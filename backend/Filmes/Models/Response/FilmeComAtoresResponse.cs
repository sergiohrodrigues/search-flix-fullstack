namespace Filmes.Models.Response
{
    public class FilmeComAtoresResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string UrlTrailler { get; set; }
        public List<AtorModel> Atores { get; set; }
    }
}
