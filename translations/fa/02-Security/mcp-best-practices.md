<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-16T23:09:21+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "fa"
}
-->
# بهترین شیوه‌های امنیتی MCP

هنگام کار با سرورهای MCP، برای محافظت از داده‌ها، زیرساخت و کاربران خود، این بهترین شیوه‌های امنیتی را رعایت کنید:

1. **اعتبارسنجی ورودی**: همیشه ورودی‌ها را اعتبارسنجی و پاک‌سازی کنید تا از حملات تزریق و مشکلات نماینده گیج جلوگیری شود.
2. **کنترل دسترسی**: احراز هویت و مجوزدهی مناسب با دسترسی‌های دقیق برای سرور MCP خود پیاده‌سازی کنید.
3. **ارتباط امن**: برای تمام ارتباطات با سرور MCP از HTTPS/TLS استفاده کنید و در صورت نیاز رمزنگاری اضافی برای داده‌های حساس در نظر بگیرید.
4. **محدودیت نرخ درخواست**: محدودیت نرخ درخواست را پیاده‌سازی کنید تا از سوءاستفاده، حملات DoS و مدیریت مصرف منابع جلوگیری شود.
5. **ثبت و نظارت**: فعالیت‌های مشکوک سرور MCP خود را پایش کنید و مسیرهای حسابرسی جامع ایجاد نمایید.
6. **ذخیره‌سازی امن**: داده‌ها و اطلاعات حساس را با رمزنگاری مناسب در حالت استراحت محافظت کنید.
7. **مدیریت توکن**: با اعتبارسنجی و پاک‌سازی تمام ورودی‌ها و خروجی‌های مدل، از آسیب‌پذیری‌های عبور توکن جلوگیری کنید.
8. **مدیریت نشست**: مدیریت امن نشست‌ها را پیاده‌سازی کنید تا از ربودن و تثبیت نشست جلوگیری شود.
9. **اجرای ابزار در محیط ایزوله**: اجرای ابزارها را در محیط‌های جداگانه انجام دهید تا در صورت نفوذ، حرکت جانبی محدود شود.
10. **بازرسی‌های امنیتی منظم**: بازبینی‌های دوره‌ای امنیتی روی پیاده‌سازی‌ها و وابستگی‌های MCP انجام دهید.
11. **اعتبارسنجی پرامپت**: ورودی‌ها و خروجی‌های پرامپت را اسکن و فیلتر کنید تا از حملات تزریق پرامپت جلوگیری شود.
12. **واگذاری احراز هویت**: به جای پیاده‌سازی احراز هویت سفارشی، از ارائه‌دهندگان هویت معتبر استفاده کنید.
13. **محدوده‌بندی مجوزها**: مجوزهای دقیق برای هر ابزار و منبع با رعایت اصل حداقل دسترسی پیاده‌سازی کنید.
14. **کاهش داده‌ها**: فقط حداقل داده‌های لازم برای هر عملیات را در دسترس قرار دهید تا سطح ریسک کاهش یابد.
15. **اسکن خودکار آسیب‌پذیری‌ها**: به‌طور منظم سرورها و وابستگی‌های MCP را برای آسیب‌پذیری‌های شناخته‌شده اسکن کنید.

## منابع پشتیبان برای بهترین شیوه‌های امنیتی MCP

### اعتبارسنجی ورودی
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### کنترل دسترسی
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### ارتباط امن
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### محدودیت نرخ درخواست
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### ثبت و نظارت
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### ذخیره‌سازی امن
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### مدیریت توکن
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### مدیریت نشست
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### اجرای ابزار در محیط ایزوله
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### بازرسی‌های امنیتی منظم
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### اعتبارسنجی پرامپت
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### واگذاری احراز هویت
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### محدوده‌بندی مجوزها
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### کاهش داده‌ها
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### اسکن خودکار آسیب‌پذیری‌ها
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نواقصی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.