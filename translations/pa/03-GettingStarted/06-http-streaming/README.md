<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:57:09+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "pa"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

ਇਹ ਅਧਿਆਇ HTTPS ਦੀ ਵਰਤੋਂ ਨਾਲ Model Context Protocol (MCP) ਰਾਹੀਂ ਸੁਰੱਖਿਅਤ, ਸਕੇਲ ਕਰਨ ਯੋਗ ਅਤੇ ਰੀਅਲ-ਟਾਈਮ ਸਟ੍ਰੀਮਿੰਗ ਨੂੰ ਲਾਗੂ ਕਰਨ ਲਈ ਵਿਸਤ੍ਰਿਤ ਮਾਰਗਦਰਸ਼ਨ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ। ਇਸ ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ ਦੀ ਪ੍ਰੇਰਣਾ, ਉਪਲਬਧ ਟਰਾਂਸਪੋਰਟ ਮਿਕੈਨਿਜ਼ਮ, MCP ਵਿੱਚ ਸਟ੍ਰੀਮਬਲ HTTP ਨੂੰ ਕਿਵੇਂ ਲਾਗੂ ਕਰਨਾ ਹੈ, ਸੁਰੱਖਿਆ ਦੀਆਂ ਸਿੱਖਿਆਵਾਂ, SSE ਤੋਂ ਮਾਈਗ੍ਰੇਸ਼ਨ ਅਤੇ ਆਪਣੀਆਂ ਸਟ੍ਰੀਮਿੰਗ MCP ਐਪਲੀਕੇਸ਼ਨਾਂ ਬਣਾਉਣ ਲਈ ਵਿਹਾਰਕ ਮਦਦ ਸ਼ਾਮਲ ਹੈ।

## MCP ਵਿੱਚ ਟਰਾਂਸਪੋਰਟ ਮਿਕੈਨਿਜ਼ਮ ਅਤੇ ਸਟ੍ਰੀਮਿੰਗ

ਇਸ ਭਾਗ ਵਿੱਚ MCP ਵਿੱਚ ਉਪਲਬਧ ਵੱਖ-ਵੱਖ ਟਰਾਂਸਪੋਰਟ ਮਿਕੈਨਿਜ਼ਮ ਅਤੇ ਇਹ ਕਿਵੇਂ ਕਲਾਇੰਟ ਅਤੇ ਸਰਵਰ ਵਿਚਕਾਰ ਰੀਅਲ-ਟਾਈਮ ਸੰਚਾਰ ਲਈ ਸਟ੍ਰੀਮਿੰਗ ਯੋਗਤਾਵਾਂ ਨੂੰ ਸਮਰਥਿਤ ਕਰਦੇ ਹਨ, ਦੀ ਜਾਂਚ ਕੀਤੀ ਗਈ ਹੈ।

### ਟਰਾਂਸਪੋਰਟ ਮਿਕੈਨਿਜ਼ਮ ਕੀ ਹੈ?

ਟਰਾਂਸਪੋਰਟ ਮਿਕੈਨਿਜ਼ਮ ਇਹ ਪਰਿਭਾਸ਼ਿਤ ਕਰਦਾ ਹੈ ਕਿ ਕਿਵੇਂ ਡਾਟਾ ਕਲਾਇੰਟ ਅਤੇ ਸਰਵਰ ਵਿਚਕਾਰ ਬਦਲਿਆ ਜਾਂਦਾ ਹੈ। MCP ਵੱਖ-ਵੱਖ ਵਾਤਾਵਰਣਾਂ ਅਤੇ ਲੋੜਾਂ ਲਈ ਕਈ ਪ੍ਰਕਾਰ ਦੇ ਟਰਾਂਸਪੋਰਟ ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ:

