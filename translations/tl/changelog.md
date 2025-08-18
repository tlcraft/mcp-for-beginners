<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T18:08:35+00:00",
  "source_file": "changelog.md",
  "language_code": "tl"
}
-->
# Changelog: MCP para sa Baguhan na Kurikulum

Ang dokumentong ito ay nagsisilbing talaan ng lahat ng mahahalagang pagbabago na ginawa sa Model Context Protocol (MCP) para sa Baguhan na kurikulum. Ang mga pagbabago ay naitala sa reverse chronological order (pinakabagong pagbabago muna).

## Agosto 18, 2025

### Komprehensibong Pag-update ng Dokumentasyon - Mga Pamantayan ng MCP 2025-06-18

#### Mga Pinakamahusay na Kasanayan sa Seguridad ng MCP (02-Security/) - Ganap na Modernisasyon
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Ganap na muling isinulat alinsunod sa MCP Specification 2025-06-18
  - **Mga Mandatoryong Kinakailangan**: Idinagdag ang malinaw na MUST/MUST NOT na mga kinakailangan mula sa opisyal na spesipikasyon na may malinaw na visual na indikasyon
  - **12 Core Security Practices**: Mula sa 15-item na listahan, inayos sa mas malawak na mga domain ng seguridad
    - Seguridad ng Token at Pagpapatunay gamit ang integrasyon ng external identity provider
    - Pamamahala ng Session at Transport Security na may mga kinakailangan sa cryptography
    - Proteksyon laban sa AI-Specific Threat gamit ang Microsoft Prompt Shields integration
    - Access Control at Permissions na sumusunod sa prinsipyo ng least privilege
    - Kaligtasan ng Nilalaman at Pagsubaybay gamit ang Azure Content Safety integration
    - Seguridad ng Supply Chain na may komprehensibong beripikasyon ng mga bahagi
    - Seguridad ng OAuth at Pag-iwas sa Confused Deputy gamit ang PKCE implementation
    - Tugon sa Insidente at Pagbawi na may automated capabilities
    - Pagsunod at Pamamahala na may regulasyon na pagkakahanay
    - Advanced Security Controls na may zero trust architecture
    - Integrasyon ng Microsoft Security Ecosystem na may komprehensibong solusyon
    - Patuloy na Ebolusyon ng Seguridad na may adaptive practices
  - **Microsoft Security Solutions**: Pinahusay na gabay sa integrasyon para sa Prompt Shields, Azure Content Safety, Entra ID, at GitHub Advanced Security
  - **Mga Mapagkukunan para sa Implementasyon**: Kategoryang komprehensibong mga link ng mapagkukunan ayon sa Opisyal na Dokumentasyon ng MCP, Microsoft Security Solutions, Security Standards, at Implementation Guides

#### Advanced Security Controls (02-Security/) - Implementasyon para sa Enterprise
- **MCP-SECURITY-CONTROLS-2025.md**: Ganap na muling inayos gamit ang enterprise-grade security framework
  - **9 Comprehensive Security Domains**: Pinalawak mula sa basic controls patungo sa detalyadong enterprise framework
    - Advanced Authentication at Authorization gamit ang Microsoft Entra ID integration
    - Seguridad ng Token at Anti-Passthrough Controls na may komprehensibong beripikasyon
    - Mga Kontrol sa Seguridad ng Session na may pag-iwas sa hijacking
    - AI-Specific Security Controls na may pag-iwas sa prompt injection at tool poisoning
    - Pag-iwas sa Confused Deputy Attack gamit ang OAuth proxy security
    - Seguridad ng Tool Execution na may sandboxing at isolation
    - Mga Kontrol sa Seguridad ng Supply Chain na may beripikasyon ng dependency
    - Monitoring at Detection Controls na may SIEM integration
    - Tugon sa Insidente at Pagbawi na may automated capabilities
  - **Mga Halimbawa ng Implementasyon**: Idinagdag ang detalyadong YAML configuration blocks at mga halimbawa ng code
  - **Integrasyon ng Microsoft Solutions**: Komprehensibong coverage ng Azure security services, GitHub Advanced Security, at enterprise identity management

