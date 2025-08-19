<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "57f7b15640bb96ef2f6f09003eec935e",
<<<<<<< HEAD
  "translation_date": "2025-08-18T23:02:12+00:00",
=======
  "translation_date": "2025-08-18T18:22:59+00:00",
>>>>>>> origin/main
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "uk"
}
-->
# Створення клієнта з LLM

<<<<<<< HEAD
До цього моменту ви бачили, як створити сервер і клієнта. Клієнт міг явно викликати сервер, щоб отримати список його інструментів, ресурсів і підказок. Однак це не дуже практичний підхід. Ваш користувач живе в епоху агентів і очікує використовувати підказки та спілкуватися з LLM для виконання завдань. Для користувача неважливо, чи використовуєте ви MCP для зберігання своїх можливостей, але він очікує взаємодії за допомогою природної мови. Як це вирішити? Рішення полягає в додаванні LLM до клієнта.

## Огляд

У цьому уроці ми зосередимося на додаванні LLM до вашого клієнта та покажемо, як це забезпечує набагато кращий досвід для користувача.
=======
До цього моменту ви бачили, як створити сервер і клієнта. Клієнт міг явно викликати сервер, щоб отримати список його інструментів, ресурсів і підказок. Однак це не дуже практичний підхід. Ваш користувач живе в епоху агентів і очікує використовувати підказки та спілкуватися з LLM для виконання завдань. Для користувача неважливо, чи використовуєте ви MCP для зберігання своїх можливостей, але вони очікують взаємодії за допомогою природної мови. Як це вирішити? Рішення полягає в додаванні LLM до клієнта.

## Огляд

У цьому уроці ми зосередимося на додаванні LLM до клієнта та покажемо, як це забезпечує набагато кращий досвід для користувача.
>>>>>>> origin/main

## Цілі навчання

Після завершення цього уроку ви зможете:

- Створити клієнта з LLM.
- Безперешкодно взаємодіяти з сервером MCP за допомогою LLM.
- Забезпечити кращий досвід для кінцевого користувача на стороні клієнта.

## Підхід

Давайте зрозуміємо підхід, який нам потрібно застосувати. Додавання LLM звучить просто, але як це зробити на практиці?

Ось як клієнт буде взаємодіяти з сервером:

1. Встановити з'єднання з сервером.

1. Отримати список можливостей, підказок, ресурсів та інструментів і зберегти їх схему.

1. Додати LLM і передати збережені можливості та їх схему у форматі, зрозумілому для LLM.

1. Обробити запит користувача, передавши його до LLM разом із інструментами, переліченими клієнтом.

<<<<<<< HEAD
Чудово, тепер ми розуміємо, як це зробити на високому рівні. Давайте спробуємо це реалізувати в наступній вправі.
=======
Чудово, тепер ми розуміємо, як це зробити на високому рівні. Давайте спробуємо це виконати в наступній вправі.
>>>>>>> origin/main

## Вправа: Створення клієнта з LLM

У цій вправі ми навчимося додавати LLM до нашого клієнта.

<<<<<<< HEAD
### Аутентифікація за допомогою персонального токена доступу GitHub
=======
### Аутентифікація за допомогою GitHub Personal Access Token
>>>>>>> origin/main

Створення токена GitHub — це простий процес. Ось як це зробити:

- Перейдіть до налаштувань GitHub – Натисніть на своє фото профілю у верхньому правому куті та виберіть "Settings".
- Перейдіть до "Developer Settings" – Прокрутіть вниз і натисніть "Developer Settings".
- Виберіть "Personal Access Tokens" – Натисніть "Personal access tokens", а потім "Generate new token".
- Налаштуйте свій токен – Додайте примітку для довідки, встановіть дату закінчення терміну дії та виберіть необхідні області (дозволи).
<<<<<<< HEAD
- Згенеруйте та скопіюйте токен – Натисніть "Generate token" і обов'язково скопіюйте його одразу, оскільки ви не зможете побачити його знову.
=======
- Згенеруйте та скопіюйте токен – Натисніть "Generate token" і обов’язково скопіюйте його одразу, оскільки ви не зможете побачити його знову.
>>>>>>> origin/main

### -1- Підключення до сервера

Спочатку створимо нашого клієнта:

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

У наведеному вище коді ми:

- Імпортували необхідні бібліотеки.
- Створили клас із двома членами, `client` і `openai`, які допоможуть нам керувати клієнтом і взаємодіяти з LLM відповідно.
<<<<<<< HEAD
- Налаштували наш екземпляр LLM для використання моделей GitHub, встановивши `baseUrl`, що вказує на API інференції.
=======
- Налаштували наш екземпляр LLM для використання GitHub Models, встановивши `baseUrl`, що вказує на API інференції.
>>>>>>> origin/main

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

