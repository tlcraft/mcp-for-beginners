<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "343235ad6c122033c549a677913443f9",
  "translation_date": "2025-07-17T18:39:26+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "el"
}
-->
# Δημιουργία πελάτη με LLM

Μέχρι τώρα, έχετε δει πώς να δημιουργήσετε έναν διακομιστή και έναν πελάτη. Ο πελάτης μπορούσε να καλεί ρητά τον διακομιστή για να εμφανίσει τα εργαλεία, τους πόρους και τα prompts του. Ωστόσο, αυτή η προσέγγιση δεν είναι πολύ πρακτική. Ο χρήστης σας ζει στην εποχή των πρακτόρων και περιμένει να χρησιμοποιεί prompts και να επικοινωνεί με ένα LLM για να το κάνει. Για τον χρήστη σας, δεν έχει σημασία αν χρησιμοποιείτε MCP ή όχι για να αποθηκεύσετε τις δυνατότητές σας, αλλά περιμένει να χρησιμοποιεί φυσική γλώσσα για την αλληλεπίδραση. Πώς το λύνουμε αυτό; Η λύση είναι να προσθέσουμε ένα LLM στον πελάτη.

## Επισκόπηση

Σε αυτό το μάθημα εστιάζουμε στην προσθήκη ενός LLM στον πελάτη σας και δείχνουμε πώς αυτό προσφέρει μια πολύ καλύτερη εμπειρία για τον χρήστη σας.

## Στόχοι Μάθησης

Στο τέλος αυτού του μαθήματος, θα μπορείτε να:

- Δημιουργήσετε έναν πελάτη με ένα LLM.
- Αλληλεπιδράσετε απρόσκοπτα με έναν MCP διακομιστή χρησιμοποιώντας ένα LLM.
- Παρέχετε καλύτερη εμπειρία τελικού χρήστη στην πλευρά του πελάτη.

## Προσέγγιση

Ας προσπαθήσουμε να κατανοήσουμε την προσέγγιση που πρέπει να ακολουθήσουμε. Η προσθήκη ενός LLM ακούγεται απλή, αλλά θα το κάνουμε πραγματικά;

Έτσι θα αλληλεπιδρά ο πελάτης με τον διακομιστή:

1. Εγκαθιδρύουμε σύνδεση με τον διακομιστή.

1. Λίστα δυνατοτήτων, prompts, πόρων και εργαλείων, και αποθηκεύουμε το σχήμα τους.

1. Προσθέτουμε ένα LLM και περνάμε τις αποθηκευμένες δυνατότητες και το σχήμα τους σε μορφή που καταλαβαίνει το LLM.

1. Διαχειριζόμαστε ένα prompt χρήστη περνώντας το στο LLM μαζί με τα εργαλεία που έχει καταγράψει ο πελάτης.

Τέλεια, τώρα που καταλαβαίνουμε σε γενικές γραμμές πώς μπορούμε να το κάνουμε, ας το δοκιμάσουμε στην παρακάτω άσκηση.

## Άσκηση: Δημιουργία πελάτη με LLM

Σε αυτή την άσκηση, θα μάθουμε πώς να προσθέσουμε ένα LLM στον πελάτη μας.

## Πιστοποίηση με GitHub Personal Access Token

Η δημιουργία ενός token στο GitHub είναι μια απλή διαδικασία. Δείτε πώς μπορείτε να το κάνετε:

- Μεταβείτε στις Ρυθμίσεις του GitHub – Κάντε κλικ στην εικόνα προφίλ σας πάνω δεξιά και επιλέξτε Ρυθμίσεις.
- Πλοηγηθείτε στις Ρυθμίσεις Προγραμματιστή – Κάντε κύλιση προς τα κάτω και επιλέξτε Ρυθμίσεις Προγραμματιστή.
- Επιλέξτε Personal Access Tokens – Κάντε κλικ στα Personal access tokens και μετά στο Generate new token.
- Διαμορφώστε το Token σας – Προσθέστε μια σημείωση για αναφορά, ορίστε ημερομηνία λήξης και επιλέξτε τα απαραίτητα δικαιώματα (scopes).
- Δημιουργήστε και Αντιγράψτε το Token – Κάντε κλικ στο Generate token και φροντίστε να το αντιγράψετε αμέσως, καθώς δεν θα μπορείτε να το δείτε ξανά.

### -1- Σύνδεση με τον διακομιστή

Ας δημιουργήσουμε πρώτα τον πελάτη μας:

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

Στον παραπάνω κώδικα έχουμε:

- Εισάγει τις απαραίτητες βιβλιοθήκες
- Δημιουργήσει μια κλάση με δύο μέλη, `client` και `openai`, που θα μας βοηθήσουν να διαχειριστούμε έναν πελάτη και να αλληλεπιδράσουμε με ένα LLM αντίστοιχα.
- Διαμορφώσει το στιγμιότυπο του LLM μας να χρησιμοποιεί GitHub Models ορίζοντας το `baseUrl` ώστε να δείχνει στο inference API.

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

