
using HotelApp.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.DTOs
{
    public class RoomDto
    {
        public int Id { get; set; }

        public List<Room> Rooms { get; set; }

        public Room Room { get; set; }

        public List<Hotel> Hotels { get; set; }

        public Hotel Hotel { get; set; }

        public  int Floor { get; set; }

        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        public bool IsBooked { get; set; } = false;

        public List<Cleaner> AvailableCleaners { get; set; }
    }
}