У наведеному вище коді ми:

- Імпортували необхідні бібліотеки для MCP.
- Створили клієнта.

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

<<<<<<< HEAD
Спочатку вам потрібно додати залежності LangChain4j до вашого файлу `pom.xml`. Додайте ці залежності для інтеграції MCP і підтримки моделей GitHub:
=======
Спочатку вам потрібно додати залежності LangChain4j до вашого файлу `pom.xml`. Додайте ці залежності для інтеграції MCP і підтримки GitHub Models:
>>>>>>> origin/main

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

Потім створіть клас клієнта Java:

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

У наведеному вище коді ми:

<<<<<<< HEAD
- **Додали залежності LangChain4j**: Необхідні для інтеграції MCP, офіційного клієнта OpenAI і підтримки моделей GitHub.
- **Імпортували бібліотеки LangChain4j**: Для інтеграції MCP і функціональності чат-моделі OpenAI.
- **Створили `ChatLanguageModel`**: Налаштований для використання моделей GitHub із вашим токеном GitHub.
- **Налаштували HTTP-транспорт**: Використовуючи події, що надсилаються сервером (SSE), для підключення до сервера MCP.
- **Створили клієнта MCP**: Який буде обробляти зв'язок із сервером.
=======
- **Додали залежності LangChain4j**: Необхідні для інтеграції MCP, офіційного клієнта OpenAI і підтримки GitHub Models.
- **Імпортували бібліотеки LangChain4j**: Для інтеграції MCP і функціональності моделі чату OpenAI.
- **Створили `ChatLanguageModel`**: Налаштований для використання GitHub Models із вашим токеном GitHub.
- **Налаштували HTTP-транспорт**: Використовуючи Server-Sent Events (SSE) для підключення до сервера MCP.
- **Створили клієнта MCP**: Для обробки комунікації з сервером.
>>>>>>> origin/main
- **Використали вбудовану підтримку MCP у LangChain4j**: Що спрощує інтеграцію між LLM і серверами MCP.

#### Rust

Цей приклад передбачає, що у вас працює сервер MCP на основі Rust. Якщо у вас його немає, зверніться до уроку [01-first-server](../01-first-server/README.md), щоб створити сервер.

Після того, як у вас є сервер MCP на основі Rust, відкрийте термінал і перейдіть до тієї ж директорії, що й сервер. Потім виконайте наступну команду, щоб створити новий проєкт клієнта LLM:

```bash
mkdir calculator-llmclient
cd calculator-llmclient
cargo init
```

Додайте наступні залежності до вашого файлу `Cargo.toml`:

```toml
[dependencies]
async-openai = { version = "0.29.0", features = ["byot"] }
rmcp = { version = "0.5.0", features = ["client", "transport-child-process"] }
serde_json = "1.0.141"
tokio = { version = "1.46.1", features = ["rt-multi-thread"] }
```

