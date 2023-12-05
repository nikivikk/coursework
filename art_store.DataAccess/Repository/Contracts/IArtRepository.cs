using art_store.Entities;

namespace art_store.DataAccess.Repository.Contracts
{
    public interface IArtRepository
    {
        Task<Art> GetById(int id);
        //Task<Art> GetByImo(string imo);
        Task<List<Art>> GetAll();
        Task<int> Create(Art art);
        Task<int> Update(Art art);
        Task<int> Delete(int id);
    }
}