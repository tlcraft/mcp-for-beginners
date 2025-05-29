<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-29T20:20:26+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "br"
}
-->
## Kemm Daouzañ  

Ar rann-se en deus meur a lezenn:

- **-1- Ho servijer kentañ**, er lezenn gentañ-mañ, deskiñ a rez penaos krouiñ ho servijer kentañ ha sellet ouzh e labour gant ar benveg inspecter, ur mod talvoudus evit klask ha disklêriañ ho servijer, [d'ar lezenn](/03-GettingStarted/01-first-server/README.md)

- **-2- Klient**, er lezenn-mañ, deskiñ a rez penaos skrivañ ur klient a c’hell kevreañ gant ho servijer, [d'ar lezenn](/03-GettingStarted/02-client/README.md)

- **-3- Klient gant LLM**, ur mod gwelloc’h evit skrivañ ur klient eo ouzhpennañ ur LLM da hemañ evit ma c’hell "kelaouiñ" gant ho servijer war ar pezh da ober, [d'ar lezenn](/03-GettingStarted/03-llm-client/README.md)

- **-4- Konsumañ ur servijer mod Agent GitHub Copilot e Visual Studio Code**. Amañ e sellomp ouzh mont war-raok hon MCP Server eus Visual Studio Code, [d'ar lezenn](/03-GettingStarted/04-vscode/README.md)

- **-5- Konsumañ gant SSE (Server Sent Events)** SSE zo ur standart evit stlennañ a servijer da klient, a ro d’ar servijeroù an tu da stlennañ hiziv-holl d’ar klientoù dre HTTP [d'ar lezenn](/03-GettingStarted/05-sse-server/README.md)

- **-6- Implij ar C’hit Toolkit AI evit VSCode** evit konsumañ ha testenniñ ho MCP Klientoù ha Servijeroù [d'ar lezenn](/03-GettingStarted/06-aitk/README.md)

- **-7- Testañ**. Amañ e vo muioc’h a sell war an doareoù da zistagañ hon servijer ha hon klient, [d'ar lezenn](/03-GettingStarted/07-testing/README.md)

- **-8- Deployañ**. Ar pennad-se a sell ouzh doareoù disheñvel da deployañ ho solucioù MCP, [d'ar lezenn](/03-GettingStarted/08-deployment/README.md)


Ar Model Context Protocol (MCP) zo ur protokol digor a stardal penaos ma ro ar raktresoù kontekst d'ar LLM. Sell ouzh MCP evel ur porzh USB-C evit ar c’hiladoù AI - e ro un doare standard da kevreañ modeloù AI gant disoc’hoù data ha ostilhoù disheñvel.

## Palioù ar C’hlask

A-benn fin ar lezenn-mañ e vo tu deoc’h:

- Krouiñ an enskrivadurioù diorren evit MCP e C#, Java, Python, TypeScript, ha JavaScript
- Sevel ha deployañ servijeroù MCP diazez gant perzhioù personelaet (amantadoù, stummoù, ha ostilhoù)
- Krouiñ ar raktresoù host a kevreañ gant servijeroù MCP
- Testañ ha disklêriañ implijadennoù MCP
- Kompren an diaesterioù en aozadur hag o diskoulmoù
- Kevreañ ho implijadennoù MCP gant servijoù LLM brudet

## Krouiñ ho Endro MCP

A-raok ma kregiñ gant MCP, pouezus eo prestaat ho endro diorren ha kompren ar mod labour diazez. Ar rann-se a sikour ac’hanoc’h gant ar stummoù kentañ evit krouiñ ur servijenn aes gant MCP.

### Prerequisiteoù

A-raok ma kregiñ gant diorren MCP, gwiriit e vez deoc’h:

- **Endro diorren**: Evit ho yezh dibabet (C#, Java, Python, TypeScript pe JavaScript)
- **IDE/Embannour**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm pe ur c’hod embannour modern all
- **Menedourien paketioù**: NuGet, Maven/Gradle, pip, pe npm/yarn
- **Anezenn API**: Evit an holl servijoù AI ma vo implijet e ho raktresoù host


### SDKioù Ofisiel

Er pennadoù da zont e welit solucioù krouet gant Python, TypeScript, Java ha .NET. Setu an holl SDKoù ofisiel skoazellet.

MCP a ro SDKoù ofisiel evit meur a yezh:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Kenstrolliet gant Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Kenstrolliet gant Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implijadenn ofisiel TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implijadenn ofisiel Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implijadenn ofisiel Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Kenstrolliet gant Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implijadenn ofisiel Rust

## Peseurt Poentioù Talvoudus

- Krouiñ un endro diorren MCP a zo aes gant SDKoù yezh-spesel
- Sevel servijeroù MCP a dalvez da grouiñ ha enrollañ ostilhoù gant skemas sklaer
- Klientoù MCP a kevrea ouzh servijeroù ha modeloù evit implijout o galloudoù estrekhet
- Testañ ha disklêriañ zo pouezus evit implijadennoù MCP a-feson
- Displegañ deployañ a stummoù disheñvel, eus diorren lec’hel betek solucioù war an tonkad

## Praktikañ

Bez’ ez eus ur roll eus samploù a ziskouez an exerciceoù e pep pennad eus ar rann-se. War-lerc’h e vez ivez exerciceoù ha labourioù war al lec’hienn.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Adalioù ouzhpenn

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Petra a zeu

Da zont: [Krouiñ ho Servijer MCP kentañ](/03-GettingStarted/01-first-server/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.