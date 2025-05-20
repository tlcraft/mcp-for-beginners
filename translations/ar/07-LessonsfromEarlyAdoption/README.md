<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T15:47:05+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ar"
}
-->
# دروس من المستخدمين الأوائل

## نظرة عامة

تستعرض هذه الدرس كيف استفاد المستخدمون الأوائل من بروتوكول سياق النموذج (MCP) لحل تحديات العالم الحقيقي ودفع الابتكار عبر الصناعات. من خلال دراسات حالة مفصلة ومشاريع تطبيقية، سترى كيف يتيح MCP دمج الذكاء الاصطناعي بطريقة موحدة وآمنة وقابلة للتوسع—موصلًا نماذج اللغة الكبيرة، الأدوات، وبيانات المؤسسات في إطار عمل موحد. ستكتسب خبرة عملية في تصميم وبناء حلول تعتمد على MCP، وتتعلّم من أنماط التنفيذ المثبتة، وتكتشف أفضل الممارسات لنشر MCP في بيئات الإنتاج. كما يسلط الدرس الضوء على الاتجاهات الناشئة، الاتجاهات المستقبلية، والموارد مفتوحة المصدر لمساعدتك على البقاء في طليعة تكنولوجيا MCP ونظامها البيئي المتطور.

## أهداف التعلم

- تحليل تطبيقات MCP في العالم الحقيقي عبر صناعات مختلفة  
- تصميم وبناء تطبيقات كاملة تعتمد على MCP  
- استكشاف الاتجاهات الناشئة والاتجاهات المستقبلية في تكنولوجيا MCP  
- تطبيق أفضل الممارسات في سيناريوهات تطوير فعلية  

## تطبيقات MCP في العالم الحقيقي

### دراسة حالة 1: أتمتة دعم العملاء في المؤسسات

نفذت شركة متعددة الجنسيات حلاً يعتمد على MCP لتوحيد تفاعلات الذكاء الاصطناعي عبر أنظمة دعم العملاء الخاصة بها. سمح لهم ذلك بـ:

- إنشاء واجهة موحدة لمزودي نماذج اللغة الكبيرة المتعددة  
- الحفاظ على إدارة مطالبات متسقة عبر الأقسام  
- تنفيذ ضوابط أمان وامتثال قوية  
- التبديل بسهولة بين نماذج الذكاء الاصطناعي المختلفة حسب الاحتياجات المحددة  

**التنفيذ التقني:**  
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

**النتائج:** تقليل تكاليف النماذج بنسبة 30%، تحسين اتساق الاستجابات بنسبة 45%، وتعزيز الامتثال عبر العمليات العالمية.

### دراسة حالة 2: مساعد التشخيص في الرعاية الصحية

طور مقدم خدمات صحية بنية تحتية تعتمد على MCP لدمج نماذج ذكاء اصطناعي طبية متخصصة متعددة مع ضمان حماية بيانات المرضى الحساسة:

- التبديل السلس بين النماذج الطبية العامة والمتخصصة  
- ضوابط خصوصية صارمة ومسارات تدقيق  
- التكامل مع أنظمة السجلات الصحية الإلكترونية الحالية  
- هندسة مطالبات متسقة للمصطلحات الطبية  

**التنفيذ التقني:**  
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

**النتائج:** تحسين اقتراحات التشخيص للأطباء مع الحفاظ على الامتثال الكامل لقانون HIPAA وتقليل كبير في التنقل بين الأنظمة.

### دراسة حالة 3: تحليل المخاطر في الخدمات المالية

طبقت مؤسسة مالية MCP لتوحيد عمليات تحليل المخاطر عبر أقسام مختلفة:

- إنشاء واجهة موحدة لنماذج مخاطر الائتمان، الكشف عن الاحتيال، ومخاطر الاستثمار  
- تنفيذ ضوابط وصول صارمة وإصدار نسخ للنماذج  
- ضمان إمكانية تدقيق جميع توصيات الذكاء الاصطناعي  
- الحفاظ على تنسيق بيانات متسق عبر أنظمة متنوعة  

**التنفيذ التقني:**  
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

**النتائج:** تعزيز الامتثال التنظيمي، تسريع دورات نشر النماذج بنسبة 40%، وتحسين اتساق تقييم المخاطر عبر الأقسام.

