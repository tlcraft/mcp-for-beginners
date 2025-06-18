<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:01:19+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "hi"
}
-->
# HTTPS स्ट्रीमिंग विथ मॉडल कॉन्टेक्स्ट प्रोटोकॉल (MCP)

यह अध्याय HTTPS का उपयोग करके मॉडल कॉन्टेक्स्ट प्रोटोकॉल (MCP) के साथ सुरक्षित, स्केलेबल और रीयल-टाइम स्ट्रीमिंग को लागू करने के लिए एक व्यापक मार्गदर्शिका प्रदान करता है। इसमें स्ट्रीमिंग के पीछे प्रेरणा, उपलब्ध ट्रांसपोर्ट मेकेनिज्म, MCP में स्ट्रीमेबल HTTP को कैसे लागू करें, सुरक्षा सर्वोत्तम प्रथाएं, SSE से माइग्रेशन, और अपने स्वयं के स्ट्रीमिंग MCP एप्लिकेशन बनाने के लिए व्यावहारिक मार्गदर्शन शामिल है।

## MCP में ट्रांसपोर्ट मेकेनिज्म और स्ट्रीमिंग

यह अनुभाग MCP में उपलब्ध विभिन्न ट्रांसपोर्ट मेकेनिज्म और उनके क्लाइंट और सर्वर के बीच रीयल-टाइम संचार के लिए स्ट्रीमिंग क्षमताओं को सक्षम करने में उनकी भूमिका की जांच करता है।

### ट्रांसपोर्ट मेकेनिज्म क्या है?

ट्रांसपोर्ट मेकेनिज्म यह परिभाषित करता है कि क्लाइंट और सर्वर के बीच डेटा कैसे आदान-प्रदान होता है। MCP विभिन्न वातावरणों और आवश्यकताओं के अनुरूप कई ट्रांसपोर्ट प्रकारों का समर्थन करता है:

- **stdio**: स्टैण्डर्ड इनपुट/आउटपुट, स्थानीय और CLI-आधारित टूल्स के लिए उपयुक्त। सरल लेकिन वेब या क्लाउड के लिए उपयुक्त नहीं।
- **SSE (Server-Sent Events)**: सर्वर को HTTP के माध्यम से क्लाइंट को रीयल-टाइम अपडेट भेजने की अनुमति देता है। वेब UI के लिए अच्छा, लेकिन स्केलेबिलिटी और लचीलापन सीमित।
- **Streamable HTTP**: आधुनिक HTTP-आधारित स्ट्रीमिंग ट्रांसपोर्ट, नोटिफिकेशन और बेहतर स्केलेबिलिटी का समर्थन करता है। अधिकांश प्रोडक्शन और क्लाउड परिदृश्यों के लिए अनुशंसित।

### तुलना तालिका

नीचे दी गई तुलना तालिका देखें ताकि आप इन ट्रांसपोर्ट मेकेनिज्म के बीच के अंतर को समझ सकें:

| ट्रांसपोर्ट        | रीयल-टाइम अपडेट्स | स्ट्रीमिंग | स्केलेबिलिटी | उपयोग का मामला          |
|-------------------|--------------------|-----------|--------------|------------------------|
| stdio             | नहीं               | नहीं      | कम           | स्थानीय CLI टूल्स       |
| SSE               | हाँ                | हाँ       | मध्यम        | वेब, रीयल-टाइम अपडेट्स |
| Streamable HTTP   | हाँ                | हाँ       | उच्च         | क्लाउड, मल्टी-क्लाइंट  |

> **टिप:** सही ट्रांसपोर्ट चुनना प्रदर्शन, स्केलेबिलिटी और उपयोगकर्ता अनुभव को प्रभावित करता है। **Streamable HTTP** आधुनिक, स्केलेबल और क्लाउड-तैयार एप्लिकेशन के लिए अनुशंसित है।

पिछले अध्यायों में आपको दिखाए गए stdio और SSE ट्रांसपोर्ट पर ध्यान दें और यह भी कि इस अध्याय में कवर किया गया ट्रांसपोर्ट स्ट्रीमेबल HTTP है।

