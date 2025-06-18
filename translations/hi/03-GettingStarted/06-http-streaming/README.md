<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:49:23+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hi"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

यह अध्याय Model Context Protocol (MCP) के साथ HTTPS का उपयोग करके सुरक्षित, स्केलेबल और रियल-टाइम स्ट्रीमिंग को लागू करने के लिए एक व्यापक मार्गदर्शिका प्रदान करता है। इसमें स्ट्रीमिंग के पीछे प्रेरणा, उपलब्ध ट्रांसपोर्ट मैकेनिज्म, MCP में स्ट्रीमेबल HTTP को कैसे लागू करें, सुरक्षा सर्वोत्तम प्रथाएं, SSE से माइग्रेशन, और अपने खुद के स्ट्रीमिंग MCP एप्लिकेशन बनाने के लिए व्यावहारिक मार्गदर्शन शामिल हैं।

## MCP में ट्रांसपोर्ट मैकेनिज्म और स्ट्रीमिंग

यह अनुभाग MCP में उपलब्ध विभिन्न ट्रांसपोर्ट मैकेनिज्म का पता लगाता है और क्लाइंट और सर्वर के बीच रियल-टाइम संचार के लिए स्ट्रीमिंग क्षमताओं को सक्षम करने में उनकी भूमिका बताता है।

### ट्रांसपोर्ट मैकेनिज्म क्या है?

ट्रांसपोर्ट मैकेनिज्म यह परिभाषित करता है कि क्लाइंट और सर्वर के बीच डेटा कैसे आदान-प्रदान किया जाता है। MCP विभिन्न वातावरणों और आवश्यकताओं के लिए उपयुक्त कई ट्रांसपोर्ट प्रकारों का समर्थन करता है:

- **stdio**: स्टैंडर्ड इनपुट/आउटपुट, स्थानीय और CLI-आधारित टूल्स के लिए उपयुक्त। सरल लेकिन वेब या क्लाउड के लिए उपयुक्त नहीं।
- **SSE (Server-Sent Events)**: सर्वर को HTTP के माध्यम से क्लाइंट को रियल-टाइम अपडेट भेजने की अनुमति देता है। वेब UI के लिए अच्छा, लेकिन स्केलेबिलिटी और लचीलापन सीमित।
- **Streamable HTTP**: आधुनिक HTTP-आधारित स्ट्रीमिंग ट्रांसपोर्ट, जो नोटिफिकेशन और बेहतर स्केलेबिलिटी का समर्थन करता है। अधिकांश प्रोडक्शन और क्लाउड परिदृश्यों के लिए अनुशंसित।

### तुलना तालिका

नीचे दी गई तुलना तालिका देखें ताकि इन ट्रांसपोर्ट मैकेनिज्म के बीच अंतर को समझा जा सके:

| ट्रांसपोर्ट         | रियल-टाइम अपडेट्स | स्ट्रीमिंग | स्केलेबिलिटी | उपयोग मामला               |
|--------------------|-------------------|------------|--------------|--------------------------|
| stdio              | नहीं              | नहीं       | कम           | स्थानीय CLI टूल्स        |
| SSE                | हाँ               | हाँ        | मध्यम        | वेब, रियल-टाइम अपडेट्स |
| Streamable HTTP    | हाँ               | हाँ        | उच्च         | क्लाउड, मल्टी-क्लाइंट    |

> **Tip:** सही ट्रांसपोर्ट चुनना प्रदर्शन, स्केलेबिलिटी, और उपयोगकर्ता अनुभव को प्रभावित करता है। आधुनिक, स्केलेबल और क्लाउड-तैयार एप्लिकेशन के लिए **Streamable HTTP** की सलाह दी जाती है।

पिछले अध्यायों में आपको दिखाए गए stdio और SSE ट्रांसपोर्ट पर ध्यान दें और देखें कि इस अध्याय में स्ट्रीमेबल HTTP ट्रांसपोर्ट को कवर किया गया है।

## स्ट्रीमिंग: अवधारणाएँ और प्रेरणा

