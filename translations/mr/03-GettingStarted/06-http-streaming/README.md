<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:03:27+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "mr"
}
-->
# HTTPS स्ट्रीमिंग विथ मॉडल कॉन्टेक्स्ट प्रोटोकॉल (MCP)

हा प्रकरण HTTPS वापरून Model Context Protocol (MCP) सह सुरक्षित, स्केलेबल आणि रिअल-टाइम स्ट्रीमिंग कसे राबवायचे याचे सखोल मार्गदर्शन प्रदान करते. यात स्ट्रीमिंगची प्रेरणा, उपलब्ध ट्रान्सपोर्ट मेकॅनिझम, MCP मध्ये स्ट्रीमेबल HTTP कसे राबवायचे, सुरक्षा सर्वोत्तम पद्धती, SSE कडून स्थलांतर, आणि स्वतःचे स्ट्रीमिंग MCP अॅप्लिकेशन्स तयार करण्यासाठी व्यावहारिक मार्गदर्शन यांचा समावेश आहे.

## MCP मधील ट्रान्सपोर्ट मेकॅनिझम आणि स्ट्रीमिंग

हा विभाग MCP मध्ये उपलब्ध वेगवेगळ्या ट्रान्सपोर्ट मेकॅनिझमचा आढावा घेतो आणि क्लायंट आणि सर्व्हरमधील रिअल-टाइम संवादासाठी स्ट्रीमिंग क्षमतांना कसे सक्षम करतात हे स्पष्ट करतो.

### ट्रान्सपोर्ट मेकॅनिझम म्हणजे काय?

ट्रान्सपोर्ट मेकॅनिझम म्हणजे क्लायंट आणि सर्व्हरमधील डेटा कसा देवाणघेवाण होतो हे ठरवणारा माध्यम. MCP विविध वातावरण आणि गरजांसाठी अनेक ट्रान्सपोर्ट प्रकारांना समर्थन देते:

- **stdio**: स्टँडर्ड इनपुट/आउटपुट, स्थानिक आणि CLI-आधारित टूल्ससाठी योग्य. सोपे पण वेब किंवा क्लाउडसाठी योग्य नाही.
- **SSE (Server-Sent Events)**: सर्व्हर HTTP वरून क्लायंटकडे रिअल-टाइम अपडेट्स पुश करू शकतो. वेब UI साठी चांगले, पण स्केलेबिलिटी आणि लवचीकतेमध्ये मर्यादित.
- **Streamable HTTP**: आधुनिक HTTP-आधारित स्ट्रीमिंग ट्रान्सपोर्ट, सूचना पाठवण्यास आणि चांगल्या स्केलेबिलिटीला समर्थन देतो. बहुतेक उत्पादन आणि क्लाउड परिस्थितीसाठी शिफारस केलेले.

### तुलना सारणी

खालील तुलना सारणीमध्ये या ट्रान्सपोर्ट मेकॅनिझममधील फरक समजून घ्या:

| ट्रान्सपोर्ट       | रिअल-टाइम अपडेट्स | स्ट्रीमिंग | स्केलेबिलिटी | वापर केस                 |
|-------------------|--------------------|-----------|--------------|--------------------------|
| stdio             | नाही               | नाही      | कमी          | स्थानिक CLI टूल्स        |
| SSE               | होय                | होय       | मध्यम        | वेब, रिअल-टाइम अपडेट्स |
| Streamable HTTP   | होय                | होय       | जास्त        | क्लाउड, मल्टी-क्लायंट    |

> **Tip:** योग्य ट्रान्सपोर्ट निवडल्याने कार्यक्षमता, स्केलेबिलिटी आणि वापरकर्ता अनुभव प्रभावित होतो. **Streamable HTTP** आधुनिक, स्केलेबल आणि क्लाउड-तयार अॅप्लिकेशन्ससाठी शिफारस केलेले आहे.

पूर्वीच्या प्रकरणांमध्ये तुम्हाला stdio आणि SSE ट्रान्सपोर्ट दाखवले गेले होते आणि या प्रकरणात स्ट्रीमेबल HTTP ट्रान्सपोर्ट कसा वापरायचा ते समजावले आहे.

## स्ट्रीमिंग: संकल्पना आणि प्रेरणा

स्ट्रीमिंगच्या मूलभूत संकल्पना आणि प्रेरणा समजून घेणे प्रभावी रिअल-टाइम संवाद प्रणाली राबवण्यासाठी अत्यावश्यक आहे.

**स्ट्रीमिंग** हा नेटवर्क प्रोग्रामिंगमधील एक तंत्र आहे ज्याद्वारे डेटा संपूर्ण प्रतिसाद तयार होण्याची वाट न पाहता लहान, हाताळण्यायोग्य तुकड्यांमध्ये किंवा घटनांच्या मालिकेप्रमाणे पाठवला आणि प्राप्त केला जातो. हे विशेषतः उपयुक्त आहे:

- मोठ्या फाइल्स किंवा डेटासेटसाठी.
- रिअल-टाइम अपडेट्ससाठी (उदा., चॅट, प्रगती पट्ट्या).
- दीर्घकाळ चालणाऱ्या संगणनांसाठी जिथे वापरकर्त्याला माहिती द्यायची असते.

स्ट्रीमिंगबद्दल उच्चस्तरीय माहिती:

- डेटा हळूहळू पाठवला जातो, एकाच वेळी सर्व डेटा नाही.
- क्लायंट येताच डेटा प्रक्रिया करू शकतो.
- अनुभवातील विलंब कमी होतो आणि वापरकर्ता अनुभव सुधारतो.

### स्ट्रीमिंग का वापरावे?

स्ट्रीमिंग वापरण्याची कारणे पुढीलप्रमाणे:

- वापरकर्त्यांना लगेच प्रतिसाद मिळतो, फक्त शेवटी नाही.
- रिअल-टाइम अॅप्लिकेशन्स आणि प्रतिसाद देणाऱ्या UI साठी सक्षम.
- नेटवर्क आणि संगणन संसाधनांचा अधिक कार्यक्षम वापर.

### सोपा उदाहरण: HTTP स्ट्रीमिंग सर्व्हर आणि क्लायंट

स्ट्रीमिंग कसे राबवता येते याचे सोपे उदाहरण:

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

हे उदाहरण दाखवते की सर्व्हर तयार होताच संदेशांची मालिका क्लायंटकडे पाठवतो, सर्व संदेश तयार होण्याची वाट पाहत नाही.

**कसे काम करते:**
- सर्व्हर प्रत्येक संदेश तयार होताच तो पाठवतो.
- क्लायंट येताच प्रत्येक तुकडा प्राप्त करून प्रिंट करतो.

