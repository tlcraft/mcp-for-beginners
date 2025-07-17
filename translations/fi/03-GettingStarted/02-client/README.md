<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-17T06:58:15+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "fi"
}
-->
# Asiakkaan luominen

Asiakkaat ovat räätälöityjä sovelluksia tai skriptejä, jotka kommunikoivat suoraan MCP-palvelimen kanssa pyytääkseen resursseja, työkaluja ja kehotteita. Toisin kuin tarkastelutyökalun käyttö, joka tarjoaa graafisen käyttöliittymän palvelimen kanssa vuorovaikutukseen, oman asiakkaan kirjoittaminen mahdollistaa ohjelmallisen ja automatisoidun vuorovaikutuksen. Tämä antaa kehittäjille mahdollisuuden integroida MCP:n ominaisuudet omiin työnkulkuihinsa, automatisoida tehtäviä ja rakentaa räätälöityjä ratkaisuja erityistarpeisiin.

## Yleiskatsaus

Tässä oppitunnissa esitellään asiakkaiden käsite Model Context Protocol (MCP) -ekosysteemissä. Opit kirjoittamaan oman asiakkaan ja yhdistämään sen MCP-palvelimeen.

## Oppimistavoitteet

Tämän oppitunnin lopussa osaat:

- Ymmärtää, mitä asiakas voi tehdä.
- Kirjoittaa oman asiakkaan.
- Yhdistää ja testata asiakasta MCP-palvelimen kanssa varmistaaksesi, että palvelin toimii odotetusti.

## Mitä asiakkaan kirjoittaminen vaatii?

Asiakkaan kirjoittamiseksi sinun tulee tehdä seuraavat asiat:

- **Tuoda oikeat kirjastot**. Käytät samaa kirjastoa kuin aiemmin, mutta eri rakenteita.
- **Luoda asiakasinstanssi**. Tämä tarkoittaa asiakkaan luomista ja yhdistämistä valittuun siirtomenetelmään.
- **Päättää, mitä resursseja listataan**. MCP-palvelimellasi on resursseja, työkaluja ja kehotteita, sinun täytyy päättää, mitkä niistä listataan.
- **Integroi asiakas isäntäohjelmaan**. Kun tiedät palvelimen ominaisuudet, sinun täytyy integroida ne isäntäohjelmaasi niin, että kun käyttäjä kirjoittaa kehotteen tai muun komennon, vastaava palvelimen toiminto kutsutaan.

Nyt kun ymmärrämme yleisellä tasolla, mitä aiomme tehdä, katsotaan seuraavaksi esimerkkiä.

### Esimerkkiasiakas

Tutustutaan tähän esimerkkiasiakkaaseen:

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

Edellisessä koodissa me:

- Tuomme kirjastot
- Luomme asiakasinstanssin ja yhdistämme sen stdio-siirrolle.
- Listaamme kehotteet, resurssit ja työkalut ja kutsumme ne kaikki.

Siinä se, asiakas, joka osaa puhua MCP-palvelimelle.

Käydään seuraavassa harjoituksessa rauhassa läpi jokainen koodinpätkä ja selitetään, mitä tapahtuu.

## Harjoitus: Asiakkaan kirjoittaminen

Kuten yllä todettiin, käytetään aikaa koodin selittämiseen, ja voit toki koodata mukana halutessasi.

### -1- Kirjastojen tuonti

Tuodaan tarvittavat kirjastot, tarvitsemme viittaukset asiakkaaseen ja valittuun siirtoprotokollaan, stdioon. stdio on protokolla paikallisesti ajettaville asioille. SSE on toinen siirtoprotokolla, jonka esittelemme tulevissa luvuissa, mutta se on toinen vaihtoehtosi. Nyt jatketaan kuitenkin stdiolla.

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

Javassa luot asiakkaan, joka yhdistyy MCP-palvelimeen edellisestä harjoituksesta. Käyttäen samaa Java Spring Boot -projektirakennetta kuin [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) -oppaassa, luo uusi Java-luokka nimeltä `SDKClient` kansioon `src/main/java/com/microsoft/mcp/sample/client/` ja lisää seuraavat importit:

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

Siirrytään instansiointiin.

### -2- Asiakkaan ja siirron instansiointi

Meidän täytyy luoda instanssi siirrolle ja asiakkaalle:

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

Edellisessä koodissa me:

- Loimme stdio-siirto-instanssin. Huomaa, miten siinä määritellään komento ja argumentit palvelimen löytämiseksi ja käynnistämiseksi, sillä se on jotain, mitä meidän täytyy tehdä asiakkaan luomisessa.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instansioimme asiakkaan antamalla sille nimen ja version.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Yhdistimme asiakkaan valittuun siirtoon.

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

Edellisessä koodissa me:

- Toimme tarvittavat kirjastot
- Instansioimme palvelimen parametri-olion, jota käytämme palvelimen käynnistämiseen, jotta voimme yhdistää siihen asiakkaalla.
- Määrittelimme metodin `run`, joka kutsuu `stdio_client`-funktiota, joka käynnistää asiakassession.
- Loimme pääsisäänkäynnin, jossa annamme `run`-metodin `asyncio.run`-funktiolle.

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

Edellisessä koodissa me:

- Toimme tarvittavat kirjastot.
- Loimme stdio-siirron ja asiakkaan `mcpClient`. Tätä käytämme listataksemme ja kutsuaksemme MCP-palvelimen toimintoja.

Huomaa, että "Arguments"-kohdassa voit osoittaa joko *.csproj*-tiedostoon tai suoritettavaan tiedostoon.

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

Edellisessä koodissa me:

