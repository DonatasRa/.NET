using System.ComponentModel.DataAnnotations;

namespace SquaresApi.Dtos
{
    public class PointCrudDto
    {
        [Range(-5000, 5000)]
        public int XCoordinate { get; set; }

        [Range(-5000, 5000)]
        public int YCoordinate { get; set; }
    }
}
