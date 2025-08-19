<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "83efa75a69bc831277263a6f1ae53669",
<<<<<<< HEAD
  "translation_date": "2025-08-18T23:19:19+00:00",
=======
  "translation_date": "2025-08-18T18:40:34+00:00",
>>>>>>> origin/main
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "my"
}
-->
# လက်တွေ့အကောင်အထည်ဖော်ခြင်း

<<<<<<< HEAD
[![MCP အက်ပ်များကို တကယ့်ကိရိယာများနှင့် လုပ်ငန်းစဉ်များဖြင့် တည်ဆောက်၊ စမ်းသပ်၊ နှင့် တင်ပို့ရန် နည်းလမ်းများ](../../../translated_images/05.64bea204e25ca891e3dd8b8f960d2170b9a000d8364305f57db3ec4a2c049a9a.my.png)](https://youtu.be/vCN9-mKBDfQ)

_(ဤသင်ခန်းစာ၏ ဗီဒီယိုကို ကြည့်ရန် အထက်ပါပုံကို နှိပ်ပါ)_

လက်တွေ့အကောင်အထည်ဖော်ခြင်းသည် Model Context Protocol (MCP) ၏ အားသာချက်များကို တကယ့်အသုံးချနိုင်စေသည်။ MCP ၏ သီအိုရီနှင့် ဖွဲ့စည်းပုံကို နားလည်ခြင်းမှာ အရေးကြီးသော်လည်း၊ အဓိကတန်ဖိုးမှာ ဤအယူအဆများကို အသုံးချပြီး တကယ့်ကိစ္စများကို ဖြေရှင်းနိုင်သော ဖြေရှင်းချက်များကို တည်ဆောက်၊ စမ်းသပ်၊ နှင့် တင်ပို့သည့်အခါတွင် ပေါ်ထွက်လာသည်။ ဤအခန်းသည် သီအိုရီနှင့် လက်တွေ့ဖွံ့ဖြိုးမှုအကြား အကွာအဝေးကို ဖြတ်ကျော်ပြီး MCP အခြေခံထားသော အက်ပ်များကို အသက်သွင်းရန် လမ်းညွှန်ပေးသည်။

သင်သည် ဉာဏ်ရည်တု အကူအညီများကို ဖွံ့ဖြိုးခြင်းဖြစ်စေ၊ AI ကို စီးပွားရေးလုပ်ငန်းစဉ်များတွင် ပေါင်းစည်းခြင်းဖြစ်စေ၊ ဒေတာကို စီမံခန့်ခွဲရန် စိတ်ကြိုက်ကိရိယာများကို တည်ဆောက်ခြင်းဖြစ်စေ၊ MCP သည် တင်းကျပ်လွယ်ကူသော အခြေခံအုတ်မြစ်တစ်ခုကို ပံ့ပိုးပေးသည်။ ၎င်း၏ ဘာသာစကားမရွေးသော ဒီဇိုင်းနှင့် လူကြိုက်များသော ပရိုဂရမ်မင်းဘာသာစကားများအတွက် တရားဝင် SDK များကြောင့် အမျိုးမျိုးသော ဖွံ့ဖြိုးသူများအတွက် လွယ်ကူစွာ ရောက်ရှိနိုင်သည်။ ဤ SDK များကို အသုံးပြုခြင်းအားဖြင့် သင်၏ ဖြေရှင်းချက်များကို အမျိုးမျိုးသော ပလက်ဖောင်းများနှင့် ပတ်ဝန်းကျင်များတွင် အမြန်စမ်းသပ်၊ ပြုပြင်၊ နှင့် တိုးချဲ့နိုင်သည်။

အောက်တွင် ဖော်ပြထားသော အပိုင်းများတွင် သင်သည် MCP ကို C#, Java with Spring, TypeScript, JavaScript, နှင့် Python တို့တွင် အကောင်အထည်ဖော်သည့် လက်တွေ့ဥပမာများ၊ နမူနာကုဒ်များ၊ နှင့် တင်ပို့မူများကို တွေ့ရမည်။ သင်သည် MCP ဆာဗာများကို အမှားရှာဖွေခြင်းနှင့် စမ်းသပ်ခြင်း၊ API များကို စီမံခန့်ခွဲခြင်း၊ နှင့် Azure ကို အသုံးပြု၍ ဖြေရှင်းချက်များကို မိုဃ်းတိမ်တွင် တင်ပို့ခြင်းတို့ကိုလည်း သင်ယူရမည်။ ဤလက်တွေ့အရင်းအမြစ်များသည် သင်၏ သင်ယူမှုကို အရှိန်မြှင့်ပေးရန်နှင့် MCP အက်ပ်များကို ယုံကြည်စိတ်ချစွာ တည်ဆောက်နိုင်ရန် အထောက်အကူပြုရန် ရည်ရွယ်ထားသည်။

## အကျဉ်းချုပ်

ဤသင်ခန်းစာသည် MCP ကို အမျိုးမျိုးသော ပရိုဂရမ်မင်းဘာသာစကားများတွင် လက်တွေ့အကောင်အထည်ဖော်ခြင်းအပေါ် အာရုံစိုက်ထားသည်။ C#, Java with Spring, TypeScript, JavaScript, နှင့် Python တို့တွင် MCP SDK များကို အသုံးပြု၍ အက်ပ်များကို တည်ဆောက်ခြင်း၊ MCP ဆာဗာများကို အမှားရှာဖွေခြင်းနှင့် စမ်းသပ်ခြင်း၊ ပြန်လည်အသုံးပြုနိုင်သော အရင်းအမြစ်များ၊ Prompt များ၊ နှင့် ကိရိယာများကို ဖန်တီးခြင်းတို့ကို လေ့လာမည်။
=======
[![How to Build, Test, and Deploy MCP Apps with Real Tools and Workflows](../../../translated_images/05.64bea204e25ca891e3dd8b8f960d2170b9a000d8364305f57db3ec4a2c049a9a.my.png)](https://youtu.be/vCN9-mKBDfQ)

_(ဤသင်ခန်းစာ၏ ဗီဒီယိုကို ကြည့်ရန် အထက်ပါ ပုံကို နှိပ်ပါ)_

လက်တွေ့အကောင်အထည်ဖော်ခြင်းသည် Model Context Protocol (MCP) ၏ အားသာချက်များကို အထင်အမြင်ရစေသော အချိန်ဖြစ်သည်။ MCP ၏ သီအိုရီနှင့် ဖွဲ့စည်းပုံကို နားလည်ခြင်းမှာ အရေးကြီးသော်လည်း၊ အမှန်တကယ်တန်ဖိုးရှိမှုသည် ဤအယူအဆများကို အသုံးချပြီး အမှန်တကယ်သော ပြဿနာများကို ဖြေရှင်းနိုင်သော ဖြေရှင်းချက်များကို တည်ဆောက်ခြင်း၊ စမ်းသပ်ခြင်းနှင့် တင်သွင်းခြင်းမှ ပေါ်ထွက်လာသည်။ ဤအခန်းသည် သဘောတရားဆိုင်ရာ အသိပညာနှင့် လက်တွေ့ ဖွံ့ဖြိုးတိုးတက်မှုအကြား အကူးအပြောင်းကို တည်ဆောက်ပေးပြီး MCP အခြေခံထားသော အက်ပ်များကို အသက်သွင်းရန် လမ်းညွှန်ပေးသည်။

သင်သည် ဉာဏ်ရည်တု အကူအညီများ ဖွံ့ဖြိုးတိုးတက်စေခြင်း၊ AI ကို စီးပွားရေးလုပ်ငန်း လုပ်ငန်းစဉ်များတွင် ပေါင်းစည်းခြင်း၊ သို့မဟုတ် ဒေတာကို အလုပ်လုပ်စေသော စိတ်ကြိုက် ကိရိယာများ တည်ဆောက်ခြင်းတို့ကို လုပ်ဆောင်နေစဉ် MCP သည် တင်းကျပ်မှုမရှိသော အခြေခံအုတ်မြစ်တစ်ခုကို ပံ့ပိုးပေးသည်။ ၎င်း၏ ဘာသာစကားမရွေးသော ဒီဇိုင်းနှင့် လူကြိုက်များသော ပရိုဂရမ်မင်းဘာသာစကားများအတွက် တရားဝင် SDK များကြောင့် အမျိုးမျိုးသော ဖွံ့ဖြိုးသူများအတွက် လွယ်ကူစွာ ရောက်ရှိနိုင်သည်။ ဤ SDK များကို အသုံးပြုခြင်းအားဖြင့် သင်သည် သင်၏ ဖြေရှင်းချက်များကို အမျိုးမျိုးသော ပလက်ဖောင်းများနှင့် ပတ်ဝန်းကျင်များတွင် အမြန်စမ်းသပ်၊ ပြန်လည်ပြင်ဆင်နှင့် တိုးချဲ့နိုင်သည်။

အောက်တွင် ဖော်ပြထားသော အပိုင်းများတွင် သင်သည် MCP ကို C#၊ Java with Spring၊ TypeScript၊ JavaScript နှင့် Python တို့တွင် အကောင်အထည်ဖော်ရန် လက်တွေ့ ဥပမာများ၊ နမူနာကုဒ်များနှင့် တင်သွင်းမှု မဟာဗျူဟာများကို တွေ့ရှိနိုင်ပါမည်။ သင်သည် MCP ဆာဗာများကို အမှားရှာဖွေခြင်းနှင့် စမ်းသပ်ခြင်း၊ API များကို စီမံခန့်ခွဲခြင်းနှင့် Azure ကို အသုံးပြု၍ ဖြေရှင်းချက်များကို ကောင်းစွာ တင်သွင်းခြင်းတို့ကိုလည်း သင်ယူနိုင်ပါမည်။ ဤလက်တွေ့ အရင်းအမြစ်များသည် သင်၏ သင်ယူမှုကို အရှိန်မြှင့်ပေးပြီး MCP အက်ပ်များကို ယုံကြည်စိတ်ချစွာ တည်ဆောက်နိုင်ရန် ကူညီပေးရန် ရည်ရွယ်ထားသည်။

## အကျဉ်းချုပ်

ဤသင်ခန်းစာသည် MCP ကို အမျိုးမျိုးသော ပရိုဂရမ်မင်းဘာသာစကားများတွင် လက်တွေ့အသုံးချခြင်းအပေါ် အာရုံစိုက်ထားသည်။ ကျွန်ုပ်တို့သည် MCP SDK များကို C#၊ Java with Spring၊ TypeScript၊ JavaScript နှင့် Python တို့တွင် အသုံးပြု၍ အက်ပ်များကို တည်ဆောက်ခြင်း၊ MCP ဆာဗာများကို အမှားရှာဖွေခြင်းနှင့် စမ်းသပ်ခြင်း၊ ပြန်လည်အသုံးပြုနိုင်သော အရင်းအမြစ်များ၊ Prompt များနှင့် ကိရိယာများကို ဖန်တီးခြင်းတို့ကို လေ့လာမည်။
>>>>>>> origin/main

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးတွင် သင်သည် အောက်ပါအရာများကို ပြုလုပ်နိုင်မည်ဖြစ်သည်-

<<<<<<< HEAD
- အမျိုးမျိုးသော ပရိုဂရမ်မင်းဘာသာစကားများတွင် တရားဝင် SDK များကို အသုံးပြု၍ MCP ဖြေရှင်းချက်များကို အကောင်အထည်ဖော်နိုင်ရန်
- MCP ဆာဗာများကို စနစ်တကျ အမှားရှာဖွေခြင်းနှင့် စမ်းသပ်နိုင်ရန်
- ဆာဗာအင်္ဂါရပ်များ (Resources, Prompts, Tools) ကို ဖန်တီးပြီး အသုံးပြုနိုင်ရန်
- ရှုပ်ထွေးသော လုပ်ငန်းစဉ်များအတွက် ထိရောက်သော MCP လုပ်ငန်းစဉ်များကို ဒီဇိုင်းဆွဲနိုင်ရန်
- MCP အကောင်အထည်ဖော်မှုများကို စွမ်းဆောင်ရည်နှင့် ယုံကြည်စိတ်ချမှုအတွက် အကောင်းဆုံးအခြေအနေဖြင့် အားဖြည့်နိုင်ရန်
=======
- အမျိုးမျိုးသော ပရိုဂရမ်မင်းဘာသာစကားများတွင် တရားဝင် SDK များကို အသုံးပြု၍ MCP ဖြေရှင်းချက်များကို အကောင်အထည်ဖော်နိုင်မည်
- MCP ဆာဗာများကို စနစ်တကျ အမှားရှာဖွေခြင်းနှင့် စမ်းသပ်နိုင်မည်
- ဆာဗာ၏ အင်္ဂါရပ်များ (Resources, Prompts, Tools) ကို ဖန်တီးပြီး အသုံးပြုနိုင်မည်
- ရှုပ်ထွေးသော လုပ်ငန်းစဉ်များအတွက် ထိရောက်သော MCP လုပ်ငန်းစဉ်များကို ဒီဇိုင်းဆွဲနိုင်မည်
- MCP အကောင်အထည်ဖော်မှုများကို စွမ်းဆောင်ရည်နှင့် ယုံကြည်စိတ်ချမှုအတွက် အကောင်းဆုံးအခြေအနေဖြင့် အားဖြည့်နိုင်မည်
>>>>>>> origin/main

## တရားဝင် SDK အရင်းအမြစ်များ

Model Context Protocol သည် အမျိုးမျိုးသော ဘာသာစကားများအတွက် တရားဝင် SDK များကို ပံ့ပိုးပေးသည်-

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
<<<<<<< HEAD
- [Java with Spring SDK](https://github.com/modelcontextprotocol/java-sdk) **မှတ်ချက်**: [Project Reactor](https://projectreactor.io) အပေါ် မှီခိုမှုလိုအပ်သည်။ ([ဆွေးနွေးမှုအချက် 246](https://github.com/orgs/modelcontextprotocol/discussions/246) ကိုကြည့်ပါ။)
=======
- [Java with Spring SDK](https://github.com/modelcontextprotocol/java-sdk) **မှတ်ချက်**: [Project Reactor](https://projectreactor.io) အပေါ် မှီခိုမှုလိုအပ်သည်။ ([ဆွေးနွေးမှု အမှတ် 246](https://github.com/orgs/modelcontextprotocol/discussions/246) ကို ကြည့်ပါ။)
>>>>>>> origin/main
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK များနှင့် အလုပ်လုပ်ခြင်း

<<<<<<< HEAD
ဤအပိုင်းတွင် MCP ကို အမျိုးမျိုးသော ပရိုဂရမ်မင်းဘာသာစကားများတွင် အကောင်အထည်ဖော်သည့် လက်တွေ့ဥပမာများကို ပံ့ပိုးပေးထားသည်။ `samples` ဖိုလ်ဒါတွင် ဘာသာစကားအလိုက် စီစဉ်ထားသော နမူနာကုဒ်များကို တွေ့နိုင်သည်။
=======
ဤအပိုင်းတွင် MCP ကို အမျိုးမျိုးသော ပရိုဂရမ်မင်းဘာသာစကားများတွင် အကောင်အထည်ဖော်ခြင်းအတွက် လက်တွေ့ ဥပမာများကို ပံ့ပိုးပေးသည်။ `samples` ဖိုလ်ဒါတွင် ဘာသာစကားအလိုက် စီစဉ်ထားသော နမူနာကုဒ်များကို တွေ့နိုင်သည်။
>>>>>>> origin/main

### ရရှိနိုင်သော နမူနာများ

ဤ repository တွင် အောက်ပါ ဘာသာစကားများအတွက် [နမူနာအကောင်အထည်ဖော်မှုများ](../../../04-PracticalImplementation/samples) ပါဝင်သည်-

- [C#](./samples/csharp/README.md)
- [Java with Spring](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

<<<<<<< HEAD
ဘာသာစကားနှင့် ပတ်ဝန်းကျင်အထူးပြု MCP အယူအဆများနှင့် အကောင်အထည်ဖော်မှု ပုံစံများကို နမူနာတစ်ခုစီတွင် ဖော်ပြထားသည်။

## ဆာဗာအင်္ဂါရပ်များ

MCP ဆာဗာများသည် အောက်ပါအင်္ဂါရပ်များကို ပေါင်းစပ်အသုံးပြုနိုင်သည်-

### Resources

Resources များသည် အသုံးပြုသူ သို့မဟုတ် AI မော်ဒယ်အတွက် အကြောင်းအရာနှင့် ဒေတာများကို ပံ့ပိုးပေးသည်-

- စာရွက်စာတမ်း စုစည်းမှုများ
- သိမှတ်စရာ အချက်အလက်များ
=======
နမူနာတစ်ခုစီသည် အဆိုပါ ဘာသာစကားနှင့် ပတ်ဝန်းကျင်အတွက် အဓိက MCP အယူအဆများနှင့် အကောင်အထည်ဖော်မှု ပုံစံများကို ပြသသည်။

## MCP ဆာဗာ၏ အဓိက အင်္ဂါရပ်များ

MCP ဆာဗာများသည် အောက်ပါ အင်္ဂါရပ်များမှ မည်သည့်အရာကိုမဆို အလွတ်ရွေးချယ်၍ အကောင်အထည်ဖော်နိုင်သည်-

### Resources

Resources များသည် အသုံးပြုသူ သို့မဟုတ် AI မော်ဒယ်အတွက် အသုံးချနိုင်သော အကြောင်းအရာနှင့် ဒေတာများကို ပံ့ပိုးပေးသည်-

- စာရွက်စာတမ်း စုစည်းမှုများ
- အသိပညာ အခြေခံများ
>>>>>>> origin/main
- ဖွဲ့စည်းထားသော ဒေတာရင်းမြစ်များ
- ဖိုင်စနစ်များ

### Prompts

<<<<<<< HEAD
Prompts များသည် အသုံးပြုသူများအတွက် ပုံစံတူ စကားစဉ်များနှင့် လုပ်ငန်းစဉ်များဖြစ်သည်-

- ကြိုတင်သတ်မှတ်ထားသော စကားစဉ်ပုံစံများ
- လမ်းညွှန်မှု ပုံစံများ
- အထူးပြု စကားစဉ်ဖွဲ့စည်းမှုများ

### Tools

Tools များသည် AI မော်ဒယ်အတွက် အလုပ်လုပ်ရန် လုပ်ဆောင်ချက်များဖြစ်သည်-

- ဒေတာကို စီမံခန့်ခွဲရန် ကိရိယာများ
- ပြင်ပ API ပေါင်းစည်းမှုများ
- တွက်ချက်မှုစွမ်းရည်များ
- ရှာဖွေရေး လုပ်ဆောင်ချက်များ

## နမူနာအကောင်အထည်ဖော်မှု: C# အကောင်အထည်ဖော်မှု

C# SDK ၏ တရားဝင် repository တွင် MCP ၏ အမျိုးမျိုးသော အကောင်အထည်ဖော်မှုများကို ပြသထားသည်-

- **အခြေခံ MCP Client**: MCP client တစ်ခုကို ဖန်တီးပြီး tools များကို ခေါ်သုံးသည့် ရိုးရှင်းသော ဥပမာ
- **အခြေခံ MCP Server**: အခြေခံ tool မှတ်ပုံတင်မှုနှင့် အတူ ရိုးရှင်းသော ဆာဗာအကောင်အထည်ဖော်မှု
- **အဆင့်မြင့် MCP Server**: Tool မှတ်ပုံတင်မှု၊ authentication၊ နှင့် အမှားကိုင်တွယ်မှုတို့ပါဝင်သည့် အပြည့်အစုံသော ဆာဗာ
- **ASP.NET ပေါင်းစည်းမှု**: ASP.NET Core နှင့် ပေါင်းစည်းမှုကို ပြသသည့် ဥပမာများ
- **Tool အကောင်အထည်ဖော်မှု ပုံစံများ**: အမျိုးမျိုးသော ရှုပ်ထွေးမှုအဆင့်များနှင့် tool များကို အကောင်အထည်ဖော်သည့် ပုံစံများ

C# SDK သည် preview အဆင့်တွင်ရှိပြီး API များသည် ပြောင်းလဲနိုင်သည်။ SDK တိုးတက်မှုနှင့်အတူ ဤ blog ကို ဆက်လက်အပ်ဒိတ်လုပ်သွားမည်။

### အဓိကအင်္ဂါရပ်များ

- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)
- သင်၏ [ပထမဆုံး MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) ကို တည်ဆောက်ခြင်း
=======
Prompts များသည် အသုံးပြုသူများအတွက် ပုံစံတူ စကားစမြည်များနှင့် လုပ်ငန်းစဉ်များဖြစ်သည်-

- ကြိုတင်သတ်မှတ်ထားသော စကားဝိုင်း ပုံစံများ
- လမ်းညွှန်ထားသော အပြန်အလှန် ပုံစံများ
- အထူးပြု စကားဝိုင်း ဖွဲ့စည်းမှုများ

### Tools

Tools များသည် AI မော်ဒယ်အတွက် အကောင်အထည်ဖော်နိုင်သော လုပ်ဆောင်ချက်များဖြစ်သည်-

- ဒေတာကို အလုပ်လုပ်စေသော ကိရိယာများ
- ပြင်ပ API ပေါင်းစည်းမှုများ
- တွက်ချက်မှု စွမ်းရည်များ
- ရှာဖွေမှု လုပ်ဆောင်ချက်

## နမူနာအကောင်အထည်ဖော်မှု: C# အကောင်အထည်ဖော်မှု

C# SDK ၏ တရားဝင် repository တွင် MCP ၏ အမျိုးမျိုးသော အကောင်အထည်ဖော်မှုများကို ပြသသည့် နမူနာများ ပါဝင်သည်-

- **Basic MCP Client**: MCP client တစ်ခုကို ဖန်တီးပြီး tools များကို ခေါ်သုံးပုံကို ပြသသည့် ရိုးရှင်းသော ဥပမာ
- **Basic MCP Server**: အခြေခံ tool မှတ်ပုံတင်မှုဖြင့် ရိုးရှင်းသော ဆာဗာအကောင်အထည်ဖော်မှု
- **Advanced MCP Server**: Tool မှတ်ပုံတင်မှု၊ authentication နှင့် အမှားကိုင်တွယ်မှုတို့ပါဝင်သည့် အပြည့်အစုံသော ဆာဗာ
- **ASP.NET Integration**: ASP.NET Core နှင့် ပေါင်းစည်းမှုကို ပြသသည့် ဥပမာများ
- **Tool Implementation Patterns**: အမျိုးမျိုးသော ရှုပ်ထွေးမှုအဆင့်များဖြင့် tools များကို အကောင်အထည်ဖော်ပုံ

C# SDK သည် preview အဆင့်တွင်ရှိပြီး API များသည် အပြောင်းအလဲရှိနိုင်သည်။ SDK တိုးတက်မှုနှင့်အတူ ဤ blog ကို ဆက်လက် update လုပ်သွားမည်။

### အဓိက အင်္ဂါရပ်များ

- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)
- သင်၏ [ပထမ MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) ကို တည်ဆောက်ခြင်း
>>>>>>> origin/main

C# အကောင်အထည်ဖော်မှု နမူနာများအတွက် [တရားဝင် C# SDK နမူနာ repository](https://github.com/modelcontextprotocol/csharp-sdk) ကို ကြည့်ပါ။

## နမူနာအကောင်အထည်ဖော်မှု: Java with Spring အကောင်အထည်ဖော်မှု

<<<<<<< HEAD
Java with Spring SDK သည် စီးပွားရေးအဆင့်အထိ MCP အကောင်အထည်ဖော်မှု ရွေးချယ်စရာများကို ပံ့ပိုးပေးသည်။

### အဓိကအင်္ဂါရပ်များ

- Spring Framework ပေါင်းစည်းမှု
- အမျိုးအစားလုံခြုံမှုအားကောင်းမှု
- Reactive programming ပံ့ပိုးမှု
- အပြည့်အစုံသော အမှားကိုင်တွယ်မှု

Java with Spring အကောင်အထည်ဖော်မှု နမူနာအတွက် samples ဖိုလ်ဒါရှိ [Java with Spring နမူနာ](samples/java/containerapp/README.md) ကို ကြည့်ပါ။

## နမူနာအကောင်အထည်ဖော်မှု: JavaScript အကောင်အထည်ဖော်မှု

JavaScript SDK သည် MCP အကောင်အထည်ဖော်မှုအတွက် ပေါ့ပါးပြီး လွယ်ကူသော နည်းလမ်းကို ပံ့ပိုးပေးသည်။

### အဓိကအင်္ဂါရပ်များ
=======
Java with Spring SDK သည် စီးပွားရေးအဆင့် အင်္ဂါရပ်များနှင့် MCP အကောင်အထည်ဖော်မှု ရွေးချယ်စရာများကို ပံ့ပိုးပေးသည်။

### အဓိက အင်္ဂါရပ်များ

- Spring Framework နှင့် ပေါင်းစည်းမှု
- အမျိုးအစား လုံခြုံမှုအားကောင်းမှု
- Reactive programming ပံ့ပိုးမှု
- အပြည့်အစုံသော အမှားကိုင်တွယ်မှု

Java with Spring အကောင်အထည်ဖော်မှု နမူနာအတွက် samples ဖိုလ်ဒါရှိ [Java with Spring sample](samples/java/containerapp/README.md) ကို ကြည့်ပါ။

## နမူနာအကောင်အထည်ဖော်မှု: JavaScript အကောင်အထည်ဖော်မှု

JavaScript SDK သည် MCP အကောင်အထည်ဖော်မှုအတွက် ပေါ့ပါးပြီး တင်းကျပ်မှုမရှိသော နည်းလမ်းကို ပံ့ပိုးပေးသည်။

### အဓိက အင်္ဂါရပ်များ
>>>>>>> origin/main

- Node.js နှင့် browser ပံ့ပိုးမှု
- Promise-based API
- Express နှင့် အခြား frameworks များနှင့် လွယ်ကူစွာ ပေါင်းစည်းနိုင်မှု
<<<<<<< HEAD
- WebSocket ပံ့ပိုးမှု

JavaScript အကောင်အထည်ဖော်မှု နမူနာအတွက် samples ဖိုလ်ဒါရှိ [JavaScript နမူနာ](samples/javascript/README.md) ကို ကြည့်ပါ။
=======
- Streaming အတွက် WebSocket ပံ့ပိုးမှု

JavaScript အကောင်အထည်ဖော်မှု နမူနာအတွက် samples ဖိုလ်ဒါရှိ [JavaScript sample](samples/javascript/README.md) ကို ကြည့်ပါ။
>>>>>>> origin/main

## နမူနာအကောင်အထည်ဖော်မှု: Python အကောင်အထည်ဖော်မှု

Python SDK သည် MCP အကောင်အထည်ဖော်မှုအတွက် Pythonic နည်းလမ်းနှင့် ML framework ပေါင်းစည်းမှုများကို ပံ့ပိုးပေးသည်။

<<<<<<< HEAD
### အဓိကအင်္ဂါရပ်များ
=======
### အဓိက အင်္ဂါရပ်များ
>>>>>>> origin/main

- Async/await ပံ့ပိုးမှု (asyncio ဖြင့်)
- FastAPI ပေါင်းစည်းမှု
- ရိုးရှင်းသော tool မှတ်ပုံတင်မှု
<<<<<<< HEAD
- လူကြိုက်များသော ML စာကြည့်တိုက်များနှင့် သဘာဝကျသော ပေါင်းစည်းမှု

Python အကောင်အထည်ဖော်မှု နမူနာအတွက် samples ဖိုလ်ဒါရှိ [Python နမူနာ](samples/python/README.md) ကို ကြည့်ပါ။

## API စီမံခန့်ခွဲမှု

Azure API Management သည် MCP Servers များကို လုံခြုံစေရန် အကောင်းဆုံးဖြေရှင်းချက်တစ်ခုဖြစ်သည်။ API Management ကို MCP Server ရှေ့တွင် ထားပြီး အောက်ပါလိုအပ်ချက်များကို ကိုင်တွယ်စေသည်-
=======
- လူကြိုက်များသော ML စာကြည့်တိုက်များနှင့် သဘာဝပေါင်းစည်းမှု

Python အကောင်အထည်ဖော်မှု နမူနာအတွက် samples ဖိုလ်ဒါရှိ [Python sample](samples/python/README.md) ကို ကြည့်ပါ။

## API စီမံခန့်ခွဲမှု

Azure API Management သည် MCP Servers များကို လုံခြုံစေရန် အကောင်းဆုံးဖြေရှင်းချက်တစ်ခုဖြစ်သည်။ ၎င်း၏ အဓိကအကြံက MCP Server ၏ရှေ့တွင် Azure API Management instance တစ်ခုကို ထားပြီး အောက်ပါလိုအပ်ချက်များကို ကိုင်တွယ်စေခြင်းဖြစ်သည်-
>>>>>>> origin/main

- rate limiting
- token စီမံခန့်ခွဲမှု
- စောင့်ကြည့်မှု
- load balancing
- လုံခြုံမှု

### Azure နမူနာ

<<<<<<< HEAD
Azure API Management ဖြင့် MCP Server တစ်ခုကို တည်ဆောက်ပြီး လုံခြုံစေရန် [နမူနာ](https://github.com/Azure-Samples/remote-mcp-apim-functions-python) ကို ကြည့်ပါ။

အထက်ပါနမူနာတွင် authentication/authorization, traffic စီမံခန့်ခွဲမှု, နှင့် Azure Monitor logs များကို အသုံးပြုထားသည်။

#### MCP authorization specification

MCP Authorization specification အကြောင်း [ပိုမိုသိရှိရန်](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) ကို ကြည့်ပါ။

## Azure တွင် Remote MCP Server တင်ပို့ခြင်း

နမူနာကို Azure တွင် deploy လုပ်ရန် အောက်ပါအဆင့်များကို လိုက်နာပါ-
=======
ဤနမူနာသည် MCP Server တစ်ခုကို တည်ဆောက်ပြီး Azure API Management ဖြင့် လုံခြုံစေရန် ပြသသည်- [Azure Sample](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

အထက်ပါနမူနာတွင် authentication/authorization နှင့် Azure API Management ၏ gateway အဖြစ် လုပ်ဆောင်မှုကို ပြသထားသည်။

#### MCP authorization specification

MCP Authorization specification အကြောင်း [ပိုမိုသိရှိရန်](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) 

## Azure တွင် Remote MCP Server တင်သွင်းခြင်း

နမူနာကို အကောင်အထည်ဖော်ရန် အောက်ပါအဆင့်များကို လိုက်နာပါ-
>>>>>>> origin/main

1. Repo ကို Clone လုပ်ပါ

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

<<<<<<< HEAD
1. `Microsoft.App` resource provider ကို မှတ်ပုံတင်ပါ။

   - Azure CLI သုံးပါက `az provider register --namespace Microsoft.App --wait` ကို run လုပ်ပါ။
   - Azure PowerShell သုံးပါက `Register-AzResourceProvider -ProviderNamespace Microsoft.App` ကို run လုပ်ပါ။

1. [azd](https://aka.ms/azd) command ကို run လုပ်ပါ-
=======
1. `Microsoft.App` resource provider ကို မှတ်ပုံတင်ပါ

   - Azure CLI သုံးပါက `az provider register --namespace Microsoft.App --wait` ကို run လုပ်ပါ
   - Azure PowerShell သုံးပါက `Register-AzResourceProvider -ProviderNamespace Microsoft.App` ကို run လုပ်ပါ

1. [azd](https://aka.ms/azd) command ကို run လုပ်ပါ
>>>>>>> origin/main

    ```shell
    azd up
    ```

<<<<<<< HEAD
    ဤ command သည် cloud resources များကို Azure တွင် deploy လုပ်ပေးမည်။

### MCP Inspector ဖြင့် ဆာဗာကို စမ်းသပ်ခြင်း

1. **အသစ်သော terminal window** တွင် MCP Inspector ကို install လုပ်ပြီး run လုပ်ပါ-
=======
    ဤ command သည် cloud resources များအားလုံးကို Azure တွင် တင်သွင်းပေးမည်

### MCP Inspector ဖြင့် သင့်ဆာဗာကို စမ်းသပ်ခြင်း

1. MCP Inspector ကို install လုပ်ပြီး run လုပ်ပါ
>>>>>>> origin/main

    ```shell
    npx @modelcontextprotocol/inspector
    ```

<<<<<<< HEAD
    MCP Inspector web app ကို URL မှာ ဖွင့်ပါ။

1. Transport type ကို `SSE` သတ်မှတ်ပါ။
1. API Management SSE endpoint URL ကို ထည့်ပြီး **Connect** လုပ်ပါ။
=======
    MCP Inspector web app ကို URL မှာ ဖွင့်ပါ

1. Transport type ကို `SSE` သတ်မှတ်ပါ
1. API Management SSE endpoint URL ကို ထည့်ပြီး **Connect** လုပ်ပါ
>>>>>>> origin/main

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

<<<<<<< HEAD
1. **List Tools**. Tool တစ်ခုကို ရွေးပြီး **Run Tool** လုပ်ပါ။

အဆင့်အားလုံးအောင်မြင်ပါက MCP server နှင့် ချိတ်ဆက်ပြီး tool ကို ခေါ်သုံးနိုင်ပါပြီ။

## Azure အတွက် MCP Servers

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Azure Functions ဖြင့် Python, C# .NET, သို့မဟုတ် Node/TypeScript အသုံးပြု၍ MCP servers တည်ဆောက်ရန် quickstart template များ။

### အဓိကအင်္ဂါရပ်များ

- လုံခြုံမှုကို အခြေခံထားခြင်း
- OAuth နှင့် API Management ပေါင်းစည်းမှု
- Azure Virtual Networks (VNET) ဖြင့် network isolation
- Serverless architecture
- လွယ်ကူသော deployment

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript)

## အဓိကအချက်များ

- MCP SDK များသည် MCP ဖြေရှင်းချက်များကို အကောင်အထည်ဖော်ရန် language-specific tools များကို ပံ့ပိုးပေးသည်

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းဘာသာစကားဖြင့် ရေးသားထားသော စာရွက်စာတမ်းကို အာဏာရှိသော ရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူက ဘာသာပြန်မှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားယူမှားမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
=======
1. Tools များကို စမ်းသပ်ပါ

အဆင့်အားလုံးအောင်မြင်ပါက သင်သည် MCP server နှင့် ချိတ်ဆက်ပြီး tool ကို ခေါ်သုံးနိုင်ပါမည်။

## Azure အတွက် MCP Servers

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Azure Functions ကို အသုံးပြု၍ MCP servers တည်ဆောက်ရန် အမြန်စတင်ရန် template များ

### အဓိက အင်္ဂါရပ်များ

- လုံခြုံမှုကို ဦးစားပေးထားခြင်း
- OAuth authentication ပံ့ပိုးမှု
- Azure Virtual Networks (VNET) ဖြင့် network isolation
- Serverless architecture
- လွယ်ကူသော တင်သွင်းမှု

Python, C# .NET, Node/TypeScript အတွက် Azure Remote MCP Functions နမူနာများကို ကြည့်ပါ-

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python)
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet)
- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-types

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းဘာသာစကားဖြင့် ရေးသားထားသော စာရွက်စာတမ်းကို အာဏာရှိသော ရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအမှားများ သို့မဟုတ် အနားယူမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
>>>>>>> origin/main
