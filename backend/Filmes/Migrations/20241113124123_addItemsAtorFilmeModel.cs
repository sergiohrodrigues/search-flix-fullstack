using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class addItemsAtorFilmeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AtorFilmeModel",
                columns: new[] { "AtorId", "FilmeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 6 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 2 },
                    { 4, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 4, 5 });
        }
    }
}
