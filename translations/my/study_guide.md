<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e2c6ed897fa98fa08e0146101776c7ff",
  "translation_date": "2025-07-18T10:33:52+00:00",
  "source_file": "study_guide.md",
  "language_code": "my"
}
-->
# Model Context Protocol (MCP) for Beginners - သင်ခန်းစာလမ်းညွှန်

ဤသင်ခန်းစာလမ်းညွှန်သည် "Model Context Protocol (MCP) for Beginners" သင်ရိုးညွှန်းတမ်းအတွက် repository ဖွဲ့စည်းမှုနှင့် အကြောင်းအရာများကို အနှစ်ချုပ်ပေးထားသည်။ Repository ကို ထိရောက်စွာ လမ်းညွှန်ရန်နှင့် ရရှိနိုင်သော အရင်းအမြစ်များကို အပြည့်အဝ အသုံးချနိုင်ရန် ဤလမ်းညွှန်ကို အသုံးပြုပါ။

## Repository အနှစ်ချုပ်

Model Context Protocol (MCP) သည် AI မော်ဒယ်များနှင့် client application များအကြား ဆက်သွယ်မှုများအတွက် စံပြဖွဲ့စည်းမှုတစ်ခုဖြစ်သည်။ မူလအားဖြင့် Anthropic မှ ဖန်တီးခဲ့ပြီး ယခုအခါ MCP community ကြီးမှ GitHub အဖွဲ့အစည်းမှ တာဝန်ယူထိန်းသိမ်းနေသည်။ ဤ repository တွင် C#, Java, JavaScript, Python နှင့် TypeScript စသည့် programming languages များဖြင့် လက်တွေ့ code ဥပမာများပါဝင်သည့် သင်ရိုးညွှန်းတမ်းတစ်ခုကို AI developer များ၊ system architect များနှင့် software engineer များအတွက် ဖန်တီးထားသည်။

## Visual Curriculum Map

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization Benefits)
      (Real-world Use Cases)
      (AI Integration Fundamentals)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
      (Transport Mechanisms)
    02. Security
      ::icon(fa fa-shield)
      (AI-Specific Threats)
      (Best Practices 2025)
      (Azure Content Safety)
      (Auth & Authorization)
      (Microsoft Prompt Shields)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server Implementation)
      (Client Development)
      (LLM Client Integration)
      (VS Code Extensions)
      (SSE Server Setup)
      (HTTP Streaming)
      (AI Toolkit Integration)
      (Testing Frameworks)
      (Deployment Strategies)
    04. Practical Implementation
      ::icon(fa fa-code)
      (Multi-Language SDKs)
      (Testing & Debugging)
      (Prompt Templates)
      (Sample Projects)
      (Production Patterns)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Agent Integration)
      (Multi-modal AI Workflows)
      (OAuth2 Authentication)
      (Real-time Search)
      (Streaming Protocols)
      (Root Contexts)
      (Routing Strategies)
      (Sampling Techniques)
      (Scaling Solutions)
      (Security Hardening)
      (Entra ID Integration)
      (Web Search MCP)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Client Ecosystem)
      (MCP Server Registry)
      (Image Generation Tools)
      (GitHub Collaboration)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Production Deployments)
      (Microsoft MCP Servers)
      (Azure MCP Service)
      (Enterprise Case Studies)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance Optimization)
      (Fault Tolerance)
      (System Resilience)
      (Monitoring & Observability)
    09. Case Studies
      ::icon(fa fa-file-text)
      (Azure API Management)
      (AI Travel Agent)
      (Azure DevOps Integration)
      (Documentation MCP)
      (Real-world Implementations)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (MCP Server Fundamentals)
      (Advanced Development)
      (AI Toolkit Integration)
      (Production Deployment)
      (4-Lab Structure)
