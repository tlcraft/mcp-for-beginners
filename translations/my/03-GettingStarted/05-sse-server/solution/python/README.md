<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-06-17T16:46:43+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "my"
}
-->
# ဤနမူနာကို စမ်းသပ်ခြင်း

`uv` ကို ထည့်သွင်းရန် အကြံပြုထားပေမယ့် မလိုအပ်ပါ၊ အသေးစိတ်အချက်အလက်များကို [အညွှန်း](https://docs.astral.sh/uv/#highlights) တွင် ကြည့်ရှုနိုင်သည်။

## -0- မိမိစက်တွင် virtual environment တစ်ခု ဖန်တီးပါ

```bash
python -m venv venv
```

## -1- virtual environment ကို ဖွင့်ပါ

```bash
venv\Scrips\activate
```

## -2- လိုအပ်သော dependency များကို ထည့်သွင်းပါ

```bash
pip install "mcp[cli]"
```

## -3- နမူနာကို စတင်ပြေးပါ

```bash
mcp run server.py
```

## -4- နမူနာကို စမ်းသပ်ပါ

တစ်ခုသော terminal မှာ server ကို စတင်ထားပြီးနောက်၊ အခြား terminal တစ်ခုကို ဖွင့်ပြီး အောက်ပါ command ကို ပြေးပါ။

```bash
mcp dev server.py
```

ဒါက နမူနာကို စမ်းသပ်နိုင်ဖို့ visual interface ပါတဲ့ web server တစ်ခုကို စတင်ပေးပါလိမ့်မယ်။

server နှင့် ချိတ်ဆက်ပြီးနောက် -

- tools များကို စစ်ဆေးပြီး `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` ကို လုပ်ဆောင်ပါ၊ ၎င်းသည် wrapper တစ်ခုဖြစ်သည်။

အောက်ပါ command ဖြင့် CLI mode မှ တိုက်ရိုက် ဖွင့်လှစ်နိုင်သည်။

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

ဒါက server တွင် ရရှိနိုင်သော tools အားလုံးကို ပြပါလိမ့်မယ်။ အောက်ပါ output ကို မြင်ရပါမယ်။

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

tool တစ်ခုကို ခေါ်ရန် အောက်ပါအတိုင်း ရိုက်ထည့်ပါ။

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

အောက်ပါ output ကို မြင်ရပါမယ်။

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
> inspector ကို browser ထက် CLI mode မှာ ပြေးတာ ပိုမြန်တယ်။
> inspector အကြောင်း ပိုမိုလေ့လာလိုပါက [ဤနေရာ](https://github.com/modelcontextprotocol/inspector) ကို သွားကြည့်ပါ။

**အသိပေးချက်**:  
ဤစာရွက်ကို AI ဘာသာပြန်ဝန်ဆောင်မှုဖြစ်သည့် [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးပမ်းပေမယ့် စက်မှ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန်။ မူရင်းစာရွက်ကို မူရင်းဘာသာဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသောအချက်အလက်များအတွက် ကျွမ်းကျင်သော လူ့ဘာသာပြန် ဝန်ဆောင်မှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်မှုအသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာသော နားလည်မှုမှားယွင်းခြင်းများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။