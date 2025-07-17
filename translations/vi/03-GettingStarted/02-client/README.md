<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:07:13+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "vi"
}
-->
# Tạo một client

Client là các ứng dụng tùy chỉnh hoặc script giao tiếp trực tiếp với MCP Server để yêu cầu tài nguyên, công cụ và prompt. Khác với việc sử dụng công cụ inspector, vốn cung cấp giao diện đồ họa để tương tác với server, việc viết client riêng cho phép tương tác theo cách lập trình và tự động hóa. Điều này giúp các nhà phát triển tích hợp khả năng của MCP vào quy trình làm việc của họ, tự động hóa các tác vụ và xây dựng các giải pháp tùy chỉnh phù hợp với nhu cầu cụ thể.

## Tổng quan

Bài học này giới thiệu khái niệm về client trong hệ sinh thái Model Context Protocol (MCP). Bạn sẽ học cách viết client riêng và kết nối nó với MCP Server.

## Mục tiêu học tập

Sau bài học này, bạn sẽ có thể:

- Hiểu client có thể làm gì.
- Viết client của riêng bạn.
- Kết nối và kiểm tra client với MCP server để đảm bảo server hoạt động như mong đợi.

## Những gì cần làm để viết một client?

Để viết một client, bạn cần thực hiện các bước sau:

- **Import các thư viện phù hợp**. Bạn sẽ sử dụng cùng thư viện như trước, chỉ khác về cách cấu trúc.
- **Khởi tạo một client**. Việc này bao gồm tạo một instance client và kết nối nó với phương thức truyền tải đã chọn.
- **Quyết định tài nguyên nào sẽ liệt kê**. MCP server của bạn có các tài nguyên, công cụ và prompt, bạn cần chọn những gì sẽ liệt kê.
- **Tích hợp client vào ứng dụng chủ**. Khi đã biết khả năng của server, bạn cần tích hợp client vào ứng dụng chủ để khi người dùng nhập prompt hoặc lệnh, tính năng tương ứng trên server được gọi.

Bây giờ, khi đã hiểu tổng quan những gì sẽ làm, hãy xem ví dụ tiếp theo.

### Ví dụ về một client

Hãy xem ví dụ client sau:

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

Trong đoạn mã trên, chúng ta đã:

- Import các thư viện
- Tạo một instance client và kết nối nó sử dụng stdio làm phương thức truyền tải.
- Liệt kê các prompt, tài nguyên và công cụ rồi gọi tất cả.

Vậy là bạn đã có một client có thể giao tiếp với MCP Server.

Hãy dành thời gian ở phần bài tập tiếp theo để phân tích từng đoạn mã và giải thích chi tiết.

## Bài tập: Viết một client

Như đã nói ở trên, hãy dành thời gian giải thích mã, và bạn có thể code theo nếu muốn.

### -1- Import các thư viện

Hãy import các thư viện cần thiết, bạn sẽ cần tham chiếu đến client và giao thức truyền tải đã chọn, stdio. stdio là giao thức dành cho các ứng dụng chạy trên máy cục bộ. SSE là một giao thức truyền tải khác sẽ được giới thiệu trong các chương sau, nhưng hiện tại chúng ta sẽ dùng stdio.

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

Với Java, bạn sẽ tạo một client kết nối đến MCP server từ bài tập trước. Sử dụng cấu trúc dự án Java Spring Boot từ [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), tạo một lớp Java mới tên `SDKClient` trong thư mục `src/main/java/com/microsoft/mcp/sample/client/` và thêm các import sau:

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

Tiếp theo, chúng ta sẽ khởi tạo.

### -2- Khởi tạo client và transport

Chúng ta cần tạo một instance của transport và một instance của client:

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

Trong đoạn mã trên, chúng ta đã:

- Tạo một instance stdio transport. Lưu ý cách nó chỉ định command và args để tìm và khởi động server, điều này cần thiết khi tạo client.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Khởi tạo client bằng cách đặt tên và phiên bản.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Kết nối client với transport đã chọn.

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

Trong đoạn mã trên, chúng ta đã:

- Import các thư viện cần thiết
- Khởi tạo một đối tượng tham số server để dùng chạy server, từ đó client có thể kết nối.
- Định nghĩa phương thức `run` gọi `stdio_client` để bắt đầu phiên client.
- Tạo điểm vào chương trình, cung cấp `run` cho `asyncio.run`.

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

Trong đoạn mã trên, chúng ta đã:

- Import các thư viện cần thiết.
- Tạo một stdio transport và một client `mcpClient`. Client này sẽ dùng để liệt kê và gọi các tính năng trên MCP Server.

