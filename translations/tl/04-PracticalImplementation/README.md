<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:58:31+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "tl"
}
-->
# Praktikal na Pagpapatupad

Ang praktikal na pagpapatupad ay kung saan nagiging makabuluhan ang kapangyarihan ng Model Context Protocol (MCP). Bagamat mahalaga ang pag-unawa sa teorya at arkitektura sa likod ng MCP, ang tunay na halaga ay lumilitaw kapag inilalapat mo ang mga konseptong ito upang bumuo, subukan, at i-deploy ang mga solusyong nagtatanggal ng mga totoong problema sa mundo. Ang kabanatang ito ay nag-uugnay sa pagitan ng konseptwal na kaalaman at aktwal na pag-unlad, na ginagabayan ka sa proseso ng pagbuo ng mga aplikasyon na batay sa MCP.

Kung ikaw ay nagde-develop ng mga intelligent assistants, nagsasama ng AI sa mga workflows ng negosyo, o bumubuo ng mga custom na tools para sa pagproseso ng datos, ang MCP ay nagbibigay ng isang flexible na pundasyon. Ang disenyo nito na hindi nakatali sa anumang wika at mga opisyal na SDKs para sa mga sikat na programming languages ay ginagawa itong accessible sa maraming uri ng developers. Sa pamamagitan ng paggamit ng mga SDKs na ito, maaari mong mabilis na mag-prototype, mag-iterate, at mag-scale ng iyong mga solusyon sa iba't ibang platform at kapaligiran.

Sa mga sumusunod na seksyon, makikita mo ang mga praktikal na halimbawa, sample code, at mga estratehiya sa deployment na nagpapakita kung paano ipatupad ang MCP sa C#, Java, TypeScript, JavaScript, at Python. Matutunan mo rin kung paano mag-debug at mag-test ng iyong MCP servers, pamahalaan ang APIs, at i-deploy ang mga solusyon sa cloud gamit ang Azure. Ang mga hands-on na resources na ito ay dinisenyo upang pabilisin ang iyong pag-aaral at tulungan kang magtiwala sa pagbuo ng matibay, production-ready na mga MCP applications.

## Pangkalahatang-ideya

Ang araling ito ay nakatuon sa mga praktikal na aspeto ng pagpapatupad ng MCP sa iba't ibang programming languages. Susuriin natin kung paano gamitin ang MCP SDKs sa C#, Java, TypeScript, JavaScript, at Python upang bumuo ng matibay na mga aplikasyon, mag-debug at mag-test ng MCP servers, at lumikha ng mga reusable resources, prompts, at tools.

## Mga Layunin sa Pag-aaral

Sa pagtatapos ng araling ito, ikaw ay makakaya:
- Ipatupad ang mga solusyong MCP gamit ang mga opisyal na SDKs sa iba't ibang programming languages
- Mag-debug at mag-test ng MCP servers nang sistematiko
- Lumikha at gumamit ng mga tampok ng server (Mga Resources, Prompts, at Tools)
- Magdisenyo ng mga epektibong workflows ng MCP para sa mga kumplikadong gawain
- I-optimize ang mga pagpapatupad ng MCP para sa performance at pagiging maaasahan

## Mga Opisyal na SDK Resources

Ang Model Context Protocol ay nag-aalok ng mga opisyal na SDKs para sa maraming wika:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Paggawa gamit ang MCP SDKs

Ang seksyong ito ay nagbibigay ng mga praktikal na halimbawa ng pagpapatupad ng MCP sa iba't ibang programming languages. Maaari mong makita ang sample code sa `samples` directory na nakaayos ayon sa wika.

### Available na Mga Halimbawa

Ang repository ay naglalaman ng mga sample na pagpapatupad sa mga sumusunod na wika:

- C#
- Java
- TypeScript
- JavaScript
- Python

Bawat sample ay nagpapakita ng mga pangunahing konsepto ng MCP at mga pattern ng pagpapatupad para sa partikular na wika at ekosistema.

## Mga Pangunahing Tampok ng Server

Ang MCP servers ay maaaring magpatupad ng anumang kombinasyon ng mga tampok na ito:

### Resources
Ang mga Resources ay nagbibigay ng konteksto at datos para sa user o AI model na gamitin:
- Mga repository ng dokumento
- Mga knowledge base
- Mga structured data sources
- Mga file systems

### Prompts
Ang mga Prompts ay mga templated na mensahe at workflows para sa mga gumagamit:
- Mga pre-defined na template ng pag-uusap
- Mga guided na pattern ng interaksyon
- Mga specialized na istruktura ng diyalogo