> [!NOTE]
> Офіційної бібліотеки Rust для OpenAI немає, однак `async-openai` — це [бібліотека, підтримувана спільнотою](https://platform.openai.com/docs/libraries/rust#rust), яка часто використовується.

Відкрийте файл `src/main.rs` і замініть його вміст наступним кодом:

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

<<<<<<< HEAD
Цей код налаштовує базовий додаток Rust, який підключатиметься до сервера MCP і моделей GitHub для взаємодії з LLM.
=======
Цей код налаштовує базовий додаток Rust, який підключається до сервера MCP і GitHub Models для взаємодії з LLM.
>>>>>>> origin/main

> [!IMPORTANT]
> Перед запуском програми переконайтеся, що змінна середовища `OPENAI_API_KEY` встановлена вашим токеном GitHub.

Чудово, на наступному кроці ми отримаємо список можливостей сервера.

### -2- Отримання можливостей сервера

<<<<<<< HEAD
Тепер ми підключимося до сервера і запитаємо його можливості:
=======
Тепер ми підключимося до сервера та запитаємо його можливості:
>>>>>>> origin/main

#### TypeScript

У тому ж класі додайте наступні методи:

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

У наведеному вище коді ми:

- Додали код для підключення до сервера, `connectToServer`.
- Створили метод `run`, відповідальний за обробку потоку нашого додатка. Поки що він лише перелічує інструменти, але ми скоро додамо більше.

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

Ось що ми додали:

- Отримання списку ресурсів та інструментів і їх виведення. Для інструментів ми також виводимо `inputSchema`, який використаємо пізніше.

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

У наведеному вище коді ми:

- Перелічили інструменти, доступні на сервері MCP.
- Для кожного інструмента вивели ім'я, опис і його схему. Останнє ми використаємо для виклику інструментів найближчим часом.

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

У наведеному вище коді ми:

- Створили `McpToolProvider`, який автоматично виявляє та реєструє всі інструменти з сервера MCP.
<<<<<<< HEAD
- Постачальник інструментів обробляє перетворення між схемами інструментів MCP і форматом інструментів LangChain4j внутрішньо.
=======
- Провайдер інструментів обробляє перетворення між схемами інструментів MCP і форматом інструментів LangChain4j внутрішньо.
>>>>>>> origin/main
- Цей підхід абстрагує ручний процес переліку та перетворення інструментів.

#### Rust

Отримання інструментів із сервера MCP здійснюється за допомогою методу `list_tools`. У вашій функції `main`, після налаштування клієнта MCP, додайте наступний код:

```rust
// Get MCP tool listing 
let tools = mcp_client.list_tools(Default::default()).await?;
```

### -3- Перетворення можливостей сервера на інструменти LLM

Наступний крок після отримання можливостей сервера — це перетворення їх у формат, зрозумілий для LLM. Після цього ми зможемо надати ці можливості як інструменти для LLM.

#### TypeScript

1. Додайте наступний код для перетворення відповіді від сервера MCP на формат інструментів, зрозумілий для LLM:

    ```typescript
    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
        }) {
        // Create a zod schema based on the input_schema
        const schema = z.object(tool.input_schema);
    
        return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
            name: tool.name,
            description: tool.description,
            parameters: {
            type: "object",
            properties: tool.input_schema.properties,
            required: tool.input_schema.required,
            },
            },
        };
    }

    ```

    Наведений вище код бере відповідь від сервера MCP і перетворює її на визначення інструменту, зрозуміле для LLM.

1. Оновіть метод `run`, щоб перелічити можливості сервера:

    ```typescript
    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
            name: tool.name,
            description: tool.description,
            input_schema: tool.inputSchema,
            });
        });
    }
    ```

    У наведеному коді ми оновили метод `run`, щоб перебирати результати та для кожного елемента викликати `openAiToolAdapter`.

#### Python

1. Спочатку створимо наступну функцію-конвертер:

    ```python
    def convert_to_llm_tool(tool):
        tool_schema = {
            "type": "function",
            "function": {
                "name": tool.name,
                "description": tool.description,
                "type": "function",
                "parameters": {
                    "type": "object",
                    "properties": tool.inputSchema["properties"]
                }
            }
        }

        return tool_schema
    ```

    У функції `convert_to_llm_tools` ми беремо відповідь інструменту MCP і перетворюємо її на формат, зрозумілий для LLM.

<<<<<<< HEAD
1. Далі оновимо код клієнта, щоб використовувати цю функцію:
=======
1. Далі оновимо наш код клієнта, щоб використовувати цю функцію:
>>>>>>> origin/main

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Тут ми додаємо виклик `convert_to_llm_tool`, щоб перетворити відповідь інструменту MCP на щось, що ми зможемо передати LLM пізніше.

#### .NET

<<<<<<< HEAD
1. Додамо код для перетворення відповіді інструменту MCP на щось, зрозуміле для LLM:
=======
1. Додамо код для перетворення відповіді інструменту MCP на щось, що зрозуміє LLM:
>>>>>>> origin/main

```csharp
ChatCompletionsToolDefinition ConvertFrom(string name, string description, JsonElement jsonElement)
{ 
    // convert the tool to a function definition
    FunctionDefinition functionDefinition = new FunctionDefinition(name)
    {
        Description = description,
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = jsonElement
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    // create a tool definition
    ChatCompletionsToolDefinition toolDefinition = new ChatCompletionsToolDefinition(functionDefinition);
    return toolDefinition;
}
```

У наведеному коді ми:

- Створили функцію `ConvertFrom`, яка приймає ім'я, опис і схему вводу.
- Визначили функціональність, яка створює `FunctionDefinition`, що передається до `ChatCompletionsDefinition`. Останнє — це те, що розуміє LLM.

1. Подивимося, як оновити існуючий код, щоб скористатися цією функцією:

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

            JsonElement propertiesElement;
            tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

            var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
            Console.WriteLine($"Tool definition: {def}");
            toolDefinitions.Add(def);

            Console.WriteLine($"Properties: {propertiesElement}");        
        }

        return toolDefinitions;
    }
    ```

    У наведеному коді ми:

<<<<<<< HEAD
    - Оновили функцію для перетворення відповіді інструменту MCP на інструмент LLM. Виділимо доданий код:
=======
    - Оновили функцію для перетворення відповіді інструменту MCP на інструмент LLM. Ось виділений код, який ми додали:
>>>>>>> origin/main

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

<<<<<<< HEAD
        Схема вводу є частиною відповіді інструменту, але знаходиться в атрибуті "properties", тому нам потрібно її витягти. Далі ми викликаємо `ConvertFrom` із деталями інструменту. Тепер, коли ми виконали основну роботу, подивимося, як це все об'єднується, коли ми обробляємо запит користувача.
=======
        Схема вводу є частиною відповіді інструменту, але знаходиться в атрибуті "properties", тому нам потрібно її витягти. Далі ми викликаємо `ConvertFrom` із деталями інструменту. Тепер, коли ми виконали основну роботу, подивимося, як усе це об'єднується, коли ми обробляємо запит користувача.
>>>>>>> origin/main

#### Java

```java
// Create a Bot interface for natural language interaction
public interface Bot {
    String chat(String prompt);
}

