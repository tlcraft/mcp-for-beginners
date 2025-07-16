<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c6f267185e24b1274dd3535d65dd1787",
  "translation_date": "2025-07-16T22:50:52+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hi"
}
-->
# क्लाइंट बनाना

क्लाइंट कस्टम एप्लिकेशन या स्क्रिप्ट होते हैं जो सीधे MCP सर्वर से संसाधन, टूल्स और प्रॉम्प्ट्स के लिए संवाद करते हैं। इंस्पेक्टर टूल के उपयोग से अलग, जो सर्वर के साथ इंटरैक्ट करने के लिए एक ग्राफिकल इंटरफेस प्रदान करता है, अपना खुद का क्लाइंट लिखने से प्रोग्रामेटिक और स्वचालित इंटरैक्शन संभव होता है। इससे डेवलपर्स MCP की क्षमताओं को अपने वर्कफ़्लो में शामिल कर सकते हैं, कार्यों को स्वचालित कर सकते हैं, और विशिष्ट आवश्यकताओं के अनुसार कस्टम समाधान बना सकते हैं।

## अवलोकन

यह पाठ MCP इकोसिस्टम में क्लाइंट्स की अवधारणा से परिचित कराता है। आप सीखेंगे कि अपना क्लाइंट कैसे लिखें और उसे MCP सर्वर से कनेक्ट करें।

## सीखने के उद्देश्य

इस पाठ के अंत तक, आप सक्षम होंगे:

- समझना कि क्लाइंट क्या कर सकता है।
- अपना खुद का क्लाइंट लिखना।
- क्लाइंट को MCP सर्वर से कनेक्ट करना और परीक्षण करना ताकि यह सुनिश्चित हो सके कि सर्वर अपेक्षित रूप से काम कर रहा है।

## क्लाइंट लिखने में क्या शामिल है?

क्लाइंट लिखने के लिए आपको निम्न करना होगा:

- **सही लाइब्रेरी इम्पोर्ट करें।** आप वही लाइब्रेरी उपयोग करेंगे जो पहले इस्तेमाल की थी, बस कुछ अलग संरचनाओं के साथ।
- **क्लाइंट का उदाहरण बनाएं।** इसमें क्लाइंट का एक इंस्टेंस बनाना और उसे चुने हुए ट्रांसपोर्ट मेथड से कनेक्ट करना शामिल होगा।
- **निर्धारित करें कि कौन से संसाधन सूचीबद्ध करने हैं।** आपका MCP सर्वर संसाधन, टूल्स और प्रॉम्प्ट्स के साथ आता है, आपको तय करना होगा कि इनमें से कौन-कौन सूचीबद्ध करना है।
- **क्लाइंट को होस्ट एप्लिकेशन में इंटीग्रेट करें।** जब आप सर्वर की क्षमताओं को जान लें, तो इसे अपने होस्ट एप्लिकेशन में जोड़ें ताकि यदि कोई उपयोगकर्ता प्रॉम्प्ट या अन्य कमांड टाइप करे तो संबंधित सर्वर फीचर सक्रिय हो।

अब जब हमने उच्च स्तर पर समझ लिया कि हमें क्या करना है, तो आइए अगला उदाहरण देखें।

### एक उदाहरण क्लाइंट

आइए इस उदाहरण क्लाइंट को देखें:

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

पिछले कोड में हमने:

- लाइब्रेरी इम्पोर्ट कीं
- क्लाइंट का एक इंस्टेंस बनाया और stdio ट्रांसपोर्ट के माध्यम से कनेक्ट किया।
- प्रॉम्प्ट्स, संसाधन और टूल्स को सूचीबद्ध किया और उन्हें कॉल किया।

बस, आपके पास एक ऐसा क्लाइंट है जो MCP सर्वर से बात कर सकता है।

आइए अगले अभ्यास भाग में हर कोड स्निपेट को विस्तार से समझें।

## अभ्यास: क्लाइंट लिखना

