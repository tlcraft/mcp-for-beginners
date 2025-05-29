<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:05:16+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hk"
}
-->
# Security Best Practices

採用 Model Context Protocol (MCP) 為 AI 驅動的應用帶來強大功能，但同時亦帶來超越傳統軟件風險的獨特安全挑戰。除了既有的安全編碼、最小權限及供應鏈安全等問題外，MCP 及 AI 工作負載還面臨新威脅，例如 prompt injection、工具中毒及動態工具修改。如未妥善管理，這些風險可能導致數據外洩、私隱侵犯及系統行為異常。

本課程探討 MCP 相關最重要的安全風險，包括身份驗證、授權、過度權限、間接 prompt injection 及供應鏈漏洞，並提供可行的控制措施和最佳實踐以降低風險。你亦會學習如何利用 Microsoft 的解決方案，例如 Prompt Shields、Azure Content Safety 及 GitHub Advanced Security，來加強 MCP 的實施。透過了解及應用這些控制措施，可大幅降低安全事件發生的機會，確保 AI 系統穩健可靠。

# Learning Objectives

完成本課程後，你將能夠：

- 識別並解釋 Model Context Protocol (MCP) 帶來的獨特安全風險，包括 prompt injection、工具中毒、過度權限及供應鏈漏洞。
- 描述並應用有效的 MCP 安全風險緩解控制，例如強健的身份驗證、最小權限、安全的令牌管理及供應鏈驗證。
- 了解並善用 Microsoft 解決方案，如 Prompt Shields、Azure Content Safety 及 GitHub Advanced Security，保護 MCP 及 AI 工作負載。
- 認識驗證工具元數據、監察動態變更及防範間接 prompt injection 攻擊的重要性。
- 將既有的安全最佳實踐（如安全編碼、伺服器加固及零信任架構）整合到 MCP 實施中，以降低安全漏洞的可能性及影響。

# MCP security controls

任何能存取重要資源的系統均面臨安全挑戰。這些挑戰通常可透過正確應用基本安全控制及概念來解決。由於 MCP 仍屬新定義，規範快速演進，隨著協議發展，相關安全控制將逐漸成熟，令其能更好地與企業及既有安全架構和最佳實踐整合。

