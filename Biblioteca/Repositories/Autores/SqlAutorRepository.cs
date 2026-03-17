using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories.Autores
{
    public class SqlAutorRepository : IAutorRepository
    {
        private readonly AppDbContext _context;
        public SqlAutorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Autor?> ObterPorIdAsync(int id)
        {
            return await _context.Autores.AsNoTracking().Include(l => l.Livros).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Autor>> ObterTodosAsync()
        {
            return await _context.Autores.AsNoTracking().Include(l => l.Livros).ToListAsync();
        }

        public async Task<Autor> CriarAutorAsync(Autor autor)
        {
            _context.Add(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task<Autor> AtualizarAutorAsync(Autor autor)
        {
            if (await ObterPorIdAsync(autor.Id) == null) return null;
            _context.Update(autor);
            await _context.SaveChangesAsync();
            return autor;
        }

        public async Task<bool> DeletarAutorAsync(int id)
        {
            Autor autor = await ObterPorIdAsync(id);
            if (autor == null) return false;
            _context.Remove(autor);
            await _context.SaveChangesAsync();
            return true;
        } 
    }
}