using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sipsa.Web.Models {
    public class MembroModel {
        public string Id { get; set; }

        public string Nome { get; set; } // Foi

        [Display (Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; } // Foi
        
        public string Naturalidade { get; set; } // Foi

        [Display (Name = "Estado civil")]
        public string EstadoCivil { get; set; } // Foi

        public string Escolaridade { get; set; } // Foi

        [Display (Name = "Profissão")]
        public string Profissao { get; set; } // Foi
        public string Titulo { get; set; } // Foi
        public string Igreja { get; set; } // Foi
        public string Telefone { get; set; }
        public List<string> Telefones { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public int Ata { get; set; }
        public string Recepcao { get; set; }
    }
}