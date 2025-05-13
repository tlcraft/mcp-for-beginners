using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;

var endpoint = "https://models.inference.ai.azure.com";
var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN"); // Your GitHub Access Token
var client = new ChatCompletionsClient(new Uri(endpoint), new AzureKeyCredential(token));
var chatHistory = new List<ChatRequestMessage>
{
    new ChatRequestSystemMessage("You are a helpful assistant that knows about AI")
};

while (true)
{
    Console.Write("You: ");
    var userMessage = Console.ReadLine();

    // Exit loop
    if (userMessage.StartsWith("/q"))
    {
        break;
    }

    chatHistory.Add(new ChatRequestUserMessage(userMessage));

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

    /*
    tool choice requires --enable-auto-tool-choice and --tool-call-parser to be set","type"
    */

    // define options
    var options = new ChatCompletionsOptions(chatHistory)
    {
        Model = "gpt-4o-mini",
        Tools = { def }
    };

    // call the model  

    ChatCompletions? response = await client.CompleteAsync(options);
    var content = response.Content;


    ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
    for (int i = 0; i < response.ToolCalls.Count; i++)
    {
        var call = response.ToolCalls[i];
        Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
        //it works!!, Tool call 0: add with arguments {"a":2,"b":4}
    }


    Console.WriteLine($"Assistant response: {content}");
    // Console.WriteLine($"Function call: {functionCall?.Name}");

    // check if tool call, if so, call the tool

}

// TODO:
//   get a function call to work on the llm - CHECK
//   list tools on mcp server
//   convert tool call to a tool on llm
//   do user prompt
//   verify if it was a function call
//   call the right tool on the mcp server