<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
  "translation_date": "2025-08-18T16:04:47+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "ro"
}
-->
# Crearea unui client cu LLM

Până acum, ai văzut cum să creezi un server și un client. Clientul a fost capabil să apeleze explicit serverul pentru a lista uneltele, resursele și prompturile acestuia. Totuși, aceasta nu este o abordare foarte practică. Utilizatorul tău trăiește în era agenților inteligenți și se așteaptă să folosească prompturi și să comunice cu un LLM pentru a realiza acest lucru. Pentru utilizatorul tău, nu contează dacă folosești MCP sau nu pentru a stoca capabilitățile, dar se așteaptă să interacționeze prin limbaj natural. Deci, cum rezolvăm această problemă? Soluția constă în adăugarea unui LLM la client.

## Prezentare generală

În această lecție ne concentrăm pe adăugarea unui LLM la clientul tău și arătăm cum aceasta oferă o experiență mult mai bună pentru utilizator.

## Obiective de învățare

La finalul acestei lecții, vei putea:

- Să creezi un client cu un LLM.
- Să interacționezi fără probleme cu un server MCP folosind un LLM.
- Să oferi o experiență mai bună utilizatorului final pe partea de client.

## Abordare

Să încercăm să înțelegem abordarea pe care trebuie să o adoptăm. Adăugarea unui LLM pare simplă, dar cum facem acest lucru în practică?

Iată cum va interacționa clientul cu serverul:

1. Stabilește conexiunea cu serverul.

1. Listează capabilitățile, prompturile, resursele și uneltele și salvează schema acestora.

1. Adaugă un LLM și transmite capabilitățile salvate și schema lor într-un format pe care LLM-ul îl înțelege.

1. Gestionează un prompt al utilizatorului, transmițându-l către LLM împreună cu uneltele listate de client.

Excelent, acum înțelegem cum putem face acest lucru la un nivel înalt. Să încercăm acest lucru în exercițiul de mai jos.

## Exercițiu: Crearea unui client cu un LLM

În acest exercițiu, vom învăța să adăugăm un LLM la clientul nostru.

### Autentificare folosind GitHub Personal Access Token

Crearea unui token GitHub este un proces simplu. Iată cum poți face acest lucru:

- Accesează Setările GitHub – Fă clic pe poza de profil din colțul din dreapta sus și selectează Setări.
- Navighează la Setările pentru Dezvoltatori – Derulează în jos și fă clic pe Setările pentru Dezvoltatori.
- Selectează Tokenuri de Acces Personal – Fă clic pe Tokenuri de acces personal și apoi pe Generare token nou.
- Configurează Tokenul – Adaugă o notă pentru referință, setează o dată de expirare și selectează permisiunile necesare (scopes).
- Generează și Copiază Tokenul – Fă clic pe Generare token și asigură-te că îl copiezi imediat, deoarece nu vei mai putea să-l vezi din nou.

### -1- Conectează-te la server

Să creăm mai întâi clientul nostru:

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

În codul precedent am:

- Importat bibliotecile necesare.
- Creat o clasă cu doi membri, `client` și `openai`, care ne vor ajuta să gestionăm un client și să interacționăm cu un LLM.
- Configurat instanța LLM pentru a folosi Modelele GitHub prin setarea `baseUrl` pentru a indica API-ul de inferență.

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

În codul precedent am:

- Importat bibliotecile necesare pentru MCP.
- Creat un client.

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

Mai întâi, va trebui să adaugi dependențele LangChain4j în fișierul `pom.xml`. Adaugă aceste dependențe pentru a permite integrarea MCP și suportul pentru Modelele GitHub:

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

Apoi creează clasa client Java:

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

În codul precedent am:

- **Adăugat dependențele LangChain4j**: Necesare pentru integrarea MCP, clientul oficial OpenAI și suportul pentru Modelele GitHub.
- **Importat bibliotecile LangChain4j**: Pentru integrarea MCP și funcționalitatea modelului de chat OpenAI.
- **Creat un `ChatLanguageModel`**: Configurat pentru a folosi Modelele GitHub cu tokenul tău GitHub.
- **Configurat transportul HTTP**: Folosind Server-Sent Events (SSE) pentru a se conecta la serverul MCP.
- **Creat un client MCP**: Care va gestiona comunicarea cu serverul.
- **Folosind suportul MCP încorporat al LangChain4j**: Care simplifică integrarea între LLM-uri și serverele MCP.

#### Rust

Acest exemplu presupune că ai un server MCP bazat pe Rust care rulează. Dacă nu ai unul, consultă lecția [01-first-server](../01-first-server/README.md) pentru a crea serverul.

Odată ce ai serverul MCP Rust, deschide un terminal și navighează la același director ca serverul. Apoi rulează următoarea comandă pentru a crea un nou proiect client LLM:

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

Adaugă următoarele dependențe în fișierul `Cargo.toml`:

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> Nu există o bibliotecă oficială Rust pentru OpenAI, totuși, cratul `async-openai` este o [bibliotecă întreținută de comunitate](https://platform.openai.com/docs/libraries/rust#rust) care este utilizată frecvent.

Deschide fișierul `src/main.rs` și înlocuiește conținutul acestuia cu următorul cod:

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

Acest cod configurează o aplicație Rust de bază care se va conecta la un server MCP și la Modelele GitHub pentru interacțiuni LLM.

> [!IMPORTANT]
> Asigură-te că setezi variabila de mediu `OPENAI_API_KEY` cu tokenul tău GitHub înainte de a rula aplicația.

Excelent, pentru pasul următor, să listăm capabilitățile serverului.

### -2- Listează capabilitățile serverului

Acum ne vom conecta la server și vom solicita capabilitățile acestuia:

#### Typescript

În aceeași clasă, adaugă următoarele metode:

```typescript
async connectToServer(transport: Transport) {
     await this.client.connect(transport);
     this.run();
     console.error("MCPClient started on stdin/stdout");
}

async run() {
    console.log("Asking server for available tools");

    // listing tools
    const toolsResult = await this.client.listTools();
}
```

În codul precedent am:

- Adăugat cod pentru conectarea la server, `connectToServer`.
- Creat o metodă `run` responsabilă pentru gestionarea fluxului aplicației noastre. Deocamdată listează doar uneltele, dar vom adăuga mai multe în curând.

#### Python

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
    print("Tool", tool.inputSchema["properties"])
```

Iată ce am adăugat:

- Listarea resurselor și uneltelor și afișarea acestora. Pentru unelte listăm și `inputSchema`, pe care îl vom folosi mai târziu.

#### .NET

```csharp
async Task<List<ChatCompletionsToolDefinition>> GetMcpTools()
{
    Console.WriteLine("Listing tools");
    var tools = await mcpClient.ListToolsAsync();

    List<ChatCompletionsToolDefinition> toolDefinitions = new List<ChatCompletionsToolDefinition>();

    foreach (var tool in tools)
    {
        Console.WriteLine($"Connected to server with tools: {tool.Name}");
        Console.WriteLine($"Tool description: {tool.Description}");
        Console.WriteLine($"Tool parameters: {tool.JsonSchema}");

        // TODO: convert tool definition from MCP tool to LLm tool     
    }

    return toolDefinitions;
}
```

În codul precedent am:

- Listat uneltele disponibile pe serverul MCP.
- Pentru fiecare unealtă, am listat numele, descrierea și schema acesteia. Aceasta din urmă este ceva ce vom folosi pentru a apela uneltele în curând.

#### Java

```java
// Create a tool provider that automatically discovers MCP tools
ToolProvider toolProvider = McpToolProvider.builder()
        .mcpClients(List.of(mcpClient))
        .build();

// The MCP tool provider automatically handles:
// - Listing available tools from the MCP server
// - Converting MCP tool schemas to LangChain4j format
// - Managing tool execution and responses
```

În codul precedent am:

- Creat un `McpToolProvider` care descoperă și înregistrează automat toate uneltele de pe serverul MCP.
- Furnizorul de unelte gestionează conversia între schemele uneltelor MCP și formatul uneltelor LangChain4j intern.
- Această abordare abstractizează procesul manual de listare și conversie a uneltelor.

#### Rust

Recuperarea uneltelor de pe serverul MCP se face folosind metoda `list_tools`. În funcția ta `main`, după configurarea clientului MCP, adaugă următorul cod:

```rust
// Get MCP tool listing 
let tools = mcp_client.list_tools(Default::default()).await?;
```

### -3- Convertește capabilitățile serverului în unelte pentru LLM

Pasul următor după listarea capabilităților serverului este să le convertești într-un format pe care LLM-ul îl înțelege. Odată ce facem acest lucru, putem oferi aceste capabilități ca unelte pentru LLM.
Vom face mai multe apeluri către LLM, așa că să definim o funcție care va gestiona apelul către LLM. Adăugați următoarea funcție în fișierul `main.rs`:

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

Această funcție primește clientul LLM, o listă de mesaje (inclusiv promptul utilizatorului), instrumentele de la serverul MCP și trimite o cerere către LLM, returnând răspunsul.

Răspunsul de la LLM va conține un array de `choices`. Va trebui să procesăm rezultatul pentru a vedea dacă există `tool_calls`. Acest lucru ne indică faptul că LLM solicită apelarea unui instrument specific cu argumente. Adăugați următorul cod la sfârșitul fișierului `main.rs` pentru a defini o funcție care să gestioneze răspunsul LLM:

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

Dacă sunt prezente `tool_calls`, funcția extrage informațiile despre instrument, apelează serverul MCP cu cererea pentru instrument și adaugă rezultatele la mesajele conversației. Apoi continuă conversația cu LLM, iar mesajele sunt actualizate cu răspunsul asistentului și rezultatele apelului instrumentului.

Pentru a extrage informațiile despre apelul instrumentului pe care LLM le returnează pentru apelurile MCP, vom adăuga o altă funcție auxiliară pentru a extrage tot ce este necesar pentru a face apelul. Adăugați următorul cod la sfârșitul fișierului `main.rs`:

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

Cu toate piesele pregătite, putem acum gestiona promptul inițial al utilizatorului și apela LLM. Actualizați funcția `main` pentru a include următorul cod:

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

Aceasta va interoga LLM cu promptul inițial al utilizatorului, cerând suma a două numere, și va procesa răspunsul pentru a gestiona dinamic apelurile instrumentelor.

Grozav, ați reușit!

## Sarcină

Luați codul din exercițiu și construiți serverul cu mai multe instrumente. Apoi creați un client cu un LLM, așa cum este în exercițiu, și testați-l cu diferite prompturi pentru a vă asigura că toate instrumentele serverului sunt apelate dinamic. Acest mod de a construi un client înseamnă că utilizatorul final va avea o experiență excelentă, deoarece va putea folosi prompturi, în loc de comenzi exacte ale clientului, și va fi inconștient de orice server MCP care este apelat.

## Soluție

[Soluție](/03-GettingStarted/03-llm-client/solution/README.md)

## Concluzii principale

- Adăugarea unui LLM la clientul dvs. oferă o modalitate mai bună pentru utilizatori de a interacționa cu serverele MCP.
- Trebuie să convertiți răspunsul serverului MCP într-un format pe care LLM îl poate înțelege.

## Exemple

- [Calculator Java](../samples/java/calculator/README.md)
- [Calculator .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](../samples/javascript/README.md)
- [Calculator TypeScript](../samples/typescript/README.md)
- [Calculator Python](../../../../03-GettingStarted/samples/python)
- [Calculator Rust](../../../../03-GettingStarted/samples/rust)

## Resurse suplimentare

## Ce urmează

- Următorul: [Consumarea unui server folosind Visual Studio Code](../04-vscode/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa natală ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.