// Configure the AI service with LLM and MCP tools
Bot bot = AiServices.builder(Bot.class)
        .chatLanguageModel(model)
        .toolProvider(toolProvider)
        .build();
```

У наведеному коді ми:

- Визначили простий інтерфейс `Bot` для взаємодії природною мовою.
<<<<<<< HEAD
- Використали `AiServices` LangChain4j для автоматичного зв'язування LLM із постачальником інструментів MCP.
=======
- Використали `AiServices` LangChain4j для автоматичного зв’язування LLM із провайдером інструментів MCP.
>>>>>>> origin/main
- Фреймворк автоматично обробляє перетворення схем інструментів і виклики функцій.
- Цей підхід усуває необхідність ручного перетворення інструментів — LangChain4j обробляє всю складність.

#### Rust

<<<<<<< HEAD
Щоб перетворити відповідь інструменту MCP на формат, зрозумілий для LLM, ми додамо допоміжну функцію, яка форматуватиме список інструментів. Додайте наступний код до вашого файлу `main.rs` нижче функції `main`. Це буде викликано під час запитів до LLM:
=======
Щоб перетворити відповідь інструменту MCP на формат, зрозумілий для LLM, ми додамо допоміжну функцію, яка форматує список інструментів. Додайте наступний код до вашого файлу `main.rs` нижче функції `main`. Це буде викликано під час запитів до LLM:
>>>>>>> origin/main

```rust
async fn format_tools(tools: &ListToolsResult) -> Result<Vec<Value>, Box<dyn Error>> {
    let tools_json = serde_json::to_value(tools)?;
    let Some(tools_array) = tools_json.get("tools").and_then(|t| t.as_array()) else {
        return Ok(vec![]);
    };

    let formatted_tools = tools_array
        .iter()
        .filter_map(|tool| {
            let name = tool.get("name")?.as_str()?;
            let description = tool.get("description")?.as_str()?;
            let schema = tool.get("inputSchema")?;

            Some(json!({
                "type": "function",
                "function": {
                    "name": name,
                    "description": description,
                    "parameters": {
                        "type": "object",
                        "properties": schema.get("properties").unwrap_or(&json!({})),
                        "required": schema.get("required").unwrap_or(&json!([]))
                    }
                }
            }))
        })
        .collect();

    Ok(formatted_tools)
}
```

<<<<<<< HEAD
Чудово, тепер ми готові обробляти запити користувачів, тож перейдемо до цього.

### -4- Обробка запиту користувача

У цій частині коду ми будемо обробляти запити користувачів.
=======
Чудово, тепер ми готові обробляти запити користувачів, тож перейдемо до цього наступного кроку.

### -4- Обробка запиту користувача

На цьому етапі коду ми будемо обробляти запити користувачів.
>>>>>>> origin/main

#### TypeScript

1. Додайте метод, який буде використовуватися для виклику нашого LLM:

    ```typescript
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
    ) {
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);


        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  

        }
    }
    ```

    У наведеному коді ми:

    - Додали метод `callTools`.
    - Метод приймає відповідь LLM і перевіряє, які інструменти потрібно викликати, якщо такі є:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Викликає інструмент, якщо LLM вказує, що його слід викликати:

        ```typescript
        // 2. Call the server's tool 
        const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
        });

        console.log("Tool result: ", toolResult);

        // 3. Do something with the result
        // TODO  
        ```

1. Оновіть метод `run`, щоб включити виклики до LLM і виклик `callTools`:

    ```typescript

    // 1. Create messages that's input for the LLM
    const prompt = "What is the sum of 2 and 3?"

    const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

    console.log("Querying LLM: ", messages[0].content);

    // 2. Calling the LLM
    let response = this.openai.chat.completions.create({
        model: "gpt-4o-mini",
        max_tokens: 1000,
        messages,
        tools: tools,
    });    

    let results: any[] = [];

    // 3. Go through the LLM response,for each choice, check if it has tool calls 
    (await response).choices.map(async (choice: { message: any; }) => {
        const message = choice.message;
        if (message.tool_calls) {
            console.log("Making tool call")
            await this.callTools(message.tool_calls, results);
        }
    });
    ```

Чудово, ось повний код:

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
import { Transport } from "@modelcontextprotocol/sdk/shared/transport.js";
import OpenAI from "openai";
import { z } from "zod"; // Import zod for schema validation

class MyClient {
    private openai: OpenAI;
    private client: Client;
    constructor(){
        this.openai = new OpenAI({
            baseURL: "https://models.inference.ai.azure.com", // might need to change to this url in the future: https://models.github.ai/inference
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

    async connectToServer(transport: Transport) {
        await this.client.connect(transport);
        this.run();
        console.error("MCPClient started on stdin/stdout");
    }

    openAiToolAdapter(tool: {
        name: string;
        description?: string;
        input_schema: any;
          }) {
          // Create a zod schema based on the input_schema
          const schema = z.object(tool.input_schema);
      
          return {
            type: "function" as const, // Explicitly set type to "function"
            function: {
              name: tool.name,
              description: tool.description,
              parameters: {
              type: "object",
              properties: tool.input_schema.properties,
              required: tool.input_schema.required,
              },
            },
          };
    }
    
    async callTools(
        tool_calls: OpenAI.Chat.Completions.ChatCompletionMessageToolCall[],
        toolResults: any[]
      ) {
        for (const tool_call of tool_calls) {
          const toolName = tool_call.function.name;
          const args = tool_call.function.arguments;
    
          console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);
    
    
          // 2. Call the server's tool 
          const toolResult = await this.client.callTool({
            name: toolName,
            arguments: JSON.parse(args),
          });
    
          console.log("Tool result: ", toolResult);
    
          // 3. Do something with the result
          // TODO  
    
         }
    }

    async run() {
        console.log("Asking server for available tools");
        const toolsResult = await this.client.listTools();
        const tools = toolsResult.tools.map((tool) => {
            return this.openAiToolAdapter({
              name: tool.name,
              description: tool.description,
              input_schema: tool.inputSchema,
            });
        });

        const prompt = "What is the sum of 2 and 3?";
    
        const messages: OpenAI.Chat.Completions.ChatCompletionMessageParam[] = [
            {
                role: "user",
                content: prompt,
            },
        ];

        console.log("Querying LLM: ", messages[0].content);
        let response = this.openai.chat.completions.create({
            model: "gpt-4o-mini",
            max_tokens: 1000,
            messages,
            tools: tools,
        });    

        let results: any[] = [];
    
        // 1. Go through the LLM response,for each choice, check if it has tool calls 
        (await response).choices.map(async (choice: { message: any; }) => {
          const message = choice.message;
          if (message.tool_calls) {
              console.log("Making tool call")
              await this.callTools(message.tool_calls, results);
          }
        });
    }
    
}

let client = new MyClient();
 const transport = new StdioClientTransport({
            command: "node",
            args: ["./build/index.js"]
        });

client.connectToServer(transport);
```

