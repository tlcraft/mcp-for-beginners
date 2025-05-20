<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T20:24:54+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fa"
}
-->
# درس‌هایی از پذیرندگان اولیه

## مروری کلی

این درس بررسی می‌کند که چگونه پذیرندگان اولیه از Model Context Protocol (MCP) برای حل چالش‌های دنیای واقعی و پیشبرد نوآوری در صنایع مختلف استفاده کرده‌اند. از طریق مطالعات موردی دقیق و پروژه‌های عملی، خواهید دید که MCP چگونه امکان یکپارچه‌سازی استاندارد، امن و مقیاس‌پذیر هوش مصنوعی را فراهم می‌کند—اتصال مدل‌های زبانی بزرگ، ابزارها و داده‌های سازمانی در یک چارچوب یکپارچه. شما تجربه عملی طراحی و ساخت راهکارهای مبتنی بر MCP کسب خواهید کرد، از الگوهای پیاده‌سازی اثبات‌شده خواهید آموخت و بهترین روش‌ها برای استقرار MCP در محیط‌های تولیدی را کشف خواهید کرد. این درس همچنین روندهای نوظهور، مسیرهای آینده و منابع متن‌باز را برجسته می‌کند تا به شما کمک کند در خط مقدم فناوری MCP و اکوسیستم در حال تحول آن باقی بمانید.

## اهداف یادگیری

- تحلیل پیاده‌سازی‌های واقعی MCP در صنایع مختلف  
- طراحی و ساخت برنامه‌های کامل مبتنی بر MCP  
- بررسی روندهای نوظهور و مسیرهای آینده در فناوری MCP  
- به‌کارگیری بهترین روش‌ها در سناریوهای توسعه واقعی  

## پیاده‌سازی‌های واقعی MCP

### مطالعه موردی ۱: اتوماسیون پشتیبانی مشتری سازمانی

یک شرکت چندملیتی راهکاری مبتنی بر MCP پیاده‌سازی کرد تا تعاملات هوش مصنوعی در سیستم‌های پشتیبانی مشتری خود را استاندارد کند. این امکان را برای آن‌ها فراهم کرد تا:

- رابط کاربری یکپارچه‌ای برای چندین ارائه‌دهنده LLM ایجاد کنند  
- مدیریت هماهنگ پرامپت‌ها در بخش‌های مختلف را حفظ کنند  
- کنترل‌های امنیتی و انطباق قوی را اجرا کنند  
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

**نتایج:** کاهش ۳۰٪ هزینه‌های مدل، بهبود ۴۵٪ در ثبات پاسخ‌ها و افزایش انطباق در عملیات جهانی.

### مطالعه موردی ۲: دستیار تشخیص پزشکی

یک ارائه‌دهنده خدمات بهداشتی زیرساخت MCP را توسعه داد تا چندین مدل تخصصی هوش مصنوعی پزشکی را یکپارچه کند و در عین حال داده‌های حساس بیماران را محافظت نماید:

- جابجایی بدون درز بین مدل‌های پزشکی عمومی و تخصصی  
- کنترل‌های سختگیرانه حفظ حریم خصوصی و ثبت حسابرسی  
- ادغام با سیستم‌های موجود پرونده الکترونیکی سلامت (EHR)  
- مهندسی پرامپت سازگار برای اصطلاحات پزشکی  

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

**نتایج:** بهبود پیشنهادات تشخیصی برای پزشکان همراه با حفظ کامل انطباق HIPAA و کاهش قابل توجه جابجایی زمینه بین سیستم‌ها.

### مطالعه موردی ۳: تحلیل ریسک خدمات مالی

یک مؤسسه مالی MCP را برای استانداردسازی فرآیندهای تحلیل ریسک در بخش‌های مختلف پیاده‌سازی کرد:

- ایجاد رابط یکپارچه برای مدل‌های ریسک اعتباری، تشخیص تقلب و ریسک سرمایه‌گذاری  
- اجرای کنترل‌های دسترسی سختگیرانه و نسخه‌بندی مدل  
- اطمینان از قابلیت حسابرسی تمام توصیه‌های هوش مصنوعی  
- حفظ قالب‌بندی داده‌ها به‌صورت سازگار در سیستم‌های متنوع  

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

