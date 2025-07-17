<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T00:27:36+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "mr"
}
-->
# SSE सर्व्हर

SSE (Server Sent Events) हा सर्व्हर-टू-क्लायंट स्ट्रीमिंगसाठीचा एक मानक आहे, जो सर्व्हर्सना HTTP वरून क्लायंट्सना रिअल-टाइम अपडेट्स पाठवण्याची परवानगी देतो. हे विशेषतः अशा अॅप्लिकेशन्ससाठी उपयुक्त आहे ज्यांना थेट अपडेट्सची गरज असते, जसे की चॅट अॅप्लिकेशन्स, नोटिफिकेशन्स किंवा रिअल-टाइम डेटा फीड्स. शिवाय, तुमचा सर्व्हर एकाच वेळी अनेक क्लायंट्सद्वारे वापरला जाऊ शकतो कारण तो क्लाउडमध्ये कुठेतरी चालणाऱ्या सर्व्हरवर राहू शकतो.

## आढावा

हा धडा SSE सर्व्हर कसे तयार करायचे आणि वापरायचे हे शिकवतो.

## शिकण्याचे उद्दिष्टे

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- SSE सर्व्हर तयार करणे.
- Inspector वापरून SSE सर्व्हर डिबग करणे.
- Visual Studio Code वापरून SSE सर्व्हर वापरणे.

## SSE, ते कसे कार्य करते

SSE हा दोन समर्थित ट्रान्सपोर्ट प्रकारांपैकी एक आहे. तुम्ही आधीच्या धड्यांमध्ये stdio वापरलेले पाहिले आहे. फरक असा आहे:

- SSE मध्ये तुम्हाला दोन गोष्टी हाताळाव्या लागतात; कनेक्शन आणि मेसेजेस.
- हा सर्व्हर कुठेही राहू शकतो, त्यामुळे Inspector आणि Visual Studio Code सारख्या टूल्ससह काम करताना तुम्हाला ते प्रतिबिंबित करावे लागेल. याचा अर्थ असा की सर्व्हर कसा सुरू करायचा हे सांगण्याऐवजी, तुम्ही कनेक्शन स्थापन होऊ शकणाऱ्या endpoint कडे निर्देश कराल. खाली उदाहरण कोड पहा:

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

- `/sse` हा रूट सेट केला आहे. जेव्हा या रूटकडे विनंती केली जाते, तेव्हा नवीन ट्रान्सपोर्ट इंस्टन्स तयार होतो आणि सर्व्हर या ट्रान्सपोर्टचा वापर करून *connect* करतो.
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

वरील कोडमध्ये:

- ASGI सर्व्हरचा एक इंस्टन्स तयार केला आहे (विशेषतः Starlette वापरून) आणि डिफॉल्ट रूट `/` माउंट केला आहे.

  मागच्या प्रक्रियेत `/sse` आणि `/messages` रूट्स कनेक्शन्स आणि मेसेजेससाठी सेटअप केले जातात. बाकी अॅप, जसे की टूल्स जोडणे, stdio सर्व्हर्ससारखेच होते.

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

    वेब सर्व्हरपासून SSE सपोर्ट करणाऱ्या वेब सर्व्हरकडे जाण्यासाठी दोन पद्धती आहेत:

    - `AddMcpServer`, ही पद्धत क्षमता वाढवते.
    - `MapMcp`, ही `/SSE` आणि `/messages` सारखे रूट्स जोडते.

आता जेव्हा आपण SSE बद्दल थोडे अधिक जाणून घेतले आहे, तर पुढे SSE सर्व्हर तयार करूया.

## सराव: SSE सर्व्हर तयार करणे

आपला सर्व्हर तयार करताना दोन गोष्टी लक्षात ठेवाव्या लागतील:

- कनेक्शन आणि मेसेजेससाठी एन्डपॉइंट्स उघडण्यासाठी वेब सर्व्हर वापरावा लागेल.
- stdio वापरताना जसे टूल्स, रिसोर्सेस आणि प्रॉम्प्ट्स वापरून सर्व्हर तयार केला तसा तयार करावा.

### -1- सर्व्हर इंस्टन्स तयार करा

सर्व्हर तयार करण्यासाठी stdio प्रमाणेच टाइप्स वापरू, पण ट्रान्सपोर्टसाठी SSE निवडावे लागेल.

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

वरील कोडमध्ये:

- सर्व्हर इंस्टन्स तयार केला आहे.
- express वेब फ्रेमवर्क वापरून अॅप डिफाइन केले आहे.
- येणाऱ्या कनेक्शन्स साठवण्यासाठी transports नावाचा व्हेरिएबल तयार केला आहे.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

वरील कोडमध्ये:

- आवश्यक लायब्ररी इम्पोर्ट केल्या आहेत, ज्यात Starlette (ASGI फ्रेमवर्क) समाविष्ट आहे.
- MCP सर्व्हरचा `mcp` नावाचा इंस्टन्स तयार केला आहे.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

या टप्प्यावर:

- वेब अॅप तयार केला आहे.
- `AddMcpServer` वापरून MCP फीचर्ससाठी सपोर्ट जोडला आहे.

आता आवश्यक रूट्स जोडूया.

### -2- रूट्स जोडा

कनेक्शन आणि येणाऱ्या मेसेजेससाठी रूट्स जोडूया:

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

वरील कोडमध्ये:

- `/sse` रूट डिफाइन केला आहे जो SSE प्रकाराचा ट्रान्सपोर्ट इंस्टन्स तयार करतो आणि MCP सर्व्हरवर `connect` कॉल करतो.
- `/messages` रूट येणाऱ्या मेसेजेसची काळजी घेतो.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

वरील कोडमध्ये:

