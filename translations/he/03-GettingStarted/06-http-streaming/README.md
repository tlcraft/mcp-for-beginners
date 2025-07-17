<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "40b1bbffdb8ce6812bf6e701cad876b6",
  "translation_date": "2025-07-17T18:58:18+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "he"
}
-->
# סטרימינג ב-HTTPS עם פרוטוקול Model Context (MCP)

פרק זה מספק מדריך מקיף ליישום סטרימינג מאובטח, מדרגי ובזמן אמת באמצעות פרוטוקול Model Context (MCP) על גבי HTTPS. הוא מכסה את המוטיבציה לסטרימינג, מנגנוני ההעברה הזמינים, כיצד ליישם HTTP סטרימינג ב-MCP, שיטות אבטחה מומלצות, מעבר מ-SSE והנחיות מעשיות לבניית יישומי סטרימינג ב-MCP משלך.

## מנגנוני העברה וסטרימינג ב-MCP

חלק זה בוחן את מנגנוני ההעברה השונים הזמינים ב-MCP ואת תפקידם בהפעלת יכולות סטרימינג לתקשורת בזמן אמת בין לקוחות לשרתים.

### מהו מנגנון העברה?

מנגנון העברה מגדיר כיצד מתבצע חילוף הנתונים בין הלקוח לשרת. MCP תומך בסוגי העברה שונים המתאימים לסביבות ודרישות שונות:

- **stdio**: קלט/פלט סטנדרטי, מתאים לכלים מקומיים ומבוססי CLI. פשוט אך לא מתאים לאינטרנט או ענן.
- **SSE (Server-Sent Events)**: מאפשר לשרתים לדחוף עדכונים בזמן אמת ללקוחות דרך HTTP. טוב לממשקי ווב, אך מוגבל בקנה מידה וגמישות.
- **Streamable HTTP**: העברת סטרימינג מודרנית מבוססת HTTP, תומכת בהתראות וסקלאביליות טובה יותר. מומלץ לרוב תרחישי ייצור וענן.

### טבלת השוואה

הסתכל בטבלת ההשוואה למטה כדי להבין את ההבדלים בין מנגנוני ההעברה:

| העברה             | עדכוני זמן אמת | סטרימינג | מדרגיות | מקרה שימוש              |
|-------------------|----------------|----------|---------|-------------------------|
| stdio             | לא             | לא       | נמוך    | כלים מקומיים ב-CLI      |
| SSE               | כן             | כן       | בינוני  | ווב, עדכוני זמן אמת    |
| Streamable HTTP   | כן             | כן       | גבוה    | ענן, לקוחות מרובים      |

> **טיפ:** בחירת מנגנון ההעברה משפיעה על ביצועים, מדרגיות וחוויית המשתמש. **Streamable HTTP** מומלץ ליישומים מודרניים, מדרגיים ומוכנים לענן.

שים לב למנגנוני ההעברה stdio ו-SSE שהוצגו בפרקים הקודמים ואיך Streamable HTTP הוא מנגנון ההעברה הנדון בפרק זה.

## סטרימינג: מושגים ומוטיבציה

הבנת המושגים הבסיסיים והמוטיבציה מאחורי סטרימינג חיונית ליישום מערכות תקשורת בזמן אמת יעילות.

**סטרימינג** היא טכניקה בתכנות רשת המאפשרת לשלוח ולקבל נתונים בחתיכות קטנות, ניתנות לניהול, או כרצף אירועים, במקום להמתין לתגובה מלאה. זה שימושי במיוחד עבור:

- קבצים או מערכי נתונים גדולים.
- עדכוני זמן אמת (למשל, צ'אט, פסי התקדמות).
- חישובים ארוכי טווח שבהם רוצים לעדכן את המשתמש.

הנה מה שחשוב לדעת על סטרימינג ברמה גבוהה:

- הנתונים נמסרים בהדרגה, לא בבת אחת.
- הלקוח יכול לעבד את הנתונים כשהם מגיעים.
- מפחית את תחושת ההשהיה ומשפר את חוויית המשתמש.

### למה להשתמש בסטרימינג?

הסיבות לשימוש בסטרימינג הן:

- המשתמשים מקבלים משוב מיידי, לא רק בסוף
- מאפשר יישומים בזמן אמת וממשקי משתמש רספונסיביים
- שימוש יעיל יותר במשאבי רשת ומחשוב

### דוגמה פשוטה: שרת ולקוח סטרימינג ב-HTTP

הנה דוגמה פשוטה ליישום סטרימינג:

## Python

**שרת (Python, באמצעות FastAPI ו-StreamingResponse):**

### Python

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


**לקוח (Python, באמצעות requests):**

### Python

```python
import requests

with requests.get("http://localhost:8000/stream", stream=True) as r:
    for line in r.iter_lines():
        if line:
            print(line.decode())
```


דוגמה זו מדגימה שרת ששולח סדרת הודעות ללקוח כשהן זמינות, במקום להמתין שכל ההודעות יהיו מוכנות.

**איך זה עובד:**
- השרת משחרר כל הודעה כשהיא מוכנה.
- הלקוח מקבל ומדפיס כל חתיכה כשהיא מגיעה.

**דרישות:**
- השרת חייב להשתמש בתגובה סטרימינג (למשל, `StreamingResponse` ב-FastAPI).
- הלקוח חייב לעבד את התגובה כסטרים (`stream=True` ב-requests).
- Content-Type בדרך כלל `text/event-stream` או `application/octet-stream`.

## Java

**שרת (Java, באמצעות Spring Boot ו-Server-Sent Events):**

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

**לקוח (Java, באמצעות Spring WebFlux WebClient):**

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
- משתמש בערימת Spring Boot הריאקטיבית עם `Flux` לסטרימינג
- `ServerSentEvent` מספק סטרימינג מובנה עם סוגי אירועים
- `WebClient` עם `bodyToFlux()` מאפשר צריכת סטרימינג ריאקטיבית
- `delayElements()` מדמה זמן עיבוד בין אירועים
- לאירועים יכולים להיות סוגים (`info`, `result`) לטיפול טוב יותר בלקוח


### השוואה: סטרימינג קלאסי מול סטרימינג ב-MCP

ההבדלים בין סטרימינג "קלאסי" לבין סטרימינג ב-MCP מוצגים כך:

| תכונה                 | סטרימינג HTTP קלאסי          | סטרימינג MCP (התראות)          |
|-----------------------|------------------------------|--------------------------------|
| תגובה ראשית           | מחולקת לחתיכות              | יחידה, בסוף                   |
| עדכוני התקדמות        | נשלחים כחלק מהנתונים         | נשלחים כהתראות               |
| דרישות מהלקוח         | חייב לעבד סטרים              | חייב לממש מטפל הודעות          |
| מקרה שימוש            | קבצים גדולים, סטרימי טוקנים | התקדמות, לוגים, משוב בזמן אמת |

### הבדלים מרכזיים שנצפו

בנוסף, הנה כמה הבדלים מרכזיים:

- **תבנית תקשורת:**
   - סטרימינג HTTP קלאסי: משתמש בקידוד העברת חתיכות פשוט לשליחת נתונים בחתיכות
   - סטרימינג MCP: משתמש במערכת התראות מובנית עם פרוטוקול JSON-RPC

- **פורמט ההודעה:**
   - HTTP קלאסי: חתיכות טקסט פשוט עם שורות חדשות
   - MCP: אובייקטים מובנים מסוג LoggingMessageNotification עם מטא-נתונים

- **יישום הלקוח:**
   - HTTP קלאסי: לקוח פשוט שמעבד תגובות סטרימינג
   - MCP: לקוח מתוחכם עם מטפל הודעות לעיבוד סוגי הודעות שונים

- **עדכוני התקדמות:**
   - HTTP קלאסי: ההתקדמות היא חלק מהזרם הראשי
   - MCP: ההתקדמות נשלחת כהודעות התראה נפרדות בזמן שהתגובה הראשית מגיעה בסוף

### המלצות

יש כמה המלצות בבחירה בין יישום סטרימינג קלאסי (כפי שהראינו עם `/stream`) לבין סטרימינג דרך MCP.

- **לצרכי סטרימינג פשוטים:** סטרימינג HTTP קלאסי פשוט יותר ליישום ומספיק לצרכים בסיסיים.

- **ליישומים מורכבים ואינטראקטיביים:** סטרימינג MCP מספק גישה מובנית יותר עם מטא-נתונים עשירים והפרדה בין התראות לתוצאות סופיות.

- **ליישומי AI:** מערכת ההתראות של MCP שימושית במיוחד למשימות AI ארוכות טווח שבהן רוצים לעדכן את המשתמשים בהתקדמות.

## סטרימינג ב-MCP

טוב, ראית כבר כמה המלצות והשוואות על ההבדל בין סטרימינג קלאסי לסטרימינג ב-MCP. עכשיו נצלול לפרטים כיצד ניתן לנצל סטרימינג ב-MCP.

הבנת אופן פעולת הסטרימינג במסגרת MCP חיונית לבניית יישומים רספונסיביים המספקים משוב בזמן אמת למשתמשים במהלך פעולות ארוכות.

ב-MCP, סטרימינג אינו מתייחס לשליחת התגובה הראשית בחתיכות, אלא לשליחת **התראות** ללקוח בזמן שהכלי מעבד בקשה. התראות אלו יכולות לכלול עדכוני התקדמות, לוגים או אירועים אחרים.

### איך זה עובד

התוצאה הראשית עדיין נשלחת כתגובה יחידה. עם זאת, ניתן לשלוח התראות כהודעות נפרדות במהלך העיבוד וכך לעדכן את הלקוח בזמן אמת. הלקוח חייב להיות מסוגל לטפל ולהציג התראות אלו.

## מהי התראה?

אמרנו "התראה", מה משמעותה בהקשר של MCP?

התראה היא הודעה שנשלחת מהשרת ללקוח כדי ליידע על התקדמות, סטטוס או אירועים אחרים במהלך פעולה ארוכת טווח. התראות משפרות את השקיפות וחוויית המשתמש.

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

כדי להפעיל לוגינג, השרת צריך לאפשר זאת כמאפיין/יכולת כך:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> בהתאם ל-SDK שבו משתמשים, ייתכן שלוגינג מופעל כברירת מחדל, או שתצטרך להפעילו במפורש בקונפיגורציית השרת.

קיימים סוגים שונים של התראות:

| רמה       | תיאור                         | דוגמת מקרה שימוש             |
|-----------|-------------------------------|-----------------------------|
| debug     | מידע מפורט לניפוי שגיאות      | נקודות כניסה/יציאה מפונקציות |
| info      | הודעות מידע כלליות            | עדכוני התקדמות בפעולה       |
| notice    | אירועים רגילים אך משמעותיים  | שינויים בקונפיגורציה        |
| warning   | תנאי אזהרה                   | שימוש בתכונה מיושנת          |
| error     | תנאי שגיאה                   | כשלונות בפעולה              |
| critical  | תנאים קריטיים                | כשל ברכיב מערכת             |
| alert     | יש לנקוט פעולה מיידית         | זיהוי פגיעה בנתונים         |
| emergency | המערכת אינה שמישה           | כשל מערכת מלא               |


## יישום התראות ב-MCP

כדי ליישם התראות ב-MCP, יש להגדיר גם את צד השרת וגם את צד הלקוח לטיפול בעדכונים בזמן אמת. זה מאפשר ליישום שלך לספק משוב מיידי למשתמשים במהלך פעולות ארוכות.

### צד השרת: שליחת התראות

נתחיל בצד השרת. ב-MCP, מגדירים כלים שיכולים לשלוח התראות בזמן עיבוד בקשות. השרת משתמש באובייקט הקשר (בדרך כלל `ctx`) כדי לשלוח הודעות ללקוח.

### Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    await ctx.info("Processing file 1/3...")
    await ctx.info("Processing file 2/3...")
    await ctx.info("Processing file 3/3...")
    return TextContent(type="text", text=f"Done: {message}")
```

בדוגמה הקודמת, הכלי `process_files` שולח שלוש התראות ללקוח תוך כדי עיבוד כל קובץ. השיטה `ctx.info()` משמשת לשליחת הודעות מידע.

בנוסף, כדי לאפשר התראות, ודא שהשרת משתמש במנגנון העברה סטרימינג (כמו `streamable-http`) ושהלקוח מיישם מטפל הודעות לעיבוד התראות. כך תוכל להגדיר את השרת להשתמש במנגנון `streamable-http`:

```python
mcp.run(transport="streamable-http")
```

### .NET

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

בדוגמה זו ב-.NET, הכלי `ProcessFiles` מסומן עם התכונה `Tool` ושולח שלוש התראות ללקוח תוך כדי עיבוד כל קובץ. השיטה `ctx.Info()` משמשת לשליחת הודעות מידע.

כדי לאפשר התראות בשרת MCP שלך ב-.NET, ודא שאתה משתמש במנגנון העברה סטרימינג:

```csharp
var builder = McpBuilder.Create();
await builder
    .UseStreamableHttp() // Enable streamable HTTP transport
    .Build()
    .RunAsync();
```

### צד הלקוח: קבלת התראות

הלקוח חייב לממש מטפל הודעות לעיבוד והצגת התראות כשהן מגיעות.

### Python

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

בקוד שלמעלה, הפונקציה `message_handler` בודקת אם ההודעה הנכנסת היא התראה. אם כן, היא מדפיסה את ההתראה; אחרת, מעבדת אותה כהודעת שרת רגילה. שים לב גם ש-`ClientSession` מאותחל עם `message_handler` לטיפול בהתראות נכנסות.

### .NET

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

בדוגמה זו ב-.NET, הפונקציה `MessageHandler` בודקת אם ההודעה הנכנסת היא התראה. אם כן, היא מדפיסה את ההתראה; אחרת, מעבדת אותה כהודעת שרת רגילה. `ClientSession` מאותחל עם מטפל ההודעות דרך `ClientSessionOptions`.

כדי לאפשר התראות, ודא שהשרת שלך משתמש במנגנון העברה סטרימינג (כמו `streamable-http`) ושהלקוח מיישם מטפל הודעות לעיבוד התראות.

## התראות התקדמות ותסריטים

חלק זה מסביר את מושג התראות ההתקדמות ב-MCP, מדוע הן חשובות, וכיצד ליישמן באמצעות Streamable HTTP. תמצא גם משימה מעשית לחיזוק ההבנה.

התראות התקדמות הן הודעות בזמן אמת שנשלחות מהשרת ללקוח במהלך פעולות ארוכות. במקום להמתין לסיום התהליך כולו, השרת מעדכן את הלקוח על הסטטוס הנוכחי. זה משפר שקיפות, חוויית משתמש ומקל על ניפוי שגיאות.

**דוגמה:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### למה להשתמש בהתראות התקדמות?

התראות התקדמות חיוניות מכמה סיבות:

- **חוויית משתמש טובה יותר:** המשתמשים רואים עדכונים תוך כדי התקדמות העבודה, לא רק בסוף.
- **משוב בזמן אמת:** הלקוחות יכולים להציג פסי התקדמות או לוגים, מה שהופך את האפליקציה לרספונסיבית.
- **ניפוי שגיאות ומעקב קל יותר:** מפתחים ומשתמשים יכולים לראות איפה תהליך עשוי להיות איטי או תקוע.

### כיצד ליישם התראות התקדמות

כך תוכל ליישם התראות התקדמות ב-MCP:

- **בשרת:** השתמש ב-`ctx.info()` או `ctx.log()` לשליחת התראות ככל שכל פריט מעובד. זה שולח הודעה ללקוח לפני שהתוצאה הראשית מוכנה.
- **בלקוח:** מימש מטפל הודעות שמאזין ומציג התראות כשהן מגיעות. מטפל זה מבדיל בין התראות לתוצאה הסופית.

**דוגמת שרת:**

## Python

```python
@mcp.tool(description="A tool that sends progress notifications")
async def process_files(message: str, ctx: Context) -> TextContent:
    for i in range(1, 11):
        await ctx.info(f"Processing document {i}/10")
    await ctx.info("Processing complete!")
    return TextContent(type="text", text=f"Done: {message}")
```


**דוגמת לקוח:**

### Python

```python
async def message_handler(message):
    if isinstance(message, types.ServerNotification):
        print("NOTIFICATION:", message)
    else:
        print("SERVER MESSAGE:", message)
```


## שיקולי אבטחה

בעת יישום שרתי MCP עם מנגנוני העברה מבוססי HTTP, האבטחה הופכת לנושא מרכזי שדורש תשומת לב קפדנית לווקטורי התקפה שונים ומנגנוני הגנה.

### סקירה כללית

אבטחה היא קריטית כאשר חושפים שרתי MCP דרך HTTP. Streamable HTTP מציג משטחי התקפה חדשים ודורש קונפיגורציה זהירה.

### נקודות מפתח
- **אימות כותרת Origin**: תמיד אמת את כותרת `Origin` כדי למנוע התקפות DNS rebinding.
- **קשירת localhost**: לפיתוח מקומי, קשר את השרת ל-`localhost` כדי למנוע חשיפה לאינטרנט הציבורי.
- **אימות**: יישם אימות (למשל, מפתחות API, OAuth) לפריסות ייצור.
- **CORS**: קבע מדיניות Cross-Origin Resource Sharing להגבלת גישה.
- **HTTPS**: השתמש ב-HTTPS בייצור להצפנת התעבורה.

### שיטות מומלצות
- אל תסמוך על בקשות נכנסות ללא אימות.
- נהל לוגים ומעקב אחר כל הגישה והשגיאות.
- עדכן תלויות באופן שוטף לתיקון פרצות אבטחה.

### אתגרים
- איזון בין אבטחה לנוחות פיתוח
- הבטחת תאימות לסביבות לקוח שונות


## שדרוג מ-SSE ל-Streamable HTTP

ליישומים שמשתמשים כיום ב-Server-Sent Events (SSE), המעבר ל-Streamable HTTP מספק יכולות משופרות ותחזוקה טובה יותר לטווח הארוך עבור יישומי MCP שלך.
### למה לשדרג?

ישנן שתי סיבות משכנעות לשדרג מ-SSE ל-Streamable HTTP:

- Streamable HTTP מציע יכולת התרחבות טובה יותר, תאימות רחבה יותר ותמיכה עשירה יותר בהתראות מאשר SSE.
- זהו אמצעי התקשורת המומלץ עבור יישומי MCP חדשים.

### שלבי ההגירה

כך תוכלו להגר מ-SSE ל-Streamable HTTP ביישומי MCP שלכם:

- **עדכון קוד השרת** לשימוש ב-`transport="streamable-http"` ב-`mcp.run()`.
- **עדכון קוד הלקוח** לשימוש ב-`streamablehttp_client` במקום לקוח SSE.
- **מימוש מטפל הודעות** בלקוח לעיבוד ההתראות.
- **בדיקת תאימות** עם כלים וזרימות עבודה קיימות.

### שמירת תאימות

מומלץ לשמור על תאימות עם לקוחות SSE קיימים במהלך תהליך ההגירה. הנה כמה אסטרטגיות:

- ניתן לתמוך גם ב-SSE וגם ב-Streamable HTTP על ידי הפעלת שני אמצעי התקשורת בנקודות קצה שונות.
- להגר בהדרגה את הלקוחות לאמצעי התקשורת החדש.

### אתגרים

יש לוודא טיפול באתגרים הבאים במהלך ההגירה:

- עדכון כל הלקוחות
- טיפול בהבדלים באספקת ההתראות

## שיקולי אבטחה

אבטחה צריכה להיות בראש סדר העדיפויות בעת יישום כל שרת, במיוחד כשמשתמשים באמצעי תקשורת מבוססי HTTP כמו Streamable HTTP ב-MCP.

בעת יישום שרתי MCP עם אמצעי תקשורת מבוססי HTTP, האבטחה הופכת לנושא מרכזי שדורש תשומת לב קפדנית לווקטורי התקפה שונים ולמנגנוני הגנה.

### סקירה כללית

אבטחה היא קריטית כאשר חושפים שרתי MCP דרך HTTP. Streamable HTTP מציג משטחי התקפה חדשים ודורש תצורה זהירה.

הנה כמה שיקולי אבטחה מרכזיים:

- **אימות כותרת Origin**: תמיד לאמת את כותרת ה-Origin כדי למנוע התקפות DNS rebinding.
- **קשירת localhost**: לפיתוח מקומי, לקשור את השרתים ל-localhost כדי למנוע חשיפה לאינטרנט הציבורי.
- **אימות**: ליישם אימות (למשל, מפתחות API, OAuth) לפריסות ייצור.
- **CORS**: להגדיר מדיניות שיתוף משאבים בין מקורות (CORS) להגבלת גישה.
- **HTTPS**: להשתמש ב-HTTPS בייצור להצפנת התעבורה.

### שיטות עבודה מומלצות

בנוסף, הנה כמה שיטות עבודה מומלצות ליישום אבטחה בשרת הזרמת MCP שלכם:

- לעולם לא לסמוך על בקשות נכנסות ללא אימות.
- לתעד ולנטר את כל הגישות והשגיאות.
- לעדכן באופן שוטף את התלויות לתיקון פרצות אבטחה.

### אתגרים

תתמודדו עם כמה אתגרים בעת יישום אבטחה בשרתי הזרמת MCP:

- איזון בין אבטחה לנוחות הפיתוח
- הבטחת תאימות עם סביבות לקוח שונות

### משימה: בנו אפליקציית MCP זרימה משלכם

**תרחיש:**
בנו שרת ולקוח MCP כאשר השרת מעבד רשימת פריטים (למשל, קבצים או מסמכים) ושולח התראה עבור כל פריט שעובד. הלקוח יציג כל התראה כשהיא מתקבלת.

**שלבים:**

1. מימוש כלי שרת שמעבד רשימה ושולח התראות עבור כל פריט.
2. מימוש לקוח עם מטפל הודעות להצגת ההתראות בזמן אמת.
3. בדקו את היישום שלכם על ידי הרצת השרת והלקוח וצפייה בהתראות.

[Solution](./solution/README.md)

## קריאה נוספת ומה הלאה?

כדי להמשיך במסע שלכם עם הזרמת MCP ולהרחיב את הידע, סעיף זה מספק משאבים נוספים והמלצות להמשך לבניית יישומים מתקדמים יותר.

### קריאה נוספת

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### מה הלאה?

- נסו לבנות כלים מתקדמים יותר ל-MCP שמשתמשים בזרימה לניתוח בזמן אמת, צ’אט או עריכה שיתופית.
- חקרו שילוב של הזרמת MCP עם מסגרות frontend (React, Vue וכו') לעדכוני ממשק חיים.
- הבא: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.