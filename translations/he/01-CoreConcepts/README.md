<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T21:59:03+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "he"
}
-->
# 📖 מושגי יסוד ב-MCP: שליטה בפרוטוקול הקשר של המודל לשילוב בינה מלאכותית

פרוטוקול הקשר של המודל (MCP) הוא מסגרת חזקה וסטנדרטית שמייעלת את התקשורת בין מודלים לשוניים גדולים (LLMs) לכלים חיצוניים, אפליקציות ומקורות נתונים. מדריך זה, המותאם ל-SEO, ילווה אותך במושגי היסוד של MCP, ויבטיח הבנה של ארכיטקטורת הלקוח-שרת, הרכיבים המרכזיים, מנגנוני התקשורת והנוהגים הטובים ליישום.

## סקירה כללית

השיעור בוחן את הארכיטקטורה הבסיסית והרכיבים שמרכיבים את מערכת ה-MCP. תלמד על ארכיטקטורת הלקוח-שרת, הרכיבים המרכזיים ומנגנוני התקשורת שמאפשרים אינטראקציה ב-MCP.

## 👩‍🎓 מטרות למידה מרכזיות

בסיום השיעור תוכל:

- להבין את ארכיטקטורת הלקוח-שרת של MCP.
- לזהות תפקידים ואחריות של Hosts, Clients ו-Servers.
- לנתח את התכונות המרכזיות שהופכות את MCP לשכבת אינטגרציה גמישה.
- ללמוד כיצד זורמת המידע במערכת ה-MCP.
- לקבל תובנות מעשיות דרך דוגמאות קוד ב-.NET, Java, Python ו-JavaScript.

## 🔎 ארכיטקטורת MCP: מבט מעמיק יותר

מערכת ה-MCP בנויה על מודל לקוח-שרת. מבנה מודולרי זה מאפשר לאפליקציות AI לתקשר עם כלים, מסדי נתונים, APIs ומשאבים הקשריים ביעילות. נפרק את הארכיטקטורה הזו לרכיבים המרכזיים שלה.

### 1. Hosts

בפרוטוקול הקשר של המודל (MCP), ה-Hosts ממלאים תפקיד מרכזי כממשק הראשי דרכו המשתמשים מתקשרים עם הפרוטוקול. ה-Hosts הם אפליקציות או סביבות שמתחילות חיבורים עם שרתי MCP כדי לגשת לנתונים, כלים והנחיות. דוגמאות ל-Hosts כוללות סביבות פיתוח משולבות (IDEs) כמו Visual Studio Code, כלים מבוססי AI כמו Claude Desktop, או סוכנים מותאמים למשימות ספציפיות.

**Hosts** הם אפליקציות LLM שמתחילות חיבורים. הם:

- מבצעים או מתקשרים עם מודלים ליצירת תגובות.
- יוזמים חיבורים עם שרתי MCP.
- מנהלים את זרימת השיחה וממשק המשתמש.
- שומרים על הגבלות הרשאה ואבטחה.
- מטפלים בהסכמת המשתמש לשיתוף נתונים והרצת כלים.

### 2. Clients

ה-Clients הם רכיבים חיוניים שמקלים על האינטראקציה בין Hosts לשרתי MCP. הם פועלים כמתווכים, ומאפשרים ל-Hosts לגשת ולנצל את הפונקציות שמספקים שרתי MCP. הם ממלאים תפקיד מרכזי בהבטחת תקשורת חלקה וחילופי נתונים יעילים במערכת ה-MCP.

**Clients** הם מחברים בתוך אפליקציית ה-Host. הם:

- שולחים בקשות לשרתים עם הנחיות/פרומפטים.
- מנהלים משא ומתן על יכולות עם השרתים.
- מטפלים בבקשות הרצת כלים מהמודלים.
- מעבדים ומציגים תגובות למשתמשים.

### 3. Servers

ה-Servers אחראים לטיפול בבקשות מלקוחות MCP ומתן תגובות מתאימות. הם מנהלים פעולות שונות כמו שליפת נתונים, הרצת כלים ויצירת פרומפטים. השרתים מבטיחים שהתקשורת בין הלקוחות ל-Hosts תהיה יעילה ואמינה, ושומרים על שלמות תהליך האינטראקציה.

**Servers** הם שירותים המספקים הקשר ויכולות. הם:

- רושמים תכונות זמינות (משאבים, פרומפטים, כלים).
- מקבלים ומבצעים קריאות כלים מהלקוח.
- מספקים מידע הקשרי לשיפור תגובות המודל.
- מחזירים פלטים ללקוח.
- שומרים על מצב לאורך האינטראקציות לפי הצורך.

