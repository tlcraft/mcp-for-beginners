<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-19T14:04:50+00:00",
  "source_file": "changelog.md",
  "language_code": "en"
}
-->
# Changelog: MCP for Beginners Curriculum

This document records all significant updates made to the Model Context Protocol (MCP) for Beginners curriculum. Changes are listed in reverse chronological order (most recent first).

## August 18, 2025

### Comprehensive Documentation Update - MCP 2025-06-18 Standards

#### MCP Security Best Practices (02-Security/) - Complete Overhaul
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Fully rewritten to align with MCP Specification 2025-06-18
  - **Mandatory Requirements**: Added clear MUST/MUST NOT requirements from the official specification with visual indicators
  - **12 Core Security Practices**: Restructured from a 15-item list into broader security domains
    - Token Security & Authentication with external identity provider integration
    - Session Management & Transport Security with cryptographic standards
    - AI-Specific Threat Protection with Microsoft Prompt Shields integration
    - Access Control & Permissions based on the principle of least privilege
    - Content Safety & Monitoring with Azure Content Safety integration
    - Supply Chain Security with thorough component verification
    - OAuth Security & Confused Deputy Prevention using PKCE
    - Incident Response & Recovery with automated capabilities
    - Compliance & Governance aligned with regulations
    - Advanced Security Controls using zero trust architecture
    - Microsoft Security Ecosystem Integration with comprehensive solutions
    - Continuous Security Evolution with adaptive practices
  - **Microsoft Security Solutions**: Enhanced guidance for integrating Prompt Shields, Azure Content Safety, Entra ID, and GitHub Advanced Security
  - **Implementation Resources**: Organized resource links into categories: Official MCP Documentation, Microsoft Security Solutions, Security Standards, and Implementation Guides

#### Advanced Security Controls (02-Security/) - Enterprise-Level Implementation
- **MCP-SECURITY-CONTROLS-2025.md**: Completely revamped with an enterprise-grade security framework
  - **9 Comprehensive Security Domains**: Expanded from basic controls to a detailed enterprise framework
    - Advanced Authentication & Authorization with Microsoft Entra ID integration
    - Token Security & Anti-Passthrough Controls with robust validation
    - Session Security Controls to prevent hijacking
    - AI-Specific Security Controls to mitigate prompt injection and tool poisoning
    - Confused Deputy Attack Prevention with OAuth proxy security
    - Tool Execution Security using sandboxing and isolation
    - Supply Chain Security Controls with dependency verification
    - Monitoring & Detection Controls with SIEM integration
    - Incident Response & Recovery with automated capabilities
  - **Implementation Examples**: Added detailed YAML configuration blocks and code samples
  - **Microsoft Solutions Integration**: Comprehensive coverage of Azure security services, GitHub Advanced Security, and enterprise identity management

#### Advanced Topics Security (05-AdvancedTopics/mcp-security/) - Production-Ready Implementation
- **README.md**: Fully rewritten for enterprise security implementation
  - **Current Specification Alignment**: Updated to MCP Specification 2025-06-18 with mandatory security requirements
  - **Enhanced Authentication**: Microsoft Entra ID integration with detailed .NET and Java Spring Security examples
  - **AI Security Integration**: Implementation of Microsoft Prompt Shields and Azure Content Safety with detailed Python examples
  - **Advanced Threat Mitigation**: Comprehensive implementation examples for:
    - Confused Deputy Attack Prevention using PKCE and user consent validation
    - Token Passthrough Prevention with audience validation and secure token management
    - Session Hijacking Prevention with cryptographic binding and behavioral analysis
  - **Enterprise Security Integration**: Azure Application Insights monitoring, threat detection pipelines, and supply chain security
  - **Implementation Checklist**: Clear distinction between mandatory and recommended security controls, highlighting Microsoft security ecosystem benefits

### Documentation Quality & Standards Alignment
- **Specification References**: Updated all references to the latest MCP Specification 2025-06-18
- **Microsoft Security Ecosystem**: Enhanced integration guidance across all security documentation
- **Practical Implementation**: Added detailed code examples in .NET, Java, and Python with enterprise patterns
- **Resource Organization**: Categorized official documentation, security standards, and implementation guides
- **Visual Indicators**: Clearly marked mandatory requirements vs. recommended practices

#### Core Concepts (01-CoreConcepts/) - Complete Overhaul
- **Protocol Version Update**: Updated to reference the latest MCP Specification 2025-06-18 with date-based versioning (YYYY-MM-DD format)
- **Architecture Refinement**: Improved descriptions of Hosts, Clients, and Servers to reflect current MCP architecture patterns
  - Hosts: Defined as AI applications coordinating multiple MCP client connections
  - Clients: Described as protocol connectors maintaining one-to-one server relationships
  - Servers: Enhanced with local vs. remote deployment scenarios
- **Primitive Restructuring**: Complete overhaul of server and client primitives
  - Server Primitives: Resources (data sources), Prompts (templates), Tools (executable functions) with detailed explanations and examples
  - Client Primitives: Sampling (LLM completions), Elicitation (user input), Logging (debugging/monitoring)
  - Updated with current discovery (`*/list`), retrieval (`*/get`), and execution (`*/call`) method patterns
