
using API_Book.DTO.AutorDTO;

namespace API_Book.DTO.LivroDTO
{
    public class LivroCriacaoDTO
    {
        public string Titulo { get; set; }
        public AutorVinculoDTO Autor { get; set; }
    }
}
