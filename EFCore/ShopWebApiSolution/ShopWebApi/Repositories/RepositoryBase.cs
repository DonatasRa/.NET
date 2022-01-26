using Microsoft.EntityFrameworkCore;
using ShopWebApi.Data;
using ShopWebApi.Models.Bases;

namespace ShopWebApi.Repositories
{
    public abstract class RepositoryBase<T> where T : NamedEntity
    {
        protected DataContext _dataContext;
        protected DbSet<T> _dbSet;

        protected RepositoryBase(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        
        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id);
        }

        public int Create(T model)
        {
            Add(model);

            return model.Id;
        }

        public void Add(T entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);
            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }
    }
}
