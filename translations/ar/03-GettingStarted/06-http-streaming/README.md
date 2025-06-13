<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:34:33+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ar"
}
-->
# HTTPS البث مع بروتوكول سياق النموذج (MCP)

يوفر هذا الفصل دليلاً شاملاً لتنفيذ بث آمن وقابل للتوسع وفي الوقت الحقيقي باستخدام بروتوكول سياق النموذج (MCP) عبر HTTPS. يغطي الدوافع للبث، وآليات النقل المتاحة، كيفية تنفيذ HTTP قابل للبث في MCP، أفضل ممارسات الأمان، الترحيل من SSE، وإرشادات عملية لبناء تطبيقات MCP الخاصة بك للبث.

## آليات النقل والبث في MCP

يستعرض هذا القسم آليات النقل المختلفة المتاحة في MCP ودورها في تمكين قدرات البث للتواصل في الوقت الحقيقي بين العملاء والخوادم.

### ما هي آلية النقل؟

تعرف آلية النقل كيفية تبادل البيانات بين العميل والخادم. يدعم MCP عدة أنواع من النقل لتناسب بيئات ومتطلبات مختلفة:

- **stdio**: الإدخال/الإخراج القياسي، مناسب للأدوات المحلية وقائمة الأوامر. بسيط لكنه غير مناسب للويب أو السحابة.
- **SSE (Server-Sent Events)**: يسمح للخوادم بدفع تحديثات في الوقت الحقيقي للعملاء عبر HTTP. جيد لواجهات الويب، لكنه محدود في التوسع والمرونة.
- **Streamable HTTP**: نقل بث حديث قائم على HTTP، يدعم الإشعارات وقابلية التوسع بشكل أفضل. يُنصح به لمعظم سيناريوهات الإنتاج والسحابة.

### جدول المقارنة

اطلع على جدول المقارنة أدناه لفهم الفروقات بين آليات النقل هذه:

| النقل             | التحديثات في الوقت الحقيقي | البث       | قابلية التوسع | حالة الاستخدام          |
|-------------------|----------------------------|------------|---------------|-------------------------|
| stdio             | لا                         | لا         | منخفض         | أدوات CLI محلية         |
| SSE               | نعم                        | نعم        | متوسط         | الويب، التحديثات الفورية |
| Streamable HTTP   | نعم                        | نعم        | عالي          | السحابة، تعدد العملاء    |

> **نصيحة:** اختيار آلية النقل المناسبة يؤثر على الأداء، وقابلية التوسع، وتجربة المستخدم. **Streamable HTTP** يُوصى به للتطبيقات الحديثة والقابلة للتوسع والمهيأة للسحابة.

لاحظ آليات النقل stdio و SSE التي تم عرضها في الفصول السابقة وكيف أن HTTP القابل للبث هو آلية النقل التي يغطيها هذا الفصل.

## البث: المفاهيم والدوافع

فهم المفاهيم الأساسية والدوافع وراء البث ضروري لتنفيذ أنظمة اتصال فعالة في الوقت الحقيقي.

**البث** هو تقنية في برمجة الشبكات تسمح بإرسال واستقبال البيانات على شكل أجزاء صغيرة يمكن التحكم بها أو كسلسلة من الأحداث، بدلاً من الانتظار حتى يكون الرد كاملاً جاهزًا. هذا مفيد بشكل خاص لـ:

- الملفات أو مجموعات البيانات الكبيرة.
- التحديثات في الوقت الحقيقي (مثل الدردشة، أشرطة التقدم).
- العمليات الحسابية طويلة الأمد حيث تريد إبقاء المستخدم على اطلاع.

إليك ما تحتاج معرفته عن البث بشكل عام:

- يتم تسليم البيانات تدريجياً، وليس دفعة واحدة.
- يمكن للعميل معالجة البيانات فور وصولها.
- يقلل من زمن الاستجابة المُدرك ويحسن تجربة المستخدم.

### لماذا نستخدم البث؟

الأسباب لاستخدام البث هي كالتالي:

- يحصل المستخدمون على ردود فعل فوراً، وليس فقط في النهاية
- يتيح تطبيقات في الوقت الحقيقي وواجهات مستخدم تفاعلية
- استخدام أكثر كفاءة لموارد الشبكة والحوسبة

### مثال بسيط: خادم وعميل HTTP للبث

إليك مثال بسيط لكيفية تنفيذ البث:

<details>
<summary>Python</summary>

**الخادم (Python، باستخدام FastAPI و StreamingResponse):**
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

**العميل (Python، باستخدام requests):**
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

يوضح هذا المثال خادمًا يرسل سلسلة من الرسائل إلى العميل عند توفرها، بدلاً من الانتظار حتى تصبح كل الرسائل جاهزة.

