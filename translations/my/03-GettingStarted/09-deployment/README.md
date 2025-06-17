<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-17T16:40:01+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "my"
}
-->
# MCP ဆာဗာများ တပ်ဆင်ခြင်း

သင့် MCP ဆာဗာကို တပ်ဆင်ခြင်းဖြင့် အခြားသူများသည် သင့်၏ tools နှင့် အရင်းအမြစ်များကို ကိုယ်ပိုင်ပတ်ဝန်းကျင်အပြင်မှလည်း အသုံးပြုနိုင်မည်ဖြစ်သည်။ တပ်ဆင်မှုအတွက် မျိုးစုံသောနည်းလမ်းများ ရှိပြီး၊ သင့်လိုအပ်ချက်များဖြစ်သည့် တိုးချဲ့နိုင်မှု၊ ယုံကြည်စိတ်ချရမှုနှင့် စီမံခန့်ခွဲရလွယ်ကူမှုတို့အပေါ်မူတည်၍ ရွေးချယ်နိုင်ပါသည်။ အောက်တွင် MCP ဆာဗာများကို ကိုယ်ပိုင်စက်တွင်၊ container များတွင်နှင့် cloud တွင် တပ်ဆင်ခြင်းဆိုင်ရာ လမ်းညွှန်ချက်များကို တွေ့ရှိနိုင်ပါသည်။

## အနှစ်ချုပ်

ဒီသင်ခန်းစာတွင် သင့် MCP Server app ကို မည်သို့ တပ်ဆင်ရမည်ကို ဖော်ပြထားသည်။

## သင်ယူရမည့် ရည်မှန်းချက်များ

ဒီသင်ခန်းစာအပြီးတွင် သင်သည် အောက်ပါအရာများကို လုပ်နိုင်မည်ဖြစ်သည်-

- တပ်ဆင်မှုနည်းလမ်း များကို သုံးသပ်နိုင်ခြင်း။
- သင့် app ကို တပ်ဆင်နိုင်ခြင်း။

## ကိုယ်ပိုင်ဖွံ့ဖြိုးမှုနှင့် တပ်ဆင်ခြင်း

သင့်ဆာဗာကို အသုံးပြုသူ၏ စက်ပေါ်တွင် လည်ပတ်ရန် ရည်ရွယ်ပါက အောက်ပါ အဆင့်များကို လိုက်နာနိုင်သည်-

1. **ဆာဗာကို ဒေါင်းလုတ်လုပ်ပါ။** သင်ဆာဗာကို မရေးသားထားပါက ပထမဦးဆုံး သင့်စက်ထဲသို့ ဒေါင်းလုတ်လုပ်ပါ။
1. **ဆာဗာလုပ်ငန်းစဉ်ကို စတင်ပါ။** သင့် MCP ဆာဗာ application ကို လည်ပတ်ပါ။

SSE အတွက် (stdio type ဆာဗာအတွက် မလိုအပ်ပါ)

1. **ကွန်ယက်ဆက်သွယ်မှုကို ပြင်ဆင်ပါ။** ဆာဗာကို မျှော်မှန်းထားသော port တွင် လက်လှမ်းမီနိုင်စေရန် သေချာပါစေ။
1. **ဖောက်သည်များကို ချိတ်ဆက်ပါ။** `http://localhost:3000` ကဲ့သို့သော ကိုယ်ပိုင်ချိတ်ဆက် URL များကို အသုံးပြုပါ။

## Cloud တပ်ဆင်ခြင်း

MCP ဆာဗာများကို မျိုးစုံသော cloud ပလက်ဖောင်းများတွင် တပ်ဆင်နိုင်သည်-

- **Serverless Functions**: ပေါ့ပေါ့ပါးပါး MCP ဆာဗာများကို serverless functions အဖြစ် တပ်ဆင်ခြင်း
- **Container Services**: Azure Container Apps, AWS ECS, သို့မဟုတ် Google Cloud Run ကဲ့သို့ ဝန်ဆောင်မှုများကို အသုံးပြုခြင်း
- **Kubernetes**: MCP ဆာဗာများကို Kubernetes cluster များတွင် တပ်ဆင်ပြီး မြင့်မားသော ရရှိနိုင်မှုအတွက် စီမံခန့်ခွဲခြင်း

### ဥပမာ - Azure Container Apps

Azure Container Apps သည် MCP ဆာဗာများ တပ်ဆင်မှုကို ပံ့ပိုးပေးသည်။ ယခုအချိန်တွင် အလုပ်တစ်စိတ်တစ်ပိုင်းသာပြီး SSE ဆာဗာများကို ပံ့ပိုးပေးနေသည်။

လုပ်ဆောင်နည်းမှာ-

1. Repo တစ်ခုကို clone လုပ်ပါ-

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. စမ်းသပ်ရန် ကိုယ်ပိုင်စက်တွင် လည်ပတ်ပါ-

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. ကိုယ်ပိုင်စက်တွင် စမ်းသပ်ရန် *.vscode* ဖိုလ်ဒါအတွင်း *mcp.json* ဖိုင်တစ်ခု ဖန်တီးပြီး အောက်ပါ အကြောင်းအရာထည့်ပါ-

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  SSE ဆာဗာ စတင်လည်ပတ်ပြီးနောက် JSON ဖိုင်တွင် play icon ကို နှိပ်နိုင်ပြီး ယခု GitHub Copilot မှ ဆာဗာပေါ်ရှိ tools များကို သိမ်းဆည်းထားသည်ကို Tool icon တွင် မြင်ရမည်ဖြစ်သည်။

1. တပ်ဆင်ရန် အောက်ပါ command ကို ရိုက်ထည့်ပါ-

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

ဒီလိုနဲ့ ကိုယ်ပိုင်စက်ပေါ်တွင် တပ်ဆင်ခြင်း၊ Azure သို့ တပ်ဆင်ခြင်းကို အဆင့်ဆင့် လုပ်ဆောင်နိုင်ပါပြီ။

## နောက်ထပ် အရင်းအမြစ်များ

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps ဆောင်းပါး](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## နောက်တစ်ဆင့်

- နောက်တစ်ဆင့် - [Practical Implementation](/04-PracticalImplementation/README.md)

**စာပို့ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးပမ်းနေသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မှန်ကန်မှုလျော့နည်းမှုများ ရှိနိုင်ကြောင်း သတိပြုပါရန် တောင်းဆိုအပ်ပါသည်။ မူရင်းစာရွက်စာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် ကျွမ်းကျင်သော လူသားဘာသာပြန်ဝန်ဆောင်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းကြောင့် ဖြစ်ပေါ်နိုင်သည့် နားလည်မှုမှားခြင်း သို့မဟုတ် အဓိပ္ပာယ်မှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့တာဝန်မခံပါ။