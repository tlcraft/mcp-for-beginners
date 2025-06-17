<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-17T17:04:17+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "my"
}
-->
# လက်တွေ့ကျကျ အကောင်အထည်ဖော်ခြင်း

လက်တွေ့ကျကျ အကောင်အထည်ဖော်ခြင်းမှာ Model Context Protocol (MCP) ရဲ့ အင်အားကို သက်သေပြနိုင်တဲ့ နေရာဖြစ်ပါတယ်။ MCP နောက်ကွယ်က သီအိုရီနဲ့ ဖွဲ့စည်းပုံကို နားလည်ခြင်းက အရေးကြီးသော်လည်း၊ အမှန်တကယ်တန်ဖိုးရှိတာက ဒီအယူအဆတွေကို အသုံးပြုပြီး အမှန်တကယ် ရှေ့ဆက်ဖြေရှင်းနည်းတွေ တည်ဆောက်၊ စမ်းသပ်၊ ထုတ်လုပ်ရာမှာ ဖြစ်ပါတယ်။ ဒီအခန်းက MCP အခြေပြု အက်ပလီကေးရှင်းတွေကို လက်တွေ့ကျကျ ဖန်တီးဖို့ လမ်းညွှန်ပေးပြီး သီအိုရီနဲ့ လက်တွေ့အကြား ချိတ်ဆက်ပေးပါတယ်။

သင်ဟာ ဉာဏ်ရည်ကောင်းတဲ့ အကူအညီပေးသူတွေ ဖန်တီးနေဖြစ်စေ၊ AI ကို စီးပွားရေးလုပ်ငန်းစဉ်တွေထဲတွင် ပေါင်းစည်းနေဖြစ်စေ၊ ဒေတာကို စီမံခန့်ခွဲဖို့ အထူးကိရိယာတွေ တည်ဆောက်နေဖြစ်စေ MCP က ပြောင်းလဲနိုင်ပြီး အခြေခံတည်ဆောက်ပုံကို ပံ့ပိုးပေးပါတယ်။ MCP ရဲ့ ဘာသာစကားမရွေး ဒီဇိုင်းနဲ့ လူကြိုက်များတဲ့ programming ဘာသာစကားများအတွက် တရားဝင် SDK များကြောင့် တိုးတက်တဲ့ developer အုပ်စုတစ်စုအတွက် လွယ်ကူစွာ အသုံးပြုနိုင်ပါတယ်။ ဒီ SDK များကို အသုံးပြုပြီး သင်၏ ဖြေရှင်းနည်းများကို အလျင်အမြန် prototype ပြုလုပ်၊ ပြင်ဆင်၊ နှင့် ပလက်ဖောင်းများနှင့် ပတ်ဝန်းကျင် များစွာတွင် အဆင့်မြှင့်နိုင်ပါသည်။

နောက်တွဲအပိုင်းများတွင် C#, Java, TypeScript, JavaScript, Python တို့တွင် MCP ကို မည်သို့ အကောင်အထည်ဖော်ရမည်ကို လက်တွေ့ ဥပမာများ၊ ကိုးဒ်နမူနာများ၊ နှင့် ထုတ်လုပ်မှု မဟာဗျူဟာများ ပါဝင်ပါသည်။ MCP server များကို debug နှင့် စမ်းသပ်ခြင်း၊ API များကို စီမံခန့်ခွဲခြင်း၊ Azure ကို အသုံးပြုပြီး cloud တွင် ဖြန့်ချိခြင်းတို့ကိုလည်း သင်ယူရမည်ဖြစ်ပြီး၊ ဒီလက်တွေ့အရင်းအမြစ်များက သင်၏ သင်ယူမှုကို မြန်ဆန်စေပြီး သေချာစွာ ပြည့်စုံသော MCP အက်ပလီကေးရှင်းများ တည်ဆောက်နိုင်ရန် ကူညီပေးပါလိမ့်မယ်။

## အနှစ်ချုပ်

ဒီသင်ခန်းစာက MCP ကို programming ဘာသာစကား များစွာတွင် လက်တွေ့ကျကျ အကောင်အထည်ဖော်ရာတွင် အာရုံစိုက်ထားပါတယ်။ C#, Java, TypeScript, JavaScript, Python SDK များကို အသုံးပြုပြီး ခိုင်မာသော အက်ပလီကေးရှင်းများ ဖန်တီးခြင်း၊ MCP server များကို debug နှင့် စမ်းသပ်ခြင်း၊ ပြန်လည်အသုံးပြုနိုင်သော resource, prompt, tool များ ဖန်တီးခြင်းတို့ကို လေ့လာပါမည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာ အပြီးသတ်တွင် သင်အောက်ပါအရာများ ပြုလုပ်နိုင်ပါလိမ့်မယ်-
- တရားဝင် SDK များကို အသုံးပြုပြီး MCP ဖြေရှင်းနည်းများကို အကောင်အထည်ဖော်နိုင်ခြင်း
- MCP server များကို စနစ်တကျ debug နှင့် စမ်းသပ်နိုင်ခြင်း
- Server feature များ (Resource, Prompt, Tool) ဖန်တီးပြီး အသုံးပြုနိုင်ခြင်း
- ရှုပ်ထွေးသော အလုပ်များအတွက် MCP workflow များ ဒီဇိုင်းဆွဲနိုင်ခြင်း
- လုပ်ဆောင်ချက်နှင့် ယုံကြည်စိတ်ချရမှုအတွက် MCP အကောင်အထည်ဖော်မှုများ အမြှင့်တင်နိုင်ခြင်း

