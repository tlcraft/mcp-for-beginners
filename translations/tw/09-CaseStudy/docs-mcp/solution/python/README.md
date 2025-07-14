<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:37:49+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "tw"
}
-->
# 使用 Chainlit 與 Microsoft Learn Docs MCP 的學習計畫產生器

## 先決條件

- Python 3.8 或以上版本
- pip（Python 套件管理工具）
- 可連接 Microsoft Learn Docs MCP 伺服器的網路連線

## 安裝

1. 克隆此儲存庫或下載專案檔案。
2. 安裝所需的相依套件：

   ```bash
   pip install -r requirements.txt
   ```

## 使用說明

### 情境 1：簡單查詢 Docs MCP  
一個命令列客戶端，連接到 Docs MCP 伺服器，發送查詢並列印結果。

1. 執行腳本：  
   ```bash
   python scenario1.py
   ```  
2. 在提示符號輸入您的文件問題。

### 情境 2：學習計畫產生器（Chainlit 網頁應用）  
一個基於網頁的介面（使用 Chainlit），讓使用者能為任何技術主題產生個人化的週別學習計畫。

1. 啟動 Chainlit 應用：  
   ```bash
   chainlit run scenario2.py
   ```  
2. 在瀏覽器中開啟終端機提供的本地 URL（例如 http://localhost:8000）。  
3. 在聊天視窗輸入您的學習主題及想學習的週數（例如「AI-900 認證，8 週」）。  
4. 應用會回應一份週別學習計畫，並附上相關 Microsoft Learn 文件的連結。

**所需環境變數：**

要使用情境 2（搭配 Azure OpenAI 的 Chainlit 網頁應用），必須在 `python` 目錄下的 `.env` 檔案中設定以下環境變數：

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

請在執行應用前填入您的 Azure OpenAI 資源資訊。

> **Tip:** 您可以透過 [Azure AI Foundry](https://ai.azure.com/) 輕鬆部署自己的模型。

### 情境 3：在 VS Code 編輯器內使用 MCP 伺服器查詢文件

不必切換瀏覽器分頁搜尋文件，您可以直接在 VS Code 中使用 MCP 伺服器將 Microsoft Learn Docs 帶入編輯器。這讓您能夠：  
- 在 VS Code 內搜尋並閱讀文件，無需離開開發環境。  
- 直接引用文件並插入連結到 README 或課程檔案中。  
- 結合 GitHub Copilot 與 MCP，打造無縫的 AI 文件工作流程。

**範例使用情境：**  
- 撰寫課程或專案文件時，快速新增參考連結到 README。  
- 使用 Copilot 產生程式碼，同時用 MCP 即時查找並引用相關文件。  
- 保持專注於編輯器，提高工作效率。

> [!IMPORTANT]  
> 請確保您的工作區中有有效的 [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) 設定檔（位置為 `.vscode/mcp.json`）。

## 為什麼情境 2 選擇 Chainlit？

Chainlit 是一個現代化的開源框架，用於建立對話式網頁應用。它讓您輕鬆打造連接後端服務（如 Microsoft Learn Docs MCP 伺服器）的聊天介面。本專案利用 Chainlit 提供簡單且互動的方式，實時產生個人化學習計畫。透過 Chainlit，您可以快速建立並部署聊天工具，提升學習與工作效率。

## 這個應用的功能

此應用允許使用者只需輸入主題與學習時長，即可建立個人化學習計畫。應用會解析您的輸入，向 Microsoft Learn Docs MCP 伺服器查詢相關內容，並將結果整理成結構化的週別計畫。每週的建議會在聊天中顯示，方便追蹤與執行。整合確保您隨時獲得最新且最相關的學習資源。

## 範例查詢

在聊天視窗試試以下查詢，看看應用如何回應：

- `AI-900 certification, 8 weeks`  
- `Learn Azure Functions, 4 weeks`  
- `Azure DevOps, 6 weeks`  
- `Data engineering on Azure, 10 weeks`  
- `Microsoft security fundamentals, 5 weeks`  
- `Power Platform, 7 weeks`  
- `Azure AI services, 12 weeks`  
- `Cloud architecture, 9 weeks`

這些範例展示了應用在不同學習目標與時間範圍上的彈性。

## 參考資料

- [Chainlit Documentation](https://docs.chainlit.io/)  
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保翻譯的準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤譯負責。