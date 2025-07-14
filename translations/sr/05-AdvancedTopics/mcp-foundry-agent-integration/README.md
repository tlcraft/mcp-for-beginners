<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-14T00:01:02+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "sr"
}
-->
# Model Context Protocol (MCP) интеграција са Azure AI Foundry

Овај водич показује како да интегришете Model Context Protocol (MCP) сервере са Azure AI Foundry агентима, омогућавајући моћну оркестрацију алата и корпоративне AI могућности.

## Увод

Model Context Protocol (MCP) је отворени стандард који омогућава AI апликацијама безбедно повезивање са спољним изворима података и алатима. Када се интегрише са Azure AI Foundry, MCP омогућава агентима приступ и интеракцију са разним спољним сервисима, API-јима и изворима података на стандардизован начин.

Ова интеграција комбинује флексибилност MCP екосистема алата са робусним агентским оквиром Azure AI Foundry, пружајући корпоративна AI решења са широким могућностима прилагођавања.

**Note:** Ако желите да користите MCP у Azure AI Foundry Agent Service, тренутно су подржане само следеће регије: westus, westus2, uaenorth, southindia и switzerlandnorth

## Циљеви учења

На крају овог водича моћи ћете да:

- Разумете Model Context Protocol и његове предности
- Подесите MCP сервере за коришћење са Azure AI Foundry агентима
- Креирате и конфигуришете агенте са MCP интеграцијом алата
- Имплементирате практичне примере користећи праве MCP сервере
- Обрадите одговоре алата и цитате у разговорима агената

## Захтеви

Пре почетка, уверите се да имате:

- Azure претплату са приступом AI Foundry
- Python 3.10+
- Инсталиран и конфигурисан Azure CLI
- Одговарајуће дозволе за креирање AI ресурса

## Шта је Model Context Protocol (MCP)?

Model Context Protocol је стандардизован начин за AI апликације да се повежу са спољним изворима података и алатима. Кључне предности укључују:

- **Стандардизована интеграција**: Конзистентан интерфејс за различите алате и сервисе
- **Безбедност**: Безбедни механизми аутентификације и ауторизације
- **Флексибилност**: Подршка за разне изворе података, API-је и прилагођене алате
- **Проширивост**: Лако додавање нових могућности и интеграција

## Подешавање MCP са Azure AI Foundry

### 1. Конфигурација окружења

Прво, подесите променљиве окружења и зависности:

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
    "server_label": "unique_server_name",      # Идентификатор MCP сервера
    "server_url": "https://api.example.com/mcp", # MCP сервер крајња тачка
    "require_approval": "never"                 # Политика одобрења: тренутно подржано само "never"
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
        # Креирање агента са MCP алатима
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
        
        # Креирање нити разговора
        thread = project_client.agents.threads.create()
        print(f"Created thread, thread ID: {thread.id}")

        # Слање поруке
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="What is .NET MAUI? How does it compare to Xamarin.Forms?",
        )
        print(f"Created message, message ID: {message.id}")

        # Покретање агента
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Чекање на завршетак
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Run status: {run.status}")

        # Испитивање корака извршења и позива алата
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Run step: {step.id}, status: {step.status}, type: {step.type}")
            if step.type == "tool_calls":
                print("Детаљи позива алата:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Приказ разговора
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## Решавање уобичајених проблема

### 1. Проблеми са везом
- Проверите да ли је MCP сервер URL доступан
- Проверите аутентификационе податке
- Уверите се у мрежну повезаност

### 2. Неуспели позиви алата
- Прегледајте аргументе и формат позива алата
- Проверите захтеве специфичне за сервер
- Имплементирајте правилно руковање грешкама

### 3. Проблеми са перформансама
- Оптимизујте учесталост позива алата
- Користите кеширање где је прикладно
- Пратите време одговора сервера

## Следећи кораци

Да бисте додатно унапредили вашу MCP интеграцију:

1. **Истражите прилагођене MCP сервере**: Направите своје MCP сервере за власничке изворе података
2. **Имплементирајте напредну безбедност**: Додајте OAuth2 или прилагођене механизме аутентификације
3. **Праћење и аналитика**: Имплементирајте логовање и праћење коришћења алата
4. **Шкалирање решења**: Размотрите балансер оптерећења и дистрибуиране MCP сервер архитектуре

## Додатни ресурси

- [Azure AI Foundry документација](https://learn.microsoft.com/azure/ai-foundry/)
- [Примери Model Context Protocol](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Преглед Azure AI Foundry агената](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP спецификација](https://spec.modelcontextprotocol.io/)

## Подршка

За додатну подршку и питања:
- Прегледајте [Azure AI Foundry документацију](https://learn.microsoft.com/azure/ai-foundry/)
- Погледајте [MCP заједничке ресурсе](https://modelcontextprotocol.io/)

## Шта следи

- [6. Заједнички доприноси](../../06-CommunityContributions/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI преводилачке услуге [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматизовани преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која произилазе из коришћења овог превода.