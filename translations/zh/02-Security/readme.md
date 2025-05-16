<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-16T14:43:54+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "zh"
}
-->
# 安全最佳实践

采用 Model Context Protocol (MCP) 为 AI 驱动的应用带来了强大的新功能，但同时也引入了超越传统软件风险的独特安全挑战。除了安全编码、最小权限和供应链安全等既有问题外，MCP 和 AI 工作负载还面临诸如提示注入、工具中毒和动态工具修改等新威胁。如果管理不当，这些风险可能导致数据外泄、隐私泄露和系统行为异常。

本课程探讨了与 MCP 相关的最重要安全风险——包括身份验证、授权、权限过度、间接提示注入和供应链漏洞，并提供了可操作的控制措施和最佳实践来缓解这些风险。你还将学习如何利用 Microsoft 的解决方案，如 Prompt Shields、Azure 内容安全和 GitHub 高级安全，来加强 MCP 的实施。通过理解并应用这些控制措施，你可以大幅降低安全漏洞的可能性，确保 AI 系统的稳健和可信。

# 学习目标

完成本课程后，你将能够：

- 识别并解释 Model Context Protocol (MCP) 引入的独特安全风险，包括提示注入、工具中毒、权限过度和供应链漏洞。
- 描述并应用有效的缓解措施，如强身份验证、最小权限、安全令牌管理和供应链验证，以应对 MCP 的安全风险。
- 了解并利用 Microsoft 解决方案，如 Prompt Shields、Azure 内容安全和 GitHub 高级安全，保护 MCP 和 AI 工作负载。
- 认识验证工具元数据、监控动态变化以及防御间接提示注入攻击的重要性。
- 将成熟的安全最佳实践——如安全编码、服务器加固和零信任架构——整合到 MCP 实施中，降低安全漏洞的发生率和影响。

# MCP 安全控制

任何访问重要资源的系统都存在内在的安全挑战。通常通过正确应用基本的安全控制和理念可以解决这些问题。由于 MCP 是新定义的协议，规范正在快速变化和演进。随着协议的成熟，其安全控制也将逐步完善，实现与企业和成熟安全架构及最佳实践的更好整合。

