<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b1cffc51b82049ac3d5e88db0ff4a0a1",
  "translation_date": "2025-06-13T00:40:36+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "tl"
}
-->
# Mga Advanced na Paksa sa MCP

Ang kabanatang ito ay naglalayong talakayin ang mga serye ng advanced na paksa sa implementasyon ng Model Context Protocol (MCP), kabilang ang multi-modal integration, scalability, mga pinakamahusay na kasanayan sa seguridad, at enterprise integration. Mahalaga ang mga paksang ito para sa pagbuo ng matibay at handang gamitin sa produksyon na mga aplikasyon ng MCP na kayang tugunan ang mga pangangailangan ng makabagong AI system.

## Pangkalahatang Pagsusuri

Tinutuklas ng araling ito ang mga advanced na konsepto sa implementasyon ng Model Context Protocol, na nakatuon sa multi-modal integration, scalability, mga pinakamahusay na kasanayan sa seguridad, at enterprise integration. Mahalaga ang mga paksang ito para sa pagbuo ng production-grade na MCP applications na kayang humawak ng kumplikadong mga pangangailangan sa mga kapaligirang pang-enterprise.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Ipatupad ang multi-modal na kakayahan sa loob ng mga MCP framework
- Magdisenyo ng scalable na MCP architectures para sa mga sitwasyong may mataas na pangangailangan
- Ilapat ang mga pinakamahusay na kasanayan sa seguridad na nakaayon sa mga prinsipyo ng seguridad ng MCP
- Isama ang MCP sa mga enterprise AI system at framework
- I-optimize ang performance at pagiging maaasahan sa mga production environment

## Mga Aralin at Halimbawang Proyekto

| Link | Pamagat | Paglalarawan |
|------|---------|--------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrate with Azure | Matutunan kung paano isama ang iyong MCP Server sa Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modal samples | Mga halimbawa para sa audio, imahe, at multi modal na tugon |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimal na Spring Boot app na nagpapakita ng OAuth2 gamit ang MCP, bilang Authorization at Resource Server. Ipinapakita ang secure token issuance, protected endpoints, deployment sa Azure Container Apps, at API Management integration. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Matuto pa tungkol sa root context at kung paano ito ipinatutupad |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Matutunan ang iba't ibang uri ng routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Matutunan kung paano gumamit ng sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling | Matuto tungkol sa scaling |
| [5.8 Security](./mcp-security/README.md) | Security | Siguraduhin ang seguridad ng iyong MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server at client na nagsasama sa SerpAPI para sa real-time na web, balita, paghahanap ng produkto, at Q&A. Ipinapakita ang multi-tool orchestration, external API integration, at matibay na error handling. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Ang real-time data streaming ay naging mahalaga sa mundo ng data-driven ngayon, kung saan kailangan ng mga negosyo at aplikasyon ang agarang access sa impormasyon para makagawa ng napapanahong mga desisyon. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Web Search | Real-time web search kung paano binabago ng MCP ang real-time web search sa pamamagitan ng pagbibigay ng standardized na paraan sa pamamahala ng context sa pagitan ng AI models, search engines, at mga aplikasyon. |

## Karagdagang Sanggunian

Para sa pinakabagong impormasyon tungkol sa mga advanced na paksa sa MCP, tingnan ang:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Mga Pangunahing Punto

- Pinalalawak ng multi-modal MCP implementations ang kakayahan ng AI lampas sa text processing
- Mahalaga ang scalability para sa mga deployment sa enterprise at maaaring tugunan sa pamamagitan ng horizontal at vertical scaling
- Pinoprotektahan ng komprehensibong mga hakbang sa seguridad ang data at sinisiguro ang tamang access control
- Pinapalakas ng enterprise integration sa mga platform tulad ng Azure OpenAI at Microsoft AI Foundry ang kakayahan ng MCP
- Nakikinabang ang mga advanced na implementasyon ng MCP mula sa optimized na arkitektura at maingat na pamamahala ng mga resources

## Ehersisyo

Magdisenyo ng enterprise-grade na implementasyon ng MCP para sa isang tiyak na kaso ng paggamit:

1. Tukuyin ang mga multi-modal na pangangailangan para sa iyong kaso ng paggamit
2. Ilahad ang mga kontrol sa seguridad na kinakailangan upang maprotektahan ang sensitibong data
3. Magdisenyo ng scalable na arkitektura na kayang humawak ng nagbabagong load
4. Planuhin ang mga punto ng integrasyon sa mga enterprise AI system
5. Idokumento ang mga posibleng bottleneck sa performance at mga estratehiya para sa pag-iwas

## Karagdagang Mga Mapagkukunan

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Ano ang susunod

- [5.1 MCP Integration](./mcp-integration/README.md)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kaming maging tumpak, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaintindihan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.