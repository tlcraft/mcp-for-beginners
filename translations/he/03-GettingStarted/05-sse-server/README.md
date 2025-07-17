<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6b1152afb5d4cb9a4175044694fd02ca",
  "translation_date": "2025-07-17T07:29:34+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "he"
}
-->
# שרת SSE

SSE (Server Sent Events) הוא תקן לשידור מידע מהשרת ללקוח בזמן אמת, המאפשר לשרתים לדחוף עדכונים בזמן אמת ללקוחות דרך HTTP. זה שימושי במיוחד לאפליקציות שדורשות עדכונים חיים, כמו אפליקציות צ'אט, התראות או זרמי נתונים בזמן אמת. בנוסף, השרת שלך יכול לשמש מספר לקוחות בו זמנית מכיוון שהוא פועל על שרת שניתן להריץ אותו במקום כלשהו בענן, למשל.

## סקירה כללית

השיעור הזה עוסק בבניית וצריכת שרתי SSE.

## מטרות הלמידה

בסיום השיעור תוכל:

- לבנות שרת SSE.
- לבצע דיבוג לשרת SSE באמצעות Inspector.
- לצרוך שרת SSE באמצעות Visual Studio Code.

## SSE, איך זה עובד

SSE הוא אחד משני סוגי ההעברה הנתמכים. כבר ראית את הראשון stdio בשיעורים קודמים. ההבדל הוא:

- ב-SSE עליך לטפל בשני דברים; חיבור והודעות.
- מכיוון שזה שרת שיכול לפעול בכל מקום, עליך לשקף זאת באופן העבודה עם כלים כמו Inspector ו-Visual Studio Code. כלומר, במקום להצביע איך להפעיל את השרת, אתה מצביע על נקודת הקצה שבה ניתן להקים חיבור. ראה דוגמת קוד למטה:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
    const transport = new SSEServerTransport('/messages', res);
    transports[transport.sessionId] = transport;
    res.on("close", () => {
        delete transports[transport.sessionId];
    });
    await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
    const sessionId = req.query.sessionId as string;
    const transport = transports[sessionId];
    if (transport) {
        await transport.handlePostMessage(req, res);
    } else {
        res.status(400).send('No transport found for sessionId');
    }
});
```

בקוד שלמעלה:

- `/sse` מוגדר כנתיב. כאשר מתקבלת בקשה לנתיב זה, נוצרת מופע חדש של ההעברה והשרת *מתחבר* באמצעות ההעברה הזו.
- `/messages` הוא הנתיב המטפל בהודעות נכנסות.

### Python

```python
mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)

```

בקוד שלמעלה:

- יצרנו מופע של שרת ASGI (בעזרת Starlette ספציפית) והתקנו את הנתיב ברירת המחדל `/`.

  מה שקורה מאחורי הקלעים הוא שהנתיבים `/sse` ו-`/messages` מוגדרים לטיפול בחיבורים ובהודעות בהתאמה. שאר האפליקציה, כמו הוספת תכונות וכלים, מתבצעת כמו בשרתי stdio.

### .NET    

```csharp
    var builder = WebApplication.CreateBuilder(args);
    builder.Services
        .AddMcpServer()
        .WithTools<Tools>();


    builder.Services.AddHttpClient();

    var app = builder.Build();

    app.MapMcp();
    ```

    יש שתי שיטות שעוזרות לנו לעבור משרת ווב לשרת ווב התומך ב-SSE והן:

    - `AddMcpServer`, שיטה שמוסיפה יכולות.
    - `MapMcp`, שמוסיפה נתיבים כמו `/SSE` ו-`/messages`.

עכשיו כשאנחנו יודעים קצת יותר על SSE, בואו נבנה שרת SSE.

## תרגיל: יצירת שרת SSE

כדי ליצור את השרת שלנו, עלינו לזכור שני דברים:

- עלינו להשתמש בשרת ווב כדי לחשוף נקודות קצה לחיבור ולהודעות.
- לבנות את השרת כמו שאנחנו רגילים עם כלים, משאבים והנחיות כשעבדנו עם stdio.

### -1- יצירת מופע שרת

כדי ליצור את השרת, נשתמש באותם סוגים כמו ב-stdio. עם זאת, עבור ההעברה, נבחר ב-SSE.

### TypeScript

```typescript
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

const server = new McpServer({
  name: "example-server",
  version: "1.0.0"
});

const app = express();

const transports: {[sessionId: string]: SSEServerTransport} = {};
```

בקוד שלמעלה:

- יצרנו מופע שרת.
- הגדרנו אפליקציה באמצעות מסגרת הווב express.
- יצרנו משתנה transports שבו נשמור חיבורים נכנסים.

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")
```

