<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-17T00:37:40+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ne"
}
-->
# क्लाइन्ट बनाउने

क्लाइन्टहरू कस्टम एप्लिकेशन वा स्क्रिप्टहरू हुन् जुन सिधै MCP सर्भरसँग संवाद गर्छन् स्रोतहरू, उपकरणहरू, र प्रॉम्प्टहरू अनुरोध गर्न। इन्स्पेक्टर टुल प्रयोग गर्ने भन्दा फरक, जसले सर्भरसँग अन्तरक्रिया गर्न ग्राफिकल इन्टरफेस प्रदान गर्छ, आफ्नै क्लाइन्ट लेख्दा प्रोग्रामेटिक र स्वचालित अन्तरक्रिया सम्भव हुन्छ। यसले विकासकर्ताहरूलाई MCP क्षमताहरू आफ्नै कार्यप्रवाहमा समावेश गर्न, कार्यहरू स्वचालित गर्न, र विशेष आवश्यकताहरू अनुसार कस्टम समाधानहरू निर्माण गर्न सक्षम बनाउँछ।

## अवलोकन

यस पाठले Model Context Protocol (MCP) इकोसिस्टम भित्र क्लाइन्टहरूको अवधारणा परिचय गराउँछ। तपाईंले आफ्नै क्लाइन्ट कसरी लेख्ने र यसलाई MCP सर्भरसँग कसरी जडान गर्ने सिक्नुहुनेछ।

## सिकाइका उद्देश्यहरू

यस पाठको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- क्लाइन्टले के गर्न सक्छ बुझ्न।
- आफ्नै क्लाइन्ट लेख्न।
- क्लाइन्टलाई MCP सर्भरसँग जडान गरी परीक्षण गर्न ताकि सर्भर अपेक्षित रूपमा काम गर्छ कि गर्दैन सुनिश्चित गर्न।

## क्लाइन्ट लेख्न के के चाहिन्छ?

क्लाइन्ट लेख्न तपाईंले निम्न कार्यहरू गर्नुपर्नेछ:

- **सही लाइब्रेरीहरू आयात गर्ने।** तपाईंले पहिले प्रयोग गरेको लाइब्रेरी नै प्रयोग गर्नुहुनेछ, तर फरक संरचनाहरू।
- **क्लाइन्टको उदाहरण बनाउने।** यसले क्लाइन्टको एउटा उदाहरण सिर्जना गरी चयन गरिएको ट्रान्सपोर्ट विधिसँग जडान गर्ने समावेश गर्छ।
- **कुन स्रोतहरू सूचीबद्ध गर्ने निर्णय गर्ने।** तपाईंको MCP सर्भरमा स्रोतहरू, उपकरणहरू र प्रॉम्प्टहरू हुन्छन्, तपाईंले कुन सूचीबद्ध गर्ने निर्णय गर्नुपर्छ।
- **क्लाइन्टलाई होस्ट एप्लिकेशनमा एकीकृत गर्ने।** सर्भरका क्षमताहरू थाहा पाएपछि, तपाईंले यसलाई आफ्नो होस्ट एप्लिकेशनमा एकीकृत गर्नुपर्छ ताकि प्रयोगकर्ताले प्रॉम्प्ट वा अन्य आदेश टाइप गर्दा सम्बन्धित सर्भर सुविधा सक्रिय होस्।

अब हामीले उच्च स्तरमा के गर्ने हो बुझिसकेपछि, अर्को उदाहरण हेरौं।

### एउटा उदाहरण क्लाइन्ट

यो उदाहरण क्लाइन्ट हेरौं:

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";

const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);

// List prompts
const prompts = await client.listPrompts();

// Get a prompt
const prompt = await client.getPrompt({
  name: "example-prompt",
  arguments: {
    arg1: "value"
  }
});

