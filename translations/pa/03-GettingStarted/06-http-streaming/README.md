<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:39:59+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "pa"
}
-->
# HTTPS ਸਟ੍ਰੀਮਿੰਗ ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕਾਲ (MCP) ਨਾਲ

ਇਸ ਅਧਿਆਇ ਵਿੱਚ HTTPS ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕਾਲ (MCP) ਨਾਲ ਸੁਰੱਖਿਅਤ, ਸਕੇਲ ਕਰਨਯੋਗ ਅਤੇ ਰੀਅਲ-ਟਾਈਮ ਸਟ੍ਰੀਮਿੰਗ ਨੂੰ ਲਾਗੂ ਕਰਨ ਲਈ ਵਿਸਤ੍ਰਿਤ ਮਾਰਗਦਰਸ਼ਨ ਦਿੱਤਾ ਗਿਆ ਹੈ। ਇਹ ਸਟ੍ਰੀਮਿੰਗ ਲਈ ਪ੍ਰੇਰਣਾ, ਉਪਲਬਧ ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ, MCP ਵਿੱਚ ਸਟ੍ਰੀਮ ਕਰਨਯੋਗ HTTP ਕਿਵੇਂ ਲਾਗੂ ਕਰਨਾ ਹੈ, ਸੁਰੱਖਿਆ ਦੀਆਂ ਚੰਗੀਆਂ ਪ੍ਰਥਾਵਾਂ, SSE ਤੋਂ ਮਾਈਗ੍ਰੇਸ਼ਨ ਅਤੇ ਆਪਣੇ ਸਵੈੰ MCP ਸਟ੍ਰੀਮਿੰਗ ਐਪਲੀਕੇਸ਼ਨਾਂ ਬਣਾਉਣ ਲਈ ਪ੍ਰਯੋਗਿਕ ਮਾਰਗਦਰਸ਼ਨ ਨੂੰ ਕਵਰ ਕਰਦਾ ਹੈ।

## MCP ਵਿੱਚ ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ ਅਤੇ ਸਟ੍ਰੀਮਿੰਗ

ਇਸ ਭਾਗ ਵਿੱਚ MCP ਵਿੱਚ ਉਪਲਬਧ ਵੱਖ-ਵੱਖ ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ ਅਤੇ ਕਲਾਇੰਟਾਂ ਅਤੇ ਸਰਵਰਾਂ ਵਿਚਕਾਰ ਰੀਅਲ-ਟਾਈਮ ਸੰਚਾਰ ਲਈ ਸਟ੍ਰੀਮਿੰਗ ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਯੋਗ ਬਣਾਉਣ ਵਿੱਚ ਉਹਨਾਂ ਦੀ ਭੂਮਿਕਾ ਦੀ ਜਾਂਚ ਕੀਤੀ ਜਾਂਦੀ ਹੈ।

### ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ ਕੀ ਹੈ?

ਇੱਕ ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ ਇਹ ਪਰਿਭਾਸ਼ਿਤ ਕਰਦਾ ਹੈ ਕਿ ਕਿਵੇਂ ਡਾਟਾ ਕਲਾਇੰਟ ਅਤੇ ਸਰਵਰ ਵਿਚਕਾਰ ਅਦਲਾ-ਬਦਲੀ ਹੁੰਦਾ ਹੈ। MCP ਵੱਖ-ਵੱਖ ਵਾਤਾਵਰਣਾਂ ਅਤੇ ਜ਼ਰੂਰਤਾਂ ਲਈ ਕਈ ਟਰਾਂਸਪੋਰਟ ਕਿਸਮਾਂ ਨੂੰ ਸਹਾਰਦਾ ਹੈ:

- **stdio**: ਸਟੈਂਡਰਡ ਇਨਪੁੱਟ/ਆਉਟਪੁੱਟ, ਸਥਾਨਕ ਅਤੇ CLI-ਆਧਾਰਿਤ ਟੂਲਾਂ ਲਈ ਉਚਿਤ। ਸਧਾਰਣ ਪਰ ਵੈੱਬ ਜਾਂ ਕਲਾਉਡ ਲਈ ਉਚਿਤ ਨਹੀਂ।
- **SSE (Server-Sent Events)**: ਸਰਵਰਾਂ ਨੂੰ HTTP ਰਾਹੀਂ ਕਲਾਇੰਟਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ ਭੇਜਣ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਵੈੱਬ UI ਲਈ ਵਧੀਆ, ਪਰ ਸਕੇਲਬਿਲਟੀ ਅਤੇ ਲਚੀਲਾਪਣ ਵਿੱਚ ਸੀਮਤ।
- **Streamable HTTP**: ਆਧੁਨਿਕ HTTP-ਆਧਾਰਿਤ ਸਟ੍ਰੀਮਿੰਗ ਟਰਾਂਸਪੋਰਟ, ਸੂਚਨਾਵਾਂ ਅਤੇ ਵਧੀਆ ਸਕੇਲਬਿਲਟੀ ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ। ਜ਼ਿਆਦਾਤਰ ਪ੍ਰੋਡਕਸ਼ਨ ਅਤੇ ਕਲਾਉਡ ਸਥਿਤੀਆਂ ਲਈ ਸਿਫਾਰਸ਼ੀ।

### ਤੁਲਨਾਤਮਕ ਟੇਬਲ

ਹੇਠਾਂ ਦਿੱਤੇ ਤੁਲਨਾਤਮਕ ਟੇਬਲ ਨੂੰ ਦੇਖੋ ਤਾਂ ਜੋ ਇਹ ਸਮਝਿਆ ਜਾ ਸਕੇ ਕਿ ਇਹ ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ ਕਿਵੇਂ ਵੱਖਰੇ ਹਨ:

| ਟਰਾਂਸਪੋਰਟ       | ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ | ਸਟ੍ਰੀਮਿੰਗ | ਸਕੇਲਬਿਲਟੀ | ਉਪਯੋਗ ਕੇਸ              |
|------------------|--------------------|-----------|------------|-------------------------|
| stdio            | ਨਹੀਂ               | ਨਹੀਂ      | ਘੱਟ        | ਸਥਾਨਕ CLI ਟੂਲ          |
| SSE              | ਹਾਂ                | ਹਾਂ       | ਦਰਮਿਆਨਾ   | ਵੈੱਬ, ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ |
| Streamable HTTP  | ਹਾਂ                | ਹਾਂ       | ਉੱਚ        | ਕਲਾਉਡ, ਬਹੁ-ਕਲਾਇੰਟ      |

> **Tip:** ਸਹੀ ਟਰਾਂਸਪੋਰਟ ਚੁਣਨਾ ਪ੍ਰਦਰਸ਼ਨ, ਸਕੇਲਬਿਲਟੀ ਅਤੇ ਉਪਭੋਗਤਾ ਅਨੁਭਵ 'ਤੇ ਪ੍ਰਭਾਵ ਪਾਂਦਾ ਹੈ। **Streamable HTTP** ਆਧੁਨਿਕ, ਸਕੇਲ ਕਰਨਯੋਗ ਅਤੇ ਕਲਾਉਡ-ਤਿਆਰ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਸਿਫਾਰਸ਼ੀ ਹੈ।

ਪਿਛਲੇ ਅਧਿਆਇਆਂ ਵਿੱਚ ਦਿਖਾਏ ਗਏ stdio ਅਤੇ SSE ਟਰਾਂਸਪੋਰਟਾਂ ਨੂੰ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਅਤੇ ਇਸ ਅਧਿਆਇ ਵਿੱਚ ਕਵਰ ਕੀਤਾ ਗਿਆ Streamable HTTP ਟਰਾਂਸਪੋਰਟ ਕਿਵੇਂ ਹੈ।

