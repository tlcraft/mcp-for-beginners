<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "eda412c63b61335a047f39c44d1b55bc",
  "translation_date": "2025-06-13T01:47:15+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "he"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

פרק זה מספק מדריך מקיף ליישום סטרימינג מאובטח, מדרגי ובזמן אמת באמצעות Model Context Protocol (MCP) עם HTTPS. הוא כולל את המוטיבציה לסטרימינג, מנגנוני ההעברה הזמינים, כיצד ליישם HTTP סטרימינג ב-MCP, שיטות אבטחה מומלצות, מעבר מ-SSE והנחיות מעשיות לבניית אפליקציות סטרימינג ב-MCP משלך.

## מנגנוני העברה וסטרימינג ב-MCP

חלק זה בוחן את מנגנוני ההעברה השונים הזמינים ב-MCP ותפקידם בהפעלת יכולות סטרימינג לתקשורת בזמן אמת בין לקוחות לשרתים.

### מהו מנגנון העברה?

מנגנון העברה מגדיר כיצד הנתונים מוחלפים בין הלקוח לשרת. MCP תומך בסוגי העברה מרובים המתאימים לסביבות ודרישות שונות:

- **stdio**: קלט/פלט סטנדרטי, מתאים לכלים מקומיים ומבוססי CLI. פשוט אך לא מתאים לאינטרנט או ענן.
- **SSE (Server-Sent Events)**: מאפשר לשרתים לדחוף עדכונים בזמן אמת ללקוחות דרך HTTP. טוב לממשקי ווב, אך מוגבל בקנה מידה ובגמישות.
- **Streamable HTTP**: מנגנון סטרימינג מודרני מבוסס HTTP, תומך בהתראות וסקלאביליות טובה יותר. מומלץ לרוב תרחישי ייצור וענן.

### טבלת השוואה

הסתכלו בטבלת ההשוואה למטה כדי להבין את ההבדלים בין מנגנוני ההעברה הללו:

| העברה            | עדכונים בזמן אמת | סטרימינג | מדרגיות | מקרה שימוש                |
|------------------|------------------|----------|---------|---------------------------|
| stdio            | לא               | לא       | נמוך    | כלים מקומיים ב-CLI        |
| SSE              | כן               | כן       | בינוני  | ווב, עדכונים בזמן אמת    |
| Streamable HTTP  | כן               | כן       | גבוה    | ענן, לקוחות מרובים        |

> **Tip:** בחירת מנגנון העברה נכון משפיעה על ביצועים, מדרגיות וחוויית המשתמש. **Streamable HTTP** מומלץ לאפליקציות מודרניות, מדרגיות ומוכנות לענן.

שימו לב למנגנוני ההעברה stdio ו-SSE שהוצגו בפרקים הקודמים ואיך Streamable HTTP הוא המנגנון הנדון בפרק זה.

## סטרימינג: מושגים ומוטיבציה

הבנת המושגים הבסיסיים והמוטיבציה מאחורי סטרימינג חיונית ליישום מערכות תקשורת בזמן אמת יעילות.

**סטרימינג** הוא טכניקה בתכנות רשת המאפשרת לשלוח ולקבל נתונים בחתיכות קטנות וברי ניהול או כרצף אירועים, במקום להמתין לתגובה מלאה. זה שימושי במיוחד עבור:

