using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementApi.Dtos;
using SchoolManagementApi.Services;

namespace SchoolManagementApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private SchoolService _schoolService;
        public readonly IMapper _mapper;

        public SchoolController(SchoolService schoolService, IMapper mapper)
        {
            _schoolService = schoolService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _schoolService.GetAllAsync());
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
                await _schoolService.RemoveAsync(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (ArgumentException ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSchool createSchool)
        {
            try
            {
                var createdId = await _schoolService.CreateAsync(createSchool);
                return StatusCode(StatusCodes.Status201Created, createdId);
            }
            catch (ArgumentException ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
