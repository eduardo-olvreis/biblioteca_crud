using System.ComponentModel.DataAnnotations;

namespace Biblioteca.DTOs.Usuarios
{
    public class UsuarioRegistroDto
    {
        [Required(ErrorMessage = "Campo 'Nome' não pode ser vazio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo 'Email' não pode ser vazio")]
        [EmailAddress(ErrorMessage = "Formato de Email inválido")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Senha { get; set; }
    }
}
