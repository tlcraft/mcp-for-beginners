<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:50:52+00:00",
  "source_file": "changelog.md",
  "language_code": "tl"
}
-->
# Changelog: MCP para sa Baguhan na Kurikulum

Ang dokumentong ito ay nagsisilbing talaan ng lahat ng mahahalagang pagbabago sa Model Context Protocol (MCP) para sa Baguhan na kurikulum. Ang mga pagbabago ay nakatala sa reverse chronological order (pinakabagong pagbabago muna).

## Setyembre 26, 2025

### Pagpapahusay ng Case Studies - Integrasyon ng GitHub MCP Registry

#### Case Studies (09-CaseStudy/) - Pokus sa Pagpapaunlad ng Ecosystem
- **README.md**: Malaking pagpapalawak na may komprehensibong case study ng GitHub MCP Registry
  - **GitHub MCP Registry Case Study**: Bagong komprehensibong case study na sinusuri ang paglulunsad ng GitHub MCP Registry noong Setyembre 2025
    - **Pagsusuri ng Problema**: Detalyadong pagsusuri sa mga hamon sa fragmented MCP server discovery at deployment
    - **Arkitektura ng Solusyon**: Diskarte ng GitHub sa centralized registry na may one-click na pag-install sa VS Code
    - **Epekto sa Negosyo**: Nasusukat na pagpapabuti sa onboarding ng developer at produktibidad
    - **Estratehikong Halaga**: Pokus sa modular na deployment ng agent at interoperability sa iba't ibang tool
    - **Pagpapaunlad ng Ecosystem**: Pagpoposisyon bilang pundasyon para sa integrasyon ng mga agentic system
  - **Pinahusay na Estruktura ng Case Study**: In-update ang lahat ng pitong case studies na may pare-parehong format at komprehensibong deskripsyon
    - Azure AI Travel Agents: Pokus sa multi-agent orchestration
    - Azure DevOps Integration: Pokus sa workflow automation
    - Real-Time Documentation Retrieval: Implementasyon ng Python console client
    - Interactive Study Plan Generator: Chainlit conversational web app
    - In-Editor Documentation: Integrasyon ng VS Code at GitHub Copilot
    - Azure API Management: Mga pattern ng integrasyon ng enterprise API
    - GitHub MCP Registry: Pagpapaunlad ng ecosystem at community platform
  - **Komprehensibong Konklusyon**: Muling isinulat ang seksyon ng konklusyon na nagha-highlight sa pitong case studies na sumasaklaw sa iba't ibang dimensyon ng implementasyon ng MCP
    - Integrasyon ng Enterprise, Multi-Agent Orchestration, Produktibidad ng Developer
    - Pagpapaunlad ng Ecosystem, Kategorya ng Aplikasyong Pang-edukasyon
    - Pinahusay na mga insight sa mga pattern ng arkitektura, estratehiya ng implementasyon, at pinakamahusay na mga kasanayan
    - Pokus sa MCP bilang isang mature, production-ready na protocol

#### Mga Update sa Study Guide (study_guide.md)
- **Visual Curriculum Map**: In-update ang mindmap upang isama ang GitHub MCP Registry sa seksyon ng Case Studies
- **Deskripsyon ng Case Studies**: Pinahusay mula sa generic na deskripsyon patungo sa detalyadong breakdown ng pitong komprehensibong case studies
- **Estruktura ng Repository**: In-update ang seksyon 10 upang ipakita ang komprehensibong coverage ng case study na may partikular na detalye ng implementasyon
- **Integrasyon ng Changelog**: Idinagdag ang entry noong Setyembre 26, 2025 na nagdodokumento ng karagdagan ng GitHub MCP Registry at mga pagpapahusay sa case study
- **Mga Update sa Petsa**: In-update ang timestamp ng footer upang ipakita ang pinakabagong rebisyon (Setyembre 26, 2025)

