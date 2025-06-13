<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:36:09+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "mo"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

This chapter offers a thorough guide to implementing secure, scalable, real-time streaming using the Model Context Protocol (MCP) over HTTPS. It covers why streaming matters, available transport options, how to implement streamable HTTP in MCP, security best practices, migrating from SSE, and practical tips for building your own streaming MCP apps.

## Transport Mechanisms and Streaming in MCP

This section reviews the different transport mechanisms MCP supports and their role in enabling streaming for real-time communication between clients and servers.

### What is a Transport Mechanism?

A transport mechanism defines how data is exchanged between client and server. MCP supports several transport types to fit various environments and needs:

- **stdio**: Standard input/output, ideal for local and CLI-based tools. Simple but not suited for web or cloud.
- **SSE (Server-Sent Events)**: Lets servers push real-time updates to clients over HTTP. Good for web UIs but limited in scalability and flexibility.
- **Streamable HTTP**: Modern HTTP-based streaming transport supporting notifications and better scalability. Recommended for most production and cloud scenarios.

### Comparison Table

Check out the comparison table below to see how these transport mechanisms differ:

| Transport         | Real-time Updates | Streaming | Scalability | Use Case                |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | No               | No        | Low         | Local CLI tools         |
| SSE               | Yes              | Yes       | Medium      | Web, real-time updates  |
| Streamable HTTP   | Yes              | Yes       | High        | Cloud, multi-client     |

> **Tip:** Choosing the right transport affects performance, scalability, and user experience. **Streamable HTTP** is recommended for modern, scalable, cloud-ready apps.

Remember the stdio and SSE transports covered in earlier chapters and that streamable HTTP is the focus here.

## Streaming: Concepts and Motivation

Grasping the core concepts and reasons behind streaming is key to building effective real-time communication systems.

**Streaming** is a network programming technique that sends and receives data in small, manageable chunks or as a series of events, instead of waiting for a full response. This is especially helpful for:

- Large files or datasets.
- Real-time updates (e.g., chat, progress bars).
- Long-running computations where ongoing user feedback is needed.

Here’s what you should know about streaming at a glance:

- Data is delivered progressively, not all at once.
- The client can process data as it arrives.
- It reduces perceived latency and enhances user experience.

### Why use streaming?

The main reasons to use streaming are:

- Users get immediate feedback, not just at the end.
- Enables real-time apps and responsive UIs.
- More efficient use of network and compute resources.

### Simple Example: HTTP Streaming Server & Client

Here’s a straightforward example of streaming in action:

<details>
<summary>Python</summary>

**Server (Python, using FastAPI and StreamingResponse):**
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

**Client (Python, using requests):**
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

This example shows a server sending messages to the client as they become available, instead of waiting for all messages to be ready.

**How it works:**
- The server yields each message as it’s ready.
- The client receives and prints each chunk as it arrives.

