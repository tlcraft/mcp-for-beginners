<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-13T16:38:23+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "tw"
}
-->
# 安全最佳實務

採用 Model Context Protocol (MCP) 為 AI 驅動的應用程式帶來強大的新功能，但同時也引入了超越傳統軟體風險的獨特安全挑戰。除了既有的安全編碼、最小權限和供應鏈安全等問題外，MCP 和 AI 工作負載還面臨新的威脅，例如提示注入、工具中毒和動態工具修改。如果未妥善管理，這些風險可能導致資料外洩、隱私侵犯及系統行為異常。

本課程探討與 MCP 相關的最重要安全風險，包括身份驗證、授權、過度權限、間接提示注入及供應鏈漏洞，並提供可行的控管措施與最佳實務來降低風險。您還將學習如何利用 Microsoft 解決方案，如 Prompt Shields、Azure Content Safety 及 GitHub Advanced Security，來強化 MCP 的實作。透過理解並應用這些控管措施，您可以大幅降低安全事件發生的可能性，確保 AI 系統的穩健與可信賴。

# 學習目標

完成本課程後，您將能夠：

- 辨識並說明 Model Context Protocol (MCP) 所帶來的獨特安全風險，包括提示注入、工具中毒、過度權限及供應鏈漏洞。
- 描述並應用有效的 MCP 安全風險緩解控管，如強健的身份驗證、最小權限、安全的令牌管理及供應鏈驗證。
- 了解並運用 Microsoft 解決方案，如 Prompt Shields、Azure Content Safety 及 GitHub Advanced Security，來保護 MCP 與 AI 工作負載。
- 認識驗證工具元資料、監控動態變更及防禦間接提示注入攻擊的重要性。
- 將既有的安全最佳實務（如安全編碼、伺服器強化及零信任架構）整合到 MCP 實作中，以降低安全事件的發生率及影響。

# MCP 安全控管

任何能存取重要資源的系統都存在隱含的安全挑戰。這些挑戰通常可透過正確應用基本安全控管與概念來解決。由於 MCP 是新定義的協議，規範仍在快速變動與演進中。隨著協議成熟，內建的安全控管將更完善，能更好地與企業及既有安全架構和最佳實務整合。

