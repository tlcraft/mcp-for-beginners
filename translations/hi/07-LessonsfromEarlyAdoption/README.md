<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:08:34+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hi"
}
-->
# शुरुआती अपनाने वालों से सबक

## अवलोकन

यह पाठ इस बात की पड़ताल करता है कि शुरुआती अपनाने वालों ने कैसे मॉडल संदर्भ प्रोटोकॉल (MCP) का उपयोग वास्तविक दुनिया की चुनौतियों को हल करने और उद्योगों में नवाचार को बढ़ावा देने के लिए किया है। विस्तृत केस स्टडी और व्यावहारिक परियोजनाओं के माध्यम से, आप देखेंगे कि MCP कैसे मानकीकृत, सुरक्षित और स्केलेबल AI एकीकरण को सक्षम करता है—बड़े भाषा मॉडल, उपकरण और उद्यम डेटा को एक एकीकृत ढांचे में जोड़ता है। आप MCP-आधारित समाधान डिज़ाइन और निर्माण का व्यावहारिक अनुभव प्राप्त करेंगे, सिद्ध कार्यान्वयन पैटर्न से सीखेंगे, और उत्पादन वातावरण में MCP को तैनात करने के सर्वोत्तम अभ्यासों की खोज करेंगे। पाठ उभरते रुझानों, भविष्य की दिशाओं और ओपन-सोर्स संसाधनों को भी उजागर करता है ताकि आप MCP प्रौद्योगिकी और इसके विकसित होते पारिस्थितिकी तंत्र की अग्रिम पंक्ति में बने रहें।

## सीखने के उद्देश्य

- विभिन्न उद्योगों में वास्तविक दुनिया के MCP कार्यान्वयन का विश्लेषण करें
- संपूर्ण MCP-आधारित एप्लिकेशन डिज़ाइन और बनाएं
- MCP प्रौद्योगिकी में उभरते रुझानों और भविष्य की दिशाओं का अन्वेषण करें
- वास्तविक विकास परिदृश्यों में सर्वोत्तम अभ्यास लागू करें

## वास्तविक दुनिया के MCP कार्यान्वयन

### केस स्टडी 1: एंटरप्राइज ग्राहक समर्थन स्वचालन

एक बहुराष्ट्रीय निगम ने अपने ग्राहक समर्थन प्रणालियों में AI इंटरैक्शन को मानकीकृत करने के लिए MCP-आधारित समाधान लागू किया। इससे उन्हें सक्षम बनाया गया:

- कई LLM प्रदाताओं के लिए एकीकृत इंटरफ़ेस बनाना
- विभागों में लगातार प्रॉम्प्ट प्रबंधन बनाए रखना
- मजबूत सुरक्षा और अनुपालन नियंत्रण लागू करना
- विशिष्ट आवश्यकताओं के आधार पर विभिन्न AI मॉडल के बीच आसानी से स्विच करना

**तकनीकी कार्यान्वयन:**
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

**परिणाम:** मॉडल लागत में 30% की कमी, प्रतिक्रिया स्थिरता में 45% सुधार, और वैश्विक संचालन में उन्नत अनुपालन।

### केस स्टडी 2: हेल्थकेयर डायग्नोस्टिक असिस्टेंट

एक स्वास्थ्य सेवा प्रदाता ने कई विशेष चिकित्सा AI मॉडल को एकीकृत करने के लिए MCP इन्फ्रास्ट्रक्चर विकसित किया, जबकि संवेदनशील रोगी डेटा सुरक्षित रहा:

- सामान्य और विशेषज्ञ चिकित्सा मॉडल के बीच सहज स्विचिंग
- सख्त गोपनीयता नियंत्रण और ऑडिट ट्रेल
- मौजूदा इलेक्ट्रॉनिक स्वास्थ्य रिकॉर्ड (EHR) प्रणालियों के साथ एकीकरण
- चिकित्सा शब्दावली के लिए लगातार प्रॉम्प्ट इंजीनियरिंग

**तकनीकी कार्यान्वयन:**
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

**परिणाम:** HIPAA अनुपालन को पूरी तरह बनाए रखते हुए चिकित्सकों के लिए उन्नत निदान सुझाव और सिस्टम के बीच संदर्भ-स्विचिंग में महत्वपूर्ण कमी।

### केस स्टडी 3: वित्तीय सेवाएं जोखिम विश्लेषण

