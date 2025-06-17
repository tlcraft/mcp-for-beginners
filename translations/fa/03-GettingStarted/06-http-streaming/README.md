<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T21:54:37+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "fa"
}
-->
# پخش HTTPS با پروتکل مدل کانتکست (MCP)

این فصل راهنمای جامعی برای پیاده‌سازی پخش امن، مقیاس‌پذیر و زمان واقعی با استفاده از پروتکل مدل کانتکست (MCP) از طریق HTTPS ارائه می‌دهد. در این فصل به انگیزه پخش، مکانیزم‌های انتقال موجود، نحوه پیاده‌سازی HTTP قابل پخش در MCP، بهترین روش‌های امنیتی، مهاجرت از SSE و راهنمایی‌های عملی برای ساخت برنامه‌های پخش MCP پرداخته شده است.

## مکانیزم‌های انتقال و پخش در MCP

این بخش به بررسی مکانیزم‌های انتقال مختلف موجود در MCP و نقش آن‌ها در فراهم کردن قابلیت‌های پخش برای ارتباط زمان واقعی بین کلاینت‌ها و سرورها می‌پردازد.

### مکانیزم انتقال چیست؟

مکانیزم انتقال تعیین می‌کند داده‌ها چگونه بین کلاینت و سرور رد و بدل می‌شوند. MCP از چندین نوع انتقال پشتیبانی می‌کند تا متناسب با محیط‌ها و نیازهای مختلف باشد:

- **stdio**: ورودی/خروجی استاندارد، مناسب برای ابزارهای محلی و مبتنی بر خط فرمان. ساده اما مناسب وب یا فضای ابری نیست.
- **SSE (Server-Sent Events)**: اجازه می‌دهد سرورها به‌روزرسانی‌های زمان واقعی را از طریق HTTP به کلاینت‌ها ارسال کنند. برای رابط‌های وب خوب است، اما در مقیاس‌پذیری و انعطاف‌پذیری محدودیت دارد.
- **Streamable HTTP**: انتقال پخش مبتنی بر HTTP مدرن که از اعلان‌ها و مقیاس‌پذیری بهتر پشتیبانی می‌کند. برای بیشتر سناریوهای تولید و ابری توصیه می‌شود.

### جدول مقایسه

برای درک تفاوت‌های این مکانیزم‌های انتقال، جدول زیر را ببینید:

| انتقال            | به‌روزرسانی زمان واقعی | پخش       | مقیاس‌پذیری | کاربرد                    |
|-------------------|------------------------|-----------|-------------|--------------------------|
| stdio             | خیر                    | خیر       | پایین      | ابزارهای محلی خط فرمان    |
| SSE               | بله                    | بله       | متوسط      | وب، به‌روزرسانی زمان واقعی |
| Streamable HTTP   | بله                    | بله       | بالا       | فضای ابری، چند کلاینتی   |

> **نکته:** انتخاب مکانیزم انتقال مناسب بر عملکرد، مقیاس‌پذیری و تجربه کاربری تأثیر می‌گذارد. **Streamable HTTP** برای برنامه‌های مدرن، مقیاس‌پذیر و آماده فضای ابری توصیه می‌شود.

به مکانیزم‌های stdio و SSE که در فصل‌های قبلی معرفی شدند توجه کنید و اینکه در این فصل تمرکز بر Streamable HTTP است.

## پخش: مفاهیم و انگیزه

درک مفاهیم پایه و انگیزه‌های پشت پخش برای پیاده‌سازی سیستم‌های ارتباطی زمان واقعی مؤثر ضروری است.

**پخش** تکنیکی در برنامه‌نویسی شبکه است که اجازه می‌دهد داده‌ها به صورت بخش‌های کوچک و قابل مدیریت یا به شکل توالی رویدادها ارسال و دریافت شوند، به جای اینکه منتظر بمانیم کل پاسخ آماده شود. این روش به ویژه برای موارد زیر مفید است:

- فایل‌ها یا مجموعه داده‌های بزرگ
- به‌روزرسانی‌های زمان واقعی (مثلاً چت، نوارهای پیشرفت)
- محاسبات طولانی‌مدت که می‌خواهید کاربر را در جریان نگه دارید