// List resources
const resources = await client.listResources();

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});
```

माथिको कोडमा हामीले:

- लाइब्रेरीहरू आयात गर्यौं
- क्लाइन्टको एउटा उदाहरण बनायौं र stdio ट्रान्सपोर्ट प्रयोग गरी जडान गर्यौं।
- प्रॉम्प्टहरू, स्रोतहरू र उपकरणहरू सूचीबद्ध गरी सबैलाई कल गर्यौं।

त्यसैले, यहाँ एउटा क्लाइन्ट छ जसले MCP सर्भरसँग कुरा गर्न सक्छ।

अर्को अभ्यास खण्डमा हामी प्रत्येक कोड अंशलाई विस्तारमा व्याख्या गर्नेछौं।

## अभ्यास: क्लाइन्ट लेख्ने

जसरी माथि भनियो, अब हामी कोड विस्तारमा बुझ्नेछौं, र चाहनु भएमा सँगै कोड पनि गर्न सक्नुहुन्छ।

### -1- लाइब्रेरीहरू आयात गर्ने

हामीलाई चाहिने लाइब्रेरीहरू आयात गरौं, हामीलाई क्लाइन्ट र हाम्रो चयन गरिएको ट्रान्सपोर्ट प्रोटोकल stdio को सन्दर्भ चाहिन्छ। stdio स्थानीय मेसिनमा चल्ने कुराहरूका लागि प्रोटोकल हो। SSE अर्को ट्रान्सपोर्ट प्रोटोकल हो जुन भविष्यका अध्यायहरूमा देखाउनेछौं, तर अहिले stdio सँगै अघि बढौं।

### TypeScript

```typescript
import { Client } from "@modelcontextprotocol/sdk/client/index.js";
import { StdioClientTransport } from "@modelcontextprotocol/sdk/client/stdio.js";
```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client
```

### .NET

```csharp
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;
```

### Java

Java को लागि, तपाईंले अघिल्लो अभ्यासको MCP सर्भरसँग जडान गर्ने क्लाइन्ट बनाउनुहुनेछ। [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) बाटै Java Spring Boot प्रोजेक्ट संरचना प्रयोग गरी `src/main/java/com/microsoft/mcp/sample/client/` फोल्डरमा `SDKClient` नामक नयाँ Java क्लास बनाउनुहोस् र तलका आयातहरू थप्नुहोस्:

```java
import java.util.Map;
import org.springframework.web.reactive.function.client.WebClient;
import io.modelcontextprotocol.client.McpClient;
import io.modelcontextprotocol.client.transport.WebFluxSseClientTransport;
import io.modelcontextprotocol.spec.McpClientTransport;
import io.modelcontextprotocol.spec.McpSchema.CallToolRequest;
import io.modelcontextprotocol.spec.McpSchema.CallToolResult;
import io.modelcontextprotocol.spec.McpSchema.ListToolsResult;
```

अब उदाहरण सिर्जना गर्ने चरणमा जाऔं।

### -2- क्लाइन्ट र ट्रान्सपोर्टको उदाहरण बनाउने

हामीले ट्रान्सपोर्ट र क्लाइन्टको उदाहरण सिर्जना गर्नुपर्नेछ:

### TypeScript

```typescript
const transport = new StdioClientTransport({
  command: "node",
  args: ["server.js"]
});

const client = new Client(
  {
    name: "example-client",
    version: "1.0.0"
  }
);

await client.connect(transport);
```

माथिको कोडमा हामीले:

- stdio ट्रान्सपोर्टको उदाहरण बनायौं। यसले कसरी सर्भर फेला पार्ने र सुरु गर्ने कमाण्ड र आर्गुमेन्टहरू निर्दिष्ट गर्छ, जुन क्लाइन्ट बनाउँदा आवश्यक हुन्छ।

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- क्लाइन्टलाई नाम र संस्करण दिएर उदाहरण बनायौं।

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- क्लाइन्टलाई चयन गरिएको ट्रान्सपोर्टसँग जडान गर्यौं।

    ```typescript
    await client.connect(transport);
    ```

### Python

```python
from mcp import ClientSession, StdioServerParameters, types
from mcp.client.stdio import stdio_client

# Create server parameters for stdio connection
server_params = StdioServerParameters(
    command="mcp",  # Executable
    args=["run", "server.py"],  # Optional command line arguments
    env=None,  # Optional environment variables
)

async def run():
    async with stdio_client(server_params) as (read, write):
        async with ClientSession(
            read, write
        ) as session:
            # Initialize the connection
            await session.initialize()

          

if __name__ == "__main__":
    import asyncio

    asyncio.run(run())
```

माथिको कोडमा हामीले:

- आवश्यक लाइब्रेरीहरू आयात गर्यौं
- सर्भर चलाउन प्रयोग हुने सर्भर प्यारामिटर वस्तु बनायौं ताकि क्लाइन्टले जडान गर्न सकोस्।
- `run` मेथड परिभाषित गर्यौं जसले `stdio_client` कल गर्छ र क्लाइन्ट सत्र सुरु गर्छ।
- `asyncio.run` मा `run` मेथडलाई प्रवेश बिन्दु बनाएर चलायौं।

