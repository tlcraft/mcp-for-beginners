<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a621fc52c7daec552eb8b3b48c0361dd",
  "translation_date": "2025-06-02T19:44:38+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "pa"
}
-->
## MCP ਵਿੱਚ ਸੈਂਪਲਿੰਗ ਅਤੇ ਰੂਟਿੰਗ ਆਰਕੀਟੈਕਚਰ

ਸੈਂਪਲਿੰਗ Model Context Protocol (MCP) ਦਾ ਇੱਕ ਮਹੱਤਵਪੂਰਨ ਹਿੱਸਾ ਹੈ ਜੋ ਬੇਹਤਰੀਨ ਬੇਨਤੀ ਪ੍ਰਕਿਰਿਆ ਅਤੇ ਰੂਟਿੰਗ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਇਸ ਵਿੱਚ ਆਉਂਦੀਆਂ ਬੇਨਤੀਆਂ ਦਾ ਵਿਸ਼ਲੇਸ਼ਣ ਕਰਨਾ ਸ਼ਾਮਲ ਹੈ ਤਾਂ ਜੋ ਸਭ ਤੋਂ ਯੋਗ ਮਾਡਲ ਜਾਂ ਸੇਵਾ ਨੂੰ ਚੁਣਿਆ ਜਾ ਸਕੇ ਜੋ ਉਨ੍ਹਾਂ ਨੂੰ ਸੰਭਾਲ ਸਕੇ, ਵੱਖ-ਵੱਖ ਮਾਪਦੰਡਾਂ ਜਿਵੇਂ ਸਮੱਗਰੀ ਦੀ ਕਿਸਮ, ਉਪਭੋਗਤਾ ਸੰਦਰਭ, ਅਤੇ ਸਿਸਟਮ ਲੋਡ ਦੇ ਅਧਾਰ 'ਤੇ।

ਸੈਂਪਲਿੰਗ ਅਤੇ ਰੂਟਿੰਗ ਨੂੰ ਮਿਲਾ ਕੇ ਇੱਕ ਮਜ਼ਬੂਤ ਆਰਕੀਟੈਕਚਰ ਬਣਾਈ ਜਾ ਸਕਦੀ ਹੈ ਜੋ ਸਰੋਤਾਂ ਦੀ ਬਿਹਤਰ ਵਰਤੋਂ ਕਰਦੀ ਹੈ ਅਤੇ ਉੱਚ ਉਪਲਬਧਤਾ ਨੂੰ ਯਕੀਨੀ ਬਣਾਉਂਦੀ ਹੈ। ਸੈਂਪਲਿੰਗ ਪ੍ਰਕਿਰਿਆ ਬੇਨਤੀਆਂ ਨੂੰ ਵਰਗੀਕ੍ਰਿਤ ਕਰਨ ਲਈ ਵਰਤੀ ਜਾ ਸਕਦੀ ਹੈ, ਜਦਕਿ ਰੂਟਿੰਗ ਉਨ੍ਹਾਂ ਨੂੰ ਯੋਗ ਮਾਡਲਾਂ ਜਾਂ ਸੇਵਾਵਾਂ ਵੱਲ ਭੇਜਦੀ ਹੈ।

ਹੇਠਾਂ ਦਿੱਤਾ ਗਿਆ ਡਾਇਗ੍ਰਾਮ ਦਿਖਾਉਂਦਾ ਹੈ ਕਿ MCP ਦੀ ਵਿਸ਼ਤ੍ਰਿਤ ਆਰਕੀਟੈਕਚਰ ਵਿੱਚ ਸੈਂਪਲਿੰਗ ਅਤੇ ਰੂਟਿੰਗ ਕਿਵੇਂ ਮਿਲ ਕੇ ਕੰਮ ਕਰਦੇ ਹਨ:

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

## ਅਗਲਾ ਕੀ ਹੈ

- [Sampling](../mcp-sampling/README.md)

**ਅਸਵੀਕਾਰੋਤਾ**:  
ਇਸ ਦਸਤਾਵੇਜ਼ ਦਾ ਅਨੁਵਾਦ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਨਾਲ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਤੀਰਤਾ ਹੋ ਸਕਦੀ ਹੈ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੇ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਪੈਦਾ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਮੀਆਂ ਜਾਂ ਭੁੱਲਾਂ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।