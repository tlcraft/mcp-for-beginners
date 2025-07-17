<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T18:17:24+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ne"
}
-->
# SSE सर्भर

SSE (सर्भर सेंट इभेन्ट्स) सर्भर-देखि-क्लाइन्ट स्ट्रिमिङको लागि एक मानक हो, जसले सर्भरहरूलाई HTTP मार्फत क्लाइन्टहरूलाई रियल-टाइम अपडेटहरू पठाउन अनुमति दिन्छ। यो विशेष गरी च्याट एप्लिकेसनहरू, सूचनाहरू, वा रियल-टाइम डाटा फिडहरू जस्ता एप्लिकेसनहरूका लागि उपयोगी हुन्छ। साथै, तपाईंको सर्भरलाई एकै समयमा धेरै क्लाइन्टहरूले प्रयोग गर्न सक्छन् किनभने यो क्लाउडमा कहीं पनि चलाउन सकिने सर्भरमा बस्छ।

## अवलोकन

यस पाठले SSE सर्भर कसरी बनाउने र प्रयोग गर्ने सिकाउँछ।

## सिकाइका उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- SSE सर्भर बनाउने।
- Inspector प्रयोग गरेर SSE सर्भर डिबग गर्ने।
- Visual Studio Code प्रयोग गरेर SSE सर्भर उपभोग गर्ने।

## SSE, यो कसरी काम गर्छ

SSE दुई समर्थित ट्रान्सपोर्ट प्रकारहरूमध्ये एक हो। तपाईंले पहिलेका पाठहरूमा stdio प्रयोग भएको देख्नुभएको छ। फरक कुरा यस्ता छन्:

- SSE ले तपाईंलाई दुई कुरा व्यवस्थापन गर्न आवश्यक छ; कनेक्शन र सन्देशहरू।
- यो सर्भर जुनसुकै ठाउँमा बस्न सक्छ, त्यसैले तपाईंले Inspector र Visual Studio Code जस्ता उपकरणहरूसँग काम गर्दा त्यसलाई प्रतिबिम्बित गर्नुपर्छ। यसको अर्थ तपाईंले सर्भर कसरी सुरु गर्ने भनेर नभई, सर्भरले कनेक्शन स्थापना गर्न सक्ने अन्तिम बिन्दु (endpoint) देखाउनु पर्छ। तलको उदाहरण कोड हेर्नुहोस्:

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

माथिको कोडमा:

- `/sse` लाई एउटा रुटको रूपमा सेट गरिएको छ। जब यस रुटमा अनुरोध आउँछ, नयाँ ट्रान्सपोर्ट इन्स्ट्यान्स बनाइन्छ र सर्भरले यस ट्रान्सपोर्टमार्फत *कनेक्ट* हुन्छ।
- `/messages`, यो रुटले आउने सन्देशहरूलाई व्यवस्थापन गर्छ।

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

माथिको कोडमा हामीले:

- ASGI सर्भरको इन्स्ट्यान्स बनाएका छौं (विशेष गरी Starlette प्रयोग गरेर) र डिफल्ट रुट `/` मा माउन्ट गरेका छौं।

  पृष्ठभूमिमा `/sse` र `/messages` रुटहरू कनेक्शन र सन्देशहरू व्यवस्थापन गर्न सेटअप गरिएका छन्। बाँकी एप्लिकेसन, जस्तै stdio सर्भरहरूमा जस्तै उपकरणहरू थप्ने कार्यहरू, त्यस्तै हुन्छ।

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

    वेब सर्भरबाट SSE समर्थन गर्ने वेब सर्भरमा जान दुई विधिहरू छन्:

    - `AddMcpServer`, यसले क्षमता थप्छ।
    - `MapMcp`, यसले `/SSE` र `/messages` जस्ता रुटहरू थप्छ।
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

// TODO: add routes 
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
    res.status(400).send('No transport found for sessionId');
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

Here's how you can add a tool for example. This specific tool creates a tool call "random-joke" that calls a Chuck Norris API and returns a JSON response.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
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

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
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

    Inspector चलाउने तरिका सबै रनटाइमहरूमा उस्तै हुन्छ। ध्यान दिनुहोस् कि हामीले सर्भर सुरु गर्ने कमाण्ड र पथको सट्टा सर्भर चलिरहेको URL र `/sse` रुट निर्दिष्ट गरेका छौं।

### -2- उपकरण प्रयोग गर्दै हेर्ने

SSE चयन गरेर सर्भरमा जडान गर्नुहोस् र URL फिल्डमा तपाईंको सर्भर चलिरहेको ठेगाना भर्नुहोस्, जस्तै http:localhost:4321/sse। अब "Connect" बटन थिच्नुहोस्। पहिलेझैं, उपकरणहरूको सूची देखाउनुहोस्, एउटा उपकरण चयन गर्नुहोस् र इनपुट मानहरू दिनुहोस्। तपाईंले तलको जस्तो परिणाम देख्नुहुनेछ:

![Inspector मा चलिरहेको SSE सर्भर](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ne.png)

शानदार, तपाईं Inspector सँग काम गर्न सक्षम हुनुहुन्छ, अब हेरौं Visual Studio Code सँग कसरी काम गर्ने।

## असाइनमेन्ट

आफ्नो सर्भरलाई थप क्षमताहरू सहित बनाउने प्रयास गर्नुहोस्। उदाहरणका लागि, [यो पृष्ठ](https://api.chucknorris.io/) हेर्नुहोस् र एउटा उपकरण थप्नुहोस् जसले API कल गर्छ। सर्भर कस्तो देखिनुपर्छ तपाईंले निर्णय गर्नुहोस्। रमाइलो गर्नुहोस् :)

## समाधान

[Solution](./solution/README.md) यहाँ काम गर्ने कोड सहित सम्भावित समाधान छ।

## मुख्य बुँदाहरू

यस अध्यायका मुख्य बुँदाहरू यस्ता छन्:

- SSE stdio पछि दोस्रो समर्थित ट्रान्सपोर्ट हो।
- SSE समर्थन गर्न, तपाईंले वेब फ्रेमवर्क प्रयोग गरेर आउने कनेक्शन र सन्देशहरू व्यवस्थापन गर्नुपर्छ।
- Inspector र Visual Studio Code दुवै SSE सर्भर उपभोग गर्न प्रयोग गर्न सकिन्छ, stdio सर्भरहरू जस्तै। ध्यान दिनुहोस् कि stdio र SSE बीच केही फरक छ। SSE को लागि, तपाईंले सर्भर अलग्गै सुरु गर्नुपर्छ र त्यसपछि Inspector उपकरण चलाउनुपर्छ। Inspector उपकरणमा URL निर्दिष्ट गर्नुपर्ने फरक पनि छ।

## नमूनाहरू

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## थप स्रोतहरू

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## के छ अर्को

- अर्को: [MCP सँग HTTP स्ट्रिमिङ (Streamable HTTP)](../06-http-streaming/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं भने पनि, कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।