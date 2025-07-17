<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:41:22+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "sw"
}
-->
# Mazoezi Bora ya Usalama ya MCP

Unapofanya kazi na seva za MCP, fuata mazoezi haya bora ya usalama ili kulinda data zako, miundombinu, na watumiaji:

1. **Uhakiki wa Ingizo**: Hakikisha kila mara unathibitisha na kusafisha ingizo ili kuzuia mashambulizi ya sindano na matatizo ya mteja mteule.
2. **Udhibiti wa Upatikanaji**: Tekeleza uthibitishaji na idhini sahihi kwa seva yako ya MCP kwa ruhusa za kina.
3. **Mawasiliano Salama**: Tumia HTTPS/TLS kwa mawasiliano yote na seva yako ya MCP na fikiria kuongeza usimbaji wa ziada kwa data nyeti.
4. **Kudhibiti Kiwango cha Matumizi**: Tekeleza mipaka ya kiwango cha matumizi ili kuzuia matumizi mabaya, mashambulizi ya DoS, na kusimamia matumizi ya rasilimali.
5. **Kufuatilia na Kurekodi**: Fuata shughuli za seva yako ya MCP kwa vitendo vya kutiliwa shaka na tekeleza rekodi kamili za ukaguzi.
6. **Uhifadhi Salama**: Linda data nyeti na nyaraka za siri kwa usimbaji salama wakati wa kuhifadhi.
7. **Usimamizi wa Tokeni**: Zuia udhaifu wa kupitisha tokeni kwa kuthibitisha na kusafisha ingizo na matokeo yote ya modeli.
8. **Usimamizi wa Kikao**: Tekeleza usimamizi salama wa vikao ili kuzuia wizi wa kikao na mashambulizi ya kufunga kikao.
9. **Kutekeleza Zana Katika Mazingira Yaliyojitenga**: Endesha utekelezaji wa zana katika mazingira yaliyojitenga ili kuzuia kusambaa kwa mashambulizi ikiwa itavamiwa.
10. **Ukaguzi wa Usalama Mara kwa Mara**: Fanya mapitio ya mara kwa mara ya usalama ya utekelezaji wako wa MCP na utegemezi wake.
11. **Uhakiki wa Maagizo**: Chunguza na kuchuja maagizo yote ya ingizo na matokeo ili kuzuia mashambulizi ya sindano ya maagizo.
12. **Uwakilishi wa Uthibitishaji**: Tumia watoa huduma wa utambulisho waliothibitishwa badala ya kutekeleza uthibitishaji wa kawaida.
13. **Kuweka Mipaka ya Ruhusa**: Tekeleza ruhusa za kina kwa kila zana na rasilimali kwa kufuata kanuni ya ruhusa ndogo kabisa.
14. **Kupunguza Data**: Onyesha data kidogo tu inayohitajika kwa kila operesheni ili kupunguza hatari.
15. **Uchunguzi wa Kiotomatiki wa Udhaifu**: Fanya uchunguzi wa mara kwa mara wa seva zako za MCP na utegemezi kwa udhaifu unaojulikana.

## Rasilimali za Kusaidia kwa Mazoezi Bora ya Usalama ya MCP

### Uhakiki wa Ingizo
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Udhibiti wa Upatikanaji
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Mawasiliano Salama
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Kudhibiti Kiwango cha Matumizi
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Kufuatilia na Kurekodi
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Uhifadhi Salama
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Usimamizi wa Tokeni
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Usimamizi wa Kikao
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Kutekeleza Zana Katika Mazingira Yaliyojitenga
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Ukaguzi wa Usalama Mara kwa Mara
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Uhakiki wa Maagizo
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Uwakilishi wa Uthibitishaji
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Kuweka Mipaka ya Ruhusa
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Kupunguza Data
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Uchunguzi wa Kiotomatiki wa Udhaifu
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Kiarifu cha Kutotegemea**:  
Hati hii imetafsiriwa kwa kutumia huduma ya tafsiri ya AI [Co-op Translator](https://github.com/Azure/co-op-translator). Ingawa tunajitahidi kwa usahihi, tafadhali fahamu kwamba tafsiri za kiotomatiki zinaweza kuwa na makosa au upungufu wa usahihi. Hati ya asili katika lugha yake ya asili inapaswa kuchukuliwa kama chanzo cha mamlaka. Kwa taarifa muhimu, tafsiri ya kitaalamu inayofanywa na binadamu inapendekezwa. Hatubebei dhamana kwa kutoelewana au tafsiri potofu zinazotokana na matumizi ya tafsiri hii.