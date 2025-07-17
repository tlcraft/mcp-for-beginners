<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T10:12:30+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sw"
}
-->
# Kuunda mteja

Wateja ni programu maalum au skiripti zinazozungumza moja kwa moja na MCP Server kuomba rasilimali, zana, na maelekezo. Tofauti na kutumia chombo cha mtazamaji, ambacho hutoa kiolesura cha picha kwa kuingiliana na seva, kuandika mteja wako mwenyewe kunaruhusu mwingiliano wa programu na otomatiki. Hii inawawezesha watengenezaji kuingiza uwezo wa MCP katika mchakato wao wa kazi, kuendesha kazi kwa otomatiki, na kujenga suluhisho maalum zinazolingana na mahitaji fulani.

## Muhtasari

Somo hili linaanzisha dhana ya wateja ndani ya mfumo wa Model Context Protocol (MCP). Utajifunza jinsi ya kuandika mteja wako mwenyewe na kuunganisha na MCP Server.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kuelewa kile mteja anaweza kufanya.
- Kuandika mteja wako mwenyewe.
- Kuunganisha na kujaribu mteja na seva ya MCP kuhakikisha inafanya kazi kama inavyotarajiwa.

## Nini kinahitajika kuandika mteja?

Ili kuandika mteja, utahitaji kufanya yafuatayo:

- **Ingiza maktaba sahihi**. Utatumia maktaba ile ile kama awali, lakini kwa muundo tofauti.
- **Tengeneza mfano wa mteja**. Hii itahusisha kuunda mfano wa mteja na kuunganisha na njia ya usafirishaji uliyochagua.
- **Amua rasilimali gani zaorodheshe**. Seva yako ya MCP ina rasilimali, zana na maelekezo, unahitaji kuamua ni ipi yaorodheshe.
- **Unganisha mteja kwenye programu mwenyeji**. Mara utakapojua uwezo wa seva, unahitaji kuunganisha hii kwenye programu yako mwenyeji ili ikiwa mtumiaji ataandika maelekezo au amri nyingine, kipengele kinacholingana cha seva kitaitwa.

Sasa tunapoelewa kwa kiwango cha juu kile tunachotaka kufanya, tuchunguze mfano ufuatao.

### Mfano wa mteja

Tuchunguze mfano huu wa mteja:

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

Katika msimbo uliotangulia tulifanya:

- Kuingiza maktaba
- Kuunda mfano wa mteja na kuunganisha kwa kutumia stdio kama njia ya usafirishaji.
- Kuweka orodha ya maelekezo, rasilimali na zana na kuziitisha zote.

Hapo una mteja anayeweza kuzungumza na MCP Server.

Tuchukue muda wetu katika sehemu inayofuata ya mazoezi na tuchambue kila kipande cha msimbo na kueleza kinachotokea.

## Mazoezi: Kuandika mteja

Kama ilivyoelezwa hapo juu, tuchukue muda kueleza msimbo, na kwa njia yoyote andika msimbo pamoja nasi ikiwa unataka.

### -1- Kuingiza maktaba

Tuingize maktaba tunazohitaji, tutahitaji marejeleo kwa mteja na kwa itifaki ya usafirishaji tuliyoichagua, stdio. stdio ni itifaki kwa vitu vinavyokusudiwa kuendeshwa kwenye mashine yako ya ndani. SSE ni itifaki nyingine ya usafirishaji tutakayoionyesha katika sura zijazo lakini hiyo ni chaguo lako jingine. Kwa sasa, tuendelee na stdio.

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

Kwa Java, utaunda mteja unaounganisha na seva ya MCP kutoka mazoezi yaliyopita. Ukitumia muundo ule ule wa mradi wa Java Spring Boot kutoka [Kuanzia na MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), tengeneza darasa jipya la Java linaloitwa `SDKClient` katika folda `src/main/java/com/microsoft/mcp/sample/client/` na ongeza imports zifuatazo:

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

