using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace sipsa.Dominio._Base
{
    public class DominioException : ArgumentException
    {
        public IList<ValidationFailure> Erros { get; set; }

        public DominioException(IList<ValidationFailure> erros)
        {
            Erros = erros;
        }

        public DominioException(string propriedade, string erro)
        {
            Erros = new List<ValidationFailure>();
            Erros.Add(new ValidationFailure(propriedade, erro));
        }
    }
}