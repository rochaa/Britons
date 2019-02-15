using System;
using FluentValidation;
using FluentValidation.Results;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Membros {
    public class MembroEnderecoValidacao : AbstractValidator<MembroEndereco> {
        public MembroEnderecoValidacao () { }

        public void InserirRegras () {
            RuleFor (e => e.Logradouro);

            RuleFor (e => e.Bairro);

            RuleFor (e => e.Cep)
                .Must (c => string.IsNullOrEmpty (c) || c.CepValido ()).WithMessage("Cep inválido");
        }

        public void Validar (MembroEndereco membroEndereco) {
            ValidationResult resultados = this.Validate (membroEndereco);

            if (!resultados.IsValid)
                throw new DominioExcecao (resultados.Errors);
        }
    }
}