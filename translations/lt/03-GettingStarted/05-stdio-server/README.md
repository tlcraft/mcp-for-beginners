<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:58:08+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "lt"
}
-->
# MCP Server su stdio transportu

> **⚠️ Svarbus atnaujinimas**: Nuo MCP specifikacijos 2025-06-18, atskiras SSE (Server-Sent Events) transportas buvo **pašalintas** ir pakeistas „Streamable HTTP“ transportu. Dabartinė MCP specifikacija apibrėžia du pagrindinius transporto mechanizmus:
> 1. **stdio** - Standartinis įvesties/išvesties transportas (rekomenduojamas vietiniams serveriams)
> 2. **Streamable HTTP** - Nuotoliniams serveriams, kurie viduje gali naudoti SSE
>
> Ši pamoka buvo atnaujinta, kad sutelktų dėmesį į **stdio transportą**, kuris yra rekomenduojamas daugumai MCP serverių įgyvendinimų.

Stdio transportas leidžia MCP serveriams bendrauti su klientais per standartinius įvesties ir išvesties srautus. Tai yra dažniausiai naudojamas ir rekomenduojamas transporto mechanizmas dabartinėje MCP specifikacijoje, suteikiantis paprastą ir efektyvų būdą kurti MCP serverius, kuriuos lengva integruoti su įvairiomis klientų programomis.

## Apžvalga

Šioje pamokoje aptarsime, kaip kurti ir naudoti MCP serverius su stdio transportu.

## Mokymosi tikslai

Pamokos pabaigoje galėsite:

- Sukurti MCP serverį naudojant stdio transportą.
- Derinti MCP serverį naudojant „Inspector“.
- Naudoti MCP serverį su Visual Studio Code.
- Suprasti dabartinius MCP transporto mechanizmus ir kodėl stdio yra rekomenduojamas.

## Stdio transportas – kaip jis veikia

Stdio transportas yra vienas iš dviejų palaikomų transporto tipų dabartinėje MCP specifikacijoje (2025-06-18). Štai kaip jis veikia:

- **Paprastas bendravimas**: Serveris skaito JSON-RPC žinutes iš standartinės įvesties (`stdin`) ir siunčia žinutes į standartinę išvestį (`stdout`).
- **Procesų pagrindu**: Klientas paleidžia MCP serverį kaip subprocesą.
- **Žinučių formatas**: Žinutės yra atskiros JSON-RPC užklausos, pranešimai arba atsakymai, atskirti naujomis eilutėmis.
- **Žurnalavimas**: Serveris GALI rašyti UTF-8 eilutes į standartinę klaidą (`stderr`) žurnalavimo tikslais.

### Pagrindiniai reikalavimai:
- Žinutės PRIVALO būti atskirtos naujomis eilutėmis ir NEGALI turėti įterptų naujų eilučių.
- Serveris NEGALI rašyti nieko į `stdout`, kas nėra galiojanti MCP žinutė.
- Klientas NEGALI rašyti nieko į serverio `stdin`, kas nėra galiojanti MCP žinutė.

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

Ankstesniame kode:

- Importuojame `Server` klasę ir `StdioServerTransport` iš MCP SDK.
- Sukuriame serverio instanciją su pagrindine konfigūracija ir galimybėmis.

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

Ankstesniame kode:

- Sukuriame serverio instanciją naudodami MCP SDK.
- Apibrėžiame įrankius naudodami dekoratorius.
- Naudojame `stdio_server` kontekstinį valdytoją transportui valdyti.

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

Pagrindinis skirtumas nuo SSE yra tas, kad stdio serveriai:

- Nereikalauja žiniatinklio serverio nustatymo ar HTTP galinių taškų.
- Paleidžiami kaip subprocesai klientų.
- Bendrauja per stdin/stdout srautus.
- Yra paprastesni įgyvendinti ir derinti.

## Užduotis: Stdio serverio kūrimas

Norėdami sukurti serverį, turime atsižvelgti į du dalykus:

- Turime naudoti žiniatinklio serverį, kad atskleistume galinius taškus ryšiui ir žinutėms.

## Laboratorija: Paprasto MCP stdio serverio kūrimas

