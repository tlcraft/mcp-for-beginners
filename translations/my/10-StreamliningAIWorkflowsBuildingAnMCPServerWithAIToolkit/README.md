<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-06-17T16:29:32+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "my"
}
-->
# AI အလုပ်လုပ်စဉ်များကို လွယ်ကူစေရန် - AI Toolkit ဖြင့် MCP Server တည်ဆောက်ခြင်း

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.my.png)

## 🎯 အနှစ်ချုပ်

**Model Context Protocol (MCP) Workshop** သို့ ကြိုဆိုပါသည်။ ဒီလက်တွေ့ လေ့ကျင့်ရေးအစီအစဉ်မှာ AI application ဖန်တီးမှုကို တိုးတက်အောင် ပြောင်းလဲပေးမယ့် နည်းပညာ နှစ်ခုကို ပေါင်းစပ်ထားပါတယ်-

- **🔗 Model Context Protocol (MCP)**: AI tool များကို ချိတ်ဆက်ပေးနိုင်တဲ့ ဖွင့်လင်းစံချိန်စံညွှန်း
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**: Microsoft ရဲ့ အားကောင်းတဲ့ AI ဖန်တီးရေး extension

### 🎓 သင်ယူရမယ့်အရာများ

ဒီ workshop အပြီးမှာ AI မော်ဒယ်များကို လက်တွေ့အသုံးပြုနိုင်တဲ့ tools နှင့် ဝန်ဆောင်မှုများနှင့် ချိတ်ဆက်ပြီး တီထွင်နိုင်မယ့် ကျွမ်းကျင်မှုရရှိမှာဖြစ်ပါတယ်။ စမ်းသပ်ခြင်းများမှစပြီး custom API တွေထည့်သွင်းခြင်းအထိ ကုန်ကျစရိတ်များကို ဖြေရှင်းနိုင်မယ့် နည်းလမ်းတွေကို လေ့လာရမှာပါ။

## 🏗️ နည်းပညာစနစ်

### 🔌 Model Context Protocol (MCP)

MCP ကို **"AI အတွက် USB-C"** လို့ ဆိုနိုင်ပြီး AI မော်ဒယ်များကို အခြား tools နဲ့ data source တွေနဲ့ ချိတ်ဆက်ပေးနိုင်တဲ့ အထွေထွေစံချိန်စံညွှန်းပါ။

**✨ အဓိကအင်္ဂါရပ်များ**
- 🔄 **စံချိန်စံညွှန်းထားသော ချိတ်ဆက်မှု**: AI tools တွေကို ချိတ်ဆက်ဖို့ အထွေထွေ interface
- 🏛️ **အသုံးပြုနိုင်မှုမြင့် ဖွဲ့စည်းပုံ**: stdio/SSE တို့ဖြင့် local နဲ့ remote server များကို ဆက်သွယ်နိုင်ခြင်း
- 🧰 **စုံလင်သော ecosystem**: Tools, prompt များနှင့် အရင်းအမြစ်များကို တစ်ခုတည်းမှာ စုစည်းထားခြင်း
- 🔒 **စီးပွားရေးအဆင့် အဆင်သင့်**: built-in လုံခြုံရေးနှင့် ယုံကြည်စိတ်ချရမှု

**🎯 MCP အရေးပါမှု**
USB-C က ကြိုးစည်းပျက်မှုတွေကို ဖယ်ရှားပေးသလို MCP က AI integration များ၏ ရိုးရှင်းမှုကို ဖယ်ရှားပေးပါတယ်။ တစ်ခုတည်းသော protocol နဲ့ များစွာသော အလားအလာများကို ဖန်တီးနိုင်ပါတယ်။

### 🤖 AI Toolkit for Visual Studio Code (AITK)

Microsoft ရဲ့ VS Code ကို AI အင်အားကြီးစက်အဖြစ် ပြောင်းလဲပေးမယ့် အဓိက AI ဖန်တီးရေး extension ဖြစ်ပါတယ်။

**🚀 အဓိကစွမ်းဆောင်ရည်များ**
- 📦 **Model Catalog**: Azure AI, GitHub, Hugging Face, Ollama ကနေ မော်ဒယ်များရယူနိုင်ခြင်း
- ⚡ **Local Inference**: ONNX အတွက် optimize လုပ်ထားသော CPU/GPU/NPU ပေါ်တွင် တိုက်ရိုက် ပြုလုပ်နိုင်ခြင်း
- 🏗️ **Agent Builder**: MCP ချိတ်ဆက်ထားသော visual AI agent ဖန်တီးရေး
- 🎭 **Multi-Modal**: စာသား၊ ဗီဇွယ်၊ နှင့် ဖွဲ့စည်းထားသော output များကို ထောက်ပံ့မှု

