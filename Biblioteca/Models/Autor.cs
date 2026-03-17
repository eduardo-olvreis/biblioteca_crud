using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Autor
    {
        public Autor()
        {
            Livros = new List<Livro>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo 'Nome' não pode ser vazio.")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo 'Idade' não pode ser vazio e menor que 1")]
        [Range(1, 150)]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Campo 'Nacionalidade' não pode ser vazio.")]
        [StringLength (50)]
        public string Nacionalidade { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}
