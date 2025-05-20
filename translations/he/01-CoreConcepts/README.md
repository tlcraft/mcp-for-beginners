<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T17:36:52+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "he"
}
-->
# 📖 מושגי יסוד ב-MCP: שליטה בפרוטוקול הקשר של המודל לשילוב AI

פרוטוקול הקשר של המודל (MCP) הוא מסגרת חזקה ומאוחדת שמייעלת את התקשורת בין מודלים לשוניים גדולים (LLMs) לכלים חיצוניים, אפליקציות ומקורות נתונים. מדריך זה, המותאם לקידום במנועי חיפוש, ילווה אותך דרך מושגי היסוד של MCP, ויבטיח שתבין את ארכיטקטורת הלקוח-שרת, הרכיבים המרכזיים, מנגנוני התקשורת, ושיטות היישום הטובות ביותר.

## סקירה כללית

השיעור הזה בוחן את הארכיטקטורה הבסיסית והרכיבים שמרכיבים את מערכת הפרוטוקול של MCP. תלמד על ארכיטקטורת הלקוח-שרת, הרכיבים המרכזיים, ומנגנוני התקשורת שמפעילים את האינטראקציות ב-MCP.

## 👩‍🎓 יעדי למידה מרכזיים

בסוף השיעור תוכל:

- להבין את ארכיטקטורת הלקוח-שרת של MCP.
- לזהות את התפקידים והאחריות של Hosts, Clients, ו-Servers.
- לנתח את התכונות המרכזיות שהופכות את MCP לשכבת אינטגרציה גמישה.
- ללמוד כיצד המידע זורם במערכת ה-MCP.
- לקבל תובנות מעשיות באמצעות דוגמאות קוד ב-.NET, Java, Python ו-JavaScript.

## 🔎 ארכיטקטורת MCP: מבט מעמיק יותר

מערכת ה-MCP בנויה על מודל לקוח-שרת. מבנה מודולרי זה מאפשר לאפליקציות AI לתקשר עם כלים, מאגרי נתונים, APIs ומשאבים קונטקסטואליים בצורה יעילה. נפרק את הארכיטקטורה הזו לרכיבים המרכזיים שלה.

### 1. Hosts

בפרוטוקול הקשר של המודל (MCP), ה-Hosts ממלאים תפקיד מרכזי כממשק הראשי דרכו המשתמשים מתקשרים עם הפרוטוקול. Hosts הם אפליקציות או סביבות שמאתחלים חיבורים עם שרתי MCP כדי לגשת לנתונים, כלים, והנחיות. דוגמאות ל-Hosts כוללות סביבות פיתוח משולבות (IDEs) כמו Visual Studio Code, כלים מבוססי AI כמו Claude Desktop, או סוכנים מותאמים למשימות ספציפיות.

**Hosts** הם אפליקציות LLM שמאתחלות חיבורים. הם:

- מבצעים או מתקשרים עם מודלים של AI ליצירת תגובות.
- מאתחלים חיבורים עם שרתי MCP.
- מנהלים את זרימת השיחה וממשק המשתמש.
- שומרים על בקרת הרשאות ואבטחה.
- מטפלים באישור המשתמש לשיתוף נתונים והרצת כלים.

### 2. Clients

Clients הם רכיבים חיוניים שמאפשרים את האינטראקציה בין Hosts לשרתי MCP. הם פועלים כמתווכים, ומאפשרים ל-Hosts לגשת ולנצל את הפונקציות שמספקים שרתי MCP. הם ממלאים תפקיד מרכזי בהבטחת תקשורת חלקה וחילופי מידע יעילים במערכת ה-MCP.

**Clients** הם מחברים בתוך אפליקציית ה-Host. הם:

- שולחים בקשות לשרתים עם הנחיות/פירוטים.
- מנהלים משא ומתן על יכולות עם השרתים.
- מנהלים בקשות להפעלת כלים שמגיעות מהמודלים.
- מעבדים ומציגים תגובות למשתמשים.

### 3. Servers

Servers אחראים לטיפול בבקשות מלקוחות MCP ולספק תגובות מתאימות. הם מנהלים פעולות שונות כגון אחזור נתונים, הפעלת כלים, ויצירת הנחיות. השרתים מבטיחים שהתקשורת בין הלקוחות ל-Hosts תהיה יעילה ואמינה, ושומרים על תקינות תהליך האינטראקציה.

**Servers** הם שירותים שמספקים הקשר ויכולות. הם:

- רושמים תכונות זמינות (משאבים, הנחיות, כלים).
- מקבלים ומבצעים קריאות כלים מהלקוח.
- מספקים מידע קונטקסטואלי לשיפור תגובות המודל.
- מחזירים פלטים ללקוח.
- שומרים על מצב לאורך האינטראקציות לפי הצורך.

ניתן לפתח שרתים על ידי כל אחד להרחבת יכולות המודל עם פונקציונליות מיוחדת.

### 4. תכונות השרת

שרתים בפרוטוקול הקשר של המודל (MCP) מספקים אבני בניין בסיסיות שמאפשרות אינטראקציות עשירות בין לקוחות, Hosts ומודלים לשוניים. תכונות אלה נועדו לשפר את יכולות MCP על ידי הצעת הקשר מובנה, כלים והנחיות.

שרתים ב-MCP יכולים להציע את התכונות הבאות:

#### 📑 משאבים

משאבים בפרוטוקול הקשר של המודל (MCP) כוללים סוגים שונים של הקשר ונתונים שניתן להשתמש בהם על ידי משתמשים או מודלים של AI. אלו כוללים:

- **נתונים קונטקסטואליים**: מידע והקשר שמשתמשים או מודלים יכולים לנצל לקבלת החלטות וביצוע משימות.
- **מאגרי ידע ומאגרי מסמכים**: אוספים של נתונים מובנים ובלתי מובנים, כגון מאמרים, מדריכים ומחקרים, שמספקים תובנות ומידע יקר ערך.
- **קבצים ומאגרי נתונים מקומיים**: נתונים המאוחסנים באופן מקומי במכשירים או בתוך מאגרי נתונים, נגישים לעיבוד וניתוח.
- **APIs ושירותי רשת**: ממשקים ושירותים חיצוניים שמציעים נתונים ופונקציות נוספות, ומאפשרים אינטגרציה עם משאבים וכלים מקוונים שונים.

דוגמה למשאב יכולה להיות סכימת מסד נתונים או קובץ שניתן לגשת אליו כך:

```text
file://log.txt
database://schema
```

### 🤖 הנחיות

הנחיות בפרוטוקול הקשר של המודל (MCP) כוללות תבניות מוכנות מראש ודפוסי אינטראקציה שמטרתם לייעל את זרימות העבודה של המשתמש ולשפר את התקשורת. אלו כוללים:

- **הודעות ותהליכי עבודה מתבניתים**: הודעות ותהליכים מובנים מראש שמנחים את המשתמשים במשימות ואינטראקציות ספציפיות.
- **דפוסי אינטראקציה מוגדרים מראש**: רצפים סטנדרטיים של פעולות ותגובות שמאפשרים תקשורת עקבית ויעילה.
- **תבניות שיחה מיוחדות**: תבניות מותאמות אישית לסוגים מסוימים של שיחות, שמבטיחות אינטראקציות רלוונטיות ומתאימות הקשרית.

תבנית הנחיה יכולה להיראות כך:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ כלים

כלים בפרוטוקול הקשר של המודל (MCP) הם פונקציות שהמודל יכול להפעיל כדי לבצע משימות ספציפיות. כלים אלה נועדו לשפר את יכולות המודל על ידי מתן פעולות מובנות ואמינות. נקודות מפתח כוללות:

- **פונקציות שהמודל יכול להפעיל**: כלים הם פונקציות שניתן לקרוא להן לביצוע משימות שונות.
- **שם ותיאור ייחודיים**: לכל כלי יש שם מובחן ותיאור מפורט שמסביר את מטרתו ופונקציונליותו.
- **פרמטרים ופלטים**: כלים מקבלים פרמטרים ספציפיים ומחזירים פלטים מובנים, להבטחת תוצאות עקביות וניתנות לחיזוי.
- **פונקציות דיסקרטיות**: כלים מבצעים פונקציות נפרדות כמו חיפושים ברשת, חישובים, ושאילתות למסדי נתונים.

דוגמה לכלי יכולה להיראות כך:

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## תכונות לקוח

בפרוטוקול הקשר של המודל (MCP), ללקוחות יש מספר תכונות מרכזיות שמעצימות את הפונקציונליות הכוללת והאינטראקציה בפרוטוקול. אחת התכונות הבולטות היא Sampling.

### 👉 Sampling

