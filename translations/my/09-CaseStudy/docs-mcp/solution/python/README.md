<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:45:08+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "my"
}
-->
# Study Plan Generator with Chainlit & Microsoft Learn Docs MCP

## မလိုအပ်သော အချက်များ

- Python 3.8 သို့မဟုတ် အထက်
- pip (Python package manager)
- Microsoft Learn Docs MCP ဆာဗာနှင့် ချိတ်ဆက်ရန် အင်တာနက် ချိတ်ဆက်မှု

## တပ်ဆင်ခြင်း

1. ဒီ repository ကို clone လုပ်ပါ သို့မဟုတ် project ဖိုင်များကို ဒေါင်းလုပ်လုပ်ပါ။
2. လိုအပ်သော dependencies များကို တပ်ဆင်ပါ။

   ```bash
   pip install -r requirements.txt
   ```

## အသုံးပြုနည်း

### အခြေအနေ ၁: Docs MCP သို့ ရိုးရှင်းသော မေးခွန်းတစ်ခု

Docs MCP ဆာဗာနှင့် ချိတ်ဆက်ပြီး မေးခွန်းတစ်ခု ပို့၍ ရလဒ်ကို ပြသပေးသော command-line client ဖြစ်သည်။

1. script ကို run ပါ။
   ```bash
   python scenario1.py
   ```
2. prompt တွင် သင့် documentation မေးခွန်းကို ထည့်ပါ။

### အခြေအနေ ၂: Study Plan Generator (Chainlit Web App)

Chainlit ကို အသုံးပြုထားသော web-based interface ဖြစ်ပြီး အသုံးပြုသူများအတွက် နည်းပညာဘာသာရပ်တစ်ခုအတွက် အပတ်စဉ် စီစဉ်ထားသော ကိုယ်ပိုင် သင်ယူအစီအစဉ်ကို ဖန်တီးပေးသည်။

1. Chainlit app ကို စတင်ပါ။
   ```bash
   chainlit run scenario2.py
   ```
