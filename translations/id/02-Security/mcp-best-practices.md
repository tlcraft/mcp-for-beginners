<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T08:50:30+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "id"
}
-->
# Praktik Terbaik Keamanan MCP

Saat bekerja dengan server MCP, ikuti praktik terbaik keamanan ini untuk melindungi data, infrastruktur, dan pengguna Anda:

1. **Validasi Input**: Selalu validasi dan bersihkan input untuk mencegah serangan injeksi dan masalah confused deputy.
2. **Kontrol Akses**: Terapkan autentikasi dan otorisasi yang tepat untuk server MCP Anda dengan izin yang terperinci.
3. **Komunikasi Aman**: Gunakan HTTPS/TLS untuk semua komunikasi dengan server MCP Anda dan pertimbangkan menambahkan enkripsi tambahan untuk data sensitif.
4. **Pembatasan Laju**: Terapkan pembatasan laju untuk mencegah penyalahgunaan, serangan DoS, dan mengelola konsumsi sumber daya.
5. **Logging dan Pemantauan**: Pantau server MCP Anda untuk aktivitas mencurigakan dan terapkan jejak audit yang komprehensif.
6. **Penyimpanan Aman**: Lindungi data sensitif dan kredensial dengan enkripsi yang tepat saat disimpan.
7. **Manajemen Token**: Cegah kerentanan token passthrough dengan memvalidasi dan membersihkan semua input dan output model.
8. **Manajemen Sesi**: Terapkan penanganan sesi yang aman untuk mencegah pembajakan dan serangan session fixation.
9. **Sandboxing Eksekusi Alat**: Jalankan eksekusi alat di lingkungan terisolasi untuk mencegah pergerakan lateral jika terjadi kompromi.
10. **Audit Keamanan Berkala**: Lakukan tinjauan keamanan secara berkala pada implementasi dan dependensi MCP Anda.
11. **Validasi Prompt**: Pindai dan saring prompt input dan output untuk mencegah serangan prompt injection.
12. **Delegasi Autentikasi**: Gunakan penyedia identitas yang sudah mapan daripada membuat autentikasi kustom.
13. **Pembatasan Izin**: Terapkan izin granular untuk setiap alat dan sumber daya sesuai prinsip least privilege.
14. **Minimisasi Data**: Hanya tampilkan data minimum yang diperlukan untuk setiap operasi guna mengurangi risiko.
15. **Pemindaian Kerentanan Otomatis**: Secara rutin pindai server MCP dan dependensi Anda untuk kerentanan yang diketahui.

## Sumber Dukung untuk Praktik Terbaik Keamanan MCP

### Validasi Input
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Kontrol Akses
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Komunikasi Aman
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Pembatasan Laju
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Logging dan Pemantauan
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Penyimpanan Aman
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Manajemen Token
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Manajemen Sesi
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Sandboxing Eksekusi Alat
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Audit Keamanan Berkala
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Validasi Prompt
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Delegasi Autentikasi
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Pembatasan Izin
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimisasi Data
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Pemindaian Kerentanan Otomatis
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan layanan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Meskipun kami berupaya untuk mencapai akurasi, harap diperhatikan bahwa terjemahan otomatis mungkin mengandung kesalahan atau ketidakakuratan. Dokumen asli dalam bahasa aslinya harus dianggap sebagai sumber yang sahih. Untuk informasi penting, disarankan menggunakan terjemahan profesional oleh manusia. Kami tidak bertanggung jawab atas kesalahpahaman atau penafsiran yang keliru yang timbul dari penggunaan terjemahan ini.