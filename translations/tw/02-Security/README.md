<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:05:56+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "tw"
}
-->
# Security Best Practices

採用 Model Context Protocol (MCP) 為 AI 驅動的應用帶來強大的新功能，但也引入了超越傳統軟體風險的獨特安全挑戰。除了既有的安全編碼、最小權限及供應鏈安全等議題外，MCP 和 AI 工作負載還面臨新的威脅，例如 prompt injection、工具中毒及動態工具修改。如果未妥善管理，這些風險可能導致資料外洩、隱私違規及系統行為異常。

本課程探討與 MCP 相關的主要安全風險，包括身份驗證、授權、過度權限、間接 prompt injection 及供應鏈漏洞，並提供可執行的控管措施與最佳實務。您也將學習如何運用 Microsoft 的解決方案，如 Prompt Shields、Azure Content Safety 及 GitHub Advanced Security，強化 MCP 的實作。透過理解並應用這些控管，能大幅降低安全事件發生的機率，確保 AI 系統穩健且值得信賴。

# Learning Objectives

完成本課程後，您將能：

- 辨識並說明 Model Context Protocol (MCP) 所帶來的獨特安全風險，包括 prompt injection、工具中毒、過度權限及供應鏈漏洞。
- 描述並運用有效的緩解控管，如強健的身份驗證、最小權限、安全的令牌管理及供應鏈驗證。
- 了解並善用 Microsoft 解決方案，如 Prompt Shields、Azure Content Safety 和 GitHub Advanced Security，保護 MCP 及 AI 工作負載。
- 認識驗證工具元資料、監控動態變更及防禦間接 prompt injection 攻擊的重要性。
- 將既有安全最佳實務（如安全編碼、伺服器強化及零信任架構）整合到 MCP 實作中，降低安全事件的發生率及影響。

# MCP security controls

任何能存取重要資源的系統，都存在隱含的安全挑戰。這些挑戰通常可透過正確應用基本的安全控管與概念來解決。由於 MCP 是新定義的協定，規範正快速演進，未來其安全控管將逐步成熟，更能與企業及既有的安全架構和最佳實務整合。

