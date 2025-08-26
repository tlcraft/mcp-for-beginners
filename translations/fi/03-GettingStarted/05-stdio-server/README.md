<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:37:07+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "fi"
}
-->
# MCP-palvelin stdio-kuljetuksella

> **⚠️ Tärkeä päivitys**: MCP-määrittelyssä 2025-06-18 itsenäinen SSE (Server-Sent Events) -kuljetus on **poistettu käytöstä** ja korvattu "Streamable HTTP" -kuljetuksella. Nykyinen MCP-määrittely määrittelee kaksi ensisijaista kuljetusmekanismia:
> 1. **stdio** - Vakiosyöttö/-tulostus (suositeltu paikallisille palvelimille)
> 2. **Streamable HTTP** - Etäpalvelimille, jotka voivat käyttää sisäisesti SSE:tä
>
> Tämä oppitunti on päivitetty keskittymään **stdio-kuljetukseen**, joka on suositeltu lähestymistapa useimmille MCP-palvelinratkaisuille.

Stdio-kuljetus mahdollistaa MCP-palvelimien ja asiakkaiden välisen viestinnän vakiosyöttö- ja tulostusvirtojen kautta. Tämä on nykyisen MCP-määrittelyn yleisimmin käytetty ja suositeltu kuljetusmekanismi, joka tarjoaa yksinkertaisen ja tehokkaan tavan rakentaa MCP-palvelimia, jotka voidaan helposti integroida eri asiakassovelluksiin.

## Yleiskatsaus

Tämä oppitunti käsittelee MCP-palvelimien rakentamista ja käyttämistä stdio-kuljetuksen avulla.

## Oppimistavoitteet

Oppitunnin lopussa osaat:

- Rakentaa MCP-palvelimen stdio-kuljetusta käyttäen.
- Vianmäärittää MCP-palvelinta Inspectorin avulla.
- Käyttää MCP-palvelinta Visual Studio Codessa.
- Ymmärtää nykyiset MCP-kuljetusmekanismit ja miksi stdio on suositeltu.

## stdio-kuljetus – Miten se toimii

Stdio-kuljetus on yksi kahdesta tuetusta kuljetustyypistä nykyisessä MCP-määrittelyssä (2025-06-18). Näin se toimii:

- **Yksinkertainen viestintä**: Palvelin lukee JSON-RPC-viestejä vakiosyötteestä (`stdin`) ja lähettää viestejä vakio-tulosteeseen (`stdout`).
- **Prosessipohjainen**: Asiakas käynnistää MCP-palvelimen aliprosessina.
- **Viestimuoto**: Viestit ovat yksittäisiä JSON-RPC-pyyntöjä, ilmoituksia tai vastauksia, jotka erotetaan rivinvaihdolla.
- **Lokitus**: Palvelin VOI kirjoittaa UTF-8-merkkijonoja vakio-virheeseen (`stderr`) lokitusta varten.

### Keskeiset vaatimukset:
- Viestit TÄYTYY erottaa rivinvaihdolla, eikä niissä SAA olla sisäisiä rivinvaihtoja.
- Palvelin EI SAA kirjoittaa mitään `stdout`-virtaan, mikä ei ole kelvollinen MCP-viesti.
- Asiakas EI SAA kirjoittaa mitään palvelimen `stdin`-virtaan, mikä ei ole kelvollinen MCP-viesti.

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

Edellisessä koodissa:

- Tuomme `Server`-luokan ja `StdioServerTransport` MCP SDK:sta.
- Luomme palvelininstanssin perusasetuksilla ja ominaisuuksilla.

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

Edellisessä koodissa:

- Luomme palvelininstanssin MCP SDK:ta käyttäen.
- Määrittelemme työkalut koristeiden avulla.
- Käytämme stdio_server-kontekstinhallintaa kuljetuksen käsittelyyn.

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

Keskeinen ero SSE:hen verrattuna on, että stdio-palvelimet:

- Eivät vaadi verkkopalvelimen asennusta tai HTTP-päätepisteitä.
- Käynnistetään asiakkaan toimesta aliprosesseina.
- Viestivät stdin/stdout-virtojen kautta.
- Ovat yksinkertaisempia toteuttaa ja vianmäärittää.

