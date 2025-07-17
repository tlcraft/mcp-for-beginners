<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8ea28e5e566edd5969337fd0b191ba3f",
  "translation_date": "2025-07-17T12:48:22+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "my"
}
-->
# GitHub Copilot Agent mode မှာ server တစ်ခုကို အသုံးပြုခြင်း

Visual Studio Code နဲ့ GitHub Copilot ဟာ client အနေနဲ့ MCP Server ကို အသုံးပြုနိုင်ပါတယ်။ ဘာကြောင့် ဒီလိုလုပ်ချင်တာလဲဆိုတော့ MCP Server ရဲ့ feature တွေကို IDE ထဲကနေ တိုက်ရိုက်အသုံးပြုနိုင်တာပါ။ ဥပမာ GitHub ရဲ့ MCP server ကို ထည့်လိုက်ရင် terminal မှာ command တွေ ရိုက်ထည့်စရာမလိုပဲ prompt တွေဖြင့် GitHub ကို ထိန်းချုပ်နိုင်မှာဖြစ်ပါတယ်။ ဒါမှမဟုတ် developer အတွေ့အကြုံကို တိုးတက်စေမယ့် ဘာမှန်းမသိတဲ့ feature တွေကို သဘာဝဘာသာစကားနဲ့ ထိန်းချုပ်နိုင်တာကို စဉ်းစားကြည့်ပါ။ အခုတော့ အောင်မြင်မှုကို မြင်လာပြီနော်?

## အနှစ်ချုပ်

ဒီသင်ခန်းစာမှာ Visual Studio Code နဲ့ GitHub Copilot ရဲ့ Agent mode ကို MCP Server အတွက် client အနေနဲ့ ဘယ်လိုအသုံးပြုရမလဲ ဆိုတာကို ဖော်ပြထားပါတယ်။

## သင်ယူရမယ့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာပြီးဆုံးတဲ့အချိန်မှာ သင်မှာ အောက်ပါအရာတွေကို လုပ်နိုင်ပါလိမ့်မယ်-

- Visual Studio Code မှတဆင့် MCP Server ကို အသုံးပြုနိုင်မယ်။
- GitHub Copilot မှတဆင့် tools စသည့် လုပ်ဆောင်ချက်တွေကို ပြေးနိုင်မယ်။
- Visual Studio Code ကို သင့် MCP Server ကို ရှာဖွေပြီး စီမံခန့်ခွဲဖို့ ပြင်ဆင်နိုင်မယ်။

## အသုံးပြုနည်း

သင့် MCP server ကို နှစ်မျိုးနည်းလမ်းနဲ့ ထိန်းချုပ်နိုင်ပါတယ်-

