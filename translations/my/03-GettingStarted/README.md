<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1197b6dbde36773e04a5ae826557fdb9",
  "translation_date": "2025-08-26T18:27:45+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "my"
}
-->
## စတင်ခြင်း  

[![သင့်ရဲ့ ပထမဆုံး MCP Server တည်ဆောက်ပါ](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.my.png)](https://youtu.be/sNDZO9N4m9Y)

_(အထက်ပါ ပုံကို နှိပ်ပြီး ဒီသင်ခန်းစာရဲ့ ဗီဒီယိုကို ကြည့်ပါ)_

ဒီအပိုင်းမှာ သင်ခန်းစာအတော်များများ ပါဝင်ပါတယ်-

- **1 သင့်ရဲ့ ပထမဆုံး server** - ဒီပထမဆုံး သင်ခန်းစာမှာ သင့်ရဲ့ ပထမဆုံး server ကို ဘယ်လိုတည်ဆောက်ရမယ်ဆိုတာ သင်ယူရမှာဖြစ်ပြီး၊ server ကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းအတွက် အသုံးဝင်တဲ့ inspector tool ကို အသုံးပြုရမှာဖြစ်ပါတယ်။ [သင်ခန်းစာကို ဖတ်ရန်](01-first-server/README.md)

- **2 Client** - ဒီသင်ခန်းစာမှာ သင့် server ကို ချိတ်ဆက်နိုင်တဲ့ client ကို ဘယ်လိုရေးရမယ်ဆိုတာ သင်ယူရမှာဖြစ်ပါတယ်။ [သင်ခန်းစာကို ဖတ်ရန်](02-client/README.md)

- **3 Client with LLM** - client ကို ပိုမိုကောင်းမွန်စွာရေးသားဖို့ LLM ကို ထည့်သွင်းပြီး server နဲ့ "ညှိနှိုင်း" လုပ်နိုင်အောင် ပြုလုပ်ခြင်းကို သင်ယူရမှာဖြစ်ပါတယ်။ [သင်ခန်းစာကို ဖတ်ရန်](03-llm-client/README.md)

- **4 Visual Studio Code မှာ GitHub Copilot Agent mode ကို အသုံးပြုပြီး server ကို အသုံးချခြင်း** - ဒီနေရာမှာ MCP Server ကို Visual Studio Code မှာ အလုပ်လုပ်အောင် ပြုလုပ်ခြင်းကို လေ့လာရမှာဖြစ်ပါတယ်။ [သင်ခန်းစာကို ဖတ်ရန်](04-vscode/README.md)

- **5 stdio Transport Server** - stdio transport သည် server-to-client ဆက်သွယ်မှုအတွက် လက်ရှိ specification မှာ အကြံပြုထားတဲ့ စံဖြစ်ပြီး subprocess-based ဆက်သွယ်မှုကို လုံခြုံစွာပေးစွမ်းနိုင်ပါတယ်။ [သင်ခန်းစာကို ဖတ်ရန်](05-stdio-server/README.md)

- **6 MCP နဲ့ HTTP Streaming (Streamable HTTP)** - အခေတ်မီ HTTP streaming, progress notifications, နှင့် Streamable HTTP ကို အသုံးပြုပြီး MCP server နှင့် client များကို scalable, real-time အဖြစ် တည်ဆောက်ခြင်းကို သင်ယူရမှာဖြစ်ပါတယ်။ [သင်ခန်းစာကို ဖတ်ရန်](06-http-streaming/README.md)

- **7 VSCode အတွက် AI Toolkit ကို အသုံးပြုခြင်း** - MCP Clients နှင့် Servers ကို စမ်းသပ်ခြင်းနှင့် အသုံးချခြင်းအတွက် AI Toolkit ကို အသုံးပြုခြင်း။ [သင်ခန်းစာကို ဖတ်ရန်](07-aitk/README.md)

- **8 စမ်းသပ်ခြင်း** - ဒီနေရာမှာ server နှင့် client ကို အမျိုးမျိုးသောနည်းလမ်းများဖြင့် စမ်းသပ်ခြင်းကို အထူးအာရုံစိုက်ပြီး လေ့လာရမှာဖြစ်ပါတယ်။ [သင်ခန်းစာကို ဖတ်ရန်](08-testing/README.md)

- **9 Deployment** - MCP solution များကို deploy လုပ်ခြင်းနည်းလမ်းများကို လေ့လာရမှာဖြစ်ပါတယ်။ [သင်ခန်းစာကို ဖတ်ရန်](09-deployment/README.md)

Model Context Protocol (MCP) သည် LLMs ကို context ပေးစွမ်းခြင်းအတွက် application များကို စံပြုလုပ်ပေးသော open protocol ဖြစ်ပါတယ်။ MCP ကို AI application များအတွက် USB-C port တစ်ခုလို စဉ်းစားနိုင်ပြီး၊ AI models များကို အမျိုးမျိုးသော data sources နှင့် tools များနှင့် ချိတ်ဆက်နိုင်စေသော စံပြုနည်းလမ်းတစ်ခုကို ပေးစွမ်းပါတယ်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာပြီးဆုံးချိန်မှာ သင့်အနေနဲ့ အောက်ပါအရာများကို လုပ်နိုင်ပါမည်-

- C#, Java, Python, TypeScript, နှင့် JavaScript အတွက် MCP development environment များကို စတင်တပ်ဆင်ခြင်း
- resources, prompts, နှင့် tools များကို custom feature အဖြစ် ထည့်သွင်းထားသော MCP servers များကို တည်ဆောက်ခြင်းနှင့် deploy လုပ်ခြင်း
- MCP servers ကို ချိတ်ဆက်နိုင်သော host applications များကို ဖန်တီးခြင်း
- MCP implementations များကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်း
- setup challenges များနှင့် အဖြေများကို နားလည်ခြင်း
- MCP implementations များကို လူကြိုက်များသော LLM services များနှင့် ချိတ်ဆက်ခြင်း

## MCP Environment ကို စတင်တပ်ဆင်ခြင်း

MCP နဲ့ အလုပ်လုပ်မယ့်အခါမှာ သင့် development environment ကို ပြင်ဆင်ထားပြီး workflow အခြေခံကို နားလည်ထားဖို့ အရေးကြီးပါတယ်။ ဒီအပိုင်းမှာ MCP နဲ့ စတင်အလုပ်လုပ်ဖို့အတွက် အဆင်ပြေစေမယ့် စတင်ခြင်းအဆင့်များကို လမ်းညွှန်ပေးပါမည်။

### လိုအပ်ချက်များ

MCP development ကို စတင်မတိုင်မီ အောက်ပါအရာများရှိထားဖို့ လိုအပ်ပါတယ်-

- **Development Environment** - သင်ရွေးချယ်ထားသော programming language (C#, Java, Python, TypeScript, or JavaScript) အတွက်
- **IDE/Editor** - Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, သို့မဟုတ် အခေတ်မီ code editor များ
- **Package Managers** - NuGet, Maven/Gradle, pip, သို့မဟုတ် npm/yarn
- **API Keys** - သင့် host applications တွင် အသုံးပြုမည့် AI services များအတွက်

### တရားဝင် SDK များ

လာမည့် chapter များတွင် Python, TypeScript, Java နှင့် .NET ကို အသုံးပြုထားသော solution များကို တွေ့ရပါမည်။ အောက်မှာ တရားဝင်ထောက်ခံထားသော SDK များကို ဖော်ပြထားပါတယ်။

MCP သည် အမျိုးမျိုးသော programming language များအတွက် တရားဝင် SDK များကို ပေးထားပါသည်-
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - တရားဝင် TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - တရားဝင် Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - တရားဝင် Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - တရားဝင် Rust implementation

## အဓိကအချက်များ

- MCP development environment ကို language-specific SDK များဖြင့် အလွယ်တကူတပ်ဆင်နိုင်သည်
- MCP servers တည်ဆောက်ခြင်းသည် tool များကို ရှင်းလင်းသော schema များဖြင့် ဖန်တီးခြင်းနှင့် register လုပ်ခြင်းကို ပါဝင်သည်
- MCP clients များသည် server များနှင့် models များကို ချိတ်ဆက်ပြီး အကျိုးကျေးဇူးများကို ရယူနိုင်သည်
- MCP implementations များကို စမ်းသပ်ခြင်းနှင့် အမှားရှာဖွေခြင်းသည် ယုံကြည်စိတ်ချရသော အကောင်အထည်ဖော်မှုများအတွက် အရေးကြီးသည်
- Deployment ရွေးချယ်မှုများသည် local development မှ cloud-based solution များအထိ ကွဲပြားသည်

## လေ့ကျင့်ခြင်း

ဒီအပိုင်းရဲ့ သင်ခန်းစာများတွင် exercises များနှင့် assignments များကို ထည့်သွင်းထားပြီး၊ အပိုင်းတိုင်းမှာလည်း သီးသန့် exercises များပါဝင်ပါတယ်။

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## ထပ်ဆောင်းရင်းမြစ်များ

- [Model Context Protocol ကို အသုံးပြုပြီး Azure မှာ Agents တည်ဆောက်ခြင်း](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps (Node.js/TypeScript/JavaScript) ကို အသုံးပြုပြီး Remote MCP](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## နောက်တစ်ခု

နောက်တစ်ခု: [သင့်ရဲ့ ပထမဆုံး MCP Server တည်ဆောက်ခြင်း](01-first-server/README.md)

---

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါရှိနိုင်သည်ကို သတိပြုပါ။ မူရင်းဘာသာစကားဖြင့် ရေးသားထားသော စာရွက်စာတမ်းကို အာဏာတရားရှိသော ရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များကို အသုံးပြု၍ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။