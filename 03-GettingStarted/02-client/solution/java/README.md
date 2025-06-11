# MCP Java Client - Calculator Demo

This project demonstrates how to create a Java client that connects to and interacts with an MCP (Model Context Protocol) server. In this example, we'll connect to the calculator server from Chapter 01 and perform various mathematical operations.

## Prerequisites

Before running this client, you need to:

1. **Start the Calculator Server** from Chapter 01:
   - Navigate to the calculator server directory: `03-GettingStarted/01-first-server/solution/java/`
   - Build and run the calculator server:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - The server should be running on `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` is a Java application that demonstrates how to:
- Connect to an MCP server using Server-Sent Events (SSE) transport
- List available tools from the server
- Call various calculator functions remotely
- Handle responses and display results

## How It Works

The client uses the Spring AI MCP framework to:

1. **Establish Connection**: Creates a WebFlux SSE client transport to connect to the calculator server
2. **Initialize Client**: Sets up the MCP client and establishes the connection
3. **Discover Tools**: Lists all available calculator operations
4. **Execute Operations**: Calls various mathematical functions with sample data
5. **Display Results**: Shows the results of each calculation

## Project Structure

```
src/
└── test/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## Key Dependencies

The project uses the following key dependencies:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

This dependency provides:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE transport for web-based communication
- MCP protocol schemas and request/response types

## Building the Project

Build the project using the Maven wrapper:

```cmd
.\mvnw clean compile
```

## Running the Client

### Method 1: Using Maven

```cmd
.\mvnw test-compile exec:java -Dexec.mainClass="com.microsoft.mcp.sample.client.SDKClient" -Dexec.classpathScope="test"
```

### Method 2: Using Java directly

```cmd
.\mvnw test-compile
java -cp "target/test-classes;target/classes" com.microsoft.mcp.sample.client.SDKClient
```

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **List Tools** - Shows all available calculator operations
3. **Perform Calculations**:
   - Addition: 5 + 3 = 8
   - Subtraction: 10 - 4 = 6
   - Multiplication: 6 × 7 = 42
   - Division: 20 ÷ 4 = 5
   - Power: 2^8 = 256
   - Square Root: √16 = 4
   - Absolute Value: |-5.5| = 5.5
   - Help: Shows available operations

## Expected Output

```
Available Tools = ListToolsResult[tools=[...]]
Add Result = CallToolResult[content=[TextContent[text=8.0]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text=6.0]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text=42.0]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text=5.0]], isError=false]
Power Result = CallToolResult[content=[TextContent[text=256.0]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text=4.0]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text=5.5]], isError=false]
Help = CallToolResult[content=[TextContent[text=Available operations: add, subtract, multiply, divide, power, squareRoot, modulus, absolute]], isError=false]
```

## Understanding the Code

### 1. Transport Setup
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
This creates an SSE (Server-Sent Events) transport that connects to the calculator server.

### 2. Client Creation
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Creates a synchronous MCP client and initializes the connection.

### 3. Calling Tools
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Calls the "add" tool with parameters a=5.0 and b=3.0.

## Troubleshooting

### Server Not Running
If you get connection errors, make sure the calculator server from Chapter 01 is running:
```
Error: Connection refused
```
**Solution**: Start the calculator server first.

### Port Already in Use
If port 8080 is busy:
```
Error: Address already in use
```
**Solution**: Stop other applications using port 8080 or modify the server to use a different port.

### Build Errors
If you encounter build errors:
```cmd
.\mvnw clean install -DskipTests
```

## Next Steps

After running this client successfully, you can:

1. **Modify the calculations** - Change the input values to test different scenarios
2. **Add error handling** - Handle division by zero or invalid inputs
3. **Extend functionality** - Add more complex mathematical operations
4. **Create a GUI** - Build a graphical interface for the calculator
5. **Add logging** - Implement proper logging instead of console output

## Learn More

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)