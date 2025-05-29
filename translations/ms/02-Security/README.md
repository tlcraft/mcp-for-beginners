<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:30:04+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "ms"
}
-->
# Security Best Practices

Adopting the Model Context Protocol (MCP) adds powerful new features to AI-driven applications but also brings unique security challenges beyond traditional software risks. Alongside established concerns like secure coding, least privilege, and supply chain security, MCP and AI workloads face new threats such as prompt injection, tool poisoning, and dynamic tool modification. If not properly managed, these risks can result in data leaks, privacy violations, and unintended system behavior.

This lesson covers the key security risks related to MCP—including authentication, authorization, excessive permissions, indirect prompt injection, and supply chain vulnerabilities—and offers practical controls and best practices to address them. You’ll also learn how to use Microsoft solutions like Prompt Shields, Azure Content Safety, and GitHub Advanced Security to enhance your MCP deployment. By understanding and applying these controls, you can greatly reduce the chance of a security breach and keep your AI systems reliable and trustworthy.

# Learning Objectives

By the end of this lesson, you will be able to:

- Identify and explain the unique security risks introduced by the Model Context Protocol (MCP), such as prompt injection, tool poisoning, excessive permissions, and supply chain vulnerabilities.
- Describe and implement effective mitigating controls for MCP security risks, including strong authentication, least privilege, secure token management, and supply chain verification.
- Understand and utilize Microsoft solutions like Prompt Shields, Azure Content Safety, and GitHub Advanced Security to protect MCP and AI workloads.
- Recognize the importance of validating tool metadata, monitoring for dynamic changes, and defending against indirect prompt injection attacks.
- Integrate established security best practices—like secure coding, server hardening, and zero trust architecture—into your MCP implementation to minimize the likelihood and impact of security incidents.

# MCP security controls

Any system with access to critical resources faces inherent security challenges. These challenges can generally be addressed by applying fundamental security controls and principles correctly. Since MCP is newly defined, its specification is evolving rapidly. As the protocol matures, its security controls will improve, allowing better integration with enterprise security architectures and established best practices.

