<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:35:48+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "he"
}
-->
# 📖 מושגי יסוד ב-MCP: שליטה בפרוטוקול הקשר למודל לשילוב בינה מלאכותית

פרוטוקול הקשר למודל (MCP) הוא מסגרת סטנדרטית וחזקה שמייעלת את התקשורת בין מודלים שפתיים גדולים (LLMs) לכלים חיצוניים, יישומים ומקורות מידע. מדריך זה, מותאם לקידום במנועי חיפוש, ילווה אותך במושגי היסוד של MCP, ויבטיח שתבין את ארכיטקטורת הלקוח-שרת, הרכיבים המרכזיים, מנגנוני התקשורת ופרקטיקות יישום מיטביות.

## סקירה כללית

השיעור הזה בוחן את הארכיטקטורה הבסיסית והרכיבים שמרכיבים את מערכת ה-MCP. תלמד על ארכיטקטורת הלקוח-שרת, הרכיבים המרכזיים ומנגנוני התקשורת שמאפשרים את האינטראקציות ב-MCP.

## 👩‍🎓 יעדי למידה מרכזיים

בסיום השיעור, תוכל:

- להבין את ארכיטקטורת הלקוח-שרת של MCP.
- לזהות תפקידים ואחריות של Hosts, Clients ו-Servers.
- לנתח את התכונות המרכזיות שהופכות את MCP לשכבת אינטגרציה גמישה.
- ללמוד כיצד המידע זורם בתוך מערכת ה-MCP.
- לקבל תובנות מעשיות דרך דוגמאות קוד ב-.NET, Java, Python ו-JavaScript.

## 🔎 ארכיטקטורת MCP: מבט מעמיק

מערכת ה-MCP בנויה על מודל לקוח-שרת. מבנה מודולרי זה מאפשר ליישומי בינה מלאכותית לתקשר ביעילות עם כלים, מאגרי נתונים, APIs ומשאבים קונטקסטואליים. נפרק את הארכיטקטורה הזו לרכיבים המרכזיים שלה.

### 1. Hosts

בפרוטוקול הקשר למודל (MCP), ה-Hosts ממלאים תפקיד מרכזי כממשק הראשי דרכו המשתמשים מתקשרים עם הפרוטוקול. Hosts הם יישומים או סביבות שמאתחלים חיבורים עם שרתי MCP כדי לגשת לנתונים, כלים והנחיות. דוגמאות ל-Hosts הן סביבות פיתוח משולבות (IDEs) כמו Visual Studio Code, כלים מבוססי בינה מלאכותית כמו Claude Desktop, או סוכנים מותאמים למשימות ספציפיות.

**Hosts** הם יישומי LLM שמאתחלים חיבורים. הם:

- מבצעים או מתקשרים עם מודלים כדי לייצר תגובות.
- מאתחלים חיבורים עם שרתי MCP.
- מנהלים את זרימת השיחה וממשק המשתמש.
- שולטים בהרשאות ומגבלות אבטחה.
- מטפלים בהסכמת המשתמש לשיתוף נתונים והפעלת כלים.

### 2. Clients

Clients הם רכיבים חיוניים שמאפשרים את האינטראקציה בין Hosts לשרתי MCP. Clients משמשים כמתווכים, ומאפשרים ל-Hosts לגשת ולהשתמש בפונקציונליות שמספקים שרתי MCP. הם ממלאים תפקיד מרכזי בהבטחת תקשורת חלקה והחלפת נתונים יעילה במסגרת ארכיטקטורת MCP.

**Clients** הם מחברים בתוך יישום ה-Host. הם:

- שולחים בקשות לשרתים עם הנחיות/פרומפטים.
- מנהלים משא ומתן על יכולות עם השרתים.
- מנהלים בקשות להפעלת כלים מהמודלים.
- מעבדים ומציגים תגובות למשתמשים.

### 3. Servers

Servers אחראים לטיפול בבקשות מלקוחות MCP ולספק תגובות מתאימות. הם מנהלים פעולות שונות כמו שליפת נתונים, הפעלת כלים ויצירת הנחיות. השרתים מבטיחים שהתקשורת בין הלקוחות ל-Hosts תהיה יעילה ואמינה, ושומרים על שלמות תהליך האינטראקציה.

**Servers** הם שירותים שמספקים הקשר ויכולות. הם:

- רושמים תכונות זמינות (משאבים, הנחיות, כלים).
- מקבלים ומבצעים קריאות לכלים מהלקוח.
- מספקים מידע קונטקסטואלי לשיפור תגובות המודל.
- מחזירים תוצאות ללקוח.
- שומרים על מצב לאורך האינטראקציות כשנדרש.

