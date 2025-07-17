<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T01:31:58+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "tr"
}
-->
# LLM ile bir istemci oluşturma

Şimdiye kadar bir sunucu ve istemci oluşturmayı gördünüz. İstemci, araçlarını, kaynaklarını ve istemlerini listelemek için sunucuyu açıkça çağırabiliyordu. Ancak bu çok pratik bir yöntem değil. Kullanıcınız ajan çağında yaşıyor ve istemleri kullanarak bir LLM ile iletişim kurmayı bekliyor. Kullanıcınız için yeteneklerinizi depolamak için MCP kullanıp kullanmadığınız önemli değil, ancak doğal dil kullanarak etkileşimde bulunmayı bekliyorlar. Peki bunu nasıl çözeriz? Çözüm, istemciye bir LLM eklemekle ilgili.

## Genel Bakış

Bu derste, istemcinize bir LLM eklemeye odaklanacağız ve bunun kullanıcı deneyimini nasıl çok daha iyi hale getirdiğini göstereceğiz.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Bir LLM ile istemci oluşturmak.
- Bir LLM kullanarak MCP sunucusuyla sorunsuz etkileşim kurmak.
- İstemci tarafında daha iyi bir son kullanıcı deneyimi sunmak.

## Yaklaşım

Almamız gereken yaklaşımı anlamaya çalışalım. Bir LLM eklemek basit görünüyor, ama gerçekten bunu yapacak mıyız?

İstemci sunucuyla şöyle etkileşim kuracak:

1. Sunucu ile bağlantı kurmak.

1. Yetenekleri, istemleri, kaynakları ve araçları listelemek ve bunların şemasını kaydetmek.

1. Bir LLM eklemek ve kaydedilen yetenekleri ve şemalarını LLM’nin anlayacağı bir formatta geçirmek.

1. Kullanıcı istemini, istemcinin listelediği araçlarla birlikte LLM’ye ileterek işlemek.

Harika, şimdi yüksek seviyede nasıl yapacağımızı anladık, aşağıdaki alıştırmada bunu deneyelim.

## Alıştırma: LLM ile bir istemci oluşturma

Bu alıştırmada, istemcimize bir LLM eklemeyi öğreneceğiz.

## GitHub Kişisel Erişim Tokenı ile Kimlik Doğrulama

GitHub tokenı oluşturmak basit bir işlemdir. İşte nasıl yapacağınız:

- GitHub Ayarlarına gidin – Sağ üst köşedeki profil resminize tıklayın ve Ayarlar’ı seçin.
- Geliştirici Ayarlarına gidin – Aşağı kaydırın ve Geliştirici Ayarları’na tıklayın.
- Kişisel Erişim Tokenlarını seçin – Kişisel erişim tokenlarına tıklayın ve ardından Yeni token oluştur’a tıklayın.
- Tokenınızı yapılandırın – Referans için bir not ekleyin, bir son kullanma tarihi belirleyin ve gerekli kapsamları (izinleri) seçin.
- Tokenı oluşturun ve kopyalayın – Token oluştur’a tıklayın ve hemen kopyalayın, çünkü tekrar göremeyeceksiniz.

### -1- Sunucuya bağlanma

Öncelikle istemcimizi oluşturalım:

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

Yukarıdaki kodda:

- Gerekli kütüphaneleri içe aktardık
- `client` ve `openai` olmak üzere iki üyeye sahip bir sınıf oluşturduk; bunlar sırasıyla istemciyi yönetmemize ve bir LLM ile etkileşim kurmamıza yardımcı olacak.
- LLM örneğimizi, `baseUrl`'i inference API’sine işaret edecek şekilde ayarlayarak GitHub Modellerini kullanacak şekilde yapılandırdık.

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

Yukarıdaki kodda:

- MCP için gerekli kütüphaneleri içe aktardık
- Bir istemci oluşturduk

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

Öncelikle, `pom.xml` dosyanıza LangChain4j bağımlılıklarını eklemeniz gerekiyor. MCP entegrasyonu ve GitHub Modelleri desteği için şu bağımlılıkları ekleyin:

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

Sonra Java istemci sınıfınızı oluşturun:

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

Yukarıdaki kodda:

- **LangChain4j bağımlılıklarını ekledik**: MCP entegrasyonu, OpenAI resmi istemcisi ve GitHub Modelleri desteği için gerekli
- **LangChain4j kütüphanelerini içe aktardık**: MCP entegrasyonu ve OpenAI sohbet modeli işlevselliği için
- **GitHub tokenınızla GitHub Modellerini kullanacak şekilde yapılandırılmış bir `ChatLanguageModel` oluşturduk**
- **Sunucuya bağlanmak için Server-Sent Events (SSE) kullanan HTTP taşıma ayarladık**
- **Sunucuyla iletişimi yönetecek bir MCP istemcisi oluşturduk**
- **LangChain4j’nin yerleşik MCP desteğini kullandık**: Bu, LLM’ler ile MCP sunucuları arasındaki entegrasyonu kolaylaştırır

