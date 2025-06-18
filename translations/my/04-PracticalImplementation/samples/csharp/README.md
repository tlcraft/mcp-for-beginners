<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:54:20+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "my"
}
-->
# နမူနာ

ယခင်ဥပမာမှာ local .NET ပရောဂျက်ကို `stdio` type နဲ့ ဘယ်လိုသုံးရမယ်၊ နဲ့ container အတွင်းမှာ server ကို locally ဘယ်လို run ရမယ် ဆိုတာကို ပြထားပါတယ်။ အများအပြားအခြေအနေတွေမှာ ဒီနည်းလမ်းက ကောင်းတဲ့ဖြေရှင်းချက်တစ်ခုပါ။ သို့သော် server ကို cloud ပတ်ဝန်းကျင်လို ချိတ်ဆက်ထားတဲ့နေရာကနေ run လုပ်နိုင်ရင် ပိုအသုံးဝင်ပါတယ်။ ဒီမှာတော့ `http` type က အသုံးဝင်လာပါတယ်။

`04-PracticalImplementation` ဖိုလ်ဒါထဲက solution ကိုကြည့်မယ်ဆိုရင် ယခင်နမူနာထက် ပိုရှုပ်ထွေးနေသလို ခံစားရနိုင်ပါတယ်။ ဒါပေမယ့် အမှန်မှာတော့ မဟုတ်ပါဘူး။ `src/Calculator` project ကို သေချာကြည့်မယ်ဆိုရင် ယခင်နမူနာနဲ့ အများအားဖြင့် တူညီတဲ့ code ဖြစ်ကြောင်း တွေ့ရမှာပါ။ ကွာခြားချက်တစ်ခုကတော့ HTTP requests တွေကို ကိုင်တွယ်ဖို့အတွက် `ModelContextProtocol.AspNetCore` ဆိုတဲ့ library ကို အသုံးပြုထားတာပါ။ နောက်ပြီး `IsPrime` method ကို private ပြောင်းထားတာကတော့ သင့် code မှာ private method တွေကိုပါ ထည့်သုံးနိုင်ကြောင်း ပြသဖို့ပါ။ အခြား code တွေက ယခင်နမူနာနဲ့ တူညီပါပဲ။

အခြား project တွေကတော့ [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview) မှာရရှိနိုင်တဲ့ project တွေဖြစ်ပါတယ်။ Solution ထဲမှာ .NET Aspire ပါဝင်ခြင်းက developer တွေအတွက် ဖန်တီးမှုနဲ့ စမ်းသပ်မှုတွေမှာ အတွေ့အကြုံပိုမိုကောင်းမွန်စေပြီး observability ကို ကူညီပေးပါတယ်။ Server ကို run ဖို့ မလိုအပ်ပေမယ့် solution ထဲမှာ ထည့်သွင်းထားတာကောင်းတဲ့ အလေ့အကျင့်တစ်ခုပါ။

## Server ကို locally စတင် run မယ်

1. VS Code (C# DevKit extension နဲ့) မှ `04-PracticalImplementation/samples/csharp` ဖိုလ်ဒါကို သွားပါ။
1. Server စတင်ဖို့အတွက် အောက်ပါ command ကို 실행ပါ။

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. Web browser က .NET Aspire dashboard ကိုဖွင့်လာရင် `http` URL ကို မှတ်ထားပါ။ အဲဒါက `http://localhost:5058/` လိုမျိုးဖြစ်နိုင်ပါတယ်။

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.my.png)

## MCP Inspector နဲ့ Streamable HTTP ကို စမ်းသပ်မယ်

Node.js 22.7.5 နဲ့ အထက်ရှိရင် MCP Inspector ကို သုံးပြီး server ကို စမ်းသပ်နိုင်ပါတယ်။

Server ကို စတင် run လုပ်ပြီး terminal မှာ အောက်ပါ command ကို 실행ပါ။

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.my.png)

- `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp` ကို ရွေးချယ်ပါ။ အဲဒါက `http` ဖြစ်ရမယ် (မဟုတ်ရင် `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` ဆိုပြီး ယခင်ကဖန်တီးထားတဲ့ server မဟုတ်ပါဘူး)။

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

အောက်ပါ စမ်းသပ်မှုတွေကို လုပ်ကြည့်ပါ။

- "6780 နောက်က ၃ ခုသော ပရိုင်းနံပါတ်များ" ကို မေးပါ။ Copilot က `NextFivePrimeNumbers` tool အသစ်ကို သုံးပြီး ပထမ ၃ ခုသာ ပြန်ပေးပါလိမ့်မယ်။
- "111 နောက်က ၇ ခုသော ပရိုင်းနံပါတ်များ" ကို မေးပြီး ဘာဖြစ်မလဲ ကြည့်ပါ။
- "John မှ လိုလီ ၂၄ လုံးရှိပြီး သူ့ကလေး ၃ ယောက်ကို လိုလီတွေကို မျှဝေချင်ပါတယ်။ ကလေးတစ်ယောက်ချင်းစီမှာ လိုလီဘယ်နှစ်လုံးရှိမလဲ?" ကို မေးပြီး ဘာဖြစ်မလဲ ကြည့်ပါ။

## Server ကို Azure ပေါ်သို့ တင်မယ်

ပိုမိုများပြားသောလူတွေ သုံးနိုင်ဖို့ server ကို Azure ပေါ်သို့ တင်ကြမယ်။

Terminal မှာ `04-PracticalImplementation/samples/csharp` ဖိုလ်ဒါကို သွားပြီး အောက်ပါ command ကို 실행ပါ။

```bash
azd up
```

Deploy ပြီးဆုံးတဲ့အခါ အောက်ပါစာသားကဲ့သို့ ပြပါလိမ့်မယ်။

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.my.png)

URL ကို ယူပြီး MCP Inspector နဲ့ GitHub Copilot Chat မှာ အသုံးပြုပါ။

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## နောက်တစ်ခုဘာလဲ?

ကြိုးစားပြီး မတူညီတဲ့ transport type တွေ၊ စမ်းသပ်မှု tools တွေကို သုံးကြည့်ပါတယ်။ MCP server ကို Azure ပေါ်သို့ တင်လည်း ပြီးပါပြီ။ ဒါပေမယ့် server က private resource တွေကို access လုပ်ဖို့လိုလာရင် ဘာဖြစ်မလဲ? ဥပမာ database တစ်ခု သို့မဟုတ် private API တစ်ခုလိုပါ။ နောက်ပိုင်း အခန်းမှာတော့ server ရဲ့ လုံခြုံမှုကို ဘယ်လိုတိုးတက်စေမလဲ ဆိုတာကို ကြည့်ပါမယ်။

**ချက်ချင်းသတိပေးချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်မှုဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ တိကျမှန်ကန်မှုအတွက် ကြိုးစားပေမယ့် အလိုအလျောက်ဘာသာပြန်ခြင်းသည် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန်။ မူရင်းစာတမ်းကို မူရင်းဘာသာဖြင့်သာ အတည်ပြုရမည့် အချက်အလက်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသောအချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်၏ ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုမှုကြောင့် ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။