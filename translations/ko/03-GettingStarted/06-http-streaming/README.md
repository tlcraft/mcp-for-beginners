<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:30:54+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ko"
}
-->
# Model Context Protocol (MCP)를 이용한 HTTPS 스트리밍

이 장에서는 HTTPS를 사용하여 Model Context Protocol(MCP)로 안전하고 확장 가능하며 실시간 스트리밍을 구현하는 방법을 자세히 안내합니다. 스트리밍의 동기, 사용 가능한 전송 메커니즘, MCP에서 스트리밍 가능한 HTTP 구현 방법, 보안 모범 사례, SSE에서의 마이그레이션, 그리고 자체 스트리밍 MCP 애플리케이션 구축을 위한 실용적인 지침을 다룹니다.

## MCP의 전송 메커니즘과 스트리밍

이 절에서는 MCP에서 사용 가능한 다양한 전송 메커니즘과 이들이 클라이언트와 서버 간 실시간 통신을 가능하게 하는 스트리밍 기능에서 어떤 역할을 하는지 살펴봅니다.

### 전송 메커니즘이란?

전송 메커니즘은 클라이언트와 서버 간 데이터가 어떻게 교환되는지를 정의합니다. MCP는 다양한 환경과 요구사항에 맞게 여러 전송 유형을 지원합니다:

- **stdio**: 표준 입출력으로, 로컬 및 CLI 기반 도구에 적합합니다. 간단하지만 웹이나 클라우드에는 적합하지 않습니다.
- **SSE (Server-Sent Events)**: 서버가 HTTP를 통해 클라이언트에 실시간 업데이트를 푸시할 수 있게 합니다. 웹 UI에 적합하지만 확장성과 유연성에 한계가 있습니다.
- **Streamable HTTP**: 알림과 더 나은 확장성을 지원하는 최신 HTTP 기반 스트리밍 전송 방식입니다. 대부분의 프로덕션 및 클라우드 환경에 권장됩니다.

### 비교 표

아래 비교 표를 통해 각 전송 메커니즘의 차이점을 확인해 보세요:

| 전송 방식         | 실시간 업데이트 | 스트리밍 | 확장성    | 사용 사례               |
|-------------------|----------------|----------|----------|------------------------|
| stdio             | 아니요         | 아니요   | 낮음     | 로컬 CLI 도구          |
| SSE               | 예             | 예       | 중간     | 웹, 실시간 업데이트    |
| Streamable HTTP   | 예             | 예       | 높음     | 클라우드, 다중 클라이언트 |

> **팁:** 적절한 전송 방식을 선택하는 것은 성능, 확장성, 사용자 경험에 큰 영향을 미칩니다. **Streamable HTTP**는 현대적이고 확장 가능하며 클라우드에 적합한 애플리케이션에 권장됩니다.

이전 장에서 소개한 stdio와 SSE 전송 방식과 이번 장에서 다루는 Streamable HTTP 전송 방식을 기억하세요.

## 스트리밍: 개념과 동기

스트리밍의 기본 개념과 동기를 이해하는 것은 효과적인 실시간 통신 시스템을 구현하는 데 필수적입니다.

**스트리밍**은 네트워크 프로그래밍에서 전체 응답이 준비될 때까지 기다리지 않고, 데이터를 작고 관리 가능한 조각이나 이벤트 시퀀스로 주고받는 기술입니다. 특히 다음과 같은 경우에 유용합니다:

- 대용량 파일이나 데이터셋
- 실시간 업데이트(예: 채팅, 진행 바)
- 사용자에게 지속적으로 정보를 제공해야 하는 장시간 실행 작업

스트리밍에 대해 알아야 할 주요 내용은 다음과 같습니다:

- 데이터가 한꺼번에가 아니라 점진적으로 전달됩니다.
- 클라이언트는 도착하는 데이터를 즉시 처리할 수 있습니다.
- 지연 시간을 줄이고 사용자 경험을 향상시킵니다.

### 왜 스트리밍을 사용할까?

스트리밍을 사용하는 이유는 다음과 같습니다:

- 사용자가 작업 완료 시점뿐 아니라 즉시 피드백을 받습니다.
- 실시간 애플리케이션과 반응형 UI를 가능하게 합니다.
- 네트워크 및 컴퓨팅 자원을 더 효율적으로 사용합니다.

### 간단한 예: HTTP 스트리밍 서버 & 클라이언트

