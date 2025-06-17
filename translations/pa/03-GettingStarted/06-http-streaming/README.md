<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:06:07+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "pa"
}
-->
# HTTPS ਸਟ੍ਰੀਮਿੰਗ ਵਿਥ ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕੋਲ (MCP)

ਇਸ ਅਧਿਆਇ ਵਿੱਚ HTTPS ਦੀ ਵਰਤੋਂ ਨਾਲ ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕੋਲ (MCP) ਦੇ ਜ਼ਰੀਏ ਸੁਰੱਖਿਅਤ, ਸਕੇਲਏਬਲ ਅਤੇ ਰੀਅਲ-ਟਾਈਮ ਸਟ੍ਰੀਮਿੰਗ ਨੂੰ ਲਾਗੂ ਕਰਨ ਲਈ ਇੱਕ ਵਿਸਥਾਰਤ ਮਾਰਗਦਰਸ਼ਨ ਦਿੱਤਾ ਗਿਆ ਹੈ। ਇਹ ਸਟ੍ਰੀਮਿੰਗ ਦੀ ਪ੍ਰੇਰਣਾ, ਉਪਲਬਧ ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ, MCP ਵਿੱਚ ਸਟ੍ਰੀਮੇਬਲ HTTP ਨੂੰ ਕਿਵੇਂ ਲਾਗੂ ਕਰਨਾ ਹੈ, ਸੁਰੱਖਿਆ ਦੇ ਸਭ ਤੋਂ ਵਧੀਆ ਤਰੀਕੇ, SSE ਤੋਂ ਮਾਈਗ੍ਰੇਸ਼ਨ ਅਤੇ ਆਪਣੇ ਸਟ੍ਰੀਮਿੰਗ MCP ਐਪਲੀਕੇਸ਼ਨ ਬਣਾਉਣ ਲਈ ਵਿਹਾਰਕ ਮਾਰਗਦਰਸ਼ਨ ਨੂੰ ਕਵਰ ਕਰਦਾ ਹੈ।

## MCP ਵਿੱਚ ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ ਅਤੇ ਸਟ੍ਰੀਮਿੰਗ

ਇਸ ਭਾਗ ਵਿੱਚ MCP ਵਿੱਚ ਉਪਲਬਧ ਵੱਖ-ਵੱਖ ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ ਅਤੇ ਇਹ ਕਿਵੇਂ ਕਲਾਇੰਟ ਅਤੇ ਸਰਵਰ ਦਰਮਿਆਨ ਰੀਅਲ-ਟਾਈਮ ਸੰਚਾਰ ਲਈ ਸਟ੍ਰੀਮਿੰਗ ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਯੋਗ ਬਣਾਉਂਦੇ ਹਨ, ਦੀ ਜਾਂਚ ਕੀਤੀ ਗਈ ਹੈ।

### ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ ਕੀ ਹੈ?

ਟ੍ਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮ ਇਹ ਦਰਸਾਉਂਦਾ ਹੈ ਕਿ ਡੇਟਾ ਕਲਾਇੰਟ ਅਤੇ ਸਰਵਰ ਵਿਚਕਾਰ ਕਿਵੇਂ ਵਟਾਇਆ ਜਾਂਦਾ ਹੈ। MCP ਵੱਖ-ਵੱਖ ਵਾਤਾਵਰਣਾਂ ਅਤੇ ਲੋੜਾਂ ਲਈ ਕਈ ਟਰਾਂਸਪੋਰਟ ਕਿਸਮਾਂ ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ:

