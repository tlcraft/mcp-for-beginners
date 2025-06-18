<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T21:53:56+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "ar"
}
-->
# البث عبر HTTPS باستخدام بروتوكول سياق النموذج (MCP)

يوفر هذا الفصل دليلاً شاملاً لتنفيذ بث آمن وقابل للتوسع وفي الوقت الحقيقي باستخدام بروتوكول سياق النموذج (MCP) عبر HTTPS. يغطي الدوافع وراء البث، وآليات النقل المتاحة، وكيفية تنفيذ HTTP قابل للبث في MCP، أفضل ممارسات الأمان، الانتقال من SSE، والإرشادات العملية لبناء تطبيقات MCP للبث الخاصة بك.

## آليات النقل والبث في MCP

تستعرض هذه القسم آليات النقل المختلفة المتاحة في MCP ودورها في تمكين قدرات البث للتواصل في الوقت الحقيقي بين العملاء والخوادم.

### ما هي آلية النقل؟

تعرف آلية النقل الطريقة التي يتم بها تبادل البيانات بين العميل والخادم. يدعم MCP أنواع نقل متعددة لتناسب بيئات ومتطلبات مختلفة:

- **stdio**: الإدخال/الإخراج القياسي، مناسب للأدوات المحلية والمعتمدة على سطر الأوامر. بسيط لكنه غير مناسب للويب أو السحابة.
- **SSE (Server-Sent Events)**: يسمح للخوادم بدفع التحديثات في الوقت الحقيقي للعملاء عبر HTTP. جيد لواجهات الويب، لكنه محدود من حيث القابلية للتوسع والمرونة.
- **Streamable HTTP**: نقل بث حديث قائم على HTTP، يدعم الإشعارات وقابلية توسع أفضل. يُوصى به لمعظم سيناريوهات الإنتاج والسحابة.

### جدول المقارنة

اطلع على جدول المقارنة أدناه لفهم الفروق بين هذه الآليات:

| النقل            | التحديثات في الوقت الحقيقي | البث       | القابلية للتوسع | حالة الاستخدام           |
|------------------|-----------------------------|------------|-----------------|--------------------------|
| stdio            | لا                          | لا         | منخفض           | أدوات CLI محلية          |
| SSE              | نعم                         | نعم        | متوسط           | الويب، التحديثات في الوقت الحقيقي |
| Streamable HTTP  | نعم                         | نعم        | عالي            | السحابة، متعدد العملاء   |

> **نصيحة:** اختيار آلية النقل المناسبة يؤثر على الأداء، القابلية للتوسع، وتجربة المستخدم. **Streamable HTTP** هو الخيار الموصى به للتطبيقات الحديثة والقابلة للتوسع والمهيأة للسحابة.

لاحظ آليات النقل stdio و SSE التي تم عرضها في الفصول السابقة وكيف أن Streamable HTTP هو آلية النقل التي نغطيها في هذا الفصل.

## البث: المفاهيم والدوافع

فهم المفاهيم الأساسية والدوافع وراء البث أمر ضروري لتنفيذ أنظمة تواصل فعالة في الوقت الحقيقي.

**البث** هو تقنية في برمجة الشبكات تسمح بإرسال واستقبال البيانات على شكل أجزاء صغيرة يمكن إدارتها أو كسلسلة من الأحداث، بدلاً من انتظار استجابة كاملة جاهزة. هذا مفيد بشكل خاص لـ:

- الملفات أو مجموعات البيانات الكبيرة.
- التحديثات في الوقت الحقيقي (مثل الدردشة، أشرطة التقدم).
- العمليات الطويلة حيث ترغب في إبقاء المستخدم على اطلاع.

إليك ما تحتاج لمعرفته على مستوى عالٍ عن البث:

- يتم تسليم البيانات تدريجياً، وليس دفعة واحدة.
- يمكن للعميل معالجة البيانات أثناء وصولها.
- يقلل من التأخير المدرك ويحسن تجربة المستخدم.

### لماذا نستخدم البث؟

الأسباب لاستخدام البث هي كالتالي:

- يحصل المستخدمون على ردود فعل فورية، وليس فقط في النهاية.
- يمكن تطبيقات الوقت الحقيقي وواجهات المستخدم التفاعلية.
- استخدام أكثر كفاءة لموارد الشبكة والحوسبة.

### مثال بسيط: خادم وعميل بث HTTP

إليك مثال بسيط على كيفية تنفيذ البث:

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

