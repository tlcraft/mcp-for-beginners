<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:24:59+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "he"
}
-->
# לקחים מאמצים מוקדמים

## סקירה כללית

השיעור הזה חוקר כיצד מאמצים מוקדמים ניצלו את Model Context Protocol (MCP) כדי לפתור אתגרים בעולם האמיתי ולקדם חדשנות בתעשיות שונות. באמצעות מקרי בוחן מפורטים ופרויקטים מעשיים, תראו כיצד MCP מאפשר אינטגרציה מאוחדת, מאובטחת וניתנת להרחבה של בינה מלאכותית—מחברת בין מודלים לשוניים גדולים, כלים ונתוני ארגונים במסגרת אחידה. תרכשו ניסיון מעשי בתכנון ובניית פתרונות מבוססי MCP, תלמדו מתבניות יישום מוכחות ותגלו שיטות עבודה מומלצות לפריסה בסביבות ייצור. השיעור גם מדגיש מגמות מתפתחות, כיוונים עתידיים ומשאבים בקוד פתוח שיעזרו לכם להישאר בחזית טכנולוגיית MCP והאקוסיסטם המתפתח שלה.

## מטרות הלמידה

- לנתח יישומים של MCP בעולם האמיתי בתעשיות שונות  
- לתכנן ולבנות אפליקציות שלמות מבוססות MCP  
- לחקור מגמות מתפתחות וכיוונים עתידיים בטכנולוגיית MCP  
- ליישם שיטות עבודה מומלצות בתרחישי פיתוח אמיתיים  

## יישומי MCP בעולם האמיתי

### מקרה בוחן 1: אוטומציה של תמיכת לקוחות בארגונים

תאגיד רב-לאומי יישם פתרון מבוסס MCP כדי לאחד את האינטראקציות של בינה מלאכותית במערכות תמיכת הלקוחות שלו. זה איפשר להם:

- ליצור ממשק אחיד לספקי LLM מרובים  
- לשמור על ניהול אחיד של הפקודות בין המחלקות  
- ליישם בקרות אבטחה וציות מחמירות  
- לעבור בקלות בין מודלים שונים לפי צרכים ספציפיים  

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

**תוצאות:** הפחתה של 30% בעלויות המודל, שיפור של 45% בעקביות התגובות, והגברת הציות בתפעול הגלובלי.

### מקרה בוחן 2: עוזר אבחון רפואי

ספק שירותי בריאות פיתח תשתית MCP לשילוב מספר מודלים רפואיים מומחים תוך שמירה על הגנת נתוני המטופלים:

- מעבר חלק בין מודלים רפואיים כלליים למומחים  
- בקרות פרטיות מחמירות ומעקבים מבוקרים  
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

**תוצאות:** שיפורים בהצעות אבחון לרופאים, תוך שמירה מלאה על תקני HIPAA והפחתה משמעותית במעברים בין מערכות.

### מקרה בוחן 3: ניתוח סיכונים בשירותים פיננסיים

מוסד פיננסי יישם MCP לאיחוד תהליכי ניתוח סיכונים במחלקות שונות:

- יצירת ממשק אחיד למודלים של סיכון אשראי, גילוי הונאות וסיכון השקעות  
- יישום בקרות גישה מחמירות וניהול גרסאות מודלים  
- הבטחת יכולת ביקורת לכל ההמלצות של הבינה המלאכותית  
- שמירה על פורמט נתונים אחיד בין מערכות מגוונות  

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

**תוצאות:** הגברת הציות הרגולטורי, קיצור מחזורי פריסה של מודלים ב-40%, ושיפור בעקביות הערכת הסיכונים במחלקות.

### מקרה בוחן 4: שרת Playwright MCP של Microsoft לאוטומציה בדפדפן

