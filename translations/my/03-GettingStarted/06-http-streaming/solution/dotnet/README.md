<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-07-13T21:06:53+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "my"
}
-->
# ဤနမူနာကို chạyခြင်း

## -1- လိုအပ်သော dependencies များကို 설치ပါ

```bash
dotnet restore
```

## -2- နမူနာကို chạyပါ

```bash
dotnet run
```

## -3- နမူနာကို စမ်းသပ်ပါ

အောက်ပါ command ကို chạyမည်မတိုင်မီ terminal အသစ်တစ်ခု ဖွင့်ပါ (server သည် အလုပ်လုပ်နေဆဲဖြစ်ရမည်)။

server တစ်ခု terminal မှာ chạyနေစဉ် terminal တစ်ခုကို ဖွင့်ပြီး အောက်ပါ command ကို chạyပါ။

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

ဤကိစ္စသည် နမူနာကို စမ်းသပ်နိုင်ရန် visual interface ပါသော web server တစ်ခုကို စတင်ပေးပါလိမ့်မည်။

> **Streamable HTTP** ကို transport အမျိုးအစားအဖြစ် ရွေးချယ်ထားပြီး URL သည် `http://localhost:3001/mcp` ဖြစ်ကြောင်း သေချာစေပါ။

server သည် ချိတ်ဆက်ပြီးနောက် -

- tools များကို စာရင်းပြုလုပ်ပြီး `add` ကို args 2 နှင့် 4 ဖြင့် chạyပါ၊ ရလဒ်တွင် 6 ကို မြင်ရမည်။
- resources နှင့် resource template သို့ သွားပြီး "greeting" ကို ခေါ်ပါ၊ အမည်တစ်ခု ရိုက်ထည့်ပြီး သင်ပေးထားသော အမည်ဖြင့် မင်္ဂလာပါ စာကို မြင်ရမည်။

### CLI mode တွင် စမ်းသပ်ခြင်း

အောက်ပါ command ကို chạyခြင်းဖြင့် တိုက်ရိုက် CLI mode တွင် စတင်နိုင်သည်။

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

ဤကိစ္စသည် server တွင် ရနိုင်သည့် tools များအားလုံးကို စာရင်းပြုလုပ်ပေးမည်။ အောက်ပါ output ကို မြင်ရမည်။

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

အောက်ပါ output ကို မြင်ရမည်။

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
> inspector ကို browser ထက် CLI mode တွင် chạyခြင်းသည် ပိုမိုလျင်မြန်သည်။
> inspector အကြောင်း ပိုမိုဖတ်ရှုလိုပါက [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ကြည့်ပါ။

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်သူမှ တာဝန်ယူ၍ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။