# Case Study: Connecting to the Microsoft Learn Docs MCP Server from a Python Client

Have you ever found yourself juggling between documentation sites, Stack Overflow, and endless search engine tabs, all while trying to solve a problem in your code? Maybe you keep a second monitor just for docs, or you’re constantly alt-tabbing between your IDE and a browser. Wouldn’t it be better if you could bring the documentation right into your workflow—integrated into your apps, your IDE, or even your own custom tools? In this case study, we’ll explore how to do exactly that by connecting directly to the Microsoft Learn Docs MCP server from a Python client.

## Overview

Modern development is more than just writing code—it’s about finding the right information at the right time. Documentation is everywhere, but it’s rarely where you need it most: inside your tools and workflows. By integrating documentation retrieval directly into your applications, you can save time, reduce context switching, and boost productivity. In this section, we’ll show you how to connect a Python client to the Microsoft Learn Docs MCP server, so you can access real-time, context-aware documentation without ever leaving your app.

We’ll walk through the process of establishing a connection, sending a request, and handling streaming responses efficiently. This approach not only streamlines your workflow but also opens the door to building smarter, more helpful developer tools.

## Learning Objectives

Why are we doing this? Because the best developer experiences are those that remove friction. Imagine a world where your code editor, chatbot, or web app can answer your documentation questions instantly, using the latest content from Microsoft Learn. By the end of this chapter, you’ll know how to:

- Understand the basics of MCP server-client communication for documentation
- Implement a Python console application to connect to the Microsoft Learn Docs MCP server
- Use streaming HTTP clients for real-time documentation retrieval
- Log and interpret documentation responses in your application

You’ll see how these skills can help you build tools that are not just reactive, but truly interactive and context-aware.

## Assignment

Let’s put this into practice. Your task is to write a Python script that connects to the Microsoft Learn Docs MCP server, invokes the `microsoft_docs_search` tool, and logs the streaming response to the console. Why this approach? Because it’s the foundation for building more advanced integrations—whether you want to power a chatbot, an IDE extension, or a web dashboard.

You’ll find the code and instructions for this scenario in the `scenario3` folder within this case study. The steps will guide you through setting up the connection, making a query, and handling the results in a user-friendly way.

- Write a Python client (`client.py`) that connects to the Microsoft Learn Docs MCP server at `https://learn.microsoft.com/api/mcp`
- Use the official MCP Python SDK and streamable HTTP client for connection
- Call the `microsoft_docs_search` tool with a query parameter to retrieve documentation
- Implement proper logging and error handling 
- Create an interactive console interface to allow users to enter multiple search queries

## Sample Queries

Documentation is only useful if you can get to it quickly. Here are some example queries you can try in your interactive client to see just how powerful this integration can be:

- Tell me about Azure OpenAI from Microsoft Learn
- How do I deploy a web app using Azure App Service from Microsoft Learn?
- Show me the documentation for Azure Functions bindings from Microsoft Learn
- What is Azure Key Vault? Get details from Microsoft Learn
- Search for 'virtual network peering' in Microsoft Learn documentation

You can enter your own questions or documentation requests. Type `exit` to quit the client.

## Solution

Now let’s see it in action. Below is a minimal sample solution to the assignment. The full code and details are available in the `scenario3/client.py` file. This example demonstrates the essential steps to connect to the Microsoft Learn Docs MCP server, call a tool, and print the result.

We’re doing it this way because it’s simple, effective, and forms the basis for more complex integrations. Once you have this working, you can expand it to support richer user interfaces, advanced error handling, or even AI-powered suggestions.

<details>
<summary>Python</summary>

```python
import asyncio
from mcp.client.streamable_http import streamablehttp_client
from mcp import ClientSession

async def main():
    async with streamablehttp_client("https://learn.microsoft.com/api/mcp") as (read_stream, write_stream, _):
        async with ClientSession(read_stream, write_stream) as session:
            await session.initialize()
            result = await session.call_tool("microsoft_docs_search", {"query": "Azure Functions best practices"})
            print(result.content)

if __name__ == "__main__":
    asyncio.run(main())
```

</details>

- For the complete implementation and logging, see [`client.py`](scenario3/client.py).
- For installation and usage instructions, see the [`README.md`](scenario3/README.md) file.

## Key Takeaways

Integrating documentation directly into your tools isn’t just a convenience—it’s a game changer for productivity. By connecting to the Microsoft Learn Docs MCP server from a Python client, you can:

- Eliminate context switching between your code and documentation
- Retrieve up-to-date, context-aware docs in real time
- Build smarter, more interactive developer tools

These skills will help you create solutions that are not only efficient, but also delightful to use.

## Additional Resources

To deepen your understanding, explore these official resources:

- [Microsoft Learn Docs MCP Server (GitHub)](https://github.com/MicrosoftDocs/mcp)
- [Get started with Azure MCP Server (mcp-python)](https://learn.microsoft.com/en-us/azure/developer/azure-mcp-server/get-started#create-the-python-app)
- [What is the Azure MCP Server?](https://learn.microsoft.com/en-us/azure/developer/azure-mcp-server/)
- [Model Context Protocol (MCP) Introduction](https://modelcontextprotocol.io/introduction)
- [Add plugins from a MCP Server (Python)](https://learn.microsoft.com/en-us/semantic-kernel/concepts/plugins/adding-mcp-plugins)

## What's Next

In the next scenario, you’ll learn how to deploy a web application or service that interacts with the Microsoft Learn Docs MCP server, demonstrating more advanced features and integrations.

Stay tuned for deeper dives into MCP server features and best practices for robust client-server communication.
