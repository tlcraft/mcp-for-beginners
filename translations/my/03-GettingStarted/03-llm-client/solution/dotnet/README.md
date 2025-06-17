<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-06-17T16:50:04+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "my"
}
-->
# ဤနမူနာကို chạyပါ

> [!NOTE]
> ဤနမူနာသည် GitHub Codespaces instance ကို အသုံးပြုနေသည်ဟု သတ်မှတ်ထားသည်။ သင်သည် ဒေသတွင်းတွင် chạyလိုပါက GitHub တွင် ကိုယ်ပိုင် access token တစ်ခု ပြုလုပ်ထားရမည်။

## စာကြည့်တိုက်များ ထည့်သွင်းပါ

```sh
dotnet restore
```

အောက်ပါ စာကြည့်တိုက်များကို ထည့်သွင်းသင့်သည် - Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol 

## chạy

```sh 
dotnet run
```

အောက်ပါအတိုင်း အထွက်ရလဒ် တစ်ခုကို တွေ့ရမည် -

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

ထွက်ရှိလာသော အပိုင်းများအများစုမှာ debugging အတွက် ဖြစ်ပေမယ့် အရေးကြီးတာက MCP Server မှ ကိရိယာများကို စာရင်းပြုစုပြီး အဲဒီကိရိယာတွေကို LLM ကိရိယာများအဖြစ် ပြောင်းလဲခြင်းဖြစ်ပြီး နောက်ဆုံးတွင် MCP client ၏ "Sum 6" ဆိုတဲ့ တုံ့ပြန်ချက်ရရှိခြင်း ဖြစ်သည်။

**မှတ်ချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် မှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်သည်ကို ကျေးဇူးပြု၍ သတိပြုပါ။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်သူ တတ်ကျွမ်းသူမှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုရာမှ ဖြစ်ပေါ်နိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့ တာဝန်မယူပါ။