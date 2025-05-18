<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:47:28+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "he"
}
-->
# 📖 מושגי ליבה של MCP: שליטה בפרוטוקול הקשר המודל לשילוב AI

פרוטוקול הקשר המודל (MCP) הוא מסגרת סטנדרטית חזקה המייעלת את התקשורת בין מודלים של שפה גדולים (LLMs) לבין כלים חיצוניים, יישומים ומקורות נתונים. המדריך האופטימלי הזה ל-SEO יעביר אותך דרך מושגי הליבה של MCP, ויבטיח שתבין את ארכיטקטורת הלקוח-שרת שלו, רכיבים חיוניים, מנגנוני תקשורת ופרקטיקות יישום מיטביות.

## סקירה כללית

השיעור הזה חוקר את הארכיטקטורה הבסיסית והרכיבים שמרכיבים את מערכת האקולוגית של פרוטוקול הקשר המודל (MCP). תלמד על ארכיטקטורת הלקוח-שרת, רכיבים מרכזיים ומנגנוני תקשורת שמפעילים את האינטראקציות של MCP.

## 👩‍🎓 מטרות למידה מרכזיות

בסוף השיעור הזה, תוכל:

- להבין את ארכיטקטורת הלקוח-שרת של MCP.
- לזהות תפקידים ואחריות של מארחים, לקוחות ושרתים.
- לנתח את התכונות המרכזיות שהופכות את MCP לשכבת שילוב גמישה.
- ללמוד כיצד מידע זורם בתוך המערכת האקולוגית של MCP.
- לקבל תובנות מעשיות באמצעות דוגמאות קוד ב-.NET, Java, Python ו-JavaScript.

## 🔎 ארכיטקטורת MCP: מבט מעמיק

המערכת האקולוגית של MCP בנויה על מודל לקוח-שרת. מבנה מודולרי זה מאפשר ליישומי AI לתקשר עם כלים, מסדי נתונים, APIs ומשאבים הקשריים ביעילות. בואו נפרק את הארכיטקטורה הזו לרכיבים המרכזיים שלה.

### 1. מארחים

בפרוטוקול הקשר המודל (MCP), מארחים משחקים תפקיד מכריע כממשק הראשי שדרכו משתמשים מתקשרים עם הפרוטוקול. מארחים הם יישומים או סביבות שמתחילים חיבורים עם שרתי MCP כדי לגשת לנתונים, כלים והנחיות. דוגמאות למארחים כוללות סביבות פיתוח משולבות (IDEs) כמו Visual Studio Code, כלים AI כמו Claude Desktop, או סוכנים מותאמים אישית שנבנו למשימות ספציפיות.

**מארחים** הם יישומי LLM שמתחילים חיבורים. הם:

- מבצעים או מתקשרים עם מודלים של AI כדי לייצר תגובות.
- מתחילים חיבורים עם שרתי MCP.
- מנהלים את זרימת השיחה והממשק המשתמש.
- שולטים בהרשאות ובמגבלות אבטחה.
- מטפלים בהסכמת המשתמש לשיתוף נתונים וביצוע כלים.

### 2. לקוחות

לקוחות הם רכיבים חיוניים שמקלים על האינטראקציה בין מארחים לשרתי MCP. לקוחות פועלים כמתווכים, המאפשרים למארחים לגשת ולהשתמש בפונקציות שמספקים שרתי MCP. הם משחקים תפקיד מכריע בהבטחת תקשורת חלקה וחילופי נתונים יעילים בתוך ארכיטקטורת MCP.

**לקוחות** הם מחברים בתוך יישום המארח. הם:

- שולחים בקשות לשרתים עם הנחיות/הוראות.
- מנהלים יכולות עם שרתים.
- מנהלים בקשות לביצוע כלים מהמודלים.
- מעבדים ומציגים תגובות למשתמשים.

### 3. שרתים

שרתים אחראים על טיפול בבקשות מלקוחות MCP ומתן תגובות מתאימות. הם מנהלים פעולות שונות כגון אחזור נתונים, ביצוע כלים ויצירת הנחיות. שרתים מבטיחים שהתקשורת בין לקוחות למארחים תהיה יעילה ואמינה, ושומרים על שלמות תהליך האינטראקציה.

**שרתים** הם שירותים שמספקים הקשר ויכולות. הם:

- רושמים תכונות זמינות (משאבים, הנחיות, כלים).
- מקבלים ומבצעים קריאות כלים מהלקוח.
- מספקים מידע הקשרי לשיפור תגובות המודל.
- מחזירים פלטים חזרה ללקוח.
- שומרים על מצב בין אינטראקציות בעת הצורך.

