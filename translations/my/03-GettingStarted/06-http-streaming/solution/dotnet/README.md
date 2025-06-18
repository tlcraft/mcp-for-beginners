<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4eb6a48c54555c64b33c763fba3f2842",
  "translation_date": "2025-06-18T06:19:49+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/dotnet/README.md",
  "language_code": "my"
}
-->
# ဤနမူနာကို အလုပ်လုပ်ခြင်း

## -1- လိုအပ်သော အစိတ်အပိုင်းများ ထည့်သွင်းပါ

```bash
dotnet restore
```

## -2- နမူနာကို အလုပ်လုပ်ပါ

```bash
dotnet run
```

## -3- နမူနာကို စမ်းသပ်ပါ

အောက်ပါအတိုင်း လုပ်မယ့်အချိန်မှာ သီးခြား terminal တစ်ခုကို စတင်ဖွင့်ထားပါ (server က အလုပ်လုပ်နေဆဲဖြစ်ရမည်)။

server တစ်ခုက terminal တစ်ခုမှာ အလုပ်လုပ်နေစဉ် တခြား terminal တစ်ခုဖွင့်ပြီး အောက်ပါ command ကို ရိုက်ထည့်ပါ-

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

ဤကိစ္စက web server တစ်ခုကို visual interface နှင့် အတူ စတင်ပေးမည်ဖြစ်ပြီး နမူနာကို စမ်းသပ်နိုင်ပါလိမ့်မည်။

> **Streamable HTTP** ကို transport အမျိုးအစားအဖြစ် ရွေးချယ်ထားခြင်းကို သေချာစေပါ၊ URL သည် `http://localhost:3001/mcp`.

Once the server is connected: 

- try listing tools and run `add` ဖြစ်ပြီး args ၂ နှင့် ၄ ဖြင့် ရလဒ်တွင် ၆ ကို မြင်ရပါမည်။
- resources နှင့် resource template ကို သွားပြီး "greeting" ကိုခေါ်ပါ၊ နာမည်တစ်ခုရိုက်ထည့်ပြီး သင့်ရဲ့နာမည်ပါသော မင်္ဂလာပါစာကို မြင်ရပါလိမ့်မည်။

### CLI မုဒ်တွင် စမ်းသပ်ခြင်း

အောက်ပါ command ကို အသုံးပြု၍ တိုက်ရိုက် CLI မုဒ်ဖြင့် စတင်နိုင်ပါသည်-

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

ဤကိစ္စက server တွင် ရနိုင်သော tools အားလုံးကို စာရင်းပြပါမည်။ အောက်ပါ output ကို မြင်ရပါလိမ့်မည်-

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

tool တစ်ခုကို ခေါ်ရန် ရိုက်ပါ-

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

အောက်ပါ output ကို မြင်ရပါလိမ့်မည်-

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
> CLI မုဒ်တွင် ispector ကို browser ထက် လုပ်ဆောင်ရတာ ပိုမြန်တတ်ပါတယ်။
> inspector အကြောင်း ပိုမိုလေ့လာရန် [ဒီနေရာမှာ](https://github.com/modelcontextprotocol/inspector) ဖတ်ရှုနိုင်ပါသည်။

**တောင်းပန်ချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်စနစ်ဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူလစာတမ်းကို မူရင်းဘာသာဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုရာမှ ဖြစ်ပေါ်နိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့တာဝန်မရှိပါ။