using art_store.DataAccess.Repository.Contracts;
using art_store.Entities;
using Microsoft.EntityFrameworkCore;

namespace art_store.DataAccess.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(art_storeDbContext art_storeContext) : base(art_storeContext)
        {
        }

        public async Task<int> Create(User user)
        {
            await _art_storeContext.Users.AddAsync(user);
            await _art_storeContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> Update(User user)
        {
            _art_storeContext.Users.Update(user);
            await _art_storeContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> Delete(int id)
        {
            var user = await _art_storeContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            _art_storeContext.Users.Remove(user);
            await _art_storeContext.SaveChangesAsync();
            return id;
        }
        public async Task<List<User>> GetAll()
        {
            return await _art_storeContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _art_storeContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _art_storeContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}