Harika, bir sonraki adım olarak sunucudaki yetenekleri listeleyelim.

### -2- Sunucu yeteneklerini listeleme

Şimdi sunucuya bağlanacağız ve yeteneklerini soracağız:

### TypeScript

Aynı sınıfa aşağıdaki yöntemleri ekleyin:

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

Yukarıdaki kodda:

- Sunucuya bağlanmak için `connectToServer` kodu ekledik.
- Uygulama akışımızı yöneten `run` metodunu oluşturduk. Şimdilik sadece araçları listeliyor, ama yakında daha fazlasını ekleyeceğiz.

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

Eklediklerimiz:

- Kaynakları ve araçları listeledik ve yazdırdık. Araçlar için ayrıca daha sonra kullanacağımız `inputSchema`'yı da listeledik.

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

Yukarıdaki kodda:

- MCP Sunucusunda mevcut araçları listeledik
- Her araç için isim, açıklama ve şemasını listeledik. Şema, araçları çağırmak için kullanacağımız bir şey.

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

Yukarıdaki kodda:

- MCP sunucusundaki tüm araçları otomatik olarak keşfeden ve kaydeden bir `McpToolProvider` oluşturduk
- Araç sağlayıcı, MCP araç şemaları ile LangChain4j’nin araç formatı arasındaki dönüşümü dahili olarak yönetiyor
- Bu yaklaşım, manuel araç listeleme ve dönüştürme sürecini soyutlar

### -3- Sunucu yeteneklerini LLM araçlarına dönüştürme

Sunucu yeteneklerini listeledikten sonra, bunları LLM’nin anlayacağı bir formata dönüştürmemiz gerekiyor. Bunu yaptıktan sonra, bu yetenekleri LLM’ye araç olarak sunabiliriz.

### TypeScript

1. MCP Sunucusundan gelen yanıtı LLM’nin kullanabileceği araç formatına dönüştürmek için aşağıdaki kodu ekleyin:

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

    Yukarıdaki kod, MCP Sunucusundan gelen yanıtı LLM’nin anlayabileceği bir araç tanımı formatına dönüştürür.

1. Sonra, `run` metodunu sunucu yeteneklerini listeleyecek şekilde güncelleyelim:

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

    Yukarıdaki kodda, `run` metodunu sonucu üzerinden geçecek ve her giriş için `openAiToolAdapter` çağıracak şekilde güncelledik.

### Python

1. Öncelikle aşağıdaki dönüştürücü fonksiyonu oluşturalım:

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

    Yukarıdaki `convert_to_llm_tools` fonksiyonunda, MCP araç yanıtını LLM’nin anlayabileceği bir formata dönüştürüyoruz.

1. Sonra, istemci kodumuzu bu fonksiyonu kullanacak şekilde güncelleyelim:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Burada, MCP araç yanıtını LLM’ye besleyebileceğimiz bir şeye dönüştürmek için `convert_to_llm_tool` çağrısı ekliyoruz.

### .NET

1. MCP araç yanıtını LLM’nin anlayabileceği bir şeye dönüştürmek için kod ekleyelim:

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

Yukarıdaki kodda:

- İsim, açıklama ve giriş şemasını alan `ConvertFrom` fonksiyonu oluşturduk.
- Bu fonksiyon, LLM’nin anlayabileceği bir `FunctionDefinition` oluşturuyor ve bunu `ChatCompletionsDefinition`'a geçiriyor.

1. Mevcut kodu bu fonksiyonu kullanacak şekilde nasıl güncelleyebileceğimize bakalım:

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

    Yukarıdaki kodda:

    - MCP araç yanıtını LLM aracına dönüştürmek için fonksiyonu güncelledik. Eklediğimiz kodu vurgulayalım:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Giriş şeması araç yanıtının bir parçası ancak "properties" özelliği altında, bu yüzden çıkarmamız gerekiyor. Ayrıca, `ConvertFrom` fonksiyonunu araç detaylarıyla çağırıyoruz. Artık ağır işleri yaptık, kullanıcı istemini işlerken çağrının nasıl birleştiğine bakalım.

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

Yukarıdaki kodda:

