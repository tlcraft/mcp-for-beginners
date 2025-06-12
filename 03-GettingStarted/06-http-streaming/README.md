# HTTPS Streaming with Model Context Protocol (MCP)

This chapter provides a comprehensive guide to implementing secure, scalable, and real-time streaming with the Model Context Protocol (MCP) using HTTPS. It covers the motivation for streaming, the available transport mechanisms, how to implement streamable HTTP in MCP, security best practices, migration from SSE, and practical guidance for building your own streaming MCP applications. 

---

## 1. Transport Mechanisms and Streaming in MCP

### What is a Transport Mechanism?
A transport mechanism defines how data is exchanged between the client and server. MCP supports multiple transport types to suit different environments and requirements:

- **stdio**: Standard input/output, suitable for local and CLI-based tools. Simple but not suitable for web or cloud.
- **SSE (Server-Sent Events)**: Allows servers to push real-time updates to clients over HTTP. Good for web UIs, but limited in scalability and flexibility.
- **Streamable HTTP**: Modern HTTP-based streaming transport, supporting notifications and better scalability. Recommended for most production and cloud scenarios.

#### Comparison Table
| Transport         | Real-time Updates | Streaming | Scalability | Use Case                |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | No               | No        | Low         | Local CLI tools         |
| SSE               | Yes              | Yes       | Medium      | Web, real-time updates  |
| Streamable HTTP   | Yes              | Yes       | High        | Cloud, multi-client     |

> **Tip:** Choosing the right transport impacts performance, scalability, and user experience. **Streamable HTTP** is recommended for modern, scalable, and cloud-ready applications.

---

## 2. Streaming: Concepts and Motivation

**Streaming** is a technique in network programming that allows data to be sent and received in small, manageable chunks or as a sequence of events, rather than waiting for an entire response to be ready. This is especially useful for:

- Large files or datasets
- Real-time updates (e.g., chat, progress bars)
- Long-running computations where you want to keep the user informed

#### Key Concepts
- Data is delivered progressively, not all at once
- The client can process data as it arrives
- Reduces perceived latency and improves user experience

#### Why use streaming?
- Users get feedback immediately, not just at the end
- Enables real-time applications and responsive UIs
- More efficient use of network and compute resources

##### Simple Example: HTTP Streaming Server & Client

**Server (Python, using FastAPI and StreamingResponse):**
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

**Client (Python, using requests):**
```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```

This example demonstrates a server sending a series of messages to the client as they become available, rather than waiting for all messages to be ready.

**How it works:**
- The server yields each message as it is ready.
- The client receives and prints each chunk as it arrives.

