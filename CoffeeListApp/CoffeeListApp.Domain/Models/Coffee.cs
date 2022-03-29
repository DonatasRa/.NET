using CoffeeListApp.Domain.Models.Bases;

namespace CoffeeListApp.Domain.Models
{
    public class Coffee : NamedEntity
    {
        public decimal ? Price { get; set; }
    }
}
