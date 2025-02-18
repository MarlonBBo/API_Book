using API_Book.DTO.Autor;
using API_Book.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Book.Infra
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ConnectionContext _connectionContext;

        public AutorRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public async Task<RespondeModel<List<Autor>>> ListarAutores()
        {
            RespondeModel<List<Autor>> resposta = new RespondeModel<List<Autor>>();
            try
            {
                var autores = await _connectionContext.Autores.ToListAsync();
                resposta.Data = autores;
                resposta.Message = "Deu tudo certo!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                return resposta;
            }
        }

        public async Task<RespondeModel<Autor>> BuscarAutor(int idAutor)
        {
            RespondeModel<Autor> resposta = new RespondeModel<Autor>();

            try
            {
                var autor = await _connectionContext.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Message = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Data = autor;
                resposta.Message = "Deu tudo certo!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                return resposta;
            }
        }

        public async Task<RespondeModel<Autor>> BuscarAutorIdLivro(int idLivro)
        {
            RespondeModel<Autor> resposta = new RespondeModel<Autor>();

            try
            {
                var livro = await _connectionContext.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Message = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Data = livro.Autor;
                resposta.Message = "Deu tudo certo!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                return resposta;
            }
        }

        public async Task<RespondeModel<List<Autor>>> CriarAutor(AutorCriacaoDTO autorCriacaoDTO)
        {
            RespondeModel<List<Autor>> resposta = new RespondeModel<List<Autor>>();

            try
            {
                var autor = new Autor()
                {
                    Name = autorCriacaoDTO.Name
                };
                _connectionContext.Add(autor);
                await _connectionContext.SaveChangesAsync();

                resposta.Data = await _connectionContext.Autores.ToListAsync();
                resposta.Message = "Tudo ok";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                return resposta;
            }
        }
    }
}

