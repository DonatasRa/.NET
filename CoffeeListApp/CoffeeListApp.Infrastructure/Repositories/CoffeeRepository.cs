using CoffeeListApp.Data;
using CoffeeListApp.Domain.Interfaces;
using CoffeeListApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeListApp.Infrastructure.Repositories
{
    public class CoffeeRepository : RepositoryBase<Coffee>, ICoffeeRepository
    {
        public CoffeeRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
