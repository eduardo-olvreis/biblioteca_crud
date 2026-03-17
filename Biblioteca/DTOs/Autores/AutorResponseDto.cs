using Biblioteca.DTOs.Livros;
using Biblioteca.Models;

namespace Biblioteca.DTOs.Autores
{
    public class AutorResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade {  get; set; }
        public string Nacionalidade {  get; set; }
        public List<LivroResumoDto> Livros {  get; set; }
    }
}
