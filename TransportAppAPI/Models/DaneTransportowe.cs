namespace TransportAppAPI.Models
{
    //Asocjacja z atrybutem, asocjacja między Placowką i Zleceniem Transportu
    public class DaneTransportowe
    {
        public int id{ get; set; }
        public DateTime dataWyruszenia { get; set; }
        //Atrybut złożony
        public DateTime planowanaDataDostarczenia { get; set; }
        //Atrybut opcjonalny
        public DateTime? dataDostarczenia { get; set; }

        public int idZlecenieTransportu { get; set; }
        public ZlecenieTransportu zelecenieTransportu { get; set; }
        public int idPlacowki { get; set; }
        public Placowka placowka { get; set; }
    }
}
