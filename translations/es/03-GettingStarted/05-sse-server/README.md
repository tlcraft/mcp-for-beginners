<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T22:09:08+00:00",
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

- `/sse` está configurado como una ruta. Cuando se hace una solicitud a esta ruta, se crea una nueva instancia de transporte y el servidor se *conecta* usando este transporte.
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

  Lo que sucede detrás de escena es que las rutas `/sse` y `/messages` se configuran para manejar conexiones y mensajes respectivamente. El resto de la aplicación, como agregar características como herramientas, funciona igual que con servidores stdio.

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

    Hay dos métodos que nos ayudan a pasar de un servidor web a un servidor web que soporta SSE y son:

    - `AddMcpServer`, este método añade capacidades.
    - `MapMcp`, este añade rutas como `/SSE` y `/messages`.

Ahora que sabemos un poco más sobre SSE, construyamos un servidor SSE.

## Ejercicio: Creando un servidor SSE

Para crear nuestro servidor, debemos tener en cuenta dos cosas:

- Necesitamos usar un servidor web para exponer endpoints para la conexión y los mensajes.
- Construir nuestro servidor como normalmente lo hacemos con herramientas, recursos y prompts cuando usábamos stdio.

### -1- Crear una instancia del servidor

Para crear nuestro servidor, usamos los mismos tipos que con stdio. Sin embargo, para el transporte, debemos elegir SSE.

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

En el código anterior hemos:

- Creado una instancia del servidor.
- Definido una app usando el framework web express.
- Creado una variable transports que usaremos para almacenar las conexiones entrantes.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

En el código anterior hemos:

- Importado las librerías que necesitaremos, incluyendo Starlette (un framework ASGI).
- Creado una instancia del servidor MCP llamada `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

En este punto, hemos:

- Creado una aplicación web.
- Añadido soporte para las características MCP mediante `AddMcpServer`.

Ahora agreguemos las rutas necesarias.

### -2- Añadir rutas

Agreguemos las rutas que manejan la conexión y los mensajes entrantes:

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

app.listen(3001);
```

En el código anterior hemos definido:

- Una ruta `/sse` que instancia un transporte de tipo SSE y termina llamando a `connect` en el servidor MCP.
- Una ruta `/messages` que se encarga de los mensajes entrantes.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

En el código anterior hemos:

- Creado una instancia de la app ASGI usando el framework Starlette. Como parte de esto, pasamos `mcp.sse_app()` a su lista de rutas. Esto monta las rutas `/sse` y `/messages` en la instancia de la app.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

Hemos añadido una línea de código al final `add.MapMcp()`, esto significa que ahora tenemos las rutas `/SSE` y `/messages`.

Ahora agreguemos capacidades al servidor.

### -3- Añadiendo capacidades al servidor

Ahora que tenemos todo lo específico de SSE definido, añadamos capacidades al servidor como herramientas, prompts y recursos.

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
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

Aquí puedes ver cómo añadir una herramienta, por ejemplo. Esta herramienta específica crea una llamada "random-joke" que consulta una API de Chuck Norris y devuelve una respuesta JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

Ahora tu servidor tiene una herramienta.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
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
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
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
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. Primero, creemos algunas herramientas, para esto crearemos un archivo *Tools.cs* con el siguiente contenido:

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

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  Aquí hemos añadido lo siguiente:

  - Creado una clase `Tools` con el decorador `McpServerToolType`.
  - Definido una herramienta `AddNumbers` decorando el método con `McpServerTool`. También proporcionamos parámetros e implementación.

1. Ahora usemos la clase `Tools` que acabamos de crear:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  Hemos añadido una llamada a `WithTools` que especifica `Tools` como la clase que contiene las herramientas. Eso es todo, estamos listos.

Genial, tenemos un servidor usando SSE, probémoslo a continuación.

## Ejercicio: Depurando un servidor SSE con Inspector

Inspector es una gran herramienta que vimos en una lección anterior [Creando tu primer servidor](/03-GettingStarted/01-first-server/README.md). Veamos si podemos usar el Inspector aquí también:

### -1- Ejecutando el inspector

Para ejecutar el inspector, primero debes tener un servidor SSE corriendo, así que hagámoslo:

1. Ejecuta el servidor

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    Observa que usamos el ejecutable `uvicorn` que se instala cuando escribimos `pip install "mcp[cli]"`. Escribir `server:app` significa que intentamos ejecutar un archivo `server.py` que tenga una instancia Starlette llamada `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    Esto debería iniciar el servidor. Para interactuar con él necesitas una nueva terminal.

1. Ejecuta el inspector

    > ![NOTE]
    > Ejecuta esto en una ventana de terminal separada de donde está corriendo el servidor. También ten en cuenta que debes ajustar el comando a continuación para que coincida con la URL donde corre tu servidor.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Ejecutar el inspector es igual en todos los entornos. Observa que en lugar de pasar una ruta a nuestro servidor y un comando para iniciarlo, pasamos la URL donde el servidor está corriendo y también especificamos la ruta `/sse`.

### -2- Probando la herramienta

Conecta el servidor seleccionando SSE en la lista desplegable y completa el campo de URL donde corre tu servidor, por ejemplo http:localhost:4321/sse. Ahora haz clic en el botón "Connect". Como antes, selecciona listar herramientas, elige una herramienta y proporciona valores de entrada. Deberías ver un resultado como el siguiente:

![Servidor SSE corriendo en inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.es.png)

Genial, puedes trabajar con el inspector, veamos ahora cómo trabajar con Visual Studio Code.

## Tarea

Intenta ampliar tu servidor con más capacidades. Consulta [esta página](https://api.chucknorris.io/) para, por ejemplo, añadir una herramienta que llame a una API. Tú decides cómo debe ser el servidor. ¡Diviértete! :)

## Solución

[Solución](./solution/README.md) Aquí tienes una posible solución con código funcional.

## Puntos clave

Los puntos clave de este capítulo son los siguientes:

- SSE es el segundo transporte soportado junto a stdio.
- Para soportar SSE, necesitas gestionar conexiones y mensajes entrantes usando un framework web.
- Puedes usar tanto Inspector como Visual Studio Code para consumir un servidor SSE, igual que con servidores stdio. Nota que hay algunas diferencias entre stdio y SSE. Para SSE, necesitas iniciar el servidor por separado y luego ejecutar la herramienta inspector. Para el inspector, también hay diferencias en que debes especificar la URL.

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