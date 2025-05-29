<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:40:35+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "sl"
}
-->
# Security Best Practices

Model Context Protocol (MCP) introduces powerful features for AI-driven apps but also brings unique security challenges beyond traditional software risks. Alongside familiar concerns like secure coding, least privilege, and supply chain security, MCP and AI workloads face new threats such as prompt injection, tool poisoning, and dynamic tool modification. Without proper management, these risks can cause data leaks, privacy violations, and unexpected system behavior.

This lesson covers key security risks linked to MCP—including authentication, authorization, excessive permissions, indirect prompt injection, and supply chain vulnerabilities—and offers practical controls and best practices to address them. You’ll also discover how to use Microsoft solutions like Prompt Shields, Azure Content Safety, and GitHub Advanced Security to enhance your MCP setup. Applying these controls will help you lower the chance of breaches and keep your AI systems secure and reliable.

# Learning Objectives

By the end of this lesson, you will be able to:

- Identify and explain unique security risks introduced by MCP, such as prompt injection, tool poisoning, excessive permissions, and supply chain vulnerabilities.
- Describe and apply effective controls for MCP security risks, including strong authentication, least privilege, secure token handling, and supply chain verification.
- Understand and leverage Microsoft tools like Prompt Shields, Azure Content Safety, and GitHub Advanced Security to protect MCP and AI workloads.
- Recognize the importance of validating tool metadata, monitoring for dynamic changes, and defending against indirect prompt injection attacks.
- Integrate established security best practices—like secure coding, server hardening, and zero trust architecture—into your MCP implementation to reduce security risks and impact.

# MCP security controls

Any system accessing critical resources faces inherent security challenges. These can generally be addressed by applying fundamental security controls and concepts correctly. MCP is still evolving rapidly, so its security controls will mature over time, allowing better integration with enterprise security architectures and best practices.

