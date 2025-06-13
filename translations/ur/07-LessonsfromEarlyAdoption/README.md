<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T16:50:41+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ur"
}
-->
# سبق کے ابتدائی اپنانے والوں سے اسباق

## جائزہ

یہ سبق بتاتا ہے کہ ابتدائی اپنانے والوں نے Model Context Protocol (MCP) کو کیسے استعمال کیا ہے تاکہ حقیقی دنیا کے مسائل حل کیے جا سکیں اور مختلف صنعتوں میں جدت کو فروغ دیا جا سکے۔ تفصیلی کیس اسٹڈیز اور عملی منصوبوں کے ذریعے، آپ دیکھیں گے کہ MCP کس طرح معیاری، محفوظ، اور قابل توسیع AI انضمام کو ممکن بناتا ہے—جو بڑے زبان کے ماڈلز، ٹولز، اور انٹرپرائز ڈیٹا کو ایک متحد فریم ورک میں جوڑتا ہے۔ آپ MCP پر مبنی حل ڈیزائن اور تعمیر کرنے کا عملی تجربہ حاصل کریں گے، ثابت شدہ نفاذ کے نمونوں سے سیکھیں گے، اور MCP کو پروڈکشن ماحول میں تعینات کرنے کے بہترین طریقے دریافت کریں گے۔ سبق ابھرتے ہوئے رجحانات، مستقبل کے راستے، اور اوپن سورس وسائل کو بھی اجاگر کرتا ہے تاکہ آپ MCP ٹیکنالوجی اور اس کے ارتقائی ماحولیاتی نظام کے آگے رہ سکیں۔

## سیکھنے کے مقاصد

- مختلف صنعتوں میں حقیقی دنیا کے MCP نفاذ کا تجزیہ کرنا  
- مکمل MCP پر مبنی ایپلیکیشنز ڈیزائن اور تعمیر کرنا  
- MCP ٹیکنالوجی میں ابھرتے ہوئے رجحانات اور مستقبل کے راستے دریافت کرنا  
- حقیقی ترقیاتی حالات میں بہترین طریقے اپنانا  

## حقیقی دنیا کے MCP نفاذ

### کیس اسٹڈی 1: انٹرپرائز کسٹمر سپورٹ آٹومیشن

ایک کثیر القومی کمپنی نے MCP پر مبنی حل نافذ کیا تاکہ اپنے کسٹمر سپورٹ سسٹمز میں AI انٹریکشنز کو معیاری بنایا جا سکے۔ اس سے وہ درج ذیل کام کر سکے:

- متعدد LLM فراہم کنندگان کے لیے ایک متحد انٹرفیس تخلیق کرنا  
- محکموں میں مستقل پرامپٹ مینجمنٹ برقرار رکھنا  
- مضبوط سیکیورٹی اور تعمیل کنٹرول نافذ کرنا  
- مخصوص ضروریات کی بنیاد پر مختلف AI ماڈلز کے درمیان آسانی سے تبدیلی کرنا  

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

**نتائج:** ماڈل کے اخراجات میں 30% کمی، ردعمل کی مستقل مزاجی میں 45% بہتری، اور عالمی آپریشنز میں بہتر تعمیل۔

### کیس اسٹڈی 2: صحت کی دیکھ بھال کے تشخیصی معاون

ایک صحت کی دیکھ بھال فراہم کرنے والے نے متعدد تخصصی طبی AI ماڈلز کو مربوط کرنے کے لیے MCP انفراسٹرکچر تیار کیا جبکہ حساس مریض کے ڈیٹا کو محفوظ رکھا:

- عام اور ماہر طبی ماڈلز کے درمیان بلا تعطل تبدیلی  
- سخت پرائیویسی کنٹرول اور آڈٹ ٹریلز  
- موجودہ الیکٹرانک ہیلتھ ریکارڈ (EHR) سسٹمز کے ساتھ انضمام  
- طبی اصطلاحات کے لیے مستقل پرامپٹ انجینئرنگ  

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

