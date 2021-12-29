using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopListApp.Data;
using ShopListApp.Dtos;
using ShopListApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopListApp.Controllers
{
    public class ShopItemsController : Controller
    {
        private DataContext _context;

        public ShopItemsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ShopItem> shopItems = _context.ShopItems.Include(c => c.ShopItemTags).ThenInclude(c => c.Tag).ToList();

            return View(shopItems);
        }

        public IActionResult Add()
        {
            var addShopItem = new AddShopItem()
            {
                ShopItems = new ShopItem(),
                AllShops = _context.Shops.ToList(),
                Tags = _context.Tags.ToList()
            };
            return View(addShopItem);
        }

        [HttpPost]
        public IActionResult Add(AddShopItem addshopItem)
        {
            if (!ModelState.IsValid)
            {
                addshopItem.AllShops = _context.Shops.ToList();
                return View(addshopItem);
            }

            _context.ShopItems.Add(addshopItem.ShopItems);
            _context.SaveChanges();

            foreach (var tagId in addshopItem.SelectedTagIds)
            {
                _context.ShopItemTags.Add(new ShopItemTag()
                {
                    TagId = tagId,
                    ShopItemId = addshopItem.ShopItems.Id
                });
            }
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
            var updateShopItem = new UpdateShopItem()
            {
                ShopItems = _context.ShopItems.Find(id),
                AllShops = _context.Shops.ToList()
            };

            return View(updateShopItem);
        }

        [HttpPost]
        public IActionResult Update(UpdateShopItem updateShopItem)
        {
            _context.ShopItems.Update(updateShopItem.ShopItems);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}