<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-13T16:36:33+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "zh"
}
-->
# 安全最佳实践

采用 Model Context Protocol (MCP) 为 AI 驱动的应用带来了强大的新功能，但也引入了超越传统软件风险的独特安全挑战。除了已知的安全编码、最小权限和供应链安全等问题外，MCP 和 AI 工作负载还面临诸如提示注入、工具中毒和动态工具修改等新威胁。如果管理不当，这些风险可能导致数据泄露、隐私侵犯和系统行为异常。

本课将探讨与 MCP 相关的最重要安全风险——包括身份验证、授权、权限过度、间接提示注入和供应链漏洞——并提供可操作的控制措施和最佳实践来减轻这些风险。你还将学习如何利用 Microsoft 解决方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security，来强化你的 MCP 实施。通过理解和应用这些控制措施，你可以显著降低安全漏洞的可能性，确保 AI 系统的稳健性和可信赖性。

# 学习目标

完成本课后，你将能够：

- 识别并解释 Model Context Protocol (MCP) 引入的独特安全风险，包括提示注入、工具中毒、权限过度和供应链漏洞。
- 描述并应用有效的缓解控制措施，如强身份验证、最小权限、安全令牌管理和供应链验证，以应对 MCP 安全风险。
- 理解并利用 Microsoft 解决方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security，保护 MCP 和 AI 工作负载。
- 认识验证工具元数据、监控动态变化以及防御间接提示注入攻击的重要性。
- 将已建立的安全最佳实践（如安全编码、服务器加固和零信任架构）整合到 MCP 实施中，降低安全漏洞的发生概率和影响。

# MCP 安全控制

任何访问重要资源的系统都面临隐含的安全挑战。通常可以通过正确应用基本的安全控制和概念来应对这些挑战。由于 MCP 是新定义的协议，规范正在快速变化，随着协议的发展，其安全控制也将逐步成熟，从而更好地与企业和既有的安全架构及最佳实践集成。

