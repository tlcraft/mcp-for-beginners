<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-16T21:37:33+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ja"
}
-->
# クライアントの作成

クライアントは、MCPサーバーと直接通信してリソース、ツール、プロンプトを要求するカスタムアプリケーションやスクリプトです。サーバーと対話するためのグラフィカルインターフェースを提供するインスペクターツールとは異なり、自分でクライアントを書くことでプログラム的かつ自動化された操作が可能になります。これにより、開発者はMCPの機能を自分のワークフローに統合し、タスクを自動化し、特定のニーズに合わせたカスタムソリューションを構築できます。

## 概要

このレッスンでは、Model Context Protocol（MCP）エコシステム内のクライアントの概念を紹介します。自分でクライアントを書き、MCPサーバーに接続する方法を学びます。

## 学習目標

このレッスンの終わりまでに、以下ができるようになります：

- クライアントが何をできるか理解する。
- 自分のクライアントを書く。
- MCPサーバーに接続し、クライアントをテストしてサーバーが期待通りに動作することを確認する。

## クライアントを書くには何が必要か？

クライアントを書くには、以下のことを行う必要があります：

- **正しいライブラリをインポートする**。前回と同じライブラリを使いますが、使う構成が異なります。
- **クライアントをインスタンス化する**。クライアントのインスタンスを作成し、選択したトランスポート方法に接続します。
- **どのリソースをリストアップするか決める**。MCPサーバーにはリソース、ツール、プロンプトが用意されているので、どれをリストアップするか決めます。
- **クライアントをホストアプリケーションに統合する**。サーバーの機能を理解したら、ユーザーがプロンプトやコマンドを入力した際に対応するサーバー機能が呼び出されるようにホストアプリケーションに統合します。

大まかにやることがわかったので、次に例を見てみましょう。

### クライアントの例

この例のクライアントを見てみましょう：

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

上記のコードでは：

- ライブラリをインポートしています。
- クライアントのインスタンスを作成し、stdioを使って接続しています。
- プロンプト、リソース、ツールをリストアップし、それらをすべて呼び出しています。

これでMCPサーバーと通信できるクライアントができました。

次の演習セクションでは、コードの各スニペットをじっくり分解して説明していきます。

## 演習：クライアントを書く

前述の通り、コードの説明に時間をかけましょう。もちろん、一緒にコードを書いてみても構いません。

### -1- ライブラリのインポート

必要なライブラリをインポートしましょう。クライアントと選択したトランスポートプロトコルであるstdioの参照が必要です。stdioはローカルマシン上で動作するもの向けのプロトコルです。SSEは別のトランスポートプロトコルで、今後の章で紹介しますが、こちらも選択肢の一つです。今回はstdioで進めます。

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

Javaの場合は、前の演習で使ったMCPサーバーに接続するクライアントを作成します。[Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java)のJava Spring Bootプロジェクト構成を使い、`src/main/java/com/microsoft/mcp/sample/client/`フォルダーに`SDKClient`という新しいJavaクラスを作成し、以下のインポートを追加してください：

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

次はインスタンス化に進みます。

### -2- クライアントとトランスポートのインスタンス化

トランスポートとクライアントのインスタンスを作成する必要があります：

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

上記のコードでは：

- stdioトランスポートのインスタンスを作成しています。コマンドと引数でサーバーの起動方法を指定している点に注目してください。クライアント作成時に必要な処理です。

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- 名前とバージョンを指定してクライアントをインスタンス化しています。

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- クライアントを選択したトランスポートに接続しています。

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

上記のコードでは：

- 必要なライブラリをインポートしています。
- サーバーパラメータオブジェクトをインスタンス化しています。これはサーバーを起動し、クライアントが接続するために使います。
- `run`メソッドを定義し、その中で`stdio_client`を呼び出してクライアントセッションを開始しています。
- エントリーポイントを作成し、`asyncio.run`に`run`メソッドを渡しています。

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

上記のコードでは：

- 必要なライブラリをインポートしています。
- stdioトランスポートを作成し、`mcpClient`というクライアントを作成しています。これはMCPサーバーの機能をリストアップ・呼び出しするために使います。

注意：「Arguments」には*.csproj*ファイルか実行可能ファイルのどちらかを指定できます。

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

上記のコードでは：

