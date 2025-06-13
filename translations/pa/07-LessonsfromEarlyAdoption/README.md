<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "26d41919cb423a87e067a3da8334e44a",
  "translation_date": "2025-06-13T17:05:58+00:00",
  "source_file": "07-LessonsfromEarlyAdoption/README.md",
  "language_code": "pa"
}
-->
# ਸ਼ੁਰੂਆਤੀ ਅਪਣਾਉਣ ਵਾਲਿਆਂ ਤੋਂ ਸਿੱਖਿਆ

## ਝਲਕ

ਇਸ ਪਾਠ ਵਿੱਚ ਵੇਖਿਆ ਗਿਆ ਹੈ ਕਿ ਸ਼ੁਰੂਆਤੀ ਅਪਣਾਉਣ ਵਾਲਿਆਂ ਨੇ Model Context Protocol (MCP) ਨੂੰ ਕਿਵੇਂ ਵਰਤਿਆ ਹੈ ਤਾਂ ਜੋ ਵੱਖ-ਵੱਖ ਉਦਯੋਗਾਂ ਵਿੱਚ ਅਸਲੀ ਦੁਨੀਆ ਦੀਆਂ ਚੁਣੌਤੀਆਂ ਦਾ ਹੱਲ ਕੱਢਿਆ ਜਾ ਸਕੇ ਅਤੇ ਨਵੀਨਤਾ ਨੂੰ ਤੇਜ਼ ਕੀਤਾ ਜਾ ਸਕੇ। ਵਿਸਥਾਰ ਨਾਲ ਕੇਸ ਅਧਿਐਨ ਅਤੇ ਹੱਥ-ਅਨੁਭਵ ਪ੍ਰੋਜੈਕਟਾਂ ਰਾਹੀਂ, ਤੁਸੀਂ ਦੇਖੋਗੇ ਕਿ MCP ਕਿਵੇਂ ਇੱਕ ਮਿਆਰੀ, ਸੁਰੱਖਿਅਤ ਅਤੇ ਸਕੇਲਬਲ AI ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਮੁਹੱਈਆ ਕਰਦਾ ਹੈ—ਜੋ ਵੱਡੇ ਭਾਸ਼ਾਈ ਮਾਡਲਾਂ, ਟੂਲਾਂ ਅਤੇ ਉਦਯੋਗਿਕ ਡਾਟਾ ਨੂੰ ਇੱਕ ਇਕੱਠੇ ਫਰੇਮਵਰਕ ਵਿੱਚ ਜੋੜਦਾ ਹੈ। ਤੁਸੀਂ MCP-ਅਧਾਰਿਤ ਹੱਲ ਡਿਜ਼ਾਈਨ ਕਰਨ ਅਤੇ ਬਣਾਉਣ ਦਾ ਪ੍ਰਯੋਗਿਕ ਅਨੁਭਵ ਪ੍ਰਾਪਤ ਕਰੋਗੇ, ਸਾਬਤ ਹੋਏ ਅਮਲ ਦੇ ਨਮੂਨੇ ਸਿੱਖੋਗੇ ਅਤੇ MCP ਨੂੰ ਪ੍ਰੋਡਕਸ਼ਨ ਵਾਤਾਵਰਣ ਵਿੱਚ ਲਾਗੂ ਕਰਨ ਲਈ ਵਧੀਆ ਅਭਿਆਸ ਜਾਣੋਗੇ। ਇਹ ਪਾਠ ਉਭਰ ਰਹੀਆਂ ਰੁਝਾਨਾਂ, ਭਵਿੱਖ ਦੀਆਂ ਦਿਸ਼ਾਵਾਂ ਅਤੇ ਖੁੱਲ੍ਹੇ ਸਰੋਤ ਸਾਧਨਾਂ ਨੂੰ ਵੀ ਰੋਸ਼ਨ ਕਰਦਾ ਹੈ ਤਾਂ ਜੋ ਤੁਸੀਂ MCP ਤਕਨਾਲੋਜੀ ਅਤੇ ਇਸਦੇ ਵਿਕਾਸਸ਼ੀਲ ਇਕੋਸਿਸਟਮ ਦੇ ਅੱਗੇ ਰਹਿ ਸਕੋ।

## ਸਿੱਖਣ ਦੇ ਲਕੜੀ

