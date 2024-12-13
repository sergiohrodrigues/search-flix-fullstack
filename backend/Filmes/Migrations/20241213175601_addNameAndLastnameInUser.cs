using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class addNameAndLastnameInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "UserStandard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserStandard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "UserAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserAdmin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UserAdmin",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Lastname", "Name" },
                values: new object[] { "Rodrigues", "Sergio" });

            migrationBuilder.UpdateData(
                table: "UserStandard",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Lastname", "Name" },
                values: new object[] { "Rodrigues", "Sergio" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "UserStandard");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserStandard");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "UserAdmin");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserAdmin");
        }
    }
}
