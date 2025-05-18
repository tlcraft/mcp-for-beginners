<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:04:47+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ur"
}
-->
# ابتدائی اپنانے والوں سے سیکھے گئے سبق

## جائزہ

یہ سبق اس بات کا جائزہ لیتا ہے کہ ابتدائی اپنانے والوں نے ماڈل کانٹیکسٹ پروٹوکول (MCP) کو کس طرح حقیقی دنیا کے چیلنجز حل کرنے اور صنعتوں میں جدت کو فروغ دینے کے لیے استعمال کیا ہے۔ تفصیلی کیس اسٹڈیز اور عملی منصوبوں کے ذریعے، آپ دیکھیں گے کہ کس طرح MCP معیاری، محفوظ، اور قابل پیمانہ AI انضمام کو فعال بناتا ہے—بڑے زبان ماڈلز، ٹولز، اور انٹرپرائز ڈیٹا کو ایک متحد فریم ورک میں جوڑتا ہے۔ آپ کو MCP پر مبنی حل ڈیزائن کرنے اور بنانے کا عملی تجربہ حاصل ہوگا، ثابت شدہ نفاذ کے نمونوں سے سیکھیں گے، اور پیداوار کے ماحول میں MCP کو تعینات کرنے کے بہترین طریقے دریافت کریں گے۔ سبق ابھرتے ہوئے رجحانات، مستقبل کی سمتوں، اور اوپن سورس وسائل کو بھی اجاگر کرتا ہے تاکہ آپ کو MCP ٹیکنالوجی اور اس کے ارتقاء پذیر ماحولیاتی نظام کے عروج پر رہنے میں مدد ملے۔

## سیکھنے کے مقاصد

- مختلف صنعتوں میں حقیقی دنیا کے MCP نفاذ کا تجزیہ کریں
- مکمل MCP پر مبنی ایپلیکیشنز ڈیزائن اور بنائیں
- MCP ٹیکنالوجی میں ابھرتے ہوئے رجحانات اور مستقبل کی سمتوں کا جائزہ لیں
- حقیقی ترقیاتی منظرناموں میں بہترین طریقوں کا اطلاق کریں

## حقیقی دنیا کے MCP نفاذ

### کیس اسٹڈی 1: انٹرپرائز کسٹمر سپورٹ آٹومیشن

ایک کثیر القومی کارپوریشن نے اپنے کسٹمر سپورٹ سسٹمز میں AI تعاملات کو معیاری بنانے کے لیے MCP پر مبنی حل نافذ کیا۔ اس سے انہیں یہ ممکن ہوا کہ:

- متعدد LLM فراہم کنندگان کے لیے ایک متحد انٹرفیس بنائیں
- محکموں میں مستقل پرامپٹ مینجمنٹ برقرار رکھیں
- مضبوط سیکیورٹی اور تعمیل کنٹرولز نافذ کریں
- مخصوص ضروریات کی بنیاد پر مختلف AI ماڈلز کے درمیان آسانی سے سوئچ کریں

**تکنیکی نفاذ:**
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

**نتائج:** ماڈل کی لاگت میں 30% کمی، ردعمل کی مستقل مزاجی میں 45% بہتری، اور عالمی آپریشنز میں بڑھتی ہوئی تعمیل۔

### کیس اسٹڈی 2: ہیلتھ کیئر ڈائیگنوسٹک اسسٹنٹ

ایک ہیلتھ کیئر فراہم کنندہ نے متعدد خصوصی طبی AI ماڈلز کو ضم کرنے کے لیے MCP انفراسٹرکچر تیار کیا جبکہ اس بات کو یقینی بنایا کہ حساس مریض کا ڈیٹا محفوظ رہے:

- جنرل اور اسپیشلسٹ میڈیکل ماڈلز کے درمیان ہموار سوئچنگ
- سخت پرائیویسی کنٹرولز اور آڈٹ ٹریلز
- موجودہ الیکٹرانک ہیلتھ ریکارڈ (EHR) سسٹمز کے ساتھ انضمام
- طبی اصطلاحات کے لیے مستقل پرامپٹ انجینئرنگ

**تکنیکی نفاذ:**
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

**نتائج:** HIPAA کی مکمل تعمیل کو برقرار رکھتے ہوئے ڈاکٹروں کے لیے تشخیصی تجاویز کو بہتر بنایا اور سسٹمز کے درمیان سیاق و سباق کی تبدیلی میں نمایاں کمی کی۔

