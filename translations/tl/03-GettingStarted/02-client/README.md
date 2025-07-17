<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:08:57+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "tl"
}
-->
# Paglikha ng kliyente

Ang mga kliyente ay mga custom na aplikasyon o script na direktang nakikipag-ugnayan sa isang MCP Server upang humiling ng mga resources, tools, at prompts. Hindi tulad ng paggamit ng inspector tool na nagbibigay ng graphical na interface para makipag-ugnayan sa server, ang pagsulat ng sarili mong kliyente ay nagbibigay-daan sa programmatic at automated na interaksyon. Pinapayagan nito ang mga developer na isama ang mga kakayahan ng MCP sa kanilang sariling workflow, i-automate ang mga gawain, at bumuo ng mga custom na solusyon na nakaangkop sa partikular na pangangailangan.

## Pangkalahatang-ideya

Ipinapakilala ng araling ito ang konsepto ng mga kliyente sa loob ng Model Context Protocol (MCP) ecosystem. Matututuhan mo kung paano sumulat ng sarili mong kliyente at paano ito ikonekta sa isang MCP Server.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Maunawaan kung ano ang magagawa ng isang kliyente.
- Sumulat ng sarili mong kliyente.
- Ikonekta at subukan ang kliyente sa isang MCP server upang matiyak na gumagana ito ayon sa inaasahan.

## Ano ang kailangan sa pagsulat ng kliyente?

Para makasulat ng kliyente, kailangan mong gawin ang mga sumusunod:

- **I-import ang tamang mga library**. Gagamitin mo ang parehong library tulad ng dati, ngunit iba ang mga konstrukto.
- **Gumawa ng instance ng kliyente**. Kasama dito ang paglikha ng client instance at pagkonekta nito sa napiling paraan ng transport.
- **Pumili kung anong mga resources ang ililista**. Ang iyong MCP server ay may mga resources, tools, at prompts; kailangan mong piliin kung alin ang ililista.
- **Isama ang kliyente sa host application**. Kapag alam mo na ang mga kakayahan ng server, kailangan mong isama ito sa iyong host application upang kapag nag-type ang user ng prompt o ibang command, ma-trigger ang kaukulang feature ng server.

Ngayon na naiintindihan natin sa pangkalahatan ang gagawin, tingnan natin ang isang halimbawa.

### Isang halimbawa ng kliyente

Tingnan natin ang halimbawa ng kliyenteng ito:

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

Sa code na ito:

- In-import ang mga library
- Gumawa ng instance ng kliyente at ikinonekta ito gamit ang stdio bilang transport.
- Inilista ang prompts, resources, at tools at tinawag ang mga ito.

Ayan, isang kliyente na kayang makipag-usap sa isang MCP Server.

Maglaan tayo ng oras sa susunod na bahagi ng ehersisyo upang himayin ang bawat bahagi ng code at ipaliwanag ang mga nangyayari.

## Ehersisyo: Pagsulat ng kliyente

Tulad ng sinabi sa itaas, maglaan tayo ng oras sa pagpapaliwanag ng code, at malaya kang sumabay sa pag-code kung nais mo.

### -1- I-import ang mga library

I-import natin ang mga kinakailangang library, kakailanganin natin ang mga reference sa kliyente at sa napiling transport protocol, ang stdio. Ang stdio ay isang protocol para sa mga bagay na tatakbo sa iyong lokal na makina. Ang SSE ay isa pang transport protocol na ipapakita natin sa mga susunod na kabanata, ngunit iyon ang isa pang opsyon mo. Sa ngayon, magpatuloy tayo gamit ang stdio.

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

Para sa Java, gagawa ka ng kliyente na kumokonekta sa MCP server mula sa nakaraang ehersisyo. Gamit ang parehong Java Spring Boot project structure mula sa [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), gumawa ng bagong Java class na tinatawag na `SDKClient` sa folder na `src/main/java/com/microsoft/mcp/sample/client/` at idagdag ang mga sumusunod na import:

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

Tuloy tayo sa pag-instansya.

### -2- Pag-instansya ng kliyente at transport

Kailangan nating gumawa ng instance ng transport at ng kliyente:

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

Sa code na ito:

- Gumawa tayo ng stdio transport instance. Pansinin kung paano nito tinutukoy ang command at args para hanapin at simulan ang server dahil ito ay kailangan natin sa paggawa ng kliyente.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Nag-instansya ng kliyente sa pamamagitan ng pagbibigay ng pangalan at bersyon.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Ikinonekta ang kliyente sa napiling transport.

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

Sa code na ito:

- In-import ang mga kinakailangang library
- Nag-instansya ng server parameters object na gagamitin para patakbuhin ang server upang makakonekta tayo dito gamit ang kliyente.
- Nagdeklara ng method na `run` na tumatawag sa `stdio_client` na nagsisimula ng client session.
- Gumawa ng entry point kung saan ibinibigay ang `run` method sa `asyncio.run`.

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

Sa code na ito:

- In-import ang mga kinakailangang library.
- Gumawa ng stdio transport at kliyente na `mcpClient`. Ito ang gagamitin natin para ilista at tawagin ang mga feature ng MCP Server.

