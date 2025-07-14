<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:38:58+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "my"
}
-->
# Case Study: Expose REST API in API Management as an MCP server

Azure API Management သည် သင့် API Endpoints များအပေါ်တွင် Gateway တစ်ခုကို ပေးဆောင်သည့် ဝန်ဆောင်မှုဖြစ်သည်။ ၎င်း၏ လုပ်ဆောင်ပုံမှာ Azure API Management သည် သင့် API များရှေ့တွင် proxy အဖြစ် လုပ်ဆောင်ပြီး ဝင်ရောက်လာသော တောင်းဆိုမှုများကို ဘာလုပ်ဆောင်မည်ကို ဆုံးဖြတ်ပေးသည်။

ဒါကို အသုံးပြုခြင်းဖြင့် အောက်ပါ အင်္ဂါရပ်များစွာကို ထည့်သွင်းနိုင်သည်-

- **လုံခြုံရေး** - API keys, JWT မှ managed identity အထိ အားလုံးကို အသုံးပြုနိုင်သည်။
- **Rate limiting** - တစ်ချိန်တည်းတွင် ခေါ်ဆိုမှုများ ဘယ်လောက်ခွင့်ပြုမည်ကို ဆုံးဖြတ်နိုင်ခြင်းသည် အသုံးပြုသူအားလုံးအတွက် ကောင်းမွန်သော အတွေ့အကြုံရရှိစေပြီး သင့်ဝန်ဆောင်မှုကို တောင်းဆိုမှုများကြောင့် မလွန်ကဲစေပါ။
- **Scaling & Load balancing** - အများအပြား endpoint များကို တင်ပို့မှုကို ချိန်ညှိနိုင်ပြီး "load balance" မည်သို့လုပ်မည်ကိုလည်း ဆုံးဖြတ်နိုင်သည်။
- **AI အင်္ဂါရပ်များ** - semantic caching, token limit, token monitoring စသည့် အင်္ဂါရပ်များဖြင့် တုံ့ပြန်မှုမြန်ဆန်စေပြီး token အသုံးစရိတ်ကို ထိန်းချုပ်နိုင်သည်။ [ဒီမှာပိုမိုဖတ်ရှုပါ](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities)။

## Why MCP + Azure API Management?

Model Context Protocol သည် agentic AI apps များအတွက် စံချိန်စံညွှန်းတစ်ခုအဖြစ် မြန်မြန်ဆန်ဆန် ဖြစ်လာပြီး tools နှင့် data များကို တစ်သွေ့တည်း ပြသပေးနိုင်ရန် ဖြစ်သည်။ Azure API Management သည် API များကို "စီမံခန့်ခွဲ" ရန် လိုအပ်သောအခါ သဘာဝကျသော ရွေးချယ်မှုဖြစ်သည်။ MCP Servers များသည် တောင်းဆိုမှုများကို tool တစ်ခုသို့ ဖြေရှင်းရန် အခြား API များနှင့် ပေါင်းစပ်အသုံးပြုလေ့ရှိသည်။ ထို့ကြောင့် Azure API Management နှင့် MCP ကို ပေါင်းစပ်အသုံးပြုခြင်းမှာ အဓိပ္ပါယ်ရှိသည်။

## Overview

ဒီအထူးသဖြင့် ကျွန်ုပ်တို့သည် API endpoints များကို MCP Server အဖြစ် ပြသပေးခြင်းကို သင်ယူမည်။ ၎င်းဖြင့် ဒီ endpoints များကို agentic app တစ်ခု၏ အစိတ်အပိုင်းအဖြစ် လွယ်ကူစွာ ထည့်သွင်းနိုင်ပြီး Azure API Management ၏ အင်္ဂါရပ်များကိုလည်း အသုံးချနိုင်မည်ဖြစ်သည်။

## Key Features

- သင်လိုချင်သည့် endpoint method များကို tools အဖြစ် ရွေးချယ်နိုင်သည်။
- သင်ရရှိမည့် အပိုအင်္ဂါရပ်များမှာ သင့် API အတွက် policy အပိုင်းတွင် သတ်မှတ်ထားသည့် အတိုင်း ဖြစ်သည်။ ဒီမှာတော့ rate limiting ကို ထည့်သွင်းပုံကို ပြသမည်။

## Pre-step: import an API

Azure API Management တွင် API ရှိပြီးသားဖြစ်ပါက ဒီအဆင့်ကို ကျော်လွှားနိုင်သည်။ မရှိပါက ဒီလင့်ခ်ကို ကြည့်ပါ၊ [importing an API to Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api)။

