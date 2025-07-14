<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-07-14T02:16:42+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "bg"
}
-->
## Интелигентно балансиране на натоварването

Балансът на натоварването оптимизира използването на ресурсите и осигурява висока наличност на MCP услугите. Съществуват различни начини за реализиране на баланс на натоварването, като например кръгово разпределение (round-robin), претеглено време за отговор или стратегии, базирани на съдържанието.

Нека разгледаме примерна реализация, която използва следните стратегии:

- **Кръгово разпределение (Round Robin)**: Разпределя заявките равномерно между наличните сървъри.
- **Претеглено време за отговор (Weighted Response Time)**: Насочва заявките към сървъри въз основа на тяхното средно време за отговор.
- **Базирано на съдържанието (Content-Aware)**: Насочва заявките към специализирани сървъри според съдържанието на заявката.

## Динамично маршрутизиране на инструменти

Маршрутизирането на инструменти гарантира, че повикванията към инструменти се насочват към най-подходящата услуга според контекста. Например, повикване към инструмент за прогноза за времето може да трябва да бъде насочено към регионален крайна точка според местоположението на потребителя, или инструментът калкулатор може да изисква използването на конкретна версия на API.

Нека разгледаме примерна реализация, която демонстрира динамично маршрутизиране на инструменти въз основа на анализ на заявката, регионални крайни точки и поддръжка на версии.

## Архитектура на семплиране и маршрутизиране в MCP

Семплирането е ключов компонент на Model Context Protocol (MCP), който позволява ефективна обработка и маршрутизиране на заявките. То включва анализ на входящите заявки, за да се определи най-подходящият модел или услуга за тяхното обработване, въз основа на различни критерии като тип съдържание, контекст на потребителя и натоварване на системата.

Семплирането и маршрутизирането могат да се комбинират, за да се създаде здрава архитектура, която оптимизира използването на ресурсите и осигурява висока наличност. Процесът на семплиране може да се използва за класифициране на заявките, докато маршрутизирането ги насочва към подходящите модели или услуги.

Диаграмата по-долу илюстрира как семплирането и маршрутизирането работят заедно в цялостна MCP архитектура:

```mermaid
flowchart TB
    Client([MCP Client])
    
    subgraph "Request Processing"
        Router{Request Router}
        Analyzer[Content Analyzer]
        Sampler[Sampling Configurator]
    end
    
    subgraph "Server Selection"
        LoadBalancer{Load Balancer}
        ModelSelector[Model Selector]
        ServerPool[(Server Pool)]
    end
    
    subgraph "Model Processing"
        ModelA[Specialized Model A]
        ModelB[Specialized Model B]
        ModelC[General Model]
    end
    
    subgraph "Tool Execution"
        ToolRouter{Tool Router}
        ToolRegistryA[(Primary Tools)]
        ToolRegistryB[(Regional Tools)]
    end
    
    Client -->|Request| Router
    Router -->|Analyze| Analyzer
    Analyzer -->|Configure| Sampler
    Router -->|Route Request| LoadBalancer
    LoadBalancer --> ServerPool
    ServerPool --> ModelSelector
    ModelSelector --> ModelA
    ModelSelector --> ModelB
    ModelSelector --> ModelC
    
    ModelA -->|Tool Calls| ToolRouter
    ModelB -->|Tool Calls| ToolRouter
    ModelC -->|Tool Calls| ToolRouter
    
    ToolRouter --> ToolRegistryA
    ToolRouter --> ToolRegistryB
    
    ToolRegistryA -->|Results| ModelA
    ToolRegistryA -->|Results| ModelB
    ToolRegistryA -->|Results| ModelC
    ToolRegistryB -->|Results| ModelA
    ToolRegistryB -->|Results| ModelB
    ToolRegistryB -->|Results| ModelC
    
    ModelA -->|Response| Client
    ModelB -->|Response| Client
    ModelC -->|Response| Client
    
    style Client fill:#d5e8f9,stroke:#333
    style Router fill:#f9d5e5,stroke:#333
    style LoadBalancer fill:#f9d5e5,stroke:#333
    style ToolRouter fill:#f9d5e5,stroke:#333
    style ModelA fill:#c2f0c2,stroke:#333
    style ModelB fill:#c2f0c2,stroke:#333
    style ModelC fill:#c2f0c2,stroke:#333
```

## Какво следва

- [5.6 Семплиране](../mcp-sampling/README.md)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.