using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace sipsa.Dominio._Base {
    public class DominioExcecao : ArgumentException {
        public IList<ValidationFailure> Erros { get; set; }

        public DominioExcecao (IList<ValidationFailure> erros) {
            Erros = erros;
        }

        public DominioExcecao (string propriedade, string erro) {
            Erros = new List<ValidationFailure> ();
            Erros.Add (new ValidationFailure (propriedade, erro));
        }
    }
}