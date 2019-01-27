using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace sipsa.Domain._Base
{
    public class DomainException : ArgumentException
    {
        public IList<ValidationFailure> Errors { get; set; }

        public DomainException(IList<ValidationFailure> errors)
        {
            Errors = errors;
        }
    }
}