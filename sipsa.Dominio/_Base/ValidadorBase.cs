using FluentValidation;
using FluentValidation.Results;

namespace sipsa.Dominio._Base
{
    public abstract class ValidadorBase<T> : AbstractValidator<T>
    {
        public int Id { get; set; }

        protected void Validar(T dominio)
        {
            ValidationResult resultados = this.Validate(dominio);

            if (!resultados.IsValid)
                throw new DominioException(resultados.Errors);
        }
    }
}