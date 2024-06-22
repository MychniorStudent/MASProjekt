using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TransportAppAPI.Enums;

namespace TransportAppAPI.Models
{
    //Dziedziczenie wieloaspektowe, "dziedziczy" po rodzaju napędu oraz terenie transportera
    public class SrodekTransportu
    {
        public int idSrodkaTransportu { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public string numerRejestracyjny { get; set; }
        public bool czyMozeNiebezpieczne { get; set; }
        public DateTime dataOstatniegoPrzeglady { get; set; }

        //Dziedziczenie dynamiczne
        public RodzajNapedu rodzajNapedu { get; set; }
        public string TerenList { get; set; }
        //Dziedziczenie overlapping
        public List<TerenTransportera> TerenTransportera
        {
            get => TerenList?.Split(',').Select(Enum.Parse<TerenTransportera>).ToList();
            set => TerenList = value != null ? string.Join(",", value) : null;
        }


        private int _myPrivateField;

        // Public property exposing the private field
        [NotMapped]
        public int MyProperty
        {
            get => _myPrivateField;
            set => _myPrivateField = value;
        }

        //Atrybut klasowy
        private static float _cenaPaliwa { get; set; } = 50;
        //getCenaPaliwa metoda
        [NotMapped]
        public static float cenaPaliwa { get => _cenaPaliwa; set => _cenaPaliwa = value; }


        private int _przeplynietaOdlegloscMile;

        [NotMapped]
        public int PrzeplynietaOdlegloscMile { 
            get {
                if (TerenTransportera.Contains(Enums.TerenTransportera.Wodny))
                    return _przeplynietaOdlegloscMile;
                throw new Exception("Blad dziedziczenia");
            } 
            set {
                if(TerenTransportera.Contains(Enums.TerenTransportera.Wodny))
                    _przeplynietaOdlegloscMile = value;
                else
                    throw new Exception("Blad dziedziczenia");
            } 
        }


        private int _przejechanaOdlegloscKm;
        [NotMapped]
        public int PrzejechanaOdlegloscKm
        {
            get
            {
                if (TerenTransportera.Contains(Enums.TerenTransportera.Ladowy))
                    return _przejechanaOdlegloscKm;
                throw new Exception("Blad dziedziczenia");
            }
            set
            {
                if (TerenTransportera.Contains(Enums.TerenTransportera.Ladowy))
                    _przejechanaOdlegloscKm = value;
                else
                    throw new Exception("Blad dziedziczenia");
            }
        }

        private int _pojemnoscBaku;
        [NotMapped]
        public int pojemnoscBaku
        {
            get
            {
                if (RodzajNapedu.Spalinowy == rodzajNapedu)
                    return _pojemnoscBaku;
                throw new Exception("Blad dziedziczenia");
            }
            set
            {
                if (RodzajNapedu.Spalinowy == rodzajNapedu)
                    _pojemnoscBaku = value;
                else
                    throw new Exception("Blad dziedziczenia");
            }
        }

        private int _iloscPaliwa { get; set; }
        [NotMapped]
        public int iloscPaliwa
        {
            get
            {
                if (RodzajNapedu.Spalinowy == rodzajNapedu)
                    return _iloscPaliwa;
                throw new Exception("Blad dziedziczenia");
            }
            set
            {
                if (RodzajNapedu.Spalinowy == rodzajNapedu)
                    _iloscPaliwa = value;
                else
                    throw new Exception("Blad dziedziczenia");
            }
        }


        private int _moc { get; set; }
        [NotMapped]
        public int moc
        {
            get
            {
                if (RodzajNapedu.Elektryczny == rodzajNapedu)
                    return _moc;
                throw new Exception("Blad dziedziczenia");
            }
            set
            {
                if (RodzajNapedu.Elektryczny == rodzajNapedu)
                    _moc = value;
                else
                    throw new Exception("Blad dziedziczenia");
            }
        }

        private float _sprawnoscAkumulatora { get; set; }
        [NotMapped]
        public float sprawnoscAkumulatora
        {
            get
            {
                if (RodzajNapedu.Elektryczny == rodzajNapedu)
                    return _sprawnoscAkumulatora;
                throw new Exception("Blad dziedziczenia");
            }
            set
            {
                if (RodzajNapedu.Elektryczny == rodzajNapedu)
                    _sprawnoscAkumulatora = value;
                else
                    throw new Exception("Blad dziedziczenia");
            }
        }

        private int _poczatkowaPojemnoscAkumulatora { get; set; }
        [NotMapped]
        public int poczatkowaPojemnoscAkumulatora
        {
            get
            {
                if (RodzajNapedu.Elektryczny == rodzajNapedu)
                    return _poczatkowaPojemnoscAkumulatora;
                throw new Exception("Blad dziedziczenia");
            }
            set
            {
                if (RodzajNapedu.Elektryczny == rodzajNapedu)
                    _poczatkowaPojemnoscAkumulatora = value;
                else
                    throw new Exception("Blad dziedziczenia");
            }
        }
        public List<ZlecenieTransportu> zlecenia { get; set; }


        //Metoda klasowa
        public static float obliczEmisjeCO2()
        {
            return 500;
        }
        //Przeciążenie
        public static float obliczEmisjeCO2(int ileOszukac)
        {
            return 500*(100/ileOszukac);
        }
        void addPrzejechanaOdl(int km)
        {
            PrzejechanaOdlegloscKm += km;
        }
        void addPrzeplynietaOdl(int mile)
        {
            PrzeplynietaOdlegloscMile += mile;
        }
        void setTransportowiec(RodzajNapedu rodzajNapedu)
        {
            this.rodzajNapedu = rodzajNapedu;
        }
        bool checkTerenTypTransportowca(TerenTransportera terenTyp)
        {
            if(TerenTransportera.Contains(terenTyp))
                return true;
            return false;
        }

    }
}