- קבצים או מערכי נתונים גדולים.
- עדכונים בזמן אמת (לדוגמה, צ'אט, פסי התקדמות).
- חישובים ארוכי טווח בהם רוצים לעדכן את המשתמש.

הנה מה שחשוב לדעת על סטרימינג ברמה גבוהה:

- הנתונים מועברים בהדרגה, לא בבת אחת.
- הלקוח יכול לעבד את הנתונים כשהם מגיעים.
- מפחית את ההשהיה הנתפסת ומשפר את חוויית המשתמש.

### למה להשתמש בסטרימינג?

הסיבות לשימוש בסטרימינג הן:

- המשתמשים מקבלים משוב מיידי, לא רק בסיום
- מאפשר אפליקציות בזמן אמת וממשקי משתמש רספונסיביים
- שימוש יעיל יותר במשאבי רשת ומחשוב

### דוגמה פשוטה: שרת ולקוח HTTP סטרימינג

הנה דוגמה פשוטה ליישום סטרימינג:

<details>
<summary>Python</summary>

**שרת (Python, באמצעות FastAPI ו-StreamingResponse):**
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

**לקוח (Python, באמצעות requests):**
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

דוגמה זו מדגימה שרת ששולח סדרת הודעות ללקוח כשהן זמינות, במקום להמתין שכל ההודעות יהיו מוכנות.

**איך זה עובד:**
- השרת מפיק כל הודעה כשהיא מוכנה.
- הלקוח מקבל ומדפיס כל חתיכה כשהיא מגיעה.

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

- **לאפליקציות מורכבות ואינטראקטיביות:** סטרימינג ב-MCP מספק גישה מובנית יותר עם מטה-דאטה עשירה והפרדה בין התראות לתוצאות סופיות.

- **לאפליקציות AI:** מערכת ההתראות של MCP מועילה במיוחד למשימות AI ארוכות טווח שבהן רוצים לעדכן את המשתמשים בהתקדמות.

## סטרימינג ב-MCP

טוב, ראיתם כבר המלצות והשוואות בין סטרימינג קלאסי לסטרימינג ב-MCP. עכשיו ניכנס לפרטים איך בדיוק ניתן לנצל סטרימינג ב-MCP.

הבנת אופן פעולת הסטרימינג במסגרת MCP חיונית לבניית אפליקציות רספונסיביות שמספקות משוב בזמן אמת למשתמשים במהלך פעולות ארוכות.

ב-MCP, סטרימינג אינו משלוח התגובה הראשית בחתיכות, אלא שליחת **התראות** ללקוח בזמן שכלי מעבד בקשה. התראות אלו יכולות לכלול עדכוני התקדמות, לוגים או אירועים אחרים.

### איך זה עובד

התוצאה העיקרית עדיין נשלחת בתגובה אחת. עם זאת, ניתן לשלוח התראות כהודעות נפרדות במהלך העיבוד וכך לעדכן את הלקוח בזמן אמת. הלקוח חייב להיות מסוגל לטפל ולהציג את ההתראות הללו.

## מהי התראה?

אמרנו "התראה", מה משמעותה בהקשר של MCP?

התראה היא הודעה שנשלחת מהשרת ללקוח כדי ליידע על התקדמות, מצב או אירועים אחרים במהלך פעולה ארוכת טווח. התראות משפרות שקיפות וחוויית משתמש.

לדוגמה, הלקוח אמור לשלוח התראה ברגע שנוצר החיבור הראשוני עם השרת.

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

התראות שייכות לנושא ב-MCP הנקרא ["Logging"](https://modelcontextprotocol.io/specification/draft/server/utilities/logging).

כדי להפעיל לוגינג, השרת צריך לאפשר זאת כמאפיין/יכולת כך:

```json
{
  "capabilities": {
    "logging": {}
  }
}
```

> [!NOTE]
> בהתאם ל-SDK שבו משתמשים, ייתכן שלוגינג מופעל כברירת מחדל, או שתצטרכו לאפשרו במפורש בקונפיגורציית השרת.

קיימים סוגים שונים של התראות:

| רמה       | תיאור                         | דוגמת שימוש                 |
|-----------|-------------------------------|-----------------------------|
| debug     | מידע מפורט לניפוי שגיאות       | נקודות כניסה/יציאה של פונקציה |
| info      | הודעות מידע כלליות             | עדכוני התקדמות בפעולה       |
| notice    | אירועים רגילים אך חשובים       | שינויים בקונפיגורציה        |
| warning   | תנאי אזהרה                    | שימוש בתכונה מיושנת         |
| error     | תנאי שגיאה                   | כשלונות בפעולה              |
| critical  | תנאים קריטיים                | כשל רכיבי מערכת              |
| alert     | יש לנקוט פעולה מיידית          | זיהוי שחיתות בנתונים         |
| emergency | המערכת לא שמישה              | כשל מערכת מלא                |

## יישום התראות ב-MCP

כדי ליישם התראות ב-MCP, יש להגדיר גם צד שרת וגם צד לקוח לטיפול בעדכונים בזמן אמת. זה מאפשר לאפליקציה לספק משוב מיידי למשתמשים במהלך פעולות ארוכות.

### צד שרת: שליחת התראות

נתחיל מצד השרת. ב-MCP מגדירים כלים שיכולים לשלוח התראות בזמן עיבוד בקשות. השרת משתמש באובייקט הקונטקסט (בדרך כלל `ctx`) כדי לשלוח הודעות ללקוח.

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

בדוגמה הקודמת, ה-`process_files` tool sends three notifications to the client as it processes each file. The `ctx.info()` method is used to send informational messages.

</details>

Additionally, to enable notifications, ensure your server uses a streaming transport (like `streamable-http`) and your client implements a message handler to process notifications. Here's how you can set up the server to use the `streamable-http` הוא מנגנון ההעברה:

```python
mcp.run(transport="streamable-http")
```

</details>

### צד לקוח: קבלת התראות

הלקוח חייב לממש מטפל הודעות שיעבד ויציג התראות כשהן מגיעות.

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

בקוד הקודם, ה-`message_handler` function checks if the incoming message is a notification. If it is, it prints the notification; otherwise, it processes it as a regular server message. Also note how the `ClientSession` is initialized with the `message_handler` to handle incoming notifications.

</details>

To enable notifications, ensure your server uses a streaming transport (like `streamable-http` מייצג את מטפל ההודעות בלקוח שמטפל בהתראות.

## התראות התקדמות ותסריטים

חלק זה מסביר את מושג התראות ההתקדמות ב-MCP, מדוע הן חשובות וכיצד ליישמן באמצעות Streamable HTTP. תמצאו גם משימה מעשית לחיזוק ההבנה.

התראות התקדמות הן הודעות בזמן אמת שנשלחות מהשרת ללקוח במהלך פעולות ארוכות. במקום להמתין לסיום התהליך כולו, השרת מעדכן את הלקוח על המצב הנוכחי. זה משפר שקיפות, חוויית משתמש ומקל על ניפוי שגיאות.

**דוגמה:**

```text

"Processing document 1/10"
"Processing document 2/10"
...
"Processing complete!"

```

### למה להשתמש בהתראות התקדמות?

התראות התקדמות חיוניות מכמה סיבות:

- **חוויית משתמש משופרת:** המשתמשים רואים עדכונים תוך כדי התקדמות העבודה, לא רק בסיום.
- **משוב בזמן אמת:** הלקוחות יכולים להציג פסי התקדמות או לוגים, מה שמעניק תחושה של תגובה מהירה.
- **ניפוי שגיאות ומעקב קל יותר:** מפתחים ומשתמשים יכולים לראות היכן התהליך איטי או תקוע.

### איך ליישם התראות התקדמות

כך ניתן ליישם התראות התקדמות ב-MCP:

- **בשרת:** השתמש ב-`ctx.info()` or `ctx.log()` כדי לשלוח התראות כאשר כל פריט מעובד. זה שולח הודעה ללקוח לפני שהתוצאה העיקרית מוכנה.
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

בעת יישום שרתי MCP עם מנגנוני העברה מבוססי HTTP, האבטחה הופכת לקריטית ודורשת תשומת לב למספר וקטורי התקפה ומנגנוני הגנה.

### סקירה כללית

אבטחה חיונית כאשר חושפים שרתי MCP דרך HTTP. Streamable HTTP מציג נקודות תורפה חדשות ודורש קונפיגורציה זהירה.

### נקודות מפתח
- **אימות כותרת Origin**: תמיד אמתו את ה-`Origin` header to prevent DNS rebinding attacks.
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
3. **מימוש מטפל הודעות** בצד הלקוח לטיפול בהתראות.
4. **בדיקת תאימות** עם כלים וזרימות עבודה קיימות.

### שמירת תאימות

מומלץ לשמור על תאימות עם לקוחות SSE קיימים במהלך תהליך ההגירה. הנה כמה אסטרטגיות:

- ניתן לתמוך גם ב-SSE וגם ב-Streamable HTTP על ידי הפעלת שני מנגנוני ההעברה בנקודות קצה שונות.
- להגריר לקוחות בהדרגה למנגנון החדש.

### אתגרים

יש לטפל באתגרים הבאים במהלך ההגירה:

- הבטחת עדכון כל הלקוחות
- טיפול בהבדלים במשלוח ההתראות

### משימה: בנה אפליקציית סטרימינג MCP משלך

**תרחיש:**
בנה שרת ולקוח MCP שבהם השרת מעבד רשימת פריטים (למשל, קבצים או מסמכים) ושולח התראה עבור כל פריט שמעובד. הלקוח יציג כל התראה כשהיא מגיעה.

**שלבים:**

1. מימוש כלי שרת שמעבד רשימה ושולח התראות עבור כל פריט.
2. מימוש לקוח עם מטפל הודעות להצגת התראות בזמן אמת.
3. בדוק את היישום שלך על ידי הרצת השרת והלקוח וצפה בהתראות.

[Solution](./solution/README.md)

## קריאה נוספת ומה הלאה?

כדי להמשיך במסע שלך עם סטרימינג ב-MCP ולהרחיב את הידע, חלק זה מספק משאבים נוספים ושלבים מומלצים לבניית אפליקציות מתקדמות יותר.

### קריאה נוספת

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### מה הלאה?

- נסה לבנות כלים מתקדמים יותר ב-MCP שמשתמשים בסטרימינג לאנליטיקה בזמן אמת, צ'אט או עריכה שיתופית.
- חקור שילוב סטרימינג של MCP עם מסגרות frontend (React, Vue וכו') לעדכוני UI חיים.
- הבא: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפתו המקורית נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.