- ਵੱਖ-ਵੱਖ ਉਦਯੋਗਾਂ ਵਿੱਚ MCP ਦੇ ਅਸਲੀ ਦੁਨੀਆ ਦੇ ਅਮਲਾਂ ਦਾ ਵਿਸ਼ਲੇਸ਼ਣ ਕਰਨਾ
- MCP-ਅਧਾਰਿਤ ਪੂਰੇ ਐਪਲੀਕੇਸ਼ਨ ਡਿਜ਼ਾਈਨ ਅਤੇ ਤਿਆਰ ਕਰਨਾ
- MCP ਤਕਨਾਲੋਜੀ ਵਿੱਚ ਉਭਰ ਰਹੀਆਂ ਰੁਝਾਨਾਂ ਅਤੇ ਭਵਿੱਖ ਦੀਆਂ ਦਿਸ਼ਾਵਾਂ ਦੀ ਖੋਜ ਕਰਨਾ
- ਅਸਲੀ ਵਿਕਾਸ ਸੰਦਰਭਾਂ ਵਿੱਚ ਵਧੀਆ ਅਭਿਆਸ ਲਾਗੂ ਕਰਨਾ

## ਅਸਲੀ ਦੁਨੀਆ ਵਿੱਚ MCP ਦੇ ਅਮਲ

### ਕੇਸ ਅਧਿਐਨ 1: ਐਂਟਰਪ੍ਰਾਈਜ਼ ਕਸਟਮਰ ਸਪੋਰਟ ਆਟੋਮੇਸ਼ਨ

ਇੱਕ ਬਹੁ-ਰਾਸ਼ਟਰੀ ਕੰਪਨੀ ਨੇ MCP-ਅਧਾਰਿਤ ਹੱਲ ਲਾਗੂ ਕੀਤਾ ਤਾਂ ਜੋ ਉਹ ਆਪਣੇ ਕਸਟਮਰ ਸਪੋਰਟ ਸਿਸਟਮਾਂ ਵਿੱਚ AI ਇੰਟਰੈਕਸ਼ਨਾਂ ਨੂੰ ਮਿਆਰੀਕृत ਕਰ ਸਕੇ। ਇਸ ਨਾਲ ਉਹਨਾਂ ਨੂੰ ਇਹ ਸਹੂਲਤ ਮਿਲੀ:

- ਕਈ LLM ਪ੍ਰਦਾਤਾਵਾਂ ਲਈ ਇੱਕ ਇਕੱਠਾ ਇੰਟਰਫੇਸ ਬਣਾਉਣਾ
- ਵਿਭਾਗਾਂ ਵਿੱਚ ਇੱਕਸਾਰ ਪ੍ਰਾਂਪਟ ਪ੍ਰਬੰਧਨ ਨੂੰ ਕਾਇਮ ਰੱਖਣਾ
- ਮਜ਼ਬੂਤ ਸੁਰੱਖਿਆ ਅਤੇ ਅਨੁਕੂਲਤਾ ਨਿਯੰਤਰਣ ਲਾਗੂ ਕਰਨਾ
- ਖਾਸ ਜ਼ਰੂਰਤਾਂ ਦੇ ਅਧਾਰ 'ਤੇ ਵੱਖ-ਵੱਖ AI ਮਾਡਲਾਂ ਵਿਚਕਾਰ ਆਸਾਨੀ ਨਾਲ ਬਦਲਣਾ

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

**ਨਤੀਜੇ:** ਮਾਡਲ ਖਰਚਾਂ ਵਿੱਚ 30% ਕਮੀ, ਜਵਾਬ ਦੇਣ ਦੀ ਇੱਕਸਾਰਤਾ ਵਿੱਚ 45% ਸੁਧਾਰ, ਅਤੇ ਵਿਸ਼ਵ ਭਰ ਵਿੱਚ ਅਨੁਕੂਲਤਾ ਵਿੱਚ ਵਾਧਾ।

### ਕੇਸ ਅਧਿਐਨ 2: ਹੈਲਥਕੇਅਰ ਡਾਇਗਨੋਸਟਿਕ ਅਸਿਸਟੈਂਟ

ਇੱਕ ਹੈਲਥਕੇਅਰ ਪ੍ਰਦਾਤਾ ਨੇ MCP ਢਾਂਚਾ ਵਿਕਸਿਤ ਕੀਤਾ ਜਿਸ ਨਾਲ ਕਈ ਵਿਸ਼ੇਸ਼ਤ ਮੈਡੀਕਲ AI ਮਾਡਲਾਂ ਨੂੰ ਜੋੜਿਆ ਜਾ ਸਕਦਾ ਹੈ, ਜਦਕਿ ਸੰਵੇਦਨਸ਼ੀਲ ਮਰੀਜ਼ ਡਾਟਾ ਦੀ ਸੁਰੱਖਿਆ ਪੂਰੀ ਰਹਿੰਦੀ ਹੈ:

- ਆਮ ਅਤੇ ਵਿਸ਼ੇਸ਼ਤ ਮੈਡੀਕਲ ਮਾਡਲਾਂ ਵਿਚਕਾਰ ਬਿਨਾਂ ਰੁਕਾਵਟ ਬਦਲਾਅ
- ਕੜੀ ਪ੍ਰਾਈਵੇਸੀ ਨਿਯੰਤਰਣ ਅਤੇ ਆਡਿਟ ਟਰੇਲ
- ਮੌਜੂਦਾ Electronic Health Record (EHR) ਸਿਸਟਮਾਂ ਨਾਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ
- ਮੈਡੀਕਲ ਟਰਮੀਨੋਲੋਜੀ ਲਈ ਇੱਕਸਾਰ ਪ੍ਰਾਂਪਟ ਇੰਜੀਨੀਅਰਿੰਗ

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

**ਨਤੀਜੇ:** ਡਾਕਟਰਾਂ ਲਈ ਡਾਇਗਨੋਸਟਿਕ ਸੁਝਾਵਾਂ ਵਿੱਚ ਸੁਧਾਰ, ਪੂਰੀ HIPAA ਅਨੁਕੂਲਤਾ, ਅਤੇ ਸਿਸਟਮਾਂ ਵਿਚਕਾਰ ਸੰਦਰਭ-ਬਦਲਾਅ ਵਿੱਚ ਮਹੱਤਵਪੂਰਨ ਕਮੀ।

### ਕੇਸ ਅਧਿਐਨ 3: ਵਿੱਤੀ ਸੇਵਾਵਾਂ ਵਿੱਚ ਜੋਖਮ ਵਿਸ਼ਲੇਸ਼ਣ

ਇੱਕ ਵਿੱਤੀ ਸੰਸਥਾ ਨੇ MCP ਲਾਗੂ ਕੀਤਾ ਤਾਂ ਜੋ ਵੱਖ-ਵੱਖ ਵਿਭਾਗਾਂ ਵਿੱਚ ਆਪਣੇ ਜੋਖਮ ਵਿਸ਼ਲੇਸ਼ਣ ਪ੍ਰਕਿਰਿਆਵਾਂ ਨੂੰ ਮਿਆਰੀਕ੍ਰਿਤ ਕਰ ਸਕੇ:

- ਕ੍ਰੈਡਿਟ ਜੋਖਮ, ਧੋਖਾਧੜੀ ਪਛਾਣ ਅਤੇ ਨਿਵੇਸ਼ ਜੋਖਮ ਮਾਡਲਾਂ ਲਈ ਇੱਕ ਇਕੱਠਾ ਇੰਟਰਫੇਸ ਬਣਾਇਆ
- ਕੜੇ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਅਤੇ ਮਾਡਲ ਵਰਜਨਿੰਗ ਲਾਗੂ ਕੀਤੀ
- ਸਾਰੇ AI ਸਿਫਾਰਸ਼ਾਂ ਦੀ ਆਡਿਟਯੋਗਤਾ ਯਕੀਨੀ ਬਣਾਈ
- ਵੱਖ-ਵੱਖ ਸਿਸਟਮਾਂ ਵਿੱਚ ਡਾਟਾ ਫਾਰਮੈਟਿੰਗ ਨੂੰ ਇੱਕਸਾਰ ਰੱਖਿਆ

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

**ਨਤੀਜੇ:** ਨਿਯਮਕ ਅਨੁਕੂਲਤਾ ਵਿੱਚ ਸੁਧਾਰ, ਮਾਡਲ ਡਿਪਲੋਇਮੈਂਟ ਚੱਕਰਾਂ ਵਿੱਚ 40% ਤੇਜ਼ੀ, ਅਤੇ ਵਿਭਾਗਾਂ ਵਿੱਚ ਜੋਖਮ ਮੁਲਾਂਕਣ ਦੀ ਇੱਕਸਾਰਤਾ।

### ਕੇਸ ਅਧਿਐਨ 4: Microsoft Playwright MCP ਸਰਵਰ ਬਰਾਊਜ਼ਰ ਆਟੋਮੇਸ਼ਨ ਲਈ

