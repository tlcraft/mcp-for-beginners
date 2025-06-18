<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:47:49+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ko"
}
-->
# HTTPS 스트리밍과 Model Context Protocol (MCP)

이 장에서는 HTTPS를 이용해 Model Context Protocol (MCP) 기반의 안전하고 확장 가능하며 실시간 스트리밍을 구현하는 방법을 자세히 안내합니다. 스트리밍의 동기, 사용 가능한 전송 메커니즘, MCP에서 스트리밍 HTTP 구현 방법, 보안 모범 사례, SSE에서의 마이그레이션, 그리고 직접 스트리밍 MCP 애플리케이션을 구축하는 실용적인 가이드를 다룹니다.

## MCP의 전송 메커니즘과 스트리밍

이 절에서는 MCP에서 사용 가능한 다양한 전송 메커니즘과 이들이 클라이언트와 서버 간 실시간 통신을 위한 스트리밍 기능을 어떻게 지원하는지 살펴봅니다.

### 전송 메커니즘이란?

전송 메커니즘은 클라이언트와 서버 간 데이터가 어떻게 교환되는지를 정의합니다. MCP는 다양한 환경과 요구에 맞게 여러 전송 유형을 지원합니다:

- **stdio**: 표준 입력/출력, 로컬 및 CLI 기반 도구에 적합합니다. 간단하지만 웹이나 클라우드 환경에는 적합하지 않습니다.
- **SSE (Server-Sent Events)**: 서버가 HTTP를 통해 클라이언트에 실시간 업데이트를 푸시할 수 있습니다. 웹 UI에 적합하지만 확장성과 유연성에 제한이 있습니다.
- **Streamable HTTP**: 알림과 더 나은 확장성을 지원하는 최신 HTTP 기반 스트리밍 전송 방식입니다. 대부분의 프로덕션 및 클라우드 시나리오에 권장됩니다.

### 비교 표

아래 비교 표를 통해 각 전송 메커니즘의 차이를 확인해보세요:

| 전송 방식         | 실시간 업데이트 | 스트리밍 | 확장성    | 사용 사례                |
|-------------------|----------------|----------|----------|-------------------------|
| stdio             | 아니요          | 아니요   | 낮음     | 로컬 CLI 도구           |
| SSE               | 예             | 예       | 중간     | 웹, 실시간 업데이트     |
| Streamable HTTP   | 예             | 예       | 높음     | 클라우드, 다중 클라이언트 |

> **팁:** 적절한 전송 방식을 선택하는 것은 성능, 확장성, 사용자 경험에 큰 영향을 미칩니다. **Streamable HTTP**는 현대적이고 확장 가능하며 클라우드에 적합한 애플리케이션에 권장됩니다.

이전 장에서 소개한 stdio와 SSE 전송 방식과 이번 장에서 다루는 streamable HTTP 전송 방식을 참고하세요.

## 스트리밍: 개념과 동기

효과적인 실시간 통신 시스템을 구현하기 위해서는 스트리밍의 기본 개념과 동기를 이해하는 것이 중요합니다.

**스트리밍**은 네트워크 프로그래밍에서 데이터를 한 번에 모두 받기보다 작은 단위나 이벤트 시퀀스로 나누어 송수신하는 기술입니다. 이는 특히 다음과 같은 경우에 유용합니다:

- 대용량 파일이나 데이터셋
- 실시간 업데이트(예: 채팅, 진행 바)
- 장시간 실행되는 계산 과정에서 사용자에게 지속적으로 정보를 제공할 때

스트리밍의 주요 특징은 다음과 같습니다:

- 데이터가 점진적으로 전달되며 한꺼번에 전송되지 않습니다.
- 클라이언트는 도착하는 데이터를 즉시 처리할 수 있습니다.
- 지연 시간을 줄이고 사용자 경험을 개선합니다.

### 왜 스트리밍을 사용할까?

스트리밍을 사용하는 이유는 다음과 같습니다:

