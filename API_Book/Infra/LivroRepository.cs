using API_Book.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Book.Infra
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ConnectionContext _connectionContext;
        public LivroRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public async Task<RespondeModel<Livro>> BuscarLivro(int id)
        {
            RespondeModel<Livro> responde = new RespondeModel<Livro>();

            try
            {
                var livro = await _connectionContext.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == id);

                if (livro == null)
                {
                    responde.Message = "Livro não encontrado";
                    return responde;
                }

                responde.Data = livro;
                return responde;
            }
            catch (Exception ex)
            {
                responde.Message = ex.Message;
                return responde;
            }
        }

        public async Task<RespondeModel<List<Livro>>> ListaDeLivros()
        {
            RespondeModel<List<Livro>> responde = new RespondeModel<List<Livro>>();

            try
            {
                var livro = await _connectionContext.Livros.ToListAsync();
                responde.Data = livro;
                responde.Message = "Deu certo!";
                return responde;
            }
            catch (Exception ex)
            {
                responde.Message = ex.Message;
                return responde;
            }
        }
    }
}
