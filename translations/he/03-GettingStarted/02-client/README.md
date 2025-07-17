<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8da8a0fd44d58fab5979d0f2914a1f37",
  "translation_date": "2025-07-17T09:06:35+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "he"
}
-->
# יצירת לקוח

לקוחות הם אפליקציות מותאמות אישית או סקריפטים שמתקשרים ישירות עם שרת MCP כדי לבקש משאבים, כלים והנחיות. בניגוד לשימוש בכלי המפקח, שמספק ממשק גרפי לאינטראקציה עם השרת, כתיבת לקוח משלך מאפשרת אינטראקציות תכנותיות ואוטומטיות. זה מאפשר למפתחים לשלב את יכולות ה-MCP בתוך זרימות העבודה שלהם, לאוטומט משימות ולבנות פתרונות מותאמים לצרכים ספציפיים.

## סקירה כללית

השיעור הזה מציג את מושג הלקוחות בתוך מערכת Model Context Protocol (MCP). תלמד כיצד לכתוב לקוח משלך ולחבר אותו לשרת MCP.

## מטרות הלמידה

בסיום השיעור תוכל:

- להבין מה לקוח יכול לעשות.
- לכתוב לקוח משלך.
- להתחבר ולבדוק את הלקוח עם שרת MCP כדי לוודא שהשרת פועל כמצופה.

## מה נדרש לכתיבת לקוח?

כדי לכתוב לקוח, תצטרך לבצע את הפעולות הבאות:

- **ייבא את הספריות הנכונות**. תשתמש באותה ספריה כמו קודם, רק במבנים שונים.
- **אתחל לקוח**. זה יכלול יצירת מופע של לקוח וחיבורו לשיטת התקשורת שנבחרה.
- **החלט אילו משאבים לרשום**. לשרת MCP שלך יש משאבים, כלים והנחיות, עליך להחליט אילו מהם להציג.
- **שלב את הלקוח באפליקציית מארח**. ברגע שתדע את יכולות השרת, עליך לשלב את זה באפליקציית המארח כך שאם משתמש מקליד הנחיה או פקודה אחרת, תתבצע הפונקציה המתאימה בשרת.

כעת, כשאנחנו מבינים ברמה גבוהה מה עומדים לעשות, בוא נבחן דוגמה.

### דוגמה ללקוח

בוא נבחן את דוגמת הלקוח הבאה:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

בקוד שלמעלה:

- ייבאנו את הספריות
- יצרנו מופע של לקוח וחיברנו אותו באמצעות stdio כפרוטוקול תקשורת.
- רשמנו הנחיות, משאבים וכלים והפעלנו את כולם.

וזהו, לקוח שיכול לתקשר עם שרת MCP.

בואו נקדיש זמן בחלק התרגיל הבא ונפרק כל קטע קוד ונבין מה קורה.

## תרגיל: כתיבת לקוח

כפי שנאמר, נקדיש זמן להסבר הקוד, ואתם מוזמנים לכתוב את הקוד במקביל אם תרצו.

### -1- ייבוא הספריות

נייבא את הספריות הדרושות, נצטרך הפניות ללקוח ולפרוטוקול התקשורת שבחרנו, stdio. stdio הוא פרוטוקול לדברים שמיועדים לרוץ במחשב המקומי שלך. SSE הוא פרוטוקול תקשורת נוסף שנציג בפרקים הבאים, אבל כרגע נמשיך עם stdio.

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

לג'אווה, תיצור לקוח שמתחבר לשרת MCP מהתרגיל הקודם. תוך שימוש במבנה פרויקט Java Spring Boot מהקובץ [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java), צור מחלקה חדשה בשם `SDKClient` בתיקייה `src/main/java/com/microsoft/mcp/sample/client/` והוסף את הייבוא הבא:

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

נעבור לאתחול.

### -2- אתחול הלקוח והפרוטוקול

נצטרך ליצור מופע של הפרוטוקול ושל הלקוח שלנו:

### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

בקוד שלמעלה:

