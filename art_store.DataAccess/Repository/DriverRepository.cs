using art_store.DataAccess.Repository.Contracts;
using art_store.Entities;
using Microsoft.EntityFrameworkCore;

namespace art_store.DataAccess.Repository
{
    public class DriverRepository : BaseRepository, IDriverRepository
    {
        public DriverRepository(art_storeDbContext art_storeContext) : base(art_storeContext)
        {
        }

        public async Task<int> Create(Driver driver)
        {
            await _art_storeContext.Drivers.AddAsync(driver);
            await _art_storeContext.SaveChangesAsync();
            return driver.Id;
        }

        public async Task<int> Update(Driver driver)
        {
            _art_storeContext.Drivers.Update(driver);
            await _art_storeContext.SaveChangesAsync();
            return driver.Id;
        }

        public async Task<int> Delete(int id)
        {
            var driver = await _art_storeContext.Drivers.FirstOrDefaultAsync(x => x.Id == id);
            _art_storeContext.Drivers.Remove(driver);
            await _art_storeContext.SaveChangesAsync();
            return id;
        }

        //public async Task<string> DeleteById(int id)
        //{
        //    var driver = await _art_storeContext.Drivers.FirstOrDefaultAsync(x => x.Id == id);
        //    if (driver != null)
        //    {
        //        _art_storeContext.Drivers.Remove(driver);
        //        await _art_storeContext.SaveChangesAsync();
        //        return $"Driver {id} was deleted";
        //    }
        //}
        public async Task<List<Driver>> GetAll()
        {
            return await _art_storeContext.Drivers.ToListAsync();
        }

        public async Task<Driver> GetById(int id)
        {
            return await _art_storeContext.Drivers.FirstOrDefaultAsync(x => x.Id == id);
        }

        //public async Task<Driver> GetByImo(string imo)
        //{
        //    return await _art_storeContext.Drivers.FirstOrDefaultAsync(x => x.Imo == imo);
        //}
    }
}
