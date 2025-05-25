<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T22:56:00+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "tw"
}
-->
# Security Best Practices

採用 Model Context Protocol (MCP) 為 AI 驅動的應用程式帶來強大新功能，但也引入了超越傳統軟體風險的獨特安全挑戰。除了既有的安全程式設計、最小權限及供應鏈安全等議題外，MCP 和 AI 工作負載還面臨新的威脅，例如提示注入、工具中毒和動態工具修改。若管理不當，這些風險可能導致資料外洩、隱私侵犯及系統異常行為。

本課程探討與 MCP 相關的主要安全風險，包括身份驗證、授權、過度權限、間接提示注入及供應鏈弱點，並提供可行的控管措施與最佳實務。你也將學習如何運用 Microsoft 解決方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security，來強化 MCP 的實作。透過了解並應用這些控管，能大幅降低安全事件發生的機率，確保 AI 系統穩健且值得信賴。

# Learning Objectives

完成本課程後，你將能：

- 辨識並說明 Model Context Protocol (MCP) 帶來的獨特安全風險，包括提示注入、工具中毒、過度權限及供應鏈弱點。
- 描述並運用有效的控管措施來減輕 MCP 的安全風險，如強健的身份驗證、最小權限、安全的 Token 管理及供應鏈驗證。
- 了解並利用 Microsoft 解決方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security，保護 MCP 和 AI 工作負載。
- 認識驗證工具元資料、監控動態變更，以及防範間接提示注入攻擊的重要性。
- 將既有的安全最佳實務——例如安全程式設計、伺服器強化及零信任架構——整合進 MCP 實作，降低安全事件的發生及影響。

# MCP security controls

任何能存取重要資源的系統，都面臨內在的安全挑戰。這些挑戰通常可透過正確應用基本安全控管與概念來解決。由於 MCP 是新定義的協議，規範仍在快速變動與演進中。未來其安全控管將逐漸成熟，能更好地整合企業既有的安全架構與最佳實務。

