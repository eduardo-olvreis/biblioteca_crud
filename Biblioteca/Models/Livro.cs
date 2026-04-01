using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo 'Título' não pode ser vazio.")]
        [StringLength(50)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo 'Ano de Lançamento' não pode ser vazio e negativo")]
        [Range(1, 2100)]
        [Display(Name = "Ano de Lançamento")]
        public int Ano {  get; set; }
            
        [Required(ErrorMessage = "Campo 'Edição' não pode ser vazio e menor que 1")]
        [Range(1, int.MaxValue)]
        [Display(Name = "Edição")]
        public int Edicao { get; set; }
        
        [Required(ErrorMessage = "Campo 'Número de Páginas' não pode ser vazio e menor que 1")]
        [Range(1, int.MaxValue)]
        [Display(Name = "Número de Páginas")]
        public int NumeroPaginas { get; set; }

        [ForeignKey("Autor")]
        public int AutorId { get; set; }

        public virtual Autor Autor {  get; set; }
    }
}
