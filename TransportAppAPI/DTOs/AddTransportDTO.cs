namespace TransportAppAPI.DTOs
{
    public class AddTransportDTO
    {
        public string model { get; set; }
        public string marka { get; set; }
        public string nrRejestracyjny { get; set; }
        public bool czyWodny { get; set; }
        public bool czyNaziemny { get; set; }
        public bool czyNiebezpieczne { get; set; }
        public bool czyElektryczny { get; set; }
    }
}
