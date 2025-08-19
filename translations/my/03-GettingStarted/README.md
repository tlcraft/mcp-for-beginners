<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "858362ce0118de3fec0f9114bf396101",
  "translation_date": "2025-08-19T18:48:54+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "my"
}
-->
## စတင်ခြင်း  

[![Build Your First MCP Server](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.my.png)](https://youtu.be/sNDZO9N4m9Y)

_(အထက်ပါပုံကိုနှိပ်ပြီး ဒီသင်ခန်းစာ၏ ဗီဒီယိုကိုကြည့်ပါ)_

ဤအပိုင်းတွင် သင်ခန်းစာအချို့ပါဝင်သည်-

- **1 သင့်ရဲ့ ပထမဆုံး server** - ဒီပထမဆုံးသင်ခန်းစာမှာ သင့်ရဲ့ ပထမဆုံး server ကို ဘယ်လိုဖန်တီးရမလဲ၊ Inspector tool ကို အသုံးပြုပြီး ဘယ်လိုစစ်ဆေးရမလဲ၊ သင့် server ကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းအတွက် အရေးကြီးတဲ့နည်းလမ်းတစ်ခုဖြစ်တဲ့ [သင်ခန်းစာ](01-first-server/README.md) ကိုလေ့လာပါ။

- **2 Client** - ဒီသင်ခန်းစာမှာ သင့် server နဲ့ ချိတ်ဆက်နိုင်တဲ့ client ကို ဘယ်လိုရေးရမလဲ [သင်ခန်းစာ](02-client/README.md) ကိုလေ့လာပါ။

- **3 Client with LLM** - Client ကို ပိုမိုကောင်းမွန်စေဖို့ LLM ကို ထည့်သွင်းပြီး သင့် server နဲ့ "ညှိနှိုင်း" လုပ်နိုင်အောင် ဘယ်လိုရေးရမလဲ [သင်ခန်းစာ](03-llm-client/README.md) ကိုလေ့လာပါ။

- **4 Visual Studio Code မှာ GitHub Copilot Agent mode နဲ့ server ကို အသုံးပြုခြင်း** - ဒီမှာတော့ Visual Studio Code ထဲကနေ MCP Server ကို ဘယ်လို run လုပ်ရမလဲ [သင်ခန်းစာ](04-vscode/README.md) ကိုလေ့လာပါ။

- **5 SSE (Server Sent Events) မှ server ကို အသုံးပြုခြင်း** - SSE သည် server-to-client streaming အတွက် စံသတ်မှတ်ချက်တစ်ခုဖြစ်ပြီး HTTP မှတစ်ဆင့် client များကို အချိန်နှင့်တပြေးညီ update များကို push လုပ်ပေးနိုင်သည် [သင်ခန်းစာ](05-sse-server/README.md) ကိုလေ့လာပါ။

- **6 MCP နဲ့ HTTP Streaming (Streamable HTTP)** - ခေတ်မီ HTTP streaming, progress notifications, MCP server နှင့် client များကို Streamable HTTP အသုံးပြုပြီး ဘယ်လို scale လုပ်ရမလဲ [သင်ခန်းစာ](06-http-streaming/README.md) ကိုလေ့လာပါ။

- **7 VSCode အတွက် AI Toolkit အသုံးပြုခြင်း** - MCP Clients နှင့် Servers ကို စမ်းသပ်ရန် [သင်ခန်းစာ](07-aitk/README.md) ကိုလေ့လာပါ။

- **8 စမ်းသပ်ခြင်း** - ဒီမှာတော့ server နဲ့ client ကို အမျိုးမျိုးသောနည်းလမ်းများဖြင့် စမ်းသပ်ပုံကို အထူးပြုလေ့လာပါမည် [သင်ခန်းစာ](08-testing/README.md) ကိုလေ့လာပါ။

- **9 Deployment** - MCP solutions များကို deployment လုပ်နိုင်သော နည်းလမ်းများကို လေ့လာပါမည် [သင်ခန်းစာ](09-deployment/README.md) ကိုလေ့လာပါ။  

Model Context Protocol (MCP) သည် LLM များကို context ပေးရန် အပလီကေးရှင်းများအကြား စံပြုလုပ်ပေးသော open protocol တစ်ခုဖြစ်သည်။ MCP ကို AI အပလီကေးရှင်းများအတွက် USB-C port တစ်ခုလိုထင်ရမည် - ဒါဟာ AI models များကို အမျိုးမျိုးသော data sources နှင့် tools များနှင့် ချိတ်ဆက်ပေးနိုင်သော စံပြုနည်းလမ်းတစ်ခုဖြစ်သည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာအဆုံးတွင် သင်တတ်မြောက်ထားမည့်အရာများမှာ-

- C#, Java, Python, TypeScript, JavaScript အတွက် MCP development environments များကို စတင်တပ်ဆင်ခြင်း
- အထူး features (resources, prompts, tools) များပါဝင်သော MCP servers များကို ဖန်တီးခြင်းနှင့် deploy လုပ်ခြင်း
- MCP servers များနှင့် ချိတ်ဆက်နိုင်သော host applications များကို ဖန်တီးခြင်း
- MCP implementations များကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်း
- အများဆုံးတွေ့ရသော setup ပြဿနာများနှင့် ၎င်းတို့၏ ဖြေရှင်းနည်းများကို နားလည်ခြင်း
- MCP implementations များကို လူကြိုက်များသော LLM services များနှင့် ချိတ်ဆက်ခြင်း

## သင့် MCP ပတ်ဝန်းကျင်ကို စတင်တပ်ဆင်ခြင်း

MCP ကို စတင်လုပ်ဆောင်မီ သင့် development environment ကို ပြင်ဆင်ထားပြီး workflow အခြေခံကို နားလည်ထားရန် အရေးကြီးသည်။ ဒီအပိုင်းမှာ MCP ကို စတင်အသုံးပြုရာတွင် အဆင်ပြေစေရန် အခြေခံတပ်ဆင်ခြင်းအဆင့်များကို လမ်းညွှန်ပေးပါမည်။

### လိုအပ်ချက်များ

MCP development ကို စတင်မီ သင့်တွင် အောက်ပါအရာများရှိရမည်-

- **Development Environment**: သင့်ရွေးချယ်ထားသော programming language (C#, Java, Python, TypeScript, JavaScript) အတွက်
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, သို့မဟုတ် မည်သည့်ခေတ်မီ code editor မဆို
- **Package Managers**: NuGet, Maven/Gradle, pip, သို့မဟုတ် npm/yarn
- **API Keys**: သင့် host applications တွင် အသုံးပြုမည့် AI services များအတွက်

### တရားဝင် SDK များ

လာမည့်အခန်းများတွင် Python, TypeScript, Java, .NET အသုံးပြုထားသော solutions များကို တွေ့ရမည်။ အောက်တွင် တရားဝင်ထောက်ခံထားသော SDK များကို ဖော်ပြထားသည်-

MCP သည် အမျိုးမျိုးသော programming languages အတွက် တရားဝင် SDK များကို ပံ့ပိုးပေးထားသည်-
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - တရားဝင် TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - တရားဝင် Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - တရားဝင် Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - တရားဝင် Rust implementation

## အဓိကအချက်များ

- MCP development environment တပ်ဆင်ခြင်းသည် language-specific SDK များဖြင့် လွယ်ကူသည်
- MCP servers ဖန်တီးခြင်းတွင် ရှင်းလင်းသော schemas များဖြင့် tools များကို ဖန်တီးပြီး register လုပ်ရမည်
- MCP clients များသည် servers နှင့် models များကို ချိတ်ဆက်ပြီး အကျိုးကျေးဇူးများကို ရယူသည်
- MCP implementations များကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းသည် ယုံကြည်စိတ်ချရသောအတွက် အရေးကြီးသည်
- Deployment ရွေးချယ်စရာများတွင် ဒေသတွင်း development မှ cloud-based solutions အထိပါဝင်သည်

## လေ့ကျင့်ခြင်း

ဤအပိုင်းရှိ သင်ခန်းစာများတွင် exercises များနှင့် assignment များပါဝင်သည့်ตัวอย่างများကို ထည့်သွင်းထားသည်။ ထို့အပြင် အခန်းတိုင်းတွင်လည်း သီးသန့် exercises များပါဝင်သည်-

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## ထပ်မံလေ့လာရန် အရင်းအမြစ်များ

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## နောက်တစ်ခု

နောက်တစ်ခု: [သင့်ရဲ့ ပထမဆုံး MCP Server ဖန်တီးခြင်း](01-first-server/README.md)

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါရှိနိုင်သည်ကို သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူရင်းဘာသာစကားဖြင့် အာဏာတရားရှိသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။