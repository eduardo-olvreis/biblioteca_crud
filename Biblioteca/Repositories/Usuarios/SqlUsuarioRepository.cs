using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories.Usuarios
{
    public class SqlUsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public SqlUsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CriarUsuarioAsync(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            var usuarioEncontrado = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
            if(usuarioEncontrado == null) { return null; };
            return (usuarioEncontrado);
        }
    }
}
