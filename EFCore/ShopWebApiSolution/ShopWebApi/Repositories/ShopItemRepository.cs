using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data;
using ShopWebApi.Models;

namespace ShopWebApi.Repositories
{
    public class ShopItemRepository : RepositoryBase<ShopItem>
    {
        public ShopItemRepository(DataContext dataContext) : base(dataContext)
        {
            
        }

        public async Task<bool> CheckNameExistAsync(string shopItemName)
        {
            return await _dataContext.ShopItems.AnyAsync(x => x.Name == shopItemName);
        }

        public async Task<bool> CheckShopIdAsync(int id)
        {
            return await _dbSet.AnyAsync(s => s.ShopId == id);
        }
    }
}