Στον παραπάνω κώδικα έχουμε:

- Εισάγει τις απαραίτητες βιβλιοθήκες για MCP
- Δημιουργήσει έναν πελάτη

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

Πρώτα, θα χρειαστεί να προσθέσετε τις εξαρτήσεις LangChain4j στο αρχείο `pom.xml` σας. Προσθέστε αυτές τις εξαρτήσεις για να ενεργοποιήσετε την ενσωμάτωση MCP και την υποστήριξη GitHub Models:

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

Έπειτα δημιουργήστε την κλάση πελάτη Java:

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

Στον παραπάνω κώδικα έχουμε:

- **Προσθέσει τις εξαρτήσεις LangChain4j**: Απαραίτητες για την ενσωμάτωση MCP, τον επίσημο πελάτη OpenAI και την υποστήριξη GitHub Models
- **Εισάγει τις βιβλιοθήκες LangChain4j**: Για ενσωμάτωση MCP και λειτουργικότητα μοντέλου συνομιλίας OpenAI
- **Δημιουργήσει ένα `ChatLanguageModel`**: Διαμορφωμένο να χρησιμοποιεί GitHub Models με το GitHub token σας
- **Ρυθμίσει τη μεταφορά HTTP**: Χρησιμοποιώντας Server-Sent Events (SSE) για σύνδεση με τον MCP διακομιστή
- **Δημιουργήσει έναν MCP πελάτη**: Που θα διαχειρίζεται την επικοινωνία με τον διακομιστή
- **Χρησιμοποιήσει την ενσωματωμένη υποστήριξη MCP του LangChain4j**: Που απλοποιεί την ενσωμάτωση μεταξύ LLMs και MCP διακομιστών

Τέλεια, για το επόμενο βήμα, ας εμφανίσουμε τις δυνατότητες στον διακομιστή.

### -2- Λίστα δυνατοτήτων διακομιστή

Τώρα θα συνδεθούμε με τον διακομιστή και θα ζητήσουμε τις δυνατότητές του:

### Typescript

Στην ίδια κλάση, προσθέστε τις παρακάτω μεθόδους:

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

Στον παραπάνω κώδικα έχουμε:

- Προσθέσει κώδικα για σύνδεση με τον διακομιστή, `connectToServer`.
- Δημιουργήσει μια μέθοδο `run` υπεύθυνη για τη ροή της εφαρμογής μας. Μέχρι στιγμής εμφανίζει μόνο τα εργαλεία, αλλά σύντομα θα προσθέσουμε περισσότερα.

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

Αυτό που προσθέσαμε:

- Εμφάνιση πόρων και εργαλείων και εκτύπωσή τους. Για τα εργαλεία εμφανίζουμε επίσης το `inputSchema` που θα χρησιμοποιήσουμε αργότερα.

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

Στον παραπάνω κώδικα έχουμε:

- Εμφανίσει τα διαθέσιμα εργαλεία στον MCP διακομιστή
- Για κάθε εργαλείο, εμφανίσει όνομα, περιγραφή και το σχήμα του. Το τελευταίο θα το χρησιμοποιήσουμε για να καλέσουμε τα εργαλεία σύντομα.

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

Στον παραπάνω κώδικα έχουμε:

- Δημιουργήσει έναν `McpToolProvider` που ανακαλύπτει και καταχωρεί αυτόματα όλα τα εργαλεία από τον MCP διακομιστή
- Ο πάροχος εργαλείων διαχειρίζεται εσωτερικά τη μετατροπή μεταξύ των σχημάτων εργαλείων MCP και της μορφής εργαλείων του LangChain4j
- Αυτή η προσέγγιση αφαιρεί την ανάγκη χειροκίνητης λίστας και μετατροπής εργαλείων

### -3- Μετατροπή δυνατοτήτων διακομιστή σε εργαλεία LLM

Το επόμενο βήμα μετά την εμφάνιση των δυνατοτήτων του διακομιστή είναι να τις μετατρέψουμε σε μορφή που καταλαβαίνει το LLM. Μόλις το κάνουμε αυτό, μπορούμε να παρέχουμε αυτές τις δυνατότητες ως εργαλεία στο LLM μας.

### TypeScript

1. Προσθέστε τον παρακάτω κώδικα για να μετατρέψετε την απάντηση από τον MCP διακομιστή σε μορφή εργαλείου που μπορεί να χρησιμοποιήσει το LLM:

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

    Ο παραπάνω κώδικας παίρνει μια απάντηση από τον MCP διακομιστή και την μετατρέπει σε ορισμό εργαλείου που καταλαβαίνει το LLM.