- **התנהגויות סוכניות ביוזמת השרת**: לקוחות מאפשרים לשרתים להפעיל פעולות או התנהגויות ספציפיות באופן אוטונומי, ומשפרים את היכולות הדינמיות של המערכת.
- **אינטראקציות רקורסיביות עם LLM**: תכונה זו מאפשרת אינטראקציות חוזרות עם מודלים לשוניים גדולים (LLMs), ומאפשרת עיבוד מורכב ואיטרטיבי של משימות.
- **בקשת השלמות נוספות מהמודל**: שרתים יכולים לבקש השלמות נוספות מהמודל, להבטיח שהתגובות יהיו מקיפות ורלוונטיות הקשרית.

## זרימת מידע ב-MCP

פרוטוקול הקשר של המודל (MCP) מגדיר זרימה מובנית של מידע בין Hosts, Clients, Servers ומודלים. הבנת הזרימה הזו מסייעת להבהיר כיצד בקשות משתמש מעובדות ואיך כלים חיצוניים ונתונים משתלבים בתגובות המודל.

- **ה-Host מאתחל חיבור**  
  אפליקציית ה-Host (כגון IDE או ממשק שיחה) מקימה חיבור לשרת MCP, בדרך כלל דרך STDIO, WebSocket, או אמצעי תקשורת נתמך אחר.

- **משא ומתן על יכולות**  
  הלקוח (המוטמע ב-Host) והשרת מחליפים מידע על התכונות, הכלים, המשאבים וגרסאות הפרוטוקול שהם תומכים בהם. זה מבטיח ששני הצדדים מבינים אילו יכולות זמינות למפגש.

- **בקשת משתמש**  
  המשתמש מתקשר עם ה-Host (לדוגמה, מזין הנחיה או פקודה). ה-Host אוסף את הקלט ומעביר אותו ללקוח לעיבוד.

- **שימוש במשאב או כלי**  
  - הלקוח עשוי לבקש הקשר או משאבים נוספים מהשרת (כגון קבצים, רשומות במסד נתונים, או מאמרי מאגר ידע) כדי להעשיר את הבנת המודל.
  - אם המודל קובע שנדרש כלי (למשל לאחזר נתונים, לבצע חישוב, או לקרוא ל-API), הלקוח שולח בקשת הפעלת כלי לשרת, עם שם הכלי והפרמטרים.

- **ביצוע על ידי השרת**  
  השרת מקבל את בקשת המשאב או הכלי, מבצע את הפעולות הנדרשות (כגון הרצת פונקציה, שאילתה למסד נתונים, או אחזור קובץ), ומחזיר את התוצאות ללקוח בפורמט מובנה.