## स्ट्रीमिंग: अवधारणाएँ और प्रेरणा

स्ट्रीमिंग के मूलभूत सिद्धांतों और प्रेरणाओं को समझना प्रभावी रीयल-टाइम संचार प्रणालियों को लागू करने के लिए आवश्यक है।

**स्ट्रीमिंग** नेटवर्क प्रोग्रामिंग में एक तकनीक है जो डेटा को छोटे, प्रबंधनीय हिस्सों में या घटनाओं की एक श्रृंखला के रूप में भेजने और प्राप्त करने की अनुमति देती है, बजाय इसके कि पूरी प्रतिक्रिया के तैयार होने का इंतजार किया जाए। यह विशेष रूप से उपयोगी है:

- बड़े फाइल या डेटा सेट के लिए।
- रीयल-टाइम अपडेट्स (जैसे चैट, प्रोग्रेस बार) के लिए।
- लंबी अवधि के गणना कार्यों के लिए जहाँ आप उपयोगकर्ता को सूचित रखना चाहते हैं।

स्ट्रीमिंग के बारे में उच्च स्तर पर आपको यह जानना चाहिए:

- डेटा धीरे-धीरे भेजा जाता है, सभी एक साथ नहीं।
- क्लाइंट डेटा को जैसे ही प्राप्त करता है, प्रोसेस कर सकता है।
- अनुमानित विलंबता कम करता है और उपयोगकर्ता अनुभव को बेहतर बनाता है।

### स्ट्रीमिंग क्यों उपयोग करें?

स्ट्रीमिंग का उपयोग करने के कारण निम्नलिखित हैं:

- उपयोगकर्ताओं को तुरंत प्रतिक्रिया मिलती है, केवल अंत में नहीं।
- रीयल-टाइम एप्लिकेशन और प्रतिक्रियाशील UI सक्षम करता है।
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

यह उदाहरण दर्शाता है कि सर्वर क्लाइंट को संदेशों की एक श्रृंखला भेजता है जैसे ही वे उपलब्ध होते हैं, बजाय इसके कि सभी संदेश तैयार होने का इंतजार किया जाए।

**यह कैसे काम करता है:**
- सर्वर प्रत्येक संदेश को जैसे ही वह तैयार होता है, भेजता है।
- क्लाइंट प्रत्येक भाग को प्राप्त करता है और जैसे ही आता है प्रिंट करता है।

