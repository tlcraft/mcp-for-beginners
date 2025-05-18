<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:24:55+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "he"
}
-->
# 📖 מושגי יסוד ב-MCP: שליטה בפרוטוקול הקשר למודל לשילוב AI

פרוטוקול הקשר למודל (MCP) הוא מסגרת סטנדרטית ועוצמתית המייעלת את התקשורת בין מודלים לשוניים גדולים (LLMs) לבין כלים חיצוניים, אפליקציות ומקורות נתונים. מדריך מותאם SEO זה יוביל אותך דרך המושגים המרכזיים של MCP, ויבטיח שתבין את ארכיטקטורת הלקוח-שרת שלו, הרכיבים החשובים, מנגנוני התקשורת והפרקטיקות הטובות ליישום.

## סקירה כללית

בשיעור זה נחקור את הארכיטקטורה הבסיסית והרכיבים שמרכיבים את מערכת ה-MCP. תלמד על ארכיטקטורת הלקוח-שרת, הרכיבים המרכזיים ומנגנוני התקשורת שמפעילים את האינטראקציות ב-MCP.

## 👩‍🎓 יעדי למידה מרכזיים

בסוף השיעור תוכל:

- להבין את ארכיטקטורת הלקוח-שרת של MCP.
- לזהות תפקידים ואחריות של Hosts, Clients ו-Servers.
- לנתח את התכונות המרכזיות שהופכות את MCP לשכבת אינטגרציה גמישה.
- ללמוד כיצד המידע זורם בתוך מערכת ה-MCP.
- לקבל תובנות מעשיות דרך דוגמאות קוד ב-.NET, Java, Python ו-JavaScript.

## 🔎 ארכיטקטורת MCP: מבט מעמיק

מערכת ה-MCP מבוססת על מודל לקוח-שרת. מבנה מודולרי זה מאפשר לאפליקציות AI לתקשר ביעילות עם כלים, מסדי נתונים, APIs ומשאבים קונטקסטואליים. נפרק את הארכיטקטורה הזו לרכיביה המרכזיים.

### 1. Hosts

בפרוטוקול הקשר למודל (MCP), ה-Hosts ממלאים תפקיד מרכזי כממשק הראשי דרכו המשתמשים מתקשרים עם הפרוטוקול. ה-Hosts הם אפליקציות או סביבות שמתחילות חיבורים עם שרתי MCP כדי לגשת לנתונים, כלים והנחיות. דוגמאות ל-Hosts הן סביבות פיתוח משולבות (IDEs) כמו Visual Studio Code, כלים מבוססי AI כמו Claude Desktop, או סוכנים מותאמים למשימות ספציפיות.

**Hosts** הם אפליקציות LLM שמתחילות חיבורים. הם:

- מבצעים או מתקשרים עם מודלים של AI כדי לייצר תגובות.
- מתחילים חיבורים עם שרתי MCP.
- מנהלים את זרימת השיחה וממשק המשתמש.
- שולטות בהרשאות ומגבלות אבטחה.
- מטפלים באישור המשתמש לשיתוף נתונים והרצת כלים.

### 2. Clients

ה-Clients הם רכיבים חיוניים שמאפשרים את האינטראקציה בין ה-Hosts לשרתי MCP. הם פועלים כמתווכים, ומאפשרים ל-Hosts לגשת ולהשתמש בפונקציות שמספקים שרתי MCP. תפקידם קריטי להבטחת תקשורת חלקה והחלפת נתונים יעילה במסגרת ארכיטקטורת MCP.

**Clients** הם מחברים בתוך אפליקציית ה-Host. הם:

- שולחים בקשות לשרתים עם הנחיות/פירוט.
- מנהלים משא ומתן על יכולות עם השרתים.
- מטפלים בבקשות להרצת כלים מהמודלים.
- מעבדים ומציגים תגובות למשתמשים.

### 3. Servers

ה-Servers אחראים לטיפול בבקשות מלקוחות MCP ומתן תגובות מתאימות. הם מנהלים פעולות שונות כמו אחזור נתונים, הרצת כלים ויצירת הנחיות. ה-Servers מבטיחים שהתקשורת בין הלקוחות ל-Hosts תהיה יעילה ואמינה, תוך שמירה על שלמות תהליך האינטראקציה.

**Servers** הם שירותים שמספקים הקשר ויכולות. הם:

- רושמים תכונות זמינות (משאבים, הנחיות, כלים).
- מקבלים ומבצעים קריאות כלים מהלקוח.
- מספקים מידע קונטקסטואלי לשיפור תגובות המודל.
- מחזירים פלטים ללקוח.
- שומרים על מצב במהלך האינטראקציות במידת הצורך.