根據[Microsoft Digital Defense Report](https://aka.ms/mddr)的研究，98% 的通報資安事件都能透過健全的安全衛生措施防範；而任何類型的資安防護中，最有效的就是落實基本的安全衛生、確實的安全程式設計及供應鏈安全——這些經過驗證的做法仍是降低風險的關鍵。

讓我們來看看採用 MCP 時，可以如何開始應對安全風險。

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** 以下資訊截至 2025 年 4 月 26 日為止是正確的。MCP 協議持續演進，未來實作可能會引入新的身份驗證模式與控管。最新更新與指引，請務必參考 [MCP Specification](https://spec.modelcontextprotocol.io/) 與官方 [MCP GitHub repository](https://github.com/modelcontextprotocol)。

### 問題說明  
原始 MCP 規範假設開發者會自行撰寫身份驗證伺服器，這需要具備 OAuth 及相關安全限制的知識。MCP 伺服器扮演 OAuth 2.0 授權伺服器角色，直接管理使用者身份驗證，而非委派給像 Microsoft Entra ID 這類外部服務。至 2025 年 4 月 26 日，MCP 規範更新允許 MCP 伺服器將使用者身份驗證委派給外部服務。

### 風險
- MCP 伺服器授權邏輯錯誤配置，可能導致敏感資料外洩或存取控管錯誤。
- 本地 MCP 伺服器的 OAuth Token 被竊取，攻擊者可藉此冒充 MCP 伺服器，存取該 Token 代表的服務與資料。

### 減緩控管
- **審查並強化授權邏輯：** 仔細審核 MCP 伺服器的授權實作，確保只有預期的使用者與客戶端能存取敏感資源。實務指引請參考 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 與 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **執行安全的 Token 管理：** 遵循 [Microsoft 的 Token 驗證與有效期限最佳實務](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，避免存取 Token 被濫用或重放攻擊。
- **保護 Token 儲存：** 始終安全儲存 Token，並使用加密保護靜態與傳輸中的 Token。實作技巧可參考 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# Excessive permissions for MCP servers

### 問題說明  
MCP 伺服器可能被授予超出所需的服務或資源權限。例如，作為 AI 銷售應用一部分的 MCP 伺服器，連接企業資料庫時應僅能存取銷售資料，不能瀏覽資料庫所有檔案。回歸最小權限原則（最老牌的安全原則之一），任何資源都不應有超出執行任務所需的權限。AI 在這方面的挑戰更大，因為為了讓系統靈活運作，很難精準定義所需權限。

### 風險  
- 授予過多權限可能導致資料外洩或未經授權修改 MCP 伺服器本不該接觸的資料，若為個人識別資訊 (PII)，也可能引發隱私問題。

### 減緩控管
- **落實最小權限原則：** 僅授予 MCP 伺服器執行任務所需的最低權限，並定期檢視與更新，確保權限不超出需求。詳細指引請見 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **採用角色型存取控制 (RBAC)：** 為 MCP 伺服器指派緊密範圍限定的角色，避免授權過廣或不必要的權限。
- **監控與稽核權限：** 持續監控權限使用狀況並稽核存取紀錄，及早發現並修正過度或未使用的權限。

# Indirect prompt injection attacks

### 問題說明

惡意或遭入侵的 MCP 伺服器可能造成重大風險，包括洩露客戶資料或觸發未預期的行為。這些風險在 AI 與基於 MCP 的工作負載中特別重要，包括：

- **提示注入攻擊 (Prompt Injection Attacks)：** 攻擊者在提示或外部內容中嵌入惡意指令，讓 AI 系統執行未預期的行動或洩露敏感資料。詳見：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **工具中毒 (Tool Poisoning)：** 攻擊者操控工具元資料（如描述或參數），影響 AI 行為，可能繞過安全控管或竊取資料。詳情：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **跨域提示注入 (Cross-Domain Prompt Injection)：** 惡意指令藏於文件、網頁或電子郵件中，AI 處理時導致資料外洩或操作異常。
- **動態工具修改 (Rug Pulls)：** 工具定義可在使用者同意後被修改，加入新的惡意行為，使用者不知情。

這些弱點凸顯整合 MCP 伺服器與工具時，必須嚴格驗證、監控及採取安全控管。詳細內容請參考上述連結。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.tw.png)

**間接提示注入**（又稱跨域提示注入或 XPIA）是生成式 AI 系統（包括使用 MCP 的系統）中的關鍵漏洞。此攻擊手法將惡意指令隱藏於外部內容，如文件、網頁或電子郵件中。當 AI 系統處理這些內容時，可能將隱藏指令當作合法使用者命令，導致資料外洩、生成有害內容或干擾使用者互動。詳盡說明及實例請見 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)。

一種特別危險的形式是 **工具中毒**。攻擊者在 MCP 工具的元資料（如工具描述或參數）中注入惡意指令。由於大型語言模型（LLM）依賴這些元資料判斷要呼叫哪些工具，遭破壞的描述可能誤導模型執行未授權的工具呼叫或繞過安全控管。這種操控通常對終端使用者不可見，但 AI 系統會解讀並執行。此風險在託管 MCP 伺服器環境尤為嚴重，因工具定義可在用戶同意後更新，稱為「[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)」。原本安全的工具可能被改為執行惡意行為，如資料外洩或系統異動，使用者不察。更多攻擊資訊請見 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.tw.png)

## 風險
AI 的非預期行為帶來各種安全風險，包括資料外洩及隱私侵犯。

### 減緩控管
### 使用 Prompt Shields 防範間接提示注入攻擊
-----------------------------------------------------------------------------

**AI Prompt Shields** 是 Microsoft 開發的解決方案，能防禦直接與間接的提示注入攻擊。其功能包括：

1.  **偵測與過濾：** 利用先進的機器學習演算法與自然語言處理，偵測並過濾外部內容（如文件、網頁、電子郵件）中嵌入的惡意指令。
    
2.  **聚焦技術 (Spotlighting)：** 協助 AI 系統區分有效系統指令與可能不可信的外部輸入。透過將輸入文字轉換為對模型更相關的形式，讓 AI 更能識別並忽略惡意指令。
    
