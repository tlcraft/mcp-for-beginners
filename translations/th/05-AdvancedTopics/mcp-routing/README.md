<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a621fc52c7daec552eb8b3b48c0361dd",
  "translation_date": "2025-06-02T19:46:14+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "th"
}
-->
## สถาปัตยกรรมการสุ่มตัวอย่างและการกำหนดเส้นทางใน MCP

การสุ่มตัวอย่างเป็นส่วนสำคัญของ Model Context Protocol (MCP) ที่ช่วยให้การประมวลผลคำขอและการกำหนดเส้นทางมีประสิทธิภาพ โดยจะทำการวิเคราะห์คำขอที่เข้ามาเพื่อกำหนดโมเดลหรือบริการที่เหมาะสมที่สุดในการจัดการ ตามเกณฑ์ต่าง ๆ เช่น ประเภทเนื้อหา บริบทของผู้ใช้ และภาระของระบบ

การสุ่มตัวอย่างและการกำหนดเส้นทางสามารถรวมกันเพื่อสร้างสถาปัตยกรรมที่แข็งแกร่งซึ่งช่วยเพิ่มประสิทธิภาพการใช้ทรัพยากรและรับประกันความพร้อมใช้งานสูง กระบวนการสุ่มตัวอย่างใช้สำหรับการจัดประเภทคำขอ ขณะที่การกำหนดเส้นทางจะส่งคำขอไปยังโมเดลหรือบริการที่เหมาะสม

แผนภาพด้านล่างแสดงให้เห็นว่าการสุ่มตัวอย่างและการกำหนดเส้นทางทำงานร่วมกันอย่างไรในสถาปัตยกรรม MCP ที่ครอบคลุม:

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

## ขั้นตอนถัดไป

- [Sampling](../mcp-sampling/README.md)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารฉบับนี้ได้รับการแปลโดยใช้บริการแปลภาษาด้วย AI [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่แม่นยำ เอกสารต้นฉบับในภาษาต้นฉบับควรถูกพิจารณาเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลสำคัญ ขอแนะนำให้ใช้บริการแปลโดยมนุษย์มืออาชีพ เราจะไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้