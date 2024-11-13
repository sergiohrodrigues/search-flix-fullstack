using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Filmes.Models
{
    public class FilmeModel
    {

        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty ;
        public string UrlTrailler { get; set; } = string.Empty;

        public string urlImage { get; set; }
        [JsonIgnore]
        public ICollection<AtorFilmeModel> AtorFilmes { get; set; }
    }
}
