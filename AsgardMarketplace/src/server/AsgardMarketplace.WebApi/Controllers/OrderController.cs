using AsgardMarketplace.Domain.Dtos;
using AsgardMarketplace.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsgardMarketplace.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                return Ok(await _orderService.GetByUserIdAsync(userId));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrder)
        {
            try
            {
                var createdId = await _orderService.CreateAsync(createOrder);
                return StatusCode(StatusCodes.Status201Created, createdId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateOrderStatusDto updateStatus)
        {
            try
            {
                await _orderService.UpdateStatusAsync(updateStatus);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Order Status updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _orderService.RemoveAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
