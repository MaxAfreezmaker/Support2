
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Support2.Areas.Identity.Data;
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
        private readonly SignInManager<Support2User> _signInManager;

        public HomeController(ILogger<HomeController> logger, supportdata context, KontaktZglosznenieData context2, SignInManager<Support2User> signInManager)
        {
            
            _logger = logger;
            _context = context;
            _context2 = context2;
            _signInManager = signInManager;
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
      /*  public IActionResult Logowanie(LoginGet model)
        {
            if (model.Login == "admin" && model.Password == "admin")
            {      
                
                return View("LogginIn/Demo");

            }
            else
            {
                return View("Badlogin");
            }
        }*/
        public IActionResult Kontakt(KontaktZgloszenie model) 
        {
            if (ModelState.IsValid)
            {
                _context2.zgloszenia.Add(model); 
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
        //     public IActionResult Demo()
        //       {
        //          return View("LogginIn/Demo");
        //     }
        //    public ActionResult Badlogin()
        //    {
        //        return View();
        //    }
        [Area("Identity")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return RedirectToAction("Login", "Home", new { area = "Identity" });
        }

        public IActionResult Register()
        {
            return RedirectToAction("Register", "Home", new { area = "Identity" });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}