<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:04:44+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ne"
}
-->
# Model Context Protocol (MCP) सँग HTTPS स्ट्रिमिङ

यो अध्यायले Model Context Protocol (MCP) प्रयोग गरी HTTPS मार्फत सुरक्षित, स्केलेबल, र वास्तविक-समय स्ट्रिमिङ कसरी कार्यान्वयन गर्ने बारे विस्तृत मार्गदर्शन प्रदान गर्दछ। यसमा स्ट्रिमिङको प्रेरणा, उपलब्ध ट्रान्सपोर्ट मेकानिजमहरू, MCP मा स्ट्रिमेबल HTTP कसरी कार्यान्वयन गर्ने, सुरक्षा सर्वोत्तम अभ्यासहरू, SSE बाट माइग्रेशन, र आफ्नै स्ट्रिमिङ MCP एप्लिकेसनहरू निर्माण गर्ने व्यावहारिक निर्देशन समावेश छ।

## MCP मा ट्रान्सपोर्ट मेकानिजमहरू र स्ट्रिमिङ

यस भागले MCP मा उपलब्ध विभिन्न ट्रान्सपोर्ट मेकानिजमहरू र तिनीहरूको भूमिका अन्वेषण गर्दछ जसले क्लाइन्ट र सर्भरबीच वास्तविक-समय सञ्चारका लागि स्ट्रिमिङ क्षमता सक्षम पार्छ।

### ट्रान्सपोर्ट मेकानिजम भनेको के हो?

ट्रान्सपोर्ट मेकानिजमले क्लाइन्ट र सर्भरबीच डेटा कसरी आदानप्रदान हुन्छ भन्ने परिभाषित गर्छ। MCP ले विभिन्न वातावरण र आवश्यकताहरूलाई मेल खाने विभिन्न ट्रान्सपोर्ट प्रकारहरू समर्थन गर्छ:

- **stdio**: मानक इनपुट/आउटपुट, स्थानीय र CLI-आधारित उपकरणहरूका लागि उपयुक्त। सरल तर वेब वा क्लाउडका लागि उपयुक्त छैन।
- **SSE (Server-Sent Events)**: सर्भरहरूले HTTP मार्फत क्लाइन्टहरूलाई वास्तविक-समय अपडेटहरू पठाउन अनुमति दिन्छ। वेब UI का लागि राम्रो, तर स्केलेबिलिटी र लचिलोपनमा सीमित।
- **Streamable HTTP**: आधुनिक HTTP-आधारित स्ट्रिमिङ ट्रान्सपोर्ट, सूचनाहरू र राम्रो स्केलेबिलिटी समर्थन गर्दै। अधिकांश उत्पादन र क्लाउड परिदृश्यहरूका लागि सिफारिस गरिएको।

### तुलना तालिका

यी ट्रान्सपोर्ट मेकानिजमहरूबीचको भिन्नता बुझ्न तलको तुलना तालिका हेर्नुहोस्:

| ट्रान्सपोर्ट        | वास्तविक-समय अपडेटहरू | स्ट्रिमिङ | स्केलेबिलिटी | प्रयोग केस               |
|--------------------|-----------------------|-----------|--------------|--------------------------|
| stdio              | छैन                  | छैन       | कम           | स्थानीय CLI उपकरणहरू     |
| SSE                | छ                    | छ         | मध्यम        | वेब, वास्तविक-समय अपडेटहरू |
| Streamable HTTP    | छ                    | छ         | उच्च         | क्लाउड, बहु-क्लाइन्ट    |

> **टिप:** उपयुक्त ट्रान्सपोर्ट छनोटले प्रदर्शन, स्केलेबिलिटी, र प्रयोगकर्ता अनुभवमा प्रभाव पार्छ। आधुनिक, स्केलेबल, र क्लाउड-तयार एप्लिकेसनहरूका लागि **Streamable HTTP** सिफारिस गरिन्छ।

पहिलेका अध्यायहरूमा देखाइएका stdio र SSE ट्रान्सपोर्टहरूलाई ध्यान दिनुहोस् र यो अध्यायमा कभर गरिएको Streamable HTTP ट्रान्सपोर्ट कसरी फरक छ।