एक वित्तीय संस्थान ने विभिन्न विभागों में अपने जोखिम विश्लेषण प्रक्रियाओं को मानकीकृत करने के लिए MCP लागू किया:

- क्रेडिट जोखिम, धोखाधड़ी का पता लगाने और निवेश जोखिम मॉडल के लिए एकीकृत इंटरफ़ेस बनाया
- सख्त पहुंच नियंत्रण और मॉडल संस्करण लागू किया
- सभी AI अनुशंसाओं की ऑडिटबिलिटी सुनिश्चित की
- विविध प्रणालियों में लगातार डेटा प्रारूपण बनाए रखा

**तकनीकी कार्यान्वयन:**
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

**परिणाम:** उन्नत नियामक अनुपालन, 40% तेज मॉडल परिनियोजन चक्र, और विभागों में जोखिम आकलन स्थिरता में सुधार।

### केस स्टडी 4: ब्राउज़र ऑटोमेशन के लिए Microsoft Playwright MCP सर्वर

Microsoft ने मॉडल संदर्भ प्रोटोकॉल के माध्यम से सुरक्षित, मानकीकृत ब्राउज़र ऑटोमेशन को सक्षम करने के लिए [Playwright MCP सर्वर](https://github.com/microsoft/playwright-mcp) विकसित किया। यह समाधान AI एजेंटों और LLMs को नियंत्रित, ऑडिट योग्य और विस्तार योग्य तरीके से वेब ब्राउज़रों के साथ इंटरैक्ट करने की अनुमति देता है—स्वचालित वेब परीक्षण, डेटा निष्कर्षण, और एंड-टू-एंड वर्कफ़्लोज़ जैसे उपयोग मामलों को सक्षम करता है।

- MCP उपकरण के रूप में ब्राउज़र ऑटोमेशन क्षमताओं (नेविगेशन, फॉर्म भरना, स्क्रीनशॉट कैप्चर, आदि) को उजागर करता है
- अनधिकृत क्रियाओं को रोकने के लिए सख्त पहुंच नियंत्रण और सैंडबॉक्सिंग लागू करता है
- सभी ब्राउज़र इंटरैक्शन के लिए विस्तृत ऑडिट लॉग प्रदान करता है
- एजेंट-संचालित ऑटोमेशन के लिए Azure OpenAI और अन्य LLM प्रदाताओं के साथ एकीकरण का समर्थन करता है

**तकनीकी कार्यान्वयन:**
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
- AI एजेंटों और LLMs के लिए सुरक्षित, प्रोग्रामेटिक ब्राउज़र ऑटोमेशन सक्षम किया
- मैनुअल परीक्षण प्रयास को कम किया और वेब अनुप्रयोगों के लिए परीक्षण कवरेज में सुधार किया
- उद्यम वातावरण में ब्राउज़र-आधारित टूल एकीकरण के लिए एक पुन: प्रयोज्य, विस्तार योग्य ढांचा प्रदान किया

**संदर्भ:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### केस स्टडी 5: Azure MCP – सेवा के रूप में एंटरप्राइज-ग्रेड मॉडल संदर्भ प्रोटोकॉल

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) Microsoft का प्रबंधित, एंटरप्राइज-ग्रेड मॉडल संदर्भ प्रोटोकॉल का कार्यान्वयन है, जिसे क्लाउड सेवा के रूप में स्केलेबल, सुरक्षित और अनुपालन MCP सर्वर क्षमताएं प्रदान करने के लिए डिज़ाइन किया गया है। Azure MCP संगठनों को MCP सर्वरों को Azure AI, डेटा, और सुरक्षा सेवाओं के साथ तेजी से तैनात, प्रबंधित और एकीकृत करने में सक्षम बनाता है, परिचालन ओवरहेड को कम करता है और AI अपनाने में तेजी लाता है।

- अंतर्निहित स्केलिंग, निगरानी और सुरक्षा के साथ पूरी तरह से प्रबंधित MCP सर्वर होस्टिंग
- Azure OpenAI, Azure AI Search, और अन्य Azure सेवाओं के साथ देशी एकीकरण
- Microsoft Entra ID के माध्यम से एंटरप्राइज प्रमाणीकरण और प्राधिकरण
- कस्टम टूल, प्रॉम्प्ट टेम्पलेट, और संसाधन कनेक्टर के लिए समर्थन
- एंटरप्राइज सुरक्षा और नियामक आवश्यकताओं के साथ अनुपालन

