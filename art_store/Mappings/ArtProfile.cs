using art_store.art_storeDto;
using art_store.Entities;
using AutoMapper;

namespace art_store.Mappings
{
    public class ArtProfile : Profile
    {
        public ArtProfile()
        {
            CreateMap<Art, ArtDto>().ReverseMap();
            CreateMap<Art, CreateArtDto>().ReverseMap();

        }
    }
}
