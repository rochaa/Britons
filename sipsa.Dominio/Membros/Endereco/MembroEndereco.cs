using System;

namespace sipsa.Dominio.Membros {
    public class MembroEndereco {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }

        public MembroEndereco (string logradouro, string bairro, string cep) {

            PreencherMembroEndereco (logradouro, bairro, cep);

            var membroEnderecoValidacao = new MembroEnderecoValidacao ();
            membroEnderecoValidacao.InserirRegras ();
            membroEnderecoValidacao.Validar (this);
        }

        public MembroEndereco () { }

        private void PreencherMembroEndereco (string logradouro, string bairro, string cep) {
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
        }
    }
}