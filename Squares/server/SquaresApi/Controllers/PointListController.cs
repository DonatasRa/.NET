using Microsoft.AspNetCore.Mvc;
using SquaresApi.Dtos;
using SquaresApi.Services;

namespace SquaresApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PointListController : ControllerBase
    {
        private PointListService _pointListService;

        public PointListController(PointListService pointListService)
        {
            _pointListService = pointListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _pointListService.GetAllAsync());
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
                await _pointListService.RemoveAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PointListDto createPointList)
        {
            try
            {
                var createdId = await _pointListService.CreateAsync(createPointList);
                return StatusCode(StatusCodes.Status201Created, createdId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PointListDto updatePointList)
        {
            try
            {
                await _pointListService.UpdatePointListAsync(id, updatePointList);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Point List Updated");
        }

    }
}