- 사용자가 작업 완료 시점이 아니라 즉시 피드백을 받음
- 실시간 애플리케이션과 반응형 UI 구현 가능
- 네트워크 및 컴퓨팅 자원을 효율적으로 활용

### 간단한 예: HTTP 스트리밍 서버와 클라이언트

다음은 스트리밍을 구현하는 간단한 예시입니다:

<details>
<summary>Python</summary>

**서버 (Python, FastAPI와 StreamingResponse 사용):**
<details>
<summary>Python</summary>

```python
from fastapi import FastAPI
from fastapi.responses import StreamingResponse
import time

app = FastAPI()

async def event_stream():
    for i in range(1, 6):
        yield f"data: Message {i}\n\n"
        time.sleep(1)

@app.get("/stream")
def stream():
    return StreamingResponse(event_stream(), media_type="text/event-stream")
```

</details>

**클라이언트 (Python, requests 사용):**
<details>
<summary>Python</summary>

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

</details>

이 예시는 서버가 모든 메시지가 준비될 때까지 기다리지 않고, 메시지가 준비되는 대로 클라이언트에 순차적으로 전송하는 방식을 보여줍니다.

**동작 원리:**
- 서버는 메시지가 준비될 때마다 이를 순차적으로 반환합니다.
- 클라이언트는 도착하는 각 청크를 받아 출력합니다.

**필수 조건:**
- 서버는 스트리밍 응답(예: `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`)을 사용해야 합니다.

</details>

<details>
<summary>Java</summary>

**서버 (Java, Spring Boot와 Server-Sent Events 사용):**

```java
@RestController
public class CalculatorController {

    @GetMapping(value = "/calculate", produces = MediaType.TEXT_EVENT_STREAM_VALUE)
    public Flux<ServerSentEvent<String>> calculate(@RequestParam double a,
                                                   @RequestParam double b,
                                                   @RequestParam String op) {
        
        double result;
        switch (op) {
            case "add": result = a + b; break;
            case "sub": result = a - b; break;
            case "mul": result = a * b; break;
            case "div": result = b != 0 ? a / b : Double.NaN; break;
            default: result = Double.NaN;
        }

        return Flux.<ServerSentEvent<String>>just(
                    ServerSentEvent.<String>builder()
                        .event("info")
                        .data("Calculating: " + a + " " + op + " " + b)
                        .build(),
                    ServerSentEvent.<String>builder()
                        .event("result")
                        .data(String.valueOf(result))
                        .build()
                )
                .delayElements(Duration.ofSeconds(1));
    }
}
```

**클라이언트 (Java, Spring WebFlux WebClient 사용):**

```java
@SpringBootApplication
public class CalculatorClientApplication implements CommandLineRunner {

    private final WebClient client = WebClient.builder()
            .baseUrl("http://localhost:8080")
            .build();

    @Override
    public void run(String... args) {
        client.get()
                .uri(uriBuilder -> uriBuilder
                        .path("/calculate")
                        .queryParam("a", 7)
                        .queryParam("b", 5)
                        .queryParam("op", "mul")
                        .build())
                .accept(MediaType.TEXT_EVENT_STREAM)
                .retrieve()
                .bodyToFlux(String.class)
                .doOnNext(System.out::println)
                .blockLast();
    }
}
```

