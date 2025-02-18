namespace API_Book.Model
{
    public interface ILivroRepository
    {
        Task<RespondeModel<List<Livro>>> ListaDeLivros();
        Task<RespondeModel<Livro>> BuscarLivro(int id);

    }
}
