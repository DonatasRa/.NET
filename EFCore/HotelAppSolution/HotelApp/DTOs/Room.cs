using HotelApp.DTOs.Bases;

namespace HotelApp.DTOs
{
    public class Room : Entity
    {
        public int Floor { get; set; }

        public int HotelId { get; set; }

        public bool isBooked { get; set; } = false;

        public int RoomNum { get; set; }
    }
}
