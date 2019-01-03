using System;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace sipsa.DynamoDB
{
    public static class DynamoDBService
    {
        public static void AddDynamoDB(this IServiceCollection services, IConfiguration configuration)
        {
            var credentials = new BasicAWSCredentials(Environment.GetEnvironmentVariable("AWSDynamoDB_AccessKey"), Environment.GetEnvironmentVariable("AWSDynamoDB_SecretKey"));
            var client = new AmazonDynamoDBClient(credentials, RegionEndpoint.SAEast1);
            var context = new DynamoDBContext(client);
            services.AddSingleton(context);
        }
    }
}
