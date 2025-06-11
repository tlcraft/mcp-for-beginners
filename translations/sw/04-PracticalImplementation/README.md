<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:22:50+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sw"
}
-->
# Utekelezaji wa Kivitendo

Utekelezaji wa kivitendo ndio sehemu ambapo nguvu ya Model Context Protocol (MCP) inakuwa halisi. Ingawa kuelewa nadharia na usanifu wa MCP ni muhimu, thamani halisi huibuka unapowatumia dhana hizi kujenga, kujaribu, na kutangaza suluhisho zinazotatua matatizo halisi ya dunia. Sura hii inaunganisha pengo kati ya maarifa ya dhana na maendeleo ya vitendo, ikikuongoza kupitia mchakato wa kuleta programu zinazotegemea MCP kuishi.

Iwe unatengeneza wasaidizi wa akili, kuunganisha AI katika mchakato wa biashara, au kujenga zana maalum za usindikaji data, MCP hutoa msingi rahisi kubadilika. Muundo wake usioegemea lugha na SDK rasmi kwa lugha maarufu za programu hufanya iwe rahisi kwa watengenezaji wengi. Kwa kutumia SDK hizi, unaweza kuunda mifano haraka, kurudia, na kupanua suluhisho zako kwenye majukwaa na mazingira tofauti.

Katika sehemu zinazofuata, utapata mifano ya vitendo, nambari za mfano, na mikakati ya kutangaza inayothibitisha jinsi ya kutekeleza MCP katika C#, Java, TypeScript, JavaScript, na Python. Pia utajifunza jinsi ya kutatua matatizo na kujaribu seva zako za MCP, kusimamia API, na kutangaza suluhisho kwenye wingu kwa kutumia Azure. Rasilimali hizi za vitendo zimeundwa kukuongezea kasi ya kujifunza na kusaidia kujenga programu imara za MCP zinazoweza kutumika uzalishaji kwa kujiamini.

## Muhtasari

Somo hili linazingatia nyanja za vitendo za utekelezaji wa MCP katika lugha mbalimbali za programu. Tutachunguza jinsi ya kutumia MCP SDK katika C#, Java, TypeScript, JavaScript, na Python kujenga programu imara, kutatua matatizo na kujaribu seva za MCP, na kuunda rasilimali, maelekezo, na zana zinazoweza kutumika tena.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:
- Kutekeleza suluhisho za MCP kwa kutumia SDK rasmi katika lugha mbalimbali za programu
- Kutatua matatizo na kujaribu seva za MCP kwa mfumo
- Kuunda na kutumia vipengele vya seva (Rasilimali, Maelekezo, na Zana)
- Kubuni mtiririko wa MCP unaofaa kwa kazi ngumu
- Kuboresha utekelezaji wa MCP kwa utendaji na uaminifu

## Rasilimali za SDK Rasmi

Model Context Protocol hutoa SDK rasmi kwa lugha nyingi:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Kufanya kazi na MCP SDKs

Sehemu hii inatoa mifano ya vitendo ya utekelezaji wa MCP katika lugha nyingi za programu. Unaweza kupata nambari za mfano katika saraka ya `samples` iliyopangwa kwa lugha.

### Mifano Inayopatikana

Hifadhi ya msimbo ina mifano ya utekelezaji katika lugha zifuatazo:

- C#
- Java
- TypeScript
- JavaScript
- Python

Kila mfano unaonyesha dhana muhimu za MCP na mifumo ya utekelezaji kwa lugha na mazingira husika.

## Vipengele Vikuu vya Seva

Seva za MCP zinaweza kutekeleza mchanganyiko wowote wa vipengele hivi:

### Rasilimali  
Rasilimali hutoa muktadha na data kwa mtumiaji au mfano wa AI kutumia:
- Hifadhi za nyaraka
- Misingi ya maarifa
- Vyanzo vya data vilivyopangwa
- Mifumo ya faili

### Maelekezo  
Maelekezo ni ujumbe na mitiririko ya kazi iliyotengenezwa kwa mtumiaji:
- Violezo vya mazungumzo vilivyowekwa awali
- Mifumo ya mwingiliano iliyoongozwa
- Muundo maalum wa mazungumzo

### Zana  
Zana ni kazi zinazotekelezwa na mfano wa AI:
- Zana za usindikaji data
- Uunganishaji wa API za nje
- Uwezo wa kihesabu
- Utafutaji

## Mifano ya Utekelezaji: C#

