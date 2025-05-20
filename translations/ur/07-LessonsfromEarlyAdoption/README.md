<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1ccfe1a6ea77e42862b92ae53cb6cddf",
  "translation_date": "2025-05-20T15:56:10+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ur"
}
-->
# اس ابتدائی اپنانے والوں سے اسباق

## جائزہ

یہ سبق اس بات کا جائزہ لیتا ہے کہ ابتدائی اپنانے والوں نے Model Context Protocol (MCP) کو کیسے استعمال کیا ہے تاکہ حقیقی دنیا کے چیلنجز حل کیے جا سکیں اور صنعتوں میں جدت کو فروغ دیا جا سکے۔ تفصیلی کیس اسٹڈیز اور عملی منصوبوں کے ذریعے، آپ دیکھیں گے کہ MCP کس طرح معیاری، محفوظ، اور اسکیل ایبل AI انٹیگریشن کو ممکن بناتا ہے—جو بڑے زبان کے ماڈلز، ٹولز، اور انٹرپرائز ڈیٹا کو ایک متحد فریم ورک میں جوڑتا ہے۔ آپ MCP پر مبنی حل ڈیزائن اور بنانے کا عملی تجربہ حاصل کریں گے، ثابت شدہ نفاذ کے نمونوں سے سیکھیں گے، اور پروڈکشن ماحول میں MCP کو تعینات کرنے کے بہترین طریقے دریافت کریں گے۔ سبق میں ابھرتے ہوئے رجحانات، مستقبل کی سمتیں، اور اوپن سورس وسائل بھی شامل ہیں تاکہ آپ MCP ٹیکنالوجی اور اس کے بدلتے ہوئے ماحولیاتی نظام میں آگے رہ سکیں۔

## سیکھنے کے مقاصد

- مختلف صنعتوں میں حقیقی دنیا کی MCP نفاذات کا تجزیہ کریں  
- مکمل MCP پر مبنی ایپلیکیشنز ڈیزائن اور بنائیں  
- MCP ٹیکنالوجی میں ابھرتے ہوئے رجحانات اور مستقبل کی سمتوں کو دریافت کریں  
- حقیقی ترقیاتی حالات میں بہترین طریقے اپنائیں  

## حقیقی دنیا کی MCP نفاذات

### کیس اسٹڈی 1: انٹرپرائز کسٹمر سپورٹ آٹومیشن

ایک کثیر القومی کمپنی نے MCP پر مبنی حل نافذ کیا تاکہ اپنے کسٹمر سپورٹ سسٹمز میں AI تعاملات کو معیاری بنایا جا سکے۔ اس سے انہیں یہ سہولت ملی:

- متعدد LLM فراہم کنندگان کے لیے ایک متحد انٹرفیس تخلیق کرنا  
- شعبہ جات میں یکساں پرامپٹ مینجمنٹ برقرار رکھنا  
- مضبوط سیکیورٹی اور تعمیل کنٹرولز نافذ کرنا  
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

**نتائج:** ماڈل کی لاگت میں 30٪ کمی، ردعمل کی مستقل مزاجی میں 45٪ بہتری، اور عالمی آپریشنز میں تعمیل میں اضافہ۔

### کیس اسٹڈی 2: ہیلتھ کیئر ڈائیگناسٹک اسسٹنٹ

ایک ہیلتھ کیئر فراہم کنندہ نے MCP انفراسٹرکچر تیار کیا تاکہ متعدد مخصوص طبی AI ماڈلز کو مربوط کیا جا سکے جبکہ حساس مریض کے ڈیٹا کی حفاظت کو یقینی بنایا جائے:

- جنرل اور اسپیشلسٹ طبی ماڈلز کے درمیان بغیر رکاوٹ تبدیلی  
- سخت پرائیویسی کنٹرولز اور آڈٹ ٹریلز  
- موجودہ الیکٹرانک ہیلتھ ریکارڈ (EHR) سسٹمز کے ساتھ انٹیگریشن  
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

**نتائج:** ڈاکٹروں کے لیے بہتر تشخیصی تجاویز، مکمل HIPAA تعمیل، اور سسٹمز کے درمیان کانٹیکسٹ سوئچنگ میں نمایاں کمی۔

### کیس اسٹڈی 3: مالیاتی خدمات میں رسک تجزیہ

ایک مالیاتی ادارے نے MCP کو اپنے مختلف شعبہ جات میں رسک تجزیہ کے عمل کو معیاری بنانے کے لیے نافذ کیا:

