<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b59b477037dc1dd6b1740a0420f3be14",
  "translation_date": "2025-07-17T08:46:45+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "tl"
}
-->
# Pinakabagong MCP Security Controls - Update ng Hulyo 2025

Habang patuloy na umuunlad ang Model Context Protocol (MCP), nananatiling mahalaga ang seguridad. Inilalahad ng dokumentong ito ang pinakabagong mga kontrol sa seguridad at mga pinakamahusay na kasanayan para sa ligtas na pagpapatupad ng MCP hanggang Hulyo 2025.

## Authentication at Authorization

### Suporta sa OAuth 2.0 Delegation

Ang mga kamakailang update sa MCP specification ay nagpapahintulot na ngayon sa mga MCP server na i-delegate ang user authentication sa mga panlabas na serbisyo tulad ng Microsoft Entra ID. Malaki ang naitutulong nito sa pagpapabuti ng seguridad sa pamamagitan ng:

1. **Pag-aalis ng Custom Auth Implementation**: Binabawasan ang panganib ng mga kahinaan sa custom authentication code  
2. **Paggamit ng Established Identity Providers**: Nakikinabang sa mga enterprise-grade na tampok ng seguridad  
3. **Pagpokus sa Centralized Identity Management**: Pinapasimple ang pamamahala ng user lifecycle at access control  

## Token Passthrough Prevention

Mahigpit na ipinagbabawal ng MCP Authorization Specification ang token passthrough upang maiwasan ang pag-iwas sa mga kontrol sa seguridad at mga isyu sa pananagutan.

### Pangunahing Mga Kinakailangan

1. **HINDI dapat tumanggap ang MCP servers ng mga token na hindi para sa kanila**: Siguraduhing tama ang audience claim ng lahat ng token  
2. **Magpatupad ng wastong token validation**: Suriin ang issuer, audience, expiration, at signature  
3. **Gumamit ng hiwalay na token issuance**: Mag-isyu ng bagong token para sa downstream services sa halip na ipasa ang umiiral na token  

## Secure Session Management

Upang maiwasan ang session hijacking at fixation attacks, ipatupad ang mga sumusunod na kontrol:

1. **Gumamit ng secure, non-deterministic session IDs**: Gawa gamit ang cryptographically secure random number generators  
2. **I-bind ang sessions sa user identity**: Pagsamahin ang session IDs sa user-specific na impormasyon  
3. **Magpatupad ng tamang session rotation**: Pagkatapos ng authentication changes o privilege escalation  
4. **Itakda ang angkop na session timeouts**: Balansihin ang seguridad at karanasan ng user  

## Tool Execution Sandboxing

Upang maiwasan ang lateral movement at mapigilan ang posibleng kompromiso:

1. **Ihiwalay ang mga tool execution environment**: Gumamit ng containers o hiwalay na proseso  
2. **Maglagay ng resource limits**: Iwasan ang resource exhaustion attacks  
3. **Magpatupad ng least privilege access**: Bigyan lamang ng kinakailangang permiso  
4. **Subaybayan ang execution patterns**: Tuklasin ang mga anomalous na kilos  

## Tool Definition Protection

Upang maiwasan ang tool poisoning:

1. **Suriin ang mga tool definition bago gamitin**: Hanapin ang mga malisyosong utos o hindi angkop na pattern  
2. **Gumamit ng integrity verification**: I-hash o lagyan ng pirma ang mga tool definition upang matukoy ang hindi awtorisadong pagbabago  
3. **Magpatupad ng change monitoring**: Magbigay ng alerto sa mga hindi inaasahang pagbabago sa tool metadata  
4. **Gamitin ang version control para sa tool definitions**: Subaybayan ang mga pagbabago at payagan ang rollback kung kinakailangan  

Ang mga kontrol na ito ay nagtutulungan upang makabuo ng matibay na seguridad para sa mga implementasyon ng MCP, na tinutugunan ang mga natatanging hamon ng AI-driven na mga sistema habang pinananatili ang matatag na tradisyunal na mga kasanayan sa seguridad.

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa kanyang sariling wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.