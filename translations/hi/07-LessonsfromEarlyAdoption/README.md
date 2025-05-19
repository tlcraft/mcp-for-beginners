<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "344a126b620ff7997158542fd31be6a4",
  "translation_date": "2025-05-19T21:44:01+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "hi"
}
-->
# शुरुआती अपनाने वालों से सीख

## अवलोकन

यह पाठ यह दर्शाता है कि कैसे शुरुआती अपनाने वालों ने Model Context Protocol (MCP) का उपयोग वास्तविक दुनिया की चुनौतियों को हल करने और उद्योगों में नवाचार को बढ़ावा देने के लिए किया है। विस्तृत केस स्टडीज और व्यावहारिक परियोजनाओं के माध्यम से, आप देखेंगे कि MCP कैसे मानकीकृत, सुरक्षित और स्केलेबल AI एकीकरण को सक्षम बनाता है—जो बड़े भाषा मॉडल, टूल्स और एंटरप्राइज़ डेटा को एक एकीकृत फ्रेमवर्क में जोड़ता है। आप MCP-आधारित समाधान डिजाइन और निर्माण में व्यावहारिक अनुभव प्राप्त करेंगे, सिद्ध कार्यान्वयन पैटर्न से सीखेंगे, और उत्पादन वातावरण में MCP तैनाती के लिए सर्वोत्तम प्रथाओं को जानेंगे। यह पाठ उभरते रुझानों, भविष्य की दिशाओं, और ओपन-सोर्स संसाधनों को भी उजागर करता है ताकि आप MCP प्रौद्योगिकी और इसके विकसित होते इकोसिस्टम में आगे बने रह सकें।

## सीखने के उद्देश्य

- विभिन्न उद्योगों में वास्तविक MCP कार्यान्वयन का विश्लेषण करें
- पूर्ण MCP-आधारित एप्लिकेशन डिज़ाइन और बनाएं
- MCP तकनीक में उभरते रुझानों और भविष्य की दिशाओं का अन्वेषण करें
- वास्तविक विकास परिदृश्यों में सर्वोत्तम प्रथाओं को लागू करें

## वास्तविक MCP कार्यान्वयन

### केस स्टडी 1: एंटरप्राइज़ ग्राहक सहायता स्वचालन

एक बहुराष्ट्रीय कंपनी ने अपने ग्राहक सहायता सिस्टम में AI इंटरैक्शन को मानकीकृत करने के लिए MCP-आधारित समाधान लागू किया। इससे उन्हें निम्नलिखित करने में मदद मिली:

- कई LLM प्रदाताओं के लिए एक एकीकृत इंटरफ़ेस बनाना
- विभागों में लगातार प्रॉम्प्ट प्रबंधन बनाए रखना
- मजबूत सुरक्षा और अनुपालन नियंत्रण लागू करना
- विशिष्ट आवश्यकताओं के आधार पर विभिन्न AI मॉडलों के बीच आसानी से स्विच करना

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

**परिणाम:** मॉडल लागत में 30% की कमी, प्रतिक्रिया स्थिरता में 45% सुधार, और वैश्विक संचालन में बेहतर अनुपालन।

### केस स्टडी 2: हेल्थकेयर डायग्नोस्टिक असिस्टेंट

एक हेल्थकेयर प्रदाता ने MCP इन्फ्रास्ट्रक्चर विकसित किया ताकि कई विशेषज्ञ चिकित्सा AI मॉडलों को एकीकृत किया जा सके, जबकि संवेदनशील रोगी डेटा की सुरक्षा सुनिश्चित की जा सके:

- सामान्य और विशेषज्ञ चिकित्सा मॉडलों के बीच सहज स्विचिंग
- सख्त गोपनीयता नियंत्रण और ऑडिट ट्रेल्स
- मौजूदा इलेक्ट्रॉनिक हेल्थ रिकॉर्ड (EHR) सिस्टम के साथ एकीकरण
- चिकित्सा शब्दावली के लिए सुसंगत प्रॉम्प्ट इंजीनियरिंग

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

**परिणाम:** चिकित्सकों के लिए बेहतर डायग्नोस्टिक सुझाव, पूर्ण HIPAA अनुपालन के साथ, और सिस्टमों के बीच संदर्भ-स्विचिंग में महत्वपूर्ण कमी।

### केस स्टडी 3: वित्तीय सेवाओं जोखिम विश्लेषण

