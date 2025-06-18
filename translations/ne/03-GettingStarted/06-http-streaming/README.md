<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:55:17+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ne"
}
-->
# HTTPS स्ट्रिमिङ मोडेल कन्टेक्स्ट प्रोटोकल (MCP) सँग

यस अध्यायले HTTPS प्रयोग गरी मोडेल कन्टेक्स्ट प्रोटोकल (MCP) सँग सुरक्षित, स्केलेबल, र रियल-टाइम स्ट्रिमिङ कसरी कार्यान्वयन गर्ने बारे विस्तृत मार्गदर्शन प्रदान गर्दछ। यसमा स्ट्रिमिङको प्रेरणा, उपलब्ध ट्रान्सपोर्ट मेकानिज्महरू, MCP मा स्ट्रिमेबल HTTP कसरी कार्यान्वयन गर्ने, सुरक्षा सर्वोत्तम अभ्यासहरू, SSE बाट माइग्रेशन, र आफ्नै स्ट्रिमिङ MCP अनुप्रयोगहरू निर्माण गर्ने व्यावहारिक निर्देशनहरू समावेश छन्।

## MCP मा ट्रान्सपोर्ट मेकानिज्महरू र स्ट्रिमिङ

यस भागले MCP मा उपलब्ध विभिन्न ट्रान्सपोर्ट मेकानिज्महरू र तीले ग्राहक र सर्भरबीचको रियल-टाइम सञ्चारका लागि स्ट्रिमिङ क्षमता कसरी सक्षम पार्छन् भनी अन्वेषण गर्दछ।

### ट्रान्सपोर्ट मेकानिज्म के हो?

ट्रान्सपोर्ट मेकानिज्मले डाटा ग्राहक र सर्भरबीच कसरी आदानप्रदान हुन्छ भनेर परिभाषित गर्छ। MCP ले विभिन्न वातावरण र आवश्यकताहरूलाई मेल खाने धेरै ट्रान्सपोर्ट प्रकारहरू समर्थन गर्छ:

- **stdio**: स्ट्यान्डर्ड इनपुट/आउटपुट, स्थानीय र CLI-आधारित उपकरणहरूको लागि उपयुक्त। सरल तर वेब वा क्लाउडका लागि उपयुक्त छैन।
- **SSE (Server-Sent Events)**: सर्भरहरूले HTTP मार्फत ग्राहकहरूलाई रियल-टाइम अपडेट पठाउन अनुमति दिन्छ। वेब UI का लागि राम्रो, तर स्केलेबिलिटी र लचिलोपनमा सीमित।
- **Streamable HTTP**: आधुनिक HTTP-आधारित स्ट्रिमिङ ट्रान्सपोर्ट, सूचना र राम्रो स्केलेबिलिटी समर्थन गर्दछ। अधिकांश उत्पादन र क्लाउड परिदृश्यहरूका लागि सिफारिस गरिन्छ।

### तुलना तालिका

तलको तुलना तालिका हेर्नुहोस् जसले यी ट्रान्सपोर्ट मेकानिज्महरू बीचको भिन्नता बुझ्न मद्दत गर्छ:

| ट्रान्सपोर्ट        | रियल-टाइम अपडेटहरू | स्ट्रिमिङ | स्केलेबिलिटी | प्रयोग केस                |
|--------------------|---------------------|-----------|--------------|--------------------------|
| stdio              | छैन                 | छैन       | कम           | स्थानीय CLI उपकरणहरू     |
| SSE                | छ                  | छ        | मध्यम        | वेब, रियल-टाइम अपडेटहरू |
| Streamable HTTP    | छ                  | छ        | उच्च         | क्लाउड, बहु-ग्राहक      |

> **टिप:** सही ट्रान्सपोर्ट छनोटले प्रदर्शन, स्केलेबिलिटी, र प्रयोगकर्ता अनुभवमा प्रभाव पार्छ। आधुनिक, स्केलेबल, र क्लाउड-तयार अनुप्रयोगहरूका लागि **Streamable HTTP** सिफारिस गरिन्छ।

अघिल्लो अध्यायहरूमा देखाइएका stdio र SSE ट्रान्सपोर्टहरूलाई ध्यान दिनुहोस् र यस अध्यायमा समेटिएको Streamable HTTP ट्रान्सपोर्टलाई बुझ्नुहोस्।

## स्ट्रिमिङ: अवधारणा र प्रेरणा

