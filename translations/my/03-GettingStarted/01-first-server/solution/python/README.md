<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d0f0d7012325b286e4a717791b23ae7e",
  "translation_date": "2025-07-13T18:02:37+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို chạy လုပ်ခြင်း

`uv` ကို 설치 လုပ်ဖို့ အကြံပြုထားပေမယ့် မလိုအပ်ပါ၊ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကို ကြည့်ပါ။

## -0- virtual environment တစ်ခု ဖန်တီးခြင်း

```bash
python -m venv venv
```

## -1- virtual environment ကို ဖွင့်ခြင်း

```bash
venv\Scrips\activate
```

## -2- လိုအပ်သော dependencies များ 설치 လုပ်ခြင်း

```bash
pip install "mcp[cli]"
```

## -3- နမူနာကို chạy လုပ်ခြင်း

```bash
mcp run server.py
```

## -4- နမူနာကို စမ်းသပ်ခြင်း

server ကို terminal တစ်ခုမှာ chạy လုပ်နေစဉ်၊ terminal တစ်ခုကို ထပ်ဖွင့်ပြီး အောက်ပါ command ကို chạy ပါ။

```bash
mcp dev server.py
```

ဒါက နမူနာကို စမ်းသပ်နိုင်ဖို့ visual interface ပါတဲ့ web server တစ်ခုကို စတင်ပေးပါလိမ့်မယ်။

server နဲ့ ချိတ်ဆက်ပြီးနောက် -

- tools များကို စာရင်းပြပြီး `add` ကို args 2 နဲ့ 4 ဖြင့် chạy ကြည့်ပါ၊ ရလဒ်မှာ 6 ကို မြင်ရပါမယ်။

- resources နဲ့ resource template ကို သွားပြီး get_greeting ကို ခေါ်ပါ၊ နာမည်တစ်ခု ရိုက်ထည့်လိုက်ရင် သင့်ရဲ့ နာမည်နဲ့ အကြိုဆိုစာကို မြင်ရပါလိမ့်မယ်။

### CLI mode မှာ စမ်းသပ်ခြင်း

သင် chạy လုပ်ထားတဲ့ inspector က Node.js app တစ်ခုဖြစ်ပြီး `mcp dev` က အဲဒီ app ကို wrapper လုပ်ထားတာပါ။

အောက်ပါ command ကို chạy လုပ်ခြင်းဖြင့် CLI mode မှာ တိုက်ရိုက် စတင်နိုင်ပါတယ်။

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

ဒါက server မှာ ရနိုင်တဲ့ tools အားလုံးကို စာရင်းပြပါလိမ့်မယ်။ အောက်ပါ output ကို မြင်ရပါမယ်။

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

tool တစ်ခုကို ခေါ်ရန် -

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
> inspector ကို browser မှာ chạy လုပ်တာထက် CLI mode မှာ chạy လုပ်တာ ပိုမြန်တတ်ပါတယ်။
> inspector အကြောင်း ပိုမိုသိရှိရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ဖတ်ပါ။

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။