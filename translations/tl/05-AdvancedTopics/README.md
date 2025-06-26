<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b96f2864e0bcb6fae9b4926813c3feb1",
  "translation_date": "2025-06-26T14:14:32+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "tl"
}
-->
# Mga Advanced na Paksa sa MCP

Ang kabanatang ito ay naglalayong talakayin ang mga advanced na paksa sa pagpapatupad ng Model Context Protocol (MCP), kabilang ang multi-modal integration, scalability, mga pinakamahusay na kasanayan sa seguridad, at enterprise integration. Mahalaga ang mga paksang ito para makabuo ng matibay at handang gamitin sa produksyon na mga aplikasyon ng MCP na kayang tugunan ang mga pangangailangan ng makabagong AI system.

## Pangkalahatang-ideya

Tinutuklas ng araling ito ang mga advanced na konsepto sa pagpapatupad ng Model Context Protocol, na nakatuon sa multi-modal integration, scalability, mga pinakamahusay na kasanayan sa seguridad, at enterprise integration. Mahalaga ang mga paksang ito para makabuo ng mga aplikasyon ng MCP na handang gamitin sa produksyon at kayang harapin ang mga kumplikadong pangangailangan sa mga kapaligiran ng enterprise.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Ipatupad ang mga multi-modal na kakayahan sa loob ng mga MCP framework
- Magdisenyo ng scalable na mga arkitektura ng MCP para sa mga sitwasyong mataas ang pangangailangan
- Ilapat ang mga pinakamahusay na kasanayan sa seguridad na naaayon sa mga prinsipyo ng seguridad ng MCP
- Isama ang MCP sa mga enterprise AI system at framework
- I-optimize ang pagganap at pagiging maaasahan sa mga production environment

## Mga Aralin at Halimbawang Proyekto

| Link | Pamagat | Paglalarawan |
|------|---------|--------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrasyon sa Azure | Alamin kung paano i-integrate ang iyong MCP Server sa Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Mga Halimbawa ng MCP Multi modal | Mga halimbawa para sa audio, imahe, at multi-modal na tugon |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimal na Spring Boot app na nagpapakita ng OAuth2 gamit ang MCP, bilang Authorization at Resource Server. Ipinapakita ang ligtas na pag-isyu ng token, protektadong mga endpoint, deployment sa Azure Container Apps, at integrasyon sa API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Mga Root Context | Alamin pa tungkol sa root context at kung paano ito ipinatutupad |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Alamin ang iba't ibang uri ng routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Alamin kung paano gumamit ng sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling | Alamin ang tungkol sa scaling |
| [5.8 Security](./mcp-security/README.md) | Seguridad | Siguraduhin ang kaligtasan ng iyong MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server at client na naka-integrate sa SerpAPI para sa real-time na paghahanap sa web, balita, produkto, at Q&A. Ipinapakita ang multi-tool orchestration, integrasyon ng external API, at matibay na paghawak ng error. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Ang real-time data streaming ay naging mahalaga sa mundo ng data ngayon, kung saan kailangan ng mga negosyo at aplikasyon ang agarang access sa impormasyon para makagawa ng napapanahong desisyon. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Paano binabago ng MCP ang real-time web search sa pamamagitan ng pagbibigay ng standardized na paraan ng pamamahala ng context sa pagitan ng mga AI model, search engine, at aplikasyon. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Entra ID Authentication | Nagbibigay ang Microsoft Entra ID ng matatag na cloud-based na solusyon para sa identity at access management, na tumutulong tiyakin na tanging mga awtorisadong user at aplikasyon lamang ang makakagamit ng iyong MCP server. |

## Karagdagang Sanggunian

Para sa pinakabagong impormasyon tungkol sa mga advanced na paksa sa MCP, bisitahin ang:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Mga Pangunahing Aral

- Pinalalawak ng multi-modal na pagpapatupad ng MCP ang kakayahan ng AI lampas sa pagproseso ng teksto
- Mahalaga ang scalability para sa mga deployment sa enterprise at maaaring matugunan sa pamamagitan ng horizontal at vertical scaling
- Pinoprotektahan ng komprehensibong mga hakbang sa seguridad ang data at tinitiyak ang tamang access control
- Pinapalawak ng enterprise integration sa mga platform tulad ng Azure OpenAI at Microsoft AI Foundry ang mga kakayahan ng MCP
- Nakikinabang ang mga advanced na pagpapatupad ng MCP mula sa optimized na mga arkitektura at maingat na pamamahala ng mga resources

## Ehersisyo

Magdisenyo ng enterprise-grade na pagpapatupad ng MCP para sa isang partikular na kaso ng paggamit:

1. Tukuyin ang mga multi-modal na pangangailangan para sa iyong kaso ng paggamit
2. Ilahad ang mga kontrol sa seguridad na kailangan upang protektahan ang sensitibong data
3. Magdisenyo ng scalable na arkitektura na kayang hawakan ang nagbabagong load
4. Magplano ng mga integration point sa mga enterprise AI system
5. Idokumento ang mga posibleng bottleneck sa pagganap at mga estratehiya para malutas ito

## Karagdagang Mga Mapagkukunan

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Ano ang susunod

- [5.1 MCP Integration](./mcp-integration/README.md)

**Pahayag ng Pagsuway**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat aming pinagsisikapang maging tumpak ang salin, pakatandaan na ang awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na bahagi. Ang orihinal na dokumento sa kanyang orihinal na wika ang dapat ituring na pinagmulan ng katotohanan. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng salin na ito.