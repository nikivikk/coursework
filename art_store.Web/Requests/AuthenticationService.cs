using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using art_store.Services.Contract;
using Blazored.LocalStorage;
using art_store.art_storeDto;
using Azure;

namespace art_store.Web.Requests
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ArtAuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient httpClient,
                           ArtAuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<RegisterResultDto> Register(RegisterDto registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync("account/register", registerModel);
            if (result.IsSuccessStatusCode)
                return new RegisterResultDto { IsSuccessful = true, Errors = null };
            return new RegisterResultDto { IsSuccessful = false, Errors = new List<string> { "Error occured" } };
        }

        public async Task<LoginResultDto> Login(LoginDto loginModel)
        {
            
            var loginAsJson = JsonSerializer.Serialize(loginModel);
            var response = await _httpClient.PostAsync("account/login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize<LoginResultDto>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); 
            if (!response.IsSuccessStatusCode)
            {
                return loginResult!;
            }

            await _localStorage.SetItemAsync("authToken", loginResult!.AccessToken);
            ((ArtAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginResult.AccessToken!);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult.AccessToken);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ArtAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> IsAuthenticated()
        {
            return await _localStorage.ContainKeyAsync("authToken");
        }
    }
}
