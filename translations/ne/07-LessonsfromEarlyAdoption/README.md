<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:13:22+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ne"
}
-->
# प्रारम्भिक अपनाउनेहरूबाट सिकाइ

## अवलोकन

यस पाठले कसरी प्रारम्भिक अपनाउनेहरूले मोडेल सन्दर्भ प्रोटोकल (MCP) लाई वास्तविक-विश्व चुनौतीहरू समाधान गर्न र उद्योगहरूमा नवप्रवर्तनलाई अघि बढाउन प्रयोग गरेका छन् भन्ने अन्वेषण गर्दछ। विस्तृत केस अध्ययनहरू र व्यावहारिक परियोजनाहरू मार्फत, तपाईले देख्नुहुनेछ कि MCP ले कसरी ठूला भाषा मोडेलहरू, उपकरणहरू, र उद्यम डाटालाई एकीकृत फ्रेमवर्कमा जोड्ने मानकीकृत, सुरक्षित, र स्केलेबल AI एकीकरण सक्षम गर्दछ। तपाईले MCP-आधारित समाधानहरू डिजाइन र निर्माण गर्ने व्यावहारिक अनुभव प्राप्त गर्नुहुनेछ, प्रमाणित कार्यान्वयन ढाँचाहरूबाट सिक्नुहुनेछ, र उत्पादन वातावरणमा MCP तैनाथ गर्नको लागि उत्तम अभ्यासहरू पत्ता लगाउनुहुनेछ। पाठले नयाँ प्रवृत्तिहरू, भविष्यको दिशा, र खुला-स्रोत स्रोतहरूलाई पनि उजागर गर्दछ जसले तपाइँलाई MCP प्रविधि र यसको विकासशील पारिस्थितिकी तन्त्रको अग्रभागमा रहन मद्दत गर्दछ।

## सिकाइ उद्देश्यहरू

- विभिन्न उद्योगहरूमा वास्तविक-विश्व MCP कार्यान्वयनहरूको विश्लेषण गर्नुहोस्
- पूर्ण MCP-आधारित अनुप्रयोगहरू डिजाइन र निर्माण गर्नुहोस्
- MCP प्रविधिमा नयाँ प्रवृत्तिहरू र भविष्यको दिशाहरू अन्वेषण गर्नुहोस्
- वास्तविक विकास परिदृश्यहरूमा उत्तम अभ्यासहरू लागू गर्नुहोस्

## वास्तविक-विश्व MCP कार्यान्वयनहरू

### केस अध्ययन 1: उद्यम ग्राहक समर्थन स्वचालन

एक बहुराष्ट्रिय निगमले आफ्नो ग्राहक समर्थन प्रणालीहरूमा AI अन्तरक्रियाहरूलाई मानकीकृत गर्न MCP-आधारित समाधान कार्यान्वयन गर्‍यो। यसले उनीहरूलाई निम्न गर्न अनुमति दियो:

- धेरै LLM प्रदायकहरूको लागि एकीकृत इन्टरफेस सिर्जना गर्नुहोस्
- विभागहरूमा लगातार प्रॉम्प्ट व्यवस्थापन कायम राख्नुहोस्
- बलियो सुरक्षा र अनुपालन नियन्त्रणहरू कार्यान्वयन गर्नुहोस्
- विशेष आवश्यकताहरूको आधारमा विभिन्न AI मोडेलहरू बीच सजिलै स्विच गर्नुहोस्

**प्राविधिक कार्यान्वयन:**
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

**परिणामहरू:** मोडेल लागतमा 30% कमी, प्रतिक्रिया स्थिरतामा 45% सुधार, र विश्वव्यापी अपरेसनहरूमा बढ्दो अनुपालन।

### केस अध्ययन 2: स्वास्थ्य सेवा निदान सहायक

एक स्वास्थ्य सेवा प्रदायकले संवेदनशील बिरामी डेटा सुरक्षित रहँदा धेरै विशेष चिकित्सा AI मोडेलहरू एकीकृत गर्न MCP पूर्वाधार विकास गर्‍यो:

- सामान्य र विशेषज्ञ चिकित्सा मोडेलहरू बीच सहज स्विचिङ
- कडा गोपनीयता नियन्त्रण र अडिट ट्रेलहरू
- विद्यमान इलेक्ट्रोनिक हेल्थ रेकर्ड (EHR) प्रणालीहरूसँग एकीकरण
- चिकित्सा शब्दावलीको लागि स्थिर प्रॉम्प्ट इन्जिनियरिङ

**प्राविधिक कार्यान्वयन:**
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

**परिणामहरू:** चिकित्सकहरूको लागि सुधारिएको निदान सुझावहरू पूर्ण HIPAA अनुपालन कायम राख्दै र प्रणालीहरू बीचको सन्दर्भ-स्विचिङमा महत्त्वपूर्ण कमी।

### केस अध्ययन 3: वित्तीय सेवाहरू जोखिम विश्लेषण

एक वित्तीय संस्थाले विभिन्न विभागहरूमा आफ्नो जोखिम विश्लेषण प्रक्रियाहरूलाई मानकीकृत गर्न MCP कार्यान्वयन गर्‍यो:

- क्रेडिट जोखिम, ठगी पत्ता लगाउने, र लगानी जोखिम मोडेलहरूको लागि एकीकृत इन्टरफेस सिर्जना गरियो
- कडा पहुँच नियन्त्रण र मोडेल संस्करण कार्यान्वयन गरियो
- सबै AI सिफारिसहरूको अडिटबिलिटी सुनिश्चित गरियो
- विविध प्रणालीहरूमा लगातार डेटा स्वरूपण कायम राखियो

**प्राविधिक कार्यान्वयन:**
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

**परिणामहरू:** बढ्दो नियामक अनुपालन, मोडेल परिनियोजन चक्रहरू 40% छिटो, र विभागहरूमा जोखिम मूल्याङ्कन स्थिरता सुधारियो।

### केस अध्ययन 4: ब्राउजर स्वचालनको लागि माइक्रोसफ्ट प्लेवाइट MCP सर्भर

