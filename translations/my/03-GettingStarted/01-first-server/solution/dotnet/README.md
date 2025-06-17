<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-06-17T16:44:52+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို chạy လုပ်ခြင်း

## -1- လိုအပ်သော dependencies များကို 설치 လုပ်ပါ

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- နမူနာကို chạy လုပ်ပါ

```bash
dotnet run
```

## -4- နမူနာကို စမ်းသပ်ပါ

Server ကို တစ်ခုသော terminal မှာ chạy လုပ်ထားစဉ်၊ နောက်တစ်ခုသော terminal ကိုဖွင့်ပြီး အောက်ပါ command ကို chạy လုပ်ပါ။

```bash
npx @modelcontextprotocol/inspector dotnet run
```

ဒါက သင့်အား နမူနာကို စမ်းသပ်နိုင်ရန် visual interface ပါဝင်သော web server တစ်ခုကို စတင်ပေးပါလိမ့်မယ်။

Server နှင့် ချိတ်ဆက်ပြီးနောက် -

- tools များကို စာရင်းပြုလုပ်ပြီး `add` ကို args 2 နဲ့ 4 ဖြင့် chạy လုပ်ပါ၊ ရလဒ်မှာ 6 ကို မြင်ရပါလိမ့်မယ်။
- resources နဲ့ resource template ကို သွားပြီး "greeting" ကို ခေါ်ပါ၊ အမည်တစ်ခုကို ရိုက်ထည့်ပြီး သင်ပေးသောအမည်နှင့် အားပေးသော သတင်းစကားကို မြင်ရပါလိမ့်မယ်။

### CLI မိုဒ်ဖြင့် စမ်းသပ်ခြင်း

အောက်ပါ command ကို chạy လုပ်ခြင်းဖြင့် CLI mode တွင် တိုက်ရိုက် စတင်နိုင်ပါသည်။

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

ဒါက server တွင် ရရှိနိုင်သော tools အားလုံးကို စာရင်းပြုလုပ်ပေးပါလိမ့်မယ်။ အောက်ပါရလဒ်ကို မြင်ရပါလိမ့်မယ်။

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

Tool တစ်ခုကို ခေါ်ရန်:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

အောက်ပါရလဒ်ကို မြင်ရပါလိမ့်မယ်။

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> inspector ကို browser မှာ run လုပ်တာထက် CLI mode မှာ run လုပ်တာ ပိုမြန်တတ်ပါတယ်။
> inspector အကြောင်းကို ပိုမိုသိရှိလိုပါက [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ဖတ်ရှုနိုင်ပါသည်။

**အနှုတ်ချုပ်**  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဆော့ဖ်ဝဲဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ချက်များတွင် အမှားများ သို့မဟုတ် တိကျမှုမရှိမှုများ ဖြစ်ပေါ်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံပါသည်။ မူလစာရွက်စာတမ်းကို မူရင်းဘာသာဖြင့်သာ ယုံကြည်စိတ်ချရသော အချက်အလက်အရင်းအမြစ်အဖြစ် သတ်မှတ်ရမည်ဖြစ်သည်။ အရေးကြီးသောအချက်အလက်များအတွက် လူ့ပညာရှင်များ၏ ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာသော နားလည်မှုမှားခြင်း သို့မဟုတ် မှားယွင်းဖော်ပြမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မခံပါ။