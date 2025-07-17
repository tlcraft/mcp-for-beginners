<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:42:06+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "cs"
}
-->
# Nejlepší bezpečnostní postupy pro MCP

Při práci se servery MCP dodržujte tyto bezpečnostní postupy, abyste ochránili svá data, infrastrukturu a uživatele:

1. **Validace vstupů**: Vždy ověřujte a čistěte vstupy, abyste zabránili útokům typu injection a problémům s „confused deputy“.
2. **Řízení přístupu**: Implementujte správnou autentizaci a autorizaci pro váš MCP server s jemně nastavenými oprávněními.
3. **Bezpečná komunikace**: Používejte HTTPS/TLS pro veškerou komunikaci s MCP serverem a zvažte přidání dalšího šifrování pro citlivá data.
4. **Omezení rychlosti požadavků**: Zavádějte omezení rychlosti, aby se zabránilo zneužití, DoS útokům a lépe se spravovala spotřeba zdrojů.
5. **Logování a monitoring**: Sledujte MCP server kvůli podezřelé aktivitě a implementujte komplexní auditní záznamy.
6. **Bezpečné ukládání**: Chraňte citlivá data a přihlašovací údaje správným šifrováním v klidu.
7. **Správa tokenů**: Zabraňte zranitelnostem při přenosu tokenů tím, že budete validovat a čistit všechny vstupy a výstupy modelu.
8. **Správa relací**: Implementujte bezpečné zpracování relací, aby se zabránilo únosu nebo fixaci relace.
9. **Sandboxing spouštění nástrojů**: Spouštějte nástroje v izolovaných prostředích, aby se zabránilo laterálnímu pohybu v případě kompromitace.
10. **Pravidelné bezpečnostní audity**: Provádějte pravidelné bezpečnostní kontroly vašich implementací MCP a jejich závislostí.
11. **Validace promptů**: Prohlížejte a filtrujte vstupní i výstupní prompty, abyste zabránili útokům typu prompt injection.
12. **Delegace autentizace**: Používejte zavedené poskytovatele identity místo implementace vlastní autentizace.
13. **Omezení oprávnění**: Zavádějte granulární oprávnění pro každý nástroj a zdroj podle principu nejmenších práv.
14. **Minimalizace dat**: Zveřejňujte pouze nezbytná data pro každou operaci, abyste snížili rizikový povrch.
15. **Automatizované skenování zranitelností**: Pravidelně skenujte MCP servery a závislosti na známé zranitelnosti.

## Podpůrné zdroje pro nejlepší bezpečnostní postupy MCP

### Validace vstupů
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Řízení přístupu
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Bezpečná komunikace
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Omezení rychlosti požadavků
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Logování a monitoring
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Bezpečné ukládání
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Správa tokenů
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Správa relací
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Sandboxing spouštění nástrojů
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Pravidelné bezpečnostní audity
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Validace promptů
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Delegace autentizace
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Omezení oprávnění
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimalizace dat
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Automatizované skenování zranitelností
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.