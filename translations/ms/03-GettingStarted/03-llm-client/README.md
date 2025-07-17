<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T08:09:17+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ms"
}
-->
# Membina klien dengan LLM

Setakat ini, anda telah melihat cara untuk membina pelayan dan klien. Klien dapat memanggil pelayan secara eksplisit untuk menyenaraikan alat, sumber dan arahan yang ada. Namun, pendekatan ini kurang praktikal. Pengguna anda hidup dalam era agen dan menjangkakan untuk menggunakan arahan dan berkomunikasi dengan LLM untuk berbuat demikian. Bagi pengguna anda, mereka tidak kisah sama ada anda menggunakan MCP atau tidak untuk menyimpan keupayaan anda, tetapi mereka menjangkakan untuk berinteraksi menggunakan bahasa semula jadi. Jadi, bagaimana kita menyelesaikan ini? Penyelesaiannya adalah dengan menambah LLM ke dalam klien.

## Gambaran Keseluruhan

Dalam pelajaran ini, kita akan fokus pada penambahan LLM ke klien anda dan menunjukkan bagaimana ini memberikan pengalaman yang jauh lebih baik untuk pengguna anda.

## Objektif Pembelajaran

Menjelang akhir pelajaran ini, anda akan dapat:

- Membina klien dengan LLM.
- Berinteraksi dengan lancar dengan pelayan MCP menggunakan LLM.
- Memberikan pengalaman pengguna yang lebih baik di pihak klien.

## Pendekatan

Mari kita fahami pendekatan yang perlu diambil. Menambah LLM kedengaran mudah, tetapi adakah kita benar-benar akan melakukannya?

Berikut adalah cara klien akan berinteraksi dengan pelayan:

1. Menjalin sambungan dengan pelayan.

1. Menyenaraikan keupayaan, arahan, sumber dan alat, dan menyimpan skema mereka.

1. Menambah LLM dan menghantar keupayaan yang disimpan serta skema mereka dalam format yang difahami oleh LLM.

1. Mengendalikan arahan pengguna dengan menghantarnya ke LLM bersama-sama dengan alat yang disenaraikan oleh klien.

Bagus, sekarang kita faham bagaimana untuk melakukannya secara umum, mari cuba dalam latihan di bawah.

## Latihan: Membina klien dengan LLM

Dalam latihan ini, kita akan belajar menambah LLM ke klien kita.

## Pengesahan menggunakan GitHub Personal Access Token

Membuat token GitHub adalah proses yang mudah. Berikut adalah caranya:

- Pergi ke GitHub Settings – Klik pada gambar profil anda di sudut kanan atas dan pilih Settings.
- Navigasi ke Developer Settings – Skrol ke bawah dan klik Developer Settings.
- Pilih Personal Access Tokens – Klik pada Personal access tokens dan kemudian Generate new token.
- Konfigurasikan Token Anda – Tambah nota untuk rujukan, tetapkan tarikh luput, dan pilih skop (kebenaran) yang diperlukan.
- Jana dan Salin Token – Klik Generate token, dan pastikan untuk menyalinnya segera kerana anda tidak akan dapat melihatnya lagi.

### -1- Sambung ke pelayan

Mari kita bina klien kita terlebih dahulu:

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

Dalam kod di atas, kita telah:

- Mengimport perpustakaan yang diperlukan
- Membina kelas dengan dua anggota, `client` dan `openai` yang akan membantu kita menguruskan klien dan berinteraksi dengan LLM masing-masing.
- Mengkonfigurasi instans LLM kita untuk menggunakan GitHub Models dengan menetapkan `baseUrl` ke API inferens.

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

Dalam kod di atas, kita telah:

- Mengimport perpustakaan yang diperlukan untuk MCP
- Membina klien

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

Pertama, anda perlu menambah kebergantungan LangChain4j ke dalam fail `pom.xml` anda. Tambah kebergantungan ini untuk membolehkan integrasi MCP dan sokongan GitHub Models:

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

Kemudian bina kelas klien Java anda:

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

Dalam kod di atas, kita telah:

- **Menambah kebergantungan LangChain4j**: Diperlukan untuk integrasi MCP, klien rasmi OpenAI, dan sokongan GitHub Models
- **Mengimport perpustakaan LangChain4j**: Untuk integrasi MCP dan fungsi model chat OpenAI
- **Membina `ChatLanguageModel`**: Dikemaskini untuk menggunakan GitHub Models dengan token GitHub anda
- **Menyediakan pengangkutan HTTP**: Menggunakan Server-Sent Events (SSE) untuk menyambung ke pelayan MCP
- **Membina klien MCP**: Yang akan mengendalikan komunikasi dengan pelayan
- **Menggunakan sokongan MCP terbina dalam LangChain4j**: Yang memudahkan integrasi antara LLM dan pelayan MCP