**आवश्यकताएँ:**
- सर्वर को स्ट्रीमिंग प्रतिक्रिया का उपयोग करना चाहिए (जैसे `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) बजाय MCP के माध्यम से स्ट्रीमिंग चुनने के।

- **सरल स्ट्रीमिंग आवश्यकताओं के लिए:** क्लासिक HTTP स्ट्रीमिंग लागू करने में सरल है और बुनियादी स्ट्रीमिंग जरूरतों के लिए पर्याप्त है।

- **जटिल, इंटरैक्टिव एप्लिकेशन के लिए:** MCP स्ट्रीमिंग एक अधिक संरचित दृष्टिकोण प्रदान करता है जिसमें समृद्ध मेटाडेटा और नोटिफिकेशन तथा अंतिम परिणाम के बीच पृथक्करण होता है।

- **AI एप्लिकेशन के लिए:** MCP का नोटिफिकेशन सिस्टम लंबी अवधि के AI कार्यों के लिए विशेष रूप से उपयोगी है जहाँ आप उपयोगकर्ताओं को प्रगति की जानकारी देना चाहते हैं।

## MCP में स्ट्रीमिंग

ठीक है, अब तक आपने क्लासिकल स्ट्रीमिंग और MCP में स्ट्रीमिंग के बीच अंतर पर कुछ सिफारिशें और तुलना देखी हैं। आइए विस्तार से देखें कि आप MCP में स्ट्रीमिंग का लाभ कैसे उठा सकते हैं।

MCP फ्रेमवर्क के भीतर स्ट्रीमिंग कैसे काम करती है, इसे समझना आवश्यक है ताकि आप प्रतिक्रियाशील एप्लिकेशन बना सकें जो लंबी अवधि के ऑपरेशनों के दौरान उपयोगकर्ताओं को रीयल-टाइम फीडबैक प्रदान करें।

MCP में, स्ट्रीमिंग का मतलब मुख्य प्रतिक्रिया को टुकड़ों में भेजना नहीं है, बल्कि यह है कि जब कोई टूल अनुरोध को प्रोसेस कर रहा हो, तब क्लाइंट को **नोटिफिकेशन** भेजना। ये नोटिफिकेशन प्रगति अपडेट, लॉग, या अन्य घटनाएँ हो सकती हैं।

### यह कैसे काम करता है

मुख्य परिणाम अभी भी एकल प्रतिक्रिया के रूप में भेजा जाता है। हालांकि, प्रोसेसिंग के दौरान नोटिफिकेशन अलग संदेशों के रूप में भेजे जा सकते हैं और इस प्रकार क्लाइंट को रीयल-टाइम में अपडेट किया जाता है। क्लाइंट को इन नोटिफिकेशन को संभालने और प्रदर्शित करने में सक्षम होना चाहिए।

## नोटिफिकेशन क्या है?

हमने "नोटिफिकेशन" कहा, तो MCP के संदर्भ में इसका क्या मतलब है?

नोटिफिकेशन एक संदेश है जो सर्वर से क्लाइंट को भेजा जाता है ताकि लंबी अवधि के ऑपरेशन के दौरान प्रगति, स्थिति, या अन्य घटनाओं के बारे में सूचित किया जा सके। नोटिफिकेशन पारदर्शिता और उपयोगकर्ता अनुभव को बेहतर बनाते हैं।

उदाहरण के लिए, क्लाइंट को एक नोटिफिकेशन भेजना चाहिए जब सर्वर के साथ प्रारंभिक हैंडशेक पूरा हो जाता है।

नोटिफिकेशन इस प्रकार एक JSON संदेश जैसा दिखता है:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

नोटिफिकेशन MCP में एक टॉपिक से संबंधित होते हैं जिसे ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) कहा जाता है।

लॉगिंग को काम करने के लिए, सर्वर को इसे फीचर/क्षमता के रूप में सक्षम करना होगा, जैसे:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> उपयोग किए गए SDK के आधार पर, लॉगिंग डिफ़ॉल्ट रूप से सक्षम हो सकता है, या आपको इसे अपने सर्वर कॉन्फ़िगरेशन में स्पष्ट रूप से सक्षम करना पड़ सकता है।

नोटिफिकेशन के विभिन्न प्रकार होते हैं:

| स्तर       | विवरण                         | उदाहरण उपयोग मामला             |
|------------|------------------------------|-------------------------------|
| debug      | विस्तृत डिबगिंग जानकारी       | फ़ंक्शन एंट्री/एग्जिट पॉइंट्स |
| info       | सामान्य सूचना संदेश           | ऑपरेशन प्रगति अपडेट           |
| notice     | सामान्य लेकिन महत्वपूर्ण घटनाएँ | कॉन्फ़िगरेशन परिवर्तन          |
| warning    | चेतावनी स्थितियाँ             | डिप्रिकेटेड फीचर उपयोग        |
| error      | त्रुटि स्थितियाँ              | ऑपरेशन विफलताएँ               |
| critical   | गंभीर स्थितियाँ              | सिस्टम कंपोनेंट फेल्योर       |
| alert      | तुरंत कार्रवाई आवश्यक         | डेटा भ्रष्टाचार पता चला       |
| emergency  | सिस्टम अनुपयोगी है           | पूरी प्रणाली विफल             |

## MCP में नोटिफिकेशन लागू करना

MCP में नोटिफिकेशन लागू करने के लिए, आपको सर्वर और क्लाइंट दोनों पक्षों को रीयल-टाइम अपडेट्स को संभालने के लिए सेटअप करना होगा। इससे आपका एप्लिकेशन लंबी अवधि के ऑपरेशनों के दौरान उपयोगकर्ताओं को तुरंत प्रतिक्रिया दे सकेगा।

### सर्वर-साइड: नोटिफिकेशन भेजना

आइए सर्वर पक्ष से शुरू करें। MCP में, आप ऐसे टूल परिभाषित करते हैं जो अनुरोधों को प्रोसेस करते समय नोटिफिकेशन भेज सकते हैं। सर्वर संदर्भ ऑब्जेक्ट (आमतौर पर `ctx`) का उपयोग क्लाइंट को संदेश भेजने के लिए करता है।

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

उपरोक्त उदाहरण में, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ट्रांसपोर्ट:

```python
mcp.run(transport="streamable-http")
```

</details>

### क्लाइंट-साइड: नोटिफिकेशन प्राप्त करना

क्लाइंट को एक संदेश हैंडलर लागू करना होगा जो नोटिफिकेशन को प्राप्त करके प्रदर्शित करता है।

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

उपरोक्त कोड में, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) और आपका क्लाइंट नोटिफिकेशन को प्रोसेस करने के लिए एक संदेश हैंडलर लागू करता है।

## प्रगति नोटिफिकेशन और परिदृश्य

यह अनुभाग MCP में प्रगति नोटिफिकेशन की अवधारणा, उनकी महत्ता, और Streamable HTTP का उपयोग करके उन्हें कैसे लागू करें, समझाता है। साथ ही आपकी समझ को मजबूत करने के लिए एक व्यावहारिक असाइनमेंट भी है।

प्रगति नोटिफिकेशन लंबी अवधि के ऑपरेशनों के दौरान सर्वर से क्लाइंट को भेजे जाने वाले रीयल-टाइम संदेश होते हैं। पूरी प्रक्रिया के खत्म होने का इंतजार करने के बजाय, सर्वर क्लाइंट को वर्तमान स्थिति के बारे में अपडेट रखता है। इससे पारदर्शिता, उपयोगकर्ता अनुभव बेहतर होता है और डिबगिंग आसान हो जाती है।

**उदाहरण:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### प्रगति नोटिफिकेशन क्यों उपयोग करें?

प्रगति नोटिफिकेशन कई कारणों से आवश्यक हैं:

- **बेहतर उपयोगकर्ता अनुभव:** उपयोगकर्ता काम की प्रगति के दौरान अपडेट देखते हैं, केवल अंत में नहीं।
- **रीयल-टाइम फीडबैक:** क्लाइंट प्रगति बार या लॉग दिखा सकते हैं, जिससे ऐप प्रतिक्रियाशील लगता है।
- **डिबगिंग और मॉनिटरिंग आसान:** डेवलपर्स और उपयोगकर्ता देख सकते हैं कि प्रक्रिया कहाँ धीमी या अटकी हुई है।

### प्रगति नोटिफिकेशन कैसे लागू करें

MCP में प्रगति नोटिफिकेशन लागू करने का तरीका:

- **सर्वर पर:** `ctx.info()` or `ctx.log()` का उपयोग करके जैसे-जैसे प्रत्येक आइटम प्रोसेस होता है, नोटिफिकेशन भेजें। यह मुख्य परिणाम के तैयार होने से पहले क्लाइंट को संदेश भेजता है।
- **क्लाइंट पर:** एक संदेश हैंडलर लागू करें जो नोटिफिकेशन को सुनता है और जैसे ही वे आते हैं, प्रदर्शित करता है। यह हैंडलर नोटिफिकेशन और अंतिम परिणाम के बीच अंतर करता है।

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

HTTP-आधारित ट्रांसपोर्ट के साथ MCP सर्वर लागू करते समय, सुरक्षा एक अत्यंत महत्वपूर्ण चिंता बन जाती है, जिसके लिए कई हमले के वेक्टर और सुरक्षा तंत्रों पर सावधानीपूर्वक ध्यान देना आवश्यक है।

### अवलोकन

HTTP पर MCP सर्वर को एक्सपोज़ करते समय सुरक्षा अत्यंत महत्वपूर्ण है। Streamable HTTP नए हमले के संभावित रास्ते प्रस्तुत करता है और सावधानीपूर्वक कॉन्फ़िगरेशन की आवश्यकता होती है।

### मुख्य बिंदु
- **Origin Header वैलिडेशन**: हमेशा `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` को मान्य करें, न कि SSE क्लाइंट को।
3. **क्लाइंट में एक संदेश हैंडलर लागू करें** ताकि नोटिफिकेशन को प्रोसेस किया जा सके।
4. **मौजूदा टूल्स और वर्कफ़्लोज़ के साथ संगतता के लिए परीक्षण करें।**

### संगतता बनाए रखना

माइग्रेशन प्रक्रिया के दौरान मौजूदा SSE क्लाइंट के साथ संगतता बनाए रखना अनुशंसित है। यहाँ कुछ रणनीतियाँ हैं:

- आप दोनों SSE और Streamable HTTP को अलग-अलग एंडपॉइंट्स पर चलाकर समर्थन कर सकते हैं।
- धीरे-धीरे क्लाइंट्स को नए ट्रांसपोर्ट पर माइग्रेट करें।

### चुनौतियाँ

माइग्रेशन के दौरान निम्नलिखित चुनौतियों को सुनिश्चित करें कि आप संबोधित करें:

- सभी क्लाइंट्स का अपडेट होना
- नोटिफिकेशन डिलीवरी में अंतर को संभालना

### असाइनमेंट: अपना स्ट्रीमिंग MCP ऐप बनाएं

**परिदृश्य:**
एक MCP सर्वर और क्लाइंट बनाएं जहाँ सर्वर आइटमों (जैसे फाइल या दस्तावेज़) की सूची को प्रोसेस करता है और प्रत्येक प्रोसेस किए गए आइटम के लिए एक नोटिफिकेशन भेजता है। क्लाइंट को प्रत्येक नोटिफिकेशन को जैसे ही वह आता है, प्रदर्शित करना चाहिए।

**कदम:**

1. एक सर्वर टूल लागू करें जो एक सूची को प्रोसेस करता है और प्रत्येक आइटम के लिए नोटिफिकेशन भेजता है।
2. एक क्लाइंट लागू करें जिसमें एक संदेश हैंडलर हो जो रीयल-टाइम में नोटिफिकेशन दिखाए।
3. अपने कार्यान्वयन का परीक्षण करें, सर्वर और क्लाइंट दोनों चलाएं, और नोटिफिकेशन देखें।

[Solution](./solution/README.md)

## आगे पढ़ाई और आगे क्या?

MCP स्ट्रीमिंग के साथ अपनी यात्रा जारी रखने और अपने ज्ञान का विस्तार करने के लिए, यह अनुभाग अतिरिक्त संसाधन और अधिक उन्नत एप्लिकेशन बनाने के लिए सुझाए गए अगले कदम प्रदान करता है।

### आगे पढ़ाई

- [Microsoft: HTTP स्ट्रीमिंग परिचय](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core में CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: स्ट्रीमिंग रिक्वेस्ट](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### आगे क्या करें?

- अधिक उन्नत MCP टूल बनाएं जो रीयल-टाइम एनालिटिक्स, चैट, या सहयोगात्मक संपादन के लिए स्ट्रीमिंग का उपयोग करते हैं।
- MCP स्ट्रीमिंग को फ्रंटेंड फ्रेमवर्क (React, Vue, आदि) के साथ लाइव UI अपडेट के लिए एकीकृत करने का अन्वेषण करें।
- अगला: [VSCode के लिए AI टूलकिट का उपयोग](../07-aitk/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। हम सटीकता के लिए प्रयासरत हैं, लेकिन कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या असंगतियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।