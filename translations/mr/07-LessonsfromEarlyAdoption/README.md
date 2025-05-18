<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a6482c201133cb6cb0742918b373a523",
  "translation_date": "2025-05-17T16:11:36+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "mr"
}
-->
# प्रारंभिक स्वीकारकर्त्यांकडून शिकलेले धडे

## विहंगावलोकन

ही शिकवणी कशी प्रारंभिक स्वीकारकर्त्यांनी मॉडेल संदर्भ प्रोटोकॉल (MCP) चा उपयोग करून वास्तविक-जागतिक आव्हानांचे निराकरण केले आणि उद्योगांमध्ये नवकल्पना कशी चालवली ते तपासते. सविस्तर प्रकरण अभ्यास आणि व्यावहारिक प्रकल्पांद्वारे, तुम्हाला दिसेल की MCP कसे प्रमाणित, सुरक्षित आणि स्केलेबल AI एकत्रीकरण सक्षम करते - मोठ्या भाषा मॉडेल्स, साधने आणि एंटरप्राइझ डेटा एका एकीकृत फ्रेमवर्कमध्ये जोडणे. MCP-आधारित उपायांची रचना आणि बांधणी करण्याचा व्यावहारिक अनुभव तुम्हाला मिळेल, सिद्ध अंमलबजावणी पद्धतींमधून शिकाल आणि उत्पादन वातावरणात MCP तैनात करण्यासाठी सर्वोत्तम पद्धती शोधाल. ही शिकवणी उदयोन्मुख ट्रेंड, भविष्यातील दिशा आणि मुक्त-स्रोत संसाधनांवर देखील प्रकाश टाकते जेणेकरून तुम्ही MCP तंत्रज्ञानाच्या अग्रभागी राहू शकाल आणि त्याच्या उत्क्रांत होणाऱ्या परिसंस्थेत राहू शकाल.

## शिकण्याची उद्दिष्टे

- विविध उद्योगांमधील वास्तविक-जागतिक MCP अंमलबजावणीचे विश्लेषण करा
- संपूर्ण MCP-आधारित अनुप्रयोग डिझाइन आणि तयार करा
- MCP तंत्रज्ञानातील उदयोन्मुख ट्रेंड आणि भविष्यातील दिशा शोधा
- वास्तविक विकास परिस्थितींमध्ये सर्वोत्तम पद्धती लागू करा

## वास्तविक-जागतिक MCP अंमलबजावणी

### प्रकरण अभ्यास 1: एंटरप्राइझ ग्राहक समर्थन स्वयंचलन

एका बहुराष्ट्रीय कंपनीने त्यांच्या ग्राहक समर्थन प्रणालींमध्ये AI संवादांचे प्रमाणित करण्यासाठी MCP-आधारित उपाय अंमलात आणला. यामुळे त्यांना हे करता आले:

- एकाधिक LLM प्रदात्यांसाठी एक एकीकृत इंटरफेस तयार करा
- विभागांमध्ये सुसंगत प्रॉम्प्ट व्यवस्थापन राखा
- मजबूत सुरक्षा आणि अनुपालन नियंत्रण लागू करा
- विशिष्ट गरजांनुसार विविध AI मॉडेल्समध्ये सहजपणे स्विच करा

**तांत्रिक अंमलबजावणी:**
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

**परिणाम:** मॉडेल खर्चात 30% कपात, प्रतिसाद सुसंगततेत 45% सुधारणा आणि जागतिक ऑपरेशन्समध्ये वाढलेले अनुपालन.

### प्रकरण अभ्यास 2: आरोग्य सेवा निदान सहाय्यक

एका आरोग्य सेवा प्रदात्याने संवेदनशील रुग्ण डेटा संरक्षित ठेवताना एकाधिक विशेष वैद्यकीय AI मॉडेल्स एकत्रित करण्यासाठी MCP पायाभूत सुविधा विकसित केल्या:

- सामान्य आणि विशेषज्ञ वैद्यकीय मॉडेल्स दरम्यान अखंड स्विचिंग
- कडक गोपनीयता नियंत्रण आणि ऑडिट ट्रेल्स
- विद्यमान इलेक्ट्रॉनिक हेल्थ रेकॉर्ड (EHR) प्रणालींसह एकत्रीकरण
- वैद्यकीय शब्दावलीसाठी सुसंगत प्रॉम्प्ट अभियांत्रिकी

**तांत्रिक अंमलबजावणी:**
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

**परिणाम:** HIPAA अनुपालन पूर्णपणे राखून आणि प्रणालींमधील संदर्भ-स्विचिंगमध्ये लक्षणीय घट राखून फिजिशियनसाठी सुधारित निदान सूचना.

