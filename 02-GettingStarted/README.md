# Getting Started with MCP

## Overview

This lesson provides practical guidance on setting up MCP environments and building your first MCP applications. You'll learn how to set up the necessary tools and frameworks, build basic MCP servers, create host applications, and test your implementations.

## Learning Objectives

By the end of this lesson, you will be able to:
- Set up development environments for MCP in C#, Java, Python, TypeScript, and JavaScript
- Build and deploy basic MCP servers with custom features (resources, prompts, and tools)
- Create host applications that connect to MCP servers
- Test and debug MCP implementations
- Understand common setup challenges and their solutions

## Setting Up Your MCP Environment

### Prerequisites

Before diving into MCP development, ensure you have:

1. **Development Environment**: For your chosen language (C#, Java, Python, TypeScript, or JavaScript)
2. **IDE/Editor**: Visual Studio, VS Code, IntelliJ, Eclipse, PyCharm, or any modern code editor
3. **Package Managers**: NuGet, Maven/Gradle, pip, or npm/yarn
4. **API Keys**: For any AI services you plan to use in your host applications

### Official SDKs

MCP provides official SDKs for multiple languages:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

### Installation and Setup

#### C# Setup

```csharp
// Create a new .NET project for your MCP server
dotnet new console -n McpCSharpServer

// Change to the project directory
cd McpCSharpServer

// Add the MCP NuGet packages
dotnet add package ModelContextProtocol.SDK --prerelease
```

#### Java Setup

```bash
# Using Maven - Create a new Java project with Maven
mvn archetype:generate -DgroupId=com.example.mcp -DartifactId=mcp-java-server -DarchetypeArtifactId=maven-archetype-quickstart -DinteractiveMode=false

# Add MCP dependencies to pom.xml
<dependencies>
    <dependency>
        <groupId>io.modelcontextprotocol</groupId>
        <artifactId>mcp-sdk</artifactId>
        <version>0.1.0</version>
    </dependency>
</dependencies>
```

#### TypeScript/JavaScript Setup

```bash
# Create a new npm project
mkdir mcp-ts-server && cd mcp-ts-server
npm init -y

# Install the MCP TypeScript SDK
npm install @modelcontextprotocol/typescript-sdk
```

#### Python Setup

```bash
# Create a virtual environment
python -m venv mcp-env
source mcp-env/bin/activate  # On Windows: mcp-env\Scripts\activate

# Install the MCP Python SDK
pip install modelcontextprotocol
        <groupId>com.mcp</groupId>
        <artifactId>mcp-server</artifactId>
        <version>1.0.0</version>
    </dependency>
</dependencies>
```

#### Python Setup

```bash
# Create a virtual environment
python -m venv mcp-env

# Activate the virtual environment
# On Windows:
mcp-env\Scripts\activate
# On macOS/Linux:
source mcp-env/bin/activate

# Install MCP packages
pip install mcp-server mcp-client
```

#### JavaScript Setup

```bash
# Initialize a new Node.js project
npm init -y

# Install MCP server package
npm install @mcp/server express
```

## Creating Your First MCP Server

An MCP server provides tools that extend the capabilities of AI models. Let's start by creating a simple MCP server with a calculator tool.

### .NET Implementation

This sample demonstrates how to create an MCP server in C# with a calculator tool implementation:

```csharp
// Create a host builder for the MCP server
var builder = Host.CreateApplicationBuilder(args);

// Configure the MCP server with tools
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()  
    .WithHttpServerTransport(options => { options.Port = 5000; })
    .WithTools<CalculatorTools>();  // Register our calculator tools

// Run the application
await builder.Build().RunAsync();
```

See the complete implementation in [samples/csharp/McpCalculatorServer.cs](./samples/csharp/McpCalculatorServer.cs)

### Java Implementation

This sample demonstrates how to create an MCP server in Java with a calculator tool implementation:

```java
package com.example.mcp;

import com.mcp.server.McpServer;

public class McpCalculatorServer {
    public static void main(String[] args) {
        // Create and configure MCP server
        McpServer server = new McpServer.Builder()
            .setName("Calculator MCP Server")
            .setVersion("1.0.0")
            .setPort(5000)
            .build();
        
        // Register calculator tool
        server.registerTool(new CalculatorTool());
        
        // Start server
        server.start();
        System.out.println("Calculator MCP Server started on port 5000");
    }
}
```

See the complete implementation in [samples/java/McpCalculatorServer.java](./samples/java/McpCalculatorServer.java)

class CalculatorTool implements Tool {
    @Override
    public String getName() {
        return "calculator";
    }
    
    @Override
    public String getDescription() {
        return "Performs basic arithmetic operations";
    }
    
    @Override
    public Object getSchema() {
        // Define parameter schema
        Map<String, Object> schema = new HashMap<>();
        schema.put("type", "object");
        
        Map<String, Object> properties = new HashMap<>();
        
        Map<String, Object> operation = new HashMap<>();
        operation.put("type", "string");
        operation.put("enum", Arrays.asList("add", "subtract", "multiply", "divide"));
        properties.put("operation", operation);
        
        Map<String, Object> a = new HashMap<>();
        a.put("type", "number");
        properties.put("a", a);
        
        Map<String, Object> b = new HashMap<>();
        b.put("type", "number");
        properties.put("b", b);
        
        schema.put("properties", properties);
        schema.put("required", Arrays.asList("operation", "a", "b"));
        
        return schema;
    }
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        // Extract parameters
        String operation = request.getParameters().get("operation").asText();
        double a = request.getParameters().get("a").asDouble();
        double b = request.getParameters().get("b").asDouble();
        
        double result = 0;
        
        // Perform calculation
        switch (operation) {
            case "add":
                result = a + b;
                break;
            case "subtract":
                result = a - b;
                break;
            case "multiply":
                result = a * b;
                break;
            case "divide":
                if (b == 0) {
                    throw new ToolExecutionException("Cannot divide by zero");
                }
                result = a / b;
                break;
            default:
                throw new ToolExecutionException("Unknown operation: " + operation);
        }
        
        // Create response
        Map<String, Object> response = new HashMap<>();
        response.put("result", result);
        
        return new ToolResponse.Builder()
            .setResult(response)
            .build();
    }
}
```

### Python Implementation

This sample demonstrates how to create an MCP server in Python with a calculator tool implementation:

```python
from mcp_server import McpServer
from mcp_tools import Tool, ToolRequest, ToolResponse

