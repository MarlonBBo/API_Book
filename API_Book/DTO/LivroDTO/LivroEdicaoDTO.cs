using API_Book.Model;

namespace API_Book.DTO.LivroDTO
{
    public class LivroEdicaoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
    }
}
