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

        public List<ShopItem> GetAll()
        {
            var shopItems = _shopItemRepository.GetAll();
            if (shopItems == null)
            {
                throw new ArgumentException("No ShopItems found");
            }

            return shopItems;
        }

        public ShopItemDto GetById(int id)
        {
            var shopItem = _shopItemRepository.GetById(id);
            if (shopItem == null)
            {
                throw new ArgumentException("ShopItem not found");
            }

            return _mapper.Map<ShopItemDto>(shopItem);
        }

        public int Create(ShopItemDto createShopItem)
        {
            var mappedShopItem = _mapper.Map<ShopItem>(createShopItem);

            var doesNameExist = _shopItemRepository.CheckNameExist(mappedShopItem.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The Name already exists");
            }

            var isValidShopId = _shopItemRepository.CheckShopId(mappedShopItem.ShopId);
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

            var modelId = _shopItemRepository.Create(model);

            return modelId;
        }

        public int Update(int id, ShopItemDto updateShopItem)
        {
            var shopItem = _shopItemRepository.GetById(id);

            var doesNameExist = _shopItemRepository.CheckNameExist(updateShopItem.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The Name already exists");
            }

            shopItem.Name = updateShopItem.Name;

            ShopItemValidation(shopItem);

            _shopItemRepository.Update(shopItem);

            return id;
        }

        public void Delete(int id)
        {
            _shopItemRepository.Delete(id);
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