根據[Microsoft Digital Defense Report](https://aka.ms/mddr)的研究，98% 的已報告資安事件可透過強健的安全衛生措施防範。對任何類型的資安事件而言，最好的防護是確保基礎的安全衛生、良好的安全編碼實務及供應鏈安全——這些經過驗證的做法仍是降低安全風險的關鍵。

以下將介紹採用 MCP 時可開始著手解決安全風險的方法。

> **Note:** 以下資訊截至 **2025 年 5 月 29 日** 為止正確。MCP 協議持續演進，未來實作可能引入新的身份驗證模式與控管。最新更新與指引請參考 [MCP 規範](https://spec.modelcontextprotocol.io/)、官方 [MCP GitHub 倉庫](https://github.com/modelcontextprotocol) 及 [安全最佳實務頁面](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)。

### 問題說明  
原始 MCP 規範假設開發者會自行撰寫身份驗證伺服器，這需要 OAuth 及相關安全限制的知識。MCP 伺服器作為 OAuth 2.0 授權伺服器，直接管理所需的使用者身份驗證，而非委派給外部服務（如 Microsoft Entra ID）。自 **2025 年 4 月 26 日** 起，MCP 規範更新允許 MCP 伺服器將使用者身份驗證委派給外部服務。

### 風險
- MCP 伺服器中授權邏輯配置錯誤，可能導致敏感資料外洩及存取控制錯誤。
- 本地 MCP 伺服器的 OAuth 令牌被竊取。若令牌遭竊，攻擊者可冒充 MCP 伺服器，存取該 OAuth 令牌所對應服務的資源與資料。

#### 令牌直通
授權規範明確禁止令牌直通，因其帶來多項安全風險，包括：

#### 安全控管繞過
MCP 伺服器或下游 API 可能實施重要安全控管，如速率限制、請求驗證或流量監控，這些控管依賴令牌的受眾或其他憑證限制。若客戶端能直接取得並使用令牌與下游 API 互動，而 MCP 伺服器未妥善驗證令牌或確保令牌是為正確服務發行，將繞過這些控管。

#### 責任追蹤與稽核問題
當客戶端使用上游發行的存取令牌呼叫時，MCP 伺服器無法辨識或區分不同 MCP 客戶端。  
下游資源伺服器的日誌可能顯示請求來自不同來源與身份，而非實際轉發令牌的 MCP 伺服器。  
這兩者都使事件調查、控管與稽核更加困難。  
若 MCP 伺服器在轉發令牌時未驗證其聲明（如角色、權限或受眾）或其他元資料，持有被竊令牌的惡意者可利用該伺服器作為資料外洩的代理。

#### 信任邊界問題
下游資源伺服器對特定實體授予信任，該信任可能包含對來源或客戶端行為模式的假設。破壞此信任邊界可能導致意外問題。  
若令牌被多個服務接受且未經適當驗證，攻擊者若入侵其中一個服務，便可利用該令牌存取其他連接服務。

#### 未來相容性風險
即使 MCP 伺服器目前是「純代理」，未來可能需要新增安全控管。從一開始就正確區分令牌受眾，有助於安全模型的演進。

### 緩解控管

**MCP 伺服器不得接受非明確為該 MCP 伺服器發行的任何令牌**

- **審查並強化授權邏輯：** 仔細稽核 MCP 伺服器的授權實作，確保只有預期的使用者與客戶端能存取敏感資源。實務指引請參考 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 及 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **強制安全令牌使用規範：** 遵循 [Microsoft 的令牌驗證與有效期限最佳實務](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，防止存取令牌濫用，降低令牌重放或竊取風險。
- **保護令牌儲存：** 始終安全儲存令牌，並使用加密保護靜態與傳輸中的令牌。實作技巧請參考 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# MCP 伺服器的過度權限

### 問題說明  
MCP 伺服器可能被授予過度的服務或資源權限。例如，作為 AI 銷售應用一部分的 MCP 伺服器，連接企業資料庫時，應僅限於存取銷售資料，而非整個資料庫的所有檔案。回歸最小權限原則（最古老的安全原則之一），任何資源都不應擁有超出其執行任務所需的權限。AI 在此領域帶來更大挑戰，因為為了靈活性，準確定義所需權限可能相當困難。

### 風險  
- 授予過度權限可能導致 MCP 伺服器外洩或修改其不應存取的資料。若資料包含個人識別資訊（PII），也可能引發隱私問題。

### 緩解控管  
- **應用最小權限原則：** 僅授予 MCP 伺服器執行任務所需的最低權限。定期檢視並更新權限，確保不超出必要範圍。詳細指引請參考 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **使用基於角色的存取控制 (RBAC)：** 為 MCP 伺服器指派嚴格限定於特定資源與操作的角色，避免廣泛或不必要的權限。
- **監控與稽核權限：** 持續監控權限使用情況，並稽核存取日誌，及時偵測與修正過度或未使用的權限。

# 間接提示注入攻擊

### 問題說明

惡意或遭入侵的 MCP 伺服器可能帶來重大風險，暴露客戶資料或觸發非預期行為。這些風險在 AI 與基於 MCP 的工作負載中特別重要，包括：

- **提示注入攻擊**：攻擊者在提示或外部內容中嵌入惡意指令，導致 AI 系統執行非預期行為或洩漏敏感資料。詳見：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **工具中毒**：攻擊者操控工具元資料（如描述或參數），影響 AI 行為，可能繞過安全控管或外洩資料。詳情：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **跨域提示注入**：惡意指令藏於文件、網頁或電子郵件中，AI 處理時導致資料洩漏或操控。
- **動態工具修改（Rug Pulls）**：工具定義在用戶批准後被更改，導入新的惡意行為而用戶不知情。

這些漏洞凸顯在整合 MCP 伺服器與工具時，需強化驗證、監控與安全控管。欲深入了解，請參考上述連結。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.tw.png)

**間接提示注入**（又稱跨域提示注入或 XPIA）是生成式 AI 系統中的嚴重漏洞，包括使用 Model Context Protocol (MCP) 的系統。此攻擊將惡意指令隱藏於外部內容（如文件、網頁或電子郵件）中。當 AI 系統處理這些內容時，可能將嵌入的指令誤判為合法使用者命令，導致非預期行為，如資料外洩、生成有害內容或操控使用者互動。詳細說明與實例請見 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)。

其中一種特別危險的攻擊是 **工具中毒**。攻擊者將惡意指令注入 MCP 工具的元資料（如工具描述或參數）。由於大型語言模型（LLM）依賴這些元資料決定調用哪些工具，遭破壞的描述可能誘使模型執行未授權的工具呼叫或繞過安全控管。這些操控通常對終端使用者不可見，但 AI 系統會解讀並執行。此風險在託管 MCP 伺服器環境中更為嚴重，因為工具定義可在用戶批准後被更新，這種情況有時稱為「[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)」。在此情況下，原本安全的工具可能被修改為執行惡意行為，如資料外洩或系統行為異常，且用戶不知情。更多攻擊向量詳見 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.tw.png)

## 風險  
非預期的 AI 行為帶來多種安全風險，包括資料外洩與隱私侵犯。

### 緩解控管  
### 使用 Prompt Shields 防禦間接提示注入攻擊
-----------------------------------------------------------------------------

**AI Prompt Shields** 是 Microsoft 開發的解決方案，用以防禦直接與間接的提示注入攻擊。其功能包括：