1. Ας ενημερώσουμε τη μέθοδο `run` για να εμφανίζει τις δυνατότητες του διακομιστή:

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

    Στον παραπάνω κώδικα, ενημερώσαμε τη μέθοδο `run` ώστε να διατρέχει το αποτέλεσμα και για κάθε εγγραφή να καλεί το `openAiToolAdapter`.

### Python

1. Πρώτα, ας δημιουργήσουμε την παρακάτω συνάρτηση μετατροπής

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

    Στη συνάρτηση `convert_to_llm_tools` παίρνουμε μια απάντηση εργαλείου MCP και την μετατρέπουμε σε μορφή που καταλαβαίνει το LLM.

1. Έπειτα, ας ενημερώσουμε τον κώδικα του πελάτη μας για να χρησιμοποιεί αυτή τη συνάρτηση ως εξής:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Εδώ, προσθέτουμε μια κλήση στο `convert_to_llm_tool` για να μετατρέψουμε την απάντηση εργαλείου MCP σε κάτι που μπορούμε να δώσουμε στο LLM αργότερα.

### .NET

1. Ας προσθέσουμε κώδικα για να μετατρέψουμε την απάντηση εργαλείου MCP σε κάτι που καταλαβαίνει το LLM

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

Στον παραπάνω κώδικα έχουμε:

- Δημιουργήσει μια συνάρτηση `ConvertFrom` που παίρνει όνομα, περιγραφή και σχήμα εισόδου.
- Ορίσει λειτουργικότητα που δημιουργεί ένα `FunctionDefinition` που περνάει σε ένα `ChatCompletionsDefinition`. Το τελευταίο είναι κάτι που καταλαβαίνει το LLM.

1. Ας δούμε πώς μπορούμε να ενημερώσουμε υπάρχοντα κώδικα για να εκμεταλλευτούμε αυτή τη συνάρτηση:

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

    Στον παραπάνω κώδικα έχουμε:

    - Ενημερώσει τη συνάρτηση για να μετατρέπει την απάντηση εργαλείου MCP σε εργαλείο LLM. Ας επισημάνουμε τον κώδικα που προσθέσαμε:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Το σχήμα εισόδου είναι μέρος της απάντησης εργαλείου αλλά στο χαρακτηριστικό "properties", οπότε πρέπει να το εξάγουμε. Επιπλέον, τώρα καλούμε το `ConvertFrom` με τις λεπτομέρειες του εργαλείου. Τώρα που έχουμε κάνει το βασικό έργο, ας δούμε πώς γίνεται η κλήση καθώς διαχειριζόμαστε ένα prompt χρήστη.

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

Στον παραπάνω κώδικα έχουμε:

- Ορίσει ένα απλό interface `Bot` για αλληλεπιδράσεις με φυσική γλώσσα
- Χρησιμοποιήσει το `AiServices` του LangChain4j για αυτόματη σύνδεση του LLM με τον πάροχο εργαλείων MCP
- Το πλαίσιο διαχειρίζεται αυτόματα τη μετατροπή σχημάτων εργαλείων και τις κλήσεις συναρτήσεων στο παρασκήνιο
- Αυτή η προσέγγιση εξαλείφει τη χειροκίνητη μετατροπή εργαλείων - το LangChain4j αναλαμβάνει όλη την πολυπλοκότητα της μετατροπής εργαλείων MCP σε μορφή συμβατή με LLM

Τέλεια, είμαστε έτοιμοι να διαχειριστούμε αιτήματα χρηστών, ας το κάνουμε τώρα.

### -4- Διαχείριση αιτήματος prompt χρήστη

Σε αυτό το μέρος του κώδικα, θα διαχειριστούμε τα αιτήματα των χρηστών.

### TypeScript

1. Προσθέστε μια μέθοδο που θα χρησιμοποιηθεί για να καλέσουμε το LLM:

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

    Στον παραπάνω κώδικα:

    - Προσθέσαμε μια μέθοδο `callTools`.
    - Η μέθοδος παίρνει μια απάντηση LLM και ελέγχει ποια εργαλεία έχουν κληθεί, αν υπάρχουν:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Καλεί ένα εργαλείο, αν το LLM υποδεικνύει ότι πρέπει να κληθεί:

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

1. Ενημερώστε τη μέθοδο `run` ώστε να περιλαμβάνει κλήσεις στο LLM και στην `callTools`:

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

Τέλεια, ας δούμε τον πλήρη κώδικα:

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

