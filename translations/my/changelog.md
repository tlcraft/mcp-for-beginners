<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-19T18:28:55+00:00",
  "source_file": "changelog.md",
  "language_code": "my"
}
-->
# Changelog: MCP သင်ခန်းစာအစီအစဉ်အတွက် ပြောင်းလဲမှုများ

ဤစာရွက်စာတမ်းသည် Model Context Protocol (MCP) သင်ခန်းစာအစီအစဉ်အတွက် အရေးပါသော ပြောင်းလဲမှုများအား မှတ်တမ်းတင်ထားသော အချက်အလက်များကို ဖော်ပြထားသည်။ ပြောင်းလဲမှုများကို နောက်ဆုံးအပ်ဒိတ်မှ စတင်၍ အနောက်ဆုံးအပ်ဒိတ်အတိုင်း စီစဉ်ထားသည်။

## ၂၀၂၅ ခုနှစ်၊ သြဂုတ်လ ၁၈ ရက်

### စာရွက်စာတမ်း အပြည့်အစုံ အပ်ဒိတ် - MCP 2025-06-18 စံနှုန်းများ

#### MCP လုံခြုံရေး အကောင်းဆုံး လုပ်ထုံးလုပ်နည်းများ (02-Security/) - ပြည့်စုံသော ခေတ်မီပြောင်းလဲမှု
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: MCP Specification 2025-06-18 နှင့် ကိုက်ညီသော အပြည့်အစုံ ပြန်ရေးသားမှု
  - **မဖြစ်မနေလိုအပ်ချက်များ**: တိကျသော MUST/MUST NOT လိုအပ်ချက်များကို ရှင်းလင်းသော အထောက်အထားများဖြင့် ထည့်သွင်းထားသည်
  - **လုံခြုံရေး လုပ်ထုံးလုပ်နည်း ၁၂ ခု**: ၁၅ ခုမှ ၁၂ ခုအထိ ပြန်လည်ဖွဲ့စည်းထားပြီး လုံခြုံရေးကဏ္ဍများအဖြစ် ဖော်ပြထားသည်
    - Token လုံခြုံရေးနှင့် အပြင် Identity Provider ပေါင်းစည်းမှု
    - Session စီမံခန့်ခွဲမှုနှင့် Transport လုံခြုံရေး (cryptographic လိုအပ်ချက်များ)
    - AI-specific အန္တရာယ်ကာကွယ်မှု (Microsoft Prompt Shields ပေါင်းစည်းမှု)
    - Access Control နှင့် Permissions (အနည်းဆုံး လိုအပ်ချက်များ)
    - Content လုံခြုံရေးနှင့် စောင့်ကြည့်မှု (Azure Content Safety ပေါင်းစည်းမှု)
    - Supply Chain လုံခြုံရေး (component အတည်ပြုမှု)
    - OAuth လုံခြုံရေးနှင့် Confused Deputy ကာကွယ်မှု (PKCE အကောင်အထည်ဖော်မှု)
    - အန္တရာယ်ဖြေရှင်းမှုနှင့် ပြန်လည်ထူထောင်မှု (automation စနစ်များ)
    - Compliance နှင့် Governance (စည်းမျဉ်းများနှင့် ကိုက်ညီမှု)
    - ခေတ်မီ လုံခြုံရေး ထိန်းချုပ်မှုများ (zero trust architecture)
    - Microsoft လုံခြုံရေး Ecosystem ပေါင်းစည်းမှု
    - လုံခြုံရေး ဆက်လက်တိုးတက်မှု (adaptive လုပ်ထုံးလုပ်နည်းများ)
  - **Microsoft လုံခြုံရေး ဖြေရှင်းနည်းများ**: Prompt Shields, Azure Content Safety, Entra ID, GitHub Advanced Security အတွက် ပေါင်းစည်းမှု လမ်းညွှန်ချက်များ တိုးမြှင့်ထားသည်
  - **အကောင်အထည်ဖော်မှု အရင်းအမြစ်များ**: Official MCP Documentation, Microsoft Security Solutions, Security Standards, Implementation Guides အလိုက် အုပ်စုခွဲထားသည်

