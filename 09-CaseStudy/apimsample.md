# Case Study: Expose REST API in API Management as an MCP server

Azure API Management, is a service that provides a Gateway on top of your API Endpoints. How it works is that Azure API Management acts like a proxy in front of your APIs and can decide what to do with incoming requests.

By using it, you add a whole host of features like:

- Security, you can use everything from API keys, JWT to managed identity.
- Rate limiting, a great feature is being able to decide how many calls get through per a certain time unit. This helps ensure all users have a great experience and also that your service isn't overwhelmed with requests.
- Scaling & Load balancing. You can set up a number of endpoints to balance out the load and you can also decide how to "load balance". 
- AI features like semantic caching, token limit and token monitoring and more. These are great features that improves responsiveness as well as helps you be on top of your token spending.

## Overview

In this specific use case we'll learn to expose API endpoints as an MCP Server. By doing this, we can easily make this endpoints part of an agentic app while also leveraging the features from Azure API Management.

## Key Features

## Expose API as MCP Server

To expose the API endpoints, let's follow these steps:

1. Navigate to Azure Portal and the following address <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp> 
Navigate to your API Management instance.

1. In the left menu, select APIs > MCP Servers > + Create new MCP Server.

1. In API, select a REST API to expose as an MCP server.

1. Select one or more API Operations to expose as tools. You can select all operations or only specific operations.

    ![Select methods to expose](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)


1. Select **Create**.

1. Navigate to the menu option **APIs** and **MCP Servers**, you should see the following:

    ![See the MCP Server in the main pane](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    The MCP server is created and the API operations are exposed as tools. The MCP server is listed in the MCP Servers pane. The URL column shows the endpoint of the MCP server that you can call for testing or within a client application.

## Optional: Configure policies

Azure API Management has the core concept of policies where you set up different rules for your endpoints like for example rate limiting or semantic caching. These policies are authored in XML.

Here's how you can set up a policy to rate limit your MCP Server:

1. In the portal, under APIs, select **MCP Servers**.

1. Select the MCP server you created.

1. In the left menu, under MCP, select **Policies**.

1. In the policy editor, add or edit the policies you want to apply to the MCP server's tools. The policies are defined in XML format. For example, you can add a policy to limit calls to the MCP server's tools (in this example, 5 calls per 30 second per client IP address). Here's XML that will cause it to rate limit:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Here's an image of the policy editor:

    ![Policy editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Try it out

Let's ensure our MCP Server is working as intended.



## References
