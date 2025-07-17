<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T07:13:57+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "nl"
}
-->
# Een client maken met LLM

Tot nu toe heb je gezien hoe je een server en een client maakt. De client kon expliciet de server aanroepen om een lijst te krijgen van tools, resources en prompts. Dit is echter niet erg praktisch. Je gebruiker leeft in het agentische tijdperk en verwacht prompts te gebruiken en te communiceren met een LLM om dit te doen. Voor jouw gebruiker maakt het niet uit of je MCP gebruikt om je mogelijkheden op te slaan, maar ze verwachten wel dat ze natuurlijke taal kunnen gebruiken om te communiceren. Hoe lossen we dit op? De oplossing is het toevoegen van een LLM aan de client.

## Overzicht

In deze les richten we ons op het toevoegen van een LLM aan je client en laten we zien hoe dit een veel betere ervaring biedt voor je gebruiker.

## Leerdoelen

Aan het einde van deze les kun je:

- Een client maken met een LLM.
- Naadloos communiceren met een MCP-server via een LLM.
- Een betere eindgebruikerservaring bieden aan de clientzijde.

## Aanpak

Laten we proberen te begrijpen welke aanpak we moeten volgen. Een LLM toevoegen klinkt eenvoudig, maar hoe gaan we dit daadwerkelijk doen?

Zo zal de client met de server communiceren:

1. Verbinding maken met de server.

1. Mogelijkheden, prompts, resources en tools opvragen en hun schema opslaan.

1. Een LLM toevoegen en de opgeslagen mogelijkheden en schema’s doorgeven in een formaat dat de LLM begrijpt.

1. Een gebruikersprompt afhandelen door deze samen met de door de client opgehaalde tools aan de LLM door te geven.

Goed, nu we op hoofdlijnen begrijpen hoe we dit kunnen doen, laten we dit uitproberen in de onderstaande oefening.

## Oefening: Een client maken met een LLM

In deze oefening leren we een LLM toe te voegen aan onze client.

## Authenticatie met GitHub Personal Access Token

Het aanmaken van een GitHub-token is een eenvoudig proces. Zo doe je dat:

- Ga naar GitHub Settings – Klik op je profielfoto rechtsboven en selecteer Settings.
- Navigeer naar Developer Settings – Scroll naar beneden en klik op Developer Settings.
- Selecteer Personal Access Tokens – Klik op Personal access tokens en vervolgens op Generate new token.
- Configureer je token – Voeg een notitie toe ter referentie, stel een vervaldatum in en selecteer de benodigde scopes (toestemmingen).
- Genereer en kopieer het token – Klik op Generate token en zorg dat je het direct kopieert, want je kunt het later niet meer zien.

### -1- Verbinden met de server

Laten we eerst onze client maken:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MCPClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", 
            apiKey: process.env.GITHUB_TOKEN,
        });

        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }
}
```

In bovenstaande code hebben we:

- De benodigde libraries geïmporteerd
- Een klasse gemaakt met twee leden, `client` en `openai`, die ons helpen een client te beheren en te communiceren met een LLM.
- Onze LLM-instantie geconfigureerd om GitHub Models te gebruiken door `baseUrl` in te stellen op de inference API.

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)


async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()


if __name__ == "__main__":
    import asyncio

    asyncio.run(run())

```

In bovenstaande code hebben we:

- De benodigde MCP-libraries geïmporteerd
- Een client aangemaakt

### .NET

```csharp
using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using System.Text.Json;

var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
    Arguments = [],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

### Java

Eerst moet je de LangChain4j dependencies toevoegen aan je `pom.xml` bestand. Voeg deze dependencies toe om MCP-integratie en ondersteuning voor GitHub Models mogelijk te maken:

```xml
<properties>
    <langchain4j.version>1.0.0-beta3</langchain4j.version>
</properties>

<dependencies>
    <!-- LangChain4j MCP Integration -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-mcp</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- OpenAI Official API Client -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-open-ai-official</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- GitHub Models Support -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-github-models</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- Spring Boot Starter (optional, for production apps) -->
    <dependency>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-actuator</artifactId>
    </dependency>
