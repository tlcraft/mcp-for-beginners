<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T21:49:45+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "ne"
}
-->
# प्रारम्भिक अपनाउनेहरूबाट सिकाइ

## अवलोकन

यस पाठले प्रारम्भिक अपनाउनेहरूले Model Context Protocol (MCP) लाई कसरी वास्तविक चुनौतीहरू समाधान गर्न र उद्योगहरूमा नवप्रवर्तन ल्याउन प्रयोग गरेका छन् भनी अन्वेषण गर्छ। विस्तृत केस स्टडीहरू र व्यावहारिक परियोजनाहरू मार्फत, तपाईंले देख्नुहुनेछ कि MCP कसरी मानकीकृत, सुरक्षित, र स्केलेबल AI एकीकरण सक्षम पार्छ—विशाल भाषा मोडेलहरू, उपकरणहरू, र उद्यम डाटालाई एकीकृत फ्रेमवर्कमा जोड्दै। तपाईंले MCP आधारित समाधानहरू डिजाइन र निर्माण गर्ने व्यावहारिक अनुभव पाउनुहुनेछ, प्रमाणित कार्यान्वयन ढाँचाहरूबाट सिक्नुहुनेछ, र उत्पादन वातावरणमा MCP तैनाथ गर्ने उत्तम अभ्यासहरू पत्ता लगाउनुहुनेछ। यस पाठले उदीयमान प्रवृत्तिहरू, भविष्यका दिशाहरू, र खुला स्रोत स्रोतहरूलाई पनि प्रकाश पार्छ जसले तपाईंलाई MCP प्रविधि र यसको विकासशील पारिस्थितिकी तन्त्रमा अग्रभागमा रहन मद्दत गर्दछ।

## सिकाइ लक्ष्यहरू

- विभिन्न उद्योगहरूमा वास्तविक MCP कार्यान्वयनहरूको विश्लेषण गर्नुहोस्
- पूर्ण MCP आधारित अनुप्रयोगहरू डिजाइन र निर्माण गर्नुहोस्
- MCP प्रविधिमा उदीयमान प्रवृत्ति र भविष्यका दिशाहरू अन्वेषण गर्नुहोस्
- वास्तविक विकास परिदृश्यहरूमा उत्तम अभ्यासहरू लागू गर्नुहोस्

## वास्तविक MCP कार्यान्वयनहरू

### केस स्टडी १: उद्यम ग्राहक समर्थन स्वचालन

एक बहुराष्ट्रिय कम्पनीले ग्राहक समर्थन प्रणालीहरूमा AI अन्तरक्रियाहरू मानकीकृत गर्न MCP आधारित समाधान कार्यान्वयन गर्‍यो। यसले तिनीहरूलाई निम्न कुराहरू गर्न सक्षम बनायो:

- विभिन्न LLM प्रदायकहरूका लागि एकीकृत इन्टरफेस सिर्जना गर्नु
- विभागहरूमा सुसंगत prompt व्यवस्थापन कायम राख्नु
- कडा सुरक्षा र अनुपालन नियन्त्रणहरू कार्यान्वयन गर्नु
- विशेष आवश्यकताहरू अनुसार विभिन्न AI मोडेलहरू सजिलै स्विच गर्न सक्नु

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

**परिणाम:** मोडेल लागतमा ३०% कटौती, प्रतिक्रिया सुसंगततामा ४५% सुधार, र विश्वव्यापी सञ्चालनहरूमा अनुपालनमा वृद्धि।

### केस स्टडी २: स्वास्थ्य सेवा डायग्नोस्टिक सहायक

एक स्वास्थ्य सेवा प्रदायकले विभिन्न विशेषज्ञ चिकित्सा AI मोडेलहरू एकीकृत गर्न MCP पूर्वाधार विकास गर्‍यो, जसले संवेदनशील बिरामी डाटा सुरक्षित राख्न सुनिश्चित गर्‍यो:

- सामान्य र विशेषज्ञ चिकित्सा मोडेलहरू बीच सहज स्विचिङ
- कडा गोपनीयता नियन्त्रण र अडिट ट्रेलहरू
- विद्यमान इलेक्ट्रोनिक हेल्थ रेकर्ड (EHR) प्रणालीहरूसँग एकीकरण
- चिकित्सा शब्दावलीका लागि सुसंगत prompt इन्जिनियरिङ

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

**परिणाम:** चिकित्सकहरूको लागि सुधारिएको निदान सुझावहरू, पूर्ण HIPAA अनुपालन कायम राख्दै, र प्रणालीहरू बीच सन्दर्भ स्विचिङमा महत्वपूर्ण कमी।

### केस स्टडी ३: वित्तीय सेवा जोखिम विश्लेषण

एक वित्तीय संस्था विभिन्न विभागहरूमा जोखिम विश्लेषण प्रक्रियाहरू मानकीकृत गर्न MCP लागू गर्‍यो:

- क्रेडिट जोखिम, ठगी पत्ता लगाउने, र लगानी जोखिम मोडेलहरूको लागि एकीकृत इन्टरफेस सिर्जना गरियो
- कडा पहुँच नियन्त्रण र मोडेल संस्करण व्यवस्थापन लागू गरियो
- सबै AI सिफारिसहरूको अडिटयोग्यता सुनिश्चित गरियो
- विभिन्न प्रणालीहरूमा सुसंगत डाटा ढाँचा कायम राखियो

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

**परिणाम:** नियामक अनुपालनमा सुधार, मोडेल तैनाथी चक्रहरू ४०% छिटो, र विभागहरूमा जोखिम मूल्यांकन सुसंगतता वृद्धि।

### केस स्टडी ४: Microsoft Playwright MCP सर्भर ब्राउजर स्वचालनका लागि

Microsoft ले Model Context Protocol मार्फत सुरक्षित, मानकीकृत ब्राउजर स्वचालन सक्षम पार्न [Playwright MCP सर्भर](https://github.com/microsoft/playwright-mcp) विकास गर्‍यो। यस समाधानले AI एजेन्टहरू र LLM हरूलाई वेब ब्राउजरहरूसँग नियन्त्रणयोग्य, अडिटयोग्य, र विस्तारयोग्य तरिकाले अन्तरक्रिया गर्न सक्षम बनाउँछ—जस्तै स्वचालित वेब परीक्षण, डाटा निष्कर्षण, र अन्त-देखि-अन्त कार्यप्रवाहहरू।

- ब्राउजर स्वचालन क्षमता (नेभिगेसन, फारम भर्नु, स्क्रीनशट लिनु आदि) MCP उपकरणहरूका रूपमा उपलब्ध गराउँछ
- अनधिकृत क्रियाकलाप रोक्न कडा पहुँच नियन्त्रण र स्यान्डबक्सिङ लागू गर्दछ
- सबै ब्राउजर अन्तरक्रियाहरूका लागि विस्तृत अडिट लगहरू प्रदान गर्दछ
- एजेन्ट-चालित स्वचालनका लागि Azure OpenAI र अन्य LLM प्रदायकहरूसँग एकीकरण समर्थन गर्दछ

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

**परिणाम:**  
- AI एजेन्टहरू र LLM हरूका लागि सुरक्षित, प्रोग्रामेटिक ब्राउजर स्वचालन सक्षम भयो  
- म्यानुअल परीक्षण प्रयास कम भयो र वेब अनुप्रयोगहरूको परीक्षण कवरेज सुधारियो  
- उद्यम वातावरणमा ब्राउजर आधारित उपकरण एकीकरणका लागि पुन: प्रयोगयोग्य र विस्तारयोग्य फ्रेमवर्क प्रदान गरियो

**सन्दर्भहरू:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### केस स्टडी ५: Azure MCP – उद्यम स्तरको Model Context Protocol सेवा रूपमा

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) Microsoft को प्रबन्धित, उद्यम-स्तरको Model Context Protocol कार्यान्वयन हो, जसले क्लाउड सेवाको रूपमा स्केलेबल, सुरक्षित, र अनुपालन योग्य MCP सर्भर क्षमता प्रदान गर्दछ। Azure MCP ले संगठनहरूलाई Azure AI, डाटा, र सुरक्षा सेवाहरू सँग MCP सर्भरहरू छिटो तैनाथ, व्यवस्थापन, र एकीकृत गर्न सक्षम बनाउँछ, सञ्चालन बोझ कम गर्दै र AI अपनत्व तीव्र पार्दै।