- Doğal dil etkileşimleri için basit bir `Bot` arayüzü tanımladık
- LangChain4j’nin `AiServices` özelliğini kullanarak LLM’yi MCP araç sağlayıcısıyla otomatik olarak bağladık
- Framework, araç şeması dönüşümü ve fonksiyon çağrısını otomatik olarak arka planda yönetiyor
- Bu yaklaşım manuel araç dönüşümünü ortadan kaldırıyor - LangChain4j MCP araçlarını LLM uyumlu formata dönüştürmenin tüm karmaşıklığını hallediyor

Harika, şimdi kullanıcı isteklerini işlemeye hazırız, bunu ele alalım.

### -4- Kullanıcı istemi isteğini işleme

Bu kod bölümünde kullanıcı isteklerini işleyeceğiz.

### TypeScript

1. LLM’yi çağırmak için kullanılacak bir yöntem ekleyin:

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

    Yukarıdaki kodda:

    - `callTools` adında bir yöntem ekledik.
    - Bu yöntem, LLM yanıtını alır ve hangi araçların çağrıldığını kontrol eder, eğer varsa:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - LLM bir aracı çağırması gerektiğini belirtirse, aracı çağırır:

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

1. `run` metodunu LLM çağrılarını ve `callTools` çağrısını içerecek şekilde güncelleyin:

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

Harika, kodun tamamını listeleyelim:

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

1. LLM çağrısı yapmak için gereken bazı importları ekleyelim:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Sonra, LLM’yi çağıracak fonksiyonu ekleyelim:

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

    Yukarıdaki kodda:

    - MCP sunucusunda bulduğumuz ve dönüştürdüğümüz fonksiyonları LLM’ye geçtik.
    - Ardından LLM’yi bu fonksiyonlarla çağırdık.
    - Sonuçları inceleyip hangi fonksiyonların çağrılması gerektiğine baktık.
    - Son olarak çağrılacak fonksiyonların bir dizisini geçtik.

1. Son adım olarak ana kodumuzu güncelleyelim:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    İşte son adım, yukarıdaki kodda:

    - LLM’nin çağırmamız gerektiğini düşündüğü fonksiyonu kullanarak MCP aracını `call_tool` ile çağırıyoruz.
    - Araç çağrısının sonucunu MCP Sunucusuna yazdırıyoruz.

### .NET

1. LLM istemi isteği yapmak için bazı kodlar gösterelim:

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

    Yukarıdaki kodda:

    - MCP sunucusundan araçları aldık, `var tools = await GetMcpTools()`.
    - Bir kullanıcı istemi tanımladık `userMessage`.
    - Model ve araçları belirten bir seçenekler nesnesi oluşturduk.
    - LLM’ye bir istek yaptık.

1. Son bir adım, LLM’nin bir fonksiyon çağırmamız gerektiğini düşünüp düşünmediğine bakalım:

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

    Yukarıdaki kodda:

    - Fonksiyon çağrıları listesini döngüye aldık.
    - Her araç çağrısı için isim ve argümanları ayrıştırdık ve MCP istemcisini kullanarak MCP sunucusundaki aracı çağırdık. Sonuçları yazdırdık.

Kodun tamamı:

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

Yukarıdaki kodda:

- MCP sunucu araçlarıyla etkileşim için basit doğal dil istemleri kullandık
- LangChain4j framework otomatik olarak:
  - Kullanıcı istemlerini gerektiğinde araç çağrılarına dönüştürür
  - LLM’nin kararına göre uygun MCP araçlarını çağırır
  - LLM ile MCP sunucusu arasındaki konuşma akışını yönetir
- `bot.chat()` metodu, MCP araçlarının çalıştırılma sonuçlarını içerebilen doğal dil yanıtları döner
- Bu yaklaşım, kullanıcıların altta yatan MCP uygulamasını bilmeden sorunsuz bir deneyim yaşamasını sağlar

Tam kod örneği:

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

Harika, başardınız!

## Ödev

Alıştırmadaki kodu alın ve sunucuyu birkaç araçla genişletin. Sonra alıştırmadaki gibi bir LLM ile istemci oluşturun ve farklı istemlerle test edin, böylece tüm sunucu araçlarınız dinamik olarak çağrılıyor olsun. Bu şekilde istemci oluşturmak, son kullanıcının tam istemci komutları yerine istemleri kullanarak harika bir deneyim yaşamasını sağlar ve herhangi bir MCP sunucusunun çağrıldığından habersiz olur.

## Çözüm

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Önemli Noktalar

- İstemcinize bir LLM eklemek, kullanıcıların MCP Sunucularıyla daha iyi etkileşim kurmasını sağlar.
- MCP Sunucu yanıtını LLM’nin anlayabileceği bir formata dönüştürmeniz gerekir.

## Örnekler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ek Kaynaklar

## Sonraki Adım

- Sonraki: [Visual Studio Code kullanarak bir sunucu tüketmek](../04-vscode/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.