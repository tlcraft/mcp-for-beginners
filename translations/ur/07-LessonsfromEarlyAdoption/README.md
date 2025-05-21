<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "296d5c8913271ef3bd696fd46d998711",
  "translation_date": "2025-05-20T20:29:25+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ur"
}
-->
# سبقوں سے سیکھنے والے

## جائزہ

یہ سبق اس بات کا جائزہ لیتا ہے کہ ابتدائی اپنانے والوں نے Model Context Protocol (MCP) کو کس طرح حقیقی دنیا کے مسائل حل کرنے اور صنعتوں میں جدت کو فروغ دینے کے لیے استعمال کیا ہے۔ تفصیلی کیس اسٹڈیز اور عملی منصوبوں کے ذریعے، آپ دیکھیں گے کہ MCP کس طرح معیاری، محفوظ، اور قابل توسیع AI انضمام کو ممکن بناتا ہے—جو بڑے زبان کے ماڈلز، آلات، اور کاروباری ڈیٹا کو ایک متحد فریم ورک میں جوڑتا ہے۔ آپ MCP پر مبنی حل ڈیزائن کرنے اور بنانے کا عملی تجربہ حاصل کریں گے، ثابت شدہ نفاذ کے نمونوں سے سیکھیں گے، اور پروڈکشن ماحول میں MCP تعینات کرنے کے بہترین طریقے دریافت کریں گے۔ سبق ابھرتے ہوئے رجحانات، مستقبل کی سمتوں، اور اوپن سورس وسائل کو بھی اجاگر کرتا ہے تاکہ آپ MCP ٹیکنالوجی اور اس کے ارتقائی ماحولیاتی نظام میں سبقت حاصل کر سکیں۔

## سیکھنے کے مقاصد

- مختلف صنعتوں میں حقیقی دنیا کی MCP نفاذات کا تجزیہ کریں  
- مکمل MCP پر مبنی ایپلیکیشنز ڈیزائن اور تعمیر کریں  
- MCP ٹیکنالوجی میں ابھرتے ہوئے رجحانات اور مستقبل کی سمتوں کو دریافت کریں  
- حقیقی ترقیاتی منظرناموں میں بہترین طریقے اپنائیں  

## حقیقی دنیا کی MCP نفاذات

### کیس اسٹڈی 1: انٹرپرائز کسٹمر سپورٹ آٹومیشن

ایک کثیر القومی کمپنی نے اپنے کسٹمر سپورٹ سسٹمز میں AI تعاملات کو معیاری بنانے کے لیے MCP پر مبنی حل نافذ کیا۔ اس سے وہ یہ کر سکے:  

- متعدد LLM فراہم کنندگان کے لیے ایک متحد انٹرفیس تخلیق کریں  
- مختلف شعبہ جات میں مستقل پرامپٹ مینجمنٹ برقرار رکھیں  
- مضبوط سیکیورٹی اور تعمیل کنٹرول نافذ کریں  
- مخصوص ضروریات کی بنیاد پر مختلف AI ماڈلز کے درمیان آسانی سے سوئچ کریں  

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

**نتائج:** ماڈل کی لاگت میں 30% کمی، ردعمل کی مستقل مزاجی میں 45% بہتری، اور عالمی آپریشنز میں بہتر تعمیل۔

### کیس اسٹڈی 2: صحت کی دیکھ بھال کے تشخیصی معاون

ایک صحت کی دیکھ بھال فراہم کنندہ نے متعدد مخصوص طبی AI ماڈلز کو مربوط کرنے کے لیے MCP انفراسٹرکچر تیار کیا جبکہ حساس مریض کے ڈیٹا کی حفاظت کو یقینی بنایا:  

- عام اور ماہر طبی ماڈلز کے درمیان بغیر رکاوٹ سوئچنگ  
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

**نتائج:** معالجین کے لیے بہتر تشخیصی تجاویز، مکمل HIPAA تعمیل، اور سسٹمز کے درمیان کانٹیکسٹ سوئچنگ میں نمایاں کمی۔

### کیس اسٹڈی 3: مالیاتی خدمات میں رسک تجزیہ

ایک مالیاتی ادارے نے مختلف شعبہ جات میں اپنے رسک تجزیہ کے عمل کو معیاری بنانے کے لیے MCP نافذ کیا:  

