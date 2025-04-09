// McpCalculatorServer.cs - Sample MCP Calculator Server implementation in C#
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.SDK.Server;
using ModelContextProtocol.SDK.Server.Tools;
using ModelContextProtocol.SDK.Server.Content;
using ModelContextProtocol.SDK.Server.Transport;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuickstartCalculator
{
    public class Program
    {        public static async Task Main(string[] args)
        {
            // Create the host builder for the MCP server
            var builder = Host.CreateApplicationBuilder(args);

            // Configure the MCP server with tools
            builder.Services
                .AddMcpServer(options =>
                {
                    options.Name = "Calculator MCP Server";
                    options.Version = "1.0.0";
                    // Optional: Configure server options
                    options.ServerConfiguration = config => 
                    {
                        config.DefaultToolTimeout = TimeSpan.FromSeconds(30);
                    };
                })
                .AddStdioTransport()  // Add support for stdio transport
                .AddTool<CalculatorTool>();  // Register our calculator tool

            // Add logging to standard error for debugging
            builder.Logging.AddConsole(options =>
            {
                options.LogToStandardErrorThreshold = LogLevel.Information;
            });

            Console.WriteLine("Starting Calculator MCP Server...");

            // Run the application
            await builder.Build().RunAsync();
        }
    }    // Define calculator tool implementation
    public class CalculatorTool : ITool
    {
        private readonly ILogger<CalculatorTool> _logger;

        public CalculatorTool(ILogger<CalculatorTool> logger)
        {
            _logger = logger;
        }

        public string Name => "calculator";
        public string Description => "Performs basic arithmetic operations";

        public ToolDefinition GetDefinition()
        {
            return new ToolDefinition
            {
                Name = Name,
                Description = Description,
                Parameters = new Dictionary<string, ParameterDefinition>
                {
                    ["operation"] = new ParameterDefinition
                    {
                        Type = ParameterType.String,
                        Description = "The operation to perform",
                        Enum = new[] { "add", "subtract", "multiply", "divide" }
                    },
                    ["a"] = new ParameterDefinition
                    {
                        Type = ParameterType.Number,
                        Description = "First number"
                    },
                    ["b"] = new ParameterDefinition
                    {
                        Type = ParameterType.Number,
                        Description = "Second number"
                    }
                },
                Required = new[] { "operation", "a", "b" }
            };
        }

        public async Task<ToolResponse> ExecuteAsync(IDictionary<string, object> parameters)
        {
            var operation = parameters["operation"].ToString();
            var a = Convert.ToDouble(parameters["a"]);
            var b = Convert.ToDouble(parameters["b"]);
            
            _logger.LogInformation($"Calculating {a} {operation} {b}");
            
            double result;
            
            switch (operation)
            {
                case "add":
                    result = a + b;
                    break;
                case "subtract":
                    result = a - b;
                    break;
                case "multiply":
                    result = a * b;
                    break;
                case "divide":
                    if (b == 0)
                        throw new ArgumentException("Cannot divide by zero");
                    result = a / b;
                    break;
                default:
                    throw new ArgumentException($"Unknown operation: {operation}");
            }
            
            // Return result in standard MCP content format
            return new ToolResponse
            {
                Content = new ContentItem[]
                {
                    new TextContent($"{{\"result\": {result}}}")
                }
            };
        }
    }

    // Define calculator operations enum
    public enum CalculatorOperation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
}
