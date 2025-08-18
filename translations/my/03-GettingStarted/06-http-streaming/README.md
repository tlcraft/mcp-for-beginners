<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5f1383103523fa822e1fec7ef81904d5",
  "translation_date": "2025-08-18T23:34:55+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/README.md",
  "language_code": "my"
}
-->
# HTTPS Streaming with Model Context Protocol (MCP)

ဤအခန်းတွင် Model Context Protocol (MCP) ကို အသုံးပြု၍ HTTPS ဖြင့် လုံခြုံ၊ အကျယ်အဝန်းရှိပြီး အချိန်နှင့်တပြေးညီ စီးဆင်းမှုကို အကောင်အထည်ဖော်ရန် လမ်းညွှန်ချက်များကို ဖော်ပြထားသည်။ စီးဆင်းမှု၏ အဓိကရည်ရွယ်ချက်၊ ရရှိနိုင်သော သယ်ဆောင်မှု механизмများ၊ MCP တွင် streamable HTTP ကို အကောင်အထည်ဖော်နည်း၊ လုံခြုံရေးအကောင်းဆုံးအလေ့အကျင့်များ၊ SSE မှ ပြောင်းရွှေ့ခြင်းနှင့် MCP စီးဆင်းမှု application များကို တည်ဆောက်ရန် လက်တွေ့လမ်းညွှန်ချက်များကို ဖော်ပြထားသည်။

## MCP တွင် သယ်ဆောင်မှု механизмများနှင့် စီးဆင်းမှု

ဤအပိုင်းတွင် MCP တွင် ရရှိနိုင်သော သယ်ဆောင်မှု механизм များနှင့် client နှင့် server အကြား အချိန်နှင့်တပြေးညီ ဆက်သွယ်မှုကို အကောင်အထည်ဖော်ရန်၌ ၎င်းတို့၏ အခန်းကဏ္ဍကို လေ့လာမည်။

### သယ်ဆောင်မှု механизм ဆိုတာဘာလဲ?

သယ်ဆောင်မှု механизм သည် client နှင့် server အကြား ဒေတာကို ဘယ်လို လွှဲပြောင်းပေးပို့မည်ကို သတ်မှတ်သည်။ MCP သည် အခြေအနေများနှင့် လိုအပ်ချက်များကို ဖြည့်ဆည်းရန် သက်ဆိုင်သော သယ်ဆောင်မှုအမျိုးအစားများကို ပံ့ပိုးပေးသည်။

- **stdio**: သာမန် input/output, ဒေသတွင်းနှင့် CLI-based tools များအတွက် သင့်လျော်သည်။ ရိုးရှင်းသော်လည်း web သို့မဟုတ် cloud အတွက် မသင့်လျော်ပါ။
- **SSE (Server-Sent Events)**: HTTP ဖြင့် server များက client များကို အချိန်နှင့်တပြေးညီ update များ push လုပ်ပေးနိုင်သည်။ web UI များအတွက် သင့်လျော်သော်လည်း အကျယ်အဝန်းနှင့် လွယ်ကူမှုမှာ ကန့်သတ်ထားသည်။
- **Streamable HTTP**: ခေတ်မီ HTTP-based streaming transport, notification များနှင့် ပိုမိုကောင်းမွန်သော scalability ကို ပံ့ပိုးပေးသည်။ အများဆုံး production နှင့် cloud အခြေအနေများအတွက် အကြံပြုသည်။

### နှိုင်းယှဉ်ဇယား

အောက်ပါ နှိုင်းယှဉ်ဇယားကို ကြည့်ပြီး သယ်ဆောင်မှု механизм များ၏ ကွာခြားချက်များကို နားလည်ပါ။

| Transport         | အချိန်နှင့်တပြေးညီ Update | Streaming | Scalability | အသုံးပြုမှုအခြေအနေ         |
|-------------------|--------------------------|-----------|-------------|-----------------------------|
| stdio             | မရှိပါ                   | မရှိပါ    | အနည်းငယ်   | ဒေသတွင်း CLI tools         |
| SSE               | ရှိသည်                   | ရှိသည်    | အလယ်အလတ်   | Web, အချိန်နှင့်တပြေးညီ update |
| Streamable HTTP   | ရှိသည်                   | ရှိသည်    | အမြင့်      | Cloud, multi-client         |

