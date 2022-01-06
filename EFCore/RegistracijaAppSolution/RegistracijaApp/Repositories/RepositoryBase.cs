using Microsoft.EntityFrameworkCore;
using RegistracijaApp.Data;
using RegistracijaApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegistracijaApp.Repositories
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
    }
}