#### Python

1. Додамо імпорти, необхідні для виклику LLM:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Далі додамо функцію, яка викликатиме LLM:

    ```python
    # llm

    def call_llm(prompt, functions):
        token = os.environ["GITHUB_TOKEN"]
        endpoint = "https://models.inference.ai.azure.com"

        model_name = "gpt-4o"

        client = ChatCompletionsClient(
            endpoint=endpoint,
            credential=AzureKeyCredential(token),
        )

        print("CALLING LLM")
        response = client.complete(
            messages=[
                {
                "role": "system",
                "content": "You are a helpful assistant.",
                },
                {
                "role": "user",
                "content": prompt,
                },
            ],
            model=model_name,
            tools = functions,
            # Optional parameters
            temperature=1.,
            max_tokens=1000,
            top_p=1.    
        )

        response_message = response.choices[0].message
        
        functions_to_call = []

        if response_message.tool_calls:
            for tool_call in response_message.tool_calls:
                print("TOOL: ", tool_call)
                name = tool_call.function.name
                args = json.loads(tool_call.function.arguments)
                functions_to_call.append({ "name": name, "args": args })

        return functions_to_call
    ```

    У наведеному коді ми:

    - Передали наші функції, знайдені на сервері MCP і перетворені, до LLM.
<<<<<<< HEAD
    - Викликали LLM із цими функціями.
    - Перевірили результат, щоб побачити, які функції потрібно викликати, якщо такі є.
    - Нарешті, передали масив функцій для виклику.

