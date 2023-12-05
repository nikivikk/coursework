using art_store.art_storeDto;
using art_store.Entities;
using AutoMapper;

namespace art_store.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();

        }
    }
}

