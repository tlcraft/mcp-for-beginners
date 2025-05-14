using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var endpoint = "https://models.inference.ai.azure.com";
var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN"); // Your GitHub Access Token
var client = new ChatCompletionsClient(new Uri(endpoint), new AzureKeyCredential(token));
var chatHistory = new List<ChatRequestMessage>
{
    new ChatRequestSystemMessage("You are a helpful assistant that knows about AI")
};

ChatCompletionsToolDefinition CreateToolDefinition()
{
    // define tools
    FunctionDefinition addFunction = new FunctionDefinition("add")
    {
        Description = "adds two numbers",
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = new
            {
                a = new
                {
                    Type = "integer",
                    Description = "the first number to add"
                },
                b = new
                {
                    Type = "integer",
                    Description = "the second number to add"
                }
            }
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    ChatCompletionsToolDefinition def = new ChatCompletionsToolDefinition(addFunction);
    return def;
}

async Task<List<string>> GetMcpTools()
{
    var clientTransport = new StdioClientTransport(new()
    {
        Name = "Demo Server",
        Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
        Arguments = [],
    });

    Console.WriteLine("Setting up stdio transport");

    await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);

    Console.WriteLine("Listing tools");
    var tools = await mcpClient.ListToolsAsync();

    List<string> toolNames = new List<string>();

    foreach (var tool in tools)
    {
        toolNames.Add(tool.Name);
        Console.WriteLine($"Connected to server with tools: {tool.Name}");
        Console.WriteLine($"Tool description: {tool.Description}");
        Console.WriteLine($"Tool parameters: {tool.InputSchema}");
    }

    // call mcp server
    // convert each tool to a function definition
    return toolNames;

}

// -1. List tools on mcp server

var tools = await GetMcpTools();
for (int i = 0; i < tools.Count; i++)
{
    var tool = tools[i];
    Console.WriteLine($"Tool {i}: {tool}");
}

// 0. Define the chat history and the user message
var userMessage = "add 2 and 4";

chatHistory.Add(new ChatRequestUserMessage(userMessage));

// 1. Define tools
ChatCompletionsToolDefinition def = CreateToolDefinition();


// 2. Define options, including the tools
var options = new ChatCompletionsOptions(chatHistory)
{
    Model = "gpt-4o-mini",
    Tools = { def }
};

// 3. Call the model  

ChatCompletions? response = await client.CompleteAsync(options);
var content = response.Content;

// 4. Check if the response contains a function call
ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
for (int i = 0; i < response.ToolCalls.Count; i++)
{
    var call = response.ToolCalls[i];
    Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
    //it works!!, Tool call 0: add with arguments {"a":2,"b":4}
}

// 5. Print the generic response
Console.WriteLine($"Assistant response: {content}");
// Console.WriteLine($"Function call: {functionCall?.Name}");

// check if tool call, if so, call the tool



// TODO:
//   get a function call to work on the llm - CHECK
//   list tools on mcp server
//   convert tool call to a tool on llm
//   do user prompt
//   verify if it was a function call
//   call the right tool on the mcp server