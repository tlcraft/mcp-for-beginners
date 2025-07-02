# Model Context Protocol (MCP) Integration with Azure AI Foundry

This guide demonstrates how to integrate Model Context Protocol (MCP) servers with Azure AI Foundry agents, enabling powerful tool orchestration and enterprise AI capabilities.

## Introduction

Model Context Protocol (MCP) is an open standard that enables AI applications to securely connect to external data sources and tools. When integrated with Azure AI Foundry, MCP allows agents to access and interact with various external services, APIs, and data sources in a standardized way.

This integration combines the flexibility of MCP's tool ecosystem with Azure AI Foundry's robust agent framework, providing enterprise-grade AI solutions with extensive customization capabilities.

**Note:** If you want to use MCP in Azure AI Foundry Agent Service, currently only the following regions are supported: westus, westus2, uaenorth, southindia and switzerlandnorth

## Learning Objectives

By the end of this guide, you will be able to:

- Understand the Model Context Protocol and its benefits
- Set up MCP servers for use with Azure AI Foundry agents
- Create and configure agents with MCP tool integration
- Implement practical examples using real MCP servers
- Handle tool responses and citations in agent conversations

## Prerequisites

Before starting, ensure you have:

- An Azure subscription with AI Foundry access
- Python 3.10+ 
- Azure CLI installed and configured
- Appropriate permissions to create AI resources

## What is Model Context Protocol (MCP)?

Model Context Protocol is a standardized way for AI applications to connect to external data sources and tools. Key benefits include:

- **Standardized Integration**: Consistent interface across different tools and services
- **Security**: Secure authentication and authorization mechanisms
- **Flexibility**: Support for various data sources, APIs, and custom tools
- **Extensibility**: Easy to add new capabilities and integrations

## Setting Up MCP with Azure AI Foundry

### 1. Environment Configuration

First, set up your environment variables and dependencies:

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="You are a helpful assistant. Use the tools provided to answer questions. Be sure to cite your sources.",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"Created agent, agent ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identifier for the MCP server
    "server_url": "https://api.example.com/mcp", # MCP server endpoint
    "require_approval": "never"                 # Approval policy: this time only support "never" 
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # Create agent with MCP tools
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="You are a helpful assistant specializing in Microsoft documentation. Use the Microsoft Learn MCP server to search for accurate, up-to-date information. Always cite your sources.",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"Created agent, agent ID: {agent.id}")    
        
        # Create conversation thread
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Send message
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Run the agent
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Poll for completion
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Examine run steps and tool calls
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Display conversation
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
```


## Troubleshooting Common Issues

### 1. Connection Issues
- Verify MCP server URL is accessible
- Check authentication credentials
- Ensure network connectivity

### 2. Tool Call Failures
- Review tool arguments and formatting
- Check server-specific requirements
- Implement proper error handling

### 3. Performance Issues
- Optimize tool call frequency
- Implement caching where appropriate
- Monitor server response times

## Next Steps

To further enhance your MCP integration:

1. **Explore Custom MCP Servers**: Build your own MCP servers for proprietary data sources
2. **Implement Advanced Security**: Add OAuth2 or custom authentication mechanisms
3. **Monitor and Analytics**: Implement logging and monitoring for tool usage
4. **Scale Your Solution**: Consider load balancing and distributed MCP server architectures

## Additional Resources

- [Azure AI Foundry Documentation](https://learn.microsoft.com/en-us/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/en-us/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/en-us/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## Support

For additional support and questions:
- Review the [Azure AI Foundry documentation](https://learn.microsoft.com/en-us/azure/ai-foundry/)
- Check the [MCP community resources](https://modelcontextprotocol.io/)