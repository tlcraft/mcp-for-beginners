<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-07-14T02:12:19+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "pa"
}
-->
## ਸਮਾਰਟ ਲੋਡ ਬੈਲੈਂਸਿੰਗ

ਲੋਡ ਬੈਲੈਂਸਿੰਗ ਸਰੋਤਾਂ ਦੀ ਵਰਤੋਂ ਨੂੰ ਸੁਧਾਰਦਾ ਹੈ ਅਤੇ MCP ਸੇਵਾਵਾਂ ਲਈ ਉੱਚ ਉਪਲਬਧਤਾ ਯਕੀਨੀ ਬਣਾਉਂਦਾ ਹੈ। ਲੋਡ ਬੈਲੈਂਸਿੰਗ ਲਾਗੂ ਕਰਨ ਦੇ ਵੱਖ-ਵੱਖ ਤਰੀਕੇ ਹਨ, ਜਿਵੇਂ ਕਿ ਰਾਊਂਡ-ਰੋਬਿਨ, ਵਜ਼ਨੀਤ ਪ੍ਰਤੀਕਿਰਿਆ ਸਮਾਂ, ਜਾਂ ਸਮੱਗਰੀ-ਜਾਣੂ ਰਣਨੀਤੀਆਂ।

ਆਓ ਹੇਠਾਂ ਦਿੱਤੇ ਉਦਾਹਰਨ ਨੂੰ ਵੇਖੀਏ ਜੋ ਇਹਨਾਂ ਰਣਨੀਤੀਆਂ ਨੂੰ ਵਰਤਦਾ ਹੈ:

- **ਰਾਊਂਡ ਰੋਬਿਨ**: ਉਪਲਬਧ ਸਰਵਰਾਂ ਵਿੱਚ ਬਰਾਬਰ ਬੇਨਤੀ ਵੰਡਦਾ ਹੈ।
- **ਵਜ਼ਨੀਤ ਪ੍ਰਤੀਕਿਰਿਆ ਸਮਾਂ**: ਸਰਵਰਾਂ ਨੂੰ ਉਹਨਾਂ ਦੇ ਔਸਤ ਪ੍ਰਤੀਕਿਰਿਆ ਸਮੇਂ ਦੇ ਆਧਾਰ 'ਤੇ ਬੇਨਤੀ ਭੇਜਦਾ ਹੈ।
- **ਸਮੱਗਰੀ-ਜਾਣੂ**: ਬੇਨਤੀ ਦੀ ਸਮੱਗਰੀ ਦੇ ਆਧਾਰ 'ਤੇ ਵਿਸ਼ੇਸ਼ ਸਰਵਰਾਂ ਨੂੰ ਬੇਨਤੀ ਭੇਜਦਾ ਹੈ।

## ਡਾਇਨਾਮਿਕ ਟੂਲ ਰਾਊਟਿੰਗ

ਟੂਲ ਰਾਊਟਿੰਗ ਇਹ ਯਕੀਨੀ ਬਣਾਉਂਦਾ ਹੈ ਕਿ ਟੂਲ ਕਾਲਾਂ ਸੰਦਰਭ ਦੇ ਆਧਾਰ 'ਤੇ ਸਭ ਤੋਂ ਉਚਿਤ ਸੇਵਾ ਵੱਲ ਭੇਜੀਆਂ ਜਾਣ। ਉਦਾਹਰਨ ਵਜੋਂ, ਮੌਸਮ ਟੂਲ ਕਾਲ ਨੂੰ ਉਪਭੋਗਤਾ ਦੇ ਸਥਾਨ ਦੇ ਆਧਾਰ 'ਤੇ ਖੇਤਰੀ ਐਂਡਪੌਇੰਟ ਵੱਲ ਭੇਜਣਾ ਪੈ ਸਕਦਾ ਹੈ, ਜਾਂ ਕੈਲਕੁਲੇਟਰ ਟੂਲ ਨੂੰ API ਦੇ ਕਿਸੇ ਖਾਸ ਵਰਜਨ ਦੀ ਲੋੜ ਹੋ ਸਕਦੀ ਹੈ।

