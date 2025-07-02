<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:14:36+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "pl"
}
-->
# Integracja Model Context Protocol (MCP) z Azure AI Foundry

Ten przewodnik pokazuje, jak zintegrować serwery Model Context Protocol (MCP) z agentami Azure AI Foundry, umożliwiając zaawansowaną orkiestrację narzędzi i funkcje AI na poziomie przedsiębiorstwa.

## Wprowadzenie

Model Context Protocol (MCP) to otwarty standard, który pozwala aplikacjom AI bezpiecznie łączyć się z zewnętrznymi źródłami danych i narzędziami. Po integracji z Azure AI Foundry, MCP umożliwia agentom dostęp do różnych zewnętrznych usług, API i źródeł danych w ujednolicony sposób.

Ta integracja łączy elastyczność ekosystemu narzędzi MCP z solidnym frameworkiem agentów Azure AI Foundry, oferując rozwiązania AI na poziomie przedsiębiorstwa z szerokimi możliwościami dostosowania.

**Note:** Jeśli chcesz używać MCP w Azure AI Foundry Agent Service, obecnie obsługiwane są tylko następujące regiony: westus, westus2, uaenorth, southindia oraz switzerlandnorth

## Cele nauki

Po zakończeniu tego przewodnika będziesz potrafił:

- Zrozumieć Model Context Protocol i jego zalety
- Skonfigurować serwery MCP do współpracy z agentami Azure AI Foundry
- Tworzyć i konfigurować agentów z integracją narzędzi MCP
- Wdrażać praktyczne przykłady z użyciem rzeczywistych serwerów MCP
- Obsługiwać odpowiedzi narzędzi i cytowania w rozmowach agentów

## Wymagania wstępne

Przed rozpoczęciem upewnij się, że masz:

- Subskrypcję Azure z dostępem do AI Foundry
- Pythona w wersji 3.10 lub wyższej
- Zainstalowane i skonfigurowane Azure CLI
- Odpowiednie uprawnienia do tworzenia zasobów AI

## Czym jest Model Context Protocol (MCP)?

Model Context Protocol to ustandaryzowany sposób, w jaki aplikacje AI łączą się z zewnętrznymi źródłami danych i narzędziami. Kluczowe zalety to:

- **Ustandaryzowana integracja**: Spójny interfejs dla różnych narzędzi i usług
- **Bezpieczeństwo**: Bezpieczne mechanizmy uwierzytelniania i autoryzacji
- **Elastyczność**: Wsparcie dla różnych źródeł danych, API i narzędzi niestandardowych
- **Rozszerzalność**: Łatwe dodawanie nowych funkcji i integracji

## Konfiguracja MCP z Azure AI Foundry

### 1. Konfiguracja środowiska

Najpierw ustaw zmienne środowiskowe i zależności:

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
        instructions="Jesteś pomocnym asystentem. Korzystaj z dostępnych narzędzi, aby odpowiadać na pytania. Pamiętaj, aby cytować swoje źródła.",
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
    print(f"Utworzono agenta, ID agenta: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Identyfikator serwera MCP
    "server_url": "https://api.example.com/mcp", # Punkt końcowy serwera MCP
    "require_approval": "never"                 # Polityka zatwierdzania: obecnie obsługiwane tylko "never"
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
        # Utwórz agenta z narzędziami MCP
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Jesteś pomocnym asystentem specjalizującym się w dokumentacji Microsoft. Korzystaj z serwera Microsoft Learn MCP, aby wyszukiwać dokładne i aktualne informacje. Zawsze cytuj swoje źródła.",
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
        print(f"Utworzono agenta, ID agenta: {agent.id}")    
        
        # Utwórz wątek rozmowy
        thread = project_client.agents.threads.create()
        print(f"Utworzono wątek, ID wątku: {thread.id}")

        # Wyślij wiadomość
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Czym jest .NET MAUI? Jak wypada w porównaniu do Xamarin.Forms?",
        )
        print(f"Utworzono wiadomość, ID wiadomości: {message.id}")

        # Uruchom agenta
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Oczekuj na zakończenie
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Status uruchomienia: {run.status}")

        # Przeanalizuj kroki uruchomienia i wywołania narzędzi
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Krok uruchomienia: {step.id}, status: {step.status}, typ: {step.type}")
            if step.type == "tool_calls":
                print("Szczegóły wywołania narzędzia:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Wyświetl rozmowę
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Rozwiązywanie typowych problemów

### 1. Problemy z połączeniem
- Sprawdź, czy adres URL serwera MCP jest dostępny
- Zweryfikuj dane uwierzytelniające
- Upewnij się, że masz połączenie z siecią

### 2. Błędy wywołań narzędzi
- Sprawdź argumenty i formatowanie wywołań narzędzi
- Zweryfikuj wymagania specyficzne dla serwera
- Zaimplementuj odpowiednią obsługę błędów

### 3. Problemy z wydajnością
- Optymalizuj częstotliwość wywołań narzędzi
- Wprowadź mechanizmy cache’owania tam, gdzie to możliwe
- Monitoruj czas odpowiedzi serwera

## Kolejne kroki

Aby dalej rozwijać integrację MCP:

1. **Poznaj niestandardowe serwery MCP**: Buduj własne serwery MCP dla prywatnych źródeł danych
2. **Wdroż zaawansowane zabezpieczenia**: Dodaj OAuth2 lub niestandardowe mechanizmy uwierzytelniania
3. **Monitorowanie i analizy**: Wprowadź logowanie i monitorowanie wykorzystania narzędzi
4. **Skaluj rozwiązanie**: Rozważ load balancing i rozproszone architektury serwerów MCP

## Dodatkowe zasoby

- [Dokumentacja Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Przykłady Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Przegląd agentów Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Specyfikacja MCP](https://spec.modelcontextprotocol.io/)

## Wsparcie

W przypadku dodatkowego wsparcia i pytań:
- Zapoznaj się z [dokumentacją Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Sprawdź [zasoby społeczności MCP](https://modelcontextprotocol.io/)

## Co dalej

- [6. Wkład społeczności](../../06-CommunityContributions/README.md)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczeń AI [Co-op Translator](https://github.com/Azure/co-op-translator). Chociaż dokładamy starań, aby tłumaczenie było jak najdokładniejsze, prosimy pamiętać, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym powinien być uważany za źródło autorytatywne. W przypadku informacji o krytycznym znaczeniu zaleca się skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.