using System.ComponentModel.DataAnnotations;

namespace sipsa.Dominio.Usuarios
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Required"), EmailAddress(ErrorMessage = "EmailAddress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required"), DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
