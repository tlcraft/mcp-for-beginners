<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T22:35:36+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "my"
}
-->
အခုတော့ SSE အကြောင်းနည်းနည်းသိပြီးသွားပြီဆိုတော့ SSE server ကို ဆောက်ကြမယ်။

## လေ့ကျင့်ခန်း - SSE Server တည်ဆောက်ခြင်း

Server ကို တည်ဆောက်ဖို့အတွက် အောက်ပါအချက် ၂ ချက်ကို မှတ်ထားရမယ်။

- Connection နဲ့ message တွေအတွက် endpoint တွေ ဖော်ပြဖို့ web server ကို အသုံးပြုရမယ်။
- stdio ကို သုံးခဲ့တဲ့အတိုင်း tools, resources နဲ့ prompts တွေနဲ့ server ကို တည်ဆောက်ရမယ်။

### -1- Server instance တစ်ခု ဖန်တီးခြင်း

Server ကို ဖန်တီးဖို့ stdio နဲ့ အသုံးပြုခဲ့တဲ့ type တွေကို သုံးပါမယ်။ သို့သော် transport အတွက် SSE ကို ရွေးချယ်ရပါမယ်။

အောက်ပါအတိုင်း ဆက်လုပ်ကြပါစို့။

### -2- Route များ ထည့်သွင်းခြင်း

Connection နဲ့ incoming message တွေကို ကိုင်တွယ်နိုင်ဖို့ route များ ထည့်သွင်းကြမယ်။

### -3- Server ၏ စွမ်းရည်များ ထည့်သွင်းခြင်း

SSE အတွက် လိုအပ်သော အချက်အလက်များ သတ်မှတ်ပြီးပါက tools, prompts, resources စသည့် server ၏ စွမ်းရည်များကို ထည့်သွင်းပါ။

သင့် code အပြည့်အစုံက အောက်ပါအတိုင်း ဖြစ်သင့်ပါတယ်။

အလွန်ကောင်းပြီ၊ SSE ကို အသုံးပြုထားတဲ့ server ရှိသွားပြီ၊ အခုတော့ စမ်းသပ်ကြည့်ပါမယ်။

## လေ့ကျင့်ခန်း - Inspector နဲ့ SSE Server ကို Debug လုပ်ခြင်း

Inspector ကတော့ ယခင်သင်ခန်းစာ [Creating your first server](/03-GettingStarted/01-first-server/README.md) မှာ တွေ့ဖူးတဲ့ အကောင်းဆုံး tool တစ်ခုပါ။ ဒီမှာပါ Inspector ကို သုံးနိုင်မလား ကြည့်ကြရအောင်။

### -1- Inspector ကို အလုပ်လုပ်စေခြင်း

Inspector ကို အလုပ်လုပ်စေဖို့အတွက် ပထမဦးဆုံး SSE server တစ်ခု အလုပ်လုပ်နေဖို့ လိုပါတယ်။ ဒါကြောင့် အောက်ပါအတိုင်း ဆက်လုပ်ကြရအောင်။

1. Server ကို အလုပ်လုပ်စေပါ။

1. Inspector ကို အလုပ်လုပ်စေပါ။

    > ![NOTE]
    > Server အလုပ်လုပ်နေတဲ့ terminal နဲ့ မတူတဲ့ terminal တစ်ခုမှာ ဒီ command ကို လုပ်ပါ။ နောက်ထပ် သတိပြုရန်ကတော့ server ရှိတဲ့ URL ကို အောက်မှာပြထားတဲ့ command မှာ ကိုက်ညီအောင် ပြင်ဆင်ဖို့ လိုပါမယ်။

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Inspector ကို အလုပ်လုပ်စေတဲ့ နည်းလမ်းဟာ runtime အားလုံးမှာ တူညီပါတယ်။ Server ကို စတင်ဖို့ command တစ်ခုမပေးဘဲ Server ရှိနေတဲ့ URL နဲ့ `/sse` route ကို ပေးတာကို သတိပြုပါ။

### -2- Tool ကို စမ်းသပ်ခြင်း

Droplist မှာ SSE ကို ရွေးပြီး server ရှိနေတဲ့ URL ကို ဖြည့်ပါ၊ ဥပမာ http:localhost:4321/sse လိုဖြစ်နိုင်ပါတယ်။ "Connect" ခလုတ်ကို နှိပ်ပါ။ ယခင်ကဲ့သို့ tools များကို စာရင်းပြပြီး tool တစ်ခုရွေးပြီး input value များထည့်ပါ။ အောက်ပါအတိုင်း ရလဒ်တွေ မြင်ရပါမယ်။

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.my.png)

အလွန်ကောင်းပါတယ်၊ Inspector နဲ့ အလုပ်လုပ်နိုင်ပြီ၊ အခုတော့ Visual Studio Code နဲ့ ဘယ်လို အလုပ်လုပ်မလဲ ကြည့်ကြရအောင်။

## အလုပ်တာဝန်

သင့် server ကို ပိုမိုစွမ်းရည်ရှိအောင် တိုးချဲ့ကြည့်ပါ။ ဥပမာ API တစ်ခုခေါ်တဲ့ tool တစ်ခု ထည့်လိုပါက [ဒီစာမျက်နှာ](https://api.chucknorris.io/) ကို ကြည့်ပါ။ Server ကို ဘယ်လိုဖန်တီးမလဲ ကိုယ်တိုင်ဆုံးဖြတ်ပါ။ ပျော်ရွှင်စွာ လုပ်ပါနော် :)

## ဖြေရှင်းချက်

[ဖြေရှင်းချက်](./solution/README.md) ဒီမှာ အလုပ်လုပ်တဲ့ code နဲ့ဖြေရှင်းချက် တစ်ခုရှိပါတယ်။

## အဓိက သင်ခန်းစာများ

ဒီအခန်းကနေ သင်ယူရမယ့် အချက်အလက်တွေကတော့ -

- SSE က stdio နောက်တစ်ခုသော ပို့ဆောင်မှုနည်းလမ်း ဖြစ်တယ်။
- SSE ကို support ဖို့အတွက် connection နဲ့ message များကို web framework ဖြင့် စီမံရမယ်။
- SSE server ကို stdio server တွေလိုပဲ Inspector နဲ့ Visual Studio Code နဲ့ သုံးနိုင်တယ်။ stdio နဲ့ SSE ကြားမှာ မတူညီတာ တချို့ရှိတယ်။ SSE မှာ server ကို သီးသန့်စတင်ပြီး inspector tool ကို run ဖို့လိုတယ်။ Inspector မှာ URL ကို သတ်မှတ်ဖို့ လိုတယ်။

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## အပိုဆောင်း အရင်းအမြစ်များ

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## နောက်တစ်ဆင့်

- နောက်တစ်ဆင့်: [MCP နဲ့ HTTP Streaming (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**အကြောင်းကြားချက်**  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးပမ်းဆောင်ရွက်ထားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် တောင်းဆိုအပ်ပါသည်။ မူရင်းစာရွက်စာတမ်းကို မူလဘာသာဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော သတင်းအချက်အလက်များအတွက် သက်ဆိုင်ရာ ပရော်ဖက်ရှင်နယ် လူသားဘာသာပြန်သူမှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်နိုင်သည့် မတိကျမှုများ သို့မဟုတ် မှားယွင်းနားလည်မှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မခံပါ။