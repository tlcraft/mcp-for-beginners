<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T01:51:32+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "ur"
}
-->
# MCP سیکیورٹی بہترین طریقے

جب آپ MCP سرورز کے ساتھ کام کر رہے ہوں تو اپنے ڈیٹا، انفراسٹرکچر، اور صارفین کی حفاظت کے لیے درج ذیل سیکیورٹی بہترین طریقے اپنائیں:

1. **ان پٹ کی تصدیق**: ہمیشہ ان پٹس کی تصدیق اور صفائی کریں تاکہ injection حملوں اور confused deputy مسائل سے بچا جا سکے۔
2. **رسائی کنٹرول**: اپنے MCP سرور کے لیے مناسب authentication اور authorization نافذ کریں، اور permissions کو باریک بینی سے ترتیب دیں۔
3. **محفوظ مواصلات**: اپنے MCP سرور کے ساتھ تمام مواصلات کے لیے HTTPS/TLS استعمال کریں اور حساس ڈیٹا کے لیے اضافی انکرپشن پر غور کریں۔
4. **ریٹ لمٹنگ**: غلط استعمال، DoS حملوں، اور وسائل کے انتظام کے لیے ریٹ لمٹنگ نافذ کریں۔
5. **لاگنگ اور مانیٹرنگ**: اپنے MCP سرور کی مشکوک سرگرمیوں کی نگرانی کریں اور مکمل audit trails نافذ کریں۔
6. **محفوظ ذخیرہ**: حساس ڈیٹا اور اسناد کو محفوظ رکھنے کے لیے مناسب انکرپشن کا استعمال کریں۔
7. **ٹوکن مینجمنٹ**: تمام ماڈل ان پٹس اور آؤٹ پٹس کی تصدیق اور صفائی کر کے token passthrough کی کمزوریوں سے بچیں۔
8. **سیشن مینجمنٹ**: سیشن ہائی جیکنگ اور fixation حملوں سے بچاؤ کے لیے محفوظ سیشن ہینڈلنگ نافذ کریں۔
9. **ٹول ایکزیکیوشن سینڈباکسنگ**: اگر کوئی کمپرو مائز ہو جائے تو lateral movement کو روکنے کے لیے ٹولز کو الگ تھلگ ماحول میں چلائیں۔
10. **باقاعدہ سیکیورٹی آڈٹس**: اپنے MCP implementations اور dependencies کا باقاعدہ سیکیورٹی جائزہ لیں۔
11. **پرومپٹ کی تصدیق**: پرومپٹ injection حملوں سے بچنے کے لیے ان پٹ اور آؤٹ پٹ دونوں پرومپٹس کو اسکین اور فلٹر کریں۔
12. **authentication delegation**: اپنی مرضی کا authentication بنانے کی بجائے معروف identity providers استعمال کریں۔
13. **permission scoping**: ہر ٹول اور resource کے لیے granular permissions نافذ کریں، کم از کم ضروری حقوق کے اصول کی پیروی کرتے ہوئے۔
14. **ڈیٹا کی کمی**: ہر آپریشن کے لیے صرف ضروری کم از کم ڈیٹا ظاہر کریں تاکہ خطرے کی سطح کم ہو۔
15. **خودکار کمزوری اسکیننگ**: اپنے MCP سرورز اور dependencies کو معروف کمزوریوں کے لیے باقاعدگی سے اسکین کریں۔

## MCP سیکیورٹی بہترین طریقوں کے لیے معاون وسائل

### ان پٹ کی تصدیق
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### رسائی کنٹرول
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### محفوظ مواصلات
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### ریٹ لمٹنگ
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### لاگنگ اور مانیٹرنگ
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### محفوظ ذخیرہ
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### ٹوکن مینجمنٹ
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### سیشن مینجمنٹ
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### ٹول ایکزیکیوشن سینڈباکسنگ
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### باقاعدہ سیکیورٹی آڈٹس
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### پرومپٹ کی تصدیق
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### authentication delegation
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### permission scoping
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### ڈیٹا کی کمی
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### خودکار کمزوری اسکیننگ
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجموں میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