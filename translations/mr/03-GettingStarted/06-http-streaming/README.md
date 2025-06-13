<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:37:57+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "mr"
}
-->
# HTTPS स्ट्रीमिंग विथ मॉडल कॉन्टेक्स्ट प्रोटोकॉल (MCP)

हा अध्याय Model Context Protocol (MCP) वापरून HTTPS द्वारे सुरक्षित, स्केलेबल आणि रिअल-टाइम स्ट्रीमिंग कशी अंमलात आणायची याचे सविस्तर मार्गदर्शन करतो. यात स्ट्रीमिंगची प्रेरणा, उपलब्ध ट्रान्सपोर्ट मेकॅनिझम, MCP मध्ये स्ट्रीमबल HTTP कसे अंमलात आणायचे, सुरक्षा सर्वोत्तम पद्धती, SSE कडून माइग्रेशन, आणि स्वतःचे स्ट्रीमिंग MCP अ‍ॅप्लिकेशन्स तयार करण्यासाठी व्यावहारिक मार्गदर्शन यांचा समावेश आहे.

## MCP मधील ट्रान्सपोर्ट मेकॅनिझम आणि स्ट्रीमिंग

हा विभाग MCP मध्ये उपलब्ध वेगवेगळ्या ट्रान्सपोर्ट मेकॅनिझमची आणि ते क्लायंट व सर्व्हरमधील रिअल-टाइम संवादासाठी स्ट्रीमिंग कसे सक्षम करतात याची चर्चा करतो.

### ट्रान्सपोर्ट मेकॅनिझम म्हणजे काय?

ट्रान्सपोर्ट मेकॅनिझम म्हणजे क्लायंट आणि सर्व्हर यांच्यात डेटा कसा देवाणघेवाण होतो हे ठरवणारी पद्धत. MCP वेगवेगळ्या वातावरण आणि गरजांसाठी अनेक ट्रान्सपोर्ट प्रकारांना समर्थन देते:

- **stdio**: स्टँडर्ड इनपुट/आउटपुट, स्थानिक आणि CLI-आधारित टूल्ससाठी योग्य. सोपे पण वेब किंवा क्लाउडसाठी योग्य नाही.
- **SSE (Server-Sent Events)**: सर्व्हर HTTP द्वारे क्लायंटला रिअल-टाइम अपडेट्स पाठवू शकतो. वेब UI साठी चांगले, पण स्केलेबिलिटी आणि लवचिकतेत मर्यादित.
- **Streamable HTTP**: आधुनिक HTTP-आधारित स्ट्रीमिंग ट्रान्सपोर्ट, नोटिफिकेशन्स आणि चांगली स्केलेबिलिटी समर्थित. बहुतेक प्रॉडक्शन आणि क्लाउड साठी शिफारस केली जाते.

### तुलना तक्ता

खालील तक्त्यात या ट्रान्सपोर्ट मेकॅनिझममधील फरक समजून घ्या:

| Transport         | रिअल-टाइम अपडेट्स | स्ट्रीमिंग | स्केलेबिलिटी | वापर प्रकरण                |
|-------------------|--------------------|-----------|--------------|----------------------------|
| stdio             | नाही               | नाही      | कमी          | स्थानिक CLI टूल्स          |
| SSE               | होय                | होय       | मध्यम        | वेब, रिअल-टाइम अपडेट्स   |
| Streamable HTTP   | होय                | होय       | उच्च         | क्लाउड, मल्टी-क्लायंट     |

> **टिप:** योग्य ट्रान्सपोर्ट निवडल्याने परफॉर्मन्स, स्केलेबिलिटी, आणि वापरकर्ता अनुभव सुधारतो. आधुनिक, स्केलेबल आणि क्लाउड-तयार अ‍ॅप्लिकेशन्ससाठी **Streamable HTTP** शिफारस केली जाते.

पूर्वीच्या अध्यायांमध्ये तुम्हाला stdio आणि SSE ट्रान्सपोर्ट दाखवले होते आणि या अध्यायात Streamable HTTP कसा वापरायचा ते समजावले आहे.

## स्ट्रीमिंग: संकल्पना आणि प्रेरणा

स्ट्रीमिंगच्या मूलभूत संकल्पना आणि प्रेरणा समजून घेणे प्रभावी रिअल-टाइम कम्युनिकेशन सिस्टम्स तयार करण्यासाठी आवश्यक आहे.

**स्ट्रीमिंग** म्हणजे नेटवर्क प्रोग्रामिंगमधील अशी तंत्रज्ञान जी पूर्ण प्रतिसाद तयार होण्याची वाट पाहण्याऐवजी डेटा लहान, हाताळण्यास सोप्या भागांमध्ये किंवा घटनांच्या मालिकेप्रमाणे पाठवते आणि प्राप्त करते. हे विशेषतः उपयुक्त आहे:

- मोठ्या फाइल्स किंवा डेटासेटसाठी.
- रिअल-टाइम अपडेट्ससाठी (उदा. चॅट, प्रोग्रेस बार).
- दीर्घकाळ चालणाऱ्या गणनांसाठी ज्यात वापरकर्त्याला अपडेट ठेवायचे असतात.

स्ट्रीमिंगबाबत तुम्हाला उच्चस्तरीय माहिती:

- डेटा हळूहळू दिला जातो, एकदम सगळा नाही.
- क्लायंट डेटा येताच प्रक्रिया करू शकतो.
- लॅटन्सी कमी होते आणि वापरकर्ता अनुभव सुधारतो.

### स्ट्रीमिंग का वापरायचे?

स्ट्रीमिंग वापरण्याची कारणे:

- वापरकर्त्यांना लगेच फीडबॅक मिळतो, फक्त शेवटी नाही.
- रिअल-टाइम अ‍ॅप्लिकेशन्स आणि प्रतिसादक्षम UI शक्य होतो.
- नेटवर्क आणि संगणकीय संसाधनांचा अधिक कार्यक्षम वापर.

### सोपा उदाहरण: HTTP स्ट्रीमिंग सर्व्हर आणि क्लायंट

स्ट्रीमिंग कसे अंमलात आणता येते याचे सोपे उदाहरण:

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

हा उदाहरण दाखवतो की सर्व्हर क्लायंटला सर्व संदेश तयार होण्याऐवजी उपलब्ध होताच पाठवतो.

**कसे काम करते:**
- सर्व्हर प्रत्येक संदेश तयार होताच तो पाठवतो.
- क्लायंट प्रत्येक चंक मिळताच तो प्रिंट करतो.

