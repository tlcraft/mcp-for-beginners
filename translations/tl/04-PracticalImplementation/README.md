<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:22:09+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "tl"
}
-->
# Praktikal nga Pagpatuman

Ang praktikal nga pagpatuman mao ang lugar diin ang gahum sa Model Context Protocol (MCP) mahimong makita ug masabtan. Samtang importante ang pagsabot sa teyorya ug arkitektura sa MCP, ang tinuod nga bili makita kung imo kining gamiton aron magtukod, mag-test, ug mag-deploy og mga solusyon nga makatubag sa tinuod nga mga problema sa kalibutan. Kini nga kapitulo nagtabang sa pagtabok sa kalainan tali sa konseptwal nga kahibalo ug praktikal nga pag-develop, nga naggiya kanimo sa proseso sa pagdala sa MCP-based nga mga aplikasyon sa kinabuhi.

Bisan pa man kung nag-develop ka og intelihenteng mga assistant, nag-integrate og AI sa mga negosyo nga workflow, o nagtukod og custom nga mga himan para sa pagproseso sa datos, ang MCP naghatag og flexible nga pundasyon. Ang iyang language-agnostic nga disenyo ug opisyal nga SDKs para sa mga popular nga programming languages naghimo niini nga accessible sa daghang mga developer. Pinaagi sa paggamit niini nga mga SDK, dali ka makabuhat og prototype, mag-iterate, ug mag-scale sa imong mga solusyon sa lain-laing mga platform ug palibot.

Sa mosunod nga mga seksyon, makit-an nimo ang mga praktikal nga pananglitan, sample code, ug mga estratehiya sa pag-deploy nga nagpakita kung giunsa pag-implementar ang MCP sa C#, Java, TypeScript, JavaScript, ug Python. Makakat-on usab ka kung giunsa pag-debug ug pag-test ang imong MCP servers, pagdumala sa mga API, ug pag-deploy sa mga solusyon sa cloud gamit ang Azure. Kini nga mga hands-on nga kahimanan gidisenyo aron mapadali ang imong pagkat-on ug matabangan ka nga kumpiyansang magtukod og lig-on, production-ready nga MCP applications.

## Overview

Kini nga leksyon nagpunting sa praktikal nga aspeto sa pagpatuman sa MCP sa daghang programming languages. Atong susihon kung giunsa paggamit ang MCP SDKs sa C#, Java, TypeScript, JavaScript, ug Python aron magtukod og lig-on nga mga aplikasyon, mag-debug ug mag-test sa MCP servers, ug maghimo og reusable nga mga resources, prompts, ug tools.

## Learning Objectives

Pagkahuman sa leksyon, mahimo nimong:

- Ipatuman ang MCP solutions gamit ang opisyal nga SDKs sa lain-laing programming languages
- Sistematikong mag-debug ug mag-test sa MCP servers
- Maghimo ug mogamit sa mga server features (Resources, Prompts, ug Tools)
- Magdisenyo og epektibong MCP workflows para sa komplikadong mga buluhaton
- I-optimize ang MCP implementations para sa performance ug kasaligan

## Official SDK Resources

Ang Model Context Protocol nagtanyag og opisyal nga SDKs para sa daghang mga lengguwahe:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Pagtrabaho gamit ang MCP SDKs

Kini nga seksyon naghatag og praktikal nga mga pananglitan sa pagpatuman sa MCP sa daghang programming languages. Makita nimo ang sample code sa `samples` nga direktoryo nga gipang-organisar base sa lengguwahe.

### Available Samples

Ang repository naglakip og mga sample implementations sa mosunod nga mga lengguwahe:

- C#
- Java
- TypeScript
- JavaScript
- Python

Ang matag sample nagpakita sa yawe nga mga konsepto sa MCP ug mga pattern sa pagpatuman alang sa partikular nga lengguwahe ug ecosystem.

## Core Server Features

Ang MCP servers makaimplementar sa bisan unsang kombinasyon sa mosunod nga mga features:

### Resources
Ang Resources naghatag og konteksto ug datos para gamiton sa user o AI model:
- Mga dokumento nga repositoryo
- Mga knowledge base
- Mga structured data sources
- File systems

