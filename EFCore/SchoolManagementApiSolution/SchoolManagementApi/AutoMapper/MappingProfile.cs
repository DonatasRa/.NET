using AutoMapper;
using SchoolManagementApi.Dtos;
using SchoolManagementApi.Models;

namespace SchoolManagementApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<School, GetSchool>().ReverseMap();
            CreateMap<School, CreateSchool>().ReverseMap();
            CreateMap<Student, GetStudent>().ReverseMap();
            CreateMap<Student, CreateStudent>().ReverseMap();
        }
    }
}