स्ट्रीमिंग के मूलभूत सिद्धांतों और प्रेरणाओं को समझना प्रभावी रियल-टाइम संचार प्रणाली लागू करने के लिए आवश्यक है।

**स्ट्रीमिंग** नेटवर्क प्रोग्रामिंग में एक तकनीक है जो डेटा को छोटे, प्रबंधनीय हिस्सों या घटनाओं की श्रृंखला के रूप में भेजने और प्राप्त करने की अनुमति देती है, बजाय इसके कि पूरी प्रतिक्रिया तैयार होने तक इंतजार किया जाए। यह विशेष रूप से उपयोगी है:

- बड़े फ़ाइलों या डेटा सेट के लिए।
- रियल-टाइम अपडेट्स (जैसे चैट, प्रोग्रेस बार) के लिए।
- लंबी अवधि के कंप्यूटेशन के लिए जहाँ आप उपयोगकर्ता को सूचित रखना चाहते हैं।

यहाँ स्ट्रीमिंग के बारे में उच्च स्तर पर जो आपको जानना चाहिए:

- डेटा क्रमिक रूप से वितरित होता है, एक साथ नहीं।
- क्लाइंट डेटा को आते ही प्रोसेस कर सकता है।
- अनुमानित विलंबता को कम करता है और उपयोगकर्ता अनुभव में सुधार करता है।

### स्ट्रीमिंग क्यों उपयोग करें?

स्ट्रीमिंग उपयोग करने के कारण निम्नलिखित हैं:

- उपयोगकर्ताओं को तुरंत प्रतिक्रिया मिलती है, केवल अंत में नहीं।
- रियल-टाइम एप्लिकेशन और प्रतिक्रियाशील UI सक्षम करता है।
- नेटवर्क और कंप्यूट संसाधनों का अधिक कुशल उपयोग।

### सरल उदाहरण: HTTP स्ट्रीमिंग सर्वर और क्लाइंट

यहाँ एक सरल उदाहरण है कि स्ट्रीमिंग को कैसे लागू किया जा सकता है:

<details>
<summary>Python</summary>

**सर्वर (Python, FastAPI और StreamingResponse का उपयोग करते हुए):**
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

**क्लाइंट (Python, requests का उपयोग करते हुए):**
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

यह उदाहरण दिखाता है कि सर्वर क्लाइंट को संदेशों की एक श्रृंखला भेजता है जैसे ही वे उपलब्ध होते हैं, बजाय इसके कि सभी संदेश तैयार होने तक इंतजार किया जाए।

**कैसे काम करता है:**
- सर्वर प्रत्येक संदेश को जैसे ही वह तैयार होता है भेजता है।
- क्लाइंट प्रत्येक प्राप्त हिस्से को प्राप्त करके प्रिंट करता है।

**आवश्यकताएँ:**
- सर्वर को स्ट्रीमिंग प्रतिक्रिया का उपयोग करना चाहिए (जैसे `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**सर्वर (Java, Spring Boot और Server-Sent Events का उपयोग करते हुए):**

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

**क्लाइंट (Java, Spring WebFlux WebClient का उपयोग करते हुए):**

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

**Java कार्यान्वयन नोट्स:**
- Spring Boot के रिएक्टिव स्टैक का उपयोग करता है जिसमें `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) और MCP के माध्यम से स्ट्रीमिंग चुनने के बीच।

- **सरल स्ट्रीमिंग आवश्यकताओं के लिए:** क्लासिक HTTP स्ट्रीमिंग लागू करना सरल और बुनियादी स्ट्रीमिंग जरूरतों के लिए पर्याप्त है।

- **जटिल, इंटरैक्टिव एप्लिकेशन के लिए:** MCP स्ट्रीमिंग एक अधिक संरचित दृष्टिकोण प्रदान करता है जिसमें समृद्ध मेटाडेटा और नोटिफिकेशन तथा अंतिम परिणाम के बीच पृथक्करण होता है।

- **AI एप्लिकेशन के लिए:** MCP का नोटिफिकेशन सिस्टम लंबे चलने वाले AI कार्यों के लिए विशेष रूप से उपयोगी है जहाँ आप उपयोगकर्ताओं को प्रगति की जानकारी देना चाहते हैं।

