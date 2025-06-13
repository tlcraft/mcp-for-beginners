<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-06-13T01:17:47+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "sr"
}
-->
## Dinamično usmeravanje alata

Usmeravanje alata osigurava da se pozivi alata šalju najprikladnijoj usluzi na osnovu konteksta. Na primer, poziv alata za vremensku prognozu može biti usmeren na regionalnu tačku pristupa u zavisnosti od lokacije korisnika, ili alat za kalkulator može koristiti određenu verziju API-ja.

Pogledajmo primer implementacije koji prikazuje dinamično usmeravanje alata zasnovano na analizi zahteva, regionalnim tačkama pristupa i podršci za verzionisanje.

## Arhitektura uzorkovanja i usmeravanja u MCP

Uzorkovanje je ključna komponenta Model Context Protocol-a (MCP) koja omogućava efikasnu obradu i usmeravanje zahteva. Ono podrazumeva analizu dolaznih zahteva kako bi se odredio najprikladniji model ili usluga za njihovo rukovanje, na osnovu različitih kriterijuma kao što su tip sadržaja, korisnički kontekst i opterećenje sistema.

Uzorkovanje i usmeravanje se mogu kombinovati kako bi se kreirala robusna arhitektura koja optimizuje korišćenje resursa i obezbeđuje visoku dostupnost. Proces uzorkovanja može se koristiti za klasifikaciju zahteva, dok ih usmeravanje šalje odgovarajućim modelima ili uslugama.

Dijagram ispod ilustruje kako uzorkovanje i usmeravanje funkcionišu zajedno u sveobuhvatnoj MCP arhitekturi:

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

## Šta sledi

- [5.6 Uzorkovanje](../mcp-sampling/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI prevodilačke usluge [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo tačnosti, imajte na umu da automatski prevodi mogu sadržavati greške ili netačnosti. Originalni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili pogrešna tumačenja nastala korišćenjem ovog prevoda.