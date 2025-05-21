<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T22:55:23+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hk"
}
-->
# Security Best Practices

採用 Model Context Protocol (MCP) 為 AI 驅動的應用帶來強大功能，但同時亦引入了超越傳統軟件風險的獨特安全挑戰。除了已知的安全編碼、最小權限及供應鏈安全等問題外，MCP 及 AI 工作負載還面對如 prompt 注入、工具中毒及動態工具修改等新威脅。如果管理不善，這些風險可能導致資料外洩、私隱侵犯及系統行為異常。

本課程探討 MCP 相關的主要安全風險，包括身份驗證、授權、過度權限、間接 prompt 注入及供應鏈漏洞，並提供具體的控制措施及最佳實踐來減輕風險。你亦會學習如何利用 Microsoft 的解決方案，如 Prompt Shields、Azure Content Safety 及 GitHub Advanced Security，來加強 MCP 的部署。透過理解及應用這些控制措施，你可以大幅降低安全漏洞的機會，確保 AI 系統的穩健及可信。

# Learning Objectives

完成本課程後，你將能夠：

- 識別及解釋 Model Context Protocol (MCP) 帶來的獨特安全風險，包括 prompt 注入、工具中毒、過度權限及供應鏈漏洞。
- 描述及應用有效的 MCP 安全風險緩解控制措施，如強健的身份驗證、最小權限、安全的令牌管理及供應鏈驗證。
- 了解及運用 Microsoft 的解決方案，例如 Prompt Shields、Azure Content Safety 及 GitHub Advanced Security，保護 MCP 及 AI 工作負載。
- 認識驗證工具元數據、監察動態變更及防禦間接 prompt 注入攻擊的重要性。
- 將已建立的安全最佳實踐，如安全編碼、伺服器加固及零信任架構，整合到 MCP 部署中，以減少安全漏洞的機會及影響。

# MCP security controls

任何可存取重要資源的系統都存在隱含的安全挑戰。這些挑戰一般可透過正確應用基本的安全控制及概念來解決。由於 MCP 是新近定義的協議，其規範正快速變化及演進。隨著協議成熟，內建的安全控制亦會逐步完善，從而更好地整合企業及既有的安全架構與最佳實踐。