</dependencies>
```

Maak vervolgens je Java clientklasse aan:

```java
import dev.langchain4j.mcp.McpToolProvider;
import dev.langchain4j.mcp.client.DefaultMcpClient;
import dev.langchain4j.mcp.client.McpClient;
import dev.langchain4j.mcp.client.transport.McpTransport;
import dev.langchain4j.mcp.client.transport.http.HttpMcpTransport;
import dev.langchain4j.model.chat.ChatLanguageModel;
import dev.langchain4j.model.openaiofficial.OpenAiOfficialChatModel;
import dev.langchain4j.service.AiServices;
import dev.langchain4j.service.tool.ToolProvider;

import java.time.Duration;
import java.util.List;

public class LangChain4jClient {
    
    public static void main(String[] args) throws Exception {        // Configure the LLM to use GitHub Models
        ChatLanguageModel model = OpenAiOfficialChatModel.builder()
                .isGitHubModels(true)
                .apiKey(System.getenv("GITHUB_TOKEN"))
                .timeout(Duration.ofSeconds(60))
                .modelName("gpt-4.1-nano")
                .build();

        // Create MCP transport for connecting to server
        McpTransport transport = new HttpMcpTransport.Builder()
                .sseUrl("http://localhost:8080/sse")
                .timeout(Duration.ofSeconds(60))
                .logRequests(true)
                .logResponses(true)
                .build();

        // Create MCP client
        McpClient mcpClient = new DefaultMcpClient.Builder()
                .transport(transport)
                .build();
    }
}
```

In bovenstaande code hebben we:

- **LangChain4j dependencies toegevoegd**: Nodig voor MCP-integratie, officiële OpenAI client en ondersteuning voor GitHub Models
- **De LangChain4j libraries geïmporteerd**: Voor MCP-integratie en OpenAI chatmodel functionaliteit
- **Een `ChatLanguageModel` aangemaakt**: Geconfigureerd om GitHub Models te gebruiken met je GitHub token
- **HTTP transport opgezet**: Met Server-Sent Events (SSE) om verbinding te maken met de MCP-server
- **Een MCP client gemaakt**: Die de communicatie met de server afhandelt
- **LangChain4j’s ingebouwde MCP-ondersteuning gebruikt**: Dit vereenvoudigt de integratie tussen LLMs en MCP-servers

Goed, voor de volgende stap gaan we de mogelijkheden op de server opvragen.

### -2 Mogelijkheden van de server opvragen

Nu verbinden we met de server en vragen we naar de mogelijkheden:

### TypeScript

Voeg in dezelfde klasse de volgende methoden toe:

```typescript
async connectToServer(transport: Transport) {
     await this.client.connect(transport);
     this.run();
     console.error("MCPClient started on stdin/stdout");
}

async run() {
    console.log("Asking server for available tools");

    // listing tools
    const toolsResult = await this.client.listTools();
}
```

In bovenstaande code hebben we:

- Code toegevoegd om verbinding te maken met de server, `connectToServer`.
- Een `run` methode gemaakt die verantwoordelijk is voor de flow van onze app. Tot nu toe worden alleen de tools weergegeven, maar we voegen hier binnenkort meer aan toe.

### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
    print("Tool", tool.inputSchema["properties"])
```

Dit hebben we toegevoegd:

- Resources en tools opgevraagd en afgedrukt. Voor tools tonen we ook het `inputSchema` dat we later gebruiken.

### .NET

```csharp
async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
{
    Console.WriteLine("Listing tools");
    var tools = await mcpClient.ListToolsAsync();

    List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

    foreach (var tool in tools)
    {
        Console.WriteLine($"Connected to server with tools: {tool.Name}");
        Console.WriteLine($"Tool description: {tool.Description}");
        Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

        // TODO: convert tool defintion from MCP tool to LLm tool     
    }

    return toolDefinitions;
}
```

In bovenstaande code hebben we:

- De beschikbare tools op de MCP-server opgevraagd
- Voor elke tool de naam, beschrijving en het schema weergegeven. Dit laatste gebruiken we straks om de tools aan te roepen.

### Java

```java
// Create a tool provider that automatically discovers MCP tools
ToolProvider toolProvider = McpToolProvider.builder()
        .mcpClients(List.of(mcpClient))
        .build();

// The MCP tool provider automatically handles:
// - Listing available tools from the MCP server
// - Converting MCP tool schemas to LangChain4j format
// - Managing tool execution and responses
```

In bovenstaande code hebben we:

- Een `McpToolProvider` gemaakt die automatisch alle tools van de MCP-server ontdekt en registreert
- De toolprovider regelt intern de conversie tussen MCP tool schema’s en het LangChain4j toolformaat
- Deze aanpak maakt handmatig tools opvragen en converteren overbodig

