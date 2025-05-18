<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:02:12+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ar"
}
-->
# دروس من المتبنين الأوائل

## نظرة عامة

يستكشف هذا الدرس كيفية استخدام المتبنين الأوائل لبروتوكول سياق النموذج (MCP) لحل تحديات العالم الحقيقي ودفع الابتكار عبر الصناعات. من خلال دراسات حالة مفصلة ومشاريع عملية، ستتعرف على كيفية تمكين MCP من التكامل القياسي والآمن والقابل للتوسع للذكاء الاصطناعي - حيث يربط بين نماذج اللغة الكبيرة والأدوات وبيانات الشركات في إطار موحد. ستكتسب خبرة عملية في تصميم وبناء حلول تعتمد على MCP، وتتعلم من أنماط التنفيذ المثبتة، وتكتشف أفضل الممارسات لنشر MCP في بيئات الإنتاج. كما يسلط الدرس الضوء على الاتجاهات الناشئة، والتوجهات المستقبلية، والموارد مفتوحة المصدر لمساعدتك على البقاء في طليعة تكنولوجيا MCP ونظامها البيئي المتطور.

## أهداف التعلم

- تحليل تطبيقات MCP في العالم الحقيقي عبر مختلف الصناعات
- تصميم وبناء تطبيقات كاملة تعتمد على MCP
- استكشاف الاتجاهات الناشئة والتوجهات المستقبلية في تكنولوجيا MCP
- تطبيق أفضل الممارسات في سيناريوهات التطوير الفعلية

## تطبيقات MCP في العالم الحقيقي

### دراسة حالة 1: أتمتة دعم العملاء في الشركات

قامت شركة متعددة الجنسيات بتنفيذ حل يعتمد على MCP لتوحيد التفاعلات الذكية عبر أنظمة دعم العملاء الخاصة بها. مما سمح لهم بـ:

- إنشاء واجهة موحدة لمزودي LLM المتعددين
- الحفاظ على إدارة موحدة للتوجيه عبر الأقسام
- تنفيذ ضوابط أمنية وامتثال قوية
- التبديل بسهولة بين نماذج الذكاء الاصطناعي المختلفة بناءً على الاحتياجات المحددة

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

**النتائج:** تقليل تكاليف النموذج بنسبة 30%، تحسين اتساق الاستجابة بنسبة 45%، وتعزيز الامتثال عبر العمليات العالمية.

### دراسة حالة 2: مساعد تشخيص الرعاية الصحية

طورت جهة مقدمة للرعاية الصحية بنية تحتية MCP لدمج نماذج الذكاء الاصطناعي الطبية المتخصصة المتعددة مع ضمان حماية بيانات المرضى الحساسة:

- التبديل السلس بين النماذج الطبية العامة والمتخصصة
- ضوابط صارمة للخصوصية ومسارات التدقيق
- التكامل مع أنظمة السجلات الصحية الإلكترونية (EHR) الحالية
- هندسة توجيه موحدة للمصطلحات الطبية

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

**النتائج:** تحسين اقتراحات التشخيص للأطباء مع الحفاظ على الامتثال الكامل لـ HIPAA وتقليل كبير في تبديل السياق بين الأنظمة.

### دراسة حالة 3: تحليل المخاطر في الخدمات المالية

قامت مؤسسة مالية بتنفيذ MCP لتوحيد عمليات تحليل المخاطر عبر الأقسام المختلفة:

- إنشاء واجهة موحدة لنماذج المخاطر الائتمانية والكشف عن الاحتيال والمخاطر الاستثمارية
- تنفيذ ضوابط صارمة للوصول وتحديد إصدارات النموذج
- ضمان قابلية التدقيق لجميع توصيات الذكاء الاصطناعي
- الحفاظ على تنسيق البيانات الموحد عبر الأنظمة المتنوعة

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

