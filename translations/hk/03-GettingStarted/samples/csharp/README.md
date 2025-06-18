<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:50:40+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "hk"
}
-->
# Basic Calculator MCP Service

此服務透過 Model Context Protocol (MCP) 提供基本計算器功能。它設計為一個簡單的範例，適合初學者了解 MCP 的實作方式。

欲了解更多資訊，請參閱 [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## 功能

此計算器服務具備以下功能：

1. **基本算術運算**：
   - 兩數相加
   - 一數減去另一數
   - 兩數相乘
   - 一數除以另一數（含除以零的檢查）

## 使用 `stdio` 類型

## 配置

1. **設定 MCP 伺服器**：
   - 在 VS Code 中開啟您的工作區。
   - 在工作區資料夾內建立 `.vscode/mcp.json` 檔案以設定 MCP 伺服器。範例配置如下：

     ```jsonc
     {
       "inputs": [
         {
           "type": "promptString",
           "id": "repository-root",
           "description": "The absolute path to the repository root"
         }
       ],
       "servers": {
         "calculator-mcp-dotnet": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
             "run",
             "--project",
             "${input:repository-root}/03-GettingStarted/samples/csharp/src/calculator.csproj"
           ]
         }
       }
     }
     ```

   - 系統會要求您輸入 GitHub 儲存庫根目錄，可透過指令 `git rev-parse --show-toplevel`.

## Using the Service

The service exposes the following API endpoints through the MCP protocol:

- `add(a, b)`: Add two numbers together
- `subtract(a, b)`: Subtract the second number from the first
- `multiply(a, b)`: Multiply two numbers
- `divide(a, b)`: Divide the first number by the second (with zero check)
- isPrime(n): Check if a number is prime

## Test with Github Copilot Chat in VS Code

1. Try making a request to the service using the MCP protocol. For example, you can ask:
   - "Add 5 and 3"
   - "Subtract 10 from 4"
   - "Multiply 6 and 7"
   - "Divide 8 by 2"
   - "Does 37854 prime?"
   - "What are the 3 prime numbers before after 4242?"
2. To make sure it's using the tools add #MyCalculator to the prompt. For example:
   - "Add 5 and 3 #MyCalculator"
   - "Subtract 10 from 4 #MyCalculator


## Containerized Version

The previous soultion is great when you have the .NET SDK installed, and all the dependencies are in place. However, if you would like to share the solution or run it in a different environment, you can use the containerized version.

1. Start Docker and make sure it's running.
1. From a terminal, navigate in the folder `03-GettingStarted\samples\csharp\src` 
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` （請替換為您的 Docker Hub 使用者名稱）取得：
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. 映像檔建立完成後，我們將它上傳到 Docker Hub。請執行以下指令：
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## 使用 Docker 化版本

1. 在 `.vscode/mcp.json` 檔案中，將伺服器設定替換為以下內容：
   ```json
    "mcp-calc": {
      "command": "docker",
      "args": [
        "run",
        "--rm",
        "-i",
        "<YOUR-DOCKER-USERNAME>/mcp-calc"
      ],
      "envFile": "",
      "env": {}
    }
   ```
   從設定中可以看到，指令為 `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`，就像之前一樣，您可以請計算器服務幫您做一些數學運算。

**免責聲明**：  
本文件乃使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們對因使用本翻譯而引致的任何誤解或誤釋概不負責。