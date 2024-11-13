using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class addUrlImageFilmes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "urlImage",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1,
                column: "urlImage",
                value: "https://i.ibb.co/9HK072n/81v-THovrz-L-AC-UF894-1000-QL80.jpg");

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Titulo", "urlImage" },
                values: new object[] { "Os Vingadores", "https://i.ibb.co/WD8sg72/big-poster-filme-os-vingadores-2012-lo03-tamanho-90x60-cm-vingadores-era-de-ultron.jpg" });

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3,
                column: "urlImage",
                value: "https://i.ibb.co/2WCtpSf/17153721540786.webp");

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4,
                column: "urlImage",
                value: "https://i.ibb.co/qrVH6pG/257136.webp");

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 5,
                column: "urlImage",
                value: "https://i.ibb.co/b287M1p/film5.jpg");

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 6,
                column: "urlImage",
                value: "https://i.ibb.co/cX7Gd21/big-poster-filme-homem-de-ferro-2-lo04-tamanho-90x60-cm-iron-man.webp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "urlImage",
                table: "Filmes");

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Titulo",
                value: "Vingadores");
        }
    }
}
