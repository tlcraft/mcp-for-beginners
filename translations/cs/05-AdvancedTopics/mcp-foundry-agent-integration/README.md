<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:20:00+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "cs"
}
-->
# Integrace Model Context Protocol (MCP) s Azure AI Foundry

Tento průvodce ukazuje, jak integrovat servery Model Context Protocol (MCP) s agenty Azure AI Foundry, což umožňuje pokročilou orchestraci nástrojů a podnikové AI funkce.

## Úvod

Model Context Protocol (MCP) je otevřený standard, který umožňuje AI aplikacím bezpečně se připojovat k externím zdrojům dat a nástrojům. Po integraci s Azure AI Foundry umožňuje MCP agentům přístup a interakci s různými externími službami, API a zdroji dat jednotným způsobem.

Tato integrace kombinuje flexibilitu ekosystému nástrojů MCP s robustním rámcem agentů Azure AI Foundry, čímž poskytuje podniková AI řešení s rozsáhlými možnostmi přizpůsobení.

**Note:** Pokud chcete používat MCP v Azure AI Foundry Agent Service, v současné době jsou podporovány pouze tyto regiony: westus, westus2, uaenorth, southindia a switzerlandnorth

## Výukové cíle

Po dokončení tohoto průvodce budete umět:

- Pochopit Model Context Protocol a jeho výhody
- Nastavit servery MCP pro použití s agenty Azure AI Foundry
- Vytvořit a nakonfigurovat agenty s integrací nástrojů MCP
- Implementovat praktické příklady s reálnými MCP servery
- Zpracovávat odpovědi nástrojů a citace v konverzacích agentů

## Požadavky

Před začátkem se ujistěte, že máte:

- Azure předplatné s přístupem k AI Foundry
- Python 3.10 a vyšší
- Nainstalovaný a nakonfigurovaný Azure CLI
- Odpovídající oprávnění pro vytváření AI zdrojů

## Co je Model Context Protocol (MCP)?

Model Context Protocol je standardizovaný způsob, jak mohou AI aplikace přistupovat k externím zdrojům dat a nástrojům. Mezi klíčové výhody patří:

- **Standardizovaná integrace**: Konzistentní rozhraní napříč různými nástroji a službami
- **Bezpečnost**: Bezpečné mechanismy autentizace a autorizace
- **Flexibilita**: Podpora různých zdrojů dat, API a vlastních nástrojů
- **Rozšiřitelnost**: Snadné přidávání nových funkcí a integrací

## Nastavení MCP s Azure AI Foundry

### 1. Konfigurace prostředí

Nejprve nastavte své proměnné prostředí a závislosti:

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
        instructions="Jste užitečný asistent. Používejte dostupné nástroje k odpovídání na otázky. Nezapomeňte uvádět zdroje.",
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
    print(f"Vytvořen agent, ID agenta: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identifikátor MCP serveru
    "server_url": "https://api.example.com/mcp", # Koncový bod MCP serveru
    "require_approval": "never"                 # Politika schvalování: zatím podporováno pouze "never"
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
        # Vytvoření agenta s MCP nástroji
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Jste užitečný asistent specializující se na dokumentaci Microsoftu. Použijte MCP server Microsoft Learn pro vyhledávání přesných a aktuálních informací. Vždy uvádějte zdroje.",
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
        print(f"Vytvořen agent, ID agenta: {agent.id}")    
        
        # Vytvoření vlákna konverzace
        thread = project_client.agents.threads.create()
        print(f"Vytvořeno vlákno, ID vlákna: {thread.id}")

        # Odeslání zprávy
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Co je to .NET MAUI? Jak se srovnává s Xamarin.Forms?",
        )
        print(f"Vytvořena zpráva, ID zprávy: {message.id}")

        # Spuštění agenta
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Čekání na dokončení
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Stav spuštění: {run.status}")

        # Prohlédnutí kroků spuštění a volání nástrojů
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Krok spuštění: {step.id}, stav: {step.status}, typ: {step.type}")
            if step.type == "tool_calls":
                print("Detaily volání nástrojů:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Zobrazení konverzace
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## Řešení běžných problémů

### 1. Problémy s připojením
- Ověřte, že je URL MCP serveru dostupná
- Zkontrolujte autentizační údaje
- Ujistěte se o funkční síťové konektivitě

### 2. Chyby při volání nástrojů
- Zkontrolujte argumenty a formátování volání nástrojů
- Prověřte specifické požadavky serveru
- Implementujte správné zpracování chyb

### 3. Problémy s výkonem
- Optimalizujte frekvenci volání nástrojů
- Použijte cache tam, kde je to vhodné
- Sledujte dobu odezvy serveru

## Další kroky

Pro další rozšíření integrace MCP:

1. **Prozkoumejte vlastní MCP servery**: Vytvořte si vlastní MCP servery pro proprietární zdroje dat
2. **Implementujte pokročilou bezpečnost**: Přidejte OAuth2 nebo vlastní autentizační mechanismy
3. **Monitorování a analýzy**: Zavádějte logování a sledování využití nástrojů
4. **Škálování řešení**: Zvažte load balancing a distribuovanou architekturu MCP serverů

## Další zdroje

- [Dokumentace Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Ukázky Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Přehled agentů Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Specifikace MCP](https://spec.modelcontextprotocol.io/)

## Podpora

Pro další podporu a dotazy:
- Prohlédněte si [dokumentaci Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Navštivte [komunitní zdroje MCP](https://modelcontextprotocol.io/)

## Co dál

- [6. Přispění komunity](../../06-CommunityContributions/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo mylné výklady vyplývající z použití tohoto překladu.