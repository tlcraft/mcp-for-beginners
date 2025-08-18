<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T18:32:46+00:00",
  "source_file": "changelog.md",
  "language_code": "my"
}
-->
# Changelog: MCP သင်ခန်းစာအစီအစဉ်အတွက် ပြောင်းလဲမှုမှတ်တမ်း

ဤစာရွက်စာတမ်းသည် Model Context Protocol (MCP) သင်ခန်းစာအစီအစဉ်အတွက် အရေးပါသော ပြောင်းလဲမှုများအား မှတ်တမ်းတင်ထားသော အချက်အလက်များကို ဖော်ပြထားသည်။ ပြောင်းလဲမှုများကို နောက်ဆုံးပြောင်းလဲမှုမှ စတင်၍ အနောက်ဆုံးမှတ်တမ်းတင်ထားသည်။

## ၂၀၂၅ ခုနှစ်၊ သြဂုတ်လ ၁၈ ရက်

### စာရွက်စာတမ်း အပြည့်အစုံ ပြင်ဆင်မှု - MCP 2025-06-18 စံနှုန်းများ

#### MCP လုံခြုံရေး အကောင်းဆုံး လုပ်ထုံးလုပ်နည်းများ (02-Security/) - အပြည့်အစုံ ခေတ်မီပြင်ဆင်မှု
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: MCP Specification 2025-06-18 နှင့် ကိုက်ညီသော အပြည့်အစုံ ပြန်ရေးသားမှု
  - **မဖြစ်မနေလိုအပ်ချက်များ**: တိကျသော MUST/MUST NOT လိုအပ်ချက်များကို ရှင်းလင်းသော အမြင်အာရုံပြုလက္ခဏာများဖြင့် ထည့်သွင်းထားသည်
  - **လုံခြုံရေး လုပ်ထုံးလုပ်နည်း ၁၂ ခု**: ၁၅-အချက်စာရင်းမှ လုံခြုံရေးဒိုမိန်းများအဖြစ် ပြန်လည်ဖွဲ့စည်းထားသည်
    - Token လုံခြုံရေးနှင့် အပြင် identity provider ပေါင်းစည်းမှု
    - Session စီမံခန့်ခွဲမှုနှင့် Transport လုံခြုံရေး (cryptographic လိုအပ်ချက်များ)
    - AI-specific အန္တရာယ်ကာကွယ်မှု (Microsoft Prompt Shields ပေါင်းစည်းမှု)
    - Access Control နှင့် Permissions (principle of least privilege)
    - Content လုံခြုံရေးနှင့် စောင့်ကြည့်မှု (Azure Content Safety ပေါင်းစည်းမှု)
    - Supply Chain လုံခြုံရေး (component အပြည့်အစုံ စစ်ဆေးမှု)
    - OAuth လုံခြုံရေးနှင့် Confused Deputy ကာကွယ်မှု (PKCE အကောင်အထည်ဖော်မှု)
    - အန္တရာယ်ဖြေရှင်းမှုနှင့် ပြန်လည်ထူထောင်မှု (automation capabilities)
    - Compliance နှင့် Governance (regulatory alignment)
    - အဆင့်မြင့် လုံခြုံရေးထိန်းချုပ်မှု (zero trust architecture)
    - Microsoft လုံခြုံရေး Ecosystem ပေါင်းစည်းမှု
    - လုံခြုံရေး ဆက်လက်တိုးတက်မှု (adaptive practices)
  - **Microsoft လုံခြုံရေး Solutions**: Prompt Shields, Azure Content Safety, Entra ID, GitHub Advanced Security အတွက် ပေါင်းစည်းမှု လမ်းညွှန်ချက်များ တိုးမြှင့်ထားသည်
  - **အကောင်အထည်ဖော်မှု အရင်းအမြစ်များ**: Official MCP Documentation, Microsoft Security Solutions, Security Standards, Implementation Guides အလိုက် အုပ်စုခွဲထားသော အရင်းအမြစ်လင့်များ

