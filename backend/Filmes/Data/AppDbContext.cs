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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Dados iniciais para a tabela Atores
            modelBuilder.Entity<AtorModel>().HasData(
                new AtorModel { 
                    Id = 1, 
                    Nome = "Robert", 
                    Sobrenome = "Downey Jr.", 
                    Datanasc = new DateTime(1965, 4, 4), 
                    Nacionalidade = "Americana" 
                },
                new AtorModel { 
                    Id = 2, 
                    Nome = "Christopher", 
                    Sobrenome = "Hemsworth", 
                    Datanasc = new DateTime(1983, 8, 11), 
                    Nacionalidade = "Americana" 
                },
                new AtorModel { 
                    Id = 3, 
                    Nome = "Chris", 
                    Sobrenome = "Evans", 
                    Datanasc = new DateTime(1981, 6, 13), 
                    Nacionalidade = "Americana" 
                },
                new AtorModel { 
                    Id = 4, 
                    Nome = "Scarlett", 
                    Sobrenome = "Johansson", 
                    Datanasc = new DateTime(1984, 11, 22), 
                    Nacionalidade = "Americana" 
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
                    AtorId = 1
                },
                new FilmeModel
                {
                    Id = 2,
                    Titulo = "Vingadores",
                    Descricao = "Loki (Tom Hiddleston) retorna à Terra enviado pelos chitauri, uma raça alienígena que pretende dominar os humanos. Com a promessa de que será o soberano do planeta, ele rouba o cubo cósmico dentro de instalações da S.H.I.E.L.D. e, com isso, adquire grandes poderes. Loki os usa para controlar o dr. Erik Selvig (Stellan Skarsgard) e Clint Barton/Gavião Arqueiro (Jeremy Renner), que passam a trabalhar para ele. No intuito de contê-los, Nick Fury (Samuel L. Jackson) convoca um grupo de pessoas com grandes habilidades, mas que jamais haviam trabalhado juntas: Tony Stark/Homem de Ferro (Robert Downey Jr.), Steve Rogers/Capitão América (Chris Evans), Thor (Chris Hemsworth), Bruce Banner/Hulk (Mark Ruffalo) e Natasha Romanoff/Viúva Negra (Scarlett Johansson). Só que, apesar do grande perigo que a Terra corre, não é tão simples assim conter o ego e os interesses de cada um deles para que possam agir em grupo.",
                    Categoria = "Ação",
                    UrlTrailler = "https://www.youtube.com/embed/KeNEGtsCWEk",
                    AtorId = 2
                },
                new FilmeModel
                {
                    Id = 3,
                    Titulo = "Capitão América: O Primeiro Vingador",
                    Descricao = "2ª Guerra Mundial. Steve Rogers (Chris Evans) é um jovem que aceitou ser voluntário em uma série de experiências que visam criar o supersoldado americano. Os militares conseguem transformá-lo em uma arma humana, mas logo percebem que o supersoldado é valioso demais para pôr em risco na luta contra os nazistas. Desta forma, Rogers é usado como uma celebridade do exército, marcando presença em paradas realizadas pela Europa no intuito de levantar a estima dos combatentes. Para tanto passa a usar uma vestimenta com as cores da bandeira dos Estados Unidos, azul, branca e vermelha. Só que um plano nazista faz com que Rogers entre em ação e assuma a alcunha de Capitão América, usando seus dons para combatê-los em plenas trincheiras da guerra.",
                    Categoria = "Aventura",
                    UrlTrailler = "https://www.youtube.com/embed/-006iHDHK34",
                    AtorId = 3
                },
                new FilmeModel
                {
                    Id = 4,
                    Titulo = "Capitão América 2 - Soldado Invernal",
                    Descricao = "Dois anos após os acontecimentos em Nova York (Os Vingadores - The Avengers), Steve Rogers (Chris Evans) continua seu dedicado trabalho com a agência S.H.I.E.L.D. e também segue tentando se acostumar com o fato de que foi descongelado e acordou décadas depois de seu tempo. Em parceria com Natasha Romanoff (Scarlett Johansson), também conhecida como Viúva Negra, ele é obrigado a enfrentar um poderoso e misterioso inimigo chamado Soldado Invernal, que visita Washington e abala o dia a dia da S.H.I.E.L.D., ainda liderada por Nick Fury (Samuel L. Jackson).",
                    Categoria = "Aventura",
                    UrlTrailler = "https://www.youtube.com/embed/Fl89Ym_fQJc",
                    AtorId = 3
                },
                new FilmeModel
                {
                    Id = 5,
                    Titulo = "Viúva Negra",
                    Descricao = "Em Viúva Negra, acompanhamos a vida de Natasha Romanoff (Scarlett Johansson) após os eventos de Guerra Civil. Se escondendo do governo norte-americano devido a sua aliança com o time do Capitão América, Natasha ainda precisa confrontar partes de sua história, que ela tanto evita, quando surge uma conspiração perigosa ligada ao seu passado. Perseguida por uma força que não irá parar até derrotá-la, ela terá que lidar com sua antiga vida de espiã, e também reencontrar membros de sua família que deixou para trás antes de se tornar parte dos Vingadores, e lidar com esses relacionamentos quebrados. Ao reencontrar suas raízes, e deixar de evitar lidar com suas vulnerabilidades e traumas, a heroína poderá encontrar a força que tanto precisa.",
                    Categoria = "Espionagem",
                    UrlTrailler = "https://www.youtube.com/embed/BotTBc1x7M4",
                    AtorId = 4
                },
                new FilmeModel
                {
                    Id = 6,
                    Titulo = "Homem de Ferro 2",
                    Descricao = "Após confessar ao mundo ser o Homem de Ferro, Tony Stark (Robert Downey Jr.) passa a ser alvo do governo dos Estados Unidos, que deseja que ele entregue seu poderoso traje. Com a negativa, o governo passa a desenvolver um novo traje com o maior rival de Stark, Justin Hammer (Sam Rockwell). Jim Rhodes (Don Cheadle), o braço direito de Tony, é colocado no centro deste conflito, o que faz com que assuma a identidade de Máquina de Combate. Paralelamente, Ivan Vanko (Mickey Rourke) cria o alter-ego de Whiplash para se vingar dos atos da família Stark no passado. Para combater Whiplash e a perseguição do governo, Stark conta com o apoio de sua nova assistente, Natasha Romanoff (Scarlett Johansson), e de Nick Fury (Samuel L. Jackson), o diretor da S.H.I.E.L.D.",
                    Categoria = "Ficção Científica",
                    UrlTrailler = "https://www.youtube.com/embed/wKtcmiifycU",
                    AtorId = 1
                }
            );
        }
    }
}
