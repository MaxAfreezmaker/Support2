using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Support2.Models.DBentities
{
    public class zgloszenial
    {
        [DisplayName("Identyfikator")]
        public int ID { get; set; }
        [DisplayName("Imie")]
        public string Imie { get; set; }
        [DisplayName("Nazwisko")]
        public string Nazwisko { get; set; }
        [DisplayName("Typ Zgłoszenia")]
        public int Typ_zgloszenia { get; set; }
        [DisplayName("Treść zgłoszenia")]
        public string Tresc_zgloszenia { get; set; }
        [DisplayName("Imie i Nazwisko")]
        public string FullName
        {
            get { return Imie + " " + Nazwisko; }
        }
    }
}
