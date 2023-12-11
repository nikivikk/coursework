using art_store.art_storeDto;
using art_store.Services.Contract;
using System.Net.Http.Json;


namespace art_store.Web.Requests
{
    public class ApiOrderService : IOrderService
    {
        protected readonly HttpClient _httpClient;

        public ApiOrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> Create(OrderDto order)
        {
            var response = await _httpClient.PostAsJsonAsync("Order", order);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : throw new HttpRequestException("Couldn't create the order object");
        }

        public async Task<int> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Order/{id}");
            return response.IsSuccessStatusCode ? id : throw new HttpRequestException($"Couldn't delete the order object with id {id}");
        }

        public async Task<int> Update(OrderDto order)
        {
            var response = await _httpClient.PutAsJsonAsync($"Order/{order.Id}", order);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<int>() : throw new HttpRequestException($"Couldn't update order with id {order.Id}");
        }


        public async Task<OrderDto> GetById(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<OrderDto>($"Order/{id}");
            return response ?? throw new HttpRequestException($"Couldn't get order with id {id}");
        }


        public async Task<List<OrderDto>> GetAll()
        {

            var response = await _httpClient.GetFromJsonAsync<List<OrderDto>>($"Order");
            return response ?? throw new HttpRequestException("Couldn't get orders");
        }



    }
}
