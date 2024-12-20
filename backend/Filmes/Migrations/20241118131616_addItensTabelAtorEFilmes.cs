﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class addItensTabelAtorEFilmes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AtorFilmeModel",
                columns: new[] { "AtorId", "FilmeId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 5, 6 },
                    { 6, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "AtorFilmeModel",
                keyColumns: new[] { "AtorId", "FilmeId" },
                keyValues: new object[] { 6, 3 });
        }
    }
}