ਆਓ ਇੱਕ ਉਦਾਹਰਨ ਵੇਖੀਏ ਜੋ ਬੇਨਤੀ ਵਿਸ਼ਲੇਸ਼ਣ, ਖੇਤਰੀ ਐਂਡਪੌਇੰਟ ਅਤੇ ਵਰਜਨਿੰਗ ਸਹਾਇਤਾ ਦੇ ਆਧਾਰ 'ਤੇ ਡਾਇਨਾਮਿਕ ਟੂਲ ਰਾਊਟਿੰਗ ਨੂੰ ਦਰਸਾਉਂਦੀ ਹੈ।

## MCP ਵਿੱਚ ਸੈਂਪਲਿੰਗ ਅਤੇ ਰਾਊਟਿੰਗ ਆਰਕੀਟੈਕਚਰ

ਸੈਂਪਲਿੰਗ ਮਾਡਲ ਕਾਂਟੈਕਸਟ ਪ੍ਰੋਟੋਕੋਲ (MCP) ਦਾ ਇੱਕ ਮਹੱਤਵਪੂਰਨ ਹਿੱਸਾ ਹੈ ਜੋ ਪ੍ਰਭਾਵਸ਼ਾਲੀ ਬੇਨਤੀ ਪ੍ਰਕਿਰਿਆ ਅਤੇ ਰਾਊਟਿੰਗ ਦੀ ਆਗਿਆ ਦਿੰਦਾ ਹੈ। ਇਹ ਆਉਣ ਵਾਲੀਆਂ ਬੇਨਤੀਆਂ ਦਾ ਵਿਸ਼ਲੇਸ਼ਣ ਕਰਦਾ ਹੈ ਤਾਂ ਜੋ ਵੱਖ-ਵੱਖ ਮਾਪਦੰਡਾਂ ਜਿਵੇਂ ਕਿ ਸਮੱਗਰੀ ਦੀ ਕਿਸਮ, ਉਪਭੋਗਤਾ ਸੰਦਰਭ ਅਤੇ ਸਿਸਟਮ ਲੋਡ ਦੇ ਆਧਾਰ 'ਤੇ ਸਭ ਤੋਂ ਉਚਿਤ ਮਾਡਲ ਜਾਂ ਸੇਵਾ ਚੁਣੀ ਜਾ ਸਕੇ।

ਸੈਂਪਲਿੰਗ ਅਤੇ ਰਾਊਟਿੰਗ ਨੂੰ ਮਿਲਾ ਕੇ ਇੱਕ ਮਜ਼ਬੂਤ ਆਰਕੀਟੈਕਚਰ ਬਣਾਇਆ ਜਾ ਸਕਦਾ ਹੈ ਜੋ ਸਰੋਤਾਂ ਦੀ ਵਰਤੋਂ ਨੂੰ ਸੁਧਾਰਦਾ ਹੈ ਅਤੇ ਉੱਚ ਉਪਲਬਧਤਾ ਯਕੀਨੀ ਬਣਾਉਂਦਾ ਹੈ। ਸੈਂਪਲਿੰਗ ਪ੍ਰਕਿਰਿਆ ਬੇਨਤੀਆਂ ਨੂੰ ਵਰਗੀਕ੍ਰਿਤ ਕਰਨ ਲਈ ਵਰਤੀ ਜਾ ਸਕਦੀ ਹੈ, ਜਦਕਿ ਰਾਊਟਿੰਗ ਉਹਨਾਂ ਨੂੰ ਉਚਿਤ ਮਾਡਲਾਂ ਜਾਂ ਸੇਵਾਵਾਂ ਵੱਲ ਭੇਜਦੀ ਹੈ।

ਹੇਠਾਂ ਦਿੱਤਾ ਚਿੱਤਰ ਦਿਖਾਉਂਦਾ ਹੈ ਕਿ ਕਿਵੇਂ ਸੈਂਪਲਿੰਗ ਅਤੇ ਰਾਊਟਿੰਗ ਮਿਲ ਕੇ ਇੱਕ ਵਿਸ਼ਤ੍ਰਿਤ MCP ਆਰਕੀਟੈਕਚਰ ਵਿੱਚ ਕੰਮ ਕਰਦੇ ਹਨ:

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

- [5.6 ਸੈਂਪਲਿੰਗ](../mcp-sampling/README.md)

**ਅਸਵੀਕਾਰੋਪਣ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਅਤ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।