> **Tip:** သင့်လျော်သော transport ကို ရွေးချယ်ခြင်းသည် performance, scalability, နှင့် user experience ကို သက်ရောက်စေသည်။ **Streamable HTTP** သည် ခေတ်မီ၊ scalable, နှင့် cloud-ready application များအတွက် အကြံပြုသည်။

### MCP တွင် စီးဆင်းမှု၏ အကြောင်းအရာနှင့် ရည်ရွယ်ချက်

စီးဆင်းမှု၏ အခြေခံအကြောင်းအရာများနှင့် ရည်ရွယ်ချက်များကို နားလည်ခြင်းသည် အချိန်နှင့်တပြေးညီ ဆက်သွယ်မှုစနစ်များကို အကျိုးရှိစွာ အကောင်အထည်ဖော်ရန် အရေးကြီးသည်။

**Streaming** သည် network programming တွင် response အားလုံးကို ပြင်ဆင်ပြီးမှ မစောင့်ဘဲ ဒေတာကို အပိုင်းပိုင်းသို့မဟုတ် အဖြစ်အပျက်များအနေနှင့် ပေးပို့ရန် ခွင့်ပြုသည့် နည်းလမ်းတစ်ခုဖြစ်သည်။ ၎င်းသည် အထူးသဖြင့် အောက်ပါအခြေအနေများတွင် အသုံးဝင်သည်-

- ဖိုင်များ သို့မဟုတ် ဒေတာအစုအဝေးများ
- အချိန်နှင့်တပြေးညီ update များ (ဥပမာ chat, progress bar များ)
- ရှည်လျားသော computation များတွင် user ကို အခြေအနေကို အချိန်နှင့်တပြေးညီ သိရှိစေလိုသောအခါ

### MCP တွင် Notification များနှင့် စီးဆင်းမှု

MCP တွင် streaming သည် response ကို အပိုင်းပိုင်းပေးပို့ခြင်းအကြောင်းမဟုတ်ပါ။ ဒါပေမယ့် tool တစ်ခုသည် request ကို process လုပ်နေစဉ် client ကို **notification** များပေးပို့ခြင်းအကြောင်းဖြစ်သည်။ Notification များသည် progress update, log များ သို့မဟုတ် အခြားအဖြစ်အပျက်များကို ပါဝင်နိုင်သည်။

### Notification ဆိုတာဘာလဲ?

Notification သည် MCP context တွင် server မှ client သို့ progress, status, သို့မဟုတ် အခြားအဖြစ်အပျက်များကို အကြောင်းကြားရန် ပေးပို့သော message တစ်ခုဖြစ်သည်။ Notification များသည် transparency နှင့် user experience ကို တိုးတက်စေသည်။

### Notification များကို MCP တွင် အကောင်အထည်ဖော်ခြင်း

Notification များကို MCP တွင် အကောင်အထည်ဖော်ရန် server နှင့် client နှစ်ဖက်စလုံးကို real-time update များကို handle လုပ်နိုင်အောင် စီစဉ်ရမည်။ ၎င်းသည် ရှည်လျားသော operation များအတွင်း user များကို ချက်ချင်း feedback ပေးနိုင်စေသည်။

#### Server-Side: Notification ပေးပို့ခြင်း

Server-Side တွင် MCP သည် request များကို process လုပ်နေစဉ် client သို့ notification များပေးပို့နိုင်သော tool များကို သတ်မှတ်သည်။

#### Client-Side: Notification လက်ခံခြင်း

Client-Side တွင် notification များကို လက်ခံပြီး ပြသနိုင်သော message handler ကို implement လုပ်ရမည်။

### Progress Notification များနှင့် အရေးပါမှု

Progress Notification များသည် user များကို operation များ၏ အခြေအနေကို အချိန်နှင့်တပြေးညီ update ပေးခြင်းဖြင့် transparency နှင့် user experience ကို တိုးတက်စေသည်။

### MCP တွင် လုံခြုံရေးအရေးပါမှု

MCP server များကို HTTP-based transport များဖြင့် expose လုပ်သောအခါ လုံခြုံရေးသည် အရေးကြီးသောအချက်ဖြစ်ပြီး attack vector များနှင့် ကာကွယ်မှု mechanism များကို ဂရုစိုက်ရန် လိုအပ်သည်။

