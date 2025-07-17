<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abd0832467d9738f53a3b4f0797e5f8d",
  "translation_date": "2025-07-17T07:43:27+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "vi"
}
-->
# Tạo client với LLM

Cho đến nay, bạn đã biết cách tạo một server và một client. Client có thể gọi server một cách rõ ràng để liệt kê các công cụ, tài nguyên và prompt của nó. Tuy nhiên, đây không phải là cách tiếp cận thực tế. Người dùng của bạn đang sống trong thời đại agentic và mong muốn sử dụng prompt và giao tiếp với một LLM để làm điều đó. Với người dùng, họ không quan tâm bạn có dùng MCP để lưu trữ khả năng hay không, nhưng họ mong muốn tương tác bằng ngôn ngữ tự nhiên. Vậy làm thế nào để giải quyết vấn đề này? Giải pháp là thêm một LLM vào client.

## Tổng quan

Trong bài học này, chúng ta tập trung vào việc thêm một LLM vào client và cho thấy cách điều này mang lại trải nghiệm tốt hơn nhiều cho người dùng.

## Mục tiêu học tập

Sau bài học này, bạn sẽ có thể:

- Tạo một client với LLM.
- Tương tác liền mạch với server MCP sử dụng LLM.
- Cung cấp trải nghiệm người dùng tốt hơn ở phía client.

## Cách tiếp cận

Hãy cùng hiểu cách tiếp cận mà chúng ta cần thực hiện. Thêm một LLM nghe có vẻ đơn giản, nhưng liệu chúng ta có thực sự làm được không?

Đây là cách client sẽ tương tác với server:

1. Thiết lập kết nối với server.

2. Liệt kê các khả năng, prompt, tài nguyên và công cụ, sau đó lưu lại schema của chúng.

3. Thêm một LLM và truyền các khả năng đã lưu cùng schema theo định dạng mà LLM hiểu được.

4. Xử lý prompt của người dùng bằng cách chuyển nó cho LLM cùng với các công cụ mà client đã liệt kê.

Tuyệt vời, giờ chúng ta đã hiểu cách thực hiện ở mức độ tổng quát, hãy thử làm trong bài tập dưới đây.

## Bài tập: Tạo client với LLM

Trong bài tập này, chúng ta sẽ học cách thêm một LLM vào client.

## Xác thực bằng GitHub Personal Access Token

Tạo token GitHub là một quá trình đơn giản. Đây là cách bạn có thể làm:

- Vào GitHub Settings – Nhấn vào ảnh đại diện của bạn ở góc trên bên phải và chọn Settings.
- Điều hướng đến Developer Settings – Kéo xuống và nhấn vào Developer Settings.
- Chọn Personal Access Tokens – Nhấn vào Personal access tokens rồi chọn Generate new token.
- Cấu hình Token của bạn – Thêm ghi chú để tham khảo, đặt ngày hết hạn và chọn các phạm vi (quyền) cần thiết.
- Tạo và sao chép Token – Nhấn Generate token, và nhớ sao chép ngay vì bạn sẽ không thể xem lại.

### -1- Kết nối với server

Trước tiên, hãy tạo client của chúng ta:

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

Trong đoạn mã trên, chúng ta đã:

- Import các thư viện cần thiết
- Tạo một class với hai thành viên, `client` và `openai`, giúp quản lý client và tương tác với LLM tương ứng.
- Cấu hình instance LLM để sử dụng GitHub Models bằng cách đặt `baseUrl` trỏ đến API inference.

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

Trong đoạn mã trên, chúng ta đã:

- Import các thư viện cần thiết cho MCP
- Tạo một client

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

Trước tiên, bạn cần thêm các dependencies LangChain4j vào file `pom.xml`. Thêm các dependencies này để kích hoạt tích hợp MCP và hỗ trợ GitHub Models:

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

Sau đó tạo class client Java của bạn:

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

Trong đoạn mã trên, chúng ta đã:

- **Thêm dependencies LangChain4j**: Cần thiết cho tích hợp MCP, client chính thức OpenAI và hỗ trợ GitHub Models
- **Import các thư viện LangChain4j**: Dùng cho tích hợp MCP và chức năng chat model OpenAI
- **Tạo một `ChatLanguageModel`**: Cấu hình để sử dụng GitHub Models với token GitHub của bạn
- **Thiết lập HTTP transport**: Sử dụng Server-Sent Events (SSE) để kết nối với server MCP
- **Tạo một client MCP**: Để xử lý giao tiếp với server
- **Sử dụng hỗ trợ MCP tích hợp sẵn của LangChain4j**: Giúp đơn giản hóa việc tích hợp giữa LLM và server MCP

