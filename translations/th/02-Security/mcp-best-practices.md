<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T08:47:27+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "th"
}
-->
# MCP แนวทางปฏิบัติด้านความปลอดภัยที่ดีที่สุด

เมื่อทำงานกับเซิร์ฟเวอร์ MCP ให้ปฏิบัติตามแนวทางปฏิบัติด้านความปลอดภัยเหล่านี้เพื่อปกป้องข้อมูล โครงสร้างพื้นฐาน และผู้ใช้ของคุณ:

1. **การตรวจสอบข้อมูลนำเข้า**: ตรวจสอบและทำความสะอาดข้อมูลนำเข้าเสมอเพื่อป้องกันการโจมตีแบบ injection และปัญหา confused deputy
2. **การควบคุมการเข้าถึง**: ใช้การพิสูจน์ตัวตนและการอนุญาตที่เหมาะสมสำหรับเซิร์ฟเวอร์ MCP ของคุณโดยมีสิทธิ์การเข้าถึงที่ละเอียด
3. **การสื่อสารที่ปลอดภัย**: ใช้ HTTPS/TLS สำหรับการสื่อสารทั้งหมดกับเซิร์ฟเวอร์ MCP และพิจารณาเพิ่มการเข้ารหัสเพิ่มเติมสำหรับข้อมูลที่มีความละเอียดอ่อน
4. **การจำกัดอัตราการใช้งาน**: ใช้การจำกัดอัตราเพื่อป้องกันการใช้งานเกินขอบเขต การโจมตี DoS และจัดการการใช้ทรัพยากร
5. **การบันทึกและการตรวจสอบ**: ตรวจสอบเซิร์ฟเวอร์ MCP ของคุณเพื่อหากิจกรรมที่น่าสงสัยและจัดทำบันทึกตรวจสอบอย่างครบถ้วน
6. **การจัดเก็บที่ปลอดภัย**: ปกป้องข้อมูลและข้อมูลรับรองที่มีความละเอียดอ่อนด้วยการเข้ารหัสที่เหมาะสมขณะจัดเก็บ
7. **การจัดการโทเค็น**: ป้องกันช่องโหว่ token passthrough โดยการตรวจสอบและทำความสะอาดข้อมูลนำเข้าและผลลัพธ์ของโมเดลทั้งหมด
8. **การจัดการเซสชัน**: ใช้การจัดการเซสชันที่ปลอดภัยเพื่อป้องกันการแฮ็กเซสชันและการโจมตีแบบ fixation
9. **การแยกสภาพแวดล้อมการรันเครื่องมือ**: รันการทำงานของเครื่องมือในสภาพแวดล้อมที่แยกออกจากกันเพื่อป้องกันการเคลื่อนที่ในระบบหากถูกโจมตี
10. **การตรวจสอบความปลอดภัยเป็นประจำ**: ดำเนินการตรวจสอบความปลอดภัยเป็นระยะสำหรับการใช้งาน MCP และส่วนประกอบที่เกี่ยวข้อง
11. **การตรวจสอบคำสั่ง (Prompt Validation)**: สแกนและกรองคำสั่งทั้งขาเข้าและขาออกเพื่อป้องกันการโจมตีแบบ prompt injection
12. **การมอบหมายการพิสูจน์ตัวตน**: ใช้ผู้ให้บริการตัวตนที่ได้รับการยอมรับแทนการสร้างระบบพิสูจน์ตัวตนเอง
13. **การกำหนดขอบเขตสิทธิ์**: กำหนดสิทธิ์อย่างละเอียดสำหรับแต่ละเครื่องมือและทรัพยากรตามหลักการ least privilege
14. **การลดข้อมูลที่เปิดเผย**: เปิดเผยข้อมูลให้น้อยที่สุดเท่าที่จำเป็นสำหรับแต่ละการทำงานเพื่อลดความเสี่ยง
15. **การสแกนหาช่องโหว่อัตโนมัติ**: สแกนเซิร์ฟเวอร์ MCP และส่วนประกอบที่เกี่ยวข้องเป็นประจำเพื่อหาช่องโหว่ที่รู้จัก

## แหล่งข้อมูลสนับสนุนสำหรับแนวทางปฏิบัติด้านความปลอดภัย MCP

### การตรวจสอบข้อมูลนำเข้า
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### การควบคุมการเข้าถึง
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### การสื่อสารที่ปลอดภัย
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### การจำกัดอัตราการใช้งาน
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### การบันทึกและการตรวจสอบ
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### การจัดเก็บที่ปลอดภัย
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### การจัดการโทเค็น
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### การจัดการเซสชัน
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### การแยกสภาพแวดล้อมการรันเครื่องมือ
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### การตรวจสอบความปลอดภัยเป็นประจำ
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### การตรวจสอบคำสั่ง (Prompt Validation)
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### การมอบหมายการพิสูจน์ตัวตน
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### การกำหนดขอบเขตสิทธิ์
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### การลดข้อมูลที่เปิดเผย
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### การสแกนหาช่องโหว่อัตโนมัติ
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**ข้อจำกัดความรับผิดชอบ**:  
เอกสารนี้ได้รับการแปลโดยใช้บริการแปลภาษาอัตโนมัติ [Co-op Translator](https://github.com/Azure/co-op-translator) แม้เราจะพยายามให้ความถูกต้องสูงสุด แต่โปรดทราบว่าการแปลอัตโนมัติอาจมีข้อผิดพลาดหรือความไม่ถูกต้อง เอกสารต้นฉบับในภาษาต้นทางถือเป็นแหล่งข้อมูลที่เชื่อถือได้ สำหรับข้อมูลที่สำคัญ ขอแนะนำให้ใช้บริการแปลโดยผู้เชี่ยวชาญมนุษย์ เราไม่รับผิดชอบต่อความเข้าใจผิดหรือการตีความผิดใด ๆ ที่เกิดจากการใช้การแปลนี้