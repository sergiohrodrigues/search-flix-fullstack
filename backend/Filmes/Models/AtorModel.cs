using System.Text.Json.Serialization;

namespace Filmes.Models
{
    public class AtorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Datanasc { get; set; }
        public string Nacionalidade { get; set; }
        [JsonIgnore]
        public ICollection<FilmeModel> Filmes { get; set; }
    }
}
