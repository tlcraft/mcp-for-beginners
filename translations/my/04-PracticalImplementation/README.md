<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T23:02:07+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "my"
}
-->
# လက်တွေ့အကောင်အထည်ဖော်ခြင်း

လက်တွေ့အကောင်အထည်ဖော်ခြင်းမှာ Model Context Protocol (MCP) ၏ အင်အားကို တကယ်ထင်ဟပ်စေတဲ့ အဆင့်ဖြစ်ပါတယ်။ MCP ၏ သီအိုရီနဲ့ ဖွဲ့စည်းပုံကို နားလည်ခြင်းက အရေးကြီးပေမယ့်၊ အမှန်တကယ်တန်ဖိုးရှိတာကတော့ ဒီအယူအဆတွေကို အသုံးပြုပြီး အမှန်တကယ်ဖြေရှင်းနိုင်တဲ့ ဖြေရှင်းချက်တွေကို တည်ဆောက်၊ စမ်းသပ်၊ ထုတ်လုပ်တဲ့အခါမှာ ဖြစ်ပါတယ်။ ဒီအခန်းက သဘောတရားနဲ့ လက်တွေ့ဖွံ့ဖြိုးတိုးတက်မှုကြားက အကွာအဝေးကို ဖြတ်သန်းပေးပြီး MCP အခြေပြု အက်ပလီကေးရှင်းတွေကို ဘယ်လိုအသက်သွင်းရမလဲဆိုတာ လမ်းညွှန်ပေးမှာ ဖြစ်ပါတယ်။

သင်ဟာ အတတ်ပညာရှင် အကူအညီပေးသူတွေ ဖန်တီးနေပါစေ၊ စီးပွားရေးလုပ်ငန်းစဉ်တွေထဲ AI ကို ပေါင်းစပ်နေပါစေ၊ ဒေတာကို ပြုလုပ်ဖို့ အထူးကိရိယာတွေ တည်ဆောက်နေပါစေ MCP က အလွယ်တကူ အသုံးပြုနိုင်တဲ့ အခြေခံအဆောက်အအုံကို ပေးထားပါတယ်။ MCP ၏ ဘာသာစကားမရွေး ဒီဇိုင်းနဲ့ လူကြိုက်များတဲ့ programming ဘာသာစကားများအတွက် တရားဝင် SDK များကြောင့် အမျိုးမျိုးသော developer များအတွက် လွယ်ကူစွာ အသုံးပြုနိုင်ပါတယ်။ ဒီ SDK များကို အသုံးပြုပြီး သင်ဟာ မျိုးစုံသော ပလက်ဖောင်းနဲ့ ပတ်ဝန်းကျင်များမှာ မျှတစွာ prototype ဖန်တီး၊ ပြန်လည်ပြင်ဆင်၊ တိုးချဲ့နိုင်ပါလိမ့်မယ်။

နောက်ထပ်အပိုင်းများမှာ MCP ကို C#, Java, TypeScript, JavaScript, Python တို့တွင် ဘယ်လို အကောင်အထည်ဖော်ရမလဲဆိုတာကို လက်တွေ့ ဥပမာများ၊ နမူနာကုဒ်များနဲ့ ထုတ်လုပ်မှုနည်းလမ်းများဖြင့် ဖော်ပြထားပါတယ်။ MCP server များကို ဘယ်လို debug နဲ့ စမ်းသပ်ရမလဲ၊ API များကို ဘယ်လို စီမံခန့်ခွဲရမလဲ၊ Azure ကို အသုံးပြုပြီး ဖြန့်ချိနည်းများကိုလည်း သင်ယူနိုင်မှာ ဖြစ်ပါတယ်။ ဒီလက်တွေ့အရင်းအမြစ်တွေက သင့်ရဲ့ သင်ယူမှုကို မြန်ဆန်စေပြီး MCP အက်ပလီကေးရှင်းများကို ယုံကြည်စိတ်ချစွာ တည်ဆောက်နိုင်ဖို့ ကူညီပေးမှာ ဖြစ်ပါတယ်။

## အနှစ်ချုပ်

ဒီသင်ခန်းစာမှာ MCP ကို မျိုးစုံ programming ဘာသာစကားများတွင် လက်တွေ့အသုံးပြုနည်းများကို အဓိကထား လေ့လာမှာ ဖြစ်ပါတယ်။ C#, Java, TypeScript, JavaScript, Python တို့တွင် MCP SDK များကို ဘယ်လို အသုံးပြုပြီး အားကောင်းတဲ့ အက်ပလီကေးရှင်းများ ဖန်တီးရမလဲ၊ MCP server များကို ဘယ်လို debug နဲ့ စမ်းသပ်ရမလဲ၊ ပြန်လည်အသုံးပြုနိုင်တဲ့ resource, prompt, tool များကို ဘယ်လို ဖန်တီးရမလဲဆိုတာကို ရှင်းလင်းပြသမှာ ဖြစ်ပါတယ်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာပြီးဆုံးချိန်မှာ သင်မှာ အောက်ပါအရာများကို လုပ်ဆောင်နိုင်ပါလိမ့်မယ်-

