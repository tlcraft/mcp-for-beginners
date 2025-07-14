<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-07-14T07:16:00+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "my"
}
-->
# AI လုပ်ငန်းစဉ်များကို ပိုမိုလွယ်ကူစေခြင်း - AI Toolkit ဖြင့် MCP Server တည်ဆောက်ခြင်း

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.my.png)

## 🎯 အနှစ်ချုပ်

**Model Context Protocol (MCP) Workshop** သို့ ကြိုဆိုပါသည်! ဒီလက်တွေ့လေ့ကျင့်ခန်းမှာ AI application ဖန်တီးမှုကို ပြောင်းလဲပေးမယ့် နည်းပညာ နှစ်ခုကို ပေါင်းစပ်ထားပါတယ်။

- **🔗 Model Context Protocol (MCP)**: AI tools တွေကို ချိတ်ဆက်ဖို့ အဆင်ပြေတဲ့ ဖွင့်လှစ်စံနှုန်း
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**: Microsoft ရဲ့ အင်အားကြီး AI ဖန်တီးမှု extension

### 🎓 သင်ယူရမယ့်အရာများ

ဒီ workshop အပြီးမှာ AI မော်ဒယ်တွေကို လက်တွေ့အသုံးပြုနိုင်တဲ့ tools နဲ့ ဝန်ဆောင်မှုတွေနဲ့ ချိတ်ဆက်ပြီး အတတ်ပညာမြင့် application တွေ ဖန်တီးနိုင်မှာ ဖြစ်ပါတယ်။ Automated testing ကနေ custom API integration အထိ စီးပွားရေးပြဿနာတွေကို ဖြေရှင်းနိုင်မယ့် ကျွမ်းကျင်မှုတွေ ရရှိမှာ ဖြစ်ပါတယ်။

## 🏗️ နည်းပညာအခြေခံ

### 🔌 Model Context Protocol (MCP)

MCP သည် **"AI အတွက် USB-C"** လို့ ဆိုနိုင်ပြီး AI မော်ဒယ်တွေကို အခြား tools နဲ့ ဒေတာရင်းမြစ်တွေနဲ့ ချိတ်ဆက်ပေးတဲ့ စံနှုန်းတစ်ခုဖြစ်ပါတယ်။

**✨ အဓိက လက္ခဏာများ:**
- 🔄 **စံနှုန်းတူ ချိတ်ဆက်မှု**: AI tools တွေကို ချိတ်ဆက်ဖို့ အပြည့်အစုံ interface
- 🏛️ **တည်ဆောက်ပုံ လွယ်ကူမှု**: local နဲ့ remote server များကို stdio/SSE နည်းဖြင့် ချိတ်ဆက်နိုင်ခြင်း
- 🧰 **စုံလင်သော ecosystem**: tools, prompts, resources များကို protocol တစ်ခုထဲမှာ စုစည်းထားခြင်း
- 🔒 **စီးပွားရေးအဆင့် အသုံးပြုနိုင်မှု**: built-in လုံခြုံရေးနှင့် ယုံကြည်စိတ်ချရမှု

**🎯 MCP ရဲ့ အရေးပါမှု:**
USB-C က ကေဘယ်တွေကို ရှင်းလင်းပေးသလို MCP က AI integration တွေကို ရိုးရှင်းစေပါတယ်။ Protocol တစ်ခုနဲ့ အခွင့်အလမ်း များစွာ။

### 🤖 AI Toolkit for Visual Studio Code (AITK)

Microsoft ရဲ့ VS Code ကို AI အင်အားကြီး စက်ရုပ်အဖြစ် ပြောင်းလဲပေးတဲ့ AI ဖန်တီးမှု extension ဖြစ်ပါတယ်။

**🚀 အဓိက လုပ်ဆောင်ချက်များ:**
- 📦 **Model Catalog**: Azure AI, GitHub, Hugging Face, Ollama မှ မော်ဒယ်များကို ရယူနိုင်ခြင်း
- ⚡ **Local Inference**: ONNX အထူးပြု CPU/GPU/NPU အကောင်အထည်ဖော်ခြင်း
- 🏗️ **Agent Builder**: MCP နှင့် ပေါင်းစပ်ပြီး Visual AI agent ဖန်တီးခြင်း
- 🎭 **Multi-Modal**: စာသား၊ ဗီဒီယို၊ ဖွဲ့စည်းထားသော output များကို ထောက်ပံ့ခြင်း

