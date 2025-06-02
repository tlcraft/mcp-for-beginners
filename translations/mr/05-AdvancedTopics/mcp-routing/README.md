<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a621fc52c7daec552eb8b3b48c0361dd",
  "translation_date": "2025-06-02T19:44:11+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "mr"
}
-->
## MCP मध्ये सॅम्पलिंग आणि राउटिंग आर्किटेक्चर

सॅम्पलिंग ही Model Context Protocol (MCP) ची एक महत्त्वाची बाब आहे जी विनंत्यांच्या कार्यक्षम प्रक्रियेसाठी आणि राउटिंगसाठी मदत करते. यात येणाऱ्या विनंत्यांचे विश्लेषण करून त्यांना हाताळण्यासाठी सर्वात योग्य मॉडेल किंवा सेवा ठरवली जाते, ज्यासाठी विविध निकष वापरले जातात जसे की कंटेंटचा प्रकार, वापरकर्त्याचा संदर्भ, आणि सिस्टीमचा लोड.

सॅम्पलिंग आणि राउटिंग एकत्र करून एक मजबूत आर्किटेक्चर तयार करता येतो जे संसाधनांचा योग्य वापर सुनिश्चित करते आणि उच्च उपलब्धता राखते. सॅम्पलिंग प्रक्रियेचा वापर विनंत्यांचे वर्गीकरण करण्यासाठी केला जातो, तर राउटिंग त्यांना योग्य मॉडेल किंवा सेवेकडे नेते.

खालील आकृतीमध्ये सॅम्पलिंग आणि राउटिंग कसे एकत्र काम करतात हे दर्शवले आहे:

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

## पुढे काय

- [Sampling](../mcp-sampling/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI भाषांतर सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून भाषांतरित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात ठेवा की स्वयंचलित भाषांतरांमध्ये चुका किंवा अचूकतेत त्रुटी असू शकतात. मूळ दस्तऐवज त्याच्या मूळ भाषेत अधिकृत स्रोत मानला पाहिजे. महत्त्वाच्या माहिती साठी व्यावसायिक मानवी भाषांतर शिफारस केली जाते. या भाषांतराच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थसंग्रहासाठी आम्ही जबाबदार नाही.