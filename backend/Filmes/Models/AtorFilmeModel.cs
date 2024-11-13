namespace Filmes.Models
{
    public class AtorFilmeModel
    {
        public int AtorId { get; set; }
        public AtorModel Ator { get; set; }
        public int FilmeId { get; set; }
        public FilmeModel Filme { get; set; }
    }
}
