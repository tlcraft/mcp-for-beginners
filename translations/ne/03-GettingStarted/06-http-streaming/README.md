<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:38:42+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ne"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

यो अध्यायले HTTPS मार्फत Model Context Protocol (MCP) प्रयोग गरेर सुरक्षित, स्केलेबल, र रियल-टाइम स्ट्रिमिङ कसरी कार्यान्वयन गर्ने बारे विस्तृत मार्गदर्शन दिन्छ। यसले स्ट्रिमिङको प्रेरणा, उपलब्ध ट्रान्सपोर्ट मेकानिजमहरू, MCP मा स्ट्रिमेबल HTTP कसरी लागू गर्ने, सुरक्षा उत्तम अभ्यासहरू, SSE बाट माइग्रेशन, र आफ्नै स्ट्रिमिङ MCP एप्लिकेसनहरू बनाउने व्यावहारिक निर्देशनहरू समेट्छ।

## MCP मा ट्रान्सपोर्ट मेकानिजमहरू र स्ट्रिमिङ

यस भागले MCP मा उपलब्ध विभिन्न ट्रान्सपोर्ट मेकानिजमहरू र ती कसरी क्लाइन्ट र सर्भर बीच रियल-टाइम सञ्चारका लागि स्ट्रिमिङ क्षमता सक्षम पार्छन् भन्ने कुरा अन्वेषण गर्छ।

### ट्रान्सपोर्ट मेकानिजम भनेको के हो?

ट्रान्सपोर्ट मेकानिजमले क्लाइन्ट र सर्भर बीच डेटा कसरी आदानप्रदान हुन्छ भन्ने परिभाषित गर्छ। MCP ले विभिन्न वातावरण र आवश्यकताहरूका लागि बहु ट्रान्सपोर्ट प्रकारहरू समर्थन गर्दछ:

- **stdio**: मानक इनपुट/आउटपुट, स्थानीय र CLI आधारित उपकरणहरूका लागि उपयुक्त। सरल तर वेब वा क्लाउडका लागि उपयुक्त छैन।
- **SSE (Server-Sent Events)**: सर्भरहरूले HTTP मार्फत क्लाइन्टलाई रियल-टाइम अपडेटहरू पठाउन अनुमति दिन्छ। वेब UI का लागि राम्रो, तर स्केलेबिलिटी र लचिलोपनमा सीमित।
- **Streamable HTTP**: आधुनिक HTTP आधारित स्ट्रिमिङ ट्रान्सपोर्ट, जसले सूचना र राम्रो स्केलेबिलिटी समर्थन गर्दछ। अधिकांश उत्पादन र क्लाउड परिदृश्यहरूका लागि सिफारिस गरिन्छ।

### तुलना तालिका

यी ट्रान्सपोर्ट मेकानिजमहरू बीचको भिन्नता बुझ्न तलको तुलना तालिका हेर्नुहोस्:

| Transport         | रियल-टाइम अपडेटहरू | स्ट्रिमिङ | स्केलेबिलिटी | प्रयोग केस               |
|-------------------|--------------------|-----------|--------------|--------------------------|
| stdio             | छैन               | छैन       | कम           | स्थानीय CLI उपकरणहरू     |
| SSE               | छ                 | छ         | मध्यम        | वेब, रियल-टाइम अपडेटहरू|
| Streamable HTTP   | छ                 | छ         | उच्च         | क्लाउड, बहु-क्लाइन्ट     |

> **Tip:** उपयुक्त ट्रान्सपोर्ट चयन गर्दा प्रदर्शन, स्केलेबिलिटी, र प्रयोगकर्ता अनुभवमा प्रभाव पर्छ। आधुनिक, स्केलेबल, र क्लाउड-तयार एप्लिकेसनहरूको लागि **Streamable HTTP** सिफारिस गरिन्छ।

अघिल्ला अध्यायहरूमा देखाइएका stdio र SSE ट्रान्सपोर्टहरूलाई नोट गर्नुहोस् र यो अध्यायमा समेटिएको Streamable HTTP ट्रान्सपोर्टलाई बुझ्नुहोस्।

## स्ट्रिमिङ: अवधारणा र प्रेरणा

