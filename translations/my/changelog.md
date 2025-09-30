<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T22:46:40+00:00",
  "source_file": "changelog.md",
  "language_code": "my"
}
-->
# Changelog: MCP for Beginners Curriculum

ဤစာရွက်စာတမ်းသည် Model Context Protocol (MCP) for Beginners သင်ခန်းစာများတွင် ပြုလုပ်ထားသော အရေးပါသော ပြောင်းလဲမှုများအား မှတ်တမ်းတင်ထားသော အချက်အလက်များကို ဖော်ပြထားသည်။ ပြောင်းလဲမှုများကို နောက်ဆုံးပြောင်းလဲမှုမှ စ၍ အနောက်ဆုံးအချိန်စဉ်အတိုင်း မှတ်တမ်းတင်ထားသည်။

## စက်တင်ဘာ ၂၉၊ ၂၀၂၅

### MCP Server Database Integration Labs - Comprehensive Hands-On Learning Path

#### 11-MCPServerHandsOnLabs - Database Integration Curriculum အသစ်
- **13-Lab Learning Path အပြည့်အစုံ**: PostgreSQL database integration ဖြင့် production-ready MCP servers တည်ဆောက်ရန်အတွက် လက်တွေ့ကျသော သင်ခန်းစာများကို ထည့်သွင်းထားသည်။
  - **အမှန်တကယ်အသုံးချမှု**: Zava Retail analytics use case ကို အသုံးပြု၍ စီးပွားရေးအဆင့်ပုံစံများကို ဖော်ပြထားသည်။
  - **သင်ယူမှုအဆင့်ဆင့်**:
    - **Labs 00-03: အခြေခံအဆင့်** - Introduction, Core Architecture, Security & Multi-Tenancy, Environment Setup
    - **Labs 04-06: MCP Server တည်ဆောက်ခြင်း** - Database Design & Schema, MCP Server Implementation, Tool Development  
    - **Labs 07-09: အဆင့်မြင့် Features** - Semantic Search Integration, Testing & Debugging, VS Code Integration
    - **Labs 10-12: Production & Best Practices** - Deployment Strategies, Monitoring & Observability, Best Practices & Optimization
  - **စီးပွားရေးနည်းပညာများ**: FastMCP framework, PostgreSQL with pgvector, Azure OpenAI embeddings, Azure Container Apps, Application Insights
  - **အဆင့်မြင့် Features**: Row Level Security (RLS), semantic search, multi-tenant data access, vector embeddings, real-time monitoring

#### Terminology Standardization - Module ကို Lab အဖြစ် ပြောင်းလဲခြင်း
- **Documentation အပြည့်အစုံ ပြင်ဆင်မှု**: 11-MCPServerHandsOnLabs တွင်ရှိသော README ဖိုင်များအား "Module" ကို "Lab" အဖြစ် ပြောင်းလဲထားသည်။
  - **ခေါင်းစဉ်များ**: "What This Module Covers" ကို "What This Lab Covers" အဖြစ် ပြောင်းလဲထားသည်။
  - **အကြောင်းအရာဖော်ပြချက်**: "This module provides..." ကို "This lab provides..." အဖြစ် ပြောင်းလဲထားသည်။
  - **သင်ယူရမည့်အရာများ**: "By the end of this module..." ကို "By the end of this lab..." အဖြစ် ပြောင်းလဲထားသည်။
  - **Navigation Links**: "Module XX:" ကို "Lab XX:" အဖြစ် ပြောင်းလဲထားသည်။
  - **ပြီးစီးမှု Tracking**: "After completing this module..." ကို "After completing this lab..." အဖြစ် ပြောင်းလဲထားသည်။
  - **နည်းပညာဆိုင်ရာ References**: Python module references များကို configuration files တွင် မပြောင်းလဲထားပါ (ဥပမာ `"module": "mcp_server.main"`)

