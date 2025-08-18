<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "69ba3bd502bd743233137bac5539c08b",
  "translation_date": "2025-08-18T23:33:56+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို အလုပ်လုပ်ရန်

`uv` ကိုတပ်ဆင်ရန် အကြံပြုပါတယ်၊ ဒါပေမယ့် မဖြစ်မနေလိုအပ်တာမဟုတ်ပါဘူး၊ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကိုကြည့်ပါ။

## -0- အတုပတ်ဝန်းကျင် တည်ဆောက်ရန်

```bash
python -m venv venv
```

## -1- အတုပတ်ဝန်းကျင်ကို အလုပ်လုပ်အောင်လုပ်ရန်

```bash
venv\Scrips\activate
```

## -2- လိုအပ်သော အချက်အလက်များကို တပ်ဆင်ရန်

```bash
pip install "mcp[cli]"
```

## -3- နမူနာကို အလုပ်လုပ်အောင်လုပ်ရန်

```bash
uvicorn server:app
```

## -4- နမူနာကို စမ်းသပ်ရန်

တစ်ခုသော terminal မှာ server ကို အလုပ်လုပ်နေစဉ်၊ အခြား terminal တစ်ခုဖွင့်ပြီး အောက်ပါ command ကို run လုပ်ပါ:

```bash
mcp dev server.py
```

ဒီနည်းလမ်းနဲ့ visual interface ပါတဲ့ web server တစ်ခုစတင်ပြီး နမူနာကို စမ်းသပ်နိုင်ပါမယ်။

Server တစ်ခုချိတ်ဆက်ပြီးနောက်:

- tools များကို စမ်းသပ်ပြီး `add` ကို run လုပ်ပါ၊ arguments အနေနဲ့ 2 နဲ့ 4 ကိုထည့်ပါ၊ ရလဒ်မှာ 6 ကိုတွေ့ရပါမယ်။
- resources နဲ့ resource template ကိုသွားပြီး `get_greeting` ကိုခေါ်ပါ၊ နာမည်တစ်ခုရိုက်ထည့်ပြီး သင့်ရိုက်ထည့်ထားတဲ့နာမည်နဲ့ greeting တစ်ခုကိုတွေ့ရပါမယ်။

### CLI mode မှာ စမ်းသပ်ခြင်း

သင့်ရဲ့ inspector က အမှန်တကယ် Node.js app တစ်ခုဖြစ်ပြီး `mcp dev` က wrapper တစ်ခုဖြစ်ပါတယ်။

CLI mode မှာ တိုက်ရိုက်စတင်ရန် အောက်ပါ command ကို run လုပ်ပါ:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

ဒီနည်းနဲ့ server မှာ ရရှိနိုင်တဲ့ tools အားလုံးကို စာရင်းပြပါမယ်။ အောက်ပါ output ကိုတွေ့ရပါမယ်:

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

အောက်ပါ output ကိုတွေ့ရပါမယ်:

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
> CLI mode မှာ inspector ကို run လုပ်ရတာ browser ထက် ပိုမြန်တတ်ပါတယ်။
> Inspector အကြောင်းပိုမိုဖတ်ရှုရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ကြည့်ပါ။

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူရင်းဘာသာစကားဖြင့် အာဏာတရ အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူက ဘာသာပြန်မှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားယူမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။