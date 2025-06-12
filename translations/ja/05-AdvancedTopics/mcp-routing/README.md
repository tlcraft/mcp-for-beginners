<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-06-12T21:39:02+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "ja"
}
-->
## MCPにおけるサンプリングとルーティングのアーキテクチャ

サンプリングは、Model Context Protocol（MCP）の重要な要素であり、効率的なリクエスト処理とルーティングを可能にします。これは、受信したリクエストを分析し、コンテンツの種類、ユーザーの状況、システム負荷などのさまざまな基準に基づいて、最も適切なモデルやサービスを決定するプロセスです。

サンプリングとルーティングを組み合わせることで、リソースの最適活用と高い可用性を実現する堅牢なアーキテクチャを構築できます。サンプリングはリクエストの分類に使用され、ルーティングはそれらを適切なモデルやサービスに振り分けます。

以下の図は、サンプリングとルーティングが包括的なMCPアーキテクチャの中でどのように連携しているかを示しています：

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

## 次に学ぶこと

- [5.6 Sampling](../mcp-sampling/README.md)

**免責事項**：  
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があることをご承知ください。原文の母国語版が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じた誤解や誤訳について、一切の責任を負いかねます。