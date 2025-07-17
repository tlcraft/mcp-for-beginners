<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:42:28+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "sk"
}
-->
# Najlepšie bezpečnostné postupy pre MCP

Pri práci so servermi MCP dodržiavajte tieto bezpečnostné odporúčania na ochranu svojich dát, infraštruktúry a používateľov:

1. **Validácia vstupov**: Vždy overujte a čistite vstupy, aby ste predišli injekčným útokom a problémom s nejasným oprávnením.
2. **Riadenie prístupu**: Implementujte správnu autentifikáciu a autorizáciu pre váš MCP server s detailným nastavením oprávnení.
3. **Bezpečná komunikácia**: Používajte HTTPS/TLS pre všetku komunikáciu s MCP serverom a zvážte pridanie ďalšieho šifrovania pre citlivé údaje.
4. **Obmedzovanie rýchlosti (Rate Limiting)**: Zavádzajte obmedzenia rýchlosti, aby ste zabránili zneužitiu, DoS útokom a riadili spotrebu zdrojov.
5. **Logovanie a monitorovanie**: Sledujte svoj MCP server kvôli podozrivej aktivite a implementujte komplexné audítorské záznamy.
6. **Bezpečné ukladanie**: Chráňte citlivé údaje a prihlasovacie údaje správnym šifrovaním v pokoji (at rest).
7. **Správa tokenov**: Predchádzajte zraniteľnostiam pri prenose tokenov overovaním a čistením všetkých vstupov a výstupov modelu.
8. **Správa relácií**: Implementujte bezpečné spracovanie relácií, aby ste zabránili únosu alebo fixácii relácie.
9. **Izolované spúšťanie nástrojov**: Spúšťajte nástroje v izolovaných prostrediach, aby ste zabránili laterálnemu pohybu v prípade kompromitácie.
10. **Pravidelné bezpečnostné audity**: Pravidelne vykonávajte bezpečnostné kontroly vašich implementácií MCP a závislostí.
11. **Validácia promptov**: Skontrolujte a filtrujte vstupné aj výstupné prompty, aby ste zabránili útokom typu prompt injection.
12. **Delegovanie autentifikácie**: Používajte overených poskytovateľov identity namiesto vlastnej implementácie autentifikácie.
13. **Obmedzenie oprávnení**: Zavádzajte detailné oprávnenia pre každý nástroj a zdroj podľa princípu najmenších právomocí.
14. **Minimalizácia dát**: Zverejňujte len nevyhnutné minimum dát pre každú operáciu, aby ste znížili rizikový povrch.
15. **Automatizované skenovanie zraniteľností**: Pravidelne skenujte svoje MCP servery a závislosti na známe zraniteľnosti.

## Podporné zdroje pre najlepšie bezpečnostné postupy MCP

### Validácia vstupov
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Riadenie prístupu
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Bezpečná komunikácia
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Obmedzovanie rýchlosti (Rate Limiting)
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Logovanie a monitorovanie
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Bezpečné ukladanie
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Správa tokenov
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Správa relácií
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Izolované spúšťanie nástrojov
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Pravidelné bezpečnostné audity
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Validácia promptov
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Delegovanie autentifikácie
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Obmedzenie oprávnení
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimalizácia dát
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Automatizované skenovanie zraniteľností
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.