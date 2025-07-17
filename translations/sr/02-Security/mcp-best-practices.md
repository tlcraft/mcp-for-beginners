<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:43:27+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "sr"
}
-->
# MCP Безбедносне најбоље праксе

Када радите са MCP серверима, пратите ове безбедносне најбоље праксе како бисте заштитили своје податке, инфраструктуру и кориснике:

1. **Валидација уноса**: Увек проверите и очистите уносе како бисте спречили инјекцијске нападе и проблеме са конфузним овлашћењима.
2. **Контрола приступа**: Имплементирајте правилну аутентификацију и ауторизацију за свој MCP сервер са детаљним дозволама.
3. **Сигурна комуникација**: Користите HTTPS/TLS за сву комуникацију са MCP сервером и размислите о додатном шифровању осетљивих података.
4. **Ограничење брзине**: Успоставите ограничење брзине како бисте спречили злоупотребу, DoS нападе и контролисали потрошњу ресурса.
5. **Логовање и праћење**: Пратите свој MCP сервер ради сумњивих активности и обезбедите свеобухватне ревизијске записе.
6. **Сигурно складиштење**: Заштитите осетљиве податке и акредитиве правилним шифровањем у миру.
7. **Управљање токенима**: Спречите рањивости токен пасструа тако што ћете валидацијом и чишћењем обрадити све уносе и излазе модела.
8. **Управљање сесијама**: Имплементирајте безбедно руковање сесијама како бисте спречили отимање и фиксацију сесија.
9. **Изолација извршавања алата**: Покрећите извршавање алата у изолованим окружењима како бисте спречили ширење у случају компромитовања.
10. **Редовне безбедносне ревизије**: Спроводите периодичне безбедносне прегледе својих MCP имплементација и зависности.
11. **Валидација упита**: Скенирајте и филтрирајте улазне и излазне упите како бисте спречили инјекцију упита.
12. **Делегирање аутентификације**: Користите проверене провајдере идентитета уместо да имплементирате прилагођену аутентификацију.
13. **Ограничење дозвола**: Имплементирајте детаљне дозволе за сваки алат и ресурс према принципу најмањих привилегија.
14. **Минимализација података**: Излажите само најмање потребне податке за сваку операцију како бисте смањили површину ризика.
15. **Аутоматизовано скенирање рањивости**: Редовно скенирајте своје MCP сервере и зависности ради познатих рањивости.

## Ресурси за подршку MCP безбедносним најбољим праксама

### Валидација уноса
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Контрола приступа
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Сигурна комуникација
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Ограничење брзине
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Логовање и праћење
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Сигурно складиштење
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Управљање токенима
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Управљање сесијама
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Изолација извршавања алата
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Редовне безбедносне ревизије
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Валидација упита
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Делегирање аутентификације
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Ограничење дозвола
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Минимализација података
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Аутоматизовано скенирање рањивости
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Одрицање од одговорности**:  
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде тачан, молимо вас да имате у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешна тумачења која могу настати коришћењем овог превода.