## MCP में स्ट्रीमिंग

ठीक है, अब तक आपने क्लासिक स्ट्रीमिंग और MCP में स्ट्रीमिंग के बीच अंतर पर कुछ सिफारिशें और तुलना देखी हैं। आइए विस्तार से जानें कि आप MCP में स्ट्रीमिंग का उपयोग कैसे कर सकते हैं।

MCP फ्रेमवर्क के भीतर स्ट्रीमिंग कैसे काम करता है इसे समझना आवश्यक है ताकि आप प्रतिक्रियाशील एप्लिकेशन बना सकें जो लंबी चलने वाली प्रक्रियाओं के दौरान उपयोगकर्ताओं को रियल-टाइम फीडबैक दें।

MCP में, स्ट्रीमिंग का मतलब मुख्य प्रतिक्रिया को टुकड़ों में भेजना नहीं है, बल्कि जब कोई टूल अनुरोध को प्रोसेस कर रहा होता है तो क्लाइंट को **नोटिफिकेशन** भेजना होता है। ये नोटिफिकेशन प्रगति अपडेट, लॉग्स, या अन्य घटनाओं को शामिल कर सकते हैं।

### यह कैसे काम करता है

मुख्य परिणाम अभी भी एकल प्रतिक्रिया के रूप में भेजा जाता है। हालांकि, प्रोसेसिंग के दौरान नोटिफिकेशन अलग-अलग संदेशों के रूप में भेजे जा सकते हैं और इस प्रकार क्लाइंट को रियल-टाइम में अपडेट किया जाता है। क्लाइंट को इन नोटिफिकेशन को संभालने और प्रदर्शित करने में सक्षम होना चाहिए।

## नोटिफिकेशन क्या है?

हमने "नोटिफिकेशन" कहा, MCP के संदर्भ में इसका क्या मतलब है?

नोटिफिकेशन एक संदेश होता है जो सर्वर से क्लाइंट को भेजा जाता है ताकि लंबी चलने वाली प्रक्रिया के दौरान प्रगति, स्थिति, या अन्य घटनाओं के बारे में सूचित किया जा सके। नोटिफिकेशन पारदर्शिता और उपयोगकर्ता अनुभव में सुधार करते हैं।

उदाहरण के लिए, क्लाइंट को एक नोटिफिकेशन भेजना चाहिए जब सर्वर के साथ प्रारंभिक हैंडशेक पूरा हो जाए।

एक नोटिफिकेशन JSON संदेश के रूप में इस प्रकार दिखता है:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

नोटिफिकेशन MCP में ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) नामक एक टॉपिक से संबंधित होते हैं।

लॉगिंग को काम करने के लिए, सर्वर को इसे फीचर/क्षमता के रूप में सक्षम करना होता है, जैसे:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> उपयोग किए गए SDK के आधार पर, लॉगिंग डिफ़ॉल्ट रूप से सक्षम हो सकता है, या आपको इसे अपने सर्वर कॉन्फ़िगरेशन में स्पष्ट रूप से सक्षम करना पड़ सकता है।

विभिन्न प्रकार के नोटिफिकेशन होते हैं:

| स्तर       | विवरण                         | उदाहरण उपयोग मामला             |
|------------|-------------------------------|-------------------------------|
| debug      | विस्तृत डिबगिंग जानकारी       | फ़ंक्शन प्रवेश/निकास बिंदु     |
| info       | सामान्य सूचना संदेश           | ऑपरेशन प्रगति अपडेट           |
| notice     | सामान्य लेकिन महत्वपूर्ण घटनाएं | कॉन्फ़िगरेशन परिवर्तन          |
| warning    | चेतावनी की स्थितियाँ          | अप्रचलित फीचर का उपयोग        |
| error      | त्रुटि की स्थितियाँ            | ऑपरेशन विफलताएँ              |
| critical   | गंभीर स्थितियाँ               | सिस्टम घटक विफलताएँ           |
| alert      | तुरंत कार्रवाई आवश्यक          | डेटा भ्रष्टाचार का पता चला    |
| emergency  | सिस्टम अनुपयोगी               | पूरी प्रणाली विफल             |

