<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-17T09:28:52+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "en"
}
-->
# Security Best Practices

Adopting the Model Context Protocol (MCP) brings powerful new capabilities to AI-driven applications, but also introduces unique security challenges that go beyond traditional software risks. Alongside established concerns like secure coding, least privilege, and supply chain security, MCP and AI workloads face new threats such as prompt injection, tool poisoning, dynamic tool modification, session hijacking, confused deputy attacks, and token passthrough vulnerabilities. If not properly managed, these risks can lead to data leaks, privacy violations, and unintended system behavior.

This lesson covers the most relevant security risks related to MCP—including authentication, authorization, excessive permissions, indirect prompt injection, session security, confused deputy issues, token passthrough vulnerabilities, and supply chain risks—and offers practical controls and best practices to address them. You’ll also learn how to use Microsoft solutions like Prompt Shields, Azure Content Safety, and GitHub Advanced Security to enhance your MCP implementation. By understanding and applying these controls, you can greatly reduce the chance of a security breach and keep your AI systems reliable and trustworthy.

# Learning Objectives

By the end of this lesson, you will be able to:

- Identify and explain the unique security risks introduced by the Model Context Protocol (MCP), including prompt injection, tool poisoning, excessive permissions, session hijacking, confused deputy issues, token passthrough vulnerabilities, and supply chain risks.
- Describe and apply effective mitigation controls for MCP security risks, such as strong authentication, least privilege, secure token management, session security measures, and supply chain verification.
- Understand and leverage Microsoft solutions like Prompt Shields, Azure Content Safety, and GitHub Advanced Security to protect MCP and AI workloads.
- Recognize the importance of validating tool metadata, monitoring for dynamic changes, defending against indirect prompt injection attacks, and preventing session hijacking.
- Incorporate established security best practices—such as secure coding, server hardening, and zero trust architecture—into your MCP implementation to minimize the likelihood and impact of security breaches.

# MCP security controls

Any system with access to critical resources faces inherent security challenges. These challenges can generally be addressed by properly applying fundamental security controls and principles. Since MCP is newly defined, its specification is evolving rapidly. As the protocol matures, its security controls will improve, enabling better integration with enterprise security architectures and best practices.

