<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T01:53:13+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "pa"
}
-->
# MCP ਸੁਰੱਖਿਆ ਲਈ ਵਧੀਆ ਅਭਿਆਸ

ਜਦੋਂ ਤੁਸੀਂ MCP ਸਰਵਰਾਂ ਨਾਲ ਕੰਮ ਕਰ ਰਹੇ ਹੋ, ਤਾਂ ਆਪਣੇ ਡੇਟਾ, ਢਾਂਚੇ ਅਤੇ ਯੂਜ਼ਰਾਂ ਦੀ ਸੁਰੱਖਿਆ ਲਈ ਇਹ ਸੁਰੱਖਿਆ ਦੇ ਵਧੀਆ ਅਭਿਆਸ ਮੰਨੋ:

1. **ਇਨਪੁੱਟ ਵੈਰੀਫਿਕੇਸ਼ਨ**: ਹਮੇਸ਼ਾ ਇਨਪੁੱਟ ਨੂੰ ਵੈਰੀਫਾਈ ਅਤੇ ਸਾਫ਼-ਸੁਥਰਾ ਕਰੋ ਤਾਂ ਜੋ ਇੰਜੈਕਸ਼ਨ ਹਮਲਿਆਂ ਅਤੇ ਗਲਤ ਪ੍ਰਤੀਨਿਧਿਤਾ ਸਮੱਸਿਆਵਾਂ ਤੋਂ ਬਚਿਆ ਜਾ ਸਕੇ।
2. **ਪਹੁੰਚ ਨਿਯੰਤਰਣ**: ਆਪਣੇ MCP ਸਰਵਰ ਲਈ ਠੀਕ ਪ੍ਰਮਾਣਿਕਤਾ ਅਤੇ ਅਧਿਕਾਰ ਲਾਗੂ ਕਰੋ, ਜਿਸ ਵਿੱਚ ਬਰੀਕੀ ਨਾਲ ਅਧਿਕਾਰ ਦਿੱਤੇ ਜਾਣ।
3. **ਸੁਰੱਖਿਅਤ ਸੰਚਾਰ**: MCP ਸਰਵਰ ਨਾਲ ਸਾਰੇ ਸੰਚਾਰ ਲਈ HTTPS/TLS ਵਰਤੋਂ ਅਤੇ ਸੰਵੇਦਨਸ਼ੀਲ ਡੇਟਾ ਲਈ ਵਾਧੂ ਇਨਕ੍ਰਿਪਸ਼ਨ ਵੀ ਸੋਚੋ।
4. **ਰੇਟ ਲਿਮਿਟਿੰਗ**: ਦੁਰਵਰਤੋਂ, DoS ਹਮਲਿਆਂ ਅਤੇ ਸਰੋਤਾਂ ਦੀ ਵਰਤੋਂ ਨੂੰ ਸੰਭਾਲਣ ਲਈ ਰੇਟ ਲਿਮਿਟਿੰਗ ਲਾਗੂ ਕਰੋ।
5. **ਲੌਗਿੰਗ ਅਤੇ ਨਿਗਰਾਨੀ**: ਆਪਣੇ MCP ਸਰਵਰ ਦੀ ਸ਼ੱਕੀ ਗਤੀਵਿਧੀ ਲਈ ਨਿਗਰਾਨੀ ਕਰੋ ਅਤੇ ਵਿਸਤ੍ਰਿਤ ਆਡਿਟ ਟ੍ਰੇਲ ਲਾਗੂ ਕਰੋ।
6. **ਸੁਰੱਖਿਅਤ ਸਟੋਰੇਜ**: ਸੰਵੇਦਨਸ਼ੀਲ ਡੇਟਾ ਅਤੇ ਪ੍ਰਮਾਣ ਪੱਤਰਾਂ ਨੂੰ ਸਹੀ ਤਰੀਕੇ ਨਾਲ ਇਨਕ੍ਰਿਪਟ ਕਰਕੇ ਸੁਰੱਖਿਅਤ ਰੱਖੋ।
7. **ਟੋਕਨ ਪ੍ਰਬੰਧਨ**: ਸਾਰੇ ਮਾਡਲ ਇਨਪੁੱਟ ਅਤੇ ਆਉਟਪੁੱਟ ਨੂੰ ਵੈਰੀਫਾਈ ਅਤੇ ਸਾਫ਼ ਕਰਕੇ ਟੋਕਨ ਪਾਸਥਰੂ ਦੀਆਂ ਕਮਜ਼ੋਰੀਆਂ ਤੋਂ ਬਚਾਓ।
8. **ਸੈਸ਼ਨ ਪ੍ਰਬੰਧਨ**: ਸੈਸ਼ਨ ਹਾਈਜੈਕਿੰਗ ਅਤੇ ਫਿਕਸੇਸ਼ਨ ਹਮਲਿਆਂ ਤੋਂ ਬਚਾਅ ਲਈ ਸੁਰੱਖਿਅਤ ਸੈਸ਼ਨ ਹੈਂਡਲਿੰਗ ਲਾਗੂ ਕਰੋ।
9. **ਟੂਲ ਐਗਜ਼ੀਕਿਊਸ਼ਨ ਸੈਂਡਬਾਕਸਿੰਗ**: ਜੇਕਰ ਕੰਪ੍ਰੋਮਾਈਜ਼ ਹੋ ਜਾਵੇ ਤਾਂ ਲੈਟਰਲ ਮੂਵਮੈਂਟ ਤੋਂ ਬਚਣ ਲਈ ਟੂਲ ਐਗਜ਼ੀਕਿਊਸ਼ਨ ਨੂੰ ਅਲੱਗ-ਅਲੱਗ ਮਾਹੌਲਾਂ ਵਿੱਚ ਚਲਾਓ।
10. **ਨਿਯਮਤ ਸੁਰੱਖਿਆ ਆਡਿਟ**: ਆਪਣੇ MCP ਇੰਪਲੀਮੈਂਟੇਸ਼ਨ ਅਤੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਦੀ ਸਮੇਂ-ਸਮੇਂ ਤੇ ਸੁਰੱਖਿਆ ਸਮੀਖਿਆ ਕਰੋ।
11. **ਪ੍ਰਾਂਪਟ ਵੈਰੀਫਿਕੇਸ਼ਨ**: ਪ੍ਰਾਂਪਟ ਇੰਜੈਕਸ਼ਨ ਹਮਲਿਆਂ ਤੋਂ ਬਚਣ ਲਈ ਇਨਪੁੱਟ ਅਤੇ ਆਉਟਪੁੱਟ ਦੋਹਾਂ ਨੂੰ ਸਕੈਨ ਅਤੇ ਫਿਲਟਰ ਕਰੋ।
12. **ਪ੍ਰਮਾਣਿਕਤਾ ਡੈਲੀਗੇਸ਼ਨ**: ਕਸਟਮ ਪ੍ਰਮਾਣਿਕਤਾ ਬਣਾਉਣ ਦੀ ਬਜਾਏ ਮੰਨਿਆ ਹੋਇਆ ਆਈਡੈਂਟੀਟੀ ਪ੍ਰੋਵਾਈਡਰ ਵਰਤੋਂ।
13. **ਅਧਿਕਾਰ ਸਕੋਪਿੰਗ**: ਹਰ ਟੂਲ ਅਤੇ ਸਰੋਤ ਲਈ ਘੱਟੋ-ਘੱਟ ਅਧਿਕਾਰ ਦੇ ਸਿਧਾਂਤ ਅਨੁਸਾਰ ਬਰੀਕੀ ਨਾਲ ਅਧਿਕਾਰ ਲਾਗੂ ਕਰੋ।
14. **ਡੇਟਾ ਘਟਾਓ**: ਹਰ ਓਪਰੇਸ਼ਨ ਲਈ ਸਿਰਫ਼ ਜ਼ਰੂਰੀ ਡੇਟਾ ਹੀ ਪ੍ਰਦਰਸ਼ਿਤ ਕਰੋ ਤਾਂ ਜੋ ਖਤਰੇ ਦੀ ਸੰਭਾਵਨਾ ਘੱਟ ਹੋਵੇ।
15. **ਆਟੋਮੈਟਿਕ ਕਮਜ਼ੋਰੀ ਸਕੈਨਿੰਗ**: ਆਪਣੇ MCP ਸਰਵਰਾਂ ਅਤੇ ਡਿਪੈਂਡੈਂਸੀਜ਼ ਨੂੰ ਜਾਣੀਆਂ ਕਮਜ਼ੋਰੀਆਂ ਲਈ ਨਿਯਮਤ ਤੌਰ 'ਤੇ ਸਕੈਨ ਕਰੋ।