- **יצירת תגובה**  
  הלקוח משלב את תגובות השרת (נתוני משאב, פלטי כלים וכו') באינטראקציה המתמשכת עם המודל. המודל משתמש במידע זה ליצירת תגובה מקיפה ורלוונטית הקשרית.

- **הצגת תוצאה**  
  ה-Host מקבל את הפלט הסופי מהלקוח ומציג אותו למשתמש, לעיתים כולל גם את הטקסט שנוצר על ידי המודל וגם תוצאות מהפעלת כלים או חיפוש משאבים.

זרימה זו מאפשרת ל-MCP לתמוך באפליקציות AI מתקדמות, אינטראקטיביות ומודעות הקשר, על ידי חיבור חלק בין מודלים לכלים חיצוניים ומקורות נתונים.

## פרטי הפרוטוקול

MCP (Model Context Protocol) בנוי מעל [JSON-RPC 2.0](https://www.jsonrpc.org/), ומספק פורמט הודעות מאוחד, בלתי תלוי בשפה, לתקשורת בין Hosts, Clients ו-Servers. יסוד זה מאפשר אינטראקציות אמינות, מובנות, והרחבות בין פלטפורמות ושפות תכנות שונות.

### תכונות מרכזיות של הפרוטוקול

MCP מרחיב את JSON-RPC 2.0 עם קונבנציות נוספות להפעלת כלים, גישה למשאבים, וניהול הנחיות. הוא תומך בשכבות תקשורת מרובות (STDIO, WebSocket, SSE) ומאפשר תקשורת מאובטחת, ניתנת להרחבה ובלתי תלויה בשפה בין הרכיבים.

#### 🧢 פרוטוקול בסיסי

- **פורמט הודעות JSON-RPC**: כל הבקשות והתגובות משתמשות במפרט JSON-RPC 2.0, להבטחת מבנה עקבי לקריאות שיטות, פרמטרים, תוצאות וטיפול בשגיאות.
- **חיבורים עם מצב**: מפגשי MCP שומרים על מצב לאורך בקשות מרובות, תומכים בשיחות מתמשכות, הצטברות הקשר וניהול משאבים.
- **משא ומתן על יכולות**: במהלך הקמת החיבור, הלקוחות והשרתים מחליפים מידע על תכונות נתמכות, גרסאות פרוטוקול, כלים ומשאבים זמינים. זה מבטיח ששני הצדדים מבינים את יכולות הצד השני ויכולים להתאים בהתאם.

#### ➕ תוספות ושירותים נוספים

להלן כמה שירותים נוספים והרחבות פרוטוקול ש-MCP מספק לשיפור חוויית המפתח ולאפשר תרחישים מתקדמים:

- **אפשרויות תצורה**: MCP מאפשר קונפיגורציה דינמית של פרמטרי המפגש, כמו הרשאות כלים, גישה למשאבים, והגדרות מודל, המותאמות לכל אינטראקציה.
- **מעקב התקדמות**: פעולות ארוכות טווח יכולות לדווח על עדכוני התקדמות, מאפשרות ממשקי משתמש רספונסיביים וחוויית משתמש משופרת במשימות מורכבות.
- **ביטול בקשות**: לקוחות יכולים לבטל בקשות בתהליך, ומאפשרים למשתמשים להפסיק פעולות שכבר אינן נדרשות או לוקחות זמן רב מדי.
- **דיווח שגיאות**: הודעות שגיאה וקודים סטנדרטיים מסייעים באבחון בעיות, טיפול בכשלים בצורה חלקה, ומתן משוב מעשי למשתמשים ולמפתחים.
- **רישום (Logging)**: גם הלקוחות וגם השרתים יכולים להפיק לוגים מובנים לצורך ביקורת, איתור באגים, ומעקב אחרי אינטראקציות הפרוטוקול.

באמצעות תכונות אלו, MCP מבטיח תקשורת יציבה, מאובטחת וגמישה בין מודלים לשוניים לכלים חיצוניים ומקורות נתונים.

### 🔐 שיקולי אבטחה

יישומי MCP צריכים לעמוד בכמה עקרונות אבטחה מרכזיים להבטחת אינטראקציות בטוחות ואמינות:

- **הסכמה ושליטה של המשתמש**: יש לקבל הסכמה מפורשת מהמשתמש לפני גישה לנתונים או ביצוע פעולות. המשתמשים צריכים שליטה ברורה על אילו נתונים משותפים ואילו פעולות מורשות, בתמיכה בממשקי משתמש אינטואיטיביים לבחינה ואישור פעילויות.

- **פרטיות נתונים**: נתוני משתמשים צריכים להיחשף רק עם הסכמה מפורשת ולהיות מוגנים באמצעות בקרות גישה מתאימות. יישומי MCP חייבים להגן מפני העברת נתונים לא מורשית ולהבטיח פרטיות לאורך כל האינטראקציות.

- **בטיחות הכלים**: לפני הפעלת כל כלי, נדרשת הסכמה מפורשת מהמשתמש. יש לוודא שהמשתמש מבין את פונקציונליות הכלי, ושהגבלות אבטחה חזקות נאכפות כדי למנוע הפעלה לא מכוונת או לא בטוחה של הכלי.

בהקפדה על עקרונות אלה, MCP מבטיח אמון, פרטיות ובטיחות המשתמשים בכל האינטראקציות בפרוטוקול.

## דוגמאות קוד: רכיבים מרכזיים

להלן דוגמאות קוד בכמה שפות תכנות פופולריות שמדגימות כיצד ליישם רכיבי שרת MCP וכלים מרכזיים.

### דוגמת .NET: יצירת שרת MCP פשוט עם כלים

זו דוגמה מעשית בקוד .NET שמדגימה כיצד ליישם שרת MCP פשוט עם כלים מותאמים אישית. הדוגמה מציגה כיצד להגדיר ולרשום כלים, לטפל בבקשות ולחבר את השרת באמצעות פרוטוקול הקשר של המודל.

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### דוגמת Java: רכיבי שרת MCP

דוגמה זו מציגה את אותו שרת MCP ורישום כלים כמו בדוגמת .NET למעלה, אך מיושמת ב-Java.

```java
import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Weather MCP Server")
            .version("1.0.0")
            .build();
            
        // Register a weather tool
        server.registerTool(McpToolDefinition.builder("weatherTool")
            .description("Gets current weather for a location")
            .parameter("location", String.class)
            .execute((ToolExecutionContext ctx) -> {
                String location = ctx.getParameter("location", String.class);
                
                // Get weather data (simplified)
                WeatherData data = getWeatherData(location);
                
                // Return formatted response
                return ToolResponse.content(
                    String.format("Temperature: %.1f°F, Conditions: %s, Location: %s", 
                    data.getTemperature(), 
                    data.getConditions(), 
                    data.getLocation())
                );
            })
            .build());
        
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Weather MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
    
    private static WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    public WeatherData(double temperature, String conditions, String location) {
        this.temperature = temperature;
        this.conditions = conditions;
        this.location = location;
    }
    
    public double getTemperature() {
        return temperature;
    }
    
    public String getConditions() {
        return conditions;
    }
    
    public String getLocation() {
        return location;
    }
}
```

### דוגמת Python: בניית שרת MCP

בדוגמה זו מוצג כיצד לבנות שרת MCP בפייתון. מוצגים גם שני דרכים שונות ליצירת כלים.

```python
#!/usr/bin/env python3
import asyncio
from mcp.server.fastmcp import FastMCP
from mcp.server.transports.stdio import serve_stdio

# Create a FastMCP server
mcp = FastMCP(
    name="Weather MCP Server",
    version="1.0.0"
)

@mcp.tool()
def get_weather(location: str) -> dict:
    """Gets current weather for a location."""
    # This would normally call a weather API
    # Simplified for demonstration
    return {
        "temperature": 72.5,
        "conditions": "Sunny",
        "location": location
    }

# Alternative approach using a class
class WeatherTools:
    @mcp.tool()
    def forecast(self, location: str, days: int = 1) -> dict:
        """Gets weather forecast for a location for the specified number of days."""
        # This would normally call a weather API forecast endpoint
        # Simplified for demonstration
        return {
            "location": location,
            "forecast": [
                {"day": i+1, "temperature": 70 + i, "conditions": "Partly Cloudy"}
                for i in range(days)
            ]
        }

# Initialize class for its methods to be registered as tools
weather_tools = WeatherTools()

if __name__ == "__main__":
    # Start the server with stdio transport
    print("Weather MCP Server starting...")
    asyncio.run(serve_stdio(mcp))
```

### דוגמת JavaScript: יצירת שרת MCP

בדוגמה זו מוצגת יצירת שרת MCP ב-JavaScript ואיך לרשום שני כלים הקשורים למזג אוויר.

```javascript
// Using the official Model Context Protocol SDK
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod"; // For parameter validation

// Create an MCP server
const server = new McpServer({
  name: "Weather MCP Server",
  version: "1.0.0"
});

// Define a weather tool
server.tool(
  "weatherTool",
  {
    location: z.string().describe("The location to get weather for")
  },
  async ({ location }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const weatherData = await getWeatherData(location);
    
    return {
      content: [
        { 
          type: "text", 
          text: `Temperature: ${weatherData.temperature}°F, Conditions: ${weatherData.conditions}, Location: ${weatherData.location}` 
        }
      ]
    };
  }
);

// Define a forecast tool
server.tool(
  "forecastTool",
  {
    location: z.string(),
    days: z.number().default(3).describe("Number of days for forecast")
  },
  async ({ location, days }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const forecast = await getForecastData(location, days);
    
    return {
      content: [
        { 
          type: "text", 
          text: `${days}-day forecast for ${location}: ${JSON.stringify(forecast)}` 
        }
      ]
    };
  }
);

// Helper functions
async function getWeatherData(location) {
  // Simulate API call
  return {
    temperature: 72.5,
    conditions: "Sunny",
    location: location
  };
}

async function getForecastData(location, days) {
  // Simulate API call
  return Array.from({ length: days }, (_, i) => ({
    day: i + 1,
    temperature: 70 + Math.floor(Math.random() * 10),
    conditions: i % 2 === 0 ? "Sunny" : "Partly Cloudy"
  }));
}

// Connect the server using stdio transport
const transport = new StdioServerTransport();
server.connect(transport).catch(console.error);

console.log("Weather MCP Server started");
```

דוגמת JavaScript זו מדגימה כיצד ליצור לקוח MCP שמתחבר לשרת, שולח הנחיה, ומעבד את התגובה כולל קריאות לכלים

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו הוא המקור המוסמך והמהימן. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. איננו אחראים לכל אי-הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.