يوضح هذا المثال خادمًا يرسل سلسلة من الرسائل إلى العميل بمجرد توفرها، بدلاً من الانتظار حتى تصبح كل الرسائل جاهزة.

**كيف يعمل:**
- الخادم يرسل كل رسالة بمجرد أن تكون جاهزة.
- العميل يستقبل ويطبع كل جزء عند وصوله.

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

- **للحالات البسيطة:** بث HTTP الكلاسيكي أسهل في التنفيذ وكافٍ للاحتياجات الأساسية.

- **للتطبيقات التفاعلية المعقدة:** يوفر بث MCP نهجًا أكثر تنظيمًا مع بيانات وصفية أغنى وفصل بين الإشعارات والنتائج النهائية.

- **لتطبيقات الذكاء الاصطناعي:** نظام الإشعارات في MCP مفيد بشكل خاص للمهام الطويلة حيث تريد إبقاء المستخدمين على اطلاع بالتقدم.

## البث في MCP

حسنًا، لقد رأيت بعض التوصيات والمقارنات حتى الآن بين البث الكلاسيكي والبث في MCP. دعنا نغوص في التفاصيل حول كيفية الاستفادة من البث في MCP.

فهم كيفية عمل البث ضمن إطار MCP ضروري لبناء تطبيقات تفاعلية توفر ردود فعل في الوقت الحقيقي للمستخدمين أثناء العمليات الطويلة.

في MCP، لا يتعلق البث بإرسال الاستجابة الرئيسية على شكل أجزاء، بل بإرسال **إشعارات** إلى العميل أثناء معالجة الأداة للطلب. يمكن أن تشمل هذه الإشعارات تحديثات التقدم، السجلات، أو أحداث أخرى.

### كيف يعمل

لا تزال النتيجة الرئيسية تُرسل كرد واحد. ومع ذلك، يمكن إرسال الإشعارات كرسائل منفصلة أثناء المعالجة لتحديث العميل في الوقت الحقيقي. يجب أن يكون العميل قادرًا على التعامل مع هذه الإشعارات وعرضها.

## ما هي الإشعارات؟

قلنا "إشعار"، ماذا يعني ذلك في سياق MCP؟

الإشعار هو رسالة تُرسل من الخادم إلى العميل لإبلاغه بالتقدم، الحالة، أو أحداث أخرى أثناء عملية طويلة. تحسن الإشعارات الشفافية وتجربة المستخدم.

على سبيل المثال، من المفترض أن يرسل العميل إشعارًا بمجرد إتمام المصافحة الأولية مع الخادم.

يبدو الإشعار كرسالة JSON مثل:

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

لكي يعمل التسجيل، يحتاج الخادم إلى تمكينه كميزة/قدرة كما يلي:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> اعتمادًا على SDK المستخدم، قد يكون التسجيل مفعلًا افتراضيًا، أو قد تحتاج إلى تمكينه صراحة في تكوين الخادم الخاص بك.

هناك أنواع مختلفة من الإشعارات:

| المستوى    | الوصف                          | مثال على الاستخدام               |
|------------|--------------------------------|----------------------------------|
| debug      | معلومات تفصيلية للتصحيح       | نقاط دخول/خروج الدوال           |
| info       | رسائل معلومات عامة            | تحديثات تقدم العمليات           |
| notice     | أحداث عادية لكنها مهمة         | تغييرات التكوين                 |
| warning    | حالات تحذيرية                 | استخدام ميزة مهجورة             |
| error      | حالات خطأ                     | فشل العمليات                   |
| critical   | حالات حرجة                   | فشل مكونات النظام               |
| alert      | يجب اتخاذ إجراء فورًا          | اكتشاف تلف في البيانات          |
| emergency  | النظام غير قابل للاستخدام     | فشل كامل للنظام                |

## تنفيذ الإشعارات في MCP

لتنفيذ الإشعارات في MCP، تحتاج إلى إعداد كل من الخادم والعميل للتعامل مع التحديثات في الوقت الحقيقي. هذا يسمح لتطبيقك بتوفير ردود فعل فورية للمستخدمين أثناء العمليات الطويلة.

### جانب الخادم: إرسال الإشعارات

لنبدأ بجانب الخادم. في MCP، تعرف الأدوات التي يمكنها إرسال إشعارات أثناء معالجة الطلبات. يستخدم الخادم كائن السياق (عادة `ctx`) لإرسال الرسائل إلى العميل.

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

في المثال السابق، تستخدم `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` النقل:

```python
mcp.run(transport="streamable-http")
```

</details>

### جانب العميل: استقبال الإشعارات

يجب على العميل تنفيذ معالج رسائل لمعالجة وعرض الإشعارات عند وصولها.

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

تشرح هذه القسم مفهوم إشعارات التقدم في MCP، ولماذا هي مهمة، وكيفية تنفيذها باستخدام Streamable HTTP. ستجد أيضًا مهمة عملية لتعزيز فهمك.

إشعارات التقدم هي رسائل في الوقت الحقيقي تُرسل من الخادم إلى العميل أثناء العمليات الطويلة. بدلاً من انتظار انتهاء العملية بالكامل، يبقي الخادم العميل على اطلاع بالحالة الحالية. هذا يحسن الشفافية، تجربة المستخدم، ويسهل عملية التصحيح.

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
- **ردود فعل في الوقت الحقيقي:** يمكن للعملاء عرض أشرطة تقدم أو سجلات، مما يجعل التطبيق يبدو تفاعليًا.
- **سهولة التصحيح والمراقبة:** يمكن للمطورين والمستخدمين رؤية أين قد تكون العملية بطيئة أو متوقفة.

### كيفية تنفيذ إشعارات التقدم

إليك كيفية تنفيذ إشعارات التقدم في MCP:

- **على الخادم:** استخدم `ctx.info()` or `ctx.log()` لإرسال الإشعارات أثناء معالجة كل عنصر. هذا يرسل رسالة إلى العميل قبل أن تكون النتيجة الرئيسية جاهزة.
- **على العميل:** نفذ معالج رسائل يستمع ويعرض الإشعارات عند وصولها. يميز هذا المعالج بين الإشعارات والنتيجة النهائية.

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

عند تنفيذ خوادم MCP باستخدام نقل قائم على HTTP، يصبح الأمان أمرًا بالغ الأهمية يتطلب اهتمامًا دقيقًا بعدة اتجاهات هجوم وآليات حماية.

### نظرة عامة

الأمان ضروري عند عرض خوادم MCP عبر HTTP. يقدم Streamable HTTP أسطح هجوم جديدة ويتطلب تكوينًا دقيقًا.

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

يوصى بالحفاظ على التوافق مع عملاء SSE الحاليين أثناء عملية الانتقال. فيما يلي بعض الاستراتيجيات:

- يمكنك دعم كل من SSE و Streamable HTTP بتشغيل كلا النقلين على نقاط نهاية مختلفة.
- قم بترحيل العملاء تدريجيًا إلى النقل الجديد.

### التحديات

تأكد من معالجة التحديات التالية أثناء الانتقال:

- ضمان تحديث جميع العملاء
- التعامل مع الفروق في تسليم الإشعارات

### المهمة: بناء تطبيق MCP للبث خاص بك

**السيناريو:**
قم ببناء خادم وعميل MCP حيث يعالج الخادم قائمة من العناصر (مثل ملفات أو مستندات) ويرسل إشعارًا لكل عنصر يتم معالجته. يجب على العميل عرض كل إشعار عند وصوله.

**الخطوات:**

1. نفذ أداة خادم تعالج القائمة وترسل إشعارات لكل عنصر.
2. نفذ عميلًا بمعالج رسائل لعرض الإشعارات في الوقت الحقيقي.
3. اختبر تنفيذك بتشغيل الخادم والعميل معًا، وراقب الإشعارات.

[الحل](./solution/README.md)

## مزيد من القراءة وما التالي؟

للاستمرار في رحلتك مع بث MCP وتوسيع معرفتك، يوفر هذا القسم موارد إضافية وخطوات مقترحة لبناء تطبيقات أكثر تقدمًا.

### مزيد من القراءة

- [Microsoft: مقدمة في بث HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: أحداث الخادم المرسلة (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS في ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: طلبات البث](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### ما التالي؟

- جرب بناء أدوات MCP أكثر تقدمًا تستخدم البث للتحليلات في الوقت الحقيقي، الدردشة، أو التحرير التعاوني.
- استكشف دمج بث MCP مع أطر الواجهة الأمامية (React، Vue، إلخ) لتحديثات واجهة المستخدم الحية.
- التالي: [استخدام مجموعة أدوات الذكاء الاصطناعي لـ VSCode](../07-aitk/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الرسمي والمعتمد. للمعلومات الهامة، يُنصح بالاستعانة بترجمة بشرية محترفة. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.