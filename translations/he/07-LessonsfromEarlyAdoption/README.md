<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T22:11:49+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "he"
}
-->
# לקחים מאמצים מוקדמים

## סקירה כללית

שיעור זה חוקר כיצד מאמצים מוקדמים ניצלו את Model Context Protocol (MCP) כדי לפתור אתגרים אמיתיים ולהניע חדשנות בתעשיות שונות. באמצעות מחקרי מקרה מפורטים ופרויקטים מעשיים, תראו כיצד MCP מאפשר אינטגרציה מאוחדת, מאובטחת וסקלאבילית של בינה מלאכותית — מחבר מודלים לשוניים גדולים, כלים ונתוני ארגונים במסגרת אחידה. תרכשו ניסיון מעשי בעיצוב ובניית פתרונות מבוססי MCP, תלמדו מדפוסי יישום מוכחים ותגלו שיטות עבודה מומלצות לפריסה בסביבות ייצור. השיעור גם מדגיש מגמות מתפתחות, כיווני עתיד ומשאבי קוד פתוח שיעזרו לכם להישאר בחזית הטכנולוגיה והאקוסיסטם המתפתח של MCP.

## מטרות הלמידה

- לנתח יישומים ממשיים של MCP בתעשיות שונות  
- לעצב ולבנות אפליקציות שלמות מבוססות MCP  
- לחקור מגמות מתפתחות וכיווני עתיד בטכנולוגיית MCP  
- ליישם שיטות עבודה מומלצות בתרחישי פיתוח אמיתיים  

## יישומי MCP במציאות

### מחקר מקרה 1: אוטומציה של תמיכת לקוחות בארגון

תאגיד רב-לאומי יישם פתרון מבוסס MCP לאיחוד האינטראקציות עם בינה מלאכותית במערכות התמיכה בלקוחות שלו. זה אפשר להם:

- ליצור ממשק אחיד לספקי LLM מרובים  
- לנהל באופן עקבי את ניהול ההנחיות בין מחלקות  
- ליישם בקרות אבטחה וציות מחמירות  
- לעבור בקלות בין מודלים שונים לפי הצורך  

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

### מחקר מקרה 2: עוזר אבחון רפואי

ספק שירותי בריאות פיתח תשתית MCP לשילוב מספר מודלים רפואיים מתמחים תוך שמירה על הגנת מידע רגיש של מטופלים:

- מעבר חלק בין מודלים רפואיים כלליים למומחים  
- בקרות פרטיות מחמירות ומעקבים מתועדים  
- אינטגרציה עם מערכות רשומות רפואיות אלקטרוניות (EHR) קיימות  
- הנדסת הנחיות עקבית למונחים רפואיים  

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

**תוצאות:** שיפור בהצעות האבחון לרופאים תוך שמירה מלאה על תקני HIPAA והפחתה משמעותית במעברי הקשר בין מערכות.

### מחקר מקרה 3: ניתוח סיכוני שירותים פיננסיים

מוסד פיננסי יישם MCP לאיחוד תהליכי ניתוח סיכונים במחלקות שונות:

- יצירת ממשק אחיד למודלים של סיכון אשראי, גילוי הונאות וסיכון השקעות  
- יישום בקרות גישה מחמירות וניהול גרסאות למודלים  
- הבטחת יכולת ביקורת לכל ההמלצות של הבינה המלאכותית  
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

**תוצאות:** שיפור הציות לרגולציה, קיצור מחזורי פריסת מודלים ב-40%, ושיפור עקביות בהערכת סיכונים במחלקות.

### מחקר מקרה 4: שרת Playwright MCP של Microsoft לאוטומציה בדפדפן

