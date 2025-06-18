<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:50:59+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "bn"
}
-->
# HTTPS স্ট্রিমিং মডেল কনটেক্সট প্রোটোকল (MCP) এর সাথে

এই অধ্যায়ে HTTPS ব্যবহার করে মডেল কনটেক্সট প্রোটোকল (MCP) এর মাধ্যমে সুরক্ষিত, স্কেলযোগ্য এবং রিয়েল-টাইম স্ট্রিমিং বাস্তবায়নের ব্যাপক নির্দেশিকা দেওয়া হয়েছে। এতে স্ট্রিমিংয়ের প্রয়োজনীয়তা, উপলব্ধ ট্রান্সপোর্ট মেকানিজম, MCP তে স্ট্রিমেবল HTTP কিভাবে ইমপ্লিমেন্ট করবেন, নিরাপত্তার সেরা অনুশীলন, SSE থেকে মাইগ্রেশন, এবং নিজের স্ট্রিমিং MCP অ্যাপ্লিকেশন তৈরি করার ব্যবহারিক নির্দেশনা অন্তর্ভুক্ত।

## MCP তে ট্রান্সপোর্ট মেকানিজম এবং স্ট্রিমিং

এই অংশে MCP তে উপলব্ধ বিভিন্ন ট্রান্সপোর্ট মেকানিজম এবং সেগুলো কীভাবে ক্লায়েন্ট ও সার্ভারের মধ্যে রিয়েল-টাইম কমিউনিকেশন সক্ষম করে তা আলোচনা করা হয়েছে।

### ট্রান্সপোর্ট মেকানিজম কী?

ট্রান্সপোর্ট মেকানিজম নির্ধারণ করে কীভাবে ডেটা ক্লায়েন্ট এবং সার্ভারের মধ্যে বিনিময় হয়। MCP বিভিন্ন পরিবেশ এবং চাহিদার জন্য একাধিক ট্রান্সপোর্ট টাইপ সমর্থন করে:

- **stdio**: স্ট্যান্ডার্ড ইনপুট/আউটপুট, লোকাল এবং CLI-ভিত্তিক টুলের জন্য উপযোগী। সহজ কিন্তু ওয়েব বা ক্লাউডের জন্য উপযুক্ত নয়।
- **SSE (Server-Sent Events)**: সার্ভারকে HTTP এর মাধ্যমে ক্লায়েন্টকে রিয়েল-টাইম আপডেট পাঠানোর অনুমতি দেয়। ওয়েব UI এর জন্য ভালো, তবে স্কেলেবিলিটি এবং ফ্লেক্সিবিলিটির ক্ষেত্রে সীমাবদ্ধ।
- **Streamable HTTP**: আধুনিক HTTP ভিত্তিক স্ট্রিমিং ট্রান্সপোর্ট, যা নোটিফিকেশন এবং উন্নত স্কেলেবিলিটি সমর্থন করে। অধিকাংশ প্রোডাকশন এবং ক্লাউড পরিস্থিতির জন্য সুপারিশকৃত।

### তুলনামূলক টেবিল

নিচের তুলনামূলক টেবিলটি দেখুন যাতে এই ট্রান্সপোর্ট মেকানিজমগুলোর মধ্যে পার্থক্য বোঝা যায়:

| ট্রান্সপোর্ট         | রিয়েল-টাইম আপডেট | স্ট্রিমিং | স্কেলেবিলিটি | ব্যবহারের ক্ষেত্র          |
|---------------------|-------------------|-----------|--------------|---------------------------|
| stdio               | না                | না        | কম           | লোকাল CLI টুল             |
| SSE                 | হ্যাঁ              | হ্যাঁ      | মাঝারি        | ওয়েব, রিয়েল-টাইম আপডেট |
| Streamable HTTP     | হ্যাঁ              | হ্যাঁ      | উচ্চ          | ক্লাউড, মাল্টি-ক্লায়েন্ট |

> **টিপ:** সঠিক ট্রান্সপোর্ট নির্বাচন পারফরম্যান্স, স্কেলেবিলিটি এবং ব্যবহারকারীর অভিজ্ঞতায় প্রভাব ফেলে। আধুনিক, স্কেলেবল এবং ক্লাউড-রেডি অ্যাপ্লিকেশনের জন্য **Streamable HTTP** সুপারিশ করা হয়।

