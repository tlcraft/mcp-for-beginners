<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "671162f2687253f22af11187919ed02d",
  "translation_date": "2025-06-21T14:01:52+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tl"
}
-->
# MCP sa Aksyon: Mga Tunay na Kaso ng Pag-aaral

Ang Model Context Protocol (MCP) ay binabago ang paraan ng pakikipag-ugnayan ng mga AI application sa data, mga tool, at mga serbisyo. Ipinapakita sa seksyong ito ang mga tunay na kaso ng pag-aaral na nagpapakita ng praktikal na aplikasyon ng MCP sa iba't ibang sitwasyon ng negosyo.

## Pangkalahatang-ideya

Ipinapakita ng seksyong ito ang mga kongkretong halimbawa ng implementasyon ng MCP, na naglalantad kung paano ginagamit ng mga organisasyon ang protocol na ito upang lutasin ang mga komplikadong hamon sa negosyo. Sa pag-aaral ng mga kasong ito, makakakuha ka ng mga pananaw tungkol sa kakayahang umangkop, scalability, at mga praktikal na benepisyo ng MCP sa mga totoong sitwasyon.

## Pangunahing Layunin ng Pagkatuto

Sa pag-explore sa mga kasong ito, matututuhan mo ang mga sumusunod:

- Paano maaaring gamitin ang MCP upang lutasin ang mga tiyak na problema sa negosyo
- Mga iba't ibang pattern ng integrasyon at arkitekturang pamamaraan
- Kilalanin ang mga pinakamahusay na gawain sa pagpapatupad ng MCP sa mga kapaligirang pang-empresa
- Makakuha ng pananaw sa mga hamon at solusyong naranasan sa mga totoong implementasyon
- Tuklasin ang mga pagkakataon upang gamitin ang mga katulad na pattern sa iyong sariling mga proyekto

## Mga Tampok na Kaso ng Pag-aaral

### 1. [Azure AI Travel Agents – Reference Implementation](./travelagentsample.md)

Tinutukoy ng kasong ito ang komprehensibong reference solution ng Microsoft na nagpapakita kung paano bumuo ng multi-agent, AI-powered na travel planning application gamit ang MCP, Azure OpenAI, at Azure AI Search. Ipinapakita ng proyekto ang:

- Multi-agent orchestration gamit ang MCP
- Integrasyon ng enterprise data sa Azure AI Search
- Secure at scalable na arkitektura gamit ang Azure services
- Extensible na mga tool gamit ang reusable na MCP components
- Conversational na karanasan ng user na pinapagana ng Azure OpenAI

Nagbibigay ang arkitektura at mga detalye ng implementasyon ng mahahalagang pananaw sa pagbuo ng mga kumplikadong multi-agent system gamit ang MCP bilang coordination layer.

### 2. [Updating Azure DevOps Items from YouTube Data](./UpdateADOItemsFromYT.md)

Ipinapakita ng kasong ito ang praktikal na aplikasyon ng MCP para sa pag-automate ng mga workflow process. Ipinapakita nito kung paano magagamit ang mga MCP tool upang:

- Kunin ang data mula sa mga online platform (YouTube)
- I-update ang mga work item sa Azure DevOps systems
- Gumawa ng mga paulit-ulit na automation workflow
- Pagsamahin ang data mula sa magkakaibang sistema

Ipinapakita ng halimbawa na ito kung paano kahit ang mga simpleng implementasyon ng MCP ay makakapagbigay ng malaking pagtaas sa kahusayan sa pamamagitan ng pag-automate ng mga pangkaraniwang gawain at pagpapabuti ng consistency ng data sa iba't ibang sistema.

### 3. [Real-Time Documentation Retrieval with MCP](./docs-mcp/README.md)

Pinangungunahan ka ng kasong ito sa pagkonekta ng Python console client sa Model Context Protocol (MCP) server upang makuha at i-log ang real-time, context-aware na Microsoft documentation. Matututuhan mo kung paano:

- Kumonekta sa MCP server gamit ang Python client at ang opisyal na MCP SDK
- Gumamit ng streaming HTTP clients para sa episyenteng real-time na pagkuha ng data
- Tawagan ang mga documentation tool sa server at i-log ang mga tugon nang direkta sa console
- Isama ang up-to-date na Microsoft documentation sa iyong workflow nang hindi umaalis sa terminal