Research from the [Microsoft Digital Defense Report](https://aka.ms/mddr) shows that 98% of reported breaches could be prevented with strong security hygiene. The best defense against any breach remains solid baseline security hygiene, secure coding practices, and supply chain security—those proven approaches still have the greatest impact on reducing risk.

Let’s explore some ways to start addressing security risks when adopting MCP.

> **Note:** The following information is accurate as of **29th May 2025**. The MCP protocol continues to evolve, and future versions may introduce new authentication patterns and controls. For the latest updates and guidance, always consult the [MCP Specification](https://spec.modelcontextprotocol.io/) and the official [MCP GitHub repository](https://github.com/modelcontextprotocol) as well as the [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement  
The original MCP specification assumed developers would build their own authentication server, requiring knowledge of OAuth and related security constraints. MCP servers acted as OAuth 2.0 Authorization Servers, handling user authentication directly instead of delegating it to an external service like Microsoft Entra ID. As of **26 April 2025**, an update to the MCP specification allows MCP servers to delegate user authentication to an external service.

### Risks
- Misconfigured authorization logic in the MCP server can expose sensitive data and cause incorrect access controls.
- Theft of OAuth tokens on the local MCP server. If stolen, these tokens can be used to impersonate the MCP server and access resources and data associated with the token.

#### Token Passthrough  
Token passthrough is explicitly prohibited in the authorization specification because it introduces several security risks, including:

#### Security Control Circumvention  
The MCP Server or downstream APIs may enforce important security controls like rate limiting, request validation, or traffic monitoring based on token audience or other credential constraints. If clients can obtain and use tokens directly with downstream APIs without the MCP server properly validating them or ensuring tokens are issued for the correct service, these controls are bypassed.

#### Accountability and Audit Trail Issues  
The MCP Server cannot identify or distinguish between MCP Clients when clients call with an upstream-issued access token that may be opaque to the MCP Server.  
The downstream Resource Server’s logs might show requests appearing to come from a different source or identity than the actual MCP server forwarding the tokens.  
Both factors complicate incident investigation, control enforcement, and auditing.  
If the MCP Server passes tokens without validating claims (like roles, privileges, or audience) or other metadata, an attacker with a stolen token can use the server as a proxy to exfiltrate data.

#### Trust Boundary Issues  
The downstream Resource Server trusts specific entities, often based on origin or client behavior patterns. Violating this trust boundary can cause unexpected problems.  
If tokens are accepted by multiple services without proper validation, an attacker compromising one service can use the token to access others.

#### Future Compatibility Risk  
Even if an MCP Server starts as a “pure proxy” today, it may need to add security controls later. Starting with proper token audience separation makes evolving the security model easier.

### Mitigating controls

**MCP servers MUST NOT accept any tokens not explicitly issued for the MCP server**

- **Review and Harden Authorization Logic:** Thoroughly audit your MCP server’s authorization to ensure only intended users and clients can access sensitive resources. For practical guidance, see [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) and [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Enforce Secure Token Practices:** Follow [Microsoft’s best practices for token validation and lifetime](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) to prevent token misuse and reduce the risk of replay or theft.
- **Protect Token Storage:** Always store tokens securely and use encryption both at rest and in transit. For implementation tips, see [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
MCP servers may be granted more permissions than necessary for the resources they access. For example, an MCP server in an AI sales app connected to an enterprise data store should only have access scoped to sales data, not all files in the store. Following the principle of least privilege—one of the oldest security principles—no resource should have permissions beyond what it needs to perform its tasks. AI increases the challenge here because its flexibility makes it harder to define exact permissions.

### Risks  
- Excessive permissions can allow data exfiltration or modification beyond what the MCP server should access. This may also cause privacy issues if the data includes personally identifiable information (PII).

### Mitigating controls  
- **Apply the Principle of Least Privilege:** Grant the MCP server only the minimum permissions necessary to perform its tasks. Regularly review and adjust permissions to avoid excess. For detailed guidance, see [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Use Role-Based Access Control (RBAC):** Assign roles to the MCP server that are tightly scoped to specific resources and actions, avoiding broad or unnecessary permissions.
- **Monitor and Audit Permissions:** Continuously monitor permission use and audit access logs to quickly detect and fix excessive or unused privileges.

# Indirect prompt injection attacks

### Problem statement

Malicious or compromised MCP servers pose significant risks by exposing customer data or enabling unintended actions. These risks are especially relevant in AI and MCP workloads, including:

- **Prompt Injection Attacks:** Attackers embed malicious instructions in prompts or external content, causing the AI system to perform unintended actions or leak sensitive data. Learn more: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Attackers manipulate tool metadata (like descriptions or parameters) to influence AI behavior, potentially bypassing security controls or exfiltrating data. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Malicious instructions embedded in documents, web pages, or emails are processed by the AI, leading to data leaks or manipulation.
- **Dynamic Tool Modification (Rug Pulls):** Tool definitions can be changed after user approval, introducing malicious behaviors without user awareness.

These vulnerabilities highlight the need for strong validation, monitoring, and security controls when integrating MCP servers and tools. For more details, see the linked references.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.ms.png)

**Indirect Prompt Injection** (also called cross-domain prompt injection or XPIA) is a critical vulnerability in generative AI systems, including those using MCP. Here, malicious instructions hidden in external content—such as documents, web pages, or emails—may be interpreted by the AI as legitimate user commands. This can lead to unintended actions like data leaks, harmful content generation, or manipulation of user interactions. For detailed explanations and examples, see [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

A particularly dangerous form of this attack is **Tool Poisoning**. Attackers inject malicious instructions into MCP tool metadata (e.g., tool descriptions or parameters). Since large language models (LLMs) rely on this metadata to decide which tools to call, compromised descriptions can trick the model into unauthorized tool calls or bypassing security controls. These manipulations are often invisible to users but interpreted by the AI system. This risk is higher in hosted MCP server environments where tool definitions can be updated after user approval—a scenario known as a "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". In such cases, a previously safe tool may later be altered to perform malicious actions, like data exfiltration or system manipulation, without the user’s knowledge. For more, see [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.ms.png)

## Risks  
Unintended AI actions can cause security issues such as data leaks and privacy breaches.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** are Microsoft’s solution to defend against both direct and indirect prompt injection attacks. They work by:

1.  **Detection and Filtering:** Using advanced machine learning and natural language processing to identify and block malicious instructions embedded in external content like documents, web pages, or emails.
    
2.  **Spotlighting:** Helping the AI system differentiate valid system instructions from potentially untrustworthy external inputs. By transforming input text to make it more relevant to the model, Spotlighting helps the AI better detect and ignore malicious instructions.
    
3.  **Delimiters and Datamarking:** Including delimiters in system messages clearly marks the location of input text, helping the AI distinguish user inputs from harmful external content. Datamarking extends this by using special markers to highlight trusted and untrusted data boundaries.
    
4.  **Continuous Monitoring and Updates:** Microsoft continuously monitors and updates Prompt Shields to address new and evolving threats, keeping defenses effective against the latest attack methods.
    
5. **Integration with Azure Content Safety:** Prompt Shields are part of the broader Azure AI Content Safety suite, which offers additional tools to detect jailbreak attempts, harmful content, and other AI security risks.

You can learn more about AI prompt shields in the [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.ms.png)

### Supply chain security

Supply chain security remains crucial in the AI era, but the definition of your supply chain has expanded. Beyond traditional code packages, you now must rigorously verify and monitor all AI-related components, including foundation models, embedding services, context providers, and third-party APIs. Each can introduce vulnerabilities if not properly managed.

**Key supply chain security practices for AI and MCP:**
- **Verify all components before integration:** This includes not only open-source libraries but also AI models, data sources, and external APIs. Always check provenance, licensing, and known vulnerabilities.
- **Maintain secure deployment pipelines:** Use automated CI/CD pipelines with integrated security scanning to catch issues early. Ensure only trusted artifacts are deployed to production.
- **Continuously monitor and audit:** Implement ongoing monitoring of all dependencies, including models and data services, to detect new vulnerabilities or supply chain attacks.
- **Apply least privilege and access controls:** Restrict access to models, data, and services to only what the MCP server requires.
- **Respond quickly to threats:** Have processes to patch or replace compromised components and rotate secrets or credentials if a breach occurs.

[GitHub Advanced Security](https://github.com/security/advanced-security) offers features like secret scanning, dependency scanning, and CodeQL analysis. These integrate with [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) and [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) to help teams identify and fix vulnerabilities across code and AI supply chain components.

Microsoft also applies extensive supply chain security practices internally across all products. Learn more in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Any MCP implementation inherits the security posture of the organization’s environment it is built on. Therefore, when securing MCP as part of your overall AI systems, it’s recommended to strengthen your existing security posture. The following established controls are especially relevant:

- Secure coding best practices in your AI application—protect against [the OWASP Top 10](https://owasp.org/www-project-top-ten/), the [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), use secure vaults for secrets and tokens, implement end-to-end secure communications between components, etc.
- Server hardening—use MFA where possible, keep patches current, integrate servers with third-party identity providers for access, and more.
- Keep devices, infrastructure, and applications up to date with patches.
- Security monitoring—implement logging and monitoring of AI applications (including MCP clients and servers) and send logs to a central SIEM for detecting anomalies.
- Zero trust architecture—isolate components through network and identity controls to minimize lateral movement if an AI application is compromised.

# Key Takeaways

- Security fundamentals remain vital: secure coding, least privilege, supply chain verification, and continuous monitoring are essential for MCP and AI workloads.
- MCP introduces new risks—such as prompt injection, tool poisoning, and excessive permissions—that require both traditional and AI-specific controls.
- Use strong authentication, authorization, and token management, leveraging external identity providers like Microsoft Entra ID when possible.
- Protect against indirect prompt injection and tool poisoning by validating tool metadata, monitoring for dynamic changes, and using solutions like Microsoft Prompt Shields.
- Treat all components in your AI supply chain—including models, embeddings, and context providers—with the same rigor as code dependencies.
- Stay up to date with evolving MCP specifications and contribute to the community to help shape secure standards.

# Additional Resources

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
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
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Next 

Next: [Chapter 3: Getting Started](/03-GettingStarted/README.md)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.