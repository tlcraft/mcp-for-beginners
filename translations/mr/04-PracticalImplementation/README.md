<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:08:32+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "mr"
}
-->
# Practical Implementation

Practical implementation is where the power of the Model Context Protocol (MCP) becomes real. While understanding the theory and architecture behind MCP is important, the true value appears when you use these concepts to build, test, and deploy solutions that address real-world challenges. This chapter connects the dots between theoretical knowledge and hands-on development, guiding you through the process of bringing MCP-based applications to life.

Whether you are creating intelligent assistants, integrating AI into business workflows, or building custom data processing tools, MCP offers a flexible foundation. Its language-neutral design and official SDKs for popular programming languages make it accessible to many developers. By using these SDKs, you can quickly prototype, iterate, and scale your solutions across various platforms and environments.

In the following sections, you’ll find practical examples, sample code, and deployment strategies that show how to implement MCP in C#, Java, TypeScript, JavaScript, and Python. You’ll also learn how to debug and test your MCP servers, manage APIs, and deploy solutions to the cloud with Azure. These hands-on resources are designed to speed up your learning and help you confidently build robust, production-ready MCP applications.

## Overview

This lesson focuses on practical aspects of implementing MCP across multiple programming languages. We’ll explore how to use MCP SDKs in C#, Java, TypeScript, JavaScript, and Python to build solid applications, debug and test MCP servers, and create reusable resources, prompts, and tools.

## Learning Objectives

By the end of this lesson, you will be able to:
- Implement MCP solutions using official SDKs in different programming languages
- Debug and test MCP servers methodically
- Create and use server features (Resources, Prompts, and Tools)
- Design effective MCP workflows for complex tasks
- Optimize MCP implementations for performance and reliability

## Official SDK Resources

The Model Context Protocol provides official SDKs for several languages:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

This section offers practical examples of implementing MCP across multiple programming languages. You can find sample code in the `samples` directory, organized by language.

### Available Samples

The repository includes sample implementations in these languages:

- C#
- Java
- TypeScript
- JavaScript
- Python

Each sample demonstrates key MCP concepts and implementation patterns specific to that language and ecosystem.

## Core Server Features

MCP servers can implement any combination of these features:

### Resources  
Resources provide context and data for the user or AI model to use:  
- Document repositories  
- Knowledge bases  
- Structured data sources  
- File systems  

### Prompts  
Prompts are templated messages and workflows for users:  
- Pre-defined conversation templates  
- Guided interaction patterns  
- Specialized dialogue structures  

### Tools  
Tools are functions the AI model can execute:  
- Data processing utilities  
- External API integrations  
- Computational capabilities  
- Search functionality  

## Sample Implementations: C#

The official C# SDK repository contains several sample implementations demonstrating different aspects of MCP:

- **Basic MCP Client**: Simple example showing how to create an MCP client and call tools  
- **Basic MCP Server**: Minimal server implementation with basic tool registration  
- **Advanced MCP Server**: Full-featured server with tool registration, authentication, and error handling  
- **ASP.NET Integration**: Examples showing integration with ASP.NET Core  
- **Tool Implementation Patterns**: Various patterns for implementing tools with different complexity levels  

The MCP C# SDK is in preview and APIs may change. We will keep updating this blog as the SDK evolves.

### Key Features  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Building your [first MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

For complete C# implementation samples, visit the [official C# SDK samples repository](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample implementation: Java Implementation

The Java SDK offers strong MCP implementation options with enterprise-grade features.

### Key Features

- Spring Framework integration  
- Strong type safety  
- Reactive programming support  
- Comprehensive error handling  

For a complete Java implementation sample, see [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) in the samples directory.

## Sample implementation: JavaScript Implementation

The JavaScript SDK provides a lightweight and flexible approach to MCP implementation.

### Key Features

- Node.js and browser support  
- Promise-based API  
- Easy integration with Express and other frameworks  
- WebSocket support for streaming  

For a complete JavaScript implementation sample, see [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) in the samples directory.

## Sample implementation: Python Implementation

