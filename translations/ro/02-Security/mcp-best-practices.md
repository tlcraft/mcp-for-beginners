<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:42:46+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "ro"
}
-->
# Cele mai bune practici de securitate MCP

Când lucrați cu servere MCP, urmați aceste cele mai bune practici de securitate pentru a vă proteja datele, infrastructura și utilizatorii:

1. **Validarea inputului**: Validați și curățați întotdeauna datele de intrare pentru a preveni atacurile de tip injection și problemele de tip confused deputy.
2. **Controlul accesului**: Implementați autentificare și autorizare corectă pentru serverul MCP, cu permisiuni detaliate.
3. **Comunicare securizată**: Folosiți HTTPS/TLS pentru toate comunicațiile cu serverul MCP și luați în considerare adăugarea unei criptări suplimentare pentru datele sensibile.
4. **Limitarea ratei**: Implementați limitarea ratei pentru a preveni abuzurile, atacurile DoS și pentru a gestiona consumul de resurse.
5. **Logare și monitorizare**: Monitorizați serverul MCP pentru activități suspecte și implementați trasee de audit cuprinzătoare.
6. **Stocare securizată**: Protejați datele sensibile și credențialele prin criptare adecvată la stocare.
7. **Gestionarea token-urilor**: Preveniți vulnerabilitățile de tip token passthrough prin validarea și curățarea tuturor inputurilor și outputurilor modelului.
8. **Gestionarea sesiunilor**: Implementați gestionarea securizată a sesiunilor pentru a preveni atacurile de tip session hijacking și fixation.
9. **Izolarea execuției uneltelor**: Rulați execuțiile uneltelor în medii izolate pentru a preveni mișcarea laterală în cazul unui compromis.
10. **Audituri de securitate regulate**: Efectuați revizuiri periodice de securitate ale implementărilor și dependențelor MCP.
11. **Validarea prompturilor**: Scanați și filtrați atât prompturile de intrare, cât și cele de ieșire pentru a preveni atacurile de tip prompt injection.
12. **Delegarea autentificării**: Folosiți furnizori de identitate consacrați în loc să implementați autentificare personalizată.
13. **Limitarea permisiunilor**: Implementați permisiuni granulare pentru fiecare unealtă și resursă, respectând principiul privilegiului minim.
14. **Minimizarea datelor**: Expuneți doar datele strict necesare pentru fiecare operațiune, pentru a reduce suprafața de risc.
15. **Scanare automată a vulnerabilităților**: Scanați regulat serverele MCP și dependențele pentru vulnerabilități cunoscute.

## Resurse de suport pentru cele mai bune practici de securitate MCP

### Validarea inputului
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Prevenirea prompt injection în MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Implementarea Azure Content Safety](./azure-content-safety-implementation.md)

### Controlul accesului
- [Specificația MCP Authorization](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Utilizarea Microsoft Entra ID cu serverele MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management ca gateway de autentificare pentru MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Comunicare securizată
- [Cele mai bune practici TLS (Transport Layer Security)](https://learn.microsoft.com/security/engineering/solving-tls)
- [Ghiduri de securitate pentru transport MCP](https://modelcontextprotocol.io/docs/concepts/transports)
- [Criptare end-to-end pentru sarcini AI](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Limitarea ratei
- [Modele de limitare a ratei API](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementarea limitării ratei cu token bucket](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Limitarea ratei în Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Logare și monitorizare
- [Logare centralizată pentru sisteme AI](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Cele mai bune practici pentru audit logging](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor pentru sarcini AI](https://learn.microsoft.com/azure/azure-monitor/overview)

### Stocare securizată
- [Azure Key Vault pentru stocarea credențialelor](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Criptarea datelor sensibile la stocare](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Utilizarea stocării securizate pentru token-uri și criptarea acestora](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Gestionarea token-urilor
- [Cele mai bune practici JWT (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [Cele mai bune practici de securitate OAuth 2.0 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Practici recomandate pentru validarea și durata token-urilor](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Gestionarea sesiunilor
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [Ghiduri pentru gestionarea sesiunilor MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Modele de design pentru sesiuni securizate](https://learn.microsoft.com/security/engineering/session-security)

### Izolarea execuției uneltelor
- [Cele mai bune practici pentru securitatea containerelor](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementarea izolării proceselor](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Limitări de resurse pentru aplicații containerizate](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Audituri de securitate regulate
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Ghiduri pentru revizuirea codului de securitate](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Validarea prompturilor
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety pentru AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Prevenirea prompt injection](https://github.com/microsoft/prompt-shield-js)

### Delegarea autentificării
- [Integrarea Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 pentru servicii MCP](https://learn.microsoft.com/security/engineering/solving-oauth)
- [Controale de securitate MCP 2025](./mcp-security-controls-2025.md)

### Limitarea permisiunilor
- [Acces securizat cu privilegiu minim](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Design RBAC (Role-Based Access Control)](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Autorizare specifică uneltelor în MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimizarea datelor
- [Protecția datelor prin design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [Cele mai bune practici pentru confidențialitatea datelor AI](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementarea tehnologiilor pentru sporirea confidențialității](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Scanare automată a vulnerabilităților
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Implementarea pipeline-ului DevSecOps](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Validare continuă a securității](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.