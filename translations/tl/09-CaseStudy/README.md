<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "873741da08dd6537858d5e14c3a386e1",
  "translation_date": "2025-07-14T05:49:31+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tl"
}
-->
# MCP sa Aksyon: Mga Kaso ng Pag-aaral sa Tunay na Mundo

Ang Model Context Protocol (MCP) ay binabago ang paraan ng pakikipag-ugnayan ng mga AI application sa data, mga tool, at serbisyo. Ipinapakita sa seksyong ito ang mga totoong kaso ng pag-aaral na nagpapakita ng praktikal na aplikasyon ng MCP sa iba't ibang senaryo ng negosyo.

## Pangkalahatang-ideya

Ipinapakita sa seksyong ito ang mga kongkretong halimbawa ng mga implementasyon ng MCP, na naglalantad kung paano ginagamit ng mga organisasyon ang protocol na ito upang lutasin ang mga kumplikadong hamon sa negosyo. Sa pamamagitan ng pagsusuri sa mga kasong ito, makakakuha ka ng mga pananaw tungkol sa kakayahang umangkop, scalability, at mga praktikal na benepisyo ng MCP sa mga totoong sitwasyon.

## Pangunahing Layunin ng Pagkatuto

Sa pag-aaral ng mga kasong ito, matututuhan mo ang mga sumusunod:

- Paano magagamit ang MCP upang lutasin ang mga partikular na problema sa negosyo
- Mga iba't ibang pattern ng integrasyon at mga arkitekturang pamamaraan
- Mga pinakamahusay na kasanayan sa pagpapatupad ng MCP sa mga kapaligirang pang-entreprenyur
- Mga hamon at solusyong naranasan sa mga totoong implementasyon
- Mga oportunidad upang magamit ang katulad na mga pattern sa iyong sariling mga proyekto

## Mga Tampok na Kaso ng Pag-aaral

### 1. [Azure AI Travel Agents – Reference Implementation](./travelagentsample.md)

Tinutukoy ng kasong ito ang komprehensibong reference solution ng Microsoft na nagpapakita kung paano bumuo ng multi-agent, AI-powered na travel planning application gamit ang MCP, Azure OpenAI, at Azure AI Search. Ipinapakita ng proyekto ang:

- Multi-agent orchestration gamit ang MCP
- Integrasyon ng enterprise data gamit ang Azure AI Search
- Ligtas at scalable na arkitektura gamit ang mga Azure service
- Extensible na mga tool gamit ang reusable na mga MCP component
- Conversational na karanasan ng user na pinapagana ng Azure OpenAI

Nagbibigay ang arkitektura at mga detalye ng implementasyon ng mahahalagang pananaw sa pagbuo ng mga kumplikadong multi-agent system gamit ang MCP bilang coordination layer.

### 2. [Pag-update ng Azure DevOps Items mula sa YouTube Data](./UpdateADOItemsFromYT.md)

Ipinapakita ng kasong ito ang praktikal na aplikasyon ng MCP para sa pag-automate ng mga workflow process. Ipinapakita nito kung paano magagamit ang mga MCP tool upang:

- Kunin ang data mula sa mga online platform (YouTube)
- I-update ang mga work item sa Azure DevOps system
- Gumawa ng mga paulit-ulit na automation workflow
- Mag-integrate ng data mula sa magkakaibang sistema

Ipinapakita ng halimbawa na ito kung paano kahit ang mga simpleng implementasyon ng MCP ay maaaring magdulot ng malaking pagtaas sa kahusayan sa pamamagitan ng pag-automate ng mga rutinang gawain at pagpapabuti ng konsistensi ng data sa mga sistema.

### 3. [Real-Time na Pagkuha ng Dokumentasyon gamit ang MCP](./docs-mcp/README.md)

Ginagabayan ka ng kasong ito kung paano ikonekta ang isang Python console client sa isang Model Context Protocol (MCP) server upang kumuha at mag-log ng real-time, context-aware na dokumentasyon ng Microsoft. Matututuhan mo kung paano:

- Kumonekta sa MCP server gamit ang Python client at ang opisyal na MCP SDK
- Gumamit ng streaming HTTP client para sa episyenteng real-time na pagkuha ng data
- Tawagan ang mga documentation tool sa server at i-log ang mga tugon nang direkta sa console
- Isama ang napapanahong dokumentasyon ng Microsoft sa iyong workflow nang hindi umaalis sa terminal

Kasama sa kabanata ang hands-on na gawain, isang minimal na working code sample, at mga link sa karagdagang mga mapagkukunan para sa mas malalim na pag-aaral. Tingnan ang buong walkthrough at code sa naka-link na kabanata upang maunawaan kung paano mababago ng MCP ang pag-access sa dokumentasyon at produktibidad ng developer sa mga console-based na kapaligiran.

