<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2228721599c0c8673de83496b4d7d7a9",
  "translation_date": "2025-08-18T18:34:02+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "my"
}
-->
# ကိစ္စလေ့လာမှု - API Management တွင် REST API ကို MCP Server အဖြစ် ဖော်ထုတ်ခြင်း

Azure API Management သည် သင့် API Endpoints အပေါ်တွင် Gateway တစ်ခုကို ပေးသော ဝန်ဆောင်မှုဖြစ်သည်။ ၎င်း၏ လုပ်ဆောင်ပုံမှာ Azure API Management သည် သင့် API များ၏ ရှေ့တွင် proxy အဖြစ် လုပ်ဆောင်ပြီး ဝင်ရောက်လာသော တောင်းဆိုမှုများကို ဘယ်လို ဆောင်ရွက်မည်ကို ဆုံးဖြတ်နိုင်သည်။

၎င်းကို အသုံးပြုခြင်းဖြင့် အောက်ပါ အကျိုးကျေးဇူးများ ရရှိနိုင်သည်-

- **လုံခြုံမှု** - API key, JWT မှ Managed Identity အထိ အားလုံးကို အသုံးပြုနိုင်သည်။
- **Rate Limiting** - တစ်ခုချိန်ကာလအတွင်း ဘယ်လောက်အရေအတွက် တောင်းဆိုမှုများကို ခွင့်ပြုမည်ကို ဆုံးဖြတ်နိုင်သည်။ ၎င်းသည် အသုံးပြုသူများအားလုံးအတွက် အတွေ့အကြုံကောင်းများ ရရှိစေပြီး သင့်ဝန်ဆောင်မှုကို တောင်းဆိုမှုများကြောင့် များလွန်းခြင်းမှ ကာကွယ်ပေးသည်။
- **အရွယ်အစားချဲ့ထွင်ခြင်းနှင့် Load Balancing** - Load ကို ချိန်ညှိရန် Endpoint အရေအတွက်များကို သတ်မှတ်နိုင်ပြီး "Load Balance" ကို ဘယ်လိုလုပ်မည်ကိုလည်း ဆုံးဖြတ်နိုင်သည်။
- **AI Features** - Semantic Caching, Token Limit နှင့် Token Monitoring စသည်တို့ကို အသုံးပြုနိုင်သည်။ ၎င်းတို့သည် တုံ့ပြန်မှုကို တိုးတက်စေပြီး Token အသုံးပြုမှုကို ထိန်းချုပ်နိုင်ရန် အထောက်အကူပြုသည်။ [ပိုမိုသိရှိရန်](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities)။

## MCP + Azure API Management ကို ဘာကြောင့် အသုံးပြုသင့်သလဲ?

Model Context Protocol သည် Agentic AI Apps များအတွက် စံသတ်မှတ်တစ်ခုအဖြစ် မြန်မြန်ဆန်ဆန် ဖြစ်လာနေသည်။ MCP Servers သည် Tools များနှင့် Data များကို တောင်းဆိုမှုများဖြေရှင်းရန် အခြား API များနှင့် ပေါင်းစည်းလေ့ရှိသည်။ ထို့ကြောင့် Azure API Management နှင့် MCP ကို ပေါင်းစည်းခြင်းသည် အကျိုးရှိစေသည်။

## အကျဉ်းချုပ်

ဤအသုံးပြုမှုအတွက် API Endpoints များကို MCP Server အဖြစ် ဖော်ထုတ်ပုံကို လေ့လာမည်။ ၎င်းအား Agentic App တစ်ခု၏ အစိတ်အပိုင်းအဖြစ် လွယ်ကူစွာ ဖော်ထုတ်နိုင်ပြီး Azure API Management ၏ အကျိုးကျေးဇူးများကိုလည်း ရယူနိုင်သည်။

## အဓိက အင်္ဂါရပ်များ

- သင်ဖော်ထုတ်လိုသော Endpoint Methods များကို ရွေးချယ်နိုင်သည်။
- သင်၏ API Policy အပိုင်းတွင် သတ်မှတ်ထားသော Configuration အပေါ် မူတည်၍ အပိုအင်္ဂါရပ်များ ရရှိနိုင်သည်။ ဤနေရာတွင် Rate Limiting ကို ထည့်သွင်းပုံကို ပြသမည်။

## Pre-step: API တစ်ခုကို Import လုပ်ခြင်း

