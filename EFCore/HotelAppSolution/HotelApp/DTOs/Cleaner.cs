using HotelApp.DTOs.Bases;

namespace HotelApp.DTOs
{
    public class Cleaner : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public City City { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