1.  **偵測與過濾**：Prompt Shields 利用先進的機器學習演算法與自然語言處理技術，偵測並過濾外部內容（如文件、網頁或電子郵件）中嵌入的惡意指令。
    
2.  **聚焦技術（Spotlighting）**：此技術協助 AI 系統區分有效的系統指令與可能不可信的外部輸入。透過轉換輸入文字，使其更符合模型需求，Spotlighting 確保 AI 能更準確識別並忽略惡意指令。
    
3.  **分隔符與資料標記**：在系統訊息中加入分隔符，明確標示輸入文字的位置，幫助 AI 系統辨識並分離使用者輸入與潛在有害的外部內容。資料標記則利用特殊標記強調可信與不可信資料的界線。
    
4.  **持續監控與更新**：Microsoft 持續監控並更新 Prompt Shields，以應對新興與演變中的威脅。此主動防禦確保防護措施對最新攻擊技術仍具效力。
    
5. **與 Azure Content Safety 整合：** Prompt Shields 是 Azure AI Content Safety 套件的一部分，該套件提供額外工具來偵測越獄嘗試、有害內容及其他 AI 應用的安全風險。

您可參考 [Prompt Shields 文件](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) 了解更多 AI Prompt Shields。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.tw.png)

### 供應鏈安全
供應鏈安全在 AI 時代依然至關重要，但供應鏈的範疇已經擴大。除了傳統的程式碼套件外，您現在必須嚴格驗證並監控所有與 AI 相關的元件，包括基礎模型、嵌入服務、上下文提供者以及第三方 API。若管理不當，這些都可能帶來漏洞或風險。

**AI 與 MCP 供應鏈安全的關鍵做法：**
- **整合前驗證所有元件：** 不僅是開源函式庫，還包括 AI 模型、資料來源和外部 API。務必檢查來源、授權及已知漏洞。
- **維護安全的部署流程：** 使用整合安全掃描的自動化 CI/CD 流程，及早發現問題。確保只有受信任的產物被部署到生產環境。
- **持續監控與稽核：** 對所有依賴項（包括模型和資料服務）實施持續監控，以偵測新漏洞或供應鏈攻擊。
- **採用最小權限與存取控制：** 限制模型、資料和服務的存取權限，僅限 MCP 伺服器正常運作所需。
- **迅速回應威脅：** 建立流程以修補或替換受損元件，若發現入侵則旋轉密鑰或憑證。

[GitHub Advanced Security](https://github.com/security/advanced-security) 提供秘密掃描、依賴掃描和 CodeQL 分析等功能。這些工具可與 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 和 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 整合，協助團隊識別並減輕程式碼及 AI 供應鏈元件的漏洞。

微軟也在內部對所有產品實施廣泛的供應鏈安全措施。詳情請參閱 [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。

# 已建立的安全最佳實踐，提升您的 MCP 實作安全態勢

任何 MCP 實作都繼承了其所建置組織環境的既有安全態勢，因此在將 MCP 視為整體 AI 系統的一部分時，建議提升整體現有的安全態勢。以下已建立的安全控管尤其重要：

- AI 應用的安全程式設計最佳實踐 — 防範 [OWASP Top 10](https://owasp.org/www-project-top-ten/)、[OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)，使用安全保管庫管理秘密與令牌，實現應用元件間的端對端安全通訊等。
- 伺服器強化 — 盡可能使用多重身份驗證（MFA）、保持補丁更新，並將伺服器整合第三方身份提供者以控管存取。
- 持續為裝置、基礎設施與應用程式套用最新補丁。
- 安全監控 — 實施 AI 應用（含 MCP 用戶端/伺服器）的日誌與監控，並將日誌傳送至中央 SIEM 以偵測異常行為。
- 零信任架構 — 透過網路與身份控管邏輯隔離元件，若 AI 應用遭入侵，可將橫向移動風險降至最低。

# 主要重點

- 安全基礎依然關鍵：安全程式設計、最小權限、供應鏈驗證與持續監控對 MCP 和 AI 工作負載不可或缺。
- MCP 帶來新風險，如提示注入、工具中毒及過度權限，需結合傳統與 AI 專屬控管。
- 採用強健的身份驗證、授權與令牌管理，盡可能利用 Microsoft Entra ID 等外部身份提供者。
- 透過驗證工具元資料、監控動態變更及使用 Microsoft Prompt Shields 等解決方案，防範間接提示注入與工具中毒。
- 對 AI 供應鏈中的所有元件（包括模型、嵌入與上下文提供者）採取與程式碼依賴相同的嚴謹態度。
- 持續關注 MCP 規範的演進，並參與社群協助塑造安全標準。

# 其他資源

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
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

下一步：[Chapter 3: Getting Started](../03-GettingStarted/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤譯負責。