Azure API Management တွင် API ရှိပြီးသားဖြစ်ပါက ဤအဆင့်ကို ကျော်သွားနိုင်သည်။ မရှိပါက [Azure API Management တွင် API ကို Import လုပ်ခြင်း](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api) ကို ကြည့်ပါ။

## API ကို MCP Server အဖြစ် ဖော်ထုတ်ခြင်း

API Endpoints များကို ဖော်ထုတ်ရန် အောက်ပါအဆင့်များကို လိုက်နာပါ-

1. Azure Portal တွင် <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp> သို့ သွားပါ။ သင့် API Management Instance ကို ရှာပါ။

1. ဘယ်ဘက် Menu တွင် APIs > MCP Servers > + Create new MCP Server ကို ရွေးပါ။

1. API တွင် MCP Server အဖြစ် ဖော်ထုတ်လိုသော REST API ကို ရွေးပါ။

1. Tools အဖြစ် ဖော်ထုတ်လိုသော API Operations များကို ရွေးပါ။ အားလုံးကို ရွေးနိုင်သလို သီးသန့် Operations များကိုသာ ရွေးနိုင်သည်။

    ![Methods ရွေးချယ်ခြင်း](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create** ကို ရွေးပါ။

1. Menu Option **APIs** နှင့် **MCP Servers** သို့ သွားပါ။ အောက်ပါအတိုင်း မြင်ရမည်-

    ![MCP Server ကို Main Pane တွင် မြင်ရမည်](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP Server ကို ဖန်တီးပြီး API Operations များကို Tools အဖြစ် ဖော်ထုတ်ထားသည်။ MCP Servers Pane တွင် MCP Server ကို မြင်ရမည်။ URL Column တွင် MCP Server ကို စမ်းသပ်ရန် သို့မဟုတ် Client Application တွင် အသုံးပြုရန် Endpoint ကို ပြထားသည်။

## Optional: Policies ကို Configure လုပ်ခြင်း

Azure API Management တွင် Policies ဆိုသော အဓိကအကြောင်းအရာရှိပြီး Endpoint များအတွက် Rate Limiting သို့မဟုတ် Semantic Caching စသည်တို့ကို သတ်မှတ်နိုင်သည်။ Policies များကို XML ဖြင့် ရေးသားသည်။

MCP Server အတွက် Rate Limiting Policy ကို သတ်မှတ်ပုံ-

1. Portal တွင် APIs အောက်ရှိ **MCP Servers** ကို ရွေးပါ။

1. ဖန်တီးထားသော MCP Server ကို ရွေးပါ။

1. ဘယ်ဘက် Menu တွင် MCP အောက်ရှိ **Policies** ကို ရွေးပါ။

1. Policy Editor တွင် MCP Server Tools များအတွက် အသုံးပြုလိုသော Policies များကို ထည့်သွင်း သို့မဟုတ် ပြင်ဆင်ပါ။ Policies များကို XML Format ဖြင့် သတ်မှတ်သည်။ ဥပမာအားဖြင့် Client IP Address တစ်ခုလျှင် MCP Server Tools များကို 30 စက္ကန့်အတွင်း 5 ကြိမ်ခွင့်ပြုမည့် Policy ကို ထည့်သွင်းနိုင်သည်။

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Policy Editor ရဲ့ ပုံရိပ်-

    ![Policy Editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)

## စမ်းသပ်ခြင်း

MCP Server သည် ရည်ရွယ်ထားသည့်အတိုင်း လုပ်ဆောင်နေသည်ကို စစ်ဆေးပါ။

ဤအတွက် Visual Studio Code နှင့် GitHub Copilot ၏ Agent Mode ကို အသုံးပြုမည်။ MCP Server ကို *mcp.json* ဖိုင်တွင် ထည့်သွင်းပါမည်။ ၎င်းအား Visual Studio Code တွင် Client အဖြစ် အသုံးပြု၍ End Users များသည် Prompt ရိုက်ထည့်ပြီး Server နှင့် အပြန်အလှန် ဆက်သွယ်နိုင်မည်။

Visual Studio Code တွင် MCP Server ကို ထည့်သွင်းပုံ-

1. Command Palette မှ MCP: **Add Server Command** ကို အသုံးပြုပါ။

1. Server Type ကို **HTTP (HTTP or Server Sent Events)** အဖြစ် ရွေးပါ။

1. API Management တွင် MCP Server URL ကို ထည့်သွင်းပါ။ ဥပမာ- **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE Endpoint အတွက်) သို့မဟုတ် **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP Endpoint အတွက်)၊ Transport အတွက် `/sse` သို့မဟုတ် `/mcp` ကွာခြားမှုကို သတိပြုပါ။