# Create calculator tool class
class CalculatorTool(Tool):
    def get_name(self):
        return "calculator"
        
    def get_description(self):
        return "Performs basic arithmetic operations"
    
    # Define the tool schema including parameters
    def get_schema(self):
        return {
            "type": "object",
            "properties": {
                "operation": {
                    "type": "string",
                    "enum": ["add", "subtract", "multiply", "divide"]
                },
                "a": {"type": "number"},
                "b": {"type": "number"}
            },
            "required": ["operation", "a", "b"]
        }
    
    # Create and start server
    if __name__ == "__main__":
        # Initialize server
        server = McpServer(name="Calculator MCP Server")
        
        # Register tools
        server.register_tool(CalculatorTool())
        
        # Start server
        server.start()
```

See the complete implementation in [samples/python/mcp_calculator_server.py](./samples/python/mcp_calculator_server.py)

### JavaScript Implementation

This sample demonstrates how to create an MCP server in JavaScript with a calculator tool implementation:

```javascript
const express = require('express');
const { McpServer, ToolRegistry } = require('@mcp/server');

// Create calculator tool
class CalculatorTool {
  getName() {
    return 'calculator';
  }

  getDescription() {
    return 'Performs basic arithmetic operations';
  }

  getSchema() {
    return {
      type: 'object',
      properties: {
        operation: {
          type: 'string',
          enum: ['add', 'subtract', 'multiply', 'divide']
        },
        a: { type: 'number' },
        b: { type: 'number' }
      },
      required: ['operation', 'a', 'b']
    };
  }
}

// Create Express app
const app = express();
app.use(express.json());

// Create and configure MCP server
const toolRegistry = new ToolRegistry();
toolRegistry.registerTool(new CalculatorTool());

const mcpServer = new McpServer({
  serverName: 'Calculator MCP Server',
  serverVersion: '1.0.0',
  toolRegistry: toolRegistry
});

