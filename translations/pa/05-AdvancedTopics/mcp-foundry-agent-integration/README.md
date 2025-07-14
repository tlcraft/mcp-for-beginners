<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:54:19+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "pa"
}
-->
# Model Context Protocol (MCP) ਦਾ Azure AI Foundry ਨਾਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ

ਇਹ ਗਾਈਡ ਦਿਖਾਉਂਦੀ ਹੈ ਕਿ ਕਿਵੇਂ Model Context Protocol (MCP) ਸਰਵਰਾਂ ਨੂੰ Azure AI Foundry ਏਜੰਟਾਂ ਨਾਲ ਜੋੜਿਆ ਜਾ ਸਕਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਸ਼ਕਤੀਸ਼ਾਲੀ ਟੂਲ ਆਰਕੀਸਟ੍ਰੇਸ਼ਨ ਅਤੇ ਐਂਟਰਪ੍ਰਾਈਜ਼ AI ਸਮਰੱਥਾਵਾਂ ਮਿਲਦੀਆਂ ਹਨ।

## ਪਰਿਚਯ

Model Context Protocol (MCP) ਇੱਕ ਖੁੱਲਾ ਮਿਆਰੀਕ੍ਰਿਤ ਪ੍ਰੋਟੋਕੋਲ ਹੈ ਜੋ AI ਐਪਲੀਕੇਸ਼ਨਾਂ ਨੂੰ ਬਾਹਰੀ ਡਾਟਾ ਸਰੋਤਾਂ ਅਤੇ ਟੂਲਾਂ ਨਾਲ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਜੁੜਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਜਦੋਂ ਇਸਨੂੰ Azure AI Foundry ਨਾਲ ਜੋੜਿਆ ਜਾਂਦਾ ਹੈ, ਤਾਂ MCP ਏਜੰਟਾਂ ਨੂੰ ਵੱਖ-ਵੱਖ ਬਾਹਰੀ ਸੇਵਾਵਾਂ, APIs ਅਤੇ ਡਾਟਾ ਸਰੋਤਾਂ ਤੱਕ ਪਹੁੰਚ ਅਤੇ ਇੰਟਰੈਕਟ ਕਰਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ।

ਇਹ ਇੰਟੀਗ੍ਰੇਸ਼ਨ MCP ਦੇ ਟੂਲ ਇਕੋਸਿਸਟਮ ਦੀ ਲਚਕੀਲਾਪਣ ਨੂੰ Azure AI Foundry ਦੇ ਮਜ਼ਬੂਤ ਏਜੰਟ ਫਰੇਮਵਰਕ ਨਾਲ ਮਿਲਾ ਕੇ ਐਂਟਰਪ੍ਰਾਈਜ਼-ਗਰੇਡ AI ਹੱਲ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ, ਜਿਸ ਵਿੱਚ ਵਿਆਪਕ ਕਸਟਮਾਈਜ਼ੇਸ਼ਨ ਸਮਰੱਥਾਵਾਂ ਹਨ।

**Note:** ਜੇ ਤੁਸੀਂ MCP ਨੂੰ Azure AI Foundry Agent Service ਵਿੱਚ ਵਰਤਣਾ ਚਾਹੁੰਦੇ ਹੋ, ਤਾਂ ਇਸ ਸਮੇਂ ਸਿਰਫ ਹੇਠਾਂ ਦਿੱਤੇ ਖੇਤਰਾਂ ਨੂੰ ਸਹਿਯੋਗ ਮਿਲਦਾ ਹੈ: westus, westus2, uaenorth, southindia ਅਤੇ switzerlandnorth

## ਸਿੱਖਣ ਦੇ ਲਕੜੇ

ਇਸ ਗਾਈਡ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- Model Context Protocol ਅਤੇ ਇਸਦੇ ਫਾਇਦੇ ਸਮਝਣਾ
- MCP ਸਰਵਰਾਂ ਨੂੰ Azure AI Foundry ਏਜੰਟਾਂ ਨਾਲ ਵਰਤਣ ਲਈ ਸੈਟਅੱਪ ਕਰਨਾ
- MCP ਟੂਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਨਾਲ ਏਜੰਟ ਬਣਾਉਣਾ ਅਤੇ ਸੰਰਚਿਤ ਕਰਨਾ
- ਅਸਲੀ MCP ਸਰਵਰਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪ੍ਰਯੋਗਿਕ ਉਦਾਹਰਣ ਲਾਗੂ ਕਰਨਾ
- ਏਜੰਟ ਗੱਲਬਾਤਾਂ ਵਿੱਚ ਟੂਲ ਜਵਾਬਾਂ ਅਤੇ ਹਵਾਲਿਆਂ ਨੂੰ ਸੰਭਾਲਣਾ