- کریڈٹ رسک، فراڈ ڈیٹیکشن، اور سرمایہ کاری کے رسک ماڈلز کے لیے متحد انٹرفیس تخلیق کیا  
- سخت رسائی کنٹرولز اور ماڈل ورژننگ نافذ کی  
- تمام AI سفارشات کی آڈیٹیبلٹی کو یقینی بنایا  
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

**نتائج:** ریگولیٹری تعمیل میں بہتری، ماڈل کی تعیناتی کے چکروں میں 40٪ تیزی، اور شعبہ جات میں رسک اسیسمنٹ کی مستقل مزاجی میں اضافہ۔

### کیس اسٹڈی 4: Microsoft Playwright MCP سرور براؤزر آٹومیشن کے لیے

Microsoft نے [Playwright MCP server](https://github.com/microsoft/playwright-mcp) تیار کیا تاکہ Model Context Protocol کے ذریعے محفوظ، معیاری براؤزر آٹومیشن ممکن ہو سکے۔ یہ حل AI ایجنٹس اور LLMs کو ویب براؤزرز کے ساتھ کنٹرولڈ، آڈیٹیبل، اور توسیعی انداز میں بات چیت کرنے کی اجازت دیتا ہے—جیسے کہ خودکار ویب ٹیسٹنگ، ڈیٹا نکالنے، اور اینڈ ٹو اینڈ ورک فلو۔

- براؤزر آٹومیشن کی صلاحیتیں (نیویگیشن، فارم فلنگ، اسکرین شاٹ کیپچر وغیرہ) MCP ٹولز کے طور پر فراہم کرتا ہے  
- غیر مجاز کارروائیوں کو روکنے کے لیے سخت رسائی کنٹرولز اور سینڈ باکسنگ نافذ کرتا ہے  
- تمام براؤزر تعاملات کے لیے تفصیلی آڈٹ لاگز فراہم کرتا ہے  
- Azure OpenAI اور دیگر LLM فراہم کنندگان کے ساتھ ایجنٹ پر مبنی آٹومیشن کی حمایت کرتا ہے  

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
- AI ایجنٹس اور LLMs کے لیے محفوظ، پروگراماتی براؤزر آٹومیشن فعال کی  
- دستی ٹیسٹنگ کی کوشش کم کی اور ویب ایپلیکیشنز کے لیے ٹیسٹ کوریج بہتر کی  
- انٹرپرائز ماحول میں براؤزر پر مبنی ٹول انٹیگریشن کے لیے قابلِ استعمال، توسیعی فریم ورک فراہم کیا  

**References:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### کیس اسٹڈی 5: Azure MCP – انٹرپرائز گریڈ Model Context Protocol بطور سروس

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) Microsoft کی منظم، انٹرپرائز گریڈ Model Context Protocol نفاذ ہے، جو MCP سرور کی صلاحیتوں کو کلاؤڈ سروس کے طور پر اسکیل ایبل، محفوظ، اور تعمیل کے ساتھ فراہم کرتی ہے۔ Azure MCP تنظیموں کو تیزی سے MCP سرورز کو تعینات، منظم، اور Azure AI، ڈیٹا، اور سیکیورٹی خدمات کے ساتھ مربوط کرنے کی سہولت دیتا ہے، جس سے آپریشنل بوجھ کم ہوتا ہے اور AI اپنانے کی رفتار بڑھتی ہے۔

- مکمل منظم MCP سرور ہوسٹنگ، جس میں بلٹ ان اسکیلنگ، مانیٹرنگ، اور سیکیورٹی شامل ہے  
- Azure OpenAI، Azure AI سرچ، اور دیگر Azure خدمات کے ساتھ قدرتی انٹیگریشن  
- Microsoft Entra ID کے ذریعے انٹرپرائز تصدیق اور اجازت  
- کسٹم ٹولز، پرامپٹ ٹیمپلیٹس، اور ریسورس کنیکٹرز کی حمایت  
- انٹرپرائز سیکیورٹی اور ریگولیٹری تقاضوں کے ساتھ تعمیل  

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
- انٹرپرائز AI پروجیکٹس کے لیے وقت کی بچت، ایک تیار، تعمیل شدہ MCP سرور پلیٹ فارم فراہم کر کے  
- LLMs، ٹولز، اور انٹرپرائز ڈیٹا ذرائع کی آسان انٹیگریشن  
- MCP ورک لوڈز کے لیے بہتر سیکیورٹی، مشاہدہ، اور آپریشنل کارکردگی  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## کیس اسٹڈی 6: NLWeb