### -3- Servermogelijkheden omzetten naar LLM-tools

De volgende stap na het opvragen van de servermogelijkheden is deze omzetten naar een formaat dat de LLM begrijpt. Zodra dat is gedaan, kunnen we deze mogelijkheden als tools aan onze LLM aanbieden.

### TypeScript

1. Voeg de volgende code toe om de response van de MCP-server om te zetten naar een toolformaat dat de LLM kan gebruiken:

    ```typescript
    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
        }) {
        // Create a zod schema based on the input_schema
        const schema = z.object(tool.input_schema);
    
        return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
            name: tool.name,
            description: tool.description,
            parameters: {
            type: "object",
            properties: tool.input_schema.properties,
            required: tool.input_schema.required,
            },
            },
        };
    }

    ```

    De bovenstaande code neemt een response van de MCP-server en zet deze om naar een tooldefinitie die de LLM begrijpt.

1. Laten we de `run` methode bijwerken om de servermogelijkheden te tonen:

    ```typescript
    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
            name: tool.name,
            description: tool.description,
            input_schema: tool.inputSchema,
            });
        });
    }
    ```

    In bovenstaande code hebben we de `run` methode aangepast om door het resultaat te lopen en voor elke entry `openAiToolAdapter` aan te roepen.

### Python

1. Maak eerst de volgende converterfunctie aan:

    ```python
    def convert_to_llm_tool(tool):
        tool_schema = {
            "type": "function",
            "function": {
                "name": tool.name,
                "description": tool.description,
                "type": "function",
                "parameters": {
                    "type": "object",
                    "properties": tool.inputSchema["properties"]
                }
            }
        }

        return tool_schema
    ```

    In de functie `convert_to_llm_tools` hierboven nemen we een MCP tool response en zetten die om naar een formaat dat de LLM begrijpt.

1. Werk vervolgens onze clientcode bij om deze functie te gebruiken:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Hier voegen we een aanroep toe aan `convert_to_llm_tool` om de MCP tool response om te zetten naar iets dat we later aan de LLM kunnen doorgeven.

### .NET

1. Voeg code toe om de MCP tool response om te zetten naar iets dat de LLM begrijpt:

```csharp
ChatCompletionsToolDefinition ConvertFrom(string name, string description, JsonElement jsonElement)
{ 
    // convert the tool to a function definition
    FunctionDefinition functionDefinition = new FunctionDefinition(name)
    {
        Description = description,
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = jsonElement
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    // create a tool definition
    ChatCompletionsToolDefinition toolDefinition = new ChatCompletionsToolDefinition(functionDefinition);
    return toolDefinition;
}
```

In bovenstaande code hebben we:

- Een functie `ConvertFrom` gemaakt die naam, beschrijving en input schema ontvangt.
- Functionaliteit gedefinieerd die een FunctionDefinition aanmaakt die wordt doorgegeven aan een ChatCompletionsDefinition. Dit laatste is iets dat de LLM begrijpt.

1. Laten we zien hoe we bestaande code kunnen aanpassen om van deze functie gebruik te maken:

    ```csharp
    async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
    {
        Console.WriteLine("Listing tools");
        var tools = await mcpClient.ListToolsAsync();

        List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

        foreach (var tool in tools)
        {
            Console.WriteLine($"Connected to server with tools: {tool.Name}");
            Console.WriteLine($"Tool description: {tool.Description}");
            Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

            JsonElement propertiesElement;
            tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

            var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
            Console.WriteLine($"Tool definition: {def}");
            toolDefinitions.Add(def);

            Console.WriteLine($"Properties: {propertiesElement}");        
        }

        return toolDefinitions;
    }
    ```

    In bovenstaande code hebben we:

    - De functie aangepast om de MCP tool response om te zetten naar een LLM-tool. We lichten de toegevoegde code uit:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Het input schema maakt deel uit van de tool response, maar zit in het "properties" attribuut, dus dat moeten we eruit halen. Verder roepen we nu `ConvertFrom` aan met de tooldetails. Nu het zware werk gedaan is, bekijken we hoe dit samenkomt als we een gebruikersprompt afhandelen.

### Java

```java
// Create a Bot interface for natural language interaction
public interface Bot {
    String chat(String prompt);
}

// Configure the AI service with LLM and MCP tools
Bot bot = AiServices.builder(Bot.class)
        .chatLanguageModel(model)
        .toolProvider(toolProvider)
        .build();
```

