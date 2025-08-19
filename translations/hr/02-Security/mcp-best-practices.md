<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:43:48+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "hr"
}
-->
# Najbolje sigurnosne prakse za MCP

Prilikom rada s MCP serverima, slijedite ove najbolje sigurnosne prakse kako biste zaštitili svoje podatke, infrastrukturu i korisnike:

1. **Validacija unosa**: Uvijek provjeravajte i sanitizirajte unose kako biste spriječili injekcijske napade i probleme s neovlaštenim pristupom.
2. **Kontrola pristupa**: Implementirajte ispravnu autentifikaciju i autorizaciju za svoj MCP server s detaljnim dopuštenjima.
3. **Sigurna komunikacija**: Koristite HTTPS/TLS za svu komunikaciju s MCP serverom i razmotrite dodatno šifriranje za osjetljive podatke.
4. **Ograničenje brzine**: Uvedite ograničenje brzine kako biste spriječili zloupotrebe, DoS napade i upravljali potrošnjom resursa.
5. **Evidencija i nadzor**: Pratite MCP server zbog sumnjivih aktivnosti i implementirajte sveobuhvatne revizijske zapise.
6. **Sigurna pohrana**: Zaštitite osjetljive podatke i vjerodajnice odgovarajućim šifriranjem u mirovanju.
7. **Upravljanje tokenima**: Spriječite ranjivosti povezane s prosljeđivanjem tokena validacijom i sanitizacijom svih ulaza i izlaza modela.
8. **Upravljanje sesijama**: Implementirajte sigurno upravljanje sesijama kako biste spriječili otmicu i fiksaciju sesija.
9. **Izolacija izvršavanja alata**: Pokrećite izvršavanje alata u izoliranim okruženjima kako biste spriječili lateralno kretanje u slučaju kompromitacije.
10. **Redovite sigurnosne revizije**: Povremeno provodite sigurnosne preglede MCP implementacija i ovisnosti.
11. **Validacija promptova**: Skenirajte i filtrirajte ulazne i izlazne promptove kako biste spriječili napade injekcije prompta.
12. **Delegacija autentifikacije**: Koristite etablirane pružatelje identiteta umjesto implementacije vlastite autentifikacije.
13. **Granulacija dopuštenja**: Implementirajte detaljna dopuštenja za svaki alat i resurs prema načelu najmanjih privilegija.
14. **Minimizacija podataka**: Izlažite samo minimalne potrebne podatke za svaku operaciju kako biste smanjili površinu rizika.
15. **Automatizirano skeniranje ranjivosti**: Redovito skenirajte MCP servere i ovisnosti na poznate ranjivosti.

## Podrška i resursi za najbolje sigurnosne prakse MCP-a

### Validacija unosa
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Kontrola pristupa
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Sigurna komunikacija
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Ograničenje brzine
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Evidencija i nadzor
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Sigurna pohrana
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Upravljanje tokenima
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Upravljanje sesijama
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Izolacija izvršavanja alata
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Redovite sigurnosne revizije
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Validacija promptova
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Delegacija autentifikacije
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Granulacija dopuštenja
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimizacija podataka
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Automatizirano skeniranje ranjivosti
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.