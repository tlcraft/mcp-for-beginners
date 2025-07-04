<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T19:19:35+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "my"
}
-->
## စတင်ခြင်း  

ဤအပိုင်းတွင် သင်ခန်းစာအချို့ ပါဝင်သည်-

- **1 သင့်ပထမဆုံးဆာဗာ**၊ ပထမဆုံးသင်ခန်းစာတွင် သင့်ပထမဆုံးဆာဗာကို ဖန်တီးနည်းနှင့် inspector tool ဖြင့် စစ်ဆေးနည်းကို သင်ယူမည်ဖြစ်ပြီး၊ ၎င်းသည် သင့်ဆာဗာကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေရေးအတွက် အထောက်အကူပြုသည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/01-first-server/README.md)

- **2 Client**၊ ဤသင်ခန်းစာတွင် သင့်ဆာဗာနှင့် ချိတ်ဆက်နိုင်သော client ကို ရေးသားနည်းကို သင်ယူမည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/02-client/README.md)

- **3 LLM ပါသော Client**၊ client ရေးသားရာတွင် LLM ကို ထည့်သွင်းခြင်းဖြင့် ဆာဗာနှင့် "ညှိနှိုင်း" ပြုလုပ်နိုင်သော ပိုမိုကောင်းမွန်သောနည်းလမ်း၊ [သင်ခန်းစာသို့](/03-GettingStarted/03-llm-client/README.md)

- **4 Visual Studio Code တွင် GitHub Copilot Agent mode ဖြင့် ဆာဗာကို အသုံးပြုခြင်း**။ ဤနေရာတွင် MCP Server ကို Visual Studio Code အတွင်းမှ တိုက်ရိုက် လည်ပတ်ခြင်းကို ကြည့်ရှုမည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/04-vscode/README.md)

- **5 SSE (Server Sent Events) မှ အသုံးပြုခြင်း** SSE သည် ဆာဗာမှ client သို့ တိုက်ရိုက် စီးဆင်းမှုများ ပေးပို့ရန် HTTP ပေါ်တွင် အသုံးပြုသော စံနမူနာဖြစ်သည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/05-sse-server/README.md)

- **6 MCP ဖြင့် HTTP Streaming (Streamable HTTP)**။ ခေတ်မီ HTTP streaming၊ တိုးတက်မှု အသိပေးချက်များနှင့် Streamable HTTP ကို အသုံးပြု၍ တိုးချဲ့နိုင်သော၊ အချိန်နှင့်တပြေးညီ လည်ပတ်နိုင်သော MCP ဆာဗာနှင့် client များ ဖန်တီးနည်းကို သင်ယူမည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/06-http-streaming/README.md)

- **7 VSCode အတွက် AI Toolkit ကို အသုံးပြုခြင်း** MCP Clients နှင့် Servers များကို စမ်းသပ်ရန်နှင့် စစ်ဆေးရန်၊ [သင်ခန်းစာသို့](/03-GettingStarted/07-aitk/README.md)

- **8 စမ်းသပ်ခြင်း**။ ဤနေရာတွင် ဆာဗာနှင့် client များကို မတူညီသောနည်းလမ်းများဖြင့် စမ်းသပ်နည်းကို အထူးအာရုံစိုက်မည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/08-testing/README.md)

- **9 တပ်ဆင်ခြင်း**။ MCP ဖြေရှင်းချက်များကို တပ်ဆင်ရာတွင် မတူညီသောနည်းလမ်းများကို လေ့လာမည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) သည် LLM များအား context ပေးပို့ရာတွင် အသုံးပြုသော စံသတ်မှတ်ထားသော protocol တစ်ခုဖြစ်သည်။ MCP ကို AI application များအတွက် USB-C port တစ်ခုလို ထင်မြင်နိုင်ပြီး၊ AI မော်ဒယ်များကို အချက်အလက်ရင်းမြစ်များနှင့် ကိရိယာများနှင့် ချိတ်ဆက်ရန် စံသတ်မှတ်ထားသော နည်းလမ်းတစ်ခုဖြစ်သည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာပြီးဆုံးချိန်တွင် သင်သည်-

