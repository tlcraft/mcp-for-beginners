<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:59:03+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "sw"
}
-->
# Utekelezaji wa Vitendo

Utekelezaji wa vitendo ni pale ambapo nguvu ya Model Context Protocol (MCP) inakuwa dhahiri. Ingawa kuelewa nadharia na usanifu wa MCP ni muhimu, thamani halisi inatokea unapoweka dhana hizi katika matumizi ya kujenga, kujaribu, na kusambaza suluhisho zinazotatua matatizo halisi. Sura hii inaunganisha pengo kati ya maarifa ya dhana na maendeleo ya vitendo, ikikuongoza katika mchakato wa kuleta programu zinazotegemea MCP katika uhai.

Ikiwa unakuza wasaidizi wenye akili, kuunganisha AI katika mitiririko ya kazi za biashara, au kujenga zana maalum za usindikaji wa data, MCP inatoa msingi rahisi. Ubunifu wake usioegemea lugha na SDK rasmi kwa lugha maarufu za programu unafanya iweze kufikiwa na watengenezaji mbalimbali. Kwa kutumia SDK hizi, unaweza haraka kuunda, kurudia, na kupanua suluhisho zako katika majukwaa na mazingira tofauti.

Katika sehemu zifuatazo, utapata mifano ya vitendo, sampuli za msimbo, na mikakati ya usambazaji inayoonyesha jinsi ya kutekeleza MCP katika C#, Java, TypeScript, JavaScript, na Python. Pia utajifunza jinsi ya kudhibiti na kujaribu seva za MCP, kusimamia API, na kusambaza suluhisho kwa wingu kwa kutumia Azure. Rasilimali hizi za vitendo zimetengenezwa ili kuharakisha kujifunza kwako na kukusaidia kujenga programu za MCP zenye nguvu, tayari kwa uzalishaji kwa ujasiri.

## Muhtasari

Somo hili linaangazia vipengele vya vitendo vya utekelezaji wa MCP katika lugha mbalimbali za programu. Tutachunguza jinsi ya kutumia SDK za MCP katika C#, Java, TypeScript, JavaScript, na Python kujenga programu thabiti, kudhibiti na kujaribu seva za MCP, na kuunda rasilimali zinazoweza kutumika tena, vidokezo, na zana.

## Malengo ya Kujifunza

Kufikia mwisho wa somo hili, utaweza:
- Kutekeleza suluhisho za MCP kwa kutumia SDK rasmi katika lugha mbalimbali za programu
- Kudhibiti na kujaribu seva za MCP kwa utaratibu
- Kuunda na kutumia vipengele vya seva (Rasilimali, Vidokezo, na Zana)
- Kubuni mitiririko ya kazi ya MCP yenye ufanisi kwa kazi ngumu
- Kuboresha utekelezaji wa MCP kwa utendaji na kuegemea

## Rasilimali za SDK Rasmi

Model Context Protocol inatoa SDK rasmi kwa lugha mbalimbali:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Kufanya kazi na SDK za MCP

Sehemu hii inatoa mifano ya vitendo ya kutekeleza MCP katika lugha mbalimbali za programu. Unaweza kupata sampuli za msimbo katika saraka ya `samples` iliyoandaliwa kwa lugha.

### Sampuli Zinazopatikana

Hazina inajumuisha utekelezaji wa sampuli katika lugha zifuatazo:

- C#
- Java
- TypeScript
- JavaScript
- Python

Kila sampuli inaonyesha dhana kuu za MCP na mifumo ya utekelezaji kwa lugha na ekosistimu maalum.

## Vipengele Vikuu vya Seva

Seva za MCP zinaweza kutekeleza mchanganyiko wowote wa vipengele hivi:

### Rasilimali
Rasilimali zinatoa muktadha na data kwa mtumiaji au modeli ya AI kutumia:
- Hazina za hati
- Misingi ya maarifa
- Vyanzo vya data vilivyoundwa
- Mifumo ya faili

### Vidokezo
Vidokezo ni ujumbe uliowekwa kiolezo na mitiririko ya kazi kwa watumiaji:
- Violezo vya mazungumzo vilivyotangulia
- Mifumo ya mwingiliano iliyosimamiwa
- Miundo maalum ya mazungumzo

### Zana
Zana ni kazi kwa modeli ya AI kutekeleza:
- Huduma za usindikaji wa data
- Miunganisho ya API ya nje
- Uwezo wa hesabu
- Utaftaji wa utendaji

## Utekelezaji wa Sampuli: C#

