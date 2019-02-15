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
        public List<string> Telefones { get; private set; }

        public MembroEndereco Endereco { get; private set; }
        public MembroAdmissao Admissao { get; private set; }

        public Membro (MembroDto membroDto) {
            PreencherMembro (membroDto);

            var membroValidacao = new MembroValidacao ();
            membroValidacao.InserirRegras ();
            membroValidacao.Validar (this);
        }

        public Membro () { }

        public void Alterar(MembroDto membroDto)
        {
            PreencherMembro (membroDto);

            var membroValidacao = new MembroValidacao ();
            membroValidacao.InserirRegras ();
            membroValidacao.Validar (this);
        }

        private void PreencherMembro(MembroDto membroDto)
        {
            Nome = membroDto.Nome;
            DataNascimento = membroDto.DataNascimento;
            Naturalidade = membroDto.Naturalidade;
            EstadoCivil = membroDto.EstadoCivil;
            Escolaridade = membroDto.Escolaridade;
            Profissao = membroDto.Profissao;
            Titulo = membroDto.Titulo;
            Igreja = membroDto.Igreja;
            Telefones = membroDto.Telefones;
            Endereco = new MembroEndereco(membroDto.Logradouro, membroDto.Bairro, membroDto.Cep);
            Admissao = new MembroAdmissao(membroDto.Data, membroDto.Ata, membroDto.Recepcao);
        }
    }
}