다음은 스트리밍을 구현하는 간단한 예입니다:

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

이 예제는 서버가 모든 메시지가 준비될 때까지 기다리지 않고, 메시지가 준비되는 대로 클라이언트에 순차적으로 전송하는 방식을 보여줍니다.

**작동 원리:**
- 서버는 메시지가 준비될 때마다 이를 순차적으로 전송합니다.
- 클라이언트는 도착하는 각 조각을 받아 출력합니다.

**요구 사항:**
- 서버는 스트리밍 응답(예: FastAPI의 `StreamingResponse`)을 사용해야 합니다.
- 클라이언트는 스트림으로 응답을 처리해야 합니다(`requests`의 `stream=True`).
- Content-Type은 보통 `text/event-stream` 또는 `application/octet-stream`입니다.

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

**Java 구현 참고 사항:**
- Spring Boot의 리액티브 스택과 `Flux`를 사용한 스트리밍
- `ServerSentEvent`는 이벤트 타입이 포함된 구조화된 이벤트 스트리밍 제공
- `WebClient`의 `bodyToFlux()`로 리액티브 스트리밍 소비 가능
- `delayElements()`로 이벤트 간 처리 시간 시뮬레이션
- 이벤트에 `info`, `result` 등 타입을 지정해 클라이언트 처리 용이

</details>

### 비교: 전통적 스트리밍 vs MCP 스트리밍

전통적인 스트리밍과 MCP 스트리밍의 차이는 다음과 같이 요약할 수 있습니다:

| 특징                  | 전통적 HTTP 스트리밍           | MCP 스트리밍 (알림 방식)          |
|-----------------------|-------------------------------|----------------------------------|
| 주요 응답             | 청크 단위 전송                | 단일 응답, 마지막에 전송          |
| 진행 상황 업데이트    | 데이터 청크로 전송            | 알림 메시지로 전송               |
| 클라이언트 요구 사항  | 스트림 처리 필요              | 메시지 핸들러 구현 필요          |
| 사용 사례             | 대용량 파일, AI 토큰 스트림  | 진행 상황, 로그, 실시간 피드백   |

### 주요 차이점

추가로 다음과 같은 차이점이 있습니다:

- **통신 패턴:**
   - 전통적 HTTP 스트리밍: 단순 청크 전송 인코딩 사용
   - MCP 스트리밍: JSON-RPC 프로토콜 기반 구조화된 알림 시스템 사용

- **메시지 형식:**
   - 전통적 HTTP: 줄바꿈이 포함된 일반 텍스트 청크
   - MCP: 메타데이터가 포함된 구조화된 LoggingMessageNotification 객체

- **클라이언트 구현:**
   - 전통적 HTTP: 스트리밍 응답을 처리하는 간단한 클라이언트
   - MCP: 다양한 메시지 유형을 처리하는 메시지 핸들러가 있는 복잡한 클라이언트

- **진행 상황 업데이트:**
   - 전통적 HTTP: 진행 상황이 주요 응답 스트림의 일부
   - MCP: 진행 상황은 별도의 알림 메시지로 전송되고, 주요 응답은 마지막에 전송

### 권장 사항

전통적인 스트리밍(`/stream` 엔드포인트 사용)과 MCP 스트리밍 중 선택할 때 다음을 권장합니다:

- **간단한 스트리밍 필요 시:** 전통적 HTTP 스트리밍이 구현이 간단하고 기본적인 스트리밍에 충분합니다.
- **복잡하고 상호작용이 많은 애플리케이션:** MCP 스트리밍은 더 풍부한 메타데이터와 알림과 최종 결과 분리를 제공하는 구조화된 접근법입니다.
- **AI 애플리케이션:** MCP의 알림 시스템은 장시간 실행되는 AI 작업에서 진행 상황을 사용자에게 지속적으로 알리는 데 특히 유용합니다.

## MCP에서의 스트리밍

지금까지 전통적 스트리밍과 MCP 스트리밍의 차이와 권장 사항을 살펴보았습니다. 이제 MCP에서 스트리밍을 어떻게 활용할 수 있는지 자세히 알아보겠습니다.

MCP 프레임워크 내에서 스트리밍이 어떻게 작동하는지 이해하는 것은 장시간 실행 작업 중 사용자에게 실시간 피드백을 제공하는 반응형 애플리케이션을 구축하는 데 필수적입니다.