Tandaan, sa "Arguments", maaari kang tumukoy sa *.csproj* o sa executable.

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

Sa code na ito:

- Gumawa ng main method na nagse-set up ng SSE transport na tumutukoy sa `http://localhost:8080` kung saan tatakbo ang MCP server.
- Gumawa ng client class na tumatanggap ng transport bilang constructor parameter.
- Sa `run` method, gumawa ng synchronous MCP client gamit ang transport at inisyalisa ang koneksyon.
- Ginamit ang SSE (Server-Sent Events) transport na angkop para sa HTTP-based na komunikasyon sa Java Spring Boot MCP servers.

### -3- Paglilista ng mga feature ng server

Ngayon, mayroon na tayong kliyente na kayang kumonekta kapag pinatakbo ang programa. Ngunit hindi pa nito inililista ang mga feature kaya gawin natin iyon ngayon:

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

Dito inililista natin ang mga available na resources gamit ang `list_resources()` at tools gamit ang `list_tools` at ipinapakita ang mga ito.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Nasa itaas ang halimbawa kung paano natin maililista ang mga tools sa server. Para sa bawat tool, ipinapakita natin ang pangalan nito.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Sa code na ito:

- Tinawag ang `listTools()` para makuha ang lahat ng available na tools mula sa MCP server.
- Ginamit ang `ping()` para tiyakin na gumagana ang koneksyon sa server.
- Ang `ListToolsResult` ay naglalaman ng impormasyon tungkol sa lahat ng tools kabilang ang kanilang mga pangalan, deskripsyon, at input schemas.

Maganda, nakolekta na natin lahat ng feature. Ngayon, kailan natin ito gagamitin? Simple lang ang kliyenteng ito, ibig sabihin kailangan nating tawagin nang tahasan ang mga feature kapag gusto natin sila. Sa susunod na kabanata, gagawa tayo ng mas advanced na kliyente na may sariling malaking language model, LLM. Sa ngayon, tingnan natin kung paano tawagin ang mga feature sa server:

### -4- Pagtawag sa mga feature

Para tawagin ang mga feature, kailangan nating tiyakin na tama ang mga argumento at sa ilang kaso, ang pangalan ng tinatawagan.

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

Sa code na ito:

- Nagbasa ng resource, tinawag ang resource gamit ang `readResource()` na may tinukoy na `uri`. Ganito ang itsura nito sa server side:

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

    Ang `uri` na `file://example.txt` ay tumutugma sa `file://{name}` sa server. Ang `example.txt` ay mapupunta sa `name`.

- Tumawag ng tool, tinawag ito sa pamamagitan ng pagtukoy ng `name` at `arguments` nito tulad nito:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Kumuha ng prompt, para makuha ang prompt, tinawag ang `getPrompt()` gamit ang `name` at `arguments`. Ganito ang code sa server:

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

    Kaya ang client code mo ay ganito para tumugma sa deklarasyon sa server:

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

Sa code na ito:

- Tinawag ang resource na `greeting` gamit ang `read_resource`.
- Tinawag ang tool na `add` gamit ang `call_tool`.

### .NET

1. Magdagdag tayo ng code para tumawag ng tool:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Para ipakita ang resulta, narito ang code para gawin iyon:

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

Sa code na ito:

- Tinawag ang iba't ibang calculator tools gamit ang `callTool()` method na may `CallToolRequest` objects.
- Bawat tawag sa tool ay nagtutukoy ng pangalan ng tool at isang `Map` ng mga argumentong kailangan ng tool.
- Inaasahan ng mga tool sa server ang mga partikular na pangalan ng parameter (tulad ng "a", "b" para sa mga operasyon sa matematika).
- Ang mga resulta ay ibinabalik bilang `CallToolResult` objects na naglalaman ng tugon mula sa server.

### -5- Patakbuhin ang kliyente

Para patakbuhin ang kliyente, i-type ang sumusunod na utos sa terminal:

### TypeScript

