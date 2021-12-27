using ShopListApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListApp.Dtos
{
    public class AddShopItem
    {
        public ShopItem ShopItems { get; set; }
        public List<Shop> AllShops { get; set; }
    }
}
