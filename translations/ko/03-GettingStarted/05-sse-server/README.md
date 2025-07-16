<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-16T21:50:18+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ko"
}
-->
# SSE 서버

SSE(Server Sent Events)는 서버에서 클라이언트로 실시간 스트리밍을 제공하는 표준으로, 서버가 HTTP를 통해 클라이언트에게 실시간 업데이트를 푸시할 수 있게 해줍니다. 이는 채팅 애플리케이션, 알림, 실시간 데이터 피드와 같이 라이브 업데이트가 필요한 애플리케이션에 특히 유용합니다. 또한, 서버는 클라우드 등 어디서든 실행될 수 있는 서버에 존재하기 때문에 여러 클라이언트가 동시에 사용할 수 있습니다.

## 개요

이 수업에서는 SSE 서버를 구축하고 사용하는 방법을 다룹니다.

## 학습 목표

이 수업이 끝나면 다음을 할 수 있습니다:

- SSE 서버를 구축할 수 있습니다.
- Inspector를 사용해 SSE 서버를 디버깅할 수 있습니다.
- Visual Studio Code를 사용해 SSE 서버를 사용할 수 있습니다.

## SSE, 작동 방식

SSE는 지원되는 두 가지 전송 방식 중 하나입니다. 이전 수업에서 stdio가 사용되는 것을 이미 보셨을 겁니다. 차이점은 다음과 같습니다:

- SSE는 연결과 메시지 두 가지를 처리해야 합니다.
- 이 서버는 어디서든 실행될 수 있기 때문에 Inspector나 Visual Studio Code 같은 도구를 사용할 때도 그 점을 반영해야 합니다. 즉, 서버를 시작하는 방법을 지정하는 대신 연결을 설정할 수 있는 엔드포인트를 지정해야 합니다. 아래 예제 코드를 참고하세요:

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

- `/sse`는 라우트로 설정되어 있습니다. 이 경로로 요청이 들어오면 새로운 전송 인스턴스가 생성되고 서버는 이 전송을 사용해 *연결*합니다.
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

  내부적으로 `/sse`와 `/messages` 라우트가 각각 연결과 메시지를 처리하도록 설정됩니다. 나머지 앱 기능, 예를 들어 도구 추가 등은 stdio 서버와 동일하게 진행됩니다.

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

    웹 서버에서 SSE를 지원하는 웹 서버로 전환하는 데 도움이 되는 두 가지 메서드가 있습니다:

    - `AddMcpServer`: 기능을 추가합니다.
    - `MapMcp`: `/SSE`와 `/messages` 같은 라우트를 추가합니다.

이제 SSE에 대해 조금 더 알았으니, SSE 서버를 만들어 봅시다.

## 연습: SSE 서버 만들기

서버를 만들 때 두 가지를 기억해야 합니다:

- 연결과 메시지를 위한 엔드포인트를 노출하는 웹 서버를 사용해야 합니다.
- stdio를 사용할 때처럼 도구, 리소스, 프롬프트를 사용해 서버를 구축합니다.

### -1- 서버 인스턴스 생성

서버를 만들 때 stdio와 같은 타입을 사용하지만, 전송 방식은 SSE를 선택해야 합니다.

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

위 코드에서는:

- 서버 인스턴스를 생성했습니다.
- 웹 프레임워크 express를 사용해 앱을 정의했습니다.
- 들어오는 연결을 저장할 transports 변수를 만들었습니다.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

위 코드에서는:

- 필요한 라이브러리를 가져왔고, Starlette(ASGI 프레임워크)를 포함했습니다.
- MCP 서버 인스턴스 `mcp`를 생성했습니다.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

이 시점에서:

- 웹 앱을 생성했습니다.
- `AddMcpServer`를 통해 MCP 기능을 추가했습니다.

다음으로 필요한 라우트를 추가해 봅시다.

### -2- 라우트 추가

연결과 들어오는 메시지를 처리하는 라우트를 추가합니다:

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

위 코드에서는:

- `/sse` 라우트를 정의해 SSE 타입의 전송을 생성하고 MCP 서버에서 `connect`를 호출합니다.
- `/messages` 라우트는 들어오는 메시지를 처리합니다.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

위 코드에서는:

- Starlette 프레임워크를 사용해 ASGI 앱 인스턴스를 생성했습니다. 이때 `mcp.sse_app()`을 라우트 목록에 전달해 `/sse`와 `/messages` 라우트를 앱 인스턴스에 마운트했습니다.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

마지막에 `add.MapMcp()` 한 줄을 추가해 `/SSE`와 `/messages` 라우트를 생성했습니다.

다음으로 서버 기능을 추가해 봅시다.

### -3- 서버 기능 추가

