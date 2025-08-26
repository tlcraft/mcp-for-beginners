<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:41:31+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "sw"
}
-->
# Seva ya MCP na Usafirishaji wa stdio

> **⚠️ Sasisho Muhimu**: Kuanzia Maelezo ya MCP ya 2025-06-18, usafirishaji wa SSE (Server-Sent Events) umepitwa na wakati na kubadilishwa na usafirishaji wa "Streamable HTTP". Maelezo ya sasa ya MCP yanafafanua mbinu mbili kuu za usafirishaji:
> 1. **stdio** - Ingizo/Toleo la Kawaida (inapendekezwa kwa seva za ndani)
> 2. **Streamable HTTP** - Kwa seva za mbali zinazoweza kutumia SSE ndani
>
> Somo hili limeboreshwa kuzingatia **usafirishaji wa stdio**, ambao ni mbinu inayopendekezwa kwa utekelezaji mwingi wa seva za MCP.

Usafirishaji wa stdio unaruhusu seva za MCP kuwasiliana na wateja kupitia mito ya ingizo na toleo la kawaida. Hii ndiyo mbinu inayotumika zaidi na inayopendekezwa katika maelezo ya sasa ya MCP, ikitoa njia rahisi na bora ya kujenga seva za MCP zinazoweza kuunganishwa kwa urahisi na programu mbalimbali za wateja.

## Muhtasari

Somo hili linashughulikia jinsi ya kujenga na kutumia Seva za MCP kwa kutumia usafirishaji wa stdio.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kujenga Seva ya MCP kwa kutumia usafirishaji wa stdio.
- Kutatua matatizo ya Seva ya MCP kwa kutumia Inspector.
- Kutumia Seva ya MCP kwa kutumia Visual Studio Code.
- Kuelewa mbinu za sasa za usafirishaji wa MCP na kwa nini stdio inapendekezwa.

## Usafirishaji wa stdio - Jinsi Unavyofanya Kazi

Usafirishaji wa stdio ni mojawapo ya aina mbili za usafirishaji zinazoungwa mkono katika maelezo ya sasa ya MCP (2025-06-18). Hivi ndivyo unavyofanya kazi:

- **Mawasiliano Rahisi**: Seva inasoma ujumbe wa JSON-RPC kutoka kwa ingizo la kawaida (`stdin`) na kutuma ujumbe kwa toleo la kawaida (`stdout`).
- **Mchakato wa msingi**: Mteja huzindua seva ya MCP kama mchakato wa chini.
- **Umbizo la Ujumbe**: Ujumbe ni maombi ya JSON-RPC, arifa, au majibu, yaliyotenganishwa na mistari mipya.
- **Kumbukumbu**: Seva INAWEZA kuandika mistari ya UTF-8 kwa kosa la kawaida (`stderr`) kwa madhumuni ya kumbukumbu.

### Mahitaji Muhimu:
- Ujumbe LAZIMA utenganishwe na mistari mipya na HAUPASWI kuwa na mistari mipya iliyojumuishwa.
- Seva HAIPASWI kuandika chochote kwa `stdout` ambacho si ujumbe halali wa MCP.
- Mteja HAUPASWI kuandika chochote kwa `stdin` ya seva ambacho si ujumbe halali wa MCP.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

Katika msimbo uliotangulia:

- Tunaingiza darasa la `Server` na `StdioServerTransport` kutoka kwa MCP SDK.
- Tunaunda mfano wa seva na usanidi wa msingi na uwezo.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

Katika msimbo uliotangulia:

- Tunaunda mfano wa seva kwa kutumia MCP SDK.
- Tunafafanua zana kwa kutumia mapambo (decorators).
- Tunatumia meneja wa muktadha wa stdio_server kushughulikia usafirishaji.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

Tofauti kuu kutoka kwa SSE ni kwamba seva za stdio:

- Hazihitaji usanidi wa seva ya wavuti au sehemu za mwisho za HTTP.
- Huzinduliwa kama michakato ya chini na mteja.
- Huwasiliana kupitia mito ya stdin/stdout.
- Ni rahisi kutekeleza na kutatua matatizo.

