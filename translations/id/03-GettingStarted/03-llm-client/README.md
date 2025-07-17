<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T07:56:33+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "id"
}
-->
# Membuat client dengan LLM

Sejauh ini, Anda telah melihat cara membuat server dan client. Client dapat memanggil server secara eksplisit untuk menampilkan daftar tools, resources, dan prompts yang tersedia. Namun, pendekatan ini kurang praktis. Pengguna Anda hidup di era agentik dan mengharapkan bisa menggunakan prompt serta berkomunikasi dengan LLM untuk melakukannya. Bagi pengguna Anda, mereka tidak peduli apakah Anda menggunakan MCP atau tidak untuk menyimpan kapabilitas Anda, tapi mereka mengharapkan bisa berinteraksi menggunakan bahasa alami. Jadi, bagaimana kita menyelesaikan ini? Solusinya adalah dengan menambahkan LLM ke client.

## Gambaran Umum

Dalam pelajaran ini kita fokus pada penambahan LLM ke client dan menunjukkan bagaimana ini memberikan pengalaman yang jauh lebih baik bagi pengguna Anda.

## Tujuan Pembelajaran

Pada akhir pelajaran ini, Anda akan mampu:

- Membuat client dengan LLM.
- Berinteraksi secara mulus dengan server MCP menggunakan LLM.
- Memberikan pengalaman pengguna yang lebih baik di sisi client.

## Pendekatan

Mari kita pahami pendekatan yang perlu kita ambil. Menambahkan LLM terdengar sederhana, tapi apakah kita benar-benar akan melakukannya?

Berikut cara client akan berinteraksi dengan server:

1. Membuat koneksi dengan server.

1. Menampilkan daftar kapabilitas, prompt, resources, dan tools, lalu menyimpan skema mereka.

1. Menambahkan LLM dan mengoper kapabilitas yang sudah disimpan beserta skemanya dalam format yang dimengerti LLM.

1. Menangani prompt pengguna dengan meneruskannya ke LLM bersama dengan tools yang terdaftar di client.

Bagus, sekarang kita sudah paham bagaimana cara melakukannya secara garis besar, mari kita coba dalam latihan berikut.

## Latihan: Membuat client dengan LLM

Dalam latihan ini, kita akan belajar menambahkan LLM ke client kita.

## Autentikasi menggunakan GitHub Personal Access Token

Membuat token GitHub adalah proses yang mudah. Berikut caranya:

- Buka GitHub Settings – Klik foto profil Anda di pojok kanan atas dan pilih Settings.
- Navigasi ke Developer Settings – Gulir ke bawah dan klik Developer Settings.
- Pilih Personal Access Tokens – Klik Personal access tokens lalu Generate new token.
- Konfigurasikan Token Anda – Tambahkan catatan untuk referensi, atur tanggal kedaluwarsa, dan pilih scope (izin) yang diperlukan.
- Generate dan Salin Token – Klik Generate token, dan pastikan untuk segera menyalinnya karena Anda tidak akan bisa melihatnya lagi.

### -1- Menghubungkan ke server

Mari kita buat client kita terlebih dahulu:

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

Dalam kode di atas kita telah:

- Mengimpor library yang dibutuhkan
- Membuat kelas dengan dua anggota, `client` dan `openai` yang akan membantu kita mengelola client dan berinteraksi dengan LLM secara berturut-turut.
- Mengonfigurasi instance LLM kita untuk menggunakan GitHub Models dengan mengatur `baseUrl` ke API inference.

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

Dalam kode di atas kita telah:

- Mengimpor library yang dibutuhkan untuk MCP
- Membuat client

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

Pertama, Anda perlu menambahkan dependensi LangChain4j ke file `pom.xml` Anda. Tambahkan dependensi ini untuk mengaktifkan integrasi MCP dan dukungan GitHub Models:

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

Kemudian buat kelas client Java Anda:

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

Dalam kode di atas kita telah:

- **Menambahkan dependensi LangChain4j**: Diperlukan untuk integrasi MCP, client resmi OpenAI, dan dukungan GitHub Models
- **Mengimpor library LangChain4j**: Untuk integrasi MCP dan fungsi model chat OpenAI
- **Membuat `ChatLanguageModel`**: Dikustomisasi untuk menggunakan GitHub Models dengan token GitHub Anda
- **Mengatur HTTP transport**: Menggunakan Server-Sent Events (SSE) untuk terhubung ke server MCP
- **Membuat client MCP**: Yang akan menangani komunikasi dengan server
- **Menggunakan dukungan MCP bawaan LangChain4j**: Yang menyederhanakan integrasi antara LLM dan server MCP

