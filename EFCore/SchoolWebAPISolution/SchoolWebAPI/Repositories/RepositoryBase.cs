using Microsoft.EntityFrameworkCore;
using SchoolWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebAPI.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected DataContext _context;
        private DbSet<T> _dbSet;

        protected RepositoryBase(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        //public T GetById(int id)
        //{
        //    return _dbSet.FirstOrDefault(t => t.Id == id);
        //}
    }
}