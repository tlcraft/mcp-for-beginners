# Scenario 1: Python Console Client for Microsoft Learn Docs MCP Server

This example shows how to connect to the Microsoft Learn Docs MCP server from a Python console client using the Model Context Protocol (MCP) over streamable HTTP. The client allows interactive documentation queries using the supported `microsoft_docs_search` tool.

## Prerequisites

- Python 3.8 or higher
- MCP Python SDK (install with pip)
- Internet connection to access the Microsoft Learn Docs MCP Server

## Installation

1. (Recommended) Create and activate a virtual environment:
   ```sh
   python -m venv .venv
   .venv\Scripts\activate  # On Windows
   source .venv/bin/activate  # On macOS/Linux
   ```
2. Install required packages:
   ```sh
   pip install mcp anyio
   ```

## Usage

1. No local server needed - this client connects to the official Microsoft Learn Docs MCP server at `https://learn.microsoft.com/api/mcp`.
2. Run the client:
   ```sh
   python client.py
   ```
3. When prompted, enter your documentation query (for example, "Azure Functions best practices")
4. Type "exit" to quit the program

## What this does

- Connects to the Microsoft Learn Docs MCP server at `https://learn.microsoft.com/api/mcp` using streamable HTTP
- Initializes an MCP session and provides an interactive interface to search documentation
- Calls the `microsoft_docs_search` tool with your query
- Logs all received messages and tool results to the console
- Provides clear error handling for tool invocation and connection issues

## Sample Queries

- "Azure Functions best practices"
- "How to deploy a static website to Azure"
- "C# async await patterns"
- "Azure Kubernetes Service overview"

## References

- [Microsoft Docs MCP Server (GitHub)](https://github.com/MicrosoftDocs/mcp)
- [Model Context Protocol (MCP) Introduction](https://modelcontextprotocol.io/introduction)
- [Get started with Azure MCP Server (mcp-python)](https://learn.microsoft.com/en-us/azure/developer/azure-mcp-server/get-started#create-the-python-app)