जैसा कि ऊपर कहा गया, चलिए कोड को विस्तार से समझते हैं, और यदि आप चाहें तो साथ-साथ कोड भी करें।

### -1- लाइब्रेरी इम्पोर्ट करना

आइए आवश्यक लाइब्रेरी इम्पोर्ट करें, हमें क्लाइंट और चुने हुए ट्रांसपोर्ट प्रोटोकॉल stdio के संदर्भ चाहिए होंगे। stdio एक ऐसा प्रोटोकॉल है जो स्थानीय मशीन पर चलने वाली चीज़ों के लिए है। SSE एक अन्य ट्रांसपोर्ट प्रोटोकॉल है जिसे हम भविष्य के अध्यायों में दिखाएंगे, लेकिन फिलहाल हम stdio के साथ आगे बढ़ेंगे।

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

Java के लिए, आप पिछले अभ्यास से MCP सर्वर से कनेक्ट होने वाला क्लाइंट बनाएंगे। [Getting Started with MCP Server](../../../../03-GettingStarted/01-first-server/solution/java) में उपयोग किए गए Java Spring Boot प्रोजेक्ट स्ट्रक्चर का उपयोग करते हुए, `src/main/java/com/microsoft/mcp/sample/client/` फोल्डर में `SDKClient` नाम की एक नई Java क्लास बनाएं और निम्न इम्पोर्ट्स जोड़ें:

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

अब इंस्टैंसिएशन की ओर बढ़ते हैं।

### -2- क्लाइंट और ट्रांसपोर्ट का इंस्टैंसिएशन

हमें ट्रांसपोर्ट और क्लाइंट दोनों के इंस्टेंस बनाने होंगे:

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

पिछले कोड में हमने:

- stdio ट्रांसपोर्ट का एक इंस्टेंस बनाया। ध्यान दें कि इसमें कमांड और आर्ग्स दिए गए हैं जो सर्वर को खोजने और शुरू करने के लिए हैं, क्योंकि क्लाइंट बनाते समय हमें यह करना होगा।

    ```typescript
    const transport = new StdioClientTransport({
        command: "node",
        args: ["server.js"]
    });
    ```

- क्लाइंट का इंस्टेंस बनाया, नाम और संस्करण दिया।

    ```typescript
    const client = new Client(
    {
        name: "example-client",
        version: "1.0.0"
    });
    ```

- क्लाइंट को चुने हुए ट्रांसपोर्ट से कनेक्ट किया।

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

पिछले कोड में हमने:

- आवश्यक लाइब्रेरी इम्पोर्ट कीं
- सर्वर पैरामीटर्स ऑब्जेक्ट बनाया क्योंकि हम इसे सर्वर चलाने के लिए उपयोग करेंगे ताकि क्लाइंट उससे कनेक्ट हो सके।
- `run` नामक एक मेथड परिभाषित किया जो `stdio_client` को कॉल करता है, जो क्लाइंट सेशन शुरू करता है।
- एक एंट्री पॉइंट बनाया जहां `asyncio.run` के माध्यम से `run` मेथड को चलाया जाता है।

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

पिछले कोड में हमने:

- आवश्यक लाइब्रेरी इम्पोर्ट कीं।
- stdio ट्रांसपोर्ट बनाया और `mcpClient` नामक क्लाइंट बनाया। इसे हम MCP सर्वर पर फीचर्स को सूचीबद्ध और कॉल करने के लिए उपयोग करेंगे।

ध्यान दें, "Arguments" में आप *.csproj* या executable दोनों में से किसी को भी पॉइंट कर सकते हैं।

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

पिछले कोड में हमने:

- एक main मेथड बनाया जो `http://localhost:8080` पर SSE ट्रांसपोर्ट सेट करता है, जहां हमारा MCP सर्वर चल रहा होगा।
- एक क्लाइंट क्लास बनाया जो ट्रांसपोर्ट को कंस्ट्रक्टर पैरामीटर के रूप में लेता है।
- `run` मेथड में, ट्रांसपोर्ट का उपयोग करके सिंक्रोनस MCP क्लाइंट बनाया और कनेक्शन इनिशियलाइज़ किया।
- SSE (Server-Sent Events) ट्रांसपोर्ट का उपयोग किया जो Java Spring Boot MCP सर्वर के लिए HTTP आधारित संचार के लिए उपयुक्त है।