2. terminal တွင် ပြသထားသော local URL (ဥပမာ http://localhost:8000) ကို browser တွင် ဖွင့်ပါ။
3. chat ပြတင်းပေါ်တွင် သင်ယူလိုသော ခေါင်းစဉ်နှင့် သင်ယူလိုသည့် အပတ်ရေကို ထည့်ပါ (ဥပမာ "AI-900 certification, 8 weeks")။
4. app သည် အပတ်စဉ်အလိုက် သင်ယူအစီအစဉ်ကို Microsoft Learn documentation များနှင့်အတူ ပြန်လည်ပေးပို့ပါမည်။

**လိုအပ်သော Environment Variables:**

အခြေအနေ ၂ (Chainlit web app နှင့် Azure OpenAI) ကို အသုံးပြုရန် `python` ဖိုလ်ဒါအတွင်း `.env` ဖိုင်တွင် အောက်ပါ environment variables များကို သတ်မှတ်ထားရမည်။

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

app ကို run မလုပ်မီ သင့် Azure OpenAI resource အသေးစိတ်များဖြင့် ဤတန်ဖိုးများကို ဖြည့်စွက်ပါ။

> **Tip:** သင့်ကိုယ်ပိုင် မော်ဒယ်များကို [Azure AI Foundry](https://ai.azure.com/) ဖြင့် လွယ်ကူစွာ တပ်ဆင်နိုင်ပါသည်။

### အခြေအနေ ၃: VS Code တွင် MCP Server ဖြင့် In-Editor Docs

Browser tab မပြောင်းဘဲ Microsoft Learn Docs ကို VS Code အတွင်းမှ တိုက်ရိုက် အသုံးပြုနိုင်ရန် MCP server ကို အသုံးပြုနိုင်သည်။ ၎င်းဖြင့် -

- VS Code အတွင်းမှ တိုက်ရိုက် စာရွက်စာတမ်းများကို ရှာဖွေဖတ်ရှုနိုင်သည်။
- README သို့မဟုတ် သင်တန်းဖိုင်များတွင် တိုက်ရိုက် လင့်ခ်များ ထည့်သွင်းနိုင်သည်။
- GitHub Copilot နှင့် MCP ကို ပေါင်းစပ်အသုံးပြု၍ AI အားဖြင့် စာရွက်စာတမ်းလုပ်ငန်းစဉ်ကို ပိုမိုထိရောက်စေသည်။

**အသုံးပြုမှု ဥပမာများ:**
- သင်တန်း သို့မဟုတ် project documentation ရေးစဉ် README တွင် အမြန် reference လင့်ခ်များ ထည့်သွင်းခြင်း။
- Copilot ဖြင့် ကုဒ်ရေးပြီး MCP ဖြင့် သက်ဆိုင်ရာ docs များကို ချက်ချင်း ရှာဖွေဖော်ပြခြင်း။
- editor အတွင်းတွင် အာရုံစိုက်ပြီး ထုတ်လုပ်မှုမြှင့်တင်ခြင်း။

> [!IMPORTANT]
> သင့် workspace တွင် တရားဝင် [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) configuration ရှိကြောင်း သေချာစေပါ (တည်နေရာမှာ `.vscode/mcp.json`)။

## အခြေအနေ ၂ အတွက် Chainlit ကို ဘာကြောင့် အသုံးပြုသနည်း?

Chainlit သည် စကားပြောဆိုနိုင်သော web application များ ဖန်တီးရန် အဆင့်မြင့် open-source framework ဖြစ်သည်။ Microsoft Learn Docs MCP ဆာဗာကဲ့သို့ backend ဝန်ဆောင်မှုများနှင့် ချိတ်ဆက်နိုင်သော chat-based user interface များကို လွယ်ကူစွာ ဖန်တီးနိုင်စေသည်။ ဤ project သည် Chainlit ကို အသုံးပြု၍ ကိုယ်ပိုင် သင်ယူအစီအစဉ်များကို အချိန်နှင့်တပြေးညီ ဖန်တီးပေးနိုင်သော ရိုးရှင်းပြီး အပြန်အလှန် ဆက်သွယ်နိုင်သော နည်းလမ်းတစ်ခုကို ပံ့ပိုးပေးသည်။ Chainlit ကို အသုံးပြုခြင်းဖြင့် ထုတ်လုပ်မှုနှင့် သင်ယူမှုကို မြှင့်တင်ပေးသော chat-based tools များကို အလျင်အမြန် တည်ဆောက်၍ တပ်ဆင်နိုင်သည်။

## ဤ app သည် ဘာလုပ်ဆောင်သနည်း

ဤ app သည် အသုံးပြုသူများအား ခေါင်းစဉ်နှင့် သင်ယူချိန်ကိုသာ ထည့်သွင်းခြင်းဖြင့် ကိုယ်ပိုင် သင်ယူအစီအစဉ် ဖန်တီးပေးသည်။ app သည် သင့်ရဲ့ input ကို ခွဲခြမ်းစိတ်ဖြာပြီး Microsoft Learn Docs MCP ဆာဗာမှ သက်ဆိုင်ရာ အကြောင်းအရာများကို ရှာဖွေကာ အပတ်စဉ်အလိုက် စီစဉ်ထားသော အစီအစဉ်တစ်ခုအဖြစ် ပြသပေးသည်။ အပတ်တိုင်းအတွက် အကြံပြုချက်များကို chat တွင် ပြသပေးသဖြင့် လိုက်နာရန်နှင့် တိုးတက်မှုကို စောင့်ကြည့်ရန် လွယ်ကူစေသည်။ ဤပေါင်းစပ်မှုကြောင့် နောက်ဆုံးပေါ်၊ သက်ဆိုင်ရာ သင်ယူမှု အရင်းအမြစ်များကို အမြဲရရှိနိုင်ပါသည်။

## နမူနာ မေးခွန်းများ

chat ပြတင်းပေါ်တွင် အောက်ပါ မေးခွန်းများကို စမ်းသပ်ကြည့်ပါ။

- `AI-900 certification, 8 weeks`
- `Learn Azure Functions, 4 weeks`
- `Azure DevOps, 6 weeks`
- `Data engineering on Azure, 10 weeks`
- `Microsoft security fundamentals, 5 weeks`
- `Power Platform, 7 weeks`
- `Azure AI services, 12 weeks`
- `Cloud architecture, 9 weeks`

ဤနမူနာများသည် app ၏ သင်ယူရည်ရွယ်ချက်များနှင့် သင်ယူချိန်ကာလအမျိုးမျိုးအတွက် လိုက်လျောညီထွေမှုကို ပြသသည်။

## ကိုးကားချက်များ

- [Chainlit Documentation](https://docs.chainlit.io/)
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်မှ ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။