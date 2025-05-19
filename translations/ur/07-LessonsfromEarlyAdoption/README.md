<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T21:33:16+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ur"
}
-->
# ابتدائی اپنانے والوں سے سبق

## جائزہ

یہ سبق اس بات کا جائزہ لیتا ہے کہ ابتدائی اپنانے والوں نے Model Context Protocol (MCP) کو کس طرح استعمال کیا ہے تاکہ حقیقی دنیا کے مسائل کو حل کیا جا سکے اور صنعتوں میں جدت کو فروغ دیا جا سکے۔ تفصیلی کیس اسٹڈیز اور عملی منصوبوں کے ذریعے، آپ دیکھیں گے کہ MCP کس طرح معیاری، محفوظ، اور قابل توسیع AI انضمام کو ممکن بناتا ہے—جو بڑے زبان کے ماڈلز، ٹولز، اور ادارہ جاتی ڈیٹا کو ایک متحد فریم ورک میں جوڑتا ہے۔ آپ MCP پر مبنی حل ڈیزائن اور تعمیر کرنے کا عملی تجربہ حاصل کریں گے، ثابت شدہ نفاذی نمونوں سے سیکھیں گے، اور MCP کو پروڈکشن ماحول میں تعینات کرنے کے بہترین طریقے دریافت کریں گے۔ سبق ابھرتے ہوئے رجحانات، مستقبل کی سمتوں، اور اوپن سورس وسائل کو بھی اجاگر کرتا ہے تاکہ آپ MCP ٹیکنالوجی اور اس کے بدلتے ہوئے ماحولیاتی نظام میں سب سے آگے رہ سکیں۔

## سیکھنے کے مقاصد

- مختلف صنعتوں میں حقیقی دنیا کی MCP نفاذات کا تجزیہ کریں  
- مکمل MCP پر مبنی ایپلیکیشنز ڈیزائن اور تعمیر کریں  
- MCP ٹیکنالوجی میں ابھرتے ہوئے رجحانات اور مستقبل کی سمتوں کو دریافت کریں  
- عملی ترقی کے مناظر میں بہترین طریقے اپنائیں  

## حقیقی دنیا کی MCP نفاذات

### کیس اسٹڈی 1: ادارہ جاتی کسٹمر سپورٹ آٹومیشن

ایک کثیر القومی کمپنی نے MCP پر مبنی حل نافذ کیا تاکہ اپنے کسٹمر سپورٹ سسٹمز میں AI تعاملات کو معیاری بنایا جا سکے۔ اس سے وہ درج ذیل کام کر سکے:

- متعدد LLM فراہم کنندگان کے لیے ایک متحد انٹرفیس تخلیق کیا  
- مختلف محکموں میں یکساں پرامپٹ مینجمنٹ برقرار رکھی  
- مضبوط سیکیورٹی اور تعمیل کنٹرول نافذ کیے  
- مخصوص ضروریات کی بنیاد پر مختلف AI ماڈلز کے درمیان آسانی سے سوئچ کیا  

**Technical Implementation:**  
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

**نتائج:** ماڈل کی لاگت میں 30% کمی، ردعمل کی یکسانیت میں 45% بہتری، اور عالمی آپریشنز میں بہتر تعمیل۔

### کیس اسٹڈی 2: صحت کی دیکھ بھال کے تشخیصی معاون

ایک صحت کی دیکھ بھال فراہم کرنے والے نے MCP انفراسٹرکچر تیار کیا تاکہ متعدد مخصوص طبی AI ماڈلز کو مربوط کیا جا سکے جبکہ حساس مریض کے ڈیٹا کی حفاظت کو یقینی بنایا گیا:

- جنرل اور ماہر طبی ماڈلز کے درمیان بغیر رکاوٹ سوئچنگ  
- سخت پرائیویسی کنٹرولز اور آڈٹ ٹریلز  
- موجودہ الیکٹرانک ہیلتھ ریکارڈ (EHR) سسٹمز کے ساتھ انضمام  
- طبی اصطلاحات کے لیے یکساں پرامپٹ انجینئرنگ  

**Technical Implementation:**  
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

**نتائج:** ڈاکٹروں کے لیے تشخیصی تجاویز میں بہتری، مکمل HIPAA تعمیل کے ساتھ، اور سسٹمز کے درمیان کانٹیکسٹ سوئچنگ میں نمایاں کمی۔

