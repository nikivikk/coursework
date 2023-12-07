

namespace art_store.DataAccess.Repository.Contracts
{
    public interface IOrderRepository
    {
        Task<int> Delete(int id);
        Task<Order> GetById(int id);
        //Task<Order> GetByImo(string imo);
        Task<List<Order>> GetAll();
        Task<int> Create(Order order);
        Task<int> Update(Order order);
    }
}