- C#, Java, Python, TypeScript နှင့် JavaScript များအတွက် MCP ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင်များကို တပ်ဆင်နိုင်မည်
- စိတ်ကြိုက် features (resources, prompts, tools) ပါသော MCP ဆာဗာများကို တည်ဆောက်ပြီး တပ်ဆင်နိုင်မည်
- MCP ဆာဗာများနှင့် ချိတ်ဆက်နိုင်သော host application များ ဖန်တီးနိုင်မည်
- MCP အကောင်အထည်ဖော်မှုများကို စမ်းသပ်ပြီး အမှားရှာဖွေနိုင်မည်
- setup ပြဿနာများနှင့် ဖြေရှင်းနည်းများကို နားလည်နိုင်မည်
- MCP အကောင်အထည်ဖော်မှုများကို လူကြိုက်များသော LLM ဝန်ဆောင်မှုများနှင့် ချိတ်ဆက်နိုင်မည်

## MCP ပတ်ဝန်းကျင် တပ်ဆင်ခြင်း

MCP နှင့် အလုပ်လုပ်ရန် မစတင်မီ သင့်ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင်ကို ပြင်ဆင်ထားပြီး အခြေခံ workflow ကို နားလည်ထားခြင်း အရေးကြီးသည်။ ဤအပိုင်းတွင် MCP ဖြင့် စတင်ရန် လိုအပ်သော အဆင့်များကို လမ်းညွှန်ပေးမည်။

### လိုအပ်ချက်များ

MCP ဖွံ့ဖြိုးရေးကို စတင်ရန် မတိုင်မီ-

- **ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင်** - သင့်ရွေးချယ်ထားသော ဘာသာစကား (C#, Java, Python, TypeScript, JavaScript)
- **IDE/Editor** - Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm သို့မဟုတ် ခေတ်မီ code editor များ
- **Package Managers** - NuGet, Maven/Gradle, pip, npm/yarn
- **API Keys** - သင့် host application များတွင် အသုံးပြုမည့် AI ဝန်ဆောင်မှုများအတွက်

### တရားဝင် SDK များ

နောက်ထပ်အခန်းများတွင် Python, TypeScript, Java နှင့် .NET အသုံးပြု၍ ဖန်တီးထားသော ဖြေရှင်းချက်များကို တွေ့မြင်ရမည်။ အောက်တွင် တရားဝင်ထောက်ပံ့ထားသော SDK များအားလုံးပါဝင်သည်။

MCP သည် ဘာသာစကားအမျိုးမျိုးအတွက် တရားဝင် SDK များကို ပံ့ပိုးပေးသည်-
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - တရားဝင် TypeScript အကောင်အထည်ဖော်မှု
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - တရားဝင် Python အကောင်အထည်ဖော်မှု
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - တရားဝင် Kotlin အကောင်အထည်ဖော်မှု
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - တရားဝင် Rust အကောင်အထည်ဖော်မှု

## အဓိက သင်ယူရမည့် အချက်များ

- MCP ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင် တပ်ဆင်ခြင်းသည် ဘာသာစကားအလိုက် SDK များဖြင့် လွယ်ကူသည်
- MCP ဆာဗာများ တည်ဆောက်ရာတွင် ကိရိယာများကို ဖန်တီးပြီး schema များနှင့် မှတ်ပုံတင်ရမည်
- MCP client များသည် ဆာဗာများနှင့် မော်ဒယ်များကို ချိတ်ဆက်ကာ တိုးချဲ့နိုင်သော လုပ်ဆောင်ချက်များကို အသုံးပြုသည်
- စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေရေးသည် MCP အကောင်အထည်ဖော်မှုများအတွက် အရေးကြီးသည်
- တပ်ဆင်ခြင်းရွေးချယ်စရာများမှာ ဒေသတွင်းဖွံ့ဖြိုးရေးမှ cloud အခြေပြု ဖြေရှင်းချက်များအထိ ရှိသည်

## လေ့ကျင့်ခြင်း

ဤအပိုင်းရှိ အခန်းအားလုံးတွင် တွေ့မြင်ရမည့် လေ့ကျင့်ခန်းများနှင့် ကိုက်ညီသော နမူနာများ ရှိသည်။ ထို့အပြင် အခန်းတိုင်းတွင် ကိုယ်ပိုင် လေ့ကျင့်ခန်းများနှင့် တာဝန်များပါဝင်သည်။

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## အပိုဆောင်း အရင်းအမြစ်များ

- [Model Context Protocol အသုံးပြု၍ Azure တွင် Agents ဖန်တီးခြင်း](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps (Node.js/TypeScript/JavaScript) ဖြင့် Remote MCP](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## နောက်တစ်ဆင့်

နောက်တစ်ဆင့်: [သင့်ပထမဆုံး MCP Server ဖန်တီးခြင်း](./01-first-server/README.md)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။