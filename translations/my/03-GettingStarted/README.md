<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "858362ce0118de3fec0f9114bf396101",
  "translation_date": "2025-08-18T18:51:04+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "my"
}
-->
## စတင်ရန်  

[![Build Your First MCP Server](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.my.png)](https://youtu.be/sNDZO9N4m9Y)

_(ဤသင်ခန်းစာ၏ ဗီဒီယိုကို ကြည့်ရန် အထက်ပါ ပုံကို နှိပ်ပါ)_

ဤအပိုင်းတွင် သင်ခန်းစာအချို့ ပါဝင်သည် -

- **1 သင့်ရဲ့ ပထမဆုံး server** - ပထမဆုံး သင်ခန်းစာတွင် သင်၏ ပထမဆုံး server ကို ဖန်တီးနည်းနှင့် inspector tool ကို အသုံးပြု၍ စစ်ဆေးနည်းကို သင်ယူမည်ဖြစ်သည်။ ဤသည်မှာ သင့် server ကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းအတွက် အဖိုးတန်နည်းလမ်းတစ်ခုဖြစ်သည်။ [သင်ခန်းစာသို့](01-first-server/README.md)

- **2 Client** - ဤသင်ခန်းစာတွင် သင့် server နှင့် ချိတ်ဆက်နိုင်သော client တစ်ခုကို ရေးသားနည်းကို သင်ယူမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](02-client/README.md)

- **3 LLM ပါဝင်သော Client** - Client ကို ပိုမိုကောင်းမွန်စွာ ရေးသားရန် LLM ကို ထည့်သွင်းခြင်းဖြင့် သင့် server နှင့် "ညှိနှိုင်း" နိုင်စေရန် သင်ယူမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](03-llm-client/README.md)

- **4 Visual Studio Code တွင် GitHub Copilot Agent mode ဖြင့် server ကို အသုံးပြုခြင်း** - ဤနေရာတွင် Visual Studio Code အတွင်းမှ MCP Server ကို အလုပ်လုပ်စေခြင်းကို လေ့လာမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](04-vscode/README.md)

- **5 SSE (Server Sent Events) မှ အသုံးပြုခြင်း** - SSE သည် server-to-client streaming အတွက် စံသတ်မှတ်ချက်တစ်ခုဖြစ်ပြီး HTTP မှတစ်ဆင့် client များသို့ အချိန်နှင့်တပြေးညီ အပ်ဒိတ်များကို ပို့နိုင်စေသည်။ [သင်ခန်းစာသို့](05-sse-server/README.md)

- **6 MCP ဖြင့် HTTP Streaming (Streamable HTTP)** - ခေတ်မီ HTTP streaming, progress notifications နှင့် Streamable HTTP ကို အသုံးပြု၍ MCP server များနှင့် client များကို မည်သို့ အကျိုးရှိစွာ ဖန်တီးနိုင်မည်ကို သင်ယူမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](06-http-streaming/README.md)

- **7 VSCode အတွက် AI Toolkit အသုံးပြုခြင်း** - သင့် MCP Clients နှင့် Servers ကို စမ်းသပ်ရန် AI Toolkit ကို မည်သို့ အသုံးပြုမည်ကို သင်ယူမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](07-aitk/README.md)

- **8 စမ်းသပ်ခြင်း** - ဤနေရာတွင် သင့် server နှင့် client ကို မျိုးစုံသောနည်းလမ်းများဖြင့် စမ်းသပ်နိုင်မည်ကို အထူးအာရုံစိုက်မည်ဖြစ်သည်။ [သင်ခန်းစာသို့](08-testing/README.md)

- **9 Deployment** - ဤအခန်းတွင် သင့် MCP ဖြေရှင်းချက်များကို မည်သို့ တင်ပို့မည်ဆိုသည်ကို လေ့လာမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](09-deployment/README.md)

Model Context Protocol (MCP) သည် LLM များအား context ပေးရန် အက်ပလီကေးရှင်းများကို စံပြုလုပ်ပေးသည့် ပွင့်လင်း protocol တစ်ခုဖြစ်သည်။ MCP ကို AI အက်ပလီကေးရှင်းများအတွက် USB-C port တစ်ခုလို စဉ်းစားပါ - ၎င်းသည် AI မော်ဒယ်များကို အမျိုးမျိုးသော ဒေတာရင်းမြစ်များနှင့် ကိရိယာများနှင့် ချိတ်ဆက်ရန် စံပြုနည်းလမ်းတစ်ခုကို ပေးသည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာအပြီးတွင် သင်သည် အောက်ပါအရာများကို တတ်မြောက်မည်ဖြစ်သည် -