#### အဆင့်မြင့် လုံခြုံရေးထိန်းချုပ်မှု (02-Security/) - စီးပွားရေးလုပ်ငန်းအတွက် အကောင်အထည်ဖော်မှု
- **MCP-SECURITY-CONTROLS-2025.md**: စီးပွားရေးလုပ်ငန်းအဆင့် လုံခြုံရေး framework ဖြင့် ပြန်လည်ရေးသားမှု
  - **လုံခြုံရေးဒိုမိန်း ၉ ခု**: အခြေခံထိန်းချုပ်မှုများမှ စီးပွားရေးလုပ်ငန်းအဆင့် framework အဖြစ် တိုးချဲ့ထားသည်
    - Advanced Authentication နှင့် Authorization (Microsoft Entra ID ပေါင်းစည်းမှု)
    - Token လုံခြုံရေးနှင့် Anti-Passthrough ထိန်းချုပ်မှု
    - Session လုံခြုံရေးထိန်းချုပ်မှု (hijacking ကာကွယ်မှု)
    - AI-specific လုံခြုံရေးထိန်းချုပ်မှု (prompt injection နှင့် tool poisoning ကာကွယ်မှု)
    - Confused Deputy ကာကွယ်မှု (OAuth proxy လုံခြုံရေး)
    - Tool အကောင်အထည်ဖော်မှု လုံခြုံရေး (sandboxing နှင့် isolation)
    - Supply Chain လုံခြုံရေးထိန်းချုပ်မှု (dependency စစ်ဆေးမှု)
    - စောင့်ကြည့်မှုနှင့် ရှာဖွေမှု ထိန်းချုပ်မှု (SIEM ပေါင်းစည်းမှု)
    - အန္တရာယ်ဖြေရှင်းမှုနှင့် ပြန်လည်ထူထောင်မှု (automation capabilities)
  - **အကောင်အထည်ဖော်မှု ဥပမာများ**: YAML configuration blocks နှင့် code ဥပမာများ ထည့်သွင်းထားသည်
  - **Microsoft Solutions ပေါင်းစည်းမှု**: Azure လုံခြုံရေးဝန်ဆောင်မှုများ၊ GitHub Advanced Security နှင့် စီးပွားရေး identity စီမံခန့်ခွဲမှု

#### အဆင့်မြင့် ခေါင်းစဉ်များ လုံခြုံရေး (05-AdvancedTopics/mcp-security/) - ထုတ်လုပ်မှုအဆင့် အကောင်အထည်ဖော်မှု
- **README.md**: စီးပွားရေးလုပ်ငန်း လုံခြုံရေးအကောင်အထည်ဖော်မှုအတွက် ပြန်လည်ရေးသားမှု
  - **လက်ရှိ Specification ကိုက်ညီမှု**: MCP Specification 2025-06-18 နှင့် mandatory လုံခြုံရေးလိုအပ်ချက်များ
  - **Authentication တိုးတက်မှု**: Microsoft Entra ID ပေါင်းစည်းမှု (.NET နှင့် Java Spring Security ဥပမာများ)
  - **AI လုံခြုံရေး ပေါင်းစည်းမှု**: Microsoft Prompt Shields နှင့် Azure Content Safety (Python ဥပမာများ)
  - **အန္တရာယ်ကာကွယ်မှု တိုးတက်မှု**: PKCE နှင့် user consent validation, audience validation နှင့် secure token management, cryptographic binding နှင့် behavioral analysis
  - **စီးပွားရေး လုံခြုံရေး ပေါင်းစည်းမှု**: Azure Application Insights monitoring, threat detection pipelines, supply chain security
  - **Implementation Checklist**: Mandatory နှင့် recommended လုံခြုံရေးထိန်းချုပ်မှုများ

### စာရွက်စာတမ်း အရည်အသွေးနှင့် စံနှုန်း ကိုက်ညီမှု
- **Specification References**: MCP Specification 2025-06-18 ကို ကိုက်ညီသော references
- **Microsoft လုံခြုံရေး Ecosystem**: လုံခြုံရေးစာရွက်စာတမ်းများတွင် ပေါင်းစည်းမှု လမ်းညွှန်ချက်များ
- **အကောင်အထည်ဖော်မှု လမ်းညွှန်ချက်များ**: .NET, Java, Python code ဥပမာများ
- **အရင်းအမြစ် စီမံခန့်ခွဲမှု**: Official documentation, security standards, implementation guides အလိုက် အုပ်စုခွဲမှု
- **မြင်သာသော လက္ခဏာများ**: Mandatory လိုအပ်ချက်များနှင့် recommended လုပ်ထုံးလုပ်နည်းများ

