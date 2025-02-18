using API_Book.DTO.Autor;

namespace API_Book.Model
{
    public interface IAutorRepository
    {
        Task<RespondeModel<List<Autor>>> ListarAutores();
        Task<RespondeModel<Autor>> BuscarAutor(int idAutor);
        Task<RespondeModel<Autor>> BuscarAutorIdLivro(int idLivro);
        Task<RespondeModel<List<Autor>>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO);  
    }
}
