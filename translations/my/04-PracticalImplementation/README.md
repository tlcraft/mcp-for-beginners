<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:26:27+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "my"
}
-->
# Practical Implementation

Model Context Protocol (MCP) ၏ အင်အားကို လက်တွေ့အသုံးချမှုမှာ တွေ့မြင်ရပါသည်။ MCP ၏ သီအိုရီနှင့် ဖွဲ့စည်းပုံကို နားလည်ခြင်းမှာ အရေးကြီးသော်လည်း၊ အမှန်တကယ်တန်ဖိုးရှိတာကတော့ ဒီအယူအဆတွေကို အသုံးပြုပြီး အမှန်တကယ်ဖြေရှင်းနိုင်တဲ့ ဖြေရှင်းချက်တွေကို တည်ဆောက်၊ စမ်းသပ်၊ ထုတ်လုပ်တဲ့အခါမှာ ဖြစ်ပေါ်လာပါသည်။ ဒီအခန်းက MCP အခြေခံထားတဲ့ အက်ပလီကေးရှင်းတွေကို တည်ဆောက်ရာမှာ သဘောတရားနဲ့ လက်တွေ့ဖွံ့ဖြိုးတိုးတက်မှုကြားက အကွာအဝေးကို ဖြတ်သန်းပေးမှာ ဖြစ်ပြီး MCP အခြေခံ အက်ပလီကေးရှင်းတွေကို အသက်သွင်းပေးဖို့ လမ်းညွှန်ပေးပါလိမ့်မယ်။

သင်ဟာ အတတ်ပညာရှင် အကူအညီပေးသူတွေ ဖန်တီးနေပါစေ၊ စီးပွားရေးလုပ်ငန်းစဉ်တွေထဲ AI ကို ပေါင်းစပ်နေပါစေ၊ ဒေတာကို ပြုလုပ်ဖို့ အထူးကိရိယာတွေ တည်ဆောက်နေပါစေ MCP က အလွယ်တကူ အသုံးပြုနိုင်တဲ့ အခြေခံအဆောက်အအုံကို ပေးပါသည်။ MCP ၏ ဘာသာစကားမရွေး ဒီဇိုင်းနဲ့ လူကြိုက်များတဲ့ programming ဘာသာစကားများအတွက် တရားဝင် SDK များကြောင့် အမျိုးမျိုးသော developer များအတွက် လွယ်ကူစွာ အသုံးပြုနိုင်ပါသည်။ ဒီ SDK များကို အသုံးပြုပြီး သင်သည် မျိုးစုံသော ပလက်ဖောင်းများနှင့် ပတ်ဝန်းကျင်များတွင် များပြားစွာ prototype ဖန်တီး၊ ပြန်လည်ပြင်ဆင်၊ တိုးချဲ့နိုင်ပါသည်။

နောက်ထပ် အပိုင်းများတွင် MCP ကို C#, Java, TypeScript, JavaScript, Python တို့တွင် ဘယ်လို အသုံးပြုရမလဲဆိုတာကို လက်တွေ့ ဥပမာများ၊ နမူနာကုဒ်များနှင့် ထုတ်လုပ်ခြင်းနည်းလမ်းများဖြင့် ဖော်ပြထားပါသည်။ MCP server များကို debug နှင့် စမ်းသပ်နည်း၊ API များကို စီမံခန့်ခွဲနည်း၊ Azure ကို အသုံးပြုပြီး cloud သို့ ထုတ်လုပ်နည်းများကိုလည်း သင်ယူနိုင်ပါသည်။ ဒီလက်တွေ့အရင်းအမြစ်များက သင်၏ သင်ယူမှုကို မြန်ဆန်စေပြီး MCP အက်ပလီကေးရှင်းများကို ယုံကြည်စိတ်ချစွာ တည်ဆောက်နိုင်ရန် အထောက်အကူပြုပါလိမ့်မယ်။

## Overview

ဒီသင်ခန်းစာမှာ MCP ကို မျိုးစုံ programming ဘာသာစကားများတွင် လက်တွေ့အသုံးပြုခြင်းအပေါ် အာရုံစိုက်ထားပါတယ်။ C#, Java, TypeScript, JavaScript, Python တို့တွင် MCP SDK များကို အသုံးပြုပြီး ခိုင်မာသော အက်ပလီကေးရှင်းများ ဖန်တီးခြင်း၊ MCP server များကို debug နှင့် စမ်းသပ်ခြင်း၊ ပြန်လည်အသုံးပြုနိုင်သော resource, prompt, tool များ ဖန်တီးခြင်းတို့ကို လေ့လာပါမယ်။

## Learning Objectives