### کیس اسٹڈی 3: مالی خدمات میں رسک تجزیہ

ایک مالیاتی ادارے نے MCP نافذ کیا تاکہ اپنے مختلف محکموں میں رسک تجزیہ کے عمل کو معیاری بنایا جا سکے:

- کریڈٹ رسک، فراڈ ڈیٹیکشن، اور سرمایہ کاری کے رسک ماڈلز کے لیے متحد انٹرفیس تخلیق کیا  
- سخت رسائی کنٹرولز اور ماڈل ورژننگ نافذ کی  
- تمام AI سفارشات کی آڈٹ ایبلٹی کو یقینی بنایا  
- مختلف سسٹمز میں یکساں ڈیٹا فارمیٹنگ برقرار رکھی  

**Technical Implementation:**  
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

**نتائج:** بہتر ریگولیٹری تعمیل، ماڈل تعیناتی کے چکر میں 40% تیزی، اور محکموں میں رسک اسیسمنٹ کی یکسانیت میں بہتری۔

### کیس اسٹڈی 4: Microsoft Playwright MCP سرور براؤزر آٹومیشن کے لیے

Microsoft نے [Playwright MCP server](https://github.com/microsoft/playwright-mcp) تیار کیا تاکہ Model Context Protocol کے ذریعے محفوظ، معیاری براؤزر آٹومیشن کو ممکن بنایا جا سکے۔ یہ حل AI ایجنٹس اور LLMs کو کنٹرولڈ، آڈیٹیبل، اور قابل توسیع انداز میں ویب براؤزرز کے ساتھ تعامل کی اجازت دیتا ہے—جیسے خودکار ویب ٹیسٹنگ، ڈیٹا استخراج، اور اینڈ ٹو اینڈ ورک فلو۔

- براؤزر آٹومیشن صلاحیتوں (نیویگیشن، فارم فلنگ، اسکرین شاٹ کیپچر وغیرہ) کو MCP ٹولز کے طور پر پیش کرتا ہے  
- غیر مجاز کارروائیوں کو روکنے کے لیے سخت رسائی کنٹرولز اور سینڈباکسنگ نافذ کرتا ہے  
- تمام براؤزر تعاملات کے لیے تفصیلی آڈٹ لاگز فراہم کرتا ہے  
- Azure OpenAI اور دیگر LLM فراہم کنندگان کے ساتھ ایجنٹ ڈرائیون آٹومیشن کے لیے انضمام کی حمایت کرتا ہے  

**Technical Implementation:**  
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

**نتائج:**  
- AI ایجنٹس اور LLMs کے لیے محفوظ، پروگراماتی براؤزر آٹومیشن کو فعال کیا  
- دستی ٹیسٹنگ کی محنت کم کی اور ویب ایپلیکیشنز کے لیے ٹیسٹ کوریج بہتر کی  
- ادارہ جاتی ماحول میں براؤزر بیسڈ ٹول انضمام کے لیے قابل استعمال، قابل توسیع فریم ورک فراہم کیا  

**References:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### کیس اسٹڈی 5: Azure MCP – انٹرپرائز گریڈ Model Context Protocol بطور سروس

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) Microsoft کا منظم، انٹرپرائز گریڈ نفاذ ہے جو Model Context Protocol کی کلاؤڈ سروس کے طور پر قابل توسیع، محفوظ، اور تعمیلی MCP سرور صلاحیتیں فراہم کرتا ہے۔ Azure MCP تنظیموں کو MCP سرورز کو تیزی سے تعینات، منظم، اور Azure AI، ڈیٹا، اور سیکیورٹی سروسز کے ساتھ مربوط کرنے کی سہولت دیتا ہے، آپریشنل بوجھ کم کرتا ہے اور AI اپنانے کو تیز کرتا ہے۔

- مکمل منظم MCP سرور ہوسٹنگ، جس میں بلٹ ان اسکیلنگ، مانیٹرنگ، اور سیکیورٹی شامل ہے  
- Azure OpenAI، Azure AI Search، اور دیگر Azure سروسز کے ساتھ مقامی انضمام  
- Microsoft Entra ID کے ذریعے انٹرپرائز تصدیق اور اجازت  
- کسٹم ٹولز، پرامپٹ ٹیمپلیٹس، اور ریسورس کنیکٹرز کی حمایت  
- انٹرپرائز سیکیورٹی اور ریگولیٹری تقاضوں کے مطابق  

