<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:26:17+00:00",
  "source_file": "changelog.md",
  "language_code": "tl"
}
-->
# Changelog: MCP para sa Baguhan na Kurikulum

Ang dokumentong ito ay nagsisilbing talaan ng lahat ng mahahalagang pagbabago na ginawa sa Model Context Protocol (MCP) para sa Baguhan na kurikulum. Ang mga pagbabago ay naitala sa reverse chronological order (pinakabagong pagbabago muna).

## Setyembre 15, 2025

### Pagpapalawak ng Advanced Topics - Custom Transports & Context Engineering

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - Bagong Gabay sa Advanced na Implementasyon
- **README.md**: Kumpletong gabay sa implementasyon para sa mga custom na mekanismo ng MCP transport
  - **Azure Event Grid Transport**: Komprehensibong serverless event-driven transport implementation
    - Mga halimbawa sa C#, TypeScript, at Python na may Azure Functions integration
    - Mga pattern ng event-driven architecture para sa scalable MCP solutions
    - Webhook receivers at push-based na paghawak ng mensahe
  - **Azure Event Hubs Transport**: Implementasyon para sa high-throughput streaming transport
    - Kakayahan sa real-time streaming para sa low-latency scenarios
    - Mga estratehiya sa partitioning at pamamahala ng checkpoint
    - Pag-batch ng mensahe at pag-optimize ng performance
  - **Enterprise Integration Patterns**: Mga halimbawa ng arkitektura na handa para sa produksyon
    - Distributed MCP processing sa maraming Azure Functions
    - Hybrid transport architectures na pinagsasama ang iba't ibang uri ng transport
    - Mga estratehiya para sa durability, reliability, at paghawak ng error
  - **Security & Monitoring**: Integrasyon ng Azure Key Vault at mga pattern ng observability
    - Managed identity authentication at least privilege access
    - Application Insights telemetry at performance monitoring
    - Circuit breakers at mga pattern ng fault tolerance
  - **Testing Frameworks**: Komprehensibong mga estratehiya sa testing para sa custom transports
    - Unit testing gamit ang test doubles at mocking frameworks
    - Integration testing gamit ang Azure Test Containers
    - Mga konsiderasyon sa performance at load testing

#### Context Engineering (05-AdvancedTopics/mcp-contextengineering/) - Umuusbong na Disiplina sa AI
- **README.md**: Komprehensibong eksplorasyon ng context engineering bilang isang umuusbong na larangan
  - **Core Principles**: Kumpletong context sharing, action decision awareness, at context window management
  - **MCP Protocol Alignment**: Paano tinutugunan ng disenyo ng MCP ang mga hamon sa context engineering
    - Mga limitasyon ng context window at mga estratehiya sa progressive loading
    - Pagtukoy ng kaugnayan at dynamic na pagkuha ng context
    - Multi-modal na paghawak ng context at mga konsiderasyon sa seguridad
  - **Implementation Approaches**: Single-threaded vs. multi-agent architectures
    - Mga teknik sa context chunking at prioritization
    - Progressive context loading at compression strategies
    - Layered context approaches at optimization sa retrieval
  - **Measurement Framework**: Umuusbong na mga sukatan para sa pagsusuri ng bisa ng context
    - Input efficiency, performance, quality, at mga konsiderasyon sa karanasan ng user
    - Mga eksperimento sa pag-optimize ng context
    - Pagsusuri ng pagkabigo at mga metodolohiya sa pagpapabuti

#### Mga Update sa Curriculum Navigation (README.md)
- **Pinahusay na Module Structure**: Na-update ang talahanayan ng kurikulum upang isama ang mga bagong advanced topics
  - Idinagdag ang Context Engineering (5.14) at Custom Transport (5.15) na mga entry
  - Konsistent na formatting at mga navigation link sa lahat ng module
  - Na-update ang mga deskripsyon upang ipakita ang kasalukuyang saklaw ng nilalaman

### Mga Pagpapabuti sa Directory Structure
- **Pag-standardize ng Pangalan**: Pinalitan ang "mcp transport" ng "mcp-transport" para sa konsistensya sa iba pang advanced topic folders
- **Organisasyon ng Nilalaman**: Ang lahat ng 05-AdvancedTopics folders ay sumusunod na ngayon sa konsistent na pattern ng pangalan (mcp-[topic])