#### ခေတ်မီ လုံခြုံရေး ထိန်းချုပ်မှုများ (02-Security/) - စီးပွားရေးအဆင့် အကောင်အထည်ဖော်မှု
- **MCP-SECURITY-CONTROLS-2025.md**: စီးပွားရေးအဆင့် လုံခြုံရေး framework ဖြင့် ပြန်လည်ရေးသားမှု
  - **လုံခြုံရေး ကဏ္ဍ ၉ ခု**: အခြေခံထိန်းချုပ်မှုများမှ စီးပွားရေးအဆင့် framework အထိ တိုးချဲ့ထားသည်
    - Advanced Authentication နှင့် Authorization (Microsoft Entra ID ပေါင်းစည်းမှု)
    - Token လုံခြုံရေးနှင့် Anti-Passthrough ထိန်းချုပ်မှုများ
    - Session လုံခြုံရေး ထိန်းချုပ်မှုများ
    - AI-specific လုံခြုံရေး ထိန်းချုပ်မှုများ
    - Confused Deputy ကာကွယ်မှု (OAuth proxy လုံခြုံရေး)
    - Tool အကောင်အထည်ဖော်မှု လုံခြုံရေး (sandboxing နှင့် isolation)
    - Supply Chain လုံခြုံရေး ထိန်းချုပ်မှုများ
    - စောင့်ကြည့်မှုနှင့် အန္တရာယ်ရှာဖွေမှု (SIEM ပေါင်းစည်းမှု)
    - အန္တရာယ်ဖြေရှင်းမှုနှင့် ပြန်လည်ထူထောင်မှု (automation စနစ်များ)
  - **အကောင်အထည်ဖော်မှု ဥပမာများ**: YAML configuration blocks နှင့် code ဥပမာများ ထည့်သွင်းထားသည်
  - **Microsoft Solutions Integration**: Azure လုံခြုံရေးဝန်ဆောင်မှုများ၊ GitHub Advanced Security နှင့် စီးပွားရေး identity စီမံခန့်ခွဲမှုများကို အပြည့်အစုံ ဖော်ပြထားသည်

#### ခေတ်မီ လုံခြုံရေး Advanced Topics (05-AdvancedTopics/mcp-security/) - ထုတ်လုပ်မှုအဆင့် အကောင်အထည်ဖော်မှု
- **README.md**: စီးပွားရေး လုံခြုံရေး အကောင်အထည်ဖော်မှုအတွက် ပြန်လည်ရေးသားမှု
  - **လက်ရှိ Specification ကိုက်ညီမှု**: MCP Specification 2025-06-18 နှင့် mandatory လုံခြုံရေးလိုအပ်ချက်များကို အပ်ဒိတ်လုပ်ထားသည်
  - **Authentication တိုးတက်မှု**: Microsoft Entra ID ပေါင်းစည်းမှု (.NET နှင့် Java Spring Security ဥပမာများ)
  - **AI လုံခြုံရေး ပေါင်းစည်းမှု**: Microsoft Prompt Shields နှင့် Azure Content Safety အကောင်အထည်ဖော်မှု (Python ဥပမာများ)
  - **အန္တရာယ် ကာကွယ်မှု**: PKCE နှင့် user consent validation, audience validation, cryptographic binding နှင့် behavioral analysis အတွက် အကောင်အထည်ဖော်မှု ဥပမာများ
  - **စီးပွားရေး လုံခြုံရေး ပေါင်းစည်းမှု**: Azure Application Insights monitoring, threat detection pipelines, supply chain security
  - **အကောင်အထည်ဖော်မှု စစ်ဆေးစာရင်း**: Microsoft security ecosystem အကျိုးကျေးဇူးများနှင့် mandatory vs. recommended လုံခြုံရေး ထိန်းချုပ်မှုများ