1. Ας προσθέσουμε μερικές εισαγωγές που χρειάζονται για να καλέσουμε ένα LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Έπειτα, ας προσθέσουμε τη συνάρτηση που θα καλέσει το LLM:

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

    Στον παραπάνω κώδικα έχουμε:

    - Περνάμε τις συναρτήσεις που βρήκαμε στον MCP διακομιστή και μετατρέψαμε, στο LLM.
    - Έπειτα καλούμε το LLM με αυτές τις συναρτήσεις.
    - Μετά, ελέγχουμε το αποτέλεσμα για να δούμε ποιες συναρτήσεις πρέπει να καλέσουμε, αν υπάρχουν.
    - Τέλος, περνάμε έναν πίνακα συναρτήσεων για κλήση.

1. Τελευταίο βήμα, ας ενημερώσουμε τον κύριο κώδικα:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Αυτό ήταν το τελικό βήμα, στον παραπάνω κώδικα:

    - Καλούμε ένα εργαλείο MCP μέσω `call_tool` χρησιμοποιώντας μια συνάρτηση που το LLM θεώρησε ότι πρέπει να καλέσουμε βάσει του prompt μας.
    - Εκτυπώνουμε το αποτέλεσμα της κλήσης εργαλείου στον MCP διακομιστή.

### .NET

1. Ας δείξουμε λίγο κώδικα για να κάνουμε ένα αίτημα prompt σε LLM:

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

    Στον παραπάνω κώδικα έχουμε:

    - Φέρει εργαλεία από τον MCP διακομιστή, `var tools = await GetMcpTools()`.
    - Ορίσει ένα prompt χρήστη `userMessage`.
    - Δημιουργήσει ένα αντικείμενο επιλογών που καθορίζει μοντέλο και εργαλεία.
    - Κάνει ένα αίτημα προς το LLM.

1. Ένα τελευταίο βήμα, ας δούμε αν το LLM θεωρεί ότι πρέπει να καλέσουμε μια συνάρτηση:

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

    Στον παραπάνω κώδικα έχουμε:

    - Κάνει βρόχο σε μια λίστα κλήσεων συναρτήσεων.
    - Για κάθε κλήση εργαλείου, αναλύει όνομα και ορίσματα και καλεί το εργαλείο στον MCP διακομιστή χρησιμοποιώντας τον MCP πελάτη. Τέλος, εκτυπώνει τα αποτελέσματα.

Ο πλήρης κώδικας:

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

Στον παραπάνω κώδικα έχουμε:

- Χρησιμοποιήσει απλά prompts φυσικής γλώσσας για αλληλεπίδραση με τα εργαλεία του MCP διακομιστή
- Το πλαίσιο LangChain4j διαχειρίζεται αυτόματα:
  - Τη μετατροπή των prompts σε κλήσεις εργαλείων όταν χρειάζεται
  - Την κλήση των κατάλληλων εργαλείων MCP βάσει της απόφασης του LLM
  - Τη διαχείριση της ροής συνομιλίας μεταξύ LLM και MCP διακομιστή
- Η μέθοδος `bot.chat()` επιστρέφει απαντήσεις σε φυσική γλώσσα που μπορεί να περιλαμβάνουν αποτελέσματα από εκτελέσεις εργαλείων MCP
- Αυτή η προσέγγιση προσφέρει μια απρόσκοπτη εμπειρία χρήστη όπου οι χρήστες δεν χρειάζεται να γνωρίζουν την υποκείμενη υλοποίηση MCP

Πλήρες παράδειγμα κώδικα:

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

Τέλεια, τα καταφέρατε!

## Ανάθεση

Πάρτε τον κώδικα από την άσκηση και αναπτύξτε τον διακομιστή με περισσότερα εργαλεία. Έπειτα δημιουργήστε έναν πελάτη με LLM, όπως στην άσκηση, και δοκιμάστε τον με διαφορετικά prompts για να βεβαιωθείτε ότι όλα τα εργαλεία του διακομιστή καλούνται δυναμικά. Αυτός ο τρόπος δημιουργίας πελάτη σημαίνει ότι ο τελικός χρήστης θα έχει εξαιρε

**Αποποίηση ευθυνών**:  
Αυτό το έγγραφο έχει μεταφραστεί χρησιμοποιώντας την υπηρεσία αυτόματης μετάφρασης AI [Co-op Translator](https://github.com/Azure/co-op-translator). Παρόλο που επιδιώκουμε την ακρίβεια, παρακαλούμε να γνωρίζετε ότι οι αυτόματες μεταφράσεις ενδέχεται να περιέχουν λάθη ή ανακρίβειες. Το πρωτότυπο έγγραφο στη γλώσσα του θεωρείται η αυθεντική πηγή. Για κρίσιμες πληροφορίες, συνιστάται επαγγελματική ανθρώπινη μετάφραση. Δεν φέρουμε ευθύνη για τυχόν παρεξηγήσεις ή λανθασμένες ερμηνείες που προκύπτουν από τη χρήση αυτής της μετάφρασης.