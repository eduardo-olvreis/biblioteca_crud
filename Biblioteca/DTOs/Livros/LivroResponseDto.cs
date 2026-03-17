namespace Biblioteca.DTOs.Livros
{
    public class LivroResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public int Edicao { get; set; }
        public int NumeroPaginas {  get; set; }
        public string NomeAutor {  get; set; }
    }
}
