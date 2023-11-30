using art_store.art_storeDto;
using art_store.Entities;
using AutoMapper;

namespace art_store.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();

        }
    }
}
