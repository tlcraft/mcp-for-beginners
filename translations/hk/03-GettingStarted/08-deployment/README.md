<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:50:22+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "hk"
}
-->
# 部署 MCP 伺服器

部署你的 MCP 伺服器可以讓其他人超越你的本地環境，存取其工具和資源。根據你的可擴展性、可靠性和管理便利性需求，有幾種部署策略可以考慮。以下是本地、容器和雲端部署 MCP 伺服器的指導。

## 概述

這一課講述如何部署你的 MCP 伺服器應用程式。

## 學習目標

完成這一課後，你將能夠：

- 評估不同的部署方法。
- 部署你的應用程式。

## 本地開發和部署

如果你的伺服器是為在用戶的機器上運行而設計的，你可以遵循以下步驟：

1. **下載伺服器**。如果你沒有編寫伺服器，首先下載到你的機器。
1. **啟動伺服器進程**：運行你的 MCP 伺服器應用程式

對於 SSE（標準輸入輸出類型伺服器不需要）

1. **配置網絡**：確保伺服器在預期的端口上可訪問
1. **連接客戶端**：使用像 `http://localhost:3000` 的本地連接 URL

## 雲端部署

MCP 伺服器可以部署到各種雲端平台：

- **無伺服器函數**：將輕量級 MCP 伺服器部署為無伺服器函數
- **容器服務**：使用像 Azure Container Apps、AWS ECS 或 Google Cloud Run 的服務
- **Kubernetes**：在 Kubernetes 集群中部署和管理 MCP 伺服器以獲得高可用性

### 範例：Azure Container Apps

Azure Container Apps 支援 MCP 伺服器的部署。目前還在進行中，並且目前支持 SSE 伺服器。

以下是你可以採取的步驟：

1. 克隆一個 repo：

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. 本地運行以測試：

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. 要在本地嘗試，請在 *.vscode* 目錄中創建一個 *mcp.json* 文件，並添加以下內容：

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

  當 SSE 伺服器啟動後，你可以在 JSON 文件中點擊播放圖標，現在應該能看到伺服器上的工具被 GitHub Copilot 接收到，看到工具圖標。

1. 要部署，運行以下命令：

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

就是這樣，本地部署，通過這些步驟部署到 Azure。

## 其他資源

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps 文章](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## 下一步

- 下一步：[實際應用](/04-PracticalImplementation/README.md)

**免責聲明**：
本文檔已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。儘管我們努力確保準確性，但請注意，自動翻譯可能會包含錯誤或不準確之處。原始語言的文檔應被視為權威來源。對於關鍵信息，建議使用專業的人類翻譯。我們不對因使用此翻譯而產生的任何誤解或誤釋承擔責任。