Lưu ý, trong phần "Arguments", bạn có thể chỉ đến file *.csproj* hoặc file thực thi.

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

Trong đoạn mã trên, chúng ta đã:

- Tạo phương thức main thiết lập SSE transport trỏ đến `http://localhost:8080` nơi MCP server chạy.
- Tạo lớp client nhận transport làm tham số constructor.
- Trong phương thức `run`, tạo client MCP đồng bộ sử dụng transport và khởi tạo kết nối.
- Sử dụng SSE (Server-Sent Events) phù hợp cho giao tiếp HTTP với MCP server Java Spring Boot.

### -3- Liệt kê các tính năng của server

Bây giờ, chúng ta đã có client có thể kết nối khi chạy chương trình. Tuy nhiên, nó chưa liệt kê các tính năng, hãy làm điều đó tiếp theo:

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

Ở đây, chúng ta liệt kê các tài nguyên có sẵn bằng `list_resources()` và công cụ bằng `list_tools` rồi in ra.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Đây là ví dụ cách liệt kê các công cụ trên server. Với mỗi công cụ, ta in ra tên của nó.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Trong đoạn mã trên, chúng ta đã:

- Gọi `listTools()` để lấy tất cả công cụ có trên MCP server.
- Dùng `ping()` để kiểm tra kết nối với server.
- `ListToolsResult` chứa thông tin về tất cả công cụ, bao gồm tên, mô tả và schema đầu vào.

Tuyệt vời, giờ chúng ta đã lấy được tất cả tính năng. Vậy khi nào dùng chúng? Client này khá đơn giản, nghĩa là bạn phải gọi rõ ràng các tính năng khi cần. Ở chương tiếp theo, chúng ta sẽ tạo client nâng cao hơn có tích hợp mô hình ngôn ngữ lớn (LLM). Còn bây giờ, hãy xem cách gọi các tính năng trên server:

### -4- Gọi các tính năng

Để gọi các tính năng, bạn cần đảm bảo truyền đúng đối số và trong một số trường hợp, tên của tính năng cần gọi.

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

Trong đoạn mã trên, chúng ta đã:

- Đọc một tài nguyên, gọi `readResource()` với `uri`. Đây là cách server xử lý:

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

    Giá trị `uri` của chúng ta là `file://example.txt` khớp với `file://{name}` trên server. `example.txt` sẽ được ánh xạ thành `name`.

- Gọi một công cụ, bằng cách chỉ định `name` và `arguments` như sau:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Lấy prompt, gọi `getPrompt()` với `name` và `arguments`. Mã server như sau:

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

    Và mã client tương ứng sẽ như sau để khớp với khai báo trên server:

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

Trong đoạn mã trên, chúng ta đã:

- Gọi tài nguyên `greeting` bằng `read_resource`.
- Gọi công cụ `add` bằng `call_tool`.

### .NET

1. Thêm mã gọi một công cụ:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

2. Để in kết quả, đây là đoạn mã xử lý:

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

Trong đoạn mã trên, chúng ta đã:

- Gọi nhiều công cụ tính toán bằng phương thức `callTool()` với các đối tượng `CallToolRequest`.
- Mỗi lần gọi công cụ chỉ định tên công cụ và một `Map` các đối số cần thiết.
- Các công cụ trên server yêu cầu tên tham số cụ thể (như "a", "b" cho các phép toán).
- Kết quả trả về là các đối tượng `CallToolResult` chứa phản hồi từ server.

### -5- Chạy client

Để chạy client, gõ lệnh sau trong terminal:

### TypeScript

Thêm đoạn sau vào phần "scripts" trong *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Gọi client với lệnh sau:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Đầu tiên, đảm bảo MCP server đang chạy tại `http://localhost:8080`. Sau đó chạy client:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Ngoài ra, bạn có thể chạy toàn bộ dự án client có sẵn trong thư mục giải pháp `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Bài tập

Trong bài tập này, bạn sẽ sử dụng kiến thức đã học để tạo một client của riêng bạn.

Dưới đây là một server bạn có thể dùng và gọi qua client, thử xem bạn có thể thêm tính năng gì để server thú vị hơn không.

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

Xem dự án này để biết cách [thêm prompt và tài nguyên](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Ngoài ra, xem liên kết này để biết cách gọi [prompt và tài nguyên](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Giải pháp

**Thư mục giải pháp** chứa các triển khai client hoàn chỉnh, sẵn sàng chạy, minh họa tất cả các khái niệm trong hướng dẫn này. Mỗi giải pháp bao gồm mã client và server được tổ chức trong các dự án riêng biệt, độc lập.

### 📁 Cấu trúc giải pháp

Thư mục giải pháp được tổ chức theo ngôn ngữ lập trình:

```
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw            # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 Mỗi giải pháp bao gồm