ניתן לפתח שרתים על ידי כל אחד להרחבת יכולות המודל עם פונקציונליות מתמחה.

### 4. תכונות השרת

שרתים בפרוטוקול הקשר של המודל (MCP) מספקים אבני בניין בסיסיות שמאפשרות אינטראקציות עשירות בין לקוחות, hosts ומודלים לשוניים. תכונות אלו נועדו לשפר את יכולות ה-MCP באמצעות מתן הקשר מובנה, כלים ופרומפטים.

שרתות MCP יכולים להציע כל אחת מהתכונות הבאות:

#### 📑 משאבים

משאבים בפרוטוקול הקשר של המודל (MCP) כוללים סוגים שונים של הקשר ונתונים שניתן לנצל על ידי משתמשים או מודלים של AI. אלו כוללים:

- **נתונים הקשריים**: מידע והקשר שמשתמשים או מודלים יכולים לנצל לקבלת החלטות וביצוע משימות.
- **בסיסי ידע ומאגרים של מסמכים**: אוספים של נתונים מובנים ובלתי מובנים, כמו מאמרים, מדריכים ומאמרי מחקר, המספקים תובנות ומידע חשוב.
- **קבצים ומסדי נתונים מקומיים**: נתונים המאוחסנים מקומית במכשירים או בתוך מסדי נתונים, נגישים לעיבוד וניתוח.
- **APIs ושירותי רשת**: ממשקים ושירותים חיצוניים שמציעים נתונים ופונקציות נוספות, ומאפשרים אינטגרציה עם משאבים וכלים מקוונים שונים.

דוגמה למשאב יכולה להיות סכמת מסד נתונים או קובץ שניתן לגשת אליו כך:

```text
file://log.txt
database://schema
```

### 🤖 פרומפטים

פרומפטים בפרוטוקול הקשר של המודל (MCP) כוללים תבניות מוגדרות מראש ודפוסי אינטראקציה שמטרתם לייעל תהליכי עבודה של משתמשים ולשפר את התקשורת. אלו כוללים:

- **הודעות ותהליכי עבודה בתבניות**: הודעות ותהליכים מובנים מראש שמדריכים משתמשים דרך משימות ואינטראקציות ספציפיות.
- **דפוסי אינטראקציה מוגדרים מראש**: רצפים סטנדרטיים של פעולות ותגובות שמאפשרים תקשורת עקבית ויעילה.
- **תבניות שיחה מתמחות**: תבניות ניתנות להתאמה המיועדות לסוגי שיחות מסוימים, להבטחת אינטראקציות רלוונטיות ומתאימות להקשר.

תבנית פרומפט יכולה להיראות כך:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ כלים

כלים בפרוטוקול הקשר של המודל (MCP) הם פונקציות שהמודל יכול להפעיל לביצוע משימות ספציפיות. כלים אלו נועדו להרחיב את יכולות המודל על ידי מתן פעולות מובנות ואמינות. מאפיינים מרכזיים כוללים:

- **פונקציות שהמודל יכול להפעיל**: כלים הם פונקציות הניתנות להרצה שהמודל יכול לקרוא להן לביצוע משימות שונות.
- **שם ייחודי ותיאור**: לכל כלי יש שם מובחן ותיאור מפורט שמסביר את מטרתו ותפקודו.
- **פרמטרים ופלטים**: כלים מקבלים פרמטרים ספציפיים ומחזירים פלט מובנה, להבטחת תוצאות עקביות וניתנות לחיזוי.
- **פונקציות בדידות**: כלים מבצעים פעולות בדידות כמו חיפושים באינטרנט, חישובים ושאילתות למסדי נתונים.

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

## תכונות הלקוח

בפרוטוקול הקשר של המודל (MCP), הלקוחות מציעים לשרתים מספר תכונות מרכזיות, המשפרות את הפונקציונליות והאינטראקציה בפרוטוקול. אחת התכונות הבולטות היא Sampling.

### 👉 Sampling

- **התנהגויות סוכנות המוזנקות על ידי השרת**: הלקוחות מאפשרים לשרתים ליזום פעולות או התנהגויות ספציפיות באופן עצמאי, ומשפרים את היכולות הדינמיות של המערכת.
- **אינטראקציות רקורסיביות עם LLMs**: תכונה זו מאפשרת אינטראקציות רקורסיביות עם מודלים לשוניים גדולים, ומאפשרת עיבוד מורכב ואיטרטיבי של משימות.
- **בקשת השלמות נוספות מהמודל**: השרתים יכולים לבקש השלמות נוספות מהמודל, להבטיח שהתשובות יהיו מקיפות ורלוונטיות להקשר.