एक वित्तीय संस्था ने अपने विभिन्न विभागों में जोखिम विश्लेषण प्रक्रियाओं को मानकीकृत करने के लिए MCP लागू किया:

- क्रेडिट जोखिम, धोखाधड़ी पहचान, और निवेश जोखिम मॉडलों के लिए एक एकीकृत इंटरफ़ेस बनाया
- सख्त पहुँच नियंत्रण और मॉडल संस्करण प्रबंधन लागू किया
- सभी AI सिफारिशों की ऑडिटेबिलिटी सुनिश्चित की
- विभिन्न सिस्टमों में डेटा स्वरूपण को सुसंगत रखा

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

**परिणाम:** नियामक अनुपालन में सुधार, 40% तेज मॉडल तैनाती चक्र, और विभागों में जोखिम आकलन की स्थिरता में वृद्धि।

### केस स्टडी 4: Microsoft Playwright MCP सर्वर ब्राउज़र स्वचालन के लिए

Microsoft ने Model Context Protocol के माध्यम से सुरक्षित, मानकीकृत ब्राउज़र स्वचालन सक्षम करने के लिए [Playwright MCP सर्वर](https://github.com/microsoft/playwright-mcp) विकसित किया। यह समाधान AI एजेंट्स और LLMs को नियंत्रित, ऑडिटेबल और विस्तार योग्य तरीके से वेब ब्राउज़रों के साथ इंटरैक्ट करने की अनुमति देता है—जैसे स्वचालित वेब परीक्षण, डेटा निष्कर्षण, और एंड-टू-एंड वर्कफ़्लोज़।

- ब्राउज़र स्वचालन क्षमताओं (नेविगेशन, फॉर्म भरना, स्क्रीनशॉट कैप्चर, आदि) को MCP टूल्स के रूप में एक्सपोज़ करता है
- अनधिकृत क्रियाओं को रोकने के लिए सख्त पहुँच नियंत्रण और सैंडबॉक्सिंग लागू करता है
- सभी ब्राउज़र इंटरैक्शन के लिए विस्तृत ऑडिट लॉग प्रदान करता है
- एजेंट-चालित स्वचालन के लिए Azure OpenAI और अन्य LLM प्रदाताओं के साथ एकीकरण का समर्थन करता है

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
- AI एजेंट्स और LLMs के लिए सुरक्षित, प्रोग्रामेटिक ब्राउज़र स्वचालन सक्षम किया  
- मैनुअल परीक्षण प्रयास कम हुए और वेब एप्लिकेशन के लिए परीक्षण कवरेज बेहतर हुआ  
- एंटरप्राइज़ वातावरण में ब्राउज़र-आधारित टूल एकीकरण के लिए पुन: प्रयोज्य, विस्तार योग्य फ्रेमवर्क प्रदान किया

**संदर्भ:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### केस स्टडी 5: Azure MCP – एंटरप्राइज़-ग्रेड Model Context Protocol as a Service

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) Microsoft का प्रबंधित, एंटरप्राइज़-ग्रेड Model Context Protocol कार्यान्वयन है, जो क्लाउड सेवा के रूप में स्केलेबल, सुरक्षित, और अनुपालन MCP सर्वर क्षमताएं प्रदान करता है। Azure MCP संगठनों को MCP सर्वर को Azure AI, डेटा, और सुरक्षा सेवाओं के साथ तेजी से तैनात, प्रबंधित, और एकीकृत करने में सक्षम बनाता है, जिससे परिचालन बोझ कम होता है और AI अपनाने की गति बढ़ती है।

- अंतर्निहित स्केलिंग, मॉनिटरिंग, और सुरक्षा के साथ पूर्ण प्रबंधित MCP सर्वर होस्टिंग  
- Azure OpenAI, Azure AI Search, और अन्य Azure सेवाओं के साथ मूल एकीकरण  
- Microsoft Entra ID के माध्यम से एंटरप्राइज़ प्रमाणीकरण और प्राधिकरण  
- कस्टम टूल्स, प्रॉम्प्ट टेम्प्लेट, और संसाधन कनेक्टर्स का समर्थन  
- एंटरप्राइज़ सुरक्षा और नियामक आवश्यकताओं के साथ अनुपालन

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
- एंटरप्राइज़ AI परियोजनाओं के लिए मूल्य प्राप्ति का समय कम किया, तैयार-से-उपयोग, अनुपालन MCP सर्वर प्लेटफ़ॉर्म प्रदान करके  
- LLMs, टूल्स, और एंटरप्राइज़ डेटा स्रोतों का एकीकरण सरल बनाया  
- MCP वर्कलोड के लिए सुरक्षा, अवलोकनीयता, और परिचालन दक्षता बढ़ाई

