<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-16T23:06:59+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "zh"
}
-->
# MCP 安全最佳实践

在使用 MCP 服务器时，请遵循以下安全最佳实践，以保护您的数据、基础设施和用户：

1. **输入验证**：始终验证和清理输入，防止注入攻击和混淆代理问题。
2. **访问控制**：为您的 MCP 服务器实施适当的身份验证和授权，采用细粒度权限管理。
3. **安全通信**：所有与 MCP 服务器的通信均使用 HTTPS/TLS，并考虑对敏感数据添加额外加密。
4. **速率限制**：实施速率限制，防止滥用、拒绝服务攻击，并管理资源消耗。
5. **日志记录与监控**：监控 MCP 服务器的可疑活动，实施全面的审计追踪。
6. **安全存储**：使用适当的静态加密保护敏感数据和凭据。
7. **令牌管理**：通过验证和清理所有模型输入输出，防止令牌传递漏洞。
8. **会话管理**：实施安全的会话处理，防止会话劫持和固定攻击。
9. **工具执行沙箱**：在隔离环境中运行工具执行，防止被攻破时的横向移动。
10. **定期安全审计**：定期对 MCP 实现和依赖项进行安全审查。
11. **提示验证**：扫描并过滤输入和输出提示，防止提示注入攻击。
12. **身份验证委托**：使用成熟的身份提供者，而非自定义身份验证。
13. **权限范围划分**：为每个工具和资源实施细粒度权限，遵循最小权限原则。
14. **数据最小化**：仅暴露每个操作所需的最少数据，降低风险面。
15. **自动化漏洞扫描**：定期扫描 MCP 服务器及其依赖项中的已知漏洞。

## MCP 安全最佳实践支持资源

### 输入验证
- [OWASP 输入验证备忘单](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [防止 MCP 中的提示注入](https://modelcontextprotocol.io/docs/guides/security)
- [Azure 内容安全实现](./azure-content-safety-implementation.md)

### 访问控制
- [MCP 授权规范](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [在 MCP 服务器中使用 Microsoft Entra ID](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API 管理作为 MCP 的认证网关](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### 安全通信
- [传输层安全 (TLS) 最佳实践](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP 传输安全指南](https://modelcontextprotocol.io/docs/concepts/transports)
- [AI 工作负载的端到端加密](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### 速率限制
- [API 速率限制模式](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [实现令牌桶速率限制](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Azure API 管理中的速率限制](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### 日志记录与监控
- [AI 系统的集中式日志](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [审计日志最佳实践](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure 监控 AI 工作负载](https://learn.microsoft.com/azure/azure-monitor/overview)

### 安全存储
- [Azure Key Vault 用于凭据存储](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [静态敏感数据加密](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [使用安全令牌存储并加密令牌](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### 令牌管理
- [JWT 最佳实践 (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 安全最佳实践 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [令牌验证和生命周期最佳实践](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### 会话管理
- [OWASP 会话管理备忘单](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP 会话处理指南](https://modelcontextprotocol.io/docs/guides/security)
- [安全会话设计模式](https://learn.microsoft.com/security/engineering/session-security)

### 工具执行沙箱
- [容器安全最佳实践](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [实现进程隔离](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [容器化应用的资源限制](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### 定期安全审计
- [微软安全开发生命周期](https://www.microsoft.com/sdl)
- [OWASP 应用安全验证标准](https://owasp.org/www-project-application-security-verification-standard/)
- [安全代码审查指南](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### 提示验证
- [微软提示防护](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure AI 内容安全](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [防止提示注入](https://github.com/microsoft/prompt-shield-js)

### 身份验证委托
- [Microsoft Entra ID 集成](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [MCP 服务的 OAuth 2.0](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP 安全控制 2025](./mcp-security-controls-2025.md)

### 权限范围划分
- [安全的最小权限访问](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [基于角色的访问控制 (RBAC) 设计](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [MCP 中的工具特定授权](https://modelcontextprotocol.io/docs/guides/best-practices)

### 数据最小化
- [设计中的数据保护](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI 数据隐私最佳实践](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [实施隐私增强技术](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### 自动化漏洞扫描
- [GitHub 高级安全](https://github.com/security/advanced-security)
- [DevSecOps 流水线实施](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [持续安全验证](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。