using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sipsa.Web.Models {
    public class MembroModel {
        public string Id { get; set; }

        public string Nome { get; set; }

        [Display (Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
        
        public string Naturalidade { get; set; }

        [Display (Name = "Estado civil")]
        public string EstadoCivil { get; set; }

        public string Escolaridade { get; set; }

        [Display (Name = "Profissão")]
        public string Profissao { get; set; }
        public string Titulo { get; set; }
        public string Igreja { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\([0-9]{2}\))\s([9]{1})?([0-9]{4})-([0-9]{4})$", ErrorMessage = "Formato do telefone inválido")]
        public string Telefone { get; set; }
        public List<string> Telefones { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }

        [Display (Name = "Data de admissão")]
        [DataType(DataType.Date)]
        public DateTime? DataAdmissao { get; set; }
        
        public int? Ata { get; set; }
        
        [Display (Name = "Recepção")]
        public string Recepcao { get; set; }
    }
}