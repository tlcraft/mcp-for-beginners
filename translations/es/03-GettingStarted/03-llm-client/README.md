<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a656dbc7648e07da08eb4d1ffde4938e",
  "translation_date": "2025-07-22T08:23:34+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "es"
}
-->
# Creando un cliente con LLM

Hasta ahora, has visto cómo crear un servidor y un cliente. El cliente ha podido llamar al servidor explícitamente para listar sus herramientas, recursos y prompts. Sin embargo, no es un enfoque muy práctico. Tu usuario vive en la era de los agentes y espera usar prompts y comunicarse con un LLM para hacerlo. Para tu usuario, no importa si usas MCP o no para almacenar tus capacidades, pero sí espera interactuar usando lenguaje natural. Entonces, ¿cómo resolvemos esto? La solución consiste en agregar un LLM al cliente.

## Descripción general

En esta lección nos enfocamos en agregar un LLM a tu cliente y mostramos cómo esto proporciona una experiencia mucho mejor para tu usuario.

## Objetivos de aprendizaje

Al final de esta lección, serás capaz de:

- Crear un cliente con un LLM.
- Interactuar sin problemas con un servidor MCP usando un LLM.
- Proporcionar una mejor experiencia al usuario final en el lado del cliente.

## Enfoque

Intentemos entender el enfoque que debemos tomar. Agregar un LLM suena simple, pero ¿realmente lo haremos?

Así es como el cliente interactuará con el servidor:

1. Establecer conexión con el servidor.

1. Listar capacidades, prompts, recursos y herramientas, y guardar su esquema.

1. Agregar un LLM y pasar las capacidades guardadas y su esquema en un formato que el LLM entienda.

1. Manejar un prompt del usuario pasándolo al LLM junto con las herramientas listadas por el cliente.

Genial, ahora entendemos cómo podemos hacer esto a alto nivel, intentémoslo en el siguiente ejercicio.

## Ejercicio: Creando un cliente con un LLM

En este ejercicio, aprenderemos a agregar un LLM a nuestro cliente.

### Autenticación usando un token de acceso personal de GitHub

Crear un token de GitHub es un proceso sencillo. Aquí te explicamos cómo hacerlo:

- Ve a Configuración de GitHub – Haz clic en tu foto de perfil en la esquina superior derecha y selecciona Configuración.
- Navega a Configuración de Desarrollador – Desplázate hacia abajo y haz clic en Configuración de Desarrollador.
- Selecciona Tokens de Acceso Personal – Haz clic en Tokens de acceso personal y luego en Generar nuevo token.
- Configura tu token – Agrega una nota para referencia, establece una fecha de expiración y selecciona los alcances necesarios (permisos).
- Genera y copia el token – Haz clic en Generar token y asegúrate de copiarlo inmediatamente, ya que no podrás verlo nuevamente.

### -1- Conectar al servidor

Primero, creemos nuestro cliente:

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

En el código anterior hemos:

- Importado las bibliotecas necesarias.
- Creado una clase con dos miembros, `client` y `openai`, que nos ayudarán a gestionar un cliente e interactuar con un LLM respectivamente.
- Configurado nuestra instancia de LLM para usar GitHub Models estableciendo `baseUrl` para apuntar a la API de inferencia.

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

En el código anterior hemos:

- Importado las bibliotecas necesarias para MCP.
- Creado un cliente.

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

Primero, necesitarás agregar las dependencias de LangChain4j a tu archivo `pom.xml`. Agrega estas dependencias para habilitar la integración con MCP y el soporte para GitHub Models:

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

Luego, crea tu clase cliente en Java:

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

En el código anterior hemos:

- **Agregado dependencias de LangChain4j**: Necesarias para la integración con MCP, el cliente oficial de OpenAI y el soporte para GitHub Models.
- **Importado las bibliotecas de LangChain4j**: Para la integración con MCP y la funcionalidad del modelo de chat de OpenAI.
- **Creado un `ChatLanguageModel`**: Configurado para usar GitHub Models con tu token de GitHub.
- **Configurado transporte HTTP**: Usando eventos enviados por el servidor (SSE) para conectarse al servidor MCP.
- **Creado un cliente MCP**: Que manejará la comunicación con el servidor.
- **Usado el soporte integrado de MCP de LangChain4j**: Que simplifica la integración entre LLMs y servidores MCP.

Genial, para nuestro próximo paso, listemos las capacidades en el servidor.

### -2- Listar capacidades del servidor

Ahora nos conectaremos al servidor y pediremos sus capacidades:

#### TypeScript

En la misma clase, agrega los siguientes métodos:

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

En el código anterior hemos:

- Agregado código para conectarnos al servidor, `connectToServer`.
- Creado un método `run` responsable de manejar el flujo de nuestra aplicación. Hasta ahora solo lista las herramientas, pero pronto agregaremos más.

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

Esto es lo que hemos agregado:

- Listado de recursos y herramientas y los hemos impreso. Para las herramientas también listamos `inputSchema`, que usaremos más adelante.

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

En el código anterior hemos:

- Listado las herramientas disponibles en el servidor MCP.
- Para cada herramienta, listado el nombre, descripción y su esquema. Este último es algo que usaremos para llamar a las herramientas próximamente.

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

En el código anterior hemos:

- Creado un `McpToolProvider` que descubre y registra automáticamente todas las herramientas del servidor MCP.
- El proveedor de herramientas maneja la conversión entre los esquemas de herramientas MCP y el formato de herramientas de LangChain4j internamente.
- Este enfoque abstrae el proceso manual de listado y conversión de herramientas.

### -3- Convertir capacidades del servidor a herramientas para LLM

El siguiente paso después de listar las capacidades del servidor es convertirlas a un formato que el LLM entienda. Una vez que hagamos eso, podemos proporcionar estas capacidades como herramientas a nuestro LLM.

#### TypeScript

1. Agrega el siguiente código para convertir la respuesta del servidor MCP a un formato de herramienta que el LLM pueda usar:

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

    El código anterior toma una respuesta del servidor MCP y la convierte en una definición de herramienta que el LLM pueda entender.

1. Actualicemos el método `run` para listar las capacidades del servidor:

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

    En el código anterior, hemos actualizado el método `run` para mapear el resultado y para cada entrada llamar a `openAiToolAdapter`.

#### Python

1. Primero, creemos la siguiente función de conversión:

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

    En la función anterior `convert_to_llm_tools` tomamos una respuesta de herramienta MCP y la convertimos a un formato que el LLM pueda entender.

1. Luego, actualicemos nuestro código de cliente para aprovechar esta función así:

    ```python
    for tool in tools.tools:
        print("Tool: ", tool.name)
        print("Tool", tool.inputSchema["properties"])
        functions.append(convert_to_llm_tool(tool))
    ```

    Aquí, estamos agregando una llamada a `convert_to_llm_tool` para convertir la respuesta de herramienta MCP a algo que podamos alimentar al LLM más adelante.

#### .NET

1. Agreguemos código para convertir la respuesta de herramienta MCP a algo que el LLM pueda entender:

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

En el código anterior hemos:

- Creado una función `ConvertFrom` que toma nombre, descripción y esquema de entrada.
- Definido funcionalidad que crea una FunctionDefinition que se pasa a un ChatCompletionsDefinition. Este último es algo que el LLM puede entender.

1. Veamos cómo podemos actualizar algo de código existente para aprovechar esta función:

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

    En el código anterior hemos:

    - Actualizado la función para convertir la respuesta de herramienta MCP a una herramienta LLM. Resaltemos el código que agregamos:

        ```csharp
        JsonElement propertiesElement;
        tool.JsonSchema.TryGetProperty("properties", out propertiesElement);

        var def = ConvertFrom(tool.Name, tool.Description, propertiesElement);
        Console.WriteLine($"Tool definition: {def}");
        toolDefinitions.Add(def);
        ```

        El esquema de entrada es parte de la respuesta de herramienta pero en el atributo "properties", por lo que necesitamos extraerlo. Además, ahora llamamos a `ConvertFrom` con los detalles de la herramienta. Ahora que hemos hecho el trabajo pesado, veamos cómo todo se junta mientras manejamos un prompt del usuario a continuación.

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

En el código anterior hemos:

- Definido una interfaz simple `Bot` para interacciones en lenguaje natural.
- Usado los `AiServices` de LangChain4j para vincular automáticamente el LLM con el proveedor de herramientas MCP.
- El marco maneja automáticamente la conversión de esquemas de herramientas y la llamada a funciones detrás de escena.
- Este enfoque elimina la conversión manual de herramientas: LangChain4j maneja toda la complejidad de convertir herramientas MCP a un formato compatible con LLM.

Genial, ahora estamos listos para manejar cualquier solicitud del usuario, así que abordemos eso a continuación.

### -4- Manejar solicitudes de prompts del usuario

En esta parte del código, manejaremos las solicitudes del usuario.

#### TypeScript

1. Agrega un método que se usará para llamar a nuestro LLM:

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

    En el código anterior hemos:

    - Agregado un método `callTools`.
    - El método toma una respuesta del LLM y verifica qué herramientas se han llamado, si es que hay alguna:

        ```typescript
        for (const tool_call of tool_calls) {
        const toolName = tool_call.function.name;
        const args = tool_call.function.arguments;

        console.log(`Calling tool ${toolName} with args ${JSON.stringify(args)}`);

        // call tool
        }
        ```

    - Llama a una herramienta, si el LLM indica que debe ser llamada:

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

