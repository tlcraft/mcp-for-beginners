# MCP Core Concepts

## Overview

This lesson explores the fundamental architecture and components that make up the Model Context Protocol (MCP) ecosystem. You'll learn about the client-server architecture, key components, and communication mechanisms that power MCP interactions.

## Learning Objectives

By the end of this lesson, you will:
- Understand the client-server architecture that underlies MCP
- Identify the key components of the MCP ecosystem
- Explain the different communication mechanisms used in MCP
- Recognize the flow of information between components

## MCP Architecture: A Deeper Look

The MCP architecture follows a client-server model designed to facilitate seamless integration between LLM applications and external data sources and tools. Let's break down this architecture into its core components.

### 1. Hosts

**Hosts** are LLM applications that initiate connections. They:

- Execute or interact with AI models to generate responses
- Initiate connections with MCP servers
- Manage the conversation flow and user interface
- Control permission and security constraints
- Handle user consent for data sharing and tool execution

Examples of Hosts include chat applications, productivity tools, and enterprise software that leverages AI capabilities.

### 2. Clients

**Clients** are connectors within the host application. They:

- Send requests to servers with prompts/instructions
- Negotiate capabilities with servers
- Manage tool execution requests from models
- Process and display responses to users

Clients operate as part of the host application to facilitate communication with MCP servers.

### 3. Servers

**Servers** are services that provide context and capabilities. They:

- Register available features (resources, prompts, tools)
- Receive and execute tool calls from the client
- Provide contextual information to enhance model responses
- Return outputs back to the client
- Maintain state across interactions when needed

Servers can be developed by anyone to extend model capabilities with specialized functionality.

### 4. Server Features

MCP servers can offer any of the following features:

#### Resources
- Context and data for the user or AI model to use
- Knowledge bases and document repositories
- Local files and databases
- APIs and web services

#### Prompts
- Templated messages and workflows for users
- Pre-defined interaction patterns
- Specialized conversation templates

#### Tools
- Functions for the AI model to execute
- Each tool has a unique name and description
- Accepts specific parameters and returns structured outputs
- Performs discrete functions (e.g., web search, calculation, database query)

### 5. Client Features

Clients may offer the following feature to servers:

#### Sampling
- Server-initiated agentic behaviors
- Recursive LLM interactions
- Allows servers to request additional model completions

## Information Flow in MCP

1. **Host Initiates Connection**: The host application connects to an MCP server
2. **Capability Negotiation**: Client and server exchange information about their capabilities
3. **User Request**: The user provides a prompt or request to the host
4. **Resource or Tool Use**: 
   - The client may request resources from the server
   - When the model needs to use a tool, the client sends a request to the server
5. **Server Execution**: The server processes the request and returns results
6. **Response Generation**: The client incorporates server responses into the model's output
7. **Result Presentation**: The host presents the final response to the user

## Protocol Details

