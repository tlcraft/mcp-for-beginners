<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T18:24:13+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "sw"
}
-->
## Kuanzia  

Sehemu hii ina masomo kadhaa:

- **1 Server yako ya kwanza**, katika somo hili la kwanza, utajifunza jinsi ya kuunda server yako ya kwanza na kuichunguza kwa kutumia chombo cha inspector, njia muhimu ya kujaribu na kutatua matatizo ya server yako, [kwenda somo](/03-GettingStarted/01-first-server/README.md)

- **2 Mteja**, katika somo hili, utajifunza jinsi ya kuandika mteja anayeweza kuungana na server yako, [kwenda somo](/03-GettingStarted/02-client/README.md)

- **3 Mteja na LLM**, njia bora zaidi ya kuandika mteja ni kwa kuongeza LLM ili iweze "kujadiliana" na server yako kuhusu nini cha kufanya, [kwenda somo](/03-GettingStarted/03-llm-client/README.md)

- **4 Kutumia server kwa mode ya GitHub Copilot Agent katika Visual Studio Code**. Hapa, tunatazama jinsi ya kuendesha MCP Server yetu kutoka ndani ya Visual Studio Code, [kwenda somo](/03-GettingStarted/04-vscode/README.md)

- **5 Kutumia kutoka SSE (Server Sent Events)** SSE ni kiwango cha mtiririko wa data kutoka server kwenda kwa mteja, kinachoruhusu server kusukuma masasisho ya wakati halisi kwa wateja kupitia HTTP [kwenda somo](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP Streaming na MCP (Streamable HTTP)**. Jifunze kuhusu mtiririko wa kisasa wa HTTP, taarifa za maendeleo, na jinsi ya kutekeleza server na wateja wa MCP wenye uwezo wa kupanuka na wa wakati halisi kwa kutumia Streamable HTTP. [kwenda somo](/03-GettingStarted/06-http-streaming/README.md)

- **7 Kutumia AI Toolkit kwa VSCode** ili kutumia na kujaribu MCP Clients na Servers zako [kwenda somo](/03-GettingStarted/07-aitk/README.md)

- **8 Upimaji**. Hapa tutazingatia hasa jinsi ya kujaribu server na mteja wetu kwa njia mbalimbali, [kwenda somo](/03-GettingStarted/08-testing/README.md)

- **9 Utekelezaji**. Sura hii itatazama njia tofauti za kupeleka suluhisho zako za MCP, [kwenda somo](/03-GettingStarted/09-deployment/README.md)


Model Context Protocol (MCP) ni itifaki wazi inayoweka viwango vya jinsi programu zinavyotoa muktadha kwa LLMs. Fikiria MCP kama bandari ya USB-C kwa programu za AI - inatoa njia ya kawaida ya kuunganisha mifano ya AI na vyanzo tofauti vya data na zana.

## Malengo ya Kujifunza

Mwisho wa somo hili, utaweza:

- Kuandaa mazingira ya maendeleo kwa MCP katika C#, Java, Python, TypeScript, na JavaScript
- Kujenga na kupeleka server za MCP za msingi zenye vipengele maalum (rasilimali, maelekezo, na zana)
- Kuunda programu za mwenyeji zinazounganisha na server za MCP
- Kupima na kutatua matatizo ya utekelezaji wa MCP
- Kuelewa changamoto za kawaida za usanidi na suluhisho zake
- Kuunganisha utekelezaji wako wa MCP na huduma maarufu za LLM

## Kuandaa Mazingira Yako ya MCP

Kabla ya kuanza kufanya kazi na MCP, ni muhimu kuandaa mazingira yako ya maendeleo na kuelewa mtiririko wa kazi wa msingi. Sehemu hii itakuongoza kupitia hatua za mwanzo za usanidi ili kuhakikisha kuanza kwa urahisi na MCP.

### Mahitaji ya Awali

Kabla ya kuingia kwenye maendeleo ya MCP, hakikisha una:

- **Mazingira ya Maendeleo**: Kwa lugha uliyochagua (C#, Java, Python, TypeScript, au JavaScript)
- **IDE/Mhariri**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, au mhariri wa kisasa wa msimbo wowote
- **Wasimamizi wa Pakiti**: NuGet, Maven/Gradle, pip, au npm/yarn
- **API Keys**: Kwa huduma zozote za AI unazopanga kutumia katika programu zako za mwenyeji


### SDK Rasmi

Katika sura zinazofuata utaona suluhisho zilizojengwa kwa kutumia Python, TypeScript, Java na .NET. Hapa ni SDK zote zinazotambulika rasmi.

MCP hutoa SDK rasmi kwa lugha nyingi:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Inasimamiwa kwa ushirikiano na Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Inasimamiwa kwa ushirikiano na Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Utekelezaji rasmi wa TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Utekelezaji rasmi wa Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Utekelezaji rasmi wa Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Inasimamiwa kwa ushirikiano na Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Utekelezaji rasmi wa Rust

## Muhimu Kukumbuka

- Kuandaa mazingira ya maendeleo ya MCP ni rahisi kwa kutumia SDK za lugha maalum
- Kujenga server za MCP kunahusisha kuunda na kusajili zana zenye miundo wazi
- Wateja wa MCP huungana na server na mifano ili kutumia uwezo uliopanuliwa
- Kupima na kutatua matatizo ni muhimu kwa utekelezaji wa MCP unaotegemewa
- Chaguzi za utekelezaji zinatofautiana kutoka maendeleo ya ndani hadi suluhisho za wingu

## Mazoezi

Tuna seti ya mifano inayosaidia mazoezi utakayoyaona katika sura zote za sehemu hii. Zaidi ya hayo kila sura pia ina mazoezi na kazi zake binafsi

- [Kalkuleta ya Java](./samples/java/calculator/README.md)
- [Kalkuleta ya .Net](../../../03-GettingStarted/samples/csharp)
- [Kalkuleta ya JavaScript](./samples/javascript/README.md)
- [Kalkuleta ya TypeScript](./samples/typescript/README.md)
- [Kalkuleta ya Python](../../../03-GettingStarted/samples/python)

## Rasilimali Zaidi

- [Jenga Maajenti kwa kutumia Model Context Protocol kwenye Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP ya Mbali na Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Kifuatavyo

Kifuatavyo: [Kuunda MCP Server yako ya kwanza](./01-first-server/README.md)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.