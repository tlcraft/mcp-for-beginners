<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-07-14T02:16:58+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "sr"
}
-->
## Динамичко усмеравање алата

Усмеравање алата обезбеђује да се позиви алата усмеравају ка најприкладнијој услузи на основу контекста. На пример, позив алата за временску прогнозу може бити усмерен ка регионалном крајњем чвору у зависности од локације корисника, или алат за калкулатор може користити одређену верзију API-ја.

Погледајмо пример имплементације који демонстрира динамичко усмеравање алата на основу анализе захтева, регионалних крајњих чворова и подршке за верзионисање.

## Архитектура узорковања и усмеравања у MCP

Узорковање је кључна компонента Протокола контекста модела (MCP) која омогућава ефикасну обраду и усмеравање захтева. Оно подразумева анализу долазних захтева како би се одредио најприкладнији модел или услуга за њихову обраду, на основу различитих критеријума као што су тип садржаја, контекст корисника и оптерећење система.

Узорковање и усмеравање могу се комбиновати да би се створила робусна архитектура која оптимизује коришћење ресурса и обезбеђује високу доступност. Процес узорковања може се користити за класификацију захтева, док их усмеравање води ка одговарајућим моделима или услугама.

Дијаграм испод илуструје како узорковање и усмеравање заједно функционишу у свеобухватној MCP архитектури:

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

## Шта следи

- [5.6 Sampling](../mcp-sampling/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо прецизности, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења настала коришћењем овог превода.