در سطح کلی، نکات زیر درباره پخش باید بدانید:

- داده‌ها به صورت تدریجی ارسال می‌شوند، نه همه یکجا
- کلاینت می‌تواند داده‌ها را هنگام دریافت پردازش کند
- تأخیر درک شده را کاهش داده و تجربه کاربری را بهبود می‌بخشد

### چرا از پخش استفاده کنیم؟

دلایل استفاده از پخش عبارتند از:

- کاربران بلافاصله بازخورد دریافت می‌کنند، نه فقط در پایان
- امکان ساخت برنامه‌های زمان واقعی و رابط‌های پاسخگو را فراهم می‌کند
- استفاده بهینه‌تر از منابع شبکه و محاسبات

### مثال ساده: سرور و کلاینت پخش HTTP

در اینجا یک مثال ساده از پیاده‌سازی پخش آورده شده است:

<details>
<summary>Python</summary>

**سرور (Python، با استفاده از FastAPI و StreamingResponse):**
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

**کلاینت (Python، با استفاده از requests):**
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

این مثال نشان می‌دهد سرور پیام‌ها را به محض آماده شدن به کلاینت ارسال می‌کند، نه اینکه منتظر تمام پیام‌ها باشد.

**نحوه کار:**
- سرور هر پیام را به محض آماده شدن ارسال می‌کند.
- کلاینت هر بخش را هنگام دریافت چاپ می‌کند.

**نیازمندی‌ها:**
- سرور باید از پاسخ پخش‌شونده استفاده کند (مثلاً `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) به جای انتخاب پخش از طریق MCP.

- **برای نیازهای ساده پخش:** پخش کلاسیک HTTP ساده‌تر است و برای نیازهای پایه کافی است.

- **برای برنامه‌های پیچیده و تعاملی:** پخش MCP رویکرد ساختاریافته‌تری با متادیتای غنی‌تر و جداسازی بین اعلان‌ها و نتایج نهایی ارائه می‌دهد.

- **برای برنامه‌های هوش مصنوعی:** سیستم اعلان MCP به ویژه برای کارهای طولانی هوش مصنوعی که می‌خواهید کاربران را از پیشرفت مطلع کنید مفید است.

## پخش در MCP

خوب، تا اینجا برخی توصیه‌ها و مقایسه‌ها درباره تفاوت بین پخش کلاسیک و پخش در MCP دیدید. حالا به جزئیات می‌پردازیم که چگونه می‌توانید پخش را در MCP به کار ببرید.

درک نحوه کار پخش در چارچوب MCP برای ساخت برنامه‌های پاسخگو که بازخورد زمان واقعی به کاربران در طول عملیات طولانی‌مدت ارائه می‌دهند، ضروری است.

در MCP، پخش به معنای ارسال پاسخ اصلی به صورت بخش بخش نیست، بلکه ارسال **اعلان‌ها** به کلاینت در حین پردازش درخواست توسط ابزار است. این اعلان‌ها می‌توانند شامل به‌روزرسانی پیشرفت، لاگ‌ها یا رویدادهای دیگر باشند.

### چگونه کار می‌کند

نتیجه اصلی هنوز به صورت یک پاسخ واحد ارسال می‌شود. با این حال، اعلان‌ها می‌توانند به صورت پیام‌های جداگانه در طول پردازش ارسال شده و کلاینت را در زمان واقعی به‌روزرسانی کنند. کلاینت باید بتواند این اعلان‌ها را دریافت و نمایش دهد.

## اعلان چیست؟

گفتیم "اعلان"، این در زمینه MCP به چه معناست؟

اعلان پیامی است که از سرور به کلاینت ارسال می‌شود تا درباره پیشرفت، وضعیت یا رویدادهای دیگر در طول یک عملیات طولانی‌مدت اطلاع‌رسانی کند. اعلان‌ها شفافیت و تجربه کاربری را بهبود می‌بخشند.

برای مثال، کلاینت باید پس از انجام دست دادن اولیه با سرور، یک اعلان ارسال کند.

یک اعلان به شکل پیام JSON به صورت زیر است:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

اعلان‌ها متعلق به موضوعی در MCP به نام ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging) هستند.

برای فعال کردن لاگ‌گیری، سرور باید آن را به عنوان ویژگی/قابلیت فعال کند، مانند:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> بسته به SDK استفاده شده، ممکن است لاگ‌گیری به صورت پیش‌فرض فعال باشد یا نیاز باشد به طور صریح در پیکربندی سرور فعال شود.

انواع مختلفی از اعلان‌ها وجود دارد:

| سطح       | توضیح                         | مثال کاربرد                    |
|-----------|-------------------------------|------------------------------|
| debug     | اطلاعات دقیق برای اشکال‌زدایی | نقاط ورود/خروج تابع          |
| info      | پیام‌های اطلاعات عمومی         | به‌روزرسانی پیشرفت عملیات    |
| notice    | رویدادهای عادی اما مهم        | تغییرات پیکربندی             |
| warning   | شرایط هشدار                  | استفاده از قابلیت منسوخ شده  |
| error     | شرایط خطا                    | شکست عملیات                  |
| critical  | شرایط بحرانی                | خرابی اجزای سیستم           |
| alert     | اقدام فوری لازم است           | شناسایی خرابی داده           |
| emergency | سیستم غیرقابل استفاده است     | خرابی کامل سیستم             |

## پیاده‌سازی اعلان‌ها در MCP

برای پیاده‌سازی اعلان‌ها در MCP، باید هر دو سمت سرور و کلاینت را برای دریافت به‌روزرسانی‌های زمان واقعی آماده کنید. این امکان را به برنامه شما می‌دهد که در طول عملیات طولانی‌مدت بازخورد فوری به کاربران ارائه دهد.

### سمت سرور: ارسال اعلان‌ها

با سمت سرور شروع کنیم. در MCP، ابزارهایی تعریف می‌کنید که می‌توانند هنگام پردازش درخواست‌ها اعلان ارسال کنند. سرور از شیء context (معمولاً `ctx`) برای ارسال پیام به کلاینت استفاده می‌کند.

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

در مثال بالا، `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` انتقال:

```python
mcp.run(transport="streamable-http")
```

</details>

### سمت کلاینت: دریافت اعلان‌ها

کلاینت باید یک هندلر پیام پیاده‌سازی کند تا اعلان‌ها را هنگام دریافت پردازش و نمایش دهد.

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

در کد بالا، `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) و کلاینت شما هندلری برای پردازش اعلان‌ها پیاده‌سازی می‌کند.

