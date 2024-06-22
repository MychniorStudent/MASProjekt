namespace TransportAppAPI.Models
{
    public class PlacowkaLadowa : Placowka
    {
        public string aglomeracja { get; set; }
        public string nazwaDrogiEkspresowej { get; set; }
        public override string zwrocInformacje()
        {
            return $"Kraj {this.kraj}, region {this.region}, data zalozenia: {this.dataZalozenia.ToString()}, algomeracja: {this.aglomeracja}, nazwa najblizszej drogi ekspresowej {this.nazwaDrogiEkspresowej}";
        }
    }
}
