using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sipsa.Models
{
    [DynamoDBTable("Usuarios")]
    public class Usuario
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBProperty, Required(ErrorMessage = "Required"), StringLength(100, MinimumLength = 3, ErrorMessage = "StringLength")]
        public string Nome { get; set; }

        [DynamoDBProperty, Required(ErrorMessage = "Required"), EmailAddress(ErrorMessage = "EmailAddress")]
        public string Email { get; set; }

        [DynamoDBProperty, Required(ErrorMessage = "Required"), DataType(DataType.Password), StringLength(50, MinimumLength = 6, ErrorMessage = "StringLength")]
        public string Senha { get; set; }

        [DynamoDBProperty, Display(Name = "Permissões")]
        public List<string> Permissoes { get; set; }
    }
}