MCP (Model Context Protocol) ایک ابھرتا ہوا پروٹوکول ہے جو چیٹ بوٹس اور AI اسسٹنٹس کو ٹولز کے ساتھ بات چیت کرنے کی اجازت دیتا ہے۔ ہر NLWeb انسٹینس بھی ایک MCP سرور ہے، جو ایک بنیادی طریقہ ask کو سپورٹ کرتا ہے، جس سے کسی ویب سائٹ سے قدرتی زبان میں سوال پوچھا جا سکتا ہے۔ موصولہ جواب schema.org استعمال کرتا ہے، جو ویب ڈیٹا کی وضاحت کے لیے وسیع پیمانے پر استعمال ہونے والا لغت ہے۔ سادہ الفاظ میں، MCP وہی ہے جو Http ہے HTML کے لیے۔ NLWeb پروٹوکولز، Schema.org فارمیٹس، اور نمونہ کوڈ کو یکجا کرتا ہے تاکہ سائٹس کو جلدی سے ایسے اینڈپوائنٹس بنانے میں مدد ملے، جو انسانی صارفین کو مکالماتی انٹرفیسز اور مشینوں کو قدرتی ایجنٹ سے ایجنٹ بات چیت کے ذریعے فائدہ پہنچائیں۔

NLWeb کے دو الگ الگ اجزاء ہیں:  
- ایک پروٹوکول، جو شروع میں بہت سادہ ہے، جو سائٹ کے ساتھ قدرتی زبان میں انٹرفیس فراہم کرتا ہے اور ایک فارمیٹ، جو json اور schema.org کا استعمال کرتا ہے جواب کے لیے۔ REST API کی دستاویزات میں مزید تفصیلات دیکھیں۔  
- (1) کا ایک سیدھا سادہ نفاذ جو موجودہ مارک اپ کا فائدہ اٹھاتا ہے، ان سائٹس کے لیے جو اشیاء کی فہرستوں (مصنوعات، ترکیبیں، سیاحتی مقامات، جائزے وغیرہ) کے طور پر خلاصہ کی جا سکتی ہیں۔ صارف انٹرفیس وجیٹس کے ساتھ، سائٹس آسانی سے اپنے مواد کے لیے مکالماتی انٹرفیسز فراہم کر سکتی ہیں۔ Life of a chat query کی دستاویزات میں اس کے کام کرنے کے طریقے کی مزید تفصیل ہے۔  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### کیس اسٹڈی 7: Foundry کے لیے MCP – Azure AI Agents کا انٹیگریشن

Azure AI Foundry MCP سرورز ظاہر کرتے ہیں کہ MCP کو انٹرپرائز ماحول میں AI ایجنٹس اور ورک فلو کو منظم اور آرکیسٹریٹ کرنے کے لیے کیسے استعمال کیا جا سکتا ہے۔ MCP کو Azure AI Foundry کے ساتھ مربوط کر کے، تنظیمیں ایجنٹ تعاملات کو معیاری بنا سکتی ہیں، Foundry کے ورک فلو مینجمنٹ کا فائدہ اٹھا سکتی ہیں، اور محفوظ، اسکیل ایبل تعیناتی کو یقینی بنا سکتی ہیں۔ یہ طریقہ تیز پروٹوٹائپنگ، مضبوط مانیٹرنگ، اور Azure AI خدمات کے ساتھ بغیر رکاوٹ انٹیگریشن کو ممکن بناتا ہے، اور علم کے انتظام اور ایجنٹ تشخیص جیسے جدید منظرناموں کی حمایت کرتا ہے۔ ڈویلپرز کو ایجنٹ پائپ لائنز بنانے، تعینات کرنے، اور مانیٹر کرنے کے لیے ایک متحد انٹرفیس ملتا ہے، جبکہ آئی ٹی ٹیمیں بہتر سیکیورٹی، تعمیل، اور آپریشنل کارکردگی حاصل کرتی ہیں۔ یہ حل ان اداروں کے لیے مثالی ہے جو AI اپنانے کو تیز کرنا چاہتے ہیں اور پیچیدہ ایجنٹ پر مبنی عمل پر کنٹرول برقرار رکھنا چاہتے ہیں۔

**References:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### کیس اسٹڈی 8: Foundry MCP Playground – تجربہ کاری اور پروٹوٹائپنگ

