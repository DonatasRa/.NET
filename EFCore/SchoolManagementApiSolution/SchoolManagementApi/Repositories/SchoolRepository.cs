using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Models;

namespace SchoolManagementApi.Repositories
{
    public class SchoolRepository : RepositoryBase<School>
    {
        public SchoolRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<bool> CheckNameExistAsync(string schoolName)
        {
            return await _dbSet.AnyAsync(s => s.Name == schoolName);
        }

    }
}
