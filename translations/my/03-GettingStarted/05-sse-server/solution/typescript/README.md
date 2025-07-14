<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:22:44+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "my"
}
-->
# ဤနမူနာကို chạyခြင်း

## -1- လိုအပ်သော dependencies များကို 설치ပါ

```bash
npm install
```

## -3- နမူနာကို chạyပါ


```bash
npm run build
```

## -4- နမူနာကို စမ်းသပ်ပါ

တစ်ခုသော terminal မှာ server ကို chạyထားပြီးနောက်၊ အခြား terminal တစ်ခုကို ဖွင့်ပြီး အောက်ပါ command ကို chạyပါ။

```bash
npm run inspector
```

ဤကိစ္စသည် သင့်အား နမူနာကို စမ်းသပ်နိုင်ရန် visual interface ပါရှိသော web server တစ်ခုကို စတင်ပေးပါလိမ့်မည်။

server သည် ချိတ်ဆက်ပြီးနောက် -

- tools များကို စာရင်းပြုလုပ်ပြီး `add` ကို args 2 နှင့် 4 ဖြင့် chạyကြည့်ပါ၊ ရလဒ်တွင် 6 ကို တွေ့ရပါမည်။
- resources နှင့် resource template သို့ သွားပြီး "greeting" ကို ခေါ်ပါ၊ အမည်တစ်ခု ရိုက်ထည့်ပြီး သင်ပေးထားသော အမည်ဖြင့် မင်္ဂလာပါစာကို တွေ့ရပါမည်။

### CLI mode တွင် စမ်းသပ်ခြင်း

သင် chạy လုပ်ထားသော inspector သည် အမှန်တကယ် Node.js app ဖြစ်ပြီး `mcp dev` သည် ၎င်း၏ wrapper တစ်ခုဖြစ်သည်။

- `npm run build` command ဖြင့် server ကို စတင်ပါ။

- အခြား terminal တစ်ခုတွင် အောက်ပါ command ကို chạyပါ။

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    ၎င်းသည် server တွင် ရနိုင်သော tools များအားလုံးကို စာရင်းပြုလုပ်ပေးပါလိမ့်မည်။ အောက်ပါ output ကို တွေ့ရပါမည်။

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

- tool type တစ်ခုကို အောက်ပါ command ဖြင့် ခေါ်ပါ။

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

အောက်ပါ output ကို တွေ့ရပါလိမ့်မည်။

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> inspector ကို browser ထက် CLI mode တွင် chạyခြင်းသည် ပိုမိုလျင်မြန်သည်။
> inspector အကြောင်း ပိုမိုဖတ်ရှုလိုပါက [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ဖတ်ရှုနိုင်ပါသည်။

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။