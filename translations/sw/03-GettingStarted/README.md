<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:42:48+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sw"
}
-->
## Kuanzia  

Sehemu hii ina masomo kadhaa:

- **-1- Server yako ya kwanza**, katika somo hili la kwanza, utajifunza jinsi ya kuunda server yako ya kwanza na kuichunguza kwa kutumia chombo cha inspector, njia muhimu ya kujaribu na kutatua matatizo ya server yako, [kwenda somo](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, katika somo hili, utajifunza jinsi ya kuandika client inayoweza kuungana na server yako, [kwenda somo](/03-GettingStarted/02-client/README.md)

- **-3- Client yenye LLM**, njia bora zaidi ya kuandika client ni kwa kuongeza LLM ili iweze "kujadiliana" na server yako kuhusu nini cha kufanya, [kwenda somo](/03-GettingStarted/03-llm-client/README.md)

- **-4- Kutumia mode ya GitHub Copilot Agent ya server katika Visual Studio Code**. Hapa, tunatazama jinsi ya kuendesha MCP Server yetu ndani ya Visual Studio Code, [kwenda somo](/03-GettingStarted/04-vscode/README.md)

- **-5- Kutumia kutoka SSE (Server Sent Events)** SSE ni standard ya mtiririko wa data kutoka server kwenda client, kuruhusu server kusukuma masasisho ya wakati halisi kwa clients kupitia HTTP [kwenda somo](/03-GettingStarted/05-sse-server/README.md)

- **-6- Kutumia AI Toolkit kwa VSCode** kwa ajili ya kutumia na kujaribu MCP Clients na Servers zako [kwenda somo](/03-GettingStarted/06-aitk/README.md)

- **-7 Kupima**. Hapa tutazingatia hasa jinsi ya kupima server na client zetu kwa njia mbalimbali, [kwenda somo](/03-GettingStarted/07-testing/README.md)

- **-8- Utekelezaji**. Sura hii itachunguza njia tofauti za kupeleka suluhisho zako za MCP, [kwenda somo](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) ni protocol wazi inayobainisha jinsi programu zinavyotoa muktadha kwa LLMs. Fikiria MCP kama port ya USB-C kwa programu za AI - inatoa njia ya kawaida ya kuunganisha modeli za AI na vyanzo mbalimbali vya data na zana.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kuweka mazingira ya maendeleo kwa MCP katika C#, Java, Python, TypeScript, na JavaScript
- Kujenga na kupeleka servers za MCP za msingi zenye vipengele maalum (rasilimali, prompts, na zana)
- Kuunda programu za mwenyeji zinazounganisha na MCP servers
- Kupima na kutatua matatizo ya utekelezaji wa MCP
- Kuelewa changamoto za kawaida za usanidi na suluhisho zake
- Kuunganisha utekelezaji wako wa MCP na huduma maarufu za LLM

## Kuandaa Mazingira Yako ya MCP

Kabla hujaanza kazi na MCP, ni muhimu kuandaa mazingira yako ya maendeleo na kuelewa mtiririko wa msingi wa kazi. Sehemu hii itakuongoza kupitia hatua za awali za usanidi ili kuhakikisha kuanza kwa MCP kwa urahisi.

### Mahitaji ya Awali

Kabla ya kuanza maendeleo ya MCP, hakikisha una:

- **Mazingira ya Maendeleo**: Kwa lugha uliyochagua (C#, Java, Python, TypeScript, au JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, au mhariri mwingine wa kisasa wa msimbo
- **Wasimamizi wa Pakiti**: NuGet, Maven/Gradle, pip, au npm/yarn
- **API Keys**: Kwa huduma zozote za AI unazopanga kutumia katika programu zako za mwenyeji


### SDK Rasmi

Katika sura zinazofuata utaona suluhisho zilizojengwa kwa kutumia Python, TypeScript, Java na .NET. Hapa kuna SDK zote zinazotambulika rasmi.

MCP hutoa SDK rasmi kwa lugha mbalimbali:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Inatengenezwa kwa ushirikiano na Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Inatengenezwa kwa ushirikiano na Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Utekelezaji rasmi wa TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Utekelezaji rasmi wa Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Utekelezaji rasmi wa Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Inatengenezwa kwa ushirikiano na Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Utekelezaji rasmi wa Rust

## Muhimu Kumbuka

- Kuandaa mazingira ya maendeleo ya MCP ni rahisi kwa kutumia SDK maalum za lugha
- Kujenga MCP servers kunahusisha kuunda na kusajili zana zenye schemas wazi
- MCP clients huungana na servers na modeli ili kutumia uwezo wa ziada
- Kupima na kutatua matatizo ni muhimu kwa utekelezaji wa MCP wenye kuaminika
- Chaguzi za utekelezaji ni kutoka maendeleo ya ndani hadi suluhisho za wingu

## Mazoezi

Tuna seti ya mifano inayosaidia mazoezi utakayoyaona katika sura zote za sehemu hii. Zaidi ya hayo kila sura ina mazoezi na kazi zake binafsi

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [Jenga Agents kwa kutumia Model Context Protocol kwenye Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP na Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Nini Kifuatacho

Ifuatayo: [Kuunda MCP Server yako ya kwanza](/03-GettingStarted/01-first-server/README.md)

**Kiepukupu cha maelezo**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kuhakikisha usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati asili katika lugha yake ya asili inapaswa kuzingatiwa kama chanzo cha kuaminika. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubeba uwajibikaji wowote kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.