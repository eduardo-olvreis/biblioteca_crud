using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories.Livros
{
    public class SqlLivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;
        public SqlLivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Livro?> ObterPorIdAsync(int id)
        {
            return await _context.Livros.AsNoTracking().Include(a => a.Autor).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Livro>> ObterTodosAsync(string? titulo, int? autorId)
        {
            var query = _context.Livros.AsNoTracking().Include(l => l.Autor).AsQueryable();
            if(!string.IsNullOrWhiteSpace(titulo))
            {
                query = query.Where(l => l.Titulo.Contains(titulo));
            }
            if(autorId != null)
            {
                query = query.Where(l => l.AutorId == autorId);
            }
            return await query.ToListAsync();
        }

        public async Task<Livro> CriarLivroAsync(Livro livro)
        {
            _context.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task<Livro> AtualizarLivroAsync(Livro livro)
        {
            if (await ObterPorIdAsync(livro.Id) == null) return null;
            _context.Update(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task<bool> DeletarLivroAsync(int id)
        {
            Livro livro = await ObterPorIdAsync(id);
            if (livro == null) return false;
            _context.Remove(livro);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