MCP에서 스트리밍은 주요 응답을 청크로 나누어 보내는 것이 아니라, 도구가 요청을 처리하는 동안 **알림(notification)** 을 클라이언트에 보내는 방식입니다. 이 알림에는 진행 상황 업데이트, 로그, 기타 이벤트가 포함될 수 있습니다.

### 작동 방식

주요 결과는 여전히 단일 응답으로 전송됩니다. 하지만 처리 중에 별도의 메시지로 알림을 보내 클라이언트에 실시간으로 업데이트할 수 있습니다. 클라이언트는 이러한 알림을 처리하고 표시할 수 있어야 합니다.

## 알림(Notification)이란?

"알림"이란 MCP 맥락에서 무엇을 의미할까요?

알림은 서버가 장시간 실행 작업 중 진행 상황, 상태 또는 기타 이벤트를 클라이언트에 알리기 위해 보내는 메시지입니다. 알림은 투명성과 사용자 경험을 향상시킵니다.

예를 들어, 클라이언트는 서버와 초기 핸드셰이크가 완료되면 알림을 보내야 합니다.

알림은 다음과 같은 JSON 메시지 형태를 가집니다:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

알림은 MCP에서 ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging)이라는 주제(topic)에 속합니다.

로깅 기능을 활성화하려면 서버에서 다음과 같이 기능/역량을 활성화해야 합니다:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> 사용 중인 SDK에 따라 로깅이 기본적으로 활성화되어 있을 수도 있고, 서버 설정에서 명시적으로 활성화해야 할 수도 있습니다.

알림에는 여러 유형이 있습니다:

| 레벨       | 설명                          | 사용 예시                      |
|------------|-------------------------------|-------------------------------|
| debug      | 상세 디버깅 정보               | 함수 진입/종료 지점            |
| info       | 일반 정보 메시지              | 작업 진행 상황 업데이트        |
| notice     | 정상적이지만 중요한 이벤트    | 설정 변경                     |
| warning    | 경고 조건                    | 더 이상 사용되지 않는 기능 사용 |
| error      | 오류 조건                    | 작업 실패                     |
| critical   | 치명적 조건                  | 시스템 구성 요소 실패          |
| alert      | 즉각 조치 필요               | 데이터 손상 감지              |
| emergency  | 시스템 사용 불가             | 전체 시스템 장애              |

## MCP에서 알림 구현하기

MCP에서 알림을 구현하려면 서버와 클라이언트 양쪽에서 실시간 업데이트를 처리할 수 있도록 설정해야 합니다. 이를 통해 장시간 실행 작업 중 사용자에게 즉각적인 피드백을 제공할 수 있습니다.

### 서버 측: 알림 보내기

서버 측부터 시작해 보겠습니다. MCP에서는 요청을 처리하는 동안 알림을 보낼 수 있는 도구를 정의합니다. 서버는 보통 `ctx`라는 컨텍스트 객체를 사용해 클라이언트에 메시지를 보냅니다.

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

위 예제에서 `process_files` 도구는 각 파일을 처리하면서 세 번의 알림을 클라이언트에 보냅니다. `ctx.info()` 메서드는 정보성 메시지를 보내는 데 사용됩니다.

</details>

또한, 알림을 활성화하려면 서버가 스트리밍 전송(예: `streamable-http`)을 사용하고 클라이언트가 알림을 처리할 메시지 핸들러를 구현해야 합니다. 다음은 서버에서 `streamable-http` 전송을 사용하는 설정 예입니다:

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

이 .NET 예제에서 `ProcessFiles` 도구는 각 파일을 처리하면서 세 번의 알림을 클라이언트에 보냅니다. `ctx.Info()` 메서드는 정보성 메시지를 보내는 데 사용됩니다.

.NET MCP 서버에서 알림을 활성화하려면 스트리밍 전송을 사용해야 합니다:

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

위 코드에서 `message_handler` 함수는 들어오는 메시지가 알림인지 확인합니다. 알림이면 출력하고, 그렇지 않으면 일반 서버 메시지로 처리합니다. 또한 `ClientSession`이 `message_handler`와 함께 초기화되어 알림을 처리합니다.

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

이 .NET 예제에서 `MessageHandler` 함수는 들어오는 메시지가 알림인지 확인합니다. 알림이면 출력하고, 그렇지 않으면 일반 서버 메시지로 처리합니다. `ClientSession`은 `ClientSessionOptions`를 통해 메시지 핸들러와 함께 초기화됩니다.