### Mga Pagpapahusay sa Kalidad ng Dokumentasyon
- **Pagpapahusay ng Konsistensya**: Standardisado ang format at estruktura ng case study sa lahat ng pitong halimbawa
- **Komprehensibong Coverage**: Ang mga case studies ay sumasaklaw na ngayon sa mga senaryo ng enterprise, produktibidad ng developer, at pagpapaunlad ng ecosystem
- **Estratehikong Pagpoposisyon**: Pinahusay na pokus sa MCP bilang pundasyon para sa deployment ng agentic system
- **Integrasyon ng Resource**: In-update ang karagdagang mga resource upang isama ang link ng GitHub MCP Registry

## Setyembre 15, 2025

### Pagpapalawak ng Advanced Topics - Custom Transports at Context Engineering

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - Bagong Gabay sa Advanced na Implementasyon
- **README.md**: Kumpletong gabay sa implementasyon para sa mga custom na mekanismo ng transport ng MCP
  - **Azure Event Grid Transport**: Komprehensibong implementasyon ng serverless event-driven transport
    - Mga halimbawa sa C#, TypeScript, at Python na may integrasyon ng Azure Functions
    - Mga pattern ng arkitektura na event-driven para sa scalable na solusyon ng MCP
    - Mga receiver ng webhook at push-based na paghawak ng mensahe
  - **Azure Event Hubs Transport**: Implementasyon ng high-throughput streaming transport
    - Kakayahan sa real-time streaming para sa mga senaryong mababa ang latency
    - Mga estratehiya sa partitioning at pamamahala ng checkpoint
    - Pag-batch ng mensahe at mga konsiderasyon sa pag-optimize ng performance
  - **Mga Pattern ng Integrasyon ng Enterprise**: Mga halimbawa ng arkitektura na handa para sa produksyon
    - Distributed MCP processing sa maraming Azure Functions
    - Hybrid na arkitektura ng transport na pinagsasama ang iba't ibang uri ng transport
    - Mga estratehiya sa durability ng mensahe, reliability, at paghawak ng error
  - **Seguridad at Monitoring**: Integrasyon ng Azure Key Vault at mga pattern ng observability
    - Authentication ng managed identity at least privilege access
    - Telemetry ng Application Insights at monitoring ng performance
    - Circuit breakers at mga pattern ng fault tolerance
  - **Mga Framework ng Pagsubok**: Komprehensibong estratehiya sa pagsubok para sa mga custom na transport
    - Unit testing gamit ang test doubles at mocking frameworks
    - Integration testing gamit ang Azure Test Containers
    - Mga konsiderasyon sa performance at load testing

#### Context Engineering (05-AdvancedTopics/mcp-contextengineering/) - Umuusbong na Disiplina ng AI
- **README.md**: Komprehensibong eksplorasyon ng context engineering bilang umuusbong na larangan
  - **Mga Pangunahing Prinsipyo**: Kumpletong context sharing, action decision awareness, at context window management
  - **Pagkakahanay sa MCP Protocol**: Paano tinutugunan ng disenyo ng MCP ang mga hamon sa context engineering
    - Mga limitasyon ng context window at mga estratehiya sa progressive loading
    - Pagtukoy ng kaugnayan at dynamic na pagkuha ng context
    - Multi-modal na paghawak ng context at mga konsiderasyon sa seguridad
  - **Mga Diskarte sa Implementasyon**: Single-threaded vs. multi-agent na arkitektura
    - Mga teknik sa context chunking at prioritization
    - Progressive context loading at mga estratehiya sa compression
    - Layered na mga diskarte sa context at pag-optimize ng retrieval
  - **Framework ng Pagsukat**: Umuusbong na mga sukatan para sa pagsusuri ng pagiging epektibo ng context
    - Mga konsiderasyon sa input efficiency, performance, quality, at user experience
    - Mga eksperimento sa pag-optimize ng context
    - Pagsusuri ng pagkabigo at mga metodolohiya ng pagpapabuti

