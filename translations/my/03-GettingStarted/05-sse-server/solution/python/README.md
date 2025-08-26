<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "69ba3bd502bd743233137bac5539c08b",
  "translation_date": "2025-08-19T18:54:23+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို အလုပ်လုပ်စေခြင်း

`uv` ကို install လုပ်ရန် အကြံပြုထားပေမယ့် မဖြစ်မနေလိုအပ်တာမဟုတ်ပါဘူး၊ [ညွှန်ကြားချက်များ](https://docs.astral.sh/uv/#highlights) ကိုကြည့်ပါ။

## -0- Virtual Environment တစ်ခု ဖန်တီးပါ

```bash
python -m venv venv
```

## -1- Virtual Environment ကို အလုပ်လုပ်စေပါ

```bash
venv\Scrips\activate
```

## -2- လိုအပ်သော Dependencies များကို Install လုပ်ပါ

```bash
pip install "mcp[cli]"
```

## -3- နမူနာကို အလုပ်လုပ်စေပါ

```bash
uvicorn server:app
```

## -4- နမူနာကို စမ်းသပ်ပါ

Server ကို တစ်ခုသော terminal မှာ အလုပ်လုပ်နေစေပြီး၊ အခြား terminal တစ်ခုဖွင့်ပြီး အောက်ပါ command ကို run လုပ်ပါ:

```bash
mcp dev server.py
```

ဒါက visual interface ပါဝင်တဲ့ web server တစ်ခုကို စတင်ပေးပါမယ်၊ နမူနာကို စမ်းသပ်နိုင်အောင်။

Server တစ်ခုကို ချိတ်ဆက်ပြီးနောက်:

- tools များကို စမ်းသပ်ကြည့်ပြီး `add` ကို args 2 နှင့် 4 ဖြင့် run လုပ်ပါ၊ ရလဒ်မှာ 6 ဖြစ်ရမယ်။
- resources နှင့် resource template ကိုသွားပြီး get_greeting ကိုခေါ်ပါ၊ နာမည်တစ်ခုရိုက်ထည့်ပြီး သင့်ရိုက်ထည့်ထားတဲ့ နာမည်နဲ့ greeting တစ်ခုကို မြင်ရပါမယ်။

### CLI Mode မှာ စမ်းသပ်ခြင်း

သင့်ရဲ့ inspector က အမှန်တကယ် Node.js app တစ်ခုဖြစ်ပြီး `mcp dev` က အဲဒါကို wrapper လုပ်ထားတာပါ။

CLI mode မှာ တိုက်ရိုက်စတင်နိုင်ဖို့ အောက်ပါ command ကို run လုပ်ပါ:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

ဒါက Server မှာ ရနိုင်တဲ့ tools အားလုံးကို ပြသပေးပါမယ်။ အောက်ပါ output ကို မြင်ရပါမယ်:

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
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> CLI mode မှာ inspector ကို run လုပ်တာ Browser မှာ run လုပ်တာထက် အများကြီးမြန်တတ်ပါတယ်။
> Inspector အကြောင်းပိုမိုဖတ်ရှုရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ကြည့်ပါ။

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ဆိုမှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို ကျေးဇူးပြု၍ သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်ပါ။ အရေးကြီးသော အချက်အလက်များအတွက် ပရော်ဖက်ရှင်နယ် လူသားဘာသာပြန်ဝန်ဆောင်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပါယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။