स्ट्रिमिङको आधारभूत अवधारणा र प्रेरणाहरू बुझ्न र प्रभावकारी रियल-टाइम सञ्चार प्रणालीहरू कार्यान्वयन गर्न आवश्यक छ।

**स्ट्रिमिङ** नेटवर्क प्रोग्रामिङमा यस्तो प्रविधि हो जसले डाटालाई साना, व्यवस्थापनयोग्य भागहरूमा वा घटनाहरूको अनुक्रमको रूपमा पठाउन र प्राप्त गर्न अनुमति दिन्छ, सम्पूर्ण जवाफ तयार हुन कुर्नुको सट्टा। यो विशेष गरी उपयोगी छ:

- ठूलो फाइल वा डाटासेटहरूका लागि।
- रियल-टाइम अपडेटहरू (जस्तै, च्याट, प्रोग्रेस बारहरू)।
- लामो समयसम्म चल्ने गणनाहरू जहाँ प्रयोगकर्तालाई अपडेट राख्न चाहिन्छ।

स्ट्रिमिङको उच्च स्तरमा तपाईंले जान्नुपर्ने कुरा:

- डाटा क्रमशः पठाइन्छ, सबै एकैपटक होइन।
- ग्राहकले डाटा प्राप्त भएसँगै प्रशोधन गर्न सक्छ।
- अनुमानित ढिलाइ घटाउँछ र प्रयोगकर्ता अनुभव सुधार्छ।

### किन स्ट्रिमिङ प्रयोग गर्ने?

स्ट्रिमिङ प्रयोग गर्ने कारणहरू:

- प्रयोगकर्ताले तुरुन्त प्रतिक्रिया पाउँछन्, अन्त्यमा मात्र होइन।
- रियल-टाइम अनुप्रयोग र प्रतिक्रिया दिने UI सक्षम पार्छ।
- नेटवर्क र कम्प्युटिङ स्रोतहरूको बढी प्रभावकारी उपयोग।

### सरल उदाहरण: HTTP स्ट्रिमिङ सर्भर र क्लाइन्ट

यहाँ स्ट्रिमिङ कसरी कार्यान्वयन गर्न सकिन्छ भन्ने सरल उदाहरण छ:

<details>
<summary>Python</summary>

**सर्भर (Python, FastAPI र StreamingResponse प्रयोग गरी):**
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

**क्लाइन्ट (Python, requests प्रयोग गरी):**
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

यो उदाहरणले देखाउँछ कि सर्भरले सन्देशहरू तयार हुनासाथ क्रमशः ग्राहकलाई पठाउँछ, सम्पूर्ण सन्देश तयार हुन कुर्नु हुँदैन।

**यसले कसरी काम गर्छ:**
- सर्भर प्रत्येक सन्देश तयार भएमा पठाउँछ।
- ग्राहक प्रत्येक भाग प्राप्त भएसँगै प्रिन्ट गर्छ।

**आवश्यकताहरू:**
- सर्भरले स्ट्रिमिङ प्रतिक्रिया प्रयोग गर्नुपर्छ (जस्तै, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`।

</details>

<details>
<summary>Java</summary>

**सर्भर (Java, Spring Boot र Server-Sent Events प्रयोग गरी):**

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

**क्लाइन्ट (Java, Spring WebFlux WebClient प्रयोग गरी):**

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

**Java कार्यान्वयन नोटहरू:**
- Spring Boot को प्रतिक्रियाशील स्ट्याक प्रयोग गर्दछ `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) सँग तुलना गर्दा MCP मार्फत स्ट्रिमिङ छनोट गर्ने।

- **सरल स्ट्रिमिङ आवश्यकताहरूका लागि:** क्लासिक HTTP स्ट्रिमिङ कार्यान्वयन गर्न सजिलो र आधारभूत स्ट्रिमिङका लागि पर्याप्त छ।

- **जटिल, अन्तरक्रियात्मक अनुप्रयोगहरूका लागि:** MCP स्ट्रिमिङले अधिक संरचित तरिका र धनी मेटाडाटा र सूचना र अन्तिम नतिजाबीच अलगाव प्रदान गर्दछ।

- **AI अनुप्रयोगहरूका लागि:** MCP को सूचना प्रणाली लामो समयसम्म चल्ने AI कार्यहरूको लागि विशेष गरी उपयोगी छ जहाँ प्रगति प्रयोगकर्तालाई जानकारी गराउन आवश्यक हुन्छ।