- မျိုးစုံ programming ဘာသာစကားများအတွက် တရားဝင် SDK များကို အသုံးပြုပြီး MCP ဖြေရှင်းချက်များ အကောင်အထည်ဖော်နိုင်ခြင်း
- MCP server များကို စနစ်တကျ debug နဲ့ စမ်းသပ်နိုင်ခြင်း
- Server features (Resources, Prompts, Tools) များ ဖန်တီးအသုံးပြုနိုင်ခြင်း
- စိန်ခေါ်မှုများအတွက် ထိရောက်တဲ့ MCP workflow များ ဒီဇိုင်းဆွဲနိုင်ခြင်း
- စွမ်းဆောင်ရည်နဲ့ ယုံကြည်စိတ်ချရမှုအတွက် MCP အကောင်အထည်ဖော်မှုများ အကောင်းဆုံးပြုလုပ်နိုင်ခြင်း

## တရားဝင် SDK အရင်းအမြစ်များ

Model Context Protocol သည် မျိုးစုံ ဘာသာစကားများအတွက် တရားဝင် SDK များကို ပံ့ပိုးပေးထားသည်-

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK များနှင့် လုပ်ဆောင်ခြင်း

ဒီအပိုင်းမှာ MCP ကို မျိုးစုံ programming ဘာသာစကားများတွင် အကောင်အထည်ဖော်နည်း လက်တွေ့ ဥပမာများ ပေးထားပါတယ်။ `samples` ဖိုလ်ဒါအတွင်း ဘာသာစကားအလိုက် စနစ်တကျ စုစည်းထားသော နမူနာကုဒ်များကို တွေ့နိုင်ပါသည်။

### ရရှိနိုင်သော နမူနာများ

Repository တွင် အောက်ပါ ဘာသာစကားများအတွက် [နမူနာ အကောင်အထည်ဖော်မှုများ](../../../04-PracticalImplementation/samples) ပါဝင်သည်-

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

နမူနာတိုင်းမှာ MCP ၏ အဓိကအယူအဆများနဲ့ အကောင်အထည်ဖော်နည်းပုံစံများကို သက်ဆိုင်ရာ ဘာသာစကားနဲ့ ပတ်ဝန်းကျင်အတွက် ဖော်ပြထားသည်။

## အဓိက Server Features များ

MCP server များသည် အောက်ပါ feature များကို မည်သည့်ပေါင်းစပ်မှုဖြင့်မဆို အကောင်အထည်ဖော်နိုင်သည်-

### Resources  
Resources များသည် အသုံးပြုသူ သို့မဟုတ် AI မော်ဒယ်အတွက် context နဲ့ ဒေတာများကို ပံ့ပိုးပေးသည်-  
- စာရွက်စာတမ်း သိမ်းဆည်းရာနေရာများ  
- အသိပညာ အခြေခံများ  
- ဖွဲ့စည်းထားသော ဒေတာရင်းမြစ်များ  
- ဖိုင်စနစ်များ  

### Prompts  
Prompts များသည် အသုံးပြုသူများအတွက် စာတမ်းပုံစံ မက်ဆေ့ခ်ျများနဲ့ workflow များဖြစ်သည်-  
- ကြိုတင်သတ်မှတ်ထားသော စကားပြောပုံစံများ  
- လမ်းညွှန်ပေးသော အပြန်အလှန်ဆက်သွယ်မှု ပုံစံများ  
- အထူးပြု စကားပြောဖွဲ့စည်းမှုများ  

### Tools  
Tools များသည် AI မော်ဒယ်အတွက် လုပ်ဆောင်ရန် function များဖြစ်သည်-  
- ဒေတာ ပြုလုပ်ခြင်း ကိရိယာများ  
- ပြင်ပ API ပေါင်းစပ်မှုများ  
- တွက်ချက်မှု စွမ်းရည်များ  
- ရှာဖွေရေး လုပ်ဆောင်ချက်များ  

## နမူနာ အကောင်အထည်ဖော်မှုများ: C#

တရားဝင် C# SDK repository တွင် MCP ၏ အမျိုးမျိုးသော အစိတ်အပိုင်းများကို ဖော်ပြသည့် နမူနာ အကောင်အထည်ဖော်မှုများ ပါဝင်သည်-

