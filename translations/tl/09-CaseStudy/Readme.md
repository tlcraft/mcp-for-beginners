<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b6b1bc868efed4cf02c52f8deada559d",
  "translation_date": "2025-05-17T17:32:52+00:00",
  "source_file": "09-CaseStudy/Readme.md",
  "language_code": "tl"
}
-->
# Pag-aaral ng Kaso: Azure AI Travel Agents – Reference Implementation

## Pangkalahatang-ideya

Ang [Azure AI Travel Agents](https://github.com/Azure-Samples/azure-ai-travel-agents) ay isang komprehensibong reference solution na binuo ng Microsoft na nagpapakita kung paano bumuo ng multi-agent, AI-powered travel planning application gamit ang Model Context Protocol (MCP), Azure OpenAI, at Azure AI Search. Ang proyektong ito ay nagpapakita ng mga pinakamahusay na kasanayan para sa pag-orchestrate ng maraming AI agents, pag-integrate ng enterprise data, at pagbibigay ng secure, extensible platform para sa mga totoong senaryo.

## Mga Pangunahing Tampok
- **Multi-Agent Orchestration:** Gumagamit ng MCP para i-coordinate ang mga espesyal na agents (hal., flight, hotel, at itinerary agents) na nagtutulungan para matupad ang mga kumplikadong gawain sa pagpaplano ng paglalakbay.
- **Enterprise Data Integration:** Kumokonekta sa Azure AI Search at iba pang enterprise data sources para magbigay ng napapanahon, may kaugnayang impormasyon para sa mga rekomendasyon sa paglalakbay.
- **Secure, Scalable Architecture:** Umaasa sa mga serbisyo ng Azure para sa authentication, authorization, at scalable deployment, na sumusunod sa mga pinakamahusay na kasanayan sa seguridad ng enterprise.
- **Extensible Tooling:** Nagpapatupad ng reusable MCP tools at prompt templates, na nagbibigay-daan sa mabilis na pag-angkop sa mga bagong domain o pangangailangan ng negosyo.
- **User Experience:** Nagbibigay ng conversational interface para sa mga user na makipag-ugnayan sa travel agents, na pinapagana ng Azure OpenAI at MCP.

## Arkitektura
![Architecture](https://github.com/Azure-Samples/azure-ai-travel-agents/blob/main/docs/ai-travel-agents-architecture-diagram.png)

### Paglalarawan ng Diagram ng Arkitektura

Ang solusyon ng Azure AI Travel Agents ay idinisenyo para sa modularity, scalability, at secure integration ng maraming AI agents at enterprise data sources. Ang mga pangunahing bahagi at daloy ng data ay ang mga sumusunod:

- **User Interface:** Nakikipag-ugnayan ang mga user sa sistema sa pamamagitan ng conversational UI (tulad ng web chat o Teams bot), na nagpapadala ng mga tanong ng user at tumatanggap ng mga rekomendasyon sa paglalakbay.
- **MCP Server:** Nagsisilbing central orchestrator, tumatanggap ng input ng user, namamahala sa context, at nagko-coordinate sa mga aksyon ng mga espesyal na agents (hal., FlightAgent, HotelAgent, ItineraryAgent) sa pamamagitan ng Model Context Protocol.
- **AI Agents:** Ang bawat agent ay responsable para sa isang partikular na domain (flights, hotels, itineraries) at ipinatupad bilang isang MCP tool. Gumagamit ang mga agents ng prompt templates at logic para iproseso ang mga kahilingan at bumuo ng mga tugon.
- **Azure OpenAI Service:** Nagbibigay ng advanced natural language understanding at generation, na nagbibigay-daan sa mga agents na maunawaan ang intensyon ng user at bumuo ng conversational na mga tugon.
- **Azure AI Search & Enterprise Data:** Nagtatanong ang mga agents sa Azure AI Search at iba pang enterprise data sources para makuha ang napapanahong impormasyon tungkol sa flights, hotels, at travel options.
- **Authentication & Security:** Nag-iintegrate sa Microsoft Entra ID para sa secure authentication at nag-aaplay ng least-privilege access controls sa lahat ng resources.
- **Deployment:** Idinisenyo para sa deployment sa Azure Container Apps, na nagtitiyak ng scalability, monitoring, at operational efficiency.

Ang arkitekturang ito ay nagbibigay-daan sa seamless orchestration ng maraming AI agents, secure integration sa enterprise data, at isang matatag, extensible platform para sa pagbuo ng domain-specific na AI solutions.

## Hakbang-hakbang na Paliwanag ng Diagram ng Arkitektura
Isipin ang pagpaplano ng isang malaking paglalakbay at pagkakaroon ng isang pangkat ng mga ekspertong katulong na tumutulong sa iyo sa bawat detalye. Ang sistema ng Azure AI Travel Agents ay gumagana sa katulad na paraan, gamit ang iba't ibang bahagi (tulad ng mga miyembro ng pangkat) na bawat isa ay may espesyal na gawain. Narito kung paano ito magkakasama:

### User Interface (UI):
Isipin ito bilang harapan ng iyong travel agent. Dito ka (ang user) nagtatanong o gumagawa ng mga kahilingan, tulad ng “Humanap ng flight papuntang Paris.” Ito ay maaaring isang chat window sa isang website o isang messaging app.

### MCP Server (Ang Coordinator):
Ang MCP Server ay tulad ng manager na nakikinig sa iyong kahilingan sa harapan at nagdedesisyon kung aling espesyalista ang dapat humawak sa bawat bahagi. Sinusubaybayan nito ang iyong usapan at sinisiguro na lahat ay maayos na tumatakbo.

### AI Agents (Mga Ekspertong Katulong):
Ang bawat agent ay eksperto sa isang partikular na larangan—ang isa ay alam ang lahat tungkol sa flights, ang isa pa tungkol sa hotels, at ang isa pa tungkol sa pagplano ng iyong itinerary. Kapag humiling ka ng isang biyahe, ipinapadala ng MCP Server ang iyong kahilingan sa tamang agent(s). Ang mga agents na ito ay gumagamit ng kanilang kaalaman at mga kasangkapan para hanapin ang pinakamagandang opsyon para sa iyo.

### Azure OpenAI Service (Eksperto sa Wika):
Ito ay tulad ng pagkakaroon ng isang eksperto sa wika na nauunawaan ang eksaktong hinihingi mo, gaano man ito ipahayag. Tinutulungan nito ang mga agents na maunawaan ang iyong mga kahilingan at tumugon sa natural, conversational na wika.

### Azure AI Search & Enterprise Data (Aklatan ng Impormasyon):
Isipin ang isang malaki, napapanahong aklatan na may lahat ng pinakabagong impormasyon sa paglalakbay—mga iskedyul ng flight, availability ng hotel, at marami pa. Hinahanap ng mga agents ang aklatang ito para makuha ang pinaka-tumpak na sagot para sa iyo.

### Authentication & Security (Guwardiya ng Seguridad):
Tulad ng isang guwardiya ng seguridad na nagbabantay kung sino ang makakapasok sa mga tiyak na lugar, ang bahaging ito ay sinisiguro na tanging mga awtorisadong tao at agents lamang ang makakakuha ng sensitibong impormasyon. Pinapanatili nitong ligtas at pribado ang iyong data.

### Deployment on Azure Container Apps (Ang Gusali):
Lahat ng mga katulong at kasangkapan ay nagtutulungan sa loob ng isang secure, scalable na gusali (ang cloud). Ibig sabihin nito ay kayang hawakan ng sistema ang maraming user nang sabay-sabay at palaging magagamit kapag kailangan mo ito.

## Paano ito lahat nagtutulungan:

Magsisimula ka sa pamamagitan ng pagtatanong sa harapan (UI).
Ang manager (MCP Server) ay nagdedesisyon kung aling espesyalista (agent) ang dapat tumulong sa iyo.
Gumagamit ang espesyalista ng eksperto sa wika (OpenAI) para maunawaan ang iyong kahilingan at ang aklatan (AI Search) para hanapin ang pinakamahusay na sagot.
Sinisiguro ng guwardiya ng seguridad (Authentication) na lahat ay ligtas.
Lahat ng ito ay nangyayari sa loob ng isang maaasahan, scalable na gusali (Azure Container Apps), kaya ang iyong karanasan ay maayos at ligtas.
Ang pagtutulungan na ito ay nagbibigay-daan sa sistema na mabilis at ligtas na tulungan ka sa pagpaplano ng iyong biyahe, tulad ng isang pangkat ng mga ekspertong travel agents na nagtutulungan sa isang modernong opisina!

## Teknikal na Pagpapatupad
- **MCP Server:** Nagho-host ng core orchestration logic, naglalantad ng mga agent tools, at namamahala sa context para sa multi-step travel planning workflows.
- **Agents:** Ang bawat agent (hal., FlightAgent, HotelAgent) ay ipinatupad bilang isang MCP tool na may sarili nitong prompt templates at logic.
- **Azure Integration:** Gumagamit ng Azure OpenAI para sa natural language understanding at Azure AI Search para sa data retrieval.
- **Security:** Nag-iintegrate sa Microsoft Entra ID para sa authentication at nag-aaplay ng least-privilege access controls sa lahat ng resources.
- **Deployment:** Sumusuporta sa deployment sa Azure Container Apps para sa scalability at operational efficiency.

## Mga Resulta at Epekto
- Nagpapakita kung paano magagamit ang MCP para i-orchestrate ang maraming AI agents sa isang totoong senaryo na pang-produksyon.
- Pinapabilis ang pagbuo ng solusyon sa pamamagitan ng pagbibigay ng reusable patterns para sa agent coordination, data integration, at secure deployment.
- Nagsisilbing blueprint para sa pagbuo ng domain-specific, AI-powered applications gamit ang MCP at mga serbisyo ng Azure.

## Mga Sanggunian
- [Azure AI Travel Agents GitHub Repository](https://github.com/Azure-Samples/azure-ai-travel-agents)
- [Azure OpenAI Service](https://azure.microsoft.com/en-us/products/ai-services/openai-service/)
- [Azure AI Search](https://azure.microsoft.com/en-us/products/ai-services/ai-search/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)

**Pagtatatuwa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Habang nagsusumikap kami para sa katumpakan, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga error o hindi tumpak na impormasyon. Ang orihinal na dokumento sa sariling wika nito ay dapat ituring na mapagkakatiwalaang sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot para sa anumang hindi pagkakaunawaan o maling interpretasyon na nagmumula sa paggamit ng pagsasaling ito.