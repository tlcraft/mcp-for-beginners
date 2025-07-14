<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:57:45+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "nl"
}
-->
# Model Context Protocol (MCP) Integratie met Azure AI Foundry

Deze handleiding laat zien hoe je Model Context Protocol (MCP) servers integreert met Azure AI Foundry agents, waardoor krachtige toolorkestratie en enterprise AI-mogelijkheden mogelijk worden.

## Introductie

Model Context Protocol (MCP) is een open standaard die AI-toepassingen in staat stelt om veilig verbinding te maken met externe databronnen en tools. Wanneer geïntegreerd met Azure AI Foundry, kunnen agents via MCP op een gestandaardiseerde manier toegang krijgen tot en interactie hebben met diverse externe services, API's en databronnen.

Deze integratie combineert de flexibiliteit van MCP’s tool-ecosysteem met het robuuste agent-framework van Azure AI Foundry, en biedt zo enterprise-grade AI-oplossingen met uitgebreide aanpassingsmogelijkheden.

**Note:** Als je MCP wilt gebruiken in Azure AI Foundry Agent Service, worden momenteel alleen de volgende regio’s ondersteund: westus, westus2, uaenorth, southindia en switzerlandnorth

## Leerdoelen

Aan het einde van deze handleiding kun je:

- Het Model Context Protocol en de voordelen ervan begrijpen
- MCP-servers opzetten voor gebruik met Azure AI Foundry agents
- Agents aanmaken en configureren met MCP-toolintegratie
- Praktische voorbeelden implementeren met echte MCP-servers
- Omgaan met toolresponsen en bronvermeldingen in agentgesprekken

## Vereisten

Zorg voordat je begint dat je het volgende hebt:

- Een Azure-abonnement met toegang tot AI Foundry
- Python 3.10+ 
- Azure CLI geïnstalleerd en geconfigureerd
- De juiste rechten om AI-resources aan te maken

## Wat is Model Context Protocol (MCP)?

Model Context Protocol is een gestandaardiseerde manier voor AI-toepassingen om verbinding te maken met externe databronnen en tools. Belangrijke voordelen zijn:

- **Gestandaardiseerde Integratie**: Consistente interface voor verschillende tools en services
- **Beveiliging**: Veilige authenticatie- en autorisatiemechanismen
- **Flexibiliteit**: Ondersteuning voor diverse databronnen, API’s en aangepaste tools
- **Uitbreidbaarheid**: Eenvoudig nieuwe functionaliteiten en integraties toevoegen

## MCP instellen met Azure AI Foundry

### 1. Omgevingsconfiguratie

Stel eerst je omgevingsvariabelen en afhankelijkheden in:

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
        instructions="Je bent een behulpzame assistent. Gebruik de beschikbare tools om vragen te beantwoorden. Vergeet niet je bronnen te vermelden.",
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
    print(f"Agent aangemaakt, agent ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identifier voor de MCP-server
    "server_url": "https://api.example.com/mcp", # MCP-server endpoint
    "require_approval": "never"                 # Goedkeuringsbeleid: momenteel alleen "never" ondersteund
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
        # Agent aanmaken met MCP-tools
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Je bent een behulpzame assistent gespecialiseerd in Microsoft-documentatie. Gebruik de Microsoft Learn MCP-server om nauwkeurige, actuele informatie te zoeken. Vermeld altijd je bronnen.",
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
        print(f"Agent aangemaakt, agent ID: {agent.id}")    
        
        # Gesprekthread aanmaken
        thread = project_client.agents.threads.create()
        print(f"Thread aangemaakt, thread ID: {thread.id}")

        # Bericht versturen
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Wat is .NET MAUI? Hoe verhoudt het zich tot Xamarin.Forms?",
        )
        print(f"Bericht aangemaakt, bericht ID: {message.id}")

        # Agent uitvoeren
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Wachten op voltooiing
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Status run: {run.status}")

        # Run-stappen en tool-aanroepen bekijken
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run stap: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Details tool-aanroep:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Gesprek weergeven
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
```

## Veelvoorkomende problemen oplossen

### 1. Verbindingsproblemen
- Controleer of de MCP-server URL bereikbaar is
- Controleer de authenticatiegegevens
- Zorg voor een werkende netwerkverbinding

### 2. Fouten bij tool-aanroepen
- Controleer de argumenten en opmaak van de tool-aanroepen
- Bekijk server-specifieke vereisten
- Implementeer goede foutafhandeling

### 3. Prestatieproblemen
- Optimaliseer de frequentie van tool-aanroepen
- Gebruik caching waar mogelijk
- Houd de reactietijden van de server in de gaten

## Volgende stappen

Om je MCP-integratie verder te verbeteren:

1. **Verken aangepaste MCP-servers**: Bouw je eigen MCP-servers voor eigen databronnen
2. **Implementeer geavanceerde beveiliging**: Voeg OAuth2 of aangepaste authenticatiemechanismen toe
3. **Monitor en analyseer**: Implementeer logging en monitoring voor toolgebruik
4. **Schaal je oplossing**: Overweeg load balancing en gedistribueerde MCP-serverarchitecturen

## Aanvullende bronnen

- [Azure AI Foundry Documentatie](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Voorbeelden](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Overzicht Azure AI Foundry Agents](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specificatie](https://spec.modelcontextprotocol.io/)

## Ondersteuning

Voor extra ondersteuning en vragen:
- Bekijk de [Azure AI Foundry documentatie](https://learn.microsoft.com/azure/ai-foundry/)
- Raadpleeg de [MCP community resources](https://modelcontextprotocol.io/)

## Wat nu

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.