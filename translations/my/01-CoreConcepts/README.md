<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a6a7bcb289c024a91289e0444cb370b",
<<<<<<< HEAD
  "translation_date": "2025-08-18T23:14:26+00:00",
=======
  "translation_date": "2025-08-18T18:36:00+00:00",
>>>>>>> origin/main
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "my"
}
-->
<<<<<<< HEAD
# MCP အခြေခံအယူအဆများ: AI ပေါင်းစည်းမှုအတွက် Model Context Protocol ကိုကျွမ်းကျင်စွာအသုံးပြုခြင်း

[![MCP Core Concepts](../../../translated_images/02.8203e26c6fb5a797f38a10012061013ec66c95bb3260f6c9cfd2bf74b00860e1.my.png)](https://youtu.be/earDzWGtE84)

_(ဤသင်ခန်းစာ၏ဗီဒီယိုကိုကြည့်ရန် အထက်ပါပုံကိုနှိပ်ပါ)_

[Model Context Protocol (MCP)](https://gi- **အသုံးပြုသူ၏ထောက်ခံချက်**: ဒေတာရယူခြင်းနှင့် လုပ်ဆောင်မှုများအားလုံးသည် အသုံးပြုသူ၏ထောက်ခံချက်ရရှိမှသာ အကောင်အထည်ဖော်မည်ဖြစ်သည်။ အသုံးပြုသူများသည် မည်သည့်ဒေတာကိုရယူမည်နှင့် မည်သည့်လုပ်ဆောင်မှုများကိုပြုလုပ်မည်ကို ရှင်းလင်းစွာနားလည်ပြီး ခွင့်ပြုချက်များနှင့် အာဏာပေးမှုများကို အသေးစိတ်ထိန်းချုပ်နိုင်ရမည်။

- **ဒေတာကိုယ်ရေးကိုယ်တာအကာအကွယ်**: အသုံးပြုသူ၏ဒေတာကို ထောက်ခံချက်မရှိဘဲ မဖော်ထုတ်ရသလို၊ အပြည့်အဝအကာအကွယ်ပေးထားသော လုပ်ဆောင်မှုဆိုင်ရာလမ်းကြောင်းတစ်လျှောက်လုံးတွင် ထိန်းသိမ်းထားရမည်။ ခွင့်မပြုထားသောဒေတာပို့ဆောင်မှုများကိုတားဆီးပြီး ကိုယ်ရေးကိုယ်တာအကန့်အသတ်များကို တင်းကြပ်စွာထိန်းသိမ်းရမည်။

- **ကိရိယာအသုံးပြုမှုလုံခြုံမှု**: ကိရိယာတစ်ခုချင်းစီကို အသုံးပြုရန်အတွက် အသုံးပြုသူ၏ထောက်ခံချက်နှင့် ကိရိယာ၏လုပ်ဆောင်မှု၊ ပါရာမီတာများနှင့် ဖြစ်နိုင်သောသက်ရောက်မှုများကို ရှင်းလင်းစွာနားလည်မှုလိုအပ်သည်။ မတော်တဆဖြစ်ရပ်များ၊ မလုံခြုံသောလုပ်ဆောင်မှုများ သို့မဟုတ် မကောင်းဆိုးရွားသောလုပ်ဆောင်မှုများကို တားဆီးရန် လုံခြုံရေးအကန့်အသတ်များကို တင်းကြပ်စွာထိန်းသိမ်းရမည်။

- **သယ်ယူပို့ဆောင်မှုအလွှာလုံခြုံမှု**: ဆက်သွယ်မှုလမ်းကြောင်းအားလုံးတွင် သင့်လျော်သော စာဝှက်ခြင်းနှင့် အတည်ပြုမှုစနစ်များကို အသုံးပြုရမည်။ အဝေးမှဆက်သွယ်မှုများတွင် လုံခြုံသော သယ်ယူပို့ဆောင်မှုပရိုတိုကောများနှင့် သင့်တော်သော အထောက်အထားစီမံခန့်ခွဲမှုကို အကောင်အထည်ဖော်ရမည်။

#### အကောင်အထည်ဖော်မှုအညွှန်းများ:

- **ခွင့်ပြုချက်စီမံခန့်ခွဲမှု**: အသုံးပြုသူများအား မည်သည့် server များ၊ ကိရိယာများနှင့် အရင်းအမြစ်များကို အသုံးပြုခွင့်ပြုမည်ကို ထိန်းချုပ်နိုင်စေရန် အသေးစိတ်ခွင့်ပြုချက်စနစ်များကို အကောင်အထည်ဖော်ပါ  
- **အတည်ပြုမှုနှင့် အာဏာပေးမှု**: လုံခြုံသော အတည်ပြုမှုနည်းလမ်းများ (OAuth, API key များ) ကို သက်တမ်းကုန်ဆုံးမှုနှင့် token စီမံခန့်ခွဲမှုမှန်ကန်စွာအသုံးပြုပါ  
- **အဝင်ဒေတာစစ်ဆေးမှု**: Injection အတိုက်အခံများကိုတားဆီးရန် သတ်မှတ်ထားသော schema များအတိုင်း ပါရာမီတာများနှင့် အဝင်ဒေတာအားလုံးကို စစ်ဆေးပါ  
- **မှတ်တမ်းမှတ်သားမှု**: လုံခြုံရေးစောင့်ကြည့်မှုနှင့် လိုက်နာမှုအတွက် လုပ်ဆောင်မှုအားလုံး၏ ပြည့်စုံသောမှတ်တမ်းများကို ထိန်းသိမ်းပါ  

[Model Context Protocol (MCP)](https://modelcontextprotocol.io/specification/2025-06-18/) သည် အကြီးမားသောဘာသာစကားမော်ဒယ်များ (LLMs) နှင့် အပြင်ပကိရိယာများ၊ အက်ပလီကေးရှင်းများနှင့် ဒေတာရင်းမြစ်များအကြား ဆက်သွယ်မှုကို အကောင်းဆုံးလုပ်ဆောင်ပေးသည့် စံပြစနစ်တစ်ခုဖြစ်သည်။ ဤလမ်းညွှန်စာအုပ်သည် MCP ၏ အခြေခံအယူအဆများကို နားလည်စေရန် client-server ဖွဲ့စည်းမှု၊ အရေးပါသောအစိတ်အပိုင်းများ၊ ဆက်သွယ်မှုစနစ်များနှင့် အကောင်အထည်ဖော်မှုအကောင်းဆုံးလေ့ကျင့်မှုများကို ရှင်းလင်းပြသမည်ဖြစ်သည်။

## အကျဉ်းချုပ်

ဤသင်ခန်းစာသည် Model Context Protocol (MCP) စနစ်၏ အခြေခံဖွဲ့စည်းမှုနှင့် အစိတ်အပိုင်းများကို လေ့လာမည်ဖြစ်သည်။ MCP ၏ client-server ဖွဲ့စည်းမှု၊ အရေးပါသောအခန်းကဏ္ဍများနှင့် MCP အပြန်အလှန်ဆက်သွယ်မှုများကို အားဖြည့်ပေးသည့် စနစ်များကို သင်လေ့လာနိုင်မည်။

## အဓိကသင်ယူရမည့်ရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးတွင် သင်သည်-

- MCP client-server ဖွဲ့စည်းမှုကို နားလည်မည်။
- Hosts, Clients, နှင့် Servers ၏ အခန်းကဏ္ဍများနှင့် တာဝန်များကို သုံးသပ်နိုင်မည်။
- MCP ကို အလွယ်တကူပေါင်းစည်းနိုင်စေရန် အဓိကအင်္ဂါရပ်များကို ခွဲခြမ်းစိတ်ဖြာနိုင်မည်။
- MCP စနစ်အတွင်း ဒေတာစီးဆင်းမှုကို နားလည်မည်။
- .NET, Java, Python, နှင့် JavaScript တို့ဖြင့် လက်တွေ့ဥပမာများမှ အတွေ့အကြုံရရှိမည်။

## MCP ဖွဲ့စည်းမှု: နက်နက်ရှိုင်းရှိုင်းကြည့်ရှုခြင်း

MCP စနစ်သည် client-server မော်ဒယ်တစ်ခုအပေါ် အခြေခံထားသည်။ ဤ module ဖွဲ့စည်းမှုသည် AI အက်ပလီကေးရှင်းများအား ကိရိယာများ၊ ဒေတာဘေ့စ်များ၊ API များနှင့် အခြေခံအရင်းအမြစ်များနှင့် ထိရောက်စွာပေါင်းစည်းနိုင်စေရန် အထောက်အကူပြုသည်။ ယခုဖွဲ့စည်းမှုကို အဓိကအစိတ်အပိုင်းများအဖြစ် ခွဲခြမ်းစိတ်ဖြာကြည့်ပါမည်။

MCP ၏ အခြေခံတွင် client-server ဖွဲ့စည်းမှုတစ်ခုရှိပြီး host application တစ်ခုသည် server များစွာနှင့် ချိတ်ဆက်နိုင်သည်-
=======
# MCP အဓိကအကြောင်းအရာများ: AI ပေါင်းစည်းမှုအတွက် Model Context Protocol ကိုကျွမ်းကျင်စွာအသုံးပြုခြင်း

[![MCP အဓိကအကြောင်းအရာများ](../../../translated_images/02.8203e26c6fb5a797f38a10012061013ec66c95bb3260f6c9cfd2bf74b00860e1.my.png)](https://youtu.be/earDzWGtE84)

_(အထက်ပါပုံကိုနှိပ်ပြီး ဒီသင်ခန်းစာ၏ဗီဒီယိုကိုကြည့်ပါ)_

[Model Context Protocol (MCP)](https://gi- **အသုံးပြုသူ၏ထောက်ခံချက်**: ဒေတာဝင်ရောက်မှုနှင့်လုပ်ဆောင်မှုအားလုံးသည် အသုံးပြုသူ၏ထောက်ခံချက်ကိုရှင်းလင်းစွာရရှိထားရမည်။ အသုံးပြုသူများသည် ဝင်ရောက်မည့်ဒေတာနှင့်လုပ်ဆောင်မည့်အရာများကို အပြည့်အဝနားလည်ပြီး ခွင့်ပြုချက်များနှင့်အာဏာပိုင်မှုများကို စိတ်ကြိုက်ထိန်းချုပ်နိုင်ရမည်။

- **ဒေတာကိုယ်ရေးကိုယ်တာအကာအကွယ်**: အသုံးပြုသူ၏ဒေတာကို ထောက်ခံချက်မရှိဘဲ မဖော်ထုတ်ရ၊ ထိန်းချုပ်မှုကာကွယ်မှုများဖြင့် အပြည့်အဝကာကွယ်ထားရမည်။ မလိုလားအပ်သောဒေတာပို့ဆောင်မှုများကိုတားဆီးပြီး ကိုယ်ရေးကိုယ်တာအကန့်အသတ်များကို တင်းကျပ်စွာထိန်းသိမ်းရမည်။

- **ကိရိယာအသုံးပြုမှုလုံခြုံမှု**: ကိရိယာတစ်ခုချင်းစီကို အသုံးပြုသူ၏ထောက်ခံချက်ဖြင့်သာ အသုံးပြုခွင့်ပြုရမည်။ ကိရိယာ၏လုပ်ဆောင်မှု၊ ပါရာမီတာများနှင့် ဖြစ်နိုင်သောရလဒ်များကို အသုံးပြုသူများရှင်းလင်းစွာနားလည်ရမည်။ မလိုလားအပ်သော၊ အန္တရာယ်ရှိသော သို့မဟုတ် မကောင်းမဆိုးသော ကိရိယာအသုံးပြုမှုများကို တားဆီးရန် လုံခြုံရေးကန့်သတ်ချက်များရှိရမည်။

- **သယ်ယူပို့ဆောင်မှုအလွှာလုံခြုံမှု**: ဆက်သွယ်မှုလမ်းကြောင်းအားလုံးတွင် သင့်လျော်သောစနစ်များဖြင့် စာဝှက်ခြင်းနှင့်အတည်ပြုခြင်းကို အသုံးပြုရမည်။ အဝေးမှဆက်သွယ်မှုများတွင် လုံခြုံသောသယ်ယူပို့ဆောင်မှုနည်းလမ်းများနှင့် မှန်ကန်သောလက်မှတ်စီမံခန့်ခွဲမှုကို အသုံးပြုရမည်။

#### အကောင်အထည်ဖော်ရန်လမ်းညွှန်ချက်များ:

- **ခွင့်ပြုချက်စီမံခန့်ခွဲမှု**: အသုံးပြုသူများအား ဝင်ရောက်ခွင့်ရှိသော server များ၊ ကိရိယာများနှင့် အရင်းအမြစ်များကို စိတ်ကြိုက်ထိန်းချုပ်နိုင်စေရန် စနစ်တကျခွင့်ပြုချက်စနစ်များကို အကောင်အထည်ဖော်ပါ။
- **အတည်ပြုခြင်းနှင့်ခွင့်ပြုခြင်း**: လုံခြုံသောအတည်ပြုနည်းလမ်းများ (OAuth, API key များ) ကို သက်တမ်းကုန်ဆုံးမှုနှင့် token စီမံခန့်ခွဲမှုမှန်ကန်စွာအသုံးပြုပါ။
- **အဝင်ဒေတာစစ်ဆေးမှု**: Injection အန္တရာယ်များကိုတားဆီးရန် သတ်မှတ်ထားသော schema များအတိုင်း ပါရာမီတာများနှင့်အဝင်ဒေတာအားလုံးကို စစ်ဆေးပါ။
- **မှတ်တမ်းသိမ်းဆည်းမှု**: လုံခြုံရေးစောင့်ကြည့်မှုနှင့်လိုက်နာမှုအတွက် လုပ်ဆောင်မှုအားလုံး၏ ပြည့်စုံသောမှတ်တမ်းများကို ထိန်းသိမ်းပါ။

[Model Context Protocol (MCP)](https://modelcontextprotocol.io/specification/2025-06-18/) သည် Large Language Models (LLMs) နှင့် အပြင်ပကိရိယာများ၊ အပလီကေးရှင်းများနှင့် ဒေတာအရင်းအမြစ်များအကြား ဆက်သွယ်မှုကို အကောင်းဆုံးဖြစ်စေသော စံပြစနစ်တစ်ခုဖြစ်သည်။ ဒီလမ်းညွှန်စာအုပ်သည် MCP ၏ client-server architecture, အဓိကအစိတ်အပိုင်းများ၊ ဆက်သွယ်မှုစနစ်များနှင့် အကောင်အထည်ဖော်မှုအကောင်းဆုံးလေ့ကျင့်မှုများကို နားလည်စေရန် သင့်အားလမ်းညွှန်ပေးမည်ဖြစ်သည်။

## အကျဉ်းချုပ်

ဒီသင်ခန်းစာတွင် Model Context Protocol (MCP) ecosystem ၏ အခြေခံဖွဲ့စည်းပုံနှင့် အစိတ်အပိုင်းများကို လေ့လာမည်ဖြစ်သည်။ MCP ၏ client-server architecture, အဓိကအခန်းကဏ္ဍများနှင့် ဆက်သွယ်မှုစနစ်များကို သင်လေ့လာနိုင်မည်ဖြစ်သည်။

## အဓိကသင်ယူရမည့်ရည်မှန်းချက်များ

ဒီသင်ခန်းစာအဆုံးတွင် သင်သည်-

- MCP client-server architecture ကိုနားလည်နိုင်မည်။
- Hosts, Clients, နှင့် Servers ၏ အခန်းကဏ္ဍများကို သတ်မှတ်နိုင်မည်။
- MCP ကို flexible integration layer ဖြစ်စေသော အဓိက features များကို ခွဲခြမ်းစိတ်ဖြာနိုင်မည်။
- MCP ecosystem အတွင်း ဒေတာစီးဆင်းမှုကို နားလည်နိုင်မည်။
- .NET, Java, Python, နှင့် JavaScript မှာရှိသော ကုဒ်ဥပမာများမှ လက်တွေ့အမြင်များရရှိနိုင်မည်။

## MCP Architecture: နက်ရှိုင်းစွာလေ့လာခြင်း

MCP ecosystem သည် client-server မော်ဒယ်ပေါ်တွင်တည်ဆောက်ထားသည်။ ဒီ modular ဖွဲ့စည်းပုံသည် AI အပလီကေးရှင်းများကို ကိရိယာများ၊ ဒေတာဘေ့စ်များ၊ API များနှင့် context အရင်းအမြစ်များနှင့် ထိရောက်စွာပေါင်းစည်းစေသည်။ ဒီ architecture ကို အဓိကအစိတ်အပိုင်းများအဖြစ် ခွဲခြမ်းစိတ်ဖြာကြည့်ပါစို့။

MCP ၏အခြေခံတွင် client-server architecture ကိုလိုက်နာပြီး host application တစ်ခုသည် server များစွာနှင့် ချိတ်ဆက်နိုင်သည်-
>>>>>>> origin/main

```mermaid
flowchart LR
    subgraph "Your Computer"
        Host["Host with MCP (Visual Studio, VS Code, IDEs, Tools)"]
        S1["MCP Server A"]
        S2["MCP Server B"]
        S3["MCP Server C"]
        Host <-->|"MCP Protocol"| S1
        Host <-->|"MCP Protocol"| S2
        Host <-->|"MCP Protocol"| S3
        S1 <--> D1[("Local\Data Source A")]
        S2 <--> D2[("Local\Data Source B")]
    end
    subgraph "Internet"
        S3 <-->|"Web APIs"| D3[("Remote\Services")]
    end
```

<<<<<<< HEAD
- **MCP Hosts**: VSCode, Claude Desktop, IDEs, သို့မဟုတ် MCP မှတစ်ဆင့် ဒေတာရယူလိုသော AI ကိရိယာများ  
- **MCP Clients**: Server များနှင့် 1:1 ချိတ်ဆက်မှုကို ထိန်းသိမ်းထားသည့် protocol clients  
- **MCP Servers**: Model Context Protocol စံစနစ်မှတစ်ဆင့် အထူးစွမ်းဆောင်ရည်များကို ဖော်ထုတ်ပေးသည့် ပေါ့ပါးသောပရိုဂရမ်များ  
- **ဒေတာရင်းမြစ်ဒေသခံများ**: သင့်ကွန်ပျူတာရှိ ဖိုင်များ၊ ဒေတာဘေ့စ်များနှင့် ဝန်ဆောင်မှုများကို MCP servers မှ လုံခြုံစွာရယူနိုင်သည်  
- **အဝေးမှဝန်ဆောင်မှုများ**: MCP servers မှ API များမှတစ်ဆင့် ချိတ်ဆက်နိုင်သည့် အင်တာနက်ပေါ်ရှိ အပြင်ပစနစ်များ  

MCP Protocol သည် YYYY-MM-DD ပုံစံဖြင့် ရက်စွဲအခြေခံဗားရှင်းသတ်မှတ်မှုကို အသုံးပြုသည့် တိုးတက်နေသောစံစနစ်တစ်ခုဖြစ်သည်။ လက်ရှိ protocol ဗားရှင်းမှာ **2025-06-18** ဖြစ်သည်။ [protocol specification](https://modelcontextprotocol.io/specification/2025-06-18/) တွင် နောက်ဆုံးအပ်ဒိတ်များကို ကြည့်ရှုနိုင်သည်။

### 1. Hosts

Model Context Protocol (MCP) တွင် **Hosts** သည် အသုံးပြုသူများမှ protocol နှင့် အဓိကအဆက်အသွယ်အဖြစ် တာဝန်ထမ်းဆောင်သည့် AI အက်ပလီကေးရှင်းများဖြစ်သည်။ Hosts များသည် MCP server များစွာနှင့် ချိတ်ဆက်မှုများကို စီမံခန့်ခွဲရန် MCP clients များကို ဖန်တီးပေးသည်။ Hosts ၏ ဥပမာများမှာ-

- **AI အက်ပလီကေးရှင်းများ**: Claude Desktop, Visual Studio Code, Claude Code  
- **ဖွံ့ဖြိုးတိုးတက်မှုပတ်ဝန်းကျင်များ**: MCP ပေါင်းစည်းမှုပါရှိသော IDE များနှင့် ကုဒ်တည်းဖြတ်သူများ  
- **စိတ်ကြိုက်အက်ပလီကေးရှင်းများ**: ရည်ရွယ်ချက်သတ်မှတ်ထားသော AI အေးဂျင့်များနှင့် ကိရိယာများ  

**Hosts** သည် AI မော်ဒယ်အပြန်အလှန်ဆက်သွယ်မှုများကို စီမံခန့်ခွဲသည့် အက်ပလီကေးရှင်းများဖြစ်သည်။ ၎င်းတို့သည်-

- **AI မော်ဒယ်များကို စီမံခန့်ခွဲခြင်း**: LLM များကို အကောင်အထည်ဖော်ခြင်း သို့မဟုတ် အပြန်အလှန်ဆက်သွယ်မှုများကို စီမံခန့်ခွဲခြင်း  
- **Client ချိတ်ဆက်မှုများကို စီမံခန့်ခွဲခြင်း**: MCP server တစ်ခုချင်းစီအတွက် MCP client တစ်ခုစီကို ဖန်တီးပြီး ထိန်းသိမ်းခြင်း  
- **အသုံးပြုသူအင်တာဖေ့စ်ကို ထိန်းချုပ်ခြင်း**: စကားဝိုင်းစီးဆင်းမှု၊ အသုံးပြုသူအပြန်အလှန်ဆက်သွယ်မှုများနှင့် တုံ့ပြန်မှုတင်ဆက်မှုကို စီမံခန့်ခွဲခြင်း  
- **လုံခြုံရေးကို အကောင်အထည်ဖော်ခြင်း**: ခွင့်ပြုချက်များ၊ လုံခြုံရေးကန့်သတ်ချက်များနှင့် အတည်ပြုမှုကို ထိန်းချုပ်ခြင်း  
- **အသုံးပြုသူထောက်ခံချက်ကို စီမံခန့်ခွဲခြင်း**: ဒေတာမျှဝေမှုနှင့် ကိရိယာအသုံးပြုမှုအတွက် အသုံးပြုသူ၏အတည်ပြုမှုကို စီမံခန့်ခွဲခြင်း  

### 2. Clients

**Clients** သည် Hosts နှင့် MCP servers အကြား တစ်ဦးချင်းချင်း ချိတ်ဆက်မှုများကို ထိန်းသိမ်းထားသည့် အရေးပါသောအစိတ်အပိုင်းများဖြစ်သည်။ MCP client တစ်ခုစီသည် Host မှ ဖန်တီးပြီး သတ်မှတ်ထားသော MCP server တစ်ခုနှင့် ချိတ်ဆက်ရန် အသုံးပြုသည်။ Clients များစွာသည် Hosts များအား Server များစွာနှင့် တစ်ပြိုင်နက်ချိတ်ဆက်နိုင်စေရန် အထောက်အကူပြုသည်။

**Clients** သည် host application အတွင်းရှိ ချိတ်ဆက်မှုအစိတ်အပိုင်းများဖြစ်သည်။ ၎င်းတို့သည်-

- **Protocol ဆက်သွယ်မှု**: JSON-RPC 2.0 တောင်းဆိုမှုများကို server များထံ ပေးပို့ခြင်း  
- **စွမ်းဆောင်ရည်ညှိနှိုင်းမှု**: စတင်ချိတ်ဆက်မှုအတွင်း server များနှင့် protocol ဗားရှင်းများကို ညှိနှိုင်းခြင်း  
- **ကိရိယာအကောင်အထည်ဖော်မှု**: မော်ဒယ်များမှ tool execution တောင်းဆိုမှုများကို စီမံခန့်ခွဲခြင်း  
- **အချိန်နှင့်တပြေးညီအပ်ဒိတ်များ**: Server များမှ အချိန်နှင့်တပြေးညီအချက်အလက်များကို စီမံခန့်ခွဲခြင်း  
- **တုံ့ပြန်မှုကို စီမံခြင်း**: Server response များကို အသုံးပြုသူများအတွက် ဖော်ပြရန် ပြင်ဆင်ခြင်း  

### 3. Servers

**Servers** သည် MCP clients များအား context, tools, နှင့် စွမ်းဆောင်ရည်များကို ပေးစွမ်းသည့် ပရိုဂရမ်များဖြစ်သည်...
- **Lifecycle Management**: Client နှင့် Server အကြား ချိတ်ဆက်မှု စတင်ခြင်း၊ စွမ်းရည်ညှိနှိုင်းခြင်းနှင့် session ပိတ်သိမ်းခြင်းကို စီမံခန့်ခွဲသည်  
- **Server Primitives**: Server များအနေဖြင့် အခြေခံလုပ်ဆောင်ချက်များကို ကိရိယာများ၊ အရင်းအမြစ်များနှင့် prompt များမှတဆင့် ပေးဆောင်နိုင်စေသည်  
- **Client Primitives**: Server များအနေဖြင့် LLM များမှ sampling တောင်းဆိုခြင်း၊ အသုံးပြုသူ input ရယူခြင်းနှင့် log message များပို့ခြင်းကို request ပြုနိုင်စေသည်  
- **Real-time Notifications**: polling မလိုအပ်ဘဲ dynamic updates များအတွက် asynchronous notifications များကို ပံ့ပိုးပေးသည်  

#### Key Features:

- **Protocol Version Negotiation**: Compatibility အတွက် date-based versioning (YYYY-MM-DD) ကို အသုံးပြုသည်  
- **Capability Discovery**: Initialization အတွင်း Client နှင့် Server များအကြား ပံ့ပိုးနိုင်သော feature အချက်အလက်များကို လဲလှယ်သည်  
- **Stateful Sessions**: အကြောင်းအရာဆက်လက်တည်ရှိစေရန် အများအပြားသော အပြန်အလှန်ဆက်သွယ်မှုများအတွင်း connection state ကို ထိန်းသိမ်းထားသည်  

### Transport Layer

**Transport Layer** သည် MCP ပါဝင်သူများအကြား ဆက်သွယ်မှု channel များ၊ message framing နှင့် authentication ကို စီမံခန့်ခွဲသည်။

#### Supported Transport Mechanisms:

1. **STDIO Transport**:
   - Process တိုက်ရိုက်ဆက်သွယ်မှုအတွက် standard input/output stream များကို အသုံးပြုသည်  
   - Network overhead မရှိသော တစ်စက်ရုံအတွင်း local process များအတွက် အကောင်းဆုံးဖြစ်သည်  
   - MCP server implementation များအတွက် အများဆုံးအသုံးပြုသည်  

2. **Streamable HTTP Transport**:
   - Client-to-server message များအတွက် HTTP POST ကို အသုံးပြုသည်  
   - Server-to-client streaming အတွက် Optional Server-Sent Events (SSE) ကို ပံ့ပိုးသည်  
   - Network များအတွင်း remote server များနှင့် ဆက်သွယ်မှုကို အကောင်းဆုံးဖြစ်စေသည်  
   - Standard HTTP authentication (bearer tokens, API keys, custom headers) ကို ပံ့ပိုးသည်  
   - MCP သည် secure token-based authentication အတွက် OAuth ကို အကြံပြုသည်  

#### Transport Abstraction:

Transport layer သည် data layer မှ ဆက်သွယ်မှုအသေးစိတ်ကို abstract လုပ်ပေးပြီး transport mechanism များအားလုံးအတွက် JSON-RPC 2.0 message format တူညီစွာ အသုံးပြုနိုင်စေသည်။ Application များအနေဖြင့် local နှင့် remote server များအကြား အလွယ်တကူ ပြောင်းလဲနိုင်စေသည်။

### Security Considerations

MCP implementation များအနေဖြင့် protocol operation များအတွင်း လုံခြုံမှု၊ ယုံကြည်မှုနှင့် လုံခြုံစိတ်ချရမှုကို အာမခံရန် အရေးကြီးသော လုံခြုံရေးမူဝါဒများကို လိုက်နာရမည်။

- **User Consent and Control**: Data ကို access လုပ်ခြင်း သို့မဟုတ် operation များကို ပြုလုပ်မီ အသုံးပြုသူ၏ သဘောတူညီမှုကို ရယူရမည်။ Data များကို မျှဝေမည့်အရာနှင့် ခွင့်ပြုထားသော လုပ်ဆောင်ချက်များကို အသုံးပြုသူအနေဖြင့် ရှင်းလင်းစွာ ထိန်းချုပ်နိုင်ရမည်။  
- **Data Privacy**: အသုံးပြုသူ data များကို သဘောတူညီမှုမရှိဘဲ မဖော်ထုတ်ရ။ Access control များဖြင့် data ကို ကာကွယ်ရမည်။  
- **Tool Safety**: Tool တစ်ခုခုကို အသုံးပြုမီ အသုံးပြုသူ၏ သဘောတူညီမှုကို ရယူရမည်။ Tool ၏ လုပ်ဆောင်ချက်များကို ရှင်းလင်းစွာ နားလည်စေရန်နှင့် မလိုလားအပ်သော tool execution များကို ကာကွယ်ရန် လုံခြုံရေးအကန့်အသတ်များကို ထိန်းသိမ်းရမည်။  

### Code Examples: Key Components

#### .NET Example: Creating a Simple MCP Server with Tools
=======
- **MCP Hosts**: VSCode, Claude Desktop, IDEs, သို့မဟုတ် MCP မှတဆင့် ဒေတာဝင်ရောက်လိုသော AI ကိရိယာများ
- **MCP Clients**: Server များနှင့် 1:1 ချိတ်ဆက်မှုကို ထိန်းသိမ်းထားသော protocol clients
- **MCP Servers**: Model Context Protocol မှတဆင့် သတ်မှတ်ထားသောစွမ်းရည်များကို ဖော်ထုတ်ပေးသော lightweight programs
- **Local Data Sources**: သင့်ကွန်ပျူတာ၏ဖိုင်များ၊ ဒေတာဘေ့စ်များနှင့် MCP servers မှလုံခြုံစွာဝင်ရောက်နိုင်သောဝန်ဆောင်မှုများ
- **Remote Services**: MCP servers မှ API များမှတဆင့်ချိတ်ဆက်နိုင်သော အင်တာနက်ပေါ်ရှိ အပြင်ပစနစ်များ

MCP Protocol သည် YYYY-MM-DD format ဖြင့် versioning ပြုလုပ်ထားသော စံပြစနစ်တစ်ခုဖြစ်သည်။ လက်ရှိ protocol version သည် **2025-06-18** ဖြစ်သည်။ [protocol specification](https://modelcontextprotocol.io/specification/2025-06-18/) တွင် နောက်ဆုံးအပ်ဒိတ်များကိုကြည့်ရှုနိုင်သည်။

### 1. Hosts

Model Context Protocol (MCP) တွင် **Hosts** သည် အသုံးပြုသူများ MCP နှင့်အတူ ဆက်သွယ်နိုင်ရန် အဓိကအင်တာဖေ့စ်အဖြစ် တာဝန်ယူသော AI အပလီကေးရှင်းများဖြစ်သည်။ Hosts များသည် MCP servers များစွာနှင့် ချိတ်ဆက်မှုများကို စီမံခန့်ခွဲရန် MCP clients များကို ဖန်တီးပေးသည်။ Host များ၏ဥပမာများမှာ-

- **AI Applications**: Claude Desktop, Visual Studio Code, Claude Code
- **Development Environments**: MCP ပေါင်းစည်းထားသော IDEs နှင့် code editors  
- **Custom Applications**: ရည်ရွယ်ချက်အထူးပြု AI agents နှင့် ကိရိယာများ

**Hosts** သည် AI model interactions ကို စီမံခန့်ခွဲသော အပလီကေးရှင်းများဖြစ်သည်။ ၎င်းတို့သည်-

- **AI Models ကိုစီမံခန့်ခွဲခြင်း**: LLMs ကို အကောင်အထည်ဖော်ခြင်း သို့မဟုတ် ထိန်းချုပ်ခြင်း
- **Client Connections ကိုစီမံခြင်း**: MCP server တစ်ခုချင်းစီအတွက် MCP client တစ်ခုစီ ဖန်တီးခြင်းနှင့် ထိန်းသိမ်းခြင်း
- **User Interface ကိုထိန်းချုပ်ခြင်း**: စကားဝိုင်းစီးဆင်းမှု၊ အသုံးပြုသူအပြန်အလှန်နှင့် output ကို စီမံခြင်း  
- **လုံခြုံရေးကိုအာမခံခြင်း**: ခွင့်ပြုချက်များ၊ လုံခြုံရေးကန့်သတ်ချက်များနှင့် အတည်ပြုမှုကို ထိန်းချုပ်ခြင်း
- **အသုံးပြုသူထောက်ခံချက်ကိုစီမံခြင်း**: ဒေတာမျှဝေမှုနှင့် ကိရိယာအသုံးပြုမှုအတွက် အသုံးပြုသူ၏ထောက်ခံချက်ကို စီမံခြင်း

### 2. Clients

**Clients** သည် Hosts နှင့် MCP servers အကြား တစ်ဦးချင်းချင်းချိတ်ဆက်မှုများကို ထိန်းသိမ်းထားသော အရေးပါသောအစိတ်အပိုင်းများဖြစ်သည်။ MCP client တစ်ခုချင်းစီသည် သီးသန့် MCP server တစ်ခုနှင့်ချိတ်ဆက်ရန် Host မှဖန်တီးထားပြီး စနစ်တကျနှင့် လုံခြုံသောဆက်သွယ်မှုလမ်းကြောင်းများကို အာမခံပေးသည်။ Clients များစွာသည် Hosts များကို server များစွာနှင့် တစ်ပြိုင်နက်ချိတ်ဆက်နိုင်စေသည်။

**Clients** သည် host application အတွင်းရှိ connector components ဖြစ်သည်။ ၎င်းတို့သည်-

- **Protocol Communication**: JSON-RPC 2.0 requests များကို server များသို့ ပို့ပေးခြင်း
- **Capability Negotiation**: Initialization အတွင်း server များနှင့် supported features နှင့် protocol versions များကို ညှိနှိုင်းခြင်း
- **Tool Execution**: Model များမှ tool execution requests များကို စီမံခြင်း
- **Real-time Updates**: Server များမှ real-time updates များကို ထိန်းသိမ်းခြင်း
- **Response Processing**: Server response များကို အသုံးပြုသူများအတွက် ပြသရန် ပြင်ဆင်ခြင်း

### 3. Servers

**Servers** သည် MCP clients များကို context, tools, နှင့် capabilities ပေးစွမ်းသော အစီအစဉ်များဖြစ်သည်။ ၎င်းတို့သည် local (Host နှင့်တူသောစက်ပေါ်တွင်) သို့မဟုတ် remote (အပြင်ပလက်ဖောင်းများပေါ်တွင်) မှ အကောင်အထည်ဖော်နိုင်ပြီး client requests များကို စီမံဆောင်ရွက်ပေးသည်။ Servers များသည် Model Context Protocol မှတဆင့် သတ်မှတ်ထားသော functionality များကို ဖော်ထုတ်ပေးသည်။

**Servers** သည် context နှင့် capabilities ပေးစွမ်းသော ဝန်ဆောင်မှုများဖြစ်သည်။ ၎င်းတို့သည်-

- **Feature Registration**: Clients များအား အသုံးပြုနိုင်သော primitives (resources, prompts, tools) များကို မှတ်ပုံတင်ခြင်း
- **Request Processing**: Clients များမှ tool calls, resource requests, နှင့် prompt requests များကို လက်ခံပြီး ဆောင်ရွက်ခြင်း
- **Context Provision**: Model response များကို မြှင့်တင်ရန် context နှင့်ဒေတာများပေးခြင်း
- **State Management**: Session state ကို ထိန်းသိမ်းပြီး stateful interactions များကို စီမံခြင်း
- **Real-time Notifications**: Connected clients များအား capability changes နှင့် updates များကို အသိပေးခြင်း

Servers များကို မည်သူမဆို ဖန်တီးနိုင်ပြီး model capabilities များကို အထူးပြုစွမ်းရည်များဖြင့် တိုးချဲ့ပေးနိုင်သည်။ ၎င်းတို့သည် local နှင့် remote deployment scenarios နှစ်မျိုးလုံးကို ပံ့ပိုးပေးသည်။

### 4. Server Primitives

Model Context Protocol (MCP) တွင် Servers များသည် clients, hosts, နှင့် language models အကြား ပိုမိုချောမွေ့သောအပြန်အလှန်ဆက်သွယ်မှုများအတွက် အခြေခံအဆောက်အအုံများဖြစ်သော **primitives** သုံးမျိုးကို ပေးစွမ်းသည်။ 

MCP servers များသည် အောက်ပါ core primitives သုံးမျိုးမှ မည်သည့်ပုံစံကိုမဆို ဖော်ထုတ်နိုင်သည်-

#### Resources

**Resources** သည် AI အပလီကေးရှင်းများကို context ပေးစွမ်းသော ဒေတာအရင်းအမြစ်များဖြစ်သည်။ ၎င်းတို့သည် static သို့မဟုတ် dynamic content ကို ကိုယ်စားပြုသည်-

- **Contextual Data**: AI model များအတွက် structured information
- **Knowledge Bases**: စာရွက်စာတမ်းများ၊ ဆောင်းပါးများ၊ လက်စွဲစာအုပ်များ
- **Local Data Sources**: ဖိုင်များ၊ ဒေတာဘေ့စ်များ
- **External Data**: API responses, web services
- **Dynamic Content**: အပြင်ပအခြေအနေများအပေါ်မူတည်၍ real-time data

Resources များကို URIs ဖြင့်သတ်မှတ်ပြီး `resources/list` နှင့် `resources/read` methods များမှတဆင့် ရှာဖွေနိုင်သည်-

```text
file://documents/project-spec.md
database://production/users/schema
api://weather/current
```

#### Prompts

**Prompts** သည် language models နှင့်အတူ interactions များကို structure လုပ်ပေးသော reusable templates ဖြစ်သည်-

- **Template-based Interactions**: Pre-structured messages
- **Workflow Templates**: Standardized sequences
- **Few-shot Examples**: Example-based templates
- **System Prompts**: Model behavior ကိုသတ်မှတ်သော prompts
- **Dynamic Templates**: Specific contexts အတွက် parameterized prompts

Prompts များကို `prompts/list` နှင့် `prompts/get` methods များမှတဆင့် ရှာဖွေနိုင်သည်-

```markdown
Generate a {{task_type}} for {{product}} targeting {{audience}} with the following requirements: {{requirements}}
```

#### Tools

**Tools** သည် AI models များအနေဖြင့် သတ်မှတ်ထားသောလုပ်ဆောင်မှုများကို ဆောင်ရွက်ရန် ခေါ်ယူနိုင်သော executable functions ဖြစ်သည်-

- **Executable Functions**: သီးသန့်လုပ်ဆောင်မှုများ
- **External System Integration**: API calls, database queries
- **Unique Identity**: Tool တစ်ခုချင်းစီတွင် distinct name, description ရှိသည်
- **Structured I/O**: Validated parameters နှင့် structured responses
- **Action Capabilities**: Real-world actions ဆောင်ရွက်ရန်

Tools များကို JSON Schema ဖြင့် parameter validation ပြုလုပ်ပြီး `tools/list` နှင့် `tools/call` methods များမှတဆင့် ရှာဖွေနိုင်သည်-

```typescript
server.tool(
  "search_products", 
  {
    query: z.string().describe("Search query for products"),
    category: z.string().optional().describe("Product category filter"),
    max_results: z.number().default(10).describe("Maximum results to return")
  }, 
  async (params) => {
    // Execute search and return structured results
    return await productService.search(params);
  }
);
```

## Client Primitives

Model Context Protocol (MCP) တွင် **clients** သည် host application မှ server များအား အပိုစွမ်းရည်များကို တောင်းဆိုနိုင်စေရန် primitives များကို ဖော်ထုတ်ပေးနိုင်သည်။

### Sampling

**Sampling** သည် servers များအား client ၏ AI application မှ language model completions များကို တောင်းဆိုနိုင်စေရန် ခွင့်ပြုသည်-

- **Model-Independent Access**: LLM SDK မပါဘဲ completions တောင်းဆိုနိုင်ခြင်း
- **Server-Initiated AI**: Server များအနေဖြင့် client ၏ AI model ကို အသုံးပြု၍ content ဖန်တီးနိုင်ခြင်း
- **Recursive LLM Interactions**: Server များအနေဖြင့် AI assistance လိုအပ်သော processing များအတွက်
- **Dynamic Content Generation**: Host ၏ model ကိုအသုံးပြု၍ contextual responses ဖန်တီးခြင်း

Sampling ကို `sampling/complete` method မှတဆင့် စတင်နိုင်သည်။

### Elicitation  

**
- **Lifecycle Management**: Client နှင့် Server အကြား ချိတ်ဆက်မှု စတင်ခြင်း၊ စွမ်းရည်ညှိနှိုင်းခြင်း၊ နှင့် session ပိတ်သိမ်းခြင်းကို စီမံခန့်ခွဲသည်  
- **Server Primitives**: Server များအနေဖြင့် Tools, Resources, နှင့် Prompts များကို အသုံးပြု၍ အခြေခံလုပ်ဆောင်ချက်များပေးနိုင်စေသည်  
- **Client Primitives**: Server များအနေဖြင့် LLMs မှ Sampling တောင်းဆိုခြင်း၊ User Input ရယူခြင်း၊ နှင့် Log Messages ပို့ခြင်းတို့ကို ပြုလုပ်နိုင်စေသည်  
- **Real-time Notifications**: Polling မလိုအပ်ဘဲ အချိန်နှင့်တပြေးညီ အချက်အလက်များကို အလိုအလျောက် အသိပေးနိုင်စေသည်  

#### အဓိက အင်္ဂါရပ်များ:

- **Protocol Version Negotiation**: Compatibility အတွက် ရက်စွဲအခြေခံ (YYYY-MM-DD) versioning ကို အသုံးပြုသည်  
- **Capability Discovery**: Initialization အတွင်း Client နှင့် Server များအကြား ပံ့ပိုးနိုင်သော အင်္ဂါရပ်များကို ဖလှယ်သည်  
- **Stateful Sessions**: အကြောင်းအရာဆက်လက်တည်ရှိစေရန် အများအပြားသော အပြန်အလှန်ဆက်သွယ်မှုများအတွင်း Connection State ကို ထိန်းသိမ်းထားသည်  

### Transport Layer

**Transport Layer** သည် MCP ပါဝင်သူများအကြား ဆက်သွယ်မှု Channel များ၊ Message Framing၊ နှင့် Authentication ကို စီမံခန့်ခွဲသည်:

#### ပံ့ပိုးထားသော Transport Mechanisms:

1. **STDIO Transport**:
   - Process များအကြား တိုက်ရိုက် ဆက်သွယ်မှုအတွက် Standard Input/Output Streams ကို အသုံးပြုသည်  
   - Network Overhead မရှိဘဲ တစ်စက်ရုံအတွင်း Process များအတွက် အကောင်းဆုံးဖြစ်သည်  
   - MCP Server များကို တိုက်ရိုက် အကောင်အထည်ဖော်ရာတွင် အများဆုံးအသုံးပြုသည်  

2. **Streamable HTTP Transport**:
   - Client-to-Server Messages အတွက် HTTP POST ကို အသုံးပြုသည်  
   - Server-to-Client Streaming အတွက် Server-Sent Events (SSE) ကို ရွေးချယ်နိုင်သည်  
   - Network များအတွင်း Remote Server များနှင့် ဆက်သွယ်မှုကို ပံ့ပိုးသည်  
   - Standard HTTP Authentication (Bearer Tokens, API Keys, Custom Headers) ကို ပံ့ပိုးသည်  
   - MCP အနေဖြင့် Token-based Authentication အတွက် OAuth ကို အကြံပြုသည်  

#### Transport Abstraction:

Transport Layer သည် Data Layer မှ ဆက်သွယ်မှုအသေးစိတ်ကို ခွဲထုတ်ထားပြီး Transport Mechanisms များအားလုံးအတွက် JSON-RPC 2.0 Message Format တူညီစွာ အသုံးပြုနိုင်စေသည်။ Application များအနေဖြင့် Local နှင့် Remote Server များအကြား အလွယ်တကူ ပြောင်းလဲနိုင်စေသည်။

### Security Considerations

MCP Implementation များအနေဖြင့် Protocol Operations အားလုံးအတွင်း လုံခြုံမှု၊ ယုံကြည်မှု၊ နှင့် လုံခြုံစိတ်ချမှုကို အာမခံရန် အရေးကြီးသော လုံခြုံရေးမူဝါဒများကို လိုက်နာရမည်:

- **User Consent and Control**: Data ကို အသုံးပြုခြင်း သို့မဟုတ် လုပ်ဆောင်မှုများ ပြုလုပ်မီ User အနေဖြင့် ရှင်းလင်းသော ခွင့်ပြုချက်ပေးရမည်။ User များအနေဖြင့် Data များကို မျှဝေခြင်းနှင့် ခွင့်ပြုထားသော လုပ်ဆောင်မှုများကို ထိန်းချုပ်နိုင်ရမည်။  
- **Data Privacy**: User Data ကို ခွင့်ပြုချက်မရှိဘဲ မဖော်ထုတ်ရ။ Access Control များဖြင့် Data ကို ကာကွယ်ရမည်။  
- **Tool Safety**: Tool မည်သည့်အခါမဆို အသုံးပြုမီ User အနေဖြင့် ရှင်းလင်းသော ခွင့်ပြုချက်ပေးရမည်။ Tool များ၏ လုပ်ဆောင်နိုင်မှုကို ရှင်းလင်းစွာ နားလည်စေရန်နှင့် မလိုလားအပ်သော Tool အသုံးပြုမှုကို ကာကွယ်ရန် လုံခြုံရေးကန့်သတ်ချက်များကို ထိန်းသိမ်းရမည်။  

### Code Examples: Key Components

#### .NET Example: MCP Server တစ်ခု ဖန်တီးခြင်း
>>>>>>> origin/main

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

#### Java Example: MCP Server Components

```java
import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Weather MCP Server")
            .version("1.0.0")
            .build();
            
        // Register a weather tool
        server.registerTool(McpToolDefinition.builder("weatherTool")
            .description("Gets current weather for a location")
            .parameter("location", String.class)
            .execute((ToolExecutionContext ctx) -> {
                String location = ctx.getParameter("location", String.class);
                
                // Get weather data (simplified)
                WeatherData data = getWeatherData(location);
                
                // Return formatted response
                return ToolResponse.content(
                    String.format("Temperature: %.1f°F, Conditions: %s, Location: %s", 
                    data.getTemperature(), 
                    data.getConditions(), 
                    data.getLocation())
                );
            })
            .build());
        
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Weather MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
    
    private static WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    public WeatherData(double temperature, String conditions, String location) {
        this.temperature = temperature;
        this.conditions = conditions;
        this.location = location;
    }
    
    public double getTemperature() {
        return temperature;
    }
    
    public String getConditions() {
        return conditions;
    }
    
    public String getLocation() {
        return location;
    }
}
```

<<<<<<< HEAD
#### Python Example: Building an MCP Server
=======
#### Python Example: MCP Server တစ်ခု တည်ဆောက်ခြင်း
>>>>>>> origin/main

```python
#!/usr/bin/env python3
import asyncio
from mcp.server.fastmcp import FastMCP
from mcp.server.transports.stdio import serve_stdio

# Create a FastMCP server
mcp = FastMCP(
    name="Weather MCP Server",
    version="1.0.0"
)

@mcp.tool()
def get_weather(location: str) -> dict:
    """Gets current weather for a location."""
    # This would normally call a weather API
    # Simplified for demonstration
    return {
        "temperature": 72.5,
        "conditions": "Sunny",
        "location": location
    }

# Alternative approach using a class
class WeatherTools:
    @mcp.tool()
    def forecast(self, location: str, days: int = 1) -> dict:
        """Gets weather forecast for a location for the specified number of days."""
        # This would normally call a weather API forecast endpoint
        # Simplified for demonstration
        return {
            "location": location,
            "forecast": [
                {"day": i+1, "temperature": 70 + i, "conditions": "Partly Cloudy"}
                for i in range(days)
            ]
        }

# Instantiate the class to register its tools
weather_tools = WeatherTools()

# Start the server using stdio transport
if __name__ == "__main__":
    asyncio.run(serve_stdio(mcp))
```

<<<<<<< HEAD
#### JavaScript Example: Creating an MCP Server
=======
#### JavaScript Example: MCP Server ဖန်တီးခြင်း
>>>>>>> origin/main

```javascript
// Using the official Model Context Protocol SDK
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod"; // For parameter validation

// Create an MCP server
const server = new McpServer({
  name: "Weather MCP Server",
  version: "1.0.0"
});

// Define a weather tool
server.tool(
  "weatherTool",
  {
    location: z.string().describe("The location to get weather for")
  },
  async ({ location }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const weatherData = await getWeatherData(location);
    
    return {
      content: [
        { 
          type: "text", 
          text: `Temperature: ${weatherData.temperature}°F, Conditions: ${weatherData.conditions}, Location: ${weatherData.location}` 
        }
      ]
    };
  }
);

// Define a forecast tool
server.tool(
  "forecastTool",
  {
    location: z.string(),
    days: z.number().default(3).describe("Number of days for forecast")
  },
  async ({ location, days }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const forecast = await getForecastData(location, days);
    
    return {
      content: [
        { 
          type: "text", 
          text: `${days}-day forecast for ${location}: ${JSON.stringify(forecast)}` 
        }
      ]
    };
  }
);

// Helper functions
async function getWeatherData(location) {
  // Simulate API call
  return {
    temperature: 72.5,
    conditions: "Sunny",
    location: location
  };
}

async function getForecastData(location, days) {
  // Simulate API call
  return Array.from({ length: days }, (_, i) => ({
    day: i + 1,
    temperature: 70 + Math.floor(Math.random() * 10),
    conditions: i % 2 === 0 ? "Sunny" : "Partly Cloudy"
  }));
}

// Connect the server using stdio transport
const transport = new StdioServerTransport();
server.connect(transport).catch(console.error);

console.log("Weather MCP Server started");
```

### Security and Authorization

<<<<<<< HEAD
MCP သည် protocol အတွင်း security နှင့် authorization ကို စီမံရန် built-in concept များနှင့် mechanism များကို ပံ့ပိုးပေးသည်။

1. **Tool Permission Control**:  
   Session အတွင်း model သုံးနိုင်မည့် tool များကို client အနေဖြင့် သတ်မှတ်နိုင်သည်။  
2. **Authentication**:  
   Tool များ၊ resource များ သို့မဟုတ် sensitive operation များကို အသုံးပြုခွင့်ပေးမီ authentication လိုအပ်သည်။  
3. **Validation**:  
   Tool invocation များအတွက် parameter validation ကို enforce လုပ်သည်။  
4. **Rate Limiting**:  
   Server resource များကို fair usage အတွက် rate limiting ကို အသုံးပြုနိုင်သည်။  

### Protocol Messages & Communication Flow

MCP သည် **JSON-RPC 2.0** message များကို အသုံးပြု၍ host, client နှင့် server များအကြား ရှင်းလင်းပြီး ယုံကြည်ရသော ဆက်သွယ်မှုများကို အကောင်အထည်ဖော်သည်။
=======
MCP သည် Security နှင့် Authorization ကို စီမံရန် အတွက် အဓိက Mechanisms များပါဝင်သည်:

1. **Tool Permission Control**:  
   Session အတွင်း Model သုံးနိုင်သော Tools များကို Client အနေဖြင့် သတ်မှတ်နိုင်သည်။  
2. **Authentication**:  
   Tools, Resources, သို့မဟုတ် Sensitive Operations များကို အသုံးပြုခွင့်ပေးမီ Authentication လိုအပ်သည်။  
3. **Validation**:  
   Tool Invocation များအတွက် Parameter Validation ကို Server အနေဖြင့် ပြုလုပ်သည်။  
4. **Rate Limiting**:  
   Server Resources များကို မတရားအသုံးပြုမှုကို ကာကွယ်ရန် Rate Limiting ကို အသုံးပြုသည်။  

### Protocol Messages & Communication Flow

MCP သည် **JSON-RPC 2.0** Messages ကို အသုံးပြု၍ Host, Client, နှင့် Server များအကြား ပြေပြစ်သော ဆက်သွယ်မှုကို အကောင်အထည်ဖော်သည်။
>>>>>>> origin/main

#### Core Message Types:

- **Initialization Messages**  
- **Discovery Messages**  
- **Execution Messages**  
- **Client-side Messages**  
- **Notification Messages**  

### Key Takeaways

<<<<<<< HEAD
- **Architecture**: MCP သည် client-server architecture ကို အသုံးပြုသည်  
- **Participants**: Host, client, server များပါဝင်သည်  
- **Transport Mechanisms**: STDIO (local) နှင့် Streamable HTTP (remote) ကို ပံ့ပိုးသည်  
- **Core Primitives**: Tool, resource, prompt များကို server မှ expose လုပ်သည်  
- **Client Primitives**: Sampling, elicitation, logging request များကို server မှ client ကို ပြုလုပ်နိုင်သည်  
- **Protocol Foundation**: JSON-RPC 2.0 ကို အခြေခံပြီး date-based versioning ကို အသုံးပြုသည်  
- **Real-time Capabilities**: Notifications များကို dynamic updates အတွက် ပံ့ပိုးသည်  
- **Security First**: User consent, data privacy, secure transport များကို အရေးပါသော အခြေခံလိုအပ်ချက်အဖြစ် သတ်မှတ်ထားသည်  

### Exercise

သင့် domain အတွက် အသုံးဝင်မည့် MCP tool တစ်ခုကို ဒီဇိုင်းဆွဲပါ။  
1. Tool အမည်  
2. Accept လုပ်မည့် parameter များ  
3. Return ပြန်ပေးမည့် output  
4. Model အနေဖြင့် user problem များကို ဖြေရှင်းရန် tool ကို ဘယ်လိုအသုံးပြုမည်  

---

### What's next
=======
- **Architecture**: MCP သည် Client-Server Architecture ကို အသုံးပြုသည်  
- **Participants**: Host, Client, Server များပါဝင်သည်  
- **Transport Mechanisms**: STDIO နှင့် Streamable HTTP ကို ပံ့ပိုးသည်  
- **Core Primitives**: Tools, Resources, Prompts များကို Server မှ ပေးသည်  
- **Client Primitives**: Sampling, Elicitation, Logging ကို Server မှ Client ကို တောင်းဆိုနိုင်သည်  
- **Protocol Foundation**: JSON-RPC 2.0 နှင့် Date-based Versioning ကို အခြေခံသည်  
- **Real-time Capabilities**: Notifications ကို ပံ့ပိုးသည်  
- **Security First**: User Consent, Data Privacy, နှင့် Secure Transport ကို အရေးပါသည်  

## Exercise

သင့်လုပ်ငန်းနယ်ပယ်အတွက် အသုံးဝင်မည့် MCP Tool တစ်ခုကို ဒီဇိုင်းဆွဲပါ။  
1. Tool အမည်  
2. Accept လုပ်မည့် Parameters  
3. Return ပြန်မည့် Output  
4. Model အနေဖြင့် User Problems ကို ဖြေရှင်းရန် Tool ကို ဘယ်လိုအသုံးပြုမည်  

---

## What's next
>>>>>>> origin/main

Next: [Chapter 2: Security](../02-Security/README.md)

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
<<<<<<< HEAD
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ဆိုမှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို ကျေးဇူးပြု၍ သိရှိထားပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်ရန် လိုအပ်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူပညာရှင်များမှ လက်တွေ့ဘာသာပြန်ဆိုမှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်ဆိုမှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပါယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
=======
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူပညာရှင်များမှ ပြုလုပ်သည့် လူ့ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသည့် နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပာယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
>>>>>>> origin/main
