<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-07-14T02:12:02+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "ne"
}
-->
## डाइनामिक टूल राउटिङ

टूल राउटिङले सुनिश्चित गर्छ कि टूल कलहरू सन्दर्भको आधारमा सबैभन्दा उपयुक्त सेवामा पठाइन्छ। उदाहरणका लागि, मौसम टूल कल प्रयोगकर्ताको स्थानको आधारमा क्षेत्रीय अन्तिम बिन्दुमा राउट गर्न आवश्यक पर्न सक्छ, वा क्याल्कुलेटर टूलले API को विशेष संस्करण प्रयोग गर्नुपर्ने हुन सक्छ।

आउनुहोस् एउटा उदाहरण हेर्नुहोस् जसले अनुरोध विश्लेषण, क्षेत्रीय अन्तिम बिन्दुहरू, र संस्करण समर्थनको आधारमा डाइनामिक टूल राउटिङ देखाउँछ।

## MCP मा स्याम्पलिङ र राउटिङ आर्किटेक्चर

स्याम्पलिङ मोडेल कन्टेक्स्ट प्रोटोकल (MCP) को एक महत्वपूर्ण अङ्ग हो जसले प्रभावकारी अनुरोध प्रशोधन र राउटिङलाई सम्भव बनाउँछ। यसले आउने अनुरोधहरूको विश्लेषण गरेर सबैभन्दा उपयुक्त मोडेल वा सेवा निर्धारण गर्छ, जस्तै सामग्री प्रकार, प्रयोगकर्ता सन्दर्भ, र प्रणाली लोडका आधारमा।

स्याम्पलिङ र राउटिङलाई संयोजन गरेर एक बलियो आर्किटेक्चर तयार गर्न सकिन्छ जसले स्रोतहरूको सदुपयोग र उच्च उपलब्धता सुनिश्चित गर्छ। स्याम्पलिङ प्रक्रियाले अनुरोधहरू वर्गीकरण गर्न मद्दत गर्छ भने राउटिङले तिनीहरूलाई उपयुक्त मोडेल वा सेवामा पठाउँछ।

तलको चित्रले देखाउँछ कि कसरी स्याम्पलिङ र राउटिङले मिलेर व्यापक MCP आर्किटेक्चरमा काम गर्छन्:

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

## के छ अर्को

- [5.6 स्याम्पलिङ](../mcp-sampling/README.md)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।