In bovenstaande code hebben we:

- Een eenvoudige `Bot` interface gedefinieerd voor natuurlijke taalinteracties
- LangChain4j’s `AiServices` gebruikt om de LLM automatisch te koppelen aan de MCP toolprovider
- Het framework regelt automatisch de tool schema conversie en functie-aanroepen achter de schermen
- Deze aanpak elimineert handmatige toolconversie – LangChain4j regelt alle complexiteit van het omzetten van MCP tools naar een LLM-compatibel formaat

Goed, we zijn nu klaar om gebruikersverzoeken te verwerken, dus laten we dat aanpakken.

### -4- Gebruikersprompt afhandelen

In dit deel van de code gaan we gebruikersverzoeken afhandelen.

### TypeScript

1. Voeg een methode toe die onze LLM aanroept:

    ```typescript
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
    ) {
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);


        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  

        }
    }
    ```

    In bovenstaande code hebben we:

    - Een methode `callTools` toegevoegd.
    - De methode controleert welke tools door de LLM zijn aangeroepen, indien aanwezig:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Roept een tool aan als de LLM aangeeft dat dat moet:

        ```typescript
        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  
        ```

1. Werk de `run` methode bij om aanroepen naar de LLM en `callTools` te verwerken:

    ```typescript

    // 1. Create messages that's input for the LLM
    const prompt = "What is the sum of 2 and 3?"

    const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

    console.log("Querying LLM: ", messages[0].content);

    // 2. Calling the LLM
    let response = this.openai.chat.completions.create({
        model: "gpt-4o-mini",
        max_tokens: 1000,
        messages,
        tools: tools,
    });    

    let results: any[] = [];

    // 3. Go through the LLM response,for each choice, check if it has tool calls 
    (await response).choices.map(async (choice: { message: any; }) => {
        const message = choice.message;
        if (message.tool_calls) {
            console.log("Making tool call")
            await this.callTools(message.tool_calls, results);
        }
    });
    ```

Goed, hier is de volledige code:

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MyClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", // might need to change to this url in the future: https://models.github.ai/inference
            apiKey: process.env.GITHUB_TOKEN,
        });

       
        
        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }

    async connectToServer(transport: Transport) {
        await this.client.connect(transport);
        this.run();
        console.error("MCPClient started on stdin/stdout");
    }

    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
          }) {
          // Create a zod schema based on the input_schema
          const schema = z.object(tool.input_schema);
      
          return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
              name: tool.name,
              description: tool.description,
              parameters: {
              type: "object",
              properties: tool.input_schema.properties,
              required: tool.input_schema.required,
              },
            },
          };
    }
    
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
      ) {
        for (const tool_call of tool_calls) {
          const toolName = tool_call.function.name;
          const args = tool_call.function.arguments;
    
          console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);
    
    
          // 2. Call the server's tool 
          const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
          });
    
          console.log("Tool result: ", toolResult);
    
          // 3. Do something with the result
          // TODO  
    
         }
    }

    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
              name: tool.name,
              description: tool.description,
              input_schema: tool.inputSchema,
            });
        });

        const prompt = "What is the sum of 2 and 3?";
    
        const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

        console.log("Querying LLM: ", messages[0].content);
        let response = this.openai.chat.completions.create({
            model: "gpt-4o-mini",
            max_tokens: 1000,
            messages,
            tools: tools,
        });    

        let results: any[] = [];
    
        // 1. Go through the LLM response,for each choice, check if it has tool calls 
        (await response).choices.map(async (choice: { message: any; }) => {
          const message = choice.message;
          if (message.tool_calls) {
              console.log("Making tool call")
              await this.callTools(message.tool_calls, results);
          }
        });
    }
    
}

let client = new MyClient();
 const transport = new StdioClientTransport({
            command: "node",
            args: ["./build/index.js"]
        });

