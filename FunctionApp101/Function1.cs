using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp101
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Read query parameters
            // Read query parameters with null checks
            string name = req.Query["name"].ToString() ?? "Guest";
            string msg = req.Query["msg"].ToString() ?? "Good Day !";


            // Create the response message
            string responseMessage = $"Hello, {name}. Your message is: {msg}";
            _logger.LogInformation(responseMessage);

            return new OkObjectResult(responseMessage);
        }
    }
}
