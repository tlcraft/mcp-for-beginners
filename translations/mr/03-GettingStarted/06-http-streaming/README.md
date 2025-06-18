<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T08:52:44+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "mr"
}
-->
# HTTPS स्ट्रीमिंग विथ मॉडल कॉन्टेक्स्ट प्रोटोकॉल (MCP)

हा अध्याय HTTPS वापरून Model Context Protocol (MCP) सह सुरक्षित, स्केलेबल आणि रिअल-टाइम स्ट्रीमिंग कसे अंमलात आणायचे याबाबत सविस्तर मार्गदर्शन करतो. यात स्ट्रीमिंगची गरज, उपलब्ध ट्रान्सपोर्ट मेकॅनिझम्स, MCP मध्ये स्ट्रीमेबल HTTP कसे अंमलात आणायचे, सुरक्षा सर्वोत्तम पद्धती, SSE कडून माइग्रेशन आणि स्वतःचे स्ट्रीमिंग MCP अनुप्रयोग तयार करण्यासाठी व्यावहारिक मार्गदर्शन यांचा समावेश आहे.

## MCP मधील ट्रान्सपोर्ट मेकॅनिझम्स आणि स्ट्रीमिंग

हा विभाग MCP मध्ये उपलब्ध वेगवेगळ्या ट्रान्सपोर्ट मेकॅनिझम्स आणि त्यांचा क्लायंट आणि सर्व्हरमधील रिअल-टाइम संवादासाठी स्ट्रीमिंग क्षमता सक्षम करण्यात कसा वापर होतो हे तपासतो.

### ट्रान्सपोर्ट मेकॅनिझम म्हणजे काय?

ट्रान्सपोर्ट मेकॅनिझम म्हणजे क्लायंट आणि सर्व्हरमधील डेटा कसा देवाणघेवाण होतो हे ठरवणारा माध्यम. MCP वेगवेगळ्या वातावरण आणि गरजांसाठी अनेक ट्रान्सपोर्ट प्रकारांना समर्थन देते:

- **stdio**: स्टँडर्ड इनपुट/आउटपुट, स्थानिक आणि CLI-आधारित टूल्ससाठी योग्य. सोपे पण वेब किंवा क्लाऊडसाठी योग्य नाही.
- **SSE (Server-Sent Events)**: सर्व्हर HTTP वरून क्लायंटकडे रिअल-टाइम अपडेट्स पुश करू शकतो. वेब UI साठी चांगले, पण स्केलेबिलिटी आणि लवचीकतेत मर्यादित.
- **Streamable HTTP**: आधुनिक HTTP-आधारित स्ट्रीमिंग ट्रान्सपोर्ट, नोटिफिकेशन्स आणि चांगली स्केलेबिलिटी समर्थित. बहुतेक प्रॉडक्शन आणि क्लाऊड परिस्थितीसाठी शिफारस केलेले.

### तुलना तक्ता

खालील तुलना तक्ता पाहा ज्यामुळे या ट्रान्सपोर्ट मेकॅनिझम्समधील फरक समजेल:

| ट्रान्सपोर्ट       | रिअल-टाइम अपडेट्स | स्ट्रीमिंग | स्केलेबिलिटी | वापर प्रकरण            |
|-------------------|------------------|-----------|-------------|-------------------------|
| stdio             | नाही              | नाही       | कमी          | स्थानिक CLI टूल्स       |
| SSE               | होय              | होय       | मध्यम        | वेब, रिअल-टाइम अपडेट्स |
| Streamable HTTP   | होय              | होय       | जास्त        | क्लाऊड, मल्टी-क्लायंट   |

> **टिप:** योग्य ट्रान्सपोर्ट निवडल्याने कार्यक्षमता, स्केलेबिलिटी आणि वापरकर्ता अनुभवावर परिणाम होतो. **Streamable HTTP** आधुनिक, स्केलेबल आणि क्लाऊड-रेडी अनुप्रयोगांसाठी शिफारस केली जाते.