client.connectToServer(transport);
```

### Python

1. Voeg de benodigde imports toe om een LLM aan te roepen:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Voeg vervolgens de functie toe die de LLM aanroept:

    ```python
    # llm

    def call_llm(prompt, functions):
        token = os.environ["GITHUB_TOKEN"]
        endpoint = "https://models.inference.ai.azure.com"

        model_name = "gpt-4o"

        client = ChatCompletionsClient(
            endpoint=endpoint,
            credential=AzureKeyCredential(token),
        )

        print("CALLING LLM")
        response = client.complete(
            messages=[
                {
                "role": "system",
                "content": "You are a helpful assistant.",
                },
                {
                "role": "user",
                "content": prompt,
                },
            ],
            model=model_name,
            tools = functions,
            # Optional parameters
            temperature=1.,
            max_tokens=1000,
            top_p=1.    
        )

        response_message = response.choices[0].message
        
        functions_to_call = []

        if response_message.tool_calls:
            for tool_call in response_message.tool_calls:
                print("TOOL: ", tool_call)
                name = tool_call.function.name
                args = json.loads(tool_call.function.arguments)
                functions_to_call.append({ "name": name, "args": args })

        return functions_to_call
    ```

    In bovenstaande code hebben we:

    - Onze functies, gevonden op de MCP-server en geconverteerd, aan de LLM doorgegeven.
    - De LLM aangeroepen met deze functies.
    - Het resultaat gecontroleerd om te zien welke functies we eventueel moeten aanroepen.
    - Ten slotte een lijst met functies doorgegeven om aan te roepen.

1. Laatste stap, werk onze hoofdcode bij:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Dat was de laatste stap, in bovenstaande code:

    - Roepen we een MCP-tool aan via `call_tool` met een functie die de LLM op basis van onze prompt dacht te moeten aanroepen.
    - Printen we het resultaat van de tool-aanroep naar de MCP-server.

### .NET

1. Hier wat code om een LLM prompt request te doen:

    ```csharp
    var tools = await GetMcpTools();

    for (int i = 0; i < tools.Count; i++)
    {
        var tool = tools[i];
        Console.WriteLine($"MCP Tools def: {i}: {tool}");
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
        Tools = { tools[0] }
    };

    // 3. Call the model  

    ChatCompletions? response = await client.CompleteAsync(options);
    var content = response.Content;

    ```

    In bovenstaande code hebben we:

    - Tools opgehaald van de MCP-server, `var tools = await GetMcpTools()`.
    - Een gebruikersprompt gedefinieerd `userMessage`.
    - Een opties-object gemaakt met model en tools.
    - Een verzoek naar de LLM gedaan.

1. Eén laatste stap, kijken of de LLM denkt dat we een functie moeten aanroepen:

    ```csharp
    // 4. Check if the response contains a function call
    ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
    for (int i = 0; i < response.ToolCalls.Count; i++)
    {
        var call = response.ToolCalls[i];
        Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
        //Tool call 0: add with arguments {"a":2,"b":4}

        var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(call.Arguments);
        var result = await mcpClient.CallToolAsync(
            call.Name,
            dict!,
            cancellationToken: CancellationToken.None
        );

        Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

    }
    ```

    In bovenstaande code hebben we:

    - Door een lijst met functie-aanroepen gelopen.
    - Voor elke tool-aanroep naam en argumenten geparsed en de tool op de MCP-server aangeroepen met de MCP client. Tot slot de resultaten geprint.

Hier is de volledige code:

```csharp
using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using System.Text.Json;

var endpoint = "https://models.inference.ai.azure.com";
var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN"); // Your GitHub Access Token
var client = new ChatCompletionsClient(new Uri(endpoint), new AzureKeyCredential(token));
var chatHistory = new List<ChatRequestMessage>
{
    new ChatRequestSystemMessage("You are a helpful assistant that knows about AI")
};

var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
    Arguments = [],
});

Console.WriteLine("Setting up stdio transport");

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);

ChatCompletionsToolDefinition ConvertFrom(string name, string description, JsonElement jsonElement)
{ 
    // convert the tool to a function definition
    FunctionDefinition functionDefinition = new FunctionDefinition(name)
    {
        Description = description,
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = jsonElement
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    // create a tool definition
    ChatCompletionsToolDefinition toolDefinition = new ChatCompletionsToolDefinition(functionDefinition);
    return toolDefinition;
}



async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
{
    Console.WriteLine("Listing tools");
    var tools = await mcpClient.ListToolsAsync();

    List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

    foreach (var tool in tools)
    {
        Console.WriteLine($"Connected to server with tools: {tool.Name}");
        Console.WriteLine($"Tool description: {tool.Description}");
        Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);

        Console.WriteLine($"Properties: {propertiesElement}");        
    }

    return toolDefinitions;
}

// 1. List tools on mcp server

var tools = await GetMcpTools();
for (int i = 0; i < tools.Count; i++)
{
    var tool = tools[i];
    Console.WriteLine($"MCP Tools def: {i}: {tool}");
}