### စာရွက်စာတမ်း အရည်အသွေးနှင့် စံနှုန်း ကိုက်ညီမှု
- **Specification References**: MCP Specification 2025-06-18 ကို ကိုက်ညီသော references အားလုံးကို အပ်ဒိတ်လုပ်ထားသည်
- **Microsoft Security Ecosystem**: လုံခြုံရေး စာရွက်စာတမ်းများတွင် ပေါင်းစည်းမှု လမ်းညွှန်ချက်များ တိုးမြှင့်ထားသည်
- **အကောင်အထည်ဖော်မှု လမ်းညွှန်ချက်များ**: .NET, Java, Python အတွက် အကောင်အထည်ဖော်မှု ဥပမာများ ထည့်သွင်းထားသည်
- **အရင်းအမြစ် စီစဉ်မှု**: Official documentation, security standards, implementation guides အလိုက် အုပ်စုခွဲထားသည်
- **မြင်သာသော အထောက်အထားများ**: မဖြစ်မနေလိုအပ်ချက်များနှင့် အကြံပြုချက်များကို ရှင်းလင်းစွာ ဖော်ပြထားသည်

#### အခြေခံ အယူအဆများ (01-CoreConcepts/) - ပြည့်စုံသော ခေတ်မီပြောင်းလဲမှု
- **Protocol Version Update**: MCP Specification 2025-06-18 ကို ကိုက်ညီသော versioning (YYYY-MM-DD format) အပ်ဒိတ်လုပ်ထားသည်
- **Architecture Refinement**: Hosts, Clients, Servers အတွက် လက်ရှိ MCP architecture patterns ကို ရှင်းလင်းစွာ ဖော်ပြထားသည်
  - Hosts ကို MCP client connections များကို စီမံခန့်ခွဲသော AI applications အဖြစ် ဖော်ပြထားသည်
  - Clients ကို protocol connectors အဖြစ် ဖော်ပြထားသည်
  - Servers ကို local နှင့် remote deployment scenarios အဖြစ် ဖော်ပြထားသည်
- **Primitive Restructuring**: Server နှင့် Client primitives အား ပြန်လည်ဖွဲ့စည်းထားသည်
  - Server Primitives: Resources (data sources), Prompts (templates), Tools (executable functions)
  - Client Primitives: Sampling (LLM completions), Elicitation (user input), Logging (debugging/monitoring)
  - Discovery (`*/list`), Retrieval (`*/get`), Execution (`*/call`) method patterns ကို အပ်ဒိတ်လုပ်ထားသည်
- **Protocol Architecture**: Two-layer architecture model ကို ဖော်ပြထားသည်
  - Data Layer: JSON-RPC 2.0 foundation
  - Transport Layer: STDIO (local) နှင့် Streamable HTTP with SSE (remote)
- **Security Framework**: User consent, data privacy, tool execution safety, transport layer security အတွက် လုံခြုံရေး စံနှုန်းများ
- **Communication Patterns**: Protocol messages အတွက် initialization, discovery, execution, notification flows ကို ဖော်ပြထားသည်
- **Code Examples**: .NET, Java, Python, JavaScript အတွက် MCP SDK patterns ကို အပ်ဒိတ်လုပ်ထားသည်

#### လုံခြုံရေး (02-Security/) - ပြည့်စုံသော လုံခြုံရေး ပြောင်းလဲမှု  
- **Standards Alignment**: MCP Specification 2025-06-18 လုံခြုံရေးလိုအပ်ချက်များနှင့် ကိုက်ညီမှု
- **Authentication Evolution**: Custom OAuth servers မှ external identity provider delegation (Microsoft Entra ID) သို့ ပြောင်းလဲမှု
- **AI-Specific Threat Analysis**: ခေတ်မီ AI အန္တရာယ်များကို ဖော်ပြထားသည်
  - Prompt injection attack scenarios
  - Tool poisoning mechanisms
  - Context window poisoning နှင့် model confusion attacks
