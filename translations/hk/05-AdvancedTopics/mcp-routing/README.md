<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-06-12T21:29:58+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "hk"
}
-->
## MCP中的取樣與路由架構

取樣是Model Context Protocol (MCP)中的關鍵組件，能有效分析和處理請求，根據內容類型、用戶背景及系統負載等不同標準，判斷最合適的模型或服務來處理請求。

取樣與路由可以結合起來，打造一個強健的架構，優化資源使用並確保高可用性。取樣過程用於分類請求，而路由則將請求導向適當的模型或服務。

下圖展示了取樣與路由如何在完整的MCP架構中協同運作：

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

## 接下來的內容

- [5.6 取樣](../mcp-sampling/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原文文件以其母語版本為準。對於重要資料，建議採用專業人工翻譯。我哋對因使用本翻譯而引致嘅任何誤解或誤釋概不負責。