微软发布的[数字防御报告](https://aka.ms/mddr)指出，98% 的报告漏洞本可通过健全的安全卫生措施避免，而防止任何类型漏洞的最佳保护是做好基础安全卫生、安全编码最佳实践和供应链安全——这些经验证的做法仍然是降低安全风险的关键。

下面我们来看一些采用 MCP 时可以开始应对安全风险的方法。

# MCP 服务器身份验证（针对 2025 年 4 月 26 日之前的 MCP 实现）

> **Note:** 以下信息截至 2025 年 4 月 26 日有效。MCP 协议持续演进，未来实现可能引入新的身份验证模式和控制。有关最新更新和指导，请始终参考 [MCP 规范](https://spec.modelcontextprotocol.io/) 和官方 [MCP GitHub 仓库](https://github.com/modelcontextprotocol)。

### 问题描述  
最初的 MCP 规范假设开发者会自行编写身份验证服务器，这需要了解 OAuth 及相关安全限制。MCP 服务器充当 OAuth 2.0 授权服务器，直接管理用户身份验证，而不是委托给诸如 Microsoft Entra ID 之类的外部服务。自 2025 年 4 月 26 日起，MCP 规范更新允许 MCP 服务器将用户身份验证委托给外部服务。

### 风险
- MCP 服务器中错误配置的授权逻辑可能导致敏感数据泄露和访问控制不当。
- 本地 MCP 服务器上的 OAuth 令牌被盗。若被盗，攻击者可冒充 MCP 服务器，访问该令牌对应服务的资源和数据。

### 缓解措施
- **审查并强化授权逻辑：** 认真审核 MCP 服务器的授权实现，确保只有预期的用户和客户端可以访问敏感资源。具体指导请参见 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 和 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **执行安全令牌策略：** 遵循 [Microsoft 的令牌验证和生命周期最佳实践](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，防止访问令牌被滥用，降低令牌重放或盗用风险。
- **保护令牌存储：** 始终安全存储令牌，使用加密保护静态和传输中的令牌。实施技巧请参考 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# MCP 服务器权限过度

### 问题描述  
MCP 服务器可能被授予了访问服务或资源的过多权限。例如，作为 AI 销售应用一部分的 MCP 服务器连接企业数据存储时，应仅限访问销售数据，而不应访问存储中的所有文件。回顾最小权限原则（最古老的安全原则之一），任何资源都不应拥有超过执行其预期任务所需的权限。AI 领域对此尤具挑战，因为为了灵活性，很难准确界定所需权限。

### 风险  
- 赋予过多权限可能导致数据外泄或修改 MCP 服务器本不应访问的数据。如果数据包含个人身份信息（PII），还会引发隐私问题。

### 缓解措施
- **应用最小权限原则：** 仅授予 MCP 服务器完成任务所需的最低权限。定期审查并更新权限，确保不过度。详细指导见 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **使用基于角色的访问控制 (RBAC)：** 为 MCP 服务器分配严格限定资源和操作的角色，避免广泛或不必要的权限。
- **监控和审计权限：** 持续监控权限使用情况，审计访问日志，及时发现并纠正过度或未使用的权限。

# 间接提示注入攻击

### 问题描述

恶意或被攻破的 MCP 服务器可能带来重大风险，暴露客户数据或触发意外行为。这些风险在 AI 和基于 MCP 的工作负载中尤为突出：

- **提示注入攻击**：攻击者在提示或外部内容中嵌入恶意指令，使 AI 系统执行非预期操作或泄露敏感数据。详情请见：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **工具中毒**：攻击者篡改工具元数据（如描述或参数），影响 AI 行为，可能绕过安全控制或外泄数据。详情：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **跨域提示注入**：恶意指令嵌入文档、网页或邮件，AI 处理时导致数据泄露或被操控。
- **动态工具修改（Rug Pulls）**：工具定义在用户批准后被更改，带来新的恶意行为，用户不知情。

这些漏洞凸显了在将 MCP 服务器和工具集成到环境中时，必须进行严格验证、监控和安全控制。欲深入了解，请参阅上述链接。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.zh.png)

**间接提示注入**（也称为跨域提示注入或 XPIA）是生成式 AI 系统中的严重漏洞，包括使用 MCP 的系统。攻击者将恶意指令隐藏在外部内容中（如文档、网页或邮件），AI 处理时可能将这些指令误判为合法用户命令，导致非预期操作，如数据泄露、生成有害内容或操控用户交互。详细说明及实际案例请见 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)。

一种特别危险的攻击形式是 **工具中毒**。攻击者在 MCP 工具的元数据（如工具描述或参数）中注入恶意指令。由于大型语言模型（LLM）依赖这些元数据决定调用哪些工具，被篡改的描述可能诱使模型执行未授权的工具调用或绕过安全控制。这些操控通常对终端用户不可见，但 AI 系统会解读并执行。该风险在托管 MCP 服务器环境中更为严重，工具定义可在用户批准后被修改，这种情况有时被称为“[Rug Pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)”。此前安全的工具可能被修改为执行恶意操作，如数据外泄或改变系统行为，用户毫不知情。更多信息请参见 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.zh.png)

## 风险  
AI 的非预期行为带来多种安全风险，包括数据外泄和隐私泄露。

### 缓解措施  
### 使用 Prompt Shields 防御间接提示注入攻击
-----------------------------------------------------------------------------

**AI Prompt Shields** 是微软开发的解决方案，用于防御直接和间接提示注入攻击。它们通过以下方式发挥作用：

1.  **检测与过滤**：Prompt Shields 利用先进的机器学习算法和自然语言处理技术，检测并过滤嵌入在外部内容（如文档、网页或邮件）中的恶意指令。
    
2.  **聚焦（Spotlighting）**：该技术帮助 AI 系统区分有效的系统指令和潜在不可信的外部输入。通过转换输入文本，使其对模型更具相关性，聚焦技术确保 AI 能更好地识别并忽略恶意指令。
    
3.  **分隔符与数据标记**：在系统消息中包含分隔符，明确输入文本的位置，帮助 AI 系统识别并分离用户输入与潜在有害的外部内容。数据标记进一步使用特殊标记突出显示可信与不可信数据的边界。
    
4.  **持续监控与更新**：微软持续监控并更新 Prompt Shields，以应对新的和不断演变的威胁。这种主动防御确保防护措施对最新攻击技术保持有效。
    