Research from the [Microsoft Digital Defense Report](https://aka.ms/mddr) shows 98% of reported breaches could be prevented by solid security hygiene. The best defense against breaches remains getting your baseline security hygiene, secure coding, and supply chain security right—time-tested practices still have the greatest impact on reducing risk.

Let’s explore ways you can begin addressing security risks when adopting MCP.

> **Note:** The following information is accurate as of **29th May 2025**. MCP is continuously evolving, and future versions may introduce new authentication methods and controls. For the latest updates, always consult the [MCP Specification](https://spec.modelcontextprotocol.io/), the official [MCP GitHub repository](https://github.com/modelcontextprotocol), and the [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement  
The original MCP spec assumed developers would build their own authentication server, requiring knowledge of OAuth and related security constraints. MCP servers acted as OAuth 2.0 Authorization Servers, managing user authentication directly rather than delegating to external services like Microsoft Entra ID. As of **26 April 2025**, an update allows MCP servers to delegate user authentication to external services.

### Risks
- Misconfigured authorization logic in MCP servers can expose sensitive data or enforce access controls incorrectly.
- Theft of OAuth tokens on local MCP servers can enable attackers to impersonate the MCP server and access protected resources.

#### Token Passthrough  
Token passthrough is explicitly forbidden in the authorization spec because it introduces several security risks:

#### Security Control Circumvention  
MCP servers or downstream APIs often rely on tokens for enforcing rate limits, request validation, or traffic monitoring based on token audience or credential constraints. If clients can use tokens directly with downstream APIs without MCP server validation, these controls are bypassed.

#### Accountability and Audit Trail Issues  
MCP servers cannot distinguish between clients if upstream-issued access tokens are used directly, making it hard to track who initiated requests. Logs on downstream servers may show requests as coming from different sources, complicating incident investigation and auditing. If tokens are passed without validating claims or metadata, attackers with stolen tokens can use the MCP server as a proxy for data theft.

#### Trust Boundary Issues  
Downstream servers trust specific entities based on origin or behavior. Breaking this trust boundary by accepting tokens without proper validation risks unauthorized access across services.

#### Future Compatibility Risk  
Even if an MCP server acts as a “pure proxy” today, it may need to add security controls later. Proper token audience separation from the start makes evolving security easier.

### Mitigating controls

**MCP servers MUST NOT accept tokens not explicitly issued for the MCP server**

- **Review and Harden Authorization Logic:** Audit your MCP server’s authorization to ensure only authorized users and clients access sensitive resources. For guidance, see [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) and [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Enforce Secure Token Practices:** Follow [Microsoft’s best practices for token validation and lifetime](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) to prevent token misuse and reduce replay or theft risks.
- **Protect Token Storage:** Always store tokens securely with encryption at rest and in transit. See [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2) for implementation tips.

# Excessive permissions for MCP servers

### Problem statement  
MCP servers may have been granted permissions beyond what they need. For example, an MCP server in an AI sales app accessing an enterprise data store should only have access scoped to sales data, not all files. Following the principle of least privilege, no resource should have permissions exceeding what’s necessary for its tasks. AI makes this challenging because defining exact permissions can be complex.

### Risks  
- Excessive permissions can allow unauthorized data exfiltration or modification, potentially exposing personally identifiable information (PII).

### Mitigating controls  
- **Apply the Principle of Least Privilege:** Grant MCP servers only the minimum permissions needed for their tasks. Regularly review and update permissions. See [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access) for details.
- **Use Role-Based Access Control (RBAC):** Assign tightly scoped roles to MCP servers, avoiding broad permissions.
- **Monitor and Audit Permissions:** Continuously monitor permission usage and audit logs to detect and address excessive or unused privileges promptly.

# Indirect prompt injection attacks

### Problem statement

Malicious or compromised MCP servers can expose customer data or trigger unintended actions, especially in AI and MCP workloads:

- **Prompt Injection Attacks:** Attackers embed harmful instructions in prompts or external content, causing AI to act unexpectedly or leak data. Learn more: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Attackers manipulate tool metadata (like descriptions or parameters) to influence AI behavior, bypass controls, or exfiltrate data. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Malicious instructions hidden in documents, web pages, or emails processed by AI, leading to data leaks or manipulation.
- **Dynamic Tool Modification (Rug Pulls):** Tool definitions can be changed post user-approval, introducing malicious behavior without user knowledge.

These vulnerabilities call for strong validation, monitoring, and security when integrating MCP servers and tools. See linked references for deeper insights.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.sl.png)

**Indirect Prompt Injection** (or cross-domain prompt injection, XPIA) is a critical vulnerability in generative AI, including MCP-based systems. Malicious instructions hidden in external content (documents, web pages, emails) may be interpreted as legitimate commands, causing unintended actions like data leaks or harmful content generation. For detailed info and examples, see [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

A particularly dangerous form is **Tool Poisoning**, where attackers inject malicious instructions into MCP tool metadata (descriptions, parameters). Since LLMs rely on this metadata to decide which tools to call, compromised descriptions can trick the model into unauthorized calls or bypassing security. These manipulations are often invisible to users but executed by the AI. This risk is higher in hosted MCP servers where tool definitions can be updated after user approval—a scenario called a "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". A previously safe tool might later be modified to act maliciously, like stealing data or changing system behavior, without user awareness. For more, see [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.sl.png)

## Risks  
Unintended AI actions risk data exfiltration and privacy breaches.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** are Microsoft’s solution to defend against direct and indirect prompt injection attacks. They work by:

1.  **Detection and Filtering:** Using advanced machine learning and natural language processing to detect and filter malicious instructions embedded in external content like documents, web pages, or emails.
    
2.  **Spotlighting:** Helping the AI distinguish valid system instructions from potentially untrustworthy external inputs by transforming input text to make it more relevant to the model, improving identification and ignoring of malicious instructions.
    
3.  **Delimiters and Datamarking:** Including delimiters in system messages to clearly mark input text location, aiding the AI in separating user input from harmful external content. Datamarking uses special markers to highlight trusted vs untrusted data boundaries.
    
4.  **Continuous Monitoring and Updates:** Microsoft continuously updates Prompt Shields to address new threats, keeping defenses effective against evolving attack methods.
    
5. **Integration with Azure Content Safety:** Prompt Shields are part of Azure AI Content Safety, which offers tools to detect jailbreak attempts, harmful content, and other AI security risks.

Learn more in the [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.sl.png)

### Supply chain security

Supply chain security remains vital in the AI era, but the scope has expanded. Beyond traditional code packages, you must verify and monitor all AI-related components, including foundation models, embedding services, context providers, and third-party APIs. Each can introduce vulnerabilities if not managed properly.

**Key supply chain security practices for AI and MCP:**
- **Verify all components before integration:** Check open-source libraries, AI models, data sources, and external APIs for provenance, licenses, and known vulnerabilities.
- **Maintain secure deployment pipelines:** Use automated CI/CD pipelines with integrated security scanning to catch issues early. Deploy only trusted artifacts to production.
- **Continuously monitor and audit:** Implement ongoing monitoring of dependencies, including models and data services, to detect new vulnerabilities or attacks.
- **Apply least privilege and access controls:** Restrict access to models, data, and services strictly to what MCP servers need.
- **Respond quickly to threats:** Have processes for patching or replacing compromised components and rotating secrets if breaches occur.

[GitHub Advanced Security](https://github.com/security/advanced-security) offers secret scanning, dependency scanning, and CodeQL analysis. These integrate with [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) and [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) to help teams identify and fix vulnerabilities across code and AI supply chains.

Microsoft also applies extensive supply chain security internally for all products. Learn more in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Any MCP deployment inherits your organization’s existing security posture. When securing MCP as part of your AI systems, it’s recommended to strengthen your overall security stance. Key established controls include:

- Secure coding best practices for your AI app—protect against [the OWASP Top 10](https://owasp.org/www-project-top-ten/), the [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), use secure vaults for secrets and tokens, and ensure end-to-end secure communication between components.
- Server hardening—use MFA where possible, keep patches current, and integrate servers with third-party identity providers for access.
- Keep devices, infrastructure, and apps updated with patches.
- Security monitoring—log and monitor AI applications (including MCP clients/servers), sending logs to a central SIEM to detect anomalies.
- Zero trust architecture—segment components via network and identity controls to minimize lateral movement if compromised.

# Key Takeaways

- Security fundamentals remain crucial: secure coding, least privilege, supply chain verification, and continuous monitoring are essential for MCP and AI workloads.
- MCP introduces new risks—prompt injection, tool poisoning, excessive permissions—that require both traditional and AI-specific controls.
- Use strong authentication, authorization, and token management, leveraging external identity providers like Microsoft Entra ID when possible.
- Protect against indirect prompt injection and tool poisoning by validating tool metadata, monitoring dynamic changes, and using solutions like Microsoft Prompt Shields.
- Treat all components in your AI supply chain—including models, embeddings, and context providers—with the same rigor as code dependencies.
- Stay up to date with evolving MCP specs and contribute to the community to help shape secure standards.

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

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.