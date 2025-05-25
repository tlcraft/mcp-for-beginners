<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T22:53:54+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "zh"
}
-->
# 安全最佳实践

采用 Model Context Protocol (MCP) 为 AI 驱动的应用带来了强大的新功能，但也引入了超出传统软件风险的独特安全挑战。除了安全编码、最小权限和供应链安全等既有关注点外，MCP 和 AI 工作负载还面临诸如提示注入、工具投毒和动态工具修改等新威胁。如果未能妥善管理，这些风险可能导致数据泄露、隐私侵犯和系统异常行为。

本课程探讨了与 MCP 相关的最重要安全风险——包括身份验证、授权、权限过度、间接提示注入和供应链漏洞——并提供了可操作的控制措施和最佳实践来减轻这些风险。你还将学习如何利用微软的解决方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security 来加强你的 MCP 实施。通过理解并应用这些控制措施，你可以大幅降低安全漏洞的可能性，确保你的 AI 系统保持稳健且值得信赖。

# 学习目标

完成本课程后，你将能够：

- 识别并解释 Model Context Protocol (MCP) 带来的独特安全风险，包括提示注入、工具投毒、权限过度和供应链漏洞。
- 描述并应用有效的缓解控制措施，如强身份验证、最小权限、安全令牌管理和供应链验证，以降低 MCP 的安全风险。
- 了解并利用微软解决方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security，保护 MCP 和 AI 工作负载。
- 认识到验证工具元数据、监控动态变化以及防御间接提示注入攻击的重要性。
- 将成熟的安全最佳实践（如安全编码、服务器加固和零信任架构）整合到 MCP 实施中，减少安全漏洞的发生和影响。

# MCP 安全控制

任何访问重要资源的系统都会面临隐含的安全挑战。安全挑战通常可以通过正确应用基本的安全控制和概念来解决。由于 MCP 是新近定义的协议，其规范正在快速变化，随着协议的演进，其安全控制也将逐渐成熟，实现与企业及既有安全架构和最佳实践的更好整合。