根據[Microsoft Digital Defense Report](https://aka.ms/mddr)的研究指出，98% 的報告違規事件可藉由強健的安全衛生習慣防止，而防範任何違規的最佳方法，就是做好基礎的安全衛生、確實的安全編碼與供應鏈安全——這些經過驗證的做法仍是降低風險的關鍵。

接下來我們來看看採用 MCP 時，可以開始如何因應安全風險。

> **Note:** 以下資訊截至 **2025 年 5 月 29 日** 為準。MCP 協定持續演進，未來實作可能會引入新的身份驗證模式與控管。最新更新與指引請參考 [MCP Specification](https://spec.modelcontextprotocol.io/)、官方 [MCP GitHub repository](https://github.com/modelcontextprotocol) 及 [security best practice page](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)。

### Problem statement  
原始 MCP 規範假設開發者會自行撰寫身份驗證伺服器，這需要 OAuth 及相關安全限制的知識。MCP 伺服器作為 OAuth 2.0 授權伺服器，直接管理使用者身份驗證，而非委派給外部服務（如 Microsoft Entra ID）。自 **2025 年 4 月 26 日** 起，MCP 規範更新允許 MCP 伺服器將使用者身份驗證委派給外部服務。

### Risks
- MCP 伺服器中授權邏輯錯誤配置可能導致敏感資料曝光及存取控管錯誤。
- 本地 MCP 伺服器的 OAuth 令牌被竊取，攻擊者可利用該令牌冒充 MCP 伺服器，存取令牌所代表服務的資源與資料。

#### Token Passthrough
在授權規範中明確禁止令牌直通，因為它帶來多種安全風險，包括：

#### Security Control Circumvention
MCP 伺服器或下游 API 可能實施重要安全控管，如速率限制、請求驗證或流量監控，這些控管依賴令牌的目標受眾或其他憑證限制。若客戶端能直接向下游 API 取得並使用令牌，而 MCP 伺服器未正確驗證或確保令牌是為該服務簽發，則繞過了這些控管。

#### Accountability and Audit Trail Issues
當客戶端以上游簽發的存取令牌呼叫時，MCP 伺服器無法辨識或區分不同的 MCP 用戶端。
下游資源伺服器的日誌可能顯示請求來自不同來源與身分，而非實際轉發令牌的 MCP 伺服器。
這兩項因素使事件調查、控管與稽核更加困難。
若 MCP 伺服器在未驗證令牌聲明（如角色、權限或目標受眾）或其他元資料的情況下轉發令牌，擁有被竊令牌的惡意者可利用伺服器作為資料外洩的代理。

#### Trust Boundary Issues
下游資源伺服器會對特定實體授予信任，這種信任可能包含來源或用戶行為模式的假設。破壞此信任邊界可能導致意料之外的問題。
若令牌被多個服務接受且未經適當驗證，攻擊者若入侵其中一服務，即可利用該令牌存取其他連接的服務。

#### Future Compatibility Risk
即使 MCP 伺服器目前作為「純代理」，未來可能需要新增安全控管。從一開始就適當分隔令牌目標受眾，有助於安全模型的演進。

### Mitigating controls

**MCP 伺服器不得接受非明確簽發給 MCP 伺服器的任何令牌**

- **檢視並強化授權邏輯：** 仔細審核 MCP 伺服器的授權實作，確保只有預期的使用者與用戶端能存取敏感資源。實務指引請參考 [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) 及 [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/)。
- **強制安全的令牌使用：** 遵循 [Microsoft 令牌驗證與生命週期最佳實務](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens)，防止存取令牌濫用，降低令牌重放或竊取風險。
- **保護令牌儲存：** 始終安全儲存令牌，並使用加密保障靜態與傳輸中的安全。實作技巧可參考 [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)。

# Excessive permissions for MCP servers

### Problem statement
MCP 伺服器可能被授予過度的權限來存取其目標服務或資源。例如，AI 銷售應用中的 MCP 伺服器應僅能存取銷售資料，而非整個企業資料庫的所有檔案。回歸最小權限原則（最古老的安全原則之一），任何資源的權限不應超過執行其預定任務所需。AI 在這方面挑戰更大，因為為了靈活性，準確定義所需權限較困難。

### Risks  
- 過度授權可能導致資料外洩或未經授權的資料修改。若資料包含個人識別資訊（PII），也會衍生隱私問題。

### Mitigating controls
- **應用最小權限原則：** 僅授予 MCP 伺服器執行任務所需的最少權限，並定期檢視與更新，確保不超出必要範圍。詳細指引請見 [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)。
- **使用角色基礎存取控制 (RBAC)：** 指派緊密限定於特定資源與動作的角色給 MCP 伺服器，避免過寬或不必要的權限。
- **監控與稽核權限：** 持續監控權限使用情況，並審核存取日誌，及時偵測並修正過度或未使用的權限。

# Indirect prompt injection attacks

### Problem statement

惡意或被入侵的 MCP 伺服器可能導致重大風險，包含暴露客戶資料或觸發未預期行為。此類風險在 AI 與 MCP 工作負載中尤其重要，涵蓋：

- **Prompt Injection 攻擊：** 攻擊者將惡意指令嵌入 prompt 或外部內容，導致 AI 系統執行未預期動作或洩漏敏感資料。詳見：[Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **工具中毒：** 攻擊者操控工具元資料（如描述或參數），影響 AI 行為，可能繞過安全控管或外洩資料。詳情：[Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **跨領域 Prompt Injection：** 惡意指令藏於文件、網頁或電子郵件中，AI 處理時導致資料外洩或操控。
- **動態工具修改（Rug Pulls）：** 工具定義可在使用者同意後被變更，導入新的惡意行為而不被察覺。

這些漏洞凸顯了在環境中整合 MCP 伺服器與工具時，需強化驗證、監控與安全控管。詳細內容請參考上述連結。

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.tw.png)

**間接 Prompt Injection**（亦稱跨領域 prompt injection 或 XPIA）是生成式 AI 系統中的重大漏洞，包含使用 MCP 的系統。此攻擊手法將惡意指令隱藏於外部內容（文件、網頁或郵件）中，當 AI 系統處理這些內容時，可能將隱藏指令誤認為合法用戶命令，導致未預期的行為，如資料外洩、產生有害內容或操控用戶互動。詳細解說及實例，請參考 [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)。

其中一種特別危險的攻擊是 **工具中毒**。攻擊者將惡意指令注入 MCP 工具的元資料（如工具描述或參數），而大型語言模型（LLM）依賴這些元資料決定調用哪些工具。被操控的描述會誤導模型執行未授權的工具呼叫或繞過安全控管。這類操作通常對終端用戶隱形，但 AI 系統會解讀並執行。此風險在託管 MCP 伺服器環境更高，因為工具定義可在用戶同意後更新，這種情況有時稱為「[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)」。先前安全的工具後續可能被改為執行惡意行為，如資料外洩或系統行為改變，而用戶不知情。更多攻擊向量資訊，請參考 [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)。

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.tw.png)

## Risks
AI 未預期行為帶來多種安全風險，包括資料外洩與隱私違規。

### Mitigating controls
### 使用 Prompt Shields 防範間接 Prompt Injection 攻擊
-----------------------------------------------------------------------------

**AI Prompt Shields** 是 Microsoft 開發的解決方案，用以防禦直接及間接的 prompt injection 攻擊。其功能包括：

1.  **偵測與過濾：** Prompt Shields 運用先進的機器學習演算法與自然語言處理技術，偵測並過濾外部內容（如文件、網頁或郵件）中嵌入的惡意指令。
    
2.  **聚焦技術（Spotlighting）：** 幫助 AI 系統區分有效的系統指令與可能不可信的外部輸入。透過轉換輸入文字，使其更貼近模型需求，確保 AI 能更精確識別並忽略惡意指令。
    
3.  **分隔符與資料標記（Delimiters and Datamarking）：** 在系統訊息中加入分隔符，明確標示輸入文字位置，協助 AI 系統辨識並區隔用戶輸入與潛在有害的外部內容。資料標記則利用特殊標記強調可信與不可信資料的邊界。
    
4.  **持續監控與更新：** Microsoft 持續監控並更新 Prompt Shields，以因應新興與演變的威脅，確保防禦措施有效。
    
5. **整合 Azure Content Safety：** Prompt Shields 是 Azure AI Content Safety 套件的一部分，該套件提供偵測越獄嘗試、有害內容及其他 AI 安全風險的額外工具。

更多關於 AI prompt shields 的資訊，請參考 [Prompt Shields documentation](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)。

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.tw.png)

### Supply chain security

供應鏈安全在 AI 時代依然是基礎，但供應鏈範圍已擴大。除了傳統的程式碼套件外，現在必須嚴格驗證與監控所有 AI 相關組件，包括基礎模型、embedding 服務、上下文提供者與第三方 API。若未妥善管理，每一項都可能引入漏洞或風險。

**AI 與 MCP 的主要供應鏈安全做法：**
- **整合前驗證所有組件：** 不僅限於開源函式庫，還包含 AI 模型、資料來源與外部 API。務必確認來源、授權與已知漏洞。
- **維護安全的部署流程：** 使用自動化 CI/CD 管線並結合安全掃描，及早發現問題。確保僅信任的產物部署到生產環境。
- **持續監控與稽核：** 對所有依賴項（含模型與資料服務）實施持續監控，偵測新漏洞或供應鏈攻擊。
- **應用最小權限與存取控管：** 僅授權 MCP 伺服器執行所需的模型、資料與服務存取。
- **迅速回應威脅：** 建立流程以修補或替換受損組件，若偵測違規則旋轉機密或憑證。

[GitHub Advanced Security](https://github.com/security/advanced-security) 提供秘密掃描、依賴掃描與 CodeQL 分析等功能，並可與 [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) 及 [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) 整合，協助團隊識別並緩解程式碼及 AI 供應鏈的漏洞。

Microsoft 也在內部產品中實施廣泛的供應鏈安全措施。詳見 [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)。

# Established security best practices that will uplift your MCP implementation's security posture

任何 MCP 實作都會繼承其所建構的組織環境既有安全態勢，因此在評估 MCP 的安全性時，建議提升整體安全態勢。以下既有安全控管尤其相關：

- AI 應用中的安全編碼最佳實務——防範 [OWASP Top 10](https://owasp.org/www-project-top-ten/)、[OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [微軟軟體供應鏈安全之旅](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [安全的最小權限存取 (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Token 驗證與有效期限最佳實踐](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [使用安全的 Token 儲存與加密 Token（YouTube）](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API 管理作為 MCP 的身份驗證閘道](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP 安全最佳實踐](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [使用 Microsoft Entra ID 進行 MCP 伺服器身份驗證](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### 下一步

下一步: [第 3 章：快速上手](/03-GettingStarted/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們力求準確，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。本公司不對因使用此翻譯所引起之任何誤解或誤譯負責。