<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:59:55+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "cs"
}
-->
# Integrace Model Context Protocol (MCP) s Azure AI Foundry

Tento průvodce ukazuje, jak integrovat servery Model Context Protocol (MCP) s agenty Azure AI Foundry, což umožňuje pokročilou orchestraci nástrojů a podnikové AI funkce.

## Úvod

Model Context Protocol (MCP) je otevřený standard, který umožňuje AI aplikacím bezpečně se připojit k externím datovým zdrojům a nástrojům. Po integraci s Azure AI Foundry umožňuje MCP agentům přístup a interakci s různými externími službami, API a datovými zdroji jednotným způsobem.

Tato integrace kombinuje flexibilitu ekosystému nástrojů MCP s robustním rámcem agentů Azure AI Foundry, čímž poskytuje podniková AI řešení s rozsáhlými možnostmi přizpůsobení.

**Note:** Pokud chcete používat MCP v Azure AI Foundry Agent Service, aktuálně jsou podporovány pouze následující regiony: westus, westus2, uaenorth, southindia a switzerlandnorth

## Cíle učení

Na konci tohoto průvodce budete schopni:

- Pochopit Model Context Protocol a jeho výhody
- Nastavit MCP servery pro použití s agenty Azure AI Foundry
- Vytvořit a nakonfigurovat agenty s integrací MCP nástrojů
- Implementovat praktické příklady s reálnými MCP servery
- Zpracovávat odpovědi nástrojů a citace v konverzacích agentů

## Požadavky

Před začátkem se ujistěte, že máte:

- Azure předplatné s přístupem k AI Foundry
- Python 3.10 a vyšší
- Nainstalovaný a nakonfigurovaný Azure CLI
- Odpovídající oprávnění pro vytváření AI zdrojů

## Co je Model Context Protocol (MCP)?

Model Context Protocol je standardizovaný způsob, jak mohou AI aplikace přistupovat k externím datovým zdrojům a nástrojům. Mezi hlavní výhody patří:

- **Standardizovaná integrace**: Konzistentní rozhraní napříč různými nástroji a službami
- **Bezpečnost**: Bezpečné mechanismy autentizace a autorizace
- **Flexibilita**: Podpora různých datových zdrojů, API a vlastních nástrojů
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
    print(f"Agent vytvořen, ID agenta: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identifikátor MCP serveru
    "server_url": "https://api.example.com/mcp", # Endpoint MCP serveru
    "require_approval": "never"                 # Politika schvalování: momentálně podporováno pouze "never"
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
            instructions="Jste užitečný asistent specializující se na dokumentaci Microsoftu. Používejte MCP server Microsoft Learn k vyhledávání přesných a aktuálních informací. Vždy uvádějte zdroje.",
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
        print(f"Agent vytvořen, ID agenta: {agent.id}")    
        
        # Vytvoření vlákna konverzace
        thread = project_client.agents.threads.create()
        print(f"Vlákno vytvořeno, ID vlákna: {thread.id}")

        # Odeslání zprávy
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Co je .NET MAUI? Jak se liší od Xamarin.Forms?",
        )
        print(f"Zpráva vytvořena, ID zprávy: {message.id}")

        # Spuštění agenta
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Kontrola dokončení
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Stav běhu: {run.status}")

        # Prohlédnutí kroků běhu a volání nástrojů
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Krok běhu: {step.id}, stav: {step.status}, typ: {step.type}")
            if step.type == "tool_calls":
                print("Detaily volání nástroje:")
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
- Ujistěte se o síťovém připojení

### 2. Selhání volání nástrojů
- Zkontrolujte argumenty a formátování nástrojů
- Ověřte specifické požadavky serveru
- Implementujte správné zpracování chyb

### 3. Výkonové problémy
- Optimalizujte frekvenci volání nástrojů
- Použijte cache tam, kde je to vhodné
- Sledujte dobu odezvy serveru

## Další kroky

Pro další vylepšení integrace MCP:

1. **Prozkoumejte vlastní MCP servery**: Vytvořte si vlastní MCP servery pro proprietární datové zdroje
2. **Implementujte pokročilou bezpečnost**: Přidejte OAuth2 nebo vlastní autentizační mechanismy
3. **Monitorování a analýzy**: Zavádějte logování a sledování využití nástrojů
4. **Škálování řešení**: Zvažte load balancing a distribuované architektury MCP serverů

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

- [6. Příspěvky komunity](../../06-CommunityContributions/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.