**نتائج:** ڈاکٹروں کے لیے بہتر تشخیصی تجاویز، مکمل HIPAA تعمیل، اور سسٹمز کے درمیان کانٹیکسٹ سوئچنگ میں نمایاں کمی۔

### کیس اسٹڈی 3: مالی خدمات میں خطرے کا تجزیہ

ایک مالی ادارے نے مختلف محکموں میں اپنے خطرے کے تجزیے کے عمل کو معیاری بنانے کے لیے MCP نافذ کیا:

- کریڈٹ رسک، فراڈ ڈیٹیکشن، اور سرمایہ کاری کے خطرے کے ماڈلز کے لیے متحد انٹرفیس بنایا  
- سخت رسائی کنٹرول اور ماڈل ورژننگ نافذ کی  
- تمام AI سفارشات کی آڈٹ ایبلٹی یقینی بنائی  
- مختلف سسٹمز میں مستقل ڈیٹا فارمیٹنگ برقرار رکھی  

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

**نتائج:** ریگولیٹری تعمیل میں بہتری، ماڈل کی تعیناتی کے چکر میں 40% تیزی، اور محکموں میں خطرے کے تجزیے کی مستقل مزاجی۔

### کیس اسٹڈی 4: Microsoft Playwright MCP سرور براؤزر آٹومیشن کے لیے

Microsoft نے [Playwright MCP server](https://github.com/microsoft/playwright-mcp) تیار کیا تاکہ Model Context Protocol کے ذریعے محفوظ، معیاری براؤزر آٹومیشن کو ممکن بنایا جا سکے۔ یہ حل AI ایجنٹس اور LLMs کو ویب براؤزرز کے ساتھ کنٹرولڈ، آڈیٹیبل، اور قابل توسیع انداز میں بات چیت کرنے کی اجازت دیتا ہے—جیسے خودکار ویب ٹیسٹنگ، ڈیٹا نکالنا، اور اینڈ ٹو اینڈ ورک فلو۔

- براؤزر آٹومیشن کی صلاحیتوں (نیویگیشن، فارم بھرنا، اسکرین شاٹ لینا وغیرہ) کو MCP ٹولز کے طور پر پیش کرتا ہے  
- غیر مجاز کارروائیوں کو روکنے کے لیے سخت رسائی کنٹرول اور سینڈباکسنگ نافذ کرتا ہے  
- تمام براؤزر تعاملات کے لیے تفصیلی آڈٹ لاگز فراہم کرتا ہے  
- ایجنٹ کی قیادت والی آٹومیشن کے لیے Azure OpenAI اور دیگر LLM فراہم کنندگان کے ساتھ انضمام کی حمایت کرتا ہے  

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
- AI ایجنٹس اور LLMs کے لیے محفوظ، پروگراماتی براؤزر آٹومیشن ممکن بنائی  
- دستی ٹیسٹنگ کی محنت کم کی اور ویب ایپلیکیشنز کے لیے ٹیسٹ کوریج بہتر کی  
- انٹرپرائز ماحول میں براؤزر پر مبنی ٹول انضمام کے لیے دوبارہ قابل استعمال، توسیعی فریم ورک فراہم کیا  

**References:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### کیس اسٹڈی 5: Azure MCP – انٹرپرائز گریڈ Model Context Protocol بطور سروس

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) Microsoft کا منظم، انٹرپرائز گریڈ نفاذ ہے جو Model Context Protocol کے MCP سرور کی صلاحیتوں کو کلاؤڈ سروس کے طور پر فراہم کرتا ہے۔ Azure MCP تنظیموں کو تیزی سے MCP سرورز کو تعینات، منظم، اور Azure AI، ڈیٹا، اور سیکیورٹی سروسز کے ساتھ مربوط کرنے کی اجازت دیتا ہے، جس سے آپریشنل بوجھ کم ہوتا ہے اور AI اپنانے میں تیزی آتی ہے۔

