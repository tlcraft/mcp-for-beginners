<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-07-14T04:10:44+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ur"
}
-->
# ابتدائی اپنانے والوں سے سبق

## جائزہ

یہ سبق اس بات کا جائزہ لیتا ہے کہ ابتدائی اپنانے والوں نے Model Context Protocol (MCP) کو کس طرح حقیقی دنیا کے مسائل حل کرنے اور صنعتوں میں جدت لانے کے لیے استعمال کیا ہے۔ تفصیلی کیس اسٹڈیز اور عملی منصوبوں کے ذریعے، آپ دیکھیں گے کہ MCP کس طرح معیاری، محفوظ، اور قابل توسیع AI انضمام کو ممکن بناتا ہے—جو بڑے زبان کے ماڈلز، ٹولز، اور ادارہ جاتی ڈیٹا کو ایک متحد فریم ورک میں جوڑتا ہے۔ آپ MCP پر مبنی حل ڈیزائن اور تعمیر کرنے کا عملی تجربہ حاصل کریں گے، ثابت شدہ نفاذ کے نمونوں سے سیکھیں گے، اور MCP کو پروڈکشن ماحول میں تعینات کرنے کے بہترین طریقے دریافت کریں گے۔ سبق میں ابھرتے ہوئے رجحانات، مستقبل کے راستے، اور اوپن سورس وسائل بھی شامل ہیں تاکہ آپ MCP ٹیکنالوجی اور اس کے بدلتے ہوئے ماحولیاتی نظام میں سبقت حاصل رکھ سکیں۔

## سیکھنے کے مقاصد

- مختلف صنعتوں میں حقیقی دنیا کی MCP نفاذات کا تجزیہ کرنا  
- مکمل MCP پر مبنی ایپلیکیشنز ڈیزائن اور تعمیر کرنا  
- MCP ٹیکنالوجی میں ابھرتے ہوئے رجحانات اور مستقبل کے راستے دریافت کرنا  
- حقیقی ترقیاتی حالات میں بہترین طریقے اپنانا  

## حقیقی دنیا کی MCP نفاذات

### کیس اسٹڈی 1: ادارہ جاتی کسٹمر سپورٹ آٹومیشن

ایک کثیر القومی کمپنی نے MCP پر مبنی حل نافذ کیا تاکہ اپنے کسٹمر سپورٹ سسٹمز میں AI تعاملات کو معیاری بنایا جا سکے۔ اس سے انہیں یہ سہولت ملی:

- متعدد LLM فراہم کنندگان کے لیے ایک متحد انٹرفیس بنانا  
- محکموں میں مستقل پرامپٹ مینجمنٹ برقرار رکھنا  
- مضبوط سیکیورٹی اور تعمیل کنٹرولز نافذ کرنا  
- مخصوص ضروریات کی بنیاد پر مختلف AI ماڈلز کے درمیان آسانی سے سوئچ کرنا  

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

**نتائج:** ماڈل کی لاگت میں 30% کمی، جواب کی مستقل مزاجی میں 45% بہتری، اور عالمی آپریشنز میں بہتر تعمیل۔

### کیس اسٹڈی 2: صحت کی دیکھ بھال کے تشخیصی معاون

ایک صحت کی دیکھ بھال فراہم کرنے والے نے MCP انفراسٹرکچر تیار کیا تاکہ متعدد تخصصی طبی AI ماڈلز کو مربوط کیا جا سکے جبکہ حساس مریض کے ڈیٹا کی حفاظت کو یقینی بنایا جا سکے:

- جنرل اور اسپیشلسٹ طبی ماڈلز کے درمیان بغیر رکاوٹ سوئچنگ  
- سخت پرائیویسی کنٹرولز اور آڈٹ ٹریلز  
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

**نتائج:** ڈاکٹروں کے لیے بہتر تشخیصی تجاویز، مکمل HIPAA تعمیل کے ساتھ، اور سسٹمز کے درمیان کانٹیکسٹ سوئچنگ میں نمایاں کمی۔

