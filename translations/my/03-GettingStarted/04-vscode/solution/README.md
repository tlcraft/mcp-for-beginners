<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:41:21+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "my"
}
-->
# စမ်းသပ်မှုကို chạyခြင်း

ဒီမှာ သင့်မှာ အလုပ်လုပ်နေတဲ့ server code ရှိပြီးသားဖြစ်ကြောင်း ယူဆထားပါတယ်။ မကြာသေးမီအခန်းတွေထဲက server တစ်ခုကို ရှာဖွေပါ။

## mcp.json ကို စီစဉ်ခြင်း

ဒီမှာ ကိုးကားရန်အသုံးပြုမယ့် ဖိုင်တစ်ခုရှိပါတယ်၊ [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json)။

သင့် server ရဲ့ အပြည့်အစုံ လမ်းကြောင်းနဲ့ လိုအပ်တဲ့ command အပြည့်အစုံကို ပြောင်းလဲပြင်ဆင်ပါ။

အထက်ဖော်ပြထားတဲ့ ဥပမာဖိုင်မှာ server entry က ဒီလိုပုံစံရှိပါတယ်-

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

ဒါဟာ ဒီလို command တစ်ခုကို chạyတာနဲ့ ဆင်တူပါတယ်- `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` "add 3 to 20" ဆိုတဲ့ စကားလုံးတစ်ခုလို ရိုက်ထည့်ပါ။

    သင့်ကို chat စာသားသေတ္တာအပေါ်မှာ tool တစ်ခုကို ရွေးချယ်ဖို့ ပြသပေးမှာ ဖြစ်ပြီး ဒီလိုမြင်ရပါလိမ့်မယ်-

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.my.png)

    tool ကို ရွေးချယ်ခြင်းဖြင့် "23" ဆိုတဲ့ နံပါတ်ရလဒ်ကို ထုတ်ပေးပါလိမ့်မယ်၊ သင့် prompt က အထက်ဖော်ပြသလိုဖြစ်ခဲ့ရင်ဖြစ်ပါတယ်။

**အတည်မပြုချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေသော်လည်း အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မူရင်းဘာသာဖြင့်သာ အတည်ပြုရမည့် အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် မူရင်းလူ့ဘာသာပြန်သူမှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။