## Expose API as MCP Server

API endpoints များကို ပြသရန် အောက်ပါအဆင့်များကို လိုက်နာပါ-

1. Azure Portal သို့ ဝင်ပြီး <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp> သို့ သွားပါ။ သင့် API Management instance ကို ရွေးချယ်ပါ။

1. ဘယ်ဘက် menu တွင် APIs > MCP Servers > + Create new MCP Server ကို ရွေးချယ်ပါ။

1. API တွင် MCP server အဖြစ် ပြသလိုသော REST API ကို ရွေးချယ်ပါ။

1. Tools အဖြစ် ပြသလိုသော API Operations တစ်ခု သို့မဟုတ် အများကို ရွေးချယ်ပါ။ အားလုံးကို သို့မဟုတ် တစ်ချို့ကိုသာ ရွေးချယ်နိုင်သည်။

    ![Select methods to expose](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create** ကို ရွေးချယ်ပါ။

1. **APIs** နှင့် **MCP Servers** menu ကို သွားပါ၊ အောက်ပါအတိုင်း မြင်ရမည်-

    ![See the MCP Server in the main pane](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP server ကို ဖန်တီးပြီး API operations များကို tools အဖြစ် ပြသထားသည်။ MCP server သည် MCP Servers pane တွင် စာရင်းပြထားသည်။ URL ကော်လံတွင် MCP server ၏ endpoint ကို ပြသထားပြီး စမ်းသပ်ရန် သို့မဟုတ် client application အတွင်း ခေါ်ဆိုနိုင်သည်။

## Optional: Configure policies

Azure API Management တွင် policy များကို သတ်မှတ်နိုင်ပြီး endpoint များအတွက် rate limiting သို့ semantic caching ကဲ့သို့သော စည်းမျဉ်းများကို သတ်မှတ်နိုင်သည်။ ၎င်း policy များကို XML ဖြင့်ရေးသားသည်။

MCP Server အတွက် rate limiting policy ကို သတ်မှတ်ပုံမှာ-

1. Portal တွင် APIs အောက်မှ **MCP Servers** ကို ရွေးချယ်ပါ။

1. ဖန်တီးထားသော MCP server ကို ရွေးချယ်ပါ။

1. ဘယ်ဘက် menu တွင် MCP အောက်မှ **Policies** ကို ရွေးချယ်ပါ။

1. Policy editor တွင် MCP server ၏ tools များအတွက် သတ်မှတ်လိုသော policy များကို ထည့်သွင်း သို့မဟုတ် ပြင်ဆင်ပါ။ Policy များကို XML ပုံစံဖြင့် သတ်မှတ်သည်။ ဥပမာအားဖြင့် MCP server ၏ tools များကို ခေါ်ဆိုမှုများကို ကန့်သတ်ရန် policy တစ်ခု ထည့်သွင်းနိုင်သည် (ဥပမာ - client IP တစ်ခုလျှင် ၃၀ စက္ကန့်အတွင်း ၅ ခေါ်ဆိုမှု)။ အောက်ပါ XML က rate limiting ဖြစ်စေမည်-

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Policy editor ၏ ပုံရိပ်-

    ![Policy editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Try it out

MCP Server သည် ရည်ရွယ်ချက်အတိုင်း လုပ်ဆောင်နေကြောင်း သေချာစေရန်။

ဒါအတွက် Visual Studio Code နှင့် GitHub Copilot ၏ Agent mode ကို အသုံးပြုမည်။ MCP server ကို *mcp.json* ထဲသို့ ထည့်သွင်းမည်ဖြစ်သည်။ ၎င်းဖြင့် Visual Studio Code သည် agentic လုပ်ဆောင်နိုင်သော client အဖြစ် လုပ်ဆောင်ပြီး အသုံးပြုသူများသည် prompt ရိုက်ထည့်ကာ server နှင့် ဆက်သွယ်နိုင်မည်ဖြစ်သည်။

Visual Studio Code တွင် MCP server ထည့်သွင်းပုံ-

1. Command Palette မှ MCP: **Add Server command** ကို အသုံးပြုပါ။

1. Prompt ပေါ်လာသည့်အခါ server အမျိုးအစားကို ရွေးချယ်ပါ- **HTTP (HTTP or Server Sent Events)**။

1. API Management တွင် MCP server ၏ URL ကို ထည့်ပါ။ ဥပမာ- **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE endpoint အတွက်) သို့မဟုတ် **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP endpoint အတွက်)၊ transport မတူညီမှုမှာ `/sse` သို့မဟုတ် `/mcp` ဖြစ်သည်။

1. သင်နှစ်သက်သည့် server ID ကို ထည့်ပါ။ ဤတန်ဖိုးသည် အရေးကြီးမဟုတ်ပေမယ့် server instance ကို မှတ်မိရန် အကူအညီဖြစ်သည်။

1. configuration ကို workspace settings သို့မဟုတ် user settings တွင် သိမ်းမည်ကို ရွေးချယ်ပါ။

  - **Workspace settings** - server configuration ကို .vscode/mcp.json ဖိုင်တွင်သာ သိမ်းဆည်းပြီး လက်ရှိ workspace တွင်သာ အသုံးပြုနိုင်သည်။

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    streaming HTTP ကို transport အဖြစ် ရွေးချယ်ပါက အနည်းငယ်ကွာခြားသည်-

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User settings** - server configuration ကို global *settings.json* ဖိုင်တွင် ထည့်သွင်းပြီး workspace အားလုံးတွင် အသုံးပြုနိုင်သည်။ configuration သည် အောက်ပါအတိုင်း ဖြစ်သည်-

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Azure API Management သို့ မှန်ကန်စွာ authentication ပြုလုပ်ရန် header တစ်ခု ထည့်သွင်းရန် လိုအပ်သည်။ အဲဒါက **Ocp-Apim-Subscription-Key** ဟုခေါ်သည်။

    - settings တွင် ထည့်သွင်းပုံ-

    ![Adding header for authentication](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)၊ ၎င်းသည် API key တန်ဖိုးကို မေးမြန်းရန် prompt တစ်ခုကို ဖော်ပြမည်ဖြစ်ပြီး သင်၏ Azure API Management instance အတွက် Azure Portal တွင် ရှာဖွေနိုင်သည်။

   - *mcp.json* တွင် ထည့်သွင်းရန်-

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Use Agent mode

ယခု settings သို့မဟုတ် *.vscode/mcp.json* တွင် အားလုံး ပြင်ဆင်ပြီးဖြစ်သည်။ စမ်းသပ်ကြည့်ပါ။

Tools icon တစ်ခုရှိမည်၊ သင့် server မှ ပြသထားသော tools များကို စာရင်းပြထားသည်-

![Tools from the server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. tools icon ကို နှိပ်ပြီး အောက်ပါအတိုင်း tools စာရင်းကို မြင်ရမည်-

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. chat တွင် prompt တစ်ခု ထည့်၍ tool ကို ခေါ်ဆိုပါ။ ဥပမာအားဖြင့် အော်ဒါအကြောင်း သိရှိရန် tool တစ်ခု ရွေးချယ်ထားပါက agent ကို အော်ဒါအကြောင်း မေးနိုင်သည်။ ဥပမာ prompt-

    ```text
    get information from order 2
    ```

    ယခု tools icon တစ်ခု ဖော်ပြမည်ဖြစ်ပြီး tool ကို ဆက်လက်ခေါ်ဆိုရန် မေးမည်။ ဆက်လက်အသုံးပြုရန် ရွေးချယ်ပါ၊ အောက်ပါအတိုင်း output ကို မြင်ရမည်-

    ![Result from prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **အထက်ပါ output သည် သင်ပြင်ဆင်ထားသော tools များပေါ် မူတည်သည်၊ သို့သော် အဓိပ္ပါယ်မှာ စာသားဖြင့် တုံ့ပြန်ချက်ရရှိခြင်းဖြစ်သည်။**


## References

ပိုမိုလေ့လာလိုပါက-

- [Tutorial on Azure API Management and MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python sample: Secure remote MCP servers using Azure API Management (experimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP client authorization lab](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Use the Azure API Management extension for VS Code to import and manage APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Register and discover remote MCP servers in Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Azure API Management နှင့် AI အင်္ဂါရပ်များစွာကို ပြသသည့် repo အကောင်းတစ်ခု
- [AI Gateway workshops](https://azure-samples.github.io/AI-Gateway/) Azure Portal ကို အသုံးပြု၍ AI အင်္ဂါရပ်များကို စတင်သုံးသပ်ရန် workshop များပါဝင်သည်။

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အချက်အလက်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ပညာရှင်များ၏ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မခံပါ။