ဒီသင်ခန်းစာပြီးဆုံးချိန်မှာ သင်သည် အောက်ပါအရာများကို လုပ်ဆောင်နိုင်ပါလိမ့်မယ်-

- မျိုးစုံ programming ဘာသာစကားများတွင် တရားဝင် SDK များကို အသုံးပြုပြီး MCP ဖြေရှင်းချက်များ တည်ဆောက်နိုင်ခြင်း
- MCP server များကို စနစ်တကျ debug နှင့် စမ်းသပ်နိုင်ခြင်း
- Server features (Resources, Prompts, Tools) များ ဖန်တီးပြီး အသုံးပြုနိုင်ခြင်း
- စိန်ခေါ်မှုများအတွက် ထိရောက်သော MCP workflow များ ဒီဇိုင်းဆွဲနိုင်ခြင်း
- စွမ်းဆောင်ရည်နှင့် ယုံကြည်စိတ်ချရမှုအတွက် MCP implementation များကို အကောင်းဆုံး ပြုလုပ်နိုင်ခြင်း

## Official SDK Resources

Model Context Protocol သည် မျိုးစုံ ဘာသာစကားများအတွက် တရားဝင် SDK များကို ပံ့ပိုးပေးပါသည်-

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Working with MCP SDKs

ဒီအပိုင်းမှာ MCP ကို မျိုးစုံ programming ဘာသာစကားများတွင် လက်တွေ့အသုံးပြုနည်း ဥပမာများကို ဖော်ပြထားပါတယ်။ `samples` ဖိုလ်ဒါအတွင်း ဘာသာစကားအလိုက် စနစ်တကျ စုစည်းထားသော နမူနာကုဒ်များကို တွေ့နိုင်ပါသည်။

### Available Samples

Repository တွင် အောက်ပါ ဘာသာစကားများအတွက် [နမူနာ implementation များ](../../../04-PracticalImplementation/samples) ပါဝင်သည်-

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

နမူနာတိုင်းမှာ MCP ၏ အဓိကအယူအဆများနှင့် အကောင်အထည်ဖော်နည်းပုံစံများကို ထူးခြားစွာ ဖော်ပြထားပါသည်။

## Core Server Features

MCP server များသည် အောက်ပါ feature များကို မည်သည့်ပေါင်းစပ်မှုဖြင့်မဆို အကောင်အထည်ဖော်နိုင်ပါသည်-

### Resources  
Resources များသည် အသုံးပြုသူ သို့မဟုတ် AI မော်ဒယ်အတွက် context နှင့် ဒေတာများကို ပံ့ပိုးပေးသည်-  
- စာရွက်စာတမ်း သိမ်းဆည်းရာနေရာများ  
- အသိပညာ အခြေခံများ  
- ဖွဲ့စည်းထားသော ဒေတာရင်းမြစ်များ  
- ဖိုင်စနစ်များ  

### Prompts  
Prompts များသည် အသုံးပြုသူများအတွက် စာတမ်းပုံစံ မက်ဆေ့ခ်ျများနှင့် workflow များဖြစ်သည်-  
- ကြိုတင်သတ်မှတ်ထားသော စကားပြောပုံစံများ  
- လမ်းညွှန်ပေးသော အပြန်အလှန်ဆက်သွယ်မှု ပုံစံများ  
- အထူးပြု စကားပြောဖွဲ့စည်းမှုများ  

### Tools  
Tools များသည် AI မော်ဒယ်အတွက် လုပ်ဆောင်ရန် function များဖြစ်သည်-  
- ဒေတာ ပြုလုပ်ခြင်း ကိရိယာများ  
- ပြင်ပ API ပေါင်းစပ်မှုများ  
- တွက်ချက်မှု စွမ်းရည်များ  
- ရှာဖွေရေး လုပ်ဆောင်ချက်များ  

## Sample Implementations: C#

တရားဝင် C# SDK repository တွင် MCP ၏ အစိတ်အပိုင်းများကို ဖော်ပြသည့် နမူနာ implementation များ ပါဝင်သည်-

- **Basic MCP Client**: MCP client တစ်ခု ဖန်တီးပြီး tool များကို ခေါ်ယူနည်း ရိုးရှင်းသော ဥပမာ  
- **Basic MCP Server**: အနည်းဆုံး tool မှတ်ပုံတင်မှုပါရှိသည့် server implementation  
- **Advanced MCP Server**: tool မှတ်ပုံတင်ခြင်း၊ authentication နှင့် error handling ပါဝင်သည့် အပြည့်အစုံ server  
- **ASP.NET Integration**: ASP.NET Core နှင့် ပေါင်းစပ်အသုံးပြုနည်း ဥပမာများ  
- **Tool Implementation Patterns**: tool များကို အဆင့်အတန်း မတူညီသော နည်းလမ်းများဖြင့် ဖန်တီးနည်းပုံစံများ  

