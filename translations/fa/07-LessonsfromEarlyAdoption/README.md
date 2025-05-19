<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T21:31:10+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "fa"
}
-->
# درس‌هایی از پذیرندگان اولیه

## مرور کلی

این درس به بررسی نحوه استفاده پذیرندگان اولیه از پروتکل مدل کانتکست (MCP) برای حل چالش‌های دنیای واقعی و پیشبرد نوآوری در صنایع مختلف می‌پردازد. از طریق مطالعات موردی دقیق و پروژه‌های عملی، خواهید دید که چگونه MCP امکان ادغام استاندارد، امن و مقیاس‌پذیر هوش مصنوعی را فراهم می‌کند—با اتصال مدل‌های زبان بزرگ، ابزارها و داده‌های سازمانی در یک چارچوب یکپارچه. شما تجربه عملی طراحی و ساخت راه‌حل‌های مبتنی بر MCP را کسب خواهید کرد، از الگوهای پیاده‌سازی اثبات شده خواهید آموخت و بهترین روش‌ها برای استقرار MCP در محیط‌های تولید را کشف خواهید کرد. این درس همچنین روندهای نوظهور، مسیرهای آینده و منابع متن‌باز را برای کمک به شما در پیشرو ماندن در فناوری MCP و اکوسیستم در حال تحول آن برجسته می‌کند.

## اهداف یادگیری

- تحلیل پیاده‌سازی‌های واقعی MCP در صنایع مختلف  
- طراحی و ساخت برنامه‌های کامل مبتنی بر MCP  
- بررسی روندهای نوظهور و مسیرهای آینده در فناوری MCP  
- به‌کارگیری بهترین روش‌ها در سناریوهای توسعه عملی  

## پیاده‌سازی‌های واقعی MCP

### مطالعه موردی ۱: اتوماسیون پشتیبانی مشتری سازمانی

یک شرکت چندملیتی راه‌حلی مبتنی بر MCP پیاده‌سازی کرد تا تعاملات هوش مصنوعی را در سیستم‌های پشتیبانی مشتری خود استاندارد کند. این امکان را به آن‌ها داد تا:

- یک رابط یکپارچه برای چندین ارائه‌دهنده LLM ایجاد کنند  
- مدیریت یکنواخت پرامپت‌ها در بخش‌های مختلف حفظ شود  
- کنترل‌های امنیتی و انطباق قوی اجرا شود  
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

### مطالعه موردی ۲: دستیار تشخیص سلامت

یک ارائه‌دهنده خدمات سلامت زیرساخت MCP را برای ادغام چندین مدل تخصصی پزشکی هوش مصنوعی توسعه داد در حالی که اطمینان حاصل می‌کرد داده‌های حساس بیماران محافظت شده باقی بمانند:

- جابجایی بی‌وقفه بین مدل‌های پزشکی عمومی و تخصصی  
- کنترل‌های حریم خصوصی سخت‌گیرانه و ردگیری‌های حسابرسی  
- ادغام با سیستم‌های پرونده الکترونیکی سلامت (EHR) موجود  
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

**نتایج:** بهبود پیشنهادات تشخیصی برای پزشکان با حفظ کامل انطباق HIPAA و کاهش قابل توجه جابجایی کانتکست بین سیستم‌ها.

### مطالعه موردی ۳: تحلیل ریسک خدمات مالی

یک موسسه مالی MCP را برای استانداردسازی فرایندهای تحلیل ریسک در بخش‌های مختلف پیاده‌سازی کرد:

- ایجاد یک رابط یکپارچه برای مدل‌های ریسک اعتباری، تشخیص تقلب و ریسک سرمایه‌گذاری  
- اعمال کنترل‌های دسترسی سخت‌گیرانه و نسخه‌بندی مدل‌ها  
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

**نتایج:** بهبود انطباق مقررات، ۴۰٪ تسریع در چرخه‌های استقرار مدل و افزایش ثبات ارزیابی ریسک در بخش‌ها.