#### Study Guide Enhancement (study_guide.md)
- **Visual Curriculum Map**: "11. Database Integration Labs" အပိုင်းအသစ်ကို သင်ခန်းစာဖွဲ့စည်းမှုကို ဖော်ပြထားသည်။
- **Repository Structure**: အပိုင်း ၁၀ မှ ၁၁ အပိုင်းအထိ အသေးစိတ်ဖော်ပြချက်များကို ပြင်ဆင်ထားသည်။
- **Learning Path Guidance**: အပိုင်း 00-11 အထိ navigation လမ်းညွှန်ချက်များကို တိုးမြှင့်ထားသည်။
- **နည်းပညာ Coverage**: FastMCP, PostgreSQL, Azure services integration အကြောင်းအရာများကို ထည့်သွင်းထားသည်။
- **သင်ယူရမည့်ရလဒ်များ**: production-ready server development, database integration patterns, စီးပွားရေးအဆင့်လုံခြုံရေးကို အထူးအာရုံစိုက်ထားသည်။

#### Main README Structure Enhancement
- **Lab-Based Terminology**: 11-MCPServerHandsOnLabs တွင်ရှိသော main README.md ကို "Lab" ဖွဲ့စည်းမှုအတိုင်း ပြင်ဆင်ထားသည်။
- **Learning Path Organization**: အခြေခံအကြောင်းအရာများမှ အဆင့်မြင့်အကောင်အထည်ဖော်မှုအထိ ရှင်းလင်းသော အဆင့်ဆင့်ဖွဲ့စည်းမှု။
- **အမှန်တကယ်အသုံးချမှု**: လက်တွေ့ကျသော သင်ယူမှုနှင့် စီးပွားရေးအဆင့်ပုံစံများကို အထူးအာရုံစိုက်ထားသည်။

### Documentation Quality & Consistency Improvements
- **လက်တွေ့ကျသော သင်ယူမှု**: documentation အတွင်း လက်တွေ့ကျသော lab-based approach ကို အထူးအာရုံစိုက်ထားသည်။
- **စီးပွားရေး Patterns**: production-ready implementations နှင့် စီးပွားရေးလုံခြုံရေးအချက်များကို အထူးအာရုံစိုက်ထားသည်။
- **နည်းပညာ Integration**: Azure services နှင့် AI integration patterns များကို အပြည့်အစုံဖော်ပြထားသည်။
- **သင်ယူမှုအဆင့်ဆင့်**: အခြေခံအကြောင်းအရာများမှ production deployment အထိ ရှင်းလင်းသော ဖွဲ့စည်းမှု။

## စက်တင်ဘာ ၂၆၊ ၂၀၂၅

### Case Studies Enhancement - GitHub MCP Registry Integration

#### Case Studies (09-CaseStudy/) - Ecosystem Development အာရုံစိုက်မှု
- **README.md**: GitHub MCP Registry case study ကို အပြည့်အစုံထည့်သွင်းထားသည်။
  - **GitHub MCP Registry Case Study**: GitHub ၏ MCP Registry စနစ်ကို စက်တင်ဘာ ၂၀၂၅ တွင် စတင်မိတ်ဆက်ခဲ့သော အပြည့်အစုံ case study
    - **ပြဿနာခွဲခြမ်းစိတ်ဖြာမှု**: MCP server discovery နှင့် deployment ပြဿနာများကို အပြည့်အစုံဖော်ပြထားသည်။
    - **ဖြေရှင်းနည်း Architecture**: GitHub ၏ centralized registry approach နှင့် one-click VS Code installation
    - **စီးပွားရေးသက်ရောက်မှု**: developer onboarding နှင့် productivity တိုးတက်မှုများကို တိုင်းတာထားသည်။
    - **မဟာဗျူဟာတန်ဖိုး**: modular agent deployment နှင့် cross-tool interoperability အာရုံစိုက်မှု
    - **Ecosystem Development**: agentic integration အတွက် အခြေခံပလက်ဖောင်းအဖြစ် တည်ဆောက်ထားသည်။
  - **Case Study Structure တိုးမြှင့်မှု**: case studies ခုနှစ်ခုအား consistent formatting နှင့် အပြည့်အစုံဖော်ပြချက်များဖြင့် ပြင်ဆင်ထားသည်။
    - Azure AI Travel Agents: Multi-agent orchestration အာရုံစိုက်မှု
    - Azure DevOps Integration: Workflow automation အာရုံစိုက်မှု
    - Real-Time Documentation Retrieval: Python console client အကောင်အထည်ဖော်မှု
    - Interactive Study Plan Generator: Chainlit conversational web app
    - In-Editor Documentation: VS Code နှင့် GitHub Copilot integration
    - Azure API Management: Enterprise API integration patterns
    - GitHub MCP Registry: Ecosystem development နှင့် community platform
  - **Comprehensive Conclusion**: case studies ခုနှစ်ခုအား အပြည့်အစုံဖော်ပြထားသော နိဂုံးအပိုင်းကို ပြင်ဆင်ထားသည်။
    - Enterprise Integration, Multi-Agent Orchestration, Developer Productivity
    - Ecosystem Development, Educational Applications categorization
    - Architectural patterns, implementation strategies, နှင့် best practices အပေါ် အထူးအာရုံစိုက်မှု
    - MCP ကို production-ready protocol အဖြစ် အထူးအာရုံစိုက်ထားသည်။

