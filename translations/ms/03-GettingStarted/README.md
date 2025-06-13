<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T00:35:10+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ms"
}
-->
## Getting Started  

This section includes several lessons:

- **1 Your first server**: In this first lesson, you'll learn how to create your first server and inspect it using the inspector tool, a great way to test and debug your server. [to the lesson](/03-GettingStarted/01-first-server/README.md)

- **2 Client**: In this lesson, you'll learn how to write a client that can connect to your server. [to the lesson](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**: An even better way to write a client is by adding an LLM so it can "negotiate" with your server on what to do. [to the lesson](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**: Here, we explore running our MCP Server directly from Visual Studio Code. [to the lesson](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)**: SSE is a standard for server-to-client streaming, allowing servers to push real-time updates to clients over HTTP. [to the lesson](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming with MCP (Streamable HTTP)**: Learn about modern HTTP streaming, progress notifications, and how to build scalable, real-time MCP servers and clients using Streamable HTTP. [to the lesson](/03-GettingStarted/06-http-streaming/README.md)

- **7 Utilising AI Toolkit for VSCode**: Use this to consume and test your MCP Clients and Servers. [to the lesson](/03-GettingStarted/07-aitk/README.md)

- **8 Testing**: This lesson focuses on various ways to test your server and client. [to the lesson](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**: This chapter covers different methods for deploying your MCP solutions. [to the lesson](/03-GettingStarted/09-deployment/README.md)


The Model Context Protocol (MCP) is an open protocol that standardizes how applications provide context to LLMs. Think of MCP as a USB-C port for AI applications — it offers a standardized way to connect AI models to various data sources and tools.

## Learning Objectives

By the end of this lesson, you will be able to:

- Set up development environments for MCP in C#, Java, Python, TypeScript, and JavaScript
- Build and deploy basic MCP servers with custom features (resources, prompts, and tools)
- Create host applications that connect to MCP servers
- Test and debug MCP implementations
- Understand common setup challenges and how to solve them
- Connect your MCP implementations to popular LLM services

## Setting Up Your MCP Environment

Before you start working with MCP, it’s important to prepare your development environment and understand the basic workflow. This section will guide you through the initial setup steps to ensure a smooth start with MCP.

### Prerequisites

Before diving into MCP development, make sure you have:

- **Development Environment**: For your chosen language (C#, Java, Python, TypeScript, or JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, or any modern code editor
- **Package Managers**: NuGet, Maven/Gradle, pip, or npm/yarn
- **API Keys**: For any AI services you plan to use in your host applications

### Official SDKs

In the upcoming chapters, you will see solutions built using Python, TypeScript, Java, and .NET. Here are all the officially supported SDKs.

MCP offers official SDKs for multiple languages:
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
- Testing and debugging are essential for reliable MCP implementations
- Deployment options range from local development to cloud-based solutions

## Practicing

We provide a set of samples that complement the exercises you’ll find in all chapters in this section. Additionally, each chapter includes its own exercises and assignments.

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

Next: [Creating your first MCP Server](/03-GettingStarted/01-first-server/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.