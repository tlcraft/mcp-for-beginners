<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a621fc52c7daec552eb8b3b48c0361dd",
  "translation_date": "2025-06-02T19:43:58+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "bn"
}
-->
## MCP-তে স্যাম্পলিং এবং রাউটিং আর্কিটেকচার

স্যাম্পলিং হল Model Context Protocol (MCP)-এর একটি গুরুত্বপূর্ণ উপাদান যা কার্যকরী অনুরোধ প্রক্রিয়াকরণ এবং রাউটিং নিশ্চিত করে। এটি আসা অনুরোধগুলি বিশ্লেষণ করে সবচেয়ে উপযুক্ত মডেল বা সার্ভিস নির্ধারণ করে, বিভিন্ন মানদণ্ড যেমন কনটেন্ট টাইপ, ব্যবহারকারীর প্রসঙ্গ, এবং সিস্টেম লোডের ভিত্তিতে।

স্যাম্পলিং এবং রাউটিং একত্রিত করে এমন একটি শক্তিশালী আর্কিটেকচার তৈরি করা যায় যা সম্পদের সর্বোত্তম ব্যবহার এবং উচ্চ উপলব্ধতা নিশ্চিত করে। স্যাম্পলিং প্রক্রিয়া অনুরোধগুলি শ্রেণীবদ্ধ করতে ব্যবহৃত হয়, আর রাউটিং সেগুলিকে উপযুক্ত মডেল বা সার্ভিসে পাঠায়।

নিচের চিত্রটি দেখায় কিভাবে স্যাম্পলিং এবং রাউটিং একসাথে MCP-এর একটি পূর্ণাঙ্গ আর্কিটেকচারে কাজ করে:

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

## পরবর্তী ধাপ

- [স্যাম্পলিং](../mcp-sampling/README.md)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ভুল বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ সুপারিশ করা হয়। এই অনুবাদের ব্যবহারে কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।