## MCP ਸੁਰੱਖਿਆ ਲਈ ਵਧੀਆ ਅਭਿਆਸ ਲਈ ਸਹਾਇਕ ਸਰੋਤ

### ਇਨਪੁੱਟ ਵੈਰੀਫਿਕੇਸ਼ਨ
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### ਪਹੁੰਚ ਨਿਯੰਤਰਣ
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### ਸੁਰੱਖਿਅਤ ਸੰਚਾਰ
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### ਰੇਟ ਲਿਮਿਟਿੰਗ
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### ਲੌਗਿੰਗ ਅਤੇ ਨਿਗਰਾਨੀ
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### ਸੁਰੱਖਿਅਤ ਸਟੋਰੇਜ
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### ਟੋਕਨ ਪ੍ਰਬੰਧਨ
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### ਸੈਸ਼ਨ ਪ੍ਰਬੰਧਨ
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### ਟੂਲ ਐਗਜ਼ੀਕਿਊਸ਼ਨ ਸੈਂਡਬਾਕਸਿੰਗ
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### ਨਿਯਮਤ ਸੁਰੱਖਿਆ ਆਡਿਟ
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### ਪ੍ਰਾਂਪਟ ਵੈਰੀਫਿਕੇਸ਼ਨ
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### ਪ੍ਰਮਾਣਿਕਤਾ ਡੈਲੀਗੇਸ਼ਨ
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### ਅਧਿਕਾਰ ਸਕੋਪਿੰਗ
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### ਡੇਟਾ ਘਟਾਓ
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### ਆਟੋਮੈਟਿਕ ਕਮਜ਼ੋਰੀ ਸਕੈਨਿੰਗ
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**ਅਸਵੀਕਾਰੋਪੱਤਰ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦਿਤ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਧਿਆਨ ਰੱਖੋ ਕਿ ਸਵੈਚਾਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੀ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਤੋਂ ਉਤਪੰਨ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆ ਲਈ ਅਸੀਂ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।