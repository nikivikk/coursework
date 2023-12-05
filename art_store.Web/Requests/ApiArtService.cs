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

        public Task<int> Create(ArtDto art)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ArtDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArtDto>> GetAll()
        {

            var response = await _httpClient.GetFromJsonAsync<List<ArtDto>>($"Art");
            return response ?? throw new HttpRequestException("Couldn't get arts");
        }

        public Task<int> Update(ArtDto art)
        {
            throw new NotImplementedException();
        }
    }
}