<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T20:20:34+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ar"
}
-->
# دروس من المتبنين الأوائل

## نظرة عامة

تستعرض هذه الدرس كيف استفاد المتبنون الأوائل من بروتوكول سياق النموذج (MCP) لحل تحديات العالم الحقيقي ودفع الابتكار عبر الصناعات. من خلال دراسات حالة مفصلة ومشاريع عملية، سترى كيف يمكن لـ MCP تمكين التكامل الموحد، الآمن والقابل للتوسع للذكاء الاصطناعي—ربط نماذج اللغة الكبيرة، الأدوات، وبيانات المؤسسات في إطار عمل موحد. ستحصل على خبرة عملية في تصميم وبناء حلول قائمة على MCP، وتتعلم من أنماط التنفيذ المثبتة، وتكتشف أفضل الممارسات لنشر MCP في بيئات الإنتاج. كما يسلط الدرس الضوء على الاتجاهات الناشئة، التوجهات المستقبلية، والموارد مفتوحة المصدر لمساعدتك على البقاء في طليعة تكنولوجيا MCP ونظامها البيئي المتطور.

## أهداف التعلم

- تحليل تطبيقات MCP في العالم الحقيقي عبر صناعات مختلفة  
- تصميم وبناء تطبيقات كاملة قائمة على MCP  
- استكشاف الاتجاهات الناشئة والتوجهات المستقبلية في تكنولوجيا MCP  
- تطبيق أفضل الممارسات في سيناريوهات التطوير الفعلية  

## تطبيقات MCP في العالم الحقيقي

### دراسة حالة 1: أتمتة دعم العملاء للمؤسسات

نفذت شركة متعددة الجنسيات حلاً قائمًا على MCP لتوحيد تفاعلات الذكاء الاصطناعي عبر أنظمة دعم العملاء الخاصة بها. سمح لهم ذلك بـ:

- إنشاء واجهة موحدة لمزودي LLM متعددين  
- الحفاظ على إدارة موحدة للمطالبات عبر الأقسام  
- تنفيذ ضوابط أمان وامتثال قوية  
- التبديل بسهولة بين نماذج الذكاء الاصطناعي المختلفة بناءً على الاحتياجات المحددة  

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

**النتائج:** خفض تكاليف النماذج بنسبة 30٪، وتحسين اتساق الاستجابة بنسبة 45٪، وتعزيز الامتثال عبر العمليات العالمية.

### دراسة حالة 2: مساعد تشخيص الرعاية الصحية

طور مزود رعاية صحية بنية MCP لدمج عدة نماذج طبية متخصصة للذكاء الاصطناعي مع ضمان حماية بيانات المرضى الحساسة:

- التبديل السلس بين النماذج الطبية العامة والمتخصصة  
- ضوابط خصوصية صارمة ومسارات تدقيق  
- التكامل مع أنظمة السجلات الصحية الإلكترونية (EHR) القائمة  
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

**النتائج:** تحسين اقتراحات التشخيص للأطباء مع الحفاظ على الامتثال الكامل لقانون HIPAA وتقليل كبير في تبديل السياق بين الأنظمة.

### دراسة حالة 3: تحليل المخاطر في الخدمات المالية

نفذت مؤسسة مالية MCP لتوحيد عمليات تحليل المخاطر عبر أقسام مختلفة:

- إنشاء واجهة موحدة لنماذج مخاطر الائتمان، كشف الاحتيال، ومخاطر الاستثمار  
- تنفيذ ضوابط وصول صارمة وإدارة إصدارات النماذج  
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

**النتائج:** تعزيز الامتثال التنظيمي، تسريع دورات نشر النماذج بنسبة 40٪، وتحسين اتساق تقييم المخاطر عبر الأقسام.

### دراسة حالة 4: خادم Microsoft Playwright MCP لأتمتة المتصفح

