<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:21:16+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "mo"
}
-->
### -2- Tsim tshem project

Tam sim no uas koj twb tau nruab koj lub SDK lawm, cia peb tsim ib lub project tom ntej:

### -3- Tsim cov ntaub ntawv project

### -4- Tsim server code

### -5- Ntxiv ib qho cuab yeej thiab ib qho kev pab cuam

Ntxiv ib qho cuab yeej thiab ib qho kev pab cuam los ntawm kev ntxiv cov code hauv qab no:

### -6 Qhov code kawg

Cia peb ntxiv qhov code kawg uas peb xav tau kom server tuaj yeem khiav tau:

### -7- Sim server

Pib server nrog cov lus txib hauv qab no:

### -8- Khiav siv inspector

Inspector yog ib qho cuab yeej zoo uas tuaj yeem pib koj lub server thiab cia koj sib cuag nrog nws kom koj tuaj yeem sim seb nws ua haujlwm tau zoo. Cia peb pib nws:

> [!NOTE]
> nws yuav zoo txawv hauv "command" teb vim nws muaj lus txib rau khiav server nrog koj tus kheej runtime/

Koj yuav pom qhov user interface hauv qab no:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.mo.png)

1. Txuas rau server los ntawm kev xaiv khawm Connect  
   Thaum koj txuas rau server lawm, koj yuav pom qhov hauv qab no:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.mo.png)

1. Xaiv "Tools" thiab "listTools", koj yuav pom "Add" tshwm, xaiv "Add" thiab sau cov nqi parameter.

  Koj yuav pom qhov tshwm sim hauv qab no, yog li txhais tau tias yog qhov txiaj ntsig ntawm "add" cuab yeej:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.mo.png)

Zoo siab, koj twb ua tau thiab khiav koj thawj server lawm!

### Official SDKs

MCP muab cov SDKs official rau ntau hom lus:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Ua haujlwm nrog Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Ua haujlwm nrog Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Qhov official TypeScript implementation
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Qhov official Python implementation
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Qhov official Kotlin implementation
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Ua haujlwm nrog Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Qhov official Rust implementation

## Cov ntsiab lus tseem ceeb

- Teem kho ib qho MCP kev tsim kho ib puag ncig yooj yim nrog cov SDK raws li lus
- Tsim MCP servers muaj xws li kev tsim thiab sau npe cov cuab yeej nrog schemas meej
- Kev sim thiab debugging yog qhov tseem ceeb rau kev ua tiav ntawm MCP implementations

## Samples

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Assignment

Tsim ib qho yooj yim MCP server nrog ib qho cuab yeej uas koj nyiam:
1. Ua tus cuab yeej nyob rau hauv koj nyiam lus (.NET, Java, Python, lossis JavaScript).
2. Qhia cov input parameters thiab cov nqi rov qab.
3. Khiav inspector cuab yeej kom paub tseeb tias server ua haujlwm raws li kev xav.
4. Sim qhov implementation nrog ntau yam inputs.

## Solution

[Solution](./solution/README.md)

## Cov ntaub ntawv ntxiv

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Qhov tom ntej

Tom ntej: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.