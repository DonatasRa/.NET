using AutoMapper;
using ShopWebApi.Dtos.ShopItemDtos;
using ShopWebApi.Models;
using ShopWebApi.Repositories;

namespace ShopWebApi.Services
{
    public class ShopItemService
    {
        private readonly ShopItemRepository _shopItemRepository;
        public readonly IMapper _mapper;

        public ShopItemService(ShopItemRepository shopItemRepository, IMapper mapper)
        {
            _shopItemRepository = shopItemRepository;
            _mapper = mapper;
        }

        public List<ShopItem> GetAll()
        {
            var shops = _shopItemRepository.GetAll();
            if (shops == null)
            {
                throw new ArgumentException("No Shops found");
            }

            return shops;
        }

        public ShopItemDto GetById(int id)
        {
            var shopItem = _shopItemRepository.GetById(id);
            if (shopItem == null)
            {
                throw new ArgumentException("Shop not found");
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

            var model = new ShopItem()
            {
                ShopId = createShopItem.ShopId,
                Name = createShopItem.Name,
                ItemPrice = createShopItem.ItemPrice
            };

            var modelId = _shopItemRepository.Create(model);

            return modelId;
        }

        public int Update(int id, ShopItemDto updateShopItem)
        {
            var shop = _shopItemRepository.GetById(id);

            var doesNameExist = _shopItemRepository.CheckNameExist(updateShopItem.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("The Name already exists");
            }

            shop.Name = updateShopItem.Name;

            _shopItemRepository.Update(shop);

            return id;
        }

        public void Delete(int id)
        {
            _shopItemRepository.Delete(id);
        }
    }
}
