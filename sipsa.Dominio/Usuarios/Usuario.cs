using System;
using System.ComponentModel;
using System.Linq;
using Amazon.DynamoDBv2.DataModel;
using FluentValidation;
using FluentValidation.Results;
using sipsa.Dominio._Base;
using sipsa.Dominio._Util;

namespace sipsa.Dominio.Usuarios {
    public class Usuario : Entidade {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Permissao { get; private set; }

        public Usuario (string nome, string email, string senha, string permissao) {
            PreencherUsuario (nome, email, senha, permissao);

            var usuarioValidacao = new UsuarioValidacao ();
            usuarioValidacao.InserirRegras ();
            usuarioValidacao.InserirRegrasSenha ();
            usuarioValidacao.Validar (this);
        }

        public Usuario () { }

        public void Alterar (string nome, string email, string permissao) {
            PreencherUsuario (nome, email, Senha, permissao);

            var usuarioValidacao = new UsuarioValidacao ();
            usuarioValidacao.InserirRegras ();
            usuarioValidacao.Validar (this);
        }

        public void CriptografarSenha (string senha) {
            Senha = Password.EncryptString (senha, Environment.GetEnvironmentVariable ("KeyPassword"));
        }

        private void PreencherUsuario (string nome, string email, string senha, string permissao) {
            Nome = nome;
            Email = email;
            Senha = senha;
            Permissao = permissao;
        }
    }
}