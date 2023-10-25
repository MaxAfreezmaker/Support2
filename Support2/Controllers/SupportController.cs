
using Microsoft.AspNetCore.Mvc;
using Support2.DBContext;
using Support2.Models.DBentities;

namespace Support2.Controllers
{
    public class SupportController : Controller
    {
        private readonly supportdata _context;

        public SupportController(supportdata context) 
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Demo()
        {
            var zgloszenia = _context.zgloszenia.ToList();

            if (zgloszenia != null && zgloszenia.Any())
            {
                return View(zgloszenia);
            }
            else
            {
                // Brak dostępnych rekordów, możesz obsłużyć to w odpowiedni sposób
                return View("BrakDostepnychRekordow"); // Przekierowanie do widoku informującego o braku rekordów
            }

            /*           var zgloszeniaall = _context.zgloszenia.ToList();
                       List<zgloszenial> zgloszenias = new List<zgloszenial>();
                       if (zgloszeniaall != null)
                       {

                           foreach(var zgloszenia in zgloszeniaall)
                           {
                               var zgloszenial = new zgloszenial()
                               {
                                   ID = zgloszenia.ID,
                                   Imie = zgloszenia.Imie,
                                   Nazwisko = zgloszenia.Nazwisko,
                                   Typ_zgloszenia = zgloszenia.Typ_zgloszenia,
                                   Tresc_zgloszenia = zgloszenia.Tresc_zgloszenia
                               };
                               zgloszenias.Add(zgloszenial);
                           }

                           return View(zgloszenias);
                       }
              */
            return View();
        }
    }
}
