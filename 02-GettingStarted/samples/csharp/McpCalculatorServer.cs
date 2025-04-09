using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

namespace McpCalculatorSample
{
    /// <summary>
    /// Sample MCP Calculator Server implementation in C#.
    /// 
    /// This class demonstrates how to create a simple MCP server with calculator tools
    /// that can perform basic arithmetic operations (add, subtract, multiply, divide).
    /// </summary>
    public class McpCalculatorServer
    {
        public static async Task Main(string[] args)
        {
            // Create an MCP server
            var server = new McpServer(
                name: "Calculator MCP Server",
                version: "1.0.0"
            );
            
            // Define calculator tools for each operation
            server.AddTool<double, double, double>("add", 
                description: "Add two numbers together",
                execute: (a, b) => Task.FromResult(a + b));
                
            server.AddTool<double, double, double>("subtract", 
                description: "Subtract b from a",
                execute: (a, b) => Task.FromResult(a - b));
                
            server.AddTool<double, double, double>("multiply", 
                description: "Multiply two numbers together",
                execute: (a, b) => Task.FromResult(a * b));
                
            server.AddTool<double, double, double>("divide", 
                description: "Divide a by b",
                execute: (a, b) => 
                {
                    if (b == 0)
                    {
                        throw new ArgumentException("Cannot divide by zero");
                    }
                    return Task.FromResult(a / b);
                });
            
            // Connect the server using stdio transport
            var transport = new StdioServerTransport();
            await server.ConnectAsync(transport);
            
            Console.WriteLine("Calculator MCP Server started");
            
            // Keep the server running until process is terminated
            await Task.Delay(-1);
        }
    }
}