MCP is built on [JSON-RPC](https://www.jsonrpc.org/) 2.0, providing a standardized message format for communication between components.

### Key Protocol Features

#### Base Protocol
- JSON-RPC message format
- Stateful connections
- Server and client capability negotiation

#### Additional Utilities
- Configuration options
- Progress tracking
- Request cancellation
- Error reporting
- Logging

### Security Considerations

MCP implementations should follow these key security principles:

1. **User Consent and Control**
   - Explicit consent for data access and operations
   - User control over shared data and actions
   - Clear UIs for reviewing and authorizing activities

2. **Data Privacy**
   - Explicit consent before exposing user data
   - Appropriate access controls for user data
   - Protection against unauthorized data transmission

3. **Tool Safety**
   - Explicit consent before tool invocation
   - Clear understanding of tool functionality
   - Proper security boundaries for tool execution

- **Use Case**: Interactive applications requiring bidirectional communication
- **Characteristics**: Full-duplex communication channel
- **Advantages**: Low-latency, bidirectional, real-time updates
- **Limitations**: More complex to implement, may be blocked by some firewalls

## Code Examples: Key Components

### .NET Example: Creating a Simple MCP Server with Tools

```csharp
using Microsoft.Mcp.Server;
using Microsoft.Mcp.Tools;

public class WeatherServer : IMcpServer
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Register our custom weather tool
        services.AddMcpTool<WeatherTool>("weatherTool");
    }
    
    public void Configure(IMcpApplicationBuilder app)
    {
        // Configure middleware
        app.UseAuthentication();
        app.UseMcpServer();
    }
}

// Custom tool implementation
public class WeatherTool : IMcpTool
{
    public string Name => "weatherTool";
    public string Description => "Gets current weather for a location";
    
    public async Task<ToolResponse> ExecuteAsync(ToolRequest request)
    {
        // Extract location parameter
        var location = request.Parameters.GetValue<string>("location");
        
        // Call weather API (simplified)
        var weatherData = await GetWeatherDataAsync(location);
        
        // Return formatted response
        return new ToolResponse 
        {
            Result = new { 
                Temperature = weatherData.Temperature,
                Conditions = weatherData.Conditions,
                Location = weatherData.Location
            }
        };
    }
}
```

### Java Example: MCP Server Components

```java
import com.mcp.server.McpServer;
import com.mcp.tools.Tool;
import com.mcp.tools.ToolRequest;
import com.mcp.tools.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) {
        // Create an MCP server
        McpServer server = new McpServer.Builder()
            .setPort(3000)
            .build();
            
        // Register a weather tool
        server.registerTool(new WeatherTool());
        
        // Start the server
        server.start();
        System.out.println("MCP Server started on port 3000");
    }
}

// Custom weather tool implementation
class WeatherTool implements Tool {
    @Override
    public String getName() {
        return "weatherTool";
    }
    
    @Override
    public String getDescription() {
        return "Gets current weather for a location";
    }
    
    @Override
    public ToolResponse execute(ToolRequest request) {
        // Extract location from parameters
        String location = request.getParameters().get("location").asText();
        
        // Get weather data (simplified)
        WeatherData data = getWeatherData(location);
        
        // Create and return response
        Map<String, Object> result = new HashMap<>();
        result.put("temperature", data.getTemperature());
        result.put("conditions", data.getConditions());
        result.put("location", data.getLocation());
        
        return new ToolResponse.Builder()
            .setResult(result)
            .build();
    }
    
    private WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    // Constructor and getters
    // ...
}
```

### Python Example: Building an MCP Server

```python
from mcp_server import McpServer
from mcp_tools import Tool, ToolRequest, ToolResponse
import requests

class WeatherTool(Tool):
    def get_name(self):
        return "weatherTool"
        
    def get_description(self):
        return "Gets current weather for a location"
    
    def execute(self, request: ToolRequest) -> ToolResponse:
        # Get location from parameters
        location = request.parameters.get("location")
        
        # Fetch weather data (simplified)
        weather_data = self._get_weather_data(location)
        
        # Return formatted response
        return ToolResponse(
            result={
                "temperature": weather_data["temperature"],
                "conditions": weather_data["conditions"],
                "location": weather_data["location"]
            }
        )
    
    def _get_weather_data(self, location):
        # This would normally call a weather API
        # Simplified for demonstration
        return {
            "temperature": 72.5,
            "conditions": "Sunny",
            "location": location
        }

# Create and start the server
if __name__ == "__main__":
    # Initialize server
    server = McpServer(port=3000)
    
    # Register tools
    server.register_tool(WeatherTool())
    
    # Start server
    server.start()
    print("MCP Server running on port 3000")
```

### JavaScript Example: Creating an MCP Client

```javascript
// Using Node.js with the MCP client library
const { McpClient } = require('@mcp/client');

async function runMcpExample() {
  // Initialize the MCP client
  const client = new McpClient({
    serverUrl: 'https://mcp-server-example.com',
    apiKey: process.env.MCP_API_KEY // Use environment variable for security
  });
  
  // Create a request with a prompt
  const prompt = "What's the current weather in London?";
  
  try {
    // Send the request to the MCP server
    const response = await client.sendPrompt(prompt, {
      allowedTools: ['weatherTool'], // Specify which tools the model can use
      temperature: 0.7,
      maxTokens: 300
    });
    
    // Process the response
    console.log('Model response:', response.generatedText);
    
    // Check if any tools were used
    if (response.toolCalls && response.toolCalls.length > 0) {
      console.log('\nTools used:');
      response.toolCalls.forEach(toolCall => {
        console.log(`- ${toolCall.name} with parameters:`, toolCall.parameters);
        console.log(`  Result:`, toolCall.result);
      });
    }
  } catch (error) {
    console.error('Error communicating with MCP server:', error);
  }
}

runMcpExample();
```

This JavaScript example demonstrates how to create an MCP client that connects to a server, sends a prompt, and processes the response including any tool calls that were made.

## Security and Authorization

MCP includes built-in concepts for managing security:

1. **Tool Permission Control**: Clients can specify which tools a model is allowed to use
2. **Authentication**: Servers can require authentication for tool access
3. **Validation**: Parameter validation ensures proper tool usage
4. **Rate Limiting**: Prevents abuse of tool resources

## Protocol Messages

MCP communication uses structured JSON messages:

1. **Client Request**: Contains prompt, conversation history, and tool configurations
2. **Model Response**: Contains generated text and/or tool calls
3. **Tool Request**: Contains tool name and parameters
4. **Tool Response**: Contains tool execution results

## Key Takeaways

- MCP uses a client-server architecture to connect models with external capabilities
- The ecosystem consists of clients, hosts, servers, tools, and data sources
- Communication can happen through STDIO, SSE, or WebSockets
- Tools are the fundamental units of functionality exposed to models
- Structured communication protocols ensure consistent interactions

## Exercise

Design a simple MCP tool that would be useful in your domain. Define:
1. What the tool would be named
2. What parameters it would accept
3. What output it would return
4. How a model might use this tool to solve user problems


---

Next: [Getting Started](../02-GettingStarted/README.md)