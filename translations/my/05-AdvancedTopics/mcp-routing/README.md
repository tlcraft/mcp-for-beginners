<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af40eab7bd6ebf7e607f982a5506a5b5",
  "translation_date": "2025-06-17T16:59:41+00:00",
  "source_file": "05-AdvancedTopics/mcp-routing/README.md",
  "language_code": "my"
}
-->
## MCP တွင် စမ်းသပ်မှုနှင့် Routing စနစ်

Sampling သည် Model Context Protocol (MCP) ၏ အရေးကြီးသောအစိတ်အပိုင်းတစ်ခုဖြစ်ပြီး၊ လုပ်ဆောင်ချက်များကို ထိရောက်စွာ ပြုလုပ်ရန်နှင့် routing ကို အဆင်ပြေစေရန် အသုံးပြုသည်။ ၎င်းသည် လာရောက်သော တောင်းဆိုချက်များကို အကြောင်းအရာအမျိုးအစား၊ အသုံးပြုသူအခြေအနေ၊ စနစ်၏အလုပ်ပမာဏများအပေါ် မူတည်၍ အထိရောက်ဆုံးသော မော်ဒယ် သို့ ဝန်ဆောင်မှုကို သတ်မှတ်ရန် လေ့လာစစ်ဆေးခြင်းကို ပါဝင်သည်။

Sampling နှင့် routing ကို ပေါင်းစပ်၍ အရင်းအမြစ်အသုံးပြုမှုကို ထိရောက်စွာ စီမံခန့်ခွဲပြီး ဝန်ဆောင်မှုများ၏ အမြင့်ဆုံးရရှိနိုင်မှုကို သေချာစေသော ခိုင်မာသော စနစ်တစ်ခုကို ဖန်တီးနိုင်သည်။ Sampling လုပ်ငန်းစဉ်သည် တောင်းဆိုချက်များကို အမျိုးအစားခွဲခြားရန် အသုံးပြုနိုင်ပြီး၊ routing သည် ၎င်းတို့ကို သင့်တော်သော မော်ဒယ်များ သို့ ဝန်ဆောင်မှုများဆီသို့ ဦးတည်ပေးသည်။

အောက်ပါ ပုံတွင် MCP ၏ စမ်းသပ်မှုနှင့် routing စနစ်များ ပေါင်းစပ်၍ ဘယ်လို လုပ်ဆောင်ကြောင်း ဖော်ပြထားသည်-

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

## နောက်တစ်ဆင့်

- [5.6 Sampling](../mcp-sampling/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်စနစ်ဖြစ်သည့် [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ တိကျမှုအတွက် ကြိုးစားဆောင်ရွက်ပေမယ့် အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်ကြောင်း ကျေးဇူးပြု၍ သတိပြုပါ။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့် ရရှိနိုင်ပါက အတည်ပြုရမည့်အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် ပရော်ဖက်ရှင်နယ် လူသား ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားခြင်းများ သို့မဟုတ် မှားယွင်းဖော်ပြမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မရှိပါ။