- पूर्ण रूपमा प्रबन्धित MCP सर्भर होस्टिङ, स्वचालित स्केलिङ, अनुगमन, र सुरक्षा सहित
- Azure OpenAI, Azure AI Search, र अन्य Azure सेवाहरू सँग स्वदेशी एकीकरण
- Microsoft Entra ID मार्फत उद्यम प्रमाणीकरण र प्राधिकरण
- अनुकूलित उपकरणहरू, prompt टेम्प्लेटहरू, र स्रोत कनेक्टरहरूको समर्थन
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

**परिणाम:**  
- उद्यम AI परियोजनाहरूका लागि तयार-प्रयोग, अनुपालन योग्य MCP सर्भर प्लेटफर्मले मूल्य प्राप्ति समय घटायो  
- LLM, उपकरणहरू, र उद्यम डाटा स्रोतहरूको एकीकरण सजिलो बनायो  
- MCP कार्यभारका लागि सुरक्षा, अवलोकनयोग्यता, र सञ्चालन दक्षता सुधारियो

**सन्दर्भहरू:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## केस स्टडी ६: NLWeb

MCP (Model Context Protocol) च्याटबोटहरू र AI सहायकहरूले उपकरणहरूसँग अन्तरक्रिया गर्नका लागि उदीयमान प्रोटोकल हो। प्रत्येक NLWeb उदाहरण पनि MCP सर्भर हो, जसले एउटा मुख्य विधि, ask, समर्थन गर्दछ जुन प्राकृतिक भाषामा वेबसाइटलाई प्रश्न सोध्न प्रयोग हुन्छ। फर्काइएको प्रतिक्रिया schema.org प्रयोग गर्दछ, जुन वेब डाटा वर्णन गर्न व्यापक रूपमा प्रयोग हुने शब्दावली हो। सजिलै भन्नुपर्दा, MCP भनेको Http को HTML जस्तै NLWeb हो। NLWeb प्रोटोकलहरू, Schema.org ढाँचाहरू, र नमूना कोडलाई संयोजन गरेर साइटहरूलाई ती endpoints छिटो बनाउन मद्दत गर्दछ, जसले मानवहरूलाई संवादात्मक इन्टरफेसहरू मार्फत र मेसिनहरूलाई प्राकृतिक एजेन्ट-टु-एजेन्ट अन्तरक्रियाद्वारा लाभान्वित गर्दछ।

NLWeb का दुई भिन्न घटकहरू छन्:  
- एउटा प्रोटोकल, सुरुमा धेरै सरल, जसले प्राकृतिक भाषामा साइटसँग अन्तरक्रिया गर्दछ र फर्काइएको उत्तरका लागि json र schema.org प्रयोग गर्दछ। REST API सम्बन्धी थप विवरणका लागि दस्तावेजीकरण हेर्नुहोस्।  
- (१) को सरल कार्यान्वयन जसले विद्यमान मार्कअप प्रयोग गर्दछ, ती साइटहरूका लागि जुन वस्तुहरूको सूची (उत्पादन, रेसिपी, आकर्षण, समीक्षा आदि) को रूपमा सारांशित गर्न सकिन्छ। प्रयोगकर्ता इन्टरफेस विजेटहरूको सेटसँगै, साइटहरूले सजिलै आफ्ना सामग्रीहरूमा संवादात्मक इन्टरफेसहरू प्रदान गर्न सक्छन्। यसले कसरी काम गर्छ भनी थप विवरणका लागि Life of a chat query दस्तावेजीकरण हेर्नुहोस्।

