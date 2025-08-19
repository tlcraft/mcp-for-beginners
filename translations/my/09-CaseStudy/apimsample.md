<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2228721599c0c8673de83496b4d7d7a9",
<<<<<<< HEAD
  "translation_date": "2025-08-18T23:12:28+00:00",
=======
  "translation_date": "2025-08-18T18:34:02+00:00",
>>>>>>> origin/main
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "my"
}
-->
<<<<<<< HEAD
# ကိစ္စလေ့လာမှု: API Management တွင် REST API ကို MCP Server အဖြစ် ဖော်ထုတ်ခြင်း

Azure API Management သည် သင့် API Endpoints များအပေါ်တွင် Gateway တစ်ခုအဖြစ် လုပ်ဆောင်ပေးသည့် ဝန်ဆောင်မှုတစ်ခုဖြစ်သည်။ ၎င်းသည် သင့် API များ၏ ရှေ့တွင် proxy တစ်ခုအဖြစ် လုပ်ဆောင်ပြီး ဝင်ရောက်လာသည့် တောင်းဆိုမှုများကို မည်သို့ ကိုင်တွယ်မည်ကို ဆုံးဖြတ်ပေးသည်။

၎င်းကို အသုံးပြုခြင်းဖြင့် အောက်ပါအတိုင်း အထောက်အကူပြုသော လုပ်ဆောင်ချက်များစွာကို ထည့်သွင်းနိုင်သည်-

- **လုံခြုံရေး** - API key, JWT မှစ၍ managed identity အထိ အသုံးပြုနိုင်သည်။
- **Rate Limiting** - တစ်ချိန်ကာလအတွင်း ဘယ်နှစ်ခေါ်ဆိုမှုများကို ခွင့်ပြုမည်ကို ဆုံးဖြတ်နိုင်သည်။ ၎င်းသည် အသုံးပြုသူများအားလုံးအတွက် အတွေ့အကြုံကောင်းများပေးနိုင်ပြီး သင့်ဝန်ဆောင်မှုကို တောင်းဆိုမှုများကြောင့် မလွှမ်းမိုးစေပါ။
- **အရွယ်အစားချဲ့ထွင်ခြင်းနှင့် Load Balancing** - Endpoints များစွာကို သတ်မှတ်ပြီး Load ကို မည်သို့ ချိန်ညှိမည်ကို ဆုံးဖြတ်နိုင်သည်။
- **AI Features** - semantic caching, token limit, token monitoring စသည်တို့ဖြင့် တုံ့ပြန်မှုမြန်ဆန်မှုကို တိုးတက်စေပြီး သင့် token အသုံးစရိတ်ကို ထိန်းချုပ်နိုင်သည်။ [ပိုမိုသိရှိရန်](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities)။

## MCP + Azure API Management ကို ဘာကြောင့် ရွေးချယ်သင့်သလဲ?

Model Context Protocol (MCP) သည် agentic AI အက်ပ်များနှင့် tools နှင့် data များကို တစ်ရိုးတည်းဖြင့် ဖော်ထုတ်ရန် စံနှုန်းတစ်ခုအဖြစ် မြန်မြန်ဆန်ဆန် ဖြစ်လာနေသည်။ Azure API Management သည် API များကို "စီမံခန့်ခွဲ" ရန် လိုအပ်သောအခါ သဘာဝကျသော ရွေးချယ်မှုတစ်ခုဖြစ်သည်။ MCP Servers များသည် tool တစ်ခုကို ဖြေရှင်းရန် အခြား API များနှင့် အများအားဖြင့် ပေါင်းစည်းလေ့ရှိသည်။ ထို့ကြောင့် Azure API Management နှင့် MCP ကို ပေါင်းစည်းခြင်းသည် အလွန် make sense ဖြစ်သည်။

## အနှစ်ချုပ်

ဤအထူးသတ်မှတ်ထားသော use case တွင် API endpoints များကို MCP Server အဖြစ် ဖော်ထုတ်ရန် လေ့လာမည်ဖြစ်သည်။ ၎င်းအားဖြင့် သင့် endpoints များကို agentic app တစ်ခု၏ အစိတ်အပိုင်းတစ်ခုအဖြစ် လွယ်ကူစွာ ထည့်သွင်းနိုင်ပြီး Azure API Management ၏ အကျိုးကျေးဇူးများကိုလည်း ရယူနိုင်မည်ဖြစ်သည်။

