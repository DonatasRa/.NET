using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolWebAPI.Data;
using SchoolWebAPI.Dtos;
using SchoolWebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;


        public StudentController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public List<StudentDto> GetAll()
        {
            List<StudentDto> students = _mapper.Map<List<StudentDto>>(_dataContext.Students.ToList());
            return students;
        }

        [HttpGet("{id}")]
        public StudentDto GetById(int id)
        {
            var student = _mapper.Map<StudentDto>(_dataContext.Students.Find(id));
            return student;
        }

        [HttpPost]
        public void Create(StudentDto student)
        {
            var newStudent = new Student()
            {
                Name = student.Name,
                Sex = student.Sex,
                SchoolId = student.SchoolId
            };
            _dataContext.Add(newStudent);
            _dataContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Update(int id, StudentDto studentUpdate)
        {
            var student = _dataContext.Students.Find(id);

            student.Name = studentUpdate.Name;
            student.Sex = studentUpdate.Sex;
            student.SchoolId = studentUpdate.SchoolId;

            _dataContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _dataContext.Students.Find(id);
            _dataContext.Remove(student);
            _dataContext.SaveChanges();
        }
    }

}
