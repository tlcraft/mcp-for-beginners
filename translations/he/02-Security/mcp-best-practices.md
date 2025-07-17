<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T08:49:46+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "he"
}
-->
# שיטות עבודה מומלצות לאבטחת MCP

בעת עבודה עם שרתי MCP, יש לעקוב אחרי שיטות עבודה מומלצות לאבטחה כדי להגן על הנתונים, התשתית והמשתמשים שלך:

1. **אימות קלט**: תמיד לאמת ולנקות את הקלטים כדי למנוע התקפות הזרקה ובעיות של נציג מבולבל.
2. **בקרת גישה**: ליישם אימות והרשאות מתאימות לשרת MCP שלך עם הרשאות מדויקות.
3. **תקשורת מאובטחת**: להשתמש ב-HTTPS/TLS לכל התקשורת עם שרת MCP ולשקול הוספת הצפנה נוספת לנתונים רגישים.
4. **הגבלת קצב**: ליישם הגבלת קצב כדי למנוע שימוש לרעה, התקפות DoS ולנהל את צריכת המשאבים.
5. **רישום ומעקב**: לעקוב אחרי פעילות חשודה בשרת MCP וליישם רישומי ביקורת מקיפים.
6. **אחסון מאובטח**: להגן על נתונים רגישים ואישורים עם הצפנה מתאימה במצב מנוחה.
7. **ניהול טוקנים**: למנוע פגיעויות של העברת טוקנים על ידי אימות וניקוי כל הקלטים והפלטים של המודל.
8. **ניהול סשנים**: ליישם טיפול מאובטח בסשנים כדי למנוע חטיפת סשנים והתקפות קיבוע.
9. **הרצת כלים בסביבה מבודדת**: להריץ את הכלים בסביבות מבודדות כדי למנוע תנועה רוחבית במקרה של פגיעה.
10. **בדיקות אבטחה תקופתיות**: לבצע סקירות אבטחה תקופתיות של יישומי MCP והתלויות שלהם.
11. **אימות פרומפטים**: לסרוק ולסנן פרומפטים נכנסים ויוצאים כדי למנוע התקפות הזרקת פרומפט.
12. **הסמכת אימות**: להשתמש בספקי זהות מוכרים במקום ליישם אימות מותאם אישית.
13. **הגבלת הרשאות**: ליישם הרשאות מדויקות לכל כלי ומשאב בהתאם לעקרונות המינימום הנדרש.
14. **מזעור נתונים**: לחשוף רק את הנתונים המינימליים הנדרשים לכל פעולה כדי לצמצם את שטח הסיכון.
15. **סריקה אוטומטית לפגיעויות**: לסרוק באופן קבוע את שרתי MCP והתלויות שלהם לפגיעויות ידועות.

## משאבים תומכים לשיטות עבודה מומלצות לאבטחת MCP

### אימות קלט
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### בקרת גישה
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### תקשורת מאובטחת
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### הגבלת קצב
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### רישום ומעקב
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### אחסון מאובטח
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### ניהול טוקנים
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### ניהול סשנים
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### הרצת כלים בסביבה מבודדת
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### בדיקות אבטחה תקופתיות
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### אימות פרומפטים
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### הסמכת אימות
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### הגבלת הרשאות
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### מזעור נתונים
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### סריקה אוטומטית לפגיעויות
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**כתב ויתור**:  
מסמך זה תורגם באמצעות שירות תרגום מבוסס בינה מלאכותית [Co-op Translator](https://github.com/Azure/co-op-translator). למרות שאנו שואפים לדיוק, יש לקחת בחשבון כי תרגומים אוטומטיים עלולים להכיל שגיאות או אי-דיוקים. המסמך המקורי בשפת המקור שלו צריך להיחשב כמקור הסמכות. למידע קריטי מומלץ להשתמש בתרגום מקצועי על ידי מתרגם אנושי. אנו לא נושאים באחריות לכל אי-הבנה או פרשנות שגויה הנובעת משימוש בתרגום זה.