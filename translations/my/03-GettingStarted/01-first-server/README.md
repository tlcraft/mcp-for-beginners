<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f01d4263fc6eec331615fef42429b720",
  "translation_date": "2025-06-18T18:28:39+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "my"
}
-->
### -2- ပရောဂျက်တစ်ခုဖန်တီးခြင်း

SDK ကိုတပ်ဆင်ပြီးသွားပြီဆိုရင်၊ အခုတော့ ပရောဂျက်တစ်ခုဖန်တီးကြရအောင်။

### -3- ပရောဂျက်ဖိုင်များဖန်တီးခြင်း

### -4- ဆာဗာကုဒ်ရေးခြင်း

### -5- ကိရိယာတစ်ခုနှင့် အရင်းအမြစ်တစ်ခုထည့်ခြင်း

အောက်ပါကုဒ်ကိုထည့်သွင်းခြင်းဖြင့် ကိရိယာတစ်ခုနှင့် အရင်းအမြစ်တစ်ခုကို ထည့်ပါ။

### -6- နောက်ဆုံးကုဒ်

ဆာဗာကိုစတင်နိုင်ဖို့အတွက် လိုအပ်သည့် နောက်ဆုံးကုဒ်ကို ထည့်သွင်းကြရအောင်။

### -7- ဆာဗာစစ်ဆေးခြင်း

အောက်ပါ command ဖြင့် ဆာဗာကို စတင်ပါ။

### -8- Inspector ဖြင့် အလုပ်လုပ်ခြင်း

Inspector သည် သင့်ဆာဗာကို စတင်ပေးပြီး၊ အလုပ်လုပ်မှုကို စမ်းသပ်နိုင်စေသော ကောင်းမွန်သောကိရိယာတစ်ခုဖြစ်သည်။ စတင်ကြည့်ရအောင်။

> သတိပေးချက်  
> "command" ကွက်တွင် သင့်ရဲ့ runtime အလိုက် ဆာဗာကို ပြေးဆွဲရန် command ပါဝင်သဖြင့် ပုံစံက မတူနိုင်ပါ။

အောက်ပါ အသုံးပြုသူအင်တာဖေ့စ်ကို မြင်ရပါမည်-

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.my.png)

1. Connect ခလုတ်ကိုနှိပ်၍ ဆာဗာနှင့် ချိတ်ဆက်ပါ။  
  ချိတ်ဆက်ပြီးနောက် အောက်ပါအတိုင်း မြင်ရပါမည်-

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.my.png)

2. "Tools" နှင့် "listTools" ကိုရွေးချယ်ပါ၊ "Add" ဟူသော ရွေးချယ်စရာပေါ်လာမည်၊ "Add" ကိုနှိပ်ပြီး parameter အချက်အလက်များ ဖြည့်ပါ။

  အောက်ပါ တုံ့ပြန်မှုကို မြင်ရပါမည်၊ "add" ကိရိယာမှရရှိသော ရလဒ်ဖြစ်သည်-

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.my.png)

ဂုဏ်ပြုပါသည်၊ သင့်ရဲ့ ပထမဆုံးဆာဗာကို ဖန်တီးပြီး ပြေးဆွဲနိုင်ခဲ့ပါပြီ။

### တရားဝင် SDK များ

MCP သည် ဘာသာစကားအမျိုးမျိုးအတွက် တရားဝင် SDK များကို ပံ့ပိုးပေးသည်-

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - တရားဝင် TypeScript အကောင်အထည်ဖော်မှု
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - တရားဝင် Python အကောင်အထည်ဖော်မှု
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - တရားဝင် Kotlin အကောင်အထည်ဖော်မှု
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI နှင့် ပူးပေါင်းထိန်းသိမ်းထားသည်
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - တရားဝင် Rust အကောင်အထည်ဖော်မှု

## အဓိက သိထားရမည့်အချက်များ

- MCP ဖွံ့ဖြိုးရေးပတ်ဝန်းကျင် တည်ဆောက်ခြင်းသည် ဘာသာစကားအလိုက် SDK များဖြင့် လွယ်ကူသည်
- MCP ဆာဗာများကို ကိရိယာများနှင့် schema များသတ်မှတ်ပြီး ဖန်တီးရမည်
- စမ်းသပ်ခြင်းနှင့် ပြင်ဆင်ခြင်းသည် MCP အကောင်အထည်ဖော်မှုများအတွက် မရှိမဖြစ်လိုအပ်သည်

## နမူနာများ

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## လေ့ကျင့်ခန်း

သင်နှစ်သက်ရာ ကိရိယာတစ်ခုပါရှိသော MCP ဆာဗာလေးတစ်ခု ဖန်တီးပါ-

1. သင်နှစ်သက်ရာ ဘာသာစကား (.NET, Java, Python, သို့မဟုတ် JavaScript) ဖြင့် ကိရိယာကို အကောင်အထည်ဖော်ပါ။
2. input parameter များနှင့် return value များကို သတ်မှတ်ပါ။
3. inspector ကိရိယာကို အသုံးပြု၍ ဆာဗာအလုပ်လုပ်မှုကို စစ်ဆေးပါ။
4. အမျိုးမျိုးသော input များဖြင့် အကောင်အထည်ဖော်မှုကို စမ်းသပ်ပါ။

## ဖြေရှင်းချက်

[ဖြေရှင်းချက်](./solution/README.md)

## နောက်ထပ်အရင်းအမြစ်များ

- [Model Context Protocol အသုံးပြုပြီး Azure ပေါ်တွင် Agent များ ဖန်တီးခြင်း](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Azure Container Apps တွင် Remote MCP (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## နောက်တစ်ခု

နောက်တစ်ခု: [MCP Clients နှင့် စတင်အသုံးပြုခြင်း](/03-GettingStarted/02-client/README.md)

**အချက်ပေးချက်**  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှုဖြစ်သော [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားပေမယ့် အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်သည်ကို သတိပြုပါရန် အသိပေးအပ်ပါသည်။ မူရင်းစာရွက်စာတမ်းကို မူလဘာသာဖြင့်သာ ယုံကြည်စိတ်ချရသော အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ကျွမ်းကျင်သူမှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်လာသော နားလည်မှုအမှားများ သို့မဟုတ် မှားယွင်းချက်များအတွက် ကျွန်ုပ်တို့မှာ တာဝန်မယူပါ။