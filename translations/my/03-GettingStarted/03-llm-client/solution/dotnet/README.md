<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c40c54fa74ded9c223bc0ebfc8a2de7c",
  "translation_date": "2025-06-18T06:11:48+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "my"
}
-->
# ဒီနမူနာကို chạy ပါ

> [!NOTE]
> ဒီနမူနာက GitHub Codespaces instance ကိုသုံးထားတယ်လို့ ထင်ထားတာပါ။ ဒါကို ကိုယ်ပိုင်စက်မှာ chạy မယ်ဆိုရင် GitHub မှာ personal access token (PAT) တစ်ခု ပြင်ဆင်ထားရပါမယ်။
>
> ```bash
> # zsh/bash
> export GITHUB_TOKEN="{{YOUR_GITHUB_PAT}}"
> ```
>
> ```powershell
> # PowerShell
> $env:GITHUB_TOKEN = "{{YOUR_GITHUB_PAT}}"
> ```

## စာကြည့်တိုက်များ ထည့်သွင်းခြင်း

```sh
dotnet restore
```

အောက်ပါ စာကြည့်တိုက်များကို ထည့်သွင်းရမည် - Azure AI Inference, Azure Identity, Microsoft.Extension, Model.Hosting, ModelContextProtcol

## chạy

```sh 
dotnet run
```

အောက်ပါကဲ့သို့ output တစ်ခုကို မြင်ရမည်ဖြစ်သည် -

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

output အများစုက debugging အတွက်ပဲ ဖြစ်ပေမယ့် အရေးကြီးတာက MCP Server မှ tools တွေကို စာရင်းပြုစုထားတာ၊ အဲဒါတွေကို LLM tools တွေဖြစ်အောင် ပြောင်းပြီး နောက်ဆုံးမှာ MCP client ရဲ့ "Sum 6" ဆိုတဲ့ အဖြေကို ရရှိနေတာပါ။

**ကြေညာချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှုအတွက် ကြိုးစားပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် တောင်းဆိုပါသည်။ မူရင်းစာတမ်းကို မူလဘာသာဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် မည်သည့်အခါတွင်မဆို ပရော်ဖက်ရှင်နယ် လူ့ဘာသာပြန်မှုကို အသုံးပြုရန် အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်နိုင်သည့် နားလည်မှုမှားယွင်းမှုများ သို့မဟုတ် မှားယွင်းဖတ်ရှုမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။