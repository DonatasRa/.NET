using AsgardMarketplace.Domain.Dtos;
using AsgardMarketplace.Domain.Models;
using AutoMapper;

namespace AsgardMarketplace.Domain.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderStatusDto>().ReverseMap();
        }
    }
}