// Start server
const PORT = process.env.PORT || 5000;
app.listen(PORT, () => {
  console.log(`Calculator MCP Server started on port ${PORT}`);
});
```

See the complete implementation in [samples/javascript/mcp_calculator_server.js](./samples/javascript/mcp_calculator_server.js)

## Building an MCP Client

Now let's create a client application that connects to our MCP server and uses the calculator tool.

### .NET Client

```csharp
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyFirstMCP;

public class MonkeyService
{
    HttpClient httpClient;
    public MonkeyService()
    {
        this.httpClient = new HttpClient();  
    }

    List<Monkey> monkeyList = new();
    public async Task<List<Monkey>> GetMonkeys()
    {
        if (monkeyList?.Count > 0)
            return monkeyList;

        var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
        if (response.IsSuccessStatusCode)
        {
            monkeyList = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey) ?? [];
        }

        monkeyList ??= [];

        return monkeyList;
    }

    public async Task<Monkey?> GetMonkey(string name)
    {
        var monkeys = await GetMonkeys();
        return monkeys.FirstOrDefault(m => m.Name?.Equals(name, StringComparison.OrdinalIgnoreCase) == true);
    }
}

public partial class Monkey
{
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Details { get; set; }
    public string? Image { get; set; }
    public int Population { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

[JsonSerializable(typeof(List<Monkey>))]
internal sealed partial class MonkeyContext : JsonSerializerContext {

}
```

### Java Client

```java
package com.example.mcp.client;

import com.mcp.client.McpClient;
import com.mcp.models.McpRequest;
import com.mcp.models.McpResponse;
import com.mcp.models.McpToolCall;

public class CalculatorClient {
    public static void main(String[] args) {
        // Create MCP client
        McpClient client = new McpClient.Builder()
            .setServerUrl("http://localhost:5000")
            .build();
            
        // Define prompt
        String prompt = "What is 135 * 28?";
        
        System.out.println("User: " + prompt);
        
        // Create request
        McpRequest request = new McpRequest.Builder()
            .setPrompt(prompt)
            .addTool("calculator")
            .build();
            
        // Send request and get response
        McpResponse response = client.sendRequest(request);
        
        // Display response
        System.out.println("AI: " + response.getGeneratedText());
        
        // Display tool usage information
        if (!response.getToolCalls().isEmpty()) {
            System.out.println("\nTool calls made:");
            for (McpToolCall toolCall : response.getToolCalls()) {
                System.out.println("- " + toolCall.getToolName() + 
                    " with parameters: " + toolCall.getParameters());
                System.out.println("  Result: " + toolCall.getResult());
            }
        }
    }
}
```

### Python Client

```python
from mcp_client import McpClient

# Initialize the MCP client
client = McpClient(server_url="http://localhost:5000")

# Define prompt
prompt = "What is 135 * 28?"

print(f"User: {prompt}")

# Send the request to the MCP server
response = client.send_prompt(
    prompt=prompt,
    allowed_tools=["calculator"]
)

# Display response
print(f"AI: {response.generated_text}")

# Display tool usage information
if response.tool_calls:
    print("\nTool calls made:")
    for tool_call in response.tool_calls:
        print(f"- {tool_call.tool_name} with parameters: {tool_call.parameters}")
        print(f"  Result: {tool_call.result}")
```

### JavaScript Client

```javascript
// Using Node.js with the MCP client
const { McpClient } = require('@mcp/client');

// Create MCP client
const client = new McpClient({
  serverUrl: 'http://localhost:5000'
});

// Define prompt
const prompt = "What is 135 * 28?";

console.log(`User: ${prompt}`);

// Send request to the MCP server
(async () => {
  try {
    const response = await client.sendPrompt(prompt, {
      allowedTools: ['calculator']
    });
    
    // Display response
    console.log(`AI: ${response.generatedText}`);
    
    // Display tool usage information
    if (response.toolCalls && response.toolCalls.length > 0) {
      console.log('\nTool calls made:');
      response.toolCalls.forEach(toolCall => {
        console.log(`- ${toolCall.name} with parameters:`, toolCall.parameters);
        console.log(`  Result:`, toolCall.result);
      });
    }
  } catch (error) {
    console.error('Error communicating with MCP server:', error);
  }
})();
```

#### Browser-Based JavaScript Client

```javascript
// Using the MCP client library in a browser environment
import { McpClient } from '@mcp/client-browser';

// Set up the UI elements
const promptInput = document.getElementById('prompt-input');
const submitButton = document.getElementById('submit-button');
const responseDiv = document.getElementById('response');
const toolCallsDiv = document.getElementById('tool-calls');

// Initialize the client
const client = new McpClient({
  serverUrl: '/api/mcp' // Relative URL for browser environment
});

// Handle form submission
submitButton.addEventListener('click', async () => {
  const prompt = promptInput.value;
  if (!prompt) return;
  
  try {
    // Show loading state
    responseDiv.textContent = 'Thinking...';
    toolCallsDiv.textContent = '';
    
    // Send the request
    const response = await client.sendPrompt(prompt, {
      allowedTools: ['calculator'],
      temperature: 0.7
    });
    
    // Display the response
    responseDiv.textContent = response.generatedText;
    
    // Display any tool calls
    if (response.toolCalls && response.toolCalls.length > 0) {
      const toolCallsList = document.createElement('ul');
      
      response.toolCalls.forEach(toolCall => {
        const listItem = document.createElement('li');
        listItem.innerHTML = `
          <strong>${toolCall.name}</strong> called with parameters: 
          <pre>${JSON.stringify(toolCall.parameters, null, 2)}</pre>
          <br>
          Result: <pre>${JSON.stringify(toolCall.result, null, 2)}</pre>
        `;
        toolCallsList.appendChild(listItem);
      });
      
      toolCallsDiv.innerHTML = '<h4>Tool Calls:</h4>';
      toolCallsDiv.appendChild(toolCallsList);
    }
  } catch (error) {
    responseDiv.textContent = `Error: ${error.message}`;
  }
});
```

## Testing and Debugging

### Testing MCP Servers

To ensure your MCP server works correctly:

1. **Direct API Testing**:
   - Use tools like Postman or cURL to send requests directly to your MCP server
   - Verify tool schemas and execution paths

2. **MCP Inspector Tool**:
   ```bash
   # Install MCP Inspector (Python)
   pip install mcp-inspector
   
   # Launch inspector
   mcp-inspector --server-url http://localhost:5000
   ```

3. **Unit Tests**:
   - Test each tool independently
   - Validate parameter validation and error handling

### Common Setup Issues and Solutions

| Issue | Possible Solution |
|-------|-------------------|
| Connection refused | Check if server is running and port is correct |
| Tool execution errors | Review parameter validation and error handling |
| Authentication failures | Verify API keys and permissions |
| Schema validation errors | Ensure parameters match the defined schema |
| Server not starting | Check for port conflicts or missing dependencies |

## Deploying MCP Servers

### Local Development

For local testing and development, run MCP servers directly in your IDE or terminal.

### Container Deployment

Use Docker for containerized deployment:

```dockerfile
# Dockerfile for Python MCP Server
FROM python:3.9

WORKDIR /app

COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

COPY . .

EXPOSE 5000

CMD ["python", "calculator_server.py"]
```

### Cloud Deployment

Deploy MCP servers to cloud platforms:

1. **Azure App Service**:
   - Supports .NET, Java, Python, and JavaScript
   - Easy integration with Azure services

2. **AWS Lambda**:
   - Serverless deployment option
   - Pay-per-use pricing model

3. **Kubernetes**:
   - For high-availability deployments
   - Scalable and resilient

## Exploring Pre-Built Integrations

Several pre-built MCP integrations are available:

1. **Azure OpenAI MCP Host**:
   - Connects to Azure OpenAI models
   - Supports tool calling capabilities

2. **Hugging Face Integration**:
   - Uses open-source models
   - Local deployment options

3. **Database Connectors**:
   - SQL and NoSQL database tools
   - Data retrieval and manipulation

## Key Takeaways

- Setting up an MCP development environment is straightforward with language-specific SDKs
- Building MCP servers involves creating and registering tools with clear schemas
- MCP clients connect to servers and models to leverage extended capabilities
- Testing and debugging are essential for reliable MCP implementations
- Deployment options range from local development to cloud-based solutions

## Exercise

Create a simple MCP server with a tool of your choice:
1. Implement the tool in your preferred language (.NET, Java, Python, or JavaScript)
2. Define input parameters and return values
3. Build a simple client that uses your tool
4. Test the implementation with various inputs

## Additional Resources

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

---

Next: [Practical Implementation](../03-PracticalImplementation/README.md)