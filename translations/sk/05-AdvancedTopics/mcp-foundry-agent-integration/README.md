<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-14T00:00:12+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "sk"
}
-->
# Integrácia Model Context Protocol (MCP) s Azure AI Foundry

Tento návod ukazuje, ako integrovať servery Model Context Protocol (MCP) s agentmi Azure AI Foundry, čím umožníte výkonnú orchestráciu nástrojov a podnikové AI riešenia.

## Úvod

Model Context Protocol (MCP) je otvorený štandard, ktorý umožňuje AI aplikáciám bezpečne sa pripájať k externým dátovým zdrojom a nástrojom. Po integrácii s Azure AI Foundry umožňuje MCP agentom pristupovať a interagovať s rôznymi externými službami, API a dátovými zdrojmi štandardizovaným spôsobom.

Táto integrácia spája flexibilitu ekosystému nástrojov MCP s robustným rámcom agentov Azure AI Foundry, čím poskytuje podnikové AI riešenia s rozsiahlymi možnosťami prispôsobenia.

**Note:** Ak chcete používať MCP v Azure AI Foundry Agent Service, momentálne sú podporované iba tieto regióny: westus, westus2, uaenorth, southindia a switzerlandnorth

## Ciele učenia

Na konci tohto návodu budete schopní:

- Pochopiť Model Context Protocol a jeho výhody
- Nastaviť MCP servery pre použitie s agentmi Azure AI Foundry
- Vytvoriť a nakonfigurovať agentov s integráciou MCP nástrojov
- Implementovať praktické príklady s reálnymi MCP servermi
- Spracovávať odpovede nástrojov a citácie v konverzáciách agentov

## Predpoklady

Pred začatím sa uistite, že máte:

- Predplatné Azure s prístupom k AI Foundry
- Python 3.10+
- Nainštalovaný a nakonfigurovaný Azure CLI
- Príslušné oprávnenia na vytváranie AI zdrojov

## Čo je Model Context Protocol (MCP)?

Model Context Protocol je štandardizovaný spôsob, ako sa AI aplikácie pripájajú k externým dátovým zdrojom a nástrojom. Hlavné výhody zahŕňajú:

- **Štandardizovaná integrácia**: Konzistentné rozhranie naprieč rôznymi nástrojmi a službami
- **Bezpečnosť**: Bezpečné mechanizmy autentifikácie a autorizácie
- **Flexibilita**: Podpora rôznych dátových zdrojov, API a vlastných nástrojov
- **Rozšíriteľnosť**: Jednoduché pridávanie nových funkcií a integrácií

## Nastavenie MCP s Azure AI Foundry

### 1. Konfigurácia prostredia

Najskôr nastavte svoje premenné prostredia a závislosti:

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
        instructions="Ste užitočný asistent. Používajte dostupné nástroje na odpovedanie na otázky. Nezabudnite uviesť zdroje.",
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
    print(f"Agent vytvorený, ID agenta: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identifikátor MCP servera
    "server_url": "https://api.example.com/mcp", # Koncový bod MCP servera
    "require_approval": "never"                 # Politika schvaľovania: momentálne podporované iba "never"
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
        # Vytvorenie agenta s MCP nástrojmi
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Ste užitočný asistent špecializujúci sa na dokumentáciu Microsoftu. Používajte MCP server Microsoft Learn na vyhľadávanie presných a aktuálnych informácií. Vždy uvádzajte zdroje.",
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
        print(f"Agent vytvorený, ID agenta: {agent.id}")    
        
        # Vytvorenie vlákna konverzácie
        thread = project_client.agents.threads.create()
        print(f"Vlákno vytvorené, ID vlákna: {thread.id}")

        # Odoslanie správy
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Čo je .NET MAUI? Ako sa porovnáva so Xamarin.Forms?",
        )
        print(f"Správa vytvorená, ID správy: {message.id}")

        # Spustenie agenta
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Čakanie na dokončenie
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Stav behu: {run.status}")

        # Preskúmanie krokov behu a volaní nástrojov
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Krok behu: {step.id}, stav: {step.status}, typ: {step.type}")
            if step.type == "tool_calls":
                print("Detaily volania nástroja:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Zobrazenie konverzácie
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Riešenie bežných problémov

### 1. Problémy s pripojením
- Skontrolujte, či je URL MCP servera dostupná
- Overte autentifikačné údaje
- Uistite sa o funkčnosti siete

### 2. Zlyhania volania nástrojov
- Skontrolujte argumenty a formátovanie volaní nástrojov
- Overte špecifické požiadavky servera
- Implementujte správne spracovanie chýb

### 3. Problémy s výkonom
- Optimalizujte frekvenciu volaní nástrojov
- Používajte cache tam, kde je to vhodné
- Sledujte časy odozvy servera

## Ďalšie kroky

Pre ďalšie vylepšenie integrácie MCP:

1. **Preskúmajte vlastné MCP servery**: Vytvorte si vlastné MCP servery pre proprietárne dátové zdroje
2. **Implementujte pokročilú bezpečnosť**: Pridajte OAuth2 alebo vlastné autentifikačné mechanizmy
3. **Monitorovanie a analýzy**: Zaveste logovanie a monitorovanie používania nástrojov
4. **Škálovanie riešenia**: Zvážte load balancing a distribuované architektúry MCP serverov

## Dodatočné zdroje

- [Azure AI Foundry Dokumentácia](https://learn.microsoft.com/azure/ai-foundry/)
- [Príklady Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Prehľad agentov Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Špecifikácia MCP](https://spec.modelcontextprotocol.io/)

## Podpora

Pre ďalšiu podporu a otázky:
- Prezrite si [dokumentáciu Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Skontrolujte [komunitné zdroje MCP](https://modelcontextprotocol.io/)

## Čo ďalej

- [6. Príspevky komunity](../../06-CommunityContributions/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.