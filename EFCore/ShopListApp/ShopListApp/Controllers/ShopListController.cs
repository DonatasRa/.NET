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

        public IActionResult Add()
        {
            var shopItem = new ShopItem();

            return View("AddItem");
        }

        [HttpPost]
        public IActionResult Add(ShopItem shopItem)
        {
            if (!ModelState.IsValid)
            {
                return View(shopItem);
            }
            _context.ShopItems.Add(shopItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var shopItem = _context.ShopItems.Find(id);
            _context.ShopItems.Remove(shopItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var shopItem = _context.ShopItems.Find(id);
            return View(shopItem);
        }

        [HttpPost]
        public IActionResult Update(ShopItem shopItem)
        {
            _context.ShopItems.Update(shopItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
