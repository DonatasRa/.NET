using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZooWebApp.Services;

namespace ZooWebApp.Controllers
{
    public class ZooController : Controller
    {
        private readonly ILogger<ZooController> _logger;
        private readonly ZooService _zooService;

        public ZooController(ILogger<ZooController> logger, ZooService zooService)
        {
            _logger = logger;
            _zooService = zooService;
        }

        public IActionResult Index()
        {
            var res = _zooService.GetAll();
            return View(res);
        }

       

        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}
