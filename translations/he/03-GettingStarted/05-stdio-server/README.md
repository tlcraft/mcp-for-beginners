<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:38:18+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "he"
}
-->
# שרת MCP עם stdio Transport

> **⚠️ עדכון חשוב**: החל ממפרט MCP בתאריך 2025-06-18, מנגנון ה-SSE (Server-Sent Events) העצמאי **הוצא משימוש** והוחלף ב-"Streamable HTTP" transport. מפרט MCP הנוכחי מגדיר שני מנגנוני תעבורה עיקריים:
> 1. **stdio** - קלט/פלט סטנדרטי (מומלץ לשרתים מקומיים)
> 2. **Streamable HTTP** - לשרתים מרוחקים שעשויים להשתמש ב-SSE באופן פנימי
>
> השיעור הזה עודכן להתמקד ב-**stdio transport**, שהוא הגישה המומלצת לרוב יישומי שרת MCP.

מנגנון stdio מאפשר לשרתים של MCP לתקשר עם לקוחות דרך זרמי קלט ופלט סטנדרטיים. זהו מנגנון התעבורה הנפוץ והמומלץ ביותר במפרט MCP הנוכחי, המספק דרך פשוטה ויעילה לבנות שרתי MCP שניתן לשלב בקלות עם יישומי לקוח שונים.

## סקירה כללית

שיעור זה מכסה כיצד לבנות ולצרוך שרתי MCP באמצעות stdio transport.

## מטרות למידה

בסיום השיעור, תוכלו:

- לבנות שרת MCP באמצעות stdio transport.
- לנפות שגיאות בשרת MCP באמצעות ה-Inspector.
- לצרוך שרת MCP באמצעות Visual Studio Code.
- להבין את מנגנוני התעבורה הנוכחיים של MCP ולמה stdio מומלץ.

## stdio Transport - איך זה עובד

מנגנון stdio הוא אחד משני סוגי התעבורה הנתמכים במפרט MCP הנוכחי (2025-06-18). כך הוא עובד:

- **תקשורת פשוטה**: השרת קורא הודעות JSON-RPC מקלט סטנדרטי (`stdin`) ושולח הודעות לפלט סטנדרטי (`stdout`).
- **מבוסס תהליך**: הלקוח מפעיל את שרת MCP כתהליך משנה.
- **פורמט הודעות**: ההודעות הן בקשות, התראות או תגובות JSON-RPC נפרדות, המופרדות באמצעות שורות חדשות.
- **לוגים**: השרת רשאי לכתוב מחרוזות UTF-8 לשגיאה סטנדרטית (`stderr`) לצורך לוגים.

### דרישות עיקריות:
- ההודעות חייבות להיות מופרדות באמצעות שורות חדשות ואסור להכיל שורות חדשות מוטמעות.
- השרת אסור שיכתוב ל-`stdout` שום דבר שאינו הודעת MCP תקפה.
- הלקוח אסור שיכתוב ל-`stdin` של השרת שום דבר שאינו הודעת MCP תקפה.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

בקוד הקודם:

- אנו מייבאים את המחלקה `Server` ואת `StdioServerTransport` מ-SDK של MCP.
- אנו יוצרים מופע שרת עם תצורה ויכולות בסיסיות.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

בקוד הקודם אנו:

- יוצרים מופע שרת באמצעות SDK של MCP.
- מגדירים כלים באמצעות דקורטורים.
- משתמשים ב-context manager של stdio_server לניהול התעבורה.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

ההבדל המרכזי מ-SSE הוא ששרתים עם stdio:

- אינם דורשים הגדרת שרת אינטרנט או נקודות קצה HTTP.
- מופעלים כתהליכי משנה על ידי הלקוח.
- מתקשרים דרך זרמי stdin/stdout.
- פשוטים יותר ליישום ולניפוי שגיאות.

## תרגיל: יצירת שרת stdio

כדי ליצור את השרת שלנו, עלינו לזכור שני דברים:

- עלינו להשתמש בשרת אינטרנט כדי לחשוף נקודות קצה לחיבור ולהודעות.

## מעבדה: יצירת שרת MCP stdio פשוט

במעבדה זו, ניצור שרת MCP פשוט באמצעות stdio transport המומלץ. שרת זה יחשוף כלים שלקוחות יכולים לקרוא באמצעות פרוטוקול Model Context.

### דרישות מקדימות

- Python 3.8 או גרסה מאוחרת יותר.
- MCP Python SDK: `pip install mcp`.
- הבנה בסיסית של תכנות אסינכרוני.

בואו נתחיל ביצירת שרת MCP stdio הראשון שלנו:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## הבדלים מרכזיים מהגישה המיושנת של SSE

**Stdio Transport (הסטנדרט הנוכחי):**
- מודל תהליך משנה פשוט - הלקוח מפעיל את השרת כתהליך משנה.
- תקשורת דרך stdin/stdout באמצעות הודעות JSON-RPC.
- אין צורך בהגדרת שרת HTTP.
- ביצועים ואבטחה טובים יותר.
- ניפוי שגיאות ופיתוח קלים יותר.

**SSE Transport (הוצא משימוש החל מ-MCP 2025-06-18):**
- דרש שרת HTTP עם נקודות קצה SSE.
- הגדרה מורכבת יותר עם תשתית שרת אינטרנט.
- שיקולי אבטחה נוספים לנקודות קצה HTTP.
- הוחלף ב-Streamable HTTP לתרחישים מבוססי אינטרנט.

### יצירת שרת עם stdio transport

כדי ליצור שרת stdio, עלינו:

1. **לייבא את הספריות הנדרשות** - אנו זקוקים לרכיבי שרת MCP ול-stdio transport.
2. **ליצור מופע שרת** - להגדיר את השרת עם יכולותיו.
3. **להגדיר כלים** - להוסיף את הפונקציונליות שברצוננו לחשוף.
4. **להגדיר את התעבורה** - להגדיר תקשורת stdio.
5. **להפעיל את השרת** - להפעיל את השרת ולנהל הודעות.

בואו נבנה זאת שלב אחר שלב:

### שלב 1: יצירת שרת stdio בסיסי

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### שלב 2: הוספת כלים נוספים

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### שלב 3: הפעלת השרת

שמרו את הקוד כ-`server.py` והפעילו אותו משורת הפקודה:

```bash
python server.py
```

השרת יתחיל וימתין לקלט מ-stdin. הוא מתקשר באמצעות הודעות JSON-RPC דרך stdio transport.

### שלב 4: בדיקה עם ה-Inspector

ניתן לבדוק את השרת שלכם באמצעות MCP Inspector:

1. התקינו את ה-Inspector: `npx @modelcontextprotocol/inspector`.
2. הפעילו את ה-Inspector והפנו אותו לשרת שלכם.
3. בדקו את הכלים שיצרתם.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// Add tools
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Get a personalized greeting",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Name of the person to greet",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `Hello, ${request.params.arguments?.name}! Welcome to MCP stdio server.`,
        },
      ],
    };
  } else {
    throw new Error(`Unknown tool: ${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("Get a personalized greeting")]
    public string GetGreeting(string name)
    {
        return $"Hello, {name}! Welcome to MCP stdio server.";
    }

    [Description("Calculate the sum of two numbers")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. בואו ניצור כמה כלים תחילה, לשם כך ניצור קובץ *Tools.cs* עם התוכן הבא:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **פתחו את ממשק האינטרנט**: ה-Inspector יפתח חלון דפדפן המציג את יכולות השרת שלכם.

3. **בדקו את הכלים**: 
   - נסו את הכלי `get_greeting` עם שמות שונים.
   - בדקו את הכלי `calculate_sum` עם מספרים שונים.
   - קראו לכלי `get_server_info` כדי לראות מידע על השרת.

4. **עקבו אחר התקשורת**: ה-Inspector מציג את הודעות JSON-RPC המוחלפות בין הלקוח לשרת.

### מה אתם אמורים לראות

כאשר השרת שלכם מתחיל כראוי, אתם אמורים לראות:
- יכולות שרת המופיעות ב-Inspector.
- כלים זמינים לבדיקה.
- חילופי הודעות JSON-RPC מוצלחים.
- תגובות כלים מוצגות בממשק.

### בעיות נפוצות ופתרונות

**השרת לא מתחיל:**
- בדקו שכל התלויות מותקנות: `pip install mcp`.
- וודאו את תחביר Python והזחה.
- חפשו הודעות שגיאה בקונסולה.

**כלים לא מופיעים:**
- וודאו שדקורטורים `@server.tool()` קיימים.
- בדקו שפונקציות הכלים מוגדרות לפני `main()`.
- וודאו שהשרת מוגדר כראוי.

**בעיות חיבור:**
- וודאו שהשרת משתמש ב-stdio transport כראוי.
- בדקו שאין תהליכים אחרים שמפריעים.
- וודאו את תחביר הפקודה של ה-Inspector.

## משימה

נסו להרחיב את השרת שלכם עם יכולות נוספות. ראו [עמוד זה](https://api.chucknorris.io/) כדי, למשל, להוסיף כלי שקורא ל-API. אתם מחליטים איך השרת ייראה. תהנו :)

## פתרון

[פתרון](./solution/README.md) הנה פתרון אפשרי עם קוד עובד.

## נקודות מפתח

הנקודות המרכזיות מהפרק הזה הן:

- stdio transport הוא מנגנון התעבורה המומלץ לשרתים מקומיים של MCP.
- stdio transport מאפשר תקשורת חלקה בין שרתי MCP ללקוחות באמצעות זרמי קלט ופלט סטנדרטיים.
- ניתן להשתמש גם ב-Inspector וגם ב-Visual Studio Code לצרוך שרתי stdio ישירות, מה שמקל על ניפוי שגיאות ואינטגרציה.

## דוגמאות 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## משאבים נוספים

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## מה הלאה

## צעדים הבאים

עכשיו כשאתם יודעים איך לבנות שרתי MCP עם stdio transport, תוכלו לחקור נושאים מתקדמים יותר:

- **הבא**: [HTTP Streaming עם MCP (Streamable HTTP)](../06-http-streaming/README.md) - למדו על מנגנון התעבורה האחר הנתמך לשרתים מרוחקים.
- **מתקדם**: [שיטות אבטחה של MCP](../../02-Security/README.md) - יישמו אבטחה בשרתי MCP שלכם.
- **לייצור**: [אסטרטגיות פריסה](../09-deployment/README.md) - פרסו את השרתים שלכם לשימוש בייצור.

## משאבים נוספים

- [מפרט MCP 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - מפרט רשמי.
- [תיעוד SDK של MCP](https://github.com/modelcontextprotocol/sdk) - הפניות ל-SDK לכל השפות.
- [דוגמאות קהילתיות](../../06-CommunityContributions/README.md) - דוגמאות שרת נוספות מהקהילה.

---

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור סמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי על ידי אדם. איננו נושאים באחריות לאי הבנות או לפרשנויות שגויות הנובעות משימוש בתרגום זה.