- کریڈٹ رسک، فراڈ کی شناخت، اور سرمایہ کاری کے رسک ماڈلز کے لیے متحد انٹرفیس بنایا  
- سخت رسائی کنٹرول اور ماڈل ورژننگ نافذ کی  
- تمام AI سفارشات کی آڈیٹیبلٹی کو یقینی بنایا  
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

**نتائج:** بہتر ریگولیٹری تعمیل، ماڈل تعیناتی کے چکروں میں 40% تیزی، اور شعبہ جات میں رسک اسیسمنٹ کی مستقل مزاجی۔

### کیس اسٹڈی 4: Microsoft Playwright MCP سرور براؤزر آٹومیشن کے لیے

Microsoft نے [Playwright MCP server](https://github.com/microsoft/playwright-mcp) تیار کیا تاکہ Model Context Protocol کے ذریعے محفوظ، معیاری براؤزر آٹومیشن کو فعال کیا جا سکے۔ یہ حل AI ایجنٹس اور LLMs کو ویب براؤزرز کے ساتھ کنٹرول شدہ، قابل آڈٹ، اور توسیعی انداز میں بات چیت کرنے کی اجازت دیتا ہے—جیسے خودکار ویب ٹیسٹنگ، ڈیٹا نکالنا، اور اینڈ ٹو اینڈ ورک فلو۔  

- براؤزر آٹومیشن کی صلاحیتیں (نیویگیشن، فارم بھرنا، اسکرین شاٹ، وغیرہ) MCP ٹولز کے طور پر فراہم کرتا ہے  
- غیر مجاز کارروائیوں کو روکنے کے لیے سخت رسائی کنٹرول اور سینڈباکسنگ نافذ کرتا ہے  
- تمام براؤزر تعاملات کے لیے تفصیلی آڈٹ لاگز فراہم کرتا ہے  
- Azure OpenAI اور دیگر LLM فراہم کنندگان کے ساتھ ایجنٹ پر مبنی آٹومیشن کے لیے انضمام کی حمایت کرتا ہے  

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
- دستی ٹیسٹنگ کی محنت کو کم کیا اور ویب ایپلیکیشنز کے لیے ٹیسٹ کوریج کو بہتر بنایا  
- انٹرپرائز ماحول میں براؤزر پر مبنی ٹول انضمام کے لیے ایک قابل استعمال، توسیعی فریم ورک فراہم کیا  

**References:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### کیس اسٹڈی 5: Azure MCP – انٹرپرائز گریڈ Model Context Protocol بطور سروس

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) Microsoft کا منظم، انٹرپرائز گریڈ Model Context Protocol نفاذ ہے، جو MCP سرور کی صلاحیتوں کو کلاؤڈ سروس کے طور پر قابل توسیع، محفوظ، اور تعمیلی فراہم کرنے کے لیے ڈیزائن کیا گیا ہے۔ Azure MCP تنظیموں کو MCP سرورز کو تیزی سے تعینات، منظم، اور Azure AI، ڈیٹا، اور سیکیورٹی خدمات کے ساتھ مربوط کرنے کی اجازت دیتا ہے، جس سے آپریشنل بوجھ کم ہوتا ہے اور AI اپنانے میں تیزی آتی ہے۔  

- مکمل طور پر منظم MCP سرور ہوسٹنگ، جس میں بلٹ ان اسکیلنگ، مانیٹرنگ، اور سیکیورٹی شامل ہے  
- Azure OpenAI، Azure AI Search، اور دیگر Azure خدمات کے ساتھ مقامی انضمام  
- Microsoft Entra ID کے ذریعے انٹرپرائز تصدیق اور اجازت  
- کسٹم ٹولز، پرامپٹ ٹیمپلیٹس، اور وسائل کنیکٹرز کی حمایت  
- انٹرپرائز سیکیورٹی اور ریگولیٹری ضروریات کی تعمیل  

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
- انٹرپرائز AI منصوبوں کے لیے وقت کی بچت، تیار استعمال اور تعمیلی MCP سرور پلیٹ فارم فراہم کر کے  
- LLMs، ٹولز، اور انٹرپرائز ڈیٹا ذرائع کے انضمام کو آسان بنایا  
- MCP ورک لوڈز کے لیے سیکیورٹی، مشاہدہ، اور آپریشنل کارکردگی کو بہتر بنایا  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## کیس اسٹڈی 6: NLWeb