**النتائج:** تحسين الامتثال التنظيمي، تسريع دورات نشر النموذج بنسبة 40%، وتحسين اتساق تقييم المخاطر عبر الأقسام.

### دراسة حالة 4: خادم MCP لـ Microsoft Playwright لأتمتة المتصفح

طورت Microsoft [خادم Playwright MCP](https://github.com/microsoft/playwright-mcp) لتمكين أتمتة المتصفح الآمنة والقياسية من خلال بروتوكول سياق النموذج. يتيح هذا الحل لوكلاء الذكاء الاصطناعي وLLMs التفاعل مع متصفحات الويب بطريقة محكومة وقابلة للتدقيق وقابلة للتوسيع - مما يتيح حالات الاستخدام مثل اختبار الويب الآلي، واستخراج البيانات، وسير العمل الشامل.

- يكشف عن قدرات أتمتة المتصفح (التنقل، ملء النماذج، التقاط لقطات الشاشة، إلخ) كأدوات MCP
- ينفذ ضوابط وصول صارمة وعزل لمنع الإجراءات غير المصرح بها
- يوفر سجلات تدقيق مفصلة لجميع تفاعلات المتصفح
- يدعم التكامل مع Azure OpenAI ومزودي LLM الآخرين لأتمتة الوكلاء

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
- تمكين أتمتة المتصفح البرمجية الآمنة لوكلاء الذكاء الاصطناعي وLLMs
- تقليل الجهد في الاختبار اليدوي وتحسين تغطية الاختبار لتطبيقات الويب
- توفير إطار عمل قابل لإعادة الاستخدام والتوسيع لتكامل أدوات المتصفح في بيئات الشركات

**المراجع:**  
- [مستودع GitHub لخادم Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [حلول Microsoft للذكاء الاصطناعي والأتمتة](https://azure.microsoft.com/en-us/products/ai-services/)

### دراسة حالة 5: Azure MCP – بروتوكول سياق النموذج كخدمة على مستوى الشركات

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) هو تنفيذ مُدار من Microsoft على مستوى الشركات لبروتوكول سياق النموذج، مصمم لتوفير قدرات خادم MCP قابلة للتوسع وآمنة ومتوافقة كخدمة سحابية. يتيح Azure MCP للمؤسسات نشر وإدارة وتكامل خوادم MCP بسرعة مع خدمات Azure AI والبيانات والأمان، مما يقلل من العبء التشغيلي ويسرع اعتماد الذكاء الاصطناعي.

- استضافة خادم MCP مُدارة بالكامل مع التوسع والمراقبة والأمان المدمجين
- التكامل الأصلي مع Azure OpenAI وAzure AI Search وخدمات Azure الأخرى
- المصادقة والتفويض على مستوى الشركات عبر Microsoft Entra ID
- دعم الأدوات المخصصة وقوالب التوجيه وموصلات الموارد
- الامتثال لمتطلبات الأمان واللوائح على مستوى الشركات

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
- تقليل الوقت للوصول للقيمة لمشاريع الذكاء الاصطناعي في الشركات من خلال توفير منصة خادم MCP جاهزة للاستخدام ومتوافقة
- تبسيط تكامل LLMs والأدوات ومصادر بيانات الشركات
- تعزيز الأمان والمراقبة والكفاءة التشغيلية لأحمال عمل MCP

**المراجع:**  
- [وثائق Azure MCP](https://aka.ms/azmcp)
- [خدمات Azure AI](https://azure.microsoft.com/en-us/products/ai-services/)

## المشاريع العملية

### المشروع 1: بناء خادم MCP متعدد المزودين

**الهدف:** إنشاء خادم MCP يمكنه توجيه الطلبات إلى مزودي نماذج الذكاء الاصطناعي المتعددين بناءً على معايير محددة.

**المتطلبات:**
- دعم ثلاثة مزودين مختلفين على الأقل للنماذج (مثل OpenAI، Anthropic، النماذج المحلية)
- تنفيذ آلية توجيه بناءً على بيانات الطلب
- إنشاء نظام تكوين لإدارة بيانات اعتماد المزودين
- إضافة التخزين المؤقت لتحسين الأداء والتكاليف
- بناء لوحة معلومات بسيطة لمراقبة الاستخدام

**خطوات التنفيذ:**
1. إعداد البنية التحتية الأساسية لخادم MCP
2. تنفيذ محولات المزود لكل خدمة نموذج ذكاء اصطناعي
3. إنشاء منطق التوجيه بناءً على سمات الطلب
4. إضافة آليات التخزين المؤقت للطلبات المتكررة
5. تطوير لوحة معلومات المراقبة
6. اختبار مع أنماط الطلبات المختلفة

**التقنيات:** اختر من بين Python (.NET/Java/Python بناءً على تفضيلك)، Redis للتخزين المؤقت، وإطار عمل ويب بسيط للوحة المعلومات.

### المشروع 2: نظام إدارة التوجيه على مستوى الشركات

**الهدف:** تطوير نظام يعتمد على MCP لإدارة وتحديد إصدارات ونشر قوالب التوجيه عبر المؤسسة.

**المتطلبات:**
- إنشاء مستودع مركزي لقوالب التوجيه
- تنفيذ أنظمة تحديد الإصدارات وموافقات سير العمل
- بناء قدرات اختبار القوالب مع مدخلات نموذجية
- تطوير ضوابط الوصول المستندة إلى الأدوار
- إنشاء واجهة برمجة تطبيقات لاسترجاع ونشر القوالب

**خطوات التنفيذ:**
1. تصميم مخطط قاعدة البيانات لتخزين القوالب
2. إنشاء واجهة برمجة التطبيقات الأساسية لعمليات CRUD للقوالب
3. تنفيذ نظام تحديد الإصدارات
4. بناء سير عمل الموافقة
5. تطوير إطار العمل للاختبار
6. إنشاء واجهة ويب بسيطة للإدارة
7. التكامل مع خادم MCP

**التقنيات:** اختيارك لإطار العمل الخلفي، قاعدة بيانات SQL أو NoSQL، وإطار عمل واجهة أمامية لواجهة الإدارة.

### المشروع 3: منصة توليد المحتوى القائمة على MCP

**الهدف:** بناء منصة توليد محتوى تستفيد من MCP لتقديم نتائج متسقة عبر أنواع مختلفة من المحتوى.

**المتطلبات:**
- دعم تنسيقات متعددة للمحتوى (مقالات المدونة، وسائل التواصل الاجتماعي، نصوص التسويق)
- تنفيذ توليد قائم على القوالب مع خيارات التخصيص
- إنشاء نظام مراجعة وتغذية راجعة للمحتوى
- تتبع مقاييس أداء المحتوى
- دعم تحديد إصدارات المحتوى والتكرار

**خطوات التنفيذ:**
1. إعداد بنية العميل MCP
2. إنشاء قوالب لأنواع المحتوى المختلفة
3. بناء خط أنابيب توليد المحتوى
4. تنفيذ نظام المراجعة
5. تطوير نظام تتبع المقاييس
6. إنشاء واجهة مستخدم لإدارة القوالب وتوليد المحتوى

**التقنيات:** لغة البرمجة المفضلة لديك، إطار عمل الويب، ونظام قاعدة البيانات.

## التوجهات المستقبلية لتكنولوجيا MCP

### الاتجاهات الناشئة

1. **MCP متعدد الوسائط**
   - توسيع MCP لتوحيد التفاعلات مع نماذج الصور والصوت والفيديو
   - تطوير قدرات التفكير عبر الوسائط
   - تنسيق توجيهات موحدة للوسائط المختلفة

2. **بنية تحتية MCP الموزعة**
   - شبكات MCP الموزعة التي يمكنها مشاركة الموارد عبر المؤسسات
   - بروتوكولات موحدة لمشاركة النماذج الآمنة
   - تقنيات الحوسبة المحافِظة على الخصوصية

3. **أسواق MCP**
   - أنظمة بيئية لمشاركة وتداول قوالب MCP والإضافات
   - عمليات ضمان الجودة والشهادات
   - التكامل مع أسواق النماذج

4. **MCP للحوسبة الطرفية**
   - تكيف معايير MCP للأجهزة الطرفية محدودة الموارد
   - بروتوكولات محسّنة لبيئات النطاق الترددي المنخفض
   - تطبيقات MCP المتخصصة لأنظمة إنترنت الأشياء

5. **الأطر التنظيمية**
   - تطوير امتدادات MCP للامتثال التنظيمي
   - مسارات تدقيق موحدة وواجهات التفسير
   - التكامل مع أطر إدارة الذكاء الاصطناعي الناشئة

### حلول MCP من Microsoft 

طورت Microsoft وAzure عدة مستودعات مفتوحة المصدر لمساعدة المطورين في تنفيذ MCP في سيناريوهات مختلفة:

#### منظمة Microsoft
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - خادم Playwright MCP لأتمتة المتصفح والاختبار
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - تنفيذ خادم OneDrive MCP للاختبار المحلي ومساهمة المجتمع

#### منظمة Azure-Samples
1. [mcp](https://github.com/Azure-Samples/mcp) - روابط لعينات وأدوات وموارد لبناء وتكامل خوادم MCP على Azure باستخدام لغات متعددة
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - خوادم MCP المرجعية التي توضح المصادقة مع مواصفات بروتوكول سياق النموذج الحالية
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - صفحة هبوط لتنفيذات خادم MCP عن بعد في وظائف Azure مع روابط إلى مستودعات خاصة باللغة
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - قالب بدء سريع لبناء ونشر خوادم MCP عن بعد المخصصة باستخدام وظائف Azure مع Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - قالب بدء سريع لبناء ونشر خوادم MCP عن بعد المخصصة باستخدام وظائف Azure مع .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - قالب بدء سريع لبناء ونشر خوادم MCP عن بعد المخصصة باستخدام وظائف Azure مع TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - إدارة API من Azure كبوابة ذكاء اصطناعي لخوادم MCP عن بعد باستخدام Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - تجارب APIM ❤️ AI بما في ذلك قدرات MCP، التكامل مع Azure OpenAI وAI Foundry

توفر هذه المستودعات تنفيذات مختلفة وقوالب وموارد للعمل مع بروتوكول سياق النموذج عبر لغات البرمجة المختلفة وخدمات Azure. تغطي مجموعة واسعة من حالات الاستخدام من تنفيذات الخوادم الأساسية إلى المصادقة والنشر السحابي وسيناريوهات التكامل على مستوى الشركات.

#### دليل موارد MCP

يوفر [دليل موارد MCP](https://github.com/microsoft/mcp/tree/main/Resources) في مستودع Microsoft MCP الرسمي مجموعة مختارة من الموارد النموذجية وقوالب التوجيه وتعريفات الأدوات للاستخدام مع خوادم بروتوكول سياق النموذج. تم تصميم هذا الدليل لمساعدة المطورين على البدء بسرعة مع MCP من خلال توفير كتل بناء قابلة لإعادة الاستخدام وأمثلة لأفضل الممارسات لـ:

- **قوالب التوجيه:** قوالب توجيه جاهزة للاستخدام لمهام وسيناريوهات الذكاء الاصطناعي الشائعة، والتي يمكن تعديلها لتنفيذات خادم MCP الخاصة بك.
- **تعريفات الأدوات:** مخططات وأوصاف أدوات نموذجية لتوحيد تكامل الأدوات واستدعائها عبر خوادم MCP المختلفة.
- **عينات الموارد:** تعريفات موارد نموذجية للاتصال بمصادر البيانات وواجهات برمجة التطبيقات والخدمات الخارجية ضمن إطار MCP.
- **تنفيذات مرجعية:** عينات عملية توضح كيفية هيكلة وتنظيم الموارد والتوجيهات والأدوات في مشاريع MCP في العالم الحقيقي.

تسرع هذه الموارد من عملية التطوير، وتعزز التوحيد القياسي، وتساعد على ضمان أفضل الممارسات عند بناء ونشر حلول تعتمد على MCP.

#### دليل موارد MCP
- [موارد MCP (عينات التوجيه، الأدوات، وتعريفات الموارد)](https://github.com/microsoft/mcp/tree/main/Resources)

### فرص البحث

- تقنيات تحسين التوجيه الفعالة داخل أطر MCP
- نماذج الأمان لنشر MCP متعدد المستأجرين
- قياس الأداء عبر تنفيذات MCP المختلفة
- طرق التحقق الرسمي لخوادم MCP

## الخاتمة

يشكل بروتوكول سياق النموذج (MCP) بسرعة مستقبل التكامل القياسي والآمن والقابل للتشغيل المتبادل للذكاء الاصطناعي عبر الصناعات. من خلال دراسات الحالة والمشاريع العملية في هذا الدرس، رأيت كيف يستفيد المتبنون الأوائل - بما في ذلك Microsoft وAzure - من MCP لحل تحديات العالم الحقيقي، وتسريع اعتماد الذكاء الاصطناعي، وضمان الامتثال والأمان والقابلية للتوسع. يتيح النهج المعياري لـ MCP للمؤسسات ربط نماذج اللغة الكبيرة والأدوات وبيانات الشركات في إطار موحد وقابل للتدقيق. مع استمرار تطور MCP، فإن البقاء على تواصل مع المجتمع، واستكشاف الموارد مفتوحة المصدر، وتطبيق أفضل الممارسات سيكون مفتاحًا لبناء حلول ذكاء اصطناعي قوية ومستعدة للمستقبل.

## موارد إضافية

- [مستودع GitHub لـ MCP (Microsoft)](https://github.com/microsoft/mcp)
- [دليل موارد MCP (عينات التوجيه، الأدوات، وتعريفات الموارد)](https://github.com/microsoft/mcp/tree/main/Resources)
- [مجتمع MCP والوثائق](https://modelcontextprotocol.io/introduction)
- [وثائق Azure MCP](https://aka.ms/azmcp)
- [مستودع GitHub لخادم Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [خادم ملفات MCP (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [عينات Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [خوادم المصادقة MCP (عينات Azure)](https://github.com/Azure-Samples/mcp-auth-servers)
- [وظائف MCP عن بعد (عينات Azure)](https://github.com/Azure-Samples/remote-mcp-functions)
- [وظائف MCP عن بعد باستخدام Python (عينات Azure)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [وظائف MCP عن بعد باستخدام .NET (عينات Azure)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [وظائف MCP عن بعد باستخدام TypeScript (عينات Azure)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)  
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)  
- [حلول مايكروسوفت للذكاء الاصطناعي والأتمتة](https://azure.microsoft.com/en-us/products/ai-services/)  

## التمارين

1. تحليل إحدى دراسات الحالة واقتراح نهج تنفيذ بديل.
2. اختيار إحدى أفكار المشاريع وإنشاء مواصفات تقنية مفصلة.
3. البحث في صناعة غير مغطاة في دراسات الحالة وتوضيح كيف يمكن لـ MCP معالجة تحدياتها الخاصة.
4. استكشاف أحد الاتجاهات المستقبلية وإنشاء مفهوم لامتداد MCP جديد لدعمه.

التالي: [أفضل الممارسات](../08-BestPractices/README.md)

**إخلاء مسؤولية**:  
تمت ترجمة هذه الوثيقة باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار الوثيقة الأصلية بلغتها الأم المصدر الموثوق به. بالنسبة للمعلومات الحاسمة، يُوصى بالترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ينشأ عن استخدام هذه الترجمة.