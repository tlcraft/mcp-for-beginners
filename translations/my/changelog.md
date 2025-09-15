<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:38:30+00:00",
  "source_file": "changelog.md",
  "language_code": "my"
}
-->
# Changelog: MCP သင်ခန်းစာအစီအစဉ် (Beginner များအတွက်)

ဤစာရွက်စာတမ်းသည် Model Context Protocol (MCP) သင်ခန်းစာအစီအစဉ်တွင် ပြုလုပ်ခဲ့သော အရေးပါသော ပြောင်းလဲမှုများအား မှတ်တမ်းတင်ရန် ရည်ရွယ်ပါသည်။ ပြောင်းလဲမှုများကို နောက်ဆုံးပြောင်းလဲမှုမှ စတင်၍ အနောက်မှရှေ့သို့ မှတ်တမ်းတင်ထားသည်။

## စက်တင်ဘာ ၁၅၊ ၂၀၂၅

### အဆင့်မြင့်ခေါင်းစဉ်များ တိုးချဲ့ခြင်း - Custom Transports & Context Engineering

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - အဆင့်မြင့် အကောင်အထည်ဖော်လမ်းညွှန် အသစ်
- **README.md**: Custom MCP transport များအတွက် အကောင်အထည်ဖော်လမ်းညွှန် ပြည့်စုံ
  - **Azure Event Grid Transport**: Serverless event-driven transport အကောင်အထည်ဖော်မှု
    - C#, TypeScript, Python နမူနာများနှင့် Azure Functions ပေါင်းစပ်မှု
    - Scalable MCP ဖြေရှင်းချက်များအတွက် Event-driven architecture patterns
    - Webhook receivers နှင့် push-based message handling
  - **Azure Event Hubs Transport**: High-throughput streaming transport အကောင်အထည်ဖော်မှု
    - Low-latency အခြေအနေများအတွက် Real-time streaming စွမ်းရည်
    - Partitioning strategies နှင့် checkpoint management
    - Message batching နှင့် စွမ်းဆောင်ရည် တိုးတက်မှု
  - **Enterprise Integration Patterns**: ထုတ်လုပ်မှုအဆင့် architectural နမူနာများ
    - Azure Functions များအကြား MCP ကို ဖြန့်ဖြူးလုပ်ဆောင်ခြင်း
    - Transport အမျိုးအစားများ ပေါင်းစပ်ထားသော Hybrid transport architectures
    - Message durability, reliability, နှင့် error handling strategies
  - **Security & Monitoring**: Azure Key Vault ပေါင်းစပ်မှုနှင့် observability patterns
    - Managed identity authentication နှင့် least privilege access
    - Application Insights telemetry နှင့် စွမ်းဆောင်ရည် စောင့်ကြည့်မှု
    - Circuit breakers နှင့် fault tolerance patterns
  - **Testing Frameworks**: Custom transports များအတွက် စမ်းသပ်မှု strategies
    - Unit testing with test doubles နှင့် mocking frameworks
    - Integration testing with Azure Test Containers
    - Performance နှင့် load testing အတွေးအခေါ်များ

#### Context Engineering (05-AdvancedTopics/mcp-contextengineering/) - AI အဆင့်မြင့်နယ်ပယ်
- **README.md**: Context engineering ကို အကျယ်အဝန်း လေ့လာခြင်း
  - **Core Principles**: Context sharing, action decision awareness, နှင့် context window management
  - **MCP Protocol Alignment**: MCP design သည် context engineering စိန်ခေါ်မှုများကို မည်သို့ ဖြေရှင်းပေးသနည်း
    - Context window အကန့်အသတ်များနှင့် progressive loading strategies
    - Relevance determination နှင့် dynamic context retrieval
    - Multi-modal context handling နှင့် security စဉ်းစားမှုများ
  - **Implementation Approaches**: Single-threaded နှင့် multi-agent architectures
    - Context chunking နှင့် prioritization techniques
    - Progressive context loading နှင့် compression strategies
    - Layered context approaches နှင့် retrieval optimization
  - **Measurement Framework**: Context effectiveness အတွက် metrics အသစ်များ
    - Input efficiency, performance, quality, နှင့် user experience စဉ်းစားမှုများ
    - Experimental approaches to context optimization
    - Failure analysis နှင့် တိုးတက်မှုနည်းလမ်းများ

