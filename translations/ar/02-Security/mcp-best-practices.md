<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T01:51:17+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "ar"
}
-->
# أفضل ممارسات الأمان لـ MCP

عند العمل مع خوادم MCP، اتبع أفضل ممارسات الأمان هذه لحماية بياناتك وبنيتك التحتية والمستخدمين:

1. **التحقق من المدخلات**: تحقق دائمًا من صحة المدخلات ونقّها لمنع هجمات الحقن ومشاكل الوكيل المضلل.
2. **التحكم في الوصول**: نفذ المصادقة والتفويض المناسبين لخادم MCP الخاص بك مع أذونات دقيقة.
3. **الاتصال الآمن**: استخدم HTTPS/TLS لجميع الاتصالات مع خادم MCP وفكر في إضافة تشفير إضافي للبيانات الحساسة.
4. **تحديد المعدل**: نفذ تحديد المعدل لمنع سوء الاستخدام وهجمات حجب الخدمة ولإدارة استهلاك الموارد.
5. **التسجيل والمراقبة**: راقب خادم MCP الخاص بك للنشاط المشبوه وطبق سجلات تدقيق شاملة.
6. **التخزين الآمن**: احمِ البيانات الحساسة وبيانات الاعتماد بالتشفير المناسب أثناء التخزين.
7. **إدارة الرموز**: امنع ثغرات تمرير الرموز من خلال التحقق وتنقية جميع مدخلات ومخرجات النماذج.
8. **إدارة الجلسات**: نفذ معالجة آمنة للجلسات لمنع اختطاف الجلسات وهجمات التثبيت.
9. **عزل تنفيذ الأدوات**: شغّل تنفيذ الأدوات في بيئات معزولة لمنع الحركة الجانبية في حال تم اختراقها.
10. **مراجعات أمان دورية**: أجرِ مراجعات أمنية دورية لتطبيقات MCP والاعتمادات التابعة لها.
11. **التحقق من المطالبات**: افحص وفلتر كل من مطالبات الإدخال والإخراج لمنع هجمات حقن المطالبات.
12. **تفويض المصادقة**: استخدم مزودي هوية معتمدين بدلاً من تنفيذ مصادقة مخصصة.
13. **تحديد نطاق الأذونات**: طبق أذونات دقيقة لكل أداة وموارد وفقًا لمبدأ أقل الامتيازات.
14. **تقليل البيانات**: اكشف فقط الحد الأدنى من البيانات اللازمة لكل عملية لتقليل سطح المخاطر.
15. **فحص الثغرات الآلي**: افحص خوادم MCP والاعتمادات التابعة لها بانتظام بحثًا عن الثغرات المعروفة.

## الموارد الداعمة لأفضل ممارسات أمان MCP

### التحقق من المدخلات
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### التحكم في الوصول
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### الاتصال الآمن
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### تحديد المعدل
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### التسجيل والمراقبة
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### التخزين الآمن
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### إدارة الرموز
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### إدارة الجلسات
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### عزل تنفيذ الأدوات
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### مراجعات أمان دورية
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### التحقق من المطالبات
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### تفويض المصادقة
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### تحديد نطاق الأذونات
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### تقليل البيانات
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### فحص الثغرات الآلي
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.