#### Advanced Topics Security (05-AdvancedTopics/mcp-security/) - Implementasyon Handa para sa Produksyon
- **README.md**: Ganap na muling isinulat para sa enterprise security implementation
  - **Pagkakahanay sa Kasalukuyang Spesipikasyon**: Na-update sa MCP Specification 2025-06-18 na may mandatoryong mga kinakailangan sa seguridad
  - **Pinahusay na Authentication**: Microsoft Entra ID integration na may komprehensibong .NET at Java Spring Security examples
  - **Integrasyon ng AI Security**: Microsoft Prompt Shields at Azure Content Safety implementation na may detalyadong Python examples
  - **Advanced Threat Mitigation**: Komprehensibong mga halimbawa ng implementasyon para sa
    - Pag-iwas sa Confused Deputy Attack gamit ang PKCE at beripikasyon ng user consent
    - Pag-iwas sa Token Passthrough gamit ang audience validation at secure token management
    - Pag-iwas sa Session Hijacking gamit ang cryptographic binding at behavioral analysis
  - **Integrasyon ng Enterprise Security**: Azure Application Insights monitoring, threat detection pipelines, at seguridad ng supply chain
  - **Checklist ng Implementasyon**: Malinaw na mandatory vs. recommended security controls na may benepisyo ng Microsoft security ecosystem

### Kalidad ng Dokumentasyon at Pagkakahanay sa Pamantayan
- **Mga Reference ng Spesipikasyon**: Na-update ang lahat ng reference sa kasalukuyang MCP Specification 2025-06-18
- **Microsoft Security Ecosystem**: Pinahusay na gabay sa integrasyon sa lahat ng dokumentasyon ng seguridad
- **Praktikal na Implementasyon**: Idinagdag ang detalyadong mga halimbawa ng code sa .NET, Java, at Python na may enterprise patterns
- **Organisasyon ng Mapagkukunan**: Komprehensibong kategorya ng opisyal na dokumentasyon, mga pamantayan sa seguridad, at mga gabay sa implementasyon
- **Visual Indicators**: Malinaw na pagmamarka ng mandatoryong mga kinakailangan vs. recommended practices

#### Core Concepts (01-CoreConcepts/) - Ganap na Modernisasyon
- **Pag-update ng Bersyon ng Protocol**: Na-update upang i-refer ang kasalukuyang MCP Specification 2025-06-18 na may date-based versioning (YYYY-MM-DD format)
- **Pagpapino ng Arkitektura**: Pinahusay na mga paglalarawan ng Hosts, Clients, at Servers upang ipakita ang kasalukuyang mga pattern ng arkitektura ng MCP
  - Ang Hosts ay malinaw na tinukoy bilang mga AI application na nagkokoordina ng maraming koneksyon ng MCP client
  - Ang Clients ay inilarawan bilang mga protocol connector na nagpapanatili ng one-to-one server relationships
  - Ang Servers ay pinahusay na may mga lokal vs. remote deployment scenarios
- **Restructuring ng Primitives**: Ganap na muling inayos ang server at client primitives
  - Server Primitives: Resources (data sources), Prompts (templates), Tools (executable functions) na may detalyadong paliwanag at mga halimbawa
  - Client Primitives: Sampling (LLM completions), Elicitation (user input), Logging (debugging/monitoring)
  - Na-update gamit ang kasalukuyang discovery (`*/list`), retrieval (`*/get`), at execution (`*/call`) method patterns
- **Arkitektura ng Protocol**: Ipinakilala ang two-layer architecture model
  - Data Layer: JSON-RPC 2.0 foundation na may lifecycle management at primitives
  - Transport Layer: STDIO (local) at Streamable HTTP na may SSE (remote) transport mechanisms
