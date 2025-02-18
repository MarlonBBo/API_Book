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
    }
}