Tuweke mbele kuanzisha.

### -2- Kuanzisha mteja na usafirishaji

Tutahitaji kuunda mfano wa usafirishaji na mfano wa mteja wetu:

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

Katika msimbo uliotangulia tumefanya:

- Kuunda mfano wa usafirishaji wa stdio. Angalia jinsi inavyoelezea amri na hoja za jinsi ya kupata na kuanzisha seva kwani hili ni jambo tutalohitaji tunapoanzisha mteja.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Kuanzisha mteja kwa kumpa jina na toleo.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Kuunganisha mteja na usafirishaji uliyochaguliwa.

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

Katika msimbo uliotangulia tumefanya:

- Kuingiza maktaba zinazohitajika
- Kuanzisha kitu cha vigezo vya seva kwani tutakitumia kuendesha seva ili tuweze kuungana nayo na mteja wetu.
- Kueleza njia `run` ambayo kwa upande wake huita `stdio_client` ambayo huanzisha kikao cha mteja.
- Kuunda sehemu ya kuingia ambapo tunatoa njia `run` kwa `asyncio.run`.

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

Katika msimbo uliotangulia tumefanya:

- Kuingiza maktaba zinazohitajika.
- Kuunda usafirishaji wa stdio na kuunda mteja `mcpClient`. Hii ni kitu ambacho tutatumia kuorodhesha na kuitisha vipengele kwenye MCP Server.

Kumbuka, katika "Arguments", unaweza kuelekeza kwa *.csproj* au kwa faili inayotekelezwa.

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

Katika msimbo uliotangulia tumefanya:

- Kuunda njia kuu inayoweka usafirishaji wa SSE unaoelekeza kwenye `http://localhost:8080` ambapo seva yetu ya MCP itakuwa ikifanya kazi.
- Kuunda darasa la mteja linalopokea usafirishaji kama parameter ya muundaji.
- Katika njia `run`, tunaunda mteja wa MCP wa wakati mmoja kwa kutumia usafirishaji na kuanzisha muunganisho.
- Kutumia usafirishaji wa SSE (Server-Sent Events) unaofaa kwa mawasiliano ya HTTP na seva za MCP za Java Spring Boot.

### -3- Kuweka orodha ya vipengele vya seva

Sasa, tuna mteja anayeweza kuungana ikiwa programu itaendeshwa. Hata hivyo, haijaorodhesha vipengele vyake, basi tufanye hivyo sasa:

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

Hapa tunaorodhesha rasilimali zinazopatikana, `list_resources()` na zana, `list_tools` na kuzichapisha.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Hapo juu ni mfano wa jinsi tunavyoweza kuorodhesha zana kwenye seva. Kwa kila zana, tunachapisha jina lake.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Katika msimbo uliotangulia tumefanya:

- Kuita `listTools()` kupata zana zote zinazopatikana kutoka MCP server.
- Kutumia `ping()` kuthibitisha kuwa muunganisho na seva unafanya kazi.
- `ListToolsResult` ina taarifa kuhusu zana zote ikiwa ni pamoja na majina yao, maelezo, na miundo ya pembejeo.

Nzuri, sasa tumekusanya vipengele vyote. Sasa swali ni lini tunavitumia? Mteja huyu ni rahisi, rahisi kwa maana kwamba tutahitaji kuitisha vipengele moja kwa moja tunapotaka. Katika sura inayofuata, tutaunda mteja wa hali ya juu zaidi ambaye atakuwa na ufikiaji wa mfano wake mkubwa wa lugha, LLM. Kwa sasa, tuchunguze jinsi ya kuitisha vipengele kwenye seva:

### -4- Kuitisha vipengele

Ili kuitisha vipengele tunahitaji kuhakikisha tunaelezea hoja sahihi na katika baadhi ya matukio jina la kile tunachojaribu kuitisha.

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

