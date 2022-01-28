using ShopWebApi.Models;
using ShopWebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopWebApi.Repositories
{
    public class ShopRepository : RepositoryBase<Shop>
    {
 
        public ShopRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<List<Shop>> GetAllWithShopItemsAsync()
        {
            return await _dbSet.Include(s => s.ShopItems).ToListAsync();
        }

        public async Task<bool> CheckNameExistAsync(string shopName)
        {
            return await _dbSet.AnyAsync(s => s.Name == shopName);
        }
    }
}
