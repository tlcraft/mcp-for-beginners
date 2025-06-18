<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3eaf38ffe0638867045ec6664908333c",
  "translation_date": "2025-06-18T09:17:47+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "he"
}
-->
# שידור HTTPS עם פרוטוקול הקשר למודל (MCP)

פרק זה מספק מדריך מקיף ליישום שידור מאובטח, מדרגי ובזמן אמת באמצעות פרוטוקול הקשר למודל (MCP) באמצעות HTTPS. הוא מכסה את המוטיבציה לשידור, מנגנוני ההעברה הזמינים, כיצד ליישם HTTP שידורי ב-MCP, שיטות עבודה מומלצות לאבטחה, מעבר מ-SSE, והנחיות מעשיות לבניית יישומי MCP שידוריים משלך.

## מנגנוני העברה ושידור ב-MCP

סעיף זה בוחן את מנגנוני ההעברה השונים הזמינים ב-MCP ואת תפקידם באפשרות שידור לתקשורת בזמן אמת בין לקוחות לשרתים.

### מהו מנגנון העברה?

מנגנון העברה מגדיר כיצד הנתונים מוחלפים בין הלקוח לשרת. MCP תומך בסוגי העברה שונים המתאימים לסביבות ודרישות מגוונות:

- **stdio**: קלט/פלט סטנדרטי, מתאים לכלים מקומיים ומבוססי שורת פקודה. פשוט אך לא מתאים לאינטרנט או לענן.
- **SSE (Server-Sent Events)**: מאפשר לשרתים לדחוף עדכונים בזמן אמת ללקוחות דרך HTTP. טוב לממשקי רשת, אך מוגבל בקנה מידה וגמישות.
- **Streamable HTTP**: העברת שידור מודרנית מבוססת HTTP, תומכת בהתראות וסקלאביליות משופרת. מומלץ לרוב התרחישים בענן ובייצור.

### טבלת השוואה

הסתכל בטבלת ההשוואה למטה כדי להבין את ההבדלים בין מנגנוני ההעברה:

| העברה            | עדכונים בזמן אמת | שידור     | מדרגיות    | מקרה שימוש              |
|------------------|------------------|-----------|------------|-------------------------|
| stdio            | לא               | לא        | נמוך       | כלים מקומיים בשורת פקודה|
| SSE              | כן               | כן        | בינוני     | רשת, עדכונים בזמן אמת  |
| Streamable HTTP  | כן               | כן        | גבוה       | ענן, ריבוי לקוחות       |

> **טיפ:** בחירת מנגנון ההעברה הנכון משפיעה על הביצועים, מדרגיות וחווית המשתמש. **Streamable HTTP** מומלץ ליישומים מודרניים, מדרגיים ומוכנים לענן.

שימו לב למנגנוני stdio ו-SSE שהוצגו בפרקים הקודמים וכיצד Streamable HTTP הוא מנגנון ההעברה המכוסה בפרק זה.

## שידור: מושגים ומוטיבציה

הבנת המושגים הבסיסיים והמוטיבציות מאחורי השידור חיונית ליישום מערכות תקשורת בזמן אמת יעילות.

**שידור** הוא טכניקה בתכנות רשת שמאפשרת שליחה וקבלה של נתונים בחתיכות קטנות, ניתנות לניהול, או כרצף של אירועים, במקום להמתין לתגובה מלאה. זה שימושי במיוחד עבור:

- קבצים או מערכי נתונים גדולים.
- עדכונים בזמן אמת (למשל, צ’אט, פסי התקדמות).
- חישובים ארוכי טווח שבהם רוצים לשמור על המשתמש מעודכן.

הנה מה שחשוב לדעת על שידור ברמה גבוהה:

- הנתונים נמסרים בהדרגה, לא בבת אחת.
- הלקוח יכול לעבד את הנתונים כשהם מגיעים.
- מפחית את ההשהייה הנתפסת ומשפר את חווית המשתמש.

### למה להשתמש בשידור?

הסיבות לשימוש בשידור הן:

- המשתמשים מקבלים משוב מיידי, לא רק בסוף.
- מאפשר יישומים בזמן אמת וממשקים תגובתיים.
- שימוש יעיל יותר במשאבי רשת ומחשוב.

### דוגמה פשוטה: שרת ולקוח שידור HTTP

הנה דוגמה פשוטה ליישום שידור:

<details>
<summary>Python</summary>

**שרת (Python, עם FastAPI ו-StreamingResponse):**
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

**לקוח (Python, עם requests):**
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

דוגמה זו ממחישה שרת ששולח סדרת הודעות ללקוח כשהן מוכנות, במקום להמתין שכל ההודעות יהיו מוכנות.

**איך זה עובד:**
- השרת מייצר כל הודעה כשהיא מוכנה.
- הלקוח מקבל ומדפיס כל חלק כשהוא מגיע.

**דרישות:**
- השרת חייב להשתמש בתגובה שידורית (למשל, `StreamingResponse` in FastAPI).
- The client must process the response as a stream (`stream=True` in requests).
- Content-Type is usually `text/event-stream` or `application/octet-stream`.