ניתן לפתח שרתים על ידי כל אחד להרחבת יכולות המודל עם פונקציונליות מיוחדת.

### 4. תכונות השרת

שרתים בפרוטוקול הקשר למודל (MCP) מספקים אבני בניין בסיסיות שמאפשרות אינטראקציות עשירות בין לקוחות, hosts ומודלים לשוניים. תכונות אלו מיועדות לשפר את יכולות ה-MCP על ידי הצעת הקשר מובנה, כלים והנחיות.

שרתות MCP יכולים להציע כל אחת מהתכונות הבאות:

#### 📑 משאבים

משאבים בפרוטוקול הקשר למודל (MCP) כוללים סוגים שונים של הקשר ונתונים שניתן להשתמש בהם על ידי משתמשים או מודלי AI. אלה כוללים:

- **נתונים קונטקסטואליים**: מידע והקשר שמשתמשים או מודלים יכולים לנצל לקבלת החלטות וביצוע משימות.
- **מאגרי ידע ומאגרי מסמכים**: אוספים של נתונים מובנים ולא מובנים, כגון מאמרים, מדריכים ומחקרים, שמספקים תובנות ומידע חשוב.
- **קבצים ומסדי נתונים מקומיים**: נתונים המאוחסנים באופן מקומי במכשירים או במסדי נתונים, זמינים לעיבוד וניתוח.
- **APIs ושירותי רשת**: ממשקים ושירותים חיצוניים שמציעים נתונים ופונקציות נוספות, ומאפשרים אינטגרציה עם משאבים וכלים מקוונים שונים.

דוגמה למשאב יכולה להיות סכמת מסד נתונים או קובץ שניתן לגשת אליו כך:

```text
file://log.txt
database://schema
```

### 🤖 הנחיות

ההנחיות בפרוטוקול הקשר למודל (MCP) כוללות תבניות מוגדרות מראש ודפוסי אינטראקציה שמטרתם לייעל את זרימת העבודה של המשתמשים ולשפר את התקשורת. אלה כוללים:

- **הודעות ותהליכי עבודה מתבניתים**: הודעות ותהליכים מובנים מראש שמדריכים את המשתמשים במשימות ואינטראקציות ספציפיות.
- **דפוסי אינטראקציה מוגדרים מראש**: רצפים סטנדרטיים של פעולות ותגובות שמאפשרים תקשורת עקבית ויעילה.
- **תבניות שיחה מיוחדות**: תבניות הניתנות להתאמה אישית המיועדות לסוגים מסוימים של שיחות, להבטחת אינטראקציות רלוונטיות וקונטקסטואליות.

תבנית הנחיה יכולה להיראות כך:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ כלים

כלים בפרוטוקול הקשר למודל (MCP) הם פונקציות שהמודל יכול להפעיל לביצוע משימות ספציפיות. כלים אלו נועדו להרחיב את יכולות המודל על ידי מתן פעולות מובנות ואמינות. נקודות מפתח כוללות:

- **פונקציות שהמודל יכול להפעיל**: כלים הם פונקציות הניתנות להרצה שהמודל יכול לקרוא להן לביצוע משימות שונות.
- **שם ותיאור ייחודיים**: לכל כלי יש שם מובחן ותיאור מפורט שמסביר את מטרתו ופונקציונליותו.
- **פרמטרים ופלטים**: כלים מקבלים פרמטרים ספציפיים ומחזירים פלט מובנה, להבטחת תוצאות עקביות וניתנות לחיזוי.
- **פונקציות דיסקרטיות**: כלים מבצעים פונקציות נפרדות כמו חיפוש ברשת, חישובים ושאילתות למסדי נתונים.

דוגמה לכלי יכולה להיראות כך:

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## תכונות הלקוח

בפרוטוקול הקשר למודל (MCP), ללקוחות יש מספר תכונות מפתח המוצעות לשרתים, המשפרות את הפונקציונליות הכוללת והאינטראקציה בתוך הפרוטוקול. אחת התכונות הבולטות היא Sampling.

### 👉 Sampling

