using Biblioteca.Models;

namespace Biblioteca.Repositories.Livros
{
    public interface ILivroRepository
    {
        Task<Livro?> ObterPorIdAsync(int id);
        Task<List<Livro>> ObterTodosAsync(string? titulo, int? autorId, int? ano, int pagina, int quantidade);
        Task<Livro> CriarLivroAsync(Livro livro);
        Task<Livro> AtualizarLivroAsync(Livro livro);
        Task<bool> DeletarLivroAsync(int id);
    }
}