**💡 ဖန်တီးရေး အကျိုးကျေးဇူးများ**
- Zero-config မော်ဒယ် တပ်ဆင်ခြင်း
- Visual prompt အင်ဂျင်နီယာလုပ်ငန်း
- အချိန်နှင့်တပြေးညီ စမ်းသပ်ရေးကွင်း
- MCP server နှင့် ချိတ်ဆက်မှု ချောမွေ့ခြင်း

## 📚 သင်ယူရေးခရီးစဉ်

### [🚀 Module 1: AI Toolkit အခြေခံ](./lab1/README.md)
**ကာလ**: 15 မိနစ်
- 🛠️ VS Code အတွက် AI Toolkit တပ်ဆင်ပြီး ဖွင့်လှစ်ခြင်း
- 🗂️ Model Catalog ကို စူးစမ်းလေ့လာခြင်း (GitHub, ONNX, OpenAI, Anthropic, Google မှ မော်ဒယ် ၁၀၀ ကျော်)
- 🎮 အချိန်နှင့်တပြေးညီ မော်ဒယ်စမ်းသပ်မှုအတွက် Interactive Playground ကို ကျွမ်းကျင်စွာ အသုံးပြုခြင်း
- 🤖 Agent Builder ဖြင့် ပထမဆုံး AI agent တည်ဆောက်ခြင်း
- 📊 F1, relevance, similarity, coherence စတဲ့ built-in metrics များဖြင့် မော်ဒယ်လုပ်ဆောင်ချက် သုံးသပ်ခြင်း
- ⚡ batch processing နှင့် multi-modal ထောက်ပံ့မှု လေ့လာခြင်း

**🎯 သင်ယူရမယ့်ရလဒ်**: AITK ၏ အင်္ဂါရပ်များကို ပြည့်စုံသိရှိပြီး လုပ်ဆောင်နိုင်သော AI agent တစ်ခု ဖန်တီးနိုင်ခြင်း

### [🌐 Module 2: MCP နှင့် AI Toolkit အခြေခံ](./lab2/README.md)
**ကာလ**: 20 မိနစ်
- 🧠 Model Context Protocol (MCP) ၏ ဖွဲ့စည်းပုံနှင့် အယူအဆများ ကျွမ်းကျင်ခြင်း
- 🌐 Microsoft ၏ MCP server ecosystem ကို စူးစမ်းလေ့လာခြင်း
- 🤖 Playwright MCP server ကို အသုံးပြု၍ browser automation agent တည်ဆောက်ခြင်း
- 🔧 MCP servers များကို AI Toolkit Agent Builder နှင့် ချိတ်ဆက်ခြင်း
- 📊 MCP tools များကို agent အတွင်း စနစ်တကျ စမ်းသပ်တည်ဆောက်ခြင်း
- 🚀 MCP စွမ်းဆောင်ရည်ပါရှိသော agent များကို ထုတ်ပေးပြီး production သို့ တင်သွင်းခြင်း

**🎯 သင်ယူရမယ့်ရလဒ်**: MCP ဖြင့် အပြင် tools များနှင့် ချိတ်ဆက်ထားသော AI agent တစ်ခု ထုတ်လုပ်နိုင်ခြင်း

### [🔧 Module 3: AI Toolkit ဖြင့် အဆင့်မြင့် MCP ဖန်တီးခြင်း](./lab3/README.md)
**ကာလ**: 20 မိနစ်
- 💻 AI Toolkit ကို အသုံးပြု၍ custom MCP servers တည်ဆောက်ခြင်း
- 🐍 MCP Python SDK အသစ်ဆုံး (v1.9.3) ကို ဖွင့်လှစ်အသုံးပြုခြင်း
- 🔍 MCP Inspector ဖြင့် debugging ဆောင်ရွက်ခြင်း
- 🛠️ Weather MCP Server တည်ဆောက်ပြီး professional debugging workflow များ စီမံခြင်း
- 🧪 Agent Builder နှင့် Inspector ပတ်ဝန်းကျင်များတွင် MCP servers များကို debug လုပ်ခြင်း

**🎯 သင်ယူရမယ့်ရလဒ်**: စမတ်သော tooling များဖြင့် custom MCP servers များ ဖန်တီးပြီး debugging ပြုလုပ်နိုင်ခြင်း