- User interface, ဒီအပိုင်းကို ဒီအခန်းမှာ နောက်ပိုင်းမှာ ပြသပါမယ်။
- Terminal, `code` executable ကို အသုံးပြုပြီး terminal မှာ ထိန်းချုပ်နိုင်ပါတယ်-

  သင့် user profile ထဲ MCP server တစ်ခု ထည့်ရန် --add-mcp command line option ကို အသုံးပြုပြီး JSON server configuration ကို {\"name\":\"server-name\",\"command\":...} ပုံစံနဲ့ ပေးပါ။

  ```
  code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
  ```

### ပုံရိပ်များ

![Visual Studio Code မှာ MCP server ကို လမ်းညွှန်ပြီး ပြင်ဆင်ခြင်း](../../../../translated_images/chat-mode-agent.729a22473f822216dd1e723aaee1f7d4a2ede571ee0948037a2d9357a63b9d0b.my.png)
![Agent session တစ်ခုစီအတွက် tool ရွေးချယ်ခြင်း](../../../../translated_images/agent-mode-select-tools.522c7ba5df0848f8f0d1e439c2e96159431bc620cb39ccf3f5dc611412fd0006.my.png)
![MCP ဖွံ့ဖြိုးတိုးတက်မှုအတွင်း အမှားများကို လွယ်ကူစွာ debug လုပ်ခြင်း](../../../../translated_images/mcp-list-servers.fce89eefe3f30032bed8952e110ab9d82fadf043fcfa071f7d40cf93fb1ea9e9.my.png)

နောက်ပိုင်းအပိုင်းတွေမှာ visual interface ကို ဘယ်လိုအသုံးပြုရမလဲ ဆိုတာကို ပိုမိုဆွေးနွေးကြမယ်။

## နည်းလမ်း

အထက်တန်းအဆင့်မှာ ဒီလို လုပ်ဆောင်ရမယ်-

- MCP Server ကို ရှာဖွေရန် ဖိုင်တစ်ခုကို ပြင်ဆင်ပါ။
- ထို server ကို စတင်/ချိတ်ဆက်ပြီး ၎င်းရဲ့ လုပ်ဆောင်ချက်များကို ပြပါ။
- GitHub Copilot Chat interface မှတဆင့် ထိုလုပ်ဆောင်ချက်များကို အသုံးပြုပါ။

အိုကေ၊ လမ်းကြောင်းကို နားလည်သွားပြီဆိုတော့ Visual Studio Code မှတဆင့် MCP Server ကို အသုံးပြုကြည့်ရအောင်။

## လေ့ကျင့်ခန်း: server တစ်ခုကို အသုံးပြုခြင်း

ဒီလေ့ကျင့်ခန်းမှာ Visual Studio Code ကို သင့် MCP server ကို ရှာဖွေဖို့ ပြင်ဆင်ပြီး GitHub Copilot Chat interface မှတဆင့် အသုံးပြုနိုင်အောင် လုပ်ပါမယ်။

### -0- အစပိုင်း၊ MCP Server ရှာဖွေရန် ဖွင့်ပါ

MCP Servers ရှာဖွေရန် ဖွင့်ထားဖို့ လိုအပ်နိုင်ပါတယ်။

1. Visual Studio Code မှာ `File -> Preferences -> Settings` ကို သွားပါ။

1. "MCP" ကို ရှာပြီး settings.json ဖိုင်ထဲမှာ `chat.mcp.discovery.enabled` ကို ဖွင့်ပါ။

### -1- config ဖိုင် ဖန်တီးခြင်း

သင့် project root မှာ config ဖိုင်တစ်ခု ဖန်တီးပါ၊ MCP.json ဆိုတဲ့ ဖိုင်တစ်ခုကို .vscode ဆိုတဲ့ folder ထဲမှာ ထည့်ရပါမယ်။ ဒီလိုပုံစံမျိုး ဖြစ်သင့်ပါတယ်-

```text
.vscode
|-- mcp.json
```

နောက်တစ်ခုက server entry ကို ဘယ်လိုထည့်ရမလဲ ကြည့်ကြရအောင်။

### -2- server ကို ပြင်ဆင်ခြင်း

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

အထက်မှာ Node.js နဲ့ server တစ်ခု စတင်ဖို့ ရိုးရှင်းတဲ့ ဥပမာတစ်ခုပါ၊ အခြား runtime တွေအတွက်တော့ `command` နဲ့ `args` ကို သင့်တော်တဲ့ server စတင် command နဲ့ ပြောင်းပါ။

### -3- server ကို စတင်ခြင်း

Entry ထည့်ပြီးသွားပြီဆို server ကို စတင်ကြည့်ရအောင်-

1. *mcp.json* ထဲမှာ သင့် entry ကို ရှာပြီး "play" icon ကို ရှာပါ-

  ![Visual Studio Code မှာ server စတင်ခြင်း](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.my.png)  

1. "play" icon ကို နှိပ်လိုက်ပါ၊ GitHub Copilot Chat မှာ tools icon ရဲ့ အရေအတွက် တိုးလာတာကို တွေ့ရပါမယ်။ tools icon ကို နှိပ်လိုက်ရင် မှတ်ပုံတင်ထားတဲ့ tools စာရင်းကို မြင်ရပါမယ်။ GitHub Copilot ကို context အနေနဲ့ အသုံးပြုချင်တဲ့ tool တွေကို စစ်/မစစ်နိုင်ပါတယ်-

  ![Visual Studio Code မှာ server စတင်ခြင်း](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.my.png)

1. tool တစ်ခုကို ပြေးရန်၊ သင့် tool တစ်ခုရဲ့ ဖော်ပြချက်နဲ့ ကိုက်ညီမယ့် prompt တစ်ခု ရိုက်ထည့်ပါ၊ ဥပမာ "add 22 to 1" ဆိုတဲ့ prompt လိုမျိုး-

  ![GitHub Copilot မှ tool တစ်ခုကို ပြေးခြင်း](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.my.png)

  ၂၃ ဆိုတဲ့ အဖြေကို မြင်ရပါမယ်။

## လုပ်ငန်းတာဝန်

သင့် *mcp.json* ဖိုင်ထဲ server entry တစ်ခု ထည့်ပြီး server ကို စတင်/ရပ်တန့်နိုင်မှုကို စမ်းကြည့်ပါ။ GitHub Copilot Chat interface မှတဆင့် server ရဲ့ tools တွေနဲ့ ဆက်သွယ်နိုင်မှုကိုလည်း သေချာစစ်ဆေးပါ။

## ဖြေရှင်းချက်

[Solution](./solution/README.md)

## အဓိက သင်ခန်းစာများ

ဒီအခန်းကနေ သင်ယူရမယ့် အချက်တွေကတော့-

- Visual Studio Code က MCP Servers အများကြီးနဲ့ tools တွေကို အသုံးပြုခွင့်ပေးတဲ့ client အကောင်းဆုံးတစ်ခုဖြစ်ပါတယ်။
- GitHub Copilot Chat interface က server တွေနဲ့ ဆက်သွယ်ရာမှာ အသုံးပြုတဲ့ နည်းလမ်းဖြစ်ပါတယ်။
- *mcp.json* ဖိုင်ထဲ server entry ပြင်ဆင်တဲ့အခါ API key စသည့် user input တွေကို prompt ပေးပြီး MCP Server ကို ပေးပို့နိုင်ပါတယ်။

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## အပိုဆောင်း အရင်းအမြစ်များ

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## နောက်တစ်ဆင့်

- နောက်တစ်ဆင့်: [SSE Server တစ်ခု ဖန်တီးခြင်း](../05-sse-server/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။