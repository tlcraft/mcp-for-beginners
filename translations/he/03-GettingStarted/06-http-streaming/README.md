<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1015443af8119fb019c152bca90fb293",
  "translation_date": "2025-06-17T22:19:21+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "he"
}
-->
# HTTPS סטרימינג עם Model Context Protocol (MCP)

פרק זה מספק מדריך מקיף ליישום סטרימינג מאובטח, מדרגי ובזמן אמת עם Model Context Protocol (MCP) באמצעות HTTPS. הוא מכסה את המוטיבציה לסטרימינג, מנגנוני ההעברה הזמינים, כיצד לממש HTTP סטרימבילי ב-MCP, המלצות אבטחה, מעבר מ-SSE והנחיות מעשיות לבניית אפליקציות סטרימינג ב-MCP משלך.

## מנגנוני העברה וסטרימינג ב-MCP

חלק זה בוחן את מנגנוני ההעברה השונים הזמינים ב-MCP ואת תפקידם בהפעלת יכולות סטרימינג לתקשורת בזמן אמת בין לקוחות לשרתים.

### מהו מנגנון העברה?

מנגנון העברה מגדיר כיצד הנתונים מוחלפים בין הלקוח לשרת. MCP תומך במספר סוגי העברה כדי להתאים לסביבות ודרישות שונות:

- **stdio**: קלט/פלט סטנדרטי, מתאים לכלים מקומיים ומבוססי שורת פקודה. פשוט אך לא מתאים לאינטרנט או לענן.
- **SSE (Server-Sent Events)**: מאפשר לשרתים לדחוף עדכונים בזמן אמת ללקוחות דרך HTTP. טוב לממשקי רשת, אך מוגבל בסקלאביליות וגמישות.
- **Streamable HTTP**: מנגנון העברה מודרני מבוסס HTTP, תומך בהתראות וסקלאביליות משופרת. מומלץ לרוב תרחישי ייצור וענן.

### טבלת השוואה

הסתכלו בטבלת ההשוואה הבאה להבנת ההבדלים בין מנגנוני ההעברה:

| העברה            | עדכוני זמן אמת | סטרימינג | סקלאביליות | מקרה שימוש             |
|------------------|----------------|-----------|-------------|------------------------|
| stdio            | לא             | לא        | נמוכה       | כלים מקומיים בשורת פקודה |
| SSE              | כן             | כן        | בינונית    | רשת, עדכוני זמן אמת    |
| Streamable HTTP  | כן             | כן        | גבוהה      | ענן, לקוחות מרובים     |

> **Tip:** הבחירה במנגנון ההעברה משפיעה על ביצועים, סקלאביליות וחוויית המשתמש. **Streamable HTTP** מומלץ לאפליקציות מודרניות, מדרגיות ומוכנות לענן.

שימו לב למנגנוני ההעברה stdio ו-SSE שהוצגו בפרקים הקודמים ואיך Streamable HTTP הוא המנגנון הנדון בפרק זה.

## סטרימינג: מושגים ומוטיבציה

הבנת המושגים הבסיסיים והמוטיבציה מאחורי סטרימינג חיונית ליישום מערכות תקשורת בזמן אמת יעילות.

**סטרימינג** הוא טכניקה בתכנות רשת המאפשרת לשלוח ולקבל נתונים בחלקים קטנים, ניתנים לניהול או כסדרת אירועים, במקום להמתין לתגובה מלאה. זה שימושי במיוחד עבור:

- קבצים או מערכי נתונים גדולים.
- עדכוני זמן אמת (כגון צ'אט, פסי התקדמות).
- חישובים ארוכי טווח בהם רוצים לשמור על עדכון המשתמש.

הנה מה שחשוב לדעת על סטרימינג ברמה גבוהה:

- הנתונים מועברים בהדרגה, לא בבת אחת.
- הלקוח יכול לעבד את הנתונים כשהם מגיעים.
- מפחית את תחושת ההשהיה ומשפר את חוויית המשתמש.

### למה להשתמש בסטרימינג?

הסיבות לשימוש בסטרימינג הן:

- המשתמשים מקבלים משוב מידי, לא רק בסוף התהליך.
- מאפשר אפליקציות בזמן אמת וממשקי משתמש תגובתיים.
- ניצול יעיל יותר של משאבי רשת ומחשוב.

### דוגמה פשוטה: שרת ולקוח HTTP סטרימינג

הנה דוגמה פשוטה לאופן בו ניתן לממש סטרימינג:

<details>
<summary>Python</summary>

**שרת (Python, שימוש ב-FastAPI ו-StreamingResponse):**
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

**לקוח (Python, שימוש ב-requests):**
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

דוגמה זו ממחישה שרת ששולח סדרת הודעות ללקוח כשהן זמינות, במקום להמתין שכל ההודעות יהיו מוכנות.

**איך זה עובד:**
- השרת משחרר כל הודעה כשהיא מוכנה.
- הלקוח מקבל ומדפיס כל חלק כשהוא מגיע.

**דרישות:**
- השרת חייב להשתמש בתגובה סטרימינג (למשל, `StreamingResponse` in FastAPI).
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

There are some things we recommend when it comes to choosing between implementing classical streaming (as an endpoint we showed you above using `/stream`) במקום לבחור סטרימינג דרך MCP.

- **לצרכי סטרימינג פשוטים:** סטרימינג HTTP קלאסי פשוט יותר ליישום ומספיק לצרכים בסיסיים.

- **לאפליקציות מורכבות ואינטראקטיביות:** סטרימינג ב-MCP מספק גישה מובנית יותר עם מטא-דאטה עשירה והפרדה בין התראות לתוצאות סופיות.

- **לאפליקציות AI:** מערכת ההתראות של MCP שימושית במיוחד למשימות AI ארוכות טווח שבהן רוצים לשמור על המשתמשים מעודכנים בהתקדמות.

## סטרימינג ב-MCP

טוב, ראיתם המלצות והשוואות עד כה בין סטרימינג קלאסי לסטרימינג ב-MCP. עכשיו נפרט בדיוק איך ניתן לנצל סטרימינג ב-MCP.

הבנת האופן בו סטרימינג פועל במסגרת MCP חיונית לבניית אפליקציות תגובתיות שמספקות משוב בזמן אמת למשתמשים במהלך פעולות ארוכות.

ב-MCP, סטרימינג אינו מתייחס לשליחת תגובה עיקרית בחלקים, אלא לשליחת **התראות** ללקוח בזמן שהכלי מעבד בקשה. התראות אלו יכולות לכלול עדכוני התקדמות, לוגים או אירועים אחרים.

### איך זה עובד

התוצאה העיקרית עדיין נשלחת בתגובה אחת. עם זאת, ניתן לשלוח התראות כהודעות נפרדות במהלך העיבוד וכך לעדכן את הלקוח בזמן אמת. הלקוח חייב להיות מסוגל לטפל ולהציג התראות אלו.

## מהי התראה?

אמרנו "התראה", מה זה אומר בהקשר של MCP?

התראה היא הודעה שנשלחת מהשרת ללקוח כדי לדווח על התקדמות, סטטוס או אירועים אחרים במהלך פעולה ארוכת טווח. התראות משפרות את השקיפות וחוויית המשתמש.

לדוגמה, לקוח אמור לשלוח התראה ברגע שנוצר החיבור הראשוני עם השרת.

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
> בהתאם ל-SDK בו משתמשים, לוגינג יכול להיות מופעל כברירת מחדל, או שתצטרכו להפעיל אותו במפורש בקונפיגורציית השרת.

קיימים סוגים שונים של התראות:

| רמה       | תיאור                        | דוגמת מקרה שימוש              |
|-----------|------------------------------|------------------------------|
| debug     | מידע מפורט לדיבאגינג          | נקודות כניסה/יציאה של פונקציות |
| info      | הודעות מידע כלליות           | עדכוני התקדמות בפעולה        |
| notice    | אירועים רגילים אך משמעותיים | שינויים בהגדרות              |
| warning   | תנאי אזהרה                  | שימוש בתכונה מיושנת          |
| error     | תנאי שגיאה                  | כשלונות בפעולה              |
| critical  | תנאי קריטי                  | כשל במרכיב מערכת            |
| alert     | יש לנקוט פעולה מיידית        | זיהוי שיבוש בנתונים         |
| emergency | המערכת אינה שמישה          | כשל מערכת מלא               |

## יישום התראות ב-MCP

כדי ליישם התראות ב-MCP, יש להגדיר הן את צד השרת והן את צד הלקוח לטיפול בעדכונים בזמן אמת. זה מאפשר לאפליקציה שלך לספק משוב מידי למשתמשים במהלך פעולות ארוכות.

### צד השרת: שליחת התראות

נתחיל מצד השרת. ב-MCP, מגדירים כלים שיכולים לשלוח התראות תוך כדי עיבוד בקשות. השרת משתמש באובייקט הקונטקסט (בדרך כלל `ctx`) לשליחת הודעות ללקוח.

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

בדוגמה הקודמת, `process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` הוא מנגנון ההעברה:

```python
mcp.run(transport="streamable-http")
```

</details>

### צד הלקוח: קבלת התראות

הלקוח חייב לממש מטפל הודעות לעיבוד והצגת התראות כשהן מגיעות.

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

בקוד הקודם, `message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` מראה כיצד הלקוח מממש מטפל הודעות לעיבוד התראות.

## התראות התקדמות ותרחישים

חלק זה מסביר את מושג התראות ההתקדמות ב-MCP, מדוע הן חשובות, וכיצד ליישם אותן באמצעות Streamable HTTP. תמצאו גם משימה מעשית לחיזוק ההבנה.

התראות התקדמות הן הודעות בזמן אמת שנשלחות מהשרת ללקוח במהלך פעולות ארוכות. במקום להמתין לסיום התהליך כולו, השרת מעדכן את הלקוח לגבי הסטטוס הנוכחי. זה משפר שקיפות, חוויית משתמש ומקל על דיבאגינג.

**דוגמה:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### למה להשתמש בהתראות התקדמות?

התראות התקדמות חיוניות מכמה סיבות:

- **שיפור חוויית המשתמש:** המשתמשים רואים עדכונים תוך כדי התקדמות העבודה, לא רק בסופה.
- **משוב בזמן אמת:** הלקוחות יכולים להציג פסי התקדמות או לוגים, מה שהופך את האפליקציה לתגובתית.
- **קלות בדיבאג ומעקב:** מפתחים ומשתמשים יכולים לראות היכן התהליך איטי או תקוע.

### איך לממש התראות התקדמות

כך ניתן לממש התראות התקדמות ב-MCP:

- **בשרת:** השתמש ב-`ctx.info()` or `ctx.log()` כדי לשלוח התראות ככל שכל פריט מעובד. זה שולח הודעה ללקוח לפני שהתוצאה העיקרית מוכנה.
- **בלקוח:** מימש מטפל הודעות שמאזין ומציג התראות כשהן מגיעות. המטפל מבדיל בין התראות לתוצאה הסופית.

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

כאשר מיישמים שרתי MCP עם מנגנוני העברה מבוססי HTTP, אבטחה הופכת לנושא מרכזי שדורש תשומת לב זהירה למגוון וקטורי התקפה ומנגנוני הגנה.

### סקירה כללית

אבטחה קריטית בעת חשיפת שרתי MCP דרך HTTP. Streamable HTTP מציג משטחי התקפה חדשים ודורש קונפיגורציה מדוקדקת.

### נקודות מפתח
- **אימות כותרת Origin**: תמיד לאמת את `Origin` כדי למנוע התקפות CSRF.
- **שימוש ב-HTTPS**: חובה להגן על התקשורת.
- **יישום מטפל הודעות** בצד הלקוח לעיבוד התראות.
- **בדיקות תאימות** עם כלים וזרימות עבודה קיימות.

### שמירת תאימות

מומלץ לשמור על תאימות עם לקוחות SSE קיימים במהלך המעבר. הנה כמה אסטרטגיות:

- ניתן לתמוך בשני המנגנונים SSE ו-Streamable HTTP על ידי הפעלת שניהם בנקודות קצה שונות.
- להמיר לקוחות בהדרגה למנגנון ההעברה החדש.

### אתגרים

יש לוודא התמודדות עם האתגרים הבאים במהלך המעבר:

- עדכון כל הלקוחות.
- טיפול בהבדלים באספקת התראות.

### משימה: בנו אפליקציית סטרימינג MCP משלכם

**תרחיש:**
בנו שרת ולקוח MCP כאשר השרת מעבד רשימת פריטים (למשל קבצים או מסמכים) ושולח התראה עבור כל פריט שעובד. הלקוח יציג כל התראה כשהיא מגיעה.

**שלבים:**

1. מימשו כלי שרת שמעבד רשימה ושולח התראות עבור כל פריט.
2. מימשו לקוח עם מטפל הודעות להצגת התראות בזמן אמת.
3. בדקו את היישום על ידי הרצת השרת והלקוח וצפייה בהתראות.

[Solution](./solution/README.md)

## קריאה נוספת ומה הלאה?

כדי להמשיך את המסע שלכם עם סטרימינג ב-MCP ולהרחיב את הידע, חלק זה מספק משאבים נוספים והמלצות לשלב הבא בבניית אפליקציות מתקדמות יותר.

### קריאה נוספת

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### מה הלאה?

- נסו לבנות כלים מתקדמים יותר ב-MCP המשתמשים בסטרימינג לאנליטיקה בזמן אמת, צ'אט או עריכה שיתופית.
- חקרו אינטגרציה של סטרימינג ב-MCP עם מסגרות פרונטאנד (React, Vue וכו') לעדכוני UI חיים.
- הבא: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. איננו אחראים לכל אי הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.