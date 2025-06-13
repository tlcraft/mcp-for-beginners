<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T16:47:39+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ar"
}
-->
# دروس من المتبنين الأوائل

## نظرة عامة

تستعرض هذه الدرس كيف استخدم المتبنون الأوائل بروتوكول سياق النموذج (MCP) لحل تحديات العالم الحقيقي ودفع الابتكار عبر الصناعات. من خلال دراسات حالة مفصلة ومشاريع عملية، سترى كيف يتيح MCP تكاملًا موحدًا، آمنًا، وقابلًا للتوسع للذكاء الاصطناعي—موصلًا نماذج اللغة الكبيرة، الأدوات، وبيانات المؤسسات في إطار عمل موحد. ستحصل على خبرة عملية في تصميم وبناء حلول قائمة على MCP، تتعلم من أنماط التنفيذ المثبتة، وتكتشف أفضل الممارسات لنشر MCP في بيئات الإنتاج. كما تسلط الدرس الضوء على الاتجاهات الناشئة، الاتجاهات المستقبلية، والموارد مفتوحة المصدر لمساعدتك على البقاء في طليعة تكنولوجيا MCP ونظامها البيئي المتطور.

## أهداف التعلم

- تحليل تطبيقات MCP الواقعية عبر صناعات مختلفة  
- تصميم وبناء تطبيقات كاملة تعتمد على MCP  
- استكشاف الاتجاهات الناشئة والاتجاهات المستقبلية في تكنولوجيا MCP  
- تطبيق أفضل الممارسات في سيناريوهات التطوير الفعلية  

## تطبيقات MCP في العالم الحقيقي

### دراسة حالة 1: أتمتة دعم العملاء في المؤسسات

طبقت شركة متعددة الجنسيات حلاً قائمًا على MCP لتوحيد تفاعلات الذكاء الاصطناعي عبر أنظمة دعم العملاء الخاصة بها. سمح لهم ذلك بـ:

- إنشاء واجهة موحدة لمزودي LLM المتعددين  
- الحفاظ على إدارة موحدة للنماذج النصية عبر الأقسام  
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

**النتائج:** خفض التكاليف بنسبة 30%، تحسين اتساق الاستجابة بنسبة 45%، وتعزيز الامتثال عبر العمليات العالمية.

### دراسة حالة 2: مساعد تشخيص الرعاية الصحية

طور مقدم رعاية صحية بنية تحتية MCP لدمج نماذج طبية متخصصة متعددة مع ضمان حماية بيانات المرضى الحساسة:

- التبديل السلس بين النماذج الطبية العامة والمتخصصة  
- ضوابط خصوصية صارمة ومسارات تدقيق  
- التكامل مع أنظمة السجلات الصحية الإلكترونية (EHR) القائمة  
- هندسة موحدة للنماذج النصية للمصطلحات الطبية  

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

**النتائج:** تحسين الاقتراحات التشخيصية للأطباء مع الحفاظ على الامتثال الكامل لقانون HIPAA وتقليل كبير في تبديل السياق بين الأنظمة.

### دراسة حالة 3: تحليل المخاطر في الخدمات المالية

طبقت مؤسسة مالية MCP لتوحيد عمليات تحليل المخاطر عبر أقسام مختلفة:

- إنشاء واجهة موحدة لنماذج مخاطر الائتمان، كشف الاحتيال، ومخاطر الاستثمار  
- تنفيذ ضوابط وصول صارمة وإدارة نسخ النماذج  
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

