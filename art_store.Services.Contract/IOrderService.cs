using art_store.art_storeDto;

namespace art_store.Services.Contract
{
    public interface IOrderService
    {
        Task<OrderDto> GetById(int id);

        Task<int> Delete(int id);

        Task<List<OrderDto>> GetAll();

        Task<int> Create(OrderDto order);

        Task<int> Update(OrderDto order);

    }
}