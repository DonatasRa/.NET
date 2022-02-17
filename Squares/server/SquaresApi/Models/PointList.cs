using SquaresApi.Models.Bases;

namespace SquaresApi.Models
{
    public class PointList : NamedEntity
    {
        public List<PointModel> Points { get; set; }
    }
}