पूर्वीच्या अध्यायांमध्ये आपण stdio आणि SSE ट्रान्सपोर्ट्स पाहिले होते, तर या अध्यायात Streamable HTTP कसा वापरायचा हे समजावले आहे.

## स्ट्रीमिंग: संकल्पना आणि प्रेरणा

स्ट्रीमिंगच्या मूलभूत संकल्पना आणि प्रेरणा समजून घेणे प्रभावी रिअल-टाइम संवाद प्रणाली तयार करण्यासाठी आवश्यक आहे.

**स्ट्रीमिंग** ही नेटवर्क प्रोग्रामिंगमधील एक तंत्र आहे ज्याद्वारे डेटा संपूर्ण प्रतिसाद तयार होण्याची वाट पाहता छोट्या, हाताळण्याजोग्या तुकड्यांमध्ये किंवा इव्हेंट्सच्या मालिकेत पाठवला आणि प्राप्त केला जातो. हे विशेषतः उपयुक्त आहे:

- मोठ्या फाइल्स किंवा डेटासेटसाठी.
- रिअल-टाइम अपडेट्ससाठी (उदा., चॅट, प्रगती पट्ट्या).
- लांब चालणाऱ्या गणनांसाठी जिथे वापरकर्त्याला सतत माहिती द्यायची असते.

स्ट्रीमिंगबाबत उच्चस्तरीय माहिती:

- डेटा हळूहळू पाठवला जातो, एकाच वेळी नाही.
- क्लायंट डेटा येताच प्रक्रिया करू शकतो.
- विलंब कमी होतो आणि वापरकर्ता अनुभव सुधारतो.

### स्ट्रीमिंग का वापरावे?

स्ट्रीमिंग वापरण्याची कारणे:

- वापरकर्त्यांना लगेच प्रतिसाद मिळतो, फक्त शेवटी नाही.
- रिअल-टाइम अनुप्रयोग आणि प्रतिसादक्षम UI सक्षम करतो.
- नेटवर्क आणि संगणकीय संसाधनांचा अधिक कार्यक्षम वापर.

### सोपा उदाहरण: HTTP स्ट्रीमिंग सर्व्हर आणि क्लायंट

स्ट्रीमिंग कसे अंमलात आणता येईल याचे एक सोपे उदाहरण:

<details>
<summary>Python</summary>

**सर्व्हर (Python, FastAPI आणि StreamingResponse वापरून):**
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

**क्लायंट (Python, requests वापरून):**
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

हे उदाहरण दाखवते की सर्व्हर सर्व संदेश तयार होण्याची वाट पाहण्याऐवजी उपलब्ध होताच क्लायंटकडे संदेश पाठवतो.

**कसे कार्य करते:**
- सर्व्हर प्रत्येक संदेश तयार होताच पाठवतो.
- क्लायंट प्रत्येक तुकडा येताच प्राप्त करून प्रिंट करतो.

**गरजा:**
- सर्व्हरने स्ट्रीमिंग प्रतिसाद वापरावा लागतो (उदा., `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`).

</details>

<details>
<summary>Java</summary>

**सर्व्हर (Java, Spring Boot आणि Server-Sent Events वापरून):**

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

**क्लायंट (Java, Spring WebFlux WebClient वापरून):**

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

**Java अंमलबजावणी टिपा:**
- Spring Boot चा reactive stack वापरतो ज्यामध्ये `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream` वापरला जातो.

- **सोप्या स्ट्रीमिंगसाठी:** पारंपरिक HTTP स्ट्रीमिंग सोपे आणि मूलभूत गरजांसाठी पुरेसे आहे.

- **जटिल, संवादात्मक अनुप्रयोगांसाठी:** MCP स्ट्रीमिंग अधिक संरचित दृष्टिकोन देते ज्यात समृद्ध मेटाडेटा आणि नोटिफिकेशन्स व अंतिम निकाल यांचे विभाजन असते.

