<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-17T16:35:36+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "my"
}
-->
## စတင်ခြင်း  

ဤအပိုင်းတွင် သင်ခန်းစာအချို့ ပါဝင်သည်-

- **1 သင်၏ ပထမဆုံး ဆာဗာ**, ပထမဆုံးသင်ခန်းစာတွင် သင်၏ ပထမဆုံး ဆာဗာကို ဖန်တီးနည်းနှင့် inspector tool ဖြင့် စစ်ဆေးနည်းကို သင်ယူမည်ဖြစ်သည်၊ ၎င်းသည် သင်၏ ဆာဗာကို စမ်းသပ်ပြီး အမှားရှာဖွေရန် အထောက်အကူပြုသည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, ဤသင်ခန်းစာတွင် သင်၏ ဆာဗာနှင့် ချိတ်ဆက်နိုင်သော client ရေးသားနည်းကို သင်ယူမည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/02-client/README.md)

- **3 Client with LLM**, client ရေးသားခြင်း၏ ပိုမိုကောင်းမွန်သည့် နည်းလမ်းမှာ LLM ကို ထည့်သွင်းခြင်းဖြစ်ပြီး ဆာဗာနှင့် "ညှိနှိုင်း" ပြုလုပ်နိုင်သည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/03-llm-client/README.md)

- **4 Consuming a server GitHub Copilot Agent mode in Visual Studio Code**။ ဤနေရာတွင် Visual Studio Code မှတဆင့် MCP Server ကို လည်ပတ်ခြင်းကို ကြည့်ရှုမည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/04-vscode/README.md)

- **5 Consuming from a SSE (Server Sent Events)** SSE သည် ဆာဗာမှ client သို့ အချက်အလက်များကို အချိန်နှင့်တပြေးညီ ပေးပို့နိုင်သော စံသတ်မှတ်ချက်တစ်ခုဖြစ်သည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming with MCP (Streamable HTTP)**။ ခေတ်မှီ HTTP streaming၊ တိုးတက်မှု အသိပေးချက်များနှင့် Streamable HTTP အသုံးပြု၍ MCP ဆာဗာနှင့် client များကို scalable real-time နည်းဖြင့် တည်ဆောက်နည်းကို သင်ယူမည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/06-http-streaming/README.md)

- **7 Utilising AI Toolkit for VSCode** MCP Clients နှင့် Servers များကို စမ်းသပ်ရန်နှင့် အသုံးပြုရန်၊ [သင်ခန်းစာသို့](/03-GettingStarted/07-aitk/README.md)

- **8 Testing**။ ဤနေရာတွင် ဆာဗာနှင့် client များကို မတူညီသောနည်းလမ်းများဖြင့် စမ်းသပ်နည်းကို အထူးအာရုံစိုက်မည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**။ MCP ဖြေရှင်းချက်များကို တင်သွင်းခြင်း၏ မတူညီသောနည်းလမ်းများကို လေ့လာမည်၊ [သင်ခန်းစာသို့](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) သည် LLM များအတွက် context ပေးပို့ပုံကို စံချိန်ညှိထားသည့် ဖွင့်လှစ်ထားသော protocol တစ်ခုဖြစ်သည်။ MCP ကို AI application များအတွက် USB-C port တစ်ခုလို ထင်မြင်နိုင်ပြီး AI မော်ဒယ်များကို မတူညီသော ဒေတာအရင်းအမြစ်များနှင့် ကိရိယာများနှင့် ချိတ်ဆက်ရန် စံချိန်ညှိထားသည့် နည်းလမ်းတစ်ခုဖြစ်သည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာပြီးဆုံးသည်နှင့်အတူ သင်သည် -

- C#, Java, Python, TypeScript နှင့် JavaScript များတွင် MCP အတွက် ဖွံ့ဖြိုးတိုးတက်ရေး ပတ်ဝန်းကျင်များကို တပ်ဆင်နိုင်မည်
- အခြေခံ MCP ဆာဗာများကို စိတ်ကြိုက် လုပ်ဆောင်ချက်များ (resources, prompts, tools) ဖြင့် တည်ဆောက်ပြီး တင်သွင်းနိုင်မည်
- MCP ဆာဗာများနှင့် ချိတ်ဆက်နိုင်သော host application များ ဖန်တီးနိုင်မည်
- MCP ကို စမ်းသပ်ပြီး အမှားရှာဖွေနိုင်မည်
- setup အခက်အခဲများနှင့် ဖြေရှင်းနည်းများကို နားလည်နိုင်မည်
- MCP implementation များကို လူကြိုက်များသော LLM ဝန်ဆောင်မှုများနှင့် ချိတ်ဆက်နိုင်မည်

## MCP ပတ်ဝန်းကျင် ကို စတင်တပ်ဆင်ခြင်း

