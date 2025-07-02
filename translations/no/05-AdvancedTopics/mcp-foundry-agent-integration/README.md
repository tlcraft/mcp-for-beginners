<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:16:41+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "no"
}
-->
# Model Context Protocol (MCP) Integrasjon med Azure AI Foundry

Denne veiledningen viser hvordan du integrerer Model Context Protocol (MCP) servere med Azure AI Foundry-agenter, og dermed muliggjør kraftig verktøyorchestrering og bedriftsrettede AI-funksjoner.

## Introduksjon

Model Context Protocol (MCP) er en åpen standard som gjør det mulig for AI-applikasjoner å koble seg sikkert til eksterne datakilder og verktøy. Når MCP integreres med Azure AI Foundry, får agenter tilgang til og kan samhandle med ulike eksterne tjenester, API-er og datakilder på en standardisert måte.

Denne integrasjonen kombinerer fleksibiliteten i MCPs verktøysystem med Azure AI Foundrys robuste agentrammeverk, og gir bedriftsklare AI-løsninger med omfattende tilpasningsmuligheter.

**Note:** Hvis du ønsker å bruke MCP i Azure AI Foundry Agent Service, støttes for øyeblikket kun følgende regioner: westus, westus2, uaenorth, southindia og switzerlandnorth

## Læringsmål

Etter å ha fullført denne veiledningen vil du kunne:

- Forstå Model Context Protocol og fordelene med det
- Sette opp MCP-servere for bruk med Azure AI Foundry-agenter
- Opprette og konfigurere agenter med MCP-verktøyintegrasjon
- Implementere praktiske eksempler med ekte MCP-servere
- Håndtere verktøyrespons og kilder i agentenes samtaler

## Forutsetninger

Før du begynner, sørg for at du har:

- Et Azure-abonnement med tilgang til AI Foundry
- Python 3.10+
- Azure CLI installert og konfigurert
- Nødvendige tillatelser for å opprette AI-ressurser

## Hva er Model Context Protocol (MCP)?

Model Context Protocol er en standardisert måte for AI-applikasjoner å koble til eksterne datakilder og verktøy på. Hovedfordelene inkluderer:

- **Standardisert integrasjon**: Konsistent grensesnitt på tvers av ulike verktøy og tjenester
- **Sikkerhet**: Sikker autentisering og autorisasjon
- **Fleksibilitet**: Støtte for ulike datakilder, API-er og tilpassede verktøy
- **Utvidbarhet**: Enkel å legge til nye funksjoner og integrasjoner

## Sette opp MCP med Azure AI Foundry

### 1. Miljøkonfigurasjon

Først setter du opp miljøvariabler og avhengigheter:

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
    "server_label": "unique_server_name",      # Identifikator for MCP-serveren
    "server_url": "https://api.example.com/mcp", # MCP-server endepunkt
    "require_approval": "never"                 # Godkjenningspolicy: støtter foreløpig kun "never"
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
        # Opprett agent med MCP-verktøy
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
        
        # Opprett samtaletråd
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Send melding
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Kjør agenten
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Poll for ferdigstillelse
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Undersøk kjøretrinn og verktøysamtaler
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
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


## Feilsøking av vanlige problemer

### 1. Tilkoblingsproblemer
- Sjekk at MCP-serverens URL er tilgjengelig
- Kontroller autentiseringsinformasjon
- Sørg for nettverkstilkobling

### 2. Feil ved verktøysamtaler
- Gå gjennom argumenter og formatering for verktøyene
- Kontroller server-spesifikke krav
- Implementer riktig feilhåndtering

### 3. Ytelsesproblemer
- Optimaliser hvor ofte verktøy kalles
- Bruk caching der det er hensiktsmessig
- Overvåk responstider fra serveren

## Neste steg

For å forbedre MCP-integrasjonen ytterligere:

1. **Utforsk egne MCP-servere**: Bygg egne MCP-servere for proprietære datakilder
2. **Implementer avansert sikkerhet**: Legg til OAuth2 eller tilpassede autentiseringsmekanismer
3. **Overvåking og analyse**: Implementer logging og overvåking av verktøybruk
4. **Skaler løsningen**: Vurder lastbalansering og distribuerte MCP-serverarkitekturer

## Ytterligere ressurser

- [Azure AI Foundry Dokumentasjon](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Eksempler](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agenter Oversikt](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Spesifikasjon](https://spec.modelcontextprotocol.io/)

## Support

For ekstra støtte og spørsmål:
- Se gjennom [Azure AI Foundry dokumentasjonen](https://learn.microsoft.com/azure/ai-foundry/)
- Sjekk [MCP community resources](https://modelcontextprotocol.io/)

## Hva nå

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.