- مکمل طور پر منظم MCP سرور ہوسٹنگ، بلٹ ان اسکیلنگ، مانیٹرنگ، اور سیکیورٹی کے ساتھ  
- Azure OpenAI، Azure AI Search، اور دیگر Azure سروسز کے ساتھ مقامی انضمام  
- Microsoft Entra ID کے ذریعے انٹرپرائز تصدیق اور اجازت  
- کسٹم ٹولز، پرامپٹ ٹیمپلیٹس، اور ریسورس کنیکٹرز کی حمایت  
- انٹرپرائز سیکیورٹی اور ریگولیٹری تقاضوں کی تعمیل  

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
- انٹرپرائز AI منصوبوں کے لیے وقت کو قدر تک کم کیا، ایک تیار، تعمیل شدہ MCP سرور پلیٹ فارم فراہم کر کے  
- LLMs، ٹولز، اور انٹرپرائز ڈیٹا ذرائع کے انضمام کو آسان بنایا  
- MCP ورک لوڈز کے لیے سیکیورٹی، مشاہدہ کاری، اور آپریشنل کارکردگی کو بہتر بنایا  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## کیس اسٹڈی 6: NLWeb

MCP (Model Context Protocol) ایک ابھرتا ہوا پروٹوکول ہے جو چیٹ بوٹس اور AI اسسٹنٹس کو ٹولز کے ساتھ بات چیت کرنے کے قابل بناتا ہے۔ ہر NLWeb انسٹانس بھی ایک MCP سرور ہے، جو ایک بنیادی طریقہ، ask، کو سپورٹ کرتا ہے، جو ایک ویب سائٹ سے قدرتی زبان میں سوال کرنے کے لیے استعمال ہوتا ہے۔ موصولہ جواب schema.org کا استعمال کرتا ہے، جو ویب ڈیٹا کی وضاحت کے لیے ایک وسیع پیمانے پر استعمال ہونے والا لغت ہے۔ آسان الفاظ میں، MCP ویسا ہی ہے جیسا HTTP ہے HTML کے لیے۔ NLWeb پروٹوکولز، Schema.org فارمیٹس، اور نمونہ کوڈ کو یکجا کرتا ہے تاکہ سائٹس تیزی سے یہ اینڈ پوائنٹس بنا سکیں، جو انسانوں کو مکالماتی انٹرفیسز کے ذریعے اور مشینوں کو قدرتی ایجنٹ سے ایجنٹ بات چیت کے ذریعے فائدہ پہنچاتے ہیں۔

NLWeb کے دو مختلف اجزاء ہیں:  
- ایک پروٹوکول، جو شروع میں بہت سادہ ہے، سائٹ کے ساتھ قدرتی زبان میں انٹرفیس کے لیے اور ایک فارمیٹ، جو json اور schema.org کو استعمال کرتا ہے جواب کے لیے۔ REST API کی دستاویزات مزید تفصیلات کے لیے دیکھیں۔  
- (1) کا ایک سیدھا نفاذ جو موجودہ مارک اپ کا فائدہ اٹھاتا ہے، ان سائٹس کے لیے جو اشیاء کی فہرستوں (مصنوعات، ترکیبیں، سیاحتی مقامات، جائزے وغیرہ) کے طور پر خلاصہ کی جا سکتی ہیں۔ صارف انٹرفیس وجیٹس کے ساتھ، سائٹس آسانی سے اپنے مواد کے لیے مکالماتی انٹرفیسز فراہم کر سکتی ہیں۔ Life of a chat query کی دستاویزات میں مزید تفصیلات دیکھیں کہ یہ کیسے کام کرتا ہے۔  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### کیس اسٹڈی 7: Foundry کے لیے MCP – Azure AI ایجنٹس کا انضمام

