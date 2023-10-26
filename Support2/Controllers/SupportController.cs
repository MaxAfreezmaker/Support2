
using Microsoft.AspNetCore.Mvc;
using Support2.DBContext;
using Support2.Models;

namespace Support2.Controllers
{
    public class SupportController : Controller
    {
        private readonly supportdata _context;
        private readonly ILogger<SupportController> _logger;
        public SupportController(supportdata context, ILogger<SupportController> logger) 
        {
            this._context = context;
            this._logger = logger;
        }
        [HttpGet]
        public IActionResult Demo()
        {
            try
            {
                if (_context != null)
                {
                    var zgloszenial = _context.zgloszenia.ToList();

                    if (zgloszenial != null && zgloszenial.Any())
                    {
                        return View("LogginIn/Demo", zgloszenial);
                    }
                    else
                    {
                        return View("LogginIn/BrakDostepnychRekordow");
                    }
                }
                else
                {
                    
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Błąd podczas pobierania danych z bazy danych");
                return View("Error");
            }
        }
        /*
                  var zgloszeniaall = _context.zgloszenia.ToList();
                   List<zgloszenial> zgloszenias = new List<zgloszenial>();
                   if (zgloszeniaall != null)
                   {

                       foreach(var zgloszenial in zgloszeniaall)
                       {
                           var zgloszeniaas = new zgloszenial()
                           {
                               ID = zgloszenial.ID,
                               Imie = zgloszenial.Imie,
                               Nazwisko = zgloszenia;.Nazwisko,
                               Typ_zgloszenia = zgloszenial.Typ_zgloszenia,
                               Tresc_zgloszenia = zgloszenial.Tresc_zgloszenia
                           };
                           zgloszenias.Add(zgloszenial);
                       }

                       return View(zgloszenias);
                   }

        return View();
        */
    }
}