**संदर्भ:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## केस स्टडी 6: NLWeb

MCP (Model Context Protocol) एक उभरता हुआ प्रोटोकॉल है जो चैटबॉट्स और AI असिस्टेंट्स को टूल्स के साथ इंटरैक्ट करने में सक्षम बनाता है। प्रत्येक NLWeb इंस्टेंस भी एक MCP सर्वर होता है, जो एक मुख्य मेथड, ask, का समर्थन करता है, जिसका उपयोग वेबसाइट से प्राकृतिक भाषा में प्रश्न पूछने के लिए किया जाता है। प्राप्त उत्तर schema.org का उपयोग करता है, जो वेब डेटा का वर्णन करने के लिए व्यापक रूप से प्रयुक्त शब्दावली है। संक्षेप में कहा जाए तो, MCP NLWeb के समान है जैसे HTTP HTML के लिए होता है। NLWeb प्रोटोकॉल, Schema.org फॉर्मेट्स, और नमूना कोड को मिलाकर साइट्स को तेजी से ये एंडपॉइंट बनाने में मदद करता है, जिससे मनुष्यों को संवादात्मक इंटरफेस और मशीनों को प्राकृतिक एजेंट-टू-एजेंट इंटरैक्शन मिलता है।

NLWeb के दो मुख्य घटक हैं:  
- एक प्रोटोकॉल, जो बहुत सरल है, जो साइट के साथ प्राकृतिक भाषा में इंटरफेस करने के लिए और JSON तथा schema.org का उपयोग करके उत्तर प्रदान करता है। REST API पर दस्तावेज़ देखें।  
- इसका एक सरल कार्यान्वयन जो मौजूदा मार्कअप का उपयोग करता है, उन साइट्स के लिए जो आइटम की सूचियों (उत्पाद, रेसिपी, आकर्षण, समीक्षा आदि) के रूप में सारगर्भित की जा सकती हैं। यूजर इंटरफेस विजेट्स के साथ, साइट्स आसानी से अपने कंटेंट के लिए संवादात्मक इंटरफेस प्रदान कर सकती हैं। Life of a chat query के दस्तावेज़ में विवरण देखें।

**संदर्भ:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

## व्यावहारिक परियोजनाएं

### परियोजना 1: मल्टी-प्रोवाइडर MCP सर्वर बनाएं

**उद्देश्य:** एक MCP सर्वर बनाएं जो विशिष्ट मानदंडों के आधार पर कई AI मॉडल प्रदाताओं को अनुरोध भेज सके।

**आवश्यकताएं:**  
- कम से कम तीन विभिन्न मॉडल प्रदाताओं का समर्थन (जैसे OpenAI, Anthropic, स्थानीय मॉडल)  
- अनुरोध मेटाडेटा के आधार पर रूटिंग तंत्र लागू करें  
- प्रदाता क्रेडेंशियल्स प्रबंधन के लिए कॉन्फ़िगरेशन सिस्टम बनाएं  
- प्रदर्शन और लागत को अनुकूलित करने के लिए कैशिंग जोड़ें  
- उपयोग की निगरानी के लिए एक सरल डैशबोर्ड बनाएं

**कार्यान्वयन चरण:**  
1. मूल MCP सर्वर इन्फ्रास्ट्रक्चर सेटअप करें  
2. प्रत्येक AI मॉडल सेवा के लिए प्रदाता एडाप्टर लागू करें  
3. अनुरोध गुणों के आधार पर रूटिंग लॉजिक बनाएं  
4. बार-बार आने वाले अनुरोधों के लिए कैशिंग तंत्र जोड़ें  
5. निगरानी डैशबोर्ड विकसित करें  
6. विभिन्न अनुरोध पैटर्न के साथ परीक्षण करें

**प्रौद्योगिकियां:** Python (.NET/Java/Python अपनी पसंद के अनुसार), Redis कैशिंग के लिए, और डैशबोर्ड के लिए एक सरल वेब फ्रेमवर्क।

### परियोजना 2: एंटरप्राइज़ प्रॉम्प्ट प्रबंधन प्रणाली

