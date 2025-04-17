# Getting Started with MCP

## Overview

This lesson provides practical guidance on setting up MCP environments and building your first MCP applications. You'll learn how to set up the necessary tools and frameworks, build basic MCP servers, create host applications, and test your implementations.

The Model Context Protocol (MCP) is an open protocol that standardizes how applications provide context to LLMs. Think of MCP like a USB-C port for AI applications - it provides a standardized way to connect AI models to different data sources and tools.

## Learning Objectives

By the end of this lesson, you will be able to:
- Set up development environments for MCP in C#, Java, Python, TypeScript, and JavaScript
- Build and deploy basic MCP servers with custom features (resources, prompts, and tools)
- Create host applications that connect to MCP servers
- Test and debug MCP implementations
- Understand common setup challenges and their solutions
- Connect your MCP implementations to popular LLM services

## Setting Up Your MCP Environment

### Prerequisites

Before diving into MCP development, ensure you have:

1. **Development Environment**: For your chosen language (C#, Java, Python, TypeScript, or JavaScript)
2. **IDE/Editor**: Visual Studio, VS Code, IntelliJ, Eclipse, PyCharm, or any modern code editor
3. **Package Managers**: NuGet, Maven/Gradle, pip, or npm/yarn
4. **API Keys**: For any AI services you plan to use in your host applications

## To set up an MCP Client and MCP Server in Visual Studio Code, follow these steps:

1. **Install Required Dependencies**:
   - Ensure you have Python (version 3.12.9 or later) and Node.js (version 22.14.0 or later) installed on your machine.
   - Install MCP server packages using npm:
     ```bash
     npm install -g @modelcontextprotocol/server-filesystem
     npm install -g @modelcontextprotocol/server-postgres
     ```

2 **Configure MCP Servers**:
   - Open your workspace in VS Code.
   - Create a `.vscode/mcp.json` file in your workspace folder to configure MCP servers. Example configuration:
     ```json
     {
       "servers": {
         "mcp-server-time": {
           "command": "python",
           "args": ["-m", "mcp_server_time", "--local-timezone=Europe/London"],
           "env": {}
         }
       }
     }
     ```

4. **Enable MCP Discovery**:
   - Go to `File -> Preferences -> Settings` in VS Code.
   - Search for "MCP" and enable `chat.mcp.discovery.enabled` in the settings.json file.

5. **Start MCP Server**:
   - Run the MCP server locally using the configured command.
   - Test the server by sending requests through the Copilot Agent Mode in VS Code.

6. **Use MCP Client**:
   - Open the Copilot Chat window in VS Code.
   - Switch to Agent Mode and interact with the MCP server tools.


### Official SDKs

MCP provides official SDKs for multiple languages:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Maintained in collaboration with Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Maintained in collaboration with Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - The official TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - The official Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - The official Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Maintained in collaboration with Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - The official Rust implementation

### Installation and Setup

### VS Code GitHub Copilot

<table>
<table>
<tr>
  <th align="left">GitHub</th>
  <td><a href="https://github.com/microsoft/vscode">https://github.com/microsoft/vscode</a></td>
</tr>
<tr>
  <th align="left">Website</th>
  <td><a href="https://code.visualstudio.com/">https://code.visualstudio.com/</a></td>
</tr>
</table>
<table>
<tr><th align="left">License</th><td>MIT</td></tr>
<tr><th align="left">Type</th><td>Desktop app, Web app</td></tr>
<tr><th align="left">Platforms</th><td>Windows, MacOS, Linux, Web</td></tr>
<tr><th align="left">Pricing</th><td>Freemium (GitHub Copilot subscription)</td></tr>
<tr><th align="left">Programming Languages</th><td>TypeScript</td></tr>
</table>

VS Code integrates MCP with GitHub Copilot through [agent mode](https://code.visualstudio.com/docs/copilot/chat/chat-agent-mode), allowing direct interaction with MCP-provided tools within your agentic coding workflow. Configure servers in Claude Desktop, workspace or user settings, with guided MCP installation and secure handling of keys in input variables to avoid leaking hard-coded keys.

**Key Features:**
- Support for stdio and server-sent events (SSE) transport
- Per-session selection of tools per agent session for optimal performance
- Easy server debugging with restart commands and output logging
- Tool calls with editable inputs and always-allow toggle
- Integration with existing VS Code extension system to register MCP servers from extensions

#### Command-line configuration
You can also use the VS Code command-line interface to add an MCP server to your user profile or to a workspace.

To add an MCP server to your user profile, use the --add-mcp command line option, and provide the JSON server configuration in the form {\"name\":\"server-name\",\"command\":...}.

```
code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
```
<details>
<summary>Screenshots</summary>

![Guided MCP server configuration in VS Code](../images/02-GettingStarted/chat-mode-agent.png)
![Tool selection per agent session](../images/02-GettingStarted/agent-mode-select-tools.png)
![Easily debug errors during MCP development](../images/02-GettingStarted/mcp-list-servers.png)
</details>

#### TypeScript/JavaScript

```bash
# For server development
npm install @modelcontextprotocol/typescript-server-sdk

# For client development
npm install @modelcontextprotocol/typescript-client-sdk
```

#### Python

```bash
# For server development
pip install mcp-server-sdk

# For client development
pip install mcp-client-sdk
```

#### C#

```bash
# Using NuGet Package Manager
Install-Package ModelContextProtocol.SDK

# Using .NET CLI
dotnet add package ModelContextProtocol.SDK
```

#### Java

```bash
# Using Maven
<dependency>
    <groupId>io.modelcontextprotocol</groupId>
    <artifactId>mcp-sdk</artifactId>
    <version>latest</version>
</dependency>

# Using Gradle
implementation 'io.modelcontextprotocol:mcp-sdk:latest'
```

### Basic MCP Server Structure

An MCP server typically includes:

1. **Server Configuration**: Setup port, authentication, and other settings
2. **Resources**: Data and context made available to LLMs
3. **Tools**: Functionality that models can invoke
4. **Prompts**: Templates for generating or structuring text

Here's a simplified example in TypeScript:

```typescript
import { Server, Tool, Resource } from "@modelcontextprotocol/typescript-server-sdk";

// Create a new MCP server
const server = new Server({
  port: 3000,
  name: "Example MCP Server",
  version: "1.0.0"
});

// Register a tool
server.registerTool({
  name: "calculator",
  description: "Performs basic calculations",
  parameters: {
    expression: {
      type: "string",
      description: "The math expression to evaluate"
    }
  },
  handler: async (params) => {
    const result = eval(params.expression);
    return { result };
  }
});

// Start the server
server.start();
```

## Testing and Debugging

### Testing MCP Servers

MCP provides tools to help you test and debug your servers:

#### Using MCP Inspector

The [MCP Inspector](https://github.com/modelcontextprotocol/inspector) is a visual testing tool that helps you:

1. **Discover Server Capabilities**: Automatically detect available resources, tools, and prompts
2. **Test Tool Execution**: Try different parameters and see responses in real-time
3. **View Server Metadata**: Examine server info, schemas, and configurations

```bash
# Installing MCP Inspector
npm install -g @modelcontextprotocol/inspector

# Running the Inspector
mcp-inspector
```

#### Manual Testing

You can test MCP servers directly using HTTP requests:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

#### Unit Testing

Create unit tests for your tools and resources to ensure they work as expected:

```javascript
// Example using Jest
test('Calculator tool returns correct result', async () => {
  const response = await calculatorTool.handler({ expression: '5+5' });
  expect(response.result).toBe(10);
});
```

### Common Setup Issues and Solutions

| Issue | Possible Solution |
|-------|-------------------|
| Connection refused | Check if server is running and port is correct |
| Tool execution errors | Review parameter validation and error handling |
| Authentication failures | Verify API keys and permissions |
| Schema validation errors | Ensure parameters match the defined schema |
| Server not starting | Check for port conflicts or missing dependencies |
| CORS errors | Configure proper CORS headers for cross-origin requests |
| Authentication issues | Verify token validity and permissions |

## Deploying MCP Servers

### Local Development

For local development and testing, you can run MCP servers directly on your machine:

1. **Start the server process**: Run your MCP server application 
2. **Configure networking**: Ensure the server is accessible on the expected port 
3. **Connect clients**: Use local connection URLs like `http://localhost:3000`

```bash
# Example: Running a TypeScript MCP server locally
npm run start
# Server running at http://localhost:3000
```

### Container Deployment

For production deployments, containerization offers several advantages:

1. **Create a Dockerfile**:

```dockerfile
FROM node:18
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
EXPOSE 3000
CMD ["npm", "start"]
```

2. **Build and run the container**:

```bash
# Build the container
docker build -t my-mcp-server .

# Run the container
docker run -p 3000:3000 my-mcp-server
```

### Cloud Deployment

MCP servers can be deployed to various cloud platforms:

1. **Serverless Functions**: Deploy lightweight MCP servers as serverless functions
2. **Container Services**: Use services like Azure Container Apps, AWS ECS, or Google Cloud Run
3. **Kubernetes**: Deploy and manage MCP servers in Kubernetes clusters for high availability

```bash
# Example: Deploying to Azure Container Apps
az containerapp create \
  --name my-mcp-server \
  --resource-group my-resources \
  --image my-registry/my-mcp-server:latest \
  --target-port 3000 \
  --ingress external
```


## Key Takeaways

- Setting up an MCP development environment is straightforward with language-specific SDKs
- Building MCP servers involves creating and registering tools with clear schemas
- MCP clients connect to servers and models to leverage extended capabilities
- Testing and debugging are essential for reliable MCP implementations
- Deployment options range from local development to cloud-based solutions

## Samples 

[Java Calculator](./samples/java/calculator/)
[.Net Calculator](./samples/csharp/)
[JavaScript Calculator](./samples/javascript/)
[TypeScript Calculator](./samples/typescript/)
[Python Calculator](./samples/python/)

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