namespace TransportAppAPI.Models
{
    //Wielodziedziczenie
    public class SuperPracownik
    {
        public int id { get; set; }
        public int idPracownikLadowy { get; set; }
        public PracownikLadowy pracownikLadowy { get; set; }
        public int idPracownikMorski { get; set; }
        public PracownikMorski pracownikMorski { get; set; }
    }
}