## ਜ਼ਰੂਰੀ ਸ਼ਰਤਾਂ

ਸ਼ੁਰੂ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ, ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਹਾਡੇ ਕੋਲ ਹੈ:

- Azure ਸਬਸਕ੍ਰਿਪਸ਼ਨ ਜਿਸ ਵਿੱਚ AI Foundry ਦੀ ਪਹੁੰਚ ਹੈ
- Python 3.10 ਜਾਂ ਉਸ ਤੋਂ ਉੱਪਰ
- Azure CLI ਇੰਸਟਾਲ ਅਤੇ ਸੰਰਚਿਤ
- AI ਸਰੋਤ ਬਣਾਉਣ ਲਈ ਉਚਿਤ ਅਧਿਕਾਰ

## Model Context Protocol (MCP) ਕੀ ਹੈ?

Model Context Protocol AI ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਇੱਕ ਮਿਆਰੀਕ੍ਰਿਤ ਤਰੀਕਾ ਹੈ ਜੋ ਬਾਹਰੀ ਡਾਟਾ ਸਰੋਤਾਂ ਅਤੇ ਟੂਲਾਂ ਨਾਲ ਜੁੜਦਾ ਹੈ। ਮੁੱਖ ਫਾਇਦੇ ਹਨ:

- **ਮਿਆਰੀਕ੍ਰਿਤ ਇੰਟੀਗ੍ਰੇਸ਼ਨ**: ਵੱਖ-ਵੱਖ ਟੂਲਾਂ ਅਤੇ ਸੇਵਾਵਾਂ ਲਈ ਇੱਕਸਾਰ ਇੰਟਰਫੇਸ
- **ਸੁਰੱਖਿਆ**: ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਪ੍ਰਣਾਲੀਆਂ
- **ਲਚਕੀਲਾਪਣ**: ਵੱਖ-ਵੱਖ ਡਾਟਾ ਸਰੋਤਾਂ, APIs ਅਤੇ ਕਸਟਮ ਟੂਲਾਂ ਲਈ ਸਹਿਯੋਗ
- **ਵਿਸਤਾਰਯੋਗਤਾ**: ਨਵੀਆਂ ਸਮਰੱਥਾਵਾਂ ਅਤੇ ਇੰਟੀਗ੍ਰੇਸ਼ਨਾਂ ਨੂੰ ਆਸਾਨੀ ਨਾਲ ਸ਼ਾਮਲ ਕਰਨ ਦੀ ਯੋਗਤਾ

## Azure AI Foundry ਨਾਲ MCP ਸੈਟਅੱਪ ਕਰਨਾ

### 1. ਵਾਤਾਵਰਣ ਸੰਰਚਨਾ

