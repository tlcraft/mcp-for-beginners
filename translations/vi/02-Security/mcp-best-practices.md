<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T08:50:07+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "vi"
}
-->
# Thực Tiễn Bảo Mật Tốt Nhất cho MCP

Khi làm việc với các máy chủ MCP, hãy tuân theo các thực tiễn bảo mật tốt nhất sau để bảo vệ dữ liệu, hạ tầng và người dùng của bạn:

1. **Xác Thực Đầu Vào**: Luôn xác thực và làm sạch dữ liệu đầu vào để ngăn chặn các cuộc tấn công tiêm nhiễm và các vấn đề confused deputy.
2. **Kiểm Soát Truy Cập**: Triển khai xác thực và ủy quyền phù hợp cho máy chủ MCP của bạn với các quyền truy cập chi tiết.
3. **Giao Tiếp An Toàn**: Sử dụng HTTPS/TLS cho tất cả các giao tiếp với máy chủ MCP và cân nhắc thêm mã hóa bổ sung cho dữ liệu nhạy cảm.
4. **Giới Hạn Tốc Độ**: Áp dụng giới hạn tốc độ để ngăn chặn lạm dụng, tấn công DoS và quản lý việc sử dụng tài nguyên.
5. **Ghi Nhật Ký và Giám Sát**: Theo dõi máy chủ MCP để phát hiện hoạt động đáng ngờ và triển khai các bản ghi kiểm toán toàn diện.
6. **Lưu Trữ An Toàn**: Bảo vệ dữ liệu nhạy cảm và thông tin đăng nhập bằng mã hóa thích hợp khi lưu trữ.
7. **Quản Lý Token**: Ngăn ngừa các lỗ hổng token passthrough bằng cách xác thực và làm sạch tất cả đầu vào và đầu ra của mô hình.
8. **Quản Lý Phiên Làm Việc**: Triển khai xử lý phiên làm việc an toàn để ngăn chặn chiếm đoạt và cố định phiên.
9. **Chạy Công Cụ Trong Môi Trường Cách Ly**: Thực thi các công cụ trong môi trường tách biệt để ngăn chặn di chuyển ngang nếu bị xâm phạm.
10. **Kiểm Tra Bảo Mật Định Kỳ**: Thực hiện đánh giá bảo mật định kỳ cho các triển khai MCP và các phụ thuộc.
11. **Xác Thực Prompt**: Quét và lọc cả prompt đầu vào và đầu ra để ngăn chặn các cuộc tấn công tiêm nhiễm prompt.
12. **Ủy Quyền Xác Thực**: Sử dụng các nhà cung cấp danh tính đã được thiết lập thay vì tự triển khai xác thực tùy chỉnh.
13. **Phân Quyền Chi Tiết**: Áp dụng quyền truy cập chi tiết cho từng công cụ và tài nguyên theo nguyên tắc quyền ít nhất.
14. **Giảm Thiểu Dữ Liệu**: Chỉ cung cấp dữ liệu tối thiểu cần thiết cho mỗi thao tác để giảm bề mặt rủi ro.
15. **Quét Lỗ Hổng Tự Động**: Thường xuyên quét các máy chủ MCP và các phụ thuộc để phát hiện các lỗ hổng đã biết.

## Tài Nguyên Hỗ Trợ cho Thực Tiễn Bảo Mật MCP

### Xác Thực Đầu Vào
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Kiểm Soát Truy Cập
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Giao Tiếp An Toàn
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Giới Hạn Tốc Độ
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Ghi Nhật Ký và Giám Sát
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Lưu Trữ An Toàn
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Quản Lý Token
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Quản Lý Phiên Làm Việc
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Chạy Công Cụ Trong Môi Trường Cách Ly
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Kiểm Tra Bảo Mật Định Kỳ
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Xác Thực Prompt
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Ủy Quyền Xác Thực
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Phân Quyền Chi Tiết
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Giảm Thiểu Dữ Liệu
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Quét Lỗ Hổng Tự Động
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Tuyên bố từ chối trách nhiệm**:  
Tài liệu này đã được dịch bằng dịch vụ dịch thuật AI [Co-op Translator](https://github.com/Azure/co-op-translator). Mặc dù chúng tôi cố gắng đảm bảo độ chính xác, xin lưu ý rằng các bản dịch tự động có thể chứa lỗi hoặc không chính xác. Tài liệu gốc bằng ngôn ngữ gốc của nó nên được coi là nguồn chính xác và đáng tin cậy. Đối với các thông tin quan trọng, nên sử dụng dịch vụ dịch thuật chuyên nghiệp do con người thực hiện. Chúng tôi không chịu trách nhiệm về bất kỳ sự hiểu lầm hoặc giải thích sai nào phát sinh từ việc sử dụng bản dịch này.