<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:21:03+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "bg"
}
-->
# Интеграция на Model Context Protocol (MCP) с Azure AI Foundry

Това ръководство показва как да интегрирате сървъри на Model Context Protocol (MCP) с агенти на Azure AI Foundry, позволявайки мощна оркестрация на инструменти и корпоративни AI възможности.

## Въведение

Model Context Protocol (MCP) е отворен стандарт, който позволява на AI приложенията да се свързват сигурно с външни източници на данни и инструменти. Когато е интегриран с Azure AI Foundry, MCP дава възможност на агентите да имат достъп и да взаимодействат с различни външни услуги, API-та и източници на данни по стандартизиран начин.

Тази интеграция съчетава гъвкавостта на екосистемата от инструменти на MCP с мощната рамка на агентите в Azure AI Foundry, предоставяйки корпоративни AI решения с богати възможности за персонализация.

**Note:** Ако искате да използвате MCP в Azure AI Foundry Agent Service, в момента се поддържат само следните региони: westus, westus2, uaenorth, southindia и switzerlandnorth

## Цели на обучението

След завършване на това ръководство ще можете да:

- Разберете Model Context Protocol и неговите предимства
- Настроите MCP сървъри за използване с агенти на Azure AI Foundry
- Създавате и конфигурирате агенти с интеграция на MCP инструменти
- Прилагате практически примери с реални MCP сървъри
- Обработвате отговори от инструменти и цитирания в разговорите на агентите

## Изисквания

Преди да започнете, уверете се, че разполагате с:

- Абонамент в Azure с достъп до AI Foundry
- Python 3.10+
- Инсталиран и конфигуриран Azure CLI
- Подходящи права за създаване на AI ресурси

## Какво е Model Context Protocol (MCP)?

Model Context Protocol е стандартизиран начин за AI приложенията да се свързват с външни източници на данни и инструменти. Основните предимства включват:

- **Стандартизирана интеграция**: Еднороден интерфейс за различни инструменти и услуги
- **Сигурност**: Сигурни механизми за удостоверяване и упълномощаване
- **Гъвкавост**: Поддръжка на различни източници на данни, API-та и персонализирани инструменти
- **Разширяемост**: Лесно добавяне на нови възможности и интеграции

## Настройка на MCP с Azure AI Foundry

### 1. Конфигурация на средата

Първо, настройте променливите на средата и зависимостите:

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
        instructions="Вие сте полезен асистент. Използвайте предоставените инструменти, за да отговаряте на въпроси. Винаги цитирайте източниците си.",
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
    print(f"Създаден агент, ID на агента: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Идентификатор за MCP сървъра
    "server_url": "https://api.example.com/mcp", # Крайна точка на MCP сървъра
    "require_approval": "never"                 # Политика за одобрение: в момента се поддържа само "never"
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
        # Създаване на агент с MCP инструменти
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Вие сте полезен асистент, специализиран в документацията на Microsoft. Използвайте Microsoft Learn MCP сървъра, за да търсите точна и актуална информация. Винаги цитирайте източниците си.",
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
        print(f"Създаден агент, ID на агента: {agent.id}")    
        
        # Създаване на нишка за разговор
        thread = project_client.agents.threads.create()
        print(f"Създадена нишка, ID на нишката: {thread.id}")

        # Изпращане на съобщение
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Какво е .NET MAUI? Как се сравнява с Xamarin.Forms?",
        )
        print(f"Създадено съобщение, ID на съобщението: {message.id}")

        # Стартиране на агента
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Изчакване за завършване
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Статус на изпълнението: {run.status}")

        # Преглед на стъпките и повикванията на инструменти
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Стъпка на изпълнение: {step.id}, статус: {step.status}, тип: {step.type}")
            if step.type == "tool_calls":
                print("Подробности за повикванията на инструменти:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Показване на разговора
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Отстраняване на често срещани проблеми

### 1. Проблеми с връзката
- Проверете дали URL адресът на MCP сървъра е достъпен
- Проверете удостоверителните данни
- Уверете се в наличието на мрежова връзка

### 2. Грешки при повиквания на инструменти
- Прегледайте аргументите и формата на повикванията
- Проверете специфичните изисквания на сървъра
- Прилагайте подходящо обработване на грешки

### 3. Проблеми с производителността
- Оптимизирайте честотата на повикванията към инструментите
- Използвайте кеширане, когато е подходящо
- Наблюдавайте времето за отговор на сървъра

## Следващи стъпки

За да подобрите интеграцията си с MCP:

1. **Изследвайте персонализирани MCP сървъри**: Създайте собствени MCP сървъри за защитени източници на данни
2. **Прилагайте разширена сигурност**: Добавете OAuth2 или персонализирани механизми за удостоверяване
3. **Мониторинг и анализи**: Внедрете логване и наблюдение на използването на инструментите
4. **Мащабиране на решението**: Обмислете балансиране на натоварването и разпределени архитектури на MCP сървъри

## Допълнителни ресурси

- [Документация на Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- [Примери за Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Преглед на агенти в Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [Спецификация на MCP](https://spec.modelcontextprotocol.io/)

## Поддръжка

За допълнителна помощ и въпроси:
- Прегледайте [документацията на Azure AI Foundry](https://learn.microsoft.com/azure/ai-foundry/)
- Проверете [ресурсите на MCP общността](https://modelcontextprotocol.io/)

## Какво следва

- [6. Приноси от общността](../../06-CommunityContributions/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или погрешни тълкувания, произтичащи от използването на този превод.