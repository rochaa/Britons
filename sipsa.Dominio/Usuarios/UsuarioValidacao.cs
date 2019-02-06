using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Usuarios {
    public class UsuarioValidacao : AbstractValidator<Usuario> {
        public UsuarioValidacao () { }

        public void InserirRegras () {
            RuleFor (u => u.Nome)
                .NotEmpty ().WithMessage ("Nome está vazio.")
                .Length (4, 60).WithMessage ("Nome deve ter entre 4 e 60 caracteres.");

            RuleFor (u => u.Email)
                .NotEmpty ().WithMessage ("Email está vazio.")
                .EmailAddress ().WithMessage ("Email com formato inválido");

            RuleFor (u => u.Permissao)
                .NotEmpty ().WithMessage ("Permissão está vazia.")
                .Must (p => UsuarioPermissao.Permitidas.Contains (p)).WithMessage ("Permissão não existente.");
        }

        public void InserirRegrasSenha () {
            RuleFor (u => u.Senha)
                .NotEmpty ().WithMessage ("Senha vazia")
                .Length (4, 15).WithMessage ("Senha deve ter entre 4 e 15 caracteres.");
        }

        public void Validar (Usuario usuario) {
            ValidationResult resultados = this.Validate (usuario);

            if (!resultados.IsValid)
                throw new DominioExcecao (resultados.Errors);
        }
    }
}