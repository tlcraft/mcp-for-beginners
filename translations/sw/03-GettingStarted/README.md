<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T00:44:02+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sw"
}
-->
## Kuanzia  

Sehemu hii ina masomo kadhaa:

- **1 Server yako ya kwanza**, katika somo hili la kwanza, utajifunza jinsi ya kuunda server yako ya kwanza na kuichunguza kwa kutumia chombo cha inspector, njia muhimu ya kujaribu na kutatua matatizo ya server yako, [kwenda somo](/03-GettingStarted/01-first-server/README.md)

- **2 Mteja**, katika somo hili, utajifunza jinsi ya kuandika mteja ambaye anaweza kuungana na server yako, [kwenda somo](/03-GettingStarted/02-client/README.md)

- **3 Mteja na LLM**, njia bora zaidi ya kuandika mteja ni kwa kuongeza LLM ili iweze "kujadiliana" na server yako kuhusu nini cha kufanya, [kwenda somo](/03-GettingStarted/03-llm-client/README.md)

- **4 Kutumia mode ya GitHub Copilot Agent ya server katika Visual Studio Code**. Hapa, tunachunguza jinsi ya kuendesha MCP Server yetu kutoka ndani ya Visual Studio Code, [kwenda somo](/03-GettingStarted/04-vscode/README.md)

- **5 Kutumia kutoka SSE (Server Sent Events)** SSE ni standard ya kupeleka data kutoka server kwenda mteja kwa mtiririko, kuruhusu server kusukuma taarifa za moja kwa moja kwa wateja kupitia HTTP [kwenda somo](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming na MCP (Streamable HTTP)**. Jifunze kuhusu mtiririko wa kisasa wa HTTP, taarifa za maendeleo, na jinsi ya kutekeleza server na mteja wa MCP wenye uwezo wa kupanuka na wa wakati halisi kwa kutumia Streamable HTTP. [kwenda somo](/03-GettingStarted/06-http-streaming/README.md)

- **7 Kutumia AI Toolkit kwa VSCode** ili kutumia na kujaribu MCP Clients na Servers zako [kwenda somo](/03-GettingStarted/07-aitk/README.md)

- **8 Upimaji**. Hapa tutazingatia hasa jinsi ya kujaribu server na mteja wetu kwa njia mbalimbali, [kwenda somo](/03-GettingStarted/08-testing/README.md)

- **9 Uenezaji**. Sura hii itachunguza njia mbalimbali za kueneza suluhisho zako za MCP, [kwenda somo](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) ni protocol wazi inayosanidi jinsi programu zinavyotoa muktadha kwa LLMs. Fikiria MCP kama bandari ya USB-C kwa programu za AI - hutoa njia ya kawaida ya kuunganisha modeli za AI na vyanzo tofauti vya data na zana.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kuandaa mazingira ya maendeleo kwa MCP kwa C#, Java, Python, TypeScript, na JavaScript
- Kujenga na kueneza server za MCP za msingi zenye vipengele maalum (rasilimali, prompts, na zana)
- Kuunda programu za mwenyeji zinazounganisha na server za MCP
- Kupima na kutatua matatizo ya utekelezaji wa MCP
- Kuelewa changamoto za kawaida za usanidi na suluhisho zake
- Kuunganisha utekelezaji wako wa MCP na huduma maarufu za LLM

## Kuandaa Mazingira Yako ya MCP

Kabla ya kuanza kazi na MCP, ni muhimu kuandaa mazingira yako ya maendeleo na kuelewa mtiririko wa kazi wa msingi. Sehemu hii itakuongoza hatua za mwanzo za kuhakikisha kuanza kwa MCP kunakuwa rahisi.

### Mahitaji ya Awali

Kabla ya kuingia kwenye maendeleo ya MCP, hakikisha una:

- **Mazingira ya Maendeleo**: Kwa lugha uliyochagua (C#, Java, Python, TypeScript, au JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, au mhariri wa kisasa wa msimbo wowote
- **Wasimamizi wa Pakiti**: NuGet, Maven/Gradle, pip, au npm/yarn
- **API Keys**: Kwa huduma zozote za AI unazopanga kutumia katika programu zako za mwenyeji


### SDK Rasmi

Katika sura zijazo utaona suluhisho zilizojengwa kwa kutumia Python, TypeScript, Java na .NET. Hapa kuna SDK zote rasmi zinazotegemewa.

MCP hutoa SDK rasmi kwa lugha nyingi:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Inasimamiwa kwa ushirikiano na Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Inasimamiwa kwa ushirikiano na Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Utekelezaji rasmi wa TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Utekelezaji rasmi wa Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Utekelezaji rasmi wa Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Inasimamiwa kwa ushirikiano na Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Utekelezaji rasmi wa Rust

## Muhimu Kumbuka

- Kuandaa mazingira ya maendeleo ya MCP ni rahisi kwa kutumia SDK za lugha husika
- Kujenga server za MCP kunahusisha kuunda na kusajili zana zenye schemas wazi
- Wateja wa MCP huungana na server na modeli ili kutumia uwezo ulioongezwa
- Kupima na kutatua matatizo ni muhimu kwa utekelezaji wa MCP unaotegemewa
- Chaguzi za uenezaji zinatofautiana kutoka maendeleo ya ndani hadi suluhisho za wingu

## Mazoezi

Tuna seti ya mifano inayokamilisha mazoezi utakayoyaona katika sura zote za sehemu hii. Zaidi ya hayo kila sura pia ina mazoezi na kazi zake za nyumbani

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [Jenga Agents ukitumia Model Context Protocol kwenye Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP ya Mbali na Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Nini kinachofuata

Ifuatayo: [Kuunda MCP Server yako ya kwanza](/03-GettingStarted/01-first-server/README.md)

**Kiasi cha majuto**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kuwa tafsiri za kiotomatiki zinaweza kuwa na makosa au kasoro. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo halali. Kwa taarifa muhimu, tafsiri ya kitaalamu na ya binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zitokanazo na matumizi ya tafsiri hii.