### प्रकरण अभ्यास 3: वित्तीय सेवा जोखीम विश्लेषण

एका वित्तीय संस्थेने त्यांच्या विविध विभागांमधील जोखीम विश्लेषण प्रक्रियांचे प्रमाणित करण्यासाठी MCP लागू केले:

- क्रेडिट जोखीम, फसवणूक शोध आणि गुंतवणूक जोखीम मॉडेल्ससाठी एक एकीकृत इंटरफेस तयार केला
- कठोर प्रवेश नियंत्रण आणि मॉडेल आवृत्तीकरण लागू केले
- सर्व AI शिफारसींच्या ऑडिटेबिलिटीची खात्री केली
- विविध प्रणालींमध्ये सुसंगत डेटा स्वरूपन राखले

**तांत्रिक अंमलबजावणी:**
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

**परिणाम:** वाढलेले नियामक अनुपालन, 40% जलद मॉडेल तैनाती चक्र, आणि विभागांमध्ये सुधारित जोखीम मूल्यांकन सुसंगतता.

### प्रकरण अभ्यास 4: ब्राउझर ऑटोमेशनसाठी Microsoft Playwright MCP सर्व्हर

मॉडेल संदर्भ प्रोटोकॉलद्वारे सुरक्षित, प्रमाणित ब्राउझर ऑटोमेशन सक्षम करण्यासाठी मायक्रोसॉफ्टने [Playwright MCP सर्व्हर](https://github.com/microsoft/playwright-mcp) विकसित केला. हे उपाय AI एजंट्स आणि LLMs ला नियंत्रित, ऑडिट करण्यायोग्य आणि विस्तारण्यायोग्य मार्गाने वेब ब्राउझरसह संवाद साधण्याची परवानगी देते - स्वयंचलित वेब चाचणी, डेटा काढणे आणि एंड-टू-एंड कार्यप्रवाह यांसारख्या वापर प्रकरणांना सक्षम करते.

- ब्राउझर ऑटोमेशन क्षमता (नेव्हिगेशन, फॉर्म भरणे, स्क्रीनशॉट कॅप्चर इ.) MCP साधन म्हणून उघड करते
- अनधिकृत क्रियाकलाप रोखण्यासाठी कठोर प्रवेश नियंत्रण आणि सॅंडबॉक्सिंग लागू करते
- सर्व ब्राउझर संवादांसाठी तपशीलवार ऑडिट लॉग प्रदान करते
- एजंट-चालित ऑटोमेशनसाठी Azure OpenAI आणि इतर LLM प्रदात्यांसह एकत्रीकरणाला समर्थन देते

**तांत्रिक अंमलबजावणी:**
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
- AI एजंट्स आणि LLMs साठी सुरक्षित, प्रोग्रामेटिक ब्राउझर ऑटोमेशन सक्षम केले
- मॅन्युअल चाचणी प्रयत्न कमी केले आणि वेब अनुप्रयोगांसाठी चाचणी कव्हरेज सुधारले
- एंटरप्राइझ वातावरणातील ब्राउझर-आधारित साधन एकत्रीकरणासाठी पुनर्वापर करण्यायोग्य, विस्तारण्यायोग्य फ्रेमवर्क प्रदान केले

**संदर्भ:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### प्रकरण अभ्यास 5: Azure MCP – सेवा म्हणून एंटरप्राइझ-ग्रेड मॉडेल संदर्भ प्रोटोकॉल

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) हे मायक्रोसॉफ्टचे व्यवस्थापित, एंटरप्राइझ-ग्रेड मॉडेल संदर्भ प्रोटोकॉलची अंमलबजावणी आहे, जे क्लाउड सेवेसारखे स्केलेबल, सुरक्षित आणि अनुपालन MCP सर्व्हर क्षमता प्रदान करण्यासाठी डिझाइन केले आहे. Azure MCP संस्थांना MCP सर्व्हर जलद तैनात, व्यवस्थापित आणि एकत्रित करण्यास सक्षम करते Azure AI, डेटा, आणि सुरक्षा सेवा, ऑपरेशनल ओव्हरहेड कमी करून आणि AI स्वीकारण्याची गती वाढवते.