स्ट्रिमिङको मूल अवधारणा र प्रेरणा बुझ्नु प्रभावकारी रियल-टाइम सञ्चार प्रणालीहरू कार्यान्वयन गर्न महत्त्वपूर्ण छ।

**स्ट्रिमिङ** नेटवर्क प्रोग्रामिङमा यस्तो प्रविधि हो जसले पूर्ण प्रतिक्रिया तयार नभएसम्म पर्खनुको सट्टा साना, व्यवस्थापनयोग्य भागहरू वा घटनाहरूको श्रृंखलाको रूपमा डेटा पठाउन र प्राप्त गर्न अनुमति दिन्छ। यो विशेष गरी उपयोगी छ:

- ठूला फाइलहरू वा डेटासेटहरूका लागि।
- रियल-टाइम अपडेटहरू (जस्तै, च्याट, प्रगति बारहरू)।
- लामो समय चल्ने गणनाहरू जहाँ प्रयोगकर्तालाई सूचित राख्न चाहिन्छ।

स्ट्रिमिङका बारेमा तपाईंले थाहा पाउनुपर्ने मुख्य कुरा:

- डेटा क्रमिक रूपमा पठाइन्छ, सबै एकैपटक होइन।
- क्लाइन्टले डेटा आइरहँदा प्रशोधन गर्न सक्छ।
- महसुस गरिएको ढिलाइ कम गर्छ र प्रयोगकर्ता अनुभव सुधार्छ।

### किन स्ट्रिमिङ प्रयोग गर्ने?

स्ट्रिमिङ प्रयोग गर्ने कारणहरू यस्ता छन्:

- प्रयोगकर्ताले तुरुन्तै प्रतिक्रिया पाउँछन्, अन्त्यमा मात्र होइन।
- रियल-टाइम एप्लिकेसन र प्रतिक्रियाशील UI सक्षम पार्छ।
- नेटवर्क र कम्प्युट स्रोतहरूको अधिक कुशल उपयोग।

### सरल उदाहरण: HTTP स्ट्रिमिङ सर्भर र क्लाइन्ट

यहाँ स्ट्रिमिङ कसरी कार्यान्वयन गर्न सकिन्छ भन्ने सरल उदाहरण छ:

<details>
<summary>Python</summary>

**सर्भर (Python, FastAPI र StreamingResponse प्रयोग गरेर):**
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

**क्लाइन्ट (Python, requests प्रयोग गरेर):**
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

यस उदाहरणले देखाउँछ कि सर्भरले सबै सन्देश तयार नभएसम्म पर्खनुको सट्टा उपलब्ध हुँदा क्लाइन्टलाई सन्देशहरू क्रमशः पठाउँछ।

**यसरी काम गर्छ:**
- सर्भर प्रत्येक सन्देश तयार भएपछि पठाउँछ।
- क्लाइन्ट प्रत्येक भाग प्राप्त हुँदा प्रिन्ट गर्छ।

