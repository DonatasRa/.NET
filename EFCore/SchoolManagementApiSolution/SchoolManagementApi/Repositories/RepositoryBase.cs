using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Models.Bases;

namespace SchoolManagementApi.Repositories
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

        public async Task RemoveAsync(int entityId)
        {
            var entity = await GetByIdAsync(entityId);
            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<int> CreateAsync(T model)
        {
            await AddAsync(model);
            
            return model.Id;
        }

        public async Task AddAsync(T entity)
        {
            _dataContext.Add(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