- अंगभूत स्केलिंग, मॉनिटरिंग आणि सुरक्षा असलेल्या पूर्णपणे व्यवस्थापित MCP सर्व्हर होस्टिंग
- Azure OpenAI, Azure AI Search आणि इतर Azure सेवांसह मूळ एकत्रीकरण
- Microsoft Entra ID द्वारे एंटरप्राइझ प्रमाणीकरण आणि अधिकृतता
- सानुकूल साधने, प्रॉम्प्ट टेम्पलेट्स, आणि संसाधन कनेक्टरसाठी समर्थन
- एंटरप्राइझ सुरक्षा आणि नियामक आवश्यकतांचे अनुपालन

**तांत्रिक अंमलबजावणी:**
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
- तयार-टू-यूज, अनुपालन MCP सर्व्हर प्लॅटफॉर्म प्रदान करून एंटरप्राइझ AI प्रकल्पांसाठी वेळ कमी केला
- LLMs, साधने, आणि एंटरप्राइझ डेटा स्रोतांचे एकत्रीकरण सुलभ केले
- MCP वर्कलोडसाठी वाढलेली सुरक्षा, निरीक्षणक्षमता, आणि ऑपरेशनल कार्यक्षमता

**संदर्भ:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## व्यावहारिक प्रकल्प

### प्रकल्प 1: मल्टी-प्रोव्हायडर MCP सर्व्हर तयार करा

**उद्दिष्ट:** विशिष्ट निकषांवर आधारित एकाधिक AI मॉडेल प्रदात्यांकडे विनंत्या मार्गदर्शन करू शकणारा MCP सर्व्हर तयार करा.

**आवश्यकता:**
- किमान तीन वेगवेगळ्या मॉडेल प्रदात्यांना समर्थन द्या (उदा., OpenAI, Anthropic, स्थानिक मॉडेल्स)
- विनंती मेटाडेटावर आधारित एक मार्गदर्शन यंत्रणा लागू करा
- प्रदाता क्रेडेन्शियल्स व्यवस्थापित करण्यासाठी एक कॉन्फिगरेशन प्रणाली तयार करा
- कार्यक्षमता आणि खर्च अनुकूलित करण्यासाठी कॅशिंग जोडा
- वापराचे निरीक्षण करण्यासाठी एक साधे डॅशबोर्ड तयार करा

**अंमलबजावणी चरण:**
1. मूलभूत MCP सर्व्हर पायाभूत सुविधा सेट करा
2. प्रत्येक AI मॉडेल सेवेसाठी प्रदाता अडॅप्टर लागू करा
3. विनंती गुणधर्मांवर आधारित मार्गदर्शन लॉजिक तयार करा
4. वारंवार विनंत्यांसाठी कॅशिंग यंत्रणा जोडा
5. मॉनिटरिंग डॅशबोर्ड विकसित करा
6. विविध विनंती नमुन्यांसह चाचणी करा

**तंत्रज्ञान:** तुमच्या पसंतीनुसार Python (.NET/Java/Python), Redis कॅशिंगसाठी, आणि डॅशबोर्डसाठी एक साधे वेब फ्रेमवर्क निवडा.

### प्रकल्प 2: एंटरप्राइझ प्रॉम्प्ट व्यवस्थापन प्रणाली

**उद्दिष्ट:** संपूर्ण संस्थेत प्रॉम्प्ट टेम्पलेट्सचे व्यवस्थापन, आवृत्तीकरण आणि तैनात करण्यासाठी MCP-आधारित प्रणाली विकसित करा.

**आवश्यकता:**
- प्रॉम्प्ट टेम्पलेट्ससाठी एक केंद्रीकृत रेपॉझिटरी तयार करा
- आवृत्तीकरण आणि मंजूरी कार्यप्रवाह लागू करा
- नमुना इनपुटसह टेम्पलेट चाचणी क्षमता तयार करा
- भूमिकेवर आधारित प्रवेश नियंत्रण विकसित करा
- टेम्पलेट पुनर्प्राप्ती आणि तैनातीसाठी API तयार करा

**अंमलबजावणी चरण:**
1. टेम्पलेट स्टोरेजसाठी डेटाबेस स्कीमा डिझाइन करा
2. टेम्पलेट CRUD ऑपरेशन्ससाठी मुख्य API तयार करा
3. आवृत्तीकरण प्रणाली लागू करा
4. मंजूरी कार्यप्रवाह तयार करा
5. चाचणी फ्रेमवर्क विकसित करा
6. व्यवस्थापनासाठी एक साधे वेब इंटरफेस तयार करा
7. MCP सर्व्हरसह एकत्रित करा

**तंत्रज्ञान:** तुमच्या पसंतीच्या बॅकएंड फ्रेमवर्क, SQL किंवा NoSQL डेटाबेस, आणि व्यवस्थापन इंटरफेससाठी फ्रंटेंड फ्रेमवर्क निवडा.

