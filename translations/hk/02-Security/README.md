<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-16T21:18:34+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "hk"
}
-->
# 安全最佳實踐

採用 Model Context Protocol (MCP) 為 AI 驅動的應用程式帶來強大的新功能，但同時也引入了超越傳統軟件風險的獨特安全挑戰。除了既有的安全編碼、最小權限和供應鏈安全等問題外，MCP 和 AI 工作負載還面臨新的威脅，例如提示注入、工具中毒、動態工具修改、會話劫持、混淆代理攻擊以及令牌直通漏洞。如果未妥善管理，這些風險可能導致資料外洩、隱私洩漏和系統行為異常。

本課程探討與 MCP 相關的最重要安全風險，包括身份驗證、授權、過度權限、間接提示注入、會話安全、混淆代理問題、令牌直通漏洞和供應鏈漏洞，並提供可行的控制措施和最佳實踐來減輕這些風險。你還將學習如何利用 Microsoft 的解決方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security，來加強你的 MCP 實施。透過理解和應用這些控制措施，你可以大幅降低安全漏洞的可能性，確保你的 AI 系統保持穩健且值得信賴。

# 學習目標

完成本課程後，你將能夠：

- 識別並解釋 Model Context Protocol (MCP) 帶來的獨特安全風險，包括提示注入、工具中毒、過度權限、會話劫持、混淆代理問題、令牌直通漏洞和供應鏈漏洞。
- 描述並應用有效的緩解控制措施，如強健的身份驗證、最小權限、安全的令牌管理、會話安全控制和供應鏈驗證。
- 了解並運用 Microsoft 解決方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security，來保護 MCP 和 AI 工作負載。
- 認識驗證工具元資料、監控動態變更、防禦間接提示注入攻擊及防止會話劫持的重要性。
- 將既有的安全最佳實踐（如安全編碼、伺服器強化和零信任架構）整合到 MCP 實施中，以降低安全漏洞的發生率和影響。

# MCP 安全控制

任何能存取重要資源的系統都面臨隱含的安全挑戰。這些挑戰通常可透過正確應用基本的安全控制和概念來解決。由於 MCP 是新定義的協議，規範正在快速變化並持續演進。最終，內建的安全控制將趨於成熟，能更好地與企業及既有的安全架構和最佳實踐整合。

