namespace TransportAppAPI.Models
{
    public class Placowka
    {
        public int idPlacowki { get; set; }
        public string kraj { get; set; }
        public string region { get; set; }
        public DateTime dataZalozenia { get; set; }
        public List<DaneTransportowe> daneTransportowe { get; set; }
        public List<Osoba> pracownicy { get; set; }

        public virtual string zwrocInformacje()
        {
            return $"Kraj {this.kraj}, region {this.region}, data zalozenia: {this.dataZalozenia.ToString()}";
        }
        float obliczWartośćZamowien(DateTime odData, DateTime doData)
        {
            var dane = daneTransportowe
                .Where(x => x.dataWyruszenia >= odData && x.dataWyruszenia <= doData)
                .Select(x => x.zelecenieTransportu).ToList();
            return dane.Sum(x => x.wartoscTransportu);
        }
    }
}
