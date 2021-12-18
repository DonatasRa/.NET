using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopListApp.Data;
using ShopListApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopListApp.Controllers
{
    public class ShopListController : Controller
    {
        private DataContext _context;

        public ShopListController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ShopItem> shopItems = _context.ShopItems.Include(c => c.Shop).ToList();

            return View(shopItems);
        }

    }
}