**Java 구현 노트:**
- Spring Boot의 리액티브 스택(`Flux` for streaming
- `ServerSentEvent` provides structured event streaming with event types
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption
- `delayElements()` simulates processing time between events
- Events can have types (`info`, `result`) for better client handling

</details>

### Comparison: Classic Streaming vs MCP Streaming

The differences between how streaming works in a "classical" manner versus how it works in MCP can be depicted like so:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

Additionally, here are some key differences:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

- **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`)을 사용합니다.
- MCP를 통한 스트리밍과 기존 스트리밍 방식 중 선택할 수 있습니다.

- **간단한 스트리밍 필요 시:** 기존 HTTP 스트리밍이 구현이 더 쉽고 기본적인 스트리밍 요구에 충분합니다.

- **복잡하고 인터랙티브한 애플리케이션의 경우:** MCP 스트리밍은 풍부한 메타데이터와 알림과 최종 결과 분리 등의 구조적 접근을 제공합니다.

- **AI 애플리케이션의 경우:** MCP의 알림 시스템은 장시간 실행되는 AI 작업에서 진행 상황을 사용자에게 지속적으로 알리는 데 특히 유용합니다.

## MCP에서의 스트리밍

이제까지 클래식 스트리밍과 MCP 스트리밍 간 차이에 대한 권장사항과 비교를 살펴보았습니다. 이제 MCP에서 스트리밍을 어떻게 활용할 수 있는지 구체적으로 알아보겠습니다.

MCP 프레임워크 내에서 스트리밍이 어떻게 작동하는지 이해하는 것은 장시간 실행 작업 중 사용자에게 실시간 피드백을 제공하는 반응형 애플리케이션을 구축하는 데 필수적입니다.

MCP에서 스트리밍은 메인 응답을 청크로 나누어 보내는 것이 아니라, 도구가 요청을 처리하는 동안 **알림(notification)** 을 클라이언트에 보내는 방식입니다. 이 알림에는 진행 상황 업데이트, 로그 또는 기타 이벤트가 포함될 수 있습니다.

### 동작 방식

메인 결과는 여전히 단일 응답으로 전송됩니다. 하지만 처리 중에 알림을 별도의 메시지로 보내 클라이언트에 실시간으로 업데이트를 제공합니다. 클라이언트는 이 알림을 처리하고 표시할 수 있어야 합니다.

## 알림(Notification)이란?

"알림"이라는 용어를 MCP 문맥에서 어떻게 이해해야 할까요?

알림은 서버가 장시간 실행되는 작업 중 진행 상황, 상태 또는 기타 이벤트를 클라이언트에 알리기 위해 보내는 메시지입니다. 알림은 투명성을 높이고 사용자 경험을 개선합니다.

예를 들어, 클라이언트는 서버와의 초기 핸드셰이크가 완료되면 알림을 보내야 합니다.

알림은 JSON 메시지 형태로 다음과 같이 나타납니다:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

알림은 MCP에서 ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging)이라는 토픽에 속합니다.

로깅 기능을 활성화하려면 서버에서 다음과 같이 기능/역량으로 설정해야 합니다:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 사용하는 SDK에 따라 로깅이 기본적으로 활성화되어 있거나, 서버 설정에서 명시적으로 활성화해야 할 수도 있습니다.

알림에는 여러 종류가 있습니다:

| 레벨       | 설명                         | 예시 사용 사례              |
|------------|------------------------------|-----------------------------|
| debug      | 상세 디버깅 정보              | 함수 진입/종료 지점          |
| info       | 일반 정보 메시지             | 작업 진행 상황 업데이트      |
| notice     | 정상적이지만 중요한 이벤트    | 설정 변경                   |
| warning    | 경고 조건                   | 더 이상 사용하지 않는 기능 사용 |
| error      | 오류 조건                   | 작업 실패                   |
| critical   | 치명적 조건                 | 시스템 구성 요소 실패        |
| alert      | 즉시 조치 필요              | 데이터 손상 감지             |
| emergency  | 시스템 사용 불가            | 전체 시스템 장애            |

## MCP에서 알림 구현하기

MCP에서 알림을 구현하려면 서버와 클라이언트 양쪽에서 실시간 업데이트를 처리할 수 있도록 설정해야 합니다. 이를 통해 장시간 실행 작업 중 사용자에게 즉각적인 피드백을 제공할 수 있습니다.

### 서버 측: 알림 보내기

서버 측부터 시작해 보겠습니다. MCP에서는 요청 처리 중 알림을 보낼 수 있는 도구를 정의합니다. 서버는 일반적으로 `ctx`라는 컨텍스트 객체를 사용해 클라이언트에 메시지를 전송합니다.

<details>
<summary>Python</summary>

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

이전 예제에서 `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` 전송 방식을 사용했습니다:

```python
mcp.run(transport="streamable-http")
```

</details>

<details>
<summary>.NET</summary>

```csharp
[Tool("A tool that sends progress notifications")]
public async Task<TextContent> ProcessFiles(string message, ToolContext ctx)
{
    await ctx.Info("Processing file 1/3...");
    await ctx.Info("Processing file 2/3...");
    await ctx.Info("Processing file 3/3...");
    return new TextContent
    {
        Type = "text",
        Text = $"Done: {message}"
    };
}
```

이 .NET 예제에서는 `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` 메서드를 통해 정보성 메시지를 보냅니다.

.NET MCP 서버에서 알림을 활성화하려면 스트리밍 전송 방식을 사용해야 합니다:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### 클라이언트 측: 알림 받기

클라이언트는 도착하는 알림을 처리하고 표시할 메시지 핸들러를 구현해야 합니다.

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)

async with ClientSession(
   read_stream, 
   write_stream,
   logging_callback=logging_collector,
   message_handler=message_handler,
) as session:
```

위 코드에서는 `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler`를 사용해 들어오는 알림을 처리합니다.

</details>

<details>
<summary>.NET</summary>

```csharp
// Define a message handler
void MessageHandler(IJsonRpcMessage message)
{
    if (message is ServerNotification notification)
    {
        Console.WriteLine($"NOTIFICATION: {notification}");
    }
    else
    {
        Console.WriteLine($"SERVER MESSAGE: {message}");
    }
}

// Create and use a client session with the message handler
var clientOptions = new ClientSessionOptions
{
    MessageHandler = MessageHandler,
    LoggingCallback = (level, message) => Console.WriteLine($"[{level}] {message}")
};

using var client = new ClientSession(readStream, writeStream, clientOptions);
await client.InitializeAsync();

// Now the client will process notifications through the MessageHandler
```

이 .NET 예제에서는 `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`)를 사용하며, 클라이언트는 알림을 처리하는 메시지 핸들러를 구현합니다.