**सन्दर्भहरू:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## व्यावहारिक परियोजनाहरू

### परियोजना १: बहु-प्रदायक MCP सर्भर बनाउनुहोस्

**उद्देश्य:** विशिष्ट मापदण्डहरूका आधारमा बहु AI मोडेल प्रदायकहरूमा अनुरोधहरू मार्गनिर्देशन गर्न सक्ने MCP सर्भर सिर्जना गर्नु।

**आवश्यकताहरू:**  
- कम्तिमा तीन फरक मोडेल प्रदायकहरू समर्थन गर्नुहोस् (जस्तै OpenAI, Anthropic, स्थानीय मोडेलहरू)  
- अनुरोध मेटाडाटामा आधारित मार्गनिर्देशन संयन्त्र कार्यान्वयन गर्नुहोस्  
- प्रदायक प्रमाणीकरण व्यवस्थापनका लागि कन्फिगरेसन प्रणाली सिर्जना गर्नुहोस्  
- प्रदर्शन र लागत अनुकूलनका लागि क्यासिङ थप्नुहोस्  
- प्रयोग अनुगमनका लागि सरल ड्यासबोर्ड बनाउनुहोस्

**कार्यान्वयन चरणहरू:**  
1. आधारभूत MCP सर्भर पूर्वाधार सेटअप गर्नुहोस्  
2. प्रत्येक AI मोडेल सेवाका लागि प्रदायक एडाप्टरहरू कार्यान्वयन गर्नुहोस्  
3. अनुरोध विशेषताहरूमा आधारित मार्गनिर्देशन तर्क सिर्जना गर्नुहोस्  
4. बारम्बार अनुरोधहरूका लागि क्यासिङ संयन्त्रहरू थप्नुहोस्  
5. अनुगमन ड्यासबोर्ड विकास गर्नुहोस्  
6. विभिन्न अनुरोध ढाँचाहरूमा परीक्षण गर्नुहोस्

**प्रविधिहरू:** तपाईंको रुचि अनुसार Python (.NET/Java/Python), Redis क्यासिङका लागि, र ड्यासबोर्डका लागि सरल वेब फ्रेमवर्क प्रयोग गर्न सक्नुहुन्छ।

### परियोजना २: उद्यम Prompt व्यवस्थापन प्रणाली

**उद्देश्य:** संगठनभर prompt टेम्प्लेटहरूको व्यवस्थापन, संस्करण नियन्त्रण, र तैनाथीका लागि MCP आधारित प्रणाली विकास गर्नु।

**आवश्यकताहरू:**  
- prompt टेम्प्लेटहरूको केन्द्रीय भण्डार सिर्जना गर्नुहोस्  
- संस्करण व्यवस्थापन र अनुमोदन कार्यप्रवाह कार्यान्वयन गर्नुहोस्  
- नमूना इनपुटहरूसँग टेम्प्लेट परीक्षण क्षमता विकास गर्नुहोस्  
- भूमिका आधारित पहुँच नियन्त्रणहरू विकास गर्नुहोस्  
- टेम्प्लेट पुनःप्राप्ति र तैनाथीका लागि API सिर्जना गर्नुहोस्

**कार्यान्वयन चरणहरू:**  
1. टेम्प्लेट भण्डारणका लागि डाटाबेस स्किमाको डिजाइन गर्नुहोस्  
2. टेम्प्लेट CRUD अपरेसनका लागि मुख्य API सिर्जना गर्नुहोस्  
3. संस्करण व्यवस्थापन प्रणाली कार्यान्वयन गर्नुहोस्  
4. अनुमोदन कार्यप्रवाह विकास गर्नुहोस्  
5. परीक्षण फ्रेमवर्क विकास गर्नुहोस्  
6. व्यवस्थापनका लागि सरल वेब इन्टरफेस सिर्जना गर्नुहोस्  
7. MCP सर्भरसँग एकीकरण गर्नुहोस्

