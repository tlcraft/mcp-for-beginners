<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:32:39+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "he"
}
-->
# לקחים מאימוץ מוקדם

## סקירה כללית

השיעור הזה בוחן כיצד מאמצים מוקדמים ניצלו את Model Context Protocol (MCP) כדי לפתור אתגרים אמיתיים ולהניע חדשנות בתעשיות שונות. דרך מחקרי מקרה מפורטים ופרויקטים מעשיים, תראו כיצד MCP מאפשר אינטגרציה מאוחדת, מאובטחת וניתנת להרחבה של בינה מלאכותית—מחבר בין מודלים לשוניים גדולים, כלים ונתוני ארגונים במסגרת אחידה. תרכשו ניסיון מעשי בעיצוב ובניית פתרונות מבוססי MCP, תלמדו מדפוסי יישום מוכחים ותגלו שיטות עבודה מומלצות לפריסה בסביבות ייצור. השיעור גם מדגיש מגמות מתפתחות, כיוונים עתידיים ומשאבים בקוד פתוח שיעזרו לכם להישאר בחזית טכנולוגיית MCP והאקוסיסטם המתפתח שלה.

## מטרות הלמידה

- לנתח יישומים אמיתיים של MCP בתעשיות שונות  
- לעצב ולבנות אפליקציות שלמות מבוססות MCP  
- לחקור מגמות מתפתחות וכיוונים עתידיים בטכנולוגיית MCP  
- ליישם שיטות עבודה מומלצות בתרחישי פיתוח אמיתיים  

## יישומים אמיתיים של MCP

### מחקר מקרה 1: אוטומציה של תמיכת לקוחות בארגונים

תאגיד רב-לאומי יישם פתרון מבוסס MCP כדי לאחד את האינטראקציות עם בינה מלאכותית במערכות התמיכה בלקוחות שלו. זה איפשר להם:

- ליצור ממשק אחיד לספקי LLM שונים  
- לשמור על ניהול עקבי של הפקודות בין המחלקות  
- ליישם בקרות אבטחה וציות מחמירות  
- לעבור בקלות בין מודלים שונים לפי הצרכים הספציפיים  

**יישום טכני:**  
```python
# Python MCP server implementation for customer support
import logging
import asyncio
from modelcontextprotocol import create_server, ServerConfig
from modelcontextprotocol.server import MCPServer
from modelcontextprotocol.transports import create_http_transport
from modelcontextprotocol.resources import ResourceDefinition
from modelcontextprotocol.prompts import PromptDefinition
from modelcontextprotocol.tool import ToolDefinition

# Configure logging
logging.basicConfig(level=logging.INFO)

async def main():
    # Create server configuration
    config = ServerConfig(
        name="Enterprise Customer Support Server",
        version="1.0.0",
        description="MCP server for handling customer support inquiries"
    )
    
    # Initialize MCP server
    server = create_server(config)
    
    # Register knowledge base resources
    server.resources.register(
        ResourceDefinition(
            name="customer_kb",
            description="Customer knowledge base documentation"
        ),
        lambda params: get_customer_documentation(params)
    )
    
    # Register prompt templates
    server.prompts.register(
        PromptDefinition(
            name="support_template",
            description="Templates for customer support responses"
        ),
        lambda params: get_support_templates(params)
    )
    
    # Register support tools
    server.tools.register(
        ToolDefinition(
            name="ticketing",
            description="Create and update support tickets"
        ),
        handle_ticketing_operations
    )
    
    # Start server with HTTP transport
    transport = create_http_transport(port=8080)
    await server.run(transport)

if __name__ == "__main__":
    asyncio.run(main())
```

**תוצאות:** הפחתה של 30% בעלויות המודלים, שיפור של 45% בעקביות התגובות, והגברת הציות בתקנים ברחבי הפעילות הגלובלית.

### מחקר מקרה 2: עוזר אבחוני בתחום הבריאות

ספק שירותי בריאות פיתח תשתית MCP לשילוב מספר מודלים רפואיים מתמחים תוך שמירה על הגנת מידע רגיש של מטופלים:

- מעבר חלק בין מודלים רפואיים כלליים למומחים  
- בקרות פרטיות מחמירות ומסלולי ביקורת  
- אינטגרציה עם מערכות רשומות רפואיות אלקטרוניות (EHR) קיימות  
- הנדסת פקודות עקבית למונחים רפואיים  

**יישום טכני:**  
```csharp
// C# MCP host application implementation in healthcare application
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.SDK.Client;
using ModelContextProtocol.SDK.Security;
using ModelContextProtocol.SDK.Resources;

public class DiagnosticAssistant
{
    private readonly MCPHostClient _mcpClient;
    private readonly PatientContext _patientContext;
    
    public DiagnosticAssistant(PatientContext patientContext)
    {
        _patientContext = patientContext;
        
        // Configure MCP client with healthcare-specific settings
        var clientOptions = new ClientOptions
        {
            Name = "Healthcare Diagnostic Assistant",
            Version = "1.0.0",
            Security = new SecurityOptions
            {
                Encryption = EncryptionLevel.Medical,
                AuditEnabled = true
            }
        };
        
        _mcpClient = new MCPHostClientBuilder()
            .WithOptions(clientOptions)
            .WithTransport(new HttpTransport("https://healthcare-mcp.example.org"))
            .WithAuthentication(new HIPAACompliantAuthProvider())
            .Build();
    }
    
    public async Task<DiagnosticSuggestion> GetDiagnosticAssistance(
        string symptoms, string patientHistory)
    {
        // Create request with appropriate resources and tool access
        var resourceRequest = new ResourceRequest
        {
            Name = "patient_records",
            Parameters = new Dictionary<string, object>
            {
                ["patientId"] = _patientContext.PatientId,
                ["requestingProvider"] = _patientContext.ProviderId
            }
        };
        
        // Request diagnostic assistance using appropriate prompt
        var response = await _mcpClient.SendPromptRequestAsync(
            promptName: "diagnostic_assistance",
            parameters: new Dictionary<string, object>
            {
                ["symptoms"] = symptoms,
                patientHistory = patientHistory,
                relevantGuidelines = _patientContext.GetRelevantGuidelines()
            });
            
        return DiagnosticSuggestion.FromMCPResponse(response);
    }
}
```

**תוצאות:** שיפור בהצעות האבחון לרופאים תוך שמירה מלאה על תקנות HIPAA והפחתה משמעותית במעבר בין מערכות.

### מחקר מקרה 3: ניתוח סיכונים בשירותים פיננסיים

מוסד פיננסי יישם MCP כדי לאחד את תהליכי ניתוח הסיכונים במחלקות שונות:

- יצירת ממשק אחיד למודלים של סיכון אשראי, גילוי הונאות וסיכון השקעות  
- יישום בקרות גישה מחמירות וניהול גרסאות למודלים  
- הבטחת יכולת ביקורת לכל ההמלצות של הבינה המלאכותית  
- שמירה על פורמט נתונים עקבי בין מערכות מגוונות  

**יישום טכני:**  
```java
// Java MCP server for financial risk assessment
import org.mcp.server.*;
import org.mcp.security.*;

public class FinancialRiskMCPServer {
    public static void main(String[] args) {
        // Create MCP server with financial compliance features
        MCPServer server = new MCPServerBuilder()
            .withModelProviders(
                new ModelProvider("risk-assessment-primary", new AzureOpenAIProvider()),
                new ModelProvider("risk-assessment-audit", new LocalLlamaProvider())
            )
            .withPromptTemplateDirectory("./compliance/templates")
            .withAccessControls(new SOCCompliantAccessControl())
            .withDataEncryption(EncryptionStandard.FINANCIAL_GRADE)
            .withVersionControl(true)
            .withAuditLogging(new DatabaseAuditLogger())
            .build();
            
        server.addRequestValidator(new FinancialDataValidator());
        server.addResponseFilter(new PII_RedactionFilter());
        
        server.start(9000);
        
        System.out.println("Financial Risk MCP Server running on port 9000");
    }
}
```

