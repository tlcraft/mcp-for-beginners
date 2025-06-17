<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-06-17T16:45:06+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို ပြေးရန်

`uv` ကို 설치 လုပ်ရန် အကြံပြုထားပေမယ့် မဖြစ်မနေ လိုအပ်တာ မဟုတ်ပါ၊ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကို ကြည့်ပါ။

## -1- အခြေခံလိုအပ်ချက်များ ထည့်သွင်းခြင်း

```bash
npm install
```

## -3- နမူနာကို ပြေးခြင်း

```bash
npm run build
```

## -4- နမူနာကို စမ်းသပ်ခြင်း

တစ်ဖက် terminal မှာ server ကို ပြေးနေစဉ်၊ နောက်ထပ် terminal တစ်ခု ဖွင့်ပြီး အောက်ပါ command ကို ပြေးပါ။

```bash
npm run inspector
```

ဒါက သင့်အား နမူနာကို စမ်းသပ်နိုင်ဖို့ ရုပ်သိမ်းနဲ့ web server တစ်ခု စတင်ပေးပါလိမ့်မယ်။

server ချိတ်ဆက်ပြီးနောက်:

- tools တွေ စာရင်းပြပြီး `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` ကို run ပြုလုပ်ကြည့်ပါ။ ဒါဟာ wrapper တစ်ခုဖြစ်ပါတယ်။

CLI mode မှာ တိုက်ရိုက် စတင်ရန် အောက်ပါ command ကို ပြေးပါ။

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

ဒါက server ထဲမှာ ရနိုင်တဲ့ tools အားလုံးကို စာရင်းပြပါလိမ့်မယ်။ အောက်ပါ output ကို တွေ့ရပါမယ်။

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

tool တစ်ခုကို ခေါ်ရန် type ပြုလုပ်ပါ။

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

အောက်ပါ output ကို တွေ့ရပါမယ်။

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
> ispector ကို browser ထက် CLI mode မှာ run ဖို့ ပိုမြန်တယ်။
> inspector အကြောင်း ပိုမိုသိရှိရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ဖတ်ပါ။

**အဆိုပြုချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် သတ်မှတ်ရန် လိုအပ်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ပညာရှင်များ၏ အတည်ပြု ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်နိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မရှိပါ။