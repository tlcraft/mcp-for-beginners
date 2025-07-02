<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:16:23+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "da"
}
-->
# Model Context Protocol (MCP) Integration med Azure AI Foundry

Denne vejledning viser, hvordan man integrerer Model Context Protocol (MCP) servere med Azure AI Foundry agenter, hvilket muliggør kraftfuld værktøjsorkestrering og enterprise AI-funktioner.

## Introduktion

Model Context Protocol (MCP) er en åben standard, der gør det muligt for AI-applikationer sikkert at forbinde til eksterne datakilder og værktøjer. Når MCP integreres med Azure AI Foundry, kan agenter få adgang til og interagere med forskellige eksterne tjenester, API'er og datakilder på en standardiseret måde.

Denne integration kombinerer fleksibiliteten i MCP's værktøjsekosystem med Azure AI Foundrys robuste agentrammeværk og leverer enterprise-grade AI-løsninger med omfattende tilpasningsmuligheder.

**Note:** Hvis du ønsker at bruge MCP i Azure AI Foundry Agent Service, understøttes i øjeblikket kun følgende regioner: westus, westus2, uaenorth, southindia og switzerlandnorth

## Læringsmål

Når du har gennemført denne vejledning, vil du kunne:

- Forstå Model Context Protocol og dets fordele  
- Sætte MCP-servere op til brug med Azure AI Foundry agenter  
- Oprette og konfigurere agenter med MCP-værktøjsintegration  
- Implementere praktiske eksempler med rigtige MCP-servere  
- Håndtere værktøjsresponser og kildehenvisninger i agent-samtaler  

## Forudsætninger

Inden du går i gang, skal du sikre dig, at du har:

- Et Azure-abonnement med adgang til AI Foundry  
- Python 3.10+  
- Azure CLI installeret og konfigureret  
- De nødvendige tilladelser til at oprette AI-ressourcer  

## Hvad er Model Context Protocol (MCP)?

Model Context Protocol er en standardiseret måde for AI-applikationer at forbinde til eksterne datakilder og værktøjer. Nøglefordele inkluderer:

- **Standardiseret integration**: Ensartet interface på tværs af forskellige værktøjer og tjenester  
- **Sikkerhed**: Sikker autentificering og autorisationsmekanismer  
- **Fleksibilitet**: Understøttelse af forskellige datakilder, API'er og brugerdefinerede værktøjer  
- **Udvidelsesmuligheder**: Nem tilføjelse af nye funktioner og integrationer  

## Opsætning af MCP med Azure AI Foundry

### 1. Miljøkonfiguration

Start med at konfigurere dine miljøvariabler og afhængigheder:

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
        instructions="Du er en hjælpsom assistent. Brug de tilgængelige værktøjer til at besvare spørgsmål. Husk at angive dine kilder.",
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
    print(f"Oprettet agent, agent ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identifikator for MCP-serveren
    "server_url": "https://api.example.com/mcp", # MCP-server endpoint
    "require_approval": "never"                 # Godkendelsespolitik: understøtter kun "never"
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
        # Opret agent med MCP-værktøjer
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Du er en hjælpsom assistent med speciale i Microsoft-dokumentation. Brug Microsoft Learn MCP-serveren til at søge efter præcis og opdateret information. Husk altid at angive dine kilder.",
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
        print(f"Oprettet agent, agent ID: {agent.id}")    
        
        # Opret samtaletråd
        thread = project_client.agents.threads.create()
        print(f"Oprettet tråd, tråd ID: {thread.id}")

        # Send besked
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Hvad er .NET MAUI? Hvordan sammenlignes det med Xamarin.Forms?",
        )
        print(f"Oprettet besked, besked ID: {message.id}")

        # Kør agenten
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Poll for færdiggørelse
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Kørselsstatus: {run.status}")

        # Undersøg kørsels trin og værktøjsopkald
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Kørsels trin: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Detaljer om værktøjsopkald:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Vis samtale
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Fejlfinding af almindelige problemer

### 1. Forbindelsesproblemer
- Kontroller, at MCP-serverens URL er tilgængelig  
- Tjek autentificeringsoplysninger  
- Sørg for netværksforbindelse  

### 2. Fejl ved værktøjsopkald
- Gennemgå værktøjsargumenter og formatering  
- Tjek server-specifikke krav  
- Implementer korrekt fejlhåndtering  

### 3. Ydelsesproblemer
- Optimer hyppigheden af værktøjsopkald  
- Implementer caching, hvor det er relevant  
- Overvåg serverens svartider  

## Næste skridt

For at forbedre din MCP-integration yderligere:

1. **Udforsk brugerdefinerede MCP-servere**: Byg dine egne MCP-servere til proprietære datakilder  
2. **Implementer avanceret sikkerhed**: Tilføj OAuth2 eller brugerdefinerede autentificeringsmekanismer  
3. **Overvågning og analyse**: Implementer logging og overvågning af værktøjsbrug  
4. **Skalér din løsning**: Overvej load balancing og distribuerede MCP-serverarkitekturer  

## Yderligere ressourcer

- [Azure AI Foundry Dokumentation](https://learn.microsoft.com/azure/ai-foundry/)  
- [Model Context Protocol Eksempler](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)  
- [Azure AI Foundry Agenter Oversigt](https://learn.microsoft.com/azure/ai-foundry/agents/)  
- [MCP Specifikation](https://spec.modelcontextprotocol.io/)  

## Support

For yderligere support og spørgsmål:  
- Gennemgå [Azure AI Foundry dokumentationen](https://learn.microsoft.com/azure/ai-foundry/)  
- Tjek [MCP community ressourcer](https://modelcontextprotocol.io/)  


## Hvad er det næste

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.