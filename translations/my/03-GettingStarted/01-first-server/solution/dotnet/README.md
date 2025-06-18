<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T06:11:33+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို လည်ပတ်ခြင်း

## -1- လိုအပ်သော dependencies များကို 설치 လုပ်ပါ

```bash
dotnet restore
```

## -3- နမူနာကို လည်ပတ်ပါ


```bash
dotnet run
```

## -4- နမူနာကို စမ်းသပ်ပါ

တစ်ခုသော terminal မှာ server လည်ပတ်နေစဉ်၊ အခြား terminal တစ်ခုကို ဖွင့်ပြီး အောက်ပါ command ကို run ပါ။

```bash
npx @modelcontextprotocol/inspector dotnet run
```

ဒါက သင့်ကို နမူနာကို စမ်းသပ်နိုင်မယ့် visual interface ပါရှိတဲ့ web server တစ်ခုကို စတင်ပေးပါလိမ့်မယ်။

server ဆက်သွယ်ပြီးနောက်:

- tools များကို စစ်ဆေးပြီး `add` ကို args 2 နဲ့ 4 ဖြင့် run ကြည့်ပါ၊ ရလဒ်မှာ 6 ကို မြင်ရပါမယ်။
- resources နဲ့ resource template ကို သွားပြီး "greeting" ကို ခေါ်ပါ၊ နာမည်တစ်ခု ရိုက်ထည့်ပါ၊ သင်ထည့်ထားတဲ့ နာမည်နဲ့ အလေးထားသော မှတ်တမ်းတစ်ခုကို မြင်ရပါလိမ့်မယ်။

### CLI mode မှာ စမ်းသပ်ခြင်း

အောက်ပါ command ကို run လုပ်ခြင်းဖြင့် တိုက်ရိုက် CLI mode မှာ စတင်နိုင်ပါတယ်။

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

ဒါက server ထဲရှိ tools အားလုံးကို စာရင်းပြပါလိမ့်မယ်။ အောက်ပါ output ကို မြင်ရပါမယ်။

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

tool တစ်ခုကို ခေါ်ရန် အောက်ပါအတိုင်း ရိုက်ထည့်ပါ။

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

အောက်ပါ output ကို မြင်ရပါမယ်။

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
> CLI mode မှာ ispector ကို run တဲ့အခါ browser ထက် ပိုမိုလျင်မြန်တတ်ပါတယ်။
> inspector အကြောင်းကို [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ပိုမိုဖတ်ရှုနိုင်ပါတယ်။

**ပယ်ချခြင်း**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ဖြစ်ပေါ်နိုင်ကြောင်း သတိပြုပါရန် လိုအပ်ပါသည်။ မူရင်းစာတမ်းကို မိခင်ဘာသာဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော သတင်းအချက်အလက်များအတွက် မဟာဗျူဟာအဖြစ် လူ့ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်နိုင်သည့် နားမလည်မှုများ သို့မဟုတ် မှားယွင်းသဘောထားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မခံပါ။