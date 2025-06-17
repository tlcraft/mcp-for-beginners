<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-06-17T16:44:38+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို chạyခြင်း

သင့်အား `uv` ကို 설치ရန် အကြံပြုထားပေမယ့် မလိုအပ်ပါ၊ [အညွှန်းများ](https://docs.astral.sh/uv/#highlights) ကို ကြည့်ပါ။

## -0- Virtual environment တစ်ခု ဖန်တီးခြင်း

```bash
python -m venv venv
```

## -1- Virtual environment ကို အက်တီဗိတ်လုပ်ခြင်း

```bash
venv\Scrips\activate
```

## -2- လိုအပ်သော dependencies များ 설치ခြင်း

```bash
pip install "mcp[cli]"
```

## -3- နမူနာကို chạyခြင်း

```bash
mcp run server.py
```

## -4- နမူနာကို စမ်းသပ်ခြင်း

Server တစ်ခုကို တစ်ခုသော terminal မှာ chạyနေစဉ်၊ အခြား terminal တစ်ခု ဖွင့်ပြီး အောက်ပါ command ကို chạyပါ။

```bash
mcp dev server.py
```

ဒါက နမူနာကို စမ်းသပ်ရန် အမြင် Interface ပါဝင်တဲ့ web server ကို စတင်ပေးပါလိမ့်မယ်။

Server ချိတ်ဆက်ပြီးနောက် -

- tools များ စာရင်းပြုလုပ်ပြီး `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` ကို wrapper အဖြစ် chạyကြည့်ပါ။

အောက်ပါ command ကို chạyခြင်းဖြင့် CLI mode မှာ တိုက်ရိုက် စတင်နိုင်ပါသည်။

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

ဒါက server မှာ ရနိုင်တဲ့ tools များအားလုံးကို စာရင်းပြပါလိမ့်မယ်။ အောက်ပါ output ကို မြင်ရပါလိမ့်မယ်။

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

Tool တစ်ခုကို ခေါ်ရန် -

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

အောက်ပါ output ကို မြင်ရပါလိမ့်မယ်။

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
> ဘရောက်ဇာထက် CLI mode မှာ ispector ကို chạyတာ ပိုမိုလျင်မြန်တတ်ပါတယ်။
> inspector အကြောင်း ပိုမိုလေ့လာရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ဖတ်ပါ။

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားဆောင်ရွက်သော်လည်း အလိုအလျောက်ဘာသာပြန်ခြင်းသည် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံပါသည်။ မူရင်းစာတမ်းကို မိခင်ဘာသာဖြင့်သာ အတည်ပြုရမည့် အရင်းအမြစ်အဖြစ် သတ်မှတ်ရန် လိုအပ်ပါသည်။ အရေးကြီးသောအချက်အလက်များအတွက် အတတ်ပညာရှိ လူသားဘာသာပြန်ကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားမလည်မှုများ သို့မဟုတ် မှားယွင်းသောအဓိပ္ပာယ်ဖွင့်ဆိုမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မရှိပါ။