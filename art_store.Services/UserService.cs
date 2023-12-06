using art_store.art_storeDto;
using art_store.Services.Contract;
using art_store.DataAccess.Repository.Contracts;
using art_store.Entities;
using AutoMapper;
using art_store.DataAccess.Repository;

namespace art_store.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(UserDto user)
        {
            var userExisted = await _userRepository.GetById(user.Id);

            if (userExisted != null)
            {
                throw new Exception("User exist");
            }

            var userToAdd = _mapper.Map<User>(user);
            return await _userRepository.Create(userToAdd);
        }

        public async Task<int> Update(UserDto user)
        {
            var userToUpdate = await _userRepository.GetById(user.Id)
                ?? throw new Exception("User not exist");

            userToUpdate = _mapper.Map(user, userToUpdate);
            return await _userRepository.Update(userToUpdate);
        }

        public async Task<int> Delete(int id)
        {
            var ToDelete = await _userRepository.GetById(id)
            ?? throw new Exception("User not exist");
            return await _userRepository.Delete(id);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email)
             ?? throw new Exception("User not exist");
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<UserDto>>(users);
        }

    }
}
