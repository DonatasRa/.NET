using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZooWebApp.Models;
using ZooWebApp.Services;

namespace ZooWebApp.Controllers
{
    public class ZooController : Controller
    {
        private readonly ZooService _zooService;

        public ZooController(ILogger<ZooController> logger, ZooService zooService)
        {
            _zooService = zooService;
        }


        // GET: ZooController
        public ActionResult Index()
        {
            var res = _zooService.GetAll();
            return View(res);
        }

        // POST: ZooController/DisplayAddAnimal
        [HttpPost]
        public ActionResult DisplayAddAnimal()
        {
            var empty = new ZooModel();
            return View(empty);
        }

        public IActionResult SubmitAnimal(ZooModel animal)
        {
            _zooService.AddAnimal(animal);
            return RedirectToAction("DisplayAddAnimal");
        }

        // POST: ZooController/Edit/5
        [HttpPost]
        public IActionResult DisplayUpdateAnimal(ZooModel animal)
        {
            return View(animal);
        }

        public IActionResult SubmitUpdate(ZooModel animal)
        {
            _zooService.UpdateAnimal(animal);
            return RedirectToAction("Index");
        }

        // GET: ZooController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ZooController/Delete/5
        [HttpPost]
        public IActionResult DeleteAnimal(ZooModel animal)
        {
             _zooService.DeleteAnimal(animal);
             return RedirectToAction("Index");
        }
    }
}
