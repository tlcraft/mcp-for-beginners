<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d26f746e21775c30b4d7ed97962b24df",
<<<<<<< HEAD
  "translation_date": "2025-08-18T23:30:57+00:00",
=======
  "translation_date": "2025-08-18T18:53:46+00:00",
>>>>>>> origin/main
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "my"
}
-->
<<<<<<< HEAD
# ဒီနမူနာကို အလုပ်လုပ်ရန်

`uv` ကိုတပ်ဆင်ရန် အကြံပြုထားပါသည်၊ သို့သော် မလိုအပ်လျှင်လည်း ရနိုင်ပါသည်။ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကို ကြည့်ပါ။

## -0- အတုပတ်ဝန်းကျင် တည်ဆောက်ရန်
=======
# ဒီနမူနာကို အလုပ်လုပ်စေခြင်း

`uv` ကို install လုပ်ရန် အကြံပြုထားပေမယ့် မဖြစ်မနေလိုအပ်တာမဟုတ်ပါဘူး၊ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကိုကြည့်ပါ။

## -0- Virtual environment တစ်ခု ဖန်တီးပါ
>>>>>>> origin/main

```bash
python -m venv venv
```

<<<<<<< HEAD
## -1- အတုပတ်ဝန်းကျင်ကို ဖွင့်ရန်
=======
## -1- Virtual environment ကို အလုပ်လုပ်စေပါ
>>>>>>> origin/main

```bash
venv\Scripts\activate
```

<<<<<<< HEAD
## -2- လိုအပ်သော အချက်အလက်များကို တပ်ဆင်ရန်
=======
## -2- လိုအပ်သော dependencies များကို install လုပ်ပါ
>>>>>>> origin/main

```bash
pip install "mcp[cli]"
```

<<<<<<< HEAD
## -3- နမူနာကို အလုပ်လုပ်ရန်
=======
## -3- နမူနာကို အလုပ်လုပ်စေပါ
>>>>>>> origin/main

```bash
mcp run server.py
```

<<<<<<< HEAD
## -4- နမူနာကို စမ်းသပ်ရန်

တစ်ခုသော terminal တွင် server ကို အလုပ်လုပ်နေစဉ်၊ အခြား terminal တစ်ခုကို ဖွင့်ပြီး အောက်ပါ command ကို အလုပ်လုပ်ပါ:
=======
## -4- နမူနာကို စမ်းသပ်ပါ

Server ကို terminal တစ်ခုမှာ အလုပ်လုပ်နေစဉ်၊ အခြား terminal တစ်ခုဖွင့်ပြီး အောက်ပါ command ကို run လုပ်ပါ:
>>>>>>> origin/main

```bash
mcp dev server.py
```

<<<<<<< HEAD
ဒီနည်းလမ်းဖြင့် visual interface ပါသော web server တစ်ခုကို စတင်နိုင်ပြီး နမူနာကို စမ်းသပ်နိုင်ပါသည်။

Server တစ်ခုနှင့် ချိတ်ဆက်ပြီးနောက်:

- tools များကို စမ်းသပ်ရန် `add` ကို args 2 နှင့် 4 ဖြင့် အလုပ်လုပ်ပါ၊ ရလဒ်အဖြစ် 6 ကို မြင်ရမည်ဖြစ်သည်။

- resources နှင့် resource template သို့သွားပြီး `get_greeting` ကို ခေါ်ပါ၊ နာမည်တစ်ခု ရိုက်ထည့်ပြီး သင့်ရိုက်ထည့်ထားသော နာမည်နှင့်အတူ greeting ကို မြင်ရမည်ဖြစ်သည်။

### CLI mode တွင် စမ်းသပ်ခြင်း

သင့်အလုပ်လုပ်နေသော inspector သည် အမှန်အားဖြင့် Node.js app တစ်ခုဖြစ်ပြီး `mcp dev` သည် ၎င်းကို အုပ်ထားသော wrapper တစ်ခုဖြစ်သည်။

CLI mode တွင် တိုက်ရိုက်စတင်ရန် အောက်ပါ command ကို အလုပ်လုပ်ပါ:
=======
ဒါက visual interface ပါဝင်တဲ့ web server တစ်ခုကို စတင်ပါမည်၊ နမူနာကို စမ်းသပ်နိုင်စေပါသည်။

Server တစ်ခုချိတ်ဆက်ပြီးနောက်:

- tools များကို စမ်းသပ်ကြည့်ပြီး `add` ကို args 2 နှင့် 4 ဖြင့် run လုပ်ပါ၊ ရလဒ်မှာ 6 ဖြစ်ရမည်။

- resources နှင့် resource template သို့သွားပြီး get_greeting ကို call လုပ်ပါ၊ နာမည်တစ်ခုရိုက်ထည့်ပြီး သင့်ရိုက်ထည့်ထားသော နာမည်နှင့်အတူ greeting တစ်ခုကို မြင်ရမည်။

### CLI mode တွင် စမ်းသပ်ခြင်း

သင့်ရဲ့ inspector သည် အမှန်အားဖြင့် Node.js app တစ်ခုဖြစ်ပြီး `mcp dev` သည် ၎င်းကို wrap လုပ်ထားသော command တစ်ခုဖြစ်သည်။

CLI mode တွင် တိုက်ရိုက်စတင်ရန် အောက်ပါ command ကို run လုပ်ပါ:
>>>>>>> origin/main

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

<<<<<<< HEAD
ဒီနည်းလမ်းဖြင့် server တွင် ရရှိနိုင်သော tools များအားလုံးကို စာရင်းပြပါမည်။ အောက်ပါ output ကို မြင်ရမည်ဖြစ်သည်:
=======
ဒါက server တွင် ရရှိနိုင်သော tools များအားလုံးကို ပြသပါမည်။ အောက်ပါ output ကို မြင်ရမည်:
>>>>>>> origin/main

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

<<<<<<< HEAD
Tool တစ်ခုကို ခေါ်ရန်:
=======
Tool တစ်ခုကို invoke လုပ်ရန်:
>>>>>>> origin/main

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

<<<<<<< HEAD
အောက်ပါ output ကို မြင်ရမည်ဖြစ်သည်:
=======
အောက်ပါ output ကို မြင်ရမည်:
>>>>>>> origin/main

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
<<<<<<< HEAD
> CLI mode တွင် inspector ကို အလုပ်လုပ်ရန် browser ထက် ပိုမိုမြန်ဆန်သော အခါများစွာ ရှိပါသည်။
> Inspector အကြောင်းပိုမိုဖတ်ရှုရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ကြည့်ပါ။

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ဆိုမှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူက ဘာသာပြန်ဆိုမှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားမှုများ သို့မဟုတ် အဓိပ္ပါယ်မှားမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။ 
=======
> CLI mode တွင် inspector ကို run လုပ်ခြင်းသည် browser တွင် run လုပ်ခြင်းထက် အချိန်ပိုမိုတိုတောင်းသည်။
> Inspector အကြောင်းပိုမိုဖတ်ရှုရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ကြည့်ပါ။

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူပညာရှင်များမှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပာယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။ 
>>>>>>> origin/main