</details>

알림을 활성화하려면 서버가 스트리밍 전송(예: `streamable-http`)을 사용하고 클라이언트가 알림을 처리할 메시지 핸들러를 구현해야 합니다.

## 진행 상황 알림 및 시나리오

이 절에서는 MCP에서 진행 상황 알림의 개념, 중요성, 그리고 Streamable HTTP를 사용해 이를 구현하는 방법을 설명합니다. 이해를 돕기 위한 실습 과제도 포함되어 있습니다.

진행 상황 알림은 장시간 실행 작업 중 서버가 클라이언트에 보내는 실시간 메시지입니다. 전체 작업이 끝날 때까지 기다리지 않고 현재 상태를 지속적으로 알려줍니다. 이는 투명성, 사용자 경험을 높이고 디버깅을 용이하게 합니다.

**예시:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### 왜 진행 상황 알림을 사용할까?

진행 상황 알림이 중요한 이유는 다음과 같습니다:

- **더 나은 사용자 경험:** 작업이 진행되는 동안 사용자가 업데이트를 확인할 수 있습니다.
- **실시간 피드백:** 클라이언트는 진행 바나 로그를 표시해 애플리케이션이 반응하는 느낌을 줍니다.
- **디버깅 및 모니터링 용이:** 개발자와 사용자가 작업이 느리거나 멈춘 지점을 파악할 수 있습니다.

### 진행 상황 알림 구현 방법

MCP에서 진행 상황 알림을 구현하는 방법은 다음과 같습니다:

- **서버 측:** 각 항목이 처리될 때마다 `ctx.info()` 또는 `ctx.log()`를 사용해 알림을 보냅니다. 이는 주요 결과가 준비되기 전에 클라이언트에 메시지를 전송합니다.
- **클라이언트 측:** 도착하는 알림을 수신하고 표시하는 메시지 핸들러를 구현합니다. 이 핸들러는 알림과 최종 결과를 구분합니다.

**서버 예제:**

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

**클라이언트 예제:**

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

HTTP 기반 전송을 사용하는 MCP 서버를 구현할 때는 여러 공격 경로와 보호 메커니즘에 세심한 주의를 기울여야 하므로 보안이 매우 중요합니다.

### 개요

MCP 서버를 HTTP로 노출할 때 보안은 필수적입니다. 스트리밍 가능한 HTTP는 새로운 공격 표면을 제공하므로 신중한 설정이 필요합니다.

### 주요 사항
- **Origin 헤더 검증**: DNS 리바인딩 공격을 방지하기 위해 항상 `Origin` 헤더를 검증하세요.
- **로컬호스트 바인딩**: 로컬 개발 시 서버를 `localhost`에 바인딩하여 공개 인터넷에 노출되지 않도록 하세요.
- **인증**: 운영 환경에서는 API 키, OAuth 등 인증을 구현하세요.
- **CORS**: 접근을 제한하기 위해 교차 출처 리소스 공유(CORS) 정책을 설정하세요.
- **HTTPS**: 운영 환경에서는 트래픽 암호화를 위해 HTTPS를 사용하세요.

### 모범 사례
- 검증 없이 들어오는 요청을 절대 신뢰하지 마세요.
- 모든 접근과 오류를 기록하고 모니터링하세요.
- 보안 취약점 패치를 위해 의존성은 정기적으로 업데이트하세요.

### 도전 과제
- 보안과 개발 편의성 간의 균형 맞추기
- 다양한 클라이언트 환경과의 호환성 확보


## SSE에서 스트리밍 가능한 HTTP로 업그레이드하기

현재 Server-Sent Events(SSE)를 사용하는 애플리케이션은 스트리밍 가능한 HTTP로 전환하면 MCP 구현에 더 나은 확장성과 장기적인 유지 가능성을 제공합니다.

### 업그레이드 이유

SSE에서 스트리밍 가능한 HTTP로 업그레이드해야 하는 두 가지 주요 이유는 다음과 같습니다:

- 스트리밍 가능한 HTTP는 SSE보다 더 나은 확장성, 호환성, 풍부한 알림 지원을 제공합니다.
- 새로운 MCP 애플리케이션에 권장되는 전송 방식입니다.

### 마이그레이션 단계