### -3- सर्वर फीचर्स की सूची बनाना

अब हमारे पास एक क्लाइंट है जो कनेक्ट हो सकता है यदि प्रोग्राम चलाया जाए। हालांकि, यह अभी तक फीचर्स की सूची नहीं दिखाता, तो आइए इसे करें:

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

यहां हम उपलब्ध संसाधन `list_resources()` और टूल्स `list_tools` को सूचीबद्ध करते हैं और उन्हें प्रिंट करते हैं।

### .NET

```dotnet
foreach (var tool in await client.ListToolsAsync())
{
    Console.WriteLine($"{tool.Name} ({tool.Description})");
}
```

ऊपर एक उदाहरण है कि हम सर्वर पर टूल्स को कैसे सूचीबद्ध कर सकते हैं। प्रत्येक टूल के लिए, हम उसका नाम प्रिंट करते हैं।

### Java

```java
// List and demonstrate tools
ListToolsResult toolsList = client.listTools();
System.out.println("Available Tools = " + toolsList);

// You can also ping the server to verify connection
client.ping();
```

पिछले कोड में हमने:

- `listTools()` को कॉल किया ताकि MCP सर्वर से सभी उपलब्ध टूल्स मिल सकें।
- `ping()` का उपयोग किया ताकि यह सत्यापित किया जा सके कि सर्वर से कनेक्शन काम कर रहा है।
- `ListToolsResult` में सभी टूल्स की जानकारी होती है, जिनमें उनके नाम, विवरण और इनपुट स्कीमा शामिल हैं।

बहुत बढ़िया, अब हमने सभी फीचर्स को कैप्चर कर लिया है। अब सवाल यह है कि हम इन्हें कब उपयोग करें? यह क्लाइंट काफी सरल है, इसका मतलब है कि हमें जब भी फीचर्स चाहिए, उन्हें स्पष्ट रूप से कॉल करना होगा। अगले अध्याय में, हम एक अधिक उन्नत क्लाइंट बनाएंगे जिसमें अपना खुद का बड़ा भाषा मॉडल (LLM) होगा। फिलहाल, आइए देखें कि सर्वर पर फीचर्स को कैसे कॉल करें:

### -4- फीचर्स को कॉल करना

फीचर्स को कॉल करने के लिए हमें सही आर्गुमेंट्स देना होंगे और कुछ मामलों में उस फीचर का नाम भी देना होगा जिसे हम कॉल कर रहे हैं।

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

पिछले कोड में हमने:

- एक संसाधन पढ़ा, `readResource()` को `uri` के साथ कॉल किया। सर्वर साइड पर यह कुछ इस तरह दिखेगा:

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

    हमारा `uri` मान `file://example.txt` सर्वर पर `file://{name}` से मेल खाता है। `example.txt` को `name` के रूप में मैप किया जाएगा।

- एक टूल कॉल किया, इसे `name` और `arguments` देकर कॉल किया:

    ```typescript
    const result = await client.callTool({
        name: "example-tool",
        arguments: {
            arg1: "value"
        }
    });
    ```

- प्रॉम्प्ट प्राप्त किया, `getPrompt()` को `name` और `arguments` के साथ कॉल किया। सर्वर कोड इस प्रकार है:

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

    और आपके क्लाइंट कोड में यह इस तरह दिखेगा ताकि सर्वर पर घोषित चीज़ों से मेल खाए:

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

पिछले कोड में हमने:

- `greeting` नामक संसाधन को `read_resource` के माध्यम से कॉल किया।
- `add` नामक टूल को `call_tool` के माध्यम से कॉल किया।

### C#

