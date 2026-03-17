using Biblioteca.Models;

namespace Biblioteca.Repositories.Autores
{
    public interface IAutorRepository
    {
        Task<Autor ?> ObterPorIdAsync(int id);
        Task<List<Autor>> ObterTodosAsync();
        Task<Autor> CriarAutorAsync(Autor autor);
        Task<Autor> AtualizarAutorAsync(Autor autor);
        Task<bool> DeletarAutorAsync(int id);
    }
}