ניתן לפתח שרתים על ידי כל אחד להרחבת יכולות המודל עם פונקציונליות מיוחדת.

### 4. תכונות שרת

שרתים בפרוטוקול הקשר למודל (MCP) מספקים אבני בניין בסיסיות שמאפשרות אינטראקציות עשירות בין לקוחות, Hosts ומודלים שפתיים. תכונות אלו מיועדות להעצים את יכולות ה-MCP על ידי הצעת הקשר מובנה, כלים והנחיות.

שרתים ב-MCP יכולים להציע כל אחת מהתכונות הבאות:

#### 📑 משאבים

משאבים בפרוטוקול הקשר למודל (MCP) כוללים סוגים שונים של הקשר ונתונים שניתן להשתמש בהם על ידי משתמשים או מודלים. אלה כוללים:

- **נתונים קונטקסטואליים**: מידע והקשר שמשתמשים או מודלים יכולים להיעזר בהם לקבלת החלטות וביצוע משימות.
- **מאגרי ידע ומאגרי מסמכים**: אוספים של נתונים מובנים ולא מובנים, כגון מאמרים, מדריכים ומחקרים, שמספקים תובנות ומידע חשוב.
- **קבצים ומאגרי נתונים מקומיים**: נתונים המאוחסנים במכשירים מקומיים או במסדי נתונים, נגישים לעיבוד וניתוח.
- **APIs ושירותי רשת**: ממשקים ושירותים חיצוניים שמציעים נתונים ופונקציות נוספות, ומאפשרים אינטגרציה עם משאבים וכלים מקוונים שונים.

דוגמה למשאב יכולה להיות סכמת מסד נתונים או קובץ שניתן לגשת אליו כך:

```text
file://log.txt
database://schema
```

### 🤖 הנחיות (Prompts)

הנחיות בפרוטוקול הקשר למודל (MCP) כוללות תבניות מוגדרות מראש ודפוסי אינטראקציה שמטרתם לייעל את זרימת העבודה של המשתמשים ולשפר את התקשורת. אלה כוללים:

- **הודעות ותהליכי עבודה מתבניתים**: הודעות ותהליכים מובנים שמנחים את המשתמשים במשימות ואינטראקציות ספציפיות.
- **דפוסי אינטראקציה מוגדרים מראש**: רצפים סטנדרטיים של פעולות ותגובות שמאפשרים תקשורת עקבית ויעילה.
- **תבניות שיחה מיוחדות**: תבניות מותאמות לסוגי שיחות מסוימים, שמבטיחות אינטראקציה רלוונטית והקשרית.

תבנית הנחיה יכולה להיראות כך:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ כלים

כלים בפרוטוקול הקשר למודל (MCP) הם פונקציות שהמודל יכול להפעיל כדי לבצע משימות ספציפיות. כלים אלו נועדו להרחיב את יכולות המודל על ידי מתן פעולות מובנות ואמינות. מאפיינים מרכזיים כוללים:

- **פונקציות שהמודל יכול להפעיל**: כלים הם פונקציות ניתנות לביצוע שהמודל יכול לקרוא להן כדי לבצע משימות שונות.
- **שם ותיאור ייחודיים**: לכל כלי יש שם מובחן ותיאור מפורט שמסביר את מטרתו ופעולתו.
- **פרמטרים ופלטים**: כלים מקבלים פרמטרים מסוימים ומחזירים פלט מובנה, כדי להבטיח תוצאות עקביות וניתנות לחיזוי.
- **פונקציות מובחנות**: כלים מבצעים פעולות מובחנות כמו חיפוש באינטרנט, חישובים ושאילתות למסדי נתונים.

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

בפרוטוקול הקשר למודל (MCP), לקוחות מציעים מספר תכונות מרכזיות לשרתים, המשפרות את הפונקציונליות והאינטראקציה בפרוטוקול. אחת התכונות הבולטות היא Sampling.

### 👉 Sampling

- **התנהגויות סוכנות שמתחילות מהשרת**: לקוחות מאפשרים לשרתים להפעיל פעולות או התנהגויות ספציפיות באופן אוטונומי, מה שמעצים את היכולות הדינמיות של המערכת.
- **אינטראקציות רקורסיביות עם LLMs**: תכונה זו מאפשרת אינטראקציות רקורסיביות עם מודלים שפתיים גדולים, ומאפשרת עיבוד מורכב ואיטרטיבי של משימות.
- **בקשת השלמות נוספות מהמודל**: שרתים יכולים לבקש השלמות נוספות מהמודל, כדי להבטיח שהתגובות יהיו מקיפות ורלוונטיות להקשר.

