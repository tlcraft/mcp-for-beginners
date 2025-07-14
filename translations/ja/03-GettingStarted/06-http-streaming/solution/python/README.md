<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:17:56+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "ja"
}
-->
# このサンプルの実行方法

クラシックなHTTPストリーミングサーバーとクライアント、そしてMCPストリーミングサーバーとクライアントをPythonで実行する方法をご紹介します。

### 概要

- アイテムを処理しながら進捗通知をクライアントにストリーム配信するMCPサーバーをセットアップします。
- クライアントは各通知をリアルタイムで表示します。
- このガイドでは、前提条件、セットアップ、実行方法、トラブルシューティングを説明します。

### 前提条件

- Python 3.9以降
- `mcp` Pythonパッケージ（`pip install mcp`でインストール）

### インストールとセットアップ

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

1. ソリューションディレクトリに移動します：

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

2. ストリームされたメッセージが順次表示されます：

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

1. ソリューションディレクトリに移動します：
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
2. **リストを処理し、`ctx.info()`や`ctx.log()`で通知を送るツールを定義します。**
3. **`transport="streamable-http"`でサーバーを実行します。**
4. **通知を受け取って表示するメッセージハンドラーを持つクライアントを実装します。**

### コードの解説
- サーバーは非同期関数とMCPコンテキストを使って進捗を送信します。
- クライアントは非同期のメッセージハンドラーを実装し、通知と最終結果を表示します。

### ヒントとトラブルシューティング

- 非同期処理には`async/await`を使い、ブロッキングを避けましょう。
- サーバーとクライアントの両方で例外処理を行い、堅牢性を高めてください。
- 複数のクライアントでテストし、リアルタイム更新を確認しましょう。
- エラーが発生した場合は、Pythonのバージョンや依存関係が正しくインストールされているかを確認してください。

**免責事項**：  
本書類はAI翻訳サービス「[Co-op Translator](https://github.com/Azure/co-op-translator)」を使用して翻訳されました。正確性の向上に努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があります。原文の言語によるオリジナル文書が正式な情報源とみなされるべきです。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。