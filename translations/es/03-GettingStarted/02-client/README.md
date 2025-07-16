<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-16T22:07:50+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "es"
}
-->
# Creando un cliente

Los clientes son aplicaciones personalizadas o scripts que se comunican directamente con un servidor MCP para solicitar recursos, herramientas y prompts. A diferencia de usar la herramienta inspector, que ofrece una interfaz gráfica para interactuar con el servidor, escribir tu propio cliente permite interacciones programáticas y automatizadas. Esto permite a los desarrolladores integrar las capacidades de MCP en sus propios flujos de trabajo, automatizar tareas y construir soluciones personalizadas adaptadas a necesidades específicas.

## Resumen

Esta lección introduce el concepto de clientes dentro del ecosistema del Protocolo de Contexto de Modelo (MCP). Aprenderás cómo escribir tu propio cliente y conectarlo a un servidor MCP.

## Objetivos de aprendizaje

Al finalizar esta lección, serás capaz de:

- Entender qué puede hacer un cliente.
- Escribir tu propio cliente.
- Conectar y probar el cliente con un servidor MCP para asegurarte de que funciona como se espera.

## ¿Qué implica escribir un cliente?

Para escribir un cliente, necesitarás hacer lo siguiente:

- **Importar las librerías correctas**. Usarás la misma librería que antes, solo que con diferentes construcciones.
- **Instanciar un cliente**. Esto implicará crear una instancia de cliente y conectarla al método de transporte elegido.
- **Decidir qué recursos listar**. Tu servidor MCP viene con recursos, herramientas y prompts; debes decidir cuáles listar.
- **Integrar el cliente en una aplicación anfitriona**. Una vez que conozcas las capacidades del servidor, necesitas integrar esto en tu aplicación anfitriona para que si un usuario escribe un prompt u otro comando, se invoque la función correspondiente del servidor.

Ahora que entendemos a grandes rasgos lo que vamos a hacer, veamos un ejemplo a continuación.

### Un cliente de ejemplo

Veamos este cliente de ejemplo:

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

En el código anterior:

- Importamos las librerías.
- Creamos una instancia de cliente y la conectamos usando stdio como transporte.
- Listamos prompts, recursos y herramientas y los invocamos todos.

Ahí lo tienes, un cliente que puede comunicarse con un servidor MCP.

Tomémonos nuestro tiempo en la siguiente sección de ejercicios para desglosar cada fragmento de código y explicar qué está pasando.

## Ejercicio: Escribiendo un cliente

Como se dijo antes, tomémonos nuestro tiempo explicando el código, y por supuesto, si quieres, programa junto con el ejemplo.

### -1- Importar las librerías

Importemos las librerías que necesitamos, necesitaremos referencias a un cliente y a nuestro protocolo de transporte elegido, stdio. stdio es un protocolo para cosas que se ejecutan en tu máquina local. SSE es otro protocolo de transporte que mostraremos en capítulos futuros, pero esa es tu otra opción. Por ahora, continuemos con stdio.

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

Para Java, crearás un cliente que se conecte al servidor MCP del ejercicio anterior. Usando la misma estructura del proyecto Java Spring Boot de [Primeros pasos con MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), crea una nueva clase Java llamada `SDKClient` en la carpeta `src/main/java/com/microsoft/mcp/sample/client/` y añade las siguientes importaciones:

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

Pasemos a la instanciación.

### -2- Instanciando cliente y transporte

Necesitaremos crear una instancia del transporte y otra de nuestro cliente:

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

En el código anterior hemos:

- Creado una instancia de transporte stdio. Observa cómo se especifican el comando y los argumentos para encontrar y arrancar el servidor, ya que eso es algo que necesitaremos hacer al crear el cliente.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- Instanciado un cliente dándole un nombre y versión.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- Conectado el cliente al transporte elegido.

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

En el código anterior hemos:

- Importado las librerías necesarias.
- Instanciado un objeto de parámetros del servidor que usaremos para ejecutar el servidor y así poder conectarnos con nuestro cliente.
- Definido un método `run` que a su vez llama a `stdio_client` que inicia una sesión de cliente.
- Creado un punto de entrada donde proporcionamos el método `run` a `asyncio.run`.

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

En el código anterior hemos:

- Importado las librerías necesarias.
- Creado un transporte stdio y un cliente `mcpClient`. Este último es lo que usaremos para listar e invocar funciones en el servidor MCP.

Nota, en "Arguments", puedes apuntar ya sea al *.csproj* o al ejecutable.

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

En el código anterior hemos:

- Creado un método main que configura un transporte SSE apuntando a `http://localhost:8080` donde estará corriendo nuestro servidor MCP.
- Creado una clase cliente que recibe el transporte como parámetro en el constructor.
- En el método `run`, creamos un cliente MCP síncrono usando el transporte e inicializamos la conexión.
- Usado el transporte SSE (Server-Sent Events) que es adecuado para comunicación HTTP con servidores MCP Java Spring Boot.

### -3- Listando las funciones del servidor

Ahora tenemos un cliente que puede conectarse si se ejecuta el programa. Sin embargo, no lista sus funciones, así que hagámoslo a continuación:

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

Aquí listamos los recursos disponibles, `list_resources()` y las herramientas, `list_tools` y los imprimimos.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

Arriba hay un ejemplo de cómo podemos listar las herramientas en el servidor. Para cada herramienta, imprimimos su nombre.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

En el código anterior hemos:

- Llamado a `listTools()` para obtener todas las herramientas disponibles del servidor MCP.
- Usado `ping()` para verificar que la conexión con el servidor funciona.
- `ListToolsResult` contiene información sobre todas las herramientas, incluyendo sus nombres, descripciones y esquemas de entrada.

Genial, ahora hemos capturado todas las funciones. Ahora la pregunta es, ¿cuándo las usamos? Bueno, este cliente es bastante simple, simple en el sentido de que necesitaremos llamar explícitamente a las funciones cuando las queramos. En el próximo capítulo, crearemos un cliente más avanzado que tenga acceso a su propio modelo de lenguaje grande, LLM. Por ahora, veamos cómo podemos invocar las funciones en el servidor:

### -4- Invocar funciones

Para invocar las funciones necesitamos asegurarnos de especificar los argumentos correctos y en algunos casos el nombre de lo que intentamos invocar.

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

En el código anterior:

- Leemos un recurso, llamamos al recurso usando `readResource()` especificando `uri`. Esto es lo que probablemente se ve en el servidor:

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

    Nuestro valor `uri` `file://example.txt` coincide con `file://{name}` en el servidor. `example.txt` se mapeará a `name`.

- Llamamos a una herramienta, la llamamos especificando su `name` y sus `arguments` así:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- Obtenemos un prompt, para obtener un prompt, llamas a `getPrompt()` con `name` y `arguments`. El código del servidor es así:

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

    y tu código cliente resultante se ve así para coincidir con lo declarado en el servidor:

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

En el código anterior hemos:

- Llamado a un recurso llamado `greeting` usando `read_resource`.
- Invocado una herramienta llamada `add` usando `call_tool`.

### C#

1. Añadamos algo de código para llamar a una herramienta:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. Para imprimir el resultado, aquí hay código para manejar eso:

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

En el código anterior hemos:

- Llamado a múltiples herramientas calculadoras usando el método `callTool()` con objetos `CallToolRequest`.
- Cada llamada a herramienta especifica el nombre de la herramienta y un `Map` de argumentos requeridos por esa herramienta.
- Las herramientas del servidor esperan nombres de parámetros específicos (como "a", "b" para operaciones matemáticas).
- Los resultados se devuelven como objetos `CallToolResult` que contienen la respuesta del servidor.

### -5- Ejecutar el cliente

Para ejecutar el cliente, escribe el siguiente comando en la terminal:

### TypeScript

Agrega la siguiente entrada a la sección "scripts" en *package.json*:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

Llama al cliente con el siguiente comando:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

Primero, asegúrate de que tu servidor MCP esté corriendo en `http://localhost:8080`. Luego ejecuta el cliente:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

Alternativamente, puedes ejecutar el proyecto cliente completo que se encuentra en la carpeta de solución `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Tarea

En esta tarea, usarás lo que has aprendido para crear un cliente, pero crea un cliente propio.

Aquí tienes un servidor que puedes usar y al que necesitas llamar desde tu código cliente, intenta agregar más funciones al servidor para hacerlo más interesante.

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

Consulta este proyecto para ver cómo puedes [agregar prompts y recursos](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

También revisa este enlace para saber cómo invocar [prompts y recursos](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## Solución

[Solución](./solution/README.md)

## Puntos clave

Los puntos clave de este capítulo sobre clientes son los siguientes:

- Pueden usarse tanto para descubrir como para invocar funciones en el servidor.
- Pueden iniciar un servidor mientras se inician ellos mismos (como en este capítulo), pero los clientes también pueden conectarse a servidores ya en ejecución.
- Son una excelente manera de probar las capacidades del servidor junto a alternativas como el Inspector, como se describió en el capítulo anterior.

## Recursos adicionales

- [Construyendo clientes en MCP](https://modelcontextprotocol.io/quickstart/client)

## Ejemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Qué sigue

- Siguiente: [Creando un cliente con un LLM](../03-llm-client/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.