<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T00:39:32+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ne"
}
-->
# SSE सर्भर

SSE (Server Sent Events) सर्भर-देखि-क्लाइन्ट स्ट्रिमिङको लागि एक मानक हो, जसले सर्भरहरूलाई HTTP मार्फत क्लाइन्टहरूलाई वास्तविक-समय अपडेटहरू पठाउन अनुमति दिन्छ। यो विशेष गरी च्याट एप्लिकेसनहरू, सूचनाहरू, वा वास्तविक-समय डाटा फिडहरू जस्ता एप्लिकेसनहरूका लागि उपयोगी हुन्छ। साथै, तपाईंको सर्भरलाई एकै समयमा धेरै क्लाइन्टहरूले प्रयोग गर्न सक्छन् किनभने यो क्लाउडमा कहीं पनि चलाउन सकिने सर्भरमा बस्छ।

## अवलोकन

यस पाठले SSE सर्भर कसरी बनाउने र प्रयोग गर्ने बारेमा सिकाउँछ।

## सिकाइका उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- SSE सर्भर बनाउने।
- Inspector प्रयोग गरेर SSE सर्भर डिबग गर्ने।
- Visual Studio Code प्रयोग गरेर SSE सर्भर उपभोग गर्ने।

## SSE, यो कसरी काम गर्छ

SSE दुई समर्थित ट्रान्सपोर्ट प्रकारहरूमध्ये एक हो। तपाईंले पहिलेका पाठहरूमा stdio प्रयोग भएको देख्नुभएको छ। फरक कुरा यस्ता छन्:

- SSE मा तपाईंले दुई कुरा व्यवस्थापन गर्नुपर्छ; कनेक्शन र सन्देशहरू।
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

- `/sse` लाई एउटा रुटको रूपमा सेट गरिएको छ। जब यस रुटमा अनुरोध आउँछ, नयाँ ट्रान्सपोर्ट इन्स्ट्यान्स बनाइन्छ र सर्भरले यस ट्रान्सपोर्ट प्रयोग गरी *connect* गर्छ।
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

  पृष्ठभूमिमा `/sse` र `/messages` रुटहरू कनेक्शन र सन्देशहरू व्यवस्थापन गर्न सेटअप गरिएका छन्। बाँकी एप्लिकेसन, जस्तै stdio सर्भरहरूमा जस्तै उपकरणहरू थप्ने काम, त्यस्तै हुन्छ।

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

अब हामीले SSE बारे अलिकति बुझ्यौं, अब SSE सर्भर बनाऔं।

## अभ्यास: SSE सर्भर बनाउने

हाम्रो सर्भर बनाउनका लागि दुई कुरा ध्यानमा राख्नुपर्छ:

- कनेक्शन र सन्देशहरूको लागि अन्तिम बिन्दुहरू खोल्न वेब सर्भर प्रयोग गर्नुपर्छ।
- stdio प्रयोग गर्दा जस्तै उपकरणहरू, स्रोतहरू र प्रॉम्प्टहरू सहित सर्भर बनाउने।

### -1- सर्भर इन्स्ट्यान्स बनाउने

हामी stdio जस्तै प्रकारहरू प्रयोग गर्छौं, तर ट्रान्सपोर्टका लागि SSE रोज्नुपर्छ।

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

माथिको कोडमा हामीले:

- सर्भर इन्स्ट्यान्स बनाएका छौं।
- express वेब फ्रेमवर्क प्रयोग गरेर एप बनाएका छौं।
- आउने कनेक्शनहरू भण्डारण गर्न transports भेरिएबल बनाएका छौं।

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

माथिको कोडमा हामीले:

- आवश्यक लाइब्रेरीहरू आयात गरेका छौं, Starlette (ASGI फ्रेमवर्क) समावेश छ।
- MCP सर्भर इन्स्ट्यान्स `mcp` बनाएका छौं।

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

यस चरणमा हामीले:

- वेब एप बनाएका छौं।
- `AddMcpServer` मार्फत MCP सुविधाहरू थपेका छौं।

अब आवश्यक रुटहरू थपौं।

### -2- रुटहरू थप्ने

अब कनेक्शन र आउने सन्देशहरू व्यवस्थापन गर्ने रुटहरू थपौं:

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

माथिको कोडमा हामीले:

- `/sse` रुट बनाएका छौं जसले SSE प्रकारको ट्रान्सपोर्ट इन्स्ट्यान्स बनाउँछ र MCP सर्भरमा `connect` कल गर्छ।
- `/messages` रुटले आउने सन्देशहरू सम्हाल्छ।

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

माथिको कोडमा हामीले:

- Starlette फ्रेमवर्क प्रयोग गरेर ASGI एप इन्स्ट्यान्स बनाएका छौं। यसमा `mcp.sse_app()` लाई रुटहरूको सूचीमा पास गरेका छौं। यसले `/sse` र `/messages` रुटहरू एपमा माउन्ट गर्छ।

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

अन्त्यमा `add.MapMcp()` कोड लाइन थपेका छौं, जसले `/SSE` र `/messages` रुटहरू उपलब्ध गराउँछ।

अब सर्भरमा क्षमता थपौं।

### -3- सर्भर क्षमताहरू थप्ने

अब SSE सम्बन्धित सबै कुरा परिभाषित भइसकेपछि, उपकरणहरू, प्रॉम्प्टहरू र स्रोतहरू जस्ता सर्भर क्षमताहरू थपौं।

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

