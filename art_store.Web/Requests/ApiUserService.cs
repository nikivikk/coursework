using art_store.art_storeDto;
using art_store.Services.Contract;
using System.Net.Http.Json;


namespace art_store.Web.Requests
{
    public class ApiUserService : IUserService
    {
        protected readonly HttpClient _httpClient;

        public ApiUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> Create(UserDto user)
        {
            var response = await _httpClient.PostAsJsonAsync("User", user);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : throw new HttpRequestException("Couldn't create the user object");
        }

        public async Task<int> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"User/{id}");
            return response.IsSuccessStatusCode ? id : throw new HttpRequestException($"Couldn't delete the user object with id {id}");
        }

        public async Task<int> Update(UserDto user)
        {
            var response = await _httpClient.PutAsJsonAsync(requestUri: $"User/{user.Id}", user);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : throw new HttpRequestException($"Couldn't update user with id {user.Id}");
        }


        public async Task<UserDto> GetById(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<UserDto>($"User/{id}");
            return response ?? throw new HttpRequestException($"Couldn't get user with id {id}");
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<UserDto>($"User/{email}");
                return response;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }



        public async Task<List<UserDto>> GetAll()
        {

            var response = await _httpClient.GetFromJsonAsync<List<UserDto>>($"User");
            return response ?? throw new HttpRequestException("Couldn't get users");
        }



    }
}