// 2. Define the chat history and the user message
var userMessage = "add 2 and 4";

chatHistory.Add(new ChatRequestUserMessage(userMessage));


// 3. Define options, including the tools
var options = new ChatCompletionsOptions(chatHistory)
{
    Model = "gpt-4o-mini",
    Tools = { tools[0] }
};

// 4. Call the model  

ChatCompletions? response = await client.CompleteAsync(options);
var content = response.Content;

// 5. Check if the response contains a function call
ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
for (int i = 0; i < response.ToolCalls.Count; i++)
{
    var call = response.ToolCalls[i];
    Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
    //Tool call 0: add with arguments {"a":2,"b":4}

    var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(call.Arguments);
    var result = await mcpClient.CallToolAsync(
        call.Name,
        dict!,
        cancellationToken: CancellationToken.None
    );

    Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

}

// 5. Print the generic response
Console.WriteLine($"Assistant response: {content}");
```

### Java

```java
try {
    // Execute natural language requests that automatically use MCP tools
    String response = bot.chat("Calculate the sum of 24.5 and 17.3 using the calculator service");
    System.out.println(response);

    response = bot.chat("What's the square root of 144?");
    System.out.println(response);

    response = bot.chat("Show me the help for the calculator service");
    System.out.println(response);
} finally {
    mcpClient.close();
}
```

In bovenstaande code hebben we:

- Eenvoudige natuurlijke taal prompts gebruikt om te communiceren met de MCP server tools
- Het LangChain4j framework regelt automatisch:
  - Het omzetten van gebruikersprompts naar tool-aanroepen wanneer nodig
  - Het aanroepen van de juiste MCP tools op basis van de beslissing van de LLM
  - Het beheren van het gesprek tussen de LLM en MCP server
- De `bot.chat()` methode retourneert natuurlijke taal antwoorden die mogelijk resultaten bevatten van MCP tool-uitvoeringen
- Deze aanpak zorgt voor een naadloze gebruikerservaring waarbij gebruikers niet hoeven te weten dat er een MCP-implementatie onderliggend wordt aangeroepen

Volledig codevoorbeeld:

```java
public class LangChain4jClient {
    
    public static void main(String[] args) throws Exception {        ChatLanguageModel model = OpenAiOfficialChatModel.builder()
                .isGitHubModels(true)
                .apiKey(System.getenv("GITHUB_TOKEN"))
                .timeout(Duration.ofSeconds(60))
                .modelName("gpt-4.1-nano")
                .timeout(Duration.ofSeconds(60))
                .build();

        McpTransport transport = new HttpMcpTransport.Builder()
                .sseUrl("http://localhost:8080/sse")
                .timeout(Duration.ofSeconds(60))
                .logRequests(true)
                .logResponses(true)
                .build();

        McpClient mcpClient = new DefaultMcpClient.Builder()
                .transport(transport)
                .build();

        ToolProvider toolProvider = McpToolProvider.builder()
                .mcpClients(List.of(mcpClient))
                .build();

        Bot bot = AiServices.builder(Bot.class)
                .chatLanguageModel(model)
                .toolProvider(toolProvider)
                .build();

        try {
            String response = bot.chat("Calculate the sum of 24.5 and 17.3 using the calculator service");
            System.out.println(response);

            response = bot.chat("What's the square root of 144?");
            System.out.println(response);

            response = bot.chat("Show me the help for the calculator service");
            System.out.println(response);
        } finally {
            mcpClient.close();
        }
    }
}
```

Geweldig, je hebt het gedaan!

## Opdracht

Neem de code uit de oefening en breid de server uit met meer tools. Maak vervolgens een client met een LLM, zoals in de oefening, en test deze met verschillende prompts om te zorgen dat al je servertools dynamisch worden aangeroepen. Deze manier van een client bouwen zorgt voor een geweldige gebruikerservaring, omdat gebruikers prompts kunnen gebruiken in plaats van exacte clientcommando’s, en niet merken dat er een MCP-server wordt aangeroepen.

## Oplossing

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Belangrijkste punten

- Het toevoegen van een LLM aan je client biedt een betere manier voor gebruikers om met MCP-servers te communiceren.
- Je moet de MCP-server response omzetten naar iets dat de LLM kan begrijpen.

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Extra bronnen

## Wat is de volgende stap

- Volgende: [Een server gebruiken met Visual Studio Code](../04-vscode/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.