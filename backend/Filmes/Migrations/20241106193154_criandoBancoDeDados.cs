using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class criandoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datanasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlTrailler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmes_Atores_AtorId",
                        column: x => x.AtorId,
                        principalTable: "Atores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Atores",
                columns: new[] { "Id", "Datanasc", "Nacionalidade", "Nome", "Sobrenome" },
                values: new object[,]
                {
                    { 1, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americana", "Robert", "Downey Jr." },
                    { 2, new DateTime(1983, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americana", "Christopher", "Hemsworth" },
                    { 3, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americana", "Chris", "Evans" },
                    { 4, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americana", "Scarlett", "Johansson" }
                });

            migrationBuilder.InsertData(
            table: "Filmes",
            columns: new[] { "Id", "Titulo", "Descricao", "Categoria", "UrlTrailler", "AtorId" },
            values: new object[,]
            {
                {
                    1,
                    "Homem de Ferro",
                    "Tony Stark (Robert Downey Jr.) é um industrial bilionário, que também é um brilhante inventor. Ao ser sequestrado ele é obrigado por terroristas a construir uma arma devastadora mas, ao invés disto, constrói uma armadura de alta tecnologia que permite que fuja de seu cativeiro.",
                    "Ficação Científica",
                    "https://www.youtube.com/embed/8ugaeA-nMTc",
                    1
                },
                {
                    2,
                    "Vingadores",
                    "Loki (Tom Hiddleston) retorna à Terra enviado pelos chitauri, uma raça alienígena que pretende dominar os humanos. Com a promessa de que será o soberano do planeta, ele rouba o cubo cósmico dentro de instalações da S.H.I.E.L.D. e, com isso, adquire grandes poderes. Loki os usa para controlar o dr. Erik Selvig (Stellan Skarsgard) e Clint Barton/Gavião Arqueiro (Jeremy Renner), que passam a trabalhar para ele. No intuito de contê-los, Nick Fury (Samuel L. Jackson) convoca um grupo de pessoas com grandes habilidades, mas que jamais haviam trabalhado juntas: Tony Stark/Homem de Ferro (Robert Downey Jr.), Steve Rogers/Capitão América (Chris Evans), Thor (Chris Hemsworth), Bruce Banner/Hulk (Mark Ruffalo) e Natasha Romanoff/Viúva Negra (Scarlett Johansson). Só que, apesar do grande perigo que a Terra corre, não é tão simples assim conter o ego e os interesses de cada um deles para que possam agir em grupo.",
                    "Ação",
                    "https://www.youtube.com/embed/KeNEGtsCWEk",
                    2
                },
                {
                    3,
                    "Capitão América: O Primeiro Vingador",
                    "2ª Guerra Mundial. Steve Rogers (Chris Evans) é um jovem que aceitou ser voluntário em uma série de experiências que visam criar o supersoldado americano. Os militares conseguem transformá-lo em uma arma humana, mas logo percebem que o supersoldado é valioso demais para pôr em risco na luta contra os nazistas. Desta forma, Rogers é usado como uma celebridade do exército, marcando presença em paradas realizadas pela Europa no intuito de levantar a estima dos combatentes. Para tanto passa a usar uma vestimenta com as cores da bandeira dos Estados Unidos, azul, branca e vermelha. Só que um plano nazista faz com que Rogers entre em ação e assuma a alcunha de Capitão América, usando seus dons para combatê-los em plenas trincheiras da guerra.",
                    "Aventura",
                    "https://www.youtube.com/embed/-006iHDHK34",
                    3
                },
                {
                    4,
                    "Capitão América 2 - Soldado Invernal",
                    "Dois anos após os acontecimentos em Nova York (Os Vingadores - The Avengers), Steve Rogers (Chris Evans) continua seu dedicado trabalho com a agência S.H.I.E.L.D. e também segue tentando se acostumar com o fato de que foi descongelado e acordou décadas depois de seu tempo. Em parceria com Natasha Romanoff (Scarlett Johansson), também conhecida como Viúva Negra, ele é obrigado a enfrentar um poderoso e misterioso inimigo chamado Soldado Invernal, que visita Washington e abala o dia a dia da S.H.I.E.L.D., ainda liderada por Nick Fury (Samuel L. Jackson).",
                    "Aventura",
                    "https://www.youtube.com/embed/Fl89Ym_fQJc",
                    3
                },
                {
                    5,
                    "Viúva Negra",
                    "Em Viúva Negra, acompanhamos a vida de Natasha Romanoff (Scarlett Johansson) após os eventos de Guerra Civil. Se escondendo do governo norte-americano devido a sua aliança com o time do Capitão América, Natasha ainda precisa confrontar partes de sua história, que ela tanto evita, quando surge uma conspiração perigosa ligada ao seu passado. Perseguida por uma força que não irá parar até derrotá-la, ela terá que lidar com sua antiga vida de espiã, e também reencontrar membros de sua família que deixou para trás antes de se tornar parte dos Vingadores, e lidar com esses relacionamentos quebrados. Ao reencontrar suas raízes, e deixar de evitar lidar com suas vulnerabilidades e traumas, a heroína poderá encontrar a força que tanto precisa.",
                    "Espionagem",
                    "https://www.youtube.com/embed/BotTBc1x7M4",
                    4
                }
            });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_AtorId",
                table: "Filmes",
                column: "AtorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Atores");
        }
    }
}
