<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "858362ce0118de3fec0f9114bf396101",
  "translation_date": "2025-08-18T23:28:22+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "my"
}
-->
## စတင်ခြင်း  

[![သင့်ရဲ့ ပထမဆုံး MCP Server တည်ဆောက်ခြင်း](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.my.png)](https://youtu.be/sNDZO9N4m9Y)

_(ဤသင်ခန်းစာ၏ ဗီဒီယိုကို ကြည့်ရန် အထက်ပါ ပုံကို နှိပ်ပါ)_

ဤအပိုင်းတွင် သင်ခန်းစာများစွာ ပါဝင်သည်-

- **1 သင့်ရဲ့ ပထမဆုံး server** - ပထမဆုံး သင်ခန်းစာတွင် သင့်ရဲ့ ပထမဆုံး server ကို တည်ဆောက်နည်းနှင့် inspector tool ကို အသုံးပြု၍ စစ်ဆေးနည်းကို သင်ယူမည်ဖြစ်သည်။ ဤ tool သည် server ကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းအတွက် အထူးအသုံးဝင်သည်။ [သင်ခန်းစာသို့](01-first-server/README.md)

- **2 Client** - ဤသင်ခန်းစာတွင် သင့် server နှင့် ချိတ်ဆက်နိုင်သော client ကို ရေးသားနည်းကို သင်ယူမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](02-client/README.md)

- **3 Client with LLM** - Client ကို ပိုမိုကောင်းမွန်စွာ ရေးသားရန် LLM ကို ထည့်သွင်းခြင်းဖြင့် server နှင့် "ညှိနှိုင်း" နိုင်စေမည့် နည်းလမ်းကို သင်ယူမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](03-llm-client/README.md)

- **4 Visual Studio Code တွင် GitHub Copilot Agent mode ဖြင့် server ကို အသုံးပြုခြင်း** - MCP Server ကို Visual Studio Code မှာ အလုပ်လုပ်စေခြင်းကို လေ့လာမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](04-vscode/README.md)

- **5 SSE (Server Sent Events) မှ server ကို အသုံးပြုခြင်း** - SSE သည် server-to-client streaming အတွက် စံသတ်မှတ်ဖြစ်ပြီး HTTP မှတဆင့် client များကို အချိန်နှင့်တပြေးညီ update များကို push လုပ်နိုင်စေသည်။ [သင်ခန်းစာသို့](05-sse-server/README.md)

- **6 MCP ဖြင့် HTTP Streaming (Streamable HTTP)** - ခေတ်မီ HTTP streaming, progress notifications နှင့် Streamable HTTP ကို အသုံးပြု၍ MCP server နှင့် client များကို အကျိုးရှိစွာ တည်ဆောက်နည်းကို သင်ယူမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](06-http-streaming/README.md)

- **7 VSCode အတွက် AI Toolkit ကို အသုံးပြုခြင်း** - MCP Clients နှင့် Servers ကို စမ်းသပ်ရန် AI Toolkit ကို အသုံးပြုနည်းကို လေ့လာမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](07-aitk/README.md)

- **8 စမ်းသပ်ခြင်း** - ဤအပိုင်းတွင် server နှင့် client ကို အမျိုးမျိုးသောနည်းလမ်းများဖြင့် စမ်းသပ်နည်းကို အထူးအာရုံစိုက်မည်ဖြစ်သည်။ [သင်ခန်းစာသို့](08-testing/README.md)

- **9 Deployment** - MCP solution များကို deploy လုပ်နည်းအမျိုးမျိုးကို လေ့လာမည်ဖြစ်သည်။ [သင်ခန်းစာသို့](09-deployment/README.md)

Model Context Protocol (MCP) သည် LLM များကို context ပေးရန် application များအတွက် စံသတ်မှတ်ထားသော open protocol ဖြစ်သည်။ MCP ကို AI application များအတွက် USB-C port တစ်ခုလို စဉ်းစားနိုင်သည် - AI models များကို data sources နှင့် tools များနှင့် ချိတ်ဆက်ရန် စံနည်းလမ်းတစ်ခုကို ပေးသည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဤသင်ခန်းစာ၏ အဆုံးတွင် သင်သည်-