MCP C# SDK သည် preview အဆင့်တွင်ရှိပြီး API များ ပြောင်းလဲနိုင်ပါသည်။ SDK တိုးတက်မှုအတိုင်း ဒီဘလော့ဂ်ကို ဆက်လက် update လုပ်သွားပါမည်။

### Key Features  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)  
- သင်၏ [ပထမဆုံး MCP Server တည်ဆောက်ခြင်း](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)  

C# implementation နမူနာများ အပြည့်အစုံအတွက် [တရားဝင် C# SDK နမူနာ repository](https://github.com/modelcontextprotocol/csharp-sdk) ကို ကြည့်ရှုနိုင်ပါသည်။

## Sample implementation: Java Implementation

Java SDK သည် စီးပွားရေးအဆင့် feature များပါဝင်သည့် MCP implementation အတွက် ခိုင်မာသော ရွေးချယ်မှုများ ပေးပါသည်။

### Key Features

- Spring Framework ပေါင်းစပ်မှု  
- အတိအကျ type safety  
- Reactive programming ပံ့ပိုးမှု  
- error handling အပြည့်အစုံ  

Java implementation နမူနာ အပြည့်အစုံအတွက် samples ဖိုလ်ဒါရှိ [Java sample](samples/java/containerapp/README.md) ကို ကြည့်ပါ။

## Sample implementation: JavaScript Implementation

JavaScript SDK သည် MCP implementation အတွက် အလွယ်တကူနှင့် လွယ်ကူသော နည်းလမ်းကို ပေးပါသည်။

### Key Features

- Node.js နှင့် browser ပံ့ပိုးမှု  
- Promise-based API  
- Express နှင့် အခြား framework များနှင့် လွယ်ကူစွာ ပေါင်းစပ်နိုင်မှု  
- Streaming အတွက် WebSocket ပံ့ပိုးမှု  

JavaScript implementation နမူနာ အပြည့်အစုံအတွက် samples ဖိုလ်ဒါရှိ [JavaScript sample](samples/javascript/README.md) ကို ကြည့်ပါ။

## Sample implementation: Python Implementation

Python SDK သည် MCP implementation အတွက် Pythonic နည်းလမ်းနှင့် ML framework များနှင့် ပေါင်းစပ်မှုကောင်းမွန်စွာ ပံ့ပိုးပါသည်။

### Key Features

- asyncio ဖြင့် async/await ပံ့ပိုးမှု  
- FastAPI ပေါင်းစပ်မှု  
- ရိုးရှင်းသော tool မှတ်ပုံတင်ခြင်း  
- လူကြိုက်များသော ML libraries များနှင့် native ပေါင်းစပ်မှု  

Python implementation နမူနာ အပြည့်အစုံအတွက် samples ဖိုလ်ဒါရှိ [Python sample](samples/python/README.md) ကို ကြည့်ပါ။

## API management

Azure API Management သည် MCP Server များကို ဘယ်လိုလုံခြုံစေမလဲဆိုတာအတွက် အကောင်းဆုံးဖြေရှင်းချက်တစ်ခုဖြစ်သည်။ အဓိကအကြံဉာဏ်မှာ MCP Server ရဲ့ရှေ့မှာ Azure API Management instance တစ်ခုထားပြီး အောက်ပါ feature များကို စီမံခန့်ခွဲပေးခြင်းဖြစ်သည်-

- rate limiting  
- token management  
- monitoring  
- load balancing  
- security  

### Azure Sample

