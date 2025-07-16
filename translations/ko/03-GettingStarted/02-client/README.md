<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-16T21:49:01+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ko"
}
-->
# 클라이언트 만들기

클라이언트는 MCP 서버와 직접 통신하여 리소스, 도구, 프롬프트를 요청하는 맞춤형 애플리케이션이나 스크립트입니다. 서버와 상호작용하기 위한 그래픽 인터페이스를 제공하는 인스펙터 도구와 달리, 직접 클라이언트를 작성하면 프로그래밍 방식으로 자동화된 상호작용이 가능합니다. 이를 통해 개발자는 MCP 기능을 자신의 워크플로우에 통합하고, 작업을 자동화하며, 특정 요구에 맞춘 맞춤형 솔루션을 구축할 수 있습니다.

## 개요

이 강의에서는 Model Context Protocol(MCP) 생태계 내에서 클라이언트의 개념을 소개합니다. 직접 클라이언트를 작성하고 MCP 서버에 연결하는 방법을 배웁니다.

## 학습 목표

이 강의를 마치면 다음을 할 수 있습니다:

- 클라이언트가 할 수 있는 일을 이해한다.
- 직접 클라이언트를 작성한다.
- 클라이언트를 MCP 서버에 연결하고 테스트하여 서버가 예상대로 작동하는지 확인한다.

## 클라이언트 작성에 필요한 것들

클라이언트를 작성하려면 다음을 수행해야 합니다:

- **올바른 라이브러리 임포트**: 이전과 같은 라이브러리를 사용하지만, 다른 구성 요소를 사용합니다.
- **클라이언트 인스턴스 생성**: 클라이언트 인스턴스를 만들고 선택한 전송 방식에 연결합니다.
- **나열할 리소스 결정**: MCP 서버에는 리소스, 도구, 프롬프트가 있으니 어떤 것을 나열할지 결정합니다.
- **호스트 애플리케이션에 클라이언트 통합**: 서버의 기능을 파악한 후, 사용자가 프롬프트나 명령을 입력하면 해당 서버 기능이 호출되도록 호스트 애플리케이션에 통합합니다.

이제 전체적인 흐름을 이해했으니, 다음으로 예제를 살펴보겠습니다.

### 예제 클라이언트

다음 예제 클라이언트를 살펴봅시다:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

위 코드에서는:

- 라이브러리를 임포트합니다.
- 클라이언트 인스턴스를 생성하고 stdio 전송 방식으로 연결합니다.
- 프롬프트, 리소스, 도구를 나열하고 모두 호출합니다.

이렇게 MCP 서버와 통신할 수 있는 클라이언트가 완성되었습니다.

다음 연습 섹션에서는 각 코드 조각을 자세히 살펴보고 설명하겠습니다.

## 연습: 클라이언트 작성하기

앞서 말했듯이, 코드를 천천히 설명하며 필요하면 직접 코딩해보세요.

### -1- 라이브러리 임포트

필요한 라이브러리를 임포트합시다. 클라이언트와 선택한 전송 프로토콜인 stdio에 대한 참조가 필요합니다. stdio는 로컬 머신에서 실행되는 것을 위한 프로토콜입니다. SSE는 이후 장에서 다룰 또 다른 전송 프로토콜이지만, 지금은 stdio로 계속 진행합니다.

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

Java의 경우, 이전 연습에서 사용한 MCP 서버에 연결하는 클라이언트를 만듭니다. [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java)에서 사용한 동일한 Java Spring Boot 프로젝트 구조를 사용하여 `src/main/java/com/microsoft/mcp/sample/client/` 폴더에 `SDKClient`라는 새 Java 클래스를 만들고 다음 임포트를 추가하세요:

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

다음은 인스턴스 생성 단계입니다.

### -2- 클라이언트 및 전송 인스턴스 생성

전송 인스턴스와 클라이언트 인스턴스를 생성해야 합니다:

### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

위 코드에서는:

- stdio 전송 인스턴스를 생성했습니다. 서버를 찾고 시작하는 방법을 지정하는 명령과 인수를 주목하세요. 클라이언트를 만들 때 필요한 부분입니다.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- 이름과 버전을 지정하여 클라이언트를 인스턴스화했습니다.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- 클라이언트를 선택한 전송 방식에 연결했습니다.

    ```typescript
    await client.connect(transport);
    ```

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

위 코드에서는:

- 필요한 라이브러리를 임포트했습니다.
- 서버를 실행하기 위한 매개변수 객체를 생성했습니다. 클라이언트가 연결할 서버를 실행하는 데 사용합니다.
- `run` 메서드를 정의했으며, 이 메서드는 `stdio_client`를 호출하여 클라이언트 세션을 시작합니다.
- `asyncio.run`에 `run` 메서드를 전달하는 진입점을 만들었습니다.

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

위 코드에서는:

- 필요한 라이브러리를 임포트했습니다.
- stdio 전송을 생성하고 `mcpClient`라는 클라이언트를 만들었습니다. 이 클라이언트를 사용해 MCP 서버의 기능을 나열하고 호출할 수 있습니다.

참고로, "Arguments"에는 *.csproj* 파일이나 실행 파일 경로를 지정할 수 있습니다.

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

위 코드에서는:

