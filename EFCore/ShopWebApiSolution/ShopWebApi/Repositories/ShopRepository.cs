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

        public List<Shop> GetAllWithShopItems()
        {
            return _dbSet.Include(s => s.ShopItems).ToList();
        }

        public bool CheckNameExist(string shopName)
        {
            return _dataContext.Shops.Select(x => x.Name).Contains(shopName);
        }
    }
}