**आवश्यकताहरू:**
- सर्भरले स्ट्रिमिङ प्रतिक्रिया प्रयोग गर्नुपर्छ (जस्तै, `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) MCP मार्फत स्ट्रिमिङ चयन गर्ने सट्टा।

- **सरल स्ट्रिमिङ आवश्यकताका लागि:** क्लासिक HTTP स्ट्रिमिङ सजिलो र आधारभूत आवश्यकताका लागि पर्याप्त हुन्छ।

- **जटिल, अन्तरक्रियात्मक एप्लिकेसनका लागि:** MCP स्ट्रिमिङले धनी मेटाडाटा र सूचना तथा अन्तिम परिणाम बीच छुट्याउने संरचनात्मक दृष्टिकोण प्रदान गर्छ।

- **AI एप्लिकेसनहरूका लागि:** MCP को सूचना प्रणाली लामो समय चल्ने AI कार्यहरूमा प्रगति सूचित गर्न उपयोगी छ।

## MCP मा स्ट्रिमिङ

अबसम्म तपाईंले क्लासिक स्ट्रिमिङ र MCP मा स्ट्रिमिङ बीचको भिन्नता सम्बन्धी सिफारिस र तुलना देख्नुभएको छ। अब MCP मा स्ट्रिमिङ कसरी प्रयोग गर्ने भनेर विस्तृत रूपमा बुझौं।

MCP फ्रेमवर्क भित्र स्ट्रिमिङ कसरी काम गर्छ भन्ने बुझ्नु प्रतिक्रियाशील एप्लिकेसनहरू निर्माण गर्न आवश्यक छ जसले लामो समय लाग्ने अपरेसनहरूमा प्रयोगकर्तालाई रियल-टाइम प्रतिक्रिया दिन्छ।

MCP मा स्ट्रिमिङको अर्थ मुख्य प्रतिक्रिया टुक्र्याएर पठाउनु होइन, तर टूलले अनुरोध प्रक्रिया गरिरहेको बेला क्लाइन्टलाई **सूचना (notifications)** पठाउनु हो। यी सूचनाहरूमा प्रगति अपडेट, लगहरू, वा अन्य घटनाहरू समावेश हुन सक्छन्।

### कसरी काम गर्छ

मुख्य परिणाम अझै एकल प्रतिक्रिया रूपमा पठाइन्छ। तर प्रक्रिया हुँदै गर्दा सूचना छुट्टै सन्देशका रूपमा पठाइन्छ र यसले क्लाइन्टलाई रियल-टाइम अपडेट दिन्छ। क्लाइन्टले यी सूचनाहरूलाई सम्हाल्न र प्रदर्शन गर्न सक्षम हुनुपर्छ।

## सूचना भनेको के हो?

हामीले "सूचना" भनेका थियौं, MCP सन्दर्भमा यसको अर्थ के हो?

सूचना भनेको सर्भरबाट क्लाइन्टतर्फ पठाइने सन्देश हो जसले लामो समय लाग्ने अपरेसनको प्रगति, स्थिति, वा अन्य घटनाहरूको जानकारी दिन्छ। सूचनाले पारदर्शिता र प्रयोगकर्ता अनुभव सुधार्छ।

उदाहरणका लागि, क्लाइन्टले सर्भरसँग प्रारम्भिक ह्यान्डशेक भएपछि सूचना पठाउनुपर्छ।

सूचना JSON सन्देशको रूपमा यसरी देखिन्छ:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

सूचनाहरू MCP मा ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) नामक विषयसँग सम्बन्धित छन्।

लगिङ काम गर्नको लागि सर्भरले यो सुविधा/क्षमता यसरी सक्षम पार्नुपर्छ:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> प्रयोग गरिएको SDK अनुसार, लगिङ डिफल्ट रूपमा सक्षम हुन सक्छ, वा तपाईंले सर्भर कन्फिगरेसनमा स्पष्ट रूपमा सक्षम पार्नुपर्ने हुन सक्छ।

विभिन्न प्रकारका सूचनाहरू छन्:

| स्तर       | विवरण                         | उदाहरण प्रयोग केस              |
|------------|------------------------------|-------------------------------|
| debug      | विस्तृत डिबग जानकारी          | फङ्सन प्रवेश/निकास बिन्दुहरू    |
| info       | सामान्य सूचना सन्देशहरू        | अपरेसन प्रगति अपडेटहरू         |
| notice     | सामान्य तर महत्वपूर्ण घटनाहरू | कन्फिगरेसन परिवर्तनहरू          |
| warning    | चेतावनी अवस्था                | डिप्रिकेटेड फिचर प्रयोग        |
| error      | त्रुटि अवस्था                 | अपरेसन असफलता                  |
| critical   | गम्भीर अवस्था                | सिस्टम कम्पोनेंट असफलता         |
| alert      | तुरुन्त कारबाही आवश्यक          | डाटा भ्रष्टाचार पत्ता लाग्यो      |
| emergency  | सिस्टम प्रयोगयोग्य छैन          | पूर्ण सिस्टम असफलता             |

## MCP मा सूचनाहरू कार्यान्वयन गर्ने

MCP मा सूचनाहरू कार्यान्वयन गर्न, तपाईंले सर्भर र क्लाइन्ट दुवै पक्षलाई रियल-टाइम अपडेटहरू ह्यान्डल गर्न सेटअप गर्नुपर्छ। यसले तपाईंको एप्लिकेसनलाई लामो समय लाग्ने अपरेसनहरूमा प्रयोगकर्तालाई तुरुन्त प्रतिक्रिया दिन सक्षम बनाउँछ।

### सर्भर-पक्ष: सूचना पठाउने

सर्भर पक्षबाट सुरु गरौं। MCP मा, तपाईंले यस्ता टूलहरू परिभाषित गर्नुहुन्छ जसले अनुरोध प्रक्रिया गर्दा सूचना पठाउन सक्छन्। सर्भरले सामान्यतया `ctx` नामक सन्दर्भ वस्तु प्रयोग गरी क्लाइन्टलाई सन्देश पठाउँछ।

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

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ट्रान्सपोर्ट:

```python
mcp.run(transport="streamable-http")
```

</details>

### क्लाइन्ट-पक्ष: सूचना प्राप्त गर्ने

क्लाइन्टले सूचना प्राप्त गरी प्रदर्शन गर्न सन्देश ह्यान्डलर कार्यान्वयन गर्नुपर्छ।

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

अघिल्लो कोडमा, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) प्रयोग गरिएको छ र तपाईंको क्लाइन्टले सूचना प्रशोधन गर्न सन्देश ह्यान्डलर कार्यान्वयन गरेको छ।

## प्रगति सूचनाहरू र परिदृश्यहरू

यस भागले MCP मा प्रगति सूचनाहरूको अवधारणा, यसको महत्त्व, र Streamable HTTP प्रयोग गरेर कसरी लागू गर्ने भन्ने कुरा व्याख्या गर्छ। साथै, तपाईंको बुझाइ सुदृढ गर्न व्यावहारिक अभ्यास पनि समावेश छ।

प्रगति सूचनाहरू लामो समय लाग्ने अपरेसनहरूका क्रममा सर्भरबाट क्लाइन्टलाई पठाइने रियल-टाइम सन्देशहरू हुन्। सम्पूर्ण प्रक्रिया समाप्त नभएसम्म पर्खनुको सट्टा, सर्भरले क्लाइन्टलाई वर्तमान स्थिति अपडेट गरिरहन्छ। यसले पारदर्शिता, प्रयोगकर्ता अनुभव सुधार्छ र डिबगिङ सजिलो बनाउँछ।

**उदाहरण:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### किन प्रगति सूचनाहरू प्रयोग गर्ने?

प्रगति सूचनाहरू आवश्यक हुने मुख्य कारणहरू:

- **राम्रो प्रयोगकर्ता अनुभव:** काम प्रगति हुँदै गर्दा अपडेटहरू देखिन्छन्, अन्त्यमा मात्र होइन।
- **रियल-टाइम प्रतिक्रिया:** क्लाइन्टहरूले प्रगति बार वा लगहरू देखाउन सक्छन्, जसले एप्लिकेसनलाई प्रतिक्रियाशील बनाउँछ।
- **डिबगिङ र मोनिटरिङ सजिलो:** विकासकर्ता र प्रयोगकर्ताले प्रक्रिया कहिँ ढिलो वा अड्किएको छ कि छैन देख्न सक्छन्।

### प्रगति सूचनाहरू कसरी कार्यान्वयन गर्ने

MCP मा प्रगति सूचनाहरू कार्यान्वयन गर्ने तरिका:

- **सर्भरमा:** `ctx.info()` or `ctx.log()` प्रयोग गरेर प्रत्येक वस्तु प्रक्रिया हुँदा सूचना पठाउनुहोस्। यसले मुख्य परिणाम तयार हुनु अघि क्लाइन्टलाई सन्देश पठाउँछ।
- **क्लाइन्टमा:** सन्देश ह्यान्डलर कार्यान्वयन गर्नुहोस् जसले आइरहेका सूचनाहरू सुन्छ र प्रदर्शन गर्छ। यो ह्यान्डलरले सूचनाहरू र अन्तिम परिणाम फरक पार्छ।

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

**क्लाइन्ट उदाहरण:**

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

## सुरक्षा सम्बन्धी विचारहरू

HTTP आधारित ट्रान्सपोर्टहरू सहित MCP सर्भरहरू कार्यान्वयन गर्दा सुरक्षा अत्यन्त महत्त्वपूर्ण हुन्छ र विभिन्न आक्रमण पथहरू र सुरक्षा उपायहरूमा ध्यान दिनुपर्छ।

### अवलोकन

HTTP मार्फत MCP सर्भरहरू एक्स्पोज गर्दा सुरक्षा अति आवश्यक हुन्छ। Streamable HTTP नयाँ आक्रमण सतहहरू प्रस्तुत गर्दछ र सावधानीपूर्वक कन्फिगरेसन आवश्यक पर्छ।

### मुख्य बुँदाहरू
- **Origin Header Validation**: सधैं `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` जाँच गर्नुहोस्, SSE क्लाइन्टको सट्टा।
3. **क्लाइन्टमा सन्देश ह्यान्डलर कार्यान्वयन गर्नुहोस्** सूचना प्रशोधन गर्न।
4. **अवस्थित उपकरण र कार्यप्रवाहहरूसँग अनुकूलता परीक्षण गर्नुहोस्।**

### अनुकूलता कायम राख्ने

माइग्रेशन प्रक्रियामा विद्यमान SSE क्लाइन्टहरूसँग अनुकूलता कायम राख्न सिफारिस गरिन्छ। केही रणनीतिहरू:

- फरक एन्डपोइन्टहरूमा SSE र Streamable HTTP दुवै ट्रान्सपोर्ट चलाएर समर्थन गर्न सकिन्छ।
- क्लाइन्टहरूलाई क्रमशः नयाँ ट्रान्सपोर्टमा माइग्रेट गर्न सकिन्छ।

### चुनौतीहरू

माइग्रेशनको क्रममा यी चुनौतीहरू समाधान गर्नुपर्छ:

- सबै क्लाइन्टहरू अपडेट गरिएको सुनिश्चित गर्नु।
- सूचना डेलिभरीमा भिन्नता सम्हाल्नु।

### अभ्यास: आफ्नै स्ट्रिमिङ MCP एप्लिकेसन बनाउनुहोस्

**परिदृश्य:**
एक MCP सर्भर र क्लाइन्ट बनाउनुहोस् जहाँ सर्भरले वस्तुहरूको सूची (जस्तै, फाइलहरू वा कागजातहरू) प्रक्रिया गर्छ र प्रत्येक वस्तु प्रक्रिया भएपछि सूचना पठाउँछ। क्लाइन्टले प्रत्येक सूचना प्राप्त हुने बित्तिकै देखाउनु पर्छ।

**चरणहरू:**

1. सूची प्रक्रिया गर्ने र प्रत्येक वस्तुका लागि सूचना पठाउने सर्भर टूल कार्यान्वयन गर्नुहोस्।
2. सूचना रियल-टाइम देखाउन सन्देश ह्यान्डलर सहित क्लाइन्ट कार्यान्वयन गर्नुहोस्।
3. सर्भर र क्लाइन्ट दुवै चलाएर परीक्षण गर्नुहोस् र सूचनाहरू अवलोकन गर्नुहोस्।

[Solution](./solution/README.md)

## थप पढाइ र के गर्ने?

MCP स्ट्रिमिङसँगको यात्रा जारी राख्न र ज्ञान विस्तार गर्न, यस भागले थप स्रोतहरू र अगाडि बढ्नका लागि सुझावहरू प्रदान गर्दछ।

### थप पढाइ

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### के गर्ने?

- रियल-टाइम एनालिटिक्स, च्याट, वा सहकार्यात्मक सम्पादनका लागि स्ट्रिमिङ प्रयोग गर्ने उन्नत MCP टूलहरू बनाउन प्रयास गर्नुहोस्।
- MCP स्ट्रिमिङलाई फ्रन्टएन्ड फ्रेमवर्कहरू (React, Vue, आदि) सँग एकीकृत गरेर लाइभ UI अपडेटहरू अन्वेषण गर्नुहोस्।
- अर्को: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) को प्रयोग गरी अनुवाद गरिएको हो। हामी सटीकताको लागि प्रयास गर्छौं, तर कृपया जानकार हुनुहोस् कि स्वचालित अनुवादमा त्रुटिहरू वा अशुद्धिहरू हुनसक्छन्। मूल दस्तावेज यसको मूल भाषामा आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीको लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।