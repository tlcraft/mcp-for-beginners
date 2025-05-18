<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:15:18+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "tw"
}
-->
# 安全最佳實踐

採用模型上下文協議 (MCP) 為 AI 驅動的應用程式帶來強大的新功能，但也引入了獨特的安全挑戰，這些挑戰超出了傳統軟體風險。除了既有的安全編碼、最低特權和供應鏈安全等問題外，MCP 和 AI 工作負載還面臨新的威脅，如提示注入、工具污染和動態工具修改。如果管理不當，這些風險可能導致資料外洩、隱私洩漏和系統行為意外。

本課程探討與 MCP 相關的最相關的安全風險，包括身份驗證、授權、過度權限、間接提示注入和供應鏈漏洞，並提供可操作的控制措施和最佳實踐來減輕這些風險。您還將學習如何利用 Microsoft 解決方案，如 Prompt Shields、Azure 內容安全和 GitHub 高級安全性來加強您的 MCP 實施。通過理解和應用這些控制措施，您可以顯著降低安全漏洞的可能性，確保您的 AI 系統保持強大和可信。

# 學習目標

完成本課程後，您將能夠：

- 識別並解釋模型上下文協議 (MCP) 引入的獨特安全風險，包括提示注入、工具污染、過度權限和供應鏈漏洞。
- 描述並應用有效的 MCP 安全風險緩解控制措施，如強健的身份驗證、最低特權、安全令牌管理和供應鏈驗證。
- 理解並利用 Microsoft 解決方案，如 Prompt Shields、Azure 內容安全和 GitHub 高級安全性來保護 MCP 和 AI 工作負載。
- 認識到驗證工具元數據、監控動態變化以及防禦間接提示注入攻擊的重要性。
- 將既有的安全最佳實踐，如安全編碼、伺服器加固和零信任架構，整合到您的 MCP 實施中，以減少安全漏洞的可能性和影響。

# MCP 安全控制

任何有重要資源訪問權的系統都隱含著安全挑戰。安全挑戰通常可以通過正確應用基本的安全控制和概念來解決。由於 MCP 只是新定義的，規範正在迅速變化，隨著協議的演變，最終其中的安全控制將會成熟，從而更好地與企業和既有的安全架構和最佳實踐集成。