1. Actualiza el método `run` para incluir llamadas al LLM y llamar a `callTools`:

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

Genial, listemos el código completo:

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

1. Agreguemos algunas importaciones necesarias para llamar a un LLM:

    ```python
    # llm
    import os
    from azure.ai.inference import ChatCompletionsClient
    from azure.ai.inference.models import SystemMessage, UserMessage
    from azure.core.credentials import AzureKeyCredential
    import json
    ```

1. Luego, agreguemos la función que llamará al LLM:

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

    En el código anterior hemos:

    - Pasado nuestras funciones, que encontramos en el servidor MCP y convertimos, al LLM.
    - Luego llamamos al LLM con dichas funciones.
    - Luego, inspeccionamos el resultado para ver qué funciones debemos llamar, si es que hay alguna.
    - Finalmente, pasamos un array de funciones para llamar.

1. Último paso, actualicemos nuestro código principal:

    ```python
    prompt = "Add 2 to 20"

    # ask LLM what tools to all, if any
    functions_to_call = call_llm(prompt, functions)

    # call suggested functions
    for f in functions_to_call:
        result = await session.call_tool(f["name"], arguments=f["args"])
        print("TOOLS result: ", result.content)
    ```

    Allí, ese fue el último paso, en el código anterior estamos:

    - Llamando a una herramienta MCP a través de `call_tool` usando una función que el LLM pensó que deberíamos llamar según nuestro prompt.
    - Imprimiendo el resultado de la llamada a la herramienta en el servidor MCP.

#### .NET

1. Mostremos algo de código para hacer una solicitud de prompt al LLM:

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

    En el código anterior hemos:

    - Obtenido herramientas del servidor MCP, `var tools = await GetMcpTools()`.
    - Definido un prompt del usuario `userMessage`.
    - Construido un objeto de opciones especificando el modelo y las herramientas.
    - Realizado una solicitud hacia el LLM.

1. Un último paso, veamos si el LLM piensa que debemos llamar a una función:

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

    En el código anterior hemos:

    - Iterado a través de una lista de llamadas a funciones.
    - Para cada llamada a herramienta, extraído el nombre y los argumentos y llamado a la herramienta en el servidor MCP usando el cliente MCP. Finalmente imprimimos los resultados.

Aquí está el código completo:

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

En el código anterior hemos:

- Usado prompts simples en lenguaje natural para interactuar con las herramientas del servidor MCP.
- El marco LangChain4j maneja automáticamente:
  - Convertir prompts de usuario en llamadas a herramientas cuando sea necesario.
  - Llamar a las herramientas MCP apropiadas según la decisión del LLM.
  - Gestionar el flujo de conversación entre el LLM y el servidor MCP.
- El método `bot.chat()` devuelve respuestas en lenguaje natural que pueden incluir resultados de ejecuciones de herramientas MCP.
- Este enfoque proporciona una experiencia de usuario fluida donde los usuarios no necesitan saber sobre la implementación subyacente de MCP.

Ejemplo de código completo:

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

¡Genial, lo lograste!

## Tarea

Toma el código del ejercicio y construye el servidor con algunas herramientas adicionales. Luego crea un cliente con un LLM, como en el ejercicio, y pruébalo con diferentes prompts para asegurarte de que todas las herramientas de tu servidor se llamen dinámicamente. Este enfoque de construir un cliente significa que el usuario final tendrá una gran experiencia, ya que podrá usar prompts en lugar de comandos exactos del cliente y será ajeno a cualquier servidor MCP que se esté llamando.

## Solución

[Solución](/03-GettingStarted/03-llm-client/solution/README.md)

## Puntos clave

- Agregar un LLM a tu cliente proporciona una mejor manera para que los usuarios interactúen con los servidores MCP.
- Necesitas convertir la respuesta del servidor MCP a algo que el LLM pueda entender.

## Ejemplos

- [Calculadora en Java](../samples/java/calculator/README.md)
- [Calculadora en .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora en JavaScript](../samples/javascript/README.md)
- [Calculadora en TypeScript](../samples/typescript/README.md)
- [Calculadora en Python](../../../../03-GettingStarted/samples/python)

## Recursos adicionales

## ¿Qué sigue?

- Siguiente: [Consumir un servidor usando Visual Studio Code](../04-vscode/README.md)

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Si bien nos esforzamos por lograr precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o imprecisiones. El documento original en su idioma nativo debe considerarse como la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas que puedan surgir del uso de esta traducción.