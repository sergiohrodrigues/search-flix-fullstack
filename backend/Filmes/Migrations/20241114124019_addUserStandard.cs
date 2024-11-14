using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class addUserStandard : Migration
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
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urlImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    urlImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datanasc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStandard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStandard", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Atores",
                columns: new[] { "Id", "Datanasc", "Nacionalidade", "Nome", "Sobrenome", "urlImage" },
                values: new object[,]
                {
                    { 1, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americana", "Robert", "Downey Jr.", "https://i.ibb.co/PM539TD/0101925.webp" },
                    { 2, new DateTime(1983, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americana", "Christopher", "Hemsworth", "https://i.ibb.co/RCJQRzM/5240675.webp" },
                    { 3, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americana", "Chris", "Evans", "https://i.ibb.co/TwCTpSm/Chris-Evans-SDCC-2014.jpg" },
                    { 4, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americana", "Scarlett", "Johansson", "https://i.ibb.co/2Nwgn4R/scarlett-johansson-1581352338657-v2-450x600.jpg" },
                    { 5, new DateTime(1972, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americana", "Gwyneth", "Paltrow", "https://i.ibb.co/f4Rq2LZ/Gwyneth-Paltrow-2013.webp" },
                    { 6, new DateTime(1982, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Britânica e Americana", "Hayley", "Atwell", "https://i.ibb.co/p4NJm72/Hayley-Atwell-2.webp" }
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Categoria", "Descricao", "Titulo", "UrlTrailler", "urlImage" },
                values: new object[,]
                {
                    { 1, "Ficação Científica", "Tony Stark (Robert Downey Jr.) é um industrial bilionário, que também é um brilhante inventor. Ao ser sequestrado ele é obrigado por terroristas a construir uma arma devastadora mas, ao invés disto, constrói uma armadura de alta tecnologia que permite que fuja de seu cativeiro.", "Homem de Ferro", "https://www.youtube.com/embed/8ugaeA-nMTc", "https://i.ibb.co/9HK072n/81v-THovrz-L-AC-UF894-1000-QL80.jpg" },
                    { 2, "Ação", "Loki (Tom Hiddleston) retorna à Terra enviado pelos chitauri, uma raça alienígena que pretende dominar os humanos. Com a promessa de que será o soberano do planeta, ele rouba o cubo cósmico dentro de instalações da S.H.I.E.L.D. e, com isso, adquire grandes poderes. Loki os usa para controlar o dr. Erik Selvig (Stellan Skarsgard) e Clint Barton/Gavião Arqueiro (Jeremy Renner), que passam a trabalhar para ele. No intuito de contê-los, Nick Fury (Samuel L. Jackson) convoca um grupo de pessoas com grandes habilidades, mas que jamais haviam trabalhado juntas: Tony Stark/Homem de Ferro (Robert Downey Jr.), Steve Rogers/Capitão América (Chris Evans), Thor (Chris Hemsworth), Bruce Banner/Hulk (Mark Ruffalo) e Natasha Romanoff/Viúva Negra (Scarlett Johansson). Só que, apesar do grande perigo que a Terra corre, não é tão simples assim conter o ego e os interesses de cada um deles para que possam agir em grupo.", "Os Vingadores", "https://www.youtube.com/embed/KeNEGtsCWEk", "https://i.ibb.co/WD8sg72/big-poster-filme-os-vingadores-2012-lo03-tamanho-90x60-cm-vingadores-era-de-ultron.jpg" },
                    { 3, "Aventura", "2ª Guerra Mundial. Steve Rogers (Chris Evans) é um jovem que aceitou ser voluntário em uma série de experiências que visam criar o supersoldado americano. Os militares conseguem transformá-lo em uma arma humana, mas logo percebem que o supersoldado é valioso demais para pôr em risco na luta contra os nazistas. Desta forma, Rogers é usado como uma celebridade do exército, marcando presença em paradas realizadas pela Europa no intuito de levantar a estima dos combatentes. Para tanto passa a usar uma vestimenta com as cores da bandeira dos Estados Unidos, azul, branca e vermelha. Só que um plano nazista faz com que Rogers entre em ação e assuma a alcunha de Capitão América, usando seus dons para combatê-los em plenas trincheiras da guerra.", "Capitão América: O Primeiro Vingador", "https://www.youtube.com/embed/-006iHDHK34", "https://i.ibb.co/2WCtpSf/17153721540786.webp" },
                    { 4, "Aventura", "Dois anos após os acontecimentos em Nova York (Os Vingadores - The Avengers), Steve Rogers (Chris Evans) continua seu dedicado trabalho com a agência S.H.I.E.L.D. e também segue tentando se acostumar com o fato de que foi descongelado e acordou décadas depois de seu tempo. Em parceria com Natasha Romanoff (Scarlett Johansson), também conhecida como Viúva Negra, ele é obrigado a enfrentar um poderoso e misterioso inimigo chamado Soldado Invernal, que visita Washington e abala o dia a dia da S.H.I.E.L.D., ainda liderada por Nick Fury (Samuel L. Jackson).", "Capitão América 2 - Soldado Invernal", "https://www.youtube.com/embed/Fl89Ym_fQJc", "https://i.ibb.co/qrVH6pG/257136.webp" },
                    { 5, "Espionagem", "Em Viúva Negra, acompanhamos a vida de Natasha Romanoff (Scarlett Johansson) após os eventos de Guerra Civil. Se escondendo do governo norte-americano devido a sua aliança com o time do Capitão América, Natasha ainda precisa confrontar partes de sua história, que ela tanto evita, quando surge uma conspiração perigosa ligada ao seu passado. Perseguida por uma força que não irá parar até derrotá-la, ela terá que lidar com sua antiga vida de espiã, e também reencontrar membros de sua família que deixou para trás antes de se tornar parte dos Vingadores, e lidar com esses relacionamentos quebrados. Ao reencontrar suas raízes, e deixar de evitar lidar com suas vulnerabilidades e traumas, a heroína poderá encontrar a força que tanto precisa.", "Viúva Negra", "https://www.youtube.com/embed/BotTBc1x7M4", "https://i.ibb.co/b287M1p/film5.jpg" },
                    { 6, "Ficção Científica", "Após confessar ao mundo ser o Homem de Ferro, Tony Stark (Robert Downey Jr.) passa a ser alvo do governo dos Estados Unidos, que deseja que ele entregue seu poderoso traje. Com a negativa, o governo passa a desenvolver um novo traje com o maior rival de Stark, Justin Hammer (Sam Rockwell). Jim Rhodes (Don Cheadle), o braço direito de Tony, é colocado no centro deste conflito, o que faz com que assuma a identidade de Máquina de Combate. Paralelamente, Ivan Vanko (Mickey Rourke) cria o alter-ego de Whiplash para se vingar dos atos da família Stark no passado. Para combater Whiplash e a perseguição do governo, Stark conta com o apoio de sua nova assistente, Natasha Romanoff (Scarlett Johansson), e de Nick Fury (Samuel L. Jackson), o diretor da S.H.I.E.L.D.", "Homem de Ferro 2", "https://www.youtube.com/embed/wKtcmiifycU", "https://i.ibb.co/cX7Gd21/big-poster-filme-homem-de-ferro-2-lo04-tamanho-90x60-cm-iron-man.webp" }
                });

            migrationBuilder.InsertData(
                table: "UserAdmin",
                columns: new[] { "Id", "Datanasc", "Email", "Password", "User" },
                values: new object[] { 2, new DateTime(1994, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "sergiohrodriguess@gmail.com", "123456", "sergio" });

            migrationBuilder.InsertData(
                table: "UserStandard",
                columns: new[] { "Id", "Email", "Password", "User" },
                values: new object[] { 1, "sergioteste@gmail.com", "1234567", "sergior" });

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

            migrationBuilder.DropTable(
                name: "UserAdmin");

            migrationBuilder.DropTable(
                name: "UserStandard");

            migrationBuilder.DropTable(
                name: "Atores");

            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