- **Microsoft AI Security Solutions**: Microsoft security ecosystem အတွက် အပြည့်အစုံ coverage
  - AI Prompt Shields
  - Azure Content Safety integration patterns
  - GitHub Advanced Security
- **Advanced Threat Mitigation**: MCP-specific attack scenarios အတွက် လုံခြုံရေး ထိန်းချုပ်မှုများ
  - Session hijacking
  - Confused deputy problems
  - Token passthrough vulnerabilities
- **Supply Chain Security**: AI supply chain coverage
- **Foundation Security**: Zero trust architecture နှင့် Microsoft security ecosystem
- **Resource Organization**: Official Docs, Standards, Research, Microsoft Solutions, Implementation Guides အလိုက် အုပ်စုခွဲထားသည်

### စာရွက်စာတမ်း အရည်အသွေး တိုးတက်မှုများ
- **Structured Learning Objectives**: သင်ယူရမည့် ရည်မှန်းချက်များကို တိကျစွာ ဖော်ပြထားသည်
- **Cross-References**: လုံခြုံရေးနှင့် အခြေခံ အယူအဆများအကြား ချိတ်ဆက်ထားသည်
- **Current Information**: Date references နှင့် specification links ကို အပ်ဒိတ်လုပ်ထားသည်
- **Implementation Guidance**: အကောင်အထည်ဖော်မှု လမ်းညွှန်ချက်များ ထည့်သွင်းထားသည်

## ၂၀၂၅ ခုနှစ်၊ ဇူလိုင်လ ၁၆ ရက်

### README နှင့် Navigation တိုးတက်မှုများ
- README.md တွင် navigation ကို ပြန်လည်ဖွဲ့စည်းထားသည်
- `<details>` tags များကို table-based format ဖြင့် အစားထိုးထားသည်
- "alternative_layouts" folder တွင် layout options များ ထည့်သွင်းထားသည်
- Card-based, tabbed-style, accordion-style navigation ဥပမာများ ထည့်သွင်းထားသည်
- Repository structure ကို အပ်ဒိတ်လုပ်ထားသည်
- "How to Use This Curriculum" အပိုင်းကို ရှင်းလင်းစွာ ဖော်ပြထားသည်
- MCP specification links ကို မှန်ကန်သော URLs သို့ ပြောင်းလဲထားသည်
- Context Engineering အပိုင်း (5.14) ကို curriculum structure တွင် ထည့်သွင်းထားသည်

### Study Guide Updates
- Repository structure နှင့် ကိုက်ညီသော study guide ကို ပြန်လည်ရေးသားထားသည်
- MCP Clients နှင့် Tools, Popular MCP Servers အပိုင်းများ ထည့်သွင်းထားသည်
- Visual Curriculum Map ကို အပ်ဒိတ်လုပ်ထားသည်
- Advanced Topics အပိုင်းကို တိုးချဲ့ဖော်ပြထားသည်
- Case Studies အပိုင်းကို အမှန်တကယ် ဥပမာများဖြင့် အပ်ဒိတ်လုပ်ထားသည်
- Comprehensive changelog ကို ထည့်သွင်းထားသည်

### Community Contributions (06-CommunityContributions/)
- MCP servers အတွက် အချက်အလက်များ ထည့်သွင်းထားသည်
- Claude ကို VSCode တွင် အသုံးပြုခြင်းအပိုင်း ထည့်သွင်းထားသည်
- Cline terminal client setup နှင့် အသုံးပြုခြင်း လမ်းညွှန်ချက်များ ထည့်သွင်းထားသည်
- MCP client အပိုင်းကို popular client options များနှင့် အပ်ဒိတ်လုပ်ထားသည်
- Contribution examples ကို code samples များဖြင့် တိုးမြှင့်ထားသည်