Šioje laboratorijoje sukursime paprastą MCP serverį, naudodami rekomenduojamą stdio transportą. Šis serveris atskleis įrankius, kuriuos klientai galės iškviesti naudodami standartinį Model Context Protocol.

### Reikalavimai

- Python 3.8 ar naujesnė versija.
- MCP Python SDK: `pip install mcp`.
- Pagrindinis asinchroninio programavimo supratimas.

Pradėkime kurti pirmąjį MCP stdio serverį:

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

## Pagrindiniai skirtumai nuo pašalinto SSE metodo

**Stdio transportas (dabartinis standartas):**
- Paprastas subprocesų modelis – klientas paleidžia serverį kaip vaiko procesą.
- Bendravimas per stdin/stdout naudojant JSON-RPC žinutes.
- Nereikia HTTP serverio nustatymo.
- Geresnis našumas ir saugumas.
- Lengvesnis derinimas ir kūrimas.

**SSE transportas (pašalintas nuo MCP 2025-06-18):**
- Reikėjo HTTP serverio su SSE galiniais taškais.
- Sudėtingesnis nustatymas su žiniatinklio serverio infrastruktūra.
- Papildomi saugumo aspektai HTTP galiniams taškams.
- Dabar pakeistas „Streamable HTTP“ žiniatinklio scenarijams.

### Stdio serverio kūrimas

Norėdami sukurti stdio serverį, turime:

1. **Importuoti reikalingas bibliotekas** – Reikia MCP serverio komponentų ir stdio transporto.
2. **Sukurti serverio instanciją** – Apibrėžti serverį su jo galimybėmis.
3. **Apibrėžti įrankius** – Pridėti funkcionalumą, kurį norime atskleisti.
4. **Nustatyti transportą** – Konfigūruoti stdio bendravimą.
5. **Paleisti serverį** – Pradėti serverį ir valdyti žinutes.

Sukurkime tai žingsnis po žingsnio:

### 1 žingsnis: Sukurti pagrindinį stdio serverį

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

### 2 žingsnis: Pridėti daugiau įrankių

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

### 3 žingsnis: Paleisti serverį

Išsaugokite kodą kaip `server.py` ir paleiskite jį iš komandinės eilutės:

```bash
python server.py
```

Serveris pradės veikti ir lauks įvesties iš stdin. Jis bendrauja naudodamas JSON-RPC žinutes per stdio transportą.

### 4 žingsnis: Testavimas su „Inspector“

Galite išbandyti savo serverį naudodami MCP „Inspector“:

1. Įdiekite „Inspector“: `npx @modelcontextprotocol/inspector`.
2. Paleiskite „Inspector“ ir nukreipkite jį į savo serverį.
3. Išbandykite sukurtus įrankius.

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

