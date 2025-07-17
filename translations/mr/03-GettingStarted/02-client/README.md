<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-17T00:25:53+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "mr"
}
-->
# क्लायंट तयार करणे

क्लायंट म्हणजे कस्टम अॅप्लिकेशन्स किंवा स्क्रिप्ट्स जे थेट MCP सर्व्हरशी संवाद साधतात, संसाधने, टूल्स आणि प्रॉम्प्ट्स विनंती करण्यासाठी. इन्स्पेक्टर टूल वापरण्यापेक्षा, जे सर्व्हरशी संवाद साधण्यासाठी ग्राफिकल इंटरफेस देते, स्वतःचा क्लायंट लिहिणे प्रोग्रामॅटिक आणि स्वयंचलित संवाद शक्य करते. यामुळे डेव्हलपर्सना MCP क्षमता त्यांच्या स्वतःच्या वर्कफ्लोमध्ये समाकलित करता येतात, कामे स्वयंचलित करता येतात आणि विशिष्ट गरजांसाठी सानुकूल सोल्यूशन्स तयार करता येतात.

## आढावा

हा धडा Model Context Protocol (MCP) पर्यावरणातील क्लायंट्सची संकल्पना ओळख करून देतो. तुम्हाला स्वतःचा क्लायंट कसा लिहायचा आणि तो MCP सर्व्हरशी कसा जोडायचा हे शिकवले जाईल.

## शिकण्याचे उद्दिष्ट

या धड्याच्या शेवटी, तुम्ही सक्षम असाल:

- क्लायंट काय करू शकतो हे समजून घेणे.
- स्वतःचा क्लायंट लिहिणे.
- क्लायंट MCP सर्व्हरशी कनेक्ट करून तपासणे की सर्व्हर अपेक्षेनुसार कार्य करतोय की नाही.

## क्लायंट लिहिताना काय करावे लागते?

क्लायंट लिहिण्यासाठी तुम्हाला खालील गोष्टी कराव्या लागतील:

- **योग्य लायब्ररी आयात करा**. तुम्ही आधी वापरलेल्या लायब्ररीचा वापर करणार आहात, फक्त वेगवेगळ्या संरचना वापरून.
- **क्लायंटची उदाहरण तयार करा**. यामध्ये क्लायंटची एक उदाहरण तयार करणे आणि निवडलेल्या ट्रान्सपोर्ट पद्धतीशी जोडणे समाविष्ट आहे.
- **कोणती संसाधने यादी करायची ते ठरवा**. तुमच्या MCP सर्व्हरमध्ये संसाधने, टूल्स आणि प्रॉम्प्ट्स असतात, तुम्हाला ठरवायचे आहे कोणती यादी करायची.
- **क्लायंटला होस्ट अॅप्लिकेशनमध्ये समाकलित करा**. एकदा तुम्हाला सर्व्हरच्या क्षमतांची माहिती झाली की, तुम्हाला हा क्लायंट तुमच्या होस्ट अॅप्लिकेशनमध्ये समाकलित करायचा आहे जेणेकरून वापरकर्ता प्रॉम्प्ट किंवा इतर कमांड टाइप केल्यावर संबंधित सर्व्हर फिचर कॉल होईल.

आता आपण उच्चस्तरीयपणे काय करणार आहोत ते समजले, तर पुढे एक उदाहरण पाहूया.

### एक उदाहरण क्लायंट

हा उदाहरण क्लायंट पाहूया:

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

वरील कोडमध्ये आपण:

- लायब्ररी आयात केल्या
- क्लायंटची एक उदाहरण तयार केली आणि stdio ट्रान्सपोर्ट वापरून कनेक्ट केली.
- प्रॉम्प्ट्स, संसाधने आणि टूल्स यादी केली आणि त्यांना कॉल केले.

म्हणजेच, एक क्लायंट जो MCP सर्व्हरशी बोलू शकतो.

पुढील व्यायाम विभागात आपण प्रत्येक कोड स्निपेट तपासून त्याचा अर्थ समजून घेऊ.

## व्यायाम: क्लायंट लिहिणे

जसे वर सांगितले, आपण कोड समजावून घेण्यासाठी वेळ घेऊ आणि इच्छेनुसार कोडसुद्धा लिहू शकता.

### -1- लायब्ररी आयात करणे

आपल्याला आवश्यक लायब्ररी आयात करूया, ज्यात क्लायंट आणि निवडलेल्या ट्रान्सपोर्ट प्रोटोकॉल stdio संदर्भ असतील. stdio ही लोकल मशीनवर चालणाऱ्या गोष्टींसाठी प्रोटोकॉल आहे. SSE हा आणखी एक ट्रान्सपोर्ट प्रोटोकॉल आहे जो पुढील अध्यायांमध्ये दाखवला जाईल, पण सध्या stdio वापरूया.

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

