using Microsoft.EntityFrameworkCore;
using SquaresApi.Data;
using SquaresApi.Models;

namespace SquaresApi.Repositories
{
    public class PointListRepository : RepositoryBase<PointList>
    {
        public PointListRepository(DataContext dataContext) : base(dataContext)
        {

        }

        public async Task<bool> CheckNameExistAsync(string pointListName)
        {
            return await _dbSet.AnyAsync(s => s.Name == pointListName);
        }
    }
}