// Pridėti įrankius
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Gauti asmeninį pasveikinimą",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Asmens, kurį reikia pasveikinti, vardas",
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
          text: `Sveiki, ${request.params.arguments?.name}! Sveiki atvykę į MCP stdio serverį.`,
        },
      ],
    };
  } else {
    throw new Error(`Nežinomas įrankis: ${request.params.name}`);
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
    [Description("Gauti asmeninį pasveikinimą")]
    public string GetGreeting(string name)
    {
        return $"Sveiki, {name}! Sveiki atvykę į MCP stdio serverį.";
    }

    [Description("Apskaičiuoti dviejų skaičių sumą")]
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

1. Sukurkime keletą įrankių, tam sukursime failą *Tools.cs* su šiuo turiniu:

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

2. **Atidarykite žiniatinklio sąsają**: „Inspector“ atidarys naršyklės langą, kuriame bus rodomos jūsų serverio galimybės.

3. **Išbandykite įrankius**: 
   - Išbandykite `get_greeting` įrankį su skirtingais vardais.
   - Testuokite `calculate_sum` įrankį su įvairiais skaičiais.
   - Iškvieskite `get_server_info` įrankį, kad pamatytumėte serverio metaduomenis.

4. **Stebėkite bendravimą**: „Inspector“ rodo JSON-RPC žinutes, keičiamas tarp kliento ir serverio.

### Ką turėtumėte matyti

Kai jūsų serveris paleidžiamas teisingai, turėtumėte matyti:
- Serverio galimybes, išvardytas „Inspector“.
- Įrankius, prieinamus testavimui.
- Sėkmingus JSON-RPC žinučių mainus.
- Įrankių atsakymus, rodomus sąsajoje.

### Dažnos problemos ir sprendimai

**Serveris nepaleidžiamas:**
- Patikrinkite, ar visos priklausomybės įdiegtos: `pip install mcp`.
- Patikrinkite Python sintaksę ir įtrauką.
- Ieškokite klaidų pranešimų konsolėje.

**Įrankiai nerodomi:**
- Įsitikinkite, kad yra `@server.tool()` dekoratoriai.
- Patikrinkite, ar įrankių funkcijos apibrėžtos prieš `main()`.
- Patikrinkite, ar serveris tinkamai sukonfigūruotas.

**Ryšio problemos:**
- Įsitikinkite, kad serveris teisingai naudoja stdio transportą.
- Patikrinkite, ar kiti procesai netrukdo.
- Patikrinkite „Inspector“ komandos sintaksę.

## Užduotis

Pabandykite sukurti serverį su daugiau galimybių. Žr. [šį puslapį](https://api.chucknorris.io/), kad, pavyzdžiui, pridėtumėte įrankį, kuris kviečia API. Jūs nusprendžiate, kaip turėtų atrodyti serveris. Smagaus kūrimo :)

## Sprendimas

[Sprendimas](./solution/README.md) Štai galimas sprendimas su veikiančiu kodu.

## Pagrindinės išvados

Pagrindinės šio skyriaus išvados yra šios:

- Stdio transportas yra rekomenduojamas mechanizmas vietiniams MCP serveriams.
- Stdio transportas leidžia sklandų bendravimą tarp MCP serverių ir klientų, naudojant standartinius įvesties ir išvesties srautus.
- Galite tiesiogiai naudoti „Inspector“ ir Visual Studio Code, kad naudotumėte stdio serverius, todėl derinimas ir integracija yra paprasti.

## Pavyzdžiai 

- [Java skaičiuotuvas](../samples/java/calculator/README.md)
- [.Net skaičiuotuvas](../../../../03-GettingStarted/samples/csharp)
- [JavaScript skaičiuotuvas](../samples/javascript/README.md)
- [TypeScript skaičiuotuvas](../samples/typescript/README.md)
- [Python skaičiuotuvas](../../../../03-GettingStarted/samples/python) 

## Papildomi ištekliai

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Kas toliau

## Kiti žingsniai

Dabar, kai išmokote kurti MCP serverius su stdio transportu, galite tyrinėti sudėtingesnes temas:

- **Toliau**: [HTTP transliavimas su MCP („Streamable HTTP“)](../06-http-streaming/README.md) – Sužinokite apie kitą palaikomą transporto mechanizmą nuotoliniams serveriams.
- **Sudėtinga**: [MCP saugumo geriausios praktikos](../../02-Security/README.md) – Įgyvendinkite saugumą savo MCP serveriuose.
- **Produkcija**: [Diegimo strategijos](../09-deployment/README.md) – Diegkite savo serverius produkciniam naudojimui.

## Papildomi ištekliai

- [MCP specifikacija 2025-06-18](https://spec.modelcontextprotocol.io/specification/) – Oficiali specifikacija.
- [MCP SDK dokumentacija](https://github.com/modelcontextprotocol/sdk) – SDK nuorodos visoms kalboms.
- [Bendruomenės pavyzdžiai](../../06-CommunityContributions/README.md) – Daugiau serverių pavyzdžių iš bendruomenės.

---

**Atsakomybės apribojimas**:  
Šis dokumentas buvo išverstas naudojant AI vertimo paslaugą [Co-op Translator](https://github.com/Azure/co-op-translator). Nors siekiame tikslumo, prašome atkreipti dėmesį, kad automatiniai vertimai gali turėti klaidų ar netikslumų. Originalus dokumentas jo gimtąja kalba turėtų būti laikomas autoritetingu šaltiniu. Kritinei informacijai rekomenduojama naudoti profesionalų žmogaus vertimą. Mes neprisiimame atsakomybės už nesusipratimus ar klaidingus interpretavimus, atsiradusius dėl šio vertimo naudojimo.