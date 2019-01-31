using Amazon.DynamoDBv2.DataModel;
using FluentValidation;
using FluentValidation.Results;

namespace sipsa.Dominio._Base
{
    public class Entidade<T> : AbstractValidator<T>
    {
        [DynamoDBHashKey]
        public string Id { get; protected set; }

        protected void Validar(T dominio)
        {
            ValidationResult resultados = this.Validate(dominio);

            if (!resultados.IsValid)
                throw new DominioException(resultados.Errors);
        }
    }
}