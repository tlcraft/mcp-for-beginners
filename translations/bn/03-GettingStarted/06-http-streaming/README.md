<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:02:09+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "bn"
}
-->
# HTTPS স্ট্রিমিং মডেল কনটেক্সট প্রোটোকল (MCP) দিয়ে

এই অধ্যায়টি HTTPS ব্যবহার করে মডেল কনটেক্সট প্রোটোকল (MCP) এর মাধ্যমে নিরাপদ, স্কেলেবল এবং রিয়েল-টাইম স্ট্রিমিং বাস্তবায়নের ব্যাপক নির্দেশিকা দেয়। এতে স্ট্রিমিং এর প্রেরণা, উপলব্ধ ট্রান্সপোর্ট মেকানিজম, MCP-তে স্ট্রিমেবল HTTP কীভাবে বাস্তবায়ন করবেন, নিরাপত্তার সেরা অভ্যাস, SSE থেকে মাইগ্রেশন এবং নিজের স্ট্রিমিং MCP অ্যাপ্লিকেশন তৈরি করার ব্যবহারিক নির্দেশনা অন্তর্ভুক্ত রয়েছে।

## MCP-তে ট্রান্সপোর্ট মেকানিজম এবং স্ট্রিমিং

এই অংশে MCP-তে উপলব্ধ বিভিন্ন ট্রান্সপোর্ট মেকানিজম এবং কিভাবে এগুলো ক্লায়েন্ট ও সার্ভারের মধ্যে রিয়েল-টাইম কমিউনিকেশন সক্ষম করে তা আলোচনা করা হয়েছে।

### ট্রান্সপোর্ট মেকানিজম কী?

ট্রান্সপোর্ট মেকানিজম নির্ধারণ করে কিভাবে ডেটা ক্লায়েন্ট এবং সার্ভারের মধ্যে আদান-প্রদান হয়। MCP বিভিন্ন পরিবেশ ও প্রয়োজনের জন্য একাধিক ট্রান্সপোর্ট টাইপ সমর্থন করে:

- **stdio**: স্ট্যান্ডার্ড ইনপুট/আউটপুট, লোকাল এবং CLI-ভিত্তিক টুলের জন্য উপযুক্ত। সহজ কিন্তু ওয়েব বা ক্লাউডের জন্য উপযুক্ত নয়।
- **SSE (Server-Sent Events)**: সার্ভার HTTP-এর মাধ্যমে ক্লায়েন্টকে রিয়েল-টাইম আপডেট পাঠাতে দেয়। ওয়েব UI-এর জন্য ভালো, তবে স্কেলেবিলিটি ও নমনীয়তার সীমাবদ্ধতা আছে।
- **Streamable HTTP**: আধুনিক HTTP ভিত্তিক স্ট্রিমিং ট্রান্সপোর্ট, নোটিফিকেশন এবং উন্নত স্কেলেবিলিটি সমর্থন করে। অধিকাংশ প্রোডাকশন এবং ক্লাউড পরিস্থিতির জন্য সুপারিশকৃত।

### তুলনা টেবিল

নিচের তুলনা টেবিল দেখে বিভিন্ন ট্রান্সপোর্ট মেকানিজমের পার্থক্য বুঝুন:

| Transport         | রিয়েল-টাইম আপডেট | স্ট্রিমিং | স্কেলেবিলিটি | ব্যবহারের ক্ষেত্র           |
|-------------------|------------------|-----------|-------------|----------------------------|
| stdio             | না               | না        | কম          | লোকাল CLI টুল              |
| SSE               | হ্যাঁ             | হ্যাঁ      | মাঝারি       | ওয়েব, রিয়েল-টাইম আপডেট  |
| Streamable HTTP   | হ্যাঁ             | হ্যাঁ      | উচ্চ         | ক্লাউড, মাল্টি-ক্লায়েন্ট  |

> **টিপ:** সঠিক ট্রান্সপোর্ট নির্বাচন কর্মক্ষমতা, স্কেলেবিলিটি এবং ব্যবহারকারীর অভিজ্ঞতায় প্রভাব ফেলে। আধুনিক, স্কেলেবল এবং ক্লাউড-রেডি অ্যাপ্লিকেশনের জন্য **Streamable HTTP** সুপারিশকৃত।

আগের অধ্যায়ে stdio এবং SSE ট্রান্সপোর্ট দেখানো হয়েছে এবং এই অধ্যায়ে Streamable HTTP ট্রান্সপোর্ট আলোচনা করা হয়েছে।