## ਸਟ੍ਰੀਮਿੰਗ: ਧਾਰਨਾਵਾਂ ਅਤੇ ਪ੍ਰੇਰਣਾ

ਸਟ੍ਰੀਮਿੰਗ ਦੇ ਮੂਲ ਭਾਵ ਅਤੇ ਪ੍ਰੇਰਣਾਵਾਂ ਨੂੰ ਸਮਝਣਾ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਰੀਅਲ-ਟਾਈਮ ਸੰਚਾਰ ਪ੍ਰਣਾਲੀਆਂ ਬਣਾਉਣ ਲਈ ਜ਼ਰੂਰੀ ਹੈ।

**ਸਟ੍ਰੀਮਿੰਗ** ਨੈੱਟਵਰਕ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਵਿੱਚ ਇੱਕ ਤਕਨੀਕ ਹੈ ਜੋ ਡਾਟਾ ਨੂੰ ਛੋਟੇ, ਸੰਭਾਲਣਯੋਗ ਹਿੱਸਿਆਂ ਜਾਂ ਘਟਨਾਵਾਂ ਦੀ ਲੜੀ ਵਜੋਂ ਭੇਜਣ ਅਤੇ ਪ੍ਰਾਪਤ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦੀ ਹੈ, ਨਾ ਕਿ ਪੂਰੀ ਜਵਾਬ ਦੀ ਉਡੀਕ ਕਰਨ ਦੀ। ਇਹ ਖਾਸ ਕਰਕੇ ਲਾਭਦਾਇਕ ਹੈ:

- ਵੱਡੀਆਂ ਫਾਈਲਾਂ ਜਾਂ ਡਾਟਾਸੈੱਟ ਲਈ।
- ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ (ਜਿਵੇਂ ਕਿ ਚੈਟ, ਪ੍ਰਗਟੀ ਬਾਰ)।
- ਲੰਬੇ ਸਮੇਂ ਚੱਲ ਰਹੀਆਂ ਗਣਨਾਵਾਂ ਜਿੱਥੇ ਤੁਸੀਂ ਉਪਭੋਗਤਾ ਨੂੰ ਜਾਣੂ ਰੱਖਣਾ ਚਾਹੁੰਦੇ ਹੋ।

ਇੱਥੇ ਸਟ੍ਰੀਮਿੰਗ ਬਾਰੇ ਉੱਚ-ਸਤਰ ਦੀ ਜਾਣਕਾਰੀ ਹੈ:

- ਡਾਟਾ ਧੀਰੇ-ਧੀਰੇ ਪਹੁੰਚਾਇਆ ਜਾਂਦਾ ਹੈ, ਸਾਰਾ ਇਕੱਠਾ ਨਹੀਂ।
- ਕਲਾਇੰਟ ਡਾਟਾ ਆਉਣ ਤੇ ਤੁਰੰਤ ਪ੍ਰਕਿਰਿਆ ਕਰ ਸਕਦਾ ਹੈ।
- ਮਹਿਸੂਸ ਕੀਤੀ ਜਾ ਰਹੀ ਦੇਰੀ ਨੂੰ ਘਟਾਉਂਦਾ ਹੈ ਅਤੇ ਉਪਭੋਗਤਾ ਅਨੁਭਵ ਨੂੰ ਸੁਧਾਰਦਾ ਹੈ।

### ਸਟ੍ਰੀਮਿੰਗ ਕਿਉਂ ਵਰਤਣੀ?

ਸਟ੍ਰੀਮਿੰਗ ਵਰਤਣ ਦੇ ਕਾਰਨ ਹੇਠਾਂ ਦਿੱਤੇ ਹਨ:

- ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਤੁਰੰਤ ਫੀਡਬੈਕ ਮਿਲਦਾ ਹੈ, ਸਿਰਫ ਅੰਤ 'ਤੇ ਨਹੀਂ।
- ਰੀਅਲ-ਟਾਈਮ ਐਪਲੀਕੇਸ਼ਨਾਂ ਅਤੇ ਜਵਾਬਦਾਰ UI ਨੂੰ ਯੋਗ ਬਣਾਉਂਦਾ ਹੈ।
- ਨੈੱਟਵਰਕ ਅਤੇ ਕੰਪਿਊਟ ਸਰੋਤਾਂ ਦੀ ਜ਼ਿਆਦਾ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਵਰਤੋਂ।

### ਸਧਾਰਣ ਉਦਾਹਰਨ: HTTP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ

ਇੱਥੇ ਇੱਕ ਸਧਾਰਣ ਉਦਾਹਰਨ ਹੈ ਕਿ ਕਿਵੇਂ ਸਟ੍ਰੀਮਿੰਗ ਲਾਗੂ ਕੀਤੀ ਜਾ ਸਕਦੀ ਹੈ:

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

ਇਹ ਉਦਾਹਰਨ ਦਰਸਾਉਂਦੀ ਹੈ ਕਿ ਸਰਵਰ ਕਿਵੇਂ ਤਿਆਰ ਹੋਣ ਵਾਲੇ ਸੁਨੇਹਿਆਂ ਦੀ ਲੜੀ ਕਲਾਇੰਟ ਨੂੰ ਭੇਜਦਾ ਹੈ, ਨਾ ਕਿ ਸਾਰੇ ਸੁਨੇਹਿਆਂ ਦੇ ਤਿਆਰ ਹੋਣ ਦੀ ਉਡੀਕ ਕਰਦਾ ਹੈ।

**ਕਿਵੇਂ ਕੰਮ ਕਰਦਾ ਹੈ:**
- ਸਰਵਰ ਹਰ ਸੁਨੇਹਾ ਜਿਵੇਂ ਹੀ ਤਿਆਰ ਹੁੰਦਾ ਹੈ ਭੇਜਦਾ ਹੈ।
- ਕਲਾਇੰਟ ਹਰ ਹਿੱਸਾ ਪ੍ਰਾਪਤ ਕਰਕੇ ਪ੍ਰਿੰਟ ਕਰਦਾ ਹੈ।

