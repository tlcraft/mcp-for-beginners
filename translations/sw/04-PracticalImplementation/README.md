<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:57:51+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sw"
}
-->
# Utekelezaji wa Kivitendo

Utekelezaji wa kivitendo ndiko ambapo nguvu ya Model Context Protocol (MCP) inakuwa dhahiri. Ingawa kuelewa nadharia na usanifu wa MCP ni muhimu, thamani halisi huibuka unapoweka dhana hizi katika matumizi kwa kujenga, kujaribu, na kupeleka suluhisho zinazotatua matatizo halisi ya dunia. Sura hii inaunganisha pengo kati ya maarifa ya dhana na maendeleo ya vitendo, ikikuongoza kupitia mchakato wa kuleta programu zinazotegemea MCP kuishi.

Iwe unaunda wasaidizi wa akili, kuingiza AI katika michakato ya biashara, au kutengeneza zana maalum za usindikaji data, MCP hutoa msingi wenye kubadilika. Muundo wake usioegemea lugha yoyote na SDK rasmi kwa lugha maarufu za programu hufanya iwe rahisi kwa watengenezaji wengi. Kwa kutumia SDK hizi, unaweza haraka kuunda mfano wa awali, kurudia, na kupanua suluhisho zako katika majukwaa na mazingira tofauti.

Katika sehemu zinazofuata, utapata mifano ya vitendo, msimbo wa sampuli, na mikakati ya upeleka inayothibitisha jinsi ya kutekeleza MCP katika C#, Java, TypeScript, JavaScript, na Python. Pia utajifunza jinsi ya kutatua matatizo na kujaribu seva zako za MCP, kusimamia API, na kupeleka suluhisho kwenye wingu kwa kutumia Azure. Rasilimali hizi za vitendo zimeundwa kukuza haraka ujifunzaji wako na kukusaidia kujenga kwa kujiamini programu thabiti, tayari kwa uzalishaji za MCP.

## Muhtasari

Somo hili linazingatia mambo ya vitendo ya utekelezaji wa MCP katika lugha mbalimbali za programu. Tutachunguza jinsi ya kutumia SDK za MCP katika C#, Java, TypeScript, JavaScript, na Python kujenga programu thabiti, kutatua matatizo na kujaribu seva za MCP, na kuunda rasilimali, maelekezo, na zana zinazoweza kutumika tena.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:
- Kutekeleza suluhisho za MCP kwa kutumia SDK rasmi katika lugha mbalimbali za programu
- Kutatua matatizo na kujaribu seva za MCP kwa mfumo
- Kuunda na kutumia vipengele vya seva (Rasilimali, Maelekezo, na Zana)
- Kubuni michakato madhubuti ya MCP kwa kazi ngumu
- Kuboresha utekelezaji wa MCP kwa utendaji na kuaminika

## Rasilimali Rasmi za SDK

Model Context Protocol hutoa SDK rasmi kwa lugha nyingi:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Kufanya kazi na SDK za MCP

Sehemu hii inatoa mifano ya vitendo ya utekelezaji wa MCP katika lugha mbalimbali za programu. Unaweza kupata msimbo wa sampuli katika saraka ya `samples` iliyopangwa kwa lugha.

### Sampuli Zinazopatikana

Hifadhi ina [mifano ya utekelezaji](../../../04-PracticalImplementation/samples) katika lugha zifuatazo:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Kila sampuli inaonyesha dhana kuu za MCP na mifumo ya utekelezaji kwa lugha na mazingira husika.

## Vipengele Vikuu vya Seva

Seva za MCP zinaweza kutekeleza mchanganyiko wowote wa vipengele hivi:

### Rasilimali
Rasilimali hutoa muktadha na data kwa mtumiaji au mfano wa AI kutumia:
- Hifadhi za nyaraka
- Misingi ya maarifa
- Vyanzo vya data vilivyopangwa
- Mifumo ya faili

### Maelekezo
Maelekezo ni ujumbe na michakato ya kazi iliyotengenezwa kwa mtumiaji:
- Violezo vya mazungumzo vilivyowekwa awali
- Mifumo ya maingiliano iliyoongozwa
- Miundo maalum ya mazungumzo

### Zana
Zana ni kazi ambazo mfano wa AI hutekeleza:
- Zana za usindikaji data
- Muunganisho wa API za nje
- Uwezo wa kihesabu
- Kazi za utafutaji

## Mifano ya Utekelezaji: C#

Hifadhi rasmi ya SDK ya C# ina mifano kadhaa ya utekelezaji inayoonyesha nyanja tofauti za MCP:

- **Mteja wa MCP wa Msingi**: Mfano rahisi unaoonyesha jinsi ya kuunda mteja wa MCP na kutumia zana
- **Seva ya MCP ya Msingi**: Utekelezaji mdogo wa seva na usajili wa zana za msingi
- **Seva ya MCP ya Juu**: Seva yenye vipengele kamili ikiwa na usajili wa zana, uthibitishaji, na usimamizi wa makosa
- **Muunganisho wa ASP.NET**: Mifano inayoonyesha muunganisho na ASP.NET Core
- **Mifumo ya Utekelezaji wa Zana**: Mifumo mbalimbali ya kutekeleza zana kwa ngazi tofauti za ugumu

SDK ya MCP ya C# iko katika awamu ya majaribio na API zinaweza kubadilika. Tutaendelea kusasisha blogi hii kadri SDK inavyoendelea.

### Vipengele Muhimu
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Kujenga [Seva yako ya MCP ya Kwanza](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Kwa mifano kamili ya utekelezaji wa C#, tembelea [hifadhi rasmi ya mifano ya SDK ya C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Mfano wa utekelezaji: Utekelezaji wa Java

SDK ya Java inatoa chaguzi thabiti za utekelezaji wa MCP zenye vipengele vya kiwango cha biashara.

### Vipengele Muhimu

- Muunganisho wa Spring Framework
- Usalama mkali wa aina
- Msaada wa programu ya reactive
- Usimamizi kamili wa makosa

Kwa mfano kamili wa utekelezaji wa Java, angalia [sampuli ya Java](samples/java/containerapp/README.md) katika saraka ya mifano.

## Mfano wa utekelezaji: Utekelezaji wa JavaScript

SDK ya JavaScript hutoa njia nyepesi na yenye kubadilika kwa utekelezaji wa MCP.

### Vipengele Muhimu

- Msaada wa Node.js na kivinjari
- API inayotumia ahadi (Promise-based)
- Muunganisho rahisi na Express na mifumo mingine
- Msaada wa WebSocket kwa mtiririko wa data

Kwa mfano kamili wa utekelezaji wa JavaScript, angalia [sampuli ya JavaScript](samples/javascript/README.md) katika saraka ya mifano.

## Mfano wa utekelezaji: Utekelezaji wa Python

SDK ya Python hutoa njia ya Pythonic kwa utekelezaji wa MCP ikiwa na muunganisho bora wa mifumo ya ML.

### Vipengele Muhimu

- Msaada wa async/await kwa kutumia asyncio
- Muunganisho wa Flask na FastAPI
- Usajili rahisi wa zana
- Muunganisho wa asili na maktaba maarufu za ML

Kwa mfano kamili wa utekelezaji wa Python, angalia [sampuli ya Python](samples/python/README.md) katika saraka ya mifano.

## Usimamizi wa API

Azure API Management ni jibu zuri la jinsi tunavyoweza kulinda Seva za MCP. Wazo ni kuweka mfano wa Azure API Management mbele ya Seva yako ya MCP na kuiruhusu kushughulikia vipengele unavyoweza kuhitaji kama:

- ukomo wa kiwango cha maombi
- usimamizi wa tokeni
- ufuatiliaji
- usawazishaji mzigo
- usalama

### Sampuli ya Azure

Hapa kuna Sampuli ya Azure inayofanya hasa hivyo, yaani [kuunda Seva ya MCP na kuilinda kwa Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Tazama jinsi mtiririko wa idhini unavyofanyika katika picha ifuatayo:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Katika picha hapo juu, yafuatayo hutokea:

- Uthibitishaji/Idhini hufanyika kwa kutumia Microsoft Entra.
- Azure API Management hufanya kazi kama lango na hutumia sera kuongoza na kusimamia trafiki.
- Azure Monitor hurekodi maombi yote kwa uchambuzi zaidi.

#### Mtiririko wa Idhini

Tuchunguze mtiririko wa idhini kwa undani zaidi:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Maelezo ya Idhini ya MCP

Jifunze zaidi kuhusu [Maelezo ya Idhini ya MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Kuweka Seva ya MCP ya Mbali kwenye Azure

Tuchunguze kama tunaweza kupeleka sampuli tuliyotaja awali:

1. Nakili hifadhi

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Sajili mtoa huduma wa rasilimali `Microsoft.App`.
    * Ikiwa unatumia Azure CLI, endesha `az provider register --namespace Microsoft.App --wait`.
    * Ikiwa unatumia Azure PowerShell, endesha `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Kisha endesha `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` baada ya muda kuona kama usajili umekamilika.

2. Endesha amri hii ya [azd](https://aka.ms/azd) kuandaa huduma ya usimamizi wa API, app ya kazi (ikiwa na msimbo) na rasilimali zote muhimu za Azure

    ```shell
    azd up
    ```

    Amri hizi zinapaswa kupeleka rasilimali zote za wingu kwenye Azure

### Kuangalia seva yako kwa MCP Inspector

1. Katika **dirisha jipya la terminal**, sakinisha na endesha MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Unapaswa kuona kiolesura kinachofanana na hiki:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sw.png) 

1. Bonyeza CTRL ili kupakia app ya wavuti ya MCP Inspector kutoka URL inayotolewa na app (mfano http://127.0.0.1:6274/#resources)
1. Weka aina ya usafirishaji kuwa `SSE`
1. Weka URL ya mwisho wa API Management SSE unaoendesha unaoonyeshwa baada ya `azd up` na **Unganisha**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Orodhesha Zana**. Bonyeza zana na **Endesha Zana**.  

Kama hatua zote zimefanikiwa, sasa unapaswa kuwa umeunganishwa na seva ya MCP na umeweza kuita zana.

## Seva za MCP kwa Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Seti hii ya hifadhi ni templeti ya kuanza haraka kwa kujenga na kupeleka seva za MCP za mbali (Model Context Protocol) kwa kutumia Azure Functions na Python, C# .NET au Node/TypeScript.

Mifano hutoa suluhisho kamili linalowezesha watengenezaji:

- Kujenga na kuendesha kwa ndani: Kuendeleza na kutatua matatizo ya seva ya MCP kwenye mashine ya ndani
- Kupeleka kwenye Azure: Kupeleka kwa urahisi kwenye wingu kwa amri rahisi ya azd up
- Kuunganishwa kutoka kwa wateja: Kuungana na seva ya MCP kutoka kwa wateja mbalimbali ikiwa ni pamoja na hali ya wakala wa Copilot wa VS Code na zana ya MCP Inspector

### Vipengele Muhimu:

- Usalama kwa muundo: Seva ya MCP inalindwa kwa kutumia funguo na HTTPS
- Chaguzi za uthibitishaji: Inasaidia OAuth kwa kutumia uthibitishaji wa ndani na/au API Management
- Kutengwa kwa mtandao: Inaruhusu kutengwa kwa mtandao kwa kutumia Azure Virtual Networks (VNET)
- Muundo usio na seva: Inatumia Azure Functions kwa utekelezaji unaoweza kupanuka na unaotegemea matukio
- Maendeleo ya ndani: Msaada kamili wa maendeleo na utatuzi wa matatizo kwa ndani
- Upelekaji rahisi: Mchakato rahisi wa kupeleka kwenye Azure

Hifadhi ina faili zote muhimu za usanidi, msimbo wa chanzo, na maelezo ya miundombinu ili kuanza haraka na utekelezaji wa seva ya MCP tayari kwa uzalishaji.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Mfano wa utekelezaji wa MCP kwa kutumia Azure Functions na Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Mfano wa utekelezaji wa MCP kwa kutumia Azure Functions na C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Mfano wa utekelezaji wa MCP kwa kutumia Azure Functions na Node/TypeScript.

## Muhimu wa Kumbuka

- SDK za MCP hutoa zana maalum za lugha kwa ajili ya kutekeleza suluhisho thabiti za MCP
- Mchakato wa kutatua matatizo na kujaribu ni muhimu kwa programu za MCP zinazotegemewa
- Violezo vya maelekezo vinavyoweza kutumika tena hutoa maingiliano thabiti ya AI
- Michakato iliyobuniwa vizuri inaweza kuratibu kazi ngumu kwa kutumia zana nyingi
- Kutekeleza suluhisho za MCP kunahitaji kuzingatia usalama, utendaji, na usimamizi wa makosa

## Zoef

Buni mchakato wa MCP wa vitendo unaoshughulikia tatizo halisi katika eneo lako:

1. Tambua zana 3-4 ambazo zitakuwa na msaada katika kutatua tatizo hili
2. Tengeneza mchoro wa mchakato unaoonyesha jinsi zana hizi zinavyoshirikiana
3. Tekeleza toleo la msingi la moja ya zana hizo kwa kutumia lugha unayopendelea
4. Tengeneza kiolezo cha maelekezo kitakachosaidia mfano kutumia zana yako kwa ufanisi

## Rasilimali Zaidi


---

Ifuatayo: [Mada za Juu](../05-AdvancedTopics/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.