Hazina rasmi ya SDK ya C# ina utekelezaji kadhaa wa sampuli unaoonyesha vipengele tofauti vya MCP:

- **Mteja wa MCP Msingi**: Mfano rahisi unaoonyesha jinsi ya kuunda mteja wa MCP na kupiga simu zana
- **Seva ya MCP Msingi**: Utekelezaji mdogo wa seva na usajili wa zana za msingi
- **Seva ya MCP ya Juu**: Seva yenye vipengele kamili na usajili wa zana, uthibitishaji, na udhibiti wa makosa
- **Muunganisho wa ASP.NET**: Mifano inayoonyesha muunganisho na ASP.NET Core
- **Mifumo ya Utekelezaji wa Zana**: Mifumo mbalimbali ya kutekeleza zana na viwango tofauti vya ugumu

SDK ya MCP ya C# iko katika hakikisho na API zinaweza kubadilika. Tutaendelea kusasisha blogu hii kadri SDK inavyoendelea.

### Vipengele Muhimu 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Kujenga [seva yako ya kwanza ya MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Kwa sampuli kamili za utekelezaji wa C#, tembelea [hazina rasmi ya sampuli za SDK ya C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Utekelezaji wa Sampuli: Utekelezaji wa Java

SDK ya Java inatoa chaguo za utekelezaji wa MCP zenye nguvu na vipengele vya daraja la biashara.

### Vipengele Muhimu

- Muunganisho wa Mfumo wa Spring
- Usalama wa aina kali
- Usaidizi wa programu ya kirekebu
- Udhibiti wa makosa wa kina

Kwa sampuli kamili ya utekelezaji wa Java, angalia [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) katika saraka ya sampuli.

## Utekelezaji wa Sampuli: Utekelezaji wa JavaScript

SDK ya JavaScript inatoa mbinu nyepesi na rahisi ya utekelezaji wa MCP.

### Vipengele Muhimu

- Usaidizi wa Node.js na kivinjari
- API inayotegemea ahadi
- Muunganisho rahisi na Express na mifumo mingine
- Usaidizi wa WebSocket kwa utiririshaji

Kwa sampuli kamili ya utekelezaji wa JavaScript, angalia [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) katika saraka ya sampuli.

## Utekelezaji wa Sampuli: Utekelezaji wa Python

SDK ya Python inatoa mbinu ya Pythonic kwa utekelezaji wa MCP na miunganisho bora ya mifumo ya ML.

### Vipengele Muhimu

- Usaidizi wa async/await na asyncio
- Muunganisho wa Flask na FastAPI
- Usajili rahisi wa zana
- Muunganisho wa asili na maktaba maarufu za ML

Kwa sampuli kamili ya utekelezaji wa Python, angalia [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) katika saraka ya sampuli.

## Usimamizi wa API

Usimamizi wa API ya Azure ni jibu bora kwa jinsi tunavyoweza kulinda seva za MCP. Wazo ni kuweka mfano wa Usimamizi wa API ya Azure mbele ya seva yako ya MCP na kuiruhusu kushughulikia vipengele unavyoweza kutaka kama:

- upunguzaji wa kiwango
- usimamizi wa tokeni
- ufuatiliaji
- usawazishaji wa mzigo
- usalama

### Sampuli ya Azure