SSE 관련 설정이 모두 끝났으니, 도구, 프롬프트, 리소스 같은 서버 기능을 추가합니다.

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

예를 들어 도구를 추가하는 방법입니다. 이 도구는 "random-joke"라는 도구를 생성하며 Chuck Norris API를 호출해 JSON 응답을 반환합니다.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

이제 서버에 도구가 하나 추가되었습니다.

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

1. 먼저 도구를 만들어 봅시다. *Tools.cs* 파일을 다음 내용으로 생성합니다:

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

  여기서는 다음을 추가했습니다:

  - `McpServerToolType` 데코레이터가 붙은 `Tools` 클래스를 생성했습니다.
  - `McpServerTool` 데코레이터로 메서드 `AddNumbers`를 도구로 정의하고, 매개변수와 구현을 제공했습니다.

1. 방금 만든 `Tools` 클래스를 활용해 봅시다:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  `WithTools` 호출에 `Tools` 클래스를 지정했습니다. 이제 준비가 완료되었습니다.

좋습니다, SSE를 사용하는 서버가 완성되었습니다. 다음으로 직접 실행해 봅시다.

## 연습: Inspector로 SSE 서버 디버깅하기

Inspector는 이전 수업 [처음 서버 만들기](/03-GettingStarted/01-first-server/README.md)에서 본 훌륭한 도구입니다. 여기서도 Inspector를 사용할 수 있는지 확인해 봅시다:

### -1- Inspector 실행하기

Inspector를 실행하려면 먼저 SSE 서버가 실행 중이어야 합니다. 다음과 같이 서버를 실행해 봅시다:

1. 서버 실행

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    `pip install "mcp[cli]"` 명령어로 설치된 실행 파일 `uvicorn`을 사용하는 점에 주목하세요. `server:app`은 `server.py` 파일을 실행하며, 그 안에 Starlette 인스턴스 `app`이 있어야 함을 의미합니다.

    ### .NET

    ```sh
    dotnet run
    ```

    이 명령어로 서버가 시작됩니다. 서버와 상호작용하려면 새 터미널이 필요합니다.

1. Inspector 실행

    > ![NOTE]
    > 서버가 실행 중인 터미널과는 별도의 터미널 창에서 실행하세요. 또한 아래 명령어는 서버가 실행 중인 URL에 맞게 조정해야 합니다.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Inspector 실행 방법은 모든 런타임에서 동일합니다. 서버 경로와 시작 명령어를 넘기는 대신, 서버가 실행 중인 URL과 `/sse` 라우트를 지정하는 점에 주목하세요.

### -2- 도구 사용해 보기

드롭다운에서 SSE를 선택하고, 서버가 실행 중인 URL(예: http:localhost:4321/sse)을 입력한 후 "Connect" 버튼을 클릭하세요. 이전과 같이 도구 목록을 불러오고, 도구를 선택한 뒤 입력값을 제공하면 아래와 같은 결과를 볼 수 있습니다:

![Inspector에서 실행 중인 SSE 서버](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ko.png)

잘 하셨습니다! Inspector를 사용할 수 있으니, 다음으로 Visual Studio Code에서 작업하는 방법을 알아봅시다.

## 과제

서버에 더 많은 기능을 추가해 보세요. 예를 들어 [이 페이지](https://api.chucknorris.io/)를 참고해 API를 호출하는 도구를 추가할 수 있습니다. 서버가 어떻게 생겼으면 좋을지 직접 결정하세요. 즐겁게 작업하세요 :)

## 해답

[해답](./solution/README.md) 작동하는 코드가 포함된 가능한 해답입니다.

## 주요 내용 정리

이번 장의 주요 내용은 다음과 같습니다:

- SSE는 stdio 다음으로 지원되는 두 번째 전송 방식입니다.
- SSE를 지원하려면 웹 프레임워크를 사용해 들어오는 연결과 메시지를 관리해야 합니다.
- Inspector와 Visual Studio Code 모두 stdio 서버처럼 SSE 서버를 사용할 수 있습니다. 다만 stdio와 SSE 간에 약간 차이가 있습니다. SSE는 서버를 별도로 시작한 후 Inspector 도구를 실행해야 하며, Inspector 도구에서는 URL을 지정해야 한다는 점이 다릅니다.

## 샘플

- [Java 계산기](../samples/java/calculator/README.md)
- [.Net 계산기](../../../../03-GettingStarted/samples/csharp)
- [JavaScript 계산기](../samples/javascript/README.md)
- [TypeScript 계산기](../samples/typescript/README.md)
- [Python 계산기](../../../../03-GettingStarted/samples/python)

## 추가 자료

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## 다음 단계

- 다음: [MCP를 이용한 HTTP 스트리밍 (Streamable HTTP)](../06-http-streaming/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 노력하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역의 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.