</details>

<details>
<summary>Java</summary>

**שרת (Java, עם Spring Boot ו-Server-Sent Events):**

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

**לקוח (Java, עם Spring WebFlux WebClient):**

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

**הערות ליישום ב-Java:**
- משתמש בערימת Spring Boot הריאקטיבית עם `Flux` for streaming
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) לעומת בחירת שידור דרך MCP.

- **לצרכים פשוטים:** שידור HTTP קלאסי פשוט יותר ליישום ומספיק לצרכים בסיסיים.

- **ליישומים מורכבים ואינטראקטיביים:** שידור ב-MCP מספק גישה מובנית יותר עם מטא-נתונים עשירים והפרדה בין התראות לתוצאות סופיות.

- **ליישומי AI:** מערכת ההתראות של MCP שימושית במיוחד למשימות AI ארוכות טווח שבהן רוצים לעדכן את המשתמשים על ההתקדמות.

## שידור ב-MCP

אז ראיתם המלצות והשוואות עד כה בין שידור קלאסי לשידור ב-MCP. כעת נצלול לפרטים כיצד תוכלו לנצל שידור ב-MCP.

הבנת אופן פעולת השידור במסגרת MCP חיונית לבניית יישומים תגובתיים שמספקים משוב בזמן אמת למשתמשים במהלך פעולות ארוכות.

ב-MCP, השידור אינו מתייחס לשליחת התגובה הראשית בחתיכות, אלא לשליחת **התראות** ללקוח בזמן שהכלי מעבד בקשה. התראות אלה יכולות לכלול עדכוני התקדמות, לוגים או אירועים אחרים.

### איך זה עובד

התוצאה הראשית עדיין נשלחת כתשובה אחת. עם זאת, התראות נשלחות כהודעות נפרדות במהלך העיבוד וכך מעדכנות את הלקוח בזמן אמת. הלקוח חייב להיות מסוגל לטפל ולהציג התראות אלו.

## מהי התראה?

אמרנו "התראה", מה משמעותה בהקשר של MCP?

התראה היא הודעה שנשלחת מהשרת ללקוח כדי לעדכן על התקדמות, מצב או אירועים אחרים במהלך פעולה ארוכת טווח. התראות משפרות שקיפות וחווית משתמש.

לדוגמה, הלקוח אמור לשלוח התראה ברגע שנוצר חיבור ראשוני עם השרת.

התראה נראית כך כהודעת JSON:

```json
{
  jsonrpc: "2.0";
  method: string;
  params?: {
    [key: string]: unknown;
  };
}
```

התראות שייכות לנושא ב-MCP המכונה ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

כדי להפעיל רישום לוגים, השרת צריך לאפשר זאת כתכונה/יכולת כך:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> בהתאם ל-SDK שבו משתמשים, ייתכן שרישום הלוגים מופעל כברירת מחדל, או שתצטרכו להפעילו במפורש בקונפיגורציית השרת שלכם.

ישנם סוגים שונים של התראות:

| רמה       | תיאור                          | דוגמת מקרה שימוש             |
|-----------|--------------------------------|-----------------------------|
| debug     | מידע מפורט לניפוי שגיאות       | נקודות כניסה/יציאה של פונקציות |
| info      | הודעות מידע כלליות             | עדכוני התקדמות בפעולה       |
| notice    | אירועים רגילים אך משמעותיים   | שינויים בקונפיגורציה        |
| warning   | תנאי אזהרה                    | שימוש בתכונה מיושנת          |
| error     | תנאי שגיאה                   | כשלונות בפעולה              |
| critical  | תנאים קריטיים                 | כשלים ברכיבי מערכת           |
| alert     | יש לנקוט פעולה מידית           | זיהוי נזק לנתונים           |
| emergency | המערכת לא שמישה               | כשל מלא של המערכת           |

## יישום התראות ב-MCP

כדי ליישם התראות ב-MCP, יש להגדיר את שני הצדדים – השרת והלקוח – לטפל בעדכונים בזמן אמת. זה מאפשר ליישום שלך לספק משוב מיידי למשתמשים במהלך פעולות ארוכות.

### צד השרת: שליחת התראות

נתחיל בצד השרת. ב-MCP, מגדירים כלים שיכולים לשלוח התראות בזמן עיבוד בקשות. השרת משתמש באובייקט הקשר (בדרך כלל `ctx`) כדי לשלוח הודעות ללקוח.

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

בדוגמה שלמעלה, ה-`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` הוא מנגנון העברה:

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

בדוגמה זו ב-.NET, השיטה `ProcessFiles` tool is decorated with the `Tool` attribute and sends three notifications to the client as it processes each file. The `ctx.Info()` משמשת לשליחת הודעות מידע.

כדי לאפשר התראות בשרת MCP שלך ב-.NET, ודא שאתה משתמש במנגנון שידור:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

</details>

### צד הלקוח: קבלת התראות