Azure AI Foundry MCP سرورز دکھاتے ہیں کہ MCP کو انٹرپرائز ماحول میں AI ایجنٹس اور ورک فلو کو منظم اور ترتیب دینے کے لیے کیسے استعمال کیا جا سکتا ہے۔ MCP کو Azure AI Foundry کے ساتھ مربوط کر کے، تنظیمیں ایجنٹ انٹریکشنز کو معیاری بنا سکتی ہیں، Foundry کے ورک فلو مینجمنٹ کا فائدہ اٹھا سکتی ہیں، اور محفوظ، قابل توسیع تعیناتی کو یقینی بنا سکتی ہیں۔ یہ طریقہ تیز پروٹو ٹائپنگ، مضبوط مانیٹرنگ، اور Azure AI سروسز کے ساتھ ہموار انضمام کو ممکن بناتا ہے، اور علم کی مینجمنٹ اور ایجنٹ کے جائزے جیسے جدید منظرناموں کی حمایت کرتا ہے۔ ڈویلپرز کو ایجنٹ پائپ لائنز کی تعمیر، تعیناتی، اور مانیٹرنگ کے لیے متحد انٹرفیس ملتا ہے، جبکہ IT ٹیموں کو بہتر سیکیورٹی، تعمیل، اور آپریشنل کارکردگی حاصل ہوتی ہے۔ یہ حل ان انٹرپرائزز کے لیے مثالی ہے جو AI اپنانے کو تیز کرنا چاہتے ہیں اور پیچیدہ ایجنٹ کی قیادت والے عمل پر کنٹرول برقرار رکھنا چاہتے ہیں۔

**References:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### کیس اسٹڈی 8: Foundry MCP Playground – تجربہ اور پروٹو ٹائپنگ

Foundry MCP Playground ایک تیار ماحول فراہم کرتا ہے MCP سرورز اور Azure AI Foundry انضمامات کے ساتھ تجربہ کرنے کے لیے۔ ڈویلپرز تیزی سے AI ماڈلز اور ایجنٹ ورک فلو کا پروٹو ٹائپ، ٹیسٹ، اور جائزہ لے سکتے ہیں Azure AI Foundry Catalog اور Labs کے وسائل استعمال کر کے۔ یہ پلی گراونڈ سیٹ اپ کو آسان بناتا ہے، نمونہ منصوبے فراہم کرتا ہے، اور مشترکہ ترقی کی حمایت کرتا ہے، جس سے کم سے کم بوجھ کے ساتھ بہترین طریقے اور نئے منظرنامے دریافت کرنا آسان ہوتا ہے۔ یہ خاص طور پر ٹیموں کے لیے مفید ہے جو خیالات کی تصدیق، تجربات کا اشتراک، اور سیکھنے کو تیز کرنا چاہتے ہیں بغیر پیچیدہ انفراسٹرکچر کی ضرورت کے۔ رکاوٹ کو کم کر کے، یہ پلی گراونڈ MCP اور Azure AI Foundry ماحولیاتی نظام میں جدت اور کمیونٹی تعاون کو فروغ دیتا ہے۔

**References:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

### کیس اسٹڈی 9: Microsoft Docs MCP Server - سیکھنا اور مہارت حاصل کرنا

Microsoft Docs MCP Server Model Context Protocol (MCP) سرور کو نافذ کرتا ہے جو AI اسسٹنٹس کو حقیقی وقت میں Microsoft کی سرکاری دستاویزات تک رسائی فراہم کرتا ہے۔ Microsoft کی سرکاری تکنیکی دستاویزات کے خلاف معنوی تلاش انجام دیتا ہے۔

**References:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)  

## عملی منصوبے

### منصوبہ 1: ملٹی-پرووائیڈر MCP سرور بنائیں

**مقصد:** ایک ایسا MCP سرور تخلیق کریں جو مخصوص معیارات کی بنیاد پر متعدد AI ماڈل فراہم کنندگان کو درخواستیں بھیج سکے۔

