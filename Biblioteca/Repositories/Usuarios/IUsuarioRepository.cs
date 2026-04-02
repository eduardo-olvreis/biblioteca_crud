using Biblioteca.Models;

namespace Biblioteca.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CriarUsuarioAsync(Usuario usuario);
        Task<Usuario?> ObterPorEmailAsync(string email);
    }
}
