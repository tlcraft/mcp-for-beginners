<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:10:02+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fa"
}
-->
# درس‌هایی از پذیرندگان اولیه

## مرور کلی

این درس به بررسی نحوه استفاده پذیرندگان اولیه از پروتکل مدل کانتکست (MCP) برای حل چالش‌های دنیای واقعی و پیشبرد نوآوری در صنایع مختلف می‌پردازد. از طریق مطالعات موردی دقیق و پروژه‌های عملی، خواهید دید که چگونه MCP امکان یکپارچه‌سازی استاندارد، امن و مقیاس‌پذیر هوش مصنوعی را فراهم می‌کند—اتصال مدل‌های زبان بزرگ، ابزارها و داده‌های سازمانی در یک چارچوب یکپارچه. شما تجربه عملی در طراحی و ساخت راه‌حل‌های مبتنی بر MCP کسب خواهید کرد، از الگوهای پیاده‌سازی اثبات‌شده می‌آموزید و بهترین روش‌ها برای استقرار MCP در محیط‌های تولید را کشف خواهید کرد. این درس همچنین روندهای نوظهور، جهت‌گیری‌های آینده و منابع متن‌باز را برجسته می‌کند تا به شما کمک کند در صدر فناوری MCP و اکوسیستم در حال تحول آن باقی بمانید.

## اهداف یادگیری

- تحلیل پیاده‌سازی‌های واقعی MCP در صنایع مختلف  
- طراحی و ساخت برنامه‌های کامل مبتنی بر MCP  
- بررسی روندهای نوظهور و جهت‌گیری‌های آینده در فناوری MCP  
- به‌کارگیری بهترین روش‌ها در سناریوهای توسعه واقعی  

## پیاده‌سازی‌های واقعی MCP

### مطالعه موردی ۱: اتوماسیون پشتیبانی مشتری سازمانی

یک شرکت چندملیتی راه‌حلی مبتنی بر MCP پیاده‌سازی کرد تا تعاملات هوش مصنوعی را در سیستم‌های پشتیبانی مشتری خود استاندارد کند. این امکان را برای آن‌ها فراهم کرد تا:

- یک رابط یکپارچه برای چندین ارائه‌دهنده LLM ایجاد کنند  
- مدیریت یکنواخت پرامپت‌ها در بخش‌های مختلف حفظ شود  
- کنترل‌های امنیتی و انطباق قوی پیاده‌سازی شود  
- به‌راحتی بین مدل‌های مختلف هوش مصنوعی بر اساس نیازهای خاص جابجا شوند  

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

**نتایج:** کاهش ۳۰٪ در هزینه‌های مدل، بهبود ۴۵٪ در ثبات پاسخ‌ها و افزایش انطباق در عملیات جهانی.

### مطالعه موردی ۲: دستیار تشخیص پزشکی

یک ارائه‌دهنده خدمات بهداشتی زیرساخت MCP را برای ادغام چندین مدل تخصصی پزشکی هوش مصنوعی توسعه داد، در حالی که اطمینان حاصل می‌کرد داده‌های حساس بیماران محافظت شده باقی بمانند:

- جابجایی بدون درز بین مدل‌های پزشکی عمومی و تخصصی  
- کنترل‌های سختگیرانه حریم خصوصی و ردگیری حسابرسی  
- ادغام با سیستم‌های موجود پرونده الکترونیکی سلامت (EHR)  
- مهندسی پرامپت یکنواخت برای اصطلاحات پزشکی  

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

**نتایج:** بهبود پیشنهادات تشخیصی برای پزشکان همراه با حفظ کامل انطباق HIPAA و کاهش قابل توجه جابجایی بین سیستم‌ها.

### مطالعه موردی ۳: تحلیل ریسک خدمات مالی

یک مؤسسه مالی MCP را برای استانداردسازی فرآیندهای تحلیل ریسک در بخش‌های مختلف پیاده‌سازی کرد:

- ایجاد یک رابط یکپارچه برای مدل‌های ریسک اعتباری، تشخیص تقلب و ریسک سرمایه‌گذاری  
- پیاده‌سازی کنترل‌های دسترسی سختگیرانه و نسخه‌بندی مدل‌ها  
- تضمین قابلیت حسابرسی تمام توصیه‌های هوش مصنوعی  
- حفظ قالب‌بندی داده یکنواخت در سیستم‌های متنوع  

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

**نتایج:** بهبود انطباق مقررات، ۴۰٪ سرعت بیشتر در چرخه‌های استقرار مدل و افزایش ثبات ارزیابی ریسک در بخش‌ها.

### مطالعه موردی ۴: سرور MCP Playwright مایکروسافت برای اتوماسیون مرورگر

مایکروسافت سرور [Playwright MCP](https://github.com/microsoft/playwright-mcp) را برای امکان اتوماسیون مرورگر امن و استاندارد از طریق پروتکل مدل کانتکست توسعه داد. این راه‌حل به عوامل هوش مصنوعی و LLMها اجازه می‌دهد تا به صورت کنترل‌شده، قابل حسابرسی و قابل توسعه با مرورگرهای وب تعامل داشته باشند—امکان استفاده‌هایی مانند تست خودکار وب، استخراج داده و گردش‌کارهای انتها به انتها را فراهم می‌کند.

- ارائه قابلیت‌های اتوماسیون مرورگر (ناوبری، پر کردن فرم، گرفتن اسکرین‌شات و غیره) به عنوان ابزارهای MCP  
- پیاده‌سازی کنترل‌های دسترسی سختگیرانه و محیط ایزوله برای جلوگیری از اقدامات غیرمجاز  
- ارائه گزارش‌های حسابرسی دقیق برای تمام تعاملات مرورگر  
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
- امکان اتوماسیون مرورگر امن و برنامه‌ریزی‌شده برای عوامل هوش مصنوعی و LLMها  
- کاهش تلاش‌های تست دستی و بهبود پوشش تست برنامه‌های وب  
- ارائه چارچوبی قابل استفاده مجدد و توسعه‌پذیر برای ادغام ابزارهای مبتنی بر مرورگر در محیط‌های سازمانی  

**مراجع:**  
- [مخزن GitHub سرور Playwright MCP](https://github.com/microsoft/playwright-mcp)  
- [راه‌حل‌های هوش مصنوعی و اتوماسیون مایکروسافت](https://azure.microsoft.com/en-us/products/ai-services/)

### مطالعه موردی ۵: Azure MCP – پروتکل مدل کانتکست سازمانی به عنوان سرویس

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) پیاده‌سازی مدیریت‌شده و سازمانی پروتکل مدل کانتکست توسط مایکروسافت است که برای ارائه قابلیت‌های سرور MCP مقیاس‌پذیر، امن و منطبق به عنوان یک سرویس ابری طراحی شده است. Azure MCP به سازمان‌ها امکان می‌دهد سرورهای MCP را به سرعت مستقر، مدیریت و با خدمات Azure AI، داده و امنیت ادغام کنند، که باعث کاهش بار عملیاتی و تسریع پذیرش هوش مصنوعی می‌شود.

- میزبانی کامل مدیریت‌شده سرور MCP با مقیاس‌بندی، نظارت و امنیت داخلی  
- ادغام بومی با Azure OpenAI، Azure AI Search و سایر خدمات Azure  
- احراز هویت و مجوز سازمانی از طریق Microsoft Entra ID  
- پشتیبانی از ابزارهای سفارشی، قالب‌های پرامپت و اتصال‌دهنده‌های منابع  
- انطباق با الزامات امنیتی و مقررات سازمانی  

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
- کاهش زمان رسیدن به ارزش برای پروژه‌های هوش مصنوعی سازمانی با ارائه پلتفرم سرور MCP آماده و منطبق  
- ساده‌سازی ادغام LLMها، ابزارها و منابع داده سازمانی  
- افزایش امنیت، قابلیت مشاهده و کارایی عملیاتی برای بارهای کاری MCP  

**مراجع:**  
- [مستندات Azure MCP](https://aka.ms/azmcp)  
- [خدمات هوش مصنوعی Azure](https://azure.microsoft.com/en-us/products/ai-services/)

## مطالعه موردی ۶: NLWeb  
MCP (پروتکل مدل کانتکست) پروتکلی نوظهور برای چت‌بات‌ها و دستیاران هوش مصنوعی است تا با ابزارها تعامل داشته باشند. هر نمونه NLWeb نیز یک سرور MCP است که از یک متد اصلی به نام ask پشتیبانی می‌کند، که برای پرسیدن سوال به یک وب‌سایت به زبان طبیعی استفاده می‌شود. پاسخ بازگشتی از schema.org بهره می‌برد، یک واژگان پرکاربرد برای توصیف داده‌های وب. به طور کلی، MCP همان نقش NLWeb است که Http برای HTML دارد. NLWeb پروتکل‌ها، فرمت‌های Schema.org و کد نمونه را ترکیب می‌کند تا به سایت‌ها کمک کند به سرعت این نقاط انتهایی را ایجاد کنند، که هم برای انسان‌ها از طریق رابط‌های مکالمه‌ای و هم برای ماشین‌ها از طریق تعامل طبیعی عامل به عامل مفید است.

دو بخش متمایز در NLWeb وجود دارد:  
- یک پروتکل بسیار ساده برای شروع، برای ارتباط با سایت به زبان طبیعی و فرمت پاسخ که از json و schema.org استفاده می‌کند. برای جزئیات بیشتر مستندات REST API را ببینید.  
- پیاده‌سازی ساده‌ای از (1) که از نشانه‌گذاری موجود بهره می‌برد، برای سایت‌هایی که می‌توان آن‌ها را به عنوان فهرستی از آیتم‌ها (محصولات، دستور غذا، جاذبه‌ها، نقدها و غیره) انتزاع کرد. همراه با مجموعه‌ای از ویجت‌های رابط کاربری، سایت‌ها می‌توانند به راحتی رابط‌های مکالمه‌ای برای محتوای خود فراهم کنند. برای جزئیات بیشتر مستندات Life of a chat query را ببینید.  

**مراجع:**  
- [مستندات Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### مطالعه موردی ۷: MCP برای Foundry – ادغام عوامل Azure AI

سرورهای MCP Azure AI Foundry نشان می‌دهند چگونه MCP می‌تواند برای هماهنگی و مدیریت عوامل هوش مصنوعی و گردش‌کارها در محیط‌های سازمانی استفاده شود. با ادغام MCP با Azure AI Foundry، سازمان‌ها می‌توانند تعاملات عوامل را استاندارد کنند، از مدیریت گردش‌کار Foundry بهره ببرند و استقرارهای امن و مقیاس‌پذیر را تضمین کنند. این رویکرد امکان نمونه‌سازی سریع، نظارت قوی و ادغام بی‌وقفه با خدمات Azure AI را فراهم می‌کند و از سناریوهای پیشرفته‌ای مانند مدیریت دانش و ارزیابی عامل پشتیبانی می‌کند. توسعه‌دهندگان از یک رابط یکپارچه برای ساخت، استقرار و نظارت بر خطوط لوله عوامل بهره‌مند می‌شوند، در حالی که تیم‌های فناوری اطلاعات امنیت، انطباق و کارایی عملیاتی بهبود یافته‌ای کسب می‌کنند. این راه‌حل برای سازمان‌هایی که به دنبال تسریع پذیرش هوش مصنوعی و حفظ کنترل بر فرآیندهای پیچیده مبتنی بر عامل هستند، ایده‌آل است.

**مراجع:**  
- [مخزن GitHub MCP Foundry](https://github.com/azure-ai-foundry/mcp-foundry)  
- [ادغام عوامل Azure AI با MCP (وبلاگ Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### مطالعه موردی ۸: زمین بازی MCP Foundry – آزمایش و نمونه‌سازی

زمین بازی MCP Foundry محیطی آماده برای آزمایش سرورهای MCP و ادغام‌های Azure AI Foundry فراهم می‌کند. توسعه‌دهندگان می‌توانند به سرعت مدل‌های هوش مصنوعی و گردش‌کارهای عامل را نمونه‌سازی، تست و ارزیابی کنند با استفاده از منابع کاتالوگ و آزمایشگاه‌های Azure AI Foundry. این زمین بازی راه‌اندازی را ساده می‌کند، پروژه‌های نمونه ارائه می‌دهد و از توسعه مشارکتی پشتیبانی می‌کند، که کاوش بهترین روش‌ها و سناریوهای جدید را با کمترین سربار ممکن می‌سازد. این محیط به ویژه برای تیم‌هایی مفید است که می‌خواهند ایده‌ها را اعتبارسنجی کنند، آزمایش‌ها را به اشتراک بگذارند و یادگیری را تسریع کنند بدون نیاز به زیرساخت پیچیده. با کاهش موانع ورود، زمین بازی به ترویج نوآوری و مشارکت جامعه در اکوسیستم MCP و Azure AI Foundry کمک می‌کند.

**مراجع:**  
- [مخزن GitHub زمین بازی MCP Foundry](https://github.com/azure-ai-foundry/foundry-mcp-playground)

### مطالعه موردی ۹: سرور MCP مستندات مایکروسافت – یادگیری و مهارت‌آموزی  
سرور MCP مستندات مایکروسافت، سرور پروتکل مدل کانتکست را پیاده‌سازی می‌کند که به دستیاران هوش مصنوعی دسترسی بلادرنگ به مستندات رسمی مایکروسافت می‌دهد. جستجوی معنایی در مستندات فنی رسمی مایکروسافت انجام می‌دهد.

**مراجع:**  
- [سرور MCP مستندات Microsoft Learn](https://github.com/MicrosoftDocs/mcp)

## پروژه‌های عملی

### پروژه ۱: ساخت سرور MCP چند ارائه‌دهنده

**هدف:** ایجاد سرور MCP که بتواند درخواست‌ها را بر اساس معیارهای مشخص به چندین ارائه‌دهنده مدل هوش مصنوعی هدایت کند.

**نیازمندی‌ها:**  
- پشتیبانی از حداقل سه ارائه‌دهنده مدل مختلف (مثلاً OpenAI، Anthropic، مدل‌های محلی)  
- پیاده‌سازی مکانیزم مسیریابی بر اساس متادیتای درخواست  
- ایجاد سیستم پیکربندی برای مدیریت اعتبارنامه‌های ارائه‌دهندگان  
- افزودن کش برای بهینه‌سازی عملکرد و هزینه‌ها  
- ساخت داشبورد ساده برای نظارت بر استفاده  

**مراحل پیاده‌سازی:**  
1. راه‌اندازی زیرساخت پایه سرور MCP  
2. پیاده‌سازی آداپتورهای ارائه‌دهنده برای هر سرویس مدل هوش مصنوعی  
3. ایجاد منطق مسیریابی بر اساس ویژگی‌های درخواست  
4. افزودن مکانیزم‌های کش برای درخواست‌های پرتکرار  
5. توسعه داشبورد نظارتی  
6. تست با الگوهای مختلف درخواست  

**فناوری‌ها:** انتخاب از بین Python (.NET/Java/Python بر اساس ترجیح شما)، Redis برای کش و یک فریم‌ورک وب ساده برای داشبورد.

### پروژه ۲: سیستم مدیریت پرامپت سازمانی

**هدف:** توسعه سیستمی مبتنی بر MCP برای مدیریت، نسخه‌بندی و استقرار قالب‌های پرامپت در سراسر سازمان.

**نیازمندی‌ها:**  
- ایجاد مخزن مرکزی برای قالب‌های پرامپت  
- پیاده‌سازی نسخه‌بندی و گردش‌کارهای تأیید  
- ساخت قابلیت‌های تست قالب با ورودی‌های نمونه  
- توسعه کنترل‌های دسترسی مبتنی بر نقش  
- ایجاد API برای بازیابی و استقرار قالب‌ها  

**مراحل پیاده‌سازی:**  
1. طراحی اسکیمای پایگاه داده برای ذخیره قالب‌ها  
2. ایجاد API اصلی برای عملیات CRUD قالب‌ها  
3. پیاده‌سازی سیستم نسخه‌بندی  
4. ساخت گردش‌کار تأیید  
5. توسعه چارچوب تست  
6. ایجاد رابط وب ساده برای مدیریت  
7. ادغام با سرور MCP  

**فناوری‌ها:** انتخاب فریم‌ورک بک‌اند، پایگاه داده SQL یا NoSQL و فریم‌ورک فرانت‌اند برای رابط مدیریت.

### پروژه ۳: پلتفرم تولید محتوا مبتنی بر MCP

**هدف:** ساخت پلتفرمی برای تولید محتوا که از MCP برای ارائه نتایج یکنواخت در انواع مختلف محتوا استفاده کند.

**نیازمندی‌ها:**  
- پشتیبانی از فرمت‌های مختلف محتوا (مقالات وبلاگ، شبکه‌های اجتماعی، متن‌های بازاریابی)  
- پیاده‌سازی تولید مبتنی بر قالب با گزینه‌های سفارشی‌سازی  
- ایجاد سیستم بازبینی و بازخورد محتوا  
- ردیابی معیارهای عملکرد محتوا  
- پشتیبانی از نسخه‌بندی و تکرار محتوا  

**مراحل پیاده‌سازی:**  
1. راه‌اندازی زیرساخت کلاینت MCP  
2. ایجاد قالب‌ها برای انواع مختلف محتوا  
3. ساخت خط تولید محتوا  
4. پیاده‌سازی سیستم بازبینی  
5. توسعه سیستم ردیابی معیارها  
6. ایجاد رابط کاربری برای مدیریت قالب‌ها و تولید محتوا  

**فناوری‌ها:** زبان برنامه‌نویسی، فریم‌ورک وب و سیستم پایگاه داده مورد علاقه شما.

## جهت‌گیری‌های آینده فناوری MCP

### روندهای نوظهور

1. **MCP چندرسانه‌ای**  
   - گسترش MCP برای استانداردسازی تعامل با مدل‌های تصویر، صدا و ویدئو  
   - توسعه قابلیت‌های استدلال میان‌رسانه‌ای  
   - فرمت‌های پرامپت استاندارد برای مدالیته‌های مختلف  

2. **زیرساخت MCP فدرال**  
   - شبکه‌های توزیع‌شده MCP که می‌توانند منابع را بین سازمان‌ها به اشتراک بگذارند  
   - پروتکل‌های استاندارد برای اشتراک‌گذاری امن مدل‌ها  
   - تکنیک‌های محاسبات حفظ حریم خصوصی  

3. **بازارهای MCP**  
   - اکوسیستم‌هایی برای به اشتراک‌گذاری و کسب درآمد از قالب‌ها و افزونه‌های MCP  
   - فرآیندهای تضمین کیفیت و صدور گواهی  
   - ادغام با بازارهای مدل  

4. **MCP برای محاسبات لبه**  
   - تطبیق استانداردهای MCP برای دستگاه‌های لبه با منابع محدود  
   - پروتکل‌های بهینه‌شده برای محیط‌های با پهنای باند کم  
   - پیاده‌سازی‌های تخصصی MCP برای اکوسیستم‌های IoT  

5. **چارچوب‌های نظارتی**  
   - توسعه افزونه‌های MCP برای انطباق با مقررات  
   - ردگیری حسابرسی استاندارد و رابط‌های توضیح‌پذیری  
   - ادغام با چارچوب‌های حاکمیت هوش مصنوعی نوظهور  

### راه‌حل‌های MCP از مایکروسافت

مایکروسافت و Azure چندین مخزن متن‌باز توسعه داده‌اند تا به توسعه‌دهندگان در پیاده‌سازی MCP در سناریوهای مختلف کمک کنند:

#### سازمان Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - سرور Playwright MCP برای اتوماسیون و تست مرورگر  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - پیاده‌سازی سرور MCP برای OneDrive جهت تست محلی و مشارکت جامعه  
3. [NLWeb](https://github.com/microsoft/NlWeb) - مجموعه‌ای از پروتکل‌های باز و ابزارهای متن‌باز مرتبط، با تمرکز بر ایجاد لایه پایه برای وب هوش مصنوعی  

#### سازمان Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - لینک به نمونه‌ها، ابزارها و منابع برای ساخت
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - صفحه اصلی پیاده‌سازی‌های Remote MCP Server در Azure Functions با لینک به مخازن مخصوص هر زبان  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - قالب شروع سریع برای ساخت و استقرار سرورهای سفارشی remote MCP با استفاده از Azure Functions و زبان Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - قالب شروع سریع برای ساخت و استقرار سرورهای سفارشی remote MCP با استفاده از Azure Functions و .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - قالب شروع سریع برای ساخت و استقرار سرورهای سفارشی remote MCP با استفاده از Azure Functions و TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - مدیریت API در Azure به عنوان دروازه AI برای سرورهای Remote MCP با استفاده از Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - آزمایش‌های APIM ❤️ AI شامل قابلیت‌های MCP، یکپارچه‌سازی با Azure OpenAI و AI Foundry  

این مخازن پیاده‌سازی‌ها، قالب‌ها و منابع متنوعی را برای کار با پروتکل مدل کانتکست (Model Context Protocol) در زبان‌های برنامه‌نویسی مختلف و سرویس‌های Azure ارائه می‌دهند. آن‌ها طیف گسترده‌ای از موارد استفاده را از پیاده‌سازی‌های پایه سرور تا احراز هویت، استقرار ابری و سناریوهای یکپارچه‌سازی سازمانی پوشش می‌دهند.

#### دایرکتوری منابع MCP

دایرکتوری [MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) در مخزن رسمی Microsoft MCP مجموعه‌ای منتخب از نمونه منابع، قالب‌های پرامپت و تعاریف ابزار برای استفاده با سرورهای Model Context Protocol را فراهم می‌کند. این دایرکتوری به توسعه‌دهندگان کمک می‌کند تا سریع‌تر با MCP شروع کنند و بلوک‌های ساختمانی قابل استفاده مجدد و نمونه‌های بهترین شیوه را ارائه می‌دهد برای:

- **قالب‌های پرامپت:** قالب‌های آماده برای وظایف و سناریوهای رایج هوش مصنوعی که می‌توان آن‌ها را برای پیاده‌سازی‌های سرور MCP خودتان تطبیق داد.  
- **تعاریف ابزار:** نمونه‌هایی از اسکیمای ابزار و متادیتا برای استانداردسازی یکپارچه‌سازی و فراخوانی ابزارها در سرورهای مختلف MCP.  
- **نمونه‌های منابع:** تعاریف نمونه منابع برای اتصال به منابع داده، APIها و سرویس‌های خارجی در چارچوب MCP.  
- **پیاده‌سازی‌های مرجع:** نمونه‌های عملی که نشان می‌دهند چگونه منابع، پرامپت‌ها و ابزارها را در پروژه‌های واقعی MCP ساختاربندی و سازماندهی کنیم.  

این منابع توسعه را تسریع می‌کنند، استانداردسازی را ترویج می‌دهند و به تضمین بهترین شیوه‌ها هنگام ساخت و استقرار راه‌حل‌های مبتنی بر MCP کمک می‌کنند.

#### دایرکتوری منابع MCP  
- [MCP Resources (نمونه پرامپت‌ها، ابزارها و تعاریف منابع)](https://github.com/microsoft/mcp/tree/main/Resources)

### فرصت‌های پژوهشی

- تکنیک‌های بهینه‌سازی پرامپت کارآمد در چارچوب‌های MCP  
- مدل‌های امنیتی برای استقرارهای چند مستاجری MCP  
- ارزیابی عملکرد در پیاده‌سازی‌های مختلف MCP  
- روش‌های تأیید رسمی برای سرورهای MCP  

## نتیجه‌گیری

پروتکل مدل کانتکست (MCP) به سرعت آینده یکپارچه‌سازی هوش مصنوعی استاندارد، امن و قابل همکاری در صنایع مختلف را شکل می‌دهد. از طریق مطالعات موردی و پروژه‌های عملی در این درس، مشاهده کردید که پیشگامان اولیه—از جمله مایکروسافت و Azure—چگونه از MCP برای حل چالش‌های دنیای واقعی، تسریع پذیرش هوش مصنوعی و تضمین انطباق، امنیت و مقیاس‌پذیری استفاده می‌کنند. رویکرد مدولار MCP به سازمان‌ها امکان می‌دهد مدل‌های زبانی بزرگ، ابزارها و داده‌های سازمانی را در چارچوبی یکپارچه و قابل حسابرسی متصل کنند. با ادامه تکامل MCP، مشارکت در جامعه، کاوش منابع متن‌باز و به‌کارگیری بهترین شیوه‌ها کلید ساخت راه‌حل‌های هوش مصنوعی مقاوم و آماده آینده خواهد بود.

## منابع اضافی

- [مخزن GitHub MCP Foundry](https://github.com/azure-ai-foundry/mcp-foundry)  
- [محیط آزمایشی Foundry MCP](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [یکپارچه‌سازی عوامل Azure AI با MCP (وبلاگ Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
- [مخزن GitHub MCP (مایکروسافت)](https://github.com/microsoft/mcp)  
- [دایرکتوری منابع MCP (نمونه پرامپت‌ها، ابزارها و تعاریف منابع)](https://github.com/microsoft/mcp/tree/main/Resources)  
- [جامعه و مستندات MCP](https://modelcontextprotocol.io/introduction)  
- [مستندات Azure MCP](https://aka.ms/azmcp)  
- [مخزن GitHub سرور Playwright MCP](https://github.com/microsoft/playwright-mcp)  
- [سرور Files MCP (OneDrive)](https://github.com/microsoft/files-mcp-server)  
- [نمونه‌های Azure MCP](https://github.com/Azure-Samples/mcp)  
- [سرورهای احراز هویت MCP (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)  
- [توابع Remote MCP (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)  
- [توابع Remote MCP Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)  
- [توابع Remote MCP .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)  
- [توابع Remote MCP TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)  
- [توابع Remote MCP APIM Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)  
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)  
- [راه‌حل‌های هوش مصنوعی و اتوماسیون مایکروسافت](https://azure.microsoft.com/en-us/products/ai-services/)

## تمرین‌ها

1. یکی از مطالعات موردی را تحلیل کنید و رویکرد پیاده‌سازی جایگزینی پیشنهاد دهید.  
2. یکی از ایده‌های پروژه را انتخاب کرده و مشخصات فنی دقیقی تهیه کنید.  
3. صنعتی که در مطالعات موردی پوشش داده نشده را بررسی کنید و شرح دهید چگونه MCP می‌تواند چالش‌های خاص آن را حل کند.  
4. یکی از جهت‌گیری‌های آینده را کاوش کرده و مفهومی برای توسعه جدید MCP جهت پشتیبانی از آن ایجاد کنید.

بعدی: [بهترین شیوه‌ها](../08-BestPractices/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.