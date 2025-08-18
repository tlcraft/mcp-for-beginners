<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d26f746e21775c30b4d7ed97962b24df",
  "translation_date": "2025-08-18T18:53:46+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို အလုပ်လုပ်စေခြင်း

`uv` ကို install လုပ်ရန် အကြံပြုထားပေမယ့် မဖြစ်မနေလိုအပ်တာမဟုတ်ပါဘူး၊ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကိုကြည့်ပါ။

## -0- Virtual environment တစ်ခု ဖန်တီးပါ

```bash
python -m venv venv
```

## -1- Virtual environment ကို အလုပ်လုပ်စေပါ

```bash
venv\Scripts\activate
```

## -2- လိုအပ်သော dependencies များကို install လုပ်ပါ

```bash
pip install "mcp[cli]"
```

## -3- နမူနာကို အလုပ်လုပ်စေပါ

```bash
mcp run server.py
```

## -4- နမူနာကို စမ်းသပ်ပါ

Server ကို terminal တစ်ခုမှာ အလုပ်လုပ်နေစဉ်၊ အခြား terminal တစ်ခုဖွင့်ပြီး အောက်ပါ command ကို run လုပ်ပါ:

```bash
mcp dev server.py
```

ဒါက visual interface ပါဝင်တဲ့ web server တစ်ခုကို စတင်ပါမည်၊ နမူနာကို စမ်းသပ်နိုင်စေပါသည်။

Server တစ်ခုချိတ်ဆက်ပြီးနောက်:

- tools များကို စမ်းသပ်ကြည့်ပြီး `add` ကို args 2 နှင့် 4 ဖြင့် run လုပ်ပါ၊ ရလဒ်မှာ 6 ဖြစ်ရမည်။

- resources နှင့် resource template သို့သွားပြီး get_greeting ကို call လုပ်ပါ၊ နာမည်တစ်ခုရိုက်ထည့်ပြီး သင့်ရိုက်ထည့်ထားသော နာမည်နှင့်အတူ greeting တစ်ခုကို မြင်ရမည်။

### CLI mode တွင် စမ်းသပ်ခြင်း

သင့်ရဲ့ inspector သည် အမှန်အားဖြင့် Node.js app တစ်ခုဖြစ်ပြီး `mcp dev` သည် ၎င်းကို wrap လုပ်ထားသော command တစ်ခုဖြစ်သည်။

CLI mode တွင် တိုက်ရိုက်စတင်ရန် အောက်ပါ command ကို run လုပ်ပါ:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

ဒါက server တွင် ရရှိနိုင်သော tools များအားလုံးကို ပြသပါမည်။ အောက်ပါ output ကို မြင်ရမည်:

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

Tool တစ်ခုကို invoke လုပ်ရန်:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

အောက်ပါ output ကို မြင်ရမည်:

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
> CLI mode တွင် inspector ကို run လုပ်ခြင်းသည် browser တွင် run လုပ်ခြင်းထက် အချိန်ပိုမိုတိုတောင်းသည်။
> Inspector အကြောင်းပိုမိုဖတ်ရှုရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ကြည့်ပါ။

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူပညာရှင်များမှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပာယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။ 