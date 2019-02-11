using System;
using System.Collections.Generic;
using FluentValidation;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Membros {
    public class Membro : Entidade {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Naturalidade { get; private set; }
        public string EstadoCivil { get; private set; }
        public string Escolaridade { get; private set; }
        public string Profissao { get; private set; }
        public string Titulo { get; private set; }
        public string Igreja { get; private set; }
    }
}