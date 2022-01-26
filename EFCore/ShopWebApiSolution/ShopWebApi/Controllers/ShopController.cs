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
        public IActionResult GetAll()
        {
            try
            {
                var shop = _mapper.Map<List<GetShop>>(_shopService.GetAll());
                return StatusCode(StatusCodes.Status200OK, shop);
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
                var shop = _mapper.Map<GetShop>(_shopService.GetById(id));
                return StatusCode(StatusCodes.Status200OK, shop);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUpdateShop createShop)
        {
            try
            {
                var createdId = _shopService.Create(createShop);
                
                return StatusCode(StatusCodes.Status201Created, createdId);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateUpdateShop updateShop)
        {
            try
            {
                _shopService.Update(id, updateShop);
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
                _shopService.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