**उद्देश्य:** संगठन भर में प्रॉम्प्ट टेम्प्लेट्स के प्रबंधन, संस्करण नियंत्रण, और तैनाती के लिए MCP-आधारित प्रणाली विकसित करें।

**आवश्यकताएं:**  
- प्रॉम्प्ट टेम्प्लेट्स के लिए केंद्रीकृत रिपॉजिटरी बनाएं  
- संस्करण नियंत्रण और अनुमोदन वर्कफ़्लोज़ लागू करें  
- नमूना इनपुट के साथ टेम्प्लेट परीक्षण क्षमता विकसित करें  
- भूमिका-आधारित पहुँच नियंत्रण बनाएं  
- टेम्प्लेट पुनः प्राप्ति और तैनाती के लिए API बनाएं

**कार्यान्वयन चरण:**  
1. टेम्प्लेट संग्रहण के लिए डेटाबेस स्कीमा डिज़ाइन करें  
2. टेम्प्लेट CRUD ऑपरेशंस के लिए कोर API बनाएं  
3. संस्करण नियंत्रण प्रणाली लागू करें  
4. अनुमोदन वर्कफ़्लो बनाएं  
5. परीक्षण फ्रेमवर्क विकसित करें  
6. प्रबंधन के लिए एक सरल वेब इंटरफ़ेस बनाएं  
7. MCP सर्वर के साथ एकीकरण करें

**प्रौद्योगिकियां:** आपकी पसंद का बैकएंड फ्रेमवर्क, SQL या NoSQL डेटाबेस, और प्रबंधन इंटरफ़ेस के लिए फ्रंटेंड फ्रेमवर्क।

### परियोजना 3: MCP-आधारित सामग्री निर्माण प्लेटफ़ॉर्म

**उद्देश्य:** एक सामग्री निर्माण प्लेटफ़ॉर्म बनाएं जो MCP का उपयोग करके विभिन्न सामग्री प्रकारों में सुसंगत परिणाम प्रदान करे।

**आवश्यकताएं:**  
- कई सामग्री स्वरूपों का समर्थन (ब्लॉग पोस्ट, सोशल मीडिया, मार्केटिंग कॉपी)  
- कस्टमाइज़ेशन विकल्पों के साथ टेम्प्लेट-आधारित निर्माण लागू करें  
- सामग्री समीक्षा और प्रतिक्रिया प्रणाली बनाएं  
- सामग्री प्रदर्शन मेट्रिक्स ट्रैक करें  
- सामग्री संस्करण नियंत्रण और पुनरावृत्ति का समर्थन करें

**कार्यान्वयन चरण:**  
1. MCP क्लाइंट इन्फ्रास्ट्रक्चर सेटअप करें  
2. विभिन्न सामग्री प्रकारों के लिए टेम्प्लेट बनाएं  
3. सामग्री निर्माण पाइपलाइन बनाएं  
4. समीक्षा प्रणाली लागू करें  
5. मेट्रिक्स ट्रैकिंग सिस्टम विकसित करें  
6. टेम्प्लेट प्रबंधन और सामग्री निर्माण के लिए यूजर इंटरफ़ेस बनाएं

**प्रौद्योगिकियां:** आपकी पसंदीदा प्रोग्रामिंग भाषा, वेब फ्रेमवर्क, और डेटाबेस सिस्टम।

## MCP तकनीक के लिए भविष्य की दिशाएँ

### उभरते रुझान

1. **मल्टी-मॉडल MCP**  
   - छवि, ऑडियो, और वीडियो मॉडलों के साथ इंटरैक्शन को मानकीकृत करने के लिए MCP का विस्तार  
   - क्रॉस-मॉडल तर्क क्षमताओं का विकास  
   - विभिन्न मोडैलिटी के लिए मानकीकृत प्रॉम्प्ट फॉर्मेट्स

2. **फेडरेटेड MCP इन्फ्रास्ट्रक्चर**  
   - संगठनों के बीच संसाधनों को साझा करने वाले वितरित MCP नेटवर्क  
   - सुरक्षित मॉडल साझा करने के लिए मानकीकृत प्रोटोकॉल  
   - गोपनीयता-संरक्षित गणना तकनीकें

3. **MCP मार्केटप्लेस**  
   - MCP टेम्प्लेट्स और प्लगइन्स साझा करने और मुद्रीकरण के लिए इकोसिस्टम  
   - गुणवत्ता आश्वासन और प्रमाणन प्रक्रियाएं  
   - मॉडल मार्केटप्लेस के साथ एकीकरण

