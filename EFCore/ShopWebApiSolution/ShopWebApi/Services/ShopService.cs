using AutoMapper;
using ShopWebApi.Dtos.ShopDtos;
using ShopWebApi.Models;
using ShopWebApi.Repositories;
using ShopWebApi.Validators;

namespace ShopWebApi.Services
{
    public class ShopService
    {
        private readonly ShopRepository _shopRepository;
        public readonly IMapper _mapper;
        private readonly ShopValidator _shopValidator = new();

        public ShopService(ShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }

        public async Task<List<GetShop>> GetAllAsync()
        {
            var shops = await _shopRepository.GetAllWithShopItemsAsync();
            if (shops == null)
            {
                throw new ArgumentException("No Shops found");
            }

            return _mapper.Map<List<GetShop>>(shops);
        }

        public async Task<GetShop> GetByIdAsync(int id)
        {
            var shop = await _shopRepository.GetByIdAsync(id);
            if (shop == null)
            {
                throw new ArgumentException("Shop not found");
            }

            return _mapper.Map<GetShop>(shop);
        }

        public async Task<int> CreateAsync(CreateUpdateShop createShop)
        {
            var mappedShop = _mapper.Map<Shop>(createShop);

            var doesNameExist = await _shopRepository.CheckNameExistAsync(mappedShop.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The Name already exists");
            }

            var model = new Shop()
            {
                Name = createShop.Name
            };

            ShopValidation(model);

            var modelId = await _shopRepository.CreateAsync(model);

            return modelId;
        }

        public async Task<int> UpdateAsync(int id, CreateUpdateShop updateShop)
        {
            var shop = await _shopRepository.GetByIdAsync(id);

            var doesNameExist = await _shopRepository.CheckNameExistAsync(updateShop.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The Name already exists");
            }

            shop.Name = updateShop.Name;

            ShopValidation(shop);

            await _shopRepository.UpdateAsync(shop);

            return id;
        }

        public async Task DeleteAsync(int id)
        {
            await _shopRepository.DeleteAsync(id);
        }

        private Shop ShopValidation(Shop shop)
        {
            var validationResult = _shopValidator.Validate(shop);
            if (!validationResult.IsValid)
            {
                foreach (var failure in validationResult.Errors)
                {
                    throw new ArgumentException("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            return shop;
        }
    }
}