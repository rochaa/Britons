using System;

namespace sipsa.Dominio.Membros {
    public class MembroAdmissao {
        public DateTime? Data { get; private set; }
        public int? Ata { get; private set; }
        public string Recepcao { get; private set; }

        public MembroAdmissao (DateTime? data, int? ata, string recepcao) {
            PreencherMembroAdmissao (data, ata, recepcao);

            var membroAdmissaoValidacao = new MembroAdmissaoValidacao ();
            membroAdmissaoValidacao.InserirRegras ();
            membroAdmissaoValidacao.Validar (this);
        }

        public MembroAdmissao () { }

        private void PreencherMembroAdmissao(DateTime? data, int? ata, string recepcao)
        {
            Data = data;
            Ata = ata;
            Recepcao = recepcao;
        }
    }
}