ဒီမှာ Azure Sample တစ်ခုရှိပြီး MCP Server တစ်ခု ဖန်တီးပြီး Azure API Management ဖြင့် လုံခြုံစေခြင်းကို ပြသထားသည်။ (https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

အောက်ပါ ပုံတွင် authorization flow ဖြစ်ပုံကို ကြည့်ရှုနိုင်ပါသည်-

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

ဤပုံတွင် အောက်ပါအရာများ ဖြစ်ပေါ်နေသည်-

- Microsoft Entra ဖြင့် Authentication/Authorization ပြုလုပ်ခြင်း  
- Azure API Management သည် gateway အဖြစ် လုပ်ဆောင်ပြီး policy များဖြင့် traffic ကို ဦးတည်စီမံခြင်း  
- Azure Monitor သည် request အားလုံးကို မှတ်တမ်းတင်ခြင်း  

#### Authorization flow

Authorization flow ကို ပိုမိုအသေးစိတ် ကြည့်ရှုကြပါစို့-

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

[MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) အကြောင်း ပိုမိုလေ့လာနိုင်ပါသည်။

## Deploy Remote MCP Server to Azure

ယခင်တွင် ဖော်ပြခဲ့သော နမူနာကို Azure သို့ ထုတ်လုပ်နိုင်မလား ကြည့်ကြရအောင်-

1. Repository ကို clone လုပ်ပါ

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` resource provider ကို မှတ်ပုံတင်ပါ  
    * Azure CLI သုံးပါက `az provider register --namespace Microsoft.App --wait` ကို run ပါ  
    * Azure PowerShell သုံးပါက `Register-AzResourceProvider -ProviderNamespace Microsoft.App` ကို run ပါ။ ပြီးနောက် `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` ကို အချိန်အနည်းငယ်ကြာပြီးမှ စစ်ဆေးပါ။

3. API management service, function app (code ပါရှိသော) နှင့် အခြား Azure resource များအား provision ပြုလုပ်ရန် [azd](https://aka.ms/azd) command ကို run ပါ

    ```shell
    azd up
    ```

    ဒီ command က Azure ပေါ်မှာ cloud resource အားလုံးကို ထုတ်လုပ်ပေးပါလိမ့်မယ်။

### MCP Inspector ဖြင့် သင်၏ server ကို စမ်းသပ်ခြင်း

1. **အသစ်သော terminal window** တစ်ခုတွင် MCP Inspector ကို install လုပ်ပြီး run ပါ

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    အောက်ပါအတိုင်း interface တစ်ခုကို တွေ့မြင်ရပါမည်-

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png)

1. MCP Inspector web app ကို URL မှာ CTRL နှိပ်ပြီး ဖွင့်ပါ (ဥပမာ http://127.0.0.1:6274/#resources)  
1. transport type ကို `SSE` သတ်မှတ်ပါ  
1. `azd up` ပြီးနောက် ပြသသော API Management SSE endpoint URL ကို သတ်မှတ်ပြီး **Connect** နှိပ်ပါ-

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools** ကို နှိပ်ပါ။ tool တစ်ခုကို ရွေးပြီး **Run Tool** ကို နှိပ်ပါ။  

အဆင့်အားလုံးမှန်ကန်ပါက MCP server နှင့် ချိတ်ဆက်ပြီး tool တစ်ခုကို ခေါ်ယူနိုင်ပါပြီ။

## MCP servers for Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) သည် Azure Functions ကို အသုံးပြုပြီး Python, C# .NET, Node/TypeScript ဖြင့် custom remote MCP server များ ဖန်တီး၊ ထုတ်လုပ်ရန် အမြန်စတင်နိုင်သော template များပါဝင်သော repository များဖြစ်သည်။

ဒီ Samples တွင် developer များအတွက် အောက်ပါ အချက်များ ပါဝင်သည်-

- ဒေသတွင်းတွင် တည်ဆောက်ပြီး run နိုင်ခြင်း၊ MCP server ကို local machine ပေါ်တွင် ဖန်တီး၊ debug လုပ်နိုင်ခြင်း  
- Azure သို့ လွယ်ကူစွာ ထုတ်လုပ်နိုင်ခြင်း (azd up command တစ်ခုဖြင့်)  
- မျိုးစုံ client များမှ MCP server သို့ ချိတ်ဆက်နိုင်ခြင်း (VS Code Copilot agent mode နှင့် MCP Inspector tool အပါအဝင်)  

### Key Features:

- ဒီဇိုင်းအရ လုံခြုံရေး: MCP server ကို key များနှင့် HTTPS ဖြင့် လုံခြုံစေခြင်း  
- Authentication ရွေးချယ်စရာများ: built-in auth နှင့်/သို့မဟုတ် API Management ဖြင့် OAuth ပံ့ပိုးမှု  
- Network isolation: Azure Virtual Networks (VNET) အသုံးပြု၍ network isolation ခွင့်ပြုခြင်း  
- Serverless architecture: Azure Functions ကို အသုံးပြုပြီး scalable, event-driven execution  
- ဒေသတွင်း ဖွံ့ဖြိုးတိုးတက်မှု: local development နှင့် debugging အပြည့်အစုံ ပံ့ပိုးမှု  
- လွယ်ကူသော ထုတ်လုပ်မှု: Azure သို့ ထုတ်လုပ်ခြင်း လုပ်ငန်းစဉ်ကို ရိုးရှင်းစေခြင်း  

Repository တွင် production-ready MCP server implementation အတွက် လိုအပ်သော configuration ဖိုင်များ၊ source code များနှင့် infrastructure definition များ ပါဝင်သည်။

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Azure Functions နှင့် Python အသုံးပြု၍ MCP ကို sample အနေနဲ့ ဖော်ပြထားသည်  
- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Azure Functions နှင့် C# .NET အသုံးပြု၍

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။