### کیس اسٹڈی 3: مالی خدمات میں رسک تجزیہ

ایک مالیاتی ادارے نے MCP کو اپنے مختلف محکموں میں رسک تجزیہ کے عمل کو معیاری بنانے کے لیے نافذ کیا:

- کریڈٹ رسک، فراڈ ڈیٹیکشن، اور سرمایہ کاری کے رسک ماڈلز کے لیے ایک متحد انٹرفیس بنایا  
- سخت رسائی کنٹرولز اور ماڈل ورژننگ نافذ کی  
- تمام AI سفارشات کی آڈٹ ایبلٹی کو یقینی بنایا  
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

**نتائج:** بہتر ریگولیٹری تعمیل، 40% تیز ماڈل تعیناتی کے چکر، اور محکموں میں رسک اسیسمنٹ کی مستقل مزاجی۔

### کیس اسٹڈی 4: Microsoft Playwright MCP سرور براؤزر آٹومیشن کے لیے

Microsoft نے [Playwright MCP server](https://github.com/microsoft/playwright-mcp) تیار کیا تاکہ Model Context Protocol کے ذریعے محفوظ، معیاری براؤزر آٹومیشن ممکن ہو سکے۔ یہ حل AI ایجنٹس اور LLMs کو ویب براؤزرز کے ساتھ کنٹرول شدہ، آڈٹ ایبل، اور توسیعی انداز میں بات چیت کرنے کی اجازت دیتا ہے—جیسے خودکار ویب ٹیسٹنگ، ڈیٹا نکالنا، اور مکمل ورک فلو۔

- براؤزر آٹومیشن کی صلاحیتوں (نیویگیشن، فارم بھرنا، اسکرین شاٹ لینا وغیرہ) کو MCP ٹولز کے طور پر پیش کرتا ہے  
- غیر مجاز کارروائیوں کو روکنے کے لیے سخت رسائی کنٹرولز اور سینڈباکسنگ نافذ کرتا ہے  
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
- AI ایجنٹس اور LLMs کے لیے محفوظ، پروگراماتی براؤزر آٹومیشن ممکن بنائی  
- دستی ٹیسٹنگ کی کوششوں میں کمی اور ویب ایپلیکیشنز کے لیے بہتر ٹیسٹ کوریج فراہم کی  
- ادارہ جاتی ماحول میں براؤزر پر مبنی ٹول انضمام کے لیے قابل استعمال، توسیعی فریم ورک مہیا کیا  

**حوالہ جات:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)  

### کیس اسٹڈی 5: Azure MCP – ادارہ جاتی معیار کا Model Context Protocol بطور سروس

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) Microsoft کی جانب سے Model Context Protocol کا ایک منظم، ادارہ جاتی معیار پر مبنی نفاذ ہے، جو کلاؤڈ سروس کے طور پر قابل توسیع، محفوظ، اور تعمیل شدہ MCP سرور کی صلاحیتیں فراہم کرتا ہے۔ Azure MCP تنظیموں کو MCP سرورز کو تیزی سے تعینات، منظم، اور Azure AI، ڈیٹا، اور سیکیورٹی خدمات کے ساتھ مربوط کرنے کی اجازت دیتا ہے، جس سے آپریشنل بوجھ کم ہوتا ہے اور AI اپنانے کی رفتار بڑھتی ہے۔

- مکمل طور پر منظم MCP سرور ہوسٹنگ، جس میں بلٹ ان اسکیلنگ، مانیٹرنگ، اور سیکیورٹی شامل ہے  
- Azure OpenAI، Azure AI Search، اور دیگر Azure خدمات کے ساتھ مقامی انضمام  
- Microsoft Entra ID کے ذریعے ادارہ جاتی توثیق اور اجازت  
- کسٹم ٹولز، پرامپٹ ٹیمپلیٹس، اور ریسورس کنیکٹرز کی حمایت  
- ادارہ جاتی سیکیورٹی اور ریگولیٹری تقاضوں کی تعمیل  

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
- ادارہ جاتی AI منصوبوں کے لیے فوری استعمال کے قابل، تعمیل شدہ MCP سرور پلیٹ فارم فراہم کر کے وقت کی بچت  
- LLMs، ٹولز، اور ادارہ جاتی ڈیٹا ذرائع کے انضمام کو آسان بنایا  
- MCP ورک لوڈز کے لیے بہتر سیکیورٹی، مشاہدہ پذیری، اور آپریشنل کارکردگی  