[Microsoft Digital Defense Report](https://aka.ms/mddr) 的研究指出，98% 的已報告入侵事件可透過強健的安全衛生措施防止，而對任何入侵最有效的保護，就是做好基線的安全衛生、正確的安全編碼最佳實踐及供應鏈安全——這些經過驗證的措施依然是減少安全風險的關鍵。

以下是你在採用 MCP 時可開始應對安全風險的一些方法。

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** 以下資訊截至 2025 年 4 月 26 日為準。MCP 協議持續演進，未來實作可能會引入新的身份驗證模式及控制。請隨時參考 [MCP Specification](https://spec.modelcontextprotocol.io/) 及官方 [MCP GitHub repository](https://github.com/modelcontextprotocol) 以獲取最新指引。

### Problem statement  
最初的 MCP 規範假設開發者會自行撰寫身份驗證伺服器，這需要具備 OAuth 及相關安全限制的知識。MCP 伺服器充當 OAuth 2.0 授權伺服器，直接管理用戶身份驗證，而非委派給外部服務如 Microsoft Entra ID。自 2025 年 4 月 26 日起，MCP 規範更新允許 MCP 伺服器將用戶身份驗證委派給外部服務。

### Risks
- MCP 伺服器中錯誤配置的授權邏輯可能導致敏感資料外洩及存取控制錯誤。
- 本地 MCP 伺服器的 OAuth 令牌被盜。若被盜用，該令牌可用於冒充 MCP 伺服器，存取令牌所授權的服務及資料。

### Mitigating controls
- **檢查及加固授權邏輯：** 仔細審核 MCP 伺服器的授權實作，確保只有授權用戶及客戶端可存取敏感資源。實用指引見 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 及 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **強制安全令牌管理：** 遵循 [Microsoft 的令牌驗證及有效期限最佳實踐](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，防止令牌濫用及減低重放或竊取風險。
- **保護令牌儲存：** 始終安全儲存令牌，並使用加密保護靜態及傳輸中的令牌。實作技巧參考 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# Excessive permissions for MCP servers

### Problem statement  
MCP 伺服器可能被授予過多權限，超出其應用範圍。例如，一個用於 AI 銷售應用的 MCP 伺服器連接企業數據庫，應只限於存取銷售數據，而不應能存取數據庫內所有檔案。根據最小權限原則（最古老的安全原則之一），任何資源的權限都不應超出其執行任務所需。AI 令這方面更具挑戰性，因為為了保持彈性，準確界定所需權限較為困難。

### Risks  
- 過度授權可能導致未經授權的資料外洩或更改。若涉及個人識別信息 (PII)，亦會帶來私隱問題。

### Mitigating controls
- **應用最小權限原則：** 只授予 MCP 伺服器執行所需任務的最低權限，並定期檢視及更新權限，確保不超出必要範圍。詳情見 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **使用角色基礎存取控制 (RBAC)：** 將嚴格限定於特定資源及操作的角色分配給 MCP 伺服器，避免廣泛或不必要的權限。
- **監察及審核權限：** 持續監察權限使用情況及審核存取日誌，及早發現並修正過度或未使用的權限。

# Indirect prompt injection attacks

### Problem statement

惡意或被入侵的 MCP 伺服器可能帶來重大風險，導致客戶資料暴露或觸發未預期行為。這些風險在 AI 及 MCP 工作負載中尤為重要，包括：

- **Prompt Injection Attacks**：攻擊者在 prompt 或外部內容中嵌入惡意指令，令 AI 系統執行未預期動作或洩露敏感資料。詳見：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**：攻擊者操控工具元數據（如描述或參數），影響 AI 行為，可能繞過安全控制或外洩資料。詳情：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**：惡意指令藏於文件、網頁或電郵中，由 AI 處理時導致資料洩漏或操控。
- **Dynamic Tool Modification (Rug Pulls)**：用戶批准後，工具定義被更改，引入新惡意行為而用戶不知情。

這些漏洞凸顯了在整合 MCP 伺服器及工具時，必須有強健的驗證、監控及安全控制。詳情可參考上述連結。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hk.png)

**間接 Prompt 注入**（又稱跨域 prompt 注入或 XPIA）是生成式 AI 系統中的嚴重漏洞，包括使用 MCP 的系統。攻擊中，惡意指令藏於外部內容，如文件、網頁或電郵。當 AI 處理這些內容時，可能將嵌入指令誤解為合法用戶命令，導致資料洩漏、產生有害內容或操控用戶互動。詳情及實例見 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)。

一種特別危險的攻擊是 **Tool Poisoning**。攻擊者將惡意指令注入 MCP 工具的元數據（如工具描述或參數），由於大型語言模型 (LLM) 依賴這些元數據決定調用哪些工具，遭破壞的描述可誤導模型執行未授權的工具呼叫或繞過安全控制。這些操控通常用戶看不見，但 AI 系統會解讀並執行。此風險在託管 MCP 伺服器環境中尤為嚴重，因工具定義可在用戶批准後更新，稱為「[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)」。原本安全的工具可能被修改成執行惡意行為，如資料外洩或系統行為變更，且用戶不知情。更多資料見 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.hk.png)

## Risks
AI 執行未預期動作帶來多種安全風險，包括資料外洩及私隱侵犯。

### Mitigating controls
### 使用 Prompt Shields 防禦間接 Prompt 注入攻擊
-----------------------------------------------------------------------------

**AI Prompt Shields** 是 Microsoft 開發的解決方案，用於防禦直接及間接的 prompt 注入攻擊。其功能包括：

1.  **偵測及過濾**：Prompt Shields 利用先進的機器學習演算法及自然語言處理技術，偵測並過濾外部內容（如文件、網頁或電郵）中嵌入的惡意指令。
    
2.  **聚焦（Spotlighting）**：協助 AI 系統區分有效的系統指令與可能不可信的外部輸入。透過改寫輸入文字，使其更貼合模型需求，令 AI 更易識別及忽略惡意指令。
    
