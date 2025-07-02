<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:13:15+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "pa"
}
-->
# Model Context Protocol (MCP) ਦਾ Azure AI Foundry ਨਾਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ

ਇਹ ਗਾਈਡ ਦਿਖਾਉਂਦੀ ਹੈ ਕਿ ਕਿਵੇਂ Model Context Protocol (MCP) ਸਰਵਰਾਂ ਨੂੰ Azure AI Foundry ਏਜੰਟਸ ਨਾਲ ਜੋੜਿਆ ਜਾ ਸਕਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਸ਼ਕਤੀਸ਼ਾਲੀ ਟੂਲ ਆਰਕੇਸਟ੍ਰੇਸ਼ਨ ਅਤੇ ਉਦਯੋਗਕ AI ਸਮਰੱਥਾਵਾਂ ਨੂੰ ਸਹੂਲਤ ਮਿਲਦੀ ਹੈ।

## ਪਰਿਚਯ

Model Context Protocol (MCP) ਇੱਕ ਖੁੱਲ੍ਹਾ ਮਿਆਰੀਕ੍ਰਿਤ ਢਾਂਚਾ ਹੈ ਜੋ AI ਐਪਲੀਕੇਸ਼ਨਾਂ ਨੂੰ ਬਾਹਰੀ ਡੇਟਾ ਸਰੋਤਾਂ ਅਤੇ ਟੂਲਾਂ ਨਾਲ ਸੁਰੱਖਿਅਤ ਤਰੀਕੇ ਨਾਲ ਜੁੜਨ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਜਦੋਂ ਇਸਨੂੰ Azure AI Foundry ਨਾਲ ਜੋੜਿਆ ਜਾਂਦਾ ਹੈ, ਤਾਂ MCP ਏਜੰਟਸ ਨੂੰ ਵੱਖ-ਵੱਖ ਬਾਹਰੀ ਸਰਵਿਸਾਂ, APIs ਅਤੇ ਡੇਟਾ ਸਰੋਤਾਂ ਤੱਕ ਪਹੁੰਚ ਅਤੇ ਇੰਟਰੈਕਸ਼ਨ ਦਾ ਮਿਆਰੀਕ੍ਰਿਤ ਤਰੀਕਾ ਪ੍ਰਦਾਨ ਕਰਦਾ ਹੈ।

ਇਹ ਇੰਟੀਗ੍ਰੇਸ਼ਨ MCP ਦੇ ਟੂਲ ਈਕੋਸਿਸਟਮ ਦੀ ਲਚਕੀਲਾਪਣ ਅਤੇ Azure AI Foundry ਦੇ ਮਜ਼ਬੂਤ ਏਜੰਟ ਫਰੇਮਵਰਕ ਨੂੰ ਜੋੜਦਾ ਹੈ, ਜਿਸ ਨਾਲ ਵਿਆਪਕ ਕਸਟਮਾਈਜ਼ੇਸ਼ਨ ਸਮਰੱਥਾਵਾਂ ਵਾਲੇ ਉਦਯੋਗਕ-ਮਿਆਰ ਦੇ AI ਹੱਲ ਪ੍ਰਦਾਨ ਹੁੰਦੇ ਹਨ।

**Note:** ਜੇ ਤੁਸੀਂ Azure AI Foundry Agent Service ਵਿੱਚ MCP ਵਰਤਣਾ ਚਾਹੁੰਦੇ ਹੋ, ਤਾਂ ਇਸ ਸਮੇਂ ਸਿਰਫ ਹੇਠ ਲਿਖੇ ਖੇਤਰ ਸਹਿਯੋਗਤ ਹਨ: westus, westus2, uaenorth, southindia ਅਤੇ switzerlandnorth

## ਸਿੱਖਣ ਦੇ ਲਕੜ

ਇਸ ਗਾਈਡ ਦੇ ਅੰਤ ਤੱਕ, ਤੁਸੀਂ ਸਮਰੱਥ ਹੋਵੋਗੇ:

- Model Context Protocol ਅਤੇ ਇਸਦੇ ਫਾਇਦੇ ਸਮਝਣਾ
- Azure AI Foundry ਏਜੰਟਸ ਲਈ MCP ਸਰਵਰ ਸੈੱਟਅੱਪ ਕਰਨਾ
- MCP ਟੂਲ ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਨਾਲ ਏਜੰਟ ਬਣਾਉਣਾ ਅਤੇ ਸੰਰਚਿਤ ਕਰਨਾ
- ਅਸਲੀ MCP ਸਰਵਰਾਂ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪ੍ਰਯੋਗਿਕ ਉਦਾਹਰਣ ਲਾਗੂ ਕਰਨਾ
- ਏਜੰਟ ਗੱਲਬਾਤ ਵਿੱਚ ਟੂਲ ਜਵਾਬ ਅਤੇ ਹਵਾਲਿਆਂ ਨੂੰ ਸੰਭਾਲਣਾ

## ਲੋੜੀਂਦੇ ਤੱਤ

