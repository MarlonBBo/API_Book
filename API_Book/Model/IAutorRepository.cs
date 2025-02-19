using API_Book.DTO.AutorDTO;

namespace API_Book.Model
{
    public interface IAutorRepository
    {
        Task<RespondeModel<List<Autor>>> ListarAutores();
        Task<RespondeModel<Autor>> BuscarAutor(int idAutor);
        Task<RespondeModel<Autor>> BuscarAutorIdLivro(int idLivro);
        Task<RespondeModel<List<Autor>>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO);  
        Task<RespondeModel<List<Autor>>> EditarAutor(AutorEdicaoDTO autorEdicaoDTO);
        Task<RespondeModel<List<Autor>>> ExcluirAutor(int idAutor);
    }
}
