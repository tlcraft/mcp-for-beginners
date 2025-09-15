<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T21:49:23+00:00",
  "source_file": "changelog.md",
  "language_code": "en"
}
-->
# Changelog: MCP for Beginners Curriculum

This document serves as a record of all significant updates made to the Model Context Protocol (MCP) for Beginners curriculum. Changes are listed in reverse chronological order (most recent changes first).

## September 15, 2025

### Expansion of Advanced Topics - Custom Transports & Context Engineering

#### MCP Custom Transports (05-AdvancedTopics/mcp-transport/) - New Advanced Implementation Guide
- **README.md**: Complete guide for implementing custom MCP transport mechanisms
  - **Azure Event Grid Transport**: Detailed serverless event-driven transport implementation
    - Examples in C#, TypeScript, and Python with Azure Functions integration
    - Event-driven architecture patterns for scalable MCP solutions
    - Webhook receivers and push-based message handling
  - **Azure Event Hubs Transport**: High-throughput streaming transport implementation
    - Real-time streaming capabilities for low-latency scenarios
    - Partitioning strategies and checkpoint management
    - Message batching and performance optimization
  - **Enterprise Integration Patterns**: Production-ready architectural examples
    - Distributed MCP processing across multiple Azure Functions
    - Hybrid transport architectures combining various transport types
    - Strategies for message durability, reliability, and error handling
  - **Security & Monitoring**: Integration with Azure Key Vault and observability patterns
    - Managed identity authentication and least privilege access
    - Application Insights telemetry and performance monitoring
    - Circuit breakers and fault tolerance patterns
  - **Testing Frameworks**: Comprehensive testing strategies for custom transports
    - Unit testing with test doubles and mocking frameworks
    - Integration testing using Azure Test Containers
    - Considerations for performance and load testing

#### Context Engineering (05-AdvancedTopics/mcp-contextengineering/) - Emerging AI Discipline
- **README.md**: In-depth exploration of context engineering as a growing field
  - **Core Principles**: Complete context sharing, action decision awareness, and context window management
  - **MCP Protocol Alignment**: How MCP design addresses context engineering challenges
    - Strategies for overcoming context window limitations and progressive loading
    - Relevance determination and dynamic context retrieval
    - Handling multi-modal context and addressing security concerns
  - **Implementation Approaches**: Single-threaded vs. multi-agent architectures
    - Techniques for context chunking and prioritization
    - Progressive context loading and compression strategies
    - Layered context approaches and retrieval optimization
  - **Measurement Framework**: Emerging metrics for evaluating context effectiveness
    - Input efficiency, performance, quality, and user experience considerations
    - Experimental methods for optimizing context
    - Failure analysis and improvement strategies

#### Curriculum Navigation Updates (README.md)
- **Enhanced Module Structure**: Updated curriculum table to include new advanced topics
  - Added Context Engineering (5.14) and Custom Transport (5.15) entries
  - Consistent formatting and navigation links across all modules
  - Updated descriptions to reflect the current scope of content

### Directory Structure Improvements
- **Naming Standardization**: Renamed "mcp transport" to "mcp-transport" for consistency with other advanced topic folders
- **Content Organization**: All 05-AdvancedTopics folders now follow a consistent naming pattern (mcp-[topic])

### Documentation Quality Enhancements
- **MCP Specification Alignment**: All new content references the current MCP Specification 2025-06-18
- **Multi-Language Examples**: Comprehensive code examples in C#, TypeScript, and Python
- **Enterprise Focus**: Production-ready patterns and Azure cloud integration throughout
- **Visual Documentation**: Mermaid diagrams for architecture and flow visualization

## August 18, 2025

### Comprehensive Documentation Update - MCP 2025-06-18 Standards

#### MCP Security Best Practices (02-Security/) - Complete Modernization
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Fully rewritten to align with MCP Specification 2025-06-18
  - **Mandatory Requirements**: Added explicit MUST/MUST NOT requirements from the official specification with clear visual indicators
  - **12 Core Security Practices**: Restructured from a 15-item list into comprehensive security domains
    - Token Security & Authentication with external identity provider integration
    - Session Management & Transport Security with cryptographic requirements
    - AI-Specific Threat Protection with Microsoft Prompt Shields integration
    - Access Control & Permissions with the principle of least privilege
    - Content Safety & Monitoring with Azure Content Safety integration
    - Supply Chain Security with thorough component verification
    - OAuth Security & Confused Deputy Prevention with PKCE implementation
    - Incident Response & Recovery with automated capabilities
    - Compliance & Governance with regulatory alignment
    - Advanced Security Controls with zero trust architecture
    - Microsoft Security Ecosystem Integration with comprehensive solutions
    - Continuous Security Evolution with adaptive practices
  - **Microsoft Security Solutions**: Enhanced integration guidance for Prompt Shields, Azure Content Safety, Entra ID, and GitHub Advanced Security
  - **Implementation Resources**: Categorized resource links by Official MCP Documentation, Microsoft Security Solutions, Security Standards, and Implementation Guides

#### Advanced Security Controls (02-Security/) - Enterprise Implementation
- **MCP-SECURITY-CONTROLS-2025.md**: Complete overhaul with an enterprise-grade security framework
  - **9 Comprehensive Security Domains**: Expanded from basic controls to a detailed enterprise framework
    - Advanced Authentication & Authorization with Microsoft Entra ID integration
    - Token Security & Anti-Passthrough Controls with comprehensive validation
    - Session Security Controls with hijacking prevention
    - AI-Specific Security Controls with prompt injection and tool poisoning prevention
    - Confused Deputy Attack Prevention with OAuth proxy security
    - Tool Execution Security with sandboxing and isolation
    - Supply Chain Security Controls with dependency verification
    - Monitoring & Detection Controls with SIEM integration
    - Incident Response & Recovery with automated capabilities
  - **Implementation Examples**: Added detailed YAML configuration blocks and code examples
  - **Microsoft Solutions Integration**: Comprehensive coverage of Azure security services, GitHub Advanced Security, and enterprise identity management

