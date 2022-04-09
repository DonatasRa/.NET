using AsgardMarketplace.Domain.Models.Bases;

namespace AsgardMarketplace.Domain.Models
{
    public class User : NamedEntity
    {
        public int ? OrderId  { get; set; }
    }
}
