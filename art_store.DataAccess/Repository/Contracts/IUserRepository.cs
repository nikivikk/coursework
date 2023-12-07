using art_store.Entities;


namespace art_store.DataAccess.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task<int> Delete(int id);
        Task<User> GetById(int id);
        //Task<User> GetByImo(string imo);
        Task<List<User>> GetAll();
        Task<int> Create(User user);
        Task<int> Update(User user);
    }
}