#### Study Guide Updates (study_guide.md)
- **Visual Curriculum Map**: Case Studies အပိုင်းတွင် GitHub MCP Registry ကို ထည့်သွင်းထားသည်။
- **Case Studies ဖော်ပြချက်**: generic descriptions မှ case studies ခုနှစ်ခု၏ အပြည့်အစုံဖော်ပြချက်များသို့ တိုးမြှင့်ထားသည်။
- **Repository Structure**: အပိုင်း ၁၀ တွင် case study အပြည့်အစုံ coverage ကို ထည့်သွင်းထားသည်။
- **Changelog Integration**: GitHub MCP Registry နှင့် case study enhancements ကို စက်တင်ဘာ ၂၆၊ ၂၀၂၅ မှတ်တမ်းအဖြစ် ထည့်သွင်းထားသည်။
- **Date Updates**: footer timestamp ကို စက်တင်ဘာ ၂၆၊ ၂၀၂၅ အဖြစ် ပြင်ဆင်ထားသည်။

### Documentation Quality Improvements
- **Consistency Enhancement**: case study formatting နှင့် structure ကို case studies ခုနှစ်ခုအတွင်း စံပြအတိုင်း ပြင်ဆင်ထားသည်။
- **Comprehensive Coverage**: case studies တွင် စီးပွားရေး၊ developer productivity နှင့် ecosystem development scenarios များကို အပြည့်အစုံဖော်ပြထားသည်။
- **Strategic Positioning**: MCP ကို agentic system deployment အတွက် အခြေခံပလက်ဖောင်းအဖြစ် အထူးအာရုံစိုက်ထားသည်။
- **Resource Integration**: GitHub MCP Registry link ကို ထည့်သွင်းထားသော အပိုဆောင်း resources များကို ပြင်ဆင်ထားသည်။

## စက်တင်ဘာ ၁၅၊ ၂၀၂၅

### Advanced Topics Expansion - Custom Transports & Context Engineering

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - Advanced Implementation Guide အသစ်
- **README.md**: custom MCP transport mechanisms အတွက် အပြည့်အစုံ implementation guide
  - **Azure Event Grid Transport**: serverless event-driven transport implementation
    - C#, TypeScript, နှင့် Python ตัวอย่างများနှင့် Azure Functions integration
    - Event-driven architecture patterns MCP solutions အတွက်
    - Webhook receivers နှင့် push-based message handling
  - **Azure Event Hubs Transport**: streaming transport implementation
    - Real-time streaming capabilities low-latency scenarios အတွက်
    - Partitioning strategies နှင့် checkpoint management
    - Message batching နှင့် performance optimization
  - **Enterprise Integration Patterns**: production-ready architectural examples
    - Distributed MCP processing Azure Functions များအတွင်း
    - Hybrid transport architectures transport types များပေါင်းစပ်မှု
    - Message durability, reliability, နှင့် error handling strategies
  - **Security & Monitoring**: Azure Key Vault integration နှင့် observability patterns
    - Managed identity authentication နှင့် least privilege access
    - Application Insights telemetry နှင့် performance monitoring
    - Circuit breakers နှင့် fault tolerance patterns
  - **Testing Frameworks**: custom transports အတွက် testing strategies
    - Unit testing test doubles နှင့် mocking frameworks
    - Integration testing Azure Test Containers
    - Performance နှင့် load testing considerations