- **התנהגויות סוכנות שמתחילות מהשרת**: הלקוחות מאפשרים לשרתים ליזום פעולות או התנהגויות ספציפיות באופן אוטונומי, ומרחיבים את היכולות הדינמיות של המערכת.
- **אינטראקציות רקורסיביות עם LLM**: תכונה זו מאפשרת אינטראקציות רקורסיביות עם מודלים לשוניים גדולים, המאפשרות עיבוד מורכב ואיטרטיבי של משימות.
- **בקשת השלמות נוספות מהמודל**: שרתים יכולים לבקש השלמות נוספות מהמודל, להבטיח שהתגובות יהיו מקיפות ורלוונטיות לקונטקסט.

## זרימת מידע ב-MCP

פרוטוקול הקשר למודל (MCP) מגדיר זרימת מידע מובנית בין hosts, clients, servers ומודלים. הבנת הזרימה הזו מסייעת להבהיר כיצד מטופלות בקשות המשתמש ואיך כלים ונתונים חיצוניים משתלבים בתגובות המודל.

- **ה-Host יוזם חיבור**  
  אפליקציית ה-Host (כמו IDE או ממשק צ'אט) מקימה חיבור לשרת MCP, בדרך כלל דרך STDIO, WebSocket או אמצעי תחבורה נתמך אחר.

- **משא ומתן על יכולות**  
  הלקוח (המוטמע ב-Host) והשרת מחליפים מידע על התכונות, הכלים, המשאבים וגרסאות הפרוטוקול שהם תומכים בהם. זה מבטיח ששני הצדדים מבינים אילו יכולות זמינות במפגש.

- **בקשת משתמש**  
  המשתמש מתקשר עם ה-Host (למשל, מזין הנחיה או פקודה). ה-Host אוסף את הקלט ומעביר אותו ללקוח לעיבוד.

- **שימוש במשאב או כלי**  
  - הלקוח עשוי לבקש הקשר או משאבים נוספים מהשרת (כגון קבצים, רשומות מסד נתונים או מאמרי בסיס ידע) כדי להעשיר את הבנת המודל.
  - אם המודל קובע שנדרש כלי (למשל, לשלוף נתונים, לבצע חישוב או לקרוא ל-API), הלקוח שולח בקשת הפעלת כלי לשרת, עם שם הכלי והפרמטרים.

- **ביצוע בשרת**  
  השרת מקבל את בקשת המשאב או הכלי, מבצע את הפעולות הנדרשות (כגון הרצת פונקציה, שאילתת מסד נתונים או שליפת קובץ), ומחזיר את התוצאות ללקוח בפורמט מובנה.

- **יצירת תגובה**  
  הלקוח משלב את תגובות השרת (נתוני משאבים, פלטי כלים וכו') באינטראקציה השוטפת עם המודל. המודל משתמש במידע זה ליצירת תגובה מקיפה ורלוונטית לקונטקסט.

- **הצגת התוצאה**  
  ה-Host מקבל את הפלט הסופי מהלקוח ומציגו למשתמש, לרוב כולל גם את הטקסט שנוצר על ידי המודל וגם תוצאות מהרצת כלים או שליפת משאבים.

זרימה זו מאפשרת ל-MCP לתמוך באפליקציות AI מתקדמות, אינטראקטיביות ומודעות הקשר, על ידי חיבור חלק בין מודלים לכלים ולמקורות נתונים חיצוניים.

## פרטי הפרוטוקול

MCP (Model Context Protocol) מבוסס על [JSON-RPC 2.0](https://www.jsonrpc.org/), ומספק פורמט הודעות סטנדרטי, ניטרלי לשפה, לתקשורת בין hosts, clients ו-servers. יסוד זה מאפשר אינטראקציות אמינות, מובנות ומורחבות בפלטפורמות ושפות תכנות שונות.

### תכונות מרכזיות של הפרוטוקול

MCP מרחיב את JSON-RPC 2.0 עם קונבנציות נוספות לקריאות כלים, גישה למשאבים וניהול הנחיות. הוא תומך בשכבות תחבורה מרובות (STDIO, WebSocket, SSE) ומאפשר תקשורת מאובטחת, מורחבת ונייטרלית לשפה בין הרכיבים.

#### 🧢 פרוטוקול בסיסי

- **פורמט הודעות JSON-RPC**: כל הבקשות והתגובות משתמשות במפרט JSON-RPC 2.0, להבטחת מבנה עקבי לקריאות מתודות, פרמטרים, תוצאות וטיפול בשגיאות.
- **חיבורים עם שמירת מצב**: מפגשי MCP שומרים על מצב לאורך בקשות מרובות, תומכים בשיחות מתמשכות, הצטברות הקשר וניהול משאבים.
- **משא ומתן על יכולות**: בעת הקמת החיבור, לקוחות ושרתים מחליפים מידע על תכונות נתמכות, גרסאות פרוטוקול, כלים ומשאבים זמינים. זה מבטיח ששני הצדדים מבינים את יכולות הצד השני ויכולים להתאים את עצמם.

#### ➕ תוספות ושירותים נוספים

להלן כמה תוספות ושירותים שה-MCP מספק לשיפור חווית המפתחים ולאפשר תרחישים מתקדמים:

- **אפשרויות תצורה**: MCP מאפשר קונפיגורציה דינמית של פרמטרי מפגש, כמו הרשאות כלים, גישה למשאבים והגדרות מודל, המותאמות לכל אינטראקציה.
- **מעקב התקדמות**: פעולות ארוכות טווח יכולות לדווח על עדכוני התקדמות, מה שמאפשר ממשקי משתמש תגובתיים וחווית משתמש משופרת במשימות מורכבות.
- **ביטול בקשות**: לקוחות יכולים לבטל בקשות בתהליך, ומאפשרים למשתמשים להפסיק פעולות שכבר אינן נדרשות או שלוקחות זמן רב מדי.
- **דיווח שגיאות**: הודעות שגיאה וקודים סטנדרטיים מסייעים באבחון בעיות, טיפול בכשלים בצורה מסודרת ומתן משוב שימושי למשתמשים ומפתחים.
- **רישום לוגים**: גם לקוחות וגם שרתים יכולים להפיק לוגים מובנים לצורכי ביקורת, איתור שגיאות ומעקב אחר אינטראקציות בפרוטוקול.

באמצעות תכונות אלו, MCP מבטיח תקשורת יציבה, מאובטחת וגמישה בין מודלים לשוניים וכלים או מקורות נתונים חיצוניים.

### 🔐 שיקולי אבטחה

יישומי MCP צריכים לעמוד בכמה עקרונות אבטחה מרכזיים כדי להבטיח אינטראקציות בטוחות ואמינות:

- **אישור ושליטה של המשתמש**: יש לקבל הסכמה מפורשת מהמשתמש לפני גישה לנתונים או ביצוע פעולות. המשתמשים צריכים לשלוט באופן ברור מה משתף ומה מורשה, בתמיכה בממשקי משתמש אינטואיטיביים לסקירה ואישור פעילויות.

- **פרטיות נתונים**: נתוני המשתמש צריכים להיות חשופים רק בהסכמה מפורשת ולהיות מוגנים באמצעות בקרות גישה מתאימות. יש להגן על היישום מפני העברת נתונים לא מורשית ולוודא שהפרטיות נשמרת בכל האינטראקציות.

- **בטיחות כלים**: לפני הפעלת כל כלי, נדרש אישור מפורש מהמשתמש. יש להבטיח שהמשתמש מבין את פונקציונליות הכלי, ולכפות גבולות אבטחה חזקים למניעת הפעלה לא מכוונת או לא בטוחה של כלים.

בהקפדה על עקרונות אלו, MCP שומר על אמון, פרטיות ובטיחות המשתמש בכל האינטראקציות בפרוטוקול.

## דוגמאות קוד: רכיבים מרכזיים

להלן דוגמאות קוד בכמה שפות תכנות פופולריות המדגימות כיצד ליישם רכיבי שרת MCP וכלים מרכזיים.

### דוגמת .NET: יצירת שרת MCP פשוט עם כלים

זוהי דוגמה מעשית ב-.NET המראה כיצד לממש שרת MCP פשוט עם כלים מותאמים. הדוגמה מציגה כיצד להגדיר ולרשום כלים, לטפל בבקשות ולחבר את השרת באמצעות פרוטוקול הקשר למודל.

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

דוגמה זו מדגימה את אותו שרת MCP ורישום כלים כמו בדוגמת ה-.NET למעלה, אך מיושמת ב-Java.

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

בדוגמה זו אנו מראים כיצד לבנות שרת MCP ב-Python. מוצגות גם שתי דרכים שונות ליצירת כלים.

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

דוגמה זו מראה יצירת שרת MCP ב-JavaScript ומדגימה כיצד לרשום שני כלים הקשורים למזג אוויר.

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

דוגמת JavaScript זו מדגימה כיצד ליצור לקוח MCP שמתחבר לשרת, שולח הנחיה ומעבד את התגובה כולל כל קריאות הכלים שבוצעו.

## אבטחה והרשאות

MCP כולל מספר מושגים ומנגנונים מובנים

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפתו המקורית הוא המקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי אנושי. איננו אחראים לכל אי-הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.