1. Останній крок, оновимо основний код:
=======
    - Потім викликали LLM із цими функціями.
    - Далі перевірили результат, щоб побачити, які функції слід викликати, якщо такі є.
    - Нарешті, передали масив функцій для виклику.

1. Останній крок, оновимо наш основний код:
>>>>>>> origin/main

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    У наведеному коді ми:

    - Викликали інструмент MCP через `call_tool`, використовуючи функцію, яку LLM вважав за потрібне викликати на основі нашої підказки.
<<<<<<< HEAD
    - Вивели результат виклику інструменту на сервер MCP.
=======
    - Вивели результат виклику інструменту до сервера MCP.
>>>>>>> origin/main

#### .NET

1. Покажемо код для виконання запиту до LLM:

    ```csharp
    var tools = await GetMcpTools();

    for (int i = 0; i < tools.Count; i++)
    {
        var tool = tools[i];
        Console.WriteLine($"MCP Tools def: {i}: {tool}");
    }

    // 0. Define the chat history and the user message
    var userMessage = "add 2 and 4";

    chatHistory.Add(new ChatRequestUserMessage(userMessage));

    // 1. Define tools
    ChatCompletionsToolDefinition def = CreateToolDefinition();


    // 2. Define options, including the tools
    var options = new ChatCompletionsOptions(chatHistory)
    {
        Model = "gpt-4o-mini",
        Tools = { tools[0] }
    };

    // 3. Call the model  

    ChatCompletions? response = await client.CompleteAsync(options);
    var content = response.Content;

    ```

    У наведеному коді ми:

    - Отримали інструменти із сервера MCP, `var tools = await GetMcpTools()`.
    - Визначили підказку користувача `userMessage`.
<<<<<<< HEAD
    - Створили об'єкт опцій, що вказує модель і інструменти.
    - Зробили запит до LLM.

1. Останній крок, перевіримо, чи LLM вважає, що потрібно викликати функцію:
=======
    - Створили об’єкт параметрів, що вказує модель і інструменти.
    - Зробили запит до LLM.

1. Останній крок, перевіримо, чи LLM вважає, що слід викликати функцію:
>>>>>>> origin/main

    ```csharp
    // 4. Check if the response contains a function call
    ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
    for (int i = 0; i < response.ToolCalls.Count; i++)
    {
        var call = response.ToolCalls[i];
        Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
        //Tool call 0: add with arguments {"a":2,"b":4}

        var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(call.Arguments);
        var result = await mcpClient.CallToolAsync(
            call.Name,
            dict!,
            cancellationToken: CancellationToken.None
        );

        Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

    }
    ```

    У наведеному коді ми:

    - Перебрали список викликів функцій.
<<<<<<< HEAD
    - Для кожного виклику інструменту витягли ім'я та аргументи й викликали інструмент на сервері MCP за допомогою клієнта MCP. Нарешті, ми вивели результати.
=======
    - Для кожного виклику інструменту розібрали ім’я та аргументи й викликали інструмент на сервері MCP за допомогою клієнта MCP. Нарешті, ми вивели результати.
>>>>>>> origin/main

Ось повний код:

```csharp
using Azure;
using Azure.AI.Inference;
using Azure.Identity;
using System.Text.Json;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
using System.Text.Json;

var endpoint = "https://models.inference.ai.azure.com";
var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN"); // Your GitHub Access Token
var client = new ChatCompletionsClient(new Uri(endpoint), new AzureKeyCredential(token));
var chatHistory = new List<ChatRequestMessage>
{
    new ChatRequestSystemMessage("You are a helpful assistant that knows about AI")
};

var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "/workspaces/mcp-for-beginners/03-GettingStarted/02-client/solution/server/bin/Debug/net8.0/server",
    Arguments = [],
});

Console.WriteLine("Setting up stdio transport");

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);

ChatCompletionsToolDefinition ConvertFrom(string name, string description, JsonElement jsonElement)
{ 
    // convert the tool to a function definition
    FunctionDefinition functionDefinition = new FunctionDefinition(name)
    {
        Description = description,
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = jsonElement
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    // create a tool definition
    ChatCompletionsToolDefinition toolDefinition = new ChatCompletionsToolDefinition(functionDefinition);
    return toolDefinition;
}



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

        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);

        Console.WriteLine($"Properties: {propertiesElement}");        
    }

    return toolDefinitions;
}

// 1. List tools on mcp server

var tools = await GetMcpTools();
for (int i = 0; i < tools.Count; i++)
{
    var tool = tools[i];
    Console.WriteLine($"MCP Tools def: {i}: {tool}");
}

// 2. Define the chat history and the user message
var userMessage = "add 2 and 4";

chatHistory.Add(new ChatRequestUserMessage(userMessage));


// 3. Define options, including the tools
var options = new ChatCompletionsOptions(chatHistory)
{
    Model = "gpt-4o-mini",
    Tools = { tools[0] }
};

// 4. Call the model  

ChatCompletions? response = await client.CompleteAsync(options);
var content = response.Content;

// 5. Check if the response contains a function call
ChatCompletionsToolCall? calls = response.ToolCalls.FirstOrDefault();
for (int i = 0; i < response.ToolCalls.Count; i++)
{
    var call = response.ToolCalls[i];
    Console.WriteLine($"Tool call {i}: {call.Name} with arguments {call.Arguments}");
    //Tool call 0: add with arguments {"a":2,"b":4}

    var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(call.Arguments);
    var result = await mcpClient.CallToolAsync(
        call.Name,
        dict!,
        cancellationToken: CancellationToken.None
    );

    Console.WriteLine(result.Content.First(c => c.Type == "text").Text);

}

// 5. Print the generic response
Console.WriteLine($"Assistant response: {content}");
```

