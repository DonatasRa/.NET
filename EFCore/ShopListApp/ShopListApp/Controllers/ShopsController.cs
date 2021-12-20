using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopListApp.Data;
using ShopListApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopListApp.Controllers
{
    public class ShopsController : Controller
    {
        private DataContext _context;

        public ShopsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Shop> shops = _context.Shops.ToList();

            return View(shops);
        }

        public IActionResult Add()
        {
            var shop = new Shop();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }
            _context.Shops.Add(shop);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var shop = _context.Shops.Find(id);
            _context.Shops.Remove(shop);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var shop = _context.Shops.Find(id);
            return View(shop);
        }

        [HttpPost]
        public IActionResult Update(Shop shop)
        {
            _context.Shops.Update(shop);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
