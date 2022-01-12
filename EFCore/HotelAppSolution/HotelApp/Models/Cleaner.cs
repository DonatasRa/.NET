using HotelApp.Bases;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class Cleaner : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public City City { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