यहाँ कसरी उपकरण थप्ने देखाइएको छ। यो उपकरणले "random-joke" नामक उपकरण बनाउँछ जुन Chuck Norris API कल गरेर JSON प्रतिक्रिया फर्काउँछ।

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

अब तपाईंको सर्भरमा एउटा उपकरण छ।

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

1. पहिले केही उपकरणहरू बनाऔं, यसको लागि *Tools.cs* नामक फाइल बनाउनेछौं जसमा निम्न सामग्री हुनेछ:

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

  यहाँ हामीले:

  - `Tools` नामक क्लास बनाएका छौं जसमा `McpServerToolType` डेकोरेटर छ।
  - `AddNumbers` नामक उपकरण परिभाषित गरेका छौं जसमा `McpServerTool` डेकोरेटर प्रयोग गरिएको छ। साथै, पेरामिटरहरू र कार्यान्वयन पनि दिएका छौं।

1. अब हामीले बनाएको `Tools` क्लास प्रयोग गरौं:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  हामीले `WithTools` कल थपेका छौं जसले `Tools` क्लासलाई उपकरणहरू भएको क्लासको रूपमा निर्दिष्ट गर्छ। बस, तयार छौं।

शानदार, हामीसँग SSE प्रयोग गर्ने सर्भर छ, अब यसलाई चलाएर हेरौं।

## अभ्यास: Inspector प्रयोग गरेर SSE सर्भर डिबग गर्ने

Inspector एउटा उत्कृष्ट उपकरण हो जुन हामीले पहिलेको पाठ [Creating your first server](/03-GettingStarted/01-first-server/README.md) मा देखेका थियौं। अब हेर्नुहोस् कि यहाँ पनि Inspector प्रयोग गर्न सकिन्छ कि सकिँदैन:

### -1- Inspector चलाउने

Inspector चलाउन पहिले SSE सर्भर चलिरहेको हुनुपर्छ, त्यसैले अब त्यो गरौं:

1. सर्भर चलाउनुहोस्

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    ध्यान दिनुहोस् हामीले `uvicorn` प्रयोग गरेका छौं जुन `pip install "mcp[cli]"` गर्दा इन्स्टल हुन्छ। `server:app` लेख्दा हामी `server.py` फाइल चलाउन खोजिरहेका छौं र त्यसमा `app` नामक Starlette इन्स्ट्यान्स छ।

    ### .NET

    ```sh
    dotnet run
    ```

    यसले सर्भर सुरु गर्नेछ। यससँग अन्तरक्रिया गर्न नयाँ टर्मिनल चाहिन्छ।

1. Inspector चलाउनुहोस्

    > ![NOTE]
    > यो सर्भर चलिरहेको टर्मिनल भन्दा अलग टर्मिनल विन्डोमा चलाउनुहोस्। साथै, तलको कमाण्डलाई तपाईंको सर्भर चलिरहेको URL अनुसार समायोजन गर्न आवश्यक छ।

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspector चलाउने तरिका सबै रनटाइमहरूमा उस्तै छ। ध्यान दिनुहोस् हामीले सर्भरको पथ र सुरु गर्ने कमाण्डको सट्टा सर्भर चलिरहेको URL र `/sse` रुट दिन्छौं।

### -2- उपकरण प्रयोग गरेर प्रयास गर्ने

SSE चयन गरी सर्भर चलिरहेको URL जस्तै http:localhost:4321/sse भर्नुहोस्। अब "Connect" बटन थिच्नुहोस्। पहिले जस्तै, उपकरणहरूको सूची देखाउनुहोस्, एउटा उपकरण छान्नुहोस् र इनपुट मानहरू दिनुहोस्। तपाईंले तलको जस्तो परिणाम देख्नुहुनेछ:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ne.png)

शानदार, तपाईं Inspector सँग काम गर्न सक्षम हुनुहुन्छ, अब Visual Studio Code सँग कसरी काम गर्ने हेरौं।

## असाइनमेन्ट

आफ्नो सर्भरलाई थप क्षमताहरू सहित बनाउने प्रयास गर्नुहोस्। उदाहरणका लागि, [यो पृष्ठ](https://api.chucknorris.io/) हेर्नुहोस् र API कल गर्ने उपकरण थप्नुहोस्। सर्भर कस्तो देखिनुपर्छ तपाईंले निर्णय गर्नुहोस्। रमाइलो गर्नुहोस् :)

## समाधान

[Solution](./solution/README.md) यहाँ काम गर्ने कोड सहित सम्भावित समाधान छ।

## मुख्य बुँदाहरू

यस अध्यायका मुख्य बुँदाहरू यस्ता छन्:

- SSE stdio पछि दोस्रो समर्थित ट्रान्सपोर्ट हो।
- SSE समर्थन गर्न, तपाईंले वेब फ्रेमवर्क प्रयोग गरी आउने कनेक्शन र सन्देशहरू व्यवस्थापन गर्नुपर्छ।
- Inspector र Visual Studio Code दुवै SSE सर्भर उपभोग गर्न प्रयोग गर्न सकिन्छ, stdio सर्भरहरू जस्तै। stdio र SSE बीच केही फरक छ। SSE मा सर्भर अलगबाट सुरु गर्नुपर्छ र त्यसपछि Inspector चलाउनुपर्छ। Inspector मा URL निर्दिष्ट गर्नुपर्ने फरक पनि छ।

## नमूनाहरू

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## थप स्रोतहरू

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## के छ अर्को

- अर्को: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।