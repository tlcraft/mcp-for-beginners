<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T06:11:40+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို chạyခြင်း

## -1- လိုအပ်သော အစိတ်အပိုင်းများ ထည့်သွင်းပါ

```bash
dotnet restore
```

## -2- နမူနာကို chạyပါ

```bash
dotnet run
```

## -3- နမူနာကို စမ်းသပ်ပါ

အောက်တွင်ပြထားသောအတိုင်း chạy မလုပ်ခင် သီးခြား terminal တစ်ခု ဖွင့်ထားပါ (server သေချာ chạy နေသေးသည်ကို သေချာစေပါ)။

server တစ်ခု terminal မှာ chạy နေစဉ် နောက်ထပ် terminal တစ်ခု ဖွင့်ပြီး အောက်ပါ command ကို chạy ပါ။

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

ဒါက သင့်ကို နမူနာကို စမ်းသပ်နိုင်မယ့် visual interface ပါတဲ့ web server တစ်ခု စတင်ပေးပါလိမ့်မယ်။

> **SSE** ကို transport အမျိုးအစားအဖြစ် ရွေးချယ်ထားပြီး URL က `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add` ဖြစ်ကြောင်း သေချာစေပါ၊ args 2 နဲ့ 4 ထည့်သွင်းထားရင် ရလဒ်မှာ 6 ကို မြင်ရပါလိမ့်မယ်။
- resources နဲ့ resource template ကို သွားပြီး "greeting" ကို ခေါ်ပါ၊ နာမည်တစ်ခု ရိုက်ထည့်ပြီး သင်ရိုက်ထည့်ထားတဲ့ နာမည်နဲ့ အကြိုဆိုစာကို မြင်ရပါလိမ့်မယ်။

### CLI mode မှာ စမ်းသပ်ခြင်း

အောက်ပါ command ကို chạy ချိန်မှာ တိုက်ရိုက် CLI mode မှာ ဖွင့်နိုင်ပါတယ်။

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

ဒါက server မှာ ရနိုင်တဲ့ tools အားလုံးကို ပြပါလိမ့်မယ်။ အောက်ပါ output ကို မြင်ရပါလိမ့်မယ်။

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

tool တစ်ခုကို ခေါ်ရန် အောက်ပါအတိုင်း ရိုက်ထည့်ပါ။

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> ispector ကို browser ထက် CLI mode မှာ chạy တာ ပိုမြန်တယ်။
> inspector အကြောင်း ပိုပြီး ဖတ်ရှုလိုပါက [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ဖတ်ရှုနိုင်ပါတယ်။

**သတိပေးချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှုအတွက် ကြိုးစားနေသော်လည်း အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့် အတည်ပြုရမည့် အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်သူ၏ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှု အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာသော နားမလည်မှုများ သို့မဟုတ် မှားယွင်းဖတ်ရှုမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။