## स्ट्रिमिङ: अवधारणा र प्रेरणा

स्ट्रिमिङका आधारभूत अवधारणा र प्रेरणालाई बुझ्नु प्रभावकारी वास्तविक-समय सञ्चार प्रणाली कार्यान्वयनका लागि आवश्यक छ।

**स्ट्रिमिङ** नेटवर्क प्रोग्रामिङमा यस्तो प्रविधि हो जसले डेटा सानो, व्यवस्थापनयोग्य भागहरूमा वा घटनाहरूको श्रृंखलाको रूपमा पठाउन र प्राप्त गर्न अनुमति दिन्छ, सम्पूर्ण प्रतिक्रिया तयार हुन कुर्नुको सट्टा। यो विशेष गरी उपयोगी छ:

- ठूला फाइलहरू वा डाटासेटहरूका लागि।
- वास्तविक-समय अपडेटहरू (जस्तै, च्याट, प्रगति बारहरू)।
- लामो समयसम्म चल्ने गणनाहरू जहाँ प्रयोगकर्तालाई जानकारी दिन आवश्यक हुन्छ।

स्ट्रिमिङका बारेमा तपाईंले माथिल्लो स्तरमा जान्नुपर्ने कुरा:

- डेटा क्रमिक रूपमा प्रदान गरिन्छ, सबै एकैपटक होइन।
- क्लाइन्टले डेटा प्राप्त हुने बित्तिकै प्रक्रिया गर्न सक्छ।
- अनुमानित विलम्ब घटाउँछ र प्रयोगकर्ता अनुभव सुधार गर्छ।

### किन स्ट्रिमिङ प्रयोग गर्ने?

स्ट्रिमिङ प्रयोग गर्ने कारणहरू यसप्रकार छन्:

- प्रयोगकर्ताहरूलाई तुरुन्त प्रतिक्रिया प्राप्त हुन्छ, अन्त्यमा मात्र होइन।
- वास्तविक-समय एप्लिकेसन र प्रतिक्रियाशील UI सक्षम बनाउँछ।
- नेटवर्क र कम्प्युट संसाधनहरूको अधिक कुशल उपयोग।

### सरल उदाहरण: HTTP स्ट्रिमिङ सर्भर र क्लाइन्ट

यहाँ स्ट्रिमिङ कसरी कार्यान्वयन गर्न सकिन्छ भन्ने सरल उदाहरण छ:

<details>
<summary>Python</summary>

**सर्भर (Python, FastAPI र StreamingResponse प्रयोग गर्दै):**
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

**क्लाइन्ट (Python, requests प्रयोग गर्दै):**
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

यस उदाहरणले देखाउँछ कि सर्भरले सबै सन्देशहरू तयार हुन कुर्नुको सट्टा उपलब्ध हुने बित्तिकै क्लाइन्टलाई सन्देशहरू पठाउँछ।

**यो कसरी काम गर्छ:**
- सर्भरले प्रत्येक सन्देश तयार भएपछि पठाउँछ।
- क्लाइन्टले प्रत्येक भाग प्राप्त गरी प्रिन्ट गर्छ।

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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) MCP मार्फत स्ट्रिमिङ छनोट गर्नुभन्दा।

- **सरल स्ट्रिमिङ आवश्यकताहरूका लागि:** क्लासिक HTTP स्ट्रिमिङ सरल र आधारभूत आवश्यकताहरूका लागि पर्याप्त छ।

- **जटिल, अन्तरक्रियात्मक एप्लिकेसनहरूका लागि:** MCP स्ट्रिमिङले अधिक संरचित तरिका प्रदान गर्छ, धनी मेटाडाटा र सूचनाहरू र अन्तिम परिणामहरू बीच छुट्टाछुट्टै विभाजनसहित।

- **AI एप्लिकेसनहरूको लागि:** MCP को सूचना प्रणाली लामो समयसम्म चल्ने AI कार्यहरूका लागि विशेष उपयोगी छ जहाँ तपाईंले प्रगति प्रयोगकर्तालाई जानकारी गराउन चाहनुहुन्छ।

## MCP मा स्ट्रिमिङ