**प्रविधिहरू:** तपाईंले रोजेको ब्याकएन्ड फ्रेमवर्क, SQL वा NoSQL डाटाबेस, र व्यवस्थापन इन्टरफेसका लागि फ्रन्टएन्ड फ्रेमवर्क।

### परियोजना ३: MCP आधारित सामग्री सिर्जना प्लेटफर्म

**उद्देश्य:** विभिन्न सामग्री प्रकारहरूमा सुसंगत नतिजा दिन MCP प्रयोग गरेर सामग्री सिर्जना प्लेटफर्म निर्माण गर्नु।

**आवश्यकताहरू:**  
- बहु सामग्री ढाँचाहरू समर्थन गर्नुहोस् (ब्लग पोस्ट, सामाजिक मिडिया, मार्केटिङ कपी)  
- अनुकूलन विकल्पहरूसहित टेम्प्लेट आधारित सिर्जना कार्यान्वयन गर्नुहोस्  
- सामग्री समीक्षा र प्रतिक्रिया प्रणाली सिर्जना गर्नुहोस्  
- सामग्री प्रदर्शन मेट्रिक्स ट्र्याक गर्नुहोस्  
- सामग्री संस्करण र पुनरावृत्तिलाई समर्थन गर्नुहोस्

**कार्यान्वयन चरणहरू:**  
1. MCP क्लाइन्ट पूर्वाधार सेटअप गर्नुहोस्  
2. विभिन्न सामग्री प्रकारका लागि टेम्प्लेटहरू सिर्जना गर्नुहोस्  
3. सामग्री सिर्जना पाइपलाइन बनाउनुहोस्  
4. समीक्षा प्रणाली कार्यान्वयन गर्नुहोस्  
5. मेट्रिक्स ट्र्याकिङ प्रणाली विकास गर्नुहोस्  
6. टेम्प्लेट व्यवस्थापन र सामग्री सिर्जनाका लागि प्रयोगकर्ता इन्टरफेस सिर्जना गर्नुहोस्

**प्रविधिहरू:** तपाईंको रोजाइको प्रोग्रामिङ भाषा, वेब फ्रेमवर्क, र डाटाबेस प्रणाली।

## MCP प्रविधिका लागि भविष्यका दिशाहरू

### उदीयमान प्रवृत्तिहरू

1. **बहु-मोडल MCP**  
   - छवि, अडियो, र भिडियो मोडेलहरूसँग अन्तरक्रिया मानकीकृत गर्न MCP को विस्तार  
   - क्रस-मोडल तर्क क्षमताहरू विकास  
   - विभिन्न मोडालिटीहरूका लागि मानकीकृत prompt ढाँचाहरू

2. **संघीय MCP पूर्वाधार**  
   - संगठनहरू बीच स्रोतहरू साझा गर्न सक्ने वितरित MCP नेटवर्कहरू  
   - सुरक्षित मोडेल साझेदारीका लागि मानकीकृत प्रोटोकलहरू  
   - गोपनीयता-संरक्षण गणना प्रविधिहरू

3. **MCP बजारहरू**  
   - MCP टेम्प्लेट र प्लगइनहरू साझा र मुद्रीकरणका लागि पारिस्थितिकी तन्त्रहरू  
   - गुणस्तर आश्वासन र प्रमाणपत्र प्रक्रिया  
   - मोडेल बजारहरूसँग एकीकरण

4. **एज कम्प्युटिङका लागि MCP**  
   - स्रोत सीमित एज उपकरणहरूका लागि MCP मानकहरूको अनुकूलन  
   - कम ब्याण्डविड्थ वातावरणका लागि अनुकूलित प्रोटोकलहरू  
   - IoT पारिस्थितिकी तन्त्रका लागि विशेष MCP कार्यान्वयनहरू

