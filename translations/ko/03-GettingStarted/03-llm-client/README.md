<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a656dbc7648e07da08eb4d1ffde4938e",
  "translation_date": "2025-07-22T08:02:09+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ko"
}
-->
# LLM을 사용한 클라이언트 생성

지금까지 서버와 클라이언트를 생성하는 방법을 살펴보았습니다. 클라이언트는 서버에 명시적으로 호출하여 도구, 리소스 및 프롬프트를 나열할 수 있었습니다. 하지만 이는 실용적인 접근 방식이 아닙니다. 사용자는 에이전트 시대에 살고 있으며, 자연어 프롬프트를 사용하여 LLM과 소통하기를 기대합니다. 사용자는 MCP를 사용하여 기능을 저장하는지 여부에는 관심이 없지만, 자연어를 통해 상호작용하기를 원합니다. 그렇다면 이를 어떻게 해결할 수 있을까요? 해결책은 클라이언트에 LLM을 추가하는 것입니다.

## 개요

이 강의에서는 클라이언트에 LLM을 추가하는 방법에 중점을 두고, 이를 통해 사용자 경험을 어떻게 개선할 수 있는지 보여줍니다.

## 학습 목표

이 강의를 마치면 다음을 할 수 있습니다:

- LLM을 사용하는 클라이언트를 생성합니다.
- LLM을 사용하여 MCP 서버와 원활하게 상호작용합니다.
- 클라이언트 측에서 더 나은 사용자 경험을 제공합니다.

## 접근 방식

우리가 취해야 할 접근 방식을 이해해 봅시다. LLM을 추가하는 것은 간단해 보이지만, 실제로는 어떻게 해야 할까요?

클라이언트가 서버와 상호작용하는 방식은 다음과 같습니다:

1. 서버와 연결을 설정합니다.

1. 기능, 프롬프트, 리소스 및 도구를 나열하고 해당 스키마를 저장합니다.

1. LLM을 추가하고 저장된 기능과 스키마를 LLM이 이해할 수 있는 형식으로 전달합니다.

1. 사용자 프롬프트를 처리하고, 이를 클라이언트가 나열한 도구와 함께 LLM에 전달합니다.

좋습니다. 이제 높은 수준에서 이를 어떻게 수행할 수 있는지 이해했으니, 아래 연습에서 이를 시도해 봅시다.

## 연습: LLM을 사용하는 클라이언트 생성

이 연습에서는 클라이언트에 LLM을 추가하는 방법을 배웁니다.

### GitHub 개인 액세스 토큰을 사용한 인증

GitHub 토큰을 생성하는 과정은 간단합니다. 다음 단계를 따르세요:

- GitHub 설정으로 이동 – 오른쪽 상단의 프로필 사진을 클릭하고 설정(Settings)을 선택합니다.
- 개발자 설정으로 이동 – 아래로 스크롤하여 개발자 설정(Developer Settings)을 클릭합니다.
- 개인 액세스 토큰 선택 – 개인 액세스 토큰(Personal access tokens)을 클릭한 후 새 토큰 생성(Generate new token)을 선택합니다.
- 토큰 구성 – 참조용 메모를 추가하고, 만료 날짜를 설정하며, 필요한 범위(권한)를 선택합니다.
- 토큰 생성 및 복사 – 토큰 생성(Generate token)을 클릭하고 즉시 복사하세요. 나중에 다시 볼 수 없습니다.

### -1- 서버에 연결

먼저 클라이언트를 생성해 봅시다:

#### TypeScript

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

위 코드에서 우리는 다음을 수행했습니다:

- 필요한 라이브러리를 가져왔습니다.
- 클라이언트와 LLM과 상호작용을 관리하는 두 멤버 `client`와 `openai`를 포함하는 클래스를 생성했습니다.
- `baseUrl`을 설정하여 GitHub 모델을 사용하도록 LLM 인스턴스를 구성했습니다.

#### Python

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

위 코드에서 우리는 다음을 수행했습니다:

- MCP에 필요한 라이브러리를 가져왔습니다.
- 클라이언트를 생성했습니다.

#### .NET

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

#### Java

먼저, `pom.xml` 파일에 LangChain4j 종속성을 추가해야 합니다. MCP 통합 및 GitHub 모델 지원을 활성화하려면 다음 종속성을 추가하세요:

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

그런 다음 Java 클라이언트 클래스를 생성하세요:

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

위 코드에서 우리는 다음을 수행했습니다:

- **LangChain4j 종속성 추가**: MCP 통합, OpenAI 공식 클라이언트 및 GitHub 모델 지원에 필요
- **LangChain4j 라이브러리 가져오기**: MCP 통합 및 OpenAI 채팅 모델 기능을 위해
- **`ChatLanguageModel` 생성**: GitHub 토큰을 사용하여 GitHub 모델을 사용하도록 구성
- **HTTP 전송 설정**: 서버-발송 이벤트(SSE)를 사용하여 MCP 서버에 연결
- **MCP 클라이언트 생성**: 서버와의 통신을 처리
- **LangChain4j의 내장 MCP 지원 사용**: LLM과 MCP 서버 간의 통합을 단순화

