<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a8831b194cb5ece750355e99434b7154",
  "translation_date": "2025-07-17T18:02:27+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ko"
}
-->
# SSE 서버

SSE(Server Sent Events)는 서버에서 클라이언트로 실시간 스트리밍을 제공하는 표준으로, 서버가 HTTP를 통해 클라이언트에게 실시간 업데이트를 푸시할 수 있게 해줍니다. 이는 채팅 애플리케이션, 알림, 실시간 데이터 피드와 같이 라이브 업데이트가 필요한 애플리케이션에 특히 유용합니다. 또한, 서버는 클라우드 등 어디서든 실행될 수 있는 서버에 존재하기 때문에 여러 클라이언트가 동시에 사용할 수 있습니다.

## 개요

이 강의에서는 SSE 서버를 구축하고 사용하는 방법을 다룹니다.

## 학습 목표

이 강의를 마치면 다음을 할 수 있습니다:

- SSE 서버를 구축할 수 있습니다.
- Inspector를 사용해 SSE 서버를 디버깅할 수 있습니다.
- Visual Studio Code를 사용해 SSE 서버를 사용할 수 있습니다.

## SSE, 작동 방식

SSE는 지원되는 두 가지 전송 방식 중 하나입니다. 이전 강의에서 stdio가 사용되는 것을 이미 보셨을 겁니다. 차이점은 다음과 같습니다:

- SSE는 연결과 메시지 두 가지를 처리해야 합니다.
- 이 서버는 어디서든 실행될 수 있기 때문에 Inspector나 Visual Studio Code 같은 도구를 사용할 때도 이를 반영해야 합니다. 즉, 서버를 시작하는 방법을 지정하는 대신 연결을 설정할 수 있는 엔드포인트를 지정해야 합니다. 아래 예제 코드를 참고하세요.

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

위 코드에서:

- `/sse`는 라우트로 설정되어 있습니다. 이 경로로 요청이 들어오면 새로운 전송 인스턴스가 생성되고 서버는 이 전송을 통해 *연결*합니다.
- `/messages`는 들어오는 메시지를 처리하는 라우트입니다.

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

위 코드에서는:

- ASGI 서버 인스턴스(특히 Starlette 사용)를 생성하고 기본 라우트 `/`에 마운트합니다.

  내부적으로 `/sse`와 `/messages` 라우트가 각각 연결과 메시지를 처리하도록 설정됩니다. 나머지 앱 기능 추가는 stdio 서버와 동일하게 진행됩니다.

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

    웹 서버를 SSE를 지원하는 웹 서버로 전환하는 데 도움이 되는 두 가지 메서드가 있습니다:

    - `AddMcpServer`: 기능을 추가합니다.
    - `MapMcp`: `/SSE`와 `/messages` 같은 라우트를 추가합니다.
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
    """두 숫자를 더합니다"""
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

// MCP 서버 생성
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
    res.status(400).send("sessionId에 해당하는 transport를 찾을 수 없습니다");
  }
});

server.tool("random-joke", "Chuck Norris API에서 가져온 농담", {}, async () => {
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
    """두 숫자를 더합니다"""
    return a + b

# 기존 ASGI 서버에 SSE 서버 마운트
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

      [McpServerTool, Description("두 숫자를 더합니다.")]
      public async Task<string> AddNumbers(
          [Description("첫 번째 숫자")] int a,
          [Description("두 번째 숫자")] int b)
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

    Inspector 실행은 모든 런타임에서 동일하게 보입니다. 서버 경로나 시작 명령어를 전달하는 대신 서버가 실행 중인 URL과 `/sse` 경로를 지정하는 점에 주목하세요.

### -2- 도구 사용해보기

드롭리스트에서 SSE를 선택하고 서버가 실행 중인 URL(예: http://localhost:4321/sse)을 입력한 후 "Connect" 버튼을 클릭하세요. 이전과 같이 도구 목록을 불러오고, 도구를 선택한 뒤 입력값을 제공하면 아래와 같은 결과를 볼 수 있습니다:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ko.png)

잘 하셨습니다! Inspector를 사용할 수 있게 되었으니, 이제 Visual Studio Code와 함께 작업하는 방법을 살펴보겠습니다.

## 과제

서버에 더 많은 기능을 추가해 보세요. 예를 들어 [이 페이지](https://api.chucknorris.io/)를 참고해 API를 호출하는 도구를 추가할 수 있습니다. 서버가 어떻게 동작할지 직접 결정해 보세요. 즐겁게 도전하세요 :)

## 해답

[해답](./solution/README.md) 작동하는 코드가 포함된 가능한 해답입니다.

## 주요 내용 정리

이번 장에서 꼭 기억해야 할 내용은 다음과 같습니다:

- SSE는 stdio 다음으로 지원되는 두 번째 전송 방식입니다.
- SSE를 지원하려면 웹 프레임워크를 사용해 들어오는 연결과 메시지를 관리해야 합니다.
- Inspector와 Visual Studio Code 모두 stdio 서버처럼 SSE 서버를 사용할 수 있습니다. 다만 stdio와 SSE는 약간 다릅니다. SSE는 서버를 별도로 시작한 후 Inspector 도구를 실행해야 하며, Inspector 도구에서는 URL을 지정해야 한다는 점이 다릅니다.

## 샘플

- [Java 계산기](../samples/java/calculator/README.md)
- [.Net 계산기](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 계산기](../samples/javascript/README.md)
- [TypeScript 계산기](../samples/typescript/README.md)
- [Python 계산기](../../../../03-GettingStarted/samples/python) 

## 추가 자료

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 다음은

- 다음: [MCP를 이용한 HTTP 스트리밍 (Streamable HTTP)](../06-http-streaming/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 내용이 포함될 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역의 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.