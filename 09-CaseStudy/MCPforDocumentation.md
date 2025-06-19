# Case Study: Connecting to the Microsoft Learn Docs MCP Server from a Python Client

This chapter demonstrates how to connect to the Microsoft Learn Docs MCP server from a Python client application. You will learn how to use the official MCP Python SDK and a streaming HTTP client to call documentation tools on the server and log the response in a console application. This practical scenario will help you understand how to access real-time, context-aware Microsoft documentation programmatically.

## Overview

In this section, we introduce the process of connecting a Python client to the Microsoft Learn Docs MCP server. The focus is on establishing a connection, sending a request, and handling streaming responses efficiently. By following this guide, you will gain hands-on experience with real-world client-server interactions for documentation retrieval.

- Learn to connect to the Microsoft Learn Docs MCP server using Python
- Use a streaming HTTP client for efficient data handling
- Call documentation tools on the server and process the response
- Log the output in a console application

## Learning Objectives

By the end of this chapter, you will be able to:

- Understand the basics of MCP server-client communication for documentation
- Implement a Python console application to connect to the Microsoft Learn Docs MCP server
- Use streaming HTTP clients for real-time documentation retrieval
- Log and interpret documentation responses in your application

## Assignment

To reinforce your understanding, you will complete a hands-on assignment. This assignment will require you to write a Python script that connects to the Microsoft Learn Docs MCP server, invokes the `microsoft_docs_search` tool, and logs the streaming response to the console. The code and instructions for this scenario are provided in the `scenario3` folder within this case study.

- Write a Python client (`client.py`) that connects to the Microsoft Learn Docs MCP server at `https://learn.microsoft.com/api/mcp`
- Use the official MCP Python SDK and streamable HTTP client for connection
- Call the `microsoft_docs_search` tool with a query parameter to retrieve documentation
- Implement proper logging and error handling 
- Create an interactive console interface to allow users to enter multiple search queries

## Sample Queries

Try these example queries in the interactive client to retrieve documentation from Microsoft Learn:

- Tell me about Azure OpenAI from Microsoft Learn
- How do I deploy a web app using Azure App Service from Microsoft Learn?
- Show me the documentation for Azure Functions bindings from Microsoft Learn
- What is Azure Key Vault? Get details from Microsoft Learn
- Search for 'virtual network peering' in Microsoft Learn documentation

You can enter your own questions or documentation requests. Type `exit` to quit the client.

## Solution
<details>
<summary>Python</summary>

Here, we provide a minimal sample solution to the assignment. The full code and details are available in the `scenario3/client.py` file. This example demonstrates the essential steps to connect to the Microsoft Learn Docs MCP server, call a tool, and print the result.


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

- Connecting to the Microsoft Learn Docs MCP server from a Python client is straightforward with the right tools
- Streaming HTTP clients enable efficient, real-time documentation retrieval
- Logging responses in a console app helps with debugging and monitoring

## Additional Resources

To deepen your understanding, explore these official resources:

- [Microsoft Learn Docs MCP Server (GitHub)](https://github.com/MicrosoftDocs/mcp)
- [Get started with Azure MCP Server (mcp-python)](https://learn.microsoft.com/en-us/azure/developer/azure-mcp-server/get-started#create-the-python-app)
- [What is the Azure MCP Server?](https://learn.microsoft.com/en-us/azure/developer/azure-mcp-server/)
- [Model Context Protocol (MCP) Introduction](https://modelcontextprotocol.io/introduction)
- [Add plugins from a MCP Server (Python)](https://learn.microsoft.com/en-us/semantic-kernel/concepts/plugins/adding-mcp-plugins)

## What's Next

In the next scenario, you will learn how to deploy a web application or service that interacts with the Microsoft Learn Docs MCP server, demonstrating more advanced features and integrations.

Stay tuned for deeper dives into MCP server features and best practices for robust client-server communication.
