<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d26f746e21775c30b4d7ed97962b24df",
  "translation_date": "2025-08-19T18:51:46+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို အလုပ်လုပ်စေခြင်း

`uv` ကို ထည့်သွင်းတပ်ဆင်ရန် အကြံပြုထားပေမယ့် မဖြစ်မနေလိုအပ်တာမဟုတ်ပါဘူး၊ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကို ကြည့်ပါ။

## -0- အခြေခံပတ်ဝန်းကျင်တစ်ခု ဖန်တီးပါ

```bash
python -m venv venv
```

## -1- အခြေခံပတ်ဝန်းကျင်ကို အလုပ်လုပ်စေပါ

```bash
venv\Scripts\activate
```

## -2- လိုအပ်သော အခြေခံပစ္စည်းများကို ထည့်သွင်းပါ

```bash
pip install "mcp[cli]"
```

## -3- နမူနာကို အလုပ်လုပ်စေပါ

```bash
mcp run server.py
```

## -4- နမူနာကို စမ်းသပ်ပါ

Server ကို တစ်ခုသော terminal မှာ အလုပ်လုပ်နေစေပြီး၊ အခြား terminal တစ်ခုဖွင့်ပြီး အောက်ပါ command ကို run လုပ်ပါ:

```bash
mcp dev server.py
```

ဒါက visual interface ပါဝင်တဲ့ web server တစ်ခုကို စတင်စေပါမယ်၊ နမူနာကို စမ်းသပ်နိုင်အောင်။

Server တစ်ခုချိတ်ဆက်ပြီးနောက်:

- tools များကို စမ်းကြည့်ပြီး `add` ကို args 2 နှင့် 4 ဖြင့် run လုပ်ပါ၊ ရလဒ်မှာ 6 ဖြစ်ရမယ်။

- resources နှင့် resource template ကိုသွားပြီး get_greeting ကို ခေါ်ပါ၊ နာမည်တစ်ခုရိုက်ထည့်ပြီး သင့်ရိုက်ထည့်ထားတဲ့ နာမည်နဲ့ greeting တစ်ခုကို မြင်ရပါမယ်။

### CLI mode မှာ စမ်းသပ်ခြင်း

သင့်ရဲ့ inspector က Node.js app တစ်ခုဖြစ်ပြီး `mcp dev` က အဲဒါကို wrapper လုပ်ထားတာပါ။

CLI mode မှာ တိုက်ရိုက်စတင်နိုင်ဖို့ အောက်ပါ command ကို run လုပ်ပါ:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

ဒါက Server မှာ ရနိုင်တဲ့ tools အားလုံးကို ပြပါမယ်။ အောက်ပါ output ကို မြင်ရပါမယ်:

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

Tool တစ်ခုကို ခေါ်ရန်:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

အောက်ပါ output ကို မြင်ရပါမယ်:

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
> CLI mode မှာ inspector ကို run လုပ်တာက browser ထက် အများကြီးမြန်တတ်ပါတယ်။
> Inspector အကြောင်းပိုမိုဖတ်ရှုရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ကြည့်ပါ။

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူရင်းဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။