微软发布的[数字防御报告](https://aka.ms/mddr)指出，98% 的已报告安全事件可通过良好的安全卫生习惯加以防止。对任何类型的安全事件而言，最好的防护是确保基础安全卫生、遵循安全编码最佳实践以及强化供应链安全——这些经过验证的传统做法仍然是降低安全风险的关键。

接下来，我们来看一些在采用 MCP 时可以开始采取的安全风险应对措施。

# MCP 服务器身份验证（适用于 2025 年 4 月 26 日之前的 MCP 实现）

> **Note:** 以下信息截至 2025 年 4 月 26 日为准。MCP 协议持续演进，未来的实现可能引入新的身份验证模式和控制。有关最新更新和指导，请始终参考 [MCP 规范](https://spec.modelcontextprotocol.io/) 及官方 [MCP GitHub 仓库](https://github.com/modelcontextprotocol)。

### 问题描述  
最初的 MCP 规范假设开发者将自行编写身份验证服务器，这需要了解 OAuth 及相关安全约束。MCP 服务器充当 OAuth 2.0 授权服务器，直接管理所需的用户身份验证，而非委托给 Microsoft Entra ID 等外部服务。截至 2025 年 4 月 26 日，MCP 规范更新允许 MCP 服务器将用户身份验证委托给外部服务。

### 风险  
- MCP 服务器中错误配置的授权逻辑可能导致敏感数据泄露和访问控制错误。
- 本地 MCP 服务器上的 OAuth 令牌被盗，攻击者可利用该令牌冒充 MCP 服务器，访问 OAuth 令牌所对应的服务资源和数据。

### 缓解措施  
- **审查并强化授权逻辑：** 仔细审核 MCP 服务器的授权实现，确保只有预期的用户和客户端能够访问敏感资源。实用指导请参见 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 和 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **执行安全令牌管理：** 遵循 [微软关于令牌验证和生命周期的最佳实践](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，防止访问令牌被滥用，降低令牌重放或被盗风险。
- **保护令牌存储：** 始终安全存储令牌，并对其在静态和传输过程中的数据进行加密。实施建议请参见 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# MCP 服务器权限过度

### 问题描述  
MCP 服务器可能被授予了访问服务/资源时权限过大的权限。例如，作为 AI 销售应用一部分的 MCP 服务器连接企业数据存储时，访问权限应仅限于销售数据，而不应允许访问存储中的所有文件。回归最小权限原则（最古老的安全原则之一），任何资源都不应拥有超出其完成预期任务所需的权限。AI 在此方面的挑战更大，因为为了保证灵活性，准确界定所需权限往往较为困难。

### 风险  
- 权限过度可能导致 MCP 服务器能够窃取或篡改其本不应访问的数据。如果数据包含个人身份信息（PII），这还会带来隐私问题。

### 缓解措施  
- **应用最小权限原则：** 仅授予 MCP 服务器执行所需任务的最低权限。定期审查并更新权限，确保不超出必要范围。详细指导请参见 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **使用基于角色的访问控制 (RBAC)：** 为 MCP 服务器分配严格限定于特定资源和操作的角色，避免赋予广泛或不必要的权限。
- **监控和审计权限：** 持续监控权限使用情况，审计访问日志，及时发现并纠正权限过度或未使用的权限。

# 间接提示注入攻击

### 问题描述

恶意或被攻破的 MCP 服务器可能带来重大风险，如泄露客户数据或引发意外操作。这些风险在基于 AI 和 MCP 的工作负载中尤为突出，包括：

- **提示注入攻击**：攻击者在提示或外部内容中嵌入恶意指令，导致 AI 系统执行非预期操作或泄露敏感数据。了解详情：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **工具投毒**：攻击者操控工具元数据（如描述或参数），影响 AI 行为，可能绕过安全控制或窃取数据。详情见：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **跨域提示注入**：恶意指令嵌入文档、网页或邮件，AI 处理后导致数据泄露或篡改。
- **动态工具修改（Rug Pulls）**：工具定义在用户批准后被更改，引入新的恶意行为而用户不知情。

这些漏洞凸显了在环境中集成 MCP 服务器和工具时，必须进行严格验证、监控和安全控制。欲深入了解，请参阅上述链接资料。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.zh.png)

**间接提示注入**（又称跨域提示注入或 XPIA）是生成式 AI 系统中的关键漏洞，包括使用 Model Context Protocol (MCP) 的系统。攻击中，恶意指令隐藏在外部内容（如文档、网页或邮件）中。当 AI 系统处理这些内容时，可能将嵌入的指令误认为合法用户命令，导致数据泄露、有害内容生成或用户交互被操控。详细解释及实际案例见 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)。

一种特别危险的形式是 **工具投毒**。攻击者将恶意指令注入 MCP 工具的元数据（如工具描述或参数）中。由于大型语言模型（LLM）依赖这些元数据决定调用哪个工具，受污染的描述可能诱导模型执行未授权的工具调用或绕过安全控制。这种操控通常对终端用户不可见，但 AI 系统会解读并执行。此风险在托管 MCP 服务器环境中尤为突出，因工具定义可在用户批准后被更新，这种情况有时被称为“[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)”。即原本安全的工具可能被修改为执行恶意操作，如数据窃取或系统行为更改，且用户不知情。更多内容见 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.zh.png)

## 风险  
AI 非预期行为带来多种安全风险，包括数据泄露和隐私侵犯。

### 缓解措施  
### 使用 Prompt Shields 防御间接提示注入攻击
-----------------------------------------------------------------------------

**AI Prompt Shields** 是微软开发的解决方案，用于防御直接和间接的提示注入攻击。其作用机制包括：

1.  **检测与过滤**：Prompt Shields 利用先进的机器学习算法和自然语言处理技术，检测并过滤嵌入在文档、网页或邮件等外部内容中的恶意指令。
    
2.  **聚焦技术（Spotlighting）**：帮助 AI 系统区分有效的系统指令和潜在不可信的外部输入。通过转换输入文本，使其更符合模型的相关性，聚焦技术确保 AI 更准确识别并忽略恶意指令。
    
3.  **分隔符与数据标记**：在系统消息中包含分隔符，明确输入文本的位置，帮助 AI 系统识别并区分用户输入与潜在有害的外部内容。数据标记扩展了这一概念，使用特殊标记突出显示可信与不可信数据的边界。
    
