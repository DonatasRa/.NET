namespace CoffeeListApp.Domain.Models.Bases
{
    public abstract class NamedEntity : Entity
    {
        public string Name { get; set; }
    }
}
