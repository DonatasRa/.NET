using ShopWebApi.Models.Bases;

namespace ShopWebApi.Models
{
    public class ShopItem : NamedEntity
    {
        public decimal ItemPrice { get; set; }

        public int ShopId { get; set; }
    }
}
