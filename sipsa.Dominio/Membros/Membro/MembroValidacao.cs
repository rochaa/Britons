using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Membros {
    public class MembroValidacao : AbstractValidator<Membro> {
        public MembroValidacao () { }

        public void InserirRegras () {
            RuleFor (m => m.Nome)
                .NotEmpty ().WithMessage ("Nome está vazio.")
                .Length (4, 60).WithMessage ("Nome deve ter entre 4 e 60 caracteres.");

            RuleFor (m => m.DataNascimento)
                .NotEmpty ().WithMessage ("Data de nascimento está vazia")
                .Must (d => d <= DateTime.Now).WithMessage ("Data de nascimento maior que a data atual");

            RuleFor (m => m.Naturalidade);

            RuleFor (m => m.EstadoCivil)
                .Must (e => string.IsNullOrEmpty (e) || MembroEstadoCivil.Permitidas.Contains (e)).WithMessage ("Estado cívil inválido.");

            RuleFor (m => m.Escolaridade)
                .Must (e => string.IsNullOrEmpty (e) || MembroEscolaridade.Permitidas.Contains (e)).WithMessage ("Escolaridade inválida.");

            RuleFor (m => m.Profissao);

            RuleFor (m => m.Titulo)
                .Must (u => string.IsNullOrEmpty (u) || MembroTitulo.Permitidas.Contains (u)).WithMessage ("Titulo inválido.");

            RuleFor (m => m.Igreja)
                .Must (i => string.IsNullOrEmpty (i) || MembroIgreja.Permitidas.Contains (i)).WithMessage ("Igreja inválida.");

            RuleFor (m => m.Telefones)
                .Must (t => !t.Any(e => !e.TelefoneValido())).WithMessage ("Possui telefone inválido.");
        }

        public void Validar (Membro membro) {
            ValidationResult resultados = this.Validate (membro);

            if (!resultados.IsValid)
                throw new DominioExcecao (resultados.Errors);
        }
    }
}