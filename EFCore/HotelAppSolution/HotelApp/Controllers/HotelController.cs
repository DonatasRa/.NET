using HotelApp.Data;
using HotelApp.DTOs;
using HotelApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Controllers
{
    public class HotelController : Controller
    {
        private DataContext _context;

        public HotelController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Hotel> hotels = _context.Hotels.Include(h => h.City).ToList();
            return View(hotels);
        }

        public IActionResult Create()
        {

            var createHotel = new CreateHotel()
            {
                SelectCities = _context.Cities.ToList()
            };

            return View(createHotel);
        }

        [HttpPost]
        public IActionResult Create(CreateHotel createHotel)
        {
            var hotel = new Hotel()
            {
                Name = createHotel.Name,
                CityId = createHotel.CityId,
                Address = createHotel.Address,
                MaxRooms = createHotel.MaxRooms
            };
                       
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var hotelRooms = new HotelDetails()
            {
                AvailableRooms = _context.Rooms.Where(r => r.HotelId == id).Where(r => r.isBooked == false).ToList(),
                BookedRooms = _context.Rooms.Where(r => r.HotelId == id).Where(r => r.isBooked == true).ToList()
            };

            return View("~/Views/Hotel/Details.cshtml", hotelRooms);
        }

        public IActionResult Edit(int id)
        {
            var hotel = new EditHotel()
            {
                Hotel = _context.Hotels.Find(id),
                SelectCities = _context.Cities.ToList()
            };

            return View(hotel);
        }

        [HttpPost]
        public IActionResult Edit(EditHotel editHotel)
        {
            var hotel = editHotel.Hotel;
            hotel.CityId = editHotel.CityId;

            _context.Hotels.Update(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var hotel = _context.Hotels.Find(id);
            _context.Hotels.Remove(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}