שרתים יכולים להיות מפותחים על ידי כל אחד להרחבת יכולות המודל עם פונקציונליות מיוחדת.

### 4. תכונות שרת

שרתים בפרוטוקול הקשר המודל (MCP) מספקים אבני בניין בסיסיות שמאפשרות אינטראקציות עשירות בין לקוחות, מארחים ומודלי שפה. תכונות אלו נועדו לשפר את יכולות MCP על ידי הצעת הקשר מובנה, כלים והנחיות.

שרתים של MCP יכולים להציע כל אחת מהתכונות הבאות:

#### 📑 משאבים

משאבים בפרוטוקול הקשר המודל (MCP) כוללים סוגים שונים של הקשר ונתונים שניתן להשתמש בהם על ידי משתמשים או מודלי AI. אלו כוללים:

- **נתונים הקשריים**: מידע והקשר שמשתמשים או מודלי AI יכולים לנצל לקבלת החלטות וביצוע משימות.
- **בסיסי ידע ומאגרים דוקומנטריים**: אוספים של נתונים מובנים ולא מובנים, כגון מאמרים, מדריכים ומחקרים, שמספקים תובנות ומידע בעלי ערך.
- **קבצים מקומיים ומסדי נתונים**: נתונים המאוחסנים מקומית על מכשירים או בתוך מסדי נתונים, נגישים לעיבוד וניתוח.
- **APIs ושירותי רשת**: ממשקים ושירותים חיצוניים שמציעים נתונים ופונקציות נוספות, מאפשרים שילוב עם משאבים וכלים מקוונים שונים.

דוגמה למשאב יכולה להיות סכמת מסד נתונים או קובץ שניתן לגשת אליו כך:

```text
file://log.txt
database://schema
```

### 🤖 הנחיות

הנחיות בפרוטוקול הקשר המודל (MCP) כוללות תבניות מוגדרות מראש ודפוסי אינטראקציה שנועדו לייעל את זרימות העבודה של המשתמשים ולשפר את התקשורת. אלו כוללים:

- **הודעות ותהליכים מתבניות**: הודעות ותהליכים מובנים מראש שמנחים משתמשים דרך משימות ואינטראקציות מסוימות.
- **דפוסי אינטראקציה מוגדרים מראש**: רצפי פעולות ותגובות סטנדרטיים שמקלים על תקשורת עקבית ויעילה.
- **תבניות שיחה מיוחדות**: תבניות מותאמות אישית שנועדו לסוגי שיחות ספציפיים, ומבטיחות אינטראקציות רלוונטיות והקשריות.

תבנית הנחיה יכולה להיראות כך:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ כלים

כלים בפרוטוקול הקשר המודל (MCP) הם פונקציות שהמודל AI יכול לבצע כדי לבצע משימות ספציפיות. כלים אלו נועדו לשפר את יכולות המודל AI על ידי מתן פעולות מובנות ואמינות. היבטים מרכזיים כוללים:

- **פונקציות לביצוע על ידי המודל AI**: כלים הם פונקציות ניתנות לביצוע שהמודל AI יכול לזמן כדי לבצע משימות שונות.
- **שם ותיאור ייחודיים**: לכל כלי יש שם ייחודי ותיאור מפורט שמסביר את מטרתו ואת תפקודו.
- **פרמטרים ותוצאות**: כלים מקבלים פרמטרים מסוימים ומחזירים תוצאות מובנות, ומבטיחים תוצאות עקביות וניתנות לחיזוי.
- **פונקציות נפרדות**: כלים מבצעים פונקציות נפרדות כגון חיפושי רשת, חישובים ושאילתות מסדי נתונים.

כלי לדוגמה יכול להיראות כך:

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

## תכונות לקוח

בפרוטוקול הקשר המודל (MCP), לקוחות מציעים מספר תכונות מפתח לשרתים, משפרים את הפונקציונליות הכוללת והאינטראקציה בתוך הפרוטוקול. אחת התכונות הבולטות היא דגימה.

### 👉 דגימה

- **התנהגויות אוטונומיות שמתחילות על ידי השרת**: לקוחות מאפשרים לשרתים להתחיל פעולות או התנהגויות ספציפיות באופן אוטונומי, משפרים את היכולות הדינמיות של המערכת.
- **אינטראקציות רקורסיביות עם LLM**: תכונה זו מאפשרת אינטראקציות רקורסיביות עם מודלים של שפה גדולים (LLMs), מאפשרת עיבוד מורכב ואיטרטיבי יותר של משימות.
- **בקשת השלמות מודל נוספות**: שרתים יכולים לבקש השלמות נוספות מהמודל, מבטיחים שהתגובות יהיו מקיפות ורלוונטיות להקשר.