Idagdag ang sumusunod na entry sa iyong "scripts" section sa *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Patakbuhin ang kliyente gamit ang sumusunod na utos:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Siguraduhing tumatakbo ang iyong MCP server sa `http://localhost:8080`. Pagkatapos, patakbuhin ang kliyente:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Bilang alternatibo, maaari mong patakbuhin ang buong client project na nasa solution folder na `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Takdang Aralin

Sa takdang araling ito, gagamitin mo ang mga natutunan mo sa paggawa ng kliyente ngunit gagawa ka ng sarili mong kliyente.

Narito ang isang server na maaari mong gamitin na kailangang tawagin gamit ang iyong client code, tingnan kung kaya mong magdagdag ng higit pang mga feature sa server upang maging mas kawili-wili ito.

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

Tingnan ang proyektong ito para makita kung paano ka makakapagdagdag ng [prompts at resources](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Gayundin, tingnan ang link na ito para sa kung paano tawagin ang [prompts at resources](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Solusyon

Ang **solution folder** ay naglalaman ng kumpleto at handang patakbuhin na mga implementasyon ng kliyente na nagpapakita ng lahat ng konseptong tinalakay sa tutorial na ito. Bawat solusyon ay may kasamang client at server code na nakaayos sa magkakahiwalay at self-contained na mga proyekto.

### 📁 Istruktura ng Solusyon

Ang direktoryo ng solusyon ay nakaayos ayon sa programming language:

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

### 🚀 Ano ang Nilalaman ng Bawat Solusyon

Bawat solusyon na nakatuon sa isang wika ay nagbibigay ng:

- **Kumpletong implementasyon ng kliyente** na may lahat ng feature mula sa tutorial
- **Gumaganang istruktura ng proyekto** na may tamang dependencies at configuration
- **Mga script para sa pag-build at pagpapatakbo** para sa madaling setup at execution
- **Detalyadong README** na may mga tagubilin na nakatuon sa wika
- **Pag-handle ng error** at mga halimbawa ng pagproseso ng resulta

### 📖 Paggamit ng mga Solusyon

1. **Pumunta sa folder ng nais mong wika**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Sundin ang mga tagubilin sa README** sa bawat folder para sa:
   - Pag-install ng dependencies
   - Pag-build ng proyekto
   - Pagpapatakbo ng kliyente

3. **Halimbawa ng output** na dapat mong makita:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Para sa kumpletong dokumentasyon at step-by-step na mga tagubilin, tingnan: **[📖 Solution Documentation](./solution/README.md)**

## 🎯 Kumpletong Mga Halimbawa

Nagbigay kami ng kumpleto at gumaganang mga implementasyon ng kliyente para sa lahat ng programming language na tinalakay sa tutorial na ito. Ipinapakita ng mga halimbawang ito ang buong functionality na inilarawan sa itaas at maaaring gamitin bilang reference implementations o panimulang punto para sa iyong sariling mga proyekto.

### Mga Available na Kumpletong Halimbawa

| Wika     | File                          | Deskripsyon                                                  |
|----------|-------------------------------|--------------------------------------------------------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java)       | Kumpletong Java client gamit ang SSE transport na may komprehensibong pag-handle ng error |
| **C#**   | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs)       | Kumpletong C# client gamit ang stdio transport na may awtomatikong pagsisimula ng server |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Kumpletong TypeScript client na may buong suporta sa MCP protocol |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py)       | Kumpletong Python client gamit ang async/await na pattern |

Bawat kumpletong halimbawa ay may kasamang:

- ✅ **Pagkonekta at pag-handle ng error**
- ✅ **Pagdiskubre ng server** (tools, resources, prompts kung saan naaangkop)
- ✅ **Mga operasyon sa calculator** (add, subtract, multiply, divide, help)
- ✅ **Pagproseso ng resulta** at nakaayos na output
- ✅ **Komprehensibong pag-handle ng error**
- ✅ **Malinis at dokumentadong code** na may step-by-step na mga komento

### Pagsisimula sa Kumpletong Mga Halimbawa

1. **Piliin ang nais mong wika** mula sa talahanayan sa itaas
2. **Suriin ang kumpletong halimbawa ng file** upang maunawaan ang buong implementasyon
3. **Patakbuhin ang halimbawa** ayon sa mga tagubilin sa [`complete_examples.md`](./complete_examples.md)
4. **I-modify at palawakin** ang halimbawa para sa iyong partikular na gamit

Para sa detalyadong dokumentasyon tungkol sa pagpapatakbo at pag-customize ng mga halimbawang ito, tingnan: **[📖 Complete Examples Documentation](./complete_examples.md)**

### 💡 Solusyon kumpara sa Kumpletong Mga Halimbawa

| **Solution Folder**               | **Kumpletong Mga Halimbawa**          |
|---------------------------------|-------------------------------------|
| Buong istruktura ng proyekto na may mga build file | Mga implementasyon sa iisang file |
| Handang patakbuhin na may dependencies | Nakatuon sa mga halimbawa ng code |
| Setup na parang production       | Pang-edukasyon na reference        |
| Tooling na nakatuon sa wika      | Paghahambing sa iba't ibang wika   |
Parehong mahalaga ang dalawang paraan - gamitin ang **solution folder** para sa mga kumpletong proyekto at ang **complete examples** para sa pag-aaral at sanggunian.

## Mga Pangunahing Punto

Ang mga pangunahing punto para sa kabanatang ito tungkol sa mga client ay ang mga sumusunod:

- Maaaring gamitin upang tuklasin at tawagan ang mga tampok sa server.
- Maaaring magsimula ng server habang nagsisimula rin ang sarili nitong proseso (tulad sa kabanatang ito) ngunit maaaring kumonekta ang mga client sa mga tumatakbong server.
- Isang mahusay na paraan upang subukan ang kakayahan ng server kasabay ng mga alternatibo tulad ng Inspector na ipinaliwanag sa nakaraang kabanata.

## Karagdagang Mga Sanggunian

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Mga Halimbawa

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ano ang Susunod

- Susunod: [Creating a client with an LLM](../03-llm-client/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.