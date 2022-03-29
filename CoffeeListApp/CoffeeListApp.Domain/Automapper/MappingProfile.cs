using AutoMapper;
using CoffeeListApp.Domain.Dtos;
using CoffeeListApp.Domain.Models;

namespace CoffeeListApp.Domain.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coffee, CoffeeDto>().ReverseMap();
        }
    }
}