根據 [Microsoft Digital Defense Report](https://aka.ms/mddr) 的研究，98% 的已報告安全漏洞可透過強健的安全衛生措施防止，而防範任何形式的安全漏洞的最佳方法是確保基線安全衛生、遵循安全編碼最佳實踐及供應鏈安全——這些經過驗證的做法仍是降低安全風險的關鍵。

讓我們來看看採用 MCP 時，可以如何開始應對安全風險。

> **Note:** 以下資訊截至 **2025 年 5 月 29 日** 為準。MCP 協議持續演進，未來的實作可能會引入新的身份驗證模式和控制措施。欲獲得最新更新和指引，請參考 [MCP 規範](https://spec.modelcontextprotocol.io/)、官方 [MCP GitHub 倉庫](https://github.com/modelcontextprotocol) 及 [安全最佳實踐頁面](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)。

### 問題陳述  
原始 MCP 規範假設開發者會自行撰寫身份驗證伺服器，這需要具備 OAuth 及相關安全限制的知識。MCP 伺服器作為 OAuth 2.0 授權伺服器，直接管理所需的用戶身份驗證，而非委派給外部服務（如 Microsoft Entra ID）。自 **2025 年 4 月 26 日** 起，MCP 規範更新允許 MCP 伺服器將用戶身份驗證委派給外部服務。

### 風險
- MCP 伺服器中錯誤配置的授權邏輯可能導致敏感資料外洩及存取控制錯誤。
- 本地 MCP 伺服器上的 OAuth 令牌被竊取。若令牌被盜，攻擊者可冒充 MCP 伺服器，存取該 OAuth 令牌所對應服務的資源和資料。

#### 令牌直通
授權規範明確禁止令牌直通，因其帶來多項安全風險，包括：

#### 安全控制繞過
MCP 伺服器或下游 API 可能實施重要的安全控制，如速率限制、請求驗證或流量監控，這些控制依賴令牌的受眾或其他憑證限制。若客戶端能直接取得並使用令牌與下游 API 互動，而 MCP 伺服器未正確驗證令牌或確保令牌是為正確服務發行，則會繞過這些控制。

#### 責任追蹤與審計問題
當客戶端使用上游發行的存取令牌呼叫時，MCP 伺服器無法識別或區分不同 MCP 客戶端。  
下游資源伺服器的日誌可能顯示請求來自不同來源和身份，而非實際轉發令牌的 MCP 伺服器。  
這兩者都使事件調查、控制和審計變得更困難。  
若 MCP 伺服器在轉發令牌時未驗證其聲明（如角色、權限或受眾）或其他元資料，持有被盜令牌的惡意者可利用該伺服器作為資料外洩的代理。

#### 信任邊界問題
下游資源伺服器對特定實體授予信任，該信任可能包含對來源或客戶端行為模式的假設。破壞此信任邊界可能導致意外問題。  
若令牌被多個服務接受且未經適當驗證，攻擊者若入侵其中一個服務，便可利用該令牌存取其他連接服務。

#### 未來相容性風險
即使 MCP 伺服器目前是「純代理」，未來可能需要新增安全控制。從一開始就正確分離令牌受眾，有助於安全模型的演進。

### 緩解控制

**MCP 伺服器不得接受未明確為 MCP 伺服器發行的任何令牌**

- **審查並強化授權邏輯：** 仔細審核 MCP 伺服器的授權實作，確保只有預期的用戶和客戶端能存取敏感資源。實務指引請參考 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 及 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **強制安全令牌使用規範：** 遵循 [Microsoft 的令牌驗證與壽命最佳實踐](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，防止存取令牌濫用，降低令牌重放或竊取風險。
- **保護令牌儲存：** 始終安全儲存令牌，並使用加密保護靜態及傳輸中的令牌。實作技巧請參考 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# MCP 伺服器的過度權限

### 問題陳述  
MCP 伺服器可能被授予過多的服務或資源權限。例如，作為 AI 銷售應用一部分的 MCP 伺服器連接企業資料庫時，應僅限於存取銷售資料，而非整個資料庫的所有檔案。回歸最小權限原則（最古老的安全原則之一），任何資源都不應擁有超出其執行任務所需的權限。AI 在此領域帶來更大挑戰，因為為了保持彈性，準確定義所需權限變得困難。

### 風險  
- 過度授權可能導致 MCP 伺服器外洩或修改其不應存取的資料。若資料包含個人識別資訊（PII），也會引發隱私問題。

### 緩解控制  
- **應用最小權限原則：** 僅授予 MCP 伺服器執行任務所需的最低權限，並定期檢視及更新權限，確保不超出必要範圍。詳細指引請參考 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **使用基於角色的存取控制 (RBAC)：** 為 MCP 伺服器分配嚴格限定於特定資源和操作的角色，避免廣泛或不必要的權限。
- **監控與審計權限：** 持續監控權限使用情況，審計存取日誌，及時偵測並修正過度或未使用的權限。

# 間接提示注入攻擊

### 問題陳述

惡意或被入侵的 MCP 伺服器可能帶來重大風險，暴露客戶資料或觸發非預期行為。這些風險在 AI 和基於 MCP 的工作負載中特別重要，包括：

- **提示注入攻擊**：攻擊者在提示或外部內容中嵌入惡意指令，導致 AI 系統執行非預期操作或洩漏敏感資料。詳情請參考：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **工具中毒**：攻擊者操控工具元資料（如描述或參數），影響 AI 行為，可能繞過安全控制或外洩資料。詳情請參考：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **跨域提示注入**：惡意指令藏於文件、網頁或電子郵件中，AI 處理時導致資料洩漏或操控。
- **動態工具修改（Rug Pulls）**：工具定義在用戶批准後被更改，導入新的惡意行為而用戶不知情。

這些漏洞凸顯了在整合 MCP 伺服器和工具時，必須實施嚴格的驗證、監控和安全控制。欲深入了解，請參考上述連結。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.hk.png)

**間接提示注入**（又稱跨域提示注入或 XPIA）是生成式 AI 系統中的關鍵漏洞，包括使用 Model Context Protocol (MCP) 的系統。此攻擊將惡意指令隱藏於外部內容（如文件、網頁或電子郵件）中。當 AI 系統處理這些內容時，可能將嵌入的指令誤認為合法用戶命令，導致非預期行為，如資料洩漏、生成有害內容或操控用戶互動。詳細說明及實例請參考 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)。

其中一種特別危險的攻擊是 **工具中毒**。攻擊者將惡意指令注入 MCP 工具的元資料（如工具描述或參數）。由於大型語言模型（LLM）依賴這些元資料決定調用哪些工具，遭破壞的描述可能誘使模型執行未授權的工具呼叫或繞過安全控制。這些操控通常對終端用戶不可見，但 AI 系統會解讀並執行。此風險在託管 MCP 伺服器環境中尤為嚴重，因為工具定義可在用戶批准後被更新，這種情況有時稱為「[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)」。在此情況下，原本安全的工具可能被修改為執行惡意行為，如資料外洩或系統行為變更，而用戶不知情。更多攻擊向量詳見 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.hk.png)

