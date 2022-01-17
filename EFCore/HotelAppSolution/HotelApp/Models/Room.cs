using HotelApp.Bases;

namespace HotelApp.Models
{
    public class Room : Entity
    {
        public int Floor { get; set; }

        public int HotelId { get; set; }

        public bool isBooked { get; set; } = false;

        public int RoomNumber { get; set; }
    }
}