- **AI अनुप्रयोगांसाठी:** MCP चे नोटिफिकेशन सिस्टम लांब चालणाऱ्या AI कामांसाठी उपयुक्त आहे ज्यामुळे वापरकर्त्यांना प्रगतीची माहिती दिली जाते.

## MCP मध्ये स्ट्रीमिंग

आता आपण क्लासिकल स्ट्रीमिंग आणि MCP मधील स्ट्रीमिंग यातील फरक पाहिला आहे. आता तपशीलवार पाहूया की MCP मध्ये स्ट्रीमिंग कसे वापरायचे.

MCP फ्रेमवर्कमध्ये स्ट्रीमिंग कसे कार्य करते हे समजून घेणे आवश्यक आहे जेणेकरून आपण लांब चालणाऱ्या ऑपरेशन्स दरम्यान वापरकर्त्यांना रिअल-टाइम फीडबॅक देणारे प्रतिसादक्षम अनुप्रयोग तयार करू शकता.

MCP मध्ये, स्ट्रीमिंग म्हणजे मुख्य प्रतिसाद तुकड्यांमध्ये पाठवणे नव्हे, तर टूल विनंती प्रक्रियेत असताना क्लायंटकडे **नोटिफिकेशन्स** पाठवणे होय. या नोटिफिकेशन्समध्ये प्रगती अपडेट्स, लॉग्स किंवा इतर इव्हेंट्स असू शकतात.

### कसे कार्य करते

मुख्य निकाल एकाच प्रतिसादात पाठवला जातो. मात्र, प्रक्रिये दरम्यान नोटिफिकेशन्स स्वतंत्र संदेश म्हणून पाठवले जाऊ शकतात ज्यामुळे क्लायंटला रिअल-टाइम अपडेट्स मिळतात. क्लायंटने हे नोटिफिकेशन्स हाताळता यावे आणि प्रदर्शित करावे लागतात.

## नोटिफिकेशन म्हणजे काय?

आपण "नोटिफिकेशन" म्हटले, तर MCP च्या संदर्भात त्याचा अर्थ काय?

नोटिफिकेशन म्हणजे सर्व्हरकडून क्लायंटकडे पाठवलेला संदेश ज्याद्वारे लांब चालणाऱ्या ऑपरेशन दरम्यान प्रगती, स्थिती किंवा इतर इव्हेंट्सची माहिती दिली जाते. नोटिफिकेशन्समुळे पारदर्शकता आणि वापरकर्ता अनुभव सुधारतो.

उदाहरणार्थ, क्लायंटने सर्व्हरशी सुरुवातीचा हँडशेक झाल्यावर एक नोटिफिकेशन पाठवायचे असते.

नोटिफिकेशन JSON संदेशाप्रमाणे दिसते:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

नोटिफिकेशन्स MCP मधील ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) या विषयाशी संबंधित आहेत.

लॉगिंग कार्यान्वित करण्यासाठी सर्व्हरने ते फीचर/क्षमता म्हणून सक्षम करावे लागते:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> वापरल्या गेलेल्या SDK नुसार, लॉगिंग डिफॉल्टने सक्षम असू शकते किंवा तुम्हाला ते सर्व्हर कॉन्फिगरेशनमध्ये स्पष्टपणे सक्षम करावे लागू शकते.

नोटिफिकेशन्सचे वेगवेगळे प्रकार:

| स्तर       | वर्णन                          | उदाहरण वापर प्रकरण           |
|------------|-------------------------------|------------------------------|
| debug      | सविस्तर डिबगिंग माहिती       | फंक्शन एंट्री/एक्झिट पॉइंट्स |
| info       | सामान्य माहितीपूर्ण संदेश      | ऑपरेशन प्रगती अपडेट्स       |
| notice     | सामान्य पण महत्त्वाचे इव्हेंट्स | कॉन्फिगरेशन बदल             |
| warning    | इशारा स्थिती                  | जुनी वैशिष्ट्ये वापरणे       |
| error      | त्रुटी स्थिती                  | ऑपरेशन अयशस्वी              |
| critical   | गंभीर स्थिती                  | सिस्टीम घटक अयशस्वी         |
| alert      | त्वरित कृती आवश्यक            | डेटा करप्शन आढळले          |
| emergency  | सिस्टीम वापरण्यायोग्य नाही    | पूर्ण सिस्टीम फेल           |