בקוד שלמעלה:

- ייבאנו את הספריות שנצטרך, כולל Starlette (מסגרת ASGI).
- יצרנו מופע שרת MCP בשם `mcp`.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();


builder.Services.AddHttpClient();

var app = builder.Build();

// TODO: add routes 
```

בשלב זה:

- יצרנו אפליקציית ווב.
- הוספנו תמיכה בתכונות MCP דרך `AddMcpServer`.

בואו נוסיף את הנתיבים הדרושים.

### -2- הוספת נתיבים

נוסיף נתיבים שמטפלים בחיבור ובהודעות נכנסות:

### TypeScript

```typescript
app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport('/messages', res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send('No transport found for sessionId');
  }
});

app.listen(3001);
```

בקוד שלמעלה הגדרנו:

- נתיב `/sse` שיוצר מופע של העברה מסוג SSE ומבצע קריאה ל-`connect` על שרת MCP.
- נתיב `/messages` שמטפל בהודעות נכנסות.

### Python

```python
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

בקוד שלמעלה:

- יצרנו מופע אפליקציית ASGI באמצעות מסגרת Starlette. כחלק מזה העברנו לנתיבים את `mcp.sse_app()`. זה מוביל להתקנת נתיבים `/sse` ו-`/messages` על מופע האפליקציה.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapMcp();
```

הוספנו שורת קוד אחת בסוף `add.MapMcp()` שמשמעותה שיש לנו עכשיו נתיבים `/SSE` ו-`/messages`.

נעבור להוספת יכולות לשרת.

### -3- הוספת יכולות לשרת

כעת כשיש לנו את כל ההגדרות הספציפיות ל-SSE, נוסיף לשרת יכולות כמו כלים, הנחיות ומשאבים.

### TypeScript

```typescript
server.tool("random-joke", "A joke returned by the chuck norris api", {},
  async () => {
    const response = await fetch("https://api.chucknorris.io/jokes/random");
    const data = await response.json();

    return {
      content: [
        {
          type: "text",
          text: data.value
        }
      ]
    };
  }
);
```

כך ניתן להוסיף כלי לדוגמה. הכלי הזה יוצר כלי בשם "random-joke" שקורא ל-API של Chuck Norris ומחזיר תגובת JSON.

### Python

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b
```

כעת לשרת שלך יש כלי אחד.

### TypeScript

```typescript
// server-sse.ts
import { Request, Response } from "express";
import express from "express";
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { SSEServerTransport } from "@modelcontextprotocol/sdk/server/sse.js";

// Create an MCP server
const server = new McpServer({
  name: "example-server",
  version: "1.0.0",
});

const app = express();

const transports: { [sessionId: string]: SSEServerTransport } = {};

app.get("/sse", async (_: Request, res: Response) => {
  const transport = new SSEServerTransport("/messages", res);
  transports[transport.sessionId] = transport;
  res.on("close", () => {
    delete transports[transport.sessionId];
  });
  await server.connect(transport);
});

app.post("/messages", async (req: Request, res: Response) => {
  const sessionId = req.query.sessionId as string;
  const transport = transports[sessionId];
  if (transport) {
    await transport.handlePostMessage(req, res);
  } else {
    res.status(400).send("No transport found for sessionId");
  }
});

server.tool("random-joke", "A joke returned by the chuck norris api", {}, async () => {
  const response = await fetch("https://api.chucknorris.io/jokes/random");
  const data = await response.json();

  return {
    content: [
      {
        type: "text",
        text: data.value,
      },
    ],
  };
});

app.listen(3001);
```

### Python

```python
from starlette.applications import Starlette
from starlette.routing import Mount, Host
from mcp.server.fastmcp import FastMCP


mcp = FastMCP("My App")

@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

# Mount the SSE server to the existing ASGI server
app = Starlette(
    routes=[
        Mount('/', app=mcp.sse_app()),
    ]
)
```

### .NET

