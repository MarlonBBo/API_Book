using API_Book.DTO.LivroDTO;
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
                var livro = await _connectionContext.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == id);

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

        public async Task<RespondeModel<List<Livro>>> BuscarLivroIdAutor(int idAutor)
        {
            RespondeModel<List<Livro>> responde = new RespondeModel<List<Livro>>();

            try
            {
                var livro = await _connectionContext.Livros
                    .Include(a => a.Autor)
                    .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                    .ToListAsync();

                if (livro == null)
                {
                    responde.Message = "Não tem livro com esse autor";
                    return responde;
                }

                responde.Data = livro;
                responde.Message = "Livro com autor encontrado";
                return responde;
            }
            catch (Exception ex)
            {
                responde.Message = ex.Message;
                return responde;
            }
        }

        public async Task<RespondeModel<List<Livro>>> CriarLivro(LivroCriacaoDTO livroCriacaoDTO)
        {
            RespondeModel<List<Livro>> responde = new RespondeModel<List<Livro>>();

            try
            {

                var autor = await _connectionContext.Autores.FirstOrDefaultAsync(a => a.Id == livroCriacaoDTO.Autor.Id);

                if (autor == null)
                {
                    responde.Message = "Nenhum regitro de autor encontrado";
                    return responde;
                }

                var livro = new Livro()
                {
                    Titulo = livroCriacaoDTO.Titulo,
                    Autor = autor,
                };

                _connectionContext.Add(livro);
                await _connectionContext.SaveChangesAsync();

                responde.Data = await _connectionContext.Livros.ToListAsync();
                responde.Message = "Livro criado!";
                return responde;

            }
            catch (Exception ex)
            {
                responde.Message = ex.Message;
                return responde;
            }
        }

        public async Task<RespondeModel<List<Livro>>> EditarLivro(LivroEdicaoDTO livroEdicaoDTO)
        {
            RespondeModel<List<Livro>> responde = new RespondeModel<List<Livro>>();

            try
            {
                var livro = await _connectionContext.Livros.FirstOrDefaultAsync(livro => livro.Id == livroEdicaoDTO.Id);

                if (livro == null)
                {
                    responde.Message = "Livro não encontrado";
                    return responde;
                }

                var novoLivro = new Livro()
                {
                    Titulo = livroEdicaoDTO.Titulo,
                    Autor = livroEdicaoDTO.Autor
                };

                _connectionContext.Add(novoLivro);
                await _connectionContext.SaveChangesAsync();

                responde.Data = await _connectionContext.Livros.ToListAsync();
                responde.Message = "Livro editado";
                return responde;

            }
            catch (Exception ex)
            {
                responde.Message = ex.Message;
                return responde;
            }
        }

        public async Task<RespondeModel<List<Livro>>> ExcluirLivro(int idLivro)
        {
            RespondeModel<List<Livro>> responde = new RespondeModel<List<Livro>>();

            try
            {
                var livro = await _connectionContext.Livros.FirstOrDefaultAsync(livro => livro.Id == idLivro);

                if (livro == null)
                {
                    responde.Message = "Livro não encontrado";
                    return responde;
                }

                _connectionContext.Remove(livro);
                await _connectionContext.SaveChangesAsync();

                responde.Data = await _connectionContext.Livros.ToListAsync();
                responde.Message = "Livro excluido com sucesso!";
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
                var livro = await _connectionContext.Livros.Include(a => a.Autor).ToListAsync();
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
