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
        public IActionResult GetAll()
        {
            try
            {
                var shopItem = _mapper.Map<List<ShopItemDto>>(_shopItemService.GetAll());
                return StatusCode(StatusCodes.Status200OK, shopItem);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var shop = _mapper.Map<ShopItemDto>(_shopItemService.GetById(id));
                return StatusCode(StatusCodes.Status200OK, shop);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ShopItemDto createShopItem)
        {
            try
            {
                var createdId = _shopItemService.Create(createShopItem);

                return StatusCode(StatusCodes.Status201Created, createdId);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ShopItemDto updateShopItem)
        {
            try
            {
                _shopItemService.Update(id, updateShopItem);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _shopItemService.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