Foundry MCP Playground MCP سرورز اور Azure AI Foundry انٹیگریشنز کے ساتھ تجربات کرنے کے لیے تیار استعمال ماحول فراہم کرتا ہے۔ ڈویلپرز Azure AI Foundry Catalog اور Labs کے وسائل استعمال کرتے ہوئے تیزی سے AI ماڈلز اور ایجنٹ ورک فلو کا پروٹوٹائپ بنا سکتے ہیں، ٹیسٹ کر سکتے ہیں، اور جائزہ لے سکتے ہیں۔ یہ پلیگراؤنڈ سیٹ اپ کو آسان بناتا ہے، نمونہ پروجیکٹس فراہم کرتا ہے، اور مشترکہ ترقی کی حمایت کرتا ہے، جس سے کم سے کم اوور ہیڈ کے ساتھ بہترین طریقے اور نئے منظرنامے دریافت کرنا آسان ہو جاتا ہے۔ یہ خاص طور پر ٹیموں کے لیے مفید ہے جو آئیڈیاز کی توثیق، تجربات کا اشتراک، اور سیکھنے کی رفتار کو بڑھانا چاہتے ہیں بغیر پیچیدہ انفراسٹرکچر کی ضرورت کے۔ رکاوٹ کو کم کر کے، یہ پلیگراؤنڈ MCP اور Azure AI Foundry کے ماحولیاتی نظام میں جدت اور کمیونٹی شراکت کو فروغ دیتا ہے۔

**References:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

## عملی منصوبے

### منصوبہ 1: ملٹی-پرووائیڈر MCP سرور بنائیں

**مقصد:** ایک MCP سرور تخلیق کریں جو مخصوص معیار کی بنیاد پر متعدد AI ماڈل فراہم کنندگان کو درخواستیں بھیج سکے۔

**ضروریات:**  
- کم از کم تین مختلف ماڈل فراہم کنندگان کی حمایت (مثلاً OpenAI، Anthropic، لوکل ماڈلز)  
- درخواست کے میٹا ڈیٹا کی بنیاد پر روٹنگ میکانزم نافذ کریں  
- فراہم کنندگان کے اسناد کے انتظام کے لیے کنفیگریشن سسٹم بنائیں  
- کارکردگی اور لاگت کو بہتر بنانے کے لیے کیشنگ شامل کریں  
- استعمال کی نگرانی کے لیے ایک سادہ ڈیش بورڈ بنائیں  

**نفاذ کے مراحل:**  
1. بنیادی MCP سرور انفراسٹرکچر قائم کریں  
2. ہر AI ماڈل سروس کے لیے فراہم کنندہ اڈاپٹرز نافذ کریں  
3. درخواست کی خصوصیات کی بنیاد پر روٹنگ لاجک تخلیق کریں  
4. بار بار آنے والی درخواستوں کے لیے کیشنگ میکانزم شامل کریں  
5. مانیٹرنگ ڈیش بورڈ تیار کریں  
6. مختلف درخواست پیٹرنز کے ساتھ ٹیسٹ کریں  

**ٹیکنالوجیز:** اپنی پسند کے مطابق Python (.NET/Java/Python)، Redis کیشنگ کے لیے، اور ڈیش بورڈ کے لیے سادہ ویب فریم ورک۔

### منصوبہ 2: انٹرپرائز پرامپٹ مینجمنٹ سسٹم

**مقصد:** ایک MCP پر مبنی سسٹم تیار کریں جو تنظیم بھر میں پرامپٹ ٹیمپلیٹس کے انتظام، ورژننگ، اور تعیناتی کے لیے ہو۔

**ضروریات:**  
- پرامپٹ ٹیمپلیٹس کے لیے مرکزی ذخیرہ تخلیق کریں  
- ورژننگ اور منظوری کے ورک فلو نافذ کریں  
- نمونہ ان پٹس کے ساتھ ٹیمپلیٹ ٹیسٹنگ کی صلاحیت بنائیں  
- رول بیسڈ رسائی کنٹرولز تیار کریں  
- ٹیمپلیٹ بازیافت اور تعیناتی کے لیے API بنائیں  

**نفاذ کے مراحل:**  
1. ٹیمپلیٹ اسٹوریج کے لیے ڈیٹا بیس اسکیمہ ڈیزائن کریں  
2. ٹیمپلیٹ CRUD آپریشنز کے لیے کور API بنائیں  
3. ورژننگ سسٹم نافذ کریں  
4. منظوری کے ورک فلو تیار کریں  
5. ٹیسٹنگ فریم ورک تیار کریں  
6. مینجمنٹ کے لیے سادہ ویب انٹرفیس بنائیں  
7. MCP سرور کے ساتھ انٹیگریٹ کریں  

