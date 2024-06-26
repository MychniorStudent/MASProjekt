﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportAppAPI.Contexts;

#nullable disable

namespace TransportAppAPI.Migrations
{
    [DbContext(typeof(TransportDbContext))]
    [Migration("20240622133312_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("transport")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TransportAppAPI.Models.DaneTransportowe", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("dataDostarczenia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataWyruszenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPlacowki")
                        .HasColumnType("int");

                    b.Property<int>("idZlecenieTransportu")
                        .HasColumnType("int");

                    b.Property<DateTime>("planowanaDataDostarczenia")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("idPlacowki");

                    b.HasIndex("idZlecenieTransportu")
                        .IsUnique();

                    b.ToTable("DaneTransportowe", "transport");

                    b.HasData(
                        new
                        {
                            id = 1,
                            dataDostarczenia = new DateTime(2024, 6, 27, 15, 33, 11, 891, DateTimeKind.Local).AddTicks(5791),
                            dataWyruszenia = new DateTime(2024, 6, 22, 15, 33, 11, 891, DateTimeKind.Local).AddTicks(5772),
                            idPlacowki = 1,
                            idZlecenieTransportu = 1,
                            planowanaDataDostarczenia = new DateTime(2024, 6, 27, 15, 33, 11, 891, DateTimeKind.Local).AddTicks(5788)
                        },
                        new
                        {
                            id = 2,
                            dataDostarczenia = new DateTime(2024, 7, 3, 15, 33, 11, 891, DateTimeKind.Local).AddTicks(5800),
                            dataWyruszenia = new DateTime(2024, 6, 22, 15, 33, 11, 891, DateTimeKind.Local).AddTicks(5798),
                            idPlacowki = 1,
                            idZlecenieTransportu = 2,
                            planowanaDataDostarczenia = new DateTime(2024, 7, 3, 15, 33, 11, 891, DateTimeKind.Local).AddTicks(5799)
                        },
                        new
                        {
                            id = 3,
                            dataDostarczenia = new DateTime(2024, 7, 8, 15, 33, 11, 891, DateTimeKind.Local).AddTicks(5804),
                            dataWyruszenia = new DateTime(2024, 6, 22, 15, 33, 11, 891, DateTimeKind.Local).AddTicks(5802),
                            idPlacowki = 1,
                            idZlecenieTransportu = 3,
                            planowanaDataDostarczenia = new DateTime(2024, 7, 7, 15, 33, 11, 891, DateTimeKind.Local).AddTicks(5803)
                        });
                });

