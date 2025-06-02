<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc249f8b228953fafca05f94bb572aac",
  "translation_date": "2025-06-02T18:35:05+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ja"
}
-->
# レッスン: Web検索MCPサーバーの構築

この章では、外部APIと連携し、多様なデータタイプを扱い、エラー管理を行い、複数のツールを統合した、実践的なAIエージェントの作り方を紹介します。以下の内容が学べます：

- **認証が必要な外部APIとの統合**
- **複数エンドポイントからの多様なデータタイプの処理**
- **堅牢なエラー処理とログ戦略**
- **単一サーバー内でのマルチツールのオーケストレーション**

このレッスンの終わりには、高度なAIやLLM搭載アプリケーションに欠かせないパターンとベストプラクティスを実践的に理解できます。

## はじめに

このレッスンでは、SerpAPIを使ってリアルタイムのウェブデータでLLMの機能を拡張する、高度なMCPサーバーとクライアントの構築方法を学びます。最新情報にアクセスできる動的なAIエージェントを開発するために重要なスキルです。

## 学習目標

このレッスンの終了時には、以下ができるようになります：

- SerpAPIのような外部APIを安全にMCPサーバーに統合する
- ウェブ、ニュース、商品検索、Q&A用の複数ツールを実装する
- LLMが扱いやすい形式に構造化データを解析・整形する
- エラー処理とAPIのレート制限を効果的に管理する
- 自動化テストと対話型のMCPクライアントの両方を構築・テストする

## Web検索MCPサーバー

このセクションでは、Web検索MCPサーバーのアーキテクチャと機能を紹介します。FastMCPとSerpAPIを組み合わせて、リアルタイムのウェブデータでLLMの機能を拡張する方法を学びます。

### 概要

この実装には、MCPが多様な外部API駆動のタスクを安全かつ効率的に処理できることを示す4つのツールが含まれています：

- **general_search**：幅広いウェブ検索用
- **news_search**：最新ニュースの検索用
- **product_search**：ECデータ検索用
- **qna**：質問応答スニペット用

### 機能
- **コード例**：Pythonの言語別コードブロックを含み（他言語への拡張も容易）、折りたたみ可能なセクションで見やすくしています

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

クライアントを実行する前に、サーバーが何をしているかを理解すると便利です。[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) を参照してください。

サーバーがツールを定義し登録する簡単な例を示します：

<details>  
<summary>Pythonサーバー</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **外部API統合**：APIキーと外部リクエストの安全な取り扱いを示しています
- **構造化データ解析**：APIレスポンスをLLM向けに変換する方法を紹介
- **エラー処理**：適切なログ出力を伴う堅牢なエラー処理
- **対話型クライアント**：自動テストと対話モードの両方を含む
- **コンテキスト管理**：MCP Contextを利用したログ記録とリクエスト追跡

## 前提条件

始める前に、環境が正しくセットアップされていることを以下の手順で確認してください。これにより依存関係がすべてインストールされ、APIキーが正しく設定されてスムーズに開発・テストが行えます。

