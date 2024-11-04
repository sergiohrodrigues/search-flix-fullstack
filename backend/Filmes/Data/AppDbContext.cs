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


    }
}
