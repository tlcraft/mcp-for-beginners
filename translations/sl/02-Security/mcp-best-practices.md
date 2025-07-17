<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:44:05+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "sl"
}
-->
# Najboljše varnostne prakse za MCP

Pri delu z MCP strežniki upoštevajte naslednje varnostne najboljše prakse za zaščito svojih podatkov, infrastrukture in uporabnikov:

1. **Preverjanje vhodnih podatkov**: Vedno preverjajte in čistite vhodne podatke, da preprečite napade z injekcijo in težave z zmedo pooblaščencev.
2. **Nadzor dostopa**: Uvedite ustrezno avtentikacijo in avtorizacijo za vaš MCP strežnik z natančno določenimi dovoljenji.
3. **Varnostna komunikacija**: Za vso komunikacijo z MCP strežnikom uporabljajte HTTPS/TLS in razmislite o dodatnem šifriranju občutljivih podatkov.
4. **Omejevanje hitrosti**: Uvedite omejevanje hitrosti, da preprečite zlorabe, DoS napade in nadzorujete porabo virov.
5. **Dnevnik in nadzor**: Spremljajte MCP strežnik za sumljive aktivnosti in uvedite celovite revizijske sledi.
6. **Varnostno shranjevanje**: Zaščitite občutljive podatke in poverilnice z ustreznim šifriranjem v mirovanju.
7. **Upravljanje žetonov**: Preprečite ranljivosti pri prenašanju žetonov z validacijo in čiščenjem vseh vhodnih in izhodnih podatkov modela.
8. **Upravljanje sej**: Uvedite varno upravljanje sej, da preprečite prevzem in fiksacijo sej.
9. **Izolacija izvajanja orodij**: Zaženite izvajanje orodij v izoliranih okoljih, da preprečite lateralno širjenje v primeru kompromitacije.
10. **Redni varnostni pregledi**: Redno izvajajte varnostne preglede vaših MCP implementacij in odvisnosti.
11. **Preverjanje pozivov**: Preverjajte in filtrirajte tako vhodne kot izhodne pozive, da preprečite napade z injekcijo pozivov.
12. **Delegacija avtentikacije**: Uporabljajte uveljavljene ponudnike identitete namesto lastnih rešitev za avtentikacijo.
13. **Določanje obsega dovoljenj**: Uvedite natančna dovoljenja za vsako orodje in vir, sledite načelom najmanjših privilegijev.
14. **Minimizacija podatkov**: Razkrijte le najmanjše potrebne podatke za vsako operacijo, da zmanjšate tveganja.
15. **Avtomatizirano skeniranje ranljivosti**: Redno pregledujte MCP strežnike in odvisnosti za znane ranljivosti.

## Podporni viri za najboljše varnostne prakse MCP

### Preverjanje vhodnih podatkov
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Nadzor dostopa
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Varnostna komunikacija
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Omejevanje hitrosti
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Dnevnik in nadzor
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Varnostno shranjevanje
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Upravljanje žetonov
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Upravljanje sej
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Izolacija izvajanja orodij
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Redni varnostni pregledi
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Preverjanje pozivov
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Delegacija avtentikacije
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Določanje obsega dovoljenj
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimizacija podatkov
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Avtomatizirano skeniranje ranljivosti
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.