**ضروریات:**  
- کم از کم تین مختلف ماڈل فراہم کنندگان کی حمایت (مثلاً OpenAI، Anthropic، مقامی ماڈلز)  
- درخواست میٹا ڈیٹا کی بنیاد پر روٹنگ میکانزم نافذ کریں  
- فراہم کنندہ کی اسناد کے انتظام کے لیے کنفیگریشن سسٹم بنائیں  
- کارکردگی اور لاگت کو بہتر بنانے کے لیے کیشنگ شامل کریں  
- استعمال کی نگرانی کے لیے ایک سادہ ڈیش بورڈ بنائیں  

**نفاذ کے مراحل:**  
1. بنیادی MCP سرور انفراسٹرکچر قائم کریں  
2. ہر AI ماڈل سروس کے لیے فراہم کنندہ اڈاپٹر نافذ کریں  
3. درخواست کی خصوصیات کی بنیاد پر روٹنگ لاجک تخلیق کریں  
4. بار بار آنے والی درخواستوں کے لیے کیشنگ میکانزم شامل کریں  
5. مانیٹرنگ ڈیش بورڈ تیار کریں  
6. مختلف درخواست پیٹرنز کے ساتھ ٹیسٹ کریں  

**ٹیکنالوجیز:** اپنی پسند کے مطابق Python (.NET/Java/Python)، کیشنگ کے لیے Redis، اور ڈیش بورڈ کے لیے ایک سادہ ویب فریم ورک منتخب کریں۔  

### منصوبہ 2: انٹرپرائز پرامپٹ مینجمنٹ سسٹم

**مقصد:** ایک MCP پر مبنی نظام تیار کریں جو تنظیم بھر میں پرامپٹ ٹیمپلیٹس کا انتظام، ورژننگ، اور تعیناتی کرے۔

**ضروریات:**  
- پرامپٹ ٹیمپلیٹس کے لیے مرکزی ذخیرہ بنائیں  
- ورژننگ اور منظوری کے ورک فلو نافذ کریں  
- نمونہ ان پٹ کے ساتھ ٹیمپلیٹ ٹیسٹنگ کی صلاحیتیں بنائیں  
- کردار پر مبنی رسائی کنٹرول تیار کریں  
- ٹیمپلیٹ بازیافت اور تعیناتی کے لیے API بنائیں  

**نفاذ کے مراحل:**  
1. ٹیمپلیٹ ذخیرہ کے لیے ڈیٹا بیس اسکیمہ ڈیزائن کریں  
2. ٹیمپلیٹ CRUD آپریشنز کے لیے بنیادی API بنائیں  
3. ورژننگ سسٹم نافذ کریں  
4. منظوری کے ورک فلو تیار کریں  
5. ٹیسٹنگ فریم ورک تیار کریں  
6. انتظام کے لیے ایک سادہ ویب انٹرفیس بنائیں  
7. MCP سرور کے ساتھ انضمام کریں  

**ٹیکنالوجیز:** اپنی پسند کے مطابق بیک اینڈ فریم ورک، SQL یا NoSQL ڈیٹا بیس، اور مینجمنٹ انٹرفیس کے لیے فرنٹ اینڈ فریم ورک منتخب کریں۔  

### منصوبہ 3: MCP پر مبنی مواد تخلیق کا پلیٹ فارم

**مقصد:** ایک ایسا مواد تخلیق پلیٹ فارم بنائیں جو MCP کا فائدہ اٹھاتے ہوئے مختلف مواد کی اقسام میں مستقل نتائج فراہم کرے۔