- **Framework ng Seguridad**: Komprehensibong mga prinsipyo ng seguridad kabilang ang explicit user consent, proteksyon sa privacy ng data, kaligtasan ng tool execution, at transport layer security
- **Mga Pattern ng Komunikasyon**: Na-update ang mga protocol message upang ipakita ang initialization, discovery, execution, at notification flows
- **Mga Halimbawa ng Code**: Na-refresh ang multi-language examples (.NET, Java, Python, JavaScript) upang ipakita ang kasalukuyang MCP SDK patterns

#### Seguridad (02-Security/) - Komprehensibong Overhaul ng Seguridad  
- **Pagkakahanay sa Pamantayan**: Ganap na pagkakahanay sa MCP Specification 2025-06-18 na mga kinakailangan sa seguridad
- **Ebolusyon ng Authentication**: Na-dokumenta ang ebolusyon mula sa custom OAuth servers patungo sa external identity provider delegation (Microsoft Entra ID)
- **Pagsusuri ng AI-Specific Threat**: Pinahusay na coverage ng modern AI attack vectors
  - Detalyadong mga senaryo ng prompt injection attack na may mga halimbawa sa totoong mundo
  - Mga mekanismo ng tool poisoning at "rug pull" attack patterns
  - Context window poisoning at model confusion attacks
- **Microsoft AI Security Solutions**: Komprehensibong coverage ng Microsoft security ecosystem
  - AI Prompt Shields na may advanced detection, spotlighting, at delimiter techniques
  - Azure Content Safety integration patterns
  - GitHub Advanced Security para sa proteksyon ng supply chain
- **Advanced Threat Mitigation**: Detalyadong mga kontrol sa seguridad para sa
  - Session hijacking na may mga senaryo ng MCP-specific attack at mga kinakailangan sa cryptographic session ID
  - Mga problema sa Confused Deputy sa mga MCP proxy scenarios na may explicit consent requirements
  - Mga kahinaan sa Token Passthrough na may mandatory validation controls
- **Seguridad ng Supply Chain**: Pinalawak na coverage ng AI supply chain kabilang ang foundation models, embeddings services, context providers, at third-party APIs
- **Foundation Security**: Pinahusay na integrasyon sa mga enterprise security patterns kabilang ang zero trust architecture at Microsoft security ecosystem
- **Organisasyon ng Mapagkukunan**: Kategoryang komprehensibong mga link ng mapagkukunan ayon sa uri (Opisyal na Dokumento, Pamantayan, Pananaliksik, Microsoft Solutions, Implementation Guides)

### Mga Pagpapabuti sa Kalidad ng Dokumentasyon
- **Structured Learning Objectives**: Pinahusay na mga layunin sa pag-aaral na may tiyak, actionable outcomes 
- **Cross-References**: Idinagdag ang mga link sa pagitan ng mga kaugnay na paksa ng seguridad at core concept
- **Kasalukuyang Impormasyon**: Na-update ang lahat ng mga reference sa petsa at mga link ng spesipikasyon sa kasalukuyang pamantayan
- **Gabay sa Implementasyon**: Idinagdag ang tiyak, actionable na mga gabay sa implementasyon sa buong seksyon

## Hulyo 16, 2025

### README at Mga Pagpapabuti sa Navigation
- Ganap na muling dinisenyo ang navigation ng kurikulum sa README.md
- Pinalitan ang `<details>` tags ng mas accessible na table-based format
- Lumikha ng mga alternatibong layout options sa bagong "alternative_layouts" folder
- Idinagdag ang mga halimbawa ng card-based, tabbed-style, at accordion-style navigation
- Na-update ang seksyon ng repository structure upang isama ang lahat ng pinakabagong file
- Pinahusay ang seksyon na "Paano Gamitin ang Kurikulum na Ito" na may malinaw na rekomendasyon
- Na-update ang mga link ng MCP specification upang ituro sa tamang URLs
- Idinagdag ang seksyon ng Context Engineering (5.14) sa istruktura ng kurikulum

