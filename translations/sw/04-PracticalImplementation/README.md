<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:24:56+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sw"
}
-->
# Utekelezaji wa Kivitendo

Utekelezaji wa kivitendo ndiko ambapo nguvu ya Model Context Protocol (MCP) inakuwa halisi. Ingawa kuelewa nadharia na usanifu wa MCP ni muhimu, thamani halisi hujitokeza unapoweka dhana hizi katika matumizi kwa kujenga, kujaribu, na kuweka suluhisho zinazotatua matatizo halisi ya dunia. Sura hii inajenga daraja kati ya maarifa ya dhana na maendeleo ya vitendo, ikikuongoza kupitia mchakato wa kuleta programu zinazotumia MCP kuwa halisi.

Iwapo unatengeneza wasaidizi wa akili, kuunganisha AI katika mchakato wa biashara, au kujenga zana maalum za usindikaji data, MCP hutoa msingi wenye kubadilika. Ubunifu wake usioegemea lugha yoyote na SDK rasmi kwa lugha maarufu za programu hufanya iwe rahisi kwa wapenzi wengi wa maendeleo. Kwa kutumia SDK hizi, unaweza haraka kuunda majaribio, kurudia, na kupanua suluhisho zako katika majukwaa na mazingira tofauti.

Katika sehemu zinazofuata, utapata mifano ya vitendo, msimbo wa mfano, na mikakati ya kuweka huduma inayothibitisha jinsi ya kutekeleza MCP katika C#, Java, TypeScript, JavaScript, na Python. Pia utajifunza jinsi ya kufuatilia na kujaribu seva zako za MCP, kusimamia API, na kuweka suluhisho katika wingu kwa kutumia Azure. Vifaa hivi vya vitendo vimeundwa kuharakisha kujifunza kwako na kukusaidia kujenga kwa kujiamini programu thabiti za MCP zinazoweza kutumika uzalishaji.

## Muhtasari

Somo hili linazingatia vipengele vya vitendo vya utekelezaji wa MCP katika lugha mbalimbali za programu. Tutachunguza jinsi ya kutumia SDK za MCP katika C#, Java, TypeScript, JavaScript, na Python kujenga programu thabiti, kufuatilia na kujaribu seva za MCP, na kuunda rasilimali, prompts, na zana zinazoweza kutumika tena.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:
- Kutekeleza suluhisho za MCP kwa kutumia SDK rasmi katika lugha mbalimbali za programu
- Kufuatilia na kujaribu seva za MCP kwa mfumo mzuri
- Kuunda na kutumia vipengele vya seva (Rasilimali, Prompts, na Zana)
- Kubuni mchakato mzuri wa MCP kwa kazi ngumu
- Kuboresha utekelezaji wa MCP kwa ajili ya utendaji na uaminifu

## Rasilimali Rasmi za SDK

Model Context Protocol hutoa SDK rasmi kwa lugha nyingi:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Kufanya kazi na SDK za MCP

Sehemu hii inatoa mifano ya vitendo ya utekelezaji wa MCP katika lugha mbalimbali za programu. Unaweza kupata msimbo wa mfano katika saraka ya `samples` iliyopangwa kwa lugha.

### Mifano Inayopatikana

Hifadhi ya msimbo ina [mifano ya utekelezaji](../../../04-PracticalImplementation/samples) katika lugha zifuatazo:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Kila mfano unaonyesha dhana kuu za MCP na mifumo ya utekelezaji kwa lugha na mazingira husika.

## Vipengele Vikuu vya Seva

Seva za MCP zinaweza kutekeleza mchanganyiko wowote wa vipengele hivi:

### Rasilimali
Rasilimali hutoa muktadha na data kwa mtumiaji au mfano wa AI kutumia:
- Makusanyo ya nyaraka
- Misingi ya maarifa
- Vyanzo vya data vilivyopangwa
- Mifumo ya faili

### Prompts
Prompts ni ujumbe uliotengenezwa awali na michakato ya kazi kwa watumiaji:
- Violezo vya mazungumzo vilivyowekwa awali
- Mifumo ya maingiliano iliyoongozwa
- Miundo maalum ya mazungumzo

### Zana
Zana ni kazi kwa mfano wa AI kutekeleza:
- Zana za usindikaji data
- Uunganishaji wa API za nje
- Uwezo wa kuhesabu
- Kazi za utafutaji