### SSE မှ Streamable HTTP သို့ ပြောင်းရွှေ့ခြင်း

Server-Sent Events (SSE) ကို အသုံးပြုနေသော application များအတွက် Streamable HTTP သို့ ပြောင်းရွှေ့ခြင်းသည် MCP implementation များအတွက် ပိုမိုကောင်းမွန်သော အစွမ်းထက်မှုများနှင့် ရေရှည်တည်တံ့မှုကို ပေးစွမ်းသည်။
SSE မှ Streamable HTTP သို့ အဆင့်မြှင့်တင်ရန် အရေးကြီးသောအကြောင်းအရင်းနှစ်ခုရှိသည်။

- Streamable HTTP သည် SSE ထက် ပိုမိုကောင်းမွန်သော scalability၊ compatibility နှင့် notification ပံ့ပိုးမှုများကို ပေးစွမ်းနိုင်သည်။
- ဒါဟာ MCP အသစ်များအတွက် အကြံပြုထားသော transport ဖြစ်သည်။

### အဆင့်မြှင့်တင်ခြင်းအဆင့်များ

MCP application များတွင် SSE မှ Streamable HTTP သို့ အဆင့်မြှင့်တင်ရန် အောက်ပါအဆင့်များကို လိုက်နာပါ။

- **Server code ကို update လုပ်ပါ** `mcp.run()` တွင် `transport="streamable-http"` ကို အသုံးပြုပါ။
- **Client code ကို update လုပ်ပါ** SSE client အစား `streamablehttp_client` ကို အသုံးပြုပါ။
- **Message handler တစ်ခုကို client တွင် implement လုပ်ပါ** notifications များကို process လုပ်ရန်။
- **Existing tools နှင့် workflows များနှင့် compatibility ရှိမရှိ စမ်းသပ်ပါ**။

### Compatibility ကို ထိန်းသိမ်းခြင်း

Migration လုပ်နေစဉ် SSE clients များနှင့် compatibility ကို ထိန်းသိမ်းရန် အကြံပြုထားသည်။ အောက်ပါနည်းလမ်းများကို အသုံးပြုနိုင်သည်။

- SSE နှင့် Streamable HTTP နှစ်ခုလုံးကို support လုပ်နိုင်ရန် transport များကို အခြား endpoint များတွင် run လုပ်ပါ။
- Gradually clients များကို transport အသစ်သို့ ပြောင်းပါ။

### စိန်ခေါ်မှုများ

Migration လုပ်နေစဉ် အောက်ပါ စိန်ခေါ်မှုများကို ဖြေရှင်းရန် သေချာပါ။

- Clients များအားလုံးကို update လုပ်ရန်
- Notification delivery တွင် ကွာခြားမှုများကို ကိုင်တွယ်ရန်

## လုံခြုံရေးအရေးယူမှုများ

MCP server များကို HTTP-based transports (Streamable HTTP) ဖြင့် implement လုပ်သောအခါ လုံခြုံရေးသည် အဓိကအရေးပါသည်။

HTTP-based transports ဖြင့် MCP servers များကို implement လုပ်သောအခါ attack vectors များနှင့် ကာကွယ်မှု mechanisms များကို ဂရုစိုက်ရန် လိုအပ်သည်။

### အကျဉ်းချုပ်

MCP servers များကို HTTP ဖြင့် expose လုပ်သောအခါ လုံခြုံရေးသည် အရေးကြီးသည်။ Streamable HTTP သည် attack surfaces အသစ်များကို ဖန်တီးပြီး သေချာသော configuration လိုအပ်သည်။

အရေးကြီးသော လုံခြုံရေးအချက်များမှာ -

- **Origin Header Validation**: DNS rebinding attacks မဖြစ်စေရန် `Origin` header ကို အမြဲ validate လုပ်ပါ။
- **Localhost Binding**: Local development အတွက် servers များကို `localhost` တွင် bind လုပ်ပါ။
- **Authentication**: Production deployments အတွက် authentication (API keys, OAuth စသည်) ကို implement လုပ်ပါ။
- **CORS**: Cross-Origin Resource Sharing (CORS) policies များကို configure လုပ်ပြီး access ကို ကန့်သတ်ပါ။
- **HTTPS**: Production တွင် HTTPS ကို အသုံးပြုပြီး traffic ကို encrypt လုပ်ပါ။

