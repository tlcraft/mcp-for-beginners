<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:44:46+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "uk"
}
-->
# Найкращі практики безпеки MCP

Працюючи з серверами MCP, дотримуйтесь цих найкращих практик безпеки, щоб захистити свої дані, інфраструктуру та користувачів:

1. **Перевірка введених даних**: Завжди перевіряйте та очищуйте введені дані, щоб запобігти ін’єкційним атакам і проблемам типу confused deputy.
2. **Контроль доступу**: Реалізуйте належну автентифікацію та авторизацію для вашого сервера MCP з детальним розмежуванням прав.
3. **Безпечне спілкування**: Використовуйте HTTPS/TLS для всіх комунікацій із сервером MCP і розгляньте можливість додаткового шифрування для конфіденційних даних.
4. **Обмеження частоти запитів**: Впровадьте обмеження частоти, щоб запобігти зловживанням, DoS-атакам і контролювати споживання ресурсів.
5. **Логування та моніторинг**: Слідкуйте за сервером MCP на предмет підозрілої активності та впроваджуйте комплексні аудиторські журнали.
6. **Безпечне зберігання**: Захищайте конфіденційні дані та облікові дані за допомогою належного шифрування у стані спокою.
7. **Управління токенами**: Запобігайте вразливостям, пов’язаним із передачею токенів, перевіряючи та очищуючи всі вхідні та вихідні дані моделей.
8. **Управління сесіями**: Реалізуйте безпечне керування сесіями, щоб запобігти викраденню та фіксації сесій.
9. **Ізоляція виконання інструментів**: Запускайте виконання інструментів у ізольованих середовищах, щоб уникнути поширення у разі компрометації.
10. **Регулярні аудити безпеки**: Проводьте періодичні перевірки безпеки ваших реалізацій MCP та залежностей.
11. **Перевірка запитів (prompt validation)**: Перевіряйте та фільтруйте як вхідні, так і вихідні запити, щоб запобігти атакам типу prompt injection.
12. **Делегування автентифікації**: Використовуйте перевірених провайдерів ідентифікації замість власної реалізації автентифікації.
13. **Обмеження прав доступу**: Впроваджуйте детальні права доступу для кожного інструменту та ресурсу, дотримуючись принципу найменших привілеїв.
14. **Мінімізація даних**: Надавайте лише мінімально необхідні дані для кожної операції, щоб зменшити площу ризику.
15. **Автоматизоване сканування вразливостей**: Регулярно скануйте сервери MCP та залежності на наявність відомих вразливостей.

## Ресурси для підтримки найкращих практик безпеки MCP

### Перевірка введених даних
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Запобігання prompt injection у MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Реалізація Azure Content Safety](./azure-content-safety-implementation.md)

### Контроль доступу
- [Специфікація авторизації MCP](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Використання Microsoft Entra ID з серверами MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management як шлюз автентифікації для MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Безпечне спілкування
- [Найкращі практики Transport Layer Security (TLS)](https://learn.microsoft.com/security/engineering/solving-tls)
- [Керівництво з безпеки транспорту MCP](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End шифрування для AI-навантажень](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Обмеження частоти запитів
- [Патерни обмеження частоти API](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Реалізація обмеження частоти за допомогою token bucket](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Обмеження частоти в Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Логування та моніторинг
- [Централізоване логування для AI-систем](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Найкращі практики аудиту логів](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor для AI-навантажень](https://learn.microsoft.com/azure/azure-monitor/overview)

### Безпечне зберігання
- [Azure Key Vault для зберігання облікових даних](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Шифрування конфіденційних даних у стані спокою](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Використання безпечного зберігання токенів та їх шифрування](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Управління токенами
- [Найкращі практики JWT (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [Найкращі практики безпеки OAuth 2.0 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Найкращі практики валідації токенів та їх життєвого циклу](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Управління сесіями
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [Керівництво з обробки сесій MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Патерни безпечного дизайну сесій](https://learn.microsoft.com/security/engineering/session-security)

### Ізоляція виконання інструментів
- [Найкращі практики безпеки контейнерів](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Реалізація ізоляції процесів](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Обмеження ресурсів для контейнеризованих додатків](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Регулярні аудити безпеки
- [Життєвий цикл розробки безпеки Microsoft](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Керівництво з огляду коду безпеки](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Перевірка запитів (prompt validation)
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety для AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Запобігання prompt injection](https://github.com/microsoft/prompt-shield-js)

### Делегування автентифікації
- [Інтеграція Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 для сервісів MCP](https://learn.microsoft.com/security/engineering/solving-oauth)
- [Контролі безпеки MCP 2025](./mcp-security-controls-2025.md)

### Обмеження прав доступу
- [Безпечний доступ з найменшими привілеями](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Проєктування RBAC (керування доступом на основі ролей)](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Авторизація для конкретних інструментів у MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Мінімізація даних
- [Захист даних за принципом Privacy by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [Найкращі практики конфіденційності даних AI](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Впровадження технологій, що підвищують конфіденційність](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Автоматизоване сканування вразливостей
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Реалізація DevSecOps pipeline](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Безперервна перевірка безпеки](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Відмова від відповідальності**:  
Цей документ було перекладено за допомогою сервісу автоматичного перекладу [Co-op Translator](https://github.com/Azure/co-op-translator). Хоча ми прагнемо до точності, будь ласка, майте на увазі, що автоматичні переклади можуть містити помилки або неточності. Оригінальний документ рідною мовою слід вважати авторитетним джерелом. Для критично важливої інформації рекомендується звертатися до професійного людського перекладу. Ми не несемо відповідальності за будь-які непорозуміння або неправильні тлумачення, що виникли внаслідок використання цього перекладу.