using HotelApp.Models;

namespace HotelApp.DTOs
{
    public class HotelDetails
    {
        public List<Room> BookedRooms { get; set; }

        public List<Room> AvailableRooms { get; set; }
    }
}
