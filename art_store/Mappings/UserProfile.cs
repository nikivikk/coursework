using art_store.art_storeDto;
using art_store.Entities;
using AutoMapper;

namespace art_store.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ReverseMap()
                // Naming can be refactored.
                .ForMember(dest => dest.Name, options => options.MapFrom(x => x.Username));
            CreateMap<User, CreateUserDto>().ReverseMap();

        }
    }
}