## 風險  
非預期的 AI 行為帶來多種安全風險，包括資料外洩和隱私洩漏。

### 緩解控制  
### 使用 Prompt Shields 防禦間接提示注入攻擊
-----------------------------------------------------------------------------

**AI Prompt Shields** 是 Microsoft 開發的解決方案，用以防禦直接及間接的提示注入攻擊。其功能包括：

1.  **偵測與過濾**：Prompt Shields 利用先進的機器學習演算法和自然語言處理技術，偵測並過濾外部內容（如文件、網頁或電子郵件）中嵌入的惡意指令。
    
2.  **聚焦技術（Spotlighting）**：此技術協助 AI 系統區分有效的系統指令與可能不可信的外部輸入。透過轉換輸入文字，使其更符合模型需求，Spotlighting 確保 AI 能更準確識別並忽略惡意指令。
    
3.  **分隔符與資料標記**：在系統訊息中加入分隔符，明確標示輸入文字的位置，幫助 AI 系統辨識並分離用戶輸入與潛在有害的外部內容。資料標記則利用特殊標記突出可信與不可信資料的邊界。
    
4.  **持續監控與更新**：Microsoft 持續監控並更新 Prompt Shields，以應對新興及演變中的威脅。此主動防禦確保防護措施對最新攻擊技術保持有效。
    
5. **與 Azure Content Safety 整合：** Prompt Shields 是 Azure AI Content Safety 套件的一部分，該套件提供額外工具來偵測越獄嘗試、有害內容及其他 AI 應用的安全風險。

你可以在 [Prompt Shields 文件](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) 中閱讀更多關於 AI Prompt Shields 的資訊。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.hk.png)

# 混淆代理問題

### 問題陳述
混淆代理問題是一種安全漏洞，發生於 MCP 伺服器作為 MCP 用戶端與第三方 API 之間的代理時。當 MCP 伺服器使用靜態客戶端 ID 向不支援動態客戶端註冊的第三方授權伺服器進行身份驗證時，該漏洞可能被利用。

### 風險

- **基於 Cookie 的同意繞過**：如果使用者之前已透過 MCP 代理伺服器進行身份驗證，第三方授權伺服器可能會在使用者瀏覽器中設置同意 Cookie。攻擊者可利用此點，向使用者發送包含惡意重定向 URI 的授權請求惡意連結。
- **授權碼竊取**：當使用者點擊惡意連結時，第三方授權伺服器可能因現有 Cookie 而跳過同意畫面，授權碼可能會被重定向到攻擊者的伺服器。
- **未經授權的 API 存取**：攻擊者可將竊取的授權碼兌換成存取權杖，冒充使用者存取第三方 API，無需明確批准。

### 緩解措施

