<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:55:09+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "it"
}
-->
# Integrazione del Model Context Protocol (MCP) con Azure AI Foundry

Questa guida mostra come integrare i server Model Context Protocol (MCP) con gli agenti di Azure AI Foundry, abilitando potenti orchestrazioni di strumenti e funzionalità AI aziendali.

## Introduzione

Model Context Protocol (MCP) è uno standard aperto che consente alle applicazioni AI di connettersi in modo sicuro a fonti di dati esterne e strumenti. Integrato con Azure AI Foundry, MCP permette agli agenti di accedere e interagire con vari servizi esterni, API e fonti di dati in modo standardizzato.

Questa integrazione unisce la flessibilità dell’ecosistema di strumenti MCP con il solido framework agenti di Azure AI Foundry, offrendo soluzioni AI di livello enterprise con ampie possibilità di personalizzazione.

**Nota:** Se vuoi usare MCP nel servizio Azure AI Foundry Agent, attualmente sono supportate solo le seguenti regioni: westus, westus2, uaenorth, southindia e switzerlandnorth

## Obiettivi di apprendimento

Al termine di questa guida, sarai in grado di:

- Comprendere il Model Context Protocol e i suoi vantaggi
- Configurare server MCP per l’uso con agenti Azure AI Foundry
- Creare e configurare agenti con integrazione di strumenti MCP
- Implementare esempi pratici utilizzando server MCP reali
- Gestire risposte degli strumenti e citazioni nelle conversazioni degli agenti

## Prerequisiti

Prima di iniziare, assicurati di avere:

- Un abbonamento Azure con accesso a AI Foundry
- Python 3.10+ 
- Azure CLI installata e configurata
- Permessi adeguati per creare risorse AI

## Cos’è il Model Context Protocol (MCP)?

Model Context Protocol è un metodo standardizzato per le applicazioni AI per connettersi a fonti di dati esterne e strumenti. I principali vantaggi includono:

- **Integrazione standardizzata**: Interfaccia coerente tra diversi strumenti e servizi
- **Sicurezza**: Meccanismi sicuri di autenticazione e autorizzazione
- **Flessibilità**: Supporto per varie fonti dati, API e strumenti personalizzati
- **Estendibilità**: Facile aggiunta di nuove funzionalità e integrazioni

## Configurazione di MCP con Azure AI Foundry

### 1. Configurazione dell’ambiente

Per prima cosa, configura le variabili d’ambiente e le dipendenze:

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
        instructions="Sei un assistente utile. Usa gli strumenti forniti per rispondere alle domande. Assicurati di citare le tue fonti.",
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
    print(f"Agente creato, ID agente: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identificatore per il server MCP
    "server_url": "https://api.example.com/mcp", # Endpoint del server MCP
    "require_approval": "never"                 # Politica di approvazione: attualmente supporta solo "never"
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
        # Crea agente con strumenti MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Sei un assistente utile specializzato nella documentazione Microsoft. Usa il server MCP di Microsoft Learn per cercare informazioni accurate e aggiornate. Cita sempre le tue fonti.",
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
        print(f"Agente creato, ID agente: {agent.id}")    
        
        # Crea thread di conversazione
        thread = project_client.agents.threads.create()
        print(f"Thread creato, ID thread: {thread.id}")

        # Invia messaggio
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Cos’è .NET MAUI? Come si confronta con Xamarin.Forms?",
        )
        print(f"Messaggio creato, ID messaggio: {message.id}")

        # Esegui l’agente
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Controlla lo stato fino al completamento
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Stato esecuzione: {run.status}")

        # Esamina i passaggi dell’esecuzione e le chiamate agli strumenti
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Passaggio esecuzione: {step.id}, stato: {step.status}, tipo: {step.type}")
            if step.type == "tool_calls":
                print("Dettagli chiamata strumento:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Mostra la conversazione
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## Risoluzione dei problemi comuni

### 1. Problemi di connessione
- Verifica che l’URL del server MCP sia accessibile
- Controlla le credenziali di autenticazione
- Assicurati della connettività di rete

### 2. Fallimenti nelle chiamate agli strumenti
- Controlla gli argomenti e il formato delle chiamate agli strumenti
- Verifica i requisiti specifici del server
- Implementa una corretta gestione degli errori

### 3. Problemi di prestazioni
- Ottimizza la frequenza delle chiamate agli strumenti
- Implementa caching dove appropriato
- Monitora i tempi di risposta del server

## Passi successivi

Per migliorare ulteriormente l’integrazione MCP:

1. **Esplora server MCP personalizzati**: Crea i tuoi server MCP per fonti dati proprietarie
2. **Implementa sicurezza avanzata**: Aggiungi OAuth2 o meccanismi di autenticazione personalizzati
3. **Monitoraggio e analisi**: Implementa logging e monitoraggio sull’uso degli strumenti
4. **Scala la tua soluzione**: Valuta bilanciamento del carico e architetture distribuite per i server MCP

## Risorse aggiuntive

- [Documentazione Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Esempi Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Panoramica agenti Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Specifiche MCP](https://spec.modelcontextprotocol.io/)

## Supporto

Per ulteriore supporto e domande:
- Consulta la [documentazione Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Verifica le [risorse della community MCP](https://modelcontextprotocol.io/)

## Cosa c’è dopo

- [6. Contributi della community](../../06-CommunityContributions/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.