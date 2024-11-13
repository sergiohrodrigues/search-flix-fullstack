using Filmes.Dto.Vinculo;
using Filmes.Models;

namespace Filmes.Dto.Filme
{
    public class FilmeEditarDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string UrlTrailler { get; set; } = string.Empty;
        public string urlImage { get; set; }
        public AtorVinculoDto Ator { get; set; }
    }
}