הלקוח חייב לממש מטפל בהודעות כדי לעבד ולהציג התראות כשהן מגיעות.

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

בקוד שלמעלה, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` מטפל בהתראות הנכנסות.

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

בדוגמה זו ב-.NET, `MessageHandler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. The `ClientSession` is initialized with the message handler via the `ClientSessionOptions`.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http`) והלקוח שלך מממש מטפל בהודעות כדי לעבד התראות.

## התראות התקדמות ותסריטים

סעיף זה מסביר את מושג התראות ההתקדמות ב-MCP, מדוע הן חשובות, וכיצד ליישמן באמצעות Streamable HTTP. תמצא גם תרגיל מעשי לחיזוק ההבנה.

התראות התקדמות הן הודעות בזמן אמת שנשלחות מהשרת ללקוח במהלך פעולות ארוכות. במקום להמתין לסיום כל התהליך, השרת מעדכן את הלקוח על המצב הנוכחי. זה משפר שקיפות, חווית משתמש ומקל על ניפוי שגיאות.

**דוגמה:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### למה להשתמש בהתראות התקדמות?

התראות התקדמות חשובות מכמה סיבות:

- **חווית משתמש משופרת:** המשתמשים רואים עדכונים בזמן שהעבודה מתקדמת, לא רק בסופה.
- **משוב בזמן אמת:** הלקוחות יכולים להציג פסי התקדמות או לוגים, מה שהופך את האפליקציה לתגובתית.
- **ניפוי שגיאות ומעקב קל יותר:** מפתחים ומשתמשים יכולים לראות היכן התהליך איטי או תקוע.

### איך ליישם התראות התקדמות

כך ניתן ליישם התראות התקדמות ב-MCP:

- **בשרת:** השתמש ב-`ctx.info()` or `ctx.log()` לשליחת התראות עם עיבוד כל פריט. זה שולח הודעה ללקוח לפני שהתוצאה הראשית מוכנה.
- **בלקוח:** מימש מטפל בהודעות שמאזין ומציג התראות כשהן מגיעות. מטפל זה מבדיל בין התראות לתוצאה הסופית.

**דוגמת שרת:**

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

**דוגמת לקוח:**

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

## שיקולי אבטחה

בעת יישום שרתי MCP עם מנגנוני העברה מבוססי HTTP, האבטחה הופכת לנושא מרכזי שדורש תשומת לב קפדנית לווקטורי התקפה שונים ומנגנוני הגנה.

### סקירה כללית

האבטחה קריטית בעת חשיפת שרתי MCP דרך HTTP. Streamable HTTP מציג נקודות תורפה חדשות ודורש תצורה מדוקדקת.

### נקודות מפתח
- **אימות כותרת Origin**: תמיד אמת את כותרת `Origin` header to prevent DNS rebinding attacks.
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
2. **Update client code** to use `streamablehttp_client` במקום לקוח SSE.
3. **מימוש מטפל בהודעות** בלקוח לעיבוד התראות.
4. **בדיקה לתאימות** עם כלים וזרימות עבודה קיימות.

### שמירת תאימות

מומלץ לשמור על תאימות עם לקוחות SSE קיימים במהלך תהליך ההעברה. להלן כמה אסטרטגיות:

- ניתן לתמוך גם ב-SSE וגם ב-Streamable HTTP על ידי הפעלת שני מנגנוני ההעברה בנקודות קצה שונות.
- לבצע העברה הדרגתית של הלקוחות למנגנון החדש.

### אתגרים

ודא שאתה מתמודד עם האתגרים הבאים במהלך ההעברה:

- עדכון כל הלקוחות
- טיפול בהבדלים במשלוח ההתראות

### תרגיל: בנה אפליקציית MCP שידורית משלך

**תרחיש:**
בנה שרת ולקוח MCP כאשר השרת מעבד רשימת פריטים (למשל, קבצים או מסמכים) ושולח התראה עבור כל פריט שעובד. הלקוח יציג כל התראה כשהיא מגיעה.

**שלבים:**

1. מימוש כלי שרת שמעבד רשימה ושולח התראות עבור כל פריט.
2. מימוש לקוח עם מטפל בהודעות להצגת התראות בזמן אמת.
3. בדוק את היישום שלך על ידי הרצת השרת והלקוח וצפה בהתראות.

[פתרון](./solution/README.md)

## קריאה נוספת ומה הלאה?

כדי להמשיך במסע שלך עם שידור MCP ולהרחיב את הידע, סעיף זה מספק משאבים נוספים והצעות לצעדים הבאים לבניית יישומים מתקדמים יותר.

### קריאה נוספת

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### מה הלאה?

- נסה לבנות כלים מתקדמים יותר ב-MCP שמשתמשים בשידור לניתוחים בזמן אמת, צ’אט או עריכה שיתופית.
- חקור שילוב של שידור MCP עם מסגרות פרונטאנד (React, Vue וכו') לעדכוני ממשק חיים.
- הבא: [שימוש בערכת כלים AI ל-VSCode](../07-aitk/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.