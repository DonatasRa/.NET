using AsgardMarketplace.Domain.Enums;

namespace AsgardMarketplace.Domain.Dtos
{
    public class UpdateOrderStatusDto
    {
        public int Id { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
