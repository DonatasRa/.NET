using Microsoft.AspNetCore.Mvc;
using SquaresApi.Dtos;
using SquaresApi.Services;

namespace SquaresApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private PointService _pointService;

        public PointController(PointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _pointService.GetAllAsync());
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _pointService.RemoveAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PointCrudDto createPoint)
        {
            try
            {
                var createdId = await _pointService.CreateAsync(createPoint);
                return StatusCode(StatusCodes.Status201Created, createdId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PointCrudDto updatePoint)
        {
            try
            {
                await _pointService.UpdatePointAsync(id, updatePoint);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Point Updated");
        }

    }
}
