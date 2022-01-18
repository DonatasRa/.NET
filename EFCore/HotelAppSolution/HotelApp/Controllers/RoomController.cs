using HotelApp.Data;
using HotelApp.DTOs;
using HotelApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Controllers
{
    public class RoomController : Controller
    {
        private DataContext _context;

        public RoomController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

        public IActionResult Create()
        {

            var createRoom = new RoomDto()
            {
                Hotels = _context.Hotels.ToList()
            };

            return View(createRoom);
        }
    }
}