- יצרנו מופע של פרוטוקול stdio. שים לב איך הוא מגדיר פקודה וארגומנטים לאיתור והפעלת השרת, כי זה משהו שנצטרך לעשות כשניצור את הלקוח.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- אתחלנו לקוח על ידי מתן שם וגרסה.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- חיברנו את הלקוח לפרוטוקול שנבחר.

    ```typescript
    await client.connect(transport);
    ```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)

async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()

          

if __name__ == "__main__":
    import asyncio

    asyncio.run(run())
```

בקוד שלמעלה:

- ייבאנו את הספריות הנדרשות
- אתחלנו אובייקט פרמטרים לשרת כדי שנוכל להריץ את השרת ולחבר אליו את הלקוח.
- הגדרנו פונקציה `run` שקוראת ל-`stdio_client` שמתחילה סשן לקוח.
- יצרנו נקודת כניסה שבה אנו מפעילים את `run` דרך `asyncio.run`.

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

בקוד שלמעלה:

- ייבאנו את הספריות הנדרשות.
- יצרנו פרוטוקול stdio ואת הלקוח `mcpClient`. הלקוח ישמש אותנו לרשום ולהפעיל פונקציות בשרת MCP.

שים לב, ב-"Arguments" אפשר להצביע על קובץ *.csproj* או על הקובץ ההרצה.

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

בקוד שלמעלה:

- יצרנו פונקציית main שמגדירה פרוטוקול SSE שמצביע ל-`http://localhost:8080` שבו שרת MCP ירוץ.
- יצרנו מחלקת לקוח שמקבלת את הפרוטוקול בפרמטר הבנאי.
- בפונקציית `run` יצרנו לקוח MCP סינכרוני באמצעות הפרוטוקול ואתחול החיבור.
- השתמשנו בפרוטוקול SSE (Server-Sent Events) שמתאים לתקשורת HTTP עם שרתי MCP מבוססי Java Spring Boot.

### -3- רשימת הפיצ'רים של השרת

כעת יש לנו לקוח שיכול להתחבר אם התוכנית תרוץ. עם זאת, הוא לא מציג את הפיצ'רים שלו, אז נעשה זאת כעת:

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
```

כאן אנו מציגים את המשאבים הזמינים, `list_resources()` ואת הכלים, `list_tools` ומדפיסים אותם.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

מעל זו דוגמה כיצד ניתן לרשום את הכלים בשרת. עבור כל כלי, מדפיסים את שמו.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

בקוד שלמעלה:

- קראנו ל-`listTools()` כדי לקבל את כל הכלים הזמינים מהשרת MCP.
- השתמשנו ב-`ping()` כדי לוודא שהחיבור לשרת תקין.
- האובייקט `ListToolsResult` מכיל מידע על כל הכלים כולל שמות, תיאורים וסכימות קלט.

מעולה, עכשיו תפסנו את כל הפיצ'רים. השאלה היא מתי משתמשים בהם? הלקוח הזה פשוט יחסית, כלומר נצטרך לקרוא במפורש לפיצ'רים כשנרצה אותם. בפרק הבא ניצור לקוח מתקדם יותר שיש לו גישה למודל שפה גדול (LLM) משלו. בינתיים, נראה איך מפעילים את הפיצ'רים בשרת:

### -4- הפעלת פיצ'רים

כדי להפעיל פיצ'רים, עלינו לוודא שאנו מציינים את הארגומנטים הנכונים ובמקרים מסוימים את שם הפיצ'ר שאנו מנסים להפעיל.

### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

בקוד שלמעלה:

- קוראים למשאב, קוראים למשאב על ידי קריאה ל-`readResource()` עם הפרמטר `uri`. כך זה נראה כנראה בצד השרת:

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    הערך שלנו `uri` הוא `file://example.txt` שמתאים ל-`file://{name}` בשרת. `example.txt` יוקצה ל-`name`.

- קוראים לכלי, קוראים לו על ידי ציון `name` ו-`arguments` כך:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- מקבלים הנחיה, כדי לקבל הנחיה, קוראים ל-`getPrompt()` עם `name` ו-`arguments`. קוד השרת נראה כך:

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    ולכן קוד הלקוח שלך ייראה כך כדי להתאים למה שהוגדר בשרת:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

בקוד שלמעלה:

- קראנו למשאב בשם `greeting` באמצעות `read_resource`.
- הפעלנו כלי בשם `add` באמצעות `call_tool`.

