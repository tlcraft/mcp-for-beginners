<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T08:49:31+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "nl"
}
-->
# MCP Security Best Practices

Wanneer je werkt met MCP-servers, volg dan deze beveiligingsrichtlijnen om je data, infrastructuur en gebruikers te beschermen:

1. **Inputvalidatie**: Valideer en reinig altijd invoer om injectieaanvallen en confused deputy-problemen te voorkomen.  
2. **Toegangscontrole**: Implementeer correcte authenticatie en autorisatie voor je MCP-server met fijnmazige permissies.  
3. **Veilige communicatie**: Gebruik HTTPS/TLS voor alle communicatie met je MCP-server en overweeg extra versleuteling voor gevoelige gegevens.  
4. **Rate limiting**: Voer rate limiting in om misbruik, DoS-aanvallen en overmatig gebruik van resources te voorkomen.  
5. **Logging en monitoring**: Houd je MCP-server in de gaten op verdachte activiteiten en implementeer uitgebreide auditlogs.  
6. **Veilige opslag**: Bescherm gevoelige data en inloggegevens met passende versleuteling in rust.  
7. **Tokenbeheer**: Voorkom token passthrough-kwetsbaarheden door alle modelinvoer en -uitvoer te valideren en te reinigen.  
8. **Sessiebeheer**: Zorg voor veilige sessieafhandeling om sessiekaping en sessiefixatie te voorkomen.  
9. **Sandboxing van tooluitvoering**: Voer tools uit in geïsoleerde omgevingen om laterale beweging bij compromittering te voorkomen.  
10. **Regelmatige beveiligingsaudits**: Voer periodieke beveiligingsreviews uit van je MCP-implementaties en afhankelijkheden.  
11. **Promptvalidatie**: Scan en filter zowel invoer- als uitvoerprompts om promptinjectie-aanvallen te voorkomen.  
12. **Authenticatie-delegatie**: Gebruik gevestigde identity providers in plaats van zelf aangepaste authenticatie te implementeren.  
13. **Permissies afbakenen**: Implementeer gedetailleerde permissies voor elke tool en resource volgens het principe van minste rechten.  
14. **Dataminimalisatie**: Maak alleen de minimaal benodigde data beschikbaar voor elke operatie om het risico te beperken.  
15. **Geautomatiseerde kwetsbaarheidsscans**: Scan regelmatig je MCP-servers en afhankelijkheden op bekende kwetsbaarheden.

## Ondersteunende bronnen voor MCP Security Best Practices

### Inputvalidatie
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)  
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)  
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)  

### Toegangscontrole
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)  
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)  
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)  

### Veilige communicatie
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)  
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)  
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)  

### Rate limiting
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)  
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)  
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)  

### Logging en monitoring
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)  
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)  
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)  

### Veilige opslag
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)  
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)  
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)  

### Tokenbeheer
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)  
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)  
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)  

### Sessiebeheer
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)  
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)  
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)  

### Sandboxing van tooluitvoering
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)  
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)  
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)  

### Regelmatige beveiligingsaudits
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)  
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)  
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)  

### Promptvalidatie
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)  
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)  
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)  

### Authenticatie-delegatie
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)  
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)  
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)  

### Permissies afbakenen
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)  
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)  
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)  

### Dataminimalisatie
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)  
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)  
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)  

### Geautomatiseerde kwetsbaarheidsscans
- [GitHub Advanced Security](https://github.com/security/advanced-security)  
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)  
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.