## MCP मध्ये नोटिफिकेशन्स अंमलात आणणे

MCP मध्ये नोटिफिकेशन्स अंमलात आणण्यासाठी, तुम्हाला सर्व्हर आणि क्लायंट दोन्ही बाजू सेटअप करावे लागतात जेणेकरून रिअल-टाइम अपडेट्स हाताळता येतील. त्यामुळे लांब चालणाऱ्या ऑपरेशन्स दरम्यान वापरकर्त्यांना त्वरित फीडबॅक देता येतो.

### सर्व्हर-साइड: नोटिफिकेशन्स पाठवणे

सर्व्हर बाजूपासून सुरुवात करूया. MCP मध्ये तुम्ही असे टूल्स परिभाषित करता जे विनंत्या प्रक्रियेदरम्यान नोटिफिकेशन्स पाठवू शकतात. सर्व्हर संदर्भ ऑब्जेक्ट (`ctx` सहसा) वापरून क्लायंटकडे संदेश पाठवतो.

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

वर दिलेल्या उदाहरणात, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ट्रान्सपोर्ट वापरला आहे:

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

या .NET उदाहरणात, `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` मेथड माहितीपूर्ण संदेश पाठवण्यासाठी वापरली जाते.

तुमच्या .NET MCP सर्व्हरमध्ये नोटिफिकेशन्स सक्षम करण्यासाठी स्ट्रीमिंग ट्रान्सपोर्ट वापरा:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### क्लायंट-साइड: नोटिफिकेशन्स प्राप्त करणे

क्लायंटने संदेश हँडलर अंमलात आणावा जो नोटिफिकेशन्स प्राप्त करून त्यांचे प्रदर्शन करेल.

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

वरील कोडमध्ये, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` वापरून येणाऱ्या नोटिफिकेशन्स हाताळल्या जातात.

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

या .NET उदाहरणात, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` वापरले आहे आणि क्लायंटमध्ये नोटिफिकेशन्स प्रक्रिया करण्यासाठी संदेश हँडलर आहे.

## प्रगती नोटिफिकेशन्स आणि परिस्थिती

हा विभाग MCP मधील प्रगती नोटिफिकेशन्सची संकल्पना, त्यांचे महत्त्व आणि Streamable HTTP वापरून त्यांची अंमलबजावणी कशी करायची हे स्पष्ट करतो. तसेच, तुमच्या समजुतीसाठी व्यावहारिक कार्य दिले आहे.

प्रगती नोटिफिकेशन्स म्हणजे लांब चालणाऱ्या ऑपरेशन्स दरम्यान सर्व्हरकडून क्लायंटकडे पाठवले जाणारे रिअल-टाइम संदेश. संपूर्ण प्रक्रिया पूर्ण होण्याची वाट पाहण्याऐवजी, सर्व्हर क्लायंटला सद्यस्थितीची माहिती देतो. यामुळे पारदर्शकता, वापरकर्ता अनुभव सुधारतो आणि डिबगिंग सोपे होते.

**उदाहरण:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### प्रगती नोटिफिकेशन्स का वापराव्यात?

प्रगती नोटिफिकेशन्स आवश्यक असण्याची कारणे:

- **चांगला वापरकर्ता अनुभव:** काम चालू असताना वापरकर्त्याला अपडेट्स दिसतात, फक्त शेवटी नाही.
- **रिअल-टाइम फीडबॅक:** क्लायंट प्रगती पट्ट्या किंवा लॉग्स दाखवू शकतो, ज्यामुळे अॅप प्रतिसादक्षम वाटतो.
- **डिबगिंग आणि मॉनिटरिंग सुलभ:** विकसक आणि वापरकर्ते कुठे प्रक्रिया मंद आहे किंवा अडकली आहे ते पाहू शकतात.

### प्रगती नोटिफिकेशन्स कशी अंमलात आणायची

MCP मध्ये प्रगती नोटिफिकेशन्स अंमलात आणण्यासाठी:

- **सर्व्हरवर:** `ctx.info()` or `ctx.log()` वापरून प्रत्येक आयटम प्रक्रियेत नोटिफिकेशन्स पाठवा. हे मुख्य निकाल तयार होण्यापूर्वी क्लायंटला संदेश पाठवते.
- **क्लायंटवर:** संदेश हँडलर अंमलात आणा जो येणाऱ्या नोटिफिकेशन्स ऐकतो आणि दाखवतो. हा हँडलर नोटिफिकेशन्स आणि अंतिम निकाल यामध्ये फरक ओळखतो.

**सर्व्हर उदाहरण:**

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

**क्लायंट उदाहरण:**

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

HTTP-आधारित ट्रान्सपोर्टसह MCP सर्व्हर्स अंमलात आणताना सुरक्षा महत्त्वाची बाब असते, ज्यासाठी अनेक हल्ल्यांच्या मार्गांचा आणि संरक्षणाच्या यंत्रणांचा विचार करणे आवश्यक आहे.

### आढावा

HTTP द्वारे MCP सर्व्हर एक्सपोज करताना सुरक्षा अत्यंत महत्वाची आहे. Streamable HTTP नवीन हल्ल्यांचे मार्ग उघडतो आणि काळजीपूर्वक कॉन्फिगरेशनची गरज असते.

### मुख्य मुद्दे
- **Origin Header ची पडताळणी:** नेहमी `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` यांची पडताळणी करा, SSE क्लायंटऐवजी.
3. **क्लायंटमध्ये संदेश हँडलर अंमलात आणा** जे नोटिफिकेशन्स प्रक्रिया करेल.
4. **विद्यमान टूल्स आणि वर्कफ्लोजशी सुसंगतता तपासा.**

### सुसंगतता राखणे

मायग्रेशन प्रक्रियेदरम्यान विद्यमान SSE क्लायंट्सशी सुसंगतता राखणे शिफारसीय आहे. काही धोरणे:

- तुम्ही SSE आणि Streamable HTTP दोन्ही ट्रान्सपोर्ट्स वेगवेगळ्या एंडपॉईंटवर चालवून समर्थन देऊ शकता.
- हळूहळू क्लायंट्सना नवीन ट्रान्सपोर्टकडे माइग्रेट करा.

### आव्हाने

मायग्रेशन दरम्यान खालील आव्हाने हाताळा:

- सर्व क्लायंट्स अपडेट झाले आहेत याची खात्री करा.
- नोटिफिकेशन वितरणातील फरक सांभाळा.

### कार्य: स्वतःचे स्ट्रीमिंग MCP अॅप तयार करा

**परिस्थिती:**
एक MCP सर्व्हर आणि क्लायंट तयार करा जिथे सर्व्हर आयटम्सची यादी (उदा., फाइल्स किंवा दस्तऐवज) प्रक्रिया करतो आणि प्रत्येक प्रक्रियेसाठी नोटिफिकेशन पाठवतो. क्लायंट प्रत्येक नोटिफिकेशन येताच दाखवतो.

**पायऱ्या:**

1. अशी सर्व्हर टूल

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेत त्रुटी असू शकतात. मूळ दस्तऐवज त्याच्या मूळ भाषेत अधिकृत स्रोत मानला पाहिजे. महत्त्वाची माहिती असल्यास व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे झालेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागीसाठी आम्ही जबाबदार नाही.