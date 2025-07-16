<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-16T23:09:38+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "pl"
}
-->
# Najlepsze praktyki bezpieczeństwa MCP

Pracując z serwerami MCP, stosuj się do poniższych najlepszych praktyk bezpieczeństwa, aby chronić swoje dane, infrastrukturę i użytkowników:

1. **Walidacja danych wejściowych**: Zawsze weryfikuj i oczyszczaj dane wejściowe, aby zapobiec atakom typu injection oraz problemom z tzw. confused deputy.
2. **Kontrola dostępu**: Wdrażaj odpowiednią autoryzację i uwierzytelnianie dla serwera MCP z precyzyjnym zarządzaniem uprawnieniami.
3. **Bezpieczna komunikacja**: Korzystaj z HTTPS/TLS we wszystkich połączeniach z serwerem MCP i rozważ dodatkowe szyfrowanie dla wrażliwych danych.
4. **Ograniczanie liczby żądań**: Wprowadź limitowanie liczby zapytań, aby zapobiec nadużyciom, atakom DoS oraz kontrolować zużycie zasobów.
5. **Logowanie i monitorowanie**: Monitoruj serwer MCP pod kątem podejrzanej aktywności i wdrażaj kompleksowe ścieżki audytu.
6. **Bezpieczne przechowywanie**: Chroń wrażliwe dane i poświadczenia za pomocą odpowiedniego szyfrowania danych w spoczynku.
7. **Zarządzanie tokenami**: Zapobiegaj podatnościom związanym z przekazywaniem tokenów, walidując i oczyszczając wszystkie dane wejściowe i wyjściowe modeli.
8. **Zarządzanie sesjami**: Wdrażaj bezpieczne zarządzanie sesjami, aby zapobiec przejęciu sesji i atakom typu fixation.
9. **Izolacja wykonywania narzędzi**: Uruchamiaj narzędzia w odizolowanych środowiskach, aby zapobiec rozprzestrzenianiu się ataku w przypadku kompromitacji.
10. **Regularne audyty bezpieczeństwa**: Przeprowadzaj okresowe przeglądy bezpieczeństwa implementacji MCP oraz ich zależności.
11. **Walidacja promptów**: Skanuj i filtruj zarówno dane wejściowe, jak i wyjściowe promptów, aby zapobiec atakom typu prompt injection.
12. **Delegowanie uwierzytelniania**: Korzystaj z uznanych dostawców tożsamości zamiast tworzyć własne mechanizmy uwierzytelniania.
13. **Zakres uprawnień**: Wdrażaj szczegółowe uprawnienia dla każdego narzędzia i zasobu, stosując zasadę najmniejszych uprawnień.
14. **Minimalizacja danych**: Udostępniaj tylko niezbędne dane dla każdej operacji, aby zmniejszyć powierzchnię ryzyka.
15. **Automatyczne skanowanie podatności**: Regularnie skanuj serwery MCP i ich zależności pod kątem znanych luk bezpieczeństwa.

## Materiały wspierające najlepsze praktyki bezpieczeństwa MCP

### Walidacja danych wejściowych
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Kontrola dostępu
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Bezpieczna komunikacja
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Ograniczanie liczby żądań
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Logowanie i monitorowanie
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Bezpieczne przechowywanie
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Zarządzanie tokenami
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Zarządzanie sesjami
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Izolacja wykonywania narzędzi
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Regularne audyty bezpieczeństwa
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Walidacja promptów
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Delegowanie uwierzytelniania
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Zakres uprawnień
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimalizacja danych
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Automatyczne skanowanie podatności
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Zastrzeżenie**:  
Niniejszy dokument został przetłumaczony za pomocą usługi tłumaczenia AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mimo że dokładamy starań, aby tłumaczenie było jak najbardziej precyzyjne, prosimy mieć na uwadze, że automatyczne tłumaczenia mogą zawierać błędy lub nieścisłości. Oryginalny dokument w języku źródłowym należy traktować jako źródło wiążące. W przypadku informacji o kluczowym znaczeniu zalecane jest skorzystanie z profesjonalnego tłumaczenia wykonanego przez człowieka. Nie ponosimy odpowiedzialności za jakiekolwiek nieporozumienia lub błędne interpretacje wynikające z korzystania z tego tłumaczenia.