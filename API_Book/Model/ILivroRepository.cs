using API_Book.DTO.LivroDTO;

namespace API_Book.Model
{
    public interface ILivroRepository
    {
        Task<RespondeModel<List<Livro>>> ListaDeLivros();
        Task<RespondeModel<Livro>> BuscarLivro(int id);
        Task<RespondeModel<List<Livro>>> BuscarLivroIdAutor(int idAutor);
        Task<RespondeModel<List<Livro>>> CriarLivro(LivroCriacaoDTO livroCriacaoDTO);
        Task<RespondeModel<List<Livro>>> EditarLivro(LivroEdicaoDTO livroEdicaoDTO);
        Task<RespondeModel<List<Livro>>> ExcluirLivro(int idLivro);

    }
}