#### Mga Update sa Curriculum Navigation (README.md)
- **Pinahusay na Estruktura ng Module**: In-update ang talahanayan ng kurikulum upang isama ang mga bagong advanced topics
  - Idinagdag ang Context Engineering (5.14) at Custom Transport (5.15) na mga entry
  - Konsistent na format at mga navigation link sa lahat ng module
  - In-update ang mga deskripsyon upang ipakita ang kasalukuyang saklaw ng nilalaman

### Mga Pagpapahusay sa Estruktura ng Directory
- **Standardisasyon ng Pangalan**: Pinalitan ang pangalan ng "mcp transport" sa "mcp-transport" para sa konsistensya sa iba pang advanced topic folders
- **Organisasyon ng Nilalaman**: Ang lahat ng 05-AdvancedTopics folders ay sumusunod na ngayon sa konsistent na pattern ng pangalan (mcp-[topic])

### Mga Pagpapahusay sa Kalidad ng Dokumentasyon
- **Pagkakahanay sa MCP Specification**: Ang lahat ng bagong nilalaman ay tumutukoy sa kasalukuyang MCP Specification 2025-06-18
- **Mga Halimbawa sa Multi-Language**: Komprehensibong mga halimbawa ng code sa C#, TypeScript, at Python
- **Pokus sa Enterprise**: Mga pattern na handa para sa produksyon at integrasyon ng Azure cloud sa kabuuan
- **Visual na Dokumentasyon**: Mga diagram ng Mermaid para sa arkitektura at visualisasyon ng daloy

## Agosto 18, 2025

### Komprehensibong Update sa Dokumentasyon - Mga Pamantayan ng MCP 2025-06-18

#### Mga Pinakamahusay na Kasanayan sa Seguridad ng MCP (02-Security/) - Kumpletong Modernisasyon
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Kumpletong muling pagsulat na naka-align sa MCP Specification 2025-06-18
  - **Mga Mandatoryong Kinakailangan**: Idinagdag ang mga explicit na MUST/MUST NOT na kinakailangan mula sa opisyal na spesipikasyon na may malinaw na visual na indikasyon
  - **12 Core Security Practices**: Muling inayos mula sa 15-item na listahan patungo sa komprehensibong mga domain ng seguridad
    - Seguridad ng Token at Authentication na may integrasyon ng external identity provider
    - Pamamahala ng Session at Seguridad ng Transport na may mga kinakailangan sa cryptographic
    - Proteksyon sa AI-Specific Threat na may integrasyon ng Microsoft Prompt Shields
    - Access Control at Permissions na may prinsipyo ng least privilege
    - Kaligtasan ng Nilalaman at Monitoring na may integrasyon ng Azure Content Safety
    - Seguridad ng Supply Chain na may komprehensibong beripikasyon ng mga component
    - Seguridad ng OAuth at Pag-iwas sa Confused Deputy na may implementasyon ng PKCE
    - Incident Response at Recovery na may automated na kakayahan
    - Pagsunod at Pamamahala na may regulasyon na pagkakahanay
    - Advanced Security Controls na may zero trust architecture
    - Integrasyon ng Microsoft Security Ecosystem na may komprehensibong solusyon
    - Patuloy na Ebolusyon ng Seguridad na may adaptive na mga kasanayan
  - **Microsoft Security Solutions**: Pinahusay na gabay sa integrasyon para sa Prompt Shields, Azure Content Safety, Entra ID, at GitHub Advanced Security
  - **Mga Resource sa Implementasyon**: Kategoryadong komprehensibong mga link ng resource ayon sa Opisyal na Dokumentasyon ng MCP, Microsoft Security Solutions, Mga Pamantayan sa Seguridad, at Mga Gabay sa Implementasyon