### کیس اسٹڈی 3: مالیاتی خدمات کے خطرے کا تجزیہ

ایک مالیاتی ادارے نے مختلف محکموں میں اپنے خطرے کے تجزیہ کے عمل کو معیاری بنانے کے لیے MCP کو نافذ کیا:

- کریڈٹ رسک، فراڈ ڈیٹیکشن، اور انویسٹمنٹ رسک ماڈلز کے لیے ایک متحد انٹرفیس بنایا
- سخت رسائی کنٹرولز اور ماڈل ورژننگ کو نافذ کیا
- تمام AI سفارشات کی آڈٹ ایبلٹی کو یقینی بنایا
- متنوع نظاموں میں مستقل ڈیٹا فارمیٹنگ کو برقرار رکھا

**تکنیکی نفاذ:**
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

**نتائج:** ریگولیٹری تعمیل میں اضافہ، ماڈل کی تعیناتی کے چکروں میں 40% تیزی، اور محکموں میں خطرے کی تشخیص کی مستقل مزاجی میں بہتری۔

### کیس اسٹڈی 4: مائیکروسافٹ پلے رائٹ MCP سرور برائے براؤزر آٹومیشن

مائیکروسافٹ نے ماڈل کانٹیکسٹ پروٹوکول کے ذریعے محفوظ، معیاری براؤزر آٹومیشن کو فعال کرنے کے لیے [پلے رائٹ MCP سرور](https://github.com/microsoft/playwright-mcp) تیار کیا۔ یہ حل AI ایجنٹس اور LLMs کو ویب براؤزرز کے ساتھ ایک کنٹرول، آڈٹ ایبل، اور توسیع پذیر طریقے سے تعامل کرنے کی اجازت دیتا ہے—خودکار ویب ٹیسٹنگ، ڈیٹا نکالنے، اور اینڈ ٹو اینڈ ورک فلو جیسے استعمال کے معاملات کو فعال کرتا ہے۔

- براؤزر آٹومیشن کی صلاحیتوں (نیویگیشن، فارم بھرنا، اسکرین شاٹ کیپچر، وغیرہ) کو MCP ٹولز کے طور پر بے نقاب کرتا ہے
- غیر مجاز اقدامات کو روکنے کے لیے سخت رسائی کنٹرولز اور سینڈ باکسنگ کو نافذ کرتا ہے
- تمام براؤزر تعاملات کے لیے تفصیلی آڈٹ لاگز فراہم کرتا ہے
- ایجنٹ سے چلنے والی آٹومیشن کے لیے Azure OpenAI اور دیگر LLM فراہم کنندگان کے ساتھ انضمام کی حمایت کرتا ہے

**تکنیکی نفاذ:**
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
- ویب ایپلیکیشنز کے لیے دستی جانچ کی کوشش کو کم کیا اور ٹیسٹ کوریج کو بہتر بنایا
- انٹرپرائز ماحول میں براؤزر پر مبنی ٹول انضمام کے لیے ایک دوبارہ استعمال کے قابل، توسیع پذیر فریم ورک فراہم کیا

**حوالہ جات:**  
- [پلے رائٹ MCP سرور گٹ ہب ریپوزٹری](https://github.com/microsoft/playwright-mcp)
- [مائیکروسافٹ AI اور آٹومیشن حل](https://azure.microsoft.com/en-us/products/ai-services/)

### کیس اسٹڈی 5: Azure MCP – انٹرپرائز گریڈ ماڈل کانٹیکسٹ پروٹوکول بطور سروس

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) ماڈل کانٹیکسٹ پروٹوکول کا مائیکروسافٹ کا منظم، انٹرپرائز گریڈ نفاذ ہے، جو کلاؤڈ سروس کے طور پر قابل پیمانہ، محفوظ، اور تعمیل MCP سرور صلاحیتیں فراہم کرنے کے لیے ڈیزائن کیا گیا ہے۔ Azure MCP تنظیموں کو Azure AI، ڈیٹا، اور سیکیورٹی سروسز کے ساتھ MCP سرورز کو تیزی سے تعینات کرنے، ان کا انتظام کرنے، اور ضم کرنے کے قابل بناتا ہے، آپریشنل اوور ہیڈ کو کم کرتا ہے اور AI اپنانے کو تیز کرتا ہے۔

- بلٹ ان اسکیلنگ، مانیٹرنگ، اور سیکیورٹی کے ساتھ مکمل طور پر منظم MCP سرور ہوسٹنگ
- Azure OpenAI، Azure AI سرچ، اور دیگر Azure خدمات کے ساتھ مقامی انضمام
- Microsoft Entra ID کے ذریعے انٹرپرائز توثیق اور اجازت
- حسب ضرورت ٹولز، پرامپٹ ٹیمپلیٹس، اور وسائل کنیکٹرز کے لیے تعاون
- انٹرپرائز سیکیورٹی اور ریگولیٹری تقاضوں کی تعمیل

**تکنیکی نفاذ:**
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
- انٹرپرائز AI منصوبوں کے لیے تعمیل شدہ MCP سرور پلیٹ فارم فراہم کرکے وقت کی قدر کو کم کیا
- LLMs، ٹولز، اور انٹرپرائز ڈیٹا سورسز کے انضمام کو آسان بنایا
- MCP ورک لوڈز کے لیے سیکیورٹی، مشاہدہ، اور آپریشنل کارکردگی کو بڑھایا

**حوالہ جات:**  
- [Azure MCP دستاویزات](https://aka.ms/azmcp)
- [Azure AI سروسز](https://azure.microsoft.com/en-us/products/ai-services/)

## عملی منصوبے

### منصوبہ 1: ایک کثیر فراہم کنندہ MCP سرور بنائیں

**مقصد:** ایک MCP سرور بنائیں جو مخصوص معیارات کی بنیاد پر متعدد AI ماڈل فراہم کنندگان کو درخواستوں کو بھیج سکے۔

**ضروریات:**
- کم از کم تین مختلف ماڈل فراہم کنندگان کی حمایت کریں (مثلاً، OpenAI, Anthropic, مقامی ماڈلز)
- درخواست کے میٹا ڈیٹا کی بنیاد پر ایک روٹنگ میکانزم نافذ کریں
- فراہم کنندہ کی اسناد کے انتظام کے لیے ایک کنفیگریشن سسٹم بنائیں
- کارکردگی اور اخراجات کو بہتر بنانے کے لیے کیشنگ شامل کریں
- استعمال کی نگرانی کے لیے ایک سادہ ڈیش بورڈ بنائیں

**نفاذ کے مراحل:**
1. بنیادی MCP سرور انفراسٹرکچر قائم کریں
2. ہر AI ماڈل سروس کے لیے فراہم کنندہ ایڈاپٹرز نافذ کریں
3. درخواست کی خصوصیات کی بنیاد پر روٹنگ منطق بنائیں
4. بار بار درخواستوں کے لیے کیشنگ میکانزم شامل کریں
5. مانیٹرنگ ڈیش بورڈ تیار کریں
6. مختلف درخواست کے نمونوں کے ساتھ ٹیسٹ کریں

**ٹیکنالوجیز:** Python (.NET/Java/Python آپ کی ترجیح پر مبنی)، کیشنگ کے لیے Redis، اور ڈیش بورڈ کے لیے ایک سادہ ویب فریم ورک کا انتخاب کریں۔

### منصوبہ 2: انٹرپرائز پرامپٹ مینجمنٹ سسٹم

**مقصد:** تنظیم بھر میں پرامپٹ ٹیمپلیٹس کے انتظام، ورژننگ، اور تعیناتی کے لیے ایک MCP پر مبنی نظام تیار کریں۔

**ضروریات:**
- پرامپٹ ٹیمپلیٹس کے لیے ایک مرکزی ذخیرہ بنائیں
- ورژننگ اور منظوری کے ورک فلو کو نافذ کریں
- نمونہ ان پٹس کے ساتھ ٹیمپلیٹ ٹیسٹنگ کی صلاحیتیں بنائیں
- رول پر مبنی رسائی کنٹرولز تیار کریں
- ٹیمپلیٹ کی بازیافت اور تعیناتی کے لیے ایک API بنائیں

**نفاذ کے مراحل:**
1. ٹیمپلیٹ اسٹوریج کے لیے ڈیٹا بیس اسکیمہ ڈیزائن کریں
2. ٹیمپلیٹ CRUD آپریشنز کے لیے بنیادی API بنائیں
3. ورژننگ سسٹم کو نافذ کریں
4. منظوری کے ورک فلو کو بنائیں
5. ٹیسٹنگ فریم ورک تیار کریں
6. انتظام کے لیے ایک سادہ ویب انٹرفیس بنائیں
7. ایک MCP سرور کے ساتھ ضم کریں

**ٹیکنالوجیز:** آپ کی پسند کا بیک اینڈ فریم ورک، SQL یا NoSQL ڈیٹا بیس، اور انتظامی انٹرفیس کے لیے ایک فرنٹ اینڈ فریم ورک۔

### منصوبہ 3: MCP پر مبنی مواد کی تخلیق کا پلیٹ فارم

**مقصد:** ایک مواد تخلیق کا پلیٹ فارم بنائیں جو مختلف مواد کی اقسام میں مستقل نتائج فراہم کرنے کے لیے MCP کا فائدہ اٹھائے۔

**ضروریات:**
- متعدد مواد کی فارمیٹس کی حمایت کریں (بلاگ پوسٹس، سوشل میڈیا، مارکیٹنگ کاپی)
- حسب ضرورت اختیارات کے ساتھ ٹیمپلیٹ پر مبنی تخلیق کو نافذ کریں
- مواد کا جائزہ اور رائے کا نظام بنائیں
- مواد کی کارکردگی کے میٹرکس کو ٹریک کریں
- مواد کے ورژننگ اور تکرار کی حمایت کریں

**نفاذ کے مراحل:**
1. MCP کلائنٹ انفراسٹرکچر قائم کریں
2. مختلف مواد کی اقسام کے لیے ٹیمپلیٹس بنائیں
3. مواد کی تخلیق کی پائپ لائن بنائیں
4. جائزہ کا نظام نافذ کریں
5. میٹرکس ٹریکنگ سسٹم تیار کریں
6. ٹیمپلیٹ مینجمنٹ اور مواد کی تخلیق کے لیے صارف کا انٹرفیس بنائیں

**ٹیکنالوجیز:** آپ کی پسندیدہ پروگرامنگ زبان، ویب فریم ورک، اور ڈیٹا بیس سسٹم۔

## MCP ٹیکنالوجی کے مستقبل کی سمتیں

### ابھرتے ہوئے رجحانات

1. **ملٹی موڈل MCP**
   - تصویر، آڈیو، اور ویڈیو ماڈلز کے ساتھ تعاملات کو معیاری بنانے کے لیے MCP کی توسیع
   - کراس موڈل استدلال کی صلاحیتوں کی ترقی
   - مختلف طریقوں کے لیے معیاری پرامپٹ فارمیٹس

2. **فیڈریٹڈ MCP انفراسٹرکچر**
   - تقسیم شدہ MCP نیٹ ورکس جو وسائل کو تنظیموں کے درمیان شیئر کر سکتے ہیں
   - محفوظ ماڈل شیئرنگ کے لیے معیاری پروٹوکول
   - پرائیویسی کو محفوظ رکھنے والی کمپیوٹیشن تکنیکیں

3. **MCP مارکیٹ پلیسز**
   - MCP ٹیمپلیٹس اور پلگ انز کے اشتراک اور منیٹائز کرنے کے لیے ماحولیاتی نظام
   - کوالٹی ایشورنس اور سرٹیفیکیشن کے عمل
   - ماڈل مارکیٹ پلیسز کے ساتھ انضمام

4. **ایج کمپیوٹنگ کے لیے MCP**
   - وسائل کی رکاوٹوں والے ایج ڈیوائسز کے لیے MCP معیارات کی موافقت
   - کم بینڈوڈتھ ماحول کے لیے بہتر پروٹوکولز
   - IoT ماحولیاتی نظام کے لیے خصوصی MCP نفاذ

5. **ریگولیٹری فریم ورک**
   - ریگولیٹری تعمیل کے لیے MCP ایکسٹینشنز کی ترقی
   - معیاری آڈٹ ٹریلز اور وضاحت کے انٹرفیس
   - ابھرتے ہوئے AI گورننس فریم ورک کے ساتھ انضمام

### مائیکروسافٹ سے MCP حل

مائیکروسافٹ اور Azure نے مختلف منظرناموں میں MCP کو نافذ کرنے میں مدد کے لیے کئی اوپن سورس ریپوزٹریز تیار کی ہیں:

#### مائیکروسافٹ تنظیم
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - براؤزر آٹومیشن اور ٹیسٹنگ کے لیے ایک پلے رائٹ MCP سرور
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - مقامی جانچ اور کمیونٹی کے تعاون کے لیے OneDrive MCP سرور نفاذ

#### Azure-Samples تنظیم
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure پر متعدد زبانوں کا استعمال کرتے ہوئے MCP سرورز بنانے اور ضم کرنے کے لیے نمونے، ٹولز، اور وسائل کے لنکس
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - موجودہ ماڈل کانٹیکسٹ پروٹوکول کی وضاحت کے ساتھ توثیق کا مظاہرہ کرنے والے حوالہ MCP سرورز
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure فنکشنز میں ریموٹ MCP سرور کے نفاذ کے لیے لینڈنگ پیج جس میں زبان سے مخصوص ریپوزٹریز کے لنکس ہیں
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure فنکشنز کا استعمال کرتے ہوئے Python کے ساتھ حسب ضرورت ریموٹ MCP سرورز بنانے اور تعینات کرنے کے لیے کوئیک اسٹارٹ ٹیمپلیٹ
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Azure فنکشنز کا استعمال کرتے ہوئے .NET/C# کے ساتھ حسب ضرورت ریموٹ MCP سرورز بنانے اور تعینات کرنے کے لیے کوئیک اسٹارٹ ٹیمپلیٹ
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Azure فنکشنز کا استعمال کرتے ہوئے TypeScript کے ساتھ حسب ضرورت ریموٹ MCP سرورز بنانے اور تعینات کرنے کے لیے کوئیک اسٹارٹ ٹیمپلیٹ
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API مینجمنٹ بطور AI گیٹ وے ریموٹ MCP سرورز کے لیے Python کا استعمال کرتے ہوئے
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI تجربات بشمول MCP صلاحیتیں، Azure OpenAI اور AI Foundry کے ساتھ انضمام

یہ ریپوزٹریز مختلف پروگرامنگ زبانوں اور Azure سروسز میں ماڈل کانٹیکسٹ پروٹوکول کے ساتھ کام کرنے کے لیے مختلف نفاذ، ٹیمپلیٹس، اور وسائل فراہم کرتے ہیں۔ وہ بنیادی سرور کے نفاذ سے لے کر توثیق، کلاؤڈ تعیناتی، اور انٹرپرائز انضمام کے منظرناموں تک کے استعمال کے معاملات کا احاطہ کرتے ہیں۔

#### MCP وسائل ڈائریکٹری

سرکاری مائیکروسافٹ MCP ریپوزٹری میں [MCP وسائل ڈائریکٹری](https://github.com/microsoft/mcp/tree/main/Resources) ماڈل کانٹیکسٹ پروٹوکول سرورز کے ساتھ استعمال کے لیے نمونہ وسائل، پرامپٹ ٹیمپلیٹس، اور ٹول کی تعریفوں کا ایک تیار کردہ مجموعہ فراہم کرتی ہے۔ یہ ڈائریکٹری ڈویلپرز کو دوبارہ استعمال کے قابل بلڈنگ بلاکس اور بہترین عمل کی مثالیں پیش کرکے MCP کے ساتھ تیزی سے شروعات کرنے میں مدد کرنے کے لیے ڈیزائن کی گئی ہے:

- **پرامپٹ ٹیمپلیٹس
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## مشقیں

1. کسی ایک کیس اسٹڈی کا تجزیہ کریں اور ایک متبادل نفاذی طریقہ کار تجویز کریں۔
2. پروجیکٹ خیالات میں سے ایک کا انتخاب کریں اور ایک تفصیلی تکنیکی وضاحت تیار کریں۔
3. کسی ایسی صنعت کی تحقیق کریں جو کیس اسٹڈیز میں شامل نہ ہو اور بیان کریں کہ MCP اس کے خاص چیلنجز کو کیسے حل کر سکتا ہے۔
4. مستقبل کی سمتوں میں سے ایک کا جائزہ لیں اور اسے سپورٹ کرنے کے لئے ایک نئے MCP توسیع کا تصور تیار کریں۔

اگلا: [بہترین طریقے](../08-BestPractices/README.md)

**دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لئے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر درستیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں معتبر ذریعہ سمجھا جانا چاہئے۔ اہم معلومات کے لئے، پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