Katika msimbo uliotangulia tumefanya:

- Kusoma rasilimali, tunaita rasilimali kwa kutumia `readResource()` tukielezea `uri`. Hapa ni jinsi inavyoweza kuonekana upande wa seva:

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

    Thamani yetu ya `uri` `file://example.txt` inalingana na `file://{name}` kwenye seva. `example.txt` itahusishwa na `name`.

- Kuita zana, tunaiita kwa kuelezea `name` na `arguments` kama ifuatavyo:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Kupata maelekezo, kupata maelekezo, unaita `getPrompt()` na `name` na `arguments`. Msimbo wa seva unaonekana hivi:

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

    na msimbo wa mteja unaotokana na huo unaonekana hivi ili ulingane na kilichotangazwa kwenye seva:

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

Katika msimbo uliotangulia tumefanya:

- Kuita rasilimali iitwayo `greeting` kwa kutumia `read_resource`.
- Kuitisha zana iitwayo `add` kwa kutumia `call_tool`.

### .NET

1. Tuweke msimbo wa kuitisha zana:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Kutoa matokeo, hapa kuna msimbo wa kushughulikia hilo:

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

Katika msimbo uliotangulia tumefanya:

- Kuita zana nyingi za kalkuleta kwa kutumia njia `callTool()` na vitu vya `CallToolRequest`.
- Kila wito wa zana unaelezea jina la zana na `Map` ya hoja zinazohitajika na zana hiyo.
- Zana za seva zinatarajia majina maalum ya vigezo (kama "a", "b" kwa operesheni za hisabati).
- Matokeo hurudishwa kama vitu vya `CallToolResult` vinavyochukua majibu kutoka seva.

### -5- Kuendesha mteja

Ili kuendesha mteja, andika amri ifuatayo kwenye terminal:

### TypeScript

