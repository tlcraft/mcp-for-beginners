<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T08:48:48+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "no"
}
-->
# MCP Sikkerhetsanbefalinger

Når du jobber med MCP-servere, følg disse sikkerhetsanbefalingene for å beskytte dataene, infrastrukturen og brukerne dine:

1. **Inputvalidering**: Valider og rens alltid input for å forhindre injeksjonsangrep og confused deputy-problemer.
2. **Tilgangskontroll**: Implementer riktig autentisering og autorisasjon for MCP-serveren din med detaljerte tillatelser.
3. **Sikker kommunikasjon**: Bruk HTTPS/TLS for all kommunikasjon med MCP-serveren, og vurder å legge til ekstra kryptering for sensitiv informasjon.
4. **Ratebegrensning**: Implementer ratebegrensning for å forhindre misbruk, DoS-angrep og for å styre ressursbruk.
5. **Logging og overvåking**: Overvåk MCP-serveren for mistenkelig aktivitet og implementer omfattende revisjonsspor.
6. **Sikker lagring**: Beskytt sensitiv data og legitimasjon med riktig kryptering i hvilemodus.
7. **Tokenhåndtering**: Forhindre token passthrough-sårbarheter ved å validere og rense alle modellens input og output.
8. **Sessionshåndtering**: Implementer sikker håndtering av økter for å forhindre kapring og fikseringsangrep.
9. **Sandboxing av verktøykjøring**: Kjør verktøy i isolerte miljøer for å hindre lateral bevegelse ved kompromittering.
10. **Regelmessige sikkerhetsrevisjoner**: Gjennomfør periodiske sikkerhetsgjennomganger av MCP-implementasjoner og avhengigheter.
11. **Validering av prompt**: Skann og filtrer både input- og output-prompt for å forhindre prompt-injeksjonsangrep.
12. **Autentiseringsdelegering**: Bruk etablerte identitetsleverandører i stedet for å lage egen autentisering.
13. **Tillatelsesavgrensning**: Implementer detaljerte tillatelser for hvert verktøy og ressurs etter prinsippet om minste privilegium.
14. **Dataminimering**: Eksponer kun det minimale nødvendige data for hver operasjon for å redusere risikoflaten.
15. **Automatisert sårbarhetsskanning**: Skann regelmessig MCP-servere og avhengigheter for kjente sårbarheter.

## Støtteressurser for MCP Sikkerhetsanbefalinger

### Inputvalidering
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Tilgangskontroll
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Sikker kommunikasjon
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Ratebegrensning
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Logging og overvåking
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Sikker lagring
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Tokenhåndtering
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Sessionshåndtering
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Sandboxing av verktøykjøring
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Regelmessige sikkerhetsrevisjoner
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Validering av prompt
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Autentiseringsdelegering
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Tillatelsesavgrensning
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Dataminimering
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Automatisert sårbarhetsskanning
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.