<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "494d87e1c4b9239c70f6a341fcc59a48",
  "translation_date": "2025-06-02T19:23:08+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "tl"
}
-->
# Mga Advanced na Paksa sa MCP

Ang kabanatang ito ay naglalayong talakayin ang mga serye ng advanced na paksa sa pagpapatupad ng Model Context Protocol (MCP), kabilang ang multi-modal integration, scalability, mga pinakamahusay na kasanayan sa seguridad, at enterprise integration. Mahalaga ang mga paksang ito para makabuo ng matibay at handang gamitin sa produksyon na mga aplikasyon ng MCP na kayang tugunan ang mga pangangailangan ng makabagong mga sistema ng AI.

## Pangkalahatang-ideya

Tinutuklas ng araling ito ang mga advanced na konsepto sa pagpapatupad ng Model Context Protocol, na nakatuon sa multi-modal integration, scalability, mga pinakamahusay na kasanayan sa seguridad, at enterprise integration. Mahalaga ang mga paksang ito para makabuo ng mga production-grade na aplikasyon ng MCP na kayang harapin ang mga komplikadong pangangailangan sa mga kapaligiran ng enterprise.

## Mga Layunin ng Pagkatuto

Sa pagtatapos ng araling ito, magagawa mong:

- Ipatupad ang mga kakayahan ng multi-modal sa loob ng mga framework ng MCP
- Disenyuhin ang scalable na mga arkitektura ng MCP para sa mga sitwasyong may mataas na pangangailangan
- Ilapat ang mga pinakamahusay na kasanayan sa seguridad na naaayon sa mga prinsipyo ng seguridad ng MCP
- Isama ang MCP sa mga enterprise AI system at framework
- I-optimize ang performance at pagiging maaasahan sa mga production environment

## Mga Aralin at Halimbawang Proyekto

| Link | Pamagat | Paglalarawan |
|------|---------|--------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrate with Azure | Alamin kung paano isama ang iyong MCP Server sa Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | MCP Multi modal samples | Mga halimbawa para sa audio, imahe, at multi-modal na tugon |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | MCP OAuth2 Demo | Minimal na Spring Boot app na nagpapakita ng OAuth2 gamit ang MCP, bilang Authorization at Resource Server. Ipinapakita ang secure token issuance, protektadong endpoints, deployment sa Azure Container Apps, at integrasyon sa API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Root contexts | Alamin pa tungkol sa root context at kung paano ito ipinatutupad |
| [5.5 Routing](./mcp-routing/README.md) | Routing | Matutunan ang iba't ibang uri ng routing |
| [5.6 Sampling](./mcp-sampling/README.md) | Sampling | Alamin kung paano gamitin ang sampling |
| [5.7 Scaling](./mcp-scaling/README.md) | Scaling | Matutunan ang tungkol sa scaling |
| [5.8 Security](./mcp-security/README.md) | Security | Pangalagaan ang iyong MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Web Search MCP | Python MCP server at client na nagsasama sa SerpAPI para sa real-time na web, balita, paghahanap ng produkto, at Q&A. Ipinapakita ang multi-tool orchestration, integrasyon ng external API, at matibay na paghawak ng error. |

## Karagdagang Sanggunian

Para sa pinaka-updated na impormasyon tungkol sa mga advanced na paksa ng MCP, tingnan ang:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Mga Pangunahing Aral

- Pinalalawak ng multi-modal na pagpapatupad ng MCP ang kakayahan ng AI lampas sa text processing
- Mahalaga ang scalability para sa mga deployment sa enterprise at maaaring tugunan sa pamamagitan ng horizontal at vertical scaling
- Pinoprotektahan ng komprehensibong mga hakbang sa seguridad ang data at sinisiguro ang tamang kontrol sa access
- Pinapalakas ng enterprise integration sa mga platform tulad ng Azure OpenAI at Microsoft AI Foundry ang kakayahan ng MCP
- Nakikinabang ang mga advanced na pagpapatupad ng MCP mula sa optimized na mga arkitektura at maingat na pamamahala ng mga resources

## Pagsasanay

Disenyuhin ang isang enterprise-grade na pagpapatupad ng MCP para sa isang partikular na kaso ng paggamit:

1. Tukuyin ang mga pangangailangan sa multi-modal para sa iyong kaso ng paggamit
2. Ilahad ang mga kontrol sa seguridad na kailangan upang maprotektahan ang sensitibong data
3. Disenyuhin ang scalable na arkitektura na kayang humawak ng iba't ibang load
4. Planuhin ang mga punto ng integrasyon sa mga enterprise AI system
5. Idokumento ang mga posibleng bottleneck sa performance at mga estratehiya sa pag-iwas

## Karagdagang Mga Mapagkukunan

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Ano ang susunod

- [5.1 MCP Integration](./mcp-integration/README.md)

**Pagtatapat**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na bahagi. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.