طورت Microsoft [خادم Playwright MCP](https://github.com/microsoft/playwright-mcp) لتمكين أتمتة متصفح آمنة وموحدة من خلال بروتوكول سياق النموذج. يسمح هذا الحل لوكلاء الذكاء الاصطناعي ونماذج اللغة الكبيرة بالتفاعل مع متصفحات الويب بطريقة مراقبة، قابلة للتدقيق وقابلة للتوسعة—مما يمكّن حالات استخدام مثل اختبار الويب الآلي، استخراج البيانات، وسير العمل الشامل.

- يعرض قدرات أتمتة المتصفح (التنقل، تعبئة النماذج، التقاط لقطات شاشة، إلخ) كأدوات MCP  
- ينفذ ضوابط وصول صارمة وعزل لمنع الإجراءات غير المصرح بها  
- يوفر سجلات تدقيق مفصلة لجميع التفاعلات مع المتصفح  
- يدعم التكامل مع Azure OpenAI ومزودي LLM الآخرين لأتمتة مدفوعة بالوكلاء  

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
- تقليل الجهد اليدوي للاختبار وتحسين تغطية الاختبار لتطبيقات الويب  
- توفير إطار عمل قابل لإعادة الاستخدام والتوسعة لتكامل أدوات المتصفح في بيئات المؤسسات  

**المراجع:**  
- [مستودع Playwright MCP على GitHub](https://github.com/microsoft/playwright-mcp)  
- [حلول Microsoft للذكاء الاصطناعي والأتمتة](https://azure.microsoft.com/en-us/products/ai-services/)  

### دراسة حالة 5: Azure MCP – بروتوكول سياق النموذج كخدمة بمستوى المؤسسات

يعد Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) تنفيذًا مُدارًا من Microsoft لبروتوكول سياق النموذج بمستوى المؤسسات، مصممًا لتوفير قدرات خادم MCP قابلة للتوسع، آمنة ومتوافقة كخدمة سحابية. يمكّن Azure MCP المؤسسات من نشر وإدارة ودمج خوادم MCP بسرعة مع خدمات Azure AI، البيانات، والأمان، مما يقلل العبء التشغيلي ويسرع اعتماد الذكاء الاصطناعي.

- استضافة خادم MCP مُدارة بالكامل مع التوسع، المراقبة، والأمان المدمج  
- تكامل أصلي مع Azure OpenAI، Azure AI Search، وخدمات Azure الأخرى  
- مصادقة وتفويض المؤسسات عبر Microsoft Entra ID  
- دعم الأدوات المخصصة، قوالب المطالبات، وموصلات الموارد  
- الامتثال لمتطلبات أمان المؤسسات والتنظيمية  

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
- تقليل زمن الوصول إلى القيمة لمشاريع الذكاء الاصطناعي المؤسسية من خلال توفير منصة خادم MCP جاهزة ومتوافقة  
- تبسيط دمج نماذج اللغة الكبيرة، الأدوات، ومصادر بيانات المؤسسات  
- تعزيز الأمان، الرصد، والكفاءة التشغيلية لأحمال عمل MCP  

**المراجع:**  
- [توثيق Azure MCP](https://aka.ms/azmcp)  
- [خدمات Azure AI](https://azure.microsoft.com/en-us/products/ai-services/)  

## دراسة حالة 6: NLWeb  
MCP (بروتوكول سياق النموذج) هو بروتوكول ناشئ للدردشة والمساعدين الذكيين للتفاعل مع الأدوات. كل نسخة من NLWeb هي أيضًا خادم MCP، يدعم طريقة أساسية واحدة، ask، تُستخدم لطرح سؤال على موقع ويب بلغة طبيعية. تعتمد الاستجابة المرجعة على schema.org، وهي مفردات شائعة لوصف بيانات الويب. بشكل مبسط، MCP هو NLWeb كما HTTP هو لـ HTML. يجمع NLWeb بين البروتوكولات، تنسيقات Schema.org، والكود النموذجي لمساعدة المواقع على إنشاء هذه النقاط النهائية بسرعة، مما يفيد البشر عبر واجهات المحادثة والآلات من خلال تفاعل الوكيل مع الوكيل الطبيعي.

هناك مكونان مميزان لـ NLWeb:  
- بروتوكول بسيط للبدء، للتفاعل مع الموقع بلغة طبيعية وتنسيق يعتمد على json وschema.org للإجابة المرجعة. راجع التوثيق الخاص بـ REST API لمزيد من التفاصيل.  
- تنفيذ مباشر لـ (1) يستفيد من العلامات الموجودة، للمواقع التي يمكن تجريدها كقوائم من العناصر (منتجات، وصفات، معالم، مراجعات، إلخ). مع مجموعة من أدوات واجهة المستخدم، يمكن للمواقع تقديم واجهات محادثة لمحتواها بسهولة. راجع التوثيق الخاص بحياة استعلام الدردشة لمزيد من التفاصيل حول كيفية عمل ذلك.  

**المراجع:**  
- [توثيق Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### دراسة حالة 7: MCP لـ Foundry – دمج وكلاء Azure AI

تُظهر خوادم Azure AI Foundry MCP كيف يمكن استخدام MCP لتنظيم وإدارة وكلاء الذكاء الاصطناعي وسير العمل في بيئات المؤسسات. من خلال دمج MCP مع Azure AI Foundry، يمكن للمؤسسات توحيد تفاعلات الوكلاء، الاستفادة من إدارة سير العمل في Foundry، وضمان عمليات نشر آمنة وقابلة للتوسع. يتيح هذا النهج النماذج الأولية السريعة، المراقبة القوية، والتكامل السلس مع خدمات Azure AI، داعمًا سيناريوهات متقدمة مثل إدارة المعرفة وتقييم الوكلاء. يستفيد المطورون من واجهة موحدة لبناء، نشر، ومراقبة خطوط أنابيب الوكلاء، بينما تحظى فرق تكنولوجيا المعلومات بتحسين الأمان، الامتثال، والكفاءة التشغيلية. الحل مثالي للمؤسسات التي تسعى لتسريع اعتماد الذكاء الاصطناعي والحفاظ على السيطرة على العمليات المعقدة التي يقودها الوكلاء.

**المراجع:**  
- [مستودع MCP Foundry على GitHub](https://github.com/azure-ai-foundry/mcp-foundry)  
- [دمج وكلاء Azure AI مع MCP (مدونة Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### دراسة حالة 8: ملعب Foundry MCP – التجريب والنمذجة الأولية

يقدم ملعب Foundry MCP بيئة جاهزة للاستخدام للتجريب مع خوادم MCP وتكاملات Azure AI Foundry. يمكن للمطورين إنشاء نماذج أولية بسرعة، اختبار، وتقييم نماذج الذكاء الاصطناعي وسير العمل باستخدام موارد من كتالوج Azure AI Foundry والمختبرات. يبسط الملعب الإعداد، يوفر مشاريع نموذجية، ويدعم التطوير التعاوني، مما يسهل استكشاف أفضل الممارسات والسيناريوهات الجديدة بأقل جهد. هو مفيد بشكل خاص للفرق التي ترغب في التحقق من الأفكار، مشاركة التجارب، وتسريع التعلم دون الحاجة إلى بنية تحتية معقدة. من خلال خفض الحواجز، يساعد الملعب في تعزيز الابتكار والمساهمات المجتمعية في نظام MCP وAzure AI Foundry.

**المراجع:**  
- [مستودع Foundry MCP Playground على GitHub](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

## مشاريع عملية

### المشروع 1: بناء خادم MCP متعدد المزودين

**الهدف:** إنشاء خادم MCP يمكنه توجيه الطلبات إلى عدة مزودي نماذج ذكاء اصطناعي بناءً على معايير محددة.

**المتطلبات:**  
- دعم ثلاثة مزودين مختلفين على الأقل (مثل OpenAI، Anthropic، نماذج محلية)  
- تنفيذ آلية توجيه تعتمد على بيانات وصف الطلب  
- إنشاء نظام تكوين لإدارة بيانات اعتماد المزودين  
- إضافة التخزين المؤقت لتحسين الأداء والتكاليف  
- بناء لوحة تحكم بسيطة لمراقبة الاستخدام  

**خطوات التنفيذ:**  
1. إعداد البنية التحتية الأساسية لخادم MCP  
2. تنفيذ محولات المزود لكل خدمة نموذج ذكاء اصطناعي  
3. إنشاء منطق التوجيه بناءً على خصائص الطلب  
4. إضافة آليات التخزين المؤقت للطلبات المتكررة  
5. تطوير لوحة المراقبة  
6. اختبار بأنماط طلبات مختلفة  

**التقنيات:** اختر من Python (.NET/Java/Python حسب تفضيلك)، Redis للتخزين المؤقت، وإطار عمل ويب بسيط للوحة التحكم.

### المشروع 2: نظام إدارة مطالبات المؤسسات

**الهدف:** تطوير نظام قائم على MCP لإدارة، إصدار، ونشر قوالب المطالبات عبر المؤسسة.

**المتطلبات:**  
- إنشاء مستودع مركزي لقوالب المطالبات  
- تنفيذ نظام إصدار ومسارات موافقة  
- بناء قدرات اختبار القوالب باستخدام مدخلات نموذجية  
- تطوير ضوابط وصول قائمة على الأدوار  
- إنشاء API لاسترجاع ونشر القوالب  

**خطوات التنفيذ:**  
1. تصميم مخطط قاعدة البيانات لتخزين القوالب  
2. إنشاء API أساسي لعمليات CRUD على القوالب  
3. تنفيذ نظام الإصدار  
4. بناء مسار الموافقة  
5. تطوير إطار اختبار القوالب  
6. إنشاء واجهة ويب بسيطة للإدارة  
7. الدمج مع خادم MCP  

**التقنيات:** اختيارك لإطار العمل الخلفي، قاعدة بيانات SQL أو NoSQL، وإطار عمل للواجهة الأمامية.

### المشروع 3: منصة توليد المحتوى القائمة على MCP

**الهدف:** بناء منصة توليد محتوى تستخدم MCP لتوفير نتائج متسقة عبر أنواع محتوى مختلفة.

**المتطلبات:**  
- دعم تنسيقات محتوى متعددة (مقالات مدونة، وسائل التواصل الاجتماعي، نصوص تسويقية)  
- تنفيذ التوليد القائم على القوالب مع خيارات التخصيص  
- إنشاء نظام مراجعة وتعليقات على المحتوى  
- تتبع مقاييس أداء المحتوى  
- دعم إصدار وتكرار المحتوى  

**خطوات التنفيذ:**  
1. إعداد بنية MCP للعميل  
2. إنشاء قوالب لأنواع المحتوى المختلفة  
3. بناء خط أنابيب توليد المحتوى  
4. تنفيذ نظام المراجعة  
5. تطوير نظام تتبع المقاييس  
6. إنشاء واجهة مستخدم لإدارة القوالب وتوليد المحتوى  

**التقنيات:** لغة البرمجة المفضلة لديك، إطار عمل ويب، ونظام قاعدة بيانات.

## التوجهات المستقبلية لتقنية MCP

### الاتجاهات الناشئة

1. **MCP متعدد الوسائط**  
   - توسيع MCP لتوحيد التفاعلات مع نماذج الصور، الصوت، والفيديو  
   - تطوير قدرات التفكير عبر الوسائط  
   - تنسيقات مطالبات موحدة للوسائط المختلفة  

2. **بنية MCP الموزعة**  
   - شبكات MCP موزعة يمكنها مشاركة الموارد عبر المؤسسات  
   - بروتوكولات موحدة لمشاركة النماذج بأمان  
   - تقنيات الحوسبة التي تحافظ على الخصوصية  

3. **أسواق MCP**  
   - أنظمة بيئية لمشاركة وتحقيق الدخل من قوالب MCP والإضافات  
   - عمليات ضمان الجودة والشهادات  
   - التكامل مع أسواق النماذج  

4. **MCP للحوسبة الطرفية**  
   - تكييف معايير MCP لأجهزة الحوسبة الطرفية ذات الموارد المحدودة  
   - بروتوكولات محسنة لبيئات عرض النطاق الترددي المنخفض  
   - تطبيقات MCP متخصصة لأنظمة إنترنت الأشياء  

5. **الأطر التنظيمية**  
   - تطوير امتدادات MCP للامتثال التنظيمي  
   - مسارات تدقيق موحدة وواجهات الشرح  
   - التكامل مع أطر حوكمة الذكاء الاصطناعي الناشئة  

### حلول MCP من Microsoft

طورت Microsoft وAzure عدة مستودعات مفتوحة المصدر لمساعدة المطورين على تنفيذ MCP في سيناريوهات مختلفة:

#### منظمة Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - خادم Playwright MCP لأتمتة المتصفح والاختبار  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - تنفيذ خادم MCP لـ OneDrive للاختبار المحلي والمساهمة المجتمعية  
3. [NLWeb](https://github.com/microsoft/NlWeb) - مجموعة من البروتوكولات المفتوحة والأدوات مفتوحة المصدر المرتبطة، تركز على تأسيس طبقة أساسية للويب الذكي  

#### منظمة Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - روابط إلى عينات، أدوات، وموارد لبناء ودمج خوادم MCP على Azure باستخدام لغات متعددة  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - خوادم MCP مرجعية توضح المصادقة مع مواصفات بروتوكول سياق النموذج الحالية  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - صفحة هبوط لتطبيقات خادم MCP البعيد في Azure Functions مع روابط لمستودعات خاصة باللغات  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - قالب بداية سريعة لبناء ونشر خوادم MCP بعيدة مخصصة باستخدام Azure Functions وPython  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - قالب بداية سريعة لبناء ونشر خوادم MCP بعيدة مخصصة باستخدام Azure Functions و.NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - قالب بداية سريعة لبناء ونشر خوادم MCP بعيدة مخصصة باستخدام Azure Functions وTypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - إدارة واجهة برمجة التطبيقات Azure كبوابة ذكاء اصطناعي لخوادم MCP البعيدة باستخدام Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - تجارب APIM ❤️ AI تشمل قدرات MCP، وتتكامل مع Azure OpenAI وAI Foundry  

توفر هذه المستودعات تطبيقات، قوالب، وموارد متنوعة للعمل مع بروتوكول سياق النموذج عبر لغات برمجة وخدمات Azure مختلفة. تغطي مجموعة واسعة من حالات الاستخدام من تطبيقات الخادم الأساسية إلى المصادقة، النشر السحابي، وسيناريوهات التكامل المؤسسي.

#### دليل موارد MCP

يوفر [دليل موارد MCP](https://github.com/microsoft/mcp/tree/main/Resources) في المستودع الرسمي لـ Microsoft MCP مجموعة من الموارد النموذجية، قوالب المطالبات، وتعريفات الأدوات للاستخدام
- [توثيق Azure MCP](https://aka.ms/azmcp)
- [مستودع Playwright MCP Server على GitHub](https://github.com/microsoft/playwright-mcp)
- [ملفات MCP Server (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [خوادم MCP Auth (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [دوال Remote MCP (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [دوال Remote MCP بايثون (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [دوال Remote MCP .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [دوال Remote MCP TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [دوال Remote MCP APIM بايثون (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [بوابة AI (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [حلول Microsoft للذكاء الاصطناعي والأتمتة](https://azure.microsoft.com/en-us/products/ai-services/)

## التمارين

1. حلل إحدى دراسات الحالة واقترح نهج تنفيذ بديل.
2. اختر أحد أفكار المشاريع وقم بإعداد مواصفة فنية مفصلة.
3. ابحث في صناعة غير مغطاة في دراسات الحالة وحدد كيف يمكن لـ MCP معالجة تحدياتها الخاصة.
4. استكشف أحد الاتجاهات المستقبلية وابتكر مفهومًا لامتداد جديد لـ MCP لدعمه.

التالي: [أفضل الممارسات](../08-BestPractices/README.md)

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. بالنسبة للمعلومات الحساسة، يُنصح بالاعتماد على الترجمة المهنية البشرية. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ناتج عن استخدام هذه الترجمة.