#### Advanced Security Controls (02-Security/) - Implementasyon ng Enterprise
- **MCP-SECURITY-CONTROLS-2025.md**: Kumpletong overhaul na may enterprise-grade na framework ng seguridad
  - **9 Komprehensibong Domain ng Seguridad**: Pinalawak mula sa basic na mga control patungo sa detalyadong enterprise framework
    - Advanced Authentication at Authorization na may integrasyon ng Microsoft Entra ID
    - Seguridad ng Token at Anti-Passthrough Controls na may komprehensibong beripikasyon
    - Mga Control sa Seguridad ng Session na may pag-iwas sa hijacking
    - AI-Specific Security Controls na may pag-iwas sa prompt injection at tool poisoning
    - Pag-iwas sa Confused Deputy Attack na may seguridad ng OAuth proxy
    - Seguridad ng Tool Execution na may sandboxing at isolation
    - Mga Control sa Seguridad ng Supply Chain na may beripikasyon ng dependency
    - Monitoring at Detection Controls na may integrasyon ng SIEM
    - Incident Response at Recovery na may automated na kakayahan
  - **Mga Halimbawa ng Implementasyon**: Idinagdag ang detalyadong YAML configuration blocks at mga halimbawa ng code
  - **Integrasyon ng Microsoft Solutions**: Komprehensibong coverage ng mga serbisyo ng seguridad ng Azure, GitHub Advanced Security, at pamamahala ng enterprise identity

#### Advanced Topics Security (05-AdvancedTopics/mcp-security/) - Implementasyon na Handa para sa Produksyon
- **README.md**: Kumpletong muling pagsulat para sa implementasyon ng seguridad ng enterprise
  - **Pagkakahanay sa Kasalukuyang Spesipikasyon**: In-update sa MCP Specification 2025-06-18 na may mandatoryong mga kinakailangan sa seguridad
  - **Pinahusay na Authentication**: Integrasyon ng Microsoft Entra ID na may komprehensibong mga halimbawa sa .NET at Java Spring Security
  - **Integrasyon ng AI Security**: Implementasyon ng Microsoft Prompt Shields at Azure Content Safety na may detalyadong mga halimbawa sa Python
  - **Advanced Threat Mitigation**: Komprehensibong mga halimbawa ng implementasyon para sa
    - Pag-iwas sa Confused Deputy Attack na may PKCE at beripikasyon ng user consent
    - Pag-iwas sa Token Passthrough na may audience validation at secure na pamamahala ng token
    - Pag-iwas sa Session Hijacking na may cryptographic binding at behavioral analysis
  - **Integrasyon ng Enterprise Security**: Monitoring ng Azure Application Insights, mga pipeline ng threat detection, at seguridad ng supply chain
  - **Checklist ng Implementasyon**: Malinaw na mandatory vs. recommended na mga control sa seguridad na may benepisyo ng Microsoft security ecosystem

### Kalidad ng Dokumentasyon at Pagkakahanay sa Pamantayan
- **Mga Reference sa Spesipikasyon**: In-update ang lahat ng reference sa kasalukuyang MCP Specification 2025-06-18
- **Microsoft Security Ecosystem**: Pinahusay na gabay sa integrasyon sa kabuuan ng dokumentasyon ng seguridad
- **Praktikal na Implementasyon**: Idinagdag ang detalyadong mga halimbawa ng code sa .NET, Java, at Python na may mga pattern ng enterprise
- **Organisasyon ng Resource**: Komprehensibong kategorya ng opisyal na dokumentasyon, mga pamantayan sa seguridad, at mga gabay sa implementasyon
- **Visual na Indikasyon**: Malinaw na pagmamarka ng mga mandatoryong kinakailangan vs. recommended na mga kasanayan

#### Mga Pangunahing Konsepto (01-CoreConcepts/) - Kumpletong Modernisasyon
- **Update sa Bersyon ng Protocol**: In-update upang tumukoy sa kasalukuyang MCP Specification 2025-06-18 na may date-based na versioning (YYYY-MM-DD format)
- **Pagpapahusay ng Arkitektura**: Pinahusay na mga deskripsyon ng Hosts, Clients, at Servers upang ipakita ang kasalukuyang mga pattern ng arkitektura ng MCP
  - Ang Hosts ay malinaw na tinukoy bilang mga AI application na nagko-coordinate ng maraming koneksyon ng MCP client
  - Ang Clients ay inilarawan bilang mga protocol connector na nagpapanatili ng one-to-one na relasyon sa server
  - Ang Servers ay pinahusay na may mga senaryo ng lokal vs. remote na deployment
