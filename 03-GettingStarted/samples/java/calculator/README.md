# Basic Calculator MCP Service

This service provides basic calculator operations through the Model Context Protocol (MCP) using Spring Boot with WebFlux transport. It's designed as a simple example for beginners learning about MCP implementations.

For more information, see the [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) reference documentation.

## Overview

The service showcases:
- Support for SSE (Server-Sent Events)
- Automatic tool registration using Spring AI's `@Tool` annotation
- Basic calculator functions:
  - Addition, subtraction, multiplication, division
  - Power calculation and square root
  - Modulus (remainder) and absolute value
  - Help function for operation descriptions

## Features

This calculator service offers the following capabilities:

1. **Basic Arithmetic Operations**:
   - Addition of two numbers
   - Subtraction of one number from another
   - Multiplication of two numbers
   - Division of one number by another (with zero division check)

2. **Advanced Operations**:
   - Power calculation (raising a base to an exponent)
   - Square root calculation (with negative number check)
   - Modulus (remainder) calculation
   - Absolute value calculation

3. **Help System**:
   - Built-in help function explaining all available operations

## Using the Service

The service exposes the following API endpoints through the MCP protocol:

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- `power(base, exponent)`: Calculate the power of a number
- `squareRoot(number)`: Calculate the square root (with negative number check)
- `modulus(a, b)`: Calculate the remainder when dividing
- `absolute(number)`: Calculate the absolute value
- `help()`: Get information about available operations

## Test Client

A simple test client is included in the `com.microsoft.mcp.sample.client` package. The `SampleCalculatorClient` class demonstrates the available operations of the calculator service.

## Using the LangChain4j Client

The project also includes a LangChain4j example client in `com.microsoft.mcp.sample.client.LangChain4jApp` that demonstrates how to integrate the calculator service with LangChain4j and OpenAI models:

### Prerequisites

1. Set up your OpenAI API key as an environment variable:
   ```bash
   export OPENAI_API_KEY=your-api-key
   ```
   On Windows, use:
   ```
   set OPENAI_API_KEY=your-api-key
   ```

2. Ensure the calculator server is running on `localhost:8080`

### Running the LangChain4j Client

This example demonstrates:
- Connecting to the calculator MCP server via SSE transport
- Using LangChain4j to create a chat bot that can leverage calculator operations
- Integrating with OpenAI models (using o4-mini by default)

The client sends the following sample queries to demonstrate functionality:
1. Calculating the sum of two numbers
2. Finding the square root of a number
3. Getting help information about available calculator operations

Run the example and check the console output to see how the AI model uses the calculator tools to respond to queries.

```java
// Sample usage
ChatLanguageModel model = OpenAiChatModel.builder()
        .apiKey(System.getenv("OPENAI_API_KEY"))
        .modelName("o4-mini")
        .build();

McpTransport transport = new HttpMcpTransport.Builder()
        .sseUrl("http://localhost:8080/sse")
        .build();
        
McpClient mcpClient = new DefaultMcpClient.Builder()
        .transport(transport)
        .build();

// Create a tool provider using the MCP client
ToolProvider toolProvider = McpToolProvider.builder()
        .mcpClients(List.of(mcpClient))
        .build();

// Build an AI service with the model and tool provider
Bot bot = AiServices.builder(Bot.class)
        .chatLanguageModel(model)
        .toolProvider(toolProvider)
        .build();

// Chat with the bot using calculator operations
String response = bot.chat("Calculate the sum of 24.5 and 17.3");
System.out.println(response);
```

## Dependencies

The project requires the Spring AI MCP Server WebFlux Boot Starter:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

This starter provides:
- Reactive transport using Spring WebFlux (`WebFluxSseServerTransport`)
- Auto-configured reactive SSE endpoints
- Included `spring-boot-starter-webflux` and `mcp-spring-webflux` dependencies

## Building the Project

Build the project using Maven:
```bash
./mvnw clean install -DskipTests
```

## Running the Server

### Using Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Using Docker

The project includes a Dockerfile for containerized deployment:

1. **Build the Docker image**:
   ```bash
   docker build -t calculator-mcp-service .
   ```

2. **Run the Docker container**:
   ```bash
   docker run -p 8080:8080 calculator-mcp-service
   ```

This will:
- Build a multi-stage Docker image with Maven 3.9.9 and Eclipse Temurin 24 JDK
- Create an optimized container image
- Expose the service on port 8080
- Start the MCP calculator service inside the container

You can access the service at `http://localhost:8080` once the container is running.