طورت مايكروسوفت [خادم Playwright MCP](https://github.com/microsoft/playwright-mcp) لتمكين أتمتة المتصفح الآمنة والموحدة من خلال بروتوكول سياق النموذج. يسمح هذا الحل لوكلاء الذكاء الاصطناعي وLLMs بالتفاعل مع متصفحات الويب بطريقة مراقبة، قابلة للتدقيق، وقابلة للتوسيع—مما يتيح استخدامات مثل اختبار الويب الآلي، استخراج البيانات، وسير العمل من البداية للنهاية.

- يعرض قدرات أتمتة المتصفح (التنقل، تعبئة النماذج، التقاط لقطات الشاشة، إلخ) كأدوات MCP  
- ينفذ ضوابط وصول صارمة وعزل للحماية من الإجراءات غير المصرح بها  
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
- تمكين أتمتة المتصفح الآمنة والبرمجية لوكلاء الذكاء الاصطناعي وLLMs  
- تقليل الجهد اليدوي في الاختبار وتحسين تغطية الاختبارات لتطبيقات الويب  
- توفير إطار عمل قابل لإعادة الاستخدام والتوسيع لتكامل أدوات المتصفح في بيئات المؤسسات  

**المراجع:**  
- [مستودع Playwright MCP على GitHub](https://github.com/microsoft/playwright-mcp)  
- [حلول مايكروسوفت للذكاء الاصطناعي والأتمتة](https://azure.microsoft.com/en-us/products/ai-services/)

### دراسة حالة 5: Azure MCP – بروتوكول سياق النموذج كخدمة بمستوى المؤسسات

يعد Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) تنفيذًا مدارًا من مايكروسوفت لبروتوكول سياق النموذج بمستوى المؤسسات، مصممًا لتوفير قدرات خادم MCP قابلة للتوسع، آمنة ومتوافقة كخدمة سحابية. يمكّن Azure MCP المؤسسات من نشر وإدارة ودمج خوادم MCP بسرعة مع خدمات Azure AI، والبيانات، والأمان، مما يقلل العبء التشغيلي ويسرع تبني الذكاء الاصطناعي.

- استضافة خادم MCP مدار بالكامل مع التوسع المدمج، المراقبة، والأمان  
- التكامل الأصلي مع Azure OpenAI، Azure AI Search، وخدمات Azure الأخرى  
- المصادقة والتفويض على مستوى المؤسسات عبر Microsoft Entra ID  
- دعم الأدوات المخصصة، قوالب النماذج النصية، وموصلات الموارد  
- الامتثال لمتطلبات الأمان والتنظيم للمؤسسات  

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
- تقليل الوقت للوصول إلى القيمة في مشاريع الذكاء الاصطناعي المؤسسية من خلال توفير منصة خادم MCP جاهزة للاستخدام ومتوافقة  
- تبسيط تكامل LLMs، الأدوات، ومصادر بيانات المؤسسات  
- تعزيز الأمان، القابلية للمراقبة، والكفاءة التشغيلية لأعباء عمل MCP  

**المراجع:**  
- [توثيق Azure MCP](https://aka.ms/azmcp)  
- [خدمات Azure AI](https://azure.microsoft.com/en-us/products/ai-services/)

## دراسة حالة 6: NLWeb  
MCP (بروتوكول سياق النموذج) هو بروتوكول ناشئ للدردشة والمساعدين الذكيين للتفاعل مع الأدوات. كل مثيل NLWeb هو أيضًا خادم MCP، يدعم طريقة أساسية واحدة، ask، تُستخدم لطرح سؤال على موقع ويب بلغة طبيعية. تعتمد الاستجابة المعادة على schema.org، وهي مفردات مستخدمة على نطاق واسع لوصف بيانات الويب. يمكن القول بشكل مبسط إن MCP هو NLWeb كما أن Http هو لـ HTML. يجمع NLWeb بين البروتوكولات، تنسيقات Schema.org، وأكواد نموذجية لمساعدة المواقع على إنشاء هذه النقاط النهائية بسرعة، مستفيدًا من واجهات المحادثة للبشر والتفاعل الطبيعي بين الوكلاء للآلات.

يوجد مكونان مميزان لـ NLWeb.  
- بروتوكول بسيط للبدء، للتفاعل مع موقع بلغة طبيعية وتنسيق يستخدم json وschema.org للإجابة المعادة. انظر التوثيق الخاص بواجهة REST API لمزيد من التفاصيل.  
- تنفيذ مباشر (1) يستفيد من العلامات الموجودة للمواقع التي يمكن تجريدها كقوائم عناصر (منتجات، وصفات، معالم، مراجعات، إلخ). مع مجموعة من عناصر واجهة المستخدم، يمكن للمواقع بسهولة توفير واجهات محادثة لمحتواها. انظر التوثيق حول حياة استعلام الدردشة لمزيد من التفاصيل حول كيفية عمل ذلك.  

**المراجع:**  
- [توثيق Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### دراسة حالة 7: MCP لـ Foundry – دمج وكلاء Azure AI

تُظهر خوادم Azure AI Foundry MCP كيف يمكن استخدام MCP لتنظيم وإدارة وكلاء الذكاء الاصطناعي وسير العمل في بيئات المؤسسات. من خلال دمج MCP مع Azure AI Foundry، يمكن للمؤسسات توحيد تفاعلات الوكلاء، الاستفادة من إدارة سير العمل في Foundry، وضمان نشرات آمنة وقابلة للتوسع. تتيح هذه الطريقة النمذجة السريعة، المراقبة القوية، والتكامل السلس مع خدمات Azure AI، داعمة سيناريوهات متقدمة مثل إدارة المعرفة وتقييم الوكلاء. يستفيد المطورون من واجهة موحدة لبناء، نشر، ومراقبة خطوط أنابيب الوكلاء، بينما تحصل فرق تكنولوجيا المعلومات على أمان، امتثال، وكفاءة تشغيلية محسنة. الحل مثالي للمؤسسات التي تسعى لتسريع تبني الذكاء الاصطناعي والحفاظ على السيطرة على العمليات المعقدة المدفوعة بالوكلاء.

**المراجع:**  
- [مستودع MCP Foundry على GitHub](https://github.com/azure-ai-foundry/mcp-foundry)  
- [دمج وكلاء Azure AI مع MCP (مدونة Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### دراسة حالة 8: ملعب Foundry MCP – التجريب والنمذجة الأولية

يقدم ملعب Foundry MCP بيئة جاهزة للاستخدام لتجربة خوادم MCP وتكاملات Azure AI Foundry. يمكن للمطورين نمذجة واختبار وتقييم نماذج الذكاء الاصطناعي وسير العمل باستخدام موارد من كتالوج ومختبرات Azure AI Foundry. يسهل الملعب الإعداد، يوفر مشاريع نموذجية، ويدعم التطوير التعاوني، مما يجعل استكشاف أفضل الممارسات والسيناريوهات الجديدة سهلاً مع أقل جهد ممكن. مفيد بشكل خاص للفرق التي ترغب في التحقق من الأفكار، مشاركة التجارب، وتسريع التعلم دون الحاجة إلى بنية تحتية معقدة. من خلال خفض الحواجز، يساعد الملعب على تعزيز الابتكار والمساهمات المجتمعية في نظام MCP وAzure AI Foundry.

**المراجع:**  
- [مستودع ملعب Foundry MCP على GitHub](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### دراسة حالة 9: خادم Microsoft Docs MCP – التعلم والتدريب  
ينفذ خادم Microsoft Docs MCP بروتوكول سياق النموذج (MCP) الذي يوفر للمساعدين الذكيين وصولًا فوريًا إلى الوثائق الرسمية لمايكروسوفت. ينفذ بحثًا دلاليًا مقابل الوثائق الفنية الرسمية لمايكروسوفت.

**المراجع:**  
- [خادم Microsoft Learn Docs MCP](https://github.com/MicrosoftDocs/mcp)

## مشاريع عملية

### المشروع 1: بناء خادم MCP متعدد المزودين

**الهدف:** إنشاء خادم MCP يمكنه توجيه الطلبات إلى عدة مزودي نماذج ذكاء اصطناعي بناءً على معايير محددة.

**المتطلبات:**  
- دعم ثلاثة مزودين مختلفين على الأقل (مثل OpenAI، Anthropic، نماذج محلية)  
- تنفيذ آلية توجيه تعتمد على بيانات تعريف الطلب  
- إنشاء نظام تكوين لإدارة بيانات اعتماد المزودين  
- إضافة التخزين المؤقت لتحسين الأداء والتكاليف  
- بناء لوحة مراقبة بسيطة لمتابعة الاستخدام  

**خطوات التنفيذ:**  
1. إعداد بنية خادم MCP الأساسية  
2. تنفيذ محولات المزود لكل خدمة نموذج ذكاء اصطناعي  
3. إنشاء منطق التوجيه بناءً على سمات الطلب  
4. إضافة آليات التخزين المؤقت للطلبات المتكررة  
5. تطوير لوحة المراقبة  
6. اختبار مع أنماط طلبات مختلفة  

**التقنيات:** اختر من بين Python (.NET/Java/Python حسب تفضيلك)، Redis للتخزين المؤقت، وإطار ويب بسيط للوحة المراقبة.

### المشروع 2: نظام إدارة النماذج النصية للمؤسسات

**الهدف:** تطوير نظام قائم على MCP لإدارة، إصدار، ونشر قوالب النماذج النصية عبر المؤسسة.

**المتطلبات:**  
- إنشاء مستودع مركزي لقوالب النماذج النصية  
- تنفيذ نظام إصدار وسير عمل للموافقة  
- بناء قدرات اختبار القوالب مع مدخلات نموذجية  
- تطوير ضوابط وصول قائمة على الأدوار  
- إنشاء API لاسترجاع القوالب ونشرها  

**خطوات التنفيذ:**  
1. تصميم مخطط قاعدة البيانات لتخزين القوالب  
2. إنشاء API أساسي لعمليات CRUD على القوالب  
3. تنفيذ نظام الإصدار  
4. بناء سير عمل الموافقة  
5. تطوير إطار اختبار القوالب  
6. إنشاء واجهة ويب بسيطة للإدارة  
7. التكامل مع خادم MCP  

**التقنيات:** اختيارك لإطار العمل الخلفي، قاعدة بيانات SQL أو NoSQL، وإطار عمل الواجهة الأمامية للإدارة.

### المشروع 3: منصة توليد المحتوى القائمة على MCP

**الهدف:** بناء منصة توليد محتوى تستفيد من MCP لتقديم نتائج متسقة عبر أنواع محتوى مختلفة.

**المتطلبات:**  
- دعم تنسيقات محتوى متعددة (مقالات مدونة، وسائل التواصل الاجتماعي، نسخ تسويقية)  
- تنفيذ التوليد المعتمد على القوالب مع خيارات التخصيص  
- إنشاء نظام مراجعة المحتوى والتغذية الراجعة  
- تتبع مقاييس أداء المحتوى  
- دعم إصدار وتكرار المحتوى  

**خطوات التنفيذ:**  
1. إعداد بنية عميل MCP  
2. إنشاء قوالب لأنواع المحتوى المختلفة  
3. بناء خط توليد المحتوى  
4. تنفيذ نظام المراجعة  
5. تطوير نظام تتبع المقاييس  
6. إنشاء واجهة مستخدم لإدارة القوالب وتوليد المحتوى  

**التقنيات:** لغة البرمجة المفضلة لديك، إطار ويب، ونظام قاعدة بيانات.

## الاتجاهات المستقبلية لتكنولوجيا MCP

### الاتجاهات الناشئة

1. **MCP متعدد الوسائط**  
   - توسيع MCP لتوحيد التفاعلات مع نماذج الصور، الصوت، والفيديو  
   - تطوير قدرات الاستدلال عبر الوسائط  
   - تنسيقات نماذج موحدة للوسائط المختلفة  

2. **بنية MCP الفدرالية**  
   - شبكات MCP موزعة يمكنها مشاركة الموارد عبر المؤسسات  
   - بروتوكولات موحدة لمشاركة النماذج بأمان  
   - تقنيات حساب تحافظ على الخصوصية  

3. **أسواق MCP**  
   - أنظمة بيئية لمشاركة وتحقيق الدخل من قوالب MCP والإضافات  
   - عمليات ضمان الجودة والشهادات  
   - التكامل مع أسواق النماذج  

4. **MCP للحوسبة الطرفية**  
   - تكييف معايير MCP لأجهزة الحافة ذات الموارد المحدودة  
   - بروتوكولات محسنة لبيئات النطاق الترددي المنخفض  
   - تنفيذات MCP متخصصة لنظم إنترنت الأشياء  

5. **الأطر التنظيمية**  
   - تطوير امتدادات MCP للامتثال التنظيمي  
   - مسارات تدقيق موحدة وواجهات توضيحية  
   - التكامل مع أطر حوكمة الذكاء الاصطناعي الناشئة  

### حلول MCP من مايكروسوفت

طورت مايكروسوفت وأزور عدة مستودعات مفتوحة المصدر لمساعدة المطورين على تنفيذ MCP في سيناريوهات مختلفة:

#### منظمة Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - خادم Playwright MCP لأتمتة المتصفح والاختبار  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - تنفيذ خادم MCP لـ OneDrive للاختبار المحلي والمساهمة المجتمعية  
3. [NLWeb](https://github.com/microsoft/NlWeb) - مجموعة بروتوكولات مفتوحة وأدوات مفتوحة المصدر، تركز على تأسيس طبقة أساسية للويب الذكي  

#### منظمة Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - روابط لعينات، أدوات، وموارد لبناء ودمج خوادم MCP على Azure باستخدام لغات متعددة  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - خوادم MCP مرجعية توضح المصادقة وفقًا لمواصفات بروتوكول سياق النموذج الحالية  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - صفحة رئيسية لتنفيذات خوادم MCP عن بُعد في Azure Functions مع روابط لمستودعات خاصة باللغات  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - قالب بدء سريع لبناء ونشر خوادم MCP عن بُعد مخصصة باستخدام Azure Functions وPython  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - قالب بدء سريع لبناء ونشر خوادم MCP عن بُعد مخصصة باستخدام Azure Functions و.NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - قالب بدء سريع لبناء ونشر خوادم MCP عن بُعد مخصصة باستخدام Azure Functions وTypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - إدارة API في Azure كبوابة ذكاء اصطناعي لخوادم MCP عن بُعد باستخدام Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - تجارب APIM ❤️ AI تشمل قدرات MCP، متكاملة مع Azure OpenAI و
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

## التمارين

1. حلل إحدى دراسات الحالة واقترح نهج تنفيذ بديل.
2. اختر أحد أفكار المشاريع وأنشئ مواصفات فنية مفصلة.
3. ابحث في صناعة غير مغطاة في دراسات الحالة وحدد كيف يمكن لـ MCP التعامل مع تحدياتها الخاصة.
4. استكشف أحد الاتجاهات المستقبلية وأنشئ مفهومًا لامتداد MCP جديد لدعمها.

التالي: [Best Practices](../08-BestPractices/README.md)

**إخلاء مسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الرسمي والمعتمد. بالنسبة للمعلومات الهامة، يُنصح بالاستعانة بالترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.