[Microsoft Digital Defense Report](https://aka.ms/mddr) 發布的研究指出，98% 的報告漏洞將通過強健的安全衛生防止，對任何類型的漏洞的最佳保護是獲得您的基線安全衛生、安全編碼最佳實踐和供應鏈安全——那些已經被嘗試和測試的實踐仍然在降低安全風險方面產生最大影響。

讓我們看看在採用 MCP 時可以開始解決安全風險的一些方法。

# MCP 伺服器身份驗證（如果您的 MCP 實施是在 2025 年 4 月 26 日之前）

> **注意:** 以下信息截至 2025 年 4 月 26 日正確。MCP 協議不斷演變，未來的實施可能會引入新的身份驗證模式和控制。欲了解最新的更新和指導，請始終參閱 [MCP 規範](https://spec.modelcontextprotocol.io/) 和官方 [MCP GitHub 存儲庫](https://github.com/modelcontextprotocol)。

### 問題陳述 
最初的 MCP 規範假定開發者會編寫自己的身份驗證伺服器。這需要 OAuth 和相關安全約束的知識。MCP 伺服器充當 OAuth 2.0 授權伺服器，直接管理所需的用戶身份驗證，而不是將其委託給外部服務，如 Microsoft Entra ID。自 2025 年 4 月 26 日起，MCP 規範更新允許 MCP 伺服器將用戶身份驗證委託給外部服務。

### 風險
- MCP 伺服器中的授權邏輯配置錯誤可能導致敏感資料暴露和訪問控制應用不當。
- 在本地 MCP 伺服器上 OAuth 令牌被盜。如果被盜，令牌可以用來冒充 MCP 伺服器並訪問 OAuth 令牌所針對的服務和資料。

### 緩解控制
- **審核和加固授權邏輯:** 仔細審核您的 MCP 伺服器的授權實施，以確保只有預期的用戶和客戶端能夠訪問敏感資源。欲了解實用指南，請參閱 [Azure API Management 您的 MCP 伺服器的身份驗證網關 | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 和 [使用 Microsoft Entra ID 通過會話驗證 MCP 伺服器 - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **強制安全令牌實踐:** 遵循 [Microsoft 的令牌驗證和生命周期最佳實踐](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，以防止濫用訪問令牌並減少令牌重播或被盜的風險。
- **保護令牌存儲:** 始終安全存儲令牌並使用加密來保護它們在休息和傳輸中的安全。欲了解實施提示，請參閱 [使用安全令牌存儲並加密令牌](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# MCP 伺服器的過度權限

### 問題陳述
MCP 伺服器可能被授予了過度的服務/資源訪問權限。例如，作為 AI 銷售應用程式的一部分的 MCP 伺服器連接到企業資料庫應該被授予的訪問範圍僅限於銷售資料，而不允許訪問資料庫中的所有文件。回到最低特權原則（最古老的安全原則之一），沒有資源應該被授予超過其執行預期任務所需的權限。AI 在這方面提出了更大的挑戰，因為要使其具有靈活性，可能很難確定所需的確切權限。

### 風險 
- 授予過度權限可能允許資料外洩或修改 MCP 伺服器不應能夠訪問的資料。如果資料是個人身份信息 (PII)，這也可能成為隱私問題。

### 緩解控制
- **應用最低特權原則:** 只授予 MCP 伺服器執行其所需任務的最低權限。定期審核並更新這些權限以確保它們不超過所需。欲了解詳細指南，請參閱 [安全最低特權訪問](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **使用基於角色的訪問控制 (RBAC):** 將角色分配給 MCP 伺服器，這些角色嚴格限定於特定資源和行動，避免廣泛或不必要的權限。
- **監控和審核權限:** 持續監控權限使用情況並審核訪問日誌，以便及時檢測和修復過度或未使用的權限。

# 間接提示注入攻擊

### 問題陳述

惡意或受損的 MCP 伺服器可能通過暴露客戶資料或啟用意外行動引入重大風險。這些風險在 AI 和基於 MCP 的工作負載中特別相關，其中：

- **提示注入攻擊**: 攻擊者將惡意指令嵌入提示或外部內容中，導致 AI 系統執行意外行動或洩露敏感資料。了解更多：[提示注入](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **工具污染**: 攻擊者操縱工具元數據（如描述或參數）以影響 AI 的行為，可能繞過安全控制或外洩資料。詳情：[工具污染](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **跨域提示注入**: 惡意指令嵌入在文件、網頁或電子郵件中，然後由 AI 處理，導致資料洩漏或操縱。
- **動態工具修改 (Rug Pulls)**: 工具定義可以在用戶批准後更改，引入新的惡意行為而不讓用戶知曉。

這些漏洞突顯了在將 MCP 伺服器和工具整合到您的環境中時需要強健的驗證、監控和安全控制。欲了解更深入的探討，請參閱上面鏈接的參考資料。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.tw.png)

**間接提示注入**（也稱為跨域提示注入或 XPIA）是生成式 AI 系統中的一個關鍵漏洞，包括使用模型上下文協議 (MCP) 的系統。在此攻擊中，惡意指令隱藏在外部內容中，例如文件、網頁或電子郵件中。當 AI 系統處理這些內容時，它可能將嵌入的指令解釋為合法的用戶命令，導致意外行動，如資料洩漏、生成有害內容或操縱用戶交互。欲了解詳細解釋和真實世界示例，請參閱 [提示注入](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)。

此攻擊的一種特別危險形式是 **工具污染**。在這裡，攻擊者將惡意指令注入 MCP 工具的元數據中（如工具描述或參數）。由於大型語言模型 (LLMs) 依賴於這些元數據來決定調用哪些工具，受損的描述可能會欺騙模型執行未授權的工具調用或繞過安全控制。這些操縱通常對最終用戶是不可見的，但可以被 AI 系統解釋和執行。在托管的 MCP 伺服器環境中，工具定義可以在用戶批准後更新——這種情況有時被稱為 "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)"。在這種情況下，之前安全的工具可能後來被修改為執行惡意行動，如資料外洩或改變系統行為，而不讓用戶知曉。欲了解更多有關此攻擊向量的信息，請參閱 [工具污染](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.tw.png)

## 風險
意外的 AI 行動帶來多種安全風險，包括資料外洩和隱私洩漏。

### 緩解控制
### 使用提示屏障保護免受間接提示注入攻擊
-----------------------------------------------------------------------------

**AI 提示屏障** 是 Microsoft 開發的一種解決方案，用於防禦直接和間接提示注入攻擊。它們通過以下方式提供幫助：

1.  **檢測和過濾**: 提示屏障使用先進的機器學習算法和自然語言處理來檢測和過濾嵌入在外部內容中的惡意指令，例如文件、網頁或電子郵件。
    
2.  **聚光燈技術**: 此技術幫助 AI 系統區分有效的系統指令和可能不可信的外部輸入。通過以使輸入文本對模型更相關的方式轉化，聚光燈技術確保 AI 可以更好地識別和忽略惡意指令。
    
3.  **分隔符和數據標記**: 在系統消息中包含分隔符明確概述輸入文本的位置，幫助 AI 系統識別並分離用戶輸入與可能有害的外部內容。數據標記通過使用特殊標記來突出顯示受信任和不受信任數據的邊界來擴展此概念。
    
4.  **持續監控和更新**: Microsoft 持續監控和更新提示屏障以應對新的和不斷演變的威脅。這種主動的方法確保防禦措施對最新的攻擊技術仍然有效。
    
5. **與 Azure 內容安全集成:** 提示屏障是更廣泛的 Azure AI 內容安全套件的一部分，該套件提供了額外的工具來檢測越獄企圖、有害內容和 AI 應用中的其他安全風險。

您可以在 [Prompt Shields 文檔](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) 中閱讀更多有關 AI 提示屏障的信息。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.tw.png)

### 供應鏈安全

供應鏈安全在 AI 時代仍然是基本的，但構成供應鏈的範圍已經擴展。除了傳統的代碼包外，您現在必須嚴格驗證和監控所有 AI 相關組件，包括基礎模型、嵌入服務、上下文提供者和第三方 API。如果管理不當，每個這些都可能引入漏洞或風險。

**AI 和 MCP 的供應鏈安全實踐要點:**
- **在集成之前驗證所有組件:** 這不僅包括開源庫，還包括 AI 模型、數據源和外部 API。始終檢查來源、許可和已知漏洞。
- **維護安全的部署管道:** 使用集成安全掃描的自動化 CI/CD 管道來及早捕獲問題。確保只有受信任的工件被部署到生產環境。
- **持續監控和審核:** 實施所有依賴項的持續監控，包括模型和數據服務，以檢測新的漏洞或供應鏈攻擊。
- **應用最低特權和訪問控制:** 限制對模型、數據和服務的訪問僅限於 MCP 伺服器運行所需的內容。
- **迅速應對威脅:** 制定一個過程來修補或替換受損的組件，以及在檢測到漏洞時旋轉秘密或憑證。

[GitHub 高級安全性](https://github.com/security/advanced-security) 提供了秘密掃描、依賴項掃描和 CodeQL 分析等功能。這些工具與 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 和 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 集成，幫助團隊識別和減輕代碼和 AI 供應鏈組件中的漏洞。

Microsoft 也在所有產品中內部實施了廣泛的供應鏈安全實踐。了解更多信息，請參閱 [在 Microsoft 安全軟件供應鏈的旅程](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。

# 提升您的 MCP 實施的安全姿態的既有安全最佳實踐

任何 MCP 實施都繼承了其所建環境的組織的既有安全姿態，因此在考慮 MCP 作為您整體 AI 系統的一個組成部分的安全性時，建議您提升整體既有安全姿態。以下既有安全控制尤其相關：

-   在您的 AI 應用中實施安全編碼最佳實踐——防止 [OWASP 十大](https://owasp.org/www-project-top-ten/)、[OWASP LLM 十大](https://genai.owasp.org/download/43299/?tmstv=1731900559)、使用安全保險庫存儲秘密和令牌、在所有應用組件之間實施端到端安全通信等。
-   伺服器加固——盡可能使用 MFA，保持補丁更新，將伺服器與第三方身份提供者集成以進行訪問等。
-   使設備、基礎設施和應用保持補丁更新
-   安全監控——實施 AI 應用的日誌和監控（包括 MCP 客戶端/伺服器）並將這些日誌發送到中央 SIEM 以檢測異常活動
-   零信任架構——通過網絡和身份控制以
- [OWASP LLMs 十大安全風險](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub 高級安全功能](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Microsoft 的軟體供應鏈安全之旅](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [安全的最低特權訪問 (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Token 驗證和有效期的最佳實踐](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [使用安全的 Token 存儲並加密 Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API 管理作為 MCP 的身份驗證閘道](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [使用 Microsoft Entra ID 與 MCP 伺服器進行身份驗證](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 下一步 

下一步：[第 3 章：入門指南](/03-GettingStarted/README.md)

**免責聲明**：

此文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。儘管我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應將原始語言的文件視為權威來源。對於關鍵信息，建議進行專業的人工作翻譯。我們對於使用此翻譯所產生的任何誤解或錯誤解釋不承擔責任。