**Requirements:**
- The server must use a streaming response (e.g., `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) rather than selecting streaming through MCP.

- **For simple streaming:** Classic HTTP streaming is easier to implement and sufficient for basic needs.

- **For complex, interactive apps:** MCP streaming offers a more structured approach with richer metadata and separation between notifications and final results.

- **For AI apps:** MCP’s notification system is especially useful for long-running AI tasks where you want to keep users updated on progress.

## Streaming in MCP

So far, you’ve seen recommendations and comparisons between classic streaming and MCP streaming. Now let’s dive into exactly how to use streaming within MCP.

Understanding streaming inside the MCP framework is crucial for building responsive apps that provide real-time feedback during long-running operations.

In MCP, streaming isn’t about sending the main response in pieces, but about sending **notifications** to the client while a tool processes a request. These notifications can include progress updates, logs, or other events.

### How it works

The main result is still delivered as a single response. However, notifications can be sent as separate messages during processing to update the client in real time. The client must be capable of handling and displaying these notifications.

## What is a Notification?

We mentioned "Notification" — what does it mean in MCP?

A notification is a message sent from the server to the client to report progress, status, or other events during a long-running operation. Notifications enhance transparency and improve user experience.

For example, a client is expected to send a notification once the initial handshake with the server completes.

A notification looks like this as a JSON message:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

Notifications belong to a topic in MCP called ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

To enable logging, the server must activate it as a feature/capability like this:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> Depending on the SDK used, logging might be enabled by default, or you may need to explicitly enable it in your server configuration.

There are different types of notifications:

| Level     | Description                    | Example Use Case                |
|-----------|-------------------------------|---------------------------------|
| debug     | Detailed debugging information | Function entry/exit points      |
| info      | General informational messages | Operation progress updates      |
| notice    | Normal but significant events  | Configuration changes           |
| warning   | Warning conditions             | Deprecated feature usage        |
| error     | Error conditions               | Operation failures              |
| critical  | Critical conditions            | System component failures       |
| alert     | Immediate action required      | Data corruption detected       |
| emergency | System is unusable             | Complete system failure         |

## Implementing Notifications in MCP

To implement notifications in MCP, you need to set up both server and client to handle real-time updates. This lets your app provide immediate feedback during long-running tasks.

### Server-side: Sending Notifications

Let’s start with the server side. In MCP, you define tools that send notifications while processing requests. The server uses the context object (usually `ctx`) to send messages to the client.

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

In the example above, the `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` transport is used:

```python
mcp.run(transport="streamable-http")
```

</details>

### Client-side: Receiving Notifications

The client must implement a message handler to process and display notifications as they come in.

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

In this code, the `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` is set up, and your client processes notifications accordingly.

## Progress Notifications & Scenarios

This section explains progress notifications in MCP: why they matter and how to implement them with Streamable HTTP. A practical exercise is included to reinforce your understanding.

Progress notifications are real-time messages sent from server to client during long operations. Instead of waiting for everything to finish, the server keeps the client updated on the current status. This boosts transparency, user experience, and eases debugging.

**Example:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Why Use Progress Notifications?

Progress notifications are important because:

- **Better user experience:** Users see updates as work happens, not just at the end.
- **Real-time feedback:** Clients can show progress bars or logs, making the app feel responsive.
- **Easier debugging and monitoring:** Developers and users can spot where a process might slow or stall.

### How to Implement Progress Notifications

Here’s how to implement progress notifications in MCP:

- **On the server:** Use `ctx.info()` or `ctx.log()` to send notifications as each item is processed. This sends messages before the main result is ready.
- **On the client:** Implement a message handler that listens for and displays notifications as they arrive. This handler distinguishes notifications from the final result.

**Server Example:**

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

**Client Example:**

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

## Security Considerations

When implementing MCP servers using HTTP-based transports, security is critical and requires attention to various attack vectors and protection measures.

### Overview

Security is vital when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and demands careful configuration.

### Key Points
- **Origin Header Validation**: Always validate the `Origin` header to prevent cross-site attacks.
- **Authentication and Authorization**: Ensure only authorized clients can connect.
- **Rate Limiting and Throttling**: Protect against abuse and denial-of-service attacks.
- **Transport Security**: Use HTTPS to encrypt data in transit.
- **Input Validation**: Sanitize inputs to avoid injection attacks.

### Maintaining Compatibility

During migration, it’s recommended to maintain compatibility with existing SSE clients. Strategies include:

- Supporting both SSE and Streamable HTTP by running them on separate endpoints.
- Gradually migrating clients to the new transport.

### Challenges

Address these challenges during migration:

- Ensuring all clients update to support the new transport.
- Handling differences in notification delivery and format.

### Assignment: Build Your Own Streaming MCP App

**Scenario:**
Create an MCP server and client where the server processes a list of items (e.g., files or documents) and sends a notification for each processed item. The client should display each notification as it arrives.

**Steps:**

1. Implement a server tool that processes a list and sends notifications for each item.
2. Implement a client with a message handler to display notifications in real time.
3. Test your implementation by running both server and client, and observe the notifications.

[Solution](./solution/README.md)

## Further Reading & What Next?

To continue your MCP streaming journey and deepen your knowledge, this section offers additional resources and suggested next steps for building more advanced apps.

### Further Reading

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### What Next?

- Try building more advanced MCP tools that use streaming for real-time analytics, chat, or collaborative editing.
- Explore integrating MCP streaming with frontend frameworks (React, Vue, etc.) for live UI updates.
- Next: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.

---

If by "mo" you mean a specific language or code, please clarify which language or dialect "mo" refers to, so I can provide an accurate translation.