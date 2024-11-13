using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class muitoParaMuitosAtoresEFilmes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Atores_AtorId",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_AtorId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "AtorId",
                table: "Filmes");

            migrationBuilder.CreateTable(
                name: "AtorFilmeModel",
                columns: table => new
                {
                    AtorId = table.Column<int>(type: "int", nullable: false),
                    FilmeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtorFilmeModel", x => new { x.AtorId, x.FilmeId });
                    table.ForeignKey(
                        name: "FK_AtorFilmeModel_Atores_AtorId",
                        column: x => x.AtorId,
                        principalTable: "Atores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtorFilmeModel_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtorFilmeModel_FilmeId",
                table: "AtorFilmeModel",
                column: "FilmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtorFilmeModel");

            migrationBuilder.AddColumn<int>(
                name: "AtorId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1,
                column: "AtorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AtorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AtorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4,
                column: "AtorId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 5,
                column: "AtorId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 6,
                column: "AtorId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_AtorId",
                table: "Filmes",
                column: "AtorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Atores_AtorId",
                table: "Filmes",
                column: "AtorId",
                principalTable: "Atores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