MCP (Model Context Protocol) ایک ابھرتا ہوا پروٹوکول ہے جو چیٹ بوٹس اور AI معاونین کو ٹولز کے ساتھ بات چیت کرنے کے قابل بناتا ہے۔ ہر NLWeb انسٹینس بھی ایک MCP سرور ہے، جو ایک بنیادی طریقہ، ask، کو سپورٹ کرتا ہے، جو ویب سائٹ سے قدرتی زبان میں سوال پوچھنے کے لیے استعمال ہوتا ہے۔ موصولہ جواب schema.org کا استعمال کرتا ہے، جو ویب ڈیٹا کی وضاحت کے لیے ایک وسیع پیمانے پر استعمال ہونے والا لغت ہے۔ آسان الفاظ میں، MCP ویسے ہی ہے جیسے NLWeb HTTP کے لیے HTML ہے۔ NLWeb پروٹوکولز، Schema.org فارمیٹس، اور نمونہ کوڈ کو یکجا کرتا ہے تاکہ سائٹس کو جلدی سے یہ اینڈپوائنٹس بنانے میں مدد ملے، جو انسانی بات چیت کے انٹرفیسز اور مشینوں کے درمیان قدرتی ایجنٹ ٹو ایجنٹ تعامل دونوں کے لیے فائدہ مند ہیں۔  

NLWeb کے دو الگ الگ اجزاء ہیں:  
- ایک پروٹوکول، جو شروع میں بہت سادہ ہے، تاکہ سائٹ کے ساتھ قدرتی زبان میں بات چیت کی جا سکے اور ایک فارمیٹ، جو json اور schema.org کا استعمال کرتا ہے جواب کے لیے۔ مزید تفصیلات کے لیے REST API کی دستاویز دیکھیں۔  
- (1) کا ایک سیدھا نفاذ جو موجودہ مارک اپ کا فائدہ اٹھاتا ہے، ایسی سائٹس کے لیے جو آئٹمز کی فہرستوں (مصنوعات، ترکیبیں، سیاحتی مقامات، جائزے، وغیرہ) کے طور پر خلاصہ کی جا سکتی ہیں۔ صارف انٹرفیس وجیٹس کے سیٹ کے ساتھ، سائٹس آسانی سے اپنے مواد کے لیے بات چیت کے انٹرفیس فراہم کر سکتی ہیں۔ اس کے کام کرنے کے طریقہ کار کے لیے Life of a chat query کی دستاویز دیکھیں۔  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### کیس اسٹڈی 7: Foundry کے لیے MCP – Azure AI Agents کا انضمام

Azure AI Foundry MCP سرورز دکھاتے ہیں کہ MCP کو انٹرپرائز ماحول میں AI ایجنٹس اور ورک فلو کو منظم اور ترتیب دینے کے لیے کیسے استعمال کیا جا سکتا ہے۔ MCP کو Azure AI Foundry کے ساتھ مربوط کر کے، تنظیمیں ایجنٹ تعاملات کو معیاری بنا سکتی ہیں، Foundry کے ورک فلو مینجمنٹ کا فائدہ اٹھا سکتی ہیں، اور محفوظ، قابل توسیع تعیناتیاں یقینی بنا سکتی ہیں۔ یہ طریقہ تیز پروٹوٹائپنگ، مضبوط مانیٹرنگ، اور Azure AI خدمات کے ساتھ ہموار انضمام کو فعال کرتا ہے، جس سے علم کے انتظام اور ایجنٹ کی جانچ جیسے جدید منظرنامے ممکن ہوتے ہیں۔ ڈویلپرز کو ایجنٹ پائپ لائنز بنانے، تعینات کرنے، اور مانیٹر کرنے کے لیے ایک متحد انٹرفیس ملتا ہے، جبکہ IT ٹیمیں بہتر سیکیورٹی، تعمیل، اور آپریشنل کارکردگی حاصل کرتی ہیں۔ یہ حل ان اداروں کے لیے مثالی ہے جو AI اپنانے کو تیز کرنا چاہتے ہیں اور پیچیدہ ایجنٹ پر مبنی عمل پر کنٹرول برقرار رکھنا چاہتے ہیں۔  

**References:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### کیس اسٹڈی 8: Foundry MCP Playground – تجربات اور پروٹوٹائپنگ