## Mifano ya Utekelezaji: C#

Hifadhi rasmi ya SDK ya C# ina mifano kadhaa inayoonyesha vipengele tofauti vya MCP:

- **Mteja wa MCP wa Msingi**: Mfano rahisi unaoonyesha jinsi ya kuunda mteja wa MCP na kuita zana
- **Seva ya MCP ya Msingi**: Utekelezaji wa seva wa chini na usajili wa zana za msingi
- **Seva ya MCP ya Juu**: Seva yenye vipengele kamili ikiwa na usajili wa zana, uthibitishaji, na utatuzi wa makosa
- **Muunganisho wa ASP.NET**: Mifano inayoonyesha muunganisho na ASP.NET Core
- **Mifumo ya Utekelezaji wa Zana**: Mifumo mbalimbali ya kutekeleza zana zenye ngazi tofauti za ugumu

SDK ya MCP ya C# iko katika awamu ya majaribio na API zinaweza kubadilika. Tutaendelea kusasisha blogi hii kadri SDK inavyobadilika.

### Vipengele Muhimu
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Kujenga [Seva yako ya MCP ya Kwanza](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Kwa mifano kamili ya utekelezaji wa C#, tembelea [hifadhi rasmi ya mifano ya SDK ya C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Mfano wa utekelezaji: Utekelezaji wa Java

SDK ya Java hutoa chaguzi thabiti za utekelezaji wa MCP zenye vipengele vya daraja la biashara.

### Vipengele Muhimu

- Muunganisho wa Spring Framework
- Usalama wa aina kali
- Msaada wa programu ya reactive
- Utatuzi wa makosa wa kina

Kwa mfano kamili wa utekelezaji wa Java, angalia [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) katika saraka ya mifano.

## Mfano wa utekelezaji: Utekelezaji wa JavaScript

SDK ya JavaScript hutoa njia nyepesi na yenye kubadilika ya utekelezaji wa MCP.

### Vipengele Muhimu

- Msaada wa Node.js na kivinjari
- API inayotumia Promise
- Muunganisho rahisi na Express na mifumo mingine
- Msaada wa WebSocket kwa mtiririko wa data

Kwa mfano kamili wa utekelezaji wa JavaScript, angalia [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) katika saraka ya mifano.

## Mfano wa utekelezaji: Utekelezaji wa Python

SDK ya Python hutoa njia ya Pythonic ya utekelezaji wa MCP na muunganisho mzuri wa mifumo ya ML.

### Vipengele Muhimu

- Msaada wa async/await na asyncio
- Muunganisho na Flask na FastAPI
- Usajili rahisi wa zana
- Muunganisho wa asili na maktaba maarufu za ML

Kwa mfano kamili wa utekelezaji wa Python, angalia [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) katika saraka ya mifano.

## Usimamizi wa API

Azure API Management ni jibu zuri la jinsi tunavyoweza kulinda seva za MCP. Wazo ni kuweka mfano wa Azure API Management mbele ya seva yako ya MCP na kuiruhusu kushughulikia vipengele unavyoweza kuhitaji kama:

- Kuweka kikomo cha mwendo wa maombi
- Usimamizi wa tokeni
- Ufuatiliaji
- Kusawazisha mzigo
- Usalama

### Mfano wa Azure

Hapa kuna Mfano wa Azure unaofanya hasa hivyo, yaani [kuunda seva ya MCP na kuiweka salama kwa Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Tazama jinsi mchakato wa idhini unavyofanyika katika picha ifuatayo:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Katika picha hapo juu, yafuatayo hutokea:

- Uthibitishaji/Idhini hufanyika kwa kutumia Microsoft Entra.
- Azure API Management hutumika kama lango na hutumia sera kuelekeza na kusimamia trafiki.
- Azure Monitor hurekodi maombi yote kwa uchambuzi zaidi.

#### Mchakato wa Idhini

Tuchunguze mchakato wa idhini kwa undani zaidi:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Maelezo ya idhini ya MCP

Jifunze zaidi kuhusu [maelezo ya Idhini ya MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Kuweka Seva ya MCP ya Mbali Azure

Tuchunguze kama tunaweza kuweka mfano tuliotaja awali:

1. Nakili hifadhi

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Jisajili `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` baada ya muda ili kuangalia kama usajili umekamilika.

2. Endesha amri hii ya [azd](https://aka.ms/azd) kuweka huduma ya usimamizi wa api, app ya kazi (ikiwa na msimbo) na rasilimali nyingine zote za Azure zinazohitajika

    ```shell
    azd up
    ```

    Amri hizi zinapaswa kuweka rasilimali zote za wingu kwenye Azure

### Kupima seva yako kwa MCP Inspector

1. Katika **dirisha jipya la terminal**, sakinisha na endesha MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Unapaswa kuona kiolesura kama hiki:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sw.png) 

1. Bonyeza CTRL ili kupakia app ya wavuti ya MCP Inspector kutoka URL iliyoonyeshwa na app (mfano http://127.0.0.1:6274/#resources)
1. Weka aina ya usafirishaji kuwa `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` na **Unganisha**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Orodhesha Zana**. Bonyeza zana na **Endesha Zana**.

Ikiwa hatua zote zimefanikiwa, sasa unapaswa kuwa umeunganishwa na seva ya MCP na umeweza kuita zana.

## Seva za MCP kwa Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Mfululizo huu wa hifadhi ni templeti ya kuanza haraka kwa kujenga na kuweka seva za MCP za mbali kwa kutumia Azure Functions na Python, C# .NET au Node/TypeScript.

Mifano hii hutoa suluhisho kamili linalowawezesha watengenezaji:

- Kujenga na kuendesha kwa ndani: Tengeneza na fuatilia seva ya MCP kwenye mashine ya ndani
- Kuweka kwenye Azure: Weka kwa urahisi kwenye wingu kwa amri rahisi ya azd up
- Kuunganishwa kutoka kwa wateja: Unganisha na seva ya MCP kutoka kwa wateja mbalimbali ikiwa ni pamoja na hali ya wakala wa Copilot wa VS Code na zana ya MCP Inspector

### Vipengele Muhimu:

- Usalama kwa muundo: Seva ya MCP imehifadhiwa kwa kutumia funguo na HTTPS
- Chaguzi za uthibitishaji: Inaunga mkono OAuth kwa kutumia uthibitishaji wa ndani na/au Usimamizi wa API
- Kutengwa kwa mtandao: Inaruhusu kutengwa kwa mtandao kwa kutumia Azure Virtual Networks (VNET)
- Muundo usio na seva: Inatumia Azure Functions kwa utekelezaji unaoweza kupanuka na kuendeshwa kwa matukio
- Maendeleo ya ndani: Msaada kamili wa maendeleo na utatuzi wa matatizo kwa ndani
- Utekelezaji rahisi: Mchakato rahisi wa kuweka kwenye Azure

Hifadhi hii ina faili zote za usanidi, msimbo wa chanzo, na maelezo ya miundombinu ili kuanza haraka na utekelezaji wa seva ya MCP inayoweza kutumika uzalishaji.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Mfano wa utekelezaji wa MCP kwa kutumia Azure Functions na Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Mfano wa utekelezaji wa MCP kwa kutumia Azure Functions na C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Mfano wa utekelezaji wa MCP kwa kutumia Azure Functions na Node/TypeScript.

## Muhimu wa Kumbuka

- SDK za MCP hutoa zana za lugha maalum kwa utekelezaji wa suluhisho thabiti za MCP
- Mchakato wa kufuatilia na kujaribu ni muhimu kwa programu za MCP zenye kuaminika
- Violezo vya prompts vinavyoweza kutumika tena huwezesha maingiliano thabiti ya AI
- Mchakato mzuri uliobuniwa vizuri unaweza kuratibu kazi ngumu kwa kutumia zana nyingi
- Kutekeleza suluhisho za MCP kunahitaji kuzingatia usalama, utendaji, na utatuzi wa makosa

## Mazoezi

Buni mchakato wa MCP wa vitendo unaoshughulikia tatizo halisi katika eneo lako:

1. Tambua zana 3-4 ambazo zitakuwa muhimu kutatua tatizo hili
2. Tengeneza mchoro wa mchakato unaoonyesha jinsi zana hizi zinavyoshirikiana
3. Tekeleza toleo la msingi la moja ya zana hizo kwa kutumia lugha unayopendelea
4. Unda kiolezo cha prompt kitakachosaidia mfano kutumia zana yako kwa ufanisi

## Rasilimali Zaidi


---

Ifuatayo: [Mada za Juu](../05-AdvancedTopics/README.md)

**Tangazo la Kukataa**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuwa sahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.