#### Context Engineering (05-AdvancedTopics/mcp-contextengineering/) - AI Discipline အသစ်
- **README.md**: context engineering အကြောင်းအရာကို အပြည့်အစုံဖော်ပြထားသည်။
  - **Core Principles**: context sharing, action decision awareness, နှင့် context window management
  - **MCP Protocol Alignment**: MCP design context engineering challenges ကို ဖြေရှင်းပုံ
    - Context window limitations နှင့် progressive loading strategies
    - Relevance determination နှင့် dynamic context retrieval
    - Multi-modal context handling နှင့် security considerations
  - **Implementation Approaches**: Single-threaded နှင့် multi-agent architectures
    - Context chunking နှင့် prioritization techniques
    - Progressive context loading နှင့် compression strategies
    - Layered context approaches နှင့် retrieval optimization
  - **Measurement Framework**: context effectiveness evaluation metrics
    - Input efficiency, performance, quality, နှင့် user experience considerations
    - Experimental approaches context optimization
    - Failure analysis နှင့် improvement methodologies

#### Curriculum Navigation Updates (README.md)
- **Enhanced Module Structure**: curriculum table ကို Advanced Topics အသစ်များထည့်သွင်းထားသည်။
  - Context Engineering (5.14) နှင့် Custom Transport (5.15) entries ထည့်သွင်းထားသည်။
  - Consistent formatting နှင့် navigation links
  - Updated descriptions current content scope ကို ဖော်ပြထားသည်။

### Directory Structure Improvements
- **Naming Standardization**: "mcp transport" ကို "mcp-transport" အဖြစ် ပြောင်းလဲထားသည်။
- **Content Organization**: 05-AdvancedTopics folders အား mcp-[topic] pattern အတိုင်း ပြင်ဆင်ထားသည်။

### Documentation Quality Enhancements
- **MCP Specification Alignment**: MCP Specification 2025-06-18 ကို references အဖြစ် အသုံးပြုထားသည်။
- **Multi-Language Examples**: C#, TypeScript, နှင့် Python code examples
- **Enterprise Focus**: production-ready patterns နှင့် Azure cloud integration
- **Visual Documentation**: Mermaid diagrams architecture နှင့် flow visualization

## သြဂုတ် ၁၈၊ ၂၀၂၅

### Documentation Comprehensive Update - MCP 2025-06-18 Standards

#### MCP Security Best Practices (02-Security/) - Modernization အပြည့်အစုံ
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: MCP Specification 2025-06-18 နှင့်အညီ ပြင်ဆင်ထားသည်။
  - **Mandatory Requirements**: MUST/MUST NOT requirements visual indicators ဖြင့် ဖော်ပြထားသည်။
  - **12 Core Security Practices**: 15-item list မှ security domains အဖြစ် ပြောင်းလဲထားသည်။
    - Token Security & Authentication external identity provider integration
    - Session Management & Transport Security cryptographic requirements
    - AI-Specific Threat Protection Microsoft Prompt Shields integration
    - Access Control & Permissions principle of least privilege
    - Content Safety & Monitoring Azure Content Safety integration
    - Supply Chain Security component verification
    - OAuth Security & Confused Deputy Prevention PKCE implementation
    - Incident Response & Recovery automated capabilities
    - Compliance & Governance regulatory alignment
    - Advanced Security Controls zero trust architecture
    - Microsoft Security Ecosystem Integration comprehensive solutions
    - Continuous Security Evolution adaptive practices
  - **Microsoft Security Solutions**: Prompt Shields, Azure Content Safety, Entra ID, နှင့် GitHub Advanced Security
  - **Implementation Resources**: Official MCP Documentation, Microsoft Security Solutions, Security Standards, နှင့် Implementation Guides