- **stdio**: ਸਟੈਂਡਰਡ ਇਨਪੁਟ/ਆਉਟਪੁਟ, ਲੋਕਲ ਅਤੇ CLI ਆਧਾਰਿਤ ਟੂਲਾਂ ਲਈ ਉਚਿਤ। ਸਧਾਰਣ ਪਰ ਵੈੱਬ ਜਾਂ ਕਲਾਉਡ ਲਈ ਢੁਕਵਾਂ ਨਹੀਂ।
- **SSE (ਸਰਵਰ-ਸੈਂਟ ਇਵੈਂਟਸ)**: ਸਰਵਰ HTTP ਰਾਹੀਂ ਕਲਾਇੰਟਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ ਭੇਜ ਸਕਦਾ ਹੈ। ਵੈੱਬ UI ਲਈ ਚੰਗਾ, ਪਰ ਸਕੇਲਏਬਿਲਟੀ ਅਤੇ ਲਚਕੀਲਾਪਣ ਵਿੱਚ ਸੀਮਿਤ।
- **Streamable HTTP**: ਆਧੁਨਿਕ HTTP-ਅਧਾਰਿਤ ਸਟ੍ਰੀਮਿੰਗ ਟਰਾਂਸਪੋਰਟ, ਸੂਚਨਾਵਾਂ ਅਤੇ ਬਿਹਤਰ ਸਕੇਲਏਬਿਲਟੀ ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ। ਜ਼ਿਆਦਾਤਰ ਉਤਪਾਦਨ ਅਤੇ ਕਲਾਉਡ ਸਥਿਤੀਆਂ ਲਈ ਸਿਫਾਰਸ਼ੀ।

### ਤੁਲਨਾਤਮਕ ਟੇਬਲ

ਹੇਠਾਂ ਦਿੱਤੇ ਟੇਬਲ ਵਿੱਚ ਇਹਨਾਂ ਟਰਾਂਸਪੋਰਟ ਮਕੈਨਿਜ਼ਮਾਂ ਵਿੱਚ ਫਰਕ ਸਮਝੋ:

| ਟਰਾਂਸਪੋਰਟ       | ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟਸ | ਸਟ੍ਰੀਮਿੰਗ | ਸਕੇਲਏਬਿਲਟੀ | ਵਰਤੋਂ ਦਾ ਮਾਮਲਾ         |
|------------------|---------------------|-----------|--------------|-------------------------|
| stdio            | ਨਹੀਂ                | ਨਹੀਂ      | ਘੱਟ         | ਲੋਕਲ CLI ਟੂਲ            |
| SSE              | ਹਾਂ                 | ਹਾਂ       | ਦਰਮਿਆਨਾ    | ਵੈੱਬ, ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟਸ |
| Streamable HTTP  | ਹਾਂ                 | ਹਾਂ       | ਉੱਚ         | ਕਲਾਉਡ, ਮਲਟੀ-ਕਲਾਇੰਟ     |

> **Tip:** ਸਹੀ ਟਰਾਂਸਪੋਰਟ ਚੁਣਨਾ ਪ੍ਰਦਰਸ਼ਨ, ਸਕੇਲਏਬਿਲਟੀ ਅਤੇ ਉਪਭੋਗਤਾ ਅਨੁਭਵ 'ਤੇ ਪ੍ਰਭਾਵ ਪਾਉਂਦਾ ਹੈ। ਆਧੁਨਿਕ, ਸਕੇਲਏਬਲ ਅਤੇ ਕਲਾਉਡ-ਤਿਆਰ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ **Streamable HTTP** ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ।

ਪਿਛਲੇ ਅਧਿਆਇਆਂ ਵਿੱਚ ਤੁਹਾਨੂੰ ਦਿਖਾਏ ਗਏ stdio ਅਤੇ SSE ਟਰਾਂਸਪੋਰਟਾਂ ਨੂੰ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਅਤੇ ਇਸ ਅਧਿਆਇ ਵਿੱਚ ਕਵਰ ਕੀਤਾ ਗਿਆ Streamable HTTP ਟਰਾਂਸਪੋਰਟ ਹੈ।

## ਸਟ੍ਰੀਮਿੰਗ: ਧਾਰਣਾਵਾਂ ਅਤੇ ਪ੍ਰੇਰਣਾ

