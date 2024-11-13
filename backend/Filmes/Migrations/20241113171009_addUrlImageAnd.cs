using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class addUrlImageAnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "urlImage",
                table: "Atores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 1,
                column: "urlImage",
                value: "https://i.ibb.co/PM539TD/0101925.webp");

            migrationBuilder.UpdateData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 2,
                column: "urlImage",
                value: "https://i.ibb.co/RCJQRzM/5240675.webp");

            migrationBuilder.UpdateData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 3,
                column: "urlImage",
                value: "https://i.ibb.co/TwCTpSm/Chris-Evans-SDCC-2014.jpg");

            migrationBuilder.UpdateData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 4,
                column: "urlImage",
                value: "https://i.ibb.co/2Nwgn4R/scarlett-johansson-1581352338657-v2-450x600.jpg");

            migrationBuilder.InsertData(
                table: "Atores",
                columns: new[] { "Id", "Datanasc", "Nacionalidade", "Nome", "Sobrenome", "urlImage" },
                values: new object[,]
                {
                    { 5, new DateTime(1972, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americana", "Gwyneth", "Paltrow", "https://i.ibb.co/f4Rq2LZ/Gwyneth-Paltrow-2013.webp" },
                    { 6, new DateTime(1982, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Britânica e Americana", "Hayley", "Atwell", "https://i.ibb.co/p4NJm72/Hayley-Atwell-2.webp" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Atores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "urlImage",
                table: "Atores");
        }
    }
}