[Microsoft Digital Defense Report](https://aka.ms/mddr) 中的研究表明，98% 的报告安全漏洞本可通过严格的安全卫生措施避免。防止任何类型安全漏洞的最佳保护是确保基础安全卫生、遵循安全编码最佳实践和供应链安全——这些经过验证的做法仍然是降低安全风险的关键。

让我们看看在采用 MCP 时，你可以如何开始应对安全风险。

> **Note:** 以下信息截至 **2025 年 5 月 29 日** 是准确的。MCP 协议持续演进，未来的实现可能引入新的身份验证模式和控制措施。有关最新更新和指导，请始终参考 [MCP 规范](https://spec.modelcontextprotocol.io/)、官方 [MCP GitHub 仓库](https://github.com/modelcontextprotocol) 以及 [安全最佳实践页面](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)。

### 问题陈述  
最初的 MCP 规范假设开发者会自行编写身份验证服务器，这需要了解 OAuth 及相关安全约束。MCP 服务器充当 OAuth 2.0 授权服务器，直接管理所需的用户身份验证，而非委托给外部服务（如 Microsoft Entra ID）。截至 **2025 年 4 月 26 日**，MCP 规范更新允许 MCP 服务器将用户身份验证委托给外部服务。

### 风险
- MCP 服务器中配置错误的授权逻辑可能导致敏感数据泄露和访问控制错误。
- 本地 MCP 服务器上的 OAuth 令牌被盗。若令牌被窃取，攻击者可冒充 MCP 服务器访问该令牌对应服务的资源和数据。

#### 令牌直通
授权规范明确禁止令牌直通，因为它带来多种安全风险，包括：

#### 绕过安全控制
MCP 服务器或下游 API 可能实施重要的安全控制，如速率限制、请求验证或流量监控，这些依赖于令牌的受众或其他凭证约束。如果客户端能直接使用令牌访问下游 API，而 MCP 服务器未能正确验证令牌或确保令牌是为正确服务颁发的，则绕过了这些控制。

#### 责任追踪和审计问题
当客户端使用上游颁发的访问令牌调用时，MCP 服务器无法识别或区分不同的 MCP 客户端。  
下游资源服务器的日志可能显示请求来自不同身份的源，而非实际转发令牌的 MCP 服务器。  
这两点都会增加事件调查、控制和审计的难度。  
如果 MCP 服务器在传递令牌时未验证其声明（如角色、权限或受众）或其他元数据，持有被盗令牌的恶意行为者可利用服务器作为数据外泄的代理。

#### 信任边界问题
下游资源服务器对特定实体授予信任，该信任可能包括对来源或客户端行为模式的假设。破坏此信任边界可能导致意外问题。  
如果令牌被多个服务接受且未经过适当验证，攻击者攻破其中一个服务后可利用该令牌访问其他关联服务。

#### 未来兼容性风险
即使 MCP 服务器当前作为“纯代理”，未来可能需要添加安全控制。起始时正确区分令牌受众，有助于安全模型的演进。

### 缓解控制

**MCP 服务器不得接受未明确为其颁发的任何令牌**

- **审查并强化授权逻辑：** 认真审计 MCP 服务器的授权实现，确保只有预期的用户和客户端能访问敏感资源。实用指导请参见 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 和 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **执行安全令牌实践：** 遵循 [Microsoft 关于令牌验证和生命周期的最佳实践](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，防止访问令牌滥用，降低令牌重放或被盗风险。
- **保护令牌存储：** 始终安全存储令牌，并使用加密保护令牌在静态和传输中的安全。实施建议见 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# MCP 服务器权限过度

### 问题陈述  
MCP 服务器可能被授予了访问服务/资源的过度权限。例如，作为 AI 销售应用一部分的 MCP 服务器连接企业数据存储时，应仅限访问销售数据，而不应访问存储中的所有文件。回归最小权限原则（最古老的安全原则之一），任何资源的权限都不应超过其执行预期任务所需。AI 在这方面带来更大挑战，因为为了灵活性，准确界定所需权限较为困难。

### 风险  
- 过度权限可能导致 MCP 服务器访问或修改其不应接触的数据，若数据包含个人身份信息（PII），还可能引发隐私问题。

### 缓解控制  
- **应用最小权限原则：** 仅授予 MCP 服务器执行任务所需的最低权限。定期审查和更新权限，确保不超出必要范围。详细指导见 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **使用基于角色的访问控制 (RBAC)：** 为 MCP 服务器分配严格限定特定资源和操作的角色，避免广泛或不必要的权限。
- **监控和审计权限：** 持续监控权限使用情况，审计访问日志，及时发现并纠正过度或未使用的权限。

# 间接提示注入攻击

### 问题陈述

恶意或被攻破的 MCP 服务器可能带来重大风险，暴露客户数据或触发非预期操作。这些风险在 AI 和基于 MCP 的工作负载中尤为突出，包括：

- **提示注入攻击**：攻击者在提示或外部内容中嵌入恶意指令，导致 AI 系统执行非预期操作或泄露敏感数据。详见：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **工具中毒**：攻击者操纵工具元数据（如描述或参数），影响 AI 行为，可能绕过安全控制或窃取数据。详情：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **跨域提示注入**：恶意指令嵌入文档、网页或邮件，AI 处理时导致数据泄露或操控。
- **动态工具修改（Rug Pulls）**：用户批准后工具定义被更改，悄然引入恶意行为。

这些漏洞凸显了在集成 MCP 服务器和工具时，必须实施严格的验证、监控和安全控制。更多内容请参见上述链接。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.zh.png)

**间接提示注入**（又称跨域提示注入或 XPIA）是生成式 AI 系统中的关键漏洞，包括使用 Model Context Protocol (MCP) 的系统。攻击者将恶意指令隐藏在外部内容（如文档、网页或邮件）中，AI 处理时可能将其误解为合法用户命令，导致数据泄露、生成有害内容或操控用户交互。详见 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/) 了解详细解释和实际案例。

一种特别危险的攻击形式是 **工具中毒**。攻击者将恶意指令注入 MCP 工具的元数据（如工具描述或参数）。由于大型语言模型（LLM）依赖这些元数据决定调用哪些工具，受损的描述可能诱使模型执行未授权的工具调用或绕过安全控制。这些操控通常对终端用户不可见，但 AI 系统会解读并执行。此风险在托管 MCP 服务器环境中尤为突出，工具定义可在用户批准后更新，这种情况有时称为“[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)”。在此情形下，原本安全的工具可能被修改为执行恶意操作，如数据外泄或系统行为改变，用户不知情。更多信息见 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.zh.png)

## 风险  
非预期的 AI 行为带来多种安全风险，包括数据泄露和隐私侵犯。

### 缓解控制  
### 使用 Prompt Shields 防御间接提示注入攻击
-----------------------------------------------------------------------------

**AI Prompt Shields** 是 Microsoft 开发的解决方案，用于防御直接和间接的提示注入攻击。其作用包括：