3.  **分隔符與資料標記 (Delimiters and Datamarking)：** 在系統訊息中加入分隔符，明確標示輸入文字位置，幫助 AI 系統辨識並分離使用者輸入與可能有害的外部內容。資料標記則使用特殊標記，突出可信與不可信資料的界線。
    
4.  **持續監控與更新：** Microsoft 持續監控並更新 Prompt Shields，以應對新興及演變的威脅。此積極策略確保防禦措施對最新攻擊手法依然有效。
    
5. **與 Azure Content Safety 整合：** Prompt Shields 是 Azure AI Content Safety 套件的一部分，提供額外工具偵測越獄嘗試、有害內容及其他 AI 安全風險。

你可以在[Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)中閱讀更多關於 AI Prompt Shields 的資訊。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.tw.png)

### Supply chain security

供應鏈安全在 AI 時代依然是基礎，但供應鏈的範圍已擴大。除了傳統的程式碼套件，現在必須嚴格驗證與監控所有 AI 相關元件，包括基礎模型、嵌入服務、上下文提供者與第三方 API。若管理不善，這些都可能帶來弱點或風險。

**AI 與 MCP 供應鏈安全的關鍵做法：**
- **整合前驗證所有元件：** 不只開源函式庫，也包含 AI 模型、資料來源與外部 API。務必檢查來源、授權與已知漏洞。
- **維護安全的部署流程：** 使用整合安全掃描的自動化 CI/CD 流程，及早發現問題。確保只部署受信任的產物到生產環境。
- **持續監控與稽核：** 對所有依賴元件（包括模型與資料服務）實施持續監控，偵測新漏洞或供應鏈攻擊。
- **落實最小權限與存取控管：** 限制模型、資料與服務的存取，僅給 MCP 伺服器執行所需。
- **快速回應威脅：** 建立機制，於發現遭入侵元件時迅速修補或替換，並在必要時輪替密鑰或憑證。

[GitHub Advanced Security](https://github.com/security/advanced-security) 提供秘密掃描、依賴掃描與 CodeQL 分析等功能，並可與 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 及 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 整合，協助團隊識別並減輕程式碼與 AI 供應鏈元件的漏洞。

Microsoft 也在內部對所有產品實施嚴格的供應鏈安全措施。詳情請見 [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。

# Established security best practices that will uplift your MCP implementation's security posture

任何 MCP 實作都繼承了所建構組織環境的既有安全態勢，因此在考量 MCP 安全時，建議同時提升整體既有安全態勢。以下既有的安全控管尤其重要：

- AI 應用的安全程式設計最佳實務——防範[OWASP Top 10](https://owasp.org/www-project-top-ten/)、[LLM 專屬 OWASP Top 10](https://genai.owasp.org/download/43299/?tmstv=1731900559)、使用安全金庫管理秘密與 Token、實作應用元件間的端對端安全通訊等。
- 伺服器強化——盡可能啟用多因素驗證 (MFA)、持續更新修補程式、整合第三方身份提供者以控管存取等。
- 持續更新裝置、基礎設施與應用程式的修補程式。
- 安全監控——實施 AI 應用（含 MCP 用戶端/伺服器）的日誌與監控，並將日誌送至中央 SIEM 以偵測異常行為。
- 零信任架構——透過網路與身份控管將元件邏輯隔離，降低 AI 應用遭入侵時的橫向移動風險。

# Key Takeaways

- 基本安全仍然關鍵：安全程式設計、最小權限、供應鏈驗證與持續監控對 MCP 和 AI 工作負載不可或缺。
- MCP 帶來新風險——如提示注入、工具中毒及過度權限——需要傳統與 AI 專屬的控管。
- 採用強健的身份驗證、授權與 Token 管理，盡可能利用外部身份提供者如 Microsoft Entra ID。
- 透過驗證工具元資料、監控動態變更及使用 Microsoft Prompt Shields，防範間接提示注入與工具中毒。
- 對 AI 供應鏈中所有元件（包含模型、嵌入與上下文提供者）採取與程式碼依賴相同的嚴謹態度。
- 持續關注 MCP 規範的演進，並參與社群，協助打造安全標準。

# Additional Resources

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [
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
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於提供準確的翻譯，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生之任何誤解或誤釋負責。