#### Curriculum Navigation Updates (README.md)
- **Enhanced Module Structure**: အဆင့်မြင့်ခေါင်းစဉ်များကို ထည့်သွင်းထားသော သင်ခန်းစာဇယားကို အဆင့်မြှင့်တင်ထားသည်
  - Context Engineering (5.14) နှင့် Custom Transport (5.15) entries ထည့်သွင်းထားသည်
  - Module အားလုံးတွင် တူညီသော format နှင့် navigation links
  - လက်ရှိ content scope ကို ရှင်းလင်းဖော်ပြထားသော updated descriptions

### Directory Structure Improvements
- **Naming Standardization**: "mcp transport" ကို "mcp-transport" ဟု အမည်ပြောင်းထားသည်
- **Content Organization**: 05-AdvancedTopics folder အားလုံးကို တူညီသော naming pattern (mcp-[topic]) ဖြင့် ပြုလုပ်ထားသည်

### Documentation Quality Enhancements
- **MCP Specification Alignment**: MCP Specification 2025-06-18 ကို ရည်ညွှန်းထားသော content အသစ်များ
- **Multi-Language Examples**: C#, TypeScript, Python code နမူနာများ
- **Enterprise Focus**: Azure cloud integration နှင့် production-ready patterns
- **Visual Documentation**: Architecture နှင့် flow visualization အတွက် Mermaid diagrams

## သြဂုတ် ၁၈၊ ၂၀၂၅

### Documentation Comprehensive Update - MCP 2025-06-18 Standards

#### MCP Security Best Practices (02-Security/) - ပြည့်စုံသော ပြုပြင်မှု
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: MCP Specification 2025-06-18 နှင့် ကိုက်ညီသော ပြုပြင်မှု
  - **Mandatory Requirements**: MUST/MUST NOT requirements များကို ရှင်းလင်းဖော်ပြထားသည်
  - **12 Core Security Practices**: Security domains အဖြစ် ပြန်လည်ဖွဲ့စည်းထားသည်
    - Token Security & Authentication
    - Session Management & Transport Security
    - AI-Specific Threat Protection
    - Access Control & Permissions
    - Content Safety & Monitoring
    - Supply Chain Security
    - OAuth Security & Confused Deputy Prevention
    - Incident Response & Recovery
    - Compliance & Governance
    - Advanced Security Controls
    - Microsoft Security Ecosystem Integration
    - Continuous Security Evolution
  - **Microsoft Security Solutions**: Prompt Shields, Azure Content Safety, Entra ID, GitHub Advanced Security
  - **Implementation Resources**: Official MCP Documentation, Microsoft Security Solutions, Security Standards, Implementation Guides

#### Advanced Security Controls (02-Security/) - Enterprise Implementation
- **MCP-SECURITY-CONTROLS-2025.md**: Enterprise-grade security framework
  - **9 Comprehensive Security Domains**: Advanced Authentication & Authorization, Token Security, Session Security, AI-Specific Security Controls, Confused Deputy Attack Prevention, Tool Execution Security, Supply Chain Security Controls, Monitoring & Detection Controls, Incident Response & Recovery
  - **Implementation Examples**: YAML configuration blocks နှင့် code နမူနာများ
  - **Microsoft Solutions Integration**: Azure security services, GitHub Advanced Security

#### Advanced Topics Security (05-AdvancedTopics/mcp-security/) - Production-Ready Implementation
- **README.md**: Enterprise security implementation အတွက် rewrite
  - **Current Specification Alignment**: MCP Specification 2025-06-18
  - **Enhanced Authentication**: Microsoft Entra ID integration
  - **AI Security Integration**: Microsoft Prompt Shields နှင့် Azure Content Safety
  - **Advanced Threat Mitigation**: Confused Deputy Attack Prevention, Token Passthrough Prevention, Session Hijacking Prevention
  - **Enterprise Security Integration**: Azure Application Insights monitoring, threat detection pipelines
  - **Implementation Checklist**: Mandatory vs. recommended security controls

### Documentation Quality & Standards Alignment
- **Specification References**: MCP Specification 2025-06-18 ကို ရည်ညွှန်းထားသည်
- **Microsoft Security Ecosystem**: Integration guidance
- **Practical Implementation**: .NET, Java, Python code နမူနာများ
- **Resource Organization**: Official documentation, security standards, implementation guides

#### Core Concepts (01-CoreConcepts/) - Complete Modernization
- **Protocol Version Update**: MCP Specification 2025-06-18 ကို ရည်ညွှန်းထားသည်
- **Architecture Refinement**: Hosts, Clients, Servers ကို ပြန်လည်ဖော်ပြထားသည်
  - Hosts: AI applications coordinating multiple MCP client connections
  - Clients: Protocol connectors maintaining one-to-one server relationships
  - Servers: Local vs. remote deployment scenarios