- Loimme päämetodin, joka asettaa SSE-siirron osoittamaan `http://localhost:8080` -osoitteeseen, jossa MCP-palvelimemme pyörii.
- Loimme asiakasluokan, joka ottaa siirron konstruktoriparametrina.
- `run`-metodissa luomme synkronisen MCP-asiakkaan käyttäen siirtoa ja alustamme yhteyden.
- Käytimme SSE (Server-Sent Events) -siirtoa, joka sopii HTTP-pohjaiseen kommunikointiin Java Spring Boot MCP -palvelimien kanssa.

### -3- Palvelimen ominaisuuksien listaaminen

Nyt meillä on asiakas, joka voi yhdistyä, jos ohjelma ajetaan. Se ei kuitenkaan vielä listaa ominaisuuksiaan, tehdään se nyt:

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

Tässä listaamme saatavilla olevat resurssit `list_resources()` ja työkalut `list_tools` ja tulostamme ne.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Yllä on esimerkki siitä, miten voimme listata palvelimen työkalut. Jokaiselle työkalulle tulostamme sen nimen.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

Edellisessä koodissa me:

- Kutsumme `listTools()` saadaksemme kaikki MCP-palvelimen saatavilla olevat työkalut.
- Käytämme `ping()` varmistaaksemme, että yhteys palvelimeen toimii.
- `ListToolsResult` sisältää tiedot kaikista työkaluista, mukaan lukien nimet, kuvaukset ja syöteskeemat.

Hienoa, nyt olemme saaneet kaikki ominaisuudet talteen. Mutta milloin niitä käytetään? Tämä asiakas on melko yksinkertainen siinä mielessä, että meidän täytyy kutsua ominaisuudet erikseen, kun haluamme niitä. Seuraavassa luvussa luomme kehittyneemmän asiakkaan, jolla on oma suuri kielimalli, LLM. Nyt kuitenkin katsotaan, miten voimme kutsua palvelimen ominaisuuksia:

### -4- Ominaisuuksien kutsuminen

Ominaisuuksia kutsuttaessa täytyy varmistaa, että annamme oikeat argumentit ja joissain tapauksissa myös kutsuttavan nimen.

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

Edellisessä koodissa me:

- Luemme resurssin kutsumalla `readResource()` ja määrittämällä `uri`. Palvelinpuolella se näyttää todennäköisesti tältä:

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

    `uri`-arvomme `file://example.txt` vastaa palvelimen `file://{name}`. `example.txt` kartoitetaan `name`-parametriin.

- Kutsumme työkalua määrittämällä sen `name` ja `arguments` näin:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Haemme kehotteen kutsumalla `getPrompt()` parametrien `name` ja `arguments` kanssa. Palvelinpuolen koodi näyttää tältä:

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

    ja asiakaskoodisi näyttää tältä, jotta se vastaa palvelimella määriteltyä:

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

Edellisessä koodissa me:

- Kutsumme resurssia nimeltä `greeting` käyttäen `read_resource`.
- Kutsumme työkalua nimeltä `add` käyttäen `call_tool`.

### C#

1. Lisätään koodi työkalun kutsumiseen:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Tulostetaan tulos seuraavalla koodilla:

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

Edellisessä koodissa me:

- Kutsumme useita laskin-työkaluja `callTool()`-metodilla käyttäen `CallToolRequest`-olioita.
- Jokainen työkalukutsu määrittää työkalun nimen ja `Map`-tyyppisen argumenttien joukon, joita työkalu tarvitsee.
- Palvelimen työkalut odottavat tiettyjä parametrien nimiä (kuten "a", "b" matemaattisissa operaatioissa).
- Tulokset palautetaan `CallToolResult`-olioina, jotka sisältävät palvelimen vastauksen.

### -5- Asiakkaan ajaminen

Ajaaksesi asiakkaan, kirjoita seuraava komento terminaaliin:

### TypeScript

Lisää seuraava merkintä "scripts"-osioon tiedostossa *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Kutsu asiakasta seuraavalla komennolla:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Varmista ensin, että MCP-palvelimesi on käynnissä osoitteessa `http://localhost:8080`. Aja sitten asiakas:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Vaihtoehtoisesti voit ajaa koko asiakasprojektin, joka löytyy ratkaisukansiosta `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Tehtävä

Tässä tehtävässä käytät oppimaasi asiakkaan luomiseen, mutta luot oman asiakkaan.

Tässä on palvelin, jota voit käyttää ja johon sinun täytyy kutsua asiakkaasi koodilla. Katso, voitko lisätä palvelimeen lisää ominaisuuksia, jotta siitä tulee mielenkiintoisempi.

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

Katso tämä projekti nähdäksesi, miten voit [lisätä kehotteita ja resursseja](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

Tutustu myös tähän linkkiin, jossa kerrotaan, miten [kehotteita ja resursseja kutsutaan](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Ratkaisu

[Ratkaisu](./solution/README.md)

## Keskeiset opit

Tämän luvun keskeiset opit asiakkaista ovat:

- Asiakkaita voi käyttää sekä palvelimen ominaisuuksien löytämiseen että kutsumiseen.
- Asiakas voi käynnistää palvelimen samalla kun se käynnistyy itse (kuten tässä luvussa), mutta asiakkaat voivat myös yhdistää jo käynnissä oleviin palvelimiin.
- Asiakas on erinomainen tapa testata palvelimen ominaisuuksia vaihtoehtojen, kuten Inspectorin, rinnalla, kuten edellisessä luvussa kuvattiin.

## Lisäresurssit

- [Asiakkaiden rakentaminen MCP:ssä](https://modelcontextprotocol.io/quickstart/client)

## Esimerkit

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Mitä seuraavaksi

- Seuraavaksi: [Asiakkaan luominen LLM:n kanssa](../03-llm-client/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.