### .NET

1. נוסיף קוד לקריאה לכלי:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. כדי להדפיס את התוצאה, הנה קוד לטיפול בזה:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

בקוד שלמעלה:

- קראנו למספר כלים של מחשבון באמצעות המתודה `callTool()` עם אובייקטים מסוג `CallToolRequest`.
- כל קריאה לכלי מציינת את שם הכלי ומפה (`Map`) של ארגומנטים הנדרשים לכלי.
- כלים בשרת מצפים לשמות פרמטרים ספציפיים (כמו "a", "b" לפעולות מתמטיות).
- התוצאות מוחזרות כאובייקטים מסוג `CallToolResult` שמכילים את התגובה מהשרת.

### -5- הרצת הלקוח

כדי להריץ את הלקוח, הקלד את הפקודה הבאה בטרמינל:

### TypeScript

הוסף את הערך הבא לקטע "scripts" בקובץ *package.json* שלך:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

הפעל את הלקוח עם הפקודה הבאה:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

ראשית, ודא ששרת MCP שלך רץ ב-`http://localhost:8080`. לאחר מכן הרץ את הלקוח:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

כחלופה, תוכל להריץ את פרויקט הלקוח המלא שמסופק בתיקיית הפתרון `03-GettingStarted\02-client\solution\java`:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## משימה

במשימה זו, תשתמש במה שלמדת ביצירת לקוח, אך תיצור לקוח משלך.

הנה שרת שתוכל להשתמש בו שעליך לקרוא אליו דרך קוד הלקוח שלך, נסה להוסיף פיצ'רים נוספים לשרת כדי להפוך אותו למעניין יותר.

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

עיין בפרויקט זה כדי לראות כיצד ניתן [להוסיף הנחיות ומשאבים](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs).

כמו כן, בדוק קישור זה לגבי אופן הפעלת [הנחיות ומשאבים](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/).

## פתרון

**תיקיית הפתרון** מכילה מימושים מלאים של לקוחות מוכנים להפעלה שמדגימים את כל המושגים שנלמדו במדריך זה. כל פתרון כולל קוד לקוח ושרת מאורגן בפרויקטים נפרדים ועצמאיים.

### 📁 מבנה הפתרון

תיקיית הפתרון מאורגנת לפי שפת תכנות:

```
solution/
├── typescript/          # TypeScript client with npm/Node.js setup
│   ├── package.json     # Dependencies and scripts
│   ├── tsconfig.json    # TypeScript configuration
│   └── src/             # Source code
├── java/                # Java Spring Boot client project
│   ├── pom.xml          # Maven configuration
│   ├── src/             # Java source files
│   └── mvnw            # Maven wrapper
├── python/              # Python client implementation
│   ├── client.py        # Main client code
│   ├── server.py        # Compatible server
│   └── README.md        # Python-specific instructions
├── dotnet/              # .NET client project
│   ├── dotnet.csproj    # Project configuration
│   ├── Program.cs       # Main client code
│   └── dotnet.sln       # Solution file
└── server/              # Additional .NET server implementation
    ├── Program.cs       # Server code
    └── server.csproj    # Server project file
```

### 🚀 מה כל פתרון כולל

כל פתרון ספציפי לשפה מספק:

- **מימוש לקוח מלא** עם כל הפיצ'רים מהמדריך
- **מבנה פרויקט עובד** עם תלותים והגדרות נכונות
- **סקריפטים לבנייה והרצה** להתקנה והפעלה קלה
- **קובץ README מפורט** עם הוראות ספציפיות לשפה
- **טיפול בשגיאות** ודוגמאות לעיבוד תוצאות

### 📖 שימוש בפתרונות

1. **נווט לתיקיית השפה המועדפת עליך**:
   ```bash
   cd solution/typescript/    # For TypeScript
   cd solution/java/          # For Java
   cd solution/python/        # For Python
   cd solution/dotnet/        # For .NET
   ```

2. **עקוב אחרי הוראות ה-README** בכל תיקייה עבור:
   - התקנת תלותים
   - בניית הפרויקט
   - הרצת הלקוח

