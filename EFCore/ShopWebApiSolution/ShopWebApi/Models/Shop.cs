using ShopWebApi.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Models
{
    public class Shop : NamedEntity
    {
        public List<ShopItem> ShopItems { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
