using Azure;
using Azure.AI.Inference;
using Azure.Identity;

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
    var options = new ChatCompletionsOptions(chatHistory)
    {
        Model = "Phi-3-medium-4k-instruct"
    };

    ChatCompletions? response = await client.CompleteAsync(options);
    var content = response.Content;
    Console.WriteLine($"Assistant response: {content}");
    

}

// TODO:
//   list tools on mcp server
//   convert tool call to a tool on llm
//   do user prompt
//   verify if it was a function call
//   call the right tool on the mcp server