**Technical Implementation:**  
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

**نتائج:**  
- انٹرپرائز AI پروجیکٹس کے لیے وقت کی بچت، تیار استعمال، تعمیلی MCP سرور پلیٹ فارم فراہم کرکے  
- LLMs، ٹولز، اور ادارہ جاتی ڈیٹا ذرائع کے انضمام کو آسان بنایا  
- MCP ورک لوڈز کے لیے بہتر سیکیورٹی، مشاہدہ، اور آپریشنل کارکردگی  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## کیس اسٹڈی 6: NLWeb

MCP (Model Context Protocol) ایک ابھرتا ہوا پروٹوکول ہے جو چیٹ بوٹس اور AI اسسٹنٹس کو ٹولز کے ساتھ تعامل کرنے کے قابل بناتا ہے۔ ہر NLWeb انسٹینس بھی ایک MCP سرور ہے، جو ایک بنیادی طریقہ کار، ask، کی حمایت کرتا ہے، جو ویب سائٹ سے قدرتی زبان میں سوال کرنے کے لیے استعمال ہوتا ہے۔ واپس ملنے والا جواب schema.org کا استعمال کرتا ہے، جو ویب ڈیٹا کی وضاحت کے لیے وسیع پیمانے پر استعمال ہونے والا لغت ہے۔ آسان الفاظ میں، MCP NLWeb کی طرح ہے جیسا کہ Http HTML کے لیے ہے۔ NLWeb پروٹوکولز، Schema.org فارمیٹس، اور نمونہ کوڈ کو یکجا کرتا ہے تاکہ سائٹس جلدی سے یہ اینڈ پوائنٹس بنا سکیں، جو انسانی گفتگو کے انٹرفیسز اور مشینوں کے درمیان قدرتی ایجنٹ سے ایجنٹ تعامل دونوں کے لیے فائدہ مند ہیں۔

NLWeb کے دو مختلف اجزاء ہیں:  
- ایک پروٹوکول، بہت سادہ، جو قدرتی زبان میں سائٹ کے ساتھ انٹرفیس کے لیے ہے اور ایک فارمیٹ، جو json اور schema.org کو واپس جواب کے لیے استعمال کرتا ہے۔ REST API کی دستاویزات میں مزید تفصیلات دیکھیں۔  
- (1) کا ایک آسان نفاذ جو موجودہ مارک اپ کا استعمال کرتا ہے، ان سائٹس کے لیے جو اشیاء کی فہرستوں (مصنوعات، ترکیبیں، سیاحتی مقامات، جائزے وغیرہ) کی صورت میں خلاصہ کی جا سکتی ہیں۔ صارف انٹرفیس وجیٹس کے ساتھ، سائٹس آسانی سے اپنے مواد کے لیے گفتگو کے انٹرفیس فراہم کر سکتی ہیں۔ Life of a chat query کی دستاویزات میں اس کے کام کرنے کے طریقہ کار کی مزید تفصیل دیکھیں۔  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

## عملی منصوبے

### منصوبہ 1: ملٹی-پرووائیڈر MCP سرور بنائیں

**مقصد:** ایسا MCP سرور بنائیں جو مخصوص معیار کی بنیاد پر متعدد AI ماڈل فراہم کنندگان کو درخواستیں بھیج سکے۔

**ضروریات:**  
- کم از کم تین مختلف ماڈل فراہم کنندگان کی حمایت (مثلاً OpenAI، Anthropic، لوکل ماڈلز)  
- درخواست میٹا ڈیٹا کی بنیاد پر روٹنگ میکنزم نافذ کریں  
- فراہم کنندہ کے اسناد کے انتظام کے لیے کنفیگریشن سسٹم بنائیں  
- کارکردگی اور لاگت کو بہتر بنانے کے لیے کیشنگ شامل کریں  
- استعمال کی نگرانی کے لیے ایک سادہ ڈیش بورڈ تیار کریں  

