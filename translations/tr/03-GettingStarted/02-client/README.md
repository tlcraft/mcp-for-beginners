<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-17T01:30:54+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tr"
}
-->
# Bir istemci oluşturma

İstemciler, kaynaklar, araçlar ve istemler talep etmek için doğrudan bir MCP Sunucusuyla iletişim kuran özel uygulamalar veya betiklerdir. Sunucuyla etkileşim için grafiksel bir arayüz sağlayan inspector aracını kullanmaktan farklı olarak, kendi istemcinizi yazmak programatik ve otomatik etkileşimlere olanak tanır. Bu, geliştiricilerin MCP yeteneklerini kendi iş akışlarına entegre etmelerini, görevleri otomatikleştirmelerini ve belirli ihtiyaçlara göre özelleştirilmiş çözümler geliştirmelerini sağlar.

## Genel Bakış

Bu ders, Model Context Protocol (MCP) ekosisteminde istemci kavramını tanıtır. Kendi istemcinizi nasıl yazacağınızı ve bir MCP Sunucusuna nasıl bağlanacağını öğreneceksiniz.

## Öğrenme Hedefleri

Bu dersin sonunda şunları yapabileceksiniz:

- Bir istemcinin neler yapabileceğini anlamak.
- Kendi istemcinizi yazmak.
- İstemciyi bir MCP sunucusuna bağlayıp test ederek sunucunun beklendiği gibi çalıştığını doğrulamak.

## İstemci yazarken neler yapılmalı?

Bir istemci yazmak için aşağıdakileri yapmanız gerekir:

- **Doğru kütüphaneleri içe aktarın**. Öncekiyle aynı kütüphaneyi kullanacaksınız, sadece farklı yapılar olacak.
- **Bir istemci örneği oluşturun**. Bu, bir istemci örneği yaratmayı ve seçilen taşıma yöntemine bağlamayı içerir.
- **Hangi kaynakların listeleneceğine karar verin**. MCP sunucunuz kaynaklar, araçlar ve istemler içerir; hangilerini listeleyeceğinize karar vermelisiniz.
- **İstemciyi ana uygulamaya entegre edin**. Sunucunun yeteneklerini öğrendikten sonra, kullanıcı bir istem veya başka bir komut yazdığında ilgili sunucu özelliğinin çağrılması için istemciyi ana uygulamanıza entegre etmelisiniz.

Yüksek seviyede ne yapacağımızı anladığımıza göre, şimdi bir örneğe bakalım.

### Örnek bir istemci

Bu örnek istemciye göz atalım:

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

Yukarıdaki kodda:

- Kütüphaneler içe aktarılır.
- Bir istemci örneği oluşturulur ve stdio taşıma yöntemiyle bağlanır.
- İstemler, kaynaklar ve araçlar listelenir ve hepsi çağrılır.

İşte bu kadar, MCP Sunucusuyla konuşabilen bir istemci.

Bir sonraki alıştırma bölümünde her kod parçasını detaylıca inceleyip ne olduğunu açıklayacağız.

## Alıştırma: İstemci yazma

Yukarıda belirtildiği gibi, kodu açıklamak için zaman ayıralım ve isterseniz beraber kodlayabilirsiniz.

### -1- Kütüphaneleri içe aktarma

Gerekli kütüphaneleri içe aktaralım, bir istemci ve seçtiğimiz taşıma protokolü stdio için referanslara ihtiyacımız olacak. stdio, yerel makinenizde çalışması amaçlanan şeyler için bir protokoldür. SSE başka bir taşıma protokolüdür, bunu ilerleyen bölümlerde göstereceğiz ama şimdilik stdio ile devam edelim.

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

Java için, önceki alıştırmadaki MCP sunucusuna bağlanan bir istemci oluşturacaksınız. [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) bölümündeki aynı Java Spring Boot proje yapısını kullanarak, `src/main/java/com/microsoft/mcp/sample/client/` klasöründe `SDKClient` adında yeni bir Java sınıfı oluşturun ve aşağıdaki importları ekleyin:

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

