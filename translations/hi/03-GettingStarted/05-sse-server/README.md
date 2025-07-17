<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T18:06:22+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hi"
}
-->
# SSE सर्वर

SSE (Server Sent Events) एक मानक है जो सर्वर से क्लाइंट तक स्ट्रीमिंग के लिए होता है, जिससे सर्वर HTTP के माध्यम से क्लाइंट्स को रियल-टाइम अपडेट्स भेज सकते हैं। यह उन एप्लिकेशन्स के लिए खास तौर पर उपयोगी है जिन्हें लाइव अपडेट्स की जरूरत होती है, जैसे चैट एप्लिकेशन, नोटिफिकेशन, या रियल-टाइम डेटा फीड। साथ ही, आपका सर्वर एक साथ कई क्लाइंट्स द्वारा इस्तेमाल किया जा सकता है क्योंकि यह किसी सर्वर पर चलता है, जो उदाहरण के लिए क्लाउड में कहीं भी हो सकता है।

## अवलोकन

यह पाठ SSE सर्वर बनाने और उपयोग करने के बारे में है।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- एक SSE सर्वर बनाना।
- Inspector का उपयोग करके SSE सर्वर को डिबग करना।
- Visual Studio Code का उपयोग करके SSE सर्वर को उपयोग करना।

## SSE, यह कैसे काम करता है

SSE दो समर्थित ट्रांसपोर्ट प्रकारों में से एक है। आपने पहले के पाठों में stdio का उपयोग होते देखा है। अंतर निम्नलिखित है:

- SSE में आपको दो चीज़ों को संभालना होता है; कनेक्शन और संदेश।
- चूंकि यह एक सर्वर है जो कहीं भी हो सकता है, इसलिए आपको Inspector और Visual Studio Code जैसे टूल्स के साथ काम करते समय इसे ध्यान में रखना होगा। इसका मतलब है कि आप सर्वर शुरू करने के बजाय उस endpoint को इंगित करते हैं जहां कनेक्शन स्थापित किया जा सकता है। नीचे उदाहरण कोड देखें:

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

उपरोक्त कोड में:

- `/sse` को एक रूट के रूप में सेट किया गया है। जब इस रूट की ओर अनुरोध किया जाता है, तो एक नया ट्रांसपोर्ट इंस्टेंस बनता है और सर्वर इस ट्रांसपोर्ट का उपयोग करके *कनेक्ट* होता है।
- `/messages`, यह रूट आने वाले संदेशों को संभालता है।

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

उपरोक्त कोड में हमने:

- एक ASGI सर्वर का इंस्टेंस बनाया (विशेष रूप से Starlette का उपयोग करते हुए) और डिफ़ॉल्ट रूट `/` को माउंट किया।

  पर्दे के पीछे यह होता है कि `/sse` और `/messages` रूट्स कनेक्शन और संदेशों को संभालने के लिए सेटअप किए जाते हैं। बाकी ऐप, जैसे टूल्स जोड़ना, stdio सर्वरों की तरह होता है।

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

    दो मेथड्स हैं जो हमें एक वेब सर्वर से SSE सपोर्टिंग वेब सर्वर में बदलने में मदद करते हैं:

    - `AddMcpServer`, यह मेथड क्षमताएं जोड़ता है।
    - `MapMcp`, यह `/SSE` और `/messages` जैसे रूट्स जोड़ता है।
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

// एक MCP सर्वर बनाएं
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
    """दो नंबर जोड़ें"""
    return a + b

# मौजूदा ASGI सर्वर पर SSE सर्वर माउंट करें
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

      [McpServerTool, Description("दो नंबरों को जोड़ें।")]
      public async Task<string> AddNumbers(
          [Description("पहला नंबर")] int a,
          [Description("दूसरा नंबर")] int b)
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

    Inspector को चलाना सभी रनटाइम्स में एक जैसा दिखता है। ध्यान दें कि हम सर्वर को शुरू करने के लिए पाथ और कमांड देने के बजाय, उस URL को देते हैं जहां सर्वर चल रहा है और साथ ही `/sse` रूट को भी निर्दिष्ट करते हैं।

### -2- टूल आज़माना

ड्रॉपलिस्ट में SSE चुनकर सर्वर से कनेक्ट करें और उस URL को भरें जहां आपका सर्वर चल रहा है, उदाहरण के लिए http:localhost:4321/sse। अब "Connect" बटन पर क्लिक करें। पहले की तरह, टूल्स की सूची चुनें, एक टूल चुनें और इनपुट मान प्रदान करें। आपको नीचे जैसा परिणाम दिखना चाहिए:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hi.png)

बहुत बढ़िया, आप Inspector के साथ काम कर पा रहे हैं, अब देखते हैं कि Visual Studio Code के साथ कैसे काम किया जा सकता है।

## असाइनमेंट

अपने सर्वर को और अधिक क्षमताओं के साथ बनाकर देखें। उदाहरण के लिए, [इस पेज](https://api.chucknorris.io/) को देखें और एक ऐसा टूल जोड़ें जो किसी API को कॉल करता हो। तय करें कि सर्वर कैसा दिखना चाहिए। मज़े करें :)

## समाधान

[समाधान](./solution/README.md) यहाँ एक संभव समाधान है जिसमें काम करने वाला कोड है।

## मुख्य बातें

इस अध्याय से मुख्य बातें निम्नलिखित हैं:

- SSE stdio के बाद दूसरा समर्थित ट्रांसपोर्ट है।
- SSE को सपोर्ट करने के लिए, आपको वेब फ्रेमवर्क का उपयोग करके आने वाले कनेक्शन्स और संदेशों को प्रबंधित करना होगा।
- आप Inspector और Visual Studio Code दोनों का उपयोग SSE सर्वर को उपयोग करने के लिए कर सकते हैं, ठीक वैसे ही जैसे stdio सर्वरों के लिए। ध्यान दें कि stdio और SSE में थोड़ा अंतर है। SSE के लिए, आपको सर्वर को अलग से शुरू करना होता है और फिर Inspector टूल चलाना होता है। Inspector टूल के लिए, URL निर्दिष्ट करना भी आवश्यक होता है।

## नमूने

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधन

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## आगे क्या है

- अगला: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।