### Advanced Topics (05-AdvancedTopics/)
- Specialized topic folders များကို consistent naming ဖြင့် စီစဉ်ထားသည်
- Context engineering materials နှင့် examples ထည့်သွင်းထားသည်
- Foundry agent integration documentation ထည့်သွင်းထားသည်
- Entra ID security integration documentation တိုးမြှင့်ထားသည်

## ၂၀၂၅ ခုနှစ်၊ ဇွန်လ ၁၁ ရက်

### စတင်ဖန်တီးမှု
- MCP for Beginners သင်ခန်းစာအစီအစဉ်၏ ပထမဆုံး version ကို ထုတ်ဝေခဲ့သည်
- အဓိက အပိုင်း ၁၀ ခုအတွက် အခြေခံဖွဲ့စည်းမှုကို ဖန်တီးခဲ့သည်
- Visual Curriculum Map ကို navigation အတွက် ထည့်သွင်းခဲ့သည်
- Programming languages များစွာဖြင့် initial sample projects များ ထည့်သွင်းခဲ့သည်

### စတင်အသုံးပြုခြင်း (03-GettingStarted/)
- Server implementation examples များ ဖန်တီးခဲ့သည်
- Client development လမ်းညွှန်ချက်များ ထည့်သွင်းခဲ့သည်
- LLM client integration လမ်းညွှန်ချက်များ ထည့်သွင်းခဲ့သည်
- VS Code integration documentation ထည့်သွင်းခဲ့သည်
- Server-Sent Events (SSE) server examples များ ထည့်သွင်းခဲ့သည်

### အခြေခံ အယူအဆများ (01-CoreConcepts/)
- Client-server architecture အကြောင်း ရှင်းလင်းစွာ ဖော်ပြခဲ့သည်
- Protocol components အရေးပါသော အချက်များကို documentation ပြုလုပ်ခဲ့သည်
- MCP messaging patterns ကို documentation ပြုလုပ်ခဲ့သည်

## ၂၀၂၅ ခုနှစ်၊ မေလ ၂၃ ရက်

### Repository Structure
- Repository ကို အခြေခံ folder structure ဖြင့် စတင်ခဲ့သည်
- အဓိက အပိုင်းတစ်ခုစီအတွက် README files များ ဖန်တီးခဲ့သည်
- Translation infrastructure ကို စတင်ခဲ့သည်
- Image assets နှင့် diagrams များ ထည့်သွင်းခဲ့သည်

### Documentation
- Curriculum overview ပါဝင်သော README.md ကို စတင်ဖန်တီးခဲ့သည်
- CODE_OF_CONDUCT.md နှင့် SECURITY.md ကို ဖန်တီးခဲ့သည်
- SUPPORT.md ကို အကူအညီရယူရန် လမ်းညွှန်ချက်များဖြင့် ဖန်တီးခဲ့သည်
- Preliminary study guide structure ကို ဖန်တီးခဲ့သည်

## ၂၀၂၅ ခုနှစ်၊ ဧပြီလ ၁၅ ရက်

### အစီအစဉ်နှင့် Framework
- MCP for Beginners သင်ခန်းစာအစီအစဉ်အတွက် စီစဉ်မှုကို စတင်ခဲ့သည်
- သင်ယူရမည့် ရည်မှန်းချက်များနှင့် ရည်ရွယ်ထားသော ပရိသတ်ကို သတ်မှတ်ခဲ့သည်
- Curriculum ၏ အပိုင်း ၁၀ ခုကို အကြမ်းဖျင်း ဖော်ပြခဲ့သည်
- ဥပမာများနှင့် case studies အတွက် conceptual framework ကို ဖွံ့ဖြိုးခဲ့သည်
- အရေးပါသော အယူအဆများအတွက် initial prototype examples များ ဖန်တီးခဲ့သည်

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် ရှုလေ့လာသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူက ဘာသာပြန်မှု ဝန်ဆောင်မှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။