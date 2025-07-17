<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T17:23:49+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "es"
}
-->
# Servidor SSE

SSE (Server Sent Events) es un estándar para la transmisión de datos del servidor al cliente, que permite a los servidores enviar actualizaciones en tiempo real a los clientes a través de HTTP. Esto es especialmente útil para aplicaciones que requieren actualizaciones en vivo, como aplicaciones de chat, notificaciones o flujos de datos en tiempo real. Además, tu servidor puede ser utilizado por múltiples clientes al mismo tiempo, ya que se ejecuta en un servidor que puede estar alojado, por ejemplo, en la nube.

## Resumen

Esta lección cubre cómo construir y consumir servidores SSE.

## Objetivos de aprendizaje

Al finalizar esta lección, serás capaz de:

- Construir un servidor SSE.
- Depurar un servidor SSE usando el Inspector.
- Consumir un servidor SSE usando Visual Studio Code.

## SSE, cómo funciona

SSE es uno de los dos tipos de transporte soportados. Ya has visto el primero, stdio, en lecciones anteriores. La diferencia es la siguiente:

- SSE requiere que manejes dos cosas: la conexión y los mensajes.
- Como este es un servidor que puede estar en cualquier lugar, necesitas que eso se refleje en cómo trabajas con herramientas como el Inspector y Visual Studio Code. Esto significa que, en lugar de indicar cómo iniciar el servidor, apuntas al endpoint donde se puede establecer la conexión. Mira el siguiente ejemplo de código:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

En el código anterior:

- `/sse` está configurado como una ruta. Cuando se hace una solicitud a esta ruta, se crea una nueva instancia de transporte y el servidor *se conecta* usando este transporte.
- `/messages` es la ruta que maneja los mensajes entrantes.

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

En el código anterior:

- Creamos una instancia de un servidor ASGI (usando específicamente Starlette) y montamos la ruta por defecto `/`.

  Lo que sucede detrás de escena es que las rutas `/sse` y `/messages` se configuran para manejar conexiones y mensajes respectivamente. El resto de la aplicación, como agregar funcionalidades o herramientas, funciona igual que con servidores stdio.

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    Hay dos métodos que nos ayudan a pasar de un servidor web a un servidor web que soporta SSE, y son:

    - `AddMcpServer`, este método añade capacidades.
    - `MapMcp`, este añade rutas como `/SSE` y `/messages`.
```

Now that we know a little bit more about SSE, let's build an SSE server next.

## Exercise: Creating an SSE Server

To create our server, we need to keep two things in mind:

- We need to use a web server to expose endpoints for connection and messages.
- Build our server like we normally do with tools, resources and prompts when we were using stdio.

### -1- Create a server instance

To create our server, we use the same types as with stdio. However, for the transport, we need to choose SSE.

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

In the preceding code we've:

- Created a server instance.
- Defined an app using the web framework express.
- Created a transports variable that we will use to store incoming connections.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

In the preceding code we've:

- Imported the libraries we're going to need with Starlette (an ASGI framework) being pulled in.
- Created an MCP server instance `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: agregar rutas 
```

At this point, we've:

- Created a web app
- Added support for MCP features through `AddMcpServer`.

Let's add the needed routes next.

### -2- Add routes

Let's add routes next that handle the connection and incoming messages:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No se encontró transporte para sessionId');
  }
});

app.listen(3001);
```

In the preceding code we've defined:

- An `/sse` route that instantiates a transport of type SSE and ends up calling `connect` on the MCP server.
- A `/messages` route that takes care of incoming messages.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

In the preceding code we've:

- Created an ASGI app instance using the Starlette framework. As part of that we passes `mcp.sse_app()` to it's list of routes. That ends up mounting an `/sse` and `/messages` route on the app instance.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

We've added one line of code at the end `add.MapMcp()` this means we now have routes `/SSE` and `/messages`. 

Let's add capabilties to the server next.

### -3- Adding server capabilities

Now that we've got everything SSE specific defined, let's add server capabilities like tools, prompts and resources.

### TypeScript