**आवश्यकता:**
- सर्व्हरला स्ट्रीमिंग प्रतिसाद वापरावा लागतो (उदा. `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) आणि MCP मध्ये स्ट्रीमिंग निवडावी लागते.

- **साध्या स्ट्रीमिंगसाठी:** क्लासिक HTTP स्ट्रीमिंग सोपी आणि मूलभूत गरजांसाठी पुरेशी आहे.

- **जटिल, संवादात्मक अ‍ॅप्ससाठी:** MCP स्ट्रीमिंग अधिक संरचित पद्धत देते ज्यात अधिक समृद्ध मेटाडेटा आणि नोटिफिकेशन्स व अंतिम परिणाम यांच्यात वेगळेपणा आहे.

- **AI अ‍ॅप्लिकेशन्ससाठी:** MCP ची नोटिफिकेशन प्रणाली दीर्घकाळ चालणाऱ्या AI टास्कसाठी उपयुक्त आहे ज्यात वापरकर्त्यांना प्रगतीची माहिती द्यायची असते.

## MCP मध्ये स्ट्रीमिंग

आता तुम्हाला क्लासिक स्ट्रीमिंग आणि MCP मधील स्ट्रीमिंगमधील फरक समजला असेल. आता पाहूया MCP मध्ये स्ट्रीमिंग कसे वापरायचे.

MCP फ्रेमवर्कमध्ये स्ट्रीमिंग कसे काम करते हे समजून घेणे महत्त्वाचे आहे जेणेकरून तुम्ही दीर्घकाळ चालणाऱ्या ऑपरेशन्स दरम्यान वापरकर्त्यांना रिअल-टाइम फीडबॅक देणारी प्रतिसादक्षम अ‍ॅप्लिकेशन्स तयार करू शकाल.

MCP मध्ये स्ट्रीमिंग म्हणजे मुख्य प्रतिसाद भागांमध्ये पाठविणे नव्हे, तर टूल विनंती प्रक्रिया करत असताना क्लायंटला **नोटिफिकेशन्स** पाठविणे होय. या नोटिफिकेशन्समध्ये प्रगती अपडेट्स, लॉग्स किंवा इतर इव्हेंट्स असू शकतात.

### कसे काम करते

मुख्य निकाल अजूनही एकाच प्रतिसादात पाठविला जातो. मात्र, प्रक्रिया दरम्यान नोटिफिकेशन्स स्वतंत्र संदेश म्हणून पाठविले जाऊ शकतात आणि त्यामुळे क्लायंट रिअल-टाइममध्ये अपडेट होतो. क्लायंटने या नोटिफिकेशन्स हाताळता आणि दाखवता यायला हवे.

## नोटिफिकेशन म्हणजे काय?

"नोटिफिकेशन" म्हटल्यावर MCP च्या संदर्भात त्याचा अर्थ काय?

नोटिफिकेशन म्हणजे सर्व्हरकडून क्लायंटकडे पाठवलेला संदेश जो दीर्घकाळ चालणाऱ्या ऑपरेशन दरम्यान प्रगती, स्थिती किंवा इतर इव्हेंट्सची माहिती देतो. नोटिफिकेशन्स पारदर्शकता आणि वापरकर्ता अनुभव सुधारतात.

उदाहरणार्थ, क्लायंटने सर्व्हरशी प्राथमिक हँडशेक झाल्यावर एक नोटिफिकेशन पाठवावे.

नोटिफिकेशन JSON संदेश म्हणून असे दिसते:

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

लॉगिंग चालू करण्यासाठी सर्व्हरला ते फीचर/क्षमता म्हणून सक्षम करावे लागते:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> वापरल्या जाणाऱ्या SDK नुसार, लॉगिंग डिफॉल्टने सक्षम असू शकते किंवा तुम्हाला ते सर्व्हर कॉन्फिगरेशनमध्ये स्पष्टपणे सक्षम करावे लागेल.

नोटिफिकेशन्सचे वेगवेगळे प्रकार आहेत:

| स्तर        | वर्णन                          | उदाहरण वापर प्रकरण            |
|-------------|--------------------------------|-------------------------------|
| debug       | तपशीलवार डीबगिंग माहिती        | फंक्शनच्या प्रवेश/निर्गमन बिंदू |
| info        | सामान्य माहितीपूर्ण संदेश       | ऑपरेशन प्रगती अपडेट्स          |
| notice      | सामान्य पण महत्त्वाचे इव्हेंट्स | कॉन्फिगरेशन बदल                |
| warning     | इशारा स्थिती                  | जुनी वैशिष्ट्ये वापरणे          |
| error       | त्रुटी स्थिती                  | ऑपरेशन अयशस्वी होणे            |
| critical    | गंभीर स्थिती                  | सिस्टीम घटक अपयश               |
| alert       | त्वरित कृती आवश्यक             | डेटा भ्रष्टाचार आढळणे          |
| emergency   | सिस्टीम वापरण्यायोग्य नाही    | पूर्ण सिस्टीम फेल्युअर          |

## MCP मध्ये नोटिफिकेशन्स अंमलात आणणे

MCP मध्ये नोटिफिकेशन्स अंमलात आणण्यासाठी, तुम्हाला सर्व्हर आणि क्लायंट दोन्ही बाजू सेट कराव्या लागतात जेणेकरून रिअल-टाइम अपडेट्स हाताळता येतील. यामुळे तुमचे अ‍ॅप्लिकेशन दीर्घकाळ चालणाऱ्या ऑपरेशन्स दरम्यान वापरकर्त्यांना तत्काळ फीडबॅक देऊ शकते.

### सर्व्हर-साईड: नोटिफिकेशन्स पाठविणे

सर्व्हर बाजूपासून सुरुवात करूया. MCP मध्ये तुम्ही असे टूल्स परिभाषित करता जे विनंती प्रक्रिया करताना नोटिफिकेशन्स पाठवू शकतात. सर्व्हर संदर्भ ऑब्जेक्ट (साधारणतः `ctx`) वापरून क्लायंटला संदेश पाठवतो.

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

वरील उदाहरणात, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` ट्रान्सपोर्ट वापरला आहे:

```python
mcp.run(transport="streamable-http")
```

</details>

### क्लायंट-साईड: नोटिफिकेशन्स प्राप्त करणे

क्लायंटला संदेश हँडलर अंमलात आणावा लागतो जो नोटिफिकेशन्स मिळताच त्यांना प्रक्रिया करून दाखवतो.

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

वरील कोडमध्ये, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` वापरून क्लायंट नोटिफिकेशन्स प्रक्रिया करतो.

## प्रगती नोटिफिकेशन्स आणि वापर प्रकरणे

हा विभाग MCP मधील प्रगती नोटिफिकेशन्सची संकल्पना, त्यांचे महत्त्व आणि Streamable HTTP वापरून त्यांना कसे अंमलात आणायचे हे समजावतो. तुम्हाला याबाबत एक व्यावहारिक कामही मिळेल.

प्रगती नोटिफिकेशन्स म्हणजे दीर्घकाळ चालणाऱ्या ऑपरेशन दरम्यान सर्व्हरकडून क्लायंटला पाठवले जाणारे रिअल-टाइम संदेश. संपूर्ण प्रक्रिया पूर्ण होण्याची वाट पाहण्याऐवजी सर्व्हर क्लायंटला सद्यस्थितीची माहिती देतो. यामुळे पारदर्शकता, वापरकर्ता अनुभव सुधारतो आणि डीबगिंग सुलभ होते.

**उदाहरण:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### प्रगती नोटिफिकेशन्स का वापराव्यात?

प्रगती नोटिफिकेशन्स महत्त्वाचे कारणे:

- **चांगला वापरकर्ता अनुभव:** काम प्रगतीत असल्याचे वापरकर्त्यांना लगेच दिसते, फक्त शेवटी नाही.
- **रिअल-टाइम फीडबॅक:** क्लायंट प्रगती बार किंवा लॉग दाखवू शकतो, ज्यामुळे अ‍ॅप प्रतिसादक्षम वाटतो.
- **डीबगिंग आणि मॉनिटरिंग सोपे:** विकसक आणि वापरकर्ते कुठे प्रक्रिया मंदावते किंवा अडचण येते ते पाहू शकतात.

### प्रगती नोटिफिकेशन्स कसे अंमलात आणायचे

प्रगती नोटिफिकेशन्स अंमलात आणण्याची पद्धत:

- **सर्व्हरवर:** प्रत्येक आयटम प्रक्रिया होताच `ctx.info()` or `ctx.log()` वापरून नोटिफिकेशन पाठवा. हे मुख्य निकाल तयार होण्याआधी क्लायंटला संदेश पाठवते.
- **क्लायंटवर:** नोटिफिकेशन्स ऐकणारा आणि दाखवणारा संदेश हँडलर अंमलात आणा. हा हँडलर नोटिफिकेशन्स आणि अंतिम निकाल यामध्ये फरक करतो.

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

HTTP-आधारित ट्रान्सपोर्टसह MCP सर्व्हर्स अंमलात आणताना, सुरक्षा अत्यंत महत्त्वाची असते आणि विविध हल्ल्यांपासून संरक्षणासाठी काळजीपूर्वक उपाययोजना करावी लागते.

### आढावा

HTTP वर MCP सर्व्हर्स उघडताना सुरक्षा अत्यंत महत्त्वाची आहे. Streamable HTTP नवीन हल्ल्यांसाठी संधी निर्माण करतो आणि काळजीपूर्वक कॉन्फिगरेशन आवश्यक आहे.

### मुख्य मुद्दे
- **Origin Header Validation**: `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` याची नेहमी पडताळणी करा, SSE क्लायंटऐवजी.
3. **क्लायंटमध्ये संदेश हँडलर अंमलात आणा** जे नोटिफिकेशन्स प्रक्रिया करेल.
4. **विद्यमान टूल्स आणि वर्कफ्लोजशी सुसंगतता तपासा**.

### सुसंगतता राखणे

मायग्रेशन प्रक्रियेदरम्यान विद्यमान SSE क्लायंटशी सुसंगतता राखणे शिफारसीय आहे. काही धोरणे:

- SSE आणि Streamable HTTP दोन्ही ट्रान्सपोर्ट वेगळ्या एंडपॉइंटवर चालवून समर्थन देऊ शकता.
- हळूहळू क्लायंटना नवीन ट्रान्सपोर्टकडे माइग्रेट करा.

### आव्हाने

मायग्रेशन दरम्यान खालील आव्हाने लक्षात घ्या:

- सर्व क्लायंट अपडेट आहेत याची खात्री करा.
- नोटिफिकेशन वितरणातील फरक हाताळा.

### काम: स्वतःचे स्ट्रीमिंग MCP अ‍ॅप तयार करा

**परिस्थिती:**
एक MCP सर्व्हर आणि क्लायंट तयार करा जिथे सर्व्हर आयटम्स (उदा. फाइल्स किंवा दस्तऐवज) ची यादी प्रक्रिया करतो आणि प्रत्येक आयटमसाठी नोटिफिकेशन पाठवतो. क्लायंट प्रत्येक नोटिफिकेशन मिळताच ते दाखवतो.

**पायऱ्या:**

1. अशी सर्व्हर टूल तयार करा जी यादी प्रक्रिया करते आणि प्रत्येक आयटमसाठी नोटिफिकेशन्स पाठवते.
2. संदेश हँडलर असलेला क्लायंट तयार करा जो नोटिफिकेशन्स रिअल-टाइममध्ये दाखवेल.
3. सर्व्हर आणि क्लायंट दोन्ही चालवून तुमची अंमलबजावणी तपासा आणि नोटिफिकेशन्स पहा.

[Solution](./solution/README.md)

## पुढील वाचन आणि पुढे काय?

MCP स्ट्रीमिंगसह तुमचा प्रवास सुरू ठेवण्यासाठी आणि अधिक प्रगत अ‍ॅप्लिकेशन्स तयार करण्यासाठी या विभागात अतिरिक्त संसाधने आणि पुढील पावले दिली आहेत.

### पुढील वाचन

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी भाषांतर शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीसाठी आम्ही जबाबदार नाही.