MCP ဖြင့် အလုပ်လုပ်ရန် မစတင်မီ သင့်ဖွံ့ဖြိုးတိုးတက်ရေး ပတ်ဝန်းကျင်ကို ပြင်ဆင်ထားပြီး အခြေခံ workflow ကို နားလည်ထားရန် အရေးကြီးသည်။ ဤအပိုင်းတွင် MCP နှင့် အဆင်ပြေစွာ စတင်နိုင်ရန် အခြေခံတပ်ဆင်ခြင်း လုပ်ဆောင်ချက်များကို လမ်းညွှန်မည်။

### လိုအပ်ချက်များ

MCP ဖွံ့ဖြိုးတိုးတက်ရေး စတင်ရန် မတက်မီ အောက်ပါအချက်များ ရှိရှိစစ်ဆေးပါ-

- **ဖွံ့ဖြိုးတိုးတက်ရေး ပတ်ဝန်းကျင်** - သင်ရွေးချယ်ထားသော ဘာသာစကားအတွက် (C#, Java, Python, TypeScript, JavaScript)
- **IDE/Editor** - Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm သို့မဟုတ် ခေတ်မီသော code editor မည်သည့်မျိုးမဆို
- **Package Managers** - NuGet, Maven/Gradle, pip, npm/yarn များ
- **API Keys** - သင်၏ host application များတွင် အသုံးပြုမည့် AI ဝန်ဆောင်မှုများအတွက်

### တရားဝင် SDK များ

လာမည့်အခန်းများတွင် Python, TypeScript, Java နှင့် .NET ကို အသုံးပြု၍ ဖြေရှင်းချက်များ ဖန်တီးထားမည်။ အောက်တွင် တရားဝင်ထောက်ပံ့ထားသော SDK များအားလုံး ပါဝင်သည်။

MCP သည် ဘာသာစကားစုံအတွက် တရားဝင် SDK များကို ပံ့ပိုးပေးသည်-

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - တရားဝင် TypeScript အကောင်အထည်ဖော်မှု
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - တရားဝင် Python အကောင်အထည်ဖော်မှု
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - တရားဝင် Kotlin အကောင်အထည်ဖော်မှု
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - တရားဝင် Rust အကောင်အထည်ဖော်မှု

## အဓိက သင်ယူရမည့်အချက်များ

- MCP ဖွံ့ဖြိုးတိုးတက်ရေး ပတ်ဝန်းကျင် တပ်ဆင်ခြင်းမှာ ဘာသာစကားအလိုက် SDK များဖြင့် လွယ်ကူသည်
- MCP ဆာဗာများ တည်ဆောက်ရာတွင် ကိရိယာများကို ရှင်းလင်းသော schema များဖြင့် ဖန်တီးပြီး မှတ်ပုံတင်ရမည်
- MCP client များသည် ဆာဗာနှင့် မော်ဒယ်များကို ချိတ်ဆက်၍ တိုးချဲ့ထားသော စွမ်းဆောင်ရည်များကို အသုံးပြုသည်
- စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေရေးသည် MCP implementation များအတွက် မဖြစ်မနေ လိုအပ်သည်
- တင်သွင်းခြင်းရွေးချယ်စရာများမှာ ဒေသတွင်းဖွံ့ဖြိုးတိုးတက်ရေးမှ မိုးကောင်းကင်အခြေပြု ဖြေရှင်းချက်များအထိ ရွေးချယ်နိုင်သည်

## လေ့ကျင့်မှု

ဤအပိုင်းရှိ အခန်းတိုင်းတွင် တွေ့မြင်ရမည့် လေ့ကျင့်ခန်းများနှင့် အတူ ပုံမှန်နမူနာများကို မျှဝေထားသည်။ ထို့ပြင် အခန်းတိုင်းတွင် ကိုယ်ပိုင် လေ့ကျင့်ခန်းများနှင့် အလုပ်များလည်း ပါဝင်သည်-

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## အပိုဆောင်း ရင်းမြစ်များ

- [Model Context Protocol ဖြင့် Azure တွင် Agents တည်ဆောက်ခြင်း](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps (Node.js/TypeScript/JavaScript) ဖြင့် Remote MCP](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## နောက်တစ်ဆင့်

နောက်တစ်ဆင့်: [သင်၏ ပထမ MCP ဆာဗာ ဖန်တီးခြင်း](/03-GettingStarted/01-first-server/README.md)

**ကြေညာချက်**  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဆော့ဖ်ဝဲဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးပမ်းသည်ဖြစ်သော်လည်း၊ စက်ရုပ်ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံပါသည်။ မူရင်းစာရွက်စာတမ်းကို သဘာဝဘာသာဖြင့်သာ အတည်ပြုရမည့် အချက်အလက်အရင်းအမြစ်အဖြစ် သတ်မှတ်ထားသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် များသောအားဖြင့် လူ့ဘာသာပြန် ဝန်ဆောင်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုအသုံးပြုမှုမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။