## MCP मा स्ट्रिमिङ

अबसम्म तपाईंले क्लासिक स्ट्रिमिङ र MCP मा स्ट्रिमिङ बीचका फरकहरूका बारेमा सिफारिस र तुलना देख्नुभएको छ। अब विस्तारमा जान्छौं कि MCP मा कसरी स्ट्रिमिङ प्रयोग गर्न सकिन्छ।

MCP फ्रेमवर्कभित्र स्ट्रिमिङ कसरी काम गर्छ भन्ने बुझ्नाले लामो समयसम्म चल्ने अपरेसनहरूमा प्रयोगकर्तालाई रियल-टाइम प्रतिक्रिया दिने प्रतिक्रियाशील अनुप्रयोगहरू निर्माण गर्न मद्दत गर्छ।

MCP मा, स्ट्रिमिङ मुख्य जवाफलाई टुक्रामा पठाउने होइन, तर उपकरणले अनुरोध प्रक्रिया गर्दा ग्राहकलाई **सूचनाहरू** पठाउने कुरा हो। यी सूचनाहरूमा प्रगति अपडेट, लगहरू, वा अन्य घटनाहरू समावेश हुन सक्छन्।

### कसरी काम गर्छ

मुख्य नतिजा अझै पनि एकल जवाफको रूपमा पठाइन्छ। तर प्रक्रिया भइरहेको बेला सूचनाहरू अलग सन्देशका रूपमा पठाउन सकिन्छ जसले ग्राहकलाई रियल-टाइममा अपडेट गर्छ। ग्राहकले यी सूचनाहरूलाई सम्हाल्न र प्रदर्शन गर्न सक्षम हुनुपर्छ।

## सूचना के हो?

हामीले "सूचना" भनेका छौं, MCP को सन्दर्भमा यसको अर्थ के हो?

सूचना भनेको लामो समयसम्म चल्ने अपरेसनको क्रममा प्रगति, स्थिति, वा अन्य घटनाहरूको बारेमा ग्राहकलाई सर्भरबाट पठाइने सन्देश हो। सूचनाले पारदर्शिता र प्रयोगकर्ता अनुभव सुधार्छ।

उदाहरणका लागि, ग्राहकले सर्भरसँगको प्रारम्भिक हात मिलाउने प्रक्रियापछि एक सूचना पठाउनुपर्छ।

सूचना JSON सन्देशको रूपमा यस्तो देखिन्छ:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

सूचनाहरू MCP मा ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) नामक विषयसँग सम्बन्धित हुन्छन्।

लगिङ कार्यान्वयन गर्न सर्भरले यसलाई सुविधा/क्षमता रूपमा सक्षम पार्नुपर्छ:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> प्रयोग गरिएको SDK अनुसार, लगिङ डिफल्ट रूपमा सक्षम हुन सक्छ वा तपाईंले सर्भर कन्फिगरेसनमा स्पष्ट रूपमा सक्षम पार्नुपर्ने हुन सक्छ।

सूचनाका विभिन्न प्रकारहरू छन्:

| स्तर       | विवरण                         | उदाहरण प्रयोग केस               |
|------------|------------------------------|--------------------------------|
| debug      | विस्तृत डिबगिङ जानकारी       | फंक्शन प्रवेश/निकास बिन्दुहरू  |
| info       | सामान्य सूचना सन्देशहरू       | अपरेसन प्रगति अपडेटहरू        |
| notice     | सामान्य तर महत्वपूर्ण घटनाहरू | कन्फिगरेसन परिवर्तनहरू         |
| warning    | चेतावनी अवस्था               | अव्यवस्थित सुविधा प्रयोग       |
| error      | त्रुटि अवस्था                | अपरेसन असफलताहरू              |
| critical   | गम्भीर अवस्था               | प्रणाली कम्पोनेंट विफलता       |
| alert      | तुरुन्त कारबाही आवश्यक        | डाटा भ्रष्टाचार पत्ता लाग्यो    |
| emergency  | प्रणाली प्रयोगयोग्य छैन      | पूर्ण प्रणाली विफलता           |

## MCP मा सूचना कार्यान्वयन

