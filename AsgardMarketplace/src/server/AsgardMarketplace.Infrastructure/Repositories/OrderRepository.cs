using AsgardMarketplace.Domain.Enums;
using AsgardMarketplace.Domain.Interfaces;
using AsgardMarketplace.Domain.Models;
using AsgardMarketplace.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AsgardMarketplace.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<Order> GetByUserIdAsync(int userId)
        {
            return await _dbSet.FirstOrDefaultAsync(o => o.UserId == userId);
        }
    }
}
