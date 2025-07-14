<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-14T00:01:21+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "hr"
}
-->
# Integracija Model Context Protocol (MCP) s Azure AI Foundry

Ovaj vodič pokazuje kako integrirati Model Context Protocol (MCP) servere s Azure AI Foundry agentima, omogućujući snažnu orkestraciju alata i AI mogućnosti za poduzeća.

## Uvod

Model Context Protocol (MCP) je otvoreni standard koji omogućuje AI aplikacijama sigurno povezivanje s vanjskim izvorima podataka i alatima. Kada se integrira s Azure AI Foundry, MCP omogućuje agentima pristup i interakciju s različitim vanjskim uslugama, API-jima i izvorima podataka na standardiziran način.

Ova integracija spaja fleksibilnost MCP-ovog ekosustava alata s robusnim okvirom Azure AI Foundry agenata, pružajući AI rješenja razine poduzeća s opsežnim mogućnostima prilagodbe.

**Note:** Ako želite koristiti MCP u Azure AI Foundry Agent Service, trenutno su podržane samo sljedeće regije: westus, westus2, uaenorth, southindia i switzerlandnorth

## Ciljevi učenja

Na kraju ovog vodiča moći ćete:

- Razumjeti Model Context Protocol i njegove prednosti
- Postaviti MCP servere za korištenje s Azure AI Foundry agentima
- Kreirati i konfigurirati agente s MCP integracijom alata
- Implementirati praktične primjere koristeći stvarne MCP servere
- Upravljati odgovorima alata i citatima u razgovorima agenata

## Preduvjeti

Prije početka, provjerite imate li:

- Azure pretplatu s pristupom AI Foundry
- Python 3.10+ 
- Instaliran i konfiguriran Azure CLI
- Odgovarajuće dozvole za kreiranje AI resursa

## Što je Model Context Protocol (MCP)?

Model Context Protocol je standardizirani način za AI aplikacije da se povežu s vanjskim izvorima podataka i alatima. Ključne prednosti uključuju:

- **Standardizirana integracija**: Dosljedno sučelje za različite alate i usluge
- **Sigurnost**: Sigurni mehanizmi autentikacije i autorizacije
- **Fleksibilnost**: Podrška za razne izvore podataka, API-je i prilagođene alate
- **Proširivost**: Jednostavno dodavanje novih mogućnosti i integracija

## Postavljanje MCP-a s Azure AI Foundry

### 1. Konfiguracija okruženja

Prvo, postavite varijable okruženja i ovisnosti:

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
    "server_label": "unique_server_name",      # Identifikator MCP servera
    "server_url": "https://api.example.com/mcp", # MCP server endpoint
    "require_approval": "never"                 # Pravilo odobrenja: trenutno podržano samo "never"
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
        # Kreiraj agenta s MCP alatima
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
        
        # Kreiraj razgovor
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Pošalji poruku
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Pokreni agenta
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Čekaj dovršetak
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Pregledaj korake izvođenja i pozive alata
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Detalji poziva alata:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Prikaži razgovor
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## Rješavanje uobičajenih problema

### 1. Problemi s povezivanjem
- Provjerite je li MCP server URL dostupan
- Provjerite vjerodajnice za autentikaciju
- Osigurajte mrežnu povezanost

### 2. Neuspjeli pozivi alata
- Pregledajte argumente i format poziva alata
- Provjerite zahtjeve specifične za server
- Implementirajte ispravno rukovanje greškama

### 3. Problemi s performansama
- Optimizirajte učestalost poziva alata
- Koristite keširanje gdje je prikladno
- Pratite vrijeme odziva servera

## Sljedeći koraci

Za daljnje unapređenje vaše MCP integracije:

1. **Istražite prilagođene MCP servere**: Izgradite vlastite MCP servere za vlasničke izvore podataka
2. **Implementirajte naprednu sigurnost**: Dodajte OAuth2 ili prilagođene mehanizme autentikacije
3. **Praćenje i analitika**: Implementirajte zapisivanje i nadzor korištenja alata
4. **Skalirajte svoje rješenje**: Razmotrite balansiranje opterećenja i distribuirane MCP server arhitekture

## Dodatni resursi

- [Azure AI Foundry Dokumentacija](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Primjeri](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Pregled Azure AI Foundry Agenata](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Specifikacija](https://spec.modelcontextprotocol.io/)

## Podrška

Za dodatnu podršku i pitanja:
- Pregledajte [Azure AI Foundry dokumentaciju](https://learn.microsoft.com/azure/ai-foundry/)
- Provjerite [MCP zajedničke resurse](https://modelcontextprotocol.io/)

## Što slijedi

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.