Microsoft ਨੇ [Playwright MCP server](https://github.com/microsoft/playwright-mcp) ਵਿਕਸਿਤ ਕੀਤਾ ਹੈ ਜੋ Model Context Protocol ਰਾਹੀਂ ਸੁਰੱਖਿਅਤ, ਮਿਆਰੀਕ੍ਰਿਤ ਬਰਾਊਜ਼ਰ ਆਟੋਮੇਸ਼ਨ ਨੂੰ ਯਕੀਨੀ ਬਣਾਉਂਦਾ ਹੈ। ਇਹ ਹੱਲ AI ਏਜੰਟਾਂ ਅਤੇ LLMs ਨੂੰ ਵੈੱਬ ਬਰਾਊਜ਼ਰਾਂ ਨਾਲ ਨਿਯੰਤਰਿਤ, ਆਡਿਟਯੋਗ ਅਤੇ ਵਿਸਥਾਰਯੋਗ ਤਰੀਕੇ ਨਾਲ ਇੰਟਰੈਕਟ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ—ਜਿਵੇਂ ਕਿ ਆਟੋਮੇਟਿਕ ਵੈੱਬ ਟੈਸਟਿੰਗ, ਡਾਟਾ ਨਿਕਾਸ ਅਤੇ ਪੂਰੇ ਵਰਕਫਲੋਜ਼।

- ਬਰਾਊਜ਼ਰ ਆਟੋਮੇਸ਼ਨ ਸਮਰੱਥਾਵਾਂ (ਨੈਵੀਗੇਸ਼ਨ, ਫਾਰਮ ਭਰਨਾ, ਸਕਰੀਨਸ਼ਾਟ ਲੈਣਾ ਆਦਿ) ਨੂੰ MCP ਟੂਲਾਂ ਵਜੋਂ ਪ੍ਰਦਰਸ਼ਿਤ ਕਰਦਾ ਹੈ
- ਅਣਅਧਿਕ੍ਰਿਤ ਕਾਰਵਾਈਆਂ ਨੂੰ ਰੋਕਣ ਲਈ ਕੜੇ ਪਹੁੰਚ ਨਿਯੰਤਰਣ ਅਤੇ ਸੈਂਡਬਾਕਸਿੰਗ ਲਾਗੂ ਕਰਦਾ ਹੈ
- ਸਾਰੇ ਬਰਾਊਜ਼ਰ ਇੰਟਰੈਕਸ਼ਨਾਂ ਲਈ ਵਿਸਥਾਰਪੂਰਵਕ ਆਡਿਟ ਲਾਗ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ
- ਏਜੰਟ-ਚਲਿਤ ਆਟੋਮੇਸ਼ਨ ਲਈ Azure OpenAI ਅਤੇ ਹੋਰ LLM ਪ੍ਰਦਾਤਾਵਾਂ ਨਾਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ

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

**ਨਤੀਜੇ:**  
- AI ਏਜੰਟਾਂ ਅਤੇ LLMs ਲਈ ਸੁਰੱਖਿਅਤ, ਪ੍ਰੋਗ੍ਰਾਮੈਟਿਕ ਬਰਾਊਜ਼ਰ ਆਟੋਮੇਸ਼ਨ ਯੋਗ ਬਣਾਇਆ  
- ਮੈਨੂਅਲ ਟੈਸਟਿੰਗ ਦਾ ਕੰਮ ਘਟਾਇਆ ਅਤੇ ਵੈੱਬ ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਟੈਸਟ ਕਵਰੇਜ ਵਿੱਚ ਸੁਧਾਰ ਕੀਤਾ  
- ਐਂਟਰਪ੍ਰਾਈਜ਼ ਵਾਤਾਵਰਣਾਂ ਵਿੱਚ ਬਰਾਊਜ਼ਰ-ਅਧਾਰਿਤ ਟੂਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਲਈ ਦੁਬਾਰਾ ਵਰਤਣਯੋਗ ਅਤੇ ਵਿਸਥਾਰਯੋਗ ਫਰੇਮਵਰਕ ਪ੍ਰਦਾਨ ਕੀਤਾ

**References:**  
- [Playwright MCP Server GitHub Repository](https://github.com/microsoft/playwright-mcp)  
- [Microsoft AI and Automation Solutions](https://azure.microsoft.com/en-us/products/ai-services/)

### ਕੇਸ ਅਧਿਐਨ 5: Azure MCP – ਐਂਟਰਪ੍ਰਾਈਜ਼-ਗਰੇਡ Model Context Protocol ਸੇਵਾ ਵਜੋਂ

Azure MCP ([https://aka.ms/azmcp](https://aka.ms/azmcp)) Microsoft ਦੀ ਮੈਨੇਜ ਕੀਤੀ ਹੋਈ, ਐਂਟਰਪ੍ਰਾਈਜ਼-ਗਰੇਡ Model Context Protocol ਅਮਲਦਾਰੀ ਹੈ, ਜੋ ਸਕੇਲਬਲ, ਸੁਰੱਖਿਅਤ ਅਤੇ ਅਨੁਕੂਲ MCP ਸਰਵਰ ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਕਲਾਉਡ ਸੇਵਾ ਵਜੋਂ ਮੁਹੱਈਆ ਕਰਦੀ ਹੈ। Azure MCP ਸੰਗਠਨਾਂ ਨੂੰ ਤੇਜ਼ੀ ਨਾਲ MCP ਸਰਵਰ ਡਿਪਲੋਇ ਕਰਨ, ਪ੍ਰਬੰਧਿਤ ਕਰਨ ਅਤੇ Azure AI, ਡਾਟਾ ਅਤੇ ਸੁਰੱਖਿਆ ਸੇਵਾਵਾਂ ਨਾਲ ਇੰਟੀਗ੍ਰੇਟ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਓਪਰੇਸ਼ਨਲ ਓਵਰਹੈਡ ਘਟਦਾ ਹੈ ਅਤੇ AI ਗ੍ਰਹਿਣ ਨੂੰ ਤੇਜ਼ੀ ਮਿਲਦੀ ਹੈ।

- ਪੂਰੀ ਤਰ੍ਹਾਂ ਮੈਨੇਜ ਕੀਤੀ MCP ਸਰਵਰ ਹੋਸਟਿੰਗ ਜਿਸ ਵਿੱਚ ਸਕੇਲਿੰਗ, ਮਾਨੀਟਰਿੰਗ ਅਤੇ ਸੁਰੱਖਿਆ ਸ਼ਾਮਲ ਹਨ  
- Azure OpenAI, Azure AI Search ਅਤੇ ਹੋਰ Azure ਸੇਵਾਵਾਂ ਨਾਲ ਮੂਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ  
- Microsoft Entra ID ਰਾਹੀਂ ਐਂਟਰਪ੍ਰਾਈਜ਼ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰਨ  
- ਕਸਟਮ ਟੂਲ, ਪ੍ਰਾਂਪਟ ਟੈਮਪਲੇਟ ਅਤੇ ਰਿਸੋਰਸ ਕਨੈਕਟਰਾਂ ਲਈ ਸਮਰਥਨ  
- ਐਂਟਰਪ੍ਰਾਈਜ਼ ਸੁਰੱਖਿਆ ਅਤੇ ਨਿਯਮਕ ਲੋੜਾਂ ਦੇ ਅਨੁਕੂਲ

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

**ਨਤੀਜੇ:**  
- ਐਂਟਰਪ੍ਰਾਈਜ਼ AI ਪ੍ਰੋਜੈਕਟਾਂ ਲਈ ਤੁਰੰਤ ਮੁੱਲ ਪ੍ਰਦਾਨ ਕਰਨ ਵਾਲਾ, ਤਿਆਰ-ਇਸਤਮਾਲ MCP ਸਰਵਰ ਪਲੇਟਫਾਰਮ  
- LLMs, ਟੂਲਾਂ ਅਤੇ ਐਂਟਰਪ੍ਰਾਈਜ਼ ਡਾਟਾ ਸਰੋਤਾਂ ਦੀ ਸੌਖੀ ਇੰਟੀਗ੍ਰੇਸ਼ਨ  
- MCP ਵਰਕਲੋਡਾਂ ਲਈ ਵਧੀਆ ਸੁਰੱਖਿਆ, ਨਿਗਰਾਨੀ ਅਤੇ ਓਪਰੇਸ਼ਨਲ ਕੁਸ਼ਲਤਾ

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [Azure AI Services](https://azure.microsoft.com/en-us/products/ai-services/)

## ਕੇਸ ਅਧਿਐਨ 6: NLWeb

MCP (Model Context Protocol) ਇੱਕ ਉਭਰਦਾ ਹੋਇਆ ਪ੍ਰੋਟੋਕੋਲ ਹੈ ਜੋ ਚੈਟਬੋਟਸ ਅਤੇ AI ਸਹਾਇਕਾਂ ਨੂੰ ਟੂਲਾਂ ਨਾਲ ਇੰਟਰੈਕਟ ਕਰਨ ਦੇ ਯੋਗ ਬਣਾਉਂਦਾ ਹੈ। ਹਰ NLWeb ਉਦਾਹਰਣ ਵੀ ਇੱਕ MCP ਸਰਵਰ ਹੈ, ਜੋ ਇੱਕ ਮੁੱਖ ਵਿਧੀ, ask, ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ ਜੋ ਕਿਸੇ ਵੈੱਬਸਾਈਟ ਨੂੰ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਵਿੱਚ ਸਵਾਲ ਪੁੱਛਣ ਲਈ ਵਰਤਿਆ ਜਾਂਦਾ ਹੈ। ਪ੍ਰਾਪਤ ਜਵਾਬ schema.org ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ, ਜੋ ਵੈੱਬ ਡਾਟਾ ਵੇਰਵਾ ਕਰਨ ਲਈ ਇੱਕ ਵਿਆਪਕ ਵਰਤੀ ਜਾਣ ਵਾਲੀ ਸ਼ਬਦਾਵਲੀ ਹੈ। ਆਮ ਤੌਰ 'ਤੇ, MCP ਨੂੰ NLWeb ਵਜੋਂ ਸਮਝਿਆ ਜਾ ਸਕਦਾ ਹੈ ਜਿਵੇਂ Http ਨੂੰ HTML ਵਜੋਂ। NLWeb ਪ੍ਰੋਟੋਕੋਲਾਂ, Schema.org ਫਾਰਮੈਟਾਂ ਅਤੇ ਨਮੂਨਾ ਕੋਡ ਨੂੰ ਮਿਲਾ ਕੇ ਸਾਈਟਾਂ ਨੂੰ ਤੇਜ਼ੀ ਨਾਲ ਇਹ ਐਂਡਪੋਇੰਟ ਬਣਾਉਣ ਵਿੱਚ ਮਦਦ ਕਰਦਾ ਹੈ, ਜੋ ਮਨੁੱਖਾਂ ਲਈ ਗੱਲਬਾਤੀ ਇੰਟਰਫੇਸ ਅਤੇ ਮਸ਼ੀਨਾਂ ਲਈ ਕੁਦਰਤੀ ਏਜੰਟ-ਟੂ-ਏਜੰਟ ਇੰਟਰੈਕਸ਼ਨ ਮੁਹੱਈਆ ਕਰਦਾ ਹੈ।

NLWeb ਦੇ ਦੋ ਵੱਖਰੇ ਭਾਗ ਹਨ:  
- ਇੱਕ ਬਹੁਤ ਹੀ ਸਧਾਰਣ ਪ੍ਰੋਟੋਕੋਲ ਜੋ ਕਿਸੇ ਸਾਈਟ ਨਾਲ ਕੁਦਰਤੀ ਭਾਸ਼ਾ ਵਿੱਚ ਇੰਟਰਫੇਸ ਕਰਨ ਲਈ ਹੈ, ਅਤੇ ਇੱਕ ਫਾਰਮੈਟ ਜੋ ਜਵਾਬ ਵਜੋਂ json ਅਤੇ schema.org ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ। REST API ਦੀ ਦਸਤਾਵੇਜ਼ੀ ਦੇਖੋ।  
- (1) ਦੀ ਇੱਕ ਸਧਾਰਣ ਅਮਲਦਾਰੀ ਜੋ ਮੌਜੂਦਾ ਮਾਰਕਅਪ ਦੀ ਵਰਤੋਂ ਕਰਦੀ ਹੈ, ਉਹਨਾਂ ਸਾਈਟਾਂ ਲਈ ਜੋ ਆਈਟਮਾਂ (ਉਤਪਾਦ, ਰੇਸਿਪੀਆਂ, ਆਕਰਸ਼ਣ, ਸਮੀਖਿਆਵਾਂ ਆਦਿ) ਦੀ ਸੂਚੀ ਵਜੋਂ ਅਬਸਟ੍ਰੈਕਟ ਕੀਤੀਆਂ ਜਾ ਸਕਦੀਆਂ ਹਨ। UI ਵਿਜਟਾਂ ਦੇ ਨਾਲ, ਸਾਈਟਾਂ ਆਪਣੇ ਸਮੱਗਰੀ ਲਈ ਗੱਲਬਾਤੀ ਇੰਟਰਫੇਸ ਆਸਾਨੀ ਨਾਲ ਪ੍ਰਦਾਨ ਕਰ ਸਕਦੀਆਂ ਹਨ। Life of a chat query ਦਸਤਾਵੇਜ਼ੀ ਵੇਖੋ।  

**References:**  
- [Azure MCP Documentation](https://aka.ms/azmcp)  
- [NLWeb](https://github.com/microsoft/NlWeb)

### ਕੇਸ ਅਧਿਐਨ 7: Foundry ਲਈ MCP – Azure AI ਏਜੰਟਾਂ ਦਾ ਇੰਟੀਗ੍ਰੇਸ਼ਨ

Azure AI Foundry MCP ਸਰਵਰ ਦਿਖਾਉਂਦੇ ਹਨ ਕਿ MCP ਨੂੰ ਉਦਯੋਗਿਕ ਵਾਤਾਵਰਣਾਂ ਵਿੱਚ AI ਏਜੰਟਾਂ ਅਤੇ ਵਰਕਫਲੋਜ਼ ਨੂੰ ਆਰਕੀਸਟ੍ਰੇਟ ਅਤੇ ਪ੍ਰਬੰਧਿਤ ਕਰਨ ਲਈ ਕਿਵੇਂ ਵਰਤਿਆ ਜਾ ਸਕਦਾ ਹੈ। MCP ਨੂੰ Azure AI Foundry ਨਾਲ ਜੋੜ ਕੇ, ਸੰਗਠਨ ਏਜੰਟ ਇੰਟਰੈਕਸ਼ਨਾਂ ਨੂੰ ਮਿਆਰੀਕ੍ਰਿਤ ਕਰ ਸਕਦੇ ਹਨ, Foundry ਦੇ ਵਰਕਫਲੋ ਪ੍ਰਬੰਧਨ ਦਾ ਲਾਭ ਉਠਾ ਸਕਦੇ ਹਨ, ਅਤੇ ਸੁਰੱਖਿਅਤ, ਸਕੇਲਬਲ ਡਿਪਲੋਇਮੈਂਟ ਨੂੰ ਯਕੀਨੀ ਬਣਾ ਸਕਦੇ ਹਨ। ਇਹ ਤਰੀਕਾ ਤੇਜ਼ ਪ੍ਰੋਟੋਟਾਈਪਿੰਗ, ਮਜ਼ਬੂਤ ਨਿਗਰਾਨੀ, ਅਤੇ Azure AI ਸੇਵਾਵਾਂ ਨਾਲ ਬਿਨਾਂ ਰੁਕਾਵਟ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਨੂੰ ਸਮਰਥਨ ਦਿੰਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਗਿਆਨ ਪ੍ਰਬੰਧਨ ਅਤੇ ਏਜੰਟ ਮੁਲਾਂਕਣ ਵਰਗੇ ਉੱਚ ਦਰਜੇ ਦੇ ਸਿਨਾਰਿਓਜ਼ ਸਹਿਯੋਗੀ ਹੁੰਦੇ ਹਨ। ਵਿਕਾਸਕਾਰਾਂ ਨੂੰ ਏਜੰਟ ਪਾਈਪਲਾਈਨਾਂ ਬਣਾਉਣ, ਡਿਪਲੋਇ ਕਰਨ ਅਤੇ ਨਿਗਰਾਨੀ ਕਰਨ ਲਈ ਇੱਕ ਇਕੱਠਾ ਇੰਟਰਫੇਸ ਮਿਲਦਾ ਹੈ, ਜਦਕਿ IT ਟੀਮਾਂ ਨੂੰ ਸੁਰੱਖਿਆ, ਅਨੁਕੂਲਤਾ ਅਤੇ ਓਪਰੇਸ਼ਨਲ ਕੁਸ਼ਲਤਾ ਵਿੱਚ ਸੁਧਾਰ ਮਿਲਦਾ ਹੈ। ਇਹ ਹੱਲ ਉਹਨਾਂ ਐਂਟਰਪ੍ਰਾਈਜ਼ਾਂ ਲਈ ਬਹੁਤ ਵਧੀਆ ਹੈ ਜੋ AI ਗ੍ਰਹਿਣ ਨੂੰ ਤੇਜ਼ ਕਰਨਾ ਚਾਹੁੰਦੇ ਹਨ ਅਤੇ ਜਟਿਲ ਏਜੰਟ-ਚਲਿਤ ਪ੍ਰਕਿਰਿਆਵਾਂ 'ਤੇ ਨਿਯੰਤਰਣ ਬਣਾਈ ਰੱਖਣਾ ਚਾਹੁੰਦੇ ਹਨ।

**References:**  
- [MCP Foundry GitHub Repository](https://github.com/azure-ai-foundry/mcp-foundry)  
- [Integrating Azure AI Agents with MCP (Microsoft Foundry Blog)](https://devblogs.microsoft.com/foundry/integrating-azure-ai-agents-mcp/)

### ਕੇਸ ਅਧਿਐਨ 8: Foundry MCP Playground – ਪ੍ਰਯੋਗ ਅਤੇ ਪ੍ਰੋਟੋਟਾਈਪਿੰਗ

Foundry MCP Playground ਇੱਕ ਤਿਆਰ-ਇਸਤਮਾਲ ਵਾਤਾਵਰਣ ਮੁਹੱਈਆ ਕਰਦਾ ਹੈ ਜੋ MCP ਸਰਵਰਾਂ ਅਤੇ Azure AI Foundry ਇੰਟੀਗ੍ਰੇਸ਼ਨਾਂ ਨਾਲ ਪ੍ਰਯੋਗ ਕਰਨ ਲਈ ਹੈ। ਵਿਕਾਸਕਾਰ ਤੇਜ਼ੀ ਨਾਲ AI ਮਾਡਲਾਂ ਅਤੇ ਏਜੰਟ ਵਰਕਫਲੋਜ਼ ਦਾ ਪ੍ਰੋਟੋਟਾਈਪ, ਟੈਸਟ ਅਤੇ ਮੁਲਾਂਕਣ ਕਰ ਸਕਦੇ ਹਨ, ਜੋ Azure AI Foundry ਕੈਟਾਲਾਗ ਅਤੇ ਲੈਬਜ਼ ਤੋਂ ਸਰੋਤਾਂ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ। ਇਹ ਪਲੇਗਰਾਊਂਡ ਸੈਟਅੱਪ ਨੂੰ ਆਸਾਨ ਬਣਾਉਂਦਾ ਹੈ, ਨਮੂਨਾ ਪ੍ਰੋਜੈਕਟ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ, ਅਤੇ ਸਹਿਯੋਗੀ ਵਿਕਾਸ ਦਾ ਸਮਰਥਨ ਕਰਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਵਧੀਆ ਅਭਿਆਸਾਂ ਅਤੇ ਨਵੇਂ ਸਿਨਾਰਿਓਜ਼ ਦੀ ਖੋਜ ਘੱਟ ਝੰਝਟ ਨਾਲ ਹੋ ਸਕਦੀ ਹੈ। ਇਹ ਖਾਸ ਕਰਕੇ ਉਹਨਾਂ ਟੀਮਾਂ ਲਈ ਲਾਭਦਾਇਕ ਹੈ ਜੋ ਵਿਚਾਰਾਂ ਦੀ ਪੁਸ਼ਟੀ ਕਰਨ, ਪ੍ਰਯੋਗ ਸਾਂਝੇ ਕਰਨ ਅਤੇ ਸਿੱਖਣ ਨੂੰ ਤੇਜ਼ ਕਰਨ ਲਈ ਇ
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

## ਅਭਿਆਸ

1. ਕਿਸੇ ਇੱਕ ਕੇਸ ਅਧਿਐਨ ਦਾ ਵਿਸ਼ਲੇਸ਼ਣ ਕਰੋ ਅਤੇ ਇੱਕ ਵਿਕਲਪਿਕ ਲਾਗੂ ਕਰਨ ਦਾ ਤਰੀਕਾ ਪ੍ਰਸਤਾਵਿਤ ਕਰੋ।
2. ਕਿਸੇ ਇੱਕ ਪ੍ਰੋਜੈਕਟ ਵਿਚਾਰ ਨੂੰ ਚੁਣੋ ਅਤੇ ਇੱਕ ਵਿਸਥਾਰਿਤ ਤਕਨੀਕੀ ਵਿਸ਼ੇਸ਼ਤਾ ਤਿਆਰ ਕਰੋ।
3. ਕਿਸੇ ਉਦਯੋਗ ਬਾਰੇ ਖੋਜ ਕਰੋ ਜੋ ਕੇਸ ਅਧਿਐਨਾਂ ਵਿੱਚ ਸ਼ਾਮਲ ਨਹੀਂ ਹੈ ਅਤੇ ਵੇਖਾਓ ਕਿ MCP ਇਸਦੇ ਖਾਸ ਚੁਣੌਤੀਆਂ ਨੂੰ ਕਿਵੇਂ ਹੱਲ ਕਰ ਸਕਦਾ ਹੈ।
4. ਭਵਿੱਖ ਦੇ ਕਿਸੇ ਇੱਕ ਦਿਸ਼ਾ ਦੀ ਜਾਂਚ ਕਰੋ ਅਤੇ ਇਸਨੂੰ ਸਮਰਥਨ ਦੇਣ ਲਈ MCP ਦਾ ਇੱਕ ਨਵਾਂ ਵਿਸ਼ਤਾਰ ਬਣਾਉਣ ਦਾ ਖ਼ਾਕਾ ਤਿਆਰ ਕਰੋ।

ਅਗਲਾ: [Best Practices](../08-BestPractices/README.md)

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਦਿਓ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਤੀਰਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਵਜੋਂ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਜਰੂਰੀ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫ਼ਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉੱਪਜਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।