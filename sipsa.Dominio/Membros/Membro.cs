using System;
using System.Collections.Generic;
using FluentValidation;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Membros
{
    public class Membro : Entidade
    {
        public string Nome { get; private set; }
        public DateTime Nascimento { get; private set; }
        public string Endereco { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Naturalidade { get; private set; }
        public string EstadoCivil { get; private set; }
        public string Escolaridade { get; private set; }
        public string Profissao { get; private set; }
        public string Titulo { get; private set; }
        public DateTime Admissao { get; private set; }
        public int Ata { get; private set; }
        public string Recepcao { get; private set; }

        public virtual List<Telefone> Telefone { get; private set; }
    
        public Membro(string nome, DateTime nascimento, string endereco, string bairro, string cep,
            string naturalidade, string estadoCivil, string escolaridade, string profissao, string titulo,
            DateTime admissao, int ata, string recepcao)
        {
            Nome = nome;
            Nascimento = nascimento;
            Endereco = endereco;
            Bairro = bairro;
            Cep = cep;
            Naturalidade = naturalidade;
            EstadoCivil = estadoCivil;
            Escolaridade = escolaridade;
            Profissao = profissao;
            Titulo = titulo;
            Admissao = admissao;
            Ata = ata;
            Recepcao = recepcao;

            //Regras();
            //Validar(this);
        }

        // private void Regras()
        // {
        //     RuleFor(m => m.Nome)
        //         .NotEmpty().WithMessage("Nome está vazio.")
        //         .Length(4, 60).WithMessage("Nome deve estar entre 4 e 60 caracteres.");

        //     RuleFor(m => m.Nascimento)
        //         .NotNull().WithMessage("Data de Nascimento está vazia.")
        //         .Must(n => n > DateTime.Now).WithMessage("Data de Nascimento maior que a data atual. oO");

        //     RuleFor(m => m.Endereco);

        //     RuleFor(m => m.Bairro);

        //     RuleFor(m => m.Cep);

        //     RuleFor(m => m.Naturalidade);

        //     RuleFor(m => m.EstadoCivil);

        //     RuleFor(m => m.Escolaridade);

        //     RuleFor(m => m.Profissao);

        //     RuleFor(m => m.Titulo);

        //     RuleFor(m => m.Admissao);

        //     RuleFor(m => m.Ata);

        //     RuleFor(m => m.Recepcao);
        // }
    }
}