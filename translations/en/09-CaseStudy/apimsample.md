<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:18:58+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "en"
}
-->
# Case Study: Expose REST API in API Management as an MCP server

Azure API Management is a service that provides a Gateway on top of your API Endpoints. It works by acting as a proxy in front of your APIs and deciding how to handle incoming requests.

By using it, you gain access to a wide range of features such as:

- **Security**: You can use everything from API keys and JWT to managed identity.
- **Rate limiting**: A useful feature that lets you control how many calls are allowed within a certain time frame. This ensures all users have a smooth experience and prevents your service from being overwhelmed.
- **Scaling & Load balancing**: You can configure multiple endpoints to distribute the load and choose how to balance it.
- **AI features like semantic caching**, token limits, token monitoring, and more. These features improve responsiveness and help you keep track of your token usage. [Read more here](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Why MCP + Azure API Management?

Model Context Protocol is quickly becoming a standard for agentic AI applications and for exposing tools and data in a consistent way. Azure API Management is a natural choice when you need to "manage" APIs. MCP Servers often integrate with other APIs to resolve requests to a tool, for example. Therefore, combining Azure API Management and MCP makes a lot of sense.

## Overview

In this specific use case, we'll learn how to expose API endpoints as an MCP Server. This allows us to easily include these endpoints as part of an agentic app while also taking advantage of Azure API Management’s features.

## Key Features

- You choose which endpoint methods you want to expose as tools.
- The additional features you get depend on what you configure in the policy section for your API. Here, we will show you how to add rate limiting.

## Pre-step: import an API

If you already have an API in Azure API Management, great—you can skip this step. If not, check out this link: [importing an API to Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Expose API as MCP Server

To expose the API endpoints, follow these steps:

1. Go to the Azure Portal at <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp> and navigate to your API Management instance.

2. In the left menu, select APIs > MCP Servers > + Create new MCP Server.

3. In API, select a REST API to expose as an MCP server.

4. Select one or more API Operations to expose as tools. You can select all operations or only specific ones.

    ![Select methods to expose](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

5. Click **Create**.

6. Go to the **APIs** menu and then **MCP Servers**; you should see the following:

    ![See the MCP Server in the main pane](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    The MCP server is created and the API operations are exposed as tools. The MCP server is listed in the MCP Servers pane. The URL column shows the endpoint of the MCP server that you can call for testing or use within a client application.

## Optional: Configure policies

Azure API Management uses policies to set up different rules for your endpoints, such as rate limiting or semantic caching. These policies are written in XML.

Here’s how to set up a policy to rate limit your MCP Server:

1. In the portal, under APIs, select **MCP Servers**.

2. Select the MCP server you created.

3. In the left menu, under MCP, select **Policies**.

4. In the policy editor, add or edit the policies you want to apply to the MCP server’s tools. Policies are defined in XML format. For example, you can add a policy to limit calls to the MCP server’s tools (in this example, 5 calls per 30 seconds per client IP address). Here’s XML that will enforce rate limiting:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Here’s an image of the policy editor:

    ![Policy editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Try it out

Let’s make sure our MCP Server is working as expected.

For this, we will use Visual Studio Code with GitHub Copilot in Agent mode. We will add the MCP server to a *mcp.json* file. This way, Visual Studio Code acts as a client with agentic capabilities, allowing end users to type prompts and interact with the server.

Here’s how to add the MCP server in Visual Studio Code:

1. Use the MCP: **Add Server** command from the Command Palette.

2. When prompted, select the server type: **HTTP (HTTP or Server Sent Events)**.

3. Enter the URL of the MCP server in API Management. For example: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (for SSE endpoint) or **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (for MCP endpoint). Note the difference between the transports is `/sse` or `/mcp`.

4. Enter a server ID of your choice. This is just a label to help you remember this server instance.

5. Choose whether to save the configuration to your workspace settings or user settings.

  - **Workspace settings** - The server configuration is saved to a .vscode/mcp.json file, available only in the current workspace.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    If you choose streaming HTTP as the transport, it will look slightly different:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - The server configuration is added to your global *settings.json* file and is available in all workspaces. The configuration looks like this:

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

6. You also need to add a header to authenticate properly with Azure API Management. It uses a header called **Ocp-Apim-Subscription-Key**.

    - Here’s how to add it to settings:

    ![Adding header for authentication](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png). This will prompt you to enter the API key value, which you can find in the Azure Portal for your Azure API Management instance.

    - To add it to *mcp.json* instead, you can add it like this:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Use Agent mode

Now that everything is set up in either settings or *.vscode/mcp.json*, let’s try it out.

There should be a Tools icon like this, where the exposed tools from your server are listed:

![Tools from the server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Click the tools icon, and you should see a list of tools like this:

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

2. Enter a prompt in the chat to invoke a tool. For example, if you selected a tool to get information about an order, you can ask the agent about an order. Here’s an example prompt:

    ```text
    get information from order 2
    ```

    You will then see a tools icon asking you to confirm running a tool. Select to continue, and you should see an output like this:

    ![Result from prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **What you see depends on the tools you’ve set up, but the idea is that you get a textual response like the one above.**

## References

Here’s where you can learn more:

- [Tutorial on Azure API Management and MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python sample: Secure remote MCP servers using Azure API Management (experimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [MCP client authorization lab](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)
- [Use the Azure API Management extension for VS Code to import and manage APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)
- [Register and discover remote MCP servers in Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Great repo showcasing many AI capabilities with Azure API Management
- [AI Gateway workshops](https://azure-samples.github.io/AI-Gateway/) Contains workshops using Azure Portal, a great way to start exploring AI capabilities.

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.