<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:02:54+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fa"
}
-->
# درس‌هایی از پذیرندگان اولیه

## مرور کلی

این درس بررسی می‌کند که چگونه پذیرندگان اولیه از پروتکل مدل کانتکست (MCP) برای حل چالش‌های دنیای واقعی و پیشبرد نوآوری در صنایع مختلف استفاده کرده‌اند. از طریق مطالعات موردی دقیق و پروژه‌های عملی، خواهید دید که چگونه MCP یکپارچه‌سازی استاندارد، امن و مقیاس‌پذیر هوش مصنوعی را امکان‌پذیر می‌سازد—اتصال مدل‌های زبان بزرگ، ابزارها و داده‌های سازمانی در یک چارچوب یکپارچه. تجربه عملی در طراحی و ساخت راه‌حل‌های مبتنی بر MCP کسب خواهید کرد، از الگوهای پیاده‌سازی اثبات‌شده یاد خواهید گرفت و بهترین شیوه‌ها برای استقرار MCP در محیط‌های تولیدی را کشف خواهید کرد. این درس همچنین به روندهای نوظهور، مسیرهای آینده و منابع متن‌باز اشاره می‌کند تا به شما کمک کند در خط مقدم فناوری MCP و اکوسیستم در حال تکامل آن بمانید.

## اهداف یادگیری

- تجزیه و تحلیل پیاده‌سازی‌های واقعی MCP در صنایع مختلف
- طراحی و ساخت برنامه‌های کامل مبتنی بر MCP
- بررسی روندهای نوظهور و مسیرهای آینده در فناوری MCP
- اعمال بهترین شیوه‌ها در سناریوهای توسعه واقعی

## پیاده‌سازی‌های واقعی MCP

### مطالعه موردی ۱: اتوماسیون پشتیبانی مشتری سازمانی

یک شرکت چندملیتی یک راه‌حل مبتنی بر MCP را برای استانداردسازی تعاملات هوش مصنوعی در سیستم‌های پشتیبانی مشتری خود پیاده‌سازی کرد. این امر به آنها اجازه داد تا:

- یک رابط یکپارچه برای چندین ارائه‌دهنده LLM ایجاد کنند
- مدیریت پیوسته پیام‌ها را در بخش‌ها حفظ کنند
- کنترل‌های امنیتی و انطباق قوی پیاده‌سازی کنند
- به راحتی بین مدل‌های مختلف هوش مصنوعی بر اساس نیازهای خاص جابجا شوند

**پیاده‌سازی فنی:**
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

**نتایج:** ۳۰٪ کاهش در هزینه‌های مدل، ۴۵٪ بهبود در پیوستگی پاسخ‌ها و افزایش انطباق در عملیات جهانی.

### مطالعه موردی ۲: دستیار تشخیص پزشکی

یک ارائه‌دهنده خدمات بهداشتی زیرساخت MCP را برای ادغام مدل‌های هوش مصنوعی پزشکی تخصصی متعدد توسعه داد در حالی که اطمینان از محافظت از داده‌های حساس بیمار:

- جابجایی بی‌وقفه بین مدل‌های پزشکی عمومی و تخصصی
- کنترل‌های سختگیرانه حریم خصوصی و مسیرهای حسابرسی
- ادغام با سیستم‌های موجود رکورد سلامت الکترونیکی (EHR)
- مهندسی پیوسته پیام‌ها برای اصطلاحات پزشکی

**پیاده‌سازی فنی:**
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

**نتایج:** بهبود پیشنهادات تشخیصی برای پزشکان در حالی که انطباق کامل با HIPAA را حفظ کرده و کاهش چشمگیر در جابجایی بین سیستم‌ها.

### مطالعه موردی ۳: تحلیل ریسک خدمات مالی

یک موسسه مالی MCP را برای استانداردسازی فرآیندهای تحلیل ریسک خود در بخش‌های مختلف پیاده‌سازی کرد:

- ایجاد یک رابط یکپارچه برای مدل‌های ریسک اعتباری، تشخیص تقلب و سرمایه‌گذاری
- پیاده‌سازی کنترل‌های دسترسی سختگیرانه و نسخه‌بندی مدل
- اطمینان از حسابرسی تمامی توصیه‌های هوش مصنوعی
- حفظ فرمت داده پیوسته در سیستم‌های متنوع