## זרימת מידע ב-MCP

פרוטוקול הקשר המודל (MCP) מגדיר זרימה מובנית של מידע בין מארחים, לקוחות, שרתים ומודלים. הבנת זרימה זו עוזרת להבהיר כיצד בקשות משתמש מעובדות וכיצד כלים חיצוניים ונתונים משולבים בתגובות המודל.

- **המארח מתחיל חיבור**  
  יישום המארח (כגון IDE או ממשק צ'אט) יוצר חיבור לשרת MCP, בדרך כלל באמצעות STDIO, WebSocket או תעבורה נתמכת אחרת.

- **ניהול יכולות**  
  הלקוח (המוטמע במארח) והשרת מחליפים מידע על התכונות הנתמכות שלהם, הכלים, המשאבים וגרסאות הפרוטוקול. זה מבטיח ששני הצדדים מבינים אילו יכולות זמינות עבור המפגש.

- **בקשת משתמש**  
  המשתמש מתקשר עם המארח (למשל, מזין הנחיה או פקודה). המארח אוסף קלט זה ומעביר אותו ללקוח לעיבוד.

- **שימוש במשאב או בכלי**  
  - הלקוח עשוי לבקש הקשר או משאבים נוספים מהשרת (כגון קבצים, ערכי מסד נתונים או מאמרי בסיס ידע) כדי להעשיר את הבנת המודל.
  - אם המודל קובע שנדרש כלי (למשל, כדי להביא נתונים, לבצע חישוב או לקרוא API), הלקוח שולח בקשת קריאת כלי לשרת, מציין את שם הכלי והפרמטרים.

- **ביצוע שרת**  
  השרת מקבל את בקשת המשאב או הכלי, מבצע את הפעולות הנדרשות (כגון הרצת פונקציה, שאילת מסד נתונים או אחזור קובץ), ומחזיר את התוצאות ללקוח בפורמט מובנה.

- **יצירת תגובה**  
  הלקוח משלב את התגובות של השרת (נתוני משאבים, פלטי כלים וכו') באינטראקציה המתמשכת עם המודל. המודל משתמש במידע זה כדי לייצר תגובה מקיפה ורלוונטית להקשר.

- **הצגת תוצאה**  
  המארח מקבל את הפלט הסופי מהלקוח ומציג אותו למשתמש, לעיתים כולל הן את הטקסט שנוצר על ידי המודל והן תוצאות מכלי או חיפושי משאבים.

זרימה זו מאפשרת ל-MCP לתמוך ביישומי AI מתקדמים, אינטראקטיביים ומודעים להקשר על ידי חיבור חלק של מודלים עם כלים חיצוניים ומקורות נתונים.

## פרטי הפרוטוקול

MCP (Model Context Protocol) בנוי על גבי [JSON-RPC 2.0](https://www.jsonrpc.org/), מספק פורמט הודעות סטנדרטי, שאינו תלוי בשפה, לתקשורת בין מארחים, לקוחות ושרתים. בסיס זה מאפשר אינטראקציות אמינות, מובנות וניתנות להרחבה בין פלטפורמות ושפות תכנות מגוונות.

### תכונות מפתח של הפרוטוקול

MCP מרחיב את JSON-RPC 2.0 עם קונבנציות נוספות לקריאות כלים, גישה למשאבים וניהול הנחיות. הוא תומך בשכבות תעבורה מרובות (STDIO, WebSocket, SSE) ומאפשר תקשורת מאובטחת, ניתנת להרחבה ואינה תלויה בשפה בין רכיבים.

#### 🧢 פרוטוקול בסיסי

- **פורמט הודעות JSON-RPC**: כל הבקשות והתגובות משתמשות במפרט JSON-RPC 2.0, מבטיחים מבנה עקבי לקריאות שיטה, פרמטרים, תוצאות וטיפול בשגיאות.
- **חיבורים עם מצב**: מפגשי MCP שומרים על מצב בין בקשות מרובות, תומכים בשיחות מתמשכות, צבירת הקשר וניהול משאבים.
- **ניהול יכולות**: במהלך הגדרת החיבור, לקוחות ושרתים מחליפים מידע על תכונות נתמכות, גרסאות פרוטוקול, כלים ומשאבים זמינים. זה מבטיח ששני הצדדים מבינים את היכולות אחד של השני ויכולים להסתגל בהתאם.

#### ➕ כלים נוספים

להלן כמה כלים נוספים והרחבות פרוטוקול שמספק MCP לשיפור חוויית המפתחים ולאפשר תרחישים מתקדמים:

- **אפשרויות תצורה**: MCP מאפשר תצורה דינמית של פרמטרי המפגש, כגון הרשאות כלים, גישה למשאבים והגדרות מודל, מותאמים לכל אינטראקציה.
- **מעקב התקדמות**: פעולות ארוכות טווח יכולות לדווח על עדכוני התקדמות, מאפשרים ממשקי משתמש תגובתיים וחוויית משתמש טובה יותר במהלך משימות מורכבות.
- **ביטול בקשות**: לקוחות יכולים לבטל בקשות בעיצומן, מאפשרים למשתמשים להפריע לפעולות שכבר אינן נחוצות או שלוקחות זמן רב מדי.
- **דיווח על שגיאות**: הודעות שגיאה וקודים סטנדרטיים עוזרים לאבחן בעיות, לטפל בכשלונות בחן ולספק משוב ישים למשתמשים ולמפתחים.
- **רישום**: הן לקוחות והן שרתים יכולים להפיק יומנים מובנים לביקורת, ניפוי שגיאות ומעקב אחר אינטראקציות פרוטוקול.

על ידי ניצול תכונות פרוטוקול אלו, MCP מבטיח תקשורת חזקה, מאובטחת וגמישה בין מודלי שפה וכלים חיצוניים או מקורות נתונים.

### 🔐 שיקולי אבטחה

יש להקפיד על מספר עקרונות אבטחה מרכזיים במימושי MCP כדי להבטיח אינטראקציות בטוחות ואמינות:

- **הסכמה ושליטה של המשתמש**: על המשתמשים לספק הסכמה מפורשת לפני שניגשים לנתונים או מתבצעות פעולות. עליהם להיות בעלי שליטה ברורה על איזה נתונים משותפים ואילו פעולות מאושרות, נתמכים על ידי ממשקי משתמש אינטואיטיביים לסקירה ואישור פעילויות.

- **פרטיות נתונים**: יש לחשוף נתוני משתמש רק בהסכמה מפורשת ויש להגן עליהם באמצעות בקרות גישה מתאימות. מימושי MCP חייבים להגן מפני העברת נתונים לא מורשית ולוודא שהפרטיות נשמרת בכל האינטראקציות.

- **בטיחות כלים**: לפני קריאת כל כלי, נדרשת הסכמה מפורשת של המשתמש. על המשתמשים להיות בעלי הבנה ברורה של תפקודו של כל כלי, ויש לאכוף גבולות אבטחה חזקים כדי למנוע ביצוע כלים בלתי מכוון או לא בטוח.

על ידי הקפדה על עקרונות אלו, MCP מבטיח שהאמון, הפרטיות והבטיחות של המשתמש נשמרים בכל אינטראקציות הפרוטוקול.

## דוגמאות קוד: רכיבים מרכזיים

להלן דוגמאות קוד במספר שפות תכנות פופולריות שממחישות כיצד ליישם רכיבי שרת MCP מרכזיים וכלים.

### דוגמה ב-.NET: יצירת שרת MCP פשוט עם כלים

להלן דוגמת קוד מעשית ב-.NET שמדגימה כיצד ליישם שרת MCP פשוט עם כלים מותאמים אישית. דוגמה זו מציגה כיצד להגדיר ולרשום כלים, לטפל בבקשות ולחבר את השרת באמצעות פרוטוקול הקשר המודל.

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

דוגמה זו מדגימה את אותו שרת MCP ורישום כלים כמו בדוגמה ב-.NET לעיל, אך מיושם ב-Java.

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

בדוגמה זו אנו מראים כיצד לבנות שרת MCP ב-Python. כמו כן, מוצגות שתי דרכים שונות ליצור כלים.

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

דוגמה זו מראה את יצירת שרת MCP ב-JavaScript ומראה כיצד לרשום שני כלים הקשורים למזג האוויר.

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

דוגמה זו ב-JavaScript מדגימה כיצד ליצור לקוח MCP שמתחבר

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום AI [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, אנא היו מודעים לכך שתרגומים אוטומטיים עשויים להכיל שגיאות או אי דיוקים. המסמך המקורי בשפתו המקורית צריך להיחשב כמקור סמכותי. עבור מידע קריטי, מומלץ להשתמש בתרגום מקצועי על ידי אדם. אנו לא נושאים באחריות לאי הבנות או לפרשנויות שגויות הנובעות משימוש בתרגום זה.