### .NET

```dotnet
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol.Transport;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
    Command = "dotnet",
    Arguments = ["run", "--project", "path/to/file.csproj"],
});

await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);
```

माथिको कोडमा हामीले:

- आवश्यक लाइब्रेरीहरू आयात गर्यौं।
- stdio ट्रान्सपोर्ट र `mcpClient` क्लाइन्ट बनायौं। यो क्लाइन्ट MCP सर्भरका सुविधाहरू सूचीबद्ध र कल गर्न प्रयोग हुनेछ।

ध्यान दिनुहोस्, "Arguments" मा तपाईंले *.csproj* वा executable दुवै मध्ये कुनै पनि देखाउन सक्नुहुन्छ।

### Java

```java
public class SDKClient {
    
    public static void main(String[] args) {
        var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
        new SDKClient(transport).run();
    }
    
    private final McpClientTransport transport;

    public SDKClient(McpClientTransport transport) {
        this.transport = transport;
    }

    public void run() {
        var client = McpClient.sync(this.transport).build();
        client.initialize();
        
        // Your client logic goes here
    }
}
```

माथिको कोडमा हामीले:

- मुख्य मेथड बनायौं जसले `http://localhost:8080` मा चल्ने MCP सर्भरको लागि SSE ट्रान्सपोर्ट सेटअप गर्छ।
- ट्रान्सपोर्टलाई कन्स्ट्रक्टर प्यारामिटरको रूपमा लिने क्लाइन्ट क्लास बनायौं।
- `run` मेथडमा ट्रान्सपोर्ट प्रयोग गरी सिंक्रोनस MCP क्लाइन्ट बनायौं र जडान सुरु गर्यौं।
- SSE (Server-Sent Events) ट्रान्सपोर्ट प्रयोग गर्यौं जुन Java Spring Boot MCP सर्भरसँग HTTP आधारित सञ्चारका लागि उपयुक्त छ।

### -3- सर्भर सुविधाहरू सूचीबद्ध गर्ने

अब हामीसँग क्लाइन्ट छ जुन जडान गर्न सक्छ। तर यसले सुविधाहरू सूचीबद्ध गर्दैन, त्यसैले अब त्यो गरौं:

### TypeScript

```typescript
// List prompts
const prompts = await client.listPrompts();

// List resources
const resources = await client.listResources();

// list tools
const tools = await client.listTools();
```

### Python

```python
# List available resources
resources = await session.list_resources()
print("LISTING RESOURCES")
for resource in resources:
    print("Resource: ", resource)

# List available tools
tools = await session.list_tools()
print("LISTING TOOLS")
for tool in tools.tools:
    print("Tool: ", tool.name)
```

यहाँ हामी उपलब्ध स्रोतहरू `list_resources()` र उपकरणहरू `list_tools` सूचीबद्ध गरी प्रिन्ट गर्छौं।

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

माथि एउटा उदाहरण छ जसले सर्भरमा रहेका उपकरणहरू सूचीबद्ध गर्छ। प्रत्येक उपकरणको नाम प्रिन्ट गर्छौं।

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

माथिको कोडमा हामीले:

- MCP सर्भरबाट सबै उपलब्ध उपकरणहरू प्राप्त गर्न `listTools()` कल गर्यौं।
- सर्भरसँग जडान ठीक छ कि छैन जाँच्न `ping()` प्रयोग गर्यौं।
- `ListToolsResult` मा सबै उपकरणहरूको नाम, विवरण र इनपुट स्किमाहरू समावेश छन्।

अति राम्रो, अब हामीले सबै सुविधाहरू समेट्यौं। अब प्रश्न उठ्छ, यी सुविधाहरू कहिले प्रयोग गर्ने? यो क्लाइन्ट धेरै सरल छ, यसको मतलब हामीले जब चाहिन्छ तब स्पष्ट रूपमा सुविधाहरू कल गर्नुपर्नेछ। अर्को अध्यायमा, हामी एउटा उन्नत क्लाइन्ट बनाउनेछौं जसले आफ्नै ठूलो भाषा मोडेल (LLM) पहुँच राख्छ। अहिलेका लागि, सर्भरका सुविधाहरू कसरी कल गर्ने हेरौं:

### -4- सुविधाहरू कल गर्ने