**حوالہ جات:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)  

## کیس اسٹڈی 6: NLWeb  
MCP (Model Context Protocol) ایک ابھرتا ہوا پروٹوکول ہے جو چیٹ بوٹس اور AI اسسٹنٹس کو ٹولز کے ساتھ بات چیت کرنے کے قابل بناتا ہے۔ ہر NLWeb انسٹینس بھی ایک MCP سرور ہے، جو ایک بنیادی طریقہ ask کو سپورٹ کرتا ہے، جس کے ذریعے ویب سائٹ سے قدرتی زبان میں سوال کیا جاتا ہے۔ موصولہ جواب schema.org کا استعمال کرتا ہے، جو ویب ڈیٹا کی وضاحت کے لیے وسیع پیمانے پر استعمال ہونے والا لغت ہے۔ آسان الفاظ میں، MCP ویسے ہی ہے جیسے NLWeb HTTP کے لیے HTML ہے۔ NLWeb پروٹوکولز، Schema.org فارمیٹس، اور نمونہ کوڈ کو یکجا کرتا ہے تاکہ سائٹس تیزی سے یہ اینڈ پوائنٹس بنا سکیں، جو انسانی صارفین کو بات چیت کے انٹرفیسز اور مشینوں کو قدرتی ایجنٹ سے ایجنٹ تعامل کے ذریعے فائدہ پہنچاتے ہیں۔

NLWeb کے دو واضح اجزاء ہیں:  
- ایک پروٹوکول، جو شروع میں بہت سادہ ہے، جو سائٹ کے ساتھ قدرتی زبان میں بات چیت کے لیے انٹرفیس فراہم کرتا ہے اور جواب کے لیے json اور schema.org کا استعمال کرتا ہے۔ REST API کی دستاویزات میں مزید تفصیلات دیکھیں۔  
- (1) کا ایک سادہ نفاذ جو موجودہ مارک اپ کا فائدہ اٹھاتا ہے، ان سائٹس کے لیے جو اشیاء کی فہرستوں (مصنوعات، ترکیبیں، سیاحتی مقامات، جائزے وغیرہ) کے طور پر خلاصہ کی جا سکتی ہیں۔ صارف انٹرفیس وجیٹس کے ساتھ، سائٹس آسانی سے اپنے مواد کے لیے بات چیت کے انٹرفیس فراہم کر سکتی ہیں۔ Life of a chat query کی دستاویزات میں اس کے کام کرنے کے طریقہ کار کی مزید تفصیلات دیکھیں۔  

**حوالہ جات:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)  

### کیس اسٹڈی 7: Foundry کے لیے MCP – Azure AI ایجنٹس کا انضمام

