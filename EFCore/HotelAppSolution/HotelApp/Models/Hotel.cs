using HotelApp.Models.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApp.Models
{
    public class Hotel : NamedEntity
    {
        public City City { get; set; }

        public int? CityId { get; set; }

        public string Address { get; set; }

        public int MaxRooms { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
    