**💡 ဖန်တီးမှု အကျိုးကျေးဇူးများ:**
- Zero-config မော်ဒယ် deployment
- Visual prompt engineering
- အချိန်နှင့်တပြေးညီ စမ်းသပ်နိုင်သော playground
- MCP server နှင့် ချိတ်ဆက်မှု လွယ်ကူခြင်း

## 📚 သင်ယူမှု ခရီးစဉ်

### [🚀 Module 1: AI Toolkit အခြေခံများ](./lab1/README.md)
**ကြာမြင့်ချိန်**: ၁၅ မိနစ်
- 🛠️ VS Code အတွက် AI Toolkit ကို တပ်ဆင်ပြီး ပြင်ဆင်ခြင်း
- 🗂️ Model Catalog ကို ရှာဖွေခြင်း (GitHub, ONNX, OpenAI, Anthropic, Google မှ မော်ဒယ် ၁၀၀ ကျော်)
- 🎮 အချိန်နှင့်တပြေးညီ မော်ဒယ် စမ်းသပ်နိုင်သော Interactive Playground ကို ကျွမ်းကျင်ခြင်း
- 🤖 Agent Builder ဖြင့် ပထမဆုံး AI agent တည်ဆောက်ခြင်း
- 📊 Built-in metrics (F1, relevance, similarity, coherence) ဖြင့် မော်ဒယ် စွမ်းဆောင်ရည် သုံးသပ်ခြင်း
- ⚡ Batch processing နှင့် multi-modal ထောက်ပံ့မှုများကို သင်ယူခြင်း

**🎯 သင်ယူပြီးရလဒ်**: AITK ၏ လုပ်ဆောင်ချက်များကို နားလည်ပြီး လုပ်ဆောင်နိုင်သော AI agent တစ်ခု ဖန်တီးနိုင်ခြင်း

### [🌐 Module 2: MCP နှင့် AI Toolkit အခြေခံများ](./lab2/README.md)
**ကြာမြင့်ချိန်**: ၂၀ မိနစ်
- 🧠 Model Context Protocol (MCP) ၏ တည်ဆောက်ပုံနှင့် အယူအဆများ ကျွမ်းကျင်ခြင်း
- 🌐 Microsoft ၏ MCP server ecosystem ကို ရှာဖွေခြင်း
- 🤖 Playwright MCP server ကို အသုံးပြု Browser automation agent တည်ဆောက်ခြင်း
- 🔧 MCP servers များကို AI Toolkit Agent Builder နှင့် ပေါင်းစပ်ခြင်း
- 📊 MCP tools များကို agent များအတွင်း ပြင်ဆင်စမ်းသပ်ခြင်း
- 🚀 MCP အားဖြင့် အင်အားမြှင့်ထားသော agent များကို ထုတ်ပေးပြီး အသုံးပြုခြင်း

**🎯 သင်ယူပြီးရလဒ်**: MCP ဖြင့် အပြင် tools များ ချိတ်ဆက်ထားသော AI agent တစ်ခု ထုတ်လုပ်နိုင်ခြင်း

### [🔧 Module 3: AI Toolkit ဖြင့် အဆင့်မြင့် MCP ဖန်တီးမှု](./lab3/README.md)
**ကြာမြင့်ချိန်**: ၂၀ မိနစ်
- 💻 AI Toolkit အသုံးပြု Custom MCP servers ဖန်တီးခြင်း
- 🐍 MCP Python SDK (v1.9.3) ကို ပြင်ဆင်အသုံးပြုခြင်း
- 🔍 MCP Inspector ဖြင့် debugging ပြုလုပ်ခြင်း
- 🛠️ Weather MCP Server တည်ဆောက်ပြီး professional debugging workflow များ အသုံးပြုခြင်း
- 🧪 Agent Builder နှင့် Inspector ပတ်ဝန်းကျင်များတွင် MCP servers များကို debug ပြုလုပ်ခြင်း

**🎯 သင်ယူပြီးရလဒ်**: ခေတ်မီ tooling များဖြင့် Custom MCP servers များ ဖန်တီးပြီး debug ပြုလုပ်နိုင်ခြင်း

