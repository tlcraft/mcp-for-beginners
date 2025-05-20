<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T17:34:55+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "he"
}
-->
# לקחים ממאמינים מוקדמים

## סקירה כללית

השיעור הזה חוקר כיצד מאמצים מוקדמים ניצלו את Model Context Protocol (MCP) כדי לפתור אתגרים אמיתיים ולהניע חדשנות בתעשיות שונות. דרך מחקרי מקרה מפורטים ופרויקטים מעשיים, תראו כיצד MCP מאפשר אינטגרציה אחידה, מאובטחת וניתנת להרחבה של בינה מלאכותית — מחבר מודלים לשוניים גדולים, כלים ונתוני ארגונים במסגרת אחת. תרכשו ניסיון מעשי בעיצוב ובנייה של פתרונות מבוססי MCP, תלמדו מדפוסי יישום מוכחים ותגלו שיטות עבודה מומלצות לפריסה בסביבות ייצור. השיעור מדגיש גם מגמות מתפתחות, כיוונים עתידיים ומשאבים בקוד פתוח שיעזרו לכם להישאר בחזית טכנולוגיית MCP והאקוסיסטם המתפתח שלה.

## מטרות הלמידה

- לנתח יישומים אמיתיים של MCP בתעשיות שונות  
- לעצב ולבנות אפליקציות שלמות מבוססות MCP  
- לחקור מגמות מתפתחות וכיוונים עתידיים בטכנולוגיית MCP  
- ליישם שיטות עבודה מומלצות בתרחישי פיתוח מעשיים  

## יישומים אמיתיים של MCP

### מחקר מקרה 1: אוטומציה של תמיכת לקוחות ארגונית

תאגיד רב-לאומי יישם פתרון מבוסס MCP כדי לאחד את האינטראקציות עם בינה מלאכותית במערכות התמיכה בלקוחות שלו. זה אפשר להם:

- ליצור ממשק אחיד לספקי LLM שונים  
- לשמור על ניהול אחיד של הפרומפטים במחלקות השונות  
- ליישם בקרות אבטחה וציות מחמירות  
- לעבור בקלות בין מודלים שונים של בינה מלאכותית לפי הצורך  

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

**תוצאות:** הפחתה של 30% בעלויות המודלים, שיפור של 45% באחידות התגובות, ושיפור הציות ברחבי הפעילות הגלובלית.

### מחקר מקרה 2: עוזר אבחוני בתחום הבריאות

ספק שירותי בריאות פיתח תשתית MCP לשילוב מספר מודלים רפואיים מתמחים, תוך שמירה על הגנה על נתוני מטופלים רגישים:

- מעבר חלק בין מודלים רפואיים כלליים למומחים  
- בקרות פרטיות מחמירות ומעקבים ביקורתיים  
- אינטגרציה עם מערכות רשומות רפואיות אלקטרוניות (EHR) קיימות  
- הנדסת פרומפט עקבית למונחים רפואיים  

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

**תוצאות:** שיפורים בהצעות אבחוניות לרופאים, שמירה מלאה על דרישות HIPAA, והפחתה משמעותית במעבר בין מערכות.

### מחקר מקרה 3: ניתוח סיכוני שירותים פיננסיים

מוסד פיננסי יישם MCP לאיחוד תהליכי ניתוח סיכונים במחלקות שונות:

- יצירת ממשק אחיד למודלים של סיכון אשראי, גילוי הונאות וסיכון השקעות  
- יישום בקרות גישה מחמירות וניהול גרסאות מודל  
- הבטחת מעקב ביקורתי לכל ההמלצות של הבינה המלאכותית  
- שמירה על פורמט נתונים עקבי במערכות מגוונות  

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

**תוצאות:** שיפור הציות לרגולציה, קיצור מחזורי פריסת מודלים ב-40%, ושיפור עקביות הערכת הסיכון במחלקות.

### מחקר מקרה 4: שרת Microsoft Playwright MCP לאוטומציה בדפדפן