### Prompts
Ang Prompts mga templated nga mga mensahe ug workflows para sa mga user:
- Pre-defined nga mga template sa pakig-istorya
- Giya nga mga pattern sa interaksyon
- Espesyal nga mga estruktura sa diyalogo

### Tools
Ang Tools mga function nga ipahigayon sa AI model:
- Mga gamit para sa pagproseso sa datos
- Integrasyon sa external nga API
- Mga computational nga kakayahan
- Search functionality

## Sample Implementations: C#

Ang opisyal nga C# SDK repository naglakip og daghang sample implementations nga nagpakita sa lain-laing aspeto sa MCP:

- **Basic MCP Client**: Simpleng pananglitan kung giunsa paghimo og MCP client ug pagtawag sa mga tools
- **Basic MCP Server**: Minimal nga server implementation nga adunay basic nga pagrehistro sa tools
- **Advanced MCP Server**: Full-featured nga server nga adunay tool registration, authentication, ug error handling
- **ASP.NET Integration**: Mga pananglitan nga nagpakita sa integrasyon sa ASP.NET Core
- **Tool Implementation Patterns**: Nagkalain-laing mga pattern para sa pagpatuman sa mga tools nga adunay lain-laing level sa komplikasyon

Ang MCP C# SDK anaa pa sa preview ug ang mga API mahimong mausab. Padayon namong i-update kini nga blog samtang mag-evolve ang SDK.

### Key Features 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Pagtukod sa imong [unang MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Para sa kompleto nga mga sample sa C# implementation, bisitaha ang [opisyal nga C# SDK samples repository](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample implementation: Java Implementation

Ang Java SDK nagtanyag og lig-on nga mga kapilian sa pagpatuman sa MCP uban sa enterprise-grade nga mga features.

### Key Features

- Integrasyon sa Spring Framework
- Lig-on nga type safety
- Suporta sa reactive programming
- Komprehensibo nga error handling

Para sa kompleto nga Java implementation sample, tan-awa ang [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) sa samples nga direktoryo.

## Sample implementation: JavaScript Implementation

Ang JavaScript SDK nagtanyag og gaan ug flexible nga pamaagi sa pagpatuman sa MCP.

### Key Features

- Suporta sa Node.js ug browser
- Promise-based nga API
- Sayon nga integrasyon sa Express ug uban pang mga framework
- Suporta sa WebSocket para sa streaming

Para sa kompleto nga JavaScript implementation sample, tan-awa ang [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) sa samples nga direktoryo.

## Sample implementation: Python Implementation

Ang Python SDK nagtanyag og Pythonic nga pamaagi sa pagpatuman sa MCP uban sa maayo nga integrasyon sa ML frameworks.

### Key Features

- Async/await nga suporta gamit ang asyncio
- Integrasyon sa Flask ug FastAPI
- Simple nga pagrehistro sa tools
- Native nga integrasyon sa mga popular nga ML libraries

Para sa kompleto nga Python implementation sample, tan-awa ang [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) sa samples nga direktoryo.

## API management 

Ang Azure API Management usa ka maayo nga solusyon kung giunsa nato maprotektahan ang MCP Servers. Ang ideya mao ang pagbutang og Azure API Management instance sa atubangan sa imong MCP Server ug pasagdan kini sa pagdumala sa mga feature nga kasagaran nimo gusto sama sa:

- rate limiting
- token management
- monitoring
- load balancing
- security

### Azure Sample