- **Restructuring ng Primitives**: Kumpletong overhaul ng server at client primitives
  - Server Primitives: Resources (mga data source), Prompts (mga template), Tools (mga executable function) na may detalyadong paliwanag at mga halimbawa
  - Client Primitives: Sampling (LLM completions), Elicitation (user input), Logging (debugging/monitoring)
  - In-update na may kasalukuyang mga method pattern ng discovery (`*/list`), retrieval (`*/get`), at execution (`*/call`)
- **Arkitektura ng Protocol**: Ipinakilala ang two-layer na modelo ng arkitektura
  - Data Layer: JSON-RPC 2.0 foundation na may lifecycle management at primitives
  - Transport Layer: STDIO (lokal) at Streamable HTTP na may SSE (remote) na mga mekanismo ng transport
- **Framework ng Seguridad**: Komprehensibong mga prinsipyo ng seguridad kabilang ang explicit na user consent, proteksyon sa privacy ng data, kaligtasan ng tool execution, at seguridad ng transport layer
- **Mga Pattern ng Komunikasyon**: In-update ang mga protocol message upang ipakita ang initialization, discovery, execution, at notification flows
- **Mga Halimbawa ng Code**: In-refresh ang mga halimbawa sa multi-language (.NET, Java, Python, JavaScript) upang ipakita ang kasalukuyang mga pattern ng MCP SDK

#### Seguridad (02-Security/) - Komprehensibong Overhaul ng Seguridad  
- **Pagkakahanay sa Pamantayan**: Buong pagkakahanay sa mga kinakailangan sa seguridad ng MCP Specification 2025-06-18
- **Ebolusyon ng Authentication**: Na-dokumento ang ebolusyon mula sa custom OAuth servers patungo sa external identity provider delegation (Microsoft Entra ID)
- **Pagsusuri ng AI-Specific Threat**: Pinahusay na coverage ng modernong mga vector ng AI attack
  - Detalyadong mga senaryo ng prompt injection attack na may mga halimbawa sa totoong mundo
  - Mga mekanismo ng tool poisoning at mga pattern ng "rug pull" attack
  - Context window poisoning at mga model confusion attack
- **Microsoft AI Security Solutions**: Komprehensibong coverage ng Microsoft security ecosystem
  - AI Prompt Shields na may advanced detection, spotlighting, at delimiter techniques
  - Mga pattern ng integrasyon ng Azure Content Safety
  - GitHub Advanced Security para sa proteksyon ng supply chain
- **Advanced Threat Mitigation**: Detalyadong mga control sa seguridad para sa
  - Session hijacking na may mga senaryo ng MCP-specific attack at mga kinakailangan sa cryptographic session ID
  - Mga problema sa Confused Deputy sa mga senaryo ng MCP proxy na may mga kinakailangan sa explicit consent
  - Mga kahinaan sa Token Passthrough na may mandatoryong mga control sa beripikasyon
- **Seguridad ng Supply Chain**: Pinalawak na coverage ng AI supply chain kabilang ang mga foundation models, embeddings services, context providers, at third-party APIs
- **Seguridad ng Pundasyon**: Pinahusay na integrasyon sa mga pattern ng seguridad ng enterprise kabilang ang zero trust architecture at Microsoft security ecosystem
- **Organisasyon ng Resource**: K
- Pinalitan ang mga tag na `<details>` ng mas naa-access na format na nakabase sa talahanayan
- Gumawa ng mga alternatibong layout sa bagong folder na "alternative_layouts"
- Nagdagdag ng mga halimbawa ng navigation na nakabase sa card, tabbed-style, at accordion-style
- In-update ang seksyon ng repository structure upang isama ang lahat ng pinakabagong file
- Pinahusay ang seksyon na "Paano Gamitin ang Curriculum na Ito" na may malinaw na rekomendasyon
- In-update ang mga link ng MCP specification upang ituro sa tamang mga URL
- Nagdagdag ng seksyon ng Context Engineering (5.14) sa istruktura ng curriculum

