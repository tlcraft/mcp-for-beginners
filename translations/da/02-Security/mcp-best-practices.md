<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T08:48:25+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "da"
}
-->
# MCP Sikkerhedsbedste Praksis

Når du arbejder med MCP-servere, skal du følge disse sikkerhedsbedste praksisser for at beskytte dine data, infrastruktur og brugere:

1. **Inputvalidering**: Valider og rens altid input for at forhindre injektionsangreb og confused deputy-problemer.
2. **Adgangskontrol**: Implementer korrekt autentificering og autorisation for din MCP-server med detaljerede tilladelser.
3. **Sikker kommunikation**: Brug HTTPS/TLS til al kommunikation med din MCP-server, og overvej at tilføje ekstra kryptering for følsomme data.
4. **Ratebegrænsning**: Implementer ratebegrænsning for at forhindre misbrug, DoS-angreb og for at styre ressourceforbruget.
5. **Logning og overvågning**: Overvåg din MCP-server for mistænkelig aktivitet og implementer omfattende revisionsspor.
6. **Sikker lagring**: Beskyt følsomme data og legitimationsoplysninger med korrekt kryptering i hvile.
7. **Tokenhåndtering**: Forhindre token passthrough-sårbarheder ved at validere og rense alle modelinput og -output.
8. **Sessionshåndtering**: Implementer sikker sessionhåndtering for at forhindre session hijacking og fixation-angreb.
9. **Sandboxing af værktøjsudførelse**: Kør værktøjsudførelser i isolerede miljøer for at forhindre lateral bevægelse, hvis de kompromitteres.
10. **Regelmæssige sikkerhedsrevisioner**: Gennemfør periodiske sikkerhedsvurderinger af dine MCP-implementeringer og afhængigheder.
11. **Promptvalidering**: Scan og filtrer både input- og outputprompter for at forhindre promptinjektionsangreb.
12. **Autentificeringsdelegering**: Brug etablerede identitetsudbydere i stedet for at implementere brugerdefineret autentificering.
13. **Tilladelsesafgrænsning**: Implementer granulære tilladelser for hvert værktøj og ressourcer efter princippet om mindst privilegium.
14. **Dataminimering**: Eksponer kun de nødvendige data for hver operation for at reducere risikofladen.
15. **Automatiseret sårbarhedsscanning**: Scan regelmæssigt dine MCP-servere og afhængigheder for kendte sårbarheder.

## Understøttende ressourcer for MCP sikkerhedsbedste praksis

### Inputvalidering
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Forebyggelse af promptinjektion i MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety-implementering](./azure-content-safety-implementation.md)

### Adgangskontrol
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Brug af Microsoft Entra ID med MCP-servere](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management som Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Sikker kommunikation
- [Transport Layer Security (TLS) bedste praksis](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End kryptering for AI-arbejdsbelastninger](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Ratebegrænsning
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementering af Token Bucket ratebegrænsning](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Ratebegrænsning i Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Logning og overvågning
- [Centraliseret logning for AI-systemer](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit logging bedste praksis](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI-arbejdsbelastninger](https://learn.microsoft.com/azure/azure-monitor/overview)

### Sikker lagring
- [Azure Key Vault til lagring af legitimationsoplysninger](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Kryptering af følsomme data i hvile](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Brug sikker tokenlagring og krypter tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Tokenhåndtering
- [JWT bedste praksis (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 sikkerhedsbedste praksis (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Bedste praksis for tokenvalidering og levetid](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Sessionshåndtering
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Sikre sessionsdesignmønstre](https://learn.microsoft.com/security/engineering/session-security)

### Sandboxing af værktøjsudførelse
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementering af procesisolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Ressourcelimits for containeriserede applikationer](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Regelmæssige sikkerhedsrevisioner
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Retningslinjer for sikkerhedskodegennemgang](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Promptvalidering
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Forebyggelse af promptinjektion](https://github.com/microsoft/prompt-shield-js)

### Autentificeringsdelegering
- [Microsoft Entra ID-integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP-tjenester](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Tilladelsesafgrænsning
- [Sikker adgang med mindst privilegium](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Værktøjsspecifik autorisation i MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Dataminimering
- [Databeskyttelse ved design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI data-privatliv bedste praksis](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementering af privatlivsforbedrende teknologier](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Automatiseret sårbarhedsscanning
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps pipeline-implementering](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Kontinuerlig sikkerhedsvalidering](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.