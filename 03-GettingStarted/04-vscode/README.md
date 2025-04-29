# Consuming a server from GitHub Copilot Agent mode

## Overview

## Learning Objectives

## To set up an MCP Client and MCP Server in Visual Studio Code, follow these steps:

Getting started with MCP in Visual Studio Code is a straightforward process that enables rapid prototyping and testing of AI-powered tools. By following the steps below, you'll set up both an MCP client and server, allowing you to explore the protocol's capabilities in a hands-on way. Let's walk through the essential setup process.

1. **Install Required Dependencies**:

   - Ensure you have Python (version 3.12.9 or later) and Node.js (version 22.14.0 or later) installed on your machine.
   - Install MCP server packages using npm:

     ```bash
     npm install -g @modelcontextprotocol/server-filesystem
     npm install -g @modelcontextprotocol/server-postgres
     ```

2 **Configure MCP Servers**:
   - Open your workspace in Visual Studio Code.
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
   - Go to `File -> Preferences -> Settings` in Visual Studio Code.
   - Search for "MCP" and enable `chat.mcp.discovery.enabled` in the settings.json file.

5. **Start MCP Server**:
   - Run the MCP server locally using the configured command.
   - Test the server by sending requests through the Copilot Agent Mode in Visual Studio Code.

6. **Use MCP Client**:
   - Open the Copilot Chat window in Visual Studio Code.
   - Switch to Agent Mode and interact with the MCP server tools.



## Exercise: 

## Assignment

## Solution

## Key Takeaways

## Samples

## Additional Resources

## What's Next