Microsoft פיתחה את [Playwright MCP server](https://github.com/microsoft/playwright-mcp) לאפשר אוטומציה בטוחה ומאוחדת של דפדפנים דרך Model Context Protocol. פתרון זה מאפשר לסוכני AI ול-LLMs לתקשר עם דפדפנים בצורה מבוקרת, מתועדת ומורחבת — לאפשר מקרים שימוש כמו בדיקות ווב אוטומטיות, חילוץ נתונים, ותהליכי עבודה מקצה לקצה.

- חושף יכולות אוטומציה בדפדפן (ניווט, מילוי טפסים, צילום מסך וכו') ככלים של MCP  
- מיישם בקרות גישה מחמירות וסביבה מבודדת למניעת פעולות בלתי מורשות  
- מספק יומני ביקורת מפורטים לכל האינטראקציות עם הדפדפן  
- תומך באינטגרציה עם Azure OpenAI וספקי LLM אחרים לאוטומציה מונעת סוכנים  

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
- אפשר אוטומציה בטוחה ומתוכנתת של דפדפנים לסוכני AI ול-LLMs  
- הפחית מאמץ בבדיקות ידניות ושיפר כיסוי בדיקות לאפליקציות ווב  
- סיפק מסגרת ניתנת לשימוש חוזר ומורחבת לאינטגרציה של כלים מבוססי דפדפן בסביבות ארגוניות  

**הפניות:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### מחקר מקרה 5: Azure MCP – Model Context Protocol ברמת ארגון כשירות

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) הוא מימוש מנוהל ברמת ארגון של Model Context Protocol, שמספק יכולות שרת MCP סקלאביליות, מאובטחות ותואמות כשרות ענן. Azure MCP מאפשר לארגונים לפרוס, לנהל ולשלב שרתי MCP עם שירותי Azure AI, נתונים ואבטחה במהירות, תוך הפחתת עומס תפעולי והאצת אימוץ AI.

- אירוח שרת MCP מנוהל מלא עם יכולות סקיילינג, ניטור ואבטחה מובנות  
- אינטגרציה ילידית עם Azure OpenAI, Azure AI Search ושירותי Azure נוספים  
- אימות והרשאות ארגוניות דרך Microsoft Entra ID  
- תמיכה בכלים מותאמים, תבניות הנחיה ומחברי משאבים  
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
- קיצור זמן הערך לפרויקטי AI ארגוניים באמצעות פלטפורמת שרת MCP מוכנה לשימוש ותואמת  
- פישוט אינטגרציה של LLMs, כלים ומקורות נתונים ארגוניים  
- שיפור האבטחה, הנראות והיעילות התפעולית לעומסי עבודה של MCP  

**הפניות:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## מחקר מקרה 6: NLWeb  
MCP (Model Context Protocol) הוא פרוטוקול מתפתח לצ'אטבוטים ועוזרי AI לאינטראקציה עם כלים. כל מופע של NLWeb הוא גם שרת MCP, התומך בשיטה מרכזית אחת, ask, המשמשת לשאילת שאלות לאתר בשפה טבעית. התגובה המוחזרת משתמשת ב-schema.org, אוצר מילים נפוץ לתיאור נתוני ווב. בקצרה, MCP הוא כמו NLWeb ביחס ל-HTTP ביחס ל-HTML. NLWeb משלב פרוטוקולים, פורמטים של Schema.org וקוד דוגמה כדי לסייע לאתרים ליצור במהירות נקודות קצה אלה, לטובת אנשים דרך ממשקי שיחה ומכונות דרך אינטראקציה טבעית בין סוכנים.

יש שני מרכיבים מובחנים ל-NLWeb:  
- פרוטוקול, פשוט להתחלה, לממשק עם אתר בשפה טבעית ופורמט המשתמש ב-json ו-schema.org לתשובה המוחזרת. ראו תיעוד ה-REST API לפרטים נוספים.  
- מימוש פשוט של (1) המשתמש במבנה קיים, לאתרים שניתן להציג כרשימות פריטים (מוצרים, מתכונים, אטרקציות, ביקורות וכו'). יחד עם סט ווידג'טים לממשק משתמש, אתרים יכולים לספק ממשקי שיחה לתוכן שלהם בקלות. ראו תיעוד Life of a chat query לפרטים נוספים על אופן הפעולה.

**הפניות:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## פרויקטים מעשיים

### פרויקט 1: בניית שרת MCP רב-ספקי

**מטרה:** ליצור שרת MCP שיכול לנתב בקשות לספקי מודלים שונים על בסיס קריטריונים ספציפיים.

**דרישות:**  
- תמיכה לפחות בשלושה ספקי מודלים שונים (למשל OpenAI, Anthropic, מודלים מקומיים)  
- מימוש מנגנון ניתוב מבוסס מטא-נתוני בקשה  
- יצירת מערכת תצורה לניהול אישורי ספקים  
- הוספת מטמון לאופטימיזציה של ביצועים ועלויות  
- בניית לוח בקרה פשוט למעקב שימוש  

**שלבי יישום:**  
1. הקמת תשתית שרת MCP בסיסית  
2. מימוש מתאמי ספק לכל שירות מודל AI  
3. יצירת לוגיקת ניתוב על סמך מאפייני בקשה  
4. הוספת מנגנוני מטמון לבקשות תכופות  
5. פיתוח לוח בקרה למעקב  
6. בדיקה עם דפוסי בקשה שונים  

**טכנולוגיות:** בחירה בין Python (.NET/Java/Python לפי העדפה), Redis למטמון, ומסגרת ווב פשוטה ללוח הבקרה.

### פרויקט 2: מערכת ניהול הנחיות ארגונית

**מטרה:** לפתח מערכת מבוססת MCP לניהול, גרסאות ופריסה של תבניות הנחיה בארגון.

**דרישות:**  
- יצירת מאגר מרכזי לתבניות הנחיה  
- מימוש ניהול גרסאות ותהליכי אישור  
- בניית יכולות בדיקת תבניות עם קלטים לדוגמה  
- פיתוח בקרות גישה מבוססות תפקידים  
- יצירת API לאחזור ופריסת תבניות  

**שלבי יישום:**  
1. עיצוב סכמת מסד נתונים לאחסון תבניות  
2. יצירת API בסיסי לפעולות CRUD על תבניות  
3. מימוש מערכת ניהול גרסאות  
4. בניית תהליך אישור  
5. פיתוח מסגרת בדיקות  
6. יצירת ממשק ווב פשוט לניהול  
7. אינטגרציה עם שרת MCP  

**טכנולוגיות:** בחירת מסגרת backend, מסד SQL או NoSQL, ומסגרת frontend לממשק ניהול.

### פרויקט 3: פלטפורמת יצירת תוכן מבוססת MCP

**מטרה:** לבנות פלטפורמה ליצירת תוכן המשתמשת ב-MCP לספק תוצאות עקביות בסוגי תוכן שונים.

**דרישות:**  
- תמיכה בפורמטים מרובים של תוכן (פוסטים בבלוג, מדיה חברתית, טקסט שיווקי)  
- מימוש יצירה מבוססת תבניות עם אפשרויות התאמה אישית  
- יצירת מערכת סקירה ומשוב לתוכן  
- מעקב אחרי מדדי ביצועי תוכן  
- תמיכה בגרסאות ועריכות תוכן  

**שלבי יישום:**  
1. הקמת תשתית לקוח MCP  
2. יצירת תבניות לסוגי תוכן שונים  
3. בניית קו יצירת תוכן  
4. מימוש מערכת סקירה  
5. פיתוח מערכת מעקב מדדים  
6. יצירת ממשק משתמש לניהול תבניות ויצירת תוכן  

**טכנולוגיות:** שפת תכנות מועדפת, מסגרת ווב ומסד נתונים.

## כיווני עתיד לטכנולוגיית MCP

### מגמות מתפתחות

1. **MCP רב-מודאלי**  
   - הרחבת MCP לאינטראקציות עם מודלים של תמונה, אודיו ווידאו  
   - פיתוח יכולות הסקה חוצת מודאליות  
   - פורמטים סטנדרטיים להנחיות למודאליות שונות  

2. **תשתית MCP מבוזרת (Federated)**  
   - רשתות MCP מבוזרות לשיתוף משאבים בין ארגונים  
   - פרוטוקולים סטנדרטיים לשיתוף מודלים מאובטח  
   - טכניקות חישוב לשמירת פרטיות  

3. **שווקי MCP**  
   - אקוסיסטמים לשיתוף ומוניטיזציה של תבניות ותוספים ל-MCP  
   - תהליכי אבטחת איכות ותעודה  
   - אינטגרציה עם שווקי מודלים  

4. **MCP למחשוב בקצה (Edge Computing)**  
   - התאמת תקני MCP למכשירי קצה מוגבלים במשאבים  
   - פרוטוקולים מותאמים לסביבות רוחב פס נמוך  
   - מימושים ייעודיים ל-MCP לאקוסיסטמי IoT  

5. **מסגרות רגולטוריות**  
   - פיתוח הרחבות MCP לציות רגולטורי  
   - מסלולי ביקורת סטנדרטיים וממשקי הסבר  
   - אינטגרציה עם מסגרות ממשל AI מתפתחות  

### פתרונות MCP מ-Microsoft

Microsoft ו-Azure פיתחו מספר מאגרים בקוד פתוח לסיוע למפתחים ליישם MCP בתרחישים שונים:

#### ארגון Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - שרת Playwright MCP לאוטומציה ובדיקות בדפדפן  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - מימוש שרת MCP ל-OneDrive לבדיקות מקומיות ותרומה לקהילה  
3. [NLWeb](https://github.com/microsoft/NlWeb) - אוסף פרוטוקולים פתוחים וכלים פתוחים נלווים, עם דגש על שכבת יסוד לאינטרנט AI  

#### ארגון Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - קישורים לדוגמאות, כלים ומשאבים לבניית ואינטגרציה של שרתי MCP ב-Azure בשפות שונות  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - שרתי MCP לדוגמה עם אימות לפי מפרט Model Context Protocol הנוכחי  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - דף נחיתה למימושי שרת MCP מרוחקים ב-Azure Functions עם קישורים לרפוזיטוריות לפי שפות  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - תבנית התחלה מהירה לבניית ופריסת שרתי MCP מרוחקים מותאמים ב-Azure Functions בפייתון  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - תבנית התחלה מהירה לבניית ופריסת שרתי MCP מרוחקים מותאמים ב-.NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - תבנית התחלה מהירה לבניית ופריסת שרתי MCP מרוחקים מותאמים ב-TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - ניהול API של Azure כשער AI לשרתי MCP מרוחקים בפייתון  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - ניסויים ב-APIM ❤️ AI כולל יכולות MCP, אינטגרציה עם Azure OpenAI ו-AI Foundry  

מאגרים אלה מספקים מימושים, תבניות ומשאבים לעבודה עם Model Context Protocol בשפות תכנות ושירותי Azure שונים. הם כוללים מגוון תרחישי שימוש החל מיישומי שרת בסיסיים, דרך אימות, פריסה בענן ואינטגרציה ארגונית.

#### מדריך משאבי MCP

מדריך [MCP Resources directory](https://github.com/microsoft/mcp/tree/main/Resources) במאגר הרשמי של Microsoft MCP מספק אוסף מאורגן של משאבי דוגמה, תבניות הנחיה והגדרות כלים לשימוש עם שרתי Model Context Protocol. מדריך זה נועד לסייע למפתחים להתחיל במהירות עם MCP על ידי הצעת בלוקים לשימוש חוזר ודוגמאות לשיטות עבודה מומלצות עבור:

- **תבניות הנחיה:** תבניות מוכנות לשימוש למשימות ותסריטים נפוצים בבינה מלאכותית, שניתן להתאים ליישומי שרת MCP שלכם.  
- **הגדרות כלים:** דוגמאות לסכמות כלים ומטא-נתונים לאיחוד אינטגרציה והפעלה של כלים בין שרתי MCP שונים.  
- **דוגמאות משאבים:** הגדרות משאבים לדוגמה לחיבור למקורות נתונים, API ושירותים חיצוניים במסגרת MCP.  
- **יישומים לדוגמה:** דוגמאות מעשיות הממחישות כיצד לארגן ולבנות משאבים, הנחיות וכלים בפרויקטים ממשיים של MCP.  

משאבים אלה מזרזים פיתוח, מקדמים סטנדרטיזציה ועוזרים להבטיח שיטות עבודה מומלצות בבניית ופריס
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)  
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)  
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)  
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)  
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

## תרגילים

1. נתח מקרה בוחן אחד והצע גישה חלופית ליישום.  
2. בחר רעיון פרויקט אחד וכתוב מפרט טכני מפורט.  
3. חקור תעשייה שלא נכללה במקרי הבוחן וציין כיצד MCP יכול להתמודד עם האתגרים הייחודיים שלה.  
4. חקור אחד מהכיוונים העתידיים ופתח קונספט להרחבה חדשה של MCP שתתמוך בו.  

הבא: [Best Practices](../08-BestPractices/README.md)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון שתרגומים אוטומטיים עלולים להכיל שגיאות או אי דיוקים. יש להחשיב את המסמך המקורי בשפת המקור כמקור הסמכותי. למידע קריטי מומלץ להיעזר בתרגום מקצועי אנושי. איננו אחראים לכל אי הבנות או פרשנויות שגויות הנובעות משימוש בתרגום זה.