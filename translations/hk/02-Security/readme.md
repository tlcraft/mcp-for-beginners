<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:14:20+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "hk"
}
-->
# 保安最佳實踐

採用模型上下文協議（MCP）為人工智能驅動的應用程式帶來了強大的新功能，但也引入了超越傳統軟件風險的獨特安全挑戰。除了已經建立的關注點，如安全編碼、最小特權和供應鏈安全之外，MCP 和人工智能工作負載還面臨著新的威脅，如提示注入、工具中毒和動態工具修改。如果管理不當，這些風險可能導致數據外洩、隱私洩露和系統行為不當。

本課程探討了與 MCP 相關的最相關的安全風險，包括身份驗證、授權、過多權限、間接提示注入和供應鏈漏洞，並提供可操作的控制措施和最佳實踐來減輕這些風險。您還將學習如何利用 Microsoft 解決方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security 來加強您的 MCP 實施。通過理解和應用這些控制措施，您可以顯著降低安全漏洞的可能性，並確保您的人工智能系統保持穩健和值得信賴。

# 學習目標

在本課程結束時，您將能夠：

- 識別和解釋模型上下文協議（MCP）引入的獨特安全風險，包括提示注入、工具中毒、過多權限和供應鏈漏洞。
- 描述並應用有效的 MCP 安全風險緩解控制措施，如強健的身份驗證、最小特權、安全令牌管理和供應鏈驗證。
- 理解和利用 Microsoft 解決方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security，來保護 MCP 和人工智能工作負載。
- 認識到驗證工具元數據、監控動態變化和防禦間接提示注入攻擊的重要性。
- 將已建立的安全最佳實踐，如安全編碼、服務器硬化和零信任架構，集成到您的 MCP 實施中，以減少安全漏洞的可能性和影響。

# MCP 安全控制

任何訪問重要資源的系統都隱含著安全挑戰。安全挑戰通常可以通過正確應用基本的安全控制和概念來解決。由於 MCP 只是新定義的，其規範正在迅速變化，並且隨著協議的演變而變化。最終，內部的安全控制將成熟，使其能夠更好地與企業和已建立的安全架構和最佳實踐集成。

