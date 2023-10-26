
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Support2.DBContext;
using Support2.Models;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;

namespace Support2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly supportdata _context;


        public HomeController(ILogger<HomeController> logger, supportdata context)
        {
            
            _logger = logger;
            _context = context;
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
                
                return View("LogginIn/Demo");

            }
            else
            {
                return View("Badlogin");
            }
        }
        public IActionResult PrivacyL()
        {
            return View("LogginIn/PrivacyL");
        }
        public IActionResult Demo()
        {
            return View("LogginIn/Demo");
        }
        public ActionResult Badlogin()
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