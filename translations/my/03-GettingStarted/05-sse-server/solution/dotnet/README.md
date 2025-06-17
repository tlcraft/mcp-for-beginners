<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-06-17T16:46:57+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "my"
}
-->
# ဤနမူနာကို chạyခြင်း

## -1- လိုအပ်သော dependencies များကို ထည့်သွင်းပါ

```bash
dotnet run
```

## -2- နမူနာကို chạyပါ

```bash
dotnet run
```

## -3- နမူနာကို စမ်းသပ်ပါ

အောက်ပါအတိုင်း chạy မပြုမီ terminal တစ်ခုကို သီးသန့်ဖွင့်ထားပါ (server သည် အခုမှ စနစ်တကျ chạy နေသေးသည်ကို သေချာစေပါ)။

server တစ်ခုတွင် chạy နေစဉ်၊ terminal တစ်ခုကို ထပ်ဖွင့်ပြီး အောက်ပါ command ကို chạy ပါ-

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

ဤကဲ့သို့လုပ်ခြင်းဖြင့် web server တစ်ခုကို visual interface ဖြင့် စတင်နိုင်ပြီး နမူနာကို စမ်းသပ်နိုင်ပါသည်။

server နှင့် ချိတ်ဆက်ပြီးပါက-

- tools များကို စာရင်းပြုလုပ်၍ `add` ကို args 2 နှင့် 4 ဖြင့် chạy ကြည့်ပါ၊ ရလဒ်တွင် 6 ကိုမြင်ရမည်။
- resources နှင့် resource template ကိုသွားပြီး "greeting" ကိုခေါ်ပြီး အမည်တစ်ခု ရိုက်ထည့်ပါ၊ သင့်ရဲ့အမည်ဖြင့် အကြိုဆိုစာတစ်ခုကို မြင်ရမည်။

### CLI mode တွင် စမ်းသပ်ခြင်း

အောက်ပါ command ကို chạyခြင်းဖြင့် တိုက်ရိုက် CLI mode တွင် စတင်နိုင်သည်-

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

ဤသည် server တွင်ရရှိနိုင်သော tools များအားလုံးကို စာရင်းပြပါလိမ့်မည်။ အောက်ပါ output ကို မြင်ရမည်-

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

tool တစ်ခုကို ခေါ်ရန် type ပါ-

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

အောက်ပါ output ကို မြင်ရမည်-

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
> ispector ကို browser ထက် CLI mode တွင် chạy သည်မှာ ပိုမြန်လေ့ရှိသည်။
> inspector အကြောင်းကို ပိုမိုလေ့လာရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ဖတ်ပါ။

**အဆိုပြုချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးပမ်းနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ဖြစ်ပေါ်နိုင်ပါသည်။ မူရင်းစာတမ်းကို မူရင်းဘာသာဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် သတ်မှတ်ရန် လိုအပ်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ပညာရှင်များ၏ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်သော နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။