<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
  "translation_date": "2025-08-18T16:15:10+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "fi"
}
-->
# Luominen asiakas LLM:n avulla

Tähän mennessä olet nähnyt, kuinka luodaan palvelin ja asiakas. Asiakas on voinut kutsua palvelinta eksplisiittisesti listatakseen sen työkalut, resurssit ja kehotteet. Tämä ei kuitenkaan ole kovin käytännöllinen lähestymistapa. Käyttäjäsi elää agenttien aikakaudella ja odottaa voivansa käyttää kehotteita ja kommunikoida LLM:n kanssa. Käyttäjääsi ei kiinnosta, käytätkö MCP:tä kyvykkyyksien tallentamiseen, mutta hän odottaa voivansa käyttää luonnollista kieltä vuorovaikutukseen. Kuinka tämä ratkaistaan? Ratkaisu on lisätä LLM asiakkaaseen.

## Yleiskatsaus

Tässä osiossa keskitymme LLM:n lisäämiseen asiakkaaseen ja näytämme, kuinka tämä parantaa käyttäjäkokemusta merkittävästi.

## Oppimistavoitteet

Tämän osion lopussa osaat:

- Luoda asiakkaan, jossa on LLM.
- Vuorovaikuttaa saumattomasti MCP-palvelimen kanssa LLM:n avulla.
- Tarjota paremman loppukäyttäjäkokemuksen asiakaspuolella.

## Lähestymistapa

Yritetään ymmärtää, mitä lähestymistapaa meidän tulee käyttää. LLM:n lisääminen kuulostaa yksinkertaiselta, mutta miten se oikeasti tehdään?

Näin asiakas vuorovaikuttaa palvelimen kanssa:

1. Yhdistä palvelimeen.

1. Listaa kyvykkyydet, kehotteet, resurssit ja työkalut ja tallenna niiden skeema.

1. Lisää LLM ja välitä tallennetut kyvykkyydet ja niiden skeema muodossa, jonka LLM ymmärtää.

1. Käsittele käyttäjän kehotetta välittämällä se LLM:lle yhdessä asiakkaan listaamien työkalujen kanssa.

Hienoa, nyt ymmärrämme korkean tason, kuinka tämä tehdään. Kokeillaan tätä seuraavassa harjoituksessa.

## Harjoitus: Asiakkaan luominen LLM:n avulla

Tässä harjoituksessa opimme lisäämään LLM:n asiakkaaseemme.

### Autentikointi GitHubin henkilökohtaisen käyttöoikeustunnuksen avulla

GitHub-tunnuksen luominen on yksinkertainen prosessi. Näin se tehdään:

- Siirry GitHub-asetuksiin – Klikkaa profiilikuvaasi oikeassa yläkulmassa ja valitse Asetukset.
- Siirry Kehittäjäasetuksiin – Vieritä alas ja klikkaa Kehittäjäasetukset.
- Valitse Henkilökohtaiset käyttöoikeustunnukset – Klikkaa Henkilökohtaiset käyttöoikeustunnukset ja sitten Luo uusi tunnus.
- Määritä tunnuksesi – Lisää muistiinpano viitteeksi, aseta vanhenemispäivä ja valitse tarvittavat käyttöoikeudet (lupat).
- Luo ja kopioi tunnus – Klikkaa Luo tunnus ja varmista, että kopioit sen heti, sillä et voi nähdä sitä uudelleen.

### -1- Yhdistä palvelimeen

Luodaan ensin asiakkaamme:

#### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MCPClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", 
            apiKey: process.env.GITHUB_TOKEN,
        });

        this.client = new Client(
            {
                name: "example-client",
                version: "1.0.0"
            },
            {
                capabilities: {
                prompts: {},
                resources: {},
                tools: {}
                }
            }
            );    
    }
}
```

Edellä olevassa koodissa olemme:

- Tuoneet tarvittavat kirjastot.
- Luoneet luokan, jossa on kaksi jäsentä, `client` ja `openai`, jotka auttavat hallitsemaan asiakasta ja vuorovaikuttamaan LLM:n kanssa.
- Konfiguroineet LLM-instanssin käyttämään GitHub-malleja asettamalla `baseUrl` osoittamaan inferenssi-API:hen.

#### Python

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

Edellä olevassa koodissa olemme:

- Tuoneet tarvittavat kirjastot MCP:lle.
- Luoneet asiakkaan.

#### .NET

```csharp
using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using System.Text.Json;

