using AutoMapper;
using SchoolWebAPI.Dtos;
using SchoolWebAPI.Models;

namespace SchoolWebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<School, SchoolDto>();
            CreateMap<Student, StudentDto>();
        }
    }
  
}