- **stdio**: ਸਟੈਂਡਰਡ ਇਨਪੁਟ/ਆਉਟਪੁਟ, ਸਥਾਨਕ ਅਤੇ CLI-ਆਧਾਰਿਤ ਟੂਲਾਂ ਲਈ ਉਚਿਤ। ਸਧਾਰਣ ਪਰ ਵੈੱਬ ਜਾਂ ਕਲਾਉਡ ਲਈ ਉਚਿਤ ਨਹੀਂ।
- **SSE (Server-Sent Events)**: ਸਰਵਰ HTTP ਰਾਹੀਂ ਕਲਾਇੰਟਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ ਭੇਜਣ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਵੈੱਬ UIs ਲਈ ਵਧੀਆ, ਪਰ ਸਕੇਲ ਕਰਨ ਅਤੇ ਲਚਕੀਲਾਪਣ ਵਿੱਚ ਸੀਮਿਤ।
- **Streamable HTTP**: ਆਧੁਨਿਕ HTTP-ਆਧਾਰਿਤ ਸਟ੍ਰੀਮਿੰਗ ਟਰਾਂਸਪੋਰਟ, ਨੋਟੀਫਿਕੇਸ਼ਨਾਂ ਅਤੇ ਵਧੀਆ ਸਕੇਲਬਿਲਿਟੀ ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ। ਜ਼ਿਆਦਾਤਰ ਪ੍ਰੋਡਕਸ਼ਨ ਅਤੇ ਕਲਾਉਡ ਸਥਿਤੀਆਂ ਲਈ ਸਿਫ਼ਾਰਸ਼ੀ।

### ਤੁਲਨਾਤਮਕ ਸਾਰਣੀ

ਹੇਠਾਂ ਦਿੱਤੀ ਸਾਰਣੀ ਵਿੱਚ ਇਹਨਾਂ ਟਰਾਂਸਪੋਰਟ ਮਿਕੈਨਿਜ਼ਮਾਂ ਦੇ ਫਰਕ ਨੂੰ ਸਮਝੋ:

| Transport         | ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ | ਸਟ੍ਰੀਮਿੰਗ | ਸਕੇਲਬਿਲਿਟੀ | ਵਰਤੋਂ ਦਾ ਕੇਸ           |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | ਨਹੀਂ             | ਨਹੀਂ      | ਘੱਟ        | ਸਥਾਨਕ CLI ਟੂਲ          |
| SSE               | ਹਾਂ              | ਹਾਂ       | ਮੱਧਮ       | ਵੈੱਬ, ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ |
| Streamable HTTP   | ਹਾਂ              | ਹਾਂ       | ਉੱਚ        | ਕਲਾਉਡ, ਬਹੁ-ਕਲਾਇੰਟ      |

> **ਟਿਪ:** ਸਹੀ ਟਰਾਂਸਪੋਰਟ ਦੀ ਚੋਣ ਪ੍ਰਦਰਸ਼ਨ, ਸਕੇਲਬਿਲਿਟੀ ਅਤੇ ਉਪਭੋਗਤਾ ਅਨੁਭਵ ਨੂੰ ਪ੍ਰਭਾਵਿਤ ਕਰਦੀ ਹੈ। **Streamable HTTP** ਆਧੁਨਿਕ, ਸਕੇਲ ਕਰਨ ਯੋਗ ਅਤੇ ਕਲਾਉਡ-ਤਿਆਰ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਸਿਫ਼ਾਰਸ਼ੀ ਹੈ।

ਪਿਛਲੇ ਅਧਿਆਇਆਂ ਵਿੱਚ ਤੁਹਾਨੂੰ ਦਿਖਾਏ ਗਏ stdio ਅਤੇ SSE ਟਰਾਂਸਪੋਰਟ ਅਤੇ ਇਸ ਅਧਿਆਇ ਵਿੱਚ ਕਵਰ ਕੀਤੇ ਗਏ streamable HTTP ਟਰਾਂਸਪੋਰਟ ਨੂੰ ਨੋਟ ਕਰੋ।

## ਸਟ੍ਰੀਮਿੰਗ: ਧਾਰਣਾਵਾਂ ਅਤੇ ਪ੍ਰੇਰਣਾ

ਸਟ੍ਰੀਮਿੰਗ ਦੇ ਮੂਲ ਧਾਰਣਾਵਾਂ ਅਤੇ ਪ੍ਰੇਰਣਾਵਾਂ ਨੂੰ ਸਮਝਣਾ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਰੀਅਲ-ਟਾਈਮ ਸੰਚਾਰ ਪ੍ਰਣਾਲੀਆਂ ਨੂੰ ਲਾਗੂ ਕਰਨ ਲਈ ਜ਼ਰੂਰੀ ਹੈ।

