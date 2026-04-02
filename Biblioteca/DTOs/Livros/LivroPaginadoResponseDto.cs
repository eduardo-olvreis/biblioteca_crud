namespace Biblioteca.DTOs.Livros
{
    public class LivroPaginadoResponseDto
    {
        public int TotalRegistros { get; set; }
        public List<LivroResponseDto> Livros { get; set; }
    }
}