सुविधाहरू कल गर्न हामीले सही आर्गुमेन्टहरू र कहिलेकाहीं कल गर्न खोजेको नाम पनि निर्दिष्ट गर्नुपर्छ।

### TypeScript

```typescript

// Read a resource
const resource = await client.readResource({
  uri: "file:///example.txt"
});

// Call a tool
const result = await client.callTool({
  name: "example-tool",
  arguments: {
    arg1: "value"
  }
});

// call prompt
const promptResult = await client.getPrompt({
    name: "review-code",
    arguments: {
        code: "console.log(\"Hello world\")"
    }
})
```

माथिको कोडमा हामीले:

- स्रोत पढ्यौं, `readResource()` कल गरेर `uri` निर्दिष्ट गर्यौं। सर्भरमा यसरी देखिन्छ:

    ```typescript
    server.resource(
        "readFile",
        new ResourceTemplate("file://{name}", { list: undefined }),
        async (uri, { name }) => ({
          contents: [{
            uri: uri.href,
            text: `Hello, ${name}!`
          }]
        })
    );
    ```

    हाम्रो `uri` मान `file://example.txt` सर्भरको `file://{name}` सँग मेल खान्छ। `example.txt` लाई `name` मा म्याप गरिन्छ।

- उपकरण कल गर्यौं, यसको `name` र `arguments` यसरी निर्दिष्ट गर्यौं:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- प्रॉम्प्ट प्राप्त गर्यौं, `getPrompt()` लाई `name` र `arguments` सहित कल गर्यौं। सर्भर कोड यसरी छ:

    ```typescript
    server.prompt(
        "review-code",
        { code: z.string() },
        ({ code }) => ({
            messages: [{
            role: "user",
            content: {
                type: "text",
                text: `Please review this code:\n\n${code}`
            }
            }]
        })
    );
    ```

    र तपाईंको क्लाइन्ट कोड यसरी देखिन्छ जुन सर्भरमा घोषणा गरिएकोसँग मेल खान्छ:

    ```typescript
    const promptResult = await client.getPrompt({
        name: "review-code",
        arguments: {
            code: "console.log(\"Hello world\")"
        }
    })
    ```

### Python

```python
# Read a resource
print("READING RESOURCE")
content, mime_type = await session.read_resource("greeting://hello")

# Call a tool
print("CALL TOOL")
result = await session.call_tool("add", arguments={"a": 1, "b": 7})
print(result.content)
```

माथिको कोडमा हामीले:

- `greeting` नामक स्रोत `read_resource` प्रयोग गरी कल गर्यौं।
- `add` नामक उपकरण `call_tool` प्रयोग गरी कल गर्यौं।

### C#

1. उपकरण कल गर्न कोड थपौं:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. परिणाम प्रिन्ट गर्न कोड:

  ```csharp
  Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
  // Sum 4
  ```

### Java

```java
// Call various calculator tools
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
System.out.println("Add Result = " + resultAdd);

CallToolResult resultSubtract = client.callTool(new CallToolRequest("subtract", Map.of("a", 10.0, "b", 4.0)));
System.out.println("Subtract Result = " + resultSubtract);

CallToolResult resultMultiply = client.callTool(new CallToolRequest("multiply", Map.of("a", 6.0, "b", 7.0)));
System.out.println("Multiply Result = " + resultMultiply);

CallToolResult resultDivide = client.callTool(new CallToolRequest("divide", Map.of("a", 20.0, "b", 4.0)));
System.out.println("Divide Result = " + resultDivide);

CallToolResult resultHelp = client.callTool(new CallToolRequest("help", Map.of()));
System.out.println("Help = " + resultHelp);
```

माथिको कोडमा हामीले:

- `callTool()` मेथड प्रयोग गरी विभिन्न क्याल्कुलेटर उपकरणहरू कल गर्यौं, `CallToolRequest` वस्तुहरूसँग।
- प्रत्येक उपकरण कलले उपकरणको नाम र आवश्यक आर्गुमेन्टहरूको `Map` निर्दिष्ट गर्छ।
- सर्भर उपकरणहरूले विशिष्ट प्यारामिटर नामहरू (जस्तै "a", "b") अपेक्षा गर्छन्।
- परिणामहरू `CallToolResult` वस्तुहरूमा फर्काइन्छ जुन सर्भरबाट प्राप्त प्रतिक्रिया समावेश गर्छ।