- **Protocol Architecture**: Introduced a two-layer architecture model
  - Data Layer: JSON-RPC 2.0 foundation with lifecycle management and primitives
  - Transport Layer: STDIO (local) and Streamable HTTP with SSE (remote) transport mechanisms
- **Security Framework**: Comprehensive security principles including explicit user consent, data privacy protection, tool execution safety, and transport layer security
- **Communication Patterns**: Updated protocol messages to illustrate initialization, discovery, execution, and notification flows
- **Code Examples**: Refreshed multi-language examples (.NET, Java, Python, JavaScript) to reflect current MCP SDK patterns

#### Security (02-Security/) - Comprehensive Overhaul  
- **Standards Alignment**: Fully aligned with MCP Specification 2025-06-18 security requirements
- **Authentication Evolution**: Documented the transition from custom OAuth servers to external identity provider delegation (Microsoft Entra ID)
- **AI-Specific Threat Analysis**: Expanded coverage of modern AI attack vectors
  - Detailed prompt injection attack scenarios with real-world examples
  - Tool poisoning mechanisms and "rug pull" attack patterns
  - Context window poisoning and model confusion attacks
- **Microsoft AI Security Solutions**: Comprehensive coverage of Microsoft security ecosystem
  - AI Prompt Shields with advanced detection, spotlighting, and delimiter techniques
  - Azure Content Safety integration patterns
  - GitHub Advanced Security for supply chain protection
- **Advanced Threat Mitigation**: Detailed security controls for:
  - Session hijacking with MCP-specific attack scenarios and cryptographic session ID requirements
  - Confused deputy problems in MCP proxy scenarios with explicit consent requirements
  - Token passthrough vulnerabilities with mandatory validation controls
- **Supply Chain Security**: Expanded AI supply chain coverage, including foundation models, embedding services, context providers, and third-party APIs
- **Foundation Security**: Enhanced integration with enterprise security patterns, including zero trust architecture and Microsoft security ecosystem
- **Resource Organization**: Categorized comprehensive resource links by type (Official Docs, Standards, Research, Microsoft Solutions, Implementation Guides)

### Documentation Quality Improvements
- **Structured Learning Objectives**: Enhanced learning objectives with specific, actionable outcomes 
- **Cross-References**: Added links between related security and core concept topics
- **Current Information**: Updated all date references and specification links to current standards
- **Implementation Guidance**: Added specific, actionable implementation guidelines throughout both sections

## July 16, 2025

### README and Navigation Improvements
- Completely redesigned the curriculum navigation in README.md
- Replaced `<details>` tags with a more accessible table-based format
- Created alternative layout options in the new "alternative_layouts" folder
- Added card-based, tabbed-style, and accordion-style navigation examples
- Updated the repository structure section to include all the latest files
- Enhanced the "How to Use This Curriculum" section with clear recommendations
- Updated MCP specification links to point to correct URLs
- Added a Context Engineering section (5.14) to the curriculum structure

### Study Guide Updates
- Completely revised the study guide to align with the current repository structure
- Added new sections for MCP Clients and Tools, and Popular MCP Servers
- Updated the Visual Curriculum Map to accurately reflect all topics
- Enhanced descriptions of Advanced Topics to cover all specialized areas
- Updated the Case Studies section to reflect real-world examples
- Added this comprehensive changelog

### Community Contributions (06-CommunityContributions/)
- Added detailed information about MCP servers for image generation
- Added a comprehensive section on using Claude in VSCode
- Added Cline terminal client setup and usage instructions
- Updated the MCP client section to include all popular client options
- Enhanced contribution examples with more accurate code samples

### Advanced Topics (05-AdvancedTopics/)
- Organized all specialized topic folders with consistent naming
- Added context engineering materials and examples
- Added Foundry agent integration documentation
- Enhanced Entra ID security integration documentation

## June 11, 2025

### Initial Creation
- Released the first version of the MCP for Beginners curriculum
- Created the basic structure for all 10 main sections
- Implemented a Visual Curriculum Map for navigation
- Added initial sample projects in multiple programming languages

### Getting Started (03-GettingStarted/)
- Created the first server implementation examples
- Added client development guidance
- Included LLM client integration instructions
- Added VS Code integration documentation
- Implemented Server-Sent Events (SSE) server examples

### Core Concepts (01-CoreConcepts/)
- Added detailed explanations of client-server architecture
- Created documentation on key protocol components
- Documented messaging patterns in MCP

## May 23, 2025

### Repository Structure
- Initialized the repository with a basic folder structure
- Created README files for each major section
- Set up translation infrastructure
- Added image assets and diagrams

### Documentation
- Created the initial README.md with a curriculum overview
- Added CODE_OF_CONDUCT.md and SECURITY.md
- Set up SUPPORT.md with guidance for getting help
- Created a preliminary study guide structure

## April 15, 2025

### Planning and Framework
- Initial planning for the MCP for Beginners curriculum
- Defined learning objectives and target audience
- Outlined a 10-section structure for the curriculum
- Developed a conceptual framework for examples and case studies
- Created initial prototype examples for key concepts

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we aim for accuracy, please note that automated translations may include errors or inaccuracies. The original document in its native language should be regarded as the authoritative source. For critical information, professional human translation is advised. We are not responsible for any misunderstandings or misinterpretations resulting from the use of this translation.