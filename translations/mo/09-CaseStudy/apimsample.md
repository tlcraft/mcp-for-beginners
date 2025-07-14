<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:26:49+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "mo"
}
-->
# 案例研究：在 API Management 中將 REST API 作為 MCP 伺服器公開

Azure API Management 是一項服務，提供您 API 端點之上的閘道功能。其運作方式是 Azure API Management 作為您 API 前端的代理，能夠決定如何處理進來的請求。

透過使用它，您可以獲得一系列功能，例如：

- **安全性**，您可以使用從 API 金鑰、JWT 到受管理身份的各種驗證方式。
- **速率限制**，一個很棒的功能是能夠決定在特定時間單位內允許多少呼叫通過。這有助於確保所有使用者都有良好的體驗，同時避免您的服務被過多請求淹沒。
- **擴展與負載平衡**。您可以設定多個端點來分散負載，並且可以決定如何進行「負載平衡」。
- **AI 功能，如語意快取**、令牌限制與令牌監控等。這些功能能提升回應速度，並幫助您掌握令牌使用狀況。[在此閱讀更多](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities)。

## 為什麼選擇 MCP + Azure API Management？

Model Context Protocol 正快速成為代理 AI 應用程式的標準，並以一致的方式公開工具與資料。當您需要「管理」API 時，Azure API Management 是自然的選擇。MCP 伺服器通常會整合其他 API 來解決工具的請求，因此結合 Azure API Management 與 MCP 非常合理。

## 概覽

在這個特定案例中，我們將學習如何將 API 端點公開為 MCP 伺服器。透過這樣做，我們可以輕鬆地將這些端點納入代理應用程式，同時利用 Azure API Management 的功能。

## 主要功能

- 您可以選擇想要公開為工具的端點方法。
- 額外功能取決於您在 API 的政策區段中設定的內容，但這裡我們將示範如何新增速率限制。

## 前置步驟：匯入 API

如果您已經在 Azure API Management 中有 API，太好了，可以跳過此步驟。若沒有，請參考此連結，[匯入 API 至 Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api)。

## 將 API 公開為 MCP 伺服器

要公開 API 端點，請依照以下步驟：

1. 前往 Azure 入口網站，並開啟此網址 <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   進入您的 API Management 實例。

1. 在左側選單中，選擇 APIs > MCP Servers > + 建立新的 MCP Server。

1. 在 API 中，選擇要公開為 MCP 伺服器的 REST API。

1. 選擇一個或多個 API 操作公開為工具。您可以選擇全部操作或僅特定操作。

    ![選擇要公開的方法](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. 選擇 **建立**。

1. 前往選單中的 **APIs** 和 **MCP Servers**，您應該會看到以下畫面：

    ![在主視窗中看到 MCP Server](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP 伺服器已建立，API 操作已公開為工具。MCP 伺服器會列在 MCP Servers 面板中。URL 欄位顯示 MCP 伺服器的端點，您可以用來測試或在客戶端應用程式中呼叫。

## 選用：設定政策

Azure API Management 的核心概念是政策，您可以為端點設定不同規則，例如速率限制或語意快取。這些政策是以 XML 撰寫。

以下示範如何設定政策來限制 MCP 伺服器的速率：

1. 在入口網站中，於 APIs 下選擇 **MCP Servers**。

1. 選擇您建立的 MCP 伺服器。

1. 在左側選單中，於 MCP 下選擇 **Policies**。

1. 在政策編輯器中，新增或編輯您想套用於 MCP 伺服器工具的政策。政策以 XML 格式定義。例如，您可以新增一個政策限制 MCP 伺服器工具的呼叫次數（此範例為每個客戶端 IP 位址每 30 秒最多 5 次呼叫）。以下是會啟用速率限制的 XML：

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    以下是政策編輯器的畫面：

    ![政策編輯器](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## 試用

讓我們確保 MCP 伺服器運作正常。

為此，我們將使用 Visual Studio Code 與 GitHub Copilot 的代理模式。我們會將 MCP 伺服器加入 *mcp.json*。如此一來，Visual Studio Code 將作為具代理能力的客戶端，最終使用者可以輸入提示並與該伺服器互動。

以下示範如何在 Visual Studio Code 中新增 MCP 伺服器：

1. 使用命令面板中的 MCP: **Add Server 指令**。

1. 出現提示時，選擇伺服器類型：**HTTP (HTTP 或 Server Sent Events)**。

1. 輸入 API Management 中 MCP 伺服器的 URL。例如：**https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse**（SSE 端點）或 **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp**（MCP 端點），注意兩者的傳輸差異在於 `/sse` 或 `/mcp`。

1. 輸入您選擇的伺服器 ID。這不是重要值，但有助於您記住此伺服器實例。

1. 選擇將設定儲存到工作區設定或使用者設定。

  - **工作區設定** - 伺服器設定會儲存到當前工作區專屬的 .vscode/mcp.json 檔案。

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    若您選擇使用串流 HTTP 作為傳輸，設定會略有不同：

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **使用者設定** - 伺服器設定會加入全域 *settings.json* 檔案，並在所有工作區可用。設定格式類似以下：

    ![使用者設定](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. 您還需要新增設定，加入標頭以確保能正確驗證 Azure API Management。它使用名為 **Ocp-Apim-Subscription-Key** 的標頭。

    - 以下示範如何將其加入設定：

    ![新增驗證標頭](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)，系統會提示您輸入 API 金鑰值，該值可在 Azure 入口網站的 Azure API Management 實例中找到。

   - 若要將其加入 *mcp.json*，可如下新增：

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### 使用代理模式

現在我們已在設定或 *.vscode/mcp.json* 中完成設定，讓我們試用看看。

應該會看到一個工具圖示，列出您伺服器公開的工具：

![伺服器工具](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. 點擊工具圖示，您會看到工具清單如下：

    ![工具清單](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. 在聊天中輸入提示以呼叫工具。例如，若您選擇了一個用於查詢訂單資訊的工具，可以向代理詢問訂單。以下是範例提示：

    ```text
    get information from order 2
    ```

    接著會出現工具圖示，提示您是否繼續呼叫工具。選擇繼續執行工具後，您應該會看到類似以下的輸出：

    ![提示結果](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **以上畫面會依您設定的工具而異，但概念是您會得到類似的文字回應。**


## 參考資料

以下是您可以深入了解的資源：

- [Azure API Management 與 MCP 教學](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python 範例：使用 Azure API Management 保護遠端 MCP 伺服器（實驗性）](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP 用戶端授權實驗室](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [使用 Azure API Management 擴充功能於 VS Code 匯入與管理 API](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [在 Azure API Center 註冊與發現遠端 MCP 伺服器](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) 很棒的資源庫，展示許多 Azure API Management 的 AI 功能
- [AI Gateway 工作坊](https://azure-samples.github.io/AI-Gateway/) 包含使用 Azure 入口網站的工作坊，是開始評估 AI 功能的好方法。

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤釋負責。