<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:12:56+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "ne"
}
-->
# Model Context Protocol (MCP) लाई Azure AI Foundry सँग एकीकृत गर्ने तरिका

यस मार्गनिर्देशनले Model Context Protocol (MCP) सर्भरहरूलाई Azure AI Foundry एजेन्टहरूसँग कसरी जोड्ने देखाउँछ, जसले शक्तिशाली टुल अर्चेस्ट्रेसन र उद्यम स्तरको AI क्षमताहरू सक्षम पार्छ।

## परिचय

Model Context Protocol (MCP) एक खुला मानक हो जसले AI अनुप्रयोगहरूलाई बाह्य डाटा स्रोतहरू र उपकरणहरूसँग सुरक्षित रूपमा जडान गर्न सक्षम बनाउँछ। Azure AI Foundry सँग एकीकृत गर्दा, MCP ले एजेन्टहरूलाई विभिन्न बाह्य सेवा, API, र डाटा स्रोतहरूसँग मानकीकृत तरिकाले पहुँच र अन्तरक्रिया गर्न अनुमति दिन्छ।

यस एकीकरणले MCP को उपकरण पारिस्थितिकी तन्त्रको लचकता र Azure AI Foundry को बलियो एजेन्ट फ्रेमवर्कलाई जोड्छ, जसले उद्यम स्तरको AI समाधानहरूलाई व्यापक अनुकूलन क्षमतासहित प्रदान गर्दछ।

**Note:** यदि तपाईं Azure AI Foundry Agent Service मा MCP प्रयोग गर्न चाहनुहुन्छ भने, हालका लागि केवल यी क्षेत्रहरू समर्थन गरिन्छ: westus, westus2, uaenorth, southindia र switzerlandnorth

## सिकाइका उद्देश्यहरू

यस मार्गनिर्देशनको अन्त्यसम्म, तपाईं सक्षम हुनुहुनेछ:

- Model Context Protocol र यसको फाइदाहरू बुझ्न
- Azure AI Foundry एजेन्टहरूसँग प्रयोग गर्न MCP सर्भरहरू सेटअप गर्न
- MCP उपकरण एकीकरणसहित एजेन्टहरू सिर्जना र कन्फिगर गर्न
- वास्तविक MCP सर्भरहरू प्रयोग गरेर व्यावहारिक उदाहरणहरू लागू गर्न
- एजेन्ट संवादहरूमा उपकरण प्रतिक्रिया र उद्धरणहरू व्यवस्थापन गर्न

## पूर्वआवश्यकताहरू

सुरु गर्नु अघि, सुनिश्चित गर्नुहोस् तपाईं सँग:

- AI Foundry पहुँच सहित Azure सदस्यता छ
- Python 3.10 वा माथि
- Azure CLI इन्स्टल र कन्फिगर गरिएको छ
- AI स्रोतहरू सिर्जना गर्ने उपयुक्त अनुमति छ

## Model Context Protocol (MCP) के हो?

Model Context Protocol AI अनुप्रयोगहरूले बाह्य डाटा स्रोत र उपकरणहरूसँग जडान गर्न प्रयोग गर्ने मानकीकृत तरिका हो। मुख्य फाइदाहरू:

- **मानकीकृत एकीकरण**: विभिन्न उपकरण र सेवाहरूमा एक समान इन्टरफेस
- **सुरक्षा**: सुरक्षित प्रमाणीकरण र प्राधिकरण संयन्त्रहरू
- **लचकता**: विभिन्न डाटा स्रोत, API, र कस्टम उपकरणहरूको समर्थन
- **विस्तारयोग्यता**: नयाँ क्षमताहरू र एकीकरणहरू सजिलै थप्न सकिने

## Azure AI Foundry सँग MCP सेटअप गर्ने तरिका

### १. वातावरण कन्फिगरेसन

