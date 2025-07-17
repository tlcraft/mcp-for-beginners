<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:43:07+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "bg"
}
-->
# MCP Най-добри практики за сигурност

Когато работите с MCP сървъри, следвайте тези най-добри практики за сигурност, за да защитите вашите данни, инфраструктура и потребители:

1. **Валидация на входните данни**: Винаги проверявайте и почиствайте входните данни, за да предотвратите инжекционни атаки и проблеми с объркани заместници.
2. **Контрол на достъпа**: Прилагайте правилна автентикация и авторизация за вашия MCP сървър с детайлни разрешения.
3. **Сигурна комуникация**: Използвайте HTTPS/TLS за всички комуникации с вашия MCP сървър и обмислете допълнително криптиране за чувствителни данни.
4. **Ограничаване на честотата**: Внедрете ограничаване на честотата, за да предотвратите злоупотреби, DoS атаки и да управлявате консумацията на ресурси.
5. **Логване и мониторинг**: Следете вашия MCP сървър за подозрителна активност и внедрете пълни одитни следи.
6. **Сигурно съхранение**: Защитете чувствителните данни и идентификационни данни с подходящо криптиране при съхранение.
7. **Управление на токени**: Предотвратете уязвимости при предаване на токени чрез валидация и почистване на всички входни и изходни данни на модела.
8. **Управление на сесии**: Прилагайте сигурно управление на сесиите, за да предотвратите отвличане и фиксация на сесии.
9. **Изолиране на изпълнението на инструменти**: Стартирайте изпълнението на инструменти в изолирани среди, за да предотвратите странично движение при компрометиране.
10. **Редовни одити на сигурността**: Провеждайте периодични прегледи на сигурността на вашите MCP реализации и зависимости.
11. **Валидация на подсказки**: Сканирайте и филтрирайте както входящите, така и изходящите подсказки, за да предотвратите инжекционни атаки.
12. **Делегиране на автентикация**: Използвайте утвърдени доставчици на идентичност, вместо да внедрявате собствена автентикация.
13. **Ограничаване на разрешенията**: Прилагайте детайлни разрешения за всеки инструмент и ресурс, следвайки принципа за най-малко привилегии.
14. **Минимализиране на данните**: Излагайте само минималното необходимо количество данни за всяка операция, за да намалите рисковата повърхност.
15. **Автоматизирано сканиране за уязвимости**: Редовно сканирайте вашите MCP сървъри и зависимости за известни уязвимости.

## Поддържащи ресурси за MCP Най-добри практики за сигурност

### Валидация на входните данни
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Контрол на достъпа
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Сигурна комуникация
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Ограничаване на честотата
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Логване и мониторинг
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Сигурно съхранение
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Управление на токени
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Управление на сесии
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Изолиране на изпълнението на инструменти
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Редовни одити на сигурността
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Валидация на подсказки
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Делегиране на автентикация
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Ограничаване на разрешенията
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Минимализиране на данните
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Автоматизирано сканиране за уязвимости
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Отказ от отговорност**:  
Този документ е преведен с помощта на AI преводаческа услуга [Co-op Translator](https://github.com/Azure/co-op-translator). Въпреки че се стремим към точност, моля, имайте предвид, че автоматизираните преводи могат да съдържат грешки или неточности. Оригиналният документ на неговия роден език трябва да се счита за авторитетен източник. За критична информация се препоръчва професионален човешки превод. Ние не носим отговорност за каквито и да е недоразумения или неправилни тълкувания, произтичащи от използването на този превод.