MCP मा सूचनाहरू कार्यान्वयन गर्न, तपाईंले सर्भर र ग्राहक दुवै पक्षलाई रियल-टाइम अपडेटहरू ह्यान्डल गर्न तयार गर्नुपर्छ। यसले लामो समयसम्म चल्ने अपरेसनहरूमा प्रयोगकर्तालाई तुरुन्त प्रतिक्रिया दिन सक्षम बनाउँछ।

### सर्भर-पक्ष: सूचना पठाउने

सर्भर पक्षबाट सुरु गरौं। MCP मा, तपाईंले उपकरणहरू परिभाषित गर्नुहुन्छ जुन अनुरोध प्रक्रिया गर्दा सूचनाहरू पठाउन सक्छन्। सर्भरले सन्देश पठाउन सन्दर्भ वस्तु (सामान्यतया `ctx`) प्रयोग गर्छ।

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

अघिल्लो उदाहरणमा, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ट्रान्सपोर्ट प्रयोग गरिएको छ:

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

यस .NET उदाहरणमा, `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` विधि सूचना सन्देश पठाउन प्रयोग गरिएको छ।

तपाईंको .NET MCP सर्भरमा सूचनाहरू सक्षम गर्न स्ट्रिमिङ ट्रान्सपोर्ट प्रयोग गरिरहेको सुनिश्चित गर्नुहोस्:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### ग्राहक-पक्ष: सूचना प्राप्त गर्ने

ग्राहकले सन्देश ह्यान्डलर कार्यान्वयन गर्नुपर्छ जसले सूचना प्राप्त हुँदा तिनीहरूलाई प्रक्रिया र प्रदर्शन गर्छ।

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

अघिल्लो कोडमा, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` ले आउने सूचनाहरू सम्हाल्छ।

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

यस .NET उदाहरणमा, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` प्रयोग गरी ग्राहकले सूचना ह्यान्डलर कार्यान्वयन गरेको छ।

## प्रगति सूचनाहरू र परिदृश्यहरू

यस भागले MCP मा प्रगति सूचनाको अवधारणा, यसको महत्त्व, र Streamable HTTP प्रयोग गरी कसरी कार्यान्वयन गर्ने बारे व्याख्या गर्छ। तपाईंको बुझाइलाई बलियो बनाउन व्यावहारिक कार्य पनि छ।

प्रगति सूचनाहरू लामो समयसम्म चल्ने अपरेसनहरूमा सर्भरबाट ग्राहकलाई पठाइने रियल-टाइम सन्देशहरू हुन्। सम्पूर्ण प्रक्रिया समाप्त हुन कुर्नुको सट्टा, सर्भरले ग्राहकलाई हालको स्थिति बारे अपडेट राख्छ। यसले पारदर्शिता, प्रयोगकर्ता अनुभव सुधार्छ र डिबगिङ सजिलो बनाउँछ।

**उदाहरण:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### किन प्रगति सूचनाहरू प्रयोग गर्ने?

प्रगति सूचनाहरूको महत्त्वका कारणहरू:

- **राम्रो प्रयोगकर्ता अनुभव:** कामको प्रगति देखिन्छ, अन्त्यमा मात्र होइन।
- **रियल-टाइम प्रतिक्रिया:** ग्राहकहरूले प्रगति बार वा लगहरू देखाउन सक्छन्, जसले अनुप्रयोगलाई प्रतिक्रियाशील बनाउँछ।
- **डिबगिङ र अनुगमन सजिलो:** विकासकर्ता र प्रयोगकर्ताले प्रक्रिया कहाँ ढिलो वा अड्किएको छ थाहा पाउन सक्छन्।

### प्रगति सूचनाहरू कसरी कार्यान्वयन गर्ने

MCP मा प्रगति सूचनाहरू कार्यान्वयन गर्ने तरिका:

- **सर्भरमा:** प्रत्येक वस्तु प्रक्रिया गर्दा `ctx.info()` or `ctx.log()` प्रयोग गरी सूचना पठाउनुहोस्। यसले मुख्य नतिजा तयार हुनु अघि ग्राहकलाई सन्देश पठाउँछ।
- **ग्राहकमा:** सूचना प्राप्त र प्रदर्शन गर्न सन्देश ह्यान्डलर कार्यान्वयन गर्नुहोस्। यो ह्यान्डलरले सूचनाहरू र अन्तिम नतिजाबीच फरक गर्छ।

**सर्भर उदाहरण:**

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

**ग्राहक उदाहरण:**

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

