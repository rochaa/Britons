using System.ComponentModel.DataAnnotations;

namespace sipsa.Web.Models {
    public class UsuarioCriacaoModel {
        public string Id { get; set; }

        [Required (ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Email obrigatório")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Senha obrigatória")]
        [DataType (DataType.Password)]
        public string Senha { get; set; }

        [Compare ("Senha", ErrorMessage = "Senha diferente")]
        [DataType (DataType.Password)]
        [Display (Name = "Confirmação Senha")]
        public string ConfirmacaoSenha { get; set; }

        [Required (ErrorMessage = "Permissão obrigatória")]
        [Display (Name = "Permissão")]
        public string Permissao { get; set; }
    }
}