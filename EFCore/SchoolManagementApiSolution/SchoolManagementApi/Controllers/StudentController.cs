using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementApi.Dtos;
using SchoolManagementApi.Services;

namespace SchoolManagementApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private StudentService _studentService;
        public readonly IMapper _mapper;

        public StudentController(StudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _studentService.GetAllAsync());
            }
            catch (ArgumentException ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _studentService.GetByIdAsync(id));
            }
            catch (ArgumentException ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _studentService.RemoveAsync(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (ArgumentException ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudent createSchool)
        {
            try
            {
                var createdId = await _studentService.CreateAsync(createSchool);
                return StatusCode(StatusCodes.Status201Created, createdId);
            }
            catch (ArgumentException ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
