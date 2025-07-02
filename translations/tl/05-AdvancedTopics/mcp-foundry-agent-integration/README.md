<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:18:55+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "tl"
}
-->
# Model Context Protocol (MCP) Integrasyon sa Azure AI Foundry

Ipinapakita ng gabay na ito kung paano i-integrate ang Model Context Protocol (MCP) servers sa Azure AI Foundry agents, na nagbibigay-daan sa makapangyarihang tool orchestration at enterprise AI capabilities.

## Panimula

Ang Model Context Protocol (MCP) ay isang bukas na pamantayan na nagpapahintulot sa mga AI application na ligtas na kumonekta sa mga panlabas na pinagkukunan ng data at mga tool. Kapag na-integrate sa Azure AI Foundry, pinapayagan ng MCP ang mga agent na ma-access at makipag-ugnayan sa iba't ibang panlabas na serbisyo, API, at pinagkukunan ng data sa isang standardized na paraan.

Pinagsasama ng integrasyong ito ang kakayahang umangkop ng MCP tool ecosystem at ang matibay na agent framework ng Azure AI Foundry, na nagbibigay ng enterprise-grade AI solutions na may malawak na kakayahan sa pagpapasadya.

**Note:** Kung nais mong gamitin ang MCP sa Azure AI Foundry Agent Service, sa kasalukuyan suportado lamang ang mga sumusunod na rehiyon: westus, westus2, uaenorth, southindia at switzerlandnorth

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng gabay na ito, magagawa mong:

- Maunawaan ang Model Context Protocol at ang mga benepisyo nito
- Mag-set up ng MCP servers para magamit kasama ang Azure AI Foundry agents
- Gumawa at mag-configure ng mga agent na may MCP tool integration
- Magpatupad ng mga praktikal na halimbawa gamit ang totoong MCP servers
- Pamahalaan ang mga tugon ng tool at mga citation sa mga pag-uusap ng agent

## Mga Kinakailangan

Bago magsimula, tiyaking mayroon ka ng:

- Isang Azure subscription na may access sa AI Foundry
- Python 3.10+
- Azure CLI na naka-install at naka-configure
- Angkop na mga pahintulot para gumawa ng AI resources

## Ano ang Model Context Protocol (MCP)?

Ang Model Context Protocol ay isang standardized na paraan para sa mga AI application na kumonekta sa mga panlabas na pinagkukunan ng data at mga tool. Ilan sa mga pangunahing benepisyo nito ay:

- **Standardized Integration**: Pare-parehong interface sa iba't ibang tool at serbisyo
- **Security**: Ligtas na mga mekanismo ng authentication at authorization
- **Flexibility**: Suporta para sa iba't ibang pinagkukunan ng data, API, at custom na mga tool
- **Extensibility**: Madaling magdagdag ng mga bagong kakayahan at integrasyon

## Pag-setup ng MCP sa Azure AI Foundry

### 1. Pag-configure ng Kapaligiran

Una, i-setup ang iyong mga environment variable at mga dependencies:

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
        instructions="Ikaw ay isang matulunging assistant. Gamitin ang mga ibinigay na tool para sagutin ang mga tanong. Siguraduhing banggitin ang iyong mga pinagkunan.",
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
    "server_label": "unique_server_name",      # Identifier para sa MCP server
    "server_url": "https://api.example.com/mcp", # Endpoint ng MCP server
    "require_approval": "never"                 # Patakaran sa approval: sa ngayon suportado lamang ang "never"
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
        # Gumawa ng agent na may MCP tools
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Ikaw ay isang matulunging assistant na dalubhasa sa Microsoft documentation. Gamitin ang Microsoft Learn MCP server para maghanap ng tumpak at napapanahong impormasyon. Laging banggitin ang iyong mga pinagkunan.",
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
        
        # Gumawa ng conversation thread
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Magpadala ng mensahe
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Ano ang .NET MAUI? Paano ito ikinumpara sa Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Patakbuhin ang agent
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Hintayin ang pagkumpleto
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Suriin ang mga hakbang ng run at mga tawag sa tool
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Mga detalye ng tool call:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Ipakita ang pag-uusap
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## Pag-aayos ng Karaniwang Mga Isyu

### 1. Mga Isyu sa Koneksyon
- Siguraduhing naa-access ang MCP server URL
- Suriin ang mga kredensyal sa authentication
- Tiyakin ang koneksyon sa network

### 2. Mga Pagkabigo sa Tawag ng Tool
- Suriin ang mga argumento at format ng tool
- Tingnan ang mga espesipikong kinakailangan ng server
- Magpatupad ng tamang error handling

### 3. Mga Isyu sa Performance
- I-optimize ang dalas ng tawag sa tool
- Gumamit ng caching kung kinakailangan
- Bantayan ang oras ng tugon ng server

## Mga Susunod na Hakbang

Para lalo pang pagandahin ang iyong MCP integration:

1. **Tuklasin ang Custom MCP Servers**: Gumawa ng sarili mong MCP servers para sa mga proprietary na pinagkukunan ng data
2. **Magpatupad ng Advanced Security**: Magdagdag ng OAuth2 o custom na mekanismo ng authentication
3. **Subaybayan at Gumawa ng Analytics**: Magpatupad ng logging at monitoring para sa paggamit ng tool
4. **Palawakin ang Iyong Solusyon**: Isaalang-alang ang load balancing at distributed MCP server architectures

## Karagdagang Mga Sanggunian

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## Suporta

Para sa karagdagang suporta at mga tanong:
- Suriin ang [Azure AI Foundry documentation](https://learn.microsoft.com/azure/ai-foundry/)
- Tingnan ang [MCP community resources](https://modelcontextprotocol.io/)

## Ano ang susunod

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama't nagsusumikap kami na maging tumpak, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.