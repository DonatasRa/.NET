using CoffeeListApp.Data;
using CoffeeListApp.Domain.Interfaces;
using CoffeeListApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeListApp.Infrastructure.Repositories
{
    public class CoffeeRepository : RepositoryBase<Coffee>, ICoffeeRepository
    {
        public CoffeeRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<bool> CheckCoffeeExistAsync(string name)
        {
            return await _dbSet.AnyAsync(c => c.Name == name);
        }
    }
}