Ongeza kipengele hiki kwenye sehemu yako ya "scripts" katika *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Piga mteja kwa amri ifuatayo:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Kwanza, hakikisha seva yako ya MCP inaendeshwa kwenye `http://localhost:8080`. Kisha endesha mteja:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Mbali na hilo, unaweza kuendesha mradi kamili wa mteja uliotolewa katika folda ya suluhisho `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Kazi ya Nyumbani

Katika kazi hii ya nyumbani, utatumia kile ulichojifunza kuunda mteja lakini utaunda mteja wako mwenyewe.

Hapa kuna seva unayoweza kutumia ambayo unahitaji kuitisha kupitia msimbo wako wa mteja, angalia kama unaweza kuongeza vipengele zaidi kwenye seva ili kuifanya iwe ya kuvutia zaidi.

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

Tazama mradi huu kuona jinsi unavyoweza [kuongeza maelekezo na rasilimali](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Pia, angalia kiungo hiki kwa jinsi ya kuitisha [maelekezo na rasilimali](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Suluhisho

**Folda ya suluhisho** ina utekelezaji kamili wa mteja tayari kuendeshwa unaoonyesha dhana zote zilizofunikwa katika mafunzo haya. Kila suluhisho lina msimbo wa mteja na seva uliopangwa katika miradi tofauti, yenye kujitegemea.

### 📁 Muundo wa Suluhisho

Kabrasha la suluhisho limepangwa kwa lugha za programu:

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

### 🚀 Kila Suluhisho Linajumuisha Nini

Kila suluhisho la lugha maalum linatoa:

- **Utekelezaji kamili wa mteja** na vipengele vyote kutoka mafunzo
- **Muundo wa mradi unaofanya kazi** na utegemezi na usanidi sahihi
- **Skripti za kujenga na kuendesha** kwa usanidi rahisi na utekelezaji
- **README ya kina** yenye maelekezo maalum ya lugha
- **Udhibiti wa makosa** na mifano ya usindikaji wa matokeo

### 📖 Kutumia Suluhisho

1. **Nenda kwenye folda ya lugha unayopendelea**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **Fuata maelekezo ya README** katika kila folda kwa:
   - Kuweka utegemezi
   - Kujenga mradi
   - Kuendesha mteja

3. **Mfano wa matokeo** unayopaswa kuona:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

Kwa nyaraka kamili na maelekezo ya hatua kwa hatua, angalia: **[📖 Nyaraka za Suluhisho](./solution/README.md)**

## 🎯 Mifano Kamili

Tumetoa utekelezaji kamili, unaofanya kazi wa wateja kwa lugha zote za programu zilizofunikwa katika mafunzo haya. Mifano hii inaonyesha utendaji kamili ulioelezwa hapo juu na inaweza kutumika kama marejeleo au pointi za kuanzia kwa miradi yako mwenyewe.

### Mifano Kamili Inayopatikana

| Lugha   | Faili                        | Maelezo                                                   |
|---------|------------------------------|-----------------------------------------------------------|
| **Java**  | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | Mteja kamili wa Java akitumia usafirishaji wa SSE na udhibiti wa makosa wa kina |
| **C#**    | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | Mteja kamili wa C# akitumia usafirishaji wa stdio na kuanzisha seva moja kwa moja |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | Mteja kamili wa TypeScript na msaada kamili wa itifaki ya MCP |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | Mteja kamili wa Python akitumia mifumo ya async/await |

Kila mfano kamili unajumuisha:

- ✅ **Kuweka muunganisho** na udhibiti wa makosa
- ✅ **Kugundua seva** (zana, rasilimali, maelekezo pale panapohitajika)
- ✅ **Operesheni za kalkuleta** (ongeza, toa, zidisha, gawanya, msaada)
- ✅ **Usindikaji wa matokeo** na matokeo yaliyopangwa vizuri
- ✅ **Udhibiti wa makosa wa kina**
- ✅ **Msimbo safi, uliotangazwa** na maelezo ya hatua kwa hatua

### Kuanzia na Mifano Kamili

1. **Chagua lugha unayopendelea** kutoka kwenye jedwali hapo juu
2. **Pitia faili la mfano kamili** kuelewa utekelezaji kamili
3. **Endesha mfano** ukifuata maelekezo katika [`complete_examples.md`](./complete_examples.md)
4. **Badilisha na ongeza** mfano kwa matumizi yako maalum

Kwa nyaraka za kina kuhusu kuendesha na kubinafsisha mifano hii, angalia: **[📖 Nyaraka za Mifano Kamili](./complete_examples.md)**

### 💡 Suluhisho dhidi ya Mifano Kamili

| **Folda ya Suluhisho**          | **Mifano Kamili**               |
|--------------------------------|--------------------------------|
| Muundo kamili wa mradi na faili za kujenga | Utekelezaji wa faili moja moja |
| Tayari kuendeshwa na utegemezi | Mifano ya msimbo pekee          |
| Usanidi wa kiwango cha uzalishaji | Marejeleo ya kielimu            |
| Zana maalum za lugha            | Ulinganisho wa lugha mbalimbali  |
Mbinu zote mbili ni muhimu - tumia **folda ya suluhisho** kwa miradi kamili na **mifano kamili** kwa kujifunza na marejeleo.

## Muhimu Kuu

Muhimu kuu wa sura hii kuhusu wateja ni yafuatayo:

- Inaweza kutumika kugundua na kuitisha vipengele kwenye seva.
- Inaweza kuanzisha seva wakati inajiendesha yenyewe (kama ilivyo katika sura hii) lakini wateja pia wanaweza kuungana na seva zinazotumika.
- Ni njia nzuri ya kujaribu uwezo wa seva ikilinganishwa na mbadala kama Inspector kama ilivyoelezwa katika sura iliyopita.

## Rasilimali Zaidi

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## Sampuli

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Nini Kifuatacho

- Ifuatayo: [Creating a client with an LLM](../03-llm-client/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.