<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-16T23:07:31+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "hk"
}
-->
# MCP 安全最佳實踐

使用 MCP 伺服器時，請遵循以下安全最佳實踐，以保護您的數據、基礎設施和用戶：

1. **輸入驗證**：務必驗證並清理輸入，防止注入攻擊及混淆代理問題。
2. **存取控制**：為您的 MCP 伺服器實施適當的身份驗證和授權，並採用細粒度權限管理。
3. **安全通訊**：所有與 MCP 伺服器的通訊均使用 HTTPS/TLS，並考慮對敏感資料加強加密。
4. **速率限制**：實施速率限制以防止濫用、DoS 攻擊，並管理資源消耗。
5. **日誌與監控**：監控 MCP 伺服器的可疑活動，並建立完整的審計追蹤。
6. **安全儲存**：使用適當的靜態加密保護敏感資料和憑證。
7. **Token 管理**：透過驗證和清理所有模型輸入與輸出，防止 token 傳遞漏洞。
8. **會話管理**：實施安全的會話處理，防止會話劫持和固定攻擊。
9. **工具執行沙盒**：在隔離環境中執行工具，避免被攻破後的橫向移動。
10. **定期安全審核**：定期檢視 MCP 實作及其依賴項的安全性。
11. **提示驗證**：掃描並過濾輸入與輸出提示，防止提示注入攻擊。
12. **身份驗證委派**：使用成熟的身份提供者，避免自行實作身份驗證。
13. **權限範圍劃分**：依最小權限原則，為每個工具和資源設定細緻權限。
14. **資料最小化**：僅暴露每個操作所需的最少資料，降低風險面。
15. **自動化漏洞掃描**：定期掃描 MCP 伺服器及其依賴項的已知漏洞。

## MCP 安全最佳實踐的支援資源

### 輸入驗證
- [OWASP 輸入驗證速查表](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [防止 MCP 中的提示注入](https://modelcontextprotocol.io/docs/guides/security)
- [Azure 內容安全實作](./azure-content-safety-implementation.md)

### 存取控制
- [MCP 授權規範](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [在 MCP 伺服器中使用 Microsoft Entra ID](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API 管理作為 MCP 的身份驗證閘道](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### 安全通訊
- [傳輸層安全性 (TLS) 最佳實踐](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP 傳輸安全指引](https://modelcontextprotocol.io/docs/concepts/transports)
- [AI 工作負載的端對端加密](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### 速率限制
- [API 速率限制模式](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [實作令牌桶速率限制](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Azure API 管理中的速率限制](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### 日誌與監控
- [AI 系統的集中式日誌](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [審計日誌最佳實踐](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure 監控 AI 工作負載](https://learn.microsoft.com/azure/azure-monitor/overview)

### 安全儲存
- [Azure Key Vault 用於憑證儲存](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [靜態資料加密](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [使用安全的 Token 儲存並加密 Token](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Token 管理
- [JWT 最佳實踐 (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 安全最佳實踐 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Token 驗證與壽命管理最佳實踐](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### 會話管理
- [OWASP 會話管理速查表](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP 會話處理指引](https://modelcontextprotocol.io/docs/guides/security)
- [安全會話設計模式](https://learn.microsoft.com/security/engineering/session-security)

### 工具執行沙盒
- [容器安全最佳實踐](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [實作進程隔離](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [容器化應用的資源限制](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### 定期安全審核
- [Microsoft 安全開發生命週期](https://www.microsoft.com/sdl)
- [OWASP 應用安全驗證標準](https://owasp.org/www-project-application-security-verification-standard/)
- [安全程式碼審查指引](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### 提示驗證
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure AI 內容安全](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [防止提示注入](https://github.com/microsoft/prompt-shield-js)

### 身份驗證委派
- [Microsoft Entra ID 整合](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [MCP 服務的 OAuth 2.0](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP 安全控制 2025](./mcp-security-controls-2025.md)

### 權限範圍劃分
- [安全的最小權限存取](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [基於角色的存取控制 (RBAC) 設計](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [MCP 中的工具專屬授權](https://modelcontextprotocol.io/docs/guides/best-practices)

### 資料最小化
- [以設計保障資料保護](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI 資料隱私最佳實踐](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [實作隱私增強技術](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### 自動化漏洞掃描
- [GitHub 進階安全](https://github.com/security/advanced-security)
- [DevSecOps 管線實作](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [持續安全驗證](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**免責聲明**：  
本文件乃使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引致的任何誤解或誤釋承擔責任。