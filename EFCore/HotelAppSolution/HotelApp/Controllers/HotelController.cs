using HotelApp.Data;
using HotelApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
    }
}