## זרימת מידע ב-MCP

פרוטוקול הקשר של המודל (MCP) מגדיר זרימה מובנית של מידע בין hosts, clients, servers ומודלים. הבנת זרימה זו מסייעת להבהיר כיצד מטופלות בקשות המשתמש ואיך כלים ונתונים חיצוניים משתלבים בתגובות המודל.

- **ה-Host יוזם חיבור**  
  אפליקציית ה-host (כמו IDE או ממשק שיחה) מקימה חיבור לשרת MCP, בדרך כלל דרך STDIO, WebSocket או פרוטוקול תחבורה נתמך אחר.

- **משא ומתן על יכולות**  
  הלקוח (המוטמע ב-host) והשרת מחליפים מידע על התכונות, הכלים, המשאבים וגרסאות הפרוטוקול שהם תומכים בהם. זה מבטיח ששני הצדדים מבינים את היכולות הזמינות למפגש.

- **בקשת משתמש**  
  המשתמש מתקשר עם ה-host (לדוגמה, מזין פרומפט או פקודה). ה-host אוסף את הקלט ומעביר אותו ללקוח לעיבוד.

- **שימוש במשאב או כלי**  
  - הלקוח עשוי לבקש הקשר או משאבים נוספים מהשרת (כגון קבצים, רשומות מסד נתונים או מאמרים מבסיס ידע) כדי להעשיר את הבנת המודל.
  - אם המודל קובע שיש צורך בכלי (למשל, לשלוף נתונים, לבצע חישוב או לקרוא ל-API), הלקוח שולח בקשת הפעלת כלי לשרת, ומציין את שם הכלי והפרמטרים.

- **הרצת השרת**  
  השרת מקבל את בקשת המשאב או הכלי, מבצע את הפעולות הנדרשות (כגון הרצת פונקציה, שאילתת מסד נתונים או שליפת קובץ) ומחזיר את התוצאות ללקוח בפורמט מובנה.