**गरजा:**
- सर्व्हरला स्ट्रीमिंग प्रतिसाद वापरावा लागतो (उदा., `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) आणि MCP द्वारे स्ट्रीमिंग निवडणे आवश्यक आहे.

- **साध्या स्ट्रीमिंगसाठी:** क्लासिक HTTP स्ट्रीमिंग सोपे आणि मूलभूत गरजांसाठी पुरेसे आहे.

- **कठीण, संवादात्मक अॅप्लिकेशन्ससाठी:** MCP स्ट्रीमिंग अधिक संरचित पद्धत देते ज्यात समृद्ध मेटाडेटा आणि सूचना व अंतिम निकाल यामध्ये वेगळेपणा असतो.

- **AI अॅप्लिकेशन्ससाठी:** MCP ची सूचना प्रणाली दीर्घकाळ चालणाऱ्या AI कार्यांसाठी उपयुक्त आहे जिथे वापरकर्त्यांना प्रगतीची माहिती द्यायची असते.

## MCP मधील स्ट्रीमिंग

ठीक आहे, तुम्हाला क्लासिकल स्ट्रीमिंग आणि MCP मधील स्ट्रीमिंग यातील फरक आणि शिफारसी पाहिल्या आहेत. आता आपण तपशीलवार पाहू की MCP मध्ये स्ट्रीमिंग कसे वापरायचे.

MCP फ्रेमवर्कमध्ये स्ट्रीमिंग कसे कार्य करते हे समजणे आवश्यक आहे जेणेकरून दीर्घकाळ चालणाऱ्या ऑपरेशन्स दरम्यान वापरकर्त्यांना रिअल-टाइम फीडबॅक देणारी प्रतिसादक्षम अॅप्लिकेशन्स तयार करता येतील.

MCP मध्ये, स्ट्रीमिंग म्हणजे मुख्य प्रतिसाद तुकड्यांमध्ये पाठवणे नव्हे, तर टूल विनंती प्रक्रिया करत असताना क्लायंटला **सूचना** पाठवणे होय. या सूचनांमध्ये प्रगती अपडेट्स, लॉग्स किंवा इतर घटना असू शकतात.

### कसे कार्य करते

मुख्य निकाल अजूनही एकाच प्रतिसादात पाठवला जातो. मात्र, सूचना स्वतंत्र संदेशांमध्ये पाठवून प्रक्रियेदरम्यान क्लायंटला रिअल-टाइम अपडेट दिला जातो. क्लायंटला या सूचनांचा स्वीकार करून प्रदर्शित करण्यास सक्षम असावे लागते.

## सूचना म्हणजे काय?

आपण "सूचना" असा शब्द वापरला, तर MCP च्या संदर्भात याचा अर्थ काय?

सूचना म्हणजे सर्व्हरकडून क्लायंटकडे पाठवलेला असा संदेश जो दीर्घकाळ चालणाऱ्या ऑपरेशन दरम्यान प्रगती, स्थिती किंवा इतर घटना यांची माहिती देतो. सूचना पारदर्शकता आणि वापरकर्ता अनुभव सुधारतात.

उदाहरणार्थ, क्लायंटने सर्व्हरशी प्रारंभिक हँडशेक पूर्ण झाल्यानंतर सूचना पाठवणे अपेक्षित आहे.

सूचना JSON संदेश म्हणून अशी दिसते:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

सूचना MCP मधील ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) या विषयाशी संबंधित असतात.

लॉगिंग कार्यान्वित करण्यासाठी, सर्व्हरला ते फीचर/क्षमता म्हणून सक्षम करावे लागते:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> वापरल्या जाणाऱ्या SDK नुसार, लॉगिंग डिफॉल्टने सक्षम असू शकते, किंवा तुम्हाला ते सर्व्हर कॉन्फिगरेशनमध्ये स्पष्टपणे सक्षम करावे लागू शकते.

सूचनांचे विविध प्रकार आहेत:

| स्तर       | वर्णन                           | उदाहरण वापर केस                 |
|------------|---------------------------------|---------------------------------|
| debug      | सविस्तर डिबगिंग माहिती          | फंक्शन प्रवेश/बाहेर पडण्याचे बिंदू |
| info       | सामान्य माहिती संदेश             | ऑपरेशन प्रगती अपडेट्स          |
| notice     | सामान्य पण महत्त्वाच्या घटना     | कॉन्फिगरेशन बदल                |
| warning    | इशारा स्थिती                    | जुनी वैशिष्ट्ये वापरणे          |
| error      | त्रुटी स्थिती                    | ऑपरेशन अपयश                   |
| critical   | गंभीर स्थिती                    | सिस्टम घटक अपयश               |
| alert      | तातडीने कृती करणे आवश्यक       | डेटा भ्रष्टता आढळली           |
| emergency  | सिस्टम वापरण्यायोग्य नाही       | पूर्ण सिस्टम अपयश             |

## MCP मध्ये सूचना राबविणे

MCP मध्ये सूचना राबविण्यासाठी, तुम्हाला सर्व्हर आणि क्लायंट दोन्ही बाजू रिअल-टाइम अपडेट्स हाताळण्यासाठी तयार करावे लागतात. यामुळे तुमच्या अॅप्लिकेशनला दीर्घकाळ चालणाऱ्या ऑपरेशन्स दरम्यान वापरकर्त्यांना त्वरित प्रतिसाद देणे शक्य होते.

### सर्व्हर बाजू: सूचना पाठवणे

सर्व्हर बाजूने सुरुवात करूया. MCP मध्ये, तुम्ही असे टूल्स परिभाषित करता जे विनंती प्रक्रिया करताना सूचना पाठवू शकतात. सर्व्हर संदर्भ ऑब्जेक्ट (`ctx` सहसा) वापरून क्लायंटकडे संदेश पाठवतो.

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

### क्लायंट बाजू: सूचना प्राप्त करणे

क्लायंटला संदेश हँडलर राबवावा लागतो जो येणाऱ्या सूचनांना प्रक्रिया करून प्रदर्शित करतो.

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

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) वापरला असून तुमचा क्लायंट सूचनांसाठी संदेश हँडलर राबवतो.

## प्रगती सूचना आणि परिस्थिती

हा विभाग MCP मधील प्रगती सूचनांचा संकल्पना, महत्त्व आणि Streamable HTTP वापरून त्याची अंमलबजावणी कशी करावी हे स्पष्ट करतो. तसेच समज दृढ करण्यासाठी एक व्यावहारिक कार्य दिले आहे.

प्रगती सूचना म्हणजे दीर्घकाळ चालणाऱ्या ऑपरेशन्स दरम्यान सर्व्हरकडून क्लायंटकडे पाठवले जाणारे रिअल-टाइम संदेश. संपूर्ण प्रक्रिया पूर्ण होण्याची वाट न पाहता, सर्व्हर क्लायंटला चालू स्थितीबद्दल अपडेट ठेवतो. हे पारदर्शकता, वापरकर्ता अनुभव सुधारते आणि डिबगिंग सुलभ करते.

**उदाहरण:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### प्रगती सूचना का वापराव्यात?

प्रगती सूचनांचे महत्त्व पुढील कारणांमुळे आहे:

- **चांगला वापरकर्ता अनुभव:** वापरकर्त्यांना काम सुरू असतानाच अपडेट्स दिसतात, फक्त शेवटी नाही.
- **रिअल-टाइम फीडबॅक:** क्लायंट प्रगती पट्ट्या किंवा लॉग्स दाखवू शकतो, अॅप अधिक प्रतिसादक्षम वाटते.
- **डिबगिंग आणि मॉनिटरिंग सुलभ:** विकसक आणि वापरकर्ते प्रक्रिया कुठे मंदावते किंवा अडचण येते हे पाहू शकतात.

### प्रगती सूचना कशा राबवायच्या

MCP मध्ये प्रगती सूचना राबवण्यासाठी:

- **सर्व्हरवर:** `ctx.info()` or `ctx.log()` वापरून प्रत्येक आयटम प्रक्रिया होताना सूचना पाठवा. हे मुख्य निकाल तयार होण्यापूर्वी क्लायंटला संदेश पाठवते.
- **क्लायंटवर:** संदेश हँडलर राबवा जो येणाऱ्या सूचनांना ऐकून प्रदर्शित करतो. हा हँडलर सूचना आणि अंतिम निकाल यात फरक करतो.

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

## सुरक्षा बाबी

HTTP-आधारित ट्रान्सपोर्टसह MCP सर्व्हर राबवताना सुरक्षा ही अत्यंत महत्त्वाची बाब असते ज्यासाठी विविध हल्ल्यांपासून संरक्षणासाठी काळजीपूर्वक विचार करणे आवश्यक आहे.

### आढावा

HTTP वर MCP सर्व्हर उघडताना सुरक्षा अत्यंत महत्त्वाची आहे. Streamable HTTP नवीन हल्ल्यांच्या शक्यता निर्माण करते आणि काळजीपूर्वक कॉन्फिगरेशन आवश्यक आहे.

### मुख्य मुद्दे
- **Origin Header पडताळणी**: नेहमी `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` चे पडताळणी करा, SSE क्लायंटऐवजी.
3. **क्लायंटमध्ये संदेश हँडलर राबवा** ज्यामुळे सूचना प्रक्रिया करता येतील.
4. **विद्यमान टूल्स आणि वर्कफ्लोजसह सुसंगतता तपासा.**

### सुसंगतता राखणे

स्थानांतरण प्रक्रियेदरम्यान विद्यमान SSE क्लायंटसह सुसंगतता राखणे शिफारसीय आहे. काही धोरणे:

- तुम्ही SSE आणि Streamable HTTP दोन्ही ट्रान्सपोर्ट वेगळ्या एंडपॉइंटवर चालवून समर्थन करू शकता.
- हळूहळू क्लायंटना नवीन ट्रान्सपोर्टकडे स्थलांतर करा.

### आव्हाने

स्थानांतरण दरम्यान खालील आव्हाने हाताळणे आवश्यक:

- सर्व क्लायंट अद्ययावत आहेत याची खात्री करणे
- सूचनांच्या वितरणातील फरक हाताळणे

### कार्य: स्वतःचे स्ट्रीमिंग MCP अॅप तयार करा

**परिस्थिती:**
एक MCP सर्व्हर आणि क्लायंट तयार करा जिथे सर्व्हर आयटम्स (उदा., फाइल्स किंवा दस्तऐवज) यादी प्रक्रिया करतो आणि प्रत्येक आयटम प्रक्रियेसाठी सूचना पाठवतो. क्लायंट प्रत्येक सूचना येताच प्रदर्शित करतो.

**पायऱ्या:**

1. आयटम्सची यादी प्रक्रिया करणारे आणि प्रत्येकासाठी सूचना पाठवणारे सर्व्हर टूल राबवा.
2. रिअल-टाइम सूचनांसाठी संदेश हँडलर असलेला क्लायंट राबवा.
3. सर्व्हर आणि क्लायंट दोन्ही चालवून तुमची अंमलबजावणी तपासा आणि सूचनांचे निरीक्षण करा.

[Solution](./solution/README.md)

## पुढील वाचन आणि पुढे काय?

MCP स्ट्रीमिंगसह तुमचा प्रवास सुरू ठेवण्यासाठी आणि अधिक प्रगत अॅप्लिकेशन्स तयार करण्यासाठी अतिरिक्त संसाधने आणि पुढील टप्प्यांचे मार्गदर्शन येथे दिले आहे.

### पुढील वाचन

- [Microsoft: HTTP स्ट्रीमिंग परिचय](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: ASP.NET Core मध्ये CORS](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### पुढे काय?

- रिअल-टाइम अॅनालिटिक्स, चॅट किंवा सहकार्य संपादनासाठी स्ट्रीमिंग वापरणारे अधिक प्रगत MCP टूल्स तयार करण्याचा प्रयत्न करा.
- फ्रंटेंड फ्रेमवर्क्स

**सूचना:**  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला पाहिजे. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याचा सल्ला दिला जातो. या अनुवादाचा वापर करून झालेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थनिर्देशांसाठी आम्ही जबाबदार नाही.