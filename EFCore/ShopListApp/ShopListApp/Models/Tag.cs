using ShopListApp.Models;
using System.Collections.Generic;

namespace ShopListApp.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public List<ShopItemTag> ShopItemTags { get; set; }
    }
}