#### Advanced Security Controls (02-Security/) - Enterprise Implementation
- **MCP-SECURITY-CONTROLS-2025.md**: enterprise-grade security framework
  - **9 Comprehensive Security Domains**: basic controls မှ enterprise framework
    - Advanced Authentication & Authorization Microsoft Entra ID integration
    - Token Security & Anti-Passthrough Controls validation
    - Session Security Controls hijacking prevention
    - AI-Specific Security Controls prompt injection နှင့် tool poisoning prevention
    - Confused Deputy Attack Prevention OAuth proxy security
    - Tool Execution Security sandboxing နှင့် isolation
    - Supply Chain Security Controls dependency verification
    - Monitoring & Detection Controls SIEM integration
    - Incident Response & Recovery automated capabilities
  - **Implementation Examples**: YAML configuration blocks နှင့် code examples
  - **Microsoft Solutions Integration**: Azure security services, GitHub Advanced Security, နှင့် enterprise identity management

#### Advanced Topics Security (05-AdvancedTopics/mcp-security/) - Production-Ready Implementation
- **README.md**: enterprise security implementation
  - **Current Specification Alignment**: MCP Specification 2025-06-18
  - **Enhanced Authentication**: Microsoft Entra ID integration .NET နှင့် Java Spring Security examples
  - **AI Security Integration**: Microsoft Prompt Shields နှင့် Azure Content Safety Python examples
  - **Advanced Threat Mitigation**: implementation examples
    - Confused Deputy Attack Prevention PKCE နှင့် user consent validation
    - Token Passthrough Prevention audience validation နှင့် secure token management
    - Session Hijacking Prevention cryptographic binding နှင့် behavioral analysis
  - **Enterprise Security Integration**: Azure Application Insights monitoring, threat detection pipelines, နှင့် supply chain security
  - **Implementation Checklist**: mandatory vs. recommended security controls Microsoft security ecosystem benefits

### Documentation Quality & Standards Alignment
- **Specification References**: MCP Specification 2025-06-18 references
- **Microsoft Security Ecosystem**: Microsoft security ecosystem integration
- **Practical Implementation**: .NET, Java, နှင့် Python code examples
- **Resource Organization**: Official documentation, security standards, နှင့် implementation guides
- **မြင်သာသောအညွှန်းများ**: မဖြစ်မဖြစ်လိုအပ်ချက်များနှင့် အကြံပြုလုပ်ဆောင်မှုများကို ရှင်းလင်းစွာ သတ်မှတ်ထားခြင်း

#### အဓိကအကြောင်းအရာများ (01-CoreConcepts/) - ခေတ်မီအပြည့်အဝ ပြုပြင်မွမ်းမံမှု
- **Protocol Version Update**: 2025-06-18 MCP Specification ကို ရည်ညွှန်းထားပြီး ရက်စွဲအခြေခံ versioning (YYYY-MM-DD format) ဖြင့် ပြုပြင်ထားသည်။
- **Architecture Refinement**: Hosts, Clients, နှင့် Servers အကြောင်းကို ယခု MCP architecture ပုံစံများနှင့် ကိုက်ညီစေရန် ပိုမိုတိကျစွာ ဖော်ပြထားသည်။
  - Hosts ကို ယခုအခါ MCP client များစွာကို စီမံခန့်ခွဲနေသော AI အက်ပလီကေးရှင်းများအဖြစ် ရှင်းလင်းစွာ သတ်မှတ်ထားသည်။
  - Clients ကို server တစ်ခုနှင့် တစ်ခုချင်းစီ ဆက်သွယ်မှုကို ထိန်းသိမ်းထားသော protocol connectors အဖြစ် ဖော်ပြထားသည်။
  - Servers ကို ဒေသတွင်း deployment နှင့် အဝေးမှ deployment ရှုထောင့်များဖြင့် တိုးတက်စွာ ဖော်ပြထားသည်။