4. **एज कंप्यूटिंग के लिए MCP**  
   - संसाधन-सीमित एज डिवाइसेस के लिए MCP मानकों का अनुकूलन  
   - कम-बैंडविड्थ वातावरण के लिए अनुकूलित प्रोटोकॉल  
   - IoT इकोसिस्टम के लिए विशेष MCP कार्यान्वयन

5. **नियामक फ्रेमवर्क**  
   - नियामक अनुपालन के लिए MCP एक्सटेंशन्स का विकास  
   - मानकीकृत ऑडिट ट्रेल्स और व्याख्यात्मक इंटरफेस  
   - उभरते AI शासन फ्रेमवर्क के साथ एकीकरण

### Microsoft से MCP समाधान

Microsoft और Azure ने विभिन्न परिदृश्यों में MCP कार्यान्वयन में मदद के लिए कई ओपन-सोर्स रिपॉजिटरी विकसित किए हैं:

#### Microsoft संगठन  
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - ब्राउज़र स्वचालन और परीक्षण के लिए Playwright MCP सर्वर  
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - स्थानीय परीक्षण और सामुदायिक योगदान के लिए OneDrive MCP सर्वर कार्यान्वयन  
3. [NLWeb](https://github.com/microsoft/NlWeb) - AI वेब के लिए एक आधारभूत परत स्थापित करने पर केंद्रित ओपन प्रोटोकॉल और टूल्स का संग्रह  

#### Azure-Samples संगठन  
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure पर MCP सर्वर बनाने और एकीकृत करने के लिए नमूने, टूल्स, और संसाधन  
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - Model Context Protocol विनिर्देश के साथ प्रमाणीकरण दिखाने वाले संदर्भ MCP सर्वर  
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions में रिमोट MCP सर्वर कार्यान्वयन के लिए लैंडिंग पेज  
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure Functions के साथ Python में कस्टम रिमोट MCP सर्वर बनाने और तैनात करने के लिए क्विकस्टार्ट टेम्प्लेट  
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - .NET/C# के लिए क्विकस्टार्ट टेम्प्लेट  
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - TypeScript के लिए क्विकस्टार्ट टेम्प्लेट  
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Python का उपयोग करते हुए रिमोट MCP सर्वरों के लिए Azure API प्रबंधन  
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - MCP क्षमताओं सहित APIM ❤️ AI प्रयोग, Azure OpenAI और AI Foundry के साथ एकीकरण

ये रिपॉजिटरी विभिन्न प्रोग्रामिंग भाषाओं और Azure सेवाओं में Model Context Protocol के साथ काम करने के लिए विभिन्न कार्यान्वयन, टेम्प्लेट, और संसाधन प्रदान करते हैं। ये बुनियादी सर्वर कार्यान्वयन से लेकर प्रमाणीकरण, क्लाउड तैनाती, और एंटरप्राइज़ एकीकरण परिदृश्यों तक कई उपयोग मामलों को कवर करते हैं।

#### MCP संसाधन निर्देशिका

[MCP Resources directory](https://github.com/microsoft/mcp/tree/main/Resources) आधिकारिक Microsoft MCP रिपॉजिटरी में एक संग्रह है जो
- [Remote MCP Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Remote MCP Functions .NET (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Remote MCP Functions TypeScript (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-functions-typescript)
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## अभ्यास

1. किसी एक केस स्टडी का विश्लेषण करें और वैकल्पिक कार्यान्वयन दृष्टिकोण प्रस्तावित करें।
2. किसी एक प्रोजेक्ट आइडिया को चुनें और एक विस्तृत तकनीकी विनिर्देशन तैयार करें।
3. उस उद्योग पर शोध करें जो केस स्टडी में शामिल नहीं है और बताएं कि MCP उसकी विशिष्ट चुनौतियों को कैसे संबोधित कर सकता है।
4. भविष्य की दिशा में से एक को खोजें और उसे समर्थन देने के लिए MCP एक्सटेंशन का एक नया कॉन्सेप्ट बनाएं।

अगला: [Best Practices](../08-BestPractices/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनूदित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या गलतियाँ हो सकती हैं। मूल दस्तावेज़ को उसकी मूल भाषा में प्राधिकृत स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सिफारिश की जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।