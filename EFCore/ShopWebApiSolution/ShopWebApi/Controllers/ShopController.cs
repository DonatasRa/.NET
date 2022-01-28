using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Dtos.ShopDtos;
using ShopWebApi.Services;

namespace ShopWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private ShopService _shopService;
        public readonly IMapper _mapper;

        public ShopController(ShopService shopService, IMapper mapper)
        {
            _shopService = shopService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var shop = _mapper.Map<List<GetShop>>(await _shopService.GetAllAsync());
                return StatusCode(StatusCodes.Status200OK, shop);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var shop = _mapper.Map<GetShop>(await _shopService.GetByIdAsync(id));
                return StatusCode(StatusCodes.Status200OK, shop);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUpdateShop createShop)
        {
            try
            {
                var createdId = await _shopService.CreateAsync(createShop);
                
                return StatusCode(StatusCodes.Status201Created, createdId);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateUpdateShop updateShop)
        {
            try
            {
                await _shopService.UpdateAsync(id, updateShop);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shopService.DeleteAsync(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
