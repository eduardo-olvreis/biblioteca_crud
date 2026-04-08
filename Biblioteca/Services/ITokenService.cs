using Biblioteca.Models;

namespace Biblioteca.Services
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}