ਸ਼ੁਰੂ ਕਰਨ ਤੋਂ ਪਹਿਲਾਂ ਇਹ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਤੁਹਾਡੇ ਕੋਲ ਹਨ:

- Azure ਸਬਸਕ੍ਰਿਪਸ਼ਨ ਜਿਸ ਵਿੱਚ AI Foundry ਦੀ ਪਹੁੰਚ ਹੈ
- Python 3.10+ 
- Azure CLI ਇੰਸਟਾਲ ਅਤੇ ਸੰਰਚਿਤ
- AI ਸਰੋਤ ਬਣਾਉਣ ਲਈ ਯੋਗ ਅਧਿਕਾਰ

## Model Context Protocol (MCP) ਕੀ ਹੈ?

Model Context Protocol AI ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਬਾਹਰੀ ਡੇਟਾ ਸਰੋਤਾਂ ਅਤੇ ਟੂਲਾਂ ਨਾਲ ਜੁੜਨ ਦਾ ਇੱਕ ਮਿਆਰੀਕ੍ਰਿਤ ਤਰੀਕਾ ਹੈ। ਮੁੱਖ ਫਾਇਦੇ ਹਨ:

- **ਮਿਆਰੀਕ੍ਰਿਤ ਇੰਟੀਗ੍ਰੇਸ਼ਨ**: ਵੱਖ-ਵੱਖ ਟੂਲਾਂ ਅਤੇ ਸਰਵਿਸਾਂ ਲਈ ਇਕਸਾਰ ਇੰਟਰਫੇਸ
- **ਸੁਰੱਖਿਆ**: ਸੁਰੱਖਿਅਤ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰਤ ਤਰੀਕੇ
- **ਲਚਕੀਲਾਪਣ**: ਵੱਖ-ਵੱਖ ਡੇਟਾ ਸਰੋਤ, APIs ਅਤੇ ਕਸਟਮ ਟੂਲਾਂ ਦਾ ਸਮਰਥਨ
- **ਵਿਸਥਾਰਯੋਗਤਾ**: ਨਵੀਆਂ ਸਮਰੱਥਾਵਾਂ ਅਤੇ ਇੰਟੀਗ੍ਰੇਸ਼ਨਾਂ ਨੂੰ ਆਸਾਨੀ ਨਾਲ ਸ਼ਾਮਲ ਕਰਨਾ

## Azure AI Foundry ਨਾਲ MCP ਸੈੱਟਅੱਪ ਕਰਨਾ

### 1. ਵਾਤਾਵਰਣ ਸੰਰਚਨਾ

ਸਭ ਤੋਂ ਪਹਿਲਾਂ ਆਪਣੇ ਵਾਤਾਵਰਣ ਦੇ ਵੈਰੀਏਬਲ ਅਤੇ ਨਿਰਭਰਤਾਵਾਂ ਸੈੱਟ ਕਰੋ:

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
        instructions="ਤੁਸੀਂ ਇੱਕ ਮਦਦਗਾਰ ਸਹਾਇਕ ਹੋ। ਪ੍ਰਸ਼ਨਾਂ ਦੇ ਜਵਾਬ ਦੇਣ ਲਈ ਦਿੱਤੇ ਗਏ ਟੂਲਾਂ ਦੀ ਵਰਤੋਂ ਕਰੋ। ਹਮੇਸ਼ਾਂ ਆਪਣੇ ਸਰੋਤਾਂ ਦਾ ਹਵਾਲਾ ਦਿਓ।",
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
    "server_label": "unique_server_name",      # MCP ਸਰਵਰ ਲਈ ਪਛਾਣ ਨਾਂ
    "server_url": "https://api.example.com/mcp", # MCP ਸਰਵਰ ਐਂਡਪੌਇੰਟ
    "require_approval": "never"                 # ਮਨਜ਼ੂਰੀ ਨੀਤੀ: ਇਸ ਵਾਰੀ ਸਿਰਫ "never" ਸਹਿਯੋਗਤ ਹੈ
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
            instructions="ਤੁਸੀਂ ਮਾਇਕ੍ਰੋਸਾਫਟ ਦਸਤਾਵੇਜ਼ੀਕਰਨ ਵਿੱਚ ਮੁਹਾਰਤ ਰੱਖਣ ਵਾਲਾ ਸਹਾਇਕ ਹੋ। ਸਹੀ ਅਤੇ ਅੱਪਡੇਟ ਜਾਣਕਾਰੀ ਲੱਭਣ ਲਈ Microsoft Learn MCP ਸਰਵਰ ਦੀ ਵਰਤੋਂ ਕਰੋ। ਹਮੇਸ਼ਾਂ ਆਪਣੇ ਸਰੋਤਾਂ ਦਾ ਹਵਾਲਾ ਦਿਓ।",
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
            content=".NET MAUI ਕੀ ਹੈ? ਇਹ Xamarin.Forms ਨਾਲ ਕਿਵੇਂ ਤੁਲਨਾ ਕਰਦਾ ਹੈ?",
        )
        print(f"Created message, message ID: {message.id}")

        # ਏਜੰਟ ਚਲਾਓ
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # ਪੂਰਾ ਹੋਣ ਦੀ ਪ੍ਰਤੀਖਾ ਕਰੋ
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # ਚਲਾਉਣ ਦੇ ਕਦਮਾਂ ਅਤੇ ਟੂਲ ਕਾਲਾਂ ਦੀ ਜਾਂਚ ਕਰੋ
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("ਟੂਲ ਕਾਲ ਵੇਰਵੇ:")
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


