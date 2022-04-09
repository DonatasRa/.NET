using CoffeeListApp.Domain.Dtos;
using CoffeeListApp.Domain.Models;

namespace CoffeeListApp.Domain.Interfaces
{
    public interface ICoffeeRepository
    {
        public Task<List<Coffee>> GetAllAsync();

        public Task<Coffee> GetByIdAsync(int id);

        public Task RemoveAsync(int entityId);

        public Task<int> CreateAsync(Coffee model);

        public Task AddAsync(Coffee entity);
    }
}
