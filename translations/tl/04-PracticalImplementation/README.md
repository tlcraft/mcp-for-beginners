<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:57:21+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "tl"
}
-->
# Praktikal na Pagpapatupad

Ang praktikal na pagpapatupad ang nagpapakita ng tunay na kapangyarihan ng Model Context Protocol (MCP). Bagamat mahalaga ang pag-unawa sa teorya at arkitektura ng MCP, ang tunay na halaga nito ay lumilitaw kapag inilapat mo ang mga konseptong ito upang bumuo, subukan, at i-deploy ang mga solusyon na tumutugon sa mga totoong problema. Ang kabanatang ito ay nag-uugnay sa pagitan ng teoretikal na kaalaman at aktwal na pag-develop, na ginagabayan ka sa proseso ng paggawa ng mga aplikasyon na batay sa MCP.

Kung ikaw man ay gumagawa ng mga intelligent assistant, nag-iintegrate ng AI sa mga workflow ng negosyo, o bumubuo ng mga custom na kasangkapan para sa pagproseso ng datos, nagbibigay ang MCP ng isang flexible na pundasyon. Ang disenyo nito na hindi nakadepende sa wika at ang mga opisyal na SDK para sa mga kilalang programming language ay ginagawang accessible ito sa malawak na hanay ng mga developer. Sa pamamagitan ng paggamit ng mga SDK na ito, mabilis kang makakagawa ng prototype, makakapag-iterate, at makakapag-scale ng iyong mga solusyon sa iba't ibang platform at kapaligiran.

Sa mga sumusunod na seksyon, makikita mo ang mga praktikal na halimbawa, sample code, at mga estratehiya sa deployment na nagpapakita kung paano ipatupad ang MCP sa C#, Java, TypeScript, JavaScript, at Python. Matututuhan mo rin kung paano i-debug at subukan ang iyong mga MCP server, pamahalaan ang mga API, at i-deploy ang mga solusyon sa cloud gamit ang Azure. Ang mga hands-on na materyales na ito ay idinisenyo upang pabilisin ang iyong pagkatuto at tulungan kang magtayo ng matibay at handang gamitin sa produksyon na mga aplikasyon ng MCP.

## Pangkalahatang-ideya

Ang araling ito ay nakatuon sa mga praktikal na aspeto ng pagpapatupad ng MCP sa iba't ibang programming language. Tatalakayin natin kung paano gamitin ang MCP SDKs sa C#, Java, TypeScript, JavaScript, at Python upang bumuo ng matibay na mga aplikasyon, mag-debug at mag-test ng MCP servers, at gumawa ng mga reusable na resources, prompts, at tools.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:
- Ipatupad ang mga solusyon ng MCP gamit ang opisyal na SDK sa iba't ibang programming language
- Sistematikong i-debug at subukan ang mga MCP server
- Gumawa at gumamit ng mga tampok ng server (Resources, Prompts, at Tools)
- Magdisenyo ng epektibong mga workflow ng MCP para sa mga komplikadong gawain
- I-optimize ang mga pagpapatupad ng MCP para sa performance at pagiging maaasahan

## Mga Opisyal na SDK na Mapagkukunan

Nagbibigay ang Model Context Protocol ng mga opisyal na SDK para sa iba't ibang wika:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Paggamit ng MCP SDKs

Nagbibigay ang seksyong ito ng mga praktikal na halimbawa ng pagpapatupad ng MCP sa iba't ibang programming language. Makikita mo ang mga sample code sa `samples` na direktoryo na nakaayos ayon sa wika.

### Mga Available na Sample

Kasama sa repository ang [mga sample na pagpapatupad](../../../04-PracticalImplementation/samples) sa mga sumusunod na wika:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Bawat sample ay nagpapakita ng mga pangunahing konsepto ng MCP at mga pattern ng pagpapatupad para sa partikular na wika at ecosystem.

## Pangunahing Tampok ng Server

Maaaring ipatupad ng mga MCP server ang anumang kumbinasyon ng mga tampok na ito:

### Resources
Nagbibigay ang Resources ng konteksto at datos para magamit ng user o AI model:
- Mga repositoryo ng dokumento
- Mga knowledge base
- Mga structured na pinagkukunan ng datos
- Mga file system

### Prompts
Ang Prompts ay mga templated na mensahe at workflow para sa mga user:
- Mga paunang-deklaradong template ng pag-uusap
- Mga gabay na pattern ng interaksyon
- Mga espesyal na istruktura ng diyalogo