**ਸਟ੍ਰੀਮਿੰਗ** ਨੈੱਟਵਰਕ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਵਿੱਚ ਇੱਕ ਤਕਨੀਕ ਹੈ ਜੋ ਡਾਟਾ ਨੂੰ ਛੋਟੇ, ਸੰਭਾਲਣ ਯੋਗ ਹਿੱਸਿਆਂ ਵਿੱਚ ਜਾਂ ਘਟਨਾਵਾਂ ਦੀ ਲੜੀ ਵਜੋਂ ਭੇਜਣ ਅਤੇ ਪ੍ਰਾਪਤ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦੀ ਹੈ, ਨਾ ਕਿ ਪੂਰੇ ਜਵਾਬ ਦੇ ਤਿਆਰ ਹੋਣ ਦੀ ਉਡੀਕ ਕਰਨ ਦੀ। ਇਹ ਖਾਸ ਤੌਰ 'ਤੇ ਲਾਭਦਾਇਕ ਹੈ:

- ਵੱਡੀਆਂ ਫਾਇਲਾਂ ਜਾਂ ਡੇਟਾਸੈੱਟ ਲਈ।
- ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ (ਜਿਵੇਂ ਕਿ ਚੈਟ, ਪ੍ਰੋਗਰੈਸ ਬਾਰ)।
- ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ ਕੰਪਿਊਟੇਸ਼ਨਾਂ ਜਿੱਥੇ ਤੁਸੀਂ ਉਪਭੋਗਤਾ ਨੂੰ ਜਾਣੂ ਰੱਖਣਾ ਚਾਹੁੰਦੇ ਹੋ।

ਸਟ੍ਰੀਮਿੰਗ ਬਾਰੇ ਤੁਹਾਨੂੰ ਉੱਚ ਸਤਰ 'ਤੇ ਇਹ ਜਾਣਨਾ ਚਾਹੀਦਾ ਹੈ:

- ਡਾਟਾ ਕ੍ਰਮਬੱਧ ਤੌਰ 'ਤੇ ਦਿੱਤਾ ਜਾਂਦਾ ਹੈ, ਇੱਕ ਵਾਰੀ ਵਿੱਚ ਸਾਰਾ ਨਹੀਂ।
- ਕਲਾਇੰਟ ਡਾਟਾ ਨੂੰ ਜਿਵੇਂ ਹੀ ਮਿਲਦਾ ਹੈ, ਪ੍ਰਕਿਰਿਆ ਕਰ ਸਕਦਾ ਹੈ।
- ਮਹਿਸੂਸ ਕੀਤੀ ਗਈ ਲੈਟੈਂਸੀ ਨੂੰ ਘਟਾਉਂਦਾ ਹੈ ਅਤੇ ਉਪਭੋਗਤਾ ਅਨੁਭਵ ਨੂੰ ਸੁਧਾਰਦਾ ਹੈ।

### ਸਟ੍ਰੀਮਿੰਗ ਕਿਉਂ ਵਰਤੋਂ?

ਸਟ੍ਰੀਮਿੰਗ ਵਰਤਣ ਦੇ ਕਾਰਨ ਇਹ ਹਨ:

- ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਤੁਰੰਤ ਫੀਡਬੈਕ ਮਿਲਦਾ ਹੈ, ਸਿਰਫ ਅੰਤ ਵਿੱਚ ਨਹੀਂ
- ਰੀਅਲ-ਟਾਈਮ ਐਪਲੀਕੇਸ਼ਨਾਂ ਅਤੇ ਸੰਵੇਦਨਸ਼ੀਲ UIs ਨੂੰ ਯੋਗ ਬਣਾਉਂਦਾ ਹੈ
- ਨੈੱਟਵਰਕ ਅਤੇ ਕੰਪਿਊਟ ਸਰੋਤਾਂ ਦੀ ਜ਼ਿਆਦਾ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਵਰਤੋਂ

### ਸਧਾਰਣ ਉਦਾਹਰਨ: HTTP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ

ਇੱਥੇ ਇੱਕ ਸਧਾਰਣ ਉਦਾਹਰਨ ਹੈ ਕਿ ਸਟ੍ਰੀਮਿੰਗ ਕਿਵੇਂ ਲਾਗੂ ਕੀਤੀ ਜਾ ਸਕਦੀ ਹੈ:

<details>
<summary>Python</summary>

**ਸਰਵਰ (Python, FastAPI ਅਤੇ StreamingResponse ਦੀ ਵਰਤੋਂ ਕਰਕੇ):**
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

**ਕਲਾਇੰਟ (Python, requests ਦੀ ਵਰਤੋਂ ਕਰਕੇ):**
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

