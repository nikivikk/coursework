using art_store.art_storeDto;
using art_store.Services.Contract;
using System.Net.Http.Json;


namespace art_store.Web.Requests
{
    public class ApiArtService : IArtService
    {
        protected readonly HttpClient _httpClient;

        public ApiArtService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> Create(ArtDto art)
        {
            var response = await _httpClient.PostAsJsonAsync("Art", art);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : throw new HttpRequestException("Couldn't create the art object");
        }

        public async Task<int> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Art/{id}");
            return response.IsSuccessStatusCode ? id : throw new HttpRequestException($"Couldn't delete the art object with id {id}");
        }

        public async Task<int> Update(ArtDto art)
        {
            var response = await _httpClient.PutAsJsonAsync($"Art/{art.Id}", art);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : throw new HttpRequestException($"Couldn't update art with id {art.Id}");
        }


        public async Task<ArtDto> GetById(int id)
        {
            
            var response = await _httpClient.GetFromJsonAsync<ArtDto>($"Art/{id}");
            return response ?? throw new HttpRequestException($"Couldn't get art with id {id}");
        }


        public async Task<List<ArtDto>> GetAll()
        {

            var response = await _httpClient.GetFromJsonAsync<List<ArtDto>>($"Art");
            return response ?? throw new HttpRequestException("Couldn't get arts");
        }

        

    }
}