## တရားဝင် SDK အရင်းအမြစ်များ

Model Context Protocol သည် ဘာသာစကား များစွာအတွက် တရားဝင် SDK များ ပံ့ပိုးပေးပါသည်-

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK များနှင့်အတူ အလုပ်လုပ်ခြင်း

ဒီပိုင်းမှာ MCP ကို ဘာသာစကား များစွာတွင် အကောင်အထည်ဖော်နည်း လက်တွေ့ ဥပမာများ ပါရှိပါတယ်။ `samples` ဖိုင်တွဲထဲတွင် ဘာသာစကား အလိုက် စီစဉ်ထားသော နမူနာကို ရှာတွေ့နိုင်ပါသည်။

### ရရှိနိုင်သည့် နမူနာများ

ဒီ repository မှာ အောက်ပါ ဘာသာစကားများအတွက် နမူနာ အကောင်အထည်ဖော်မှုများ ပါဝင်သည်-

- C#
- Java
- TypeScript
- JavaScript
- Python

နမူနာတစ်ခုချင်းစီမှာ MCP အဓိက အယူအဆများနှင့် အကောင်အထည်ဖော်နည်းပုံစံများကို ဖော်ပြထားသည်။

## အဓိက Server Feature များ

MCP server များသည် အောက်ပါ feature များကို မည်သည့်ပေါင်းစပ်မှုဖြင့်မဆို အကောင်အထည်ဖော်နိုင်သည်-

### Resources
Resources များသည် အသုံးပြုသူ သို့မဟုတ် AI မော်ဒယ်အတွက် context နှင့် ဒေတာများ ပေးစွမ်းသည်-
- စာရွက်စာတမ်း သိမ်းဆည်းရာနေရာများ
- အသိပညာ အခြေခံများ
- ဖွဲ့စည်းထားသော ဒေတာ အရင်းအမြစ်များ
- ဖိုင်စနစ်များ

### Prompts
Prompts များသည် အသုံးပြုသူများအတွက် စနစ်တကျ ပြင်ဆင်ထားသော စကားဝိုင်းနှင့် လုပ်ငန်းစဉ်များဖြစ်သည်-
- ကြိုတင်သတ်မှတ်ထားသော စကားပြော template များ
- ညွှန်ကြားချက် ပုံစံများ
- အထူးပြု ဆွေးနွေးပုံစံများ

### Tools
Tools များသည် AI မော်ဒယ်အတွက် အလုပ်လုပ်ရန် function များဖြစ်သည်-
- ဒေတာကို စီမံခန့်ခွဲသုံးစွဲရန် ကိရိယာများ
- ပြင်ပ API ပေါင်းစည်းမှုများ
- တွက်ချက်မှု စွမ်းရည်များ
- ရှာဖွေရေး လုပ်ဆောင်ချက်များ

## နမူနာ အကောင်အထည်ဖော်မှုများ: C#

တရားဝင် C# SDK repository တွင် MCP ၏ အမျိုးမျိုးသော အစိတ်အပိုင်းများကို ဖော်ပြထားသော နမူနာများပါဝင်သည်-

- **အခြေခံ MCP Client**: MCP client တည်ဆောက်ပြီး tool များကို ခေါ်ယူပုံ ရိုးရှင်းသော ဥပမာ
- **အခြေခံ MCP Server**: tool များကို စာရင်းသွင်းထားသော အနည်းဆုံး server အကောင်အထည်ဖော်မှု
- **တိုးတက်သော MCP Server**: tool စာရင်းသွင်းခြင်း၊ authentication နှင့် error ကိုင်တွယ်မှုပါရှိသော ပြည့်စုံသော server
- **ASP.NET ပေါင်းစည်းမှု**: ASP.NET Core နှင့် ပေါင်းစည်းမှုကို ဖော်ပြထားသော ဥပမာများ
- **Tool အကောင်အထည်ဖော်မှု ပုံစံများ**: အဆင့်အတန်း မတူညီသော tool များကို ဖန်တီးရန် ပုံစံမျိုးစုံ