- **Primitive Restructuring**: Server နှင့် client primitives
  - Server Primitives: Resources, Prompts, Tools
  - Client Primitives: Sampling, Elicitation, Logging
  - Discovery (`*/list`), retrieval (`*/get`), execution (`*/call`) method patterns
- **Protocol Architecture**: Two-layer architecture model
  - Data Layer: JSON-RPC 2.0 foundation
  - Transport Layer: STDIO (local) နှင့် Streamable HTTP with SSE (remote)
- **Security Framework**: User consent, data privacy protection, tool execution safety, transport layer security
- **Communication Patterns**: Initialization, discovery, execution, notification flows
- **Code Examples**: .NET, Java, Python, JavaScript MCP SDK patterns

#### Security (02-Security/) - Comprehensive Security Overhaul  
- **Standards Alignment**: MCP Specification 2025-06-18
- **Authentication Evolution**: Microsoft Entra ID integration
- **AI-Specific Threat Analysis**: Prompt injection, tool poisoning, context window poisoning
- **Microsoft AI Security Solutions**: Prompt Shields, Azure Content Safety, GitHub Advanced Security
- **Advanced Threat Mitigation**: Session hijacking, Confused deputy problems, Token passthrough vulnerabilities
- **Supply Chain Security**: Foundation models, embeddings services, context providers, third-party APIs
- **Foundation Security**: Zero trust architecture, Microsoft security ecosystem
- **Resource Organization**: Official Docs, Standards, Research, Microsoft Solutions, Implementation Guides

### Documentation Quality Improvements
- **Structured Learning Objectives**: Specific, actionable outcomes 
- **Cross-References**: Related security နှင့် core concept topics
- **Current Information**: Updated date references
- **Implementation Guidance**: Actionable implementation guidelines

## ဇူလိုင် ၁၆၊ ၂၀၂၅

### README နှင့် Navigation Improvements
- README.md တွင် curriculum navigation ပြန်လည်ဖော်ပြထားသည်
- `<details>` tags ကို table-based format ဖြင့် အစားထိုးထားသည်
- Alternative layout options ထည့်သွင်းထားသည်
- Repository structure section ကို အဆင့်မြှင့်တင်ထားသည်
- "How to Use This Curriculum" ကို ရှင်းလင်းဖော်ပြထားသည်
- Context Engineering section (5.14) ထည့်သွင်းထားသည်

### Study Guide Updates
- Repository structure နှင့် ကိုက်ညီသော study guide
- MCP Clients နှင့် Tools, Popular MCP Servers အပိုင်းများ ထည့်သွင်းထားသည်
- Visual Curriculum Map ကို အတိအကျ ပြန်လည်ဖော်ပြထားသည်
- Advanced Topics ကို အကျယ်ဖော်ပြထားသည်
- Case Studies ကို အမှန်တကယ် နမူနာများဖြင့် ပြန်လည်ဖော်ပြထားသည်

### Community Contributions (06-CommunityContributions/)
- MCP servers for image generation
- Claude in VSCode အသုံးပြုမှု
- Cline terminal client setup နှင့် usage instructions
- MCP client options
- Contribution examples

### Advanced Topics (05-AdvancedTopics/)
- Specialized topic folders
- Context engineering materials
- Foundry agent integration documentation
- Entra ID security integration documentation

## ဇွန် ၁၁၊ ၂၀၂၅

### Initial Creation
- MCP for Beginners curriculum ၏ ပထမဆုံး version
- ၁၀ အပိုင်းအခြေခံဖွဲ့စည်းမှု
- Visual Curriculum Map
- Programming languages များအတွက် sample projects

### Getting Started (03-GettingStarted/)
- Server implementation examples
- Client development guidance
- LLM client integration instructions
- VS Code integration documentation
- Server-Sent Events (SSE) server examples

### Core Concepts (01-CoreConcepts/)
- Client-server architecture
- Key protocol components
- Messaging patterns

## မေ ၂၃၊ ၂၀၂၅

### Repository Structure
- Repository အခြေခံ folder structure
- README files
- Translation infrastructure
- Image assets နှင့် diagrams

### Documentation
- README.md
- CODE_OF_CONDUCT.md နှင့် SECURITY.md
- SUPPORT.md
- Study guide structure

## ဧပြီ ၁၅၊ ၂၀၂၅

### Planning and Framework
- MCP for Beginners curriculum အတွက် စီမံချက်
- Learning objectives နှင့် target audience
- ၁၀-section structure
- Examples နှင့် case studies
- Prototype examples

---

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါရှိနိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူရင်းဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် ရှုလေ့ရှိသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။