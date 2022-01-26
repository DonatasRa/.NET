using ShopWebApi.Dtos.ShopItemDtos;

namespace ShopWebApi.Dtos.ShopDtos
{
    public class GetShop
    {
        public string Name { get; set; }

        public List<ShopItemDto> ShopItems { get; set; }
    }
}