## MCP में नोटिफिकेशन लागू करना

MCP में नोटिफिकेशन लागू करने के लिए, आपको सर्वर और क्लाइंट दोनों पक्षों को रियल-टाइम अपडेट्स को संभालने के लिए सेट अप करना होगा। इससे आपका एप्लिकेशन लंबी चलने वाली प्रक्रियाओं के दौरान उपयोगकर्ताओं को तत्काल प्रतिक्रिया प्रदान कर सकता है।

### सर्वर-साइड: नोटिफिकेशन भेजना

आइए सर्वर साइड से शुरू करें। MCP में, आप ऐसे टूल परिभाषित करते हैं जो अनुरोधों को प्रोसेस करते समय नोटिफिकेशन भेज सकते हैं। सर्वर संदर्भ ऑब्जेक्ट (आमतौर पर `ctx`) का उपयोग करके क्लाइंट को संदेश भेजता है।

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

पिछले उदाहरण में, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ट्रांसपोर्ट का उपयोग किया गया है:

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

इस .NET उदाहरण में, `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` मेथड का उपयोग सूचना संदेश भेजने के लिए किया गया है।

अपने .NET MCP सर्वर में नोटिफिकेशन सक्षम करने के लिए सुनिश्चित करें कि आप स्ट्रीमिंग ट्रांसपोर्ट का उपयोग कर रहे हैं:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### क्लाइंट-साइड: नोटिफिकेशन प्राप्त करना

क्लाइंट को एक संदेश हैंडलर लागू करना चाहिए जो आने वाले नोटिफिकेशन को प्रोसेस और प्रदर्शित करे।

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

पिछले कोड में, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` का उपयोग इनकमिंग नोटिफिकेशन को संभालने के लिए किया गया है।

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

इस .NET उदाहरण में, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` का उपयोग किया गया है और आपका क्लाइंट नोटिफिकेशन को प्रोसेस करने के लिए एक संदेश हैंडलर लागू करता है।

## प्रगति नोटिफिकेशन और परिदृश्य

यह अनुभाग MCP में प्रगति नोटिफिकेशन की अवधारणा, उनका महत्व, और Streamable HTTP का उपयोग करके उन्हें कैसे लागू करें, समझाता है। साथ ही, आपकी समझ को मजबूत करने के लिए एक व्यावहारिक असाइनमेंट भी है।

प्रगति नोटिफिकेशन रियल-टाइम संदेश होते हैं जो लंबी चलने वाली प्रक्रियाओं के दौरान सर्वर से क्लाइंट को भेजे जाते हैं। पूरी प्रक्रिया समाप्त होने तक इंतजार करने के बजाय, सर्वर क्लाइंट को वर्तमान स्थिति के बारे में अपडेट रखता है। इससे पारदर्शिता, उपयोगकर्ता अनुभव बेहतर होता है और डिबगिंग आसान हो जाती है।

**उदाहरण:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### प्रगति नोटिफिकेशन क्यों उपयोग करें?

प्रगति नोटिफिकेशन कई कारणों से आवश्यक हैं:

- **बेहतर उपयोगकर्ता अनुभव:** उपयोगकर्ता कार्य प्रगति के अनुसार अपडेट देखते हैं, केवल अंत में नहीं।
- **रियल-टाइम फीडबैक:** क्लाइंट प्रगति बार या लॉग दिखा सकते हैं, जिससे ऐप प्रतिक्रियाशील महसूस होता है।
- **आसान डिबगिंग और निगरानी:** डेवलपर्स और उपयोगकर्ता देख सकते हैं कि प्रक्रिया कहाँ धीमी या अटकी हुई है।

### प्रगति नोटिफिकेशन कैसे लागू करें

यहाँ बताया गया है कि आप MCP में प्रगति नोटिफिकेशन कैसे लागू कर सकते हैं:

- **सर्वर पर:** `ctx.info()` or `ctx.log()` का उपयोग करें ताकि प्रत्येक आइटम के प्रोसेस होते ही नोटिफिकेशन भेजे जा सकें। यह मुख्य परिणाम तैयार होने से पहले क्लाइंट को संदेश भेजता है।
- **क्लाइंट पर:** एक संदेश हैंडलर लागू करें जो नोटिफिकेशन को सुनता और प्रदर्शित करता है। यह हैंडलर नोटिफिकेशन और अंतिम परिणाम के बीच अंतर करता है।

**सर्वर उदाहरण:**

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

**क्लाइंट उदाहरण:**

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

## सुरक्षा विचार

जब MCP सर्वर HTTP-आधारित ट्रांसपोर्ट के साथ लागू किए जाते हैं, तो सुरक्षा अत्यंत महत्वपूर्ण हो जाती है और कई हमले के तरीकों और सुरक्षा उपायों पर सावधानीपूर्वक ध्यान देने की आवश्यकता होती है।

### अवलोकन

HTTP पर MCP सर्वर को एक्सपोज़ करते समय सुरक्षा महत्वपूर्ण है। स्ट्रीमेबल HTTP नए हमले के रास्ते खोलता है और सावधानीपूर्वक कॉन्फ़िगरेशन की मांग करता है।

### मुख्य बिंदु
- **Origin Header सत्यापन**: हमेशा `Origin` हेडर को सत्यापित करें ताकि केवल विश्वसनीय स्रोतों से अनुरोध स्वीकार किए जाएं।
- **प्रामाणिकता और प्राधिकरण**: उचित प्रमाणीकरण और प्राधिकरण लागू करें।
- **सुरक्षित कनेक्शन**: केवल HTTPS का उपयोग करें।
- **इनपुट सत्यापन**: सभी इनपुट को ठीक से सत्यापित और साफ़ करें।
- **अद्यतन और पैचिंग**: सर्वर सॉफ़्टवेयर और निर्भरता को नियमित रूप से अपडेट करें।

### संगतता बनाए रखना

माइग्रेशन प्रक्रिया के दौरान मौजूदा SSE क्लाइंट के साथ संगतता बनाए रखना अनुशंसित है। यहाँ कुछ रणनीतियाँ हैं:

- आप SSE और Streamable HTTP दोनों का समर्थन कर सकते हैं, दोनों ट्रांसपोर्ट को अलग-अलग एंडपॉइंट्स पर चलाकर।
- धीरे-धीरे क्लाइंट्स को नए ट्रांसपोर्ट पर माइग्रेट करें।

### चुनौतियाँ

माइग्रेशन के दौरान निम्नलिखित चुनौतियों को संबोधित करना सुनिश्चित करें:

- सभी क्लाइंट्स को अपडेट करना।
- नोटिफिकेशन डिलीवरी में अंतर को संभालना।

### असाइनमेंट: अपना खुद का स्ट्रीमिंग MCP ऐप बनाएं

**परिदृश्य:**
एक MCP सर्वर और क्लाइंट बनाएं जहाँ सर्वर आइटम की एक सूची (जैसे फ़ाइलें या दस्तावेज़) को प्रोसेस करता है और प्रत्येक प्रोसेस किए गए आइटम के लिए एक नोटिफिकेशन भेजता है। क्लाइंट को प्रत्येक नोटिफिकेशन को आते ही प्रदर्शित करना चाहिए।

**कदम:**

1. एक सर्वर टूल लागू करें जो सूची को प्रोसेस करे और प्रत्येक आइटम के लिए नोटिफिकेशन भेजे।
2. एक क्लाइंट लागू करें जिसमें एक संदेश हैंडलर हो जो रियल-टाइम में नोटिफिकेशन दिखाए।
3. अपने कार्यान्वयन का परीक्षण करें, सर्वर और क्लाइंट दोनों चलाकर नोटिफिकेशन देखें।

[Solution](./solution/README.md)

## आगे पढ़ें और आगे क्या करें?

MCP स्ट्रीमिंग के साथ अपनी यात्रा जारी रखने और अपने ज्ञान का विस्तार करने के लिए, यह अनुभाग अतिरिक्त संसाधन और अधिक उन्नत एप्लिकेशन बनाने के लिए सुझाए गए अगले कदम प्रदान करता है।

### आगे पढ़ें

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft:

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या गलतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।