ਸਮਝਣਾ ਕਿ ਸਟ੍ਰੀਮਿੰਗ ਦੇ ਮੁਢਲੀ ਧਾਰਣਾਵਾਂ ਅਤੇ ਪ੍ਰੇਰਣਾ ਕੀ ਹਨ, ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਰੀਅਲ-ਟਾਈਮ ਸੰਚਾਰ ਪ੍ਰਣਾਲੀਆਂ ਬਣਾਉਣ ਲਈ ਜਰੂਰੀ ਹੈ।

**ਸਟ੍ਰੀਮਿੰਗ** ਇੱਕ ਨੈੱਟਵਰਕ ਪ੍ਰੋਗ੍ਰਾਮਿੰਗ ਤਕਨੀਕ ਹੈ ਜੋ ਡੇਟਾ ਨੂੰ ਛੋਟੇ, ਸੰਭਾਲਣਯੋਗ ਹਿੱਸਿਆਂ ਜਾਂ ਘਟਨਾਵਾਂ ਦੀ ਲੜੀ ਵਜੋਂ ਭੇਜਣ ਅਤੇ ਪ੍ਰਾਪਤ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦੀ ਹੈ, ਬਜਾਏ ਪੂਰੇ ਜਵਾਬ ਦੀ ਉਡੀਕ ਕਰਨ ਦੇ। ਇਹ ਖਾਸ ਕਰਕੇ ਇਹਨਾਂ ਲਈ ਲਾਭਦਾਇਕ ਹੈ:

- ਵੱਡੀਆਂ ਫਾਈਲਾਂ ਜਾਂ ਡੇਟਾਸੈਟਸ।
- ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟਸ (ਜਿਵੇਂ ਚੈਟ, ਪ੍ਰੋਗਰੈਸ ਬਾਰ)।
- ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੀਆਂ ਗਣਨਾਵਾਂ ਜਿੱਥੇ ਤੁਸੀਂ ਉਪਭੋਗਤਾ ਨੂੰ ਜਾਣੂ ਕਰਵਾਉਣਾ ਚਾਹੁੰਦੇ ਹੋ।

ਇੱਥੇ ਸਟ੍ਰੀਮਿੰਗ ਬਾਰੇ ਕੁਝ ਮੁੱਖ ਗੱਲਾਂ ਹਨ:

- ਡੇਟਾ ਕ੍ਰਮਬੱਧ ਤਰੀਕੇ ਨਾਲ ਦਿੱਤਾ ਜਾਂਦਾ ਹੈ, ਸਾਰਾ ਇਕੱਠਾ ਨਹੀਂ।
- ਕਲਾਇੰਟ ਆਉਣ ਵਾਲਾ ਡੇਟਾ ਤੁਰੰਤ ਪ੍ਰੋਸੈਸ ਕਰ ਸਕਦਾ ਹੈ।
- ਪ੍ਰਤੀਤ ਹੋਣ ਵਾਲੀ ਲੈਟੈਂਸੀ ਘਟਾਉਂਦਾ ਹੈ ਅਤੇ ਉਪਭੋਗਤਾ ਅਨੁਭਵ ਸੁਧਾਰਦਾ ਹੈ।

### ਸਟ੍ਰੀਮਿੰਗ ਕਿਉਂ ਵਰਤਣੀ ਹੈ?

ਸਟ੍ਰੀਮਿੰਗ ਵਰਤਣ ਦੇ ਕਾਰਨ ਹਨ:

- ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਤੁਰੰਤ ਫੀਡਬੈਕ ਮਿਲਦਾ ਹੈ, ਸਿਰਫ ਅੰਤ ਵਿੱਚ ਨਹੀਂ
- ਰੀਅਲ-ਟਾਈਮ ਐਪਲੀਕੇਸ਼ਨਾਂ ਅਤੇ ਜਵਾਬਦੇਹ UI ਨੂੰ ਯੋਗ ਬਣਾਉਂਦਾ ਹੈ
- ਨੈੱਟਵਰਕ ਅਤੇ ਕੰਪਿਊਟ ਸਰੋਤਾਂ ਦੀ ਜ਼ਿਆਦਾ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਵਰਤੋਂ

### ਸਧਾਰਣ ਉਦਾਹਰਨ: HTTP ਸਟ੍ਰੀਮਿੰਗ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ

ਇੱਥੇ ਇੱਕ ਸਧਾਰਣ ਉਦਾਹਰਨ ਹੈ ਕਿ ਸਟ੍ਰੀਮਿੰਗ ਕਿਵੇਂ ਲਾਗੂ ਕੀਤੀ ਜਾ ਸਕਦੀ ਹੈ:

<details>
<summary>Python</summary>

**ਸਰਵਰ (Python, FastAPI ਅਤੇ StreamingResponse ਵਰਤ ਕੇ):**
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

**ਕਲਾਇੰਟ (Python, requests ਵਰਤ ਕੇ):**
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

ਇਹ ਉਦਾਹਰਨ ਦਰਸਾਉਂਦੀ ਹੈ ਕਿ ਸਰਵਰ ਕਿਵੇਂ ਕਲਾਇੰਟ ਨੂੰ ਸੁਨੇਹਿਆਂ ਦੀ ਲੜੀ ਭੇਜਦਾ ਹੈ ਜਿਵੇਂ ਜਿਵੇਂ ਉਹ ਉਪਲਬਧ ਹੁੰਦੇ ਹਨ, ਬਜਾਏ ਸਾਰਿਆਂ ਸੁਨੇਹਿਆਂ ਦੀ ਤਿਆਰੀ ਦੀ ਉਡੀਕ ਕਰਨ ਦੇ।

**ਕਿਵੇਂ ਕੰਮ ਕਰਦਾ ਹੈ:**
- ਸਰਵਰ ਹਰ ਸੁਨੇਹਾ ਤਿਆਰ ਹੋਣ 'ਤੇ ਭੇਜਦਾ ਹੈ।
- ਕਲਾਇੰਟ ਆਉਣ ਵਾਲੇ ਹਰ ਹਿੱਸੇ ਨੂੰ ਪ੍ਰਾਪਤ ਕਰਕੇ ਪ੍ਰਿੰਟ ਕਰਦਾ ਹੈ।