**तकनीकी कार्यान्वयन:**
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
- तैयार-से-उपयोग, अनुपालन MCP सर्वर प्लेटफ़ॉर्म प्रदान करके एंटरप्राइज AI परियोजनाओं के लिए मूल्य तक पहुँचने का समय कम किया
- LLMs, उपकरण, और उद्यम डेटा स्रोतों के एकीकरण को सरल बनाया
- MCP वर्कलोड के लिए उन्नत सुरक्षा, अवलोकनीयता, और परिचालन दक्षता

**संदर्भ:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## व्यावहारिक परियोजनाएँ

### परियोजना 1: एक बहु-प्रदाता MCP सर्वर बनाएं

**उद्देश्य:** विशिष्ट मानदंडों के आधार पर कई AI मॉडल प्रदाताओं को अनुरोध भेजने में सक्षम MCP सर्वर बनाएं।

**आवश्यकताएँ:**
- कम से कम तीन विभिन्न मॉडल प्रदाताओं का समर्थन करें (जैसे, OpenAI, Anthropic, स्थानीय मॉडल)
- अनुरोध मेटाडेटा के आधार पर एक रूटिंग तंत्र लागू करें
- प्रदाता क्रेडेंशियल्स के प्रबंधन के लिए एक कॉन्फ़िगरेशन प्रणाली बनाएं
- प्रदर्शन और लागत को अनुकूलित करने के लिए कैशिंग जोड़ें
- उपयोग की निगरानी के लिए एक सरल डैशबोर्ड बनाएं

**कार्यान्वयन चरण:**
1. बुनियादी MCP सर्वर इन्फ्रास्ट्रक्चर सेट करें
2. प्रत्येक AI मॉडल सेवा के लिए प्रदाता एडेप्टर लागू करें
3. अनुरोध विशेषताओं के आधार पर रूटिंग लॉजिक बनाएं
4. बार-बार अनुरोधों के लिए कैशिंग तंत्र जोड़ें
5. निगरानी डैशबोर्ड विकसित करें
6. विभिन्न अनुरोध पैटर्न के साथ परीक्षण करें

**प्रौद्योगिकियाँ:** Python (.NET/Java/Python आपकी पसंद के अनुसार), कैशिंग के लिए Redis, और डैशबोर्ड के लिए एक सरल वेब फ्रेमवर्क चुनें।

### परियोजना 2: एंटरप्राइज प्रॉम्प्ट प्रबंधन प्रणाली

**उद्देश्य:** पूरे संगठन में प्रॉम्प्ट टेम्पलेट्स के प्रबंधन, संस्करणीकरण, और तैनाती के लिए MCP-आधारित प्रणाली विकसित करें।

**आवश्यकताएँ:**
- प्रॉम्प्ट टेम्पलेट्स के लिए एक केंद्रीकृत रिपॉजिटरी बनाएं
- संस्करणीकरण और अनुमोदन वर्कफ़्लोज़ लागू करें
- नमूना इनपुट के साथ टेम्पलेट परीक्षण क्षमताएं बनाएं
- भूमिका-आधारित पहुंच नियंत्रण विकसित करें
- टेम्पलेट पुनःप्राप्ति और तैनाती के लिए एक API बनाएं

**कार्यान्वयन चरण:**
1. टेम्पलेट स्टोरेज के लिए डेटाबेस स्कीमा डिज़ाइन करें
2. टेम्पलेट CRUD संचालन के लिए मुख्य API बनाएं
3. संस्करणीकरण प्रणाली लागू करें
4. अनुमोदन वर्कफ़्लो बनाएं
5. परीक्षण ढांचा विकसित करें
6. प्रबंधन के लिए एक सरल वेब इंटरफ़ेस बनाएं
7. MCP सर्वर के साथ एकीकृत करें

**प्रौद्योगिकियाँ:** आपके पसंद के बैकएंड फ्रेमवर्क, SQL या NoSQL डेटाबेस, और प्रबंधन इंटरफ़ेस के लिए एक फ्रंटेंड फ्रेमवर्क।

### परियोजना 3: MCP-आधारित सामग्री निर्माण प्लेटफ़ॉर्म

**उद्देश्य:** विभिन्न सामग्री प्रकारों में लगातार परिणाम प्रदान करने के लिए MCP का उपयोग करने वाला सामग्री निर्माण प्लेटफ़ॉर्म बनाएं।