#### Java

```java
try {
    // Execute natural language requests that automatically use MCP tools
    String response = bot.chat("Calculate the sum of 24.5 and 17.3 using the calculator service");
    System.out.println(response);

    response = bot.chat("What's the square root of 144?");
    System.out.println(response);

    response = bot.chat("Show me the help for the calculator service");
    System.out.println(response);
} finally {
    mcpClient.close();
}
```

У наведеному коді ми:

- Використали прості підказки природною мовою для взаємодії з інструментами сервера MCP.
- Фреймворк LangChain4j автоматично обробляє:
  - Перетворення підказок користувача на виклики інструментів, коли це необхідно.
  - Виклик відповідних інструментів MCP на основі рішення LLM.
  - Управління потоком розмови між LLM і сервером MCP.
- Метод `bot.chat()` повертає відповіді природною мовою, які можуть включати результати виконання інструментів MCP.
- Цей підхід забезпечує безперебійну взаємодію, де користувачам не потрібно знати про реалізацію MCP.

Повний приклад коду:

```java
public class LangChain4jClient {
    
    public static void main(String[] args) throws Exception {        ChatLanguageModel model = OpenAiOfficialChatModel.builder()
                .isGitHubModels(true)
                .apiKey(System.getenv("GITHUB_TOKEN"))
                .timeout(Duration.ofSeconds(60))
                .modelName("gpt-4.1-nano")
                .timeout(Duration.ofSeconds(60))
                .build();

        McpTransport transport = new HttpMcpTransport.Builder()
                .sseUrl("http://localhost:8080/sse")
                .timeout(Duration.ofSeconds(60))
                .logRequests(true)
                .logResponses(true)
                .build();

        McpClient mcpClient = new DefaultMcpClient.Builder()
                .transport(transport)
                .build();

        ToolProvider toolProvider = McpToolProvider.builder()
                .mcpClients(List.of(mcpClient))
                .build();

        Bot bot = AiServices.builder(Bot.class)
                .chatLanguageModel(model)
                .toolProvider(toolProvider)
                .build();

        try {
            String response = bot.chat("Calculate the sum of 24.5 and 17.3 using the calculator service");
            System.out.println(response);

            response = bot.chat("What's the square root of 144?");
            System.out.println(response);

            response = bot.chat("Show me the help for the calculator service");
            System.out.println(response);
        } finally {
            mcpClient.close();
        }
    }
}
```

#### Rust

Ось де відбувається основна робота. Ми викличемо LLM із початковою підказкою користувача, потім обробимо відповідь, щоб побачити, чи потрібно викликати якісь інструменти. Якщо так, ми викличемо ці інструменти та продовжимо розмову з LLM, доки не буде отримано остаточну відповідь без необхідності викликів інструментів.
Ми будемо здійснювати кілька викликів до LLM, тому давайте визначимо функцію, яка буде обробляти виклик до LLM. Додайте наступну функцію до вашого файлу `main.rs`:

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

Ця функція приймає клієнт LLM, список повідомлень (включаючи запит користувача), інструменти з сервера MCP і надсилає запит до LLM, повертаючи відповідь.