## اعلان‌های پیشرفت و سناریوها

این بخش مفهوم اعلان‌های پیشرفت در MCP، اهمیت آن‌ها و نحوه پیاده‌سازی آن‌ها با استفاده از Streamable HTTP را توضیح می‌دهد. همچنین یک تمرین عملی برای تقویت یادگیری شما ارائه شده است.

اعلان‌های پیشرفت پیام‌های زمان واقعی هستند که از سرور به کلاینت در طول عملیات طولانی ارسال می‌شوند. به جای اینکه منتظر بمانیم کل فرایند تمام شود، سرور کلاینت را درباره وضعیت فعلی به‌روزرسانی می‌کند. این شفافیت، تجربه کاربری و اشکال‌زدایی را بهبود می‌بخشد.

**مثال:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### چرا از اعلان‌های پیشرفت استفاده کنیم؟

اعلان‌های پیشرفت به دلایل زیر ضروری‌اند:

- **تجربه کاربری بهتر:** کاربران به‌روزرسانی‌ها را هنگام پیشرفت کار می‌بینند، نه فقط در پایان.
- **بازخورد زمان واقعی:** کلاینت‌ها می‌توانند نوار پیشرفت یا لاگ‌ها را نمایش دهند و برنامه پاسخگو به نظر برسد.
- **اشکال‌زدایی و نظارت آسان‌تر:** توسعه‌دهندگان و کاربران می‌توانند ببینند کجا فرایند ممکن است کند یا متوقف شده باشد.

### چگونه اعلان‌های پیشرفت را پیاده‌سازی کنیم