3. **פלט לדוגמה** שתראה:
   ```text
   Prompt: Please review this code: console.log("hello");
   Resource template: file
   Tool result: { content: [ { type: 'text', text: '9' } ] }
   ```

לתיעוד מלא והוראות שלב-אחר-שלב, ראה: **[📖 תיעוד הפתרונות](./solution/README.md)**

## 🎯 דוגמאות מלאות

סיפקנו מימושים מלאים של לקוחות עובדים לכל שפות התכנות שנלמדו במדריך זה. דוגמאות אלו מדגימות את כל הפונקציונליות שתוארה למעלה וניתן להשתמש בהן כהפניות או נקודות התחלה לפרויקטים שלך.

### דוגמאות מלאות זמינות

| שפה | קובץ | תיאור |
|----------|------|-------------|
| **Java** | [`client_example_java.java`](../../../../03-GettingStarted/02-client/client_example_java.java) | לקוח Java מלא המשתמש בפרוטוקול SSE עם טיפול שגיאות מקיף |
| **C#** | [`client_example_csharp.cs`](../../../../03-GettingStarted/02-client/client_example_csharp.cs) | לקוח C# מלא המשתמש בפרוטוקול stdio עם הפעלת שרת אוטומטית |
| **TypeScript** | [`client_example_typescript.ts`](../../../../03-GettingStarted/02-client/client_example_typescript.ts) | לקוח TypeScript מלא עם תמיכה מלאה בפרוטוקול MCP |
| **Python** | [`client_example_python.py`](../../../../03-GettingStarted/02-client/client_example_python.py) | לקוח Python מלא המשתמש בתבניות async/await |

כל דוגמה מלאה כוללת:

- ✅ **הקמת חיבור** וטיפול בשגיאות
- ✅ **גילוי שרת** (כלים, משאבים, הנחיות במידת הצורך)
- ✅ **פעולות מחשבון** (חיבור, חיסור, כפל, חילוק, עזרה)
- ✅ **עיבוד תוצאות** ופלט מעוצב
- ✅ **טיפול שגיאות מקיף**
- ✅ **קוד נקי ומתועד** עם הסברים שלב-אחר-שלב

### התחלה עם דוגמאות מלאות

1. **בחר את שפת התכנות המועדפת עליך** מהטבלה למעלה
2. **עיין בקובץ הדוגמה המלא** כדי להבין את המימוש המלא
3. **הרץ את הדוגמה** בהתאם להוראות ב-[`complete_examples.md`](./complete_examples.md)
4. **שנה והרחב** את הדוגמה לצרכים הספציפיים שלך

לתיעוד מפורט על הרצה והתאמה של דוגמאות אלו, ראה: **[📖 תיעוד דוגמאות מלאות](./complete_examples.md)**

### 💡 תיקיית פתרון לעומת דוגמאות מלאות

| **תיקיית פתרון** | **דוגמאות מלאות** |
|--------------------|--------------------- |
| מבנה פרויקט מלא עם קבצי בנייה | מימושים בקובץ יחיד |
| מוכן להפעלה עם תלותים | דוגמאות קוד ממוקדות |
| הגדרה בסגנון ייצור | הפניה חינוכית |
| כלי פיתוח ספציפיים לשפה | השוואה בין שפות |
שתי הגישות הן בעלות ערך - השתמשו בתיקיית **solution** לפרויקטים שלמים ובדוגמאות ה**complete** ללמידה ולהתייחסות.

## נקודות מפתח

נקודות המפתח בפרק זה לגבי הלקוחות הן:

- ניתן להשתמש בהם גם לגילוי וגם לקריאה של פונקציות בשרת.
- יכולים להפעיל שרת בזמן שהם מתחילים לפעול (כמו בפרק זה), אך לקוחות יכולים להתחבר גם לשרתים שכבר פועלים.
- זו דרך מצוינת לבדוק את יכולות השרת לצד חלופות כמו ה-Inspector כפי שתואר בפרק הקודם.

## משאבים נוספים

- [Building clients in MCP](https://modelcontextprotocol.io/quickstart/client)

## דוגמאות

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## מה הלאה

- הבא: [Creating a client with an LLM](../03-llm-client/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. יש להתייחס למסמך המקורי בשפתו המקורית כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.