### Mga Pagpapahusay sa Kalidad ng Dokumentasyon
- **Pag-align sa MCP Specification**: Ang lahat ng bagong nilalaman ay tumutukoy sa kasalukuyang MCP Specification 2025-06-18
- **Multi-Language Examples**: Komprehensibong mga halimbawa ng code sa C#, TypeScript, at Python
- **Enterprise Focus**: Mga pattern na handa para sa produksyon at integrasyon sa Azure cloud sa kabuuan
- **Visual Documentation**: Mga diagram ng Mermaid para sa arkitektura at visualization ng daloy

## Agosto 18, 2025

### Komprehensibong Update sa Dokumentasyon - MCP 2025-06-18 Standards

#### MCP Security Best Practices (02-Security/) - Kumpletong Modernisasyon
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kumpletong pagsulat na naka-align sa MCP Specification 2025-06-18
  - **Mandatory Requirements**: Idinagdag ang mga explicit na MUST/MUST NOT requirements mula sa opisyal na specification na may malinaw na visual indicators
  - **12 Core Security Practices**: Mula sa 15-item list, nirestrukturang maging komprehensibong mga domain ng seguridad
    - Token Security & Authentication na may integrasyon sa external identity provider
    - Session Management & Transport Security na may mga cryptographic requirements
    - AI-Specific Threat Protection na may integrasyon sa Microsoft Prompt Shields
    - Access Control & Permissions na may prinsipyo ng least privilege
    - Content Safety & Monitoring na may integrasyon sa Azure Content Safety
    - Supply Chain Security na may komprehensibong beripikasyon ng mga component
    - OAuth Security & Confused Deputy Prevention na may PKCE implementation
    - Incident Response & Recovery na may automated capabilities
    - Compliance & Governance na may regulatory alignment
    - Advanced Security Controls na may zero trust architecture
    - Microsoft Security Ecosystem Integration na may komprehensibong solusyon
    - Continuous Security Evolution na may adaptive practices
  - **Microsoft Security Solutions**: Pinahusay na gabay sa integrasyon para sa Prompt Shields, Azure Content Safety, Entra ID, at GitHub Advanced Security
  - **Implementation Resources**: Nakategoryang komprehensibong mga link ng resource ayon sa Official MCP Documentation, Microsoft Security Solutions, Security Standards, at Implementation Guides

#### Advanced Security Controls (02-Security/) - Implementasyon para sa Enterprise
- **MCP-SECURITY-CONTROLS-2025.md**: Kumpletong overhaul na may enterprise-grade security framework
  - **9 Comprehensive Security Domains**: Pinalawak mula sa basic controls patungo sa detalyadong enterprise framework
    - Advanced Authentication & Authorization na may integrasyon sa Microsoft Entra ID
    - Token Security & Anti-Passthrough Controls na may komprehensibong beripikasyon
    - Session Security Controls na may pag-iwas sa hijacking
    - AI-Specific Security Controls na may pag-iwas sa prompt injection at tool poisoning
    - Confused Deputy Attack Prevention na may OAuth proxy security
    - Tool Execution Security na may sandboxing at isolation
    - Supply Chain Security Controls na may beripikasyon ng dependency
    - Monitoring & Detection Controls na may SIEM integration
    - Incident Response & Recovery na may automated capabilities
  - **Implementation Examples**: Idinagdag ang detalyadong YAML configuration blocks at mga halimbawa ng code
  - **Microsoft Solutions Integration**: Komprehensibong coverage ng Azure security services, GitHub Advanced Security, at enterprise identity management

#### Advanced Topics Security (05-AdvancedTopics/mcp-security/) - Implementasyon na Handa para sa Produksyon
- **README.md**: Kumpletong pagsulat para sa implementasyon ng seguridad sa enterprise
  - **Current Specification Alignment**: Na-update sa MCP Specification 2025-06-18 na may mandatory security requirements
  - **Enhanced Authentication**: Integrasyon ng Microsoft Entra ID na may komprehensibong mga halimbawa sa .NET at Java Spring Security
  - **AI Security Integration**: Implementasyon ng Microsoft Prompt Shields at Azure Content Safety na may detalyadong mga halimbawa sa Python
  - **Advanced Threat Mitigation**: Komprehensibong mga halimbawa ng implementasyon para sa
    - Confused Deputy Attack Prevention na may PKCE at beripikasyon ng user consent
    - Token Passthrough Prevention na may audience validation at secure token management
    - Session Hijacking Prevention na may cryptographic binding at behavioral analysis
  - **Enterprise Security Integration**: Azure Application Insights monitoring, threat detection pipelines, at supply chain security
  - **Implementation Checklist**: Malinaw na mandatory vs. recommended security controls na may benepisyo mula sa Microsoft security ecosystem

