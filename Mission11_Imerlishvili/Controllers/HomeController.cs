using Microsoft.AspNetCore.Mvc;
using Mission11_Imerlishvili.Models;
using System.Diagnostics;

namespace Mission11_Imerlishvili.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

      
    }
}
