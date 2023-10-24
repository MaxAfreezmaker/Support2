using Microsoft.AspNetCore.Mvc;
using Support2.Models;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;

namespace Support2.Controllers
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
            var model = new LoginGet();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Logowanie(LoginGet model)
        {
            if (model.Login == "admin" && model.Password == "admin")
            {
                return View("demo");
            }
            else
            {
                return View("Error");
            }
        }
        public IActionResult Demo()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}