using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListApp.Models
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public int ShopId { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;
        public Shop Shop { get; set; }
    }
}