### [🐙 Module 4: လက်တွေ့ MCP ဖန်တီးမှု - Custom GitHub Clone Server](./lab4/README.md)
**ကြာမြင့်ချိန်**: ၃၀ မိနစ်
- 🏗️ လက်တွေ့အသုံးပြု GitHub Clone MCP Server တည်ဆောက်ခြင်း
- 🔄 Repository cloning ကို စမတ်စနစ်ဖြင့် validation နှင့် error handling ပါဝင်စေခြင်း
- 📁 directory management နှင့် VS Code integration ကို အတတ်ပညာမြင့် ဖန်တီးခြင်း
- 🤖 GitHub Copilot Agent Mode ကို custom MCP tools နှင့် အသုံးပြုခြင်း
- 🛡️ စီးပွားရေးအဆင့် အသုံးပြုနိုင်မှုနှင့် cross-platform ကို အာမခံခြင်း

**🎯 သင်ယူပြီးရလဒ်**: လက်တွေ့အသုံးပြုမှုများကို ပိုမိုလွယ်ကူစေမယ့် production-ready MCP server တစ်ခု ထုတ်လုပ်နိုင်ခြင်း

## 💡 လက်တွေ့အသုံးချမှုများနှင့် သက်ရောက်မှု

### 🏢 စီးပွားရေးအသုံးပြုမှုများ

#### 🔄 DevOps Automation
သင့်ဖွံ့ဖြိုးတိုးတက်မှု လုပ်ငန်းစဉ်ကို စမတ် automation ဖြင့် ပြောင်းလဲပါ။
- **Smart Repository Management**: AI အခြေပြု code review နှင့် merge ဆုံးဖြတ်ချက်များ
- **Intelligent CI/CD**: code ပြောင်းလဲမှုအပေါ် အလိုအလျောက် pipeline တိုးတက်မှု
- **Issue Triage**: အမှားများကို အလိုအလျောက် သတ်မှတ်ခြင်းနှင့် ခန့်အပ်ခြင်း

#### 🧪 အရည်အသွေး အာမခံမှု ပြောင်းလဲမှု
AI အားဖြင့် စမ်းသပ်မှုများကို မြှင့်တင်ပါ။
- **Intelligent Test Generation**: စမ်းသပ်မှု စာရင်းများကို အလိုအလျောက် ဖန်တီးခြင်း
- **Visual Regression Testing**: AI အားဖြင့် UI ပြောင်းလဲမှုများ စစ်ဆေးခြင်း
- **Performance Monitoring**: ပြဿနာများကို ကြိုတင် သိရှိပြီး ဖြေရှင်းခြင်း

#### 📊 ဒေတာ လုပ်ငန်းစဉ် အတတ်ပညာမြှင့်တင်မှု
ပိုမိုစမတ်သော ဒေတာ လုပ်ငန်းစဉ်များ ဖန်တီးပါ။
- **Adaptive ETL Processes**: ကိုယ်တိုင်တိုးတက်သွားသော ဒေတာ ပြောင်းလဲမှုများ
- **Anomaly Detection**: အချိန်နှင့်တပြေးညီ ဒေတာ အရည်အသွေး စောင့်ကြည့်ခြင်း
- **Intelligent Routing**: စမတ် ဒေတာ လှိုင်းစီးမှု စီမံခန့်ခွဲမှု

#### 🎧 ဖောက်သည် အတွေ့အကြုံ မြှင့်တင်ခြင်း
ထူးခြားသော ဖောက်သည် ဝန်ဆောင်မှုများ ဖန်တီးပါ။
- **Context-Aware Support**: ဖောက်သည် သမိုင်းကြောင်းကို အသုံးပြု AI agent များ
- **Proactive Issue Resolution**: ကြိုတင် ခန့်မှန်းပြီး ဝန်ဆောင်မှု ပြုလုပ်ခြင်း
- **Multi-Channel Integration**: ပလက်ဖောင်း အမျိုးမျိုးတွင် AI အတွေ့အကြုံ တစ်ခုတည်းဖြင့် ပေါင်းစပ်ခြင်း

## 🛠️ လိုအပ်ချက်များနှင့် ပြင်ဆင်မှု

### 💻 စနစ်လိုအပ်ချက်များ

| အစိတ်အပိုင်း | လိုအပ်ချက် | မှတ်ချက် |
|-------------|-------------|---------|
| **Operating System** | Windows 10+, macOS 10.15+, Linux | မည်သည့်ခေတ်မှီ OS မဆို အသုံးပြုနိုင်သည် |
| **Visual Studio Code** | နောက်ဆုံး stable version | AITK အတွက် လိုအပ်သည် |
| **Node.js** | v18.0+ နှင့် npm | MCP server ဖန်တီးရန် |
| **Python** | 3.10+ | Python MCP servers အတွက် ရွေးချယ်စရာ |
| **Memory** | အနည်းဆုံး 8GB RAM | local မော်ဒယ်များအတွက် 16GB အကြံပြုသည် |

