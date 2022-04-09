using CoffeeListApp.Domain.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeListApp.Domain.Interfaces.Bases
{
    public interface IRepositoryBase<T> where T : Entity
    {
        
    }
}
