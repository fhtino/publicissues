using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Data.Tables;

namespace azfunct1
{
    public static class HelloWorld
    {
        [FunctionName("helloworld")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Hello world");            

            string responseMessage = $"Hello world! - {DateTime.UtcNow.ToString("O")}";

            try
            {
                var tsc = new TableServiceClient("UseDevelopmentStorage=true");
                var tabc = tsc.GetTableClient("zzztest1");
                await tabc.CreateIfNotExistsAsync();
            }
            catch (Exception ex)
            {
                responseMessage = $"ERROR: {ex.ToString()}";
            }
            
            return new OkObjectResult(responseMessage);
        }
    }
}
