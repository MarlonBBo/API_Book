using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API_Book.Model
{
    public class Autor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Livro> Livros { get; set; }
    }
}