var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
    Arguments = [],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

#### Java

Ensiksi sinun täytyy lisätä LangChain4j-riippuvuudet `pom.xml`-tiedostoosi. Lisää nämä riippuvuudet mahdollistamaan MCP-integraatio ja GitHub-mallien tuki:

```xml
<properties>
    <langchain4j.version>1.0.0-beta3</langchain4j.version>
</properties>

<dependencies>
    <!-- LangChain4j MCP Integration -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-mcp</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- OpenAI Official API Client -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-open-ai-official</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- GitHub Models Support -->
    <dependency>
        <groupId>dev.langchain4j</groupId>
        <artifactId>langchain4j-github-models</artifactId>
        <version>${langchain4j.version}</version>
    </dependency>
    
    <!-- Spring Boot Starter (optional, for production apps) -->
    <dependency>
        <groupId>org.springframework.boot</groupId>
        <artifactId>spring-boot-starter-actuator</artifactId>
    </dependency>
</dependencies>
```

Luo sitten Java-asiakasluokkasi:

```java
import dev.langchain4j.mcp.McpToolProvider;
import dev.langchain4j.mcp.client.DefaultMcpClient;
import dev.langchain4j.mcp.client.McpClient;
import dev.langchain4j.mcp.client.transport.McpTransport;
import dev.langchain4j.mcp.client.transport.http.HttpMcpTransport;
import dev.langchain4j.model.chat.ChatLanguageModel;
import dev.langchain4j.model.openaiofficial.OpenAiOfficialChatModel;
import dev.langchain4j.service.AiServices;
import dev.langchain4j.service.tool.ToolProvider;

import java.time.Duration;
import java.util.List;

public class LangChain4jClient {
    
    public static void main(String[] args) throws Exception {        // Configure the LLM to use GitHub Models
        ChatLanguageModel model = OpenAiOfficialChatModel.builder()
                .isGitHubModels(true)
                .apiKey(System.getenv("GITHUB_TOKEN"))
                .timeout(Duration.ofSeconds(60))
                .modelName("gpt-4.1-nano")
                .build();

        // Create MCP transport for connecting to server
        McpTransport transport = new HttpMcpTransport.Builder()
                .sseUrl("http://localhost:8080/sse")
                .timeout(Duration.ofSeconds(60))
                .logRequests(true)
                .logResponses(true)
                .build();

        // Create MCP client
        McpClient mcpClient = new DefaultMcpClient.Builder()
                .transport(transport)
                .build();
    }
}
```

Edellä olevassa koodissa olemme:

- **Lisänneet LangChain4j-riippuvuudet**: Tarvitaan MCP-integraatioon, OpenAI:n viralliseen asiakkaaseen ja GitHub-mallien tukeen.
- **Tuoneet LangChain4j-kirjastot**: MCP-integraatiota ja OpenAI:n chat-mallin toiminnallisuutta varten.
- **Luoneet `ChatLanguageModel`**: Konfiguroitu käyttämään GitHub-malleja GitHub-tunnuksesi avulla.
- **Asettaneet HTTP-siirron**: Käyttämällä Server-Sent Events (SSE) -tekniikkaa MCP-palvelimeen yhdistämiseen.
- **Luoneet MCP-asiakkaan**: Joka hoitaa kommunikoinnin palvelimen kanssa.
- **Käyttäneet LangChain4j:n sisäänrakennettua MCP-tukea**: Joka yksinkertaistaa LLM:n ja MCP-palvelimien välistä integraatiota.

#### Rust

Tämä esimerkki olettaa, että sinulla on Rust-pohjainen MCP-palvelin käynnissä. Jos sinulla ei ole sellaista, katso [01-first-server](../01-first-server/README.md) -osio palvelimen luomiseksi.

Kun sinulla on Rust MCP-palvelin, avaa terminaali ja siirry samaan hakemistoon kuin palvelin. Suorita sitten seuraava komento luodaksesi uuden LLM-asiakasprojektin:

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