좋습니다. 다음 단계로 서버의 기능을 나열해 봅시다.

### -2- 서버 기능 나열

이제 서버에 연결하고 기능을 요청해 봅시다:

#### TypeScript

같은 클래스에 다음 메서드를 추가하세요:

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

위 코드에서 우리는 다음을 수행했습니다:

- 서버에 연결하는 `connectToServer` 코드를 추가했습니다.
- 앱 흐름을 처리하는 `run` 메서드를 생성했습니다. 현재는 도구만 나열하지만, 곧 더 많은 기능을 추가할 것입니다.

#### Python

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

추가한 내용은 다음과 같습니다:

- 리소스와 도구를 나열하고 이를 출력했습니다. 도구의 경우 나중에 사용할 `inputSchema`도 나열했습니다.

#### .NET

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

        // TODO: convert tool definition from MCP tool to LLm tool     
    }

    return toolDefinitions;
}
```

위 코드에서 우리는 다음을 수행했습니다:

- MCP 서버에서 사용 가능한 도구를 나열했습니다.
- 각 도구에 대해 이름, 설명 및 스키마를 나열했습니다. 스키마는 곧 도구를 호출하는 데 사용할 것입니다.

#### Java

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

위 코드에서 우리는 다음을 수행했습니다:

- MCP 서버에서 모든 도구를 자동으로 검색하고 등록하는 `McpToolProvider`를 생성했습니다.
- 도구 제공자는 MCP 도구 스키마와 LangChain4j 도구 형식 간의 변환을 내부적으로 처리합니다.
- 이 접근 방식은 수동 도구 나열 및 변환 프로세스를 추상화합니다.

### -3- 서버 기능을 LLM 도구로 변환

서버 기능을 나열한 후 다음 단계는 이를 LLM이 이해할 수 있는 형식으로 변환하는 것입니다. 이를 통해 이러한 기능을 LLM 도구로 제공할 수 있습니다.

#### TypeScript

1. MCP 서버의 응답을 LLM이 사용할 수 있는 도구 형식으로 변환하는 다음 코드를 추가하세요:

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

    위 코드는 MCP 서버의 응답을 LLM이 이해할 수 있는 도구 정의 형식으로 변환합니다.

1. 다음으로 `run` 메서드를 업데이트하여 서버 기능을 나열하세요:

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

    위 코드에서 우리는 `run` 메서드를 업데이트하여 결과를 매핑하고 각 항목에 대해 `openAiToolAdapter`를 호출했습니다.

#### Python

1. 먼저 다음 변환 함수를 생성하세요:

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

    위 함수 `convert_to_llm_tools`는 MCP 도구 응답을 받아 LLM이 이해할 수 있는 형식으로 변환합니다.

1. 다음으로 클라이언트 코드를 업데이트하여 이 함수를 활용하세요:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    여기서 우리는 MCP 도구 응답을 나중에 LLM에 전달할 수 있는 형식으로 변환하는 `convert_to_llm_tool` 호출을 추가했습니다.

#### .NET

1. MCP 도구 응답을 LLM이 이해할 수 있는 형식으로 변환하는 코드를 추가하세요:

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

위 코드에서 우리는 다음을 수행했습니다:

- 이름, 설명 및 입력 스키마를 받는 `ConvertFrom` 함수를 생성했습니다.
- FunctionDefinition을 생성하는 기능을 정의했으며, 이는 ChatCompletionsDefinition에 전달됩니다. 후자는 LLM이 이해할 수 있는 것입니다.

1. 기존 코드를 업데이트하여 위 함수를 활용하는 방법을 살펴봅시다:

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

    위 코드에서 우리는 MCP 도구 응답을 LLM 도구로 변환하는 기능을 업데이트했습니다. 추가한 코드는 다음과 같습니다:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        입력 스키마는 도구 응답의 일부이지만 "properties" 속성에 있으므로 이를 추출해야 합니다. 또한 도구 세부 정보를 사용하여 `ConvertFrom`을 호출합니다. 이제 주요 작업을 완료했으니, 다음으로 사용자 프롬프트를 처리하는 방법을 살펴봅시다.

#### Java

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

위 코드에서 우리는 다음을 수행했습니다:

- 자연어 상호작용을 위한 간단한 `Bot` 인터페이스를 정의했습니다.
- LangChain4j의 `AiServices`를 사용하여 LLM과 MCP 도구 제공자를 자동으로 바인딩했습니다.
- 프레임워크는 MCP 도구 스키마 변환 및 함수 호출을 자동으로 처리합니다.
- 이 접근 방식은 수동 도구 변환을 제거하며, LangChain4j가 MCP 도구를 LLM 호환 형식으로 변환하는 모든 복잡성을 처리합니다.

좋습니다. 이제 사용자 요청을 처리할 준비가 되었으니, 이를 다뤄봅시다.

### -4- 사용자 프롬프트 요청 처리

이 코드 부분에서는 사용자 요청을 처리합니다.

#### TypeScript

1. LLM을 호출하는 데 사용할 메서드를 추가하세요:

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

    위 코드에서 우리는 다음을 수행했습니다:

    - `callTools` 메서드를 추가했습니다.
    - 이 메서드는 LLM 응답을 받아 호출할 도구가 있는지 확인합니다:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - LLM이 호출해야 한다고 표시한 도구를 호출합니다:

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

1. `run` 메서드를 업데이트하여 LLM 호출 및 `callTools` 호출을 포함하세요:

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

좋습니다. 전체 코드를 나열해 봅시다:

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

#### Python

1. LLM 호출에 필요한 일부 가져오기를 추가하세요:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. 다음으로 LLM을 호출하는 함수를 추가하세요:

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

    위 코드에서 우리는 다음을 수행했습니다:

    - MCP 서버에서 찾은 함수와 변환된 함수를 LLM에 전달했습니다.
    - 그런 다음 해당 함수로 LLM을 호출했습니다.
    - 결과를 검사하여 호출할 함수가 있는지 확인했습니다.
    - 마지막으로 호출할 함수 배열을 전달했습니다.

1. 마지막 단계로, 메인 코드를 업데이트하세요:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    위 코드에서 우리는 다음을 수행했습니다:

    - LLM이 제안한 함수로 MCP 도구를 호출했습니다.
    - MCP 서버의 도구 호출 결과를 출력했습니다.

#### .NET

1. LLM 프롬프트 요청을 처리하는 코드를 살펴봅시다:

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

    위 코드에서 우리는 다음을 수행했습니다:

    - MCP 서버에서 도구를 가져왔습니다(`var tools = await GetMcpTools()`).
    - 사용자 프롬프트 `userMessage`를 정의했습니다.
    - 모델과 도구를 지정하는 옵션 객체를 생성했습니다.
    - LLM에 요청을 보냈습니다.

1. 마지막 단계로, LLM이 함수 호출을 제안하는지 확인해 봅시다:

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

    위 코드에서 우리는 다음을 수행했습니다:

    - 함수 호출 목록을 반복했습니다.
    - 각 도구 호출에 대해 이름과 인수를 파싱하고 MCP 클라이언트를 사용하여 MCP 서버에서 도구를 호출했습니다. 마지막으로 결과를 출력했습니다.

전체 코드는 다음과 같습니다:

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

#### Java

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

위 코드에서 우리는 다음을 수행했습니다:

- 간단한 자연어 프롬프트를 사용하여 MCP 서버 도구와 상호작용했습니다.
- LangChain4j 프레임워크는 다음을 자동으로 처리합니다:
  - 사용자 프롬프트를 도구 호출로 변환
  - LLM의 결정에 따라 적절한 MCP 도구 호출
  - LLM과 MCP 서버 간의 대화 흐름 관리
- `bot.chat()` 메서드는 MCP 도구 실행 결과를 포함할 수 있는 자연어 응답을 반환합니다.
- 이 접근 방식은 사용자가 기본 MCP 구현에 대해 알 필요 없이 원활한 사용자 경험을 제공합니다.

전체 코드 예제:

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

좋습니다. 해냈습니다!

## 과제

연습에서 작성한 코드를 사용하여 더 많은 도구를 포함한 서버를 구축하세요. 그런 다음 연습에서처럼 LLM을 사용하는 클라이언트를 생성하고, 다양한 프롬프트로 테스트하여 서버의 모든 도구가 동적으로 호출되는지 확인하세요. 이러한 방식으로 클라이언트를 구축하면 최종 사용자는 정확한 클라이언트 명령 대신 프롬프트를 사용할 수 있으며, MCP 서버가 호출되는지 알 필요 없이 훌륭한 사용자 경험을 제공받을 수 있습니다.

## 솔루션

[솔루션](/03-GettingStarted/03-llm-client/solution/README.md)

## 주요 내용

- 클라이언트에 LLM을 추가하면 MCP 서버와 상호작용하는 더 나은 방법을 제공합니다.
- MCP 서버 응답을 LLM이 이해할 수 있는 형식으로 변환해야 합니다.

## 샘플

- [Java 계산기](../samples/java/calculator/README.md)
- [.Net 계산기](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 계산기](../samples/javascript/README.md)
- [TypeScript 계산기](../samples/typescript/README.md)
- [Python 계산기](../../../../03-GettingStarted/samples/python)

## 추가 자료

## 다음 단계

- 다음: [Visual Studio Code를 사용한 서버 소비](../04-vscode/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확성이 포함될 수 있습니다. 원본 문서의 원어 버전이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우, 전문적인 인간 번역을 권장합니다. 이 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 책임을 지지 않습니다.