### Mga Update sa Study Guide
- Ganap na binago ang study guide upang i-align sa kasalukuyang istruktura ng repository
- Idinagdag ang mga bagong seksyon para sa MCP Clients at Tools, at Popular MCP Servers
- Na-update ang Visual Curriculum Map upang tumpak na ipakita ang lahat ng paksa
- Pinahusay ang mga paglalarawan ng Advanced Topics upang masakop ang lahat ng specialized areas
- Na-update ang seksyon ng Case Studies upang ipakita ang aktwal na mga halimbawa
- Idinagdag ang komprehensibong changelog na ito

### Mga Kontribusyon ng Komunidad (06-CommunityContributions/)
- Idinagdag ang detalyadong impormasyon tungkol sa MCP servers para sa image generation
- Idinagdag ang komprehensibong seksyon sa paggamit ng Claude sa VSCode
- Idinagdag ang mga tagubilin sa setup at paggamit ng Cline terminal client
- Na-update ang seksyon ng MCP client upang isama ang lahat ng popular na client options
- Pinahusay ang mga halimbawa ng kontribusyon na may mas tumpak na mga sample ng code

### Advanced Topics (05-AdvancedTopics/)
- Inayos ang lahat ng specialized topic folders na may consistent naming
- Idinagdag ang mga materyales at halimbawa ng context engineering
- Idinagdag ang dokumentasyon ng Foundry agent integration
- Pinahusay ang dokumentasyon ng Entra ID security integration

## Hunyo 11, 2025

### Paunang Paglikha
- Inilabas ang unang bersyon ng MCP para sa Baguhan na kurikulum
- Lumikha ng pangunahing istruktura para sa lahat ng 10 pangunahing seksyon
- Nagpatupad ng Visual Curriculum Map para sa navigation
- Idinagdag ang mga paunang sample na proyekto sa iba't ibang programming languages

### Pagsisimula (03-GettingStarted/)
- Lumikha ng mga unang halimbawa ng server implementation
- Idinagdag ang gabay sa pag-develop ng client
- Isinama ang mga tagubilin sa integrasyon ng LLM client
- Idinagdag ang dokumentasyon ng VS Code integration
- Nagpatupad ng mga halimbawa ng Server-Sent Events (SSE) server

### Core Concepts (01-CoreConcepts/)
- Idinagdag ang detalyadong paliwanag ng client-server architecture
- Lumikha ng dokumentasyon sa mga pangunahing bahagi ng protocol
- Na-dokumenta ang mga pattern ng messaging sa MCP

## Mayo 23, 2025

### Istruktura ng Repository
- Inisyalisa ang repository na may pangunahing istruktura ng folder
- Lumikha ng mga README file para sa bawat pangunahing seksyon
- Nag-set up ng translation infrastructure
- Idinagdag ang mga image assets at diagram

### Dokumentasyon
- Lumikha ng paunang README.md na may overview ng kurikulum
- Idinagdag ang CODE_OF_CONDUCT.md at SECURITY.md
- Nag-set up ng SUPPORT.md na may gabay para sa pagkuha ng tulong
- Lumikha ng preliminary study guide structure

## Abril 15, 2025

### Pagpaplano at Framework
- Paunang pagpaplano para sa MCP para sa Baguhan na kurikulum
- Tinukoy ang mga layunin sa pag-aaral at target na audience
- In-outline ang 10-seksyon na istruktura ng kurikulum
- Nag-develop ng conceptual framework para sa mga halimbawa at case studies
- Lumikha ng mga paunang prototype na halimbawa para sa mga pangunahing konsepto

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama't sinisikap naming maging tumpak, pakitandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa kanyang orihinal na wika ang dapat ituring na opisyal na sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.