## အဓိက အင်္ဂါရပ်များ

- သင့် tools အဖြစ် ဖော်ထုတ်လိုသည့် endpoint methods များကို ရွေးချယ်နိုင်သည်။
- သင့် API အတွက် policy အပိုင်းတွင် သတ်မှတ်ထားသည့် အရာများပေါ်မူတည်၍ ထပ်ဆင့်အင်္ဂါရပ်များ ရရှိမည်ဖြစ်သည်။ ဤနေရာတွင် rate limiting ကို မည်သို့ ထည့်သွင်းရမည်ကို ပြသမည်။

## ကြိုတင်အဆင့်: API တစ်ခုကို တင်သွင်းခြင်း

Azure API Management တွင် API တစ်ခုရှိပြီးသားဖြစ်ပါက ဤအဆင့်ကို ကျော်သွားနိုင်သည်။ မရှိသေးပါက ဤလင့်ခ်ကို ကြည့်ပါ - [importing an API to Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api)။

## API ကို MCP Server အဖြစ် ဖော်ထုတ်ခြင်း

API endpoints များကို ဖော်ထုတ်ရန် အောက်ပါအဆင့်များကို လိုက်နာပါ-

1. Azure Portal သို့ သွားပြီး <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp> သို့ ဝင်ပါ။ သင့် API Management instance သို့ သွားပါ။

1. ဘယ်ဘက်မီနူးတွင် APIs > MCP Servers > + Create new MCP Server ကို ရွေးပါ။

1. API တွင် MCP server အဖြစ် ဖော်ထုတ်လိုသည့် REST API ကို ရွေးပါ။

1. Tools အဖြစ် ဖော်ထုတ်လိုသည့် API Operations တစ်ခု သို့မဟုတ် အများအပြားကို ရွေးပါ။ အားလုံး သို့မဟုတ် သီးသန့် operations များကိုသာ ရွေးနိုင်သည်။

    ![Select methods to expose](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. **Create** ကို ရွေးပါ။

1. မီနူးအတွက် **APIs** နှင့် **MCP Servers** သို့ သွားပါ၊ အောက်ပါအတိုင်း မြင်ရမည်ဖြစ်သည်-

    ![See the MCP Server in the main pane](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP server ကို ဖန်တီးပြီး API operations များကို tools အဖြစ် ဖော်ထုတ်ထားသည်။ MCP Servers pane တွင် MCP server ကို တွေ့နိုင်သည်။ URL ကော်လံတွင် MCP server ၏ endpoint ကို ဖော်ပြထားပြီး client application သို့မဟုတ် စမ်းသပ်မှုအတွက် ခေါ်နိုင်သည်။

## အလိုအလျောက်: Policies ကို သတ်မှတ်ခြင်း

Azure API Management တွင် policies ဆိုသည့် အဓိကအယူအဆတစ်ခုရှိပြီး သင့် endpoints များအတွက် rate limiting သို့မဟုတ် semantic caching စသည်တို့ကို သတ်မှတ်နိုင်သည်။ ဤ policies များကို XML ဖြင့် ရေးသားသည်။

MCP Server အတွက် rate limit policy တစ်ခုကို မည်သို့ သတ်မှတ်ရမည်ကို ကြည့်ပါ-

1. Portal တွင် APIs အောက်ရှိ **MCP Servers** ကို ရွေးပါ။

1. ဖန်တီးထားသော MCP server ကို ရွေးပါ။

1. ဘယ်ဘက်မီနူးတွင် MCP အောက်ရှိ **Policies** ကို ရွေးပါ။

1. Policy editor တွင် MCP server ၏ tools များအတွက် အသုံးပြုလိုသည့် policies များကို ထည့်သွင်း သို့မဟုတ် ပြင်ဆင်ပါ။ Policies များကို XML format ဖြင့် သတ်မှတ်သည်။ ဥပမာအားဖြင့် MCP server ၏ tools များကို client IP တစ်ခုစီအတွက် 30 စက္ကန့်အတွင်း 5 ခေါ်ဆိုမှုအထိ ကန့်သတ်ရန် policy တစ်ခု ထည့်နိုင်သည်။ ဤ XML သည် rate limit ဖြစ်စေမည်-
=======
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
>>>>>>> origin/main

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

<<<<<<< HEAD
    Policy editor ၏ ပုံရိပ်-

    ![Policy editor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)

## စမ်းသပ်ကြည့်ပါ

MCP Server သည် ရည်ရွယ်သည့်အတိုင်း လုပ်ဆောင်နေကြောင်း သေချာစေရန် စမ်းသပ်ကြည့်ပါ။

ဤအတွက် Visual Studio Code နှင့် GitHub Copilot ၏ Agent mode ကို အသုံးပြုမည်ဖြစ်သည်။ MCP server ကို *mcp.json* ဖိုင်တွင် ထည့်သွင်းပါမည်။ ၎င်းအားဖြင့် Visual Studio Code သည် client အဖြစ် လုပ်ဆောင်ပြီး end users များသည် prompt တစ်ခု ရိုက်ထည့်ကာ server နှင့် အပြန်အလှန် ဆက်သွယ်နိုင်မည်ဖြစ်သည်။

Visual Studio Code တွင် MCP server ကို ထည့်သွင်းရန်-

1. Command Palette မှ MCP: **Add Server command** ကို အသုံးပြုပါ။

1. Server type ကို ရွေးပါ: **HTTP (HTTP or Server Sent Events)**။

1. API Management တွင် MCP server ၏ URL ကို ထည့်သွင်းပါ။ ဥပမာ- **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE endpoint အတွက်) သို့မဟုတ် **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP endpoint အတွက်)၊ transport အတွက် `/sse` သို့မဟုတ် `/mcp` အဖြစ် ကွဲပြားမှုကို သတိပြုပါ။

