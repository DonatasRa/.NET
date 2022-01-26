using ShopWebApi.Data;
using ShopWebApi.Models;

namespace ShopWebApi.Repositories
{
    public class ShopItemRepository : RepositoryBase<ShopItem>
    {
        public ShopItemRepository(DataContext dataContext) : base(dataContext)
        {
            
        }

        public bool CheckNameExist(string shopItemName)
        {
            return _dataContext.ShopItems.Select(x => x.Name).Contains(shopItemName);
        }
    }
}