Bagus, untuk langkah seterusnya, mari kita senaraikan keupayaan pada pelayan.

### -2 Senaraikan keupayaan pelayan

Sekarang kita akan sambung ke pelayan dan minta keupayaannya:

### Typescript

Dalam kelas yang sama, tambah kaedah berikut:

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

Dalam kod di atas, kita telah:

- Menambah kod untuk menyambung ke pelayan, `connectToServer`.
- Membina kaedah `run` yang bertanggungjawab mengendalikan aliran aplikasi kita. Setakat ini ia hanya menyenaraikan alat tetapi kita akan tambah lagi nanti.

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

Ini yang kita tambah:

- Menyenaraikan sumber dan alat dan mencetaknya. Untuk alat, kita juga menyenaraikan `inputSchema` yang akan kita gunakan kemudian.

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

Dalam kod di atas, kita telah:

- Menyenaraikan alat yang tersedia pada Pelayan MCP
- Untuk setiap alat, menyenaraikan nama, penerangan dan skema. Yang terakhir ini akan kita gunakan untuk memanggil alat tidak lama lagi.

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

Dalam kod di atas, kita telah:

- Membina `McpToolProvider` yang secara automatik mengesan dan mendaftar semua alat dari pelayan MCP
- Penyedia alat mengendalikan penukaran antara skema alat MCP dan format alat LangChain4j secara dalaman
- Pendekatan ini mengabstrakkan proses penyenaraian dan penukaran alat secara manual

### -3- Tukar keupayaan pelayan kepada alat LLM

Langkah seterusnya selepas menyenaraikan keupayaan pelayan adalah menukarnya ke dalam format yang difahami oleh LLM. Setelah itu, kita boleh menyediakan keupayaan ini sebagai alat kepada LLM kita.

### TypeScript

1. Tambah kod berikut untuk menukar respons dari Pelayan MCP ke format alat yang boleh digunakan oleh LLM:

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

    Kod di atas mengambil respons dari Pelayan MCP dan menukarnya ke format definisi alat yang difahami oleh LLM.

1. Mari kemaskini kaedah `run` seterusnya untuk menyenaraikan keupayaan pelayan:

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

    Dalam kod di atas, kita mengemaskini kaedah `run` untuk memetakan hasil dan bagi setiap entri memanggil `openAiToolAdapter`.

### Python

1. Pertama, mari bina fungsi penukar berikut

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

    Dalam fungsi `convert_to_llm_tools` di atas, kita mengambil respons alat MCP dan menukarnya ke format yang difahami oleh LLM.

1. Seterusnya, kemaskini kod klien kita untuk menggunakan fungsi ini seperti berikut:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Di sini, kita menambah panggilan ke `convert_to_llm_tool` untuk menukar respons alat MCP kepada sesuatu yang boleh kita berikan kepada LLM kemudian.

### .NET

1. Mari tambah kod untuk menukar respons alat MCP kepada sesuatu yang difahami oleh LLM

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

Dalam kod di atas, kita telah:

- Membina fungsi `ConvertFrom` yang mengambil nama, penerangan dan skema input.
- Mendefinisikan fungsi yang mencipta FunctionDefinition yang dihantar ke ChatCompletionsDefinition. Yang terakhir ini adalah sesuatu yang difahami oleh LLM.

1. Mari lihat bagaimana kita boleh kemaskini kod sedia ada untuk menggunakan fungsi ini:

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

    Dalam kod di atas, kita telah:

    - Mengemaskini fungsi untuk menukar respons alat MCP kepada alat LLM. Mari kita sorot kod yang ditambah:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Skema input adalah sebahagian daripada respons alat tetapi pada atribut "properties", jadi kita perlu ekstrak. Selain itu, kita kini memanggil `ConvertFrom` dengan butiran alat. Setelah selesai kerja berat ini, mari lihat bagaimana panggilan ini digabungkan semasa kita mengendalikan arahan pengguna seterusnya.

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

Dalam kod di atas, kita telah:

- Mendefinisikan antara muka `Bot` yang ringkas untuk interaksi bahasa semula jadi
- Menggunakan `AiServices` LangChain4j untuk mengikat LLM secara automatik dengan penyedia alat MCP
- Rangka kerja secara automatik mengendalikan penukaran skema alat dan panggilan fungsi di belakang tabir
- Pendekatan ini menghapuskan penukaran alat secara manual - LangChain4j mengendalikan semua kerumitan menukar alat MCP ke format yang serasi dengan LLM

