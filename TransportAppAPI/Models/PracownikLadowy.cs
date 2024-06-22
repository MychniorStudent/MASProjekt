using System.ComponentModel.DataAnnotations.Schema;
using TransportAppAPI.Enums;

namespace TransportAppAPI.Models
{
    public class PracownikLadowy : Osoba
    {
        public string kategoriePJ { get; set; }

        //Atrybut powtarzalny

        [NotMapped]
        public List<KategoriaPJ> kategoriaPJ
        {
            get => kategoriePJ?.Split(',').Select(Enum.Parse<KategoriaPJ>).ToList();
            set => kategoriePJ = value != null ? string.Join(",", value) : null;
        }
        public int? idSuperPracownikaLadowy { get; set; }
        public SuperPracownik superPracownikLadowy { get; set; }
        //Przesłonięcie
        public override decimal obliczWyplate()
        {
           return zlecenia.Count * 50 + kategoriaPJ.Count * 400;
        }

        //Polimorfizm
        public override string zwrocInformacje()
        {
            return $"Nazwisko {this.nazwisko}, adres zamieszkania: {this.adresZamieszkania}, kategorie prawa jazdy {kategoriaPJ}";
        }
    }
}
