using System.ComponentModel.DataAnnotations;

namespace sipsa.Web.Models {
    public class UsuarioModel {
        public string Id { get; set; }

        [Required (ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Email obrigatório")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Permissão obrigatória")]
        [Display (Name = "Permissão")]
        public string Permissao { get; set; }
    }
}