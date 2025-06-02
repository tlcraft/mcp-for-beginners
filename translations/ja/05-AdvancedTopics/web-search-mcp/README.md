<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b0660b689ab793a8e9aefe29fb7f8b6a",
  "translation_date": "2025-06-02T13:06:31+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ja"
}
-->
# レッスン: Web検索MCPサーバーの構築

この章では、外部APIと連携し、多様なデータタイプを扱い、エラーを管理し、複数のツールをオーケストレーションする実践的なAIエージェントの構築方法を紹介します。以下の内容を学べます：

- **認証が必要な外部APIとの統合**
- **複数のエンドポイントからの多様なデータタイプの処理**
- **堅牢なエラーハンドリングとログ戦略**
- **単一サーバーでのマルチツールオーケストレーション**

このレッスンを終える頃には、高度なAIやLLM搭載アプリケーションに欠かせないパターンやベストプラクティスを実践的に習得できます。

## はじめに

このレッスンでは、SerpAPIを使ってリアルタイムのウェブデータでLLMの能力を拡張する高度なMCPサーバーとクライアントの構築方法を学びます。最新のウェブ情報にアクセスできる動的なAIエージェント開発において重要なスキルです。

## 学習目標

このレッスンの終了時には、以下ができるようになります：

- SerpAPIなどの外部APIを安全にMCPサーバーに統合する
- ウェブ、ニュース、商品検索、Q&A用の複数ツールを実装する
- 構造化データをLLM向けに解析・整形する
- エラー処理とAPIのレート制限管理を効果的に行う
- 自動化および対話型のMCPクライアントを構築・テストする

## Web検索MCPサーバー

このセクションでは、Web検索MCPサーバーのアーキテクチャと特徴を紹介します。FastMCPとSerpAPIを組み合わせて、リアルタイムのウェブデータでLLMの機能を拡張する方法を見ていきます。

### 概要

この実装では、MCPが多様な外部APIベースのタスクを安全かつ効率的に処理できることを示す4つのツールを備えています：

- **general_search**：幅広いウェブ検索用
- **news_search**：最新ニュースの検索用
- **product_search**：eコマースデータの検索用
- **qna**：質問応答スニペット用

### 特徴
- **コード例**：Pythonの言語別コードブロックを含み、他言語への拡張も容易。折りたたみセクションで見やすく整理。

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

クライアントを実行する前に、サーバーの動作を理解しておくと便利です。[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)をご覧ください。

サーバーがツールを定義し登録する簡単な例を紹介します：

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

- **外部API統合**：APIキーや外部リクエストの安全な取り扱いを示す
- **構造化データ解析**：APIレスポンスをLLMが扱いやすい形式に変換
- **エラーハンドリング**：適切なログ出力を伴う堅牢なエラー処理
- **対話型クライアント**：自動テストと対話モードの両方を含む
- **コンテキスト管理**：MCPコンテキストを活用したログとリクエスト追跡

## 前提条件

開始する前に、以下の手順で環境を整えてください。これにより依存関係がインストールされ、APIキーが正しく設定されてスムーズに開発・テストが行えます。