#### အခြေခံအယူအဆများ (01-CoreConcepts/) - အပြည့်အစုံ ခေတ်မီပြင်ဆင်မှု
- **Protocol Version Update**: MCP Specification 2025-06-18 ကို YYYY-MM-DD format ဖြင့် ပြင်ဆင်ထားသည်
- **Architecture ပြင်ဆင်မှု**: Hosts, Clients, Servers အတွက် လက်ရှိ MCP architecture patterns ကို ရှင်းလင်းဖော်ပြထားသည်
  - Hosts: MCP client connections များကို စီမံခန့်ခွဲသော AI applications
  - Clients: protocol connectors (server နှင့် တစ်ဦးတည်း ဆက်သွယ်မှု)
  - Servers: local နှင့် remote deployment scenarios
- **Primitive Restructuring**: Server နှင့် client primitives အပြည့်အစုံ ပြင်ဆင်ထားသည်
  - Server Primitives: Resources, Prompts, Tools
  - Client Primitives: Sampling, Elicitation, Logging
  - Discovery (`*/list`), Retrieval (`*/get`), Execution (`*/call`) method patterns
- **Protocol Architecture**: Two-layer architecture model
  - Data Layer: JSON-RPC 2.0 foundation
  - Transport Layer: STDIO (local) နှင့် Streamable HTTP with SSE (remote)
- **လုံခြုံရေး Framework**: User consent, data privacy, tool execution safety, transport layer security
- **ဆက်သွယ်မှု ပုံစံများ**: Initialization, discovery, execution, notification flows
- **Code Examples**: .NET, Java, Python, JavaScript MCP SDK patterns

#### လုံခြုံရေး (02-Security/) - အပြည့်အစုံ ပြင်ဆင်မှု  
- **စံနှုန်း ကိုက်ညီမှု**: MCP Specification 2025-06-18
- **Authentication တိုးတက်မှု**: Microsoft Entra ID delegation
- **AI-specific အန္တရာယ်ခွဲခြားမှု**: Prompt injection, tool poisoning, context window poisoning
- **Microsoft AI လုံခြုံရေး Solutions**: Prompt Shields, Azure Content Safety, GitHub Advanced Security
- **အန္တရာယ်ကာကွယ်မှု**: Session hijacking, Confused deputy, Token passthrough vulnerabilities
- **Supply Chain လုံခြုံရေး**: Foundation models, embeddings services, context providers, third-party APIs
- **Foundation လုံခြုံရေး**: Zero trust architecture, Microsoft security ecosystem
- **အရင်းအမြစ် စီမံခန့်ခွဲမှု**: Official Docs, Standards, Research, Microsoft Solutions, Implementation Guides

### စာရွက်စာတမ်း အရည်အသွေး တိုးတက်မှု
- **Structured Learning Objectives**: သင်ယူရမည့် ရည်ရွယ်ချက်များ
- **Cross-References**: လုံခြုံရေးနှင့် အခြေခံအယူအဆများအကြား လင့်များ
- **လက်ရှိ အချက်အလက်များ**: Specification links နှင့် date references
- **Implementation Guidance**: လုပ်ထုံးလုပ်နည်းများ

## ၂၀၂၅ ခုနှစ်၊ ဇူလိုင်လ ၁၆ ရက်

### README နှင့် Navigation တိုးတက်မှု
- README.md တွင် navigation ပြန်လည်ရေးသားမှု
- `<details>` tags ကို table-based format ဖြင့် အစားထိုးထားသည်
- "alternative_layouts" folder တွင် layout options အသစ်များ ထည့်သွင်းထားသည်
- Card-based, tabbed-style, accordion-style navigation ဥပမာများ
- Repository structure section ကို အပ်ဒိတ်လုပ်ထားသည်
- "How to Use This Curriculum" section ကို ရှင်းလင်းစွာ ဖော်ပြထားသည်
- MCP specification links ကို မှန်ကန်သော URLs သို့ ပြောင်းထားသည်
- Context Engineering section (5.14) ကို curriculum structure တွင် ထည့်သွင်းထားသည်

