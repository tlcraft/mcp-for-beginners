<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T08:49:09+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "fi"
}
-->
# MCP:n turvallisuuden parhaat käytännöt

Työskennellessäsi MCP-palvelimien kanssa noudata näitä turvallisuuden parhaita käytäntöjä suojataksesi tietosi, infrastruktuurisi ja käyttäjäsi:

1. **Syötteen validointi**: Varmista aina syötteiden validointi ja puhdistus estääksesi injektiohyökkäykset ja sekaannusongelmat.
2. **Käyttöoikeuksien hallinta**: Toteuta asianmukainen tunnistus ja valtuutus MCP-palvelimellesi hienojakoisilla käyttöoikeuksilla.
3. **Turvallinen viestintä**: Käytä HTTPS/TLS-protokollaa kaikessa MCP-palvelimen viestinnässä ja harkitse lisäsalausta arkaluontoisille tiedoille.
4. **Nopeusrajoitus**: Ota käyttöön nopeusrajoitus väärinkäytösten, palvelunestohyökkäysten estämiseksi ja resurssien hallitsemiseksi.
5. **Lokitus ja valvonta**: Seuraa MCP-palvelintasi epäilyttävän toiminnan varalta ja toteuta kattavat auditointilokit.
6. **Turvallinen tallennus**: Suojaa arkaluontoiset tiedot ja tunnistetiedot asianmukaisella levossa tapahtuvalla salauksella.
7. **Tokenien hallinta**: Estä tokenien läpivientiin liittyvät haavoittuvuudet validoimalla ja puhdistamalla kaikki mallin syötteet ja tulosteet.
8. **Istunnon hallinta**: Toteuta turvallinen istunnon käsittely estääksesi istunnon kaappauksen ja kiinnityshyökkäykset.
9. **Työkalujen suoritusympäristön eristäminen**: Suorita työkalut eristetyissä ympäristöissä estääksesi sivuttaisliikkeet, jos järjestelmä vaarantuu.
10. **Säännölliset turvallisuustarkastukset**: Tee ajoittain turvallisuusarviointeja MCP-toteutuksillesi ja niiden riippuvuuksille.
11. **Kehotevalidointi**: Tarkista ja suodata sekä syöte- että tulostekehotteet estääksesi kehotteiden injektointihyökkäykset.
12. **Tunnistautumisen delegointi**: Käytä vakiintuneita identiteetin tarjoajia sen sijaan, että toteuttaisit oman tunnistautumisen.
13. **Käyttöoikeuksien rajaus**: Toteuta hienojakoiset käyttöoikeudet jokaiselle työkalulle ja resurssille vähimmän oikeuden periaatteen mukaisesti.
14. **Datan minimointi**: Paljasta vain kunkin toiminnon kannalta välttämätön vähimmäismäärä tietoa riskipinnan pienentämiseksi.
15. **Automaattinen haavoittuvuusskannaus**: Skannaa säännöllisesti MCP-palvelimesi ja niiden riippuvuudet tunnetuista haavoittuvuuksista.

## MCP:n turvallisuuden parhaiden käytäntöjen tukiresurssit

### Syötteen validointi
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Käyttöoikeuksien hallinta
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Turvallinen viestintä
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Nopeusrajoitus
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Lokitus ja valvonta
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Turvallinen tallennus
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Tokenien hallinta
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Istunnon hallinta
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Työkalujen suoritusympäristön eristäminen
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Säännölliset turvallisuustarkastukset
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Kehotevalidointi
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Tunnistautumisen delegointi
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Käyttöoikeuksien rajaus
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Datan minimointi
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Automaattinen haavoittuvuusskannaus
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.