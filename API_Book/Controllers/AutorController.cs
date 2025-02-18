using API_Book.DTO.Autor;
using API_Book.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_Book.Controllers
{
    [ApiController]
    [Route("/Autor")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _repository;

        public AutorController(IAutorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<RespondeModel<List<Autor>>>> ListarAutores()
        {
            var autores = await _repository.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutor/{idAutor}")]
        public async Task<ActionResult<RespondeModel<Autor>>> BuscarAutor(int idAutor)
        {
            var autor = await _repository.BuscarAutor(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorIdLivro/{idLivro}")]
        public async Task<ActionResult<RespondeModel<Autor>>> BuscarAutorIdLivro(int idLivro)
        {
            var autor = await _repository.BuscarAutor(idLivro);
            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<RespondeModel<Autor>>> CriarAutor(AutorCriacaoDTO autorCriacao)
        {
            var autores = await _repository.CriarAutor(autorCriacao);
            return Ok(autores);
        }


    }
}