### -5- क्लाइन्ट चलाउने

क्लाइन्ट चलाउन, टर्मिनलमा तलको कमाण्ड टाइप गर्नुहोस्:

### TypeScript

*package.json* को "scripts" सेक्सनमा तल थप्नुहोस्:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

क्लाइन्ट यसरी कल गर्नुहोस्:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

पहिले, सुनिश्चित गर्नुहोस् तपाईंको MCP सर्भर `http://localhost:8080` मा चलिरहेको छ। त्यसपछि क्लाइन्ट चलाउनुहोस्:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

अथवा, समाधान फोल्डर `03-GettingStarted\02-client\solution\java` मा उपलब्ध सम्पूर्ण क्लाइन्ट प्रोजेक्ट चलाउन सक्नुहुन्छ:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## असाइनमेन्ट

यस असाइनमेन्टमा, तपाईंले सिकेको प्रयोग गरी आफ्नै क्लाइन्ट बनाउनु हुनेछ।

यहाँ एउटा सर्भर छ जुन तपाईंले आफ्नो क्लाइन्ट कोडबाट कल गर्नुपर्नेछ, हेर्नुहोस् के तपाईं यसमा थप सुविधाहरू थप्न सक्नुहुन्छ ताकि यो अझ रोचक बनोस्।

### TypeScript

```typescript
import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";

// Create an MCP server
const server = new McpServer({
  name: "Demo",
  version: "1.0.0"
});

// Add an addition tool
server.tool("add",
  { a: z.number(), b: z.number() },
  async ({ a, b }) => ({
    content: [{ type: "text", text: String(a + b) }]
  })
);

// Add a dynamic greeting resource
server.resource(
  "greeting",
  new ResourceTemplate("greeting://{name}", { list: undefined }),
  async (uri, { name }) => ({
    contents: [{
      uri: uri.href,
      text: `Hello, ${name}!`
    }]
  })
);

// Start receiving messages on stdin and sending messages on stdout

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("MCPServer started on stdin/stdout");
}

main().catch((error) => {
  console.error("Fatal error: ", error);
  process.exit(1);
});
```

### Python

```python
# server.py
from mcp.server.fastmcp import FastMCP

# Create an MCP server
mcp = FastMCP("Demo")


# Add an addition tool
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b


# Add a dynamic greeting resource
@mcp.resource("greeting://{name}")
def get_greeting(name: str) -> str:
    """Get a personalized greeting"""
    return f"Hello, {name}!"

```

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class CalculatorTool
{
    [McpServerTool, Description("Adds two numbers")]
    public static string Add(int a, int b) => $"Sum {a + b}";
}
```

यस प्रोजेक्टलाई हेर्नुहोस् कसरी [प्रॉम्प्ट र स्रोतहरू थप्ने](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)।

त्यसैगरी, यो लिंकमा हेर्नुहोस् कसरी [प्रॉम्प्ट र स्रोतहरू कल गर्ने](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/)।

## समाधान

[Solution](./solution/README.md)

## मुख्य सिकाइहरू

यस अध्यायका मुख्य सिकाइहरू क्लाइन्टहरू सम्बन्धमा:

- सर्भरका सुविधाहरू पत्ता लगाउन र कल गर्न दुवै प्रयोग गर्न सकिन्छ।
- क्लाइन्टले आफैं सुरु हुँदा सर्भर पनि सुरु गर्न सक्छ (जस्तै यस अध्यायमा) तर क्लाइन्टहरू चलिरहेको सर्भरसँग पनि जडान हुन सक्छन्।
- इन्स्पेक्टर जस्ता विकल्पहरूका तुलनामा सर्भर क्षमताहरू परीक्षण गर्ने राम्रो तरिका हो।

## थप स्रोतहरू

- [MCP मा क्लाइन्ट बनाउने](https://modelcontextprotocol.io/quickstart/client)

## नमूनाहरू

- [Java क्याल्कुलेटर](../samples/java/calculator/README.md)
- [.Net क्याल्कुलेटर](../../../../03-GettingStarted/samples/csharp)
- [JavaScript क्याल्कुलेटर](../samples/javascript/README.md)
- [TypeScript क्याल्कुलेटर](../samples/typescript/README.md)
- [Python क्याल्कुलेटर](../../../../03-GettingStarted/samples/python)

## के छ अर्को

- अर्को: [LLM सहित क्लाइन्ट बनाउने](../03-llm-client/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनु पर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।