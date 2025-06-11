<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T16:09:22+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "tl"
}
-->
# Mga Advanced na Paksa sa MCP

Ang kabanatang ito ay naglalayong talakayin ang mga advanced na paksa sa implementasyon ng Model Context Protocol (MCP), kabilang ang multi-modal integration, scalability, mga pinakamahusay na kasanayan sa seguridad, at enterprise integration. Mahalaga ang mga paksang ito para makabuo ng matibay at handang gamitin sa produksyon na mga aplikasyon ng MCP na kayang tugunan ang mga pangangailangan ng modernong AI systems.

## Pangkalahatang-ideya

Tinutuklas ng araling ito ang mga advanced na konsepto sa implementasyon ng Model Context Protocol, na nakatuon sa multi-modal integration, scalability, mga pinakamahusay na kasanayan sa seguridad, at enterprise integration. Mahalaga ang mga paksang ito para makabuo ng production-grade na mga aplikasyon ng MCP na kayang humawak ng mga komplikadong pangangailangan sa mga enterprise environment.

## Mga Layunin sa Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Magpatupad ng multi-modal na kakayahan sa loob ng mga MCP framework  
- Magdisenyo ng scalable na mga arkitektura ng MCP para sa mga senaryong mataas ang pangangailangan  
- Mag-aplay ng mga pinakamahusay na kasanayan sa seguridad na naaayon sa mga prinsipyo ng seguridad ng MCP  
- Isama ang MCP sa mga enterprise AI system at framework  
- I-optimize ang performance at pagiging maaasahan sa mga production environment  

## Mga Aralin at Halimbawang Proyekto

| Link | Pamagat | Paglalarawan |
|------|---------|--------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrate with Azure | Matutunan kung paano isama ang iyong MCP Server sa Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modal samples | Mga halimbawa para sa audio, imahe, at multi-modal na tugon |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimal na Spring Boot app na nagpapakita ng OAuth2 gamit ang MCP, bilang Authorization at Resource Server. Ipinapakita ang secure na token issuance, protektadong endpoints, deployment sa Azure Container Apps, at API Management integration. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Matutunan pa tungkol sa root context at kung paano ito ipinatutupad |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Matutunan ang iba't ibang uri ng routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Matutunan kung paano gumamit ng sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling | Matutunan tungkol sa scaling |
| [5.8 Security](./mcp-security/README.md) | Security | Siguraduhin ang iyong MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server at client na nagsasama ng SerpAPI para sa real-time na web, balita, paghahanap ng produkto, at Q&A. Ipinapakita ang multi-tool orchestration, external API integration, at matatag na error handling. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Ang real-time na data streaming ay naging mahalaga sa makabagong mundo ng datos, kung saan kailangan ng mga negosyo at aplikasyon ng agarang access sa impormasyon para makagawa ng napapanahong desisyon. |

## Karagdagang Sanggunian

Para sa pinakabagong impormasyon tungkol sa mga advanced na paksa ng MCP, sumangguni sa:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Mga Pangunahing Punto

- Pinalalawak ng multi-modal na implementasyon ng MCP ang kakayahan ng AI lampas sa pagproseso ng teksto  
- Mahalaga ang scalability para sa mga deployment sa enterprise at maaaring matugunan sa pamamagitan ng horizontal at vertical scaling  
- Pinoprotektahan ng komprehensibong mga hakbang sa seguridad ang datos at tinitiyak ang tamang access control  
- Pinapalakas ng enterprise integration sa mga platform tulad ng Azure OpenAI at Microsoft AI Foundry ang mga kakayahan ng MCP  
- Nakikinabang ang mga advanced na implementasyon ng MCP mula sa optimized na mga arkitektura at maingat na pamamahala ng mga resources  

## Ehersisyo

Disenyo ng enterprise-grade na implementasyon ng MCP para sa isang partikular na kaso ng paggamit:

1. Tukuyin ang mga multi-modal na pangangailangan para sa iyong kaso ng paggamit  
2. Ilahad ang mga kontrol sa seguridad na kailangan para protektahan ang sensitibong datos  
3. Disenyo ng scalable na arkitektura na kayang humawak ng nagbabagong load  
4. Planuhin ang mga integration point sa mga enterprise AI system  
5. Idokumento ang mga posibleng bottleneck sa performance at mga estratehiya sa pag-iwas  

## Karagdagang Mga Mapagkukunan

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Ano ang susunod

- [5.1 MCP Integration](./mcp-integration/README.md)

**Pagsasalin ng Tiwala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, mangyaring tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang maling pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.