### အကောင်းဆုံးအလေ့အကျင့်များ

MCP streaming server တွင် လုံခြုံရေးကို implement လုပ်သောအခါ အောက်ပါအလေ့အကျင့်များကို လိုက်နာပါ။

- Validation မရှိဘဲ incoming requests များကို မယုံပါနှင့်။
- Access နှင့် error များအားလုံးကို log လုပ်ပြီး monitor လုပ်ပါ။
- Security vulnerabilities များကို patch လုပ်ရန် dependencies များကို regular update လုပ်ပါ။

### စိန်ခေါ်မှုများ

MCP streaming servers တွင် လုံခြုံရေးကို implement လုပ်သောအခါ အောက်ပါ စိန်ခေါ်မှုများကို ရင်ဆိုင်ရမည်ဖြစ်သည်။

- Development အဆင်ပြေမှုနှင့် လုံခြုံရေးကို balance လုပ်ရန်
- Clients များ၏ environment များနှင့် compatibility ရှိစေရန်

### လုပ်ငန်းတာဝန်: သင့်ကိုယ်ပိုင် Streaming MCP App တည်ဆောက်ပါ

**အခြေအနေ:**
MCP server နှင့် client တစ်ခုကို တည်ဆောက်ပါ။ Server သည် items (ဥပမာ - files သို့မဟုတ် documents) များကို process လုပ်ပြီး process လုပ်ပြီးသော item တစ်ခုစီအတွက် notification ပေးပါမည်။ Client သည် notification များကို real-time အတိုင်း ပြသရမည်။

**အဆင့်များ:**

1. Items များကို process လုပ်ပြီး item တစ်ခုစီအတွက် notification ပေးသော server tool တစ်ခုကို implement လုပ်ပါ။
2. Notifications များကို real-time အတိုင်း ပြသရန် message handler ပါသော client တစ်ခုကို implement လုပ်ပါ။
3. Server နှင့် client ကို run လုပ်ပြီး notifications များကို စမ်းသပ်ပါ။

[Solution](./solution/README.md)

## ထပ်မံဖတ်ရှုရန်နှင့် နောက်တစ်ဆင့်

MCP streaming နှင့် ပိုမိုအဆင့်မြင့် applications များတည်ဆောက်ရန် သင်၏အသိပညာကို တိုးချဲ့ရန် အပိုင်းတွင် ထပ်မံဖတ်ရှုရန် resources များနှင့် အကြံပြုထားသော နောက်တစ်ဆင့်များကို ပေးထားသည်။

### ထပ်မံဖတ်ရှုရန်

- [Microsoft: Introduction to HTTP Streaming](https://learn.microsoft.com/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430#streaming)
- [Microsoft: Server-Sent Events (SSE)](https://learn.microsoft.com/azure/application-gateway/for-containers/server-sent-events?tabs=server-sent-events-gateway-api&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Microsoft: CORS in ASP.NET Core](https://learn.microsoft.com/aspnet/core/security/cors?view=aspnetcore-8.0&WT.mc_id=%3Fwt.mc_id%3DMVP_452430)
- [Python requests: Streaming Requests](https://requests.readthedocs.io/en/latest/user/advanced/#streaming-requests)

### နောက်တစ်ဆင့်

- Real-time analytics, chat, သို့မဟုတ် collaborative editing အတွက် streaming ကို အသုံးပြုသော MCP tools များကို တည်ဆောက်ရန် ကြိုးစားပါ။
- Live UI updates အတွက် MCP streaming ကို frontend frameworks (React, Vue စသည်) နှင့် ပေါင်းစပ်ရန် စမ်းသပ်ပါ။
- နောက်တစ်ဆင့်: [Utilising AI Toolkit for VSCode](../07-aitk/README.md)

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ဆိုမှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသောအချက်အလက်များအတွက် ပရော်ဖက်ရှင်နယ် လူသားဘာသာပြန်ကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားမှုများ သို့မဟုတ် အဓိပ္ပါယ်မှားမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။