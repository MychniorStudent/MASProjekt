namespace TransportAppAPI.Models
{
    public class PlacowkaMorska : Placowka
    {
        public string zbiornikWodny { get; set; }
        public int liczbaDokow { get; set; }
        public bool czyObslugujeLodziePodwodne { get; set; }
        public override string zwrocInformacje()
        {
            return $"Kraj {this.kraj}, region {this.region}, data zalozenia: {this.dataZalozenia.ToString()}, zbiornikWodny: {this.zbiornikWodny}, liczba dokow {this.liczbaDokow}, czy obsluguje lodzie podwodne {this.czyObslugujeLodziePodwodne}";
        }
    }
}