### دراسة حالة 4: خادم Microsoft Playwright MCP لأتمتة المتصفح

طورت Microsoft [خادم Playwright MCP](https://github.com/microsoft/playwright-mcp) لتمكين أتمتة المتصفح الآمنة والموحدة عبر بروتوكول سياق النموذج. يتيح هذا الحل لوكلاء الذكاء الاصطناعي ونماذج اللغة الكبيرة التفاعل مع متصفحات الويب بطريقة محكمة وقابلة للتدقيق وقابلة للتوسع—ممكناً استخدامات مثل اختبار الويب الآلي، استخراج البيانات، وسير العمل الشامل.

- يعرض قدرات أتمتة المتصفح (التنقل، تعبئة النماذج، التقاط لقطات شاشة، إلخ) كأدوات MCP  
- ينفذ ضوابط وصول صارمة وعزل لمنع الإجراءات غير المصرح بها  
- يوفر سجلات تدقيق مفصلة لجميع تفاعلات المتصفح  
- يدعم التكامل مع Azure OpenAI ومزودي نماذج اللغة الكبيرة الآخرين لأتمتة مدفوعة بالوكلاء  

**التنفيذ التقني:**  
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

**النتائج:**  
- تمكين أتمتة متصفح آمنة وبرمجية لوكلاء الذكاء الاصطناعي ونماذج اللغة الكبيرة  
- تقليل الجهد اليدوي في الاختبار وتحسين تغطية الاختبارات لتطبيقات الويب  
- توفير إطار عمل قابل لإعادة الاستخدام والتوسع لتكامل أدوات المتصفح في بيئات المؤسسات  

**المراجع:**  
- [مستودع Playwright MCP على GitHub](https://github.com/microsoft/playwright-mcp)  
- [حلول الذكاء الاصطناعي والأتمتة من Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

### دراسة حالة 5: Azure MCP – بروتوكول سياق النموذج كخدمة بمستوى مؤسسي

يعد Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) تنفيذ Microsoft المُدار وبمستوى مؤسسي لبروتوكول سياق النموذج، مصمم لتوفير قدرات خادم MCP قابلة للتوسع، آمنة ومتوافقة كخدمة سحابية. يمكّن Azure MCP المؤسسات من نشر وإدارة ودمج خوادم MCP بسرعة مع خدمات Azure AI، والبيانات، والأمان، مما يقلل العبء التشغيلي ويسرع تبني الذكاء الاصطناعي.

- استضافة خادم MCP مُدارة بالكامل مع التوسع، المراقبة، والأمان المدمجين  
- تكامل أصلي مع Azure OpenAI، Azure AI Search، وخدمات Azure الأخرى  
- المصادقة والتفويض المؤسسي عبر Microsoft Entra ID  
- دعم الأدوات المخصصة، قوالب المطالبات، وموصلات الموارد  
- الامتثال لمتطلبات الأمان والتنظيم المؤسسي  

**التنفيذ التقني:**  
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

**النتائج:**  
- تقليل الوقت اللازم لتحقيق القيمة لمشاريع الذكاء الاصطناعي المؤسسية من خلال توفير منصة خادم MCP جاهزة للاستخدام ومتوافقة  
- تبسيط دمج نماذج اللغة الكبيرة، الأدوات، ومصادر بيانات المؤسسات  
- تعزيز الأمان، الرصد، والكفاءة التشغيلية لأعباء عمل MCP  

**المراجع:**  
- [توثيق Azure MCP](https://aka.ms/azmcp)  
- [خدمات Azure AI](https://azure.microsoft.com/en-us/products/ai-services/)

## دراسة حالة 6: NLWeb

MCP (بروتوكول سياق النموذج) هو بروتوكول ناشئ للدردشة والمساعدين الذكيين للتفاعل مع الأدوات. كل مثيل من NLWeb هو أيضًا خادم MCP يدعم طريقة أساسية واحدة، ask، تُستخدم لطرح سؤال على موقع ويب بلغة طبيعية. يستفيد الرد المعاد من schema.org، وهي مفردات مستخدمة على نطاق واسع لوصف بيانات الويب. بشكل مبسط، MCP هو NLWeb كما أن Http هو لـ HTML. يجمع NLWeb بين البروتوكولات، تنسيقات Schema.org، والكود النموذجي لمساعدة المواقع على إنشاء هذه النقاط النهائية بسرعة، مما يفيد البشر عبر واجهات المحادثة والآلات عبر التفاعل الطبيعي بين الوكلاء.

يتكون NLWeb من مكونين مميزين:  
- بروتوكول بسيط للبدء، للتفاعل مع الموقع بلغة طبيعية وتنسيق يستخدم json وschema.org للإجابة المعادة. راجع الوثائق الخاصة بـ REST API لمزيد من التفاصيل.  
- تنفيذ بسيط لـ (1) يستفيد من العلامات الموجودة، للمواقع التي يمكن تجريدها كقوائم عناصر (منتجات، وصفات، معالم، مراجعات، إلخ). مع مجموعة من عناصر واجهة المستخدم، يمكن للمواقع تقديم واجهات محادثة بسهولة لمحتواها. راجع الوثائق حول Life of a chat query لمزيد من التفاصيل حول كيفية عمل ذلك.

**المراجع:**  
- [توثيق Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### دراسة حالة 7: MCP لـ Foundry – دمج وكلاء Azure AI

تُظهر خوادم Azure AI Foundry MCP كيف يمكن استخدام MCP لتنظيم وإدارة وكلاء الذكاء الاصطناعي وسير العمل في بيئات المؤسسات. من خلال دمج MCP مع Azure AI Foundry، يمكن للمؤسسات توحيد تفاعلات الوكلاء، الاستفادة من إدارة سير العمل في Foundry، وضمان عمليات نشر آمنة وقابلة للتوسع. يتيح هذا النهج النمذجة السريعة، المراقبة القوية، والتكامل السلس مع خدمات Azure AI، داعمًا سيناريوهات متقدمة مثل إدارة المعرفة وتقييم الوكلاء. يستفيد المطورون من واجهة موحدة لبناء ونشر ومراقبة خطوط أنابيب الوكلاء، بينما تحظى فرق تكنولوجيا المعلومات بأمان أفضل، امتثال، وكفاءة تشغيلية محسنة. الحل مثالي للمؤسسات التي تسعى لتسريع تبني الذكاء الاصطناعي والحفاظ على السيطرة على العمليات المعقدة المدفوعة بالوكلاء.

**المراجع:**  
- [مستودع MCP Foundry على GitHub](https://github.com/azure-ai-foundry/mcp-foundry)  
- [دمج وكلاء Azure AI مع MCP (مدونة Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### دراسة حالة 8: ملعب Foundry MCP – التجارب والنماذج الأولية

يقدم ملعب Foundry MCP بيئة جاهزة للاستخدام لتجربة خوادم MCP وتكاملات Azure AI Foundry. يمكن للمطورين بسرعة إنشاء نماذج أولية، اختبار، وتقييم نماذج الذكاء الاصطناعي وسير عمل الوكلاء باستخدام موارد من كتالوج Azure AI Foundry والمختبرات. يسهل الملعب الإعداد، يوفر مشاريع نموذجية، ويدعم التطوير التعاوني، مما يجعل من السهل استكشاف أفضل الممارسات والسيناريوهات الجديدة بأقل جهد. هو مفيد بشكل خاص للفرق التي تسعى للتحقق من الأفكار، مشاركة التجارب، وتسريع التعلم دون الحاجة إلى بنية تحتية معقدة. من خلال خفض عتبة الدخول، يساعد الملعب على تعزيز الابتكار والمساهمات المجتمعية في نظام MCP وAzure AI Foundry.

**المراجع:**  
- [مستودع Foundry MCP Playground على GitHub](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## مشاريع تطبيقية

### المشروع 1: بناء خادم MCP متعدد المزودين

**الهدف:** إنشاء خادم MCP يمكنه توجيه الطلبات إلى مزودي نماذج الذكاء الاصطناعي المتعددين بناءً على معايير محددة.

**المتطلبات:**  
- دعم ثلاثة مزودين مختلفين على الأقل (مثل OpenAI، Anthropic، النماذج المحلية)  
- تنفيذ آلية توجيه تعتمد على بيانات وصف الطلب  
- إنشاء نظام تكوين لإدارة بيانات اعتماد المزودين  
- إضافة تخزين مؤقت لتحسين الأداء والتكاليف  
- بناء لوحة تحكم بسيطة لمراقبة الاستخدام  

**خطوات التنفيذ:**  
1. إعداد بنية تحتية أساسية لخادم MCP  
2. تنفيذ محولات المزود لكل خدمة نموذج ذكاء اصطناعي  
3. إنشاء منطق التوجيه بناءً على سمات الطلب  
4. إضافة آليات التخزين المؤقت للطلبات المتكررة  
5. تطوير لوحة المراقبة  
6. اختبار مع أنماط طلبات مختلفة  

**التقنيات:** اختر من Python (.NET/Java/Python حسب تفضيلك)، Redis للتخزين المؤقت، وإطار عمل ويب بسيط للوحة التحكم.

### المشروع 2: نظام إدارة المطالبات المؤسسية

**الهدف:** تطوير نظام يعتمد على MCP لإدارة، إصدار نسخ، ونشر قوالب المطالبات عبر المؤسسة.

**المتطلبات:**  
- إنشاء مستودع مركزي لقوالب المطالبات  
- تنفيذ نظام إصدار نسخ وسير عمل الموافقة  
- بناء قدرات اختبار القوالب مع مدخلات نموذجية  
- تطوير ضوابط وصول قائمة على الأدوار  
- إنشاء API لاسترجاع القوالب ونشرها  

**خطوات التنفيذ:**  
1. تصميم مخطط قاعدة البيانات لتخزين القوالب  
2. إنشاء API أساسي لعمليات CRUD على القوالب  
3. تنفيذ نظام إصدار النسخ  
4. بناء سير عمل الموافقة  
5. تطوير إطار عمل الاختبار  
6. إنشاء واجهة ويب بسيطة للإدارة  
7. التكامل مع خادم MCP  

**التقنيات:** اختيارك لإطار العمل الخلفي، قاعدة بيانات SQL أو NoSQL، وإطار عمل الواجهة الأمامية.

### المشروع 3: منصة توليد المحتوى تعتمد على MCP

**الهدف:** بناء منصة توليد محتوى تستفيد من MCP لتوفير نتائج متسقة عبر أنواع المحتوى المختلفة.

**المتطلبات:**  
- دعم تنسيقات محتوى متعددة (مقالات مدونة، وسائل التواصل الاجتماعي، نسخ تسويقية)  
- تنفيذ توليد قائم على القوالب مع خيارات تخصيص  
- إنشاء نظام مراجعة المحتوى وتقديم الملاحظات  
- تتبع مؤشرات أداء المحتوى  
- دعم إصدار نسخ المحتوى والتكرار  

**خطوات التنفيذ:**  
1. إعداد بنية عميل MCP  
2. إنشاء قوالب لأنواع المحتوى المختلفة  
3. بناء خط أنابيب توليد المحتوى  
4. تنفيذ نظام المراجعة  
5. تطوير نظام تتبع المؤشرات  
6. إنشاء واجهة مستخدم لإدارة القوالب وتوليد المحتوى  

**التقنيات:** لغة البرمجة المفضلة لديك، إطار عمل الويب، ونظام قاعدة البيانات.

## الاتجاهات المستقبلية لتكنولوجيا MCP

### الاتجاهات الناشئة

1. **MCP متعدد الوسائط**  
   - توسيع MCP لتوحيد التفاعلات مع نماذج الصور، الصوت، والفيديو  
   - تطوير قدرات الاستدلال عبر الوسائط  
   - تنسيقات مطالبات موحدة للوسائط المختلفة  

2. **بنية MCP الموزعة**  
   - شبكات MCP موزعة يمكنها مشاركة الموارد عبر المؤسسات  
   - بروتوكولات موحدة لمشاركة النماذج بأمان  
   - تقنيات الحوسبة المحافظة على الخصوصية  

3. **أسواق MCP**  
   - أنظمة بيئية لمشاركة وتحقيق الربح من قوالب MCP والإضافات  
   - عمليات ضمان الجودة والشهادات  
   - التكامل مع أسواق النماذج  

4. **MCP للحوسبة الطرفية**  
   - تكييف معايير MCP لأجهزة الطرفية ذات الموارد المحدودة  
   - بروتوكولات محسنة لبيئات النطاق الترددي المنخفض  
   - تنفيذات MCP متخصصة لأنظمة إنترنت الأشياء  

5. **الأطر التنظيمية**  
   - تطوير امتدادات MCP للامتثال التنظيمي  
   - مسارات تدقيق موحدة وواجهات تفسيرية  
   - التكامل مع أطر حوكمة الذكاء الاصطناعي الناشئة  

### حلول MCP من Microsoft

طورت Microsoft وAzure عدة مستودعات مفتوحة المصدر لمساعدة المطورين على تنفيذ MCP في سيناريوهات مختلفة:

#### منظمة Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - خادم Playwright MCP لأتمتة المتصفح والاختبار  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - تنفيذ خادم MCP لـ OneDrive للاختبار المحلي والمساهمة المجتمعية  
3. [NLWeb](https://github.com/microsoft/NlWeb) - مجموعة من البروتوكولات المفتوحة والأدوات مفتوحة المصدر المرتبطة، تركز على تأسيس طبقة أساسية للويب الذكي  

#### منظمة Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - روابط لأمثلة وأدوات وموارد لبناء ودمج خوادم MCP على Azure باستخدام لغات متعددة  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - خوادم MCP مرجعية توضح المصادقة مع مواصفات بروتوكول سياق النموذج الحالية  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - صفحة هبوط لتنفيذات خوادم MCP البعيدة في Azure Functions مع روابط لمستودعات خاصة باللغات  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - قالب بدء سريع لبناء ونشر خوادم MCP البعيدة باستخدام Azure Functions مع Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - قالب بدء سريع لبناء ونشر خوادم MCP البعيدة باستخدام Azure Functions مع .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - قالب بدء سريع لبناء ونشر خوادم MCP البعيدة باستخدام Azure Functions مع TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - إدارة API من Azure كبوابة ذكاء اصطناعي لخوادم MCP البعيدة باستخدام Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - تجارب APIM ❤️ AI بما في ذلك قدرات MCP، التكامل مع Azure OpenAI وAI Foundry  

توفر هذه المستودعات تطبيقات مختلفة، قوالب، وموارد للعمل مع بروتوكول سياق النموذج عبر لغات برمجة متعددة وخدمات Azure. تغطي مجموعة من حالات الاستخدام من تنفيذات الخوادم الأساسية إلى المصادقة، النشر السحابي، وسيناريوهات دمج المؤسسات.

#### دليل موارد MCP

يوفر [دليل موارد MCP](https://github.com/microsoft/mcp/tree/main/Resources) في المستودع الرسمي لـ Microsoft MCP مجموعة مختارة من موارد النماذج، قوالب المطالبات، وتعريفات
- [توثيق Azure MCP](https://aka.ms/azmcp)
- [مستودع Playwright MCP Server على GitHub](https://github.com/microsoft/playwright-mcp)
- [ملفات MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [عينات Azure MCP](https://github.com/Azure-Samples/mcp)
- [خوادم MCP Auth (عينات Azure)](https://github.com/Azure-Samples/mcp-auth-servers)
- [وظائف MCP عن بُعد (عينات Azure)](https://github.com/Azure-Samples/remote-mcp-functions)
- [وظائف MCP عن بُعد بايثون (عينات Azure)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [وظائف MCP عن بُعد .NET (عينات Azure)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [وظائف MCP عن بُعد TypeScript (عينات Azure)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [وظائف MCP APIM عن بُعد بايثون (عينات Azure)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [بوابة الذكاء الاصطناعي (عينات Azure)](https://github.com/Azure-Samples/AI-Gateway)
- [حلول الذكاء الاصطناعي والأتمتة من Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)

## التمارين

1. حلل إحدى دراسات الحالة واقترح نهج تنفيذ بديل.
2. اختر إحدى أفكار المشاريع وقم بإعداد مواصفة فنية مفصلة.
3. ابحث في صناعة غير مغطاة في دراسات الحالة وحدد كيف يمكن لـ MCP معالجة تحدياتها الخاصة.
4. استكشف أحد الاتجاهات المستقبلية وابتكر مفهومًا لإضافة جديدة لـ MCP لدعمها.

التالي: [أفضل الممارسات](../08-BestPractices/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الرسمي والمعتمد. بالنسبة للمعلومات الحساسة أو الهامة، يُنصح بالاستعانة بترجمة بشرية محترفة. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.