Hifadhi rasmi ya C# SDK ina mifano kadhaa ya utekelezaji inayonyesha nyanja tofauti za MCP:

- **Mteja wa MCP Msingi**: Mfano rahisi unaoonyesha jinsi ya kuunda mteja wa MCP na kuita zana
- **Seva ya MCP Msingi**: Utekelezaji mdogo wa seva na usajili wa zana za msingi
- **Seva ya MCP ya Juu**: Seva yenye vipengele kamili ikijumuisha usajili wa zana, uthibitishaji, na utunzaji wa makosa
- **Uunganishaji wa ASP.NET**: Mifano inayoonyesha uunganishaji na ASP.NET Core
- **Mifumo ya Utekelezaji wa Zana**: Mifumo mbalimbali ya kutekeleza zana kwa ngazi tofauti za ugumu

SDK ya MCP ya C# iko katika awamu ya majaribio na API zinaweza kubadilika. Tutaendelea kusasisha blogu hii kadri SDK inavyoendelea.

### Vipengele Muhimu  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Kujenga [Seva yako ya MCP ya Kwanza](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Kwa mifano kamili ya utekelezaji wa C#, tembelea [hifadhi rasmi ya mifano ya C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Mfano wa Utekelezaji: Java

Java SDK hutoa chaguzi thabiti za utekelezaji wa MCP zenye vipengele vya kiwango cha biashara.

### Vipengele Muhimu

- Uunganishaji na Spring Framework
- Usalama mkali wa aina
- Msaada wa programu ya kuendeshwa kwa matukio (Reactive programming)
- Utunzaji wa makosa wa kina

Kwa mfano kamili wa utekelezaji wa Java, angalia [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) katika saraka ya mifano.

## Mfano wa Utekelezaji: JavaScript

JavaScript SDK hutoa njia nyepesi na rahisi ya utekelezaji wa MCP.

### Vipengele Muhimu

- Msaada kwa Node.js na vivinjari
- API inayotumia ahadi (Promise-based)
- Uunganishaji rahisi na Express na mifumo mingine
- Msaada wa WebSocket kwa uenezaji wa data kwa muda halisi

Kwa mfano kamili wa utekelezaji wa JavaScript, angalia [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) katika saraka ya mifano.

## Mfano wa Utekelezaji: Python

Python SDK hutoa njia ya Pythonic ya utekelezaji wa MCP yenye uunganisho mzuri na mifumo ya ML.

### Vipengele Muhimu

- Msaada wa async/await kwa asyncio
- Uunganishaji na Flask na FastAPI
- Usajili rahisi wa zana
- Uunganishaji wa asili na maktaba maarufu za ML

Kwa mfano kamili wa utekelezaji wa Python, angalia [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) katika saraka ya mifano.

## Usimamizi wa API

Azure API Management ni jibu zuri la jinsi tunavyoweza kuimarisha seva za MCP. Wazo ni kuweka mfano wa Azure API Management mbele ya seva yako ya MCP na kuiruhusu kushughulikia vipengele unavyoweza kuhitaji kama:

- kuweka mipaka ya maombi
- usimamizi wa tokeni
- ufuatiliaji
- usawazishaji mzigo
- usalama

### Mfano wa Azure