- **Primitive Restructuring**: Server နှင့် Client primitives များကို ပြုပြင်မွမ်းမံမှုအပြည့်အဝ ပြုလုပ်ထားသည်။
  - Server Primitives: Resources (ဒေတာရင်းမြစ်များ), Prompts (template များ), Tools (အကောင်အထည်ဖော်နိုင်သော လုပ်ဆောင်မှုများ) ကို အသေးစိတ်ရှင်းလင်းချက်များနှင့် နမူနာများဖြင့် ဖော်ပြထားသည်။
  - Client Primitives: Sampling (LLM completions), Elicitation (အသုံးပြုသူ input), Logging (debugging/monitoring)
  - ယခု discovery (`*/list`), retrieval (`*/get`), နှင့် execution (`*/call`) method patterns များဖြင့် ပြုပြင်ထားသည်။
- **Protocol Architecture**: နှစ်ထပ် architecture ပုံစံကို မိတ်ဆက်ထားသည်။
  - Data Layer: JSON-RPC 2.0 အခြေခံထားပြီး lifecycle management နှင့် primitives များပါဝင်သည်။
  - Transport Layer: STDIO (ဒေသတွင်း) နှင့် Streamable HTTP with SSE (အဝေးမှ) transport mechanisms
- **Security Framework**: အသုံးပြုသူ၏ သဘောတူညီမှု, ဒေတာကိုယ်ရေးကိုယ်တာ ကာကွယ်မှု, tool execution safety, နှင့် transport layer security အပါအဝင် လုံခြုံရေးအခြေခံသဘောတရားများကို အပြည့်အဝ ဖော်ပြထားသည်။
- **Communication Patterns**: Protocol messages များကို initialization, discovery, execution, နှင့် notification flows အဖြစ် ပြုပြင်ထားသည်။
- **Code Examples**: MCP SDK patterns များနှင့် ကိုက်ညီစေရန် multi-language examples (.NET, Java, Python, JavaScript) များကို ပြုပြင်ထားသည်။

#### Security (02-Security/) - လုံခြုံရေးအပြည့်အဝ ပြုပြင်မွမ်းမံမှု  
- **Standards Alignment**: MCP Specification 2025-06-18 လုံခြုံရေးလိုအပ်ချက်များနှင့် အပြည့်အဝ ကိုက်ညီမှု
- **Authentication Evolution**: custom OAuth servers မှ Microsoft Entra ID အပြင်ပ identity provider delegation သို့ ရှင်းလင်းစွာ ဖော်ပြထားသည်။
- **AI-Specific Threat Analysis**: ခေတ်မီ AI တိုက်ခိုက်မှုများအပေါ် အကျယ်အဝန်း ဖော်ပြထားသည်။
  - Prompt injection attack နမူနာများနှင့် အမှန်တကယ်ဖြစ်ရပ်များကို အသေးစိတ်ဖော်ပြထားသည်။
  - Tool poisoning mechanisms နှင့် "rug pull" attack patterns
  - Context window poisoning နှင့် model confusion attacks
- **Microsoft AI Security Solutions**: Microsoft security ecosystem အကျယ်အဝန်း ဖော်ပြထားသည်။
  - AI Prompt Shields with advanced detection, spotlighting, နှင့် delimiter techniques
  - Azure Content Safety integration patterns
  - GitHub Advanced Security for supply chain protection
- **Advanced Threat Mitigation**: လုံခြုံရေးထိန်းချုပ်မှုများကို အသေးစိတ်ဖော်ပြထားသည်။
  - Session hijacking MCP-specific attack scenarios နှင့် cryptographic session ID လိုအပ်ချက်များ
  - Confused deputy problems MCP proxy scenarios တွင် explicit consent လိုအပ်ချက်များ
  - Token passthrough vulnerabilities mandatory validation controls
- **Supply Chain Security**: AI supply chain coverage ကို foundation models, embeddings services, context providers, နှင့် third-party APIs အပါအဝင် တိုးချဲ့ထားသည်။
- **Foundation Security**: Enterprise security patterns နှင့် zero trust architecture နှင့် Microsoft security ecosystem integration ကို တိုးတက်စွာ ဖော်ပြထားသည်။
- **Resource Organization**: အမျိုးအစားအလိုက် comprehensive resource links များကို Categorized ပြုလုပ်ထားသည် (Official Docs, Standards, Research, Microsoft Solutions, Implementation Guides)

