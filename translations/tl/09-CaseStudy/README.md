<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "61a160248efabe92b09d7b08293d17db",
  "translation_date": "2025-08-18T18:09:19+00:00",
  "source_file": "09-CaseStudy/README.md",
  "language_code": "tl"
}
-->
# MCP sa Aksyon: Mga Kaso ng Paggamit sa Tunay na Mundo

[![MCP sa Aksyon: Mga Kaso ng Paggamit sa Tunay na Mundo](../../../translated_images/10.3262cc80b4de5071fde8ba74c5c5d6738a0a9f398dcc0423f0210f632e2238b8.tl.png)](https://youtu.be/IxshWb2Az5w)

_(I-click ang larawan sa itaas upang panoorin ang video ng araling ito)_

Ang Model Context Protocol (MCP) ay nagbabago kung paano nakikipag-ugnayan ang mga AI application sa data, tools, at serbisyo. Ang seksyong ito ay nagtatampok ng mga kaso ng paggamit sa tunay na mundo na nagpapakita ng praktikal na aplikasyon ng MCP sa iba't ibang senaryo ng negosyo.

## Pangkalahatang-ideya

Ang seksyong ito ay nagpapakita ng mga konkretong halimbawa ng mga implementasyon ng MCP, na binibigyang-diin kung paano ginagamit ng mga organisasyon ang protocol na ito upang lutasin ang mga kumplikadong hamon sa negosyo. Sa pamamagitan ng pagsusuri sa mga kasong ito, makakakuha ka ng mga pananaw sa kakayahang umangkop, scalability, at praktikal na benepisyo ng MCP sa tunay na mundo.

## Mga Pangunahing Layunin sa Pagkatuto

Sa pag-aaral ng mga kasong ito, ikaw ay:

- Mauunawaan kung paano maaaring gamitin ang MCP upang lutasin ang mga tiyak na problema sa negosyo  
- Matututo tungkol sa iba't ibang pattern ng integrasyon at mga diskarte sa arkitektura  
- Makikilala ang mga pinakamahusay na kasanayan para sa pagpapatupad ng MCP sa mga kapaligiran ng negosyo  
- Makakakuha ng mga pananaw sa mga hamon at solusyon na naranasan sa mga implementasyon sa tunay na mundo  
- Matutukoy ang mga pagkakataon upang magamit ang mga katulad na pattern sa iyong sariling mga proyekto  

## Mga Itinatampok na Kaso ng Paggamit

### 1. [Azure AI Travel Agents – Reference Implementation](./travelagentsample.md)

Ang kasong ito ay sinusuri ang komprehensibong reference solution ng Microsoft na nagpapakita kung paano bumuo ng isang multi-agent, AI-powered na travel planning application gamit ang MCP, Azure OpenAI, at Azure AI Search. Ang proyekto ay nagtatampok ng:

- Multi-agent orchestration gamit ang MCP  
- Integrasyon ng enterprise data sa Azure AI Search  
- Secure at scalable na arkitektura gamit ang mga serbisyo ng Azure  
- Extensible tooling gamit ang reusable MCP components  
- Conversational user experience na pinapagana ng Azure OpenAI  

Ang mga detalye ng arkitektura at implementasyon ay nagbibigay ng mahahalagang pananaw sa pagbuo ng mga kumplikadong multi-agent system na may MCP bilang coordination layer.

### 2. [Pag-update ng Azure DevOps Items mula sa YouTube Data](./UpdateADOItemsFromYT.md)

Ang kasong ito ay nagpapakita ng praktikal na aplikasyon ng MCP para sa pag-automate ng mga proseso ng workflow. Ipinapakita nito kung paano maaaring gamitin ang mga MCP tools upang:

- Mag-extract ng data mula sa mga online platform (YouTube)  
- Mag-update ng mga work item sa mga Azure DevOps system  
- Lumikha ng mga repeatable automation workflow  
- Mag-integrate ng data sa iba't ibang sistema  

Ang halimbawang ito ay nagpapakita kung paano kahit ang mga simpleng implementasyon ng MCP ay maaaring magbigay ng makabuluhang pagtaas sa kahusayan sa pamamagitan ng pag-automate ng mga routine na gawain at pagpapabuti ng consistency ng data sa mga sistema.

### 3. [Real-Time Documentation Retrieval gamit ang MCP](./docs-mcp/README.md)

Ang kasong ito ay gumagabay sa iyo sa pagkonekta ng isang Python console client sa isang Model Context Protocol (MCP) server upang makuha at i-log ang real-time, context-aware na Microsoft documentation. Matututuhan mo kung paano:

- Kumonekta sa isang MCP server gamit ang isang Python client at ang opisyal na MCP SDK  
- Gumamit ng streaming HTTP clients para sa mahusay na real-time na pagkuha ng data  
- Tumawag ng mga documentation tools sa server at i-log ang mga tugon nang direkta sa console  
- Mag-integrate ng up-to-date na Microsoft documentation sa iyong workflow nang hindi umaalis sa terminal  

Ang kabanata ay naglalaman ng isang hands-on na assignment, isang minimal working code sample, at mga link sa karagdagang resources para sa mas malalim na pag-aaral. Tingnan ang buong walkthrough at code sa naka-link na kabanata upang maunawaan kung paano maaaring baguhin ng MCP ang access sa dokumentasyon at produktibidad ng developer sa mga console-based na kapaligiran.

### 4. [Interactive Study Plan Generator Web App gamit ang MCP](./docs-mcp/README.md)

Ang kasong ito ay nagpapakita kung paano bumuo ng isang interactive na web application gamit ang Chainlit at ang Model Context Protocol (MCP) upang makabuo ng personalized na mga study plan para sa anumang paksa. Maaaring tukuyin ng mga user ang isang subject (tulad ng "AI-900 certification") at isang study duration (hal., 8 linggo), at ang app ay magbibigay ng week-by-week na breakdown ng inirerekomendang content. Ang Chainlit ay nagbibigay-daan sa isang conversational chat interface, na ginagawang mas engaging at adaptive ang karanasan.

- Conversational web app na pinapagana ng Chainlit  
- Mga user-driven na prompt para sa paksa at tagal  
- Week-by-week na mga rekomendasyon ng content gamit ang MCP  
- Real-time, adaptive na mga tugon sa isang chat interface  

Ang proyekto ay nagpapakita kung paano maaaring pagsamahin ang conversational AI at MCP upang lumikha ng dynamic, user-driven na mga educational tool sa isang modernong web environment.

### 5. [In-Editor Docs gamit ang MCP Server sa VS Code](./docs-mcp/README.md)

Ang kasong ito ay nagpapakita kung paano mo maaaring dalhin ang Microsoft Learn Docs nang direkta sa iyong VS Code environment gamit ang MCP server—hindi na kailangang magpalipat-lipat ng browser tabs! Makikita mo kung paano:

- Agad na maghanap at magbasa ng mga dokumento sa loob ng VS Code gamit ang MCP panel o command palette  
- Mag-refer ng dokumentasyon at maglagay ng mga link nang direkta sa iyong README o course markdown files  
- Gamitin ang GitHub Copilot at MCP nang magkasama para sa seamless, AI-powered na dokumentasyon at workflows sa code  
- I-validate at pagandahin ang iyong dokumentasyon gamit ang real-time na feedback at Microsoft-sourced na katumpakan  
- Mag-integrate ng MCP sa GitHub workflows para sa tuloy-tuloy na pag-validate ng dokumentasyon  

Ang implementasyon ay naglalaman ng:

- Halimbawang `.vscode/mcp.json` configuration para sa madaling setup  
- Mga walkthrough na may mga screenshot ng in-editor na karanasan  
- Mga tip para sa pagsasama ng Copilot at MCP para sa maximum na produktibidad  

Ang senaryong ito ay perpekto para sa mga course author, documentation writer, at developer na nais manatiling nakatuon sa kanilang editor habang nagtatrabaho sa mga dokumento, Copilot, at mga validation tool—lahat ay pinapagana ng MCP.

### 6. [Paglikha ng APIM MCP Server](./apimsample.md)

Ang kasong ito ay nagbibigay ng step-by-step na gabay kung paano lumikha ng isang MCP server gamit ang Azure API Management (APIM). Sinasaklaw nito ang:

- Pag-set up ng isang MCP server sa Azure API Management  
- Pag-expose ng mga API operation bilang MCP tools  
- Pag-configure ng mga polisiya para sa rate limiting at seguridad  
- Pagsubok sa MCP server gamit ang Visual Studio Code at GitHub Copilot  

Ang halimbawang ito ay nagpapakita kung paano magagamit ang mga kakayahan ng Azure upang lumikha ng isang matatag na MCP server na maaaring gamitin sa iba't ibang aplikasyon, na nagpapahusay sa integrasyon ng mga AI system sa mga enterprise API.

## Konklusyon

Ang mga kasong ito ay nagtatampok ng kakayahang umangkop at praktikal na aplikasyon ng Model Context Protocol sa tunay na mundo. Mula sa mga kumplikadong multi-agent system hanggang sa mga targeted automation workflow, ang MCP ay nagbibigay ng isang standardized na paraan upang ikonekta ang mga AI system sa mga tools at data na kailangan nila upang maghatid ng halaga.

Sa pag-aaral ng mga implementasyong ito, makakakuha ka ng mga pananaw sa mga pattern ng arkitektura, mga estratehiya sa implementasyon, at mga pinakamahusay na kasanayan na maaaring mailapat sa iyong sariling mga proyekto sa MCP. Ang mga halimbawa ay nagpapakita na ang MCP ay hindi lamang isang teoretikal na framework kundi isang praktikal na solusyon sa mga tunay na hamon sa negosyo.

## Karagdagang Resources

- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)  
- [Azure DevOps MCP Tool](https://github.com/microsoft/azure-devops-mcp)  
- [Playwright MCP Tool](https://github.com/microsoft/playwright-mcp)  
- [Microsoft Docs MCP Server](https://github.com/MicrosoftDocs/mcp)  
- [MCP Community Examples](https://github.com/microsoft/mcp)  

Next: Hands on Lab [Pag-streamline ng AI Workflows: Pagbuo ng isang MCP Server gamit ang AI Toolkit](../10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md)  

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama't sinisikap naming maging tumpak, tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na opisyal na sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.