C# MCP SDK သည် preview အဆင့်တွင်ရှိပြီး API များ ပြောင်းလဲနိုင်သဖြင့် SDK တိုးတက်မှုအတိုင်း ဒီဘလော့ဂ်ကို ဆက်လက်ပြင်ဆင်သွားမည် ဖြစ်သည်။

### အဓိက Features
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- သင်၏ [ပထမဆုံး MCP Server တည်ဆောက်ခြင်း](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/)

C# အကောင်အထည်ဖော်မှုနမူနာများ အပြည့်အစုံအတွက် [တရားဝင် C# SDK နမူနာ repository](https://github.com/modelcontextprotocol/csharp-sdk) ကို သွားကြည့်ပါ။

## နမူနာ အကောင်အထည်ဖော်မှု: Java Implementation

Java SDK သည် စီးပွားရေးအဆင့် feature များနှင့် MCP အကောင်အထည်ဖော်မှု ရွေးချယ်စရာများကို ပံ့ပိုးပေးသည်။

### အဓိက Features

- Spring Framework ပေါင်းစည်းမှု
- တင်းကြပ်သော type လုံခြုံမှု
- Reactive programming ပံ့ပိုးမှု
- error ကိုင်တွယ်မှု ပြည့်စုံမှု

Java အကောင်အထည်ဖော်မှုနမူနာ အပြည့်အစုံအတွက် samples ဖိုင်တွဲရှိ [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) ကို ကြည့်ရှုနိုင်ပါသည်။

## နမူနာ အကောင်အထည်ဖော်မှု: JavaScript Implementation

JavaScript SDK သည် MCP အကောင်အထည်ဖော်မှုအတွက် လွယ်ကူပြီး ပြောင်းလဲနိုင်သော နည်းလမ်းဖြစ်သည်။

### အဓိက Features

- Node.js နှင့် browser ပံ့ပိုးမှု
- Promise အခြေပြု API
- Express နှင့် အခြား framework များနှင့် လွယ်ကူစွာ ပေါင်းစည်းနိုင်မှု
- Streaming အတွက် WebSocket ပံ့ပိုးမှု

JavaScript အကောင်အထည်ဖော်မှုနမူနာ အပြည့်အစုံအတွက် samples ဖိုင်တွဲရှိ [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) ကို ကြည့်ရှုနိုင်ပါသည်။

## နမူနာ အကောင်အထည်ဖော်မှု: Python Implementation

Python SDK သည် ML framework များနှင့် ပေါင်းစည်းမှုကောင်းမွန်ပြီး Pythonic နည်းလမ်းဖြင့် MCP အကောင်အထည်ဖော်မှုကို ပံ့ပိုးသည်။

### အဓိက Features

- asyncio ဖြင့် async/await ပံ့ပိုးမှု
- Flask နှင့် FastAPI ပေါင်းစည်းမှု
- tool စာရင်းသွင်းခြင်း လွယ်ကူမှု
- လူကြိုက်များသော ML စာကြည့်တိုက်များနှင့် တိုက်ရိုက် ပေါင်းစည်းမှု

Python အကောင်အထည်ဖော်မှုနမူနာ အပြည့်အစုံအတွက် samples ဖိုင်တွဲရှိ [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) ကို ကြည့်ရှုနိုင်ပါသည်။

## API စီမံခန့်ခွဲမှု

Azure API Management သည် MCP server များကို ဘယ်လို လုံခြုံစွာ စီမံနိုင်မလဲဆိုတဲ့ ကောင်းမွန်တဲ့ဖြေရှင်းချက်တစ်ခုဖြစ်သည်။ အဓိကအယူအဆမှာ MCP Server ရဲ့ရှေ့မှာ Azure API Management instance တစ်ခုထားပြီး သင်လိုအပ်မယ့် feature များကို ကိုင်တွယ်ပေးရန် ဖြစ်သည်-

- rate limiting
- token management
- monitoring
- load balancing
- security

### Azure နမူနာ