Azure AI Foundry MCP سرورز دکھاتے ہیں کہ MCP کو کس طرح AI ایجنٹس اور ورک فلو کو ادارہ جاتی ماحول میں منظم اور مربوط کرنے کے لیے استعمال کیا جا سکتا ہے۔ MCP کو Azure AI Foundry کے ساتھ مربوط کر کے، تنظیمیں ایجنٹ تعاملات کو معیاری بنا سکتی ہیں، Foundry کے ورک فلو مینجمنٹ کا فائدہ اٹھا سکتی ہیں، اور محفوظ، قابل توسیع تعیناتی کو یقینی بنا سکتی ہیں۔ یہ طریقہ تیز پروٹوٹائپنگ، مضبوط مانیٹرنگ، اور Azure AI خدمات کے ساتھ ہموار انضمام کو ممکن بناتا ہے، اور علم کے انتظام اور ایجنٹ کی تشخیص جیسے جدید منظرناموں کی حمایت کرتا ہے۔ ڈویلپرز کو ایجنٹ پائپ لائنز بنانے، تعینات کرنے، اور مانیٹر کرنے کے لیے ایک متحد انٹرفیس ملتا ہے، جبکہ IT ٹیموں کو بہتر سیکیورٹی، تعمیل، اور آپریشنل کارکردگی حاصل ہوتی ہے۔ یہ حل ان اداروں کے لیے مثالی ہے جو AI اپنانے کی رفتار بڑھانا چاہتے ہیں اور پیچیدہ ایجنٹ پر مبنی عمل پر کنٹرول برقرار رکھنا چاہتے ہیں۔

**حوالہ جات:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  

### کیس اسٹڈی 8: Foundry MCP Playground – تجربہ اور پروٹوٹائپنگ

Foundry MCP Playground ایک تیار استعمال ماحول فراہم کرتا ہے جہاں MCP سرورز اور Azure AI Foundry انضمامات کے ساتھ تجربہ کیا جا سکتا ہے۔ ڈویلپرز تیزی سے AI ماڈلز اور ایجنٹ ورک فلو کی پروٹوٹائپنگ، جانچ، اور تشخیص کر سکتے ہیں، Azure AI Foundry کیٹلاگ اور لیبز کے وسائل کا استعمال کرتے ہوئے۔ یہ پلیگراونڈ سیٹ اپ کو آسان بناتا ہے، نمونہ منصوبے فراہم کرتا ہے، اور مشترکہ ترقی کی حمایت کرتا ہے، جس سے کم سے کم بوجھ کے ساتھ بہترین طریقے اور نئے منظرنامے دریافت کرنا آسان ہو جاتا ہے۔ یہ خاص طور پر ان ٹیموں کے لیے مفید ہے جو خیالات کی تصدیق، تجربات کا اشتراک، اور سیکھنے کی رفتار بڑھانا چاہتی ہیں بغیر پیچیدہ انفراسٹرکچر کی ضرورت کے۔ رکاوٹوں کو کم کر کے، یہ پلیگراونڈ MCP اور Azure AI Foundry کے ماحولیاتی نظام میں جدت اور کمیونٹی تعاون کو فروغ دیتا ہے۔