### Study Guide Updates
- Repository structure နှင့် ကိုက်ညီသော study guide ပြင်ဆင်မှု
- MCP Clients နှင့် Tools, Popular MCP Servers အပိုင်းများ ထည့်သွင်းထားသည်
- Visual Curriculum Map ကို အပ်ဒိတ်လုပ်ထားသည်
- Advanced Topics အပိုင်းများကို တိုးချဲ့ဖော်ပြထားသည်
- Case Studies အပိုင်းကို အမှန်တကယ် ဥပမာများဖြင့် ပြင်ဆင်ထားသည်
- Comprehensive changelog ကို ထည့်သွင်းထားသည်

### Community Contributions (06-CommunityContributions/)
- MCP servers အကြောင်း အသေးစိတ် အချက်အလက်များ
- Claude ကို VSCode တွင် အသုံးပြုခြင်း
- Cline terminal client setup နှင့် အသုံးပြုမှု
- MCP client options အားလုံးကို ထည့်သွင်းထားသည်
- Contribution examples ကို တိကျသော code samples ဖြင့် တိုးတက်မှု

### Advanced Topics (05-AdvancedTopics/)
- Specialized topic folders ကို consistent naming ဖြင့် စီမံထားသည်
- Context engineering materials နှင့် examples
- Foundry agent integration documentation
- Entra ID security integration documentation

## ၂၀၂၅ ခုနှစ်၊ ဇွန်လ ၁၁ ရက်

### စတင်ဖန်တီးမှု
- MCP for Beginners curriculum ၏ ပထမဆုံး version ထုတ်ဝေခဲ့သည်
- အဓိကအပိုင်း ၁၀ ခုအတွက် အခြေခံဖွဲ့စည်းမှု ဖန်တီးခဲ့သည်
- Visual Curriculum Map ကို navigation အတွက် ထည့်သွင်းခဲ့သည်
- Programming languages များစွာဖြင့် sample projects ထည့်သွင်းခဲ့သည်

### Getting Started (03-GettingStarted/)
- Server implementation examples ပထမဆုံး ဖန်တီးခဲ့သည်
- Client development လမ်းညွှန်ချက်များ ထည့်သွင်းခဲ့သည်
- LLM client integration လမ်းညွှန်ချက်များ
- VS Code integration documentation
- Server-Sent Events (SSE) server examples

### Core Concepts (01-CoreConcepts/)
- Client-server architecture အကြောင်း အသေးစိတ် ရှင်းလင်းဖော်ပြခဲ့သည်
- Protocol components အရေးပါသော အချက်များ
- MCP messaging patterns

## ၂၀၂၅ ခုနှစ်၊ မေလ ၂၃ ရက်

### Repository Structure
- Repository ကို အခြေခံ folder structure ဖြင့် စတင်ခဲ့သည်
- အဓိကအပိုင်းများအတွက် README files ဖန်တီးခဲ့သည်
- Translation infrastructure တည်ဆောက်ခဲ့သည်
- Image assets နှင့် diagrams ထည့်သွင်းခဲ့သည်

### Documentation
- Curriculum overview ပါဝင်သော README.md စတင်ရေးသားခဲ့သည်
- CODE_OF_CONDUCT.md နှင့် SECURITY.md
- SUPPORT.md ကို အကူအညီရယူရန် လမ်းညွှန်ချက်များဖြင့် ဖန်တီးခဲ့သည်
- Preliminary study guide structure

## ၂၀၂၅ ခုနှစ်၊ ဧပြီလ ၁၅ ရက်

### Planning နှင့် Framework
- MCP for Beginners curriculum အတွက် စီမံကိန်းရေးဆွဲမှု
- သင်ယူရမည့် ရည်ရွယ်ချက်များနှင့် ပန်းတိုင် audience သတ်မှတ်မှု
- Curriculum ၏ ၁၀-အပိုင်း ဖွဲ့စည်းမှု
- ဥပမာများနှင့် case studies အတွက် conceptual framework
- အဓိကအယူအဆများအတွက် prototype examples ဖန်တီးခဲ့သည်

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ဆိုမှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူလဘာသာစကားဖြင့် ရေးသားထားသော စာရွက်စာတမ်းကို အာဏာတည်သော ရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူသားပညာရှင်များမှ ဘာသာပြန်ဆိုမှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်ဆိုမှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပါယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။