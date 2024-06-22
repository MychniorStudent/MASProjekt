using TransportAppAPI.Contexts;

namespace TransportAppAPI.Models
{
    public class Towar
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public int ilosc { get; set; }
        public bool czyNiebezpieczne { get; set; }
        public string kategoria { get; set; }

        //Asocjacja do Zlecenia transportu
        public int? idTransportu { get; set; }
        public ZlecenieTransportu transport { get; set; }

        void dodajNowyTowar(string nazwa, int ilosc, bool czyNiebezpieczne)
        {
            TransportDbContext transportDbContext = new TransportDbContext();
            transportDbContext.Towary.Add(new Towar { nazwa = nazwa, ilosc = ilosc, czyNiebezpieczne = czyNiebezpieczne });
            transportDbContext.SaveChanges();
        }
    }
}