1. आइए टूल कॉल करने के लिए कुछ कोड जोड़ें:

  ```csharp
  var result = await mcpClient.CallToolAsync(
      "Add",
      new Dictionary<string, object?>() { ["a"] = 1, ["b"] = 3  },
      cancellationToken:CancellationToken.None);
  ```

1. परिणाम प्रिंट करने के लिए, यहां कुछ कोड है:

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

पिछले कोड में हमने:

- कई कैलकुलेटर टूल्स को `callTool()` मेथड के साथ `CallToolRequest` ऑब्जेक्ट्स के माध्यम से कॉल किया।
- प्रत्येक टूल कॉल में टूल का नाम और आवश्यक आर्गुमेंट्स का `Map` दिया गया।
- सर्वर टूल्स विशिष्ट पैरामीटर नामों (जैसे "a", "b" गणितीय ऑपरेशंस के लिए) की उम्मीद करते हैं।
- परिणाम `CallToolResult` ऑब्जेक्ट्स के रूप में लौटते हैं जिनमें सर्वर से प्रतिक्रिया होती है।

### -5- क्लाइंट चलाना

क्लाइंट चलाने के लिए, टर्मिनल में निम्न कमांड टाइप करें:

### TypeScript

*package.json* की "scripts" सेक्शन में निम्न एंट्री जोड़ें:

```json
"client": "tsx && node build/client.js"
```

```sh
npm run client
```

### Python

क्लाइंट को निम्न कमांड से कॉल करें:

```sh
python client.py
```

### .NET

```sh
dotnet run
```

### Java

सबसे पहले सुनिश्चित करें कि आपका MCP सर्वर `http://localhost:8080` पर चल रहा है। फिर क्लाइंट चलाएं:

```bash
# Build you project
./mvnw clean compile

# Run the client
./mvnw exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

वैकल्पिक रूप से, आप समाधान फोल्डर `03-GettingStarted\02-client\solution\java` में उपलब्ध पूर्ण क्लाइंट प्रोजेक्ट चला सकते हैं:

```bash
# Navigate to the solution directory
cd 03-GettingStarted/02-client/solution/java

# Build and run the JAR
./mvnw clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## असाइनमेंट

इस असाइनमेंट में, आप जो कुछ सीखे हैं उसका उपयोग करते हुए अपना खुद का क्लाइंट बनाएंगे।

यहां एक सर्वर है जिसे आपको अपने क्लाइंट कोड के माध्यम से कॉल करना है, देखें कि क्या आप सर्वर में और फीचर्स जोड़ सकते हैं ताकि यह और अधिक रोचक बन सके।

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

इस प्रोजेक्ट को देखें कि आप [प्रॉम्प्ट्स और संसाधन कैसे जोड़ सकते हैं](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/samples/EverythingServer/Program.cs)।

साथ ही, इस लिंक को देखें कि [प्रॉम्प्ट्स और संसाधन कैसे कॉल करें](https://github.com/modelcontextprotocol/csharp-sdk/blob/main/src/ModelContextProtocol/Client/)।

## समाधान

[Solution](./solution/README.md)

## मुख्य बातें

इस अध्याय की मुख्य बातें क्लाइंट्स के बारे में निम्नलिखित हैं:

- क्लाइंट्स का उपयोग सर्वर पर फीचर्स को खोजने और कॉल करने दोनों के लिए किया जा सकता है।
- क्लाइंट्स खुद को शुरू करते समय सर्वर भी शुरू कर सकते हैं (जैसे इस अध्याय में), लेकिन क्लाइंट्स चल रहे सर्वर से भी कनेक्ट हो सकते हैं।
- यह सर्वर की क्षमताओं का परीक्षण करने का एक शानदार तरीका है, इंस्पेक्टर जैसे विकल्पों के साथ जैसा पिछले अध्याय में बताया गया था।

## अतिरिक्त संसाधन

- [MCP में क्लाइंट बनाना](https://modelcontextprotocol.io/quickstart/client)

## सैंपल्स

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## आगे क्या है

- अगला: [LLM के साथ क्लाइंट बनाना](../03-llm-client/README.md)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।