1. Server ID ကို သင်ရွေးချယ်ပါ။ ၎င်းသည် အရေးကြီးသောတန်ဖိုးမဟုတ်သော်လည်း Server Instance ကို မှတ်မိရန် အထောက်အကူပြုသည်။

1. Configuration ကို Workspace Settings သို့မဟုတ် User Settings တွင် သိမ်းဆည်းမည်ကို ရွေးပါ။

  - **Workspace Settings** - Server Configuration ကို *mcp.json* ဖိုင်တွင် သိမ်းဆည်းပြီး လက်ရှိ Workspace တွင်သာ ရရှိနိုင်သည်။

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    Streaming HTTP ကို Transport အဖြစ် ရွေးပါက အနည်းငယ် ကွာခြားမည်-

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User Settings** - Server Configuration ကို Global *settings.json* ဖိုင်တွင် ထည့်သွင်းပြီး Workspace အားလုံးတွင် ရရှိနိုင်သည်။ Configuration သည် အောက်ပါအတိုင်း ဖြစ်မည်-

    ![User Setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Azure API Management သို့ Authentication လုပ်ရန် Header ကို ထည့်သွင်းရန် လိုအပ်သည်။ ၎င်းသည် **Ocp-Apim-Subscription-Key** Header ကို အသုံးပြုသည်။

    - Settings တွင် Header ကို ထည့်သွင်းပုံ-

    ![Authentication Header ထည့်သွင်းခြင်း](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)၊ API Key Value ကို Azure Portal တွင် ရှာနိုင်သည်။

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

### Agent Mode ကို အသုံးပြုခြင်း

Settings သို့မဟုတ် *.vscode/mcp.json* တွင် အားလုံးကို Set Up ပြီးပါပြီ။ စမ်းသပ်ကြည့်ပါ။

Tools Icon ကို အောက်ပါအတိုင်း မြင်ရမည်-

![Server Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Tools Icon ကို Click လုပ်ပါ။ Tools များ၏ စာရင်းကို အောက်ပါအတိုင်း မြင်ရမည်-

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Chat တွင် Prompt ရိုက်ထည့်ပြီး Tool ကို Invoke လုပ်ပါ။ ဥပမာအားဖြင့် Order အကြောင်းကို သိရန် Tool ကို ရွေးထားပါက Agent ကို Order အကြောင်း မေးနိုင်သည်။ Prompt ဥပမာ-

    ```text
    get information from order 2
    ```

    Tools Icon ကို Click လုပ်ပြီး Tool ကို Run လုပ်ရန် ရွေးပါ။ Output ကို အောက်ပါအတိုင်း မြင်ရမည်-

    ![Prompt Result](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **အထက်ပါ Output သည် သင် Setup လုပ်ထားသော Tools များပေါ်မူတည်ပြီး Textual Response အဖြစ် ရရှိမည်**

## References

ပိုမိုသိရှိရန်-

- [Azure API Management နှင့် MCP Tutorial](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python Sample: Azure API Management ဖြင့် Remote MCP Servers ကို လုံခြုံစွာ အသုံးပြုခြင်း](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)
- [MCP Client Authorization Lab](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)
- [Visual Studio Code Extension ဖြင့် Azure API Management ကို Import နှင့် Manage လုပ်ခြင်း](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)
- [Azure API Center တွင် Remote MCP Servers ကို Register နှင့် Discover လုပ်ခြင်း](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) - Azure API Management နှင့် AI အင်္ဂါရပ်များကို ပြသသော Repo
- [AI Gateway Workshops](https://azure-samples.github.io/AI-Gateway/) - Azure Portal အသုံးပြု၍ AI အင်္ဂါရပ်များကို စမ်းသပ်ရန် Workshop များ

**အကြောင်းကြားချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူရင်းဘာသာစကားဖြင့် ရေးသားထားသော စာရွက်စာတမ်းကို အာဏာတရားရှိသော ရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ဘာသာပြန်ပညာရှင်များမှ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော အလွဲအလွတ်များ သို့မဟုတ် အနားလွဲမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။