- **明確同意要求**：使用靜態客戶端 ID 的 MCP 代理伺服器**必須**在轉發至第三方授權伺服器前，為每個動態註冊的客戶端取得使用者同意。
- **正確的 OAuth 實作**：遵循 OAuth 2.1 的安全最佳實踐，包括對授權請求使用代碼挑戰（PKCE）以防止攔截攻擊。
- **客戶端驗證**：嚴格驗證重定向 URI 和客戶端識別碼，防止惡意行為者利用漏洞。

# Token Passthrough 漏洞

### 問題說明

「Token passthrough」是一種反模式，指 MCP 伺服器接受來自 MCP 用戶端的權杖，卻未驗證該權杖是否正確發給 MCP 伺服器本身，然後將權杖「直接傳遞」給下游 API。此做法明顯違反 MCP 授權規範，並帶來嚴重安全風險。

### 風險

- **安全控管繞過**：若用戶端能直接使用權杖與下游 API 互動而無適當驗證，可能繞過重要安全控管，如速率限制、請求驗證或流量監控。
- **責任與審計追蹤問題**：當用戶端使用上游發行的存取權杖時，MCP 伺服器無法辨識或區分不同 MCP 用戶端，導致事件調查與審計困難。
- **資料外洩**：若權杖未經適當聲明驗證，持有被竊權杖的惡意者可利用伺服器作為資料外洩的代理。
- **信任邊界違反**：下游資源伺服器可能基於來源或行為模式對特定實體授予信任，破壞此信任邊界可能引發意外安全問題。
- **多服務權杖濫用**：若多個服務接受未經適當驗證的權杖，攻擊者入侵其中一個服務後，可能利用該權杖存取其他連接服務。

### 緩解措施

- **權杖驗證**：MCP 伺服器**不得**接受非明確發給自身的任何權杖。
- **受眾驗證**：始終驗證權杖的受眾聲明是否與 MCP 伺服器身份相符。
- **適當的權杖生命週期管理**：實施短期存取權杖及適當的權杖輪替機制，以降低權杖竊取與濫用風險。

# 會話劫持

### 問題說明

會話劫持是一種攻擊手法，攻擊者取得伺服器提供給用戶端的會話 ID，並利用該會話 ID 冒充原始用戶端執行未經授權的操作。此問題在處理 MCP 請求的有狀態 HTTP 伺服器中特別令人擔憂。

### 風險

- **會話劫持提示注入**：攻擊者取得會話 ID 後，可能向與用戶端連線伺服器共享會話狀態的伺服器發送惡意事件，觸發有害操作或存取敏感資料。
- **會話劫持冒充**：持有被竊會話 ID 的攻擊者可直接呼叫 MCP 伺服器，繞過身份驗證，並被視為合法使用者。
- **可恢復串流遭破壞**：當伺服器支援重送/可恢復串流時，攻擊者可提前終止請求，導致原用戶端稍後恢復時可能帶入惡意內容。

### 緩解措施

- **授權驗證**：實作授權的 MCP 伺服器**必須**驗證所有入站請求，且**不得**使用會話作為身份驗證手段。
- **安全會話 ID**：MCP 伺服器**必須**使用由安全隨機數生成器產生的安全且非決定性的會話 ID，避免使用可預測或連續的識別碼。
- **用戶專屬會話綁定**：MCP 伺服器**應該**將會話 ID 與用戶專屬資訊綁定，例如使用格式 `<user_id>:<session_id>` 結合內部用戶 ID。
- **會話過期**：實施適當的會話過期與輪替機制，限制會話 ID 被盜用的風險時間窗。
- **傳輸安全**：所有通訊必須使用 HTTPS，防止會話 ID 被攔截。

# 供應鏈安全

供應鏈安全在 AI 時代依然至關重要，但供應鏈的範圍已擴大。除了傳統的程式碼套件外，您現在必須嚴格驗證和監控所有 AI 相關元件，包括基礎模型、嵌入服務、上下文提供者及第三方 API。若管理不當，這些元件都可能引入漏洞或風險。

