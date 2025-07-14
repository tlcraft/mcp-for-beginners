<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-13T20:03:27+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "my"
}
-->
အခုတော့ SSE အကြောင်းနည်းနည်းသိသွားပြီဆိုတော့ SSE server တစ်ခုကို တည်ဆောက်ကြရအောင်။

## လေ့ကျင့်ခန်း - SSE Server တည်ဆောက်ခြင်း

Server ကို တည်ဆောက်ဖို့အတွက် အောက်ပါအချက်နှစ်ချက်ကို သတိထားရမယ်။

- Connection နဲ့ messages အတွက် endpoint တွေကို ဖော်ပြဖို့ web server ကို အသုံးပြုရမယ်။
- stdio ကို အသုံးပြုခဲ့သလို tools, resources နဲ့ prompts တွေနဲ့ server ကို တည်ဆောက်ရမယ်။

### -1- Server instance တစ်ခု ဖန်တီးခြင်း

Server ကို ဖန်တီးဖို့ stdio နဲ့ အသုံးပြုခဲ့တဲ့ types တွေကို အသုံးပြုမယ်။ သို့သော် transport အတွက် SSE ကို ရွေးချယ်ရမယ်။

အခုတော့ လိုအပ်တဲ့ routes တွေကို ထည့်ကြရအောင်။

### -2- Routes တွေ ထည့်ခြင်း

Connection နဲ့ incoming messages ကို ကိုင်တွယ်ပေးမယ့် routes တွေကို ထည့်လိုက်ကြရအောင်။

အခုတော့ server ရဲ့ စွမ်းဆောင်ရည်တွေကို ထည့်ကြရအောင်။

### -3- Server စွမ်းဆောင်ရည်များ ထည့်ခြင်း

SSE အတွက် လိုအပ်တဲ့ အချက်တွေကို သတ်မှတ်ပြီးသွားပြီဆိုတော့ tools, prompts နဲ့ resources စတဲ့ server စွမ်းဆောင်ရည်တွေကို ထည့်လိုက်ကြရအောင်။

သင့်ရဲ့ အပြည့်အစုံ code က အောက်ပါအတိုင်း ဖြစ်သင့်ပါတယ်။

အရမ်းကောင်းပြီ၊ SSE ကို အသုံးပြုတဲ့ server တစ်ခု ရှိသွားပြီ၊ အခုတော့ စမ်းသပ်ကြည့်ရအောင်။

## လေ့ကျင့်ခန်း - Inspector နဲ့ SSE Server ကို Debug လုပ်ခြင်း

Inspector ကတော့ ကျွန်တော်တို့ အရင်က [Creating your first server](/03-GettingStarted/01-first-server/README.md) သင်ခန်းစာမှာ တွေ့ခဲ့တဲ့ အရမ်းကောင်းတဲ့ tool တစ်ခုပါ။ ဒီမှာလည်း Inspector ကို အသုံးပြုနိုင်မလား စမ်းကြည့်ကြရအောင်။

### -1- Inspector ကို run လုပ်ခြင်း

Inspector ကို run လုပ်ဖို့အတွက် အရင်ဆုံး SSE server တစ်ခု run လိုက်ရမယ်၊ အဲ့ဒါကို အခုလုပ်ကြရအောင်။

1. Server ကို run လုပ်ပါ။

1. Inspector ကို run လုပ်ပါ။

    > ![NOTE]
    > Server run လုပ်ထားတဲ့ terminal window ကနေ မတူတဲ့ terminal window တစ်ခုမှာ run လုပ်ပါ။ နောက်ထပ် သတိပြုရမှာက အောက်ပါ command ကို သင့် server ရဲ့ URL နဲ့ ကိုက်ညီအောင် ပြင်ဆင်ဖို့ လိုပါတယ်။

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Inspector ကို run လုပ်တာက runtime အားလုံးမှာ တူညီပါတယ်။ Server ကို စတင် run လုပ်ဖို့ path နဲ့ command ပေးတာမဟုတ်ပဲ server ရဲ့ URL နဲ့ `/sse` route ကို ပေးတာကို သတိထားပါ။

### -2- Tool ကို စမ်းသပ်ကြည့်ခြင်း

Droplist မှာ SSE ကို ရွေးပြီး သင့် server ရဲ့ URL ကို ဖြည့်ပါ၊ ဥပမာ http:localhost:4321/sse။ "Connect" ခလုတ်ကို နှိပ်ပါ။ ယခင်ကဲ့သို့ tools များကို စာရင်းပြပြီး tool တစ်ခုကို ရွေးပြီး input value များထည့်ပါ။ အောက်ပါအတိုင်း ရလဒ်ကို တွေ့ရပါမယ်။

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.my.png)

အရမ်းကောင်းပြီ၊ Inspector နဲ့ အလုပ်လုပ်နိုင်ပြီ၊ အခုတော့ Visual Studio Code နဲ့ ဘယ်လို အလုပ်လုပ်ရမလဲ ကြည့်ကြရအောင်။

## အလုပ်အပ်

Server ကို ပိုမိုစွမ်းဆောင်ရည်များဖြင့် တည်ဆောက်ကြည့်ပါ။ ဥပမာ API ကို ခေါ်တဲ့ tool တစ်ခု ထည့်ချင်ရင် [ဒီစာမျက်နှာ](https://api.chucknorris.io/) ကို ကြည့်ပါ။ Server ကို ဘယ်လို ဖန်တီးချင်သလဲ သင်ပဲဆုံးဖြတ်ပါ။ ပျော်ရွှင်ပါစေ :)

## ဖြေရှင်းချက်

[ဖြေရှင်းချက်](./solution/README.md) ဒီမှာ အလုပ်လုပ်တဲ့ code နဲ့ဖြေရှင်းချက်တစ်ခု ရှိပါတယ်။

## အဓိက သင်ခန်းစာများ

ဒီအခန်းကနေ သင်ယူရမယ့် အဓိကအချက်တွေကတော့ -

- SSE က stdio နောက်တစ်ခုအဖြစ် ထောက်ခံတဲ့ transport ဖြစ်တယ်။
- SSE ကို ထောက်ခံဖို့အတွက် incoming connections နဲ့ messages ကို web framework နဲ့ စီမံရမယ်။
- Inspector နဲ့ Visual Studio Code နှစ်ခုလုံးကို SSE server ကို အသုံးပြုဖို့ အသုံးပြုနိုင်တယ်၊ stdio servers လိုပဲ။ stdio နဲ့ SSE ကြားက ကွာခြားချက်က SSE အတွက် server ကို သီးခြားစတင် run လိုက်ပြီး inspector tool ကို run လိုက်ရတယ်။ Inspector tool မှာ URL ကို သတ်မှတ်ပေးရတယ်ဆိုတာပါ။

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## ထပ်ဆောင်း အရင်းအမြစ်များ

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## နောက်တစ်ဆင့်

- နောက်တစ်ဆင့်: [HTTP Streaming with MCP (Streamable HTTP)](../06-http-streaming/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ပညာရှင်များ၏ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မခံပါ။