Lisää seuraavat riippuvuudet `Cargo.toml`-tiedostoosi:

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> Rustille ei ole virallista OpenAI-kirjastoa, mutta `async-openai`-paketti on [yhteisön ylläpitämä kirjasto](https://platform.openai.com/docs/libraries/rust#rust), jota käytetään yleisesti.

Avaa `src/main.rs`-tiedosto ja korvaa sen sisältö seuraavalla koodilla:

```rust
use async_openai::{Client, config::OpenAIConfig};
use rmcp::{
    RmcpError,
    model::{CallToolRequestParam, ListToolsResult},
    service::{RoleClient, RunningService, ServiceExt},
    transport::{ConfigureCommandExt, TokioChildProcess},
};
use serde_json::{Value, json};
use std::error::Error;
use tokio::process::Command;

#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    // Initial message
    let mut messages = vec![json!({"role": "user", "content": "What is the sum of 3 and 2?"})];

    // Setup OpenAI client
    let api_key = std::env::var("OPENAI_API_KEY")?;
    let openai_client = Client::with_config(
        OpenAIConfig::new()
            .with_api_base("https://models.github.ai/inference/chat")
            .with_api_key(api_key),
    );

    // Setup MCP client
    let server_dir = std::path::Path::new(env!("CARGO_MANIFEST_DIR"))
        .parent()
        .unwrap()
        .join("calculator-server");

    let mcp_client = ()
        .serve(
            TokioChildProcess::new(Command::new("cargo").configure(|cmd| {
                cmd.arg("run").current_dir(server_dir);
            }))
            .map_err(RmcpError::transport_creation::<TokioChildProcess>)?,
        )
        .await?;

    // TODO: Get MCP tool listing 

    // TODO: LLM conversation with tool calls

    Ok(())
}
```

Tämä koodi asettaa perus Rust-sovelluksen, joka yhdistyy MCP-palvelimeen ja GitHub-malleihin LLM-vuorovaikutusta varten.

> [!IMPORTANT]
> Varmista, että asetat `OPENAI_API_KEY` ympäristömuuttujan GitHub-tunnuksellasi ennen sovelluksen suorittamista.

Hienoa, seuraavaksi listataan palvelimen kyvykkyydet.
Lisää seuraava funktio `main.rs`-tiedostoosi:

```rust
async fn call_llm(
    client: &Client<OpenAIConfig>,
    messages: &[Value],
    tools: &ListToolsResult,
) -> Result<Value, Box<dyn Error>> {
    let response = client
        .completions()
        .create_byot(json!({
            "messages": messages,
            "model": "openai/gpt-4.1",
            "tools": format_tools(tools).await?,
        }))
        .await?;
    Ok(response)
}
```

Tämä funktio ottaa LLM-asiakkaan, viestien listan (mukaan lukien käyttäjän kehotteen), MCP-palvelimen työkalut ja lähettää pyynnön LLM:lle, palauttaen vastauksen.

LLM:n vastaus sisältää `choices`-taulukon. Meidän täytyy käsitellä tulos tarkistaaksemme, onko mukana `tool_calls`. Tämä kertoo, että LLM pyytää tietyn työkalun kutsumista argumenttien kanssa. Lisää seuraava koodi `main.rs`-tiedostosi loppuun määrittääksesi funktion LLM-vastauksen käsittelyyn:

```rust
async fn process_llm_response(
    llm_response: &Value,
    mcp_client: &RunningService<RoleClient, ()>,
    openai_client: &Client<OpenAIConfig>,
    mcp_tools: &ListToolsResult,
    messages: &mut Vec<Value>,
) -> Result<(), Box<dyn Error>> {
    let Some(message) = llm_response
        .get("choices")
        .and_then(|c| c.as_array())
        .and_then(|choices| choices.first())
        .and_then(|choice| choice.get("message"))
    else {
        return Ok(());
    };

    // Print content if available
    if let Some(content) = message.get("content").and_then(|c| c.as_str()) {
        println!("🤖 {}", content);
    }

    // Handle tool calls
    if let Some(tool_calls) = message.get("tool_calls").and_then(|tc| tc.as_array()) {
        messages.push(message.clone()); // Add assistant message

        // Execute each tool call
        for tool_call in tool_calls {
            let (tool_id, name, args) = extract_tool_call_info(tool_call)?;
            println!("⚡ Calling tool: {}", name);

            let result = mcp_client
                .call_tool(CallToolRequestParam {
                    name: name.into(),
                    arguments: serde_json::from_str::<Value>(&args)?.as_object().cloned(),
                })
                .await?;

            // Add tool result to messages
            messages.push(json!({
                "role": "tool",
                "tool_call_id": tool_id,
                "content": serde_json::to_string_pretty(&result)?
            }));
        }

        // Continue conversation with tool results
        let response = call_llm(openai_client, messages, mcp_tools).await?;
        Box::pin(process_llm_response(
            &response,
            mcp_client,
            openai_client,
            mcp_tools,
            messages,
        ))
        .await?;
    }
    Ok(())
}
```

Jos `tool_calls` on mukana, funktio poimii työkalutiedot, kutsuu MCP-palvelinta työkalupyynnön kanssa ja lisää tulokset keskusteluviesteihin. Se jatkaa keskustelua LLM:n kanssa, ja viestit päivitetään avustajan vastauksella ja työkalukutsun tuloksilla.

Poimiaksesi työkalukutsutiedot, jotka LLM palauttaa MCP-kutsuja varten, lisää toinen apufunktio, joka poimii kaiken tarvittavan kutsun tekemiseen. Lisää seuraava koodi `main.rs`-tiedostosi loppuun:

```rust
fn extract_tool_call_info(tool_call: &Value) -> Result<(String, String, String), Box<dyn Error>> {
    let tool_id = tool_call
        .get("id")
        .and_then(|id| id.as_str())
        .unwrap_or("")
        .to_string();
    let function = tool_call.get("function").ok_or("Missing function")?;
    let name = function
        .get("name")
        .and_then(|n| n.as_str())
        .unwrap_or("")
        .to_string();
    let args = function
        .get("arguments")
        .and_then(|a| a.as_str())
        .unwrap_or("{}")
        .to_string();
    Ok((tool_id, name, args))
}
```

Kun kaikki osat ovat valmiina, voimme nyt käsitellä alkuperäisen käyttäjän kehotteen ja kutsua LLM:n. Päivitä `main`-funktiosi sisältämään seuraava koodi:

```rust
// LLM conversation with tool calls
let response = call_llm(&openai_client, &messages, &tools).await?;
process_llm_response(
    &response,
    &mcp_client,
    &openai_client,
    &tools,
    &mut messages,
)
.await?;
```

Tämä kysyy LLM:ltä alkuperäisen käyttäjän kehotteen, jossa pyydetään kahden luvun summaa, ja käsittelee vastauksen dynaamisesti työkalukutsujen käsittelyä varten.

Hienoa, onnistuit!

## Tehtävä

Ota harjoituksen koodi ja rakenna palvelin lisäämällä siihen enemmän työkaluja. Luo sitten asiakas LLM:n kanssa, kuten harjoituksessa, ja testaa sitä erilaisilla kehotteilla varmistaaksesi, että kaikki palvelimen työkalut kutsutaan dynaamisesti. Tällainen tapa rakentaa asiakas tarjoaa loppukäyttäjälle erinomaisen käyttökokemuksen, sillä he voivat käyttää kehotteita tarkkojen asiakaskomentojen sijaan, eivätkä he ole tietoisia MCP-palvelimen kutsumisesta.

## Ratkaisu

[Ratkaisu](/03-GettingStarted/03-llm-client/solution/README.md)

## Keskeiset Opit

- LLM:n lisääminen asiakkaaseen tarjoaa paremman tavan käyttäjille olla vuorovaikutuksessa MCP-palvelimien kanssa.
- MCP-palvelimen vastaus täytyy muuntaa muotoon, jonka LLM ymmärtää.

## Esimerkit

- [Java-laskin](../samples/java/calculator/README.md)
- [.Net-laskin](../../../../03-GettingStarted/samples/csharp)
- [JavaScript-laskin](../samples/javascript/README.md)
- [TypeScript-laskin](../samples/typescript/README.md)
- [Python-laskin](../../../../03-GettingStarted/samples/python)
- [Rust-laskin](../../../../03-GettingStarted/samples/rust)

## Lisäresurssit

## Mitä Seuraavaksi

- Seuraavaksi: [Palvelimen kuluttaminen Visual Studio Codella](../04-vscode/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä AI-käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäisellä kielellä tulisi pitää ensisijaisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.