<<<<<<< HEAD
Відповідь від LLM міститиме масив `choices`. Нам потрібно обробити результат, щоб перевірити, чи присутні `tool_calls`. Це дозволяє зрозуміти, що LLM запитує виклик конкретного інструменту з аргументами. Додайте наступний код до кінця вашого файлу `main.rs`, щоб визначити функцію для обробки відповіді LLM:
=======
Відповідь від LLM міститиме масив `choices`. Нам потрібно буде обробити результат, щоб перевірити, чи є якісь `tool_calls`. Це дозволяє зрозуміти, що LLM запитує виклик певного інструменту з аргументами. Додайте наступний код у кінець вашого файлу `main.rs`, щоб визначити функцію для обробки відповіді LLM:
>>>>>>> origin/main

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

<<<<<<< HEAD
Якщо присутні `tool_calls`, функція витягує інформацію про інструмент, викликає сервер MCP із запитом до інструменту і додає результати до повідомлень розмови. Потім вона продовжує розмову з LLM, а повідомлення оновлюються відповіддю асистента та результатами виклику інструменту.

Щоб витягнути інформацію про виклик інструменту, яку LLM повертає для викликів MCP, ми додамо ще одну допоміжну функцію, яка витягне все необхідне для здійснення виклику. Додайте наступний код до кінця вашого файлу `main.rs`:
=======
Якщо присутні `tool_calls`, функція витягує інформацію про інструмент, викликає сервер MCP із запитом до інструменту та додає результати до повідомлень розмови. Потім вона продовжує розмову з LLM, а повідомлення оновлюються відповіддю асистента та результатами виклику інструменту.

Щоб витягти інформацію про виклик інструменту, яку LLM повертає для викликів MCP, ми додамо ще одну допоміжну функцію для отримання всього необхідного для виклику. Додайте наступний код у кінець вашого файлу `main.rs`:
>>>>>>> origin/main

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

<<<<<<< HEAD
З усіма складовими на місці, тепер ми можемо обробити початковий запит користувача і викликати LLM. Оновіть вашу функцію `main`, включивши наступний код:
=======
Маючи всі необхідні частини, ми тепер можемо обробити початковий запит користувача та викликати LLM. Оновіть вашу функцію `main`, додавши наступний код:
>>>>>>> origin/main

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

<<<<<<< HEAD
Це запитає LLM з початковим запитом користувача, який просить знайти суму двох чисел, і обробить відповідь для динамічного оброблення викликів інструментів.
=======
Це дозволить зробити запит до LLM із початковим запитом користувача, який просить знайти суму двох чисел, і обробити відповідь для динамічного оброблення викликів інструментів.
>>>>>>> origin/main

Чудово, ви це зробили!

## Завдання

<<<<<<< HEAD
Візьміть код із вправи та розробіть сервер із додатковими інструментами. Потім створіть клієнт із LLM, як у вправі, і протестуйте його з різними запитами, щоб переконатися, що всі ваші серверні інструменти викликаються динамічно. Такий спосіб створення клієнта забезпечує чудовий досвід для кінцевого користувача, оскільки він може використовувати запити, а не точні команди клієнта, і бути не обізнаним про будь-який сервер MCP, який викликається.
=======
Візьміть код із вправи та розширте сервер, додавши більше інструментів. Потім створіть клієнт із LLM, як у вправі, і протестуйте його з різними запитами, щоб переконатися, що всі ваші серверні інструменти викликаються динамічно. Такий спосіб створення клієнта забезпечить чудовий користувацький досвід, оскільки користувачі зможуть використовувати запити замість точних команд клієнта і не будуть знати про виклики до сервера MCP.
>>>>>>> origin/main

## Рішення

[Рішення](/03-GettingStarted/03-llm-client/solution/README.md)

## Основні висновки

- Додавання LLM до вашого клієнта забезпечує кращий спосіб взаємодії користувачів із серверами MCP.
<<<<<<< HEAD
- Вам потрібно конвертувати відповідь сервера MCP у формат, який LLM може зрозуміти.

## Приклади

- [Java Калькулятор](../samples/java/calculator/README.md)
- [.Net Калькулятор](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Калькулятор](../samples/javascript/README.md)
- [TypeScript Калькулятор](../samples/typescript/README.md)
- [Python Калькулятор](../../../../03-GettingStarted/samples/python)
- [Rust Калькулятор](../../../../03-GettingStarted/samples/rust)
=======
- Вам потрібно перетворити відповідь сервера MCP у формат, зрозумілий для LLM.

## Приклади

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)
- [Rust Calculator](../../../../03-GettingStarted/samples/rust)
>>>>>>> origin/main

## Додаткові ресурси

## Що далі

<<<<<<< HEAD
- Далі: [Споживання сервера за допомогою Visual Studio Code](../04-vscode/README.md)
=======
- Далі: [Використання сервера у Visual Studio Code](../04-vscode/README.md)
>>>>>>> origin/main

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, зверніть увагу, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ мовою оригіналу слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується професійний переклад людиною. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.