Microsoft פיתחה את [Playwright MCP server](https://github.com/microsoft/playwright-mcp) כדי לאפשר אוטומציה מאובטחת ומאוחדת של דפדפנים דרך Model Context Protocol. הפתרון מאפשר לסוכני AI ול-LLMs לתקשר עם דפדפנים באופן מבוקר, ניתן לביקורת ומורחב—ומאפשר שימושים כמו בדיקות אוטומטיות, חילוץ נתונים וזרימות עבודה מקצה לקצה.

- מציג יכולות אוטומציה בדפדפן (ניווט, מילוי טפסים, צילום מסך וכו') ככלי MCP  
- מיישם בקרות גישה מחמירות וסביבת סנדבוקס למניעת פעולות בלתי מורשות  
- מספק יומני ביקורת מפורטים לכל האינטראקציות בדפדפן  
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
- אפשר אוטומציה מאובטחת ומבוקרת של דפדפנים לסוכני AI ול-LLMs  
- הפחית את המאמץ בבדיקות ידניות ושיפר את כיסוי הבדיקות לאפליקציות ווב  
- סיפק מסגרת חוזרת ומורחבת לאינטגרציה של כלים מבוססי דפדפן בסביבות ארגוניות  

**הפניות:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### מקרה בוחן 5: Azure MCP – Model Context Protocol ארגוני כשירות

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) הוא יישום מנוהל, ארגוני וניתן להרחבה של Model Context Protocol, שמטרתו לספק יכולות שרת MCP מאובטחות וציות כשירות בענן. Azure MCP מאפשר לארגונים לפרוס, לנהל ולשלב שרתי MCP במהירות עם שירותי Azure AI, נתונים ואבטחה, תוך הפחתת עומסי תפעול והאצת אימוץ בינה מלאכותית.

- אירוח שרת MCP מנוהל במלואו עם יכולות סקיילינג, ניטור ואבטחה מובנות  
- אינטגרציה טבעית עם Azure OpenAI, Azure AI Search ושירותי Azure נוספים  
- אימות והרשאות ארגוניות באמצעות Microsoft Entra ID  
- תמיכה בכלים מותאמים, תבניות פקודות ומחברים למשאבים  
- עמידה בדרישות אבטחה ורגולציה ארגוניות  

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
- קיצור זמן הגעה לערך בפרויקטי AI ארגוניים באמצעות פלטפורמת שרת MCP מוכנה לשימוש וציות  
- פישוט אינטגרציה של LLMs, כלים ומקורות נתונים ארגוניים  
- שיפור האבטחה, הנראות והיעילות התפעולית לעומסי MCP  

**הפניות:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## מקרה בוחן 6: NLWeb  
MCP (Model Context Protocol) הוא פרוטוקול מתפתח עבור צ'אטבוטים ועוזרי AI לתקשר עם כלים. כל מופע של NLWeb הוא גם שרת MCP התומך בשיטה מרכזית אחת, ask, המשמשת לשאילת שאלות לאתר בשפה טבעית. התגובה המוחזרת משתמשת ב-schema.org, אוצר מילים נפוץ לתיאור נתוני רשת. במובן רחב, MCP הוא NLWeb כפי ש-Http הוא ל-HTML. NLWeb משלבת פרוטוקולים, פורמטים של Schema.org וקוד דוגמה כדי לעזור לאתרים ליצור במהירות נקודות קצה אלה, המועילות הן לבני אדם דרך ממשקי שיחה והן למכונות באינטראקציה טבעית בין סוכנים.

ל-NLWeb שני רכיבים מובחנים:  
- פרוטוקול פשוט להתחלה, לממשק עם אתר בשפה טבעית ופורמט המשתמש ב-json ו-schema.org לתשובה המוחזרת. ראו את התיעוד על REST API לפרטים נוספים.  
- יישום פשוט של (1) המשתמש בסימון קיים, לאתרים שניתן להציג אותם כרשימות פריטים (מוצרים, מתכונים, אטרקציות, ביקורות וכו'). יחד עם סט ווידג'טים לממשק משתמש, אתרים יכולים לספק ממשקי שיחה לתוכן שלהם בקלות. ראו את התיעוד על Life of a chat query לפרטים נוספים על אופן הפעולה.  

**הפניות:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### מקרה בוחן 7: MCP ל-Foundry – אינטגרציה של סוכני Azure AI

שרתי Azure AI Foundry MCP מדגימים כיצד ניתן להשתמש ב-MCP לאורקסטרציה וניהול סוכני AI וזרימות עבודה בסביבות ארגוניות. באמצעות אינטגרציה של MCP עם Azure AI Foundry, ארגונים יכולים לאחד אינטראקציות סוכנים, לנצל את ניהול זרימות העבודה של Foundry ולהבטיח פריסות מאובטחות וניתנות להרחבה. גישה זו מאפשרת יצירת אב-טיפוס מהירה, ניטור חזק ואינטגרציה חלקה עם שירותי Azure AI, ותומכת בתרחישים מתקדמים כגון ניהול ידע והערכת סוכנים. מפתחים נהנים מממשק אחיד לבניית, פריסה וניטור צינורות סוכנים, וצוותי IT זוכים לשיפור באבטחה, ציות ויעילות תפעולית. הפתרון אידיאלי לארגונים המבקשים להאיץ אימוץ AI ולשמור על שליטה בתהליכים מורכבים המונעים על ידי סוכנים.

**הפניות:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### מקרה בוחן 8: Foundry MCP Playground – ניסויים ואב-טיפוס

Foundry MCP Playground מציע סביבה מוכנה לשימוש לניסויים עם שרתי MCP ואינטגרציות Azure AI Foundry. מפתחים יכולים במהירות ליצור אב-טיפוס, לבדוק ולהעריך מודלי AI וזרימות עבודה של סוכנים באמצעות משאבים מקטלוג ומעבדות Azure AI Foundry. המגרש מפשט את ההקמה, מספק פרויקטים לדוגמה ותומך בפיתוח שיתופי, מה שמקל על חקירת שיטות עבודה מומלצות ותסריטים חדשים עם עומס מינימלי. הוא שימושי במיוחד לצוותים המעוניינים לאמת רעיונות, לשתף ניסויים ולהאיץ למידה ללא צורך בתשתית מורכבת. בהורדת מחסום הכניסה, המגרש תורם לחדשנות ולקידום קהילתי באקוסיסטם של MCP ו-Azure AI Foundry.

**הפניות:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

### מקרה בוחן 9: שרת Microsoft Docs MCP – למידה וכישורים  
שרת Microsoft Docs MCP מיישם את Model Context Protocol (MCP) ומספק לעוזרי AI גישה בזמן אמת לתיעוד הרשמי של Microsoft. מבצע חיפוש סמנטי מול התיעוד הטכני הרשמי של Microsoft.

**הפניות:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)  

## פרויקטים מעשיים

### פרויקט 1: בניית שרת MCP רב-ספקי

**מטרה:** ליצור שרת MCP שיכול לנתב בקשות למספר ספקי מודלים של AI בהתאם לקריטריונים ספציפיים.

**דרישות:**  
- תמיכה לפחות בשלושה ספקי מודלים שונים (למשל OpenAI, Anthropic, מודלים מקומיים)  
- יישום מנגנון ניתוב מבוסס מטא-נתוני בקשה  
- יצירת מערכת תצורה לניהול אישורי ספקים  
- הוספת מטמון לאופטימיזציה של ביצועים ועלויות  
- בניית לוח בקרה פשוט למעקב שימוש  

**שלבי יישום:**  
1. הקמת תשתית שרת MCP בסיסית  
2. יישום מתאמים לספקי מודלים לכל שירות AI  
3. יצירת לוגיקת ניתוב על בסיס תכונות הבקשה  
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
2. יצירת API בסיסי לפעולות CRUD על תבניות  
3. יישום מערכת ניהול גרסאות  
4. בניית תהליך אישור  
5. פיתוח מסגרת בדיקות  
6. יצירת ממשק ווב פשוט לניהול  
7. אינטגרציה עם שרת MCP  

**טכנולוגיות:** בחירת מסגרת backend, מסד SQL או NoSQL, ומסגרת frontend לממשק הניהול.

### פרויקט 3: פלטפורמת יצירת תוכן מבוססת MCP

**מטרה:** לבנות פלטפורמה ליצירת תוכן המשתמשת ב-MCP לספק תוצאות עקביות בסוגי תוכן שונים.

**דרישות:**  
- תמיכה בפורמטים שונים של תוכן (פוסטים לבלוג, רשתות חברתיות, טקסט שיווקי)  
- יישום יצירה מבוססת תבניות עם אפשרויות התאמה אישית  
- יצירת מערכת סקירה ומשוב לתוכן  
- מעקב אחרי מדדי ביצועי תוכן  
- תמיכה בניהול גרסאות ואיטרציות של תוכן  

**שלבי יישום:**  
1. הקמת תשתית לקוח MCP  
2. יצירת תבניות לסוגי תוכן שונים  
3. בניית צינור יצירת תוכן  
4. יישום מערכת סקירה  
5. פיתוח מערכת מעקב מדדים  
6. יצירת ממשק משתמש לניהול תבניות ויצירת תוכן  

**טכנולוגיות:** שפת תכנות מועדפת, מסגרת ווב, ומערכת מסד נתונים.

## כיוונים עתידיים בטכנולוגיית MCP

### מגמות מתפתחות

1. **MCP רב-מודלי**  
   - הרחבת MCP לאינטראקציות עם מודלים של תמונה, קול ווידאו  
   - פיתוח יכולות הסקה חוצות-מודלים  
   - פורמטים סטנדרטיים לפקודות במודאליות שונות  

2. **תשתית MCP מבוזרת**  
   - רשתות MCP מבוזרות לשיתוף משאבים בין ארגונים  
   - פרוטוקולים סטנדרטיים לשיתוף מודלים מאובטח  
   - טכניקות חישוב לשמירת פרטיות  

3. **שווקי MCP**  
   - אקוסיסטמים לשיתוף ומוניטיזציה של תבניות ותוספים ל-MCP  
   - תהליכי אבטחת איכות והסמכה  
   - אינטגרציה עם שווקי מודלים  

4. **MCP למחשוב קצה**  
   - התאמת תקני MCP למכשירי קצה עם משאבים מוגבלים  
   - פרוטוקולים מותאמים לסביבות ברוחב פס נמוך  
   - יישומים מיוחדים ל-MCP באקוסיסטם IoT  

5. **מסגרות רגולטוריות**  
   - פיתוח הרחבות MCP לציות לרגולציה  
   - מסלולי ביקורת סטנדרטיים וממשקי הסבר  
   - אינטגרציה עם מסגרות ממשל AI מתפתחות  

### פתרונות MCP של Microsoft

Microsoft ו-Azure פיתחו מספר מאגרים בקוד פתוח לסייע למפתחים ליישם MCP בתרחישים שונים:

#### ארגון Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - שרת Playwright MCP לאוטומציה ובדיקות בדפדפן  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - יישום שרת MCP ל-OneDrive לבדיקות מקומיות ותרומות קהילתיות  
3. [NLWeb](https://github.com/microsoft/NlWeb) - אוסף פרוטוקולים פתוחים וכלים פתוחים נלווים, עם דגש על שכבת יסוד לרשת AI  

#### ארגון Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - קישורים לדוגמאות, כלים ומשאבים לבניית ושילוב שרתי MCP ב-Azure בשפות שונות  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - שרתי MCP לדוג
- [קהילת MCP ותיעוד](https://modelcontextprotocol.io/introduction)
- [תיעוד Azure MCP](https://aka.ms/azmcp)
- [מאגר GitHub של שרת Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [שרת Files MCP (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [שרתים לאימות MCP (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [פונקציות מרחוק MCP (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [פונקציות מרחוק MCP בפייתון (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [פונקציות מרחוק MCP ב-.NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [פונקציות מרחוק MCP ב-TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [פונקציות APIM מרחוק MCP בפייתון (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [פתרונות AI ואוטומציה של Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

## תרגילים

1. נתחו אחת ממקרי המבחן והציעו גישה חלופית ליישום.
2. בחרו אחד מרעיונות הפרויקט וצרו מפרט טכני מפורט.
3. חקרו ענף שלא נכלל במקרי המבחן ופרטו כיצד MCP יכול להתמודד עם האתגרים הייחודיים שלו.
4. חקרו אחד מהכיוונים העתידיים וצרו קונספט להרחבה חדשה של MCP לתמיכה בו.

הבא: [Best Practices](../08-BestPractices/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפתו המקורית נחשב למקור המהימן. למידע קריטי מומלץ להשתמש בתרגום מקצועי של אדם. איננו אחראים לכל אי-הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.