<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1c767a35642f753127dc08545c25a290",
  "translation_date": "2025-08-18T23:25:31+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "my"
}
-->
# MCP လုံခြုံရေး: AI စနစ်များအတွက် အပြည့်အစုံကာကွယ်မှု

[![MCP လုံခြုံရေးအကောင်းဆုံးအကြံပြုချက်များ](../../../translated_images/03.175aed6dedae133f9d41e49cefd0f0a9a39c3317e1eaa7ef7182696af7534308.my.png)](https://youtu.be/88No8pw706o)

_(ဤသင်ခန်းစာ၏ ဗီဒီယိုကို ကြည့်ရန် အထက်ပါပုံကို နှိပ်ပါ)_

AI စနစ်ဒီဇိုင်းတွင် လုံခြုံရေးသည် အခြေခံအချက်တစ်ခုဖြစ်ပြီး၊ ထို့ကြောင့် ကျွန်ုပ်တို့သည် ဒုတိယပိုင်းအဖြစ် ဦးစားပေးထားပါသည်။ ၎င်းသည် Microsoft ၏ **Secure by Design** မူဝါဒနှင့် [Secure Future Initiative](https://www.microsoft.com/security/blog/2025/04/17/microsofts-secure-by-design-journey-one-year-of-success/) မှ အညီဖြစ်သည်။

Model Context Protocol (MCP) သည် AI အခြေပြု အက်ပ်များအတွက် အင်အားကြီးသော စွမ်းရည်အသစ်များကို ပေးစွမ်းသော်လည်း၊ ရိုးရာဆော့ဖ်ဝဲလ်အန္တရာယ်များထက် ကျော်လွန်သော ထူးခြားသော လုံခြုံရေးစိန်ခေါ်မှုများကို ဖြစ်ပေါ်စေသည်။ MCP စနစ်များသည် ရိုးရာလုံခြုံရေးစိုးရိမ်မှုများ (လုံခြုံသော ကုဒ်ရေးသားမှု၊ အနည်းဆုံးအခွင့်အာဏာ၊ ထောက်ပံ့မှုကွင်းဆက်လုံခြုံရေး) နှင့် AI သီးသန့် အန္တရာယ်အသစ်များ (prompt injection, tool poisoning, session hijacking, confused deputy attacks, token passthrough vulnerabilities, dynamic capability modification) တို့ကို ရင်ဆိုင်ကြုံတွေ့ရသည်။

ဤသင်ခန်းစာတွင် MCP အကောင်အထည်ဖော်မှုများတွင် အရေးကြီးဆုံး လုံခြုံရေးအန္တရာယ်များကို လေ့လာမည်ဖြစ်ပြီး၊ authentication, authorization, excessive permissions, indirect prompt injection, session security, confused deputy problems, token management, supply chain vulnerabilities စသည့် အချက်များကို ဖော်ပြမည်ဖြစ်သည်။ Microsoft ၏ Prompt Shields, Azure Content Safety, GitHub Advanced Security စနစ်များကို အသုံးပြု၍ MCP ကို ပိုမိုခိုင်မာစေရန် အကောင်းဆုံးအကြံပြုချက်များနှင့် ထိရောက်သော ထိန်းချုပ်မှုများကို သင်လေ့လာနိုင်မည်ဖြစ်သည်။

## သင်ခန်းစာရည်မှန်းချက်များ

ဤသင်ခန်းစာအဆုံးတွင် သင်သည် အောက်ပါအချက်များကို နားလည်နိုင်မည်ဖြစ်သည်-

- **MCP သီးသန့် အန္တရာယ်များကို ဖော်ထုတ်ခြင်း**: MCP စနစ်များတွင် prompt injection, tool poisoning, excessive permissions, session hijacking, confused deputy problems, token passthrough vulnerabilities, supply chain risks စသည့် ထူးခြားသော လုံခြုံရေးအန္တရာယ်များကို သိရှိနိုင်ရန်
- **လုံခြုံရေးထိန်းချုပ်မှုများကို အသုံးချခြင်း**: authentication ခိုင်မာမှု၊ အနည်းဆုံးအခွင့်အာဏာဝင်ခွင့်၊ token စီမံခန့်ခွဲမှု၊ session လုံခြုံရေးထိန်းချုပ်မှုများနှင့် supply chain စစ်ဆေးမှုများကို ထိရောက်စွာ အကောင်အထည်ဖော်နိုင်ရန်
- **Microsoft လုံခြုံရေးဖြေရှင်းချက်များကို အသုံးပြုခြင်း**: Microsoft Prompt Shields, Azure Content Safety, GitHub Advanced Security စနစ်များကို MCP လုပ်ငန်းခွင်များအတွက် အသုံးချနိုင်ရန်
- **Tool လုံခြုံရေးကို အတည်ပြုခြင်း**: tool metadata စစ်ဆေးမှု၏ အရေးပါမှုကို နားလည်ပြီး၊ dynamic changes များကို စောင့်ကြည့်ခြင်းနှင့် indirect prompt injection အန္တရာယ်များကို ကာကွယ်နိုင်ရန်
- **အကောင်းဆုံးအကြံပြုချက်များကို ပေါင်းစည်းခြင်း**: လုံခြုံသော ကုဒ်ရေးသားမှု၊ server hardening, zero trust စသည့် ရိုးရာလုံခြုံရေးအခြေခံချက်များနှင့် MCP သီးသန့်ထိန်းချုပ်မှုများကို ပေါင်းစည်း၍ အပြည့်အစုံကာကွယ်မှုရရှိစေရန်

# MCP လုံခြုံရေးဖွဲ့စည်းမှုနှင့် ထိန်းချုပ်မှုများ

ခေတ်သစ် MCP အကောင်အထည်ဖော်မှုများသည် ရိုးရာဆော့ဖ်ဝဲလ်လုံခြုံရေးနှင့် AI သီးသန့်အန္တရာယ်များကို ရင်ဆိုင်နိုင်ရန် အလွှာလိုက်လုံခြုံရေးနည်းလမ်းများလိုအပ်သည်။ MCP သတ်မှတ်ချက်သည် အလျင်အမြန် တိုးတက်နေပြီး၊ လုံခြုံရေးထိန်းချုပ်မှုများကို ပိုမိုကောင်းမွန်စေရန် စဉ်ဆက်မပြတ် ဖွံ့ဖြိုးနေသည်။

[Microsoft Digital Defense Report](https://aka.ms/mddr) မှ သုတေသနအရ **သတင်းပေးအချက်များ၏ ၉၈% ကို ခိုင်မာသော လုံခြုံရေးအခြေခံချက်များဖြင့် ကာကွယ်နိုင်သည်** ဟု ဖော်ပြထားသည်။ အကျိုးရှိစွာ ကာကွယ်နိုင်ရန် အကောင်းဆုံးနည်းလမ်းမှာ MCP သီးသန့်ထိန်းချုပ်မှုများနှင့် အခြေခံလုံခြုံရေးအခြေခံချက်များကို ပေါင်းစည်းခြင်းဖြစ်သည်။

## လက်ရှိ လုံခြုံရေးအခြေအနေ

> **Note:** ဤအချက်အလက်များသည် **၂၀၂၅ ခုနှစ် ဩဂုတ်လ ၁၈ ရက်** အခြေအနေအရ MCP လုံခြုံရေးစံနှုန်းများကို အခြေခံထားသည်။ MCP သတ်မှတ်ချက်သည် အလျင်အမြန် တိုးတက်နေပြီး၊ အနာဂတ်အကောင်အထည်ဖော်မှုများတွင် authentication ပုံစံအသစ်များနှင့် ထိန်းချုပ်မှုများ ပါဝင်လာနိုင်သည်။ နောက်ဆုံးအချက်အလက်များအတွက် [MCP Specification](https://spec.modelcontextprotocol.io/), [MCP GitHub repository](https://github.com/modelcontextprotocol), [security best practices documentation](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) တို့ကို အမြဲကြည့်ရှုပါ။

### MCP Authentication ၏ တိုးတက်မှု

MCP သတ်မှတ်ချက်သည် authentication နှင့် authorization အပေါ် အလွန်အမင်း တိုးတက်မှုများ ပြုလုပ်ခဲ့သည်-

- **မူလနည်းလမ်း**: စတင်သတ်မှတ်ချက်များတွင် developer များကို custom authentication servers တည်ဆောက်ရန် လိုအပ်ခဲ့ပြီး၊ MCP servers များသည် OAuth 2.0 Authorization Servers အဖြစ် တိုက်ရိုက် အသုံးပြုသူ authentication ကို စီမံခန့်ခွဲခဲ့သည်
- **လက်ရှိစံနှုန်း (၂၀၂၅-၀၆-၁၈)**: အသစ်ပြင်ဆင်ထားသော သတ်မှတ်ချက်သည် MCP servers များကို Microsoft Entra ID ကဲ့သို့သော အပြင်ပန်း identity providers များသို့ authentication ကို လွှဲပြောင်းခွင့်ပြုသည်
- **Transport Layer Security**: လိုကယ် (STDIO) နှင့် remote (Streamable HTTP) ချိတ်ဆက်မှုများအတွက် လုံခြုံသော transport mechanism များကို ပိုမိုကောင်းမွန်စွာ ထောက်ပံ့သည်

## Authentication & Authorization လုံခြုံရေး

### လက်ရှိ လုံခြုံရေးစိန်ခေါ်မှုများ

ခေတ်သစ် MCP အကောင်အထည်ဖော်မှုများသည် authentication နှင့် authorization အပေါ် အမျိုးမျိုးသော စိန်ခေါ်မှုများကို ရင်ဆိုင်ရသည်-

### အန္တရာယ်များနှင့် ခြိမ်းခြောက်မှုများ

- **Authorization Logic မှားယွင်းမှု**: MCP servers တွင် authorization ကို မှားယွင်းစွာ အကောင်အထည်ဖော်ခြင်းကြောင့် အရေးကြီးသော ဒေတာများ ထိခိုက်နိုင်ခြင်း
- **OAuth Token ခိုးယူမှု**: MCP server token များ ခိုးယူခြင်းဖြင့် တရားမဝင်သူများသည် server များကို အတုလုပ်၍ downstream services များကို ဝင်ရောက်နိုင်ခြင်း
- **Token Passthrough အန္တရာယ်များ**: token ကို မှားယွင်းစွာ စီမံခန့်ခွဲခြင်းကြောင့် လုံခြုံရေးထိန်းချုပ်မှုများကို ကျော်ဖြတ်နိုင်ခြင်း
- **Excessive Permissions**: MCP servers များတွင် အလွန်အကျွံသော အခွင့်အာဏာများရှိခြင်းကြောင့် အန္တရာယ်များ ပိုမိုဖြစ်ပေါ်စေခြင်း

#### Token Passthrough: အရေးကြီးသော Anti-Pattern

**Token passthrough ကို လက်ရှိ MCP authorization သတ်မှတ်ချက်တွင် တင်းတင်းကြပ်ကြပ် တားမြစ်ထားသည်**၊ အကြောင်းမှာ ၎င်းသည် အလွန်ဆိုးရွားသော လုံခြုံရေးအကျိုးဆက်များ ဖြစ်ပေါ်စေနိုင်သောကြောင့်ဖြစ်သည်-

##### လုံခြုံရေးထိန်းချုပ်မှုများကို ကျော်ဖြတ်ခြင်း
- MCP servers နှင့် downstream APIs များသည် token စစ်ဆေးမှုအပေါ် မူတည်သော အရေးကြီးသော လုံခြုံရေးထိန်းချုပ်မှုများ (rate limiting, request validation, traffic monitoring) ကို အကောင်အထည်ဖော်ထားသည်
- token ကို တိုက်ရိုက် client-to-API အသုံးပြုခြင်းသည် ထိုထိန်းချုပ်မှုများကို ကျော်ဖြတ်စေပြီး၊ လုံခြုံရေးဖွဲ့စည်းမှုကို ထိခိုက်စေသည်

##### Accountability & Audit စိန်ခေါ်မှုများ  
- MCP servers များသည် upstream-issued tokens ကို အသုံးပြုသော clients များကို ခွဲခြားနိုင်ခြင်းမရှိတော့ပါ
- Downstream resource server logs များတွင် တရားဝင် MCP server များအစား client များကို ပြသထားသည်
- Incident စုံစမ်းမှုနှင့် လိုက်နာမှု စစ်ဆေးမှုများကို ပိုမိုခက်ခဲစေသည်

##### Data Exfiltration အန္တရာယ်များ
- token claims မစစ်ဆေးဘဲ ခွင့်ပြုခြင်းကြောင့် token ခိုးယူသူများသည် MCP servers များကို proxy အဖြစ် အသုံးပြု၍ ဒေတာများကို ခိုးယူနိုင်သည်
- Trust boundary များကို ချိုးဖောက်ခြင်းကြောင့် မရည်ရွယ်ထားသော လုံခြုံရေးထိန်းချုပ်မှုများကို ကျော်ဖြတ်နိုင်သည်

##### Multi-Service ခြိမ်းခြောက်မှုများ
- တရားမဝင် token များကို ဝန်ဆောင်မှုများစွာတွင် လက်ခံခြင်းကြောင့် ချိတ်ဆက်ထားသော စနစ်များအတွင်း လွယ်ကူစွာ ရွှေ့ပြောင်းနိုင်သည်
- token မူလများကို အတည်ပြုနိုင်ခြင်းမရှိသောအခါ ဝန်ဆောင်မှုများအကြား ယုံကြည်မှုအခြေခံချက်များကို ချိုးဖောက်နိုင်သည်

### လုံခြုံရေးထိန်းချုပ်မှုများနှင့် ကာကွယ်မှုများ

**အရေးကြီးသော လုံခြုံရေးလိုအပ်ချက်များ:**

> **MANDATORY**: MCP servers များသည် **MUST NOT** MCP server အတွက် ထုတ်ပေးထားခြင်းမဟုတ်သော tokens များကို လက်ခံသင့်ပါ

#### Authentication & Authorization ထိန်းချုပ်မှုများ

- **Authorization Logic စစ်ဆေးမှု**: MCP server authorization logic ကို စစ်တမ်းပြုလုပ်၍ သတ်မှတ်ထားသော အသုံးပြုသူများနှင့် clients များသာ sensitive resources များကို ဝင်ရောက်နိုင်စေရန် သေချာစေရန်
  - **Implementation Guide**: [Azure API Management as Authentication Gateway for MCP Servers](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
  - **Identity Integration**: [Using Microsoft Entra ID for MCP Server Authentication](https://den.dev/blog/mcp-server-auth-entra-id-session/)

- **Token စီမံခန့်ခွဲမှုကို လုံခြုံစွာ ပြုလုပ်ခြင်း**: [Microsoft ၏ token စစ်ဆေးမှုနှင့် lifecycle အကောင်းဆုံးအကြံပြုချက်များ](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) ကို အသုံးပြုပါ
  - token audience claims များ MCP server identity နှင့် ကိုက်ညီမှုရှိကြောင်း စစ်ဆေးပါ
  - token rotation နှင့် expiration မူဝါဒများကို အကောင်အထည်ဖော်ပါ
  - token replay attacks နှင့် unauthorized usage များကို ကာကွယ်ပါ

- **Token ကို လုံခြုံစွာ သိမ်းဆည်းခြင်း**: token များကို rest နှင့် transit နှစ်ခုလုံးတွင် စာဝှက်ထားသော အခြေအနေဖြင့် သိမ်းဆည်းပါ
  - **အကောင်းဆုံးအကြံပြုချက်များ**: [Secure Token Storage and Encryption Guidelines](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

#### Access Control အကောင်အထည်ဖော်မှု

- **အနည်းဆုံးအခွင့်အာဏာ၏ မူဝါဒ**: MCP servers များကို လိုအပ်သော အနည်းဆုံးအခွင့်အာဏာများသာ ခွင့်ပြုပါ
  - အခွင့်အာဏာများကို ပုံမှန်စစ်ဆေးပြီး၊ privilege creep များကို ကာကွယ်ပါ
  - **Microsoft Documentation**: [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)

- **Role-Based Access Control (RBAC)**: အခွင့်အာဏာများကို အသေးစိတ် သတ်မှတ်ပါ
  - roles များကို သီးသန့် resource များနှင့် လုပ်ဆောင်မှုများအတွက်သာ သတ်မှတ်ပါ
  - အကျယ်အဝန်းမရှိသော အခွင့်အာဏာများကို ရှောင်ရှားပါ

- **Permission များကို ဆက်လက်စောင့်ကြည့်ခြင်း**: အခွင့်အာဏာအသုံးပြုမှု ပုံစံများကို စောင့်ကြည့်ပြီး၊ မူမမှန်သော လုပ်ဆောင်မှုများကို စောင့်ကြည့်ပါ
  - အလွန်အကျွံသော သို့မဟုတ် အသုံးမပြုသော အခွင့်အာဏာများကို ချက်ချင်း ပြုပြင်ပါ

## AI သီးသန့် လုံခြုံရေးအန္တရာယ်များ

### Prompt Injection & Tool Manipulation တိုက်ခိုက်မှုများ

ခေတ်သစ် MCP အကောင်အထည်ဖော်မှုများသည် ရိုးရာလုံခြုံရေးနည်းလမ်းများဖြင့် အပြည့်အဝ ကာကွယ်နိုင်မည့်အထက်ကျသော AI သီးသန့် တိုက်ခိုက်မှုများကို ရင်ဆိုင်ရသည်-

#### **Indirect Prompt Injection (Cross-Domain Prompt Injection)**

**Indirect Prompt Injection** သည် MCP အခြေပြု AI စနစ်များတွင် အရေးကြီးဆုံး အန္တရာယ်တစ်ခုဖြစ်သည်။ ၎င်းသည် တရားမဝင်သူများက AI စနစ်များမှ တရားဝင်အမိန့်များအဖြစ် လက်ခံသည့် အပြင်ပန်းအကြောင်းအရာများ (စာရွက်စာတမ်းများ၊ ဝက်ဘ်စာမျက်နှာများ၊ အီးမေးလ်များ သို့မဟုတ် ဒေတာရင်းမြစ်များ) အတွင်း မကောင်းဆိုးဝါးအမိန့်များကို ထည့်သွင်းခြင်းဖြစ်သည်။

**တိုက်ခိုက်မှုအခြေအနေများ:**
- **စာရွက်စာတမ်းအခြေပြု Injection**: AI ၏ မရည်ရွယ်ထားသော လုပ်ဆောင်မှုများကို ဖြစ်ပေါ်စေသော မကောင်းဆိုးဝါးအမိန့်များကို စာရွက်စာတမ်းများတွင် ဖုံးကွယ်ထားခြင်း
- **ဝက်ဘ်အကြောင်းအရာ ခြိမ်းခြောက်မှု**: AI ၏ အပြုအမူကို ထိန်းချုပ်နိုင်သော prompt များကို ထည့်သွင်းထားသော ဝက်ဘ်စာမျက်နှာများ
- **အီးမေးလ်အခြေပြု တိုက်ခိုက်မှုများ**: AI assistant များကို ဒေတာပေါက်ကြားမှု သို့မဟုတ် တရားမဝင်လုပ်ဆောင်မှုများ ပြုလုပ်စေသော မကောင်းဆိုးဝါး prompt များကို အီးမေးလ်များတွင် ထည့်သွင်းခြင်း
- **ဒေတာရင်း
- **လုံခြုံသော Session ဖန်တီးမှု**: လုံခြုံမှုအဆင့်မြင့်သော၊ မဟုတ်မမှန်သော session ID များကို လုံခြုံသော အမှတ်စဉ်ထုတ်လုပ်စက်များဖြင့် ဖန်တီးပါ  
- **အသုံးပြုသူနှင့် သက်ဆိုင်မှုချိတ်ဆက်မှု**: Session ID များကို အသုံးပြုသူနှင့် သက်ဆိုင်သော အချက်အလက်များနှင့် ချိတ်ဆက်ထားပါ၊ ဥပမာ `<user_id>:<session_id>` ပုံစံကို အသုံးပြု၍ အသုံးပြုသူများအကြား session အလွဲသုံးမှုကို ကာကွယ်ပါ  
- **Session အသက်ရှင်မှုစီမံခန့်ခွဲမှု**: အချိန်ကုန်ဆုံးမှု၊ ပြောင်းလဲမှုနှင့် ပယ်ဖျက်မှုများကို မှန်ကန်စွာ အကောင်အထည်ဖော်ပါ၊ ထို့ကြောင့် အန္တရာယ်အချိန်ကာလများကို ကန့်သတ်နိုင်ပါမည်  
- **သယ်ဆောင်မှုလုံခြုံမှု**: Session ID များကို ဖမ်းယူမှုမှ ကာကွယ်ရန် အဆက်အသွယ်အားလုံးအတွက် HTTPS ကို မဖြစ်မနေ အသုံးပြုပါ  

### Confused Deputy ပြဿနာ

**Confused deputy ပြဿနာ** သည် MCP server များသည် client များနှင့် third-party ဝန်ဆောင်မှုများအကြား authentication proxy အဖြစ် လုပ်ဆောင်သောအခါ ဖြစ်ပေါ်နိုင်ပြီး၊ static client ID များကို အလွဲသုံးမှုဖြင့် authorization bypass အခွင့်အလမ်းများ ဖန်တီးပေးနိုင်သည်။

#### **တိုက်ခိုက်မှုစနစ်နှင့် အန္တရာယ်များ**

- **Cookie-based ခွင့်ပြုချက်လွှဲပြောင်းမှု**: ယခင်အသုံးပြုသူ authentication မှ ဖန်တီးထားသော consent cookie များကို အတု authorization request များနှင့် malicious redirect URI များဖြင့် အန္တရာယ်ရှိသူများက အလွဲသုံးနိုင်သည်  
- **Authorization Code ခိုးယူမှု**: ရှိပြီးသား consent cookie များကြောင့် authorization server များသည် consent screen များကို ကျော်ဖြတ်ပြီး၊ code များကို အန္တရာယ်ရှိသူထိန်းချုပ်ထားသော endpoint များသို့ redirect လုပ်နိုင်သည်  
- **API ခွင့်မပြုသော အသုံးပြုမှု**: ခိုးယူထားသော authorization code များသည် token များကို လဲလှယ်ရန်နှင့် အသုံးပြုသူကို ခွင့်ပြုချက်မရှိဘဲ အတုလုပ်ရန် ခွင့်ပြုနိုင်သည်  

#### **ကာကွယ်ရေးမူဝါဒများ**

**မဖြစ်မနေလိုအပ်သော ထိန်းချုပ်မှုများ**:
- **ထင်ရှားသော ခွင့်ပြုချက်လိုအပ်ချက်များ**: Static client ID များကို အသုံးပြုသော MCP proxy server များသည် dynamic client တစ်ခုစီအတွက် အသုံးပြုသူ၏ ခွင့်ပြုချက်ကို မဖြစ်မနေ ရယူရမည်  
- **OAuth 2.1 လုံခြုံမှုအကောင်အထည်ဖော်မှု**: PKCE (Proof Key for Code Exchange) အပါအဝင် လက်ရှိ OAuth လုံခြုံမှုအကောင်းဆုံးအတတ်ပညာများကို authorization request အားလုံးအတွက် လိုက်နာပါ  
- **Client စစ်ဆေးမှုတင်းကြပ်မှု**: Redirect URI များနှင့် client identifier များကို အတည်ပြုရန် တင်းကြပ်သော စစ်ဆေးမှုများကို အကောင်အထည်ဖော်ပါ  

### Token Passthrough အားနည်းချက်များ  

**Token passthrough** သည် MCP server များက client token များကို မှန်ကန်စွာ စစ်ဆေးမှုမရှိဘဲ လက်ခံပြီး၊ ထို token များကို downstream API များသို့ ပို့ပေးသော anti-pattern တစ်ခုဖြစ်ပြီး၊ MCP authorization သတ်မှတ်ချက်များကို ချိုးဖောက်သည်။

#### **လုံခြုံမှုဆိုင်ရာ အကျိုးသက်ရောက်မှုများ**

- **ထိန်းချုပ်မှုလွှဲပြောင်းမှု**: Client-to-API token အသုံးပြုမှုသည် အရေးကြီးသော rate limiting၊ validation နှင့် monitoring ထိန်းချုပ်မှုများကို ကျော်ဖြတ်စေသည်  
- **Audit Trail ပျက်စီးမှု**: Upstream-issued token များကြောင့် client ကို ဖော်ထုတ်ရန် မဖြစ်နိုင်တော့ဘဲ၊ အမှုဖြစ်စဉ်စစ်ဆေးမှုများကို ခက်ခဲစေသည်  
- **Proxy အခြေခံသော ဒေတာခိုးယူမှု**: Unvalidated token များကြောင့် အန္တရာယ်ရှိသူများသည် unauthorized data access အတွက် server များကို proxy အဖြစ် အသုံးပြုနိုင်သည်  
- **ယုံကြည်မှုနယ်နိမိတ်ချိုးဖောက်မှု**: Token မူလများကို အတည်ပြု၍ မရသောအခါ Downstream service များ၏ ယုံကြည်မှုအခြေခံချက်များကို ချိုးဖောက်နိုင်သည်  
- **Multi-service တိုက်ခိုက်မှု တိုးချဲ့မှု**: Compromised token များကို ဝန်ဆောင်မှုများစွာတွင် လက်ခံခြင်းကြောင့် lateral movement ဖြစ်ပေါ်စေသည်  

#### **လိုအပ်သော လုံခြုံမှုထိန်းချုပ်မှုများ**

**မလျော့နည်းရမည့် လိုအပ်ချက်များ**:
- **Token စစ်ဆေးမှု**: MCP server များသည် MCP server အတွက် ထုတ်ပေးထားခြင်း မရှိသော token များကို လက်ခံ **မရ**  
- **Audience အတည်ပြုမှု**: Token audience claim များသည် MCP server ၏ identity နှင့် ကိုက်ညီမှုရှိကြောင်း အမြဲစစ်ဆေးပါ  
- **Token အသက်ရှင်မှုမှန်ကန်မှု**: အချိန်တိုအတွင်း သက်တမ်းကုန်ဆုံးသော access token များနှင့် လုံခြုံသော rotation လုပ်ငန်းစဉ်များကို အကောင်အထည်ဖော်ပါ  


### **Microsoft Security Solutions**
- [Microsoft Prompt Shields Documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety Service](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Microsoft Entra ID Security](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Azure Token Management Best Practices](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [GitHub Advanced Security](https://github.com/security/advanced-security)

### **Implementation Guides & Tutorials**
- [Azure API Management as MCP Authentication Gateway](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Microsoft Entra ID Authentication with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Secure Token Storage and Encryption (Video)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### **DevOps & Supply Chain Security**
- [Azure DevOps Security](https://azure.microsoft.com/products/devops)
- [Azure Repos Security](https://azure.microsoft.com/products/devops/repos/)
- [Microsoft Supply Chain Security Journey](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)

## **အပိုဆောင်းလုံခြုံရေးစာရွက်စာတမ်းများ**

လုံခြုံရေးဆိုင်ရာလမ်းညွှန်ချက်များကို အပြည့်အစုံလေ့လာရန် ဒီအပိုင်းထဲမှာပါဝင်တဲ့ အထူးစာရွက်စာတမ်းများကို ကိုးကားပါ။

- **[MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md)** - MCP အကောင်အထည်ဖော်မှုများအတွက် လုံခြုံရေးအကောင်းဆုံးလေ့ကျင့်မှုများ
- **[Azure Content Safety Implementation](./azure-content-safety-implementation.md)** - Azure Content Safety ကို ပေါင်းစပ်အသုံးပြုမှုဆိုင်ရာ လက်တွေ့နမူနာများ  
- **[MCP Security Controls 2025](./mcp-security-controls-2025.md)** - MCP အကောင်အထည်ဖော်မှုများအတွက် နောက်ဆုံးပေါ်လုံခြုံရေးထိန်းချုပ်မှုများနှင့်နည်းလမ်းများ
- **[MCP Best Practices Quick Reference](./mcp-best-practices.md)** - MCP လုံခြုံရေးအရေးပါသောလေ့ကျင့်မှုများအတွက် အမြန်ကိုးကားလမ်းညွှန်

---

## အခုနောက်တစ်ခု

နောက်တစ်ခု: [အခန်း ၃: စတင်အသုံးပြုခြင်း](../03-GettingStarted/README.md)

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအမှားများ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။