<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T15:16:56+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "en"
}
-->
# Security Best Practices

Adopting the Model Context Protocol (MCP) brings powerful new capabilities to AI-driven applications, but also introduces unique security challenges that go beyond traditional software risks. Alongside established concerns like secure coding, least privilege, and supply chain security, MCP and AI workloads face new threats such as prompt injection, tool poisoning, and dynamic tool modification. If not properly managed, these risks can lead to data leaks, privacy violations, and unexpected system behavior.

This lesson covers the most relevant security risks related to MCP—including authentication, authorization, excessive permissions, indirect prompt injection, and supply chain vulnerabilities—and offers practical controls and best practices to address them. You’ll also learn how to use Microsoft solutions like Prompt Shields, Azure Content Safety, and GitHub Advanced Security to strengthen your MCP deployment. By understanding and applying these controls, you can greatly reduce the chance of a security breach and keep your AI systems reliable and trustworthy.

# Learning Objectives

By the end of this lesson, you will be able to:

- Identify and explain the unique security risks introduced by the Model Context Protocol (MCP), including prompt injection, tool poisoning, excessive permissions, and supply chain vulnerabilities.
- Describe and apply effective mitigating controls for MCP security risks, such as strong authentication, least privilege, secure token management, and supply chain verification.
- Understand and leverage Microsoft solutions like Prompt Shields, Azure Content Safety, and GitHub Advanced Security to protect MCP and AI workloads.
- Recognize the importance of validating tool metadata, monitoring for dynamic changes, and defending against indirect prompt injection attacks.
- Incorporate established security best practices—such as secure coding, server hardening, and zero trust architecture—into your MCP implementation to reduce the likelihood and impact of security breaches.

# MCP security controls

Any system with access to critical resources faces inherent security challenges. These challenges can generally be addressed by properly applying fundamental security controls and principles. Since MCP is newly defined, its specification is evolving rapidly. As the protocol matures, its security controls will improve, enabling better integration with enterprise security architectures and best practices.

