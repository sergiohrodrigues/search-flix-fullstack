﻿// <auto-generated />
using System;
using Filmes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Filmes.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241113171009_addUrlImageAnd")]
    partial class addUrlImageAnd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Filmes.Models.AtorFilmeModel", b =>
                {
                    b.Property<int>("AtorId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.HasKey("AtorId", "FilmeId");

                    b.HasIndex("FilmeId");

                    b.ToTable("AtorFilmeModel");

                    b.HasData(
                        new
                        {
                            AtorId = 1,
                            FilmeId = 1
                        },
                        new
                        {
                            AtorId = 1,
                            FilmeId = 2
                        },
                        new
                        {
                            AtorId = 1,
                            FilmeId = 6
                        },
                        new
                        {
                            AtorId = 2,
                            FilmeId = 2
                        },
                        new
                        {
                            AtorId = 3,
                            FilmeId = 2
                        },
                        new
                        {
                            AtorId = 3,
                            FilmeId = 3
                        },
                        new
                        {
                            AtorId = 3,
                            FilmeId = 4
                        },
                        new
                        {
                            AtorId = 4,
                            FilmeId = 2
                        },
                        new
                        {
                            AtorId = 4,
                            FilmeId = 5
                        });
                });

            modelBuilder.Entity("Filmes.Models.AtorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datanasc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("urlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Atores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Datanasc = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidade = "Americana",
                            Nome = "Robert",
                            Sobrenome = "Downey Jr.",
                            urlImage = "https://i.ibb.co/PM539TD/0101925.webp"
                        },
                        new
                        {
                            Id = 2,
                            Datanasc = new DateTime(1983, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidade = "Americana",
                            Nome = "Christopher",
                            Sobrenome = "Hemsworth",
                            urlImage = "https://i.ibb.co/RCJQRzM/5240675.webp"
                        },
                        new
                        {
                            Id = 3,
                            Datanasc = new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidade = "Americana",
                            Nome = "Chris",
                            Sobrenome = "Evans",
                            urlImage = "https://i.ibb.co/TwCTpSm/Chris-Evans-SDCC-2014.jpg"
                        },
                        new
                        {
                            Id = 4,
                            Datanasc = new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidade = "Americana",
                            Nome = "Scarlett",
                            Sobrenome = "Johansson",
                            urlImage = "https://i.ibb.co/2Nwgn4R/scarlett-johansson-1581352338657-v2-450x600.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Datanasc = new DateTime(1972, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidade = "Americana",
                            Nome = "Gwyneth",
                            Sobrenome = "Paltrow",
                            urlImage = "https://i.ibb.co/f4Rq2LZ/Gwyneth-Paltrow-2013.webp"
                        },
                        new
                        {
                            Id = 6,
                            Datanasc = new DateTime(1982, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nacionalidade = "Britânica e Americana",
                            Nome = "Hayley",
                            Sobrenome = "Atwell",
                            urlImage = "https://i.ibb.co/p4NJm72/Hayley-Atwell-2.webp"
                        });
                });

            modelBuilder.Entity("Filmes.Models.FilmeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlTrailler")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Filmes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Categoria = "Ficação Científica",
                            Descricao = "Tony Stark (Robert Downey Jr.) é um industrial bilionário, que também é um brilhante inventor. Ao ser sequestrado ele é obrigado por terroristas a construir uma arma devastadora mas, ao invés disto, constrói uma armadura de alta tecnologia que permite que fuja de seu cativeiro.",
                            Titulo = "Homem de Ferro",
                            UrlTrailler = "https://www.youtube.com/embed/8ugaeA-nMTc"
                        },
                        new
                        {
                            Id = 2,
                            Categoria = "Ação",
                            Descricao = "Loki (Tom Hiddleston) retorna à Terra enviado pelos chitauri, uma raça alienígena que pretende dominar os humanos. Com a promessa de que será o soberano do planeta, ele rouba o cubo cósmico dentro de instalações da S.H.I.E.L.D. e, com isso, adquire grandes poderes. Loki os usa para controlar o dr. Erik Selvig (Stellan Skarsgard) e Clint Barton/Gavião Arqueiro (Jeremy Renner), que passam a trabalhar para ele. No intuito de contê-los, Nick Fury (Samuel L. Jackson) convoca um grupo de pessoas com grandes habilidades, mas que jamais haviam trabalhado juntas: Tony Stark/Homem de Ferro (Robert Downey Jr.), Steve Rogers/Capitão América (Chris Evans), Thor (Chris Hemsworth), Bruce Banner/Hulk (Mark Ruffalo) e Natasha Romanoff/Viúva Negra (Scarlett Johansson). Só que, apesar do grande perigo que a Terra corre, não é tão simples assim conter o ego e os interesses de cada um deles para que possam agir em grupo.",
                            Titulo = "Vingadores",
                            UrlTrailler = "https://www.youtube.com/embed/KeNEGtsCWEk"
                        },
                        new
                        {
                            Id = 3,
                            Categoria = "Aventura",
                            Descricao = "2ª Guerra Mundial. Steve Rogers (Chris Evans) é um jovem que aceitou ser voluntário em uma série de experiências que visam criar o supersoldado americano. Os militares conseguem transformá-lo em uma arma humana, mas logo percebem que o supersoldado é valioso demais para pôr em risco na luta contra os nazistas. Desta forma, Rogers é usado como uma celebridade do exército, marcando presença em paradas realizadas pela Europa no intuito de levantar a estima dos combatentes. Para tanto passa a usar uma vestimenta com as cores da bandeira dos Estados Unidos, azul, branca e vermelha. Só que um plano nazista faz com que Rogers entre em ação e assuma a alcunha de Capitão América, usando seus dons para combatê-los em plenas trincheiras da guerra.",
                            Titulo = "Capitão América: O Primeiro Vingador",
                            UrlTrailler = "https://www.youtube.com/embed/-006iHDHK34"
                        },
                        new
                        {
                            Id = 4,
                            Categoria = "Aventura",
                            Descricao = "Dois anos após os acontecimentos em Nova York (Os Vingadores - The Avengers), Steve Rogers (Chris Evans) continua seu dedicado trabalho com a agência S.H.I.E.L.D. e também segue tentando se acostumar com o fato de que foi descongelado e acordou décadas depois de seu tempo. Em parceria com Natasha Romanoff (Scarlett Johansson), também conhecida como Viúva Negra, ele é obrigado a enfrentar um poderoso e misterioso inimigo chamado Soldado Invernal, que visita Washington e abala o dia a dia da S.H.I.E.L.D., ainda liderada por Nick Fury (Samuel L. Jackson).",
                            Titulo = "Capitão América 2 - Soldado Invernal",
                            UrlTrailler = "https://www.youtube.com/embed/Fl89Ym_fQJc"
                        },
                        new
                        {
                            Id = 5,
                            Categoria = "Espionagem",
                            Descricao = "Em Viúva Negra, acompanhamos a vida de Natasha Romanoff (Scarlett Johansson) após os eventos de Guerra Civil. Se escondendo do governo norte-americano devido a sua aliança com o time do Capitão América, Natasha ainda precisa confrontar partes de sua história, que ela tanto evita, quando surge uma conspiração perigosa ligada ao seu passado. Perseguida por uma força que não irá parar até derrotá-la, ela terá que lidar com sua antiga vida de espiã, e também reencontrar membros de sua família que deixou para trás antes de se tornar parte dos Vingadores, e lidar com esses relacionamentos quebrados. Ao reencontrar suas raízes, e deixar de evitar lidar com suas vulnerabilidades e traumas, a heroína poderá encontrar a força que tanto precisa.",
                            Titulo = "Viúva Negra",
                            UrlTrailler = "https://www.youtube.com/embed/BotTBc1x7M4"
                        },
                        new
                        {
                            Id = 6,
                            Categoria = "Ficção Científica",
                            Descricao = "Após confessar ao mundo ser o Homem de Ferro, Tony Stark (Robert Downey Jr.) passa a ser alvo do governo dos Estados Unidos, que deseja que ele entregue seu poderoso traje. Com a negativa, o governo passa a desenvolver um novo traje com o maior rival de Stark, Justin Hammer (Sam Rockwell). Jim Rhodes (Don Cheadle), o braço direito de Tony, é colocado no centro deste conflito, o que faz com que assuma a identidade de Máquina de Combate. Paralelamente, Ivan Vanko (Mickey Rourke) cria o alter-ego de Whiplash para se vingar dos atos da família Stark no passado. Para combater Whiplash e a perseguição do governo, Stark conta com o apoio de sua nova assistente, Natasha Romanoff (Scarlett Johansson), e de Nick Fury (Samuel L. Jackson), o diretor da S.H.I.E.L.D.",
                            Titulo = "Homem de Ferro 2",
                            UrlTrailler = "https://www.youtube.com/embed/wKtcmiifycU"
                        });
                });

            modelBuilder.Entity("Filmes.Models.UserAdminModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAdmin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "sergiohrodriguess@gmail.com",
                            Password = "123456",
                            User = "sergio"
                        });
                });

            modelBuilder.Entity("Filmes.Models.AtorFilmeModel", b =>
                {
                    b.HasOne("Filmes.Models.AtorModel", "Ator")
                        .WithMany("AtorFilmes")
                        .HasForeignKey("AtorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Filmes.Models.FilmeModel", "Filme")
                        .WithMany("AtorFilmes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ator");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Filmes.Models.AtorModel", b =>
                {
                    b.Navigation("AtorFilmes");
                });

            modelBuilder.Entity("Filmes.Models.FilmeModel", b =>
                {
                    b.Navigation("AtorFilmes");
                });
#pragma warning restore 612, 618
        }
    }
}
