using AsgardMarketplace.Domain.Enums;
using AsgardMarketplace.Domain.Models.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsgardMarketplace.Domain.Models
{
    public class Order : Entity
    {
        public string Status { get; set; } = "Created";

        public int UserId { get; set; }
        [NotMapped]
        public Item Item { get; set; }

        public int ItemId { get; set; }
    }
}