### Tools
Ang mga Tools ay mga function para sa AI model na isagawa:
- Mga utility para sa pagproseso ng datos
- Mga integration ng external APIs
- Mga kakayahan sa computation
- Mga functionality ng search

## Sample na Mga Pagpapatupad: C#

Ang opisyal na C# SDK repository ay naglalaman ng ilang sample na pagpapatupad na nagpapakita ng iba't ibang aspeto ng MCP:

- **Basic MCP Client**: Simpleng halimbawa kung paano lumikha ng MCP client at tawagan ang mga tools
- **Basic MCP Server**: Minimal na pagpapatupad ng server na may pangunahing tool registration
- **Advanced MCP Server**: Kumpletong server na may tool registration, authentication, at error handling
- **ASP.NET Integration**: Mga halimbawa na nagpapakita ng integration sa ASP.NET Core
- **Tool Implementation Patterns**: Iba't ibang pattern para sa pagpapatupad ng tools na may iba't ibang antas ng kumplikado

Ang MCP C# SDK ay nasa preview at maaaring magbago ang APIs. Patuloy naming ia-update ang blog na ito habang nag-e-evolve ang SDK.

### Mga Pangunahing Tampok
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Pagbuo ng iyong [unang MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Para sa kumpletong mga sample ng pagpapatupad sa C#, bisitahin ang [opisyal na C# SDK samples repository](https://github.com/modelcontextprotocol/csharp-sdk)

## Sample na Pagpapatupad: Java Implementation

Ang Java SDK ay nag-aalok ng matibay na mga pagpipilian sa pagpapatupad ng MCP na may mga tampok na pang-enterprise.

### Mga Pangunahing Tampok

- Integrasyon ng Spring Framework
- Matibay na type safety
- Suporta sa reactive programming
- Komprehensibong error handling

Para sa kumpletong sample ng pagpapatupad sa Java, tingnan ang [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) sa samples directory.

## Sample na Pagpapatupad: JavaScript Implementation

Ang JavaScript SDK ay nagbibigay ng magaan at flexible na paraan sa pagpapatupad ng MCP.

### Mga Pangunahing Tampok

- Suporta sa Node.js at browser
- Promise-based na API
- Madaling integrasyon sa Express at iba pang frameworks
- Suporta sa WebSocket para sa streaming

Para sa kumpletong sample ng pagpapatupad sa JavaScript, tingnan ang [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) sa samples directory.

## Sample na Pagpapatupad: Python Implementation

Ang Python SDK ay nag-aalok ng Pythonic na paraan sa pagpapatupad ng MCP na may mahusay na integrasyon sa mga ML framework.

### Mga Pangunahing Tampok

- Suporta sa Async/await gamit ang asyncio
- Integrasyon ng Flask at FastAPI
- Simpleng tool registration
- Native na integrasyon sa mga sikat na ML libraries

Para sa kumpletong sample ng pagpapatupad sa Python, tingnan ang [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) sa samples directory.

## Pamamahala ng API

Ang Azure API Management ay isang mahusay na sagot sa kung paano natin mapapangalagaan ang MCP Servers. Ang ideya ay ilagay ang isang Azure API Management instance sa harap ng iyong MCP Server at hayaan itong pamahalaan ang mga tampok na malamang na gusto mo tulad ng:

- rate limiting
- pamamahala ng token
- monitoring
- load balancing
- seguridad

### Azure Sample

Narito ang isang Azure Sample na gumagawa ng eksaktong iyon, ibig sabihin [paglikha ng isang MCP Server at pag-secure nito gamit ang Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Tingnan kung paano nangyayari ang authorization flow sa imahe sa ibaba:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Sa naunang imahe, ang mga sumusunod ay nagaganap:

- Ang Authentication/Authorization ay nangyayari gamit ang Microsoft Entra.
- Ang Azure API Management ay kumikilos bilang isang gateway at gumagamit ng mga polisiya upang idirekta at pamahalaan ang trapiko.
- Ang Azure Monitor ay naglo-log ng lahat ng kahilingan para sa karagdagang pagsusuri.

#### Authorization flow

Tingnan natin nang mas detalyado ang authorization flow:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP authorization specification

Alamin ang higit pa tungkol sa [MCP Authorization specification](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## I-deploy ang Remote MCP Server sa Azure

Tingnan natin kung maaari nating i-deploy ang sample na nabanggit natin kanina:

1. I-clone ang repo

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Irehistro ang `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` pagkatapos ng ilang oras upang suriin kung kumpleto na ang registration.

2. Patakbuhin ang [azd](https://aka.ms/azd) command na ito upang i-provision ang api management service, function app (na may code) at lahat ng iba pang kinakailangang Azure resources

    ```shell
    azd up
    ```

    Dapat i-deploy ng mga command na ito ang lahat ng cloud resources sa Azure

### Pagsubok ng iyong server gamit ang MCP Inspector

1. Sa isang **bagong terminal window**, i-install at patakbuhin ang MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Dapat mong makita ang isang interface na katulad ng:

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.tl.png)

1. I-CTRL click upang i-load ang MCP Inspector web app mula sa URL na ipinapakita ng app (hal. http://127.0.0.1:6274/#resources)
1. Itakda ang transport type sa `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` at **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **List Tools**. I-click ang isang tool at **Run Tool**.

Kung lahat ng hakbang ay gumana, dapat ngayon ay nakakonekta ka sa MCP server at nagawa mong tawagan ang isang tool.

## MCP servers para sa Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ang set ng mga repositories na ito ay quickstart template para sa pagbuo at pag-deploy ng custom remote MCP (Model Context Protocol) servers gamit ang Azure Functions sa Python, C# .NET o Node/TypeScript.

Ang Samples ay nagbibigay ng kumpletong solusyon na nagbibigay-daan sa mga developer na:

- Bumuo at patakbuhin nang lokal: Bumuo at mag-debug ng isang MCP server sa lokal na makina
- I-deploy sa Azure: Madaling i-deploy sa cloud gamit ang isang simpleng azd up command
- Kumonekta mula sa mga kliyente: Kumonekta sa MCP server mula sa iba't ibang kliyente kabilang ang VS Code's Copilot agent mode at ang MCP Inspector tool

### Mga Pangunahing Tampok:

- Seguridad sa disenyo: Ang MCP server ay secured gamit ang mga keys at HTTPS
- Mga pagpipilian sa authentication: Sinusuportahan ang OAuth gamit ang built-in auth at/o API Management
- Network isolation: Pinapayagan ang network isolation gamit ang Azure Virtual Networks (VNET)
- Serverless architecture: Ginagamit ang Azure Functions para sa scalable, event-driven execution
- Lokal na pag-unlad: Komprehensibong suporta sa lokal na pag-unlad at pag-debug
- Simpleng deployment: Streamlined na proseso ng deployment sa Azure

Ang repository ay naglalaman ng lahat ng kinakailangang configuration files, source code, at mga infrastructure definitions upang mabilis na makapagsimula sa isang production-ready na MCP server implementation.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Sample na pagpapatupad ng MCP gamit ang Azure Functions sa Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Sample na pagpapatupad ng MCP gamit ang Azure Functions sa C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Sample na pagpapatupad ng MCP gamit ang Azure Functions sa Node/TypeScript.

## Mahahalagang Takeaways

- Ang MCP SDKs ay nagbibigay ng mga language-specific na tools para sa pagpapatupad ng matibay na mga solusyong MCP
- Ang proseso ng debugging at testing ay kritikal para sa mga maaasahang aplikasyon ng MCP
- Ang mga reusable na prompt templates ay nagbibigay-daan sa consistent na AI interactions
- Ang mahusay na disenyo ng workflows ay maaaring mag-orchestrate ng mga kumplikadong gawain gamit ang maraming tools
- Ang pagpapatupad ng mga solusyong MCP ay nangangailangan ng konsiderasyon sa seguridad, performance, at error handling

## Ehersisyo

Magdisenyo ng praktikal na workflow ng MCP na tumutugon sa isang totoong problema sa iyong domain:

1. Tukuyin ang 3-4 na tools na magiging kapaki-pakinabang para sa paglutas ng problemang ito
2. Gumawa ng diagram ng workflow na nagpapakita kung paano nag-i-interact ang mga tools na ito
3. Ipatupad ang isang basic na bersyon ng isa sa mga tools gamit ang iyong paboritong wika
4. Gumawa ng prompt template na makakatulong sa model na epektibong gamitin ang iyong tool

## Karagdagang Resources

---

Susunod: [Mga Advanced na Paksa](../05-AdvancedTopics/README.md)

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat pinagsisikapan naming maging tumpak, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga error o hindi pagkaka-ayon. Ang orihinal na dokumento sa kanyang katutubong wika ay dapat ituring na mapagkakatiwalaang pinagmulan. Para sa kritikal na impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Kami ay hindi mananagot para sa anumang hindi pagkakaintindihan o maling interpretasyon na dulot ng paggamit ng pagsasaling ito.