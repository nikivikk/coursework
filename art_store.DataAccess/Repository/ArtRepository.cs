using art_store.DataAccess.Repository.Contracts;
using art_store.Entities;
using Microsoft.EntityFrameworkCore;

namespace art_store.DataAccess.Repository
{
    public class ArtRepository : BaseRepository, IArtRepository
    {
        public ArtRepository(art_storeDbContext art_storeContext) : base(art_storeContext)
        {
        }

        public async Task<int> Create(Art art)
        {
            await _art_storeContext.Arts.AddAsync(art);
            await _art_storeContext.SaveChangesAsync();
            return art.Id;
        }

        public async Task<int> Update(Art art)
        {
            _art_storeContext.Arts.Update(art);
            await _art_storeContext.SaveChangesAsync();
            return art.Id;
        }

        public async Task<int> Delete(int id)
        {
            var art = await _art_storeContext.Arts.FirstOrDefaultAsync(x => x.Id == id);
            _art_storeContext.Arts.Remove(art);
            await _art_storeContext.SaveChangesAsync();
            return id;
        }
        public async Task<List<Art>> GetAll()
        {
            return await _art_storeContext.Arts.Include(x => x.Order)
                .ToListAsync();
        }

        public async Task<Art> GetById(int id)
        {
            return await _art_storeContext.Arts.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