Research published in the [Microsoft Digital Defense Report](https://aka.ms/mddr) shows that 98% of reported breaches could be prevented by strong security hygiene. The best defense against any breach is to get your baseline security hygiene, secure coding practices, and supply chain security right—those proven practices still have the greatest impact on reducing security risk.

Let’s explore some ways you can start addressing security risks when adopting MCP.

> **Note:** The following information is accurate as of **29th May 2025**. The MCP protocol is continuously evolving, and future versions may introduce new authentication patterns and controls. For the latest updates and guidance, always refer to the [MCP Specification](https://spec.modelcontextprotocol.io/), the official [MCP GitHub repository](https://github.com/modelcontextprotocol), and the [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement  
The original MCP specification assumed developers would build their own authentication server. This required knowledge of OAuth and related security constraints. MCP servers acted as OAuth 2.0 Authorization Servers, managing user authentication directly rather than delegating it to an external service like Microsoft Entra ID. As of **26 April 2025**, an update to the MCP specification allows MCP servers to delegate user authentication to an external service.

### Risks
- Misconfigured authorization logic in the MCP server can lead to exposure of sensitive data and incorrect access controls.
- OAuth token theft on the local MCP server. If stolen, the token can be used to impersonate the MCP server and access resources and data from the service the OAuth token is for.

#### Token Passthrough  
Token passthrough is explicitly prohibited in the authorization specification because it introduces several security risks, including:

#### Security Control Circumvention  
The MCP Server or downstream APIs may enforce important security controls like rate limiting, request validation, or traffic monitoring that depend on the token audience or other credential constraints. If clients can obtain and use tokens directly with downstream APIs without the MCP server validating them properly or ensuring the tokens are issued for the correct service, these controls are bypassed.

#### Accountability and Audit Trail Issues  
The MCP Server cannot identify or distinguish between MCP Clients when clients call with an upstream-issued access token that may be opaque to the MCP Server.  
The downstream Resource Server’s logs may show requests appearing to come from a different source or identity, rather than the MCP server that is actually forwarding the tokens.  
Both factors complicate incident investigation, control enforcement, and auditing.  
If the MCP Server passes tokens without validating their claims (e.g., roles, privileges, or audience) or other metadata, a malicious actor with a stolen token can use the server as a proxy for data exfiltration.

#### Trust Boundary Issues  
The downstream Resource Server grants trust to specific entities, which may include assumptions about origin or client behavior. Breaking this trust boundary can cause unexpected problems.  
If the token is accepted by multiple services without proper validation, an attacker who compromises one service can use the token to access other connected services.

#### Future Compatibility Risk  
Even if an MCP Server starts as a “pure proxy” today, it may need to add security controls later. Starting with proper token audience separation makes evolving the security model easier.

### Mitigating controls

**MCP servers MUST NOT accept any tokens that were not explicitly issued for the MCP server**

- **Review and Harden Authorization Logic:** Carefully audit your MCP server’s authorization implementation to ensure only intended users and clients can access sensitive resources. For practical guidance, see [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) and [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Enforce Secure Token Practices:** Follow [Microsoft’s best practices for token validation and lifetime](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) to prevent token misuse and reduce the risk of token replay or theft.
- **Protect Token Storage:** Always store tokens securely and use encryption to protect them at rest and in transit. For implementation tips, see [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
MCP servers may have been granted excessive permissions to the services or resources they access. For example, an MCP server in an AI sales application connecting to an enterprise data store should have access limited to sales data only, not all files in the store. Referring back to the principle of least privilege (one of the oldest security principles), no resource should have permissions beyond what is necessary to perform its intended tasks. AI adds complexity here because its flexibility makes it challenging to define exact required permissions.

### Risks  
- Granting excessive permissions can allow data exfiltration or modification beyond what the MCP server was intended to access. This could also lead to privacy issues if the data includes personally identifiable information (PII).

### Mitigating controls  
- **Apply the Principle of Least Privilege:** Grant the MCP server only the minimum permissions needed to perform its tasks. Regularly review and update these permissions to ensure they remain appropriate. For detailed guidance, see [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Use Role-Based Access Control (RBAC):** Assign roles to the MCP server that are tightly scoped to specific resources and actions, avoiding broad or unnecessary permissions.
- **Monitor and Audit Permissions:** Continuously monitor permission usage and audit access logs to detect and promptly address excessive or unused privileges.

# Indirect prompt injection attacks

### Problem statement

Malicious or compromised MCP servers can pose significant risks by exposing customer data or enabling unintended actions. These risks are especially relevant in AI and MCP-based workloads, where:

- **Prompt Injection Attacks:** Attackers embed malicious instructions in prompts or external content, causing the AI system to perform unintended actions or leak sensitive data. Learn more: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Attackers manipulate tool metadata (such as descriptions or parameters) to influence the AI’s behavior, potentially bypassing security controls or exfiltrating data. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Malicious instructions are embedded in documents, web pages, or emails, which the AI then processes, leading to data leaks or manipulation.
- **Dynamic Tool Modification (Rug Pulls):** Tool definitions can be changed after user approval, introducing new malicious behaviors without the user’s knowledge.

These vulnerabilities highlight the need for strong validation, monitoring, and security controls when integrating MCP servers and tools into your environment. For a deeper dive, see the linked references above.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.en.png)

**Indirect Prompt Injection** (also called cross-domain prompt injection or XPIA) is a critical vulnerability in generative AI systems, including those using MCP. In this attack, malicious instructions are hidden inside external content—such as documents, web pages, or emails. When the AI processes this content, it may interpret the embedded instructions as legitimate user commands, causing unintended actions like data leaks, harmful content generation, or manipulation of user interactions. For detailed explanations and real-world examples, see [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

A particularly dangerous form of this attack is **Tool Poisoning**. Here, attackers inject malicious instructions into MCP tool metadata (like tool descriptions or parameters). Since large language models (LLMs) rely on this metadata to decide which tools to invoke, compromised descriptions can trick the model into executing unauthorized tool calls or bypassing security controls. These manipulations are often invisible to end users but can be interpreted and acted upon by the AI system. This risk is especially high in hosted MCP server environments, where tool definitions can be updated after user approval—a scenario sometimes called a "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". In such cases, a tool that was previously safe may later be modified to perform malicious actions, like data exfiltration or system manipulation, without the user’s knowledge. For more on this attack vector, see [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.en.png)

## Risks  
Unintended AI actions pose various security risks, including data exfiltration and privacy breaches.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** are a Microsoft solution designed to defend against both direct and indirect prompt injection attacks. They help by:

1.  **Detection and Filtering:** Prompt Shields use advanced machine learning and natural language processing to detect and filter out malicious instructions embedded in external content like documents, web pages, or emails.
    
2.  **Spotlighting:** This technique helps the AI system distinguish valid system instructions from potentially untrustworthy external inputs. By transforming input text to make it more relevant to the model, Spotlighting helps the AI better identify and ignore malicious instructions.
    
3.  **Delimiters and Datamarking:** Including delimiters in system messages clearly marks the location of input text, helping the AI separate user inputs from potentially harmful external content. Datamarking extends this by using special markers to highlight boundaries between trusted and untrusted data.
    
4.  **Continuous Monitoring and Updates:** Microsoft continuously monitors and updates Prompt Shields to address new and evolving threats. This proactive approach keeps defenses effective against the latest attack techniques.
    
5. **Integration with Azure Content Safety:** Prompt Shields are part of the broader Azure AI Content Safety suite, which offers additional tools for detecting jailbreak attempts, harmful content, and other security risks in AI applications.

You can learn more about AI prompt shields in the [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.en.png)

# Confused Deputy Problem

### Problem statement
The confused deputy problem is a security vulnerability that occurs when an MCP server acts as a proxy between MCP clients and third-party APIs. This vulnerability can be exploited when the MCP server uses a static client ID to authenticate with a third-party authorization server that lacks dynamic client registration support.

### Risks

- **Cookie-based consent bypass**: If a user has previously authenticated through the MCP proxy server, a third-party authorization server may set a consent cookie in the user's browser. An attacker can later exploit this by sending the user a malicious link with a crafted authorization request containing a malicious redirect URI.
- **Authorization code theft**: When the user clicks the malicious link, the third-party authorization server may skip the consent screen due to the existing cookie, and the authorization code could be redirected to the attacker's server.
- **Unauthorized API access**: The attacker can exchange the stolen authorization code for access tokens and impersonate the user to access the third-party API without explicit approval.

### Mitigating controls

- **Explicit consent requirements**: MCP proxy servers using static client IDs **MUST** obtain user consent for each dynamically registered client before forwarding to third-party authorization servers.
- **Proper OAuth implementation**: Follow OAuth 2.1 security best practices, including using code challenges (PKCE) for authorization requests to prevent interception attacks.
- **Client validation**: Implement strict validation of redirect URIs and client identifiers to prevent exploitation by malicious actors.


# Token Passthrough Vulnerabilities

### Problem statement

"Token passthrough" is an anti-pattern where an MCP server accepts tokens from an MCP client without validating that the tokens were properly issued to the MCP server itself, and then "passes them through" to downstream APIs. This practice explicitly violates the MCP authorization specification and introduces serious security risks.

### Risks

- **Security Control Circumvention**: Clients could bypass important security controls like rate limiting, request validation, or traffic monitoring if they can use tokens directly with downstream APIs without proper validation.
- **Accountability and Audit Trail Issues**: The MCP server will be unable to identify or distinguish between MCP clients when clients use upstream-issued access tokens, making incident investigation and auditing more difficult.
- **Data Exfiltration**: If tokens are passed without proper claims validation, a malicious actor with a stolen token could use the server as a proxy for data exfiltration.
- **Trust Boundary Violations**: Downstream resource servers may grant trust to specific entities with assumptions about origin or behavior patterns. Breaking this trust boundary could lead to unexpected security issues.
- **Multi-service Token Misuse**: If tokens are accepted by multiple services without proper validation, an attacker compromising one service could use the token to access other connected services.

### Mitigating controls

- **Token validation**: MCP servers **MUST NOT** accept any tokens that were not explicitly issued for the MCP server itself.
- **Audience verification**: Always validate that tokens have the correct audience claim that matches the MCP server's identity.
- **Proper token lifecycle management**: Implement short-lived access tokens and proper token rotation practices to reduce the risk of token theft and misuse.


# Session Hijacking

### Problem statement

Session hijacking is an attack vector where a client is provided a session ID by the server, and an unauthorized party obtains and uses that same session ID to impersonate the original client and perform unauthorized actions on their behalf. This is particularly concerning in stateful HTTP servers handling MCP requests.

### Risks

- **Session Hijack Prompt Injection**: An attacker who obtains a session ID could send malicious events to a server that shares session state with the server the client is connected to, potentially triggering harmful actions or accessing sensitive data.
- **Session Hijack Impersonation**: An attacker with a stolen session ID could make calls directly to the MCP server, bypassing authentication and being treated as the legitimate user.
- **Compromised Resumable Streams**: When a server supports redelivery/resumable streams, an attacker could terminate a request prematurely, leading to it being resumed later by the original client with potentially malicious content.

### Mitigating controls

- **Authorization verification**: MCP servers that implement authorization **MUST** verify all inbound requests and **MUST NOT** use sessions for authentication.
- **Secure session IDs**: MCP servers **MUST** use secure, non-deterministic session IDs generated with secure random number generators. Avoid predictable or sequential identifiers.
- **User-specific session binding**: MCP servers **SHOULD** bind session IDs to user-specific information, combining the session ID with information unique to the authorized user (like their internal user ID) using a format like `
<user_id>:<session_id>`.
- **Session expiration**: Implement proper session expiration and rotation to limit the window of vulnerability if a session ID is compromised.
- **Transport security**: Always use HTTPS for all communication to prevent session ID interception.


# Supply chain security

Supply chain security remains fundamental in the AI era, but the scope of what constitutes your supply chain has expanded. In addition to traditional code packages, you must now rigorously verify and monitor all AI-related components, including foundation models, embeddings services, context providers, and third-party APIs. Each of these can introduce vulnerabilities or risks if not properly managed.

**Key supply chain security practices for AI and MCP:**
- **Verify all components before integration:** This includes not just open-source libraries, but also AI models, data sources, and external APIs. Always check for provenance, licensing, and known vulnerabilities.
- **Maintain secure deployment pipelines:** Use automated CI/CD pipelines with integrated security scanning to catch issues early. Ensure that only trusted artifacts are deployed to production.
- **Continuously monitor and audit:** Implement ongoing monitoring for all dependencies, including models and data services, to detect new vulnerabilities or supply chain attacks.
- **Apply least privilege and access controls:** Restrict access to models, data, and services to only what is necessary for your MCP server to function.
- **Respond quickly to threats:** Have a process in place for patching or replacing compromised components, and for rotating secrets or credentials if a breach is detected.

[GitHub Advanced Security](https://github.com/security/advanced-security) provides features such as secret scanning, dependency scanning, and CodeQL analysis. These tools integrate with [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) and [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) to help teams identify and mitigate vulnerabilities across both code and AI supply chain components.

Microsoft also implements extensive supply chain security practices internally for all products. Learn more in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Established security best practices that will uplift your MCP implementation's security posture

Any MCP implementation inherits the existing security posture of your organization's environment that it is built upon, so when considering the security of MCP as a component of your overall AI systems it is recommended that you look at uplifting your overall existing security posture. The following established security controls are especially pertinent:

-   Secure coding best practices in your AI application - protect against [the OWASP Top 10](https://owasp.org/www-project-top-ten/), the [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), use of secure vaults for secrets and tokens, implementing end-to-end secure communications between all application components, etc.
-   Server hardening -- use MFA where possible, keep patching up to date, integrate the server with a third party identity provider for access, etc.
-   Keep devices, infrastructure and applications up to date with patches
-   Security monitoring -- implementing logging and monitoring of an AI application (including the MCP client/servers) and sending those logs to a central SIEM for detection of anomalous activities
-   Zero trust architecture -- isolating components via network and identity controls in a logical manner to minimize lateral movement if an AI application were compromised.

# Key Takeaways

- Security fundamentals remain critical: Secure coding, least privilege, supply chain verification, and continuous monitoring are essential for MCP and AI workloads.
- MCP introduces new risks—such as prompt injection, tool poisoning, session hijacking, confused deputy problems, token passthrough vulnerabilities, and excessive permissions—that require both traditional and AI-specific controls.
- Use robust authentication, authorization, and token management practices, leveraging external identity providers like Microsoft Entra ID where possible.
- Protect against indirect prompt injection and tool poisoning by validating tool metadata, monitoring for dynamic changes, and using solutions like Microsoft Prompt Shields.
- Implement secure session management by using non-deterministic session IDs, binding sessions to user identities, and never using sessions for authentication.
- Prevent confused deputy attacks by requiring explicit user consent for each dynamically registered client and implementing proper OAuth security practices.
- Avoid token passthrough vulnerabilities by ensuring that MCP servers only accept tokens explicitly issued for them and validate token claims appropriately.
- Treat all components in your AI supply chain—including models, embeddings, and context providers—with the same rigor as code dependencies.
- Stay current with evolving MCP specifications and contribute to the community to help shape secure standards.

# Additional Resources

## External Resources
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Additional Security Documents

For more detailed security guidance, please refer to these documents:

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - Comprehensive list of security best practices for MCP implementations
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Implementation examples for integrating Azure Content Safety with MCP servers
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - Latest security controls and techniques for securing MCP deployments
- [MCP Best Practices](./mcp-best-practices.md) - Quick reference guide for MCP security

### Next 

Next: [Chapter 3: Getting Started](../03-GettingStarted/README.md)

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.