```

## Repository ဖွဲ့စည်းမှု

Repository ကို MCP ၏ အစိတ်အပိုင်းအမျိုးမျိုးကို အာရုံစိုက်ထားသည့် အဓိကပိုင်း ၁၀ ခုအဖြစ် စီစဉ်ထားသည်-

1. **Introduction (00-Introduction/)**
   - Model Context Protocol အကြောင်းအနှစ်ချုပ်
   - AI pipeline များတွင် စံပြဖွဲ့စည်းမှု၏ အရေးပါမှု
   - လက်တွေ့အသုံးချမှုများနှင့် အကျိုးကျေးဇူးများ

2. **Core Concepts (01-CoreConcepts/)**
   - Client-server ဖွဲ့စည်းမှု
   - Protocol ၏ အဓိကအစိတ်အပိုင်းများ
   - MCP တွင် အသုံးပြုသော စာတိုက်ပုံစံများ

3. **Security (02-Security/)**
   - MCP အခြေပြု စနစ်များတွင် ဖြစ်ပေါ်နိုင်သော လုံခြုံရေး အန္တရာယ်များ
   - လုံခြုံရေး အကောင်အထည်ဖော်မှုအတွက် အကောင်းဆုံး လုပ်ထုံးလုပ်နည်းများ
   - အတည်ပြုခြင်းနှင့် ခွင့်ပြုခြင်း မဟာဗျူဟာများ
   - **လုံခြုံရေး စာတမ်းများ အပြည့်အစုံ**:
     - MCP Security Best Practices 2025
     - Azure Content Safety Implementation Guide
     - MCP Security Controls and Techniques
     - MCP Best Practices Quick Reference
   - **အဓိက လုံခြုံရေး ခေါင်းစဉ်များ**:
     - Prompt injection နှင့် tool poisoning တိုက်ခိုက်မှုများ
     - Session hijacking နှင့် confused deputy ပြဿနာများ
     - Token passthrough အားနည်းချက်များ
     - အလွန်အကျွံ ခွင့်ပြုချက်များနှင့် access control
     - AI အစိတ်အပိုင်းများအတွက် supply chain လုံခြုံရေး
     - Microsoft Prompt Shields ပေါင်းစပ်မှု

4. **Getting Started (03-GettingStarted/)**
   - ပတ်ဝန်းကျင် ပြင်ဆင်ခြင်းနှင့် ဖွဲ့စည်းခြင်း
   - အခြေခံ MCP server နှင့် client များ ဖန်တီးခြင်း
   - ရှိပြီးသား application များနှင့် ပေါင်းစည်းခြင်း
   - အပိုင်းများတွင် ပါဝင်သည်-
     - ပထမဆုံး server အကောင်အထည်ဖော်ခြင်း
     - Client ဖန်တီးခြင်း
     - LLM client ပေါင်းစည်းခြင်း
     - VS Code ပေါင်းစည်းခြင်း
     - Server-Sent Events (SSE) server
     - HTTP streaming
     - AI Toolkit ပေါင်းစည်းခြင်း
     - စမ်းသပ်မှု မဟာဗျူဟာများ
     - တပ်ဆင်ခြင်း လမ်းညွှန်ချက်များ

5. **Practical Implementation (04-PracticalImplementation/)**
   - အမျိုးမျိုးသော programming language များတွင် SDK များ အသုံးပြုခြင်း
   - Debugging, စမ်းသပ်ခြင်းနှင့် အတည်ပြုခြင်း နည်းလမ်းများ
   - ပြန်လည်အသုံးပြုနိုင်သော prompt template များနှင့် workflow များ ဖန်တီးခြင်း
   - အကောင်အထည်ဖော်မှု ဥပမာများပါဝင်သည့် စမ်းသပ်ပရောဂျက်များ

6. **Advanced Topics (05-AdvancedTopics/)**
   - Context engineering နည်းပညာများ
   - Foundry agent ပေါင်းစည်းခြင်း
   - Multi-modal AI workflow များ
   - OAuth2 authentication များ ပြသခြင်း
   - အချိန်နှင့်တပြေးညီ ရှာဖွေရေး စွမ်းဆောင်ရည်များ
   - အချိန်နှင့်တပြေးညီ streaming
   - Root context များ အကောင်အထည်ဖော်ခြင်း
   - Routing မဟာဗျူဟာများ
   - Sampling နည်းလမ်းများ
   - Scaling နည်းလမ်းများ
   - လုံခြုံရေး စဉ်းစားချက်များ
   - Entra ID လုံခြုံရေး ပေါင်းစည်းမှု
   - Web search ပေါင်းစည်းမှု

7. **Community Contributions (06-CommunityContributions/)**
   - ကုဒ်နှင့် စာတမ်းများ ပံ့ပိုးပေးခြင်းနည်းလမ်းများ
   - GitHub မှတဆင့် ပူးပေါင်းဆောင်ရွက်ခြင်း
   - အသိုင်းအဝိုင်းမှ တိုးတက်မှုများနှင့် တုံ့ပြန်ချက်များ
   - MCP client များ (Claude Desktop, Cline, VSCode) အသုံးပြုခြင်း
   - လူကြိုက်များသော MCP server များနှင့် ပူးပေါင်းဆောင်ရွက်ခြင်း (ပုံဖန်တီးခြင်း အပါအဝင်)

8. **Lessons from Early Adoption (07-LessonsfromEarlyAdoption/)**
   - လက်တွေ့ အကောင်အထည်ဖော်မှုများနှင့် အောင်မြင်မှုဇာတ်လမ်းများ
   - MCP အခြေပြု ဖြေရှင်းချက်များ တည်ဆောက်ခြင်းနှင့် တပ်ဆင်ခြင်း
   - လမ်းကြောင်းနှင့် အနာဂတ် ရှုမြင်ချက်များ
   - **Microsoft MCP Servers Guide**: ၁၀ ခုသော ထုတ်လုပ်မှုအဆင်သင့် Microsoft MCP server များအတွက် လမ်းညွှန်ချက် အပြည့်အစုံ
     - Microsoft Learn Docs MCP Server
     - Azure MCP Server (၁၅+ အထူးပြု ချိတ်ဆက်ကွန်နက်တာများ)
     - GitHub MCP Server
     - Azure DevOps MCP Server
     - MarkItDown MCP Server
     - SQL Server MCP Server
     - Playwright MCP Server
     - Dev Box MCP Server
     - Azure AI Foundry MCP Server
     - Microsoft 365 Agents Toolkit MCP Server

9. **Best Practices (08-BestPractices/)**
   - စွမ်းဆောင်ရည် တိုးတက်မှုနှင့် အကောင်းဆုံး ပြုပြင်ခြင်း
   - MCP စနစ်များကို အမှားခံနိုင်စွမ်းရှိအောင် ဒီဇိုင်းဆွဲခြင်း
   - စမ်းသပ်ခြင်းနှင့် တည်ငြိမ်မှု မဟာဗျူဟာများ

10. **Case Studies (09-CaseStudy/)**
    - Azure API Management ပေါင်းစည်းမှု ဥပမာ
    - ခရီးသွားအေးဂျင့် အကောင်အထည်ဖော်မှု ဥပမာ
    - Azure DevOps နှင့် YouTube အပ်ဒိတ် ပေါင်းစည်းမှု
    - စာတမ်းရေးခြင်း MCP အကောင်အထည်ဖော်မှု ဥပမာများ
    - အသေးစိတ်စာတမ်းများပါဝင်သည့် အကောင်အထည်ဖော်မှု ဥပမာများ

11. **Hands-on Workshop (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - MCP နှင့် AI Toolkit ပေါင်းစပ်ထားသည့် လက်တွေ့ လေ့ကျင့်ခန်း
    - AI မော်ဒယ်များနှင့် လက်တွေ့ကိရိယာများကို ချိတ်ဆက်သည့် အတတ်ပညာဆိုင်ရာ application များ တည်ဆောက်ခြင်း
    - အခြေခံအကြောင်းအရာများ၊ စိတ်ကြိုက် server ဖန်တီးခြင်းနှင့် ထုတ်လုပ်မှု တပ်ဆင်ခြင်း မော်ဂျူးများ ပါဝင်သည်
    - **Lab ဖွဲ့စည်းမှု**:
      - Lab 1: MCP Server အခြေခံများ
      - Lab 2: အဆင့်မြင့် MCP Server ဖန်တီးခြင်း
      - Lab 3: AI Toolkit ပေါင်းစည်းခြင်း
      - Lab 4: ထုတ်လုပ်မှု တပ်ဆင်ခြင်းနှင့် တိုးချဲ့ခြင်း
    - Lab အခြေပြု သင်ယူမှုနည်းလမ်းဖြင့် အဆင့်ဆင့် လမ်းညွှန်ချက်များ

## အပိုဆောင်း အရင်းအမြစ်များ

Repository တွင် အောက်ပါ အထောက်အပံ့များ ပါဝင်သည်-

- **Images ဖိုလ်ဒါ**: သင်ရိုးညွှန်းတမ်းအတွင်း အသုံးပြုထားသည့် ပုံဆွဲများနှင့် ရုပ်ပုံများ
- **ဘာသာပြန်ချက်များ**: စာတမ်းများကို အလိုအလျောက် ဘာသာပြန်ထားခြင်းဖြင့် ဘာသာစကားစုံ ထောက်ပံ့မှု
- **တရားဝင် MCP အရင်းအမြစ်များ**:
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## ဤ Repository ကို မည်သို့ အသုံးပြုမည်နည်း

1. **အဆင့်လိုက် သင်ယူခြင်း**: အခန်းများကို အစဉ်လိုက် (00 မှ 10 အထိ) လေ့လာပါ။
2. **ဘာသာစကားအလိုက် အာရုံစိုက်ခြင်း**: သင်စိတ်ဝင်စားသော programming language အတွက် sample directory များကို ရှာဖွေပါ။
3. **လက်တွေ့ အကောင်အထည်ဖော်ခြင်း**: "Getting Started" အပိုင်းမှ စ၍ ပတ်ဝန်းကျင် ပြင်ဆင်ခြင်းနှင့် ပထမဆုံး MCP server နှင့် client ဖန်တီးခြင်းကို စတင်ပါ။
4. **အဆင့်မြင့် လေ့လာမှု**: အခြေခံများကို နားလည်ပြီးနောက် အဆင့်မြင့် ခေါင်းစဉ်များသို့ ဝင်ရောက်လေ့လာပါ။
5. **အသိုင်းအဝိုင်း ပါဝင်ဆောင်ရွက်ခြင်း**: GitHub ဆွေးနွေးပွဲများနှင့် Discord ချန်နယ်များမှတဆင့် MCP အသိုင်းအဝိုင်းနှင့် ဆက်သွယ်ပါ။

## MCP Client များနှင့် ကိရိယာများ

သင်ရိုးညွှန်းတမ်းတွင် MCP client များနှင့် ကိရိယာများ အမျိုးမျိုး ပါဝင်သည်-

1. **တရားဝင် Client များ**:
   - Visual Studio Code
   - MCP in Visual Studio Code
   - Claude Desktop
   - Claude in VSCode
   - Claude API

2. **အသိုင်းအဝိုင်း Client များ**:
   - Cline (terminal-based)
   - Cursor (code editor)
   - ChatMCP
   - Windsurf

3. **MCP စီမံခန့်ခွဲမှု ကိရိယာများ**:
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## လူကြိုက်များသော MCP Server များ

Repository တွင် မတူညီသော MCP server များကို မိတ်ဆက်ထားသည်-

1. **တရားဝင် Microsoft MCP Server များ**:
   - Microsoft Learn Docs MCP Server
   - Azure MCP Server (၁၅+ အထူးပြု ချိတ်ဆက်ကွန်နက်တာများ)
   - GitHub MCP Server
   - Azure DevOps MCP Server
   - MarkItDown MCP Server
   - SQL Server MCP Server
   - Playwright MCP Server
   - Dev Box MCP Server
   - Azure AI Foundry MCP Server
   - Microsoft 365 Agents Toolkit MCP Server

2. **တရားဝင် ကိုးကား Server များ**:
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

3. **ပုံဖန်တီးခြင်း**:
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

4. **ဖွံ့ဖြိုးရေး ကိရိယာများ**:
   - Git MCP
   - Terminal Control
   - Code Assistant

5. **အထူးပြု Server များ**:
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## ပံ့ပိုးမှု ပေးခြင်း

ဤ repository သည် အသိုင်းအဝိုင်းမှ ပံ့ပိုးမှုများကို ကြိုဆိုပါသည်။ MCP ecosystem တွင် ထိရောက်စွာ ပံ့ပိုးပေးရန် Community Contributions အပိုင်းကို ကြည့်ရှုပါ။

## ပြောင်းလဲမှုမှတ်တမ်း

| ရက်စွဲ | ပြောင်းလဲမှုများ |
|---------|------------------|
| ၂၀၂၅ ခုနှစ် ဇူလိုင် ၁၈ ရက် | - Microsoft MCP Servers Guide ပါဝင်သည့် repository ဖွဲ့စည်းမှု အသစ်<br>- ထုတ်လုပ်မှုအဆင်သင့် Microsoft MCP server ၁၀ ခုစာရင်း ထည့်သွင်း<br>- လူကြိုက်များသော MCP Server အပိုင်းတွင် တရားဝင် Microsoft MCP Server များ ထည့်သွင်း<br>- Case Studies အပိုင်းတွင် အမှန်တကယ် ဖိုင် ဥပမာများ ထည့်သွင်း<br>- Hands-on Workshop အတွက် Lab ဖွဲ့စည်းမှု အသေးစိတ် ထည့်သွင်း |
| ၂၀၂၅ ခုနှစ် ဇူလိုင် ၁၆ ရက် | - လက်ရှိ အကြောင်းအရာများကို ပြသရန် repository ဖွဲ့စည်းမှု ပြင်ဆင်<br>- MCP Clients နှင့် Tools အပိုင်း ထည့်သွင်း<br>- လူကြိုက်များသော MCP Server အပိုင်း ထည့်သွင်း<br>- Visual Curriculum Map ကို လက်ရှိ ခေါင်းစဉ်များဖြင့် ပြင်ဆင်<br>- Advanced Topics အပိုင်းတွင် အထူးပြု ခေါင်းစဉ်များ ထည့်သွင်း<br>- Case Studies ကို အမှန်တကယ် ဥပမာများဖြင့် ပြင်ဆင်<br>- MCP ကို Anthropic မှ ဖန်တီးခဲ့သည်ဟု ဖော်ပြချက် ထည့်သွင်း |
| ၂၀၂၅ ခုနှစ် ဇွန် ၁၁ ရက် | - သင်ခန်းစာလမ်းညွှန် မူလ ဖန်တီးခြင်း<br>- Visual Curriculum Map ထည့်သွင်းခြင်း<br>- Repository ဖွဲ့စည်းမှု အကြောင်း ရေးသားခြင်း<br>- စမ်းသပ်ပရောဂျက်များနှင့် အပိုဆောင်း အရင်းအမြစ်များ ထည့်သွင်းခြင်း |

---

*ဤသင်ခန်းစာလမ်းညွှန်ကို ၂၀၂၅ ခုနှစ် ဇူလိုင် ၁၈ ရက်တွင် ပြင်ဆင်ပြီး ထိုရက်စွဲအထိ repository အကြောင်းအရာကို အနှစ်ချုပ်ပေးထားပါသည်။ ထိုရက်စွဲနောက်ပိုင်းတွင် repository အကြောင်းအရာများ ပြောင်းလဲနိုင်ပါသည်။*

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။