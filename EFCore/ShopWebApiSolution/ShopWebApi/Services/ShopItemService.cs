using AutoMapper;
using ShopWebApi.Dtos.ShopItemDtos;
using ShopWebApi.Models;
using ShopWebApi.Repositories;
using ShopWebApi.Validators;

namespace ShopWebApi.Services
{
    public class ShopItemService
    {
        private readonly ShopItemRepository _shopItemRepository;
        public readonly IMapper _mapper;
        private readonly ShopItemValidator _shopItemValidator = new();

        public ShopItemService(ShopItemRepository shopItemRepository, IMapper mapper)
        {
            _shopItemRepository = shopItemRepository;
            _mapper = mapper;
        }

        public async Task<List<ShopItem>> GetAllAsync()
        {
            var shopItems = await _shopItemRepository.GetAllAsync();
            if (shopItems == null)
            {
                throw new ArgumentException("No ShopItems found");
            }

            return shopItems;
        }

        public async Task<ShopItemDto> GetByIdAsync(int id)
        {
            var shopItem = await _shopItemRepository.GetByIdAsync(id);
            if (shopItem == null)
            {
                throw new ArgumentException("ShopItem not found");
            }

            return _mapper.Map<ShopItemDto>(shopItem);
        }

        public async Task<int> CreateAsync(ShopItemDto createShopItem)
        {
            var mappedShopItem = _mapper.Map<ShopItem>(createShopItem);

            var doesNameExist = await _shopItemRepository.CheckNameExistAsync(mappedShopItem.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The Name already exists");
            }

            var isValidShopId = await _shopItemRepository.CheckShopIdAsync(mappedShopItem.ShopId);
            if (!isValidShopId)
            {
                throw new ArgumentException($"ShopId {createShopItem.ShopId} not found");
            }

            var model = new ShopItem()
            {
                ShopId = createShopItem.ShopId,
                Name = createShopItem.Name,
                ItemPrice = createShopItem.ItemPrice
            };

            ShopItemValidation(model);

            var modelId = await _shopItemRepository.CreateAsync(model);

            return modelId;
        }

        public async Task<int> UpdateAsync(int id, ShopItemDto updateShopItem)
        {
            var shopItem = await _shopItemRepository.GetByIdAsync(id);

            var doesNameExist = await _shopItemRepository.CheckNameExistAsync(updateShopItem.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The Name already exists");
            }

            shopItem.Name = updateShopItem.Name;
            shopItem.ItemPrice = updateShopItem.ItemPrice;
            shopItem.ShopId = updateShopItem.ShopId;

            ShopItemValidation(shopItem);

            await _shopItemRepository.UpdateAsync(shopItem);

            return id;
        }

        public async Task DeleteAsync(int id)
        {
            await _shopItemRepository.DeleteAsync(id);
        }

        private ShopItem ShopItemValidation(ShopItem shopItem)
        {
            var validationResult = _shopItemValidator.Validate(shopItem);
            if (!validationResult.IsValid)
            {
                foreach (var failure in validationResult.Errors)
                {
                    throw new ArgumentException("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            return shopItem;
        }
    }
}