- **အခြေခံ MCP Client**: MCP client တစ်ခု ဖန်တီးပြီး tool များကို ခေါ်ယူနည်း ရိုးရှင်းသော ဥပမာ  
- **အခြေခံ MCP Server**: အခြေခံ tool မှတ်ပုံတင်မှုပါရှိသည့် အနည်းဆုံး server အကောင်အထည်ဖော်မှု  
- **တိုးတက်သော MCP Server**: tool မှတ်ပုံတင်ခြင်း၊ အတည်ပြုခြင်းနဲ့ error ကိုင်တွယ်မှုများပါဝင်သည့် အပြည့်အစုံ server  
- **ASP.NET ပေါင်းစပ်မှု**: ASP.NET Core နှင့် ပေါင်းစပ်အသုံးပြုနည်း ဥပမာများ  
- **Tool အကောင်အထည်ဖော်မှု ပုံစံများ**: အဆင့်အတန်း မတူညီသော tool များ ဖန်တီးနည်း ပုံစံများ  

MCP C# SDK သည် preview အဆင့်တွင်ရှိပြီး API များ ပြောင်းလဲနိုင်ပါသည်။ SDK တိုးတက်မှုအတိုင်း ဒီဘလော့ဂ်ကို ဆက်လက် update လုပ်သွားမည်ဖြစ်သည်။

### အဓိက Features  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)  
- သင်၏ [ပထမဆုံး MCP Server တည်ဆောက်ခြင်း](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)  

C# အကောင်အထည်ဖော်မှု နမူနာများ အပြည့်အစုံအတွက် [တရားဝင် C# SDK နမူနာ repository](https://github.com/modelcontextprotocol/csharp-sdk) ကို ကြည့်ရှုနိုင်ပါသည်။

## နမူနာ အကောင်အထည်ဖော်မှု: Java Implementation

Java SDK သည် စီးပွားရေးအဆင့် features များပါဝင်သည့် MCP အကောင်အထည်ဖော်မှု ရွေးချယ်စရာများကို ပံ့ပိုးပေးသည်။

### အဓိက Features

- Spring Framework ပေါင်းစပ်မှု  
- အတိအကျ type safety  
- Reactive programming ပံ့ပိုးမှု  
- error handling အပြည့်အစုံ  

Java အကောင်အထည်ဖော်မှု နမူနာ အပြည့်အစုံအတွက် samples ဖိုလ်ဒါရှိ [Java sample](samples/java/containerapp/README.md) ကို ကြည့်ရှုနိုင်ပါသည်။

## နမူနာ အကောင်အထည်ဖော်မှု: JavaScript Implementation

JavaScript SDK သည် MCP အကောင်အထည်ဖော်မှုအတွက် အလင်းလွယ်ပြီး လွယ်ကူသော နည်းလမ်းကို ပေးသည်။

### အဓိက Features

- Node.js နဲ့ browser ပံ့ပိုးမှု  
- Promise-based API  
- Express နဲ့ အခြား framework များနှင့် လွယ်ကူစွာ ပေါင်းစပ်နိုင်မှု  
- Streaming အတွက် WebSocket ပံ့ပိုးမှု  

JavaScript အကောင်အထည်ဖော်မှု နမူနာ အပြည့်အစုံအတွက် samples ဖိုလ်ဒါရှိ [JavaScript sample](samples/javascript/README.md) ကို ကြည့်ရှုနိုင်ပါသည်။

## နမူနာ အကောင်အထည်ဖော်မှု: Python Implementation

Python SDK သည် MCP အကောင်အထည်ဖော်မှုအတွက် Pythonic နည်းလမ်းနဲ့ ML framework များနှင့် ပေါင်းစပ်မှုကောင်းမွန်စွာ ပံ့ပိုးပေးသည်။

### အဓိက Features

- asyncio ဖြင့် async/await ပံ့ပိုးမှု  
- Flask နဲ့ FastAPI ပေါင်းစပ်မှု  
- tool မှတ်ပုံတင်ခြင်း ရိုးရှင်းမှု  
- လူကြိုက်များသော ML libraries များနှင့် သဘာဝပေါင်းစပ်မှု  

Python အကောင်အထည်ဖော်မှု နမူနာ အပြည့်အစုံအတွက် samples ဖိုလ်ဒါရှိ [Python sample](samples/python/README.md) ကို ကြည့်ရှုနိုင်ပါသည်။

## API စီမံခန့်ခွဲမှု

Azure API Management သည် MCP Server များကို ဘယ်လိုလုံခြုံစေမလဲဆိုတဲ့ အဖြေကောင်းတစ်ခုဖြစ်သည်။ အဓိကအယူအဆက MCP Server ရဲ့ရှေ့မှာ Azure API Management instance တစ်ခုထားပြီး သင်လိုချင်နိုင်တဲ့ feature များကို စီမံခန့်ခွဲပေးခြင်းဖြစ်သည်-