## স্ট্রিমিং: ধারণা ও প্রেরণা

স্ট্রিমিং এর মৌলিক ধারণা ও প্রেরণা বোঝা কার্যকর রিয়েল-টাইম কমিউনিকেশন সিস্টেম বাস্তবায়নের জন্য অপরিহার্য।

**স্ট্রিমিং** হলো নেটওয়ার্ক প্রোগ্রামিং এর একটি কৌশল যা ডেটা ছোট ছোট অংশে বা ইভেন্ট সিরিজ আকারে পাঠানো ও গ্রহণের সুযোগ দেয়, পুরো রেসপন্স সম্পূর্ণ হওয়ার জন্য অপেক্ষা না করেই। এটি বিশেষভাবে উপযোগী:

- বড় ফাইল বা ডেটাসেটের জন্য।
- রিয়েল-টাইম আপডেট (যেমন চ্যাট, প্রগ্রেস বার)।
- দীর্ঘমেয়াদী গণনার ক্ষেত্রে যেখানে ব্যবহারকারীকে অবহিত রাখা দরকার।

স্ট্রিমিং সম্পর্কে উচ্চ স্তরের কিছু তথ্য:

- ডেটা ধাপে ধাপে সরবরাহ করা হয়, একসাথে নয়।
- ক্লায়েন্ট ডেটা আসার সাথে সাথেই প্রক্রিয়া করতে পারে।
- ধারণাগত লেটেন্সি কমায় এবং ব্যবহারকারীর অভিজ্ঞতা উন্নত করে।

### কেন স্ট্রিমিং ব্যবহার করবেন?

স্ট্রিমিং ব্যবহারের কারণসমূহ:

- ব্যবহারকারী তৎক্ষণাৎ প্রতিক্রিয়া পায়, শুধু শেষে নয়।
- রিয়েল-টাইম অ্যাপ্লিকেশন ও প্রতিক্রিয়াশীল UI সম্ভব করে।
- নেটওয়ার্ক ও কম্পিউটিং রিসোর্সের আরও কার্যকর ব্যবহার।

### সহজ উদাহরণ: HTTP স্ট্রিমিং সার্ভার ও ক্লায়েন্ট

নিচে স্ট্রিমিং কীভাবে বাস্তবায়ন করা যায় তার একটি সহজ উদাহরণ:

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

এই উদাহরণে সার্ভার ক্লায়েন্টকে বার্তা গুলো পাওয়ার সাথে সাথে পাঠায়, সব বার্তা একসাথে অপেক্ষা করে না।

**কিভাবে কাজ করে:**
- সার্ভার প্রতিটি বার্তা প্রস্তুত হওয়ার সাথে সাথে পাঠায়।
- ক্লায়েন্ট বার্তা আসার সাথে সাথে গ্রহণ ও প্রদর্শন করে।

