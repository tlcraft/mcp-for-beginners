<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-12T22:10:43+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "tw"
}
-->
# Deploying MCP Servers

部署你的 MCP 伺服器，讓其他人能在你本地環境之外存取它的工具和資源。根據你對擴展性、可靠性和管理便利性的需求，有多種部署策略可以考慮。以下會提供在本地、容器和雲端部署 MCP 伺服器的指引。

## Overview

本課程說明如何部署你的 MCP Server 應用程式。

## Learning Objectives

完成本課程後，你將能夠：

- 評估不同的部署方式。
- 部署你的應用程式。

## Local development and deployment

如果你的伺服器是要在使用者機器上運行供其使用，可以依照以下步驟：

1. **下載伺服器**。如果你沒有自己寫伺服器，先下載到你的電腦。
1. **啟動伺服器程序**：執行你的 MCP server 應用程式。

針對 SSE（stdio 型伺服器不需要）

1. **設定網路**：確保伺服器在預期的連接埠可存取。
1. **連線客戶端**：使用像 `http://localhost:3000` 這樣的本地連線 URL。

## Cloud Deployment

MCP 伺服器可以部署到多種雲端平台：

- **Serverless Functions**：將輕量級 MCP 伺服器部署成無伺服器函式。
- **Container Services**：使用像 Azure Container Apps、AWS ECS 或 Google Cloud Run 等服務。
- **Kubernetes**：在 Kubernetes 叢集部署並管理 MCP 伺服器，以達到高可用性。

### Example: Azure Container Apps

Azure Container Apps 支援部署 MCP Servers，目前仍在持續開發中，並且支援 SSE 伺服器。

以下是操作步驟：

1. Clone 一個 repo：

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. 在本地執行以測試：

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. 若要本地測試，在 *.vscode* 目錄下建立一個 *mcp.json* 檔案，並加入以下內容：

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

  SSE 伺服器啟動後，你可以點擊 JSON 檔案中的播放圖示，GitHub Copilot 就能偵測到伺服器上的工具，會看到工具圖示。

1. 要部署的話，執行以下指令：

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

這樣就完成了，按照這些步驟可以本地部署，也能部署到 Azure。

## Additional Resources

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps article](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)


## What's Next

- 下一步: [Practical Implementation](/04-PracticalImplementation/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件之母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生之任何誤解或誤釋負責。