Mỗi giải pháp theo ngôn ngữ cung cấp:

- **Triển khai client hoàn chỉnh** với tất cả tính năng trong hướng dẫn
- **Cấu trúc dự án hoạt động** với các phụ thuộc và cấu hình phù hợp
- **Script build và chạy** để dễ dàng thiết lập và thực thi
- **README chi tiết** với hướng dẫn riêng cho từng ngôn ngữ
- **Xử lý lỗi** và ví dụ xử lý kết quả

### 📖 Sử dụng các giải pháp

1. **Đi đến thư mục ngôn ngữ bạn chọn**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Theo dõi hướng dẫn trong README** ở mỗi thư mục để:
   - Cài đặt phụ thuộc
   - Build dự án
   - Chạy client

3. **Ví dụ đầu ra bạn sẽ thấy**:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Để xem tài liệu đầy đủ và hướng dẫn từng bước, xem: **[📖 Tài liệu giải pháp](./solution/README.md)**

## 🎯 Ví dụ hoàn chỉnh

Chúng tôi cung cấp các triển khai client hoàn chỉnh, hoạt động cho tất cả ngôn ngữ lập trình được đề cập trong hướng dẫn này. Các ví dụ này minh họa đầy đủ chức năng đã mô tả và có thể dùng làm tham khảo hoặc điểm khởi đầu cho dự án của bạn.

### Ví dụ hoàn chỉnh có sẵn

| Ngôn ngữ | Tệp | Mô tả |
|----------|------|-------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | Client Java hoàn chỉnh sử dụng SSE transport với xử lý lỗi toàn diện |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | Client C# hoàn chỉnh sử dụng stdio transport với tự động khởi động server |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Client TypeScript hoàn chỉnh hỗ trợ đầy đủ giao thức MCP |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | Client Python hoàn chỉnh sử dụng async/await |

Mỗi ví dụ hoàn chỉnh bao gồm:

- ✅ **Thiết lập kết nối** và xử lý lỗi
- ✅ **Khám phá server** (công cụ, tài nguyên, prompt nếu có)
- ✅ **Các phép toán máy tính** (cộng, trừ, nhân, chia, trợ giúp)
- ✅ **Xử lý kết quả** và xuất ra định dạng đẹp
- ✅ **Xử lý lỗi toàn diện**
- ✅ **Mã sạch, có chú thích chi tiết từng bước**

### Bắt đầu với ví dụ hoàn chỉnh

1. **Chọn ngôn ngữ bạn muốn** trong bảng trên
2. **Xem qua tệp ví dụ hoàn chỉnh** để hiểu toàn bộ triển khai
3. **Chạy ví dụ** theo hướng dẫn trong [`complete_examples.md`](./complete_examples.md)
4. **Chỉnh sửa và mở rộng** ví dụ cho trường hợp sử dụng của bạn

Để xem tài liệu chi tiết về cách chạy và tùy chỉnh các ví dụ này, xem: **[📖 Tài liệu ví dụ hoàn chỉnh](./complete_examples.md)**

### 💡 Giải pháp so với ví dụ hoàn chỉnh

| **Thư mục Giải pháp** | **Ví dụ Hoàn chỉnh** |
|-----------------------|---------------------|
| Cấu trúc dự án đầy đủ với file build | Triển khai mã đơn file |
| Sẵn sàng chạy với phụ thuộc | Ví dụ mã tập trung |
| Thiết lập giống môi trường sản xuất | Tham khảo giáo dục |
| Công cụ riêng cho từng ngôn ngữ | So sánh đa ngôn ngữ |
Cả hai phương pháp đều có giá trị - sử dụng **thư mục solution** cho các dự án hoàn chỉnh và **ví dụ hoàn chỉnh** để học tập và tham khảo.

## Những điểm chính cần nhớ

Những điểm chính của chương này về client như sau:

- Có thể được sử dụng để cả khám phá và gọi các tính năng trên server.
- Có thể khởi động một server trong khi chính nó cũng khởi động (như trong chương này), nhưng client cũng có thể kết nối với các server đang chạy.
- Là một cách tuyệt vời để thử nghiệm khả năng của server bên cạnh các lựa chọn khác như Inspector đã được mô tả trong chương trước.

## Tài nguyên bổ sung

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Ví dụ mẫu

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Tiếp theo

- Tiếp theo: [Creating a client with an LLM](../03-llm-client/README.md)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.