**आवश्यकताएँ:**
- कई सामग्री प्रारूपों का समर्थन करें (ब्लॉग पोस्ट, सोशल मीडिया, विपणन कॉपी)
- अनुकूलन विकल्पों के साथ टेम्पलेट-आधारित निर्माण लागू करें
- सामग्री समीक्षा और प्रतिक्रिया प्रणाली बनाएं
- सामग्री प्रदर्शन मेट्रिक्स ट्रैक करें
- सामग्री संस्करणीकरण और पुनरावृत्ति का समर्थन करें

**कार्यान्वयन चरण:**
1. MCP क्लाइंट इन्फ्रास्ट्रक्चर सेट करें
2. विभिन्न सामग्री प्रकारों के लिए टेम्पलेट बनाएं
3. सामग्री निर्माण पाइपलाइन बनाएं
4. समीक्षा प्रणाली लागू करें
5. मेट्रिक्स ट्रैकिंग प्रणाली विकसित करें
6. टेम्पलेट प्रबंधन और सामग्री निर्माण के लिए एक उपयोगकर्ता इंटरफ़ेस बनाएं

**प्रौद्योगिकियाँ:** आपकी पसंद की प्रोग्रामिंग भाषा, वेब फ्रेमवर्क, और डेटाबेस सिस्टम।

## MCP प्रौद्योगिकी के लिए भविष्य की दिशाएँ

### उभरते रुझान

1. **मल्टी-मोडल MCP**
   - छवि, ऑडियो, और वीडियो मॉडलों के साथ इंटरैक्शन को मानकीकृत करने के लिए MCP का विस्तार
   - क्रॉस-मोडल तर्क क्षमताओं का विकास
   - विभिन्न तरीकों के लिए मानकीकृत प्रॉम्प्ट प्रारूप

2. **वितरित MCP अवसंरचना**
   - वितरित MCP नेटवर्क जो संगठनों के बीच संसाधनों को साझा कर सकते हैं
   - सुरक्षित मॉडल साझा करने के लिए मानकीकृत प्रोटोकॉल
   - गोपनीयता-संरक्षण गणना तकनीक

3. **MCP मार्केटप्लेस**
   - MCP टेम्पलेट्स और प्लगइन्स को साझा और मुद्रीकृत करने के लिए पारिस्थितिकी तंत्र
   - गुणवत्ता आश्वासन और प्रमाणन प्रक्रियाएं
   - मॉडल मार्केटप्लेस के साथ एकीकरण

4. **एज कंप्यूटिंग के लिए MCP**
   - संसाधन-सीमित एज उपकरणों के लिए MCP मानकों का अनुकूलन
   - कम-बैंडविड्थ वातावरण के लिए अनुकूलित प्रोटोकॉल
   - IoT पारिस्थितिकी तंत्र के लिए विशेष MCP कार्यान्वयन

5. **नियामक ढांचे**
   - नियामक अनुपालन के लिए MCP एक्सटेंशन का विकास
   - मानकीकृत ऑडिट ट्रेल और व्याख्यात्मक इंटरफेस
   - उभरते AI शासन ढांचे के साथ एकीकरण

### Microsoft से MCP समाधान

Microsoft और Azure ने विभिन्न परिदृश्यों में MCP को लागू करने में मदद करने के लिए कई ओपन-सोर्स रिपॉजिटरी विकसित की हैं:

#### Microsoft संगठन
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - ब्राउज़र ऑटोमेशन और परीक्षण के लिए एक Playwright MCP सर्वर
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - स्थानीय परीक्षण और सामुदायिक योगदान के लिए OneDrive MCP सर्वर कार्यान्वयन

#### Azure-Samples संगठन
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure पर MCP सर्वर बनाने और एकीकृत करने के लिए नमूने, उपकरण, और संसाधनों के लिंक
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - वर्तमान मॉडल संदर्भ प्रोटोकॉल विनिर्देशन के साथ प्रमाणीकरण प्रदर्शित करने वाले संदर्भ MCP सर्वर
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions में रिमोट MCP सर्वर कार्यान्वयन के लिए लैंडिंग पृष्ठ, भाषा-विशिष्ट रिपॉजिटरी के लिंक के साथ
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure Functions के साथ Python का उपयोग करके कस्टम रिमोट MCP सर्वर बनाने और तैनात करने के लिए त्वरित प्रारंभ टेम्पलेट
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Azure Functions के साथ .NET/C# का उपयोग करके कस्टम रिमोट MCP सर्वर बनाने और तैनात करने के लिए त्वरित प्रारंभ टेम्पलेट
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Azure Functions के साथ TypeScript का उपयोग करके कस्टम रिमोट MCP सर्वर बनाने और तैनात करने के लिए त्वरित प्रारंभ टेम्पलेट
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Azure API प्रबंधन के रूप में AI गेटवे Python का उपयोग करके रिमोट MCP सर्वरों के लिए
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI प्रयोगों में MCP क्षमताएं शामिल हैं, Azure OpenAI और AI Foundry के साथ एकीकृत

