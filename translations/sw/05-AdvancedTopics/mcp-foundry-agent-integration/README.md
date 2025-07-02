<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:19:15+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "sw"
}
-->
# Muungano wa Model Context Protocol (MCP) na Azure AI Foundry

Mwongozo huu unaonyesha jinsi ya kuunganisha seva za Model Context Protocol (MCP) na mawakala wa Azure AI Foundry, kuruhusu upangaji mzuri wa zana na uwezo wa AI kwa biashara.

## Utangulizi

Model Context Protocol (MCP) ni kiwango wazi kinachowezesha programu za AI kuungana kwa usalama na vyanzo vya data na zana za nje. Inapounganishwa na Azure AI Foundry, MCP inaruhusu mawakala kupata na kuingiliana na huduma mbalimbali za nje, API, na vyanzo vya data kwa njia iliyo sanifu.

Muungano huu unaunganisha unyumbufu wa mfumo wa zana za MCP na mfumo thabiti wa mawakala wa Azure AI Foundry, ukitoa suluhisho za AI za kiwango cha biashara zenye uwezo mkubwa wa kubinafsisha.

**Note:** Ikiwa unataka kutumia MCP katika Azure AI Foundry Agent Service, kwa sasa maeneo yafuatayo tu yanasaidiwa: westus, westus2, uaenorth, southindia na switzerlandnorth

## Malengo ya Kujifunza

Mwisho wa mwongozo huu, utaweza:

- Kuelewa Model Context Protocol na faida zake
- Kusanidi seva za MCP kwa matumizi na mawakala wa Azure AI Foundry
- Kuunda na kusanidi mawakala kwa muungano wa zana za MCP
- Kutekeleza mifano halisi ukitumia seva halisi za MCP
- Kushughulikia majibu ya zana na marejeo katika mazungumzo ya mawakala

## Mahitaji ya Awali

Kabla ya kuanza, hakikisha una:

- Usajili wa Azure unaopata huduma ya AI Foundry
- Python 3.10+
- Azure CLI imewekwa na kusanidiwa
- Ruhusa zinazofaa za kuunda rasilimali za AI

## Model Context Protocol (MCP) ni Nini?

Model Context Protocol ni njia iliyo sanifu kwa programu za AI kuungana na vyanzo vya data na zana za nje. Faida kuu ni:

- **Muungano Sanifu**: Kiolesura cha kuaminika kati ya zana na huduma tofauti
- **Usalama**: Mbinu salama za uthibitishaji na idhini
- **Unyumbufu**: Msaada kwa vyanzo mbalimbali vya data, API, na zana maalum
- **Uwezo wa Kuongezeka**: Rahisi kuongeza uwezo mpya na muungano

## Kusanidi MCP na Azure AI Foundry

### 1. Usanidi wa Mazingira

Kwanza, weka vigezo vya mazingira na utegemezi:

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
        instructions="Wewe ni msaidizi mkarimu. Tumia zana zilizotolewa kujibu maswali. Hakikisha unataja vyanzo vyako.",
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
    "server_label": "unique_server_name",      # Kitambulisho cha seva ya MCP
    "server_url": "https://api.example.com/mcp", # Anuani ya seva ya MCP
    "require_approval": "never"                 # Sera ya idhini: kwa sasa inasaidia tu "never"
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
        # Unda wakala kwa kutumia zana za MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Wewe ni msaidizi mkarimu mtaalamu wa nyaraka za Microsoft. Tumia seva ya MCP ya Microsoft Learn kutafuta taarifa sahihi na za kisasa. Daima taja vyanzo vyako.",
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
        
        # Unda mfululizo wa mazungumzo
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Tuma ujumbe
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Ni nini .NET MAUI? Inalinganishwaje na Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Endesha wakala
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Subiri kukamilika
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Angalia hatua za utekelezaji na simu za zana
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Maelezo ya simu za zana:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Onyesha mazungumzo
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Kutatua Matatizo Yanayojirudia

### 1. Matatizo ya Muunganisho
- Hakikisha URL ya seva ya MCP inapatikana
- Kagua vyeti vya uthibitishaji
- Hakikisha muunganisho wa mtandao uko sawa

### 2. Kushindwa kwa Simu za Zana
- Angalia hoja na muundo wa simu za zana
- Kagua mahitaji maalum ya seva
- Tekeleza usimamizi mzuri wa makosa

### 3. Matatizo ya Utendaji
- Boresha mara ya simu za zana
- Tumia caching inapofaa
- Fuatilia muda wa majibu ya seva

## Hatua Zifuatazo

Ili kuboresha muungano wako wa MCP:

1. **Chunguza Seva Maalum za MCP**: Jenga seva zako za MCP kwa vyanzo vya data vya kipekee
2. **Tekeleza Usalama wa Juu**: Ongeza OAuth2 au mbinu maalum za uthibitishaji
3. **Fuatilia na Uchambuzi**: Tekeleza ufuatiliaji na uchambuzi wa matumizi ya zana
4. **Panua Suluhisho Lako**: Fikiria usawazishaji mzigo na usanifu wa seva za MCP zilizoenea

## Rasilimali Zaidi

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## Msaada

Kwa msaada zaidi na maswali:
- Pitia [nyaraka za Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Angalia [rasilimali za jamii ya MCP](https://modelcontextprotocol.io/)

## Nini Kifuatacho

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Kielelezo cha Majukumu**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati asilia katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inashauriwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.