```typescript
server.tool("random-joke", "Un chiste devuelto por la API de Chuck Norris", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

Here's how you can add a tool for example. This specific tool creates a tool call "random-joke" that calls a Chuck Norris API and returns a JSON response.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Suma dos números"""
    return a + b
```

Now your server has one tool.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Crear un servidor MCP
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No se encontró transporte para sessionId");
  }
});

server.tool("random-joke", "Un chiste devuelto por la API de Chuck Norris", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Suma dos números"""
    return a + b

# Montar el servidor SSE en el servidor ASGI existente
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Let's create some tools first, for this we will create a file *Tools.cs* with the following content:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Suma dos números.")]
      public async Task<string> AddNumbers(
          [Description("El primer número")] int a,
          [Description("El segundo número")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Here we've added the following:

  - Created a class `Tools` with the decorator `McpServerToolType`.
  - Defined a tool `AddNumbers` by decorating the method with `McpServerTool`. We've also provided parameters and an implementation.

1. Let's leverage the `Tools` class we just created:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  We've added a call to `WithTools` that specifies `Tools` as the class containing the tools. That's it, we're ready.

Great, we have a server using SSE, let's take it for a spin next.

## Exercise: Debugging an SSE Server with Inspector

Inspector is a great tool that we saw in a previous lesson [Creating your first server](/03-GettingStarted/01-first-server/README.md). Let's see if we can use the Inspector even here:

### -1- Running the inspector

To run the inspector, you first must have an SSE server running, so let's do that next:

1. Run the server 

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Note how we use the executable `uvicorn` that's installed when we typed `pip install "mcp[cli]"`. Typing `server:app` means we're trying to run a file `server.py` and for it to have a Starlette instance called `app`. 

    ### .NET

    ```sh
    dotnet run
    ```

    This should start the server. To interface with it you need a new terminal.

1. Run the inspector

    > ![NOTE]
    > Run this in a separate terminal window than the server is running in. Also note, you need to adjust the below command to fit the URL where your server runs.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Ejecutar el inspector es igual en todos los entornos. Observa que en lugar de pasar una ruta a nuestro servidor y un comando para iniciarlo, pasamos la URL donde el servidor está corriendo y también especificamos la ruta `/sse`.

### -2- Probando la herramienta

Conéctate al servidor seleccionando SSE en la lista desplegable y completa el campo de URL donde tu servidor está corriendo, por ejemplo http:localhost:4321/sse. Ahora haz clic en el botón "Connect". Como antes, selecciona listar herramientas, elige una herramienta y proporciona los valores de entrada. Deberías ver un resultado como el siguiente:

![Servidor SSE corriendo en inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.es.png)

Genial, puedes trabajar con el inspector, ahora veamos cómo trabajar con Visual Studio Code.

## Tarea

Intenta ampliar tu servidor con más funcionalidades. Consulta [esta página](https://api.chucknorris.io/) para, por ejemplo, agregar una herramienta que llame a una API. Tú decides cómo debe ser el servidor. ¡Diviértete! :)

## Solución

[Solución](./solution/README.md) Aquí tienes una posible solución con código funcional.

## Puntos clave

Los puntos clave de este capítulo son los siguientes:

- SSE es el segundo transporte soportado junto a stdio.
- Para soportar SSE, necesitas gestionar conexiones entrantes y mensajes usando un framework web.
- Puedes usar tanto Inspector como Visual Studio Code para consumir un servidor SSE, igual que con servidores stdio. Nota que hay algunas diferencias entre stdio y SSE. Para SSE, necesitas iniciar el servidor por separado y luego ejecutar tu herramienta inspector. Para la herramienta inspector, también hay diferencias en que debes especificar la URL.

## Ejemplos

- [Calculadora Java](../samples/java/calculator/README.md)
- [Calculadora .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](../samples/javascript/README.md)
- [Calculadora TypeScript](../samples/typescript/README.md)
- [Calculadora Python](../../../../03-GettingStarted/samples/python)

## Recursos adicionales

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Qué sigue

- Siguiente: [HTTP Streaming con MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.