Şimdi örneklemeye geçelim.

### -2- İstemci ve taşıma örneği oluşturma

Taşıma ve istemci örneklerini oluşturmamız gerekecek:

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

Yukarıdaki kodda:

- stdio taşıma örneği oluşturuldu. Komut ve argümanların sunucuyu bulmak ve başlatmak için nasıl belirtildiğine dikkat edin, çünkü istemciyi oluştururken bunu yapmamız gerekecek.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- İstemci, isim ve sürüm verilerek örneklendi.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- İstemci seçilen taşıma yöntemine bağlandı.

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

Yukarıdaki kodda:

- Gerekli kütüphaneler içe aktarıldı.
- Sunucuyu çalıştırmak ve istemciyle bağlanmak için kullanılacak sunucu parametreleri nesnesi örneklendi.
- `stdio_client` çağıran `run` adlı bir metot tanımlandı, bu metot istemci oturumunu başlatır.
- `asyncio.run` ile `run` metodu giriş noktası olarak verildi.

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

Yukarıdaki kodda:

- Gerekli kütüphaneler içe aktarıldı.
- stdio taşıma oluşturuldu ve `mcpClient` adlı bir istemci yaratıldı. Bu istemci MCP Sunucusundaki özellikleri listelemek ve çağırmak için kullanılacak.

Not: "Arguments" kısmında ya *.csproj* dosyasına ya da çalıştırılabilir dosyaya işaret edebilirsiniz.

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

Yukarıdaki kodda:

- MCP sunucumuzun çalışacağı `http://localhost:8080` adresine işaret eden SSE taşıma ayarlandı.
- Taşıma parametresi alan bir istemci sınıfı oluşturuldu.
- `run` metodunda taşıma kullanılarak eşzamanlı bir MCP istemcisi yaratıldı ve bağlantı başlatıldı.
- Java Spring Boot MCP sunucularıyla HTTP tabanlı iletişim için uygun olan SSE (Server-Sent Events) taşıma kullanıldı.

### -3- Sunucu özelliklerini listeleme

Artık program çalıştırıldığında bağlanabilen bir istemcimiz var. Ancak özellikleri listelemiyor, şimdi bunu yapalım:

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

Burada mevcut kaynakları `list_resources()`, araçları `list_tools` ile listeliyoruz ve yazdırıyoruz.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Yukarıda sunucudaki araçları nasıl listeleyebileceğimize dair bir örnek var. Her araç için adını yazdırıyoruz.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Yukarıdaki kodda:

- MCP sunucusundan tüm mevcut araçları almak için `listTools()` çağrıldı.
- Bağlantının çalıştığını doğrulamak için `ping()` kullanıldı.
- `ListToolsResult`, araçların isimleri, açıklamaları ve giriş şemaları dahil tüm bilgileri içerir.

Harika, şimdi tüm özellikleri yakaladık. Peki, ne zaman kullanacağız? Bu istemci oldukça basit; özellikleri kullanmak istediğimizde açıkça çağırmamız gerekiyor. Bir sonraki bölümde, kendi büyük dil modeline (LLM) erişimi olan daha gelişmiş bir istemci oluşturacağız. Şimdilik, sunucudaki özelliklerin nasıl çağrılacağını görelim:

### -4- Özellikleri çağırma

Özellikleri çağırmak için doğru argümanları ve bazı durumlarda çağırmak istediğimiz şeyin adını belirtmemiz gerekir.

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

Yukarıdaki kodda:

- Bir kaynağı okuduk, `readResource()` çağrısı ile `uri` belirtilerek kaynak çağrılır. Sunucu tarafında muhtemelen şöyle görünür:

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

    `uri` değerimiz `file://example.txt`, sunucudaki `file://{name}` ile eşleşir. `example.txt` `name` olarak eşlenir.

