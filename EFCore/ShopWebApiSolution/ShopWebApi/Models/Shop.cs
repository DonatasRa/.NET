using ShopWebApi.Models.Bases;

namespace ShopWebApi.Models
{
    public class Shop : NamedEntity
    {
        public List<ShopItem> ShopItems { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
