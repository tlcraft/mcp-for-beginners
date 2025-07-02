<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:08:48+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "ru"
}
-->
# Интеграция Model Context Protocol (MCP) с Azure AI Foundry

В этом руководстве показано, как интегрировать серверы Model Context Protocol (MCP) с агентами Azure AI Foundry, что позволяет реализовать мощную оркестровку инструментов и корпоративные возможности искусственного интеллекта.

## Введение

Model Context Protocol (MCP) — это открытый стандарт, который позволяет AI-приложениям безопасно подключаться к внешним источникам данных и инструментам. При интеграции с Azure AI Foundry MCP даёт агентам доступ к различным внешним сервисам, API и источникам данных через единый стандартизованный интерфейс.

Эта интеграция объединяет гибкость экосистемы инструментов MCP с надёжной архитектурой агентов Azure AI Foundry, обеспечивая корпоративные AI-решения с широкими возможностями настройки.

**Note:** Если вы хотите использовать MCP в Azure AI Foundry Agent Service, в настоящее время поддерживаются только следующие регионы: westus, westus2, uaenorth, southindia и switzerlandnorth

## Цели обучения

К концу этого руководства вы сможете:

- Понять, что такое Model Context Protocol и его преимущества
- Настроить серверы MCP для работы с агентами Azure AI Foundry
- Создавать и настраивать агентов с интеграцией MCP-инструментов
- Реализовывать практические примеры с реальными MCP-серверами
- Обрабатывать ответы инструментов и ссылки на источники в диалогах агентов

## Требования

Перед началом убедитесь, что у вас есть:

- Подписка Azure с доступом к AI Foundry
- Python версии 3.10 и выше
- Установленный и настроенный Azure CLI
- Необходимые права для создания AI-ресурсов

## Что такое Model Context Protocol (MCP)?

Model Context Protocol — это стандартизованный способ подключения AI-приложений к внешним источникам данных и инструментам. Основные преимущества:

- **Стандартизированная интеграция**: единый интерфейс для разных инструментов и сервисов
- **Безопасность**: надёжные механизмы аутентификации и авторизации
- **Гибкость**: поддержка различных источников данных, API и кастомных инструментов
- **Расширяемость**: лёгкое добавление новых возможностей и интеграций

## Настройка MCP с Azure AI Foundry

### 1. Конфигурация окружения

Сначала настройте переменные окружения и зависимости:

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
        instructions="Вы — полезный помощник. Используйте предоставленные инструменты для ответов на вопросы. Обязательно указывайте источники.",
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
    print(f"Создан агент, ID агента: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Идентификатор MCP-сервера
    "server_url": "https://api.example.com/mcp", # URL MCP-сервера
    "require_approval": "never"                 # Политика одобрения: пока поддерживается только "never"
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
        # Создаём агента с MCP-инструментами
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Вы — полезный помощник, специализирующийся на документации Microsoft. Используйте MCP-сервер Microsoft Learn для поиска точной и актуальной информации. Всегда указывайте источники.",
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
        print(f"Создан агент, ID агента: {agent.id}")    
        
        # Создаём поток диалога
        thread = project_client.agents.threads.create()
        print(f"Создан поток, ID потока: {thread.id}")

        # Отправляем сообщение
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Что такое .NET MAUI? Чем он отличается от Xamarin.Forms?",
        )
        print(f"Создано сообщение, ID сообщения: {message.id}")

        # Запускаем агента
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Ожидаем завершения
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Статус выполнения: {run.status}")

        # Анализируем шаги выполнения и вызовы инструментов
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Шаг выполнения: {step.id}, статус: {step.status}, тип: {step.type}")
            if step.type == "tool_calls":
                print("Детали вызова инструментов:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Отображаем диалог
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
```

## Устранение распространённых проблем

### 1. Проблемы с подключением
- Проверьте, что URL MCP-сервера доступен
- Проверьте учётные данные для аутентификации
- Убедитесь в наличии сетевого соединения

### 2. Ошибки вызова инструментов
- Проверьте аргументы и форматирование вызовов инструментов
- Учитывайте требования конкретного сервера
- Реализуйте корректную обработку ошибок

### 3. Проблемы с производительностью
- Оптимизируйте частоту вызовов инструментов
- Используйте кэширование там, где это возможно
- Следите за временем отклика сервера

## Следующие шаги

Для дальнейшего улучшения интеграции MCP:

1. **Изучите кастомные MCP-серверы**: создайте свои MCP-серверы для закрытых источников данных
2. **Реализуйте продвинутую безопасность**: добавьте OAuth2 или другие механизмы аутентификации
3. **Мониторинг и аналитика**: внедрите логирование и мониторинг использования инструментов
4. **Масштабирование решения**: рассмотрите балансировку нагрузки и распределённые архитектуры MCP-серверов

## Дополнительные ресурсы

- [Документация Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Примеры Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Обзор агентов Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Спецификация MCP](https://spec.modelcontextprotocol.io/)

## Поддержка

Для дополнительной поддержки и вопросов:
- Изучите [документацию Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Ознакомьтесь с [ресурсами сообщества MCP](https://modelcontextprotocol.io/)

## Что дальше

- [6. Вклад сообщества](../../06-CommunityContributions/README.md)

**Отказ от ответственности**:  
Этот документ был переведен с помощью AI-сервиса перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, пожалуйста, учитывайте, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному человеческому переводу. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.