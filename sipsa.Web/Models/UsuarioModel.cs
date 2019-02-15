using System.ComponentModel.DataAnnotations;

namespace sipsa.Web.Models {
    public class UsuarioModel {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        [Display (Name = "Permissão")]
        public string Permissao { get; set; }
    }
}