**תוצאות:** שיפור הציות לרגולציה, קיצור מחזורי פריסת מודלים ב-40%, ושיפור עקביות הערכת הסיכונים במחלקות.

### מחקר מקרה 4: שרת Playwright MCP של Microsoft לאוטומציה בדפדפן

מיקרוסופט פיתחה את [Playwright MCP server](https://github.com/microsoft/playwright-mcp) כדי לאפשר אוטומציה מאובטחת ומאוחדת של דפדפנים דרך Model Context Protocol. הפתרון מאפשר לסוכני AI ול-LLM אינטראקציה עם דפדפנים בצורה מבוקרת, ניתנת לביקורת ומורחבת—ומאפשר שימושים כמו בדיקות אוטומטיות, חילוץ נתונים וזרימות עבודה מקצה לקצה.

- חושף יכולות אוטומציה בדפדפן (ניווט, מילוי טפסים, צילום מסך וכו') ככלים ב-MCP  
- מיישם בקרות גישה מחמירות וסביבת סנדבוקס למניעת פעולות לא מורשות  
- מספק יומני ביקורת מפורטים לכל האינטראקציות עם הדפדפן  
- תומך באינטגרציה עם Azure OpenAI וספקי LLM נוספים לאוטומציה מונעת סוכנים  

**יישום טכני:**  
```typescript
// TypeScript: Registering Playwright browser automation tools in an MCP server
import { createServer, ToolDefinition } from 'modelcontextprotocol';
import { launch } from 'playwright';

const server = createServer({
  name: 'Playwright MCP Server',
  version: '1.0.0',
  description: 'MCP server for browser automation using Playwright'
});

// Register a tool for navigating to a URL and capturing a screenshot
server.tools.register(
  new ToolDefinition({
    name: 'navigate_and_screenshot',
    description: 'Navigate to a URL and capture a screenshot',
    parameters: {
      url: { type: 'string', description: 'The URL to visit' }
    }
  }),
  async ({ url }) => {
    const browser = await launch();
    const page = await browser.newPage();
    await page.goto(url);
    const screenshot = await page.screenshot();
    await browser.close();
    return { screenshot };
  }
);

// Start the MCP server
server.listen(8080);
```

**תוצאות:**  
- אפשר אוטומציה מאובטחת ומבוקרת של דפדפנים עבור סוכני AI ו-LLM  
- הפחית את מאמץ הבדיקות הידניות ושיפר את כיסוי הבדיקות לאפליקציות ווב  
- סיפק מסגרת ניתנת לשימוש חוזר ולהרחבה לאינטגרציה של כלים מבוססי דפדפן בסביבות ארגוניות  

**הפניות:**  
- [מאגר GitHub של Playwright MCP Server](https://github.com/microsoft/playwright-mcp)  
- [פתרונות AI ואוטומציה של Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

### מחקר מקרה 5: Azure MCP – Model Context Protocol ברמת ארגון כשירות

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) הוא יישום מנוהל ברמת ארגון של Model Context Protocol, שמטרתו לספק יכולות שרת MCP ניתנות להרחבה, מאובטחות ותואמות רגולציה כשירות ענן. Azure MCP מאפשר לארגונים לפרוס, לנהל ולשלב שרתי MCP במהירות עם שירותי Azure AI, נתונים ואבטחה, תוך הפחתת עומס תפעולי והאצת אימוץ AI.

- אירוח שרת MCP מנוהל מלא עם יכולות סקיילינג, ניטור ואבטחה מובנות  
- אינטגרציה טבעית עם Azure OpenAI, Azure AI Search ושירותי Azure נוספים  
- אימות והרשאות ארגוניות דרך Microsoft Entra ID  
- תמיכה בכלים מותאמים, תבניות פקודות ומחברי משאבים  
- תאימות לדרישות אבטחה ורגולציה ארגוניות  

**יישום טכני:**  
```yaml
# Example: Azure MCP server deployment configuration (YAML)
apiVersion: mcp.microsoft.com/v1
kind: McpServer
metadata:
  name: enterprise-mcp-server
spec:
  modelProviders:
    - name: azure-openai
      type: AzureOpenAI
      endpoint: https://<your-openai-resource>.openai.azure.com/
      apiKeySecret: <your-azure-keyvault-secret>
  tools:
    - name: document_search
      type: AzureAISearch
      endpoint: https://<your-search-resource>.search.windows.net/
      apiKeySecret: <your-azure-keyvault-secret>
  authentication:
    type: EntraID
    tenantId: <your-tenant-id>
  monitoring:
    enabled: true
    logAnalyticsWorkspace: <your-log-analytics-id>
```

**תוצאות:**  
- קיצור זמן הגעה לערך בפרויקטי AI ארגוניים באמצעות פלטפורמת שרת MCP מוכנה לשימוש ותואמת  
- פישוט אינטגרציה של LLM, כלים ומקורות נתונים ארגוניים  
- שיפור האבטחה, הניטור והיעילות התפעולית בעומסי עבודה של MCP  

**הפניות:**  
- [תיעוד Azure MCP](https://aka.ms/azmcp)  
- [שירותי Azure AI](https://azure.microsoft.com/en-us/products/ai-services/)

## מחקר מקרה 6: NLWeb  
MCP (Model Context Protocol) הוא פרוטוקול מתפתח לצ'אטבוטים ועוזרי AI לאינטראקציה עם כלים. כל מופע של NLWeb הוא גם שרת MCP, התומך בשיטה מרכזית אחת, ask, המשמשת לשאילת שאלות לאתר בשפה טבעית. התשובה המוחזרת משתמשת ב-schema.org, אוצר מילים נפוץ לתיאור נתוני ווב. במובן כללי, MCP הוא כמו NLWeb ביחס ל-Http ל-HTML. NLWeb משלב פרוטוקולים, פורמטים של Schema.org וקוד לדוגמה כדי לעזור לאתרים ליצור במהירות נקודות קצה אלו, לטובת בני אדם דרך ממשקי שיחה ולמכונות דרך אינטראקציה טבעית בין סוכנים.

יש שני רכיבים מובחנים ל-NLWeb:  
- פרוטוקול פשוט להתחלה, לאינטראקציה עם אתר בשפה טבעית ובפורמט המשתמש ב-json ו-schema.org לתשובה המוחזרת. ראו את התיעוד על REST API לפרטים נוספים.  
- יישום פשוט של (1) המשתמש בסימון קיים, לאתרים שניתן להציג אותם כרשימות של פריטים (מוצרים, מתכונים, אטרקציות, ביקורות וכו'). יחד עם סט ווידג'טים לממשק משתמש, אתרים יכולים לספק בקלות ממשקי שיחה לתוכן שלהם. ראו את התיעוד על Life of a chat query לפרטים נוספים על אופן הפעולה.

**הפניות:**  
- [תיעוד Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### מחקר מקרה 7: MCP ל-Foundry – אינטגרציה של סוכני Azure AI

שרתים של Azure AI Foundry MCP מדגימים כיצד ניתן להשתמש ב-MCP לתזמור וניהול סוכני AI וזרימות עבודה בסביבות ארגוניות. באמצעות אינטגרציה של MCP עם Azure AI Foundry, ארגונים יכולים לאחד אינטראקציות סוכנים, לנצל את ניהול זרימות העבודה של Foundry ולהבטיח פריסות מאובטחות וניתנות להרחבה. גישה זו מאפשרת פרוטוטייפינג מהיר, ניטור חזק ואינטגרציה חלקה עם שירותי Azure AI, ותומכת בתרחישים מתקדמים כמו ניהול ידע והערכת סוכנים. מפתחים נהנים מממשק אחיד לבניית, פריסה וניטור צינורות סוכנים, בעוד צוותי IT מקבלים שיפור באבטחה, ציות ויעילות תפעולית. הפתרון אידיאלי לארגונים המעוניינים להאיץ אימוץ AI ולשמור על שליטה בתהליכים מורכבים מונעי סוכנים.

**הפניות:**  
- [מאגר GitHub של MCP Foundry](https://github.com/azure-ai-foundry/mcp-foundry)  
- [אינטגרציה של סוכני Azure AI עם MCP (בלוג Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### מחקר מקרה 8: Foundry MCP Playground – ניסויים ופרוטוטייפינג

Foundry MCP Playground מציע סביבה מוכנה לשימוש לניסויים עם שרתי MCP ואינטגרציות Azure AI Foundry. מפתחים יכולים במהירות ליצור אב-טיפוס, לבדוק ולהעריך מודלים וזרימות עבודה של סוכנים באמצעות משאבים מ-Azure AI Foundry Catalog ו-Labs. המגרש מפשט את ההקמה, מספק פרויקטים לדוגמה ותומך בפיתוח שיתופי, מה שמקל על חקירת שיטות עבודה מומלצות ותרחישים חדשים עם מינימום עומס. הוא שימושי במיוחד לצוותים המעוניינים לאמת רעיונות, לשתף ניסויים ולהאיץ למידה ללא צורך בתשתית מורכבת. בהורדת מחסום הכניסה, המגרש תורם לחדשנות ולתרומות קהילתיות באקוסיסטם של MCP ו-Azure AI Foundry.

**הפניות:**  
- [מאגר GitHub של Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### מחקר מקרה 9: שרת Microsoft Docs MCP – למידה וכישורים  
שרת Microsoft Docs MCP מיישם את Model Context Protocol (MCP) ומספק לעוזרי AI גישה בזמן אמת לתיעוד הרשמי של Microsoft. מבצע חיפוש סמנטי בתיעוד הטכני הרשמי של Microsoft.

**הפניות:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)

## פרויקטים מעשיים

### פרויקט 1: בניית שרת MCP עם מספר ספקים

**מטרה:** ליצור שרת MCP שיכול לנתב בקשות לספקי מודלים שונים על פי קריטריונים ספציפיים.

**דרישות:**  
- תמיכה לפחות בשלושה ספקי מודלים שונים (למשל OpenAI, Anthropic, מודלים מקומיים)  
- יישום מנגנון ניתוב מבוסס מטא-נתוני בקשה  
- יצירת מערכת קונפיגורציה לניהול אישורי ספקים  
- הוספת מטמון לאופטימיזציה של ביצועים ועלויות  
- בניית לוח בקרה פשוט למעקב שימוש  

**שלבי יישום:**  
1. הקמת תשתית שרת MCP בסיסית  
2. יישום מתאמי ספק לכל שירות מודל AI  
3. יצירת לוגיקת ניתוב על פי מאפייני בקשה  
4. הוספת מנגנוני מטמון לבקשות תכופות  
5. פיתוח לוח בקרה למעקב  
6. בדיקה עם דפוסי בקשה שונים  

**טכנולוגיות:** בחירה בין Python (.NET/Java/Python לפי העדפה), Redis למטמון, ומסגרת ווב פשוטה ללוח הבקרה.

### פרויקט 2: מערכת ניהול פקודות ארגונית

**מטרה:** לפתח מערכת מבוססת MCP לניהול, גרסאות ופריסה של תבניות פקודות בארגון.

**דרישות:**  
- יצירת מאגר מרכזי לתבניות פקודות  
- יישום ניהול גרסאות ותהליכי אישור  
- בניית יכולות בדיקת תבניות עם קלטים לדוגמה  
- פיתוח בקרות גישה מבוססות תפקידים  
- יצירת API לשליפה ופריסה של תבניות  

**שלבי יישום:**  
1. עיצוב סכמת מסד נתונים לאחסון תבניות  
2. יצירת API מרכזי לפעולות CRUD על תבניות  
3. יישום מערכת ניהול גרסאות  
4. בניית תהליך אישור  
5. פיתוח מסגרת בדיקות  
6. יצירת ממשק ווב פשוט לניהול  
7. אינטגרציה עם שרת MCP  

**טכנולוגיות:** בחירת מסגרת backend, מסד נתונים SQL או NoSQL, ומסגרת frontend לממשק הניהול.

### פרויקט 3: פלטפורמת יצירת תוכן מבוססת MCP

**מטרה:** לבנות פלטפורמה ליצירת תוכן המשתמשת ב-MCP כדי לספק תוצאות עקביות בסוגי תוכן שונים.

**דרישות:**  
- תמיכה בפורמטים שונים של תוכן (פוסטים בבלוג, רשתות חברתיות, טקסט שיווקי)  
- יישום יצירה מבוססת תבניות עם אפשרויות התאמה אישית  
- יצירת מערכת סקירה ומשוב לתוכן  
- מעקב אחר מדדי ביצועי תוכן  
- תמיכה בניהול גרסאות ואיטרציות של תוכן  

**שלבי יישום:**  
1. הקמת תשתית לקוח MCP  
2. יצירת תבניות לסוגי תוכן שונים  
3. בניית צינור יצירת תוכן  
4. יישום מערכת סקירה  
5. פיתוח מערכת מעקב מדדים  
6. יצירת ממשק משתמש לניהול תבניות ויצירת תוכן  

**טכנולוגיות:** שפת תכנות מועדפת, מסגרת ווב ומערכת מסד נתונים.

## כיוונים עתידיים לטכנולוגיית MCP

### מגמות מתפתחות

1. **MCP רב-מודלי**  
   - הרחבת MCP לאינטראקציה עם מודלים של תמונה, קול ווידאו  
   - פיתוח יכולות הסקה בין-מודליות  
   - פורמטים סטנדרטיים לפקודות במודאליות שונות  

2. **תשתית MCP מבוזרת**  
   - רשתות MCP מבוזרות לשיתוף משאבים בין ארגונים  
   - פרוטוקולים סטנדרטיים לשיתוף מודלים מאובטח  
   - טכניקות חישוב לשמירה על פרטיות  

3. **שווקי MCP**  
   - אקוסיסטמים לשיתוף ומונטיזציה של תבניות ותוספים ל-MCP  
   - תהליכי אבטחת איכות והסמכה  
   - אינטגרציה עם שווקי מודלים  

4. **MCP למחשוב קצה**  
   - התאמת תקני MCP למכשירי קצה עם משאבים מוגבלים  
   - פרוטוקולים מותאמים לסביבות רוחב פס נמוך  
   - יישומים מיוחדים של MCP לאקוסיסטמים של IoT  

5. **מסגרות רגולטוריות**  
   - פיתוח הרחבות MCP לציות לרגולציה  
   - מסלולי ביקורת ויכולות הסבר סטנדרטיות  
   - אינטגרציה עם מסגרות ממשל AI מתפתחות  

### פתרונות MCP של Microsoft

מיקרוסופט ו-Azure פיתחו מספר מאגרים בקוד פתוח המסייעים למפתחים ליישם MCP בתרחישים שונים:

#### ארגון Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - שרת Playwright MCP לאוטומציה ובדיקות בדפדפן  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - יישום שרת MCP ל-OneDrive לבדיקות מקומיות ותרומה לקהילה  
3. [NLWeb](https://github.com/microsoft/NlWeb) - אוסף פרוטוקולים וכלים בקוד פתוח, עם דגש על יצירת שכבת יסוד לאינטרנט AI  

#### ארגון Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - קישורים לדוגמאות, כלים ומשאבים לבניית ושילוב שרתי MCP ב-Azure בשפות שונות
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - דף נחיתה למימושי Remote MCP Server ב-Azure Functions עם קישורים למאגרי קוד לפי שפות  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - תבנית התחלה מהירה לבניית ופריסת שרתי Remote MCP מותאמים אישית באמצעות Azure Functions עם Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - תבנית התחלה מהירה לבניית ופריסת שרתי Remote MCP מותאמים אישית באמצעות Azure Functions עם .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - תבנית התחלה מהירה לבניית ופריסת שרתי Remote MCP מותאמים אישית באמצעות Azure Functions עם TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - ניהול API של Azure כ-Gateway לשרתי Remote MCP באמצעות Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - ניסויים ב-APIM ❤️ AI הכוללים יכולות MCP, אינטגרציה עם Azure OpenAI ו-AI Foundry  

מאגרי הקוד הללו מספקים מימושים, תבניות ומשאבים שונים לעבודה עם Model Context Protocol בשפות תכנות ושירותי Azure מגוונים. הם מכסים מגוון מקרים שימושיים, החל ממימושי שרת בסיסיים ועד לאימות, פריסת ענן ותסריטי אינטגרציה ארגונית.  

#### ספריית משאבי MCP  

ספריית [MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) במאגר הרשמי של Microsoft MCP מספקת אוסף מובחר של דוגמאות משאבים, תבניות פרומפט והגדרות כלים לשימוש עם שרתי Model Context Protocol. ספרייה זו נועדה לסייע למפתחים להתחיל במהירות עם MCP על ידי הצעת אבני בניין לשימוש חוזר ודוגמאות מיטביות ל:  

- **תבניות פרומפט:** תבניות מוכנות לשימוש למשימות ותסריטי AI נפוצים, שניתן להתאים למימושי שרת MCP משלכם.  
- **הגדרות כלים:** דוגמאות לסכמות כלים ומטא-נתונים לסטנדרטיזציה של אינטגרציה והפעלה של כלים בין שרתי MCP שונים.  
- **דוגמאות משאבים:** הגדרות משאבים לדוגמא לחיבור למקורות נתונים, APIs ושירותים חיצוניים במסגרת MCP.  
- **מימושים לדוגמה:** דוגמאות מעשיות שמדגימות כיצד לארגן ולבנות משאבים, פרומפטים וכלים בפרויקטים אמיתיים של MCP.  

משאבים אלה מאיצים את הפיתוח, מקדמים סטנדרטיזציה ועוזרים להבטיח שיטות עבודה מומלצות בעת בנייה ופריסה של פתרונות מבוססי MCP.  

#### ספריית משאבי MCP  
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  

### הזדמנויות מחקר  

- טכניקות אופטימיזציה יעילות לפרומפטים במסגרת MCP  
- מודלים של אבטחה לפריסות MCP מרובות שוכרים  
- מדידת ביצועים בין מימושי MCP שונים  
- שיטות אימות פורמליות לשרתי MCP  

## סיכום  

Model Context Protocol (MCP) מעצב במהירות את עתיד האינטגרציה הסטנדרטית, המאובטחת והמתפקדת של AI בתעשיות שונות. דרך מקרי הבוחן והפרויקטים המעשיים בשיעור זה, ראיתם כיצד מאמצים מוקדמים — כולל Microsoft ו-Azure — מנצלים את MCP כדי לפתור אתגרים אמיתיים, להאיץ אימוץ AI ולהבטיח תאימות, אבטחה וסקלאביליות. הגישה המודולרית של MCP מאפשרת לארגונים לחבר מודלים שפתיים גדולים, כלים ונתוני ארגונים במסגרת אחידה, ניתנת לביקורת. ככל ש-MCP ממשיך להתפתח, שמירה על מעורבות בקהילה, חקירת משאבים בקוד פתוח ויישום שיטות עבודה מומלצות יהיו המפתח לבניית פתרונות AI חזקים ומוכנים לעתיד.  

## משאבים נוספים  

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)  
- [MCP Resources Directory (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  
- [MCP Community & Documentation](https://modelcontextprotocol.io/introduction)  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Files MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)  
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)  
- [MCP Auth Servers (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)  
- [Remote MCP Functions (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)  
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)  
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)  
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)  
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)  
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

## תרגילים  

1. נתחו אחד ממקרי הבוחן והציעו גישה מימושית חלופית.  
2. בחרו אחד מרעיונות הפרויקטים וצרו מפרט טכני מפורט.  
3. חקרו תעשייה שלא נכללה במקרי הבוחן ופרטו כיצד MCP יכול להתמודד עם האתגרים הספציפיים שלה.  
4. חקרו אחד מהכיוונים העתידיים וצרו קונספט להרחבה חדשה של MCP לתמיכה בו.  

הבא: [Best Practices](../08-BestPractices/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.