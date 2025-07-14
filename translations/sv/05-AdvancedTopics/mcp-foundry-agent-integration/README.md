<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:56:39+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "sv"
}
-->
# Model Context Protocol (MCP) Integration med Azure AI Foundry

Denna guide visar hur du integrerar Model Context Protocol (MCP) servrar med Azure AI Foundry-agenter, vilket möjliggör kraftfull verktygsorkestrering och AI-lösningar för företag.

## Introduktion

Model Context Protocol (MCP) är en öppen standard som gör det möjligt för AI-applikationer att säkert ansluta till externa datakällor och verktyg. När MCP integreras med Azure AI Foundry kan agenter få tillgång till och interagera med olika externa tjänster, API:er och datakällor på ett standardiserat sätt.

Denna integration kombinerar flexibiliteten i MCP:s verktygsekosystem med Azure AI Foundrys robusta agentramverk, vilket ger företagsklassade AI-lösningar med omfattande anpassningsmöjligheter.

**Note:** Om du vill använda MCP i Azure AI Foundry Agent Service stöds för närvarande endast följande regioner: westus, westus2, uaenorth, southindia och switzerlandnorth

## Lärandemål

Efter att ha gått igenom denna guide kommer du att kunna:

- Förstå Model Context Protocol och dess fördelar
- Sätta upp MCP-servrar för användning med Azure AI Foundry-agenter
- Skapa och konfigurera agenter med MCP-verktygsintegration
- Implementera praktiska exempel med riktiga MCP-servrar
- Hantera verktygsrespons och källhänvisningar i agentkonversationer

## Förutsättningar

Innan du börjar, se till att du har:

- Ett Azure-abonnemang med tillgång till AI Foundry
- Python 3.10+
- Azure CLI installerat och konfigurerat
- Lämpliga behörigheter för att skapa AI-resurser

## Vad är Model Context Protocol (MCP)?

Model Context Protocol är ett standardiserat sätt för AI-applikationer att ansluta till externa datakällor och verktyg. Viktiga fördelar inkluderar:

- **Standardiserad integration**: Enhetligt gränssnitt över olika verktyg och tjänster
- **Säkerhet**: Säker autentisering och auktorisering
- **Flexibilitet**: Stöd för olika datakällor, API:er och anpassade verktyg
- **Utbyggbarhet**: Lätt att lägga till nya funktioner och integrationer

## Konfigurera MCP med Azure AI Foundry

### 1. Miljökonfiguration

Börja med att ställa in dina miljövariabler och beroenden:

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
        instructions="Du är en hjälpsam assistent. Använd de tillgängliga verktygen för att besvara frågor. Var noga med att ange dina källor.",
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
    print(f"Agent skapad, agent-ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identifierare för MCP-servern
    "server_url": "https://api.example.com/mcp", # MCP-serverns slutpunkt
    "require_approval": "never"                 # Godkännande-policy: stöder för närvarande endast "never"
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
        # Skapa agent med MCP-verktyg
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Du är en hjälpsam assistent specialiserad på Microsoft-dokumentation. Använd Microsoft Learn MCP-servern för att söka efter korrekt och uppdaterad information. Ange alltid dina källor.",
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
        print(f"Agent skapad, agent-ID: {agent.id}")    
        
        # Skapa konversations-tråd
        thread = project_client.agents.threads.create()
        print(f"Tråd skapad, tråd-ID: {thread.id}")

        # Skicka meddelande
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Vad är .NET MAUI? Hur skiljer det sig från Xamarin.Forms?",
        )
        print(f"Meddelande skapat, meddelande-ID: {message.id}")

        # Kör agenten
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Vänta på att körningen ska slutföras
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Körningsstatus: {run.status}")

        # Granska körningssteg och verktygsanrop
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Körningssteg: {step.id}, status: {step.status}, typ: {step.type}")
            if step.type == "tool_calls":
                print("Detaljer om verktygsanrop:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Visa konversation
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Felsökning av vanliga problem

### 1. Anslutningsproblem
- Kontrollera att MCP-serverns URL är åtkomlig
- Kontrollera autentiseringsuppgifter
- Säkerställ nätverksanslutning

### 2. Fel vid verktygsanrop
- Granska verktygsargument och formatering
- Kontrollera serverns specifika krav
- Implementera korrekt felhantering

### 3. Prestandaproblem
- Optimera frekvensen av verktygsanrop
- Använd caching där det är lämpligt
- Övervaka serverns svarstider

## Nästa steg

För att ytterligare förbättra din MCP-integration:

1. **Utforska egna MCP-servrar**: Bygg egna MCP-servrar för proprietära datakällor
2. **Implementera avancerad säkerhet**: Lägg till OAuth2 eller anpassade autentiseringsmekanismer
3. **Övervakning och analys**: Implementera loggning och övervakning av verktygsanvändning
4. **Skalning av lösningen**: Överväg lastbalansering och distribuerade MCP-serverarkitekturer

## Ytterligare resurser

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## Support

För ytterligare support och frågor:
- Granska [Azure AI Foundry-dokumentationen](https://learn.microsoft.com/azure/ai-foundry/)
- Kolla in [MCP community resources](https://modelcontextprotocol.io/)

## Vad händer härnäst

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, vänligen observera att automatiska översättningar kan innehålla fel eller brister. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för några missförstånd eller feltolkningar som uppstår till följd av användningen av denna översättning.