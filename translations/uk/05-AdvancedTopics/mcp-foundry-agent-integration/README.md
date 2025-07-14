<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-14T00:02:18+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "uk"
}
-->
# Інтеграція Model Context Protocol (MCP) з Azure AI Foundry

Цей посібник демонструє, як інтегрувати сервери Model Context Protocol (MCP) з агентами Azure AI Foundry, що дозволяє ефективно організовувати роботу інструментів та забезпечувати корпоративні AI можливості.

## Вступ

Model Context Protocol (MCP) — це відкритий стандарт, який дозволяє AI-додаткам безпечно підключатися до зовнішніх джерел даних та інструментів. При інтеграції з Azure AI Foundry MCP дає агентам можливість отримувати доступ і взаємодіяти з різними зовнішніми сервісами, API та джерелами даних у стандартизований спосіб.

Ця інтеграція поєднує гнучкість екосистеми інструментів MCP з надійною архітектурою агентів Azure AI Foundry, забезпечуючи корпоративні AI-рішення з широкими можливостями налаштування.

**Note:** Якщо ви хочете використовувати MCP у Azure AI Foundry Agent Service, наразі підтримуються лише такі регіони: westus, westus2, uaenorth, southindia та switzerlandnorth

## Цілі навчання

Після проходження цього посібника ви зможете:

- Розуміти Model Context Protocol та його переваги
- Налаштувати сервери MCP для роботи з агентами Azure AI Foundry
- Створювати та конфігурувати агентів з інтеграцією MCP інструментів
- Реалізувати практичні приклади з використанням реальних серверів MCP
- Обробляти відповіді інструментів та посилання у розмовах агентів

## Вимоги

Перед початком переконайтеся, що у вас є:

- Підписка Azure з доступом до AI Foundry
- Python 3.10+
- Встановлений та налаштований Azure CLI
- Відповідні права для створення AI ресурсів

## Що таке Model Context Protocol (MCP)?

Model Context Protocol — це стандартизований спосіб для AI-додатків підключатися до зовнішніх джерел даних та інструментів. Основні переваги:

- **Стандартизована інтеграція**: уніфікований інтерфейс для різних інструментів і сервісів
- **Безпека**: надійні механізми автентифікації та авторизації
- **Гнучкість**: підтримка різних джерел даних, API та кастомних інструментів
- **Розширюваність**: легке додавання нових можливостей та інтеграцій

## Налаштування MCP з Azure AI Foundry

### 1. Конфігурація середовища

Спочатку налаштуйте змінні середовища та залежності:

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
        instructions="Ви корисний помічник. Використовуйте надані інструменти для відповіді на запитання. Обов’язково вказуйте джерела.",
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
    print(f"Створено агента, ID агента: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Ідентифікатор MCP сервера
    "server_url": "https://api.example.com/mcp", # Адреса MCP сервера
    "require_approval": "never"                 # Політика затвердження: наразі підтримується лише "never"
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
        # Створення агента з MCP інструментами
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Ви корисний помічник, що спеціалізується на документації Microsoft. Використовуйте MCP сервер Microsoft Learn для пошуку точної та актуальної інформації. Завжди вказуйте джерела.",
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
        print(f"Створено агента, ID агента: {agent.id}")    
        
        # Створення розмовної нитки
        thread = project_client.agents.threads.create()
        print(f"Створено нитку, ID нитки: {thread.id}")

        # Надсилання повідомлення
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Що таке .NET MAUI? Чим він відрізняється від Xamarin.Forms?",
        )
        print(f"Створено повідомлення, ID повідомлення: {message.id}")

        # Запуск агента
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Очікування завершення
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Статус виконання: {run.status}")

        # Перегляд кроків виконання та викликів інструментів
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Крок виконання: {step.id}, статус: {step.status}, тип: {step.type}")
            if step.type == "tool_calls":
                print("Деталі виклику інструменту:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Відображення розмови
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Вирішення поширених проблем

### 1. Проблеми з підключенням
- Перевірте доступність URL MCP сервера
- Переконайтеся в правильності облікових даних для автентифікації
- Перевірте мережеве з’єднання

### 2. Помилки виклику інструментів
- Перевірте аргументи та форматування викликів інструментів
- Врахуйте специфічні вимоги сервера
- Реалізуйте коректну обробку помилок

### 3. Проблеми з продуктивністю
- Оптимізуйте частоту викликів інструментів
- Використовуйте кешування там, де це доречно
- Моніторьте час відповіді сервера

## Наступні кроки

Для подальшого покращення інтеграції MCP:

1. **Досліджуйте кастомні MCP сервери**: створюйте власні MCP сервери для приватних джерел даних
2. **Реалізуйте розширену безпеку**: додайте OAuth2 або власні механізми автентифікації
3. **Моніторинг та аналітика**: впровадьте логування та моніторинг використання інструментів
4. **Масштабування рішення**: розгляньте балансування навантаження та розподілену архітектуру MCP серверів

## Додаткові ресурси

- [Документація Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Приклади Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Огляд агентів Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Специфікація MCP](https://spec.modelcontextprotocol.io/)

## Підтримка

Для додаткової підтримки та запитань:
- Ознайомтеся з [документацією Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Перевірте [ресурси спільноти MCP](https://modelcontextprotocol.io/)

## Що далі

- [6. Внески спільноти](../../06-CommunityContributions/README.md)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.