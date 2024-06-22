using System.ComponentModel.DataAnnotations.Schema;

namespace TransportAppAPI.Models
{
    public class ZlecenieTransportu
    {
        public int id { get; set; }

        //Atrybut pochodny
        [NotMapped]
        public float wartoscTransportu { 
            get
            {
                return towary.Count * 500;
            } 
        }
        public List<Towar> towary { get; set; }
        public string adres { get; set; }
        public string status { get; set; }
        public int idPrzewoznika { get; set; }
        public Osoba przewoznik { get; set; }
        //public int idDaneTransportowe { get; set; }
        public DaneTransportowe daneTransportowe { get; set; }
        public int idSrodekTransportu { get; set; }
        public SrodekTransportu srodekTransportu { get; set; }

        float obliczWartoscTransportu()
        {
            return towary.Count * 500;
        }
        int przygotujZamowienie(List<Towar> towaryZamowienia)
        {
            towary = towaryZamowienia;
            return towary.Count;
        }

    }
}