## 진행 알림 및 시나리오

이 절에서는 MCP에서 진행 알림의 개념과 중요성, Streamable HTTP를 이용해 구현하는 방법을 설명합니다. 이해를 돕기 위한 실습 과제도 포함되어 있습니다.

진행 알림은 장시간 실행되는 작업 중 서버가 클라이언트에 실시간으로 현재 상태를 알리는 메시지입니다. 전체 작업 완료를 기다리지 않고 진행 상황을 지속적으로 전달해 투명성과 사용자 경험을 높이고 디버깅을 용이하게 합니다.

**예시:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 진행 알림을 사용하는 이유

진행 알림이 중요한 이유는 다음과 같습니다:

- **더 나은 사용자 경험:** 사용자는 작업 완료 시점이 아니라 진행 중에도 업데이트를 확인할 수 있습니다.
- **실시간 피드백:** 클라이언트는 진행 바나 로그를 표시해 애플리케이션이 반응하는 느낌을 줍니다.
- **디버깅 및 모니터링 용이:** 개발자와 사용자가 프로세스가 어디에서 느려지거나 멈추었는지 파악할 수 있습니다.

### 진행 알림 구현 방법

MCP에서 진행 알림을 구현하는 방법은 다음과 같습니다:

- **서버 측:** 각 항목 처리 시 `ctx.info()` or `ctx.log()`를 사용해 알림을 보냅니다. 이는 최종 결과가 준비되기 전에 클라이언트에 메시지를 전송합니다.
- **클라이언트 측:** 알림과 최종 결과를 구분해 처리하고 표시하는 메시지 핸들러를 구현합니다.

**서버 예시:**

<details>
<summary>Python</summary>

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

