using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransportAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class Sziton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "transport");

            migrationBuilder.CreateTable(
                name: "MyEntities",
                schema: "transport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    MyPrivateFieldColumn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Placowki",
                schema: "transport",
                columns: table => new
                {
                    idPlacowki = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kraj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataZalozenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlacowkaDiscriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    aglomeracja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nazwaDrogiEkspresowej = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zbiornikWodny = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    liczbaDokow = table.Column<int>(type: "int", nullable: true),
                    czyObslugujeLodziePodwodne = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placowki", x => x.idPlacowki);
                });

            migrationBuilder.CreateTable(
                name: "SrodkiTransportu",
                schema: "transport",
                columns: table => new
                {
                    idSrodkaTransportu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numerRejestracyjny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    czyMozeNiebezpieczne = table.Column<bool>(type: "bit", nullable: false),
                    dataOstatniegoPrzeglady = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rodzajNapedu = table.Column<int>(type: "int", nullable: false),
                    TerenList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iloscPaliwaColumn = table.Column<int>(type: "int", nullable: false),
                    mocColumn = table.Column<int>(type: "int", nullable: false),
                    sprawnoscAkumulatoraColumn = table.Column<float>(type: "real", nullable: false),
                    poczatkowaPojemnoscAkumulatoraColumn = table.Column<int>(type: "int", nullable: false),
                    MyPrivateFieldColumn = table.Column<int>(type: "int", nullable: false),
                    pojemnoscBakuColumn = table.Column<int>(type: "int", nullable: false),
                    PrzejechanaOdlegloscKmColumn = table.Column<int>(type: "int", nullable: false),
                    PrzeplynietaOdlegloscMileColumn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SrodkiTransportu", x => x.idSrodkaTransportu);
                });

            migrationBuilder.CreateTable(
                name: "SuperPracownicy",
                schema: "transport",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPracownikLadowy = table.Column<int>(type: "int", nullable: false),
                    idPracownikMorski = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPracownicy", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Osoby",
                schema: "transport",
                columns: table => new
                {
                    idPracownika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    adresZamieszkania = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idPlacowki = table.Column<int>(type: "int", nullable: false),
                    OsobaDiscriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    kategoriePJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idSuperPracownikaLadowy = table.Column<int>(type: "int", nullable: true),
                    idSuperPracownikaMorski = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoby", x => x.idPracownika);
                    table.ForeignKey(
                        name: "FK_Osoby_Placowki_idPlacowki",
                        column: x => x.idPlacowki,
                        principalSchema: "transport",
                        principalTable: "Placowki",
                        principalColumn: "idPlacowki",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Osoby_SuperPracownicy_idSuperPracownikaLadowy",
                        column: x => x.idSuperPracownikaLadowy,
                        principalSchema: "transport",
                        principalTable: "SuperPracownicy",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Osoby_SuperPracownicy_idSuperPracownikaMorski",
                        column: x => x.idSuperPracownikaMorski,
                        principalSchema: "transport",
                        principalTable: "SuperPracownicy",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ZleceniaTransportu",
                schema: "transport",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idPrzewoznika = table.Column<int>(type: "int", nullable: false),
                    idSrodekTransportu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZleceniaTransportu", x => x.id);
                    table.ForeignKey(
                        name: "FK_ZleceniaTransportu_Osoby_idPrzewoznika",
                        column: x => x.idPrzewoznika,
                        principalSchema: "transport",
                        principalTable: "Osoby",
                        principalColumn: "idPracownika",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ZleceniaTransportu_SrodkiTransportu_idSrodekTransportu",
                        column: x => x.idSrodekTransportu,
                        principalSchema: "transport",
                        principalTable: "SrodkiTransportu",
                        principalColumn: "idSrodkaTransportu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaneTransportowe",
                schema: "transport",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataWyruszenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    planowanaDataDostarczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataDostarczenia = table.Column<DateTime>(type: "datetime2", nullable: true),
                    idZlecenieTransportu = table.Column<int>(type: "int", nullable: false),
                    idPlacowki = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaneTransportowe", x => x.id);
                    table.ForeignKey(
                        name: "FK_DaneTransportowe_Placowki_idPlacowki",
                        column: x => x.idPlacowki,
                        principalSchema: "transport",
                        principalTable: "Placowki",
                        principalColumn: "idPlacowki",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DaneTransportowe_ZleceniaTransportu_idZlecenieTransportu",
                        column: x => x.idZlecenieTransportu,
                        principalSchema: "transport",
                        principalTable: "ZleceniaTransportu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Towary",
                schema: "transport",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ilosc = table.Column<int>(type: "int", nullable: false),
                    czyNiebezpieczne = table.Column<bool>(type: "bit", nullable: false),
                    kategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idTransportu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towary", x => x.id);
                    table.ForeignKey(
                        name: "FK_Towary_ZleceniaTransportu_idTransportu",
                        column: x => x.idTransportu,
                        principalSchema: "transport",
                        principalTable: "ZleceniaTransportu",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                schema: "transport",
                table: "Placowki",
                columns: new[] { "idPlacowki", "PlacowkaDiscriminator", "aglomeracja", "dataZalozenia", "kraj", "nazwaDrogiEkspresowej", "region" },
                values: new object[] { 1, "PlacowkaLadowa", "Warszawska", new DateTime(2024, 6, 20, 19, 17, 7, 244, DateTimeKind.Local).AddTicks(3469), "Polska", "S8", "Mazwosze" });

            migrationBuilder.InsertData(
                schema: "transport",
                table: "Placowki",
                columns: new[] { "idPlacowki", "PlacowkaDiscriminator", "czyObslugujeLodziePodwodne", "dataZalozenia", "kraj", "liczbaDokow", "region", "zbiornikWodny" },
                values: new object[] { 2, "PlacowkaMorska", true, new DateTime(2024, 6, 20, 19, 17, 7, 244, DateTimeKind.Local).AddTicks(3519), "Polska", 3, "Pomorskie", "bajkal" });

            migrationBuilder.InsertData(
                schema: "transport",
                table: "SrodkiTransportu",
                columns: new[] { "idSrodkaTransportu", "TerenList", "iloscPaliwaColumn", "mocColumn", "MyPrivateFieldColumn", "poczatkowaPojemnoscAkumulatoraColumn", "pojemnoscBakuColumn", "PrzejechanaOdlegloscKmColumn", "PrzeplynietaOdlegloscMileColumn", "sprawnoscAkumulatoraColumn", "czyMozeNiebezpieczne", "dataOstatniegoPrzeglady", "marka", "model", "numerRejestracyjny", "rodzajNapedu" },
                values: new object[] { 1, "Ladowy,Wodny", 50, 0, 0, 0, 0, 0, 0, 0f, false, new DateTime(2024, 6, 20, 19, 17, 7, 243, DateTimeKind.Local).AddTicks(5564), "Wolkzwagen", "pu", "WL1234", 0 });

            migrationBuilder.InsertData(
                schema: "transport",
                table: "SuperPracownicy",
                columns: new[] { "id", "idPracownikLadowy", "idPracownikMorski" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                schema: "transport",
                table: "Towary",
                columns: new[] { "id", "czyNiebezpieczne", "idTransportu", "ilosc", "kategoria", "nazwa" },
                values: new object[,]
                {
                    { 7, false, null, 15, "Alkohol", "Wudka2" },
                    { 8, false, null, 15, "Alkohol", "Wudka3" }
                });

            migrationBuilder.InsertData(
                schema: "transport",
                table: "Osoby",
                columns: new[] { "idPracownika", "OsobaDiscriminator", "adresZamieszkania", "dataUrodzenia", "idPlacowki", "idSuperPracownikaLadowy", "imie", "kategoriePJ", "nazwisko" },
                values: new object[] { 1, "PracownikLadowy", "", new DateTime(2024, 6, 20, 19, 17, 7, 244, DateTimeKind.Local).AddTicks(3542), 1, null, "", "A,C", "" });

            migrationBuilder.InsertData(
                schema: "transport",
                table: "Osoby",
                columns: new[] { "idPracownika", "OsobaDiscriminator", "adresZamieszkania", "dataUrodzenia", "idPlacowki", "idSuperPracownikaMorski", "imie", "nazwisko" },
                values: new object[] { 2, "PracownikMorski", "", new DateTime(2024, 6, 20, 19, 17, 7, 244, DateTimeKind.Local).AddTicks(3901), 2, null, "", "" });

            migrationBuilder.InsertData(
                schema: "transport",
                table: "ZleceniaTransportu",
                columns: new[] { "id", "adres", "idPrzewoznika", "idSrodekTransportu", "status" },
                values: new object[,]
                {
                    { 1, "Warszawa", 1, 1, "zrealizowane" },
                    { 2, "Krakow", 1, 1, "zrealizowane" },
                    { 3, "Poznan", 1, 1, "zrealizowane" }
                });

            migrationBuilder.InsertData(
                schema: "transport",
                table: "DaneTransportowe",
                columns: new[] { "id", "dataDostarczenia", "dataWyruszenia", "idPlacowki", "idZlecenieTransportu", "planowanaDataDostarczenia" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 6, 20, 19, 17, 7, 245, DateTimeKind.Local).AddTicks(8771), 1, 1, new DateTime(2024, 6, 25, 19, 17, 7, 245, DateTimeKind.Local).AddTicks(8792) },
                    { 2, null, new DateTime(2024, 6, 20, 19, 17, 7, 245, DateTimeKind.Local).AddTicks(8796), 1, 2, new DateTime(2024, 7, 1, 19, 17, 7, 245, DateTimeKind.Local).AddTicks(8797) },
                    { 3, null, new DateTime(2024, 6, 20, 19, 17, 7, 245, DateTimeKind.Local).AddTicks(8799), 1, 3, new DateTime(2024, 7, 5, 19, 17, 7, 245, DateTimeKind.Local).AddTicks(8800) }
                });

            migrationBuilder.InsertData(
                schema: "transport",
                table: "Towary",
                columns: new[] { "id", "czyNiebezpieczne", "idTransportu", "ilosc", "kategoria", "nazwa" },
                values: new object[,]
                {
                    { 1, true, 1, 50, "Alkohol", "Piwo" },
                    { 2, false, 1, 30, "Alkohol", "Piwo" },
                    { 3, true, 2, 20, "Alkohol", "Bimber" },
                    { 4, false, 1, 10, "Alkohol", "Whiksy" },
                    { 5, true, 2, 500, "Alkohol", "Wino" },
                    { 6, false, 1, 15, "Alkohol", "Wudka" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaneTransportowe_idPlacowki",
                schema: "transport",
                table: "DaneTransportowe",
                column: "idPlacowki");

            migrationBuilder.CreateIndex(
                name: "IX_DaneTransportowe_idZlecenieTransportu",
                schema: "transport",
                table: "DaneTransportowe",
                column: "idZlecenieTransportu",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Osoby_idPlacowki",
                schema: "transport",
                table: "Osoby",
                column: "idPlacowki");

            migrationBuilder.CreateIndex(
                name: "IX_Osoby_idSuperPracownikaLadowy",
                schema: "transport",
                table: "Osoby",
                column: "idSuperPracownikaLadowy",
                unique: true,
                filter: "[idSuperPracownikaLadowy] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Osoby_idSuperPracownikaMorski",
                schema: "transport",
                table: "Osoby",
                column: "idSuperPracownikaMorski",
                unique: true,
                filter: "[idSuperPracownikaMorski] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Towary_idTransportu",
                schema: "transport",
                table: "Towary",
                column: "idTransportu");

            migrationBuilder.CreateIndex(
                name: "IX_ZleceniaTransportu_idPrzewoznika",
                schema: "transport",
                table: "ZleceniaTransportu",
                column: "idPrzewoznika");

            migrationBuilder.CreateIndex(
                name: "IX_ZleceniaTransportu_idSrodekTransportu",
                schema: "transport",
                table: "ZleceniaTransportu",
                column: "idSrodekTransportu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaneTransportowe",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "MyEntities",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "Towary",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "ZleceniaTransportu",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "Osoby",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "SrodkiTransportu",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "Placowki",
                schema: "transport");

            migrationBuilder.DropTable(
                name: "SuperPracownicy",
                schema: "transport");
        }
    }
}
