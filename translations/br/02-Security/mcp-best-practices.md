<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T01:53:45+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "br"
}
-->
# Melhores Práticas de Segurança para MCP

Ao trabalhar com servidores MCP, siga estas melhores práticas de segurança para proteger seus dados, infraestrutura e usuários:

1. **Validação de Entrada**: Sempre valide e sanitize as entradas para evitar ataques de injeção e problemas de delegado confuso.
2. **Controle de Acesso**: Implemente autenticação e autorização adequadas para seu servidor MCP com permissões detalhadas.
3. **Comunicação Segura**: Use HTTPS/TLS para todas as comunicações com seu servidor MCP e considere adicionar criptografia extra para dados sensíveis.
4. **Limitação de Taxa**: Implemente limitação de taxa para evitar abusos, ataques DoS e gerenciar o consumo de recursos.
5. **Registro e Monitoramento**: Monitore seu servidor MCP para atividades suspeitas e implemente trilhas de auditoria abrangentes.
6. **Armazenamento Seguro**: Proteja dados sensíveis e credenciais com criptografia adequada em repouso.
7. **Gerenciamento de Tokens**: Evite vulnerabilidades de passagem de token validando e sanitizando todas as entradas e saídas do modelo.
8. **Gerenciamento de Sessão**: Implemente um manejo seguro de sessões para prevenir sequestro e fixação de sessão.
9. **Sandboxing na Execução de Ferramentas**: Execute ferramentas em ambientes isolados para evitar movimentação lateral em caso de comprometimento.
10. **Auditorias de Segurança Regulares**: Realize revisões periódicas de segurança nas implementações e dependências do MCP.
11. **Validação de Prompt**: Analise e filtre prompts de entrada e saída para evitar ataques de injeção de prompt.
12. **Delegação de Autenticação**: Use provedores de identidade estabelecidos em vez de implementar autenticação personalizada.
13. **Escopo de Permissões**: Implemente permissões granulares para cada ferramenta e recurso seguindo o princípio do menor privilégio.
14. **Minimização de Dados**: Exponha apenas os dados mínimos necessários para cada operação, reduzindo a superfície de risco.
15. **Varredura Automática de Vulnerabilidades**: Escaneie regularmente seus servidores MCP e dependências em busca de vulnerabilidades conhecidas.

## Recursos de Apoio para as Melhores Práticas de Segurança MCP

### Validação de Entrada
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Controle de Acesso
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Comunicação Segura
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Limitação de Taxa
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Registro e Monitoramento
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Armazenamento Seguro
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Gerenciamento de Tokens
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Gerenciamento de Sessão
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Sandboxing na Execução de Ferramentas
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Auditorias de Segurança Regulares
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Validação de Prompt
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Delegação de Autenticação
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Escopo de Permissões
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimização de Dados
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Varredura Automática de Vulnerabilidades
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.