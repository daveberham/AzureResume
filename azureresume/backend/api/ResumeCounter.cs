using System.Text.Json.Serialization;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class ResumeCounter
    {
      [Function("ResumeCounter")]
        [CosmosDBOutput("DatebaseName", "CollectionName", ConnectionStringSetting = "CosmosDBConnectionString")]
        public static Object Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
        [CosmosDBInput("DatebaseName", "CollectionName", ConnectionStringSetting = "CosmosDBConnectionString", Id ="1", PartitionKey = "1")] CounterJson counter,
           FunctionContext executionContext)
        {
            counter.count++; 
             return counter;
        }
    }

  
    public class CounterJson
    {
        public CounterJson(string id)
        {
            Id = id;
        }

        [JsonPropertyName("id")]
     public string Id {get;set;}

      [JsonPropertyName ("count")]
     public int count {get;set;}

    }
}