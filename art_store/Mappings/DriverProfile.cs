using art_store.art_storeDto;
using art_store.Entities;
using AutoMapper;

namespace art_store.Mappings
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverDto>().ReverseMap();
            CreateMap<Driver, CreateDriverDto>().ReverseMap();

        }
    }
}