</details>

**클라이언트 예시:**

<details>
<summary>Python</summary>

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

</details>

## 보안 고려사항

HTTP 기반 전송을 사용하는 MCP 서버를 구현할 때는 여러 공격 벡터와 보호 메커니즘에 주의를 기울여야 하므로 보안이 매우 중요합니다.

### 개요

HTTP를 통해 MCP 서버를 노출할 경우 보안은 필수적입니다. Streamable HTTP는 새로운 공격 표면을 제공하며 신중한 설정이 필요합니다.

### 주요 사항
- **Origin 헤더 검증**: 항상 `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices
- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of SSE client.
- **Implement a message handler** in the client to process notifications.
- **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

## Security Considerations

Security should be a top priority when implementing any server, especially when using HTTP-based transports like Streamable HTTP in MCP. 

When implementing MCP servers with HTTP-based transports, security becomes a paramount concern that requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

Here are some key security considerations:

- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Implement authentication (e.g., API keys, OAuth) for production deployments.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additionally, here are some best practices to follow when implementing security in your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to patch security vulnerabilities.

### Challenges

You will face some challenges when implementing security in MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), migrating to Streamable HTTP provides enhanced capabilities and better long-term sustainability for your MCP implementations.

### Why Upgrade?

There are two compelling reasons to upgrade from SSE to Streamable HTTP:

- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

Here's how you can migrate from SSE to Streamable HTTP in your MCP applications:

1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client`를 SSE 클라이언트 대신 사용하세요.
3. 클라이언트에서 알림을 처리할 메시지 핸들러를 구현하세요.
4. 기존 도구 및 워크플로우와의 호환성을 테스트하세요.

### 호환성 유지

마이그레이션 과정에서 기존 SSE 클라이언트와의 호환성을 유지하는 것이 권장됩니다. 다음과 같은 전략이 있습니다:

- 서로 다른 엔드포인트에서 SSE와 Streamable HTTP를 동시에 지원할 수 있습니다.
- 클라이언트를 점진적으로 새로운 전송 방식으로 이전합니다.

### 도전 과제

마이그레이션 시 다음 문제를 해결해야 합니다:

- 모든 클라이언트가 업데이트되었는지 확인
- 알림 전달 방식 차이 처리

### 과제: 직접 스트리밍 MCP 애플리케이션 만들기

**시나리오:**
서버가 아이템 목록(예: 파일이나 문서)을 처리하며 각 아이템 처리 시 알림을 보내는 MCP 서버와 클라이언트를 만드세요. 클라이언트는 도착하는 알림을 실시간으로 표시해야 합니다.

**단계:**

1. 아이템 목록을 처리하고 각 아이템마다 알림을 보내는 서버 도구를 구현하세요.
2. 알림을 실시간으로 표시하는 메시지 핸들러를 갖춘 클라이언트를 구현하세요.
3. 서버와 클라이언트를 실행해 알림이 제대로 표시되는지 테스트하세요.

[Solution](./solution/README.md)

## 추가 자료 및 다음 단계

MCP 스트리밍에 대한 이해를 심화하고 더 발전된 애플리케이션을 구축하기 위해 아래 추가 자료와 권장 단계를 참고하세요.

### 추가 자료

- [Microsoft: HTTP 스트리밍 소개](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core에서 CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: 스트리밍 요청](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 다음 단계

- 실시간 분석, 채팅, 협업 편집 등 스트리밍을 활용하는 더 발전된 MCP 도구를 만들어 보세요.
- MCP 스트리밍을 프론트엔드 프레임워크(React, Vue 등)와 통합해 라이브 UI 업데이트를 구현해 보세요.
- 다음: [VSCode용 AI 툴킷 활용](../07-aitk/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원본 문서는 해당 언어의 원문이 권위 있는 자료로 간주되어야 합니다. 중요한 정보의 경우, 전문 인간 번역을 권장합니다. 본 번역의 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.