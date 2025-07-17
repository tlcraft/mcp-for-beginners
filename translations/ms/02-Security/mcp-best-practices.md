<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T08:50:50+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "ms"
}
-->
# Amalan Terbaik Keselamatan MCP

Apabila bekerja dengan pelayan MCP, ikut amalan terbaik keselamatan ini untuk melindungi data, infrastruktur, dan pengguna anda:

1. **Pengesahan Input**: Sentiasa sahkan dan bersihkan input untuk mengelakkan serangan suntikan dan masalah confused deputy.
2. **Kawalan Akses**: Laksanakan pengesahan dan kebenaran yang betul untuk pelayan MCP anda dengan kebenaran yang terperinci.
3. **Komunikasi Selamat**: Gunakan HTTPS/TLS untuk semua komunikasi dengan pelayan MCP anda dan pertimbangkan menambah penyulitan tambahan untuk data sensitif.
4. **Had Kadar**: Laksanakan had kadar untuk mengelakkan penyalahgunaan, serangan DoS, dan mengurus penggunaan sumber.
5. **Pencatatan dan Pemantauan**: Pantau pelayan MCP anda untuk aktiviti mencurigakan dan laksanakan jejak audit yang menyeluruh.
6. **Penyimpanan Selamat**: Lindungi data sensitif dan kelayakan dengan penyulitan yang betul semasa disimpan.
7. **Pengurusan Token**: Elakkan kelemahan token passthrough dengan mengesahkan dan membersihkan semua input dan output model.
8. **Pengurusan Sesi**: Laksanakan pengendalian sesi yang selamat untuk mengelakkan penculikan dan serangan penetapan sesi.
9. **Sandbox Pelaksanaan Alat**: Jalankan pelaksanaan alat dalam persekitaran terasing untuk mengelakkan pergerakan sisi jika dikompromi.
10. **Audit Keselamatan Berkala**: Jalankan semakan keselamatan berkala terhadap pelaksanaan MCP dan kebergantungan anda.
11. **Pengesahan Prompt**: Imbas dan tapis kedua-dua prompt input dan output untuk mengelakkan serangan suntikan prompt.
12. **Delegasi Pengesahan**: Gunakan penyedia identiti yang telah ditetapkan daripada melaksanakan pengesahan tersuai.
13. **Skop Kebenaran**: Laksanakan kebenaran terperinci untuk setiap alat dan sumber mengikut prinsip keistimewaan minimum.
14. **Pengurangan Data**: Dedahkan hanya data minimum yang diperlukan untuk setiap operasi bagi mengurangkan permukaan risiko.
15. **Imbasan Kerentanan Automatik**: Imbas secara berkala pelayan MCP dan kebergantungan anda untuk kerentanan yang diketahui.

## Sumber Sokongan untuk Amalan Terbaik Keselamatan MCP

### Pengesahan Input
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Kawalan Akses
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Komunikasi Selamat
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Had Kadar
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Pencatatan dan Pemantauan
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Penyimpanan Selamat
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Pengurusan Token
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Pengurusan Sesi
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Sandbox Pelaksanaan Alat
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Audit Keselamatan Berkala
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Pengesahan Prompt
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Delegasi Pengesahan
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Skop Kebenaran
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Pengurangan Data
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Imbasan Kerentanan Automatik
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Penafian**:  
Dokumen ini telah diterjemahkan menggunakan perkhidmatan terjemahan AI [Co-op Translator](https://github.com/Azure/co-op-translator). Walaupun kami berusaha untuk ketepatan, sila ambil maklum bahawa terjemahan automatik mungkin mengandungi kesilapan atau ketidaktepatan. Dokumen asal dalam bahasa asalnya harus dianggap sebagai sumber yang sahih. Untuk maklumat penting, terjemahan profesional oleh manusia adalah disyorkan. Kami tidak bertanggungjawab atas sebarang salah faham atau salah tafsir yang timbul daripada penggunaan terjemahan ini.