**كيف يعمل:**
- الخادم يولد كل رسالة بمجرد جاهزيتها.
- العميل يستلم ويطبع كل جزء فور وصوله.

**المتطلبات:**
- يجب أن يستخدم الخادم استجابة بث (مثل `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) بدلاً من اختيار البث عبر MCP.

- **للحاجات البسيطة للبث:** البث الكلاسيكي عبر HTTP أسهل في التنفيذ وكافٍ للاحتياجات الأساسية.

- **للتطبيقات التفاعلية والمعقدة:** يوفر بث MCP نهجًا أكثر تنظيمًا مع بيانات وصفية أغنى وفصل بين الإشعارات والنتائج النهائية.

- **لتطبيقات الذكاء الاصطناعي:** نظام الإشعارات في MCP مفيد بشكل خاص للمهام الطويلة التي تريد إبقاء المستخدمين على اطلاع بتقدمها.

## البث في MCP

حسنًا، لقد رأيت بعض التوصيات والمقارنات حتى الآن حول الفرق بين البث الكلاسيكي والبث في MCP. دعنا ندخل في التفاصيل حول كيفية الاستفادة من البث في MCP.

فهم كيفية عمل البث داخل إطار عمل MCP ضروري لبناء تطبيقات تفاعلية توفر ردود فعل في الوقت الحقيقي للمستخدمين أثناء العمليات طويلة الأمد.

في MCP، البث لا يعني إرسال الرد الرئيسي على شكل أجزاء، بل إرسال **إشعارات** إلى العميل أثناء معالجة الأداة للطلب. يمكن أن تتضمن هذه الإشعارات تحديثات التقدم، السجلات، أو أحداث أخرى.

### كيف يعمل

النتيجة الرئيسية لا تزال تُرسل كرد واحد. ومع ذلك، يمكن إرسال الإشعارات كرسائل منفصلة أثناء المعالجة وبالتالي تحديث العميل في الوقت الحقيقي. يجب أن يكون العميل قادرًا على التعامل مع هذه الإشعارات وعرضها.

## ما هي الإشعارات؟

قلنا "الإشعار"، ماذا يعني ذلك في سياق MCP؟

الإشعار هو رسالة تُرسل من الخادم إلى العميل لإبلاغه بالتقدم، الحالة، أو أحداث أخرى أثناء عملية طويلة الأمد. الإشعارات تحسن الشفافية وتجربة المستخدم.

على سبيل المثال، من المفترض أن يرسل العميل إشعارًا بمجرد إتمام المصافحة الأولية مع الخادم.

يبدو الإشعار كرسالة JSON كما يلي:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

تنتمي الإشعارات إلى موضوع في MCP يُشار إليه باسم ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

لتفعيل السجلات، يحتاج الخادم إلى تمكينها كميزة/قدرة كما يلي:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> اعتمادًا على SDK المستخدم، قد يتم تمكين السجلات بشكل افتراضي، أو قد تحتاج إلى تمكينها صراحة في تكوين الخادم الخاص بك.

هناك أنواع مختلفة من الإشعارات:

| المستوى    | الوصف                         | مثال على حالة الاستخدام           |
|------------|-------------------------------|----------------------------------|
| debug      | معلومات تفصيلية للتصحيح       | نقاط دخول/خروج الدوال            |
| info       | رسائل معلومات عامة            | تحديثات تقدم العمليات            |
| notice     | أحداث عادية لكنها مهمة         | تغييرات التكوين                  |
| warning    | حالات تحذيرية                 | استخدام ميزات مهجورة             |
| error      | حالات أخطاء                  | فشل العمليات                    |
| critical   | حالات حرجة                   | فشل مكونات النظام                |
| alert      | يجب اتخاذ إجراء فوراً          | اكتشاف تلف في البيانات           |
| emergency  | النظام غير قابل للاستخدام     | فشل النظام الكامل                |

## تنفيذ الإشعارات في MCP

لتنفيذ الإشعارات في MCP، تحتاج إلى إعداد كلا من جانب الخادم والعميل للتعامل مع التحديثات في الوقت الحقيقي. هذا يسمح لتطبيقك بتقديم ردود فعل فورية للمستخدمين أثناء العمليات طويلة الأمد.

### جانب الخادم: إرسال الإشعارات

لنبدأ بجانب الخادم. في MCP، تقوم بتعريف أدوات يمكنها إرسال الإشعارات أثناء معالجة الطلبات. يستخدم الخادم كائن السياق (عادة `ctx`) لإرسال الرسائل إلى العميل.

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

في المثال السابق، النقل `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

</details>

### جانب العميل: استقبال الإشعارات

يجب على العميل تنفيذ معالج رسائل لمعالجة وعرض الإشعارات فور وصولها.

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

في الكود السابق، `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) ويقوم عميلك بتنفيذ معالج رسائل لمعالجة الإشعارات.

## إشعارات التقدم والسيناريوهات

يشرح هذا القسم مفهوم إشعارات التقدم في MCP، لماذا هي مهمة، وكيفية تنفيذها باستخدام Streamable HTTP. ستجد أيضًا تمرينًا عمليًا لتعزيز فهمك.

إشعارات التقدم هي رسائل في الوقت الحقيقي تُرسل من الخادم إلى العميل أثناء العمليات طويلة الأمد. بدلاً من الانتظار حتى تنتهي العملية بالكامل، يبقي الخادم العميل على اطلاع بالحالة الحالية. هذا يحسن الشفافية، تجربة المستخدم، ويسهل التصحيح.

**مثال:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### لماذا نستخدم إشعارات التقدم؟

إشعارات التقدم ضرورية لعدة أسباب:

- **تحسين تجربة المستخدم:** يرى المستخدمون التحديثات أثناء تقدم العمل، وليس فقط في النهاية.
- **ردود فعل في الوقت الحقيقي:** يمكن للعملاء عرض أشرطة التقدم أو السجلات، مما يجعل التطبيق يبدو تفاعليًا.
- **تسهيل التصحيح والمراقبة:** يمكن للمطورين والمستخدمين رؤية أين قد تكون العملية بطيئة أو متوقفة.

### كيفية تنفيذ إشعارات التقدم

إليك كيفية تنفيذ إشعارات التقدم في MCP:

- **على الخادم:** استخدم `ctx.info()` or `ctx.log()` لإرسال الإشعارات مع معالجة كل عنصر. هذا يرسل رسالة إلى العميل قبل أن تكون النتيجة الرئيسية جاهزة.
- **على العميل:** نفذ معالج رسائل يستمع ويعرض الإشعارات فور وصولها. يميز هذا المعالج بين الإشعارات والنتيجة النهائية.

**مثال الخادم:**

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

**مثال العميل:**

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

## اعتبارات الأمان

عند تنفيذ خوادم MCP باستخدام نقل قائم على HTTP، يصبح الأمان أمرًا بالغ الأهمية يتطلب اهتمامًا دقيقًا بعدة نواحي للهجوم وآليات الحماية.

### نظرة عامة

الأمان أمر حاسم عند تعريض خوادم MCP عبر HTTP. يقدم Streamable HTTP أسطح هجوم جديدة ويتطلب تكوينًا دقيقًا.

### النقاط الرئيسية
- **التحقق من رأس Origin**: تحقق دائمًا من `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` بدلاً من عميل SSE.
3. **تنفيذ معالج رسائل** في العميل لمعالجة الإشعارات.
4. **اختبار التوافق** مع الأدوات وسير العمل الحالية.

### الحفاظ على التوافق

يوصى بالحفاظ على التوافق مع عملاء SSE الحاليين أثناء عملية الترحيل. إليك بعض الاستراتيجيات:

- يمكنك دعم كل من SSE و Streamable HTTP بتشغيل كلا النقلين على نقاط نهاية مختلفة.
- ترحيل العملاء تدريجيًا إلى النقل الجديد.

### التحديات

تأكد من معالجة التحديات التالية أثناء الترحيل:

- ضمان تحديث جميع العملاء
- التعامل مع الاختلافات في تسليم الإشعارات

### التمرين: بناء تطبيق MCP للبث خاص بك

**السيناريو:**
قم ببناء خادم وعميل MCP حيث يعالج الخادم قائمة من العناصر (مثل الملفات أو المستندات) ويرسل إشعارًا لكل عنصر تتم معالجته. يجب أن يعرض العميل كل إشعار فور وصوله.

**الخطوات:**

1. نفذ أداة خادم تعالج قائمة وترسل إشعارات لكل عنصر.
2. نفذ عميلًا مع معالج رسائل لعرض الإشعارات في الوقت الحقيقي.
3. اختبر تنفيذك بتشغيل الخادم والعميل معًا، ومراقبة الإشعارات.

[الحل](./solution/README.md)

## المزيد من القراءة وما التالي؟

لمواصلة رحلتك مع بث MCP وتوسيع معرفتك، يوفر هذا القسم موارد إضافية وخطوات مقترحة لبناء تطبيقات أكثر تقدمًا.

### المزيد من القراءة

- [Microsoft: مقدمة في HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS في ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: طلبات البث](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### ما التالي؟

- جرب بناء أدوات MCP أكثر تقدمًا تستخدم البث لتحليلات في الوقت الحقيقي، الدردشة، أو التحرير التعاوني.
- استكشف دمج بث MCP مع أُطُر الواجهة الأمامية (React, Vue, إلخ) لتحديثات واجهة المستخدم الحية.
- التالي: [استخدام مجموعة أدوات الذكاء الاصطناعي لـ VSCode](../07-aitk/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.