Huu ni mfano wa Azure unaofanya hasa hivyo, yaani [kuunda seva ya MCP na kuilinda kwa Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Tazama jinsi mtiririko wa idhini unavyofanyika katika picha ifuatayo:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Katika picha iliyotangulia, yafuatayo hutokea:

- Uthibitishaji/Idhini hutekelezwa kwa kutumia Microsoft Entra.
- Azure API Management hufanya kazi kama lango na hutumia sera kuongoza na kusimamia trafiki.
- Azure Monitor huhifadhi kumbukumbu za maombi yote kwa uchambuzi zaidi.

#### Mtiririko wa Idhini

Tuchunguze mtiririko wa idhini kwa undani zaidi:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Maelezo ya Idhini ya MCP

Jifunze zaidi kuhusu [maelezo ya Idhini ya MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Kutangaza Seva ya Remote MCP kwenye Azure

Tuweze kuona kama tunaweza kutangaza mfano tuliotaja hapo awali:

1. Nakili hifadhi ya msimbo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Sajili `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` baada ya muda ili kuangalia kama usajili umekamilika.

2. Endesha amri hii ya [azd](https://aka.ms/azd) ili kuandaa huduma ya usimamizi wa API, programu ya kazi (na msimbo) na rasilimali zote muhimu za Azure

    ```shell
    azd up
    ```

    Amri hii inapaswa kutangaza rasilimali zote za wingu kwenye Azure

### Kuijaribu seva yako kwa MCP Inspector

1. Katika **dirisha jipya la terminal**, weka na endesha MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Unapaswa kuona kiolesura kinachofanana na hiki:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.sw.png) 

1. Bonyeza CTRL na ubofye ili kupakia programu ya wavuti ya MCP Inspector kutoka URL iliyoonyeshwa na programu (mfano http://127.0.0.1:6274/#resources)
1. Weka aina ya usafirishaji kuwa `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` na **Unganisha**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Orodhesha Zana**.  Bonyeza zana na **Endesha Zana**.  

Ikiwa hatua zote zimefanikiwa, sasa unapaswa kuwa umeunganishwa na seva ya MCP na umeweza kuita zana.

## Seva za MCP kwa Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Seti hii ya hifadhi ni templeti za kuanza haraka za kujenga na kutangaza seva za MCP (Model Context Protocol) za mbali kwa kutumia Azure Functions na Python, C# .NET au Node/TypeScript.

Mifano hii hutoa suluhisho kamili linalomruhusu mtengenezaji:

- Kujenga na kuendesha kwa ndani: Kuendeleza na kutatua matatizo ya seva ya MCP kwenye mashine ya ndani
- Kutangaza kwenye Azure: Kutangaza kwa urahisi kwenye wingu kwa amri rahisi ya azd up
- Kuunganishwa kutoka kwa wateja: Kuungana na seva ya MCP kutoka kwa wateja mbalimbali ikiwa ni pamoja na hali ya wakala wa Copilot wa VS Code na zana ya MCP Inspector

### Vipengele Muhimu:

- Usalama kwa muundo: Seva ya MCP imehifadhiwa kwa kutumia funguo na HTTPS
- Chaguzi za uthibitishaji: Inasaidia OAuth kwa kutumia uthibitishaji wa ndani na/au API Management
- Kutengwa kwa mtandao: Inaruhusu kutengwa kwa mtandao kwa kutumia Azure Virtual Networks (VNET)
- Muundo usio na seva: Inatumia Azure Functions kwa utekelezaji unaozidi na unaotegemea matukio
- Maendeleo ya ndani: Msaada kamili wa maendeleo ya ndani na utatuzi wa matatizo
- Utekelezaji rahisi: Mchakato rahisi wa kutangaza kwenye Azure

Hifadhi hii ina faili zote muhimu za usanidi, msimbo wa chanzo, na maelezo ya miundombinu ili kuanza haraka na utekelezaji wa seva ya MCP inayotumika uzalishaji.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Mfano wa utekelezaji wa MCP kwa kutumia Azure Functions na Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Mfano wa utekelezaji wa MCP kwa kutumia Azure Functions na C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Mfano wa utekelezaji wa MCP kwa kutumia Azure Functions na Node/TypeScript.

## Muhimu wa Kumbuka

- SDK za MCP hutoa zana maalum kwa lugha za programu kwa ajili ya kutekeleza suluhisho thabiti za MCP
- Mchakato wa utatuzi na majaribio ni muhimu kwa programu za MCP zenye uaminifu
- Violezo vya maelekezo vinavyoweza kutumika tena huwezesha mwingiliano thabiti wa AI
- Mitiririko iliyobuniwa vizuri inaweza kuratibu kazi ngumu kwa kutumia zana nyingi
- Kutekeleza suluhisho za MCP kunahitaji kuzingatia usalama, utendaji, na utunzaji wa makosa

## Zoef

Buni mtiririko wa MCP wa vitendo unaoshughulikia tatizo halisi katika eneo lako:

1. Tambua zana 3-4 ambazo zingekuwa muhimu kutatua tatizo hili
2. Tengeneza mchoro wa mtiririko unaoonyesha jinsi zana hizi zinavyoshirikiana
3. Tekeleza toleo la msingi la moja ya zana hizo kwa lugha unayopendelea
4. Unda kiolezo cha maelekezo kitakachosaidia mfano kutumia zana yako kwa ufanisi

## Rasilimali Zaidi


---

Ifuatayo: [Mada za Juu](../05-AdvancedTopics/README.md)

**Kiarifu cha Kutengwa**:  
Hati hii imetafsiriwa kwa kutumia huduma ya utafsiri wa AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuwa sahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya mama inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inashauriwa. Hatuwajibiki kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.