<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:50:21+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "de"
}
-->
# Model Context Protocol (MCP) Integration mit Azure AI Foundry

Dieser Leitfaden zeigt, wie Model Context Protocol (MCP)-Server mit Azure AI Foundry-Agenten integriert werden, um leistungsstarke Tool-Orchestrierung und Enterprise-KI-Funktionen zu ermöglichen.

## Einführung

Model Context Protocol (MCP) ist ein offener Standard, der es KI-Anwendungen ermöglicht, sicher auf externe Datenquellen und Tools zuzugreifen. In Kombination mit Azure AI Foundry erlaubt MCP Agenten, auf verschiedene externe Dienste, APIs und Datenquellen auf standardisierte Weise zuzugreifen und mit ihnen zu interagieren.

Diese Integration verbindet die Flexibilität des MCP-Tool-Ökosystems mit dem robusten Agenten-Framework von Azure AI Foundry und bietet so KI-Lösungen auf Unternehmensniveau mit umfangreichen Anpassungsmöglichkeiten.

**Note:** Wenn Sie MCP im Azure AI Foundry Agent Service verwenden möchten, werden derzeit nur die folgenden Regionen unterstützt: westus, westus2, uaenorth, southindia und switzerlandnorth

## Lernziele

Am Ende dieses Leitfadens werden Sie in der Lage sein:

- Das Model Context Protocol und seine Vorteile zu verstehen
- MCP-Server für die Verwendung mit Azure AI Foundry-Agenten einzurichten
- Agenten mit MCP-Tool-Integration zu erstellen und zu konfigurieren
- Praktische Beispiele mit echten MCP-Servern umzusetzen
- Werkzeugantworten und Quellenangaben in Agentenkonversationen zu verarbeiten

## Voraussetzungen

Bevor Sie beginnen, stellen Sie sicher, dass Sie Folgendes haben:

- Ein Azure-Abonnement mit Zugriff auf AI Foundry
- Python 3.10+
- Azure CLI installiert und konfiguriert
- Die erforderlichen Berechtigungen zum Erstellen von KI-Ressourcen

## Was ist Model Context Protocol (MCP)?

Model Context Protocol ist eine standardisierte Methode, mit der KI-Anwendungen eine Verbindung zu externen Datenquellen und Tools herstellen können. Wichtige Vorteile sind:

- **Standardisierte Integration**: Einheitliche Schnittstelle über verschiedene Tools und Dienste hinweg
- **Sicherheit**: Sichere Authentifizierungs- und Autorisierungsmechanismen
- **Flexibilität**: Unterstützung verschiedener Datenquellen, APIs und benutzerdefinierter Tools
- **Erweiterbarkeit**: Einfache Erweiterung um neue Funktionen und Integrationen

## Einrichtung von MCP mit Azure AI Foundry

### 1. Umgebungskonfiguration

Richten Sie zunächst Ihre Umgebungsvariablen und Abhängigkeiten ein:

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
    "server_label": "unique_server_name",      # Bezeichner für den MCP-Server
    "server_url": "https://api.example.com/mcp", # MCP-Server-Endpunkt
    "require_approval": "never"                 # Genehmigungsrichtlinie: derzeit nur "never" unterstützt
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
        # Agent mit MCP-Tools erstellen
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
        
        # Konversations-Thread erstellen
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Nachricht senden
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Agent ausführen
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Auf Abschluss warten
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Lauf-Schritte und Tool-Aufrufe prüfen
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Details der Tool-Aufrufe:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Konversation anzeigen
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
```

## Häufige Probleme und deren Behebung

### 1. Verbindungsprobleme
- Überprüfen Sie, ob die MCP-Server-URL erreichbar ist
- Prüfen Sie die Authentifizierungsdaten
- Stellen Sie sicher, dass die Netzwerkverbindung besteht

### 2. Fehler bei Tool-Aufrufen
- Überprüfen Sie die Argumente und das Format der Tool-Aufrufe
- Beachten Sie server-spezifische Anforderungen
- Implementieren Sie eine geeignete Fehlerbehandlung

### 3. Leistungsprobleme
- Optimieren Sie die Häufigkeit der Tool-Aufrufe
- Nutzen Sie Caching, wo sinnvoll
- Überwachen Sie die Antwortzeiten des Servers

## Nächste Schritte

Um Ihre MCP-Integration weiter zu verbessern:

1. **Eigene MCP-Server entwickeln**: Erstellen Sie eigene MCP-Server für proprietäre Datenquellen
2. **Erweiterte Sicherheit implementieren**: Fügen Sie OAuth2 oder benutzerdefinierte Authentifizierungsmechanismen hinzu
3. **Überwachung und Analyse**: Implementieren Sie Logging und Monitoring für die Tool-Nutzung
4. **Skalierung Ihrer Lösung**: Berücksichtigen Sie Lastverteilung und verteilte MCP-Server-Architekturen

## Zusätzliche Ressourcen

- [Azure AI Foundry Dokumentation](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol Beispiele](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry Agents Übersicht](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP Spezifikation](https://spec.modelcontextprotocol.io/)

## Support

Für weitere Unterstützung und Fragen:
- Lesen Sie die [Azure AI Foundry Dokumentation](https://learn.microsoft.com/azure/ai-foundry/)
- Schauen Sie in die [MCP Community-Ressourcen](https://modelcontextprotocol.io/)

## Was kommt als Nächstes

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.