نحوه پیاده‌سازی اعلان‌های پیشرفت در MCP به شرح زیر است:

- **در سرور:** از `ctx.info()` or `ctx.log()` برای ارسال اعلان‌ها هنگام پردازش هر آیتم استفاده کنید. این پیام‌ها قبل از آماده شدن نتیجه اصلی به کلاینت ارسال می‌شوند.
- **در کلاینت:** هندلری پیاده‌سازی کنید که اعلان‌ها را هنگام دریافت شنود و نمایش دهد. این هندلر بین اعلان‌ها و نتیجه نهایی تمایز قائل می‌شود.

**مثال سرور:**

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

**مثال کلاینت:**

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

## ملاحظات امنیتی

هنگام پیاده‌سازی سرورهای MCP با انتقال‌های مبتنی بر HTTP، امنیت به یک نگرانی اساسی تبدیل می‌شود که نیازمند توجه دقیق به چندین مسیر حمله و مکانیزم‌های محافظتی است.

### مرور کلی

امنیت هنگام ارائه سرورهای MCP از طریق HTTP بسیار حیاتی است. Streamable HTTP سطوح حمله جدیدی معرفی می‌کند و نیازمند پیکربندی دقیق است.

### نکات کلیدی
- **اعتبارسنجی هدر Origin**: همیشه هدر `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` را به جای کلاینت SSE بررسی کنید.
3. **پیاده‌سازی هندلر پیام** در کلاینت برای پردازش اعلان‌ها.
4. **آزمون سازگاری** با ابزارها و جریان‌های کاری موجود.

### حفظ سازگاری

توصیه می‌شود در فرایند مهاجرت سازگاری با کلاینت‌های SSE موجود حفظ شود. راهکارها عبارتند از:

- می‌توانید هم SSE و هم Streamable HTTP را با اجرای هر دو روی نقاط پایانی مختلف پشتیبانی کنید.
- به تدریج کلاینت‌ها را به انتقال جدید منتقل کنید.

### چالش‌ها

در طول مهاجرت باید به چالش‌های زیر رسیدگی کنید:

- اطمینان از به‌روزرسانی همه کلاینت‌ها
- مدیریت تفاوت‌ها در ارسال اعلان‌ها

### تمرین: ساخت برنامه پخش MCP خودتان

**سناریو:**
یک سرور و کلاینت MCP بسازید که سرور یک لیست از آیتم‌ها (مثلاً فایل‌ها یا اسناد) را پردازش کند و برای هر آیتم پردازش شده یک اعلان ارسال کند. کلاینت باید هر اعلان را هنگام دریافت نمایش دهد.

**مراحل:**

1. ابزار سرور را پیاده‌سازی کنید که لیستی را پردازش کرده و برای هر آیتم اعلان ارسال کند.
2. کلاینتی با هندلر پیام پیاده‌سازی کنید که اعلان‌ها را به صورت زمان واقعی نمایش دهد.
3. پیاده‌سازی خود را با اجرای همزمان سرور و کلاینت تست کرده و اعلان‌ها را مشاهده کنید.

[راه‌حل](./solution/README.md)

## مطالعه بیشتر و گام بعدی چیست؟

برای ادامه مسیر با پخش MCP و گسترش دانش خود، این بخش منابع اضافی و گام‌های پیشنهادی بعدی برای ساخت برنامه‌های پیشرفته‌تر را ارائه می‌دهد.

### مطالعه بیشتر

- [Microsoft: معرفی پخش HTTP](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: رویدادهای ارسالی از سرور (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS در ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: درخواست‌های پخش](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### گام بعدی چیست؟

- سعی کنید ابزارهای پیشرفته‌تری در MCP بسازید که از پخش برای تحلیل‌های زمان واقعی، چت یا ویرایش مشترک استفاده می‌کنند.
- ادغام پخش MCP با فریم‌ورک‌های فرانت‌اند (React، Vue و غیره) برای به‌روزرسانی‌های زنده UI را بررسی کنید.
- بعدی: [استفاده از جعبه‌ابزار هوش مصنوعی برای VSCode](../07-aitk/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه ماشینی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.