আগের অধ্যায়গুলোতে stdio এবং SSE ট্রান্সপোর্ট সম্পর্কে দেখানো হয়েছে এবং এই অধ্যায়ে স্ট্রিমেবল HTTP ট্রান্সপোর্ট কভার করা হয়েছে।

## স্ট্রিমিং: ধারণা এবং প্রেরণা

স্ট্রিমিংয়ের মৌলিক ধারণা এবং প্রেরণা বোঝা কার্যকর রিয়েল-টাইম কমিউনিকেশন সিস্টেম বাস্তবায়নের জন্য অপরিহার্য।

**স্ট্রিমিং** হলো নেটওয়ার্ক প্রোগ্রামিংয়ের একটি কৌশল যা ডেটা ছোট ছোট manageable অংশে বা ইভেন্টের সিরিজ হিসেবে পাঠানো এবং গ্রহণ করার সুযোগ দেয়, পুরো রেসপন্স প্রস্তুত হওয়ার জন্য অপেক্ষা না করে। এটি বিশেষ করে কাজে লাগে:

- বড় ফাইল বা ডেটাসেটের ক্ষেত্রে।
- রিয়েল-টাইম আপডেট (যেমন, চ্যাট, প্রগ্রেস বার)।
- দীর্ঘমেয়াদি কম্পিউটেশন যেখানে ব্যবহারকারীকে অবহিত রাখা দরকার।

উচ্চ স্তরে স্ট্রিমিং সম্পর্কে যা জানা দরকার:

- ডেটা ধাপে ধাপে সরবরাহ করা হয়, একসঙ্গে নয়।
- ক্লায়েন্ট ডেটা আসার সাথে সাথে প্রক্রিয়া করতে পারে।
- উপলব্ধ বিলম্ব কমায় এবং ব্যবহারকারীর অভিজ্ঞতা উন্নত করে।

### কেন স্ট্রিমিং ব্যবহার করবেন?

স্ট্রিমিং ব্যবহারের কারণগুলো হলো:

- ব্যবহারকারীরা অবিলম্বে প্রতিক্রিয়া পান, শুধু শেষে নয়
- রিয়েল-টাইম অ্যাপ্লিকেশন এবং প্রতিক্রিয়াশীল UI সক্ষম করে
- নেটওয়ার্ক এবং কম্পিউটিং রিসোর্সের আরও কার্যকর ব্যবহার

### সহজ উদাহরণ: HTTP স্ট্রিমিং সার্ভার ও ক্লায়েন্ট

নিচে একটি সহজ উদাহরণ দেওয়া হলো কিভাবে স্ট্রিমিং ইমপ্লিমেন্ট করা যায়:

<details>
<summary>Python</summary>

**সার্ভার (Python, FastAPI এবং StreamingResponse ব্যবহার করে):**
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

**ক্লায়েন্ট (Python, requests ব্যবহার করে):**
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

এই উদাহরণে সার্ভার ক্লায়েন্টকে বার্তাগুলো পাওয়ার সাথে সাথে পাঠাচ্ছে, সব বার্তা প্রস্তুত হওয়ার জন্য অপেক্ষা করছে না।

**কিভাবে কাজ করে:**
- সার্ভার প্রতিটি বার্তা প্রস্তুত হওয়ার সাথে সাথে পাঠায়।
- ক্লায়েন্ট প্রতিটি অংশ পাওয়ার সাথে সাথে গ্রহণ ও প্রদর্শন করে।