## Harjoitus: Stdio-palvelimen luominen

Palvelimen luomisessa on huomioitava kaksi asiaa:

- Meidän täytyy käyttää verkkopalvelinta päätepisteiden ja viestien tarjoamiseen.

## Lab: Yksinkertaisen MCP stdio-palvelimen luominen

Tässä laboratoriossa luomme yksinkertaisen MCP-palvelimen käyttäen suositeltua stdio-kuljetusta. Tämä palvelin tarjoaa työkaluja, joita asiakkaat voivat kutsua standardin Model Context Protocolin avulla.

### Esivaatimukset

- Python 3.8 tai uudempi
- MCP Python SDK: `pip install mcp`
- Perustiedot asynkronisesta ohjelmoinnista

Aloitetaan ensimmäisen MCP stdio-palvelimen luomisella:

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

## Keskeiset erot vanhentuneeseen SSE-lähestymistapaan

**Stdio-kuljetus (nykyinen standardi):**
- Yksinkertainen aliprosessimalli – asiakas käynnistää palvelimen lapsiprosessina.
- Viestintä stdin/stdout:n kautta JSON-RPC-viesteillä.
- Ei vaadi HTTP-palvelimen asennusta.
- Parempi suorituskyky ja turvallisuus.
- Helpompi vianmäärittää ja kehittää.

**SSE-kuljetus (poistettu käytöstä MCP 2025-06-18):**
- Vaati HTTP-palvelimen SSE-päätepisteillä.
- Monimutkaisempi asennus verkkopalvelininfrastruktuurin kanssa.
- Lisäturvahuomioita HTTP-päätepisteille.
- Korvattu Streamable HTTP:llä verkkopohjaisiin skenaarioihin.

### Palvelimen luominen stdio-kuljetuksella

Palvelimen luomisessa meidän täytyy:

1. **Tuoda tarvittavat kirjastot** – Tarvitsemme MCP-palvelinkomponentit ja stdio-kuljetuksen.
2. **Luoda palvelininstanssi** – Määritellä palvelin sen ominaisuuksilla.
3. **Määritellä työkalut** – Lisätä haluamamme toiminnallisuus.
4. **Asettaa kuljetus** – Konfiguroida stdio-viestintä.
5. **Käynnistää palvelin** – Käynnistää palvelin ja käsitellä viestit.

Rakennetaan tämä vaihe vaiheelta:

### Vaihe 1: Perus stdio-palvelimen luominen

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

### Vaihe 2: Lisää työkaluja

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

### Vaihe 3: Palvelimen käynnistäminen

Tallenna koodi tiedostoon `server.py` ja suorita se komentoriviltä:

```bash
python server.py
```

Palvelin käynnistyy ja odottaa syötettä stdin:stä. Se viestii JSON-RPC-viesteillä stdio-kuljetuksen kautta.

### Vaihe 4: Testaus Inspectorilla

Voit testata palvelintasi MCP Inspectorilla:

1. Asenna Inspector: `npx @modelcontextprotocol/inspector`
2. Suorita Inspector ja osoita se palvelimeesi.
3. Testaa luomiasi työkaluja.

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