מיקרוסופט פיתחה את [Playwright MCP server](https://github.com/microsoft/playwright-mcp) כדי לאפשר אוטומציה מאובטחת וסטנדרטית בדפדפנים דרך Model Context Protocol. פתרון זה מאפשר לסוכני בינה מלאכותית ול-LLMs אינטראקציה עם דפדפנים באופן מבוקר, ניתן לביקורת ומורחב — ומאפשר שימושים כגון בדיקות ווב אוטומטיות, חילוץ נתונים, וזרימות עבודה מקצה לקצה.

- חושף יכולות אוטומציה בדפדפן (ניווט, מילוי טפסים, צילום מסך וכו') ככלי MCP  
- מיישם בקרות גישה מחמירות וסביבות מבודדות למניעת פעולות לא מורשות  
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
- אפשר אוטומציה מאובטחת ומבוקרת של דפדפנים לסוכני בינה מלאכותית ו-LLMs  
- צמצם את המאמץ בבדיקות ידניות ושיפר את כיסוי הבדיקות של אפליקציות ווב  
- סיפק מסגרת חוזרת ומורחבת לאינטגרציה של כלים מבוססי דפדפן בסביבות ארגוניות  

**מקורות:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### מחקר מקרה 5: Azure MCP – Model Context Protocol ברמת ארגון כשירות

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) הוא מימוש מנוהל ומותאם ארגונית של Model Context Protocol, המציע יכולות שרת MCP ניתנות להרחבה, מאובטחות ותואמות רגולציה כשירות ענן. Azure MCP מאפשר לארגונים לפרוס, לנהל ולשלב במהירות שרתי MCP עם שירותי Azure AI, נתונים ואבטחה, מפחית עומסי תפעול ומאיץ את אימוץ הבינה המלאכותית.

- אירוח שרתי MCP מנוהל במלואו עם יכולות סקיילינג, ניטור ואבטחה מובנות  
- אינטגרציה טבעית עם Azure OpenAI, Azure AI Search ושירותי Azure נוספים  
- אימות והרשאות ארגוניות דרך Microsoft Entra ID  
- תמיכה בכלים מותאמים, תבניות פרומפט וקונקטורים למשאבים  
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
- פישוט אינטגרציה של LLMs, כלים ומקורות נתונים ארגוניים  
- שיפור אבטחה, נראות ויעילות תפעולית לעומסי עבודה מבוססי MCP  

**מקורות:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## מחקר מקרה 6: NLWeb  
MCP הוא פרוטוקול מתפתח המאפשר לצ'אטבוטים ועוזרי AI אינטראקציה עם כלים. כל מופע של NLWeb הוא גם שרת MCP התומך בשיטה מרכזית אחת, ask, המשמשת לשאילת שאלות לאתר בשפה טבעית. התגובה המוחזרת משתמשת ב-schema.org, אוצר מילים נפוץ לתיאור נתוני ווב. במובן רחב, MCP הוא NLWeb כפי ש-Http הוא ל-HTML. NLWeb משלב פרוטוקולים, פורמטים של Schema.org וקוד דוגמה כדי לעזור לאתרים ליצור במהירות נקודות קצה אלו, המועילות הן לבני אדם דרך ממשקי שיחה והן למכונות דרך אינטראקציה טבעית בין סוכנים.

ל-NLWeb שני רכיבים מובחנים:  
- פרוטוקול פשוט המאפשר ממשק שיחה עם אתר בשפה טבעית ופורמט מבוסס json ו-schema.org לתשובה. ראו תיעוד REST API לפרטים.  
- מימוש פשוט של (1) המשתמש בסימון קיים לאתרים שניתן להכליל אותם כרשימות פריטים (מוצרים, מתכונים, אטרקציות, ביקורות וכו'). יחד עם וידג'טים לממשק משתמש, אתרים יכולים לספק ממשקי שיחה לתוכן שלהם בקלות. ראו תיעוד Life of a chat query לפרטים נוספים על אופן הפעולה.  

**מקורות:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### מחקר מקרה 7: MCP ל-Foundry – שילוב סוכני Azure AI

שרתי Azure AI Foundry MCP מדגימים כיצד ניתן להשתמש ב-MCP לארכיטקטורה וניהול סוכני AI וזרימות עבודה בסביבות ארגוניות. באמצעות שילוב MCP עם Azure AI Foundry, ארגונים יכולים לאחד אינטראקציות סוכנים, לנצל ניהול זרימות עבודה של Foundry, ולהבטיח פריסות מאובטחות וניתנות להרחבה. גישה זו מאפשרת פרוטוטייפ מהיר, ניטור חזק ואינטגרציה חלקה עם שירותי Azure AI, ותומכת בתרחישים מתקדמים כמו ניהול ידע והערכת סוכנים. מפתחים נהנים מממשק אחיד לבניית, פריסה וניטור צינורות סוכנים, בעוד צוותי IT מקבלים שיפור באבטחה, ציות ויעילות תפעולית. הפתרון אידיאלי לארגונים המעוניינים להאיץ אימוץ AI ולשמור על שליטה בתהליכים מורכבים המונעים על ידי סוכנים.

**מקורות:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### מחקר מקרה 8: Foundry MCP Playground – ניסויים ופרוטוטייפינג

Foundry MCP Playground מציע סביבה מוכנה לשימוש לניסויים עם שרתי MCP ואינטגרציות Azure AI Foundry. מפתחים יכולים במהירות ליצור פרוטוטייפ, לבדוק ולהעריך מודלים של AI וזרימות עבודה של סוכנים באמצעות משאבים מ-Azure AI Foundry Catalog ו-Labs. המגרש מפשט הקמה, מספק פרויקטים לדוגמה ותומך בפיתוח שיתופי, מה שמקל על חקר שיטות עבודה מומלצות ותסריטים חדשים עם עומס מינימלי. הוא מועיל במיוחד לצוותים שרוצים לאמת רעיונות, לשתף ניסויים ולהאיץ למידה ללא צורך בתשתית מורכבת. בהורדת מחסום הכניסה, המגרש תורם לחדשנות ולתרומות קהילתיות באקוסיסטם MCP ו-Azure AI Foundry.

**מקורות:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## פרויקטים מעשיים

### פרויקט 1: בניית שרת MCP עם מספר ספקים

**מטרה:** ליצור שרת MCP שיכול לכוון בקשות למספר ספקי מודלים של AI על פי קריטריונים ספציפיים.

**דרישות:**  
- תמיכה בלפחות שלושה ספקי מודלים שונים (למשל OpenAI, Anthropic, מודלים מקומיים)  
- יישום מנגנון ניתוב מבוסס מטא-נתוני בקשה  
- יצירת מערכת תצורה לניהול אישורי ספקים  
- הוספת מטמון לאופטימיזציה של ביצועים ועלויות  
- בניית לוח בקרה פשוט לניטור השימוש  

**שלבי יישום:**  
1. הקמת תשתית בסיסית של שרת MCP  
2. יישום מתאמי ספקים לכל שירות מודל AI  
3. יצירת לוגיקת ניתוב על פי תכונות הבקשה  
4. הוספת מנגנוני מטמון לבקשות תכופות  
5. פיתוח לוח בקרה לניטור  
6. בדיקה עם תבניות בקשה שונות  

**טכנולוגיות:** בחירה בין Python (.NET/Java/Python לפי העדפתך), Redis למטמון, ומסגרת ווב פשוטה ללוח הבקרה.

### פרויקט 2: מערכת ניהול פרומפט ארגונית

**מטרה:** לפתח מערכת מבוססת MCP לניהול, ניהול גרסאות ופריסה של תבניות פרומפט בארגון.

**דרישות:**  
- יצירת מאגר מרכזי לתבניות פרומפט  
- יישום ניהול גרסאות ותהליכי אישור  
- בניית יכולות בדיקת תבניות עם קלטים לדוגמה  
- פיתוח בקרות גישה מבוססות תפקידים  
- יצירת API לשליפת תבניות ופריסה  

**שלבי יישום:**  
1. עיצוב סכמת מסד נתונים לאחסון תבניות  
2. יצירת API בסיסי לפעולות CRUD על תבניות  
3. יישום מערכת ניהול גרסאות  
4. בניית תהליך אישור  
5. פיתוח מסגרת בדיקה  
6. יצירת ממשק ווב פשוט לניהול  
7. אינטגרציה עם שרת MCP  

**טכנולוגיות:** בחירתך במסגרת backend, מסד נתונים SQL או NoSQL, ומסגרת frontend לממשק הניהול.

### פרויקט 3: פלטפורמת יצירת תוכן מבוססת MCP

**מטרה:** לבנות פלטפורמה ליצירת תוכן המשתמשת ב-MCP כדי לספק תוצאות עקביות בסוגי תוכן שונים.

**דרישות:**  
- תמיכה בפורמטים שונים של תוכן (פוסטים בבלוג, מדיה חברתית, טקסט שיווקי)  
- יישום יצירה מבוססת תבניות עם אפשרויות התאמה אישית  
- יצירת מערכת לסקירה ומשוב על תוכן  
- מעקב אחר מדדי ביצועי תוכן  
- תמיכה בניהול גרסאות ועריכה  

**שלבי יישום:**  
1. הקמת תשתית לקוח MCP  
2. יצירת תבניות לסוגי תוכן שונים  
3. בניית צינור יצירת תוכן  
4. יישום מערכת סקירה  
5. פיתוח מערכת מעקב מדדים  
6. יצירת ממשק משתמש לניהול תבניות ויצירת תוכן  

**טכנולוגיות:** שפת תכנות מועדפת, מסגרת ווב ומסד נתונים.

## כיוונים עתידיים לטכנולוגיית MCP

### מגמות מתפתחות

1. **MCP רב-מודלי**  
   - הרחבת MCP לאינטראקציה סטנדרטית עם מודלים של תמונה, אודיו ווידאו  
   - פיתוח יכולות חשיבה חוצת מודלים  
   - פורמטים סטנדרטיים לפרומפטים למודאליות שונות  

2. **תשתית MCP מבוזרת**  
   - רשתות MCP מבוזרות לשיתוף משאבים בין ארגונים  
   - פרוטוקולים סטנדרטיים לשיתוף מודלים מאובטח  
   - טכניקות חישוב לשמירה על פרטיות  

3. **שווקי MCP**  
   - אקוסיסטמים לשיתוף ומונטיזציה של תבניות ותוספים של MCP  
   - תהליכי בקרת איכות והסמכה  
   - אינטגרציה עם שווקי מודלים  

4. **MCP למחשוב קצה**  
   - התאמת תקני MCP למכשירי קצה עם משאבים מוגבלים  
   - פרוטוקולים מותאמים לסביבות רוחב פס נמוך  
   - מימושי MCP מיוחדים לאקוסיסטם IoT  

5. **מסגרות רגולטוריות**  
   - פיתוח הרחבות MCP לציות לרגולציה  
   - מעקבים ביקורתיים ויכולות הסבר סטנדרטיות  
   - אינטגרציה עם מסגרות ממשל AI מתפתחות  

### פתרונות MCP של מיקרוסופט

מיקרוסופט ו-Azure פיתחו מספר מאגרים בקוד פתוח כדי לסייע למפתחים ליישם MCP בתרחישים שונים:

#### ארגון Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – שרת MCP ל-Playwright לאוטומציה ובדיקות בדפדפן  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – מימוש שרת MCP ל-OneDrive לבדיקות מקומיות ותרומות קהילתיות  
3. [NLWeb](https://github.com/microsoft/NlWeb) – אוסף פרוטוקולים פתוחים וכלים בקוד פתוח, עם דגש על שכבת יסוד לרשת AI  

#### ארגון Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) – קישורים לדוגמאות, כלים ומשאבים לבניית אינטגרציית שרתי MCP ב-Azure בשפות שונות  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – שרתי MCP לדוגמה המדגימים אימות לפי מפרט Model Context Protocol  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – דף נחיתה למימושי שרת MCP מרוחק ב-Azure Functions עם קישורים לרפוזיטוריות לפי שפה  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) –
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

1. נתחו אחד ממקרי המבחן והציעו גישה חלופית ליישום.
2. בחרו אחד מרעיונות הפרויקט וצרו מפרט טכני מפורט.
3. חקרו תעשייה שלא נכללה במקרי המבחן ופרטו כיצד MCP יכול להתמודד עם האתגרים הספציפיים שלה.
4. חקרו אחת מהכיוונים העתידיים וצרו קונספט להרחבה חדשה של MCP לתמיכה בה.

הבא: [Best Practices](../08-BestPractices/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא אחראים לכל אי-הבנה או פרשנות שגויה הנובעים מהשימוש בתרגום זה.