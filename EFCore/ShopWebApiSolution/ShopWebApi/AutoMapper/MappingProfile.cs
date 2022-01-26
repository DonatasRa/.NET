using AutoMapper;
using ShopWebApi.Dtos.ShopDtos;
using ShopWebApi.Dtos.ShopItemDtos;
using ShopWebApi.Models;

namespace ShopWebApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shop, GetShop>().ReverseMap();
            CreateMap<Shop, CreateUpdateShop>().ReverseMap();
            CreateMap<ShopItem, ShopItemDto>().ReverseMap();
        }
    }
}
