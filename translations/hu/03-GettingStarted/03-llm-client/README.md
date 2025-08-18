<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
  "translation_date": "2025-08-18T19:32:29+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hu"
}
-->
# LLM kliens létrehozása

Eddig láthattad, hogyan hozhatsz létre szervert és klienst. A kliens képes volt kifejezetten hívni a szervert, hogy listázza annak eszközeit, erőforrásait és promptjait. Ez azonban nem túl praktikus megközelítés. A felhasználód az ügynöki korszakban él, és elvárja, hogy promptokat használjon, valamint természetes nyelven kommunikáljon egy LLM-mel. A felhasználódat nem érdekli, hogy MCP-t használsz-e a képességeid tárolására, de elvárja, hogy természetes nyelven tudjon interakcióba lépni. Hogyan oldjuk meg ezt? A megoldás az, hogy egy LLM-et adunk a klienshez.

## Áttekintés

Ebben a leckében arra koncentrálunk, hogyan adjunk hozzá egy LLM-et a klienshez, és bemutatjuk, hogy ez hogyan biztosít sokkal jobb élményt a felhasználó számára.

## Tanulási célok

A lecke végére képes leszel:

- Létrehozni egy LLM-mel rendelkező klienst.
- Zökkenőmentesen interakcióba lépni egy MCP szerverrel egy LLM segítségével.
- Jobb felhasználói élményt nyújtani a kliens oldalon.

## Megközelítés

Próbáljuk megérteni, milyen megközelítést kell alkalmaznunk. Egy LLM hozzáadása egyszerűnek hangzik, de tényleg így van?

Így fog a kliens interakcióba lépni a szerverrel:

1. Kapcsolatot létesít a szerverrel.

1. Listázza a képességeket, promptokat, erőforrásokat és eszközöket, majd elmenti azok sémáját.

1. Hozzáad egy LLM-et, és átadja a mentett képességeket és azok sémáját olyan formátumban, amelyet az LLM megért.

1. Kezeli a felhasználói promptot úgy, hogy átadja azt az LLM-nek, az eszközökkel együtt, amelyeket a kliens listázott.

Nagyszerű, most már értjük, hogyan tudjuk ezt magas szinten megvalósítani. Próbáljuk ki az alábbi gyakorlatban.

## Gyakorlat: LLM-mel rendelkező kliens létrehozása

Ebben a gyakorlatban megtanuljuk, hogyan adjunk hozzá egy LLM-et a kliensünkhöz.

### Hitelesítés GitHub személyes hozzáférési token segítségével

GitHub token létrehozása egyszerű folyamat. Így teheted meg:

- Menj a GitHub beállításokhoz – Kattints a profilképedre a jobb felső sarokban, majd válaszd a Beállítások lehetőséget.
- Navigálj a Fejlesztői beállításokhoz – Görgess le, és kattints a Fejlesztői beállítások lehetőségre.
- Válaszd a Személyes hozzáférési tokeneket – Kattints a Személyes hozzáférési tokenekre, majd az Új token létrehozása gombra.
- Konfiguráld a tokenedet – Adj hozzá egy megjegyzést referenciaként, állíts be lejárati dátumot, és válaszd ki a szükséges jogosultságokat.
- Generáld és másold a tokent – Kattints a Token generálása gombra, és győződj meg róla, hogy azonnal lemásolod, mivel később nem fogod tudni újra megtekinteni.

### -1- Kapcsolódás a szerverhez

Először hozzuk létre a kliensünket:

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

Az előző kódban:

- Importáltuk a szükséges könyvtárakat.
- Létrehoztunk egy osztályt két taggal, `client` és `openai`, amelyek segítenek a kliens kezelésében és az LLM-mel való interakcióban.
- Konfiguráltuk az LLM példányunkat, hogy a GitHub Modellek inference API-ját használja a `baseUrl` beállításával.

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

Az előző kódban:

- Importáltuk az MCP-hez szükséges könyvtárakat.
- Létrehoztunk egy klienst.

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

Először hozzá kell adnod a LangChain4j függőségeket a `pom.xml` fájlodhoz. Add hozzá ezeket a függőségeket az MCP integráció és a GitHub Modellek támogatásának engedélyezéséhez:

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

Ezután hozd létre a Java kliens osztályodat:

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

Az előző kódban:

- **Hozzáadtuk a LangChain4j függőségeket**: Szükséges az MCP integrációhoz, az OpenAI hivatalos klienséhez és a GitHub Modellek támogatásához.
- **Importáltuk a LangChain4j könyvtárakat**: Az MCP integrációhoz és az OpenAI chat modell funkcionalitásához.
- **Létrehoztunk egy `ChatLanguageModel`-t**: Konfiguráltuk, hogy a GitHub Modelleket használja a GitHub tokeneddel.
- **Beállítottuk a HTTP transportot**: Server-Sent Events (SSE) használatával kapcsolódtunk az MCP szerverhez.
- **Létrehoztunk egy MCP klienst**: Amely kezeli a kommunikációt a szerverrel.
- **Használtuk a LangChain4j beépített MCP támogatását**: Amely egyszerűsíti az LLM-ek és MCP szerverek közötti integrációt.

