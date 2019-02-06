using Amazon.DynamoDBv2.DataModel;

namespace sipsa.Dominio._Base
{
    public class Entidade
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
    }
}