// Lisää työkaluja
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Hanki henkilökohtainen tervehdys",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Henkilön nimi, jota tervehditään",
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
          text: `Hei, ${request.params.arguments?.name}! Tervetuloa MCP stdio-palvelimeen.`,
        },
      ],
    };
  } else {
    throw new Error(`Tuntematon työkalu: ${request.params.name}`);
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
    [Description("Hanki henkilökohtainen tervehdys")]
    public string GetGreeting(string name)
    {
        return $"Hei, {name}! Tervetuloa MCP stdio-palvelimeen.";
    }

    [Description("Laske kahden luvun summa")]
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

1. Luodaan ensin työkaluja, tätä varten luomme tiedoston *Tools.cs* seuraavalla sisällöllä:

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

2. **Avaa verkkokäyttöliittymä**: Inspector avaa selaimen ikkunan, jossa näkyvät palvelimesi ominaisuudet.

3. **Testaa työkaluja**: 
   - Kokeile `get_greeting`-työkalua eri nimillä.
   - Testaa `calculate_sum`-työkalua eri numeroilla.
   - Kutsu `get_server_info`-työkalua nähdäksesi palvelimen metadataa.

4. **Seuraa viestintää**: Inspector näyttää JSON-RPC-viestit, joita vaihdetaan asiakkaan ja palvelimen välillä.

### Mitä sinun pitäisi nähdä

Kun palvelimesi käynnistyy oikein, sinun pitäisi nähdä:
- Palvelimen ominaisuudet listattuna Inspectorissa.
- Työkalut testattavissa.
- Onnistuneet JSON-RPC-viestinvaihdot.
- Työkalujen vastaukset käyttöliittymässä.

### Yleiset ongelmat ja ratkaisut

**Palvelin ei käynnisty:**
- Tarkista, että kaikki riippuvuudet on asennettu: `pip install mcp`.
- Varmista Python-syntaksi ja sisennys.
- Etsi virheilmoituksia konsolista.

**Työkalut eivät näy:**
- Varmista, että `@server.tool()`-koristeet ovat käytössä.
- Tarkista, että työkalufunktiot on määritelty ennen `main()`-funktiota.
- Varmista, että palvelin on oikein konfiguroitu.

**Yhteysongelmat:**
- Varmista, että palvelin käyttää stdio-kuljetusta oikein.
- Tarkista, ettei muut prosessit häiritse.
- Varmista Inspector-komennon syntaksi.

## Tehtävä

Kokeile laajentaa palvelintasi lisäämällä ominaisuuksia. Katso [tämä sivu](https://api.chucknorris.io/) ja lisää esimerkiksi työkalu, joka kutsuu API:a. Päätä itse, miltä palvelimen pitäisi näyttää. Pidä hauskaa :)

## Ratkaisu

[Ratkaisu](./solution/README.md) Tässä mahdollinen ratkaisu toimivalla koodilla.

## Keskeiset opit

Tämän luvun keskeiset opit ovat seuraavat:

- Stdio-kuljetus on suositeltu mekanismi paikallisille MCP-palvelimille.
- Stdio-kuljetus mahdollistaa saumattoman viestinnän MCP-palvelimien ja asiakkaiden välillä vakiosyöttö- ja tulostusvirtojen avulla.
- Voit käyttää sekä Inspectoria että Visual Studio Codea stdio-palvelimien suoraan kuluttamiseen, mikä tekee vianmäärityksestä ja integroinnista yksinkertaista.

## Esimerkit 

- [Java-laskin](../samples/java/calculator/README.md)
- [.Net-laskin](../../../../03-GettingStarted/samples/csharp)
- [JavaScript-laskin](../samples/javascript/README.md)
- [TypeScript-laskin](../samples/typescript/README.md)
- [Python-laskin](../../../../03-GettingStarted/samples/python) 

## Lisäresurssit

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Mitä seuraavaksi

## Seuraavat askeleet

Nyt kun olet oppinut rakentamaan MCP-palvelimia stdio-kuljetuksella, voit tutkia edistyneempiä aiheita:

- **Seuraavaksi**: [HTTP Streaming MCP:n kanssa (Streamable HTTP)](../06-http-streaming/README.md) - Opi toinen tuettu kuljetusmekanismi etäpalvelimille.
- **Edistynyt**: [MCP:n turvallisuuden parhaat käytännöt](../../02-Security/README.md) - Toteuta turvallisuus MCP-palvelimissasi.
- **Tuotanto**: [Julkaisustrategiat](../09-deployment/README.md) - Julkaise palvelimesi tuotantokäyttöön.

## Lisäresurssit

- [MCP-määrittely 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - Virallinen määrittely.
- [MCP SDK -dokumentaatio](https://github.com/modelcontextprotocol/sdk) - SDK-viitteet kaikille kielille.
- [Yhteisön esimerkit](../../06-CommunityContributions/README.md) - Lisää palvelinesimerkkejä yhteisöltä.

---

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.