- Python 3.8以上
- SerpAPI APIキー（[SerpAPI](https://serpapi.com/)で登録、無料プランあり）

## インストール

環境をセットアップするために、以下の手順に従ってください：

1. uv（推奨）またはpipで依存関係をインストール：

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. プロジェクトルートに`.env`ファイルを作成し、SerpAPIキーを記入：

```
SERPAPI_KEY=your_serpapi_key_here
```

## 使い方

Web検索MCPサーバーは、SerpAPIと連携してウェブ、ニュース、商品検索、Q&Aのツールを提供するコアコンポーネントです。リクエストの処理、API呼び出しの管理、レスポンスの解析、構造化結果のクライアントへの返却を行います。

完全な実装は[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)で確認できます。

### サーバーの起動

MCPサーバーを起動するには、以下のコマンドを使います：

```bash
python server.py
```

このサーバーはstdioベースのMCPサーバーとして動作し、クライアントが直接接続できます。

### クライアントモード

クライアントは（`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)）で提供されています。

### クライアントの実行

自動テストを実行する（サーバーも自動起動）には：

```bash
python client.py
```

対話モードで実行するには：

```bash
python client.py --interactive
```

### さまざまな方法でのテスト

用途やワークフローに応じて、サーバーのツールをテスト・操作する方法はいくつかあります。

#### MCP Python SDKでカスタムテストスクリプトを書く
MCP Python SDKを使って独自のテストスクリプトを作成することも可能です：

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

ここでの「テストスクリプト」とは、MCPサーバーのクライアントとして動作する独自のPythonプログラムのことです。正式なユニットテストではなく、プログラム的にサーバーに接続し、任意のツールをパラメータ付きで呼び出し、結果を検査できます。この方法は以下に役立ちます：

- ツール呼び出しのプロトタイピングや実験
- サーバーの入力に対する応答の検証
- 繰り返しのツール呼び出しの自動化
- MCPサーバー上での独自のワークフローや統合構築

新しいクエリの試行、ツールの動作のデバッグ、より高度な自動化の出発点としてテストスクリプトを活用できます。以下はMCP Python SDKを使った例です：

## ツール説明

サーバーが提供する以下のツールを使って、さまざまな検索やクエリが可能です。各ツールのパラメータと使用例を説明します。

このセクションでは、利用可能な各ツールの詳細とパラメータを紹介します。

### general_search

一般的なウェブ検索を行い、整形済みの結果を返します。

**このツールの呼び出し方：**

MCP Python SDKを使って自作スクリプトから呼び出すか、Inspectorや対話型クライアントモードで操作できます。以下はSDKを使ったコード例です：

<details>
<summary>Python例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

対話モードでは、`general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（文字列）：検索クエリを選択してください。

**リクエスト例：**

```json
{
  "query": "latest AI trends"
}
```

### news_search

クエリに関連する最近のニュース記事を検索します。

**このツールの呼び出し方：**

MCP Python SDKを使ったスクリプト、Inspector、対話型クライアントで呼び出せます。以下はSDKの例：

<details>
<summary>Python例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

対話モードでは、`news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（文字列）：検索クエリを選択してください。

**リクエスト例：**

```json
{
  "query": "AI policy updates"
}
```

### product_search

クエリにマッチする商品を検索します。

**このツールの呼び出し方：**

MCP Python SDKを使ったスクリプト、Inspector、対話型クライアントで呼び出せます。以下はSDKの例：

<details>
<summary>Python例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

対話モードでは、`product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query`（文字列）：商品検索クエリを選択してください。

**リクエスト例：**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

検索エンジンから質問に対する直接回答を取得します。

**このツールの呼び出し方：**

MCP Python SDKを使ったスクリプト、Inspector、対話型クライアントで呼び出せます。以下はSDKの例：

<details>
<summary>Python例</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

対話モードでは、`qna` from the menu and enter your question when prompted.

**Parameters:**
- `question`（文字列）：回答を求める質問を選択してください。

**リクエスト例：**

```json
{
  "question": "what is artificial intelligence"
}
```

## コード詳細

このセクションでは、サーバーとクライアントの実装に関するコードスニペットと参照を提供します。

<details>
<summary>Python</summary>

完全な実装詳細は[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)をご覧ください。

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## このレッスンの高度な概念

構築を始める前に、この章で繰り返し登場する重要な高度な概念を紹介します。これらを理解しておくと、初心者でもスムーズに学習を進められます：

- **マルチツールのオーケストレーション**：ウェブ検索、ニュース検索、商品検索、Q&Aなど複数のツールを単一のMCPサーバーで動かすこと。サーバーが多様なタスクを処理可能にします。
- **APIレート制限の管理**：SerpAPIのような外部APIは一定時間内のリクエスト数を制限しています。これを検知し、適切に対応するコードを書くことで、アプリが制限に引っかかっても安定動作します。
- **構造化データ解析**：APIレスポンスは複雑でネストされていることが多いです。これをLLMや他のプログラムが扱いやすいきれいな形式に変換することを指します。
- **エラー回復**：ネットワーク障害やAPIから期待外のレスポンスが返ることがあります。エラー回復は、そうした問題を処理してクラッシュせず有用なフィードバックを返すことです。
- **パラメータ検証**：ツールへの入力が正しく安全であるかチェックし、デフォルト値を設定し、型を確認することでバグや混乱を防ぎます。

## トラブルシューティング

Web検索MCPサーバーを使っていると、時折問題に遭遇することがあります。これは外部APIや新しいツールを使う際にはよくあることです。このセクションではよくある問題への実践的な解決策を示し、早期復旧を助けます。エラーが発生したらまずここを確認してください。以下のヒントは多くのユーザーの問題を解決し、追加の支援なしに対処可能です。

### よくある問題

以下はユーザーがよく遭遇する問題と、その解決方法です：

1. **.envファイルにSERPAPI_KEYがない**
   - `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `` というエラーが出たら、`.env`ファイルを作成してキーを設定してください。キーが正しいのにエラーが続く場合は、無料プランのクォータが切れていないか確認しましょう。

### デバッグモード

デフォルトではアプリは重要な情報のみをログに出力します。問題の詳細を調査したい場合は、DEBUGモードを有効にすると、処理の各ステップに関する詳細な情報が表示されます。

**通常の出力例**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**DEBUG出力例**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

DEBUGモードではHTTPリクエストやレスポンス、内部処理の詳細が追加で表示されるため、トラブルシューティングに非常に役立ちます。

DEBUGモードを有効にするには、`client.py` or `server.py`の冒頭でログレベルをDEBUGに設定してください：

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## 次に進むには

- [6. Community Contributions](../../06-CommunityContributions/README.md)

**免責事項**：  
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されました。正確性には努めておりますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご了承ください。原文の言語による原本が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の使用により生じた誤解や解釈の相違について、当方は一切の責任を負いかねます。