### प्रकल्प 3: MCP-आधारित सामग्री निर्मिती प्लॅटफॉर्म

**उद्दिष्ट:** विविध सामग्री प्रकारांमध्ये सुसंगत परिणाम प्रदान करण्यासाठी MCP चा लाभ घेणारा सामग्री निर्मिती प्लॅटफॉर्म तयार करा.

**आवश्यकता:**
- एकाधिक सामग्री स्वरूपांना समर्थन द्या (ब्लॉग पोस्ट्स, सोशल मीडिया, मार्केटिंग कॉपी)
- सानुकूलन पर्यायांसह टेम्पलेट-आधारित निर्मिती लागू करा
- सामग्री पुनरावलोकन आणि अभिप्राय प्रणाली तयार करा
- सामग्री कामगिरी मेट्रिक्स ट्रॅक करा
- सामग्री आवृत्तीकरण आणि पुनरावृत्तीला समर्थन द्या

**अंमलबजावणी चरण:**
1. MCP क्लायंट पायाभूत सुविधा सेट करा
2. विविध सामग्री प्रकारांसाठी टेम्पलेट्स तयार करा
3. सामग्री निर्मिती पाइपलाइन तयार करा
4. पुनरावलोकन प्रणाली लागू करा
5. मेट्रिक्स ट्रॅकिंग प्रणाली विकसित करा
6. टेम्पलेट व्यवस्थापन आणि सामग्री निर्मितीसाठी एक वापरकर्ता इंटरफेस तयार करा

**तंत्रज्ञान:** तुमची पसंतीची प्रोग्रामिंग भाषा, वेब फ्रेमवर्क, आणि डेटाबेस प्रणाली निवडा.

## MCP तंत्रज्ञानासाठी भविष्यातील दिशा

### उदयोन्मुख ट्रेंड

1. **मल्टी-मोडल MCP**
   - प्रतिमा, ऑडिओ, आणि व्हिडिओ मॉडेल्ससह संवाद प्रमाणित करण्यासाठी MCP चे विस्तार
   - क्रॉस-मोडल विचार करण्याच्या क्षमतांचा विकास
   - विविध प्रकारांसाठी प्रमाणित प्रॉम्प्ट स्वरूप

2. **फेडरेटेड MCP पायाभूत संरचना**
   - वितरित MCP नेटवर्क्स जे संसाधने संस्थांमध्ये शेअर करू शकतात
   - सुरक्षित मॉडेल शेअरिंगसाठी प्रमाणित प्रोटोकॉल
   - गोपनीयता-संरक्षण संगणन तंत्रे

3. **MCP मार्केटप्लेस**
   - MCP टेम्पलेट्स आणि प्लगइन्स शेअर आणि मॅनेटाइज करण्यासाठी परिसंस्था
   - गुणवत्ता आश्वासन आणि प्रमाणन प्रक्रिया
   - मॉडेल मार्केटप्लेससह एकत्रीकरण

4. **एज कॉम्प्युटिंगसाठी MCP**
   - संसाधन-प्रतिबंधित एज डिव्हाइसेससाठी MCP मानकांचे अनुकूलन
   - कमी-बँडविड्थ वातावरणासाठी अनुकूलित प्रोटोकॉल
   - IoT परिसंस्थांसाठी विशेष MCP अंमलबजावणी

5. **नियामक फ्रेमवर्क्स**
   - नियामक अनुपालनासाठी MCP विस्तारांचा विकास
   - प्रमाणित ऑडिट ट्रेल्स आणि स्पष्टीकरणात्मक इंटरफेस
   - उदयोन्मुख AI गव्हर्नन्स फ्रेमवर्कसह एकत्रीकरण

### Microsoft कडून MCP उपाय

Microsoft आणि Azure ने विकसकांना विविध परिस्थितींमध्ये MCP लागू करण्यात मदत करण्यासाठी अनेक ओपन-सोर्स रेपॉझिटरी विकसित केल्या आहेत:

#### Microsoft संस्था
1. [playwright-mcp](https://github.com/microsoft/playwright-mcp) - ब्राउझर ऑटोमेशन आणि चाचणीसाठी Playwright MCP सर्व्हर
2. [files-mcp-server](https://github.com/microsoft/files-mcp-server) - स्थानिक चाचणी आणि समुदाय योगदानासाठी OneDrive MCP सर्व्हर अंमलबजावणी

#### Azure-Samples संस्था
1. [mcp](https://github.com/Azure-Samples/mcp) - Azure वर MCP सर्व्हर तयार करण्यासाठी आणि एकत्रित करण्यासाठी नमुने, साधने, आणि संसाधनांचे दुवे
2. [mcp-auth-servers](https://github.com/Azure-Samples/mcp-auth-servers) - वर्तमान मॉडेल संदर्भ प्रोटोकॉल तपशीलांसह प्रमाणीकरण दर्शविणारे संदर्भ MCP सर्व्हर
3. [remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions) - Azure Functions मध्ये Remote MCP Server अंमलबजावणीसाठी लँडिंग पृष्ठ, भाषेसाठी विशिष्ट रेपॉझिटरीसाठी दुवे
4. [remote-mcp-functions-python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure Functions सह Python वापरून सानुकूल रिमोट MCP सर्व्हर तयार आणि तैनात करण्यासाठी जलद प्रारंभ टेम्पलेट
5. [remote-mcp-functions-dotnet](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Azure Functions सह .NET/C# वापरून सानुकूल रिमोट MCP सर्व्हर तयार आणि तैनात करण्यासाठी जलद प्रारंभ टेम्पलेट
6. [remote-mcp-functions-typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Azure Functions सह TypeScript वापरून सानुकूल रिमोट MCP सर्व्हर तयार आणि तैनात करण्यासाठी जलद प्रारंभ टेम्पलेट
7. [remote-mcp-apim-functions-python](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) - Python वापरून Remote MCP सर्व्हरला AI गेटवे म्हणून Azure API Management
8. [AI-Gateway](https://github.com/Azure-Samples/AI-Gateway) - APIM ❤️ AI प्रयोग ज्यात MCP क्षमता, Azure OpenAI आणि AI Foundry सह एकत्रीकरण

हे रेपॉझिटरी विविध प्रोग्रामिंग भाषांमध्ये आणि Azure सेवांमध्ये मॉडेल संदर्भ प्रोटोकॉलसह कार्य करण्यासाठी विविध अंमलबजावणी, टेम्पलेट्स, आणि संसाधने प्रदान करतात. ते मूलभूत सर्व्हर अंमलबजावणीपासून प्रमाणीकरण, क्लाउड तैनाती, आणि एंटरप्राइझ एकत्रीकरण परिस्थितीपर्यंत विविध वापर प्रकरणे समाविष्ट करतात.

#### MCP संसाधने निर्देशिका

अधिकृत Microsoft MCP रेपॉझिटरीमधील [MCP Resources निर्देशिका](https://github.com/microsoft/mcp/tree/main/Resources) मॉडेल संदर्भ प्रोटोकॉल सर्व्हरसह वापरण्यासाठी नमुना संसाधने, प्रॉम्प्ट टेम्पलेट्स, आणि साधन परिभाषांचा एक क्युरेटेड संग्रह प्रदान करते. MCP सह जलद प्रारंभ करण्यासाठी पुनर्वापर करण्यायोग्य बिल्डिंग ब्लॉक्स आणि सर्वोत्तम-अभ्यास उदाहरणे ऑफर करून विकसकांना मदत करण्यासाठी ही निर्देशिका डिझाइन केली आहे:

- **प्रॉम्प्ट टेम्पलेट्स:** सामान्य AI कार्ये आणि परिस्थित
- [Remote MCP APIM Functions Python (Azure-Samples)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [AI-Gateway (Azure-Samples)](https://github.com/Azure-Samples/AI-Gateway)
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

## व्यायाम

1. एक केस स्टडी विश्लेषित करा आणि पर्यायी अंमलबजावणी दृष्टिकोन प्रस्तावित करा.
2. प्रकल्प कल्पनांपैकी एक निवडा आणि तपशीलवार तांत्रिक तपशील तयार करा.
3. केस स्टडीमध्ये समाविष्ट नसलेल्या उद्योगाचा संशोधन करा आणि MCP त्याच्या विशिष्ट आव्हानांना कसे संबोधित करू शकते हे नमूद करा.
4. भविष्यातील दिशानिर्देशांपैकी एकाचा शोध घ्या आणि त्याला समर्थन देण्यासाठी नवीन MCP विस्ताराची संकल्पना तयार करा.

पुढे: [सर्वोत्तम पद्धती](../08-BestPractices/README.md)

**अस्वीकृति**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित करण्यात आला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादात चुका किंवा अपूर्णता असू शकतात. मूळ भाषेतील दस्तऐवज अधिकृत स्रोत म्हणून विचारात घेतला पाहिजे. महत्त्वपूर्ण माहितीसाठी, व्यावसायिक मानवी अनुवादाची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमज किंवा चुकीच्या अर्थाबद्दल आम्ही जबाबदार नाही.