Tuyệt vời, bước tiếp theo, chúng ta sẽ liệt kê các khả năng trên server.

### -2- Liệt kê khả năng của server

Bây giờ chúng ta sẽ kết nối với server và yêu cầu các khả năng của nó:

### TypeScript

Trong cùng class, thêm các phương thức sau:

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

Trong đoạn mã trên, chúng ta đã:

- Thêm mã để kết nối với server, `connectToServer`.
- Tạo một phương thức `run` chịu trách nhiệm xử lý luồng ứng dụng. Hiện tại nó chỉ liệt kê các công cụ nhưng chúng ta sẽ thêm nhiều hơn sau.

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

Đây là những gì chúng ta đã thêm:

- Liệt kê tài nguyên và công cụ và in ra chúng. Với công cụ, chúng ta cũng liệt kê `inputSchema` để dùng sau.

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

Trong đoạn mã trên, chúng ta đã:

- Liệt kê các công cụ có trên MCP Server
- Với mỗi công cụ, liệt kê tên, mô tả và schema của nó. Phần sau sẽ được dùng để gọi công cụ sau này.

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

Trong đoạn mã trên, chúng ta đã:

- Tạo một `McpToolProvider` tự động phát hiện và đăng ký tất cả công cụ từ server MCP
- Tool provider xử lý việc chuyển đổi giữa schema công cụ MCP và định dạng công cụ của LangChain4j bên trong
- Cách tiếp cận này giúp ẩn đi quá trình liệt kê và chuyển đổi công cụ thủ công

### -3- Chuyển đổi khả năng server thành công cụ LLM

Bước tiếp theo sau khi liệt kê khả năng server là chuyển đổi chúng sang định dạng mà LLM hiểu được. Khi làm xong, chúng ta có thể cung cấp các khả năng này như các công cụ cho LLM.

### TypeScript

1. Thêm đoạn mã sau để chuyển đổi phản hồi từ MCP Server sang định dạng công cụ mà LLM có thể sử dụng:

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

    Đoạn mã trên lấy phản hồi từ MCP Server và chuyển đổi thành định nghĩa công cụ mà LLM có thể hiểu.

1. Tiếp theo, cập nhật phương thức `run` để liệt kê khả năng server:

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

    Trong đoạn mã trên, chúng ta đã cập nhật `run` để duyệt qua kết quả và với mỗi mục gọi `openAiToolAdapter`.

### Python

1. Trước tiên, tạo hàm chuyển đổi sau:

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

    Trong hàm `convert_to_llm_tools` trên, chúng ta lấy phản hồi công cụ MCP và chuyển đổi sang định dạng mà LLM có thể hiểu.

1. Tiếp theo, cập nhật mã client để sử dụng hàm này như sau:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Ở đây, chúng ta thêm lời gọi `convert_to_llm_tool` để chuyển đổi phản hồi công cụ MCP thành thứ có thể cung cấp cho LLM sau này.

### .NET

1. Thêm mã để chuyển đổi phản hồi công cụ MCP thành thứ mà LLM có thể hiểu

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

Trong đoạn mã trên, chúng ta đã:

- Tạo hàm `ConvertFrom` nhận vào tên, mô tả và input schema.
- Định nghĩa chức năng tạo `FunctionDefinition` được truyền vào `ChatCompletionsDefinition`. Phần sau là thứ mà LLM có thể hiểu.

1. Cập nhật một số mã hiện có để tận dụng hàm trên:

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

    Trong đoạn mã trên, chúng ta đã:

    - Cập nhật hàm để chuyển đổi phản hồi công cụ MCP thành công cụ LLM. Hãy chú ý đoạn mã thêm vào:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        Input schema là một phần của phản hồi công cụ nhưng nằm trong thuộc tính "properties", nên cần trích xuất. Hơn nữa, chúng ta gọi `ConvertFrom` với chi tiết công cụ. Giờ đã xong phần xử lý nặng, hãy xem cách gọi khi xử lý prompt người dùng tiếp theo.

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

Trong đoạn mã trên, chúng ta đã:

- Định nghĩa một interface `Bot` đơn giản cho tương tác ngôn ngữ tự nhiên
- Sử dụng `AiServices` của LangChain4j để tự động liên kết LLM với MCP tool provider
- Framework tự động xử lý chuyển đổi schema công cụ và gọi hàm phía sau
- Cách tiếp cận này loại bỏ việc chuyển đổi công cụ thủ công - LangChain4j xử lý toàn bộ phức tạp khi chuyển đổi công cụ MCP sang định dạng tương thích LLM

