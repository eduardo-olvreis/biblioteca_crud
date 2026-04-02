using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo 'Nome' não pode ser vazio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo 'Email' não pode ser vazio")]
        [EmailAddress(ErrorMessage = "Formato de Email inválido")]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }
    }
}
