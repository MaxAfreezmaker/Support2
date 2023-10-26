using System.ComponentModel;

namespace Support2.Models
{

    public class zgloszenial
    {
        [DisplayName("Identyfikator")]
        public int ID { get; set; }
        [DisplayName("Imie")]
        public string Imie { get; set; }
        [DisplayName("Nazwisko")]
        public string Nazwisko { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Typ Zgłoszenia")]
        public int Typ_zgloszenia { get; set; }
        [DisplayName("Treść zgłoszenia")]
        public string opis { get; set; }
        [DisplayName("Imie i Nazwisko")]
        public string FullName
        {
            get { return Imie + " " + Nazwisko; }
        }
    }
}
