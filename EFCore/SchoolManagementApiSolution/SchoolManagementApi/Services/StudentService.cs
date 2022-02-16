using AutoMapper;
using SchoolManagementApi.Dtos;
using SchoolManagementApi.Models;
using SchoolManagementApi.Repositories;
using SchoolManagementApi.Validators;

namespace SchoolManagementApi.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        public readonly IMapper _mapper;
        private readonly StudentValidator _studentValidator = new();

        public StudentService(StudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<GetStudent>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            if (students == null)
            {
                throw new ArgumentException("No Students found");
            }

            return _mapper.Map<List<GetStudent>>(students);
        }

        public async Task<GetStudent> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                throw new ArgumentException("Student not found");
            }

            return _mapper.Map<GetStudent>(student);
        }

        public async Task RemoveAsync(int id)
        {
            await _studentRepository.RemoveAsync(id);
        }

        public async Task<int> CreateAsync(CreateStudent createStudent)
        {
            var newStudent = new Student()
            {
                FirstName = createStudent.FirstName,
                LastName = createStudent.LastName,
                SchoolId = createStudent.SchoolId
            };

            var newStudentId = await _studentRepository.CreateAsync(newStudent);

            return newStudentId;
        }
    }
}