Bagus, untuk langkah berikutnya, mari kita tampilkan kapabilitas yang ada di server.

### -2 Menampilkan kapabilitas server

Sekarang kita akan menghubungkan ke server dan meminta daftar kapabilitasnya:

### TypeScript

Di kelas yang sama, tambahkan metode berikut:

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

Dalam kode di atas kita telah:

- Menambahkan kode untuk menghubungkan ke server, `connectToServer`.
- Membuat metode `run` yang bertanggung jawab mengatur alur aplikasi kita. Saat ini hanya menampilkan daftar tools tapi kita akan menambahkan lebih banyak nanti.

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

Berikut yang kita tambahkan:

- Menampilkan resources dan tools serta mencetaknya. Untuk tools kita juga menampilkan `inputSchema` yang akan kita gunakan nanti.

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

Dalam kode di atas kita telah:

- Menampilkan tools yang tersedia di MCP Server
- Untuk setiap tool, menampilkan nama, deskripsi, dan skemanya. Skema ini akan kita gunakan untuk memanggil tools nanti.

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

Dalam kode di atas kita telah:

- Membuat `McpToolProvider` yang secara otomatis menemukan dan mendaftarkan semua tools dari server MCP
- Penyedia tool ini menangani konversi antara skema tool MCP dan format tool LangChain4j secara internal
- Pendekatan ini menghilangkan kebutuhan listing dan konversi tool secara manual

### -3- Mengonversi kapabilitas server menjadi tools LLM

Langkah berikutnya setelah menampilkan kapabilitas server adalah mengonversinya ke format yang dimengerti LLM. Setelah itu, kita bisa menyediakan kapabilitas ini sebagai tools untuk LLM kita.

### TypeScript

1. Tambahkan kode berikut untuk mengonversi respons dari MCP Server ke format tool yang bisa digunakan LLM:

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

    Kode di atas mengambil respons dari MCP Server dan mengonversinya ke format definisi tool yang dimengerti LLM.

1. Selanjutnya, kita perbarui metode `run` untuk menampilkan kapabilitas server:

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

    Dalam kode di atas, kita memperbarui metode `run` untuk memetakan hasil dan untuk setiap entri memanggil `openAiToolAdapter`.

### Python

1. Pertama, buat fungsi konverter berikut:

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

    Dalam fungsi `convert_to_llm_tools` di atas, kita mengambil respons tool MCP dan mengonversinya ke format yang dimengerti LLM.

1. Selanjutnya, perbarui kode client kita untuk memanfaatkan fungsi ini seperti berikut:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Di sini, kita menambahkan pemanggilan `convert_to_llm_tool` untuk mengonversi respons tool MCP menjadi sesuatu yang bisa kita berikan ke LLM nanti.

### .NET

1. Tambahkan kode untuk mengonversi respons tool MCP menjadi sesuatu yang dimengerti LLM

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

Dalam kode di atas kita telah:

- Membuat fungsi `ConvertFrom` yang menerima nama, deskripsi, dan skema input.
- Mendefinisikan fungsi yang membuat `FunctionDefinition` yang diteruskan ke `ChatCompletionsDefinition`. Ini adalah sesuatu yang dimengerti LLM.

1. Mari kita lihat bagaimana memperbarui kode yang ada untuk memanfaatkan fungsi ini:

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

    Dalam kode di atas, kita:

    - Memperbarui fungsi untuk mengonversi respons tool MCP menjadi tool LLM. Berikut bagian kode yang kita tambahkan:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Skema input adalah bagian dari respons tool tapi ada di atribut "properties", jadi kita perlu mengekstraknya. Selanjutnya, kita memanggil `ConvertFrom` dengan detail tool. Setelah pekerjaan berat selesai, mari kita lihat bagaimana pemanggilan ini berjalan saat kita menangani prompt pengguna.

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

Dalam kode di atas kita telah:

- Mendefinisikan interface sederhana `Bot` untuk interaksi bahasa alami
- Menggunakan `AiServices` LangChain4j untuk mengikat LLM secara otomatis dengan penyedia tool MCP
- Framework secara otomatis menangani konversi skema tool dan pemanggilan fungsi di belakang layar
- Pendekatan ini menghilangkan kebutuhan konversi tool manual - LangChain4j menangani semua kompleksitas mengonversi tools MCP ke format yang kompatibel dengan LLM