**Requirements:**
- The server must use a streaming response (e.g., `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

---

### Comparison: Classic Streaming vs MCP Streaming

| Feature                | Classic HTTP Streaming         | MCP Streaming (Notifications)      |
|------------------------|-------------------------------|-------------------------------------|
| Main response          | Chunked                       | Single, at end                      |
| Progress updates       | Sent as data chunks           | Sent as notifications               |
| Client requirements    | Must process stream           | Must implement message handler      |
| Use case               | Large files, AI token streams | Progress, logs, real-time feedback  |

### Key Differences Observed

1. **Communication Pattern:**
   - Classic HTTP streaming: Uses simple chunked transfer encoding to send data in chunks
   - MCP streaming: Uses a structured notification system with JSON-RPC protocol

2. **Message Format:**
   - Classic HTTP: Plain text chunks with newlines
   - MCP: Structured LoggingMessageNotification objects with metadata

3. **Client Implementation:**
   - Classic HTTP: Simple client that processes streaming responses
   - MCP: More sophisticated client with a message handler to process different types of messages

4. **Progress Updates:**
   - Classic HTTP: The progress is part of the main response stream
   - MCP: Progress is sent via separate notification messages while the main response comes at the end

### Recommendations

Based on what we've observed:

1. **For simple streaming needs:** Classic HTTP streaming is simpler to implement and sufficient for basic streaming needs.

2. **For complex, interactive applications:** MCP streaming provides a more structured approach with richer metadata and separation between notifications and final results.

3. **For AI applications:** MCP's notification system is particularly useful for long-running AI tasks where you want to keep users informed of progress.

---

## 3. Streaming in MCP

In MCP, streaming is not about sending the main response in chunks, but about sending **notifications** to the client while a tool is processing a request. These notifications can include progress updates, logs, or other events.

#### Key differences from traditional streaming
- The main result is still sent as a single response
- Notifications are sent as separate messages during processing
- The client must be able to handle and display these notifications

#### What is a Notification?
A notification is a message sent from the server to the client to inform about progress, status, or other events during a long-running operation. Notifications improve transparency and user experience.

##### Why use notifications?
- Keep users informed about progress
- Enable real-time feedback and better UX
- Useful for debugging and monitoring

---

## 4. Implementing Notifications in MCP

### Server-side: Sending Notifications
To send notifications from your MCP tool, use the context object (usually `ctx`) to call methods like `ctx.info()` or `ctx.log()`. These send messages to the client as the server processes a request.

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

### Client-side: Receiving Notifications
The client must implement a message handler to process and display notifications as they arrive.

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications.

---

## 5. Streamable HTTP Transport

### What is Streamable HTTP?
Streamable HTTP is a transport mechanism in MCP that uses HTTP POST requests and supports streaming notifications (such as progress updates) from the server to the client. It is designed for modern web and cloud environments.

### How It Works
- The client sends a request to the server using HTTP.
- The server can send notifications (e.g., progress, logs) back to the client while processing the request.
- The final response is sent when processing is complete.

### Benefits Over SSE and stdio
- **Better scalability**: Works well with load balancers and cloud deployments.
- **Stateless and stateful modes**: Supports both, with resumability.
- **Rich notifications**: Send progress, logs, and other events during processing.
- **Standard HTTP**: Easier to integrate with existing infrastructure.

### Implementation Details
- Uses JSON or SSE for response formats.
- Requires clients to implement a message handler to process notifications.
- Supports both synchronous and asynchronous tool execution.

### Example Use Cases
- Long-running document processing with progress updates
- Real-time AI inference with streaming logs
- Multi-client collaborative tools

---

## 6. Security Considerations

### Overview
Security is critical when exposing MCP servers over HTTP. Streamable HTTP introduces new attack surfaces and requires careful configuration.

### Key Points
- **Origin Header Validation**: Always validate the `Origin` header to prevent DNS rebinding attacks.
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

---

## 7. Implementation Guide

This section provides a step-by-step guide to building, running, and understanding an MCP streaming server and client using the streamable HTTP transport.

### Overview
- You will set up an MCP server that streams progress notifications to the client as it processes items.
- The client will display each notification in real time.
- This guide covers prerequisites, setup, running, and troubleshooting.

### Prerequisites
- Python 3.9 or newer
- The `mcp` Python package (install with `pip install mcp`)

### Installation & Setup
1. **Create and activate a virtual environment (recommended):**
   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```
2. **Install required dependencies:**
   ```pwsh
   pip install mcp fastapi uvicorn requests
   ```

### Example Files
- **Server:** [server.py](./server.py)
- **Client:** [client.py](./client.py)

### Running the Classic HTTP Streaming Server
1. Navigate to the solution directory:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Start the classic HTTP streaming server:
   ```pwsh
   python server.py
   ```
3. The server will start and display:
   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Running the Classic HTTP Streaming Client
1. Open a new terminal (activate the same virtual environment and directory):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```
2. You should see streamed messages printed sequentially:
   ```
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### Running the MCP Streaming Server
1. Navigate to the solution directory:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Start the MCP server with the streamable-http transport:
   ```pwsh
   python server.py mcp
   ```
3. The server will start and display:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Running the MCP Streaming Client
1. Open a new terminal (activate the same virtual environment and directory):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. You should see notifications printed in real time as the server processes each item:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### Key Implementation Steps
1. **Create the MCP server using FastMCP.**
2. **Define a tool that processes a list and sends notifications using `ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting
- Use `async/await` for non-blocking operations.
- Always handle exceptions in both server and client for robustness.
- Test with multiple clients to observe real-time updates.
- If you encounter errors, check your Python version and ensure all dependencies are installed.

---

## 8. Upgrading from SSE to Streamable HTTP

### Why Upgrade?
- Streamable HTTP offers better scalability, compatibility, and richer notification support than SSE.
- It is the recommended transport for new MCP applications.

### Migration Steps
1. **Update server code** to use `transport="streamable-http"` in `mcp.run()`.
2. **Update client code** to use `streamablehttp_client` instead of SSE client.
3. **Implement a message handler** in the client to process notifications.
4. **Test for compatibility** with existing tools and workflows.

### Maintaining Compatibility
- You can support both SSE and Streamable HTTP by running both transports on different endpoints.
- Gradually migrate clients to the new transport.

### Challenges
- Ensuring all clients are updated
- Handling differences in notification delivery

---

## 9. Progress Notifications & Scenarios

This section explains the concept of progress notifications in MCP, why they matter, and how to implement them using Streamable HTTP. You'll also find a practical assignment to reinforce your understanding.

### What Are Progress Notifications?
Progress notifications are real-time messages sent from the server to the client during long-running operations. Instead of waiting for the entire process to finish, the server keeps the client updated about the current status. This improves transparency, user experience, and makes debugging easier.

**Example:**
- "Processing document 1/10"
- "Processing document 2/10"
- ...
- "Processing complete!"

### Why Use Progress Notifications?
- **Better user experience:** Users see updates as work progresses, not just at the end.
- **Real-time feedback:** Clients can display progress bars or logs, making the app feel responsive.
- **Easier debugging and monitoring:** Developers and users can see where a process might be slow or stuck.

### How to Implement Progress Notifications
- **On the server:** Use `ctx.info()` or `ctx.log()` to send notifications as each item is processed. This sends a message to the client before the main result is ready.
- **On the client:** Implement a message handler that listens for and displays notifications as they arrive. This handler distinguishes between notifications and the final result.

**Server Example:**
```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```

**Client Example:**
```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```

### Assignment: Build Your Own Streaming MCP App

**Scenario:**
Build an MCP server and client where the server processes a list of items (e.g., files or documents) and sends a notification for each item processed. The client should display each notification as it arrives.

**Steps:**
1. Implement a server tool that processes a list and sends notifications for each item.
2. Implement a client with a message handler to display notifications in real time.
3. Test your implementation by running both server and client, and observe the notifications.

You can use the code samples above as a starting point, or refer to the provided [server.py](./server.py) and [client.py](./client.py) in this chapter for a complete implementation.

## 10. Further Reading & What Next?

### Further Reading
- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### What Next?
- Try building more advanced MCP tools that use streaming for real-time analytics, chat, or collaborative editing.
- Explore integrating MCP streaming with frontend frameworks (React, Vue, etc.) for live UI updates.
- Next: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)
