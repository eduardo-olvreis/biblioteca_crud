using Biblioteca.DTOs.Livros;
using Biblioteca.Models;
using Biblioteca.Repositories.Autores;
using Biblioteca.Repositories.Livros;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _repositorio;
        private readonly IAutorRepository _autorRepository;
        public LivroController(ILivroRepository repositorio, IAutorRepository autorRepository)
        {
            _repositorio = repositorio;
            _autorRepository = autorRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroResponseDto>> ObterPorIdAsync(int id)
        {
            var livro = await _repositorio.ObterPorIdAsync(id);
            if (livro == null) return NotFound("Livro não encontrado.");
            var response = new LivroResponseDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Ano = livro.Ano,
                Edicao = livro.Edicao,
                NumeroPaginas = livro.NumeroPaginas,
                NomeAutor = livro.Autor?.Nome ?? "Autor não informado"
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroResponseDto>>> ObterTodosAsync([FromQuery] string? titulo, [FromQuery] int? autorId)
        {
            var livros = await _repositorio.ObterTodosAsync(titulo, autorId);
            var response = livros.Select(l => new LivroResponseDto
            {
                Id = l.Id,
                Titulo = l.Titulo,
                Ano = l.Ano,
                Edicao = l.Edicao,
                NumeroPaginas = l.NumeroPaginas,
                NomeAutor = l.Autor?.Nome ?? "Autor não informado"
            }).ToList();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<LivroResponseDto>> CriarLivroAsync(LivroCreateDto livroDto)
        {
            var livro = new Livro
            {
                Titulo = livroDto.Titulo,
                Ano = livroDto.Ano,
                Edicao = livroDto.Edicao,
                NumeroPaginas = livroDto.NumeroPaginas,
                AutorId = livroDto.AutorId,
            };
            var encontrouAutor = await _autorRepository.ObterPorIdAsync(livro.AutorId);
            if (encontrouAutor == null) return BadRequest("Autor não encontrado.");
            await _repositorio.CriarLivroAsync(livro);
            var response = new LivroResponseDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Ano = livro.Ano,
                Edicao = livro.Edicao,
                NumeroPaginas = livro.NumeroPaginas,
                NomeAutor = encontrouAutor.Nome
            };
            return CreatedAtAction(nameof(ObterPorIdAsync), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LivroResponseDto>> AtualizarLivroAsync(int id, [FromBody] LivroCreateDto livroDto)
        {
            var livroEncontrado = await _repositorio.ObterPorIdAsync(id);
            if (livroEncontrado == null) return NotFound("Nenhum livro encontrado.");
            livroEncontrado.Titulo = livroDto.Titulo;
            livroEncontrado.Ano = livroDto.Ano;
            livroEncontrado.Edicao = livroDto.Edicao;
            livroEncontrado.NumeroPaginas = livroDto.NumeroPaginas;
            livroEncontrado.AutorId = livroDto.AutorId;
            livroEncontrado.Autor = null;
            var autorEncontrado = await _autorRepository.ObterPorIdAsync(livroEncontrado.AutorId);
            if (autorEncontrado == null) return BadRequest("Autor informado não existe.");
            await _repositorio.AtualizarLivroAsync(livroEncontrado);
            var response = new LivroResponseDto
            {
                Id = livroEncontrado.Id,
                Titulo = livroEncontrado.Titulo,
                Ano = livroEncontrado.Ano,
                Edicao = livroEncontrado.Edicao,
                NumeroPaginas = livroEncontrado.NumeroPaginas,
                NomeAutor = autorEncontrado.Nome
            };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarLivroAsync(int id)
        {
            var livro = await _repositorio.DeletarLivroAsync(id);
            if (livro == false) return NotFound("Livro não encontrado.");
            return NoContent();
        }
    }
}