根據 [Microsoft Digital Defense Report](https://aka.ms/mddr) 發佈的研究，98% 的報告漏洞可以通過強健的安全衛生預防，並且防止任何類型漏洞的最佳保護措施是做好基線安全衛生、安全編碼最佳實踐和供應鏈安全——那些已經知道的經過試驗和測試的做法仍然對減少安全風險有最大的影響。

讓我們來看看在採用 MCP 時，您可以開始解決安全風險的一些方法。

# MCP 服務器身份驗證（如果您的 MCP 實施在 2025 年 4 月 26 日之前）

> **注意：** 以下信息截至 2025 年 4 月 26 日是正確的。MCP 協議不斷演變，未來的實施可能會引入新的身份驗證模式和控制措施。欲了解最新更新和指導，請始終參考 [MCP Specification](https://spec.modelcontextprotocol.io/) 和官方 [MCP GitHub repository](https://github.com/modelcontextprotocol)。

### 問題陳述 
最初的 MCP 規範假定開發人員會編寫自己的身份驗證服務器。這需要了解 OAuth 和相關的安全約束。MCP 服務器作為 OAuth 2.0 授權服務器，直接管理所需的用戶身份驗證，而不是將其委託給外部服務，如 Microsoft Entra ID。截至 2025 年 4 月 26 日，MCP 規範的更新允許 MCP 服務器將用戶身份驗證委託給外部服務。

### 風險
- MCP 服務器中配置錯誤的授權邏輯可能導致敏感數據暴露和不正確的訪問控制應用。
- 本地 MCP 服務器上的 OAuth 令牌被盜。如果被盜，令牌可以用於冒充 MCP 服務器並訪問令牌所屬服務的資源和數據。

### 緩解控制
- **審查和加強授權邏輯：** 仔細審核您的 MCP 服務器的授權實施，以確保只有預期的用戶和客戶端可以訪問敏感資源。實用指南，請參見 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 和 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **強制執行安全令牌實踐：** 遵循 [Microsoft 的令牌驗證和壽命的最佳實踐](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，以防止訪問令牌的濫用，並減少令牌重放或盜竊的風險。
- **保護令牌存儲：** 始終安全地存儲令牌，並使用加密來保護其在靜止和傳輸中的安全性。欲了解實施提示，請參見 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# MCP 服務器的過多權限

### 問題陳述
MCP 服務器可能被授予了對其訪問的服務/資源的過多權限。例如，一個作為人工智能銷售應用程式一部分的 MCP 服務器連接到企業數據存儲，應該將訪問範圍限制在銷售數據，而不允許訪問存儲中的所有文件。參考最小特權原則（最古老的安全原則之一），任何資源都不應擁有超過其執行預期任務所需的權限。人工智能在這方面提出了更大的挑戰，因為要使其靈活，可能難以確定所需的確切權限。

### 風險 
- 授予過多權限可能允許 MCP 服務器訪問或修改其不應能夠訪問的數據。如果數據是個人身份信息（PII），這也可能成為隱私問題。

### 緩解控制
- **應用最小特權原則：** 僅授予 MCP 服務器執行其所需任務所需的最低權限。定期審查和更新這些權限，以確保它們不超過所需的範圍。詳細指南，請參見 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **使用基於角色的訪問控制（RBAC）：** 為 MCP 服務器分配角色，這些角色緊密範圍於特定資源和操作，避免廣泛或不必要的權限。
- **監控和審計權限：** 持續監控權限使用情況，並審計訪問日誌，以便及時檢測和糾正過多或未使用的權限。

# 間接提示注入攻擊

### 問題陳述

惡意或受損的 MCP 服務器可能通過暴露客戶數據或啟用非預期操作引入重大風險。這些風險在基於人工智能和 MCP 的工作負載中特別相關，其中：

- **提示注入攻擊**：攻擊者將惡意指令嵌入提示或外部內容中，導致人工智能系統執行非預期操作或洩露敏感數據。了解更多：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **工具中毒**：攻擊者操縱工具元數據（如描述或參數）以影響人工智能的行為，可能繞過安全控制或洩露數據。詳情：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **跨域提示注入**：惡意指令嵌入在文檔、網頁或電子郵件中，然後由人工智能處理，導致數據洩露或操縱。
- **動態工具修改（地毯拉動）**：工具定義可以在用戶批准後更改，引入新的惡意行為而不被用戶察覺。

這些漏洞強調了在將 MCP 服務器和工具集成到您的環境中時需要強健的驗證、監控和安全控制。欲深入了解，請參見上面鏈接的參考資料。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.hk.png)

**間接提示注入**（也稱為跨域提示注入或 XPIA）是生成性人工智能系統中的一個關鍵漏洞，包括使用模型上下文協議（MCP）的系統。在此攻擊中，惡意指令隱藏在外部內容中，例如文檔、網頁或電子郵件中。當人工智能系統處理這些內容時，它可能將嵌入的指令解釋為合法的用戶命令，導致非預期行為，如數據洩露、生成有害內容或操縱用戶交互。欲了解詳細解釋和現實世界的例子，請參見 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)。

此攻擊的一種特別危險的形式是 **工具中毒**。在這裡，攻擊者將惡意指令注入 MCP 工具的元數據中（如工具描述或參數）。由於大型語言模型（LLMs）依賴於這些元數據來決定調用哪些工具，受損的描述可以欺騙模型執行未授權的工具調用或繞過安全控制。這些操縱對最終用戶通常是不可見的，但可以被人工智能系統解釋並執行。在托管的 MCP 服務器環境中，這種風險加劇，其中工具定義可以在用戶批准後更新——有時稱為“[地毯拉動](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)”。在這種情況下，先前安全的工具可能會被修改以執行惡意行為，如數據外洩或改變系統行為，而不被用戶知曉。欲了解更多關於此攻擊向量的信息，請參見 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.hk.png)

## 風險
非預期的人工智能行為帶來多種安全風險，包括數據外洩和隱私洩露。

### 緩解控制
### 使用提示盾牌保護免受間接提示注入攻擊
-----------------------------------------------------------------------------

**AI 提示盾牌** 是由 Microsoft 開發的解決方案，用於防禦直接和間接提示注入攻擊。它們通過以下方式提供幫助：

1.  **檢測和過濾**：提示盾牌使用先進的機器學習算法和自然語言處理來檢測和過濾嵌入在外部內容（如文檔、網頁或電子郵件）中的惡意指令。
    