### [🐙 Module 4: လက်တွေ့ MCP ဖန်တီးခြင်း - Custom GitHub Clone Server](./lab4/README.md)
**ကာလ**: 30 မိနစ်
- 🏗️ တကယ့်အသုံးပြုမှုအတွက် GitHub Clone MCP Server တည်ဆောက်ခြင်း
- 🔄 စမတ် repository cloning ကို အတည်ပြုခြင်းနှင့် error handling ဖြင့် ပြုလုပ်ခြင်း
- 📁 directory စီမံခန့်ခွဲမှု နှင့် VS Code integration တည်ဆောက်ခြင်း
- 🤖 GitHub Copilot Agent Mode ကို custom MCP tools နှင့် အသုံးပြုခြင်း
- 🛡️ စီးပွားရေးအဆင့် စနစ်တကျ ယုံကြည်စိတ်ချရမှုနှင့် cross-platform ကို လိုက်လျောညီထွေ ပြုလုပ်ခြင်း

**🎯 သင်ယူရမယ့်ရလဒ်**: လက်တွေ့ အသုံးပြုမှုများကို လွယ်ကူစေသော production-ready MCP server တစ်ခု ထုတ်လုပ်နိုင်ခြင်း

## 💡 လက်တွေ့ အသုံးချမှုများနှင့် သက်ရောက်မှု

### 🏢 စီးပွားရေးအသုံးပြုမှုများ

#### 🔄 DevOps Automation
သင့်ဖွံ့ဖြိုးရေးလုပ်ငန်းစဉ်ကို စမတ် automation ဖြင့် ပြောင်းလဲပါ-
- **Smart Repository Management**: AI အခြေပြု code review နှင့် merge ဆုံးဖြတ်ချက်များ
- **Intelligent CI/CD**: code ပြောင်းလဲမှုအပေါ် အလိုအလျောက် pipeline ကို optimize လုပ်ခြင်း
- **Issue Triage**: အမှားများကို အလိုအလျောက် သတ်မှတ်ခြင်းနှင့် တာဝန်ပေးခြင်း

#### 🧪 အရည်အသွေးအာမခံမှု ပြောင်းလဲမှု
AI အားဖြင့် စမ်းသပ်မှုကို မြှင့်တင်ပါ-
- **Intelligent Test Generation**: စမ်းသပ်မှု စနစ်များကို အလိုအလျောက် ဖန်တီးခြင်း
- **Visual Regression Testing**: AI ဖြင့် UI ပြောင်းလဲမှုများကို တွေ့ရှိခြင်း
- **Performance Monitoring**: ပြဿနာများကို ကြိုတင် သိရှိပြီး ဖြေရှင်းခြင်း

#### 📊 ဒေတာ စီးဆင်းမှု သဘောတရား
ပိုမို စမတ်သော ဒေတာ စီမံခန့်ခွဲမှု စနစ်များ တည်ဆောက်ခြင်း-
- **Adaptive ETL Processes**: ကိုယ်တိုင် ကိုက်ညီသွားမယ့် ဒေတာ ပြောင်းလဲမှုများ
- **Anomaly Detection**: အချိန်နှင့်တပြေးညီ ဒေတာ အရည်အသွေး စောင့်ကြည့်မှု
- **Intelligent Routing**: စမတ် ဒေတာ လမ်းကြောင်း စီမံခန့်ခွဲမှု

#### 🎧 ဖောက်သည် အတွေ့အကြုံ တိုးတက်မှု
ထူးခြားသော ဖောက်သည် ဝန်ဆောင်မှုများ ဖန်တီးပါ-
- **Context-Aware Support**: ဖောက်သည် သမိုင်းကြောင်းကို အသုံးပြုနိုင်သော AI agent များ
- **Proactive Issue Resolution**: ခန့်မှန်းနိုင်သော ဖောက်သည် ဝန်ဆောင်မှု
- **Multi-Channel Integration**: မျိုးစုံ ပလက်ဖောင်းများတွင် AI အတွေ့အကြုံ တစ်ခုတည်းဖြင့် ချိတ်ဆက်မှု

## 🛠️ မတိုင်မီလိုအပ်ချက်များနှင့် တပ်ဆင်ခြင်း

### 💻 စနစ်လိုအပ်ချက်များ

| အစိတ်အပိုင်း | လိုအပ်ချက် | မှတ်ချက် |
|-------------|-------------|----------|
| **Operating System** | Windows 10+, macOS 10.15+, Linux | မည်သည့်ခေတ်မီ OS မဆို |
| **Visual Studio Code** | နောက်ဆုံး stable ဗားရှင်း | AITK အတွက်လိုအပ်သည် |
| **Node.js** | v18.0+ နှင့် npm | MCP server ဖန်တီးရန် |
| **Python** | 3.10+ | Python MCP servers အတွက် ရွေးချယ်စရာ |
| **Memory** | အနည်းဆုံး 8GB RAM | local models အတွက် 16GB အကြံပြုသည် |

### 🔧 ဖန်တီးရေး ပတ်ဝန်းကျင်

