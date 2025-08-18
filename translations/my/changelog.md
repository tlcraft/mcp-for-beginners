<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T23:11:20+00:00",
  "source_file": "changelog.md",
  "language_code": "my"
}
-->
# Changelog: MCP for Beginners Curriculum

ဤစာရွက်စာတမ်းသည် Model Context Protocol (MCP) for Beginners သင်ခန်းစာများတွင် ပြုလုပ်ခဲ့သော အရေးပါသော ပြောင်းလဲမှုများအား မှတ်တမ်းတင်ထားသော အချက်အလက်များကို ဖော်ပြထားသည်။ ပြောင်းလဲမှုများကို နောက်ဆုံးပြောင်းလဲမှုများကို အရင်ဖော်ပြပြီး အနောက်ဆုံးမှစ၍ မှတ်တမ်းတင်ထားသည်။

## ၂၀၂၅ ခုနှစ်၊ သြဂုတ်လ ၁၈ ရက်

### Documentation Comprehensive Update - MCP 2025-06-18 Standards

#### MCP Security Best Practices (02-Security/) - ပြည့်စုံသော ပြုပြင်မွမ်းမံမှု
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: MCP Specification 2025-06-18 နှင့် ကိုက်ညီစေရန် ပြန်လည်ရေးသားမှု
  - **မဖြစ်မနေလိုအပ်ချက်များ**: တိကျသော MUST/MUST NOT လိုအပ်ချက်များကို ရှင်းလင်းသော အထောက်အထားများဖြင့် ထည့်သွင်းထားသည်
  - **Core Security Practices ၁၂ ခု**: ၁၅-အချက်စာရင်းမှ Comprehensive Security Domains အဖြစ် ပြုပြင်ထားသည်
    - Token Security & Authentication (identity provider အပြင်ပေါ်တွင် ပေါင်းစည်းမှု)
    - Session Management & Transport Security (cryptographic လိုအပ်ချက်များ)
    - AI-Specific Threat Protection (Microsoft Prompt Shields integration)
    - Access Control & Permissions (principle of least privilege)
    - Content Safety & Monitoring (Azure Content Safety integration)
    - Supply Chain Security (component verification)
    - OAuth Security & Confused Deputy Prevention (PKCE implementation)
    - Incident Response & Recovery (automation capabilities)
    - Compliance & Governance (regulatory alignment)
    - Advanced Security Controls (zero trust architecture)
    - Microsoft Security Ecosystem Integration (comprehensive solutions)
    - Continuous Security Evolution (adaptive practices)
  - **Microsoft Security Solutions**: Prompt Shields, Azure Content Safety, Entra ID, GitHub Advanced Security အတွက် ပေါင်းစည်းမှု လမ်းညွှန်ချက်များကို တိုးမြှင့်ထားသည်
  - **Implementation Resources**: Official MCP Documentation, Microsoft Security Solutions, Security Standards, Implementation Guides အလိုက် အရင်းအမြစ်များကို အမျိုးအစားခွဲထားသည်

#### Advanced Security Controls (02-Security/) - စီးပွားရေးအဆင့် အကောင်အထည်ဖော်မှု
- **MCP-SECURITY-CONTROLS-2025.md**: စီးပွားရေးအဆင့် Security Framework ဖြင့် ပြုပြင်မွမ်းမံမှု
  - **Comprehensive Security Domains ၉ ခု**: အခြေခံထိန်းချုပ်မှုများမှ စီးပွားရေးအဆင့် Framework အဖြစ် တိုးချဲ့ထားသည်
    - Advanced Authentication & Authorization (Microsoft Entra ID integration)
    - Token Security & Anti-Passthrough Controls (comprehensive validation)
    - Session Security Controls (hijacking prevention)
    - AI-Specific Security Controls (prompt injection နှင့် tool poisoning prevention)
    - Confused Deputy Attack Prevention (OAuth proxy security)
    - Tool Execution Security (sandboxing နှင့် isolation)
    - Supply Chain Security Controls (dependency verification)
    - Monitoring & Detection Controls (SIEM integration)
    - Incident Response & Recovery (automation capabilities)
  - **Implementation Examples**: YAML configuration blocks နှင့် code examples များကို ထည့်သွင်းထားသည်
  - **Microsoft Solutions Integration**: Azure security services, GitHub Advanced Security, enterprise identity management အတွက် Comprehensive coverage

