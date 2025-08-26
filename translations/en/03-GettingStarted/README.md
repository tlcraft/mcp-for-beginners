<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1197b6dbde36773e04a5ae826557fdb9",
  "translation_date": "2025-08-26T16:59:55+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "en"
}
-->
## Getting Started  

[![Build Your First MCP Server](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.en.png)](https://youtu.be/sNDZO9N4m9Y)

_(Click the image above to watch the video for this lesson)_

This section includes several lessons:

- **1 Your first server**: In this first lesson, you’ll learn how to create your first server and use the inspector tool to test and debug it. [Go to the lesson](01-first-server/README.md)

- **2 Client**: In this lesson, you’ll learn how to write a client that connects to your server. [Go to the lesson](02-client/README.md)

- **3 Client with LLM**: A more advanced way to write a client is by integrating an LLM, enabling it to "negotiate" with your server. [Go to the lesson](03-llm-client/README.md)

- **4 Consuming a server in GitHub Copilot Agent mode with Visual Studio Code**: Learn how to run your MCP Server directly within Visual Studio Code. [Go to the lesson](04-vscode/README.md)

- **5 stdio Transport Server**: The stdio transport is the recommended standard for MCP server-to-client communication, offering secure subprocess-based communication. [Go to the lesson](05-stdio-server/README.md)

- **6 HTTP Streaming with MCP (Streamable HTTP)**: Discover modern HTTP streaming, progress notifications, and how to build scalable, real-time MCP servers and clients using Streamable HTTP. [Go to the lesson](06-http-streaming/README.md)

- **7 Utilizing the AI Toolkit for VSCode**: Learn how to use the AI Toolkit to test and consume your MCP Clients and Servers. [Go to the lesson](07-aitk/README.md)

- **8 Testing**: This lesson focuses on various ways to test your server and client. [Go to the lesson](08-testing/README.md)

- **9 Deployment**: Explore different methods for deploying your MCP solutions. [Go to the lesson](09-deployment/README.md)

The Model Context Protocol (MCP) is an open protocol that standardizes how applications provide context to LLMs. Think of MCP as the "USB-C port" for AI applications—it offers a standardized way to connect AI models to various data sources and tools.

## Learning Objectives

By the end of this lesson, you will be able to:

- Set up development environments for MCP in C#, Java, Python, TypeScript, and JavaScript
- Build and deploy basic MCP servers with custom features (resources, prompts, and tools)
- Create host applications that connect to MCP servers
- Test and debug MCP implementations
- Address common setup challenges and their solutions
- Connect your MCP implementations to popular LLM services

## Setting Up Your MCP Environment

Before starting with MCP, it’s important to prepare your development environment and understand the basic workflow. This section will guide you through the initial setup to ensure a smooth start.

### Prerequisites

Before diving into MCP development, make sure you have:

- **Development Environment**: For your chosen language (C#, Java, Python, TypeScript, or JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, or any modern code editor
- **Package Managers**: NuGet, Maven/Gradle, pip, or npm/yarn
- **API Keys**: For any AI services you plan to use in your host applications

### Official SDKs

In the upcoming chapters, you’ll see solutions built using Python, TypeScript, Java, and .NET. Below are the officially supported SDKs.

MCP provides official SDKs for multiple languages:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Maintained in collaboration with Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Maintained in collaboration with Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - The official TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - The official Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - The official Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Maintained in collaboration with Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - The official Rust implementation

## Key Takeaways

- Setting up an MCP development environment is straightforward with language-specific SDKs
- Building MCP servers involves creating and registering tools with clear schemas
- MCP clients connect to servers and models to leverage extended capabilities
- Testing and debugging are critical for reliable MCP implementations
- Deployment options range from local development to cloud-based solutions

## Practicing

We provide a set of sample projects to complement the exercises in each chapter. Additionally, each chapter includes its own exercises and assignments.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Additional Resources

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## What's next

Next: [Creating your first MCP Server](01-first-server/README.md)

---

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we aim for accuracy, please note that automated translations may include errors or inaccuracies. The original document in its native language should be regarded as the authoritative source. For critical information, professional human translation is advised. We are not responsible for any misunderstandings or misinterpretations resulting from the use of this translation.