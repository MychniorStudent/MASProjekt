using Microsoft.EntityFrameworkCore;
using TransportAppAPI.Enums;
using TransportAppAPI.Models;

namespace TransportAppAPI.Contexts
{
    public class TransportDbContext : DbContext
    {
        public TransportDbContext() { }
        public TransportDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=local;Integrated Security=True;TrustServerCertificate=True;");//("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24438;Integrated Security=True;TrustServerCertificate=True;"); 
        }

        //Ekstensja i Ekstensja trwałość
        public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<SrodekTransportu> SrodkiTransportu { get; set; }
        public virtual DbSet<Osoba> Osoby { get; set; }
        public virtual DbSet<PracownikLadowy> PracownicyLadowi { get; set; }
        public virtual DbSet<PracownikMorski> PracownicyMorscy { get; set; }
        public virtual DbSet<SuperPracownik> SuperPracownicy { get; set; }
        public virtual DbSet<Placowka> Placowki { get; set; }
        public virtual DbSet<PlacowkaLadowa> PlacowkiLadowe { get; set; }
        public virtual DbSet<PlacowkaMorska> PlacowkiMorskie { get; set; }

        public virtual DbSet<DaneTransportowe> DaneTransportowe { get; set; }
        public virtual DbSet<ZlecenieTransportu> ZleceniaTransportu { get; set; }
        public virtual DbSet<Towar> Towary { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("transport");


            modelBuilder.Entity<MyEntity>(entity =>
            {
                // Mapowanie prywatnego pola na kolumnę w tabeli
                entity.Property<int>("_myPrivateField")
                    .HasColumnName("MyPrivateFieldColumn")
                    .IsRequired();
            });

            modelBuilder.Entity<SrodekTransportu>(entity =>
            {
                entity.HasKey(x => x.idSrodkaTransportu);
                entity.Ignore(x => x.TerenTransportera);

                entity.Property<int>("_myPrivateField")
                    .HasColumnName("MyPrivateFieldColumn")
                    .IsRequired();

                entity.Property<int>("_przeplynietaOdlegloscMile")
                .HasColumnName("PrzeplynietaOdlegloscMileColumn");


                entity.Property<int>("_przejechanaOdlegloscKm")
                .HasColumnName("PrzejechanaOdlegloscKmColumn");


                entity.Property<int>("_pojemnoscBaku")
                .HasColumnName("pojemnoscBakuColumn");



                entity.Property<int>("_iloscPaliwa")
                .HasColumnName("iloscPaliwaColumn");


                entity.Property<int>("_moc")
                .HasColumnName("mocColumn");


                entity.Property<float>("_sprawnoscAkumulatora")
                .HasColumnName("sprawnoscAkumulatoraColumn");


                entity.Property<int>("_poczatkowaPojemnoscAkumulatora")
                .HasColumnName("poczatkowaPojemnoscAkumulatoraColumn");

                entity.HasData(new SrodekTransportu
                {
                    idSrodkaTransportu = 1,
                    TerenTransportera = new List<TerenTransportera> { TerenTransportera.Ladowy, TerenTransportera.Wodny },
                    numerRejestracyjny = "WL1234",
                    marka = "Wolkzwagen",
                    model = "pu",
                    dataOstatniegoPrzeglady = DateTime.Now,
                    czyMozeNiebezpieczne = false,
                    rodzajNapedu = RodzajNapedu.Spalinowy,
                    iloscPaliwa = 50
                });

            });

            //placowka
            modelBuilder.Entity<Placowka>(entity =>
            {
                entity.HasKey(x => x.idPlacowki);
                entity.HasDiscriminator<string>("PlacowkaDiscriminator")
                .HasValue<PlacowkaLadowa>("PlacowkaLadowa")
                .HasValue<PlacowkaMorska>("PlacowkaMorska");

                //entity.HasData(
                //    new PlacowkaLadowa {idPlacowki = 1, dataZalozenia = DateTime.Now, kraj = "Polska", region = "Mazwosze", aglomeracja="Warszawska", nazwaDrogiEkspresowej = "S8" },
                //    new PlacowkaMorska { idPlacowki = 2, dataZalozenia = DateTime.Now, kraj = "Polska", region = "Pomorskie",liczbaDokow=3,czyObslugujeLodziePodwodne = true }
                //    );

            //    //pracownik
            //    entity.HasMany(x=>x.pracownicy)
            //    .WithOne(x=>x.placowka)
            //    .HasForeignKey(x=>x.idPlacowki)
            //    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<PlacowkaLadowa>(entity =>
            {
                entity.HasData(
                   new PlacowkaLadowa { idPlacowki = 1, dataZalozenia = DateTime.Now, kraj = "Polska", region = "Mazwosze", aglomeracja = "Warszawska", nazwaDrogiEkspresowej = "S8" }
                   );
            });
            modelBuilder.Entity<PlacowkaMorska>(entity =>
            {
                entity.HasData(
                 new PlacowkaMorska { idPlacowki = 2, dataZalozenia = DateTime.Now, kraj = "Polska", region = "Pomorskie", liczbaDokow = 3, czyObslugujeLodziePodwodne = true, zbiornikWodny = "bajkal" }
                   );
            });



            modelBuilder.Entity<PracownikLadowy>(entity =>
            {
                entity.HasData(
                    new PracownikLadowy { idPracownika = 1, idPlacowki = 1, imie = "", nazwisko = "", adresZamieszkania = "", dataUrodzenia = DateTime.Now, kategoriaPJ = new List<Enums.KategoriaPJ> { Enums.KategoriaPJ.A, Enums.KategoriaPJ.C } }
                  );
            });
            modelBuilder.Entity<PracownikMorski>(entity =>
            {
                entity.HasData(
                    new PracownikMorski { idPracownika = 2, idPlacowki = 2, imie = "", nazwisko = "", adresZamieszkania = "", dataUrodzenia = DateTime.Now, stopienMarynarski = Enums.StopienMarynarski.Majtek }
                );
            });

            //pracownik
            modelBuilder.Entity<Osoba>(entity => {
                entity.HasKey(x => x.idPracownika);
                entity.HasDiscriminator<string>("OsobaDiscriminator")
                .HasValue<PracownikLadowy>("PracownikLadowy")
                .HasValue<PracownikMorski>("PracownikMorski");

                //placowka 
                entity.HasOne(x => x.placowka)
                .WithMany(x => x.pracownicy)
                .HasForeignKey(x => x.idPlacowki).OnDelete(DeleteBehavior.Restrict);

                //entity.HasData(
                //    new PracownikLadowy {idPracownika = 1, idPlacowki = 1, imie = "", nazwisko = "", adresZamieszkania = "", dataUrodzenia = DateTime.Now, kategoriaPJ = new List<Enums.KategoriaPJ> { Enums.KategoriaPJ.A, Enums.KategoriaPJ.C } },
                //    new PracownikMorski {idPracownika = 2, idPlacowki = 2, imie = "", nazwisko="",adresZamieszkania="",dataUrodzenia = DateTime.Now, stopienMarynarski = Enums.StopienMarynarski.Majtek}
                //);
                //.IsRequired();

                //entity.HasMany(x=>x.zlecenia)
                //.WithOne(x=>x.przewoznik)
                //.HasForeignKey(x=>x.idPrzewoznika)
                //.OnDelete(DeleteBehavior.NoAction);
            });

            //zlecenie transportu
            modelBuilder.Entity<ZlecenieTransportu>(entity => {
                entity.HasKey(x => x.id);

                //dane transportowe
                entity.HasOne(x => x.daneTransportowe)
                .WithOne(x => x.zelecenieTransportu)
                .HasForeignKey<DaneTransportowe>(x => x.idZlecenieTransportu).OnDelete(DeleteBehavior.Cascade);

                //srodek transportu
                entity
                .HasOne(x => x.srodekTransportu)
                .WithMany(x => x.zlecenia)
                .HasForeignKey(x => x.idSrodekTransportu);

                //relacja do towarow definiowana w towarach



                //osoba
                entity.HasOne(x => x.przewoznik)
                .WithMany(x => x.zlecenia)
                .HasForeignKey(x => x.idPrzewoznika).OnDelete(DeleteBehavior.Restrict);

                entity.HasData(
                    new ZlecenieTransportu { id = 1, adres = "Warszawa", status = "zrealizowane", idPrzewoznika = 1, idSrodekTransportu = 1},
                    new ZlecenieTransportu { id = 2, adres = "Krakow", status = "zrealizowane", idPrzewoznika = 1, idSrodekTransportu = 1 },
                    new ZlecenieTransportu { id = 3, adres = "Poznan", status = "zrealizowane", idPrzewoznika = 1, idSrodekTransportu = 1 }
                    );

            });

            //dane transportowe
            modelBuilder.Entity<DaneTransportowe>(entity => {
                entity.HasKey(x => x.id);

                //zlecenie transportu
                //entity.HasOne(x => x.zelecenieTransportu)
                //.WithOne(x => x.daneTransportowe)
                //.HasForeignKey<ZlecenieTransportu>(x => x.idDaneTransportowe);

                //placowka
                entity.HasOne(x => x.placowka)
                .WithMany(x => x.daneTransportowe)
                .HasForeignKey(x => x.idPlacowki).OnDelete(DeleteBehavior.Restrict);

                entity.HasData(
                    new DaneTransportowe { id = 1, dataWyruszenia = DateTime.Now, planowanaDataDostarczenia = DateTime.Now.AddDays(5), idZlecenieTransportu = 1, idPlacowki = 1 },
                    new DaneTransportowe { id = 2, dataWyruszenia = DateTime.Now, planowanaDataDostarczenia = DateTime.Now.AddDays(11), idZlecenieTransportu = 2, idPlacowki = 1 },
                    new DaneTransportowe { id = 3, dataWyruszenia = DateTime.Now, planowanaDataDostarczenia = DateTime.Now.AddDays(15), idZlecenieTransportu = 3, idPlacowki = 1 }
                    );
              
            });

           

            //towary
            modelBuilder.Entity<Towar>(entity => {
                entity.HasKey(x => x.id);


                //zlecenie
                entity.HasOne(x => x.transport)
                .WithMany(x => x.towary)
                .HasForeignKey(x => x.idTransportu).OnDelete(DeleteBehavior.NoAction);

                entity.HasData(
                    new Towar {id = 1,czyNiebezpieczne=true,ilosc=50,kategoria = "Alkohol", nazwa = "Piwo", idTransportu = 1},
                    new Towar {id = 2,czyNiebezpieczne=false,ilosc=30,kategoria = "Alkohol", nazwa = "Piwo", idTransportu = 1 },
                    new Towar {id = 3,czyNiebezpieczne=true,ilosc=20,kategoria = "Alkohol", nazwa = "Bimber", idTransportu =2},
                    new Towar {id = 4,czyNiebezpieczne=false,ilosc=10,kategoria = "Alkohol", nazwa = "Whiksy", idTransportu =1},
                    new Towar {id = 5,czyNiebezpieczne=true,ilosc=500,kategoria = "Alkohol", nazwa = "Wino", idTransportu = 2},
                    new Towar {id = 6,czyNiebezpieczne=false,ilosc=15,kategoria = "Alkohol", nazwa = "Wudka", idTransportu =1},
                    new Towar {id = 7,czyNiebezpieczne=false,ilosc=15,kategoria = "Alkohol", nazwa = "Wudka2"},
                    new Towar {id = 8,czyNiebezpieczne=false,ilosc=15,kategoria = "Alkohol", nazwa = "Wudka3"}
                    
                    );
            });

            modelBuilder.Entity<SuperPracownik>(entity =>
            {
                entity.HasKey(x => x.id);

                entity.HasOne(x => x.pracownikLadowy).WithOne(x => x.superPracownikLadowy).HasForeignKey<PracownikLadowy>(x => x.idSuperPracownikaLadowy).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(x => x.pracownikMorski).WithOne(x => x.superPracownikMorski).HasForeignKey<PracownikMorski>(x => x.idSuperPracownikaMorski).OnDelete(DeleteBehavior.NoAction);
            
                entity.HasData(new SuperPracownik { id = 1, idPracownikLadowy = 1, idPracownikMorski = 2 });
            
            });

        }
    }
}
