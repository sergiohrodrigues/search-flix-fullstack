using Filmes.Dto.Vinculo;
using Filmes.Models;

namespace Filmes.Dto.Filme
{
    public class FilmeEditarDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public AtorVinculoDto Ator { get; set; }
    }
}