[Microsoft Digital Defense Report](https://aka.ms/mddr) 的研究指出，98% 的報告安全事件可透過強健的安全衛生措施預防，而抵禦各類攻擊的最佳保護，是做好基線安全衛生、安全編碼最佳實踐及供應鏈安全——這些已驗證有效的措施仍是減低安全風險的關鍵。

以下是你在採用 MCP 時可開始應對安全風險的一些方法。

> **Note:** 以下資訊截至 **2025 年 5 月 29 日** 為準。MCP 協議持續演進，未來版本可能引入新的身份驗證模式和控制措施。欲知最新更新及指引，請參考 [MCP Specification](https://spec.modelcontextprotocol.io/)、官方 [MCP GitHub repository](https://github.com/modelcontextprotocol) 及 [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)。

### Problem statement  
最初 MCP 規範假設開發者會自行編寫身份驗證伺服器，這需要 OAuth 及相關安全限制的知識。MCP 伺服器作為 OAuth 2.0 授權伺服器，直接管理所需的用戶身份驗證，而非委派給外部服務如 Microsoft Entra ID。自 **2025 年 4 月 26 日** 起，MCP 規範更新允許 MCP 伺服器將用戶身份驗證委派給外部服務。

### Risks
- MCP 伺服器授權邏輯配置錯誤，可能導致敏感資料外洩及錯誤的存取控制。
- 本地 MCP 伺服器的 OAuth 令牌被盜，攻擊者可利用該令牌冒充 MCP 伺服器，存取該 OAuth 令牌所對應服務的資源及數據。

#### Token Passthrough
授權規範明確禁止令牌直通，因其帶來多種安全風險，包括：

#### Security Control Circumvention
MCP 伺服器或下游 API 可能實施重要安全控制，例如速率限制、請求驗證或流量監控，這些依賴令牌受眾或其他憑證限制。如果客戶端能直接用令牌與下游 API 通訊，而 MCP 伺服器未能妥善驗證令牌或確保令牌發給正確服務，將繞過這些控制。

#### Accountability and Audit Trail Issues
當客戶端使用上游發出的存取令牌（對 MCP 伺服器可能不透明）呼叫時，MCP 伺服器無法辨別或區分不同 MCP 客戶端。  
下游資源伺服器的日誌可能顯示請求來自不同身份的來源，而非實際轉發令牌的 MCP 伺服器。  
這兩者均增加事件調查、控制及審計的困難。  
若 MCP 伺服器在轉發令牌時未驗證其聲明（例如角色、權限或受眾）或其他元數據，持有被盜令牌的惡意者可利用伺服器作為資料外洩的代理。

#### Trust Boundary Issues
下游資源伺服器對特定實體授予信任，該信任可能包含對來源或客戶端行為模式的假設。破壞此信任邊界可能導致意外問題。  
若令牌被多個服務接受且未經適當驗證，攻擊者若入侵其中一個服務，可利用該令牌存取其他相關服務。

#### Future Compatibility Risk
即使 MCP 伺服器目前是「純代理」，將來可能需新增安全控制。從一開始就正確分離令牌受眾，有助於安全模型的演進。

### Mitigating controls

**MCP 伺服器絕不可接受非明確發給該 MCP 伺服器的令牌**

- **審查及強化授權邏輯：** 仔細審核 MCP 伺服器的授權實作，確保只有預期的用戶和客戶端可存取敏感資源。實務指引可參考 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 及 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **強制安全令牌操作：** 遵循 [Microsoft 的令牌驗證及生命週期最佳實踐](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，防止令牌濫用，降低重放或竊取風險。
- **保護令牌儲存：** 始終安全儲存令牌，並對靜態及傳輸中資料進行加密。實作建議請參考 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# Excessive permissions for MCP servers

### Problem statement  
MCP 伺服器可能獲授過度權限存取服務/資源。例如，一個屬於 AI 銷售應用的 MCP 伺服器連接企業資料庫，應僅限於銷售數據的存取，而不應能訪問資料庫中所有檔案。回到最小權限原則（最古老的安全原則之一），任何資源都不應擁有超出執行其指定任務所需的權限。AI 在此方面帶來挑戰，因為為了保持彈性，準確定義所需權限變得困難。

### Risks  
- 過度授權可能導致資料外洩或未經授權修改 MCP 伺服器本不應存取的資料。如資料包含個人身份資訊（PII），亦構成私隱風險。

### Mitigating controls
- **落實最小權限原則：** 只授予 MCP 伺服器執行所需任務的最低權限。定期檢視及更新權限，確保不超出必要範圍。詳見 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **使用基於角色的存取控制 (RBAC)：** 為 MCP 伺服器指派嚴格限定特定資源及操作的角色，避免過寬或不必要權限。
- **監控及審計權限：** 持續監察權限使用情況，審計存取日誌，及時發現並修正過度或未使用的權限。

# Indirect prompt injection attacks

### Problem statement

惡意或被入侵的 MCP 伺服器可能帶來重大風險，包括洩露客戶資料或觸發未預期行為。此類風險在 AI 及 MCP 工作負載中特別重要，例如：

- **Prompt Injection Attacks**：攻擊者在提示詞或外部內容中植入惡意指令，令 AI 系統執行未預期動作或洩露敏感資料。詳見：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**：攻擊者操控工具元數據（如描述或參數），影響 AI 行為，可能繞過安全控制或外洩資料。詳情：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**：惡意指令藏於文件、網頁或電郵中，AI 處理時導致資料外洩或操控。
- **Dynamic Tool Modification (Rug Pulls)**：工具定義在用戶批准後被更改，引入新的惡意行為而用戶不自知。

這些漏洞凸顯在整合 MCP 伺服器及工具時，需強化驗證、監控及安全控制。詳情請參考以上連結。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hk.png)

**Indirect Prompt Injection**（又稱跨域 prompt injection 或 XPIA）是生成式 AI 系統中的關鍵漏洞，包括使用 MCP 的系統。此攻擊將惡意指令藏於外部內容（如文件、網頁或電郵）中，當 AI 處理該內容時，可能將這些指令誤認為合法用戶命令，導致資料洩漏、有害內容生成或用戶互動被操控。詳見 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/) 了解詳細說明及實例。

其中一種特別危險的攻擊是 **Tool Poisoning**。攻擊者將惡意指令注入 MCP 工具的元數據（例如工具描述或參數）。由於大型語言模型（LLMs）依賴這些元數據決定調用哪些工具，遭篡改的描述可誤導模型執行未授權的工具呼叫或繞過安全控制。此類操作通常對最終用戶不可見，但 AI 系統會解讀並執行。此風險在託管 MCP 伺服器環境尤為嚴重，因為工具定義可在用戶批准後被更改，俗稱「[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)」。在此情況下，先前安全的工具後來可能被修改以執行惡意行為，如資料外洩或系統行為改變，且用戶不知情。更多資訊請參考 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.hk.png)

