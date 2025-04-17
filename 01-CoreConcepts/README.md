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
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### Java Example: MCP Server Components

```java
import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Weather MCP Server")
            .version("1.0.0")
            .build();
            
        // Register a weather tool
        server.registerTool(McpToolDefinition.builder("weatherTool")
            .description("Gets current weather for a location")
            .parameter("location", String.class)
            .execute((ToolExecutionContext ctx) -> {
                String location = ctx.getParameter("location", String.class);
                
                // Get weather data (simplified)
                WeatherData data = getWeatherData(location);
                
                // Return formatted response
                return ToolResponse.content(
                    String.format("Temperature: %.1f°F, Conditions: %s, Location: %s", 
                    data.getTemperature(), 
                    data.getConditions(), 
                    data.getLocation())
                );
            })
            .build());
        
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Weather MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
    
    private static WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    public WeatherData(double temperature, String conditions, String location) {
        this.temperature = temperature;
        this.conditions = conditions;
        this.location = location;
    }
    
    public double getTemperature() {
        return temperature;
    }
    
    public String getConditions() {
        return conditions;
    }
    
    public String getLocation() {
        return location;
    }
}
```

### Python Example: Building an MCP Server

```python
#!/usr/bin/env python3
import asyncio
from mcp.server.fastmcp import FastMCP
from mcp.server.transports.stdio import serve_stdio

# Create a FastMCP server
mcp = FastMCP(
    name="Weather MCP Server",
    version="1.0.0"
)

@mcp.tool()
def get_weather(location: str) -> dict:
    """Gets current weather for a location."""
    # This would normally call a weather API
    # Simplified for demonstration
    return {
        "temperature": 72.5,
        "conditions": "Sunny",
        "location": location
    }

# Alternative approach using a class
class WeatherTools:
    @mcp.tool()
    def forecast(self, location: str, days: int = 1) -> dict:
        """Gets weather forecast for a location for the specified number of days."""
        # This would normally call a weather API forecast endpoint
        # Simplified for demonstration
        return {
            "location": location,
            "forecast": [
                {"day": i+1, "temperature": 70 + i, "conditions": "Partly Cloudy"}
                for i in range(days)
            ]
        }

# Initialize class for its methods to be registered as tools
weather_tools = WeatherTools()

if __name__ == "__main__":
    # Start the server with stdio transport
    print("Weather MCP Server starting...")
    asyncio.run(serve_stdio(mcp))
```

### JavaScript Example: Creating an MCP Server

```javascript
// Using the official Model Context Protocol SDK
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod"; // For parameter validation

// Create an MCP server
const server = new McpServer({
  name: "Weather MCP Server",
  version: "1.0.0"
});

// Define a weather tool
server.tool(
  "weatherTool",
  {
    location: z.string().describe("The location to get weather for")
  },
  async ({ location }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const weatherData = await getWeatherData(location);
    
    return {
      content: [
        { 
          type: "text", 
          text: `Temperature: ${weatherData.temperature}°F, Conditions: ${weatherData.conditions}, Location: ${weatherData.location}` 
        }
      ]
    };
  }
);

// Define a forecast tool
server.tool(
  "forecastTool",
  {
    location: z.string(),
    days: z.number().default(3).describe("Number of days for forecast")
  },
  async ({ location, days }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const forecast = await getForecastData(location, days);
    
    return {
      content: [
        { 
          type: "text", 
          text: `${days}-day forecast for ${location}: ${JSON.stringify(forecast)}` 
        }
      ]
    };
  }
);

// Helper functions
async function getWeatherData(location) {
  // Simulate API call
  return {
    temperature: 72.5,
    conditions: "Sunny",
    location: location
  };
}

async function getForecastData(location, days) {
  // Simulate API call
  return Array.from({ length: days }, (_, i) => ({
    day: i + 1,
    temperature: 70 + Math.floor(Math.random() * 10),
    conditions: i % 2 === 0 ? "Sunny" : "Partly Cloudy"
  }));
}

// Connect the server using stdio transport
const transport = new StdioServerTransport();
server.connect(transport).catch(console.error);

console.log("Weather MCP Server started");
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
