using HotelApp.Models;

namespace HotelApp.DTOs
{
    public class EditHotel
    {

        public Hotel Hotel { get; set; }

        public int CityId { get; set; }

        public List<City> SelectCities { get; set; }
    }
}
