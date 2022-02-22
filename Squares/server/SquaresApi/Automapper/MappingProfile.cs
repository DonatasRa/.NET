using AutoMapper;
using SquaresApi.Dtos;
using SquaresApi.Models;

namespace SquaresApi.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PointModel, PointCrudDto>().ReverseMap();
            CreateMap<PointList, PointListDto>().ReverseMap();
        }
    }
}