Bagus, sekarang kita siap menangani permintaan pengguna, mari kita lanjutkan.

### -4- Menangani permintaan prompt pengguna

Di bagian kode ini, kita akan menangani permintaan dari pengguna.

### TypeScript

1. Tambahkan metode yang akan digunakan untuk memanggil LLM kita:

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

    Dalam kode di atas kita:

    - Menambahkan metode `callTools`.
    - Metode ini menerima respons LLM dan memeriksa tools apa yang dipanggil, jika ada:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Memanggil tool jika LLM menunjukkan harus dipanggil:

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

1. Perbarui metode `run` untuk memasukkan pemanggilan LLM dan `callTools`:

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

Bagus, berikut kode lengkapnya:

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

1. Tambahkan beberapa import yang dibutuhkan untuk memanggil LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Selanjutnya, tambahkan fungsi yang akan memanggil LLM:

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

    Dalam kode di atas kita telah:

    - Meneruskan fungsi-fungsi yang kita temukan di server MCP dan sudah dikonversi ke LLM.
    - Memanggil LLM dengan fungsi-fungsi tersebut.
    - Memeriksa hasil untuk melihat fungsi apa yang harus dipanggil, jika ada.
    - Terakhir, meneruskan array fungsi yang harus dipanggil.

1. Langkah terakhir, perbarui kode utama kita:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Nah, itu adalah langkah terakhir, dalam kode di atas kita:

    - Memanggil tool MCP melalui `call_tool` menggunakan fungsi yang dipilih LLM berdasarkan prompt kita.
    - Mencetak hasil pemanggilan tool ke server MCP.

### .NET

1. Berikut contoh kode untuk melakukan permintaan prompt ke LLM:

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

    Dalam kode di atas kita telah:

    - Mengambil tools dari server MCP, `var tools = await GetMcpTools()`.
    - Mendefinisikan prompt pengguna `userMessage`.
    - Membuat objek opsi yang menentukan model dan tools.
    - Membuat permintaan ke LLM.

1. Langkah terakhir, mari kita lihat apakah LLM menganggap kita harus memanggil fungsi:

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

    Dalam kode di atas kita telah:

    - Melakukan loop pada daftar pemanggilan fungsi.
    - Untuk setiap pemanggilan tool, mengurai nama dan argumen lalu memanggil tool di server MCP menggunakan client MCP. Terakhir, mencetak hasilnya.

Berikut kode lengkapnya:

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

Dalam kode di atas kita telah:

- Menggunakan prompt bahasa alami sederhana untuk berinteraksi dengan tools server MCP
- Framework LangChain4j secara otomatis menangani:
  - Mengonversi prompt pengguna menjadi pemanggilan tool saat diperlukan
  - Memanggil tools MCP yang sesuai berdasarkan keputusan LLM
  - Mengelola alur percakapan antara LLM dan server MCP
- Metode `bot.chat()` mengembalikan respons bahasa alami yang mungkin termasuk hasil eksekusi tools MCP
- Pendekatan ini memberikan pengalaman pengguna yang mulus di mana pengguna tidak perlu tahu tentang implementasi MCP di belakang layar

Contoh kode lengkap:

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

Bagus, Anda berhasil!

## Tugas

Ambil kode dari latihan dan kembangkan server dengan beberapa tools tambahan. Kemudian buat client dengan LLM, seperti di latihan, dan uji dengan berbagai prompt untuk memastikan semua tools server Anda dapat dipanggil secara dinamis. Cara membangun client seperti ini membuat pengguna akhir mendapatkan pengalaman yang hebat karena mereka bisa menggunakan prompt, bukan perintah client yang tepat, dan tidak perlu tahu ada server MCP yang dipanggil.

## Solusi

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Poin Penting

- Menambahkan LLM ke client Anda memberikan cara yang lebih baik bagi pengguna untuk berinteraksi dengan server MCP.
- Anda perlu mengonversi respons server MCP ke sesuatu yang dimengerti LLM.

## Contoh

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Sumber Tambahan

## Selanjutnya

- Selanjutnya: [Menggunakan server dengan Visual Studio Code](../04-vscode/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diketahui bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.