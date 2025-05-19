<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T21:29:52+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ar"
}
-->
# دروس من المتبنين الأوائل

## نظرة عامة

تستعرض هذه الدرس كيف استفاد المتبنون الأوائل من بروتوكول سياق النموذج (MCP) لحل تحديات العالم الحقيقي ودفع الابتكار عبر الصناعات. من خلال دراسات حالة مفصلة ومشاريع تطبيقية، سترى كيف يمكّن MCP من دمج الذكاء الاصطناعي بطريقة موحدة، آمنة وقابلة للتوسع—موصلًا بين نماذج اللغة الكبيرة، الأدوات، وبيانات المؤسسات ضمن إطار موحد. ستكتسب خبرة عملية في تصميم وبناء حلول قائمة على MCP، وتتعلم من أنماط التنفيذ المثبتة، وتكتشف أفضل الممارسات لنشر MCP في بيئات الإنتاج. كما يسلط الدرس الضوء على الاتجاهات الناشئة، الاتجاهات المستقبلية، والموارد مفتوحة المصدر لمساعدتك على البقاء في طليعة تكنولوجيا MCP ونظامها البيئي المتطور.

## أهداف التعلم

- تحليل تطبيقات MCP الواقعية عبر صناعات مختلفة  
- تصميم وبناء تطبيقات كاملة قائمة على MCP  
- استكشاف الاتجاهات الناشئة والاتجاهات المستقبلية في تكنولوجيا MCP  
- تطبيق أفضل الممارسات في سيناريوهات تطوير فعلية  

## تطبيقات MCP الواقعية

### دراسة حالة 1: أتمتة دعم العملاء في المؤسسات

طبقت شركة متعددة الجنسيات حلاً قائمًا على MCP لتوحيد تفاعلات الذكاء الاصطناعي عبر أنظمة دعم العملاء الخاصة بها. سمح لهم ذلك بـ:

- إنشاء واجهة موحدة لمزودي نماذج اللغة الكبيرة المتعددة  
- الحفاظ على إدارة مطالبات متسقة عبر الأقسام  
- تنفيذ ضوابط أمان وامتثال قوية  
- التبديل بسهولة بين نماذج الذكاء الاصطناعي المختلفة حسب الاحتياجات المحددة  

**التنفيذ الفني:**  
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

**النتائج:** تقليل تكاليف النماذج بنسبة 30%، تحسين الاتساق في الاستجابة بنسبة 45%، وتعزيز الامتثال عبر العمليات العالمية.

### دراسة حالة 2: مساعد تشخيص الرعاية الصحية

طور مقدم خدمات صحية بنية تحتية لـ MCP لدمج نماذج طبية متخصصة متعددة مع ضمان حماية بيانات المرضى الحساسة:

- التبديل السلس بين نماذج طبية عامة ومتخصصة  
- ضوابط خصوصية صارمة ومسارات تدقيق  
- التكامل مع أنظمة السجلات الصحية الإلكترونية القائمة  
- هندسة مطالبات متسقة للمصطلحات الطبية  

**التنفيذ الفني:**  
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
- تنفيذ ضوابط وصول صارمة وإصدار نسخ للنماذج  
- ضمان إمكانية تدقيق جميع توصيات الذكاء الاصطناعي  
- الحفاظ على تنسيق بيانات متسق عبر أنظمة متنوعة  

**التنفيذ الفني:**  
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

### دراسة حالة 4: خادم MCP لـ Microsoft Playwright لأتمتة المتصفح