माइक्रोसफ्टले मोडेल सन्दर्भ प्रोटोकल मार्फत सुरक्षित, मानकीकृत ब्राउजर स्वचालन सक्षम गर्न [प्लेवाइट MCP सर्भर](https://github.com/microsoft/playwright-mcp) विकास गर्‍यो। यस समाधानले AI एजेन्टहरू र LLMs लाई वेब ब्राउजरहरूसँग नियन्त्रित, अडिटयोग्य, र विस्तारयोग्य तरिकामा अन्तरक्रिया गर्न अनुमति दिन्छ - स्वचालित वेब परीक्षण, डेटा निष्कर्षण, र अन्त्य-देखि-अन्त्य वर्कफ्लोहरू जस्ता प्रयोगका केसहरू सक्षम गर्दै।

- ब्राउजर स्वचालन क्षमताहरू (नेभिगेसन, फारम भर्नु, स्क्रिनसट क्याप्चर, आदि) MCP उपकरणको रूपमा उजागर गर्दछ
- अनधिकृत कार्यहरू रोक्न कडा पहुँच नियन्त्रण र स्यान्डबक्सिङ कार्यान्वयन गर्दछ
- सबै ब्राउजर अन्तरक्रियाहरूको लागि विस्तृत अडिट लगहरू प्रदान गर्दछ
- एजेन्ट-चालित स्वचालनको लागि Azure OpenAI र अन्य LLM प्रदायकहरूसँग एकीकरणलाई समर्थन गर्दछ

**प्राविधिक कार्यान्वयन:**
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

**परिणामहरू:**  
- AI एजेन्टहरू र LLMs का लागि सुरक्षित, प्रोग्रामेटिक ब्राउजर स्वचालन सक्षम गरियो
- म्यानुअल परीक्षण प्रयास कम गरियो र वेब अनुप्रयोगहरूको लागि परीक्षण कभरेज सुधार गरियो
- उद्यम वातावरणमा ब्राउजर-आधारित उपकरण एकीकरणको लागि पुन: प्रयोग गर्न मिल्ने, विस्तारयोग्य फ्रेमवर्क प्रदान गरियो

**सन्दर्भहरू:**  
- [प्लेवाइट MCP सर्भर GitHub रिपोजिटरी](https://github.com/microsoft/playwright-mcp)
- [माइक्रोसफ्ट AI र स्वचालन समाधानहरू](https://azure.microsoft.com/en-us/products/ai-services/)

### केस अध्ययन 5: Azure MCP – सेवा रूपमा उद्यम-ग्रेड मोडेल सन्दर्भ प्रोटोकल

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) माइक्रोसफ्टको व्यवस्थापित, उद्यम-ग्रेड मोडेल सन्दर्भ प्रोटोकलको कार्यान्वयन हो, जुन क्लाउड सेवाको रूपमा स्केलेबल, सुरक्षित, र अनुपालन MCP सर्भर क्षमताहरू प्रदान गर्न डिजाइन गरिएको हो। Azure MCP ले संगठनहरूलाई MCP सर्भरहरूलाई Azure AI, डेटा, र सुरक्षा सेवाहरूसँग छिटो तैनाथ, व्यवस्थापन, र एकीकृत गर्न सक्षम बनाउँछ, अपरेशनल ओभरहेड घटाउँछ र AI अपनाउनेलाई गति दिन्छ।

- बिल्ट-इन स्केलिङ, अनुगमन, र सुरक्षासँग पूर्ण रूपमा व्यवस्थापित MCP सर्भर होस्टिङ
- Azure OpenAI, Azure AI खोज, र अन्य Azure सेवाहरूसँग देशी एकीकरण
- माइक्रोसफ्ट Entra ID मार्फत उद्यम प्रमाणीकरण र अधिकार
- कस्टम उपकरणहरू, प्रॉम्प्ट टेम्प्लेटहरू, र संसाधन कनेक्टरहरूको लागि समर्थन
- उद्यम सुरक्षा र नियामक आवश्यकताहरूको अनुपालन

**प्राविधिक कार्यान्वयन:**
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

**परिणामहरू:**  
- उद्यम AI परियोजनाहरूको लागि मूल्य-समय कम गरियो, तयार-प्रयोग, अनुपालन MCP सर्भर प्लेटफर्म प्रदान गरेर
- LLMs, उपकरणहरू, र उद्यम डेटा स्रोतहरूको एकीकरण सरल बनाइयो
- MCP कार्यभारहरूको लागि बढ्दो सुरक्षा, अवलोकनीयता, र अपरेशनल दक्षता

**सन्दर्भहरू:**  
- [Azure MCP प्रलेखन](https://aka.ms/azmcp)
- [Azure AI सेवाहरू](https://azure.microsoft.com/en-us/products/ai-services/)

## व्यावहारिक परियोजनाहरू

### परियोजना 1: बहु-प्रदायक MCP सर्भर निर्माण गर्नुहोस्

**उद्देश्य:** विशिष्ट मापदण्डको आधारमा अनुरोधहरूलाई बहु AI मोडेल प्रदायकहरूमा मार्ग दिन सक्ने MCP सर्भर सिर्जना गर्नुहोस्।

**आवश्यकताहरू:**
- कम्तीमा तीन फरक मोडेल प्रदायकहरू (जस्तै, OpenAI, Anthropic, स्थानीय मोडेलहरू) को समर्थन गर्नुहोस्
- अनुरोध मेटाडाटाको आधारमा रुटिङ मेकानिज्म कार्यान्वयन गर्नुहोस्
- प्रदायक प्रमाणहरू व्यवस्थापन गर्न कन्फिगरेसन प्रणाली सिर्जना गर्नुहोस्
- प्रदर्शन र लागतहरू अनुकूलन गर्न क्यासिङ थप्नुहोस्
- प्रयोगको निगरानी गर्न सरल ड्यासबोर्ड निर्माण गर्नुहोस्

**कार्यान्वयन चरणहरू:**
1. आधारभूत MCP सर्भर पूर्वाधार सेट अप गर्नुहोस्
2. प्रत्येक AI मोडेल सेवाको लागि प्रदायक एडाप्टरहरू कार्यान्वयन गर्नुहोस्
3. अनुरोध विशेषताहरूको आधारमा रुटिङ तर्क सिर्जना गर्नुहोस्
4. बारम्बार अनुरोधहरूको लागि क्यासिङ संयन्त्रहरू थप्नुहोस्
5. निगरानी ड्यासबोर्ड विकास गर्नुहोस्
6. विभिन्न अनुरोध ढाँचाहरूसँग परीक्षण गर्नुहोस्

**प्रविधिहरू:** Python (.NET/Java/Python तपाईको प्राथमिकतामा आधारित) बाट छनोट गर्नुहोस्, क्यासिङको लागि Redis, र ड्यासबोर्डको लागि सरल वेब फ्रेमवर्क।

### परियोजना 2: उद्यम प्रॉम्प्ट व्यवस्थापन प्रणाली

**उद्देश्य:** संगठनभरि प्रॉम्प्ट टेम्प्लेटहरू व्यवस्थापन, संस्करण, र तैनाथ गर्नको लागि MCP-आधारित प्रणाली विकास गर्नुहोस्।

**आवश्यकताहरू:**
- प्रॉम्प्ट टेम्प्लेटहरूको लागि केन्द्रीय भण्डार सिर्जना गर्नुहोस्
- संस्करण र स्वीकृति कार्यप्रवाहहरू कार्यान्वयन गर्नुहोस्
- नमूना इनपुटहरूसँग टेम्प्लेट परीक्षण क्षमताहरू निर्माण गर्नुहोस्
- भूमिका-आधारित पहुँच नियन्त्रणहरू विकास गर्नुहोस्
- टेम्प्लेट पुनःप्राप्ति र तैनातीको लागि API सिर्जना गर्नुहोस्

**कार्यान्वयन चरणहरू:**
1. टेम्प्लेट भण्डारणको लागि डेटाबेस स्कीमा डिजाइन गर्नुहोस्
2. टेम्प्लेट CRUD अपरेसनहरूको लागि कोर API सिर्जना गर्नुहोस्
3. संस्करण प्रणाली कार्यान्वयन गर्नुहोस्
4. स्वीकृति कार्यप्रवाह निर्माण गर्नुहोस्
5. परीक्षण फ्रेमवर्क विकास गर्नुहोस्
6. व्यवस्थापनको लागि सरल वेब इन्टरफेस सिर्जना गर्नुहोस्
7. MCP सर्भरसँग एकीकृत गर्नुहोस्

**प्रविधिहरू:** तपाईको छनोटको ब्याकएन्ड फ्रेमवर्क, SQL वा NoSQL डेटाबेस, र व्यवस्थापन इन्टरफेसको लागि फ्रन्टएन्ड फ्रेमवर्क।

### परियोजना 3: MCP-आधारित सामग्री उत्पादन प्लेटफर्म

**उद्देश्य:** विभिन्न सामग्री प्रकारहरूमा स्थिर परिणामहरू प्रदान गर्न MCP प्रयोग गर्ने सामग्री उत्पादन प्लेटफर्म निर्माण गर्नुहोस्।

**आवश्यकताहरू:**
- धेरै सामग्री ढाँचाहरू (ब्लग पोस्टहरू, सामाजिक मिडिया, मार्केटिङ प्रतिलिपि) को समर्थन गर्नुहोस्
- अनुकूलन विकल्पहरूसँग टेम्प्लेट-आधारित उत्पादन कार्यान्वयन गर्नुहोस्
- सामग्री समीक्षा र प्रतिक्रिया प्रणाली सिर्जना गर्नुहोस्
- सामग्री प्रदर्शन मेट्रिक्स ट्र्याक गर्नुहोस्
- सामग्री संस्करण र पुनरावृत्तिको समर्थन गर्नुहोस्

**कार्यान्वयन चरणहरू:**
1. MCP ग्राहक पूर्वाधार सेट अप गर्नुहोस्
2. विभिन्न सामग्री प्रकारहरूको लागि टेम्प्लेटहरू सिर्जना गर्नुहोस्
3. सामग्री उत्पादन पाइपलाइन निर्माण गर्नुहोस्
4. समीक्षा प्रणाली कार्यान्वयन गर्नुहोस्
5. मेट्रिक्स ट्र्याकिङ प्रणाली विकास गर्नुहोस्
6. टेम्प्लेट व्यवस्थापन र सामग्री उत्पादनको लागि प्रयोगकर्ता इन्टरफेस सिर्जना गर्नुहोस्

**प्रविधिहरू:** तपाईको मनपर्ने प्रोग्रामिङ भाषा, वेब फ्रेमवर्क, र डेटाबेस प्रणाली।

## MCP प्रविधिको भविष्यको दिशा

### नयाँ प्रवृत्तिहरू

1. **मल्टि-मोडल MCP**
   - छवि, अडियो, र भिडियो मोडेलहरूसँग अन्तरक्रियालाई मानकीकृत गर्न MCP को विस्तार
   - क्रस-मोडल तर्क क्षमताहरूको विकास
   - विभिन्न मोडलिटीहरूको लागि मानकीकृत प्रॉम्प्ट ढाँचाहरू

2. **संघीय MCP पूर्वाधार**
   - वितरण गरिएको MCP नेटवर्कहरू जसले संगठनहरूमा स्रोतहरू साझेदारी गर्न सक्छ
   - सुरक्षित मोडेल साझेदारीको लागि मानकीकृत प्रोटोकलहरू
   - गोपनीयता-संरक्षण कम्प्युटेसन प्रविधिहरू

3. **MCP बजारहरू**
   - MCP टेम्प्लेटहरू र प्लगइनहरू साझेदारी र मुद्रीकरण गर्नको लागि पारिस्थितिकी तन्त्र
   - गुणस्तर आश्वासन र प्रमाणीकरण प्रक्रिया
   - मोडेल बजारहरूसँग एकीकरण

4. **एज कम्प्युटिङको लागि MCP**
   - स्रोत-सीमित एज उपकरणहरूको लागि MCP मापदण्डहरूको अनुकूलन
   - कम-ब्यान्डविथ वातावरणको लागि अनुकूलित प्रोटोकलहरू
   - IoT पारिस्थितिकी तन्त्रहरूको लागि विशेष MCP कार्यान्वयनहरू

5. **नियामक फ्रेमवर्कहरू**
   - नियामक अनुपालनको लागि MCP एक्सटेन्सनहरूको विकास
   - मानकीकृत अडिट ट्रेलहरू र व्याख्यात्मक इन्टरफेसहरू
   - उदीयमान AI शासन फ्रेमवर्कहरूसँग एकीकरण

### माइक्रोसफ्टबाट MCP समाधानहरू

माइक्रोसफ्ट र Azure ले विभिन्न परिदृश्यहरूमा MCP कार्यान्वयन गर्न विकासकर्ताहरूलाई मद्दत गर्न धेरै खुला-स्रोत रिपोजिटरीहरू विकास गरेका छन्:

#### माइक्रोसफ्ट संगठन
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - ब्राउजर स्वचालन र परीक्षणको लागि प्लेवाइट MCP सर्भर
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - स्थानीय परीक्षण र समुदाय योगदानको लागि OneDrive MCP सर्भर कार्यान्वयन

#### Azure-Samples संगठन
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure मा MCP सर्भरहरू निर्माण र एकीकृत गर्नका लागि नमूना, उपकरणहरू, र स्रोतहरूसँग लिङ्कहरू
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - वर्तमान मोडेल सन्दर्भ प्रोटोकल विशिष्टतासँग प्रमाणीकरण प्रदर्शन गर्ने सन्दर्भ MCP सर्भरहरू
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions मा रिमोट MCP सर्भर कार्यान्वयनहरूको लागि अवतरण पृष्ठ, भाषासँग सम्बन्धित रिपोजिटरीहरूको लिङ्कहरूसँग
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure Functions सँग Python प्रयोग गरेर कस्टम रिमोट MCP सर्भरहरू निर्माण र तैनाथ गर्नको लागि छिटो सुरुवात टेम्प्लेट
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Azure Functions सँग .NET/C# प्रयोग गरेर कस्टम रिमोट MCP सर्भरहरू निर्माण र तैनाथ गर्नको लागि छिटो सुरुवात टेम्प्लेट
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Azure Functions सँग TypeScript प्रयोग गरेर कस्टम रिमोट MCP सर्भरहरू निर्माण र तैनाथ गर्नको लागि छिटो सुरुवात टेम्प्लेट
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Python प्रयोग गरेर रिमोट MCP सर्भरहरूमा Azure API व्यवस्थापनलाई AI गेटवेको रूपमा प्रयोग गर्नुहोस्
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI प्रयोगहरू जसमा MCP क्षमताहरू, Azure OpenAI र AI Foundry सँग एकीकृत गरिएका छन्

यी रिपोजिटरीहरूले विभिन्न प्रोग्रामिङ भाषाहरू र Azure सेवाहरूमा मोडेल सन्दर्भ प्रोटोकलसँग काम गर्नका लागि विभिन्न कार्यान्वयनहरू, टेम्प्लेटहरू, र स्रोतहरू प्रदान गर्छन्। तिनीहरूले आधारभूत सर्भर कार्यान्वयनहरूदेखि लिएर प्रमाणीकरण, क्लाउड तैनाती, र उद्यम एकीकरण परिदृश्यहरू सम्मका विभिन्न प्रयोगका केसहरू समेट्छन्।

#### MCP स्रोत निर्देशिका

आधिकारिक माइक्रोसफ्ट MCP रिपोजिटरीमा [MCP स्रोत निर्देशिका](https://github.com/microsoft/mcp/tree/main/Resources) ले मोडेल सन्दर्भ प्रोटोकल सर्भरहरूसँग प्रयोगको लागि नमूना स्रोतहरू, प्रॉम्प्ट टेम्प्लेटहरू, र उपकरण परिभाषाहरूको क्युरेट गरिएको सङ्ग्रह प्रदान गर्दछ। यो निर्देशिका MCP सँग द्रुत रूपमा सुरु गर्नका लागि विकासकर्ताहरूलाई पुन: प्रयोग गर्न मिल्ने निर्माण ब्लकहरू र उत्तम अभ्यास उदाहरणहरू प्रदान गरेर डिजाइन गरिएको हो:

- **प्रॉम्प्ट टेम्प्लेटहरू:** सामान्य AI कार्यहरू र परिदृश्यहरूको लागि तयार-प्रयोग प्रॉम्प्ट टेम्प्लेटहरू, जुन तपाईंको आफ्नै MCP सर्भर कार्यान्वयनहरूको
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## अभ्यासहरू

1. एउटा केस स्टडी विश्लेषण गर्नुहोस् र वैकल्पिक कार्यान्वयन दृष्टिकोण प्रस्ताव गर्नुहोस्।
2. परियोजना विचारहरूमध्ये एक छान्नुहोस् र विस्तृत प्राविधिक विशिष्टता तयार गर्नुहोस्।
3. केस स्टडीहरूमा समेटिएको छैन यस्तो कुनै उद्योगमा अनुसन्धान गर्नुहोस् र त्यसको विशेष चुनौतीहरू MCP ले कसरी सम्बोधन गर्न सक्छ भनेर रेखांकित गर्नुहोस्।
4. भविष्यका दिशाहरू मध्ये एक अन्वेषण गर्नुहोस् र यसलाई समर्थन गर्न नयाँ MCP विस्तारको अवधारणा तयार गर्नुहोस्।

अर्को: [सर्वोत्तम अभ्यासहरू](../08-BestPractices/README.md)

**अस्वीकरण**:  
यो कागजात AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरेर अनुवाद गरिएको छ। हामी शुद्धताका लागि प्रयास गर्छौं, कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादहरूमा त्रुटिहरू वा अशुद्धताहरू हुन सक्छन्। यसको मूल भाषा मा रहेको कागजातलाई आधिकारिक स्रोत मान्नुपर्छ। महत्वपूर्ण जानकारीको लागि, व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न हुने कुनै पनि गलतफहमी वा गलत व्याख्याको लागि हामी जिम्मेवार छैनौं।