1. Server ID ကို သင့်စိတ်ကြိုက် ထည့်သွင်းပါ။ ၎င်းသည် အရေးကြီးသောတန်ဖိုးမဟုတ်သော်လည်း server instance ကို မှတ်မိရန် အထောက်အကူပြုမည်။

1. Configuration ကို workspace settings သို့မဟုတ် user settings တွင် သိမ်းဆည်းမည်ကို ရွေးပါ-

  - **Workspace settings** - Server configuration ကို .vscode/mcp.json ဖိုင်တွင် သိမ်းဆည်းပြီး လက်ရှိ workspace တွင်သာ ရနိုင်သည်။
=======
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
>>>>>>> origin/main

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

<<<<<<< HEAD
    သို့မဟုတ် streaming HTTP ကို transport အဖြစ် ရွေးပါက အနည်းငယ်ကွဲပြားမည်-
=======
    Streaming HTTP ကို Transport အဖြစ် ရွေးပါက အနည်းငယ် ကွာခြားမည်-
>>>>>>> origin/main

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

<<<<<<< HEAD
  - **User settings** - Server configuration ကို သင့် global *settings.json* ဖိုင်တွင် ထည့်သွင်းပြီး အားလုံး workspace များတွင် ရနိုင်သည်။ Configuration သည် အောက်ပါအတိုင်း ဖြစ်မည်-

    ![User setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Azure API Management သို့ authentication ပြုလုပ်ရန် header တစ်ခု ထည့်သွင်းရန် လိုအပ်သည်။ ၎င်းသည် **Ocp-Apim-Subscription-Key** header ကို အသုံးပြုသည်။

    - Settings တွင် ထည့်သွင်းရန် နည်းလမ်း-

    ![Adding header for authentication](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)၊ ၎င်းသည် API key တန်ဖိုးကို Azure Portal တွင် သင့် Azure API Management instance အတွက် ရယူရန် prompt ပြမည်။
=======
  - **User Settings** - Server Configuration ကို Global *settings.json* ဖိုင်တွင် ထည့်သွင်းပြီး Workspace အားလုံးတွင် ရရှိနိုင်သည်။ Configuration သည် အောက်ပါအတိုင်း ဖြစ်မည်-

    ![User Setting](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Azure API Management သို့ Authentication လုပ်ရန် Header ကို ထည့်သွင်းရန် လိုအပ်သည်။ ၎င်းသည် **Ocp-Apim-Subscription-Key** Header ကို အသုံးပြုသည်။

    - Settings တွင် Header ကို ထည့်သွင်းပုံ-

    ![Authentication Header ထည့်သွင်းခြင်း](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)၊ API Key Value ကို Azure Portal တွင် ရှာနိုင်သည်။
>>>>>>> origin/main

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

<<<<<<< HEAD
### Agent mode ကို အသုံးပြုပါ

ယခု settings သို့မဟုတ် *.vscode/mcp.json* တွင် အားလုံး ပြင်ဆင်ပြီးဖြစ်သည်။ စမ်းသပ်ကြည့်ပါ။

Tools icon တစ်ခုကို အောက်ပါအတိုင်း တွေ့ရမည်-

![Tools from the server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Tools icon ကို နှိပ်ပါ၊ exposed tools များ၏ စာရင်းကို အောက်ပါအတိုင်း တွေ့ရမည်-

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Chat တွင် prompt တစ်ခု ထည့်သွင်းကာ tool ကို ခေါ်ဆိုပါ။ ဥပမာအားဖြင့် order အကြောင်းကို သိရန် tool တစ်ခုကို ရွေးချယ်ခဲ့ပါက agent ကို order အကြောင်း မေးမြန်းနိုင်သည်။ ဥပမာ prompt-
=======
### Agent Mode ကို အသုံးပြုခြင်း

Settings သို့မဟုတ် *.vscode/mcp.json* တွင် အားလုံးကို Set Up ပြီးပါပြီ။ စမ်းသပ်ကြည့်ပါ။

Tools Icon ကို အောက်ပါအတိုင်း မြင်ရမည်-

![Server Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Tools Icon ကို Click လုပ်ပါ။ Tools များ၏ စာရင်းကို အောက်ပါအတိုင်း မြင်ရမည်-

    ![Tools](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Chat တွင် Prompt ရိုက်ထည့်ပြီး Tool ကို Invoke လုပ်ပါ။ ဥပမာအားဖြင့် Order အကြောင်းကို သိရန် Tool ကို ရွေးထားပါက Agent ကို Order အကြောင်း မေးနိုင်သည်။ Prompt ဥပမာ-
>>>>>>> origin/main

    ```text
    get information from order 2
    ```

<<<<<<< HEAD
    Tools icon တစ်ခု ပေါ်လာပြီး tool ကို ဆက်လက်ခေါ်ဆိုရန် မေးမြန်းမည်။ Tool ကို ဆောင်ရွက်ရန် ရွေးပါ၊ အောက်ပါအတိုင်း output တစ်ခုကို တွေ့ရမည်-

    ![Result from prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **အထက်တွင် မြင်ရသည်မှာ သင့် setup လုပ်ထားသည့် tools များပေါ်မူတည်သည်၊ သို့သော် အထူးသဖြင့် အထက်ပါအတိုင်း text response တစ်ခု ရရှိမည်**။

## ရင်းမြစ်များ

ပိုမိုလေ့လာရန်-

- [Tutorial on Azure API Management and MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python sample: Secure remote MCP servers using Azure API Management (experimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP client authorization lab](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Use the Azure API Management extension for VS Code to import and manage APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Register and discover remote MCP servers in Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Azure API Management နှင့် AI လုပ်ဆောင်ချက်များကို ပြသသည့် repo
- [AI Gateway workshops](https://azure-samples.github.io/AI-Gateway/) Azure Portal ကို အသုံးပြုသည့် workshops များပါဝင်ပြီး AI လုပ်ဆောင်ချက်များကို စမ်းသပ်ရန် အကောင်းဆုံး နည်းလမ်းဖြစ်သည်။

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက် ဘာသာပြန်မှုများတွင် အမှားများ သို့မဟုတ် မမှန်ကန်မှုများ ပါဝင်နိုင်သည်ကို သတိပြုပါ။ မူလဘာသာစကားဖြင့် ရေးသားထားသော စာရွက်စာတမ်းကို အာဏာတည်သော ရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူပညာရှင်များမှ ဘာသာပြန်မှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်မှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပါယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။
=======
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
>>>>>>> origin/main