Tuyệt vời, giờ chúng ta đã sẵn sàng xử lý các yêu cầu từ người dùng, hãy làm phần đó tiếp theo.

### -4- Xử lý yêu cầu prompt của người dùng

Trong phần mã này, chúng ta sẽ xử lý các yêu cầu từ người dùng.

### TypeScript

1. Thêm phương thức dùng để gọi LLM:

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

    Trong đoạn mã trên, chúng ta:

    - Thêm phương thức `callTools`.
    - Phương thức này nhận phản hồi từ LLM và kiểm tra xem công cụ nào được gọi, nếu có:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Gọi công cụ nếu LLM chỉ định cần gọi:

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

1. Cập nhật phương thức `run` để bao gồm lời gọi tới LLM và gọi `callTools`:

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

Tuyệt vời, đây là toàn bộ mã:

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

1. Thêm một số import cần thiết để gọi LLM

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Tiếp theo, thêm hàm gọi LLM:

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

    Trong đoạn mã trên, chúng ta đã:

    - Truyền các hàm mà chúng ta tìm thấy trên server MCP và đã chuyển đổi cho LLM.
    - Gọi LLM với các hàm đó.
    - Kiểm tra kết quả để xem hàm nào cần gọi, nếu có.
    - Cuối cùng, truyền một mảng các hàm cần gọi.

1. Bước cuối cùng, cập nhật mã chính:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Ở đây, bước cuối cùng là:

    - Gọi một công cụ MCP qua `call_tool` sử dụng hàm mà LLM cho rằng nên gọi dựa trên prompt.
    - In kết quả gọi công cụ tới MCP Server.

### .NET

1. Mã ví dụ cho việc gửi yêu cầu prompt tới LLM:

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

    Trong đoạn mã trên, chúng ta đã:

    - Lấy các công cụ từ server MCP, `var tools = await GetMcpTools()`.
    - Định nghĩa prompt người dùng `userMessage`.
    - Tạo đối tượng options chỉ định model và công cụ.
    - Gửi yêu cầu tới LLM.

1. Bước cuối cùng, kiểm tra xem LLM có nghĩ nên gọi hàm nào không:

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

    Trong đoạn mã trên, chúng ta đã:

    - Lặp qua danh sách các lời gọi hàm.
    - Với mỗi lời gọi công cụ, phân tích tên và tham số rồi gọi công cụ trên server MCP bằng client MCP. Cuối cùng in kết quả.

Đây là mã đầy đủ:

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

Trong đoạn mã trên, chúng ta đã:

- Sử dụng prompt ngôn ngữ tự nhiên đơn giản để tương tác với công cụ trên server MCP
- Framework LangChain4j tự động xử lý:
  - Chuyển đổi prompt người dùng thành lời gọi công cụ khi cần
  - Gọi các công cụ MCP phù hợp dựa trên quyết định của LLM
  - Quản lý luồng hội thoại giữa LLM và server MCP
- Phương thức `bot.chat()` trả về phản hồi ngôn ngữ tự nhiên có thể bao gồm kết quả từ việc thực thi công cụ MCP
- Cách tiếp cận này mang lại trải nghiệm liền mạch cho người dùng, họ không cần biết về việc gọi server MCP bên dưới

Ví dụ mã hoàn chỉnh:

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

Tuyệt vời, bạn đã làm được!

## Bài tập về nhà

Lấy mã từ bài tập và xây dựng server với nhiều công cụ hơn. Sau đó tạo một client với LLM như trong bài tập và thử nghiệm với các prompt khác nhau để đảm bảo tất cả công cụ trên server được gọi một cách động. Cách xây dựng client này giúp người dùng cuối có trải nghiệm tuyệt vời vì họ có thể dùng prompt thay vì các lệnh client chính xác và không cần biết có server MCP nào được gọi.

## Giải pháp

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Những điểm chính cần nhớ

- Thêm một LLM vào client giúp người dùng tương tác với server MCP tốt hơn.
- Bạn cần chuyển đổi phản hồi từ server MCP thành thứ mà LLM có thể hiểu.

## Mẫu ví dụ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tài nguyên bổ sung

## Tiếp theo

- Tiếp theo: [Sử dụng server với Visual Studio Code](../04-vscode/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.