- MCP 서버가 실행될 `http://localhost:8080`을 가리키는 SSE 전송을 설정하는 main 메서드를 만들었습니다.
- 전송을 생성자 매개변수로 받는 클라이언트 클래스를 만들었습니다.
- `run` 메서드에서 전송을 사용해 동기 MCP 클라이언트를 생성하고 연결을 초기화했습니다.
- Java Spring Boot MCP 서버와 HTTP 기반 통신에 적합한 SSE(Server-Sent Events) 전송을 사용했습니다.

### -3- 서버 기능 나열하기

이제 클라이언트가 연결할 준비가 되었습니다. 하지만 아직 기능을 나열하지 않으니, 다음으로 기능을 나열해봅시다:

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

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
```

여기서는 사용 가능한 리소스(`list_resources()`)와 도구(`list_tools`)를 나열하고 출력합니다.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

위 예제는 서버의 도구를 나열하는 방법입니다. 각 도구의 이름을 출력합니다.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

위 코드에서는:

- `listTools()`를 호출해 MCP 서버에서 사용 가능한 모든 도구를 가져왔습니다.
- `ping()`을 사용해 서버 연결이 정상인지 확인했습니다.
- `ListToolsResult`는 도구의 이름, 설명, 입력 스키마 등 모든 정보를 포함합니다.

좋습니다, 이제 모든 기능을 가져왔습니다. 그렇다면 언제 이 기능들을 사용할까요? 이 클라이언트는 단순해서 기능을 명시적으로 호출해야 합니다. 다음 장에서는 자체 대형 언어 모델(LLM)에 접근할 수 있는 더 발전된 클라이언트를 만들 예정입니다. 지금은 서버 기능을 호출하는 방법을 살펴봅시다:

### -4- 기능 호출하기

기능을 호출하려면 올바른 인수와 경우에 따라 호출할 이름을 지정해야 합니다.

### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

위 코드에서는:

- 리소스를 읽습니다. `readResource()`를 호출하며 `uri`를 지정합니다. 서버 쪽 코드는 대략 다음과 같습니다:

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    `uri` 값 `file://example.txt`는 서버의 `file://{name}`과 매칭됩니다. `example.txt`가 `name`에 매핑됩니다.

- 도구를 호출합니다. 도구 이름과 인수를 지정하여 호출합니다:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- 프롬프트를 가져옵니다. `getPrompt()`를 호출하며 이름과 인수를 전달합니다. 서버 코드는 다음과 같습니다:

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    따라서 클라이언트 코드는 서버에 선언된 내용과 일치하도록 다음과 같습니다:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

위 코드에서는:

- `greeting`이라는 리소스를 `read_resource`로 호출했습니다.
- `add`라는 도구를 `call_tool`로 호출했습니다.

### C#

1. 도구를 호출하는 코드를 추가해봅시다:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. 결과를 출력하는 코드는 다음과 같습니다:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

위 코드에서는:

- `callTool()` 메서드와 `CallToolRequest` 객체를 사용해 여러 계산기 도구를 호출했습니다.
- 각 도구 호출은 도구 이름과 해당 도구가 요구하는 인수 맵을 지정합니다.
- 서버 도구는 수학 연산을 위한 "a", "b" 같은 특정 매개변수 이름을 기대합니다.
- 결과는 서버 응답을 포함하는 `CallToolResult` 객체로 반환됩니다.

### -5- 클라이언트 실행하기

터미널에서 다음 명령어를 입력해 클라이언트를 실행하세요:

### TypeScript

*package.json*의 "scripts" 섹션에 다음 항목을 추가하세요:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

다음 명령어로 클라이언트를 실행하세요:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

먼저 MCP 서버가 `http://localhost:8080`에서 실행 중인지 확인하세요. 그런 다음 클라이언트를 실행합니다:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

또는 솔루션 폴더 `03-GettingStarted\02-client\solution\java`에 제공된 완성된 클라이언트 프로젝트를 실행할 수 있습니다:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## 과제

이번 과제에서는 배운 내용을 활용해 직접 클라이언트를 만들어 봅니다.

다음 서버를 사용해 클라이언트 코드를 통해 호출해보세요. 서버에 더 흥미로운 기능을 추가할 수 있는지 시도해보세요.

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

이 프로젝트를 참고해 [프롬프트와 리소스 추가 방법](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)을 확인하세요.

또한, [프롬프트와 리소스 호출 방법](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/)도 참고하세요.

## 솔루션

[솔루션](./solution/README.md)

## 주요 내용 정리

이번 장에서 클라이언트에 대해 꼭 기억해야 할 점은 다음과 같습니다:

- 서버의 기능을 탐색하고 호출하는 데 사용할 수 있다.
- 클라이언트가 스스로 시작하면서 서버도 시작할 수 있지만(이번 장처럼), 이미 실행 중인 서버에 연결할 수도 있다.
- 인스펙터 같은 대안과 함께 서버 기능을 테스트하는 훌륭한 방법이다.

## 추가 자료

- [MCP에서 클라이언트 만들기](https://modelcontextprotocol.io/quickstart/client)

## 샘플

- [Java 계산기](../samples/java/calculator/README.md)
- [.Net 계산기](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 계산기](../samples/javascript/README.md)
- [TypeScript 계산기](../samples/typescript/README.md)
- [Python 계산기](../../../../03-GettingStarted/samples/python)

## 다음 단계

- 다음: [LLM을 활용한 클라이언트 만들기](../03-llm-client/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의해 주시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.