- rate limiting  
- token management  
- monitoring  
- load balancing  
- security  

### Azure နမူနာ

ဒီမှာ Azure နမူနာတစ်ခုရှိပြီး MCP Server တည်ဆောက်ပြီး Azure API Management ဖြင့် လုံခြုံစေခြင်းကို ပြသထားသည်။ (https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

အောက်ပါ ပုံတွင် authorization လုပ်ငန်းစဉ် ဖြစ်ပုံကို ကြည့်ရှုနိုင်သည်-

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

ဤပုံတွင် အောက်ပါအရာများ ဖြစ်ပေါ်နေသည်-

- Authentication/Authorization ကို Microsoft Entra ဖြင့် ဆောင်ရွက်သည်။  
- Azure API Management သည် gateway အဖြစ် လုပ်ဆောင်ပြီး policy များဖြင့် traffic ကို ဦးတည်စီမံသည်။  
- Azure Monitor သည် request အားလုံးကို မှတ်တမ်းတင်ပြီး နောက်ထပ် စစ်ဆေးမှုအတွက် သိမ်းဆည်းသည်။  

#### Authorization လုပ်ငန်းစဉ်

Authorization လုပ်ငန်းစဉ်ကို ပိုမိုအသေးစိတ် ကြည့်ရှုကြပါစို့-

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

ပိုမိုသိရှိလိုပါက [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) ကို လေ့လာနိုင်ပါသည်။

## Remote MCP Server ကို Azure တွင် ဖြန့်ချိခြင်း

ယခင်တွင် ဖော်ပြခဲ့သော နမူနာကို ဖြန့်ချိနိုင်မလား ကြည့်ကြရအောင်-

1. Repository ကို clone လုပ်ပါ

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` resource provider ကို မှတ်ပုံတင်ပါ  
    * Azure CLI သုံးပါက `az provider register --namespace Microsoft.App --wait` ကို run ပါ။  
    * Azure PowerShell သုံးပါက `Register-AzResourceProvider -ProviderNamespace Microsoft.App` ကို run ပါ။ ပြီးနောက် `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` ကို အချိန်အနည်းငယ်ကြာပြီးမှ စစ်ဆေးပါ။

3. API Management service, function app (code ပါရှိသော) နဲ့ အခြား Azure resource များအားလုံးကို provision ပြုလုပ်ရန် [azd](https://aka.ms/azd) command ကို run ပါ

    ```shell
    azd up
    ```

    ဒီ command က Azure ပေါ်မှာ cloud resource အားလုံးကို ဖြန့်ချိပေးပါလိမ့်မယ်။

### MCP Inspector ဖြင့် သင်၏ server ကို စမ်းသပ်ခြင်း

1. **အသစ်သော terminal window** တစ်ခုတွင် MCP Inspector ကို install လုပ်ပြီး run ပါ

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    အောက်ပါအတိုင်း interface တစ်ခုကို တွေ့မြင်ရပါမည်-

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.my.png)

1. MCP Inspector web app ကို URL မှ CTRL click ဖြင့် ဖွင့်ပါ (ဥပမာ http://127.0.0.1:6274/#resources)  
1. transport type ကို `SSE` အဖြစ် သတ်မှတ်ပါ  
1. `azd up` ပြီးနောက် ပြသသော API Management SSE endpoint URL ကို သတ်မှတ်ပြီး **Connect** ကို နှိပ်ပါ-

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools** ကို နှိပ်ပါ။ Tool တစ်ခုကို ရွေးပြီး **Run Tool** ကို နှိပ်ပါ။  

အဆင့်အားလုံးမှန်ကန်ပါက MCP server နှင့် ချိတ်ဆက်ပြီး tool တစ်ခုကို ခေါ်ယူနိုင်ပါပြီ။

## Azure အတွက် MCP server များ

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) သည် Python, C# .NET သို့မဟုတ် Node/TypeScript အသုံးပြု၍ Azure Functions ဖြင့် custom remote MCP server များ တည်ဆောက်၊ ဖြန့်ချိရန် အမြန်စတင်နိုင်သော template များပါဝင်သော repository များဖြစ်သည်။

ဒီ Samples တွင် developer များအတွက် အောက်ပါ အချက်များ ပါဝင်သည်-

- ဒေသတွင်းတွင် တည်ဆောက်ပြီး run နိုင်ခြင်း- MCP server ကို ဒေသတွင်းစက်ပေါ်တွင် ဖန်တီး၊ debug လုပ်နိုင်ခြင်း  
- Azure သို့ ဖြန့်ချိခြင်း

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။