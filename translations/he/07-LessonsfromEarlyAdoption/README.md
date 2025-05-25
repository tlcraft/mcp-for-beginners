<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T21:57:55+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "he"
}
-->
# לקחים מאימוץ מוקדם

## סקירה כללית

השיעור הזה בוחן כיצד מאמצים מוקדמים השתמשו ב-Model Context Protocol (MCP) כדי לפתור אתגרים בעולם האמיתי ולקדם חדשנות בתעשיות שונות. דרך מחקרי מקרה מפורטים ופרויקטים מעשיים, תראו כיצד MCP מאפשר אינטגרציה מאוחדת, מאובטחת וניתנת להרחבה של בינה מלאכותית – מחבר בין מודלים לשוניים גדולים, כלים ונתוני ארגונים במסגרת אחת. תרכשו ניסיון מעשי בעיצוב ובניית פתרונות מבוססי MCP, תלמדו מדפוסי יישום מוכחים ותגלו שיטות עבודה מומלצות לפריסת MCP בסביבות ייצור. השיעור גם מדגיש מגמות מתפתחות, כיווני עתיד ומשאבים בקוד פתוח שיעזרו לכם להישאר בחזית הטכנולוגיה והאקוסיסטם המתפתח של MCP.

## מטרות הלמידה

- לנתח יישומי MCP מעשיים בתעשיות שונות  
- לעצב ולבנות אפליקציות שלמות מבוססות MCP  
- לחקור מגמות מתפתחות וכיווני עתיד בטכנולוגיית MCP  
- ליישם שיטות עבודה מומלצות בתרחישי פיתוח אמיתיים  

## יישומי MCP מעשיים

### מחקר מקרה 1: אוטומציה בתמיכה ללקוח בארגונים גדולים

תאגיד רב-לאומי יישם פתרון מבוסס MCP לאיחוד אינטראקציות הבינה המלאכותית במערכות התמיכה בלקוחות שלו. זה איפשר להם:

- ליצור ממשק אחיד לספקי LLM מרובים  
- לשמור על ניהול עקבי של פרומפטים במחלקות שונות  
- ליישם בקרות אבטחה וציות מחמירות  
- לעבור בקלות בין מודלים שונים של AI בהתאם לצרכים ספציפיים  

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

**תוצאות:** הפחתה של 30% בעלויות המודל, שיפור של 45% בעקביות התגובות, והגברת הציות בתקיפות בפעילות גלובלית.

### מחקר מקרה 2: עוזר אבחון בתחום הבריאות

ספק שירותי בריאות פיתח תשתית MCP לשילוב מספר מודלים רפואיים ממוקדים תוך שמירה על הגנת מידע רגיש של מטופלים:

- מעבר חלק בין מודלים כלליים למומחים רפואיים  
- בקרות פרטיות מחמירות ומסלולי ביקורת  
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

**תוצאות:** שיפור בהצעות אבחון לרופאים תוך שמירה מלאה על תקני HIPAA והפחתה משמעותית במעברים בין מערכות.

### מחקר מקרה 3: ניתוח סיכונים בשירותים פיננסיים

מוסד פיננסי יישם MCP לאיחוד תהליכי ניתוח סיכונים במחלקות שונות:

- יצירת ממשק אחיד למודלים של סיכון אשראי, גילוי הונאות וסיכון השקעות  
- יישום בקרות גישה מחמירות וניהול גרסאות מודל  
- הבטחת אפשרות ביקורת לכל ההמלצות של ה-AI  
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

**תוצאות:** שיפור בציות לרגולציה, קיצור מחזורי פריסה ב-40%, ושיפור עקביות הערכת הסיכון במחלקות.

### מחקר מקרה 4: שרת Playwright MCP של Microsoft לאוטומציה בדפדפן