#### Rust

Ez a példa feltételezi, hogy van egy Rust alapú MCP szervered. Ha nincs, térj vissza az [01-first-server](../01-first-server/README.md) leckéhez, hogy létrehozd a szervert.

Miután megvan a Rust MCP szervered, nyiss meg egy terminált, és navigálj ugyanabba a könyvtárba, mint a szerver. Ezután futtasd az alábbi parancsot egy új LLM kliens projekt létrehozásához:

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

Add hozzá a következő függőségeket a `Cargo.toml` fájlodhoz:

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> Nincs hivatalos Rust könyvtár az OpenAI-hoz, azonban az `async-openai` crate egy [közösség által karbantartott könyvtár](https://platform.openai.com/docs/libraries/rust#rust), amelyet gyakran használnak.

Nyisd meg a `src/main.rs` fájlt, és cseréld le annak tartalmát az alábbi kódra:

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

Ez a kód beállít egy alapvető Rust alkalmazást, amely kapcsolódik egy MCP szerverhez és a GitHub Modellekhez az LLM interakciókhoz.

> [!IMPORTANT]
> Győződj meg róla, hogy beállítod az `OPENAI_API_KEY` környezeti változót a GitHub tokeneddel, mielőtt futtatnád az alkalmazást.

Nagyszerű, a következő lépésben listázzuk a szerver képességeit.
Hozzáadjuk a következő függvényt a `main.rs` fájlhoz:

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

Ez a függvény fogadja az LLM kliensét, egy üzenetlistát (beleértve a felhasználói promptot), az MCP szerver eszközeit, és küld egy kérést az LLM-nek, amely visszaadja a választ.

Az LLM válasza egy `choices` tömböt tartalmaz. Feldolgoznunk kell az eredményt, hogy lássuk, vannak-e `tool_calls`. Ez jelzi, hogy az LLM egy adott eszközt szeretne meghívni argumentumokkal. Adjuk hozzá a következő kódot a `main.rs` fájl aljához, hogy definiáljunk egy függvényt az LLM válaszának kezelésére:

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

Ha `tool_calls` jelen van, a függvény kinyeri az eszköz információit, meghívja az MCP szervert az eszköz kérésével, és hozzáadja az eredményeket a beszélgetési üzenetekhez. Ezután folytatja a beszélgetést az LLM-mel, és az üzenetek frissülnek az asszisztens válaszával és az eszköz hívás eredményeivel.

Az MCP hívásokhoz szükséges eszköz hívási információk kinyeréséhez hozzáadunk egy segédfüggvényt, amely mindent kinyer, ami a híváshoz szükséges. Adjuk hozzá a következő kódot a `main.rs` fájl aljához:

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

Most, hogy minden darab a helyén van, kezelhetjük a kezdeti felhasználói promptot és meghívhatjuk az LLM-et. Frissítsük a `main` függvényt az alábbi kóddal:

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

Ez az LLM-et fogja lekérdezni a kezdeti felhasználói prompttal, amely két szám összegét kéri, és feldolgozza a választ, hogy dinamikusan kezelje az eszköz hívásokat.

Nagyszerű, sikerült!

## Feladat

Vegyük a gyakorlatban használt kódot, és építsük ki a szervert további eszközökkel. Ezután hozzunk létre egy klienst egy LLM-mel, mint a gyakorlatban, és teszteljük különböző promptokkal, hogy megbizonyosodjunk arról, hogy az összes szerver eszköz dinamikusan meghívásra kerül. Az ilyen típusú kliens építése biztosítja, hogy a végfelhasználó nagyszerű felhasználói élményt kapjon, mivel promptokat használhat, ahelyett, hogy pontos kliens parancsokat kellene megadnia, és nem kell tudnia az MCP szerverről.

## Megoldás

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Fő tanulságok

- Az LLM hozzáadása a klienshez jobb módot biztosít a felhasználóknak az MCP szerverekkel való interakcióra.
- Az MCP szerver válaszát olyan formátumra kell konvertálni, amelyet az LLM megért.

## Minták

- [Java Kalkulátor](../samples/java/calculator/README.md)
- [.Net Kalkulátor](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulátor](../samples/javascript/README.md)
- [TypeScript Kalkulátor](../samples/typescript/README.md)
- [Python Kalkulátor](../../../../03-GettingStarted/samples/python)
- [Rust Kalkulátor](../../../../03-GettingStarted/samples/rust)

## További források

## Mi következik?

- Következő: [Szerver fogyasztása a Visual Studio Code használatával](../04-vscode/README.md)

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítószolgáltatás segítségével készült fordítás. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.