Research published in the [Microsoft Digital Defense Report](https://aka.ms/mddr) shows that 98% of reported breaches could be prevented by strong security hygiene. The best defense against any breach is to get your baseline security hygiene, secure coding practices, and supply chain security right—those proven methods still have the greatest impact on reducing risk.

Let’s explore some ways you can start addressing security risks when adopting MCP.

> **Note:** The following information is accurate as of **29th May 2025**. The MCP protocol is continuously evolving, and future versions may introduce new authentication patterns and controls. For the latest updates and guidance, always refer to the [MCP Specification](https://spec.modelcontextprotocol.io/), the official [MCP GitHub repository](https://github.com/modelcontextprotocol), and the [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement  
The original MCP specification assumed developers would build their own authentication server. This required knowledge of OAuth and related security constraints. MCP servers acted as OAuth 2.0 Authorization Servers, managing user authentication directly rather than delegating it to an external service like Microsoft Entra ID. As of **26 April 2025**, an update to the MCP specification allows MCP servers to delegate user authentication to an external service.

### Risks
- Misconfigured authorization logic in the MCP server can expose sensitive data and cause incorrect access controls.
- OAuth token theft on the local MCP server. If stolen, the token can be used to impersonate the MCP server and access resources and data from the service the OAuth token is for.

#### Token Passthrough
Token passthrough is explicitly prohibited in the authorization specification because it introduces several security risks, including:

#### Security Control Circumvention
The MCP Server or downstream APIs may enforce important security controls like rate limiting, request validation, or traffic monitoring that rely on the token audience or other credential constraints. If clients can obtain and use tokens directly with downstream APIs without the MCP server validating them properly or ensuring the tokens are issued for the correct service, these controls are bypassed.

#### Accountability and Audit Trail Issues
The MCP Server cannot identify or distinguish between MCP Clients when clients call with an upstream-issued access token that may be opaque to the MCP Server.  
The downstream Resource Server’s logs may show requests appearing to come from a different source or identity, rather than the MCP server forwarding the tokens.  
Both factors complicate incident investigation, controls, and auditing.  
If the MCP Server passes tokens without validating their claims (e.g., roles, privileges, or audience) or other metadata, a malicious actor with a stolen token can use the server as a proxy for data exfiltration.

#### Trust Boundary Issues
The downstream Resource Server grants trust to specific entities, which may include assumptions about origin or client behavior. Breaking this trust boundary can cause unexpected problems.  
If the token is accepted by multiple services without proper validation, an attacker who compromises one service can use the token to access other connected services.

#### Future Compatibility Risk
Even if an MCP Server starts as a “pure proxy” today, it may need to add security controls later. Starting with proper token audience separation makes evolving the security model easier.

### Mitigating controls

**MCP servers MUST NOT accept any tokens not explicitly issued for the MCP server**

- **Review and Harden Authorization Logic:** Carefully audit your MCP server’s authorization implementation to ensure only intended users and clients can access sensitive resources. For practical guidance, see [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) and [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Enforce Secure Token Practices:** Follow [Microsoft’s best practices for token validation and lifetime](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) to prevent token misuse and reduce the risk of token replay or theft.
- **Protect Token Storage:** Always store tokens securely and use encryption to protect them at rest and in transit. For implementation tips, see [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
MCP servers may have been granted excessive permissions to the service or resource they access. For example, an MCP server in an AI sales application connecting to an enterprise data store should have access limited to sales data, not all files in the store. Referring back to the principle of least privilege (one of the oldest security principles), no resource should have permissions beyond what is necessary to perform its intended tasks. AI adds complexity here because its flexibility makes it challenging to define exact required permissions.

### Risks  
- Granting excessive permissions can allow data exfiltration or modification that the MCP server was not meant to perform. This could also cause privacy issues if the data includes personally identifiable information (PII).

### Mitigating controls  
- **Apply the Principle of Least Privilege:** Grant the MCP server only the minimum permissions needed to perform its tasks. Regularly review and update these permissions to ensure they don’t exceed what’s necessary. For detailed guidance, see [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Use Role-Based Access Control (RBAC):** Assign roles to the MCP server that are tightly scoped to specific resources and actions, avoiding broad or unnecessary permissions.
- **Monitor and Audit Permissions:** Continuously monitor permission usage and audit access logs to quickly detect and fix excessive or unused privileges.

# Indirect prompt injection attacks

### Problem statement

Malicious or compromised MCP servers can pose serious risks by exposing customer data or enabling unintended actions. These risks are especially relevant in AI and MCP-based workloads, where:

- **Prompt Injection Attacks:** Attackers embed malicious instructions in prompts or external content, causing the AI system to perform unintended actions or leak sensitive data. Learn more: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Attackers manipulate tool metadata (such as descriptions or parameters) to influence the AI’s behavior, potentially bypassing security controls or exfiltrating data. Details: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Malicious instructions are embedded in documents, web pages, or emails, which the AI then processes, leading to data leaks or manipulation.
- **Dynamic Tool Modification (Rug Pulls):** Tool definitions can be changed after user approval, introducing new malicious behaviors without the user’s knowledge.

These vulnerabilities highlight the need for strong validation, monitoring, and security controls when integrating MCP servers and tools into your environment. For more details, see the linked references above.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.en.png)

**Indirect Prompt Injection** (also called cross-domain prompt injection or XPIA) is a critical vulnerability in generative AI systems, including those using MCP. In this attack, malicious instructions are hidden inside external content—like documents, web pages, or emails. When the AI processes this content, it may interpret the embedded instructions as legitimate user commands, causing unintended actions such as data leaks, harmful content generation, or manipulation of user interactions. For a detailed explanation and real-world examples, see [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

A particularly dangerous form of this attack is **Tool Poisoning**. Here, attackers inject malicious instructions into MCP tool metadata (such as tool descriptions or parameters). Since large language models (LLMs) rely on this metadata to decide which tools to call, compromised descriptions can trick the model into executing unauthorized tool calls or bypassing security controls. These manipulations are often invisible to end users but can be interpreted and acted upon by the AI system. This risk is especially high in hosted MCP server environments, where tool definitions can be updated after user approval—a scenario sometimes called a "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". In such cases, a tool that was previously safe may later be modified to perform malicious actions, like data exfiltration or system manipulation, without the user’s knowledge. For more on this attack vector, see [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.en.png)

## Risks  
Unintended AI actions pose various security risks, including data exfiltration and privacy breaches.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** are a Microsoft solution designed to defend against both direct and indirect prompt injection attacks. They help by:

1.  **Detection and Filtering:** Prompt Shields use advanced machine learning and natural language processing to detect and filter out malicious instructions embedded in external content like documents, web pages, or emails.
    
2.  **Spotlighting:** This technique helps the AI system distinguish between valid system instructions and potentially untrustworthy external inputs. By transforming the input text to make it more relevant to the model, Spotlighting helps the AI better identify and ignore malicious instructions.
    
3.  **Delimiters and Datamarking:** Including delimiters in the system message clearly marks the location of input text, helping the AI separate user inputs from potentially harmful external content. Datamarking extends this by using special markers to highlight boundaries between trusted and untrusted data.
    
4.  **Continuous Monitoring and Updates:** Microsoft continuously monitors and updates Prompt Shields to address new and evolving threats. This proactive approach keeps defenses effective against the latest attack methods.
    
5. **Integration with Azure Content Safety:** Prompt Shields are part of the broader Azure AI Content Safety suite, which offers additional tools for detecting jailbreak attempts, harmful content, and other security risks in AI applications.

You can learn more about AI prompt shields in the [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.en.png)

### Supply chain security
Supply chain security remains fundamental in the AI era, but the scope of what counts as your supply chain has expanded. Beyond traditional code packages, you now need to thoroughly verify and monitor all AI-related components, including foundation models, embedding services, context providers, and third-party APIs. Each of these can introduce vulnerabilities or risks if not properly managed.

**Key supply chain security practices for AI and MCP:**
- **Verify all components before integration:** This includes not only open-source libraries but also AI models, data sources, and external APIs. Always check provenance, licensing, and known vulnerabilities.
- **Maintain secure deployment pipelines:** Use automated CI/CD pipelines with integrated security scanning to catch issues early. Ensure that only trusted artifacts are deployed to production.
- **Continuously monitor and audit:** Implement ongoing monitoring for all dependencies, including models and data services, to detect new vulnerabilities or supply chain attacks.
- **Apply least privilege and access controls:** Limit access to models, data, and services strictly to what your MCP server needs to operate.
- **Respond quickly to threats:** Have processes in place to patch or replace compromised components and to rotate secrets or credentials if a breach is detected.

[GitHub Advanced Security](https://github.com/security/advanced-security) offers features like secret scanning, dependency scanning, and CodeQL analysis. These tools integrate with [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) and [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) to help teams identify and mitigate vulnerabilities across both code and AI supply chain components.

Microsoft also applies extensive supply chain security practices internally for all products. Learn more in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Established security best practices that will strengthen your MCP implementation’s security posture

Any MCP implementation inherits the existing security posture of your organization’s environment where it is deployed. Therefore, when considering MCP security as part of your overall AI systems, it’s recommended to enhance your overall existing security posture. The following established security controls are especially relevant:

-   Secure coding best practices in your AI application – protect against [the OWASP Top 10](https://owasp.org/www-project-top-ten/), the [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), use secure vaults for secrets and tokens, implement end-to-end secure communications between all application components, and more.
-   Server hardening – use MFA where possible, keep patches up to date, integrate the server with a third-party identity provider for access, etc.
-   Keep devices, infrastructure, and applications updated with patches.
-   Security monitoring – implement logging and monitoring of your AI application (including MCP clients/servers) and send those logs to a central SIEM to detect anomalous activities.
-   Zero trust architecture – isolate components logically through network and identity controls to minimize lateral movement if an AI application is compromised.

# Key Takeaways

- Security fundamentals remain critical: secure coding, least privilege, supply chain verification, and continuous monitoring are essential for MCP and AI workloads.
- MCP introduces new risks—such as prompt injection, tool poisoning, and excessive permissions—that require both traditional and AI-specific controls.
- Use strong authentication, authorization, and token management practices, leveraging external identity providers like Microsoft Entra ID where possible.
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

Next: [Chapter 3: Getting Started](../03-GettingStarted/README.md)

**Disclaimer**:  
This document has been translated using the AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.