1. ניצור קודם כל כמה כלים, לשם כך ניצור קובץ *Tools.cs* עם התוכן הבא:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

  namespace server;

  [McpServerToolType]
  public sealed class Tools
  {

      public Tools()
      {
      
      }

      [McpServerTool, Description("Add two numbers together.")]
      public async Task<string> AddNumbers(
          [Description("The first number")] int a,
          [Description("The second number")] int b)
      {
          return (a + b).ToString();
      }

  }
  ```

  כאן הוספנו את הדברים הבאים:

  - יצרנו מחלקה `Tools` עם הדקורטור `McpServerToolType`.
  - הגדרנו כלי `AddNumbers` על ידי קישוט המתודה עם `McpServerTool`. בנוסף סיפקנו פרמטרים ומימוש.

1. נשתמש במחלקת `Tools` שיצרנו:

  ```csharp
  var builder = WebApplication.CreateBuilder(args);
  builder.Services
      .AddMcpServer()
      .WithTools<Tools>();


  builder.Services.AddHttpClient();

  var app = builder.Build();

  app.MapMcp();
  ```

  הוספנו קריאה ל-`WithTools` שמציינת את `Tools` כמחלקה שמכילה את הכלים. זהו, אנחנו מוכנים.

מעולה, יש לנו שרת שמשתמש ב-SSE, בואו ננסה אותו.

## תרגיל: דיבוג שרת SSE עם Inspector

Inspector הוא כלי מצוין שראינו בשיעור קודם [יצירת השרת הראשון שלך](/03-GettingStarted/01-first-server/README.md). בואו נראה אם נוכל להשתמש ב-Inspector גם כאן:

### -1- הפעלת ה-Inspector

כדי להפעיל את ה-Inspector, קודם כל חייב להיות שרת SSE פועל, אז נעשה זאת עכשיו:

1. הפעל את השרת

    ### TypeScript

    ```sh
    tsx && node ./build/server-sse.ts
    ```

    ### Python

    ```sh
    uvicorn server:app
    ```

    שים לב שאנחנו משתמשים בקובץ ההרצה `uvicorn` שהותקן כשהרצנו `pip install "mcp[cli]"`. הקלדת `server:app` משמעותה שאנחנו מנסים להריץ את הקובץ `server.py` שבו יש מופע Starlette בשם `app`.

    ### .NET

    ```sh
    dotnet run
    ```

    זה אמור להפעיל את השרת. כדי לתקשר איתו תצטרך טרמינל חדש.

1. הפעל את ה-Inspector

    > ![NOTE]
    > הפעל זאת בחלון טרמינל נפרד מזה שבו השרת פועל. שים לב, יש להתאים את הפקודה למטה לכתובת ה-URL שבה השרת שלך פועל.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    הפעלת ה-Inspector דומה בכל הסביבות. שים לב שבמקום להעביר נתיב לשרת ופקודה להפעלתו, מעבירים את כתובת ה-URL שבה השרת פועל ומציינים גם את הנתיב `/sse`.

### -2- ניסיון הכלי

התחבר לשרת על ידי בחירת SSE ברשימת הבחירה ומלא את שדה ה-URL שבו השרת שלך פועל, למשל http:localhost:4321/sse. עכשיו לחץ על כפתור "Connect". כמו קודם, בחר ברשימת הכלים, בחר כלי וספק ערכי קלט. אמור להופיע תוצאה כמו בתמונה למטה:

![שרת SSE פועל ב-Inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.he.png)

מעולה, אתה יכול לעבוד עם ה-Inspector, בוא נראה איך לעבוד עם Visual Studio Code.

## משימה

נסה לבנות את השרת שלך עם יכולות נוספות. ראה [את העמוד הזה](https://api.chucknorris.io/) כדי, למשל, להוסיף כלי שקורא ל-API. אתה מחליט איך השרת ייראה. בהצלחה :)

## פתרון

[פתרון](./solution/README.md) הנה פתרון אפשרי עם קוד עובד.

## נקודות מפתח

הנקודות החשובות מפרק זה הן:

- SSE הוא סוג ההעברה השני הנתמך לצד stdio.
- כדי לתמוך ב-SSE, עליך לנהל חיבורים והודעות נכנסות באמצעות מסגרת ווב.
- ניתן להשתמש גם ב-Inspector וגם ב-Visual Studio Code לצריכת שרת SSE, בדיוק כמו בשרתי stdio. שים לב שיש הבדלים קטנים בין stdio ל-SSE. ב-SSE יש להפעיל את השרת בנפרד ואז להפעיל את כלי ה-Inspector. בנוסף, בכלי ה-Inspector יש לציין את כתובת ה-URL.

## דוגמאות

- [מחשבון Java](../samples/java/calculator/README.md)
- [מחשבון .Net](../../../../03-GettingStarted/samples/csharp)
- [מחשבון JavaScript](../samples/javascript/README.md)
- [מחשבון TypeScript](../samples/typescript/README.md)
- [מחשבון Python](../../../../03-GettingStarted/samples/python)

## משאבים נוספים

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## מה הלאה

- הבא: [HTTP Streaming עם MCP (Streamable HTTP)](../06-http-streaming/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.