Foundry MCP Playground ایک تیار استعمال ماحول فراہم کرتا ہے جہاں MCP سرورز اور Azure AI Foundry انضمامات کے ساتھ تجربات کیے جا سکتے ہیں۔ ڈویلپرز تیزی سے AI ماڈلز اور ایجنٹ ورک فلو کا پروٹوٹائپ، ٹیسٹ، اور جائزہ لے سکتے ہیں، Azure AI Foundry Catalog اور Labs کے وسائل کا استعمال کرتے ہوئے۔ یہ پلیگراؤنڈ سیٹ اپ کو آسان بناتا ہے، نمونہ منصوبے فراہم کرتا ہے، اور مشترکہ ترقی کی حمایت کرتا ہے، جس سے کم سے کم اوور ہیڈ کے ساتھ بہترین طریقوں اور نئے منظرناموں کو دریافت کرنا آسان ہو جاتا ہے۔ یہ خاص طور پر ان ٹیموں کے لیے مفید ہے جو خیالات کی توثیق، تجربات کا اشتراک، اور سیکھنے کی رفتار کو بڑھانا چاہتی ہیں بغیر پیچیدہ انفراسٹرکچر کی ضرورت کے۔ داخلے کی رکاوٹ کو کم کر کے، یہ پلیگراؤنڈ MCP اور Azure AI Foundry ماحولیاتی نظام میں جدت اور کمیونٹی تعاون کو فروغ دیتا ہے۔  

**References:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)

## عملی منصوبے

### منصوبہ 1: ملٹی-پرووائیڈر MCP سرور بنائیں

**مقصد:** ایک ایسا MCP سرور بنائیں جو مخصوص معیار کی بنیاد پر متعدد AI ماڈل فراہم کنندگان کو درخواستیں بھیج سکے۔  

**ضروریات:**  
- کم از کم تین مختلف ماڈل فراہم کنندگان کی حمایت (جیسے OpenAI، Anthropic، لوکل ماڈلز)  
- درخواست میٹا ڈیٹا کی بنیاد پر راؤٹنگ میکانزم نافذ کریں  
- فراہم کنندہ کی اسناد کے انتظام کے لیے کنفیگریشن سسٹم بنائیں  
- کارکردگی اور لاگت کو بہتر بنانے کے لیے کیشنگ شامل کریں  
- استعمال کی نگرانی کے لیے ایک سادہ ڈیش بورڈ تیار کریں  

**نفاذ کے مراحل:**  
1. بنیادی MCP سرور انفراسٹرکچر سیٹ اپ کریں  
2. ہر AI ماڈل سروس کے لیے فراہم کنندہ اڈاپٹرز نافذ کریں  
3. درخواست کی خصوصیات کی بنیاد پر راؤٹنگ لاجک بنائیں  
4. بار بار آنے والی درخواستوں کے لیے کیشنگ میکانزم شامل کریں  
5. مانیٹرنگ ڈیش بورڈ تیار کریں  
6. مختلف درخواست پیٹرنز کے ساتھ ٹیسٹ کریں  

**ٹیکنالوجیز:** Python (.NET/Java/Python آپ کی پسند کے مطابق)، Redis کیشنگ کے لیے، اور ڈیش بورڈ کے لیے سادہ ویب فریم ورک۔

### منصوبہ 2: انٹرپرائز پرامپٹ مینجمنٹ سسٹم

**مقصد:** ایک MCP پر مبنی سسٹم تیار کریں جو تنظیم بھر میں پرامپٹ ٹیمپلیٹس کے انتظام، ورژننگ، اور تعیناتی کے لیے ہو۔  

**ضروریات:**  
- پرامپٹ ٹیمپلیٹس کے لیے مرکزی مخزن بنائیں  
- ورژننگ اور منظوری کے ورک فلو نافذ کریں  
- نمونہ ان پٹس کے ساتھ ٹیمپلیٹ ٹیسٹنگ کی صلاحیتیں بنائیں  
- رول بیسڈ رسائی کنٹرول تیار کریں  
- ٹیمپلیٹ بازیافت اور تعیناتی کے لیے API بنائیں  

**نفاذ کے مراحل:**  
1. ٹیمپلیٹ اسٹوریج کے لیے ڈیٹا بیس اسکیمہ ڈیزائن کریں  
2. ٹیمپلیٹ CRUD آپریشنز کے لیے بنیادی API بنائیں  
3. ورژننگ سسٹم نافذ کریں  
4. منظوری کا ورک فلو بنائیں  
5. ٹیسٹنگ فریم ورک تیار کریں  
6. انتظام کے لیے سادہ ویب انٹرفیس بنائیں  
7. MCP سرور کے ساتھ انضمام کریں  