**نفاذی مراحل:**  
1. بنیادی MCP سرور انفراسٹرکچر قائم کریں  
2. ہر AI ماڈل سروس کے لیے فراہم کنندہ اڈاپٹرز نافذ کریں  
3. درخواست کی خصوصیات کی بنیاد پر روٹنگ لاجک بنائیں  
4. کثرت سے آنے والی درخواستوں کے لیے کیشنگ میکنزم شامل کریں  
5. مانیٹرنگ ڈیش بورڈ تیار کریں  
6. مختلف درخواست پیٹرنز کے ساتھ ٹیسٹ کریں  

**ٹیکنالوجیز:** Python (.NET/Java/Python آپ کی پسند کے مطابق)، Redis کیشنگ کے لیے، اور ڈیش بورڈ کے لیے ایک سادہ ویب فریم ورک۔

### منصوبہ 2: ادارہ جاتی پرامپٹ مینجمنٹ سسٹم

**مقصد:** ایک MCP پر مبنی نظام تیار کریں جو تنظیم بھر میں پرامپٹ ٹیمپلیٹس کا انتظام، ورژننگ، اور تعیناتی کرے۔

**ضروریات:**  
- پرامپٹ ٹیمپلیٹس کے لیے مرکزی ذخیرہ بنائیں  
- ورژننگ اور منظوری کے ورک فلو نافذ کریں  
- نمونہ ان پٹ کے ساتھ ٹیمپلیٹ ٹیسٹنگ کی صلاحیتیں بنائیں  
- کردار کی بنیاد پر رسائی کنٹرول تیار کریں  
- ٹیمپلیٹ بازیافت اور تعیناتی کے لیے API بنائیں  

**نفاذی مراحل:**  
1. ٹیمپلیٹ اسٹوریج کے لیے ڈیٹا بیس اسکیمہ ڈیزائن کریں  
2. ٹیمپلیٹ CRUD آپریشنز کے لیے بنیادی API بنائیں  
3. ورژننگ سسٹم نافذ کریں  
4. منظوری کا ورک فلو تیار کریں  
5. ٹیسٹنگ فریم ورک تیار کریں  
6. انتظام کے لیے ایک سادہ ویب انٹرفیس بنائیں  
7. MCP سرور کے ساتھ انضمام کریں  

**ٹیکنالوجیز:** آپ کی پسند کا بیک اینڈ فریم ورک، SQL یا NoSQL ڈیٹا بیس، اور فرنٹ اینڈ فریم ورک۔

### منصوبہ 3: MCP پر مبنی مواد تخلیق پلیٹ فارم

**مقصد:** ایسا مواد تخلیق پلیٹ فارم بنائیں جو MCP کا استعمال کرتے ہوئے مختلف مواد کی اقسام میں یکساں نتائج فراہم کرے۔

**ضروریات:**  
- متعدد مواد فارمیٹس کی حمایت (بلاگ پوسٹس، سوشل میڈیا، مارکیٹنگ کاپی)  
- ٹیمپلیٹ پر مبنی تخلیق، حسب ضرورت کے اختیارات کے ساتھ  
- مواد کا جائزہ اور تاثرات کا نظام بنائیں  
- مواد کی کارکردگی کے میٹرکس کو ٹریک کریں  
- مواد کی ورژننگ اور تکرار کی حمایت کریں  

**نفاذی مراحل:**  
1. MCP کلائنٹ انفراسٹرکچر قائم کریں  
2. مختلف مواد کی اقسام کے لیے ٹیمپلیٹس بنائیں  
3. مواد تخلیق کی پائپ لائن تیار کریں  
4. جائزہ نظام نافذ کریں  
5. میٹرکس ٹریکنگ سسٹم تیار کریں  
6. ٹیمپلیٹ مینجمنٹ اور مواد تخلیق کے لیے یوزر انٹرفیس بنائیں  

**ٹیکنالوجیز:** آپ کی پسند کی پروگرامنگ زبان، ویب فریم ورک، اور ڈیٹا بیس سسٹم۔

## MCP ٹیکنالوجی کے لیے مستقبل کی سمتیں

### ابھرتے ہوئے رجحانات

1. **ملٹی موڈل MCP**  
   - تصویر، آڈیو، اور ویڈیو ماڈلز کے ساتھ تعاملات کو معیاری بنانا  
   - کراس موڈل ریازننگ صلاحیتوں کی ترقی  
   - مختلف موڈالٹیز کے لیے معیاری پرامپٹ فارمیٹس  

