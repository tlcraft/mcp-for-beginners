<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "fbe345ba124324648cfb3aef9a9120b8",
  "translation_date": "2025-07-13T20:22:59+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "en"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

This chapter offers a detailed guide on implementing secure, scalable, and real-time streaming using the Model Context Protocol (MCP) over HTTPS. It covers the reasons for streaming, available transport methods, how to implement streamable HTTP in MCP, security best practices, migrating from SSE, and practical advice for building your own streaming MCP applications.

## Transport Mechanisms and Streaming in MCP

This section examines the different transport mechanisms supported by MCP and their role in enabling streaming for real-time communication between clients and servers.

### What is a Transport Mechanism?

A transport mechanism defines how data is exchanged between client and server. MCP supports several transport types to fit various environments and needs:

- **stdio**: Standard input/output, ideal for local and CLI-based tools. Simple but not suitable for web or cloud environments.
- **SSE (Server-Sent Events)**: Lets servers push real-time updates to clients over HTTP. Good for web UIs but limited in scalability and flexibility.
- **Streamable HTTP**: A modern HTTP-based streaming transport that supports notifications and offers better scalability. Recommended for most production and cloud use cases.

### Comparison Table

Check out the table below to see the differences between these transport mechanisms:

| Transport         | Real-time Updates | Streaming | Scalability | Use Case                |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | No               | No        | Low         | Local CLI tools         |
| SSE               | Yes              | Yes       | Medium      | Web, real-time updates  |
| Streamable HTTP   | Yes              | Yes       | High        | Cloud, multi-client     |

> **Tip:** Choosing the right transport affects performance, scalability, and user experience. **Streamable HTTP** is recommended for modern, scalable, cloud-ready applications.

Note the stdio and SSE transports introduced in previous chapters, and how streamable HTTP is the focus of this chapter.

## Streaming: Concepts and Motivation

Understanding the core concepts and motivations behind streaming is key to building effective real-time communication systems.

**Streaming** is a network programming technique that sends and receives data in small, manageable chunks or as a sequence of events, instead of waiting for the entire response to be ready. This is especially useful for:

- Large files or datasets.
- Real-time updates (e.g., chat, progress bars).
- Long-running computations where you want to keep users informed.

Here’s what you need to know about streaming at a high level:

- Data is delivered progressively, not all at once.
- The client can process data as it arrives.
- It reduces perceived latency and improves user experience.

### Why use streaming?

The reasons to use streaming include:

- Users receive immediate feedback, not just at the end.
- Enables real-time applications and responsive UIs.
- More efficient use of network and compute resources.

### Simple Example: HTTP Streaming Server & Client

Here’s a simple example of how streaming can be implemented:

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

This example shows a server sending a series of messages to the client as they become available, instead of waiting for all messages to be ready.

**How it works:**
- The server yields each message as it’s ready.
- The client receives and prints each chunk as it arrives.