### 4. [Interactive Study Plan Generator Web App gamit ang MCP](./docs-mcp/README.md)

Ipinapakita ng kasong ito kung paano bumuo ng isang interactive na web application gamit ang Chainlit at ang Model Context Protocol (MCP) upang makagawa ng personalized na study plan para sa anumang paksa. Maaaring tukuyin ng mga user ang isang subject (tulad ng "AI-900 certification") at ang tagal ng pag-aaral (hal., 8 linggo), at magbibigay ang app ng linggo-linggong breakdown ng mga inirerekomendang nilalaman. Pinapagana ng Chainlit ang isang conversational chat interface, na ginagawang mas nakakaengganyo at adaptive ang karanasan.

- Conversational web app na pinapagana ng Chainlit
- Mga prompt na pinapatakbo ng user para sa paksa at tagal
- Linggo-linggong rekomendasyon ng nilalaman gamit ang MCP
- Real-time, adaptive na mga tugon sa chat interface

Ipinapakita ng proyekto kung paano maaaring pagsamahin ang conversational AI at MCP upang makalikha ng mga dynamic, user-driven na educational tool sa isang modernong web environment.

### 5. [In-Editor Docs gamit ang MCP Server sa VS Code](./docs-mcp/README.md)

Ipinapakita ng kasong ito kung paano mo maaaring dalhin ang Microsoft Learn Docs nang direkta sa iyong VS Code environment gamit ang MCP server—hindi na kailangang magpalipat-lipat ng browser tab! Makikita mo kung paano:

- Mabilis na maghanap at magbasa ng docs sa loob ng VS Code gamit ang MCP panel o command palette
- Mag-refer ng dokumentasyon at maglagay ng mga link nang direkta sa iyong README o course markdown files
- Gamitin ang GitHub Copilot at MCP nang sabay para sa seamless, AI-powered na dokumentasyon at workflow ng code
- I-validate at pagandahin ang iyong dokumentasyon gamit ang real-time na feedback at katumpakan mula sa Microsoft
- Isama ang MCP sa GitHub workflows para sa tuloy-tuloy na pag-validate ng dokumentasyon

Kasama sa implementasyon ang:
- Halimbawa ng `.vscode/mcp.json` configuration para sa madaling setup
- Mga screenshot-based na walkthrough ng in-editor na karanasan
- Mga tip para pagsamahin ang Copilot at MCP para sa pinakamataas na produktibidad

Ang senaryong ito ay perpekto para sa mga course author, documentation writer, at developer na nais manatiling nakatuon sa kanilang editor habang nagtatrabaho sa docs, Copilot, at mga validation tool—lahat ay pinapagana ng MCP.

### 6. [Paglikha ng APIM MCP Server](./apimsample.md)

Nagbibigay ang kasong ito ng step-by-step na gabay kung paano gumawa ng MCP server gamit ang Azure API Management (APIM). Saklaw nito ang:

- Pag-setup ng MCP server sa Azure API Management
- Pag-expose ng mga API operation bilang MCP tool
- Pag-configure ng mga polisiya para sa rate limiting at seguridad
- Pagsubok ng MCP server gamit ang Visual Studio Code at GitHub Copilot

Ipinapakita ng halimbawa kung paano magagamit ang mga kakayahan ng Azure upang makabuo ng matibay na MCP server na maaaring gamitin sa iba't ibang aplikasyon, na nagpapahusay sa integrasyon ng mga AI system sa mga enterprise API.

## Konklusyon

Ipinapakita ng mga kasong ito ang kakayahang umangkop at praktikal na aplikasyon ng Model Context Protocol sa mga totoong sitwasyon. Mula sa mga kumplikadong multi-agent system hanggang sa mga targeted automation workflow, nagbibigay ang MCP ng isang standardized na paraan upang ikonekta ang mga AI system sa mga tool at data na kailangan nila upang maghatid ng halaga.

Sa pag-aaral ng mga implementasyong ito, makakakuha ka ng mga pananaw sa mga pattern ng arkitektura, mga estratehiya sa pagpapatupad, at mga pinakamahusay na kasanayan na maaaring magamit sa iyong sariling mga proyekto ng MCP. Ipinapakita ng mga halimbawa na ang MCP ay hindi lamang isang teoretikal na balangkas kundi isang praktikal na solusyon sa mga tunay na hamon sa negosyo.

## Karagdagang Mga Mapagkukunan

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

Susunod: Hands on Lab [Streamlining AI Workflows: Building an MCP Server with AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.