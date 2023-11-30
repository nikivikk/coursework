using art_store.DataAccess.Repository.Contracts;
using art_store.Entities;
using Microsoft.EntityFrameworkCore;

namespace art_store.DataAccess.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(art_storeDbContext art_storeContext) : base(art_storeContext)
        {
        }

        public async Task<int> Create(Order order)
        {
            await _art_storeContext.Orders.AddAsync(order);
            await _art_storeContext.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> Update(Order order)
        {
            _art_storeContext.Orders.Update(order);
            await _art_storeContext.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> Delete(int id)
        {
            var order = await _art_storeContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            _art_storeContext.Orders.Remove(order);
            await _art_storeContext.SaveChangesAsync();
            return id;
        }
        public async Task<List<Order>> GetAll()
        {
            return await _art_storeContext.Orders.Include(x => x.Arts)
                .ToListAsync(); ;
        }

        public async Task<Order> GetById(int id)
        {
            return await _art_storeContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}