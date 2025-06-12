<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-06-12T22:21:15+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "ja"
}
-->
# このサンプルの実行方法

Pythonを使って、クラシックなHTTPストリーミングサーバーとクライアント、そしてMCPストリーミングサーバーとクライアントを実行する方法をご紹介します。

### 概要

- アイテムを処理しながら、進捗通知をクライアントにストリーミングするMCPサーバーをセットアップします。
- クライアントは各通知をリアルタイムで表示します。
- このガイドでは、前提条件、セットアップ、実行方法、トラブルシューティングを解説します。

### 前提条件

- Python 3.9以上
- `mcp` Pythonパッケージ（`pip install mcp`でインストール）

### インストール＆セットアップ

1. リポジトリをクローンするか、ソリューションファイルをダウンロードします。

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **仮想環境を作成して有効化します（推奨）：**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **必要な依存関係をインストールします：**

   ```pwsh
   pip install "mcp[cli]"
   ```

### ファイル構成

- **サーバー:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **クライアント:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### クラシックHTTPストリーミングサーバーの実行

1. ソリューションのディレクトリに移動します：

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. クラシックHTTPストリーミングサーバーを起動します：

   ```pwsh
   python server.py
   ```

3. サーバーが起動し、以下のように表示されます：

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### クラシックHTTPストリーミングクライアントの実行

1. 新しいターミナルを開き（同じ仮想環境とディレクトリを有効化）：

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. ストリーミングされたメッセージが順次表示されるはずです：

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### MCPストリーミングサーバーの実行

1. ソリューションのディレクトリに移動します：
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. streamable-httpトランスポートを使ってMCPサーバーを起動します：
   ```pwsh
   python server.py mcp
   ```
3. サーバーが起動し、以下のように表示されます：
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCPストリーミングクライアントの実行

1. 新しいターミナルを開き（同じ仮想環境とディレクトリを有効化）：
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. サーバーが各アイテムを処理するたびに通知がリアルタイムで表示されます：
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### 主要な実装ステップ

1. **FastMCPを使ってMCPサーバーを作成します。**
2. **リストを処理しながら、`ctx.info()` or `ctx.log()`.**
3. **Run the server with `transport="streamable-http"`.**
4. **Implement a client with a message handler to display notifications as they arrive.**

### Code Walkthrough
- The server uses async functions and the MCP context to send progress updates.
- The client implements an async message handler to print notifications and the final result.

### Tips & Troubleshooting

- Use `async/await` を使って通知を送るツールを定義します（非同期処理のため）。**
- サーバーとクライアントの両方で例外処理を行い、堅牢性を確保しましょう。
- 複数のクライアントでテストしてリアルタイム更新を確認してください。
- エラーが発生した場合は、Pythonのバージョンや依存関係のインストール状況を確認してください。

**免責事項**:  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されています。正確性には努めておりますが、自動翻訳には誤りや不正確な箇所が含まれる可能性があります。原文の言語によるオリジナル文書が権威ある情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じた誤解や解釈の相違について、当方は一切責任を負いかねます。