ਸਭ ਤੋਂ ਪਹਿਲਾਂ, ਆਪਣੇ ਵਾਤਾਵਰਣ ਦੇ ਵੈਰੀਏਬਲ ਅਤੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਸੈਟ ਕਰੋ:

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
    "server_label": "unique_server_name",      # MCP ਸਰਵਰ ਲਈ ਪਹਚਾਣ
    "server_url": "https://api.example.com/mcp", # MCP ਸਰਵਰ ਦਾ ਐਂਡਪੌਇੰਟ
    "require_approval": "never"                 # ਮਨਜ਼ੂਰੀ ਨੀਤੀ: ਇਸ ਵੇਲੇ ਸਿਰਫ "never" ਸਹਿਯੋਗਿਤ ਹੈ
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
        # MCP ਟੂਲਾਂ ਨਾਲ ਏਜੰਟ ਬਣਾਓ
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
        
        # ਗੱਲਬਾਤ ਦਾ ਧਾਗਾ ਬਣਾਓ
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # ਸੁਨੇਹਾ ਭੇਜੋ
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # ਏਜੰਟ ਚਲਾਓ
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # ਪੂਰਾ ਹੋਣ ਦੀ ਪ੍ਰਤੀਖਾ ਕਰੋ
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # ਚਲਾਉਣ ਦੇ ਕਦਮ ਅਤੇ ਟੂਲ ਕਾਲਾਂ ਦੀ ਜਾਂਚ ਕਰੋ
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # ਗੱਲਬਾਤ ਦਿਖਾਓ
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
```

## ਆਮ ਸਮੱਸਿਆਵਾਂ ਦਾ ਹੱਲ

### 1. ਕਨੈਕਸ਼ਨ ਸਮੱਸਿਆਵਾਂ
- MCP ਸਰਵਰ URL ਦੀ ਪਹੁੰਚ ਯਕੀਨੀ ਬਣਾਓ
- ਪ੍ਰਮਾਣਿਕਤਾ ਦੇ ਕ੍ਰੈਡੈਂਸ਼ਲ ਚੈੱਕ ਕਰੋ
- ਨੈੱਟਵਰਕ ਕਨੈਕਸ਼ਨ ਦੀ ਜਾਂਚ ਕਰੋ

### 2. ਟੂਲ ਕਾਲ ਫੇਲ੍ਹ ਹੋਣਾ
- ਟੂਲ ਦੇ ਆਰਗੁਮੈਂਟ ਅਤੇ ਫਾਰਮੈਟਿੰਗ ਦੀ ਸਮੀਖਿਆ ਕਰੋ
- ਸਰਵਰ-ਵਿਸ਼ੇਸ਼ ਲੋੜਾਂ ਦੀ ਜਾਂਚ ਕਰੋ
- ਠੀਕ ਤਰੀਕੇ ਨਾਲ ਐਰਰ ਹੈਂਡਲਿੰਗ ਲਾਗੂ ਕਰੋ

### 3. ਪ੍ਰਦਰਸ਼ਨ ਸਮੱਸਿਆਵਾਂ
- ਟੂਲ ਕਾਲ ਦੀ ਫ੍ਰਿਕਵੈਂਸੀ ਨੂੰ ਅਪਟੀਮਾਈਜ਼ ਕਰੋ
- ਜਿੱਥੇ ਲੋੜ ਹੋਵੇ ਕੈਸ਼ਿੰਗ ਲਾਗੂ ਕਰੋ
- ਸਰਵਰ ਦੇ ਜਵਾਬ ਦੇ ਸਮੇਂ ਦੀ ਨਿਗਰਾਨੀ ਕਰੋ

## ਅਗਲੇ ਕਦਮ

ਆਪਣੇ MCP ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਨੂੰ ਹੋਰ ਬਿਹਤਰ ਬਣਾਉਣ ਲਈ:

1. **ਕਸਟਮ MCP ਸਰਵਰ ਬਣਾਓ**: ਆਪਣੇ ਖਾਸ ਡਾਟਾ ਸਰੋਤਾਂ ਲਈ MCP ਸਰਵਰ ਬਣਾਓ
2. **ਉੱਚ ਸੁਰੱਖਿਆ ਲਾਗੂ ਕਰੋ**: OAuth2 ਜਾਂ ਕਸਟਮ ਪ੍ਰਮਾਣਿਕਤਾ ਪ੍ਰਣਾਲੀਆਂ ਸ਼ਾਮਲ ਕਰੋ
3. **ਮਾਨੀਟਰਿੰਗ ਅਤੇ ਵਿਸ਼ਲੇਸ਼ਣ**: ਟੂਲ ਦੀ ਵਰਤੋਂ ਲਈ ਲੌਗਿੰਗ ਅਤੇ ਮਾਨੀਟਰਿੰਗ ਲਾਗੂ ਕਰੋ
4. **ਆਪਣੇ ਹੱਲ ਨੂੰ ਸਕੇਲ ਕਰੋ**: ਲੋਡ ਬੈਲੈਂਸਿੰਗ ਅਤੇ ਵੰਡੇ MCP ਸਰਵਰ ਆਰਕੀਟੈਕਚਰਾਂ ਬਾਰੇ ਸੋਚੋ

## ਵਾਧੂ ਸਰੋਤ

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## ਸਹਾਇਤਾ

ਵਾਧੂ ਸਹਾਇਤਾ ਅਤੇ ਸਵਾਲਾਂ ਲਈ:
- [Azure AI Foundry documentation](https://learn.microsoft.com/azure/ai-foundry/) ਨੂੰ ਵੇਖੋ
- [MCP community resources](https://modelcontextprotocol.io/) ਦੀ ਜਾਂਚ ਕਰੋ

## ਅਗਲਾ ਕੀ ਹੈ

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।