Kasama sa kabanata ang hands-on na gawain, minimal na sample code na gumagana, at mga link sa karagdagang mga mapagkukunan para sa mas malalim na pag-aaral. Tingnan ang buong walkthrough at code sa naka-link na kabanata upang maunawaan kung paano mababago ng MCP ang pag-access sa dokumentasyon at produktibidad ng developer sa mga console-based na kapaligiran.

### 4. [Interactive Study Plan Generator Web App with MCP](./docs-mcp/README.md)

Ipinapakita ng kasong ito kung paano bumuo ng interactive na web application gamit ang Chainlit at Model Context Protocol (MCP) upang makabuo ng personalized na mga plano sa pag-aaral para sa anumang paksa. Maaaring tukuyin ng mga user ang isang subject (tulad ng "AI-900 certification") at tagal ng pag-aaral (hal., 8 linggo), at magbibigay ang app ng linggo-linggong breakdown ng mga inirerekomendang nilalaman. Pinapagana ng Chainlit ang conversational chat interface, na ginagawang engaging at adaptive ang karanasan.

- Conversational web app na pinapagana ng Chainlit
- Mga prompt na pinamumunuan ng user para sa paksa at tagal
- Linggo-linggong rekomendasyon ng nilalaman gamit ang MCP
- Real-time, adaptive na tugon sa chat interface

Ipinapakita ng proyekto kung paano maaaring pagsamahin ang conversational AI at MCP upang makalikha ng mga dynamic, user-driven na educational tools sa makabagong web environment.

### 5. [In-Editor Docs with MCP Server in VS Code](./docs-mcp/README.md)

Ipinapakita ng kasong ito kung paano mo maipapasok ang Microsoft Learn Docs nang direkta sa iyong VS Code environment gamit ang MCP server—hindi na kailangang magpalipat-lipat pa sa browser! Makikita mo kung paano:

- Mabilis na maghanap at magbasa ng docs sa loob ng VS Code gamit ang MCP panel o command palette
- Mag-refer ng dokumentasyon at maglagay ng mga link nang direkta sa iyong README o course markdown files
- Gamitin ang GitHub Copilot at MCP nang sabay para sa seamless, AI-powered na dokumentasyon at workflow ng code
- I-validate at pagandahin ang iyong dokumentasyon gamit ang real-time na feedback at katumpakan mula sa Microsoft
- Isama ang MCP sa GitHub workflows para sa tuloy-tuloy na validation ng dokumentasyon

Kasama sa implementasyon ang:
- Halimbawa ng `.vscode/mcp.json` configuration para sa madaling setup
- Mga walkthrough na may screenshot ng in-editor experience
- Mga tip para sa pagsasama ng Copilot at MCP para sa pinakamataas na produktibidad

Ang senaryong ito ay perpekto para sa mga course author, manunulat ng dokumentasyon, at developer na nais manatiling nakatutok sa kanilang editor habang nagtatrabaho sa docs, Copilot, at mga validation tool—lahat ay pinapagana ng MCP.

## Konklusyon

Ipinapakita ng mga kasong ito ang kakayahang umangkop at praktikal na aplikasyon ng Model Context Protocol sa mga totoong sitwasyon. Mula sa mga komplikadong multi-agent system hanggang sa mga targeted na automation workflow, nagbibigay ang MCP ng isang standardized na paraan upang ikonekta ang mga AI system sa mga tool at data na kailangan nila upang makapaghatid ng halaga.

Sa pag-aaral ng mga implementasyong ito, makakakuha ka ng mga pananaw sa mga pattern ng arkitektura, mga estratehiya sa pagpapatupad, at mga pinakamahusay na gawain na maaaring gamitin sa iyong sariling mga proyekto sa MCP. Ipinapakita ng mga halimbawa na ang MCP ay hindi lamang isang teoretikal na balangkas kundi isang praktikal na solusyon sa mga tunay na hamon sa negosyo.

## Karagdagang Mga Mapagkukunan

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)
- [MCP Community Examples](https://github.com/microsoft/mcp)

**Pahayag ng Pagwawaksi**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat aming pinagsisikapang maging tumpak ang salin, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mga mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.