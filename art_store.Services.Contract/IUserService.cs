using art_store.art_storeDto;

namespace art_store.Services.Contract
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);

        Task<int> Delete(int id);

        Task<List<UserDto>> GetAll();

        Task<UserDto> GetByEmail(string email);
        Task<int> Create(UserDto user);

        Task<int> Update(UserDto user);

    }
}