**حوالہ جات:**  
- [Foundry MCP Playground GitHub Repository](https://github.com/azure-ai-foundry/foundry-mcp-playground)  

### کیس اسٹڈی 9: Microsoft Docs MCP Server - سیکھنا اور مہارت حاصل کرنا

Microsoft Docs MCP Server Model Context Protocol (MCP) سرور کو نافذ کرتا ہے جو AI اسسٹنٹس کو Microsoft کی سرکاری دستاویزات تک حقیقی وقت میں رسائی فراہم کرتا ہے۔ یہ Microsoft کی سرکاری تکنیکی دستاویزات کے خلاف معنوی تلاش انجام دیتا ہے۔

**حوالہ جات:**  
- [Microsoft Learn Docs MCP Server](https://github.com/MicrosoftDocs/mcp)  

## عملی منصوبے

### منصوبہ 1: ملٹی-پرووائیڈر MCP سرور بنائیں

**مقصد:** ایک MCP سرور بنائیں جو مخصوص معیار کی بنیاد پر متعدد AI ماڈل فراہم کنندگان کو درخواستیں بھیج سکے۔

**ضروریات:**  
- کم از کم تین مختلف ماڈل فراہم کنندگان کی حمایت (مثلاً OpenAI، Anthropic، مقامی ماڈلز)  
- درخواست کے میٹا ڈیٹا کی بنیاد پر روٹنگ میکانزم نافذ کریں  
- فراہم کنندہ کی اسناد کے انتظام کے لیے کنفیگریشن سسٹم بنائیں  
- کارکردگی اور لاگت کو بہتر بنانے کے لیے کیشنگ شامل کریں  
- استعمال کی نگرانی کے لیے ایک سادہ ڈیش بورڈ تیار کریں  

**نفاذ کے مراحل:**  
1. بنیادی MCP سرور انفراسٹرکچر قائم کریں  
2. ہر AI ماڈل سروس کے لیے فراہم کنندہ ایڈاپٹرز نافذ کریں  
3. درخواست کی خصوصیات کی بنیاد پر روٹنگ لاجک بنائیں  
4. بار بار آنے والی درخواستوں کے لیے کیشنگ میکانزم شامل کریں  
5. مانیٹرنگ ڈیش بورڈ تیار کریں  
6. مختلف درخواست کے نمونوں کے ساتھ ٹیسٹ کریں  

**ٹیکنالوجیز:** Python (.NET/Java/Python آپ کی پسند کے مطابق)، Redis کیشنگ کے لیے، اور ڈیش بورڈ کے لیے ایک سادہ ویب فریم ورک۔

### منصوبہ 2: ادارہ جاتی پرامپٹ مینجمنٹ سسٹم

**مقصد:** ایک MCP پر مبنی نظام تیار کریں جو تنظیم بھر میں پرامپٹ ٹیمپلیٹس کا انتظام، ورژننگ، اور تعیناتی کرے۔

**ضروریات:**  
- پرامپٹ ٹیمپلیٹس کے لیے مرکزی ذخیرہ بنائیں  
- ورژننگ اور منظوری کے ورک فلو نافذ کریں  
- نمونہ ان پٹس کے ساتھ ٹیمپلیٹ ٹیسٹنگ کی صلاحیتیں بنائیں  
- کردار کی بنیاد پر رسائی کنٹرولز تیار کریں  
- ٹیمپلیٹ بازیافت اور تعیناتی کے لیے API بنائیں  

**نفاذ کے مراحل:**  
1. ٹیمپلیٹ اسٹوریج کے لیے ڈیٹا بیس اسکیمہ ڈیزائن کریں  
2. ٹیمپلیٹ CRUD آپریشنز کے لیے بنیادی API بنائیں  
3. ورژننگ سسٹم نافذ کریں  
4. منظوری کے ورک فلو تیار کریں  
5. ٹیسٹنگ فریم ورک تیار کریں  
6. انتظام کے لیے ایک سادہ ویب انٹرفیس بنائیں  
7. MCP سرور کے ساتھ انضمام کریں  

**ٹیکنالوجیز:** آپ کی پسند کا بیک اینڈ فریم ورک، SQL یا NoSQL ڈیٹا بیس، اور انتظامی انٹرفیس کے لیے فرنٹ اینڈ فریم ورک۔

### منصوبہ 3: MCP پر مبنی مواد تخلیق کا پلیٹ فارم

**مقصد:** ایک ایسا مواد تخلیق پلیٹ فارم بنائیں جو مختلف مواد کی اقسام میں مستقل نتائج فراہم کرنے کے لیے MCP کا استعمال کرے۔

**ضروریات:**  
- متعدد مواد کے فارمیٹس کی حمایت (بلاگ پوسٹس، سوشل میڈیا، مارکیٹنگ کاپی)  
- ٹیمپلیٹ پر مبنی تخلیق، حسب ضرورت اختیارات کے ساتھ  
- مواد کا جائزہ اور تاثرات کا نظام بنائیں  
- مواد کی کارکردگی کے میٹرکس کو ٹریک کریں  
- مواد کی ورژننگ اور تکرار کی حمایت کریں  

**نفاذ کے مراحل:**  
1. MCP کلائنٹ انفراسٹرکچر قائم کریں  
2. مختلف مواد کی اقسام کے لیے ٹیمپلیٹس بنائیں  
3. مواد تخلیق کی پائپ لائن تیار کریں  
4. جائزہ نظام نافذ کریں  
5. میٹرکس ٹریکنگ سسٹم تیار کریں  
6. ٹیمپلیٹ مینجمنٹ اور مواد تخلیق کے لیے یوزر انٹرفیس بنائیں  

**ٹیکنالوجیز:** آپ کی پسند کی پروگرامنگ زبان، ویب فریم ورک، اور ڈیٹا بیس سسٹم۔

## MCP ٹیکنالوجی کے لیے مستقبل کے راستے

### ابھرتے ہوئے رجحانات

1. **ملٹی-موڈل MCP**  
   - تصویر، آڈیو، اور ویڈیو ماڈلز کے ساتھ تعاملات کو معیاری بنانا  
   - کراس-موڈل استدلال کی صلاحیتوں کی ترقی  
   - مختلف موڈالٹیز کے لیے معیاری پرامپٹ فارمیٹس  

2. **فیڈریٹڈ MCP انفراسٹرکچر**  
   - تنظیموں کے درمیان وسائل کے اشتراک کے لیے تقسیم شدہ MCP نیٹ ورکس  
   - محفوظ ماڈل شیئرنگ کے لیے معیاری پروٹوکولز  
   - پرائیویسی محفوظ کرنے والی کمپیوٹیشن تکنیکیں  

3. **MCP مارکیٹ پلیسز**  
   - MCP ٹیمپلیٹس اور پلگ انز کے اشتراک اور منیٹائزیشن کے لیے ماحولیاتی
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions میں Remote MCP Server کی تنصیبات کے لیے لینڈنگ پیج، زبان مخصوص ریپوز کے لنکس کے ساتھ  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python کے ساتھ Azure Functions استعمال کرتے ہوئے کسٹم remote MCP سرور بنانے اور تعینات کرنے کے لیے فوری آغاز کا ٹیمپلیٹ  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - .NET/C# کے ساتھ Azure Functions استعمال کرتے ہوئے کسٹم remote MCP سرور بنانے اور تعینات کرنے کے لیے فوری آغاز کا ٹیمپلیٹ  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - TypeScript کے ساتھ Azure Functions استعمال کرتے ہوئے کسٹم remote MCP سرور بنانے اور تعینات کرنے کے لیے فوری آغاز کا ٹیمپلیٹ  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Python استعمال کرتے ہوئے Remote MCP سرورز کے لیے Azure API Management کو AI گیٹ وے کے طور پر استعمال کرنا  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI تجربات بشمول MCP صلاحیتیں، Azure OpenAI اور AI Foundry کے ساتھ انضمام  

یہ ریپوز مختلف پروگرامنگ زبانوں اور Azure سروسز میں Model Context Protocol کے ساتھ کام کرنے کے لیے مختلف تنصیبات، ٹیمپلیٹس، اور وسائل فراہم کرتے ہیں۔ یہ بنیادی سرور تنصیبات سے لے کر توثیق، کلاؤڈ تعیناتی، اور انٹرپرائز انضمام کے مختلف استعمال کے کیسز کو کور کرتے ہیں۔  

#### MCP Resources Directory  

[مائیکروسافٹ کے سرکاری MCP ریپوز میں MCP Resources ڈائریکٹری](https://github.com/microsoft/mcp/tree/main/Resources) ایک منتخب شدہ مجموعہ فراہم کرتی ہے جس میں نمونہ وسائل، پرامپٹ ٹیمپلیٹس، اور ٹول کی تعریفیں شامل ہیں جو Model Context Protocol سرورز کے ساتھ استعمال کے لیے ہیں۔ یہ ڈائریکٹری ڈویلپرز کو MCP کے ساتھ جلدی شروع کرنے میں مدد دیتی ہے، قابلِ استعمال اجزاء اور بہترین طریقہ کار کی مثالیں فراہم کرکے:  

- **Prompt Templates:** عام AI کاموں اور منظرناموں کے لیے تیار شدہ پرامپٹ ٹیمپلیٹس، جنہیں آپ اپنے MCP سرور کی تنصیبات کے لیے ڈھالا جا سکتا ہے۔  
- **Tool Definitions:** مختلف MCP سرورز میں ٹول انضمام اور کال کو معیاری بنانے کے لیے مثال کے طور پر ٹول اسکیمے اور میٹا ڈیٹا۔  
- **Resource Samples:** MCP فریم ورک کے اندر ڈیٹا ذرائع، APIs، اور بیرونی خدمات سے کنکشن کے لیے مثال کے طور پر وسائل کی تعریفیں۔  
- **Reference Implementations:** عملی نمونے جو دکھاتے ہیں کہ حقیقی دنیا کے MCP پروجیکٹس میں وسائل، پرامپٹس، اور ٹولز کو کیسے منظم اور ترتیب دیا جائے۔  

یہ وسائل ترقی کو تیز کرتے ہیں، معیاری بنانے کو فروغ دیتے ہیں، اور MCP پر مبنی حل بنانے اور تعینات کرنے میں بہترین طریقہ کار کو یقینی بناتے ہیں۔  

#### MCP Resources Directory  
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  

### تحقیق کے مواقع  

- MCP فریم ورکس میں مؤثر پرامپٹ آپٹیمائزیشن تکنیکیں  
- ملٹی ٹیننٹ MCP تعیناتیوں کے لیے سیکیورٹی ماڈلز  
- مختلف MCP تنصیبات کے درمیان کارکردگی کی جانچ  
- MCP سرورز کے لیے رسمی تصدیقی طریقے  

## نتیجہ  

Model Context Protocol (MCP) تیزی سے صنعتوں میں معیاری، محفوظ، اور باہم مربوط AI انضمام کے مستقبل کی تشکیل دے رہا ہے۔ اس سبق میں کیس اسٹڈیز اور عملی منصوبوں کے ذریعے، آپ نے دیکھا کہ ابتدائی اپنانے والے—جیسے کہ Microsoft اور Azure—MCP کو حقیقی دنیا کے چیلنجز حل کرنے، AI اپنانے کو تیز کرنے، اور تعمیل، سیکیورٹی، اور توسیع پذیری کو یقینی بنانے کے لیے کیسے استعمال کر رہے ہیں۔ MCP کا ماڈیولر طریقہ کار تنظیموں کو بڑے زبان ماڈلز، ٹولز، اور انٹرپرائز ڈیٹا کو ایک متحد، قابلِ جانچ فریم ورک میں جوڑنے کے قابل بناتا ہے۔ جیسے جیسے MCP ترقی کرتا رہے گا، کمیونٹی کے ساتھ جڑے رہنا، اوپن سورس وسائل کو دریافت کرنا، اور بہترین طریقہ کار اپنانا مضبوط اور مستقبل کے لیے تیار AI حل بنانے کی کلید ہوگا۔  

## اضافی وسائل  

- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Foundry MCP Playground](https://github.com/azure-ai-foundry/foundry-mcp-playground)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)  
- [MCP GitHub Repository (Microsoft)](https://github.com/microsoft/mcp)  
- [MCP Resources Directory (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)  
- [MCP Community & Documentation](https://modelcontextprotocol.io/introduction)  
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

1. کیس اسٹڈی میں سے کسی ایک کا تجزیہ کریں اور متبادل تنصیب کا طریقہ تجویز کریں۔  
2. کسی ایک پروجیکٹ آئیڈیا کا انتخاب کریں اور تفصیلی تکنیکی وضاحت تیار کریں۔  
3. ایسی صنعت پر تحقیق کریں جو کیس اسٹڈیز میں شامل نہیں ہے اور بیان کریں کہ MCP اس کی مخصوص مشکلات کو کیسے حل کر سکتا ہے۔  
4. مستقبل کے کسی ایک رخ کو دریافت کریں اور اسے سپورٹ کرنے کے لیے MCP کی نئی توسیع کا تصور تیار کریں۔  

اگلا: [Best Practices](../08-BestPractices/README.md)

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