using AsgardMarketplace.Domain.Models.Bases;

namespace AsgardMarketplace.Domain.Models
{
    public class Item : NamedEntity
    {
        public decimal Price { get; set; }

        public int ? OrderId { get; set; }
    }
}
