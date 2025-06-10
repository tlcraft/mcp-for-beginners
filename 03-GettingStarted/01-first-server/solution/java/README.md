# MCP Calculator Server - Your First Java MCP Server

Welcome to your first Model Context Protocol (MCP) server! This tutorial will guide you through creating and running a simple calculator server that can be called by MCP clients.

## What is MCP?

The Model Context Protocol (MCP) is a standard for connecting AI models with external tools and data sources. It allows AI assistants to:
- Call functions/tools in your applications
- Access data from various sources
- Perform actions on behalf of users

## What You'll Learn

In this tutorial, you'll:
1. ✅ Create a simple MCP server with calculator functions
2. ✅ Run the server locally
3. ✅ Connect to it using different MCP clients
4. ✅ Call calculator functions from the clients

## Project Structure

```
├── src/main/java/
│   └── com/microsoft/mcp/sample/server/
│       ├── McpServerApplication.java     # Main Spring Boot application
│       ├── service/
│       │   └── CalculatorService.java    # Calculator functions
│       ├── controller/
│       │   └── HealthController.java     # Health check endpoint
│       └── config/
│           └── StartupConfig.java        # Server configuration
├── src/test/java/
│   └── com/microsoft/mcp/sample/client/
│       ├── SDKClient.java                # Basic MCP SDK client
│       └── Bot.java                      # AI assistant client
├── pom.xml                               # Maven dependencies
└── README.md                             # This file
```

## Prerequisites

Before you start, make sure you have:
- ☑️ Java 17 or higher installed
- ☑️ Maven 3.6+ installed
- ☑️ An IDE like VS Code, IntelliJ IDEA, or Eclipse

## Step 1: Understanding the Calculator Service

The heart of our MCP server is the `CalculatorService` class. Let's look at what it provides:

```java
@Service
public class CalculatorService {
    
    @Tool(description = "Add two numbers together")
    public String add(double a, double b) {
        // Adds two numbers and returns formatted result
    }
    
    @Tool(description = "Subtract the second number from the first number")
    public String subtract(double a, double b) {
        // Subtracts b from a and returns formatted result
    }
    
    @Tool(description = "Multiply two numbers together")
    public String multiply(double a, double b) {
        // Multiplies two numbers and returns formatted result
    }
    
    @Tool(description = "Divide the first number by the second number")
    public String divide(double a, double b) {
        // Divides a by b (with zero-division protection)
    }
}
```

**Key Points:**
- The `@Tool` annotation exposes methods as MCP tools
- Each method has a clear description for AI clients
- Methods return formatted strings showing the calculation

## Step 2: Running the Server

### Option A: Using Maven Wrapper (Recommended)

```cmd
# Build and run the server
mvnw.cmd spring-boot:run
```

### Option B: Using Maven

```cmd
# Build the project
mvn clean compile

# Run the server
mvn spring-boot:run
```

### Option C: Using JAR

```cmd
# Build the JAR file
mvn clean package

# Run the JAR
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

**Expected Output:**
```
  ____      _            _       _             
 / ___|__ _| | ___ _   _| | __ _| |_ ___  _ __ 
| |   / _` | |/ __| | | | |/ _` | __/ _ \| '__|
| |__| (_| | | (__| |_| | | (_| | || (_) | |   
 \____\__,_|_|\___|\__,_|_|\__,_|\__\___/|_|   

2024-XX-XX 10:30:45.123  INFO 12345 --- [main] c.m.m.s.s.McpServerApplication: Started McpServerApplication in 2.345 seconds
```

Your server is now running on `http://localhost:8080`!

## Step 3: Testing the Server

### Health Check
First, verify the server is running:
```cmd
curl http://localhost:8080/actuator/health
```

Expected response:
```json
{"status":"UP"}
```

### MCP Endpoints
The server exposes MCP endpoints at:
- `http://localhost:8080/mcp/v1/tools` - List available tools
- `http://localhost:8080/mcp/v1/tools/call` - Call tools

## Step 4: Using the MCP Client

### Basic SDK Client

Run the basic MCP client to test your server:

```cmd
# Compile and run the SDK client
mvn test-compile exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient"
```

**What this client does:**
1. Connects to your MCP server
2. Lists available tools (add, subtract, multiply, divide)
3. Calls the `add` function with example numbers
4. Displays the result

**Expected Output:**
```
Available tools: [add, subtract, multiply, divide]
Calling add(5.0, 3.0)...
Result: 5.0 + 3.0 = 8.0
```

## Step 5: Understanding the Code

### Server Side (`McpServerApplication.java`)
```java
@SpringBootApplication
public class McpServerApplication {
    
    @Bean
    public ToolCallbackProvider calculatorTools(CalculatorService calculator) {
        return MethodToolCallbackProvider.builder()
            .toolObjects(calculator)
            .build();
    }
}
```

This configuration:
- Creates a Spring Boot application
- Registers the `CalculatorService` as an MCP tool provider
- Automatically exposes `@Tool` annotated methods

### Client Side (`SDKClient.java`)
```java
var transport = new WebFluxSseClientTransport(
    WebClient.builder().baseUrl("http://localhost:8080")
);
var client = McpClient.sync(transport).build();
client.initialize();

// List tools
ListToolsResult tools = client.listTools();

// Call a tool
CallToolResult result = client.callTool(
    new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0))
);
```

This client:
- Connects to the MCP server via HTTP
- Discovers available tools
- Calls tools with parameters

## Common Issues & Solutions

### ❌ "Port 8080 already in use"
**Solution:** Stop other applications using port 8080, or change the port:
```cmd
mvn spring-boot:run -Dspring-boot.run.arguments="--server.port=8081"
```

### ❌ "Java version not supported"
**Solution:** Ensure you're using Java 17+:
```cmd
java -version
```

### ❌ "Connection refused"
**Solution:** Make sure the server is running before starting the client.

## Next Steps

Now that you have a working MCP server, try:

1. **Add new calculator functions:**
   - Square root
   - Power operations
   - Trigonometric functions

2. **Create more complex tools:**
   - File operations
   - Database queries
   - API integrations

3. **Build different clients:**
   - Web applications
   - Desktop apps
   - AI chatbots

## Key Concepts Learned

✅ **MCP Server:** A service that exposes tools/functions to AI clients  
✅ **Tools:** Functions annotated with `@Tool` that can be called remotely  
✅ **Transport:** The communication layer (HTTP/SSE in this example)  
✅ **Client:** Applications that discover and call MCP tools  

## Resources

- [Model Context Protocol Specification](https://spec.modelcontextprotocol.io/)
- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/mcp.html)
- [MCP Java SDK](https://github.com/modelcontextprotocol/java-sdk)

---

🎉 **Congratulations!** You've successfully created and tested your first MCP server. You're now ready to build more complex MCP applications!