### Tools
Ang Tools ay mga function na pinapatakbo ng AI model:
- Mga utility para sa pagproseso ng datos
- Integrasyon sa mga external na API
- Mga kakayahan sa komputasyon
- Pagsasagawa ng paghahanap

## Mga Sample na Pagpapatupad: C#

Ang opisyal na C# SDK repository ay naglalaman ng ilang sample na pagpapatupad na nagpapakita ng iba't ibang aspeto ng MCP:

- **Basic MCP Client**: Simpleng halimbawa kung paano gumawa ng MCP client at tumawag ng mga tool
- **Basic MCP Server**: Minimal na pagpapatupad ng server na may basic na pagrehistro ng tool
- **Advanced MCP Server**: Kumpletong server na may pagrehistro ng tool, authentication, at error handling
- **ASP.NET Integration**: Mga halimbawa ng integrasyon sa ASP.NET Core
- **Tool Implementation Patterns**: Iba't ibang pattern para sa pagpapatupad ng mga tool na may iba't ibang antas ng komplikasyon

Ang MCP C# SDK ay nasa preview pa at maaaring magbago ang mga API. Patuloy naming ia-update ang blog na ito habang umuunlad ang SDK.

### Pangunahing Tampok 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Paggawa ng iyong [unang MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Para sa kumpletong mga sample ng pagpapatupad sa C#, bisitahin ang [opisyal na C# SDK samples repository](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample na pagpapatupad: Java Implementation

Nagbibigay ang Java SDK ng matibay na mga opsyon para sa pagpapatupad ng MCP na may mga enterprise-grade na tampok.

### Pangunahing Tampok

- Integrasyon sa Spring Framework
- Malakas na type safety
- Suporta sa reactive programming
- Komprehensibong error handling

Para sa kumpletong sample ng Java implementation, tingnan ang [Java sample](samples/java/containerapp/README.md) sa samples directory.

## Sample na pagpapatupad: JavaScript Implementation

Nagbibigay ang JavaScript SDK ng magaan at flexible na paraan ng pagpapatupad ng MCP.

### Pangunahing Tampok

- Suporta sa Node.js at browser
- Promise-based na API
- Madaling integrasyon sa Express at iba pang framework
- Suporta sa WebSocket para sa streaming

Para sa kumpletong sample ng JavaScript implementation, tingnan ang [JavaScript sample](samples/javascript/README.md) sa samples directory.

## Sample na pagpapatupad: Python Implementation

Nagbibigay ang Python SDK ng Pythonic na paraan ng pagpapatupad ng MCP na may mahusay na integrasyon sa mga ML framework.

### Pangunahing Tampok

- Suporta sa async/await gamit ang asyncio
- Integrasyon sa Flask at FastAPI
- Simpleng pagrehistro ng tool
- Native na integrasyon sa mga kilalang ML library

Para sa kumpletong sample ng Python implementation, tingnan ang [Python sample](samples/python/README.md) sa samples directory.

## Pamamahala ng API

Ang Azure API Management ay isang mahusay na solusyon para sa kung paano natin mapoprotektahan ang mga MCP Server. Ang ideya ay ilagay ang isang Azure API Management instance sa harap ng iyong MCP Server at hayaang ito ang humawak ng mga tampok na malamang gusto mong gamitin tulad ng:

- rate limiting
- pamamahala ng token
- monitoring
- load balancing
- seguridad

### Azure Sample