5. **与 Azure 内容安全集成**：Prompt Shields 是 Azure AI 内容安全套件的一部分，提供检测越狱尝试、有害内容及其他 AI 应用安全风险的附加工具。

更多关于 AI Prompt Shields 的内容，请参见[Prompt Shields 文档](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.zh.png)

### 供应链安全

供应链安全在 AI 时代依然至关重要，但供应链的范围已扩大。除了传统代码包外，还必须严格验证和监控所有 AI 相关组件，包括基础模型、嵌入服务、上下文提供者和第三方 API。这些组件若管理不善，均可能带来漏洞或风险。

**AI 和 MCP 供应链安全的关键实践：**
- **集成前验证所有组件：** 不仅是开源库，还包括 AI 模型、数据源和外部 API。始终检查来源、许可和已知漏洞。
- **维护安全的部署流水线：** 使用集成安全扫描的自动化 CI/CD 流水线，及早发现问题。确保仅可信工件部署到生产环境。
- **持续监控和审计：** 对所有依赖项（包括模型和数据服务）进行持续监控，及时发现新的漏洞或供应链攻击。
- **应用最小权限和访问控制：** 限制对模型、数据和服务的访问，仅允许 MCP 服务器正常运行所需的权限。
- **快速响应威胁：** 建立补丁或替换受损组件的流程，发现漏洞时及时轮换密钥或凭据。

[GitHub 高级安全](https://github.com/security/advanced-security) 提供秘密扫描、依赖扫描和 CodeQL 分析等功能。这些工具可与 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 和 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 集成，帮助团队识别和缓解代码及 AI 供应链组件中的漏洞。

微软内部也对所有产品实施了广泛的供应链安全实践。详情请参见 [微软软件供应链安全之旅](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。

# 成熟的安全最佳实践提升你的 MCP 实施安全态势

任何 MCP 实施都继承了其所依赖的组织环境的现有安全态势，因此在考虑 MCP 作为整体 AI 系统组件的安全时，建议提升整体现有安全水平。以下成熟的安全控制尤为相关：

- AI 应用中的安全编码最佳实践——防护[OWASP Top 10](https://owasp.org/www-project-top-ten/)、[LLM 版 OWASP Top 10](https://genai.owasp.org/download/43299/?tmstv=1731900559)，使用安全保管库管理密钥和令牌，实现应用组件间的端到端安全通信等。
- 服务器加固——尽可能使用多因素认证，保持补丁更新，将服务器集成第三方身份提供者进行访问控制等。
- 保持设备、基础设施和应用程序补丁及时更新。
- 安全监控——实施 AI 应用（包括 MCP 客户端/服务器）的日志记录和监控，将日志发送到集中 SIEM 以检测异常活动。
- 零信任架构——通过网络和身份控制逻辑隔离组件，最大限度减少 AI 应用被攻破时的横向移动。

# 关键要点

- 安全基础仍然至关重要：安全编码、最小权限、供应链验证和持续监控对 MCP 和 AI 工作负载不可或缺。
- MCP 引入了新风险——如提示注入、工具中毒和权限过度——需要结合传统与 AI 特有的控制措施。
- 使用强身份验证、授权和令牌管理实践，尽可能利用外部身份提供者如 Microsoft Entra ID。
- 通过验证工具元数据、监控动态变化以及使用微软 Prompt Shields 等解决方案，防范间接提示注入和工具中毒。
- 对 AI 供应链中的所有组件——包括模型、嵌入和上下文提供者——应用与代码依赖相同的严格要求。
- 紧跟 MCP 规范的演进，积极参与社区，共同推动安全标准的发展。

# 其他资源

- [Microsoft 数字防御报告](https://aka.ms/mddr)
- [MCP 规范](https://spec.modelcontextprotocol.io/)
- [MCP 中的提示注入（Simon Willison）](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [工具中毒攻击（Invariant Labs）](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [MCP 中的 Rug Pulls（Wiz Security）](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields 文档（微软）](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [微软软件供应链安全之旅](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [安全的最小权限访问（Microsoft）](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [令牌验证和有效期的最佳实践](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [使用安全令牌存储和加密令牌（YouTube）](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [将 Azure API 管理作为 MCP 的身份验证网关](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [使用 Microsoft Entra ID 进行 MCP 服务器身份验证](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 下一步

下一步: [第3章：入门指南](/03-GettingStarted/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们力求准确，但请注意，自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。