The Python SDK offers a Pythonic approach to MCP implementation with excellent ML framework integrations.

### Key Features

- Async/await support with asyncio  
- Flask and FastAPI integration  
- Simple tool registration  
- Native integration with popular ML libraries  

For a complete Python implementation sample, see [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) in the samples directory.

## API management 

Azure API Management is a great solution for securing MCP Servers. The idea is to place an Azure API Management instance in front of your MCP Server and let it handle features you’ll likely need such as:

- rate limiting  
- token management  
- monitoring  
- load balancing  
- security  

### Azure Sample

Here’s an Azure Sample doing exactly that, i.e. [creating an MCP Server and securing it with Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

See how the authorization flow works in the image below:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

In the image above, the following happens:

- Authentication/Authorization occurs using Microsoft Entra.  
- Azure API Management acts as a gateway and uses policies to route and manage traffic.  
- Azure Monitor logs all requests for further analysis.  

#### Authorization flow

Let’s take a closer look at the authorization flow:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

Learn more about the [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Deploy Remote MCP Server to Azure

Let’s see how to deploy the sample we mentioned earlier:

1. Clone the repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Register `Microsoft.App`` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` and check after some time if the registration is complete.

3. Run this [azd](https://aka.ms/azd) command to provision the API management service, function app (with code), and all other required Azure resources

    ```shell
    azd up
    ```

    This command will deploy all the cloud resources on Azure.

### Testing your server with MCP Inspector

1. In a **new terminal window**, install and run MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    You should see an interface like this:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.mr.png) 

2. CTRL-click to load the MCP Inspector web app from the URL displayed by the app (e.g. http://127.0.0.1:6274/#resources)  
3. Set the transport type to `SSE``
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` and **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. Click on a tool and **Run Tool**.  

If everything went well, you should now be connected to the MCP server and able to call a tool.

## MCP servers for Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): This set of repositories provides quickstart templates for building and deploying custom remote MCP (Model Context Protocol) servers using Azure Functions with Python, C# .NET, or Node/TypeScript.

The samples offer a complete solution allowing developers to:

- Build and run locally: Develop and debug an MCP server on your local machine  
- Deploy to Azure: Easily deploy to the cloud with a simple azd up command  
- Connect from clients: Connect to the MCP server from various clients, including VS Code’s Copilot agent mode and the MCP Inspector tool  

### Key Features:

- Security by design: The MCP server is secured using keys and HTTPS  
- Authentication options: Supports OAuth with built-in auth and/or API Management  
- Network isolation: Enables network isolation using Azure Virtual Networks (VNET)  
- Serverless architecture: Uses Azure Functions for scalable, event-driven execution  
- Local development: Full support for local development and debugging  
- Simple deployment: Streamlined deployment process to Azure  

The repository includes all necessary configuration files, source code, and infrastructure definitions to get started quickly with a production-ready MCP server implementation.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Sample MCP implementation using Azure Functions with Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Sample MCP implementation using Azure Functions with C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Sample MCP implementation using Azure Functions with Node/TypeScript.

## Key Takeaways

- MCP SDKs provide language-specific tools for building robust MCP solutions  
- Debugging and testing are critical for reliable MCP applications  
- Reusable prompt templates ensure consistent AI interactions  
- Well-designed workflows can coordinate complex tasks using multiple tools  
- Implementing MCP solutions requires attention to security, performance, and error handling  

## Exercise

Design a practical MCP workflow that solves a real-world problem in your field:

1. Identify 3-4 tools that would help solve this problem  
2. Create a workflow diagram showing how these tools interact  
3. Implement a basic version of one tool using your preferred language  
4. Create a prompt template to help the model effectively use your tool  

## Additional Resources


---

Next: [Advanced Topics](../05-AdvancedTopics/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात घ्या की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेचा अभाव असू शकतो. मूळ दस्तऐवज त्याच्या मूळ भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी भाषांतर शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुतींसाठी किंवा चुकीच्या अर्थसाधनेसाठी आम्ही जबाबदार नाही.