**প্রয়োজনীয়তা:**
- সার্ভার স্ট্রিমিং রেসপন্স ব্যবহার করবে (যেমন `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) MCP এর মাধ্যমে স্ট্রিমিং নির্বাচন করার পরিবর্তে।

- **সহজ স্ট্রিমিংয়ের জন্য:** ক্লাসিক HTTP স্ট্রিমিং সহজে বাস্তবায়নযোগ্য এবং মৌলিক স্ট্রিমিং প্রয়োজনের জন্য যথেষ্ট।

- **জটিল, ইন্টারেক্টিভ অ্যাপ্লিকেশনের জন্য:** MCP স্ট্রিমিং আরও কাঠামোবদ্ধ পদ্ধতি দেয়, যা উন্নত মেটাডেটা এবং নোটিফিকেশন ও চূড়ান্ত ফলাফলের পৃথকীকরণ প্রদান করে।

- **AI অ্যাপ্লিকেশনের জন্য:** MCP এর নোটিফিকেশন সিস্টেম দীর্ঘমেয়াদী AI কাজের জন্য বিশেষভাবে উপযোগী যেখানে ব্যবহারকারীকে অগ্রগতি সম্পর্কে অবহিত রাখা হয়।

## MCP-তে স্ট্রিমিং

আপনি এখন পর্যন্ত ক্লাসিক স্ট্রিমিং এবং MCP স্ট্রিমিংয়ের মধ্যে পার্থক্য সম্পর্কে কিছু সুপারিশ এবং তুলনা দেখেছেন। এখন বিস্তারিতভাবে জানব কিভাবে MCP তে স্ট্রিমিং ব্যবহার করবেন।

MCP ফ্রেমওয়ার্কে স্ট্রিমিং কীভাবে কাজ করে তা বোঝা জরুরি, যাতে দীর্ঘমেয়াদী অপারেশনের সময় ব্যবহারকারীদের রিয়েল-টাইম ফিডব্যাক প্রদান করে প্রতিক্রিয়াশীল অ্যাপ্লিকেশন তৈরি করা যায়।

MCP তে স্ট্রিমিং মানে প্রধান রেসপন্স টুকরো করে পাঠানো নয়, বরং টুল যখন অনুরোধ প্রক্রিয়াকরণ করছে তখন ক্লায়েন্টকে **নোটিফিকেশন** পাঠানো। এই নোটিফিকেশনগুলোতে প্রগ্রেস আপডেট, লগ অথবা অন্যান্য ইভেন্ট থাকতে পারে।

### কিভাবে কাজ করে

প্রধান ফলাফল এখনও একক রেসপন্স হিসেবে পাঠানো হয়। তবে, প্রক্রিয়াকরণের সময় নোটিফিকেশন আলাদা বার্তা হিসেবে পাঠানো হয় এবং এর মাধ্যমে ক্লায়েন্টকে রিয়েল-টাইমে আপডেট করা হয়। ক্লায়েন্টকে এই নোটিফিকেশনগুলো গ্রহণ ও প্রদর্শন করতে সক্ষম হতে হবে।

## নোটিফিকেশন কী?

আমরা বলেছি "নোটিফিকেশন", MCP এর প্রেক্ষাপটে এর অর্থ কী?

নোটিফিকেশন হলো সার্ভার থেকে ক্লায়েন্টকে পাঠানো একটি বার্তা যা দীর্ঘমেয়াদী অপারেশনের সময় অগ্রগতি, অবস্থা বা অন্যান্য ইভেন্ট সম্পর্কে জানায়। নোটিফিকেশন স্বচ্ছতা এবং ব্যবহারকারীর অভিজ্ঞতা উন্নত করে।

উদাহরণস্বরূপ, ক্লায়েন্টকে একটি নোটিফিকেশন পাঠাতে হবে যখন সার্ভারের সাথে প্রাথমিক হ্যান্ডশেক সম্পন্ন হয়।

নোটিফিকেশন JSON বার্তা হিসেবে দেখতে এমন:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

নোটিফিকেশন MCP-তে ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) নামে একটি টপিকের অন্তর্গত।

লগিং কাজ করার জন্য, সার্ভারকে এটি ফিচার/ক্ষমতা হিসেবে সক্ষম করতে হবে যেমন:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> ব্যবহৃত SDK অনুসারে, লগিং ডিফল্টরূপে সক্ষম থাকতে পারে অথবা আপনাকে সার্ভার কনফিগারেশনে এটি স্পষ্টভাবে সক্ষম করতে হতে পারে।

নোটিফিকেশনের বিভিন্ন ধরণ রয়েছে:

| স্তর       | বর্ণনা                         | উদাহরণ ব্যবহারের ক্ষেত্র         |
|------------|-------------------------------|---------------------------------|
| debug      | বিস্তারিত ডিবাগিং তথ্য          | ফাংশন এন্ট্রি/এক্সিট পয়েন্ট    |
| info       | সাধারণ তথ্যবহুল বার্তা          | অপারেশন প্রগ্রেস আপডেট          |
| notice     | স্বাভাবিক কিন্তু গুরুত্বপূর্ণ ইভেন্ট | কনফিগারেশন পরিবর্তন           |
| warning    | সতর্কতা শর্তাবলী               | অব্যবহৃত ফিচারের ব্যবহার       |
| error      | ত্রুটি শর্তাবলী                | অপারেশন ব্যর্থতা                |
| critical   | গুরুতর শর্তাবলী               | সিস্টেম কম্পোনেন্ট ব্যর্থতা      |
| alert      | অবিলম্বে পদক্ষেপ গ্রহণ প্রয়োজন | ডেটা ক্ষয়ক্ষতি সনাক্তকরণ      |
| emergency  | সিস্টেম ব্যবহারযোগ্য নয়       | সম্পূর্ণ সিস্টেম ব্যর্থতা        |

## MCP-তে নোটিফিকেশন বাস্তবায়ন

MCP-তে নোটিফিকেশন বাস্তবায়নের জন্য সার্ভার ও ক্লায়েন্ট উভয় পক্ষকে রিয়েল-টাইম আপডেট পরিচালনা করার জন্য সেটআপ করতে হবে। এতে দীর্ঘমেয়াদী অপারেশনের সময় ব্যবহারকারীদের তাত্ক্ষণিক ফিডব্যাক প্রদান সম্ভব হয়।

### সার্ভার-সাইড: নোটিফিকেশন পাঠানো

সার্ভার সাইড থেকে শুরু করা যাক। MCP তে আপনি এমন টুল সংজ্ঞায়িত করেন যা অনুরোধ প্রক্রিয়াকরণের সময় নোটিফিকেশন পাঠাতে পারে। সার্ভার ক্লায়েন্টকে বার্তা পাঠাতে context অবজেক্ট (সাধারণত `ctx`) ব্যবহার করে।

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

উপরের উদাহরণে, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ট্রান্সপোর্ট ব্যবহার করা হয়েছে:

```python
mcp.run(transport="streamable-http")
```

</details>

### ক্লায়েন্ট-সাইড: নোটিফিকেশন গ্রহণ

ক্লায়েন্টকে একটি মেসেজ হ্যান্ডলার বাস্তবায়ন করতে হবে যা নোটিফিকেশন আসার সাথে সাথেই প্রক্রিয়া ও প্রদর্শন করবে।

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

উপরের কোডে, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` এবং ক্লায়েন্ট নোটিফিকেশন প্রক্রিয়াকরণের জন্য একটি মেসেজ হ্যান্ডলার বাস্তবায়ন করেছে।

## প্রগ্রেস নোটিফিকেশন ও পরিস্থিতি

এই অংশে MCP তে প্রগ্রেস নোটিফিকেশনের ধারণা, এর গুরুত্ব এবং Streamable HTTP ব্যবহার করে কিভাবে এটি বাস্তবায়ন করবেন তা ব্যাখ্যা করা হয়েছে। এছাড়াও একটি ব্যবহারিক অ্যাসাইনমেন্ট রয়েছে যা আপনার বোঝাপড়াকে আরও দৃঢ় করবে।

প্রগ্রেস নোটিফিকেশন হলো সার্ভার থেকে ক্লায়েন্টকে দীর্ঘমেয়াদী অপারেশনের সময় রিয়েল-টাইমে পাঠানো বার্তা। পুরো প্রক্রিয়া শেষ হওয়ার জন্য অপেক্ষা না করে সার্ভার ক্লায়েন্টকে বর্তমান অবস্থা সম্পর্কে জানায়। এতে স্বচ্ছতা, ব্যবহারকারীর অভিজ্ঞতা উন্নত হয় এবং ডিবাগিং সহজ হয়।

**উদাহরণ:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### কেন প্রগ্রেস নোটিফিকেশন ব্যবহার করবেন?

প্রগ্রেস নোটিফিকেশন ব্যবহারের কারণসমূহ:

- **ভালো ব্যবহারকারীর অভিজ্ঞতা:** কাজ চলাকালীন আপডেট দেখা যায়, শুধু শেষে নয়।
- **রিয়েল-টাইম ফিডব্যাক:** ক্লায়েন্ট প্রগ্রেস বার বা লগ দেখাতে পারে, অ্যাপ্লিকেশন প্রতিক্রিয়াশীল মনে হয়।
- **সহজ ডিবাগিং ও মনিটরিং:** ডেভেলপার ও ব্যবহারকারী বুঝতে পারে প্রক্রিয়াটি কোথায় ধীর বা আটকে আছে।

### কিভাবে প্রগ্রেস নোটিফিকেশন বাস্তবায়ন করবেন

MCP তে প্রগ্রেস নোটিফিকেশন বাস্তবায়নের পদ্ধতি:

- **সার্ভারে:** `ctx.info()` or `ctx.log()` ব্যবহার করে প্রতিটি আইটেম প্রক্রিয়াকরণের সময় নোটিফিকেশন পাঠান। এটি প্রধান ফলাফল প্রস্তুত হওয়ার আগে ক্লায়েন্টকে বার্তা পাঠায়।
- **ক্লায়েন্টে:** একটি মেসেজ হ্যান্ডলার বাস্তবায়ন করুন যা নোটিফিকেশন আসার সাথে সাথেই শুনবে এবং প্রদর্শন করবে। এই হ্যান্ডলার নোটিফিকেশন ও চূড়ান্ত ফলাফল আলাদা করতে সক্ষম।

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

## নিরাপত্তা বিবেচনা

HTTP ভিত্তিক ট্রান্সপোর্ট সহ MCP সার্ভার বাস্তবায়নের সময় নিরাপত্তা একটি গুরুত্বপূর্ণ বিষয় যা বিভিন্ন আক্রমণ ভেক্টর ও সুরক্ষা প্রক্রিয়া সম্পর্কে সতর্ক মনোযোগ দাবি করে।

### সংক্ষিপ্ত বিবরণ

HTTP এর মাধ্যমে MCP সার্ভার প্রকাশ করার সময় নিরাপত্তা অত্যন্ত গুরুত্বপূর্ণ। Streamable HTTP নতুন আক্রমণের সুযোগ সৃষ্টি করে এবং সঠিক কনফিগারেশন প্রয়োজন।

### প্রধান পয়েন্টসমূহ
- **Origin Header যাচাই:** সর্বদা `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` যাচাই করুন SSE ক্লায়েন্টের পরিবর্তে।
3. **ক্লায়েন্টে মেসেজ হ্যান্ডলার বাস্তবায়ন করুন** নোটিফিকেশন প্রক্রিয়াকরণের জন্য।
4. **বিদ্যমান টুল ও ওয়ার্কফ্লো এর সাথে সামঞ্জস্য পরীক্ষা করুন।**

### সামঞ্জস্য বজায় রাখা

মাইগ্রেশন প্রক্রিয়ায় বিদ্যমান SSE ক্লায়েন্টের সাথে সামঞ্জস্য বজায় রাখা সুপারিশ করা হয়। কিছু কৌশল:

- SSE ও Streamable HTTP উভয় ট্রান্সপোর্ট আলাদা এন্ডপয়েন্টে চালিয়ে সমর্থন করা যায়।
- ধাপে ধাপে ক্লায়েন্টদের নতুন ট্রান্সপোর্টে স্থানান্তর করা।

### চ্যালেঞ্জসমূহ

মাইগ্রেশনের সময় নিম্নলিখিত চ্যালেঞ্জ মোকাবেলা করতে হবে:

- নিশ্চিত করা যে সকল ক্লায়েন্ট আপডেট হয়েছে
- নোটিফিকেশন ডেলিভারির পার্থক্যগুলি সামলানো

### অ্যাসাইনমেন্ট: নিজের স্ট্রিমিং MCP অ্যাপ তৈরি করুন

**পরিস্থিতি:**
একটি MCP সার্ভার ও ক্লায়েন্ট তৈরি করুন যেখানে সার্ভার একটি আইটেম তালিকা (যেমন ফাইল বা ডকুমেন্ট) প্রক্রিয়াকরণ করে এবং প্রতিটি প্রক্রিয়াকৃত আইটেমের জন্য একটি নোটিফিকেশন পাঠায়। ক্লায়েন্ট প্রতিটি নোটিফিকেশন আসার সাথে সাথেই প্রদর্শন করবে।

**ধাপসমূহ:**

1. একটি সার্ভার টুল বাস্তবায়ন করুন যা তালিকা প্রক্রিয়াকরণ করে এবং প্রতিটি আইটেমের জন্য নোটিফিকেশন পাঠায়।
2. একটি ক্লায়েন্ট বাস্তবায়ন করুন যার মেসেজ হ্যান্ডলার আছে যা রিয়েল-টাইমে নোটিফিকেশন প্রদর্শন করে।
3. আপনার বাস্তবায়ন পরীক্ষা করুন সার্ভার ও ক্লায়েন্ট উভয় চালিয়ে এবং নোটিফিকেশনগুলো পর্যবেক্ষণ করুন।

[Solution](./solution/README.md)

## আরও পড়াশোনা ও পরবর্তী ধাপ

MCP স্ট্রিমিং নিয়ে আপনার যাত্রা চালিয়ে যেতে এবং জ্ঞান বৃদ্ধি করতে এই অংশে অতিরিক্ত সম্পদ এবং উন্নত অ্যাপ্লিকেশন তৈরি করার জন্য পরবর্তী ধাপের সুপারিশ দেওয়া হয়েছে।

### আরও পড়াশোনা

- [Microsoft: HTTP স্ট্রিমিং পরিচিতি](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core-এ CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id

**অস্বীকারোক্তি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার মাতৃভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদের ব্যবহার থেকে উদ্ভূত কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়বদ্ধ নয়।