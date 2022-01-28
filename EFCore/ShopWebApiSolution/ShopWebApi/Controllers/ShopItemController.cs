using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Dtos.ShopItemDtos;
using ShopWebApi.Services;

namespace ShopWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShopItemController : ControllerBase
    {
        private ShopItemService _shopItemService;
        private readonly IMapper _mapper;

        public ShopItemController(ShopItemService shopItemService, IMapper mapper)
        {
            _shopItemService = shopItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var shopItem = _mapper.Map<List<ShopItemDto>>(await _shopItemService.GetAllAsync());
                return StatusCode(StatusCodes.Status200OK, shopItem);
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
                var shop = _mapper.Map<ShopItemDto>(await _shopItemService.GetByIdAsync(id));
                return StatusCode(StatusCodes.Status200OK, shop);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShopItemDto createShopItem)
        {
            try
            {
                var createdId = await _shopItemService.CreateAsync(createShopItem);

                return StatusCode(StatusCodes.Status201Created, createdId);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShopItemDto updateShopItem)
        {
            try
            {
                await _shopItemService.UpdateAsync(id, updateShopItem);
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
                await _shopItemService.DeleteAsync(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