Java साठी, तुम्ही मागील व्यायामातील MCP सर्व्हरशी कनेक्ट होणारा क्लायंट तयार कराल. [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) मधील Java Spring Boot प्रोजेक्ट स्ट्रक्चर वापरून, `src/main/java/com/microsoft/mcp/sample/client/` फोल्डरमध्ये `SDKClient` नावाचा नवीन Java क्लास तयार करा आणि खालील आयात जोडा:

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

आता इंस्टांटिएशनकडे वळूया.

### -2- क्लायंट आणि ट्रान्सपोर्ट इंस्टांटिएट करणे

आपल्याला ट्रान्सपोर्ट आणि क्लायंटची उदाहरण तयार करावी लागेल:

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

वरील कोडमध्ये आपण:

- stdio ट्रान्सपोर्टची उदाहरण तयार केली. यात कमांड आणि args कसे शोधायचे आणि सर्व्हर कसे सुरू करायचे हे दिले आहे, कारण क्लायंट तयार करताना हे आवश्यक आहे.

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- क्लायंटची उदाहरण तयार केली, त्याला नाव आणि आवृत्ती दिली.

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- क्लायंटला निवडलेल्या ट्रान्सपोर्टशी जोडले.

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

वरील कोडमध्ये आपण:

- आवश्यक लायब्ररी आयात केल्या
- सर्व्हर पॅरामीटर्स ऑब्जेक्ट तयार केला, ज्याचा वापर सर्व्हर चालवण्यासाठी होईल आणि क्लायंटशी कनेक्ट होण्यासाठी.
- `run` नावाची पद्धत परिभाषित केली जी `stdio_client` कॉल करते, ज्यामुळे क्लायंट सेशन सुरू होते.
- `asyncio.run` मध्ये `run` पद्धत दिली.

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

वरील कोडमध्ये आपण:

- आवश्यक लायब्ररी आयात केल्या.
- stdio ट्रान्सपोर्ट तयार केला आणि `mcpClient` नावाचा क्लायंट तयार केला. हा क्लायंट MCP सर्व्हरवरील फिचर्स यादी करण्यासाठी आणि कॉल करण्यासाठी वापरला जाईल.

टीप: "Arguments" मध्ये तुम्ही *.csproj* किंवा executable कडे निर्देश करू शकता.

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

वरील कोडमध्ये आपण:

- मुख्य मेथड तयार केली जी `http://localhost:8080` कडे SSE ट्रान्सपोर्ट सेट करते, जिथे MCP सर्व्हर चालणार आहे.
- क्लायंट क्लास तयार केला जो ट्रान्सपोर्ट कन्स्ट्रक्टर पॅरामीटर म्हणून घेतो.
- `run` मेथडमध्ये ट्रान्सपोर्ट वापरून सिंक्रोनस MCP क्लायंट तयार केला आणि कनेक्शन सुरू केले.
- SSE (Server-Sent Events) ट्रान्सपोर्ट वापरला, जो Java Spring Boot MCP सर्व्हरसाठी HTTP आधारित संवादासाठी योग्य आहे.

### -3- सर्व्हर फिचर्सची यादी करणे

आता आपल्याकडे क्लायंट आहे जो प्रोग्राम चालविल्यास कनेक्ट होऊ शकतो. पण तो त्याच्या फिचर्सची यादी करत नाही, तर ती आता करूया:

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

येथे आपण उपलब्ध संसाधने `list_resources()` आणि टूल्स `list_tools` यादी करतो आणि त्यांना प्रिंट करतो.

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

वरील उदाहरणात आपण सर्व्हरवरील टूल्स कसे यादी करू शकतो हे दाखवले आहे. प्रत्येक टूलचे नाव प्रिंट केले आहे.

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

वरील कोडमध्ये आपण:

- `listTools()` कॉल करून MCP सर्व्हरवरील सर्व टूल्स मिळवले.
- `ping()` वापरून सर्व्हरशी कनेक्शन कार्यरत आहे का ते तपासले.
- `ListToolsResult` मध्ये सर्व टूल्सची माहिती असते, जसे की नावे, वर्णने आणि इनपुट स्कीमा.

छान, आता सर्व फिचर्स मिळाले. आता प्रश्न आहे, आपण त्यांचा वापर कधी करतो? हा क्लायंट सोपा आहे, म्हणजे फिचर्स वापरण्यासाठी तुम्हाला त्यांना स्पष्टपणे कॉल करावे लागेल. पुढील अध्यायात आपण अधिक प्रगत क्लायंट तयार करू जो स्वतःच्या मोठ्या भाषा मॉडेल (LLM) शी जोडलेला असेल. सध्या, चला पाहूया सर्व्हरवरील फिचर्स कसे कॉल करायचे:

### -4- फिचर्स कॉल करणे

फिचर्स कॉल करण्यासाठी योग्य आर्ग्युमेंट्स आणि काही वेळा कॉल करायच्या गोष्टीचे नाव देणे आवश्यक आहे.

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

वरील कोडमध्ये आपण:

- एक संसाधन वाचले, `readResource()` कॉल करून `uri` दिले. सर्व्हरवर हे कसे दिसेल ते खालीलप्रमाणे:

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

    आमचा `uri` मूल्य `file://example.txt` सर्व्हरवरील `file://{name}` शी जुळते. `example.txt` हे `name` शी मॅप होईल.

- एक टूल कॉल केले, त्याचे `name` आणि `arguments` दिले:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- प्रॉम्प्ट मिळवला, `getPrompt()` कॉल करून `name` आणि `arguments` दिले. सर्व्हर कोड खालीलप्रमाणे:

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

    आणि क्लायंट कोड खालीलप्रमाणे दिसेल जे सर्व्हरवर घोषित केलेल्या गोष्टीशी जुळते:

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

वरील कोडमध्ये आपण:

- `greeting` नावाचे संसाधन `read_resource` वापरून कॉल केले.
- `add` नावाचा टूल `call_tool` वापरून कॉल केला.

### C#

1. टूल कॉल करण्यासाठी कोड:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

2. निकाल प्रिंट करण्यासाठी कोड:

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

वरील कोडमध्ये आपण:

- अनेक कॅल्क्युलेटर टूल्स `callTool()` मेथड वापरून `CallToolRequest` ऑब्जेक्ट्ससह कॉल केले.
- प्रत्येक टूल कॉलमध्ये टूलचे नाव आणि आवश्यक आर्ग्युमेंट्सचा `Map` दिला.
- सर्व्हर टूल्स विशिष्ट पॅरामीटर नावे अपेक्षित करतात (जसे "a", "b" गणितीय ऑपरेशन्ससाठी).
- निकाल `CallToolResult` ऑब्जेक्ट्समध्ये परत येतो ज्यात सर्व्हरचा प्रतिसाद असतो.

### -5- क्लायंट चालवणे

क्लायंट चालवण्यासाठी टर्मिनलमध्ये खालील कमांड टाइप करा:

### TypeScript

*package.json* मधील "scripts" विभागात खालील एंट्री जोडा:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

खालील कमांडने क्लायंट कॉल करा:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

सर्वप्रथम, तुमचा MCP सर्व्हर `http://localhost:8080` वर चालू आहे याची खात्री करा. नंतर क्लायंट चालवा:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

किंवा, संपूर्ण क्लायंट प्रोजेक्ट `03-GettingStarted\02-client\solution\java` फोल्डरमधून चालवा:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## असाइनमेंट

या असाइनमेंटमध्ये, तुम्ही शिकलेल्या गोष्टी वापरून स्वतःचा क्लायंट तयार कराल.

खालील सर्व्हर वापरून पाहा, ज्याला तुम्हाला तुमच्या क्लायंट कोडद्वारे कॉल करायचे आहे. पाहा तुम्ही सर्व्हरमध्ये अधिक फिचर्स कसे जोडू शकता जेणेकरून तो अधिक मनोरंजक बनेल.

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

हा प्रोजेक्ट पाहा ज्यात [प्रॉम्प्ट्स आणि संसाधने कशी जोडायची](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs) हे दाखवले आहे.

तसेच, [प्रॉम्प्ट्स आणि संसाधने कशी invoke करायची](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/) यासाठी हा लिंक तपासा.

## सोल्यूशन

[सोल्यूशन](./solution/README.md)

## मुख्य मुद्दे

या अध्यायातील मुख्य मुद्दे क्लायंट्सबद्दल:

- सर्व्हरवरील फिचर्स शोधण्यासाठी आणि कॉल करण्यासाठी वापरता येतात.
- स्वतः सुरू होणाऱ्या सर्व्हरला सुरू करू शकतात (जसे या अध्यायात) पण क्लायंट्स चालू असलेल्या सर्व्हरशी देखील कनेक्ट होऊ शकतात.
- Inspector सारख्या पर्यायांबरोबर सर्व्हरच्या क्षमतांची चाचणी करण्याचा उत्तम मार्ग आहे.

## अतिरिक्त संसाधने

- [MCP मध्ये क्लायंट तयार करणे](https://modelcontextprotocol.io/quickstart/client)

## नमुने

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## पुढे काय

- पुढे: [LLM सह क्लायंट तयार करणे](../03-llm-client/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.