ये रिपॉजिटरी विभिन्न प्रोग्रामिंग भाषाओं और Azure सेवाओं में मॉडल संदर्भ प्रोटोकॉल के साथ काम करने के लिए विभिन्न कार्यान्वयन, टेम्पलेट, और संसाधन प्रदान करते हैं। वे बुनियादी सर्वर कार्यान्वयन से लेकर प्रमाणीकरण, क्लाउड परिनियोजन, और उद्यम एकीकरण परिदृश्यों तक कई उपयोग मामलों को कवर करते हैं।

#### MCP संसाधन निर्देशिका

आधिकारिक Microsoft MCP रिपॉजिटरी में [MCP संसाधन निर्देशिका](https://github.com/microsoft/mcp/tree/main/Resources) MCP सर्वरों के साथ उपयोग के लिए नमूना संसाधनों, प्रॉम्प्ट टेम्पलेट, और टूल परिभाषाओं का एक क्यूरेटेड संग्रह प्रदान करती है। यह निर्देशिका MCP के साथ जल्दी से शुरुआत करने में मदद करने के लिए पुन: प्रयोज्य निर्माण खंड और सर्वोत्तम अभ्यास उदाहरण प्रदान करती है:

- **प्रॉम्प्ट टेम्पलेट:** सामान्य AI कार्यों और परिदृश्यों के लिए तैयार-से-उपयोग प्रॉम्प्ट टेम्पलेट, जिन्हें आपके अपने MCP सर्वर कार्यान्वयन के लिए अनुकूलित किया जा सकता है।
- **टूल परिभाषाएँ:** विभिन्न MCP सर्वरों के बीच टूल एकीकरण और आह्वान को मानकीकृत करने के लिए उदाहरण टूल स्कीमा और मेटाडेटा।
- **संसाधन नमूने:** MCP ढांचे के भीतर डेटा स्रोतों, API, और बाहरी सेवाओं से जुड़ने के लिए उदाहरण संसाधन परिभाषाएँ।
- **संदर्भ कार्यान्वयन:** वास्तविक दुनिया के MCP परियोजनाओं में संसाधनों, प्रॉम्प्ट, और टूल को संरचित और संगठित करने का तरीका प्रदर्शित करने वाले व्यावहारिक नमूने।

ये संसाधन विकास को गति देते हैं, मानकीकरण को बढ़ावा देते हैं, और MCP-आधारित समाधानों के निर्माण और तैनाती के दौरान सर्वोत्तम अभ्यास सुनिश्चित करने में मदद करते हैं।

#### MCP संसाधन निर्देशिका
- [MCP Resources (Sample Prompts, Tools, and Resource Definitions)](https://github.com/microsoft/mcp/tree/main/Resources)

### अनुसंधान के अवसर

- MCP फ्रेमवर्क के भीतर कुशल प्रॉम्प्ट अनुकूलन तकनीक
- बहु-किरायेदार MCP तैनाती के लिए सुरक्षा मॉडल
-
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## अभ्यास

1. एक केस स्टडी का विश्लेषण करें और एक वैकल्पिक कार्यान्वयन दृष्टिकोण प्रस्तावित करें।
2. परियोजना विचारों में से एक चुनें और एक विस्तृत तकनीकी विनिर्देशन बनाएं।
3. एक उद्योग का शोध करें जो केस स्टडी में शामिल नहीं है और वर्णन करें कि MCP उसकी विशेष चुनौतियों को कैसे संबोधित कर सकता है।
4. भविष्य के दिशाओं में से एक का अन्वेषण करें और उसे समर्थन देने के लिए एक नए MCP विस्तार की अवधारणा बनाएं।

अगला: [सर्वोत्तम अभ्यास](../08-BestPractices/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयास करते हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में प्रामाणिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न होने वाली किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।