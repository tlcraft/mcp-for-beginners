<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-12T22:10:53+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "hk"
}
-->
# 部署 MCP 伺服器

部署你的 MCP 伺服器可以讓其他人喺你嘅本地環境之外使用佢嘅工具同資源。根據你對擴展性、可靠性同管理便利性嘅需求，有幾種部署策略可以考慮。以下會介紹喺本地、容器同雲端部署 MCP 伺服器嘅指引。

## 概覽

本課會教你點樣部署你嘅 MCP Server 應用程式。

## 學習目標

完成本課後，你將能夠：

- 評估唔同嘅部署方法。
- 部署你嘅應用程式。

## 本地開發同部署

如果你嘅伺服器係打算喺用戶機器上運行，咁可以跟住以下步驟：

1. **下載伺服器**。如果你冇寫呢個伺服器，先下載佢到你嘅機器。  
1. **啟動伺服器程序**：運行你嘅 MCP server 應用程式。

對 SSE（唔需要 stdio 類型伺服器）

1. **配置網絡**：確保伺服器喺預期嘅端口可以被訪問。  
1. **連接客戶端**：使用本地連接 URL，好似 `http://localhost:3000`。

## 雲端部署

MCP 伺服器可以部署到唔同嘅雲端平台：

- **無伺服器函數**：將輕量級 MCP 伺服器部署為無伺服器函數。  
- **容器服務**：使用 Azure Container Apps、AWS ECS 或 Google Cloud Run 等服務。  
- **Kubernetes**：喺 Kubernetes 叢集部署同管理 MCP 伺服器，實現高可用性。

### 範例：Azure Container Apps

Azure Container Apps 支援部署 MCP 伺服器。呢個功能仍然喺開發中，目前只支援 SSE 伺服器。

你可以咁做：

1. 克隆一個 repo：

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. 喺本地運行測試：

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. 想喺本地試用，喺 *.vscode* 目錄建立一個 *mcp.json* 文件，並加入以下內容：

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  一旦 SSE 伺服器啟動，你可以喺 JSON 文件點擊播放圖標，GitHub Copilot 就會識別到伺服器上嘅工具，睇下 Tool 圖標。

1. 要部署，執行以下命令：

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

就係咁，跟住呢啲步驟就可以本地部署，或者部署到 Azure。

## 額外資源

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps 文章](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## 下一步

- 下一課：[Practical Implementation](/04-PracticalImplementation/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。因使用本翻譯所引起嘅任何誤解或誤釋，我哋概不負責。