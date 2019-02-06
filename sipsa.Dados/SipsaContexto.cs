using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace sipsa.Dados {
    public class SipsaContexto : DynamoDBContext {
        public SipsaContexto (IAmazonDynamoDB client) : base (client) {

        }
    }
}