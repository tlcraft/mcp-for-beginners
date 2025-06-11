<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:14:52+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sw"
}
-->
## Kuanzia  

Sehemu hii ina masomo kadhaa:

- **1 Server yako ya kwanza**, katika somo hili la kwanza, utajifunza jinsi ya kuunda server yako ya kwanza na kuichunguza kwa kutumia chombo cha inspector, njia muhimu ya kujaribu na kutatua matatizo ya server yako, [kwenda somo](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, katika somo hili, utajifunza jinsi ya kuandika client inayoweza kuungana na server yako, [kwenda somo](/03-GettingStarted/02-client/README.md)

- **3 Client yenye LLM**, njia bora zaidi ya kuandika client ni kwa kuongeza LLM ili iweze "kujadiliana" na server yako kuhusu kinachotakiwa kufanywa, [kwenda somo](/03-GettingStarted/03-llm-client/README.md)

- **4 Kutumia mode ya GitHub Copilot Agent ya server ndani ya Visual Studio Code**. Hapa, tunatazama jinsi ya kuendesha MCP Server yetu kutoka ndani ya Visual Studio Code, [kwenda somo](/03-GettingStarted/04-vscode/README.md)

- **5 Kutumia kutoka SSE (Server Sent Events)** SSE ni standard ya usambazaji wa data kutoka server kwenda client, ikiruhusu server kusukuma masasisho ya muda halisi kwa clients kupitia HTTP [kwenda somo](/03-GettingStarted/05-sse-server/README.md)

- **6 Kutumia AI Toolkit kwa VSCode** kwa ajili ya kutumia na kujaribu MCP Clients na Servers zako [kwenda somo](/03-GettingStarted/06-aitk/README.md)

- **7 Kupima**. Hapa tutazingatia hasa jinsi ya kupima server na client zetu kwa njia tofauti, [kwenda somo](/03-GettingStarted/07-testing/README.md)

- **8 Utekelezaji**. Sura hii itaangalia njia tofauti za kupeleka suluhisho zako za MCP, [kwenda somo](/03-GettingStarted/08-deployment/README.md)


Model Context Protocol (MCP) ni protocol wazi inayobainisha jinsi programu zinavyotoa muktadha kwa LLMs. Fikiria MCP kama bandari ya USB-C kwa programu za AI - inatoa njia iliyosanifiwa ya kuunganisha modeli za AI na vyanzo mbalimbali vya data na zana.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kuandaa mazingira ya maendeleo kwa MCP kwa C#, Java, Python, TypeScript, na JavaScript
- Kujenga na kupeleka server za MCP za msingi zenye vipengele maalum (rasilimali, prompts, na zana)
- Kuunda programu mwenyeji zinazounganisha na server za MCP
- Kupima na kutatua matatizo ya utekelezaji wa MCP
- Kuelewa changamoto za kawaida za usanidi na suluhisho zake
- Kuunganisha utekelezaji wako wa MCP na huduma maarufu za LLM

## Kuandaa Mazingira Yako ya MCP

Kabla hujaanza kazi na MCP, ni muhimu kujiandaa mazingira ya maendeleo na kuelewa mtiririko wa kazi wa msingi. Sehemu hii itakuongoza kupitia hatua za mwanzo za usanidi ili kuhakikisha kuanza kwa MCP kwa urahisi.

### Mahitaji ya Awali

Kabla ya kuingia kwenye maendeleo ya MCP, hakikisha una:

- **Mazingira ya Maendeleo**: Kwa lugha uliyochagua (C#, Java, Python, TypeScript, au JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, au mhariri wa nambari wa kisasa yeyote
- **Wasimamizi wa Pakiti**: NuGet, Maven/Gradle, pip, au npm/yarn
- **API Keys**: Kwa huduma zozote za AI unazopanga kutumia katika programu zako mwenyeji


### SDK Rasmi

Katika sura zijazo utaona suluhisho zilizojengwa kwa kutumia Python, TypeScript, Java na .NET. Hapa ni SDK zote zinazotolewa rasmi.

MCP hutoa SDK rasmi kwa lugha nyingi:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Inasimamiwa kwa ushirikiano na Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Inasimamiwa kwa ushirikiano na Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Utekelezaji rasmi wa TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Utekelezaji rasmi wa Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Utekelezaji rasmi wa Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Inasimamiwa kwa ushirikiano na Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Utekelezaji rasmi wa Rust

## Muhimu Kuu

- Kuandaa mazingira ya maendeleo ya MCP ni rahisi kwa kutumia SDK za lugha tofauti
- Kujenga server za MCP kunahusisha kuunda na kusajili zana zenye schema wazi
- MCP clients huungana na server na modeli ili kutumia uwezo ulioongezwa
- Kupima na kutatua matatizo ni muhimu kwa utekelezaji imara wa MCP
- Chaguzi za utekelezaji ni kutoka maendeleo ya ndani hadi suluhisho za wingu

## Mazoezi

Tuna seti ya mifano inayokamilisha mazoezi utakayoyaona katika sura zote za sehemu hii. Zaidi ya hayo kila sura pia ina mazoezi na kazi zake.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Kifuatacho

Ifuatayo: [Kuunda MCP Server yako ya kwanza](/03-GettingStarted/01-first-server/README.md)

**Kasi ya Majukumu**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au upotovu wa maana. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatuna dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.