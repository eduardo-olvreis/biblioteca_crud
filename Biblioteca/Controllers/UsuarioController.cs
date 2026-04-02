using Biblioteca.DTOs.Usuarios;
using Biblioteca.Models;
using Biblioteca.Repositories.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repositorio;
        public UsuarioController(IUsuarioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDto>> CriarUsuarioAsync(UsuarioRegistroDto usuarioDto)
        {
            var usuarioJaExiste = await _repositorio.ObterPorEmailAsync(usuarioDto.Email);
            if (usuarioJaExiste != null) { return BadRequest("Email já cadastrado."); }
            var usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Senha)
            };
            await _repositorio.CriarUsuarioAsync(usuario);
            var response = new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
            return Ok(response);
        }
    }
}