## सुरक्षा विचारहरू

HTTP-आधारित ट्रान्सपोर्टहरू प्रयोग गरी MCP सर्भरहरू कार्यान्वयन गर्दा सुरक्षा अत्यन्त महत्वपूर्ण हुन्छ र यसले विभिन्न आक्रमण मार्गहरू र सुरक्षा उपायहरूमा ध्यान दिन आवश्यक हुन्छ।

### अवलोकन

HTTP मार्फत MCP सर्भरहरू प्रदर्शन गर्दा सुरक्षा महत्वपूर्ण हुन्छ। Streamable HTTP ले नयाँ आक्रमण सतहहरू प्रस्तुत गर्दछ र सावधानीपूर्वक कन्फिगरेसन आवश्यक हुन्छ।

### मुख्य बुँदाहरू
- **Origin Header प्रमाणीकरण**: सधैं `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` प्रयोग गर्नुहोस्, SSE क्लाइन्टको सट्टा।
3. **ग्राहकमा सन्देश ह्यान्डलर कार्यान्वयन गर्नुहोस्** जसले सूचनाहरू प्रक्रिया गर्छ।
4. **मौजूदा उपकरण र कार्यप्रवाहसँग अनुकूलता परीक्षण गर्नुहोस्।**

### अनुकूलता कायम राख्ने

माइग्रेशन प्रक्रियामा मौजूदा SSE क्लाइन्टहरूसँग अनुकूलता कायम राख्न सिफारिस गरिन्छ। यहाँ केही रणनीतिहरू छन्:

- तपाईं SSE र Streamable HTTP दुवैलाई फरक अन्तबिन्दुमा चलाएर समर्थन गर्न सक्नुहुन्छ।
- ग्राहकहरूलाई नयाँ ट्रान्सपोर्टमा क्रमशः माइग्रेट गर्नुहोस्।

### चुनौतीहरू

माइग्रेशनको क्रममा निम्न चुनौतीहरू समाधान गर्नुपर्छ:

- सबै ग्राहकहरू अपडेट भएको सुनिश्चित गर्नु।
- सूचना वितरणमा भिन्नता सम्हाल्नु।

### कार्य: आफ्नै स्ट्रिमिङ MCP अनुप्रयोग बनाउनुहोस्

**परिदृश्य:**
एक MCP सर्भर र क्लाइन्ट बनाउनुहोस् जहाँ सर्भरले वस्तुहरूको सूची (जस्तै, फाइल वा कागजातहरू) प्रक्रिया गर्छ र प्रत्येक वस्तु प्रक्रिया भएपछि सूचना पठाउँछ। ग्राहकले प्रत्येक सूचना प्राप्त भएसँगै प्रदर्शन गर्नुपर्छ।

**चरणहरू:**

1. सूची प्रक्रिया गर्ने र प्रत्येक वस्तुका लागि सूचना पठाउने सर्भर उपकरण कार्यान्वयन गर्नुहोस्।
2. रियल-टाइममा सूचनाहरू प्रदर्शन गर्न सन्देश ह्यान्डलर सहित क्लाइन्ट कार्यान्वयन गर्नुहोस्।
3. सर्भर र क्लाइन्ट दुवै चलाएर कार्यान्वयन परीक्षण गर्नुहोस् र सूचनाहरू अवलोकन गर्नुहोस्।

[Solution](./solution/README.md)

## थप पढाइ र के गर्ने?

MCP स्ट्रिमिङसँग आफ्नो यात्रा जारी राख्न र आफ्नो ज्ञान विस्तार गर्न, यस भागले थप स्रोतहरू र उन्नत अनुप्रयोगहरू निर्माणका लागि सुझावहरू प्रदान गर्दछ।

### थप पढाइ

- [Microsoft: HTTP स्ट्रिमिङ परिचय](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core मा CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: स्ट्रिमिङ अनुरोधहरू](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### के गर्ने?

- रियल-टाइम एनालिटिक्स, च्याट, वा सहकार्य सम्पादनका लागि स्ट्रिमिङ प्रयोग गर्ने उन्न

**अस्वीकरण**:  
यो कागजात [Co-op Translator](https://github.com/Azure/co-op-translator) नामक एआई अनुवाद सेवा प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल कागजात यसको मूल भाषामा आधिकारिक स्रोतको रूपमा मान्नुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याप्रति हामी जिम्मेवार छैनौं।