מיקרוסופט פיתחה את [Playwright MCP server](https://github.com/microsoft/playwright-mcp) לאוטומציה מאובטחת ומאוחדת של דפדפנים דרך Model Context Protocol. פתרון זה מאפשר לסוכני AI ו-LLMs לתקשר עם דפדפנים באופן מבוקר, ניתן לביקורת ומורחב – מאפשר שימושים כמו בדיקות ווב אוטומטיות, חילוץ נתונים, וזרימות עבודה מקצה לקצה.

- מציג יכולות אוטומציה של דפדפן (ניווט, מילוי טפסים, צילום מסך וכו') ככלים ב-MCP  
- מיישם בקרות גישה מחמירות וסביבות מבודדות למניעת פעולות בלתי מורשות  
- מספק יומני ביקורת מפורטים לכל האינטראקציות עם הדפדפן  
- תומך באינטגרציה עם Azure OpenAI וספקי LLM נוספים לאוטומציה מונחית סוכנים  

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
- אפשר אוטומציה מאובטחת ומונחית תוכנית לסוכני AI ו-LLMs  
- הפחית מאמץ בבדיקות ידניות ושיפר כיסוי בדיקות לאפליקציות ווב  
- סיפק מסגרת שימושית ומורחבת לאינטגרציה של כלים מבוססי דפדפן בסביבות ארגוניות  

**הפניות:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### מחקר מקרה 5: Azure MCP – Model Context Protocol ארגוני כשירות

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) הוא יישום מנוהל וארגוני של Model Context Protocol מבית מיקרוסופט, המציע יכולות שרת MCP ניתנות להרחבה, מאובטחות ותואמות רגולציה כשירות ענן. Azure MCP מאפשר לארגונים לפרוס, לנהל ולשלב שרתי MCP עם שירותי Azure AI, נתונים ואבטחה במהירות, תוך הפחתת עומס תפעולי והאצת אימוץ AI.

- אירוח שרתי MCP מנוהל עם יכולות סקיילינג, ניטור ואבטחה מובנות  
- אינטגרציה מקורית עם Azure OpenAI, Azure AI Search ושירותי Azure נוספים  
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
- קיצור זמן ההגעה לערך בפרויקטים ארגוניים של AI עם פלטפורמת שרת MCP מוכנה לשימוש  
- פישוט אינטגרציה של LLMs, כלים ומקורות נתונים ארגוניים  
- שיפור אבטחה, נראות ויעילות תפעולית לעומסי עבודה של MCP  

**הפניות:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## מחקר מקרה 6: NLWeb

MCP (Model Context Protocol) הוא פרוטוקול מתפתח לצ'אטבוטים ועוזרי AI לתקשר עם כלים. כל מופע של NLWeb הוא גם שרת MCP התומך בשיטה מרכזית אחת, ask, המשמשת לשאילת שאלות באתר בשפה טבעית. התשובה המוחזרת משתמשת ב-schema.org, אוצר מילים נפוץ לתיאור נתוני ווב. במובן כללי, MCP הוא ל-NLWeb מה ש-HTTP הוא ל-HTML. NLWeb משלבת פרוטוקולים, פורמטים של Schema.org וקוד דוגמה כדי לעזור לאתרים ליצור נקודות קצה במהירות, לטובת בני אדם בממשקי שיחה ולמכונות באינטראקציה טבעית בין סוכנים.

ל-NLWeb שני מרכיבים מובחנים:  
- פרוטוקול פשוט לתחילת עבודה, לאינטראקציה עם אתר בשפה טבעית, ופורמט המשתמש ב-json ו-schema.org לתשובה המוחזרת. ראו את התיעוד על REST API לפרטים נוספים.  
- יישום פשוט של (1) המשתמש בסימון קיים, לאתרים שניתן להציג אותם כרשימות פריטים (מוצרים, מתכונים, אטרקציות, ביקורות וכו'). יחד עם סט ווידג'טים לממשק משתמש, אתרים יכולים לספק בקלות ממשקי שיחה לתוכן שלהם. ראו תיעוד על Life of a chat query לפרטים על אופן הפעולה.  

**הפניות:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### מחקר מקרה 7: MCP ל-Foundry – אינטגרציה עם סוכני Azure AI

שרתים של Azure AI Foundry MCP מדגימים כיצד ניתן להשתמש ב-MCP לתיאום וניהול סוכני AI וזרימות עבודה בסביבות ארגוניות. באמצעות שילוב MCP עם Azure AI Foundry, ארגונים יכולים לאחד אינטראקציות סוכנים, לנצל את ניהול זרימות העבודה של Foundry ולהבטיח פריסות מאובטחות וניתנות להרחבה. גישה זו מאפשרת פרוטוטייפינג מהיר, ניטור חזק ואינטגרציה חלקה עם שירותי Azure AI, תומכת בתרחישים מתקדמים כמו ניהול ידע והערכת סוכנים. מפתחים נהנים מממשק אחיד לבניית, פריסה וניטור צינורות סוכנים, וצוותי IT משפרים אבטחה, ציות ויעילות תפעולית. הפתרון אידיאלי לארגונים המבקשים להאיץ אימוץ AI ולשמור על שליטה בתהליכים מורכבים מונחי סוכנים.

**הפניות:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### מחקר מקרה 8: Foundry MCP Playground – ניסויים ופרוטוטייפינג

Foundry MCP Playground מציע סביבה מוכנה לשימוש לניסויים עם שרתי MCP ואינטגרציות Azure AI Foundry. מפתחים יכולים ליצור פרוטוטייפים במהירות, לבדוק ולהעריך מודלים וזרימות עבודה של סוכנים באמצעות משאבים מ-Azure AI Foundry Catalog ו-Labs. המגרש מפשט את ההתקנה, מספק פרויקטים לדוגמה ותומך בפיתוח שיתופי, מה שמקל על חקירת שיטות עבודה מומלצות ותרחישים חדשים עם מינימום עומס. הוא שימושי במיוחד לצוותים המעוניינים לאמת רעיונות, לשתף ניסויים ולהאיץ למידה ללא צורך בתשתית מורכבת. בהורדת מחסום הכניסה, המגרש תורם לחדשנות ולקהילה באקוסיסטם של MCP ו-Azure AI Foundry.

**הפניות:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

## פרויקטים מעשיים

### פרויקט 1: בניית שרת MCP עם מספר ספקים

**מטרה:** ליצור שרת MCP שיכול לכוון בקשות לספקי מודלים של AI מרובים על בסיס קריטריונים ספציפיים.

**דרישות:**  
- תמיכה לפחות בשלושה ספקי מודלים שונים (למשל OpenAI, Anthropic, מודלים מקומיים)  
- יישום מנגנון ניתוב מבוסס מטא-נתוני בקשה  
- יצירת מערכת קונפיגורציה לניהול אישורי ספקים  
- הוספת מטמון לאופטימיזציה של ביצועים ועלויות  
- בניית לוח בקרה פשוט למעקב שימוש  

**שלבי יישום:**  
1. הקמת תשתית שרת MCP בסיסית  
2. יישום מתאמי ספק לכל שירות מודל AI  
3. יצירת לוגיקת ניתוב לפי מאפייני בקשה  
4. הוספת מנגנוני מטמון לבקשות תכופות  
5. פיתוח לוח בקרה לניטור  
6. בדיקה עם דפוסי בקשות שונים  

**טכנולוגיות:** בחרו בין Python (.NET/Java/Python לפי העדפתכם), Redis למטמון, ומסגרת ווב פשוטה ללוח הבקרה.

### פרויקט 2: מערכת ניהול פרומפט ארגונית

**מטרה:** לפתח מערכת מבוססת MCP לניהול, ניהול גרסאות ופריסה של תבניות פרומפט בארגון.

**דרישות:**  
- יצירת מאגר מרכזי לתבניות פרומפט  
- יישום ניהול גרסאות ותהליכי אישור  
- בניית יכולות בדיקה עם קלטים לדוגמה  
- פיתוח בקרות גישה מבוססות תפקידים  
- יצירת API לשליפה ופריסה של תבניות  

**שלבי יישום:**  
1. עיצוב סכימת מסד נתונים לאחסון תבניות  
2. יצירת API מרכזי לפעולות CRUD על תבניות  
3. יישום מערכת ניהול גרסאות  
4. בניית תהליך אישור  
5. פיתוח מסגרת בדיקות  
6. יצירת ממשק ווב פשוט לניהול  
7. אינטגרציה עם שרת MCP  

**טכנולוגיות:** בחירתכם במסגרת backend, מסד נתונים SQL או NoSQL, ומסגרת frontend לממשק הניהול.

### פרויקט 3: פלטפורמת יצירת תוכן מבוססת MCP

**מטרה:** לבנות פלטפורמה ליצירת תוכן המשתמשת ב-MCP לספק תוצאות עקביות בסוגי תוכן שונים.

**דרישות:**  
- תמיכה בפורמטים שונים של תוכן (פוסטים לבלוג, מדיה חברתית, טקסט שיווקי)  
- יישום יצירה מבוססת תבניות עם אפשרויות התאמה אישית  
- יצירת מערכת סקירה ומשוב לתוכן  
- מעקב אחר מדדי ביצועי תוכן  
- תמיכה בניהול גרסאות וחזרות  

**שלבי יישום:**  
1. הקמת תשתית לקוח MCP  
2. יצירת תבניות לסוגי תוכן שונים  
3. בניית צינור יצירת תוכן  
4. יישום מערכת סקירה  
5. פיתוח מערכת מעקב מדדים  
6. יצירת ממשק משתמש לניהול תבניות ויצירת תוכן  

**טכנולוגיות:** שפת תכנות מועדפת, מסגרת ווב ומערכת מסד נתונים.

## כיווני עתיד לטכנולוגיית MCP

### מגמות מתפתחות

1. **MCP מולטי-מודאלי**  
   - הרחבת MCP לאינטראקציות עם מודלים של תמונה, אודיו ווידאו  
   - פיתוח יכולות הסקה בין-מודאליות  
   - פורמטים סטנדרטיים לפרומפטים במודאליות שונות  

2. **תשתית MCP מבוזרת (Federated)**  
   - רשתות MCP מבוזרות לשיתוף משאבים בין ארגונים  
   - פרוטוקולים סטנדרטיים לשיתוף מודלים מאובטח  
   - טכניקות חישוב לשמירה על פרטיות  

3. **שווקי MCP**  
   - אקוסיסטמים לשיתוף ומונטיזציה של תבניות ותוספים ב-MCP  
   - תהליכי הבטחת איכות ותעודה  
   - אינטגרציה עם שווקי מודלים  

4. **MCP למחשוב בקצה**  
   - התאמת תקני MCP למכשירי קצה בעלי משאבים מוגבלים  
   - פרוטוקולים מותאמים לסביבות ברוחב פס נמוך  
   - יישומים מיוחדים ל-MCP באקוסיסטמי IoT  

5. **מסגרות רגולטוריות**  
   - פיתוח הרחבות MCP לציות רגולטורי  
   - מסלולי ביקורת סטנדרטיים וממשקי הסברה  
   - אינטגרציה עם מסגרות ממשל AI מתפתחות  

### פתרונות MCP מבית Microsoft

מיקרוסופט ו-Azure פיתחו מספר מאגרים בקוד פתוח לסיוע למפתחים ביישום MCP בתרחישים שונים:

#### ארגון Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) – שרת Playwright MCP לאוטומציה ובדיקות דפדפן  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) – יישום שרת MCP ל-OneDrive לבדיקות מקומיות ותרומות קהילתיות  
3. [NLWeb](https://github.com/microsoft/NlWeb) – אוסף פרוטוקולים וכלים בקוד פתוח, מתמקד ביצירת שכבת יסוד לאינטרנט AI  

#### ארגון Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) – קישורים לדוגמאות, כלים ומשאבים לבניית ותחזוקת שרתי MCP ב-Azure בשפות שונות  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) – שרתי MCP לדוגמה עם אימות לפי מפרט Model Context Protocol הנוכחי  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) – דף נחיתה ליישומי שרתי MCP מרוחקים ב-Azure Functions עם קישורים לריפוזיטוריות לפי שפה  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) – תבנית התחלה מהירה לבניית ופריסת שרתי MCP מרוחקים מותאמים ב
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

1. נתחו אחת ממקרי המבחן והציעו גישה אלטרנטיבית ליישום.  
2. בחרו אחת מרעיונות הפרויקט וכתבו מפרט טכני מפורט.  
3. חקרו תעשייה שלא נכללה במקרי המבחן ופרטו כיצד MCP יכול להתמודד עם האתגרים הייחודיים שלה.  
4. חקרו אחד מהכיוונים העתידיים ויצרו קונספט להרחבה חדשה של MCP שתתמוך בו.  

הבא: [Best Practices](../08-BestPractices/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש להיות מודעים לכך שתרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו נחשב למקור הסמכותי. למידע קריטי מומלץ להשתמש בתרגום מקצועי אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעים משימוש בתרגום זה.