## זרימת מידע ב-MCP

פרוטוקול הקשר למודל (MCP) מגדיר זרימה מובנית של מידע בין Hosts, Clients, Servers ומודלים. הבנת הזרימה הזו מבהירה כיצד מטופלות בקשות המשתמש ואיך כלים ונתונים חיצוניים משתלבים בתגובות המודל.

- **ה-Host מאתחל חיבור**  
  יישום ה-Host (כגון IDE או ממשק צ'אט) יוצר חיבור לשרת MCP, בדרך כלל דרך STDIO, WebSocket או אמצעי תקשורת נתמך אחר.

- **משא ומתן על יכולות**  
  הלקוח (המוטמע ב-Host) והשרת מחליפים מידע על התכונות, הכלים, המשאבים וגרסאות הפרוטוקול הנתמכות. זה מבטיח ששני הצדדים מבינים אילו יכולות זמינות למפגש.

- **בקשת משתמש**  
  המשתמש מתקשר עם ה-Host (לדוגמה, מזין פרומפט או פקודה). ה-Host אוסף את הקלט ומעביר אותו ללקוח לעיבוד.

- **שימוש במשאב או כלי**  
  - הלקוח עשוי לבקש הקשר נוסף או משאבים מהשרת (כגון קבצים, רשומות מסד נתונים או מאמרי מאגר ידע) כדי להעשיר את הבנת המודל.
  - אם המודל קובע שנדרש כלי (לדוגמה, לשליפת נתונים, ביצוע חישוב או קריאת API), הלקוח שולח בקשה להפעלת כלי לשרת, ומציין את שם הכלי והפרמטרים.

- **ביצוע בשרת**  
  השרת מקבל את בקשת המשאב או הכלי, מבצע את הפעולות הנדרשות (כגון הרצת פונקציה, שאילתת מסד נתונים או שליפת קובץ), ומחזיר את התוצאות ללקוח בפורמט מובנה.

- **יצירת תגובה**  
  הלקוח משלב את תגובות השרת (נתוני משאב, פלטי כלים וכו') באינטראקציה המתמשכת עם המודל. המודל משתמש במידע זה כדי לייצר תגובה מקיפה ורלוונטית להקשר.

- **הצגת התוצאה**  
  ה-Host מקבל את הפלט הסופי מהלקוח ומציג אותו למשתמש, לרוב כולל גם את הטקסט שנוצר על ידי המודל וגם את תוצאות הפעלת הכלים או השליפות.

זרימה זו מאפשרת ל-MCP לתמוך ביישומי בינה מלאכותית מתקדמים, אינטראקטיביים ובהקשר, על ידי חיבור חלק בין מודלים לכלים ולמקורות נתונים חיצוניים.

## פרטי פרוטוקול

MCP (Model Context Protocol) בנוי על גבי [JSON-RPC 2.0](https://www.jsonrpc.org/), ומספק פורמט הודעות סטנדרטי, בלתי תלוי בשפה, לתקשורת בין Hosts, Clients ו-Servers. בסיס זה מאפשר אינטראקציות אמינות, מובנות והרחבות בין פלטפורמות ושפות תכנות שונות.

### תכונות מרכזיות בפרוטוקול

MCP מרחיב את JSON-RPC 2.0 עם קונבנציות נוספות להפעלת כלים, גישה למשאבים וניהול הנחיות. הוא תומך בשכבות תקשורת מרובות (STDIO, WebSocket, SSE) ומאפשר תקשורת מאובטחת, ניתנת להרחבה ובלתי תלויה בשפה בין רכיבים.

#### 🧢 פרוטוקול בסיסי

- **פורמט הודעות JSON-RPC**: כל הבקשות והתגובות משתמשות במפרט JSON-RPC 2.0, המבטיח מבנה עקבי לקריאות שיטה, פרמטרים, תוצאות וטיפול בשגיאות.
- **חיבורים עם מצב**: מפגשי MCP שומרים על מצב לאורך בקשות מרובות, תומכים בשיחות מתמשכות, הצטברות הקשר וניהול משאבים.
- **משא ומתן על יכולות**: במהלך הקמת החיבור, לקוחות ושרתים מחליפים מידע על תכונות נתמכות, גרסאות פרוטוקול, כלים ומשאבים זמינים. זה מבטיח ששני הצדדים מבינים את היכולות של השני ויכולים להתאים את עצמם בהתאם.

#### ➕ כלים נוספים

להלן כמה כלים והרחבות פרוטוקול שמספק MCP לשיפור חוויית המפתח ולאפשר תרחישים מתקדמים:

- **אפשרויות קונפיגורציה**: MCP מאפשר קונפיגורציה דינמית של פרמטרי המפגש, כגון הרשאות כלים, גישה למשאבים והגדרות מודל, המותאמים לכל אינטראקציה.
- **מעקב התקדמות**: פעולות ארוכות טווח יכולות לדווח על עדכוני התקדמות, מה שמאפשר ממשקי משתמש מגיבים וחוויית משתמש משופרת במהלך משימות מורכבות.
- **ביטול בקשות**: לקוחות יכולים לבטל בקשות בתהליך, מה שמאפשר למשתמשים לקטוע פעולות שאינן נחוצות עוד או שנמשכות יותר מדי זמן.
- **דיווח שגיאות**: הודעות שגיאה וסטטוסים סטנדרטיים מסייעים באבחון בעיות, טיפול בכשלים באופן אלגנטי ומתן משוב מעשי למשתמשים ולמפתחים.
- **רישום לוגים**: גם לקוחות וגם שרתים יכולים להפיק לוגים מובנים לצורך ביקורת, איתור תקלות ומעקב אחר אינטראקציות הפרוטוקול.

באמצעות תכונות אלו, MCP מבטיח תקשורת יציבה, מאובטחת וגמישה בין מודלים שפתיים לכלים ומקורות נתונים חיצוניים.

### 🔐 שיקולי אבטחה

מימושי MCP צריכים לעמוד בכמה עקרונות אבטחה מרכזיים כדי להבטיח אינטראקציות בטוחות ואמינות:

- **הסכמת משתמש ושליטה**: המשתמשים חייבים לתת הסכמה מפורשת לפני גישה לנתונים או ביצוע פעולות. עליהם להיות בעלי שליטה ברורה על איזה מידע משותף ואילו פעולות מאושרות, נתמכות בממשקי משתמש אינטואיטיביים לסקירה ואישור פעילויות.

- **פרטיות נתונים**: נתוני המשתמש צריכים להיות חשופים רק בהסכמה מפורשת והם חייבים להיות מוגנים באמצעות בקרות גישה מתאימות. מימושי MCP חייבים למנוע שידור נתונים בלתי מורשה ולהבטיח פרטיות לאורך כל האינטראקציות.

- **בטיחות כלים**: לפני הפעלת כל כלי, נדרשת הסכמה מפורשת של המשתמש. המשתמשים צריכים להבין היטב את פונקציונליות הכלי, ויש לאכוף גבולות אבטחה מחמירים למניעת הפעלה לא מכוונת או לא בטוחה של כלים.

באמצעות עקרונות אלו, MCP מבטיח אמון, פרטיות ובטיחות המשתמשים בכל האינטראקציות בפרוטוקול.

## דוגמאות קוד: רכיבים מרכזיים

להלן דוגמאות קוד בשפות תכנות פופולריות שממחישות כיצד לממש רכיבי שרת MCP וכלים מרכזיים.

### דוגמת .NET: יצירת שרת MCP פשוט עם כלים

דוגמה מעשית בקוד .NET שמדגימה כיצד לממש שרת MCP פשוט עם כלים מותאמים. הדוגמה מציגה כיצד להגדיר ולרשום כלים, לטפל בבקשות ולחבר את השרת באמצעות פרוטוקול הקשר למודל.

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

דוגמה זו מדגימה את אותו שרת MCP ורישום כלים כמו בדוגמת .NET שלמעלה, אך מיושמת ב-Java.

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

בדוגמה זו מוצג כיצד לבנות שרת MCP ב-Python. מוצגים גם שני דרכים שונות ליצירת כלים.

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

# Instantiate the class to register its tools
weather_tools = WeatherTools()

# Start the server using stdio transport
if __name__ == "__main__":
    asyncio.run(serve_stdio(mcp))
```

### דוגמת JavaScript: יצירת שרת MCP

דוגמה זו מציגה יצירת שרת MCP ב-JavaScript וכיצד לרשום שני כלים הקשורים למזג אוויר.

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

דוגמת JavaScript זו מראה כיצד ליצור לקוח MCP שמתחבר לשרת, שולח פרומפט ומעבד את התגובה כולל כל קריאות הכלים שבוצעו.

## אבטחה ואישור הרשאות

MCP כולל מספר מושגים ומ

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). בעוד שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו הוא המקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.