MCP 애플리케이션에서 SSE에서 스트리밍 가능한 HTTP로 전환하는 방법은 다음과 같습니다:

- 서버 코드를 `mcp.run()`에서 `transport="streamable-http"`로 업데이트하세요.
- 클라이언트 코드를 SSE 클라이언트 대신 `streamablehttp_client`로 변경하세요.
- 클라이언트에 알림을 처리할 메시지 핸들러를 구현하세요.
- 기존 도구 및 워크플로우와의 호환성을 테스트하세요.

### 호환성 유지

마이그레이션 과정에서 기존 SSE 클라이언트와의 호환성을 유지하는 것이 좋습니다. 다음과 같은 전략이 있습니다:

- 서로 다른 엔드포인트에서 SSE와 스트리밍 가능한 HTTP를 동시에 지원할 수 있습니다.
- 클라이언트를 점진적으로 새로운 전송 방식으로 전환하세요.

### 도전 과제

마이그레이션 시 다음 문제를 해결해야 합니다:

- 모든 클라이언트가 업데이트되었는지 확인
- 알림 전달 방식의 차이 처리

## 보안 고려사항

HTTP 기반 전송, 특히 MCP에서 스트리밍 가능한 HTTP를 사용할 때는 보안이 최우선 과제입니다.

HTTP 기반 전송을 사용하는 MCP 서버를 구현할 때는 여러 공격 경로와 보호 메커니즘에 세심한 주의를 기울여야 하므로 보안이 매우 중요합니다.

### 개요

MCP 서버를 HTTP로 노출할 때 보안은 필수적입니다. 스트리밍 가능한 HTTP는 새로운 공격 표면을 제공하므로 신중한 설정이 필요합니다.

다음은 주요 보안 고려사항입니다:

- **Origin 헤더 검증**: DNS 리바인딩 공격을 방지하기 위해 항상 `Origin` 헤더를 검증하세요.
- **로컬호스트 바인딩**: 로컬 개발 시 서버를 `localhost`에 바인딩하여 공개 인터넷에 노출되지 않도록 하세요.
- **인증**: 운영 환경에서는 API 키, OAuth 등 인증을 구현하세요.
- **CORS**: 접근을 제한하기 위해 교차 출처 리소스 공유(CORS) 정책을 설정하세요.
- **HTTPS**: 운영 환경에서는 트래픽 암호화를 위해 HTTPS를 사용하세요.

### 모범 사례

MCP 스트리밍 서버 보안을 구현할 때 다음 모범 사례를 따르세요:

- 검증 없이 들어오는 요청을 절대 신뢰하지 마세요.
- 모든 접근과 오류를 기록하고 모니터링하세요.
- 보안 취약점 패치를 위해 의존성은 정기적으로 업데이트하세요.

### 도전 과제

MCP 스트리밍 서버 보안 구현 시 다음과 같은 어려움이 있을 수 있습니다:

- 보안과 개발 편의성 간의 균형 맞추기
- 다양한 클라이언트 환경과의 호환성 확보

### 과제: 나만의 스트리밍 MCP 앱 만들기

**시나리오:**
서버가 항목 목록(예: 파일 또는 문서)을 처리하고 각 항목 처리 시 알림을 보내는 MCP 서버와 클라이언트를 만드세요. 클라이언트는 도착하는 알림을 실시간으로 표시해야 합니다.

**단계:**

1. 목록을 처리하고 각 항목에 대해 알림을 보내는 서버 도구를 구현하세요.
2. 알림을 실시간으로 표시할 메시지 핸들러가 있는 클라이언트를 구현하세요.
3. 서버와 클라이언트를 실행하여 알림이 제대로 표시되는지 테스트하세요.

[Solution](./solution/README.md)

## 추가 학습 및 다음 단계

MCP 스트리밍을 더 깊이 이해하고 고급 애플리케이션을 개발하기 위해 다음 자료와 권장 단계를 참고하세요.

### 추가 학습 자료

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### 다음 단계

- 실시간 분석, 채팅, 협업 편집 등에 스트리밍을 활용하는 고급 MCP 도구를 만들어 보세요.
- 프론트엔드 프레임워크(React, Vue 등)와 MCP 스트리밍을 연동해 실시간 UI 업데이트를 구현해 보세요.
- 다음: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원문은 해당 언어의 원본 문서가 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해 당사는 책임을 지지 않습니다.