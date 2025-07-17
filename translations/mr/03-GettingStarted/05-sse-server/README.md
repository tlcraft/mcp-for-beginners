<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T18:14:26+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "mr"
}
-->
# SSE सर्व्हर

SSE (Server Sent Events) हा सर्व्हर-टू-क्लायंट स्ट्रीमिंगसाठी एक मानक आहे, ज्यामुळे सर्व्हर HTTP वरून क्लायंटला रिअल-टाइम अपडेट्स पाठवू शकतो. हे विशेषतः अशा अॅप्लिकेशन्ससाठी उपयुक्त आहे ज्यांना थेट अपडेट्सची गरज असते, जसे की चॅट अॅप्लिकेशन्स, नोटिफिकेशन्स किंवा रिअल-टाइम डेटा फीड्स. शिवाय, तुमचा सर्व्हर एकाच वेळी अनेक क्लायंट्सद्वारे वापरला जाऊ शकतो कारण तो क्लाउडमध्ये कुठेतरी चालू असू शकतो.

## आढावा

हा धडा SSE सर्व्हर कसे तयार करायचे आणि वापरायचे हे शिकवतो.

## शिकण्याचे उद्दिष्ट

या धड्याच्या शेवटी, तुम्ही खालील गोष्टी करू शकाल:

- SSE सर्व्हर तयार करणे.
- Inspector वापरून SSE सर्व्हर डिबग करणे.
- Visual Studio Code वापरून SSE सर्व्हर वापरणे.

## SSE, ते कसे कार्य करते

SSE हा दोन समर्थित ट्रान्सपोर्ट प्रकारांपैकी एक आहे. तुम्ही आधीच्या धड्यांमध्ये stdio वापरलेले पाहिले आहे. फरक असा आहे:

- SSE मध्ये तुम्हाला दोन गोष्टी हाताळाव्या लागतात; कनेक्शन आणि मेसेजेस.
- हा सर्व्हर कुठेही चालू होऊ शकतो, त्यामुळे Inspector आणि Visual Studio Code सारख्या टूल्ससह काम करताना तुम्हाला त्याचा विचार करावा लागतो. म्हणजेच, सर्व्हर सुरू करण्याचा मार्ग सांगण्याऐवजी, तुम्ही कनेक्शन स्थापन होऊ शकणाऱ्या endpoint कडे निर्देश करता. खाली उदाहरण कोड पहा:

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

वरील कोडमध्ये:

- `/sse` हा रूट सेट केला आहे. जेव्हा या रूटकडे विनंती येते, तेव्हा नवीन ट्रान्सपोर्ट इंस्टन्स तयार होतो आणि सर्व्हर या ट्रान्सपोर्टद्वारे *कनेक्ट* होतो.
- `/messages` हा रूट येणाऱ्या मेसेजेस हाताळतो.

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

वरील कोडमध्ये आपण:

- ASGI सर्व्हरचा एक इंस्टन्स तयार करतो (विशेषतः Starlette वापरून) आणि डिफॉल्ट रूट `/` माउंट करतो.

  मागच्या प्रक्रियेत `/sse` आणि `/messages` रूट्स कनेक्शन्स आणि मेसेजेस हाताळण्यासाठी सेट केले जातात. बाकी अॅप, जसे की टूल्स जोडणे, stdio सर्व्हरप्रमाणेच होते.

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

    वेब सर्व्हरपासून SSE सपोर्ट करणाऱ्या वेब सर्व्हरमध्ये जाण्यासाठी दोन पद्धती आहेत:

    - `AddMcpServer`, ही पद्धत क्षमता वाढवते.
    - `MapMcp`, ही `/SSE` आणि `/messages` सारखे रूट्स जोडते.
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

// MCP सर्व्हर तयार करा
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

# विद्यमान ASGI सर्व्हरवर SSE सर्व्हर माउंट करा
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

    Inspector सर्व्हर चालू असलेल्या URL आणि `/sse` रूटसह कसे वापरायचे हे सर्व रनटाइममध्ये सारखेच आहे. लक्षात घ्या की सर्व्हर सुरू करण्यासाठी कमांड देण्याऐवजी, आपण सर्व्हर चालू असलेला URL आणि `/sse` रूट देतो.

### -2- टूल वापरून पाहणे

SSE निवडून सर्व्हरशी कनेक्ट व्हा आणि URL फील्डमध्ये तुमचा सर्व्हर चालू असलेला URL भरा, उदा. http:localhost:4321/sse. नंतर "Connect" बटणावर क्लिक करा. त्यानंतर, टूल्सची यादी करा, टूल निवडा आणि इनपुट मूल्ये द्या. तुम्हाला खालीलप्रमाणे निकाल दिसेल:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.mr.png)

छान, तुम्ही Inspector वापरू शकता, आता पाहूया Visual Studio Code कसे वापरायचे.

## असाइनमेंट

तुमचा सर्व्हर अधिक क्षमतांसह तयार करण्याचा प्रयत्न करा. उदाहरणार्थ, API कॉल करणारा टूल जोडण्यासाठी [ही पेज](https://api.chucknorris.io/) पहा. तुम्ही ठरवा की सर्व्हर कसा दिसायला हवा. मजा करा :)

## सोल्यूशन

[Solution](./solution/README.md) येथे एक शक्य सोल्यूशन आहे ज्यात काम करणारा कोड आहे.

## मुख्य मुद्दे

या प्रकरणातील मुख्य मुद्दे खालीलप्रमाणे आहेत:

- SSE हा stdio नंतरचा दुसरा समर्थित ट्रान्सपोर्ट आहे.
- SSE सपोर्ट करण्यासाठी, तुम्हाला येणाऱ्या कनेक्शन्स आणि मेसेजेस वेब फ्रेमवर्क वापरून हाताळावे लागतात.
- तुम्ही Inspector आणि Visual Studio Code दोन्ही वापरून SSE सर्व्हर वापरू शकता, stdio सर्व्हरप्रमाणेच. लक्षात ठेवा की stdio आणि SSE मध्ये थोडा फरक आहे. SSE साठी, तुम्हाला सर्व्हर स्वतंत्रपणे सुरू करावा लागतो आणि नंतर Inspector टूल चालवावे लागते. Inspector टूलसाठी URL देखील निर्दिष्ट करावा लागतो.

## नमुने

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## अतिरिक्त संसाधने

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## पुढे काय

- पुढे: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.