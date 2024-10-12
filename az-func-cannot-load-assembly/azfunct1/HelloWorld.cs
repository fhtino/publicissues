using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            await Task.CompletedTask;
            string responseMessage = $"Hello world! - {DateTime.UtcNow.ToString("O")}";
            return new OkObjectResult(responseMessage);
        }
    }
}
