<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "54e9ffc5dba01afcb8880a9949fd1881",
  "translation_date": "2025-07-13T19:37:26+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "my"
}
-->
နောက်ပိုင်းအပိုင်းတွေမှာတော့ visual interface ကို ဘယ်လိုအသုံးပြုရမယ်ဆိုတာကို ပိုမိုဆွေးနွေးကြမယ်။

## နည်းလမ်း

အထက်တန်းမှာ ဒီလိုနည်းလမ်းနဲ့ ရှေ့ဆက်ရမှာဖြစ်ပါတယ်-

- MCP Server ကို ရှာဖွေဖို့ ဖိုင်တစ်ခုကို ပြင်ဆင်ပါ။
- အဆိုပါ server ကို စတင်/ချိတ်ဆက်ပြီး ၎င်းရဲ့ စွမ်းဆောင်ရည်များကို စာရင်းပြုစုပါ။
- GitHub Copilot Chat interface မှတဆင့် အဆိုပါ စွမ်းဆောင်ရည်များကို အသုံးပြုပါ။

အရမ်းကောင်းပြီ၊ ဒီ flow ကို နားလည်သွားပြီဆိုတော့ Visual Studio Code မှတဆင့် MCP Server ကို အသုံးပြုကြည့်ကြမယ်။

## လေ့ကျင့်ခန်း: Server ကို အသုံးပြုခြင်း

ဒီလေ့ကျင့်ခန်းမှာတော့ Visual Studio Code ကို သင့် MCP server ကို ရှာဖွေဖို့ ပြင်ဆင်ပြီး GitHub Copilot Chat interface မှတဆင့် အသုံးပြုနိုင်အောင် လုပ်ပါမယ်။

### -0- အစပိုင်း၊ MCP Server ရှာဖွေရန် ဖွင့်ပါ

MCP Servers ရှာဖွေရန် ဖွင့်ထားဖို့ လိုအပ်နိုင်ပါတယ်။

1. Visual Studio Code မှာ `File -> Preferences -> Settings` ကို သွားပါ။

1. "MCP" ကို ရှာပြီး settings.json ဖိုင်ထဲမှာ `chat.mcp.discovery.enabled` ကို ဖွင့်ပါ။

### -1- config ဖိုင် ဖန်တီးခြင်း

ပရောဂျက်ရဲ့ root folder မှာ MCP.json ဆိုတဲ့ ဖိုင်တစ်ခုကို .vscode ဆိုတဲ့ ဖိုလ်ဒါထဲမှာ ဖန်တီးပါ။ အောက်ပါပုံစံနဲ့ ဖြစ်သင့်ပါတယ်-

```text
.vscode
|-- mcp.json
```

နောက်တစ်ခုက server entry ကို ဘယ်လိုထည့်မလဲဆိုတာ ကြည့်ကြမယ်။

### -2- Server ကို ပြင်ဆင်ခြင်း

*mcp.json* ထဲမှာ အောက်ပါအကြောင်းအရာကို ထည့်ပါ-

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

အထက်မှာ Node.js နဲ့ server ကို စတင်ဖို့ ရိုးရှင်းတဲ့ ဥပမာတစ်ခုပါ၊ အခြား runtime တွေအတွက်တော့ `command` နဲ့ `args` ကို သင့်တော်တဲ့ server စတင်ဖို့ command နဲ့ ပြောင်းလဲရေးပါ။

### -3- Server ကို စတင်ပါ

Entry ထည့်ပြီးသွားပြီဆိုတော့ server ကို စတင်ကြည့်ပါ-

1. *mcp.json* ထဲမှာ သင့် entry ကို ရှာပြီး "play" icon ကို တွေ့ပါ-

  ![Starting server in Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.my.png)  

1. "play" icon ကို နှိပ်ပါ၊ GitHub Copilot Chat မှာ tools icon ရဲ့ အရေအတွက် တိုးလာတာကို တွေ့ရပါမယ်။ tools icon ကို နှိပ်ရင် မှတ်ပုံတင်ထားတဲ့ tools စာရင်းကို မြင်ရပါမယ်။ GitHub Copilot ကို context အနေနဲ့ အသုံးပြုချင်တဲ့ tool တွေကို စစ်/မစစ် ရွေးချယ်နိုင်ပါတယ်-

  ![Starting server in Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.my.png)

1. Tool တစ်ခုကို လည်ပတ်ဖို့တော့ သင့် tool တစ်ခုရဲ့ ဖော်ပြချက်နဲ့ ကိုက်ညီမယ့် prompt တစ်ခု ရိုက်ထည့်ပါ၊ ဥပမာ "add 22 to 1" ဆိုတဲ့ prompt လို-

  ![Running a tool from GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.my.png)

  ၂၃ ဆိုတဲ့ အဖြေကို မြင်ရပါမယ်။

## အလုပ်အပ်

*mcp.json* ဖိုင်ထဲ server entry တစ်ခု ထည့်ပြီး server ကို စတင်/ရပ်တန့်နိုင်ကြောင်း သေချာစေပါ။ GitHub Copilot Chat interface မှတဆင့် server ရဲ့ tools တွေနဲ့ ဆက်သွယ်နိုင်ကြောင်းလည်း သေချာစေပါ။

## ဖြေရှင်းချက်

[Solution](./solution/README.md)

## အဓိက သင်ခန်းစာများ

ဒီအခန်းကနေ သင်ယူရမယ့် အချက်တွေကတော့-

- Visual Studio Code က MCP Servers အများကြီးနဲ့ tools တွေကို အသုံးပြုခွင့်ပေးတဲ့ client ကောင်းတစ်ခုဖြစ်ပါတယ်။
- GitHub Copilot Chat interface က server တွေနဲ့ ဆက်သွယ်ရာမှာ အသုံးပြုတဲ့ နည်းလမ်းဖြစ်ပါတယ်။
- *mcp.json* ဖိုင်ထဲ server entry ပြင်ဆင်တဲ့အခါ API key စသည့် အသုံးပြုသူ input များကို prompt ပေးပြီး MCP Server ကို ပေးပို့နိုင်ပါတယ်။

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## အပိုဆောင်း အရင်းအမြစ်များ

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## နောက်တစ်ဆင့်

- နောက်တစ်ဆင့်: [Creating an SSE Server](../05-sse-server/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။