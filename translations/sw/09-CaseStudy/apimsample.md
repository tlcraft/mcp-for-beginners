<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:35:41+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "sw"
}
-->
# Case Study: Kufichua REST API katika API Management kama MCP server

Azure API Management, ni huduma inayotoa Gateway juu ya API Endpoints zako. Inavyofanya kazi ni kwamba Azure API Management hufanya kazi kama wakala mbele ya APIs zako na inaweza kuamua nini cha kufanya na maombi yanayoingia.

Kwa kuitumia, unaongeza vipengele vingi kama:

- **Usalama**, unaweza kutumia kila kitu kuanzia API keys, JWT hadi managed identity.
- **Kudhibiti kiwango cha maombi**, kipengele kizuri ni uwezo wa kuamua ni maombi mangapi yanapita kwa kipindi fulani cha muda. Hii husaidia kuhakikisha watumiaji wote wanapata uzoefu mzuri na pia huduma yako haizidiwi na maombi.
- **Kupima ukubwa & Kusawazisha mzigo**. Unaweza kuweka idadi ya endpoints kusawazisha mzigo na pia unaweza kuamua jinsi ya "kusawazisha mzigo".
- **Vipengele vya AI kama semantic caching**, kikomo cha token na ufuatiliaji wa token na zaidi. Hivi ni vipengele bora vinavyoboresha mwitikio pamoja na kusaidia kudhibiti matumizi ya token zako. [Soma zaidi hapa](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Kwa nini MCP + Azure API Management?

Model Context Protocol inazidi kuwa kiwango cha kawaida kwa programu za AI za agentic na jinsi ya kufichua zana na data kwa njia thabiti. Azure API Management ni chaguo la asili unapotaka "kusimamia" APIs. MCP Servers mara nyingi huunganishwa na APIs nyingine kutatua maombi kwa zana kwa mfano. Kwa hiyo kuunganisha Azure API Management na MCP ni jambo lenye mantiki sana.

## Muhtasari

Katika kesi hii maalum tutajifunza jinsi ya kufichua API endpoints kama MCP Server. Kwa kufanya hivi, tunaweza kwa urahisi kufanya endpoints hizi kuwa sehemu ya programu ya agentic huku tukitumia vipengele vya Azure API Management.

## Vipengele Muhimu

- Unachagua njia za endpoint unazotaka kufichua kama zana.
- Vipengele vya ziada unavyopata vinategemea kile unachokisanidi katika sehemu ya sera kwa API yako. Lakini hapa tutaonyesha jinsi ya kuongeza kudhibiti kiwango cha maombi.

## Hatua ya awali: ingiza API

Kama tayari una API katika Azure API Management, nzuri, basi unaweza ruka hatua hii. Ikiwa huna, angalia kiungo hiki, [kuingiza API katika Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Kufichua API kama MCP Server

Ili kufichua API endpoints, fuata hatua hizi:

1. Nenda kwenye Azure Portal na anwani ifuatayo <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Nenda kwenye mfano wako wa API Management.

1. Katika menyu ya kushoto, chagua APIs > MCP Servers > + Create new MCP Server.

1. Katika API, chagua REST API kufichua kama MCP server.

1. Chagua moja au zaidi ya API Operations kufichua kama zana. Unaweza kuchagua shughuli zote au shughuli maalum tu.

    ![Chagua njia za kufichua](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Chagua **Create**.

1. Nenda kwenye chaguo la menyu **APIs** na **MCP Servers**, utapaswa kuona yafuatayo:

    ![Tazama MCP Server kwenye dirisha kuu](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP server imetengenezwa na shughuli za API zimefichuliwa kama zana. MCP server inaorodheshwa kwenye dirisha la MCP Servers. Safu ya URL inaonyesha endpoint ya MCP server ambayo unaweza kuitumia kwa majaribio au ndani ya programu ya mteja.

## Hiari: Sanidi sera

Azure API Management ina dhana kuu ya sera ambapo unaweka sheria tofauti kwa endpoints zako kama vile kudhibiti kiwango cha maombi au semantic caching. Sera hizi huandikwa kwa XML.

Hapa ni jinsi unavyoweza kusanidi sera ya kudhibiti kiwango cha maombi kwa MCP Server yako:

1. Katika portal, chini ya APIs, chagua **MCP Servers**.

1. Chagua MCP server uliyotengeneza.

1. Katika menyu ya kushoto, chini ya MCP, chagua **Policies**.

1. Katika mhariri wa sera, ongeza au hariri sera unazotaka kutumia kwa zana za MCP server. Sera zinafafanuliwa kwa muundo wa XML. Kwa mfano, unaweza kuongeza sera ya kupunguza maombi kwa zana za MCP server (katika mfano huu, maombi 5 kwa sekunde 30 kwa kila anwani ya IP ya mteja). Hii ni XML itakayosababisha kudhibiti kiwango cha maombi:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Hii ni picha ya mhariri wa sera:

    ![Mhariri wa sera](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)

## Jaribu

Tuhakikishe MCP Server yetu inafanya kazi kama inavyotarajiwa.

Kwa hili, tutatumia Visual Studio Code na GitHub Copilot na hali yake ya Agent. Tutaunda MCP server katika *mcp.json*. Kwa kufanya hivyo, Visual Studio Code itafanya kazi kama mteja mwenye uwezo wa agentic na watumiaji wa mwisho wataweza kuandika maelekezo na kuingiliana na server hiyo.

Tazama jinsi ya kuongeza MCP server katika Visual Studio Code:

1. Tumia amri ya MCP: **Add Server kutoka Command Palette**.

1. Ukipigiwa simu, chagua aina ya server: **HTTP (HTTP au Server Sent Events)**.

1. Weka URL ya MCP server katika API Management. Mfano: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (kwa endpoint ya SSE) au **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (kwa endpoint ya MCP), angalia tofauti kati ya usafirishaji ni `/sse` au `/mcp`.

1. Weka kitambulisho cha server unachotaka. Hii si thamani muhimu lakini itakusaidia kukumbuka ni server gani hii.

1. Chagua kama unataka kuhifadhi usanidi kwenye mipangilio ya workspace au mipangilio ya mtumiaji.

  - **Mipangilio ya workspace** - Usanidi wa server unahifadhiwa kwenye faili la .vscode/mcp.json linalopatikana tu katika workspace ya sasa.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    au kama utachagua usafirishaji wa HTTP wa mtiririko itakuwa tofauti kidogo:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Mipangilio ya mtumiaji** - Usanidi wa server unaongezwa kwenye faili yako ya *settings.json* ya kimataifa na upatikane katika workspaces zote. Usanidi unaonekana kama ifuatavyo:

    ![Mipangilio ya mtumiaji](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Pia unahitaji kuongeza usanidi, kichwa cha maombi ili kuhakikisha uthibitishaji sahihi kuelekea Azure API Management. Inatumia kichwa kinachoitwa **Ocp-Apim-Subscription-Key**.

    - Hapa ni jinsi unavyoweza kuiongeza kwenye mipangilio:

    ![Kuongeza kichwa cha uthibitishaji](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), hii itasababisha onyo la kuomba thamani ya API key ambayo unaweza kupata katika Azure Portal kwa mfano wako wa Azure API Management.

   - Ili kuiongeza badala yake kwenye *mcp.json*, unaweza kuiongeza kama ifuatavyo:

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

### Tumia hali ya Agent

Sasa tumesanidi yote katika mipangilio au katika *.vscode/mcp.json*. Tujaribu sasa.

Kutakuwa na ikoni ya Zana kama ifuatavyo, ambapo zana zilizofichuliwa kutoka kwa server yako zitaorodheshwa:

![Zana kutoka kwa server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Bonyeza ikoni ya zana na utapata orodha ya zana kama ifuatavyo:

    ![Zana](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Weka maelekezo kwenye mazungumzo kuitisha zana. Kwa mfano, kama umechagua zana ya kupata taarifa kuhusu agizo, unaweza kumuuliza wakala kuhusu agizo hilo. Hapa ni mfano wa maelekezo:

    ```text
    get information from order 2
    ```

    Sasa utaonyeshwa ikoni ya zana ikikuomba uendelee kuitisha zana. Chagua kuendelea kuendesha zana, sasa utaona matokeo kama ifuatavyo:

    ![Matokeo kutoka kwa maelekezo](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **kile unachoona hapo juu kinategemea zana ulizozisanidi, lakini wazo ni kwamba unapata jibu la maandishi kama lilivyo hapo juu**

## Marejeleo

Hapa ni jinsi unavyoweza kujifunza zaidi:

- [Mafunzo kuhusu Azure API Management na MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Mfano wa Python: Kulinda MCP servers za mbali kwa kutumia Azure API Management (jaribio)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Maabara ya idhini ya mteja wa MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Tumia ugani wa Azure API Management kwa VS Code kuingiza na kusimamia APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Jisajili na gundua MCP servers za mbali katika Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Hifadhi nzuri inayonyesha uwezo mwingi wa AI na Azure API Management
- [Warsha za AI Gateway](https://azure-samples.github.io/AI-Gateway/) Zinajumuisha warsha kwa kutumia Azure Portal, njia nzuri ya kuanza kutathmini uwezo wa AI.

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.