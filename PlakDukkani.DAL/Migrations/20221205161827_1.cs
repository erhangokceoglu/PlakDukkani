using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlakDukkan.DAL.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albumler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AlbumSanatcisi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AlbumCikisTarihi = table.Column<DateTime>(type: "date", nullable: false),
                    AlbumFiyati = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: false),
                    IndirimOrani = table.Column<decimal>(type: "decimal(18,2)", maxLength: 5, nullable: true),
                    SatisDevamMı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albumler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Yoneticiler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TelefonNumarasi = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yoneticiler", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albumler");

            migrationBuilder.DropTable(
                name: "Yoneticiler");
        }
    }
}