**ਲੋੜਾਂ:**
- ਸਰਵਰ ਨੂੰ ਸਟ੍ਰੀਮਿੰਗ ਰਿਸਪਾਂਸ ਵਰਤਣੀ ਚਾਹੀਦੀ ਹੈ (ਜਿਵੇਂ `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) MCP ਰਾਹੀਂ ਸਟ੍ਰੀਮਿੰਗ ਚੁਣਨ ਦੀ ਥਾਂ।

- **ਸਧਾਰਣ ਸਟ੍ਰੀਮਿੰਗ ਲਈ:** ਕਲਾਸਿਕ HTTP ਸਟ੍ਰੀਮਿੰਗ ਲਾਗੂ ਕਰਨਾ ਆਸਾਨ ਹੈ ਅਤੇ ਬੁਨਿਆਦੀ ਲੋੜਾਂ ਲਈ ਕਾਫ਼ੀ ਹੈ।

- **ਜਟਿਲ, ਇੰਟਰਐਕਟਿਵ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ:** MCP ਸਟ੍ਰੀਮਿੰਗ ਇੱਕ ਬਿਹਤਰ ਸੰਰਚਿਤ ਤਰੀਕਾ ਦਿੰਦਾ ਹੈ ਜਿਸ ਵਿੱਚ ਧਨਾਢ ਮੈਟਾਡੇਟਾ ਅਤੇ ਸੂਚਨਾਵਾਂ ਅਤੇ ਅੰਤਿਮ ਨਤੀਜਿਆਂ ਵਿਚਕਾਰ ਵੱਖਰਾ ਪੱਖ ਹੈ।

- **AI ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ:** MCP ਦੀ ਸੂਚਨਾ ਪ੍ਰਣਾਲੀ ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ AI ਕੰਮਾਂ ਲਈ ਖਾਸ ਤੌਰ 'ਤੇ ਲਾਭਦਾਇਕ ਹੈ ਜਿੱਥੇ ਤੁਸੀਂ ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਪ੍ਰਗਤੀ ਦੀ ਜਾਣਕਾਰੀ ਦੇਣਾ ਚਾਹੁੰਦੇ ਹੋ।

## MCP ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ

ਠੀਕ ਹੈ, ਤਾਂ ਹੁਣ ਤੱਕ ਤੁਸੀਂ ਕਲਾਸਿਕ ਸਟ੍ਰੀਮਿੰਗ ਅਤੇ MCP ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ ਦੇ ਵਿਚਕਾਰ ਕੁਝ ਸਿਫਾਰਸ਼ਾਂ ਅਤੇ ਤੁਲਨਾਵਾਂ ਦੇਖੀਆਂ ਹਨ। ਆਓ ਵੇਖੀਏ ਕਿ ਤੁਸੀਂ MCP ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ ਨੂੰ ਕਿਵੇਂ ਵਰਤ ਸਕਦੇ ਹੋ।

MCP ਫਰੇਮਵਰਕ ਵਿੱਚ ਸਟ੍ਰੀਮਿੰਗ ਕਿਵੇਂ ਕੰਮ ਕਰਦੀ ਹੈ, ਇਹ ਸਮਝਣਾ ਜਰੂਰੀ ਹੈ ਤਾਂ ਜੋ ਤੁਸੀਂ ਉਹ ਐਪਲੀਕੇਸ਼ਨ ਬਣਾ ਸਕੋ ਜੋ ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ ਕੰਮਾਂ ਦੌਰਾਨ ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਫੀਡਬੈਕ ਦੇਣ।

MCP ਵਿੱਚ, ਸਟ੍ਰੀਮਿੰਗ ਦਾ ਮਤਲਬ ਮੁੱਖ ਜਵਾਬ ਨੂੰ ਹਿੱਸਿਆਂ ਵਿੱਚ ਭੇਜਣਾ ਨਹੀਂ ਹੈ, ਬਲਕਿ ਜਦੋਂ ਕੋਈ ਟੂਲ ਬੇਨਤੀ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰ ਰਿਹਾ ਹੁੰਦਾ ਹੈ, ਤਦ ਕਲਾਇੰਟ ਨੂੰ **ਸੂਚਨਾਵਾਂ** ਭੇਜਣਾ ਹੁੰਦਾ ਹੈ। ਇਹ ਸੂਚਨਾਵਾਂ ਪ੍ਰਗਤੀ ਅੱਪਡੇਟ, ਲੌਗ ਜਾਂ ਹੋਰ ਘਟਨਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ।

### ਇਹ ਕਿਵੇਂ ਕੰਮ ਕਰਦਾ ਹੈ

ਮੁੱਖ ਨਤੀਜਾ ਅਜੇ ਵੀ ਇਕੱਲਾ ਜਵਾਬ ਵਜੋਂ ਭੇਜਿਆ ਜਾਂਦਾ ਹੈ। ਪਰ, ਸੂਚਨਾਵਾਂ ਨੂੰ ਪ੍ਰੋਸੈਸਿੰਗ ਦੌਰਾਨ ਵੱਖਰੇ ਸੁਨੇਹਿਆਂ ਵਜੋਂ ਭੇਜਿਆ ਜਾ ਸਕਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਕਲਾਇੰਟ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਵਿੱਚ ਅੱਪਡੇਟ ਕੀਤਾ ਜਾ ਸਕਦਾ ਹੈ। ਕਲਾਇੰਟ ਨੂੰ ਇਹ ਸੂਚਨਾਵਾਂ ਪ੍ਰੋਸੈਸ ਅਤੇ ਪ੍ਰਦਰਸ਼ਿਤ ਕਰਨ ਯੋਗ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ।

## ਸੂਚਨਾ ਕੀ ਹੈ?

ਅਸੀਂ "ਸੂਚਨਾ" ਬਾਰੇ ਕਿਹਾ, ਤਾਂ MCP ਦੇ ਸੰਦਰਭ ਵਿੱਚ ਇਸਦਾ ਕੀ ਮਤਲਬ ਹੈ?

ਸੂਚਨਾ ਇੱਕ ਸੁਨੇਹਾ ਹੈ ਜੋ ਸਰਵਰ ਵੱਲੋਂ ਕਲਾਇੰਟ ਨੂੰ ਭੇਜਿਆ ਜਾਂਦਾ ਹੈ ਤਾਂ ਜੋ ਲੰਬੇ ਸਮੇਂ ਚੱਲ ਰਹੇ ਕੰਮ ਦੌਰਾਨ ਪ੍ਰਗਤੀ, ਸਥਿਤੀ ਜਾਂ ਹੋਰ ਘਟਨਾਵਾਂ ਬਾਰੇ ਜਾਣੂ ਕਰਵਾਇਆ ਜਾ ਸਕੇ। ਸੂਚਨਾਵਾਂ ਪਾਰਦਰਸ਼ਤਾ ਅਤੇ ਉਪਭੋਗਤਾ ਅਨੁਭਵ ਨੂੰ ਸੁਧਾਰਦੀਆਂ ਹਨ।

ਉਦਾਹਰਨ ਵਜੋਂ, ਜਦ ਕਲਾਇੰਟ ਨੇ ਸਰਵਰ ਨਾਲ ਸ਼ੁਰੂਆਤੀ ਹੈਂਡਸ਼ੇਕ ਕਰ ਲਿਆ ਹੋਵੇ, ਤਾਂ ਉਸਨੂੰ ਇੱਕ ਸੂਚਨਾ ਭੇਜਣੀ ਚਾਹੀਦੀ ਹੈ।

ਸੂਚਨਾ ਇਸ ਤਰ੍ਹਾਂ JSON ਸੁਨੇਹੇ ਵਾਂਗ ਦਿਖਾਈ ਦਿੰਦੀ ਹੈ:

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

ਲੌਗਿੰਗ ਨੂੰ ਕੰਮ ਕਰਨ ਲਈ, ਸਰਵਰ ਨੂੰ ਇਸਨੂੰ ਫੀਚਰ/ਸਮਰੱਥਾ ਵਜੋਂ ਚਾਲੂ ਕਰਨਾ ਪੈਂਦਾ ਹੈ:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> ਵਰਤੇ ਗਏ SDK ਦੇ ਅਨੁਸਾਰ, ਲੌਗਿੰਗ ਡਿਫਾਲਟ ਤੌਰ 'ਤੇ ਚਾਲੂ ਹੋ ਸਕਦੀ ਹੈ, ਜਾਂ ਤੁਹਾਨੂੰ ਆਪਣੇ ਸਰਵਰ ਕਨਫਿਗਰੇਸ਼ਨ ਵਿੱਚ ਇਸਨੂੰ ਖੁਦ ਚਾਲੂ ਕਰਨਾ ਪੈ ਸਕਦਾ ਹੈ।

ਵੱਖ-ਵੱਖ ਕਿਸਮ ਦੀਆਂ ਸੂਚਨਾਵਾਂ ਹਨ:

| ਪੱਧਰ       | ਵਰਣਨ                           | ਉਦਾਹਰਨ ਵਰਤੋਂ ਦਾ ਮਾਮਲਾ           |
|-------------|--------------------------------|----------------------------------|
| debug       | ਵਿਸਥਾਰਪੂਰਵਕ ਡੀਬੱਗਿੰਗ ਜਾਣਕਾਰੀ | ਫੰਕਸ਼ਨ ਦੇ ਐਂਟਰੀ/ਐਕਜ਼ਿਟ ਪੌਇੰਟ    |
| info        | ਆਮ ਜਾਣਕਾਰੀ ਸੁਨੇਹੇ             | ਓਪਰੇਸ਼ਨ ਦੀ ਪ੍ਰਗਤੀ ਅੱਪਡੇਟ          |
| notice      | ਆਮ ਪਰ ਮਹੱਤਵਪੂਰਨ ਘਟਨਾਵਾਂ     | ਸੰਰਚਨਾ ਵਿੱਚ ਬਦਲਾਅ                |
| warning     | ਚੇਤਾਵਨੀ ਸਥਿਤੀਆਂ              | ਡੀਪ੍ਰੀਕੇਟ ਕੀਤੀ ਵਿਸ਼ੇਸ਼ਤਾ ਦੀ ਵਰਤੋਂ |
| error       | ਗਲਤੀ ਸਥਿਤੀਆਂ                 | ਓਪਰੇਸ਼ਨ ਅਸਫਲਤਾਵਾਂ               |
| critical    | ਗੰਭੀਰ ਸਥਿਤੀਆਂ               | ਸਿਸਟਮ ਕੰਪੋਨੈਂਟ ਦੀਆਂ ਅਸਫਲਤਾਵਾਂ   |
| alert       | ਤੁਰੰਤ ਕਾਰਵਾਈ ਲਾਜ਼ਮੀ          | ਡੇਟਾ ਕਰਪਸ਼ਨ ਦਾ ਪਤਾ ਲੱਗਣਾ         |
| emergency   | ਸਿਸਟਮ ਬੇਕਾਰ ਹੋ ਗਿਆ ਹੈ         | ਪੂਰਾ ਸਿਸਟਮ ਫੇਲ                  |

## MCP ਵਿੱਚ ਸੂਚਨਾਵਾਂ ਲਾਗੂ ਕਰਨਾ

MCP ਵਿੱਚ ਸੂਚਨਾਵਾਂ ਲਾਗੂ ਕਰਨ ਲਈ, ਤੁਹਾਨੂੰ ਸਰਵਰ ਅਤੇ ਕਲਾਇੰਟ ਦੋਹਾਂ ਪਾਸਿਆਂ ਨੂੰ ਰੀਅਲ-ਟਾਈਮ ਅੱਪਡੇਟ ਸੰਭਾਲਣ ਲਈ ਤਿਆਰ ਕਰਨਾ ਪੈਂਦਾ ਹੈ। ਇਸ ਨਾਲ ਤੁਹਾਡੀ ਐਪਲੀਕੇਸ਼ਨ ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ ਕੰਮਾਂ ਦੌਰਾਨ ਉਪਭੋਗਤਾਵਾਂ ਨੂੰ ਤੁਰੰਤ ਫੀਡਬੈਕ ਦੇ ਸਕਦੀ ਹੈ।

### ਸਰਵਰ-ਪਾਸਾ: ਸੂਚਨਾਵਾਂ ਭੇਜਣਾ

ਆਓ ਸਰਵਰ ਪਾਸੇ ਨਾਲ ਸ਼ੁਰੂ ਕਰੀਏ। MCP ਵਿੱਚ, ਤੁਸੀਂ ਟੂਲ ਪਰਿਭਾਸ਼ਿਤ ਕਰਦੇ ਹੋ ਜੋ ਬੇਨਤੀਆਂ ਨੂੰ ਪ੍ਰੋਸੈਸ ਕਰਦੇ ਸਮੇਂ ਸੂਚਨਾਵਾਂ ਭੇਜ ਸਕਦੇ ਹਨ। ਸਰਵਰ ਸੰਦਰਭ ਆਬਜੈਕਟ (ਆਮ ਤੌਰ 'ਤੇ `ctx`) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਕਲਾਇੰਟ ਨੂੰ ਸੁਨੇਹੇ ਭੇਜਦਾ ਹੈ।

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

ਉਪਰੋਕਤ ਉਦਾਹਰਨ ਵਿੱਚ, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ਟਰਾਂਸਪੋਰਟ ਵਰਤਿਆ ਗਿਆ ਹੈ:

```python
mcp.run(transport="streamable-http")
```

</details>

### ਕਲਾਇੰਟ-ਪਾਸਾ: ਸੂਚਨਾਵਾਂ ਪ੍ਰਾਪਤ ਕਰਨਾ

ਕਲਾਇੰਟ ਨੂੰ ਇੱਕ ਸੁਨੇਹਾ ਹੈਂਡਲਰ ਲਾਗੂ ਕਰਨਾ ਚਾਹੀਦਾ ਹੈ ਜੋ ਆਉਣ ਵਾਲੀਆਂ ਸੂਚਨਾਵਾਂ ਨੂੰ ਪ੍ਰੋਸੈਸ ਅਤੇ ਪ੍ਰਦਰਸ਼ਿਤ ਕਰਦਾ ਹੈ।

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

ਉਪਰੋਕਤ ਕੋਡ ਵਿੱਚ, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) ਵਰਤ ਕੇ ਤੁਹਾਡਾ ਕਲਾਇੰਟ ਸੂਚਨਾਵਾਂ ਨੂੰ ਸੰਭਾਲਦਾ ਹੈ।

## ਪ੍ਰਗਤੀ ਸੂਚਨਾਵਾਂ ਅਤੇ ਸਥਿਤੀਆਂ

ਇਹ ਭਾਗ MCP ਵਿੱਚ ਪ੍ਰਗਤੀ ਸੂਚਨਾਵਾਂ ਦੇ ਸੰਕਲਪ, ਮਹੱਤਵ ਅਤੇ Streamable HTTP ਦੀ ਵਰਤੋਂ ਨਾਲ ਇਨ੍ਹਾਂ ਨੂੰ ਲਾਗੂ ਕਰਨ ਦਾ ਤਰੀਕਾ ਸਮਝਾਉਂਦਾ ਹੈ। ਇਸਦੇ ਨਾਲ ਇੱਕ ਵਿਹਾਰਕ ਅਸਾਈਨਮੈਂਟ ਵੀ ਦਿੱਤਾ ਗਿਆ ਹੈ ਜੋ ਤੁਹਾਡੇ ਸਮਝ ਨੂੰ ਮਜ਼ਬੂਤ ਕਰੇਗਾ।

ਪ੍ਰਗਤੀ ਸੂਚਨਾਵਾਂ ਉਹ ਰੀਅਲ-ਟਾਈਮ ਸੁਨੇਹੇ ਹਨ ਜੋ ਸਰਵਰ ਵੱਲੋਂ ਲੰਬੇ ਸਮੇਂ ਚੱਲਣ ਵਾਲੇ ਕੰਮਾਂ ਦੌਰਾਨ ਕਲਾਇੰਟ ਨੂੰ ਭੇਜੇ ਜਾਂਦੇ ਹਨ। ਪੂਰੇ ਪ੍ਰਕਿਰਿਆ ਦੇ ਖਤਮ ਹੋਣ ਦੀ ਉਡੀਕ ਕਰਨ ਦੀ ਥਾਂ, ਸਰਵਰ ਕਲਾਇੰਟ ਨੂੰ ਮੌਜੂਦਾ ਸਥਿਤੀ ਬਾਰੇ ਅੱਪਡੇਟ ਕਰਦਾ ਰਹਿੰਦਾ ਹੈ। ਇਸ ਨਾਲ ਪਾਰਦਰਸ਼ਤਾ, ਉਪਭੋਗਤਾ ਅਨੁਭਵ ਸੁਧਾਰਦਾ ਹੈ ਅਤੇ ਡੀਬੱਗਿੰਗ ਆਸਾਨ ਹੁੰਦੀ ਹੈ।

**ਉਦਾਹਰਨ:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### ਪ੍ਰਗਤੀ ਸੂਚਨਾਵਾਂ ਕਿਉਂ ਵਰਤਣ

**ਅਸਵੀਕਾਰੋक्ति**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਸਵੈਚਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਹੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਭ੍ਰਮਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।