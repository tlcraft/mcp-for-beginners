<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "69ba3bd502bd743233137bac5539c08b",
  "translation_date": "2025-08-18T18:55:45+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို အလုပ်လုပ်စေခြင်း

`uv` ကိုတပ်ဆင်ရန် အကြံပြုထားပါတယ်၊ ဒါပေမယ့် မဖြစ်မနေလိုအပ်တာမဟုတ်ပါဘူး။ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကိုကြည့်ပါ။

## -0- အတုပတ်ဝန်းကျင် တည်ဆောက်ပါ

```bash
python -m venv venv
```

## -1- အတုပတ်ဝန်းကျင်ကို အလုပ်လုပ်စေပါ

```bash
venv\Scrips\activate
```

## -2- လိုအပ်သော အချက်အလက်များကို တပ်ဆင်ပါ

```bash
pip install "mcp[cli]"
```

## -3- နမူနာကို အလုပ်လုပ်စေပါ

```bash
uvicorn server:app
```

## -4- နမူနာကို စမ်းသပ်ပါ

တစ်ခုသော terminal မှာ server ကို အလုပ်လုပ်နေစဉ်၊ အခြား terminal တစ်ခုဖွင့်ပြီး အောက်ပါ command ကို run လုပ်ပါ:

```bash
mcp dev server.py
```

ဒီနည်းလမ်းဖြင့် visual interface ပါတဲ့ web server တစ်ခုစတင်ပြီး နမူနာကို စမ်းသပ်နိုင်ပါမည်။

Server တစ်ခုချိတ်ဆက်ပြီးနောက်:

- tools များကို စမ်းသပ်ကြည့်ပြီး `add` ကို args 2 နှင့် 4 ဖြင့် run လုပ်ပါ၊ ရလဒ်မှာ 6 ဖြစ်ရမည်။
- resources နှင့် resource template သို့သွားပြီး `get_greeting` ကိုခေါ်ပါ၊ နာမည်တစ်ခုရိုက်ထည့်ပြီး သင့်ရိုက်ထည့်ထားသော နာမည်နှင့်အတူ greeting တစ်ခုကို မြင်ရမည်။

### CLI mode တွင် စမ်းသပ်ခြင်း

သင့်ရဲ့ inspector သည် အမှန်အားဖြင့် Node.js app တစ်ခုဖြစ်ပြီး `mcp dev` သည် ထို app ကို wrap လုပ်ထားသော command တစ်ခုဖြစ်သည်။

CLI mode တွင် တိုက်ရိုက်စတင်ရန် အောက်ပါ command ကို run လုပ်ပါ:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

ဒီနည်းလမ်းဖြင့် server တွင် ရရှိနိုင်သော tools များအားလုံးကို စာရင်းပြပါမည်။ အောက်ပါ output ကို မြင်ရမည်:

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

Tool တစ်ခုကို ခေါ်ရန်:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> CLI mode တွင် inspector ကို run လုပ်ခြင်းသည် browser တွင် run လုပ်ခြင်းထက် ပိုမိုမြန်ဆန်တတ်သည်။
> Inspector အကြောင်းပိုမိုဖတ်ရှုရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ကြည့်ပါ။

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းဘာသာစကားဖြင့် ရေးသားထားသော စာရွက်စာတမ်းကို အာဏာတရားရှိသော ရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားယူမှားမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။