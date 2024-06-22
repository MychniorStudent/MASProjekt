namespace TransportAppAPI.DTOs
{
    public class GetOrdersDTO
    {
        public int id { get; set; }
        public string nazwisko { get; set; }
        public string status { get; set; }
        public DateTime dataWyruszenia { get; set; }
        public DateTime planowanaDataDostarczenia { get; set; }
        public DateTime? dataDostarczenia { get; set; }
        public string adres { get; set; }
    }
}