**AI 與 MCP 供應鏈安全的關鍵做法：**
- **整合前驗證所有元件**：不僅是開源函式庫，還包括 AI 模型、資料來源及外部 API。務必檢查來源、授權及已知漏洞。
- **維護安全部署管線**：使用整合安全掃描的自動化 CI/CD 管線，及早發現問題。確保僅可信工件部署至生產環境。
- **持續監控與稽核**：對所有依賴項（包括模型與資料服務）實施持續監控，偵測新漏洞或供應鏈攻擊。
- **最小權限與存取控管**：限制模型、資料及服務的存取權限，僅限 MCP 伺服器正常運作所需。
- **快速回應威脅**：建立流程以修補或替換受損元件，並在偵測到入侵時輪替密鑰或憑證。

[GitHub Advanced Security](https://github.com/security/advanced-security) 提供秘密掃描、依賴掃描及 CodeQL 分析等功能，並與 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 及 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 整合，協助團隊識別並減輕程式碼及 AI 供應鏈元件的漏洞。

微軟也在內部對所有產品實施廣泛的供應鏈安全措施。詳情請參閱 [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。

# 已建立的安全最佳實踐，提升您的 MCP 實作安全態勢

任何 MCP 實作都繼承了其所建構組織環境的既有安全態勢，因此在考慮 MCP 作為整體 AI 系統組件的安全性時，建議提升整體既有安全態勢。以下已建立的安全控管尤其相關：

- AI 應用的安全程式設計最佳實踐 — 防範 [OWASP Top 10](https://owasp.org/www-project-top-ten/)、[LLM 專用 OWASP Top 10](https://genai.owasp.org/download/43299/?tmstv=1731900559)、使用安全保管庫管理秘密與權杖、實作應用元件間的端對端安全通訊等。
- 伺服器強化 — 盡可能使用多因素驗證，保持補丁更新，整合第三方身份提供者進行存取控管等。
- 裝置、基礎設施與應用程式保持最新補丁。
- 安全監控 — 實施 AI 應用（含 MCP 用戶端/伺服器）的日誌與監控，並將日誌送至中央 SIEM 以偵測異常行為。
- 零信任架構 — 透過網路與身份控管邏輯隔離元件，降低 AI 應用遭入侵時的橫向移動風險。

# 主要重點

- 安全基礎依然關鍵：安全程式設計、最小權限、供應鏈驗證與持續監控對 MCP 與 AI 工作負載至關重要。
- MCP 帶來新風險 — 如提示注入、工具中毒、會話劫持、混淆代理問題、Token Passthrough 漏洞及過度權限，需結合傳統與 AI 專屬控管。
- 採用強健的身份驗證、授權與權杖管理實務，盡可能利用 Microsoft Entra ID 等外部身份提供者。
- 透過驗證工具元資料、監控動態變更及使用 Microsoft Prompt Shields 等方案，防範間接提示注入與工具中毒。
- 實作安全會話管理，使用非決定性會話 ID，將會話綁定至用戶身份，且絕不使用會話作為身份驗證。
- 透過要求每個動態註冊客戶端的明確使用者同意及正確的 OAuth 安全實作，防止混淆代理攻擊。
- 避免 Token Passthrough 漏洞，確保 MCP 伺服器僅接受明確發給自身的權杖，並適當驗證權杖聲明。
- 對 AI 供應鏈中的所有元件（包括模型、嵌入與上下文提供者）採取與程式碼依賴相同的嚴格標準。
- 持續關注 MCP 規範的演進，並參與社群協助塑造安全標準。

# 附加資源

## 外部資源
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
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
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## 其他安全文件

欲獲得更詳細的安全指引，請參考以下文件：

- [MCP Security Best Practices 2025](./mcp-security-best-practices-2025.md) - MCP 實作的全面安全最佳實踐清單
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md) - Azure Content Safety 與 MCP 伺服器整合的實作範例
- [MCP Security Controls 2025](./mcp-security-controls-2025.md) - 最新 MCP 部署安全控管與技術
- [MCP Best Practices](./mcp-best-practices.md) - MCP 安全快速參考指南

### 下一步

下一章節：[Chapter 3: Getting Started](../03-GettingStarted/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。