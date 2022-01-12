using HotelApp.Data;
using HotelApp.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Details(int id)
        {
            _context.Hotels.Find(id);
            return View("~/Views/Room/Index.cshtml"); 
        }
    }
}