### Documentation Quality Improvements
- **Structured Learning Objectives**: သတ်မှတ်ထားသော လေ့လာရေးရည်မှန်းချက်များကို အကျိုးရှိသော ရလဒ်များဖြင့် တိုးတက်စွာ ဖော်ပြထားသည်။
- **Cross-References**: လုံခြုံရေးနှင့် အဓိကအကြောင်းအရာများဆိုင်ရာ ချိတ်ဆက်ထားသော link များ ထည့်သွင်းထားသည်။
- **Current Information**: ရက်စွဲများနှင့် specification links များကို ယခုစံနှုန်းများနှင့် ကိုက်ညီစေရန် ပြုပြင်ထားသည်။
- **Implementation Guidance**: အဓိကအကြောင်းအရာနှင့် လုံခြုံရေးအပိုင်းများတွင် အကျိုးရှိသော implementation guidelines များ ထည့်သွင်းထားသည်။

## 2025 ခုနှစ် ဇူလိုင်လ 16 ရက်

### README နှင့် Navigation ပြုပြင်မှုများ
- README.md တွင် curriculum navigation ကို ပြုပြင်မွမ်းမံထားသည်။
- `<details>` tags များကို ပိုမိုရောက်ရှိနိုင်သော table-based format ဖြင့် အစားထိုးထားသည်။
- "alternative_layouts" folder တွင် အခြား layout ရွေးချယ်မှုများ ဖန်တီးထားသည်။
- card-based, tabbed-style, နှင့် accordion-style navigation နမူနာများ ထည့်သွင်းထားသည်။
- repository structure အပိုင်းကို နောက်ဆုံးဖိုင်များအားလုံးပါဝင်စေရန် ပြုပြင်ထားသည်။
- "How to Use This Curriculum" အပိုင်းကို ရှင်းလင်းသော အကြံပြုချက်များဖြင့် တိုးတက်စွာ ဖော်ပြထားသည်။
- MCP specification links များကို မှန်ကန်သော URLs သို့ ပြုပြင်ထားသည်။
- Context Engineering အပိုင်း (5.14) ကို curriculum structure တွင် ထည့်သွင်းထားသည်။

### Study Guide Updates
- repository structure နှင့် ကိုက်ညီစေရန် study guide ကို ပြုပြင်ထားသည်။
- MCP Clients နှင့် Tools, နှင့် Popular MCP Servers အပိုင်းများ ထည့်သွင်းထားသည်။
- Visual Curriculum Map ကို အကြောင်းအရာအားလုံးကို မှန်ကန်စွာ ဖော်ပြထားသည်။
- Advanced Topics အပိုင်းဖော်ပြချက်များကို အထူးအပိုင်းများအားလုံးကို ဖော်ပြထားသည်။
- Case Studies အပိုင်းကို အမှန်တကယ်ဖြစ်ရပ်များနှင့် ကိုက်ညီစေရန် ပြုပြင်ထားသည်။
- changelog အပြည့်အစုံကို ထည့်သွင်းထားသည်။

### Community Contributions (06-CommunityContributions/)
- ပုံရိပ်ဖန်တီးမှုအတွက် MCP servers အကြောင်း အသေးစိတ်ဖော်ပြထားသည်။
- Claude ကို VSCode တွင် အသုံးပြုခြင်းအပိုင်း Comprehensive section ထည့်သွင်းထားသည်။
- Cline terminal client setup နှင့် အသုံးပြုမှုအညွှန်းများ ထည့်သွင်းထားသည်။
- MCP client အပိုင်းကို လူကြိုက်များ client ရွေးချယ်မှုများအားလုံးပါဝင်စေရန် ပြုပြင်ထားသည်။
- အတိအကျ code နမူနာများဖြင့် contribution examples များကို တိုးတက်စွာ ဖော်ပြထားသည်။

