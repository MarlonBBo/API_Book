using API_Book.DTO.LivroDTO;
using API_Book.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_Book.Controllers
{
    [ApiController]
    [Route("/Livro")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _repository;

        public LivroController(ILivroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<RespondeModel<Livro>>>BuscarLivroPorId(int idLivro)
        {
            var livro = await _repository.BuscarLivro(idLivro);
            return Ok(livro);
        }

        [HttpGet("ListaDeLivros")]
        public async Task<ActionResult<RespondeModel<List<Livro>>>> ListaDeLivros()
        {
            var livro = await _repository.ListaDeLivros();
            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorAutor/{idAutor}")]
        public async Task<ActionResult<RespondeModel<List<Livro>>>> BuscarLivroPorAutor(int idAutor)
        {
            var livro = await _repository.BuscarLivroIdAutor(idAutor);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<RespondeModel<List<Livro>>>> CriarLivro(LivroCriacaoDTO livroCriacaoDTO)
        {
            var livro = await _repository.CriarLivro(livroCriacaoDTO);
            return Ok(livro);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<RespondeModel<List<Livro>>>> EditarLivro(LivroEdicaoDTO livroEdicaoDTO)
        {
            var livro = _repository.EditarLivro(livroEdicaoDTO);
            return Ok(livro);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<RespondeModel<List<Livro>>>> ExcluirLivro(int idLivro)
        {
            var livro = await _repository.ExcluirLivro(idLivro);
            return Ok(livro);
        }
    }
}
