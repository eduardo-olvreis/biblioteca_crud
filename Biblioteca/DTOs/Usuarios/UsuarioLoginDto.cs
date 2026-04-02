using System.ComponentModel.DataAnnotations;

namespace Biblioteca.DTOs.Usuarios
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "Campo 'Email' não pode ser vazio.")]
        [EmailAddress(ErrorMessage = "Formatação de Email inválida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo 'Senha' não pode ser vazio")]
        public string Senha { get; set; }
    }
}
