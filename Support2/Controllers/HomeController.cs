
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
        private readonly KontaktZglosznenieData _context2;


        public HomeController(ILogger<HomeController> logger, supportdata context, KontaktZglosznenieData context2)
        {
            
            _logger = logger;
            _context = context;
            _context2 = context2;
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
        public IActionResult Kontakt(KontaktZgloszenie model) 
        {
            if (ModelState.IsValid)
            {
                _context2.KontaktZgloszenieDownload.Add(model); 
                _context2.SaveChanges(); 
                return RedirectToAction("Potwierdzenie");
            }
            return View(model);
        }
        public IActionResult Form_Kontakt()
        {
            return View("ThankYouForContact");
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