Narito ang isang Azure Sample na gumagawa ng eksaktong iyon, ibig sabihin [gumagawa ng MCP Server at pinoprotektahan ito gamit ang Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Tingnan kung paano nangyayari ang authorization flow sa larawan sa ibaba:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Sa larawan sa itaas, ang mga sumusunod ang nangyayari:

- Nagaganap ang Authentication/Authorization gamit ang Microsoft Entra.
- Gumaganap ang Azure API Management bilang gateway at gumagamit ng mga polisiya para idirekta at pamahalaan ang trapiko.
- Nilo-log ng Azure Monitor ang lahat ng request para sa karagdagang pagsusuri.

#### Authorization flow

Tingnan natin nang mas detalyado ang authorization flow:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

Alamin pa ang tungkol sa [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## I-deploy ang Remote MCP Server sa Azure

Tingnan natin kung paano natin maide-deploy ang sample na nabanggit natin kanina:

1. I-clone ang repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Irehistro ang `Microsoft.App` resource provider.
    * Kung gumagamit ka ng Azure CLI, patakbuhin ang `az provider register --namespace Microsoft.App --wait`.
    * Kung gumagamit ka ng Azure PowerShell, patakbuhin ang `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Pagkatapos ay patakbuhin ang `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` pagkatapos ng ilang sandali upang tingnan kung kumpleto na ang pagrehistro.

2. Patakbuhin ang [azd](https://aka.ms/azd) command na ito upang i-provision ang api management service, function app (kasama ang code) at lahat ng iba pang kinakailangang Azure resources

    ```shell
    azd up
    ```

    Dapat i-deploy ng command na ito ang lahat ng cloud resources sa Azure

### Pagsubok ng iyong server gamit ang MCP Inspector

1. Sa isang **bagong terminal window**, i-install at patakbuhin ang MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Makikita mo ang isang interface na katulad nito:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.tl.png) 

1. CTRL click upang i-load ang MCP Inspector web app mula sa URL na ipinapakita ng app (hal. http://127.0.0.1:6274/#resources)
1. Itakda ang transport type sa `SSE`
1. Itakda ang URL sa iyong tumatakbong API Management SSE endpoint na ipinakita pagkatapos ng `azd up` at **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listahan ng Tools**. I-click ang isang tool at **Run Tool**.  

Kung gumana ang lahat ng hakbang, dapat ay nakakonekta ka na ngayon sa MCP server at nagawa mong tawagan ang isang tool.

## MCP servers para sa Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ang set ng mga repository na ito ay mga quickstart template para sa paggawa at pag-deploy ng custom remote MCP (Model Context Protocol) servers gamit ang Azure Functions sa Python, C# .NET o Node/TypeScript.

Nagbibigay ang mga Sample ng kumpletong solusyon na nagpapahintulot sa mga developer na:

- Bumuo at magpatakbo nang lokal: Mag-develop at mag-debug ng MCP server sa lokal na makina
- Mag-deploy sa Azure: Madaling i-deploy sa cloud gamit ang simpleng azd up command
- Kumonekta mula sa mga client: Kumonekta sa MCP server mula sa iba't ibang client kabilang ang VS Code's Copilot agent mode at ang MCP Inspector tool

### Pangunahing Tampok:

- Seguridad sa disenyo: Ang MCP server ay pinoprotektahan gamit ang mga key at HTTPS
- Mga opsyon sa authentication: Sinusuportahan ang OAuth gamit ang built-in na auth at/o API Management
- Network isolation: Pinapayagan ang network isolation gamit ang Azure Virtual Networks (VNET)
- Serverless architecture: Ginagamit ang Azure Functions para sa scalable, event-driven na pagpapatupad
- Lokal na pag-develop: Komprehensibong suporta para sa lokal na pag-develop at debugging
- Simpleng deployment: Pinadaling proseso ng deployment sa Azure

Kasama sa repository ang lahat ng kinakailangang configuration files, source code, at infrastructure definitions upang mabilis kang makapagsimula sa isang production-ready na MCP server implementation.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Sample na pagpapatupad ng MCP gamit ang Azure Functions sa Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Sample na pagpapatupad ng MCP gamit ang Azure Functions sa C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Sample na pagpapatupad ng MCP gamit ang Azure Functions sa Node/TypeScript.

## Mahahalagang Punto

- Nagbibigay ang MCP SDKs ng mga tool na nakatuon sa partikular na wika para sa matibay na pagpapatupad ng MCP solutions
- Kritikal ang proseso ng pag-debug at pagsubok para sa maaasahang mga aplikasyon ng MCP
- Pinapadali ng mga reusable prompt template ang consistent na interaksyon sa AI
- Ang maayos na disenyo ng mga workflow ay maaaring mag-orchestrate ng mga komplikadong gawain gamit ang maraming tool
- Ang pagpapatupad ng MCP solutions ay nangangailangan ng pagsasaalang-alang sa seguridad, performance, at error handling

## Ehersisyo

Magdisenyo ng praktikal na MCP workflow na tumutugon sa isang totoong problema sa iyong larangan:

1. Tukuyin ang 3-4 na tool na magiging kapaki-pakinabang sa paglutas ng problemang ito
2. Gumawa ng workflow diagram na nagpapakita kung paano nag-iinteract ang mga tool na ito
3. Ipatupad ang isang basic na bersyon ng isa sa mga tool gamit ang iyong paboritong wika
4. Gumawa ng prompt template na makakatulong sa model na epektibong magamit ang iyong tool

## Karagdagang Mapagkukunan


---

Susunod: [Advanced Topics](../05-AdvancedTopics/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.