**ਜ਼ਰੂਰਤਾਂ:**
- ਸਰਵਰ ਨੂੰ ਸਟ੍ਰੀਮਿੰਗ ਜਵਾਬ ਵਰਤਣਾ ਚਾਹੀਦਾ ਹੈ (ਜਿਵੇਂ `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) MCP ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ ਚੁਣਨ ਦੀ ਥਾਂ।

- **ਸਧਾਰਣ ਸਟ੍ਰੀਮਿੰਗ ਲਈ:** ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਲਾਗੂ ਕਰਨਾ ਆਸਾਨ ਅਤੇ ਬੁਨਿਆਦੀ ਜ਼ਰੂਰਤਾਂ ਲਈ ਕਾਫੀ ਹੈ।

- **ਜਟਿਲ, ਇੰਟਰਐਕਟਿਵ ਐਪ ਲਈ:** MCP ਸਟ੍ਰੀਮਿੰਗ ਵੱਧ ਸੰਗਠਿਤ ਪਹੁੰਚ ਦੇਂਦਾ ਹੈ ਜਿਸ ਵਿੱਚ ਅਮੀਰ ਮੈਟਾਡੇਟਾ ਅਤੇ ਸੂਚਨਾਵਾਂ ਅਤੇ ਅੰਤਿਮ ਨਤੀਜਿਆਂ ਵਿੱਚ ਵੱਖਰਾ ਕਰਨ ਦੀ ਸਮਰੱਥਾ ਹੁੰਦੀ ਹੈ।

- **AI ਐਪ ਲਈ:** MCP ਦੀ ਸੂਚਨਾ ਪ੍ਰਣਾਲੀ ਲੰਬੇ ਸਮੇਂ ਚੱਲ ਰਹੇ AI ਕੰਮਾਂ ਲਈ ਖਾਸ ਕਰਕੇ ਲਾਭਦਾਇਕ ਹੈ ਜਿੱਥੇ ਤੁਸੀਂ ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਪ੍ਰਗਟੀ ਬਾਰੇ ਜਾਣੂ ਰੱਖਣਾ ਚਾਹੁੰਦੇ ਹੋ।

## MCP ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ

ਠੀਕ ਹੈ, ਤੁਸੀਂ ਹੁਣ ਤੱਕ ਕੁਝ ਸਿਫਾਰਸ਼ਾਂ ਅਤੇ ਤੁਲਨਾਵਾਂ ਦੇਖੀਆਂ ਹਨ ਕਿ ਕਿਵੇਂ ਕਲਾਸਿਕ ਸਟ੍ਰੀਮਿੰਗ ਅਤੇ MCP ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ ਵਿੱਚ ਫਰਕ ਹੈ। ਆਓ ਵੇਖੀਏ ਕਿ ਤੁਸੀਂ MCP ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ ਕਿਵੇਂ ਵਰਤ ਸਕਦੇ ਹੋ।

MCP ਫਰੇਮਵਰਕ ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ ਕਿਵੇਂ ਕੰਮ ਕਰਦੀ ਹੈ ਇਹ ਸਮਝਣਾ ਜ਼ਰੂਰੀ ਹੈ ਤਾਂ ਜੋ ਤੁਸੀਂ ਜਵਾਬਦਾਰ ਐਪਲੀਕੇਸ਼ਨਾਂ ਬਣਾ ਸਕੋ ਜੋ ਲੰਬੇ ਸਮੇਂ ਚੱਲ ਰਹੇ ਕੰਮਾਂ ਦੌਰਾਨ ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਫੀਡਬੈਕ ਦੇ ਸਕਣ।

MCP ਵਿੱਚ, ਸਟ੍ਰੀਮਿੰਗ ਦਾ ਮਤਲਬ ਮੁੱਖ ਜਵਾਬ ਨੂੰ ਹਿੱਸਿਆਂ ਵਿੱਚ ਭੇਜਣਾ ਨਹੀਂ ਹੈ, ਪਰ ਇਸਦਾ ਮਤਲਬ ਹੈ ਕਿ ਟੂਲ ਜਦੋਂ ਕਿਸੇ ਬੇਨਤੀ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰ ਰਿਹਾ ਹੁੰਦਾ ਹੈ ਤਾਂ ਕਲਾਇੰਟ ਨੂੰ **ਸੂਚਨਾਵਾਂ** ਭੇਜਣਾ। ਇਹ ਸੂਚਨਾਵਾਂ ਵਿੱਚ ਪ੍ਰਗਟੀ ਅੱਪਡੇਟ, ਲੌਗ ਜਾਂ ਹੋਰ ਘਟਨਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ।

### ਇਹ ਕਿਵੇਂ ਕੰਮ ਕਰਦਾ ਹੈ

ਮੁੱਖ ਨਤੀਜਾ ਅਜੇ ਵੀ ਇਕੱਲੇ ਜਵਾਬ ਵਜੋਂ ਭੇਜਿਆ ਜਾਂਦਾ ਹੈ। ਪਰ, ਸੂਚਨਾਵਾਂ ਨੂੰ ਪ੍ਰੋਸੈਸਿੰਗ ਦੌਰਾਨ ਵੱਖਰੇ ਸੁਨੇਹਿਆਂ ਵਜੋਂ ਭੇਜਿਆ ਜਾ ਸਕਦਾ ਹੈ ਅਤੇ ਇਸ ਤਰ੍ਹਾਂ ਕਲਾਇੰਟ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ ਕਰਦਾ ਹੈ। ਕਲਾਇੰਟ ਨੂੰ ਇਹ ਸੂਚਨਾਵਾਂ ਸੰਭਾਲਣ ਅਤੇ ਦਿਖਾਉਣ ਯੋਗ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ।

## ਸੂਚਨਾ ਕੀ ਹੈ?

ਅਸੀਂ "ਸੂਚਨਾ" ਬਾਰੇ ਗੱਲ ਕੀਤੀ, MCP ਦੇ ਸੰਦਰਭ ਵਿੱਚ ਇਸਦਾ ਕੀ ਮਤਲਬ ਹੈ?

ਸੂਚਨਾ ਇੱਕ ਸੁਨੇਹਾ ਹੁੰਦਾ ਹੈ ਜੋ ਸਰਵਰ ਤੋਂ ਕਲਾਇੰਟ ਨੂੰ ਭੇਜਿਆ ਜਾਂਦਾ ਹੈ ਤਾਂ ਜੋ ਲੰਬੇ ਸਮੇਂ ਚੱਲ ਰਹੇ ਕੰਮ ਦੌਰਾਨ ਪ੍ਰਗਟੀ, ਸਥਿਤੀ ਜਾਂ ਹੋਰ ਘਟਨਾਵਾਂ ਬਾਰੇ ਜਾਣੂ ਕਰਾਇਆ ਜਾ ਸਕੇ। ਸੂਚਨਾਵਾਂ ਪਾਰਦਰਸ਼ਤਾ ਅਤੇ ਉਪਭੋਗਤਾ ਅਨੁਭਵ ਨੂੰ ਸੁਧਾਰਦੀਆਂ ਹਨ।

ਉਦਾਹਰਨ ਲਈ, ਇੱਕ ਕਲਾਇੰਟ ਨੂੰ ਸੂਚਨਾ ਭੇਜਣੀ ਚਾਹੀਦੀ ਹੈ ਜਦੋਂ ਸਰਵਰ ਨਾਲ ਸ਼ੁਰੂਆਤੀ ਹੱਥ ਮਿਲਾਉਣ (ਹੈਂਡਸ਼ੇਕ) ਮੁਕੰਮਲ ਹੋ ਜਾਵੇ।

ਇੱਕ ਸੂਚਨਾ JSON ਸੁਨੇਹੇ ਵਜੋਂ ਇਸ ਤਰ੍ਹਾਂ ਦਿਖਾਈ ਦਿੰਦੀ ਹੈ:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

ਸੂਚਨਾਵਾਂ MCP ਵਿੱਚ ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) ਨਾਮਕ ਵਿਸ਼ੇ ਨਾਲ ਸੰਬੰਧਿਤ ਹੁੰਦੀਆਂ ਹਨ।

ਲੌਗਿੰਗ ਨੂੰ ਕੰਮ ਕਰਨ ਲਈ, ਸਰਵਰ ਨੂੰ ਇਸਨੂੰ ਫੀਚਰ/ਸਮਰੱਥਾ ਵਜੋਂ ਐਨੇਬਲ ਕਰਨਾ ਪੈਂਦਾ ਹੈ:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> ਵਰਤੇ ਗਏ SDK 'ਤੇ ਨਿਰਭਰ ਕਰਦਾ ਹੈ ਕਿ ਲੌਗਿੰਗ ਡਿਫਾਲਟ ਰੂਪ ਵਿੱਚ ਐਨੇਬਲ ਹੋ ਸਕਦੀ ਹੈ, ਜਾਂ ਤੁਹਾਨੂੰ ਆਪਣੇ ਸਰਵਰ ਕੰਫਿਗਰੇਸ਼ਨ ਵਿੱਚ ਇਸਨੂੰ ਖੁਦ ਐਨੇਬਲ ਕਰਨਾ ਪੈ ਸਕਦਾ ਹੈ।

ਸੂਚਨਾਵਾਂ ਦੇ ਵੱਖ-ਵੱਖ ਕਿਸਮਾਂ ਹਨ:

| ਪੱਧਰ       | ਵਰਣਨ                         | ਉਦਾਹਰਨ ਵਰਤੋਂ ਕੇਸ           |
|------------|------------------------------|-----------------------------|
| debug      | ਵਿਸਥਾਰਪੂਰਕ ਡੀਬੱਗਿੰਗ ਜਾਣਕਾਰੀ | ਫੰਕਸ਼ਨ ਦੀ ਸ਼ੁਰੂਆਤ/ਖਤਮ     |
| info       | ਆਮ ਜਾਣਕਾਰੀ ਸੁਨੇਹੇ           | ਕਾਰਵਾਈ ਦੀ ਪ੍ਰਗਟੀ ਅੱਪਡੇਟ    |
| notice     | ਸਧਾਰਣ ਪਰ ਮਹੱਤਵਪੂਰਨ ਘਟਨਾਵਾਂ | ਸੰਰਚਨਾ ਬਦਲਾਅ              |
| warning    | ਚੇਤਾਵਨੀ ਸਥਿਤੀਆਂ            | ਪੁਰਾਣਾ ਹੋ ਚੁੱਕਾ ਫੀਚਰ ਵਰਤੋਂ |
| error      | ਗਲਤੀ ਸਥਿਤੀਆਂ               | ਕਾਰਵਾਈ ਵਿੱਚ ਅਸਫਲਤਾ        |
| critical   | ਗੰਭੀਰ ਸਥਿਤੀਆਂ              | ਸਿਸਟਮ ਕੰਪੋਨੈਂਟ ਦੀ ਅਸਫਲਤਾ  |
| alert      | ਤੁਰੰਤ ਕਾਰਵਾਈ ਲਾਜ਼ਮੀ         | ਡਾਟਾ ਕਰਪਸ਼ਨ ਪਤਾ ਲੱਗਣਾ     |
| emergency  | ਸਿਸਟਮ ਬੇਕਾਰ ਹੋ ਚੁੱਕਾ ਹੈ     | ਪੂਰਾ ਸਿਸਟਮ ਫੇਲ੍ਹ            |

## MCP ਵਿੱਚ ਸੂਚਨਾਵਾਂ ਲਾਗੂ ਕਰਨਾ

MCP ਵਿੱਚ ਸੂਚਨਾਵਾਂ ਲਾਗੂ ਕਰਨ ਲਈ, ਤੁਹਾਨੂੰ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਦੋਹਾਂ ਪਾਸਿਆਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ ਸੰਭਾਲਣ ਲਈ ਸੈੱਟ ਕਰਨਾ ਪੈਂਦਾ ਹੈ। ਇਸ ਨਾਲ ਤੁਹਾਡੀ ਐਪਲੀਕੇਸ਼ਨ ਲੰਬੇ ਸਮੇਂ ਚੱਲ ਰਹੇ ਕੰਮਾਂ ਦੌਰਾਨ ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਤੁਰੰਤ ਫੀਡਬੈਕ ਦੇ ਸਕਦੀ ਹੈ।

### ਸਰਵਰ-ਪਾਸਾ: ਸੂਚਨਾਵਾਂ ਭੇਜਣਾ

ਆਓ ਸਰਵਰ ਪਾਸੇ ਤੋਂ ਸ਼ੁਰੂ ਕਰੀਏ। MCP ਵਿੱਚ, ਤੁਸੀਂ ਟੂਲਾਂ ਨੂੰ ਪਰਿਭਾਸ਼ਿਤ ਕਰਦੇ ਹੋ ਜੋ ਬੇਨਤੀਆਂ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰਦੇ ਸਮੇਂ ਸੂਚਨਾਵਾਂ ਭੇਜ ਸਕਦੀਆਂ ਹਨ। ਸਰਵਰ ਸੰਦੇਸ਼ ਭੇਜਣ ਲਈ ਆਮ ਤੌਰ 'ਤੇ `ctx` ਕਾਂਟੈਕਸਟ ਓਬਜੈਕਟ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ।

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

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ਟਰਾਂਸਪੋਰਟ:

```python
mcp.run(transport="streamable-http")
```

</details>

### ਕਲਾਇੰਟ-ਪਾਸਾ: ਸੂਚਨਾਵਾਂ ਪ੍ਰਾਪਤ ਕਰਨਾ

ਕਲਾਇੰਟ ਨੂੰ ਇੱਕ ਮੈਸੇਜ ਹੈਂਡਲਰ ਲਾਗੂ ਕਰਨਾ ਚਾਹੀਦਾ ਹੈ ਜੋ ਆਉਂਦੀਆਂ ਸੂਚਨਾਵਾਂ ਨੂੰ ਪ੍ਰਕਿਰਿਆ ਕਰਦਾ ਅਤੇ ਦਿਖਾਉਂਦਾ ਹੈ।

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

ਪਿਛਲੇ ਕੋਡ ਵਿੱਚ, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) ਹੈ ਅਤੇ ਤੁਹਾਡਾ ਕਲਾਇੰਟ ਸੂਚਨਾਵਾਂ ਸੰਭਾਲਣ ਲਈ ਮੈਸੇਜ ਹੈਂਡਲਰ ਲਾਗੂ ਕਰਦਾ ਹੈ।

## ਪ੍ਰਗਟੀ ਸੂਚਨਾਵਾਂ ਅਤੇ ਸਥਿਤੀਆਂ

ਇਸ ਭਾਗ ਵਿੱਚ MCP ਵਿੱਚ ਪ੍ਰਗਟੀ ਸੂਚਨਾਵਾਂ ਦੀ ਸੰਕਲਪਨਾ, ਉਹ ਕਿਉਂ ਮਹੱਤਵਪੂਰਨ ਹਨ ਅਤੇ Streamable HTTP ਦੀ ਵਰਤੋਂ ਨਾਲ ਕਿਵੇਂ ਲਾਗੂ ਕੀਤੀਆਂ ਜਾਣ, ਦੀ ਵਿਆਖਿਆ ਕੀਤੀ ਗਈ ਹੈ। ਤੁਹਾਨੂੰ ਆਪਣੀ ਸਮਝ ਨੂੰ ਮਜ਼ਬੂਤ ਕਰਨ ਲਈ ਇੱਕ ਪ੍ਰਯੋਗਿਕ ਅਸਾਈਨਮੈਂਟ ਵੀ ਮਿਲੇਗਾ।

ਪ੍ਰਗਟੀ ਸੂਚਨਾਵਾਂ ਲੰਬੇ ਸਮੇਂ ਚੱਲ ਰਹੀਆਂ ਕਾਰਵਾਈਆਂ ਦੌਰਾਨ ਸਰਵਰ ਤੋਂ ਕਲਾਇੰਟ ਨੂੰ ਭੇਜੇ ਜਾਣ ਵਾਲੇ ਰੀਅਲ-ਟਾਈਮ ਸੁਨੇਹੇ ਹੁੰਦੇ ਹਨ। ਪੂਰੀ ਪ੍ਰਕਿਰਿਆ ਦੇ ਮੁਕੰਮਲ ਹੋਣ ਦੀ ਉਡੀਕ ਕਰਨ ਦੀ ਥਾਂ, ਸਰਵਰ ਕਲਾਇੰਟ ਨੂੰ ਮੌਜੂਦਾ ਸਥਿਤੀ ਬਾਰੇ ਅੱਪਡੇਟ ਰੱਖਦਾ ਹੈ। ਇਸ ਨਾਲ ਪਾਰਦਰਸ਼ਤਾ, ਉਪਭੋਗਤਾ ਅਨੁਭਵ ਸੁਧਰਦਾ ਹੈ ਅਤੇ ਡੀਬੱਗਿੰਗ ਆਸਾਨ ਹੁੰਦੀ ਹੈ।

**ਉਦਾਹਰਨ:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### ਪ੍ਰਗਟੀ ਸੂਚ

**ਅਸਵੀਕਾਰੋਧ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਣਸਹੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫ਼ਾਰਿਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉੱਪਜਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।