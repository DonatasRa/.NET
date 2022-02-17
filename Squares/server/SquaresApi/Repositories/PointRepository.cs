
using Microsoft.EntityFrameworkCore;
using SquaresApi.Data;
using SquaresApi.Models;

namespace SquaresApi.Repositories
{
    public class PointRepository : RepositoryBase<PointModel>
    {
        public PointRepository(DataContext dataContext) : base(dataContext)
        {
            
        }

        public async Task<bool> CheckPointExistAsync(int xCoordinate, int yCoordinate)
        {
            return await _dbSet.AnyAsync(p => (p.XCoordinate == xCoordinate) && (p.YCoordinate == yCoordinate));
        }
    }
}