### Mga Update sa Study Guide
- Ganap na binago ang study guide upang umayon sa kasalukuyang istruktura ng repository
- Nagdagdag ng mga bagong seksyon para sa MCP Clients and Tools, at Popular MCP Servers
- In-update ang Visual Curriculum Map upang tumpak na maipakita ang lahat ng paksa
- Pinahusay ang mga paglalarawan ng Advanced Topics upang masakop ang lahat ng specialized na lugar
- In-update ang seksyon ng Case Studies upang ipakita ang aktwal na mga halimbawa
- Nagdagdag ng komprehensibong changelog na ito

### Mga Ambag ng Komunidad (06-CommunityContributions/)
- Nagdagdag ng detalyadong impormasyon tungkol sa MCP servers para sa image generation
- Nagdagdag ng komprehensibong seksyon sa paggamit ng Claude sa VSCode
- Nagdagdag ng mga tagubilin sa setup at paggamit ng Cline terminal client
- In-update ang seksyon ng MCP client upang isama ang lahat ng popular na client options
- Pinahusay ang mga halimbawa ng ambag na may mas tumpak na code samples

### Advanced Topics (05-AdvancedTopics/)
- Inayos ang lahat ng specialized na folder ng paksa na may pare-parehong pangalan
- Nagdagdag ng mga materyales at halimbawa ng context engineering
- Nagdagdag ng dokumentasyon sa Foundry agent integration
- Pinahusay ang dokumentasyon ng Entra ID security integration

## Hunyo 11, 2025

### Unang Paglikha
- Inilabas ang unang bersyon ng MCP para sa Beginners curriculum
- Gumawa ng pangunahing istruktura para sa lahat ng 10 pangunahing seksyon
- Nagpatupad ng Visual Curriculum Map para sa navigation
- Nagdagdag ng mga paunang sample na proyekto sa iba't ibang programming languages

### Getting Started (03-GettingStarted/)
- Gumawa ng mga unang halimbawa ng server implementation
- Nagdagdag ng gabay sa pag-develop ng client
- Isinama ang mga tagubilin sa LLM client integration
- Nagdagdag ng dokumentasyon sa VS Code integration
- Nagpatupad ng mga halimbawa ng Server-Sent Events (SSE) server

### Core Concepts (01-CoreConcepts/)
- Nagdagdag ng detalyadong paliwanag ng client-server architecture
- Gumawa ng dokumentasyon sa mga pangunahing bahagi ng protocol
- Nagdokumento ng mga messaging pattern sa MCP

## Mayo 23, 2025

### Istruktura ng Repository
- Inisyalisa ang repository na may pangunahing istruktura ng folder
- Gumawa ng mga README file para sa bawat pangunahing seksyon
- Nag-set up ng translation infrastructure
- Nagdagdag ng mga image asset at diagram

### Dokumentasyon
- Gumawa ng paunang README.md na may overview ng curriculum
- Nagdagdag ng CODE_OF_CONDUCT.md at SECURITY.md
- Nag-set up ng SUPPORT.md na may gabay para sa paghingi ng tulong
- Gumawa ng paunang istruktura ng study guide

## Abril 15, 2025

### Pagpaplano at Framework
- Paunang pagpaplano para sa MCP para sa Beginners curriculum
- Tinukoy ang mga layunin sa pag-aaral at target na audience
- In-outline ang 10-seksyon na istruktura ng curriculum
- Bumuo ng conceptual framework para sa mga halimbawa at case studies
- Gumawa ng mga paunang prototype na halimbawa para sa mga pangunahing konsepto

---

