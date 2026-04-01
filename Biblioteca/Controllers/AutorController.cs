using Biblioteca.DTOs.Autores;
using Biblioteca.DTOs.Livros;
using Biblioteca.Models;
using Biblioteca.Repositories.Autores;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _repositorio;
        public AutorController(IAutorRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorResponseDto>> ObterPorIdAsync(int id)
        {
            var autor = await _repositorio.ObterPorIdAsync(id);
            if (autor == null) return NotFound("Autor não encontrado.");
            var response = new AutorResponseDto
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Idade = autor.Idade,
                Nacionalidade = autor.Nacionalidade,
                Livros = autor.Livros.Select(l => new LivroResumoDto
                {
                    Id = l.Id,
                    Titulo = l.Titulo
                }).ToList()
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorResponseDto>>> ObterTodosAsync()
        {
            var autores = await _repositorio.ObterTodosAsync();
            var response = autores.Select(a => new AutorResponseDto
            {
                Id = a.Id,
                Nome = a.Nome,
                Idade = a.Idade,
                Nacionalidade = a.Nacionalidade,
                Livros = a.Livros.Select(l => new LivroResumoDto
                {
                    Id = l.Id,
                    Titulo = l.Titulo
                }).ToList()
            }).ToList();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AutorResponseDto>> CriarAutorAsync(AutorCreateDto autorDto)
        {
            var autor = new Autor
            {
                Nome = autorDto.Nome,
                Idade = autorDto.Idade,
                Nacionalidade = autorDto.Nacionalidade
            };
            await _repositorio.CriarAutorAsync(autor);
            var response = new AutorResponseDto
            {
                Id = autor.Id,
                Nome = autor.Nome,
                Idade = autor.Idade,
                Nacionalidade = autor.Nacionalidade,
                Livros = autor.Livros.Select(l => new LivroResumoDto
                {
                    Id = l.Id,
                    Titulo = l.Titulo
                }).ToList()
            };
            return CreatedAtAction(nameof(ObterPorIdAsync), new { id = response.Id, }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AutorResponseDto>> AtualizarAutorAsync(int id, [FromBody] AutorCreateDto autorDto)
        {
            var autorEncontrado = await _repositorio.ObterPorIdAsync(id);
            if(autorEncontrado == null) { return NotFound("Autor não encontrado."); }
            autorEncontrado.Nome = autorDto.Nome;
            autorEncontrado.Idade = autorDto.Idade;
            autorEncontrado.Nacionalidade = autorDto.Nacionalidade;
            await _repositorio.AtualizarAutorAsync(autorEncontrado);
            var response = new AutorResponseDto
            {
                Id = autorEncontrado.Id,
                Nome = autorEncontrado.Nome,
                Idade = autorEncontrado.Idade,
                Nacionalidade = autorEncontrado.Nacionalidade,
                Livros = autorEncontrado.Livros.Select(l => new LivroResumoDto
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                }).ToList()
            };
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarAutorAsync(int id)
        {
            var autor = await _repositorio.DeletarAutorAsync(id);
            if (autor == false) return NotFound("Autor não encontrado.");
            return NoContent();
        }
    }
}