3.  **分隔符及數據標記（Delimiters and Datamarking）**：在系統訊息中加入分隔符，明確標示輸入文字位置，幫助 AI 區分用戶輸入與潛在有害的外部內容。數據標記則利用特殊標記，突出可信與不可信數據的邊界。
    
4.  **持續監控及更新**：Microsoft 持續監控及更新 Prompt Shields，以應對新興及演變中的威脅，確保防禦措施保持有效。
    
5. **與 Azure Content Safety 整合：** Prompt Shields 是 Azure AI Content Safety 套件的一部分，提供額外工具偵測越獄嘗試、有害內容及其他 AI 安全風險。

更多關於 AI Prompt Shields 的資料，請參閱 [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.hk.png)

### Supply chain security

供應鏈安全在 AI 時代依然是基礎，但供應鏈的範圍已擴大。除了傳統的程式碼套件外，還需嚴格驗證及監控所有 AI 相關元件，包括基礎模型、嵌入服務、上下文提供者及第三方 API。任何一環管理不善均可能引入漏洞或風險。

**AI 及 MCP 的主要供應鏈安全實踐：**
- **整合前驗證所有元件：** 不只開源庫，還包括 AI 模型、資料來源及外部 API。必須核查來源、授權及已知漏洞。
- **維護安全部署流程：** 使用自動化 CI/CD 流水線並整合安全掃描，及早發現問題。確保只部署可信工件到生產環境。
- **持續監控及審核：** 對所有依賴項（包括模型及數據服務）進行持續監控，以偵測新漏洞或供應鏈攻擊。
- **應用最小權限及存取控制：** 限制模型、數據及服務的存取，只限 MCP 伺服器正常運作所需。
- **迅速回應威脅：** 建立流程修補或替換受損元件，及在發現入侵時旋轉密鑰或憑證。

[GitHub Advanced Security](https://github.com/security/advanced-security) 提供秘密掃描、依賴掃描及 CodeQL 分析等功能。這些工具可與 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 及 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 整合，協助團隊識別及緩解程式碼及 AI 供應鏈元件的漏洞。

Microsoft 亦在內部對所有產品實施廣泛的供應鏈安全措施。詳情見 [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。

# Established security best practices that will uplift your MCP implementation's security posture

任何 MCP 部署都繼承其所建構組織環境的既有安全狀態，因此在考慮 MCP 作為整體 AI 系統的一部分時，建議提升整體既有安全態勢。以下既有安全控制特別重要：

- AI 應用中的安全編碼最佳實踐 — 防範 [OWASP Top 10](https://owasp.org/www-project-top-ten/)、[OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)、使用安全金庫存放秘密及令牌、實現應用組件間端對端安全通訊等。
- 伺服器加固 — 儘可能使用多重身份驗證 (MFA)、保持補丁更新、整合第三方身份提供者控制存取等。
- 保持裝置、基礎設施及應用程式的補丁更新。
- 安全監控 — 實施 AI 應用（包括 MCP 客戶端／伺服器）的日誌記錄及監控，並將日誌發送至集中 SIEM 以偵測異常行為。
- 零信任架構 — 透過網絡及身份控制邏輯隔離組件，減少 AI 應用被入侵後的橫向移動風險。

# Key Takeaways

- 安全基礎仍然至關重要：安全編碼、最小權限、供應鏈驗證及持續監控是 MCP 及 AI 工作負載的關鍵。
- MCP 帶來新風險，如 prompt 注入、工具中毒及過度權限，需要傳統及 AI 專屬的控制措施。
- 採用強健的身份驗證、授權及令牌管理，並盡可能利用外部身份提供者如 Microsoft Entra ID。
- 通過驗證工具元數據、監控動態變更及使用 Microsoft Prompt Shields 防範間接 prompt 注入及工具中毒。
- 對 AI 供應鏈中的所有元件，包括模型、嵌入及上下文提供者，採取與程式碼依賴同等嚴謹的管理。
- 持續關注 MCP 規範演進，並積極參與社群，共同塑造安全標準。

# Additional Resources

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)

- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 下一步

下一步: [Chapter 3: Getting Started](/03-GettingStarted/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資料，建議採用專業人工翻譯。本公司概不負責因使用本翻譯而引致嘅任何誤解或誤釋。