- Bir aracı çağırdık, `name` ve `arguments` belirtilerek çağrılır:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Bir istem aldık, `getPrompt()` `name` ve `arguments` ile çağrılır. Sunucu kodu şöyle görünür:

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

    Bu nedenle istemci kodunuz sunucuda tanımlananla eşleşecek şekilde şöyle olur:

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

Yukarıdaki kodda:

- `read_resource` ile `greeting` adlı bir kaynak çağrıldı.
- `call_tool` ile `add` adlı bir araç çağrıldı.

### C#

1. Bir aracı çağırmak için kod ekleyelim:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Sonucu yazdırmak için aşağıdaki kodu kullanabilirsiniz:

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

Yukarıdaki kodda:

- `callTool()` metodu ve `CallToolRequest` nesneleri kullanılarak birden fazla hesap makinesi aracı çağrıldı.
- Her araç çağrısı, araç adı ve o araç için gereken argümanların bir `Map`'ini belirtir.
- Sunucu araçları belirli parametre isimleri (örneğin matematiksel işlemler için "a", "b") bekler.
- Sonuçlar, sunucudan gelen yanıtı içeren `CallToolResult` nesneleri olarak döner.

### -5- İstemciyi çalıştırma

İstemciyi çalıştırmak için terminalde aşağıdaki komutu yazın:

### TypeScript

*package.json* dosyanızdaki "scripts" bölümüne aşağıdaki girdiyi ekleyin:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

İstemciyi şu komutla çağırın:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Öncelikle MCP sunucunuzun `http://localhost:8080` adresinde çalıştığından emin olun. Ardından istemciyi çalıştırın:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternatif olarak, çözüm klasöründeki `03-GettingStarted\02-client\solution\java` içindeki tamamlanmış istemci projesini çalıştırabilirsiniz:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Ödev

Bu ödevde, öğrendiklerinizi kullanarak kendi istemcinizi oluşturacaksınız.

İşte istemci kodunuzla çağırmanız gereken bir sunucu; sunucuyu daha ilginç hale getirmek için daha fazla özellik ekleyip ekleyemeyeceğinize bakın.

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

Bu projeye bakarak [istemler ve kaynaklar nasıl eklenir](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs) görebilirsiniz.

Ayrıca, [istemler ve kaynaklar nasıl çağrılır](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/) bağlantısını inceleyin.

## Çözüm

[Çözüm](./solution/README.md)

## Önemli Noktalar

Bu bölümde istemcilerle ilgili önemli noktalar şunlardır:

- Sunucudaki özellikleri keşfetmek ve çağırmak için kullanılabilirler.
- Kendileri başlatılırken sunucuyu da başlatabilirler (bu bölümde olduğu gibi), ancak çalışan sunuculara da bağlanabilirler.
- Önceki bölümde anlatıldığı gibi Inspector gibi alternatiflerin yanında sunucu yeteneklerini test etmek için harika bir yoldur.

## Ek Kaynaklar

- [MCP’de istemci oluşturma](https://modelcontextprotocol.io/quickstart/client)

## Örnekler

- [Java Hesap Makinesi](../samples/java/calculator/README.md)
- [.Net Hesap Makinesi](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Hesap Makinesi](../samples/javascript/README.md)
- [TypeScript Hesap Makinesi](../samples/typescript/README.md)
- [Python Hesap Makinesi](../../../../03-GettingStarted/samples/python)

## Sonraki Adım

- Sonraki: [LLM ile istemci oluşturma](../03-llm-client/README.md)

**Feragatname**:  
Bu belge, AI çeviri servisi [Co-op Translator](https://github.com/Azure/co-op-translator) kullanılarak çevrilmiştir. Doğruluk için çaba göstersek de, otomatik çevirilerin hatalar veya yanlışlıklar içerebileceğini lütfen unutmayınız. Orijinal belge, kendi dilinde yetkili kaynak olarak kabul edilmelidir. Kritik bilgiler için profesyonel insan çevirisi önerilir. Bu çevirinin kullanımı sonucu oluşabilecek yanlış anlamalar veya yorum hatalarından sorumlu değiliz.