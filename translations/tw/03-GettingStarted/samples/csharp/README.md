<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0f7a188d6cb4c18fc83e44fede4cadb1",
  "translation_date": "2025-05-17T12:58:28+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "tw"
}
-->
# 基本計算機 MCP 服務

此服務透過模型上下文協議（MCP）提供基本的計算機操作。它被設計為一個簡單的範例，供初學者學習 MCP 實作。

欲了解更多資訊，請參閱 [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## 功能

這個計算機服務提供以下功能：

1. **基本算術運算**：
   - 兩個數字的加法
   - 一個數字減去另一個數字
   - 兩個數字的乘法
   - 一個數字除以另一個數字（包含除零檢查）

## 使用 `stdio` 類型

## 配置

1. **配置 MCP 伺服器**：
   - 在 VS Code 中打開你的工作區。
   - 在工作區資料夾中創建一個 `.vscode/mcp.json` 文件以配置 MCP 伺服器。範例配置：
     ```json
     {
       "servers": {
         "MyCalculator": {
           "type": "stdio",
           "command": "dotnet",
           "args": [
                "run",
                "--project",
                "D:\\source\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj"
            ],
           "env": {}
         }
       }
     }
     ```
   - 將路徑替換為你的專案路徑。路徑應為絕對路徑，而非相對於工作區資料夾的路徑。（範例：D:\\gh\\mcp-for-beginners\\03-GettingStarted\\samples\\csharp\\src\\calculator.csproj）

## 使用服務

服務透過 MCP 協議提供以下 API 端點：

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` 用你的 Docker Hub 使用者名稱替換：
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. 建立映像後，讓我們將其上傳到 Docker Hub。執行以下命令：
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## 使用 Docker 化版本

1. 在 `.vscode/mcp.json` 文件中，用以下配置替換伺服器配置：
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
   查看配置，你可以看到命令是 `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {`，如同之前一樣，你可以要求計算機服務為你進行一些數學計算。

**免責聲明**：
本文檔已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。儘管我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始語言的文件應被視為權威來源。對於重要信息，建議尋求專業人工翻譯。我們對因使用此翻譯而產生的任何誤解或誤讀不承擔責任。