- Starlette फ्रेमवर्क वापरून ASGI अॅप इंस्टन्स तयार केला आहे. त्यात `mcp.sse_app()` रूट्सच्या यादीत दिला आहे. त्यामुळे `/sse` आणि `/messages` रूट्स अॅपवर माउंट होतात.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

शेवटी `add.MapMcp()` हा एक ओळ कोड जोडला आहे, ज्यामुळे आता `/SSE` आणि `/messages` रूट्स उपलब्ध आहेत.

आता सर्व्हरमध्ये क्षमता (capabilities) जोडूया.

### -3- सर्व्हर क्षमता जोडणे

आता जेव्हा SSE संबंधित सर्व काही डिफाइन केले आहे, तेव्हा टूल्स, प्रॉम्प्ट्स आणि रिसोर्सेस सारख्या सर्व्हर क्षमताही जोडूया.

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

उदाहरणार्थ, टूल कसे जोडायचे ते येथे दाखवले आहे. हा टूल "random-joke" नावाचा टूल तयार करतो जो Chuck Norris API कॉल करतो आणि JSON प्रतिसाद परत करतो.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

आता तुमच्या सर्व्हरमध्ये एक टूल आहे.

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

1. प्रथम काही टूल्स तयार करूया, यासाठी *Tools.cs* नावाचा फाइल तयार करा ज्यात खालील सामग्री असेल:

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

  येथे आपण पुढील गोष्टी केल्या आहेत:

  - `Tools` नावाची क्लास तयार केली आहे ज्यावर `McpServerToolType` डेकोरेटर आहे.
  - `AddNumbers` नावाचा टूल तयार केला आहे ज्यावर `McpServerTool` डेकोरेटर आहे. त्याला पॅरामीटर्स आणि अंमलबजावणी दिली आहे.

1. आता आपण नुकतीच तयार केलेली `Tools` क्लास वापरूया:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  `WithTools` कॉल जोडला आहे ज्यात `Tools` क्लास टूल्ससाठी दिला आहे. एवढेच, आपण तयार आहोत.

छान, आपल्याकडे SSE वापरून सर्व्हर आहे, आता त्याचा वापर करून पाहूया.

## सराव: Inspector वापरून SSE सर्व्हर डिबग करणे

Inspector हा एक छान टूल आहे ज्याला आपण मागील धड्यात पाहिले होते [Creating your first server](/03-GettingStarted/01-first-server/README.md). चला पाहूया की आपण Inspector इथेही वापरू शकतो का:

### -1- Inspector चालवणे

Inspector चालवण्यासाठी प्रथम SSE सर्व्हर चालू असणे आवश्यक आहे, तर ते करूया:

1. सर्व्हर चालवा

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    लक्षात घ्या की आपण `uvicorn` executable वापरतो जे `pip install "mcp[cli]"` टाइप केल्यावर इन्स्टॉल होते. `server:app` टाइप केल्याने `server.py` फाइल चालवण्याचा प्रयत्न होतो ज्यात `app` नावाचा Starlette इंस्टन्स असतो.

    ### .NET

    ```sh
    dotnet run
    ```

    यामुळे सर्व्हर सुरू होईल. त्याच्याशी संवाद साधण्यासाठी नवीन टर्मिनल आवश्यक आहे.

1. Inspector चालवा

    > ![NOTE]
    > हा कमांड त्या टर्मिनलमध्ये चालवा जिथे सर्व्हर चालू नाही. तसेच, खालील कमांड तुमच्या सर्व्हरच्या URL नुसार बदलावी लागेल.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspector सर्व रनटाइममध्ये सारखा दिसतो. लक्षात घ्या की आपण सर्व्हरचा पाथ देण्याऐवजी सर्व्हर चालू असलेल्या URL आणि `/sse` रूट देतो.

### -2- टूल वापरून पाहणे

ड्रॉपलिस्टमधून SSE निवडा आणि URL फील्डमध्ये तुमचा सर्व्हर चालू असलेला URL भरा, उदा. http:localhost:4321/sse. नंतर "Connect" बटणावर क्लिक करा. नंतर टूल्सची यादी पाहा, टूल निवडा आणि इनपुट मूल्ये द्या. तुम्हाला खालीलप्रमाणे निकाल दिसेल:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.mr.png)

छान, तुम्ही Inspector वापरू शकता, आता पाहूया Visual Studio Code कसे वापरायचे.

## असाइनमेंट

तुमचा सर्व्हर अधिक क्षमतांसह तयार करण्याचा प्रयत्न करा. उदाहरणार्थ, [ही पेज](https://api.chucknorris.io/) पाहा आणि API कॉल करणारा टूल जोडा. सर्व्हर कसा दिसावा हे तुम्ही ठरवा. मजा करा :)

## सोल्यूशन

[Solution](./solution/README.md) येथे एक शक्य सोल्यूशन आहे ज्यात काम करणारा कोड आहे.

## मुख्य मुद्दे

या प्रकरणातील मुख्य मुद्दे:

- SSE हा stdio नंतरचा दुसरा समर्थित ट्रान्सपोर्ट आहे.
- SSE सपोर्ट करण्यासाठी, तुम्हाला येणाऱ्या कनेक्शन्स आणि मेसेजेस वेब फ्रेमवर्क वापरून हाताळावे लागतात.
- Inspector आणि Visual Studio Code दोन्ही SSE सर्व्हर वापरण्यासाठी वापरू शकता, stdio सर्व्हर्ससारखेच. लक्षात ठेवा की stdio आणि SSE मध्ये थोडा फरक आहे. SSE साठी, तुम्हाला सर्व्हर स्वतंत्रपणे सुरू करावा लागतो आणि नंतर Inspector टूल चालवावे लागते. Inspector टूलसाठी URL देखील निर्दिष्ट करावा लागतो.

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
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.