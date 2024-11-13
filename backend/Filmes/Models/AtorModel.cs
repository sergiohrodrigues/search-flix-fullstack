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
        public string urlImage { get; set; }
        [JsonIgnore]
        public ICollection<AtorFilmeModel> AtorFilmes { get; set; }
    }
}
