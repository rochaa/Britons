using System.ComponentModel.DataAnnotations;

namespace sipsa.Web.Models {
    public class UsuarioCriacaoModel {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [DataType (DataType.Password)]
        public string Senha { get; set; }

        [Compare ("Senha", ErrorMessage = "Senha diferente")]
        [DataType (DataType.Password)]
        [Display (Name = "Confirmação Senha")]
        public string ConfirmacaoSenha { get; set; }

        [Display (Name = "Permissão")]
        public string Permissao { get; set; }
    }
}