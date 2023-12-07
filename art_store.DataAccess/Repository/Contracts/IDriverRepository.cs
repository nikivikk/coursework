using art_store.Entities;


namespace art_store.DataAccess.Repository.Contracts
{
    public interface IDriverRepository
    {
        Task<Driver> GetById(int id);
        Task<int> Delete(int id);
        //Task<Driver> GetByImo(string imo);
        Task<List<Driver>> GetAll();
        Task<int> Create(Driver driver);
        Task<int> Update(Driver driver);
    }
}
