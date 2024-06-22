namespace TransportAppAPI.DTOs
{
    public class GetTransportsDTO
    {
        public int id { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public bool czyMozeNiebezpieczne { get; set; }
    }
}
