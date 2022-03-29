using CoffeeListApp.Domain.Dtos;
using CoffeeListApp.Domain.Models;

namespace CoffeeListApp.Domain.Interfaces
{
    public interface ICoffeeRepository
    {
        public Task<List<Coffee>> GetAllAsync();
    }
}