**پیاده‌سازی فنی:**
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

**نتایج:** افزایش انطباق قانونی، ۴۰٪ چرخه‌های استقرار مدل سریع‌تر و بهبود پیوستگی ارزیابی ریسک در بخش‌ها.

### مطالعه موردی ۴: سرور MCP Microsoft Playwright برای اتوماسیون مرورگر

مایکروسافت سرور [Playwright MCP](https://github.com/microsoft/playwright-mcp) را برای امکان‌پذیر ساختن اتوماسیون مرورگر امن و استاندارد از طریق پروتکل مدل کانتکست توسعه داد. این راه‌حل به عوامل هوش مصنوعی و LLMها اجازه می‌دهد تا به صورت کنترل‌شده، قابل حسابرسی و قابل گسترش با مرورگرهای وب تعامل داشته باشند—موارد استفاده مانند تست وب خودکار، استخراج داده و گردش کار پایان به پایان را امکان‌پذیر می‌سازد.

- قابلیت‌های اتوماسیون مرورگر (ناوبری، پر کردن فرم، گرفتن اسکرین‌شات و غیره) را به عنوان ابزارهای MCP ارائه می‌دهد
- کنترل‌های دسترسی سختگیرانه و محیط‌های محدودسازی برای جلوگیری از اقدامات غیرمجاز را پیاده‌سازی می‌کند
- گزارش‌های حسابرسی دقیق برای تمامی تعاملات مرورگر ارائه می‌دهد
- پشتیبانی از ادغام با Azure OpenAI و سایر ارائه‌دهندگان LLM برای اتوماسیون مبتنی بر عامل

**پیاده‌سازی فنی:**
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

**نتایج:**  
- امکان‌پذیر ساختن اتوماسیون مرورگر امن و برنامه‌نویسی برای عوامل هوش مصنوعی و LLMها
- کاهش تلاش‌های تست دستی و بهبود پوشش تست برای برنامه‌های وب
- ارائه یک چارچوب قابل استفاده مجدد و قابل گسترش برای ادغام ابزار مبتنی بر مرورگر در محیط‌های سازمانی

**مراجع:**  
- [مخزن GitHub سرور Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [راه‌حل‌های هوش مصنوعی و اتوماسیون مایکروسافت](https://azure.microsoft.com/en-us/products/ai-services/)

### مطالعه موردی ۵: Azure MCP – پروتکل مدل کانتکست در سطح سازمانی به عنوان یک سرویس

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) پیاده‌سازی مدیریت‌شده و در سطح سازمانی پروتکل مدل کانتکست مایکروسافت است که برای ارائه قابلیت‌های سرور MCP مقیاس‌پذیر، امن و منطبق به عنوان یک سرویس ابری طراحی شده است. Azure MCP به سازمان‌ها اجازه می‌دهد تا به سرعت سرورهای MCP را با خدمات Azure AI، داده و امنیت ادغام کنند، هزینه‌های عملیاتی را کاهش داده و پذیرش هوش مصنوعی را تسریع کنند.

- میزبانی سرور MCP کاملاً مدیریت‌شده با مقیاس‌پذیری، نظارت و امنیت داخلی
- ادغام بومی با Azure OpenAI، Azure AI Search و سایر خدمات Azure
- احراز هویت و مجوز سازمانی از طریق Microsoft Entra ID
- پشتیبانی از ابزارهای سفارشی، قالب‌های پیام و اتصالات منابع
- انطباق با الزامات امنیتی و قانونی سازمانی

**پیاده‌سازی فنی:**
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

**نتایج:**  
- کاهش زمان ارزش‌گذاری برای پروژه‌های هوش مصنوعی سازمانی با ارائه یک پلتفرم سرور MCP آماده استفاده و منطبق
- ساده‌سازی ادغام LLMها، ابزارها و منابع داده سازمانی
- افزایش امنیت، قابلیت مشاهده و کارایی عملیاتی برای بارهای کاری MCP

**مراجع:**  
- [مستندات Azure MCP](https://aka.ms/azmcp)
- [خدمات هوش مصنوعی Azure](https://azure.microsoft.com/en-us/products/ai-services/)

## پروژه‌های عملی

### پروژه ۱: ساخت یک سرور MCP چند ارائه‌دهنده

**هدف:** ایجاد یک سرور MCP که بتواند درخواست‌ها را بر اساس معیارهای خاص به چندین ارائه‌دهنده مدل هوش مصنوعی مسیریابی کند.

**نیازمندی‌ها:**
- پشتیبانی از حداقل سه ارائه‌دهنده مدل مختلف (مثلاً OpenAI، Anthropic، مدل‌های محلی)
- پیاده‌سازی یک مکانیزم مسیریابی بر اساس متادیتای درخواست
- ایجاد یک سیستم پیکربندی برای مدیریت اعتبارنامه‌های ارائه‌دهنده
- افزودن حافظه نهان برای بهینه‌سازی عملکرد و هزینه‌ها
- ساخت یک داشبورد ساده برای نظارت بر استفاده

**مراحل پیاده‌سازی:**
1. تنظیم زیرساخت اصلی سرور MCP
2. پیاده‌سازی آداپتورهای ارائه‌دهنده برای هر سرویس مدل هوش مصنوعی
3. ایجاد منطق مسیریابی بر اساس ویژگی‌های درخواست
4. افزودن مکانیزم‌های حافظه نهان برای درخواست‌های مکرر
5. توسعه داشبورد نظارت
6. تست با الگوهای مختلف درخواست

**فناوری‌ها:** انتخاب از بین Python (.NET/Java/Python بر اساس ترجیح شما)، Redis برای حافظه نهان و یک چارچوب وب ساده برای داشبورد.

### پروژه ۲: سیستم مدیریت پیام سازمانی

**هدف:** توسعه یک سیستم مبتنی بر MCP برای مدیریت، نسخه‌بندی و استقرار قالب‌های پیام در سراسر یک سازمان.

**نیازمندی‌ها:**
- ایجاد یک مخزن مرکزی برای قالب‌های پیام
- پیاده‌سازی سیستم نسخه‌بندی و گردش کار تأیید
- ساخت قابلیت‌های تست قالب با ورودی‌های نمونه
- توسعه کنترل‌های دسترسی مبتنی بر نقش
- ایجاد یک API برای بازیابی و استقرار قالب‌ها

**مراحل پیاده‌سازی:**
1. طراحی شمای پایگاه داده برای ذخیره قالب‌ها
2. ایجاد API اصلی برای عملیات CRUD قالب
3. پیاده‌سازی سیستم نسخه‌بندی
4. ساخت گردش کار تأیید
5. توسعه چارچوب تست
6. ایجاد یک رابط وب ساده برای مدیریت
7. ادغام با سرور MCP

**فناوری‌ها:** انتخاب شما از چارچوب پشتیبان، پایگاه داده SQL یا NoSQL و یک چارچوب جلویی برای رابط مدیریت.

### پروژه ۳: پلتفرم تولید محتوا مبتنی بر MCP

**هدف:** ساخت یک پلتفرم تولید محتوا که از MCP برای ارائه نتایج پیوسته در انواع مختلف محتوا استفاده کند.

**نیازمندی‌ها:**
- پشتیبانی از فرمت‌های محتوای مختلف (پست‌های وبلاگ، رسانه‌های اجتماعی، کپی بازاریابی)
- پیاده‌سازی تولید مبتنی بر قالب با گزینه‌های سفارشی‌سازی
- ایجاد یک سیستم بررسی و بازخورد محتوا
- ردیابی معیارهای عملکرد محتوا
- پشتیبانی از نسخه‌بندی و تکرار محتوا

**مراحل پیاده‌سازی:**
1. تنظیم زیرساخت مشتری MCP
2. ایجاد قالب‌ها برای انواع مختلف محتوا
3. ساخت خط تولید محتوا
4. پیاده‌سازی سیستم بررسی
5. توسعه سیستم ردیابی معیارها
6. ایجاد یک رابط کاربری برای مدیریت قالب و تولید محتوا

**فناوری‌ها:** زبان برنامه‌نویسی مورد نظر شما، چارچوب وب و سیستم پایگاه داده.

## مسیرهای آینده برای فناوری MCP

### روندهای نوظهور

1. **MCP چندوجهی**
   - گسترش MCP برای استانداردسازی تعاملات با مدل‌های تصویر، صوت و ویدئو
   - توسعه قابلیت‌های استدلال متقابل وجهی
   - قالب‌های پیام استاندارد برای وجوه مختلف

2. **زیرساخت MCP فدرال**
   - شبکه‌های توزیع‌شده MCP که می‌توانند منابع را در سازمان‌ها به اشتراک بگذارند
   - پروتکل‌های استاندارد برای اشتراک‌گذاری ایمن مدل
   - تکنیک‌های محاسباتی حفظ حریم خصوصی

3. **بازارهای MCP**
   - اکوسیستم‌ها برای اشتراک‌گذاری و درآمدزایی قالب‌ها و پلاگین‌های MCP
   - فرآیندهای تضمین کیفیت و صدور گواهینامه
   - ادغام با بازارهای مدل

4. **MCP برای محاسبات لبه**
   - تطبیق استانداردهای MCP برای دستگاه‌های لبه با منابع محدود
   - پروتکل‌های بهینه‌سازی‌شده برای محیط‌های کم‌پهنای باند
   - پیاده‌سازی‌های تخصصی MCP برای اکوسیستم‌های IoT

5. **چارچوب‌های قانونی**
   - توسعه افزونه‌های MCP برای انطباق قانونی
   - مسیرهای حسابرسی استاندارد و رابط‌های توضیحی
   - ادغام با چارچوب‌های حاکمیت هوش مصنوعی نوظهور

### راه‌حل‌های MCP از مایکروسافت

مایکروسافت و Azure چندین مخزن متن‌باز برای کمک به توسعه‌دهندگان در پیاده‌سازی MCP در سناریوهای مختلف توسعه داده‌اند:

#### سازمان مایکروسافت
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - سرور Playwright MCP برای اتوماسیون و تست مرورگر
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - پیاده‌سازی سرور MCP OneDrive برای تست محلی و مشارکت جامعه

#### سازمان Azure-Samples
1. [mcp](https://github.com/Azure-Samples/mcp) - لینک به نمونه‌ها، ابزارها و منابع برای ساخت و ادغام سرورهای MCP در Azure با استفاده از زبان‌های مختلف
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - سرورهای مرجع MCP که احراز هویت با مشخصات فعلی پروتکل مدل کانتکست را نشان می‌دهند
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - صفحه فرود برای پیاده‌سازی‌های سرور MCP از راه دور در Azure Functions با لینک به مخازن زبان‌های خاص
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - الگوی شروع سریع برای ساخت و استقرار سرورهای MCP سفارشی از راه دور با استفاده از Azure Functions با Python
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - الگوی شروع سریع برای ساخت و استقرار سرورهای MCP سفارشی از راه دور با استفاده از Azure Functions با .NET/C#
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - الگوی شروع سریع برای ساخت و استقرار سرورهای MCP سفارشی از راه دور با استفاده از Azure Functions با TypeScript
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - مدیریت API Azure به عنوان دروازه هوش مصنوعی به سرورهای MCP از راه دور با استفاده از Python
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - آزمایش‌های APIM ❤️ AI شامل قابلیت‌های MCP، ادغام با Azure OpenAI و AI Foundry

این مخازن پیاده‌سازی‌ها، الگوها و منابع مختلفی برای کار با پروتکل مدل کانتکست در زبان‌های برنامه‌نویسی مختلف و خدمات Azure ارائه می‌دهند. آنها طیف وسیعی از موارد استفاده از پیاده‌سازی‌های سرور پایه تا احراز هویت، استقرار ابری و سناریوهای یکپارچه‌سازی سازمانی را پوشش می‌دهند.

#### دایرکتوری منابع MCP

دایرکتوری [منابع MCP](https://github.com/microsoft/mcp/tree/main/Resources) در مخزن رسمی MCP مایکروسافت مجموعه‌ای از منابع نمونه، قالب‌های پیام و تعاریف ابزار برای استفاده با سرورهای پروتکل مدل کانتکست ارائه می‌دهد. این دایرکتوری برای کمک به توسعه‌دهندگان در شروع سریع با MCP با ارائه بلوک‌های ساختمانی قابل استفاده مجدد و نمونه‌های بهترین شیوه طراحی شده است:

- **قالب‌های پیام:** قالب‌های پیام آماده برای استفاده برای وظایف و سناریوهای معمول هوش مصنوعی که می‌توانند برای پیاده‌سازی‌های سرور MCP خود شما تطبیق داده شوند.
- **تعاریف ابزار:** طرح‌های ابزار نمونه و متادیتا برای استانداردسازی یکپارچه‌سازی و فراخوانی ابزار در سرورهای مختلف MCP.
- **نمونه‌های منابع:** تعاریف منابع نمونه برای اتصال به منابع داده، APIها و خدمات خارجی در چارچوب MCP.
- **پیاده‌سازی‌های مرجع:** نمونه‌های عملی که نشان می‌دهند چگونه منابع، پیام‌ها و ابزارها را در پروژه‌های واقعی MCP ساختاردهی و سازماندهی کنید.

این منابع توسعه را تسریع می‌کنند، استانداردسازی را ترویج می‌دهند و به اطمینان از بهترین شیوه‌ها هنگام ساخت و استقرار راه‌حل‌های مبتنی بر MCP کمک می‌کنند.

#### دایرکتوری منابع MCP
- [منابع MCP (قالب‌های نمونه، ابزارها و تعاریف منابع)](https://github.com/microsoft/mcp/tree/main/Resources)

### فرصت‌های تحقیقاتی

- تکنیک‌های بهینه‌سازی پیام کارآمد در چارچوب‌های MCP
- مدل‌های امنیتی برای استقرار MCP چندمستاجری
- سنجش عملکرد در پیاده‌سازی‌های مختلف MCP
- روش‌های تأیید رسمی برای سرورهای MCP

## نتیجه‌گیری

پروتکل مدل کانتکست (MCP) به سرعت در حال شکل‌دهی به آینده یکپارچه‌سازی هوش مصنوعی استاندارد، امن و قابل تعامل در صنایع مختلف است. از طریق مطالعات موردی و پروژه‌های عملی در این درس، شما دیده‌اید که چگونه پذیرندگان اولیه—از جمله مایکروسافت و Azure—از MCP برای حل چالش‌های دنیای واقعی، تسریع پذیرش هوش مصنوعی و اطمینان از انطباق، امنیت و مقیاس‌پذیری استفاده می‌کنند. رویکرد ماژولار MCP به سازمان‌ها اجازه می‌دهد مدل‌های زبان بزرگ، ابزارها و داده‌های سازمانی را در یک چارچوب یکپارچه و قابل حسابرسی متصل کنند. همان‌طور که MCP به تکامل خود ادامه می‌دهد، درگیر ماندن با جامعه، بررسی منابع متن‌باز و اعمال بهترین شیوه‌ها کلید ساخت راه‌حل‌های هوش مصنوعی قوی و آماده برای آینده خواهد بود.

## منابع اضافی

- [مخزن GitHub MCP (مایکروسافت)](https://github.com/microsoft/mcp)
- [دایرکتوری منابع MCP (قالب‌های نمونه، ابزارها و تعاریف منابع)](https://github.com/microsoft/mcp/tree/main/Resources)
- [جامعه و مستندات MCP](https://modelcontextprotocol.io/introduction)
- [مستندات Azure MCP](https://aka.ms/azmcp)
-
- [توابع Remote MCP APIM Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [راهکارهای هوش مصنوعی و اتوماسیون مایکروسافت](https://azure.microsoft.com/en-us/products/ai-services/)

## تمرین‌ها

1. یکی از مطالعات موردی را تحلیل کنید و یک روش پیاده‌سازی جایگزین پیشنهاد دهید.
2. یکی از ایده‌های پروژه را انتخاب کنید و مشخصات فنی دقیقی ایجاد کنید.
3. یک صنعت که در مطالعات موردی پوشش داده نشده است را تحقیق کنید و مشخص کنید که MCP چگونه می‌تواند به چالش‌های خاص آن رسیدگی کند.
4. یکی از جهت‌های آینده را بررسی کنید و یک مفهوم برای یک افزونه جدید MCP برای پشتیبانی از آن ایجاد کنید.

بعدی: [بهترین روش‌ها](../08-BestPractices/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان مادری باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حساس، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئولیتی در قبال سوء تفاهم‌ها یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.