#### Advanced Topics Security (05-AdvancedTopics/mcp-security/) - ထုတ်လုပ်မှုအဆင့် အကောင်အထည်ဖော်မှု
- **README.md**: စီးပွားရေးအဆင့် Security Implementation အတွက် ပြန်လည်ရေးသားမှု
  - **Current Specification Alignment**: MCP Specification 2025-06-18 နှင့် ကိုက်ညီစေရန် ပြုပြင်ထားသည်
  - **Enhanced Authentication**: Microsoft Entra ID integration (.NET နှင့် Java Spring Security examples)
  - **AI Security Integration**: Microsoft Prompt Shields နှင့် Azure Content Safety implementation (Python examples)
  - **Advanced Threat Mitigation**: PKCE နှင့် user consent validation, audience validation, session hijacking prevention အတွက် Comprehensive implementation examples
  - **Enterprise Security Integration**: Azure Application Insights monitoring, threat detection pipelines, supply chain security
  - **Implementation Checklist**: Mandatory နှင့် recommended security controls များကို ရှင်းလင်းစွာ ဖော်ပြထားသည်

### Documentation Quality & Standards Alignment
- **Specification References**: MCP Specification 2025-06-18 ကို ကိုက်ညီစေရန် ပြုပြင်ထားသည်
- **Microsoft Security Ecosystem**: Security documentation အတွင်း ပေါင်းစည်းမှု လမ်းညွှန်ချက်များကို တိုးမြှင့်ထားသည်
- **Practical Implementation**: .NET, Java, Python code examples များကို ထည့်သွင်းထားသည်
- **Resource Organization**: Official documentation, security standards, implementation guides အလိုက် Categorization ပြုလုပ်ထားသည်
- **Visual Indicators**: Mandatory requirements နှင့် recommended practices များကို ရှင်းလင်းစွာ ဖော်ပြထားသည်

#### Core Concepts (01-CoreConcepts/) - ပြည့်စုံသော ပြုပြင်မွမ်းမံမှု
- **Protocol Version Update**: MCP Specification 2025-06-18 ကို YYYY-MM-DD format ဖြင့် ပြုပြင်ထားသည်
- **Architecture Refinement**: Hosts, Clients, Servers အတွက် ဖော်ပြချက်များကို တိုးမြှင့်ထားသည်
  - Hosts: AI applications coordinating multiple MCP client connections
  - Clients: Protocol connectors maintaining one-to-one server relationships
  - Servers: Local နှင့် remote deployment scenarios
- **Primitive Restructuring**: Server နှင့် client primitives များကို ပြုပြင်ထားသည်
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
- **Standards Alignment**: MCP Specification 2025-06-18 security requirements
- **Authentication Evolution**: Custom OAuth servers မှ external identity provider delegation (Microsoft Entra ID)
- **AI-Specific Threat Analysis**: Prompt injection, tool poisoning, context window poisoning, model confusion attacks
- **Microsoft AI Security Solutions**: Prompt Shields, Azure Content Safety, GitHub Advanced Security
- **Advanced Threat Mitigation**: Session hijacking, confused deputy problems, token passthrough vulnerabilities
- **Supply Chain Security**: Foundation models, embeddings services, context providers, third-party APIs
- **Foundation Security**: Zero trust architecture နှင့် Microsoft security ecosystem
- **Resource Organization**: Official Docs, Standards, Research, Microsoft Solutions, Implementation Guides

### Documentation Quality Improvements
- **Structured Learning Objectives**: သင်ယူရမည့် ရည်ရွယ်ချက်များကို တိုးမြှင့်ထားသည်
- **Cross-References**: Security နှင့် core concept topics များအကြား ချိတ်ဆက်ထားသည်
- **Current Information**: Date references နှင့် specification links များကို ပြုပြင်ထားသည်
- **Implementation Guidance**: အကောင်အထည်ဖော်မှု လမ်းညွှန်ချက်များကို ထည့်သွင်းထားသည်

## ၂၀၂၅ ခုနှစ်၊ ဇူလိုင်လ ၁၆ ရက်

### README နှင့် Navigation Improvements
- README.md တွင် navigation ကို ပြန်လည်ရေးသားထားသည်
- `<details>` tags များကို table-based format ဖြင့် အစားထိုးထားသည်
- "alternative_layouts" folder တွင် layout options များ ထည့်သွင်းထားသည်
- Card-based, tabbed-style, accordion-style navigation examples များ ထည့်သွင်းထားသည်
- Repository structure section ကို ပြုပြင်ထားသည်
- "How to Use This Curriculum" ကို ရှင်းလင်းစွာ ဖော်ပြထားသည်
- MCP specification links များကို မှန်ကန်သော URLs သို့ ပြောင်းထားသည်
- Context Engineering section (5.14) ကို curriculum structure တွင် ထည့်သွင်းထားသည်