2. **فیڈریٹڈ MCP انفراسٹرکچر**  
   - تنظیموں کے درمیان وسائل شیئر کرنے کے لیے تقسیم شدہ MCP نیٹ ورکس  
   - محفوظ ماڈل شیئرنگ کے لیے معیاری پروٹوکولز  
   - پرائیویسی محفوظ کمپیوٹیشن تکنیکیں  

3. **MCP مارکیٹ پلیسز**  
   - MCP ٹیمپلیٹس اور پلگ انز کے اشتراک اور منافع بخش بنانے کے ماحولیاتی نظام  
   - معیار کی یقین دہانی اور سرٹیفیکیشن کے عمل  
   - ماڈل مارکیٹ پلیسز کے ساتھ انضمام  

4. **ایج کمپیوٹنگ کے لیے MCP**  
   - محدود وسائل والے ایج ڈیوائسز کے لیے MCP معیارات کی تطبیق  
   - کم بینڈوڈتھ ماحول کے لیے بہتر پروٹوکولز  
   - IoT ماحولیاتی نظام کے لیے مخصوص MCP نفاذات  

5. **ریگولیٹری فریم ورکس**  
   - ریگولیٹری تعمیل کے لیے MCP توسیعات کی ترقی  
   - معیاری آڈٹ ٹریلز اور وضاحت کے انٹرفیس  
   - ابھرتے ہوئے AI گورننس فریم ورکس کے ساتھ انضمام  

### Microsoft سے MCP حل

Microsoft اور Azure نے متعدد اوپن سورس ریپوزیٹریز تیار کی ہیں تاکہ مختلف مناظروں میں MCP کو نافذ کرنے میں ڈویلپرز کی مدد کی جا سکے:

#### Microsoft آرگنائزیشن  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - براؤزر آٹومیشن اور ٹیسٹنگ کے لیے Playwright MCP سرور  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - مقامی ٹیسٹنگ اور کمیونٹی تعاون کے لیے OneDrive MCP سرور نفاذ  
3. [NLWeb](https://github.com/microsoft/NlWeb) - اوپن پروٹوکولز اور متعلقہ اوپن سورس ٹولز کا مجموعہ، AI ویب کے لیے بنیادی پرت قائم کرنا  

#### Azure-Samples آرگنائزیشن  
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure پر MCP سرورز کی تعمیر اور انضمام کے لیے نمونے، ٹولز، اور وسائل  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - موجودہ Model Context Protocol وضاحت کے ساتھ تصدیق دکھانے والے MCP سرورز  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions میں ریموٹ MCP سرور نفاذات کے لیے لینڈنگ پیج  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python کے ساتھ Azure Functions استعمال کرتے ہوئے کسٹم ریموٹ MCP سرورز بنانے اور تعینات کرنے کا کوئیک اسٹارٹ ٹیمپلیٹ  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - .NET/C# کے ساتھ Azure Functions استعمال کرتے ہوئے کسٹم ریموٹ MCP سرورز کے لیے کوئیک اسٹارٹ ٹیمپلیٹ  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - TypeScript کے ساتھ Azure Functions استعمال کرتے ہوئے کسٹم ریموٹ MCP سرورز کے لیے کوئیک اسٹارٹ ٹیمپلیٹ  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Python استعمال کرتے ہوئے Remote MCP سرورز کے لیے Azure API مینجمنٹ بطور AI گیٹ وے  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI تجربات بشمول MCP صلاحیتیں، Azure OpenAI اور AI Foundry کے ساتھ انضمام  

یہ ری
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## مشقیں

1. کسی کیس اسٹڈی کا تجزیہ کریں اور ایک متبادل نفاذ کا طریقہ تجویز کریں۔
2. کسی پروجیکٹ آئیڈیا کا انتخاب کریں اور تفصیلی تکنیکی وضاحت تیار کریں۔
3. ایسی صنعت پر تحقیق کریں جو کیس اسٹڈیز میں شامل نہ ہو اور بیان کریں کہ MCP اس کی مخصوص مشکلات کو کیسے حل کر سکتا ہے۔
4. مستقبل کی سمتوں میں سے ایک کو دریافت کریں اور اسے سپورٹ کرنے کے لیے MCP کی نئی توسیع کا تصور تیار کریں۔

اگلا: [Best Practices](../08-BestPractices/README.md)

**دسclaimer**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجموں میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ ہم اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