### 🔧 ဖန်တီးမှု ပတ်ဝန်းကျင်

#### အကြံပြု VS Code Extensions
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) - ရွေးချယ်အသုံးပြုနိုင်သည်

#### ရွေးချယ်စရာ Tools
- **uv**: ခေတ်မီ Python package manager
- **MCP Inspector**: MCP servers အတွက် visual debugging tool
- **Playwright**: web automation ဥပမာများအတွက်

## 🎖️ သင်ယူပြီးရလဒ်များနှင့် လက်မှတ်ရရှိမှု လမ်းကြောင်း

### 🏆 ကျွမ်းကျင်မှု စစ်ဆေးစာရင်း

ဒီ workshop ကို ပြီးမြောက်ခြင်းဖြင့် အောက်ပါ ကျွမ်းကျင်မှုများ ရရှိမည်။

#### 🎯 အဓိက ကျွမ်းကျင်မှုများ
- [ ] **MCP Protocol ကျွမ်းကျင်မှု**: တည်ဆောက်ပုံနှင့် အကောင်အထည်ဖော်မှု နက်ရှိုင်းစွာ နားလည်ခြင်း
- [ ] **AITK ကျွမ်းကျင်မှု**: AI Toolkit ကို အမြန်ဖန်တီးမှုအတွက် ကျွမ်းကျင်စွာ အသုံးပြုနိုင်ခြင်း
- [ ] **Custom Server ဖန်တီးမှု**: MCP servers များကို တည်ဆောက်၊ ထုတ်လုပ်၊ ထိန်းသိမ်းနိုင်ခြင်း
- [ ] **Tool Integration ကျွမ်းကျင်မှု**: AI ကို ရှိပြီးသား ဖွံ့ဖြိုးတိုးတက်မှု လုပ်ငန်းစဉ်များနှင့် ချိတ်ဆက်နိုင်ခြင်း
- [ ] **ပြဿနာဖြေရှင်းမှု လက်တွေ့အသုံးချမှု**: သင်ယူထားသော ကျွမ်းကျင်မှုများကို စီးပွားရေး ပြဿနာများတွင် အသုံးချနိုင်ခြင်း

#### 🔧 နည်းပညာ ကျွမ်းကျင်မှုများ
- [ ] VS Code တွင် AI Toolkit ကို တပ်ဆင် ပြင်ဆင်ခြင်း
- [ ] Custom MCP servers များ ဒီဇိုင်းဆွဲ၊ တည်ဆောက်ခြင်း
- [ ] GitHub Models များကို MCP architecture နှင့် ပေါင်းစပ်ခြင်း
- [ ] Playwright ဖြင့် automated testing workflow များ ဖန်တီးခြင်း
- [ ] AI agents များကို ထုတ်လုပ် အသုံးပြုခြင်း
- [ ] MCP server performance ကို debug နှင့် optimize ပြုလုပ်ခြင်း

#### 🚀 အဆင့်မြင့် လုပ်ဆောင်ချက်များ
- [ ] စီးပွားရေးအဆင့် AI integration များ ဒီဇိုင်းဆွဲခြင်း
- [ ] AI applications အတွက် လုံခြုံရေး အကောင်းဆုံး လုပ်ထုံးလုပ်နည်းများ အကောင်အထည်ဖော်ခြင်း
- [ ] MCP server architecture များကို တိုးချဲ့နိုင်စွမ်းရှိစေရန် ဒီဇိုင်းဆွဲခြင်း
- [ ] အထူး domain များအတွက် custom tool chain များ ဖန်တီးခြင်း
- [ ] AI-native ဖန်တီးမှုတွင် အခြားသူများကို လမ်းညွှန်ပေးခြင်း

## 📖 အပိုဆောင်း အရင်းအမြစ်များ
- [MCP Specification](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 သင့် AI ဖန်တီးမှု လုပ်ငန်းစဉ်ကို ပြောင်းလဲဖို့ ပြင်ဆင်ပြီးပြီလား?**

MCP နဲ့ AI Toolkit တို့နဲ့ အတူတကွ အနာဂတ် အတတ်ပညာမြင့် application များကို တည်ဆောက်ကြပါစို့!

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။