4.  **持续监控与更新**：微软持续监控并更新 Prompt Shields，以应对新的和不断演变的威胁。这种主动防御确保防护措施有效抵御最新攻击手法。
    
5. **与 Azure Content Safety 集成**：Prompt Shields 是 Azure AI Content Safety 套件的一部分，该套件提供检测越狱尝试、有害内容及其他 AI 安全风险的额外工具。

你可以在[Prompt Shields 文档](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)中了解更多关于 AI Prompt Shields 的内容。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.zh.png)

### 供应链安全

供应链安全在 AI 时代依然至关重要，但供应链的范围已扩大。除了传统的代码包外，你现在必须严格验证和监控所有 AI 相关组件，包括基础模型、嵌入服务、上下文提供者和第三方 API。若管理不当，这些都可能引入漏洞或风险。

**AI 和 MCP 供应链安全的关键实践：**  
- **集成前验证所有组件：** 不仅包括开源库，还涵盖 AI 模型、数据源和外部 API。始终检查来源、许可和已知漏洞。  
- **维护安全部署管道：** 使用集成安全扫描的自动化 CI/CD 管道，及早发现问题。确保仅将受信任的制品部署到生产环境。  
- **持续监控与审计：** 对所有依赖项（包括模型和数据服务）实施持续监控，以检测新漏洞或供应链攻击。  
- **应用最小权限和访问控制：** 限制模型、数据和服务的访问，仅限 MCP 服务器正常运行所需。  
- **快速响应威胁：** 建立补丁或替换受损组件的流程，若检测到安全事件，及时更换密钥或凭据。

[GitHub Advanced Security](https://github.com/security/advanced-security) 提供密钥扫描、依赖扫描和 CodeQL 分析等功能。这些工具可与 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 和 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 集成，帮助团队识别并减轻代码及 AI 供应链组件的漏洞。

微软内部也对所有产品实施了广泛的供应链安全实践。详情请见 [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。

# 既有安全最佳实践提升你的 MCP 实施安全态势

任何 MCP 实施都继承了其所构建的组织环境的现有安全态势，因此在考虑 MCP 作为整体 AI 系统组成部分的安全性时，建议提升整体现有安全态势。以下成熟的安全控制尤为相关：

- AI 应用中的安全编码最佳实践——防范 [OWASP Top 10](https://owasp.org/www-project-top-ten/) 和 [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)，使用安全保险库管理密钥和令牌，实现所有应用组件间的端到端安全通信等。
- 服务器加固——尽可能启用多因素认证（MFA），保持补丁更新，将服务器集成第三方身份提供商进行访问控制等。
- 设备、基础设施和应用保持补丁最新。
- 安全监控——实施 AI 应用（包括 MCP 客户端/服务器）的日志记录和监控，并将日志发送至集中式 SIEM 以检测异常活动。
- 零信任架构——通过网络和身份控制逻辑隔离组件，最大限度减少 AI 应用遭受入侵时的横向移动。

# 关键要点

- 安全基础依然至关重要：安全编码、最小权限、供应链验证和持续监控是 MCP 和 AI 工作负载的核心。
- MCP 引入了新风险，如提示注入、工具投毒和权限过度，需要结合传统和 AI 特有的控制措施应对。
- 采用强身份验证、授权和令牌管理实践，尽可能利用 Microsoft Entra ID 等外部身份提供商。
- 通过验证工具元数据、监控动态变化及使用 Microsoft Prompt Shields 等解决方案，防范间接提示注入和工具投毒。
- 对 AI 供应链中的所有组件——包括模型、嵌入和上下文提供者——保持与代码依赖同等严格的安全态度。
- 紧跟 MCP 规范的演进，积极参与社区，共同推动安全标准的完善。

# 附加资源

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
- [微软保障软件供应链安全之旅](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [安全的最小权限访问（Microsoft）](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [令牌验证和生命周期的最佳实践](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [使用安全的令牌存储和令牌加密（YouTube）](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [将 Azure API 管理用作 MCP 的认证网关](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [使用 Microsoft Entra ID 认证 MCP 服务器](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 下一步

下一步: [第3章：入门](/03-GettingStarted/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们努力确保准确性，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于关键信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或曲解，我们不承担任何责任。