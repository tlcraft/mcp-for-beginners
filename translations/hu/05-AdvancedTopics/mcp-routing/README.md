<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-06-13T00:53:32+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "hu"
}
-->
## Intelligens terheléselosztás

A terheléselosztás optimalizálja az erőforrások kihasználtságát, és biztosítja az MCP szolgáltatások magas rendelkezésre állását. Többféle módszer létezik a terheléselosztás megvalósítására, például körkörös (round-robin), súlyozott válaszidő vagy tartalomérzékeny stratégiák.

Nézzük meg az alábbi példát, amely a következő stratégiákat alkalmazza:

- **Körkörös (Round Robin)**: Egyenletesen osztja el a kéréseket az elérhető szerverek között.
- **Súlyozott válaszidő (Weighted Response Time)**: A szerverek átlagos válaszideje alapján irányítja a kéréseket.
- **Tartalomérzékeny (Content-Aware)**: A kérés tartalma alapján speciális szerverekhez irányítja a kéréseket.

## Dinamikus eszközirányítás

Az eszközirányítás biztosítja, hogy az eszközhívások a kontextus alapján a legmegfelelőbb szolgáltatáshoz kerüljenek. Például egy időjárás-eszköz hívását a felhasználó helyzete alapján regionális végpontra kell irányítani, vagy egy számológép eszköznek egy adott API verziót kell használnia.

Nézzünk meg egy példát, amely bemutatja a dinamikus eszközirányítást kérés elemzés, regionális végpontok és verziókezelés alapján.

## Mintavétel és irányítási architektúra az MCP-ben

A mintavétel a Model Context Protocol (MCP) egyik kulcsfontosságú eleme, amely lehetővé teszi a hatékony kérésfeldolgozást és irányítást. Ez magában foglalja a bejövő kérések elemzését annak érdekében, hogy meghatározza, melyik modell vagy szolgáltatás a legalkalmasabb azok kezelésére, különböző szempontok, például tartalomtípus, felhasználói kontextus és rendszerterhelés alapján.

A mintavétel és az irányítás kombinálásával robusztus architektúra hozható létre, amely optimalizálja az erőforrások kihasználtságát és biztosítja a magas rendelkezésre állást. A mintavételi folyamat a kérések osztályozására használható, míg az irányítás a megfelelő modellekhez vagy szolgáltatásokhoz irányítja azokat.

Az alábbi ábra bemutatja, hogyan működnek együtt a mintavétel és az irányítás egy átfogó MCP architektúrában:

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

## Mi következik

- [5.6 Mintavétel](../mcp-sampling/README.md)

**Nyilatkozat**:  
Ez a dokumentum az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.