### Advanced Topics (05-AdvancedTopics/)
- အထူးအပိုင်း folder များအားလုံးကို consistent naming ဖြင့် စီစဉ်ထားသည်။
- context engineering ပညာရပ်များနှင့် နမူနာများ ထည့်သွင်းထားသည်။
- Foundry agent integration documentation ထည့်သွင်းထားသည်။
- Entra ID security integration documentation ကို တိုးတက်စွာ ဖော်ပြထားသည်။

## 2025 ခုနှစ် ဇွန်လ 11 ရက်

### Initial Creation
- MCP for Beginners curriculum ၏ ပထမဆုံး version ကို ထုတ်ဝေခဲ့သည်။
- အဓိကအပိုင်း 10 ခုအတွက် အခြေခံဖွဲ့စည်းမှုကို ဖန်တီးခဲ့သည်။
- Visual Curriculum Map ကို navigation အတွက် ထည့်သွင်းခဲ့သည်။
- Programming language များစွာဖြင့် နမူနာပရောဂျက်များကို ထည့်သွင်းခဲ့သည်။

### Getting Started (03-GettingStarted/)
- ပထမဆုံး server implementation နမူနာများကို ဖန်တီးခဲ့သည်။
- client ဖွံ့ဖြိုးရေးအညွှန်းများ ထည့်သွင်းခဲ့သည်။
- LLM client integration အညွှန်းများ ထည့်သွင်းခဲ့သည်။
- VS Code integration documentation ထည့်သွင်းခဲ့သည်။
- Server-Sent Events (SSE) server နမူနာများ ထည့်သွင်းခဲ့သည်။

### Core Concepts (01-CoreConcepts/)
- client-server architecture အကြောင်းကို အသေးစိတ်ရှင်းလင်းစွာ ဖော်ပြခဲ့သည်။
- protocol အရေးပါသော components များကို documentation ပြုလုပ်ခဲ့သည်။
- MCP messaging patterns များကို ဖော်ပြခဲ့သည်။

## 2025 ခုနှစ် မေလ 23 ရက်

### Repository Structure
- အခြေခံ folder structure ဖြင့် repository ကို စတင်ခဲ့သည်။
- အဓိကအပိုင်းတစ်ခုစီအတွက် README ဖိုင်များ ဖန်တီးခဲ့သည်။
- translation infrastructure ကို စတင်ခဲ့သည်။
- ပုံရိပ် assets နှင့် diagrams များ ထည့်သွင်းခဲ့သည်။

### Documentation
- curriculum overview ပါဝင်သော README.md ကို စတင်ဖန်တီးခဲ့သည်။
- CODE_OF_CONDUCT.md နှင့် SECURITY.md ကို ထည့်သွင်းခဲ့သည်။
- SUPPORT.md ကို အကူအညီရယူရန် အညွှန်းများဖြင့် ဖန်တီးခဲ့သည်။
- preliminary study guide structure ကို ဖန်တီးခဲ့သည်။

## 2025 ခုနှစ် ဧပြီလ 15 ရက်

### Planning and Framework
- MCP for Beginners curriculum အတွက် စီမံကိန်းရေးဆွဲမှုကို စတင်ခဲ့သည်။
- လေ့လာရေးရည်မှန်းချက်များနှင့် ပန်းတိုင်အဖွဲ့ကို သတ်မှတ်ခဲ့သည်။
- curriculum ၏ အပိုင်း 10 ခုဖွဲ့စည်းမှုကို အကြမ်းဖျင်းရေးဆွဲခဲ့သည်။
- နမူနာများနှင့် case studies အတွက် အထူးအကြံပေး framework ကို ဖွံ့ဖြိုးခဲ့သည်။
- အဓိကအကြောင်းအရာများအတွက် prototype နမူနာများကို စတင်ဖန်တီးခဲ့သည်။

---

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းဘာသာစကားဖြင့် ရေးသားထားသော စာရွက်စာတမ်းကို အာဏာပိုင်အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူက ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွဲအချော်အချော်များ သို့မဟုတ် အနားယူမှုမှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။