1.  **检测与过滤**：Prompt Shields 利用先进的机器学习算法和自然语言处理技术，检测并过滤嵌入在文档、网页或邮件等外部内容中的恶意指令。
    
2.  **聚焦技术**：帮助 AI 系统区分有效的系统指令和潜在不可信的外部输入。通过转换输入文本，使其更贴合模型需求，聚焦技术确保 AI 更好地识别并忽略恶意指令。
    
3.  **分隔符和数据标记**：在系统消息中包含分隔符，明确指出输入文本的位置，帮助 AI 系统识别并区分用户输入与潜在有害的外部内容。数据标记则通过特殊标记突出可信与不可信数据的边界。
    
4.  **持续监控与更新**：Microsoft 持续监控并更新 Prompt Shields，以应对新兴和不断演变的威胁。这种主动防御确保防护措施对最新攻击技术保持有效。
    
5. **与 Azure Content Safety 集成：** Prompt Shields 是 Azure AI Content Safety 套件的一部分，提供额外工具检测越狱尝试、有害内容及 AI 应用中的其他安全风险。

你可以在 [Prompt Shields 文档](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) 中了解更多关于 AI Prompt Shields 的信息。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.zh.png)

### 供应链安全
供应链安全在人工智能时代依然至关重要，但供应链的范围已经扩大。除了传统的代码包之外，现在还必须严格验证和监控所有与 AI 相关的组件，包括基础模型、嵌入服务、上下文提供者以及第三方 API。如果管理不当，这些都可能带来漏洞或风险。

**AI 和 MCP 供应链安全的关键实践：**
- **集成前验证所有组件：** 不仅包括开源库，还包括 AI 模型、数据源和外部 API。始终检查来源、许可和已知漏洞。
- **维护安全的部署流水线：** 使用集成安全扫描的自动化 CI/CD 流水线，及早发现问题。确保只有可信的工件被部署到生产环境。
- **持续监控和审计：** 对所有依赖项（包括模型和数据服务）实施持续监控，以检测新的漏洞或供应链攻击。
- **应用最小权限和访问控制：** 限制对模型、数据和服务的访问，仅允许 MCP 服务器正常运行所需的权限。
- **快速响应威胁：** 建立补丁或替换受损组件的流程，若检测到泄露，及时更换密钥或凭据。

[GitHub Advanced Security](https://github.com/security/advanced-security) 提供了秘密扫描、依赖扫描和 CodeQL 分析等功能。这些工具可与 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 和 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 集成，帮助团队识别并缓解代码及 AI 供应链组件中的漏洞。

微软内部也对所有产品实施了广泛的供应链安全措施。详情请参见 [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。


# 已建立的安全最佳实践，提升您的 MCP 实施安全态势

任何 MCP 实施都继承了其所构建的组织环境的现有安全态势，因此在将 MCP 作为整体 AI 系统的一个组件考虑安全时，建议提升整体现有的安全态势。以下已建立的安全控制尤为重要：

-   AI 应用中的安全编码最佳实践——防范[OWASP Top 10](https://owasp.org/www-project-top-ten/)、[LLM 的 OWASP Top 10](https://genai.owasp.org/download/43299/?tmstv=1731900559)，使用安全保管库存储密钥和令牌，实现所有应用组件间的端到端安全通信等。
-   服务器加固——尽可能使用多因素认证，保持补丁更新，将服务器与第三方身份提供者集成以控制访问等。
-   保持设备、基础设施和应用程序的补丁更新。
-   安全监控——对 AI 应用（包括 MCP 客户端/服务器）实施日志记录和监控，将日志发送到集中式 SIEM 以检测异常活动。
-   零信任架构——通过网络和身份控制逻辑隔离组件，最大限度减少 AI 应用被攻破时的横向移动。

# 关键要点

- 安全基础依然关键：安全编码、最小权限、供应链验证和持续监控对 MCP 和 AI 工作负载至关重要。
- MCP 引入了新的风险——如提示注入、工具中毒和权限过度——需要传统和 AI 特定的控制措施。
- 使用强健的身份验证、授权和令牌管理实践，尽可能利用 Microsoft Entra ID 等外部身份提供者。
- 通过验证工具元数据、监控动态变化以及使用 Microsoft Prompt Shields 等解决方案，防范间接提示注入和工具中毒。
- 对 AI 供应链中的所有组件——包括模型、嵌入和上下文提供者——都应像对待代码依赖一样严格对待。
- 关注 MCP 规范的演进，并积极参与社区，共同推动安全标准的发展。

# 其他资源

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

### 下一步

下一步：[第3章：入门](../03-GettingStarted/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。