## Risks  
AI 的未預期行為帶來多種安全風險，包括資料外洩及私隱侵犯。

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** 是 Microsoft 開發的解決方案，用以防範直接及間接 prompt injection 攻擊。其功能包括：

1.  **偵測與過濾**：利用先進的機器學習演算法及自然語言處理技術，偵測並過濾外部內容（如文件、網頁或電郵）中嵌入的惡意指令。
    
2.  **聚焦技術 (Spotlighting)**：幫助 AI 系統分辨有效的系統指令與潛在不可信的外部輸入。透過改變輸入文本，使其更貼近模型需求，提升 AI 對惡意指令的識別與忽略能力。
    
3.  **分隔符與數據標記 (Delimiters and Datamarking)**：在系統訊息中加入分隔符，明確指出輸入文本位置，協助 AI 辨識並區分用戶輸入與潛在有害的外部內容。數據標記更進一步利用特殊標記標示可信與不可信資料邊界。
    
4.  **持續監控與更新**：Microsoft 持續監控並更新 Prompt Shields，針對新興及演化的威脅採取主動防禦，確保防護效果。
    
5.  **整合 Azure Content Safety**：Prompt Shields 是 Azure AI Content Safety 套件的一部分，提供額外工具偵測越獄嘗試、有害內容及其他 AI 安全風險。

詳情可參閱 [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.hk.png)

### Supply chain security

供應鏈安全在 AI 時代依然至關重要，但供應鏈範圍已擴大。除了傳統的程式碼套件外，現須嚴格驗證及監控所有 AI 相關組件，包括基礎模型、嵌入服務、上下文提供者及第三方 API。若管理不當，這些均可能引入漏洞或風險。

**AI 及 MCP 的主要供應鏈安全實踐：**  
- **整合前驗證所有組件：** 不只開源庫，還包括 AI 模型、資料來源及外部 API。務必檢查來源、授權及已知漏洞。  
- **維護安全部署流程：** 採用自動化 CI/CD 流程並整合安全掃描，及早發現問題。確保僅可信工件部署至生產環境。  
- **持續監控及審計：** 對所有依賴項（模型及資料服務）實施持續監控，及時偵測新漏洞或供應鏈攻擊。  
- **落實最小權限及存取控制：** 限制模型、資料及服務的存取權限，只允許 MCP 伺服器正常運作所需。  
- **快速應對威脅：** 建立流程，及時修補或替換受損組件，並在發生安全事件時旋轉密鑰或憑證。

[GitHub Advanced Security](https://github.com/security/advanced-security) 提供秘密掃描、依賴掃描及 CodeQL 分析等功能，並可與 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 及 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 整合，協助團隊識別及緩解程式碼及 AI 供應鏈組件中的漏洞。

Microsoft 亦在內部對所有產品實施全面的供應鏈安全實踐。詳見 [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。

# Established security best practices that will uplift your MCP implementation's security posture

任何 MCP 實施均繼承其所建構的組織環境的既有安全狀態，因此在評估 MCP 作為整體 AI 系統一部分的安全時，建議提升整體既有安全態勢。以下既有安全控制尤為相關：

- 在 AI 應用中實施安全編碼最佳實踐——防範 [OWASP Top 10](https://owasp.org/www-project-top-ten/)、[OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 下一步

下一步: [第3章：入門指南](/03-GettingStarted/README.md)

**免責聲明**：  
本文件係用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯。雖然我哋致力保持準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。本公司對因使用此翻譯而引致嘅任何誤解或誤譯概不負責。