- C#, Java, Python, TypeScript, JavaScript တို့အတွက် MCP ဖွံ့ဖြိုးရေး ပတ်ဝန်းကျင်များကို စတင်တပ်ဆင်ခြင်း
- အထူးအင်္ဂါရပ်များ (resources, prompts, tools) ပါဝင်သည့် အခြေခံ MCP server များကို ဖန်တီးခြင်းနှင့် တင်ပို့ခြင်း
- MCP server များနှင့် ချိတ်ဆက်နိုင်သည့် host application များ ဖန်တီးခြင်း
- MCP အကောင်အထည်ဖော်မှုများကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်း
- ရှိနေသော စနစ်များနှင့် ချိတ်ဆက်ရာတွင် ကြုံတွေ့နိုင်သည့် စိန်ခေါ်မှုများနှင့် ၎င်းတို့၏ ဖြေရှင်းနည်းများကို နားလည်ခြင်း
- သင့် MCP အကောင်အထည်ဖော်မှုများကို လူကြိုက်များသော LLM ဝန်ဆောင်မှုများနှင့် ချိတ်ဆက်ခြင်း

## သင့် MCP ပတ်ဝန်းကျင်ကို တပ်ဆင်ခြင်း

MCP နှင့် အလုပ်လုပ်ရန် မစတင်မီ သင့်ဖွံ့ဖြိုးရေး ပတ်ဝန်းကျင်ကို ပြင်ဆင်ရန်နှင့် အခြေခံ workflow ကို နားလည်ရန် အရေးကြီးသည်။ ဤအပိုင်းတွင် MCP နှင့် စတင်အလုပ်လုပ်ရာတွင် အဆင်ပြေစေရန် စတင်အဆင့်များကို လမ်းညွှန်ပေးမည်ဖြစ်သည်။

### လိုအပ်ချက်များ

MCP ဖွံ့ဖြိုးရေးကို စတင်မီ သင့်တွင် အောက်ပါအရာများ ရှိရန် လိုအပ်သည် -

- **ဖွံ့ဖြိုးရေး ပတ်ဝန်းကျင်** - သင့်ရွေးချယ်ထားသော programming language (C#, Java, Python, TypeScript, JavaScript) အတွက်
- **IDE/Editor** - Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, သို့မဟုတ် ခေတ်မီ code editor မည်သည့်အရာမဆို
- **Package Managers** - NuGet, Maven/Gradle, pip, npm/yarn
- **API Keys** - သင့် host application များတွင် အသုံးပြုမည့် AI ဝန်ဆောင်မှုများအတွက်

### တရားဝင် SDK များ

လာမည့်အခန်းများတွင် Python, TypeScript, Java, .NET တို့ကို အသုံးပြု၍ ဖန်တီးထားသော ဖြေရှင်းချက်များကို တွေ့မြင်ရမည်။ အောက်တွင် တရားဝင်ထောက်ခံထားသော SDK များကို ဖော်ပြထားသည်။

MCP သည် အမျိုးမျိုးသော programming language များအတွက် တရားဝင် SDK များကို ပံ့ပိုးပေးထားသည် -
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - တရားဝင် TypeScript အကောင်အထည်ဖော်မှု
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - တရားဝင် Python အကောင်အထည်ဖော်မှု
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - တရားဝင် Kotlin အကောင်အထည်ဖော်မှု
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - တရားဝင် Rust အကောင်အထည်ဖော်မှု

## အဓိက အချက်များ

- MCP ဖွံ့ဖြိုးရေး ပတ်ဝန်းကျင်ကို language-specific SDK များဖြင့် လွယ်ကူစွာ တပ်ဆင်နိုင်သည်
- MCP server များကို ဖန်တီးရန်နှင့် tools များကို ရှင်းလင်းသော schema များဖြင့် မှတ်ပုံတင်ရန် လိုအပ်သည်
- MCP client များသည် server များနှင့် မော်ဒယ်များကို ချိတ်ဆက်ပြီး တိုးချဲ့ထားသော စွမ်းရည်များကို အသုံးချနိုင်သည်
- MCP အကောင်အထည်ဖော်မှုများကို ယုံကြည်စိတ်ချစွာ အလုပ်လုပ်စေရန် စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းသည် အရေးကြီးသည်
- Deployment ရွေးချယ်မှုများတွင် ဒေသတွင်းဖွံ့ဖြိုးရေးမှ cloud-based ဖြေရှင်းချက်များအထိ ပါဝင်သည်

## လေ့ကျင့်ခြင်း

ဤအပိုင်းရှိ သင်ခန်းစာများတွင် တွေ့မြင်ရမည့် လေ့ကျင့်မှုများကို ဖြည့်စွက်ပေးသည့် နမူနာများကို ကျွန်ုပ်တို့ ပံ့ပိုးပေးထားပါသည်။ ထို့အပြင် အခန်းတိုင်းတွင် သက်ဆိုင်ရာ လေ့ကျင့်မှုများနှင့် အလုပ်ပေးအပ်ချက်များလည်း ပါဝင်သည်။

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## ထပ်မံသိရှိရန် အရင်းအမြစ်များ

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## နောက်တစ်ဆင့်

နောက်တစ်ဆင့်: [သင့်ရဲ့ ပထမဆုံး MCP Server ဖန်တီးခြင်း](01-first-server/README.md)

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူရင်းဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအမှားများ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။