### Mga Pagpapahusay sa Kalidad ng Dokumentasyon at Pag-align sa Standards
- **Specification References**: Na-update ang lahat ng reference sa kasalukuyang MCP Specification 2025-06-18
- **Microsoft Security Ecosystem**: Pinahusay na gabay sa integrasyon sa kabuuan ng dokumentasyon ng seguridad
- **Practical Implementation**: Idinagdag ang detalyadong mga halimbawa ng code sa .NET, Java, at Python na may mga pattern para sa enterprise
- **Resource Organization**: Komprehensibong pagkakategorya ng opisyal na dokumentasyon, mga pamantayan sa seguridad, at mga gabay sa implementasyon
- **Visual Indicators**: Malinaw na pagmamarka ng mandatory requirements vs. recommended practices

#### Core Concepts (01-CoreConcepts/) - Kumpletong Modernisasyon
- **Protocol Version Update**: Na-update upang tumukoy sa kasalukuyang MCP Specification 2025-06-18 na may date-based versioning (YYYY-MM-DD format)
- **Architecture Refinement**: Pinahusay na mga deskripsyon ng Hosts, Clients, at Servers upang ipakita ang kasalukuyang mga pattern ng arkitektura ng MCP
  - Ang Hosts ay malinaw na tinukoy bilang mga AI application na nagko-coordinate ng maraming koneksyon ng MCP client
  - Ang Clients ay inilarawan bilang mga protocol connector na nagpapanatili ng one-to-one server relationships
  - Ang Servers ay pinahusay na may mga senaryo ng lokal vs. remote deployment
- **Primitive Restructuring**: Kumpletong overhaul ng server at client primitives
  - Server Primitives: Resources (data sources), Prompts (templates), Tools (executable functions) na may detalyadong mga paliwanag at halimbawa
  - Client Primitives: Sampling (LLM completions), Elicitation (user input), Logging (debugging/monitoring)
  - Na-update gamit ang kasalukuyang discovery (`*/list`), retrieval (`*/get`), at execution (`*/call`) method patterns
- **Protocol Architecture**: Ipinakilala ang two-layer architecture model
  - Data Layer: JSON-RPC 2.0 foundation na may lifecycle management at primitives
  - Transport Layer: STDIO (local) at Streamable HTTP na may SSE (remote) transport mechanisms
- **Security Framework**: Komprehensibong mga prinsipyo ng seguridad kabilang ang explicit user consent, data privacy protection, tool execution safety, at transport layer security
- **Communication Patterns**: Na-update ang mga protocol message upang ipakita ang initialization, discovery, execution, at notification flows
- **Code Examples**: Na-refresh ang mga multi-language examples (.NET, Java, Python, JavaScript) upang ipakita ang kasalukuyang MCP SDK patterns

#### Seguridad (02-Security/) - Komprehensibong Overhaul ng Seguridad  
- **Standards Alignment**: Kumpletong pag-align sa MCP Specification 2025-06-18 na mga kinakailangan sa seguridad
- **Authentication Evolution**: Na-dokumenta ang ebolusyon mula sa custom OAuth servers patungo sa external identity provider delegation (Microsoft Entra ID)
- **AI-Specific Threat Analysis**: Pinahusay na coverage ng modern AI attack vectors
  - Detalyadong mga senaryo ng prompt injection attack na may mga halimbawa sa totoong mundo
  - Mga mekanismo ng tool poisoning at "rug pull" attack patterns
  - Context window poisoning at model confusion attacks
- **Microsoft AI Security Solutions**: Komprehensibong coverage ng Microsoft security ecosystem
  - AI Prompt Shields na may advanced detection, spotlighting, at delimiter techniques
  - Mga pattern ng integrasyon ng Azure Content Safety
  - GitHub Advanced Security para sa proteksyon ng supply chain
- **Advanced Threat Mitigation**: Detalyadong mga kontrol sa seguridad para sa
  - Session hijacking na may mga senaryo ng MCP-specific attack at mga kinakailangan sa cryptographic session ID
  - Mga problema sa confused deputy sa MCP proxy scenarios na may explicit consent requirements
  - Mga kahinaan sa token passthrough na may mandatory validation controls
