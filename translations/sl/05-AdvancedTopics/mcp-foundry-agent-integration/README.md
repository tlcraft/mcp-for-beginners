<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-14T00:01:39+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "sl"
}
-->
# Integracija Model Context Protocol (MCP) z Azure AI Foundry

Ta vodič prikazuje, kako integrirati strežnike Model Context Protocol (MCP) z agenti Azure AI Foundry, kar omogoča zmogljivo orkestracijo orodij in podjetniške AI zmogljivosti.

## Uvod

Model Context Protocol (MCP) je odprt standard, ki omogoča AI aplikacijam varno povezavo z zunanjimi podatkovnimi viri in orodji. Ko je integriran z Azure AI Foundry, MCP agentom omogoča dostop do različnih zunanjih storitev, API-jev in podatkovnih virov na standardiziran način.

Ta integracija združuje prilagodljivost MCP ekosistema orodij z robustnim agentnim ogrodjem Azure AI Foundry, kar zagotavlja podjetniške AI rešitve z obsežnimi možnostmi prilagajanja.

**Note:** Če želite uporabljati MCP v Azure AI Foundry Agent Service, so trenutno podprte le naslednje regije: westus, westus2, uaenorth, southindia in switzerlandnorth

## Cilji učenja

Ob koncu tega vodiča boste znali:

- Razumeti Model Context Protocol in njegove prednosti
- Nastaviti MCP strežnike za uporabo z agenti Azure AI Foundry
- Ustvariti in konfigurirati agente z integracijo MCP orodij
- Izvesti praktične primere z uporabo pravih MCP strežnikov
- Obvladovati odzive orodij in navajanja v pogovorih agentov

## Predpogoji

Pred začetkom poskrbite, da imate:

- Azure naročnino z dostopom do AI Foundry
- Python 3.10 ali novejši
- Azure CLI nameščen in konfiguriran
- Ustrezna dovoljenja za ustvarjanje AI virov

## Kaj je Model Context Protocol (MCP)?

Model Context Protocol je standardiziran način, da se AI aplikacije povežejo z zunanjimi podatkovnimi viri in orodji. Ključne prednosti vključujejo:

- **Standardizirana integracija**: Enoten vmesnik za različna orodja in storitve
- **Varnost**: Varni mehanizmi za preverjanje pristnosti in avtorizacijo
- **Prilagodljivost**: Podpora za različne podatkovne vire, API-je in prilagojena orodja
- **Razširljivost**: Enostavno dodajanje novih zmogljivosti in integracij

## Nastavitev MCP z Azure AI Foundry

### 1. Konfiguracija okolja

Najprej nastavite svoje okoljske spremenljivke in odvisnosti:

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
    "server_label": "unique_server_name",      # Identifikator MCP strežnika
    "server_url": "https://api.example.com/mcp", # MCP strežniški konec
    "require_approval": "never"                 # Politika odobritve: trenutno podprto samo "never"
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
        # Ustvari agenta z MCP orodji
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
        
        # Ustvari nit pogovora
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Pošlji sporočilo
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Zaženi agenta
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Čakaj na dokončanje
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Preglej korake izvajanja in klice orodij
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Tool call details:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Prikaži pogovor
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Reševanje pogostih težav

### 1. Težave s povezavo
- Preverite, ali je MCP strežniški URL dostopen
- Preverite poverilnice za preverjanje pristnosti
- Zagotovite omrežno povezljivost

### 2. Napake pri klicih orodij
- Preglejte argumente in oblikovanje klicev orodij
- Preverite zahteve specifične za strežnik
- Uvedite ustrezno obravnavo napak

### 3. Težave z zmogljivostjo
- Optimizirajte pogostost klicev orodij
- Uporabite predpomnjenje, kjer je primerno
- Spremljajte odzivne čase strežnika

## Naslednji koraki

Za nadaljnjo izboljšavo vaše MCP integracije:

1. **Raziskujte lastne MCP strežnike**: Zgradite svoje MCP strežnike za lastne podatkovne vire
2. **Izvedite napredno varnost**: Dodajte OAuth2 ali prilagojene mehanizme preverjanja pristnosti
3. **Spremljanje in analitika**: Uvedite beleženje in spremljanje uporabe orodij
4. **Razširite svojo rešitev**: Razmislite o uravnoteženju obremenitve in distribuirani arhitekturi MCP strežnikov

## Dodatni viri

- [Azure AI Foundry Documentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Samples](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Overview](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)

## Podpora

Za dodatno podporo in vprašanja:
- Preglejte [Azure AI Foundry dokumentacijo](https://learn.microsoft.com/azure/ai-foundry/)
- Preverite [MCP skupnostne vire](https://modelcontextprotocol.io/)

## Kaj sledi

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.