Aniya ang usa ka Azure Sample nga nagbuhat niini, i.e [paghimo og MCP Server ug pagprotekta niini gamit ang Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Tan-awa kung giunsa ang authorization flow sa mosunod nga hulagway:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Sa hulagway sa ibabaw, ang mga mosunod nahitabo:

- Ang Authentication/Authorization gihimo gamit ang Microsoft Entra.
- Ang Azure API Management naglihok isip gateway ug naggamit og mga polisiya aron idirekta ug dumala ang trapiko.
- Ang Azure Monitor nag-log sa tanan nga mga request alang sa dugang nga analisis.

#### Authorization flow

Tan-awon nato og mas detalyado ang authorization flow:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

Kat-on pa og dugang bahin sa [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Pag-deploy sa Remote MCP Server sa Azure

Tan-awon nato kung mahimo ba nato i-deploy ang sample nga among gihisgutan sa taas:

1. I-clone ang repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. I-register ang `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` ug hulata ang pipila ka panahon aron masuta kung nahuman na ang registration.

3. Patakba kini nga [azd](https://aka.ms/azd) nga command aron i-provision ang api management service, function app (uban ang code) ug tanan nga kinahanglanon nga Azure resources

    ```shell
    azd up
    ```

    Kini nga mga command angay mag-deploy sa tanan nga cloud resources sa Azure

### Pagsulay sa imong server gamit ang MCP Inspector

1. Sa usa ka **bag-ong terminal window**, i-install ug patakba ang MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Makita nimo ang interface nga susama niini:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tl.png) 

2. CTRL click aron i-load ang MCP Inspector web app gikan sa URL nga gipakita sa app (pananglitan http://127.0.0.1:6274/#resources)
3. I-set ang transport type sa `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` ug i-**Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**.  I-klik ang usa ka tool ug i-**Run Tool**.  

Kung ang tanan nga mga lakang nagmalampuson, karon nakonektar na ka sa MCP server ug nakatawag ka na og tool.

## MCP servers para sa Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Kini nga hugpong sa mga repositoryo mao ang quickstart template para sa pagtukod ug pag-deploy sa custom remote MCP (Model Context Protocol) servers gamit ang Azure Functions sa Python, C# .NET o Node/TypeScript. 

Ang mga Sample naghatag og kompleto nga solusyon nga nagtugot sa mga developer nga:

- Magtukod ug magpadagan lokal: Mag-develop ug mag-debug sa MCP server sa lokal nga makina
- Mag-deploy sa Azure: Sayon nga pag-deploy sa cloud gamit ang usa ka yano nga azd up command
- Maka-konektar gikan sa mga kliyente: Maka-konektar sa MCP server gikan sa lain-laing mga kliyente lakip na ang VS Code’s Copilot agent mode ug ang MCP Inspector tool

### Key Features:

- Seguridad nga naka-disenyo: Ang MCP server giprotektahan gamit ang mga yawe ug HTTPS
- Mga opsyon sa authentication: Nagsuporta sa OAuth gamit ang built-in nga auth ug/o API Management
- Network isolation: Nagatugot sa network isolation gamit ang Azure Virtual Networks (VNET)
- Serverless architecture: Naggamit sa Azure Functions para sa scalable, event-driven nga pagdagan
- Lokal nga pag-develop: Komprehensibo nga suporta sa lokal nga pag-develop ug pag-debug
- Yano nga pag-deploy: Streamlined nga proseso sa pag-deploy sa Azure

Ang repository naglakip sa tanan nga kinahanglanon nga configuration files, source code, ug infrastructure definitions aron dali ka makasugod sa production-ready nga MCP server implementation.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Sample nga implementasyon sa MCP gamit ang Azure Functions sa Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Sample nga implementasyon sa MCP gamit ang Azure Functions sa C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Sample nga implementasyon sa MCP gamit ang Azure Functions sa Node/TypeScript.

## Mga Pangunang Punto

- Ang MCP SDKs naghatag og mga lengguwahe-specific nga himan para sa pagpatuman sa lig-on nga MCP solutions
- Importante ang proseso sa pag-debug ug pag-test para sa kasaligan nga MCP applications
- Ang reusable prompt templates nagpasayon sa konsistent nga AI interactions
- Ang maayong pagdisenyo sa workflows makapahimo sa pag-organisar sa komplikadong mga buluhaton gamit ang daghang mga tools
- Ang pagpatuman sa MCP solutions nagkinahanglan og pagtagad sa seguridad, performance, ug error handling

## Ehersisyo

Disenyohi ang usa ka praktikal nga MCP workflow nga makatubag sa tinuod nga problema sa imong domain:

1. Ilhan ang 3-4 nga mga tools nga magamit para sa pagsulbad sa problema
2. Buhata ang workflow diagram nga nagpakita kung giunsa pag-interact ang mga tools
3. Ipatuman ang basic nga bersyon sa usa sa mga tools gamit ang imong paboritong lengguwahe
4. Buhata ang prompt template nga makatabang sa modelo nga epektibong gamiton ang imong tool

## Dugang nga mga Kahimanan


---

Sunod: [Advanced Topics](../05-AdvancedTopics/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na opisyal na sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.