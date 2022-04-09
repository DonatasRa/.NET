using AsgardMarketplace.Domain.Enums;
using AsgardMarketplace.Domain.Models;

namespace AsgardMarketplace.Domain.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<Order> GetByUserIdAsync(int userId);
    }
}
