using Filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AtorModel> Atores { get; set; }
        public DbSet<FilmeModel> Filmes { get; set; }
        public DbSet<UserStandardModel> UserStandard { get; set; }
        public DbSet<UserAdminModel> UserAdmin { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AtorFilmeModel>()
            .HasKey(af => new { af.AtorId, af.FilmeId });

            modelBuilder.Entity<AtorFilmeModel>()
                .HasOne(af => af.Ator)
                .WithMany(a => a.AtorFilmes)
                .HasForeignKey(af => af.AtorId);

            modelBuilder.Entity<AtorFilmeModel>()
                .HasOne(af => af.Filme)
                .WithMany(f => f.AtorFilmes)
                .HasForeignKey(af => af.FilmeId);

            // Dados iniciais para a tabela Atores
            modelBuilder.Entity<AtorModel>().HasData(
                new AtorModel { 
                    Id = 1, 
                    Nome = "Robert", 
                    Sobrenome = "Downey Jr.", 
                    Datanasc = new DateTime(1965, 4, 4), 
                    Nacionalidade = "Americana",
                    urlImage = "https://i.ibb.co/PM539TD/0101925.webp"
                },
                new AtorModel { 
                    Id = 2, 
                    Nome = "Christopher", 
                    Sobrenome = "Hemsworth", 
                    Datanasc = new DateTime(1983, 8, 11), 
                    Nacionalidade = "Americana",
                    urlImage = "https://i.ibb.co/RCJQRzM/5240675.webp"
                },
                new AtorModel { 
                    Id = 3, 
                    Nome = "Chris", 
                    Sobrenome = "Evans", 
                    Datanasc = new DateTime(1981, 6, 13), 
                    Nacionalidade = "Americana",
                    urlImage = "https://i.ibb.co/TwCTpSm/Chris-Evans-SDCC-2014.jpg"
                },
                new AtorModel { 
                    Id = 4, 
                    Nome = "Scarlett", 
                    Sobrenome = "Johansson", 
                    Datanasc = new DateTime(1984, 11, 22), 
                    Nacionalidade = "Americana",
                    urlImage = "https://i.ibb.co/2Nwgn4R/scarlett-johansson-1581352338657-v2-450x600.jpg"
                },
                new AtorModel { 
                    Id = 5, 
                    Nome = "Gwyneth", 
                    Sobrenome = "Paltrow", 
                    Datanasc = new DateTime(1972, 09, 27), 
                    Nacionalidade = "Americana",
                    urlImage = "https://i.ibb.co/f4Rq2LZ/Gwyneth-Paltrow-2013.webp"
                },
                new AtorModel { 
                    Id = 6, 
                    Nome = "Hayley", 
                    Sobrenome = "Atwell", 
                    Datanasc = new DateTime(1982, 05, 05), 
                    Nacionalidade = "Britânica e Americana",
                    urlImage = "https://i.ibb.co/p4NJm72/Hayley-Atwell-2.webp"
                }
            );

            // Dados iniciais para a tabela Filmes
            modelBuilder.Entity<FilmeModel>().HasData(
                new FilmeModel
                {
                    Id = 1,
                    Titulo = "Homem de Ferro",
                    Descricao = "Tony Stark (Robert Downey Jr.) é um industrial bilionário, que também é um brilhante inventor. Ao ser sequestrado ele é obrigado por terroristas a construir uma arma devastadora mas, ao invés disto, constrói uma armadura de alta tecnologia que permite que fuja de seu cativeiro.",
                    Categoria = "Ficação Científica",
                    UrlTrailler = "https://www.youtube.com/embed/8ugaeA-nMTc",
                    urlImage = "https://i.ibb.co/9HK072n/81v-THovrz-L-AC-UF894-1000-QL80.jpg"
                },
                new FilmeModel
                {
                    Id = 2,
                    Titulo = "Os Vingadores",
                    Descricao = "Loki (Tom Hiddleston) retorna à Terra enviado pelos chitauri, uma raça alienígena que pretende dominar os humanos. Com a promessa de que será o soberano do planeta, ele rouba o cubo cósmico dentro de instalações da S.H.I.E.L.D. e, com isso, adquire grandes poderes. Loki os usa para controlar o dr. Erik Selvig (Stellan Skarsgard) e Clint Barton/Gavião Arqueiro (Jeremy Renner), que passam a trabalhar para ele. No intuito de contê-los, Nick Fury (Samuel L. Jackson) convoca um grupo de pessoas com grandes habilidades, mas que jamais haviam trabalhado juntas: Tony Stark/Homem de Ferro (Robert Downey Jr.), Steve Rogers/Capitão América (Chris Evans), Thor (Chris Hemsworth), Bruce Banner/Hulk (Mark Ruffalo) e Natasha Romanoff/Viúva Negra (Scarlett Johansson). Só que, apesar do grande perigo que a Terra corre, não é tão simples assim conter o ego e os interesses de cada um deles para que possam agir em grupo.",
                    Categoria = "Ação",
                    UrlTrailler = "https://www.youtube.com/embed/KeNEGtsCWEk",
                    urlImage = "https://i.ibb.co/WD8sg72/big-poster-filme-os-vingadores-2012-lo03-tamanho-90x60-cm-vingadores-era-de-ultron.jpg"
                },
                new FilmeModel
                {
                    Id = 3,
                    Titulo = "Capitão América: O Primeiro Vingador",
                    Descricao = "2ª Guerra Mundial. Steve Rogers (Chris Evans) é um jovem que aceitou ser voluntário em uma série de experiências que visam criar o supersoldado americano. Os militares conseguem transformá-lo em uma arma humana, mas logo percebem que o supersoldado é valioso demais para pôr em risco na luta contra os nazistas. Desta forma, Rogers é usado como uma celebridade do exército, marcando presença em paradas realizadas pela Europa no intuito de levantar a estima dos combatentes. Para tanto passa a usar uma vestimenta com as cores da bandeira dos Estados Unidos, azul, branca e vermelha. Só que um plano nazista faz com que Rogers entre em ação e assuma a alcunha de Capitão América, usando seus dons para combatê-los em plenas trincheiras da guerra.",
                    Categoria = "Aventura",
                    UrlTrailler = "https://www.youtube.com/embed/-006iHDHK34",
                    urlImage = "https://i.ibb.co/2WCtpSf/17153721540786.webp"
                },
                new FilmeModel
                {
                    Id = 4,
                    Titulo = "Capitão América 2 - Soldado Invernal",
                    Descricao = "Dois anos após os acontecimentos em Nova York (Os Vingadores - The Avengers), Steve Rogers (Chris Evans) continua seu dedicado trabalho com a agência S.H.I.E.L.D. e também segue tentando se acostumar com o fato de que foi descongelado e acordou décadas depois de seu tempo. Em parceria com Natasha Romanoff (Scarlett Johansson), também conhecida como Viúva Negra, ele é obrigado a enfrentar um poderoso e misterioso inimigo chamado Soldado Invernal, que visita Washington e abala o dia a dia da S.H.I.E.L.D., ainda liderada por Nick Fury (Samuel L. Jackson).",
                    Categoria = "Aventura",
                    UrlTrailler = "https://www.youtube.com/embed/Fl89Ym_fQJc",
                    urlImage = "https://i.ibb.co/qrVH6pG/257136.webp"
                },
                new FilmeModel
                {
                    Id = 5,
                    Titulo = "Viúva Negra",
                    Descricao = "Em Viúva Negra, acompanhamos a vida de Natasha Romanoff (Scarlett Johansson) após os eventos de Guerra Civil. Se escondendo do governo norte-americano devido a sua aliança com o time do Capitão América, Natasha ainda precisa confrontar partes de sua história, que ela tanto evita, quando surge uma conspiração perigosa ligada ao seu passado. Perseguida por uma força que não irá parar até derrotá-la, ela terá que lidar com sua antiga vida de espiã, e também reencontrar membros de sua família que deixou para trás antes de se tornar parte dos Vingadores, e lidar com esses relacionamentos quebrados. Ao reencontrar suas raízes, e deixar de evitar lidar com suas vulnerabilidades e traumas, a heroína poderá encontrar a força que tanto precisa.",
                    Categoria = "Espionagem",
                    UrlTrailler = "https://www.youtube.com/embed/BotTBc1x7M4",
                    urlImage = "https://i.ibb.co/b287M1p/film5.jpg"
                },
                new FilmeModel
                {
                    Id = 6,
                    Titulo = "Homem de Ferro 2",
                    Descricao = "Após confessar ao mundo ser o Homem de Ferro, Tony Stark (Robert Downey Jr.) passa a ser alvo do governo dos Estados Unidos, que deseja que ele entregue seu poderoso traje. Com a negativa, o governo passa a desenvolver um novo traje com o maior rival de Stark, Justin Hammer (Sam Rockwell). Jim Rhodes (Don Cheadle), o braço direito de Tony, é colocado no centro deste conflito, o que faz com que assuma a identidade de Máquina de Combate. Paralelamente, Ivan Vanko (Mickey Rourke) cria o alter-ego de Whiplash para se vingar dos atos da família Stark no passado. Para combater Whiplash e a perseguição do governo, Stark conta com o apoio de sua nova assistente, Natasha Romanoff (Scarlett Johansson), e de Nick Fury (Samuel L. Jackson), o diretor da S.H.I.E.L.D.",
                    Categoria = "Ficção Científica",
                    UrlTrailler = "https://www.youtube.com/embed/wKtcmiifycU",
                    urlImage = "https://i.ibb.co/cX7Gd21/big-poster-filme-homem-de-ferro-2-lo04-tamanho-90x60-cm-iron-man.webp"
                }
            );

            // Dados iniciais para a tabela de Atores e Filmes
            modelBuilder.Entity<AtorFilmeModel>().HasData(
                new AtorFilmeModel
                {
                    AtorId = 1,
                    FilmeId = 1,
                },
                new AtorFilmeModel
                {
                    AtorId = 1,
                    FilmeId = 2,
                },
                new AtorFilmeModel
                {
                    AtorId = 1,
                    FilmeId = 6,
                },
                new AtorFilmeModel
                {
                    AtorId = 2,
                    FilmeId = 2,
                },
                new AtorFilmeModel
                {
                    AtorId = 3,
                    FilmeId = 2,
                },
                new AtorFilmeModel
                {
                    AtorId = 3,
                    FilmeId = 3,
                },
                new AtorFilmeModel
                {
                    AtorId = 3,
                    FilmeId = 4,
                },
                new AtorFilmeModel
                {
                    AtorId = 4,
                    FilmeId = 2,
                },
                new AtorFilmeModel
                {
                    AtorId = 4,
                    FilmeId = 5,
                },
                new AtorFilmeModel
                {
                    AtorId = 5,
                    FilmeId = 1,
                },
                new AtorFilmeModel
                {
                    AtorId = 5,
                    FilmeId = 6,
                },
                new AtorFilmeModel
                {
                    AtorId = 6,
                    FilmeId = 3,
                }
            );

            //Dados iniciais para a tabela de UserStandard
            modelBuilder.Entity<UserStandardModel>().HasData(
                new UserStandardModel
                {
                    Id = 1,
                    User = "sergior",
                    Password = "1234567",
                    Email = "sergioteste@gmail.com"
                }
               );

            //Dados iniciais para a tabela de UserAdmin
            modelBuilder.Entity<UserAdminModel>().HasData(
                new UserAdminModel
                {
                    Id = 2,
                    User = "sergio",
                    Password = "123456",
                    Email = "sergiohrodriguess@gmail.com",
                    Datanasc = new DateTime(1994, 9, 24)
                }
               );
            
        }
    }
}