#### Advanced Topics Security (05-AdvancedTopics/mcp-security/) - Production-Ready Implementation
- **README.md**: Fully rewritten for enterprise security implementation
  - **Current Specification Alignment**: Updated to MCP Specification 2025-06-18 with mandatory security requirements
  - **Enhanced Authentication**: Microsoft Entra ID integration with detailed .NET and Java Spring Security examples
  - **AI Security Integration**: Microsoft Prompt Shields and Azure Content Safety implementation with detailed Python examples
  - **Advanced Threat Mitigation**: Comprehensive implementation examples for
    - Confused Deputy Attack Prevention with PKCE and user consent validation
    - Token Passthrough Prevention with audience validation and secure token management
    - Session Hijacking Prevention with cryptographic binding and behavioral analysis
  - **Enterprise Security Integration**: Azure Application Insights monitoring, threat detection pipelines, and supply chain security
  - **Implementation Checklist**: Clear mandatory vs. recommended security controls with Microsoft security ecosystem benefits

### Documentation Quality & Standards Alignment
- **Specification References**: Updated all references to the current MCP Specification 2025-06-18
- **Microsoft Security Ecosystem**: Enhanced integration guidance throughout all security documentation
- **Practical Implementation**: Added detailed code examples in .NET, Java, and Python with enterprise patterns
- **Resource Organization**: Comprehensive categorization of official documentation, security standards, and implementation guides
- **Visual Indicators**: Clear marking of mandatory requirements vs. recommended practices

#### Core Concepts (01-CoreConcepts/) - Complete Modernization
- **Protocol Version Update**: Updated to reference the current MCP Specification 2025-06-18 with date-based versioning (YYYY-MM-DD format)
- **Architecture Refinement**: Enhanced descriptions of Hosts, Clients, and Servers to reflect current MCP architecture patterns
  - Hosts now clearly defined as AI applications coordinating multiple MCP client connections
  - Clients described as protocol connectors maintaining one-to-one server relationships
  - Servers enhanced with local vs. remote deployment scenarios
- **Primitive Restructuring**: Complete overhaul of server and client primitives
  - Server Primitives: Resources (data sources), Prompts (templates), Tools (executable functions) with detailed explanations and examples
  - Client Primitives: Sampling (LLM completions), Elicitation (user input), Logging (debugging/monitoring)
  - Updated with current discovery (`*/list`), retrieval (`*/get`), and execution (`*/call`) method patterns
- **Protocol Architecture**: Introduced two-layer architecture model
  - Data Layer: JSON-RPC 2.0 foundation with lifecycle management and primitives
  - Transport Layer: STDIO (local) and Streamable HTTP with SSE (remote) transport mechanisms
- **Security Framework**: Comprehensive security principles including explicit user consent, data privacy protection, tool execution safety, and transport layer security
- **Communication Patterns**: Updated protocol messages to show initialization, discovery, execution, and notification flows
- **Code Examples**: Refreshed multi-language examples (.NET, Java, Python, JavaScript) to reflect current MCP SDK patterns

#### Security (02-Security/) - Comprehensive Security Overhaul  
- **Standards Alignment**: Full alignment with MCP Specification 2025-06-18 security requirements
- **Authentication Evolution**: Documented evolution from custom OAuth servers to external identity provider delegation (Microsoft Entra ID)
- **AI-Specific Threat Analysis**: Enhanced coverage of modern AI attack vectors
  - Detailed prompt injection attack scenarios with real-world examples
  - Tool poisoning mechanisms and "rug pull" attack patterns
  - Context window poisoning and model confusion attacks
- **Microsoft AI Security Solutions**: Comprehensive coverage of Microsoft security ecosystem
  - AI Prompt Shields with advanced detection, spotlighting, and delimiter techniques
  - Azure Content Safety integration patterns
  - GitHub Advanced Security for supply chain protection
- **Advanced Threat Mitigation**: Detailed security controls for
  - Session hijacking with MCP-specific attack scenarios and cryptographic session ID requirements
  - Confused deputy problems in MCP proxy scenarios with explicit consent requirements
  - Token passthrough vulnerabilities with mandatory validation controls
- **Supply Chain Security**: Expanded AI supply chain coverage including foundation models, embeddings services, context providers, and third-party APIs
- **Foundation Security**: Enhanced integration with enterprise security patterns including zero trust architecture and Microsoft security ecosystem
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
- Updated the repository structure section to include all latest files
- Enhanced "How to Use This Curriculum" section with clear recommendations
- Updated MCP specification links to point to correct URLs
- Added Context Engineering section (5.14) to the curriculum structure

### Study Guide Updates
- Completely revised the study guide to align with the current repository structure
- Added new sections for MCP Clients and Tools, and Popular MCP Servers
- Updated the Visual Curriculum Map to accurately reflect all topics
- Enhanced descriptions of Advanced Topics to cover all specialized areas
- Updated the Case Studies section to reflect actual examples
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
- Created a basic structure for all 10 main sections
- Implemented the Visual Curriculum Map for navigation
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

---

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we aim for accuracy, please note that automated translations may include errors or inaccuracies. The original document in its native language should be regarded as the authoritative source. For critical information, professional human translation is advised. We are not responsible for any misunderstandings or misinterpretations resulting from the use of this translation.