            modelBuilder.Entity("TransportAppAPI.Models.Osoba", b =>
                {
                    b.Property<int>("idPracownika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPracownika"));

                    b.Property<string>("OsobaDiscriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("adresZamieszkania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPlacowki")
                        .HasColumnType("int");

                    b.Property<string>("imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPracownika");

                    b.HasIndex("idPlacowki");

                    b.ToTable("Osoby", "transport");

                    b.HasDiscriminator<string>("OsobaDiscriminator").HasValue("Osoba");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TransportAppAPI.Models.Placowka", b =>
                {
                    b.Property<int>("idPlacowki")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPlacowki"));

                    b.Property<string>("PlacowkaDiscriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<DateTime>("dataZalozenia")
                        .HasColumnType("datetime2");

                    b.Property<string>("kraj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPlacowki");

                    b.ToTable("Placowki", "transport");

                    b.HasDiscriminator<string>("PlacowkaDiscriminator").HasValue("Placowka");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TransportAppAPI.Models.SrodekTransportu", b =>
                {
                    b.Property<int>("idSrodkaTransportu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idSrodkaTransportu"));

                    b.Property<string>("TerenList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_iloscPaliwa")
                        .HasColumnType("int")
                        .HasColumnName("iloscPaliwaColumn");

                    b.Property<int>("_moc")
                        .HasColumnType("int")
                        .HasColumnName("mocColumn");

                    b.Property<int>("_myPrivateField")
                        .HasColumnType("int")
                        .HasColumnName("MyPrivateFieldColumn");

                    b.Property<int>("_poczatkowaPojemnoscAkumulatora")
                        .HasColumnType("int")
                        .HasColumnName("poczatkowaPojemnoscAkumulatoraColumn");

                    b.Property<int>("_pojemnoscBaku")
                        .HasColumnType("int")
                        .HasColumnName("pojemnoscBakuColumn");

                    b.Property<int>("_przejechanaOdlegloscKm")
                        .HasColumnType("int")
                        .HasColumnName("PrzejechanaOdlegloscKmColumn");

                    b.Property<int>("_przeplynietaOdlegloscMile")
                        .HasColumnType("int")
                        .HasColumnName("PrzeplynietaOdlegloscMileColumn");

                    b.Property<float>("_sprawnoscAkumulatora")
                        .HasColumnType("real")
                        .HasColumnName("sprawnoscAkumulatoraColumn");

                    b.Property<bool>("czyMozeNiebezpieczne")
                        .HasColumnType("bit");

                    b.Property<DateTime>("dataOstatniegoPrzeglady")
                        .HasColumnType("datetime2");

                    b.Property<string>("marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numerRejestracyjny")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rodzajNapedu")
                        .HasColumnType("int");

                    b.HasKey("idSrodkaTransportu");

                    b.ToTable("SrodkiTransportu", "transport");

                    b.HasData(
                        new
                        {
                            idSrodkaTransportu = 1,
                            TerenList = "Ladowy,Wodny",
                            _iloscPaliwa = 50,
                            _moc = 0,
                            _myPrivateField = 0,
                            _poczatkowaPojemnoscAkumulatora = 0,
                            _pojemnoscBaku = 0,
                            _przejechanaOdlegloscKm = 0,
                            _przeplynietaOdlegloscMile = 0,
                            _sprawnoscAkumulatora = 0f,
                            czyMozeNiebezpieczne = false,
                            dataOstatniegoPrzeglady = new DateTime(2024, 6, 22, 15, 33, 11, 889, DateTimeKind.Local).AddTicks(7063),
                            marka = "Wolkzwagen",
                            model = "polo",
                            numerRejestracyjny = "WL1234",
                            rodzajNapedu = 0
                        });
                });

            modelBuilder.Entity("TransportAppAPI.Models.SuperPracownik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("idPracownikLadowy")
                        .HasColumnType("int");

                    b.Property<int>("idPracownikMorski")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("SuperPracownicy", "transport");

                    b.HasData(
                        new
                        {
                            id = 1,
                            idPracownikLadowy = 1,
                            idPracownikMorski = 2
                        });
                });

            modelBuilder.Entity("TransportAppAPI.Models.Towar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("czyNiebezpieczne")
                        .HasColumnType("bit");

                    b.Property<int?>("idTransportu")
                        .HasColumnType("int");

                    b.Property<int>("ilosc")
                        .HasColumnType("int");

                    b.Property<string>("kategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("idTransportu");

                    b.ToTable("Towary", "transport");

                    b.HasData(
                        new
                        {
                            id = 1,
                            czyNiebezpieczne = true,
                            idTransportu = 1,
                            ilosc = 50,
                            kategoria = "Alkohol",
                            nazwa = "Piwo"
                        },
                        new
                        {
                            id = 2,
                            czyNiebezpieczne = false,
                            idTransportu = 1,
                            ilosc = 30,
                            kategoria = "Alkohol",
                            nazwa = "Piwo"
                        },
                        new
                        {
                            id = 3,
                            czyNiebezpieczne = true,
                            idTransportu = 2,
                            ilosc = 20,
                            kategoria = "Alkohol",
                            nazwa = "Bimber"
                        },
                        new
                        {
                            id = 4,
                            czyNiebezpieczne = false,
                            idTransportu = 1,
                            ilosc = 10,
                            kategoria = "Alkohol",
                            nazwa = "Whiksy"
                        },
                        new
                        {
                            id = 5,
                            czyNiebezpieczne = true,
                            idTransportu = 2,
                            ilosc = 500,
                            kategoria = "Alkohol",
                            nazwa = "Wino"
                        },
                        new
                        {
                            id = 6,
                            czyNiebezpieczne = false,
                            idTransportu = 1,
                            ilosc = 15,
                            kategoria = "Alkohol",
                            nazwa = "Wudka"
                        },
                        new
                        {
                            id = 7,
                            czyNiebezpieczne = false,
                            ilosc = 15,
                            kategoria = "Alkohol",
                            nazwa = "Wudka2"
                        },
                        new
                        {
                            id = 8,
                            czyNiebezpieczne = false,
                            ilosc = 15,
                            kategoria = "Alkohol",
                            nazwa = "Wudka3"
                        });
                });

            modelBuilder.Entity("TransportAppAPI.Models.ZlecenieTransportu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idPrzewoznika")
                        .HasColumnType("int");

                    b.Property<int>("idSrodekTransportu")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("idPrzewoznika");

                    b.HasIndex("idSrodekTransportu");

                    b.ToTable("ZleceniaTransportu", "transport");

                    b.HasData(
                        new
                        {
                            id = 1,
                            adres = "Warszawa",
                            idPrzewoznika = 1,
                            idSrodekTransportu = 1,
                            status = "zrealizowane"
                        },
                        new
                        {
                            id = 2,
                            adres = "Krakow",
                            idPrzewoznika = 1,
                            idSrodekTransportu = 1,
                            status = "zrealizowane"
                        },
                        new
                        {
                            id = 3,
                            adres = "Poznan",
                            idPrzewoznika = 1,
                            idSrodekTransportu = 1,
                            status = "zrealizowane"
                        });
                });

            modelBuilder.Entity("TransportAppAPI.Models.PracownikLadowy", b =>
                {
                    b.HasBaseType("TransportAppAPI.Models.Osoba");

                    b.Property<int?>("idSuperPracownikaLadowy")
                        .HasColumnType("int");

                    b.Property<string>("kategoriePJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("idSuperPracownikaLadowy")
                        .IsUnique()
                        .HasFilter("[idSuperPracownikaLadowy] IS NOT NULL");

                    b.HasDiscriminator().HasValue("PracownikLadowy");

                    b.HasData(
                        new
                        {
                            idPracownika = 1,
                            adresZamieszkania = "",
                            dataUrodzenia = new DateTime(2024, 6, 22, 15, 33, 11, 890, DateTimeKind.Local).AddTicks(3266),
                            idPlacowki = 1,
                            imie = "Michal",
                            nazwisko = "Góra",
                            kategoriePJ = "A,C"
                        });
                });

            modelBuilder.Entity("TransportAppAPI.Models.PracownikMorski", b =>
                {
                    b.HasBaseType("TransportAppAPI.Models.Osoba");

                    b.Property<int?>("idSuperPracownikaMorski")
                        .HasColumnType("int");

                    b.HasIndex("idSuperPracownikaMorski")
                        .IsUnique()
                        .HasFilter("[idSuperPracownikaMorski] IS NOT NULL");

                    b.HasDiscriminator().HasValue("PracownikMorski");

                    b.HasData(
                        new
                        {
                            idPracownika = 2,
                            adresZamieszkania = "",
                            dataUrodzenia = new DateTime(2024, 6, 22, 15, 33, 11, 890, DateTimeKind.Local).AddTicks(3503),
                            idPlacowki = 2,
                            imie = "Bartek",
                            nazwisko = "Ann"
                        });
                });

            modelBuilder.Entity("TransportAppAPI.Models.PlacowkaLadowa", b =>
                {
                    b.HasBaseType("TransportAppAPI.Models.Placowka");

                    b.Property<string>("aglomeracja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazwaDrogiEkspresowej")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PlacowkaLadowa");

                    b.HasData(
                        new
                        {
                            idPlacowki = 1,
                            dataZalozenia = new DateTime(2024, 6, 22, 15, 33, 11, 890, DateTimeKind.Local).AddTicks(3210),
                            kraj = "Polska",
                            region = "Mazwosze",
                            aglomeracja = "Warszawska",
                            nazwaDrogiEkspresowej = "S8"
                        });
                });

            modelBuilder.Entity("TransportAppAPI.Models.PlacowkaMorska", b =>
                {
                    b.HasBaseType("TransportAppAPI.Models.Placowka");

                    b.Property<bool>("czyObslugujeLodziePodwodne")
                        .HasColumnType("bit");

                    b.Property<int>("liczbaDokow")
                        .HasColumnType("int");

                    b.Property<string>("zbiornikWodny")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PlacowkaMorska");

                    b.HasData(
                        new
                        {
                            idPlacowki = 2,
                            dataZalozenia = new DateTime(2024, 6, 22, 15, 33, 11, 890, DateTimeKind.Local).AddTicks(3248),
                            kraj = "Polska",
                            region = "Pomorskie",
                            czyObslugujeLodziePodwodne = true,
                            liczbaDokow = 3,
                            zbiornikWodny = "bajkal"
                        });
                });

            modelBuilder.Entity("TransportAppAPI.Models.DaneTransportowe", b =>
                {
                    b.HasOne("TransportAppAPI.Models.Placowka", "placowka")
                        .WithMany("daneTransportowe")
                        .HasForeignKey("idPlacowki")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TransportAppAPI.Models.ZlecenieTransportu", "zelecenieTransportu")
                        .WithOne("daneTransportowe")
                        .HasForeignKey("TransportAppAPI.Models.DaneTransportowe", "idZlecenieTransportu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("placowka");

                    b.Navigation("zelecenieTransportu");
                });

            modelBuilder.Entity("TransportAppAPI.Models.Osoba", b =>
                {
                    b.HasOne("TransportAppAPI.Models.Placowka", "placowka")
                        .WithMany("pracownicy")
                        .HasForeignKey("idPlacowki")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("placowka");
                });

            modelBuilder.Entity("TransportAppAPI.Models.Towar", b =>
                {
                    b.HasOne("TransportAppAPI.Models.ZlecenieTransportu", "transport")
                        .WithMany("towary")
                        .HasForeignKey("idTransportu")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("transport");
                });

            modelBuilder.Entity("TransportAppAPI.Models.ZlecenieTransportu", b =>
                {
                    b.HasOne("TransportAppAPI.Models.Osoba", "przewoznik")
                        .WithMany("zlecenia")
                        .HasForeignKey("idPrzewoznika")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TransportAppAPI.Models.SrodekTransportu", "srodekTransportu")
                        .WithMany("zlecenia")
                        .HasForeignKey("idSrodekTransportu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("przewoznik");

                    b.Navigation("srodekTransportu");
                });

            modelBuilder.Entity("TransportAppAPI.Models.PracownikLadowy", b =>
                {
                    b.HasOne("TransportAppAPI.Models.SuperPracownik", "superPracownikLadowy")
                        .WithOne("pracownikLadowy")
                        .HasForeignKey("TransportAppAPI.Models.PracownikLadowy", "idSuperPracownikaLadowy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("superPracownikLadowy");
                });

            modelBuilder.Entity("TransportAppAPI.Models.PracownikMorski", b =>
                {
                    b.HasOne("TransportAppAPI.Models.SuperPracownik", "superPracownikMorski")
                        .WithOne("pracownikMorski")
                        .HasForeignKey("TransportAppAPI.Models.PracownikMorski", "idSuperPracownikaMorski")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("superPracownikMorski");
                });

            modelBuilder.Entity("TransportAppAPI.Models.Osoba", b =>
                {
                    b.Navigation("zlecenia");
                });

            modelBuilder.Entity("TransportAppAPI.Models.Placowka", b =>
                {
                    b.Navigation("daneTransportowe");

                    b.Navigation("pracownicy");
                });

            modelBuilder.Entity("TransportAppAPI.Models.SrodekTransportu", b =>
                {
                    b.Navigation("zlecenia");
                });

            modelBuilder.Entity("TransportAppAPI.Models.SuperPracownik", b =>
                {
                    b.Navigation("pracownikLadowy")
                        .IsRequired();

                    b.Navigation("pracownikMorski")
                        .IsRequired();
                });

            modelBuilder.Entity("TransportAppAPI.Models.ZlecenieTransportu", b =>
                {
                    b.Navigation("daneTransportowe")
                        .IsRequired();

                    b.Navigation("towary");
                });
#pragma warning restore 612, 618
        }
    }
}