**প্রয়োজনীয়তা:**
- সার্ভারকে স্ট্রিমিং রেসপন্স ব্যবহার করতে হবে (যেমন, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**সার্ভার (Java, Spring Boot এবং Server-Sent Events ব্যবহার করে):**

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

**ক্লায়েন্ট (Java, Spring WebFlux WebClient ব্যবহার করে):**

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

**Java বাস্তবায়নের নোট:**
- Spring Boot এর reactive stack ব্যবহার করে `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) এর পরিবর্তে MCP এর মাধ্যমে স্ট্রিমিং বেছে নেওয়া যায়।

- **সহজ স্ট্রিমিংয়ের জন্য:** ক্লাসিক HTTP স্ট্রিমিং সহজে ইমপ্লিমেন্ট করা যায় এবং মৌলিক স্ট্রিমিং চাহিদার জন্য যথেষ্ট।

- **জটিল, ইন্টারেক্টিভ অ্যাপ্লিকেশনের জন্য:** MCP স্ট্রিমিং বেশি কাঠামোগত পদ্ধতি দেয় যেখানে আরও সমৃদ্ধ মেটাডেটা এবং নোটিফিকেশন ও চূড়ান্ত ফলাফলের পৃথকরণ থাকে।

- **AI অ্যাপ্লিকেশনের জন্য:** MCP এর নোটিফিকেশন সিস্টেম দীর্ঘমেয়াদি AI টাস্কে ব্যবহারকারীদের প্রগতি সম্পর্কে অবহিত রাখতে বিশেষভাবে কার্যকর।

## MCP তে স্ট্রিমিং

এখন পর্যন্ত আপনি ক্লাসিক্যাল স্ট্রিমিং এবং MCP স্ট্রিমিংয়ের মধ্যে পার্থক্য সম্পর্কে কিছু সুপারিশ এবং তুলনা দেখেছেন। আসুন বিস্তারিত জানি কিভাবে MCP তে স্ট্রিমিং ব্যবহার করা যায়।

MCP ফ্রেমওয়ার্কের মধ্যে স্ট্রিমিং কিভাবে কাজ করে তা বোঝা জরুরি যাতে দীর্ঘমেয়াদি অপারেশনের সময় ব্যবহারকারীদের রিয়েল-টাইম ফিডব্যাক দেওয়া যায়।

MCP তে স্ট্রিমিং মানে প্রধান রেসপন্স টুকরো টুকরো পাঠানো নয়, বরং একটি টুল যখন অনুরোধ প্রক্রিয়াজাত করছে তখন ক্লায়েন্টকে **নোটিফিকেশন** পাঠানো। এই নোটিফিকেশনগুলিতে প্রগ্রেস আপডেট, লগ বা অন্যান্য ইভেন্ট থাকতে পারে।

### কিভাবে কাজ করে

মূল ফলাফল এখনও একক রেসপন্স হিসেবে পাঠানো হয়। তবে, প্রক্রিয়াকরণের সময় নোটিফিকেশনগুলো আলাদা বার্তা হিসেবে পাঠানো হয় এবং এর মাধ্যমে ক্লায়েন্ট রিয়েল-টাইমে আপডেট হয়। ক্লায়েন্টকে অবশ্যই এই নোটিফিকেশনগুলো গ্রহণ ও প্রদর্শন করতে সক্ষম হতে হবে।

## নোটিফিকেশন কী?

আমরা বলেছি "নোটিফিকেশন", MCP প্রেক্ষাপটে এর অর্থ কী?

নোটিফিকেশন হলো সার্ভার থেকে ক্লায়েন্টের কাছে পাঠানো একটি বার্তা যা দীর্ঘমেয়াদি অপারেশনের সময় প্রগ্রেস, অবস্থা বা অন্যান্য ইভেন্ট সম্পর্কে জানায়। নোটিফিকেশন স্বচ্ছতা এবং ব্যবহারকারীর অভিজ্ঞতা উন্নত করে।

উদাহরণস্বরূপ, ক্লায়েন্টকে সার্ভারের সাথে প্রাথমিক হ্যান্ডশেক সম্পন্ন হওয়ার পর একটি নোটিফিকেশন পাঠাতে হবে।

নোটিফিকেশন দেখতে JSON বার্তার মতো হয়:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

নোটিফিকেশন MCP এর একটি টপিকের অন্তর্ভুক্ত যা ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) নামে পরিচিত।

লগিং কাজ করার জন্য, সার্ভারকে এটি একটি ফিচার/ক্ষমতা হিসেবে সক্ষম করতে হবে, যেমন:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> ব্যবহৃত SDK এর উপর নির্ভর করে, লগিং ডিফল্টরূপে সক্রিয় থাকতে পারে, অথবা আপনাকে আপনার সার্ভার কনফিগারেশনে স্পষ্টভাবে এটি সক্ষম করতে হতে পারে।

নোটিফিকেশনের বিভিন্ন ধরণ আছে:

| স্তর       | বর্ণনা                         | উদাহরণ ব্যবহার ক্ষেত্র           |
|------------|-------------------------------|--------------------------------|
| debug      | বিস্তারিত ডিবাগিং তথ্য          | ফাংশন এন্ট্রি/এক্সিট পয়েন্ট  |
| info       | সাধারণ তথ্যবহুল বার্তা          | অপারেশন প্রগ্রেস আপডেট        |
| notice     | স্বাভাবিক কিন্তু গুরুত্বপূর্ণ ইভেন্ট | কনফিগারেশন পরিবর্তন           |
| warning    | সতর্কতা পরিস্থিতি              | ডিপ্রিকেটেড ফিচার ব্যবহারে     |
| error      | ত্রুটি পরিস্থিতি                | অপারেশন ব্যর্থতা              |
| critical   | গুরুতর পরিস্থিতি               | সিস্টেম কম্পোনেন্ট ব্যর্থতা    |
| alert      | অবিলম্বে পদক্ষেপ গ্রহণ দরকার   | ডেটা করাপশন সনাক্তকরণ        |
| emergency  | সিস্টেম অচল                   | সম্পূর্ণ সিস্টেম ব্যর্থতা      |

## MCP তে নোটিফিকেশন ইমপ্লিমেন্ট করা

MCP তে নোটিফিকেশন ইমপ্লিমেন্ট করতে হলে সার্ভার এবং ক্লায়েন্ট উভয়কেই রিয়েল-টাইম আপডেট হ্যান্ডেল করার জন্য সেটআপ করতে হবে। এর ফলে দীর্ঘমেয়াদি অপারেশনের সময় ব্যবহারকারীদের অবিলম্বে ফিডব্যাক দেওয়া সম্ভব হয়।

### সার্ভার-সাইড: নোটিফিকেশন পাঠানো

চলুন সার্ভার সাইড থেকে শুরু করি। MCP তে আপনি এমন টুল ডিফাইন করেন যা অনুরোধ প্রক্রিয়াকরণের সময় নোটিফিকেশন পাঠাতে পারে। সার্ভার সাধারণত `ctx` নামে কনটেক্সট অবজেক্ট ব্যবহার করে ক্লায়েন্টকে বার্তা পাঠায়।

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

আগের উদাহরণে, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ট্রান্সপোর্ট ব্যবহার করা হয়েছে:

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

এই .NET উদাহরণে, `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` মেথড ব্যবহার করে তথ্যবহুল বার্তা পাঠানো হয়।

আপনার .NET MCP সার্ভারে নোটিফিকেশন সক্ষম করতে নিশ্চিত করুন যে আপনি স্ট্রিমিং ট্রান্সপোর্ট ব্যবহার করছেন:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### ক্লায়েন্ট-সাইড: নোটিফিকেশন গ্রহণ

ক্লায়েন্টকে একটি মেসেজ হ্যান্ডলার ইমপ্লিমেন্ট করতে হবে যা আসা নোটিফিকেশনগুলো প্রক্রিয়া এবং প্রদর্শন করবে।

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

উপরের কোডে, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` আসা নোটিফিকেশন হ্যান্ডেল করতে ব্যবহৃত হয়।

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

এই .NET উদাহরণে, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` ব্যবহার করে ক্লায়েন্ট নোটিফিকেশন হ্যান্ডলার ইমপ্লিমেন্ট করেছে।

## প্রগ্রেস নোটিফিকেশন এবং পরিস্থিতি

এই অংশে MCP তে প্রগ্রেস নোটিফিকেশন এর ধারণা, এর গুরুত্ব এবং Streamable HTTP ব্যবহার করে কিভাবে ইমপ্লিমেন্ট করবেন তা ব্যাখ্যা করা হয়েছে। এছাড়াও একটি ব্যবহারিক অ্যাসাইনমেন্ট রয়েছে যা আপনার বোঝাপড়া শক্তিশালী করবে।

প্রগ্রেস নোটিফিকেশন হলো সার্ভার থেকে ক্লায়েন্টে পাঠানো রিয়েল-টাইম বার্তা যা দীর্ঘমেয়াদি অপারেশনের সময় বর্তমান অবস্থা জানায়। পুরো প্রক্রিয়া শেষ হওয়ার জন্য অপেক্ষা না করে সার্ভার ক্লায়েন্টকে আপডেট রাখে। এটি স্বচ্ছতা, ব্যবহারকারীর অভিজ্ঞতা উন্নত করে এবং ডিবাগিং সহজ করে।

**উদাহরণ:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### কেন প্রগ্রেস নোটিফিকেশন ব্যবহার করবেন?

প্রগ্রেস নোটিফিকেশন গুরুত্বপূর্ণ কারণ:

- **ভালো ব্যবহারকারীর অভিজ্ঞতা:** কাজ চলাকালীন আপডেট দেখা যায়, শুধু শেষে নয়।
- **রিয়েল-টাইম ফিডব্যাক:** ক্লায়েন্ট প্রগ্রেস বার বা লগ দেখাতে পারে, অ্যাপটি প্রতিক্রিয়াশীল মনে হয়।
- **সহজ ডিবাগিং ও মনিটরিং:** ডেভেলপার ও ব্যবহারকারী বুঝতে পারে কোন ধাপে প্রক্রিয়া ধীর বা আটকে আছে।

### কিভাবে প্রগ্রেস নোটিফিকেশন ইমপ্লিমেন্ট করবেন

এভাবে MCP তে প্রগ্রেস নোটিফিকেশন ইমপ্লিমেন্ট করা যায়:

- **সার্ভারে:** প্রতিটি আইটেম প্রক্রিয়াকরণের সময় `ctx.info()` or `ctx.log()` ব্যবহার করে নোটিফিকেশন পাঠান। এটি প্রধান ফলাফল প্রস্তুত হওয়ার আগে ক্লায়েন্টকে বার্তা পাঠায়।
- **ক্লায়েন্টে:** একটি মেসেজ হ্যান্ডলার ইমপ্লিমেন্ট করুন যা আসা নোটিফিকেশনগুলো শুনে এবং প্রদর্শন করে। এই হ্যান্ডলার নোটিফিকেশন ও চূড়ান্ত ফলাফল আলাদা করে।

**সার্ভার উদাহরণ:**

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

**ক্লায়েন্ট উদাহরণ:**

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

## নিরাপত্তা বিষয়াবলী

HTTP ভিত্তিক ট্রান্সপোর্ট ব্যবহার করে MCP সার্ভার ইমপ্লিমেন্ট করার সময় নিরাপত্তা একটি প্রধান বিষয় যা বিভিন্ন আক্রমণ ভেক্টর এবং সুরক্ষা ব্যবস্থা সম্পর্কে সতর্কতা প্রয়োজন।

### ওভারভিউ

HTTP এর মাধ্যমে MCP সার্ভার প্রকাশ করার সময় নিরাপত্তা অপরিহার্য। Streamable HTTP নতুন আক্রমণ পৃষ্ঠার সৃষ্টি করে এবং সঠিক কনফিগারেশন প্রয়োজন।

### মূল বিষয়াবলী
- **Origin Header যাচাই**: সবসময় `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` যাচাই করুন, SSE ক্লায়েন্টের পরিবর্তে।
3. **ক্লায়েন্টে একটি মেসেজ হ্যান্ডলার ইমপ্লিমেন্ট করুন** যা নোটিফিকেশন প্রক্রিয়া করবে।
4. **বিদ্যমান টুল এবং ওয়ার্কফ্লোর সাথে সামঞ্জস্য পরীক্ষা করুন।**

### সামঞ্জস্যতা বজায় রাখা

মাইগ্রেশন প্রক্রিয়ায় বিদ্যমান SSE ক্লায়েন্টের সাথে সামঞ্জস্যতা বজায় রাখা সুপারিশ করা হয়। কয়েকটি কৌশল:

- SSE এবং Streamable HTTP উভয় ট্রান্সপোর্ট আলাদা এন্ডপয়েন্টে চালানো যেতে পারে।
- ধাপে ধাপে ক্লায়েন্টদের নতুন ট্রান্সপোর্টে স্থানান্তর করা।

### চ্যালেঞ্জসমূহ

মাইগ্রেশনের সময় নিম্নলিখিত চ্যালেঞ্জগুলো মোকাবেলা করতে হবে:

- নিশ্চিত করা যে সব ক্লায়েন্ট আপডেট হয়েছে
- নোটিফিকেশন ডেলিভারিতে পার্থক্য সামলানো

### অ্যাসাইনমেন্ট: নিজের স্ট্রিমিং MCP অ্যাপ তৈরি করুন

**পরিস্থিতি:**
একটি MCP সার্ভার এবং ক্লায়েন্ট তৈরি করুন যেখানে সার্ভার একটি আইটেম তালিকা (যেমন, ফাইল বা ডকুমেন্ট) প্রক্রিয়া করে এবং প্রতিটি আইটেম প্রক্রিয়াকরণের পর একটি নোটিফিকেশন পাঠায়। ক্লায়েন্ট প্রতিটি নোটিফিকেশন পাওয়ার সাথে সাথে প্রদর্শন করবে।

**ধাপসমূহ

**অস্বীকারোক্তি**:  
এই ডকুমেন্টটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে অনুগ্রহ করে মনে রাখবেন যে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা ভুল থাকতে পারে। মূল ডকুমেন্ট তার স্বাভাবিক ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।