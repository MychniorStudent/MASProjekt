namespace TransportAppAPI.DTOs
{
    public class AddOrderDTO
    {
        public DateTime dataWyruszenia { get; set; }
        public DateTime planowanaDataDostraczenia { get; set; }
        public string adresDostawy { get; set; }
        public int idTransportu { get; set; }
        public List<int> idProduktow { get; set; }
    }
}
