using art_store.art_storeDto;

namespace art_store.Services.Contract
{
    public interface IDriverService
    {
        Task<DriverDto> GetById(int id);

        Task<int> Delete(int id);

        Task<List<DriverDto>> GetAll();

        Task<int> Create(DriverDto driver);

        Task<int> Update(DriverDto driver);

    }
}
