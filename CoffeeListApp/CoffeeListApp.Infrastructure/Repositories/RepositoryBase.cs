using CoffeeListApp.Data;
using CoffeeListApp.Domain.Models.Bases;
using Microsoft.EntityFrameworkCore;

namespace CoffeeListApp.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> where T : Entity
    {
        protected DataContext _dataContext;
        protected DbSet<T> _dbSet;

        protected RepositoryBase(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