Hapa kuna sampuli ya Azure inayofanya hivyo, yaani [kuunda seva ya MCP na kuilinda kwa Usimamizi wa API ya Azure](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Angalia jinsi mtiririko wa uthibitishaji unavyofanyika kwenye picha iliyo hapa chini:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Katika picha iliyotangulia, yafuatayo yanatokea:

- Uthibitishaji/Uthibitisho unafanyika kwa kutumia Microsoft Entra.
- Usimamizi wa API ya Azure hufanya kazi kama lango na hutumia sera kuelekeza na kudhibiti trafiki.
- Azure Monitor hurekodi maombi yote kwa uchambuzi zaidi.

#### Mtiririko wa uthibitishaji

Hebu tuangalie mtiririko wa uthibitishaji kwa undani zaidi:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Maelezo ya uthibitishaji wa MCP

Jifunze zaidi kuhusu [maelezo ya uthibitishaji wa MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Kusambaza Seva ya MCP ya Mbali kwa Azure

Hebu tuone kama tunaweza kusambaza sampuli tuliyotaja awali:

1. Clone repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Sajili `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` baada ya muda fulani kuangalia kama usajili umekamilika.

2. Endesha amri hii ya [azd](https://aka.ms/azd) ili kutoa huduma ya usimamizi wa api, programu ya kazi (na msimbo) na rasilimali zote nyingine zinazohitajika za Azure

    ```shell
    azd up
    ```

    Amri hii inapaswa kusambaza rasilimali zote za wingu kwenye Azure

### Kujaribu seva yako na MCP Inspector

1. Katika **dirisha jipya la terminal**, sakinisha na endesha MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Unapaswa kuona kiolesura kinachofanana na:

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.sw.png)

1. Bonyeza CTRL ili kupakia programu ya wavuti ya MCP Inspector kutoka kwa URL iliyoonyeshwa na programu (mf. http://127.0.0.1:6274/#resources)
1. Weka aina ya usafirishaji kuwa `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` na **Unganisha**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Orodhesha Zana**. Bonyeza zana na **Endesha Zana**.  

Ikiwa hatua zote zimefanya kazi, sasa unapaswa kuwa umeunganishwa na seva ya MCP na umeweza kupiga simu zana.

## Seva za MCP kwa Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Seti hii ya hazina ni kiolezo cha kuanza haraka kwa kujenga na kusambaza seva za MCP za mbali za kawaida kwa kutumia Azure Functions na Python, C# .NET au Node/TypeScript. 

Sampuli zinatoa suluhisho kamili linaloruhusu watengenezaji kufanya:

- Kujenga na kuendesha ndani: Kuendeleza na kudhibiti seva ya MCP kwenye mashine ya ndani
- Kusambaza kwa Azure: Kusambaza kwa urahisi kwa wingu kwa amri rahisi ya azd up
- Kuunganisha kutoka kwa wateja: Kuunganisha kwa seva ya MCP kutoka kwa wateja mbalimbali ikiwa ni pamoja na hali ya wakala wa VS Code's Copilot na zana ya MCP Inspector

### Vipengele Muhimu:

- Usalama kwa muundo: Seva ya MCP inalindwa kwa kutumia funguo na HTTPS
- Chaguo za uthibitishaji: Inasaidia OAuth kwa kutumia uthibitishaji wa ndani na/au Usimamizi wa API
- Uisolishaji wa mtandao: Inaruhusu usolishaji wa mtandao kwa kutumia Mitandao ya Kibinafsi ya Azure (VNET)
- Usanifu usio na seva: Inatumia Azure Functions kwa utekelezaji wa kipimo, unaosababishwa na matukio
- Maendeleo ya ndani: Usaidizi wa kina wa maendeleo na udhibiti wa ndani
- Mchakato rahisi wa kusambaza: Mchakato wa kusambaza ulioimarishwa kwa Azure

Hazina inajumuisha faili zote muhimu za usanidi, msimbo wa chanzo, na ufafanuzi wa miundombinu ili kuanza haraka na utekelezaji wa seva ya MCP tayari kwa uzalishaji.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Utekelezaji wa sampuli wa MCP kwa kutumia Azure Functions na Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Utekelezaji wa sampuli wa MCP kwa kutumia Azure Functions na C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Utekelezaji wa sampuli wa MCP kwa kutumia Azure Functions na Node/TypeScript.

## Mambo Muhimu ya Kumbuka

- SDK za MCP zinatoa zana maalum za lugha kwa kutekeleza suluhisho thabiti za MCP
- Mchakato wa kudhibiti na kujaribu ni muhimu kwa programu za MCP zinazotegemewa
- Violezo vya vidokezo vinavyoweza kutumika tena huwezesha mwingiliano thabiti wa AI
- Mitiririko ya kazi iliyoundwa vizuri inaweza kuandaa kazi ngumu kwa kutumia zana nyingi
- Kutekeleza suluhisho za MCP kunahitaji kuzingatia usalama, utendaji, na udhibiti wa makosa

## Zoezi

Buni mtiririko wa kazi wa MCP wa vitendo unaoshughulikia tatizo halisi katika uwanja wako:

1. Tambua zana 3-4 ambazo zingekuwa muhimu kutatua tatizo hili
2. Unda mchoro wa mtiririko wa kazi unaoonyesha jinsi zana hizi zinavyoshirikiana
3. Tekeleza toleo la msingi la moja ya zana kwa kutumia lugha unayopendelea
4. Unda kiolezo cha vidokezo ambacho kingesaidia modeli kutumia zana yako kwa ufanisi

## Rasilimali za Ziada

---

Next: [Mada za Juu](../05-AdvancedTopics/README.md)

**Kanusho**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au kutokuelewana. Hati asilia katika lugha yake ya kiasili inapaswa kuzingatiwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu ya kibinadamu inapendekezwa. Hatuwajibiki kwa maelewano mabaya au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.