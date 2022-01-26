using ShopWebApi.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebApi.Models
{
    public class ShopItem : NamedEntity
    {
        public decimal ItemPrice { get; set; }

        public int ShopId { get; set; }
    }
}