Bagus, kita sudah bersedia untuk mengendalikan sebarang permintaan pengguna, jadi mari kita teruskan.

### -4- Mengendalikan permintaan arahan pengguna

Dalam bahagian kod ini, kita akan mengendalikan permintaan pengguna.

### TypeScript

1. Tambah kaedah yang akan digunakan untuk memanggil LLM kita:

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

    Dalam kod di atas kita:

    - Menambah kaedah `callTools`.
    - Kaedah ini mengambil respons LLM dan memeriksa alat apa yang telah dipanggil, jika ada:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Memanggil alat, jika LLM menunjukkan ia perlu dipanggil:

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

1. Kemaskini kaedah `run` untuk memasukkan panggilan ke LLM dan memanggil `callTools`:

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

Bagus, mari lihat kod penuh:

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

1. Mari tambah beberapa import yang diperlukan untuk memanggil LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Seterusnya, tambah fungsi yang akan memanggil LLM:

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

    Dalam kod di atas kita telah:

    - Menghantar fungsi yang kita temui pada pelayan MCP dan telah ditukar kepada LLM.
    - Kemudian memanggil LLM dengan fungsi tersebut.
    - Kemudian memeriksa hasil untuk melihat fungsi apa yang perlu dipanggil, jika ada.
    - Akhir sekali, kita menghantar senarai fungsi untuk dipanggil.

1. Langkah terakhir, kemaskini kod utama kita:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Itu, langkah terakhir, dalam kod di atas kita:

    - Memanggil alat MCP melalui `call_tool` menggunakan fungsi yang LLM fikir kita perlu panggil berdasarkan arahan kita.
    - Mencetak hasil panggilan alat ke Pelayan MCP.

### .NET

1. Mari tunjukkan kod untuk membuat permintaan arahan LLM:

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

    Dalam kod di atas kita telah:

    - Mendapatkan alat dari pelayan MCP, `var tools = await GetMcpTools()`.
    - Mendefinisikan arahan pengguna `userMessage`.
    - Membina objek pilihan yang menentukan model dan alat.
    - Membuat permintaan ke LLM.

1. Satu langkah terakhir, mari lihat jika LLM fikir kita perlu memanggil fungsi:

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

    Dalam kod di atas kita telah:

    - Melalui senarai panggilan fungsi.
    - Untuk setiap panggilan alat, mengurai nama dan argumen dan memanggil alat pada pelayan MCP menggunakan klien MCP. Akhirnya kita cetak hasilnya.

Berikut adalah kod penuh:

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

Dalam kod di atas kita telah:

- Menggunakan arahan bahasa semula jadi yang ringkas untuk berinteraksi dengan alat pelayan MCP
- Rangka kerja LangChain4j secara automatik mengendalikan:
  - Menukar arahan pengguna kepada panggilan alat apabila perlu
  - Memanggil alat MCP yang sesuai berdasarkan keputusan LLM
  - Mengurus aliran perbualan antara LLM dan pelayan MCP
- Kaedah `bot.chat()` mengembalikan respons bahasa semula jadi yang mungkin termasuk hasil dari pelaksanaan alat MCP
- Pendekatan ini memberikan pengalaman pengguna yang lancar di mana pengguna tidak perlu tahu tentang pelaksanaan MCP di belakang tabir

Contoh kod lengkap:

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

Bagus, anda berjaya!

## Tugasan

Ambil kod dari latihan dan bina pelayan dengan lebih banyak alat. Kemudian bina klien dengan LLM, seperti dalam latihan, dan uji dengan pelbagai arahan untuk memastikan semua alat pelayan anda dipanggil secara dinamik. Cara membina klien ini bermakna pengguna akhir akan mendapat pengalaman yang hebat kerana mereka boleh menggunakan arahan, bukannya arahan klien yang tepat, dan tidak perlu tahu tentang pelayan MCP yang dipanggil.

## Penyelesaian

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Perkara Penting

- Menambah LLM ke klien anda memberikan cara yang lebih baik untuk pengguna berinteraksi dengan Pelayan MCP.
- Anda perlu menukar respons Pelayan MCP kepada sesuatu yang difahami oleh LLM.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

## Apa Seterusnya

- Seterusnya: [Menggunakan pelayan dengan Visual Studio Code](../04-vscode/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.