**نتایج:** افزایش انطباق نظارتی، چرخه‌های استقرار مدل ۴۰٪ سریع‌تر و بهبود ثبات ارزیابی ریسک در بخش‌ها.

### مطالعه موردی ۴: سرور Playwright MCP مایکروسافت برای اتوماسیون مرورگر

مایکروسافت سرور [Playwright MCP](https://github.com/microsoft/playwright-mcp) را برای امکان اتوماسیون مرورگر امن و استاندارد از طریق Model Context Protocol توسعه داد. این راهکار به عوامل هوش مصنوعی و LLMها اجازه می‌دهد تا به صورت کنترل‌شده، قابل حسابرسی و توسعه‌پذیر با مرورگرهای وب تعامل داشته باشند—که موارد استفاده‌ای مانند تست خودکار وب، استخراج داده و جریان‌های کاری انتها به انتها را ممکن می‌سازد.

- ارائه قابلیت‌های اتوماسیون مرورگر (ناوبری، پر کردن فرم، عکس‌برداری صفحه و غیره) به‌عنوان ابزارهای MCP  
- اجرای کنترل‌های دسترسی سختگیرانه و جداسازی محیط برای جلوگیری از اقدامات غیرمجاز  
- فراهم کردن گزارش‌های حسابرسی دقیق برای تمام تعاملات مرورگر  
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
- امکان اتوماسیون برنامه‌نویسی مرورگر امن برای عوامل هوش مصنوعی و LLMها  
- کاهش تلاش‌های تست دستی و بهبود پوشش تست برنامه‌های وب  
- ارائه چارچوبی قابل استفاده مجدد و توسعه‌پذیر برای ادغام ابزارهای مبتنی بر مرورگر در محیط‌های سازمانی  

**مراجع:**  
- [مخزن GitHub سرور Playwright MCP](https://github.com/microsoft/playwright-mcp)  
- [راهکارهای هوش مصنوعی و اتوماسیون مایکروسافت](https://azure.microsoft.com/en-us/products/ai-services/)

### مطالعه موردی ۵: Azure MCP – پروتکل مدل کانتکست سازمانی به‌عنوان سرویس

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) پیاده‌سازی سازمانی مدیریت‌شده مایکروسافت از Model Context Protocol است که به‌عنوان یک سرویس ابری، قابلیت‌های سرور MCP مقیاس‌پذیر، امن و منطبق را ارائه می‌دهد. Azure MCP به سازمان‌ها امکان می‌دهد تا به سرعت سرورهای MCP را مستقر، مدیریت و با خدمات هوش مصنوعی، داده و امنیت Azure ادغام کنند و بار عملیاتی را کاهش داده و پذیرش هوش مصنوعی را تسریع نمایند.

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
- کاهش زمان رسیدن به ارزش برای پروژه‌های هوش مصنوعی سازمانی با ارائه پلتفرم سرور MCP آماده استفاده و منطبق  
- ساده‌سازی ادغام مدل‌های زبانی بزرگ، ابزارها و منابع داده سازمانی  
- افزایش امنیت، قابلیت مشاهده و کارایی عملیاتی بارهای کاری MCP  

**مراجع:**  
- [مستندات Azure MCP](https://aka.ms/azmcp)  
- [خدمات هوش مصنوعی Azure](https://azure.microsoft.com/en-us/products/ai-services/)

## مطالعه موردی ۶: NLWeb

MCP (Model Context Protocol) پروتکلی نوظهور برای تعامل چت‌بات‌ها و دستیاران هوش مصنوعی با ابزارها است. هر نمونه NLWeb نیز یک سرور MCP است که از یک متد اصلی به نام ask پشتیبانی می‌کند که برای پرسیدن سوال به یک وب‌سایت به زبان طبیعی استفاده می‌شود. پاسخ برگشتی از schema.org استفاده می‌کند، که یک واژگان پرکاربرد برای توصیف داده‌های وب است. به طور خلاصه، MCP همان‌طور است که NLWeb به Http نسبت به HTML است. NLWeb پروتکل‌ها، قالب‌های Schema.org و نمونه کد را ترکیب می‌کند تا به سایت‌ها کمک کند این نقاط انتهایی را سریع ایجاد کنند و از طریق رابط‌های مکالمه‌ای برای انسان‌ها و تعامل طبیعی عامل به عامل برای ماشین‌ها بهره‌مند شوند.

دو جزء متمایز در NLWeb وجود دارد:  
- یک پروتکل بسیار ساده برای شروع، برای تعامل با سایت به زبان طبیعی و قالبی که با json و schema.org برای پاسخ برگشتی کار می‌کند. برای جزئیات بیشتر به مستندات REST API مراجعه کنید.  
- پیاده‌سازی ساده‌ای از (1) که از نشانه‌گذاری موجود بهره می‌برد، برای سایت‌هایی که می‌توان آن‌ها را به عنوان لیستی از اقلام (محصولات، دستورها، جاذبه‌ها، بررسی‌ها و غیره) انتزاع کرد. همراه با مجموعه‌ای از ویجت‌های رابط کاربری، سایت‌ها می‌توانند به راحتی رابط‌های مکالمه‌ای برای محتوای خود فراهم کنند. برای جزئیات بیشتر به مستندات Life of a chat query مراجعه کنید.  

**مراجع:**  
- [مستندات Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### مطالعه موردی ۷: MCP برای Foundry – ادغام عوامل هوش مصنوعی Azure

سرورهای Azure AI Foundry MCP نشان می‌دهند که چگونه می‌توان از MCP برای هماهنگی و مدیریت عوامل هوش مصنوعی و جریان‌های کاری در محیط‌های سازمانی استفاده کرد. با ادغام MCP با Azure AI Foundry، سازمان‌ها می‌توانند تعاملات عوامل را استاندارد کنند، از مدیریت جریان کاری Foundry بهره ببرند و استقرارهای امن و مقیاس‌پذیر را تضمین کنند. این رویکرد امکان نمونه‌سازی سریع، نظارت قوی و ادغام بدون درز با خدمات هوش مصنوعی Azure را فراهم می‌آورد و از سناریوهای پیشرفته مانند مدیریت دانش و ارزیابی عامل پشتیبانی می‌کند. توسعه‌دهندگان از یک رابط یکپارچه برای ساخت، استقرار و نظارت بر خطوط لوله عامل‌ها بهره‌مند می‌شوند، در حالی که تیم‌های فناوری اطلاعات امنیت، انطباق و کارایی عملیاتی بهبود یافته‌ای دریافت می‌کنند. این راهکار برای سازمان‌هایی که به دنبال تسریع پذیرش هوش مصنوعی و حفظ کنترل بر فرآیندهای پیچیده مبتنی بر عامل هستند، ایده‌آل است.

**مراجع:**  
- [مخزن GitHub MCP Foundry](https://github.com/azure-ai-foundry/mcp-foundry)  
- [ادغام عوامل هوش مصنوعی Azure با MCP (وبلاگ Microsoft Foundry)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### مطالعه موردی ۸: زمین بازی Foundry MCP – آزمایش و نمونه‌سازی

زمین بازی Foundry MCP محیطی آماده برای آزمایش سرورهای MCP و ادغام‌های Azure AI Foundry فراهم می‌کند. توسعه‌دهندگان می‌توانند به سرعت مدل‌های هوش مصنوعی و جریان‌های کاری عامل را نمونه‌سازی، تست و ارزیابی کنند با استفاده از منابع کاتالوگ و آزمایشگاه‌های Azure AI Foundry. این زمین بازی راه‌اندازی را ساده می‌کند، پروژه‌های نمونه ارائه می‌دهد و توسعه مشارکتی را پشتیبانی می‌کند، که کاوش بهترین روش‌ها و سناریوهای جدید را با کمترین سربار ممکن می‌سازد. این محیط به ویژه برای تیم‌هایی که به دنبال اعتبارسنجی ایده‌ها، اشتراک آزمایش‌ها و تسریع یادگیری بدون نیاز به زیرساخت‌های پیچیده هستند، مفید است. با کاهش موانع ورود، زمین بازی به نوآوری و مشارکت جامعه در اکوسیستم MCP و Azure AI Foundry کمک می‌کند.

**مراجع:**  
- [مخزن GitHub زمین بازی Foundry MCP](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## پروژه‌های عملی

### پروژه ۱: ساخت سرور MCP چند ارائه‌دهنده

**هدف:** ایجاد سرور MCP که بتواند درخواست‌ها را بر اساس معیارهای مشخص به چندین ارائه‌دهنده مدل هوش مصنوعی مسیریابی کند.

**نیازمندی‌ها:**  
- پشتیبانی از حداقل سه ارائه‌دهنده مدل مختلف (مثلاً OpenAI، Anthropic، مدل‌های محلی)  
- پیاده‌سازی مکانیزم مسیریابی بر اساس متادیتای درخواست  
- ایجاد سیستم پیکربندی برای مدیریت اعتبارنامه‌های ارائه‌دهنده‌ها  
- افزودن کش برای بهینه‌سازی عملکرد و هزینه‌ها  
- ساخت داشبورد ساده برای نظارت بر استفاده  

**مراحل پیاده‌سازی:**  
1. راه‌اندازی زیرساخت پایه سرور MCP  
2. پیاده‌سازی آداپتورهای ارائه‌دهنده برای هر سرویس مدل هوش مصنوعی  
3. ایجاد منطق مسیریابی بر اساس ویژگی‌های درخواست  
4. افزودن مکانیزم‌های کش برای درخواست‌های مکرر  
5. توسعه داشبورد نظارت  
6. تست با الگوهای مختلف درخواست  

**فناوری‌ها:** انتخاب از بین Python (.NET/Java/Python بر اساس ترجیح شما)، Redis برای کش و چارچوب وب ساده برای داشبورد.

### پروژه ۲: سیستم مدیریت پرامپت سازمانی

**هدف:** توسعه سیستمی مبتنی بر MCP برای مدیریت، نسخه‌بندی و استقرار قالب‌های پرامپت در سراسر سازمان.

**نیازمندی‌ها:**  
- ایجاد مخزن مرکزی برای قالب‌های پرامپت  
- پیاده‌سازی سیستم نسخه‌بندی و جریان‌های کاری تایید  
- ساخت قابلیت‌های تست قالب با ورودی‌های نمونه  
- توسعه کنترل‌های دسترسی مبتنی بر نقش  
- ایجاد API برای بازیابی و استقرار قالب‌ها  

**مراحل پیاده‌سازی:**  
1. طراحی طرح‌واره پایگاه داده برای ذخیره قالب‌ها  
2. ایجاد API اصلی برای عملیات CRUD قالب‌ها  
3. پیاده‌سازی سیستم نسخه‌بندی  
4. ساخت جریان کاری تایید  
5. توسعه چارچوب تست  
6. ایجاد رابط وب ساده برای مدیریت  
7. ادغام با سرور MCP  

**فناوری‌ها:** انتخاب چارچوب بک‌اند، پایگاه داده SQL یا NoSQL و چارچوب فرانت‌اند برای رابط مدیریت.

### پروژه ۳: پلتفرم تولید محتوا مبتنی بر MCP

**هدف:** ساخت پلتفرمی برای تولید محتوا که با استفاده از MCP نتایج یکپارچه‌ای در انواع مختلف محتوا ارائه دهد.

**نیازمندی‌ها:**  
- پشتیبانی از فرمت‌های محتوای مختلف (مقالات وبلاگ، شبکه‌های اجتماعی، کپی بازاریابی)  
- پیاده‌سازی تولید مبتنی بر قالب با گزینه‌های سفارشی‌سازی  
- ایجاد سیستم بازبینی و بازخورد محتوا  
- ردیابی معیارهای عملکرد محتوا  
- پشتیبانی از نسخه‌بندی و تکرار محتوا  

**مراحل پیاده‌سازی:**  
1. راه‌اندازی زیرساخت کلاینت MCP  
2. ایجاد قالب‌ها برای انواع مختلف محتوا  
3. ساخت خط تولید تولید محتوا  
4. پیاده‌سازی سیستم بازبینی  
5. توسعه سیستم ردیابی معیارها  
6. ایجاد رابط کاربری برای مدیریت قالب‌ها و تولید محتوا  

**فناوری‌ها:** زبان برنامه‌نویسی، چارچوب وب و سیستم پایگاه داده مورد علاقه شما.

## مسیرهای آینده فناوری MCP

### روندهای نوظهور

1. **MCP چندرسانه‌ای**  
   - گسترش MCP برای استانداردسازی تعاملات با مدل‌های تصویر، صوت و ویدئو  
   - توسعه قابلیت‌های استدلال چندرسانه‌ای  
   - قالب‌های پرامپت استاندارد برای مدالیته‌های مختلف  

2. **زیرساخت MCP فدرال**  
   - شبکه‌های توزیع‌شده MCP که منابع را بین سازمان‌ها به اشتراک می‌گذارند  
   - پروتکل‌های استاندارد برای اشتراک‌گذاری امن مدل‌ها  
   - تکنیک‌های محاسبات حفظ حریم خصوصی  

3. **بازارهای MCP**  
   - اکوسیستم‌هایی برای اشتراک و کسب درآمد از قالب‌ها و افزونه‌های MCP  
   - فرآیندهای تضمین کیفیت و صدور گواهی  
   - ادغام با بازارهای مدل  

4. **MCP برای محاسبات لبه‌ای**  
   - تطبیق استانداردهای MCP برای دستگاه‌های لبه‌ای با منابع محدود  
   - پروتکل‌های بهینه‌شده برای محیط‌های با پهنای باند کم  
   - پیاده‌سازی‌های تخصصی MCP برای اکوسیستم‌های IoT  

5. **چارچوب‌های مقرراتی**  
   - توسعه افزونه‌های MCP برای انطباق با مقررات  
   - مسیرهای حسابرسی استاندارد و رابط‌های قابلیت توضیح  
   - ادغام با چارچوب‌های حاکمیتی نوظهور هوش مصنوعی  

### راهکارهای MCP از مایکروسافت

مایکروسافت و Azure چندین مخزن متن‌باز برای کمک به توسعه‌دهندگان در پیاده‌سازی MCP در سناریوهای مختلف توسعه داده‌اند:

#### سازمان Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - سرور Playwright MCP برای اتوماسیون و تست مرورگر  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - پیاده‌سازی سرور MCP برای OneDrive جهت تست محلی و مشارکت جامعه  
3. [NLWeb](https://github.com/microsoft/NlWeb) - مجموعه‌ای از پروتکل‌های باز و ابزارهای متن‌باز مرتبط، تمرکز اصلی آن ایجاد لایه پایه برای وب هوش مصنوعی است  

#### سازمان Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - لینک به نمونه‌ها، ابزارها و منابع برای ساخت و ادغام سرورهای MCP روی Azure با زبان‌های مختلف  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - سرورهای مرجع MCP که احراز هویت را با مشخصات فعلی Model Context Protocol نشان می‌دهند  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - صفحه فرود برای پیاده‌سازی‌های سرور MCP از راه دور در Azure Functions با لینک به مخازن زبانی  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - قالب شروع سریع برای ساخت و استقرار سرورهای MCP از راه دور سفارشی با Azure Functions و Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dot
- [مستندات Azure MCP](https://aka.ms/azmcp)
- [مخزن GitHub سرور Playwright MCP](https://github.com/microsoft/playwright-mcp)
- [سرور Files MCP (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [سرورهای احراز هویت MCP (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [توابع Remote MCP (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [توابع Remote MCP پایتون (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [توابع Remote MCP دات‌نت (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [توابع Remote MCP تایپ‌اسکریپت (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [توابع Remote MCP APIM پایتون (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [راهکارهای هوش مصنوعی و اتوماسیون مایکروسافت](https://azure.microsoft.com/en-us/products/ai-services/)

## تمرین‌ها

1. یکی از مطالعات موردی را تحلیل کرده و یک رویکرد جایگزین برای پیاده‌سازی پیشنهاد دهید.
2. یکی از ایده‌های پروژه را انتخاب کرده و مشخصات فنی دقیقی تهیه کنید.
3. صنعتی که در مطالعات موردی پوشش داده نشده را بررسی کنید و شرح دهید چگونه MCP می‌تواند چالش‌های خاص آن را برطرف کند.
4. یکی از جهت‌گیری‌های آینده را بررسی کرده و مفهومی برای توسعه جدید MCP جهت پشتیبانی از آن ایجاد کنید.

بعدی: [بهترین شیوه‌ها](../08-BestPractices/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، توصیه می‌شود از ترجمه حرفه‌ای انسانی استفاده شود. ما در قبال هرگونه سوء تفاهم یا تفسیر نادرست ناشی از استفاده از این ترجمه مسئولیتی نداریم.