<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-06-17T16:47:13+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို ပြေးရန်

## -1- လိုအပ်သောပစ္စည်းများ ထည့်သွင်းပါ

```bash
npm install
```

## -3- နမူနာကို ပြေးပါ

```bash
npm run build
```

## -4- နမူနာကို စမ်းသပ်ပါ

တစ်ခုသော terminal မှာ server ပြေးနေစဉ်၊ တခြား terminal တစ်ခုဖွင့်ပြီး အောက်ပါ command ကို အသုံးပြုပါ။

```bash
npm run inspector
```

ဒါက နမူနာကို စမ်းသပ်နိုင်ရန် မျက်နှာပြင်ပါဝင်သော web server ကို စတင်ပေးပါလိမ့်မယ်။

server ချိတ်ဆက်ပြီးနောက်:

- tools များစာရင်းပြပြီး `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build` ကို အလုပ်လုပ်ကြည့်ပါ။

- တခြား terminal တစ်ခုတွင် အောက်ပါ command ကို ပြေးပါ။

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    ဒါက server ထဲမှာ ရရှိနိုင်တဲ့ tools အားလုံးကို ပြပါလိမ့်မယ်။ အောက်ပါအတိုင်း output ကို မြင်ရပါလိမ့်မယ်။

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

- tool အမျိုးအစားတစ်ခုကို အသုံးပြုရန် အောက်ပါ command ကို ရိုက်ထည့်ပါ။

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

အောက်ပါ output ကို မြင်ရပါလိမ့်မယ်။

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
> ispector ကို browser ထက် CLI mode မှာ ပြေးတာ ပိုမြန်တတ်ပါတယ်။
> inspector အကြောင်း ပိုမိုသိရှိရန် [ဒီမှာ](https://github.com/modelcontextprotocol/inspector) ဖတ်ပါ။

**အဆိုပြုချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးပမ်းနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူလစာတမ်းကို မိခင်ဘာသာဖြင့်သာ တရားဝင် အချက်အလက်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ပညာရှင်တစ်ဦး၏ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက် အသုံးပြုမှုမှ ဖြစ်ပေါ်လာနိုင်သည့် နားမလည်မှုများ သို့မဟုတ် မှားယွင်းဖော်ပြမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မခံပါ။