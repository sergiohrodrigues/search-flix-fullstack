using System.ComponentModel.DataAnnotations.Schema;
using static Filmes.Enums.EnumCategorias;

namespace Filmes.Models
{
    public class FilmeModel
    {

        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty ;
        public string UrlTrailler { get; set; } = string.Empty;
        public int AtorId { get; set; }

        // Define o relacionamento com AtorModel
        [ForeignKey("AtorId")]
        public AtorModel Ator { get; set; }
    }
}