अहिले सम्म तपाईंले क्लासिक स्ट्रिमिङ र MCP मा स्ट्रिमिङ बीचको सिफारिस र तुलना देख्नुभएको छ। अब हामी विस्तारमा जान्छौं कि MCP मा स्ट्रिमिङ कसरी प्रयोग गर्ने।

MCP फ्रेमवर्क भित्र स्ट्रिमिङ कसरी काम गर्छ भन्ने बुझ्नु आवश्यक छ ताकि लामो समयसम्म चल्ने अपरेसनहरूका क्रममा प्रयोगकर्तालाई वास्तविक-समय प्रतिक्रिया दिने प्रतिक्रियाशील एप्लिकेसनहरू बनाउन सकियोस्।

MCP मा, स्ट्रिमिङ भनेको मुख्य प्रतिक्रिया टुक्राहरूमा पठाउनु होइन, तर उपकरणले अनुरोध प्रक्रिया गर्दा क्लाइन्टलाई **सूचनाहरू** पठाउनु हो। यी सूचनाहरूमा प्रगति अपडेटहरू, लगहरू, वा अन्य घटनाहरू समावेश हुन सक्छन्।

### यो कसरी काम गर्छ

मुख्य परिणाम अझै एकल प्रतिक्रियाको रूपमा पठाइन्छ। तथापि, प्रक्रिया भइरहेको बेला सूचनाहरू अलग सन्देशहरूका रूपमा पठाउन सकिन्छ र यसले क्लाइन्टलाई वास्तविक-समयमा अपडेट गर्दछ। क्लाइन्टले यी सूचनाहरूलाई सम्हाल्न र प्रदर्शन गर्न सक्षम हुनुपर्छ।

## सूचना भनेको के हो?

हामीले "सूचना" भन्यौं, MCP सन्दर्भमा यसको अर्थ के हो?

सूचना भनेको लामो समयसम्म चल्ने अपरेसनको क्रममा प्रगति, स्थिति, वा अन्य घटनाहरूको बारेमा क्लाइन्टलाई जानकारी दिन सर्भरबाट पठाइने सन्देश हो। सूचनाले पारदर्शिता र प्रयोगकर्ता अनुभव सुधार गर्छ।

उदाहरणका लागि, क्लाइन्टले सर्भरसँग प्रारम्भिक ह्यान्डशेक पूरा भएपछि सूचना पठाउनुपर्छ।

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

सूचनाहरू MCP मा ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) भन्ने विषयसँग सम्बन्धित छन्।

लगिङ कार्यान्वयन गर्न सर्भरले यसलाई सुविधा/क्षमता रूपमा सक्षम पार्नुपर्छ, यसरी:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> प्रयोग गरिएको SDK अनुसार, लगिङ डिफल्टमा सक्षम हुन सक्छ, वा तपाईंले सर्भर कन्फिगरेसनमा स्पष्ट रूपमा सक्षम पार्नुपर्ने हुन सक्छ।

सूचनाका विभिन्न प्रकारहरू छन्:

| स्तर       | विवरण                          | उदाहरण प्रयोग केस             |
|------------|--------------------------------|-------------------------------|
| debug      | विस्तृत डिबगिङ जानकारी         | फंक्शन प्रवेश/निकास बिन्दुहरू |
| info       | सामान्य सूचना सन्देशहरू         | अपरेसन प्रगति अपडेटहरू       |
| notice     | सामान्य तर महत्वपूर्ण घटनाहरू | कन्फिगरेसन परिवर्तनहरू        |
| warning    | चेतावनी अवस्था                 | पुरानो सुविधाको प्रयोग        |
| error      | त्रुटि अवस्था                  | अपरेसन असफलता                |
| critical   | गम्भीर अवस्था                 | प्रणाली कम्पोनेन्ट असफलता     |
| alert      | तुरुन्त कदम चाल्नु पर्छ       | डाटा भ्रष्टाचार पत्ता लाग्यो    |
| emergency  | प्रणाली प्रयोगयोग्य छैन         | पूर्ण प्रणाली असफलता          |

## MCP मा सूचना कार्यान्वयन

