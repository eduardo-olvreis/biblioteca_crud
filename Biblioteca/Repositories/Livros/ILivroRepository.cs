using Biblioteca.Models;

namespace Biblioteca.Repositories.Livros
{
    public interface ILivroRepository
    {
        Task<Livro> ObterPorId(int id);
        Task<List<Livro>> ObterTodos();
        Task<Livro> CriarLivro(Livro livro);
        Task<Livro> AtualizarLivro(Livro livro);
        Task<bool> DeletarLivro(int id);
    }
}