- MCPサーバーが動作する`http://localhost:8080`を指すSSEトランスポートをセットアップするmainメソッドを作成しています。
- トランスポートをコンストラクタパラメータに取るクライアントクラスを作成しています。
- `run`メソッド内でトランスポートを使って同期的なMCPクライアントを作成し、接続を初期化しています。
- Java Spring Boot MCPサーバーとのHTTPベース通信に適したSSE（Server-Sent Events）トランスポートを使用しています。

### -3- サーバー機能のリストアップ

プログラムを実行すれば接続できるクライアントができましたが、まだ機能のリストアップはしていません。次にそれを行いましょう：

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

ここでは利用可能なリソースを`list_resources()`、ツールを`list_tools`でリストアップし、出力しています。

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

上記はサーバー上のツールをリストアップする例です。各ツールの名前を出力しています。

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

上記のコードでは：

- `listTools()`を呼び出してMCPサーバーから利用可能なツールを取得しています。
- `ping()`を使ってサーバーとの接続が正常か確認しています。
- `ListToolsResult`にはツールの名前、説明、入力スキーマなどの情報が含まれています。

これで全機能を取得できました。では、これらの機能はいつ使うのでしょうか？このクライアントはシンプルで、使いたい機能を明示的に呼び出す必要があります。次の章では、自身の大規模言語モデル（LLM）にアクセスできるより高度なクライアントを作成します。今回はサーバーの機能を呼び出す方法を見てみましょう。

### -4- 機能の呼び出し

機能を呼び出すには、正しい引数や場合によっては呼び出す名前を指定する必要があります。

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

上記のコードでは：

- リソースを読み込みます。`readResource()`を呼び出し、`uri`を指定しています。サーバー側はおそらく以下のようになっています：

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

    `uri`の値`file://example.txt`はサーバーの`file://{name}`にマッチし、`example.txt`が`name`にマッピングされます。

- ツールを呼び出します。`name`と`arguments`を指定して呼び出します：

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- プロンプトを取得します。`getPrompt()`に`name`と`arguments`を渡して呼び出します。サーバー側は以下のようになっています：

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

    そのため、クライアント側のコードはサーバーの宣言に合わせて以下のようになります：

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

上記のコードでは：

- `greeting`というリソースを`read_resource`で呼び出しています。
- `add`というツールを`call_tool`で呼び出しています。

### C#

1. ツールを呼び出すコードを追加しましょう：

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. 結果を出力するコードは以下の通りです：

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

上記のコードでは：

- `callTool()`メソッドを使い、`CallToolRequest`オブジェクトで複数の計算ツールを呼び出しています。
- 各ツール呼び出しはツール名と、そのツールが必要とする引数の`Map`を指定しています。
- サーバーのツールは特定のパラメーター名（例えば数学演算用の"a"、"b"）を期待しています。
- 結果はサーバーからのレスポンスを含む`CallToolResult`オブジェクトとして返されます。

### -5- クライアントの実行

クライアントを実行するには、ターミナルで以下のコマンドを入力します：

### TypeScript

*package.json*の"scripts"セクションに以下を追加してください：

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

以下のコマンドでクライアントを呼び出します：

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

まず、MCPサーバーが`http://localhost:8080`で動作していることを確認してください。その後クライアントを実行します：

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

または、ソリューションフォルダー`03-GettingStarted\02-client\solution\java`にある完全なクライアントプロジェクトを実行することもできます：

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## 課題

この課題では、学んだことを活かして自分のクライアントを作成します。

以下のサーバーを使ってクライアントコードから呼び出してください。サーバーにさらに機能を追加して、より面白くしてみましょう。

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

このプロジェクトを参照して、[プロンプトやリソースの追加方法](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)を確認してください。

また、[プロンプトやリソースの呼び出し方法](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/)もチェックしてください。

## 解答例

[Solution](./solution/README.md)

## まとめ

この章のクライアントに関する重要なポイントは以下の通りです：

- サーバーの機能を発見し、呼び出すために使える。
- クライアント自身が起動しながらサーバーも起動できる（この章のように）が、既に動作中のサーバーに接続することもできる。
- 前章で説明したインスペクターのような代替手段と並んで、サーバーの機能を試すのに非常に便利な方法である。

## 追加リソース

- [MCPでのクライアント構築](https://modelcontextprotocol.io/quickstart/client)

## サンプル

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## 次にやること

- 次へ：[LLMを使ったクライアントの作成](../03-llm-client/README.md)

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は一切の責任を負いかねます。