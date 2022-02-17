
using SquaresApi.Models.Bases;
using System.ComponentModel.DataAnnotations;

namespace SquaresApi.Models
{
    public class PointModel : Entity
    {
        [Range(-5000, 5000)]
        public int XCoordinate  { get; set; }

        [Range(-5000, 5000)]
        public int YCoordinate { get; set; }

        public PointList PointList { get; set; }
    }
}
