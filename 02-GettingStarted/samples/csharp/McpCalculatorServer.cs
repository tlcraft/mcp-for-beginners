// McpCalculatorServer.cs - Sample MCP Calculator Server implementation in C#
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mcp;
using Mcp.Server;
using Mcp.Server.Transport;
using System;
using System.Threading.Tasks;
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Create the host builder for the MCP server
            var builder = Host.CreateApplicationBuilder(args);

            // Configure the MCP server with tools
            builder.Services
                .AddMcpServer(options =>
                {
                    // Optional: Configure server options
                    options.DefaultFunctionOptionsBuilder = builder => builder.WithTimeout(TimeSpan.FromSeconds(30));
                })
                .WithStdioServerTransport()  // Add support for stdio transport (for use with language models)
                .WithHttpServerTransport(options =>  // Also add HTTP transport for direct API access
                {
                    options.Port = 5000;
                    options.Path = "/mcp";
                })
                .WithTools<CalculatorTools>();  // Register our calculator tools

            // Add logging to standard error for debugging
            builder.Logging.AddConsole(options =>
            {
                options.LogToStandardErrorThreshold = LogLevel.Trace;
            });

            Console.WriteLine("Starting MCP server...");
            Console.WriteLine("HTTP server available at http://localhost:5000/mcp");

            // Run the application
            await builder.Build().RunAsync();
        }
    }

    // Define calculator tools implementation
    public class CalculatorTools
    {
        private readonly ILogger<CalculatorTools> _logger;

        public CalculatorTools(ILogger<CalculatorTools> logger)
        {
            _logger = logger;
        }

        [McpTool("calculate", "Performs basic arithmetic operations")]
        public Task<CalculationResult> CalculateAsync(
            [McpParameter(Description = "The operation to perform (add, subtract, multiply, divide)")] string operation,
            [McpParameter(Description = "First number")] double a,
            [McpParameter(Description = "Second number")] double b)
        {
            _logger.LogInformation($"Calculating {a} {operation} {b}");
            
            double result = operation.ToLowerInvariant() switch
            {
                "add" => a + b,
                "subtract" => a - b,
                "multiply" => a * b,
                "divide" => b != 0 ? a / b : throw new ArgumentException("Cannot divide by zero"),
                _ => throw new ArgumentException($"Unknown operation: {operation}")
            };
            
            return Task.FromResult(new CalculationResult { Result = result });
        }
    }

    // Define result model
    public class CalculationResult
    {
        public double Result { get; set; }
    }
}
