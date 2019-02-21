using System;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Membros {
    public class MembroAdmissaoValidacao : AbstractValidator<MembroAdmissao> {
        public MembroAdmissaoValidacao () { }

        public void InserirRegras () {
            RuleFor (a => a.Data)
                .Must (d => d == null || d <= DateTime.Now).WithMessage ("Data de admissão maior que a data atual");

            RuleFor (a => a.Ata);

            RuleFor (a => a.Recepcao)
                .Must (r => string.IsNullOrEmpty (r) || MembroAdmissaoRecepcao.Permitidas.Contains (r)).WithMessage ("Recepção inválida.");
        }

        public void Validar (MembroAdmissao membroAdmissao) {
            ValidationResult resultados = this.Validate (membroAdmissao);

            if (!resultados.IsValid)
                throw new DominioExcecao (resultados.Errors);
        }
    }
}