## ਆਮ ਸਮੱਸਿਆਵਾਂ ਅਤੇ ਹੱਲ

### 1. ਕਨੈਕਸ਼ਨ ਸਮੱਸਿਆਵਾਂ
- MCP ਸਰਵਰ URL ਦੀ ਪਹੁੰਚ ਯਕੀਨੀ ਬਣਾਓ
- ਪ੍ਰਮਾਣਿਕਤਾ ਦੇ ਕ੍ਰੈਡੈਂਸ਼ਲ ਚੈੱਕ ਕਰੋ
- ਨੈੱਟਵਰਕ ਕਨੈਕਸ਼ਨ ਦੀ ਪੁਸ਼ਟੀ ਕਰੋ

### 2. ਟੂਲ ਕਾਲ ਫੇਲ੍ਹ
- ਟੂਲ ਦਲੀਲਾਂ ਅਤੇ ਫਾਰਮੈਟਿੰਗ ਦੀ ਸਮੀਖਿਆ ਕਰੋ
- ਸਰਵਰ-ਵਿਸ਼ੇਸ਼ ਲੋੜਾਂ ਨੂੰ ਚੈੱਕ ਕਰੋ
- ਠੀਕ ਤਰ੍ਹਾਂ ਗਲਤੀ ਸੰਭਾਲਣ ਲਾਗੂ ਕਰੋ

### 3. ਕਾਰਗੁਜ਼ਾਰੀ ਸਮੱਸਿਆਵਾਂ
- ਟੂਲ ਕਾਲ ਦੀ ਆਵ੍ਰਿਤੀ ਨੂੰ ਅਨੁਕੂਲ ਬਣਾਓ
- ਜਿੱਥੇ ਜ਼ਰੂਰੀ ਹੋਵੇ ਕੈਸ਼ਿੰਗ ਲਾਗੂ ਕਰੋ
- ਸਰਵਰ ਜਵਾਬ ਸਮੇਂ ਦੀ ਨਿਗਰਾਨੀ ਕਰੋ

## ਅਗਲੇ ਕਦਮ

ਆਪਣੀ MCP ਇੰਟੀਗ੍ਰੇਸ਼ਨ ਨੂੰ ਹੋਰ ਸੁਧਾਰਨ ਲਈ:

1. **ਕਸਟਮ MCP ਸਰਵਰ ਬਣਾਓ**: ਆਪਣੀਆਂ ਖਾਸ ਡੇਟਾ ਸਰੋਤਾਂ ਲਈ MCP ਸਰਵਰ ਤਿਆਰ ਕਰੋ
2. **ਉੱਚ ਸੁਰੱਖਿਆ ਲਾਗੂ ਕਰੋ**: OAuth2 ਜਾਂ ਕਸਟਮ ਪ੍ਰਮਾਣਿਕਤਾ ਤਰੀਕੇ ਸ਼ਾਮਲ ਕਰੋ
3. **ਨਿਗਰਾਨੀ ਅਤੇ ਵਿਸ਼ਲੇਸ਼ਣ**: ਟੂਲ ਦੀ ਵਰਤੋਂ ਲਈ ਲਾਗਿੰਗ ਅਤੇ ਮਾਨੀਟਰਿੰਗ ਲਾਗੂ ਕਰੋ
4. **ਆਪਣੇ ਹੱਲ ਨੂੰ ਸਕੇਲ ਕਰੋ**: ਲੋਡ ਬੈਲੈਂਸਿੰਗ ਅਤੇ ਵੰਡੇ MCP ਸਰਵਰ ਆਰਕੀਟੈਕਚਰ ਵਿਚਾਰੋ

## ਵਾਧੂ ਸਰੋਤ

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## ਸਹਾਇਤਾ

ਵਾਧੂ ਸਹਾਇਤਾ ਅਤੇ ਸਵਾਲਾਂ ਲਈ:
- [Azure AI Foundry documentation](https://learn.microsoft.com/azure/ai-foundry/) ਦੀ ਸਮੀਖਿਆ ਕਰੋ
- [MCP community resources](https://modelcontextprotocol.io/) ਨੂੰ ਵੇਖੋ

## ਅਗਲਾ ਕੀ ਹੈ

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਵਿੱਚ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਣਸਹੀਤੀਆਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪੈਦਾਅ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਅਰਥ ਲਗਾਉਣ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।