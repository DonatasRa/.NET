using SchoolWebAPI.Data;
using SchoolWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebAPI.Repositories
{
    public class SchoolRepository : RepositoryBase<School>
    {
        public SchoolRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