#### အကြံပြု VS Code Extension များ
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) - ရွေးချယ်စရာဖြစ်ပြီး အထောက်အကူဖြစ်နိုင်သည်

#### ရွေးချယ်စရာကိရိယာများ
- **uv**: ခေတ်မီ Python package မန်နေဂျာ
- **MCP Inspector**: MCP server များအတွက် visual debugging ကိရိယာ
- **Playwright**: web automation နမူနာများအတွက်

## 🎖️ သင်ယူပြီးရရှိမည့် ကျွမ်းကျင်မှုများနှင့် အသိအမှတ်ပြုလမ်းကြောင်း

### 🏆 ကျွမ်းကျင်မှု စစ်ဆေးစာရင်း

ဒီ workshop ပြီးဆုံးရင် အောက်ပါ ကျွမ်းကျင်မှုများ ရရှိမှာဖြစ်ပါတယ်-

#### 🎯 အဓိက ကျွမ်းကျင်မှုများ
- [ ] **MCP Protocol ကျွမ်းကျင်မှု**: ဖွဲ့စည်းပုံနှင့် ဆောင်ရွက်နည်းများကို နက်နက်ရှိုင်းရှိုင်း သိရှိခြင်း
- [ ] **AITK ကျွမ်းကျင်မှု**: AI Toolkit ကို အမြန်တိုးတက်စွာ အသုံးပြုနိုင်ခြင်း
- [ ] **Custom Server ဖန်တီးမှု**: MCP servers များ တည်ဆောက်၊ ထုတ်လုပ် နှင့် ပြုပြင်ထိန်းသိမ်းနိုင်ခြင်း
- [ ] **Tool Integration ကျွမ်းကျင်မှု**: AI ကို ရှိပြီးသား ဖန်တီးရေးလုပ်ငန်းစဉ်များနှင့် ချိတ်ဆက်နိုင်ခြင်း
- [ ] **ပြဿနာဖြေရှင်းမှု**: လေ့လာသင်ယူထားသော ကျွမ်းကျင်မှုများကို စီးပွားရေး ပြဿနာများဖြေရှင်းရာတွင် အသုံးချနိုင်ခြင်း

#### 🔧 နည်းပညာ ကျွမ်းကျင်မှုများ
- [ ] VS Code တွင် AI Toolkit တပ်ဆင်ဖွင့်လှစ်ခြင်း
- [ ] custom MCP servers များ ဒီဇိုင်းဆွဲခြင်းနှင့် တည်ဆောက်ခြင်း
- [ ] GitHub Models များကို MCP architecture နှင့် ချိတ်ဆက်ခြင်း
- [ ] Playwright ဖြင့် အလိုအလျောက် စမ်းသပ်ရေး workflow များ ဖန်တီးခြင်း
- [ ] AI agents များကို production အသုံးပြုမှုအတွက် ထုတ်လုပ်ခြင်း
- [ ] MCP server performance ကို debug ပြုလုပ်ပြီး မြှင့်တင်ခြင်း

#### 🚀 အဆင့်မြင့် စွမ်းရည်များ
- [ ] စီးပွားရေးအဆင့် AI integration များ ဖန်တီးခြင်း
- [ ] AI application များအတွက် လုံခြုံရေး အကောင်းဆုံး နည်းလမ်းများ တပ်ဆင်ခြင်း
- [ ] MCP server architecture များကို တိုးချဲ့နိုင်စွမ်းရှိအောင် ဒီဇိုင်းဆွဲခြင်း
- [ ] အထူး domain များအတွက် custom tool chain များ ဖန်တီးခြင်း
- [ ] AI-native ဖန်တီးရေးတွင် အခြားသူများကို လမ်းညွှန်ပေးခြင်း

## 📖 အပိုဆောင်း အရင်းအမြစ်များ
- [MCP Specification](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub Repository](https://github.com/microsoft/vscode-ai-toolkit)
- [Sample MCP Servers Collection](https://github.com/modelcontextprotocol/servers)
- [Best Practices Guide](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 သင့် AI ဖန်တီးရေးလုပ်ငန်းစဉ်ကို ပြောင်းလဲဖို့ အသင့်ပါပြီလား?**

MCP နှင့် AI Toolkit တို့ဖြင့် အနာဂတ် အထူးစမတ် application များကို အတူတကွ တည်ဆောက်ကြရအောင်!

**ကြေညာချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေသော်လည်း အလိုအလျောက်ဘာသာပြန်မှုတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ဖြစ်ပေါ်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူလစာတမ်းကို မူရင်းဘာသာဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက်တော့ ပရော်ဖက်ရှင်နယ် လူသားဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှု အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်နိုင်သည့် နားမလည်မှုများ သို့မဟုတ် မှားယွင်းဖတ်ရှုမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မရှိပါ။