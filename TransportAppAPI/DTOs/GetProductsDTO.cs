namespace TransportAppAPI.DTOs
{
    public class GetProductsDTO
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public string kategoria { get; set; }
        public int ilosc { get; set; }
        public bool czyNiebezpieczny { get; set; }
    }
}
