using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

namespace McpCalculatorSample;

/// <summary>
/// Sample MCP Calculator Server implementation in C#.
/// 
/// This class demonstrates how to create a simple MCP server with calculator tools
/// that can perform basic arithmetic operations (add, subtract, multiply, divide).
/// </summary>
[McpServerToolType]
public class McpCalculatorServer
{
    [McpServerTool, Description("Calculates the sum of two numbers")]
    public static async double Add(double numberA, double numberB)
    {
        return numberA + numberB;
    }

    [McpServerTool, Description("Calculates the difference of two numbers")]
    public static async double Subtract(double numberA, double numberB)
    {
        return numberA - numberB;
    }

    [McpServerTool, Description("Calculates the product of two numbers")]
    public static async double Multiply(double numberA, double numberB)
    {
        return numberA * numberB;
    }
    
    [McpServerTool, Description("Calculates the quotient of two numbers")]
    public static async double Divide(double numberA, double numberB)
    {
        if (numberB == 0)
        {
            throw new ArgumentException("Cannot divide by zero");
        }
        return numberA / numberB;
    }
}