- C#, Java, Python, TypeScript, JavaScript များအတွက် MCP development environment များကို စတင်တပ်ဆင်နိုင်မည်
- အထူး feature (resources, prompts, tools) များပါဝင်သော MCP server များကို တည်ဆောက်ပြီး deploy လုပ်နိုင်မည်
- MCP server များနှင့် ချိတ်ဆက်နိုင်သော host application များကို ဖန်တီးနိုင်မည်
- MCP implementation များကို စမ်းသပ်ပြီး အမှားရှာဖွေနိုင်မည်
- အများဆုံးတွေ့ရသော setup အခက်အခဲများနှင့် ၎င်းတို့၏ ဖြေရှင်းနည်းများကို နားလည်နိုင်မည်
- MCP implementation များကို လူကြိုက်များသော LLM service များနှင့် ချိတ်ဆက်နိုင်မည်

## MCP Environment ကို တပ်ဆင်ခြင်း

MCP နှင့် အလုပ်လုပ်ရန် မစတင်မီ သင့် development environment ကို ပြင်ဆင်ပြီး အခြေခံ workflow ကို နားလည်ရန် အရေးကြီးသည်။ ဤအပိုင်းတွင် MCP ကို စတင်အသုံးပြုရန် လိုအပ်သော အဆင့်များကို လမ်းညွှန်ပေးမည်ဖြစ်သည်။

### လိုအပ်ချက်များ

MCP development ကို စတင်မီ သင့်တွင် အောက်ပါအရာများရှိရန် လိုအပ်သည်-

- **Development Environment**: သင့်ရွေးချယ်ထားသော programming language (C#, Java, Python, TypeScript, JavaScript) အတွက်
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, သို့မဟုတ် ခေတ်မီ code editor များ
- **Package Managers**: NuGet, Maven/Gradle, pip, npm/yarn
- **API Keys**: Host application များတွင် အသုံးပြုမည့် AI service များအတွက်

### တရားဝင် SDK များ

လာမည့်အခန်းများတွင် Python, TypeScript, Java, .NET ကို အသုံးပြု၍ တည်ဆောက်ထားသော solution များကို တွေ့ရမည်။ အောက်ပါသည် တရားဝင်ထောက်ခံထားသော SDK များဖြစ်သည်-

MCP သည် အမျိုးမျိုးသော programming language များအတွက် တရားဝင် SDK များကို ပေးသည်-
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - တရားဝင် TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - တရားဝင် Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - တရားဝင် Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - တရားဝင် Rust implementation

## အဓိကအချက်များ

- MCP development environment ကို language-specific SDK များဖြင့် ရိုးရှင်းစွာ တပ်ဆင်နိုင်သည်
- MCP server များကို tool များကို schema ရှင်းလင်းစွာ ဖော်ပြပြီး register လုပ်ခြင်းဖြင့် တည်ဆောက်သည်
- MCP client များသည် server များနှင့် model များကို ချိတ်ဆက်ပြီး အကျိုးကျေးဇူးများကို ရယူသည်
- MCP implementation များကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းသည် ယုံကြည်စိတ်ချရသော အကောင်အထည်ဖော်မှုအတွက် အရေးကြီးသည်
- Deployment ရွေးချယ်မှုများသည် local development မှ cloud-based solution များအထိ ကွဲပြားသည်

## လေ့ကျင့်ခြင်း

ဤအပိုင်းတွင် ပါဝင်သော သင်ခန်းစာများ၏ လေ့ကျင့်ခန်းများနှင့် အတူ သင်ခန်းစာများကို ဖြည့်စွက်ပေးသော sample များရှိသည်-

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## ထပ်ဆောင်းရင်းမြစ်များ

- [Azure တွင် Model Context Protocol ကို အသုံးပြု၍ Agent များ တည်ဆောက်ခြင်း](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps (Node.js/TypeScript/JavaScript) ဖြင့် Remote MCP](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## အခုနောက်

နောက်တစ်ခု- [သင့်ရဲ့ ပထမဆုံး MCP Server တည်ဆောက်ခြင်း](01-first-server/README.md)

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ဆိုမှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်ပါသည်။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပြန်ဆိုမှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပာယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။