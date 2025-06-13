<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-06-13T00:37:52+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "ms"
}
-->
## MCP-ում նմուշառում և երթուղավորումի ճարտարապետություն

Նմուշարումը Model Context Protocol (MCP)-ի կարևոր բաղադրիչ է, որը հնարավորություն է տալիս արդյունավետ մշակել և երթուղավորել հարցումները: Այն ներառում է ներթափանցող հարցումների վերլուծություն՝ որոշելու համար ամենահարմար մոդելը կամ ծառայությունը, որը կկառավարի դրանք՝ հիմնվելով տարբեր չափանիշների վրա, ինչպիսիք են բովանդակության տեսակը, օգտվողի կոնտեքստը և համակարգի բեռնվածությունը:

Նմուշարումը և երթուղավորումը կարող են համատեղ օգտագործվել՝ ստեղծելով ամուր ճարտարապետություն, որը օպտիմալացնում է ռեսուրսների օգտագործումը և ապահովում բարձր հասանելիություն: Նմուշարումն օգտագործվում է հարցումների դասակարգման համար, իսկ երթուղավորումը ուղղորդում է դրանք համապատասխան մոդելներին կամ ծառայություններին:

Ստորև ներկայացված է դիագրամ, որը ցույց է տալիս, թե ինչպես են նմուշարումն ու երթուղավորումը միասին աշխատում MCP-ի համապարփակ ճարտարապետության մեջ:

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

## Ի՞նչ է հաջորդը

- [5.6 Նմուշառում](../mcp-sampling/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil perhatian bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya hendaklah dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab terhadap sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.