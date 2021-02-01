using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Recruitment.Common;
using Recruitment.Common.Models;
using Recruitment.HashFunction.Services;

namespace Recruitment.HashFunction
{
    public static class HashFunction
    {
        [FunctionName("Hash")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function,  "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var data = JsonSerializer.Deserialize<LoginDataRequest>(requestBody);

            var hash = new Hash().GenerateHash(data);
            var response = new HashResponse {Hash = hash};

            log.LogInformation($"Generating hash {hash}");

            var d = JsonSerializer.Serialize(response);
            return new OkObjectResult(d);
        }
    }
}