2.  **聚光燈**：這種技術幫助人工智能系統區分有效的系統指令和潛在的不可信外部輸入。通過以更相關於模型的方式轉換輸入文本，聚光燈確保人工智能能夠更好地識別和忽略惡意指令。
    
3.  **分隔符和數據標記**：在系統消息中包含分隔符明確指出輸入文本的位置，幫助人工智能系統識別和分隔用戶輸入和潛在的有害外部內容。數據標記通過使用特殊標記來突出顯示可信和不可信數據的邊界來擴展此概念。
    
4.  **持續監控和更新**：Microsoft 持續監控和更新提示盾牌，以應對新出現的威脅。這種積極的方式確保防禦措施對最新的攻擊技術保持有效。
    
5. **與 Azure Content Safety 集成：** 提示盾牌是更廣泛的 Azure AI Content Safety 套件的一部分，該套件提供額外的工具，用於檢測越獄嘗試、有害內容和人工智能應用中的其他安全風險。

您可以在 [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection) 中閱讀更多關於 AI 提示盾牌的信息。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.hk.png)

### 供應鏈安全

供應鏈安全在人工智能時代仍然是基本的，但構成您供應鏈的範圍已經擴大。除了傳統的代碼包，您現在必須嚴格驗證和監控所有與人工智能相關的組件，包括基礎模型、嵌入服務、上下文提供者和第三方 API。如果管理不當，每一個都可能引入漏洞或風險。

**人工智能和 MCP 的關鍵供應鏈安全實踐：**
- **在集成之前驗證所有組件：** 這不僅包括開源庫，還包括人工智能模型、數據源和外部 API。始終檢查來源、許可和已知漏洞。
- **保持安全的部署管道：** 使用集成安全掃描的自動 CI/CD 管道，以便早期發現問題。確保只有受信任的工件被部署到生產環境。
- **持續監控和審計：** 對所有依賴項進行持續監控，包括模型和數據服務，以檢測新漏洞或供應鏈攻擊。
- **應用最小特權和訪問控制：** 限制對模型、數據和服務的訪問僅限於 MCP 服務器運行所需的內容。
- **迅速應對威脅：** 制定補丁或替換受損組件的流程，並在檢測到漏洞時輪換密鑰或憑證。

[GitHub Advanced Security](https://github.com/security/advanced-security) 提供秘密掃描、依賴項掃描和 CodeQL 分析等功能。這些工具與 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 和 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 集成，幫助團隊識別和緩解代碼和人工智能供應鏈組件中的漏洞。

Microsoft 還在內部為所有產品實施廣泛的供應鏈安全實踐。了解更多信息，請參見 [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。

# 提升 MCP 實施安全態勢的已建立安全最佳實踐

任何 MCP 實施都會繼承其所建環境的現有安全態勢，因此在考慮 MCP 作為整體人工智能系統的組件的安全性時，建議您提升整體現有的安全態勢。以下已建立的安全控制尤其相關：

-   您的人工智能應用中的安全編碼最佳實踐 - 保護免受 [OWASP Top 10](https://owasp.org/www-project-top-ten/)、[OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559) 的攻擊，使用安全保險庫存儲密鑰和令牌，在所有應用組件之間實施端到端安全通信等。
-   服務器硬化 - 盡可能使用 MFA，保持補丁更新，將服務器與第三方身份提供者集成以獲得訪問等。
-   保持設備、基礎設施和應用程式的補丁更新
-   安全監控 - 實施人工智能應用（包括 MCP 客戶端/服務器）的日誌記錄和監控，並將這些日誌發送到中央 SIEM 以檢測異常活動
-   零信任
- [OWASP LLMs 十大安全漏洞](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub 高级安全](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [微软软件供应链安全之旅](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [安全最小权限访问（微软）](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [令牌验证和生命周期的最佳实践](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [使用安全令牌存储和加密令牌（YouTube）](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API 管理作为 MCP 的认证网关](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [使用 Microsoft Entra ID 进行 MCP 服务器认证](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 下一步

下一步：[第三章：入门指南](/03-GettingStarted/README.md)

**免責聲明**：
本文件是使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯的。儘管我們力求準確，但請注意，自動翻譯可能會包含錯誤或不準確之處。應將原文文件視為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們對於因使用此翻譯而產生的任何誤解或誤釋不承擔責任。