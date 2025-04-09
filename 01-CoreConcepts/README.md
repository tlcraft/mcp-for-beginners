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

The MCP architecture follows a client-server model designed to facilitate seamless interaction between AI models and external systems. Let's break down this architecture into its core components.

### 1. MCP Clients

**MCP Clients** are applications or services that initiate interactions with AI models. They:

- Send requests to MCP Hosts with prompts/instructions
- Specify which tools and capabilities should be available
- Receive and process model responses
- Manage the conversation flow and user interface

Examples of MCP Clients include chat applications, productivity tools, and enterprise software that leverages AI capabilities.

### 2. MCP Hosts

**MCP Hosts** are environments that run AI models. They:

- Execute the AI model to generate responses
- Manage communication between clients and servers
- Route tool calls from the model to appropriate servers
- Handle permission and security constraints
- Return model outputs to the client

MCP Hosts can be cloud-based services (like Azure OpenAI Service or AI Foundry) or self-hosted environments running local models.

### 3. MCP Servers

**MCP Servers** provide tools and data sources that extend the model's capabilities. They:

- Register available tools with the host
- Receive and execute tool calls from the model
- Return tool outputs back to the model via the host
- Manage authentication and authorization for tools
- Handle data access and transformation

MCP Servers can be developed by anyone to extend model capabilities with specialized functionality.

### 4. Tools

**Tools** are individual functions or capabilities exposed by MCP Servers. Each tool:

- Has a unique name and description
- Accepts specific parameters
- Returns structured outputs
- Performs a discrete function (e.g., web search, calculation, database query)

Tools are the fundamental units of functionality that models can access through MCP.

### 5. Data Sources

**Data Sources** are repositories of information that tools can access:

- Local files and databases
- Knowledge bases and document repositories
- APIs and web services
- Real-time data streams

## Information Flow in MCP

1. **Client Initiates Request**: The client sends a prompt/instruction to the host
2. **Host Processes with Model**: The AI model generates a response or tool call
3. **Tool Execution**: If the model calls a tool, the request goes to the appropriate server
4. **Server Processes Tool Call**: The server executes the tool and returns results
5. **Model Incorporates Tool Results**: The model uses tool outputs to generate its final response
6. **Response Returned to Client**: The client receives the model's response

## Communication Mechanisms

MCP supports multiple communication protocols to accommodate different use cases:

### 1. Standard Input/Output (STDIO)

- **Use Case**: Local development and simple integrations
- **Characteristics**: Text-based, synchronous communication
- **Advantages**: Simple to implement, no network dependencies
- **Limitations**: Limited to same-machine communication

### 2. Server-Sent Events (SSE)

- **Use Case**: Web applications requiring streaming responses
- **Characteristics**: HTTP-based, one-way real-time streaming from server to client
- **Advantages**: Works through firewalls, supports streaming tokens
- **Limitations**: One-way communication only

### 3. WebSockets

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