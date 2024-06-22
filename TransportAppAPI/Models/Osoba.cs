namespace TransportAppAPI.Models
{
    //Klasa abstrakcyjna
    public abstract class Osoba
    {
        public int idPracownika { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public DateTime dataUrodzenia { get; set; }
        public string adresZamieszkania { get; set; }
        public List<ZlecenieTransportu> zlecenia { get; set; }

        public int idPlacowki { get; set; }
        public Placowka placowka { get; set; }

        //Przesłonięcie
        public virtual decimal obliczWyplate()
        {
            return zlecenia.Count * 50;
        }

        public abstract string zwrocInformacje();
    }
}
