<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:50:32+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "tw"
}
-->
# 部署 MCP 伺服器

部署您的 MCP 伺服器可以讓其他人訪問其工具和資源，而不僅限於本地環境。根據擴展性、可靠性和管理便利性需求，有多種部署策略可供考慮。以下是有關在本地、容器中和雲端部署 MCP 伺服器的指導。

## 概述

本課程涵蓋如何部署您的 MCP 伺服器應用程式。

## 學習目標

在本課程結束時，您將能夠：

- 評估不同的部署方法。
- 部署您的應用程式。

## 本地開發和部署

如果您的伺服器旨在用戶機器上運行，可以按照以下步驟進行：

1. **下載伺服器**。如果您不是伺服器的編寫者，首先將其下載到您的機器上。
1. **啟動伺服器進程**：運行您的 MCP 伺服器應用程式

針對 SSE（對於 stdio 類型伺服器不需要）

1. **配置網絡**：確保伺服器在預期的端口上可訪問
1. **連接客戶端**：使用本地連接 URL，如 `http://localhost:3000`

## 雲端部署

MCP 伺服器可以部署到各種雲端平台：

- **無伺服器函數**：將輕量級 MCP 伺服器部署為無伺服器函數
- **容器服務**：使用 Azure Container Apps、AWS ECS 或 Google Cloud Run 等服務
- **Kubernetes**：在 Kubernetes 集群中部署和管理 MCP 伺服器，以實現高可用性

### 範例：Azure Container Apps

Azure Container Apps 支援 MCP 伺服器的部署。這仍在進行中，目前支持 SSE 伺服器。

以下是如何進行：

1. 克隆倉庫：

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. 在本地運行以進行測試：

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. 要在本地嘗試，請在 *.vscode* 目錄中創建一個 *mcp.json* 文件並添加以下內容：

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

  一旦 SSE 伺服器啟動，您可以點擊 JSON 文件中的播放圖標，您現在應該可以看到 GitHub Copilot 採集伺服器上的工具，查看工具圖標。

1. 要部署，運行以下命令：

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

這樣就完成了，按照這些步驟在本地部署它，並將其部署到 Azure。

## 其他資源

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps 文章](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP 倉庫](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## 下一步

- 下一步：[實際應用](/04-PracticalImplementation/README.md)

**免責聲明**：
本文檔使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。儘管我們努力追求準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原始語言的文檔作為權威來源。對於關鍵信息，建議使用專業人工翻譯。對於因使用此翻譯而產生的任何誤解或誤譯，我們不承擔責任。