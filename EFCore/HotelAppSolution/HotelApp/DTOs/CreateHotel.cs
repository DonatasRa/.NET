using HotelApp.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.DTOs
{
    public class CreateHotel
    {
        [Display(Name = "Hotel Name")]
        public string Name { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }

        public List<City> SelectCities { get; set; }

        [MinLength(5)]
        public string Address { get; set; }

        public int MaxRooms { get; set; }
    }
}
