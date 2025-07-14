<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:07:54+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို chạy လုပ်ခြင်း

`uv` ကို 설치 လုပ်ဖို့ အကြံပြုထားပေမယ့် မလိုအပ်ပါ၊ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကို ကြည့်ပါ။

## -1- လိုအပ်သော dependency များ 설치 လုပ်ခြင်း

```bash
npm install
```

## -3- နမူနာကို chạy လုပ်ခြင်း

```bash
npm run build
```

## -4- နမူနာကို စမ်းသပ်ခြင်း

တစ်ခုသော terminal မှာ server ကို chạy လုပ်ထားပြီးနောက်၊ အခြား terminal တစ်ခု ဖွင့်ပြီး အောက်ပါ command ကို chạy ပါ။

```bash
npm run inspector
```

ဒါက web server တစ်ခုကို visual interface နဲ့ စတင်ပေးမှာဖြစ်ပြီး နမူနာကို စမ်းသပ်နိုင်ပါလိမ့်မယ်။

server ချိတ်ဆက်ပြီးနောက် -

- tools များကို စာရင်းပြပြီး `add` ကို args 2 နဲ့ 4 ဖြင့် chạy လုပ်ကြည့်ပါ၊ ရလဒ်မှာ 6 ကို မြင်ရပါမယ်။
- resources နဲ့ resource template ကို သွားပြီး "greeting" ကို ခေါ်ပါ၊ နာမည်တစ်ခု ရိုက်ထည့်ပြီး သင့်ရဲ့ နာမည်နဲ့ အကြိုဆိုစာကို မြင်ရပါလိမ့်မယ်။

### CLI mode မှာ စမ်းသပ်ခြင်း

သင် chạy လုပ်ထားတဲ့ inspector က Node.js app တစ်ခုဖြစ်ပြီး `mcp dev` က အဲဒီ app ကို wrapper လုပ်ထားတာပါ။

အောက်ပါ command ကို chạy လုပ်ခြင်းဖြင့် CLI mode မှာ တိုက်ရိုက် စတင်နိုင်ပါတယ်။

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
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

tool တစ်ခုကို ခေါ်ရန် type လုပ်ပါ -

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> inspector ကို browser မှာ chạy လုပ်တာထက် CLI mode မှာ chạy လုပ်တာ ပိုမြန်တယ်။
> inspector အကြောင်း ပိုမိုသိရှိရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ဖတ်ပါ။

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။