पहिले, आफ्नो वातावरण भेरिएबलहरू र निर्भरताहरू सेटअप गर्नुहोस्:

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
        instructions="तपाईं एक सहयोगी सहायक हुनुहुन्छ। प्रश्नहरूको उत्तर दिनका लागि उपलब्ध उपकरणहरू प्रयोग गर्नुहोस्। आफ्नो स्रोतहरू सधैं उद्धृत गर्नुहोस्।",
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
    "server_label": "unique_server_name",      # MCP सर्भरको पहिचानकर्ता
    "server_url": "https://api.example.com/mcp", # MCP सर्भरको अन्तिम बिन्दु
    "require_approval": "never"                 # स्वीकृति नीति: हाल केवल "never" समर्थन गरिन्छ
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
        # MCP उपकरणहरूसहित एजेन्ट सिर्जना गर्नुहोस्
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="तपाईं Microsoft कागजातमा विशेषज्ञता भएको सहयोगी सहायक हुनुहुन्छ। Microsoft Learn MCP सर्भर प्रयोग गरेर सही र अद्यावधिक जानकारी खोज्नुहोस्। सधैं आफ्नो स्रोतहरू उद्धृत गर्नुहोस्।",
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
        
        # संवाद थ्रेड सिर्जना गर्नुहोस्
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # सन्देश पठाउनुहोस्
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content=".NET MAUI के हो? यो Xamarin.Forms सँग कसरी तुलना हुन्छ?",
        )
        print(f"Created message, message ID: {message.id}")

        # एजेन्ट चलाउनुहोस्
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # पूर्णता लागि पोल गर्नुहोस्
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # रन चरणहरू र उपकरण कलहरू जाँच गर्नुहोस्
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # संवाद प्रदर्शन गर्नुहोस्
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## सामान्य समस्या समाधान

### १. जडान समस्याहरू
- MCP सर्भर URL पहुँचयोग्य छ कि छैन जाँच गर्नुहोस्
- प्रमाणीकरण प्रमाणपत्रहरू जाँच गर्नुहोस्
- नेटवर्क कनेक्टिविटी सुनिश्चित गर्नुहोस्

### २. उपकरण कल असफलताहरू
- उपकरणका तर्कहरू र स्वरूप जाँच गर्नुहोस्
- सर्भर-विशेष आवश्यकताहरू जाँच गर्नुहोस्
- उचित त्रुटि ह्यान्डलिङ कार्यान्वयन गर्नुहोस्

### ३. प्रदर्शन समस्याहरू
- उपकरण कल आवृत्ति अनुकूलन गर्नुहोस्
- जहाँ उपयुक्त हो क्यासिङ लागू गर्नुहोस्
- सर्भर प्रतिक्रिया समयहरू अनुगमन गर्नुहोस्

## आगामी कदमहरू

तपाईंको MCP एकीकरणलाई अझ सुधार गर्न:

1. **कस्टम MCP सर्भरहरू अन्वेषण गर्नुहोस्**: आफ्नै MCP सर्भरहरू निर्माण गर्नुहोस् आफ्नै डाटा स्रोतहरूका लागि
2. **उन्नत सुरक्षा कार्यान्वयन गर्नुहोस्**: OAuth2 वा कस्टम प्रमाणीकरण संयन्त्रहरू थप्नुहोस्
3. **अनुगमन र विश्लेषण**: उपकरण प्रयोगका लागि लगिङ र अनुगमन लागू गर्नुहोस्
4. **तपाईंको समाधानलाई स्केल गर्नुहोस्**: लोड ब्यालेन्सिङ र वितरण गरिएको MCP सर्भर वास्तुकलाहरू विचार गर्नुहोस्

## थप स्रोतहरू

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## समर्थन

थप समर्थन र प्रश्नहरूको लागि:
- [Azure AI Foundry documentation](https://learn.microsoft.com/azure/ai-foundry/) समीक्षा गर्नुहोस्
- [MCP community resources](https://modelcontextprotocol.io/) जाँच गर्नुहोस्

## के गर्ने अर्को

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया जानकार हुनुहोस् कि स्वचालित अनुवादमा त्रुटि वा गलत अर्थ हुन सक्छ। मूल दस्तावेज यसको मूल भाषामा आधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलत बुझाइ वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।