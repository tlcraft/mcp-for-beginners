<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T01:50:58+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "ru"
}
-->
# Лучшие практики безопасности MCP

При работе с серверами MCP следуйте этим рекомендациям по безопасности, чтобы защитить свои данные, инфраструктуру и пользователей:

1. **Проверка входных данных**: Всегда проверяйте и очищайте входные данные, чтобы предотвратить инъекции и проблемы с «запутанным посредником».
2. **Контроль доступа**: Реализуйте надёжную аутентификацию и авторизацию для вашего MCP-сервера с детализированными правами доступа.
3. **Безопасная связь**: Используйте HTTPS/TLS для всех коммуникаций с MCP-сервером и рассмотрите возможность дополнительного шифрования для чувствительных данных.
4. **Ограничение частоты запросов**: Внедряйте лимиты на количество запросов, чтобы предотвратить злоупотребления, DoS-атаки и контролировать потребление ресурсов.
5. **Логирование и мониторинг**: Отслеживайте подозрительную активность на MCP-сервере и обеспечьте полный аудит действий.
6. **Безопасное хранение**: Защищайте конфиденциальные данные и учётные данные с помощью надлежащего шифрования при хранении.
7. **Управление токенами**: Предотвращайте уязвимости, связанные с передачей токенов, проверяя и очищая все входные и выходные данные моделей.
8. **Управление сессиями**: Обеспечьте безопасное управление сессиями, чтобы избежать перехвата и фиксации сессий.
9. **Изоляция выполнения инструментов**: Запускайте инструменты в изолированных средах, чтобы предотвратить распространение угроз при компрометации.
10. **Регулярные аудиты безопасности**: Проводите периодические проверки безопасности ваших реализаций MCP и зависимостей.
11. **Проверка подсказок**: Анализируйте и фильтруйте как входящие, так и исходящие подсказки, чтобы предотвратить атаки с внедрением подсказок.
12. **Делегирование аутентификации**: Используйте проверенных провайдеров идентификации вместо самостоятельной реализации аутентификации.
13. **Ограничение прав доступа**: Внедряйте детализированные права для каждого инструмента и ресурса, следуя принципу минимально необходимых привилегий.
14. **Минимизация данных**: Предоставляйте только минимально необходимую информацию для каждой операции, чтобы снизить поверхность риска.
15. **Автоматизированное сканирование уязвимостей**: Регулярно проверяйте MCP-серверы и зависимости на известные уязвимости.

## Ресурсы для поддержки лучших практик безопасности MCP

### Проверка входных данных
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Предотвращение внедрения подсказок в MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Реализация Azure Content Safety](./azure-content-safety-implementation.md)

### Контроль доступа
- [Спецификация авторизации MCP](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Использование Microsoft Entra ID с MCP-серверами](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management как шлюз аутентификации для MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Безопасная связь
- [Лучшие практики Transport Layer Security (TLS)](https://learn.microsoft.com/security/engineering/solving-tls)
- [Руководство по безопасности транспорта MCP](https://modelcontextprotocol.io/docs/concepts/transports)
- [Сквозное шифрование для AI-нагрузок](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Ограничение частоты запросов
- [Паттерны ограничения частоты API](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Реализация алгоритма Token Bucket для ограничения частоты](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Ограничение частоты в Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Логирование и мониторинг
- [Централизованное логирование для AI-систем](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Лучшие практики аудита логов](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor для AI-нагрузок](https://learn.microsoft.com/azure/azure-monitor/overview)

### Безопасное хранение
- [Azure Key Vault для хранения учётных данных](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Шифрование чувствительных данных при хранении](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Использование безопасного хранения токенов и их шифрование](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Управление токенами
- [Лучшие практики JWT (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [Лучшие практики безопасности OAuth 2.0 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Рекомендации по проверке токенов и срокам их действия](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Управление сессиями
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [Руководство по управлению сессиями MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Паттерны безопасного проектирования сессий](https://learn.microsoft.com/security/engineering/session-security)

### Изоляция выполнения инструментов
- [Лучшие практики безопасности контейнеров](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Реализация изоляции процессов](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Ограничения ресурсов для контейнеризованных приложений](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Регулярные аудиты безопасности
- [Жизненный цикл разработки безопасности Microsoft](https://www.microsoft.com/sdl)
- [Стандарт проверки безопасности приложений OWASP](https://owasp.org/www-project-application-security-verification-standard/)
- [Руководство по обзору кода безопасности](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Проверка подсказок
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety для AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Предотвращение внедрения подсказок](https://github.com/microsoft/prompt-shield-js)

### Делегирование аутентификации
- [Интеграция Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 для MCP-сервисов](https://learn.microsoft.com/security/engineering/solving-oauth)
- [Контроль безопасности MCP 2025](./mcp-security-controls-2025.md)

### Ограничение прав доступа
- [Безопасный доступ с минимальными привилегиями](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Проектирование RBAC (ролевой контроль доступа)](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Авторизация для конкретных инструментов в MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Минимизация данных
- [Защита данных на этапе проектирования](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [Лучшие практики конфиденциальности данных AI](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Внедрение технологий повышения конфиденциальности](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Автоматизированное сканирование уязвимостей
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Реализация DevSecOps pipeline](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Непрерывная проверка безопасности](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Отказ от ответственности**:  
Этот документ был переведен с помощью сервиса автоматического перевода [Co-op Translator](https://github.com/Azure/co-op-translator). Несмотря на наши усилия по обеспечению точности, просим учитывать, что автоматический перевод может содержать ошибки или неточности. Оригинальный документ на его исходном языке следует считать авторитетным источником. Для получения критически важной информации рекомендуется обращаться к профессиональному переводу, выполненному человеком. Мы не несем ответственности за любые недоразумения или неправильные толкования, возникшие в результате использования данного перевода.