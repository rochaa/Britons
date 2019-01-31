using System;
using System.ComponentModel;
using System.Linq;
using Amazon.DynamoDBv2.DataModel;
using FluentValidation;
using FluentValidation.Results;
using sipsa.Dominio._Base;

namespace sipsa.Dominio.Usuarios
{
    public class Usuario : Entidade<Usuario>
    {
        [DynamoDBProperty]
        public string Nome { get; private set; }

        [DynamoDBProperty]
        public string Email { get; private set; }

        [DynamoDBProperty]
        public string Senha { get; private set; }

        [DynamoDBProperty]
        public string Permissao { get; private set; }

        public Usuario(string nome, string email, string senha, string permissao)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Permissao = permissao;

            Regras();
            Validar(this);
        }

        public Usuario() { }

        private void Regras()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("Nome está vazio.")
                .Length(4, 60).WithMessage("Nome deve estar entre 4 e 60 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email está vazio.")
                .EmailAddress().WithMessage("Email com formato inválido");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("Senha vazia");

            RuleFor(u => u.Permissao)
                .NotEmpty().WithMessage("Permissão está vazia.")
                .Must(p => UsuarioPermissao.Permitidas.Contains(p)).WithMessage("Permissão não existente.");
        }
    }
}