**ٹیکنالوجیز:** بیک اینڈ فریم ورک، SQL یا NoSQL ڈیٹا بیس، اور فرنٹ اینڈ فریم ورک اپنی پسند کے مطابق۔

### منصوبہ 3: MCP پر مبنی مواد تخلیق کا پلیٹ فارم

**مقصد:** ایک مواد تخلیق کا پلیٹ فارم بنائیں جو MCP کا استعمال کرتے ہوئے مختلف مواد کی اقسام میں مستقل نتائج فراہم کرے۔

**ضروریات:**  
- متعدد مواد فارمیٹس کی حمایت (بلاگ پوسٹس، سوشل میڈیا، مارکیٹنگ کاپی)  
- حسب ضرورت آپشنز کے ساتھ ٹیمپلیٹ پر مبنی تخلیق نافذ کریں  
- مواد کے جائزے اور تاثرات کا نظام بنائیں  
- مواد کی کارکردگی کے میٹرکس ٹریک کریں  
- مواد کی ورژننگ اور تکرار کی حمایت کریں  

**نفاذ کے مراحل:**  
1. MCP کلائنٹ انفراسٹرکچر قائم کریں  
2. مختلف مواد کی اقسام کے لیے ٹیمپلیٹس بنائیں  
3. مواد تخلیق پائپ لائن تیار کریں  
4. جائزہ نظام نافذ کریں  
5. میٹرکس ٹریکنگ سسٹم تیار کریں  
6. ٹیمپلیٹ مینجمنٹ اور مواد تخلیق کے لیے یوزر انٹرفیس بنائیں  

**ٹیکنالوجیز:** اپنی پسند کی پروگرامنگ زبان، ویب فریم ورک، اور ڈیٹا بیس سسٹم۔

## MCP ٹیکنالوجی کے لیے مستقبل کی سمتیں

### ابھرتے ہوئے رجحانات

1. **ملٹی موڈل MCP**  
   - تصویری، آڈیو، اور ویڈیو ماڈلز کے ساتھ تعاملات کو معیاری بنانا  
   - کراس موڈل ریزننگ صلاحیتوں کی ترقی  
   - مختلف موڈالٹیز کے لیے معیاری پرامپٹ فارمیٹس  

2. **فیڈریٹڈ MCP انفراسٹرکچر**  
   - تنظیموں کے درمیان وسائل شیئر کرنے والے تقسیم شدہ MCP نیٹ ورکس  
   - محفوظ ماڈل شیئرنگ کے لیے معیاری پروٹوکولز  
   - پرائیویسی محفوظ کرنے والی کمپیوٹیشن تکنیکس  

3. **MCP مارکیٹ پلیسز**  
   - MCP ٹیمپلیٹس اور پلگ انز کے اشتراک اور منیٹائزیشن کے لیے ماحولیاتی نظام  
   - معیار کی ضمانت اور سرٹیفیکیشن کے عمل  
   - ماڈل مارکیٹ پلیسز کے ساتھ انٹیگریشن  

4. **ایج کمپیوٹنگ کے لیے MCP**  
   - محدود وسائل والے ایج ڈیوائسز کے لیے MCP معیارات کی تطبیق  
   - کم بینڈوڈتھ ماحول کے لیے بہتر پروٹوکولز  
   - IoT ماحولیاتی
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

## مشقیں

1. کیس اسٹڈیز میں سے کسی ایک کا تجزیہ کریں اور متبادل عمل درآمد کا طریقہ تجویز کریں۔  
2. منصوبے کے خیالات میں سے کسی ایک کا انتخاب کریں اور تفصیلی تکنیکی وضاحت تیار کریں۔  
3. کسی ایسے صنعت پر تحقیق کریں جو کیس اسٹڈیز میں شامل نہیں ہے اور بیان کریں کہ MCP اس کی مخصوص مشکلات کو کیسے حل کر سکتا ہے۔  
4. مستقبل کے کسی رخ کو دریافت کریں اور اسے سپورٹ کرنے کے لیے MCP کی ایک نئی توسیع کا تصور تیار کریں۔  

اگلا: [Best Practices](../08-BestPractices/README.md)

**دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا بے ضابطگیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں مستند ذریعہ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