5. **नियामक संरचनाहरू**  
   - नियामक अनुपालनका लागि MCP विस्तारहरूको विकास  
   - मानकीकृत अडिट ट्रेल र व्याख्यात्मक इन्टरफेसहरू  
   - उदीयमान AI शासन संरचनाहरूसँग एकीकरण

### Microsoft बाट MCP समाधानहरू

Microsoft र Azure ले विकासकर्ताहरूलाई विभिन्न परिदृश्यहरूमा MCP कार्यान्वयनमा सहयोग गर्न धेरै खुला स्रोत भण्डारहरू विकास गरेका छन्:

#### Microsoft संगठन  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - ब्राउजर स्वचालन र परीक्षणका लागि Playwright MCP सर्भर  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - स्थानीय परीक्षण र समुदाय योगदानका लागि OneDrive MCP सर्भर कार्यान्वयन  
3. [NLWeb](https://github.com/microsoft/NlWeb) - खुला प्रोटोकल र सम्बन्धित खुला स्रोत उपकरणहरूको संग्रह, मुख्य फोकस AI वेबको आधारशिला स्थापना गर्नु

#### Azure-Samples संगठन  
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure मा MCP सर्भरहरू निर्माण र एकीकृत गर्नका लागि नमूना, उपकरणहरू, र स्रोतहरू  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - वर्तमान Model Context Protocol विशिष्टता अनुसार प्रमाणीकरण देखाउने सन्दर्भ MCP सर्भरहरू  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions मा रिमोट MCP सर्भर कार्यान्वयनहरूको ल्यान्डिङ पृष्ठ  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Python प्रयोग गरेर Azure Functions मा कस्टम रिमोट MCP सर्भर बनाउन र तैनाथ गर्न क्विकस्टार्ट टेम्प्लेट  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - .NET/C# प्रयोग गरेर Azure Functions मा कस्टम रिमोट MCP सर्भर बनाउन र तैनाथ गर्न क्विकस्टार्ट टेम्प्लेट  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - TypeScript प्रयोग गरेर Azure Functions मा कस्टम रिमोट MCP सर्भर बनाउन र तैनाथ गर्न क्विकस्टार्ट टेम्प्लेट  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Python प्रयोग गरेर Azure API Management लाई रिमोट MCP सर्भरहरूको AI गेटवेका रूपमा प्रयोग  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI प्रयोगहरू जसमा MCP क्षमता, Azure OpenAI र AI Foundry सँग एकीकरण

यी भण्डारहरूले विभिन्न प्रोग्रामिङ भाषाहरू र Azure सेवाहरूमा Model Context Protocol सँग काम गर्ने विभिन्न
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## अभ्यासहरू

1. एउटा केस अध्ययन विश्लेषण गरी वैकल्पिक कार्यान्वयन तरिका प्रस्ताव गर्नुहोस्।
2. एउटा परियोजना विचार छान्नुहोस् र विस्तृत प्राविधिक विशिष्टता तयार गर्नुहोस्।
3. केस अध्ययनमा समेटिएको छैन भने कुनै उद्योगको अनुसन्धान गरी MCP ले त्यसका विशिष्ट चुनौतीहरू कसरी सम्बोधन गर्न सक्छ भनेर रेखाङ्कन गर्नुहोस्।
4. भविष्यका दिशाहरू मध्ये एउटा अन्वेषण गरी त्यसलाई समर्थन गर्ने नयाँ MCP विस्तारको अवधारणा तयार गर्नुहोस्।

अर्को: [Best Practices](../08-BestPractices/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा गलतफहमी हुनसक्छ। मूल दस्तावेजलाई यसको मूल भाषामा आधिकारिक स्रोतको रूपमा मानिनुपर्छ। महत्वपूर्ण जानकारीको लागि पेशेवर मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलत बुझाइ वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।