using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories.Livros
{
    public class SqlLivroRepository
    {
        private readonly AppDbContext _context;
        public SqlLivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Livro> ObterPorId(int id)
        {
            return await _context.Livros.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        }

        
    }
}
