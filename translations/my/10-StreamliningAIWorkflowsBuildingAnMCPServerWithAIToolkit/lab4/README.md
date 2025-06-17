<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f83bc722dc758efffd68667d6a1db470",
  "translation_date": "2025-06-17T16:31:26+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/lab4/README.md",
  "language_code": "my"
}
-->
# 🐙 Module 4: Practical MCP Development - Custom GitHub Clone Server

![Duration](https://img.shields.io/badge/Duration-30_minutes-blue?style=flat-square)
![Difficulty](https://img.shields.io/badge/Difficulty-Intermediate-orange?style=flat-square)
![MCP](https://img.shields.io/badge/MCP-Custom%20Server-purple?style=flat-square&logo=github)
![VS Code](https://img.shields.io/badge/VS%20Code-Integration-blue?style=flat-square&logo=visualstudiocode)
![GitHub Copilot](https://img.shields.io/badge/GitHub%20Copilot-Agent%20Mode-green?style=flat-square&logo=github)

> **⚡ အမြန်စတင်ခြင်း:** GitHub repository များကို အလိုအလျောက် clone လုပ်ပေးပြီး VS Code နှင့်ပေါင်းစပ်အသုံးပြုနိုင်တဲ့ production-ready MCP server ကို ၃၀ မိနစ်အတွင်း တည်ဆောက်လိုက်ပါ။

## 🎯 သင်ယူရမည့် ရည်မှန်းချက်များ

ဤလက်တွေ့လေ့ကျင့်ခန်းပြီးဆုံးချိန်တွင် သင်သည် -

- ✅ လက်တွေ့အသုံးပြုမှုများအတွက် custom MCP server တည်ဆောက်နိုင်မည်
- ✅ MCP မှတဆင့် GitHub repository များ clone လုပ်နိုင်မည်
- ✅ custom MCP server များကို VS Code နှင့် Agent Builder တွင် ပေါင်းစပ်အသုံးပြုနိုင်မည်
- ✅ GitHub Copilot Agent Mode ကို custom MCP tools နှင့် အသုံးပြုနိုင်မည်
- ✅ production ပတ်ဝန်းကျင်များတွင် custom MCP server များ စမ်းသပ်၊ တင်သွင်းနိုင်မည်

## 📋 လိုအပ်ချက်များ

- Labs 1-3 (MCP အခြေခံနှင့် အဆင့်မြင့် ဖွံ့ဖြိုးမှုများ) ပြီးမြောက်ထားရှိခြင်း
- GitHub Copilot subscription ([အခမဲ့ စာရင်းသွင်းနိုင်ပါသည်](https://github.com/github-copilot/signup))
- VS Code တွင် AI Toolkit နှင့် GitHub Copilot extension များ ထည့်သွင်းထားရှိခြင်း
- Git CLI တပ်ဆင်ပြီး ပြင်ဆင်ထားခြင်း

## 🏗️ စီမံကိန်းအနှစ်ချုပ်

### **လက်တွေ့ဖွံ့ဖြိုးမှု စိန်ခေါ်မှု**
ဖွံ့ဖြိုးသူများအနေဖြင့် GitHub မှ repository များကို clone လုပ်ပြီး VS Code သို့မဟုတ် VS Code Insiders တွင် ဖွင့်ရခြင်းသည် လက်ဖြင့် လုပ်ဆောင်ရသော အဆင့်များဖြစ်သည်။
ဤလုပ်ငန်းစဉ်မှာ -
1. Terminal/command prompt ဖွင့်ခြင်း
2. လိုချင်သော directory သို့ သွားရောက်ခြင်း
3. `git clone` command ကို ရိုက်ထည့်ခြင်း
4. Clone လုပ်ထားသော directory တွင် VS Code ဖွင့်ခြင်း

**ကျွန်ုပ်တို့၏ MCP ဖြေရှင်းချက်သည် ဤလုပ်ငန်းစဉ်ကို တစ်ချက် command ဖြင့် ပြုလုပ်ပေးနိုင်ပါသည်။**

### **သင်တည်ဆောက်မည့်အရာ**
**GitHub Clone MCP Server** (`git_mcp_server`) သည် အောက်ပါအချက်များကို ပံ့ပိုးပေးပါသည် -

| လုပ်ဆောင်ချက် | ဖော်ပြချက် | အကျိုးကျေးဇူး |
|---------|-------------|---------|
| 🔄 **တော်တော်ကို အဆင်ပြေသော Repository Cloning** | GitHub repo များကို စစ်ဆေးပြီး clone လုပ်ပေးခြင်း | အမှားစစ်ဆေးမှုကို အလိုအလျောက် ပြုလုပ်ခြင်း |
| 📁 **အတိအကျ Directory စီမံခန့်ခွဲမှု** | directory များကို စစ်ဆေးပြီး လုံခြုံစွာ ဖန်တီးပေးခြင်း | မတော်တဆ overwrite ဖြစ်မှုကို ကာကွယ်ပေးခြင်း |
| 🚀 **Platform များစွာတွင် VS Code ပေါင်းစပ်ခြင်း** | VS Code/Insiders တွင် project များ ဖွင့်ပေးခြင်း | လုပ်ငန်းစဉ် ပြောင်းလဲမှုကို အဆင်ပြေစေခြင်း |
| 🛡️ **ခိုင်မာသော အမှားစီမံခန့်ခွဲမှု** | network, permission, path အခက်အခဲများကို ကိုင်တွယ်ပေးခြင်း | production အသုံးပြုမှုအတွက် ယုံကြည်စိတ်ချရမှု |

---

## 📖 လုပ်ဆောင်မှု အဆင့်ဆင့်

### အဆင့် ၁: Agent Builder တွင် GitHub Agent ဖန်တီးခြင်း

1. AI Toolkit extension မှတဆင့် **Agent Builder ကို စတင်ဖွင့်ပါ**
2. အောက်ပါ အချက်အလက်များဖြင့် **Agent အသစ် တစ်ခု ဖန်တီးပါ**
   ```
   Agent Name: GitHubAgent
   ```

3. **custom MCP server ကို စတင်ဖန်တီးခြင်း**
   - **Tools** → **Add Tool** → **MCP Server** သို့ သွားပါ
   - **"Create A new MCP Server"** ကို ရွေးချယ်ပါ
   - အလွန်တော်သော လွတ်လပ်မှုအတွက် **Python template** ကို ရွေးပါ
   - **Server Name:** `git_mcp_server`

### အဆင့် ၂: GitHub Copilot Agent Mode ကို ပြင်ဆင်ခြင်း

1. VS Code တွင် **GitHub Copilot ကို ဖွင့်ပါ** (Ctrl/Cmd + Shift + P → "GitHub Copilot: Open")
2. Copilot အင်တာဖေ့စ်တွင် **Agent Model ကို ရွေးချယ်ပါ**
3. ပိုမိုကောင်းမွန်သော မှတ်ချက်စဉ်များအတွက် **Claude 3.7 model** ကို ရွေးပါ
4. **MCP integration ကို ဖွင့်ပါ** (tool များအသုံးပြုရန်)

> **💡 အကြံပြုချက်:** Claude 3.7 သည် ဖွံ့ဖြိုးမှုလုပ်ငန်းစဉ်များနှင့် အမှားစီမံခန့်ခွဲမှု ပုံစံများကို ပိုမိုနက်ရှိုင်းစွာ နားလည်စေပါသည်။

### အဆင့် ၃: MCP Server အဓိကလုပ်ဆောင်ချက်များ အကောင်အထည်ဖော်ခြင်း

**GitHub Copilot Agent Mode ဖြင့် အောက်ပါ အသေးစိတ် prompt ကို အသုံးပြုပါ**

```
Create two MCP tools with the following comprehensive requirements:

🔧 TOOL A: clone_repository
Requirements:
- Clone any GitHub repository to a specified local folder
- Return the absolute path of the successfully cloned project
- Implement comprehensive validation:
  ✓ Check if target directory already exists (return error if exists)
  ✓ Validate GitHub URL format (https://github.com/user/repo)
  ✓ Verify git command availability (prompt installation if missing)
  ✓ Handle network connectivity issues
  ✓ Provide clear error messages for all failure scenarios

🚀 TOOL B: open_in_vscode
Requirements:
- Open specified folder in VS Code or VS Code Insiders
- Cross-platform compatibility (Windows/Linux/macOS)
- Use direct application launch (not terminal commands)
- Auto-detect available VS Code installations
- Handle cases where VS Code is not installed
- Provide user-friendly error messages

Additional Requirements:
- Follow MCP 1.9.3 best practices
- Include proper type hints and documentation
- Implement logging for debugging purposes
- Add input validation for all parameters
- Include comprehensive error handling
```

### အဆင့် ၄: MCP Server ကို စမ်းသပ်ခြင်း

#### 4a. Agent Builder တွင် စမ်းသပ်ခြင်း

1. Agent Builder အတွက် debug configuration ကို စတင်ဖွင့်ပါ
2. အောက်ပါ system prompt ဖြင့် သင့် agent ကို ပြင်ဆင်ပါ

```
SYSTEM_PROMPT:
You are my intelligent coding repository assistant. You help developers efficiently clone GitHub repositories and set up their development environment. Always provide clear feedback about operations and handle errors gracefully.
```

3. အမှန်တကယ်ဖြစ်နိုင်သော အသုံးပြုသူ အခြေအနေများဖြင့် စမ်းသပ်ပါ

```
USER_PROMPT EXAMPLES:

Scenario : Basic Clone and Open
"Clone {Your GitHub Repo link such as https://github.com/kinfey/GHCAgentWorkshop
 } and save to {The global path you specify}, then open it with VS Code Insiders"
```

![Agent Builder Testing](../../../../translated_images/DebugAgent.81d152370c503241b3b39a251b8966f7f739286df19dd57f9147f6402214a012.my.png)

**မျှော်မှန်းထားသော ရလဒ်များ**
- ✅ path အတည်ပြုချက်နှင့်အတူ cloning အောင်မြင်မှု
- ✅ VS Code ကို အလိုအလျောက် ဖွင့်ပေးခြင်း
- ✅ မှားယွင်းမှုရှိသော အခြေအနေများအတွက် ရှင်းလင်းသော error message များ
- ✅ အထူးအခြေအနေများကို သေချာစွာ ကိုင်တွယ်နိုင်ခြင်း

#### 4b. MCP Inspector တွင် စမ်းသပ်ခြင်း

![MCP Inspector Testing](../../../../translated_images/DebugInspector.eb5c95f94c69a8ba36944941b9a3588309a3a2fae101ace470ee09bde41d1667.my.png)

---

**🎉 ဂုဏ်ပြုပါတယ်!** သင်သည် လက်တွေ့အသုံးပြုနိုင်ပြီး production-ready MCP server တစ်ခုကို အောင်မြင်စွာ ဖန်တီးနိုင်ခဲ့ပါပြီ။ သင့် custom GitHub clone server သည် MCP ၏ စွမ်းအားကို အသုံးပြု၍ ဖွံ့ဖြိုးသူများ၏ အလုပ်လုပ်စဉ်များကို အလိုအလျောက် ပြုလုပ်ပေးနိုင်မှုကို ပြသပေးပါသည်။

### 🏆 ရရှိထားသော အောင်မြင်မှုများ
- ✅ **MCP Developer** - Custom MCP server တည်ဆောက်နိုင်ခြင်း
- ✅ **Workflow Automator** - ဖွံ့ဖြိုးမှုလုပ်ငန်းစဉ်များကို တိုးတက်စေခြင်း  
- ✅ **Integration Expert** - ဖွံ့ဖြိုးရေးကိရိယာများကို ပေါင်းစပ်နိုင်ခြင်း
- ✅ **Production Ready** - တင်သွင်းအသုံးပြုနိုင်သော ဖြေရှင်းချက်များ တည်ဆောက်နိုင်ခြင်း

---

## 🎓 သင်တန်းပြီးမြောက်ခြင်း: Model Context Protocol နှင့် သင့်ခရီး

**အထူးဂုဏ်ယူပါသော သင်တန်းသားများခင်ဗျာ၊**

Model Context Protocol သင်တန်း၏ မော်ဂျူးလ်လေးခုလုံးကို အောင်မြင်စွာ ပြီးမြောက်ခဲ့ကြသည်မှာ ဂုဏ်ယူစရာပါ။ AI Toolkit အခြေခံများကို နားလည်မှုမှ စ၍ လက်တွေ့အသုံးပြုနိုင်သော production-ready MCP server များ တည်ဆောက်နိုင်ရေးအထိ သင်တန်းတစ်ခုလုံးအတွင်း ရရှိခဲ့သည်။

### 🚀 သင့်သင်ယူမှုလမ်းကြောင်း ပြန်လည်သုံးသပ်ခြင်း

**[Module 1](../lab1/README.md)**: AI Toolkit အခြေခံများ၊ မော်ဒယ်စမ်းသပ်ခြင်း၊ ပထမဆုံး AI agent ဖန်တီးခြင်း

**[Module 2](../lab2/README.md)**: MCP architecture နားလည်ခြင်း၊ Playwright MCP ပေါင်းစပ်ခြင်း၊ browser automation agent တည်ဆောက်ခြင်း

**[Module 3](../lab3/README.md)**: custom MCP server ဖွံ့ဖြိုးမှု၊ Weather MCP server ဖန်တီးခြင်း၊ debugging ကိရိယာများ ကျွမ်းကျင်မှု

**[Module 4](../lab4/README.md)**: GitHub repository workflow အလိုအလျောက်လုပ်ဆောင်မှု tool တည်ဆောက်ခြင်း

### 🌟 သင်တတ်မြောက်ထားသောအရာများ

- ✅ **AI Toolkit Ecosystem**: မော်ဒယ်များ၊ agent များ၊ ပေါင်းစပ်မှုနည်းပညာများ
- ✅ **MCP Architecture**: client-server ဒီဇိုင်း၊ သယ်ယူပို့ဆောင်မှုနည်းပညာများ၊ လုံခြုံရေး
- ✅ **Developer Tools**: Playground, Inspector မှ production deployment အထိ
- ✅ **Custom Development**: MCP server များ တည်ဆောက်၊ စမ်းသပ်၊ တင်သွင်းခြင်း
- ✅ **လက်တွေ့အသုံးပြုမှုများ**: AI ဖြင့် လုပ်ငန်းစဉ်များ ပြုပြင်ပြောင်းလဲခြင်း

### 🔮 နောက်တစ်ဆင့် အစီအစဉ်များ

1. **သင့်ကိုယ်ပိုင် MCP Server တည်ဆောက်ပါ** - သင့် workflow များကို အလိုအလျောက်လုပ်ဆောင်ရန်
2. **MCP အသိုင်းအဝိုင်းသို့ ပူးပေါင်းပါ** - သင်၏ ဖန်တီးမှုများကို မျှဝေပြီး အခြားသူများထံမှ သင်ယူပါ
3. **အဆင့်မြင့် ပေါင်းစပ်မှုများ ရှာဖွေပါ** - MCP server များကို စီးပွားရေးစနစ်များနှင့် ချိတ်ဆက်ပါ
4. **Open Source တွင် ပံ့ပိုးပါ** - MCP ကိရိယာများနှင့် စာတမ်းများ တိုးတက်အောင် ကူညီပါ

ဤသင်တန်းသည် စတင်ခြင်းသာဖြစ်ပြီး Model Context Protocol ecosystem သည် အလွန်မြန်ဆန်စွာ ဖွံ့ဖြိုးနေပါသည်။ သင်သည် AI စွမ်းအားဖြင့် တီထွင်ဖန်တီးမှုကိရိယာများ၏ ရှေ့ဆောင်တစ်ဦးဖြစ်ရန် ပြင်ဆင်ပြီးဖြစ်ပါသည်။

**သင်တန်းတွင် ပါဝင်ပေးမှုနှင့် သင်ယူမှုအတွက် ကျေးဇူးအထူးတင်ရှိပါသည်။**

AI tool များနှင့် သင်၏ ဖွံ့ဖြိုးရေးခရီးကို ပိုမိုကောင်းမွန်စေမည့် စိတ်ကူးများကို ဤသင်တန်းက ဖန်တီးပေးနိုင်ခဲ့ကြောင်း မျှော်လင့်ပါသည်။

**ကိုဒ်ရေးသားရာတွင် ပျော်ရွှင်ပါစေ!**

---

**ကန့်သတ်ချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ချက်များတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် လိုအပ်ပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ တရားဝင် အချက်အလက်အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် ကျွမ်းကျင်သော လူသားဘာသာပြန်မှ ပြုလုပ်ရန် အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမမှန်ခြင်းများ သို့မဟုတ် အဓိပ္ပာယ်အပြောင်းအလဲများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။