**ٹیکنالوجیز:** آپ کی پسند کا بیک اینڈ فریم ورک، SQL یا NoSQL ڈیٹا بیس، اور فرنٹ اینڈ فریم ورک۔

### منصوبہ 3: MCP پر مبنی مواد تخلیق کا پلیٹ فارم

**مقصد:** ایک ایسا مواد تخلیق پلیٹ فارم بنائیں جو مختلف مواد کی اقسام میں مستقل نتائج فراہم کرنے کے لیے MCP کا استعمال کرے۔  

**ضروریات:**  
- متعدد مواد کے فارمیٹس کی حمایت (بلاگ پوسٹس، سوشل میڈیا، مارکیٹنگ کاپی)  
- ٹیمپلیٹ پر مبنی تخلیق، حسب ضرورت کے اختیارات کے ساتھ  
- مواد کے جائزے اور تاثرات کا نظام بنائیں  
- مواد کی کارکردگی کے میٹرکس کو ٹریک کریں  
- مواد کی ورژننگ اور تکرار کی حمایت کریں  

**نفاذ کے مراحل:**  
1. MCP کلائنٹ انفراسٹرکچر سیٹ اپ کریں  
2. مختلف مواد کی اقسام کے لیے ٹیمپلیٹس بنائیں  
3. مواد تخلیق پائپ لائن تیار کریں  
4. جائزہ نظام نافذ کریں  
5. میٹرکس ٹریکنگ سسٹم تیار کریں  
6. ٹیمپلیٹ مینجمنٹ اور مواد تخلیق کے لیے یوزر انٹرفیس بنائیں  

**ٹیکنالوجیز:** آپ کی پسندیدہ پروگرامنگ زبان، ویب فریم ورک، اور ڈیٹا بیس سسٹم۔

## MCP ٹیکنالوجی کے لیے مستقبل کی سمتیں

### ابھرتے ہوئے رجحانات

1. **ملٹی-موڈل MCP**  
   - MCP کو تصویری، آڈیو، اور ویڈیو ماڈلز کے ساتھ تعاملات کو معیاری بنانے کے لیے وسعت دینا  
   - کراس-موڈل استدلال کی صلاحیتوں کی ترقی  
   - مختلف موڈالٹیز کے لیے معیاری پرامپٹ فارمیٹس  

2. **فیڈریٹڈ MCP انفراسٹرکچر**  
   - تنظیموں کے درمیان وسائل شیئر کرنے والے تقسیم شدہ MCP نیٹ ورکس  
   - محفوظ ماڈل شیئرنگ کے لیے معیاری پروٹوکولز  
   - پرائیویسی محفوظ کرنے والی کمپیوٹیشن تکنیکیں  

3. **MCP مارکیٹ پلیسز**  
   - MCP ٹیمپلیٹس اور پلگ انز کو شیئر اور مونیٹائز کرنے کے ماحولیاتی نظام  
   - کوالٹی اشورنس اور سرٹیفیکیشن کے عمل  
   - ماڈل مارکیٹ پلیسز کے ساتھ انضمام  

4. **ایج کمپیوٹنگ کے لیے MCP**  
   - محدود وسائل والے ایج ڈیوائسز کے لیے MCP معیارات کی تطبیق  
   - کم بینڈوڈتھ ماحول کے لیے بہتر پروٹوکولز  
   - IoT ماحولیاتی نظام کے لیے مخصوص MCP نفاذات  

5. **ریگولی
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

1. کیس اسٹڈیز میں سے کسی ایک کا تجزیہ کریں اور ایک متبادل نفاذ کا طریقہ تجویز کریں۔  
2. پروجیکٹ آئیڈیاز میں سے ایک منتخب کریں اور تفصیلی تکنیکی وضاحت تیار کریں۔  
3. کسی ایسی صنعت پر تحقیق کریں جو کیس اسٹڈیز میں شامل نہیں ہے اور بتائیں کہ MCP اس کی مخصوص مشکلات کو کیسے حل کر سکتا ہے۔  
4. مستقبل کے راستوں میں سے کسی ایک کو دریافت کریں اور اسے سپورٹ کرنے کے لیے MCP کی ایک نئی توسیع کا تصور تیار کریں۔  

Next: [Best Practices](../08-BestPractices/README.md)

**دستخطی بیان**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا کمی بیشی ہو سکتی ہے۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ذریعہ سمجھی جائے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