MCP मा सूचना कार्यान्वयन गर्न, तपाईंले सर्भर र क्लाइन्ट दुवै पक्षमा वास्तविक-समय अपडेटहरू सम्हाल्न सेटअप गर्नुपर्छ। यसले लामो समयसम्म चल्ने अपरेसनहरूका क्रममा प्रयोगकर्तालाई तुरुन्त प्रतिक्रिया दिन अनुमति दिन्छ।

### सर्भर-पक्ष: सूचना पठाउने

सर्भर पक्षबाट सुरु गरौं। MCP मा, तपाईंले यस्ता उपकरणहरू परिभाषित गर्नुहुन्छ जसले अनुरोध प्रक्रिया गर्दा सूचना पठाउन सक्छन्। सर्भरले सन्देश पठाउन प्रायः `ctx` नामक कन्टेक्स्ट वस्तु प्रयोग गर्छ।

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

### क्लाइन्ट-पक्ष: सूचना प्राप्त गर्ने

क्लाइन्टले सूचना प्राप्त र प्रदर्शन गर्न सन्देश ह्यान्डलर कार्यान्वयन गर्नुपर्छ।

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` प्रयोग गरिएको छ र तपाईंको क्लाइन्टले सूचना प्रक्रिया गर्न सन्देश ह्यान्डलर कार्यान्वयन गरेको छ।

## प्रगति सूचनाहरू र परिदृश्यहरू

यस भागले MCP मा प्रगति सूचनाको अवधारणा, यसको महत्व, र Streamable HTTP प्रयोग गरी कसरी कार्यान्वयन गर्ने व्याख्या गर्दछ। साथै तपाईंको बुझाइलाई मजबुत बनाउन व्यावहारिक कार्यसम्पादन पनि समावेश छ।

प्रगति सूचनाहरू लामो समयसम्म चल्ने अपरेसनहरूका क्रममा सर्भरबाट क्लाइन्टलाई पठाइने वास्तविक-समय सन्देशहरू हुन्। सम्पूर्ण प्रक्रिया पूरा हुन कुर्नुको सट्टा, सर्भरले वर्तमान स्थिति बारे क्लाइन्टलाई अपडेट राख्छ। यसले पारदर्शिता, प्रयोगकर्ता अनुभव सुधार्छ र डिबगिङ सजिलो बनाउँछ।

**उदाहरण:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### किन प्रगति सूचनाहरू प्रयोग गर्ने?

प्रगति सूचनाहरू धेरै कारणले आवश्यक छन्:

- **राम्रो प्रयोगकर्ता अनुभव:** काम प्रगति भइरहँदा अपडेटहरू देखिन्छन्, अन्त्यमा मात्र होइन।
- **वास्तविक-समय प्रतिक्रिया:** क्लाइन्टहरूले प्रगति बार वा लगहरू देखाउन सक्छन्, जसले एप्लिकेसनलाई प्रतिक्रियाशील बनाउँछ।
- **डिबगिङ र अनुगमन सजिलो:** विकासकर्ता र प्रयोगकर्ताले प्रक्रिया कहाँ ढिलो वा अड्किएको छ भनेर देख्न सक्छन्।

### प्रगति सूचनाहरू कसरी कार्यान्वयन गर्ने

MCP मा प्रगति सूचनाहरू कार्यान्वयन गर्ने तरिका:

- **सर्भरमा:** `ctx.info()` or `ctx.log()` प्रयोग गरी प्रत्येक वस्तु प्रक्रिया हुँदा सूचना पठाउनुहोस्। यसले मुख्य परिणाम तयार हुनु अघि क्लाइन्टलाई सन्देश पठाउँछ।
- **क्लाइन्टमा:** सूचना प्राप्त र प्रदर्शन गर्न सन्देश ह्यान्डलर कार्यान्वयन गर्नुहोस्। यसले सूचनाहरू र अन्तिम परिणाम छुट्याउँछ।

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

## सुरक्षा विचारहरू

HTTP-आधारित ट्रान्सपोर्टहरूसँग MCP सर्भरहरू कार्यान्वयन गर्दा सुरक्षा अत्यन्त महत्वपूर्ण हुन्छ र विभिन्न आक्रमण भेक्टर र सुरक्षा उपायहरूमा ध्यान दिन आवश्यक हुन्छ।

### अवलोकन

HTTP मार्फत MCP सर्भरहरू एक्सपोज गर्दा सुरक्षा आवश्यक हुन्छ। Streamable HTTP नयाँ आक्रमण सतहहरू प्रस्तुत गर्छ र सावधानीपूर्वक कन्फिगरेसन आवश्यक पर्छ।

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
2. **Update client code** to use `streamablehttp_client` प्रमाणीकरण गर्नुहोस्, SSE क्लाइन्टको सट्टा।
3. **क्लाइन्टमा सन्देश ह्यान्डलर कार्यान्वयन गर्नुहोस्** सूचना प्रक्रिया गर्न।
4. **अवस्थित उपकरण र कार्यप्रवाहसँग उपयुक्तता परीक्षण गर्नुहोस्।**

### उपयुक्तता कायम राख्ने

माइग्रेशन प्रक्रियामा विद्यमान SSE क्लाइन्टहरूसँग उपयुक्तता कायम राख्न सिफारिस गरिन्छ। यहाँ केही रणनीतिहरू छन्:

- तपाईं SSE र Streamable HTTP दुवै समर्थन गर्न सक्नुहुन्छ, अलग-अलग अन्तबिन्दुहरूमा दुवै ट्रान्सपोर्ट चलाएर।
- क्रमिक रूपमा क्लाइन्टहरूलाई नयाँ ट्रान्सपोर्टमा माइग्रेट गर्नुहोस्।

### चुनौतीहरू

माइग्रेशनको क्रममा निम्न चुनौतीहरू सम्बोधन गर्नुपर्छ:

- सबै क्लाइन्टहरू अपडेट गरिएको सुनिश्चित गर्नु।
- सूचना डेलिभरीमा भिन्नता सम्हाल्नु।

### कार्य: आफ्नै स्ट्रिमिङ MCP एप बनाउनुहोस्

**परिदृश्य:**
एउटा MCP सर्भर र क्लाइन्ट बनाउनुहोस् जहाँ सर्भरले वस्तुहरूको सूची (जस्तै, फाइलहरू वा कागजातहरू) प्रक्रिया गर्छ र प्रत्येक प्रक्रिया गरिएको वस्तुको लागि सूचना पठाउँछ। क्लाइन्टले प्रत्येक सूचना प्राप्त हुने बित्तिकै प्रदर्शन गर्नुपर्छ।

**चरणहरू:**

1. सूचनाहरू पठाउने सूची प्रक्रिया गर्ने सर्भर उपकरण कार्यान्वयन गर्नुहोस्।
2. वास्तविक-समयमा सूचनाहरू प्रदर्शन गर्न सन्देश ह्यान्डलर सहित क्लाइन्ट कार्यान्वयन गर्नुहोस्।
3. दुवै सर्भर र क्लाइन्ट चलाएर परीक्षण गर्नुहोस् र सूचनाहरू अवलोकन गर्नुहोस्।

[Solution](./solution/README.md)

## थप पढाइ र के गर्ने?

MCP स्ट्रिमिङसँग आफ्नो यात्रा जारी राख्न र ज्ञान विस्तार गर्न, यस भागले थप स्रोतहरू र उन्नत एप्लिकेसनहरू निर्माणका लागि सुझावहरू प्रदान गर्दछ।

### थप पढाइ

- [Microsoft: HTTP स्ट्रिमिङ परिचय](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core मा CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### के गर्ने?

- वास्तविक-समय विश्लेषण, च्याट, वा सहकार्य सम्पादनका लागि स्ट्रिमिङ प्रयोग गर्ने थप उन्नत MCP उपकरणहरू बनाउने प्रयास गर्नुहोस्।
- फ्रन्टएन्ड फ्रेमवर्कहरू (React, Vue, आदि) सँग MCP स्ट्रिमिङ एकीकृत गर्ने अन्वेषण गर्नुहोस् ताकि प्रत्यक्ष UI अपडेटहरू सम्भव होस्।
- अर्को: [VSCode का लागि AI Toolkit प्रयोग](../07-aitk/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताको प्रयास गर्छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।