- Python 3.8以上
- SerpAPI APIキー（[SerpAPI](https://serpapi.com/)で無料プランに登録可能）

## インストール

環境構築のため、以下の手順に従ってください：

1. uv（推奨）またはpipで依存関係をインストール：

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. プロジェクトルートに`.env`ファイルを作成し、SerpAPIキーを設定：

```
SERPAPI_KEY=your_serpapi_key_here
```

## 使い方

Web検索MCPサーバーは、SerpAPIと連携してウェブ、ニュース、商品検索、Q&Aのツールを提供するコアコンポーネントです。リクエストを受け取り、API呼び出しを管理し、レスポンスを解析して構造化結果をクライアントに返します。

完全な実装は[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py)で確認できます。

### サーバーの起動

MCPサーバーを起動するには、以下のコマンドを使います：

```bash
python server.py
```

このサーバーはstdioベースのMCPサーバーとして動作し、クライアントが直接接続可能です。

### クライアントモード

クライアントは(`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)にあります。

### クライアントの実行

自動テストを実行する（サーバーも自動起動）：

```bash
python client.py
```

または対話モードで実行：

```bash
python client.py --interactive
```

### 様々な方法でのテスト

サーバーが提供するツールを、用途やワークフローに応じてさまざまな方法でテスト・操作できます。

#### MCP Python SDKを使ったカスタムテストスクリプト作成
MCP Python SDKを使い、自分でテストスクリプトを作成することも可能です：

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

ここでいう「テストスクリプト」とは、MCPサーバーのクライアントとして動作するカスタムPythonプログラムのことです。正式な単体テストではなく、プログラムからサーバーに接続し、任意のツールをパラメータ付きで呼び出し、結果を検査できます。以下の用途に役立ちます：

- ツール呼び出しの試作や実験
- サーバーの応答検証
- ツールの繰り返し呼び出しの自動化
- MCPサーバー上での独自ワークフローや統合の構築

新しいクエリの素早い試行やツールの挙動デバッグ、高度な自動化の出発点としても活用できます。以下はMCP Python SDKを使ったスクリプト例です：

## ツールの説明

サーバーが提供する各ツールは、さまざまな検索やクエリを実行できます。以下に各ツールの説明、パラメータ、使用例を示します。

### general_search

一般的なウェブ検索を行い、整形済みの結果を返します。

**呼び出し方法：**

MCP Python SDKを使ったスクリプトやInspector、対話型クライアントモードから`general_search`を呼び出せます。SDK使用例は以下：

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
- `query`（文字列）：検索クエリを選択します。

**リクエスト例：**

```json
{
  "query": "latest AI trends"
}
```

### news_search

指定クエリに関連する最新ニュース記事を検索します。

**呼び出し方法：**

MCP Python SDK、Inspector、対話型クライアントから`news_search`を呼び出せます。SDK例は以下：

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
- `query`（文字列）：検索クエリを選択します。

**リクエスト例：**

```json
{
  "query": "AI policy updates"
}
```

### product_search

クエリにマッチする商品を検索します。

**呼び出し方法：**

MCP Python SDK、Inspector、対話型クライアントから`product_search`を呼び出せます。SDK例は以下：

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
- `query`（文字列）：商品検索クエリを選択します。

**リクエスト例：**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

検索エンジンから質問への直接回答を取得します。

**呼び出し方法：**

MCP Python SDK、Inspector、対話型クライアントから`qna`を呼び出せます。SDK例は以下：

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
- `question`（文字列）：回答を求める質問を選択します。

**リクエスト例：**

```json
{
  "question": "what is artificial intelligence"
}
```

## コード詳細

サーバーとクライアントの実装に関するコード断片と参照を提供します。

<details>
<summary>Python</summary>

完全な実装は[`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py)でご確認ください。

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## このレッスンの高度な概念

構築を始める前に、この章で登場する重要な高度な概念を理解しておくとスムーズに進められます：

- **マルチツールオーケストレーション**：ウェブ検索、ニュース検索、商品検索、Q&Aなど複数のツールを単一のMCPサーバー内で動かすこと。多様なタスクに対応可能です。
- **APIレート制限の管理**：多くの外部APIは一定時間内のリクエスト数を制限します。これを検知して適切に処理することで、アプリの異常停止を防ぎます。
- **構造化データ解析**：APIレスポンスは複雑かつ入れ子構造の場合が多いです。これをLLMや他のプログラムが扱いやすい形式に変換する技術です。
- **エラー回復**：ネットワーク障害や予期しないAPIレスポンスなど問題発生時にも、クラッシュせずに有用なフィードバックを返す処理です。
- **パラメータ検証**：ツールへの入力が正しく安全かどうかチェックし、デフォルト値の設定や型の確認を行うことでバグや混乱を防ぎます。

このセクションは、Web検索MCPサーバーを扱う際に遭遇しやすい問題の診断と解決に役立ちます。エラーや予期しない挙動があれば、まずはここを確認してください。多くの問題は以下のヒントで素早く解決できます。

## トラブルシューティング

Web検索MCPサーバーを使用していると、外部APIや新しいツールの開発時に問題が発生することがあります。このセクションでは、最も一般的な問題とその解決策を紹介します。問題に直面したらまずここを確認してください。多くのケースで追加のサポートなしに解決できます。

### よくある問題

以下はユーザーがよく遭遇する問題と、その説明および解決手順です：

1. **.envファイルにSERPAPI_KEYがない**
   - `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your `.env`ファイルを作成し設定してください。キーが正しいのにエラーが出る場合は、無料プランのクォータ切れを確認してください。

### デバッグモード

デフォルトでは、アプリは重要な情報のみログ出力します。詳細な動作状況を確認したい場合（特にトラブルシューティング時）は、DEBUGモードを有効にするとHTTPリクエストやレスポンスなど内部の詳細なログが表示されます。

**通常出力例**
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

DEBUGモードではHTTP通信やその他内部処理の追加ログが表示され、問題解決に役立ちます。

DEBUGモードを有効にするには、`client.py` or `server.py`の先頭でログレベルをDEBUGに設定してください：

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
本書類はAI翻訳サービス「Co-op Translator」（https://github.com/Azure/co-op-translator）を使用して翻訳されています。正確性を期していますが、自動翻訳には誤りや不正確な部分が含まれる可能性があることをご承知ください。原文の言語によるオリジナル文書が正式な情報源とみなされます。重要な情報については、専門の人間による翻訳を推奨します。本翻訳の利用により生じたいかなる誤解や誤訳についても、当方は責任を負いかねます。