طورت Microsoft [خادم Playwright MCP](https://github.com/microsoft/playwright-mcp) لتمكين أتمتة المتصفح الآمنة والموحدة من خلال بروتوكول سياق النموذج. يتيح هذا الحل لوكلاء الذكاء الاصطناعي ونماذج اللغة الكبيرة التفاعل مع متصفحات الويب بطريقة مراقبة، قابلة للتدقيق، وقابلة للتوسع—مما يمكّن حالات استخدام مثل اختبار الويب الآلي، استخراج البيانات، وسير العمل الشامل.

- يعرض قدرات أتمتة المتصفح (التنقل، ملء النماذج، التقاط لقطات الشاشة، إلخ) كأدوات MCP  
- ينفذ ضوابط وصول صارمة وعزل لمنع الإجراءات غير المصرح بها  
- يوفر سجلات تدقيق مفصلة لجميع تفاعلات المتصفح  
- يدعم التكامل مع Azure OpenAI ومزودي نماذج اللغة الكبيرة الآخرين لأتمتة مدفوعة بالوكلاء  

**التنفيذ الفني:**  
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
- توفير إطار عمل قابل لإعادة الاستخدام وقابل للتوسع لتكامل أدوات المتصفح في بيئات المؤسسات  

**المراجع:**  
- [مستودع Playwright MCP على GitHub](https://github.com/microsoft/playwright-mcp)  
- [حلول الذكاء الاصطناعي والأتمتة من Microsoft](https://azure.microsoft.com/en-us/products/ai-services/)  

### دراسة حالة 5: Azure MCP – بروتوكول سياق النموذج بمستوى المؤسسات كخدمة

يُعد Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) تنفيذ Microsoft المدار لمستوى المؤسسات لبروتوكول سياق النموذج، مصمم لتوفير قدرات خادم MCP قابلة للتوسع، آمنة ومتوافقة كخدمة سحابية. يمكّن Azure MCP المؤسسات من نشر وإدارة ودمج خوادم MCP بسرعة مع خدمات Azure AI والبيانات والأمان، مما يقلل من عبء التشغيل ويسرع تبني الذكاء الاصطناعي.

- استضافة خادم MCP مُدارة بالكامل مع التوسع، المراقبة، والأمان المدمج  
- تكامل أصلي مع Azure OpenAI، Azure AI Search، وخدمات Azure الأخرى  
- مصادقة وتفويض مؤسسي عبر Microsoft Entra ID  
- دعم الأدوات المخصصة، قوالب المطالبات، وموصلات الموارد  
- الامتثال لمتطلبات الأمان والتنظيم المؤسسية  

**التنفيذ الفني:**  
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
- تقليل زمن القيمة لمشاريع الذكاء الاصطناعي المؤسسية من خلال توفير منصة خادم MCP جاهزة ومتوافقة  
- تبسيط دمج نماذج اللغة الكبيرة، الأدوات، ومصادر بيانات المؤسسات  
- تعزيز الأمان، القابلية للرصد، والكفاءة التشغيلية لأعباء عمل MCP  

**المراجع:**  
- [توثيق Azure MCP](https://aka.ms/azmcp)  
- [خدمات Azure AI](https://azure.microsoft.com/en-us/products/ai-services/)  

## دراسة حالة 6: NLWeb  
MCP (بروتوكول سياق النموذج) هو بروتوكول ناشئ للدردشة وروبوتات الذكاء الاصطناعي للتفاعل مع الأدوات. كل مثيل من NLWeb هو أيضًا خادم MCP، يدعم طريقة أساسية واحدة، ask، تُستخدم لطرح سؤال على موقع ويب بلغة طبيعية. تستفيد الاستجابة المرجعة من schema.org، وهي مفردات مستخدمة على نطاق واسع لوصف بيانات الويب. بشكل عام، MCP يشبه NLWeb كما HTTP يشبه HTML. يجمع NLWeb بين البروتوكولات، صيغ Schema.org، وأمثلة الشيفرة لمساعدة المواقع على إنشاء هذه النقاط النهائية بسرعة، مستفيدًا بذلك البشر من خلال واجهات المحادثة والآلات من خلال التفاعل الطبيعي بين الوكلاء.

هناك مكونان مميزان لـ NLWeb.  
- بروتوكول بسيط للبدء، للتفاعل مع الموقع بلغة طبيعية وصيغة تعتمد على json وschema.org للإجابة المرجعة. راجع التوثيق الخاص بواجهة REST API لمزيد من التفاصيل.  
- تنفيذ مباشر لـ (1) يستفيد من العلامات الموجودة، للمواقع التي يمكن تجريدها كقوائم عناصر (منتجات، وصفات، معالم، مراجعات، إلخ). مع مجموعة من عناصر واجهة المستخدم، يمكن للمواقع تقديم واجهات محادثة بسهولة لمحتواها. راجع التوثيق حول Life of a chat query لمزيد من التفاصيل حول كيفية عمل ذلك.  

**المراجع:**  
- [توثيق Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

## مشاريع تطبيقية

### المشروع 1: بناء خادم MCP متعدد المزودين

**الهدف:** إنشاء خادم MCP يمكنه توجيه الطلبات إلى مزودي نماذج ذكاء اصطناعي متعددين بناءً على معايير محددة.

**المتطلبات:**  
- دعم ثلاثة مزودين مختلفين على الأقل (مثل OpenAI، Anthropic، النماذج المحلية)  
- تنفيذ آلية توجيه بناءً على بيانات وصفية للطلب  
- إنشاء نظام تكوين لإدارة بيانات اعتماد المزودين  
- إضافة التخزين المؤقت لتحسين الأداء والتكاليف  
- بناء لوحة تحكم بسيطة لمراقبة الاستخدام  

**خطوات التنفيذ:**  
1. إعداد البنية التحتية الأساسية لخادم MCP  
2. تنفيذ محولات المزود لكل خدمة نموذج ذكاء اصطناعي  
3. إنشاء منطق التوجيه بناءً على سمات الطلب  
4. إضافة آليات التخزين المؤقت للطلبات المتكررة  
5. تطوير لوحة المراقبة  
6. اختبار بأنماط طلب مختلفة  

**التقنيات:** اختر من Python (.NET/Java/Python حسب تفضيلك)، Redis للتخزين المؤقت، وإطار عمل ويب بسيط للوحة التحكم.

### المشروع 2: نظام إدارة المطالبات المؤسسي

**الهدف:** تطوير نظام قائم على MCP لإدارة، إصدار نسخ، ونشر قوالب المطالبات عبر المؤسسة.

**المتطلبات:**  
- إنشاء مستودع مركزي لقوالب المطالبات  
- تنفيذ نظام إصدار نسخ وسير عمل للموافقة  
- بناء قدرات اختبار القوالب مع مدخلات نموذجية  
- تطوير ضوابط وصول قائمة على الأدوار  
- إنشاء API لاسترجاع ونشر القوالب  

**خطوات التنفيذ:**  
1. تصميم مخطط قاعدة البيانات لتخزين القوالب  
2. إنشاء API أساسي لعمليات CRUD على القوالب  
3. تنفيذ نظام إصدار النسخ  
4. بناء سير عمل الموافقة  
5. تطوير إطار اختبار  
6. إنشاء واجهة ويب بسيطة للإدارة  
7. التكامل مع خادم MCP  

**التقنيات:** اختيارك لإطار العمل الخلفي، قاعدة بيانات SQL أو NoSQL، وإطار عمل الواجهة الأمامية للإدارة.

### المشروع 3: منصة توليد المحتوى القائمة على MCP

**الهدف:** بناء منصة توليد محتوى تستفيد من MCP لتوفير نتائج متسقة عبر أنواع محتوى مختلفة.

**المتطلبات:**  
- دعم صيغ محتوى متعددة (مقالات مدونة، وسائل التواصل الاجتماعي، نسخ تسويقية)  
- تنفيذ توليد قائم على القوالب مع خيارات تخصيص  
- إنشاء نظام مراجعة وتعليقات على المحتوى  
- تتبع مقاييس أداء المحتوى  
- دعم إصدار نسخ المحتوى والتكرار  

**خطوات التنفيذ:**  
1. إعداد بنية MCP للعميل  
2. إنشاء قوالب لأنواع المحتوى المختلفة  
3. بناء خط توليد المحتوى  
4. تنفيذ نظام المراجعة  
5. تطوير نظام تتبع المقاييس  
6. إنشاء واجهة مستخدم لإدارة القوالب وتوليد المحتوى  

**التقنيات:** لغة البرمجة المفضلة لديك، إطار عمل الويب، ونظام قاعدة البيانات.

## الاتجاهات المستقبلية لتقنية MCP

### الاتجاهات الناشئة

1. **MCP متعدد الوسائط**  
   - توسيع MCP لتوحيد التفاعلات مع نماذج الصور، الصوت، والفيديو  
   - تطوير قدرات الاستدلال عبر الوسائط  
   - صيغ مطالبات موحدة للوسائط المختلفة  

2. **بنية MCP الموزعة**  
   - شبكات MCP موزعة يمكنها مشاركة الموارد عبر المؤسسات  
   - بروتوكولات موحدة لمشاركة النماذج بأمان  
   - تقنيات حساب تحافظ على الخصوصية  

3. **أسواق MCP**  
   - أنظمة بيئية لمشاركة وتحقيق الدخل من قوالب MCP والإضافات  
   - عمليات ضمان الجودة والشهادات  
   - التكامل مع أسواق النماذج  

4. **MCP للحوسبة الطرفية**  
   - تكييف معايير MCP للأجهزة الطرفية محدودة الموارد  
   - بروتوكولات محسنة لبيئات ذات عرض نطاق منخفض  
   - تطبيقات MCP متخصصة لنظم إنترنت الأشياء  

5. **الأطر التنظيمية**  
   - تطوير امتدادات MCP للامتثال التنظيمي  
   - مسارات تدقيق موحدة وواجهات شرح  
   - التكامل مع أطر حوكمة الذكاء الاصطناعي الناشئة  

### حلول MCP من Microsoft

طورت Microsoft وAzure عدة مستودعات مفتوحة المصدر لمساعدة المطورين على تنفيذ MCP في سيناريوهات مختلفة:

#### منظمة Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - خادم Playwright MCP لأتمتة المتصفح والاختبار  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - تنفيذ خادم MCP لـ OneDrive للاختبار المحلي والمساهمة المجتمعية  
3. [NLWeb](https://github.com/microsoft/NlWeb) - مجموعة من البروتوكولات المفتوحة والأدوات مفتوحة المصدر المرتبطة بها، تركز على إنشاء طبقة أساسية للويب الذكي  

#### منظمة Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - روابط لأمثلة، أدوات، وموارد لبناء ودمج خوادم MCP على Azure باستخدام لغات متعددة  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - خوادم MCP مرجعية توضح المصادقة مع مواصفة بروتوكول سياق النموذج الحالية  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - صفحة هبوط لتنفيذات خوادم MCP عن بعد باستخدام Azure Functions مع روابط للمستودعات الخاصة باللغات  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - قالب بدء سريع لبناء ونشر خوادم MCP مخصصة عن بعد باستخدام Azure Functions مع Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - قالب بدء سريع لبناء ونشر خوادم MCP مخصصة عن بعد باستخدام Azure Functions مع .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - قالب بدء سريع لبناء ونشر خوادم MCP مخصصة عن بعد باستخدام Azure Functions مع TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - إدارة API في Azure كبوابة ذكاء اصطناعي لخوادم MCP عن بعد باستخدام Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - تجارب APIM ❤️ AI تشمل قدرات MCP، متكاملة مع Azure OpenAI وAI Foundry  

توفر هذه المستودعات تنفيذات، قوالب، وموارد مختلفة للعمل مع بروتوكول سياق النموذج عبر لغات برمجة وخدمات Azure متنوعة. تغطي مجموعة من حالات الاستخدام من تنفيذات الخوادم الأساسية إلى المصادقة، النشر السحابي، وسيناريوهات دمج المؤسسات.

#### دليل موارد MCP

يوفر [دليل موارد MCP](https://github.com/microsoft/mcp/tree/main/Resources) في المستودع الرسمي لـ Microsoft MCP مجموعة من الموارد النموذجية، قوالب المطالبات، وتعريفات الأدوات لاستخدامها مع خوادم بروتوكول سياق النموذج. صُمم هذا الدليل لمساعدة المطورين على البدء بسرعة مع MCP من خلال تقديم مكونات قابلة لإعادة الاستخدام وأمثلة لأفضل الممارسات لـ:

- **قوالب المطالبات:** قوالب جاهزة للاستخدام لمهام وسيناريوهات الذكاء الاصطناعي الشائعة، يمكن تعديلها لتناسب تنفيذات خادم MCP الخاصة بك.  
- **تعريفات الأدوات:** أمثلة على مخططات الأدوات والبيانات الوصفية لتوحيد دمج الأدوات واستدعائها عبر خوادم MCP المختلفة.  
- **نماذج الموارد:** تعريفات موارد نموذجية للاتصال بمصادر البيانات، واجهات برمجة التطبيقات، والخدمات الخارجية ضمن إطار MCP.  
- **تنفيذات مرجعية:** أمثلة عملية توضح كيفية هيكلة وتنظيم الموارد، المطالبات، والأدوات في مشاريع MCP الواقعية.  

تسرع هذه الموارد عملية التطوير، تعزز التوحيد، وتساعد على ضمان أفضل الممارسات عند بناء ونشر حلول قائمة على MCP.

#### دليل موارد MCP  
- [موارد MCP (نماذج المطالبات، الأدوات، وتعريفات الموارد)](https://github.com/microsoft/mcp/tree/main/Resources)  

### فرص البحث

- تقنيات تحسين المطالبات الفعالة ضمن أطر MCP  
- نماذج الأمان لنشر MCP متعدد المستأجرين  
- قياس الأداء عبر تطبيقات MCP المختلفة  
- طرق التحقق الرسمية لخوادم MCP  

## الخلاصة

يشكل بروتوكول سياق النموذج (MCP) مستقبل دمج الذكاء الاصطناعي الموحد، الآمن، والقابل للتشغيل البيني عبر الصناعات بسرعة. من خلال دراسات الحالة والمشاريع التطبيقية في هذا الدرس، رأيت كيف يستخدم المتبنون الأوائل—بما في ذلك Microsoft وAzure—MCP لحل تحديات العالم الحقيقي، تسريع تبني الذكاء الاصطناعي، وضمان الامتثال، الأمان، وقابلية التوسع. تتيح منهجية MCP المعيارية للمؤسسات ربط نماذج اللغة الكبيرة، الأدوات، وبيانات المؤسسات ضمن إطار موحد وقابل للتدقيق. ومع استمرار تطور MCP، سيكون البقاء متفاعلاً مع المجتمع، استكشاف الموارد مفتوحة المصدر، وتطبيق أفضل الممارسات مفتاحًا لبناء حلول ذكاء اصطناعي قوية ومستعدة للمستقبل.

## موارد إضافية

- [مستودع MCP على Git
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## التمارين

1. تحليل إحدى دراسات الحالة واقتراح نهج تنفيذ بديل.
2. اختيار فكرة مشروع واحدة وإنشاء مواصفات فنية مفصلة لها.
3. البحث في صناعة غير مغطاة في دراسات الحالة وتوضيح كيف يمكن لـ MCP التعامل مع تحدياتها الخاصة.
4. استكشاف أحد الاتجاهات المستقبلية وإنشاء مفهوم لامتداد MCP جديد لدعم هذا الاتجاه.

التالي: [أفضل الممارسات](../08-BestPractices/README.md)

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى للدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الحساسة، يُنصح بالاستعانة بالترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ناتج عن استخدام هذه الترجمة.