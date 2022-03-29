using CoffeeListApp.Domain.Dtos.Bases;

namespace CoffeeListApp.Domain.Dtos
{
    public class CoffeeDto : NamedEntity
    {
        public decimal ? Price { get; set; }
    }
}