- **יצירת תגובה**  
  הלקוח משלב את תגובות השרת (נתוני משאב, פלטי כלים וכו') באינטראקציה המתמשכת עם המודל. המודל משתמש במידע זה ליצירת תגובה מקיפה ורלוונטית להקשר.

- **הצגת התוצאה**  
  ה-host מקבל את הפלט הסופי מהלקוח ומציג אותו למשתמש, לעיתים כולל את הטקסט שנוצר על ידי המודל וכל תוצאות מהרצת כלים או חיפושי משאבים.

זרימה זו מאפשרת ל-MCP לתמוך באפליקציות AI מתקדמות, אינטראקטיביות ומודעות הקשר, על ידי חיבור חלק בין מודלים לכלים חיצוניים ומקורות נתונים.

## פרטי הפרוטוקול

MCP (Model Context Protocol) בנוי על גבי [JSON-RPC 2.0](https://www.jsonrpc.org/), ומספק פורמט הודעות סטנדרטי, ניטרלי לשפה, לתקשורת בין hosts, clients ו-servers. בסיס זה מאפשר אינטראקציות אמינות, מובנות וניתנות להרחבה בפלטפורמות ושפות תכנות מגוונות.

### תכונות מרכזיות בפרוטוקול

MCP מרחיב את JSON-RPC 2.0 עם קונבנציות נוספות להפעלת כלים, גישה למשאבים וניהול פרומפטים. הוא תומך בשכבות תחבורה מרובות (STDIO, WebSocket, SSE) ומאפשר תקשורת מאובטחת, ניתנת להרחבה ונייטרלית לשפה בין הרכיבים.

#### 🧢 פרוטוקול בסיסי

- **פורמט הודעות JSON-RPC**: כל הבקשות והתגובות משתמשות במפרט JSON-RPC 2.0, להבטחת מבנה עקבי לקריאות שיטות, פרמטרים, תוצאות וטיפול בשגיאות.
- **חיבורים מדינתיים**: מפגשי MCP שומרים על מצב לאורך בקשות מרובות, תומכים בשיחות מתמשכות, הצטברות הקשר וניהול משאבים.
- **משא ומתן על יכולות**: במהלך הקמת החיבור, לקוחות ושרתים מחליפים מידע על תכונות נתמכות, גרסאות פרוטוקול, כלים ומשאבים זמינים. זה מבטיח ששני הצדדים מבינים את יכולות זה של זה ויכולים להתאים בהתאם.

#### ➕ שירותים נוספים

להלן כמה שירותים והרחבות פרוטוקול ש-MCP מספק לשיפור חוויית המפתח ולאפשר תרחישים מתקדמים:

- **אפשרויות קונפיגורציה**: MCP מאפשר קונפיגורציה דינמית של פרמטרי מפגש, כמו הרשאות כלים, גישה למשאבים והגדרות מודל, המותאמות לכל אינטראקציה.
- **מעקב התקדמות**: פעולות ארוכות טווח יכולות לדווח על עדכוני התקדמות, מה שמאפשר ממשקי משתמש מגיבים וחוויית משתמש טובה יותר במהלך משימות מורכבות.
- **ביטול בקשות**: לקוחות יכולים לבטל בקשות בתהליך, ומאפשרים למשתמשים להפסיק פעולות שכבר אינן נחוצות או שלוקחות זמן רב מדי.
- **דיווח שגיאות**: הודעות שגיאה וקודים סטנדרטיים מסייעים באבחון בעיות, טיפול בכישלונות בצורה אלגנטית ומתן משוב מעשי למשתמשים ומפתחים.
- **רישום לוגים**: גם לקוחות וגם שרתים יכולים להפיק לוגים מובנים למטרות ביקורת, איתור באגים ומעקב אחר אינטראקציות הפרוטוקול.

באמצעות תכונות הפרוטוקול הללו, MCP מבטיח תקשורת חזקה, מאובטחת וגמישה בין מודלים לשוניים לכלים חיצוניים או מקורות נתונים.

### 🔐 שיקולי אבטחה

יישומי MCP צריכים לעמוד בכמה עקרונות אבטחה מרכזיים להבטחת אינטראקציות בטוחות ואמינות:

- **הסכמת משתמש ושליטה**: יש לקבל הסכמה מפורשת מהמשתמש לפני גישה לנתונים או ביצוע פעולות. על המשתמש להיות בשליטה ברורה על אילו נתונים משותפים ואילו פעולות מורשות, בתמיכה בממשקי משתמש אינטואיטיביים לסקירה ואישור פעילויות.

- **פרטיות נתונים**: נתוני המשתמש צריכים להיות חשופים רק בהסכמה מפורשת, ולהיות מוגנים באמצעות בקרות גישה מתאימות. יישומי MCP חייבים להגן מפני העברת נתונים לא מורשית ולהבטיח שהפרטיות נשמרת בכל האינטראקציות.

- **בטיחות הכלים**: לפני הפעלת כל כלי, יש לקבל הסכמה מפורשת מהמשתמש. על המשתמש להבין היטב את תפקודו של כל כלי, ויש לאכוף גבולות אבטחה חזקים למניעת הפעלה בלתי מכוונת או מסוכנת של כלים.

באמצעות עמידה בעקרונות אלו, MCP מבטיח אמון, פרטיות ובטיחות של המשתמשים בכל האינטראקציות בפרוטוקול.

## דוגמאות קוד: רכיבים מרכזיים

להלן דוגמאות קוד בשפות תכנות פופולריות שמדגימות כיצד לממש רכיבי שרת MCP וכלים מרכזיים.

### דוגמה ב-.NET: יצירת שרת MCP פשוט עם כלים

זוהי דוגמה מעשית ב-.NET המדגימה כיצד לממש שרת MCP פשוט עם כלים מותאמים. הדוגמה מציגה כיצד להגדיר ולרשום כלים, לטפל בבקשות ולחבר את השרת באמצעות פרוטוקול הקשר של המודל.

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

### דוגמה ב-Java: רכיבי שרת MCP

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

### דוגמה ב-Python: בניית שרת MCP

בדוגמה זו מראים כיצד לבנות שרת MCP ב-Python. מוצגות גם שתי דרכים שונות ליצירת כלים.

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

### דוגמה ב-JavaScript: יצירת שרת MCP

בדוגמה זו מוצגת יצירת שרת MCP ב-JavaScript וכיצד לרשום שני כלים הקשורים למזג אוויר.

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

דוגמת JavaScript זו מראה כיצד ליצור לקוח MCP שמתחבר לשרת, שולח פרומפט ומעבד את התגובה כולל קריאות כלים שבוצעו.

## אבטחה והרשאות

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להיעזר בתרגום מקצועי על ידי אדם. אנו לא נושאים באחריות לכל אי הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.