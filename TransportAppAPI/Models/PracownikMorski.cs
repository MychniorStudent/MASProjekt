using TransportAppAPI.Enums;

namespace TransportAppAPI.Models
{
    public class PracownikMorski : Osoba
    {
       public StopienMarynarski stopienMarynarski;
        public int? idSuperPracownikaMorski { get; set; }
        public SuperPracownik superPracownikMorski { get; set; }
        //Przesłonięcie
        public override decimal obliczWyplate()
        {
            return zlecenia.Count * 50 + (int)stopienMarynarski * 500;
        }

        //Polimorfizm
        public override string zwrocInformacje()
        {
            return $"Nazwisko {this.nazwisko}, adres zamieszkania: {this.adresZamieszkania}, stopien marynarski {this.stopienMarynarski}";
        }
    }
}
