using FluentValidation;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Membros {
    public class Telefone : Entidade {
        public string Numero { get; private set; }
        public Membro Membro { get; private set; }

        public Telefone (string numero, Membro membro) {
            Numero = numero;
            Membro = membro;

            //Regras();
            //Validar(this);
        }

        // private void Regras()
        // {
        //     RuleFor(t => t.Numero)
        //         .NotEmpty().WithMessage("Telefone está vazio.");
        // }
    }
}