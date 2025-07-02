<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:20:42+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "ro"
}
-->
# Integrarea Model Context Protocol (MCP) cu Azure AI Foundry

Acest ghid arată cum să integrați serverele Model Context Protocol (MCP) cu agenții Azure AI Foundry, oferind astfel orchestrarea puternică a uneltelor și capabilități AI pentru mediul enterprise.

## Introducere

Model Context Protocol (MCP) este un standard deschis care permite aplicațiilor AI să se conecteze în siguranță la surse externe de date și unelte. Integrat cu Azure AI Foundry, MCP permite agenților să acceseze și să interacționeze cu diverse servicii externe, API-uri și surse de date într-un mod standardizat.

Această integrare combină flexibilitatea ecosistemului de unelte MCP cu cadrul robust al agenților Azure AI Foundry, oferind soluții AI de nivel enterprise cu capacități extinse de personalizare.

**Note:** Dacă doriți să utilizați MCP în Azure AI Foundry Agent Service, în prezent sunt suportate doar următoarele regiuni: westus, westus2, uaenorth, southindia și switzerlandnorth

## Obiective de învățare

La finalul acestui ghid, veți putea:

- Înțelege Model Context Protocol și beneficiile sale
- Configura servere MCP pentru utilizarea cu agenții Azure AI Foundry
- Crea și configura agenți cu integrare MCP pentru unelte
- Implementa exemple practice folosind servere MCP reale
- Gestiona răspunsurile uneltelor și citările în conversațiile agenților

## Cerințe preliminare

Înainte de a începe, asigurați-vă că aveți:

- Un abonament Azure cu acces la AI Foundry
- Python 3.10+ 
- Azure CLI instalat și configurat
- Permisiunile necesare pentru a crea resurse AI

## Ce este Model Context Protocol (MCP)?

Model Context Protocol este o metodă standardizată prin care aplicațiile AI se conectează la surse externe de date și unelte. Beneficiile cheie includ:

- **Integrare standardizată**: Interfață consistentă pentru diferite unelte și servicii
- **Securitate**: Mecanisme sigure de autentificare și autorizare
- **Flexibilitate**: Suport pentru diverse surse de date, API-uri și unelte personalizate
- **Extensibilitate**: Ușor de adăugat noi capabilități și integrări

## Configurarea MCP cu Azure AI Foundry

### 1. Configurarea mediului

Mai întâi, configurați variabilele de mediu și dependențele:

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
        instructions="Ești un asistent de ajutor. Folosește uneltele puse la dispoziție pentru a răspunde la întrebări. Asigură-te că citezi sursele.",
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
    print(f"Agent creat, ID agent: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identificator pentru serverul MCP
    "server_url": "https://api.example.com/mcp", # Endpoint-ul serverului MCP
    "require_approval": "never"                 # Politica de aprobare: momentan suportă doar "never"
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
        # Creare agent cu unelte MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Ești un asistent de ajutor specializat în documentația Microsoft. Folosește serverul Microsoft Learn MCP pentru a căuta informații precise și actualizate. Citează întotdeauna sursele.",
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
        print(f"Agent creat, ID agent: {agent.id}")    
        
        # Creare fir de conversație
        thread = project_client.agents.threads.create()
        print(f"Fir creat, ID fir: {thread.id}")

        # Trimitere mesaj
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Ce este .NET MAUI? Cum se compară cu Xamarin.Forms?",
        )
        print(f"Mesaj creat, ID mesaj: {message.id}")

        # Rularea agentului
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Așteptare finalizare
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Stare rulare: {run.status}")

        # Analiză pași rulare și apeluri unelte
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Pas rulare: {step.id}, stare: {step.status}, tip: {step.type}")
            if step.type == "tool_calls":
                print("Detalii apel unealtă:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Afișare conversație
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
```

## Depanarea problemelor comune

### 1. Probleme de conectare
- Verificați dacă URL-ul serverului MCP este accesibil
- Verificați credențialele de autentificare
- Asigurați conectivitatea la rețea

### 2. Eșecuri la apelurile uneltelor
- Revizuiți argumentele și formatul apelurilor uneltelor
- Verificați cerințele specifice serverului
- Implementați gestionarea corectă a erorilor

### 3. Probleme de performanță
- Optimizați frecvența apelurilor uneltelor
- Implementați caching acolo unde este cazul
- Monitorizați timpii de răspuns ai serverului

## Pașii următori

Pentru a îmbunătăți integrarea MCP:

1. **Explorați servere MCP personalizate**: Construiți propriile servere MCP pentru surse de date proprietare
2. **Implementați securitate avansată**: Adăugați OAuth2 sau mecanisme personalizate de autentificare
3. **Monitorizare și analiză**: Implementați logare și monitorizare pentru utilizarea uneltelor
4. **Scalați soluția**: Luați în considerare echilibrarea încărcării și arhitecturi distribuite pentru serverele MCP

## Resurse suplimentare

- [Documentația Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Exemple Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Prezentare generală Azure AI Foundry Agents](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Specificația MCP](https://spec.modelcontextprotocol.io/)

## Suport

Pentru suport suplimentar și întrebări:
- Consultați [documentația Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Verificați [resursele comunității MCP](https://modelcontextprotocol.io/)

## Ce urmează

- [6. Contribuții din comunitate](../../06-CommunityContributions/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original, în limba sa nativă, trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.