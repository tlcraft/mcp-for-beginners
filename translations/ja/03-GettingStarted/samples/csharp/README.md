<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "882aae00f1d3f007e20d03b883f44afa",
  "translation_date": "2025-06-18T05:51:47+00:00",
  "source_file": "03-GettingStarted/samples/csharp/README.md",
  "language_code": "ja"
}
-->
# Basic Calculator MCP Service

このサービスは、Model Context Protocol（MCP）を通じて基本的な計算機能を提供します。MCPの実装を学ぶ初心者向けのシンプルな例として設計されています。

詳細は[C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)をご覧ください。

## Features

この計算機サービスは以下の機能を提供します：

1. **基本的な算術演算**：
   - 2つの数値の加算
   - 1つの数値から別の数値の減算
   - 2つの数値の乗算
   - 1つの数値を別の数値で除算（ゼロ除算のチェック付き）

## Using `stdio` Type

## Configuration

1. **MCPサーバーの設定**：
   - VS Codeでワークスペースを開きます。
   - ワークスペースフォルダ内に`.vscode/mcp.json`ファイルを作成し、MCPサーバーを設定します。設定例：

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

   - GitHubリポジトリのルートを入力するよう求められます。これはコマンド `git rev-parse --show-toplevel`.

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
1. To build the Docker image for the calculator service, execute the following command (replace `<YOUR-DOCKER-USERNAME>` から取得できます（<YOUR-DOCKER-USERNAME>はDocker Hubのユーザー名に置き換えてください）：
   ```bash
   docker build -t <YOUR-DOCKER-USERNAME>/mcp-calculator .
   ``` 
1. イメージのビルドが完了したら、Docker Hubにアップロードしましょう。以下のコマンドを実行します：
   ```bash
    docker push <YOUR-DOCKER-USERNAME>/mcp-calculator
  ```

## Docker化されたバージョンの利用

1. `.vscode/mcp.json`ファイル内で、サーバーの設定を以下のように置き換えます：
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
   設定を見ると、コマンドは `docker` and the args are `run --rm -i <YOUR-DOCKER-USERNAME>/mcp-calc`. The `--rm` flag ensures that the container is removed after it stops, and the `-i` flag allows you to interact with the container's standard input. The last argument is the name of the image we just built and pushed to Docker Hub.

## Test the Dockerized Version

Start the MCP Server by clicking the little Start button above `"mcp-calc": {` となっており、前と同様に計算機サービスに計算を依頼できます。

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性を期しておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知ください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間翻訳をご利用いただくことを推奨します。本翻訳の使用により生じた誤解や誤訳について、当方は一切の責任を負いかねます。