**ضروریات:**  
- متعدد مواد کے فارمیٹس کی حمایت (بلاگ پوسٹس، سوشل میڈیا، مارکیٹنگ کاپی)  
- تخصیص کے اختیارات کے ساتھ ٹیمپلیٹ پر مبنی تخلیق نافذ کریں  
- مواد کے جائزے اور فیڈ بیک کا نظام بنائیں  
- مواد کی کارکردگی کے میٹرکس کو ٹریک کریں  
- مواد کی ورژننگ اور تکرار کی حمایت کریں  

**نفاذ کے مراحل:**  
1. MCP کلائنٹ انفراسٹرکچر قائم کریں  
2. مختلف مواد کی اقسام کے لیے ٹیمپلیٹس بنائیں  
3. مواد تخلیق پائپ لائن تیار کریں  
4. جائزہ نظام نافذ کریں  
5. میٹرکس ٹریکنگ سسٹم تیار کریں  
6. ٹیمپلیٹ مینجمنٹ اور مواد تخلیق کے لیے یوزر انٹرفیس بنائیں  

**ٹیکنالوجیز:** اپنی پسندیدہ پروگرامنگ زبان، ویب فریم ورک، اور ڈیٹا بیس سسٹم استعمال کریں۔  

## MCP ٹیکنالوجی کے لیے مستقبل کے راستے

### ابھرتے ہوئے رجحانات

1. **ملٹی-موڈل MCP**  
   - تصویری، آڈیو، اور ویڈیو ماڈلز کے ساتھ تعاملات کو معیاری بنانا  
   - کراس-موڈل ریزننگ صلاحیتوں کی ترقی  
   - مختلف موڈالٹیز کے لیے معیاری پرامپٹ فارمیٹس  

2. **فیڈریٹڈ MCP انفراسٹرکچر**  
   - تنظیموں کے درمیان وسائل بانٹنے والے تقسیم شدہ MCP نیٹ ورکس  
   - محفوظ ماڈل شیئرنگ کے لیے معیاری پروٹوکولز  
   - پرائیویسی محفوظ رکھنے والی کمپیوٹیشن تکنیکس  

3. **MCP مارکیٹ پلیسز**  
   - MCP ٹیمپلیٹس اور پلگ انز کے اشتراک اور مونیٹائزیشن کے ماحولیاتی نظام  
   - معیار کی یقین
- [MCP کمیونٹی اور دستاویزات](https://modelcontextprotocol.io/introduction)
- [Azure MCP دستاویزات](https://aka.ms/azmcp)
- [Playwright MCP سرور GitHub ریپوزیٹری](https://github.com/microsoft/playwright-mcp)
- [Files MCP سرور (OneDrive)](https://github.com/microsoft/files-mcp-server)
- [Azure-Samples MCP](https://github.com/Azure-Samples/mcp)
- [MCP Auth سرورز (Azure-Samples)](https://github.com/Azure-Samples/mcp-auth-servers)
- [Remote MCP فنکشنز (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions)
- [Remote MCP فنکشنز Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP فنکشنز .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP فنکشنز TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM فنکشنز Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI اور آٹومیشن حل](https://azure.microsoft.com/en-us/products/ai-services/)

## مشقیں

1. کیس اسٹڈیز میں سے ایک کا تجزیہ کریں اور متبادل نفاذ کا طریقہ تجویز کریں۔
2. پروجیکٹ کے خیالات میں سے ایک منتخب کریں اور تفصیلی تکنیکی وضاحت تیار کریں۔
3. کسی ایسی صنعت پر تحقیق کریں جو کیس اسٹڈیز میں شامل نہیں ہے اور بیان کریں کہ MCP اس کی مخصوص چیلنجز کو کیسے حل کر سکتا ہے۔
4. مستقبل کی سمتوں میں سے ایک کا جائزہ لیں اور اسے سپورٹ کرنے کے لیے نئے MCP ایکسٹینشن کا تصور تیار کریں۔

اگلا: [بہترین طریقے](../08-BestPractices/README.md)

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجموں میں غلطیاں یا بے ضابطگیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تعبیر کے ذمہ دار نہیں ہیں۔