using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace server;

[McpServerToolType]
public sealed class Tools
{

    public Tools()
    {
     
    }

    [McpServerTool, Description("Add two numbers together.")]
    public async Task<string> AddNumbers(
        [Description("The first number")] int a,
        [Description("The second number")] int b)
    {
        return (a + b).ToString();
    }

}