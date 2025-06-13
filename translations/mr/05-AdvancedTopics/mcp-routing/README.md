<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-06-12T23:24:58+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "mr"
}
-->
## MCP मधील सॅम्पलिंग आणि राउटिंग आर्किटेक्चर

सॅम्पलिंग हा Model Context Protocol (MCP) चा एक महत्त्वाचा घटक आहे जो विनंत्यांच्या कार्यक्षम प्रक्रियेसाठी आणि राउटिंगसाठी मदत करतो. यामध्ये येणाऱ्या विनंत्यांचे विश्लेषण करून त्यांना हाताळण्यासाठी सर्वात योग्य मॉडेल किंवा सेवा ठरवली जाते, ज्यासाठी विविध निकष वापरले जातात जसे की कंटेंट प्रकार, वापरकर्त्याचा संदर्भ, आणि सिस्टम लोड.

सॅम्पलिंग आणि राउटिंग एकत्र करून एक मजबूत आर्किटेक्चर तयार करता येतो जो संसाधनांचा प्रभावी वापर करतो आणि उच्च उपलब्धता सुनिश्चित करतो. सॅम्पलिंग प्रक्रियेद्वारे विनंत्यांचे वर्गीकरण करता येते, तर राउटिंग त्यांना योग्य मॉडेल्स किंवा सेवांकडे मार्गदर्शन करते.

खालिल आकृतीत दाखवले आहे की सॅम्पलिंग आणि राउटिंग कसे एकत्र काम करतात एक व्यापक MCP आर्किटेक्चरमध्ये:

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

- [5.6 Sampling](../mcp-sampling/README.md)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्न करतो, तरी कृपया लक्षात ठेवा की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेच्या त्रुटी असू शकतात. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीकरिता व्यावसायिक मानवी अनुवाद शिफारस केला जातो. या अनुवादाच्या वापरामुळे उद्भवणाऱ्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागीसाठी आम्ही जबाबदार नाही.