ਇਹ ਉਦਾਹਰਨ ਦਰਸਾਉਂਦੀ ਹੈ ਕਿ ਸਰਵਰ ਕਿਵੇਂ ਤਿਆਰ ਹੋਣ ਵਾਲੇ ਹਰ ਸੁਨੇਹੇ ਨੂੰ ਕਲਾਇੰਟ ਨੂੰ ਭੇਜਦਾ ਹੈ, ਬਜਾਏ ਇਸਦੇ ਕਿ ਸਾਰੇ ਸੁਨੇਹੇ ਤਿਆਰ ਹੋਣ ਦੀ ਉਡੀਕ ਕੀਤੀ ਜਾਵੇ।

**ਕਿਵੇਂ ਕੰਮ ਕਰਦਾ ਹੈ:**
- ਸਰਵਰ ਹਰ ਸੁਨੇਹੇ ਨੂੰ ਜਿਵੇਂ ਹੀ ਤਿਆਰ ਹੁੰਦਾ ਹੈ, ਭੇਜਦਾ ਹੈ।
- ਕਲਾਇੰਟ ਹਰ ਹਿੱਸਾ ਮਿਲਣ ਤੇ ਪ੍ਰਿੰਟ ਕਰਦਾ ਹੈ।

**ਲੋੜੀਂਦਾ:**
- ਸਰਵਰ ਨੂੰ ਸਟ੍ਰੀਮਿੰਗ ਰਿਸਪਾਂਸ ਵਰਤਣਾ ਚਾਹੀਦਾ ਹੈ (ਜਿਵੇਂ `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**ਸਰਵਰ (Java, Spring Boot ਅਤੇ Server-Sent Events ਦੀ ਵਰਤੋਂ ਕਰਕੇ):**

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

**ਕਲਾਇੰਟ (Java, Spring WebFlux WebClient ਦੀ ਵਰਤੋਂ ਕਰਕੇ):**

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

**Java ਲਾਗੂ ਕਰਨ ਦੇ ਨੋਟਸ:**
- Spring Boot ਦੀ reactive stack ਵਰਤਦਾ ਹੈ ਜਿਸ ਵਿੱਚ `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream` ਸ਼ਾਮਲ ਹਨ।
- ਸਧਾਰਣ ਸਟ੍ਰੀਮਿੰਗ ਲਈ ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਸੌਖਾ ਅਤੇ ਮੁੱਢਲੀ ਲੋੜਾਂ ਲਈ ਕਾਫ਼ੀ ਹੈ।
- ਜਟਿਲ, ਇੰਟਰਐਕਟਿਵ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ MCP ਸਟ੍ਰੀਮਿੰਗ ਇੱਕ ਢਾਂਚਾਬੱਧ ਤਰੀਕਾ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ ਜਿਸ ਵਿੱਚ ਨੋਟੀਫਿਕੇਸ਼ਨ ਅਤੇ ਅੰਤਿਮ ਨਤੀਜਿਆਂ ਵਿਚ ਵੱਖਰਾ ਫਰਕ ਹੁੰਦਾ ਹੈ।
- AI ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ MCP ਦਾ ਨੋਟੀਫਿਕੇਸ਼ਨ ਸਿਸਟਮ ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ ਕੰਮਾਂ ਲਈ ਬਹੁਤ ਲਾਭਦਾਇਕ ਹੈ।

## MCP ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ

ਠੀਕ ਹੈ, ਹੁਣ ਤੱਕ ਤੁਸੀਂ ਕਲਾਸਿਕ ਸਟ੍ਰੀਮਿੰਗ ਅਤੇ MCP ਸਟ੍ਰੀਮਿੰਗ ਵਿਚਕਾਰ ਕੁਝ ਸਿਫਾਰਸ਼ਾਂ ਅਤੇ ਤੁਲਨਾਵਾਂ ਵੇਖੀਆਂ ਹਨ। ਆਓ ਵੇਖੀਏ ਕਿ MCP ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ ਨੂੰ ਕਿਵੇਂ ਵਰਤਿਆ ਜਾ ਸਕਦਾ ਹੈ।

MCP ਫਰੇਮਵਰਕ ਦੇ ਅੰਦਰ ਸਟ੍ਰੀਮਿੰਗ ਕਿਵੇਂ ਕੰਮ ਕਰਦੀ ਹੈ, ਇਹ ਸਮਝਣਾ ਜ਼ਰੂਰੀ ਹੈ ਤਾਂ ਜੋ ਤੁਸੀਂ ਐਸੀਆਂ ਐਪਲੀਕੇਸ਼ਨਾਂ ਬਣਾ ਸਕੋ ਜੋ ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ ਕੰਮਾਂ ਦੌਰਾਨ ਯੂਜ਼ਰ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਫੀਡਬੈਕ ਦੇ ਸਕਣ।

MCP ਵਿੱਚ, ਸਟ੍ਰੀਮਿੰਗ ਦਾ ਮਤਲਬ ਮੁੱਖ ਜਵਾਬ ਨੂੰ ਹਿੱਸਿਆਂ ਵਿੱਚ ਭੇਜਣਾ ਨਹੀਂ ਹੈ, ਸਗੋਂ ਇਹ ਹੈ ਕਿ ਟੂਲ ਕਿਸੇ ਬੇਨਤੀ ਨੂੰ ਪ੍ਰਕਿਰਿਆ ਕਰਦੇ ਸਮੇਂ ਕਲਾਇੰਟ ਨੂੰ **ਨੋਟੀਫਿਕੇਸ਼ਨ** ਭੇਜੇ। ਇਹ ਨੋਟੀਫਿਕੇਸ਼ਨ ਪ੍ਰਗਟੀਕਰਨ ਅੱਪਡੇਟ, ਲੌਗ ਜਾਂ ਹੋਰ ਘਟਨਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ।

### ਕਿਵੇਂ ਕੰਮ ਕਰਦਾ ਹੈ

ਮੁੱਖ ਨਤੀਜਾ ਅਜੇ ਵੀ ਇੱਕੋ ਜਵਾਬ ਵਜੋਂ ਭੇਜਿਆ ਜਾਂਦਾ ਹੈ। ਹਾਲਾਂਕਿ, ਨੋਟੀਫਿਕੇਸ਼ਨ ਪ੍ਰਕਿਰਿਆ ਦੌਰਾਨ ਵੱਖ-ਵੱਖ ਸੁਨੇਹਿਆਂ ਵਜੋਂ ਭੇਜੇ ਜਾ ਸਕਦੇ ਹਨ, ਇਸ ਤਰ੍ਹਾਂ ਕਲਾਇੰਟ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਵਿੱਚ ਅੱਪਡੇਟ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ। ਕਲਾਇੰਟ ਨੂੰ ਇਹ ਨੋਟੀਫਿਕੇਸ਼ਨ ਸੰਭਾਲਣ ਅਤੇ ਦਿਖਾਉਣ ਯੋਗ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ।

## ਨੋਟੀਫਿਕੇਸ਼ਨ ਕੀ ਹੈ?

ਅਸੀਂ ਕਿਹਾ "ਨੋਟੀਫਿਕੇਸ਼ਨ", MCP ਦੇ ਸੰਦਰਭ ਵਿੱਚ ਇਸਦਾ ਕੀ ਮਤਲਬ ਹੈ?

ਨੋਟੀਫਿਕੇਸ਼ਨ ਇੱਕ ਸੁਨੇਹਾ ਹੈ ਜੋ ਸਰਵਰ ਵੱਲੋਂ ਕਲਾਇੰਟ ਨੂੰ ਭੇਜਿਆ ਜਾਂਦਾ ਹੈ ਤਾਂ ਜੋ ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ ਕੰਮ ਦੌਰਾਨ ਪ੍ਰਗਟੀਕਰਨ, ਸਥਿਤੀ ਜਾਂ ਹੋਰ ਘਟਨਾਵਾਂ ਬਾਰੇ ਜਾਣੂ ਕਰਵਾਇਆ ਜਾ ਸਕੇ। ਨੋਟੀਫਿਕੇਸ਼ਨ ਪਾਰਦਰਸ਼ਤਾ ਅਤੇ ਉਪਭੋਗਤਾ ਅਨੁਭਵ ਨੂੰ ਸੁਧਾਰਦੇ ਹਨ।

ਉਦਾਹਰਨ ਵਜੋਂ, ਜਦੋਂ ਕਲਾਇੰਟ ਸਰਵਰ ਨਾਲ ਮੁਲਾਕਾਤ ਕਰਦਾ ਹੈ, ਤਾਂ ਇੱਕ ਨੋਟੀਫਿਕੇਸ਼ਨ ਭੇਜਣੀ ਚਾਹੀਦੀ ਹੈ।

ਨੋਟੀਫਿਕੇਸ਼ਨ ਇੱਕ JSON ਸੁਨੇਹੇ ਵਾਂਗ ਇਸ ਤਰ੍ਹਾਂ ਦਿਸਦੀ ਹੈ:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

ਨੋਟੀਫਿਕੇਸ਼ਨ MCP ਵਿੱਚ ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) ਨਾਮਕ ਟਾਪਿਕ ਨਾਲ ਜੁੜੇ ਹੁੰਦੇ ਹਨ।

ਲੌਗਿੰਗ ਕੰਮ ਕਰਨ ਲਈ, ਸਰਵਰ ਨੂੰ ਇਸਨੂੰ ਇੱਕ ਫੀਚਰ/ਸਮਰੱਥਾ ਵਜੋਂ ਯੋਗ ਕਰਨਾ ਪੈਂਦਾ ਹੈ:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> ਵਰਤੇ ਗਏ SDK ਦੇ ਅਨੁਸਾਰ, ਲੌਗਿੰਗ ਡਿਫਾਲਟ ਰੂਪ ਵਿੱਚ ਯੋਗ ਹੋ ਸਕਦੀ ਹੈ ਜਾਂ ਤੁਹਾਨੂੰ ਆਪਣੇ ਸਰਵਰ ਕੰਫਿਗਰੇਸ਼ਨ ਵਿੱਚ ਇਸਨੂੰ ਖਾਸ ਤੌਰ 'ਤੇ ਯੋਗ ਕਰਨਾ ਪੈ ਸਕਦਾ ਹੈ।

ਨੋਟੀਫਿਕੇਸ਼ਨਾਂ ਦੇ ਵੱਖ-ਵੱਖ ਪ੍ਰਕਾਰ ਹਨ:

| ਪੱਧਰ      | ਵਰਣਨ                        | ਉਦਾਹਰਨ ਵਰਤੋਂ ਦਾ ਕੇਸ            |
|------------|-----------------------------|---------------------------------|
| debug      | ਵਿਸਥਾਰਪੂਰਵਕ ਡੀਬੱਗ ਜਾਣਕਾਰੀ | ਫੰਕਸ਼ਨ ਐਂਟਰੀ/ਐਗਜ਼ਿਟ ਪੁਆਇੰਟ     |
| info       | ਆਮ ਜਾਣਕਾਰੀ ਸੰਦੇਸ਼           | ਓਪਰੇਸ਼ਨ ਪ੍ਰਗਟੀਕਰਨ ਅੱਪਡੇਟ       |
| notice     | ਆਮ ਪਰ ਮਹੱਤਵਪੂਰਣ ਘਟਨਾਵਾਂ  | ਸੰਰਚਨਾ ਬਦਲਾਅ                   |
| warning    | ਚੇਤਾਵਨੀ ਸਥਿਤੀਆਂ            | ਪੁਰਾਣੇ ਫੀਚਰ ਦੀ ਵਰਤੋਂ            |
| error      | ਗਲਤੀ ਸਥਿਤੀਆਂ               | ਓਪਰੇਸ਼ਨ ਅਸਫਲਤਾ                 |
| critical   | ਗੰਭੀਰ ਸਥਿਤੀਆਂ             | ਸਿਸਟਮ ਕੰਪੋਨੈਂਟ ਫੇਲ੍ਹ            |
| alert      | ਤੁਰੰਤ ਕਾਰਵਾਈ ਲੋੜੀਂਦੀ ਹੈ    | ਡਾਟਾ ਕਰਪਸ਼ਨ ਪਤਾ ਲੱਗਿਆ          |
| emergency  | ਸਿਸਟਮ ਅਣਉਪਯੋਗ ਹੈ           | ਪੂਰਾ ਸਿਸਟਮ ਫੇਲ੍ਹ                |

## MCP ਵਿੱਚ ਨੋਟੀਫਿਕੇਸ਼ਨਾਂ ਨੂੰ ਲਾਗੂ ਕਰਨਾ

MCP ਵਿੱਚ ਨੋਟੀਫਿਕੇਸ਼ਨਾਂ ਨੂੰ ਲਾਗੂ ਕਰਨ ਲਈ, ਤੁਹਾਨੂੰ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਦੋਹਾਂ ਪਾਸਿਆਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟਸ ਸੰਭਾਲਣ ਲਈ ਤਿਆਰ ਕਰਨਾ ਪੈਂਦਾ ਹੈ। ਇਸ ਨਾਲ ਤੁਹਾਡੀ ਐਪਲੀਕੇਸ਼ਨ ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ ਕੰਮਾਂ ਦੌਰਾਨ ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਤੁਰੰਤ ਫੀਡਬੈਕ ਦੇ ਸਕਦੀ ਹੈ।

### ਸਰਵਰ-ਪਾਸਾ: ਨੋਟੀਫਿਕੇਸ਼ਨ ਭੇਜਣਾ

ਚਲੋ ਸਰਵਰ ਪਾਸੇ ਤੋਂ ਸ਼ੁਰੂ ਕਰੀਏ। MCP ਵਿੱਚ, ਤੁਸੀਂ ਟੂਲ ਪਰਿਭਾਸ਼ਿਤ ਕਰਦੇ ਹੋ ਜੋ ਬੇਨਤੀ ਦੀ ਪ੍ਰਕਿਰਿਆ ਦੌਰਾਨ ਨੋਟੀਫਿਕੇਸ਼ਨ ਭੇਜ ਸਕਦੇ ਹਨ। ਸਰਵਰ ਸੰਦੇਸ਼ ਭੇਜਣ ਲਈ context ਆਬਜੈਕਟ (ਆਮ ਤੌਰ 'ਤੇ `ctx`) ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ।

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

ਪਿਛਲੇ ਉਦਾਹਰਨ ਵਿੱਚ, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ਟਰਾਂਸਪੋਰਟ ਵਰਤਿਆ ਗਿਆ:

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

ਇਸ .NET ਉਦਾਹਰਨ ਵਿੱਚ, `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` ਮੈਥਡ ਜਾਣਕਾਰੀ ਸੰਦੇਸ਼ ਭੇਜਣ ਲਈ ਵਰਤੀ ਗਈ ਹੈ।

ਆਪਣੇ .NET MCP ਸਰਵਰ ਵਿੱਚ ਨੋਟੀਫਿਕੇਸ਼ਨ ਯੋਗ ਕਰਨ ਲਈ, ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਸੀਂ ਸਟ੍ਰੀਮਿੰਗ ਟਰਾਂਸਪੋਰਟ ਵਰਤ ਰਹੇ ਹੋ:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### ਕਲਾਇੰਟ-ਪਾਸਾ: ਨੋਟੀਫਿਕੇਸ਼ਨ ਪ੍ਰਾਪਤ ਕਰਨਾ

ਕਲਾਇੰਟ ਨੂੰ ਇੱਕ ਮੈਸੇਜ ਹੈਂਡਲਰ ਲਾਗੂ ਕਰਨਾ ਚਾਹੀਦਾ ਹੈ ਜੋ ਨੋਟੀਫਿਕੇਸ਼ਨਾਂ ਨੂੰ ਪ੍ਰਕਿਰਿਆ ਕਰਕੇ ਦਿਖਾ ਸਕੇ।

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

ਪਿਛਲੇ ਕੋਡ ਵਿੱਚ, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` ਨੋਟੀਫਿਕੇਸ਼ਨਾਂ ਨੂੰ ਸੰਭਾਲਣ ਲਈ ਵਰਤਿਆ ਗਿਆ।

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

ਇਸ .NET ਉਦਾਹਰਨ ਵਿੱਚ, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` ਵਰਤਿਆ ਗਿਆ ਹੈ ਅਤੇ ਤੁਹਾਡਾ ਕਲਾਇੰਟ ਨੋਟੀਫਿਕੇਸ਼ਨਾਂ ਨੂੰ ਪ੍ਰਕਿਰਿਆ ਕਰਨ ਲਈ ਮੈਸੇਜ ਹੈਂਡਲਰ ਲਾਗੂ ਕਰਦਾ ਹੈ।

## ਪ੍ਰਗਟੀਕਰਨ ਨੋਟੀਫਿਕੇਸ਼ਨ ਅਤੇ ਸਥਿਤੀਆਂ

ਇਹ ਭਾਗ MCP

**ਅਸਵੀਕਾਰੋक्ति**:  
ਇਹ ਦਸਤਾਵੇਜ਼ ਏਆਈ ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਥਿਰਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਣ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।