<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:07:42+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "br"
}
-->
## Kemm Daouzh  

Ar rummad-mañ en deus meur a lezenn:

- **1 Ho servijer kentañ**, e lezenn gentañ-mañ, deskiñ a rez penaos krouiñ ho servijer kentañ ha sellet ouzhpenn anezhañ gant ar c'hementer anavezout, ur mod talvoudus evit testañ ha diwallout ho servijer, [d'ar lezenn](/03-GettingStarted/01-first-server/README.md)

- **2 Klient**, e lezenn-mañ, deskiñ a rez penaos skrivañ ur klient a c'hell mont e darempred gant ho servijer, [d'ar lezenn](/03-GettingStarted/02-client/README.md)

- **3 Klient gant LLM**, un doare gwelloc'h evit skrivañ ur klient eo ouzhpennañ ur LLM evit ma c'hellfe "kemer perzh" gant ho servijer diwar-benn ar pezh da ober, [d'ar lezenn](/03-GettingStarted/03-llm-client/README.md)

- **4 Implijout ur servijer MCP e mod Agent GitHub Copilot e Visual Studio Code**. Amañ e sellomp ouzh mont e darempred gant hor servijer MCP en un doare dielfennañ e Visual Studio Code, [d'ar lezenn](/03-GettingStarted/04-vscode/README.md)

- **5 Implijout dre SSE (Server Sent Events)** SSE zo ur standart evit stlammoù servijer-dre-klient, o reiñ d'ar servijeroù ar galloud da stagañ kemmoù e gwirionez war ar mare da vat d'ar klientoù dre HTTP [d'ar lezenn](/03-GettingStarted/05-sse-server/README.md)

- **6 Implijout ar C'hit Toolkit AI evit VSCode** evit implijout ha testañ ho MCP Klientoù ha Servijeroù [d'ar lezenn](/03-GettingStarted/06-aitk/README.md)

- **7 Testañ**. Amañ e vo roet pouez bras da geñver penaos testañ hor servijer ha hor klient e meur a zoare, [d'ar lezenn](/03-GettingStarted/07-testing/README.md)

- **8 Dibarzhiañ**. Kelaouenn-mañ a sell war meur a zoare da zibab ho soluzioù MCP, [d'ar lezenn](/03-GettingStarted/08-deployment/README.md)


Ar Model Context Protocol (MCP) zo ur protokol digor a standardez penaos e ro arventennoù da LLM. Sellit ouzh MCP evel ur porzh USB-C evit ar c'hinnigoù AI - e ro ur mod standard da liammañ modelloù AI gant meur a fennad roadennoù ha ostilhoù.

## Palioù deskiñ

A-benn fin an lezenn-mañ, e c'hellit:

- Krouiñ an endro diorren evit MCP e C#, Java, Python, TypeScript, ha JavaScript
- Sevel ha dibarzhiañ servijeroù MCP diazez gant perzhioù personelaet (resoursoù, prenañ, ha ostilhoù)
- Krouiñ arventennoù kêr a staga ouzh servijeroù MCP
- Testañ ha diwallout implijadennoù MCP
- Kompren ar c'hudennoù kentañ hag o diskoulmoù
- Stagañ ho implijadennoù MCP gant servijoù LLM brudet

## Krouiñ ho Endro MCP

A-raok mont e darempred gant MCP, pouezus eo prientiñ ho endro diorren ha kompren ar raktres diazez. Ar rummad-mañ a sikour ac'hanoc'h da vont dre ar palioù kentañ evit ur krogiñ aes gant MCP.

### Goulennioù kentañ

A-raok mont e darempred gant diorren MCP, gwiriit e vez:

- **Endro Diorrezh**: Evit ar yezh ho peus dibabet (C#, Java, Python, TypeScript, pe JavaScript)
- **IDE/Embannerezh**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, pe un embanner kod modern all
- **Menedourien Pakadoù**: NuGet, Maven/Gradle, pip, pe npm/yarn
- **Alioù API**: Evit ar servijoù AI a fell deoc'h implijout en ho arventennoù kêr


### SDKioù Ofisiel

Er pennadoù da zont e welit soluzioù savet gant Python, TypeScript, Java ha .NET. Setu an holl SDKioù ofisiel a zo bet skoazellet.

MCP a ginnig SDKioù ofisiel evit meur a yezh :
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Meret e kevredigezh gant Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Meret e kevredigezh gant Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implijadur ofisiel TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implijadur ofisiel Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implijadur ofisiel Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Meret e kevredigezh gant Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implijadur ofisiel Rust

## Peseurt traoù da retenniñ

- Ar staliñ un endro diorren MCP zo aes gant SDKioù yezh-spesifik
- Sevel servijeroù MCP a dalvez da grouiñ ha enrollañ ostilhoù gant skemmoù sklaer
- Klientoù MCP a staga ouzh servijeroù ha modelloù evit implijout galloudoù ouzhpenn
- Testañ ha diwallout zo pouezus evit implijadennoù MCP a-berzh
- Mont e darempred a c'hoarvez eus diorren lec'hel betek soluzioù e-keñver an neñv

## Praktik

Eus ar samploù a zo evit gouzout muioc'h war ar c'hoantoù a welit e pep pennad en ar rummad-mañ. En o zouez e vez ivez c'hoantoù ha labourioù personelaet e pep pennad.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../../../03-GettingStarted/samples/javascript)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Ressourioù ouzhpenn

- [Sevel Agentoù en implij Model Context Protocol war Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP diavaez gant Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Petra da heul

Da-heul: [Krouiñ ho Servijer MCP kentañ](/03-GettingStarted/01-first-server/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.