**Requirements:**
- The server must use a streaming response (e.g., `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**Server (Java, using Spring Boot and Server-Sent Events):**

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

**Client (Java, using Spring WebFlux WebClient):**

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

**Java Implementation Notes:**
- Uses Spring Boot’s reactive stack with `Flux` for streaming.
- `ServerSentEvent` provides structured event streaming with event types.
- `WebClient` with `bodyToFlux()` enables reactive streaming consumption.
- `delayElements()` simulates processing time between events.
- Events can have types (`info`, `result`) for better client handling.

</details>

### Comparison: Classic Streaming vs MCP Streaming

Here’s how classic streaming compares to MCP streaming:

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-----------------------------------|
| Main response          | Chunked                       | Single, at end                    |
| Progress updates       | Sent as data chunks           | Sent as notifications             |
| Client requirements    | Must process stream           | Must implement message handler    |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback|

### Key Differences Observed

Additional key differences include:

- **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks.
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol.

- **Message Format:**
   - Classic HTTP: Plain text chunks with newlines.
   - MCP: Structured LoggingMessageNotification objects with metadata.

- **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses.
   - MCP: More sophisticated client with a message handler to process different message types.

- **Progress Updates:**
   - Classic HTTP: Progress is part of the main response stream.
   - MCP: Progress is sent via separate notification messages while the main response is sent at the end.

### Recommendations

Here are some recommendations when choosing between classical streaming (like the `/stream` endpoint example) and MCP streaming:

- **For simple streaming needs:** Classic HTTP streaming is easier to implement and sufficient for basic streaming.

- **For complex, interactive applications:** MCP streaming offers a more structured approach with richer metadata and clear separation between notifications and final results.

- **For AI applications:** MCP’s notification system is especially useful for long-running AI tasks where you want to keep users informed of progress.

## Streaming in MCP

Now that you’ve seen recommendations and comparisons, let’s dive into how to leverage streaming in MCP.

Understanding streaming within MCP is crucial for building responsive applications that provide real-time feedback during long-running operations.

In MCP, streaming doesn’t mean sending the main response in chunks. Instead, it means sending **notifications** to the client while a tool processes a request. These notifications can include progress updates, logs, or other events.

### How it works

The main result is still sent as a single response. However, notifications are sent as separate messages during processing to update the client in real time. The client must be able to handle and display these notifications.

## What is a Notification?

We mentioned "Notification" — what does that mean in MCP?

A notification is a message sent from the server to the client to inform about progress, status, or other events during a long-running operation. Notifications improve transparency and user experience.

For example, a client is expected to send a notification once the initial handshake with the server is complete.

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
|-----------|-------------------------------|--------------------------------|
| debug     | Detailed debugging information | Function entry/exit points      |
| info      | General informational messages | Operation progress updates      |
| notice    | Normal but significant events  | Configuration changes           |
| warning   | Warning conditions             | Deprecated feature usage        |
| error     | Error conditions               | Operation failures              |
| critical  | Critical conditions            | System component failures       |
| alert     | Immediate action required      | Data corruption detected        |
| emergency | System is unusable             | Complete system failure         |

## Implementing Notifications in MCP

To implement notifications in MCP, you need to set up both server and client to handle real-time updates. This lets your app provide immediate feedback during long-running operations.

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

In the example above, the `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method sends informational messages.

</details>

Also, to enable notifications, make sure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here’s how to configure the server to use the `streamable-http` transport:

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

In this .NET example, the `ProcessFiles` tool is marked with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` method sends informational messages.

To enable notifications in your .NET MCP server, ensure you’re using a streaming transport:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### Client-side: Receiving Notifications

The client must implement a message handler to process and display notifications as they arrive.

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

In the code above, the `message_handler` function checks if the incoming message is a notification. If so, it prints the notification; otherwise, it processes it as a regular server message. Notice how `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

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

In this .NET example, the `MessageHandler` function checks if the incoming message is a notification. If so, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications.

## Progress Notifications & Scenarios

This section explains progress notifications in MCP, why they matter, and how to implement them using Streamable HTTP. You’ll also find a practical exercise to reinforce your understanding.

Progress notifications are real-time messages sent from the server to the client during long-running operations. Instead of waiting for the entire process to finish, the server keeps the client updated on the current status. This improves transparency, user experience, and makes debugging easier.

**Example:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### Why Use Progress Notifications?

Progress notifications are important because:

- **Better user experience:** Users see updates as work progresses, not just at the end.
- **Real-time feedback:** Clients can show progress bars or logs, making the app feel responsive.
- **Easier debugging and monitoring:** Developers and users can see where a process might be slow or stuck.

### How to Implement Progress Notifications

Here’s how to implement progress notifications in MCP:

- **On the server:** Use `ctx.info()` or `ctx.log()` to send notifications as each item is processed. This sends messages to the client before the main result is ready.
- **On the client:** Implement a message handler that listens for and displays notifications as they arrive. This handler distinguishes between notifications and the final result.

**Server Example:**

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

When implementing MCP servers with HTTP-based transports, security is a critical concern that requires careful attention to various attack vectors and protection measures.

### Overview

Security is essential when exposing MCP servers over HTTP. Streamable HTTP introduces new vulnerabilities and demands careful configuration.

### Key Points
- **Origin Header Validation**: Always check the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid exposing them to the public internet.
- **Authentication**: Use authentication methods (e.g., API keys, OAuth) for production environments.
- **CORS**: Set up Cross-Origin Resource Sharing (CORS) policies to limit access.
- **HTTPS**: Use HTTPS in production to encrypt data in transit.

### Best Practices
- Never trust incoming requests without proper validation.
- Log and monitor all access and errors.
- Keep dependencies up to date to fix security vulnerabilities.

### Challenges
- Balancing security with ease of development
- Ensuring compatibility across different client environments


## Upgrading from SSE to Streamable HTTP

For applications currently using Server-Sent Events (SSE), switching to Streamable HTTP offers improved features and better long-term support for your MCP implementations.

### Why Upgrade?

There are two main reasons to move from SSE to Streamable HTTP:

- Streamable HTTP provides better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps

To migrate from SSE to Streamable HTTP in your MCP apps:

- **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
- **Update client code** to use `streamablehttp_client` instead of the SSE client.
- **Add a message handler** in the client to process incoming notifications.
- **Test compatibility** with your existing tools and workflows.

### Maintaining Compatibility

It’s advisable to keep supporting existing SSE clients during migration. Some approaches include:

- Running both SSE and Streamable HTTP transports on different endpoints.
- Gradually moving clients over to the new transport.

### Challenges

Be mindful of these challenges during migration:

- Making sure all clients are updated
- Handling differences in how notifications are delivered

## Security Considerations

Security should always be a top priority when building any server, especially when using HTTP-based transports like Streamable HTTP in MCP.

When implementing MCP servers with HTTP-based transports, security requires careful attention to multiple attack vectors and protection mechanisms.

### Overview

Security is crucial when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful setup.

Key security points include:

- **Origin Header Validation**: Always verify the `Origin` header to prevent DNS rebinding attacks.
- **Localhost Binding**: For local development, bind servers to `localhost` to avoid public exposure.
- **Authentication**: Use authentication (e.g., API keys, OAuth) in production.
- **CORS**: Configure Cross-Origin Resource Sharing (CORS) policies to restrict access.
- **HTTPS**: Use HTTPS in production to encrypt traffic.

### Best Practices

Additional best practices for securing your MCP streaming server:

- Never trust incoming requests without validation.
- Log and monitor all access and errors.
- Regularly update dependencies to fix security issues.

### Challenges

Some challenges you may face when securing MCP streaming servers:

- Balancing security with ease of development
- Ensuring compatibility with various client environments

### Assignment: Build Your Own Streaming MCP App

**Scenario:**
Create an MCP server and client where the server processes a list of items (e.g., files or documents) and sends a notification for each processed item. The client should display each notification as it arrives.

**Steps:**

1. Build a server tool that processes a list and sends notifications for each item.
2. Build a client with a message handler to display notifications in real time.
3. Test your setup by running both server and client, and watch the notifications.

[Solution](./solution/README.md)

## Further Reading & What Next?

To continue learning about MCP streaming and expand your skills, this section offers additional resources and suggested next steps for building more advanced applications.

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
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.