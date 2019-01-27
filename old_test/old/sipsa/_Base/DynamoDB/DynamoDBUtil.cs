using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sipsa.DynamoDB
{
    public class DynamoDBUtil
    {
        public static async Task<T> GetFromId<T>(DynamoDBContext db, string id)
        {
            List<ScanCondition> conditions = new List<ScanCondition>
            {
                new ScanCondition("Id", ScanOperator.Equal, id)
            };
            var entity = await db.ScanAsync<T>(conditions).GetRemainingAsync();
            return entity.First();
        }
    }
}