### Study Guide Updates
- Repository structure နှင့် ကိုက်ညီစေရန် Study Guide ကို ပြုပြင်ထားသည်
- MCP Clients နှင့် Tools, Popular MCP Servers အပိုင်းများကို ထည့်သွင်းထားသည်
- Visual Curriculum Map ကို အတိအကျ ပြုပြင်ထားသည်
- Advanced Topics အပိုင်းများကို တိုးချဲ့ထားသည်
- Case Studies section ကို အမှန်တကယ် ဥပမာများဖြင့် ပြုပြင်ထားသည်
- Comprehensive changelog ကို ထည့်သွင်းထားသည်

### Community Contributions (06-CommunityContributions/)
- Image generation MCP servers အတွက် အချက်အလက်များ ထည့်သွင်းထားသည်
- Claude in VSCode အသုံးပြုမှုအပိုင်းကို ထည့်သွင်းထားသည်
- Cline terminal client setup နှင့် usage instructions
- MCP client options များကို ပြည့်စုံစွာ ဖော်ပြထားသည်
- Contribution examples များကို တိုးမြှင့်ထားသည်

### Advanced Topics (05-AdvancedTopics/)
- Specialized topic folders များကို consistent naming ဖြင့် စီစဉ်ထားသည်
- Context engineering materials နှင့် examples
- Foundry agent integration documentation
- Entra ID security integration documentation

## ၂၀၂၅ ခုနှစ်၊ ဇွန်လ ၁၁ ရက်

### Initial Creation
- MCP for Beginners curriculum ၏ ပထမဆုံး version ကို ထုတ်ဝေခဲ့သည်
- ၁၀ အပိုင်းအခြေခံဖွဲ့စည်းမှုကို ဖန်တီးခဲ့သည်
- Visual Curriculum Map ကို navigation အတွက် ထည့်သွင်းခဲ့သည်
- Programming languages များအတွက် initial sample projects များ ထည့်သွင်းခဲ့သည်

### Getting Started (03-GettingStarted/)
- Server implementation examples များကို ဖန်တီးခဲ့သည်
- Client development guidance ကို ထည့်သွင်းခဲ့သည်
- LLM client integration instructions
- VS Code integration documentation
- Server-Sent Events (SSE) server examples

### Core Concepts (01-CoreConcepts/)
- Client-server architecture အကြောင်းကို ရှင်းလင်းစွာ ဖော်ပြခဲ့သည်
- Key protocol components အကြောင်းကို documentation ပြုလုပ်ခဲ့သည်
- Messaging patterns in MCP

## ၂၀၂၅ ခုနှစ်၊ မေလ ၂၃ ရက်

### Repository Structure
- Repository ကို အခြေခံ folder structure ဖြင့် စတင်ခဲ့သည်
- README files များကို major sections အလိုက် ဖန်တီးခဲ့သည်
- Translation infrastructure ကို စတင်ခဲ့သည်
- Image assets နှင့် diagrams များကို ထည့်သွင်းခဲ့သည်

### Documentation
- Curriculum overview ပါဝင်သော README.md ကို စတင်ရေးသားခဲ့သည်
- CODE_OF_CONDUCT.md နှင့် SECURITY.md ကို ဖန်တီးခဲ့သည်
- SUPPORT.md ကို အကူအညီရယူရန် လမ်းညွှန်ချက်များဖြင့် ဖန်တီးခဲ့သည်
- Preliminary study guide structure ကို ဖန်တီးခဲ့သည်

## ၂၀၂၅ ခုနှစ်၊ ဧပြီလ ၁၅ ရက်

### Planning and Framework
- MCP for Beginners curriculum အတွက် စီမံကိန်းရေးဆွဲခဲ့သည်
- Learning objectives နှင့် target audience ကို သတ်မှတ်ခဲ့သည်
- Curriculum ၏ ၁၀-section structure ကို အကြမ်းဖျင်းရေးဆွဲခဲ့သည်
- Examples နှင့် case studies အတွက် conceptual framework ကို ဖန်တီးခဲ့သည်
- Key concepts အတွက် initial prototype examples များကို ဖန်တီးခဲ့သည်

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအမှားများ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။