## Zoezi: Kuunda Seva ya stdio

Ili kuunda seva yetu, tunahitaji kuzingatia mambo mawili:

- Tunahitaji kutumia seva ya wavuti kufichua sehemu za mwisho kwa ajili ya muunganisho na ujumbe.

## Maabara: Kuunda seva rahisi ya MCP stdio

Katika maabara hii, tutaunda seva rahisi ya MCP kwa kutumia usafirishaji wa stdio unaopendekezwa. Seva hii itafichua zana ambazo wateja wanaweza kuita kwa kutumia Model Context Protocol ya kawaida.

### Mahitaji ya Awali

- Python 3.8 au toleo jipya zaidi.
- MCP Python SDK: `pip install mcp`.
- Uelewa wa msingi wa programu ya async.

Tuanzie kwa kuunda seva yetu ya kwanza ya MCP stdio:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## Tofauti kuu kutoka kwa mbinu ya SSE iliyopitwa na wakati

**Usafirishaji wa Stdio (Kiwango cha Sasa):**
- Mfano rahisi wa mchakato wa chini - mteja huzindua seva kama mchakato wa mtoto.
- Mawasiliano kupitia stdin/stdout kwa kutumia ujumbe wa JSON-RPC.
- Hakuna usanidi wa seva ya HTTP unaohitajika.
- Utendaji bora na usalama.
- Rahisi kutatua matatizo na kuendeleza.

**Usafirishaji wa SSE (Uliopitwa na Wakati kuanzia MCP 2025-06-18):**
- Ulihitaji seva ya HTTP yenye sehemu za mwisho za SSE.
- Usanidi mgumu zaidi na miundombinu ya seva ya wavuti.
- Masuala ya ziada ya usalama kwa sehemu za mwisho za HTTP.
- Sasa imebadilishwa na Streamable HTTP kwa hali za wavuti.

### Kuunda seva kwa usafirishaji wa stdio

Ili kuunda seva yetu ya stdio, tunahitaji:

1. **Kuagiza maktaba zinazohitajika** - Tunahitaji vipengele vya seva ya MCP na usafirishaji wa stdio.
2. **Kuunda mfano wa seva** - Kufafanua seva na uwezo wake.
3. **Kufafanua zana** - Kuongeza utendakazi tunaotaka kufichua.
4. **Kusanidi usafirishaji** - Kusimamia mawasiliano ya stdio.
5. **Kuendesha seva** - Kuanza seva na kushughulikia ujumbe.

Tuijenge hatua kwa hatua:

### Hatua ya 1: Kuunda seva ya msingi ya stdio

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### Hatua ya 2: Kuongeza zana zaidi

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### Hatua ya 3: Kuendesha seva

Hifadhi msimbo kama `server.py` na uendeshe kutoka kwenye mstari wa amri:

```bash
python server.py
```

Seva itaanza na kusubiri ingizo kutoka kwa stdin. Inawasiliana kwa kutumia ujumbe wa JSON-RPC kupitia usafirishaji wa stdio.

### Hatua ya 4: Kujaribu kwa kutumia Inspector

Unaweza kujaribu seva yako kwa kutumia MCP Inspector:

1. Sakinisha Inspector: `npx @modelcontextprotocol/inspector`.
2. Endesha Inspector na uielekeze kwenye seva yako.
3. Jaribu zana ulizounda.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// Ongeza zana
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Pata salamu ya kibinafsi",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Jina la mtu wa kusalimiwa",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `Habari, ${request.params.arguments?.name}! Karibu kwenye seva ya MCP stdio.`,
        },
      ],
    };
  } else {
    throw new Error(`Zana haijulikani: ${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("Pata salamu ya kibinafsi")]
    public string GetGreeting(string name)
    {
        return $"Habari, {name}! Karibu kwenye seva ya MCP stdio.";
    }

    [Description("Hesabu jumla ya namba mbili")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. Tuunde zana kadhaa kwanza, kwa hili tutaunda faili *Tools.cs* yenye maudhui yafuatayo:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **Fungua kiolesura cha wavuti**: Inspector itafungua dirisha la kivinjari linaloonyesha uwezo wa seva yako.

3. **Jaribu zana**: 
   - Jaribu zana ya `get_greeting` kwa majina tofauti.
   - Jaribu zana ya `calculate_sum` kwa namba mbalimbali.
   - Ita zana ya `get_server_info` kuona metadata ya seva.

4. **Fuatilia mawasiliano**: Inspector inaonyesha ujumbe wa JSON-RPC unaobadilishwa kati ya mteja na seva.

### Unachopaswa kuona

Seva yako ikianza kwa usahihi, unapaswa kuona:
- Uwezo wa seva umeorodheshwa kwenye Inspector.
- Zana zinapatikana kwa majaribio.
- Ujumbe wa JSON-RPC unabadilishwa kwa mafanikio.
- Majibu ya zana yanaonyeshwa kwenye kiolesura.

### Masuala ya kawaida na suluhisho

**Seva haianzi:**
- Hakikisha utegemezi wote umesakinishwa: `pip install mcp`.
- Thibitisha sintaksia ya Python na mpangilio.
- Angalia ujumbe wa makosa kwenye console.

**Zana hazionekani:**
- Hakikisha `@server.tool()` mapambo yapo.
- Thibitisha kuwa kazi za zana zimefafanuliwa kabla ya `main()`.
- Hakikisha seva imewekwa vizuri.

**Masuala ya muunganisho:**
- Hakikisha seva inatumia usafirishaji wa stdio kwa usahihi.
- Angalia kama hakuna michakato mingine inayozuia.
- Thibitisha sintaksia ya amri ya Inspector.

## Kazi

Jaribu kujenga seva yako na uwezo zaidi. Tazama [ukurasa huu](https://api.chucknorris.io/) ili, kwa mfano, kuongeza zana inayopiga API. Wewe ndiye unayeamua jinsi seva inavyopaswa kuonekana. Furahia :)

## Suluhisho

[Suluhisho](./solution/README.md) Hapa kuna suluhisho linalowezekana lenye msimbo unaofanya kazi.

## Mambo Muhimu ya Kujifunza

Mambo muhimu ya kujifunza kutoka kwenye sura hii ni:

- Usafirishaji wa stdio ni mbinu inayopendekezwa kwa seva za MCP za ndani.
- Usafirishaji wa stdio unaruhusu mawasiliano rahisi kati ya seva za MCP na wateja kwa kutumia mito ya ingizo na toleo la kawaida.
- Unaweza kutumia Inspector na Visual Studio Code kutumia seva za stdio moja kwa moja, na kufanya utatuzi wa matatizo na ujumuishaji kuwa rahisi.

## Sampuli 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Rasilimali za Ziada

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Nini Kifuatacho

## Hatua Zifuatazo

Sasa kwa kuwa umejifunza jinsi ya kujenga seva za MCP kwa usafirishaji wa stdio, unaweza kuchunguza mada za juu zaidi:

- **Ifuatayo**: [HTTP Streaming na MCP (Streamable HTTP)](../06-http-streaming/README.md) - Jifunze kuhusu mbinu nyingine ya usafirishaji inayoungwa mkono kwa seva za mbali.
- **Juu**: [MCP Security Best Practices](../../02-Security/README.md) - Tekeleza usalama katika seva zako za MCP.
- **Uzalishaji**: [Mikakati ya Utekelezaji](../09-deployment/README.md) - Tekeleza seva zako kwa matumizi ya uzalishaji.

## Rasilimali za Ziada

- [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Maelezo rasmi.
- [MCP SDK Documentation](https://github.com/modelcontextprotocol/sdk) - Marejeleo ya SDK kwa lugha zote.
- [Community Examples](../../06-CommunityContributions/README.md) - Sampuli zaidi za seva kutoka kwa jamii.

---

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya kutafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuwa sahihi. Hati ya asili katika lugha yake ya awali inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatutawajibika kwa kutoelewana au tafsiri zisizo sahihi zinazotokana na matumizi ya tafsiri hii.