- **Supply Chain Security**: Pinalawak na coverage ng AI supply chain kabilang ang foundation models, embeddings services, context providers, at third-party APIs
- **Foundation Security**: Pinahusay na integrasyon sa mga pattern ng seguridad sa enterprise kabilang ang zero trust architecture at Microsoft security ecosystem
- **Resource Organization**: Nakategoryang komprehensibong mga link ng resource ayon sa uri (Official Docs, Standards, Research, Microsoft Solutions, Implementation Guides)

### Mga Pagpapahusay sa Kalidad ng Dokumentasyon
- **Structured Learning Objectives**: Pinahusay na mga layunin sa pag-aaral na may tiyak at actionable na mga resulta 
- **Cross-References**: Idinagdag ang mga link sa pagitan ng mga kaugnay na paksa ng seguridad at core concept
- **Current Information**: Na-update ang lahat ng mga reference sa petsa at mga link ng specification sa kasalukuyang mga pamantayan
- **Implementation Guidance**: Idinagdag ang tiyak at actionable na mga gabay sa implementasyon sa kabuuan ng parehong mga seksyon

## Hulyo 16, 2025

### README at Mga Pagpapahusay sa Navigation
- Ganap na muling idinisenyo ang navigation ng kurikulum sa README.md
- Pinalitan ang `<details>` tags ng mas accessible na table-based format
- Lumikha ng mga alternatibong opsyon sa layout sa bagong "alternative_layouts" folder
- Idinagdag ang mga halimbawa ng navigation na card-based, tabbed-style, at accordion-style
- Na-update ang seksyon ng repository structure upang isama ang lahat ng pinakabagong file
- Pinahusay ang seksyon na "How to Use This Curriculum" na may malinaw na mga rekomendasyon
- Na-update ang mga link ng MCP specification upang ituro sa tamang URLs
- Idinagdag ang seksyon ng Context Engineering (5.14) sa istruktura ng kurikulum

### Mga Update sa Study Guide
- Ganap na binago ang study guide upang i-align sa kasalukuyang istruktura ng repository
- Idinagdag ang mga bagong seksyon para sa MCP Clients at Tools, at Popular MCP Servers
- Na-update ang Visual Curriculum Map upang tumpak na ipakita ang lahat ng mga paksa
- Pinahusay ang mga deskripsyon ng Advanced Topics upang masakop ang lahat ng mga espesyal na lugar
- Na-update ang seksyon ng Case Studies upang ipakita ang aktwal na mga halimbawa
- Idinagdag ang komprehensibong changelog na ito

### Mga Kontribusyon ng Komunidad (06-CommunityContributions/)
- Idinagdag ang detalyadong impormasyon tungkol sa MCP servers para sa image generation
- Idinagdag ang komprehensibong seksyon sa paggamit ng Claude sa VSCode
- Idinagdag ang mga tagubilin sa setup at paggamit ng Cline terminal client
- Na-update ang seksyon ng MCP client upang isama ang lahat ng popular na opsyon ng client
- Pinahusay ang mga halimbawa ng kontribusyon na may mas tumpak na mga sample ng code

### Advanced Topics (05-AdvancedTopics/)
- Inorganisa ang lahat ng mga folder ng specialized topic na may konsistent na pangalan
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
- Lumikha ng mga unang halimbawa ng implementasyon ng server
- Idinagdag ang gabay sa pag-develop ng client
- Isinama ang mga tagubilin sa integrasyon ng LLM client
- Idinagdag ang dokumentasyon ng integrasyon ng VS Code
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
- Lumikha ng paunang istruktura ng study guide

## Abril 15, 2025

### Pagpaplano at Framework
- Paunang pagpaplano para sa MCP para sa Baguhan na kurikulum
- Tinukoy ang mga layunin sa pag-aaral at target na audience
- In-outline ang 10-seksyon na istruktura ng kurikulum
- Nag-develop ng conceptual framework para sa mga halimbawa at case studies
- Lumikha ng mga paunang prototype na halimbawa para sa mga pangunahing konsepto

---

**Paunawa**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagama't sinisikap naming maging tumpak, tandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o hindi pagkakatugma. Ang orihinal na dokumento sa kanyang katutubong wika ang dapat ituring na opisyal na sanggunian. Para sa mahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.