ဒီမှာ Azure နမူနာတစ်ခုရှိပြီး MCP Server တစ်ခု တည်ဆောက်ကာ Azure API Management ဖြင့် လုံခြုံစေခြင်းကို ပြသထားသည်- [creating an MCP Server and securing it with Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

အောက်ပါ ပုံတွင် authorization flow ဖြစ်ပုံကို ကြည့်ရှုနိုင်ပါသည်-

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

ဤပုံတွင် အောက်ပါအရာများ ဖြစ်ပျက်နေသည်-

- Authentication/Authorization ကို Microsoft Entra ဖြင့် ဆောင်ရွက်သည်။
- Azure API Management သည် gateway အဖြစ် လုပ်ဆောင်ပြီး မူဝါဒများ အသုံးပြုကာ traffic ကို စီမံခန့်ခွဲသည်။
- Azure Monitor သည် အားလုံးသော request များကို မှတ်တမ်းတင်ပြီး နောက်ပိုင်း စိစစ်မှုအတွက် သိမ်းဆည်းသည်။

#### Authorization flow

authorization flow ကို အသေးစိတ် ကြည့်ရအောင်-

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

[ MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow) အကြောင်း ပိုမိုသိရှိလိုပါက လေ့လာနိုင်ပါသည်။

## Remote MCP Server ကို Azure တွင် ဖြန့်ချိခြင်း

ယခင်တွင် ဖော်ပြခဲ့သော နမူနာကို ဖြန့်ချိနိုင်မလား ကြည့်ကြရအောင်-

1. Repository ကို clone လုပ်ပါ

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. `Microsoft.App` provider ကို register လုပ်ပါ - အချိန်အနည်းငယ်နောက်မှ registration ပြီးစီးပြီလား စစ်ဆေးရန်

    `az provider register --namespace Microsoft.App --wait`

    သို့မဟုတ်

    `Register-AzResourceProvider -ProviderNamespace Microsoft.App`

    နှင့်

    `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

3. API Management service, function app (code ပါရှိ) နှင့် အခြား Azure အရင်းအမြစ်များအား provision လုပ်ရန် [azd](https://aka.ms/azd) command ကို run ပါ

    ```shell
    azd up
    ```

    ဒီ command က Azure ပေါ်မှာ cloud အရင်းအမြစ်အားလုံးကို ဖြန့်ချိပါလိမ့်မယ်။

### MCP Inspector ဖြင့် သင်၏ server ကို စမ်းသပ်ခြင်း

1. **Terminal အသစ်တစ်ခုတွင်** MCP Inspector ကို install လုပ်ပြီး run ပါ

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    အောက်ပါ အင်တာဖေ့စ်ကဲ့သို့ မြင်ရပါမည်-

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.my.png)

2. MCP Inspector web app ကို URL (ဥပမာ http://127.0.0.1:6274/#resources) မှ CTRL နှိပ်ပြီး ဖွင့်ပါ။
3. transport type ကို `SSE` သတ်မှတ်ပြီး **Connect** ကိုနှိပ်ပါ။

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools** ကို ဖော်ပြပါ။ tool တစ်ခုကို နှိပ်ပြီး **Run Tool** ကို နှိပ်ပါ။

အဆင့်အားလုံးမှန်ကန်ပါက MCP server နှင့် ချိတ်ဆက်ပြီး tool တစ်ခုကို ခေါ်ယူနိုင်ပါပြီ။

## Azure အတွက် MCP server များ

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Python, C# .NET သို့မဟုတ် Node/TypeScript အသုံးပြုကာ Azure Functions ဖြင့် custom remote MCP server များ ဖန်တီး၊ ဖြန့်ချိရန် quickstart template များပါဝင်သည်။

ဒီ Samples သည် developer များအတွက် အောက်ပါ အစိတ်အပိုင်းများပါဝင်သော ပြည့်စုံသော ဖြေရှင်းချက်ဖြစ်သည်-

- ဒေသတွင်းတွင် တည်ဆောက်ခြင်းနှင့် run ခြင်း: MCP server ကို ဒေသတွင်း စက်ပေါ်တွင် ဖန်တီး၊ debug ပြုလုပ်နိုင်ခြင်း
- Azure သို့ ဖြန့်ချိခြင်း: azd up command လွယ်ကူစွာ အသုံးပြုကာ cloud သို့ ဖြန့်ချိနိုင်ခြင်း
- client များမှ ချိတ်ဆက်ခြင်း: VS Code ရဲ့ Copilot agent mode နှင့် MCP Inspector tool အပါအဝင် client များမှ MCP server ကို ချိတ်ဆက်နိုင်ခြင်း

### အဓိက Features:

- ဒီဇိုင်းအရ လုံခြုံမှု: MCP server ကို key များနှင့် HTTPS အသုံးပြုပြီး လုံခြုံစေသည်
- Authentication ရွေးချယ်စရာများ: built-in auth နှင့်/သို့မဟုတ် API Management ဖြင့် OAuth ကို ပံ့ပိုးသည်
- Network isolation: Azure

**ကြေညာချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ တိကျမှုအတွက် ကြိုးစားပေမယ့် အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် တိကျမှုမရှိမှုများ ဖြစ်ပေါ်နိုင်ကြောင်း သတိပြုပါရန်။ မူရင်းစာရွက်စာတမ်းကို မူရင်းဘာသာဖြင့် အတည်ပြုရမည့် အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော သတင်းအချက်အလက်များအတွက် လူ့ဘာသာပြန်ကျွမ်းကျင်သူ၏ ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်နိုင်သည့် နားမလည်မှုများ သို့မဟုတ် မှားယွင်းသဘောထားများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။