### مطالعه موردی ۴: سرور MCP مایکروسافت Playwright برای اتوماسیون مرورگر

مایکروسافت سرور [Playwright MCP](https://github.com/microsoft/playwright-mcp) را برای امکان اتوماسیون مرورگر امن و استاندارد از طریق پروتکل مدل کانتکست توسعه داد. این راه‌حل به عوامل هوش مصنوعی و LLMها اجازه می‌دهد تا به شکلی کنترل‌شده، قابل حسابرسی و قابل توسعه با مرورگرهای وب تعامل داشته باشند—و موارد استفاده‌ای مانند تست خودکار وب، استخراج داده و جریان‌های کاری انتها به انتها را ممکن می‌سازد.

- قابلیت‌های اتوماسیون مرورگر (ناوبری، پر کردن فرم، گرفتن اسکرین‌شات و غیره) را به عنوان ابزارهای MCP ارائه می‌دهد  
- کنترل‌های دسترسی سخت‌گیرانه و جداسازی محیط برای جلوگیری از اقدامات غیرمجاز پیاده‌سازی می‌کند  
- گزارش‌های حسابرسی دقیق برای تمام تعاملات مرورگر فراهم می‌کند  
- از ادغام با Azure OpenAI و دیگر ارائه‌دهندگان LLM برای اتوماسیون مبتنی بر عامل پشتیبانی می‌کند  

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
- اتوماسیون مرورگر برنامه‌ریزی‌شده، امن برای عوامل هوش مصنوعی و LLMها فعال شد  
- تلاش تست دستی کاهش یافت و پوشش تست برنامه‌های وب بهبود یافت  
- چارچوبی قابل استفاده مجدد و قابل توسعه برای ادغام ابزارهای مبتنی بر مرورگر در محیط‌های سازمانی فراهم شد  

**مراجع:**  
- [مخزن GitHub سرور Playwright MCP](https://github.com/microsoft/playwright-mcp)  
- [راه‌حل‌های هوش مصنوعی و اتوماسیون مایکروسافت](https://azure.microsoft.com/en-us/products/ai-services/)

### مطالعه موردی ۵: Azure MCP – پروتکل مدل کانتکست سازمانی به عنوان سرویس

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) پیاده‌سازی سازمانی مدیریت شده مایکروسافت از پروتکل مدل کانتکست است که برای ارائه قابلیت‌های سرور MCP مقیاس‌پذیر، امن و منطبق به عنوان سرویس ابری طراحی شده است. Azure MCP به سازمان‌ها امکان می‌دهد به سرعت سرورهای MCP را با سرویس‌های هوش مصنوعی، داده و امنیت Azure مستقر، مدیریت و ادغام کنند و بار عملیاتی را کاهش داده و پذیرش هوش مصنوعی را تسریع بخشند.

- میزبانی کامل سرور MCP با مقیاس‌بندی، نظارت و امنیت داخلی  
- ادغام بومی با Azure OpenAI، Azure AI Search و سایر خدمات Azure  
- احراز هویت و مجوز سازمانی از طریق Microsoft Entra ID  
- پشتیبانی از ابزارهای سفارشی، قالب‌های پرامپت و کانکتورهای منابع  
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
- کاهش زمان رسیدن به ارزش پروژه‌های هوش مصنوعی سازمانی با ارائه پلتفرم سرور MCP آماده و منطبق  
- ساده‌سازی ادغام LLMها، ابزارها و منابع داده سازمانی  
- افزایش امنیت، قابلیت مشاهده و بهره‌وری عملیاتی در بارهای کاری MCP  

**مراجع:**  
- [مستندات Azure MCP](https://aka.ms/azmcp)  
- [خدمات هوش مصنوعی Azure](https://azure.microsoft.com/en-us/products/ai-services/)

## مطالعه موردی ۶: NLWeb  
MCP (پروتکل مدل کانتکست) پروتکلی نوظهور برای چت‌بات‌ها و دستیاران هوش مصنوعی است تا با ابزارها تعامل داشته باشند. هر نمونه NLWeb همچنین یک سرور MCP است که از یک متد اصلی به نام ask پشتیبانی می‌کند که برای پرسیدن سوال به یک وب‌سایت به زبان طبیعی استفاده می‌شود. پاسخ بازگشتی از schema.org استفاده می‌کند، یک واژگان پرکاربرد برای توصیف داده‌های وب. به طور کلی، MCP همان نقش NLWeb را برای HTTP و HTML ایفا می‌کند. NLWeb پروتکل‌ها، فرمت‌های Schema.org و نمونه کد را ترکیب می‌کند تا به سایت‌ها کمک کند به سرعت این نقاط پایانی را ایجاد کنند، که هم برای انسان‌ها از طریق رابط‌های مکالمه‌ای و هم برای ماشین‌ها از طریق تعامل طبیعی عامل به عامل مفید است.

NLWeb شامل دو جزء متمایز است:  
- یک پروتکل بسیار ساده برای شروع، برای ارتباط با سایت به زبان طبیعی و فرمت پاسخ که از json و schema.org بهره می‌برد. برای جزئیات بیشتر مستندات REST API را ببینید.  
- پیاده‌سازی ساده‌ای از (1) که از نشانه‌گذاری موجود استفاده می‌کند، برای سایت‌هایی که می‌توانند به عنوان فهرستی از آیتم‌ها (محصولات، دستور غذا، جاذبه‌ها، نقدها و غیره) انتزاع شوند. همراه با مجموعه‌ای از ویجت‌های رابط کاربری، سایت‌ها می‌توانند به راحتی رابط‌های مکالمه‌ای برای محتوای خود فراهم کنند. برای جزئیات بیشتر مستندات Life of a chat query را ببینید.

**مراجع:**  
- [مستندات Azure MCP](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## پروژه‌های عملی

### پروژه ۱: ساخت سرور MCP چند ارائه‌دهنده

**هدف:** ایجاد یک سرور MCP که بتواند درخواست‌ها را بر اساس معیارهای خاص به چندین ارائه‌دهنده مدل هوش مصنوعی مسیریابی کند.

**نیازمندی‌ها:**  
- پشتیبانی حداقل از سه ارائه‌دهنده مدل مختلف (مثلاً OpenAI، Anthropic، مدل‌های محلی)  
- پیاده‌سازی مکانیزم مسیریابی بر اساس متادیتای درخواست  
- ایجاد سیستم پیکربندی برای مدیریت اطلاعات اعتبار ارائه‌دهندگان  
- افزودن کش برای بهینه‌سازی عملکرد و هزینه‌ها  
- ساخت داشبورد ساده برای نظارت بر استفاده  

**مراحل پیاده‌سازی:**  
1. راه‌اندازی زیرساخت پایه سرور MCP  
2. پیاده‌سازی آداپتورهای ارائه‌دهنده برای هر سرویس مدل هوش مصنوعی  
3. ایجاد منطق مسیریابی بر اساس ویژگی‌های درخواست  
4. افزودن مکانیزم‌های کش برای درخواست‌های مکرر  
5. توسعه داشبورد نظارتی  
6. تست با الگوهای مختلف درخواست  

**فناوری‌ها:** انتخاب از میان Python (.NET/Java/Python بر اساس ترجیح شما)، Redis برای کش و یک فریم‌ورک وب ساده برای داشبورد.

### پروژه ۲: سیستم مدیریت پرامپت سازمانی

**هدف:** توسعه سیستمی مبتنی بر MCP برای مدیریت، نسخه‌بندی و استقرار قالب‌های پرامپت در سراسر سازمان.

**نیازمندی‌ها:**  
- ایجاد مخزن متمرکز برای قالب‌های پرامپت  
- پیاده‌سازی نسخه‌بندی و گردش کار تایید  
- ساخت قابلیت‌های تست قالب با ورودی‌های نمونه  
- توسعه کنترل‌های دسترسی مبتنی بر نقش  
- ایجاد API برای بازیابی و استقرار قالب‌ها  

**مراحل پیاده‌سازی:**  
1. طراحی ساختار پایگاه داده برای ذخیره قالب‌ها  
2. ایجاد API اصلی برای عملیات CRUD قالب‌ها  
3. پیاده‌سازی سیستم نسخه‌بندی  
4. ساخت گردش کار تایید  
5. توسعه چارچوب تست  
6. ایجاد رابط وب ساده برای مدیریت  
7. ادغام با سرور MCP  

**فناوری‌ها:** انتخاب شما از فریم‌ورک بک‌اند، پایگاه داده SQL یا NoSQL و فریم‌ورک فرانت‌اند برای رابط مدیریت.

### پروژه ۳: پلتفرم تولید محتوا مبتنی بر MCP

**هدف:** ساخت پلتفرمی برای تولید محتوا که از MCP بهره می‌برد تا نتایج یکنواخت در انواع مختلف محتوا ارائه دهد.

**نیازمندی‌ها:**  
- پشتیبانی از فرمت‌های مختلف محتوا (مقالات وبلاگ، شبکه‌های اجتماعی، متن‌های بازاریابی)  
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

**فناوری‌ها:** زبان برنامه‌نویسی، فریم‌ورک وب و سیستم پایگاه داده مورد علاقه شما.

## مسیرهای آینده فناوری MCP

### روندهای نوظهور

1. **MCP چندرسانه‌ای**  
   - گسترش MCP برای استانداردسازی تعامل با مدل‌های تصویر، صدا و ویدئو  
   - توسعه قابلیت‌های استدلال چندرسانه‌ای  
   - قالب‌های پرامپت استاندارد برای مدیوم‌های مختلف  

2. **زیرساخت MCP فدراسیون‌شده**  
   - شبکه‌های توزیع‌شده MCP که می‌توانند منابع را بین سازمان‌ها به اشتراک بگذارند  
   - پروتکل‌های استاندارد برای اشتراک‌گذاری امن مدل‌ها  
   - تکنیک‌های محاسبات حفظ حریم خصوصی  

3. **بازارهای MCP**  
   - اکوسیستم‌هایی برای اشتراک‌گذاری و کسب درآمد از قالب‌ها و افزونه‌های MCP  
   - فرآیندهای تضمین کیفیت و صدور گواهینامه  
   - ادغام با بازارهای مدل  

4. **MCP برای محاسبات لبه‌ای**  
   - تطبیق استانداردهای MCP برای دستگاه‌های لبه‌ای با منابع محدود  
   - پروتکل‌های بهینه‌شده برای محیط‌های با پهنای باند کم  
   - پیاده‌سازی‌های تخصصی MCP برای اکوسیستم‌های IoT  

5. **چارچوب‌های نظارتی**  
   - توسعه افزونه‌های MCP برای انطباق با مقررات  
   - ردگیری‌های حسابرسی استاندارد و رابط‌های توضیح‌پذیری  
   - ادغام با چارچوب‌های حاکمیت هوش مصنوعی نوظهور  

### راه‌حل‌های MCP از مایکروسافت

مایکروسافت و Azure چندین مخزن متن‌باز برای کمک به توسعه‌دهندگان در پیاده‌سازی MCP در سناریوهای مختلف توسعه داده‌اند:

#### سازمان Microsoft  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - سرور Playwright MCP برای اتوماسیون و تست مرورگر  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - پیاده‌سازی سرور MCP وان‌درایو برای تست محلی و مشارکت جامعه  
3. [NLWeb](https://github.com/microsoft/NlWeb) - مجموعه‌ای از پروتکل‌های باز و ابزارهای متن‌باز مرتبط با وب هوشمند  

#### سازمان Azure-Samples  
1. [mcp](https://github.com/Azure-Samples/mcp) - لینک به نمونه‌ها، ابزارها و منابع برای ساخت و ادغام سرورهای MCP در Azure با زبان‌های مختلف  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - نمونه‌های سرور MCP با احراز هویت بر اساس مشخصات فعلی پروتکل مدل کانتکست  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - صفحه فرود برای پیاده‌سازی‌های سرور MCP از راه دور در Azure Functions با لینک به مخازن زبان‌های مختلف  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - قالب شروع سریع برای ساخت و استقرار سرورهای MCP از راه دور سفارشی با Azure Functions و Python  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - قالب شروع سریع برای ساخت و استقرار سرورهای MCP از راه دور سفارشی با Azure Functions و .NET/C#  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - قالب شروع سریع برای ساخت و استقرار سرورهای MCP از راه دور سفارشی با Azure Functions و TypeScript  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - مدیریت API Azure به عنوان دروازه هوش مصنوعی به سرورهای MCP از راه دور با استفاده از Python  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - آزمایش‌های APIM ❤️ AI شامل قابلیت‌های MCP، ادغام با Azure OpenAI و AI Foundry  

این مخازن پیاده‌سازی‌ها، قالب‌ها و منابع مختلفی برای کار با پروتکل مدل کانتکست در زبان‌های برنامه‌نویسی و خدمات Azure فراهم می‌کنند. آن‌ها طیف وسیعی از کاربردها از پیاده‌سازی‌های پایه سرور تا احراز هویت، استقرار ابری و ادغام سازمانی را پوشش می‌دهند.

#### دایرکتوری منابع MCP

دایرکتوری [MCP Resources](https://github.com/microsoft/mcp/tree/main/Resources) در مخزن رسمی MCP مایکروسافت مجموعه‌ای منتخب از منابع نمونه، قالب‌های پرامپت و تعاریف ابزار برای استفاده با سرورهای پروتکل مدل کانتکست را ارائه می‌دهد. این دایرکتوری به توسعه‌دهندگان کمک می‌کند تا به سرعت با MCP شروع به کار کنند و بلوک‌های ساختاری قابل استفاده مجدد و مثال‌های بهترین شیوه را برای:

- **قالب‌های پرامپت:** قالب‌های آماده برای وظایف و سناریوهای رایج هوش مصنوعی که می‌توان آن‌ها را برای پیاده‌سازی‌های سرور MCP خود تطبیق داد  
- **تعاریف ابزار:** نمونه‌های اسکیمای ابزار و متادیتا برای استانداردسازی ادغام و فراخوانی ابزار در سرورهای MCP مختلف  
- **نمونه‌های منابع:** تعاریف نمونه منابع برای اتصال به منابع داده، APIها و خدمات خارجی در چارچوب MCP  
- **پیاده‌سازی‌های مرجع:** نمونه‌های عملی که نحوه ساختاردهی و سازماندهی منابع، پرامپت‌ها و ابزارها را در پروژه‌های واقعی MCP نشان می‌دهند  

این منابع
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## تمرین‌ها

1. یکی از مطالعات موردی را تحلیل کنید و یک رویکرد پیاده‌سازی جایگزین پیشنهاد دهید.
2. یکی از ایده‌های پروژه را انتخاب کرده و مشخصات فنی دقیقی تهیه کنید.
3. صنعتی که در مطالعات موردی پوشش داده نشده است را بررسی کنید و شرح دهید چگونه MCP می‌تواند چالش‌های خاص آن را حل کند.
4. یکی از مسیرهای آینده را کاوش کرده و مفهومی برای توسعه جدید MCP جهت پشتیبانی از آن ایجاد کنید.

بعدی: [Best Practices](../08-BestPractices/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا برداشت نادرستی که از استفاده از این ترجمه ناشی شود، نیستیم.